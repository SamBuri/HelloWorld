Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
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

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmManageAccountPayments

#Region " Fields "

    Private defaultBillModesID As String = String.Empty
    Private defaultAccountNo As String = String.Empty

    Private accountReceiptSaved As Boolean = False

    Private WithEvents docAccounts As New PrintDocument()

    ' The paragraphs.
    Private cashParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private oBillModesID As New LookupDataID.BillModesID()
#End Region

#Region " Validations "

    Private Sub nbxAccountAmount_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nbxAccountAmount.Validating

        Dim errorMSG As String = "Amount can’t be more than amount tendered in local currency!"

        Try

            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate)

            If amount > (amountTendered * exchangeRate) Then
                ErrProvider.SetError(Me.nbxAccountAmount, errorMSG)
                Me.nbxAccountAmount.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.nbxAccountAmount, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region


    Private Sub frmManageAccountPayments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.MaxDate = Today

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Text = "Manage Cash Account Payments"

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InitOptions
                Me.stbAccountTranNo.ReadOnly = .TranNoLocked
            End With

            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboAccountActionID, LookupObjects.AccountAction, False)
            LoadLookupDataCombo(Me.cboAccountCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboAccountGroupID, LookupObjects.AccountGroup, False)

            Me.btnPrint.Enabled = oVariousOptions.AllowProvisionalPrinting

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultBillModesID) Then
              
                Me.stbAccountNo.ReadOnly = True
                Me.stbAccountNo.Text = FormatText(defaultAccountNo, "Suppliers", "SupplierNo")
                Me.LoadAccountDetails(defaultBillModesID, defaultAccountNo)
            Else

                Me.stbAccountNo.ReadOnly = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbAccountNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub ClearControls()
        Me.nbxAccountAmount.Clear()
        Me.ResetControls()
    End Sub

    Private Sub ResetControls()
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()

    End Sub

    Private Sub DefaultControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)

            Me.cboAccountCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

            Me.stbAccountNo.ReadOnly = False
            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.Checked = True
            Me.chkPrintReceiptOnSaving.Checked = True

            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub txtAccountNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAccountNo.TextChanged
        Me.ResetControls()
    End Sub

    Private Sub txtAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbAccountNo.Leave

        Try

            Dim accountNo As String = RevertText(StringMayBeEnteredIn(Me.stbAccountNo))

            If String.IsNullOrEmpty(accountNo) Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.LoadAccountDetails(oBillModesID.Cash, accountNo)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim accountBalance As Decimal

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()
        

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oSuppliers.GetSuppliers(accountNo).Tables("Suppliers").Rows(0)

                    Me.stbAccountNo.Text = FormatText(accountNo, "Suppliers", "SupplierNo")
                    accountName = StringMayBeEnteredIn(row, "SupplierName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
               


            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Text = accountName
            Me.nbxAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboAccountActionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountActionID.SelectedIndexChanged
        Me.NewBalance()
    End Sub

    Private Sub nbxAccountAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAccountAmount.Leave
        Me.CalculateAccountChange()
    End Sub

    Private Sub nbxAccountAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmount.TextChanged
        Me.NewBalance()
    End Sub

    Private Sub NewBalance()

        Dim oAccounts As New SyncSoft.SQLDb.Accounts()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Try

            Dim accountActionID As String = StringValueMayBeEnteredIn(Me.cboAccountActionID, "Account Action!")
            If String.IsNullOrEmpty(accountActionID) Then
                Me.nbxAccountBalance.Clear()
                Return
            End If

            Dim newBalance As Decimal
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount, False)

            If accountActionID.ToUpper().Equals(oAccountActionID.Credit.ToUpper()) Then
                newBalance = oAccounts.NewBalance(amount, 0)
            Else : newBalance = oAccounts.NewBalance(0, amount)
            End If

            Me.nbxAccountBalance.Value = FormatNumber(newBalance, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub cboAccountCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboAccountCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetAccountCurrencyControls(currenciesID)
            Me.CalculateAccountChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetAccountCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxAccountExchangeRate.Value = "1.00"
                Me.nbxAccountExchangeRate.Enabled = False
                Me.btnAccountExchangeRate.Enabled = False
                Me.nbxAccountAmount.Enabled = False
                Me.nbxAccountAmount.BackColor = SystemColors.Info

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxAccountExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxAccountExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxAccountExchangeRate.Enabled = False
                Me.btnAccountExchangeRate.Enabled = True
                Me.nbxAccountAmount.Enabled = False
                Me.nbxAccountAmount.BackColor = SystemColors.Info

            Else
                Me.nbxAccountExchangeRate.Value = String.Empty
                Me.nbxAccountExchangeRate.Enabled = True
                Me.btnAccountExchangeRate.Enabled = True
                Me.nbxAccountAmount.Enabled = True
                Me.nbxAccountAmount.BackColor = SystemColors.Window
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnAccountExchangeRate.Enabled Then Security.Apply(Me.btnAccountExchangeRate, AccessRights.All)
            Me.stbAccountChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAccountExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboAccountCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateAccountAmount()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAccountAmount.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)

            Dim amount As Decimal = amountTendered * exchangeRate
            Me.nbxAccountAmount.Text = FormatNumber(amount, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateAccountChange()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountChange.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)

            Dim change As Decimal = amountTendered * exchangeRate - amount
            Me.stbAccountChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub nbxAccountAmountTendered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmountTendered.TextChanged
        Me.CalculateAccountAmount()
    End Sub

    Private Sub nbxAccountAmountTendered_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountAmountTendered.Leave
        Me.CalculateAccountChange()
    End Sub

    Private Sub nbxAccountExchangeRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAccountExchangeRate.TextChanged
        Me.CalculateAccountAmount()
    End Sub

    Private Sub nbxAccountExchangeRate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAccountExchangeRate.Leave
        Me.CalculateAccountChange()
    End Sub

    Private Sub ResetAccountCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboAccountCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim lAccounts As New List(Of DBConnect)

            Using oAccounts As New SyncSoft.SQLDb.Accounts()

                With oAccounts

                    .TranNo = RevertText(StringEnteredIn(Me.stbAccountTranNo, "Transaction No!"))
                    .AccountBillModesID = oBillModesID.Cash
                    .AccountBillNo = RevertText(StringEnteredIn(Me.stbAccountNo, "Account No!"))
                    .ClientFullName = StringEnteredIn(Me.stbAccountName, "Account Name!")
                    .TranDate = DateEnteredIn(Me.dtpTransactionDate, "Transaction Date!")
                    .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                    .AccountActionID = StringValueEnteredIn(Me.cboAccountActionID, "Account Action!")
                    .AmountWords = NumberToWords(.Amount)
                    .CurrenciesID = StringValueEnteredIn(Me.cboAccountCurrenciesID, "Currency!")
                    .AmountTendered = DecimalEnteredIn(Me.nbxAccountAmountTendered, False, "Amount Tendered!")
                    .ExchangeRate = DecimalEnteredIn(Me.nbxAccountExchangeRate, False, "Exchange Rate!")
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .Change = DecimalEnteredIn(Me.stbAccountChange, False, "Change!")
                    .AccountGroupID = StringValueEnteredIn(Me.cboAccountGroupID, "Account Group!")
                    .DocumentNo = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                    .Notes = StringMayBeEnteredIn(Me.stbAccountNotes)
                    .EntryModeID = oEntryModeID.Manual
                    .ReferenceNo = Nothing
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccounts.Add(oAccounts)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me, ErrProvider)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountBalance, True)

                If oAccounts.AccountActionID.ToUpper().Equals(oAccountActionID.Debit.ToUpper()) Then

                    If Not oVariousOptions.AllowManualAccountDebitEntry Then
                        message = "The system is set not to allow manual account debit entry!"
                        Throw New ArgumentException(message)
                    Else
                        message = "You have decided to make a manual debit entry to this account. " +
                            ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                End If

                If oAccounts.AccountActionID.ToUpper().Equals(oAccountActionID.Debit.ToUpper()) AndAlso accountBalance < 0 Then
                    If Not oVariousOptions.AllowDirectDebitBalanceEntry Then
                        message = "The system is set not to allow direct debit balance entry!"
                        Throw New ArgumentException(message)
                    Else
                        message = "You have decided to make a direct debit that leaves this account with a debit balance. " +
                            ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If
                End If

            End Using


            transactions.Add(New TransactionList(Of DBConnect)(lAccounts, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Receipt On Saving. " +
                           ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintAccounts(True)
            Else : Me.PrintAccounts(True)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            Me.DefaultControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#Region " Accounts Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintAccounts(False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintAccounts(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.accountReceiptSaved = receiptSaved
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docAccounts
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docAccounts.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub docAccounts_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docAccounts.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            If Me.accountReceiptSaved Then
                title = AppData.ProductOwner.ToUpper() + " Account Receipt".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Account Receipt (Provisional)".ToUpper()
            End If

            With e.Graphics

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 10 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                Dim oAccountActionID As New LookupDataID.AccountActionID()

                Dim accountName As String = StringMayBeEnteredIn(Me.stbAccountName)
                Dim accountNo As String = StringMayBeEnteredIn(Me.stbAccountNo)
                Dim accountCategory As String = oBillModesID.Cash
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpTransactionDate))
                Dim payMode As String = StringMayBeEnteredIn(Me.cboPayModesID)
                Dim accountAction As String = StringMayBeEnteredIn(Me.cboAccountActionID)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                Dim balance As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountBalance, True), AppData.DecimalPlaces)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True))
                Dim notes As String = StringMayBeEnteredIn(Me.stbAccountNotes)
                Dim textLEN As Integer = 75
                Dim wordLines As Integer

                .DrawString("Account Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Account Category: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(accountCategory, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Transaction No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(transactionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Transaction Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(transactionDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Account Action: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(accountAction, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Document No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                'If DecimalMayBeEnteredIn(Me.nbxAccountBalance, True) < 0 Then
                '    .DrawString("Account Balance (DR): ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                'Else : .DrawString("Account Balance (CR): ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                'End If
                '.DrawString(balance, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                If String.IsNullOrEmpty(accountAction) Then
                    .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                    .DrawString("Amount Debited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                    .DrawString("Amount Credited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                Else : .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                End If
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                If Not String.IsNullOrEmpty(amountWords) Then
                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim oCurrenciesID As New LookupDataID.CurrenciesID()

                Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboAccountCurrenciesID, "Currency!")

                If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                    Dim currency As String = StringMayBeEnteredIn(Me.cboAccountCurrenciesID)

                    .DrawString("Amount Tendered: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(amountTenderedLocalCurrency, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                    foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                    foreignCurrencyData.Append(ControlChars.NewLine)
                    .DrawString(foreignCurrencyData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(notes) Then
                    notes = "Notes: " + notes.Trim()
                    Dim notesData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedNotesData As List(Of String) = WrapText(notes, textLEN)
                    If wrappedNotesData.Count > 1 Then
                        For pos As Integer = 0 To wrappedNotesData.Count - 1
                            notesData.Append(wrappedNotesData(pos).Trim())
                            notesData.Append(ControlChars.NewLine)
                        Next
                    Else : notesData.Append(notes)
                    End If

                    .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Me.accountReceiptSaved Then
                    Dim provisionalFooter As String = "*** Remember to return this provisional receipt for a final one ***"
                    Dim provisionalData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedProvisionalData As List(Of String) = WrapText(provisionalFooter, textLEN)

                    If wrappedProvisionalData.Count > 1 Then
                        For pos As Integer = 0 To wrappedProvisionalData.Count - 1
                            provisionalData.Append(wrappedProvisionalData(pos).Trim())
                            provisionalData.Append(ControlChars.NewLine)
                        Next
                    Else : provisionalData.Append(provisionalFooter)
                    End If

                    .DrawString(provisionalData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then

                    Dim SupplierSignData As New System.Text.StringBuilder(String.Empty)

                    SupplierSignData.Append("Suppliers's Sign:   " + GetCharacters("."c, 20))
                    SupplierSignData.Append(GetSpaces(4))
                    SupplierSignData.Append("Date:  " + GetCharacters("."c, 20))
                    .DrawString(SupplierSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim checkedSignData As New System.Text.StringBuilder(String.Empty)

                    checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                    checkedSignData.Append(GetSpaces(4))
                    checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                    .DrawString(checkedSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                    Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim footerData As New System.Text.StringBuilder(String.Empty)

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class