
Option Strict On
Option Infer On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic
Imports SyncSoft.Common.Structures
Imports System.Drawing.Printing


Public Class frmOPDStaffPaymentDetails

#Region " Fields "
    Private listCount As Integer = 0
    Private WithEvents docVoucher As New PrintDocument()
    ' The paragraphs.
    Private voucherParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomers As DataTable
    Private insuranceCompanies As DataTable
#End Region

    Private Sub frmOPDStaffPaymentDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()


            'LoadLookupDataCombo(Me.colOPDVoucherCompletePayment, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboItemStatus, LookupObjects.ItemStatus, True)
            LoadLookupDataCombo(Me.clbItemCategory, LookupObjects.ItemCategory, False)
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboStaffTitle, LookupObjects.StaffTitle, False)
            'Me.LoadStaff()

            Me.SetNextPaymentVouchertNo(Me.stbPaymentVoucherNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Add(" ")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbPaymentVoucherNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPaymentVoucherNo.Enter
        'Me.SetNextPaymentVouchertNo(Me.stbPaymentVoucherNo)
    End Sub

    Private Sub SetNextPaymentVouchertNo(ByVal sourceControl As TextBox)

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("StaffPayments", "PaymentVoucherNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim PaymentVouchertNo As String = yearL2 + oStaffPayments.GetNextPaymentVoucherID.ToString().PadLeft(paddingLEN, paddingCHAR)

            sourceControl.Text = FormatText(PaymentVouchertNo, "StaffPayments", "PaymentVoucherNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboStaffNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStaffNo.SelectedIndexChanged
        Dim staff As DataTable
        Dim oStaff As New SyncSoft.SQLDb.Staff
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")

            staff = oStaff.GetStaff(staffNo).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim row As DataRow = staff.Rows(0)

            Me.stbFirstName.Text = StringMayBeEnteredIn(row, "FirstName")
            Me.stbLastName.Text = StringMayBeEnteredIn(row, "LastName")
            Me.stbGender.Text = StringMayBeEnteredIn(row, "Gender")
            Me.stbStaffTitle.Text = StringMayBeEnteredIn(row, "StaffTitle")
            Me.stbSpeciality.Text = StringMayBeEnteredIn(row, "Speciality")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Dim voucherItems As New DataTable
        Dim staff As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
        Dim oStaff As New SyncSoft.SQLDb.Staff
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim itemCategoryID As String = StringToSplitSelectedInAtleastOne(Me.clbItemCategory, LookupObjects.ItemCategory, "Item CategoryID!")
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Modes!")
            Dim itemStatusID As String = StringValueMayBeEnteredIn(Me.cboItemStatus, "item StatusID!")
            Dim staffTitleID As String = StringValueEnteredIn(Me.cboStaffTitle, "Staff Title!")

            Me.SetNextPaymentVouchertNo(Me.stbPaymentVoucherNo)
            Me.lblRecordsNo.Text = String.Empty
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")

            If staffTitleID = oStaffTitleID.Doctor Then
                Select Case billModesID.ToUpper()

                    Case oBillModesID.Cash.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        voucherItems = oStaffPayments.GetVoucherPaymentDetails(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                               oVisitTypeID.OutPatient, itemStatusID, String.Empty, String.Empty).Tables("voucherItems")

                    Case oBillModesID.Account.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo)))
                        voucherItems = oStaffPayments.GetVoucherPaymentDetails(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                               oVisitTypeID.OutPatient, itemStatusID, accountNo, String.Empty).Tables("voucherItems")

                    Case oBillModesID.Insurance.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim accountNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboAccountNo, "Account No!")))
                        Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

                        If (String.IsNullOrEmpty(companyNo)) Then
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            voucherItems = oStaffPayments.GetVoucherPaymentDetails(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                                   oVisitTypeID.OutPatient, itemStatusID, accountNo, String.Empty).Tables("voucherItems")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Else
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            voucherItems = oStaffPayments.GetVoucherPaymentDetails(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                                   oVisitTypeID.OutPatient, itemStatusID, accountNo, companyNo).Tables("voucherItems")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                End Select

            Else

                Select Case billModesID.ToUpper()

                    Case oBillModesID.Cash.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        voucherItems = oStaffPayments.GetVoucherPaymentDetailsExt(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                               oVisitTypeID.OutPatient, itemStatusID, String.Empty, String.Empty).Tables("voucherItems")

                    Case oBillModesID.Account.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo)))
                        voucherItems = oStaffPayments.GetVoucherPaymentDetailsExt(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                               oVisitTypeID.OutPatient, itemStatusID, accountNo, String.Empty).Tables("voucherItems")

                    Case oBillModesID.Insurance.ToUpper()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim accountNo As String = RevertText(SubstringRight(StringEnteredIn(Me.cboAccountNo, "Account No!")))
                        Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

                        If (String.IsNullOrEmpty(companyNo)) Then
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            voucherItems = oStaffPayments.GetVoucherPaymentDetailsExt(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                                   oVisitTypeID.OutPatient, itemStatusID, accountNo, String.Empty).Tables("voucherItems")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Else
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            voucherItems = oStaffPayments.GetVoucherPaymentDetailsExt(staffNo, startDateTime, endDateTime, itemCategoryID, billModesID,
                                                                                   oVisitTypeID.OutPatient, itemStatusID, accountNo, companyNo).Tables("voucherItems")
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                End Select

            End If

            staff = oStaff.GetStaff(staffNo).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvOPDVoucherDetails.Rows.Clear()
            Me.stbAmountInWords.Text = String.Empty
            Me.stbTotalAmount.Text = String.Empty
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim message As String

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDateTime(CDate(startDateTime)) + " and " + FormatDateTime(CDate(endDateTime)) + "!"
                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If voucherItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + voucherItems.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If voucherItems Is Nothing OrElse voucherItems.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To voucherItems.Rows.Count - 1

                Dim row As DataRow = voucherItems.Rows(pos)

                With Me.dgvOPDVoucherDetails
                    ' Ensure that you add a new row-
                    .Rows.Add()
                    .Item(Me.colOPDVoucherPatientNo.Name, pos).Value = StringEnteredIn(row, "PatientNo")
                    .Item(Me.colOPDVoucherFullName.Name, pos).Value = StringEnteredIn(row, "FullName")
                    .Item(Me.colOPDVoucherVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    '.Item(Me.colOPDVoucherExtraBillNo.Name, pos).Value = StringEnteredIn(row, "ExtraBillNo")
                    '.Item(Me.colOPDVoucherRoundNo.Name, pos).Value = StringEnteredIn(row, "RoundNo")
                    .Item(Me.colOPDVoucherVisitDate.Name, pos).Value = DateMayBeEnteredIn(row, "VisitDate")
                    .Item(Me.colOPDVoucherVisitStatus.Name, pos).Value = StringEnteredIn(row, "VisitStatus")
                    .Item(Me.colOPDVoucherVisitCategory.Name, pos).Value = StringEnteredIn(row, "VisitCategory")
                    .Item(Me.colOPDVoucherItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colOPDVoucherItemCategoryID.Name, pos).Value = StringEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colOPDVoucherItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colOPDVoucherItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colOPDVoucherItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colOPDVoucherPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colOPDVoucherQuantity.Name, pos).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.colOPDVoucherUnitPrice.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colOPDVoucherTotalFee.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalFee", True), AppData.DecimalPlaces)
                    .Item(Me.colOPDVoucherToBillCustomerName.Name, pos).Value = StringMayBeEnteredIn(row, "BillCustomerName")
                    .Item(Me.colOPDVoucherToBillCustomerNo.Name, pos).Value = StringMayBeEnteredIn(row, "BillNo")

                End With

            Next

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOPDVoucherDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOPDVoucherDetails.CellEndEdit
        If e.ColumnIndex.Equals(Me.colOPDVoucherAmount.Index) Then
            Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, Me.dgvOPDVoucherDetails.CurrentCell.RowIndex).Value = FormatNumber(CDec(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, Me.dgvOPDVoucherDetails.CurrentCell.RowIndex).Value), AppData.DecimalPlaces)
        End If
        Me.calculateTotals()
    End Sub

    Private Sub cmsAlertListIncludeAll_Click(sender As Object, e As EventArgs) Handles cmsAlertListIncludeAll.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcVoucherDetails.SelectedTab.Name
                Case Me.tpgOPDVoucherDetails.Name
                    For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, row.Index).Value = True
                    Next
                    If Me.chkApplyPercentage.Checked = True Then
                        Me.nbxApplyPercentage_Leave(sender, e)
                    End If
                    Me.calculateTotals()
            End Select
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListIncludeNone_Click(sender As Object, e As EventArgs) Handles cmsAlertListIncludeNone.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Select Case Me.tbcVoucherDetails.SelectedTab.Name
                Case Me.tpgOPDVoucherDetails.Name
                    For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, row.Index).Value = False
                    Next
                    Me.calculateTotals()
            End Select
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub calculateTotals()
        Try

            Select Case Me.tbcVoucherDetails.SelectedTab.Name
                Case Me.tpgOPDVoucherDetails.Name
                    Dim TotalOPDVoucherAmount As Decimal
                    For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                        If row.IsNewRow Then Exit For
                        If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, row.Index).Value) = True Then
                            TotalOPDVoucherAmount += DecimalMayBeEnteredIn(row.Cells, Me.colOPDVoucherAmount)
                        End If
                    Next
                    Me.stbTotalAmount.Text = FormatNumber(TotalOPDVoucherAmount, AppData.DecimalPlaces)
                    Me.stbAmountInWords.Text = NumberToWords(TotalOPDVoucherAmount)
            End Select
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub frmOPDStaffPaymentDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oOPDStaffPaymentDetails.PaymentVoucherNo = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment VoucherNo!"))
            oStaffPayments.PaymentVoucherNo = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment VoucherNo!"))

            DisplayMessage(oOPDStaffPaymentDetails.Delete() + " " + oStaffPayments.Delete)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboStaffNo.Text = String.Empty
            Me.dgvOPDVoucherDetails.Rows.Clear()
            Me.stbTotalAmount.Text = String.Empty
            Me.stbAmountInWords.Text = String.Empty
            Me.nbxApplyPercentage.Text = String.Empty
            Me.chkApplyPercentage.Checked = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.grpSetParameters)

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim paymentVoucherNo As String
        Dim oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
        Dim voucherItems As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
        Dim oStaff As New SyncSoft.SQLDb.Staff
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oclaimStatusID = New LookupDataID.ClaimStatusID
        Dim staff As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor()

            paymentVoucherNo = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment VoucherNo!"))

            Dim dataSource As DataTable = oStaffPayments.GetStaffPayments(paymentVoucherNo).Tables("StaffPayments")
            Me.DisplayData(dataSource)
            Dim dataSourceRow As DataRow = dataSource.Rows(0)
            If StringMayBeEnteredIn(dataSourceRow, "VoucherStatusID") = oclaimStatusID.Approved Then
                DisplayMessage("This Payment Voucher has already been approved and can not be edited!")
                Me.ebnSaveUpdate.Enabled = False
                Me.fbnDelete.Enabled = False
                Me.colOPDVoucherAmount.ReadOnly = True
                'Exit Sub
            Else
                'Me.ebnSaveUpdate.Enabled = True
                Me.ebnSaveUpdate.Enabled = True
                Me.fbnDelete.Enabled = True
                Me.colOPDVoucherAmount.ReadOnly = False
            End If

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim billModeID As String = StringValueEnteredIn(Me.cboBillModesID, "Bill ModesID")

            Me.lblRecordsNo.Text = String.Empty
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")

            staff = oStaff.GetStaff(staffNo).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim StaffRow As DataRow = staff.Rows(0)

            Me.stbFirstName.Text = StringMayBeEnteredIn(StaffRow, "FirstName")
            Me.stbLastName.Text = StringMayBeEnteredIn(StaffRow, "LastName")
            Me.stbGender.Text = StringMayBeEnteredIn(StaffRow, "Gender")
            Me.stbStaffTitle.Text = StringMayBeEnteredIn(StaffRow, "StaffTitle")
            Me.stbSpeciality.Text = StringMayBeEnteredIn(StaffRow, "Speciality")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            voucherItems = oStaffPayments.GetPendingVoucherPaymentDetails(staffNo, startDateTime, endDateTime, paymentVoucherNo, billModeID, oVisitTypeID.OutPatient).Tables("voucherItems")
            Me.dgvOPDVoucherDetails.Rows.Clear()

            Dim message As String

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDateTime(CDate(startDateTime)) + " and " + FormatDateTime(CDate(endDateTime)) + "!"
                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If voucherItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + voucherItems.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If voucherItems Is Nothing OrElse voucherItems.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To voucherItems.Rows.Count - 1

                Dim row As DataRow = voucherItems.Rows(pos)

                With Me.dgvOPDVoucherDetails
                    ' Ensure that you add a new row-
                    .Rows.Add()
                    .Item(Me.colOPDVoucherInclude.Name, pos).Value = True
                    .Item(Me.colOPDVoucherPatientNo.Name, pos).Value = StringEnteredIn(row, "PatientNo")
                    .Item(Me.colOPDVoucherFullName.Name, pos).Value = StringEnteredIn(row, "FullName")
                    .Item(Me.colOPDVoucherVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                    '.Item(Me.colOPDVoucherExtraBillNo.Name, pos).Value = StringEnteredIn(row, "ExtraBillNo")
                    '.Item(Me.colOPDVoucherRoundNo.Name, pos).Value = StringEnteredIn(row, "RoundNo")
                    .Item(Me.colOPDVoucherVisitDate.Name, pos).Value = DateMayBeEnteredIn(row, "VisitDate")
                    .Item(Me.colOPDVoucherVisitStatus.Name, pos).Value = StringEnteredIn(row, "VisitStatus")
                    .Item(Me.colOPDVoucherVisitCategory.Name, pos).Value = StringEnteredIn(row, "VisitCategory")
                    .Item(Me.colOPDVoucherItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                    .Item(Me.colOPDVoucherItemCategoryID.Name, pos).Value = StringEnteredIn(row, "ItemCategoryID")
                    .Item(Me.colOPDVoucherItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colOPDVoucherItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colOPDVoucherItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colOPDVoucherPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colOPDVoucherQuantity.Name, pos).Value = IntegerMayBeEnteredIn(row, "Quantity")
                    .Item(Me.colOPDVoucherUnitPrice.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colOPDVoucherTotalFee.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalFee", True), AppData.DecimalPlaces)

                    If (DecimalMayBeEnteredIn(row, "Amount") = Nothing) Then
                        .Item(Me.colOPDVoucherAmount.Name, pos).Value = 0
                    Else
                        .Item(Me.colOPDVoucherAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount", True), AppData.DecimalPlaces)
                    End If
                End With

            Next
            Me.calculateTotals()
            'Me.ebnSaveUpdate.Enabled = True
            'Me.fbnDelete.Enabled = True
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim message As String

        Try
            Me.Cursor = Cursors.WaitCursor()

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(Me.StaffPaymentsList, Action.Save))
                    If Me.listCount = 0 Then
                    Else
                        records = DoTransactions(transactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not Me.chkPrintVoucherOnSaving.Checked Then
                            message = "You have not checked Print Voucher On Saving. " + ControlChars.NewLine + "Would you want a Voucher printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintVoucher()
                        Else : Me.PrintVoucher()
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End If
                    DisplayMessage(records.ToString() + " record(s) Saved!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblRecordsNo.Text = String.Empty
                    Me.dtpStartDate.Checked = False
                    Me.dtpEndDate.Checked = False
                    Me.cboStaffNo.Text = String.Empty
                    Me.nbxApplyPercentage.Text = String.Empty
                    Me.chkApplyPercentage.Checked = False
                    Me.dgvOPDVoucherDetails.Rows.Clear()
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.grpSetParameters)
                    Me.SetNextPaymentVouchertNo(Me.stbPaymentVoucherNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(Me.UpdateStaffPaymentsList, Action.Update))
                    If Me.listCount = 0 Then
                    Else
                        records = DoTransactions(transactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not Me.chkPrintVoucherOnSaving.Checked Then
                            message = "You have not checked Print Voucher On Saving. " + ControlChars.NewLine + "Would you want a Voucher printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintVoucher()
                        Else : Me.PrintVoucher()
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    DisplayMessage(records.ToString() + " record(s) Updated!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOPDVoucherDetails.Rows.Clear()
                    Me.lblRecordsNo.Text = String.Empty
                    Me.stbPaymentVoucherNo.Text = String.Empty
                    Me.dtpStartDate.Checked = False
                    Me.dtpEndDate.Checked = False
                    Me.cboStaffNo.Text = String.Empty
                    Me.nbxApplyPercentage.Text = String.Empty
                    Me.chkApplyPercentage.Checked = False
                    Me.dgvOPDVoucherDetails.Rows.Clear()
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.grpSetParameters)
                    Me.CallOnKeyEdit()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            End Select


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function StaffPaymentsList() As List(Of DBConnect)
        'xxx()
        Dim message As String
        Dim nonSelected As Boolean = False
        Dim hasAmountValue As Boolean = False
        Dim lStaffPaymentsList As New List(Of DBConnect)
        Dim oVisitTypeID As New LookupDataID.VisitTypeID
        Dim oVisitStatusID As New LookupDataID.VisitStatusID
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID

        Try
            Dim PaymentVoucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment Voucher No!"))

            For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                Dim cells As DataGridViewCellCollection = Me.dgvOPDVoucherDetails.Rows(row.Index).Cells
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    If (DecimalMayBeEnteredIn(cells, Me.colOPDVoucherAmount, False) > 0) Then
                        hasAmountValue = True
                        Exit For
                    End If

                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvOPDVoucherDetails.RowCount < 1 OrElse nonSelected OrElse (hasAmountValue = False) Then Throw New ArgumentException("Must include at least one entry on payment details With Correct Amount!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
            With oStaffPayments

                .PaymentVoucherNo = paymentVoucherNo
                .VisitTypeID = oVisitTypeID.OutPatient
                .StartDateTime = DateTimeEnteredIn(Me.dtpStartDate, "StartDate!")
                .EndDateTime = DateTimeEnteredIn(Me.dtpEndDate, "EndDate!")
                .BillModesID = StringValueEnteredIn(Me.cboBillModesID, "Bill ModesID!")
                .StaffNo = SubstringRight(StringMayBeEnteredIn(Me.cboStaffNo)).ToUpper()
                .VoucherStatusID = oClaimStatusID.NotApproved
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With
            oStaffPayments.Save()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvOPDVoucherDetails.RowCount - 1

                If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDVoucherDetails.Rows(rowNo).Cells
                    Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherVisitNo, "Visit No!"))
                    'Dim roundNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherRoundNo, "Round No!"))
                    'Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherExtraBillNo, "extra Bill No!"))
                    Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherItemCode, "Item Code!"))
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colOPDVoucherItemCategoryId, "Item CategoryId!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOPDVoucherAmount, True, "Amount")
                    'Dim staffNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboStaffNo)).ToUpper()
                    'Dim PaymentVoucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment Voucher No!"))
                    'Dim CompletePayment As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherCompletePayment, "Full Payment!"))
                    'Dim PaymentDateTime As DateTime = DateTimeEnteredIn(Me.dtpPaymentDateTime, "Payment Date & Time!")


                    Using oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
                        With oOPDStaffPaymentDetails

                            .PaymentVoucherNo = PaymentVoucherNo
                            .VisitNo = visitNo
                            '.RoundNo = roundNo
                            '.ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Amount = amount
                            .ApprovalStatusID = oClaimStatusID.Pending
                            .ApprovalNotes = String.Empty
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With


                        If StringMayBeEnteredIn(cells, Me.colOPDVoucherVisitStatus) = GetLookupDataDes(oVisitStatusID.Doctor) Then
                            'If GetLookupDataID(StringMayBeEnteredIn(cells, Me.colVisitStatus).ToString) = oVisitStatusID.Doctor.ToUpper Then
                            message = "The VisitNo " + visitNo + " with visitState " + StringMayBeEnteredIn(cells, Me.colOPDVoucherVisitStatus) + " has not been seen by the this doctor. " +
                                 ControlChars.NewLine + "Are you sure you want to pay this Doctor against this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                                ' Exit For
                            Else
                                lStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                                Me.listCount = +1
                            End If

                        ElseIf StringMayBeEnteredIn(cells, Me.colOPDVoucherVisitStatus) = GetLookupDataDes(oVisitStatusID.Cancelled) Then
                            message = "The VisitNo " + visitNo + " with visitState " + StringMayBeEnteredIn(cells, Me.colOPDVoucherVisitStatus) + " Cancelled. " +
                                 ControlChars.NewLine + "Are you sure you want to pay this Doctor against this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                            Else
                                lStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                                Me.listCount = +1
                            End If
                        ElseIf DecimalEnteredIn(cells, Me.colOPDVoucherAmount, True, "Amount") > DecimalEnteredIn(cells, Me.colOPDVoucherTotalFee, True, "Amount") Then
                            'If GetLookupDataID(StringMayBeEnteredIn(cells, Me.colVisitStatus).ToString) = oVisitStatusID.Doctor.ToUpper Then
                            message = "The VisitNo " + visitNo + " with ItemName " + StringMayBeEnteredIn(cells, Me.colOPDVoucherItemName) + " has Amount Greater Than Total Fee. " +
                                 ControlChars.NewLine + "Are you sure you want to pay this Doctor against this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                                ' Exit For
                            Else
                                lStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                                Me.listCount = +1
                            End If
                        Else
                            lStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                            Me.listCount = +1
                        End If



                    End Using
                End If
            Next

            Return lStaffPaymentsList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function UpdateStaffPaymentsList() As List(Of DBConnect)
        'xxx()
        Dim message As String
        Dim nonSelected As Boolean = False
        Dim lUpdateStaffPaymentsList As New List(Of DBConnect)
        Dim oVisitTypeID As New LookupDataID.VisitTypeID
        Dim oVisitStatusID As New LookupDataID.VisitStatusID
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID

        Try
            Dim PaymentVoucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment Voucher No!"))

            For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvOPDVoucherDetails.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvOPDVoucherDetails.RowCount - 1

                If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDVoucherDetails.Rows(rowNo).Cells
                    Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherVisitNo, "Visit No!"))
                    'Dim roundNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherRoundNo, "Round No!"))
                    'Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherExtraBillNo, "extra Bill No!"))
                    Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colOPDVoucherItemCode, "Item Code!"))
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colOPDVoucherItemCategoryId, "Item CategoryId!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOPDVoucherAmount, True, "Amount")

                    Using oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
                        With oOPDStaffPaymentDetails

                            .PaymentVoucherNo = PaymentVoucherNo
                            .VisitNo = visitNo
                            '.RoundNo = roundNo
                            '.ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Amount = amount
                            .ApprovalStatusID = oClaimStatusID.Pending
                            .ApprovalNotes = String.Empty
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With


                        If DecimalEnteredIn(cells, Me.colOPDVoucherAmount, True, "Amount") > DecimalEnteredIn(cells, Me.colOPDVoucherTotalFee, True, "Amount") Then
                            'If GetLookupDataID(StringMayBeEnteredIn(cells, Me.colVisitStatus).ToString) = oVisitStatusID.Doctor.ToUpper Then
                            message = "The VisitNo " + visitNo + " with ItemName " + StringMayBeEnteredIn(cells, Me.colOPDVoucherItemName) + " has Amount Greater Than Total Fee. " +
                                 ControlChars.NewLine + "Are you sure you want to pay this Doctor against this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                                ' Exit For
                            Else
                                lUpdateStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                                Me.listCount = +1
                            End If
                        Else
                            lUpdateStaffPaymentsList.Add(oOPDStaffPaymentDetails)
                            Me.listCount = +1
                        End If
                    End Using

                End If
            Next

            Return lUpdateStaffPaymentsList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        Me.stbPaymentVoucherNo.ReadOnly = False
        Me.fbnLoad.Enabled = False
        Me.dtpStartDate.Enabled = False
        Me.dtpEndDate.Enabled = False
        Me.stbPaymentVoucherNo.Text = String.Empty
        Me.cboStaffNo.Enabled = False
        Me.cboStaffTitle.Enabled = False
        Me.cboItemStatus.Enabled = False
        Me.cboBillModesID.Enabled = False
        Me.clbItemCategory.Enabled = False
        Me.colOPDVoucherInclude.ReadOnly = True
        'Me.chkPrintVoucherOnSaving.Enabled = False
        Me.btnFindVoucherPaymentNo.Enabled = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.cboStaffTitle.Enabled = True
        Me.stbPaymentVoucherNo.ReadOnly = True
        Me.btnFindVoucherPaymentNo.Enabled = False

        ResetControlsIn(Me)

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

#End Region

#Region " Invoice Printing "

    Private Sub PrintVoucher()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcVoucherDetails.SelectedTab.Name
                Case Me.tpgOPDVoucherDetails.Name
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvOPDVoucherDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on OPD Voucher details!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.OPDVoucherPrintData()

            End Select
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docVoucher
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docVoucher.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docVoucher_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docVoucher.PrintPage

        Try
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " OPD Staff Payment Draft Voucher".ToUpper()

            Dim voucherNo As String = StringMayBeEnteredIn(Me.stbPaymentVoucherNo)
            Dim StaffName As String = StringMayBeEnteredIn(Me.stbLastName) + " " + StringMayBeEnteredIn(Me.stbFirstName)
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim billModes As String = StringEnteredIn(Me.cboBillModesID, "Bill Modes!")
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDate))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDate))

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
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight


                    .DrawString("Staff Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(StaffName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(voucherNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Staff No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(staffNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Modes: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billModes, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)


                    yPos += 2 * lineHeight



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

                If voucherParagraphs Is Nothing Then Return

                Do While voucherParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(voucherParagraphs(1), PrintParagraps)
                    voucherParagraphs.Remove(1)

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
                        voucherParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (voucherParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub OPDVoucherPrintData()

        Dim padVisitNo As Integer = 13
        Dim padExtraBillNo As Integer = 13
        Dim padItemName As Integer = 30
        'Dim padItemCategory As Integer = 20
        Dim padAmount As Integer = 10
        Dim padTotalAmount As Integer = 52

        Dim padItemNo As Integer = 4
        'Dim padItemName As Integer = 20
        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20
        Dim padItemsAmountExtra As Integer = 46

        Dim count As Integer
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        voucherParagraphs = New Collection()

        Dim oVariousOptions As New VariousOptions()


        Try
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")

            ' Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Visit No: ".PadRight(padVisitNo))
            tableHeader.Append("Category: ".PadRight(padExtraBillNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            ' tableHeader.Append("Item Category: ".PadRight(padItemCategory))
            tableHeader.Append(" Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            'Dim tableData As New System.Text.StringBuilder(String.Empty)

            Dim voucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Invoice No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim voucherDetails = From data In Me.OPDVoucherPaymentDetailsList Group data By VisitNo = data.Item1, ExtraBillNo = data.Item2,
                                ItemName = data.Item3, amount = data.Item4
                                 Into SumAmount = Sum(data.Item4) Select VisitNo, ExtraBillNo, ItemName, amount

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each item In voucherDetails

                count += 1

                Dim itemNo As String = (count).ToString()
                Dim VisitNo As String = item.VisitNo
                Dim ExtraBillNo As String = item.ExtraBillNo
                Dim ItemName As String = item.ItemName
                Dim amount As String = FormatNumber(item.amount, AppData.DecimalPlaces)

                tableData.Append(VisitNo.PadRight(padVisitNo))
                tableData.Append(ExtraBillNo.PadRight(padExtraBillNo))

                Dim wrappedItemName As List(Of String) = WrapText(ItemName, padItemName)
                If wrappedItemName.Count > 1 Then
                    For pos As Integer = 0 To wrappedItemName.Count - 1
                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padItemName))
                        If Not pos = wrappedItemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemName - 4))
                        Else : tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next
                Else
                    tableData.Append(FixDataLength(ItemName, padItemName))
                    tableData.Append(amount.PadLeft(padAmount))
                End If
                tableData.Append(ControlChars.NewLine)
            Next

            voucherParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            Dim totalAmount As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmount, True)
            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountInWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            Dim CreatedSignData As New System.Text.StringBuilder(String.Empty)
            CreatedSignData.Append(ControlChars.NewLine)

            CreatedSignData.Append("Created By:       " + GetCharacters("."c, 20))
            CreatedSignData.Append(GetSpaces(4))
            CreatedSignData.Append("Date:  " + GetCharacters("."c, 20))
            CreatedSignData.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(footerFont, CreatedSignData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function OPDVoucherPaymentDetailsList() As List(Of Tuple(Of String, String, String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim OPDvoucherPaymentDetails As New List(Of Tuple(Of String, String, String, Decimal))

            For rowNo As Integer = 0 To Me.dgvOPDVoucherDetails.RowCount - 1

                If CBool(Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDVoucherDetails.Rows(rowNo).Cells
                    Dim visitNo As String = StringEnteredIn(cells, Me.colOPDVoucherVisitNo, "Visit No!")
                    Dim category As String = StringEnteredIn(cells, Me.colOPDVoucherItemCategory, "Item Category!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colOPDVoucherItemName, "Item Name!")
                    'Dim itemCategory As String = StringEnteredIn(cells, Me.colOPDVoucherItemCategory, "Item Category!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOPDVoucherAmount, True, "Amount")

                    OPDvoucherPaymentDetails.Add(New Tuple(Of String, String, String, Decimal)(visitNo, category, itemName, amount))

                End If
            Next

            Return OPDvoucherPaymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region


    Private Sub btnFindVoucherPaymentNo_Click(sender As Object, e As EventArgs) Handles btnFindVoucherPaymentNo.Click
        Dim oVisitTypeID As New LookupDataID.VisitTypeID
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim pendingStaffPayments As New frmPendingStaffPayments(Me.stbPaymentVoucherNo, False, oVisitTypeID.OutPatient)
            pendingStaffPayments.ShowDialog()
            Me.fbnSearch_Click(sender, EventArgs.Empty)
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmsAlertListFillAmount_Click(sender As Object, e As EventArgs) Handles cmsAlertListFillAmount.Click
        Try
            For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, row.Index).Value = FormatNumber(CDec(DecimalMayBeEnteredIn(row.Cells, Me.colOPDVoucherTotalFee)), AppData.DecimalPlaces)
            Next
            Me.calculateTotals()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cmsAlertListUndoFillAmount_Click(sender As Object, e As EventArgs) Handles cmsAlertListUndoFillAmount.Click
        Try
            For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, row.Index).Value = 0
            Next
            Me.calculateTotals()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub chkApplyPercentage_CheckedChanged(sender As Object, e As EventArgs) Handles chkApplyPercentage.CheckedChanged
        Try
            Select Case Me.chkApplyPercentage.Checked
                Case True
                    Me.nbxApplyPercentage.Enabled = True
                    'For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                    '    If row.IsNewRow Then Exit For
                    '    Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, row.Index).Value = DecimalMayBeEnteredIn(row.Cells, Me.colOPDVoucherTotalFee)
                    'Next
                Case False
                    Me.nbxApplyPercentage.Enabled = False
                    For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                        If row.IsNewRow Then Exit For
                        Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, row.Index).Value = String.Empty
                    Next
            End Select
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub nbxApplyPercentage_Leave(sender As Object, e As EventArgs) Handles nbxApplyPercentage.Leave
        Try
            Dim percentageValue As Integer = IntegerEnteredIn(Me.nbxApplyPercentage)
            Dim eMessage As String = "Negative entry Values are not allowed in percentage value"
            If percentageValue <= 0 Then
                Throw New ArgumentException(eMessage)
            End If
            For Each row As DataGridViewRow In Me.dgvOPDVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                Dim totalFee As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colOPDVoucherTotalFee)
                If totalFee > 0 Then
                    Me.dgvOPDVoucherDetails.Item(Me.colOPDVoucherAmount.Name, row.Index).Value = FormatNumber(CDec(totalFee * percentageValue / 100), AppData.DecimalPlaces)
                End If
            Next
            Me.calculateTotals()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBillModesID.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPaymentControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "To-Bill Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBillClients(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillsPaymentControls()
        Me.cboAccountNo.Items.Clear()
        Me.cboCompanyNo.Items.Clear()
        Me.cboAccountNo.Text = String.Empty
        Me.cboCompanyNo.Text = String.Empty
    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()
        Dim oCompanies As New SyncSoft.SQLDb.Companies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPaymentControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Me.cboAccountNo.Enabled = False
                    Me.cboCompanyNo.Enabled = False
                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers
                    Me.cboAccountNo.Enabled = True
                    Me.cboCompanyNo.Enabled = False
                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboAccountNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBPBillAccountNo.Text = "To-Bill Account Number"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Insurances
                    Me.cboAccountNo.Enabled = True
                    Me.cboCompanyNo.Enabled = True
                    Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")
                    LoadComboData(Me.cboAccountNo, insurances, "InsuranceFullName")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.lblBPBillAccountNo.Text = "To-Bill Insurance No"
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    insuranceCompanies = oCompanies.GetCompanies().Tables("Companies")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboCompanyNo, insuranceCompanies, "companyFullName")
                    Me.cboCompanyNo.Items.Insert(0, String.Empty)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboStaffTitle_Leave(sender As Object, e As EventArgs) 'Handles cboStaffTitle.Leave
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cboStaffNo.Items.Clear()
            ' Load from Staff
            Dim staffTitleID As String = StringValueEnteredIn(Me.cboStaffTitle, "Staff Title!")
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(staffTitleID).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Add(" ")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboBillModesID_TextChanged(sender As Object, e As EventArgs) Handles cboBillModesID.TextChanged
        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillsPaymentControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cboStaffTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStaffTitle.SelectedIndexChanged
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.cboStaffNo.Items.Clear()
            ' Load from Staff
            Dim staffTitleID As String = StringValueMayBeEnteredIn(Me.cboStaffTitle, "Staff Title!")
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(staffTitleID).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Add(" ")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class