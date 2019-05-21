
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmPendingVisitFiles

#Region " Fields "
    Private alertNoControl As Control
    Private _HideSelfRequest As Boolean
    Private _PendingVisit As PendingVisit
    Dim visitNo As String
    Dim patientNo As String
    Dim firstName As String
    Dim oServicePointID As New LookupDataID.ServicePointID
    Private servicePointID As String
    'Private _TriageObject As Boolean = False
#End Region
   
    Private Sub frmPendingVisitFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            If Me._PendingVisit = PendingVisit.Files Then
                Me.Text = "Pending visit files list"
                Me.colPriority.Visible = False
                Me.colPriority.DataPropertyName = Nothing
                Me.colFirstName.DataPropertyName = Nothing
                colFirstName.Visible = False
            ElseIf Me._PendingVisit = PendingVisit.Triage Then
                Me.Text = "Pending triage visit list"
                Me.colPriority.Visible = True
                Me.colPriority.DataPropertyName = "Priority"
                Me.colStatus.Visible = False
                Me.colStatus.DataPropertyName = Nothing
                Me.ColReturnedBy.Visible = False
                Me.ColReturnedBy.DataPropertyName = Nothing

            ElseIf Me._PendingVisit = PendingVisit.VisionAssessment Then
                Me.Text = "Pending Vision Assessment visit list"
                Me.colPriority.Visible = False
                Me.colPriority.DataPropertyName = Nothing
                Me.colStatus.Visible = False
                Me.colStatus.DataPropertyName = Nothing
                Me.ColReturnedBy.Visible = False
                Me.ColReturnedBy.DataPropertyName = Nothing
                Me.colFirstName.DataPropertyName = Nothing
                colFirstName.Visible = False
            Else : Me.Text = "Pending visit files list"
                Me.colPriority.Visible = False
                Me.colPriority.DataPropertyName = Nothing
                Me.colStatus.Visible = False
                Me.colStatus.DataPropertyName = Nothing
                Me.ColReturnedBy.Visible = False
                Me.ColReturnedBy.DataPropertyName = Nothing
                Me.colFirstName.DataPropertyName = Nothing
                colFirstName.Visible = False
            End If
            Me.ShowPendingVisitFiles()

            Me.CheckQueueStatus()
           
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub CheckQueueStatus()
        If IsQueueEnabled() = False Then
            Me.fbnCall.Visible = False

        Else
            Me.fbnCall.Visible = True

        End If
    End Sub


    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowPendingVisitFiles()

        Dim visits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oPriorityID As New LookupDataID.PriorityID()


        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits

            If Me._PendingVisit = PendingVisit.Files Then
                visits = oVisits.GetPendingVisitFiles(_HideSelfRequest).Tables("Visits")
            ElseIf Me._PendingVisit = PendingVisit.Triage Then
                visits = oVisits.GetPendingVisitTriage(_HideSelfRequest).Tables("Visits")
                ' visits = oVisits.GetEmergencyPendingVisitTriage(_HideSelfRequest).Tables("Visits")
            ElseIf Me._PendingVisit = PendingVisit.VisionAssessment Then
                visits = oVisits.GetPendingVisionAssessment(_HideSelfRequest).Tables("Visits")
            Else : visits = oVisits.GetPendingVisitFiles(_HideSelfRequest).Tables("Visits")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingVisitFiles, visits)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()
            Dim flagStatusStyle As New DataGridViewCellStyle()


            statusStyle.BackColor = Color.GreenYellow
            flagStatusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvPendingVisitFiles.Rows
                If row.IsNewRow Then Exit For
                Dim checkstatus As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colStatus)
                Dim Priority As String = StringMayBeEnteredIn(row.Cells, Me.colPriority)
                If checkstatus = False Then Me.dgvPendingVisitFiles.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
                If Me._PendingVisit = PendingVisit.Triage Then
                    If Priority = GetLookupDataDes(oPriorityID.Emergency) Then Me.dgvPendingVisitFiles.Rows(row.Index).DefaultCellStyle.ApplyStyle(flagStatusStyle)
                End If

                If Me._PendingVisit = PendingVisit.Files Then
                    If checkstatus = True Then Me.dgvPendingVisitFiles.Rows(row.Index).DefaultCellStyle.ApplyStyle(flagStatusStyle)
                End If
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Me.ShowPendingVisitFiles()
    End Sub

    Private Sub dgvPendingVisitFiles_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingVisitFiles.CellClick
        If e.RowIndex < 0 Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvPendingVisitFiles.Rows(e.RowIndex).Cells, Me.colVisitNo))
        Me.patientNo = StringMayBeEnteredIn(Me.dgvPendingVisitFiles.Rows(e.RowIndex).Cells, Me.colPatientNo)
        Me.firstName = StringMayBeEnteredIn(Me.dgvPendingVisitFiles.Rows(e.RowIndex).Cells, Me.colFirstName)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        fbnCall.Enabled = e.RowIndex >= 0
    End Sub

    Private Sub dgvPendingVisitFiles_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingVisitFiles.CellDoubleClick

        Try
            Dim oCurrentPatient As New CurrentPatient()

            oCurrentPatient.PatientNo = Me.dgvPendingVisitFiles.Item(Me.colPatientNo.Name, e.RowIndex).Value.ToString()
            oCurrentPatient.VisitNo = Me.dgvPendingVisitFiles.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = oCurrentPatient.VisitNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPendingVisitFiles.ColumnCount < 1 OrElse Me.dgvPendingVisitFiles.RowCount < 1 Then
            Me.cmsAlertListCopy.Enabled = False
            Me.cmsAlertListSelectAll.Enabled = False
        Else
            Me.cmsAlertListCopy.Enabled = True
            Me.cmsAlertListSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsAlertListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvPendingVisitFiles.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPendingVisitFiles))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPendingVisitFiles.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

  

    Private Sub fbnCall_Click(sender As System.Object, e As System.EventArgs) Handles fbnCall.Click
        Try

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim oServicePointID As New LookupDataID.ServicePointID
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            SaveQueuedMessage(visitNo, oServicePointID.Triage(), String.Empty, 0)

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try
    End Sub
End Class