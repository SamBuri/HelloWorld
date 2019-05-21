Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmCashDailyReport

    Private Sub validateCollections(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Try
            Dim message As String

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    If Me.dgvCashCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgCashPayment.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                        DisplayMessage(message)
                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvCashCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgExpenditure.Name

                    If Me.dgvExpenditureCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgExpenditure.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvExpenditureCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Expenditure Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgInsurance.Name

                    If Me.dgvInsuranceCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgInsurance.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                        DisplayMessage(message)
                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvInsuranceCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Insurance Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgAccount.Name

                    If Me.dgvAccountCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgAccount.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(message)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvAccountCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Accounts Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgOtherIncomes.Name

                    If Me.dgvOtherIncomeCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgOtherIncomes.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(message)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvOtherIncomeCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Other Income Record(s): " + rowCount.ToString()


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDiscounts.Name

                    If Me.dgvDiscounts.RowCount <= 0 Then

                        message = "No " + Me.tpgDiscounts.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(message)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvDiscounts.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Discounts Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgRefunds.Name

                    If Me.dgvRefundsCollections.RowCount <= 0 Then

                        message = "No " + Me.tpgRefunds.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        DisplayMessage(message)
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvRefundsCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Refunds Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case Me.tpgManagerAccounts.Name

                    If Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgCreditAccounts.Name) Then
                        If Me.dgvManageAccountCredits.RowCount <= 0 Then

                            message = "No " + Me.tpgCreditAccounts.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                            DisplayMessage(message)
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim rowCount As Integer = Me.dgvManageAccountCredits.RowCount
                        Me.fbnExport.Enabled = rowCount > 0
                        Me.lblRecordsNo.Text = "Returned Credit Record(s): " + rowCount.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ElseIf Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgDebitAccounts.Name) Then

                        If Me.dgvManageAccountDebits.RowCount <= 0 Then

                            message = "No " + Me.tpgDebitAccounts.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                            DisplayMessage(message)
                        End If


                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim rowCount As Integer = Me.dgvManageAccountDebits.RowCount
                        Me.fbnExport.Enabled = rowCount > 0
                        Me.lblRecordsNo.Text = "Returned Debit Record(s): " + rowCount.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If


            End Select



        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcCashCollections_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcCashCollections.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    Dim rowCount As Integer = Me.dgvCashCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblBranchID.Visible = True
                    Me.cboBranchID.Visible = True
                    Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()
                Case Me.tpgExpenditure.Name
                    Me.lblBranchID.Visible = False
                    Me.cboBranchID.Visible = False
                    Dim rowCount As Integer = Me.dgvExpenditureCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Expenditure Record(s): " + rowCount.ToString()

                Case Me.tpgAccount.Name

                    Dim rowCount As Integer = Me.dgvAccountCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Accounts Record(s): " + rowCount.ToString()
                    Me.lblBranchID.Visible = True
                    Me.cboBranchID.Visible = True

                Case Me.tpgInsurance.Name

                    Dim rowCount As Integer = Me.dgvInsuranceCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Insurance Record(s): " + rowCount.ToString()
                    Me.lblBranchID.Visible = True
                    Me.cboBranchID.Visible = True

                Case Me.tpgOtherIncomes.Name

                    Dim rowCount As Integer = Me.dgvOtherIncomeCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Other Income Record(s): " + rowCount.ToString()
                    Me.lblBranchID.Visible = False
                    Me.cboBranchID.Visible = False

                Case Me.tpgDiscounts.Name
                    Me.lblBranchID.Visible = False
                    Me.cboBranchID.Visible = False
                    Dim rowCount As Integer = Me.dgvDiscounts.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Discount Record(s): " + rowCount.ToString()

                Case Me.tpgRefunds.Name
                    Me.lblBranchID.Visible = False
                    Me.cboBranchID.Visible = False
                    Dim rowCount As Integer = Me.dgvRefundsCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Refund Record(s): " + rowCount.ToString()

                Case Me.tpgOtherPayments.Name
                    Me.lblBranchID.Visible = True
                    Me.cboBranchID.Visible = True
                    Dim rowCount As Integer = Me.dgvOtherPayments.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Other Payments Record(s): " + rowCount.ToString()


                Case Me.tpgManagerAccounts.Name
                    Me.lblBranchID.Visible = False
                    Me.cboBranchID.Visible = False
                    If Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgCreditAccounts.Name) Then
                        Dim rowCount As Integer = Me.dgvManageAccountCredits.RowCount
                        Me.fbnExport.Enabled = rowCount > 0
                        '  Me.btnPrint.Enabled = rowCount > 0
                        Me.lblRecordsNo.Text = "Returned Account Credit Record(s): " + rowCount.ToString()
                    ElseIf Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgDebitAccounts.Name) Then
                        Dim rowCount As Integer = Me.dgvManageAccountDebits.RowCount
                        Me.fbnExport.Enabled = rowCount > 0
                        '  Me.btnPrint.Enabled = rowCount > 0
                        Me.lblRecordsNo.Text = "Returned Account Debit Record(s): " + rowCount.ToString()

                    End If


                Case Else
                    Me.fbnExport.Enabled = False
                    ' Me.btnPrint.Enabled = False
                    Me.lblBranchID.Visible = True
                    Me.cboBranchID.Visible = True
            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor


            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    ExportToExcel(Me.dgvCashCollections, Me.tpgCashPayment.Text)

                Case Me.tpgInsurance.Name
                    ExportToExcel(Me.dgvInsuranceCollections, Me.tpgInsurance.Text)

                Case Me.tpgExpenditure.Name
                    ExportToExcel(Me.dgvExpenditureCollections, Me.tpgExpenditure.Text)

                Case Me.tpgAccount.Name
                    ExportToExcel(Me.dgvAccountCollections, Me.tpgAccount.Text)
                Case Me.tpgOtherIncomes.Name
                    ExportToExcel(Me.dgvOtherIncomeCollections, Me.tpgOtherIncomes.Text)
                Case Me.tpgRefunds.Name
                    ExportToExcel(Me.dgvRefundsCollections, Me.tpgRefunds.Text)
                Case Me.tpgDiscounts.Name
                    ExportToExcel(Me.dgvDiscounts, Me.tpgDiscounts.Text)
                Case Me.tpgOtherPayments.Name
                    ExportToExcel(Me.dgvOtherPayments, Me.tpgOtherPayments.Text)
                Case Me.tpgManagerAccounts.Name
                    If Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgDebitAccounts.Name) Then
                        ExportToExcel(Me.dgvManageAccountDebits, Me.tpgDebitAccounts.Text)
                    ElseIf Me.tbcManageAccounts.SelectedTab.Name.Equals(Me.tpgCreditAccounts.Name) Then
                        ExportToExcel(Me.dgvManageAccountCredits, Me.tpgCreditAccounts.Text)
                    End If
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowExpenditureCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, branchID As String)

        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Expenditure

            Dim expenditure As DataTable = oExpenditure.GetExpenditure(startDateTime, endDateTime, Nothing, Nothing).Tables("Expenditure")
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
                Me.stbTotalExpenditure.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbExpenditureAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbExpenditureTotalAmount.Clear()
                Me.stbTotalExpenditure.Clear()
                Me.stbExpenditureAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDailyCashPayments(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim branchID As String = StringValueMayBeEnteredIn(Me.cboBranchID)
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments

            Dim cashPayments As DataTable = oPayments.GetOtherPayments(startDateTime, endDateTime, Nothing, branchID).Tables("Payments")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCashCollections, cashPayments)
            FormatGridRow(Me.dgvCashCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvCashCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCashAmountPaid)
                If amountPaid < 0 Then Me.dgvCashCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If cashPayments IsNot Nothing AndAlso cashPayments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniCashPayments As EnumerableRowCollection(Of DataRow) = cashPayments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniCashPayments Select data.Field(Of Decimal)("OAmountPaid")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbCashTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbGrandAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbCashTotalAmount.Clear()
                Me.stbGrandAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDailyInsurancePayments(ByVal startDateTime As Date, ByVal endDateTime As Date, branchID As String)

        Dim insurancePayments As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
                insurancePayments = oVisits.GetDailyInsuranceVisitsPayments(startDateTime, endDateTime).Tables("Visits")

            Else
                insurancePayments = oVisits.GetDailyInsuranceVisitsPayments(startDateTime, endDateTime, branchID).Tables("Visits")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCollections, insurancePayments)
            FormatGridRow(Me.dgvInsuranceCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvInsuranceCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colInsuranceAmount)
                If amountPaid < 0 Then Me.dgvInsuranceCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If insurancePayments IsNot Nothing AndAlso insurancePayments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniInsurancePayments As EnumerableRowCollection(Of DataRow) = insurancePayments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniInsurancePayments Select data.Field(Of Decimal)("TotalBill")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbInsuranceTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbInsuranceAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbInsuranceTotalAmount.Clear()
                Me.stbInsuranceAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOtherPayments(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal paymentsModeID As String, ByVal branchID As String)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim otherPayments As DataTable
        Try
            Me.Cursor = Cursors.WaitCursor


            If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
                otherPayments = oPayments.GetOtherPayments(startDateTime, endDateTime, paymentsModeID).Tables("Payments")

          Else : otherPayments = oPayments.GetOtherPayments(startDateTime, endDateTime, paymentsModeID, branchID).Tables("Payments")
            End If




            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOtherPayments, otherPayments)
            FormatGridRow(Me.dgvOtherPayments)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvOtherPayments.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colOtherPaymentNetAmount)
                If amountPaid < 0 Then Me.dgvOtherPayments.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If otherPayments IsNot Nothing AndAlso otherPayments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniCashPayments As EnumerableRowCollection(Of DataRow) = otherPayments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniCashPayments Select data.Field(Of Decimal)("NetAmount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbOtherPayment.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbOtherPaymentsWords.Text = NumberToWords(totalBill)
            Else
                Me.stbOtherPayment.Clear()
                Me.stbOtherPaymentsWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDailyAccountsPayments(ByVal startDateTime As Date, ByVal endDateTime As Date, branchID As String)

        Dim accountPayments As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
                accountPayments = oVisits.GetDailyAccountVisitsPayments(startDateTime, endDateTime).Tables("Visits")

            Else
                accountPayments = oVisits.GetDailyAccountVisitsPayments(startDateTime, endDateTime, branchID).Tables("Visits")
            End If

            LoadGridData(Me.dgvAccountCollections, accountPayments)
            FormatGridRow(Me.dgvAccountCollections)



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvAccountCollections.Rows
                If row.IsNewRow Then Exit For
                Dim acAmountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.ColAcAmount)
                If acAmountPaid < 0 Then Me.dgvAccountCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountPayments IsNot Nothing AndAlso accountPayments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniAccountPayments As EnumerableRowCollection(Of DataRow) = accountPayments.AsEnumerable()
                Dim totalAcBill As Decimal = (From data In miniAccountPayments Select data.Field(Of Decimal)("AcTotalBill")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbAccountTotalAmount.Text = FormatNumber(totalAcBill, AppData.DecimalPlaces)
                Me.stbAccountAmountWords.Text = NumberToWords(totalAcBill)
            Else
                Me.stbAccountTotalAmount.Clear()
                Me.stbAccountAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOtherIncomeCollections(ByVal startDateTime As Date, ByVal endDateTime As Date)
        Dim otherIncome As DataTable
        Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OtherIncome

            ' If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
            otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, Nothing, Nothing).Tables("OtherIncome")

            'Else : otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, Nothing, branchID).Tables("OtherIncome")
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOtherIncomeCollections, otherIncome)
            FormatGridRow(Me.dgvOtherIncomeCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvOtherIncomeCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colOtherIncomeAmount)
                If amountPaid < 0 Then Me.dgvOtherIncomeCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If otherIncome IsNot Nothing AndAlso otherIncome.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniOtherIncome As EnumerableRowCollection(Of DataRow) = otherIncome.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniOtherIncome Select data.Field(Of Decimal)("Amount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbOtherIncomeTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbOtherIncomeAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbOtherIncomeTotalAmount.Clear()
                Me.stbOtherIncomeAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowManageAccountDebits(ByVal startDateTime As Date, ByVal endDateTime As Date)
        Dim debits As DataTable
        Dim oDebits As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Accounts
            ' If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
            debits = oDebits.GetManageAccountDebits(startDateTime, endDateTime).Tables("Accounts")

            'Else : debits = oDebits.GetManageAccountDebits(startDateTime, endDateTime, branchID).Tables("Accounts")
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvManageAccountDebits, debits)
            FormatGridRow(Me.dgvManageAccountDebits)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvManageAccountDebits.Rows
                If row.IsNewRow Then Exit For
                Dim amountDebited As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.ColDebitAmount)
                If amountDebited < 0 Then Me.dgvManageAccountDebits.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If debits IsNot Nothing AndAlso debits.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniDebits As EnumerableRowCollection(Of DataRow) = debits.AsEnumerable()
                Dim totalDebits As Decimal = (From data In miniDebits Select data.Field(Of Decimal)("Amount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbDebitTotalAmount.Text = FormatNumber(totalDebits, AppData.DecimalPlaces)
                Me.stbDebitAmount.Text = FormatNumber(totalDebits, AppData.DecimalPlaces)
                Me.stbDebitAmountWords.Text = NumberToWords(totalDebits)
            Else
                Me.stbDebitTotalAmount.Clear()
                Me.stbDebitAmountWords.Clear()
                Me.stbDebitAmount.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowManageAccountCredits(ByVal startDateTime As Date, ByVal endDateTime As Date)
        Dim credits As DataTable
        Dim oDebits As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Accounts

            ' If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
            credits = oDebits.GetManageAccountCredits(startDateTime, endDateTime).Tables("Accounts")

            'Else : credits = oDebits.GetManageAccountCredits(startDateTime, endDateTime, branchID).Tables("Accounts")
            'End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvManageAccountCredits, credits)
            FormatGridRow(Me.dgvManageAccountCredits)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvManageAccountCredits.Rows
                If row.IsNewRow Then Exit For
                Dim amountCredited As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCreditAmount)
                If amountCredited < 0 Then Me.dgvManageAccountCredits.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If credits IsNot Nothing AndAlso credits.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniCredits As EnumerableRowCollection(Of DataRow) = credits.AsEnumerable()
                Dim totalCredits As Decimal = (From data In miniCredits Select data.Field(Of Decimal)("Amount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbCreditTotalAmount.Text = FormatNumber(totalCredits, AppData.DecimalPlaces)
            Else
                Me.stbCreditTotalAmount.Clear()

            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowRefundsCollections(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim refunds As DataTable
        Dim oRefunds As New SyncSoft.SQLDb.Refunds()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Refunds

            'If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
            refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, Nothing).Tables("Refunds")
            'Else : refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, branchID).Tables("Refunds")
            'End If
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

    Private Sub ShowDiscounts(ByVal startDateTime As Date, ByVal endDateTime As Date)
        Dim paymentDetails As DataTable
        Dim oPaymentDetails As New SyncSoft.SQLDb.PaymentDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from PaymentDetails

            'If String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
            paymentDetails = oPaymentDetails.GetDiscounts(startDateTime, endDateTime).Tables("PaymentDetails")
            'Else : paymentDetails = oPaymentDetails.GetDiscounts(startDateTime, endDateTime, branchID).Tables("PaymentDetails")
            'End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDiscounts, paymentDetails)
            FormatGridRow(Me.dgvDiscounts)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvDiscounts.Rows
                If row.IsNewRow Then Exit For
                Dim discountOffered As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.ColDiscountDiscount)
                If discountOffered < 0 Then Me.dgvDiscounts.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If paymentDetails IsNot Nothing AndAlso paymentDetails.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniDiscount As EnumerableRowCollection(Of DataRow) = paymentDetails.AsEnumerable()
                Dim totalDiscount As Decimal = (From data In miniDiscount Select data.Field(Of Decimal)("Discount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbTotalDiscount.Text = FormatNumber(totalDiscount, AppData.DecimalPlaces)
                Me.stbDiscountAmountWords.Text = NumberToWords(totalDiscount)
            Else

                Me.stbTotalDiscount.Clear()
                Me.stbDiscountAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click

        Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
        Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")
        Dim paymentID As String = StringValueMayBeEnteredIn(Me.cboPaymodes)
        Dim branchID As String = StringValueMayBeEnteredIn(Me.cboBranchID)



            Try
                Me.Cursor = Cursors.WaitCursor

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date and Time can't be before Start Date and Time!")
            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    Me.ShowDailyCashPayments(startDateTime, endDateTime)

                Case Me.tpgOtherPayments.Name
                    Me.ShowOtherPayments(startDateTime, endDateTime, paymentID, branchID)

                Case Me.tpgExpenditure.Name
                    Me.ShowExpenditureCollections(startDateTime, endDateTime, branchID)

                Case tpgInsurance.Name
                    ShowDailyInsurancePayments(startDateTime, endDateTime, branchID)

                Case tpgAccount.Name
                    ShowDailyAccountsPayments(startDateTime, endDateTime, branchID)

                Case tpgOtherIncomes.Name
                    ShowOtherIncomeCollections(startDateTime, endDateTime)
                Case Me.tpgManagerAccounts.Name
                    Me.ShowManageAccountCredits(startDateTime, endDateTime)
                    Me.ShowManageAccountDebits(startDateTime, endDateTime)

                Case tpgRefunds.Name
                    Me.ShowRefundsCollections(startDateTime, endDateTime)
                Case tpgDiscounts.Name
                    Me.ShowDiscounts(startDateTime, endDateTime)
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            validateCollections(startDateTime, endDateTime)

            Dim totalIncome As Decimal = DecimalMayBeEnteredIn(Me.stbCashTotalAmount, True)
            Dim totalExpenditure As Decimal = DecimalMayBeEnteredIn(Me.stbExpenditureTotalAmount, True)

            Dim grandTotal As Decimal = totalIncome - totalExpenditure

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If grandTotal = 0 Then
                Me.stbGrandTotalAmount.Clear()
                Me.stbGrandAmountWords.Clear()
            Else
                Me.stbGrandTotalAmount.Text = FormatNumber(grandTotal, AppData.DecimalPlaces)
                Me.stbGrandAmountWords.Text = NumberToWords(grandTotal)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totaldebit As Decimal = DecimalMayBeEnteredIn(Me.stbDebitTotalAmount, True)
            Dim totalcredit As Decimal = DecimalMayBeEnteredIn(Me.stbCreditTotalAmount, True)

            Dim accountGrandtotal As Decimal = totalcredit - totaldebit

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountGrandtotal = 0 Then
                Me.stbAccountGrandTotal.Clear()
                Me.stbAccountGrandTotalWords.Clear()
            Else
                Me.stbAccountGrandTotal.Text = FormatNumber(accountGrandtotal, AppData.DecimalPlaces)
                Me.stbAccountGrandTotalWords.Text = NumberToWords(accountGrandtotal)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Catch ex As Exception
                ErrorMessage(ex)

            Finally
                Me.Cursor = Cursors.Default

            End Try



    End Sub

    Private Sub fbnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles fbnRefresh.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            ''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnLoad.PerformClick()
            ''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub tbcManageAccounts_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcManageAccounts.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcManageAccounts.SelectedTab.Name

                Case Me.tpgCreditAccounts.Name
                    Dim rowCount As Integer = Me.dgvManageAccountCredits.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Account Credit Record(s): " + rowCount.ToString()

                Case Me.tpgDebitAccounts.Name
                    Dim rowCount As Integer = Me.dgvManageAccountDebits.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    '  Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Account Debit Record(s): " + rowCount.ToString()

                Case Else
                    Me.fbnExport.Enabled = False
                    ' Me.btnPrint.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmCashDailyReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.cboPaymodes, LookupObjects.PayModes, True)
            LoadLookupDataCombo(Me.cboBranchID, LookupObjects.VisitCategory, False)
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnPaymentModes_Click(sender As System.Object, e As System.EventArgs)

        Try
            Me.Cursor = Cursors.WaitCursor



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class