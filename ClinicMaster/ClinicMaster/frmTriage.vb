
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.SQLDb

Public Class frmTriage

#Region " Fields "
    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now

    Private defaultVisitNo As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False
    Private billModesID As String
    Private oVariousOptions As New VariousOptions()
    Private oCurrentVisit As CurrentVisit
#End Region

    Private Sub frmTriage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboTriagePriority, LookupObjects.Priority, True)
            LoadLookupDataCombo(Me.cboBMIStatusID, LookupObjects.BMIStatus, True)
            LoadLookupDataCombo(Me.cboMUACStatusID, LookupObjects.MUACStatus, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Me.Cursor = Cursors.WaitCursor

            Me.chkHideSelfRequest.Checked = True

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.ShowPatientDetails(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else : Me.stbVisitNo.ReadOnly = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub SetBMIStatus(bmi As Single)

        Dim oBMIStatusID As New LookupDataID.BMIStatusID()

        Try

            Select Case bmi

                Case Is <= 0 : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.NA
                Case Is < 18.5 : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.UnderWeight
                Case 18.5 To 24.9 : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.NormalWeight
                Case 25 To 29.9 : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.OverWeight
                Case Is >= 30 : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.Obesity
                Case Else : Me.cboBMIStatusID.SelectedValue = oBMIStatusID.NA

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetMUACStatus(_MUAC As Single, ByVal Age As Integer)

        Dim oMUACStatusID As New LookupDataID.MUACStatusID()

        Try

            Select Case Age
                Case Is < 5
                    If _MUAC <= 0 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
                    ElseIf _MUAC <= 11.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Red
                    ElseIf _MUAC <= 12.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Yellow
                    ElseIf _MUAC > 12.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Green
                    End If

                Case 5 To 9, Is < 10

                    If _MUAC <= 0 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
                    ElseIf _MUAC <= 13.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Red
                    ElseIf _MUAC <= 14.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Yellow
                    ElseIf _MUAC > 14.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Green
                    End If

                Case 10 To 14, Is < 15, Is > 60

                    If _MUAC <= 0 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
                    ElseIf _MUAC <= 16 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Red
                    ElseIf _MUAC <= 18.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Yellow
                    ElseIf _MUAC > 18.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Green
                    End If

                Case 15 To 17, Is < 18

                    If _MUAC <= 0 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
                    ElseIf _MUAC <= 18.5 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Red
                    ElseIf _MUAC <= 21 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Yellow
                    ElseIf _MUAC > 21 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Green
                    End If

                Case Is >= 18, Is < 60
                    If _MUAC <= 0 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
                    ElseIf _MUAC <= 19 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Red
                    ElseIf _MUAC <= 22 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Yellow
                    ElseIf _MUAC > 22 Then
                        Me.cboMUACStatusID.SelectedValue = oMUACStatusID.Green
                    End If
            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub frmTriage_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowPendingVisitTriage()
        Me.EmergencyVisitAlert()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub nbxWeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbxWeight.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub nbxHeight_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nbxHeight.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return

        Me.ShowPatientDetails(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.spbPhoto.Image = Nothing
        Me.stbVisitDate.Clear()
        Me.stbJoinDate.Clear()

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged

        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits

        Try

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Me.ClearControls()

            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.cboTriagePriority.Text = GetLookupDataDes(StringEnteredIn(row, "VisitsPriorityID"))
            Me.billModesID = StringEnteredIn(row, "BillModesID")
            Me.stbDoctorSpecialty.Text = StringMayBeEnteredIn(row, "DoctorSpecialty")
            Me.stbTToSeeDoctor.Text = StringMayBeEnteredIn(row, "ToSeeDoctor")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub nbxWeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxWeight.Leave
        Me.SetBMI()
    End Sub

    Private Sub nbxHeight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxHeight.Leave
        Me.SetBMI()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oTriage As New SyncSoft.SQLDb.Triage()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oTriage.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oTriage.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Me.Search(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Public Sub Search(ByVal visitNo As String)

        Dim oTriage As New SyncSoft.SQLDb.Triage()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oTriage.GetTriage(visitNo).Tables("Triage")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oTriage As New SyncSoft.SQLDb.Triage()
        Dim oPriorityID As New LookupDataID.PriorityID
        Dim oMUACStatusID As New LookupDataID.MUACStatusID()
        Dim oBMIStatusID As New LookupDataID.BMIStatusID()

        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
        Dim priorityID As String = StringValueEnteredIn(Me.cboTriagePriority, "TriagePriorityID!")

        Try
            Me.Cursor = Cursors.WaitCursor()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ErrProvider.SetError(Me.btnPendingVisitTriage, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oTriage

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .Weight = SingleMayBeEnteredIn(Me.nbxWeight, -1)
                .Temperature = SingleMayBeEnteredIn(Me.nbxTemperature, -1)
                .Height = SingleMayBeEnteredIn(Me.nbxHeight, -1)
                .Pulse = ShortMayBeEnteredIn(Me.nbxPulse, 0)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim bloodPressure As String = StringMayBeEnteredIn(Me.stbBloodPressure)
                IsBloodPressureValid(bloodPressure)
                .BloodPressure = bloodPressure
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .HeadCircum = SingleMayBeEnteredIn(Me.nbxHeadCircum, -1)
                .BodySurfaceArea = SingleMayBeEnteredIn(Me.nbxBodySurfaceArea, -1)
                .RespirationRate = ShortMayBeEnteredIn(Me.nbxRespirationRate, 0)
                .OxygenSaturation = SingleMayBeEnteredIn(Me.nbxOxygenSaturation, -1)
                .HeartRate = ShortMayBeEnteredIn(Me.nbxHeartRate, 0)
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .TriagePriorityID = StringValueEnteredIn(Me.cboTriagePriority, "TriagePriorityID!")
                .MUAC = SingleMayBeEnteredIn(Me.nbxMUAC, -1)

                If Me.nbxBMI.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.nbxBMI.Text) Then
                    .BMIStatusID = StringValueEnteredIn(Me.cboBMIStatusID, "BMI Status!")
                Else : .BMIStatusID = oBMIStatusID.NA
                End If

                If Me.nbxMUAC.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.nbxMUAC.Text) Then
                    .MUACStatusID = StringValueEnteredIn(Me.cboMUACStatusID, "MUAC Status!")
                Else : .MUACStatusID = oMUACStatusID.NA
                End If

                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If .Weight < 0 AndAlso .Temperature < 0 AndAlso .Height < 0 AndAlso
                    .Pulse <= 0 AndAlso String.IsNullOrEmpty(.BloodPressure) AndAlso
                    .HeadCircum < 0 AndAlso .BodySurfaceArea < 0 AndAlso .RespirationRate <= 0 AndAlso
                    .OxygenSaturation < 0 AndAlso .HeartRate <= 0 AndAlso String.IsNullOrEmpty(.Notes) Then _
                 Throw New ArgumentException("Must enter at least One Item for Triage!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oServicePoint As New ServicePointID()
            Dim oBillModesID As New BillModesID()
            Dim lservicePoints As New List(Of String)
            lservicePoints.Add(oServicePoint.Doctor())
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            If Me.billModesID.ToUpper.Equals(oBillModesID.Cash().ToUpper()) Then
                lservicePoints.Add(oServicePoint.Cashier())
            End If

            Dim lQueues As New List(Of DBConnect)
            lservicePoints.Add(oServicePoint.Triage)
            lQueues = GetQueuesList(visitNo, oServicePoint.Triage(), oTriage.TriagePriorityID, lservicePoints)
            transactions.Add(New TransactionList(Of DBConnect)(lQueues, Action.Save))
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Dim oVariousOptions As New VariousOptions()


                    If oVariousOptions.ForceTBAssessmentAtTriage Then
                        Dim fLoadTBAssessment As New frmTBIntensifiedCaseFinding(visitNo)
                        fLoadTBAssessment.ShowDialog()
                    End If

                    oTriage.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)

                    Me.cboTriagePriority.SelectedValue = oPriorityID.Normal
                    Me.ShowPendingVisitTriage()
                    Me.chkHideSelfRequest.Checked = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oTriage.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

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
            Me.SetBMIStatus(bmi)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub chkHideSelfRequest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHideSelfRequest.CheckedChanged
        Me.ShowPendingVisitTriage()
        Me.EmergencyVisitAlert()
    End Sub

#Region " Alerts "

    Private Function ShowPendingVisitTriage() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim pendingVisitTriage As DataTable = oVisits.GetPendingVisitTriage(hideSelfRequest).Tables("Visits")
            Dim recordsNo As Integer = pendingVisitTriage.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlertMessage.Text = "Visit(s) to Triage: " + recordsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return recordsNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnPendingVisitTriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendingVisitTriage.Click

        Try

            ' Me.ShowPendingVisitTriage()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim fPendingVisitTriage As New frmPendingVisitFiles(Me.stbVisitNo, hideSelfRequest, PendingVisit.Triage)
            fPendingVisitTriage.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPendingVisitTriage()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then
                Me.EmergencyVisitAlert()
                If Me.ShowPendingVisitTriage() > 0 Then If InitOptions.AlertSoundOn Then Beep()


            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

    Private Sub EmergencyVisitAlert()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVisits As New SyncSoft.SQLDb.Visits()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim EmergencyPendingVisitTriage As DataTable = oVisits.GetEmergencyPendingVisitTriage(hideSelfRequest).Tables("Visits")
            Dim recordsNo As Integer = EmergencyPendingVisitTriage.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If recordsNo > 0 Then
                Dim errorMSG As String = recordsNo.ToString() + " Emergency Visit(s) Need to be Attended Immediately!!! "
                ErrProvider.Clear()
                ErrProvider.SetError(Me.btnPendingVisitTriage, errorMSG)
                Me.btnPendingVisitTriage.Focus()
            Else
                ErrProvider.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.btnPendingVisitTriage.Enabled = False
        Me.chkHideSelfRequest.Enabled = False

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.btnPendingVisitTriage.Enabled = True
        Me.chkHideSelfRequest.Enabled = True

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

    Private Sub nbxMUAC_Leave(sender As System.Object, e As System.EventArgs) Handles nbxMUAC.Leave
        Try

            Dim oMUACStatusID As New LookupDataID.MUACStatusID()

            Dim _MUAC As Single = SingleMayBeEnteredIn(Me.nbxMUAC)
            Dim age As Integer = IntegerMayBeEnteredIn(Me.stbAge)
            Me.cboMUACStatusID.SelectedValue = oMUACStatusID.NA
            Me.SetMUACStatus(_MUAC, age)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub EditBtnTB_Click(sender As System.Object, e As System.EventArgs) Handles EditBtnTB.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fTBIntensifiedCaseFinding As New frmTBIntensifiedCaseFinding(visitNo)

            fTBIntensifiedCaseFinding.Save()
            fTBIntensifiedCaseFinding.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub EditPatients_Click(sender As System.Object, e As System.EventArgs) Handles EditPatients.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            If Not oVariousOptions.EnableSecondPatientForm Then
                Dim fPatients As New frmPatients(patientNo, True)
                fPatients.tbcPatients.SelectTab(fPatients.tpgPatientAllergies.Name)
                fPatients.Edit()
                fPatients.ShowDialog()
            Else
                Dim f2Patients As New frmPatientsTwo(patientNo, True)
                f2Patients.tbcPatients.SelectTab(f2Patients.tpgPatientAllergies.Name)
                f2Patients.Edit()
                f2Patients.ShowDialog()
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

  
End Class