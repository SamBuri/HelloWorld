
Option Strict On
Option Infer On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPaymentVouchers

#Region " Fields "

    Private VoucherNoPrefix As String = Today.Year.ToString().Substring(2)
    Private oVoucherTypeID As New LookupDataID.VoucherTypeID()
    Private bankNameID As String
    Private bankAccountNo As String
    Private oCurrenciesID As New LookupDataID.CurrenciesID
    Private oCollectionSourceTyPeID As New LookupDataID.CollectionSourceTypeID
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Dim oBillModesID As New LookupDataID.BillModesID()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()


    Private tipSPOutstandingBalanceWords As New ToolTip()
    Private tipSPCashAccountBalanceWords As New ToolTip()

    Private accountReceiptSaved As Boolean = False
    Private WithEvents docAccounts As New PrintDocument()

    Private WithEvents docCashReceipt As New PrintDocument()
    Private cashReceiptSaved As Boolean = False
    ' The paragraphs.
    Private cashParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)


    Private WithEvents docSPCashReceipt As New PrintDocument()
    Private cashSPReceiptSaved As Boolean = False

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

    Private Sub frmPaymentVouchers_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.MaxDate = Today

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With InitOptions
                Me.stbAccountTranNo.ReadOnly = .TranNoLocked
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboServicePaymentPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboServicePaymentCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboModeOfPaymentID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboAccountActionID, LookupObjects.AccountAction, False)
            LoadLookupDataCombo(Me.cboAccountCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboAccountGroupID, LookupObjects.AccountGroup, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextVoucherNo(Me.stbVoucherNo)
            Me.SetNextVoucherNo(Me.stbServiceVoucherNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub stbGRNNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbGRNNo.TextChanged
        'Me.ClearCashPaymentControls()
    End Sub


    Private Sub stbGRNNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbGRNNo.Leave
        Try

            Me.Cursor = Cursors.WaitCursor


            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbGRNNo))
            Me.ShowGoodsReceivedNote(_GRNNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnLoadPendingCashPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPendingCashPayment.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicGoodsReceivedNote As New frmNotPaidGRNs(Me.stbGRNNo)
            fPeriodicGoodsReceivedNote.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbGRNNo))
            Me.ShowGoodsReceivedNote(_GRNNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub cboCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetCashCurrencyControls(currenciesID)
            Me.CalculateCashChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetCashCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxExchangeRate.Value = "1.00"
                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = False



            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)

                    Me.nbxExchangeRate.Value = exchangeRate.ToString()

                End If
                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = True


            Else
                Me.nbxExchangeRate.Value = String.Empty
                Me.nbxExchangeRate.Enabled = True
                Me.btnExchangeRate.Enabled = True


            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnExchangeRate.Enabled Then Security.Apply(Me.btnExchangeRate, AccessRights.All)
            Me.stbChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetExCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then


                Me.nbxExchangeRate.Value = "1.00"
                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else
                    Me.nbxExchangeRate.Value = exchangeRate.ToString()
                End If


                Me.nbxExchangeRate.Enabled = False
                Me.btnExchangeRate.Enabled = True

            Else


                Me.nbxExchangeRate.Value = String.Empty
                Me.nbxExchangeRate.Enabled = True
                Me.btnExchangeRate.Enabled = True
            End If


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateCashAmountTendered()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAmountTendered.Value = String.Empty
            Me.ResetCashCurrencyControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                amountTendered = totalBill - accountBalance

            ElseIf Me.chkUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                amountTendered = 0

            Else : amountTendered = totalBill
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateCashChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbChange.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim change As Decimal

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub AmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxAmountTendered.Leave, nbxAmountTendered.TextChanged
        Me.CalculateCashChange()
    End Sub

    Private Sub ExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxExchangeRate.Leave, nbxExchangeRate.TextChanged
        Me.CalculateCashChange()
    End Sub

    Private Sub ResetCashCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub

    'next 

    Private Sub stbReceiptNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVoucherNo.Enter
        Me.SetNextVoucherNo(Me.stbVoucherNo)
    End Sub


    Private Sub btnExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)

            If Me.chkUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateCashAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateCashChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub SetNextVoucherNo(ByVal sourceControl As TextBox)

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPayments As New SyncSoft.SQLDb.PaymentVouchers()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("PaymentVouchers", "VoucherNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextVoucherNo As String = CStr(oPayments.GetNextVoucherID).PadLeft(paddingLEN, paddingCHAR)

            Dim VoucherNo As String = ((VoucherNoPrefix + nextVoucherNo).Trim())
            sourceControl.Text = FormatText(VoucherNo, "PaymentVouchers", "VoucherNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowGoodsReceivedNote(_GRNNo As String)

        Dim oGoodsReceivedNote As New SyncSoft.SQLDb.GoodsReceivedNote()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearCashPaymentControls()

            Me.SetNextVoucherNo(Me.stbVoucherNo)

            If String.IsNullOrEmpty(_GRNNo) Then Return

            Dim goodsReceivedNote As DataTable = oGoodsReceivedNote.GetGoodsReceivedNote(_GRNNo).Tables("GoodsReceivedNote")
            Dim row As DataRow = goodsReceivedNote.Rows(0)


            Me.stbGRNNo.Text = FormatText(_GRNNo, "GoodsReceivedNote", "GRNNo")
            Me.stbReceivedDate.Text = FormatDate(DateMayBeEnteredIn(row, "ReceivedDate"))
            Me.stbSupplierNo.Text = StringMayBeEnteredIn(row, "supplierNo")
            Me.stbSupplierName.Text = StringMayBeEnteredIn(row, "SupplierName")
            Me.stbTotalAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "NotPaidAmount"), AppData.DecimalPlaces)
            Me.nbxAmountTendered.Text = FormatNumber(DecimalMayBeEnteredIn(row, "NotPaidAmount"), AppData.DecimalPlaces)

            Dim amountInWords As Decimal = DecimalMayBeEnteredIn(row, "NotPaidAmount")
            Me.stbAmountWords.Text = NumberToWords(amountInWords)



            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(row, "CashAccountBalance")
            Me.nbxCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(cashAccountBalance))

            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadGoodsReceivedNoteDetails(_GRNNo)



        Catch eX As Exception
            Me.ClearCashPaymentControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadGoodsReceivedNoteDetails(ByVal _GRNNo As String)

        Dim oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()

        Try

            Me.dgvPaymentDetails.Rows.Clear()

            Dim goodsReceivedNoteDetails As DataTable = oGoodsReceivedNoteDetails.GetUnpaidGoodsReceivedNoteDetails(_GRNNo).Tables("GoodsReceivedNoteDetails")
            If goodsReceivedNoteDetails Is Nothing OrElse goodsReceivedNoteDetails.Rows.Count < 1 Then
                DisplayMessage("No goods received note details to view!")
                Return
            End If
     
   
            LoadGridData(Me.dgvPaymentDetails, goodsReceivedNoteDetails)

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For

                Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value = True

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function GetBankingRegisterList(registerNo As String, collectionSourceType As String, amountCollected As Decimal,
                                        payCurrency As String, exchangeRate As Decimal, bankDate As Date) As List(Of DBConnect)
        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID

        Dim lBankingRegister As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oBankAccount As New BankAccounts()

            Dim bankAccount As DataTable = oBankAccount.GetBankAccounts(Me.bankAccountNo).Tables("BankAccounts")
            Dim row As DataRow = bankAccount.Rows(0)

            Dim currencyID As String = StringEnteredIn(row, "CurrencyID")
            Dim accountName As String = StringEnteredIn(row, "AccountName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If currencyID.ToUpper.Equals(oCurrenciesID.UgandaShillings) Then
                exchangeRate = 1
            Else
                exchangeRate = GetExchangeRateBuying(currencyID)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            With oBankingRegister

                .RegisterNo = registerNo
                .CollectionStartDate = Today
                .CollectionEndDate = Now
                .BankingDate = bankDate
                .CollectionSourCeTypeID = collectionSourceType
                .BankNameID = bankNameID
                .AccountName = accountName
                .AccountNo = Me.bankAccountNo
                .AmountCollected = amountCollected
                .AmountBanked = Me.CalculateAccountAmount(payCurrency, amountCollected, currencyID)
                .AmountInWords = NumberToWords(amountCollected)
                .CurrencyID = currencyID

                .ExchangeRate = exchangeRate
                If (.AmountCollected < .AmountBanked * exchangeRate) Then
                    DisplayMessage("Amount banked cannot be greater than amount collected")

                End If
                .BankedBy = CurrentUser.LoginID
                .LoginID = CurrentUser.LoginID

                .RecordDateTime = Now()

            End With

            lBankingRegister.Add(oBankingRegister)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
        Return lBankingRegister
    End Function


    Private Function GetBankingDetailList(registerNo As String, amountBanked As Decimal, payModesID As String, documentNo As String) As List(Of DBConnect)

        Dim lBankingRegisterDetails As New List(Of DBConnect)

        Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

            With oBankingRegisterDetails

                .RegisterNo = registerNo
                .Amount = amountBanked
                .CollectionModesID = payModesID
                .BankModesID = payModesID
                .DocumentNo = documentNo
                .LoginID = CurrentUser.LoginID
                .RecordDateTime = Now()


            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lBankingRegisterDetails.Add(oBankingRegisterDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        End Using

        Return lBankingRegisterDetails

    End Function


    Private Function CalculateAccountAmount(paymentCurrencyID As String, amountBanked As Decimal, accountCurrencyID As String) As Decimal

        Dim bankedinAccountCurrency As Decimal
        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If accountCurrencyID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                bankedinAccountCurrency = amountBanked
            Else
                Dim exchangeRate As Decimal = GetExchangeRateBuying(accountCurrencyID)
                bankedinAccountCurrency = amountBanked / exchangeRate
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        Return bankedinAccountCurrency

    End Function

    Private Function GetNextRegisterNo() As String
        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Dim registerNo As String = String.Empty
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBankingRegister As New BankingRegister()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BankingRegister", "RegisterNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextRegisterID As String = oBankingRegister.GetNextRegisterID().ToString().PadLeft(paddingLEN, paddingCHAR)

            registerNo = FormatText(yearL2 + nextRegisterID.Trim(), "BankingRegister", "RegisterNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
        Return registerNo
    End Function

    Private Function GetBankingDetails(receiptNo As String, documentNo As String, payModeID As String) As List(Of DBConnect)
        Dim lBankPaymentDetails As New List(Of DBConnect)
        Dim oBankPaymentDetails As New BankPaymentDetails()
        With oBankPaymentDetails

            .ReceiptNo = receiptNo
            .BankNamesID = Me.bankNameID
            .AccountNo = Me.bankAccountNo
            .DocumentNo = documentNo
            .PayModesID = payModeID

            .RecordDateTime = Now()
            .LoginID = CurrentUser.LoginID

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End With
        lBankPaymentDetails.Add(oBankPaymentDetails)
        Return lBankPaymentDetails
    End Function



    Private Sub SupplierPayments()

        Dim message As String
        Dim lPaymentVouchers As New List(Of DBConnect)
        Dim lPaymentVoucherDetails As New List(Of DBConnect)
        Dim lGRNNO As New List(Of DBConnect)
        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Try
            Dim oEntryModeID As New LookupDataID.EntryModeID()
            Dim oPayModesID As New LookupDataID.PayModesID()
            Dim oPaymentVouchers As New SyncSoft.SQLDb.PaymentVouchers()
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxExchangeRate.GetDecimal(False)
            Dim voucherNo As String = RevertText(StringEnteredIn(Me.stbVoucherNo, "VoucherNo!"))
            Dim payDate As Date = DateEnteredIn(Me.dtpPayDate, "Pay Date!")
            Dim supplierNo As String = StringEnteredIn(Me.stbSupplierNo, "Supplier No!")
            Dim accountBalance As Decimal = GetAccountBalance(oBillModesID.Cash, supplierNo)
            Me.ResetCashAccountBalanceCTRL(accountBalance)
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvPaymentDetails.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue.\n Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(voucherNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPeID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPaymentVouchers

                .VoucherNo = voucherNo
                .PayTypeID = payMode
                .BillNo = StringEnteredIn(Me.stbGRNNo, "Invoice No!")
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "PayModesID!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                .AmountWords = StringEnteredIn(Me.stbAmountWords, "AmountWords!")
                .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                .CurrenciesID = StringValueEnteredIn(Me.cboCurrenciesID, "CurrenciesID!")
                .AmountTendered = Me.nbxAmountTendered.GetDecimal(False)
                .ExchangeRate = Me.nbxExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkUseAccountBalance.Checked
                .VoucherTypeID = oVoucherTypeID.SupplierPayments
                .PayNo = RevertText(StringEnteredIn(Me.stbInvoiceNo))
                .FilterNo = RevertText(StringEnteredIn(Me.stbSupplierNo, "Supplier No!"))
                .Payee = StringEnteredIn(Me.stbSupplierName, "Payee!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgMedicalSupplierPayment)
                lPaymentVouchers.Add(oPaymentVouchers)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With


            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)

                    Using oPaymentVoucherDetails As New SyncSoft.SQLDb.PaymentVoucherDetails()

                        With oPaymentVoucherDetails

                            .VoucherNo = voucherNo
                            .BillNo = StringEnteredIn(Me.stbGRNNo, "Invoice No!")
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = IntegerEnteredIn(cells, Me.colQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colUnitCost, False, "amount!")
                            .Discount = DecimalEnteredIn(cells, Me.colDiscount, True, "discount!")
                            .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(tpgMedicalSupplierPayment)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With

                        lPaymentVoucherDetails.Add(oPaymentVoucherDetails)
                    End Using


                    Using oItems As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()
                        With oItems
                            .GRNNo = StringEnteredIn(Me.stbGRNNo, "GRN No!")
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .PaystatusID = oPayStatusID.PaidFor

                        End With
                        lGRNNO.Add(oItems)
                    End Using

                End If
            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgMedicalSupplierPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentVouchers, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentVoucherDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lGRNNO, Action.Update))



            If change < 0 AndAlso Not Me.chkSendBalanceToAccount.Checked Then

                Me.nbxAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use what’s on the your account? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from the Supplier's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from the Supplier's account that will eventually be debited by " +
                    FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = RevertText(StringEnteredIn(Me.stbSupplierNo))
                        .ClientFullName = StringEnteredIn(Me.stbSupplierName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.SupplierPayment
                        .Notes = "Payment under Voucher no: " + voucherNo
                        .EntryModeID = oEntryModeID.System
                        .ReferenceNo = RevertText(StringEnteredIn(Me.stbGRNNo))
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    message = "You have chosen to send balance to the Supplier's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"


                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to the Supplier's account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .ClientFullName = StringEnteredIn(Me.stbSupplierName)
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = RevertText(StringEnteredIn(Me.stbSupplierNo))
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under Voucher no: " + voucherNo
                        .ReferenceNo = voucherNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkUseAccountBalance.Checked AndAlso Not Me.chkSendBalanceToAccount.Checked Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbTotalAmountPaid.Text + ", Voucher No: " + Me.stbVoucherNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            DoTransactions(transactions)

            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Voucher On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintCashReceipt(True)
            Else : Me.PrintCashReceipt(True)
            End If
            Me.ClearCashPaymentControls()
            SetNextVoucherNo(Me.stbVoucherNo)

        Catch ex As Exception

            If ex.Message.Contains("The VoucherNo :") Then
                message = "The Voucher No: " + Me.stbVoucherNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine +
                    "If you are using the system generated number, probably another person has already taken it." + ControlChars.NewLine +
                    "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextVoucherNo(Me.stbVoucherNo)
            End If

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ResetCashAccountBalanceCTRL(cashAccountBalance As Decimal)

        Try

            If Not cashAccountBalance = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True) Then

                Me.nbxCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
                Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(cashAccountBalance))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkUseAccountBalance.Checked AndAlso cashAccountBalance <= 0 Then
                    Me.ResetUseAccountBalanceCTRL(cashAccountBalance)
                Else : Me.CalculateCashChange()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ResetUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                    " can’t be used to offset this bill"

            Me.chkUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(sender As System.Object, e As System.EventArgs) Handles ebnSaveUpdate.Click
 Select Me.tbcCashier.SelectedTab.Name

            Case Me.tpgMedicalSupplierPayment.Name
                Me.btnManageAccounts.Visible = True
                Me.SupplierPayments()


            Case Me.tpgNonMedicalSupplierPayment.Name
                Me.SPSupplierPayments()
                Me.btnManageAccounts.Visible = True

            Case Me.tpgSupplierAccounts.Name
                Me.btnManageAccounts.Visible = False
                Me.SaveAccounts()

        End Select

    End Sub

    Private Sub ClearCashPaymentControls()

        Me.stbSupplierName.Clear()
        Me.stbSupplierNo.Clear()
        Me.stbReceivedDate.Clear()
        Me.stbVoucherNo.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.tipCashAccountBalanceWords.RemoveAll()
        Me.nbxCashAccountBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        ErrProvider.SetError(Me.nbxCashAccountBalance, String.Empty)
        Me.stbGRNNo.Clear()
        Me.stbInvoiceNo.Clear()
        Me.dtpPayDate.Value = Today
        Me.dtpPayDate.Checked = False
        Me.stbDocumentNo.Clear()
        Me.stbNotes.Clear()
        Me.stbTotalAmountPaid.Clear()
        Me.stbAmountWords.Clear()
        Me.nbxAmountTendered.Value = String.Empty
        Me.chkUseAccountBalance.Checked = False
        Me.chkSendBalanceToAccount.Checked = False

        '  Me.btnManageAccounts.Enabled = False
        Me.dgvPaymentDetails.Rows.Clear()

        Me.ResetCashCurrencyControls()

    End Sub


    Private Sub ClearSPCashPaymentControls()

        Me.stbSPSupplierName.Clear()
        Me.stbSPSupplierNo.Clear()
        Me.stbSPReceivedDate.Clear()
        Me.stbServiceVoucherNo.Clear()
        Me.nbxSPOutstandingBalance.Value = String.Empty
        Me.tipSPOutstandingBalanceWords.RemoveAll()
        Me.tipSPCashAccountBalanceWords.RemoveAll()
        Me.nbxSPCashAccountBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxSPOutstandingBalance, String.Empty)
        ErrProvider.SetError(Me.nbxSPCashAccountBalance, String.Empty)
        Me.stbSeviceInvoiceNo.Clear()
        Me.stbSPBillNo.Clear()
        Me.dtpSPPayDate.Value = Today
        Me.dtpSPPayDate.Checked = False
        Me.stbSPDocumentNo.Clear()
        Me.stbSPNotes.Clear()
        Me.stbSPTotalAmountPaid.Clear()
        Me.stbSPAmountWords.Clear()
        Me.nbxSPAmountTendered.Value = String.Empty
        Me.chkSPUseAccountBalance.Checked = False
        Me.chkSPSendBalanceToAccount.Checked = False

        'Me.btnManageAccounts.Enabled = False
        Me.dgvServiceInvoices.Rows.Clear()

        Me.ResetSPCashCurrencyControls()

    End Sub


    Private Sub dgvPaymentDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentDetails.CellEndEdit

        If e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colUnitCost.Index) OrElse
            e.ColumnIndex.Equals(Me.colDiscount.Index) Then

            Me.CalculateCashTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.colInclude.Index) Then
            Me.CalculateCashTotalBill()
        End If

    End Sub

    Private Sub cmsPaymentsIncludeAll_Click(sender As System.Object, e As System.EventArgs) Handles cmsPaymentsIncludeAll.Click

        For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
            If row.IsNewRow Then Exit For

            Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value = True

        Next
    End Sub

    Private Sub cmsPaymentsIncludeNone_Click(sender As System.Object, e As System.EventArgs) Handles cmsPaymentsIncludeNone.Click
        For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows

           
                Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value = False

        Next
        Me.CalculateCashTotalBill()
    End Sub


    Private Sub CalculateCashTotalBill()

        Dim totalBill As Decimal

        Me.stbTotalAmountPaid.Clear()
        Me.nbxAmountTendered.Value = String.Empty
        Me.chkUseAccountBalance.Checked = False
        Me.chkSendBalanceToAccount.Checked = False
        Me.ResetCashCurrencyControls()

        For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1
            If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                totalBill += amount
            End If
        Next

        Me.stbTotalAmountPaid.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalBill)
        Me.nbxAmountTendered.Value = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateCashChange()

    End Sub

#Region " Cashier Printing "

    Private Sub PrintCashReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cashReceiptSaved = receiptSaved
                    Me.SetCashPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docCashReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCashReceipt.Print()



        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docCashReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCashReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Cash Payment".ToUpper()



            Dim fromName As String = StringMayBeEnteredIn(Me.stbSupplierName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbVoucherNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbInvoiceNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpPayDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbReceivedDate)
            Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)
            Dim docNo As String = StringMayBeEnteredIn(Me.stbDocumentNo)
            Dim textLEN As Integer = 75

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Paid To: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Voucher No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Received Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        If Not String.IsNullOrEmpty(docNo) Then

                            .DrawString("Document No:", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(docNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
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

                If cashParagraphs Is Nothing Then Return

                Do While cashParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(cashParagraphs(1), PrintParagraps)
                    cashParagraphs.Remove(1)

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
                        cashParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (cashParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetCashPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 12
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 56
        Dim padAmountTendered As Integer = 53
        Dim padAccountBalance As Integer = 43
        Dim padChange As Integer = 40

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        cashParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.HideCashPaymentReceiptDetails Then
                ' Header goes here!

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padCategoryName))
                tableHeader.Append("Amount: ".PadLeft(padCategoryAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetails = From data In Me.GetPaymentDetailsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentDetails

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padCategoryName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padCategoryAmount + 26))

                    tableData.Append(ControlChars.NewLine)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Cost: ".PadLeft(padUnitPrice))
                tableHeader.Append("Discount: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                    If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitCost.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()

                        tableData.Append(itemNo.PadRight(padItemNo))
                        If itemName.Length > 20 Then
                            tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                        Else : tableData.Append(itemName.PadRight(padItemName))
                        End If
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(discount.PadLeft(padDiscount))
                        tableData.Append(amount.PadLeft(padAmount))

                        tableData.Append(ControlChars.NewLine)

                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim changeAmount As New System.Text.StringBuilder(String.Empty)

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            Dim totalChange As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            totalAmount.Append(ControlChars.NewLine)

          
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))



            totalAmount.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            If totalChange > 0 Then
                changeAmount.Append(ControlChars.NewLine)
                changeAmount.Append("Change: ")
                changeAmount.Append(FormatNumber(totalChange, AppData.DecimalPlaces).PadLeft(padTotalAmount + 6))

                changeAmount.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, changeAmount.ToString()))
            End If

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkUseAccountBalance.Checked OrElse (Me.chkSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If

            

         
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetPaymentDetailsItemTotalsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                If CBool(Me.dgvPaymentDetails.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(itemName, amount))

                End If
            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region




    Private Sub btnLoadPendingCashServicesPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPendingCashServicesPayment.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicGoodsReceivedNote As New frmNotPaidServiceInvoices(Me.stbSeviceInvoiceNo)
            fPeriodicGoodsReceivedNote.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbSeviceInvoiceNo))
            Me.ShowServiceDetails(_GRNNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowServiceDetails(_GRNNo As String)

        Dim oServiceInvoices As New SyncSoft.SQLDb.ServiceInvoices()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearSPCashPaymentControls()

            Me.SetNextVoucherNo(Me.stbServiceVoucherNo)

            If String.IsNullOrEmpty(_GRNNo) Then Return

            Dim serviceInvoices As DataTable = oServiceInvoices.GetServiceInvoices(_GRNNo).Tables("ServiceInvoices")
            Dim row As DataRow = serviceInvoices.Rows(0)


            Me.stbSeviceInvoiceNo.Text = FormatText(_GRNNo, "ServiceInvoices", "ServiceInvoiceNo")
            Me.stbSPBillNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbSPReceivedDate.Text = FormatDate(DateMayBeEnteredIn(row, "ReceivedDate"))
            Me.stbSPSupplierNo.Text = StringMayBeEnteredIn(row, "supplierNo")
            Me.stbSPSupplierName.Text = StringMayBeEnteredIn(row, "SupplierName")
            Me.stbSPTotalAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "NotPaidAmount"), AppData.DecimalPlaces)
            Me.nbxSPAmountTendered.Text = FormatNumber(DecimalMayBeEnteredIn(row, "NotPaidAmount"), AppData.DecimalPlaces)

            Dim amountInWords As Decimal = DecimalMayBeEnteredIn(row, "NotPaidAmount")
            Me.stbSPAmountWords.Text = NumberToWords(amountInWords)



            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(row, "CashAccountBalance")
            Me.nbxSPCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
            Me.tipSPCashAccountBalanceWords.SetToolTip(Me.nbxSPCashAccountBalance, NumberToWords(cashAccountBalance))

            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxSPOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipSPOutstandingBalanceWords.SetToolTip(Me.nbxSPOutstandingBalance, NumberToWords(outstandingBalance))

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadServiceInvoices(_GRNNo)



        Catch eX As Exception
            Me.ClearSPCashPaymentControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServiceInvoices(ByVal _GRNNo As String)

        Dim oServiceInvoiceDetails As New SyncSoft.SQLDb.ServiceInvoices()

        Try

            Me.dgvServiceInvoices.Rows.Clear()

            Dim ServiceInvoiceDetails As DataTable = oServiceInvoiceDetails.GetNotPaidServiceInvoiceDetails(_GRNNo).Tables("ServiceInvoices")
            If ServiceInvoiceDetails Is Nothing OrElse ServiceInvoiceDetails.Rows.Count < 1 Then
                DisplayMessage("No Service details to view!")
                Return
            End If


            LoadGridData(Me.dgvServiceInvoices, ServiceInvoiceDetails)

            For Each row As DataGridViewRow In Me.dgvServiceInvoices.Rows
                If row.IsNewRow Then Exit For

                Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, row.Index).Value = True

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub stbServiceVoucherNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbServiceVoucherNo.Enter
        Me.SetNextVoucherNo(Me.stbServiceVoucherNo)
    End Sub

    Private Sub cboServicePaymentCurrenciesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServicePaymentCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboServicePaymentCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetSPCashCurrencyControls(currenciesID)
            Me.CalculateSPCashChange()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvServiceInvoices_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServiceInvoices.CellEndEdit

        If e.ColumnIndex.Equals(Me.ColSPReceivedQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.ColSPRate.Index) OrElse
           e.ColumnIndex.Equals(Me.colSPDiscount.Index) Then


            Me.CalculateSPCashTotalBill()

        ElseIf e.ColumnIndex.Equals(Me.ColSPInclude.Index) Then
            Me.CalculateSPCashTotalBill()
        End If

    End Sub

    Private Sub SetSPCashCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxSPExchangeRate.Value = "1.00"
                Me.nbxSPExchangeRate.Enabled = False
                Me.btnServicePaymentExchangeRate.Enabled = False



            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxSPExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)

                    Me.nbxSPExchangeRate.Value = exchangeRate.ToString()

                End If
                Me.nbxSPExchangeRate.Enabled = False
                Me.btnServicePaymentExchangeRate.Enabled = True


            Else
                Me.nbxSPExchangeRate.Value = String.Empty
                Me.nbxSPExchangeRate.Enabled = True
                Me.btnServicePaymentExchangeRate.Enabled = True


            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.btnServicePaymentExchangeRate.Enabled Then Security.Apply(Me.btnServicePaymentExchangeRate, AccessRights.All)
            Me.stbSPChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetSPExCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then


                Me.nbxSPExchangeRate.Value = "1.00"
                Me.nbxSPExchangeRate.Enabled = False
                Me.btnServicePaymentExchangeRate.Enabled = False

            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxSPExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else
                    Me.nbxSPExchangeRate.Value = exchangeRate.ToString()
                End If


                Me.nbxSPExchangeRate.Enabled = False
                Me.nbxSPExchangeRate.Enabled = True

            Else


                Me.nbxSPExchangeRate.Value = String.Empty
                Me.nbxSPExchangeRate.Enabled = True
                Me.btnServicePaymentExchangeRate.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateSPCashAmountTendered()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxSPAmountTendered.Value = String.Empty
            Me.ResetCashCurrencyControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbSPAmountWords, True)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxSPCashAccountBalance, True)
            Dim amountTendered As Decimal

            If Me.chkSPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                amountTendered = totalBill - accountBalance

            ElseIf Me.chkSPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                amountTendered = 0

            Else : amountTendered = totalBill
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxSPAmountTendered.Value = FormatNumber(amountTendered, AppData.DecimalPlaces)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateSPCashChange()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSPChange.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbSPTotalAmountPaid, True)
            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxSPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxSPExchangeRate, False)
            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxSPCashAccountBalance, True)
            Dim change As Decimal

            If totalBill <= 0 OrElse amountTendered < 0 OrElse exchangeRate <= 0 Then Return

            If Me.chkSPUseAccountBalance.Checked AndAlso accountBalance <= totalBill Then
                change = amountTendered * exchangeRate - totalBill + accountBalance

            ElseIf Me.chkSPUseAccountBalance.Checked AndAlso accountBalance > totalBill Then
                change = amountTendered * exchangeRate

            Else : change = amountTendered * exchangeRate - totalBill
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSPChange.Text = FormatNumber(change, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateSPCashTotalBill()

        Dim totalBill As Decimal

        Me.stbSPTotalAmountPaid.Clear()
        Me.nbxSPAmountTendered.Value = String.Empty
        Me.chkSPUseAccountBalance.Checked = False
        Me.chkSPSendBalanceToAccount.Checked = False
        Me.ResetSPCashCurrencyControls()

        For rowNo As Integer = 0 To Me.dgvServiceInvoices.RowCount - 1
            If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvServiceInvoices.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.ColSPAmount)
                totalBill += amount
            End If
        Next

        Me.stbSPTotalAmountPaid.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbSPAmountWords.Text = NumberToWords(totalBill)
        Me.nbxSPAmountTendered.Value = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateSPCashChange()

    End Sub


    Private Sub SPAmountTenderedChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxSPAmountTendered.Leave, nbxSPAmountTendered.TextChanged
        Me.CalculateSPCashChange()
    End Sub

    Private Sub SPExchangeRateChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxSPExchangeRate.Leave, nbxSPExchangeRate.TextChanged
        Me.CalculateSPCashChange()
    End Sub

    Private Sub ResetSPCashCurrencyControls()

        Try

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Me.cboServicePaymentCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings

        Catch ex As Exception
            Return
        End Try

    End Sub


    Private Sub btnServicePaymentExchangeRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServicePaymentExchangeRate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fExchangeRates As New frmExchangeRates()
            fExchangeRates.ShowDialog()

            Me.cboServicePaymentCurrenciesID_SelectedIndexChanged(sender, EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkSPUseAccountBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSPUseAccountBalance.Click

        Try

            Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxSPCashAccountBalance, True)

            If Me.chkSPUseAccountBalance.Checked AndAlso accountBalance <= 0 Then
                Me.ResetSPUseAccountBalanceCTRL(accountBalance)
            Else : Me.CalculateSPCashAmountTendered()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateSPCashChange()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub ResetSPCashAccountBalanceCTRL(cashAccountBalance As Decimal)

        Try

            If Not cashAccountBalance = DecimalMayBeEnteredIn(Me.nbxSPCashAccountBalance, True) Then

                Me.nbxSPCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
                Me.tipSPCashAccountBalanceWords.SetToolTip(Me.nbxSPCashAccountBalance, NumberToWords(cashAccountBalance))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkSPUseAccountBalance.Checked AndAlso cashAccountBalance <= 0 Then
                    Me.ResetSPUseAccountBalanceCTRL(cashAccountBalance)
                Else : Me.CalculateSPCashChange()
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ResetSPUseAccountBalanceCTRL(accountBalance As Decimal)

        Try

            Dim message As String = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                                    " can’t be used to offset this bill"

            Me.chkSPUseAccountBalance.Checked = False
            Throw New ArgumentException(message)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

 
    Private Sub stbSeviceInvoiceNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbSeviceInvoiceNo.Leave
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicGoodsReceivedNote As New frmNotPaidServiceInvoices(Me.stbSeviceInvoiceNo)
            fPeriodicGoodsReceivedNote.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbSeviceInvoiceNo))
            Me.ShowServiceDetails(_GRNNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    'Down

    Private Sub SPSupplierPayments()

        Dim message As String
        Dim lPaymentVouchers As New List(Of DBConnect)
        Dim lPaymentVoucherDetails As New List(Of DBConnect)
        Dim lGRNNO As New List(Of DBConnect)
        Dim lAccountBalance As New List(Of DBConnect)
        Dim lSendBalance As New List(Of DBConnect)
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim oAccountGroupID As New LookupDataID.AccountGroupID()
        Try
            Dim oEntryModeID As New LookupDataID.EntryModeID()
            Dim oPayModesID As New LookupDataID.PayModesID()
            Dim oPaymentVouchers As New SyncSoft.SQLDb.PaymentVouchers()
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbSPChange, True)
            Dim payMode As String = StringValueEnteredIn(Me.cboServicePaymentPayModesID, "Pay Modes!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboServicePaymentCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxSPAmountTendered, True, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxSPExchangeRate.GetDecimal(False)
            Dim voucherNo As String = RevertText(StringEnteredIn(Me.stbServiceVoucherNo, "VoucherNo!"))
            Dim payDate As Date = DateEnteredIn(Me.dtpSPPayDate, "Pay Date!")
            Dim supplierNo As String = StringEnteredIn(Me.stbSPSupplierNo, "Supplier No!")
            Dim accountBalance As Decimal = GetAccountBalance(oBillModesID.Cash, supplierNo)
            Me.ResetCashAccountBalanceCTRL(accountBalance)
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvServiceInvoices.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvServiceInvoices.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payMode.Equals(oPayModesID.Cheque()) OrElse payMode.Equals(oPayModesID.Visa()) OrElse
                payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then

                Dim documentNo As String = StringEnteredIn(stbSPDocumentNo, "Documment No")
                If (String.IsNullOrEmpty(bankNameID) OrElse String.IsNullOrEmpty(bankAccountNo)) Then
                    MsgBox(GetLookupDataDes(payMode) + " Requires Bank Details to Continue. Please provide the bank Information")
                    Dim ofrmBankPaymentDetails As New frmBankPaymentDetails(payMode)
                    ofrmBankPaymentDetails.ShowDialog()
                    Me.bankNameID = ofrmBankPaymentDetails.BankName()
                    Me.bankAccountNo = ofrmBankPaymentDetails.AccountNo()

                    If String.IsNullOrEmpty(Me.bankNameID) OrElse String.IsNullOrEmpty(Me.bankAccountNo) Then Return
                    Dim registerID As String = RevertText(Me.GetNextRegisterNo())
                    transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetails(voucherNo, documentNo, payMode), Action.Save))

                    If payMode.Equals(oPayModesID.Visa()) OrElse payMode.Equals(oPayModesID.ElectronicFundTransfer()) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingRegisterList(registerID, Me.oCollectionSourceTyPeID.PatientPayments, amountTendered,
                                                                                              payCurrencyID, exchangeRate, payDate), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetBankingDetailList(registerID, amountTendered, payMode, documentNo), Action.Save))
                    End If
                End If
            End If

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPaymentVouchers

                .VoucherNo = voucherNo
                .PayTypeID = payMode
                .BillNo = RevertText(StringEnteredIn(Me.stbSeviceInvoiceNo, "Invoice No!"))
                .PayDate = payDate
                .PayModesID = StringValueEnteredIn(Me.cboServicePaymentPayModesID, "PayModesID!")
                .DocumentNo = StringMayBeEnteredIn(Me.stbSPDocumentNo)
                .AmountWords = StringEnteredIn(Me.stbSPAmountWords, "AmountWords!")
                .Notes = StringEnteredIn(Me.stbSPNotes, "Notes!")
                .CurrenciesID = StringValueEnteredIn(Me.cboServicePaymentCurrenciesID, "CurrenciesID!")
                .AmountTendered = Me.nbxSPAmountTendered.GetDecimal(False)
                .ExchangeRate = Me.nbxSPExchangeRate.GetDecimal(False)
                .Change = change
                .SendBalanceToAccount = Me.chkSPSendBalanceToAccount.Checked
                .UseAccountBalance = Me.chkSPUseAccountBalance.Checked
                .VoucherTypeID = oVoucherTypeID.SupplierPayments
                .PayNo = RevertText(StringEnteredIn(Me.stbSPBillNo, "Invoice No!"))
                .FilterNo = RevertText(StringEnteredIn(Me.stbSPSupplierNo, "Supplier No!"))
                .Payee = StringEnteredIn(Me.stbSPSupplierName, "Payee!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgNonMedicalSupplierPayment)
                lPaymentVouchers.Add(oPaymentVouchers)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With


            For rowNo As Integer = 0 To Me.dgvServiceInvoices.RowCount - 1

                If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvServiceInvoices.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.ColSPItemCode, "item!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.ColSPItemCategoryID)

                    Using oPaymentVoucherDetails As New SyncSoft.SQLDb.PaymentVoucherDetails()

                        With oPaymentVoucherDetails

                            .VoucherNo = voucherNo
                            .BillNo = RevertText(StringEnteredIn(Me.stbSPBillNo, "Invoice No!"))
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = IntegerEnteredIn(cells, Me.ColSPReceivedQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.ColSPRate, False, "amount!")
                            .Discount = DecimalEnteredIn(cells, Me.colSPDiscount, True, "discount!")
                            .Amount = DecimalEnteredIn(cells, Me.ColSPAmount, False, "amount!")
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(tpgMedicalSupplierPayment)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With

                        lPaymentVoucherDetails.Add(oPaymentVoucherDetails)
                    End Using


                    Using oItems As New SyncSoft.SQLDb.ServiceInvoiceDetails()
                        With oItems
                            .ServiceInvoiceNo = RevertText(StringEnteredIn(Me.stbSeviceInvoiceNo, "Sevice Invoice No!"))
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .PayStatusID = oPayStatusID.PaidFor

                        End With
                        lGRNNO.Add(oItems)
                    End Using

                End If
            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgNonMedicalSupplierPayment, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentVouchers, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lPaymentVoucherDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lGRNNO, Action.Update))



            If change < 0 AndAlso Not Me.chkSPSendBalanceToAccount.Checked Then

                Me.nbxSPAmountTendered.Focus()
                Throw New ArgumentException("Amount tendered can’t be less than total bill!")

            ElseIf payDate < Today Then

                message = "You have selected a pay date that is before today, " +
                            "this will result in this receipt’s total bill not showing in today’s cash collections if searched via pay date." +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkSPUseAccountBalance.Checked Then

                Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbSPTotalAmountPaid, True)
                Dim creditBalance As Decimal = totalBill

                If accountBalance <= 0 Then

                    message = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                            " can’t be used to offset this bill"
                    Throw New ArgumentException(message)

                ElseIf totalBill > accountBalance AndAlso accountBalance > 0 Then

                    creditBalance = accountBalance

                    message = "Your current balance of " + FormatNumber(accountBalance, AppData.DecimalPlaces) +
                              " is insufficient to cater for this bill. " + ControlChars.NewLine +
                              "Would you like the system to use what’s on the your account? "

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    message = "You have chosen to receive part of this payment from the Supplier's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                Else : message = "You have chosen to receive this payment from the Supplier's account that will eventually be debited by " +
                    FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        .TranNo = GetNextTranNo()
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = RevertText(StringEnteredIn(Me.stbSPSupplierNo))
                        .ClientFullName = StringEnteredIn(Me.stbSPSupplierName)
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboServicePaymentPayModesID, "Pay Modes!")
                        .AccountActionID = oAccountActionID.Debit
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbSPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = oAccountGroupID.SupplierPayment
                        .Notes = "Payment under Voucher no: " + voucherNo
                        .EntryModeID = oEntryModeID.System
                        .ReferenceNo = voucherNo
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lAccountBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lAccountBalance, Action.Save))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            If Me.chkSPSendBalanceToAccount.Checked Then

                Dim accountActionID As String
                Dim creditBalance As Decimal = change
                Dim accountGroupID As String = oAccountGroupID.NA

                If change < 0 Then

                    accountActionID = oAccountActionID.Debit
                    creditBalance = -change
                    accountGroupID = oAccountGroupID.BillClearance

                    message = "You have chosen to send balance to the Supplier's account that will eventually be debited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"


                ElseIf change = 0 Then

                    message = "You have chosen to send balance to account. The system does not allow any account action with zero balance sent!"
                    Throw New ArgumentException(message)

                Else
                    accountActionID = oAccountActionID.Credit
                    creditBalance = change
                    accountGroupID = oAccountGroupID.LackofChange

                    message = "You have chosen to send balance to the Supplier's account that will eventually be credited by " +
                        FormatNumber(creditBalance, AppData.DecimalPlaces) + ControlChars.NewLine + "Are you sure you want to save?"

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Using oAccounts As New SyncSoft.SQLDb.Accounts()

                    With oAccounts
                        If Me.chkUseAccountBalance.Checked Then
                            .TranNo = GetNextTranNo(1)
                        Else : .TranNo = GetNextTranNo()
                        End If
                        .ClientFullName = StringEnteredIn(Me.stbSPSupplierName)
                        .AccountBillModesID = oBillModesID.Cash
                        .AccountBillNo = RevertText(StringEnteredIn(Me.stbSPSupplierNo))
                        .TranDate = payDate
                        .PayModesID = StringValueEnteredIn(Me.cboServicePaymentPayModesID, "Pay Modes!")
                        .AccountActionID = accountActionID
                        .Amount = creditBalance
                        .DocumentNo = StringMayBeEnteredIn(Me.stbSPDocumentNo)
                        .AmountWords = NumberToWords(.Amount)
                        .CurrenciesID = oCurrenciesID.UgandaShillings
                        .AmountTendered = .Amount
                        .ExchangeRate = 1
                        .Change = 0
                        .AccountGroupID = accountGroupID
                        .Notes = "Payment under Voucher no: " + voucherNo
                        .ReferenceNo = voucherNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lSendBalance.Add(oAccounts)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With

                End Using

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                transactions.Add(New TransactionList(Of DBConnect)(lSendBalance, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            If Not Me.chkSPUseAccountBalance.Checked AndAlso Not Me.chkSPSendBalanceToAccount.Checked Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                message = "You are about to perform an irreversible action please ensure that you have all the payment " +
                    "(Total Bill: " + Me.stbSPTotalAmountPaid.Text + ", Voucher No: " + Me.stbServiceVoucherNo.Text + ") " +
                    "with you before continuing." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            DoTransactions(transactions)

            If Not Me.chkPrintReceiptOnSaving.Checked Then
                message = "You have not checked Print Voucher On Saving. " + ControlChars.NewLine + "Would you want a receipt printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintSPCashReceipt(True)
            Else : Me.PrintSPCashReceipt(True)
            End If


            Me.ClearSPCashPaymentControls()

            SetNextVoucherNo(Me.stbServiceVoucherNo)

        Catch ex As Exception

            If ex.Message.Contains("The VoucherNo :") Then
                message = "The Voucher No: " + Me.stbServiceVoucherNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine +
                    "If you are using the system generated number, probably another person has already taken it." + ControlChars.NewLine +
                    "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextVoucherNo(Me.stbServiceVoucherNo)
            End If

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region "SP Cashier Printing "

    Private Sub PrintSPCashReceipt(ByVal receiptSaved As Boolean)

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvServiceInvoices.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvServiceInvoices.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cashSPReceiptSaved = receiptSaved
            Me.SetSPCashPrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docSPCashReceipt
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docSPCashReceipt.Print()



        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docSPCashReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docSPCashReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Cash Payment".ToUpper()



            Dim fromName As String = StringMayBeEnteredIn(Me.stbSPSupplierName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbServiceVoucherNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbSPBillNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpSPPayDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbSPReceivedDate)
            Dim notes As String = StringMayBeEnteredIn(Me.stbSPNotes)
            Dim docNo As String = StringMayBeEnteredIn(Me.stbSPDocumentNo)
            Dim textLEN As Integer = 75

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Paid To: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Voucher No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Received Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        If Not String.IsNullOrEmpty(docNo) Then

                            .DrawString("Document No:", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(docNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
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

                If cashParagraphs Is Nothing Then Return

                Do While cashParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(cashParagraphs(1), PrintParagraps)
                    cashParagraphs.Remove(1)

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
                        cashParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (cashParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetSPCashPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 12
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 56
        Dim padAmountTendered As Integer = 53
        Dim padAccountBalance As Integer = 43
        Dim padChange As Integer = 40

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        cashParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.HideCashPaymentReceiptDetails Then
                ' Header goes here!

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padCategoryName))
                tableHeader.Append("Amount: ".PadLeft(padCategoryAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetails = From data In Me.GetPaymentDetailsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentDetails

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padCategoryName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padCategoryAmount + 26))

                    tableData.Append(ControlChars.NewLine)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Cost: ".PadLeft(padUnitPrice))
                tableHeader.Append("Discount: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvServiceInvoices.RowCount - 1

                    If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvServiceInvoices.Rows(rowNo).Cells

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.ColSPItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.ColSPReceivedQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.ColSPRate.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colSPDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.ColSPAmount.Name).Value.ToString()

                        tableData.Append(itemNo.PadRight(padItemNo))
                        If itemName.Length > 20 Then
                            tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                        Else : tableData.Append(itemName.PadRight(padItemName))
                        End If
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(discount.PadLeft(padDiscount))
                        tableData.Append(amount.PadLeft(padAmount))

                        tableData.Append(ControlChars.NewLine)

                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim changeAmount As New System.Text.StringBuilder(String.Empty)

            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbSPTotalAmountPaid, True)
            Dim totalChange As Decimal = DecimalMayBeEnteredIn(Me.stbSPChange, True)
            totalAmount.Append(ControlChars.NewLine)


            totalAmount.Append("Total Amount: ")
            totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))



            totalAmount.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbSPAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            If totalChange > 0 Then
                changeAmount.Append(ControlChars.NewLine)
                changeAmount.Append("Change: ")
                changeAmount.Append(FormatNumber(totalChange, AppData.DecimalPlaces).PadLeft(padTotalAmount + 6))

                changeAmount.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, changeAmount.ToString()))
            End If

            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxSPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxSPExchangeRate, False)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbSPChange, True)
            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboServicePaymentCurrenciesID, "Currency!")
            Dim currency As String = StringMayBeEnteredIn(Me.cboServicePaymentCurrenciesID)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkSPUseAccountBalance.Checked OrElse (Me.chkSPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkSPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim accountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxSPCashAccountBalance, True)
                Dim balanceFromAccount As Decimal

                If accountBalance <= totalBill Then
                    balanceFromAccount = accountBalance
                Else : balanceFromAccount = totalBill
                End If

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkSPSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If




            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetSPPaymentDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvServiceInvoices.RowCount - 1

                If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvServiceInvoices.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.ColSPItemCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.ColSPAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(category, amount))

                End If
            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetSPPaymentDetailsItemTotalsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvServiceInvoices.RowCount - 1

                If CBool(Me.dgvServiceInvoices.Item(Me.ColSPInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvServiceInvoices.Rows(rowNo).Cells
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.ColSPAmount, False, "amount!")

                    paymentDetails.Add(New Tuple(Of String, Decimal)(itemName, amount))

                End If
            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Accounts"

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

    Private Sub stbAccountNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAccountNo.TextChanged
        Me.ResetControls()
    End Sub


    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim phoneNumber As String = String.Empty
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

    Private Sub SaveAccounts()

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
            ResetControlsIn(Me.tpgSupplierAccounts)
            Me.DefaultControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region "Print Accounts"


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

#End Region

    Private Sub btnManageAccounts_Click(sender As System.Object, e As System.EventArgs) Handles btnManageAccounts.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim fManageAccounts As frmManageAccountPayments

           Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgMedicalSupplierPayment.Name

                    Dim SupplierNo As String = RevertText(StringEnteredIn(Me.stbSupplierNo, "Supplier No!"))
                    fManageAccounts = New frmManageAccountPayments(oBillModesID.Cash, SupplierNo)
                    fManageAccounts.ShowDialog()

                Case Me.tpgNonMedicalSupplierPayment.Name
                    Dim SupplierNo As String = RevertText(StringEnteredIn(Me.stbSPSupplierNo, "Supplier No!"))
                    fManageAccounts = New frmManageAccountPayments(oBillModesID.Cash, SupplierNo)
                    fManageAccounts.ShowDialog()

                Case Else
                    btnManageAccounts.Visible = False

            End Select
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub stbAccountNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbAccountNo.Leave
        Try

            Dim accountNo As String = RevertText(StringMayBeEnteredIn(Me.stbAccountNo))

            If Not String.IsNullOrEmpty(accountNo) Then

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

    Private Sub tbcCashier_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles tbcCashier.SelectedIndexChanged
        Select Case Me.tbcCashier.SelectedTab.Name

            Case Me.tpgMedicalSupplierPayment.Name
                btnManageAccounts.Visible = True

            Case Me.tpgNonMedicalSupplierPayment.Name
                btnManageAccounts.Visible = True

            Case Else
                btnManageAccounts.Visible = False

        End Select
    End Sub
End Class