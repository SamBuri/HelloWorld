
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmVisionAssessment

#Region " Fields "
    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now

    Private defaultVisitNo As String = String.Empty
    Private defaultEyeTestID As String = String.Empty
    Private defaulteyeID As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False
#End Region

    Private Sub frmVisionAssessment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboEyeTestID, LookupObjects.EyeTest, False)
            LoadLookupDataCombo(Me.cboVisualAcuityRightID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboVisualAcuityRightExtID, LookupObjects.VisualAcuityExt, False)
            LoadLookupDataCombo(Me.cboVisualAcuityLeftID, LookupObjects.VisualAcuity, False)
            LoadLookupDataCombo(Me.cboVisualAcuityLeftExtID, LookupObjects.VisualAcuityExt, False)
            LoadLookupDataCombo(Me.cboPreferentialLookingRightID, LookupObjects.PreferentialLooking, True)
            LoadLookupDataCombo(Me.cboPreferentialLookingLeftID, LookupObjects.PreferentialLooking, True)


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = defaultVisitNo.ToUpper()
                Me.stbVisitNo.ReadOnly = True
                If Not String.IsNullOrEmpty(defaultEyeTestID) Then
                    Me.cboEyeTestID.SelectedValue = defaultEyeTestID
                    Me.cboEyeTestID.Enabled = False
                    Me.Search(defaultVisitNo, defaultEyeTestID)
                End If
                Me.ShowPatientDetails(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else
                Me.stbVisitNo.ReadOnly = False
                Me.cboEyeTestID.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmVisionAssessment_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowPendingVisitTriage()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub frmVisionAssessment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub cboEyeTestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEyeTestID.SelectedIndexChanged
        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
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

        Dim oVisits As New SyncSoft.SQLDb.Visits()

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

        Catch eX As Exception
            Throw eX

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

    Private Sub LoadSelectedDefaults()

        Try

            Dim oPreferentialLookingID As New LookupDataID.PreferentialLookingID()


         
            Me.cboPreferentialLookingRightID.SelectedValue = oPreferentialLookingID.NA
            Me.cboPreferentialLookingLeftID.SelectedValue = oPreferentialLookingID.NA


        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oVisionAssessment.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
            oVisionAssessment.EyeTestID = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")

            DisplayMessage(oVisionAssessment.Delete())
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

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
            Dim eyeTestID As String = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")
            Me.Search(visitNo, eyeTestID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub Search(ByVal visitNo As String, ByVal eyeTestID As String)

        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oVisionAssessment.GetVisionAssessment(visitNo, eyeTestID).Tables("VisionAssessment")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oVisionAssessment As New SyncSoft.SQLDb.VisionAssessment()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oVisionAssessment

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
                .EyeTestID = StringValueEnteredIn(Me.cboEyeTestID, "Eye Test!")
                .VisualAcuityRightID = StringValueEnteredIn(Me.cboVisualAcuityRightID, "Visual Acuity Right!")
                .VisualAcuityRightExtID = StringValueEnteredIn(Me.cboVisualAcuityRightExtID, "Visual Acuity Right Ext!")
                .VisualAcuityLeftID = StringValueEnteredIn(Me.cboVisualAcuityLeftID, "VisualAcuity Left!")
                .VisualAcuityLeftExtID = StringValueEnteredIn(Me.cboVisualAcuityLeftExtID, "Visual Acuity Left Ext!")
                .PreferentialLookingRightID = StringValueEnteredIn(Me.cboPreferentialLookingRightID, "Preferential Looking Right!")
                .PreferentialLookingLeftID = StringValueEnteredIn(Me.cboPreferentialLookingLeftID, "Preferential Looking Left!")
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .LoginID = CurrentUser.LoginID
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oVisionAssessment.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ShowPendingVisitTriage()
                    Me.chkHideSelfRequest.Checked = True
                    Me.LoadSelectedDefaults()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oVisionAssessment.Update())
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Alerts "

    Private Sub chkHideSelfRequest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkHideSelfRequest.CheckedChanged
        Me.ShowPendingVisitTriage()
    End Sub

    Private Function ShowPendingVisitTriage() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim pendingVisitTriage As DataTable = oVisits.GetPendingVisionAssessment(hideSelfRequest).Tables("Visits")
            Dim recordsNo As Integer = pendingVisitTriage.Rows.Count

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlertMessage.Text = "Visit(s) to Vision : " + recordsNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return recordsNo
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnPendingVisitTriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendingVisitTriage.Click

        Try

            Me.ShowPendingVisitTriage()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim fPendingVisitTriage As New frmPendingVisitFiles(Me.stbVisitNo, hideSelfRequest, PendingVisit.VisionAssessment)
            fPendingVisitTriage.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPendingVisitTriage()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then If Me.ShowPendingVisitTriage() > 0 Then If InitOptions.AlertSoundOn Then Beep()

        Catch eX As Exception
            Return

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
        Me.LoadSelectedDefaults()

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

End Class