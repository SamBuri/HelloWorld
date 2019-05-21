

Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmDoctor

#Region " Fields "

    Private clinicalFindingsSaved As Boolean = True
    Private eyeAssessmentSaved As Boolean = True
    Private orthopticsSaved As Boolean = True
    Private opticalPrescriptionSaved As Boolean = True
    Private refractionSaved As Boolean = True
    Private lowVisionSaved As Boolean = True
    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty
    Private Shared totalCost As Decimal = 0
    Private allergies As DataTable
    Private labTests As DataTable
    Private consumableItems As DataTable
    Private cardiologyExaminations As DataTable
    Private radiologyExaminations As DataTable
    Private pathologyExaminations As DataTable
    Private patientAllergies As DataTable
    Private procedures As DataTable
    Private theatreServices As DataTable
    Private dentalService As DataTable
    Private dentalLaboratory As DataTable
    Private opticalServices As DataTable
    Private diseases As DataTable
    Private labResultsAlerts As DataTable
    Private cardiologyReportsAlerts As DataTable
    Private labResultsIPDAlerts As DataTable

    Private antenatalStageSaved As Boolean = True
    Private obstetricHistorySaved As Boolean = True
    Private perinatalSaved As Boolean = True
    Private postNatalSaved As Boolean = True
    Private ChildGrowthSaved As Boolean = True


    Private radiologyReportsAlerts As DataTable
    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now
    Private iPDAlertsStartDateTime As Date = Now
    Private visitStatus As String = String.Empty
    Private genderID As String = String.Empty
    Private visitStandardFee As Decimal = 0
    Private visitServiceCode As String = String.Empty
    Private visitServiceName As String = String.Empty
    Private ageInyears As Decimal

    Private doctorLoginID As String = String.Empty
    Private staffFullName As String = String.Empty

    Private accessCashServices As Boolean = False

    Private hasPaidPackage As Boolean = False
    Private IsPackage As Boolean = False

    Private patientpackageNo As String = String.Empty
    Private packageNopatient As String = String.Empty
    Private currentLoginFullName As String = String.Empty
    Private servicePayStatusID As String = String.Empty
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private copayServicePayStatusID As String = String.Empty

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private _DrugNo As String = String.Empty
    Private _DiagnosisCode As String = String.Empty
    Private _TheatreCode As String = String.Empty
    Private _TestCode As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _TestValue As String = String.Empty
    Private _ExamNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _DentalNameValue As String = String.Empty
    Private _DentalLabNameValue As String = String.Empty
    Private _OpticalNameValue As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty

    Private tipBillServiceFeeWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCoPayValueWords As New ToolTip()

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private proPaint As New System.Diagnostics.Process()

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
    Private totalBillConsumption As Decimal
    Private oBillModesID As New LookupDataID.BillModesID()
    Private OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()

#End Region

#Region " Validations "


    Private Sub dtpReferralDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpReferralDate.Validating

        Try

            Dim errorMSG As String = "Referral date can't be before visit date!"
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim referralDate As Date = DateMayBeEnteredIn(Me.dtpReferralDate)

            If referralDate = AppData.NullDateValue Then Return

            If referralDate < visitDate Then
                ErrProvider.SetError(Me.dtpReferralDate, errorMSG)
                Me.dtpReferralDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpReferralDate, "")
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region

#Region " Properties "

    Private ReadOnly Property NewTriageTest() As String
        Get
            Return "Register Triage..."
        End Get
    End Property

    Private ReadOnly Property EditTriageTest() As String
        Get
            Return "Edit Triage..."
        End Get
    End Property

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

    Private ReadOnly Property NewRefractionVision() As String
        Get
            Return "Register Refraction Vision..."
        End Get
    End Property

    Private ReadOnly Property EditRefractionVision() As String
        Get
            Return "Edit Refraction Vision..."
        End Get
    End Property

    Private ReadOnly Property NewRefractionVisionAssessment() As String
        Get
            Return "Register Refraction Vision Assessment..."
        End Get
    End Property

    Private ReadOnly Property EditRefractionVisionAssessment() As String
        Get
            Return "Edit Refraction Vision Assessment..."
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

    Private ReadOnly Property ScheduleAppointment() As String
        Get
            Return "Schedule Appointment"
        End Get
    End Property

    Private ReadOnly Property TodaysAppointment() As String
        Get
            Return "Today's Appointments"
        End Get
    End Property

    Private ReadOnly Property VisitClosed() As String
        Get
            Return "Visit Closed"
        End Get
    End Property

    Private ReadOnly Property CloseVisit() As String
        Get
            Return "Close Visit"
        End Get
    End Property

#End Region

    Private Sub frmDoctor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            Me.LoadAllergies()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            proPaint = Nothing

            If oVariousOptions.HideDoctorBillServiceFee Then
                Me.stbBillServiceFee.PasswordChar = "#"c
            Else : Me.stbBillServiceFee.PasswordChar = CChar(String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadServices()
            Me.LoadCardiologyExaminations()
            Me.LoadRadiologyExaminations()
            Me.LoadPathologyExaminations()
            Me.LoadProcedures()
            Me.LoadTheatreServices()
            Me.LoadDentalCategoryService()
            Me.LoadDentalCategoryLaboratory()


            Me.LoadStaff()
            Me.ShowAllAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)
            LoadLookupDataCombo(Me.cboLenseTypeID, LookupObjects.LenseType, False)
            LoadLookupDataCombo(Me.cboCoverTestID, LookupObjects.CoverTest, True)
            LoadLookupDataCombo(Me.cboOphthalmologistSeenID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboColourVisionDefectID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboContrastSensitivityID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboVisualFieldDefectID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboOtherImpairmentsId, LookupObjects.YesNo, True)
            'LoadLookupDataCombo(Me.clbChronicDiseases, LookupObjects.ChronicDiseases, False)
            LoadLookupDataCombo(Me.cboExistingVisualAcuityFarLEID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboExistingVisualAcuityFarREID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboExistingVisualAcuityNearLEID, LookupObjects.VisualAcuityNear, False)
            LoadLookupDataCombo(Me.cboExistingVisualAcuityNearREID, LookupObjects.VisualAcuityNear, False)

            LoadLookupDataCombo(Me.cboNewVisualAcuityFarLEID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboNewVisualAcuityFarREID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboNewVisualAcuityNearLEID, LookupObjects.VisualAcuityNear, False)
            LoadLookupDataCombo(Me.cboNewVisualAcuityNearREID, LookupObjects.VisualAcuityNear, False)

            LoadLookupDataCombo(Me.clbExistingLVDsNear, LookupObjects.LowVisionDevicesNear, False)
            LoadLookupDataCombo(Me.clbExistingLVDsFar, LookupObjects.LowVisionDevicesFar, False)
            LoadLookupDataCombo(Me.clbLowVisionDevicesNear, LookupObjects.LowVisionDevicesNear, False)
            LoadLookupDataCombo(Me.clbLowVisionDevicesFar, LookupObjects.LowVisionDevicesFar, False)
            LoadLookupDataCombo(Me.clbNonOpticalAids, LookupObjects.NonOpticalAids, False)

            ''''''''''''''''''''''''''''''''''''PAED'''''''''''''''''''''''''''''''''''''''''''''
           

            LoadLookupDataCombo(Me.cboEIDResults, LookupObjects.EIDResults, False)

            LoadLookupDataCombo(Me.cboConditionOnBith, LookupObjects.ConditionOnBirth, False)
            LoadLookupDataCombo(Me.cboBreastFeeding, LookupObjects.BreastFeeding, False)
            LoadLookupDataCombo(Me.cboConvulsions, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboJaundice, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboEarlyInfection, LookupObjects.YesNoUnknown, False)
            LoadLookupDataCombo(Me.cboDeliveryComplications, LookupObjects.DeliveryComplications, False)
            LoadLookupDataCombo(Me.cboInfection, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSmoking, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboAccidentDuringPregnancy, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboUseOfDrugsOrPrescription, LookupObjects.YesNoUnknown, False)
            LoadLookupDataCombo(Me.cboAbortions, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCaesarian, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboStillBirth, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboChronicIllness, LookupObjects.YesNo, False)


            LoadLookupDataCombo(Me.cboWeightForAge, LookupObjects.WeightForAge, False)
            LoadLookupDataCombo(Me.cboWeightForHeight, LookupObjects.WeightForAge, False)
            LoadLookupDataCombo(Me.cboHeightForAge, LookupObjects.WeightForAge, False)
            LoadLookupDataCombo(Me.cboUmblicalCordDetails, LookupObjects.ConditionOfUmblicalCord, False)

            LoadLookupDataCombo(Me.cboCauseOfDeath, LookupObjects.IfDeceased, False)
            LoadLookupDataCombo(Me.cboComplicationsGyn, LookupObjects.DeliveryComplications, False)
            LoadLookupDataCombo(Me.cboModeOfDelivery, LookupObjects.TypeOfDelivery, False)
            LoadLookupDataCombo(Me.cboMothersCondition, LookupObjects.MothersCondition, False)
            LoadLookupDataCombo(Me.cboBabyAlive, LookupObjects.YesNo, False)

            Me.labTests = LoadLabTests()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LockItemsUnitPrices()
            Me.ApplySecurity()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertCheckPeriod = InitOptions.AlertCheckPeriod \ 2
            If alertCheckPeriod > 0 Then
                Me.tmrAlerts.Interval = 1000 * 60 * alertCheckPeriod
            Else : Me.tmrAlerts.Interval = 1000 * 60
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmDoctor_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowAllAlerts()
    End Sub

    Private Sub frmDoctor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Dim oVariousOptions As New VariousOptions
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

    Private Sub stbVisitNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Me.AllSaved() Then Me.Close()

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadSeeDrVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSeeDrVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSeeDoctorVisits As New frmSeeDoctorVisits(Me.stbVisitNo)
            fSeeDoctorVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServicePointID As New LookupDataID.ServicePointID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from services
            Dim services As DataTable = oServices.GetServicesAtServicePoint(oServicePointID.Visit).Tables("Services")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboServiceCode.Sorted = False
            Me.cboServiceCode.DataSource = services
            Me.cboServiceCode.DisplayMember = "ServiceName"
            Me.cboServiceCode.ValueMember = "ServiceCode"

            Me.cboServiceCode.SelectedIndex = -1
            Me.cboServiceCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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


            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return labTests
            '''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function LoadTheatreServices() As DataTable

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()
        Dim oSetupData As New SetupData()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices
            If Not InitOptions.LoadTheatreServicesAtStart Then
                theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
                oSetupData.TheatreServices = theatreServices
            Else : theatreServices = oSetupData.TheatreServices
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return theatreServices
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub LoadDentalCategoryService()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            dentalService = oDentalServices.GetDentalServicesByCategory(oDentalCategoryID.Service).Tables("DentalServices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalService, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalLabCode.Sorted = False
            LoadComboData(Me.colDentalLabCode, dentalLaboratory, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Sub LoadOpticalServices()

    '    Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        ' Load from OpticalServices

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Me.colOpticalCode.Sorted = False
    '        LoadComboData(Me.colOpticalCode, opticalServices, "OpticalCode", "OpticalName")
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub

    Private Function GetConsumableItems() As DataTable

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return consumableItems

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

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


            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return diseases
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            If oVariousOptions.RestrictSelectionOfOnlyLoggedInDoctors Then
                staff = oStaff.GetLoggedInStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadStaff(ByVal doctorSpecialtyID As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboReferredTo.Items.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Load all from Staff
            Dim staff As DataTable = oStaff.GetStaffByDoctorSpecialty(oStaffTitleID.Doctor, doctorSpecialtyID).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboReferredTo, staff, "StaffFullName")
            Me.cboReferredTo.Items.Insert(0, "")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cbodoctorSpecialtyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoctorSpecialtyID.SelectedIndexChanged

        Try

            Dim doctorSpecialtyID As String = StringValueMayBeEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
            If String.IsNullOrEmpty(doctorSpecialtyID) Then Return

            Me.LoadStaff(doctorSpecialtyID)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClinicalFindingsTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbClinicalNotes.TextChanged, stbPMH.TextChanged, stbPOH.TextChanged, stbPGH.TextChanged, stbFSH.TextChanged,
        stbGeneralAppearance.TextChanged, stbCVS.TextChanged, stbENT.TextChanged, stbAbdomen.TextChanged,
        stbCNS.TextChanged, stbEYE.TextChanged, stbMuscularSkeletal.TextChanged

        clinicalFindingsSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbVisitNo))

    End Sub

    Private Sub OpticalPrescriptionTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        opticalPrescriptionSaved = False
    End Sub

    Private Sub RefractionTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPD.TextChanged, stbSegmentHeights.TextChanged
        refractionSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbVisitNo))
    End Sub

    Private Sub EyeAssessmentTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRightMapular.TextChanged,
        stbLeftOpticalDisc.TextChanged
        eyeAssessmentSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbVisitNo))

    End Sub

    Private Sub OrthopticsTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        orthopticsSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbVisitNo))

    End Sub
    Private Sub LowVisionTextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBriefHistory.TextChanged, stbProfession.TextChanged, stbMajorOcularDiagnosisRE.TextChanged, stbOtherOcularDiagnosisRE.TextChanged, stbMajorOcularDiagnosisLE.TextChanged, stbOtherOcularDiagnosisLE.TextChanged,
    cboOphthalmologistSeenID.TextChanged, stbExistingTreatmentFarLE.TextChanged, cboExistingVisualAcuityFarLEID.TextChanged, stbExistingTreatmentFarRE.TextChanged, cboExistingVisualAcuityFarREID.TextChanged, stbExistingTreatmentNearLE.TextChanged, cboExistingVisualAcuityNearLEID.TextChanged, stbExistingTreatmentNearRE.TextChanged,
    stbNewTreatmentFarLE.TextChanged, cboNewVisualAcuityFarLEID.TextChanged, stbNewTreatmentFarRE.TextChanged, cboNewVisualAcuityFarREID.TextChanged, stbNewTreatmentNearLE.TextChanged, cboNewVisualAcuityNearLEID.TextChanged, stbNewTreatmentNearRE.TextChanged, cboNewVisualAcuityNearREID.TextChanged, clbExistingLVDsFar.TextChanged, clbExistingLVDsNear.TextChanged,
    cboExistingVisualAcuityNearREID.TextChanged, cboOtherImpairmentsId.TextChanged, stbOtherImpairments.TextChanged, cboVisualFieldDefectID.TextChanged, stbVisualFieldDefectTestUsed.TextChanged, stbAdvice.TextChanged, clbLowVisionDevicesFar.TextChanged, clbLowVisionDevicesNear.TextChanged, clbNonOpticalAids.TextChanged
        lowVisionSaved = String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbVisitNo))
    End Sub


#Region " Alerts "

    Private Sub ShowAllAlerts()
        Me.ShowWaitingVisits()
        Me.ShowLabResultsAlerts()
        Me.ShowCardiologyReportsAlerts()
        Me.ShowRadiologyReportsAlerts()
        Me.ShowLabResultsIPDAlerts()
    End Sub

    Private Function ShowWaitingVisits() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim visits As DataTable = oVisits.GetWaitingVisits(CurrentUser.LoginID).Tables("Visits")
            Dim EmergencyVisits As DataTable = oVisits.GetEmergencyWaitingVisits(CurrentUser.LoginID).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = visits.Rows.Count
            Dim EmergencyWaitingNo As Integer = EmergencyVisits.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblWaitingVisits.Text = "Waiting Visits: " + waitingNo.ToString() + "(" + EmergencyWaitingNo.ToString() + ")"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowLabResultsAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Alerts
            labResultsAlerts = oAlerts.GetAlerts(oAlertTypeID.LabResults, CurrentUser.LoginID).Tables("Alerts")

            Dim alertsNo As Integer = labResultsAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblLabResultsAlerts.Text = "Ready Results: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowCardiologyReportsAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Alerts
            cardiologyReportsAlerts = oAlerts.GetAlerts(oAlertTypeID.CardiologyReports, CurrentUser.LoginID).Tables("Alerts")

            Dim alertsNo As Integer = cardiologyReportsAlerts.Rows.Count

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblCardiologyReportsAlerts.Text = "Cardiology: " + alertsNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowRadiologyReportsAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Alerts
            radiologyReportsAlerts = oAlerts.GetAlerts(oAlertTypeID.RadiologyReports, CurrentUser.LoginID).Tables("Alerts")

            Dim alertsNo As Integer = radiologyReportsAlerts.Rows.Count

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRadiologyReportsAlerts.Text = "Radiology Reports: " + alertsNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowLabResultsIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            labResultsIPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.LabResults, CurrentUser.LoginID).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = labResultsIPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "IPD Ready Results: " + iPDAlertsNo.ToString()

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

    Private Sub btnWaitingVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWaitingVisits.Click

        Try

            Me.ShowWaitingVisits()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fWaitingVisits As New frmWaitingVisits(Me.stbVisitNo)
            fWaitingVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try


    End Sub

    Private Sub btnViewLabResultsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewLabResultsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.LabResults, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewCardiologyReportsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewCardiologyReportsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowCardiologyReportsAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.CardiologyReports, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub


    Private Sub btnViewRadiologyReportsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRadiologyReportsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRadiologyReportsAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.RadiologyReports, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitsHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteLabResultsAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If labResultsAlerts Is Nothing OrElse labResultsAlerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = labResultsAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                      GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                      data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub DeleteCardiologyReportsAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If cardiologyReportsAlerts Is Nothing OrElse cardiologyReportsAlerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = cardiologyReportsAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                        GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                        data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub DeleteRadiologyReportsAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If radiologyReportsAlerts Is Nothing OrElse radiologyReportsAlerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = radiologyReportsAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                        GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                        data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnViewDispensingStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDispensingStatus.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fDoctorItems As New frmDoctorItems(Me.stbVisitNo, AlertItemCategory.Drug)
            fDoctorItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then
                If Me.ShowWaitingVisits() > 0 Then If InitOptions.AlertSoundOn Then Beep()
                If Me.ShowLabResultsAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
                If Me.ShowCardiologyReportsAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
                If Me.ShowRadiologyReportsAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbBillServiceFee.Clear()
        Me.tipBillServiceFeeWords.RemoveAll()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbPackage.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbAdress.Clear()
        Me.stbTotalVisits.Clear()
        visitStatus = String.Empty
        genderID = String.Empty
        totalBillConsumption = 0
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.stbCombination.Clear()
        billCustomerName = String.Empty
        doctorLoginID = String.Empty
        billModesID = String.Empty
        associatedBillNo = String.Empty
        copayServicePayStatusID = String.Empty
        Me.stbBillMode.Clear()
        Me.cboServiceCode.SelectedIndex = -1
        Me.cboServiceCode.SelectedIndex = -1
        Me.stbVisitServiceName.Clear()
        Me.lblServicePayStatusID.Text = String.Empty
        patientpackageNo = String.Empty
        packageNopatient = String.Empty
        currentLoginFullName = String.Empty
        Me.spbPhoto.Image = Nothing
        Me.btnAppointments.Text = Me.TodaysAppointment
        Me.btnAddConsumables.Enabled = False
        Me.btnAddExtraCharge.Enabled = False
        Me.btnAttachPackage.Enabled = False
        ' Me.btnViewRadiologyImages.Enabled = False
        Me.btnSelfRequests.Enabled = False
        Me.btnAdmissions.Enabled = False
        Me.ManageDoctorVisitClosed(False)
        Me.btnDoctorVisitClosed.Enabled = False
        Me.btnPrintPreviewMedicalReport.Enabled = False
        If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgGeneral.Name) Then Me.btnPrint.Enabled = False
        Me.btnTriage.Text = Me.NewTriageTest
        Me.btnTriage.Enabled = False
        Me.btnVisionAssessment.Text = Me.NewVisionAssessment
        Me.btnVisionAssessment.Enabled = False
        Me.btnVisionAssessmentTwo.Text = Me.NewVisionAssessmentTwo
        Me.btnVisionAssessmentTwo.Enabled = False

        Me.nbxWeight.Clear()
        Me.nbxTemperature.Clear()
        Me.nbxHeight.Clear()
        Me.nbxMUAC.Clear()
        Me.nbxPulse.Clear()
        Me.stbBloodPressure.Clear()
        Me.nbxHeadCircum.Clear()
        Me.nbxBodySurfaceArea.Clear()
        Me.nbxRespirationRate.Clear()
        Me.nbxOxygenSaturation.Clear()
        Me.nbxHeartRate.Clear()
        Me.nbxBMI.Clear()
        Me.stbBMIStatus.Clear()
        Me.stbNotes.Clear()
        Me.spbClinicalImage.Image = Nothing
        Me.stbEyeTest.Clear()
        Me.StbVisualAcuityRight.Clear()
        Me.StbVisualAcuityRightExt.Clear()
        Me.StbVisualAcuityLeft.Clear()
        Me.StbVisualAcuityLeftExt.Clear()

        Me.StbPreferentialLookingRight.Clear()
        Me.StbPreferentialLookingLeft.Clear()

        Me.StbEyeNotes.Clear()
        Me.stbEyeTestEXT.Clear()
        Me.StbVisualAcuityRightExEXTID.Clear()
        Me.StbVisualAcuityRightExtEXTID.Clear()
        Me.StbVisualAcuityLeftExEXTID.Clear()
        Me.StbVisualAcuityLeftExtEXTID.Clear()

        Me.StbPreferentialLookingRightEXTID.Clear()
        Me.StbPreferentialLookingLeftEXTID.Clear()
        Me.stbNotesEXT.Clear()
        Me.stbEyeTestOptical.Clear()
        Me.StbVisualAcuityRightOptical.Clear()
        Me.StbVisualAcuityRightExtOptical.Clear()
        Me.StbVisualAcuityLeftOptical.Clear()
        Me.StbVisualAcuityLeftExtOptical.Clear()
        Me.StbPreferentialLookingRightEXTID.Clear()
        Me.StbPreferentialLookingLeftEXTID.Clear()
        Me.StbEyeNotesOptical.Clear()
        Me.lblMessage.Visible = False
        Me.grpCoPay.Visible = False
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        ResetControlsIn(Me.pnlBill)

        hasPaidPackage = False

    End Sub

    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''''
        staffFullName = String.Empty

        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgTriage)
        ResetControlsIn(Me.tpgClinicalGeneral)
        ResetControlsIn(Me.tpgLaboratory)
        ResetControlsIn(Me.tpgCardiology)
        ResetControlsIn(Me.tpgRadiology)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgDental)
        ResetControlsIn(Me.tpgDentalLab)
        'ResetControlsIn(Me.pnlOptical)
        ResetControlsIn(Me.tpgRefraction)
        ResetControlsIn(Me.tpgRefractionVisionAssessment)
        ResetControlsIn(Me.tpgEye)
        ResetControlsIn(Me.tpgLowVision)
        ResetControlsIn(Me.tpgLowVisionEXT)
        ResetControlsIn(Me.tpgOpticalServices)
        ResetControlsIn(Me.tpgOptical)
        ResetControlsIn(Me.tpgLabResults)
        ResetControlsIn(Me.tpgCardiologyReports)
        ResetControlsIn(Me.tpgRadiologyReports)
        ResetControlsIn(Me.tpgReferrals)
        ResetControlsIn(Me.tpgDiagnosis)
        ResetControlsIn(Me.tpgVisionAssessment)
        ResetControlsIn(Me.tpgEyeAssessment)
        ResetControlsIn(Me.tpgOrthoptics)
        'ResetControlsIn(Me.tpgChronicDiseases)
        ResetControlsIn(Me.tpgAllergies)
        ResetControlsIn(Me.tpgChildGrowth)
        ResetControlsIn(Me.tpgPostNatal)
        ResetControlsIn(Me.grpPerinatal)
        ResetControlsIn(Me.tpgObstetric)


        '''''''''''''''''''''''''''''''''''''''
        clinicalFindingsSaved = True
        eyeAssessmentSaved = True
        orthopticsSaved = True
        '''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ManageDoctorVisitClosed(ByVal closed As Boolean)

        If closed Then
            Me.btnDoctorVisitClosed.Enabled = False
            Me.btnDoctorVisitClosed.Text = Me.VisitClosed
        Else
            Me.btnDoctorVisitClosed.Enabled = Not Me.cboStaffNo.Enabled
            Me.btnDoctorVisitClosed.Text = Me.CloseVisit
        End If

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVariousOptions As New VariousOptions()
        Dim opatientallergies As New SyncSoft.SQLDb.PatientAllergies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim patientAllergyMsg As String = " This Patient has Allergy(s)" + ControlChars.NewLine + "Please take note"

        Dim chronicDiseasesMsg As String = " This Patient has Chronic Disease(s)" + ControlChars.NewLine + "Please take note"


        Try

            Me.tipBillServiceFeeWords.RemoveAll()
            Me.tipOutstandingBalanceWords.RemoveAll()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")

            Dim row As DataRow = visits.Rows(0)


            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Dim allergyList As DataTable = opatientallergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")
            Dim chronicDiseases As DataTable = oPatients.GetPatientByChronicDiseases(patientNo).Tables("Patients")
            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbMedicalConditions.Text = StringMayBeEnteredIn(row, "MedicalConditions")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            genderID = StringEnteredIn(row, "GenderID")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbAge.Text = GetAgeString(birthDate)
            Me.ageInyears = DecimalMayBeEnteredIn(row, "Age")
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            visitStatus = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.stbCombination.Text = StringMayBeEnteredIn(row, "Combination")
            Me.stbAdress.Text = StringMayBeEnteredIn(row, "Address")
            Dim billMode As String = StringEnteredIn(row, "BillMode")
            Me.stbBillMode.Text = billMode
            Me.priorityID = GetLookupDataID(LookupObjects.Priority, StringEnteredIn(row, "PriorityID"))
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

            'LoadCheckedListBox(Me.clbChronicDiseases, StringMayBeEnteredIn(row, "ChronicDiseases"))

            doctorLoginID = StringMayBeEnteredIn(row, "DoctorLoginID")
            hasPaidPackage = BooleanMayBeEnteredIn(row, "HasPaidPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            packageNopatient = patientNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

            If allergyList.Rows.Count > 0 Then

                ErrProvider.SetError(Me.tbcDrRoles, patientAllergyMsg)
                ErrProvider.SetIconAlignment(Me.tbcDrRoles, ErrorIconAlignment.TopLeft)
                ErrProvider.SetIconPadding(Me.tbcDrRoles, -8)

            Else
                ErrProvider.SetError(Me.tbcDrRoles, String.Empty)

            End If

            'If chronicDiseases.Rows.Count > 0 Then

            '        ErrProvider.SetError(Me.tbcTriage, chronicDiseasesMsg)
            '        ErrProvider.SetIconAlignment(Me.tbcTriage, ErrorIconAlignment.TopLeft)
            '        ErrProvider.SetIconPadding(Me.tbcTriage, -8)

            '    Else
            '        ErrProvider.SetError(Me.tbcTriage, String.Empty)

            'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                visitServiceCode = StringMayBeEnteredIn(row, "ServiceCode")
                visitServiceName = StringMayBeEnteredIn(row, "ServiceName")
                accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
                servicePayStatusID = StringMayBeEnteredIn(row, "ServicePayStatusID")
                billModesID = StringMayBeEnteredIn(row, "BillModesID")
                associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
                copayServicePayStatusID = StringMayBeEnteredIn(row, "ItemsCashServicePayStatusID")
                Me.stbVisitServiceName.Text = visitServiceName
                Me.lblServicePayStatusID.Text = GetLookupDataDes(servicePayStatusID)

                Dim doctorServiceCode As String = StringMayBeEnteredIn(row, "DoctorServiceCode")
                Dim serviceCode As String

                If Not String.IsNullOrEmpty(doctorServiceCode) Then
                    Me.cboServiceCode.SelectedValue = doctorServiceCode
                    serviceCode = doctorServiceCode
                Else
                    Me.cboServiceCode.SelectedValue = visitServiceCode
                    serviceCode = visitServiceCode
                End If

                If Not String.IsNullOrEmpty(serviceCode) Then
                    Try
                        Dim items As DataTable = oItems.GetItem(visitNo, serviceCode, oItemCategoryID.Service).Tables("Items")
                        Dim itemsRow As DataRow = items.Rows(0)
                        visitStandardFee = DecimalMayBeEnteredIn(itemsRow, "UnitPrice")
                        Me.stbBillServiceFee.Text = FormatNumber(visitStandardFee, AppData.DecimalPlaces)
                        If Not oVariousOptions.HideDoctorBillServiceFee Then
                            Me.tipBillServiceFeeWords.SetToolTip(Me.stbBillServiceFee, NumberToWords(visitStandardFee))
                        End If

                    Catch ex As Exception
                        Exit Try
                    End Try
                End If


                staffFullName = StringMayBeEnteredIn(row, "StaffFullName")

                Me.btnAppointments.Enabled = True
                Me.btnAppointments.Text = Me.ScheduleAppointment
                Me.btnAddConsumables.Enabled = True
                Me.btnAttachPackage.Enabled = True
                ' Me.btnViewRadiologyImages.Enabled = True
                Me.btnAddExtraCharge.Enabled = True
                Me.btnSelfRequests.Enabled = True
                Me.btnAdmissions.Enabled = True

                Security.Apply(Me.btnAppointments, AccessRights.Write)
                Security.Apply(Me.btnAddConsumables, AccessRights.Write)
                Security.Apply(Me.btnAddExtraCharge, AccessRights.Write)
                Security.Apply(Me.btnSelfRequests, AccessRights.Write)
                Security.Apply(Me.btnAdmissions, AccessRights.Write)
                Security.Apply(Me.btnAttachPackage, AccessRights.Write)
                ' Security.Apply(Me.btnViewRadiologyImages, AccessRights.Write)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim hasTriage As Boolean = BooleanMayBeEnteredIn(row, "HasTriage")
                If Not hasTriage Then
                    Me.btnTriage.Text = Me.NewTriageTest
                    Security.Apply(Me.btnTriage, AccessRights.Write)
                Else
                    Me.btnTriage.Text = Me.EditTriageTest
                    Security.Apply(Me.btnTriage, AccessRights.Edit)
                End If
                Me.nbxWeight.Value = StringMayBeEnteredIn(row, "Weight")
                Me.nbxTemperature.Value = StringMayBeEnteredIn(row, "Temperature")
                Me.nbxHeight.Value = StringMayBeEnteredIn(row, "Height")
                Me.nbxPulse.Value = StringMayBeEnteredIn(row, "Pulse")
                Me.stbBloodPressure.Text = StringMayBeEnteredIn(row, "BloodPressure")
                Me.nbxHeadCircum.Value = StringMayBeEnteredIn(row, "HeadCircum")
                Me.nbxBodySurfaceArea.Value = StringMayBeEnteredIn(row, "BodySurfaceArea")
                Me.nbxRespirationRate.Value = StringMayBeEnteredIn(row, "RespirationRate")
                Me.nbxOxygenSaturation.Value = StringMayBeEnteredIn(row, "OxygenSaturation")
                Me.nbxHeartRate.Value = StringMayBeEnteredIn(row, "HeartRate")
                Me.nbxBMI.Value = StringMayBeEnteredIn(row, "BMI")
                Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")
                Me.nbxMUAC.Value = StringMayBeEnteredIn(row, "MUAC")
                Me.stbBMIStatus.Text = StringMayBeEnteredIn(row, "BMIStatus")
                Me.LoadAllergyData(patientNo)
                Me.LoadPostNatal(patientNo)

                Me.LoadObstetricHistory(patientNo)

                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)

                Me.lblMessage.Visible = (GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12)) AndAlso
                                         billMode.ToUpper().Equals(cashAccountNo.ToUpper()))

                Me.grpCoPay.Visible = Not billModesID.ToUpper().Equals(oBillModesID.Cash)


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ShowVisionAssessment(ByVal visitNo As String)

        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()
        Dim visionAssessment As DataTable = oVisionAssessment.GetVisionAssessment(visitNo).Tables("VisionAssessment")

        If visionAssessment Is Nothing OrElse visionAssessment.Rows.Count < 1 Then
            Me.btnVisionAssessment.Text = Me.NewVisionAssessment
            Security.Apply(Me.btnVisionAssessment, AccessRights.Write)
            Me.btnVisionAssessment.Text = Me.NewRefractionVisionAssessment
            Security.Apply(Me.btnVisionAssessment, AccessRights.Write)
            Return

        End If

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnVisionAssessment.Text = Me.EditVisionAssessmentTest
            Security.Apply(Me.btnVisionAssessment, AccessRights.Edit)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visionAssessmentRow As DataRow = visionAssessment.Rows(0)
            Me.stbEyeTest.Text = StringEnteredIn(visionAssessmentRow, "EyeTest")
            Me.StbVisualAcuityRight.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRight")
            Me.StbVisualAcuityRightExt.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRightExt")
            Me.StbVisualAcuityLeft.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeft")
            Me.StbVisualAcuityLeftExt.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeftExt")
            Me.StbPreferentialLookingRight.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingRight")
            Me.StbPreferentialLookingLeft.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingLeft")
            Me.StbEyeNotes.Text = StringMayBeEnteredIn(visionAssessmentRow, "Notes")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If visionAssessment.Rows.Count < 2 Then
                Me.btnVisionAssessmentTwo.Text = Me.NewVisionAssessmentTwo
                Security.Apply(Me.btnVisionAssessmentTwo, AccessRights.Write)
                Return
            End If
            Dim VisionAssessmentrowext As DataRow = visionAssessment.Rows(1)
            Me.btnVisionAssessmentTwo.Text = Me.EditVisionAssessmentTestTwo
            Security.Apply(Me.btnVisionAssessmentTwo, AccessRights.Edit)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbEyeTestEXT.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "EyeTest")
            Me.StbVisualAcuityRightExEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "VisualAcuityRight")
            Me.StbVisualAcuityRightExtEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "VisualAcuityRightExt")
            Me.StbVisualAcuityLeftExEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "VisualAcuityLeft")
            Me.StbVisualAcuityLeftExtEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "VisualAcuityLeftExt")
            Me.StbPreferentialLookingRightEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "PreferentialLookingRight")
            Me.StbPreferentialLookingLeftEXTID.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "PreferentialLookingLeft")
            Me.stbNotesEXT.Text = StringMayBeEnteredIn(VisionAssessmentrowext, "Notes")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ShowRefractionVisionAssessment(ByVal visitNo As String)

        Dim oEyeTestID As New LookupDataID.EyeTestID()
        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()

        Try
            Dim visionAssessment As DataTable = oVisionAssessment.GetVisionAssessment(visitNo, oEyeTestID.Refraction).Tables("VisionAssessment")
            Dim visionAssessmentRow As DataRow = visionAssessment.Rows(0)
            Dim hasRefractionVisionAssessment As Boolean = BooleanMayBeEnteredIn(visionAssessmentRow, "HasRefractionVisionAssessment")

            If Not hasRefractionVisionAssessment Then
                Me.btnRefractionVisionAssessment.Text = Me.NewRefractionVisionAssessment
                Security.Apply(Me.btnRefractionVisionAssessment, AccessRights.Write)
                Return
            Else
                Me.btnRefractionVisionAssessment.Text = Me.EditRefractionVisionAssessment
                Security.Apply(Me.btnRefractionVisionAssessment, AccessRights.Edit)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbEyeTestOptical.Text = StringEnteredIn(visionAssessmentRow, "EyeTest")
                Me.StbVisualAcuityRightOptical.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRight")
                Me.StbVisualAcuityRightExtOptical.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRightExt")
                Me.StbVisualAcuityLeftOptical.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeft")
                Me.StbVisualAcuityLeftExtOptical.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeftExt")
                Me.StbPreferentialLookingRightEXTID.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingRight")
                Me.StbPreferentialLookingLeftEXTID.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingLeft")
                Me.StbEyeNotesOptical.Text = StringMayBeEnteredIn(visionAssessmentRow, "Notes")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub ShowRefractionVision(ByVal visitNo As String)

        Dim oEyeTestID As New LookupDataID.EyeTestID()
        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()

        Try
            Dim visionAssessment As DataTable = oVisionAssessment.GetVisionAssessment(visitNo).Tables("VisionAssessment")
            Dim visionAssessmentRow As DataRow = visionAssessment.Rows(0)
            Dim hasRefractionAssessment As Boolean = BooleanMayBeEnteredIn(visionAssessmentRow, "HasRefractionVisionAssessment")

            If hasRefractionAssessment Then
                Me.btnRefractionVision.Text = Me.NewRefractionVision
                Security.Apply(Me.btnRefractionVision, AccessRights.Write)

            Else
                Me.btnRefractionVision.Text = Me.EditRefractionVision
                Security.Apply(Me.btnRefractionVision, AccessRights.Edit)


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbEyeTestRefraction.Text = StringEnteredIn(visionAssessmentRow, "EyeTest")
                Me.StbVisualAcuityRightRefraction.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRight")
                Me.StbVisualAcuityRightExtRefraction.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityRightExt")
                Me.StbVisualAcuityLeftRefraction.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeft")
                Me.StbVisualAcuityLeftExtRefraction.Text = StringMayBeEnteredIn(visionAssessmentRow, "VisualAcuityLeftExt")
                Me.StbPreferentialLookingRightEXTID.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingRight")
                Me.StbPreferentialLookingLeftEXTID.Text = StringMayBeEnteredIn(visionAssessmentRow, "PreferentialLookingLeft")
                Me.StbEyeNotesRefraction.Text = StringMayBeEnteredIn(visionAssessmentRow, "Notes")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub stbVisitNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        Me.ResetControls()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
                Me.stbVisitNo.Text = currentVisitNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub LoadVisitsData(ByVal visitNo As String)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadDoctorVisit(visitNo)
            Me.LoadLabResults(visitNo)
            Me.LoadClinicalFindings(visitNo)
            Me.LoadLaboratory(visitNo)
            Me.LoadCardiology(visitNo)
            Me.LoadRadiology(visitNo)
            Me.LoadPathology(visitNo)
            Me.LoadPrescriptions(visitNo)
            Me.LoadProcedures(visitNo)
            Me.LoadTheatreServices(visitNo)
            Me.LoadDentalCategoryService(visitNo)
            Me.LoadDentalCategoryLaboratory(visitNo)
            Me.ShowVisionAssessment(visitNo)
            Me.ShowRefractionVisionAssessment(visitNo)
            Me.ShowRefractionVision(visitNo)
            Me.LoadEyeAssessment(visitNo)
            Me.LoadOrthoptics(visitNo)
            Me.LoadOpticalPrescription(visitNo)
            Me.LoadConsumables(visitNo)
            Me.LoadRefraction(visitNo)
            Me.LoadLowVision(visitNo)
            Me.LoadReferrals(visitNo)
            Me.LoadDiagnosis(visitNo)
            Me.LoadCardiologyReports(visitNo)
            Me.LoadRadiologyReports(visitNo)
            Me.LoadPathologyReports(visitNo)
            Me.LoadPathologyImagesData(visitNo)
            Me.LoadChildGrowth(visitNo)
            Me.LoadAntenatal(visitNo)
            Me.LoadPerinatal(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''
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
                Case Me.tpgOptical.Name
                    Me.CalculateBillForConsumables()
                Case Me.tpgHistopathologyRequisition.Name
                    'Me.CalculateBillForPathology()
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then
                        Me.CalculateBillForPathology()
                    End If

                Case Else : ResetControlsIn(Me.pnlBill)

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadVisitsData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadVisitsData(Me.oDigitalPersonaTemplate.ID)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub btnAppointments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppointments.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.btnAppointments.Text.Equals(Me.ScheduleAppointment) Then
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient Number!"))
                Dim fAppointments As New frmAppointments(patientNo)
                fAppointments.Save()
                fAppointments.ShowDialog()
            Else
                Dim fTodayAppointments As New frmTodayAppointments(True)
                fTodayAppointments.ShowDialog(Me)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAddConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fConsumables As New frmConsumables(visitNo)
            fConsumables.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAddExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExtraCharge.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fExtraCharge As New frmExtraCharge(visitNo)
            fExtraCharge.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSelfRequests_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelfRequests.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelfRequests As New frmSelfRequests(True, patientNo)
            fSelfRequests.Save()
            fSelfRequests.ShowDialog()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles btnAdmissions.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim staffFullName As String = StringMayBeEnteredIn(Me.cboStaffNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fAdmissions As New frmAdmissions(visitNo, staffFullName)
            fAdmissions.Save()
            fAdmissions.ShowDialog()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnDoctorVisitClosed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDoctorVisitClosed.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "Closing this visit mean no more changes will be accepted. " +
                                    ControlChars.NewLine + "Are you sure you want to continue?"
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oDoctorVisits
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
                .StaffNo = String.Empty
                .Closed = True
                DisplayMessage(.Update())
            End With

            Me.ManageDoctorVisitClosed(True)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnCancerDiagnosis_Click(sender As System.Object, e As System.EventArgs) Handles btnCancerDiagnosis.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim staffFullName As String = StringMayBeEnteredIn(Me.cboStaffNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fCancerDiagnosis As New frmCancerDiagnosis(visitNo, staffFullName)
            fCancerDiagnosis.ShowDialog()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

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

    Private Sub btnTriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTriage.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fTriage As New frmTriage(visitNo, True)

            If Me.btnTriage.Text.Equals(Me.EditTriageTest) Then
                fTriage.Edit()
                fTriage.Search(visitNo)
            Else : fTriage.Save()
            End If

            fTriage.ShowDialog()
            Me.ShowPatientDetails(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionAssessment.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim fVisionAssessment As frmVisionAssessment

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.btnVisionAssessment.Text.Equals(Me.EditVisionAssessmentTest) Then
                Dim eyeTest As String = StringEnteredIn(Me.stbEyeTest, "Eye Test!")
                Dim eyeTestID As String = GetLookupDataID(LookupObjects.EyeTest, eyeTest)
                fVisionAssessment = New frmVisionAssessment(visitNo, eyeTestID, True)
                fVisionAssessment.Edit()
            Else
                fVisionAssessment = New frmVisionAssessment(visitNo, True)
                fVisionAssessment.Save()
            End If

            fVisionAssessment.ShowDialog()
            Me.ShowVisionAssessment(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnVisionAssessmentTwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionAssessmentTwo.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim fVisionAssessment As frmVisionAssessment
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.btnVisionAssessmentTwo.Text.Equals(Me.EditVisionAssessmentTestTwo) Then
                Dim eyeTest As String = StringEnteredIn(Me.stbEyeTestEXT, "Eye Test!")
                Dim eyeTestID As String = GetLookupDataID(LookupObjects.EyeTest, eyeTest)
                fVisionAssessment = New frmVisionAssessment(visitNo, eyeTestID, True)
                fVisionAssessment.Edit()
            Else
                fVisionAssessment = New frmVisionAssessment(visitNo, True)
                fVisionAssessment.Save()
            End If

            fVisionAssessment.ShowDialog()
            Me.ShowVisionAssessment(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnRefractionVisionAssessment_Click(sender As System.Object, e As System.EventArgs) Handles btnRefractionVisionAssessment.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim fVisionAssessment As frmVisionAssessment

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.btnRefractionVisionAssessment.Text.Equals(Me.EditRefractionVisionAssessment) Then
                Dim eyeTest As String = StringEnteredIn(Me.stbEyeTestOptical, "Eye Test!")
                Dim eyeTestID As String = GetLookupDataID(LookupObjects.EyeTest, eyeTest)
                fVisionAssessment = New frmVisionAssessment(visitNo, eyeTestID, True)
                fVisionAssessment.Edit()
            Else
                fVisionAssessment = New frmVisionAssessment(visitNo, True)
                fVisionAssessment.Save()
            End If

            fVisionAssessment.ShowDialog()
            Me.ShowRefractionVisionAssessment(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnRefractionVision_Click(sender As System.Object, e As System.EventArgs) Handles btnRefractionVision.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim fVisionAssessment As frmVisionAssessment

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.btnRefractionVision.Text.Equals(Me.EditRefractionVision) Then
                Dim eyeTest As String = StringEnteredIn(Me.stbEyeTestRefraction, "Eye Test!")
                Dim eyeTestID As String = GetLookupDataID(LookupObjects.EyeTest, eyeTest)
                fVisionAssessment = New frmVisionAssessment(visitNo, eyeTestID, True)
                fVisionAssessment.Edit()
            Else
                fVisionAssessment = New frmVisionAssessment(visitNo, True)
                fVisionAssessment.Save()
            End If

            fVisionAssessment.ShowDialog()
            Me.ShowRefractionVision(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Save Methods "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim message As String
            Dim oVariousOptions As New VariousOptions()
            Dim oVisitStatusID As New LookupDataID.VisitStatusID()

            Dim oServices As New SyncSoft.SQLDb.Services()
            Dim oPayStatusID As New LookupDataID.PayStatusID()
            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim oServiceCodes As New LookupDataID.ServiceCodes()
            Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim services As DataTable = oServices.GetServices(visitServiceCode).Tables("Services")
            Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()
            Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Check if the current Patient has paid

            If oVariousOptions.AllowAccessCashConsultation.Equals(True) Then

            ElseIf serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) AndAlso
                             Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                             Me.stbBillMode.Text.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
                             servicePayStatusID.ToUpper().Equals(oPayStatusID.NotPaid.ToUpper()) AndAlso
                             oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                             accessCashServices.Equals(False) And hasPaidPackage.Equals(False) AndAlso visitStandardFee > 0 Then

                Throw New ArgumentException("This visit is set not to access cash service before payment. Please check with cashier.")


            ElseIf serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) AndAlso
                        Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                        Me.stbBillMode.Text.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
                        servicePayStatusID.ToUpper().Equals(oPayStatusID.NA.ToUpper()) AndAlso
                        oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                        accessCashServices.Equals(False) And hasPaidPackage.Equals(False) AndAlso visitStandardFee > 0 Then

                Throw New ArgumentException("This visit is set not to access cash service before package payment. Please check with cashier.")
            End If

            ' check if the visit is a self request

            If oVariousOptions.ForceSelfRequestVisitsToPayConsultation AndAlso serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then
                message = "The system is set not to allow Self request visits to access doctor without Paying Consultation"
                Throw New ArgumentException(message)

            End If
            ' Remember to save header if not yet saved
            Me.SaveDoctorVisits()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)

            If Not visitDate.Equals(AppData.NullDateValue) AndAlso Not String.IsNullOrEmpty(visitStatus) AndAlso
               Not visitStatus.ToUpper().Equals(GetLookupDataDes(oVisitStatusID.Doctor).ToUpper()) AndAlso
               visitDate < GetShortDate(Today) Then

                Dim remainingUpdateDays As Integer = (Today - visitDate).Days

                If remainingUpdateDays > oVariousOptions.DoctorVisitUpdateDays Then
                    message = "The visit that you want to update is a past visit that is known to have been completed." +
                                ControlChars.NewLine + "The system is set not to allow changes to a completed visit after " +
                                oVariousOptions.DoctorVisitUpdateDays.ToString() + " day(s)."
                    Throw New ArgumentException(message)
                Else
                    message = "The visit that you want to update is a past visit that is known to have been completed." +
                                ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                End If

            End If



            If oVariousOptions.EnableMemberLimitBalanceTracking Then

                Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
                Dim remainingAmount As Decimal = GetMemberPremiumUsageBalance(billNo)
                If IsPatientSchemeMember(billNo).Equals(True) Then
                    If totalBillConsumption > remainingAmount Then
                        message = "You have exceeded the allowed Credit Limit." +
                                    ControlChars.NewLine + "The system is set not to allow consumption after finishing your allocated Credit " +
                                    remainingAmount.ToString() + " is your current balance!!, Please contact your administrator."
                        Throw New ArgumentException(message)
                    End If
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgTriage.Name
                    DisplayMessage("View Triage Data")

                Case Me.tpgClinicalFindings.Name
                    If Me.tbcClinicalFindings.SelectedTab.Name.Equals(Me.tpgGyn.Name) Then
                        If Me.tbcGyn.SelectedTab.Name.Equals(Me.tpgObstetric.Name) Then Me.SaveObstetricHistory()
                        If Me.tbcGyn.SelectedTab.Name.Equals(Me.tpgAntenatalStage.Name) Then Me.SaveAntenatal()
                        If Me.tbcGyn.SelectedTab.Name.Equals(Me.tpgPerinatal.Name) Then Me.SavePerinatal()

                    End If

                    If Me.tbcClinicalFindings.SelectedTab.Name.Equals(Me.tpgClinicalGeneral.Name) Then
                        Me.SaveClinicalFindings()


                    ElseIf Me.tbcClinicalFindings.SelectedTab.Name.Equals(Me.tpgPaediatrics.Name) Then

                        If Me.tbcPaediatrics.SelectedTab.Name.Equals(Me.tpgChildGrowth.Name) Then Me.SaveChildGrowth()
                        If Me.tbcPaediatrics.SelectedTab.Name.Equals(Me.tpgPostNatal.Name) Then Me.SavePostNatal()

                    End If

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

                Case Me.tpgReferrals.Name
                    Me.SaveReferrals()

                Case Me.tpgDiagnosis.Name
                    Me.SaveDiagnosis()

                Case Me.tpgEye.Name
                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgEyeAssessment.Name) Then Me.SaveEyeAssessment()
                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOrthoptics.Name) Then Me.SaveOrthoptics()
                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgLowVision.Name) Then Me.SaveLowVision()
                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOptical.Name) Then
                        If Me.tbcOptical.SelectedTab.Name.Equals(Me.tpgRefraction.Name) Then Me.SaveRefraction()
                        If Me.tbcOptical.SelectedTab.Name.Equals(Me.tpgOpticalServices.Name) Then Me.SaveOpticalPrescription()
                        If Me.tbcOptical.SelectedTab.Name.Equals(Me.tpgOpticalServices.Name) Then Me.SaveOpticalconsumables()
                    End If

                Case Me.tpgPathology.Name
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then Me.SavePathology()

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Function SaveDoctorVisits() As Boolean

        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()

        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()

        Dim lItems As New List(Of DBConnect)
        Dim lAccounts As New List(Of DBConnect)
        Dim lDoctorVisits As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))

            Dim standardFee As Decimal = GetServicesStaffFee(serviceCode, staffNo, billNo, billModesID, associatedBillNo)


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(staffNo).Tables("Staff").Rows(0)
            doctorLoginID = StringMayBeEnteredIn(staffRow, "LoginID")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim services As DataTable = oServices.GetServices(serviceCode).Tables("Services")
            Dim serviceName As String = services.Rows(0).Item("ServiceName").ToString()
            Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDoctorVisits

                .VisitNo = visitNo
                .StaffNo = staffNo
                .ServiceCode = serviceCode
                .LoginID = CurrentUser.LoginID

                ' Because the header (Doctor Visits) will be part of many activities of the doctor,
                ' save it only if not yet saved

                If .DoctorVisitSaved = False Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.RestrictDoctorLoginID AndAlso Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                        message = "The primary doctor you have selected has a different associated login ID from that " +
                        "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
                       "Contact administrator if you still need to do this."

                        Throw New ArgumentException(message)

                    ElseIf String.IsNullOrEmpty(doctorLoginID) Then

                        message = "The primary doctor you have selected does not have an associated login ID we recommend " +
                       "that you contact the administrator to have this fixed. Else you won’t get system alerts." +
                                               ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                    ElseIf Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                        message = "The primary doctor you have selected has a different associated login ID from that " +
                        "of the current user. If this is a referral, make sure that the visit is referred appropriately; " +
                        "otherwise alerts for this visit won’t be forwarded to you. " +
                                             ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    If serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then
                        message = "The system has detected that this visit was originally registered as self request with no consultation bill. " +
                        "It's advised that you edit To-Bill Service to forward consultation bill. " +
                                             ControlChars.NewLine + "Are you sure you want to continue? "
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                            Me.cboServiceCode.Focus()
                            Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lDoctorVisits.Add(oDoctorVisits)
                    transactions.Add(New TransactionList(Of DBConnect)(lDoctorVisits, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If visitServiceCode.ToUpper().Equals(serviceCode.ToUpper()) AndAlso
                    Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                    Not visitStandardFee.Equals(standardFee) Then

                        Dim lServiceItems As New List(Of DBConnect)
                        Dim lItemsCASH As New List(Of DBConnect)

                        Dim miniTransactions As New List(Of TransactionList(Of DBConnect))

                        Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                        Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

                        Dim quantity As Integer = 1
                        Dim cashAmount As Decimal = CDec(quantity * standardFee * coPayPercent) / 100

                        Using oItems As New SyncSoft.SQLDb.Items()

                            With oItems

                                .VisitNo = visitNo
                                .ItemCode = serviceCode
                                .ItemCategoryID = oItemCategoryID.Service
                                .Quantity = quantity
                                .UnitPrice = standardFee
                                .ItemDetails = serviceName + " Service"
                                .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                                    .ItemStatusID = oItemStatusID.Offered
                                Else : .ItemStatusID = oItemStatusID.Pending
                                End If
                                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, serviceCode, oItemCategoryID.Service).Equals(True) Then
                                    .PayStatusID = oPayStatusID.NA
                                Else
                                    .PayStatusID = oPayStatusID.NotPaid
                                End If
                                .LoginID = CurrentUser.LoginID
                            End With
                            lServiceItems.Add(oItems)
                        End Using

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        miniTransactions.Add(New TransactionList(Of DBConnect)(lServiceItems, Action.Save))

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = visitNo
                                    .ItemCode = serviceCode
                                    .ItemCategoryID = oItemCategoryID.Service
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            miniTransactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        message = "The system has detected that a " + visitServiceName + " fee of " + FormatNumber(visitStandardFee, AppData.DecimalPlaces) +
                                  " was register for this visit. However, " + SubstringLeft(Me.cboStaffNo.Text) + " is set to charge " +
                                  FormatNumber(standardFee, AppData.DecimalPlaces) + ControlChars.NewLine + "Would you like to change to a correct fee?"

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try

                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Exit Try
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            DoTransactions(miniTransactions)
                            Me.ShowPatientDetails(visitNo)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Catch eX As Exception
                            message = eX.Message + ControlChars.NewLine + "Would you like to continue with this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Save action aborted!")

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Using oItemUnitPrice As New SyncSoft.SQLDb.ItemUnitPrice()

                                With oItemUnitPrice

                                    .VisitNo = visitNo
                                    .ItemCategoryID = oItemCategoryID.Service
                                    .ItemCode = serviceCode
                                    .UnitPrice = standardFee

                                    Try
                                        .Update()

                                    Catch innerEx As Exception
                                        Exit Try
                                    End Try

                                End With

                            End Using

                        End Try
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf Not visitServiceCode.ToUpper().Equals(serviceCode.ToUpper()) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        message = "The system has detected that a " + visitServiceName + " service " +
                                  " was register for this visit. However, " + SubstringLeft(Me.cboStaffNo.Text) + " is set to charge for " +
                                  Me.cboServiceCode.Text + ControlChars.NewLine + "Would you like to change to a correct service?"

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try

                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                                serviceCode = visitServiceCode
                                Me.ShowPatientDetails(visitNo)
                                Exit Try
                            End If

                            If Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                                Try

                                    Using oItems As New SyncSoft.SQLDb.Items()
                                        With oItems
                                            .VisitNo = visitNo
                                            .ItemCode = visitServiceCode
                                            .ItemCategoryID = oItemCategoryID.Service

                                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                            .Delete()
                                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                        End With
                                    End Using

                                Catch eX As Exception
                                    message = eX.Message + ControlChars.NewLine + "Would you like to continue with this visit?"
                                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Save action aborted!")
                                End Try

                            End If

                            If Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                                Using oItems As New SyncSoft.SQLDb.Items()

                                    With oItems

                                        .VisitNo = visitNo
                                        .ItemCode = serviceCode
                                        .ItemCategoryID = oItemCategoryID.Service
                                        .Quantity = 1
                                        .UnitPrice = standardFee
                                        .ItemDetails = serviceName + " Service"
                                        .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                        If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                                            .ItemStatusID = oItemStatusID.Offered
                                        Else : .ItemStatusID = oItemStatusID.Pending
                                        End If
                                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, serviceCode, oItemCategoryID.Service).Equals(True) Then
                                            .PayStatusID = oPayStatusID.NA
                                        Else
                                            .PayStatusID = oPayStatusID.NotPaid
                                        End If
                                        .LoginID = CurrentUser.LoginID

                                    End With

                                    Try

                                        oItems.Save()

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        Me.tipBillServiceFeeWords.RemoveAll()
                                        Me.stbBillServiceFee.Text = FormatNumber(standardFee, AppData.DecimalPlaces)
                                        Me.tipBillServiceFeeWords.SetToolTip(Me.stbBillServiceFee, NumberToWords(standardFee))
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                    Catch eX As Exception
                                        Throw eX

                                    End Try

                                End Using
                            Else : Me.stbBillServiceFee.Text = String.Empty
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                        ''This allows billing or services select at Visits, irrespective of where service bill at is
                        ''as long as its not at Visits
                        If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) OrElse
                               Not serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) OrElse
                               (serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) And
                                Not serviceCode.ToUpper().Equals(visitServiceCode.ToUpper())) Then

                            Using oItems As New SyncSoft.SQLDb.Items()
                                With oItems
                                    .VisitNo = visitNo
                                    .ItemCode = serviceCode
                                    .ItemCategoryID = oItemCategoryID.Service
                                    .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                    .PayStatusID = String.Empty
                                    .LoginID = CurrentUser.LoginID
                                    .ItemStatusID = oItemStatusID.Offered
                                End With
                                lItems.Add(oItems)
                            End Using

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                                Dim oEntryModeID As New LookupDataID.EntryModeID()

                                Dim lClaims As New List(Of DBConnect)

                                Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                                Dim lClaimsEXT As New List(Of DBConnect)
                                Dim lClaimDetails As New List(Of DBConnect)

                                Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)
                                Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

                                Using oClaims As New SyncSoft.SQLDb.Claims()

                                    With oClaims

                                        .MedicalCardNo = billNo
                                        .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                        .PatientNo = patientNo
                                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                        .VisitTime = GetTime(Now)
                                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                        .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))
                                        .ClaimStatusID = oClaimStatusID.Pending
                                        .ClaimEntryID = oEntryModeID.System
                                        .LoginID = CurrentUser.LoginID

                                    End With

                                    lClaims.Add(oClaims)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    If String.IsNullOrEmpty(claimNo) Then

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        With oClaimsEXT
                                            .ClaimNo = oClaims.ClaimNo
                                            .VisitNo = visitNo
                                        End With

                                        lClaimsEXT.Add(oClaimsEXT)

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        claimNo = oClaims.ClaimNo
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    End If
                                End Using

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim limitBalance As Decimal
                                Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Service)
                                Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Service)
                                If limitAmount > 0 Then
                                    limitBalance = limitAmount - consumedAmount
                                Else : limitBalance = 0
                                End If

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                                    With oClaimDetails

                                        .ClaimNo = claimNo
                                        .ItemName = serviceName
                                        .BenefitCode = oBenefitCodes.Service
                                        .Quantity = 1
                                        .UnitPrice = visitStandardFee
                                        .Adjustment = 0
                                        .Amount = .Quantity * .UnitPrice
                                        .Notes = serviceName + " offered to Visit No: " + visitNo
                                        .LimitAmount = limitAmount
                                        .ConsumedAmount = consumedAmount
                                        .LimitBalance = limitBalance

                                    End With

                                    lClaimDetails.Add(oClaimDetails)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                End Using

                            End If
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboStaffNo.Enabled = False
                    Me.cboServiceCode.Enabled = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.UpdateVisitStatus(visitNo, oVisitStatusID.Completed)
                    Me.ManageDoctorVisitClosed(False)
                    Me.btnPrintPreviewMedicalReport.Enabled = True
                    If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgGeneral.Name) Then Me.btnPrint.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(doctorLoginID) Then

                        message = "The primary doctor you have selected does not have an associated login ID we recommend " +
                       "that you contact the administrator to have this fixed. Else you won’t get system alerts." +
                                               ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                    ElseIf Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                        message = "The primary doctor you have selected has a different associated login ID from that " +
                        "of the current user. If this is a referral, make sure that the visit is referred appropriately; " +
                        "otherwise alerts for this visit won’t be forwarded to you. " +
                                             ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End With

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub UpdateVisitStatus(ByVal visitNo As String, ByVal visitStatusID As String)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim lVisits As New List(Of DBConnect)

            If String.IsNullOrEmpty(visitNo) Then Return

            With oVisits

                .VisitNo = visitNo
                .VisitStatusID = visitStatusID
                .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                .AccessCashServices = accessCashServices
                .LoginID = String.Empty
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lVisits.Add(oVisits)
            transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Update))

            DoTransactions(transactions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SaveClinicalFindings()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oClinicalFindings As New SyncSoft.SQLDb.ClinicalFindings()

            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update clinical findings for a passed visit." +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            With oClinicalFindings

                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                .PresentingComplaint = StringEnteredIn(Me.stbPresentingComplaint, "Presenting Complaint!")
                .ClinicalNotes = StringMayBeEnteredIn(Me.stbClinicalNotes)
                .ROS = StringMayBeEnteredIn(Me.stbROS)
                .PMH = StringMayBeEnteredIn(Me.stbPMH)
                .POH = StringMayBeEnteredIn(Me.stbPOH)
                .PGH = StringMayBeEnteredIn(Me.stbPGH)
                .FSH = StringMayBeEnteredIn(Me.stbFSH)
                .GeneralAppearance = StringMayBeEnteredIn(Me.stbGeneralAppearance)
                .Respiratory = StringMayBeEnteredIn(Me.stbRespiratory)
                .CVS = StringMayBeEnteredIn(Me.stbCVS)
                .ENT = StringMayBeEnteredIn(Me.stbENT)
                .Abdomen = StringMayBeEnteredIn(Me.stbAbdomen)
                .CNS = StringMayBeEnteredIn(Me.stbCNS)
                .EYE = StringMayBeEnteredIn(Me.stbEYE)
                .MuscularSkeletal = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
                .Skin = StringMayBeEnteredIn(Me.stbSkin)
                .PV = StringMayBeEnteredIn(Me.stbPV)
                .PsychologicalStatus = StringMayBeEnteredIn(Me.stbPsychologicalStatus)
                .ProvisionalDiagnosis = StringEnteredIn(Me.stbProvisionalDiagnosis, "Provisional Diagnosis!")
                .TreatmentPlan = StringMayBeEnteredIn(Me.stbTreatmentPlan)
                .ClinicalImage = BytesMayBeEnteredIn(Me.spbClinicalImage)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.PresentingComplaint) AndAlso String.IsNullOrEmpty(.ClinicalNotes) AndAlso
                String.IsNullOrEmpty(.ROS) AndAlso String.IsNullOrEmpty(.PMH) AndAlso String.IsNullOrEmpty(.POH) AndAlso
                String.IsNullOrEmpty(.PGH) AndAlso String.IsNullOrEmpty(.FSH) AndAlso String.IsNullOrEmpty(.GeneralAppearance) AndAlso
                String.IsNullOrEmpty(.Respiratory) AndAlso String.IsNullOrEmpty(.CVS) AndAlso String.IsNullOrEmpty(.ENT) AndAlso
                String.IsNullOrEmpty(.Abdomen) AndAlso String.IsNullOrEmpty(.CNS) AndAlso String.IsNullOrEmpty(.EYE) AndAlso
                String.IsNullOrEmpty(.MuscularSkeletal) AndAlso String.IsNullOrEmpty(.Skin) AndAlso String.IsNullOrEmpty(.PV) AndAlso
                String.IsNullOrEmpty(.PsychologicalStatus) AndAlso String.IsNullOrEmpty(.ProvisionalDiagnosis) AndAlso
                String.IsNullOrEmpty(.TreatmentPlan) AndAlso .ClinicalImage Is Nothing Then _
                Throw New ArgumentException("Must Register At Least One Item Clinical Findings!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                clinicalFindingsSaved = True
                DisplayMessage("Clinical Findings Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub SaveEyeAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oEyeAssessment As New SyncSoft.SQLDb.EyeAssessment()
            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update eye assessment for a passed visit." +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            With oEyeAssessment

                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
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
                Dim rightIOP As String = StringMayBeEnteredIn(Me.nbxRightIOP)
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
                Throw New ArgumentException("Must Register At Least One Item Eye Assessment!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                eyeAssessmentSaved = True
                DisplayMessage("Eye Assessment Successfully Saved!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Public Sub SaveOrthoptics()

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oOrthoptics As New SyncSoft.SQLDb.Orthoptics()
            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update orthoptics for a passed visit." +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            With oOrthoptics

                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
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
                orthopticsSaved = True
                DisplayMessage("Orthoptics Assessment Successfully Saved!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub SaveRefraction()

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oRefraction As New SyncSoft.SQLDb.Refraction()
            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update Refraction for a passed visit." +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            With oRefraction
                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                .RightMRSPH = StringMayBeEnteredIn(Me.stbRightMRSPH)
                .LeftMRSPH = StringMayBeEnteredIn(Me.stbLeftMRSPH)
                .RightMRCYL = StringMayBeEnteredIn(Me.stbRightMRCYL)
                .LeftMRCYL = StringMayBeEnteredIn(Me.stbLeftMRCYL)
                .RightMRAXIS = StringMayBeEnteredIn(Me.stbRightMRAXIS)
                .LeftMRAXIS = StringMayBeEnteredIn(Me.stbLeftMRAXIS)
                .RightCRSPH = StringMayBeEnteredIn(Me.stbRightCRSPH)
                .LeftCRSPH = StringMayBeEnteredIn(Me.stbLeftCRSPH)
                .RightCRCYL = StringMayBeEnteredIn(Me.stbRightCRCYL)
                .LeftCRCYL = StringMayBeEnteredIn(Me.stbLeftCRCYL)
                .RightCRAXIS = StringMayBeEnteredIn(Me.stbRightCRAXIS)
                .LeftCRAXIS = StringMayBeEnteredIn(Me.stbLeftCRAXIS)
                .RightPCRSPH = StringMayBeEnteredIn(Me.stbRightPCRSPH)
                .LeftPCRSPH = StringMayBeEnteredIn(Me.stbLeftPCRSPH)
                .RightPCRCYL = StringMayBeEnteredIn(Me.stbRightPCRCYL)
                .LeftPCRCYL = StringMayBeEnteredIn(Me.stbLeftPCRCYL)
                .RightPCRAXIS = StringMayBeEnteredIn(Me.stbRightPCRAXIS)
                .LeftPCRRAXIS = StringMayBeEnteredIn(Me.stbLeftPCRRAXIS)
                .PD = StringMayBeEnteredIn(Me.stbPD)
                .segmentHeights = StringMayBeEnteredIn(Me.stbSegmentHeights)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.RightMRSPH) AndAlso String.IsNullOrEmpty(.LeftMRSPH) AndAlso String.IsNullOrEmpty(.RightMRCYL) AndAlso String.IsNullOrEmpty(.LeftMRCYL) AndAlso
                String.IsNullOrEmpty(.RightMRAXIS) AndAlso String.IsNullOrEmpty(.LeftMRAXIS) AndAlso String.IsNullOrEmpty(.RightCRSPH) AndAlso
                String.IsNullOrEmpty(.LeftCRSPH) AndAlso String.IsNullOrEmpty(.RightCRCYL) AndAlso String.IsNullOrEmpty(.LeftCRCYL) AndAlso
                String.IsNullOrEmpty(.RightCRAXIS) AndAlso String.IsNullOrEmpty(.LeftCRAXIS) AndAlso String.IsNullOrEmpty(.RightPCRSPH) AndAlso
                String.IsNullOrEmpty(.LeftPCRSPH) AndAlso String.IsNullOrEmpty(.RightPCRCYL) AndAlso String.IsNullOrEmpty(.RightPCRAXIS) AndAlso
                String.IsNullOrEmpty(.LeftPCRRAXIS) AndAlso String.IsNullOrEmpty(.PD) AndAlso String.IsNullOrEmpty(.segmentHeights) Then _
                Throw New ArgumentException("Must Register At Least One Refraction Item !")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                refractionSaved = True
                DisplayMessage("Refraction Successfully Saved!")

            End With
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SaveLowVision()

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oLowVision As New SyncSoft.SQLDb.LowVision()
            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update Low Vision for a passed visit." +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If
            With oLowVision
                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                .BriefHistory = StringMayBeEnteredIn(Me.stbBriefHistory)
                .Profession = StringMayBeEnteredIn(Me.stbProfession)
                .MajorOcularDiagnosisRE = StringMayBeEnteredIn(Me.stbMajorOcularDiagnosisRE)
                .MajorOcularDiagnosisLE = StringMayBeEnteredIn(Me.stbMajorOcularDiagnosisLE)
                .OtherOcularDiagnosisRE = StringMayBeEnteredIn(Me.stbOtherOcularDiagnosisRE)
                .OtherOcularDiagnosisLE = StringMayBeEnteredIn(Me.stbOtherOcularDiagnosisLE)
                .OphthalmologistSeenID = StringValueEnteredIn(Me.cboOphthalmologistSeenID, "Ophthalmologist Seen")
                .OtherImpairmentsID = StringValueEnteredIn(Me.cboOtherImpairmentsId, "Other Impairments")
                .OtherImpairments = StringMayBeEnteredIn(Me.stbOtherImpairments)
                .ExistingTreatmentFarRE = StringMayBeEnteredIn(Me.stbExistingTreatmentFarRE)
                .ExistingTreatmentFarLE = StringMayBeEnteredIn(Me.stbExistingTreatmentFarLE)
                .ExistingTreatmentNearRE = StringMayBeEnteredIn(Me.stbExistingTreatmentNearRE)
                .ExistingTreatmentNearLE = StringMayBeEnteredIn(Me.stbExistingTreatmentNearLE)
                .NewTreatmentFarRE = StringMayBeEnteredIn(Me.stbNewTreatmentFarRE)
                .NewTreatmentFarLE = StringMayBeEnteredIn(Me.stbNewTreatmentFarLE)
                .NewTreatmentNearRE = StringMayBeEnteredIn(Me.stbNewTreatmentNearRE)
                .NewTreatmentNearLE = StringMayBeEnteredIn(Me.stbNewTreatmentNearLE)
                .ExistingVisualAcuityFarLEID = StringValueEnteredIn(Me.cboExistingVisualAcuityFarLEID, "Existing Visual Acuity Far Left Eye")
                .ExistingVisualAcuityFarREID = StringValueEnteredIn(Me.cboExistingVisualAcuityFarREID, "Existing Visual Acuity Far Right Eye")
                .ExistingVisualAcuityNearLEID = StringValueEnteredIn(Me.cboExistingVisualAcuityNearLEID, "Existing Visual Acuity Near Left Eye")
                .ExistingVisualAcuityNearREID = StringValueEnteredIn(Me.cboExistingVisualAcuityNearREID, "Existing Visual Acuity Near Right Eye")
                .NewVisualAcuityFarLEID = StringValueEnteredIn(Me.cboNewVisualAcuityFarLEID, "New Visual Acuity Far Left Eye")
                .NewVisualAcuityFarREID = StringValueEnteredIn(Me.cboNewVisualAcuityFarREID, "New Visual Acuity Far Right Eye")
                .NewVisualAcuityNearLEID = StringValueEnteredIn(Me.cboNewVisualAcuityNearLEID, "New Visual Acuity Near Left Eye")
                .NewVisualAcuityNearREID = StringValueEnteredIn(Me.cboNewVisualAcuityNearREID, "New Visual Acuity Near Right Eye")
                .ExistingLVDsNear = StringToSplitSelectedInAtleastOne(Me.clbExistingLVDsNear, LookupObjects.LowVisionDevicesNear, "Existing LVDs Near")
                .ExistingLVDsFar = StringToSplitSelectedInAtleastOne(Me.clbExistingLVDsFar, LookupObjects.LowVisionDevicesFar, "Existing LVDs Far")
                .ProblemEncounteredLVDsNear = StringMayBeEnteredIn(Me.stbProblemEncounteredLVDsNear)
                .ProblemEncounteredLVDsFar = StringMayBeEnteredIn(Me.stbProblemEncounteredLVDsFar)
                .ColourVisionDefectID = StringValueEnteredIn(Me.cboColourVisionDefectID, "Colour Vision Defect")
                .ColourVisionTestUsed = StringMayBeEnteredIn(Me.stbColourVisionTestUsed)
                .ContrastSensitivityID = StringValueEnteredIn(Me.cboContrastSensitivityID, "Contrast Sensitivity")
                .ContrastSensitivityTestUsed = StringMayBeEnteredIn(Me.stbContrastSensitivityTestUsed)
                .VisualFieldDefectID = StringValueEnteredIn(Me.cboVisualFieldDefectID, "Visual Field Defect")
                .VisualFieldDefectTestUsed = StringMayBeEnteredIn(Me.stbVisualFieldDefectTestUsed)
                .LowVisionDevicesFar = StringToSplitSelectedInAtleastOne(Me.clbLowVisionDevicesFar, LookupObjects.LowVisionDevicesFar, "Low Vision Devices Far")
                .LowVisionDevicesNear = StringToSplitSelectedInAtleastOne(Me.clbLowVisionDevicesNear, LookupObjects.LowVisionDevicesNear, "Low Vision Devices Near")
                .NonOpticalAids = StringToSplitSelectedInAtleastOne(Me.clbNonOpticalAids, LookupObjects.NonOpticalAids, "Non Optical Aids")
                .Advice = StringMayBeEnteredIn(Me.stbAdvice)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.BriefHistory) AndAlso String.IsNullOrEmpty(.Profession) AndAlso String.IsNullOrEmpty(.MajorOcularDiagnosisRE) AndAlso String.IsNullOrEmpty(.MajorOcularDiagnosisLE) AndAlso
                String.IsNullOrEmpty(.OtherOcularDiagnosisRE) AndAlso String.IsNullOrEmpty(.OtherOcularDiagnosisLE) AndAlso String.IsNullOrEmpty(.OtherImpairmentsID) AndAlso String.IsNullOrEmpty(.OtherImpairments) AndAlso
                String.IsNullOrEmpty(.ExistingTreatmentFarLE) AndAlso String.IsNullOrEmpty(.ExistingTreatmentFarRE) AndAlso String.IsNullOrEmpty(.ExistingTreatmentNearLE) AndAlso String.IsNullOrEmpty(.ExistingTreatmentNearRE) AndAlso
                String.IsNullOrEmpty(.NewTreatmentFarLE) AndAlso String.IsNullOrEmpty(.NewTreatmentFarRE) AndAlso String.IsNullOrEmpty(.NewTreatmentNearLE) AndAlso String.IsNullOrEmpty(.NewTreatmentNearRE) AndAlso
                String.IsNullOrEmpty(.ExistingVisualAcuityFarLEID) AndAlso String.IsNullOrEmpty(.ExistingVisualAcuityFarREID) AndAlso String.IsNullOrEmpty(.ExistingVisualAcuityNearLEID) AndAlso String.IsNullOrEmpty(.ExistingVisualAcuityNearREID) AndAlso
                String.IsNullOrEmpty(.NewVisualAcuityFarLEID) AndAlso String.IsNullOrEmpty(.NewVisualAcuityFarREID) AndAlso String.IsNullOrEmpty(.NewVisualAcuityNearLEID) AndAlso String.IsNullOrEmpty(.NewVisualAcuityNearREID) AndAlso
                String.IsNullOrEmpty(.ExistingLVDsNear) AndAlso String.IsNullOrEmpty(.ExistingLVDsFar) AndAlso
                String.IsNullOrEmpty(.ProblemEncounteredLVDsNear) AndAlso String.IsNullOrEmpty(.ProblemEncounteredLVDsFar) AndAlso
                String.IsNullOrEmpty(.ColourVisionTestUsed) AndAlso String.IsNullOrEmpty(.ContrastSensitivityTestUsed) AndAlso
                String.IsNullOrEmpty(.VisualFieldDefectTestUsed) AndAlso String.IsNullOrEmpty(.LowVisionDevicesFar) AndAlso String.IsNullOrEmpty(.LowVisionDevicesNear) AndAlso
                String.IsNullOrEmpty(.NonOpticalAids) AndAlso String.IsNullOrEmpty(.Advice) Then _
                Throw New ArgumentException("Must Register At Least One Low Vision Item !")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lowVisionSaved = True
                DisplayMessage("Low Vision Successfully Saved!")

            End With
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SaveLaboratory()

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim billNo As String = StringMayBeEnteredIn(stbBillNo)
        Dim oVariousOptions As New VariousOptions()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvLabTests.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Lab Test!")

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.ColLabTestCode, "test!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
            Next

            Dim quantity As Integer = 1
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
                Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.ColLabTestCode))
                Dim testName As String = RevertText(StringEnteredIn(cells, Me.colTest))
                Dim details As String = StringMayBeEnteredIn(cells, Me.ColTestNotes)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try
                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = details
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Test
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Test).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim lservicePoints As New List(Of String)
                    Dim oServicePoint As New LookupDataID.ServicePointID()
                    lservicePoints.Add(oServicePoint.Laboratory())
                    Dim lWaitingPatient As New List(Of DBConnect)

                    If (Me.billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper)) Then
                        lservicePoints.Add(oServicePoint.Cashier())
                    End If

                    ''''make queue
                    lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Doctor(), Me.priorityID, lservicePoints)
                    transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Test
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If



                    
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.LabRequests
                                        .VisitNo = visitNo
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvLabTests.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveCardiology()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvCardiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for Cardiology examinations!")

            For Each row As DataGridViewRow In Me.dgvCardiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colCardiologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colCardiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colCardiologyIndication, "Indication!")
            Next

            Dim quantity As Integer = 1
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colCardiologyExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colCardiologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colCardiologyIndication, "Indication!")
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Cardiology
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Cardiology).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Cardiology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lservicePoints As New List(Of String)
                    Dim oServicePoint As New LookupDataID.ServicePointID()
                    lservicePoints.Add(oServicePoint.Cardiology())
                    Dim lWaitingPatient As New List(Of DBConnect)

                    If (Me.billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper)) Then
                        lservicePoints.Add(oServicePoint.Cashier())
                    End If

                    ''''make queue
                    lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Doctor(), Me.priorityID, lservicePoints)
                    transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Cardiology
                                        .VisitNo = visitNo
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvRadiology.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for radiology examinations!")

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colRadiologyIndication, "Indication!")
            Next

            Dim quantity As Integer = 1
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colRadiologyIndication, "Indication!")
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Radiology
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Radiology).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Radiology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lservicePoints As New List(Of String)
                    Dim oServicePoint As New LookupDataID.ServicePointID()
                    lservicePoints.Add(oServicePoint.Radiology())
                    Dim lWaitingPatient As New List(Of DBConnect)

                    If (Me.billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper)) Then
                        lservicePoints.Add(oServicePoint.Cashier())
                    End If

                    ''''make queue
                    lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Doctor(), Me.priorityID, lservicePoints)
                    transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Radiology
                                        .VisitNo = visitNo
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub SavePathology()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvHistopathologyRequisition.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for pathology examinations!")

            For Each row As DataGridViewRow In Me.dgvHistopathologyRequisition.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colPathologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colPathologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colPathologyIndication, "Indication!")
            Next

            Dim quantity As Integer = 1
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvHistopathologyRequisition.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colPathologyExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colPathologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colPathologyIndication, "Indication!")
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Pathology
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Pathology).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Pathology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Pathology
                                        .VisitNo = visitNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Pathology sent"
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

    Private Sub SavePrescriptions()

        Dim message As String
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oVariousOptions As New VariousOptions()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

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

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim lItemsEXT As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                If quantity < 0 Then
                    Throw New ArgumentException("Negative values not allowed for quantity at position " + (rowNo + 1).ToString())

                End If

                Try


                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemStatusID = oItemStatusID.Pending

                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Drug).Equals(True) Then

                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then

                            Dim drugName As String = StringEnteredIn(cells, Me.colDrug)
                            Dim availableStock As Integer = GetAvailableStock(oItems.ItemCode)
                             Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                            Dim halted As Boolean = BooleanMayBeEnteredIn(cells, Me.colHalted)
                            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasAlternateDrugs)
                            Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                            Dim expiryWarningDays As Integer = oVariousOptions.ExpiryWarningDays
                            Dim expiryRemainingDays As Integer = (expiryDate - Today).Days

                            If halted Then
                                If hasAlternateDrugs Then
                                    message = "Drug: " + drugName + " is currently on halt and has registered alternatives. " +
                                                    "The system does not allow prescription of a drug on halt. " +
                                                    ControlChars.NewLine + "Would you like to look at its alternatives? "
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oItems.ItemCode)
                                Else
                                    message = "Drug: " + drugName + " is currently on halt and has no registered alternatives. " +
                                                "The system does not allow prescription of a drug on halt!"
                                    DisplayMessage(message)
                                End If

                                Continue For

                            ElseIf oItems.Quantity > 0 AndAlso availableStock < oItems.Quantity Then
                                If Not oVariousOptions.AllowPrescriptionToNegative() Then
                                    If hasAlternateDrugs Then
                                        message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                          (oItems.Quantity - availableStock).ToString() + " and has registered alternatives. " +
                                          "The system does not allow a prescription of a drug that is out of stock. " +
                                          "Please notify Pharmacy to re-stock appropriately. " +
                                           ControlChars.NewLine + "Would you like to look at its alternatives? "
                                        If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oItems.ItemCode)
                                    Else
                                        message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                            (oItems.Quantity - availableStock).ToString() + " and has no registered alternatives. " +
                                            "The system does not allow a prescription of a drug that is out of stock. " +
                                            "Please notify Pharmacy to re-stock appropriately!"
                                        DisplayMessage(message)
                                    End If
                                    Continue For
                                Else
                                    message = "Insufficient stock to dispense for " + drugName +
                                              " with a deficit of " + (oItems.Quantity - availableStock).ToString() +
                                              ControlChars.NewLine + "Are you sure you want to continue?"
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then
                                        If hasAlternateDrugs Then
                                            message = "Would you like to look at " + drugName + " alternatives? "
                                            If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oItems.ItemCode)
                                        End If
                                        Continue For
                                    End If
                                End If

                            ElseIf orderLevel >= availableStock - oItems.Quantity Then
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

                            ElseIf expiryDate > AppData.NullDateValue AndAlso expiryRemainingDays <= expiryWarningDays Then
                                message = "Drug: " + drugName + " has " + expiryRemainingDays.ToString() +
                                    " remaining day(s) to expire. Please notify Pharmacy to re-stock appropriately!"
                                DisplayMessage(message)

                            ElseIf expiryDate = AppData.NullDateValue Then
                                message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                                DisplayMessage(message)
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lItems.Add(oItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lservicePoints As New List(Of String)
                    Dim oServicePoint As New LookupDataID.ServicePointID()
                    lservicePoints.Add(oServicePoint.Pharmacy())
                    Dim lWaitingPatient As New List(Of DBConnect)

                    If (Me.billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper)) Then
                        lservicePoints.Add(oServicePoint.Cashier())
                    End If

                    ''''make queue
                    lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Visit(), Me.priorityID, lservicePoints)
                    transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Using oItemsEXT As New SyncSoft.SQLDb.ItemsEXT()
                        With oItemsEXT
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Dosage = StringEnteredIn(cells, Me.colDosage)
                            .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lItemsEXT.Add(oItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsEXT, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Drug
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lItemsCASH.Add(oItemsCASH)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .VisitNo = visitNo
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvPrescription.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If Not (serviceCode.ToUpper().Equals(oServiceCodes.Review.ToUpper())) AndAlso OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(False) AndAlso oVariousOptions.AllowDrugsServiceFee AndAlso Me.dgvPrescription.RowCount > 0 Then
                Dim oServices As New SyncSoft.SQLDb.Services()
                Dim services As DataTable = oServices.GetServices(oServiceCodes.ServiceFee).Tables("Services")
                Dim servicesRow As DataRow = services.Rows(0)
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(servicesRow, "StandardFee")
                Dim serviceName As String = StringMayBeEnteredIn(servicesRow, "ServiceName")

                Using oItems As New SyncSoft.SQLDb.Items()
                    With oItems
                        .VisitNo = visitNo
                        .ItemCode = oServiceCodes.ServiceFee
                        .Quantity = 1
                        .UnitPrice = unitPrice
                        .ItemDetails = serviceName
                        .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .ItemCategoryID = oItemCategoryID.Service
                        .ItemStatusID = oItemStatusID.Pending
                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, oServiceCodes.ServiceFee, oItemCategoryID.Service).Equals(True) Then
                            .PayStatusID = oPayStatusID.NA
                        Else
                            .PayStatusID = oPayStatusID.NotPaid
                        End If
                        .LoginID = CurrentUser.LoginID
                        .Save()

                    End With
                End Using
            End If


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
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for procedure!")

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "procedure!")
                IntegerEnteredIn(row.Cells, Me.colProcedureQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "unit price!")
            Next

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Procedure
                                        .VisitNo = visitNo
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

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvTheatre.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for theatre!")

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreService, "theatre!")
                IntegerEnteredIn(row.Cells, Me.colTheatreQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "unit price!")
            Next

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colICDTheatreCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Theatre
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Theatre
                                        .VisitNo = visitNo
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
            'Me.dgvTheatre.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveDentalCategoryService()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvDental.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for dental service!")

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                IntegerEnteredIn(row.Cells, Me.colDentalQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalNotes, "Notes!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
            Next

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDentalCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colDentalNotes, "Notes!")
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Dental
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID
                        End With
                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Dental
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Dental
                                        .VisitNo = visitNo
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDental.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveDentalCategoryLaboratory()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvDentalLab.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for dental Lab!")

            For Each row As DataGridViewRow In Me.dgvDentalLab.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalLabCode, "Dental!")
                IntegerEnteredIn(row.Cells, Me.colDentalLabQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalLabNotes, "Notes!")
                DecimalEnteredIn(row.Cells, Me.colDentalLabUnitPrice, False, "Unit Price!")
            Next

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDentalLab.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDentalLabCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalLabQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalLabUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colDentalLabNotes, "Notes!")
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Dental
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID
                        End With
                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Dental
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Dental
                                        .VisitNo = visitNo
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDentalLab.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveOpticalPrescription()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oOptical As New SyncSoft.SQLDb.Optical()

            If DateMayBeEnteredIn(Me.stbVisitDate) < CDate(FormatDate(Today)) Then
                Dim message As String = "You are trying to update optical prescription for a passed visit. " +
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            With oOptical

                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                .RightSPH = StringMayBeEnteredIn(Me.stbRightSPH)
                .RightCYL = StringMayBeEnteredIn(Me.stbRightCYL)
                .RightAXIS = StringMayBeEnteredIn(Me.stbRightAXIS)
                .RightPRISM = StringMayBeEnteredIn(Me.stbRightPRISM)
                .RightADD = StringMayBeEnteredIn(Me.stbRightADD)
                .LeftSPH = StringMayBeEnteredIn(Me.stbLeftSPH)
                .LeftCYL = StringMayBeEnteredIn(Me.stbLeftCYL)
                .LeftAXIS = StringMayBeEnteredIn(Me.stbLeftAXIS)
                .LeftPRISM = StringMayBeEnteredIn(Me.stbLeftPRISM)
                .LeftADD = StringMayBeEnteredIn(Me.stbLeftADD)
                .Pd = IntegerMayBeEnteredIn(Me.nbxPd, -1)
                .Sg = IntegerMayBeEnteredIn(Me.nbxSg, -1)
                .LenseTypeID = StringValueEnteredIn(Me.cboLenseTypeID, "Lense Type!")
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.RightSPH) AndAlso String.IsNullOrEmpty(.RightCYL) AndAlso String.IsNullOrEmpty(.RightAXIS) AndAlso
                String.IsNullOrEmpty(.RightPRISM) AndAlso String.IsNullOrEmpty(.RightADD) AndAlso String.IsNullOrEmpty(.LeftSPH) AndAlso
                String.IsNullOrEmpty(.LeftCYL) AndAlso String.IsNullOrEmpty(.LeftAXIS) AndAlso String.IsNullOrEmpty(.LeftPRISM) AndAlso
                String.IsNullOrEmpty(.LeftADD) Then Throw New ArgumentException("Must Register At Least One Item Optical Prescription!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                opticalPrescriptionSaved = True
                DisplayMessage("Optical Prescription Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveOpticalconsumables()

        Dim message As String

        Dim oVariousOptions As New VariousOptions()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvConsumables.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for consumable item!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Dim consumableNo As String = RevertText(StringEnteredIn(row.Cells, Me.ColConsumableCode, "Consumable Number!"))
                Dim consumableName As String = StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Name!")
                IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = RevertText(StringEnteredIn(cells, Me.ColConsumableCode))
                Dim consumableName As String = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False)

                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    If quantity > 0 AndAlso unitsInStock < quantity Then
                        If Not oVariousOptions.AllowPrescriptionToNegative() Then

                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                               ControlChars.NewLine + "The system does not allow to give a consumable that is out of stock. " +
                               "Please re-stock appropriately! "

                            Throw New ArgumentException(message)
                        Else
                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf orderLevel >= unitsInStock - quantity Then

                        message = "Stock level for " + consumableName + " is running low. Please re-stock appropriately!"
                        DisplayMessage(message)

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredConsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " + ControlChars.NewLine +
                                "The system does not allow to give a consumable that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + consumableName + " had reached. " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + consumableName + " is not set. The system can not verify when this consumable will expire!"
                        DisplayMessage(message)

                    End If

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = consumableNo
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemStatusID = oItemStatusID.Pending
                            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = consumableNo
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Consumable
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Consumable(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.OpenIssueConsumablesAfterPrescription Then

                Dim hasPendingItems As Boolean = False
                message = "Would you like to open issue consumables now?"

                For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value) = True Then
                        Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableItemStatus)
                        If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                            hasPendingItems = True
                            Exit For
                        End If
                    End If
                    hasPendingItems = False
                Next

                If hasPendingItems AndAlso WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIssueConsumables As New frmIssueConsumables(visitNo)
                    fIssueConsumables.ShowDialog()
                    Me.LoadConsumables(visitNo)
                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveReferrals()

        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oReferrals As New SyncSoft.SQLDb.Referrals()
            Dim lReferrals As New List(Of DBConnect)

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
            Dim lDoctorVisits As New List(Of DBConnect)

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))

            With oReferrals

                .VisitNo = visitNo
                .ReferralDate = DateEnteredIn(Me.dtpReferralDate, "Referral Date!")
                .ReferredBy = SubstringEnteredIn(Me.cboStaffNo, "Referred By!")
                .DoctorSpecialtyID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                If Me.cboReferredTo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboReferredTo.Text) Then
                    .ReferredTo = SubstringEnteredIn(Me.cboReferredTo, "Referred To!")
                Else : .ReferredTo = String.Empty
                End If
                .ReferralNotes = StringEnteredIn(Me.stbReferralNotes, "Referral Notes!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lReferrals.Add(oReferrals)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            With oDoctorVisits

                .VisitNo = visitNo
                '.StaffNo = SubstringEnteredIn(Me.cboReferredTo, "Referred To!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lDoctorVisits.Add(oDoctorVisits)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            transactions.Add(New TransactionList(Of DBConnect)(lReferrals, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lDoctorVisits, Action.Delete, "DoctorVisits"))

            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.UpdateVisitStatus(visitNo, oVisitStatusID.Doctor)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboStaffNo.SelectedIndex = -1
            Me.cboStaffNo.SelectedIndex = -1
            Me.cboStaffNo.Enabled = True

            Me.cboServiceCode.SelectedIndex = -1
            Me.cboServiceCode.SelectedIndex = -1
            Me.cboServiceCode.Enabled = True

            DisplayMessage("Referral Successfully Saved!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lDiagnosis As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                Try

                    Using oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
                        With oDiagnosis
                            .VisitNo = visitNo
                            .DiseaseCode = StringEnteredIn(cells, Me.colICDDiagnosisCode)
                            .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lDiagnosis.Add(oDiagnosis)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDiagnosis, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim oBillModesID As New LookupDataID.BillModesID()
                    Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                        Dim oEntryModeID As New LookupDataID.EntryModeID()

                        Dim lClaims As New List(Of DBConnect)

                        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                        Dim lClaimsEXT As New List(Of DBConnect)
                        Dim lClaimDiagnosis As New List(Of DBConnect)

                        Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
                        Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)
                        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

                        Using oClaims As New SyncSoft.SQLDb.Claims()

                            With oClaims

                                .MedicalCardNo = billNo
                                .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                .PatientNo = patientNo
                                .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .VisitTime = GetTime(Now)
                                .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))
                                .ClaimStatusID = oClaimStatusID.Pending
                                .ClaimEntryID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID

                            End With

                            lClaims.Add(oClaims)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If String.IsNullOrEmpty(claimNo) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                With oClaimsEXT
                                    .ClaimNo = oClaims.ClaimNo
                                    .VisitNo = visitNo
                                End With

                                lClaimsEXT.Add(oClaimsEXT)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                claimNo = oClaims.ClaimNo
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If
                        End Using

                        Using oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

                            With oClaimDiagnosis
                                .ClaimNo = claimNo
                                .DiseaseCode = StringEnteredIn(cells, Me.colICDDiagnosisCode, "Disease Code!")
                            End With

                            lClaimDiagnosis.Add(oClaimDiagnosis)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lClaimDiagnosis, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End Using

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True
                    Me.LoadDiseaseAttachedPrescriptions(StringEnteredIn(cells, Me.colICDDiagnosisCode))
                    Me.LoadDiseaseAttachedLabTests(StringEnteredIn(cells, Me.colICDDiagnosisCode))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "SAVE OPTIONS"
    Private Sub SaveAntenatal()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oAntenatal As New SyncSoft.SQLDb.Antenatal()
            With oAntenatal
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .Infection = StringValueMayBeEnteredIn(Me.cboInfection, "Infection!")
                .InfectionDetails = StringMayBeEnteredIn(Me.stbInfectionDetails)
                .AccidentDuringPregnancy = StringValueMayBeEnteredIn(Me.cboAccidentDuringPregnancy, "Accident During Pregnancy!")
                .DetailsOfAccident = StringMayBeEnteredIn(Me.stbDetailsOfAccident)
                .UseOfDrugsOrPrescription = StringValueMayBeEnteredIn(Me.cboUseOfDrugsOrPrescription, "Use Of Drugs Or Prescription!")
                .DrugDetails = StringMayBeEnteredIn(Me.stbDrugDetails)
                .Smoking = StringValueEnteredIn(Me.cboSmoking, "Smoking!")
                .ChronicIllness = StringValueMayBeEnteredIn(Me.cboChronicIllness, "Chronic Illness!")
                .DetailsOfIllness = StringMayBeEnteredIn(Me.stbDetailsOfIllness)

                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                antenatalStageSaved = True
                DisplayMessage("Antenatal Details Successfully Saved!")
            End With


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try


    End Sub

    Private Sub SavePerinatal()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oPerinatal As New SyncSoft.SQLDb.Perinatal()
            With oPerinatal
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .ModeOfDelivery = StringValueEnteredIn(Me.cboModeOfDelivery, "Mode Of Delivery!")
                .DurationOfLabour = CSng(CStr(CSng(StringMayBeEnteredIn(Me.nbxDurationOfLabour))))
                .DeliveryComplications = StringValueEnteredIn(Me.cboDeliveryComplications, "Delivery Complications!")
                .AmountOfBloodLoss = CSng(StringMayBeEnteredIn(Me.nbxAmountOfBloodLoss))
                .MothersCondition = StringValueMayBeEnteredIn(Me.cboMothersCondition)
                .DetailsOfCondition = StringMayBeEnteredIn(Me.stbDetailsOfCondition)
                .BabyAlive = StringValueMayBeEnteredIn(Me.cboBabyAlive)
                .CauseOfDeath = StringValueMayBeEnteredIn(Me.cboCauseOfDeath, "Cause Of Death!")
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                PerinatalSaved = True
                DisplayMessage("Perinatal Details Successfully Saved!")
            End With


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try


    End Sub
    'Private Sub SaveChronicDiseases()


    '    Dim oChronicDiseases As New SyncSoft.SQLDb.Patients()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor()

    '        With oChronicDiseases
    '            .PatientNo = RevertText(StringEnteredIn(stbPatientNo, "Patient's No!"))
    '            .ChronicDiseases = StringToSplitSelectedIn(Me.clbChronicDiseases, LookupObjects.ChronicDiseases)
    '            '.LoginID = CurrentUser.LoginID


    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            ValidateEntriesIn(Me)
    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            .Save()

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            DisplayMessage("Chronic Diseases Successfully Saved!")

    '        End With


    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default()

    '    End Try


    'End Sub

    Private Sub SaveObstetricHistory()


        Dim oObstetricHistory As New SyncSoft.SQLDb.ObstetricHistory()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oObstetricHistory
                .PatientNo = RevertText(StringEnteredIn(stbPatientNo, "Patient's No!"))
                .Gravidity = Me.nbxGravidity.GetInteger()
                .Parity = Me.nbxParity.GetInteger()
                .NoOfSurvivingChildren = Me.nbxNoOfSurvivingChildren.GetInteger()
                .LMP = DateMayBeEnteredIn(Me.dtpLMP)
                .EDD = DateMayBeEnteredIn(Me.dtpEDD)
                .GestationalAgeInWks = Me.nbxGestationalAgeInWks.GetInteger()
                .StillBirth = StringValueMayBeEnteredIn(Me.cboStillBirth)
                .NoOfStillBirths = IntegerValueMayBeEnteredIn(Me.nbxNoOfStillBirths)
                .Abortions = StringValueMayBeEnteredIn(Me.cboAbortions)
                .NoOfAbortions = IntegerValueMayBeEnteredIn(Me.nbxNoOfAbortions)
                .Caesarian = StringValueMayBeEnteredIn(Me.cboCaesarian)
                .NoOfCaesarians = IntegerValueMayBeEnteredIn(Me.nbxNoOfCaesarians)

                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                obstetricHistorySaved = True
                DisplayMessage("Obstetric History Successfully Saved!")

            End With


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try


    End Sub

    Private Sub SaveChildGrowth()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oChildGrowth As New SyncSoft.SQLDb.ChildGrowth()

            With oChildGrowth

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .SocialSmile = Me.chkSocialSmile.Checked
                .HeadControl = Me.chkHeadControl.Checked
                .ReactionToSound = Me.chkReactionToSound.Checked
                .GraspReflex = Me.chkGraspReflex.Checked
                .Sitting = Me.chkSitting.Checked
                .Standing = Me.chkStanding.Checked
                .WeightForAge = StringValueMayBeEnteredIn(Me.cboWeightForAge, "Weght For Age!")
                .HeightForAge = StringValueMayBeEnteredIn(Me.cboHeightForAge, "Height For Age!")
                .WeightForHeight = StringValueEnteredIn(Me.cboWeightForHeight, "Weight For Height!")
                .BreastFeedingID = StringValueEnteredIn(Me.cboBreastFeeding, "Breast Feeding!")
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ChildGrowthSaved = True
                DisplayMessage("Child Growth & Development Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SavePostNatal()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim oPostNatal As New SyncSoft.SQLDb.PostNatal()
            With oPostNatal
                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's No!"))
                .DeliveryComplications = StringValueMayBeEnteredIn(Me.cboDeliveryComplications)
                .ConditionOnBirth = StringValueMayBeEnteredIn(Me.cboConditionOnBith)
                .ConditionDetails = StringMayBeEnteredIn(Me.stbConditionDetails)
                .PhysicalAbnormalityDetails = StringMayBeEnteredIn(Me.stbPhysicalAbnormalityDetails)
                .UmblicalCordDetails = StringValueMayBeEnteredIn(Me.cboUmblicalCordDetails)
                .Jaundice = StringValueMayBeEnteredIn(Me.cboJaundice, "Jaundice!")
                .EarlyInfection = StringValueMayBeEnteredIn(Me.cboEarlyInfection, "EarlyInfection!")
                .InfectionDetails = StringMayBeEnteredIn(Me.stbInfectionDetails)
                .Convulsions = StringValueMayBeEnteredIn(Me.cboConvulsions, "Convulsions!")
                .ConvulsionsDetails = StringMayBeEnteredIn(Me.stbConvulsionsDetails)
                .EIDResults = StringValueMayBeEnteredIn(Me.cboEIDResults, "EIDResults!")
                .ApgarScore = Me.nbxApgarScore.GetInteger()
                .Notes = StringMayBeEnteredIn(Me.stbComplicationNotes)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                postNatalSaved = True
                DisplayMessage("PostNatal Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub




#End Region

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oClinicalFindings As New SyncSoft.SQLDb.ClinicalFindings()
        Dim oOptical As New SyncSoft.SQLDb.Optical()
        Dim oEyeAssessment As New SyncSoft.SQLDb.EyeAssessment()
        Dim oOrthoptics As New SyncSoft.SQLDb.Orthoptics()
        Dim oRefraction As New SyncSoft.SQLDb.Refraction()
        Dim oReferrals As New SyncSoft.SQLDb.Referrals()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgClinicalFindings.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                    oClinicalFindings.VisitNo = visitNo
                    DisplayMessage(oClinicalFindings.Delete())

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me.tpgClinicalFindings)
                    clinicalFindingsSaved = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgEye.Name

                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgEyeAssessment.Name) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                        oEyeAssessment.VisitNo = visitNo
                        DisplayMessage(oEyeAssessment.Delete())

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ResetControlsIn(Me.tpgEyeAssessment)
                        eyeAssessmentSaved = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOrthoptics.Name) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                        oOrthoptics.VisitNo = visitNo
                        DisplayMessage(oOrthoptics.Delete())

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ResetControlsIn(Me.tpgOrthoptics)
                        orthopticsSaved = True
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOptical.Name) Then

                        If Me.tbcOptical.SelectedTab.Name.Equals(Me.tpgOpticalServices.Name) Then

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                            oOptical.VisitNo = visitNo
                            DisplayMessage(oOptical.Delete())

                            ResetControlsIn(Me.pnlOptical)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ElseIf Me.tbcOptical.SelectedTab.Name.Equals(Me.tpgRefraction.Name) Then

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                            oRefraction.VisitNo = visitNo
                            DisplayMessage(oRefraction.Delete())

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ResetControlsIn(Me.tpgRefraction)
                            orthopticsSaved = True
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End If

                    End If


                Case Me.tpgReferrals.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

                    oReferrals.VisitNo = visitNo
                    DisplayMessage(oReferrals.Delete())

                    ResetControlsIn(Me.tpgReferrals)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcDrRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDrRoles.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name
                Case Me.tpgGeneral.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTriage.Text
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = Me.btnPrintPreviewMedicalReport.Enabled
                    ResetControlsIn(Me.pnlBill)

                    'Case Me.tpgTriage.Name
                    '    Me.lblBillForItem.Text = "Bill for " + Me.tpgTriage.Text
                    '    Me.pnlBill.Visible = False
                    '    Me.btnSave.Visible = False
                    '    Me.btnDelete.Visible = False
                    '    Me.btnPrint.Enabled = Me.btnPrintPreviewMedicalReport.Enabled
                    '    ResetControlsIn(Me.pnlBill)

                Case Me.tpgClinicalFindings.Name
                    'Me.LoadClinicalFindings()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgClinicalFindings.Text
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgDiagnosis.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDiagnosis.Text
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgLaboratory.Name
                    'Me.LoadLabTests()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgLaboratory.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvLabTests.RowCount < 2 Then
                        Me.LoadPackageAttachedLabTests(patientpackageNo)
                    End If
                    Me.CalculateBillForLaboratory()

                Case Me.tpgCardiology.Name
                    'Me.LoadCardiology()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgCardiology.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForCardiology()
                    If dgvCardiology.RowCount < 2 Then
                        Me.LoadPackageAttachedCardiology(patientpackageNo)
                    End If

                Case Me.tpgRadiology.Name
                    'Me.LoadRadiology()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgRadiology.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForRadiology()
                    If dgvRadiology.RowCount < 2 Then
                        Me.LoadPackageAttachedRadiology(patientpackageNo)
                    End If

                Case Me.tpgPrescriptions.Name

                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForPrescriptions()
                    If dgvPrescription.RowCount < 2 Then
                        Me.LoadPackageAllowedPrescriptions(patientpackageNo)
                    End If


                Case Me.tpgProcedures.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgProcedures.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    If dgvProcedures.RowCount < 2 Then
                        Me.LoadPackageAllowedProcedures(patientpackageNo)
                    End If
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTheatre.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForTheatre()

                Case Me.tpgDental.Name
                    'Me.LoadDental()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDental.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForDentalCategoryService()

                Case Me.tpgDentalLab.Name
                    'Me.LoadDentalLab()
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDentalLab.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForDentalCategoryLaboratory()

                Case Me.tpgOptical.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgOptical.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True
                    Me.btnPrint.Enabled = False
                    Me.CalculateBillForConsumables()


                Case Me.tpgEye.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.tbcEye.SelectedTab.Name.Equals(Me.tpgVisionAssessment.Name) Then
                        Me.btnSave.Visible = False
                        Me.btnDelete.Visible = False

                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgEyeAssessment.Name) Then
                        Me.btnSave.Visible = True
                        Me.btnDelete.Visible = True
                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOrthoptics.Name) Then
                        Me.btnSave.Visible = True
                        Me.btnDelete.Visible = True
                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgLowVision.Name) Then
                        Me.btnSave.Visible = True
                        Me.btnDelete.Visible = True
                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgLowVisionEXT.Name) Then
                        Me.btnSave.Visible = False
                        Me.btnDelete.Visible = False
                    ElseIf Me.tbcEye.SelectedTab.Name.Equals(Me.tpgOptical.Name) Then
                        Me.lblBillForItem.Text = "Bill for " + Me.tpgOptical.Text
                        Me.pnlBill.Visible = True
                        Me.btnSave.Visible = True
                        Me.btnDelete.Visible = True
                        Me.btnPrint.Enabled = False
                        Me.CalculateBillForConsumables()
                    Else
                        Me.btnSave.Visible = False
                        Me.btnDelete.Visible = False
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgPathology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgHistopathologyRequisition.Text
                    Me.pnlBill.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    Me.CalculateBillForPathology()

                Case Me.tpgPathology.Name
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
                    If Me.tbcHistopathology.SelectedTab.Name.Equals(Me.tpgHistopathologyRequisition.Name) Then
                        Me.lblBillForItem.Text = "Bill for " + Me.tpgHistopathologyRequisition.Text
                        Me.pnlBill.Visible = True
                        Me.btnSave.Visible = True
                        Me.btnDelete.Visible = False
                        Me.btnPrint.Enabled = True
                        Me.CalculateBillForPathology()
                    Else
                        Me.btnSave.Visible = False
                        Me.btnDelete.Visible = False
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgLabResults.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgCardiologyReports.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgRadiologyReports.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = True
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgReferrals.Name
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False
                    Me.btnPrint.Enabled = False
                    ResetControlsIn(Me.pnlBill)

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAllAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgGeneral.Name) Then
                Me.btnSave.Enabled = False
                Me.btnDelete.Enabled = False

            ElseIf Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgLabResults.Name) Then
                Me.btnSave.Enabled = False
                Me.btnDelete.Enabled = False
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                If String.IsNullOrEmpty(visitNo) Then Return
                Me.LoadLabResults(visitNo)
                Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
                If visitDate = AppData.NullDateValue Then Return
                Me.DeleteLabResultsAlerts(visitNo, visitDate)

            ElseIf Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgCardiologyReports.Name) Then
                Me.btnSave.Enabled = False
                Me.btnDelete.Enabled = False
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                If String.IsNullOrEmpty(visitNo) Then Return
                Me.LoadCardiologyReports(visitNo)
                Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
                If visitDate = AppData.NullDateValue Then Return
                Me.DeleteCardiologyReportsAlerts(visitNo, visitDate)


            ElseIf Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgRadiologyReports.Name) Then
                Me.btnSave.Enabled = False
                Me.btnDelete.Enabled = False
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                If String.IsNullOrEmpty(visitNo) Then Return
                Me.LoadRadiologyReports(visitNo)
                Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
                If visitDate = AppData.NullDateValue Then Return
                Me.DeleteRadiologyReportsAlerts(visitNo, visitDate)



            Else
                Me.btnSave.Enabled = True
                Me.btnDelete.Enabled = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.ApplySecurity()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcEye_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcEye.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcEye.SelectedTab.Name

                Case Me.tpgVisionAssessment.Name

                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False

                Case Me.tpgEyeAssessment.Name

                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True

                Case Me.tpgOrthoptics.Name

                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True

                Case Me.tpgLowVision.Name

                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True

                Case Me.tpgOptical.Name

                    Me.btnSave.Visible = True
                    Me.btnDelete.Visible = True

                Case Me.tpgLowVisionEXT.Name

                    Me.btnSave.Visible = False
                    Me.btnDelete.Visible = False

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

    Private Function AllSaved() As Boolean

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim message As String = "Please ensure that all items are saved on "
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not clinicalFindingsSaved Then
                DisplayMessage(message + Me.tpgClinicalFindings.Text)
                Me.tbcDrRoles.SelectTab(Me.tpgClinicalFindings)
                Me.tbcClinicalFindings.SelectTab(Me.tpgClinicalGeneral)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not eyeAssessmentSaved Then
                DisplayMessage(message + Me.tpgEyeAssessment.Text)
                Me.tbcDrRoles.SelectTab(Me.tpgEye)
                Me.tbcEye.SelectTab(Me.tpgEyeAssessment)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not opticalPrescriptionSaved Then
                DisplayMessage(message + Me.tpgOptical.Text)
                Me.tbcDrRoles.SelectTab(Me.tpgEye)
                Me.tbcEye.SelectTab(Me.tpgOptical)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                    Case Me.tpgEye.Name
                        For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colConsumablesSaved) Then
                                DisplayMessage(message + Me.tpgOptical.Text)
                                Me.tbcDrRoles.SelectTab(Me.tpgEye)
                                Me.tbcEye.SelectTab(Me.tpgOptical)
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.cboStaffNo.Enabled AndAlso Me.dgvPrescription.Rows.Count > 1 AndAlso
                Me.dgvDiagnosis.Rows.Count <= 1 AndAlso oVariousOptions.ForceDiagnosisOnPrescription Then

                message = "Please ensure that diagnosis is registered for a visit with prescription!"
                DisplayMessage(message)
                Me.tbcDrRoles.SelectTab(Me.tpgDiagnosis)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False

            End If

            If Not Me.cboStaffNo.Enabled AndAlso
               Me.dgvDiagnosis.Rows.Count <= 1 AndAlso oVariousOptions.ForceDiagnosisAtDoctor Then

                message = "Please ensure that diagnosis is registered for this visit, Contact your Administrator for help!"
                DisplayMessage(message)
                Me.tbcDrRoles.SelectTab(Me.tpgDiagnosis)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Function DoctorVisitClosed() As Boolean

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnDoctorVisitClosed.Text.ToString().Trim().ToUpper().Equals(Me.VisitClosed.ToUpper()) Then
                DisplayMessage("This visit has been closed thus no more changes can be accepted.")
                Return True
            Else : Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub LoadDoctorVisit(ByVal visitNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVariousOptions As New VariousOptions()
        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
        Try

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()

            If oDoctorVisits.GetDoctorVisit(visitNo) Then
                Me.cboStaffNo.Text = oDoctorVisits.StaffFullName
                Me.cboStaffNo.Enabled = False
                Me.btnPrintPreviewMedicalReport.Enabled = True
                If Not String.IsNullOrEmpty(oDoctorVisits.ServiceCode) Then
                    Me.cboServiceCode.SelectedValue = oDoctorVisits.ServiceCode
                    Me.cboServiceCode.Enabled = False
                Else : Me.cboServiceCode.Enabled = True
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.ManageDoctorVisitClosed(oDoctorVisits.Closed)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                Me.cboStaffNo.SelectedIndex = -1
                Me.cboStaffNo.SelectedIndex = -1
                If String.IsNullOrEmpty(staffFullName) Then
                    Me.cboStaffNo.Text = oStaff.GetCurrentStaffFullName
                Else : Me.cboStaffNo.Text = staffFullName
                End If

                Me.cboStaffNo.Enabled = True
                Me.btnPrintPreviewMedicalReport.Enabled = False

                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedValue = visitServiceCode
                Me.cboServiceCode.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim services As DataTable = oServices.GetServices(visitServiceCode).Tables("Services")
                Dim serviceName As String = services.Rows(0).Item("ServiceName").ToString()
                Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        


                If oVariousOptions.AllowAccessCashConsultation.Equals(True) Then

                ElseIf serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) AndAlso
                                 Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                                 Me.stbBillMode.Text.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
                                 servicePayStatusID.ToUpper().Equals(oPayStatusID.NotPaid.ToUpper()) AndAlso
                                 oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                                 accessCashServices.Equals(False) AndAlso visitStandardFee > 0 Then

                    Throw New ArgumentException("This visit is set not to access cash service before payment. Please check with cashier.")

                ElseIf serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) AndAlso
                   Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                   Me.stbBillMode.Text.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
                   servicePayStatusID.ToUpper().Equals(oPayStatusID.NA.ToUpper()) AndAlso
                   oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                   accessCashServices.Equals(False) And hasPaidPackage.Equals(False) AndAlso visitStandardFee > 0 Then

                    Throw New ArgumentException("This visit is set not to access cash service before package payment. Please check with cashier.")
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim _NACoPayType As String = GetLookupDataDes(oCoPayTypeID.NA)

            If Not oVariousOptions.AllowAccessCoPayServices AndAlso Not coPayType.ToUpper().Equals(_NACoPayType.ToUpper()) AndAlso Not stbBillMode.Text.ToUpper().ToUpper().Equals(cashAccountNo.ToUpper()) Then
                Dim cashNotPaid As Boolean = False
                If copayServicePayStatusID.ToUpper().Equals(oPayStatusID.NotPaid.ToUpper()) AndAlso visitStandardFee > 0 Then
                    cashNotPaid = True
                Else
                    cashNotPaid = False
                End If

                Dim Message As String = "This visit is set not to access a Service because co-pay percent or value is not paid for a co-pay visit!. Please check with cashier."
                If cashNotPaid Then Throw New ArgumentException(Message)

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgGeneral.Name) Then Me.btnPrint.Enabled = Me.btnPrintPreviewMedicalReport.Enabled
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadClinicalFindings(ByVal visitNo As String)

        Dim oClinicalFindings As New SyncSoft.SQLDb.ClinicalFindings()

        Try

            ResetControlsIn(Me.tpgClinicalFindings)
            Dim clinicalFindings As DataTable = oClinicalFindings.GetClinicalFindings(RevertText(visitNo)).Tables("ClinicalFindings")

            If clinicalFindings Is Nothing Then Return

            For Each row As DataRow In clinicalFindings.Rows

                Me.stbPresentingComplaint.Text = StringMayBeEnteredIn(row, "PresentingComplaint")
                Me.stbClinicalNotes.Text = StringMayBeEnteredIn(row, "ClinicalNotes")
                Me.stbROS.Text = StringMayBeEnteredIn(row, "ROS")
                Me.stbPMH.Text = StringMayBeEnteredIn(row, "PMH")
                Me.stbPOH.Text = StringMayBeEnteredIn(row, "POH")
                Me.stbPGH.Text = StringMayBeEnteredIn(row, "PGH")
                Me.stbFSH.Text = StringMayBeEnteredIn(row, "FSH")
                Me.stbGeneralAppearance.Text = StringMayBeEnteredIn(row, "GeneralAppearance")
                Me.stbRespiratory.Text = StringMayBeEnteredIn(row, "Respiratory")
                Me.stbCVS.Text = StringMayBeEnteredIn(row, "CVS")
                Me.stbENT.Text = StringMayBeEnteredIn(row, "ENT")
                Me.stbAbdomen.Text = StringMayBeEnteredIn(row, "Abdomen")
                Me.stbCNS.Text = StringMayBeEnteredIn(row, "CNS")
                Me.stbEYE.Text = StringMayBeEnteredIn(row, "EYE")
                Me.stbMuscularSkeletal.Text = StringMayBeEnteredIn(row, "MuscularSkeletal")
                Me.stbSkin.Text = StringMayBeEnteredIn(row, "Skin")
                Me.stbPV.Text = StringMayBeEnteredIn(row, "PV")
                Me.stbPsychologicalStatus.Text = StringMayBeEnteredIn(row, "PsychologicalStatus")
                Me.stbProvisionalDiagnosis.Text = StringMayBeEnteredIn(row, "ProvisionalDiagnosis")
                Me.stbTreatmentPlan.Text = StringMayBeEnteredIn(row, "TreatmentPlan")
                Me.spbClinicalImage.Image = ImageMayBeEnteredIn(row, "ClinicalImage")

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadObstetricHistory(ByVal patientNo As String)

        Dim oObstetricHistory As New SyncSoft.SQLDb.ObstetricHistory()

        Try

            'ResetControlsIn(Me.tpgObstetric)
            Dim ObstetricHistory As DataTable = oObstetricHistory.GetObstetricHistory(RevertText(patientNo)).Tables("ObstetricHistory")

            If ObstetricHistory Is Nothing Then Return

            For Each row As DataRow In ObstetricHistory.Rows


                Me.nbxGravidity.Text = StringMayBeEnteredIn(row, "Gravidity")
                Me.nbxParity.Text = StringMayBeEnteredIn(row, "Parity")
                Me.nbxNoOfSurvivingChildren.Text = StringMayBeEnteredIn(row, "NoOfSurvivingChildren")
                Me.dtpLMP.Value = DateMayBeEnteredIn(row, "LMP")
                Me.dtpEDD.Value = DateMayBeEnteredIn(row, "EDD")
                Me.nbxGestationalAgeInWks.Text = StringMayBeEnteredIn(row, "GestationalAgeInWks")
                Me.cboStillBirth.SelectedValue = StringMayBeEnteredIn(row, "StillBirth")
                Me.nbxNoOfStillBirths.Text = StringMayBeEnteredIn(row, "NoOfStillBirths")
                Me.cboAbortions.SelectedValue = StringMayBeEnteredIn(row, "Abortions")
                Me.nbxNoOfAbortions.Text = StringMayBeEnteredIn(row, "NoOfAbortions")
                Me.cboCaesarian.SelectedValue = StringMayBeEnteredIn(row, "Caesarian")
                Me.nbxNoOfCaesarians.Text = StringMayBeEnteredIn(row, "NoOfCaesarians")


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            obstetricHistorySaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadAntenatal(ByVal VisitNo As String)

        Dim oAntenatal As New SyncSoft.SQLDb.Antenatal()

        Try

            'ResetControlsIn(Me.tpgAntenatalStage)
            Dim Antenatal As DataTable = oAntenatal.GetAntenatal(RevertText(VisitNo)).Tables("Antenatal")

            If Antenatal Is Nothing Then Return

            For Each row As DataRow In Antenatal.Rows


                Me.cboInfection.SelectedValue = StringMayBeEnteredIn(row, "Infection")
                Me.stbInfectionDetails.Text = StringMayBeEnteredIn(row, "InfectionDetails")
                Me.cboAccidentDuringPregnancy.SelectedValue = StringMayBeEnteredIn(row, "AccidentDuringPregnancy")
                Me.stbDetailsOfAccident.Text = StringMayBeEnteredIn(row, "DetailsOfAccident")
                Me.cboUseOfDrugsOrPrescription.SelectedValue = StringMayBeEnteredIn(row, "UseOfDrugsOrPrescription")
                Me.stbDrugDetails.Text = StringMayBeEnteredIn(row, "DrugDetails")
                Me.cboSmoking.SelectedValue = StringMayBeEnteredIn(row, "Smoking")
                Me.cboChronicIllness.SelectedValue = StringMayBeEnteredIn(row, "ChronicIllness")
                Me.stbDetailsOfIllness.Text = StringMayBeEnteredIn(row, "DetailsOfIllness")


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            antenatalStageSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPerinatal(ByVal visitNo As String)

        Dim oPerinatal As New SyncSoft.SQLDb.Perinatal()

        Try

            ResetControlsIn(Me.tpgPerinatal)
            Dim Perinatal As DataTable = oPerinatal.GetPerinatal(RevertText(visitNo)).Tables("Perinatal")

            If Perinatal Is Nothing Then Return

            For Each row As DataRow In Perinatal.Rows

                Me.cboModeOfDelivery.SelectedValue = StringMayBeEnteredIn(row, "ModeOfDelivery")
                Me.nbxDurationOfLabour.Text = StringMayBeEnteredIn(row, "DurationOfLabour")
                Me.cboComplicationsGyn.SelectedValue = StringMayBeEnteredIn(row, "DeliveryComplications")
                Me.nbxAmountOfBloodLoss.Text = StringMayBeEnteredIn(row, "AmountOfBloodLoss")
                Me.cboMothersCondition.SelectedValue = StringMayBeEnteredIn(row, "MothersCondition")
                Me.stbDetailsOfCondition.Text = StringMayBeEnteredIn(row, "DetailsOfCondition")
                Me.cboBabyAlive.SelectedValue = StringMayBeEnteredIn(row, "BabyAlive")
                Me.cboCauseOfDeath.SelectedValue = StringMayBeEnteredIn(row, "CauseOfDeath")

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            perinatalSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadChildGrowth(ByVal visitNo As String)

        Dim oChildGrowth As New SyncSoft.SQLDb.ChildGrowth()

        Try

            ResetControlsIn(Me.tpgChildGrowth)
            Dim childGrowth As DataTable = oChildGrowth.GetChildGrowth(RevertText(visitNo)).Tables("ChildGrowth")

            If childGrowth Is Nothing Then Return

            For Each row As DataRow In childGrowth.Rows


                Me.chkSocialSmile.Checked = BooleanMayBeEnteredIn(row, "SocialSmile")
                Me.chkHeadControl.Checked = BooleanMayBeEnteredIn(row, "HeadControl")
                Me.chkReactionToSound.Checked = BooleanMayBeEnteredIn(row, "ReactionToSound")
                Me.chkGraspReflex.Checked = BooleanMayBeEnteredIn(row, "GraspReflex")
                Me.chkSitting.Checked = BooleanMayBeEnteredIn(row, "Sitting")
                Me.chkStanding.Checked = BooleanMayBeEnteredIn(row, "Standing")
                Me.cboWeightForAge.SelectedValue = StringMayBeEnteredIn(row, "WeightForAge")
                Me.cboHeightForAge.SelectedValue = StringMayBeEnteredIn(row, "HeightForAge")
                Me.cboWeightForHeight.SelectedValue = StringMayBeEnteredIn(row, "HeightForAge")
                Me.cboBreastFeeding.SelectedValue = StringMayBeEnteredIn(row, "BreastFeedingID")
                Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ChildGrowthSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPostNatal(ByVal patientNo As String)

        Dim oPostNatal As New SyncSoft.SQLDb.PostNatal()

        Try

            'ResetControlsIn(Me.tpgPostNatal)
            Dim postNatal As DataTable = oPostNatal.GetPostNatal(RevertText(patientNo)).Tables("PostNatal")

            If postNatal Is Nothing Then Return

            For Each row As DataRow In postNatal.Rows


                Me.cboDeliveryComplications.SelectedValue = StringMayBeEnteredIn(row, "DeliveryComplications")
                Me.cboConditionOnBith.SelectedValue = StringMayBeEnteredIn(row, "ConditionOnBirth")
                Me.stbConditionDetails.Text = StringMayBeEnteredIn(row, "ConditionDetails")
                Me.stbPhysicalAbnormalityDetails.Text = StringMayBeEnteredIn(row, "PhysicalAbnormalityDetails")
                Me.cboUmblicalCordDetails.SelectedValue = StringMayBeEnteredIn(row, "UmblicalCordDetails")
                Me.cboJaundice.SelectedValue = StringMayBeEnteredIn(row, "Jaundice")
                Me.cboEarlyInfection.SelectedValue = StringMayBeEnteredIn(row, "EarlyInfection")
                Me.stbInfectionDetails.Text = StringMayBeEnteredIn(row, "InfectionDetails")
                Me.cboConvulsions.SelectedValue = StringMayBeEnteredIn(row, "Convulsions")
                Me.stbConvulsionsDetails.Text = StringMayBeEnteredIn(row, "ConvulsionsDetails")
                Me.cboEIDResults.SelectedValue = StringMayBeEnteredIn(row, "EIDResults")
                Me.nbxApgarScore.Text = StringMayBeEnteredIn(row, "ApgarScore")
                Me.stbComplicationNotes.Text = StringMayBeEnteredIn(row, "Notes")


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            postNatalSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadEyeAssessment(ByVal visitNo As String)

        Dim oEyeAssessment As New SyncSoft.SQLDb.EyeAssessment()

        Try

            ResetControlsIn(Me.tpgEyeAssessment)

            Dim eyeAssessment As DataTable = oEyeAssessment.GetEyeAssessment(RevertText(visitNo)).Tables("EyeAssessment")
            If eyeAssessment Is Nothing Then Return

            For Each row As DataRow In eyeAssessment.Rows

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
                Me.nbxRightIOP.Text = StringMayBeEnteredIn(row, "RightIOP")
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
            eyeAssessmentSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadOrthoptics(ByVal visitNo As String)

        Dim oOrthoptics As New SyncSoft.SQLDb.Orthoptics()

        Try

            ResetControlsIn(Me.tpgOrthoptics)

            Dim orthoptics As DataTable = oOrthoptics.GetOrthoptics(RevertText(visitNo)).Tables("Orthoptics")
            If orthoptics Is Nothing Then Return

            For Each row As DataRow In orthoptics.Rows

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
            orthopticsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadOpticalPrescription(ByVal visitNo As String)

        Dim oOptical As New SyncSoft.SQLDb.Optical()

        Try

            ResetControlsIn(Me.pnlOptical)
            Dim optical As DataTable = oOptical.GetOptical(RevertText(visitNo)).Tables("Optical")

            If optical Is Nothing Then Return

            For Each row As DataRow In optical.Rows

                Me.stbRightSPH.Text = StringMayBeEnteredIn(row, "RightSPH")
                Me.stbRightCYL.Text = StringMayBeEnteredIn(row, "RightCYL")
                Me.stbRightAXIS.Text = StringMayBeEnteredIn(row, "RightAXIS")
                Me.stbRightPRISM.Text = StringMayBeEnteredIn(row, "RightPRISM")
                Me.stbRightADD.Text = StringMayBeEnteredIn(row, "RightADD")
                Me.stbLeftSPH.Text = StringMayBeEnteredIn(row, "LeftSPH")
                Me.stbLeftCYL.Text = StringMayBeEnteredIn(row, "LeftCYL")
                Me.stbLeftAXIS.Text = StringMayBeEnteredIn(row, "LeftAXIS")
                Me.stbLeftPRISM.Text = StringMayBeEnteredIn(row, "LeftPRISM")
                Me.stbLeftADD.Text = StringMayBeEnteredIn(row, "LeftADD")
                Me.nbxPd.Value = StringMayBeEnteredIn(row, "Pd")
                Me.nbxSg.Value = StringMayBeEnteredIn(row, "Sg")
                Me.cboLenseTypeID.SelectedValue = StringMayBeEnteredIn(row, "LenseTypeID")

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalPrescriptionSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRefraction(ByVal visitNo As String)

        Dim oRefraction As New SyncSoft.SQLDb.Refraction()

        Try
            ResetControlsIn(Me.tpgRefraction)

            Dim refraction As DataTable = oRefraction.GetRefraction(RevertText(visitNo)).Tables("Refraction")

            If refraction Is Nothing Then Return
            For Each row As DataRow In refraction.Rows

                Me.stbRightMRSPH.Text = StringMayBeEnteredIn(row, "RightMRSPH")
                Me.stbLeftMRSPH.Text = StringMayBeEnteredIn(row, "LeftMRSPH")
                Me.stbRightMRCYL.Text = StringMayBeEnteredIn(row, "RightMRCYL")
                Me.stbLeftMRCYL.Text = StringMayBeEnteredIn(row, "LeftMRCYL")
                Me.stbRightMRAXIS.Text = StringMayBeEnteredIn(row, "RightMRAXIS")
                Me.stbLeftMRAXIS.Text = StringMayBeEnteredIn(row, "LeftMRAXIS")
                Me.stbRightCRSPH.Text = StringMayBeEnteredIn(row, "RightCRSPH")
                Me.stbLeftCRSPH.Text = StringMayBeEnteredIn(row, "LeftCRSPH")
                Me.stbRightCRCYL.Text = StringMayBeEnteredIn(row, "RightCRCYL")
                Me.stbLeftCRCYL.Text = StringMayBeEnteredIn(row, "LeftCRCYL")
                Me.stbRightCRAXIS.Text = StringMayBeEnteredIn(row, "RightCRAXIS")
                Me.stbLeftCRAXIS.Text = StringMayBeEnteredIn(row, "LeftCRAXIS")
                Me.stbRightPCRSPH.Text = StringMayBeEnteredIn(row, "RightPCRSPH")
                Me.stbLeftPCRSPH.Text = StringMayBeEnteredIn(row, "LeftPCRSPH")
                Me.stbRightPCRCYL.Text = StringMayBeEnteredIn(row, "RightPCRCYL")
                Me.stbLeftPCRCYL.Text = StringMayBeEnteredIn(row, "LeftPCRCYL")
                Me.stbRightPCRAXIS.Text = StringMayBeEnteredIn(row, "RightPCRAXIS")
                Me.stbLeftPCRRAXIS.Text = StringMayBeEnteredIn(row, "LeftPCRRAXIS")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            refractionSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadLowVision(ByVal visitNo As String)

        Dim oLowVision As New SyncSoft.SQLDb.LowVision()


        Try
            ResetControlsIn(Me.tpgLowVision)
            ResetControlsIn(Me.tpgLowVisionEXT)

            Dim lowVision As DataTable = oLowVision.GetLowVision(RevertText(visitNo)).Tables("LowVision")
            If lowVision Is Nothing Then Return

            For Each row As DataRow In lowVision.Rows

                Me.stbBriefHistory.Text = StringMayBeEnteredIn(row, "BriefHistory")
                Me.stbProfession.Text = StringMayBeEnteredIn(row, "Profession")
                Me.stbMajorOcularDiagnosisRE.Text = StringMayBeEnteredIn(row, "MajorOcularDiagnosisRE")
                Me.stbMajorOcularDiagnosisLE.Text = StringMayBeEnteredIn(row, "MajorOcularDiagnosisLE")
                Me.stbOtherOcularDiagnosisRE.Text = StringMayBeEnteredIn(row, "OtherOcularDiagnosisRE")
                Me.stbOtherOcularDiagnosisLE.Text = StringMayBeEnteredIn(row, "OtherOcularDiagnosisLE")
                Me.cboOphthalmologistSeenID.SelectedValue = StringMayBeEnteredIn(row, "OphthalmologistSeenID")
                Me.cboOtherImpairmentsId.SelectedValue = StringMayBeEnteredIn(row, "OtherImpairmentsID")
                Me.stbOtherImpairments.Text = StringMayBeEnteredIn(row, "OtherImpairments")

                Me.stbExistingTreatmentFarLE.Text = StringMayBeEnteredIn(row, "ExistingTreatmentFarLE")
                Me.stbExistingTreatmentFarRE.Text = StringMayBeEnteredIn(row, "ExistingTreatmentFarRE")
                Me.stbExistingTreatmentNearLE.Text = StringMayBeEnteredIn(row, "ExistingTreatmentNearLE")
                Me.stbExistingTreatmentNearRE.Text = StringMayBeEnteredIn(row, "ExistingTreatmentNearRE")
                Me.stbNewTreatmentFarLE.Text = StringMayBeEnteredIn(row, "NewTreatmentFarLE")
                Me.stbNewTreatmentFarRE.Text = StringMayBeEnteredIn(row, "NewTreatmentFarRE")
                Me.stbNewTreatmentNearLE.Text = StringMayBeEnteredIn(row, "NewTreatmentNearLE")
                Me.stbNewTreatmentNearRE.Text = StringMayBeEnteredIn(row, "NewTreatmentNearRE")
                Me.cboExistingVisualAcuityFarLEID.SelectedValue = StringMayBeEnteredIn(row, "ExistingVisualAcuityFarLEID")
                Me.cboExistingVisualAcuityFarREID.SelectedValue = StringMayBeEnteredIn(row, "ExistingVisualAcuityFarREID")
                Me.cboExistingVisualAcuityNearLEID.SelectedValue = StringMayBeEnteredIn(row, "ExistingVisualAcuityNearLEID")
                Me.cboExistingVisualAcuityNearREID.SelectedValue = StringMayBeEnteredIn(row, "ExistingVisualAcuityNearREID")
                Me.cboNewVisualAcuityFarLEID.SelectedValue = StringMayBeEnteredIn(row, "NewVisualAcuityFarLEID")
                Me.cboNewVisualAcuityFarREID.SelectedValue = StringMayBeEnteredIn(row, "NewVisualAcuityFarREID")
                Me.cboNewVisualAcuityNearLEID.SelectedValue = StringMayBeEnteredIn(row, "NewVisualAcuityNearLEID")
                Me.cboNewVisualAcuityNearREID.SelectedValue = StringMayBeEnteredIn(row, "NewVisualAcuityNearREID")
                Me.stbProblemEncounteredLVDsNear.Text = StringMayBeEnteredIn(row, "ProblemEncounteredLVDsNear")
                Me.stbProblemEncounteredLVDsFar.Text = StringMayBeEnteredIn(row, "ProblemEncounteredLVDsFar")
                Me.cboColourVisionDefectID.SelectedValue = StringMayBeEnteredIn(row, "ColourVisionDefectID")
                Me.stbColourVisionTestUsed.Text = StringMayBeEnteredIn(row, "ColourVisionTestUsed")
                Me.cboContrastSensitivityID.SelectedValue = StringMayBeEnteredIn(row, "ContrastSensitivityID")
                Me.stbContrastSensitivityTestUsed.Text = StringMayBeEnteredIn(row, "ContrastSensitivityTestUsed")
                Me.cboVisualFieldDefectID.SelectedValue = StringMayBeEnteredIn(row, "VisualFieldDefectID")
                Me.stbVisualFieldDefectTestUsed.Text = StringMayBeEnteredIn(row, "VisualFieldDefectTestUsed")
                'Me.stbLowVisionDevicesFar.Text = StringMayBeEnteredIn(row, "LowVisionDevicesFar")
                'Me.stbLowVisionDevicesNear.Text = StringMayBeEnteredIn(row, "LowVisionDevicesNear")
                'Me.stbNonOpticalAids.Text = StringMayBeEnteredIn(row, "NonOpticalAids")
                Me.stbAdvice.Text = StringMayBeEnteredIn(row, "Advice")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim sExistingLVDsNearItem As String
                Dim sExistingLVDsFarItem As String
                Dim sLowVisionDevicesFarItem As String
                Dim sLowVisionDevicesNearItem As String
                Dim sNonOpticalAidsItem As String
                Dim selectindex As Integer

                If String.IsNullOrEmpty(StringMayBeEnteredIn(row, "ExistingLVDsNear")) Then
                Else

                    Dim sExistingLVDsNear As String() = StringMayBeEnteredIn(row, "ExistingLVDsNear").Split(New Char() {","c})
                    For Each sExistingLVDsNearItem In sExistingLVDsNear
                        Me.clbExistingLVDsNear.SelectedItem = sExistingLVDsNearItem.Trim()
                        selectindex = Me.clbExistingLVDsNear.SelectedIndex
                        Me.clbExistingLVDsNear.SetItemChecked(selectindex, True)
                        Me.clbExistingLVDsNear.SelectedIndex = -1
                    Next
                End If


                If String.IsNullOrEmpty(StringMayBeEnteredIn(row, "ExistingLVDsFar")) Then
                Else
                    Dim sExistingLVDsFar As String() = StringMayBeEnteredIn(row, "ExistingLVDsFar").Split(New Char() {","c})
                    For Each sExistingLVDsFarItem In sExistingLVDsFar
                        Me.clbExistingLVDsFar.SelectedItem = sExistingLVDsFarItem.Trim
                        selectindex = Me.clbExistingLVDsFar.SelectedIndex
                        Me.clbExistingLVDsFar.SetItemChecked(selectindex, True)
                        Me.clbExistingLVDsNear.SelectedIndex = -1

                    Next

                End If

                If String.IsNullOrEmpty(StringMayBeEnteredIn(row, "LowVisionDevicesNear")) Then
                Else

                    Dim sLowVisionDevicesNear As String() = StringMayBeEnteredIn(row, "LowVisionDevicesNear").Split(New Char() {","c})
                    For Each sLowVisionDevicesNearItem In sLowVisionDevicesNear
                        Me.clbLowVisionDevicesNear.SelectedItem = sLowVisionDevicesNearItem.Trim()
                        selectindex = Me.clbLowVisionDevicesNear.SelectedIndex
                        Me.clbLowVisionDevicesNear.SetItemChecked(selectindex, True)
                        Me.clbLowVisionDevicesNear.SelectedIndex = -1
                    Next
                End If


                If String.IsNullOrEmpty(StringMayBeEnteredIn(row, "LowVisionDevicesFar")) Then
                Else
                    Dim sLowVisionDevicesFar As String() = StringMayBeEnteredIn(row, "LowVisionDevicesFar").Split(New Char() {","c})
                    For Each sLowVisionDevicesFarItem In sLowVisionDevicesFar
                        Me.clbLowVisionDevicesFar.SelectedItem = sLowVisionDevicesFarItem.Trim
                        selectindex = Me.clbLowVisionDevicesFar.SelectedIndex
                        Me.clbLowVisionDevicesFar.SetItemChecked(selectindex, True)
                        Me.clbLowVisionDevicesFar.SelectedIndex = -1
                    Next

                End If

                If String.IsNullOrEmpty(StringMayBeEnteredIn(row, "NonOpticalAids")) Then
                Else

                    Dim sNonOpticalAids As String() = StringMayBeEnteredIn(row, "NonOpticalAids").Split(New Char() {","c})
                    For Each sNonOpticalAidsItem In sNonOpticalAids
                        Me.clbNonOpticalAids.SelectedItem = sNonOpticalAidsItem.Trim()
                        selectindex = Me.clbNonOpticalAids.SelectedIndex
                        Me.clbNonOpticalAids.SetItemChecked(selectindex, True)
                        Me.clbNonOpticalAids.SelectedIndex = -1
                    Next
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lowVisionSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadReferrals(ByVal visitNo As String)

        Dim oReferrals As New SyncSoft.SQLDb.Referrals()

        Try

            ResetControlsIn(Me.tpgReferrals)

            Dim referrals As DataTable = oReferrals.GetReferrals(visitNo).Tables("Referrals")

            If referrals Is Nothing OrElse referrals.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataRow In referrals.Rows
                Me.dtpReferralDate.Value = DateMayBeEnteredIn(row, "ReferralDate")
                Me.dtpReferralDate.Checked = True
                Me.stbReferredBy.Text = StringMayBeEnteredIn(row, "ReferredByFullName")
                Me.cboDoctorSpecialtyID.SelectedValue = StringMayBeEnteredIn(row, "DoctorSpecialtyID")
                Me.cboReferredTo.Text = StringMayBeEnteredIn(row, "ReferredToFullName")
                Me.stbReferralNotes.Text = StringMayBeEnteredIn(row, "ReferralNotes")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    'Private Sub LoadAttachedTheatreServices(selectedRow As Integer, procedureCode As String)

    '    Dim unitPrice As Decimal
    '    Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems()
    '    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '    Dim theatreServices As DataTable = oItems.GetAttachedPossibleTheatreServices(procedureCode).Tables("PossibleAttachedItems")
    '    If theatreServices Is Nothing OrElse theatreServices.Rows.Count < 1 Then Return

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim count As Integer = Me.dgvTheatre.Rows.Count - 1

    '    If selectedRow = dgvProcedures.Rows.Count - 2 Then

    '        For pos As Integer = 0 To theatreServices.Rows.Count - 1
    '            Dim row As DataRow = theatreServices.Rows(pos)
    '            With Me.dgvTheatre

    '                .Rows.Add()
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim theatreServiceNo As String = StringEnteredIn(row, "ItemCode")
    '                Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
    '                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, theatreServiceNo, oItemCategoryID.Theatre).Equals(True) Then
    '                    unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, theatreServiceNo, oItemCategoryID.Theatre)
    '                Else
    '                    unitPrice = DecimalEnteredIn(row, "UnitPrice", False)
    '                End If


    '                Dim amount As Decimal = quantity * unitPrice
    '                .Item(Me.colICDTheatreCode.Name, count).Value = theatreServiceNo
    '                .Item(Me.colTheatreService.Name, count).Value = StringEnteredIn(row, "TheatreName")
    '                'Me.ShowTheatreServiceDetails(StringEnteredIn(row, "ItemCode"), pos)
    '                .Item(Me.colTheatreQuantity.Name, count).Value = quantity
    '                .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
    '                .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
    '                .Item(Me.colTheatreNotes.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
    '                .Item(Me.colTheatreItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
    '                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And
    '                    OpackagesEXT.IsPackageItem(patientpackageNo, theatreServiceNo, oItemCategoryID.Theatre).Equals(True) Then
    '                    .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
    '                Else
    '                    .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NotPaid)
    '                End If

    '                .Item(Me.colTheatreSaved.Name, pos).Value = False
    '                count += 1

    '            End With

    '        Next

    '    End If

    'End Sub

    'Private Sub LoadAttachedPrescriptions(selectedRow As Integer, procedureCode As String)
    '    Dim unitPrice As Decimal
    '    Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
    '    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '    Dim attachedPrescriptions As DataTable = oItems.GetAttachedPossiblePrescription(procedureCode).Tables("PossibleAttachedItems")
    '    If attachedPrescriptions Is Nothing OrElse attachedPrescriptions.Rows.Count < 1 Then Return

    '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '    Dim count As Integer = Me.dgvPrescription.Rows.Count - 1

    '    If selectedRow = dgvProcedures.Rows.Count - 2 Then

    '        For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
    '            Dim row As DataRow = attachedPrescriptions.Rows(pos)
    '            With Me.dgvPrescription

    '                ' Ensure that you add a new row
    '                .Rows.Add()

    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim drugNo As String = StringEnteredIn(row, "ItemCode")
    '                Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
    '                Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
    '                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
    '                    unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, drugNo, oItemCategoryID.Drug)
    '                Else
    '                    unitPrice = DecimalEnteredIn(row, "UnitPrice", False)
    '                End If
    '                Dim amount As Decimal = quantity * unitPrice

    '                .Item(Me.colDrugNo.Name, count).Value = drugNo
    '                .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugName")
    '                Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
    '                .Item(Me.colDrugQuantity.Name, count).Value = quantity
    '                .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
    '                .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
    '                .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
    '                .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
    '                .Item(Me.ColPrescribedby.Name, pos).Value = CurrentUser.FullName
    '                .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
    '                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
    '                    .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
    '                Else
    '                    .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NotPaid)
    '                End If

    '                .Item(Me.colPrescriptionSaved.Name, pos).Value = False
    '                count += 1

    '            End With

    '        Next

    '    End If

    'End Sub

    Private Sub LoadDiseaseAttachedPrescriptions(diseasecode As String)
        Dim unitPrice As Decimal
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

                '   If selectedRow = dgvDiagnosis.Rows.Count - 2 Then

                For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                    Dim row As DataRow = attachedPrescriptions.Rows(pos)
                    With Me.dgvPrescription

                        ' Ensure that you add a new row
                        .Rows.Add()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")

                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                            unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, drugNo, oItemCategoryID.Drug)
                        Else
                            unitPrice = DecimalEnteredIn(row, "UnitPrice", False)
                        End If

                        Dim amount As Decimal = quantity * unitPrice

                        .Item(Me.colDrugNo.Name, count).Value = drugNo
                        .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugName")
                        Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colDrugQuantity.Name, count).Value = quantity
                        .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                        .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                        .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.ColPrescribedby.Name, pos).Value = CurrentUser.FullName
                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
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
        '  End If
    End Sub

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


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Diseases", "Disease Code", "Disease Name", Me.LoadDiseases(), "DiseaseFullName",
            '                                                         "DiseaseCode", "DiseaseFullName", Me.dgvDiagnosis, Me.colICDDiagnosisCode, e.RowIndex)

            'Me._DiagnosisCode = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(e.RowIndex).Cells, Me.colICDDiagnosisCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDiagnosis.Rows(e.RowIndex).IsNewRow Then

            '    Me.dgvDiagnosis.Rows.Add()
            '    'fSelectItem.ShowDialog(Me)
            '    fQuickSearch.ShowDialog(Me)
            '    Me.SetDiagnosisEntries(e.RowIndex)


            'ElseIf Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) Then

            '    'fSelectItem.ShowDialog(Me)
            '    fQuickSearch.ShowDialog(Me)
            '    Me.SetDiagnosisEntries(e.RowIndex)
            'End If


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
                If Diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
                Dim row As DataRow = Diagnosis.Rows(0)
                Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")

                '    Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                'Dim diagnosisDisplay As String = (From data In diagnosis
                '                                  Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
                '                                  Select data.Field(Of String)("DiseaseName")).First()
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

                        'Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()

                        'Dim enteredDisplay As String = (From data In diagnosis
                        '                                Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.Trim().ToUpper())
                        '                                Select data.Field(Of String)("DiseaseName")).First()
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


    Private Sub dgvDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''           
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDiagnosis
                .VisitNo = visitNo
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

    Private Sub LoadDiagnosis(ByVal visitNo As String)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim diagnosis As DataTable = oDiagnosis.GetDiagnosis(RevertText(visitNo)).Tables("Diagnosis")
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
                Me.SetLabTestsEntries(rowIndex)

            ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                rowIndex = Me.dgvLabTests.NewRowIndex - 1
                Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowIndex).Cells, Me.ColLabTestCode)
                Me.SetLabTestsEntries(rowIndex)

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
                    Me.SetLabTestsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try



    End Sub


    Private Sub SetLabTestsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.ColLabTestCode))

            Me.SetLabTestsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
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
            Dim unitPrice As Decimal
            Dim testCode As String = RevertText(SubstringRight(selectedItem))
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If labTests Is Nothing OrElse String.IsNullOrEmpty(testCode) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, testCode, oItemCategoryID.Test)
            Else
                unitPrice = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)
            End If


            For Each row As DataRow In labTests.Select("TestCode = '" + testCode + "'")

                Me.dgvLabTests.Item(Me.ColLabTestCode.Name, selectedRow).Value = testCode.ToUpper()
                Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Value = StringEnteredIn(row, "TestName")
                Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvLabTests.Item(Me.colLTQuantity.Name, selectedRow).Value = 1
                Me.dgvLabTests.Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                Me.dgvLabTests.Item(Me.colLTItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvLabTests.Item(Me.colRejectionStatus.Name, selectedRow).Value = "False"
                Me.dgvLabTests.Item(Me.ColRequestedBy.Name, selectedRow).Value = CurrentUser.FullName
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
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

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvLabTests.Item(Me.ColLabTestCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub CalculateBillForLaboratory()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

            If IsNumeric(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadLaboratory(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for
            Dim flagStatusStyle As New DataGridViewCellStyle()
            flagStatusStyle.BackColor = Color.MistyRose
            Dim oVariousOptions As New VariousOptions()
            Dim tests As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Test).Tables("Items")
            If tests Is Nothing OrElse tests.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To tests.Rows.Count - 1

                Dim row As DataRow = tests.Rows(pos)
                With Me.dgvLabTests

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.ColLabTestCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.ColTestNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colLTQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    If oVariousOptions.ForceLabResultsVerification Then
                        .Item(Me.colLTItemStatus.Name, pos).Value = StringEnteredIn(row, "LabApprovedStatusID")
                    Else
                        .Item(Me.colLTItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    End If
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForLaboratory()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadLabResults(ByVal visitNo As String)

        Dim styleResult As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Dim oResultFlagID As New LookupDataID.ResultFlagID()

        Try

            Me.dgvLabResults.Rows.Clear()

            ' Load from Lab Results
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim labResults As DataTable = oLabResults.GetLabResultsByVisitNo(visitNo).Tables("LabResults")
            If labResults Is Nothing Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabResults, labResults)

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

    Private Sub LoadDiseaseAttachedLabTests(diseasecode As String)

        Dim unitPrice As Decimal
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

                For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                    Dim row As DataRow = attachedPrescriptions.Rows(pos)
                    With Me.dgvLabTests

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim testCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
                            unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, testCode, oItemCategoryID.Test)
                        Else
                            unitPrice = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)
                        End If

                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        .Item(Me.ColLabTestCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "TestName")
                        .Item(Me.colLTQuantity.Name, pos).Value = quantity
                        .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                        .Item(Me.colLTItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.ColRequestedBy.Name, pos).Value = CurrentUser.FullName
                        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, testCode, oItemCategoryID.Test).Equals(True) Then
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
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
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
            Dim unitPrice As Decimal
            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If cardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Cardiology).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, examCode, oItemCategoryID.Cardiology)
            Else
                unitPrice = GetCustomFee(examCode, oItemCategoryID.Cardiology, billNo, billModesID, associatedBillNo)
            End If

          
            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "CardiologyCategories")
                Me.dgvCardiology.Item(Me.ColCardiologySite.Name, selectedRow).Value = StringEnteredIn(row, "CardiologySites")
                Me.dgvCardiology.Item(Me.colCardiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvCardiology.Item(Me.colCardiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvCardiology.Item(Me.ColCardiologyRequest.Name, selectedRow).Value = CurrentUser.FullName

                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Cardiology).Equals(True) Then
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Cardiology
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowCardiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If CardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CardiologyCategories")
                Me.dgvCardiology.Item(Me.ColCardiologySite.Name, pos).Value = StringMayBeEnteredIn(row, "CardiologySites")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCardiology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvCardiology.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim Cardiology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Cardiology).Tables("Items")
            If Cardiology Is Nothing OrElse Cardiology.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    .Item(Me.ColCardiologyRequest.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colCardiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForCardiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCardiologyReports(ByVal visitNo As String)

        Dim oCardiologyReports As New SyncSoft.SQLDb.CardiologyReports()

        Try

            ' Load from Lab CardiologyReports
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim CardiologyReports As DataTable = oCardiologyReports.GetCardiologyReports(RevertText(visitNo)).Tables("CardiologyReports")

            If CardiologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCardiologyReports, CardiologyReports)
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
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                         Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                        Dim quantity As Integer = 1
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        .Item(Me.colCardiologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ExamFullName")
                        .Item(Me.colCardiologyQuantity.Name, pos).Value = quantity
                        Me.ShowCardiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colCardiologyUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colCardiologyItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colCardiologyPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.ColCardiologyRequest.Name, pos).Value = CurrentUser.FullName
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
            Dim unitPrice As Decimal
            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Radiology).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, examCode, oItemCategoryID.Radiology)
            Else
                unitPrice = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, associatedBillNo)
            End If

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "RadiologyCategories")
                Me.dgvRadiology.Item(Me.ColRadiologySite.Name, selectedRow).Value = StringEnteredIn(row, "RadiologySites")
                Me.dgvRadiology.Item(Me.colRadiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvRadiology.Item(Me.colRadiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvRadiology.Item(Me.ColRadiologyRequest.Name, selectedRow).Value = CurrentUser.FullName

                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Radiology).Equals(True) Then
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvRadiology.Item(Me.colExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowRadiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "RadiologyCategories")
                Me.dgvRadiology.Item(Me.ColRadiologySite.Name, pos).Value = StringMayBeEnteredIn(row, "RadiologySites")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRadiology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvRadiology.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radiology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Radiology).Tables("Items")
            If radiology Is Nothing OrElse radiology.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    .Item(Me.ColRadiologyRequest.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colRadiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForRadiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRadiologyReports(ByVal visitNo As String)

        Dim oRadiologyReports As New SyncSoft.SQLDb.RadiologyReports()

        Try

            ' Load from Lab RadiologyReports
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radiologyReports As DataTable = oRadiologyReports.GetRadiologyReports(RevertText(visitNo)).Tables("RadiologyReports")

            If radiologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvRadiologyReports, radiologyReports)
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
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                        Dim quantity As Integer = 1
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        .Item(Me.colExamFullName.Name, pos).Value = StringEnteredIn(row, "ExamFullName")
                        .Item(Me.colRadiologyQuantity.Name, pos).Value = quantity
                        Me.ShowRadiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colRadiologyUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.colRadiologyItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colRadiologyPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.ColRadiologyRequest.Name, pos).Value = CurrentUser.FullName
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


            Dim availableStock As Integer = GetAvailableStock(selectedItem)

            If availableStock.Equals(0) Then
                Me.dgvPrescription.Rows(selectedRow).DefaultCellStyle.BackColor = Color.MistyRose
            End If

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
            Me.DetailPrescribedDrug(selectedRow, RevertText(SubstringRight(selectedItem)))
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
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvPrescription.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer, selectedItem As String)
        Try
            Dim message As String
            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim unitPrice As Decimal
       
            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim drugs As DataTable = oDrugs.GetDrugs(selectedItem).Tables("Drugs")

            If drugs Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = drugs.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim availableStock As Integer = GetAvailableStock(selectedItem)
            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Drug).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, selectedItem, oItemCategoryID.Drug)
            Else
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
            End If

            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = selectedItem.ToUpper()
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
                .Item(Me.ColPrescribedby.Name, selectedRow).Value = CurrentUser.FullName

                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Drug).Equals(True) Then
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
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(selectedItem)

            ElseIf availableStock <= 0 AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is out of stock and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(selectedItem)

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
        CalculateTotalBillCost()
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
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim quantity As Single = 0
            Dim drugNo As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo)
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDosage)
            Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)
            Dim drugName As String = StringEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            If duration < 0 Then
                Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = String.Empty
                Throw New ArgumentException("Negative values not allowed for duration")

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

            If quantity < 0 Then
                Throw New ArgumentException("Negative values not allowed for quantity")
                Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = String.Empty

            End If

            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = CInt(quantity)
            Me.dgvPrescription.Item(Me.ColPrescribedQty.Name, selectedRow).Value = CInt(quantity)

            'If oVariousOptions.EnableDoctorHelpNotifications Then

            Dim averageConsumedStock As Decimal = oVariousOptions.MaximumDrugQtyToGive()


            If averageConsumedStock > 0 Then
                If quantity > averageConsumedStock Then
                    Dim Message As String = "The Drug " + drugName + " With Quantity " + quantity.ToString + " is greater than the Average Of " +
                          averageConsumedStock.ToString() + " which is usually given to Patients. " +
                           ControlChars.NewLine + "Are you sure, you would like to Proceed ? "
                    If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then
                        Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = String.Empty
                    End If

                End If
            End If


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

    Private Sub LoadPrescriptions(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug).Tables("Items")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.ColPrescribedQty.Name, pos).Value = IntegerEnteredIn(row, "DoctorQuantity")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.ColPrescribedby.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
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
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
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
                        .Item(Me.ColPrescribedby.Name, pos).Value = CurrentUser.FullName
                        .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                        count += 1

                    End With

                Next

            End If
        End If

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
            If Me.colDrugSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPrescription.Rows(e.RowIndex).IsNewRow Then

                Me.dgvPrescription.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.colDrugSelect.Index.Equals(e.ColumnIndex) Then

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
            Dim unitPrice As Decimal
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If procedures Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Procedure).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, selectedItem, oItemCategoryID.Procedure)
            Else
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)
            End If

            For Each row As DataRow In procedures.Select("ProcedureCode = '" + selectedItem + "'")
                Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvProcedures.Item(Me.colICDProcedureCode.Name, selectedRow).Value = selectedItem
                Me.dgvProcedures.Item(Me.colProcedureQuantity.Name, selectedRow).Value = 1
                Me.dgvProcedures.Item(Me.ColProcedureRequest.Name, selectedRow).Value = CurrentUser.FullName
                Me.dgvProcedures.Item(Me.colProcedureItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Procedure).Equals(True) Then
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
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadProcedures(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim procedure As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Procedure).Tables("Items")

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
                    .Item(Me.ColProcedureRequest.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
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
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                        Dim amount As Decimal = quantity * unitPrice


                        .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")

                        .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ProcedureCode")
                        .Item(Me.colProcedureQuantity.Name, pos).Value = 1
                        .Item(Me.colProcedureUnitPrice.Name, pos).Value = unitPrice
                        .Item(Me.ColProcedureRequest.Name, pos).Value = CurrentUser.FullName
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
    Private Sub ShowTheatreServiceDetails(ByVal theatreCode As String, ByVal pos As Integer)

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try

            Dim theatreServices As DataTable = oTheatreServices.GetTheatreServices(theatreCode).Tables("TheatreServices")

            If theatreServices Is Nothing OrElse theatreCode Is Nothing Then Return
            Dim row As DataRow = theatreServices.Rows(0)
            Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

            With Me.dgvTheatre
                .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "TheatreName")
                .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                .Item(Me.colTheatreSaved.Name, pos).Value = True

            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadTheatreServices(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre).Tables("Items")

            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatre.Rows.Count - 1

                Dim row As DataRow = theatre.Rows(pos)

                With Me.dgvTheatre
                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "ItemName")
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvTheatre_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellClick
        Try
            Me.Cursor = Cursors.WaitCursor

            'If e.RowIndex < 0 Then Return
            'Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
            'Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

            'Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
            'fQuickSearch.ShowDialog(Me)
            'Dim rowIndex As Integer
            'rowIndex = Me.dgvDiagnosis.NewRowIndex
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
            'fQuickSearch.ShowDialog(Me)
            Dim rowIndex As Integer

            If Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvTheatre.Rows(e.RowIndex).IsNewRow Then

                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvTheatre.NewRowIndex
                If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)

            ElseIf Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) Then
                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvTheatre.NewRowIndex
                If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
            End If

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("TheatreServices", "Theatre Code", "Theatre", Me.LoadTheatreServices(), "TheatreServicesFullName",
            '                                                         "TheatreCode", "TheatreServicesFullName", Me.dgvTheatre, Me.colICDTheatreCode, e.RowIndex)

            'Me._TheatreCode = StringMayBeEnteredIn(Me.dgvTheatre.Rows(e.RowIndex).Cells, Me.colICDTheatreCode)

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'If Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvTheatre.Rows(e.RowIndex).IsNewRow Then

            '    Me.dgvTheatre.Rows.Add()

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetTheatreEntries(e.RowIndex)

            'ElseIf Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) Then

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetTheatreEntries(e.RowIndex)




            'If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreService.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreService)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
            If Me.dgvTheatre.Rows.Count > 1 Then

                Me.SetTheatreEntries(selectedRow)

            End If

            If e.ColumnIndex.Equals(Me.colICDTheatreCode.Index) Then
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)
        'Dim odiagnosis As New SyncSoft.SQLDb.Diseases()


        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        'Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colICDDiagnosisCode)



        'If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    Dim diagnosis As DataTable = odiagnosis.GetDiseases(selectedItem).Tables("Diseases")
        '    If diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
        '    Dim row As DataRow = diagnosis.Rows(0)
        '    Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")

        '    '    Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
        '    'Dim diagnosisDisplay As String = (From data In diagnosis
        '    '                                  Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
        '    '                                  Select data.Field(Of String)("DiseaseName")).First()
        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    DisplayMessage("Diagnosis (" + enteredDisplay + ") can't be edited!")
        '    Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
        '    Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
        '    Return
        'End If

        'For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2


        '    If Not rowNo.Equals(selectedRow) Then

        '        Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colICDDiagnosisCode)

        '        If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
        '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '            Dim diagnosis As DataTable = odiagnosis.GetDiseases(enteredItem).Tables("Diseases")

        '            If diagnosis Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
        '            Dim row As DataRow = diagnosis.Rows(0)

        '            'Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()

        '            'Dim enteredDisplay As String = (From data In diagnosis
        '            '                                Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.Trim().ToUpper())
        '            '                                Select data.Field(Of String)("DiseaseName")).First()
        '            Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")
        '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        '            DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
        '            Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
        '            Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
        '            Return
        '        End If
        '    End If

        'Next

        Try
            Dim otheatre As New SyncSoft.SQLDb.TheatreServices()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colICDTheatreCode)



            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim theatre As DataTable = otheatre.GetTheatreServices(selectedItem).Tables("TheatreServices")
                If theatre Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
                Dim row As DataRow = theatre.Rows(0)
                Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre Service (" + enteredDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2


                If Not rowNo.Equals(selectedRow) Then

                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colICDTheatreCode)

                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim theatre As DataTable = otheatre.GetTheatreServices(enteredItem).Tables("TheatreServices")

                        If theatre Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
                        Dim row As DataRow = theatre.Rows(0)

                        Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                        DisplayMessage("Theatre service (" + enteredDisplay + ") already entered!")
                        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreCode
                        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            'Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colICDTheatreCode)

            'If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    Dim theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
            '    Dim theatreDisplay As String = (From data In theatre
            '                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreCode.ToUpper())
            '                                    Select data.Field(Of String)("TheatreName")).First()
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    DisplayMessage("Theatre (" + theatreDisplay + ") can't be edited!")
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreCode
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '    Return
            'End If


            'For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2


            '    If Not rowNo.Equals(selectedRow) Then
            '        Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colICDTheatreCode)
            '        If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '            Dim _Theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
            '            Dim enteredDisplay As String = (From data In _Theatre
            '                                            Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
            '                                            Select data.Field(Of String)("TheatreName")).First()
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '            DisplayMessage("Theatre (" + enteredDisplay + ") already entered!")
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '            Return
            '        End If
            '    End If
            'Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim unitPrice As Decimal
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If theatreServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, selectedItem, oItemCategoryID.Theatre)
            Else
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)
            End If

            For Each row As DataRow In theatreServices.Select("TheatreCode = '" + selectedItem + "'")
                Me.dgvTheatre.Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, selectedRow).Value = 1
                Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailTheatreService(selectedRow, RevertText(SubstringRight(selectedItem)))
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailTheatreService(ByVal selectedRow As Integer, selectedItem As String)
        Try
            Dim theatreServiceSelected As String = String.Empty
            Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()


            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim theatreService As DataTable = oTheatreServices.GetTheatreServices(selectedItem).Tables("TheatreServices")

            If theatreService Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = theatreService.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreName As String = StringEnteredIn(row, "TheatreName", "Theatre Service Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvTheatre
                
                .Item(Me.colICDTheatreCode.Name, selectedRow).Value = StringEnteredIn(row, "TheatreCode")
                .Item(Me.colTheatreService.Name, selectedRow).Value = StringEnteredIn(row, "TheatreName")
                .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = Me._TheatreCode.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvTheatre_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserAddedRow
        Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Try
            
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''           
            'Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            'Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, toDeleteRowNo).Value)

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If DeleteMessage() = Windows.Forms.DialogResult.No Then
            '    e.Cancel = True
            '    Return
            'End If

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Security.Apply(Me.btnDelete, AccessRights.Delete)
            'If Me.btnDelete.Enabled = False Then
            '    DisplayMessage("You do not have permission to delete this record!")
            '    e.Cancel = True
            '    Return
            'End If

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'With oDiagnosis
            '    .VisitNo = visitNo
            '    .DiseaseCode = diagnosis
            '    DisplayMessage(.Delete())
            'End With

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oItems.Delete())

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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub



    'Private Sub LoadPackageAllowedTheatre(packageNo As String)

    '    Dim oItems As New SyncSoft.SQLDb.Items()
    '    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '    Try

    '        Me.dgvTheatre.Rows.Clear()

    '        ' Load items not yet paid for

    '        Dim theatre As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre).Tables("Items")

    '        If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        For pos As Integer = 0 To theatre.Rows.Count - 1

    '            Dim row As DataRow = theatre.Rows(pos)

    '            With Me.dgvTheatre
    '                ' Ensure that you add a new row
    '                .Rows.Add()

    '                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

    '                .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
    '                .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
    '                .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
    '                .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
    '                .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
    '                .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
    '                .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
    '                .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
    '                .Item(Me.colTheatreSaved.Name, pos).Value = True
    '            End With
    '        Next

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Me.CalculateBillForTheatre()
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        Throw ex

    '    End Try

    'End Sub
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
            Dim unitPrice As Decimal
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If dentalService Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, selectedItem, oItemCategoryID.Dental)
            Else
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)
            End If

            Dim quantity As Integer = 1

            For Each row As DataRow In dentalService.Select("DentalCode = '" + selectedItem + "'")

                Me.dgvDental.Item(Me.colDentalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvDental.Item(Me.colDentalQuantity.Name, selectedRow).Value = quantity
                Me.dgvDental.Item(Me.colDentalItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvDental.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oItems.Delete())

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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadDentalCategoryService(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            Dim dental As DataTable = oItems.GetDentalItems(visitNo, GetLookupDataDes(oDentalCategoryID.Service)).Tables("Items")
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

    Private Sub LoadDentalReports(ByVal visitNo As String)

        'Dim oDentalReports As New SyncSoft.SQLDb.DentalReports()

        'Try

        '    ' Load from Lab DentalReports
        '    Dim dentalReports As DataTable = oDentalReports.GetDentalReports(visitNo).Tables("DentalReports")

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
            Dim unitPrice As Decimal
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If dentalLaboratory Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, selectedItem, oItemCategoryID.Dental)
            Else
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)
            End If


            Dim quantity As Integer = 1

            For Each row As DataRow In dentalLaboratory.Select("DentalCode = '" + selectedItem + "'")

                Me.dgvDentalLab.Item(Me.colDentalLabUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvDentalLab.Item(Me.colDentalLabQuantity.Name, selectedRow).Value = quantity
                Me.dgvDentalLab.Item(Me.colDentalLabItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvDentalLab.Item(Me.colDentalLabSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvDentalLab.Item(Me.colDentalLabCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oItems.Delete())

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
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadDentalCategoryLaboratory(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try

            Me.dgvDentalLab.Rows.Clear()

            ' Load items not yet paid for

            Dim dental As DataTable = oItems.GetDentalItems(visitNo, GetLookupDataDes(oDentalCategoryID.Laboratory)).Tables("Items")
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

    '#Region " Optical - Grid "

    '    Private Sub dgvOptical_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

    '        If e.ColumnIndex <> Me.colOpticalCode.Index OrElse Me.dgvOptical.Rows.Count <= 1 Then Return
    '        Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex
    '        _OpticalNameValue = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

    '    End Sub

    '    Private Sub dgvOptical_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    '        Try

    '            Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex

    '            If e.ColumnIndex.Equals(Me.colOpticalCode.Index) Then
    '                ' Ensure unique entry in the combo column
    '                If Me.dgvOptical.Rows.Count > 1 Then Me.SetOpticalServiceEntries(selectedRow)

    '            ElseIf e.ColumnIndex.Equals(Me.colOpticalQuantity.Index) Then
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.CalculateOpticalAmount(selectedRow)
    '                Me.CalculateBillForOptical()
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            ElseIf e.ColumnIndex.Equals(Me.colOpticalUnitPrice.Index) Then
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Me.CalculateOpticalAmount(selectedRow)
    '                Me.CalculateBillForOptical()
    '                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            End If

    '        Catch ex As Exception
    '            ErrorMessage(ex)

    '        End Try

    '    End Sub

    '    Private Sub SetOpticalServiceEntries(ByVal selectedRow As Integer)

    '        Try

    '            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

    '            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, selectedRow).Value).Equals(True) Then
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim _Optical As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
    '                Dim opticalDisplay As String = (From data In _Optical
    '                                                Where data.Field(Of String)("OpticalCode").ToUpper().Equals(_OpticalNameValue.ToUpper())
    '                                                Select data.Field(Of String)("OpticalName")).First()
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                DisplayMessage("Optical (" + opticalDisplay + ") can't be edited!")
    '                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue


    '                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
    '                Return
    '            End If

    '            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

    '                If Not rowNo.Equals(selectedRow) Then
    '                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(rowNo).Cells, Me.colOpticalCode)
    '                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''..''..'''''''
    '                        Dim _Optical As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
    '                        Dim enteredDisplay As String = (From data In _Optical
    '                                                        Where data.Field(Of String)("OpticalCode").ToUpper().Equals(enteredItem.ToUpper())
    '                                                        Select data.Field(Of String)("OpticalName")).First()
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        DisplayMessage("Optical (" + enteredDisplay + ") already entered!")
    '                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue
    '                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
    '                        Return
    '                    End If
    '                End If
    '            Next

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
    '            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '            If opticalServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
    '            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Optical, billNo, billModesID, associatedBillNo)

    '            For Each row As DataRow In opticalServices.Select("OpticalCode = '" + selectedItem + "'")
    '                Me.dgvOptical.Item(Me.colOpticalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
    '                Me.dgvOptical.Item(Me.colOpticalCategory.Name, selectedRow).Value = StringEnteredIn(row, "OpticalCategory")
    '                Me.dgvOptical.Item(Me.colOpticalQuantity.Name, selectedRow).Value = 1
    '                Me.dgvOptical.Item(Me.colOpticalItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
    '                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Optical).Equals(True) Then
    '                    Me.dgvOptical.Item(Me.colOpticalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
    '                Else
    '                    Me.dgvOptical.Item(Me.colOpticalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
    '                End If
    '            Next

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Me.CalculateOpticalAmount(selectedRow)
    '            Me.CalculateBillForOptical()
    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '    End Sub

    '    Private Sub dgvOptical_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
    '        Me.dgvOptical.Item(Me.colOpticalQuantity.Name, e.Row.Index - 1).Value = 1
    '    End Sub

    '    Private Sub dgvOptical_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs)

    '        Try

    '            Me.Cursor = Cursors.WaitCursor

    '            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    '            Dim oItems As New SyncSoft.SQLDb.Items()
    '            Dim toDeleteRowNo As Integer = e.Row.Index

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return
    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If Me.DoctorVisitClosed() Then
    '                e.Cancel = True
    '                Return
    '            End If

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
    '            Dim itemCode As String = SubstringRight(CStr(Me.dgvOptical.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value))

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If DeleteMessage() = Windows.Forms.DialogResult.No Then
    '                e.Cancel = True
    '                Return
    '            End If

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Security.Apply(Me.btnDelete, AccessRights.Delete)
    '            If Me.btnDelete.Enabled = False Then
    '                DisplayMessage("You do not have permission to delete this record!")
    '                e.Cancel = True
    '                Return
    '            End If

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            With oItems
    '                .VisitNo = visitNo
    '                .ItemCode = itemCode
    '                .ItemCategoryID = oItemCategoryID.Optical
    '            End With

    '            DisplayMessage(oItems.Delete())

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Catch ex As Exception
    '            ErrorMessage(ex)
    '            e.Cancel = True

    '        Finally
    '            Me.Cursor = Cursors.Default

    '        End Try

    '    End Sub

    '    Private Sub dgvOptical_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs)
    '        Me.CalculateBillForOptical()
    '    End Sub

    '    Private Sub dgvOptical_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
    '        ErrorMessage(e.Exception)
    '        e.Cancel = True
    '    End Sub

    '    Private Sub CalculateOpticalAmount(ByVal selectedRow As Integer)

    '        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalQuantity)
    '        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalUnitPrice)

    '        Me.dgvOptical.Item(Me.colOpticalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    '    End Sub

    '    Private Sub CalculateBillForOptical()

    '        Dim totalBill As Decimal

    '        ResetControlsIn(Me.pnlBill)

    '        For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 1

    '            If IsNumeric(Me.dgvOptical.Item(Me.colOpticalAmount.Name, rowNo).Value) Then
    '                totalBill += CDec(Me.dgvOptical.Item(Me.colOpticalAmount.Name, rowNo).Value)
    '            Else : totalBill += 0
    '            End If
    '        Next

    '        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
    '        Me.stbBillWords.Text = NumberToWords(totalBill)

    '    End Sub

    '    Private Sub ShowOpticalCategory(ByVal opticalCode As String, ByVal pos As Integer)

    '        Try

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            If opticalServices Is Nothing OrElse String.IsNullOrEmpty(opticalCode) Then Return

    '            For Each row As DataRow In opticalServices.Select("OpticalCode = '" + opticalCode + "'")
    '                Me.dgvOptical.Item(Me.colOpticalCategory.Name, pos).Value = StringMayBeEnteredIn(row, "OpticalCategory")
    '            Next

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Catch ex As Exception
    '            Throw ex

    '        End Try

    '    End Sub

    '    Private Sub LoadOptical(ByVal visitNo As String)

    '        Dim oItems As New SyncSoft.SQLDb.Items()
    '        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    '        Try

    '            Me.dgvOptical.Rows.Clear()

    '            ' Load items not yet paid for

    '            Dim Optical As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Optical).Tables("Items")

    '            If Optical Is Nothing OrElse Optical.Rows.Count < 1 Then Return

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            For pos As Integer = 0 To Optical.Rows.Count - 1

    '                Dim row As DataRow = Optical.Rows(pos)

    '                With Me.dgvOptical
    '                    ' Ensure that you add a new row
    '                    .Rows.Add()

    '                    .Item(Me.colOpticalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
    '                    Me.ShowOpticalCategory(StringEnteredIn(row, "ItemCode"), pos)
    '                    .Item(Me.colOpticalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
    '                    .Item(Me.colOpticalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
    '                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)
    '                    .Item(Me.colOpticalAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
    '                    .Item(Me.colOpticalNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
    '                    .Item(Me.colOpticalItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
    '                    .Item(Me.colOpticalPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
    '                    .Item(Me.colOpticalSaved.Name, pos).Value = True
    '                End With
    '            Next

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Me.CalculateBillForOptical()
    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Catch ex As Exception
    '            Throw ex

    '        End Try

    '    End Sub

    '#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.ColConsumableCode.Index) Then

                Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

                If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then
                    ' Ensure unique entry in the combo column
                    If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

                ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CalculateConsumablesAmount(selectedRow)
                    Me.CalculateBillForConsumables()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CalculateConsumablesAmount(selectedRow)
                    Me.CalculateBillForConsumables()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableCode)

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Consumable Item Name (" + _ConsumableItemValue + ") can't be edited!")
                Me.dgvConsumables.Item(Me.ColConsumableCode.Name, selectedRow).Value = _ConsumableItemValue
                Me.dgvConsumables.Item(Me.ColConsumableCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.ColConsumableCode)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable Item Name (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Item(Me.ColConsumableCode.Name, selectedRow).Value = _ConsumableItemValue
                        Me.dgvConsumables.Item(Me.ColConsumableCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DetailConsumableItem(selectedRow)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvConsumables.UserDeletedRow
        Me.CalculateBillForConsumables()
    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadPackageAttachedConsumables(PackageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedConsumables As DataTable = oItems.GetAllowedPackageConsumables(PackageNo).Tables("PackagesEXT")
        If attachedConsumables.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed Consumables on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedConsumables Is Nothing OrElse attachedConsumables.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvConsumables.Rows.Count - 1


                For pos As Integer = 0 To attachedConsumables.Rows.Count - 1
                    Dim row As DataRow = attachedConsumables.Rows(pos)
                    With Me.dgvConsumables

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim testCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                       Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "TestFullName")
                        .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                        .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                        .Item(Me.colConsumableItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablesSaved.Name, pos).Value = False
                        .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                        .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                        .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                        .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                        .Item(Me.colConsumableHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
                        count += 1

                    End With

                Next

                Me.CalculateBillForConsumables()
            End If
        End If
    End Sub

    Private Sub DetailConsumableItem(selectedRow As Integer)

        Dim selectedItem As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumableNo As String = RevertText(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim unitPrice As Decimal
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            Dim quantity As Integer = 1

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, consumableNo, oItemCategoryID.Consumable)
            Else
                unitPrice = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvConsumables
                .Item(Me.colConsumableName.Name, selectedRow).Value = StringEnteredIn(row, "ConsumableName")
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colConsumableUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colConsumableHalted.Name, selectedRow).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateConsumablesAmount(selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitPrice)

        Me.dgvConsumables.Item(Me.colConsumableAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForConsumables()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
            totalBill += amount
        Next
        CalculateTotalBillCost()
        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadConsumables(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable).Tables("Items")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To consumableItems.Rows.Count - 1

                Dim row As DataRow = consumableItems.Rows(pos)

                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", True)
                    Dim amount As Decimal = quantity * unitPrice

                    .Item(Me.ColConsumableCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                    .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumablesSaved.Name, pos).Value = True
                    .Item(Me.colConsumableItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvConsumables_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellClick
       
        If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) AndAlso Me.dgvConsumables.RowCount < 2 Then
            LoadPackageAttachedConsumables(patientpackageNo)

        End If

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("ConsumableItems", "Consumable No", "Consumable Name", Me.GetConsumableItems(), "ConsumableFullName",
                                                                     "ConsumableNo", "ConsumableName", Me.dgvConsumables, Me.ColConsumableCode, e.RowIndex)

            Me._DiagnosisCode = StringMayBeEnteredIn(Me.dgvConsumables.Rows(e.RowIndex).Cells, Me.ColConsumableCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColSelectConsumable.Index.Equals(e.ColumnIndex) AndAlso Me.dgvConsumables.Rows(e.RowIndex).IsNewRow Then

                Me.dgvConsumables.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)
            ElseIf Me.ColSelectConsumable.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try



    End Sub



#End Region

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
            Dim unitPrice As Decimal
            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Pathology).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, examCode, oItemCategoryID.Pathology)
            Else
                unitPrice = GetCustomFee(examCode, oItemCategoryID.Pathology, billNo, billModesID, associatedBillNo)
            End If


            For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "PathologyCategories")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyQuantity.Name, selectedRow).Value = 1
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Pathology).Equals(True) Then
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

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.DoctorVisitClosed() Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Pathology
            End With

            DisplayMessage(oItems.Delete())

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
        CalculateTotalBillCost()
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

    Private Sub LoadPathology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvHistopathologyRequisition.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Pathology).Tables("Items")
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

    Private Sub LoadPathologyReports(ByVal visitNo As String)

        Dim oPathologyReports As New SyncSoft.SQLDb.PathologyReports()

        Try

            ' Load from Lab PathologyReports
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathologyReports As DataTable = oPathologyReports.GetPathologyReports(RevertText(visitNo)).Tables("PathologyReports")

            If pathologyReports Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvHistopathologyReport, pathologyReports)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPathologyImagesData(ByVal visitNo As String)

        Dim oPathologyImages As New SyncSoft.SQLDb.PathologyImages()

        Try

            ' Load from Lab PathologyImages
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathologyImages As DataTable = oPathologyImages.GetPathologyImages(RevertText(visitNo)).Tables("PathologyImages")

            If pathologyImages Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvPathologyImages.Rows.Clear()

            If pathologyImages Is Nothing OrElse pathologyImages.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To pathologyImages.Rows.Count - 1

                Dim row As DataRow = pathologyImages.Rows(pos)
                With Me.dgvPathologyImages

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colPathologyImage.Name, pos).Value = ImageMayBeEnteredIn(row, "PathologyImage")
                    .Item(Me.colPathologymageName.Name, pos).Value = StringMayBeEnteredIn(row, "ImageName")

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region "Allergies -Grid"

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Load from allergies
            allergies = oAllergies.GetAllergies().Tables("Allergies")


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowAllergyNo(ByVal allergyNo As String, ByVal pos As Integer)
        Dim oAllergies As New SyncSoft.SQLDb.Allergies()
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patientAllergies Is Nothing OrElse String.IsNullOrEmpty(allergyNo) Then Return

            For Each row As DataRow In patientAllergies.Select("AllergyNo = '" + allergyNo + "'")
                ' Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, pos).Value = StringMayBeEnteredIn(row, "AllergyNo")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadAllergyData(ByVal patientNo As String)

        Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim patientAllergies As DataTable = oPatientAllergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If patientAllergies Is Nothing OrElse patientAllergies.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To patientAllergies.Rows.Count - 1

                Dim row As DataRow = patientAllergies.Rows(pos)
                With Me.dgvPatientAllergies

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colAllergy.Name, pos).Value = StringMayBeEnteredIn(row, "AllergyName")
                    .Item(Me.colAllergyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "AllergyCategory")
                    .Item(Me.colReaction.Name, pos).Value = StringMayBeEnteredIn(row, "Reaction")

                End With

            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnAddAllergy_Click(sender As System.Object, e As System.EventArgs) Handles btnAddAllergy.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVariousOptions As New VariousOptions()
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, " A Visit No, to Continue!"))

            If Not oVariousOptions.EnableSecondPatientForm Then
                Dim fPatientAllergies As New frmPatients(patientNo, True)
                fPatientAllergies.tbcPatients.SelectTab(fPatientAllergies.tpgPatientAllergies.Name)
                fPatientAllergies.Edit()
                fPatientAllergies.ShowDialog()
            Else
                Dim fPatientAllergies As New frmPatientsTwo(patientNo, True)
                fPatientAllergies.tbcPatients.SelectTab(fPatientAllergies.tpgPatientAllergies.Name)
                fPatientAllergies.Edit()
                fPatientAllergies.ShowDialog()
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
#End Region

#Region " Doctor - Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim docTypeID As New LookupDataID.DocumentTypeID()
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
            Dim printdesc As String = (stbFullName.Text + " 's" + " Medical Report (Dr)")
            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgGeneral.Name
                    Me.PrintMedicalReport()
                    SavePrintDetails(patientNo, visitNo, printdesc, docTypeID.MedicalReport)
                Case Me.tpgClinicalFindings.Name
                    MessageBox.Show("Print Clinical Findings...")
                Case Me.tpgEyeAssessment.Name
                    MessageBox.Show("Print Eye Assessment...")
                Case Me.tpgOrthoptics.Name
                    MessageBox.Show("Print Orthoptics...")

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

                Case Me.tpgOptical.Name
                    MessageBox.Show("Print Optical...")
                Case Me.tpgRefraction.Name
                    MessageBox.Show("Print Refraction...")

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

                Case Me.tpgReferrals.Name
                    MessageBox.Show("Print Referrals...")

                Case Me.tpgDiagnosis.Name
                    MessageBox.Show("Print Diagnosis...")

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
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
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
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
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
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
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
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
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Prescription - Printing "

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
                    Dim itemName As String = cells.Item(Me.colDrug.Name).Value.ToString()
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
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
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
                    Dim itemName As String = cells.Item(Me.colTheatreService.Name).Value.ToString()
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
                    Dim itemName As String = (From data In _DentalServices
                                              Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("DentalName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colDentalQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDentalUnitPrice.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colDentalAmount.Name).Value.ToString()

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
                    Dim itemName As String = (From data In _Dental
                                              Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("DentalName")).First()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As String = cells.Item(Me.colDentalLabQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colDentalLabUnitPrice.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colDentalLabAmount.Name).Value.ToString()

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
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
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

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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
            Dim muac As String = StringMayBeEnteredIn(Me.nbxMUAC)
            Dim pulse As String = StringMayBeEnteredIn(Me.nbxPulse)
            Dim bloodPressure As String = StringMayBeEnteredIn(Me.stbBloodPressure)
            Dim headCircum As String = StringMayBeEnteredIn(Me.nbxHeadCircum)
            Dim bodySurfaceArea As String = StringMayBeEnteredIn(Me.nbxBodySurfaceArea)
            Dim respirationRate As String = StringMayBeEnteredIn(Me.nbxRespirationRate)
            Dim oxygenSaturation As String = StringMayBeEnteredIn(Me.nbxOxygenSaturation)
            Dim heartRate As String = StringMayBeEnteredIn(Me.nbxHeartRate)
            Dim bMI As String = StringMayBeEnteredIn(Me.nbxBMI)
            Dim bmiStatus As String = StringMayBeEnteredIn(Me.stbBMIStatus)
            Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)

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

            If Not String.IsNullOrEmpty(muac) Then
                If textData.Length > 1 Then
                    textData.Append(", MUAC: " + height + " cm")
                Else : textData.Append("MUAC: " + height + " cm")
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

            If Not String.IsNullOrEmpty(respirationRate) Then
                If textData.Length > 1 Then
                    textData.Append(", Respiration Rate: " + respirationRate + " B/min")
                Else : textData.Append("Respiration Rate: " + respirationRate + " B/min")
                End If
            End If

            If Not String.IsNullOrEmpty(oxygenSaturation) Then
                If textData.Length > 1 Then
                    textData.Append(", Oxygen Saturation: " + oxygenSaturation + " %")
                Else : textData.Append("Oxygen Saturation: " + oxygenSaturation + " %")
                End If
            End If

            If Not String.IsNullOrEmpty(heartRate) Then
                If textData.Length > 1 Then
                    textData.Append(", Heart Rate: " + heartRate + " B/min")
                Else : textData.Append("Heart Rate: " + heartRate + " B/min")
                End If
            End If

            If Not String.IsNullOrEmpty(bMI) Then
                If textData.Length > 1 Then
                    textData.Append(", BMI: " + bMI + " Kg/M²")
                Else : textData.Append("BMI: " + bMI + " Kg/M²")
                End If
            End If

            If Not String.IsNullOrEmpty(bmiStatus) Then
                If textData.Length > 1 Then
                    textData.Append(", BMI Status: " + bmiStatus)
                Else : textData.Append("BMI Status: " + bmiStatus)
                End If
            End If

            If Not String.IsNullOrEmpty(notes) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Notes: " + ControlChars.NewLine + notes)
                Else : textData.Append("Notes: " + ControlChars.NewLine + notes)
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

            Dim presentingComplaint As String = StringMayBeEnteredIn(Me.stbPresentingComplaint)
            Dim clinicalNotes As String = StringMayBeEnteredIn(Me.stbClinicalNotes)
            Dim rOS As String = StringMayBeEnteredIn(Me.stbROS)
            Dim pMH As String = StringMayBeEnteredIn(Me.stbPMH)
            Dim pOH As String = StringMayBeEnteredIn(Me.stbPOH)
            Dim pGH As String = StringMayBeEnteredIn(Me.stbPGH)
            Dim fSH As String = StringMayBeEnteredIn(Me.stbFSH)
            Dim generalAppearance As String = StringMayBeEnteredIn(Me.stbGeneralAppearance)
            Dim respiratory As String = StringMayBeEnteredIn(Me.stbRespiratory)
            Dim cVS As String = StringMayBeEnteredIn(Me.stbCVS)
            Dim eNT As String = StringMayBeEnteredIn(Me.stbENT)
            Dim abdomen As String = StringMayBeEnteredIn(Me.stbAbdomen)
            Dim cNS As String = StringMayBeEnteredIn(Me.stbCNS)
            Dim eYE As String = StringMayBeEnteredIn(Me.stbEYE)
            Dim muscularSkeletal As String = StringMayBeEnteredIn(Me.stbMuscularSkeletal)
            Dim skin As String = StringMayBeEnteredIn(Me.stbSkin)
            Dim pV As String = StringMayBeEnteredIn(Me.stbPV)
            Dim psychologicalStatus As String = StringMayBeEnteredIn(Me.stbPsychologicalStatus)
            Dim provisionalDiagnosis As String = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)
            Dim treatmentPlan As String = StringMayBeEnteredIn(Me.stbTreatmentPlan)

            If Not String.IsNullOrEmpty(presentingComplaint) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Presenting Complaint: " + ControlChars.NewLine + presentingComplaint)
                Else : textData.Append("Presenting Complaint: " + ControlChars.NewLine + presentingComplaint)
                End If
            End If

            If Not String.IsNullOrEmpty(clinicalNotes) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
                Else : textData.Append("Clinical Notes: " + ControlChars.NewLine + clinicalNotes)
                End If
            End If

            If Not String.IsNullOrEmpty(rOS) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("ROS: " + ControlChars.NewLine + rOS)
                Else : textData.Append("ROS: " + ControlChars.NewLine + rOS)
                End If
            End If

            If Not String.IsNullOrEmpty(pMH) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("PMH/PSH: " + ControlChars.NewLine + pMH)
                Else : textData.Append("PMH/PSH: " + ControlChars.NewLine + pMH)
                End If
            End If

            If Not String.IsNullOrEmpty(pOH) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("POH: " + ControlChars.NewLine + pOH)
                Else : textData.Append("POH: " + ControlChars.NewLine + pOH)
                End If
            End If

            If Not String.IsNullOrEmpty(pGH) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("PGH: " + ControlChars.NewLine + pGH)
                Else : textData.Append("PGH: " + ControlChars.NewLine + pGH)
                End If
            End If

            If Not String.IsNullOrEmpty(fSH) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("FSH: " + ControlChars.NewLine + fSH)
                Else : textData.Append("FSH: " + ControlChars.NewLine + fSH)
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

            If Not String.IsNullOrEmpty(eNT) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("ENT: " + ControlChars.NewLine + eNT)
                Else : textData.Append("ENT: " + ControlChars.NewLine + eNT)
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

            If Not String.IsNullOrEmpty(eYE) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("EYE: " + ControlChars.NewLine + eYE)
                Else : textData.Append("EYE: " + ControlChars.NewLine + eYE)
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

            If Not String.IsNullOrEmpty(skin) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Skin & Other(s): " + ControlChars.NewLine + skin)
                Else : textData.Append("Skin & Other(s): " + ControlChars.NewLine + skin)
                End If
            End If

            If Not String.IsNullOrEmpty(pV) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("PV/PR: " + ControlChars.NewLine + pV)
                Else : textData.Append("PV/PR: " + ControlChars.NewLine + pV)
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

            If Not String.IsNullOrEmpty(provisionalDiagnosis) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Provisional Diagnosis: " + ControlChars.NewLine + provisionalDiagnosis)
                Else : textData.Append("Provisional Diagnosis: " + ControlChars.NewLine + provisionalDiagnosis)
                End If
            End If

            If Not String.IsNullOrEmpty(treatmentPlan) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Treatment Plan: " + ControlChars.NewLine + treatmentPlan)
                Else : textData.Append("Treatment Plan: " + ControlChars.NewLine + treatmentPlan)
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
                    Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colTheatreService)
                    Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = StringMayBeEnteredIn(cells, Me.colTheatreService)
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

#Region " Security Method "

    Private Sub ApplySecurity()

        Try

            If Me.tbcDrRoles.SelectedTab.Name.Equals(Me.tpgEye.Name) Then

                Me.btnSave.Tag = Me.tbcEye.SelectedTab.Tag.ToString()
                Me.btnDelete.Tag = Me.tbcEye.SelectedTab.Tag.ToString()
            Else
                Me.btnSave.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()
                Me.btnDelete.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()

            End If

            Security.Apply(Me.btnSave, AccessRights.Write)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkNavigateVisits.Checked = Not Me.chkNavigateVisits.Checked
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgLaboratory.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = True
            Case Me.tpgCardiology.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgRadiology.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgPrescriptions.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = True
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgProcedures.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgTheatre.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgDental.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False
            Case Me.tpgDentalLab.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = True
            Case Me.tbcEye.Name


                If tbcEye.SelectedTab.Name.Equals(Me.tpgOrthoptics.Name) Then
                    Me.cmsDoctorCopy.Visible = False
                    Me.cmsDoctorSelectAll.Visible = False
                    Me.cmsDoctorQuickSearch.Visible = True
                    Me.cmsfrequentlyprescribeddrugs.Visible = False
                    Me.cmsFrequentlyRequestedTests.Visible = False
                End If
            Case Me.tpgLabResults.Name

                Me.cmsDoctorCopy.Visible = True
                Me.cmsDoctorSelectAll.Visible = True
                Me.cmsDoctorQuickSearch.Visible = False
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False

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
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False

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
                Me.cmsfrequentlyprescribeddrugs.Visible = False
                Me.cmsFrequentlyRequestedTests.Visible = False

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
                Me.cmsfrequentlyprescribeddrugs.Visible = False
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



                Case Me.tpgPrescriptions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrugNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvPrescription.NewRowIndex - 1
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowIndex).Cells, Me.colDrugNo)
                    Me.SetDrugsEntries(rowIndex, SubstringRight(selectedItem))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                   
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

                Case Me.tpgProcedures.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Procedures", Me.dgvProcedures, Me.colProcedureCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvProcedures.NewRowIndex
                    If rowIndex > 0 Then Me.SetProceduresEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgTheatre.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
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

                Case Me.tpgOpticalServices.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableName)
                    fQuickSearch.ShowDialog(Me)
                    rowIndex = Me.dgvConsumables.NewRowIndex
                    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "Doctor Templates"

    Private Sub stbPresentingComplaint_Enter(sender As System.Object, e As System.EventArgs) Handles stbPresentingComplaint.Enter
        Me.PlaceTemplateButton(Me.stbPresentingComplaint)
    End Sub

    Private Sub stbClinicalNotes_Enter(sender As System.Object, e As System.EventArgs) Handles stbClinicalNotes.Enter
        Me.PlaceTemplateButton(Me.stbClinicalNotes)
    End Sub

    Private Sub stbROS_Enter(sender As System.Object, e As System.EventArgs) Handles stbROS.Enter
        Me.PlaceTemplateButton(Me.stbROS)
    End Sub

    Private Sub stbPMH_Enter(sender As System.Object, e As System.EventArgs) Handles stbPMH.Enter
        Me.PlaceTemplateButton(Me.stbPMH)
    End Sub

    Private Sub stbPOH_Enter(sender As System.Object, e As System.EventArgs) Handles stbPOH.Enter
        Me.PlaceTemplateButton(Me.stbPOH)
    End Sub

    Private Sub stbPGH_Enter(sender As System.Object, e As System.EventArgs) Handles stbPGH.Enter
        Me.PlaceTemplateButton(Me.stbPGH)
    End Sub

    Private Sub stbFSH_Enter(sender As System.Object, e As System.EventArgs) Handles stbFSH.Enter
        Me.PlaceTemplateButton(Me.stbFSH)
    End Sub

    Private Sub stbGeneralAppearance_Enter(sender As System.Object, e As System.EventArgs) Handles stbGeneralAppearance.Enter
        Me.PlaceTemplateButton(Me.stbGeneralAppearance)
    End Sub

    Private Sub stbRespiratory_Enter(sender As System.Object, e As System.EventArgs) Handles stbRespiratory.Enter
        Me.PlaceTemplateButton(Me.stbRespiratory)
    End Sub

    Private Sub stbCVS_Enter(sender As System.Object, e As System.EventArgs) Handles stbCVS.Enter
        Me.PlaceTemplateButton(Me.stbCVS)
    End Sub

    Private Sub stbENT_Enter(sender As System.Object, e As System.EventArgs) Handles stbENT.Enter
        Me.PlaceTemplateButton(Me.stbENT)
    End Sub

    Private Sub stbAbdomen_Enter(sender As System.Object, e As System.EventArgs) Handles stbAbdomen.Enter
        Me.PlaceTemplateButton(Me.stbAbdomen)
    End Sub

    Private Sub stbCNS_Enter(sender As System.Object, e As System.EventArgs) Handles stbCNS.Enter
        Me.PlaceTemplateButton(Me.stbCNS)
    End Sub

    Private Sub stbEYE_Enter(sender As System.Object, e As System.EventArgs) Handles stbEYE.Enter
        Me.PlaceTemplateButton(Me.stbEYE)
    End Sub

    Private Sub stbMuscularSkeletal_Enter(sender As System.Object, e As System.EventArgs) Handles stbMuscularSkeletal.Enter
        Me.PlaceTemplateButton(Me.stbMuscularSkeletal)
    End Sub

    Private Sub stbSkin_Enter(sender As System.Object, e As System.EventArgs) Handles stbSkin.Enter
        Me.PlaceTemplateButton(Me.stbSkin)
    End Sub

    Private Sub stbPV_Enter(sender As System.Object, e As System.EventArgs) Handles stbPV.Enter
        Me.PlaceTemplateButton(Me.stbPV)
    End Sub

    Private Sub stbPsychologicalStatus_Enter(sender As System.Object, e As System.EventArgs) Handles stbPsychologicalStatus.Enter
        Me.PlaceTemplateButton(Me.stbPsychologicalStatus)
    End Sub

    Private Sub stbProvisionalDiagnosis_Enter(sender As System.Object, e As System.EventArgs) Handles stbProvisionalDiagnosis.Enter
        Me.PlaceTemplateButton(Me.stbProvisionalDiagnosis)
    End Sub

    Private Sub stbTreatmentPlan_Enter(sender As System.Object, e As System.EventArgs) Handles stbTreatmentPlan.Enter
        Me.PlaceTemplateButton(Me.stbTreatmentPlan)
    End Sub

    Private Sub tpgClinicalFindings_Leave(sender As System.Object, e As System.EventArgs) Handles tpgClinicalFindings.Leave
        Me.btnLoadTemplate.Visible = False
    End Sub

    Private Sub PlaceTemplateButton(textControl As TextBox)
        Dim x As Integer = textControl.Location.X
        Dim y As Integer = textControl.Location.Y
        Dim width As Integer = textControl.Size.Width
        Me.btnLoadTemplate.Location = New System.Drawing.Point(x + width, y)
        Me.btnLoadTemplate.TabIndex = textControl.TabIndex - 1
        Me.btnLoadTemplate.BringToFront()
        Me.btnLoadTemplate.Visible = True
    End Sub

    Private Sub btnLoadTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadTemplate.Click

        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()

        If ((Me.btnLoadTemplate.Location.X - stbPresentingComplaint.Width = stbPresentingComplaint.Location.X) AndAlso
            (Me.btnLoadTemplate.Location.Y = stbPresentingComplaint.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PresentingComplaint, Me.stbPresentingComplaint, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbClinicalNotes.Width = stbClinicalNotes.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbClinicalNotes.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ClinicalNotes, Me.stbClinicalNotes, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbROS.Width = stbROS.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbROS.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ROS, Me.stbROS, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbPMH.Width = stbPMH.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbPMH.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PMH, Me.stbPMH, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbPOH.Width = stbPOH.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbPOH.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.POH, Me.stbPOH, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbPGH.Width = stbPGH.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbPGH.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PGH, Me.stbPGH, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbFSH.Width = stbFSH.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbFSH.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.FSH, Me.stbFSH, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbGeneralAppearance.Width = stbGeneralAppearance.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbGeneralAppearance.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.GeneralAppearance, Me.stbGeneralAppearance, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbRespiratory.Width = stbRespiratory.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbRespiratory.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Respiratory, Me.stbRespiratory, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbCVS.Width = stbCVS.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbCVS.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.CVS, Me.stbCVS, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbENT.Width = stbENT.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbENT.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ENT, Me.stbENT, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbAbdomen.Width = stbAbdomen.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbAbdomen.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Abdomen, Me.stbAbdomen, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbCNS.Width = stbCNS.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbCNS.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.CNS, Me.stbCNS, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbEYE.Width = stbEYE.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbEYE.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.EYE, Me.stbEYE, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbMuscularSkeletal.Width = stbMuscularSkeletal.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbMuscularSkeletal.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.MuscularSkeletal, Me.stbMuscularSkeletal, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbSkin.Width = stbSkin.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbSkin.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Skin, Me.stbSkin, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbPV.Width = stbPV.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbPV.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PV, Me.stbPV, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbPsychologicalStatus.Width = stbPsychologicalStatus.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbPsychologicalStatus.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PsychologicalStatus, Me.stbPsychologicalStatus, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbProvisionalDiagnosis.Width = stbProvisionalDiagnosis.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbProvisionalDiagnosis.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ProvisionalDiagnosis, Me.stbProvisionalDiagnosis, True)
            fGetTemplates.ShowDialog(Me)

        ElseIf ((Me.btnLoadTemplate.Location.X - stbTreatmentPlan.Width = stbTreatmentPlan.Location.X) AndAlso
                (Me.btnLoadTemplate.Location.Y = stbTreatmentPlan.Location.Y)) Then
            Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.TreatmentPlan, Me.stbTreatmentPlan, True)
            fGetTemplates.ShowDialog(Me)

        End If

    End Sub


#End Region


    Private Sub cmsfrequentlyprescribeddrugs_Click(sender As System.Object, e As System.EventArgs) Handles cmsfrequentlyprescribeddrugs.Click

        Try

            frmDrfrequentlyprescribeddrugs.ShowDialog()
            LoadfrequentPrescribedDrugs()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub stbEmergency_Click(sender As System.Object, e As System.EventArgs) Handles stbEmergency.Click
        Try

            Me.ShowWaitingVisits()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fWaitingVisits As New frmWaitingVisits(Me.stbVisitNo, True)
            fWaitingVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub nbxRightIOP_Leave(sender As Object, e As System.EventArgs) Handles nbxRightIOP.Leave
        Dim _IOP As Integer = IntegerMayBeEnteredIn(nbxRightIOP)
        Dim errorMessage As String = "The Value must between 0 and 70"
        If _IOP < 0 OrElse _IOP > 70 Then
            ErrProvider.SetError(nbxRightIOP, errorMessage)
        Else
            ErrProvider.SetError(nbxRightIOP, "")
        End If
    End Sub

    Private Sub btnAttachPackage_Click(sender As System.Object, e As System.EventArgs) Handles btnAttachPackage.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fAttachPackage As New frmAttachPackage(visitNo)
            fAttachPackage.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub btnImmunisation_Click(sender As System.Object, e As System.EventArgs) Handles btnImmunisation.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No"))

            Dim fVaccines As New frmImmunisationVaccines(patientNo)

            fVaccines.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Public Sub LoadFrequentlyRequestedTests()
        Try


            Dim TestPair As KeyValuePair(Of String, String)
            For Each TestPair In frequentlyRequestedTests.Values

                With Me.dgvLabTests
                    .Rows.Add()
                    .Item(Me.ColLabTestCode.Name, .NewRowIndex - 1).Value = TestPair.Value
                    Me.SetLabTestsEntries(.NewRowIndex - 1, SubstringRight(TestPair.Value))
                End With
            Next

            frequentlyRequestedTests.Values.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub cmsFrequentlyRequestedTests_Click(sender As System.Object, e As System.EventArgs) Handles cmsFrequentlyRequestedTests.Click
        frmDoctorfrequentlyRequestedTest.ShowDialog()
        LoadFrequentlyRequestedTests()
    End Sub

    Private Sub LoadfrequentPrescribedDrugs()
        Try

          
            Dim DrugPair As KeyValuePair(Of String, String)
            For Each DrugPair In frequentlyPrescribedDrugs.Values

                With Me.dgvPrescription
                    .Rows.Add()
                    .Item(Me.colDrugNo.Name, .NewRowIndex - 1).Value = DrugPair.Key
                    .Item(Me.colDrug.Name, .NewRowIndex - 1).Value = DrugPair.Value
                    Me.SetDrugsEntries(.NewRowIndex - 1, DrugPair.Key)
                End With
            Next

            frequentlyPrescribedDrugs.Values.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub cboEarlyInfection_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboEarlyInfection.SelectedIndexChanged
        If Me.cboEarlyInfection.SelectedIndex = 1 Then
            Me.stbInfectionDetails.Enabled = False
        Else
            Me.stbInfectionDetails.Enabled = True

        End If
    End Sub

    Private Sub cboConvulsions_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConvulsions.SelectedIndexChanged
        If Me.cboConvulsions.SelectedIndex = 1 Then
            Me.stbConvulsionsDetails.Enabled = False
        Else
            Me.stbConvulsionsDetails.Enabled = True

        End If
    End Sub


    Private Sub cboInfection_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboInfection.SelectedIndexChanged
        If Me.cboInfection.SelectedIndex = 1 Then
            Me.stbInfectionDetails.Enabled = False
        Else
            Me.stbInfectionDetails.Enabled = True

        End If
    End Sub

    Private Sub cboAccidentDuringPregnancy_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAccidentDuringPregnancy.SelectedIndexChanged
        If Me.cboAccidentDuringPregnancy.SelectedIndex = 1 Then
            Me.stbDetailsOfAccident.Enabled = False
        Else
            Me.stbDetailsOfAccident.Enabled = True

        End If
    End Sub

    Private Sub cboUseOfDrugsOrPrescription_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUseOfDrugsOrPrescription.SelectedIndexChanged
        If Me.cboUseOfDrugsOrPrescription.SelectedIndex = 1 Then
            Me.stbDrugDetails.Enabled = False
        Else
            Me.stbDrugDetails.Enabled = True

        End If
       
    End Sub

    Private Sub cboChronicIllness_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboChronicIllness.SelectedIndexChanged
        If Me.cboChronicIllness.SelectedIndex = 1 Then
            Me.stbDetailsOfIllness.Enabled = False
        Else
            Me.stbDetailsOfIllness.Enabled = True

        End If
    End Sub

    Private Sub cboCaesarian_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCaesarian.SelectedIndexChanged
        If Me.cboCaesarian.SelectedIndex = 1 Then
            Me.nbxNoOfCaesarians.Enabled = False
        Else
            Me.nbxNoOfCaesarians.Enabled = True

        End If
    End Sub

    Private Sub cboStillBirth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboStillBirth.SelectedIndexChanged
        If Me.cboStillBirth.SelectedIndex = 1 Then
            Me.nbxNoOfStillBirths.Enabled = False
        Else
            Me.nbxNoOfStillBirths.Enabled = True

        End If
    End Sub

    Private Sub cboAbortions_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAbortions.SelectedIndexChanged
        If Me.cboAbortions.SelectedIndex = 1 Then
            Me.nbxNoOfAbortions.Enabled = False
        Else
            Me.nbxNoOfAbortions.Enabled = True

        End If
    End Sub


    Private Sub cboBabyAlive_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboBabyAlive.SelectedIndexChanged
        If Me.cboBabyAlive.SelectedIndex = 1 Then
            Me.cboCauseOfDeath.Enabled = True
        Else
            Me.cboCauseOfDeath.Enabled = False

        End If
    End Sub

   

    Private Sub btnViewList_Click(sender As System.Object, e As System.EventArgs) Handles btnViewList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.LabResults, Nothing)
        fIPDAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub


    Private Sub LockItemsUnitPrices()
        Dim oVariousOptions As New VariousOptions()
        Dim unitPrice As DataGridViewColumn() = {colProcedureUnitPrice, colDentalUnitPrice, colTheatreUnitPrice}
        DisableGridComponets(unitPrice, oVariousOptions.LockItemsUnitPrices)

    End Sub


    Private Sub CalculateTotalBillCost()

        If Me.stbVisitNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.stbVisitNo.Text) Then

            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim totalDrugCost, totalLabCost, totalCardiologycost, totalProcedurescost, totalRadiologycost,
              totalTheatreCost, totalDentalCost, totalDentalLabCost, totalConsumablesCost, totaTheatreServices, totalHistopathologyRequisitionCost As Decimal


            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
                If IsNumeric(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value) Then
                    totalDrugCost += CDec(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value)
                Else : totalDrugCost += 0
                End If
            Next

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1

                If IsNumeric(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value) Then
                    totalLabCost += CDec(Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, rowNo).Value)
                Else : totalLabCost += 0
                End If
            Next


            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

                If IsNumeric(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value) Then
                    totalCardiologycost += CDec(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value)
                Else : totalCardiologycost += 0
                End If
            Next


            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1

                If IsNumeric(Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, rowNo).Value) Then
                    totalRadiologycost += CDec(Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, rowNo).Value)
                Else : totalRadiologycost += 0
                End If
            Next

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

                If IsNumeric(Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, rowNo).Value) Then
                    totalProcedurescost += CDec(Me.dgvProcedures.Item(Me.colProcedureUnitPrice.Name, rowNo).Value)
                Else : totalProcedurescost += 0
                End If
            Next


            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

                If IsNumeric(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value) Then
                    totalTheatreCost += CDec(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value)
                Else : totalTheatreCost += 0
                End If
            Next

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1

                If IsNumeric(Me.dgvDental.Item(Me.colDentalAmount.Name, rowNo).Value) Then
                    totalDentalCost += CDec(Me.dgvDental.Item(Me.colDentalAmount.Name, rowNo).Value)
                Else : totalDentalCost += 0
                End If
            Next


            For rowNo As Integer = 0 To Me.dgvDentalLab.RowCount - 1

                If IsNumeric(Me.dgvDentalLab.Item(Me.colDentalLabAmount.Name, rowNo).Value) Then
                    totalDentalLabCost += CDec(Me.dgvDentalLab.Item(Me.colDentalLabAmount.Name, rowNo).Value)
                Else : totalDentalLabCost += 0
                End If
            Next


            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
                totalConsumablesCost += amount
            Next

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 1

                If IsNumeric(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value) Then
                    totalHistopathologyRequisitionCost += CDec(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value)
                Else : totalHistopathologyRequisitionCost += 0
                End If
            Next



            totalBillConsumption = (totalDrugCost + totalLabCost + totalCardiologycost + totalProcedurescost + totalRadiologycost +
              totalTheatreCost + totalDentalCost + totalDentalLabCost + totalConsumablesCost + totaTheatreServices + totalHistopathologyRequisitionCost)
        End If
    End Sub


    Private Sub frmDoctor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        Try
            If e.KeyCode = Keys.S AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                btnSave_Click(sender, e)
            ElseIf e.KeyCode = Keys.F AndAlso e.Modifiers = Keys.Control Then
                e.Handled = True
                btnLoadSeeDrVisits_Click(sender, e)
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





