
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmPeriodicInventoryTransfers

#Region " Fields "
    Private alertNoControl As Control
#End Region

    Private Sub frmPeriodicInventoryTransfers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Periodic Inventory Transfers"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowPeriodicInventoryTransfers(Today, Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicInventoryTransfers(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPeriodicInventoryTransfers(ByVal startDate As Date, ByVal endDate As Date)

        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from InventoryTransfers
            Dim InventoryTransfers As DataTable = oInventoryTransfers.GetPeriodicInventoryTransfers(startDate, endDate).Tables("InventoryTransfers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicInventoryTransfers, InventoryTransfers)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If InventoryTransfers.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + InventoryTransfers.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPeriodicInventoryTransfers_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicInventoryTransfers.CellDoubleClick

        Try

            Dim TransferNo As String = Me.dgvPeriodicInventoryTransfers.Item(Me.colTransferNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = TransferNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = TransferNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = TransferNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Close()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPeriodicInventoryTransfers.ColumnCount < 1 OrElse Me.dgvPeriodicInventoryTransfers.RowCount < 1 Then
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

            If Me.dgvPeriodicInventoryTransfers.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPeriodicInventoryTransfers))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPeriodicInventoryTransfers.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class