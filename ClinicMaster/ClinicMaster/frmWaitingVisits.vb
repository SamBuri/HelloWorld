
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmWaitingVisits

#Region " Fields "
    Private alertNoControl As Control
    Public IsEmergency As Boolean
#End Region
    Dim visitNo As String
    Dim patientNo As String
    Dim firstName As String

    Private Sub frmWaitingVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
        Select Case IsEmergency
            Case True

                Me.Text = "Emergency Visit's list waiting to see you"
                Me.ShowEmergencyWaitingVisits()

            Case False
                    Me.Text = "Visit's list waiting to see you"
                    Me.ShowWaitingVisits()
            End Select

            CheckQueueStatus()

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

    Private Sub ShowWaitingVisits()

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oPriorityID As New LookupDataID.PriorityID

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim visits As DataTable = oVisits.GetWaitingVisits(CurrentUser.LoginID).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvWaitingPatients, visits)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowEmergencyWaitingVisits()

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oPriorityID As New LookupDataID.PriorityID

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim visits As DataTable = oVisits.GetEmergencyWaitingVisits(Nothing).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvWaitingPatients, visits)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvWaitingPatients.Rows
                If row.IsNewRow Then Exit For
                Dim Priority As String = StringMayBeEnteredIn(row.Cells, Me.colPriority)
                If Priority = GetLookupDataDes(oPriorityID.Emergency) Then Me.dgvWaitingPatients.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvWaitingPatients_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWaitingPatients.CellClick
        If e.RowIndex < 0 Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvWaitingPatients.Rows(e.RowIndex).Cells, Me.colVisitNo))
        Me.patientNo = StringMayBeEnteredIn(Me.dgvWaitingPatients.Rows(e.RowIndex).Cells, Me.colPatientNo)
        Me.firstName = StringMayBeEnteredIn(Me.dgvWaitingPatients.Rows(e.RowIndex).Cells, Me.colFirstName)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        fbnCall.Enabled = e.RowIndex >= 0
    End Sub


    Private Sub dgvWaitingPatients_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWaitingPatients.CellDoubleClick

        Try
            Dim oCurrentPatient As New CurrentPatient()

            oCurrentPatient.PatientNo = Me.dgvWaitingPatients.Item(Me.colPatientNo.Name, e.RowIndex).Value.ToString()
            oCurrentPatient.VisitNo = Me.dgvWaitingPatients.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvWaitingPatients.ColumnCount < 1 OrElse Me.dgvWaitingPatients.RowCount < 1 Then
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

            If Me.dgvWaitingPatients.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvWaitingPatients))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvWaitingPatients.SelectAll()

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

            SaveQueuedMessage(visitNo, oServicePointID.Doctor, String.Empty, 0)

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try
    End Sub

End Class