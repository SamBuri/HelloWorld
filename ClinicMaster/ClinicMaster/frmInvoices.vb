
Option Strict On
Option Infer On

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

Public Class frmInvoices

#Region " Fields "

    Dim invoiceItems As DataTable

    Private defaultVisitNo As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private patientNo As String = String.Empty
    Private visitDate As String = String.Empty
    Private visitNo As String = String.Empty
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private visitBillNo As String = String.Empty
    Private memberCardNo As String = String.Empty
    Private mainMemberName As String = String.Empty
    Private claimReferenceNo As String = String.Empty
    Private primaryDoctor As String = String.Empty
    Private billCustomerName As String = String.Empty
    Private insuranceName As String = String.Empty
    Private coPayType As String = String.Empty
    Private coPayPercent As Single = 0
    Private coPayValue As Decimal = 0

    Private billCustomers As DataTable
    Private WithEvents docInvoices As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

#End Region

    Private Sub frmInvoices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim oBillModesID As New LookupDataID.BillModesID()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpInvoiceDate.MaxDate = Today


            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.dtpStartDate.Value = Today.AddDays(-1)
            Me.dtpEndDate.Value = Today


            If oVariousOptions.EnableInvoiceDate Then
                Me.dtpInvoiceDate.Enabled = True
                Me.dtpInvoiceDate.Value = Today
                Me.dtpInvoiceDate.Checked = True
            Else

                Me.dtpInvoiceDate.Checked = True
                Me.dtpInvoiceDate.Value = Today
                Me.dtpInvoiceDate.Enabled = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.cboBillModesID.SelectedValue = oBillModesID.Cash
                Me.cboBillAccountNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.cboBillModesID.Enabled = False
                Me.cboBillAccountNo.Enabled = False
                Me.btnFindVisitNo.Enabled = False
                Me.btnLoadPeriodicVisits.Enabled = False
                Me.LoadBillDetails(oBillModesID.Cash, defaultVisitNo)
            Else
                Me.cboBillModesID.Enabled = True
                Me.cboBillAccountNo.Enabled = True
            End If


            If Not oVariousOptions.EnablePrintInvoiceDetailesCheck Then
                Me.chkPrintInvoiceDetailedOnSaving.Visible = False
            Else
                Me.chkPrintInvoiceDetailedOnSaving.Visible = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInvoices_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboBillAccountNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboBillAccountNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbInvoiceNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.cboBillAccountNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowVisitBillHeaderData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.cboBillAccountNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitBillHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnLoadPendingBillsPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingBillsPayment.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadBillItems()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextInvoiceNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Invoices", "InvoiceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim invoiceNo As String = yearL2 + oInvoices.GetNextInvoiceID.ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbInvoiceNo.Text = FormatText(invoiceNo, "Invoices", "InvoiceNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return

            Me.LoadAccountClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccountClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearAccountControls()
            Me.ClearBillsPayControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnFindVisitNo.Enabled = True
                    Me.btnLoadPeriodicVisits.Enabled = True
                    Me.lblBillAccountNo.Text = "Visit No"
                    Me.lblBillCustomerName.Text = "Patient Name"
                    Me.pnlNavigateVisits.Visible = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnFindVisitNo.Enabled = False
                    Me.btnLoadPeriodicVisits.Enabled = False
                    Me.lblBillAccountNo.Text = "Account No"
                    Me.lblBillCustomerName.Text = "Account Name"
                    Me.pnlNavigateVisits.Visible = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances

                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboBillAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.btnFindVisitNo.Enabled = False
                    Me.btnLoadPeriodicVisits.Enabled = False
                    Me.lblBillAccountNo.Text = "Insurance No"
                    Me.lblBillCustomerName.Text = "Insurance Name"
                    Me.pnlNavigateVisits.Visible = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearAccountControls()
        Me.cboBillAccountNo.DataSource = Nothing
        Me.cboBillAccountNo.Items.Clear()
        Me.cboBillAccountNo.Text = String.Empty
        ResetControlsIn(Me.pnlNavigateVisits)
    End Sub

    Private Sub cboBillAccountNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillAccountNo.SelectedIndexChanged
        Me.ClearBillsPayControls()
    End Sub

    Private Sub cboBillAccountNo_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles cboBillAccountNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''
            Me.ShowVisitBillHeaderData()
            '''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearPrintControls()

        patientNo = String.Empty
        visitDate = String.Empty
        visitNo = String.Empty
        visitBillNo = String.Empty
        memberCardNo = String.Empty
        mainMemberName = String.Empty
        claimReferenceNo = String.Empty
        primaryDoctor = String.Empty
        billCustomerName = String.Empty
        insuranceName = String.Empty
        coPayType = String.Empty
        coPayPercent = 0
        CoPayValue = 0

    End Sub

    Private Sub ShowBillDetails(ByVal billModesID As String, ByVal billNo As String)

        Dim displayName As String = String.Empty

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Clear()
            Me.ClearPrintControls()
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oVisits.GetVisits(billNo).Tables("Visits").Rows(0)

                    visitNo = FormatText(billNo, "Visits", "VisitNo")
                    Me.cboBillAccountNo.Text = visitNo
                    displayName = StringMayBeEnteredIn(row, "FullName")
                    patientNo = StringMayBeEnteredIn(row, "PatientNo")
                    visitDate = FormatDate(DateMayBeEnteredIn(row, "VisitDate"))
                    primaryDoctor = StringMayBeEnteredIn(row, "PrimaryDoctor")
                    memberCardNo = StringMayBeEnteredIn(row, "MemberCardNo")
                    mainMemberName = StringMayBeEnteredIn(row, "MainMemberName")
                    claimReferenceNo = StringMayBeEnteredIn(row, "ClaimReferenceNo")
                    visitBillNo = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    insuranceName = StringMayBeEnteredIn(row, "InsuranceName")
                    coPayType = StringMayBeEnteredIn(row, "CoPayType")
                    coPayPercent = SingleMayBeEnteredIn(row, "CoPayPercent")
                    coPayValue = DecimalMayBeEnteredIn(row, "CoPayValue")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    EnablePeriodCTLS(False)
                    Me.dtpStartDate.Value = DateEnteredIn(row, "VisitDate")
                    Me.dtpEndDate.Value = DateEnteredIn(row, "VisitDate")
                    Me.chkReconciliationRequired.Checked = BooleanMayBeEnteredIn(row, "OPDBillReconciled")
                    Me.dtpStartDate.Checked = True
                    Me.dtpEndDate.Checked = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.cboBillAccountNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    displayName = StringMayBeEnteredIn(row, "BillCustomerName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    EnablePeriodCTLS(True)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.cboBillAccountNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    displayName = StringMayBeEnteredIn(row, "InsuranceName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    EnablePeriodCTLS(True)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Text = displayName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowVisitBillHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPayControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillAccountNo)))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")

            If String.IsNullOrEmpty(billNo) OrElse String.IsNullOrEmpty(billModesID) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillDetails(billModesID, billNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadBillDetails(ByVal billModesID As String, ByVal billNo As String)


        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillDetails(billModesID, billNo)
            Me.LoadBillItems()
            ''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillItems()


        Dim items As DataTable
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim message As String = "Unknown Error Occured!"
            Dim cashAccount As String = GetLookupDataDes(oBillModesID.Cash)
            Dim outPatientVisit As String = GetLookupDataDes(oVisitTypeID.OutPatient)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")
            Dim billNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboBillAccountNo, "To-Bill Number!")))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ResetBillsPayControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billNo.ToUpper().Equals(cashAccount.ToUpper()) Then Throw New ArgumentException("Invalid entry (CASH) for an account!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                'items = oItems.GetNotPaidItemsByVisitNo(billNo).Tables("Items")
                items = oItems.GetVisitItemsByInvoiceStatus(billNo, False).Tables("Items")
                Me.invoiceItems = oItems.GetNotPaidItemsByVisitNo(billNo).Tables("Items")
                ShowGeneratedInvoiceControl(billNo, True)
            Else : items = oItems.GetNotPaidItems(billModesID, billNo, startDate, endDate, String.Empty).Tables("Items")
                Me.invoiceItems = oItems.GetNotPaidItems(billModesID, billNo, startDate, endDate, String.Empty).Tables("Items")
                ShowGeneratedInvoiceControl(billNo, False)

            End If

            If oVariousOptions.EnableInvoiceDate Then
                Me.dtpInvoiceDate.Enabled = True
                Me.dtpInvoiceDate.Value = Today
            Else

                Me.dtpInvoiceDate.Checked = True
                Me.dtpInvoiceDate.Value = Today
                Me.dtpInvoiceDate.Enabled = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items Is Nothing OrElse items.Rows.Count < 1 Then Throw New ArgumentException("No " + outPatientVisit + " Record(s) found!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To items.Rows.Count - 1

                Dim row As DataRow = items.Rows(rowNo)

                With Me.dgvInvoiceDetails

                    .Rows.Add()

                    .Item(Me.colVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                    .Item(Me.colVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                    .Item(Me.colPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                    .Item(Me.colFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                    .Item(Me.colItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                    .Item(Me.colQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.ColMappedCode.Name, rowNo).Value = StringMayBeEnteredIn(row, "MappedCustomCode")
                    .Item(Me.colUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)
                    .Item(Me.colDiscount.Name, rowNo).Value = FormatNumber(0)
                    .Item(Me.colAmount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
                    .Item(Me.colBillPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "BillPrice"), AppData.DecimalPlaces)
                    .Item(Me.colItemStatus.Name, rowNo).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                    .Item(Me.colMainMemberName.Name, rowNo).Value = StringMayBeEnteredIn(row, "MainMemberName")
                    .Item(Me.colClaimReferenceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "ClaimReferenceNo")
                    .Item(Me.colBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                    .Item(Me.colCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                    .Item(Me.colCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                    .Item(Me.colCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    .Item(Me.colItemCategoryID.Name, rowNo).Value = StringEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colSaved.Name, rowNo).Value = False

                End With

                Me.CalculateBillAmount(rowNo)

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = " Returned Record(s): " + items.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateAccountTotalBill()
            Me.SetNextInvoiceNo()

            Me.ebnSaveUpdate.Enabled = Me.dgvInvoiceDetails.RowCount > 0
            Me.btnAddExtraCharge.Enabled = Me.dgvInvoiceDetails.RowCount > 0
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateVisits)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillsPayControls()

        Me.stbBillCustomerName.Clear()
        chkReconciliationRequired.Checked = False
        ResetControlsIn(Me.pnlNavigateVisits)
        Me.ResetBillsPayControls()

    End Sub

    Private Sub ResetBillsPayControls()

        Me.stbInvoiceNo.Clear()
        Me.stbBPTotalBill.Clear()
        Me.stbBPAmountWords.Clear()
        Me.ResetRecordsControls()

    End Sub

    Private Sub ResetRecordsControls()

        Me.dgvInvoiceDetails.Rows.Clear()
        Me.lblRecordsNo.Text = String.Empty
        Me.ebnSaveUpdate.Enabled = False
        Me.btnAddExtraCharge.Enabled = False
        Me.lblLoadInvoices.Text = ""
        Me.fbnLoadInvoices.Visible = False

    End Sub

   
    Private Sub btnAddExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddExtraCharge.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim message As String = "Would you like to Re-Load Invoice Details?"

            If Me.dgvInvoiceDetails.RowCount <= 0 Then Return

            Dim selectedRow As Integer = Me.dgvInvoiceDetails.CurrentCell.RowIndex
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.dgvInvoiceDetails.Rows(selectedRow).Cells, Me.colVisitNo))

            Dim fExtraCharge As New frmExtraCharge(visitNo)
            fExtraCharge.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.LoadBillItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Invoice Details - Grid "

    Private Sub CalculateBillAmount(ByVal rowNo As Integer)

        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells

        Try

            Dim quantity As Integer = IntegerMayBeEnteredIn(cells, Me.colQuantity)
           

            Dim billPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colBillPrice)
            Dim discount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDiscount)
            Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice)
            Dim amount As Decimal = (quantity * billPrice) - discount
            Dim displayAmount As Decimal = (quantity * unitPrice) - discount

            Me.dgvInvoiceDetails.Item(Me.colAmount.Name, rowNo).Value = FormatNumber(amount, AppData.DecimalPlaces)
            Me.dgvInvoiceDetails.Item(Me.colDisplayAmount.Name, rowNo).Value = FormatNumber(displayAmount, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateAccountTotalBill()

        Dim totalBill As Decimal

        Me.stbBPTotalBill.Clear()

        For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
            totalBill += amount
        Next

        Me.stbBPTotalBill.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBPAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub dgvInvoiceDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceDetails.CellEndEdit
        If e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse e.ColumnIndex.Equals(Me.colUnitPrice.Index) _
            OrElse e.ColumnIndex.Equals(Me.colDiscount.Index) Then Me.CalculateBillAmount(e.RowIndex)
        Me.CalculateAccountTotalBill()
    End Sub

    Private Sub dgvInvoiceDetails_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvInvoiceDetails.UserDeletedRow
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CalculateAccountTotalBill()
        Me.lblRecordsNo.Text = " Returned Record(s): " + Me.dgvInvoiceDetails.Rows.Count.ToString()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub dgvInvoiceDetails_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInvoiceDetails.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.InvoiceDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvInvoiceDetails.Item(Me.colSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
            Dim visitNo As String = RevertText(Me.dgvInvoiceDetails.Item(Me.colVisitNo.Name, toDeleteRowNo).Value.ToString())
            Dim itemCode As String = Me.dgvInvoiceDetails.Item(Me.colItemCode.Name, toDeleteRowNo).Value.ToString()
            Dim itemCategoryID As String = Me.dgvInvoiceDetails.Item(Me.colItemCategoryID.Name, toDeleteRowNo).Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .InvoiceNo = invoiceNo
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = itemCategoryID
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.cboBillAccountNo, Me.lblBillAccountNo.Text + "!"))
                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.cboBillAccountNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.LoadBillDetails(oBillModesID.Cash, visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInvoices.InvoiceNo = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
            DisplayMessage(oInvoices.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.grpInvoiceDetails)
            ResetControlsIn(Me.pnlNavigateVisits)
            Me.lblRecordsNo.Text = String.Empty
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim billModesID As String

            Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
            Dim dataSource As DataTable = oInvoices.GetInvoices(invoiceNo).Tables("Invoices")
            Me.DisplayData(dataSource)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoices As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()

            Dim payNo As String = (From data In invoices Select data.Field(Of String)("PayNo")).First()
            Dim payTypeID As String = (From data In invoices Select data.Field(Of String)("PayTypeID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If payTypeID.ToUpper().Equals(oPayTypeID.AccountBill.ToUpper()) Then
                billModesID = oBillModesID.Account
            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                billModesID = oBillModesID.Insurance
            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.VisitBill.ToUpper()) Then
                billModesID = oBillModesID.Cash
            Else : billModesID = String.Empty
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = billModesID
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "Visit No"
                    Me.lblBillCustomerName.Text = "Patient Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "Account No"
                    Me.lblBillCustomerName.Text = "Account Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBillAccountNo.Text = "Insurance No"
                    Me.lblBillCustomerName.Text = "Insurance Name"
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillDetails(billModesID, payNo)
            Me.LoadInvoiceDetails(invoiceNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim message As String
        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oVariousOptions As New VariousOptions()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim lInvoices As New List(Of DBConnect)

            Dim payTypeID As String
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "To-Bill Account Category!")

            If billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                payTypeID = oPayTypeID.AccountBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                payTypeID = oPayTypeID.InsuranceBill
            ElseIf billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                payTypeID = oPayTypeID.VisitBill
            Else : payTypeID = String.Empty
            End If

            'If Me.chkReconciliationRequired.Checked AndAlso billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then

            '    message = "The Patient With VisitNo  (" + StringMayBeEnteredIn(Me.cboBillAccountNo) + ") has bills that require to be cleared " +
            '              "with the Account Balance Available on Account " +
            '              ", Please contact the Cashier to clear the Patient before Proceeding!!"
            '    Throw New ArgumentException(message)
            'End If



            Dim billNo As String = RevertText(StringEnteredIn(Me.cboBillAccountNo, Me.lblBillAccountNo.Text + "!"))

            With oInvoices

                .InvoiceNo = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
                .PayTypeID = payTypeID
                .PayNo = billNo
                .InvoiceDate = DateEnteredIn(Me.dtpInvoiceDate, "Invoice Date!")
                .StartDate = DateEnteredIn(Me.dtpStartDate, "Start Date!")
                .EndDate = DateEnteredIn(Me.dtpEndDate, "End Date!")
                .AmountWords = StringMayBeEnteredIn(Me.stbBPAmountWords)
                .VisitTypeID = oVisitTypeID.OutPatient
                .EntryModeID = oEntryModeID.Manual
                .Locked = False
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lInvoices.Add(oInvoices)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'If oInvoices.HasVisitInvoices(oInvoices.PayTypeID, oInvoices.PayNo, oInvoices.VisitTypeID, oInvoices.StartDate, oInvoices.EndDate) Then
                    '    If oVariousOptions.AllowCreateMultipleVisitInvoices Then
                    '        message = "You already have an invoice for this visit/bill. " +
                    '                  "If the previous invoice is no longer needed, it can be deleted via invoices edit sub menu." +
                    '                   ControlChars.NewLine + "Are you sure you want to save?"
                    '        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    '    Else
                    '        message = "You already have an invoice for this visit/bill. " +
                    '                  "If the previous invoice is no longer needed, it can be deleted via invoices edit sub menu. " +
                    '                  "The system is set not to allow multiple invoices on the same visit/bill. " +
                    '                  "Please contact the administrator if you still need to create this invoice."
                    '        Throw New ArgumentException(message)
                    '    End If
                    'End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInvoices, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InvoiceDetailsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.chkPrintInvoiceOnSaving.Checked Then
                        message = "You have not checked Print Invoice On Saving. " + ControlChars.NewLine + "Would you want an invoice printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintInvoice()
                    Else : Me.PrintInvoice()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "Invoice No : " + FormatText(oInvoices.InvoiceNo, "Invoices", "InvoiceNo") + ", was successfully Created!"
                    DisplayMessage(message)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.grpInvoiceDetails)
                    ResetControlsIn(Me.pnlNavigateVisits)
                    Me.pnlNavigateVisits.Visible = False
                    Me.lblRecordsNo.Text = String.Empty
                    Me.btnFindVisitNo.Enabled = False
                    Me.btnLoadPeriodicVisits.Enabled = False
                    Me.chkPrintInvoiceOnSaving.Checked = True
                    Me.lblLoadInvoices.Text = ""
                    Me.fbnLoadInvoices.Visible = False
                    Me.SetNextInvoiceNo()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInvoices, Action.Update, "Patients"))
                    transactions.Add(New TransactionList(Of DBConnect)(InvoiceDetailsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            If ex.Message.Contains("The Invoice No:") OrElse ex.Message.EndsWith("already exists") Then
                message = "The Invoice No: " + Me.stbInvoiceNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine +
                          "If you are using the system generated number, probably another user has already taken it." + ControlChars.NewLine +
                          "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextInvoiceNo()
            Else : ErrorMessage(ex)
            End If

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

   
    Private Function InvoiceDetailsList() As List(Of DBConnect)

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oObjectNames As New LookupDataID.AccessObjectNames()
        Dim lInvoiceDetails As New List(Of DBConnect)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim hasPendingItems As Boolean = False
            For Each row As DataGridViewRow In Me.dgvInvoiceDetails.Rows
                If row.IsNewRow Then Exit For
                Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colItemStatus)
                If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                    hasPendingItems = True
                    Exit For
                End If
                hasPendingItems = False
            Next

            If hasPendingItems Then
                If oVariousOptions.AllowProcessingPendingItems Then
                    message = "You have chosen to invoice pending service(s). " + ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
                Else : message = "The system is set not to allow invoicing pending service(s). Please contact your administrator!"
                    Throw New ArgumentException(message)
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVisitNo, "Visit No!"))
                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)

                Using oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()

                    With oInvoiceDetails
                        .InvoiceNo = invoiceNo
                        .VisitNo = visitNo
                        .ItemCode = itemCode
                        .ItemCategoryID = itemCategoryID
                        .Quantity = IntegerEnteredIn(cells, Me.colQuantity)
                        If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                              (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                            .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!")
                        Else : .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                        End If
                        .ObjectName = oObjectNames.Items

                        .Discount = DecimalEnteredIn(cells, Me.colDiscount, True, "discount!")
                        If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                              (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                            .Amount = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")
                        Else : .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                        End If

                    End With
                    lInvoiceDetails.Add(oInvoiceDetails)
                    
                End Using

            Next

            Return lInvoiceDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    

    Private Sub LoadInvoiceDetails(ByVal invoiceNo As String)

        Dim oVisitTypeID As New LookupDataID.VisitTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetRecordsControls()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoiceDetails As DataTable = oInvoiceDetails.GetInvoiceDetails(invoiceNo).Tables("InvoiceDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outPatientVisit As String = GetLookupDataDes(oVisitTypeID.OutPatient)
            If invoiceDetails Is Nothing OrElse invoiceDetails.Rows.Count < 1 Then Throw New ArgumentException("No " + outPatientVisit + " Record(s) found!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To InvoiceDetails.Rows.Count - 1

                Dim row As DataRow = InvoiceDetails.Rows(rowNo)

                With Me.dgvInvoiceDetails

                    .Rows.Add()

                    .Item(Me.colVisitNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "VisitNo"), "Visits", "VisitNo")
                    .Item(Me.colVisitDate.Name, rowNo).Value = FormatDate(DateEnteredIn(row, "VisitDate"))
                    .Item(Me.colPatientNo.Name, rowNo).Value = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
                    .Item(Me.colFullName.Name, rowNo).Value = StringEnteredIn(row, "FullName")
                    .Item(Me.colItemCode.Name, rowNo).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colItemName.Name, rowNo).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colCategory.Name, rowNo).Value = StringMayBeEnteredIn(row, "ItemCategory")
                    .Item(Me.colQuantity.Name, rowNo).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.ColMappedCode.Name, rowNo).Value = StringMayBeEnteredIn(row, "MappedCustomCode")

                    .Item(Me.colUnitPrice.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)
                    .Item(Me.colDiscount.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Discount"), AppData.DecimalPlaces)
                    .Item(Me.colItemStatus.Name, rowNo).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colMemberCardNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "MemberCardNo")
                    .Item(Me.colMainMemberName.Name, rowNo).Value = StringMayBeEnteredIn(row, "MainMemberName")
                    .Item(Me.colClaimReferenceNo.Name, rowNo).Value = StringMayBeEnteredIn(row, "ClaimReferenceNo")
                    .Item(Me.colBillCustomerName.Name, rowNo).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                    .Item(Me.colCoPayType.Name, rowNo).Value = StringMayBeEnteredIn(row, "CoPayType")
                    .Item(Me.colCoPayPercent.Name, rowNo).Value = SingleMayBeEnteredIn(row, "CoPayPercent")
                    .Item(Me.colCoPayValue.Name, rowNo).Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    .Item(Me.colItemCategoryID.Name, rowNo).Value = StringEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colSaved.Name, rowNo).Value = True

                End With

                Me.CalculateBillAmount(rowNo)

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = " Returned Record(s): " + InvoiceDetails.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateAccountTotalBill()
            Me.ebnSaveUpdate.Enabled = Me.dgvInvoiceDetails.RowCount > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Invoice Printing "

    Private Sub PrintInvoice()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oBillModesID As New LookupDataID.BillModesID()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInvoiceDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on invoice details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Me.SetVisitInvoicePrintData()

                Case oBillModesID.Account.ToUpper(), oBillModesID.Insurance.ToUpper()
                    Me.SetBillInvoicePrintData()

                Case Else : Me.SetVisitInvoicePrintData()

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInvoices
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInvoices.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInvoices_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInvoices.PrintPage

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Invoice".ToUpper()

            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbInvoiceNo)
            Dim billName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim invoiceDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpInvoiceDate))
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDate))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "Account Category!")
            Dim billNo As String = StringEnteredIn(Me.cboBillAccountNo, Me.lblBillAccountNo.Text + "!")

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    billNo = FormatText(billNo, "Visits", "VisitNo")

                Case oBillModesID.Account.ToUpper()
                    billNo = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()

                Case oBillModesID.Insurance.ToUpper()
                    billNo = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideInvoiceHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    Select Case billModesID.ToUpper()

                        Case oBillModesID.Cash.ToUpper()

                            .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(billName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            yPos += lineHeight

                            .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                            .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                            yPos += lineHeight

                            .DrawString("Invoive Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                            .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                            yPos += lineHeight

                            .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            .DrawString("To-Bill No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                            .DrawString(visitBillNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                            yPos += lineHeight

                            If Not String.IsNullOrEmpty(memberCardNo) Then
                                .DrawString("Member Card No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                                .DrawString(memberCardNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                                yPos += lineHeight
                            End If

                            If Not String.IsNullOrEmpty(mainMemberName) Then
                                .DrawString("Main Member Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                                .DrawString(mainMemberName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                                yPos += lineHeight
                            End If

                            If Not String.IsNullOrEmpty(claimReferenceNo) Then
                                .DrawString("Claim Reference No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                                .DrawString(claimReferenceNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                                yPos += lineHeight
                            End If

                            .DrawString("Ref. Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                            yPos += lineHeight

                            .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                            If Not String.IsNullOrEmpty(insuranceName) Then
                                yPos += lineHeight

                                .DrawString("Bill Insurance Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                                .DrawString(insuranceName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                            End If


                            If Not String.IsNullOrEmpty(oProductOwner.TINNo) Then

                                yPos += lineHeight
                                .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                                .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, 35 + widthTopFourth, yPos)


                            End If

                            yPos += 2 * lineHeight

                        Case oBillModesID.Account.ToUpper(), oBillModesID.Insurance.ToUpper()

                            .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(billName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                            yPos += lineHeight

                            .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            .DrawString("To-Bill No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                            .DrawString(billNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                            yPos += lineHeight

                            .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                            .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                            .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                            yPos += lineHeight

                            .DrawString("Invoive Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                            .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                            If Not String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso Not String.IsNullOrEmpty(oProductOwner.VATNo) Then

                                yPos += lineHeight

                                .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                                .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                                .DrawString("VAT No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                                .DrawString(oProductOwner.VATNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                            ElseIf Not String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso String.IsNullOrEmpty(oProductOwner.VATNo) Then

                                .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                                .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                            ElseIf String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso Not String.IsNullOrEmpty(oProductOwner.VATNo) Then

                                .DrawString("VAT No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                                .DrawString(oProductOwner.VATNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                            End If

                            yPos += 2 * lineHeight

                    End Select

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

                If invoiceParagraphs Is Nothing Then Return

                Do While invoiceParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(invoiceParagraphs(1), PrintParagraps)
                    invoiceParagraphs.Remove(1)

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
                        invoiceParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (invoiceParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetVisitInvoicePrintData()

        'Dim padItemNo As Integer = 4
        'Dim padItemName As Integer = 20
        'Dim padQuantity As Integer = 4
        'Dim padUnitPrice As Integer = 14
        'Dim padDiscount As Integer = 12
        'Dim padAmount As Integer = 16
        'Dim padTotalAmount As Integer = 56

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60

        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60





        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)
        Dim oVariousOptions As New VariousOptions()

        pageNo = 0
        invoiceParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim count As Integer
            Dim countExtra As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If chkPrintInvoiceDetailedOnSaving.Checked = True Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Discount: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadRight(padAmount))

                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    'Dim itemcode As String = cells.Item(Me.ColMappedCode.Name).Value.ToString()
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colDisplayAmount.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))

                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            'tableData.Append(itemcode.PadLeft(padAmount))
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(discount.PadLeft(padDiscount))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        'tableData.Append(itemcode.PadLeft(padAmount))
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(discount.PadLeft(padDiscount))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If

                    tableData.Append(ControlChars.NewLine)
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.PrintItemCodesOnInvoices Then

                    tableHeader.Append("Code: ".PadRight(padICItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padICItemName))
                    tableHeader.Append("Qty: ".PadLeft(padICQuantity))
                    tableHeader.Append("Unit Price: ".PadLeft(padICUnitPrice))
                    'tableHeader.Append("Disc: ".PadLeft(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padICAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        'Dim itemNo As String = (count).ToString()
                        Dim itemNo As String = cells.Item(Me.colItemCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        'Dim discount As String = cells.Item(Me.ColMappedCode.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colDisplayAmount.Name).Value.ToString()

                        tableData.Append(itemNo.PadRight(padICItemNo))

                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padICItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                'tableData.Append(itemcode.PadLeft(padICAmount))
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padICItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padICItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padICQuantity))
                                    tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                                    'tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padICAmount))
                                End If
                            Next

                        Else
                            'tableData.Append(itemcode.PadLeft(padAmount))
                            tableData.Append(FixDataLength(itemName, padICItemName))
                            tableData.Append(quantity.PadLeft(padICQuantity))
                            tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                            'tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padICAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    For Each item In invoiceDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                        tableData.Append(itemNo.PadRight(padItemNo))

                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                        Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                        End If
                        tableData.Append(categoryAmount.PadLeft(padAmount))
                        tableData.Append(ControlChars.NewLine)

                    Next
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim invoiceDetailQuantities = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    For Each item In invoiceDetails
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        tableData.Append(GetSpaces(padItemNo))
                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                        Else : tableData.Append(categoryName.PadRight(padItemName))
                        End If
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)

                        Dim categorizedInvoiceDetails = (From data In Me.GetCategorizedInvoiceDetails Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                        itemDiscount = data.Item5, itemAmount = data.Item6 Into CategoryAmount2 = Sum(data.Item6) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemDiscount, itemAmount Where
                                        CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                        CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                        For Each categorizedItem In categorizedInvoiceDetails
                            countExtra += 1
                            Dim categorizedItemNo As String = (countExtra).ToString()
                            Dim itemName As String = categorizedItem.itemName
                            Dim categorizedInvoiceDetailQuantity = From data In Me.GetCategorizedInvoiceDetails Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                   Select totalQuantity, Item2
                                                                   Where Item2 = itemName

                            Dim itemQuantity As String = categorizedInvoiceDetailQuantity.ElementAt(0).totalQuantity.ToString
                            Dim ItemUnitPrice As String = FormatNumber(categorizedItem.itemUnitPrice, AppData.DecimalPlaces)
                            Dim itemDiscount As String = FormatNumber(categorizedItem.itemDiscount, AppData.DecimalPlaces)
                            Dim itemAmount As String = FormatNumber(categorizedItem.itemAmount, AppData.DecimalPlaces)

                            tableData.Append(categorizedItemNo.PadRight(padItemNo))

                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padItemNo))
                                    Else
                                        tableData.Append(itemQuantity.PadLeft(padQuantity))
                                        tableData.Append(itemAmount.PadLeft(padAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padItemName))
                                tableData.Append(itemQuantity.PadLeft(padQuantity))
                                tableData.Append(itemAmount.PadLeft(padAmount))
                            End If
                            tableData.Append(ControlChars.NewLine)
                        Next
                        tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                        tableData.Append(categoryAmount.PadLeft(padAmount + 41))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)
                        countExtra = 0
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                Else

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                    tableHeader.Append("Discount: ".PadLeft(padDiscount))
                    tableHeader.Append("Amount: ".PadRight(padAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        'Dim itemcode As String = cells.Item(Me.ColMappedCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colDisplayAmount.Name).Value.ToString()

                        tableData.Append(itemNo.PadRight(padItemNo))

                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                'tableData.Append(itemcode.PadLeft(padAmount))
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padQuantity))
                                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                    tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padAmount))
                                End If
                            Next

                        Else
                            'tableData.Append(itemcode.PadLeft(padAmount))
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(quantity.PadLeft(padQuantity))
                            tableData.Append(unitPrice.PadLeft(padUnitPrice))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If


            End If

            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            Dim totalAmount As Decimal = GetTotalAmount()
            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then

                Dim coPayAmount As Decimal = CDec(totalAmount * coPayPercent) / 100
                Dim balanceDue As Decimal = totalAmount - coPayAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim coPayAmountData As New System.Text.StringBuilder(String.Empty)
                coPayAmountData.Append("Co-Pay Amount: ")
                coPayAmountData.Append(FormatNumber(coPayAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 1))
                coPayAmountData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, coPayAmountData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueData As New System.Text.StringBuilder(String.Empty)
                balanceDueData.Append("Balance Due: ")
                balanceDueData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount + 1))
                balanceDueData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceDueData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueWordsData As New System.Text.StringBuilder(String.Empty)
                balanceDueWordsData.Append("(" + NumberToWords(balanceDue).Trim() + " ONLY)")
                balanceDueWordsData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, balanceDueWordsData.ToString()))

            Else
                Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
                Dim amountWords As String = StringMayBeEnteredIn(Me.stbBPAmountWords)
                totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
                totalAmountWords.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.DisablePatientSignOnInvoices Then

                Dim patientSignData As New System.Text.StringBuilder(String.Empty)
                patientSignData.Append(ControlChars.NewLine)

                patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
                patientSignData.Append(GetSpaces(4))
                patientSignData.Append("Date:  " + GetCharacters("."c, 20))
                patientSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
                checkedSignData.Append(ControlChars.NewLine)

                checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                checkedSignData.Append(GetSpaces(4))
                checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                checkedSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetInvoiceDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Private Function GetInvoiceDetailsListExtra() As List(Of Tuple(Of String, String, String, Decimal))

    '    Try

    '        ' Create list of tuples with two items each.
    '        Dim invoiceDetailsExtra As New List(Of Tuple(Of String, String, String, Decimal))

    '        For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

    '            Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
    '            Dim patientNo As String = cells.Item(Me.colPatientNo.Name).Value.ToString()
    '            Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
    '            Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
    '            Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

    '            invoiceDetailsExtra.Add(New Tuple(Of String, String, String, Decimal)(patientNo, category, itemName, amount))

    '        Next

    '        Return invoiceDetailsExtra

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    Private Function GetCategorizedInvoiceDetails() As List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetailsExtra2 As New List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unitPrice!")
                Dim discount As Decimal = DecimalEnteredIn(cells, Me.colDiscount, True, "discount!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

                invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal, Decimal)(category, itemName, quantity, unitPrice, discount, amount))

            Next

            Return invoiceDetailsExtra2

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Sub SetBillInvoicePrintData()

        Dim padVisitNo As Integer = 13
        Dim padVisitDate As Integer = 10
        Dim padFullName As Integer = 20
        Dim padMemberCardNo As Integer = 12
        Dim padAmount As Integer = 14
        Dim padTotalAmount As Integer = 57

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20
        Dim padItemsAmountExtra As Integer = 46

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()

        Dim oVariousOptions As New VariousOptions()


        Try
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.HideCashPaymentReceiptDetails Then
                ' Header goes here!

            Else
                Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()

                ' Dim tableHeader As New System.Text.StringBuilder(String.Empty)
                tableHeader.Append("Visit No: ".PadRight(padVisitNo))
                tableHeader.Append("Visit Date: ".PadRight(padVisitDate))
                tableHeader.Append("Patient's Name: ".PadRight(padFullName))
                tableHeader.Append("Member No: ".PadRight(padMemberCardNo))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                'Dim tableData As New System.Text.StringBuilder(String.Empty)

                Dim invoiceNo As String = RevertText(StringEnteredIn(Me.stbInvoiceNo, "Invoice No!"))
                Dim invoiceBillDetails As DataTable = oInvoiceDetails.GetInvoiceBillDetails(invoiceNo).Tables("InvoiceDetails")

                For Each row As DataRow In invoiceBillDetails.Rows

                    Dim visitNo As String = StringMayBeEnteredIn(row, "VisitNo")
                    Dim visitDate As String = StringMayBeEnteredIn(row, "VisitDate")
                    Dim fullName As String = StringMayBeEnteredIn(row, "FullName")
                    Dim memberCardNo As String = StringMayBeEnteredIn(row, "MemberCardNo")
                    Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(row, "VisitAmount"), AppData.DecimalPlaces)

                    tableData.Append(visitNo.PadRight(padVisitNo))
                    tableData.Append(visitDate.PadRight(padVisitDate))
                    If fullName.Length > 20 Then
                        tableData.Append(fullName.Substring(0, 19).PadRight(padFullName))
                    Else : tableData.Append(fullName.PadRight(padFullName))
                    End If

                    Dim wrappedMemberCardNo As List(Of String) = WrapText(memberCardNo, padMemberCardNo)
                    If wrappedMemberCardNo.Count > 1 Then
                        For pos As Integer = 0 To wrappedMemberCardNo.Count - 1
                            tableData.Append(FixDataLength(wrappedMemberCardNo(pos).Trim(), padMemberCardNo))
                            If Not pos = wrappedMemberCardNo.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(2 + padVisitNo + padVisitDate + padFullName))
                            Else : tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next
                    Else
                        tableData.Append(FixDataLength(memberCardNo, padMemberCardNo))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If
                    tableData.Append(ControlChars.NewLine)
                Next

                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

                Dim totalAmount As New System.Text.StringBuilder(String.Empty)
                totalAmount.Append(ControlChars.NewLine)
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(Me.stbBPTotalBill.Text.ToString().PadLeft(padTotalAmount))
                totalAmount.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

                Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
                Dim amountWords As String = StringMayBeEnteredIn(Me.stbBPAmountWords)
                totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
                totalAmountWords.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

                Dim footerData As New System.Text.StringBuilder(String.Empty)
                footerData.Append(ControlChars.NewLine)
                footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                                  Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
                footerData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Invoice Details Extras "

    Private Sub dgvInvoiceDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvInvoiceDetails.DoubleClick

        Try

            If Me.btnAddExtraCharge.Enabled = False Then Return
            btnAddExtraCharge_Click(Me, EventArgs.Empty)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsInvoiceDetails_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInvoiceDetails.Opening

        If Me.dgvInvoiceDetails.ColumnCount < 1 OrElse Me.dgvInvoiceDetails.RowCount < 1 Then
            Me.cmsInvoiceDetailsCopy.Enabled = False
            Me.cmsInvoiceDetailsSelectAll.Enabled = False
            Me.cmsInvoiceDetailsAddExtraCharge.Enabled = False
            Me.cmsInvoiceDetailsEditVisit.Enabled = False
            Me.cmsInvoiceDetailsEditBill.Enabled = False
        Else
            Me.cmsInvoiceDetailsCopy.Enabled = True
            Me.cmsInvoiceDetailsSelectAll.Enabled = True
            Me.cmsInvoiceDetailsAddExtraCharge.Enabled = Me.btnAddExtraCharge.Enabled
            Me.cmsInvoiceDetailsEditVisit.Enabled = True
            Me.cmsInvoiceDetailsEditBill.Enabled = True
            Security.Apply(Me.cmsInvoiceDetails, AccessRights.Edit)
        End If

    End Sub

    Private Sub cmsInvoiceDetailsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvInvoiceDetails.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvInvoiceDetails))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvInvoiceDetails.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsAddExtraCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsAddExtraCharge.Click

        Try

            If Me.btnAddExtraCharge.Enabled = False Then Return
            btnAddExtraCharge_Click(Me, EventArgs.Empty)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsInvoiceDetailsEditVisit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsEditVisit.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowIndex As Integer = Me.dgvInvoiceDetails.CurrentCell.RowIndex
            Dim visitNo As String = RevertText(StringEnteredIn(Me.dgvInvoiceDetails.Rows(rowIndex).Cells, Me.colVisitNo, "Visit No!"))

            Dim fVisits As New frmVisits(visitNo, ItemsKeyNo.VisitNo)
            fVisits.Edit()
            fVisits.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
            Dim message As String = "Would you like to Re-Load Bill?"
            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.LoadBillItems()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsEditBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsEditBill.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowIndex As Integer = Me.dgvInvoiceDetails.CurrentCell.RowIndex
            Dim visitNo As String = RevertText(StringEnteredIn(Me.dgvInvoiceDetails.Rows(rowIndex).Cells, Me.colVisitNo, "Visit No!"))

            Dim fSelfRequests As New frmSelfRequests(visitNo)
            fSelfRequests.Edit()
            fSelfRequests.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "Would you like to Re-Load Bill?"
            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.LoadBillItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.stbInvoiceNo.ReadOnly = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlPeriod)
        ResetControlsIn(Me.grpInvoiceDetails)
        ResetControlsIn(Me.pnlNavigateVisits)
        '
        Me.EnableInvoiceCTLS(False)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbInvoiceNo.ReadOnly = InitOptions.InvoiceNoLocked

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpInvoiceDetails)
        ResetControlsIn(Me.pnlNavigateVisits)
        Me.SetNextInvoiceNo()

        Me.EnableInvoiceCTLS(True)

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

    Private Sub EnableInvoiceCTLS(ByVal state As Boolean)

        Me.grpSetParameters.Enabled = state
        Me.lblRecordsNo.Text = String.Empty
        Me.EnablePeriodCTLS(state)
        Me.cboBillModesID.Enabled = state
        Me.cboBillAccountNo.Enabled = state
        Me.btnFindVisitNo.Visible = state
        Me.btnLoadPeriodicVisits.Visible = state
        Me.btnAddExtraCharge.Enabled = False
        Me.pnlNavigateVisits.Visible = False

        Me.chkPrintInvoiceOnSaving.Checked = state
        Me.chkPrintInvoiceOnSaving.Visible = state

    End Sub

    Private Sub EnablePeriodCTLS(ByVal state As Boolean)

        If state AndAlso Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            Me.dtpStartDate.Value = Today.AddDays(-1)
            Me.dtpEndDate.Value = Today
        End If

        Me.dtpStartDate.Checked = state
        Me.dtpEndDate.Checked = state
        Me.pnlPeriod.Enabled = state

    End Sub

#End Region

#Region " Security Method "

    Private Sub ApplySecurity()

        Try
            If Me.btnAddExtraCharge.Enabled Then Security.Apply(Me.btnAddExtraCharge, AccessRights.Write)
           
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    Private Sub ShowGeneratedInvoiceControl(billNo As String, show As Boolean)
        Try
            Dim oItems As New SyncSoft.SQLDb.Items()
            Me.Cursor = Cursors.WaitCursor
            Dim items As DataTable = oItems.GetVisitItemsByInvoiceStatus(billNo, True).Tables("Items")
            Dim returnedItems As Integer = items.Rows.Count

            If Not show Then
                Me.fbnLoadInvoices.Visible = False
                Me.lblLoadInvoices.Visible = False
                Me.lblLoadInvoices.Text = String.Empty
            Else

                If returnedItems > 0 Then
                    Me.fbnLoadInvoices.Visible = True
                    Me.fbnLoadInvoices.Enabled = True
                    Me.lblLoadInvoices.Visible = True
                    Me.lblLoadInvoices.Text = "Previous Invoiced OPD Item(s): " + returnedItems.ToString
                Else
                    Me.fbnLoadInvoices.Visible = False
                    Me.lblLoadInvoices.Visible = False
                    Me.lblLoadInvoices.Text = String.Empty
                End If

            End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub fbnLoadInvoices_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoadInvoices.Click
        Dim visitNo As String = StringMayBeEnteredIn(cboBillAccountNo)
        If String.IsNullOrEmpty(visitNo) Then Return
        Dim fVisitInvoice As New frmVisitInvoices(visitNo, oVisitTypeID.OutPatient)
        fVisitInvoice.Show()
    End Sub


    Private Function GetTotalAmount() As Decimal
        Try
            Dim totalAmount As Decimal = 0
            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVisitNo, "Visit No!"))
                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                Dim discount = DecimalEnteredIn(cells, Me.colDiscount, False, "Discount!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                Dim unitPrice As Decimal = 0
                Dim amount As Decimal = 0



                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                              (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                    unitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!")
                Else
                    unitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                End If

                amount = (DecimalEnteredIn(cells, Me.colQuantity, False, "Quantity!") * unitPrice) - discount
                totalAmount += amount
            Next
            Return totalAmount
        Catch ex As Exception
            Throw ex
        End Try

    End Function

End Class