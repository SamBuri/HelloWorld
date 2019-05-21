
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmPeriodicPhysicalStockCount

#Region " Fields "
    Dim control As Control



#End Region

    Private Sub frmPeriodicPhysicalStockCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Periodic Physical Stock Count"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowPeriodicPhsicalStockCount(Today, Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPeriodicPhysicalStockCount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub






    Private Sub ShowPeriodicPhsicalStockCount(ByVal startDate As Date, ByVal endDate As Date)

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load Physical Stock Count
            Dim physicalStockCount As DataTable = oPhysicalStockCount.GetPhysicalStockCount(Nothing, startDate, endDate).Tables("PhysicalStockCount")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPhysicalStockCount, physicalStockCount)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If physicalStockCount.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + physicalStockCount.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicPhsicalStockCount(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgvPhysicalStockCount_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPhysicalStockCount.CellDoubleClick
        Try

            Dim _PSCNo As String = Me.dgvPhysicalStockCount.Item(Me.colPSCNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.control Is TextBox Then
                CType(Me.control, TextBox).Text = _PSCNo
                CType(Me.control, TextBox).Focus()

            ElseIf TypeOf Me.control Is SmartTextBox Then
                CType(Me.control, SmartTextBox).Text = _PSCNo
                CType(Me.control, SmartTextBox).Focus()

            ElseIf TypeOf Me.control Is ComboBox Then
                CType(Me.control, ComboBox).Text = _PSCNo
                CType(Me.control, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try
    End Sub

    'Private Sub cmsAlertListCopy_Click(sender As Object, e As EventArgs) Handles cmsAlertListCopy.Click

    'End Sub


    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPhysicalStockCount.ColumnCount < 1 OrElse Me.dgvPhysicalStockCount.RowCount < 1 Then
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

            If Me.dgvPhysicalStockCount.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPhysicalStockCount))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPhysicalStockCount.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class