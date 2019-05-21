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

Public Class frmManageAccountsReversals
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

#End Region

#Region " Validations "

    Private Property currenciesID As Object

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

    Private Sub frmManageAccountsReversals_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim oVariousOptions As New VariousOptions()

        Try

            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Text = "Manage Cash Account Reversal"

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InitOptions
                Me.stbAccountTranNo.ReadOnly = .TranNoLocked
            End With

            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboAccountActionID, LookupObjects.AccountAction, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadAccounts(ByVal tranNo As String)

        Dim oAccounts As New SyncSoft.SQLDb.Accounts()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Try

            Dim accounts As DataTable = oAccounts.GetAccounts(tranNo).Tables("Accounts")
            Dim row As DataRow = accounts.Rows(0)

            Me.stbPreviousTranNo.Text = FormatText(tranNo, "Accounts", "TranNo")

            Me.stbTransactionDate.Text = FormatDate(DateEnteredIn(row, "TranDate"))
            Me.stbBillModes.Text = StringMayBeEnteredIn(row, "AccountCategory")
            Me.stbAccountNo.Text = StringMayBeEnteredIn(row, "AccountBillNo")
            Me.stbAccountName.Text = StringMayBeEnteredIn(row, "AccountName")
            Me.stbAccountPayModes.Text = StringMayBeEnteredIn(row, "PayModes")
            Me.stbAccountAction.Text = StringMayBeEnteredIn(row, "AccountAction")

            If stbAccountAction.Text.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                cboAccountActionID.SelectedValue = oAccountActionID.Debit()
            ElseIf stbAccountAction.Text.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                cboAccountActionID.SelectedValue = oAccountActionID.Credit()
            End If
            Me.stbAccountCurrency.Text = StringMayBeEnteredIn(row, "Currency")
            Me.nbxAccountAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxAccountExchangeRate.Value = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.nbxAccountAmount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
            Me.stbAccountChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.nbxAccountBalance.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Balance"), AppData.DecimalPlaces)
            Me.stbAccountDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbAccountGroup.Text = StringMayBeEnteredIn(row, "AccountGroup")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ClearManageAccountsControls()

        Me.stbTransactionDate.Clear()
        Me.stbBillModes.Clear()
        Me.stbAccountNo.Clear()
        Me.stbAccountName.Clear()
        Me.stbAccountPayModes.Clear()
        Me.stbAccountAction.Clear()
        Me.stbAccountCurrency.Clear()
        Me.nbxAccountAmountTendered.Value = String.Empty
        Me.nbxAccountExchangeRate.Value = String.Empty
        Me.nbxAccountAmount.Value = String.Empty
        Me.stbAccountChange.Clear()
        Me.stbAccountDocumentNo.Clear()
        Me.stbAccountNotes.Clear()
        Me.nbxAccountBalance.Value = String.Empty
    End Sub

    Private Sub ShowAccountsData()

        Try

            Dim transactionNo As String = RevertText(StringMayBeEnteredIn(Me.stbPreviousTranNo))
            If String.IsNullOrEmpty(transactionNo) Then Return

            Me.ClearManageAccountsControls()
            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")
            Me.LoadAccounts(transactionNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbPreviousTranNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPreviousTranNo.TextChanged
        Me.ClearManageAccountsControls()
    End Sub

    Private Sub stbPreviousTranNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPreviousTranNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowAccountsData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbPreviousTranNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbPreviousTranNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim lAccountsEXT As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim lAccounts As New List(Of DBConnect)

            Using oAccounts As New SyncSoft.SQLDb.Accounts()

                With oAccounts

                    .TranNo = RevertText(StringEnteredIn(Me.stbAccountTranNo, "Transaction No!"))
                    .AccountBillModesID = GetLookupDataID(LookupObjects.BillModes, Me.stbBillModes.Text)
                    .AccountBillNo = RevertText(StringEnteredIn(Me.stbAccountNo, "Account No!"))
                    .ClientFullName = StringEnteredIn(Me.stbAccountName, "Account Name!")
                    .TranDate = DateEnteredIn(Me.stbTransactionDate, "Transaction Date!")
                    .PayModesID = GetLookupDataID(LookupObjects.PayModes, Me.stbAccountPayModes.Text)
                    .AccountActionID = StringValueEnteredIn(Me.cboAccountActionID, "Account Action!")
                    .AmountWords = NumberToWords(.Amount)
                    .CurrenciesID = GetLookupDataID(LookupObjects.Currencies, Me.stbAccountCurrency.Text)
                    .AmountTendered = DecimalEnteredIn(Me.nbxAccountAmountTendered, False, "Amount Tendered!")
                    .ExchangeRate = DecimalEnteredIn(Me.nbxAccountExchangeRate, False, "Exchange Rate!")
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .Change = DecimalEnteredIn(Me.stbAccountChange, False, "Change!")
                    .AccountGroupID = GetLookupDataID(LookupObjects.AccountGroup, stbAccountGroup.Text)
                    .DocumentNo = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                    .Notes = StringEnteredIn(Me.stbAccountNotes, "Notes!")
                    .EntryModeID = oEntryModeID.Manual
                    .ReferenceNo = Nothing
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccounts.Add(oAccounts)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me, ErrProvider)



            End Using

            Using oAccountsEXT As New SyncSoft.SQLDb.AccountsEXT()

                With oAccountsEXT

                    .TranNo = RevertText(StringEnteredIn(Me.stbAccountTranNo, "TranNo!"))
                    .ReferenceNo = RevertText(StringEnteredIn(Me.stbPreviousTranNo, "Previous TransactionNo!"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccountsEXT.Add(oAccountsEXT)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountBalance, True)
            Dim accountamount As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmount, True)

            If accountBalance < accountamount Then
                Dim message As String = "The System doesn't allow you to Reverse a transaction whose Account Balance is less than the Transaction Amount. "
                Throw New ArgumentException(message)
            End If


            transactions.Add(New TransactionList(Of DBConnect)(lAccounts, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lAccountsEXT, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintReceiptOnSaving.Checked Then
                Dim message As String = "You have not checked Print Receipt On Saving. " +
                           ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintAccounts(True)
            Else : Me.PrintAccounts(True)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadManageAccounts_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadManageAccounts.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fAccountsReceipts As New frmAccountsReceipts(Me.stbPreviousTranNo)
            fAccountsReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAccountsData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                Dim accountCategory As String = StringMayBeEnteredIn(Me.stbBillModes)
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = StringMayBeEnteredIn(Me.stbTransactionDate)
                Dim payMode As String = StringMayBeEnteredIn(Me.stbAccountPayModes)
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

                Dim currenciesID As String = GetLookupDataID(LookupObjects.Currencies, Me.stbAccountCurrency.Text)
                If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                    Dim currency As String = StringMayBeEnteredIn(Me.stbAccountCurrency)

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

                    Dim patientSignData As New System.Text.StringBuilder(String.Empty)

                    patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
                    patientSignData.Append(GetSpaces(4))
                    patientSignData.Append("Date:  " + GetCharacters("."c, 20))
                    .DrawString(patientSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
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