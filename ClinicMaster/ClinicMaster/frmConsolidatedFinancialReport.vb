Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmConsolidatedFinancialReport
#Region " Fields "
    Private Const splitCHAR As Char = ","c
    Private items As DataTable
    Private extraBillItems As DataTable
    Private billCustomers As DataTable
    Private insuranceCompanies As DataTable
    Private billCompanies As DataTable
#End Region

    Private Sub frmConsolidatedFinancialReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        Me.dtpStartDate.MaxDate = Today.AddDays(1)
        Me.dtpEndDate.MaxDate = Today.AddDays(1)

        Me.dtpStartDate.Value = Today
        Me.dtpEndDate.Value = Now

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.ItemCategory, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oReports As New SyncSoft.SQLDb.Reports()
            Dim oAccountActionID As New LookupDataID.AccountActionID()
            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim reports As DataTable
            Dim styleTotal As New DataGridViewCellStyle()
            Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

            Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")
            Dim itemcategory As String = StringValueMayBeEnteredIn(Me.cboItemCategoryID)
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                
                Case Me.tpgIncomePaymentDetails.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(itemcategory) Then
                        reports = oReports.GetDetailedIncomePaymentDetailsSummaries(startDate, endDate, itemcategory).Tables("Reports")
                    Else
                        reports = oReports.GetDetailedIncomePaymentDetailsSummaries(startDate, endDate).Tables("Reports")

                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIncomePaymentDetails.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIncomePaymentDetails

                            .Rows.Add()

                            .Item(Me.colPaymentDetailsReceiptNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "ReceiptNo")
                            .Item(Me.colPaymentDetailsVisitDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "VisitDate"), True)
                            .Item(Me.colPaymentDetailsFullName.Name, rowNo).Value = StringMayBeEnteredIn(row, "FullName")
                            .Item(Me.colIncomePaymentDetailsCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.colPaymentDetailsTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.colPaymentDetailsPaidAfterDays.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "PaidAfterDays")
                            .Item(Me.colPaymentDetailsRecordDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "RecordDate"), True)
                            .Item(Me.colPaymentDetailsRecordTime.Name, rowNo).Value = StringMayBeEnteredIn(row, "RecordTime")

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIncomePaymentDetails, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Case Me.tpgCreditCashSales.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(itemcategory) Then
                        reports = oReports.GetDetailedNotPaidIncomePaymentDetailsSummaries(startDate, endDate, itemcategory).Tables("Reports")
                    Else
                        reports = oReports.GetDetailedNotPaidIncomePaymentDetailsSummaries(startDate, endDate).Tables("Reports")

                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCreditCashSales.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvCreditCashSales

                            .Rows.Add()

                            .Item(Me.colCCSVisitNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "VisitNo")
                            .Item(Me.colCCSVisitDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "VisitDate"), True)
                            .Item(Me.colCCSFullName.Name, rowNo).Value = StringMayBeEnteredIn(row, "FullName")
                            .Item(Me.ColCCSIncomeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.ColCCSTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.ColCCSRecordDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "RecordDate"), True)
                            .Item(Me.ColCCSRecordTime.Name, rowNo).Value = StringMayBeEnteredIn(row, "RecordTime")

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvCreditCashSales, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                Case Me.tpgIPDCashPayments.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(itemcategory) Then
                        reports = oReports.GetIPDDetailedIncomePaymentDetailsSummaries(startDate, endDate, itemcategory).Tables("Reports")
                    Else
                        reports = oReports.GetIPDDetailedIncomePaymentDetailsSummaries(startDate, endDate).Tables("Reports")

                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIPDCashPayments.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIPDCashPayments

                            .Rows.Add()

                            .Item(Me.ColIPDReceiptNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "ReceiptNo")
                            .Item(Me.ColIPDVisitDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "VisitDate"), True)
                            .Item(Me.ColIPDFullName.Name, rowNo).Value = StringMayBeEnteredIn(row, "FullName")
                            .Item(Me.ColIPDIncomeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.ColIPDTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.ColIPDRecordDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "RecordDate"), True)
                            .Item(Me.ColIPDRecordTime.Name, rowNo).Value = StringMayBeEnteredIn(row, "RecordTime")

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIPDCashPayments, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgIPDCreditBillsPayment.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(itemcategory) Then
                        reports = oReports.GetDetailedIPDNotPaidIncomePaymentDetailsSummaries(startDate, endDate, itemcategory).Tables("Reports")
                    Else
                        reports = oReports.GetDetailedIPDNotPaidIncomePaymentDetailsSummaries(startDate, endDate).Tables("Reports")

                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIPDCreditBillPayment.Rows.Clear()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    For rowNo As Integer = 0 To reports.Rows.Count - 1

                        Dim row As DataRow = reports.Rows(rowNo)

                        With Me.dgvIPDCreditBillPayment

                            .Rows.Add()

                            .Item(Me.ColIPDCreditBillVisitNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "VisitNo")
                            .Item(Me.ColIPDCreditBillVisitDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "VisitDate"), True)
                            .Item(Me.ColIPDCreditBillFullName.Name, rowNo).Value = StringMayBeEnteredIn(row, "FullName")
                            .Item(Me.ColIPDCreditBillIncomeCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "IncomeCategory")
                            .Item(Me.ColIPDCreditBillTotalAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalAmount"))
                            .Item(Me.ColIPDCreditBillRecordDate.Name, rowNo).Value = FormatDate(DateMayBeEnteredIn(row, "RecordDate"), True)
                            .Item(Me.ColIPDCreditBillRecordTime.Name, rowNo).Value = StringMayBeEnteredIn(row, "RecordTime")

                            If rowNo = reports.Rows.Count - 1 Then
                                styleTotal.BackColor = Color.AliceBlue
                                styleTotal.Font = font
                                .Rows(rowNo).DefaultCellStyle.ApplyStyle(styleTotal)
                            End If

                        End With

                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    FormatGridRow(Me.dgvIPDCreditBillPayment, Nothing, 3)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select
            LoadGoodsReceivedNoteDetailsSupplierHistory()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotal()
        Try
            Cursor = Cursors.WaitCursor
            stbTotalAmount.Clear()
            stbAmountWords.Clear()

            Dim netSupplied As Decimal = CalculateGridAmount(Me.dgvSupplierHistory, Me.colNetAmount)

            stbTotalAmount.Text = FormatNumber(netSupplied, AppData.DecimalPlaces)

            If netSupplied < 1 Then Return
            stbAmountWords.Text = NumberToWords(netSupplied)
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LoadGoodsReceivedNoteDetailsSupplierHistory()

        Dim GoodsReceivedNoteDetails As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")
            Dim itemcategory As String = StringValueMayBeEnteredIn(Me.cboItemCategoryID)
            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim OGoodsReceivedNoteDetails As New GoodsReceivedNoteDetails()

            If Not String.IsNullOrEmpty(itemcategory) Then
                GoodsReceivedNoteDetails = OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, itemcategory, String.Empty, startDate, endDate).Tables("GoodsReceivedNoteDetails")

            Else
                GoodsReceivedNoteDetails = OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, String.Empty, String.Empty, startDate, endDate).Tables("GoodsReceivedNoteDetails")

            End If


            Dim rows As Integer = GoodsReceivedNoteDetails.Rows.Count()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSupplierHistory, GoodsReceivedNoteDetails)
            FormatGridRow(Me.dgvSupplierHistory)



            Me.CalculateTotal()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnExportTo_Click(sender As System.Object, e As System.EventArgs) Handles fbnExportTo.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgIncomePaymentDetails.Name
                    ExportToExcel(Me.dgvIncomePaymentDetails, Me.tpgIncomePaymentDetails.Text)

                Case Me.tpgCreditCashSales.Name
                    ExportToExcel(Me.dgvCreditCashSales, Me.tpgCreditCashSales.Text)

                Case Me.tpgIPDCashPayments.Name
                    ExportToExcel(Me.dgvIPDCashPayments, Me.tpgIPDCashPayments.Text)

                Case Me.tpgIPDCreditBillsPayment.Name
                    ExportToExcel(Me.dgvIPDCreditBillPayment, Me.tpgIPDCreditBillsPayment.Text)

                Case Me.tpgSupplierHistory.Name
                    ExportToExcel(Me.dgvSupplierHistory, Me.tpgSupplierHistory.Text)


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class