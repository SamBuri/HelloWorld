
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmBillsPaymentReceipts

#Region " Fields "
    Private alertNoControl As Control
    Private _VisitTypeID As String
#End Region

    Private Sub frmBillsPaymentReceipts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVisitTypeID As New LookupDataID.VisitTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor()

            If Me._VisitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient.ToUpper()) Then
                Me.Text = "Bills Payment Receipts"

            ElseIf Me._VisitTypeID.ToUpper().Equals(oVisitTypeID.InPatient.ToUpper()) Then
                Me.Text = "Credit Bill Form Payment Receipts"

            Else : Me.Text = "Bills Payment Receipts"
            End If

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today.AddDays(-1)
            Me.dtpEndDateTime.Value = Now

            Me.ShowBillsPaymentReceipts(Today.AddDays(-1), Now)

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
            Me.ShowBillsPaymentReceipts(startDateTime, endDateTime)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowBillsPaymentReceipts(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim payments As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments

            If Me._VisitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient.ToUpper()) Then
                payments = oPayments.GetBillsPayment(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")

            ElseIf Me._VisitTypeID.ToUpper().Equals(oVisitTypeID.InPatient.ToUpper()) Then
                payments = oPayments.GetCreditBillFormPayment(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")

            Else : payments = oPayments.GetBillsPayment(startDateTime, endDateTime, Nothing, Nothing).Tables("Payments")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillsPaymentReceipts, payments)

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

    Private Sub dgvBillsPaymentReceipts_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillsPaymentReceipts.CellDoubleClick

        Try

            Dim receiptNo As String = Me.dgvBillsPaymentReceipts.Item(Me.colReceiptNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvBillsPaymentReceipts.ColumnCount < 1 OrElse Me.dgvBillsPaymentReceipts.RowCount < 1 Then
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

            If Me.dgvBillsPaymentReceipts.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvBillsPaymentReceipts))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvBillsPaymentReceipts.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class