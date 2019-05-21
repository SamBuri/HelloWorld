
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmCashReceipts

#Region " Fields "
    Private alertNoControl As Control
    Private _PayTypeID As String
#End Region

    Private Sub frmCashReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Cash Receipts"

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today.AddDays(-1)
            Me.dtpEndDateTime.Value = Now

            Me.ShowCashReceipts(Today.AddDays(-1), Now)

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
            Me.ShowCashReceipts(startDateTime, endDateTime)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowCashReceipts(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim payments As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments

            If Me._PayTypeID.ToUpper().Equals(oPayTypeID.VisitBill.ToUpper()) Then
                payments = oPayments.GetCashPayments(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")

            ElseIf Me._PayTypeID.ToUpper().Equals(oPayTypeID.ExtraBill.ToUpper()) Then
                payments = oPayments.GetBillFormPayment(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")

            Else : payments = oPayments.GetCashPayments(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCashReceipts, payments)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If payments.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + payments.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvCashReceipts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCashReceipts.CellDoubleClick

        Try

            Dim receiptNo As String = Me.dgvCashReceipts.Item(Me.colReceiptNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = receiptNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = receiptNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = receiptNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvCashReceipts.ColumnCount < 1 OrElse Me.dgvCashReceipts.RowCount < 1 Then
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

            If Me.dgvCashReceipts.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvCashReceipts))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvCashReceipts.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class