
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.Drawing.Printing

Public Class frmCashCollections

#Region " Fields "

    Private padNo As Integer = 10
    Private padDetails As Integer = 18
    Private padAmount As Integer = 14
    Private padTendered As Integer = 14
    Private padCurrency As Integer = 14

    Private WithEvents docCollections As New PrintDocument()

    ' The paragraphs.
    Private collectionParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmCashCollections_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now
            LoadLookupDataCombo(Me.cboBranchID, LookupObjects.BranchID, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.EnableViewCashCollections Then
                Me.cboLoginID.Text = CurrentUser.LoginID
                Me.cboLoginID.Enabled = False
            Else
                Me.cboLoginID.Text = CurrentUser.LoginID
                Me.cboLoginID.Enabled = True
            End If
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
            Dim BranchID As String = StringValueMayBeEnteredIn(Me.cboBranchID)
            Me.fbnLoad.PerformClick()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




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

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date and Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date and Time")
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)
            Dim branchID As String = StringValueMayBeEnteredIn(Me.cboBranchID)
            
            Me.ShowCollections(startDateTime, endDateTime, branchID, loginID)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnRefresh.Click

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

    Private Sub ResetControls(ByVal state As Boolean)
        Me.fbnExport.Enabled = state
        Me.btnPrint.Enabled = state
    End Sub

    Private Sub dtpStartDateTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDateTime.ValueChanged
        Me.ResetControls(False)
    End Sub

    Private Sub dtpEndDateTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEndDateTime.ValueChanged
        Me.ResetControls(False)
    End Sub

    Private Sub cboLoginID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLoginID.TextChanged
        Me.ResetControls(False)
    End Sub

    Private Sub ShowCashCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim payments As DataTable
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments


            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                payments = oPayments.GetCashPayments(startDateTime, endDateTime, branchID, String.Empty).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                payments = oPayments.GetCashPayments(startDateTime, endDateTime, branchID, loginID).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                payments = oPayments.GetCashPayments(startDateTime, endDateTime, Nothing, loginID).Tables("Payments")

            Else
                payments = oPayments.GetCashPayments(startDateTime, endDateTime, Nothing, String.Empty).Tables("Payments")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCashCollections, payments)
            FormatGridRow(Me.dgvCashCollections)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvCashCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAmountPaid)
                If amountPaid < 0 Then Me.dgvCashCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payments IsNot Nothing AndAlso payments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniPayments As EnumerableRowCollection(Of DataRow) = payments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniPayments Select data.Field(Of Decimal)("AmountPaid")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbCashTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbCashAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbCashTotalAmount.Clear()
                Me.stbCashAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowBillFormCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim payments As DataTable
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                payments = oPayments.GetBillFormPayment(startDateTime, endDateTime, String.Empty, branchID).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                payments = oPayments.GetBillFormPayment(startDateTime, endDateTime, loginID, branchID).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                payments = oPayments.GetBillFormPayment(startDateTime, endDateTime, loginID, Nothing).Tables("Payments")

            Else
                payments = oPayments.GetBillFormPayment(startDateTime, endDateTime, String.Empty, Nothing).Tables("Payments")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillFormCollections, payments)
            FormatGridRow(Me.dgvBillFormCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvBillFormCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colBFPAmountPaid)
                If amountPaid < 0 Then Me.dgvBillFormCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payments IsNot Nothing AndAlso payments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniPayments As EnumerableRowCollection(Of DataRow) = payments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniPayments Select data.Field(Of Decimal)("AmountPaid")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbBFPTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbBFPAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbBFPTotalAmount.Clear()
                Me.stbBFPAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowBPCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim payments As DataTable
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments

          
            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                payments = oPayments.GetBillsPayment(startDateTime, endDateTime, branchID, String.Empty).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                payments = oPayments.GetBillsPayment(startDateTime, endDateTime, branchID, loginID).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                payments = oPayments.GetBillsPayment(startDateTime, endDateTime, Nothing, loginID).Tables("Payments")

            Else
                payments = oPayments.GetBillsPayment(startDateTime, endDateTime, Nothing, String.Empty).Tables("Payments")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBPCollections, payments)
            FormatGridRow(Me.dgvBPCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvBPCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colBPAmountPaid)
                If amountPaid < 0 Then Me.dgvBPCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payments IsNot Nothing AndAlso payments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniPayments As EnumerableRowCollection(Of DataRow) = payments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniPayments Select data.Field(Of Decimal)("AmountPaid")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbBPTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbBPAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbBPTotalAmount.Clear()
                Me.stbBPAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowCBFPCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal visitsBranch As String, ByVal loginID As String)

        Dim payments As DataTable
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments


            If Not String.IsNullOrEmpty(visitsBranch) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                payments = oPayments.GetCreditBillFormPayment(startDateTime, endDateTime, visitsBranch, String.Empty).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(visitsBranch) AndAlso Not String.IsNullOrEmpty(loginID) Then
                payments = oPayments.GetCreditBillFormPayment(startDateTime, endDateTime, visitsBranch, loginID).Tables("Payments")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(visitsBranch) Then
                payments = oPayments.GetCreditBillFormPayment(startDateTime, endDateTime, Nothing, loginID).Tables("Payments")

            Else
                payments = oPayments.GetCreditBillFormPayment(startDateTime, endDateTime, Nothing, String.Empty).Tables("Payments")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCBFPCollections, payments)
            FormatGridRow(Me.dgvCBFPCollections)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvCBFPCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCBFPAmountPaid)
                If amountPaid < 0 Then Me.dgvCBFPCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payments IsNot Nothing AndAlso payments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniPayments As EnumerableRowCollection(Of DataRow) = payments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniPayments Select data.Field(Of Decimal)("AmountPaid")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbCBFPTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbCBFPAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbCBFPTotalAmount.Clear()
                Me.stbCBFPAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowAccountCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim accounts As DataTable
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oAccounts As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Accounts

           If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                accounts = oAccounts.GetAccounts(startDateTime, endDateTime, branchID, String.Empty).Tables("Accounts")
            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                accounts = oAccounts.GetAccounts(startDateTime, endDateTime, Nothing, loginID).Tables("Accounts")
            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                accounts = oAccounts.GetAccounts(startDateTime, endDateTime, branchID, loginID).Tables("Accounts")

            Else
                accounts = oAccounts.GetAccounts(startDateTime, endDateTime, Nothing, String.Empty).Tables("Accounts")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAccountCollections, accounts)
            FormatGridRow(Me.dgvAccountCollections)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvAccountCollections.Rows
                If row.IsNewRow Then Exit For
                Dim amountPaid As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAccountAmount)
                If amountPaid < 0 Then Me.dgvAccountCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accounts IsNot Nothing AndAlso accounts.Rows.Count > 0 Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniAccounts As EnumerableRowCollection(Of DataRow) = accounts.AsEnumerable()

                Dim totalCredit As Decimal = (From data In miniAccounts
                                              Where data.Field(Of String)("AccountAction").ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper())
                                              Select data.Field(Of Decimal)("AccountAmount")).Sum()

                Dim totalDebit As Decimal = (From data In miniAccounts
                                             Where data.Field(Of String)("AccountAction").ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper())
                                             Select data.Field(Of Decimal)("AccountAmount")).Sum()

                Dim totalBill As Decimal = (From data In miniAccounts Select data.Field(Of Decimal)("AccountAmount")).Sum()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.nbxTotalCredit.Text = FormatNumber(totalCredit, AppData.DecimalPlaces)
                Me.nbxTotalDebit.Text = FormatNumber(totalDebit, AppData.DecimalPlaces)

                Me.stbAccountTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbAccountAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.nbxTotalCredit.Clear()
                Me.nbxTotalDebit.Clear()
                Me.stbAccountTotalAmount.Clear()
                Me.stbAccountAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOtherIncomeCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim otherIncome As DataTable
        Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OtherIncome

            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, branchID, String.Empty).Tables("OtherIncome")
            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, Nothing, loginID).Tables("OtherIncome")
            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, branchID, loginID).Tables("OtherIncome")

            Else
                otherIncome = oOtherIncome.GetOtherIncome(startDateTime, endDateTime, branchID, loginID).Tables("OtherIncome")
            End If
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

    Private Sub ShowRefundsCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Dim refunds As DataTable
        Dim oRefunds As New SyncSoft.SQLDb.Refunds()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Refunds

            If oVariousOptions.EnableUseOfRefundDateForReports Then

                If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                    refunds = oRefunds.GetRefundsWithTransDate(startDateTime, endDateTime, branchID, String.Empty).Tables("Refunds")
                ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                    refunds = oRefunds.GetRefundsWithTransDate(startDateTime, endDateTime, branchID, loginID).Tables("Refunds")
                ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                    refunds = oRefunds.GetRefundsWithTransDate(startDateTime, endDateTime, Nothing, loginID).Tables("Refunds")
                Else
                    refunds = oRefunds.GetRefundsWithTransDate(startDateTime, endDateTime, Nothing, String.Empty).Tables("Refunds")
                End If
            Else

                If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                    refunds = oRefunds.GetRefunds(startDateTime, endDateTime, branchID, String.Empty).Tables("Refunds")
                ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                    refunds = oRefunds.GetRefunds(startDateTime, endDateTime, branchID, loginID).Tables("Refunds")
                ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                    refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, loginID).Tables("Refunds")
                Else
                    refunds = oRefunds.GetRefunds(startDateTime, endDateTime, Nothing, String.Empty).Tables("Refunds")
                End If


            End If

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

    Private Sub ShowExpenditureCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal loginID As String, ByVal branchID As String)

        Dim expenditure As DataTable
        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Expenditure

            If Not String.IsNullOrEmpty(branchID) AndAlso String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, branchID, String.Empty).Tables("Expenditure")

            ElseIf Not String.IsNullOrEmpty(branchID) AndAlso Not String.IsNullOrEmpty(loginID) Then
                expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, branchID, loginID).Tables("Expenditure")

            ElseIf Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(branchID) Then
                expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, Nothing, loginID).Tables("Expenditure")

            Else
                expenditure = oExpenditure.GetExpenditure(startDateTime, endDateTime, Nothing, String.Empty).Tables("Expenditure")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


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
                Me.stbExpenditureAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbExpenditureTotalAmount.Clear()
                Me.stbExpenditureAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowCurrencySummariesCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal loginID As String)

        Dim payments As DataTable
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Payments

            If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                payments = oPayments.GetCurrencySummaries(startDateTime, endDateTime).Tables("Payments")
            Else : payments = oPayments.GetCurrencySummaries(startDateTime, endDateTime, loginID).Tables("Payments")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCurrencySummariesCollections, payments)
            FormatGridRow(Me.dgvCurrencySummariesCollections)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusStyle As New DataGridViewCellStyle()

            statusStyle.BackColor = Color.MistyRose

            For Each row As DataGridViewRow In Me.dgvCurrencySummariesCollections.Rows
                If row.IsNewRow Then Exit For
                Dim localCurrencyAmount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colLocalCurrencyAmount)
                If localCurrencyAmount < 0 Then Me.dgvCurrencySummariesCollections.Rows(row.Index).DefaultCellStyle.ApplyStyle(statusStyle)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payments IsNot Nothing AndAlso payments.Rows.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim miniPayments As EnumerableRowCollection(Of DataRow) = payments.AsEnumerable()
                Dim totalBill As Decimal = (From data In miniPayments Select data.Field(Of Decimal)("LocalCurrencyAmount")).Sum()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.stbCurrencySummariesTotalAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
                Me.stbCurrencySummariesAmountWords.Text = NumberToWords(totalBill)
            Else
                Me.stbCurrencySummariesTotalAmount.Clear()
                Me.stbCurrencySummariesAmountWords.Clear()
            End If

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCahierLogins(ByVal startDateTime As Date, ByVal endDateTime As Date)

        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLoginID.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load from Payments
            Dim payments As DataTable = oPayments.GetCahierLogins(startDateTime, endDateTime).Tables("Payments")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLoginID, payments, "LoginID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowCollections(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal branchID As String, ByVal loginID As String)

        Try
            Dim message As String

            Me.Cursor = Cursors.WaitCursor

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date and Time can't be before Start Date and Time!")

            Me.ShowCashCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowBillFormCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowBPCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowCBFPCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowAccountCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowOtherIncomeCollections(startDateTime, endDateTime, loginID, branchID)
            Me.ShowRefundsCollections(startDateTime, endDateTime, loginID, branchID)
            Me.ShowExpenditureCollections(startDateTime, endDateTime, branchID, loginID)
            Me.ShowCurrencySummariesCollections(startDateTime, endDateTime, loginID)
            Me.LoadCahierLogins(startDateTime, endDateTime)

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    If Me.dgvCashCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgCashPayment.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"
                        ElseIf Not String.IsNullOrEmpty(branchID) OrElse branchID.Equals("*") Then
                            message = "No " + Me.tpgCashPayment.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgCashPayment.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvCashCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgBillFormPayment.Name

                    If Me.dgvBillFormCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgBillFormPayment.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgBillFormPayment.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvBillFormCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Bill Form Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgBillsPayment.Name

                    If Me.dgvBPCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgBillsPayment.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgBillsPayment.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvBPCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Bills Payment Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgCreditBillFormPayment.Name

                    If Me.dgvCBFPCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgCreditBillFormPayment.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgCreditBillFormPayment.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvCBFPCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Credit Bill Form Payment Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgAccounts.Name

                    If Me.dgvAccountCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgAccounts.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgAccounts.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvAccountCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Accounts Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgOtherIncome.Name

                    If Me.dgvOtherIncomeCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgOtherIncome.Text + " record(s) found for period between " +
                                      FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgOtherIncome.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvOtherIncomeCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Other Income Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgRefunds.Name

                    If Me.dgvRefundsCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgRefunds.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgRefunds.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvRefundsCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Refunds Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgExpenditure.Name

                    If Me.dgvExpenditureCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgExpenditure.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgExpenditure.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvExpenditureCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Expenditure Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgCurrencySummaries.Name

                    If Me.dgvCurrencySummariesCollections.RowCount <= 0 Then

                        If String.IsNullOrEmpty(loginID) OrElse loginID.Equals("*") Then
                            message = "No " + Me.tpgCurrencySummaries.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgCurrencySummaries.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Login ID: " + loginID + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvCurrencySummariesCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Currency Summaries Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalIncome As Decimal = DecimalMayBeEnteredIn(Me.stbCashTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbBFPTotalAmount, True) +
                                        DecimalMayBeEnteredIn(Me.stbBPTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbCBFPTotalAmount, True) +
                                        DecimalMayBeEnteredIn(Me.stbAccountTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbOtherIncomeTotalAmount, True)

            Dim totalExpenditure As Decimal = DecimalMayBeEnteredIn(Me.stbRefundsTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbExpenditureTotalAmount, True)

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
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()
                  
                Case Me.tpgBillFormPayment.Name

                    Dim rowCount As Integer = Me.dgvBillFormCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Bill Form Record(s): " + rowCount.ToString()
                   
                Case Me.tpgBillsPayment.Name

                    Dim rowCount As Integer = Me.dgvBPCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Bills Payment Record(s): " + rowCount.ToString()
                   
                Case Me.tpgCreditBillFormPayment.Name

                    Dim rowCount As Integer = Me.dgvCBFPCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Credit Bill Form Payment Record(s): " + rowCount.ToString()
                   
                Case Me.tpgAccounts.Name

                    Dim rowCount As Integer = Me.dgvAccountCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Accounts Record(s): " + rowCount.ToString()
                    
                Case Me.tpgOtherIncome.Name

                    Dim rowCount As Integer = Me.dgvOtherIncomeCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Other Income Record(s): " + rowCount.ToString()
                    
                Case Me.tpgRefunds.Name

                    Dim rowCount As Integer = Me.dgvRefundsCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Refunds Record(s): " + rowCount.ToString()
                   
                Case Me.tpgExpenditure.Name

                    Dim rowCount As Integer = Me.dgvExpenditureCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Expenditure Record(s): " + rowCount.ToString()
                    
                Case Me.tpgCurrencySummaries.Name

                    Dim rowCount As Integer = Me.dgvCurrencySummariesCollections.RowCount
                    Me.fbnExport.Enabled = rowCount > 0
                    Me.btnPrint.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = "Returned Currency Summaries Record(s): " + rowCount.ToString()
                    
                Case Else
                    Me.fbnExport.Enabled = False
                    Me.btnPrint.Enabled = False

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    ExportToExcel(Me.dgvCashCollections, Me.tpgCashPayment.Text)

                Case Me.tpgBillFormPayment.Name
                    ExportToExcel(Me.dgvBillFormCollections, Me.tpgBillFormPayment.Text)

                Case Me.tpgBillsPayment.Name
                    ExportToExcel(Me.dgvBPCollections, Me.tpgBillsPayment.Text)

                Case Me.tpgCreditBillFormPayment.Name
                    ExportToExcel(Me.dgvCBFPCollections, Me.tpgCreditBillFormPayment.Text)

                Case Me.tpgAccounts.Name
                    ExportToExcel(Me.dgvAccountCollections, Me.tpgAccounts.Text)

                Case Me.tpgOtherIncome.Name
                    ExportToExcel(Me.dgvOtherIncomeCollections, Me.tpgOtherIncome.Text)

                Case Me.tpgRefunds.Name
                    ExportToExcel(Me.dgvRefundsCollections, Me.tpgRefunds.Text)

                Case Me.tpgExpenditure.Name
                    ExportToExcel(Me.dgvExpenditureCollections, Me.tpgExpenditure.Text)

                Case Me.tpgCurrencySummaries.Name
                    ExportToExcel(Me.dgvCurrencySummariesCollections, Me.tpgCurrencySummaries.Text)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Collections Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintCollections()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintCollections()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCollectionsPrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docCollections
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True

            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docCollections.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docCollections_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCollections.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Cash Collections".ToUpper()

            Dim startDateTime As String = FormatDateTime(DateTimeMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDateTime As String = FormatDateTime(DateTimeMayBeEnteredIn(Me.dtpEndDateTime))
            Dim loginID As String = StringMayBeEnteredIn(Me.cboLoginID)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Start Record Date and Time : ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString("                             " + startDateTime, bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

                    .DrawString("End Record Date and Time   : ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString("                             " + endDateTime, bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

                    If Not String.IsNullOrEmpty(loginID) Then
                        .DrawString("Login ID                   : ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString("                             " + loginID, bodyBoldFont, Brushes.Black, xPos, yPos)
                        yPos += 2 * lineHeight
                    Else : yPos += lineHeight
                    End If

                End If

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

                If collectionParagraphs Is Nothing Then Return

                Do While collectionParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(collectionParagraphs(1), PrintParagraps)
                    collectionParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
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
                        collectionParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (collectionParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetCollectionsPrintData()

        Dim padCashTotal As Integer = 19
        Dim padBillFormTotal As Integer = 14
        Dim padBPTotal As Integer = 18
        Dim padCBFPTotal As Integer = 14
        Dim padCreditTotal As Integer = 16
        Dim padDebitTotal As Integer = 17
        Dim padAccountTotal As Integer = 18
        Dim padOtherIncomeTotal As Integer = 19
        Dim padRefundsTotal As Integer = 24
        Dim padExpenditureTotal As Integer = 20
        Dim padTotalCashCollections As Integer = 20
        Dim padTotalCashSpent As Integer = 24
        Dim padTotalAmount As Integer = 14
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        collectionParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padNo))
            tableHeader.Append("Details: ".PadRight(padDetails))
            tableHeader.Append("Total Amount: ".PadLeft(padAmount))
            tableHeader.Append("Amount Tendered: ".PadLeft(padTendered))
            tableHeader.Append("Currency: ".PadRight(padCurrency))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim cashHeader As New System.Text.StringBuilder(String.Empty)
            cashHeader.Append(Me.tpgCashPayment.Text + " (No: => Receipt No) ".PadRight(padNo))
            cashHeader.Append(ControlChars.NewLine)

            Dim cashFooter As New System.Text.StringBuilder(String.Empty)
            cashFooter.Append("Total On " + Me.tpgCashPayment.Text + ": ")
            cashFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbCashTotalAmount, True)).PadLeft(padCashTotal))
            cashFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billFormHeader As New System.Text.StringBuilder(String.Empty)
            billFormHeader.Append(ControlChars.NewLine)
            billFormHeader.Append(Me.tpgBillFormPayment.Text + " (No: => Receipt No) ".PadRight(padNo))
            billFormHeader.Append(ControlChars.NewLine)

            Dim billFormFooter As New System.Text.StringBuilder(String.Empty)
            billFormFooter.Append("Total On " + Me.tpgBillFormPayment.Text + ": ")
            billFormFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbBFPTotalAmount, True)).PadLeft(padBillFormTotal))
            billFormFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim bPHeader As New System.Text.StringBuilder(String.Empty)
            bPHeader.Append(ControlChars.NewLine)
            bPHeader.Append(Me.tpgBillsPayment.Text + " (No: => Receipt No) ".PadRight(padNo))
            bPHeader.Append(ControlChars.NewLine)

            Dim bPFooter As New System.Text.StringBuilder(String.Empty)
            bPFooter.Append("Total On " + Me.tpgBillsPayment.Text.Replace("Credit", String.Empty).Trim() + ": ")
            bPFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbBPTotalAmount, True)).PadLeft(padBPTotal))
            bPFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim cBFPHeader As New System.Text.StringBuilder(String.Empty)
            cBFPHeader.Append(ControlChars.NewLine)
            cBFPHeader.Append(Me.tpgCreditBillFormPayment.Text + " (No: => Receipt No) ".PadRight(padNo))
            cBFPHeader.Append(ControlChars.NewLine)

            Dim cBFPFooter As New System.Text.StringBuilder(String.Empty)
            cBFPFooter.Append("Total On " + Me.tpgCreditBillFormPayment.Text.Replace("Credit", String.Empty).Trim() + ": ")
            cBFPFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbCBFPTotalAmount, True)).PadLeft(padCBFPTotal))
            cBFPFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountHeader As New System.Text.StringBuilder(String.Empty)
            accountHeader.Append(ControlChars.NewLine)
            accountHeader.Append(Me.tpgAccounts.Text + " (No: => Transaction No) ".PadRight(padNo))
            accountHeader.Append(ControlChars.NewLine)

            Dim creditFooter As New System.Text.StringBuilder(String.Empty)
            creditFooter.Append("Total Credit On " + Me.tpgAccounts.Text + ": ")
            creditFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.nbxTotalCredit, True)).PadLeft(padCreditTotal))
            creditFooter.Append(ControlChars.NewLine)

            Dim debitFooter As New System.Text.StringBuilder(String.Empty)
            debitFooter.Append("Total Debit On " + Me.tpgAccounts.Text + ": ")
            debitFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.nbxTotalDebit, True)).PadLeft(padDebitTotal))
            debitFooter.Append(ControlChars.NewLine)

            Dim accountFooter As New System.Text.StringBuilder(String.Empty)
            accountFooter.Append("Net Amount On " + Me.tpgAccounts.Text + ": ")
            accountFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbAccountTotalAmount, True)).PadLeft(padAccountTotal))
            accountFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim otherIncomeHeader As New System.Text.StringBuilder(String.Empty)
            otherIncomeHeader.Append(ControlChars.NewLine)
            otherIncomeHeader.Append(Me.tpgOtherIncome.Text + " (No: => Income No) ".PadRight(padNo))
            otherIncomeHeader.Append(ControlChars.NewLine)

            Dim otherIncomeFooter As New System.Text.StringBuilder(String.Empty)
            otherIncomeFooter.Append("Total On " + Me.tpgOtherIncome.Text + ": ")
            otherIncomeFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbOtherIncomeTotalAmount, True)).PadLeft(padOtherIncomeTotal))
            otherIncomeFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim refundsHeader As New System.Text.StringBuilder(String.Empty)
            refundsHeader.Append(ControlChars.NewLine)
            refundsHeader.Append(Me.tpgRefunds.Text + " (No: => Refund No) ".PadRight(padNo))
            refundsHeader.Append(ControlChars.NewLine)

            Dim refundsFooter As New System.Text.StringBuilder(String.Empty)
            refundsFooter.Append("Total On " + Me.tpgRefunds.Text + ": ")
            refundsFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbRefundsTotalAmount, True)).PadLeft(padRefundsTotal))
            refundsFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim expenditureHeader As New System.Text.StringBuilder(String.Empty)
            expenditureHeader.Append(ControlChars.NewLine)
            expenditureHeader.Append(Me.tpgExpenditure.Text + " (No: => Expenditure No) ".PadRight(padNo))
            expenditureHeader.Append(ControlChars.NewLine)

            Dim expenditureFooter As New System.Text.StringBuilder(String.Empty)
            expenditureFooter.Append("Total On " + Me.tpgExpenditure.Text + ": ")
            expenditureFooter.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbExpenditureTotalAmount, True)).PadLeft(padExpenditureTotal))
            expenditureFooter.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim currencySummariesHeader As New System.Text.StringBuilder(String.Empty)
            currencySummariesHeader.Append(Me.tpgCurrencySummaries.Text + " ".PadRight(padNo))
            currencySummariesHeader.Append(ControlChars.NewLine)

            If Me.dgvCashCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, cashHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CashCollectionsData()))
            If Me.dgvCashCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, cashFooter.ToString()))
            End If

            If Me.dgvBillFormCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, billFormHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.BillFormCollectionsData()))
            If Me.dgvBillFormCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, billFormFooter.ToString()))
            End If

            If Me.dgvBPCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, bPHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.BPCollectionsData()))
            If Me.dgvBPCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, bPFooter.ToString()))
            End If

            If Me.dgvCBFPCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, cBFPHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CBFPCollectionsData()))
            If Me.dgvCBFPCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, cBFPFooter.ToString()))
            End If

            If Me.dgvAccountCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, accountHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.AccountCollectionsData()))
            If Me.dgvAccountCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, creditFooter.ToString()))
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, debitFooter.ToString()))
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, accountFooter.ToString()))
            End If

            If Me.dgvOtherIncomeCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, otherIncomeHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherIncomeCollectionsData()))
            If Me.dgvOtherIncomeCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, otherIncomeFooter.ToString()))
            End If

            If Me.dgvRefundsCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, refundsHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RefundsCollectionsData()))
            If Me.dgvRefundsCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, refundsFooter.ToString()))
            End If

            If Me.dgvExpenditureCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, expenditureHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ExpenditureCollectionsData()))
            If Me.dgvExpenditureCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, expenditureFooter.ToString()))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalCashCollections As Decimal = DecimalMayBeEnteredIn(Me.stbCashTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbBFPTotalAmount, True) +
                                        DecimalMayBeEnteredIn(Me.stbBPTotalAmount, True) + DecimalMayBeEnteredIn(Me.stbCBFPTotalAmount, True) +
                                        DecimalMayBeEnteredIn(Me.nbxTotalCredit, True) + DecimalMayBeEnteredIn(Me.stbOtherIncomeTotalAmount, True)

            Dim totalCashSpent As Decimal = Math.Abs(DecimalMayBeEnteredIn(Me.nbxTotalDebit, True)) + DecimalMayBeEnteredIn(Me.stbRefundsTotalAmount, True) +
                                            DecimalMayBeEnteredIn(Me.stbExpenditureTotalAmount, True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim cashCollectionsTotal As New System.Text.StringBuilder(String.Empty)
            cashCollectionsTotal.Append(ControlChars.NewLine)
            cashCollectionsTotal.Append("Total Cash Collected: ")
            cashCollectionsTotal.Append(FormatNumber(totalCashCollections).PadLeft(padTotalCashCollections))
            cashCollectionsTotal.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, cashCollectionsTotal.ToString()))

            Dim cashSpentTotal As New System.Text.StringBuilder(String.Empty)
            cashSpentTotal.Append("Total Cash Spent: ")
            cashSpentTotal.Append(FormatNumber(totalCashSpent).PadLeft(padTotalCashSpent))
            cashSpentTotal.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, cashSpentTotal.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Grand Total (Cash at Hand): ")
            totalAmount.Append(FormatNumber(DecimalMayBeEnteredIn(Me.stbGrandTotalAmount, True)).PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbGrandAmountWords)
            amountWordsData.Append("(" + amountWords.Trim() + " ONLY)")
            amountWordsData.Append(ControlChars.NewLine)
            amountWordsData.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(footerFont, amountWordsData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCurrencySummariesCollections.RowCount > 0 Then
                collectionParagraphs.Add(New PrintParagraps(bodyBoldFont, currencySummariesHeader.ToString()))
            End If
            collectionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.CurrencySummariesCollectionsData()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim cashierSignData As New System.Text.StringBuilder(String.Empty)
            cashierSignData.Append(ControlChars.NewLine)
            cashierSignData.Append("Cashier's Signature:   " + GetCharacters("."c, 20))
            cashierSignData.Append(GetSpaces(4))
            cashierSignData.Append("Date:  " + GetCharacters("."c, 20))
            cashierSignData.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(footerFont, cashierSignData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim treasurerSignData As New System.Text.StringBuilder(String.Empty)
            treasurerSignData.Append(ControlChars.NewLine)

            treasurerSignData.Append("Treasurer's Signature: " + GetCharacters("."c, 20))
            treasurerSignData.Append(GetSpaces(2))
            treasurerSignData.Append("  Date:  " + GetCharacters("."c, 20))
            treasurerSignData.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(footerFont, treasurerSignData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            collectionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function CashCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvCashCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvCashCollections.Rows(rowNo).Cells

                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colReceiptNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colFullName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colAmountPaid)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colCashAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colCashCurrency)

                tableData.Append(receiptNo.PadRight(padNo + 2))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount - 2))
                tableData.Append(tendered.PadLeft(padTendered - 1))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency - 1))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency - 1))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BillFormCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvBillFormCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvBillFormCollections.Rows(rowNo).Cells

                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colBFPReceiptNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colBFPFullName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colBFPAmountPaid)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colBFPAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colBFPCurrency)

                tableData.Append(receiptNo.PadRight(padNo + 3))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function BPCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvBPCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvBPCollections.Rows(rowNo).Cells

                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colBPReceiptNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colBPBillCustomerName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colBPAmountPaid)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colBPAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colBPCurrency)

                tableData.Append(receiptNo.PadRight(padNo + 1))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CBFPCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvCBFPCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvCBFPCollections.Rows(rowNo).Cells

                Dim receiptNo As String = StringMayBeEnteredIn(cells, Me.colCBFPReceiptNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colCBFPBillCustomerName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colCBFPAmountPaid)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colCBFPAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colCBFPCurrency)

                tableData.Append(receiptNo.PadRight(padNo))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AccountCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvAccountCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvAccountCollections.Rows(rowNo).Cells

                Dim tranNo As String = StringMayBeEnteredIn(cells, Me.colTranNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colAccountName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colAccountAmount)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colAccountAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colAccountCurrency)

                tableData.Append(tranNo.PadRight(padNo))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function OtherIncomeCollectionsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvOtherIncomeCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvOtherIncomeCollections.Rows(rowNo).Cells

                Dim incomeNo As String = StringMayBeEnteredIn(cells, Me.colIncomeNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colIncomeSource)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colOtherIncomeAmount)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colOIAmountTendered)
                Dim currency As String = StringMayBeEnteredIn(cells, Me.colOICurrency)

                tableData.Append(incomeNo.PadRight(padNo))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RefundsCollectionsData() As String

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            Dim padRefundNo As Integer = padNo + 3
            Dim padPayeeName As Integer = padDetails - 3

            For rowNo As Integer = 0 To Me.dgvRefundsCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvRefundsCollections.Rows(rowNo).Cells

                Dim refundNo As String = StringMayBeEnteredIn(cells, Me.colRefundNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colPayeeName)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colRefundsAmount)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colRefundsAmount)
                Dim currency As String = GetLookupDataDes(oCurrenciesID.UgandaShillings)

                tableData.Append(refundNo.PadRight(padRefundNo))
                If details.Length >= 15 Then
                    tableData.Append(details.Substring(0, 14).PadRight(padPayeeName))
                Else : tableData.Append(details.PadRight(padPayeeName))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ExpenditureCollectionsData() As String

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvExpenditureCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvExpenditureCollections.Rows(rowNo).Cells

                Dim expenditureNo As String = StringMayBeEnteredIn(cells, Me.colExpenditureNo)
                Dim details As String = StringMayBeEnteredIn(cells, Me.colExpenditureCategory)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colExpenditureAmount)
                Dim tendered As String = StringMayBeEnteredIn(cells, Me.colExpenditureAmount)
                Dim currency As String = GetLookupDataDes(oCurrenciesID.UgandaShillings)

                tableData.Append(ExpenditureNo.PadRight(padNo))
                If details.Length >= 18 Then
                    tableData.Append(details.Substring(0, 17).PadRight(padDetails))
                Else : tableData.Append(details.PadRight(padDetails))
                End If
                tableData.Append(amount.PadLeft(padAmount))
                tableData.Append(tendered.PadLeft(padTendered))
                If currency.Length >= 14 Then
                    tableData.Append(GetSpaces(2) + currency.Substring(0, 14).PadRight(padCurrency))
                Else : tableData.Append(GetSpaces(2) + currency.PadRight(padCurrency))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function CurrencySummariesCollectionsData() As String

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim padCurrency As Integer = padNo + padDetails

            For rowNo As Integer = 0 To Me.dgvCurrencySummariesCollections.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvCurrencySummariesCollections.Rows(rowNo).Cells

                Dim currency As String = StringMayBeEnteredIn(cells, Me.colCurrencySummariesCurrency)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colForeignCurrencyAmount)

                If currency.Length >= padCurrency Then
                    tableData.Append(currency.Substring(0, padCurrency - 1).PadRight(padCurrency))
                Else : tableData.Append(currency.PadRight(padCurrency))
                End If
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

            Next

            If Me.dgvCurrencySummariesCollections.RowCount > 0 Then

                Dim localCurrency As String = GetLookupDataDes(oCurrenciesID.UgandaShillings)
                Dim amount As Decimal = DecimalMayBeEnteredIn(Me.stbGrandTotalAmount, True) -
                                        DecimalMayBeEnteredIn(Me.stbCurrencySummariesTotalAmount, True)

                If localCurrency.Length >= padCurrency Then
                    tableData.Append(localCurrency.Substring(0, padCurrency - 1).PadRight(padCurrency))
                Else : tableData.Append(localCurrency.PadRight(padCurrency))
                End If
                tableData.Append(FormatNumber(amount, AppData.DecimalPlaces).PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)
                tableData.Append(ControlChars.NewLine)

            End If

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

    Private Sub cmsEdit_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsEdit.Opening

        Select Case Me.tbcCashCollections.SelectedTab.Name

            Case Me.tpgCashPayment.Name

                If Me.dgvCashCollections.ColumnCount < 1 OrElse Me.dgvCashCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgBillFormPayment.Name

                If Me.dgvBillFormCollections.ColumnCount < 1 OrElse Me.dgvBillFormCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgBillsPayment.Name

                If Me.dgvBPCollections.ColumnCount < 1 OrElse Me.dgvBPCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgCreditBillFormPayment.Name

                If Me.dgvCBFPCollections.ColumnCount < 1 OrElse Me.dgvCBFPCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgAccounts.Name

                If Me.dgvAccountCollections.ColumnCount < 1 OrElse Me.dgvAccountCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgOtherIncome.Name

                If Me.dgvOtherIncomeCollections.ColumnCount < 1 OrElse Me.dgvOtherIncomeCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgRefunds.Name

                If Me.dgvRefundsCollections.ColumnCount < 1 OrElse Me.dgvRefundsCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgExpenditure.Name

                If Me.dgvExpenditureCollections.ColumnCount < 1 OrElse Me.dgvExpenditureCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Me.tpgCurrencySummaries.Name

                If Me.dgvCurrencySummariesCollections.ColumnCount < 1 OrElse Me.dgvCurrencySummariesCollections.RowCount < 1 Then
                    Me.cmsEditCopy.Enabled = False
                    Me.cmsEditSelectAll.Enabled = False
                Else
                    Me.cmsEditCopy.Enabled = True
                    Me.cmsEditSelectAll.Enabled = True
                End If

            Case Else
                Me.cmsEditCopy.Enabled = True
                Me.cmsEditSelectAll.Enabled = True

        End Select

    End Sub

    Private Sub cmsEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsEditCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    If Me.dgvCashCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCashCollections))

                Case Me.tpgBillFormPayment.Name

                    If Me.dgvBillFormCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvBillFormCollections))

                Case Me.tpgBillsPayment.Name

                    If Me.dgvBPCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvBPCollections))

                Case Me.tpgCreditBillFormPayment.Name

                    If Me.dgvCBFPCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCBFPCollections))

                Case Me.tpgAccounts.Name

                    If Me.dgvAccountCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvAccountCollections))

                Case Me.tpgOtherIncome.Name

                    If Me.dgvOtherIncomeCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvOtherIncomeCollections))

                Case Me.tpgRefunds.Name

                    If Me.dgvRefundsCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvRefundsCollections))

                Case Me.tpgExpenditure.Name

                    If Me.dgvExpenditureCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvExpenditureCollections))

                Case Me.tpgCurrencySummaries.Name

                    If Me.dgvCurrencySummariesCollections.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvCurrencySummariesCollections))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsEditSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsEditSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcCashCollections.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    Me.dgvCashCollections.SelectAll()

                Case Me.tpgBillFormPayment.Name
                    Me.dgvBillFormCollections.SelectAll()

                Case Me.tpgBillsPayment.Name
                    Me.dgvBPCollections.SelectAll()

                Case Me.tpgCreditBillFormPayment.Name
                    Me.dgvCBFPCollections.SelectAll()

                Case Me.tpgAccounts.Name
                    Me.dgvAccountCollections.SelectAll()

                Case Me.tpgOtherIncome.Name
                    Me.dgvOtherIncomeCollections.SelectAll()

                Case Me.tpgRefunds.Name
                    Me.dgvRefundsCollections.SelectAll()

                Case Me.tpgExpenditure.Name
                    Me.dgvExpenditureCollections.SelectAll()

                Case Me.tpgCurrencySummaries.Name
                    Me.dgvCurrencySummariesCollections.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


 
End Class