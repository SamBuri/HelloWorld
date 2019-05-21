
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic

Public Class frmINTPara

#Region " Fields "
    Private oIntegrationAgent As New IntegrationAgents()
#End Region

    Dim defaultAdmissionNo As String

    Private Sub frmINTPara_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboGenderID, LookupObjects.Gender, False)
            LoadLookupDataCombo(Me.cboHIVStatus, LookupObjects.HIVStatus, False)
            LoadKeyValueCombos()

            If Not String.IsNullOrEmpty(defaultAdmissionNo) Then
                Me.stbAdmissionNo.Text = defaultAdmissionNo
                Me.ShowPatientDetails(RevertText(defaultAdmissionNo))

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadKeyValueCombos()
        Dim lmonths As New List(Of ComboValues)
        Dim lHospitalised As New List(Of ComboValues)
        Dim lEyeMovement As New List(Of ComboValues)
        Dim lBestMotorResponse As New List(Of ComboValues)
        Dim lBestVerbalResponse As New List(Of ComboValues)

        lmonths.Add(New ComboValues("January", 1))
        lmonths.Add(New ComboValues("Febuary", 2))
        lmonths.Add(New ComboValues("March", 3))
        lmonths.Add(New ComboValues("April", 4))
        lmonths.Add(New ComboValues("May", 5))
        lmonths.Add(New ComboValues("June", 6))
        lmonths.Add(New ComboValues("July", 7))
        lmonths.Add(New ComboValues("August", 8))
        lmonths.Add(New ComboValues("September", 9))
        lmonths.Add(New ComboValues("October", 10))
        lmonths.Add(New ComboValues("November", 11))
        lmonths.Add(New ComboValues("December", 12))

        lHospitalised.Add(New ComboValues("Less than 7 DAYS ago", 1))
        lHospitalised.Add(New ComboValues("7 to 30 DAYS ago", 2))
        lHospitalised.Add(New ComboValues("30 DAYS to 1 YEAR ago", 3))
        lHospitalised.Add(New ComboValues("more than 1 YEAR ago", 4))
        lHospitalised.Add(New ComboValues("Never", 5))

        lEyeMovement.Add(New ComboValues("Fails to watch or follow", 1))
        lEyeMovement.Add(New ComboValues("Watches or follows", 2))

        lBestMotorResponse.Add(New ComboValues("No response or inappropriate response", 1))
        lBestMotorResponse.Add(New ComboValues("Withdraws limb from painful stimulus", 2))
        lBestMotorResponse.Add(New ComboValues("Localizes painful stimulus)", 3))

        lBestVerbalResponse.Add(New ComboValues("No vocal response to pain", 1))
        lBestVerbalResponse.Add(New ComboValues("Moan or abnormal cry with pain", 2))
        lBestVerbalResponse.Add(New ComboValues("Cries appropriately with pain (or speaks if verbal)", 3))


        ''''''''''''''' Load Combos
        With cboBirthMonth
            .DataSource = lmonths
            .DisplayMember = "displayMember"
            .ValueMember = "valueMember"
        End With

        With cbolastHospitalized
            .DataSource = lHospitalised
            .DisplayMember = "displayMember"
            .ValueMember = "valueMember"

        End With

        With cboEyeMovement
            .DataSource = lEyeMovement
            .DisplayMember = "displayMember"
            .ValueMember = "valueMember"

        End With

        With cboBestMotorResponse
            .DataSource = lBestMotorResponse
            .DisplayMember = "displayMember"
            .ValueMember = "valueMember"

        End With

        With cboBestVerbalResponse
            .DataSource = lBestVerbalResponse
            .DisplayMember = "displayMember"
            .ValueMember = "valueMember"

        End With
        
    End Sub


    Private Sub frmINTPara_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oINTPara As New SyncSoft.SQLDb.INTPara()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oINTPara.AgentNo = oIntegrationAgent.PARA()
            oINTPara.AdmissionNo = StringEnteredIn(Me.stbAdmissionNo, "Admission No!")

            DisplayMessage(oINTPara.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim agentNo As String
        Dim admissionNo As String

        Dim oINTPara As New SyncSoft.SQLDb.INTPara()

        Try
            Me.Cursor = Cursors.WaitCursor()

            agentNo = oIntegrationAgent.PARA()
            admissionNo = StringEnteredIn(Me.stbAdmissionNo, "Admission No!")

            Dim dataSource As DataTable = oINTPara.GetINTPara(agentNo, admissionNo).Tables("INTPara")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oINTPara As New SyncSoft.SQLDb.INTPara()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oINTPara

                .AgentNo = oIntegrationAgent.PARA()
                .AdmissionNo = StringEnteredIn(Me.stbAdmissionNo, "Admission No!")
                .StudyID = StringEnteredIn(Me.stbStudyID, "Study ID!")
                .AssessmentSite = StringEnteredIn(Me.stbAssessmentSite, "Assessment Site!")
                .AssessmentDate = DateEnteredIn(Me.dtpAssessmentDate, "Assessment Date!")
                .GenderID = StringValueEnteredIn(Me.cboGenderID, "Gender!")
                .BirthYear = Me.nbxBirthYear.GetInteger()
                .BirthMonth = StringEnteredIn(Me.cboBirthMonth, "Birth Month!")
                .EstimatedYears = Me.nbxEstimatedYears.GetInteger()
                .LastHospitalized = StringEnteredIn(Me.cbolastHospitalized, "Last Hospitalized!")
                .Weight = Me.nbxWeight.GetSingle()
                .MUAC = Me.nbxMUAC.GetSingle()
                .CalculatedZScoreAgeWeight = Me.nbxCalculatedZScoreAgeWeight.GetSingle()
                .TabletOxygenSaturation = StringEnteredIn(Me.stbTabletOxygenSaturation, "Tablet oOxygen Saturation!")
                .TabletHeartRate = Me.nbxTabletHeartRate.GetSingle()
                .SQI = Me.nbxSQI.GetInteger()
                .SpO2Time = DateEnteredIn(Me.dtpSpO2Time, "SpO2 Time!")
                .SpO2TrendFile = StringEnteredIn(Me.stbSpO2TrendFile, "SpO2 Trend File!")
                .SP02RedFile = StringEnteredIn(Me.stbSP02RedFile, "SpO2 Red File!")
                .Sp02InfraredFile = StringEnteredIn(Me.stbSp02InfraredFile, "SpO2 Infrared File!")
                .AnotherDeviceSOP2 = StringEnteredIn(Me.stbAnotherDeviceSOP2, "SpO2 from Another Device!")
                .EyeMovement = StringEnteredIn(Me.cboEyeMovement, "Eye Movement (Blantyre Coma Scale)!")
                .BestMotorResponse = StringEnteredIn(Me.cboBestMotorResponse, "Best Motor Response (Blantyre Coma Scale)!")
                .BestVerbalResponse = StringEnteredIn(Me.cboBestVerbalResponse, "Best Verbal Response (Blantyre Coma Scale)!")
                .HIVStatus = StringValueEnteredIn(Me.cboHIVStatus, "HIV Status!")
                .PostDischargeMortalityRisk = Me.nbxPostDischargeMortalityRisk.GetInteger()
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oINTPara.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oINTPara.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)
        Me.stbAssessmentSite.Text = AppData.ProductOwner
    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub btnLoadAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadAdmissions.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fInWardAdmissions.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.ShowPatientDetails(admissionNo)
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

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.nbxEstimatedYears.Text = StringEnteredIn(row, "Age")
            Me.nbxMUAC.Value = FormatNumber(DecimalMayBeEnteredIn(row, "MUAC", False), AppData.DecimalPlaces)
            Me.nbxWeight.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Weight", False), AppData.DecimalPlaces)
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            dtpBirthDate.Value = birthDate
            Me.cboGenderID.SelectedValue = StringEnteredIn(row, "GenderID")
            nbxBirthYear.Text = birthDate.Year.ToString()
            cboBirthMonth.SelectedValue = birthDate.Month
            Me.stbAssessmentSite.Text = AppData.ProductOwner
        Catch eX As Exception
            Me.ClearControls()
            Throw eX

        End Try

    End Sub

    Private Sub ClearControls()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()

        Me.cboGenderID.SelectedIndex = -1
        Me.nbxEstimatedYears.Clear()

        'billModesID = String.Empty
        'associatedBillNo = String.Empty


    End Sub
    Class ComboValues
        Public Property displayMember As String
        Public Property valueMember As Object

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal displayMember As String, ByVal valueMember As Object)
            MyClass.New()
            Me.displayMember = displayMember
            Me.valueMember = valueMember
        End Sub

    End Class

End Class