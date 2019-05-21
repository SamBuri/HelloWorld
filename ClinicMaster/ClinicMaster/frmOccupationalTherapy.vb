
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmOccupationalTherapy

#Region " Fields "
    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private OTInterventionSaved As Boolean = True
    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty
#End Region

    Private Sub frmOccupationalTherapy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboWalkingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboSitStandTransfersID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboBathingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboToiletingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboDressingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboHandFunctionID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboWashingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboFeedingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboGroomingID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboMealPreparationID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboWorkPlaySchoolID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboLeisureID, LookupObjects.LevelOfDependence, False)
            LoadLookupDataCombo(Me.cboCommunicationID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboCognitionID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboAttentionID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboImpulseControlID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboSleepID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboMemoryID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboPerceptionID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboThoughtID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboSightID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboTasteID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboHearingID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboTouchID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboSmellID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboPainID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboVestibularID, LookupObjects.AdhereStatus, False)
            LoadLookupDataCombo(Me.cboTemperatureAndPressureID, LookupObjects.AdhereStatus, False)

            LoadLookupDataCombo(Me.cboInterventionType, LookupObjects.InterventionType, False)

            Me.LoadStaff()
            Me.ShowSentAlerts()

            'Me.ClearControls()
            'Me.ResetControls()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmOccupationalTherapy_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oOccupationalTherapy As New SyncSoft.SQLDb.OccupationalTherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return


            DisplayMessage(oOccupationalTherapy.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        Dim oOccupationalTherapy As New SyncSoft.SQLDb.OccupationalTherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim VisitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Dim dataSource As DataTable = oOccupationalTherapy.GetOccupationalTherapy(VisitNo).Tables("OccupationalTherapy")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub ebnSave_Click(sender As System.Object, e As System.EventArgs) Handles ebnSave.Click
        Dim oOccupationalTherapy As New SyncSoft.SQLDb.OccupationalTherapy()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oOccupationalTherapy

                .VisitNo = RevertText(StringEnteredIn(stbVisitNo, "Visit's No!"))
                .WalkingID = StringValueEnteredIn(Me.cboWalkingID, "Walking!")
                .SitStandTransfersID = StringValueEnteredIn(Me.cboSitStandTransfersID, "Sit Stand Transfers!")
                .BathingID = StringValueEnteredIn(Me.cboBathingID, "Bathing!")
                .ToiletingID = StringValueEnteredIn(Me.cboToiletingID, "Toileting!")
                .DressingID = StringValueEnteredIn(Me.cboDressingID, "Dressing!")
                .HandFunctionID = StringValueEnteredIn(Me.cboHandFunctionID, "Hand Function!")
                .WashingID = StringValueEnteredIn(Me.cboWashingID, "Washing!")
                .FeedingID = StringValueEnteredIn(Me.cboFeedingID, "Feeding!")
                .GroomingID = StringValueEnteredIn(Me.cboGroomingID, "Grooming!")
                .MealPreparationID = StringValueEnteredIn(Me.cboMealPreparationID, "Meal Preparation!")
                .WorkPlaySchoolID = StringValueEnteredIn(Me.cboWorkPlaySchoolID, "Work Play School!")
                .LeisureID = StringValueEnteredIn(Me.cboLeisureID, "Leisure!")
                .CommunicationID = StringValueEnteredIn(Me.cboCommunicationID, "Communication!")
                .CognitionID = StringValueEnteredIn(Me.cboCognitionID, "Cognition!")
                .AttentionID = StringValueEnteredIn(Me.cboAttentionID, "Attention!")
                .ImpulseControlID = StringValueEnteredIn(Me.cboImpulseControlID, "Impulse Control!")
                .SleepID = StringValueEnteredIn(Me.cboSleepID, "Sleep!")
                .MemoryID = StringValueEnteredIn(Me.cboMemoryID, "Memory!")
                .PerceptionID = StringValueEnteredIn(Me.cboPerceptionID, "Perception!")
                .ThoughtID = StringValueEnteredIn(Me.cboThoughtID, "Thought!")
                .SightID = StringValueEnteredIn(Me.cboSightID, "Sight!")
                .TasteID = StringValueEnteredIn(Me.cboTasteID, "Taste!")
                .HearingID = StringValueEnteredIn(Me.cboHearingID, "Hearing!")
                .TouchID = StringValueEnteredIn(Me.cboTouchID, "Touch!")
                .SmellID = StringValueEnteredIn(Me.cboSmellID, "Smell!")
                .PainID = StringValueEnteredIn(Me.cboPainID, "Pain!")
                .VestibularID = StringValueEnteredIn(Me.cboVestibularID, "Vestibular!")
                .TemperatureAndPressureID = StringValueEnteredIn(Me.cboTemperatureAndPressureID, "Temperature And Pressure!")
                .LoginID = CurrentUser.LoginID


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oOccupationalTherapy.Save()

                    DisplayMessage(" OT Evaluation Successfully Saved!")

                    Me.SaveOTIntervention()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ResetControls()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oOccupationalTherapy.Update())
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



    Private Sub btnLoadOTVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadOTVisits.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSeeDoctorVisits As New frmSeeDoctorVisits(Me.stbVisitNo)
            fSeeDoctorVisits.ShowDialog(Me)

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    'Private Sub ClearControls()


    '    Me.stbVisitDate.Clear()
    '    Me.stbPatientNo.Clear()
    '    Me.stbFullName.Clear()
    '    Me.stbNotes.Clear()
    '    Me.stbPhone.Clear()
    '    Me.nbxAge.Clear()
    '    Me.stbVisitNo.Clear()
    '    Me.stbLastVisitDate.Clear()
    '    Me.stbLocation.Clear()
    '    Me.spbPhoto.Image = Nothing


    'End Sub

    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgOTEvaluation)
        ResetControlsIn(Me.tpgIntervention)
        ResetControlsIn(Me.grpADL)
        ResetControlsIn(Me.grpMentalFunctions)
        ResetControlsIn(Me.grpSensoryFunctions)
        ResetControlsIn(Me.grpOTInterventionActivities)

        '''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''

    End Sub

#Region "LOAD OPTIONS"
    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.ClearControls()
            'Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.ClearControls()
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub LoadVisitsData(ByVal visitNo As String)
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''
            'ResetControlsIn(Me.tpgIntervention)

            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)



            '''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()
        Dim oAccessCashServices As New SyncSoft.SQLDb.AccessedCashServices()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim debitBalanceErrorMSG As String = "This Patient has a debt!! Debit balance should be cleared first!"
        Try
            Me.Cursor = Cursors.WaitCursor


            'Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            'Dim row As DataRow = patients.Rows(0)
            'Dim lastVisitDate As Date = DateEnteredIn(row, "lastVisitDate")
            Dim UserBranchID As String = GetStaffCurrentBranch(CurrentUser.LoginID)
            Dim Visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = Visits.Rows(0)

            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(row, "LastVisitDate"))
            Me.nbxAge.Text = StringEnteredIn(row, "Age")
            'Me.stbLocation.Text = StringEnteredIn(row, "AddressDistrict")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim pt As EnumerableRowCollection(Of DataRow) = patients.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    'Private Sub SetNextOccupationalTherapyNo()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Dim oVariousOptions As New VariousOptions()
    '        Dim oClient As New SyncSoft.SQLDb.OccupationalTherapy()
    '        Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

    '        Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("OccupationalTherapy", "OccupationalTherapyNo").Tables("AutoNumbers")
    '        Dim row As DataRow = autoNumbers.Rows(0)

    '        Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
    '        Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

    '        Dim occupationalTherapyNoPrefix As String = oVariousOptions.StaffNoPrefix
    '        Dim nextOccupationalTherapyNo As String = CStr(oClient.GetNextOccupationalTherapyID).PadLeft(paddingLEN, paddingCHAR)
    '        Me.stbTherapyNo.Text = FormatText((occupationalTherapyNoPrefix + nextOccupationalTherapyNo).Trim(), "OccupationalTherapy", "OccupationalTherapyNo")

    '    Catch eX As Exception
    '        ErrorMessage(eX)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub
#End Region

#Region "SAVE OPTIONS"
    Private Sub SaveOTIntervention()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lOTIntervention As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Try

                    Using oOTIntervention As New SyncSoft.SQLDb.OTIntervention()

                        With oOTIntervention
                        .VisitNo = visitNo
                        .LeadTherapist = SubstringEnteredIn(Me.cboLeadTherapist, "Lead Therapist!")
                        .InterventionTypeID = StringValueEnteredIn(Me.cboInterventionType, "Intervention Type")
                        .CognitiveAssessment = Me.chkCognitiveAssessment.Checked
                        .HandTherapy = Me.chkHandTherapy.Checked
                        .HealthEducation = Me.chkHealthEducation.Checked
                        .TherapeuticGroupActivities = Me.chkTherapeuticGroupActivities.Checked
                        .HomebasedRehabilitation = Me.chkHomebasedRehabilitation.Checked
                        .AssistiveDevices = Me.chkAssistiveDevices.Checked
                        .MobilitySkillsTraining = Me.chkMobilitySkillsTraining.Checked
                        .NeurocognitiveRehabilitation = Me.chkNeurocognitiveRehabilitation.Checked
                        .OrientationTechniques = Me.chkOrientationTechniques.Checked
                        .VocationalRehabilitation = Me.chkVocationalRehabilitation.Checked
                        .SelfCareTraining = Me.chkSelfCareTraining.Checked
                        .PlayTherapy = Me.chkPlayTherapy.Checked
                        .StressManagement = Me.chkStressManagement.Checked
                        .OtherAssessment = StringEnteredIn(Me.stbOtherAssessment, "Other Assessment!")
                        .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                        .LoginID = CurrentUser.LoginID


                        End With

                    lOTIntervention.Add(oOTIntervention)
                    oOTIntervention.Save()

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lOTIntervention, Action.Save))


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                OTInterventionSaved = True

                    DisplayMessage("OT Intervention Successfully Saved!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#End Region

#Region "LOAD OPTIONS"
    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Therapist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadTherapist, staff, "StaffFullName")
            LoadComboData(Me.cboLeadTherapist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
#End Region


    Private Sub btnFindVisitNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub



    Private Sub btnViewList_Click(sender As System.Object, e As System.EventArgs) Handles btnViewList.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.OccupationalTherapy, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

#Region " Alerts "

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim UserBranchID As String = GetStaffCurrentBranch(CurrentUser.LoginID)


            alerts = oAlerts.GetAlerts(oAlertTypeID.OccupationalTherapy, UserBranchID).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Forwarded to OT: " + alertsNo.ToString()

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




    Private Sub DeleteAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If alerts Is Nothing OrElse alerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = alerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts _
                                        Where data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) _
                                        And GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) _
                                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= InitOptions.AlertCheckPeriod Then
                If Me.ShowSentAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region


    Private Sub stbVisitNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.TextChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.ClearControls()
        Me.ResetControls()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbVisitNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlAlerts)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.Enter
        Try
            'currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try
    End Sub

    Private Sub stbVisitNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

End Class