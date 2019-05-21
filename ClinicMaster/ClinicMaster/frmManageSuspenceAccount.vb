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
Public Class frmManageSuspenceAccount

#Region " Fields "

    Private defaultBillModesID As String = String.Empty
    Private defaultAccountNo As String = String.Empty
    Private billCustomers As DataTable
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
    Private Sub frmManageSuspenceAccount_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim oVariousOptions As New VariousOptions()

        Try

            Me.Cursor = Cursors.WaitCursor
            ClearControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.MaxDate = Today

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
              With InitOptions
                Me.stbAccountTranNo.ReadOnly = .TranNoLocked
            End With

            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)

            LoadLookupDataCombo(Me.cboAccountCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.cboAccountGroupID, LookupObjects.AccountGroup, False)
            LoadLookupDataCombo(Me.cboAccountActionID, LookupObjects.AccountAction, False)

            Me.DefaultControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
         

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    

    Private Sub DefaultControls()

        Try
            Dim oAccountActionID As New LookupDataID.AccountActionID()
            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)

            Me.cboBillModesID.SelectedValue = defaultBillModesID
            Me.cboAccountCurrenciesID.SelectedValue = oCurrenciesID.UgandaShillings
            Me.cboAccountActionID.SelectedValue = oAccountActionID.Debit
            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.Checked = True


            Me.stbAccountTranNo.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub


    Private Sub cboAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccountNo.Leave

        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo)))

            If String.IsNullOrEmpty(accountNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadAccountDetails(billModesID, accountNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()
        Me.nbxAccountAmount.Clear()
        Me.nbxAccountAmountTendered.Clear()
        Me.ResetControls()
    End Sub

    Private Sub ResetControls()
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()
        Me.cboAccountNo.DataSource = Nothing
        Me.cboAccountNo.Items.Clear()
        Me.cboAccountNo.Text = String.Empty
        Me.stbAccountNotes.Clear()
        Me.stbAccountDocumentNo.Clear()

    End Sub

    Private Sub LoadAccountClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "From Patient No"
                    Me.lblAccountName.Text = "From Patient Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboAccountNo, billCustomers, "BillCustomerFullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "From Account No"
                    Me.lblAccountName.Text = "From Account Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "From Insurance No"
                    Me.lblAccountName.Text = "From Insurance Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim accountBalance As Decimal
        Dim accountPhone As String = String.Empty

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Clear()
            Me.nbxAccountAmount.Clear()
            Me.nbxAccountBalance.Clear()
              '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oPatients.GetPatients(accountNo).Tables("Patients").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                     accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    accountName = StringMayBeEnteredIn(row, "BillCustomerName")
                     accountBalance = GetAccountBalance(oBillModesID.Account, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(accountNo).Tables("Insurances").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Insurances", "InsuranceNo")
                    accountName = StringMayBeEnteredIn(row, "InsuranceName")
                     accountBalance = GetAccountBalance(oBillModesID.Insurance, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return

        
          
            Me.LoadAccountClients(billModesID)



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

    Private Sub SetNextTranNo(ByVal sourceControl As TextBox)

        Try
            Me.Cursor = Cursors.WaitCursor

            sourceControl.Text = FormatText(GetNextTranNo(), "Accounts", "TranNo")

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


    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Dim lAccounts As New List(Of DBConnect)
        Dim lsusAccounts As New List(Of DBConnect)
        Dim lsuspense As New List(Of DBConnect)
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oVariousOptions As New VariousOptions()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim accountBillNo As String = "SUSP"

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim payMode As String = StringValueEnteredIn(Me.cboPayModesID, "Pay Modes!")
            Dim accountActionID As String = StringValueEnteredIn(Me.cboAccountActionID, "Account Action!")
            Dim payCurrencyID As String = StringValueEnteredIn(Me.cboAccountCurrenciesID, "Currency!")
            Dim amountTendered As Decimal = DecimalEnteredIn(Me.nbxAccountAmountTendered, False, "Amount Tendered!")
            Dim exchangeRate As Decimal = Me.nbxAccountExchangeRate.GetDecimal(False)
            Dim payDate As Date = DateEnteredIn(Me.dtpTransactionDate, "Transaction Date!")
            Dim tranNo As String = RevertText(StringEnteredIn(Me.stbAccountTranNo, "Transaction No!"))
             Using oAccounts As New SyncSoft.SQLDb.Accounts()

                With oAccounts

                    .TranNo = tranNo
                    .AccountBillModesID = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")
                    .AccountBillNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
                    .ClientFullName = StringEnteredIn(Me.stbAccountName, "Account Name!")
                    .TranDate = DateEnteredIn(Me.dtpTransactionDate, "Transaction Date!")
                    .PayModesID = payMode
                    .AccountActionID = accountActionID
                    .AmountWords = NumberToWords(.Amount)
                    .CurrenciesID = payCurrencyID
                    .AmountTendered = amountTendered
                    .ExchangeRate = exchangeRate
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .Change = DecimalEnteredIn(Me.stbAccountChange, False, "Change!")
                    .DocumentNo = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                    .AccountGroupID = StringValueEnteredIn(Me.cboAccountGroupID, "Account Group!")
                    .Notes = StringEnteredIn(Me.stbAccountNotes, "Notes!")
                    .EntryModeID = oEntryModeID.System
                    .ReferenceNo = Nothing
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccounts.Add(oAccounts)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oAccountTransferDetails As New SyncSoft.SQLDb.AccountTransferDetails()

                With oAccountTransferDetails

                    .TranNo = tranNo + "" + "s"
                    .FromAccount = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
                    .ToAccount = accountBillNo
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .AmountInWords = NumberToWords(.Amount)
                    .Reason = StringValueEnteredIn(Me.cboAccountGroupID, "Account Group!")
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lsuspense.Add(oAccountTransferDetails)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With

            End Using
            Using osusAccounts As New SyncSoft.SQLDb.Accounts()

                With osusAccounts

                    .TranNo = tranNo + "" + "s"
                    .AccountBillModesID = oBillModesID.Account
                    .ClientFullName = accountBillNo
                    .AccountBillNo = accountBillNo
                    .TranDate = payDate
                    .PayModesID = payMode
                    .AccountActionID = oAccountActionID.Credit
                    .AmountWords = NumberToWords(.Amount)
                    .CurrenciesID = payCurrencyID
                    .AmountTendered = amountTendered
                    .ExchangeRate = exchangeRate
                    .Amount = Me.nbxAccountAmount.GetDecimal(False)
                    .Change = DecimalEnteredIn(Me.stbAccountChange, False, "Change!")
                    .DocumentNo = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                    .AccountGroupID = StringValueEnteredIn(Me.cboAccountGroupID, "Account Group!")
                    .Notes = StringEnteredIn(Me.stbAccountNotes, "Notes!")
                    .EntryModeID = oEntryModeID.System
                    .ReferenceNo = Nothing
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lsusAccounts.Add(osusAccounts)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
            End Using
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            transactions.Add(New TransactionList(Of DBConnect)(lAccounts, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lsusAccounts, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lsuspense, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            DoTransactions(transactions)
            ClearControls()
            Me.SetNextTranNo(Me.stbAccountTranNo)
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
End Class