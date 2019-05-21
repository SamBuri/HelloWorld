
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmOtherIncomeReceipts

#Region " Fields "
    Private alertNoControl As Control
#End Region

    Private Sub frmOtherIncomeReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Other Income Receipts"

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today.AddDays(-1)
            Me.dtpEndDateTime.Value = Now

            Me.ShowOtherIncomeReceipts(Today.AddDays(-1), Now)

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

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date & Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date & Time")

            If endDateTime < startDateTime Then Throw New ArgumentException("End Record Date & Time can't be before Start Record Date & Time!")
            Me.ShowOtherIncomeReceipts(startDateTime, endDateTime)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOtherIncomeReceipts(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OtherIncome
            Dim otherIncome As DataTable = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, Nothing, Nothing).Tables("OtherIncome")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOtherIncomeReceipts, otherIncome)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If otherIncome.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + otherIncome.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOtherIncomeReceipts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherIncomeReceipts.CellDoubleClick

        Try

            Dim incomeNo As String = Me.dgvOtherIncomeReceipts.Item(Me.colIncomeNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = incomeNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = incomeNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = incomeNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvOtherIncomeReceipts.ColumnCount < 1 OrElse Me.dgvOtherIncomeReceipts.RowCount < 1 Then
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

            If Me.dgvOtherIncomeReceipts.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvOtherIncomeReceipts))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvOtherIncomeReceipts.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class