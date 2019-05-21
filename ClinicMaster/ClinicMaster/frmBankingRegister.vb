Option Strict On
Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Text
Imports System.Collections.Generic

Public Class frmBankingRegister

#Region " Fields "
    Private currencyID As String
    Private currentExchangeRate As Decimal
    Private oCurrenciesID As New LookupDataID.CurrenciesID()
    Private oCollectionSourceID As New LookupDataID.CollectionSourceTypeID()
    Dim oPayModesID As New LookupDataID.PayModesID()
#End Region

    Private Sub frmBankingRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Try

            Me.Cursor = Cursors.WaitCursor()

            dtpCollectionStartDateTime.MaxDate = Now.AddMinutes(10)
            dtpCollectionEndDateTime.MaxDate = Now.AddMinutes(10)

            Me.dtpCollectionStartDateTime.Value = Today
            Me.dtpCollectionEndDateTime.Value = Now

            dtpBankingDate.MaxDate = Today

            LoadLookupDataCombo(Me.cboBankNameID, LookupObjects.BankNamesID, False)
            LoadLookupDataCombo(Me.cboCollectionSource, LookupObjects.CollectionSourceID)

            LoadMMOrCashPayMode(colBankMode)
            LoadMMOrCashPayMode(colOtherIncomeBankMode)
            LoadMMOrCashPayMode(colAccountBankMode)
            SetNextRegisterNo()

            ' --------------------------------------------------------------------------------------------------------
            tbcCollections.TabPages.Remove(tpgChequePayments)
            tbcCollections.TabPages.Remove(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
            tbcCollections.TabPages.Remove(tpgAccounts)
            tbcCollections.TabPages.Remove(tpgAccountsCheque)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmBankingRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oBankingRegister.RegisterNo = StringEnteredIn(Me.stbRegisterNo, "Register No!")

            DisplayMessage(oBankingRegister.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim registerNo As String

        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()

        Try
            Me.Cursor = Cursors.WaitCursor()

            registerNo = StringEnteredIn(Me.stbRegisterNo, "Register No!")

            Dim dataSource As DataTable = oBankingRegister.GetBankingRegister(registerNo).Tables("BankingRegister")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oBankingRegister As New SyncSoft.SQLDb.BankingRegister()
        Dim oCurrenciesID As New LookupDataID.CurrenciesID
        Dim exchangeRate As Decimal

        Dim lBankingRegister As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Try
            Me.Cursor = Cursors.WaitCursor()

            If String.IsNullOrEmpty(currencyID) Then Return

            If currencyID.ToUpper.Equals(oCurrenciesID.UgandaShillings) Then
                exchangeRate = 1
            Else
                exchangeRate = GetExchangeRateBuying(currencyID)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountNo As String = StringEnteredIn(Me.stbAccountNo, "Account No!")
            Dim accountName As String = StringEnteredIn(Me.cboAccountNames, "Account Name!")
            Dim collectionSourceType As String = StringValueEnteredIn(cboCollectionSource, "Collection Source Type!")

            With oBankingRegister

                .RegisterNo = StringEnteredIn(Me.stbRegisterNo, "Register No!")
                .CollectionStartDate = DateTimeEnteredIn(Me.dtpCollectionStartDateTime, "Collection Start Date!")
                .CollectionEndDate = DateTimeEnteredIn(Me.dtpCollectionEndDateTime, "Collection End Date!")
                .BankingDate = DateEnteredIn(Me.dtpBankingDate, "Banking Date!")
                .CollectionSourCeTypeID = StringValueEnteredIn(cboCollectionSource, "Collection Source Type")
                .BankNameID = StringValueEnteredIn(Me.cboBankNameID, "Bank Name!")
                .AccountName = accountName
                .AccountNo = accountNo
                .AmountCollected = Me.nbxAmountCollected.GetDecimal(False)
                .AmountBanked = nbxBankedInAmountCurrency.GetDecimal(False)
                .AmountInWords = StringEnteredIn(Me.stbAmountInWords, "Amount In Words!")
                .CurrencyID = currencyID

                .ExchangeRate = exchangeRate
                If (.AmountCollected < .AmountBanked * nbxExchangeRate.GetDecimal(False)) Then
                    DisplayMessage("Amount banked cannot be greater than amount collected")
                    Return
                End If
                .BankedBy = StringEnteredIn(Me.stbBankedBy, "Banked By!")
                .LoginID = CurrentUser.LoginID

                .RecordDateTime = Now()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            lBankingRegister.Add(oBankingRegister)

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBankingRegister, Action.Save))

                    If collectionSourceType.Equals(oCollectionSourceID.PatientPayments) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetPatientCashPayment(), Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetPatientChequePaymentDetails, Action.Save))
                    ElseIf collectionSourceType.Equals(oCollectionSourceID.OtherIncome())
                        transactions.Add(New TransactionList(Of DBConnect)(GetOtherIncomeCashPayment, Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetOtherIncomeChequePaymentDetails, Action.Save))

                    ElseIf collectionSourceType.Equals(oCollectionSourceID.Account())
                        transactions.Add(New TransactionList(Of DBConnect)(GetAccountCashPayment, Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(GetAccountChequePaymentDetails, Action.Save))

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    dgvAllCollections.Rows.Clear()
                    dgvAccounts.Rows.Clear()
                    dgvOtherIncomes.Rows.Clear()

                    dgvAccountsCheque.Rows.Clear()
                    dgvOtherIncomeCheque.Rows.Clear()
                    dgvChequeCollections.Rows.Clear()
                    SetNextRegisterNo()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBankingRegister, Action.Update))

                    If collectionSourceType.Equals(oCollectionSourceID.PatientPayments) Then
                        transactions.Add(New TransactionList(Of DBConnect)(GetPatientCashPayment(), Action.Update))
                        transactions.Add(New TransactionList(Of DBConnect)(GetPatientChequePaymentDetails, Action.Update))
                    ElseIf collectionSourceType.Equals(oCollectionSourceID.OtherIncome)
                        transactions.Add(New TransactionList(Of DBConnect)(GetOtherIncomeCashPayment, Action.Update))
                        transactions.Add(New TransactionList(Of DBConnect)(GetOtherIncomeChequePaymentDetails, Action.Update))

                    ElseIf collectionSourceType.Equals(oCollectionSourceID.Account)
                        transactions.Add(New TransactionList(Of DBConnect)(GetAccountCashPayment, Action.Update))
                        transactions.Add(New TransactionList(Of DBConnect)(GetAccountChequePaymentDetails, Action.Update))

                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)
        SetNextRegisterNo()
    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub


    Private Sub LoadAccountNames(ByVal bankID As String)

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()

        cboAccountNames.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            cboAccountNames.Items.Clear()
            stbAccountNo.Clear()
            If String.IsNullOrEmpty(bankID) Then Return
            Dim bankAccount As DataTable = oBankAccount.GetBankAccountsByBankID(bankID).Tables("BankAccounts")


            LoadComboData(cboAccountNames, bankAccount, "AccountName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountNo(ByVal bankID As String, ByVal accountName As String)

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()
        stbAccountNo.Clear()
        Try
            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(bankID) OrElse String.IsNullOrEmpty(accountName) Then Return
            Dim bankAccount As DataTable = oBankAccount.GetBankAccounts(String.Empty, bankID, accountName).Tables("BankAccounts")
            Dim row As DataRow = bankAccount.Rows(0)

            currencyID = StringEnteredIn(row, "CurrencyID")

            stbAccountNo.Text = StringEnteredIn(row, "AccountNo")
            Dim currency As String = StringEnteredIn(row, "Currency")
            stbCurrency.Text = currency
            SetCashCurrencyControls(currencyID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCollectedAmount()

        Dim oPayment As New SyncSoft.SQLDb.Payments()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateTimeMayBeEnteredIn(dtpCollectionStartDateTime)
            Dim endDate As Date = DateTimeMayBeEnteredIn(dtpCollectionEndDateTime)
            If String.IsNullOrEmpty(startDate.ToString()) OrElse String.IsNullOrEmpty(startDate.ToString()) Then Return
            Dim payment As DataTable = oPayment.GetDailyNetCashCollections(startDate, endDate).Tables("CashPayments")

            Dim amountCollected As Decimal = CDec(payment.Rows(0).Item("NetCashCollected"))
            nbxAmountCollected.Text = FormatNumber(amountCollected, AppData.DecimalPlaces)
            nbxAmountBanked.Text = FormatNumber(amountCollected, AppData.DecimalPlaces)

        Catch ex As Exception


        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextRegisterNo()
        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBankingRegister As New BankingRegister()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BankingRegister", "RegisterNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextRegisterID As String = oBankingRegister.GetNextRegisterID().ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbRegisterNo.Text = FormatText(yearL2 + nextRegisterID.Trim(), "BankingRegister", "RegisterNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBankNameID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBankNameID.SelectedIndexChanged
        LoadAccountNames(StringValueMayBeEnteredIn(cboBankNameID))
    End Sub

    Private Sub cboAccountNames_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountNames.SelectedIndexChanged
        LoadAccountNo(StringValueMayBeEnteredIn(cboBankNameID), StringMayBeEnteredIn(cboAccountNames))
        CalculateAccountAmount()
    End Sub

    Private Sub nbxAmountCollected_GotFocus(sender As Object, e As EventArgs) Handles nbxAmountCollected.GotFocus
        'LoadCollectedAmount()
        'LoadCollectionSummaries()



    End Sub

    Private Sub nbxAmountCollected_Leave(sender As Object, e As EventArgs) Handles nbxAmountCollected.Leave
        Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(nbxAmountCollected), AppData.DecimalPlaces)
        nbxAmountCollected.Text = amount
        nbxAmountBanked.Text = amount

    End Sub


    Private Sub nbxAmountBanked_Leave(sender As Object, e As EventArgs) Handles nbxAmountBanked.Leave
        nbxAmountBanked.Text = FormatNumber(DecimalMayBeEnteredIn(nbxAmountBanked), AppData.DecimalPlaces)
        CalculateAccountAmount()


    End Sub

    Private Sub nbxAmountBanked_TextChanged(sender As Object, e As EventArgs) Handles nbxAmountBanked.TextChanged
        stbAmountInWords.Text = NumberToWords(DecimalMayBeEnteredIn(nbxAmountBanked))
        CalculateAccountAmount()


    End Sub


    Private Sub SetCashCurrencyControls(ByVal currenciesID As String)

        Try

            Me.Cursor = Cursors.WaitCursor


            Dim exchangeRate As Decimal = GetExchangeRateBuying(currenciesID)

            If currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                Me.nbxExchangeRate.Value = "1.00"
                Me.nbxExchangeRate.Enabled = False



            ElseIf exchangeRate > 0 Then
                If exchangeRate >= 1 Then
                    Me.nbxExchangeRate.Value = FormatNumber(exchangeRate, AppData.DecimalPlaces)
                Else : Me.nbxExchangeRate.Value = exchangeRate.ToString()
                End If
                Me.nbxExchangeRate.Enabled = False


            Else
                Me.nbxExchangeRate.Value = String.Empty
                Me.nbxExchangeRate.Enabled = True

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateAccountAmount()

        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim accountCurrency As String = StringMayBeEnteredIn(stbCurrency)
            Dim amountBanked As Decimal = DecimalMayBeEnteredIn(nbxAmountBanked)
            Dim currencyID As String = GetLookupDataID(LookupObjects.Currencies, accountCurrency)
            Dim bankedinAccountCurrency As Decimal


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            If currencyID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then
                bankedinAccountCurrency = amountBanked
            Else
                Dim exchangeRate As Decimal = GetExchangeRateBuying(currencyID)

                'exchangeRate = GetExchangeRateBuying(GetLookupDataID(LookupObjects.Currencies, accountCurrency))
                bankedinAccountCurrency = amountBanked / exchangeRate
            End If

            nbxBankedInAmountCurrency.Text = FormatNumber(bankedinAccountCurrency, AppData.DecimalPlaces)
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Function GetPeriodicPayModesPaymentsSummary(startDateTime As Date, endDateTime As Date,
                                                       payModesID As String, loginID As String, VisitsBranch As String) As DataSet

        Dim oPaymemt As New Payments
        Dim payments As DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)




            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)
            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, String.Empty, loginID, String.Empty)
            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)



            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, payModesID, loginID, String.Empty)
            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)
        Else
            payments = oPaymemt.GetPeriodicPayModesPaymentsSummary(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)
        End If
        Return payments
    End Function


    Public Function GetPeriodicPayModesPayments(startDateTime As Date, endDateTime As Date, payModesID As String, loginID As String, VisitsBranch As String) As DataSet
        Dim oPaymemt As New Payments
        Dim payments As DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)


            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)

            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, String.Empty, loginID, String.Empty)


            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)

            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, payModesID, loginID, String.Empty)


            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)



        Else
            payments = oPaymemt.GetPeriodicPayModesPayments(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)

        End If
        Return payments
    End Function


    Public Function GetPeriodicOtherIncomeSummary(startDateTime As Date, endDateTime As Date,
                                                       payModesID As String, loginID As String, VisitsBranch As String) As DataSet

        Dim oOtherIncome As New OtherIncome()
        Dim otherIncomes As New DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)

            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)
            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, String.Empty, loginID, String.Empty)
            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)



            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, payModesID, loginID, String.Empty)
            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)
        Else
            otherIncomes = oOtherIncome.GetPeriodicPayModesOtherIncomeSummary(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)
        End If

        Return otherIncomes
    End Function



    Public Function GetPeriodicOtherIncome(startDateTime As Date, endDateTime As Date, payModesID As String, loginID As String, VisitsBranch As String) As DataSet
        Dim oOtherIncomes As New OtherIncome
        Dim otherIncomes As DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)


            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)

            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, String.Empty, loginID, String.Empty)


            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)

            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, payModesID, loginID, String.Empty)


            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)

        Else
            otherIncomes = oOtherIncomes.GetPeriodicPayModeOtherIncome(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)

        End If

        Return otherIncomes

    End Function

    ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


    Public Function GetPeriodicPayModesAccountSummary(startDateTime As Date, endDateTime As Date,
                                                       payModesID As String, loginID As String, VisitsBranch As String) As DataSet

        Dim oAccounts As New Accounts()
        Dim accounts As DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)




            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)
            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, String.Empty, loginID, String.Empty)
            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)



            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, payModesID, loginID, String.Empty)
            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)
        Else
            accounts = oAccounts.GetPeriodicPayModesAccountsSummary(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)
        End If
        Return accounts
    End Function


    Public Function GetPeriodicPayModesAccounts(startDateTime As Date, endDateTime As Date, payModesID As String, loginID As String, VisitsBranch As String) As DataSet
        Dim oAccounts As New Accounts
        Dim accunts As DataSet
        '-----------------------All null---------------------------------------
        If String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, String.Empty, String.Empty, String.Empty)


            '------------------------only PayModeID Not null---------------------------------------
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, payModesID, String.Empty, String.Empty)

            '------------------------only LoginID Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, String.Empty, loginID, String.Empty)


            '------------------------only VisitsBranch Not null---------------------------------------
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, String.Empty, String.Empty, VisitsBranch)

            '----------------------------- Not PayModesID And LoginID----------------------------------------

        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, payModesID, loginID, String.Empty)


            '------------------------only PayModesID And BranchID Not null---------------------------------------	
        ElseIf Not String.IsNullOrEmpty(payModesID) AndAlso String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, payModesID, String.Empty, VisitsBranch)

            '------------------------only Login ID And Branch ID Not null---------------------------------------	
        ElseIf String.IsNullOrEmpty(payModesID) AndAlso Not String.IsNullOrEmpty(loginID) AndAlso Not String.IsNullOrEmpty(VisitsBranch) Then
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, String.Empty, loginID, VisitsBranch)



        Else
            accunts = oAccounts.GetPeriodicPayModeAccounts(startDateTime, endDateTime, payModesID, loginID, VisitsBranch)

        End If
        Return accunts
    End Function



    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



    Private Sub LoadCollectionSummaries()

        nbxAmountCollected.Clear()

        Dim incomeSource As String = StringValueMayBeEnteredIn(cboCollectionSource, "Collection Source!")

        If String.IsNullOrEmpty(incomeSource) Then Return

        Dim startDate As Date = DateTimeMayBeEnteredIn(dtpCollectionStartDateTime)
        Dim endDate As Date = DateTimeMayBeEnteredIn(dtpCollectionEndDateTime)

        If startDate > endDate Then Return

        If Not String.IsNullOrEmpty(FormatDate(endDate)) Then
            If startDate > endDate Then
                MsgBox("Start Date Can't be greater than end Date")
                Return
            End If
        End If

        If String.IsNullOrEmpty(startDate.ToString()) OrElse String.IsNullOrEmpty(startDate.ToString()) Then Return
        Dim dataTable As New DataTable
        Dim netCollected As Decimal

        ' -----------------------------------------------------------------------------------------

        Try
            Me.Cursor = Cursors.WaitCursor
            If incomeSource.Equals(oCollectionSourceID.PatientPayments) Then
                dataTable = Me.GetPeriodicPayModesPaymentsSummary(startDate, endDate, String.Empty, String.Empty, String.Empty).Tables("Payments")

                dgvAllCollections.Rows.Clear()


                If dataTable.Rows.Count() < 1 Then Return

                For pos As Integer = 0 To dataTable.Rows.Count - 1
                    Dim row As DataRow = dataTable.Rows(pos)
                    Dim payModesID As String = StringMayBeEnteredIn(row, "PayModesID")
                    Dim payMode As String = StringMayBeEnteredIn(row, "PayModes")
                    Dim amountCollected As Decimal = DecimalEnteredIn(row, "AmountCollected", False)
                    Dim totalRefunded As Decimal = DecimalEnteredIn(row, "TotalAmountRefunded", False)
                    Dim netAmountCollected As Decimal = DecimalEnteredIn(row, "NetAmountCollected", False)

                    With Me.dgvAllCollections
                        .Rows.Add()
                        .Item(Me.colPayModes.Name, pos).Value = payMode

                        .Item(Me.colAmountCollected.Name, pos).Value = FormatNumber(amountCollected, AppData.DecimalPlaces)
                        .Item(Me.colAmountRefunded.Name, pos).Value = totalRefunded
                        .Item(Me.colNetPatientPaymentAmountCollected.Name, pos).Value = FormatNumber(netAmountCollected, AppData.DecimalPlaces)
                        .Item(Me.colAmountBanked.Name, pos).Value = FormatNumber(netAmountCollected, AppData.DecimalPlaces)


                        If payModesID.Equals(oPayModesID.Cash()) OrElse payModesID.Equals(oPayModesID.MobileMoney()) Then
                            .Item(Me.colBankMode.Name, pos).Value = payModesID
                            .Item(Me.colAllInclude.Name, pos).Value = True
                        Else
                            dgvAllCollections.Rows(pos).ReadOnly = True
                            If payModesID.ToUpper().Equals(oPayModesID.Cheque) Then
                                .Item(Me.colAllInclude.Name, pos).ReadOnly = False

                            End If
                        End If


                    End With
                Next

                For Each row As DataGridViewRow In Me.dgvAllCollections.Rows
                    If row.IsNewRow Then Exit For

                Next
                dgvChequeCollections.Rows.Clear()
                tbcCollections.TabPages.Remove(tpgChequePayments)
                FormatGridRow(dgvAllCollections)
                netCollected = CalculateGridAmount(Me.dgvAllCollections, Me.colNetPatientPaymentAmountCollected)

                ' '''''''''''''''''''''''''''''''''''''''''''''''Accounts'''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf incomeSource.Equals(oCollectionSourceID.Account) Then
                dataTable = Me.GetPeriodicPayModesAccountSummary(startDate, endDate, String.Empty, String.Empty, String.Empty).Tables("Accounts")

                dgvAccounts.Rows.Clear()


                If dataTable.Rows.Count() < 1 Then Return

                For pos As Integer = 0 To dataTable.Rows.Count - 1
                    Dim row As DataRow = dataTable.Rows(pos)

                    Dim payMode As String = StringMayBeEnteredIn(row, "PayModes")
                    Dim payModesID As String = StringMayBeEnteredIn(row, "PayModesID")
                    Dim amountCollected As Decimal = DecimalEnteredIn(row, "Amount", False)


                    With Me.dgvAccounts
                        .Rows.Add()
                        .Item(Me.colAccountPayMode.Name, pos).Value = payMode
                        .Item(Me.colAccountAmountCredited.Name, pos).Value = FormatNumber(amountCollected, AppData.DecimalPlaces)
                        .Item(Me.colAccountBankedAmount.Name, pos).Value = FormatNumber(amountCollected, AppData.DecimalPlaces)


                        If payModesID.Equals(oPayModesID.Cash()) OrElse payModesID.Equals(oPayModesID.MobileMoney()) Then
                            .Item(Me.colAccountBankMode.Name, pos).Value = payModesID
                            .Item(Me.colAccountInclude.Name, pos).Value = True

                        Else
                            dgvAccounts.Rows(pos).ReadOnly = True
                            If payModesID.ToUpper().Equals(oPayModesID.Cheque) Then
                                .Item(Me.colAccountInclude.Name, pos).ReadOnly = False


                            End If

                        End If

                    End With
                Next

                For Each row As DataGridViewRow In Me.dgvAccounts.Rows
                    If row.IsNewRow Then Exit For

                Next

                dgvAccountsCheque.Rows.Clear()
                tbcCollections.TabPages.Remove(tpgAccountsCheque)

                FormatGridRow(dgvAccounts)
                netCollected = CalculateGridAmount(Me.dgvAccounts, Me.colAccountAmountCredited)

                ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf incomeSource.Equals(oCollectionSourceID.OtherIncome)


                dataTable = Me.GetPeriodicOtherIncomeSummary(startDate, endDate, String.Empty, String.Empty, String.Empty).Tables("OtherIncome")

                dgvOtherIncomes.Rows.Clear()


                If dataTable.Rows.Count() < 1 Then Return

                For pos As Integer = 0 To dataTable.Rows.Count - 1
                    Dim row As DataRow = dataTable.Rows(pos)
                    Dim payModesID As String = StringMayBeEnteredIn(row, "PayModesID")
                    Dim payMode As String = StringMayBeEnteredIn(row, "PayModes")
                    Dim amountCollected As Decimal = DecimalEnteredIn(row, "Amount", False)


                    With Me.dgvOtherIncomes
                        .Rows.Add()
                        .Item(Me.colOtherIncomePayMode.Name, pos).Value = payMode
                        .Item(Me.colIncomeReceived.Name, pos).Value = FormatNumber(amountCollected, AppData.DecimalPlaces)
                        .Item(Me.colOtherIncomeBanked.Name, pos).Value = FormatNumber(amountCollected, AppData.DecimalPlaces)

                        If payModesID.Equals(oPayModesID.Cash()) OrElse payModesID.Equals(oPayModesID.MobileMoney()) Then
                            .Item(Me.colOtherIncomeBankMode.Name, pos).Value = payModesID
                            .Item(Me.colIncludeOtherIncome.Name, pos).Value = True



                        Else
                            dgvOtherIncomes.Rows(pos).ReadOnly = True
                            If payModesID.ToUpper().Equals(oPayModesID.Cheque) Then
                                .Item(Me.colIncludeOtherIncome.Name, pos).ReadOnly = False


                            End If
                        End If

                    End With
                Next

                For Each row As DataGridViewRow In Me.dgvOtherIncomes.Rows
                    If row.IsNewRow Then Exit For

                Next
                FormatGridRow(dgvOtherIncomes)
                netCollected = CalculateGridAmount(Me.dgvOtherIncomes, colIncomeReceived)
            End If

            dgvOtherIncomeCheque.Rows.Clear()
            tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
            nbxAmountCollected.Text = FormatNumber(netCollected)
            Me.CalculateTotalBanked()

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub LoadCollectionDetails(payModesID As String)

        Dim incomeSource As String = StringValueEnteredIn(cboCollectionSource, "Collection Source!")
        Dim startDate As Date = DateTimeMayBeEnteredIn(dtpCollectionStartDateTime)
        Dim endDate As Date = DateTimeMayBeEnteredIn(dtpCollectionEndDateTime)
        If String.IsNullOrEmpty(startDate.ToString()) OrElse String.IsNullOrEmpty(startDate.ToString()) Then Return
        Dim dataTable As New DataTable


        ' -----------------------------------------------------------------------------------------
        Try
            Me.Cursor = Cursors.WaitCursor
            If incomeSource.Equals(oCollectionSourceID.PatientPayments) Then
                dataTable = Me.GetPeriodicPayModesPayments(startDate, endDate, payModesID, String.Empty, String.Empty).Tables("Payments")
                If dataTable.Rows.Count() < 1 Then Return
                LoadGridData(dgvChequeCollections, dataTable)
                FormatGridRow(dgvChequeCollections)
                DisableColumn(dgvChequeCollections, colSaved)

            ElseIf incomeSource.Equals(oCollectionSourceID.OtherIncome)
                dataTable = Me.GetPeriodicOtherIncome(startDate, endDate, payModesID, String.Empty, String.Empty).Tables("OtherIncome")
                If dataTable.Rows.Count() < 1 Then Return
                LoadGridData(dgvOtherIncomeCheque, dataTable)
                FormatGridRow(dgvOtherIncomeCheque)
                DisableColumn(dgvOtherIncomeCheque, colOtherIncomeChequeSaved)

            ElseIf incomeSource.Equals(oCollectionSourceID.Account)
                dataTable = Me.GetPeriodicPayModesAccounts(startDate, endDate, payModesID, String.Empty, String.Empty).Tables("Accounts")
                If dataTable.Rows.Count() < 1 Then Return
                LoadGridData(dgvAccountsCheque, dataTable)
                FormatGridRow(dgvAccountsCheque)
                DisableColumn(dgvAccountsCheque, colAccountChequeSaved)
            End If


        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub cboCollectionSource_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCollectionSource.SelectedIndexChanged

        Dim collectionSource As String = StringValueMayBeEnteredIn(cboCollectionSource)
        nbxAmountBanked.Clear()
        If String.IsNullOrEmpty(collectionSource) Then Return

        If (collectionSource.Equals(oCollectionSourceID.PatientPayments)) Then
            tbcCollections.TabPages.Remove(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgAllCollections)
            tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
            tbcCollections.TabPages.Add(tpgAllCollections)
            tbcCollections.TabPages.Remove(tpgChequePayments)
            tbcCollections.TabPages.Remove(tpgAccountsCheque)
            tbcCollections.TabPages.Remove(tpgAccounts)

        ElseIf (collectionSource.Equals(oCollectionSourceID.OtherIncome))
            tbcCollections.TabPages.Remove(tpgAllCollections)
            tbcCollections.TabPages.Remove(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
            tbcCollections.TabPages.Remove(tpgChequePayments)
            tbcCollections.TabPages.Add(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgAccountsCheque)
            tbcCollections.TabPages.Remove(tpgAccounts)

        ElseIf (collectionSource.Equals(oCollectionSourceID.Account))
            tbcCollections.TabPages.Remove(tpgAllCollections)
            tbcCollections.TabPages.Remove(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
            tbcCollections.TabPages.Remove(tpgChequePayments)
            tbcCollections.TabPages.Remove(tpgOtherPayment)
            tbcCollections.TabPages.Remove(tpgAccountsCheque)
            tbcCollections.TabPages.Remove(tpgAccounts)
            tbcCollections.TabPages.Add(tpgAccounts)

        End If

        LoadCollectionSummaries()

    End Sub


    Private Sub dgvOtherIncomes_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOtherIncomes.CellEndEdit
        Dim row As Integer = e.RowIndex
        If row < 0 Then Return
        Try

            If e.ColumnIndex.Equals(Me.colIncludeOtherIncome.Index) Then
                Dim payModeID As String = GetLookupDataID(LookupObjects.PayModes, StringEnteredIn(Me.dgvOtherIncomes.Rows(row).Cells, colOtherIncomePayMode))
                If payModeID.Equals(oPayModesID.Cheque) Then


                    If CBool(Me.dgvOtherIncomes.Item(Me.colIncludeOtherIncome.Name, row).Value) = True Then
                        tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
                        tbcCollections.TabPages.Add(tpgOtherPaymentCheque)
                        tbcCollections.SelectedTab = tpgOtherPaymentCheque
                        LoadCollectionDetails(payModeID)

                    ElseIf CBool(Me.dgvOtherIncomes.Item(Me.colIncludeOtherIncome.Name, row).Value) = False
                        tbcCollections.TabPages.Remove(tpgOtherPaymentCheque)
                        dgvOtherIncomeCheque.Rows.Clear()

                    End If
                End If
                Me.CalculateTotalBanked()

            ElseIf e.ColumnIndex = colOtherIncomeBanked.Index
                Me.CalculateTotalBanked()
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub dgvAllCollections_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAllCollections.CellEndEdit
        Dim row As Integer = e.RowIndex
        If row < 0 Then Return
        Try
            If e.ColumnIndex.Equals(Me.colAllInclude.Index) Then
                Dim payModeID As String = GetLookupDataID(LookupObjects.PayModes, StringEnteredIn(Me.dgvAllCollections.Rows(row).Cells, Me.colPayModes))
                If payModeID.Equals(oPayModesID.Cheque) Then

                    If CBool(Me.dgvAllCollections.Item(Me.colAllInclude.Name, e.RowIndex).Value) = True Then
                        tbcCollections.TabPages.Remove(tpgChequePayments)
                        tbcCollections.TabPages.Add(tpgChequePayments)
                        tbcCollections.SelectedTab = tpgChequePayments
                        LoadCollectionDetails(payModeID)

                    ElseIf CBool(Me.dgvAllCollections.Item(Me.colAllInclude.Name, e.RowIndex).Value) = False
                        tbcCollections.TabPages.Remove(tpgChequePayments)
                        dgvChequeCollections.Rows.Clear()

                    End If
                End If
            End If
            Me.CalculateTotalBanked()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtpCollectionStartDateTime_Leave(sender As Object, e As EventArgs) Handles dtpCollectionStartDateTime.Leave
        LoadCollectionSummaries()
    End Sub


    Private Sub dtpCollectionEndDateTime_Leave(sender As Object, e As EventArgs) Handles dtpCollectionEndDateTime.Leave

        LoadCollectionSummaries()
    End Sub

    Private Function CalculateTotalPatientPayment() As Decimal
        Dim totalCashBanked As Decimal = 0

        For Each row As DataGridViewRow In Me.dgvAllCollections.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colPayModes)
            Dim include As Boolean = CBool(Me.dgvAllCollections.Item(Me.colAllInclude.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------

            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then
                totalCashBanked += DecimalMayBeEnteredIn(row.Cells, Me.colAmountBanked)
            Else
                colNetPatientPaymentAmountCollected.ReadOnly = True

            End If

        Next
        Return totalCashBanked + CalculatePatientChequePayment()

    End Function


    Private Function CalculateTotalOtherIncomePayment() As Decimal
        Dim totalCashBanked As Decimal = 0
        Dim checkAmount As Decimal = 0

        For Each row As DataGridViewRow In Me.dgvOtherIncomes.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colOtherIncomePayMode)
            Dim include As Boolean = CBool(Me.dgvOtherIncomes.Item(Me.colIncludeOtherIncome.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------

            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then
                totalCashBanked += DecimalMayBeEnteredIn(row.Cells, Me.colOtherIncomeBanked)

            End If

        Next


        Return totalCashBanked + Me.CalculateOtherIncomeCheque
    End Function


    Private Function CalculateOtherIncomeCheque() As Decimal

        Dim otherIncomeCheque As Decimal = 0
        For Each row As DataGridViewRow In Me.dgvOtherIncomeCheque.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvOtherIncomeCheque.Item(Me.colIncludeOtherIncomeCheque.Name, row.Index).Value)
            Dim isSaved As Boolean = CBool(Me.dgvOtherIncomeCheque.Item(Me.colOtherIncomeChequeSaved.Name, row.Index).Value)


            If include AndAlso isSaved Then
                otherIncomeCheque += DecimalMayBeEnteredIn(row.Cells, Me.colOtherIncomeChequeReceivedIncome)

            End If

        Next

        stbOtherIncomeChequePayments.Text = FormatNumber(otherIncomeCheque)
        stbOtherIncomeChequePayMentInWords.Text = NumberToWords(otherIncomeCheque)

        Return otherIncomeCheque
    End Function


    Private Function CalculatePatientChequePayment() As Decimal

        Dim chequePaymement As Decimal = 0
        stbPatientChequePayments.Clear()
        stbPatientChequePaymentsWords.Clear()

        For Each row As DataGridViewRow In Me.dgvChequeCollections.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvChequeCollections.Item(Me.colIncludeChequePayment.Name, row.Index).Value)

            If include Then
                chequePaymement += DecimalMayBeEnteredIn(row.Cells, Me.colPatientPaymentChequeAmount)

            End If

        Next
        stbPatientChequePayments.Text = FormatNumber(chequePaymement)
        stbPatientChequePaymentsWords.Text = NumberToWords(chequePaymement)
        Return chequePaymement

    End Function


    Private Function CalculateAccountCheque() As Decimal

        Dim accountCheque As Decimal = 0
        For Each row As DataGridViewRow In Me.dgvAccountsCheque.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvAccountsCheque.Item(Me.colAccountChequeInclude.Name, row.Index).Value)


            If include Then
                accountCheque += DecimalMayBeEnteredIn(row.Cells, Me.colAccountChequeAmount)

            End If

        Next

        stbAccountCheque.Text = FormatNumber(accountCheque)
        stbAccountChequeInWords.Text = NumberToWords(accountCheque)

        Return accountCheque
    End Function

    Private Function CalculateTotalAccountPayment() As Decimal
        Dim totalCashBanked As Decimal = 0
        Dim checkAmount As Decimal = 0

        For Each row As DataGridViewRow In Me.dgvAccounts.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colAccountPayMode)
            Dim include As Boolean = CBool(Me.dgvAccounts.Item(Me.colAccountInclude.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------

            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then
                totalCashBanked += DecimalMayBeEnteredIn(row.Cells, Me.colAccountBankedAmount)

            End If

        Next


        Return totalCashBanked + Me.CalculateAccountCheque()
    End Function


    Private Sub CalculateTotalBanked()
        nbxAmountBanked.Clear()
        Dim totalBanked As Decimal
        Dim incomeSource As String = StringValueMayBeEnteredIn(cboCollectionSource)

        If String.IsNullOrEmpty(incomeSource) Then Return

        If (incomeSource.Equals(oCollectionSourceID.PatientPayments)) Then
            totalBanked = CalculateTotalPatientPayment()

        ElseIf (incomeSource.Equals(oCollectionSourceID.Account)) Then
            totalBanked = CalculateTotalAccountPayment()

        Else
            totalBanked = CalculateTotalOtherIncomePayment()
        End If


        nbxAmountBanked.Text = FormatNumber(totalBanked)
    End Sub

    Private Sub dgvChequeCollections_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChequeCollections.CellEndEdit
        If e.ColumnIndex = colIncludeChequePayment.Index Then
            CalculatePatientChequePayment()
            CalculateTotalBanked()
        End If
    End Sub


    Private Sub dgvOtherIncomeCheque_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOtherIncomeCheque.CellEndEdit
        If e.ColumnIndex = colIncludeOtherIncomeCheque.Index Then
            CalculateOtherIncomeCheque()
            CalculateTotalBanked()
        End If
    End Sub


#End Region

    Private Function GetPatientCashPayment() As List(Of DBConnect)

        Dim lCashPaymodes As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvAllCollections.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colPayModes)
            Dim include As Boolean = CBool(Me.dgvAllCollections.Item(Me.colAllInclude.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------

            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then


                Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                    With oBankingRegisterDetails


                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colAmountBanked)
                        .CollectionModesID = GetLookupDataID(LookupObjects.PayModes, payModesID)
                        .BankModesID = StringEnteredIn(row.Cells, Me.colBankMode)
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colAllCollectionsDocumentNo)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    lCashPaymodes.Add(oBankingRegisterDetails)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End Using

            End If
        Next

        Return lCashPaymodes

    End Function


    Private Function GetPatientChequePaymentDetails() As List(Of DBConnect)
        Dim payModesID As String = oPayModesID.Cheque()
        Dim lChequePayments As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvChequeCollections.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvChequeCollections.Item(Me.colIncludeChequePayment.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------


            If include Then
                Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                    With oBankingRegisterDetails


                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colPatientPaymentChequeAmount)
                        .CollectionModesID = payModesID
                        .BankModesID = payModesID
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colPatientChequeDocumentNo)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lChequePayments.Add(oBankingRegisterDetails)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End Using
            End If

        Next

        Return lChequePayments

    End Function


    Private Function GetOtherIncomeCashPayment() As List(Of DBConnect)

        Dim lCashOtherIncomePaymodes As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvOtherIncomes.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colOtherIncomePayMode)
            Dim include As Boolean = CBool(Me.dgvOtherIncomes.Item(Me.colIncludeOtherIncome.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------


            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then

                Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                    With oBankingRegisterDetails

                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colOtherIncomeBanked)
                        .CollectionModesID = GetLookupDataID(LookupObjects.PayModes, payModesID)
                        .BankModesID = StringEnteredIn(row.Cells, Me.colOtherIncomeBankMode)
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colOtherIncomeDocumentNo)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lCashOtherIncomePaymodes.Add(oBankingRegisterDetails)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End Using
            End If

        Next

        Return lCashOtherIncomePaymodes

    End Function


    Private Function GetOtherIncomeChequePaymentDetails() As List(Of DBConnect)
        Dim payModesID As String = oPayModesID.Cheque()
        Dim lChequePayments As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvOtherIncomeCheque.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvOtherIncomeCheque.Item(Me.colIncludeOtherIncomeCheque.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------



            Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                If include Then
                    With oBankingRegisterDetails


                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colOtherIncomeChequeReceivedIncome)
                        .CollectionModesID = payModesID
                        .BankModesID = payModesID
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colOtherIncomeChequeDocumentNo)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lChequePayments.Add(oBankingRegisterDetails)
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Using


        Next

        Return lChequePayments

    End Function


    Private Function GetAccountCashPayment() As List(Of DBConnect)

        Dim lAccountCashPayModes As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvAccounts.Rows
            If row.IsNewRow Then Exit For
            Dim payModesID As String = StringEnteredIn(row.Cells, Me.colAccountPayMode)
            Dim include As Boolean = CBool(Me.dgvAccounts.Item(Me.colAccountInclude.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------


            If Not payModesID.ToUpper().Equals(GetLookupDataDes(oPayModesID.Cheque).ToUpper()) AndAlso include Then

                Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                    With oBankingRegisterDetails

                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colAccountBankedAmount)
                        .CollectionModesID = GetLookupDataID(LookupObjects.PayModes, payModesID)
                        .BankModesID = StringEnteredIn(row.Cells, Me.colAccountBankMode)
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colAccountDocumentNo)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccountCashPayModes.Add(oBankingRegisterDetails)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End Using
            End If

        Next

        Return lAccountCashPayModes

    End Function


    Private Function GetAccountChequePaymentDetails() As List(Of DBConnect)
        Dim payModesID As String = oPayModesID.Cheque()
        Dim lAccountCheque As New List(Of DBConnect)
        For Each row As DataGridViewRow In Me.dgvAccountsCheque.Rows
            If row.IsNewRow Then Exit For

            Dim include As Boolean = CBool(Me.dgvAccountsCheque.Item(Me.colAccountChequeInclude.Name, row.Index).Value)


            ' ------------------------------------------------------------------------------------------------

            If include Then

                Using oBankingRegisterDetails As New SyncSoft.SQLDb.BankingRegisterDetails()

                    With oBankingRegisterDetails


                        .RegisterNo = StringEnteredIn(stbRegisterNo, "Register No")
                        .Amount = DecimalMayBeEnteredIn(row.Cells, Me.colAccountChequeAmount)
                        .CollectionModesID = payModesID
                        .BankModesID = payModesID
                        .DocumentNo = StringEnteredIn(row.Cells, Me.colAccountChequeDocument)
                        .LoginID = CurrentUser.LoginID
                        .RecordDateTime = Now()


                    End With

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lAccountCheque.Add(oBankingRegisterDetails)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End Using
            End If

        Next

        Return lAccountCheque

    End Function


    Private Sub dgvAccountsCheque_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccountsCheque.CellEndEdit
        If e.ColumnIndex = colAccountChequeInclude.Index Then
            CalculatePatientChequePayment()
            CalculateTotalBanked()
        End If
    End Sub


    Private Sub dgvAccounts_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccounts.CellEndEdit
        Dim row As Integer = e.RowIndex
        If row < 0 Then Return
        Try

            If e.ColumnIndex.Equals(Me.colAccountInclude.Index) Then
                Dim payModeID As String = GetLookupDataID(LookupObjects.PayModes, StringEnteredIn(Me.dgvAccounts.Rows(row).Cells, colAccountPayMode))
                If payModeID.Equals(oPayModesID.Cheque) Then


                    If CBool(Me.dgvAccounts.Item(Me.colAccountInclude.Name, row).Value) = True Then
                        tbcCollections.TabPages.Remove(tpgAccountsCheque)
                        tbcCollections.TabPages.Add(tpgAccountsCheque)
                        tbcCollections.SelectedTab = tpgAccountsCheque
                        LoadCollectionDetails(payModeID)

                    ElseIf CBool(Me.dgvAccounts.Item(Me.colAccountInclude.Name, row).Value) = False
                        tbcCollections.TabPages.Remove(tpgAccountsCheque)
                        dgvAccountsCheque.Rows.Clear()

                    End If
                End If
                Me.CalculateTotalBanked()

            ElseIf e.ColumnIndex = colAccountBankedAmount.Index
                Me.CalculateTotalBanked()
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub LoadMMOrCashPayMode(column As DataGridViewComboBoxColumn)
        Dim lPayModesID As New List(Of LookupData)
        Dim oCashPayment As New LookupData()
        oCashPayment.DataID = oPayModesID.Cash()
        oCashPayment.DataDes = GetLookupDataDes(oPayModesID.Cash())
        Dim oMobileMoney As New LookupData()
        oMobileMoney.DataID = oPayModesID.MobileMoney()
        oMobileMoney.DataDes = GetLookupDataDes(oPayModesID.MobileMoney())

        lPayModesID.Add(oCashPayment)
        lPayModesID.Add(oMobileMoney)

        column.DataSource = Nothing

        column.DataSource = lPayModesID
        column.DisplayMember = "DataDes"
        column.ValueMember = "DataID"


    End Sub


    Private Sub DisableColumn(dataGridView As DataGridView, column As DataGridViewCheckBoxColumn)

        For Each row As DataGridViewRow In dataGridView.Rows
            If row.IsNewRow Then Exit For
            Dim isSaved As Boolean = CBool(dataGridView(column.Name, row.Index).Value)

            If isSaved Then
                row.ReadOnly = True
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Next

    End Sub


End Class