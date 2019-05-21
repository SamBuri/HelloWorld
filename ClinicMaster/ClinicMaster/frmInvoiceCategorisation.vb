
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

Public Class frmInvoiceCategorisation
#Region " Fields "
    Private billCustomers As DataTable
    Private WithEvents docPrintAccountStatement As New PrintDocument()
    Private accountStatement As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 7, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 7)
    Private bodySmallFont As New Font(printFontName, 6)
#End Region



    Private Sub frmInvoiceCategorisation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboBillMode, LookupObjects.BillModes, False)
            Me.dtpStartDateTime.Value = Today.AddDays(-1)

            Me.tbcInvoiceCategorisation_SelectedIndexChanged(Me, EventArgs.Empty)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub frmAccountStatement_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
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
                    Me.lblAccountNo.Text = "Account No"
                    Me.lblAccountName.Text = "Account Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblAccountNo.Text = "Insurance No"
                    Me.lblAccountName.Text = "Insurance Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

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
            Dim oItems As New Items()
            Dim Invoicecategorised As New DataTable()
            Dim refunds As New DataTable
            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim IPDInvoicecategorised As New DataTable()
            Dim rowCount As Integer

            Dim billModesID As String = StringEnteredIn(Me.cboBillMode, "Account Category!")
            Dim AccountNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboAccountNo, "Account Name!")))
            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date & Time")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date & Time")
            Dim ExcludePendingItems As Boolean = chkExcludePendingItems.Checked
            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(startDateTime) + " and " + FormatDate(endDateTime) + "!"

            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")
            If String.IsNullOrEmpty(billModesID) Then Return


            Select Case Me.tbcInvoiceCategorisation.SelectedTab.Name

                Case Me.tpgOutpatient.Name

                    If billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper) Then
                        Invoicecategorised = oItems.GetInvoiceCategorization(startDateTime, endDateTime, ExcludePendingItems, AccountNo, String.Empty).Tables("Items")
                    Else
                        Invoicecategorised = oItems.GetInvoiceCategorization(startDateTime, endDateTime, ExcludePendingItems, String.Empty, AccountNo).Tables("Items")
                    End If

                    LoadGridData(Me.dgvOutPatientInvoiceCategorisation, Invoicecategorised)
                    FormatGridColumn(Me.dgvOutPatientInvoiceCategorisation)
                    rowCount = Me.dgvOutPatientInvoiceCategorisation.RowCount
                Case Me.tpgInPatient.Name
                    If billModesID.ToUpper.Equals(oBillModesID.Cash.ToUpper) Then
                        IPDInvoicecategorised = oExtraBillItems.GetIPDInvoiceCategorization(startDateTime, endDateTime, ExcludePendingItems, AccountNo, String.Empty).Tables("ExtraBillItems")
                    Else
                        IPDInvoicecategorised = oExtraBillItems.GetIPDInvoiceCategorization(startDateTime, endDateTime, ExcludePendingItems, String.Empty, AccountNo).Tables("ExtraBillItems")
                    End If

                    LoadGridData(Me.dgvInPatientInvoiceCategorisation, IPDInvoicecategorised)
                    FormatGridColumn(Me.dgvInPatientInvoiceCategorisation)
                    rowCount = Me.dgvInPatientInvoiceCategorisation.RowCount
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



    Private Sub ClearControls()
        Me.stbAccountName.Clear()
        Me.nbxAccountBalance.Clear()
        Me.nbxOutstandingBill.Clear()
        Me.stbAccountName.Clear()
        Me.dgvOutPatientInvoiceCategorisation.Rows.Clear()
        Me.dgvInPatientInvoiceCategorisation.Rows.Clear()
        Me.cboAccountNo.Text = String.Empty

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
                    Dim row As DataRow = oPatients.GetPatients(accountNo).Tables("Patients").Rows(0)

                    Me.cboAccountNo.Text = FormatText(accountNo, "Patients", "PatientNo")
                    accountName = StringMayBeEnteredIn(row, "FullName")
                    accountBalance = GetAccountBalance(oBillModesID.Cash, accountNo)
                    Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
                    Me.nbxOutstandingBill.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
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



    Private Sub cboAccountNo_Leave(sender As Object, e As EventArgs) Handles cboAccountNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            LoadAccountDetails()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
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
    Private Sub fbnRefresh_Click(sender As Object, e As EventArgs) Handles fbnRefresh.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.cboBillMode.SelectedIndex = -1
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




    Private Sub fbnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExport.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcInvoiceCategorisation.SelectedTab.Name

                Case Me.tpgOutpatient.Name
                    ExportToExcel(Me.dgvOutPatientInvoiceCategorisation, Me.tpgOutpatient.Text, Me.Text)

                Case Me.tpgInPatient.Name
                    ExportToExcel(Me.dgvInPatientInvoiceCategorisation, Me.tpgInPatient.Text, Me.Text)


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcInvoiceCategorisation_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tbcInvoiceCategorisation.SelectedIndexChanged

        Try
            Dim rowCount As Integer
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcInvoiceCategorisation.SelectedTab.Name

                Case Me.tpgOutpatient.Name
                    Me.chkExcludePendingItems.Text = "Exclude Pending Items"
                    rowCount = Me.dgvOutPatientInvoiceCategorisation.RowCount
                Case Me.tpgInPatient.Name
                    Me.chkExcludePendingItems.Text = "Exclude Paid For Items"
                    rowCount = Me.dgvInPatientInvoiceCategorisation.RowCount
            End Select


            Me.fbnExport.Enabled = rowCount > 0
            Me.lblRecordsNo.Text = "Returned Cash Record(s): " + rowCount.ToString()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub
End Class