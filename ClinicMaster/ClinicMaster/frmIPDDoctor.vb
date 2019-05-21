
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmIPDDoctor

#Region " Fields "
    Private padItemNo As Integer = 4
    Private clinicalFindingsSaved As Boolean = True
    Private IPDeyeAssessmentSaved As Boolean = True
    Private IPDorthopticsSaved As Boolean = True
    Private currentAllSaved As Boolean = True
    Private currentAdmissionNo As String = String.Empty
    Private currentRoundNo As String = String.Empty
    Private labTests As DataTable
    Private cardiologyExaminations As DataTable

    Private radiologyExaminations As DataTable
    Private pathologyExaminations As DataTable
    Private procedures As DataTable
    Private theatreServices As DataTable
    Private dentalService As DataTable
    Private dentalLaboratory As DataTable
    Private diseases As DataTable
    Private Shared totalCost As Decimal = 0

    Private hasPackage As Boolean = False
    Private patientpackageNo As String = String.Empty

    Private labResultsIPDAlerts As DataTable
    Private cardiologyReportsIPDAlerts As DataTable

    Private radiologyReportsIPDAlerts As DataTable
    Private alertCheckPeriod As Integer
    Private iPDAlertsStartDateTime As Date = Now

    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private _TestValue As String = String.Empty
    Private _DrugNo As String = String.Empty
    Private _DiagnosisCode As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _ExamNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _DentalNameValue As String = String.Empty
    Private _DentalLabNameValue As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private _TestCode As String = String.Empty
    Private _TheatreCode As String = String.Empty

    Private OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
    Private proPaint As New System.Diagnostics.Process

    Private WithEvents docDoctor As New PrintDocument()
    Private WithEvents docMedicalReport As New PrintDocument()


    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private doctorParagraphs As Collection
    Private medicalReportParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private priorityID As String



#End Region

#Region " Validations "

    Private Sub dtpRoundDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles stbRoundDateTime.Validating

        Dim errorMSG As String = "Round date time can't be before admission date time!"

        Try

            Dim admissionDateTime As Date = DateTimeMayBeEnteredIn(Me.stbAdmissionDateTime)
            Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbRoundDateTime)

            If GetShortDate(roundDateTime) = AppData.NullDateValue Then Return

            If roundDateTime < admissionDateTime Then
                ErrProvider.SetError(Me.stbRoundDateTime, errorMSG)
                Me.stbRoundDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.stbRoundDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

#Region " Properties "

    Private ReadOnly Property NewVisionAssessment() As String
        Get
            Return "Register Vision Assessment..."
        End Get
    End Property

    Private ReadOnly Property EditVisionAssessmentTest() As String
        Get
            Return "Edit Vision Assessment..."
        End Get
    End Property

    Private ReadOnly Property NewVisionAssessmentTwo() As String
        Get
            Return "Register 2nd Vision Assessment..."
        End Get
    End Property

    Private ReadOnly Property EditVisionAssessmentTestTwo() As String
        Get
            Return "Edit 2nd Vision Assessment..."
        End Get
    End Property

#End Region

    Private Sub frmIPDDoctor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            proPaint = Nothing
            Me.chkCreateNewRound.Checked = True
            Me.EnableResetRoundCTLS(True, True)

            Me.stbRoundDateTime.MaxDate = Today.AddDays(1)
            Me.stbRoundDateTime.Value = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()
            Me.LoadCardiologyExaminations()
            Me.LoadRadiologyExaminations()
            Me.LoadProcedures()
            Me.LoadTheatreServices()
            Me.LoadDentalCategoryService()
            Me.LoadDentalCategoryLaboratory()
            Me.LoadPathologyExaminations()
            Me.ShowAllIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboCoverTestID, LookupObjects.CoverTest, True)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LockItemsUnitPrices()
            Me.labTests = LoadLabTests()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertCheckPeriod = InitOptions.AlertCheckPeriod \ 2
            If alertCheckPeriod > 0 Then
                Me.tmrIPDAlerts.Interval = 1000 * 60 * alertCheckPeriod
            Else : Me.tmrIPDAlerts.Interval = 1000 * 60
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmIPDDoctor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowAllIPDAlerts()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub frmDoctor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            If Not Me.AllSaved() Then
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                Else : CloseProcess(proPaint)
                End If
            Else : CloseProcess(proPaint)
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub stbAdmissionNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbAdmissionNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub cboRoundNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        If Me.AllSaved() Then Me.Close()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function LoadLabTests() As DataTable

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            Return labTests

        Catch ex As Exception
            Throw (ex)


        End Try

    End Function

    Private Sub LoadCardiologyExaminations()

        Dim oCardiologyExaminations As New SyncSoft.SQLDb.CardiologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from CardiologyExaminations
            If Not InitOptions.LoadCardiologyExaminationsAtStart Then
                cardiologyExaminations = oCardiologyExaminations.GetCardiologyExaminations().Tables("CardiologyExaminations")
                oSetupData.CardiologyExaminations = cardiologyExaminations
            Else : cardiologyExaminations = oSetupData.CardiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colCardiologyExamFullName, cardiologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadRadiologyExaminations()

        Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RadiologyExaminations
            If Not InitOptions.LoadRadiologyExaminationsAtStart Then
                radiologyExaminations = oRadiologyExaminations.GetRadiologyExaminations().Tables("RadiologyExaminations")
                oSetupData.RadiologyExaminations = radiologyExaminations
            Else : radiologyExaminations = oSetupData.RadiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExamFullName, radiologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPathologyExaminations()

        Dim oPathologyExaminations As New SyncSoft.SQLDb.PathologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            'Load Pathology Examinations
            If Not InitOptions.LoadRadiologyExaminationsAtStart Then
                pathologyExaminations = oPathologyExaminations.GetPathologyExaminations().Tables("PathologyExaminations")
                oSetupData.RadiologyExaminations = pathologyExaminations
            Else : pathologyExaminations = oSetupData.RadiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colPathologyExamFullName, pathologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

   Private Sub LoadProcedures()

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Procedures
            If Not InitOptions.LoadProceduresAtStart Then
                procedures = oProcedures.GetProcedures().Tables("Procedures")
                oSetupData.Procedures = procedures
            Else : procedures = oSetupData.Procedures
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalCategoryService()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            dentalService = oDentalServices.GetDentalServicesByCategory(oDentalCategoryID.Service).Tables("DentalServices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalService, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalCategoryLaboratory()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            dentalLaboratory = oDentalServices.GetDentalServicesByCategory(oDentalCategoryID.Laboratory).Tables("DentalServices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalLabCode.Sorted = False
            LoadComboData(Me.colDentalLabCode, dentalLaboratory, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function LoadDiseases() As DataTable

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            If Not InitOptions.LoadDiseasesAtStart Then
                diseases = oDiseases.GetDiseases().Tables("Diseases")
                oSetupData.Diseases = diseases
            Else : diseases = oSetupData.Diseases
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return diseases

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub SetNextRoundNo(ByVal admissionNo As String)

        Try

            Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("IPDDoctor", "RoundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim roundID As String = oIPDDoctor.GetNextRoundID(admissionNo).ToString()
            roundID = roundID.PadLeft(paddingLEN, paddingCHAR)

            Me.cboRoundNo.Text = FormatText(admissionNo + roundID.Trim(), "IPDDoctor", "RoundNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then
                Me.cboRoundNo.Items.Clear()
                Me.cboRoundNo.Text = String.Empty
            Else : Me.LoadIPDDoctorByAdmissionNo()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)
            Me.ShowlatestIPDVisionAssessment(admissionNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()
        End Try

    End Sub

    Private Sub LoadIPDDoctorByAdmissionNo()

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            If String.IsNullOrEmpty(admissionNo) Then Return

            ' Load from IPDDoctor 
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNo(admissionNo).Tables("IPDDoctor")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Items.Clear()
            For pos As Integer = 0 To iPDDoctor.Rows.Count - 1
                Me.cboRoundNo.Items.Add(FormatText(CStr(iPDDoctor.Rows(pos).Item("RoundNo")), "IPDDoctor", "RoundNo"))
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.cboRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadRounds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadRounds.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fIPDDoctorRounds As New frmIPDDoctorRounds(Me.cboRoundNo)
        fIPDDoctorRounds.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fInWardAdmissions.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.ShowPatientDetails(admissionNo)
        Me.ShowlatestIPDVisionAssessment(admissionNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.chkCreateNewRound.Checked Then Me.LoadIPDDoctorByAdmissionNo()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ClearControls()
        Me.stbPackage.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbVisitNo.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.stbTotalIPDDoctorRounds.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbBillAccountNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbBillMode.Clear()
        Me.spbPhoto.Image = Nothing
        billModesID = String.Empty
        associatedBillNo = String.Empty
        Me.btnAddConsumables.Enabled = False
        Me.btnNewVisionAssessment.Enabled = False
        Me.btnAddExtraCharge.Enabled = False
        Me.nbxWeight.Clear()
        Me.nbxTemperature.Clear()
        Me.nbxHeight.Clear()
        Me.nbxPulse.Clear()
        Me.stbBloodPressure.Clear()
        Me.nbxHeadCircum.Clear()
        Me.nbxBodySurfaceArea.Clear()
        hasPackage = False
        patientpackageNo = String.Empty
        If Me.chkCreateNewRound.Checked Then Me.cboRoundNo.Text = String.Empty
        Me.ResetControls()

    End Sub

    Private Sub ResetControls()

        Me.cboStaffNo.SelectedIndex = -1
        Me.cboStaffNo.SelectedIndex = -1
        Me.stbRoundDateTime.Value = Now
        Me.stbRoundDateTime.Checked = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgClinicalFindings)
        ResetControlsIn(Me.grpTriage)
        ResetControlsIn(Me.grpClinicalNotes)
        ResetControlsIn(Me.tpgLaboratory)
        ResetControlsIn(Me.tpgCardiology)

        ResetControlsIn(Me.tpgRadiology)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgDental)
        ResetControlsIn(Me.tpgDentalLab)
        ResetControlsIn(Me.tpgLabResults)
        ResetControlsIn(Me.tpgCardiologyReports)
        ResetControlsIn(Me.tpgRadiologyReports)
        ResetControlsIn(Me.tpgDiagnosis)
        ResetControlsIn(Me.tpgIPDEyeAssessment)
        ResetControlsIn(Me.tpgIPDOrthoptics)
        ResetControlsIn(Me.tpgIPDVisionAssessment)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        clinicalFindingsSaved = True
        IPDeyeAssessmentSaved = True
        IPDorthopticsSaved = True
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ShowPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try

            Me.ClearControls()

            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = admissions.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")

            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbTotalIPDDoctorRounds.Text = StringEnteredIn(row, "TotalIPDDoctorRounds")
            Me.stbAdmissionStatus.Text = StringMayBeEnteredIn(row, "AdmissionStatus")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbBillAccountNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnAddConsumables.Enabled = True
            Security.Apply(Me.btnAddConsumables, AccessRights.Write)
            Me.btnNewVisionAssessment.Enabled = True
            Security.Apply(Me.btnNewVisionAssessment, AccessRights.Write)
            Me.btnAddExtraCharge.Enabled = True
            Security.Apply(Me.btnAddExtraCharge, AccessRights.Write)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Me.SetNextRoundNo(admissionNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            Throw eX

        End Try

    End Sub

    Private Sub ShowlatestIPDVisionAssessment(ByVal admissionNo As String)

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()
        Dim iPDVisionAssessment As DataTable = oIPDVisionAssessment.GetIPDVisionAssessmentWithAdmissionNo(admissionNo).Tables("IPDVisionAssessment")

        Try

            '  Dim hasLatestVisualAssessment As Boolean = BooleanMayBeEnteredIn(IPDvisionAssessmentRow, "HasIPDVisualAssessment")

            If iPDVisionAssessment Is Nothing OrElse iPDVisionAssessment.Rows.Count > 0 Then
                Dim IPDvisionAssessmentRow As DataRow = iPDVisionAssessment.Rows(0)
                Me.StbVARoundNo.Text = StringEnteredIn(IPDvisionAssessmentRow, "VARoundNo")
                Me.stbEyeTest.Text = StringEnteredIn(IPDvisionAssessmentRow, "EyeTest")
                Me.StbVisualAcuityRight.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityRight")
                Me.StbVisualAcuityRightExt.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityRightExt")
                Me.StbVisualAcuityLeft.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityLeft")
                Me.StbVisualAcuityLeftExt.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityLeftExt")
                Me.StbPreferentialLookingRight.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "PreferentialLookingRight")
                Me.StbPreferentialLookingLeft.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "PreferentialLookingLeft")
                Me.StbEyeNotes.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "Notes")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ShowIPDVisionAssessment(ByVal vAroundNo As String)

        Dim oIPDVisionAssessment As New SyncSoft.SQLDb.IPDVisionAssessment()
        Dim iPDVisionAssessment As DataTable = oIPDVisionAssessment.GetIPDVisionAssessment(vAroundNo).Tables("IPDVisionAssessment")

        Try
            Dim IPDvisionAssessmentRow As DataRow = iPDVisionAssessment.Rows(0)
            Me.StbVARoundNo.Text = StringEnteredIn(IPDvisionAssessmentRow, "VARoundNo")
            Me.stbEyeTest.Text = StringEnteredIn(IPDvisionAssessmentRow, "EyeTest")
            Me.StbVisualAcuityRight.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityRight")
            Me.StbVisualAcuityRightExt.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityRightExt")
            Me.StbVisualAcuityLeft.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityLeft")
            Me.StbVisualAcuityLeftExt.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "VisualAcuityLeftExt")
            Me.StbPreferentialLookingRight.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "PreferentialLookingRight")
            Me.StbPreferentialLookingLeft.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "PreferentialLookingLeft")
            Me.StbEyeNotes.Text = StringMayBeEnteredIn(IPDvisionAssessmentRow, "Notes")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub stbAdmissionNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentAdmissionNo = StringMayBeEnteredIn(Me.stbAdmissionNo)
                ProcessTabKey(True)
            Else : currentAdmissionNo = String.Empty
            End If

        Catch ex As Exception
            currentAdmissionNo = String.Empty
        End Try

    End Sub

    Private Sub stbAdmissionNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.TextChanged
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentAdmissionNo) Then
            Me.stbAdmissionNo.Text = currentAdmissionNo
            Return
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        Me.ResetControls()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbAdmissionNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentAdmissionNo) Then
                Me.stbAdmissionNo.Text = currentAdmissionNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)
            Me.ShowlatestIPDVisionAssessment(admissionNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableResetRoundCTLS(ByVal state As Boolean, ByVal reset As Boolean)

        Me.stbAdmissionNo.Enabled = state
        Me.btnFindAdmissionNo.Enabled = state
        Me.btnFindRoundNo.Enabled = Not state
        Me.btnLoadRounds.Enabled = Not state
        Me.pnlNavigateRounds.Enabled = Not state
        If state Then
            Me.cboRoundNo.Enabled = Not InitOptions.RoundNoLocked
            ResetControlsIn(Me.pnlNavigateRounds)
        Else : Me.cboRoundNo.Enabled = True
        End If
        Me.cboStaffNo.Enabled = state
        Me.stbRoundDateTime.Enabled = state
        Me.btnLoadList.Enabled = state
        Me.btnViewList.Enabled = Not state
        Me.btnViewCardiologyReportsList.Enabled = Not state

        Me.btnViewRadiologyReportsList.Enabled = Not state
        Me.btnViewDispensingStatus.Enabled = Not state

        If reset Then
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)
            ResetControlsIn(Me.tpgClinicalFindings)
            ResetControlsIn(Me.grpTriage)
            ResetControlsIn(Me.grpClinicalNotes)
            ResetControlsIn(Me.tpgLaboratory)
            ResetControlsIn(Me.tpgCardiology)
            ResetControlsIn(Me.tpgRadiology)
            ResetControlsIn(Me.tpgPrescriptions)
            ResetControlsIn(Me.tpgProcedures)
            ResetControlsIn(Me.tpgTheatre)
            ResetControlsIn(Me.tpgDental)
            ResetControlsIn(Me.tpgDentalLab)
            ResetControlsIn(Me.tpgLabResults)
            ResetControlsIn(Me.tpgCardiologyReports)
            ResetControlsIn(Me.tpgRadiologyReports)
            ResetControlsIn(Me.tpgDiagnosis)
            Me.ResetControls()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If

    End Sub

    Private Sub chkCreateNewRound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCreateNewRound.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkCreateNewRound.Checked = Not Me.chkCreateNewRound.Checked
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableResetRoundCTLS(Me.chkCreateNewRound.Checked, True)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnDrawClinicalImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrawClinicalImage.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            LoadProcess(proPaint, "MSPaint.exe", AppData.AppTitle + "-Paint")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadClinicalImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadClinicalImage.Click
        Me.spbClinicalImage.LoadPhoto(Me.spbClinicalImage.ImageSizeLimit)
    End Sub

    Private Sub btnClearClinicalImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearClinicalImage.Click
        Me.spbClinicalImage.DeletePhoto()
    End Sub

    Private Sub cboRoundNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoundNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentRoundNo = StringMayBeEnteredIn(Me.cboRoundNo)
                ProcessTabKey(True)
            Else : currentRoundNo = String.Empty
            End If

        Catch ex As Exception
            currentRoundNo = String.Empty
        End Try

    End Sub

    Private Sub cboRoundNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRoundNo.SelectedIndexChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.cboRoundNo.Text = currentRoundNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub cboRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoundNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.cboRoundNo.Text = currentRoundNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowRoundsHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ShowRoundsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ResetControlsIn(Me.pnlNavigateRounds)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadRoundsData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        End Try

    End Sub

    Private Sub LoadRoundsData(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim iPDDoctorData As EnumerableRowCollection(Of DataRow) = iPDDoctor.AsEnumerable()
            Dim admissionNo As String = (From data In iPDDoctorData Select data.Field(Of String)("AdmissionNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(admissionNo)
            Me.ShowlatestIPDVisionAssessment(admissionNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            Me.cboStaffNo.Text = (From data In iPDDoctorData Select data.Field(Of String)("StaffFullName")).First()
            Me.stbRoundDateTime.Value = (From data In iPDDoctorData Select data.Field(Of Date)("RoundDateTime")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClinicalFindings(roundNo)
            Me.LoadLaboratory(roundNo)
            Me.LoadCardiology(roundNo)
            Me.LoadRadiology(roundNo)
            Me.LoadPrescriptions(roundNo)
            Me.LoadProcedures(roundNo)
            Me.LoadTheatre(roundNo)
            Me.LoadDentalCategoryService(roundNo)
            Me.LoadDentalCategoryLaboratory(roundNo)
            Me.LoadLabResults(roundNo)
            Me.LoadIPDDiagnosis(roundNo)
            Me.LoadIPDCardiologyReports(roundNo)
            Me.LoadIPDRadiologyReports(roundNo)
            Me.LoadIPDEyeAssessment(roundNo)
            Me.LoadIPDOrthoptics(roundNo)
            Me.LoadPathology(roundNo)
            Me.LoadPathologyReports(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgLaboratory.Name
                    Me.CalculateBillForLaboratory()

                Case Me.tpgCardiology.Name
                    Me.CalculateBillForCardiology()

                Case Me.tpgRadiology.Name
                    Me.CalculateBillForRadiology()

                Case Me.tpgPrescriptions.Name
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.CalculateBillForTheatre()

                Case Me.tpgDental.Name
                    Me.CalculateBillForDentalCategoryService()

                Case Me.tpgDentalLab.Name
                    Me.CalculateBillForDentalCategoryLaboratory()

                Case Me.tpgHistopathologyRequisition.Name
                    'Me.CalculateBillForPathology()
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then
                        Me.CalculateBillForPathology()
                    End If

                Case Else : ResetControlsIn(Me.pnlBill)

            End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub tbcDrRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDrRoles.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgClinicalFindings.Name
                    'Me.LoadClinicalFindings()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgClinicalFindings.Text
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = True
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgDiagnosis.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDiagnosis.Text
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgLaboratory.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgLaboratory.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvLabTests.RowCount < 2 Then
                        Me.LoadPackageAttachedLabTests(patientpackageNo)
                    End If
                    Me.CalculateBillForLaboratory()


                Case Me.tpgCardiology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgCardiology.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvCardiology.RowCount < 2 Then
                        Me.LoadPackageAttachedCardiology(patientpackageNo)
                    End If
                    Me.CalculateBillForCardiology()


                Case Me.tpgRadiology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgRadiology.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvRadiology.RowCount < 2 Then
                        Me.LoadPackageAttachedRadiology(patientpackageNo)
                    End If
                    Me.CalculateBillForRadiology()

                Case Me.tpgPrescriptions.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvPrescription.RowCount < 2 Then
                        Me.LoadPackageAllowedPrescriptions(patientpackageNo)
                    End If
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgProcedures.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvProcedures.RowCount < 2 Then
                        Me.LoadPackageAllowedProcedures(patientpackageNo)
                    End If
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTheatre.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForTheatre()

                Case Me.tpgDental.Name
                    'Me.LoadDental()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDental.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForDentalCategoryService()

                Case Me.tpgDentalLab.Name
                    'Me.LoadDentalLab()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDentalLab.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForDentalCategoryLaboratory()

                Case Me.tpgLabResults.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgCardiologyReports.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgRadiologyReports.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgPathology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgHistopathologyRequisition.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForPathology()

                Case Me.tpgPathology.Name
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then
                        Me.lblBillForItem.Text = "Bill for " + Me.tpgHistopathologyRequisition.Text
                        Me.pnlBill.Visible = True
                        Me.btnSave.Visible = True
                        Me.fbnDelete.Visible = False
                        Me.btnPrint.Enabled = True
                        Me.CalculateBillForPathology()
                    Else
                        Me.btnSave.Visible = False
                        Me.fbnDelete.Visible = False
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgIPDEye.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDVisionAssessment.Name) Then
                        Me.btnSave.Visible = False
                        Me.fbnDelete.Visible = False

                    ElseIf Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDEyeAssessment.Name) Then
                        Me.btnSave.Visible = True
                        Me.fbnDelete.Visible = True

                    ElseIf Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDOrthoptics.Name) Then
                        Me.btnSave.Visible = True
                        Me.fbnDelete.Visible = True
                    Else
                        Me.btnSave.Visible = False
                        Me.fbnDelete.Visible = False
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.fbnDelete.Visible = False
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllIPDAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgLabResults.Name) Then
                Me.btnSave.Enabled = False
                Me.fbnDelete.Enabled = False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
                If String.IsNullOrEmpty(roundNo) Then Return
                Me.LoadLabResults(roundNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
                If roundDateTime = AppData.NullDateValue Then Return
                Me.DeleteIPDAlerts(roundNo, roundDateTime)

            ElseIf Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgCardiologyReports.Name) Then
                Me.btnSave.Enabled = False
                Me.fbnDelete.Enabled = False
                Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
                If String.IsNullOrEmpty(roundNo) Then Return
                Me.LoadIPDCardiologyReports(roundNo)
                Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
                If roundDateTime = AppData.NullDateValue Then Return
                Me.DeleteCardiologyReportsAlerts(roundNo, roundDateTime)

            ElseIf Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgRadiologyReports.Name) Then
                Me.btnSave.Enabled = False
                Me.fbnDelete.Enabled = False
                Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
                If String.IsNullOrEmpty(roundNo) Then Return
                Me.LoadIPDRadiologyReports(roundNo)
                Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
                If roundDateTime = AppData.NullDateValue Then Return
                Me.DeleteRadiologyReportsAlerts(roundNo, roundDateTime)

            Else
                Me.btnSave.Enabled = True
                Me.fbnDelete.Enabled = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.ApplySecurity()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click
        Dim oIPDClinicalFindings As New SyncSoft.SQLDb.IPDClinicalFindings()
        Dim oIPDEyeAssessment As New SyncSoft.SQLDb.IPDEyeAssessment()
        Dim oIPDOrthoptics As New SyncSoft.SQLDb.IPDOrthoptics()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim roundNo As String = RevertText(StringEnteredIn(cboRoundNo, "Round No!"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgClinicalFindings.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                    oIPDClinicalFindings.RoundNo = roundNo
                    DisplayMessage(oIPDClinicalFindings.Delete())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me.tpgClinicalFindings)
                    ResetControlsIn(Me.grpClinicalNotes)
                    clinicalFindingsSaved = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgIPDEye.Name

                    If Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDEyeAssessment.Name) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                        oIPDEyeAssessment.RoundNo = roundNo
                        DisplayMessage(oIPDEyeAssessment.Delete())

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ResetControlsIn(Me.tpgIPDEyeAssessment)
                        IPDeyeAssessmentSaved = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ElseIf Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDOrthoptics.Name) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                        oIPDOrthoptics.RoundNo = roundNo
                        DisplayMessage(oIPDOrthoptics.Delete())

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ResetControlsIn(Me.tpgIPDOrthoptics)
                        IPDorthopticsSaved = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End If

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub ClinicalFindingsTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbHistory.TextChanged,
        stbClinicalNotes.TextChanged, stbGeneralAppearance.TextChanged, stbRespiratory.TextChanged, stbCVS.TextChanged, stbAbdomen.TextChanged,
        stbCNS.TextChanged, stbMuscularSkeletal.TextChanged, stbPsychologicalStatus.TextChanged, stbClinicalDiagnosis.TextChanged

        clinicalFindingsSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.cboRoundNo))

    End Sub
    Private Sub IPDEyeAssessmentTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRightPupil.TextChanged, stbLeftPupil.TextChanged, stbRightLidMargin.TextChanged, stbLeftLidMargin.TextChanged,
           stbRightVerticalCornea.TextChanged, stbLeftAnteriorChamber.TextChanged, stbRightIrish.TextChanged, stbLeftIrish.TextChanged, stbRightAnteriorChamberAngle.TextChanged, stbLeftAnteriorChamberAngle.TextChanged,
           stbRightRetina.TextChanged, stbLeftRetina.TextChanged, stbRightMacular.TextChanged, stbLeftMacular.TextChanged, stbLeftOpticDisc.TextChanged, stbRightOpticDisc.TextChanged, stbRightAnteriorChamber.TextChanged,
           stbRightMacular.TextChanged, stbLeftOpticDisc.TextChanged, stbRightVitreous.TextChanged, stbLeftVitreous.TextChanged, stbLeftLense.TextChanged, stbRightLense.TextChanged,
           StbEyeAssessmentNotes.TextChanged, stbLeftOrbit.TextChanged, stbRightOrbit.TextChanged, stbLeftEyeBall.TextChanged, stbRightEyeBall.TextChanged
        IPDeyeAssessmentSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.cboRoundNo))

    End Sub

    Private Sub IPDOrthopticsTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbHeadPosture.TextChanged, stbFixation.TextChanged, stbLeftHirschberg.TextChanged, stbRightHirschberg.TextChanged, stbRightEOM.TextChanged, stbLeftEOM.TextChanged,
       stbLeftAPCTGlasses.TextChanged, stbRightAPCTGlasses.TextChanged, stbLeftAPCTWithOutGlasses.TextChanged, stbRightAPCTWithOutGlasses.TextChanged, stbCorrespondence.TextChanged, stbPrismAdaptation.TextChanged, stbFusionConvergence.TextChanged, stbFusionDivergence.TextChanged, stbFusionRange.TextChanged, stbNearPointOfAccommodation.TextChanged, stbNearPointOfConvergence.TextChanged, stbOrthopticsNotes.TextChanged
        IPDorthopticsSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.cboRoundNo))

    End Sub

#Region " IPDAlerts "

    Private Sub ShowAllIPDAlerts()
        Me.ShowLabResultsIPDAlerts()
        Me.ShowCardiologyReportsIPDAlerts()
        Me.ShowRadiologyReportsIPDAlerts()
    End Sub

    Private Function ShowLabResultsIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            labResultsIPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.LabResults, CurrentUser.LoginID).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = labResultsIPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Ready Results: " + iPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowCardiologyReportsIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from IPDAlerts
            cardiologyReportsIPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.CardiologyReports, CurrentUser.LoginID).Tables("IPDAlerts")

            Dim alertsNo As Integer = cardiologyReportsIPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblCardiologyReportsIPDAlerts.Text = "Cardiology Reports: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowRadiologyReportsIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from IPDAlerts
            radiologyReportsIPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.RadiologyReports, CurrentUser.LoginID).Tables("IPDAlerts")

            Dim alertsNo As Integer = radiologyReportsIPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRadiologyReportsIPDAlerts.Text = "Radiology Reports: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowAllIPDAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.LabResults, Me.cboRoundNo)
        fIPDAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If labResultsIPDAlerts Is Nothing OrElse labResultsIPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = labResultsIPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) And
                                        GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime))
                                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DeleteCardiologyReportsAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If cardiologyReportsIPDAlerts Is Nothing OrElse cardiologyReportsIPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = cardiologyReportsIPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) And
                        GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime))
                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub DeleteRadiologyReportsAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If radiologyReportsIPDAlerts Is Nothing OrElse radiologyReportsIPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = radiologyReportsIPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) And
                        GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime))
                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnViewCardiologyReportsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCardiologyReportsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowCardiologyReportsIPDAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.CardiologyReports, Me.cboRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub


    Private Sub btnViewRadiologyReportsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRadiologyReportsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRadiologyReportsIPDAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.RadiologyReports, Me.cboRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewDispensingStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDispensingStatus.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fDoctorIPDItems As New frmDoctorIPDItems(Me.cboRoundNo, AlertItemCategory.Drug)
            fDoctorIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowRoundsHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrIPDAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrIPDAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, iPDAlertsStartDateTime, Now)
            If period >= alertCheckPeriod Then
                If Me.ShowLabResultsIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub btnAddConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim fIPDConsumables As New frmIPDConsumables(roundNo)
            fIPDConsumables.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Save Methods "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.SaveIPDDoctor()

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgClinicalFindings.Name
                    Me.SaveClinicalFindings()

                Case Me.tpgLaboratory.Name
                    Me.SaveLaboratory()

                Case Me.tpgCardiology.Name
                    Me.SaveCardiology()

                Case Me.tpgRadiology.Name
                    Me.SaveRadiology()

                Case Me.tpgLabResults.Name
                    DisplayMessage("View Lab Results")

                Case Me.tpgCardiologyReports.Name
                    DisplayMessage("View Cardiology Report")

                Case Me.tpgRadiologyReports.Name
                    DisplayMessage("View Radiology Report")

                Case Me.tpgPrescriptions.Name
                    Me.SavePrescriptions()

                Case Me.tpgProcedures.Name
                    Me.SaveProcedures()

                Case Me.tpgTheatre.Name
                    Me.SaveTheatre()

                Case Me.tpgDental.Name
                    Me.SaveDentalCategoryService()

                Case Me.tpgDentalLab.Name
                    Me.SaveDentalCategoryLaboratory()

                Case Me.tpgDiagnosis.Name
                    Me.SaveIPDDiagnosis()

                Case Me.tpgIPDEye.Name
                    If Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDEyeAssessment.Name) Then Me.SaveIPDEyeAssessment()
                    If Me.tbcIPDEye.SelectedTab.Name.Equals(Me.tpgIPDOrthoptics.Name) Then Me.SaveIPDOrthoptics()

                Case Me.tpgPathology.Name
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then Me.SavePathology()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllIPDAlerts()
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SaveIPDDoctor()

        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim message As String

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

            With oIPDDoctor

                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                .StaffNo = staffNo
                .RoundDateTime = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim staff As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")
                Dim miniStaff As EnumerableRowCollection(Of DataRow) = staff.AsEnumerable()
                Dim doctorLoginID As String = (From data In miniStaff Select data.Field(Of String)("LoginID")).First()

                If String.IsNullOrEmpty(doctorLoginID) Then
                    message = "The attending doctor you have selected does not have an associated login ID we recommend " + _
                   "that you contact the administrator to have this fixed. Else you won’t get system alerts." + _
                                           ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                ElseIf Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                    message = "The attending doctor you have selected has a different associated login ID from that " + _
                    "of the current user. Alerts for this round won’t be forwarded to you. " + _
                                         ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not .IsIPDDoctorSaved Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim admissionStatus As String = StringEnteredIn(Me.stbAdmissionStatus, "Admission Status!")
                    If admissionStatus.ToUpper().Equals(GetLookupDataDes(oAdmissionStatusID.Discharged).ToUpper()) Then
                        message = "This patient has been discharged. You can’t create a new round on a discharged admission!"
                        Throw New ArgumentException(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.chkCreateNewRound.Checked = False
                Me.EnableResetRoundCTLS(False, False)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveClinicalFindings()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDClinicalFindings As New SyncSoft.SQLDb.IPDClinicalFindings()

            If DateTimeMayBeEnteredIn(Me.stbRoundDateTime) < CDate(FormatDateTime(Today)) Then
                Dim message As String = "You are trying to update clinical findings for a passed round." + _
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            With oIPDClinicalFindings

                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .Weight = SingleMayBeEnteredIn(Me.nbxWeight, -1)
                .Temperature = SingleMayBeEnteredIn(Me.nbxTemperature, -1)
                .Height = SingleMayBeEnteredIn(Me.nbxHeight, -1)
                .Pulse = ShortMayBeEnteredIn(Me.nbxPulse, 0)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bloodPressure As String = StringMayBeEnteredIn(Me.stbBloodPressure)
                IsBloodPressureValid(bloodPressure)
                .BloodPressure = bloodPressure
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .HeadCircum = SingleMayBeEnteredIn(Me.nbxHeadCircum, -1)
                .BodySurfaceArea = SingleMayBeEnteredIn(Me.nbxBodySurfaceArea, -1)
                .History = StringMayBeEnteredIn(Me.stbHistory)
                .ClinicalNotes = StringMayBeEnteredIn(Me.stbClinicalNotes)
                .Respiratory = StringMayBeEnteredIn(Me.stbRespiratory)
                .GeneralAppearance = StringMayBeEnteredIn(Me.stbGeneralAppearance)
                .CVS = StringMayBeEnteredIn(Me.stbCVS)
                .Abdomen = StringMayBeEnteredIn(Me.stbAbdomen)
                .CNS = StringMayBeEnteredIn(Me.stbCNS)
                .MuscularSkeletal = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
                .PsychologicalStatus = StringMayBeEnteredIn(Me.stbPsychologicalStatus)
                .ClinicalDiagnosis = StringMayBeEnteredIn(Me.stbClinicalDiagnosis)
                .ClinicalImage = BytesMayBeEnteredIn(Me.spbClinicalImage)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If .Weight <= 0 AndAlso .Temperature <= 0 AndAlso .Height <= 0 AndAlso .Pulse <= 0 AndAlso
                String.IsNullOrEmpty(.BloodPressure) AndAlso .HeadCircum <= 0 AndAlso .BodySurfaceArea <= 0 AndAlso
                String.IsNullOrEmpty(.History) AndAlso String.IsNullOrEmpty(.ClinicalNotes) AndAlso
                String.IsNullOrEmpty(.Respiratory) AndAlso String.IsNullOrEmpty(.GeneralAppearance) AndAlso
                String.IsNullOrEmpty(.CVS) AndAlso String.IsNullOrEmpty(.Abdomen) AndAlso
                String.IsNullOrEmpty(.CNS) AndAlso String.IsNullOrEmpty(.MuscularSkeletal) AndAlso
                String.IsNullOrEmpty(.PsychologicalStatus) AndAlso String.IsNullOrEmpty(.ClinicalDiagnosis) AndAlso
                .ClinicalImage Is Nothing Then Throw New ArgumentException("Must Register At Least One Item Clinical Findings!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                clinicalFindingsSaved = True
                DisplayMessage("Clinical Findings Successfully Saved!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub SaveIPDEyeAssessment()

        Dim oEyeAssessment As New SyncSoft.SQLDb.IPDEyeAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oEyeAssessment

                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .LeftPupil = StringMayBeEnteredIn(Me.stbLeftPupil)
                .RightPupil = StringMayBeEnteredIn(Me.stbRightPupil)
                .LeftLidMargin = StringMayBeEnteredIn(Me.stbLeftLidMargin)
                .RightLidMargin = StringMayBeEnteredIn(Me.stbRightLidMargin)
                .LeftConjuctiva = StringMayBeEnteredIn(Me.stbLeftConjuctiva)
                .RightConjuctiva = StringMayBeEnteredIn(Me.stbRightConjuctiva)
                .LeftBulbarConjuctiva = StringMayBeEnteredIn(Me.stbLeftBulbarConjuctiva)
                .RightBulbarConjuctiva = StringMayBeEnteredIn(Me.stbRightBulbarConjuctiva)
                .LeftCentralCornea = StringMayBeEnteredIn(Me.stbLeftCentralCornea)
                .RightCentralCornea = StringMayBeEnteredIn(Me.stbRightCentralCornea)
                .LeftVerticalCornea = StringMayBeEnteredIn(Me.stbLeftVerticalCornea)
                .RightVerticalCornea = StringMayBeEnteredIn(Me.stbRightVerticalCornea)
                .LeftAnteriorChamber = StringMayBeEnteredIn(Me.stbLeftAnteriorChamber)
                .RightAnteriorChamber = StringMayBeEnteredIn(Me.stbRightAnteriorChamber)
                .LeftIrish = StringMayBeEnteredIn(Me.stbLeftIrish)
                .RightIrish = StringMayBeEnteredIn(Me.stbRightIrish)
                .LeftAnteriorChamberAngle = StringMayBeEnteredIn(Me.stbLeftAnteriorChamberAngle)
                .RightAnteriorChamberAngle = StringMayBeEnteredIn(Me.stbRightAnteriorChamberAngle)
                .LeftRetina = StringMayBeEnteredIn(Me.stbLeftRetina)
                .RightRetina = StringMayBeEnteredIn(Me.stbRightRetina)
                .LeftMacular = StringMayBeEnteredIn(Me.stbLeftMacular)
                .RightMacular = StringMayBeEnteredIn(Me.stbRightMacular)
                .LeftOpticDisc = StringMayBeEnteredIn(Me.stbLeftOpticDisc)
                .RightOpticDisc = StringMayBeEnteredIn(Me.stbRightOpticDisc)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim leftIOP As String = StringMayBeEnteredIn(Me.stbLeftIOP)
                '  IsBloodPressureValid(leftIOP)
                .LeftIOP = leftIOP

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim rightIOP As String = StringMayBeEnteredIn(Me.stbRightIOP)
                ' IsBloodPressureValid(rightIOP)
                .RightIOP = rightIOP
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .LeftVitreous = StringMayBeEnteredIn(Me.stbLeftVitreous)
                .RightVitreous = StringMayBeEnteredIn(Me.stbRightVitreous)
                .LeftLense = StringMayBeEnteredIn(Me.stbLeftLense)
                .RightLense = StringMayBeEnteredIn(Me.stbRightLense)
                .EyeNotes = StringMayBeEnteredIn(Me.StbEyeAssessmentNotes)
                .LeftEyeBall = StringMayBeEnteredIn(Me.stbLeftEyeBall)
                .RightEyeBall = StringMayBeEnteredIn(Me.stbRightEyeBall)
                .LeftOrbit = StringMayBeEnteredIn(Me.stbLeftOrbit)
                .RightOrbit = StringMayBeEnteredIn(Me.stbRightOrbit)
                .LoginID = CurrentUser.LoginID


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.LeftPupil) AndAlso String.IsNullOrEmpty(.RightPupil) AndAlso String.IsNullOrEmpty(.LeftLidMargin) AndAlso String.IsNullOrEmpty(.LeftMacular) AndAlso
                String.IsNullOrEmpty(.LeftOpticDisc) AndAlso String.IsNullOrEmpty(.RightOpticDisc) AndAlso String.IsNullOrEmpty(.RightMacular) AndAlso
                String.IsNullOrEmpty(.RightLidMargin) AndAlso String.IsNullOrEmpty(.LeftConjuctiva) AndAlso String.IsNullOrEmpty(.RightConjuctiva) AndAlso
                String.IsNullOrEmpty(.RightBulbarConjuctiva) AndAlso String.IsNullOrEmpty(.LeftBulbarConjuctiva) AndAlso String.IsNullOrEmpty(.LeftCentralCornea) AndAlso
                String.IsNullOrEmpty(.LeftAnteriorChamberAngle) AndAlso String.IsNullOrEmpty(.RightAnteriorChamberAngle) AndAlso String.IsNullOrEmpty(.LeftRetina) AndAlso
                String.IsNullOrEmpty(.RightRetina) AndAlso String.IsNullOrEmpty(.RightIrish) AndAlso
                String.IsNullOrEmpty(.RightCentralCornea) AndAlso String.IsNullOrEmpty(.LeftVerticalCornea) AndAlso String.IsNullOrEmpty(.RightVerticalCornea) AndAlso
                String.IsNullOrEmpty(.LeftAnteriorChamber) AndAlso String.IsNullOrEmpty(.RightAnteriorChamber) AndAlso String.IsNullOrEmpty(.LeftVitreous) AndAlso
                String.IsNullOrEmpty(.RightVitreous) AndAlso String.IsNullOrEmpty(.LeftLense) AndAlso String.IsNullOrEmpty(.RightLense) AndAlso
                String.IsNullOrEmpty(.LeftIrish) AndAlso String.IsNullOrEmpty(.LeftEyeBall) AndAlso String.IsNullOrEmpty(.RightEyeBall) AndAlso
                String.IsNullOrEmpty(.LeftOrbit) AndAlso String.IsNullOrEmpty(.RightOrbit) AndAlso
                String.IsNullOrEmpty(.EyeNotes) Then _
                Throw New ArgumentException("Must Register At Least One Item IPD Eye Assessment!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                IPDeyeAssessmentSaved = True
                DisplayMessage("IPD Eye Assessment Successfully Saved!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Public Sub SaveIPDOrthoptics()

        Dim oIPDOrthoptics As New SyncSoft.SQLDb.IPDOrthoptics()
        Try
            Me.Cursor = Cursors.WaitCursor()
            With oIPDOrthoptics
                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .HeadPosture = StringMayBeEnteredIn(Me.stbHeadPosture)
                .Fixation = StringMayBeEnteredIn(Me.stbFixation)
                .LeftHirschberg = StringMayBeEnteredIn(Me.stbLeftHirschberg)
                .RightHirschberg = StringMayBeEnteredIn(Me.stbRightHirschberg)
                .RightEOM = StringMayBeEnteredIn(Me.stbRightEOM)
                .LeftEOM = StringMayBeEnteredIn(Me.stbLeftEOM)
                .CoverTestID = StringValueEnteredIn(Me.cboCoverTestID, "CoverTest")
                .LeftAPCTGlasses = StringMayBeEnteredIn(Me.stbLeftAPCTGlasses)
                .RightAPCTGlasses = StringMayBeEnteredIn(Me.stbRightAPCTGlasses)
                .LeftAPCTWithOutGlasses = StringMayBeEnteredIn(Me.stbLeftAPCTWithOutGlasses)
                .RightAPCTWithOutGlasses = StringMayBeEnteredIn(Me.stbRightAPCTWithOutGlasses)
                .Correspondence = StringMayBeEnteredIn(Me.stbCorrespondence)
                .PrismAdaptation = StringMayBeEnteredIn(Me.stbPrismAdaptation)
                .FusionConvergence = StringMayBeEnteredIn(Me.stbFusionConvergence)
                .FusionDivergence = StringMayBeEnteredIn(Me.stbFusionDivergence)
                .FusionRange = StringMayBeEnteredIn(Me.stbFusionRange)
                .NearPointOfAccommodation = StringMayBeEnteredIn(Me.stbNearPointOfAccommodation)
                .NearPointOfConvergence = StringMayBeEnteredIn(Me.stbNearPointOfConvergence)
                .OrthopticsNotes = StringMayBeEnteredIn(Me.stbOrthopticsNotes)
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.HeadPosture) AndAlso String.IsNullOrEmpty(.Fixation) AndAlso String.IsNullOrEmpty(.LeftHirschberg) AndAlso String.IsNullOrEmpty(.RightHirschberg) AndAlso
                String.IsNullOrEmpty(.RightEOM) AndAlso String.IsNullOrEmpty(.LeftEOM) AndAlso String.IsNullOrEmpty(.CoverTestID) AndAlso
                String.IsNullOrEmpty(.LeftAPCTGlasses) AndAlso String.IsNullOrEmpty(.RightAPCTGlasses) AndAlso String.IsNullOrEmpty(.LeftAPCTWithOutGlasses) AndAlso
                String.IsNullOrEmpty(.RightAPCTWithOutGlasses) AndAlso String.IsNullOrEmpty(.Correspondence) AndAlso String.IsNullOrEmpty(.PrismAdaptation) AndAlso
                String.IsNullOrEmpty(.FusionConvergence) AndAlso String.IsNullOrEmpty(.FusionDivergence) AndAlso String.IsNullOrEmpty(.FusionRange) AndAlso
                String.IsNullOrEmpty(.NearPointOfAccommodation) AndAlso String.IsNullOrEmpty(.OrthopticsNotes) Then _
                Throw New ArgumentException("Must Register At Least One Item Orthoptic!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                IPDorthopticsSaved = True
                DisplayMessage("Orthoptics Assessment Successfully Saved!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub



    Private Sub SaveLaboratory()

        Dim quantity As Integer = 1

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvLabTests.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Lab Test!")

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTest, "test!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
            Next

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                Try

                    With oIPDItems

                        .RoundNo = roundNo
                        .ItemCode = StringEnteredIn(cells, Me.ColLabTestCode)
                        .Quantity = quantity
                        .UnitPrice = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                        .ItemDetails = StringMayBeEnteredIn(cells, Me.ColTestNotes)
                        .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                        .ItemCategoryID = oItemCategoryID.Test
                        .ItemStatusID = oItemStatusID.Pending
                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, StringEnteredIn(cells, Me.ColLabTestCode), oItemCategoryID.Test).Equals(True) Then
                            .PayStatusID = oPayStatusID.NA
                        Else
                            .PayStatusID = oPayStatusID.NotPaid
                        End If
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.LabRequests
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Lab Request(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveCardiology()

        Dim quantity As Integer = 1
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvCardiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Cardiology examinations!")

            For Each row As DataGridViewRow In Me.dgvCardiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colCardiologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colCardiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colCardiologyIndication, "Indication!")
            Next

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

                Try

                    With oIPDItems

                        .RoundNo = roundNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colCardiologyExamFullName))
                        .Quantity = quantity
                        .UnitPrice = DecimalEnteredIn(cells, Me.colCardiologyUnitPrice, False)
                        .ItemDetails = StringEnteredIn(cells, Me.colCardiologyIndication, "Indication!")
                        .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                        .ItemCategoryID = oItemCategoryID.Cardiology
                        .ItemStatusID = oItemStatusID.Pending
                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, SubstringRight(StringEnteredIn(cells, Me.colCardiologyExamFullName)), oItemCategoryID.Cardiology).Equals(True) Then
                            .PayStatusID = oPayStatusID.NA
                        Else
                            .PayStatusID = oPayStatusID.NotPaid
                        End If

                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Cardiology
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Cardiology sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvCardiology.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SaveRadiology()

        Dim quantity As Integer = 1
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvRadiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for radiology examinations!")

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colRadiologyIndication, "Indication!")
            Next

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                Try

                    With oIPDItems

                        .RoundNo = roundNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                        .Quantity = quantity
                        .UnitPrice = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                        .ItemDetails = StringEnteredIn(cells, Me.colRadiologyIndication, "Indication!")
                        .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                        .ItemCategoryID = oItemCategoryID.Radiology
                        .ItemStatusID = oItemStatusID.Pending
                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, SubstringRight(StringEnteredIn(cells, Me.colExamFullName)), oItemCategoryID.Radiology).Equals(True) Then
                            .PayStatusID = oPayStatusID.NA
                        Else
                            .PayStatusID = oPayStatusID.NotPaid
                        End If
                       
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Radiology
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Radiology sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvRadiology.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SavePrescriptions()

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for prescription!")

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows

                If row.IsNewRow Then Exit For

                StringEnteredIn(row.Cells, Me.colDrug, "drug!")
                StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                IntegerEnteredIn(row.Cells, Me.colDrugQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "unit price!")
                StringMayBeEnteredIn(row.Cells, Me.colDrugFormula)

            Next

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lIPDItems As New List(Of DBConnect)
                Dim lIPDItemsEXT As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                Try
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = StringMayBeEnteredIn(cells, Me.colDrugNo)
                            .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                            .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemStatusID = oItemStatusID.Pending

                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, StringMayBeEnteredIn(cells, Me.colDrugNo), oItemCategoryID.Drug).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then

                            Dim drugName As String = StringEnteredIn(cells, Me.colDrug)
                            Dim averageConsumedStock As Decimal = oVariousOptions.MaximumDrugQtyToGive()
                            Dim availableStock As Integer = GetAvailableStock(oIPDItems.ItemCode)
                            Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                            Dim halted As Boolean = BooleanMayBeEnteredIn(cells, Me.colHalted)
                            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasAlternateDrugs)
                            Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                            Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                            Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                          If averageConsumedStock > 0 Then
                                If oIPDItems.Quantity > averageConsumedStock Then
                                    message = "The Drug " + drugName + " With Quantity " + oIPDItems.Quantity.ToString + " is greater than the Average Of " +
                                          averageConsumedStock.ToString() + " which is usually given to Patients. " +
                                           ControlChars.NewLine + "Are you sure, you would like to Proceed ? "
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Continue For

                                End If

                            End If

                            If oIPDItems.Quantity > 0 AndAlso availableStock < oIPDItems.Quantity Then
                                If Not oVariousOptions.AllowPrescriptionToNegative() Then
                                    If hasAlternateDrugs Then
                                        message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                          (oIPDItems.Quantity - availableStock).ToString() + " and has registered alternatives. " +
                                          "The system does not allow a prescription of a drug that is out of stock. " +
                                          "Please notify Pharmacy to re-stock appropriately. " +
                                           ControlChars.NewLine + "Would you like to look at its alternatives? "
                                        If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oIPDItems.ItemCode)
                                    Else
                                        message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                            (oIPDItems.Quantity - availableStock).ToString() + " and has no registered alternatives. " +
                                            "The system does not allow a prescription of a drug that is out of stock. " +
                                            "Please notify Pharmacy to re-stock appropriately!"
                                        DisplayMessage(message)
                                    End If
                                    Continue For
                                Else
                                    message = "Insufficient stock to dispense for " + drugName +
                                              " with a deficit of " + (oIPDItems.Quantity - availableStock).ToString() +
                                              ControlChars.NewLine + "Are you sure you want to continue?"
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then
                                        If hasAlternateDrugs Then
                                            message = "Would you like to look at " + drugName + " alternatives? "
                                            If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oIPDItems.ItemCode)
                                        End If
                                        Continue For
                                    End If
                                End If

                            ElseIf orderLevel >= availableStock - oIPDItems.Quantity Then
                                message = "Stock level for " + drugName + " is running low. Please notify Pharmacy to re-stock appropriately!"
                                DisplayMessage(message)
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                                If Not oVariousOptions.AllowPrescriptionExpiredDrugs() Then
                                    message = "Expiry date for " + drugName + " had reached. " +
                                        "The system does not allow to prescribe a drug that is expired. Please notify Pharmacy to re-stock appropriately! "
                                    DisplayMessage(message)
                                    Continue For
                                Else
                                    message = "Expiry date for " + drugName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Continue For
                                End If

                            ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                                message = "Drug: " + drugName + " has " + remainingDaysExpiryDate.ToString() +
                                    " remaining day(s) to expire. Please notify Pharmacy to re-stock appropriately!"
                                DisplayMessage(message)

                            ElseIf expiryDate = AppData.NullDateValue Then
                                message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                                DisplayMessage(message)
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItems.Add(oIPDItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    Using oIPDItemsEXT As New SyncSoft.SQLDb.IPDItemsEXT()
                        With oIPDItemsEXT
                            .RoundNo = roundNo
                            .ItemCode = StringEnteredIn(cells, Me.colDrugNo)
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Dosage = StringEnteredIn(cells, Me.colDosage)
                            .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItemsEXT.Add(oIPDItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItemsEXT, Action.Save))

                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Prescription(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.OpenIPDDispenseAfterPrescription Then

                Dim hasPendingItems As Boolean = False
                message = "Would you like to open IPD Dispense now?"

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value) = True Then
                        Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colDrugItemStatus)
                        If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                            hasPendingItems = True
                            Exit For
                        End If
                    End If
                    hasPendingItems = False
                Next

                If hasPendingItems AndAlso WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIPDPharmacy As New frmIPDPharmacy(roundNo)
                    fIPDPharmacy.ShowDialog()
                    Me.LoadPrescriptions(roundNo)
                End If

            End If

            '''''''''''''''''l''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvPrescription.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveProcedures()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for procedure!")

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows

                If row.IsNewRow Then Exit For

                StringEnteredIn(row.Cells, Me.colProcedureCode, "procedure!")
                IntegerEnteredIn(row.Cells, Me.colProcedureQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "unit price!")
            Next

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                Try

                    With oIPDItems

                        .RoundNo = roundNo
                        .ItemCode = StringEnteredIn(cells, Me.colProcedureCode)
                        .Quantity = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                        .UnitPrice = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                        .ItemDetails = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                        .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                        .ItemCategoryID = oItemCategoryID.Procedure
                        .ItemStatusID = oItemStatusID.Pending
                        If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, StringEnteredIn(cells, Me.colProcedureCode), oItemCategoryID.Procedure).Equals(True) Then
                            .PayStatusID = oPayStatusID.NA
                        Else
                            .PayStatusID = oPayStatusID.NotPaid
                        End If
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Procedure
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Procedure(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvProcedures.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveTheatre()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvTheatre.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for theatre!")

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "theatre!")
                IntegerEnteredIn(row.Cells, Me.colTheatreQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "unit price!")
            Next

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim lIPDItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colTheatreCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)

                Try

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                            .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                            .ItemCategoryID = oItemCategoryID.Theatre
                            .ItemStatusID = oItemStatusID.Pending
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .LoginID = CurrentUser.LoginID
                        End With

                        lIPDItems.Add(oIPDItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Theatre
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Theatre(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvTheatre.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveDentalCategoryService()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvDental.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for dental service!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                IntegerEnteredIn(row.Cells, Me.colDentalQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalNotes, "Notes!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
            Next

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDentalCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)

                Try

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colDentalNotes, "Notes!")
                            .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                            .ItemCategoryID = oItemCategoryID.Dental
                            .ItemStatusID = oItemStatusID.Pending
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID
                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Dental
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Dental sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDental.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveDentalCategoryLaboratory()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvDentalLab.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for dental Lab!")

            For Each row As DataGridViewRow In Me.dgvDentalLab.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalLabCode, "Dental!")
                IntegerEnteredIn(row.Cells, Me.colDentalLabQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalLabNotes, "Notes!")
                DecimalEnteredIn(row.Cells, Me.colDentalLabUnitPrice, False, "Unit Price!")
            Next

            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDentalLab.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDentalLabCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalLabQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalLabUnitPrice, False)

                Try

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colDentalLabNotes, "Notes!")
                            .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                            .ItemCategoryID = oItemCategoryID.Dental
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .LoginID = CurrentUser.LoginID
                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Dental
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Dental lab sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDentalLab.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveIPDDiagnosis()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                Try

                    With oIPDDiagnosis

                        .RoundNo = roundNo
                        .DiseaseCode = StringEnteredIn(cells, Me.colICDDiagnosisCode)
                        .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                        .LoginID = CurrentUser.LoginID

                        .Save()

                    End With

                    Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDiagnosis.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SavePathology()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))

            If Me.dgvHistopathologyRequisition.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for pathology examinations!")

            For Each row As DataGridViewRow In Me.dgvHistopathologyRequisition.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colPathologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colPathologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colPathologyIndication, "Indication!")
            Next

            Dim quantity As Integer = 1
            

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim lIPDItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvHistopathologyRequisition.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colPathologyExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colPathologyUnitPrice, False)


                Try

                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colPathologyIndication, "Indication!")
                            .LastUpdate = DateTimeEnteredIn(Me.stbRoundDateTime, "Round Date Time!")
                            .ItemCategoryID = oItemCategoryID.Pathology
                            .ItemStatusID = oItemStatusID.Pending
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Pathology).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Pathology
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Pathology(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvRadiology.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Function AllSaved() As Boolean

        Try

            Dim message As String = "Please ensure that all items are saved on "
            Dim roundNo As String = StringMayBeEnteredIn(Me.cboRoundNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not clinicalFindingsSaved Then
                DisplayMessage(message + Me.tpgClinicalFindings.Text)
                Me.tbcDrRoles.SelectTab(Me.tpgClinicalFindings)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If

            For Each page As TabPage In Me.tbcDrRoles.TabPages

                Select Case page.Name

                    Case Me.tpgLaboratory.Name
                        For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colLabTestsSaved) Then
                                DisplayMessage(message + Me.tpgLaboratory.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgLaboratory)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgCardiology.Name
                        For Each row As DataGridViewRow In Me.dgvCardiology.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colCardiologySaved) Then
                                DisplayMessage(message + Me.tpgCardiology.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgCardiology)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgRadiology.Name
                        For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colRadiologySaved) Then
                                DisplayMessage(message + Me.tpgRadiology.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgRadiology)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgPrescriptions.Name
                        For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colPrescriptionSaved) Then
                                DisplayMessage(message + Me.tpgPrescriptions.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgProcedures.Name
                        For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colProceduresSaved) Then
                                DisplayMessage(message + Me.tpgProcedures.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgProcedures)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgTheatre.Name
                        For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colTheatreSaved) Then
                                DisplayMessage(message + Me.tpgTheatre.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgTheatre)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgDental.Name
                        For Each row As DataGridViewRow In Me.dgvDental.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDentalSaved) Then
                                DisplayMessage(message + Me.tpgDental.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgDental)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgDentalLab.Name
                        For Each row As DataGridViewRow In Me.dgvDentalLab.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDentalLabSaved) Then
                                DisplayMessage(message + Me.tpgDentalLab.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgDentalLab)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgDiagnosis.Name
                        For Each row As DataGridViewRow In Me.dgvDiagnosis.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDiagnosisSaved) Then
                                DisplayMessage(message + Me.tpgDiagnosis.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgDiagnosis)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                End Select
            Next

            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub LoadClinicalFindings(ByVal roundNo As String)

        Dim oIPDClinicalFindings As New SyncSoft.SQLDb.IPDClinicalFindings()

        Try

            ResetControlsIn(Me.tpgClinicalFindings)
            ResetControlsIn(Me.grpClinicalNotes)

            Dim iPDClinicalFindings As DataTable = oIPDClinicalFindings.GetIPDClinicalFindings(roundNo).Tables("IPDClinicalFindings")

            If iPDClinicalFindings Is Nothing Then Return

            For Each row As DataRow In iPDClinicalFindings.Rows

                Me.nbxWeight.Value = StringMayBeEnteredIn(row, "Weight")
                Me.nbxTemperature.Value = StringMayBeEnteredIn(row, "Temperature")
                Me.nbxHeight.Value = StringMayBeEnteredIn(row, "Height")
                Me.nbxPulse.Value = StringMayBeEnteredIn(row, "Pulse")
                Me.stbBloodPressure.Text = StringMayBeEnteredIn(row, "BloodPressure")
                Me.nbxHeadCircum.Value = StringMayBeEnteredIn(row, "HeadCircum")
                Me.nbxBodySurfaceArea.Value = StringMayBeEnteredIn(row, "BodySurfaceArea")
                Me.stbHistory.Text = StringMayBeEnteredIn(row, "History")
                Me.stbClinicalNotes.Text = StringMayBeEnteredIn(row, "ClinicalNotes")
                Me.stbRespiratory.Text = StringMayBeEnteredIn(row, "Respiratory")
                Me.stbGeneralAppearance.Text = StringMayBeEnteredIn(row, "GeneralAppearance")
                Me.stbCVS.Text = StringMayBeEnteredIn(row, "CVS")
                Me.stbAbdomen.Text = StringMayBeEnteredIn(row, "Abdomen")
                Me.stbCNS.Text = StringMayBeEnteredIn(row, "CNS")
                Me.stbMuscularSkeletal.Text = StringMayBeEnteredIn(row, "MuscularSkeletal")
                Me.stbPsychologicalStatus.Text = StringMayBeEnteredIn(row, "PsychologicalStatus")
                Me.stbClinicalDiagnosis.Text = StringMayBeEnteredIn(row, "ClinicalDiagnosis")
                Me.spbClinicalImage.Image = ImageMayBeEnteredIn(row, "ClinicalImage")

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadIPDEyeAssessment(ByVal roundNo As String)

        Dim oEyeAssessment As New SyncSoft.SQLDb.IPDEyeAssessment()

        Try

            ResetControlsIn(Me.tpgIPDEyeAssessment)

            Dim IPDeyeAssessment As DataTable = oEyeAssessment.GetIPDEyeAssessment(RevertText(roundNo)).Tables("IPDEyeAssessment")
            If IPDeyeAssessment Is Nothing Then Return

            For Each row As DataRow In IPDeyeAssessment.Rows

                Me.stbLeftPupil.Text = StringMayBeEnteredIn(row, "LeftPupil")
                Me.stbRightPupil.Text = StringMayBeEnteredIn(row, "RightPupil")
                Me.stbLeftLidMargin.Text = StringMayBeEnteredIn(row, "LeftLidMargin")
                Me.stbRightLidMargin.Text = StringMayBeEnteredIn(row, "RightLidMargin")
                Me.stbLeftConjuctiva.Text = StringMayBeEnteredIn(row, "LeftConjuctiva")
                Me.stbRightConjuctiva.Text = StringMayBeEnteredIn(row, "RightConjuctiva")
                Me.stbLeftBulbarConjuctiva.Text = StringMayBeEnteredIn(row, "LeftBulbarConjuctiva")
                Me.stbRightBulbarConjuctiva.Text = StringMayBeEnteredIn(row, "RightBulbarConjuctiva")
                Me.stbLeftCentralCornea.Text = StringMayBeEnteredIn(row, "LeftCentralCornea")
                Me.stbRightCentralCornea.Text = StringMayBeEnteredIn(row, "RightCentralCornea")
                Me.stbLeftVerticalCornea.Text = StringMayBeEnteredIn(row, "LeftVerticalCornea")
                Me.stbRightVerticalCornea.Text = StringMayBeEnteredIn(row, "RightVerticalCornea")
                Me.stbLeftAnteriorChamber.Text = StringMayBeEnteredIn(row, "LeftAnteriorChamber")
                Me.stbRightAnteriorChamber.Text = StringMayBeEnteredIn(row, "RightAnteriorChamber")
                Me.stbLeftIrish.Text = StringMayBeEnteredIn(row, "LeftIrish")
                Me.stbRightIrish.Text = StringMayBeEnteredIn(row, "RightIrish")
                Me.stbLeftAnteriorChamberAngle.Text = StringMayBeEnteredIn(row, "LeftAnteriorChamberAngle")
                Me.stbRightAnteriorChamberAngle.Text = StringMayBeEnteredIn(row, "RightAnteriorChamberAngle")
                Me.stbLeftRetina.Text = StringMayBeEnteredIn(row, "LeftRetina")
                Me.stbRightRetina.Text = StringMayBeEnteredIn(row, "RightRetina")
                Me.stbLeftMacular.Text = StringMayBeEnteredIn(row, "LeftMacular")
                Me.stbRightMacular.Text = StringMayBeEnteredIn(row, "RightMacular")
                Me.stbLeftOpticDisc.Text = StringMayBeEnteredIn(row, "LeftOpticDisc")
                Me.stbRightOpticDisc.Text = StringMayBeEnteredIn(row, "RightOpticDisc")
                Me.stbLeftIOP.Text = StringMayBeEnteredIn(row, "LeftIOP")
                Me.stbRightIOP.Text = StringMayBeEnteredIn(row, "RightIOP")
                Me.stbLeftVitreous.Text = StringMayBeEnteredIn(row, "LeftVitreous")
                Me.stbRightVitreous.Text = StringMayBeEnteredIn(row, "RightVitreous")
                Me.stbLeftLense.Text = StringMayBeEnteredIn(row, "LeftLense")
                Me.stbRightLense.Text = StringMayBeEnteredIn(row, "RightLense")
                Me.stbLeftOrbit.Text = StringMayBeEnteredIn(row, "LeftOrbit")
                Me.stbRightOrbit.Text = StringMayBeEnteredIn(row, "RightOrbit")
                Me.stbLeftEyeBall.Text = StringMayBeEnteredIn(row, "LeftEyeBall")
                Me.stbRightEyeBall.Text = StringMayBeEnteredIn(row, "RightEyeBall")
                Me.StbEyeAssessmentNotes.Text = StringMayBeEnteredIn(row, "EyeNotes")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            IPDeyeAssessmentSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub
    Private Sub LoadIPDOrthoptics(ByVal roundNo As String)

        Dim oIPDOrthoptics As New SyncSoft.SQLDb.IPDOrthoptics()

        Try

            ResetControlsIn(Me.tpgIPDOrthoptics)

            Dim ipdorthoptics As DataTable = oIPDOrthoptics.GetIPDOrthoptics(RevertText(roundNo)).Tables("IPDOrthoptics")
            If ipdorthoptics Is Nothing Then Return

            For Each row As DataRow In ipdorthoptics.Rows

                Me.stbHeadPosture.Text = StringMayBeEnteredIn(row, "HeadPosture")
                Me.stbFixation.Text = StringMayBeEnteredIn(row, "Fixation")
                Me.stbLeftHirschberg.Text = StringMayBeEnteredIn(row, "LeftHirschberg")
                Me.stbRightHirschberg.Text = StringMayBeEnteredIn(row, "RightHirschberg")
                Me.stbRightEOM.Text = StringMayBeEnteredIn(row, "RightEOM")
                Me.stbLeftEOM.Text = StringMayBeEnteredIn(row, "LeftEOM")
                Me.cboCoverTestID.SelectedValue = StringMayBeEnteredIn(row, "CoverTestID")
                Me.stbLeftAPCTGlasses.Text = StringMayBeEnteredIn(row, "LeftAPCTGlasses")
                Me.stbRightAPCTGlasses.Text = StringMayBeEnteredIn(row, "RightAPCTGlasses")
                Me.stbLeftAPCTWithOutGlasses.Text = StringMayBeEnteredIn(row, "LeftAPCTWithOutGlasses")
                Me.stbRightAPCTWithOutGlasses.Text = StringMayBeEnteredIn(row, "RightAPCTWithOutGlasses")
                Me.stbCorrespondence.Text = StringMayBeEnteredIn(row, "Correspondence")
                Me.stbPrismAdaptation.Text = StringMayBeEnteredIn(row, "PrismAdaptation")
                Me.stbFusionConvergence.Text = StringMayBeEnteredIn(row, "FusionConvergence")
                Me.stbFusionDivergence.Text = StringMayBeEnteredIn(row, "FusionDivergence")
                Me.stbFusionRange.Text = StringMayBeEnteredIn(row, "FusionRange")
                Me.stbNearPointOfAccommodation.Text = StringMayBeEnteredIn(row, "NearPointOfAccommodation")
                Me.stbNearPointOfConvergence.Text = StringMayBeEnteredIn(row, "NearPointOfConvergence")
                Me.stbOrthopticsNotes.Text = StringMayBeEnteredIn(row, "OrthopticsNotes")


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            IPDorthopticsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub




#Region " Lab Tests - Grid "

    Private Sub dgvLabTests_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim rowIndex As Integer
            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("LabTests", "Test Code", "Test Name", Me.labTests, "TestFullName",
                                                                     "TestCode", "TestName", Me.dgvLabTests, Me.ColLabTestCode, e.RowIndex)

            Me._TestCode = StringMayBeEnteredIn(Me.dgvLabTests.Rows(e.RowIndex).Cells, Me.ColLabTestCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvLabTests.Rows(e.RowIndex).IsNewRow Then

                Me.dgvLabTests.Rows.Add()

                fSelectItem.ShowDialog(Me)

                rowIndex = Me.dgvLabTests.NewRowIndex - 1
                Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowIndex).Cells, Me.ColLabTestCode)
                Me.SetLabTestsEntries(rowIndex, selectedItem)

            ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                rowIndex = Me.dgvLabTests.NewRowIndex - 1
                Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowIndex).Cells, Me.ColLabTestCode)
                Me.SetLabTestsEntries(rowIndex, selectedItem)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvLabTests_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTests.CellBeginEdit

        If e.ColumnIndex <> Me.ColLabTestCode.Index OrElse Me.dgvLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
        _TestValue = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColLabTestCode)

    End Sub

    Private Sub dgvLabTests_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.ColLabTestCode.Index) Then

                Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
                Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColLabTestCode)

                If e.ColumnIndex.Equals(Me.ColLabTestCode.Index) Then
                    ' Ensure unique entry in the combo column
                    If Me.dgvLabTests.Rows.Count > 1 Then Me.SetLabTestsEntries(selectedRow, selectedItem)
                End If
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        End Try



    End Sub


    Private Sub SetLabTestsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try


            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Test (" + _TestValue + ") can't be edited!")
                Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Value = _TestValue
                Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Selected = True

                Return

            End If


            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2


                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowNo).Cells, Me.ColLabTestCode)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Test (" + enteredItem + ") already selected!")
                        Me.dgvLabTests.Rows.RemoveAt(selectedRow)
                        Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Value = _TestValue
                        Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim testCode As String = RevertText(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If labTests Is Nothing OrElse String.IsNullOrEmpty(testCode) Then Return
            Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In labTests.Select("TestCode = '" + testCode + "'")
                Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Value = testCode.ToUpper()
                Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Value = StringEnteredIn(row, "TestName")
                Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvLabTests.Item(Me.colLTQuantity.Name, selectedRow).Value = 1
                Me.dgvLabTests.Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                Me.dgvLabTests.Item(Me.colLTItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvLabTests.Item(Me.colRejectionStatus.Name, selectedRow).Value = "False"
                Me.dgvLabTests.Item(Me.ColRequestedBy.Name, selectedRow).Value = CurrentUser.FullName
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                    Me.dgvLabTests.Item(Me.colLTPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvLabTests.Item(Me.colLTPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForLaboratory()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Value = Me._TestCode.ToUpper()
        End Try

    End Sub


    Private Sub CalculateBillForLaboratory()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

            If IsNumeric(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = CStr(Me.dgvLabTests.Item(Me.ColLabTestCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvLabTests.UserDeletedRow
        Me.CalculateBillForLaboratory()
    End Sub

    Private Sub dgvLabTests_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub


    Private Sub LoadLaboratory(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for
            Dim flagStatusStyle As New DataGridViewCellStyle()
            flagStatusStyle.BackColor = Color.MistyRose

            Dim tests As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Test).Tables("IPDItems")
            If tests Is Nothing OrElse tests.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To tests.Rows.Count - 1

                Dim row As DataRow = tests.Rows(pos)
                With Me.dgvLabTests

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.ColLabTestCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colLTQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colLTItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.ColTestNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colLTPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colRejectionStatus.Name, pos).Value = StringEnteredIn(row, "RejectionStatus")
                    .Item(Me.ColRequestedBy.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colLabTestsSaved.Name, pos).Value = True
                End With

            Next



            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                Dim checkstatus As String = StringMayBeEnteredIn(row.Cells, Me.colRejectionStatus)
                If checkstatus = "True" Then Me.dgvLabTests.Rows(row.Index).DefaultCellStyle.ApplyStyle(flagStatusStyle)
                ' End If
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadLabResults(ByVal roundNo As String)

        Dim styleResult As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Try

            Me.dgvLabResults.Rows.Clear()

            If String.IsNullOrEmpty(roundNo) Then Return
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

            If String.IsNullOrEmpty(visitNo) Then Return

            ' Load from Lab Results
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim labResults As DataTable = oLabResults.GetLabResultsByVisitNo(visitNo).Tables("LabResults")
            If labResults Is Nothing OrElse labResults.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labResultsIPD As EnumerableRowCollection(Of DataRow) = From data In labResults.AsEnumerable() Where _
                                data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) Select data

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabResults, labResultsIPD)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            styleResult.BackColor = Color.MistyRose
            styleResult.Font = font

            For rowNo As Integer = 0 To Me.dgvLabResults.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvLabResults.Rows(rowNo).Cells

                Dim resultFlag As String = StringMayBeEnteredIn(cells, Me.colResultFlag)
                Dim resultDataType As String = StringMayBeEnteredIn(cells, Me.colResultDataType)
                Dim normalRange As String = StringMayBeEnteredIn(cells, Me.colNormalRange)
                Dim result As String = StringMayBeEnteredIn(cells, Me.colResult)

                If resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.Low).ToUpper()) OrElse
                    resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.High).ToUpper()) OrElse
                     LabResultNotInNormalRange(resultDataType, gender, normalRange, result) Then
                    Me.dgvLabResults.Rows(rowNo).Cells(Me.colResult.Name).Style.ApplyStyle(styleResult)
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPackageAttachedLabTests(PackageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedLabTests As DataTable = oItems.GetAllowedPackageLabTests(PackageNo).Tables("PackagesEXT")
        If attachedLabTests.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed LabTests on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                Me.tbcDrRoles.SelectTab(Me.tpgLaboratory.Name)

                If attachedLabTests Is Nothing OrElse attachedLabTests.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvLabTests.Rows.Count - 1


                For pos As Integer = 0 To attachedLabTests.Rows.Count - 1
                    Dim row As DataRow = attachedLabTests.Rows(pos)
                    With Me.dgvLabTests

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim testCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                        Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        .Item(Me.ColLabTestCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "TestName")
                        .Item(Me.colLTQuantity.Name, pos).Value = quantity
                        .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                        .Item(Me.colLTItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colLTPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.ColRequestedBy.Name, pos).Value = CurrentUser.FullName
                        .Item(Me.colRejectionStatus.Name, pos).Value = "False"
                        .Item(Me.colLabTestsSaved.Name, pos).Value = False
                        count += 1

                    End With

                Next

            End If
        End If
    End Sub

#End Region

#Region " Cardiology - Grid "

    Private Sub dgvCardiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCardiology.CellBeginEdit

        If e.ColumnIndex <> Me.colCardiologyExamFullName.Index OrElse Me.dgvCardiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvCardiology.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvCardiology.Rows(selectedRow).Cells, Me.colCardiologyExamFullName)

    End Sub

    Private Sub dgvCardiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCardiology.CellEndEdit

        Try

            If Me.colCardiologyExamFullName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colCardiologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvCardiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvCardiology.CurrentCell.RowIndex
                    Me.SetCardiologyExaminationsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetCardiologyExaminationsEntries(ByVal selectedRow As Integer)

        Try
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvCardiology.Rows(selectedRow).Cells, Me.colCardiologyExamFullName)

            If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvCardiology.Rows(rowNo).Cells, Me.colCardiologyExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If CardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Cardiology, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "CardiologyCategories")
                Me.dgvCardiology.Item(Me.colCardiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvCardiology.Item(Me.colCardiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Cardiology).Equals(True) Then
                    Me.dgvCardiology.Item(Me.colCardiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvCardiology.Item(Me.colCardiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForCardiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvCardiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvCardiology.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Cardiology
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvCardiology_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvCardiology.UserDeletedRow
        Me.CalculateBillForCardiology()
    End Sub

    Private Sub dgvCardiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCardiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForCardiology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

            If IsNumeric(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowCardiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If CardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CardiologyCategories")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCardiology(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvCardiology.Rows.Clear()

            ' Load items not yet paid for

            Dim Cardiology As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Cardiology).Tables("IPDItems")
            If Cardiology Is Nothing OrElse Cardiology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To Cardiology.Rows.Count - 1

                Dim row As DataRow = Cardiology.Rows(pos)
                With Me.dgvCardiology

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colCardiologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colCardiologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colCardiologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowCardiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colCardiologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colCardiologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colCardiologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colCardiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForCardiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadIPDCardiologyReports(ByVal roundNo As String)

        Dim oIPDCardiologyReports As New SyncSoft.SQLDb.IPDCardiologyReports()

        Try

            ' Load from Lab CardiologyReports
            Dim iPDCardiologyReports As DataTable = oIPDCardiologyReports.GetIPDCardiologyReports(roundNo).Tables("IPDCardiologyReports")

            If iPDCardiologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCardiologyReports, iPDCardiologyReports)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPackageAttachedCardiology(PackageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedCardiology As DataTable = oItems.GetAllowedPackageCardiologyExaminations(PackageNo).Tables("PackagesEXT")
        If attachedCardiology.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed Cardiology examinations on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedCardiology Is Nothing OrElse attachedCardiology.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvCardiology.Rows.Count - 1


                For pos As Integer = 0 To attachedCardiology.Rows.Count - 1
                    Dim row As DataRow = attachedCardiology.Rows(pos)
                    With Me.dgvCardiology

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim examCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                        Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Cardiology, billNo, billModesID, associatedBillNo)
                        Dim quantity As Integer = 1
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        .Item(Me.colCardiologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ExamFullName")
                        .Item(Me.colCardiologyQuantity.Name, pos).Value = 1
                        Me.ShowCardiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colCardiologyUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colCardiologyItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colCardiologyPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colCardiologySaved.Name, pos).Value = False
                        count += 1
                    End With

                Next

            End If
        End If
    End Sub

#End Region


#Region " Radiology - Grid "

    Private Sub dgvRadiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRadiology.CellBeginEdit

        If e.ColumnIndex <> Me.colExamFullName.Index OrElse Me.dgvRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

    End Sub

    Private Sub dgvRadiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRadiology.CellEndEdit

        Try

            If Me.colExamFullName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvRadiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
                    Me.SetRadiologyExaminationsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetRadiologyExaminationsEntries(ByVal selectedRow As Integer)

        Try
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(rowNo).Cells, Me.colExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "RadiologyCategories")
                Me.dgvRadiology.Item(Me.colRadiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvRadiology.Item(Me.colRadiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Radiology).Equals(True) Then
                    Me.dgvRadiology.Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvRadiology.Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
             
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForRadiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvRadiology.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvRadiology.Item(Me.colExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvRadiology_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvRadiology.UserDeletedRow
        Me.CalculateBillForRadiology()
    End Sub

    Private Sub dgvRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForRadiology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

            If IsNumeric(Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowRadiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "RadiologyCategories")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRadiology(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvRadiology.Rows.Clear()

            ' Load items not yet paid for

            Dim radiology As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Radiology).Tables("IPDItems")
            If radiology Is Nothing OrElse radiology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To radiology.Rows.Count - 1

                Dim row As DataRow = radiology.Rows(pos)
                With Me.dgvRadiology

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colRadiologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colRadiologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowRadiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colRadiologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colRadiologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colRadiologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colRadiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForRadiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadIPDRadiologyReports(ByVal roundNo As String)

        Dim oIPDRadiologyReports As New SyncSoft.SQLDb.IPDRadiologyReports()

        Try

            ' Load from Lab RadiologyReports
            Dim iPDRadiologyReports As DataTable = oIPDRadiologyReports.GetIPDRadiologyReports(roundNo).Tables("IPDRadiologyReports")

            If iPDRadiologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvRadiologyReports, iPDRadiologyReports)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPackageAttachedRadiology(PackageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedRadiology As DataTable = oItems.GetAllowedPackageRadiologyExaminations(PackageNo).Tables("PackagesEXT")
        If attachedRadiology.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed Radiology examinations on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedRadiology Is Nothing OrElse attachedRadiology.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvRadiology.Rows.Count - 1


                For pos As Integer = 0 To attachedRadiology.Rows.Count - 1
                    Dim row As DataRow = attachedRadiology.Rows(pos)
                    With Me.dgvRadiology

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim examCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                        Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, associatedBillNo)
                        Dim quantity As Integer = 1
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        .Item(Me.colExamFullName.Name, pos).Value = StringEnteredIn(row, "ExamFullName")
                        .Item(Me.colRadiologyQuantity.Name, pos).Value = 1
                        Me.ShowRadiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colRadiologyUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colRadiologyItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colRadiologyPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colRadiologySaved.Name, pos).Value = False
                        count += 1
                    End With

                Next

            End If
        End If
    End Sub

#End Region

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit
  If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)
            ElseIf e.ColumnIndex.Equals(Me.colDosage.Index) Then
                Me.CalculateDrugQuantity(selectedRow, True)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDuration.Index) Then
                Me.CalculateDrugQuantity(selectedRow, False)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                 Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))

            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Rows.RemoveAt(selectedRow)
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailPrescribedDrug(selectedRow)
            Me.CalculateDrugQuantity(selectedRow, False)
            Me.CalculateDrugAmount(selectedRow)
            Me.CalculateBillForPrescriptions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = CStr(Me.dgvPrescription.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvPrescription.UserDeletedRow
        Me.CalculateBillForPrescriptions()
    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer)
        Try
            Dim message As String
            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim drugNo As String = String.Empty
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()

            If Me.dgvPrescription.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))
            If String.IsNullOrEmpty(drugNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim availableStock As Integer = GetAvailableStock(drugNo)
            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")
            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                .Item(Me.colAvailableStock.Name, selectedRow).Value = availableStock
                .Item(Me.colDrug.Name, selectedRow).Value = drugName
                .Item(Me.colOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colPrescriptionGroup.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colDrugItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

                .Item(Me.colHalted.Name, selectedRow).Value = halted
                .Item(Me.colHasAlternateDrugs.Name, selectedRow).Value = hasAlternateDrugs
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If halted AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is on halt and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            ElseIf availableStock <= 0 AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is out of stock and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
            Throw ex
        End Try

    End Sub

    Private Sub CalculateBillForPrescriptions()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            If IsNumeric(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)
        If quantity < 0 Then
            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = String.Empty
            Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = String.Empty
            Throw New ArgumentException("Negative values not allowed for Quantity")

        End If
        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateDrugQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oDosageCalculationID As New LookupDataID.DosageCalculationID()

        Try

            Dim quantity As Single = 0
            Dim drugNo As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo)
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDosage)
            Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)

            If duration < 0 Then
                Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = String.Empty
                Throw New ArgumentException("Negative values not allowed for Quantity")

            End If
            Dim varyPrescribedQty As Boolean = BooleanEnteredIn(row, "VaryPrescribedQty")
            Dim defaultPrescribedQty As Integer = IntegerEnteredIn(row, "DefaultPrescribedQty")
            Dim dosageSeparator As Char = CChar(StringEnteredIn(row, "DosageSeparator").ToUpper())
            Dim dosageCalculationID As String = StringEnteredIn(row, "DosageCalculationID")
            'Dim dosageFormat As String = StringMayBeEnteredIn(row, "DosageFormat")

            If String.IsNullOrEmpty(dosage) Then Return

            If Not IsCharacterInString(dosage.Trim().ToUpper(), dosageSeparator) Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(";".ToUpper()))
                            dosageSeparator = CChar(";".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(":".ToUpper()))
                            dosageSeparator = CChar(":".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("+".ToUpper()))
                            dosageSeparator = CChar("+".ToUpper())
                    End Select
                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("X".ToUpper()))
                            dosageSeparator = CChar("X".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("*".ToUpper()))
                            dosageSeparator = CChar("*".ToUpper())
                    End Select
                End If
            End If

            Dim fullDosage() As String = dosage.Trim().ToUpper().Split(dosageSeparator)
            If fullDosage.Length < 2 Then Throw New ArgumentException("Dosage format incorrect!")

            If Not varyPrescribedQty Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    For Each dose As String In fullDosage
                        Dim dailyDosage As Single
                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                            quantity += dailyDosage
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric separated with '" + dosageSeparator + "' character")
                        End If
                    Next

                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then

                    If fullDosage.Length = 2 Then

                        Dim dailyDosage As Single
                        Dim dailyPeriod As Integer

                        Dim dose As String = fullDosage(fullDosage.GetLowerBound(0))
                        Dim period As String = fullDosage(fullDosage.GetUpperBound(0))

                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric")
                        End If

                        If IsNumeric(period.Trim()) AndAlso Integer.TryParse(period.Trim(), dailyPeriod) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + period + "', enter only as numeric with no decimal places")
                        End If

                        quantity = dailyDosage * dailyPeriod * duration

                    Else : Throw New ArgumentException("Dosage format incorrect, enter only as numeric separated with '" + dosageSeparator + "' character e.g. 2" + dosageSeparator + "1")
                    End If

                Else : quantity = defaultPrescribedQty
                End If
            Else : quantity = defaultPrescribedQty
            End If

            If calculateDuration AndAlso dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = fullDosage.Length
            End If

            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = CInt(quantity)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ShowDrugDetails(ByVal drugNo As String, ByVal pos As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugNo Is Nothing Then Return
            Dim row As DataRow = drugs.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colAvailableStock.Name, pos).Value = GetAvailableStock(drugNo)
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colPrescriptionGroup.Name, pos).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
                .Item(Me.colHasAlternateDrugs.Name, pos).Value = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPrescriptions(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Drug).Tables("IPDItems")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDrugNo.Name, pos).Value = StringMayBeEnteredIn(row, "ItemCode")
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPrescriptions()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

 
    Private Function GetDrugs() As DataTable

        Dim drugs As DataTable
        Dim oSetupData As New SetupData()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            ' Load from drugs

            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return drugs
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function


    Private Sub dgvPrescription_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvPrescription, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvPrescription.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColDrugselect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPrescription.Rows(e.RowIndex).IsNewRow Then

                Me.dgvPrescription.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.ColDrugselect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPackageAllowedPrescriptions(packageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedPrescriptions As DataTable = oItems.GetAllowedPackagePrescritions(packageNo).Tables("PackagesEXT")
        If attachedPrescriptions.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed drugs on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedPrescriptions Is Nothing OrElse attachedPrescriptions.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvPrescription.Rows.Count - 1

                ''  If selectedRow = dgvDiagnosis.Rows.Count - 2 Then

                For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                    Dim row As DataRow = attachedPrescriptions.Rows(pos)
                    With Me.dgvPrescription

                        ' Ensure that you add a new row
                        .Rows.Add()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
                        Dim amount As Decimal = quantity * unitPrice

                        .Item(Me.colDrugNo.Name, count).Value = drugNo
                        .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugName")
                        Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colDrugQuantity.Name, count).Value = quantity
                        .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                        .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                        .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                        count += 1

                    End With

                Next

            End If
        End If

    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub dgvProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvProcedures.Rows.Count > 1 Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
                    Me.SetProceduresEntries(selectedRow)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            ElseIf e.ColumnIndex.Equals(Me.colProcedureUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateBillForProcedures()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetProceduresEntries(ByVal selectedRow As Integer)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim procedureDisplay As String = (From data In _Procedures
                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper())
                                    Select data.Field(Of String)("ProcedureName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Procedures
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ProcedureName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If procedures Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In procedures.Select("ProcedureCode = '" + selectedItem + "'")
                Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvProcedures.Item(Me.colICDProcedureCode.Name, selectedRow).Value = selectedItem
                Me.dgvProcedures.Item(Me.colProcedureQuantity.Name, selectedRow).Value = 1
                Me.dgvProcedures.Item(Me.colProcedureItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Procedure).Equals(True) Then
                    Me.dgvProcedures.Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvProcedures.Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
               
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvProcedures_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserAddedRow
        Me.dgvProcedures.Item(Me.colProcedureQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserDeletedRow
        Me.CalculateBillForProcedures()
    End Sub

    Private Sub dgvProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForProcedures()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1
            If IsNumeric(Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadProcedures(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim procedure As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Procedure).Tables("IPDItems")
            If procedure Is Nothing OrElse procedure.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To procedure.Rows.Count - 1

                Dim row As DataRow = procedure.Rows(pos)

                With Me.dgvProcedures
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colProcedureUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colProcedureItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colProcedurePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colProceduresSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPackageAllowedProcedures(packageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedProcedures As DataTable = oItems.GetAllowedPackageProcedures(packageNo).Tables("PackagesEXT")
        If attachedProcedures.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed Procedures on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedProcedures Is Nothing OrElse attachedProcedures.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvProcedures.Rows.Count - 1


                For pos As Integer = 0 To attachedProcedures.Rows.Count - 1
                    Dim row As DataRow = attachedProcedures.Rows(pos)
                    With Me.dgvProcedures

                        .Rows.Add()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim procedurecode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        Dim unitPrice As Decimal = GetCustomFee(procedurecode, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)
                        Dim amount As Decimal = quantity * unitPrice


                        .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")

                        .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ProcedureCode")
                        .Item(Me.colProcedureQuantity.Name, pos).Value = 1
                        .Item(Me.colProcedureUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                        .Item(Me.colProcedureItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colProcedurePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colProceduresSaved.Name, pos).Value = False
                        count += 1

                    End With

                Next

            End If
        End If

    End Sub

#End Region

#Region " Theatre - Grid "

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreCode.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTheatreCode.Index) Then
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)

        Try
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                Dim theatreDisplay As String = (From data In _Theatre
                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreNameValue.ToUpper())
                                    Select data.Field(Of String)("TheatreName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre (" + theatreDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colTheatreCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Theatre
                                            Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("TheatreName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Theatre (" + enteredDisplay + ") already entered!")
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next
            'Dim otheatre As New SyncSoft.SQLDb.TheatreServices()

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colICDTheatreCode)



            'If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    Dim theatre As DataTable = otheatre.GetTheatreServices(selectedItem).Tables("TheatreServices")
            '    If theatre Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            '    Dim row As DataRow = theatre.Rows(0)
            '    Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")

            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    DisplayMessage("Theatre Service (" + enteredDisplay + ") can't be edited!")
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '    Return
            'End If

            'For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2


            '    If Not rowNo.Equals(selectedRow) Then

            '        Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colICDTheatreCode)

            '        If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '            Dim theatre As DataTable = otheatre.GetTheatreServices(enteredItem).Tables("TheatreServices")

            '            If theatre Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
            '            Dim row As DataRow = theatre.Rows(0)

            '            Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '            DisplayMessage("Theatre service (" + enteredDisplay + ") already entered!")
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '            Return
            '        End If
            '    End If

            'Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If theatreServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In theatreServices.Select("TheatreCode = '" + selectedItem + "'")
                Me.dgvTheatre.Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, selectedRow).Value = 1
                Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Private Sub DetailTheatreService(ByVal selectedRow As Integer, selectedItem As String)
    '    Try
    '        Dim theatreServiceSelected As String = String.Empty
    '        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()


    '        If String.IsNullOrEmpty(selectedItem) Then Return

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Dim billAccountNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
    '        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '        Dim theatreService As DataTable = oTheatreServices.GetTheatreServices(selectedItem).Tables("TheatreServices")

    '        If theatreService Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
    '        Dim row As DataRow = theatreService.Rows(0)

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Dim theatreName As String = StringEnteredIn(row, "TheatreName", "Theatre Service Name!")

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        With Me.dgvTheatre

    '            .Item(Me.colICDTheatreCode.Name, selectedRow).Value = StringEnteredIn(row, "TheatreCode")
    '            .Item(Me.colTheatreCode.Name, selectedRow).Value = StringEnteredIn(row, "TheatreName")
    '            .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
    '            .Item(Me.colTheatreSaved.Name, selectedRow).Value = True

    '        End With

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = Me._TheatreCode.ToUpper()
    '        Throw ex

    '    End Try

    'End Sub

    Private Sub dgvTheatre_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserAddedRow
        Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserDeletedRow
        Me.CalculateBillForTheatre()
    End Sub

    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForTheatre()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

            If IsNumeric(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadTheatre(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Theatre).Tables("IPDItems")

            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatre.Rows.Count - 1

                Dim row As DataRow = theatre.Rows(pos)

                With Me.dgvTheatre
                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colTheatreSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Dental Category Service - Grid "

    Private Sub dgvDental_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDental.CellBeginEdit

        If e.ColumnIndex <> Me.colDentalCode.Index OrElse Me.dgvDental.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex
        _DentalNameValue = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

    End Sub

    Private Sub dgvDental_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDental.CellEndEdit

        Try

            If Me.colDentalCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDentalCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvDental.Rows.Count > 1 Then Me.SetDentalServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDentalQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalCategoryServiceAmount(selectedRow)
                Me.CalculateBillForDentalCategoryService()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colDentalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalCategoryServiceAmount(selectedRow)
                Me.CalculateBillForDentalCategoryService()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDentalServiceEntries(ByVal selectedRow As Integer)

        Try
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalService.AsEnumerable()
                Dim dentalDisplay As String = (From data In _DentalServices
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalNameValue.ToUpper())
                                    Select data.Field(Of String)("DentalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Dental (" + dentalDisplay + ") can't be edited!")
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(rowNo).Cells, Me.colDentalCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalService.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _DentalServices
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DentalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental (" + enteredDisplay + ") already selected!")
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If dentalService Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)
            Dim quantity As Integer = 1

            For Each row As DataRow In dentalService.Select("DentalCode = '" + selectedItem + "'")

                Me.dgvDental.Item(Me.colDentalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvDental.Item(Me.colDentalQuantity.Name, selectedRow).Value = quantity
                Me.dgvDental.Item(Me.colDentalItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
                    Me.dgvDental.Item(Me.colDentalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvDental.Item(Me.colDentalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateDentalCategoryServiceAmount(selectedRow)
            Me.CalculateBillForDentalCategoryService()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDental_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDental.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round's No!"))
            Dim itemCode As String = CStr(Me.dgvDental.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDental_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvDental.UserDeletedRow
        Me.CalculateBillForDentalCategoryService()
    End Sub

    Private Sub dgvDental_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDental.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateDentalCategoryServiceAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalUnitPrice)

        Me.dgvDental.Item(Me.colDentalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForDentalCategoryService()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1

            If IsNumeric(Me.dgvDental.Item(Me.colDentalAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvDental.Item(Me.colDentalAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadDentalCategoryService(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            Dim dental As DataTable = oIPDItems.GetDentalIPDItems(roundNo, GetLookupDataDes(oDentalCategoryID.Service)).Tables("IPDItems")
            If dental Is Nothing OrElse dental.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To dental.Rows.Count - 1

                Dim row As DataRow = dental.Rows(pos)
                With Me.dgvDental

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colDentalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDentalNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDentalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colDentalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colDentalAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDentalItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDentalPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colDentalSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForDentalCategoryService()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadIPDDentalReports(ByVal roundNo As String)

        'Dim oIPDDentalReports As New SyncSoft.SQLDb.IPDDentalReports()

        'Try

        '    ' Load from Lab DentalReports
        '    Dim dentalReports As DataTable = oIPDDentalReports.GetIPDDentalReports(roundNo).Tables("IPDDentalReports")

        '    If dentalReports Is Nothing Then Return

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    LoadGridData(Me.dgvDentalReports, dentalReports)
        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Catch ex As Exception
        '    Throw ex

        'End Try

    End Sub

#End Region

#Region " Dental Category Laboratory - Grid "

    Private Sub dgvDentalLab_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDentalLab.CellBeginEdit

        If e.ColumnIndex <> Me.colDentalLabCode.Index OrElse Me.dgvDentalLab.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDentalLab.CurrentCell.RowIndex
        _DentalLabNameValue = StringMayBeEnteredIn(Me.dgvDentalLab.Rows(selectedRow).Cells, Me.colDentalLabCode)

    End Sub

    Private Sub dgvDentalLab_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDentalLab.CellEndEdit

        Try

            If Me.colDentalLabCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvDentalLab.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDentalLabCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvDentalLab.Rows.Count > 1 Then SetDentalLaboratoryEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDentalLabQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalCategoryLaboratoryAmount(selectedRow)
                Me.CalculateBillForDentalCategoryLaboratory()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colDentalLabUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalCategoryLaboratoryAmount(selectedRow)
                Me.CalculateBillForDentalCategoryLaboratory()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDentalLaboratoryEntries(ByVal selectedRow As Integer)

        Try

            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDentalLab.Rows(selectedRow).Cells, Me.colDentalLabCode)

            If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalLaboratory As EnumerableRowCollection(Of DataRow) = dentalLaboratory.AsEnumerable()
                Dim dentalDisplay As String = (From data In _DentalLaboratory
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalLabNameValue.ToUpper())
                                    Select data.Field(Of String)("DentalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Dental Lab (" + dentalDisplay + ") can't be edited!")
                Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, selectedRow).Value = _DentalLabNameValue
                Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDentalLab.Rows(rowNo).Cells, Me.colDentalLabCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _DentalLaboratory As EnumerableRowCollection(Of DataRow) = dentalLaboratory.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _DentalLaboratory
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DentalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental Lab (" + enteredDisplay + ") already selected!")
                        Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, selectedRow).Value = _DentalLabNameValue
                        Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If dentalLaboratory Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)
            Dim quantity As Integer = 1

            For Each row As DataRow In dentalLaboratory.Select("DentalCode = '" + selectedItem + "'")

                Me.dgvDentalLab.Item(Me.colDentalLabUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvDentalLab.Item(Me.colDentalLabQuantity.Name, selectedRow).Value = quantity
                Me.dgvDentalLab.Item(Me.colDentalLabItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
                    Me.dgvDentalLab.Item(Me.colDentalLabPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvDentalLab.Item(Me.colDentalLabPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateDentalCategoryLaboratoryAmount(selectedRow)
            Me.CalculateBillForDentalCategoryLaboratory()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDentalLab_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDentalLab.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round's No!"))
            Dim itemCode As String = CStr(Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDentalLab_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvDentalLab.UserDeletedRow
        Me.CalculateBillForDentalCategoryLaboratory()
    End Sub

    Private Sub dgvDentalLab_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDentalLab.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateDentalCategoryLaboratoryAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDentalLab.Rows(selectedRow).Cells, Me.colDentalLabQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvDentalLab.Rows(selectedRow).Cells, Me.colDentalLabUnitPrice)

        Me.dgvDentalLab.Item(Me.colDentalLabAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForDentalCategoryLaboratory()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 1

            If IsNumeric(Me.dgvDentalLab.Item(Me.colDentalLabAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvDentalLab.Item(Me.colDentalLabAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadDentalCategoryLaboratory(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try

            Me.dgvDentalLab.Rows.Clear()

            ' Load items not yet paid for

            Dim dental As DataTable = oIPDItems.GetDentalIPDItems(roundNo, GetLookupDataDes(oDentalCategoryID.Laboratory)).Tables("IPDItems")
            If dental Is Nothing OrElse dental.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To dental.Rows.Count - 1

                Dim row As DataRow = dental.Rows(pos)
                With Me.dgvDentalLab

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colDentalLabCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDentalLabNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDentalLabQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colDentalLabUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colDentalLabAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDentalLabItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDentalLabPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colDentalLabSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForDentalCategoryLaboratory()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Diagnosis - Grid "

    Private Sub dgvDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDiagnosis.CellBeginEdit

        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    End Sub

    Private Sub dgvDiagnosis_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colICDDiagnosisCode)
            Dim rowIndex As Integer

            If Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDiagnosis.Rows(e.RowIndex).IsNewRow Then

                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvDiagnosis.NewRowIndex
                If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)


            ElseIf Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) Then
                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvDiagnosis.NewRowIndex
                If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
            End If

            'If e.RowIndex < 0 Then Return

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Diseases", "Disease Code", "Disease Name", Me.LoadDiseases(), "DiseaseFullName",
            '                                                         "DiseaseCode", "DiseaseFullName", Me.dgvDiagnosis, Me.colICDDiagnosisCode, e.RowIndex)

            'Me._DiagnosisCode = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(e.RowIndex).Cells, Me.colICDDiagnosisCode)

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDiagnosis.Rows(e.RowIndex).IsNewRow Then

            '    Me.dgvDiagnosis.Rows.Add()

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetDiagnosisEntries(e.RowIndex)
            'ElseIf Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) Then

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetDiagnosisEntries(e.RowIndex)

            'End If
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub dgvDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colICDDiagnosisCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvDiagnosis.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
                    Me.SetDiagnosisEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub



    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim odiagnosis As New SyncSoft.SQLDb.Diseases()


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colICDDiagnosisCode)


            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As DataTable = odiagnosis.GetDiseases(selectedItem).Tables("Diseases")
                If diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
                Dim row As DataRow = diagnosis.Rows(0)
                Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + enteredDisplay + ") can't be edited!")
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2


                If Not rowNo.Equals(selectedRow) Then

                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colICDDiagnosisCode)

                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As DataTable = odiagnosis.GetDiseases(enteredItem).Tables("Diseases")

                        If diagnosis Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
                        Dim row As DataRow = diagnosis.Rows(0)

                        Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailSelectedDiagnosis(selectedRow, (SubstringRight(selectedItem)))

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseCode = '" + selectedItem + "'")
                Me.dgvDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCategories")
                Me.dgvDiagnosis.Item(Me.ColDiagnosedBy.Name, selectedRow).Value = CurrentUser.FullName
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadDiseaseAttachedPrescriptions(selectedRow, selectedItem)
            Me.LoadDiseaseAttachedLabTests(selectedRow, selectedItem)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailSelectedDiagnosis(ByVal selectedRow As Integer, selectedItem As String)
        Try

            Dim odiagnosis As New SyncSoft.SQLDb.Diseases()

            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim diagnosis As DataTable = odiagnosis.GetDiseases(selectedItem).Tables("Diseases")

            If diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = diagnosis.Rows(0)
            With Me.dgvDiagnosis

                .Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCode")
                .Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                .Item(Me.colDiseaseCode.Name, selectedRow).Value = StringMayBeEnteredIn(row, "DiseaseName")
                .Item(Me.ColDiagnosedBy.Name, selectedRow).Value = CurrentUser.FullName
            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = Me._DiagnosisCode.ToUpper()
            Throw ex

        End Try

    End Sub



    Private Sub LoadDiseaseAttachedPrescriptions(selectedRow As Integer, diseasecode As String)

        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim attachedPrescriptions As DataTable = oItems.GetAttachedPossiblePrescription(diseasecode).Tables("PossibleAttachedItems")
        If attachedPrescriptions.Rows.Count > 0 Then

            Dim Message As String = "Hello I can suggest Prescriptions for this selected diagnosis " +
                       ControlChars.NewLine + "Would you like it If I go ahead?"
            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)

                If attachedPrescriptions Is Nothing OrElse attachedPrescriptions.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvPrescription.Rows.Count - 1

                If selectedRow = dgvDiagnosis.Rows.Count - 2 Then

                    For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                        Dim row As DataRow = attachedPrescriptions.Rows(pos)
                        With Me.dgvPrescription

                            ' Ensure that you add a new row
                            .Rows.Add()

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                            Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
                            Dim amount As Decimal = quantity * unitPrice

                            .Item(Me.colDrugNo.Name, count).Value = drugNo
                            .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugName")
                            Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                            .Item(Me.colDrugQuantity.Name, count).Value = quantity
                            .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                            .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                            .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                            .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)

                            '' .Item(Me.ColPrescribedby.Name, pos).Value = CurrentUser.FullName
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                                .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                            Else
                                .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                            End If
                            .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                            count += 1

                        End With

                    Next

                End If
            End If
        End If
    End Sub

    Private Sub LoadDiseaseAttachedLabTests(selectedRow As Integer, diseasecode As String)

        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim attachedPrescriptions As DataTable = oItems.GetPossibleAttachedLabTests(diseasecode).Tables("PossibleAttachedItems")
        If attachedPrescriptions.Rows.Count > 0 Then

            Dim Message As String = "Hi there I can suggest Lab Tests for this selected diagnosis " +
                       ControlChars.NewLine + "Would you like it If I go ahead?"
            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                Me.tbcDrRoles.SelectTab(Me.tpgLaboratory.Name)

                If attachedPrescriptions Is Nothing OrElse attachedPrescriptions.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvLabTests.Rows.Count - 1

                If selectedRow = dgvDiagnosis.Rows.Count - 2 Then

                    For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                        Dim row As DataRow = attachedPrescriptions.Rows(pos)
                        With Me.dgvLabTests

                            ' Ensure that you add a new row
                            .Rows.Add()

                            Dim testCode As String = StringEnteredIn(row, "ItemCode")
                            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillAccountNo))
                            Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)
                            Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            .Item(Me.ColLabTestCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                            .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "TestName")
                            .Item(Me.colLTQuantity.Name, pos).Value = quantity
                            .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                            .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                            .Item(Me.colLTItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                            .Item(Me.ColRequestedBy.Name, pos).Value = CurrentUser.FullName
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                                .Item(Me.colLTPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)

                            Else
                                .Item(Me.colLTPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                            End If

                            .Item(Me.colRejectionStatus.Name, pos).Value = "False"
                            .Item(Me.colLabTestsSaved.Name, pos).Value = False
                            count += 1

                        End With

                    Next

                End If
            End If
        End If
    End Sub

    Private Sub dgvDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDiagnosis.UserDeletingRow
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round's No!"))
            Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oIPDDiagnosis
                .RoundNo = roundNo
                .DiseaseCode = diagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub


    Private Sub LoadIPDDiagnosis(ByVal roundNo As String)

        Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim diagnosis As DataTable = oIPDDiagnosis.GetIPDDiagnosis(RevertText(roundNo)).Tables("IPDDiagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To diagnosis.Rows.Count - 1

                Dim row As DataRow = diagnosis.Rows(pos)

                With Me.dgvDiagnosis
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseName")
                    .Item(Me.colICDDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.ColDiagnosedBy.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



#End Region


#Region " Laboratory - Printing "

    Private Sub PrintLaboratory()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvLabTests.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for lab test!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetLaboratoryPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetLaboratoryPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Test Name: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

                If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = SubstringLeft(cells.Item(Me.colTest.Name).Value.ToString())
                    Dim quantity As String = cells.Item(Me.colLTQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colLTUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Cardiology - Printing "

    Private Sub PrintCardiology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCardiology.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for Cardiology examinations!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvCardiology.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Cardiology examinations!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCardiologyPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetCardiologyPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Examination: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

                If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = SubstringLeft(cells.Item(Me.colCardiologyExamFullName.Name).Value.ToString())
                    Dim quantity As String = cells.Item(Me.colCardiologyQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colCardiologyUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region


#Region " Radiology - Printing "

    Private Sub PrintRadiology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvRadiology.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for radiology examinations!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for radiology examinations!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetRadiologyPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetRadiologyPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Examination: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

                If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = SubstringLeft(cells.Item(Me.colExamFullName.Name).Value.ToString())
                    Dim quantity As String = cells.Item(Me.colRadiologyQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colRadiologyUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Prescription Printing "

    Private Sub PrintPrescription()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for prescription!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for prescription!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPrescriptionPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetPrescriptionPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 18
        Dim padFullDosage As Integer = 18
        Dim padQuantity As Integer = 5
        Dim padUnitPrice As Integer = 10
        Dim padAmount As Integer = 14
        Dim padTotalAmount As Integer = 58

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Drug Name: ".PadRight(padItemName))
            tableHeader.Append(" ")
            tableHeader.Append("Dosage: ".PadRight(padFullDosage))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = SubstringLeft(cells.Item(Me.colDrug.Name).Value.ToString())
                    Dim dosage As String = cells.Item(Me.colDosage.Name).Value.ToString()
                    Dim duration As String = cells.Item(Me.colDuration.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colDrugQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDrugUnitPrice.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()

                    Dim fullDosage As String
                    If duration.Trim().Equals("1") Then
                        fullDosage = dosage + " for " + duration + " day"
                    Else : fullDosage = dosage + " for " + duration + " days"
                    End If

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 18 Then
                        tableData.Append(itemName.Substring(0, 18).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(" ")
                    If fullDosage.Length > 18 Then
                        tableData.Append(fullDosage.Substring(0, 18).PadRight(padFullDosage))
                    Else : tableData.Append(fullDosage.PadRight(padFullDosage))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Procedures - Printing "

    Private Sub PrintProcedures()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for Procedure!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Procedure!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetProceduresPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetProceduresPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Procedure: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

                If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = cells.Item(Me.colICDProcedureCode.Name).Value.ToString()
                    Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim itemName As String = (From data In _Procedures
                                        Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper())
                                        Select data.Field(Of String)("ProcedureName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colProcedureQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colProcedureUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Theatre - Printing "

    Private Sub PrintTheatre()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTheatre.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for Theatre!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Theatre!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetTheatrePrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetTheatrePrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Theatre: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

                If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = cells.Item(Me.colICDTheatreCode.Name).Value.ToString()
                    Dim _Theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim itemName As String = (From data In _Theatre
                                        Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper())
                                        Select data.Field(Of String)("TheatreName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colTheatreQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colTheatreUnitPrice.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colTheatreAmount.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Dental Category Service - Printing "

    Private Sub PrintDentalCategoryService()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDental.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for Dental!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Dental!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDentalCategoryServicePrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetDentalCategoryServicePrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Dental: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1

                If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = cells.Item(Me.colDentalCode.Name).Value.ToString()
                    Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalService.AsEnumerable()
                    Dim itemName As String = (From data In _DentalServices _
                                        Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                        Select data.Field(Of String)("DentalName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colDentalQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDentalUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Dental Category Laboratory - Printing "

    Private Sub PrintDentalCategoryLaboratory()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDentalLab.RowCount <= 1 Then Throw New ArgumentException("Must include at least one entry for Dental Lab!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvDentalLab.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Dental Lab!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDentalCategoryLaboratoryPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetDentalCategoryLaboratoryPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 8
        Dim padUnitPrice As Integer = 16
        Dim padAmount As Integer = 20
        Dim padTotalAmount As Integer = 56

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Dental Lab: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 1

                If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDentalLab.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = cells.Item(Me.colDentalLabCode.Name).Value.ToString()
                    Dim _Dental As EnumerableRowCollection(Of DataRow) = dentalLaboratory.AsEnumerable()
                    Dim itemName As String = (From data In _Dental _
                                        Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                        Select data.Field(Of String)("DentalName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colDentalLabQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDentalLabUnitPrice.Name).Value.ToString()
                    Dim amount As String = unitPrice

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill: ")
            totalAmount.Append(Me.stbBillForItem.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBillWords)
            footerData.Append("(" + amountWords + " ONLY)")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Security Method "

    Private Sub ApplySecurity()

        Try
            If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgIPDEye.Name) Then

                Me.btnSave.Tag = Me.tbcIPDEye.SelectedTab.Tag.ToString()
                Me.fbnDelete.Tag = Me.tbcIPDEye.SelectedTab.Tag.ToString()
            Else
                Me.btnSave.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()
                Me.fbnDelete.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()

            End If

            Security.Apply(Me.btnSave, AccessRights.Write)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Rounds Navigate "

    Private Sub EnableNavigateRoundsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNoNavigate(admissionNo).Tables("IPDDoctor")

                For pos As Integer = 0 To iPDDoctor.Rows.Count - 1
                    If roundNo.ToUpper().Equals(iPDDoctor.Rows(pos).Item("RoundNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navRounds.DataSource = iPDDoctor
                Me.navRounds.Navigate(startPosition)

            Else : Me.navRounds.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateRounds.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateRounds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateRounds.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkNavigateRounds.Checked = Not Me.chkNavigateRounds.Checked
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navRounds.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(currentValue.ToString())
            If String.IsNullOrEmpty(roundNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadRoundsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Popup Menu "

    Private Sub cmsDoctor_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDoctor.Opening

        Select Case Me.tbcDrRoles.SelectedTab.Name

            Case Me.tpgDiagnosis.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgLaboratory.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgCardiology.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgRadiology.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgPrescriptions.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgProcedures.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgTheatre.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgDental.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgDentalLab.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

            Case Me.tpgLabResults.Name

                Me.cmsDoctorCopy.Visible = True
                Me.cmsDoctorSelectAll.Visible = True
                Me.cmsDoctorQuickSearch.Visible = False

                If Me.dgvLabResults.ColumnCount < 1 OrElse Me.dgvLabResults.RowCount < 1 Then
                    Me.cmsDoctorCopy.Enabled = False
                    Me.cmsDoctorSelectAll.Enabled = False
                Else
                    Me.cmsDoctorCopy.Enabled = True
                    Me.cmsDoctorSelectAll.Enabled = True
                End If

            Case Me.tpgCardiologyReports.Name

                Me.cmsDoctorCopy.Visible = True
                Me.cmsDoctorSelectAll.Visible = True
                Me.cmsDoctorQuickSearch.Visible = False

                If Me.dgvCardiologyReports.ColumnCount < 1 OrElse Me.dgvCardiologyReports.RowCount < 1 Then
                    Me.cmsDoctorCopy.Enabled = False
                    Me.cmsDoctorSelectAll.Enabled = False
                Else
                    Me.cmsDoctorCopy.Enabled = True
                    Me.cmsDoctorSelectAll.Enabled = True
                End If

            Case Me.tpgRadiologyReports.Name

                Me.cmsDoctorCopy.Visible = True
                Me.cmsDoctorSelectAll.Visible = True
                Me.cmsDoctorQuickSearch.Visible = False

                If Me.dgvRadiologyReports.ColumnCount < 1 OrElse Me.dgvRadiologyReports.RowCount < 1 Then
                    Me.cmsDoctorCopy.Enabled = False
                    Me.cmsDoctorSelectAll.Enabled = False
                Else
                    Me.cmsDoctorCopy.Enabled = True
                    Me.cmsDoctorSelectAll.Enabled = True
                End If

            Case Else

                Me.cmsDoctorCopy.Visible = True
                Me.cmsDoctorSelectAll.Visible = True
                Me.cmsDoctorQuickSearch.Visible = False

                Me.cmsDoctorCopy.Enabled = False
                Me.cmsDoctorSelectAll.Enabled = False

        End Select

    End Sub

    Private Sub cmsDoctorCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDoctorCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgLabResults.Name

                    If Me.dgvLabResults.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvLabResults))

                Case Me.tpgCardiologyReports.Name

                    If Me.dgvCardiologyReports.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCardiologyReports))

                Case Me.tpgRadiologyReports.Name

                    If Me.dgvRadiologyReports.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvRadiologyReports))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsDoctorSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDoctorSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgLabResults.Name
                    Me.dgvLabResults.SelectAll()

                Case Me.tpgCardiologyReports.Name
                    Me.dgvCardiologyReports.SelectAll()

                Case Me.tpgRadiologyReports.Name
                    Me.dgvRadiologyReports.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsDoctorQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDoctorQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgDiagnosis.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colICDDiagnosisCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgLaboratory.Name

                     Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("LabTests", Me.dgvLabTests, Me.ColLabTestCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvLabTests.NewRowIndex - 1
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowIndex).Cells, Me.ColLabTestCode)
                    Dim testcode As String = SubstringRight(selectedItem)
                    Me.SetLabTestsEntries(rowIndex, testcode)

                Case Me.tpgCardiology.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("CardiologyExaminations", Me.dgvCardiology, Me.colCardiologyExamFullName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvCardiology.NewRowIndex
                    If rowIndex > 0 Then Me.SetCardiologyExaminationsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgRadiology.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("RadiologyExaminations", Me.dgvRadiology, Me.colExamFullName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvRadiology.NewRowIndex
                    If rowIndex > 0 Then Me.SetRadiologyExaminationsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgPrescriptions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrugNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvPrescription.NewRowIndex
                    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgProcedures.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Procedures", Me.dgvProcedures, Me.colProcedureCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvProcedures.NewRowIndex
                    If rowIndex > 0 Then Me.SetProceduresEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgTheatre.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colTheatreCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvTheatre.NewRowIndex
                    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDental.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("DentalServiceItems", Me.dgvDental, Me.colDentalCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDental.NewRowIndex
                    If rowIndex > 0 Then Me.SetDentalServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDentalLab.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("DentalLabItems", Me.dgvDentalLab, Me.colDentalLabCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDentalLab.NewRowIndex
                    If rowIndex > 0 Then Me.SetDentalLaboratoryEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnNewVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewVisionAssessment.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            Dim fIPDVisionAssessment As New frmIPDVisionAssessment(admissionNo, False)
            fIPDVisionAssessment.ShowDialog()
            'fIPDVisionAssessment.Save()
            Me.ShowlatestIPDVisionAssessment(admissionNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub tbcIPDEye_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbcIPDEye.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDEye.SelectedTab.Name

                Case Me.tpgIPDVisionAssessment.Name

                    Me.btnSave.Visible = False
                    Me.fbnDelete.Visible = False

                Case Me.tpgIPDEyeAssessment.Name

                    Me.btnSave.Visible = True
                    Me.fbnDelete.Visible = True

                    '''''''''''''''''''''''''''''
                    Me.ApplySecurity()
                    '''''''''''''''''''''''''''''

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnAddExtraCharge_Click(sender As System.Object, e As System.EventArgs) Handles btnAddExtraCharge.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fExtraCharge As New frmIPDExtraCharge(visitNo)

            fExtraCharge.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnCancerDiagnosis_Click(sender As System.Object, e As System.EventArgs) Handles btnCancerDiagnosis.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim staffFullName As String = StringMayBeEnteredIn(Me.stbFullName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fCancerDiagnosis As New frmIPDCancerDiagnosis(roundNo, staffFullName)
            fCancerDiagnosis.ShowDialog()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#Region " Pathology - Grid "

    Private Sub dgvHistopathologyRequisition_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvHistopathologyRequisition.CellBeginEdit
        If e.ColumnIndex <> Me.colPathologyExamFullName.Index OrElse Me.dgvHistopathologyRequisition.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvHistopathologyRequisition.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

    End Sub

    Private Sub dgvHistopathologyRequisition_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistopathologyRequisition.CellEndEdit
        Try

            If Me.colPathologyExamFullName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colPathologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvHistopathologyRequisition.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvHistopathologyRequisition.CurrentCell.RowIndex
                    Me.SetPathologyExaminationsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetPathologyExaminationsEntries(ByVal selectedRow As Integer)

        Try
            Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

            If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Pathology Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(rowNo).Cells, Me.colPathologyExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillMode))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Pathology, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "PathologyCategories")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyQuantity.Name, selectedRow).Value = 1
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Pathology).Equals(True) Then
                    Me.dgvHistopathologyRequisition.Item(Me.colPathologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvHistopathologyRequisition.Item(Me.colPathologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)

                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPathology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvHistopathologyRequisition_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvHistopathologyRequisition.UserDeletingRow
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, toDeleteRowNo).Value) = False Then Return
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Pathology
            End With

            DisplayMessage(oIPDItems.Delete())


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvHistopathologyRequisition_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvHistopathologyRequisition.UserDeletedRow
        Me.CalculateBillForPathology()
    End Sub

    Private Sub dgvHistopathologyRequisition_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvHistopathologyRequisition.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForPathology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 1

            If IsNumeric(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowPathologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "PathologyCategories")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPathology(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvHistopathologyRequisition.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathology As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Pathology).Tables("IPDItems")
            If pathology Is Nothing OrElse pathology.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To pathology.Rows.Count - 1

                Dim row As DataRow = pathology.Rows(pos)
                With Me.dgvHistopathologyRequisition

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colPathologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colPathologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colPathologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowPathologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colPathologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colPathologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colPathologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colPathologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPathology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculatePathologyAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyUnitPrice)

        Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadPathologyReports(ByVal roundNo As String)

        Dim oPathologyReports As New SyncSoft.SQLDb.IPDPathologyReports()

        Try

            ' Load from Lab PathologyReports
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathologyReports As DataTable = oPathologyReports.GetIPDPathologyReports(RevertText(roundNo)).Tables("IPDPathologyReports")

            If pathologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvHistopathologyReport, pathologyReports)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

  

#End Region

    'Private Sub dgvTheatre_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellClick
    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        'Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
    '        ''fQuickSearch.ShowDialog(Me)
    '        'Dim rowIndex As Integer

    '        'If Me.colTheatreSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvTheatre.Rows(e.RowIndex).IsNewRow Then

    '        '    fQuickSearch.ShowDialog(Me)
    '        '    rowIndex = Me.dgvTheatre.NewRowIndex
    '        '    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)

    '        'ElseIf Me.colTheatreSelect.Index.Equals(e.ColumnIndex) Then
    '        '    fQuickSearch.ShowDialog(Me)
    '        '    rowIndex = Me.dgvTheatre.NewRowIndex
    '        '    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
    '        'End If


    '    Catch ex As Exception

    '    End Try



    'End Sub

#Region " IPD Doctor - Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Me.Cursor = Cursors.WaitCursor
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Medical Report (Dr)")

        Try
            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgClinicalFindings.Name
                    Me.PrintMedicalReport()
                    SavePrintDetails(patientNo, visitNo, printdesc, docTypeID.MedicalReport)
                Case Me.tpgClinicalFindings.Name
                    MessageBox.Show("Print Clinical Findings...")
              

                Case Me.tpgLaboratory.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Laboratory Request".ToUpper()
                    Me.PrintLaboratory()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Laboratory Request (Dr)"), docTypeID.LabTests)

                Case Me.tpgCardiology.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Cardiology Examination Request".ToUpper()
                    Me.PrintCardiology()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Cardiology Examination Request (Dr)"), docTypeID.Cardiology)

                Case Me.tpgRadiology.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Radiology Examination Request".ToUpper()
                    Me.PrintRadiology()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Radiology Examination Request (Dr)"), docTypeID.Radiology)

                Case Me.tpgPrescriptions.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Prescription".ToUpper()
                    Me.PrintPrescription()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Prescription (Dr)"), docTypeID.Prescription)

                Case Me.tpgProcedures.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Procedure Request".ToUpper()
                    PrintProcedures()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Procedure Request (Dr)"), docTypeID.Procedure)

                Case Me.tpgTheatre.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Theatre Service Request".ToUpper()
                    PrintTheatre()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Theatre Service Request (Dr)"), docTypeID.Theatre)


                Case Me.tpgDental.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Dental Request".ToUpper()
                    Me.PrintDentalCategoryService()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Dental Request (Dr)"), docTypeID.Dental)

                Case Me.tpgDentalLab.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Dental Lab Request".ToUpper()
                    Me.PrintDentalCategoryLaboratory()
                    SavePrintDetails(patientNo, visitNo, (stbFullName.Text + " 's" + " Dental Lab Request (Dr)"), docTypeID.Dental)

                Case Me.tpgLabResults.Name

                    If Me.dgvLabResults.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for lab results!")

                    Dim selectedRow As Integer = Me.dgvLabResults.CurrentCell.RowIndex
                    Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.dgvLabResults.Rows(selectedRow).Cells, Me.colSpecimenNo))
                    Dim fPrintLabResults As New frmPrintLabResults(specimenNo)
                    fPrintLabResults.ShowDialog()


                Case Me.tpgCardiologyReports.Name

                    If Me.dgvCardiologyReports.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for Cardiology report!")

                    ' Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Dim fPrintCardiologyReports As New frmPrintCardiologyReports(visitNo)
                    fPrintCardiologyReports.ShowDialog()


                Case Me.tpgRadiologyReports.Name

                    If Me.dgvRadiologyReports.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for radiology report!")

                    ' Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                    If String.IsNullOrEmpty(visitNo) Then Return

                    Dim fPrintRadiologyReports As New frmPrintRadiologyReports(visitNo)
                    fPrintRadiologyReports.ShowDialog()


                Case Me.tpgDiagnosis.Name
                    MessageBox.Show("Print Diagnosis...")

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
        'Try


        '    Me.Cursor = Cursors.WaitCursor
        '    Dim docTypeID As New LookupDataID.DocumentTypeID()
        '    Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        '    Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo))
        '    Dim printdesc As String = (stbFullName.Text + " 's" + " Medical Report (Dr)")
        '    Select Case Me.tbcDrRoles.SelectedTab.Name

        '        Case Me.tpgClinicalFindings.Name
        '            Me.PrintMedicalReport()
        '            SavePrintDetails(patientNo, roundNo, printdesc, docTypeID.MedicalReport)
        '        Case Me.tpgClinicalFindings.Name
        '            MessageBox.Show("Print Clinical Findings...")
        '        Case Me.tpgIPDEye.Name
        '            MessageBox.Show("Print Eye Assessment...")

        '        Case Me.tpgLaboratory.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Laboratory Request".ToUpper()
        '            Me.PrintLaboratory()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Laboratory Request (Dr)"), docTypeID.LabTests)

        '        Case Me.tpgCardiology.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Cardiology Examination Request".ToUpper()
        '            Me.PrintCardiology()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Cardiology Examination Request (Dr)"), docTypeID.Cardiology)

        '        Case Me.tpgRadiology.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Radiology Examination Request".ToUpper()
        '            Me.PrintRadiology()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Radiology Examination Request (Dr)"), docTypeID.Radiology)

        '        Case Me.tpgPrescriptions.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Prescription".ToUpper()
        '            Me.PrintPrescription()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Prescription (Dr)"), docTypeID.Prescription)

        '        Case Me.tpgProcedures.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Procedure Request".ToUpper()
        '            PrintProcedures()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Procedure Request (Dr)"), docTypeID.Procedure)

        '        Case Me.tpgTheatre.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Theatre Service Request".ToUpper()
        '            PrintTheatre()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Theatre Service Request (Dr)"), docTypeID.Theatre)


        '        Case Me.tpgDental.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Dental Request".ToUpper()
        '            Me.PrintDentalCategoryService()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Dental Request (Dr)"), docTypeID.Dental)

        '        Case Me.tpgDentalLab.Name
        '            title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Dental Lab Request".ToUpper()
        '            Me.PrintDentalCategoryLaboratory()
        '            SavePrintDetails(patientNo, roundNo, (stbFullName.Text + " 's" + " Dental Lab Request (Dr)"), docTypeID.Dental)


        '        Case Me.tpgLabResults.Name

        '            If Me.dgvLabResults.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for lab results!")

        '            Dim selectedRow As Integer = Me.dgvLabResults.CurrentCell.RowIndex
        '            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.dgvLabResults.Rows(selectedRow).Cells, Me.colSpecimenNo))
        '            Dim fPrintLabResults As New frmPrintLabResults(specimenNo)
        '            fPrintLabResults.ShowDialog()


        '        Case Me.tpgCardiologyReports.Name

        '            If Me.dgvCardiologyReports.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for Cardiology report!")

        '            ' Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        '            If String.IsNullOrEmpty(roundNo) Then Return

        '            Dim fPrintCardiologyReports As New frmPrintCardiologyReports(roundNo)
        '            fPrintCardiologyReports.ShowDialog()


        '        Case Me.tpgRadiologyReports.Name

        '            If Me.dgvRadiologyReports.RowCount <= 0 Then Throw New ArgumentException("Must have at least one entry for radiology report!")

        '            ' Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        '            If String.IsNullOrEmpty(roundNo) Then Return

        '            Dim fPrintRadiologyReports As New frmPrintRadiologyReports(roundNo)
        '            fPrintRadiologyReports.ShowDialog()

        '        Case Me.tpgDiagnosis.Name
        '            MessageBox.Show("Print Diagnosis...")

        '    End Select

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default

        'End Try
    End Sub

    Private Sub docDoctor_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDoctor.PrintPage

        Try

            Dim titleFont As New Font("Courier New", 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim roundNo As String = StringValueMayBeEnteredIn(Me.cboRoundNo)
            Dim roundDate As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)

            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = SubstringLeft(Me.cboStaffNo.Text)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 6 * widthTopFirst
                Dim widthTopThird As Single = 15 * widthTopFirst
                Dim widthTopFourth As Single = 25 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Round Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    '.DrawString(roundDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    '.DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    '.DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                    'yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If doctorParagraphs Is Nothing Then Return

                Do While doctorParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(doctorParagraphs(1), PrintParagraps)
                    doctorParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        doctorParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (doctorParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub PrintIPDMedicalReport()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetIPDMedicalReportPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            btnPrint.Enabled = True
            dlgPrint.Document = docMedicalReport
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docMedicalReport.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetIPDMedicalReportPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        medicalReportParagraphs = New Collection()

        Try


            '''''''''''''''CLINICAL FINDINGS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim clinicalFindingsTitle As New System.Text.StringBuilder(String.Empty)
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            clinicalFindingsTitle.Append("IPD CLINICAL FINDINGS: ".ToUpper())
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, clinicalFindingsTitle.ToString()))
            ' medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ClinicalFindingsData()))

            ''''''''''''''''Orthoptics'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orthopticsTitle As New System.Text.StringBuilder(String.Empty)
            orthopticsTitle.Append(ControlChars.NewLine)
            orthopticsTitle.Append("IPD ORTHOPTICS: ".ToUpper())
            orthopticsTitle.Append(ControlChars.NewLine)
            orthopticsTitle.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, orthopticsTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OrthopticsData()))

           
            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append(ControlChars.NewLine)

            Dim tableDiagnosis As New System.Text.StringBuilder(String.Empty)
            tableDiagnosis.Append("No: ".PadRight(padLineNo))
            tableDiagnosis.Append("Diagnosis: ".PadRight(padService))
            tableDiagnosis.Append("Notes: ".PadRight(padNotes))
            tableDiagnosis.Append(ControlChars.NewLine)
            tableDiagnosis.Append(ControlChars.NewLine)

            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))
            If Me.dgvDiagnosis.RowCount > 1 Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDiagnosis.ToString()))
            End If
            medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))

            ''''''''''''''''Laboratory'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim laboratoryTitle As New System.Text.StringBuilder(String.Empty)
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append("LABORATORY: ".ToUpper())
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append(ControlChars.NewLine)

            Dim tableLaboratory As New System.Text.StringBuilder(String.Empty)
            tableLaboratory.Append("No: ".PadRight(padLineNo))
            tableLaboratory.Append("Test Name: ".PadRight(padService + padNotes))
            tableLaboratory.Append(ControlChars.NewLine)
            tableLaboratory.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.LaboratoryData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, laboratoryTitle.ToString()))
                If Me.dgvLabTests.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableLaboratory.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.LaboratoryData()))
            End If

            ''''''''''''''''Cardiology'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim CardiologyTitle As New System.Text.StringBuilder(String.Empty)
            CardiologyTitle.Append(ControlChars.NewLine)
            CardiologyTitle.Append("Cardiology: ".ToUpper())
            CardiologyTitle.Append(ControlChars.NewLine)
            CardiologyTitle.Append(ControlChars.NewLine)

            Dim tableCardiology As New System.Text.StringBuilder(String.Empty)
            tableCardiology.Append("No: ".PadRight(padLineNo))
            tableCardiology.Append("Cardiology Examination: ".PadRight(padService))
            tableCardiology.Append("Indication: ".PadRight(padNotes))
            tableCardiology.Append(ControlChars.NewLine)
            tableCardiology.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.CardiologyData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, CardiologyTitle.ToString()))
                If Me.dgvCardiology.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableCardiology.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CardiologyData()))
            End If

            ''''''''''''''''Radiology'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radiologyTitle As New System.Text.StringBuilder(String.Empty)
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append("RADIOLOGY: ".ToUpper())
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append(ControlChars.NewLine)

            Dim tableRadiology As New System.Text.StringBuilder(String.Empty)
            tableRadiology.Append("No: ".PadRight(padLineNo))
            tableRadiology.Append("Radiology Examination: ".PadRight(padService))
            tableRadiology.Append("Indication: ".PadRight(padNotes))
            tableRadiology.Append(ControlChars.NewLine)
            tableRadiology.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.RadiologyData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, radiologyTitle.ToString()))
                If Me.dgvRadiology.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableRadiology.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RadiologyData()))
            End If

            ''''''''''''''''Prescription'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("Prescription: ".ToUpper())
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append(ControlChars.NewLine)

            Dim tablePrescription As New System.Text.StringBuilder(String.Empty)
            tablePrescription.Append("No: ".PadRight(padLineNo))
            tablePrescription.Append("Drug Name: ".PadRight(padService))
            tablePrescription.Append("Dosage: ".PadRight(padNotes))
            tablePrescription.Append(ControlChars.NewLine)
            tablePrescription.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.PrescriptionData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionTitle.ToString()))
                If Me.dgvPrescription.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tablePrescription.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionData()))
            End If

            ''''''''''''''''Procedures'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proceduresTitle As New System.Text.StringBuilder(String.Empty)
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append("Procedures: ".ToUpper())
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append(ControlChars.NewLine)

            Dim tableProcedures As New System.Text.StringBuilder(String.Empty)
            tableProcedures.Append("No: ".PadRight(padLineNo))
            tableProcedures.Append("Procedure Name: ".PadRight(padService))
            tableProcedures.Append("Notes: ".PadRight(padNotes))
            tableProcedures.Append(ControlChars.NewLine)
            tableProcedures.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.ProceduresData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, proceduresTitle.ToString()))
                If Me.dgvProcedures.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableProcedures.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ProceduresData()))
            End If

            ''''''''''''''''Theatre'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreTitle As New System.Text.StringBuilder(String.Empty)
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append("Theatre: ".ToUpper())
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append(ControlChars.NewLine)

            Dim tableTheatre As New System.Text.StringBuilder(String.Empty)
            tableTheatre.Append("No: ".PadRight(padLineNo))
            tableTheatre.Append("Theatre Name: ".PadRight(padService))
            tableTheatre.Append("Notes: ".PadRight(padNotes))
            tableTheatre.Append(ControlChars.NewLine)
            tableTheatre.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.TheatreData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, theatreTitle.ToString()))
                If Me.dgvTheatre.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableTheatre.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TheatreData()))
            End If

            ''''''''''''''''Dental Services'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dentalTitle As New System.Text.StringBuilder(String.Empty)
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append("Dental Services: ".ToUpper())
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append(ControlChars.NewLine)

            Dim tableDental As New System.Text.StringBuilder(String.Empty)
            tableDental.Append("No: ".PadRight(padLineNo))
            tableDental.Append("Dental Service: ".PadRight(padService))
            tableDental.Append("Notes: ".PadRight(padNotes))
            tableDental.Append(ControlChars.NewLine)
            tableDental.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.DentalServicesData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, dentalTitle.ToString()))
                If Me.dgvDental.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDental.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalServicesData()))
            End If

            ''''''''''''''''Dental Laboratory'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dentalLabTitle As New System.Text.StringBuilder(String.Empty)
            dentalLabTitle.Append(ControlChars.NewLine)
            dentalLabTitle.Append("Dental Laboratory: ".ToUpper())
            dentalLabTitle.Append(ControlChars.NewLine)
            dentalLabTitle.Append(ControlChars.NewLine)

            Dim tableDentalLab As New System.Text.StringBuilder(String.Empty)
            tableDentalLab.Append("No: ".PadRight(padLineNo))
            tableDentalLab.Append("Dental Lab: ".PadRight(padService))
            tableDentalLab.Append("Notes: ".PadRight(padNotes))
            tableDentalLab.Append(ControlChars.NewLine)
            tableDentalLab.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.DentalLaboratoryData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, dentalLabTitle.ToString()))
                If Me.dgvDentalLab.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDentalLab.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalLaboratoryData()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Doctor's Sign:   " + GetCharacters("."c, 20))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 20))
            doctorSignData.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    'Public Function ClinicalFindingsData() As String

    '    Try

    '        Dim textData As New System.Text.StringBuilder(String.Empty)


    '        Dim clinicalNotes As String = StringMayBeEnteredIn(Me.stbClinicalNotes)
    '        Dim respiratory As String = StringMayBeEnteredIn(Me.stbRespiratory)
    '        Dim generalAppearance As String = StringMayBeEnteredIn(Me.stbGeneralAppearance)
    '        Dim cVS As String = StringMayBeEnteredIn(Me.stbCVS)
    '        Dim abdomen As String = StringMayBeEnteredIn(Me.stbAbdomen)
    '        Dim cNS As String = StringMayBeEnteredIn(Me.stbCNS)
    '        Dim muscularSkeletal As String = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
    '        Dim psychologicalStatus As String = StringMayBeEnteredIn(Me.stbPsychologicalStatus)
    '        Dim clinicalDiagnosis As String = StringMayBeEnteredIn(Me.stbClinicalDiagnosis)


    '        If Not String.IsNullOrEmpty(clinicalNotes) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
    '            Else : textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(respiratory) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Respiratory: " + ControlChars.NewLine + respiratory)
    '            Else : textData.Append("Respiratory: " + ControlChars.NewLine + respiratory)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(generalAppearance) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("General Appearance: " + ControlChars.NewLine + generalAppearance)
    '            Else : textData.Append("General Appearance: " + ControlChars.NewLine + generalAppearance)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(cVS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("CVS: " + ControlChars.NewLine + cVS)
    '            Else : textData.Append("CVS: " + ControlChars.NewLine + cVS)
    '            End If
    '        End If


    '        If Not String.IsNullOrEmpty(abdomen) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Abdomen & GUT: " + ControlChars.NewLine + abdomen)
    '            Else : textData.Append("Abdomen & GUT: " + ControlChars.NewLine + abdomen)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(cNS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("CNS: " + ControlChars.NewLine + cNS)
    '            Else : textData.Append("CNS: " + ControlChars.NewLine + cNS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(muscularSkeletal) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Muscular Skeletal: " + ControlChars.NewLine + muscularSkeletal)
    '            Else : textData.Append("Muscular Skeletal: " + ControlChars.NewLine + muscularSkeletal)
    '            End If
    '        End If


    '        If Not String.IsNullOrEmpty(psychologicalStatus) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Psychological Status: " + ControlChars.NewLine + psychologicalStatus)
    '            Else : textData.Append("Psychological Status: " + ControlChars.NewLine + psychologicalStatus)
    '            End If
    '        End If


    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

#Region " Clinical Findings Printing "


    Private Sub PrintClinicalFindings()

        Dim dlgPrint As New PrintDialog()
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Clinical Findings")
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetClinicalFindingsPrintData()
            'SavePrintDetails(patientNo, patientNo, printdesc, docTypeID.ClinicalFindings)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor

            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SetClinicalFindingsPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        Dim clinicalNotes As String = StringMayBeEnteredIn(Me.stbClinicalNotes)
        Dim respiratory As String = StringMayBeEnteredIn(Me.stbRespiratory)
        Dim generalAppearance As String = StringMayBeEnteredIn(Me.stbGeneralAppearance)
        Dim CVS As String = StringMayBeEnteredIn(Me.stbCVS)
        Dim abdomen As String = StringMayBeEnteredIn(Me.stbAbdomen)
        Dim CNS As String = StringMayBeEnteredIn(Me.stbCNS)
        Dim muscularSkeletal As String = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
        Dim psychologicalStatus As String = StringMayBeEnteredIn(Me.stbPsychologicalStatus)
        Dim clinicalDiagnosis As String = StringMayBeEnteredIn(Me.stbClinicalDiagnosis)
        Dim doctorName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))

        Dim patientsClinicalNotes As New System.Text.StringBuilder(String.Empty)
        Dim respiratoryClinical As New System.Text.StringBuilder(String.Empty)
        Dim generalAppearanceClinical As New System.Text.StringBuilder(String.Empty)
        Dim CVSClinical As New System.Text.StringBuilder(String.Empty)
        Dim abdomenClinical As New System.Text.StringBuilder(String.Empty)
        Dim CNSClinical As New System.Text.StringBuilder(String.Empty)
        Dim muscularSkeletalClinical As New System.Text.StringBuilder(String.Empty)
        Dim psychologicalStatusClinical As New System.Text.StringBuilder(String.Empty)
        Dim clinicalDiagnosisClinical As New System.Text.StringBuilder(String.Empty)

        doctorParagraphs = New Collection()

        Try

            If Not (String.IsNullOrEmpty(clinicalNotes) Or String.IsNullOrWhiteSpace(clinicalNotes)) Then
                patientsClinicalNotes.Append("Clinical Notes.".PadRight(padItemNo))
                patientsClinicalNotes.Append(ControlChars.NewLine)
                'primaryDeathCause.Append(ControlChars.NewLine)
                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, patientsClinicalNotes.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PatientsClinicalNotes()))
            End If

            If Not (String.IsNullOrEmpty(respiratory) Or String.IsNullOrWhiteSpace(respiratory)) Then
                respiratoryClinical.Append("Respiratory.".PadRight(padItemNo))
                respiratoryClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, respiratoryClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.respiratoryClinicalData()))
            End If

            If Not (String.IsNullOrEmpty(generalAppearance) Or String.IsNullOrWhiteSpace(generalAppearance)) Then
                generalAppearanceClinical.Append("General Appearance.".PadRight(padItemNo))
                generalAppearanceClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, generalAppearanceClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.generalAppearanceData()))
            End If

            If Not (String.IsNullOrEmpty(CVS) Or String.IsNullOrWhiteSpace(CVS)) Then
                CVSClinical.Append("CVS.".PadRight(padItemNo))
                CVSClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, CVSClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CVSClinicalData()))
            End If


            If Not (String.IsNullOrEmpty(abdomen) Or String.IsNullOrWhiteSpace(abdomen)) Then
                CVSClinical.Append("Abdomen.".PadRight(padItemNo))
                CVSClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, abdomenClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.abdomenClinicalData()))
            End If

            If Not (String.IsNullOrEmpty(CNS) Or String.IsNullOrWhiteSpace(CNS)) Then
                CVSClinical.Append("CNS.".PadRight(padItemNo))
                CVSClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, CNSClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CNSClinicalData()))
            End If

            If Not (String.IsNullOrEmpty(muscularSkeletal) Or String.IsNullOrWhiteSpace(muscularSkeletal)) Then
                muscularSkeletalClinical.Append("Muscular Skeletal.".PadRight(padItemNo))
                muscularSkeletalClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, muscularSkeletalClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.muscularSkeletalClinicalData()))
            End If

            If Not (String.IsNullOrEmpty(psychologicalStatus) Or String.IsNullOrWhiteSpace(psychologicalStatus)) Then
                psychologicalStatusClinical.Append("Psychological Status.".PadRight(padItemNo))
                psychologicalStatusClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, psychologicalStatusClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.psychologicalStatusClinicalData()))
            End If

            If Not (String.IsNullOrEmpty(clinicalDiagnosis) Or String.IsNullOrWhiteSpace(clinicalDiagnosis)) Then
                clinicalDiagnosisClinical.Append("Clinical Diagnosis.".PadRight(padItemNo))
                clinicalDiagnosisClinical.Append(ControlChars.NewLine)

                doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, clinicalDiagnosisClinical.ToString()))
                doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.clinicalDiagnosisClinicalData()))
            End If

            Dim signArea As New System.Text.StringBuilder(String.Empty)
            signArea.Append(ControlChars.NewLine)
            signArea.Append("Doctor's Sign:")
            signArea.Append(GetSpaces(1))
            signArea.Append(GetCharacters("."c, 20))
            signArea.Append(GetSpaces(3))
            signArea.Append(" Date:")
            signArea.Append(GetSpaces(1))
            signArea.Append(GetCharacters("."c, 20))
            doctorParagraphs.Add(New PrintParagraps(bodyNormalFont, signArea.ToString()))
            signArea.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''            
            'Reset pageNo so that one can print header data on other death forms without first closing the form
            pageNo = 0
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function PatientsClinicalNotes() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbClinicalNotes.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function respiratoryClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbRespiratory.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function generalAppearanceData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbGeneralAppearance.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CVSClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbCVS.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function muscularSkeletalClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbMuscularSkeletal.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function abdomenClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbAbdomen.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CNSClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbCNS.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function psychologicalStatusClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbPsychologicalStatus.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function clinicalDiagnosisClinicalData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbClinicalDiagnosis.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function



#End Region

    'Public Function TheatreData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

    '            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colICDTheatreCode)
    '                Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
    '                Dim theatreName As String = StringMayBeEnteredIn(cells, Me.colTheatreCode)
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)

    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedTheatreDisplay As List(Of String) = WrapText(theatreName, padService)
    '                If wrappedTheatreDisplay.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedTheatreDisplay.Count - 1
    '                        tableData.Append(FixDataLength(wrappedTheatreDisplay(pos).Trim(), padService))
    '                        If pos = wrappedTheatreDisplay.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(notes, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(theatreName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(notes, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function CardiologyData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

    '            If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

    '                line += 1

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim lineNo As String = (line).ToString()
    '                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colCardiologyExamFullName))
    '                Dim indication As String = StringMayBeEnteredIn(cells, Me.colCardiologyIndication)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedItemName As List(Of String) = WrapText(itemName, padService)
    '                If wrappedItemName.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedItemName.Count - 1
    '                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padService))
    '                        If pos = wrappedItemName.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(indication, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(itemName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(indication, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function DentalLaboratoryData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 1

    '            If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvDentalLab.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim dentalCode As String = StringMayBeEnteredIn(cells, Me.colDentalLabCode)
    '                Dim miniDentalLaboratory As EnumerableRowCollection(Of DataRow) = dentalLaboratory.AsEnumerable()
    '                Dim dentalName As String = (From data In miniDentalLaboratory
    '                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(dentalCode.ToUpper())
    '                                            Select data.Field(Of String)("DentalName")).First()
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalLabNotes)

    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedDentalLabDisplay As List(Of String) = WrapText(dentalName, padService)
    '                If wrappedDentalLabDisplay.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedDentalLabDisplay.Count - 1
    '                        tableData.Append(FixDataLength(wrappedDentalLabDisplay(pos).Trim(), padService))
    '                        If pos = wrappedDentalLabDisplay.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(notes, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(dentalName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(notes, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function DentalServicesData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1

    '            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim dentalCode As String = StringMayBeEnteredIn(cells, Me.colDentalCode)
    '                Dim miniDentalService As EnumerableRowCollection(Of DataRow) = dentalService.AsEnumerable()
    '                Dim dentalName As String = (From data In miniDentalService
    '                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(dentalCode.ToUpper())
    '                                            Select data.Field(Of String)("DentalName")).First()
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalNotes)

    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedDentalDisplay As List(Of String) = WrapText(dentalName, padService)
    '                If wrappedDentalDisplay.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedDentalDisplay.Count - 1
    '                        tableData.Append(FixDataLength(wrappedDentalDisplay(pos).Trim(), padService))
    '                        If pos = wrappedDentalDisplay.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(notes, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(dentalName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(notes, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function DiagnosisData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

    '            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim diseaseCode As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)
    '                Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedDiagnosisDisplay As List(Of String) = WrapText(diagnosisDisplay, padService)
    '                If wrappedDiagnosisDisplay.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedDiagnosisDisplay.Count - 1
    '                        tableData.Append(FixDataLength(wrappedDiagnosisDisplay(pos).Trim(), padService))
    '                        If pos = wrappedDiagnosisDisplay.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(notes, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(diagnosisDisplay, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(notes, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function LaboratoryData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer
    '        Dim padLabTest As Integer

    '        padLabTest = padService + padNotes

    '        For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

    '            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

    '                line += 1

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim lineNo As String = (line).ToString()
    '                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colTest))

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedItemName As List(Of String) = WrapText(itemName, padLabTest)

    '                If wrappedItemName.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedItemName.Count - 1
    '                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padLabTest))
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else : tableData.Append(FixDataLength(itemName, padLabTest))
    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function PrescriptionData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

    '            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()
    '                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrug)
    '                Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugFormula)
    '                Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)

    '                Dim fullDosage As String
    '                If String.IsNullOrEmpty(notes) Then
    '                    If duration.Trim().Equals("0") Then
    '                        fullDosage = dosage
    '                    ElseIf duration.Trim().Equals("1") Then
    '                        fullDosage = dosage + " for " + duration + " day"
    '                    Else : fullDosage = dosage + " for " + duration + " days"
    '                    End If
    '                Else
    '                    If duration.Trim().Equals("0") Then
    '                        fullDosage = dosage + " (" + notes + ")"
    '                    ElseIf duration.Trim().Equals("1") Then
    '                        fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
    '                    Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
    '                    End If
    '                End If

    '                tableData.Append(lineNo.PadRight(padLineNo))
    '                tableData.Append(itemName.PadRight(padService))

    '                Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padNotes)
    '                If wrappedfullDosage.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedfullDosage.Count - 1
    '                        tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padNotes))
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo + padService))
    '                    Next
    '                Else : tableData.Append(FixDataLength(fullDosage, padNotes))
    '                End If
    '                tableData.Append(ControlChars.NewLine)
    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function ProceduresData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

    '            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

    '                line += 1

    '                Dim lineNo As String = (line).ToString()

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim procedureCode As String = StringMayBeEnteredIn(cells, Me.colProcedureCode)
    '                Dim miniProcedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
    '                Dim procedureName As String = (From data In miniProcedures
    '                                               Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(procedureCode.ToUpper())
    '                                               Select data.Field(Of String)("ProcedureName")).First()
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)

    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedProceduresDisplay As List(Of String) = WrapText(procedureName, padService)
    '                If wrappedProceduresDisplay.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedProceduresDisplay.Count - 1
    '                        tableData.Append(FixDataLength(wrappedProceduresDisplay(pos).Trim(), padService))
    '                        If pos = wrappedProceduresDisplay.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(notes, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(procedureName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(notes, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function RadiologyData() As String

    '    Try

    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        Dim line As Integer

    '        For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

    '            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

    '                line += 1

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim lineNo As String = (line).ToString()
    '                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExamFullName))
    '                Dim indication As String = StringMayBeEnteredIn(cells, Me.colRadiologyIndication)

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                tableData.Append(lineNo.PadRight(padLineNo))

    '                Dim wrappedItemName As List(Of String) = WrapText(itemName, padService)
    '                If wrappedItemName.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedItemName.Count - 1
    '                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padService))
    '                        If pos = wrappedItemName.Count - 1 Then

    '                            Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
    '                            If wrappedNotes.Count > 1 Then
    '                                For count As Integer = 0 To wrappedNotes.Count - 1
    '                                    tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                                    tableData.Append(ControlChars.NewLine)
    '                                    tableData.Append(GetSpaces(padLineNo + padService))
    '                                Next
    '                            Else : tableData.Append(FixDataLength(indication, padNotes))
    '                            End If

    '                        End If
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padLineNo))
    '                    Next
    '                Else
    '                    tableData.Append(FixDataLength(itemName, padService))
    '                    Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
    '                    If wrappedNotes.Count > 1 Then
    '                        For count As Integer = 0 To wrappedNotes.Count - 1
    '                            tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
    '                            tableData.Append(ControlChars.NewLine)
    '                            tableData.Append(GetSpaces(padLineNo + padService))
    '                        Next
    '                    Else : tableData.Append(FixDataLength(indication, padNotes))
    '                    End If

    '                End If

    '                tableData.Append(ControlChars.NewLine)

    '            End If
    '        Next

    '        Return tableData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Public Function OrthopticsData() As String

        Try
            Dim textData As New System.Text.StringBuilder(String.Empty)
            Dim HeadPosture As String = StringMayBeEnteredIn(Me.stbHeadPosture)
            Dim Fixation As String = StringMayBeEnteredIn(Me.stbFixation)
            Dim LeftHirschberg As String = StringMayBeEnteredIn(Me.stbLeftHirschberg)
            Dim RightHirschberg As String = StringMayBeEnteredIn(Me.stbRightHirschberg)
            Dim RightEOM As String = StringMayBeEnteredIn(Me.stbRightEOM)
            Dim LeftEOM As String = StringMayBeEnteredIn(Me.stbLeftEOM)
            Dim CoverTestID As String = StringMayBeEnteredIn(Me.cboCoverTestID)
            Dim LeftAPCTGlasses As String = StringMayBeEnteredIn(Me.stbLeftAPCTGlasses)
            Dim RightAPCTGlasses As String = StringMayBeEnteredIn(Me.stbRightAPCTGlasses)
            Dim LeftAPCTWithOutGlasses As String = StringMayBeEnteredIn(Me.stbLeftAPCTWithOutGlasses)
            Dim RightAPCTWithOutGlasses As String = StringMayBeEnteredIn(Me.stbRightAPCTWithOutGlasses)
            Dim Correspondence As String = StringMayBeEnteredIn(Me.stbCorrespondence)
            Dim PrismAdaptation As String = StringMayBeEnteredIn(Me.stbPrismAdaptation)
            Dim FusionConvergence As String = StringMayBeEnteredIn(Me.stbFusionConvergence)
            Dim FusionDivergence As String = StringMayBeEnteredIn(Me.stbFusionDivergence)
            Dim FusionRange As String = StringMayBeEnteredIn(Me.stbFusionRange)
            Dim NearPointOfAccommodation As String = StringMayBeEnteredIn(Me.stbNearPointOfAccommodation)
            Dim NearPointOfConvergence As String = StringMayBeEnteredIn(Me.stbNearPointOfConvergence)
            Dim OrthopticsNotes As String = StringMayBeEnteredIn(Me.stbOrthopticsNotes)

            If Not String.IsNullOrEmpty(HeadPosture) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Head Posture: " + ControlChars.NewLine + HeadPosture)
                Else : textData.Append("Head Posture: " + ControlChars.NewLine + HeadPosture)
                End If
            End If

            If Not String.IsNullOrEmpty(Fixation) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Fixation: " + ControlChars.NewLine + Fixation)
                Else : textData.Append("Fixation: " + ControlChars.NewLine + Fixation)
                End If
            End If

            If Not String.IsNullOrEmpty(RightHirschberg) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Right Hirschberg: " + ControlChars.NewLine + RightHirschberg)
                Else : textData.Append("Right Hirschberg: " + ControlChars.NewLine + RightHirschberg)
                End If
            End If

            If Not String.IsNullOrEmpty(LeftHirschberg) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Left Hirschberg: " + ControlChars.NewLine + LeftHirschberg)
                Else : textData.Append("Left Hirschberg: " + ControlChars.NewLine + LeftHirschberg)
                End If
            End If



            If Not String.IsNullOrEmpty(RightEOM) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Right EOM: " + ControlChars.NewLine + RightEOM)
                Else : textData.Append("Right EOM: " + ControlChars.NewLine + RightEOM)
                End If
            End If

            If Not String.IsNullOrEmpty(LeftEOM) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Left EOM: " + ControlChars.NewLine + LeftEOM)
                Else : textData.Append("Left EOM: " + ControlChars.NewLine + LeftEOM)
                End If
            End If

            If Not String.IsNullOrEmpty(CoverTestID) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Cover Test: " + ControlChars.NewLine + CoverTestID)
                Else : textData.Append("Cover Test: " + ControlChars.NewLine + CoverTestID)
                End If
            End If

            If Not String.IsNullOrEmpty(RightAPCTGlasses) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Alternate Prism Cover Test With Glasses (Right): " + ControlChars.NewLine + RightAPCTGlasses)
                Else : textData.Append("Alternate Prism Cover Test With Glasses (Right): " + ControlChars.NewLine + RightAPCTGlasses)
                End If
            End If

            If Not String.IsNullOrEmpty(LeftAPCTGlasses) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Alternate Prism Cover Test With Glasses (Left): " + ControlChars.NewLine + LeftAPCTGlasses)
                Else : textData.Append("Alternate Prism Cover Test With Glasses (Left): " + ControlChars.NewLine + LeftAPCTGlasses)
                End If
            End If

            If Not String.IsNullOrEmpty(RightAPCTWithOutGlasses) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Alternate Prism Cover Test Without Glasses (Right): " + ControlChars.NewLine + RightAPCTWithOutGlasses)
                Else : textData.Append("Alternate Prism Cover Test Without Glasses (Right): " + ControlChars.NewLine + RightAPCTWithOutGlasses)
                End If
            End If

            If Not String.IsNullOrEmpty(LeftAPCTWithOutGlasses) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Alternate Prism Cover Test Without Glasses (Left): " + ControlChars.NewLine + LeftAPCTWithOutGlasses)
                Else : textData.Append("Alternate Prism Cover Test Without Glasses (Left): " + ControlChars.NewLine + LeftAPCTWithOutGlasses)
                End If
            End If

            If Not String.IsNullOrEmpty(Correspondence) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Correspondence: " + ControlChars.NewLine + Correspondence)
                Else : textData.Append("Correspondence: " + ControlChars.NewLine + Correspondence)
                End If
            End If

            If Not String.IsNullOrEmpty(PrismAdaptation) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Prism Adaptation: " + ControlChars.NewLine + PrismAdaptation)
                Else : textData.Append("Prism Adaptation: " + ControlChars.NewLine + PrismAdaptation)
                End If
            End If

            If Not String.IsNullOrEmpty(FusionConvergence) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Fusion Convergence: " + ControlChars.NewLine + FusionConvergence)
                Else : textData.Append("Fusion Convergence: " + ControlChars.NewLine + FusionConvergence)
                End If
            End If

            If Not String.IsNullOrEmpty(FusionDivergence) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Fusion Divergence: " + ControlChars.NewLine + FusionDivergence)
                Else : textData.Append("Fusion Divergence: " + ControlChars.NewLine + FusionDivergence)
                End If
            End If

            If Not String.IsNullOrEmpty(FusionRange) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Fusion Range: " + ControlChars.NewLine + FusionRange)
                Else : textData.Append("Fusion Range: " + ControlChars.NewLine + FusionRange)
                End If
            End If

            If Not String.IsNullOrEmpty(NearPointOfAccommodation) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Near Point Of Accommodation: " + ControlChars.NewLine + NearPointOfAccommodation)
                Else : textData.Append("Near Point Of Accommodation: " + ControlChars.NewLine + NearPointOfAccommodation)
                End If
            End If

            If Not String.IsNullOrEmpty(NearPointOfConvergence) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Near Point Of Convergence: " + ControlChars.NewLine + NearPointOfConvergence)
                Else : textData.Append("Near Point Of Convergence: " + ControlChars.NewLine + NearPointOfConvergence)
                End If
            End If

            If Not String.IsNullOrEmpty(OrthopticsNotes) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Orthoptics Notes: " + ControlChars.NewLine + OrthopticsNotes)
                Else : textData.Append("Orthoptics Notes: " + ControlChars.NewLine + OrthopticsNotes)
                End If
            End If


            If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

            Return textData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Medical Report - Printing "

    Private Sub btnPrintPreviewMedicalReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreviewMedicalReport.Click
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Medical Report Preview (Dr)")
        Try

            Me.Cursor = Cursors.WaitCursor

            ''Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetMedicalReportPrintData()
            SavePrintDetails(patientNo, visitNo, printdesc, docTypeID.MedicalReport)
            With dlgPrintPreview
                .Document = docMedicalReport
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintMedicalReport()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetMedicalReportPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docMedicalReport
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docMedicalReport.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docMedicalReport_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docMedicalReport.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top
            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Medical Report".ToUpper()
            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim roundDate As String = StringMayBeEnteredIn(Me.stbRoundDateTime)
            Dim roundNo As String = StringMayBeEnteredIn(Me.cboRoundNo)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = SubstringLeft(Me.cboStaffNo.Text)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Round No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(roundNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Round Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(roundDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If medicalReportParagraphs Is Nothing Then Return

                Do While medicalReportParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(medicalReportParagraphs(1), PrintParagraps)
                    medicalReportParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        medicalReportParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (medicalReportParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetMedicalReportPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        medicalReportParagraphs = New Collection()

        Try

            '''''''''''''''TRIAGE''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim triageTitle As New System.Text.StringBuilder(String.Empty)
            triageTitle.Append(ControlChars.NewLine)
            triageTitle.Append("TRIAGE: ".ToUpper())
            triageTitle.Append(ControlChars.NewLine)
            triageTitle.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, triageTitle.ToString()))
            medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TriageData()))

            '''''''''''''''CLINICAL FINDINGS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim clinicalFindingsTitle As New System.Text.StringBuilder(String.Empty)
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            clinicalFindingsTitle.Append("CLINICAL FINDINGS: ".ToUpper())
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            clinicalFindingsTitle.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, clinicalFindingsTitle.ToString()))
            medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ClinicalFindingsData()))

            ' '''''''''''''''VISION ASSESSMENT''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim vaTitle As New System.Text.StringBuilder(String.Empty)
            'vaTitle.Append(ControlChars.NewLine)
            'vaTitle.Append("VISION ASSESSMENT: ".ToUpper())
            'vaTitle.Append(ControlChars.NewLine)
            'vaTitle.Append(ControlChars.NewLine)
            'medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, vaTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.FirstVisualAssessmentData()))
            ' '''''''''''''''VISION ASSESSMENT TWO''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim SecondvaTitle As New System.Text.StringBuilder(String.Empty)
            'SecondvaTitle.Append(ControlChars.NewLine)
            'SecondvaTitle.Append("VISION ASSESSMENT (II): ".ToUpper())
            'SecondvaTitle.Append(ControlChars.NewLine)
            'SecondvaTitle.Append(ControlChars.NewLine)
            'medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, SecondvaTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.SecondVisualAssessmentData()))
            ' '''''''''''''''EYE ASSESSMENT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim eyeassessmentTitle As New System.Text.StringBuilder(String.Empty)
            'eyeassessmentTitle.Append(ControlChars.NewLine)
            'eyeassessmentTitle.Append("EYE ASSESSMENT: ".ToUpper())
            'eyeassessmentTitle.Append(ControlChars.NewLine)
            'eyeassessmentTitle.Append(ControlChars.NewLine)
            'medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, eyeassessmentTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.EyeAssessmentData()))

            ' '''''''''''''''ORTHOPTICS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim orthopticsTitle As New System.Text.StringBuilder(String.Empty)
            'orthopticsTitle.Append(ControlChars.NewLine)
            'orthopticsTitle.Append("ORTHOPTICS: ".ToUpper())
            'orthopticsTitle.Append(ControlChars.NewLine)
            'orthopticsTitle.Append(ControlChars.NewLine)
            'medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, orthopticsTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OrthopticsData()))

            ' '''''''''''''''REFRACTION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim refractionTitle As New System.Text.StringBuilder(String.Empty)
            'refractionTitle.Append(ControlChars.NewLine)
            'refractionTitle.Append("REFRACTION: ".ToUpper())
            'refractionTitle.Append(ControlChars.NewLine)
            'refractionTitle.Append(ControlChars.NewLine)
            'medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, refractionTitle.ToString()))
            'medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RefractionData()))

            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append(ControlChars.NewLine)

            Dim tableDiagnosis As New System.Text.StringBuilder(String.Empty)
            tableDiagnosis.Append("No: ".PadRight(padLineNo))
            tableDiagnosis.Append("Diagnosis: ".PadRight(padService))
            tableDiagnosis.Append("Notes: ".PadRight(padNotes))
            tableDiagnosis.Append(ControlChars.NewLine)
            tableDiagnosis.Append(ControlChars.NewLine)

            medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))
            If Me.dgvDiagnosis.RowCount > 1 Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDiagnosis.ToString()))
            End If
            medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))

            ''''''''''''''''Laboratory'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim laboratoryTitle As New System.Text.StringBuilder(String.Empty)
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append("LABORATORY: ".ToUpper())
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append(ControlChars.NewLine)

            Dim tableLaboratory As New System.Text.StringBuilder(String.Empty)
            tableLaboratory.Append("No: ".PadRight(padLineNo))
            tableLaboratory.Append("Test Name: ".PadRight(padService + padNotes))
            tableLaboratory.Append(ControlChars.NewLine)
            tableLaboratory.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.LaboratoryData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, laboratoryTitle.ToString()))
                If Me.dgvLabTests.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableLaboratory.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.LaboratoryData()))
            End If

            ''''''''''''''''Cardiology'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim CardiologyTitle As New System.Text.StringBuilder(String.Empty)
            CardiologyTitle.Append(ControlChars.NewLine)
            CardiologyTitle.Append("Cardiology: ".ToUpper())
            CardiologyTitle.Append(ControlChars.NewLine)
            CardiologyTitle.Append(ControlChars.NewLine)

            Dim tableCardiology As New System.Text.StringBuilder(String.Empty)
            tableCardiology.Append("No: ".PadRight(padLineNo))
            tableCardiology.Append("Cardiology Examination: ".PadRight(padService))
            tableCardiology.Append("Indication: ".PadRight(padNotes))
            tableCardiology.Append(ControlChars.NewLine)
            tableCardiology.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.CardiologyData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, CardiologyTitle.ToString()))
                If Me.dgvCardiology.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableCardiology.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CardiologyData()))
            End If

            ''''''''''''''''Radiology'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radiologyTitle As New System.Text.StringBuilder(String.Empty)
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append("RADIOLOGY: ".ToUpper())
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append(ControlChars.NewLine)

            Dim tableRadiology As New System.Text.StringBuilder(String.Empty)
            tableRadiology.Append("No: ".PadRight(padLineNo))
            tableRadiology.Append("Radiology Examination: ".PadRight(padService))
            tableRadiology.Append("Indication: ".PadRight(padNotes))
            tableRadiology.Append(ControlChars.NewLine)
            tableRadiology.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.RadiologyData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, radiologyTitle.ToString()))
                If Me.dgvRadiology.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableRadiology.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RadiologyData()))
            End If

            ''''''''''''''''Prescription'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("Prescription: ".ToUpper())
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append(ControlChars.NewLine)

            Dim tablePrescription As New System.Text.StringBuilder(String.Empty)
            tablePrescription.Append("No: ".PadRight(padLineNo))
            tablePrescription.Append("Drug Name: ".PadRight(padService))
            tablePrescription.Append("Dosage: ".PadRight(padNotes))
            tablePrescription.Append(ControlChars.NewLine)
            tablePrescription.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.PrescriptionData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionTitle.ToString()))
                If Me.dgvPrescription.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tablePrescription.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionData()))
            End If

            ''''''''''''''''Procedures'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proceduresTitle As New System.Text.StringBuilder(String.Empty)
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append("Procedures: ".ToUpper())
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append(ControlChars.NewLine)

            Dim tableProcedures As New System.Text.StringBuilder(String.Empty)
            tableProcedures.Append("No: ".PadRight(padLineNo))
            tableProcedures.Append("Procedure Name: ".PadRight(padService))
            tableProcedures.Append("Notes: ".PadRight(padNotes))
            tableProcedures.Append(ControlChars.NewLine)
            tableProcedures.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.ProceduresData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, proceduresTitle.ToString()))
                If Me.dgvProcedures.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableProcedures.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ProceduresData()))
            End If

            ''''''''''''''''Theatre'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreTitle As New System.Text.StringBuilder(String.Empty)
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append("Theatre: ".ToUpper())
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append(ControlChars.NewLine)

            Dim tableTheatre As New System.Text.StringBuilder(String.Empty)
            tableTheatre.Append("No: ".PadRight(padLineNo))
            tableTheatre.Append("Theatre Name: ".PadRight(padService))
            tableTheatre.Append("Notes: ".PadRight(padNotes))
            tableTheatre.Append(ControlChars.NewLine)
            tableTheatre.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.TheatreData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, theatreTitle.ToString()))
                If Me.dgvTheatre.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableTheatre.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TheatreData()))
            End If

            ''''''''''''''''Dental Services'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dentalTitle As New System.Text.StringBuilder(String.Empty)
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append("Dental Services: ".ToUpper())
            dentalTitle.Append(ControlChars.NewLine)
            dentalTitle.Append(ControlChars.NewLine)

            Dim tableDental As New System.Text.StringBuilder(String.Empty)
            tableDental.Append("No: ".PadRight(padLineNo))
            tableDental.Append("Dental Service: ".PadRight(padService))
            tableDental.Append("Notes: ".PadRight(padNotes))
            tableDental.Append(ControlChars.NewLine)
            tableDental.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.DentalServicesData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, dentalTitle.ToString()))
                If Me.dgvDental.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDental.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalServicesData()))
            End If

            ''''''''''''''''Dental Laboratory'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dentalLabTitle As New System.Text.StringBuilder(String.Empty)
            dentalLabTitle.Append(ControlChars.NewLine)
            dentalLabTitle.Append("Dental Laboratory: ".ToUpper())
            dentalLabTitle.Append(ControlChars.NewLine)
            dentalLabTitle.Append(ControlChars.NewLine)

            Dim tableDentalLab As New System.Text.StringBuilder(String.Empty)
            tableDentalLab.Append("No: ".PadRight(padLineNo))
            tableDentalLab.Append("Dental Lab: ".PadRight(padService))
            tableDentalLab.Append("Notes: ".PadRight(padNotes))
            tableDentalLab.Append(ControlChars.NewLine)
            tableDentalLab.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.DentalLaboratoryData()) Then
                medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, dentalLabTitle.ToString()))
                If Me.dgvDentalLab.RowCount > 1 Then
                    medicalReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDentalLab.ToString()))
                End If
                medicalReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalLaboratoryData()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Doctor's Sign:   " + GetCharacters("."c, 20))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 20))
            doctorSignData.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            medicalReportParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function TriageData() As String

        Try

            Dim textData As New System.Text.StringBuilder(String.Empty)

            Dim weight As String = StringMayBeEnteredIn(Me.nbxWeight)
            Dim temperature As String = StringMayBeEnteredIn(Me.nbxTemperature)
            Dim height As String = StringMayBeEnteredIn(Me.nbxHeight)
            Dim pulse As String = StringMayBeEnteredIn(Me.nbxPulse)
            Dim bloodPressure As String = StringMayBeEnteredIn(Me.stbBloodPressure)
            Dim headCircum As String = StringMayBeEnteredIn(Me.nbxHeadCircum)
            Dim bodySurfaceArea As String = StringMayBeEnteredIn(Me.nbxBodySurfaceArea)
            Dim notes As String = StringMayBeEnteredIn(Me.stbClinicalNotes)

            If Not String.IsNullOrEmpty(weight) Then
                If textData.Length > 1 Then
                    textData.Append(", Weight: " + weight + " Kg")
                Else : textData.Append("Weight: " + weight + " Kg")
                End If
            End If

            If Not String.IsNullOrEmpty(temperature) Then
                If textData.Length > 1 Then
                    textData.Append(", Temperature: " + temperature + " Celc.")
                Else : textData.Append("Temperature: " + temperature + " Celc.")
                End If
            End If

            If Not String.IsNullOrEmpty(height) Then
                If textData.Length > 1 Then
                    textData.Append(", Height: " + height + " cm")
                Else : textData.Append("Height: " + height + " cm")
                End If
            End If

            

            If Not String.IsNullOrEmpty(pulse) Then
                If textData.Length > 1 Then
                    textData.Append(", Pulse: " + pulse + " B/min")
                Else : textData.Append("Pulse: " + pulse + " B/min")
                End If
            End If

            If Not String.IsNullOrEmpty(bloodPressure) Then
                If textData.Length > 1 Then
                    textData.Append(", Blood Pressure: " + bloodPressure + " mmHg")
                Else : textData.Append("Blood Pressure: " + bloodPressure + " mmHg")
                End If
            End If

            If Not String.IsNullOrEmpty(headCircum) Then
                If textData.Length > 1 Then
                    textData.Append(", Head Circum: " + headCircum + " cm")
                Else : textData.Append("Head Circum: " + headCircum + " cm")
                End If
            End If

            If Not String.IsNullOrEmpty(bodySurfaceArea) Then
                If textData.Length > 1 Then
                    textData.Append(", Body Surface Area: " + bodySurfaceArea + " cm")
                Else : textData.Append("Body Surface Area: " + bodySurfaceArea + " cm")
                End If
            End If

            If Not String.IsNullOrEmpty(notes) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Clinical Notes: " + ControlChars.NewLine + notes)
                Else : textData.Append("Clinical Notes: " + ControlChars.NewLine + notes)
                End If
            End If

            If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

            Return textData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Public Function FirstVisualAssessmentData() As String

    '    Try
    '        Dim textData As New System.Text.StringBuilder(String.Empty)
    '        Dim EyeTestID As String = StringMayBeEnteredIn(Me.stbEyeTest)
    '        Dim VisualAcuityRightID As String = StringMayBeEnteredIn(Me.StbVisualAcuityRight)
    '        Dim VisualAcuityRightExtID As String = StringMayBeEnteredIn(Me.StbVisualAcuityRightExt)
    '        Dim VisualAcuityLeftID As String = StringMayBeEnteredIn(Me.StbVisualAcuityLeft)
    '        Dim VisualAcuityLeftExtID As String = StringMayBeEnteredIn(Me.StbVisualAcuityLeftExt)
    '        Dim PreferentialLookingRightID As String = StringMayBeEnteredIn(Me.StbPreferentialLookingRight)
    '        Dim PreferentialLookingLeftID As String = StringMayBeEnteredIn(Me.StbPreferentialLookingLeft)
    '        Dim VANotes As String = StringMayBeEnteredIn(Me.StbEyeNotes)

    '        If Not String.IsNullOrEmpty(EyeTestID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", EyeTest: " + EyeTestID + "")
    '            Else : textData.Append("EyeTest: " + EyeTestID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityRightID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Right: " + VisualAcuityRightID + "")
    '            Else : textData.Append("Visual Acuity Right: " + VisualAcuityRightID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityRightExtID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Right Ext: " + VisualAcuityRightExtID + "")
    '            Else : textData.Append("Visual Acuity Right Ext: " + VisualAcuityRightExtID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityLeftID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Left: " + VisualAcuityLeftID + "")
    '            Else : textData.Append("Visual Acuity Left: " + VisualAcuityLeftID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityLeftExtID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Left Ext: " + VisualAcuityLeftExtID + "")
    '            Else : textData.Append("Visual Acuity Left Ext: " + VisualAcuityLeftExtID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(PreferentialLookingRightID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Preferential Looking Right: " + PreferentialLookingRightID + "")
    '            Else : textData.Append("Preferential Looking Right: " + PreferentialLookingRightID + " ")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(PreferentialLookingLeftID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Preferential Looking Left: " + PreferentialLookingLeftID + "")
    '            Else : textData.Append("Preferential Looking Left: " + PreferentialLookingLeftID + "")
    '            End If
    '        End If


    '        If Not String.IsNullOrEmpty(VANotes) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", VA Notes: " + VANotes + "")
    '            Else : textData.Append("VA Notes: " + VANotes + "")
    '            End If
    '        End If

    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function SecondVisualAssessmentData() As String

    '    Try
    '        Dim textData As New System.Text.StringBuilder(String.Empty)
    '        Dim EyeTestID As String = StringMayBeEnteredIn(Me.stbEyeTestEXT)
    '        Dim VisualAcuityRightID As String = StringMayBeEnteredIn(Me.StbVisualAcuityRightExEXTID)
    '        Dim VisualAcuityRightExtID As String = StringMayBeEnteredIn(Me.StbVisualAcuityRightExtEXTID)
    '        Dim VisualAcuityLeftID As String = StringMayBeEnteredIn(Me.StbVisualAcuityLeftExEXTID)
    '        Dim VisualAcuityLeftExtID As String = StringMayBeEnteredIn(Me.StbVisualAcuityLeftExtEXTID)
    '        Dim PreferentialLookingRightID As String = StringMayBeEnteredIn(Me.StbPreferentialLookingRightEXTID)
    '        Dim PreferentialLookingLeftID As String = StringMayBeEnteredIn(Me.StbPreferentialLookingLeftEXTID)
    '        Dim VANotes As String = StringMayBeEnteredIn(Me.stbNotesEXT)

    '        If Not String.IsNullOrEmpty(EyeTestID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", EyeTest: " + EyeTestID + "")
    '            Else : textData.Append("EyeTest: " + EyeTestID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityRightID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Right: " + VisualAcuityRightID + "")
    '            Else : textData.Append("Visual Acuity Right: " + VisualAcuityRightID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityRightExtID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Right Ext: " + VisualAcuityRightExtID + "")
    '            Else : textData.Append("Visual Acuity Right Ext: " + VisualAcuityRightExtID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityLeftID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Left: " + VisualAcuityLeftID + "")
    '            Else : textData.Append("Visual Acuity Left: " + VisualAcuityLeftID + "")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(VisualAcuityLeftExtID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Visual Acuity Left Ext: " + VisualAcuityLeftExtID + "")
    '            Else : textData.Append("Visual Acuity Left Ext: " + VisualAcuityLeftExtID + "")
    '            End If
    '        End If



    '        If Not String.IsNullOrEmpty(PreferentialLookingRightID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Preferential Looking Right: " + PreferentialLookingRightID + "")
    '            Else : textData.Append("Preferential Looking Right: " + PreferentialLookingRightID + " ")
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(PreferentialLookingLeftID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", Preferential Looking Left: " + PreferentialLookingLeftID + "")
    '            Else : textData.Append("Preferential Looking Left: " + PreferentialLookingLeftID + "")
    '            End If
    '        End If


    '        If Not String.IsNullOrEmpty(VANotes) Then
    '            If textData.Length > 1 Then
    '                textData.Append(", VA Notes: " + VANotes + "")
    '            Else : textData.Append("VA Notes: " + VANotes + "")
    '            End If
    '        End If

    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Public Function ClinicalFindingsData() As String

        Try

            Dim textData As New System.Text.StringBuilder(String.Empty)
            Dim clinicalNotes As String = StringMayBeEnteredIn(Me.stbClinicalNotes)
            Dim generalAppearance As String = StringMayBeEnteredIn(Me.stbGeneralAppearance)
            Dim respiratory As String = StringMayBeEnteredIn(Me.stbRespiratory)
            Dim cVS As String = StringMayBeEnteredIn(Me.stbCVS)
            Dim abdomen As String = StringMayBeEnteredIn(Me.stbAbdomen)
            Dim cNS As String = StringMayBeEnteredIn(Me.stbCNS)
            Dim muscularSkeletal As String = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
            Dim psychologicalStatus As String = StringMayBeEnteredIn(Me.stbPsychologicalStatus)


            If Not String.IsNullOrEmpty(clinicalNotes) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
                Else : textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
                End If
            End If


            If Not String.IsNullOrEmpty(generalAppearance) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("General Appearance: " + ControlChars.NewLine + generalAppearance)
                Else : textData.Append("General Appearance: " + ControlChars.NewLine + generalAppearance)
                End If
            End If

            If Not String.IsNullOrEmpty(respiratory) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Respiratory: " + ControlChars.NewLine + respiratory)
                Else : textData.Append("Respiratory: " + ControlChars.NewLine + respiratory)
                End If
            End If

            If Not String.IsNullOrEmpty(cVS) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("CVS: " + ControlChars.NewLine + cVS)
                Else : textData.Append("CVS: " + ControlChars.NewLine + cVS)
                End If
            End If

            If Not String.IsNullOrEmpty(abdomen) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Abdomen & GUT: " + ControlChars.NewLine + abdomen)
                Else : textData.Append("Abdomen & GUT: " + ControlChars.NewLine + abdomen)
                End If
            End If

            If Not String.IsNullOrEmpty(cNS) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("CNS: " + ControlChars.NewLine + cNS)
                Else : textData.Append("CNS: " + ControlChars.NewLine + cNS)
                End If
            End If

            If Not String.IsNullOrEmpty(muscularSkeletal) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Muscular Skeletal: " + ControlChars.NewLine + muscularSkeletal)
                Else : textData.Append("Muscular Skeletal: " + ControlChars.NewLine + muscularSkeletal)
                End If
            End If

            If Not String.IsNullOrEmpty(psychologicalStatus) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Psychological Status: " + ControlChars.NewLine + psychologicalStatus)
                Else : textData.Append("Psychological Status: " + ControlChars.NewLine + psychologicalStatus)
                End If
            End If


            If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

            Return textData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Public Function EyeAssessmentData() As String

    '    Try

    '        Dim textData As New System.Text.StringBuilder(String.Empty)
    '        Dim LeftPupil As String = StringMayBeEnteredIn(Me.stbLeftPupil)
    '        Dim RightPupil As String = StringMayBeEnteredIn(Me.stbRightPupil)
    '        Dim LeftLidMargin As String = StringMayBeEnteredIn(Me.stbLeftLidMargin)
    '        Dim RightLidMargin As String = StringMayBeEnteredIn(Me.stbRightLidMargin)
    '        Dim LeftConjuctiva As String = StringMayBeEnteredIn(Me.stbLeftConjuctiva)
    '        Dim RightConjuctiva As String = StringMayBeEnteredIn(Me.stbRightConjuctiva)
    '        Dim LeftBulbarConjuctiva As String = StringMayBeEnteredIn(Me.stbLeftBulbarConjuctiva)
    '        Dim RightBulbarConjuctiva As String = StringMayBeEnteredIn(Me.stbRightBulbarConjuctiva)
    '        Dim LeftCentralCornea As String = StringMayBeEnteredIn(Me.stbLeftCentralCornea)
    '        Dim RightCentralCornea As String = StringMayBeEnteredIn(Me.stbRightCentralCornea)
    '        Dim LeftVerticalCornea As String = StringMayBeEnteredIn(Me.stbLeftVerticalCornea)
    '        Dim RightVerticalCornea As String = StringMayBeEnteredIn(Me.stbRightVerticalCornea)
    '        Dim LeftAnteriorChamber As String = StringMayBeEnteredIn(Me.stbLeftAnteriorChamber)
    '        Dim RightAnteriorChamber As String = StringMayBeEnteredIn(Me.stbRightAnteriorChamber)
    '        Dim LeftIrish As String = StringMayBeEnteredIn(Me.stbLeftIrish)
    '        Dim RightIrish As String = StringMayBeEnteredIn(Me.stbRightIrish)
    '        Dim LeftAnteriorChamberAngle As String = StringMayBeEnteredIn(Me.stbLeftAnteriorChamberAngle)
    '        Dim RightAnteriorChamberAngle As String = StringMayBeEnteredIn(Me.stbRightAnteriorChamberAngle)
    '        Dim LeftRetina As String = StringMayBeEnteredIn(Me.stbLeftRetina)
    '        Dim RightRetina As String = StringMayBeEnteredIn(Me.stbRightRetina)
    '        Dim LeftMacular As String = StringMayBeEnteredIn(Me.stbLeftMacular)
    '        Dim RightMacular As String = StringMayBeEnteredIn(Me.stbRightMacular)
    '        Dim LeftOpticDisc As String = StringMayBeEnteredIn(Me.stbLeftOpticDisc)
    '        Dim RightOpticDisc As String = StringMayBeEnteredIn(Me.stbRightOpticDisc)
    '        Dim leftIOP As String = StringMayBeEnteredIn(Me.stbLeftIOP)
    '        Dim rightIOP As String = StringMayBeEnteredIn(Me.stbRightIOP)
    '        Dim LeftVitreous As String = StringMayBeEnteredIn(Me.stbLeftVitreous)
    '        Dim RightVitreous As String = StringMayBeEnteredIn(Me.stbRightVitreous)
    '        Dim LeftLense As String = StringMayBeEnteredIn(Me.stbLeftLense)
    '        Dim RightLense As String = StringMayBeEnteredIn(Me.stbRightLense)
    '        Dim EyeNotes As String = StringMayBeEnteredIn(Me.StbEyeAssessmentNotes)
    '        Dim LeftEyeBall As String = StringMayBeEnteredIn(Me.stbLeftEyeBall)
    '        Dim RightEyeBall As String = StringMayBeEnteredIn(Me.stbRightEyeBall)
    '        Dim LeftOrbit As String = StringMayBeEnteredIn(Me.stbLeftOrbit)
    '        Dim RightOrbit As String = StringMayBeEnteredIn(Me.stbRightOrbit)

    '        If Not String.IsNullOrEmpty(RightPupil) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Pupil: " + ControlChars.NewLine + RightPupil)
    '            Else : textData.Append("Right Pupil: " + ControlChars.NewLine + RightPupil)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftPupil) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Pupil: " + ControlChars.NewLine + LeftPupil)
    '            Else : textData.Append("Left Pupil: " + ControlChars.NewLine + LeftPupil)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightLidMargin) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Lid Margin: " + ControlChars.NewLine + RightLidMargin)
    '            Else : textData.Append("Right Lid Margin: " + ControlChars.NewLine + RightLidMargin)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftLidMargin) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Lid Margin: " + ControlChars.NewLine + LeftLidMargin)
    '            Else : textData.Append("Left Lid Margin: " + ControlChars.NewLine + LeftLidMargin)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightConjuctiva) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Conjuctiva: " + ControlChars.NewLine + RightConjuctiva)
    '            Else : textData.Append("Right Conjuctiva: " + ControlChars.NewLine + RightConjuctiva)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftConjuctiva) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Conjuctiva: " + ControlChars.NewLine + LeftConjuctiva)
    '            Else : textData.Append("Left Conjuctiva: " + ControlChars.NewLine + LeftConjuctiva)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightBulbarConjuctiva) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Bulbar Conjuctiva: " + ControlChars.NewLine + RightBulbarConjuctiva)
    '            Else : textData.Append("Right Bulbar Conjuctiva: " + ControlChars.NewLine + RightBulbarConjuctiva)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftBulbarConjuctiva) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Bulbar Conjuctiva: " + ControlChars.NewLine + LeftBulbarConjuctiva)
    '            Else : textData.Append("Left Bulbar Conjuctiva: " + ControlChars.NewLine + LeftBulbarConjuctiva)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightCentralCornea) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Central Cornea: " + ControlChars.NewLine + RightCentralCornea)
    '            Else : textData.Append("Right Central Cornea: " + ControlChars.NewLine + RightCentralCornea)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftCentralCornea) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Central Cornea: " + ControlChars.NewLine + LeftCentralCornea)
    '            Else : textData.Append("Left Central Cornea: " + ControlChars.NewLine + LeftCentralCornea)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightVerticalCornea) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Vertical Cornea: " + ControlChars.NewLine + RightVerticalCornea)
    '            Else : textData.Append("Right Vertical Cornea: " + ControlChars.NewLine + RightVerticalCornea)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftVerticalCornea) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Vertical Cornea: " + ControlChars.NewLine + LeftVerticalCornea)
    '            Else : textData.Append("Left Vertical Cornea: " + ControlChars.NewLine + LeftVerticalCornea)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightIrish) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Irish: " + ControlChars.NewLine + RightIrish)
    '            Else : textData.Append("Right Irish: " + ControlChars.NewLine + RightIrish)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftIrish) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Irish: " + ControlChars.NewLine + LeftIrish)
    '            Else : textData.Append("Left Irish: " + ControlChars.NewLine + LeftIrish)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightAnteriorChamberAngle) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Anterior Chamber Angle: " + ControlChars.NewLine + RightAnteriorChamberAngle)
    '            Else : textData.Append("Right Anterior Chamber Angle: " + ControlChars.NewLine + RightAnteriorChamberAngle)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftAnteriorChamberAngle) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Anterior Chamber Angle: " + ControlChars.NewLine + LeftAnteriorChamberAngle)
    '            Else : textData.Append("Left Anterior Chamber Angle: " + ControlChars.NewLine + LeftAnteriorChamberAngle)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightRetina) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Retina: " + ControlChars.NewLine + RightRetina)
    '            Else : textData.Append("Right Retina: " + ControlChars.NewLine + RightRetina)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftRetina) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Retina: " + ControlChars.NewLine + LeftRetina)
    '            Else : textData.Append("Left Retina: " + ControlChars.NewLine + LeftRetina)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightMacular) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Macular: " + ControlChars.NewLine + RightMacular)
    '            Else : textData.Append("Right Macular: " + ControlChars.NewLine + RightMacular)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftMacular) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Macular: " + ControlChars.NewLine + LeftMacular)
    '            Else : textData.Append("Left Macular: " + ControlChars.NewLine + LeftMacular)
    '            End If
    '        End If

    '        ''''''
    '        If Not String.IsNullOrEmpty(RightOpticDisc) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Optic Disc: " + ControlChars.NewLine + RightOpticDisc)
    '            Else : textData.Append("Right Optic Disc: " + ControlChars.NewLine + RightOpticDisc)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftOpticDisc) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Optic Disc: " + ControlChars.NewLine + LeftOpticDisc)
    '            Else : textData.Append("Left Optic Disc: " + ControlChars.NewLine + LeftOpticDisc)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(rightIOP) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right IOP: " + ControlChars.NewLine + rightIOP)
    '            Else : textData.Append("Right IOP: " + ControlChars.NewLine + rightIOP)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(leftIOP) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left IOP: " + ControlChars.NewLine + leftIOP)
    '            Else : textData.Append("Left IOP: " + ControlChars.NewLine + leftIOP)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightVitreous) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Vitreous: " + ControlChars.NewLine + RightVitreous)
    '            Else : textData.Append("Right Vitreous: " + ControlChars.NewLine + RightVitreous)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftVitreous) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Vitreous: " + ControlChars.NewLine + LeftVitreous)
    '            Else : textData.Append("Left Vitreous: " + ControlChars.NewLine + LeftVitreous)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightLense) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Lense: " + ControlChars.NewLine + RightLense)
    '            Else : textData.Append("Right Lense: " + ControlChars.NewLine + RightLense)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftLense) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Lense: " + ControlChars.NewLine + LeftLense)
    '            Else : textData.Append("Left Lense: " + ControlChars.NewLine + LeftLense)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightEyeBall) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Eye Ball: " + ControlChars.NewLine + RightEyeBall)
    '            Else : textData.Append("Right Eye Ball: " + ControlChars.NewLine + RightEyeBall)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftEyeBall) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Eye Ball: " + ControlChars.NewLine + LeftEyeBall)
    '            Else : textData.Append("Left Eye Ball: " + ControlChars.NewLine + LeftEyeBall)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightOrbit) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Orbit: " + ControlChars.NewLine + RightOrbit)
    '            Else : textData.Append("Right Orbit: " + ControlChars.NewLine + RightOrbit)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftOrbit) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Orbit: " + ControlChars.NewLine + LeftOrbit)
    '            Else : textData.Append("Left Orbit: " + ControlChars.NewLine + LeftOrbit)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(EyeNotes) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Eye Notes: " + ControlChars.NewLine + EyeNotes)
    '            Else : textData.Append("Eye Notes: " + ControlChars.NewLine + EyeNotes)
    '            End If
    '        End If


    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function OrthopticsData() As String

    '    Try
    '        Dim textData As New System.Text.StringBuilder(String.Empty)
    '        Dim HeadPosture As String = StringMayBeEnteredIn(Me.stbHeadPosture)
    '        Dim Fixation As String = StringMayBeEnteredIn(Me.stbFixation)
    '        Dim LeftHirschberg As String = StringMayBeEnteredIn(Me.stbLeftHirschberg)
    '        Dim RightHirschberg As String = StringMayBeEnteredIn(Me.stbRightHirschberg)
    '        Dim RightEOM As String = StringMayBeEnteredIn(Me.stbRightEOM)
    '        Dim LeftEOM As String = StringMayBeEnteredIn(Me.stbLeftEOM)
    '        Dim CoverTestID As String = StringMayBeEnteredIn(Me.cboCoverTestID)
    '        Dim LeftAPCTGlasses As String = StringMayBeEnteredIn(Me.stbLeftAPCTGlasses)
    '        Dim RightAPCTGlasses As String = StringMayBeEnteredIn(Me.stbRightAPCTGlasses)
    '        Dim LeftAPCTWithOutGlasses As String = StringMayBeEnteredIn(Me.stbLeftAPCTWithOutGlasses)
    '        Dim RightAPCTWithOutGlasses As String = StringMayBeEnteredIn(Me.stbRightAPCTWithOutGlasses)
    '        Dim Correspondence As String = StringMayBeEnteredIn(Me.stbCorrespondence)
    '        Dim PrismAdaptation As String = StringMayBeEnteredIn(Me.stbPrismAdaptation)
    '        Dim FusionConvergence As String = StringMayBeEnteredIn(Me.stbFusionConvergence)
    '        Dim FusionDivergence As String = StringMayBeEnteredIn(Me.stbFusionDivergence)
    '        Dim FusionRange As String = StringMayBeEnteredIn(Me.stbFusionRange)
    '        Dim NearPointOfAccommodation As String = StringMayBeEnteredIn(Me.stbNearPointOfAccommodation)
    '        Dim NearPointOfConvergence As String = StringMayBeEnteredIn(Me.stbNearPointOfConvergence)
    '        Dim OrthopticsNotes As String = StringMayBeEnteredIn(Me.stbOrthopticsNotes)

    '        If Not String.IsNullOrEmpty(HeadPosture) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Head Posture: " + ControlChars.NewLine + HeadPosture)
    '            Else : textData.Append("Head Posture: " + ControlChars.NewLine + HeadPosture)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(Fixation) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Fixation: " + ControlChars.NewLine + Fixation)
    '            Else : textData.Append("Fixation: " + ControlChars.NewLine + Fixation)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightHirschberg) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right Hirschberg: " + ControlChars.NewLine + RightHirschberg)
    '            Else : textData.Append("Right Hirschberg: " + ControlChars.NewLine + RightHirschberg)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftHirschberg) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left Hirschberg: " + ControlChars.NewLine + LeftHirschberg)
    '            Else : textData.Append("Left Hirschberg: " + ControlChars.NewLine + LeftHirschberg)
    '            End If
    '        End If



    '        If Not String.IsNullOrEmpty(RightEOM) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right EOM: " + ControlChars.NewLine + RightEOM)
    '            Else : textData.Append("Right EOM: " + ControlChars.NewLine + RightEOM)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftEOM) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left EOM: " + ControlChars.NewLine + LeftEOM)
    '            Else : textData.Append("Left EOM: " + ControlChars.NewLine + LeftEOM)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(CoverTestID) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Cover Test: " + ControlChars.NewLine + CoverTestID)
    '            Else : textData.Append("Cover Test: " + ControlChars.NewLine + CoverTestID)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightAPCTGlasses) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Alternate Prism Cover Test With Glasses (Right): " + ControlChars.NewLine + RightAPCTGlasses)
    '            Else : textData.Append("Alternate Prism Cover Test With Glasses (Right): " + ControlChars.NewLine + RightAPCTGlasses)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftAPCTGlasses) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Alternate Prism Cover Test With Glasses (Left): " + ControlChars.NewLine + LeftAPCTGlasses)
    '            Else : textData.Append("Alternate Prism Cover Test With Glasses (Left): " + ControlChars.NewLine + LeftAPCTGlasses)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightAPCTWithOutGlasses) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Alternate Prism Cover Test Without Glasses (Right): " + ControlChars.NewLine + RightAPCTWithOutGlasses)
    '            Else : textData.Append("Alternate Prism Cover Test Without Glasses (Right): " + ControlChars.NewLine + RightAPCTWithOutGlasses)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftAPCTWithOutGlasses) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Alternate Prism Cover Test Without Glasses (Left): " + ControlChars.NewLine + LeftAPCTWithOutGlasses)
    '            Else : textData.Append("Alternate Prism Cover Test Without Glasses (Left): " + ControlChars.NewLine + LeftAPCTWithOutGlasses)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(Correspondence) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Correspondence: " + ControlChars.NewLine + Correspondence)
    '            Else : textData.Append("Correspondence: " + ControlChars.NewLine + Correspondence)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(PrismAdaptation) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Prism Adaptation: " + ControlChars.NewLine + PrismAdaptation)
    '            Else : textData.Append("Prism Adaptation: " + ControlChars.NewLine + PrismAdaptation)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(FusionConvergence) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Fusion Convergence: " + ControlChars.NewLine + FusionConvergence)
    '            Else : textData.Append("Fusion Convergence: " + ControlChars.NewLine + FusionConvergence)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(FusionDivergence) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Fusion Divergence: " + ControlChars.NewLine + FusionDivergence)
    '            Else : textData.Append("Fusion Divergence: " + ControlChars.NewLine + FusionDivergence)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(FusionRange) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Fusion Range: " + ControlChars.NewLine + FusionRange)
    '            Else : textData.Append("Fusion Range: " + ControlChars.NewLine + FusionRange)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(NearPointOfAccommodation) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Near Point Of Accommodation: " + ControlChars.NewLine + NearPointOfAccommodation)
    '            Else : textData.Append("Near Point Of Accommodation: " + ControlChars.NewLine + NearPointOfAccommodation)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(NearPointOfConvergence) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Near Point Of Convergence: " + ControlChars.NewLine + NearPointOfConvergence)
    '            Else : textData.Append("Near Point Of Convergence: " + ControlChars.NewLine + NearPointOfConvergence)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(OrthopticsNotes) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Orthoptics Notes: " + ControlChars.NewLine + OrthopticsNotes)
    '            Else : textData.Append("Orthoptics Notes: " + ControlChars.NewLine + OrthopticsNotes)
    '            End If
    '        End If


    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    'Public Function RefractionData() As String

    '    Try
    '        Dim textData As New System.Text.StringBuilder(String.Empty)

    '        Dim RightMRSPH As String = StringMayBeEnteredIn(Me.stbRightMRSPH)
    '        Dim LeftMRSPH As String = StringMayBeEnteredIn(Me.stbLeftMRSPH)
    '        Dim RightMRCYL As String = StringMayBeEnteredIn(Me.stbRightMRCYL)
    '        Dim LeftMRCYL As String = StringMayBeEnteredIn(Me.stbLeftMRCYL)
    '        Dim RightMRAXIS As String = StringMayBeEnteredIn(Me.stbRightMRAXIS)
    '        Dim LeftMRAXIS As String = StringMayBeEnteredIn(Me.stbLeftMRAXIS)

    '        Dim RightCRSPH As String = StringMayBeEnteredIn(Me.stbRightCRSPH)
    '        Dim LeftCRSPH As String = StringMayBeEnteredIn(Me.stbLeftCRSPH)
    '        Dim RightCRCYL As String = StringMayBeEnteredIn(Me.stbRightCRCYL)
    '        Dim LeftCRCYL As String = StringMayBeEnteredIn(Me.stbLeftCRCYL)
    '        Dim RightCRAXIS As String = StringMayBeEnteredIn(Me.stbRightCRAXIS)
    '        Dim LeftCRAXIS As String = StringMayBeEnteredIn(Me.stbLeftCRAXIS)

    '        Dim RightPCRSPH As String = StringMayBeEnteredIn(Me.stbRightPCRSPH)
    '        Dim LeftPCRSPH As String = StringMayBeEnteredIn(Me.stbLeftPCRSPH)
    '        Dim RightPCRCYL As String = StringMayBeEnteredIn(Me.stbRightPCRCYL)
    '        Dim LeftPCRCYL As String = StringMayBeEnteredIn(Me.stbLeftPCRCYL)
    '        Dim RightPCRAXIS As String = StringMayBeEnteredIn(Me.stbRightPCRAXIS)
    '        Dim LeftPCRRAXIS As String = StringMayBeEnteredIn(Me.stbLeftPCRRAXIS)

    '        If Not String.IsNullOrEmpty(RightMRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right MR SPH: " + ControlChars.NewLine + RightMRSPH)
    '            Else : textData.Append("Right MR SPH: " + ControlChars.NewLine + RightMRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftMRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left MR SPH: " + ControlChars.NewLine + LeftMRSPH)
    '            Else : textData.Append("Left MR SPH: " + ControlChars.NewLine + LeftMRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightMRCYL) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right MR CYL: " + ControlChars.NewLine + RightMRCYL)
    '            Else : textData.Append("Right MR CYL: " + ControlChars.NewLine + RightMRCYL)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftMRCYL) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left MR CYL: " + ControlChars.NewLine + LeftMRCYL)
    '            Else : textData.Append("Left MR CYL: " + ControlChars.NewLine + LeftMRCYL)
    '            End If
    '        End If



    '        If Not String.IsNullOrEmpty(RightMRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right MR AXIS: " + ControlChars.NewLine + RightMRAXIS)
    '            Else : textData.Append("Right MR AXIS: " + ControlChars.NewLine + RightMRAXIS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftMRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left MR AXIS: " + ControlChars.NewLine + LeftMRAXIS)
    '            Else : textData.Append("Left MR AXIS: " + ControlChars.NewLine + LeftMRAXIS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightCRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right CR SPH: " + ControlChars.NewLine + RightCRSPH)
    '            Else : textData.Append("Right CR SPH: " + ControlChars.NewLine + RightCRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftCRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left CR SPH: " + ControlChars.NewLine + LeftCRSPH)
    '            Else : textData.Append("Left CR SPH: " + ControlChars.NewLine + LeftCRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightCRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right CR AXIS: " + ControlChars.NewLine + RightCRAXIS)
    '            Else : textData.Append("Right CR AXIS: " + ControlChars.NewLine + RightCRAXIS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftCRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left CR AXIS: " + ControlChars.NewLine + LeftCRAXIS)
    '            Else : textData.Append("Left CR AXIS: " + ControlChars.NewLine + LeftCRAXIS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightPCRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right PCR SPH: " + ControlChars.NewLine + RightPCRSPH)
    '            Else : textData.Append("Right PCR SPH: " + ControlChars.NewLine + RightPCRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftPCRSPH) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left PCR SPH: " + ControlChars.NewLine + LeftPCRSPH)
    '            Else : textData.Append("Left PCR SPH: " + ControlChars.NewLine + LeftPCRSPH)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightPCRCYL) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right PCR CYL: " + ControlChars.NewLine + RightPCRCYL)
    '            Else : textData.Append("Right PCR CYL: " + ControlChars.NewLine + RightPCRCYL)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftPCRCYL) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left PCR CYL: " + ControlChars.NewLine + LeftPCRCYL)
    '            Else : textData.Append("Left PCR CYL: " + ControlChars.NewLine + LeftPCRCYL)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(RightPCRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Right PCR AXIS: " + ControlChars.NewLine + RightPCRAXIS)
    '            Else : textData.Append("Right PCR AXIS: " + ControlChars.NewLine + RightPCRAXIS)
    '            End If
    '        End If

    '        If Not String.IsNullOrEmpty(LeftPCRRAXIS) Then
    '            If textData.Length > 1 Then
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append(ControlChars.NewLine)
    '                textData.Append("Left PCR AXIS: " + ControlChars.NewLine + LeftPCRRAXIS)
    '            Else : textData.Append("Fusion Range: " + ControlChars.NewLine + LeftPCRRAXIS)
    '            End If
    '        End If


    '        If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

    '        Return textData.ToString()

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Public Function DiagnosisData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

                If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim diseaseCode As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)
                    Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedDiagnosisDisplay As List(Of String) = WrapText(diagnosisDisplay, padService)
                    If wrappedDiagnosisDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedDiagnosisDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedDiagnosisDisplay(pos).Trim(), padService))
                            If pos = wrappedDiagnosisDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(diagnosisDisplay, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LaboratoryData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer
            Dim padLabTest As Integer

            padLabTest = padService + padNotes

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

                If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                    line += 1

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lineNo As String = (line).ToString()
                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colTest))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedItemName As List(Of String) = WrapText(itemName, padLabTest)

                    If wrappedItemName.Count > 1 Then
                        For pos As Integer = 0 To wrappedItemName.Count - 1
                            tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padLabTest))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else : tableData.Append(FixDataLength(itemName, padLabTest))
                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CardiologyData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

                If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

                    line += 1

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lineNo As String = (line).ToString()
                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colCardiologyExamFullName))
                    Dim indication As String = StringMayBeEnteredIn(cells, Me.colCardiologyIndication)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedItemName As List(Of String) = WrapText(itemName, padService)
                    If wrappedItemName.Count > 1 Then
                        For pos As Integer = 0 To wrappedItemName.Count - 1
                            tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padService))
                            If pos = wrappedItemName.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(indication, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(itemName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(indication, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function RadiologyData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

                If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                    line += 1

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lineNo As String = (line).ToString()
                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExamFullName))
                    Dim indication As String = StringMayBeEnteredIn(cells, Me.colRadiologyIndication)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedItemName As List(Of String) = WrapText(itemName, padService)
                    If wrappedItemName.Count > 1 Then
                        For pos As Integer = 0 To wrappedItemName.Count - 1
                            tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padService))
                            If pos = wrappedItemName.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(indication, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(itemName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(indication, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(indication, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrug)
                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                    Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)

                    Dim fullDosage As String
                    If String.IsNullOrEmpty(notes) Then
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " for " + duration + " day"
                        Else : fullDosage = dosage + " for " + duration + " days"
                        End If
                    Else
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage + " (" + notes + ")"
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
                        Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
                        End If
                    End If

                    tableData.Append(lineNo.PadRight(padLineNo))
                    tableData.Append(itemName.PadRight(padService))

                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padNotes)
                    If wrappedfullDosage.Count > 1 Then
                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padNotes))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo + padService))
                        Next
                    Else : tableData.Append(FixDataLength(fullDosage, padNotes))
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ProceduresData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

                If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim procedureCode As String = StringMayBeEnteredIn(cells, Me.colProcedureCode)
                    Dim miniProcedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim procedureName As String = (From data In miniProcedures
                                                   Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(procedureCode.ToUpper())
                                                   Select data.Field(Of String)("ProcedureName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedProceduresDisplay As List(Of String) = WrapText(procedureName, padService)
                    If wrappedProceduresDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedProceduresDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedProceduresDisplay(pos).Trim(), padService))
                            If pos = wrappedProceduresDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(procedureName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TheatreData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

                If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colTheatreService)
                    'Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    'Dim theatreName As String = StringMayBeEnteredIn(cells, Me.colTheatreService)

                    Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colICDTheatreCode)
                    Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = StringMayBeEnteredIn(cells, Me.colTheatreCode)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedTheatreDisplay As List(Of String) = WrapText(theatreName, padService)
                    If wrappedTheatreDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedTheatreDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedTheatreDisplay(pos).Trim(), padService))
                            If pos = wrappedTheatreDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(theatreName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DentalServicesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1

                If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim dentalCode As String = StringMayBeEnteredIn(cells, Me.colDentalCode)
                    Dim miniDentalService As EnumerableRowCollection(Of DataRow) = dentalService.AsEnumerable()
                    Dim dentalName As String = (From data In miniDentalService
                                                Where data.Field(Of String)("DentalCode").ToUpper().Equals(dentalCode.ToUpper())
                                                Select data.Field(Of String)("DentalName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedDentalDisplay As List(Of String) = WrapText(dentalName, padService)
                    If wrappedDentalDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedDentalDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedDentalDisplay(pos).Trim(), padService))
                            If pos = wrappedDentalDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(dentalName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DentalLaboratoryData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 1

                If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDentalLab.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim dentalCode As String = StringMayBeEnteredIn(cells, Me.colDentalLabCode)
                    Dim miniDentalLaboratory As EnumerableRowCollection(Of DataRow) = dentalLaboratory.AsEnumerable()
                    Dim dentalName As String = (From data In miniDentalLaboratory
                                                Where data.Field(Of String)("DentalCode").ToUpper().Equals(dentalCode.ToUpper())
                                                Select data.Field(Of String)("DentalName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalLabNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedDentalLabDisplay As List(Of String) = WrapText(dentalName, padService)
                    If wrappedDentalLabDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedDentalLabDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedDentalLabDisplay(pos).Trim(), padService))
                            If pos = wrappedDentalLabDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(dentalName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

    Private Sub LockItemsUnitPrices()
        Dim oVariousOptions As New VariousOptions()
        Dim unitPrice As DataGridViewColumn() = {colProcedureUnitPrice, colDentalUnitPrice, colTheatreUnitPrice}
        DisableGridComponets(unitPrice, oVariousOptions.LockItemsUnitPrices)

    End Sub

    Private Sub frmIPDDoctor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try
            If e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                btnSave_Click(sender, e)
            ElseIf e.KeyCode = Keys.D AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions)
                Me.BringToFront()
            ElseIf e.KeyCode = Keys.L AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                Me.tbcDrRoles.SelectTab(Me.tpgLaboratory)
                Me.BringToFront()
            ElseIf e.KeyCode = Keys.N AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                Me.tbcDrRoles.SelectTab(Me.tpgClinicalFindings)
                Me.BringToFront()

            ElseIf e.KeyCode = Keys.R AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                Me.tbcDrRoles.SelectTab(Me.tpgLabResults)
                Me.BringToFront()
            End If
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


End Class