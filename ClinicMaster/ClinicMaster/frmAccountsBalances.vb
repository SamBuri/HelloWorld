Option Strict On

Imports SyncSoft.Common.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID


Public Class frmAccountsBalances

    Private Sub frmAccountsBalances_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.ShowPendingPayments(Nothing)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub ShowPendingPayments(ByVal amount As Nullable(Of Decimal))

        Dim billsExceeding As DataTable
        Dim obillsExceeding As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from billsExceeding

            If nbxAmount IsNot Nothing Then
                billsExceeding = obillsExceeding.GetPatientAccountBalances(amount).Tables("Patients")
            Else : billsExceeding = obillsExceeding.GetPatientAccountBalances().Tables("Patients")
            End If




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAccountsBalance, billsExceeding)


            Me.lblRecordsNo.Text = " Returned Record(s): " + billsExceeding.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            If nbxAmount IsNot Nothing Then
                Dim amount As Decimal = DecimalMayBeEnteredIn(nbxAmount)
                Me.ShowPendingPayments(amount)

            Else

                Me.ShowPendingPayments(Nothing)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvAccountsBalance.ColumnCount < 1 OrElse Me.dgvAccountsBalance.RowCount < 1 Then
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

            If Me.dgvAccountsBalance.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvAccountsBalance))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvAccountsBalance.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class