
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.SQLDb.Lookup
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmVisitFiles

#Region " Fields "

    Private alertCheckPeriod As Integer
    Private alertsStartDateTime As Date = Now

#End Region

    Private Sub frmVisitFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oFileStatusID As New LookupDataID.FileStatusID()

            LoadLookupDataCombo(Me.cboFileStatusID, LookupObjects.FileStatus, True)
            Me.chkHideSelfRequest.Checked = True

            Me.cboFileStatusID.SelectedValue = oFileStatusID.Seen

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmVisitFiles_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowPendingVisitFiles()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub frmVisitFiles_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbReferenceNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbReferenceNo.Text = StringMayBeEnteredIn(row, "ReferenceNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkHideSelfRequest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHideSelfRequest.CheckedChanged
        Me.ShowPendingVisitFiles()
    End Sub

#Region " Alerts "

    Private Function ShowPendingVisitFiles() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim pendingVisitFiles As DataTable = oVisits.GetPendingVisitFiles(hideSelfRequest).Tables("Visits")
            Dim recordsNo As Integer = pendingVisitFiles.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlertMessage.Text = "Patient(s) expected to pick a file: " + recordsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

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

    Private Sub btnPendingVisitFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendingVisitFiles.Click

        Try

            Me.ShowPendingVisitFiles()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hideSelfRequest As Boolean = Me.chkHideSelfRequest.Checked
            Dim fPendingVisitFiles As New frmPendingVisitFiles(Me.stbVisitNo, hideSelfRequest, PendingVisit.Files)
            fPendingVisitFiles.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Focus()
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.ShowPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPendingVisitFiles()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= alertCheckPeriod Then If Me.ShowPendingVisitFiles() > 0 Then If InitOptions.AlertSoundOn Then Beep()

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim oVisitFiles As New SyncSoft.SQLDb.VisitFiles()
        Dim oFileStatusID As New LookupDataID.FileStatusID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oVisitFiles

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .FileStatusID = StringValueEnteredIn(Me.cboFileStatusID, "File Status!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "Are you sure file status is: " + StringMayBeEnteredIn(Me.cboFileStatusID) + "?"
            If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oVisitFiles.Save()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVisitFiles.FileStatusID.ToUpper().Equals(oFileStatusID.Seen.ToUpper()) Then
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
                Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                Dim fOutwardFiles As New frmOutwardFiles(patientNo, billCustomerName, visitNo)
                fOutwardFiles.ShowDialog()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPendingVisitFiles()
            Me.chkHideSelfRequest.Checked = True
            Me.cboFileStatusID.SelectedValue = oFileStatusID.Seen

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

End Class