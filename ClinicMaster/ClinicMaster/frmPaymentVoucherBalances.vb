Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmPaymentVoucherBalances
#Region " Fields "
    Private alertNoControl As Control
    Private _IncludeReceived As Boolean
#End Region


    Private Sub frmPaymentVoucherBalances_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.dtpStartDate.MaxDate = Today.AddDays(1)
            Me.dtpEndDate.MaxDate = Today.AddDays(1)

            Me.dtpStartDate.Value = Today
            Me.dtpEndDate.Value = Now

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowPeriodicPurchaseOrders(ByVal startDate As Date, ByVal endDate As Date)

        Dim oPurchaseOrders As New SyncSoft.SQLDb.PurchaseOrders()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from PurchaseOrders
            Dim purchaseOrders As DataTable = oPurchaseOrders.GetPurchaseOrdersNotPaidFor(startDate, endDate).Tables("PurchaseOrders")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicPurchaseOrders, purchaseOrders)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If purchaseOrders.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + purchaseOrders.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPeriodicServiceInvoices(ByVal startDate As Date, ByVal endDate As Date)

        Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ServiceInvoices
            Dim ServiceInvoices As DataTable = oServiceInvoices.GetServiceInvoicesNotPaidFor(startDate, endDate).Tables("ServiceInvoices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicServiceInvoices, ServiceInvoices)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If ServiceInvoices.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + ServiceInvoices.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Select Case Me.tbcPaymentVouchers.SelectedTab.Name

                Case Me.tpgGoodsInvoices.Name
                    Me.ShowPeriodicPurchaseOrders(startDate, endDate)
                    Me.tbcPaymentVouchers_SelectedIndexChanged(tbcPaymentVouchers, New EventArgs())
                Case Me.tpgServiceInvoices.Name
                    Me.ShowPeriodicServiceInvoices(startDate, endDate)
                    Me.tbcPaymentVouchers_SelectedIndexChanged(tbcPaymentVouchers, New EventArgs())
            End Select



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPaymentVouchers.SelectedTab.Name

                Case Me.tpgGoodsInvoices.Name
                    ExportToExcel(Me.dgvPeriodicPurchaseOrders, Me.tpgGoodsInvoices.Text)

                Case Me.tpgServiceInvoices.Name
                    ExportToExcel(Me.dgvPeriodicServiceInvoices, Me.tpgServiceInvoices.Text)
                
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub tbcPaymentVouchers_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcPaymentVouchers.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPaymentVouchers.SelectedTab.Name

                Case Me.tpgGoodsInvoices.Name
                    Dim rowCount As Integer = Me.dgvPeriodicPurchaseOrders.RowCount
                    Me.fbnExport.Enabled = rowCount > 0

                Case Me.tpgServiceInvoices.Name
                    Dim rowCount As Integer = Me.dgvPeriodicServiceInvoices.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                Case Else
                    Me.fbnExport.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class