
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmWaitingCashPayments

#Region " Fields "
    Private alertNoControl As Control
#End Region
    Dim visitNo As String
    Dim patientNo As String
    Dim firstName As String

    Private Sub frmWaitingCashPayments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Waiting Cash Payments!"

            Me.ShowWaitingCashPayments()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

        CheckQueueStatus()

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

    Private Sub ShowWaitingCashPayments()

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = Today.AddDays(-1)
            Dim endDate As Date = Today


            Dim billNo As String = GetLookupDataDes(oBillModesID.Cash)
            ' Load from Items

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingCashPayments As DataTable = oItems.GetPeriodicCashNotPaidItemsSummary(startDate, endDate).Tables("Items")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingItems, waitingCashPayments)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPendingItems_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingItems.CellClick
        If e.RowIndex < 0 Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colVisitNo))
        Me.patientNo = StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colPatientNo)
        Me.firstName = StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colFirstName)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        fbnCall.Enabled = e.RowIndex >= 0
    End Sub

    Private Sub dgvPendingItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingItems.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvPendingItems.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = visitNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = visitNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = visitNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPendingItems.ColumnCount < 1 OrElse Me.dgvPendingItems.RowCount < 1 Then
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

            If Me.dgvPendingItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPendingItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPendingItems.SelectAll()

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