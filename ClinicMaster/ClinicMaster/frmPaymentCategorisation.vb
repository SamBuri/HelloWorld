Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.SQLDb.Lookup
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects


Imports SyncSoft.Common.Structures

Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports SyncSoft.SQLDb
Imports System.Drawing.Printing

Public Class frmPaymentCategorisation


#Region "Fields"
    Private billCustomers As DataTable

#End Region

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            loadData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub loadData()

        Dim oAccounts As New SyncSoft.SQLDb.Accounts

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.Cursor = Cursors.WaitCursor
            Dim oItems As New Items()
            Dim refunds As New DataTable
            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim IPDInvoicecategorised As New DataTable()
            Dim rowCount As Integer

            Dim billModesID As String = String.Empty
            Dim AccountNo As String = (RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo))))
            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date & Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date & Time")

            Dim opayments As New SyncSoft.SQLDb.Payments()
            Dim Paymentcategorised As New DataTable
            Dim IPDPaymentcategorised As New DataTable
            Dim OPDCategorisedAccountDetails As New DataTable
            Dim IPDCategorisedAccountDetails As New DataTable
            Me.lblRecordsNo.Text = ""
            Me.fbnExport.Enabled = False

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDateTime) + " and " + FormatDate(endDateTime) + "!"

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")



            Select Case Me.tbcPaymentCategorisation.SelectedTab.Name

                Case Me.tpgOutpatient.Name
                    billModesID = StringValueEnteredIn(Me.cboBillMode, "Account Category!")

                    If billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper) Then
                        If String.IsNullOrEmpty(AccountNo) Then
                            Paymentcategorised = opayments.GetOPDPaymentCategorization(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            Paymentcategorised = opayments.GetOPDPaymentCategorization(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If

                    Else
                        If String.IsNullOrEmpty(AccountNo) Then
                            Paymentcategorised = opayments.GetOPDCreditPaymentCategorisation(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            Paymentcategorised = opayments.GetOPDCreditPaymentCategorisation(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If

                    End If

                    LoadGridData(Me.dgvOutPatientPaymentCategorisation, Paymentcategorised)
                    FormatGridColumn(Me.dgvOutPatientPaymentCategorisation)
                    rowCount = Me.dgvOutPatientPaymentCategorisation.RowCount

                Case Me.tpgInPatient.Name
                    billModesID = StringValueEnteredIn(Me.cboBillMode, "Account Category!")
                    If billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper) Then
                    If String.IsNullOrEmpty(AccountNo) Then
                            IPDPaymentcategorised = opayments.GetIPDPaymentCategorization(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            IPDPaymentcategorised = opayments.GetIPDPaymentCategorization(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If
                    Else
                        If String.IsNullOrEmpty(AccountNo) Then
                            IPDPaymentcategorised = opayments.GetIPDCreditPaymentCategorisation(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            IPDPaymentcategorised = opayments.GetIPDCreditPaymentCategorisation(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If

                    End If

                    LoadGridData(Me.dgvIPDPatientPaymentCategorisation, IPDPaymentcategorised)
                    FormatGridColumn(Me.dgvIPDPatientPaymentCategorisation)
                    rowCount = Me.dgvIPDPatientPaymentCategorisation.RowCount


                Case Me.tpgOPDInvoiceDetails.Name

                    ' Me.cboBillMode.SelectedItem = oBillModesID.Account.ToUpper
                    'Me.cboBillMode.Enabled = False
                    billModesID = StringValueEnteredIn(Me.cboBillMode, "Account Category!")

                    If billModesID.ToUpper.Equals(oBillModesID.Account.ToUpper) Then

                        If String.IsNullOrEmpty(AccountNo) Then
                            OPDCategorisedAccountDetails = opayments.GetOPDCreditInvoiceCategorisationDetails(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            OPDCategorisedAccountDetails = opayments.GetOPDCreditInvoiceCategorisationDetails(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If
                    Else

                        If String.IsNullOrEmpty(AccountNo) Then
                            OPDCategorisedAccountDetails = opayments.GetOPDCashInvoiceCategorisationDetails(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            OPDCategorisedAccountDetails = opayments.GetOPDCashInvoiceCategorisationDetails(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If
                    End If

                    LoadGridData(Me.dgvOPDAccountDetails, OPDCategorisedAccountDetails)
                    FormatGridColumn(Me.dgvOPDAccountDetails)
                    rowCount = Me.dgvOPDAccountDetails.RowCount

                Case Me.tpgIPDInvoiceDetails.Name

                   billModesID = StringValueEnteredIn(Me.cboBillMode, "Account Category!")

                    If billModesID.ToUpper.Equals(oBillModesID.Account.ToUpper) Then

                        If String.IsNullOrEmpty(AccountNo) Then
                            IPDCategorisedAccountDetails = opayments.GetIPDCreditInvoiceCategorisationDetails(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            IPDCategorisedAccountDetails = opayments.GetIPDCreditInvoiceCategorisationDetails(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If
                    Else

                        If String.IsNullOrEmpty(AccountNo) Then
                            IPDCategorisedAccountDetails = opayments.GetIPDCashInvoiceCategorisationDetails(String.Empty, startDateTime, endDateTime).Tables("Payments")
                        Else
                            IPDCategorisedAccountDetails = opayments.GetIPDCashInvoiceCategorisationDetails(AccountNo, startDateTime, endDateTime).Tables("Payments")
                        End If
                    End If

                    LoadGridData(Me.dgvIPDAccountDetails, IPDCategorisedAccountDetails)
                    FormatGridColumn(Me.dgvIPDAccountDetails)
                    rowCount = Me.dgvIPDAccountDetails.RowCount


                Case Me.tpgAccounts.Name

                    Dim accounts As DataTable = oAccounts.GetAccountDeposits(startDateTime, endDateTime).Tables("Accounts")

                    LoadGridData(Me.dgvAccounts, accounts)
                    FormatGridColumn(Me.dgvAccounts)
                    rowCount = Me.dgvAccounts.RowCount



            End Select


            Me.fbnExport.Enabled = rowCount > 0
            Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountDetails()
        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillMode, "Account Category!")
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

    Private Sub LoadAccountDetails(ByVal billModesID As String, ByVal accountNo As String)

        Dim accountName As String = String.Empty
        Dim accountBalance As Decimal

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAccountName.Clear()
            Me.nbxAccountBalance.Clear()
            'Me.stbTotalDeposit.Clear()
            'Me.stbBill.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim Patients As DataTable = oPatients.GetPatients(accountNo).Tables("Patients")

                    If Patients Is Nothing OrElse Patients.Rows.Count < 1 Then Return
                    Dim row As DataRow = Patients.Rows(0)


                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                    Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
                    Me.nbxOutstandingBill.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim BillCustomers As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")

                    If BillCustomers Is Nothing OrElse BillCustomers.Rows.Count < 1 Then Return

                    Dim row As DataRow = BillCustomers.Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    accountName = StringMayBeEnteredIn(row, "BillCustomerName")
                    accountBalance = GetAccountBalance(oBillModesID.Account, accountNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim Insurances As DataTable = oInsurances.GetInsurances(accountNo).Tables("Insurances")

                    If Insurances Is Nothing OrElse Insurances.Rows.Count < 1 Then Return

                    Dim row As DataRow = Insurances.Rows(0)


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
                    Me.lblAccountNo.Text = "Account No"
                    Me.lblAccountName.Text = "Patient Name"

                    Me.colPatientName.HeaderText = "Patient Name"
                    Me.colAccountNo.HeaderText = "Patient No"
                    Me.colFullName.HeaderText = "Patient Name"
                    Me.colIPDAccountNo.HeaderText = "Patient No"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        BillCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = BillCustomers
                    Else : BillCustomers = oSetupData.BillCustomers
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboAccountNo, BillCustomers, "BillCustomerFullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Account No"
                    Me.lblAccountName.Text = "Account Name"

                    Me.colPatientName.HeaderText = "Account Name"
                    Me.colAccountNo.HeaderText = "Account No"
                    Me.colFullName.HeaderText = "Account Name"
                    Me.colIPDAccountNo.HeaderText = "Account No"

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Insurance No"
                    Me.lblAccountName.Text = "Insurance Name"

                    Me.colPatientName.HeaderText = "Insurance Name"
                    Me.colAccountNo.HeaderText = "Insurance No"
                    Me.colFullName.HeaderText = "Insurance Name"
                    Me.colIPDAccountNo.HeaderText = "Insurance No"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmPaymentCategorisation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboBillMode, LookupObjects.BillModes, False)


            Me.dtpStartDateTime.Value = Today.AddDays(-1)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub fbnRefresh_Click(sender As Object, e As EventArgs) Handles fbnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
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

    Private Sub ClearControls()



        Me.dgvOutPatientPaymentCategorisation.Rows.Clear()
        Me.dgvIPDPatientPaymentCategorisation.Rows.Clear()

    End Sub

    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPaymentCategorisation.SelectedTab.Name

                Case Me.tpgOutpatient.Name
                    ExportToExcel(Me.dgvOutPatientPaymentCategorisation, Me.tpgOutpatient.Text, Me.Text)

                Case Me.tpgInPatient.Name
                    ExportToExcel(Me.dgvIPDPatientPaymentCategorisation, Me.tpgInPatient.Text, Me.Text)

                Case Me.tpgAccounts.Name
                    ExportToExcel(Me.dgvAccounts, Me.tpgAccounts.Text, Me.Text)

                Case Me.tpgOPDInvoiceDetails.Name
                    ExportToExcel(Me.dgvOPDAccountDetails, Me.tpgOPDInvoiceDetails.Text, Me.Text)

                Case Me.tpgIPDInvoiceDetails.Name
                    ExportToExcel(Me.dgvIPDAccountDetails, Me.tpgIPDInvoiceDetails.Text, Me.Text)
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    'Private Sub btnLoadPatients_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadPatients.Click

    '    Try

    '        Me.Cursor = Cursors.WaitCursor

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.cboAccountNo)
    '        fQuickSearch.ShowDialog(Me)

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
    '        If Not String.IsNullOrEmpty(patientNo) Then Me.LoadAccountDetails()
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '    Catch ex As Exception
    '        ErrorMessage(ex)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try
    'End Sub

    'Private Sub ShowPatientDetails(ByVal patientNo As String)

    '    Dim oPatients As New SyncSoft.SQLDb.Patients()

    '    Try
    '        Me.Cursor = Cursors.WaitCursor

    '        Me.ClearControls()

    '        Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
    '        Dim row As DataRow = patients.Rows(0)

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Me.stbFullName.Text = StringEnteredIn(row, "FullName")
    '        Me.stbGender.Text = StringEnteredIn(row, "Gender")
    '        Me.stbAge.Text = StringEnteredIn(row, "Age")

    '        Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
    '        Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)

    '    Catch eX As Exception
    '        Me.ClearControls()
    '        ErrorMessage(eX)

    '    Finally
    '        Me.Cursor = Cursors.Default

    '    End Try

    'End Sub

    

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try
          
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.cboAccountNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.LoadAccountDetails()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboBillMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBillMode.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()
            Me.cboAccountNo.Items.Clear()
            Me.ClearControls()


            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillMode, "Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.btnLoad.Visible = billModesID.ToUpper().Equals(oBillModesID.Cash().ToUpper())
            Me.LoadAccountClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboAccountNo_Leave(sender As Object, e As System.EventArgs) Handles cboAccountNo.Leave
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.cboAccountNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.LoadAccountDetails()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub tbcPaymentCategorisation_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcPaymentCategorisation.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oBillModesID As New LookupDataID.BillModesID()

            Select Case Me.tbcPaymentCategorisation.SelectedTab.Name

                Case Me.tpgAccounts.Name

                    Me.cboBillMode.Text = String.Empty
                    Me.cboBillMode.Enabled = False
                    Me.cboAccountNo.Enabled = False
                    Me.stbAccountName.Enabled = False
                    Me.stbPatientChequePayments.Enabled = False
                    Me.stbPatientChequePaymentsWords.Enabled = False

                Case Else

                    Me.cboBillMode.Enabled = True
                    Me.cboAccountNo.Enabled = True
                    Me.stbAccountName.Enabled = True
                    Me.stbPatientChequePayments.Enabled = True
                    Me.stbPatientChequePaymentsWords.Enabled = True

            End Select


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class