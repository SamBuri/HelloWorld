
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb

Public Class frmSales

#Region " Fields "

    Private drugOpeningStock As Decimal = 0
    Private drugpurchases As Decimal = 0
    Private drugClosingStock As Decimal = 0
    Private drugCost As Decimal = 0

    Private consumableOpeningStock As Decimal = 0
    Private consumablepurchases As Decimal = 0
    Private consumableClosingStock As Decimal = 0
    Private consumableCost As Decimal = 0

    Private totalOpeningStock As Decimal = 0
    Private purchases As Decimal = 0
    Private totalClosingStock As Decimal = 0
    Private costOfGoods As Decimal = 0
    Private expenses As Decimal = 0

    Private consumableMannualIssued As Decimal = 0
    Private drugMannualIssued As Decimal

    ''' '''''''''''''''''''''''''''''''''''''''''''

    Private _OPDtotalVAT As Decimal = 0
    Private _OPDtotalSales As Decimal = 0


    Private _IPDtotalVAT As Decimal = 0
    Private _IPDtotalSales As Decimal = 0

    Private _OPDAccountSales As Decimal = 0
    Private _OPDCashSales As Decimal = 0
    Private _IPDAccountSales As Decimal = 0
    Private _IPDCashSales As Decimal = 0



    Private refund As Decimal = 0
    Private totalaccountSales As Decimal = 0
    Private totalCashSales As Decimal = 0
    Private salesCost As Decimal = 0
    Private totalDisposed As Decimal = 0
    Private totalVAT As Decimal = 0
    Private totalSales As Decimal = 0
    Private netSales As Decimal = 0
    Private grossProsit As Decimal = 0
    Private netProfit As Decimal = 0

    ''' <summary>
    ''' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' </summary>
    Private WithEvents docPhysicalStockCount As New PrintDocument()
    Private profitAndLossCountDetailsParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboItemCategoryID, LookupObjects.ItemCategory, False)
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboPayStatus, LookupObjects.PayStatus, False)
            LoadLookupDataCombo(Me.cboBranchID, LookupObjects.BranchID, False)
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadItemsInventory(Today, Now, StringValueMayBeEnteredIn(cboItemCategoryID))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSales_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub



    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub




    Private Sub fbnLoadIncomeItems_Click(sender As Object, e As EventArgs) Handles fbnLoadIncomeItems.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")

            clearTextBoxes()
            Me.loadData(startDateTime, endDateTime)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowExpenditures(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal loginID As String)

        Dim expenditure As DataTable
        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Expenditure

            If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, Nothing, Nothing).Tables("Expenditure")
            Else : expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, loginID, Nothing).Tables("Expenditure")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExpenditureCollections, expenditure)
            FormatGridRow(Me.dgvExpenditureCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvExpenditureCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colExpenditureAmount)
                If amountPaid < 0 Then Me.dgvExpenditureCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If expenditure IsNot Nothing AndAlso expenditure.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniExpenditure As EnumerableRowCollection(Of DataRow) = expenditure.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniExpenditure Select data.Field(Of Decimal)("Amount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbExpenditureTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbExpensesInWords.Text = NumberToWords(totalBill)
            Else
                Me.stbExpenditureTotalAmount.Clear()
                Me.stbExpensesInWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcTradingProfitAndLostAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcTradingProfitAndLostAccount.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcTradingProfitAndLostAccount.SelectedTab.Name

                Case Me.tbcSales.Name
                    cboLocationID.Enabled = False
                    cboLoginID.Enabled = True
                    cboItemCategoryID.Enabled = True
                    cboBranchID.Enabled = True
                    Select Case Me.tbcSales.Name

                        Case Me.tpgSales.Name
                            cboLocationID.Enabled = False
                            cboLoginID.Enabled = True
                            cboItemCategoryID.Enabled = True
                            cboBranchID.Enabled = True
                            Dim rowCount As Integer = Me.dgvSales.RowCount
                            Me.fbnExport.Enabled = rowCount > 0
                            cboItemCategoryID.Enabled = True
                            Me.lblRecordsNo.Text = "Returned Sales Record(s): " + rowCount.ToString()

                        Case Me.tpgIPDSales.Name
                            cboLocationID.Enabled = False
                            cboLoginID.Enabled = True
                            cboItemCategoryID.Enabled = True
                            cboBranchID.Enabled = True
                            Dim rowCount As Integer = Me.dgvIPDSales.RowCount
                            Me.fbnExport.Enabled = rowCount > 0
                            cboItemCategoryID.Enabled = True
                            Me.lblRecordsNo.Text = "Returned Sales Record(s): " + rowCount.ToString()

                        Case Me.tpgRefund.Name
                            Dim rowCount As Integer = Me.dgvRefundsCollections.RowCount
                            Me.fbnExport.Enabled = rowCount > 0
                            cboItemCategoryID.Enabled = False
                            Me.lblRecordsNo.Text = "Returned Refunds Record(s): " + rowCount.ToString()

                    End Select

                Case Me.tpgStock.Name
                    cboLocationID.Enabled = True
                    cboItemCategoryID.Enabled = True
                    cboLoginID.Enabled = False
                    cboBranchID.Enabled = False

                    Select Case Me.tpgDrugs.Name
                        Case Me.tpgSales.Name
                            Dim rowCount As Integer = Me.dgvDrugPeriodicInventory.RowCount
                            Me.fbnExport.Enabled = rowCount > 0
                            cboItemCategoryID.Enabled = True
                            Me.lblRecordsNo.Text = "Returned Drugs Record(s): " + rowCount.ToString()

                        Case Me.tpgConsumables.Name
                            Dim rowCount As Integer = Me.dgvConsumablePeriodicInventory.RowCount
                            Me.fbnExport.Enabled = rowCount > 0

                            Me.lblRecordsNo.Text = "Returned Consumables Record(s): " + rowCount.ToString()

                    End Select
                Case Me.tpgExpenditure.Name

                    cboLocationID.Enabled = False
                    cboLoginID.Enabled = True
                    cboItemCategoryID.Enabled = False
                    cboBranchID.Enabled = False

                Case Else
                    cboBranchID.Enabled = True
                    Dim rowCount As Integer = Me.dgvExpenditureCollections.RowCount
                            Me.fbnExport.Enabled = rowCount > 0
                            cboItemCategoryID.Enabled = False

                            Me.lblRecordsNo.Text = "Returned Expenditure Record(s): " + rowCount.ToString()


            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub loadData(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oItems As New Items()
        Dim oInventory As New Inventory()
        Dim oExtraBillItems As New ExtraBillItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            clearTextBoxes()
            Dim loginID As String = StringMayBeEnteredIn(cboLoginID)

            Dim branchID As String = StringValueMayBeEnteredIn(Me.cboBranchID)
            Dim itemCategoryID As String = StringValueMayBeEnteredIn(Me.cboItemCategoryID)
            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID)
            Dim itemCode As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID)
            Dim payStatus As String = StringValueMayBeEnteredIn(cboPayStatus)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ExtraBillItems As DataTable = oExtraBillItems.GetIPDSales(startDateTime, endDateTime, branchID, itemCategoryID, itemCode, billModesID, payStatus, loginID).Tables("ExtraBillItems")
            Dim Items As DataTable = oItems.GetSales(startDateTime, endDateTime, branchID, itemCategoryID, itemCode, billModesID, payStatus, loginID).Tables("Items")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSales, Items)
            FormatGridRow(Me.dgvSales)
            LoadGridData(Me.dgvIPDSales, ExtraBillItems)
            FormatGridRow(Me.dgvIPDSales)


            Me.ShowRefunds(startDateTime, endDateTime, loginID, branchID)
            Me.ShowExpenditures(startDateTime, endDateTime, branchID, loginID)
            ShowDrugPeriodicInventory(startDateTime, endDateTime, locationID, itemCode)
            ShowConsumablePeriodicInventory(startDateTime, endDateTime, locationID, itemCode)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLogins(startDateTime, endDateTime)
            SetTextBoxes()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadLogins(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oItems As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLoginID.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from Payments
            Dim items As DataTable = oItems.GetItemsLogins(startDateTime, endDateTime).Tables("Items")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLoginID, items, "LoginID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadItemsInventory(ByVal startDateTime As Date, ByVal endDateTime As Date, itemCategoryID As String)

        Dim oItems As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboItemCode.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from Payments
            Dim items As DataTable = oItems.GetItemsInventory(startDateTime, endDateTime, itemCategoryID).Tables("Items")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, items, "ItemFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnRefresh_Click(sender As Object, e As EventArgs) Handles fbnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            ''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnLoadIncomeItems.PerformClick()
            ''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnExport_Click(sender As Object, e As EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcTradingProfitAndLostAccount.SelectedTab.Name

                Case Me.tbcSales.Name
                    Select Case Me.tbcSales.Name
                        Case Me.tpgSales.Name
                            ExportToExcel(Me.dgvSales, Me.tpgSales.Text)
                        Case Me.tpgRefund.Name
                            ExportToExcel(Me.dgvRefundsCollections, Me.tpgRefund.Text)
                        Case Me.tpgIPDSales.Name
                            ExportToExcel(Me.dgvIPDSales, Me.tpgIPDSales.Text)
                    End Select


                Case Me.tpgExpenditure.Name
                    ExportToExcel(Me.dgvExpenditureCollections, Me.tpgExpenditure.Text)
                Case Me.tpgStock.Name

                    Select Case Me.tpgStock.Name
                        Case Me.tpgDrugs.Name
                            ExportToExcel(Me.dgvDrugPeriodicInventory, Me.tpgDrugs.Text)
                        Case Me.tpgConsumables.Name
                            ExportToExcel(Me.dgvConsumablePeriodicInventory, Me.tpgConsumables.Text)
                    End Select

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub ShowRefunds(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim refunds As DataTable
        Dim oRefunds As New SyncSoft.SQLDb.Refunds()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Refunds


            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                refunds = oRefunds.GetRefunds(startDateTime, endDateTime, branchID, String.Empty).Tables("Refunds")

            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                refunds = oRefunds.GetRefunds(startDateTime, endDateTime, branchID, loginID).Tables("Refunds")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, loginID).Tables("Refunds")

            Else
                refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, String.Empty).Tables("Refunds")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvRefundsCollections, refunds)
            FormatGridRow(Me.dgvRefundsCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvRefundsCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colRefundsAmount)
                If amountPaid < 0 Then Me.dgvRefundsCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If refunds IsNot Nothing AndAlso refunds.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniRefunds As EnumerableRowCollection(Of DataRow) = refunds.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniRefunds Select data.Field(Of Decimal)("Amount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbRefundsTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbRefundsAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbRefundsTotalAmount.Clear()
                Me.stbRefundsAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowExpenditures(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal loginID As String, ByVal branchID As String)

        Dim expenditure As DataTable
        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()

        Try
            Me.Cursor = Cursors.WaitCursor


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, branchID, loginID).Tables("Expenditure")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExpenditureCollections, expenditure)
            FormatGridRow(Me.dgvExpenditureCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvExpenditureCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colExpenditureAmount)
                If amountPaid < 0 Then Me.dgvExpenditureCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDrugPeriodicInventory(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal locationID As String, ByVal drugNo As String)

        Dim periodicDrugs As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(drugNo) OrElse drugNo.Equals("*") Then
                periodicDrugs = oDrugs.GetDrugPeriodicInventory(startDateTime, endDateTime, locationID).Tables("Drugs")
            Else : periodicDrugs = oDrugs.GetDrugPeriodicInventory(startDateTime, endDateTime, locationID, drugNo).Tables("Drugs")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDrugPeriodicInventory, periodicDrugs)
            FormatGridRow(Me.dgvDrugPeriodicInventory)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowConsumablePeriodicInventory(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal locationID As String, ByVal ConsumableNo As String)

        Dim periodicConsumableItems As DataTable
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(ConsumableNo) OrElse ConsumableNo.Equals("*") Then
                periodicConsumableItems = oConsumableItems.GetConsumablePeriodicInventory(startDateTime, endDateTime, locationID).Tables("ConsumableItems")
            Else : periodicConsumableItems = oConsumableItems.GetConsumablePeriodicInventory(startDateTime, endDateTime, locationID, ConsumableNo).Tables("ConsumableItems")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumablePeriodicInventory, periodicConsumableItems)
            FormatGridRow(Me.dgvConsumablePeriodicInventory)

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub cboItemCategoryID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemCategoryID.SelectedIndexChanged
        LoadItemsInventory(DateTimeMayBeEnteredIn(dtpStartDateTime), DateTimeMayBeEnteredIn(dtpEndDateTime), StringValueMayBeEnteredIn(cboItemCategoryID))
    End Sub

    Private Sub SetTextBoxes()

        Try

            Me.Cursor = Cursors.WaitCursor
            'Me.drugOpeningStock = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colDrugOpeningStockVAlue)
            'Me.drugpurchases = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colDrugReceivedCostValue)
            'Me.drugClosingStock = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colDrugClosingStockValue)
            Me.drugMannualIssued = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colDrugMannualIssuedCostValue)

            'Me.consumableOpeningStock = CalculateGridAmount(Me.dgvConsumablePeriodicInventory, Me.colConsumableOpeningStockValue)
            'Me.consumablepurchases = CalculateGridAmount(Me.dgvConsumablePeriodicInventory, Me.colConsumableReceivedValue)
            'Me.consumableClosingStock = CalculateGridAmount(Me.dgvConsumablePeriodicInventory, Me.colConsumableClosingStockCost)

            Me.consumableMannualIssued = CalculateGridAmount(Me.dgvConsumablePeriodicInventory, Me.colConsumableMannualIssuedCostValue)
            Dim _OPDSalesCost As Decimal = CalculateGridAmount(Me.dgvSales, Me.colSalesCost)
            Dim _IPDSalesCost As Decimal = CalculateGridAmount(Me.dgvIPDSales, Me.colIPDSalesCost)
            Me.salesCost = _OPDSalesCost + _IPDSalesCost
            Me.totalDisposed = consumableMannualIssued + drugMannualIssued
            Me.totalOpeningStock = drugOpeningStock + consumableOpeningStock
            Me.purchases = drugpurchases + consumablepurchases
            Me.totalClosingStock = drugClosingStock + consumableClosingStock

            Me.costOfGoods = salesCost + totalDisposed '(totalOpeningStock + purchases) - totalClosingStock
            Me.expenses = CalculateGridAmount(Me.dgvExpenditureCollections, Me.colExpenditureAmount)

            Me._OPDtotalVAT = CalculateGridAmount(Me.dgvSales, Me.ColVATValue)
            Me._IPDtotalVAT = CalculateGridAmount(Me.dgvIPDSales, Me.colIPDVATValue)


            Me._OPDtotalSales = CalculateGridAmount(Me.dgvSales, Me.ColTotalSales)
            Me._IPDtotalSales = CalculateGridAmount(Me.dgvIPDSales, Me.colIPDTotalSales)




            Me.refund = CalculateGridAmount(Me.dgvRefundsCollections, Me.colRefundsAmount)

            Me.totalVAT = Me._OPDtotalVAT + Me._IPDtotalVAT
            Me.totalSales = Me._OPDtotalSales + Me._IPDtotalSales

            Me.netSales = totalSales - refund
            Me.grossProsit = netSales - costOfGoods
            Me.netProfit = grossProsit - expenses





            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            _OPDAccountSales = 0
            _OPDCashSales = 0
            _IPDAccountSales = 0
            _IPDCashSales = 0

            '_PaidPendingAccountSales = 0
            '_PaidPendingCashSales = 0

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oBillModes As New LookupDataID.BillModesID()

            For Each row As DataGridViewRow In Me.dgvSales.Rows
                If row.IsNewRow Then Exit For
                Dim billMode As String = StringMayBeEnteredIn(row.Cells, Me.colPayMode)

                If billMode.ToUpper().Equals(GetLookupDataDes(oBillModes.Account()).ToUpper) Then
                    _OPDAccountSales += DecimalMayBeEnteredIn(row.Cells, Me.ColTotalSales)

                ElseIf billMode.ToUpper().Equals(GetLookupDataDes(oBillModes.Cash()).ToUpper)

                    _OPDCashSales += DecimalMayBeEnteredIn(row.Cells, Me.ColTotalSales)

                End If

            Next


            For Each row As DataGridViewRow In Me.dgvIPDSales.Rows
                If row.IsNewRow Then Exit For
                Dim billMode As String = StringMayBeEnteredIn(row.Cells, Me.colIPDPayMode)

                If billMode.ToUpper().Equals(GetLookupDataDes(oBillModes.Account()).ToUpper) Then
                    _IPDAccountSales += DecimalMayBeEnteredIn(row.Cells, Me.colIPDTotalSales)


                ElseIf billMode.ToUpper().Equals(GetLookupDataDes(oBillModes.Cash()).ToUpper)
                    _IPDCashSales += DecimalMayBeEnteredIn(row.Cells, Me.colIPDTotalSales)

                End If

            Next



            Me.totalaccountSales = _IPDAccountSales + _OPDAccountSales
            Me.totalCashSales = _IPDCashSales + _OPDCashSales



            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbCashSales.Text = FormatNumber(totalCashSales, AppData.DecimalPlaces)

            Me.stbCreditSales.Text = FormatNumber(totalaccountSales, AppData.DecimalPlaces)
            stbCostOfGoods.Text = FormatNumber(costOfGoods, AppData.DecimalPlaces)

            stbExpenditureTotalAmount.Text = FormatNumber(expenses, AppData.DecimalPlaces)
            stbExpensesInWords.Text = NumberToWords(expenses)

            stbRefundsTotalAmount.Text = FormatNumber(refund, AppData.DecimalPlaces)
            stbRefundsAmountWords.Text = NumberToWords(refund)

            Me.stbTotalSales.Text = FormatNumber(totalSales, AppData.DecimalPlaces)
            Me.stbTotalSalesWords.Text = NumberToWords(totalSales)

            Me.stbTotalVAT.Text = FormatNumber(totalVAT, AppData.DecimalPlaces)
            Me.stbTotalSales.Text = FormatNumber(totalSales, AppData.DecimalPlaces)
            Me.stbTotalSalesWords.Text = NumberToWords(totalSales)
            Me.stbTotalVAT.Text = FormatNumber(totalVAT, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            stbDispodedDrugs.Text = FormatNumber(drugMannualIssued, AppData.DecimalPlaces)
            stbDisposedConsumables.Text = FormatNumber(consumableMannualIssued, AppData.DecimalPlaces)
            stbSalesCost.Text = FormatNumber(_OPDSalesCost, AppData.DecimalPlaces)


            stbNetSales.Text = FormatNumber(netSales, AppData.DecimalPlaces)
            stbGrossProfit.Text = FormatNumber(grossProsit, AppData.DecimalPlaces)
            stbNetProfit.Text = FormatNumber(netProfit, AppData.DecimalPlaces)
            stbNetProfitInWords.Text = NumberToWords(netProfit)

            stbTotalSales.Text = FormatNumber(totalSales, AppData.DecimalPlaces)
            stbTotalSalesWords.Text = NumberToWords(totalSales)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub ClearTextBoxes()


        Me.stbCashSales.Clear()
        Me.stbCreditSales.Clear()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        stbDispodedDrugs.Clear()
        stbDisposedConsumables.Clear()
        stbSalesCost.Clear()

        stbNetSales.Clear()
        stbGrossProfit.Clear()
        stbNetProfit.Clear()
        stbNetProfitInWords.Clear()

        stbTotalSales.Clear()
        stbTotalSalesWords.Clear()
    End Sub


#Region "Print"

    Private Sub PrintProfitAndLoss()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetProfitAndLossDetailPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPhysicalStockCount

            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPhysicalStockCount.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docProfitAndLoss_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPhysicalStockCount.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + "Trading Profit and Loss Statement".ToUpper()

            Dim branchName As String = StringMayBeEnteredIn(Me.cboBranchID)
            Dim startDate As String = FormatDateTime(DateTimeMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDate As String = FormatDateTime(DateTimeMayBeEnteredIn(Me.dtpEndDateTime))
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
            Dim itemCategory As String = StringMayBeEnteredIn(Me.cboItemCategoryID)
            Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboItemCode))
            Dim billMode As String = StringMayBeEnteredIn(Me.cboBillModesID)
            Dim payStatus As String = StringMayBeEnteredIn(Me.cboPayStatus)
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 6 + lineHeight

                    .DrawString("Start Date and Time: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("End Date and Time: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(branchName) Then
                        .DrawString("Branch Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(branchName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(location) Then
                        .DrawString("Inventory Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(location, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(loginID) Then
                        .DrawString("Login ID: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(loginID, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(itemCategory) Then
                        .DrawString("Item Category: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(itemCategory, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(itemName) Then
                        .DrawString("Item Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(itemName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(billMode) Then
                        .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(payStatus) Then
                        .DrawString("Pay Status: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(payStatus, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If profitAndLossCountDetailsParagraphs Is Nothing Then Return

                Do While profitAndLossCountDetailsParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(profitAndLossCountDetailsParagraphs(1), PrintParagraps)
                    profitAndLossCountDetailsParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        profitAndLossCountDetailsParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (profitAndLossCountDetailsParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetProfitAndLossDetailPrintData()


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        profitAndLossCountDetailsParagraphs = New Collection()

        Try
            Dim profitAndLossBuilder As New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Sales")
            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append("Cash Sales".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.totalCashSales))

            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Credit Sales".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.totalaccountSales))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, profitAndLossBuilder.ToString()))

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append("Total Sales".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(totalSales))
            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)

            profitAndLossBuilder.Append("Refunds".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.refund))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, profitAndLossBuilder.ToString()))

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)

            profitAndLossBuilder.Append("Net Sales".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(netSales))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))


            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Cost of Goods Sold")

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append("Sold Goods".PadRight(20))
            profitAndLossBuilder.Append(FormatNumber(Me.salesCost))
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Disposed Off".PadRight(20))
            profitAndLossBuilder.Append(FormatNumber(Me.totalDisposed))


            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, profitAndLossBuilder.ToString()))
            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)

            profitAndLossBuilder.Append("Cost of Goods Sold".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.costOfGoods))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))
            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)

            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Gross Profit".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.grossProsit))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))


            Dim oExpenditure As New Expenditure()
            Dim periodicExpenditures As DataTable = oExpenditure.GetSummarizedPeriodicExpenditure(DateTimeEnteredIn(dtpStartDateTime),
                          DateTimeEnteredIn(dtpEndDateTime), StringMayBeEnteredIn(cboLoginID), StringValueMayBeEnteredIn(cboBranchID)).Tables("Expenditure")
            If (periodicExpenditures.Rows.Count > 0) Then

                profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)

                profitAndLossBuilder.Append(ControlChars.NewLine)
                profitAndLossBuilder.Append(ControlChars.NewLine)
                profitAndLossBuilder.Append("Expenses")
                profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))

                profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
                For pos As Integer = 0 To periodicExpenditures.Rows.Count - 1

                    Dim row As DataRow = periodicExpenditures.Rows(pos)

                    profitAndLossBuilder.Append(StringEnteredIn(row, "ExpenditureCategory").PadRight(20))
                    profitAndLossBuilder.Append(FormatNumber(CDec(StringEnteredIn(row, "ExpenditureCategoryTotal"))))
                    profitAndLossBuilder.Append(ControlChars.NewLine)
                Next
                profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, profitAndLossBuilder.ToString()))

                profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
                profitAndLossBuilder.Append("Total Expenses".PadRight(40))
                profitAndLossBuilder.Append(FormatNumber(Me.expenses))

                profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))
            Else
                profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
                profitAndLossBuilder.Append(ControlChars.NewLine)
                profitAndLossBuilder.Append("Expenses".PadRight(40))
                profitAndLossBuilder.Append(FormatNumber(Me.expenses))

                profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, profitAndLossBuilder.ToString()))
            End If

            profitAndLossBuilder = New System.Text.StringBuilder(String.Empty)
            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Net Profit Before Tax".PadRight(40))
            profitAndLossBuilder.Append(FormatNumber(Me.netProfit))

            profitAndLossBuilder.Append(ControlChars.NewLine)
            profitAndLossBuilder.Append("Net  Profit Before Tax in Words: " + NumberToWords(netProfit))

            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, profitAndLossBuilder.ToString()))


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            profitAndLossCountDetailsParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetProfitAndLossDetailPrintData()

            With dlgPrintPreview
                .Document = docPhysicalStockCount
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintProfitAndLoss()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub






#End Region



End Class

