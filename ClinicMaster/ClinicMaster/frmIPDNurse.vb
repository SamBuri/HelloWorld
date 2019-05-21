
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

Public Class frmIPDNurse

#Region " Fields "

    Private clinicalFindingsSaved As Boolean = True
    Private currentAllSaved As Boolean = True
    Private currentAdmissionNo As String = String.Empty
    Private currentRoundNo As String = String.Empty

    Private diseases As DataTable

    Private IPDNurseAssessmentSaved As Boolean = True
    Private IPDNursingPlanSaved As Boolean = True
    Private IPDNurseEvaluationSaved As Boolean = True

    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private _TestValue As String = String.Empty
    Private _DrugNo As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _PrescriptionConsumableValue As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private _DiagnosisCode As String = String.Empty

    Private proPaint As New System.Diagnostics.Process
    Private patientAllergies As DataTable
    Private allergies As DataTable

#End Region

#Region " Validations "

    Private Sub dtpRoundDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpNurseRoundDateTime.Validating

        Dim errorMSG As String = "Round date time can't be before admission date time!"

        Try

            Dim admissionDateTime As Date = DateTimeMayBeEnteredIn(Me.stbAdmissionDateTime)
            Dim roundDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpNurseRoundDateTime)

            If GetShortDate(roundDateTime) = AppData.NullDateValue Then Return

            If roundDateTime < admissionDateTime Then
                ErrProvider.SetError(Me.dtpNurseRoundDateTime, errorMSG)
                Me.dtpNurseRoundDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpNurseRoundDateTime, String.Empty)
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

            Me.dtpNurseRoundDateTime.MaxDate = Today.AddDays(1)
            Me.dtpNurseRoundDateTime.Value = Now
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowFluidInBalances()
            Me.GetUnAttendedInWardAdmissions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colFluidsMeasureFluidType, LookupObjects.FluidType, True)
            LoadLookupDataCombo(Me.colFluidsMeasureFluidCategory, LookupObjects.FluidCategoryID, True)
            LoadLookupDataCombo(Me.cboNursingCareEffective, LookupObjects.YesNo, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

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
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Nurse).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub SetNextNurseRoundNo(ByVal RoundNo As String)

        Try

            Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("IPDNurse", "NurseRoundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim roundID As String = oIPDNurse.GetNextIPDNurseRoundID(RoundNo).ToString()
            roundID = roundID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbNurseRoundNo.Text = FormatText(RoundNo + roundID.Trim(), "IPDNurse", "NurseRoundNo")

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try

    End Sub

    Private Sub SetLastNurseRoundNo(ByVal RoundNo As String)

        Try

            Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("IPDNurse", "NurseRoundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim roundID As String = Nothing
            If CInt(oIPDNurse.GetNextIPDNurseRoundID(RoundNo)) = 1 Then
                roundID = oIPDNurse.GetNextIPDNurseRoundID(RoundNo).ToString()
            ElseIf CInt(oIPDNurse.GetNextIPDNurseRoundID(RoundNo)) > 1 Then
                roundID = (CInt(oIPDNurse.GetNextIPDNurseRoundID(RoundNo)) - 1).ToString()
            End If

            roundID = roundID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbNurseRoundNo.Text = FormatText(RoundNo + roundID.Trim(), "IPDNurse", "NurseRoundNo")

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        Finally
            Me.dtpNurseRoundDateTime.ResetText()
            Me.dtpNurseRoundDateTime.Checked = False
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
            'Me.ShowlatestIPDVisionAssessment(admissionNo)
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
            'Me.cboRoundNo.Items.Clear()
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
        'Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        '' Dim roundNo As String = RevertText(StringValueEnteredIn(Me.cboRoundNo, "RoundNo No!"))
        'Dim admissionNo As String

        'Dim doctorRounds As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNo(admissionNo).Tables("IPDDoctor")
        '    Dim message As String
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return
        'If Me.cboRoundNo.Text = String.Empty Then
        '    message = "This patient has no Doctor Round. Please register round with IPD Doctor!"
        'Else
        Dim fFindRoundNo As New frmFindAutoNo(Me.cboRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()

        ' End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Me.SetLastNurseRoundNo(RevertText(StringEnteredIn(Me.cboRoundNo)))
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.chkCreateNewRound.Checked Then
            Me.SetNextNurseRoundNo(RevertText(StringEnteredIn(Me.cboRoundNo)))
        End If
       
    End Sub

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo, False)
            fInWardAdmissions.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)
            'Me.ShowlatestIPDVisionAssessment(admissionNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Not Me.chkCreateNewRound.Checked Then Me.LoadIPDDoctorByAdmissionNo()
            Me.LoadIPDDoctorByAdmissionNo()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub btnUnAttendedInWardAdmissions_Click(sender As Object, e As EventArgs) Handles btnUnAttendedInWardAdmissions.Click

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo, True)
            fInWardAdmissions.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return

            Me.cboRoundNo.Enabled = True
            Me.ShowPatientDetails(admissionNo)
            'Me.ShowlatestIPDVisionAssessment(admissionNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Not Me.chkCreateNewRound.Checked Then Me.LoadIPDDoctorByAdmissionNo()
            Me.LoadIPDDoctorByAdmissionNo()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub btnFluidInbalance_Click(sender As Object, e As EventArgs) Handles btnFluidInbalance.Click

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fGetToCountFluidInBalances As New frmGetToCountFluidInBalances(Me.stbAdmissionNo, AutoNumber.NurseRoundNo)
            fGetToCountFluidInBalances.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowPatientDetails(admissionNo)
            Me.ShowDrugAdmission(admissionNo)
            'Me.ShowlatestIPDVisionAssessment(admissionNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkCreateNewRound.Checked Then Me.LoadIPDDoctorByAdmissionNo()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.ShowFluidsBalanceTotals(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ClearControls()

        'Me.stbNurseRoundNo.Clear()
        Me.stbOtherAttendingNurse.Clear()
        Me.stbAttendingDoctor.Clear()
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
        'Me.btnAddConsumables.Enabled = False
        'Me.btnNewVisionAssessment.Enabled = False
        Me.nbxWeight.Clear()
        Me.nbxTemperature.Clear()
        Me.nbxHeight.Clear()
        Me.nbxPulse.Clear()
        Me.stbBloodPressure.Clear()
        Me.nbxHeadCircum.Clear()
        Me.nbxBodySurfaceArea.Clear()
        If Me.chkCreateNewRound.Checked Then Me.cboRoundNo.Text = String.Empty
        Me.ResetControls()

    End Sub

    Private Sub ResetControls()

        Me.cboStaffNo.SelectedIndex = -1
        Me.cboStaffNo.SelectedIndex = -1
        Me.dtpNurseRoundDateTime.Value = Now
        Me.dtpNurseRoundDateTime.Checked = False
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.grpTriage)
        ResetControlsIn(Me.grpNotes)
        ResetControlsIn(Me.tpgDiagnosis)
        ResetControlsIn(Me.tpgAdministorDrugs)
        ResetControlsIn(Me.tpgGivenDrugs)
        ResetControlsIn(Me.tpgDrugAdministrationStatus)
        ResetControlsIn(Me.tpgConsumableAdministrationStatus)
        ResetControlsIn(Me.tpgGivenConsumables)
        ResetControlsIn(Me.tpgFluidsMeasure)
        ResetControlsIn(Me.tpgFluidsBalance)
        ResetControlsIn(Me.tpgNurseAssessment)
        ResetControlsIn(Me.tpgPlanning)
        ResetControlsIn(Me.tpgEvaluation)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        clinicalFindingsSaved = True
        clinicalFindingsSaved = True
        IPDNurseAssessmentSaved = True
        IPDNurseEvaluationSaved = True
        IPDNursingPlanSaved = True
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ShowPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()

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

            Me.stbChronicalDiseases.Text = StringMayBeEnteredIn(row, "ChronicDiseases")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(oIPDDoctor.GetRoundNo(admissionNo), "IPDDoctor", "RoundNo")

            
            Dim nurseRoundNo As String = RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo))
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))

            If Not String.IsNullOrEmpty(oIPDDoctor.GetRoundNo(admissionNo)) Then Me.LoadIPDDrugAdministration(oIPDDoctor.GetRoundNo(admissionNo))
            If Not String.IsNullOrEmpty(nurseRoundNo) Then Me.LoadIPDGivenDrugs(nurseRoundNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim IPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            ' If IPDDoctor Is Nothing Then
            For Each IPDDoctorRow As DataRow In IPDDoctor.Rows
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(IPDDoctorRow, "AttendingDoctor")
                Me.dtpDoctorRoundDateTime.Value = DateTimeEnteredIn(IPDDoctorRow, "RoundDateTime")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Me.SetNextNurseRoundNo(oIPDDoctor.GetRoundNo(admissionNo)) 'Me.SetNextRoundNo(admissionNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            Throw eX

        End Try

    End Sub

    Private Sub ShowDrugAdmission(ByVal admissionNo As String)

        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        
        Try

            'Me.ClearControls()

            Dim iPDDrugAdministration As DataTable = oIPDDrugAdministration.GetDrugsAdministedPerAdmission(admissionNo, oItemCategoryID.Drug).Tables("IPDDrugAdministration")
            Dim iPDConsumableAdministration As DataTable = oIPDDrugAdministration.GetDrugsAdministedPerAdmission(admissionNo, oItemCategoryID.Consumable).Tables("IPDDrugAdministration")

            If iPDDrugAdministration Is Nothing OrElse iPDDrugAdministration.Rows.Count < 1 Then Return
            Me.dgvDrugAdministrationStatus.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To iPDDrugAdministration.Rows.Count - 1

                Dim row As DataRow = iPDDrugAdministration.Rows(pos)
                With Me.dgvDrugAdministrationStatus
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDrugAdministrationRoundNo.Name, pos).Value = FormatText(StringEnteredIn(row, "RoundNo"), "RoundNo", "RoundNo")
                    .Item(Me.colDrugAdministrationItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDrugAdministrationItemFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colDrugAdministrationItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colDrugAdministrationDosage.Name, pos).Value = StringEnteredIn(row, "Dosage")
                    .Item(Me.colDrugAdministrationDuration.Name, pos).Value = StringEnteredIn(row, "Duration")
                    .Item(Me.colDrugAdministrationQuantity.Name, pos).Value = StringEnteredIn(row, "Quantity")
                    .Item(Me.colDrugAdministrationGivenQuantity.Name, pos).Value = StringEnteredIn(row, "QuantityTaken")
                    .Item(Me.colDrugAdministrationBalance.Name, pos).Value = StringEnteredIn(row, "Balance")
                    .Item(Me.colDrugAdministrationUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugAdministrationDispensedFrom.Name, pos).Value = StringEnteredIn(row, "Location")
                End With
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If iPDConsumableAdministration Is Nothing OrElse iPDConsumableAdministration.Rows.Count < 1 Then Return
            Me.dgvConsumableAdministrationStatus.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To iPDConsumableAdministration.Rows.Count - 1

                Dim row As DataRow = iPDConsumableAdministration.Rows(pos)
                With Me.dgvConsumableAdministrationStatus
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colConsumableAdministrationStatusRoundNo.Name, pos).Value = FormatText(StringEnteredIn(row, "RoundNo"), "RoundNo", "RoundNo")
                    .Item(Me.colConsumableAdministrationStatusItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colConsumableAdministrationStatusConsumable.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colConsumableAdministrationStatusItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colConsumableAdministrationStatusQuantity.Name, pos).Value = StringEnteredIn(row, "Quantity")
                    .Item(Me.colConsumableAdministrationStatusGivenQty.Name, pos).Value = StringEnteredIn(row, "QuantityTaken")
                    .Item(Me.colConsumableAdministrationStatusBalance.Name, pos).Value = StringEnteredIn(row, "Balance")
                    .Item(Me.colConsumableAdministrationStatusUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                End With
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch eX As Exception
            ErrorMessage(eX)
        End Try

    End Sub

    Private Sub ShowFluidsBalanceTotals(ByVal roundNo As String)

        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

        Try

            'Me.ClearControls()
            If String.IsNullOrEmpty(roundNo) Then Return

            Dim IPDNurseFluids As DataTable = oIPDNurseFluids.GetIPDNurseFluidsBalanceInputOutputTotals(roundNo).Tables("IPDNurseFluidsBalanceInputOutputTotals")
            
            If IPDNurseFluids Is Nothing OrElse IPDNurseFluids.Rows.Count < 1 Then Return
            Me.dgvFluidsBalance.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To IPDNurseFluids.Rows.Count - 1

                Dim row As DataRow = IPDNurseFluids.Rows(pos)
                With Me.dgvFluidsBalance
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colFluidsBalanceRoundNo.Name, pos).Value = FormatText(StringEnteredIn(row, "RoundNo"), "RoundNo", "RoundNo")
                    .Item(Me.colFluidsBalanceFluidType.Name, pos).Value = StringEnteredIn(row, "FluidType")
                    .Item(Me.colFluidsBalanceQuantityIN.Name, pos).Value = IntegerEnteredIn(row, "QuantityIN")
                    .Item(Me.colFluidsBalanceQuantityOUT.Name, pos).Value = IntegerEnteredIn(row, "QuantityOUT")

                End With
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            
        Catch eX As Exception
            ErrorMessage(eX)
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
        Me.stbNurseRoundNo.Clear()
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
            'xxx()
            Me.ShowPatientDetails(admissionNo)
            Me.ShowDrugAdmission(admissionNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.ShowFluidsBalanceTotals(roundNo)
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
        'Me.btnLoadRounds.Enabled = Not state
        Me.btnFindNurseRoundNo.Enabled = Not state
        Me.stbNurseRoundNo.Enabled = Not state
        Me.pnlNavigateRounds.Enabled = Not state
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Me.cboRoundNo.Enabled = Not state
        Me.stbOtherAttendingNurse.Enabled = state
        Me.dtpNurseRoundDateTime.Enabled = Not state
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.colFluidsMeasureFluidCategory.ReadOnly = Not state
        Me.colFluidsMeasureFluidType.ReadOnly = Not state
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If state Then
        '    Me.cboRoundNo.Enabled = Not InitOptions.RoundNoLocked
        '    ResetControlsIn(Me.pnlNavigateRounds)
        'Else : Me.cboRoundNo.Enabled = True
        'End If

        Me.cboStaffNo.Enabled = state
        Me.dtpNurseRoundDateTime.Enabled = state
        Me.btnLoadList.Enabled = state
        'Me.btnViewList.Enabled = Not state
        'Me.btnViewRadiologyReportsList.Enabled = Not state
        'Me.btnViewDispensingStatus.Enabled = Not state

        If reset Then
            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgGeneral)
            ResetControlsIn(Me.tpgFluidsMeasure)
            ResetControlsIn(Me.grpTriage)
            ResetControlsIn(Me.grpNotes)
            ResetControlsIn(Me.tpgDiagnosis)

            Me.ResetControls()
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            IPDNurseAssessmentSaved = True
            IPDNursingPlanSaved = True
            IPDNurseEvaluationSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If

    End Sub

    Private Sub chkCreateNewRound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCreateNewRound.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            If Not Me.AllSaved() Then
                Me.chkCreateNewRound.Checked = Not Me.chkCreateNewRound.Checked
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.EnableResetRoundCTLS(Me.chkCreateNewRound.Checked, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
        
    End Sub

    Private Sub btnDrawClinicalImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            Me.Cursor = Cursors.WaitCursor

            LoadProcess(proPaint, "MSPaint.exe", AppData.AppTitle + "-Paint")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

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
        'Me.stbNurseRoundNo.Enabled = True
        'Me.stbNurseRoundNo.Clear()
        If Me.chkCreateNewRound.Checked Then
            Me.SetNextNurseRoundNo(RevertText(StringEnteredIn(Me.cboRoundNo)))
        Else
            Me.SetLastNurseRoundNo(RevertText(StringEnteredIn(Me.cboRoundNo)))
        End If


        If Not String.IsNullOrEmpty(RevertText(StringEnteredIn(Me.cboRoundNo))) Then Me.LoadIPDDrugAdministration(RevertText(StringEnteredIn(Me.cboRoundNo)))
        If Not String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))) Then Me.ShowDrugAdmission(RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo)))
       

        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.cboRoundNo.Text = currentRoundNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub cboRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoundNo.Leave

        Try
            'LoadRoundsData

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' If Me.chkCreateNewRound.Checked Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.cboRoundNo.Text = currentRoundNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))) Then
                Me.ShowRoundsHeaderData()
            End If
            'DisplayMessage(Me.stbNurseRoundNo.Text)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowDrugAdmission(admissionNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.ShowFluidsBalanceTotals(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub stbNurseRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbNurseRoundNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.cboRoundNo.Text = currentRoundNo
                Return
            End If
            Dim nurseRoundNo As String = RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(nurseRoundNo) Then
                Me.ShowNurseRoundsHeaderData()
                LoadIPDGivenDrugs(nurseRoundNo)
                LoadIPDNurseFluids(nurseRoundNo)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowDrugAdmission(admissionNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.ShowFluidsBalanceTotals(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            'Me.ClearControls()
            'ResetControlsIn(Me.pnlNavigateRounds)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.cboRoundNo))
            If Not String.IsNullOrEmpty(roundNo) Then Me.LoadRoundsData(roundNo)

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)
        End Try

    End Sub

    Private Sub ShowNurseRoundsHeaderData()

        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ResetControlsIn(Me.pnlNavigateRounds)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nurseRoundNo As String = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse Round No!"))
            If String.IsNullOrEmpty(nurseRoundNo) Then Return

            Dim iPDNurse As DataTable = oIPDNurse.GetIPDNurse(nurseRoundNo).Tables("IPDNurse")
            Dim iPDNurseData As EnumerableRowCollection(Of DataRow) = iPDNurse.AsEnumerable()
            Dim roundNo As String = (From data In iPDNurseData Select data.Field(Of String)("RoundNo")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadNurseRoundsData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        End Try

    End Sub

    Private Sub LoadRoundsData(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()

        Try


            Dim nurseRoundNo As String = RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim iPDDoctorData As EnumerableRowCollection(Of DataRow) = iPDDoctor.AsEnumerable()
            Dim admissionNo As String = (From data In iPDDoctorData Select data.Field(Of String)("AdmissionNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(admissionNo)
            'Me.SetNextNurseRoundNo(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbNurseRoundNo.Text = FormatText(oIPDNurse.GetNurseRoundNo(admissionNo), "IPDNurse", "NurseRoundNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            'Me.cboStaffNo.Text = (From data In iPDDoctorData Select data.Field(Of String)("StaffFullName")).First()
            Me.dtpNurseRoundDateTime.Value = (From data In iPDDoctorData Select data.Field(Of Date)("RoundDateTime")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClinicalFindings(nurseRoundNo)
            Me.LoadIPDNurseAssessment(nurseRoundNo)
            Me.LoadIPDNursingPlan(nurseRoundNo)
            Me.LoadIPDNurseEvaluation(nurseRoundNo)
            ''Me.LoadIPDDiagnosis(roundNo)
            Me.LoadAllergyData(RevertText(StringMayBeEnteredIn(Me.stbPatientNo)))


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadNurseRoundsData(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim iPDDoctorData As EnumerableRowCollection(Of DataRow) = iPDDoctor.AsEnumerable()
            Dim admissionNo As String = (From data In iPDDoctorData Select data.Field(Of String)("AdmissionNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(admissionNo)
            'Me.SetNextNurseRoundNo(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCreateNewRound.Checked Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            Me.cboStaffNo.Text = (From data In iPDDoctorData Select data.Field(Of String)("StaffFullName")).First()
            Me.dtpNurseRoundDateTime.Value = (From data In iPDDoctorData Select data.Field(Of Date)("RoundDateTime")).First()

            Dim nurseRoundNo As String = RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClinicalFindings(RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo)))
            Me.LoadIPDNurseAssessment(RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo)))
            Me.LoadIPDNurseEvaluation(RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo)))
            Me.LoadIPDNursingPlan(RevertText(StringMayBeEnteredIn(Me.stbNurseRoundNo)))
            ''Me.LoadIPDDiagnosis(roundNo)
            
            Me.LoadAllergyData(RevertText(StringMayBeEnteredIn(Me.stbPatientNo)))


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click
        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim nurseRoundNo As String = RevertText(StringEnteredIn(stbNurseRoundNo, "Nurse Round No!"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Select Case Me.tbcDrRoles.SelectedTab.Name

            ' Case Me.tpgGeneral.Name

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oIPDNurse.NurseRoundNo = nurseRoundNo
            DisplayMessage(oIPDNurse.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgGeneral)
            ResetControlsIn(Me.tpgClinicalFindings)
            ResetControlsIn(Me.tpgAdministorDrugs)
            ResetControlsIn(Me.tpgAdministorConsumables)
            ResetControlsIn(Me.tpgGivenDrugs)
            ResetControlsIn(Me.tpgGivenConsumables)
            ResetControlsIn(Me.tpgDrugAdministrationStatus)
            ResetControlsIn(Me.tpgConsumableAdministrationStatus)
            ResetControlsIn(Me.tpgFluidsMeasure)
            ResetControlsIn(Me.tpgFluidsBalance)

            ResetControlsIn(Me.tpgNurseAssessment)
            ResetControlsIn(Me.tpgPlanning)
            ResetControlsIn(Me.tpgEvaluation)

            'clinicalFindingsSaved = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub


#Region " IPDNurseAlerts "

    Private Function ShowFluidInBalances() As Integer

        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim FluidInBalances As DataTable = oIPDNurseFluids.FluidInBalances().Tables("FluidInBalances")

            Dim iPDAlertsNo As Integer = FluidInBalances.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblFluidInbalance.Text = "Fluid InBalances: " + iPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function GetUnAttendedInWardAdmissions() As Integer

        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
        Dim oVariousOptions As New VariousOptions()

        Dim IPDAlertDays As Integer = oVariousOptions.IPDNurseAlertDays
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim UnAttendedInWardAdmissions As DataTable = oIPDNurse.GetUnAttendedInWardAdmissions(IPDAlertDays).Tables("GetUnAttendedInWardAdmissions")

            Dim iPDAlertsNo As Integer = UnAttendedInWardAdmissions.Rows.Count
            'DisplayMessage(iPDAlertsNo.ToString)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblDrugAdministration.Text = "Drug Administration: " + iPDAlertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub frmIPDNurse_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.ShowFluidInBalances()
        Me.GetUnAttendedInWardAdmissions()
    End Sub
    
#End Region

#Region " Save Methods "

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Me.Cursor = Cursors.WaitCursor()

            Try
                If (DateTimeEnteredIn(Me.dtpNurseRoundDateTime, "Nurse Round Date Time") = Nothing) Or (SubstringEnteredIn(Me.cboStaffNo, "Staff No!") Is Nothing) Or (RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse Round No!")) Is Nothing) Then Return


            Me.SaveClinicalFindings()
                Me.SaveIPDDrugAdministration()
            Me.SaveIPDConsumableAdministration()
            Me.SaveIPDNurseFluids()
            'Me.SaveIPDNurseAssessment()
            'Me.SaveIPDNursingPlan()
            'Me.SaveIPDNurseEvaluation()
            Select Case Me.tbcDrRoles.SelectedTab.Name
                Case Me.tpgGeneral.Name
                    If Me.tbcGeneral.SelectedTab.Name.Equals(Me.tpgNurseAssessment.Name) Then Me.SaveIPDNurseAssessment()
                    If Me.tbcGeneral.SelectedTab.Name.Equals(Me.tpgPlanning.Name) Then Me.SaveIPDNursingPlan()
                    If Me.tbcGeneral.SelectedTab.Name.Equals(Me.tpgEvaluation.Name) Then Me.SaveIPDNurseEvaluation()


            End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            Me.chkCreateNewRound.Checked = False
            Me.chkNavigateRounds.Checked = True
            Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
            Me.pnlNavigateRounds.Enabled = True
            If Not Me.chkCreateNewRound.Checked = False Then Me.ClearControls()
            Me.ShowFluidInBalances()
            Me.GetUnAttendedInWardAdmissions()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default()
        End Try


    End Sub

    Private Sub SaveClinicalFindings()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
            Dim oStaff As New SyncSoft.SQLDb.Staff()
            Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()
            Dim message As String

            With oIPDNurse

                .RoundNo = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                .NurseRoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse Round No!"))
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
                .RespirationRate = ShortMayBeEnteredIn(Me.nbxRespirationRate, 0)
                .OxygenSaturation = SingleMayBeEnteredIn(Me.nbxOxygenSaturation, -1)
                .HeartRate = ShortMayBeEnteredIn(Me.nbxHeartRate, 0)
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .NurseRoundDateTime = DateTimeEnteredIn(Me.dtpNurseRoundDateTime, "Nurse Round Date Time")
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff No!")
                .OtherAttendingNurse = StringMayBeEnteredIn(Me.stbOtherAttendingNurse)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If .Weight <= 0 AndAlso .Temperature <= 0 AndAlso .Height <= 0 AndAlso .Pulse <= 0 AndAlso
                'String.IsNullOrEmpty(.BloodPressure) AndAlso .HeadCircum <= 0 AndAlso .BodySurfaceArea <= 0 AndAlso
                '.RespirationRate <= 0 AndAlso .OxygenSaturation <= 0 AndAlso .HeartRate <= 0 AndAlso
                'String.IsNullOrEmpty(.Notes) Then Return
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DateTimeMayBeEnteredIn(Me.dtpNurseRoundDateTime) < CDate(FormatDateTime(Today)) And Me.chkCreateNewRound.Checked = False Then
                    message = "You are trying to update Nurse clinical findings for a passed round." + _
                                            ControlChars.NewLine + "Are you sure you want to do this?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                Dim staff As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")
                Dim miniStaff As EnumerableRowCollection(Of DataRow) = staff.AsEnumerable()
                Dim doctorLoginID As String = (From data In miniStaff Select data.Field(Of String)("LoginID")).First()

                If String.IsNullOrEmpty(doctorLoginID) Then
                    message = "The attending doctor selected does not have an associated login ID we recommend " + _
                   "that you contact the administrator to have this fixed. Else you won’t get system alerts." + _
                                           ControlChars.NewLine + "Are you sure you want to continue?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim admissionStatus As String = StringEnteredIn(Me.stbAdmissionStatus, "Admission Status!")
                If admissionStatus.ToUpper().Equals(GetLookupDataDes(oAdmissionStatusID.Discharged).ToUpper()) Then
                    message = "This patient has been discharged. You can’t create a new round on a discharged admission!"
                    Throw New ArgumentException(message)
                Else
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If



            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveIPDDrugAdministration()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            'If Me.dgvPrescription.Rows.Count < 2 Then Return

            If DateTimeMayBeEnteredIn(Me.dtpNurseRoundDateTime) < CDate(FormatDateTime(Today)) And Me.chkCreateNewRound.Checked = False Then
                Dim Message As String = "You are trying to update Drug Administration for a passed round." + _
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Using oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration()

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                    Dim givenQuantity As Integer = IntegerEnteredIn(cells, Me.ColQuantitytoGive, "Quantity to give!")
                    Dim remainingQty As Integer = IntegerEnteredIn(cells, Me.ColRemainingQty, "Remaining Quantity!")
                    Dim drugAdminDateTime As Date = DateTimeEnteredIn(Me.dtpNurseRoundDateTime, "Nurse Round Date Time!")


                    If (givenQuantity > remainingQty) Then
                        Throw New ArgumentException("Given Quantity can't be more than Remaining Quantity!")
                    ElseIf (givenQuantity <= 0) Then
                        Throw New ArgumentException("Given Quantity can't be zero or less,Please select another drug")
                    End If

                    With oIPDDrugAdministration

                        .NurseRoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "NurseRoundNo!"))
                        .TakenDateTime = drugAdminDateTime
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                        .itemCategoryID = oItemCategoryID.Drug
                        .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colDrug))
                        .QuantityTaken = givenQuantity
                        .NurseNotes = StringEnteredIn(cells, Me.ColNurseNotes)
                        .LoginID = CurrentUser.LoginID
                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With

                    oIPDDrugAdministration.Save()
                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgDrugAdministration)
            ResetControlsIn(Me.tpgGivenDrugs)
            ResetControlsIn(Me.tpgDrugAdministrationStatus)

            
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SaveIPDConsumableAdministration()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            For rowNo As Integer = 0 To Me.dgvAdministorConsumables.RowCount - 2

                Using oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration()

                    Dim cells As DataGridViewCellCollection = Me.dgvAdministorConsumables.Rows(rowNo).Cells
                    Dim givenQuantity As Integer = IntegerEnteredIn(cells, Me.colAdministorConsumablesQuantityToGive, "Quantity to give!")
                    Dim remainingQty As Integer = IntegerEnteredIn(cells, Me.colAdministorConsumablesRemainingQty, "Remaining Quantity!")
                    Dim drugAdminDateTime As Date = DateTimeEnteredIn(Me.dtpNurseRoundDateTime, "Nurse Round Date Time!")


                    If (givenQuantity > remainingQty) Then
                        Throw New ArgumentException("Given Quantity can't be more than Remaining Quantity!")
                    ElseIf (givenQuantity <= 0) Then
                        Throw New ArgumentException("Given Quantity can't be zero or less,Please select another drug")
                    End If

                    With oIPDDrugAdministration

                        .NurseRoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "NurseRoundNo!"))
                        .TakenDateTime = drugAdminDateTime
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colAdministorConsumables))
                        .itemCategoryID = oItemCategoryID.Consumable
                        .ItemName = SubstringLeft(StringEnteredIn(cells, Me.colAdministorConsumables))
                        .QuantityTaken = givenQuantity
                        .NurseNotes = StringEnteredIn(cells, Me.colAdministorConsumablesNurseNotes)
                        .LoginID = CurrentUser.LoginID
                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With

                    oIPDDrugAdministration.Save()
                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvAdministorConsumables.Item(Me.colAdministorConsumablesSaved.Name, rowNo).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me.tpgConsumableAdministration)
            ResetControlsIn(Me.tpgGivenConsumables)
            ResetControlsIn(Me.tpgConsumableAdministrationStatus)
            If Not (String.IsNullOrEmpty(RevertText(StringEnteredIn(Me.stbAdmissionNo, "AdmissionNo!")))) Then Me.ShowDrugAdmission(RevertText(StringEnteredIn(Me.stbAdmissionNo, "AdmissionNo!")))

            'Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub SaveIPDNurseFluids()

        Try
            'If Me.dgvFluidsMeasure.Rows.Count < 2 Then Return

            If DateTimeMayBeEnteredIn(Me.dtpNurseRoundDateTime) < CDate(FormatDateTime(Today)) And Me.chkCreateNewRound.Checked = False And Me.dgvFluidsMeasure.Rows.Count > 2 Then
                Dim Message As String = "You are trying to update Fluid Measure Entries for a passed round." + _
                                        ControlChars.NewLine + "Are you sure you want to do this?"
                If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Return
            End If

            For rowNo As Integer = 0 To Me.dgvFluidsMeasure.RowCount - 2

                Using oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

                    Dim cells As DataGridViewCellCollection = Me.dgvFluidsMeasure.Rows(rowNo).Cells

                    Dim fluidTypeID As String = StringEnteredIn(cells, Me.colFluidsMeasureFluidType, "Fluid Type!")
                    Dim fluidcategoryID As String = StringEnteredIn(cells, Me.colFluidsMeasureFluidCategory, "fluid category ID!")
                    Dim RouteID As String = StringEnteredIn(cells, Me.colFluidsMeasureRouteID, "fluid Route ID!")
                    Dim Quantity As Integer = IntegerEnteredIn(cells, Me.colFluidsMeasureFluidQuantity, "Quantity!")
                    Dim nurseNotes As String = StringEnteredIn(cells, Me.colFluidsMeasureFluidNurseNotes, "nurse Notes!")

                    Dim nurseDateTime As Date = DateTimeEnteredIn(Me.dtpNurseRoundDateTime, "Nurse Round Date Time!")

                    With oIPDNurseFluids

                        .NurseRoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "NurseRoundNo!"))
                        '.NurseRoundNo = RevertText("1600006301020015")
                        .TakenDateTime = nurseDateTime
                        .FluidTypeID = fluidTypeID
                        .FluidCategoryID = fluidcategoryID
                        .RouteID = RouteID
                        .Quantity = Quantity
                        .NurseNotes = nurseNotes
                        .LoginID = CurrentUser.LoginID

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                    oIPDNurseFluids.Save()
                End Using

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidSaved.Name, rowNo).Value = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'ResetControlsIn(Me.tpgFluidsBalance)
            'ResetControlsIn(Me.tpgGivenDrugs)
            ResetControlsIn(Me.tpgFluidsBalance)
            If Not (String.IsNullOrEmpty(RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!")))) Then Me.ShowFluidsBalanceTotals(RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!")))

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub SaveIPDNurseAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDNurseAssessment As New SyncSoft.SQLDb.IPDNurseAssessment()

            With oIPDNurseAssessment

                .RoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse's Round No!"))
                .Complaint = StringMayBeEnteredIn(Me.stbComplaint)
                .Etiology = StringMayBeEnteredIn(Me.stbEtiology)
                .SignsAndSymptoms = StringMayBeEnteredIn(Me.stbSignsAndSymptoms)
                .ProposedSolution = StringMayBeEnteredIn(Me.stbProposedSolution)

                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If String.IsNullOrEmpty(.Complaint) AndAlso String.IsNullOrEmpty(.Etiology) AndAlso
                'String.IsNullOrEmpty(.SignsAndSymptoms) AndAlso
                'String.IsNullOrEmpty(.SignsAndSymptoms) Then _
                'Throw New ArgumentException("Must Register At Least One Item in Nurse Assessment!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                IPDNurseAssessmentSaved = True
                'DisplayMessage("Nurse Assessment Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveIPDNursingPlan()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDNursingPlan As New SyncSoft.SQLDb.IPDNursingPlan()

            With oIPDNursingPlan

                .RoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse's Round No!"))
                .ExpectedOutcome = StringMayBeEnteredIn(Me.stbExpectedOutcome)
                .NursingActions = StringMayBeEnteredIn(Me.stbNursingActions)
                .Implementation = StringMayBeEnteredIn(Me.stbImplementation)

                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If String.IsNullOrEmpty(.ExpectedOutcome) AndAlso String.IsNullOrEmpty(.NursingActions) AndAlso
                'String.IsNullOrEmpty(.Implementation) Then _
                'Throw New ArgumentException("Must Register At Least One Item in Nursing Plan!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                IPDNursingPlanSaved = True
                'DisplayMessage("Nursing Plan Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveIPDNurseEvaluation()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oIPDNurseEvaluation As New SyncSoft.SQLDb.IPDNurseEvaluation()

            With oIPDNurseEvaluation

                .RoundNo = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "Nurse's Round No!"))
                .NursingCareEffective = StringValueMayBeEnteredIn(Me.cboNursingCareEffective)
                .ProposedModifications = StringMayBeEnteredIn(Me.stbProposedModifications)
                .EvaluationNotes = StringMayBeEnteredIn(Me.stbEvaluationNotes)
                .LoginID = CurrentUser.LoginID

                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If String.IsNullOrEmpty(.NursingCareEffective) AndAlso String.IsNullOrEmpty(.ProposedModifications) AndAlso
                'String.IsNullOrEmpty(.EvaluationNotes) Then _
                'Throw New ArgumentException("Must Register At Least One Item in Nurse Evaluation!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                IPDNurseEvaluationSaved = True
                'DisplayMessage("Nurse Evaluation Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try

            Dim message As String = "Please ensure that all items are saved on "
            Dim roundNo As String = StringMayBeEnteredIn(Me.cboRoundNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not clinicalFindingsSaved Then
                DisplayMessage(message + Me.tpgGeneral.Text)
                Me.tbcDrRoles.SelectTab(Me.tpgGeneral)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If

            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function


#End Region

#Region "IPDDrugAdministration"

    Private Sub LoadClinicalFindings(ByVal nurseRoundNo As String)

        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()

        Try

            ResetControlsIn(Me.tpgGeneral)
            ResetControlsIn(Me.grpNotes)

            Dim iPDNurse As DataTable = oIPDNurse.GetIPDNurse(nurseRoundNo).Tables("IPDNurse")

            If iPDNurse Is Nothing Then Return

            For Each row As DataRow In iPDNurse.Rows

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
                Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
                Me.cboStaffNo.Text = StringMayBeEnteredIn(row, "StaffNo")
                Me.stbOtherAttendingNurse.Text = StringMayBeEnteredIn(row, "OtherAttendingNurse")
                Me.dtpNurseRoundDateTime.Value = DateTimeEnteredIn(row, "NurseRoundDateTime")
                'Me.dtpDoctorRoundDateTime.Value = DateTimeEnteredIn(row, "DoctorRoundDateTime")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            clinicalFindingsSaved = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadIPDDrugAdministration(ByVal roundNo As String)
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        'Dim oItemCategoryID As New LookupDataID.fluidCategoryId()

        Try
            Dim iPDtemsDrugs As DataTable = oIPDItems.GetIPDItemsByRoundNo(roundNo, oItemCategoryID.Drug).Tables("IPDItems")
            Dim iPDtemsConsumables As DataTable = oIPDItems.GetIPDItemsByRoundNo(roundNo, oItemCategoryID.Consumable).Tables("IPDItems")
            'Dim iPDtemsRow As DataRow = iPDtems.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colAdministorConsumables.Items.Clear()
            Me.colDrug.Items.Clear()
            LoadComboData(Me.colDrug, iPDtemsDrugs, "ItemFullName")
            LoadComboData(Me.colAdministorConsumables, iPDtemsConsumables, "ItemFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub LoadIPDGivenDrugs(ByVal nurseRoundNo As String)

        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvGivendrugs.Rows.Clear()

            Dim drugs As DataTable = oIPDDrugAdministration.GetIPDDrugAdministration(nurseRoundNo, oItemCategoryID.Drug).Tables("IPDDrugAdministration")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                With Me.dgvGivendrugs
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.ColReturnItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.ColReturnQuantityTaken.Name, pos).Value = IntegerEnteredIn(row, "QuantityTaken")
                    .Item(Me.ColReturnGivenDateTime.Name, pos).Value = StringEnteredIn(row, "TakenDateTime")
                    .Item(Me.ColReturnNurseNotes.Name, pos).Value = StringEnteredIn(row, "NurseNotes")
                    .Item(Me.ColReturnGivenBy.Name, pos).Value = StringEnteredIn(row, "StaffName")
                    '.Item(Me.ColReturnSaved.Name, pos).Value = True
                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub LoadIPDGivenConsumables(ByVal nurseRoundNo As String)

        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.dgvGivenConsumables.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim consumableItems As DataTable = oIPDDrugAdministration.GetIPDDrugAdministration(nurseRoundNo, oItemCategoryID.Consumable).Tables("IPDDrugAdministration")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To consumableItems.Rows.Count - 1

                Dim row As DataRow = consumableItems.Rows(pos)
                With Me.dgvGivenConsumables
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.coldgvGivenConsumable.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.coldgvGivenConsumablesQuantity.Name, pos).Value = IntegerEnteredIn(row, "QuantityTaken")
                    .Item(Me.coldgvGivenConsumablesGivenAt.Name, pos).Value = StringEnteredIn(row, "TakenDateTime")
                    .Item(Me.coldgvGivenConsumablesNurseNotes.Name, pos).Value = StringEnteredIn(row, "NurseNotes")
                    .Item(Me.coldgvGivenConsumablesGivenBy.Name, pos).Value = StringEnteredIn(row, "StaffName")
                    '.Item(Me.ColReturnSaved.Name, pos).Value = True
                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub LoadIPDNurseFluids(ByVal nurseRoundNo As String)

        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids

        Try
            Me.dgvFluidsMeasure.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim IPDNurseFluids As DataTable = oIPDNurseFluids.GetIPDNurseFluids(nurseRoundNo).Tables("IPDNurseFluids")
            If IPDNurseFluids Is Nothing OrElse IPDNurseFluids.Rows.Count < 1 Then Return


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'LoadGridData(Me.dgvFluidsMeasure, IPDNurseFluids)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'For pos As Integer = 0 To dgvFluidsMeasure.Rows.Count - 2
            '    With Me.dgvFluidsMeasure
            '        .Item(Me.colFluidsMeasureFluidSaved.Name, pos).Value = True
            '    End With

            'Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To IPDNurseFluids.Rows.Count - 1

                Dim row As DataRow = IPDNurseFluids.Rows(pos)
                With Me.dgvFluidsMeasure
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colFluidsMeasureFluidType.Name, pos).Value = StringMayBeEnteredIn(row, "FluidTypeID")
                    .Item(Me.colFluidsMeasureFluidCategory.Name, pos).Value = StringMayBeEnteredIn(row, "FluidCategoryID")
                    .Item(Me.colFluidsMeasureRouteID.Name, pos).Value = StringMayBeEnteredIn(row, "FluidRouteID")
                    .Item(Me.colFluidsMeasureFluidRoute.Name, pos).Value = StringMayBeEnteredIn(row, "Route")
                    .Item(Me.colFluidsMeasureFluidQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colFluidsMeasureFluidNurseNotes.Name, pos).Value = StringMayBeEnteredIn(row, "NurseNotes")
                    .Item(Me.colFluidsMeasureFluidSaved.Name, pos).Value = True
                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.colFluidsMeasureFluidTransferMode.ReadOnly = True
            Me.colFluidsMeasureFluidCategory.ReadOnly = True
            Me.colFluidsMeasureFluidType.ReadOnly = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub


    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvAdministorConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAdministorConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colAdministorConsumables.Index OrElse Me.dgvAdministorConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvAdministorConsumables.CurrentCell.RowIndex
        _PrescriptionConsumableValue = StringMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumables)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrug.Index) Then

                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)
            ElseIf e.ColumnIndex.Equals(Me.ColQuantitytoGive.Index) Then
                Me.CalculateRemainingQty(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvAdministorConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdministorConsumables.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvAdministorConsumables.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colAdministorConsumables.Index) Then

                If Me.dgvAdministorConsumables.Rows.Count > 1 Then Me.SetConsumablesEntries(selectedRow)
            ElseIf e.ColumnIndex.Equals(Me.colAdministorConsumablesQuantityToGive.Index) Then
                Me.CalculateConsumablesRemainingQty(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateRemainingQty(selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim issuedQty As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColGivenQty)
        Me.dgvPrescription.Item(Me.ColRemainingQty.Name, selectedRow).Value = (quantity - issuedQty)
        Dim remainingbal As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColRemainingQty)

        If (remainingbal <= 0) Then
            Throw New ArgumentException("This patient has received all Prescribed Quanity for this drug ." +
                                                   ControlChars.NewLine + "Please issue another drug")
            Me.dgvPrescription.Rows.RemoveAt(selectedRow)
            Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = Me._DrugNo
            Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True

        End If


    End Sub

    Private Sub CalculateConsumablesRemainingQty(selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumablesQuantity)
        Dim issuedQty As Integer = IntegerMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumablesGivenQuantity)
        Me.dgvAdministorConsumables.Item(Me.colAdministorConsumablesRemainingQty.Name, selectedRow).Value = (quantity - issuedQty)
        Dim remainingbal As Integer = IntegerMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumablesRemainingQty)

        If (remainingbal <= 0) Then
            Throw New ArgumentException("This patient has received all Prescribed Quanity for this Consumable ." +
                                                   ControlChars.NewLine + "Please issue another Consumable")
            Me.dgvAdministorConsumables.Rows.RemoveAt(selectedRow)
            Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Value = Me._DrugNo
            Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Selected = True

        End If


    End Sub

    Private Sub DrugQuantityTaken(ByVal selectedRow As Integer)
        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim itemCode As String = SubstringRight(selectedItem)

            Dim roundNo As String = RevertText(StringEnteredIn(cboRoundNo))
            Dim items As DataTable = oIPDDrugAdministration.GetDrugAdministeredQuantity(roundNo, itemCode, oItemCategoryID.Drug).Tables("IPDDrugAdministration")
            Dim row As DataRow = items.Rows(0)
            With Me.dgvPrescription
                .Item(Me.ColGivenQty.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "TotalGivenAmount")
                Me.CalculateRemainingQty(selectedRow)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ConsumableQuantityTaken(ByVal selectedRow As Integer)
        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            If Me.dgvAdministorConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumables)

            Dim itemCode As String = SubstringRight(selectedItem)

            Dim roundNo As String = RevertText(StringEnteredIn(cboRoundNo))
            Dim items As DataTable = oIPDDrugAdministration.GetDrugAdministeredQuantity(roundNo, itemCode, oItemCategoryID.Consumable).Tables("IPDDrugAdministration")
            Dim row As DataRow = items.Rows(0)
            With Me.dgvAdministorConsumables
                .Item(Me.colAdministorConsumablesGivenQuantity.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "TotalGivenAmount")
                Me.CalculateConsumablesRemainingQty(selectedRow)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)
        Try
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug (" + _PrescriptionDrugValue + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrug)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Drug (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailDrug(selectedRow)
            Me.DrugQuantityTaken(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumablesEntries(ByVal selectedRow As Integer)
        Try
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumables)

            If CBool(Me.dgvAdministorConsumables.Item(Me.colAdministorConsumablesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Consumable (" + _PrescriptionConsumableValue + ") can't be edited!")
                Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Value = _PrescriptionConsumableValue
                Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvAdministorConsumables.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(rowNo).Cells, Me.colAdministorConsumables)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable (" + enteredItem + ") already selected!")
                        Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Value = _PrescriptionConsumableValue
                        Me.dgvAdministorConsumables.Item(Me.colAdministorConsumables.Name, selectedRow).Selected = True
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailConsumable(selectedRow)
            Me.ConsumableQuantityTaken(selectedRow)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailDrug(ByVal selectedRow As Integer)
        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim drugNo As String = SubstringRight(selectedItem)

            Dim roundNo As String = RevertText(StringEnteredIn(cboRoundNo))

            If String.IsNullOrEmpty(drugNo) Then Return
            Dim iPDDrugAdministration As DataTable = oIPDDrugAdministration.GetIPDDrugAdministrationPerRound(roundNo, oItemCategoryID.Drug, drugNo).Tables("IPDItems")
            If iPDDrugAdministration Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = iPDDrugAdministration.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colDrugQuantity.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Quantity")
                .Item(Me.colDuration.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Duration")
                .Item(Me.colDosage.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Dosage")
                .Item(Me.colNotes.Name, selectedRow).Value = StringMayBeEnteredIn(row, "ItemDetails")
                .Item(Me.colFromLocation.Name, selectedRow).Value = StringMayBeEnteredIn(row, "FromLocation")
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringMayBeEnteredIn(row, "UnitMeasure")
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailConsumable(ByVal selectedRow As Integer)
        Dim oIPDDrugAdministration As New SyncSoft.SQLDb.IPDDrugAdministration
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Try

            If Me.dgvAdministorConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvAdministorConsumables.Rows(selectedRow).Cells, Me.colAdministorConsumables)

            Dim consumableNo As String = SubstringRight(selectedItem)

            Dim roundNo As String = RevertText(StringEnteredIn(cboRoundNo))

            If String.IsNullOrEmpty(consumableNo) Then Return
            Dim iPDDrugAdministration As DataTable = oIPDDrugAdministration.GetIPDDrugAdministrationPerRound(roundNo, oItemCategoryID.Consumable, consumableNo).Tables("IPDItems")
            If iPDDrugAdministration Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = iPDDrugAdministration.Rows(0)

            With Me.dgvAdministorConsumables
                .Item(Me.colAdministorConsumablesQuantity.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Quantity")
                .Item(Me.colAdministorConsumablesNotes.Name, selectedRow).Value = StringMayBeEnteredIn(row, "ItemDetails")
                .Item(Me.colAdministorConsumablesUnitMeasure.Name, selectedRow).Value = StringMayBeEnteredIn(row, "UnitMeasure")
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub


#End Region

#Region "IPDNurseAssement"
    Private Sub LoadIPDNurseAssessment(ByVal roundNo As String)

        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
        Dim oIPDNurseAssessment As New SyncSoft.SQLDb.IPDNurseAssessment()

        Try

            ResetControlsIn(Me.tpgNurseAssessment)

            Dim iPDNurseAssessment As DataTable = oIPDNurseAssessment.GetIPDNurseAssessment(roundNo).Tables("IPDNurseAssessment")

            If iPDNurseAssessment Is Nothing Then Return

            For Each row As DataRow In iPDNurseAssessment.Rows


                Me.stbComplaint.Text = StringMayBeEnteredIn(row, "Complaint")
                Me.stbEtiology.Text = StringMayBeEnteredIn(row, "Etiology")
                Me.stbSignsAndSymptoms.Text = StringMayBeEnteredIn(row, "SignsAndSymptoms")
                Me.stbProposedSolution.Text = StringMayBeEnteredIn(row, "ProposedSolution")


            Next

            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            IPDNurseAssessmentSaved = True
            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            'Throw ex

        End Try

    End Sub

    Private Sub LoadIPDNursingPlan(ByVal nurseRoundNo As String)
        Dim oIPDNursingPlan As New SyncSoft.SQLDb.IPDNursingPlan()

        
        Try

            ResetControlsIn(Me.tpgPlanning)

            Dim iPDNursingPlan As DataTable = oIPDNursingPlan.GetIPDNursingPlan(nurseRoundNo).Tables("IPDNursingPlan")

            If iPDNursingPlan Is Nothing Then Return

            For Each row As DataRow In iPDNursingPlan.Rows

                Me.stbExpectedOutcome.Text = StringMayBeEnteredIn(row, "ExpectedOutcome")
                Me.stbNursingActions.Text = StringMayBeEnteredIn(row, "NursingActions")
                Me.stbImplementation.Text = StringMayBeEnteredIn(row, "Implementation")


            Next

            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            IPDNursingPlanSaved = True
            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ' Throw ex

        End Try

    End Sub

    Private Sub LoadIPDNurseEvaluation(ByVal nurseRoundNo As String)


        Dim oIPDNurseEvaluation As New SyncSoft.SQLDb.IPDNurseEvaluation()

        Try

            ResetControlsIn(Me.tpgEvaluation)

            Dim iPDNurseEvaluation As DataTable = oIPDNurseEvaluation.GetIPDNurseEvaluation(nurseRoundNo).Tables("IPDNurseEvaluation")

            If iPDNurseEvaluation Is Nothing Then Return

            For Each row As DataRow In iPDNurseEvaluation.Rows


                Me.cboNursingCareEffective.SelectedValue = StringMayBeEnteredIn(row, "NursingCareEffective")
                Me.stbProposedModifications.Text = StringMayBeEnteredIn(row, "ProposedModifications")
                Me.stbEvaluationNotes.Text = StringMayBeEnteredIn(row, "EvaluationNotes")



            Next

            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            IPDNurseEvaluationSaved = True
            '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            'Throw ex

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

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Diseases", "Disease Code", "Disease Name", Me.LoadDiseases(), "DiseaseFullName",
                                                                     "DiseaseCode", "DiseaseFullName", Me.dgvDiagnosis, Me.colICDDiagnosisCode, e.RowIndex)

            Me._DiagnosisCode = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(e.RowIndex).Cells, Me.colICDDiagnosisCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDiagnosis.Rows(e.RowIndex).IsNewRow Then

                Me.dgvDiagnosis.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDiagnosisEntries(e.RowIndex)
            ElseIf Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetDiagnosisEntries(e.RowIndex)

            End If
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

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colICDDiagnosisCode)

            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In diagnosis
                                                  Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                                  Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colICDDiagnosisCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                                        Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.ToUpper())
                                                        Select data.Field(Of String)("DiseaseName")).First()
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
            Me.DetailSelectedDiagnosis(selectedRow, RevertText(SubstringRight(selectedItem)))

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


    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
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


#Region "Allergies -Grid"

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Load from allergies
            allergies = oAllergies.GetAllergies().Tables("Allergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.colAllergyNo.Sorted = False
            'LoadComboData(Me.colAllergyNo, allergies, "AllergyNo", "AllergyName")
            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, " A Visit No, to Continue!"))
            Dim fPatientAllergies As New frmPatients(patientNo, True)
            fPatientAllergies.tbcPatients.SelectTab(fPatientAllergies.tpgPatientAllergies.Name)
            fPatientAllergies.Edit()
            fPatientAllergies.ShowDialog()




        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#Region "Fluids Balance Grid"

    Private Sub dgvFluidsBalance_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvFluidsBalance.CellBeginEdit

        If e.ColumnIndex <> Me.colFluidsMeasureFluidCategory.Index OrElse Me.dgvFluidsBalance.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    End Sub

    Private Sub dgvFluidsMeasure_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFluidsMeasure.CellClick
        Try
            Dim oFluidCategoryID As New LookupDataID.FluidCategoryID()

            Dim selectedRow As Integer = Me.dgvFluidsMeasure.CurrentCell.RowIndex
            If Me.chkCreateNewRound.Checked = True And e.ColumnIndex.Equals(Me.colFluidsMeasureFluidRoute.Index) And Not String.IsNullOrEmpty(StringMayBeEnteredIn(Me.dgvFluidsMeasure.Rows(selectedRow).Cells, Me.colFluidsMeasureFluidCategory)) Then

                Dim fluidcategoryID As String = StringMayBeEnteredIn(Me.dgvFluidsMeasure.Rows(selectedRow).Cells, Me.colFluidsMeasureFluidCategory)

                If fluidcategoryID.ToUpper().Equals(oFluidCategoryID.InTake) And Not String.IsNullOrEmpty(fluidcategoryID) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value = String.Empty
                    Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("InTake Route", "Route", "Route Full Name", Me.FluidInTakeRouteItems(), "DataDes",
                                                                 "DataDes", "ItemFullName", Me.dgvFluidsMeasure, Me.colFluidsMeasureFluidRoute, e.RowIndex)

                    fSelectItem.ShowDialog(Me)
                    Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataID(LookupObjects.FluidInTakeRouteID, (Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString).ToString
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If
                If fluidcategoryID.ToUpper().Equals(oFluidCategoryID.OutPut) And Not String.IsNullOrEmpty(fluidcategoryID) Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value = String.Empty
                    Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("OutPut Route", "Route", "Route Full Name", Me.FluidOutPutRouteItems(), "DataDes",
                                                                 "DataDes", "ItemFullName", Me.dgvFluidsMeasure, Me.colFluidsMeasureFluidRoute, e.RowIndex)

                    fSelectItem.ShowDialog(Me)
                    'Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataDes((Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString)
                    Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureRouteID.Name, selectedRow).Value = GetLookupDataID(LookupObjects.FluidOutPutRouteID, (Me.dgvFluidsMeasure.Item(Me.colFluidsMeasureFluidRoute.Name, selectedRow).Value).ToString).ToString '
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            End If


        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Function FluidInTakeRouteItems() As DataTable

        Dim Items As DataTable
        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

        Try
            Items = oIPDNurseFluids.GetFluidInTakeRouteItems().Tables("FluidInTakeRouteItems")
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return Items
            '''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Private Function FluidOutPutRouteItems() As DataTable

        Dim Items As DataTable
        Dim oIPDNurseFluids As New SyncSoft.SQLDb.IPDNurseFluids()

        Try
            Items = oIPDNurseFluids.GetFluidOutPutRouteItems().Tables("FluidOutPutRouteItems")
            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return Items
            '''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

#End Region

#Region " Security Method "

    Private Sub ApplySecurity()

        Try
            Me.btnSave.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()
            Me.fbnDelete.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()

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
        Dim oIPDNurse As New SyncSoft.SQLDb.IPDNurse()
        Dim oIPDNursingPlan As New SyncSoft.SQLDb.IPDNursingPlan()
        Dim oIPDNurseAssessment As New SyncSoft.SQLDb.IPDNurseAssessment()
        Dim oIPDNurseEvaluation As New SyncSoft.SQLDb.IPDNurseEvaluation()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim nurseRoundNo As String = RevertText(StringEnteredIn(Me.stbNurseRoundNo, "NurseRound No!"))
                Dim roundNo As String = RevertText(StringEnteredIn(Me.cboRoundNo, "Round No!"))
                Dim iPDNurse As DataTable = oIPDNurse.GetIPDNurseByRoundNoNavigate(roundNo).Tables("IPDNurse")
               

                For pos As Integer = 0 To iPDNurse.Rows.Count - 1
                    If nurseRoundNo.ToUpper().Equals(iPDNurse.Rows(pos).Item("NurseRoundNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next


                Me.navRounds.DataSource = iPDNurse
               
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
        'If Not Me.AllSaved() Then
        '    Me.chkNavigateRounds.Checked = Not Me.chkNavigateRounds.Checked
        '    Return
        'End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navRounds.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nurseRoundNo As String = RevertText(currentValue.ToString())
            If String.IsNullOrEmpty(nurseRoundNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbNurseRoundNo.Text = FormatText(nurseRoundNo, "IPDNurse", "nurseRoundNo")
            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.LoadRoundsData(roundNo)
            Me.LoadClinicalFindings(nurseRoundNo)
            Me.LoadIPDGivenDrugs(nurseRoundNo)
            Me.LoadIPDGivenConsumables(nurseRoundNo)
            Me.LoadIPDNurseFluids(nurseRoundNo)
            Me.LoadIPDNurseAssessment(nurseRoundNo)
            Me.LoadIPDNursingPlan(nurseRoundNo)
            Me.LoadIPDNurseEvaluation(nurseRoundNo)
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

                'Case Me.tpgLabResults.Name

                '    If Me.dgvLabResults.SelectedCells.Count < 1 Then Return
                '    Clipboard.SetText(CopyFromControl(Me.dgvLabResults))

                'Case Me.tpgRadiologyReports.Name

                '    If Me.dgvRadiologyReports.SelectedCells.Count < 1 Then Return
                '    Clipboard.SetText(CopyFromControl(Me.dgvRadiologyReports))

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

                'Case Me.tpgLabResults.Name
                '    Me.dgvLabResults.SelectAll()

                'Case Me.tpgRadiologyReports.Name
                '    Me.dgvRadiologyReports.SelectAll()

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
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colDiseaseCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnFindNurseRoundNo_Click(sender As Object, e As EventArgs) Handles btnFindNurseRoundNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbNurseRoundNo, AutoNumber.NurseRoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowRoundsHeaderData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub SetBMI()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBMI.Value = String.Empty
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim weight As Single = SingleMayBeEnteredIn(Me.nbxWeight)
            Dim height As Single = SingleMayBeEnteredIn(Me.nbxHeight) / 100

            Dim bmi As Single = CalculateBMI(weight, height)
            If bmi <= 0 Then Return

            Me.nbxBMI.Value = bmi.ToString("#.00")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub nbxWeight_Leave(sender As Object, e As EventArgs) Handles nbxWeight.Leave
        Me.SetBMI()
    End Sub

    Private Sub nbxHeight_Leave(sender As Object, e As EventArgs) Handles nbxHeight.Leave
        Me.SetBMI()
    End Sub

    Private Sub stbNurseRoundNo_TextChanged(sender As Object, e As EventArgs)
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
            If Not String.IsNullOrEmpty(Me.stbNurseRoundNo.Text) Then Me.ShowNurseRoundsHeaderData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnAddConsumables_Click(sender As Object, e As EventArgs) Handles btnAddConsumables.Click
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

    Private Sub btnNewVisionAssessment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewVisionAssessment.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            Dim fIPDVisionAssessment As New frmIPDVisionAssessment(admissionNo, False)
            fIPDVisionAssessment.ShowDialog()
            'fIPDVisionAssessment.Save()
            ' Me.ShowlatestIPDVisionAssessment(admissionNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnBillFormReturns_Click(sender As Object, e As EventArgs) Handles btnBillFormReturns.Click
        Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(RevertText(StringMayBeEnteredIn(Me.cboRoundNo)))
            'DisplayMessage(extraBillNo)
            If String.IsNullOrEmpty(extraBillNo) Then Return
            Dim fReturnedExtraBillItems As New frmBillAdjustments(extraBillNo, True)
            fReturnedExtraBillItems.ShowDialog()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub




    Private Sub cboRoundNo_TextChanged(sender As Object, e As EventArgs) Handles cboRoundNo.TextChanged
        ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.ClearControls()
        'ResetControlsIn(Me.pnlNavigateRounds)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.stbNurseRoundNo.Enabled = True
        'Me.dtpDoctorRoundDateTime.ResetText()
        'Me.stbNurseRoundNo.Clear()
    End Sub



    Private Sub cboNursingCareEffective_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNursingCareEffective.SelectedIndexChanged
        If Me.cboNursingCareEffective.SelectedIndex = 1 Then
            Me.stbProposedModifications.Enabled = True
        Else
            Me.stbProposedModifications.Enabled = False


        End If
    End Sub

    'Private Sub btnTemplateLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnTemplateLoad.Click
    '    Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
    '    If ((Me.btnLoadTemplate.Location.X - stbExpectedOutcome.Width = stbExpectedOutcome.Location.X) AndAlso
    '       (Me.btnLoadTemplate.Location.Y = stbExpectedOutcome.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ExpectedOutcome, Me.stbExpectedOutcome, True)
    '        fGetTemplates.ShowDialog(Me)
    '    ElseIf ((Me.btnLoadTemplate.Location.X - stbNursingActions.Width = stbNursingActions.Location.X) AndAlso
    '            (Me.btnLoadTemplate.Location.Y = stbNursingActions.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.NursingActions, Me.stbNursingActions, True)
    '        fGetTemplates.ShowDialog(Me)


    '    ElseIf ((Me.btnLoadTemplate.Location.X - stbImplementation.Width = stbImplementation.Location.X) AndAlso
    '     (Me.btnLoadTemplate.Location.Y = stbImplementation.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Implementation, Me.stbImplementation, True)
    '        fGetTemplates.ShowDialog(Me)


    '    End If


    'End Sub

    '#Region "IPDNurse Templates"

    '    Private Sub stbExpectedOutcome_Enter(sender As System.Object, e As System.EventArgs) Handles stbExpectedOutcome.Enter
    '        Me.PlaceTemplateButton(Me.stbExpectedOutcome)
    '    End Sub

    '    Private Sub stbNursingActions_Enter(sender As System.Object, e As System.EventArgs) Handles stbNursingActions.Enter
    '        Me.PlaceTemplateButton(Me.stbNursingActions)
    '    End Sub

    '    Private Sub stbImplementation_Enter(sender As System.Object, e As System.EventArgs) Handles stbImplementation.Enter
    '        Me.PlaceTemplateButton(Me.stbImplementation)
    '    End Sub



    '    'Private Sub tpgNurseAssessment_Leave(sender As System.Object, e As System.EventArgs) Handles tpgNurseAssessment.Leave
    '    '    Me.btnLoadTemplate.Visible = True
    '    'End Sub

    '    'Private Sub tpgPlanning_Leave(sender As System.Object, e As System.EventArgs) Handles tpgPlanning.Leave
    '    '    Me.btnLoadTemplate.Visible = True
    '    'End Sub

    '    'Private Sub PlaceTemplateButton(textControl As TextBox)
    '    '    Dim x As Integer = textControl.Location.X
    '    '    Dim y As Integer = textControl.Location.Y
    '    '    Dim width As Integer = textControl.Size.Width
    '    '    Me.btnLoadTemplate.Location = New System.Drawing.Point(x + width, y)
    '    '    Me.btnLoadTemplate.TabIndex = textControl.TabIndex - 1
    '    '    Me.btnLoadTemplate.BringToFront()
    '    '    Me.btnLoadTemplate.Visible = True
    '    'End Sub

    '#End Region

    
    'Private Sub btnLoadTemplate_Click(sender As System.Object, e As System.EventArgs)
    '    Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
    '    If ((Me.btnLoadTemplate.Location.X - stbComplaint.Width = stbComplaint.Location.X) AndAlso
    '            (Me.btnLoadTemplate.Location.Y = stbComplaint.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Complaint, Me.stbComplaint, True)
    '        fGetTemplates.ShowDialog(Me)


    '    ElseIf ((Me.btnLoadTemplate.Location.X - stbEtiology.Width = stbEtiology.Location.X) AndAlso
    '            (Me.btnLoadTemplate.Location.Y = stbEtiology.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.Etiology, Me.stbEtiology, True)
    '        fGetTemplates.ShowDialog(Me)

    '    ElseIf ((Me.btnLoadTemplate.Location.X - stbSignsAndSymptoms.Width = stbSignsAndSymptoms.Location.X) AndAlso
    '           (Me.btnLoadTemplate.Location.Y = stbSignsAndSymptoms.Location.Y)) Then
    '        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.SignsAndSymptoms, Me.stbSignsAndSymptoms, True)
    '        fGetTemplates.ShowDialog(Me)

    '    End If
    'End Sub


End Class