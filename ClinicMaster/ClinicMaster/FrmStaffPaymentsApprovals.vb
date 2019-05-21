
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
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports SyncSoft.Common.Structures
Imports System.Drawing.Printing

Public Class FrmStaffPaymentsApprovals

#Region "fields"
    Private WithEvents docVoucher As New PrintDocument()
    ' The paragraphs.
    Private voucherParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

    Private Sub FrmStaffPaymentsApprovals_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.colVoucherItemCategoryID.Visible = False
            'LoadLookupDataCombo(Me.colVoucherApprovalStatus, LookupObjects.ClaimStatus)
            LoadLookupDataCombo(Me.cboPayModesID, LookupObjects.PayModes)
            LoadLookupDataCombo(Me.cboCurrenciesID, LookupObjects.Currencies)
            LoadLookupDataCombo(Me.colVoucherApprovalStatus, LookupObjects.ClaimStatus)

            Me.lblPendingVouchers.Text = "Pending Vouchers:" + Me.PendingStaffPaymentsCount.ToString

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Function PendingStaffPaymentsCount() As Integer

        Dim result As Integer
        Dim PendingStaffPayments As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            PendingStaffPayments = oStaffPayments.GetPendingStaffPayments().Tables("StaffPayments")
            result = PendingStaffPayments.Rows.Count
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try
        Return result
    End Function

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim pendingStaffPayments As New frmPendingStaffPayments(Me.stbPaymentVoucherNo, False)
            pendingStaffPayments.ShowDialog()

            If Not (String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbPaymentVoucherNo))) Then
                Me.LoadPaymentData()
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub LoadPaymentData()
        Dim paymentVoucherNo As String
        Dim voucherItems As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
        Dim oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
        Dim oIPDStaffPaymentDetails As New SyncSoft.SQLDb.IPDStaffPaymentDetails()
        Dim oStaffPaymentsExt As New SyncSoft.SQLDb.StaffPaymentsExt()
        Dim oStaff As New SyncSoft.SQLDb.Staff
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID
        Dim staff As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor()

            paymentVoucherNo = RevertText(StringMayBeEnteredIn(Me.stbPaymentVoucherNo)) ', "Payment VoucherNo!"))
            If String.IsNullOrEmpty(paymentVoucherNo) Then Return
            Dim dataSource As DataTable = oStaffPayments.GetStaffPayments(paymentVoucherNo).Tables("StaffPayments")
            Me.DisplayData(dataSource)

            Dim dataSourceRow As DataRow = dataSource.Rows(0)
            If StringMayBeEnteredIn(dataSourceRow, "VoucherStatusID") = oclaimStatusID.Approved Then
                DisplayMessage("This Payment Voucher has already been approved and can not be edited!")
                Me.ebnSaveUpdate.Enabled = False
                Me.colVoucherApprovalStatus.ReadOnly = True
                Me.colVoucherNotes.ReadOnly = True
                Me.colVoucherInclude.Visible = False

                Dim staffPaymentsDisplay As DataTable = oStaffPaymentsExt.GetStaffPaymentsExt(paymentVoucherNo).Tables("StaffPaymentsExt")
                'DisplayMessage(staffPaymentsDisplay.Rows.Count.ToString)
                Dim staffPaymentsDisplayRow As DataRow = staffPaymentsDisplay.Rows(0)

                Me.dtpApprovalDateTime.Value = DateTimeEnteredIn(staffPaymentsDisplayRow, "ApprovalDateTime")
                Me.cboPayModesID.Text = GetLookupDataDes(StringEnteredIn(staffPaymentsDisplayRow, "PayModeID"))
                Me.stbDocumentNo.Text = StringEnteredIn(staffPaymentsDisplayRow, "DocumentNo")
                Me.cboCurrenciesID.Text = GetLookupDataDes(StringEnteredIn(staffPaymentsDisplayRow, "CurrenciesID"))
            Else
                Me.colVoucherInclude.Visible = True
                Me.ebnSaveUpdate.Enabled = True
                Me.colVoucherApprovalStatus.ReadOnly = False
                Me.colVoucherNotes.ReadOnly = False
            End If




            Dim staffNo As String = SubstringEnteredIn(Me.stbStaffNo, "Staff!")
            'Dim billModeID As String = StringValueEnteredIn(Me.stbBillModes, "Bill Modes!")

            Me.lblRecordsNo.Text = String.Empty
            'If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")

            staff = oStaff.GetStaff(staffNo).Tables("Staff")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim StaffRow As DataRow = staff.Rows(0)

            Me.stbFirstName.Text = StringMayBeEnteredIn(StaffRow, "FirstName")
            Me.stbLastName.Text = StringMayBeEnteredIn(StaffRow, "LastName")
            Me.stbGender.Text = StringMayBeEnteredIn(StaffRow, "Gender")
            Me.stbStaffTitle.Text = StringMayBeEnteredIn(StaffRow, "StaffTitle")
            Me.stbSpeciality.Text = StringMayBeEnteredIn(StaffRow, "Speciality")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.stbVisitType.Text = GetLookupDataDes(oVisitTypeID.InPatient) Then

                Me.colVoucherExtraBillNo.Visible = True
                Me.colVoucherRoundNo.Visible = True
                Me.dgvVoucherDetails.Rows.Clear()

                voucherItems = oIPDStaffPaymentDetails.GetIPDStaffPaymentDetails(paymentVoucherNo).Tables("IPDStaffPaymentDetails")
                Me.lblRecordsNo.Text = " Returned Record(s): " + voucherItems.Rows.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If voucherItems Is Nothing OrElse voucherItems.Rows.Count < 1 Then Return
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For pos As Integer = 0 To voucherItems.Rows.Count - 1

                    Dim row As DataRow = voucherItems.Rows(pos)

                    With Me.dgvVoucherDetails
                        ' Ensure that you add a new row-
                        .Rows.Add()
                        .Item(Me.colVoucherInclude.Name, pos).Value = False
                        .Item(Me.colVoucherPatientNo.Name, pos).Value = StringEnteredIn(row, "PatientNo")
                        .Item(Me.colVoucherFullName.Name, pos).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colVoucherVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                        .Item(Me.colVoucherExtraBillNo.Name, pos).Value = StringEnteredIn(row, "ExtraBillNo")
                        .Item(Me.colVoucherRoundNo.Name, pos).Value = StringEnteredIn(row, "RoundNo")
                        .Item(Me.colVoucherItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                        .Item(Me.colVoucherItemCategoryID.Name, pos).Value = StringEnteredIn(row, "ItemCategoryID")
                        .Item(Me.colVoucherItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colVoucherItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colVoucherApprovalStatus.Name, pos).Value = StringEnteredIn(row, "ApprovalStatusID")
                        .Item(Me.colVoucherNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ApprovalNotes")
                        If (DecimalMayBeEnteredIn(row, "Amount") = Nothing) Then
                            .Item(Me.colVoucherAmount.Name, pos).Value = 0
                        Else
                            .Item(Me.colVoucherAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount", True), AppData.DecimalPlaces)
                        End If
                    End With

                Next
                Me.calculateTotals()

            ElseIf Me.stbVisitType.Text = GetLookupDataDes(oVisitTypeID.OutPatient) Then

                Me.colVoucherExtraBillNo.Visible = False
                Me.colVoucherRoundNo.Visible = False
                Me.dgvVoucherDetails.Rows.Clear()

                voucherItems = oOPDStaffPaymentDetails.GetOPDStaffPaymentDetails(paymentVoucherNo).Tables("OPDStaffPaymentDetails")
                Me.lblRecordsNo.Text = " Returned Record(s): " + voucherItems.Rows.Count.ToString()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If voucherItems Is Nothing OrElse voucherItems.Rows.Count < 1 Then Return
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.colVoucherExtraBillNo.Visible = False
                Me.colVoucherRoundNo.Visible = False

                For pos As Integer = 0 To voucherItems.Rows.Count - 1

                    Dim row As DataRow = voucherItems.Rows(pos)

                    With Me.dgvVoucherDetails
                        ' Ensure that you add a new row-
                        .Rows.Add()
                        .Item(Me.colVoucherInclude.Name, pos).Value = False
                        .Item(Me.colVoucherPatientNo.Name, pos).Value = StringEnteredIn(row, "PatientNo")
                        .Item(Me.colVoucherFullName.Name, pos).Value = StringEnteredIn(row, "FullName")
                        .Item(Me.colVoucherVisitNo.Name, pos).Value = StringEnteredIn(row, "VisitNo")
                        '.Item(Me.colVoucherExtraBillNo.Name, pos).Value = StringEnteredIn(row, "ExtraBillNo")
                        '.Item(Me.colVoucherRoundNo.Name, pos).Value = StringEnteredIn(row, "RoundNo")
                        .Item(Me.colVoucherItemCategory.Name, pos).Value = StringEnteredIn(row, "ItemCategory")
                        .Item(Me.colVoucherItemCategoryID.Name, pos).Value = StringEnteredIn(row, "ItemCategoryID")
                        .Item(Me.colVoucherItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                        .Item(Me.colVoucherItemCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colVoucherApprovalStatus.Name, pos).Value = StringEnteredIn(row, "ApprovalStatusID")
                        .Item(Me.colVoucherNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ApprovalNotes")
                        'DisplayMessage(StringMayBeEnteredIn(row, "ApprovalNotes"))
                        If (DecimalMayBeEnteredIn(row, "Amount") = Nothing) Then
                            .Item(Me.colVoucherAmount.Name, pos).Value = 0
                        Else
                            .Item(Me.colVoucherAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount", True), AppData.DecimalPlaces)
                        End If
                    End With

                Next
                Me.calculateTotals()


            End If
            
        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me)
            Me.dgvVoucherDetails.Rows.Clear()
            ResetControlsIn(Me.grpSetParameters)
            ResetControlsIn(Me.pnlPeriod)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub calculateTotals()
        Try
            Dim TotalVoucherAmount As Decimal
            Dim oClaimStatusID As New LookupDataID.ClaimStatusID

            For Each row As DataGridViewRow In Me.dgvVoucherDetails.Rows
                If row.IsNewRow Then Exit For

                If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, row.Index).Value) = True And (CStr(Me.dgvVoucherDetails.Item(Me.colVoucherApprovalStatus.Name, row.Index).Value) = CStr((oClaimStatusID.Approved))) Then
                    TotalVoucherAmount += DecimalMayBeEnteredIn(row.Cells, Me.colVoucherAmount)
                End If
            Next
            Me.stbTotalAmount.Text = FormatNumber(TotalVoucherAmount, AppData.DecimalPlaces)
            Me.stbAmountInWords.Text = NumberToWords(TotalVoucherAmount)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            ' Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            'Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvVoucherDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVoucherDetails.CellClick

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.calculateTotals()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub



    Private Sub btnExchangeRate_Click(sender As Object, e As EventArgs) Handles btnExchangeRate.Click
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

    Private Sub cboCurrenciesID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurrenciesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim currenciesID As String = StringValueMayBeEnteredIn(Me.cboCurrenciesID, "Currency!")
            If String.IsNullOrEmpty(currenciesID) Then Return

            Me.SetCashCurrencyControls(currenciesID)
            'Me.CalculateCashChange()

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
                Else : Me.nbxExchangeRate.Value = exchangeRate.ToString()
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
            'Me.stbChange.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ebnSaveUpdate_Click(sender As Object, e As EventArgs) Handles ebnSaveUpdate.Click

        Dim oStaffPaymentsExt As New SyncSoft.SQLDb.StaffPaymentsExt()
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim message As String
        Dim nonSelected As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor()

            For Each row As DataGridViewRow In Me.dgvVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvVoucherDetails.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on Voucher details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oStaffPaymentsExt

                .PaymentVoucherNo = StringEnteredIn(Me.stbPaymentVoucherNo, "Payment VoucherNo!")
                .ApprovalDateTime = DateEnteredIn(Me.dtpApprovalDateTime, "Approval DateTime!")
                .PayModeID = StringValueEnteredIn(Me.cboPayModesID, "Pay ModesID!")
                .DocumentNo = StringEnteredIn(Me.stbDocumentNo, "Document No!")
                .CurrenciesID = StringValueEnteredIn(Me.cboCurrenciesID, "CurrenciesID!")
                .ExchangeRate = Me.nbxExchangeRate.GetDecimal(False)
                .Amount = DecimalEnteredIn(Me.stbTotalAmount, False, "Amount")
                .AmountWords = StringEnteredIn(Me.stbAmountInWords, "Amount Words!")
                .ApprovalStatusID = oClaimStatusID.Approved
                .LoginID = CurrentUser.LoginID

                '.RecordDateTime = DateEnteredIn(Me.dtpRecordDateTime, "RecordDateTime!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    oStaffPaymentsExt.Save()
                    transactions.Add(New TransactionList(Of DBConnect)(Me.UpdateStaffVoucherDetailsList, Action.Update))
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    If Not Me.chkPrintVoucherOnSaving.Checked Then
                        message = "You have not checked Print Voucher On Saving. " + ControlChars.NewLine + "Would you want a Voucher printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintVoucher()
                        DisplayMessage("Voucher record(s) Saved!")
                        ResetControlsIn(Me)
                        Me.dgvVoucherDetails.Rows.Clear()
                        ResetControlsIn(Me.grpSetParameters)
                        ResetControlsIn(Me.pnlPeriod)

                    Else : Me.PrintVoucher()
                        DisplayMessage("Voucher record(s) Saved!")
                        ResetControlsIn(Me)
                        Me.dgvVoucherDetails.Rows.Clear()
                        ResetControlsIn(Me.grpSetParameters)
                        ResetControlsIn(Me.pnlPeriod)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oStaffPaymentsExt.Update())
                    'Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()
            Me.lblPendingVouchers.Text = "Pending Vouchers:" + Me.PendingStaffPaymentsCount.ToString
        End Try
    End Sub

    Private Function GetClaimStatusID(ByVal Value As String) As String

        Dim oStaffPaymentExt As New SyncSoft.SQLDb.StaffPaymentsExt()
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID
        Dim outPut As String = String.Empty

        Try
            Me.Cursor = Cursors.WaitCursor()

            If Value = oClaimStatusID.Approved Then
                outPut = oClaimStatusID.Approved
            ElseIf Value = oClaimStatusID.NotApproved Then
                outPut = oClaimStatusID.NotApproved
            ElseIf Value = oClaimStatusID.Pending Then
                outPut = oClaimStatusID.Pending
            ElseIf Value = oClaimStatusID.ReturntoDoctor Then
                outPut = oClaimStatusID.ReturntoDoctor
            Else

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default()
        End Try
        Return outPut
    End Function

    Private Function UpdateStaffVoucherDetailsList() As List(Of DBConnect)

        Dim nonSelected As Boolean = False
        Dim lUpdateStaffVoucherDetailsList As New List(Of DBConnect)
        Dim oVisitTypeID As New LookupDataID.VisitTypeID
        Dim oVisitStatusID As New LookupDataID.VisitStatusID
        Dim oClaimStatusID As New LookupDataID.ClaimStatusID

        Try
            Dim PaymentVoucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Payment Voucher No!"))

            For Each row As DataGridViewRow In Me.dgvVoucherDetails.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvVoucherDetails.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry on Voucher details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbVisitType.Text = GetLookupDataDes(oVisitTypeID.InPatient) Then

                For rowNo As Integer = 0 To Me.dgvVoucherDetails.RowCount - 1
                    If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, rowNo).Value) = True Then
                        Dim cells As DataGridViewCellCollection = Me.dgvVoucherDetails.Rows(rowNo).Cells
                        Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherVisitNo, "Visit No!"))
                        Dim roundNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherRoundNo, "Round No!"))
                        Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherExtraBillNo, "extra Bill No!"))
                        Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colVoucherItemCode, "Item Code!"))
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colVoucherItemCategoryID, "Item CategoryId!")
                        Dim approvalStatusID As String = GetClaimStatusID(StringEnteredIn(cells, Me.colVoucherApprovalStatus, "Approval Status!"))
                        'DisplayMessage(approvalStatusID)
                        Dim approvalNotes As String = StringMayBeEnteredIn(cells, Me.colVoucherNotes)
                        Dim amount As Decimal = DecimalEnteredIn(cells, Me.colVoucherAmount, True, "Amount")

                        Using oIPDStaffPaymentDetails As New SyncSoft.SQLDb.IPDStaffPaymentDetails()
                            With oIPDStaffPaymentDetails

                                .PaymentVoucherNo = PaymentVoucherNo
                                .VisitNo = visitNo
                                .RoundNo = roundNo
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .Amount = amount
                                .ApprovalStatusID = approvalStatusID
                                .ApprovalNotes = approvalNotes
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ValidateEntriesIn(Me)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With
                            lUpdateStaffVoucherDetailsList.Add(oIPDStaffPaymentDetails)

                        End Using

                    End If
                Next
                'Return lUpdateStaffVoucherDetailsList

            ElseIf Me.stbVisitType.Text = GetLookupDataDes(oVisitTypeID.OutPatient) Then

                For rowNo As Integer = 0 To Me.dgvVoucherDetails.RowCount - 1

                    If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, rowNo).Value) = True Then

                        Dim cells As DataGridViewCellCollection = Me.dgvVoucherDetails.Rows(rowNo).Cells
                        Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherVisitNo, "Visit No!"))
                        'Dim roundNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherRoundNo, "Round No!"))
                        'Dim extraBillNo As String = RevertText(StringEnteredIn(cells, Me.colVoucherExtraBillNo, "extra Bill No!"))
                        Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colVoucherItemCode, "Item Code!"))
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colVoucherItemCategoryID, "Item CategoryId!")
                        Dim approvalStatusID As String = GetClaimStatusID(StringEnteredIn(cells, Me.colVoucherApprovalStatus, "Approval Status!"))
                        Dim approvalNotes As String = StringMayBeEnteredIn(cells, Me.colVoucherNotes)
                        Dim amount As Decimal = DecimalEnteredIn(cells, Me.colVoucherAmount, True, "Amount")

                        Using oOPDStaffPaymentDetails As New SyncSoft.SQLDb.OPDStaffPaymentDetails()
                            With oOPDStaffPaymentDetails

                                .PaymentVoucherNo = PaymentVoucherNo
                                .VisitNo = visitNo
                                '.RoundNo = roundNo
                                '.ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .Amount = amount
                                .ApprovalStatusID = approvalStatusID
                                .ApprovalNotes = approvalNotes
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ValidateEntriesIn(Me)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With
                            lUpdateStaffVoucherDetailsList.Add(oOPDStaffPaymentDetails)

                        End Using
                    End If
                Next
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return lUpdateStaffVoucherDetailsList
        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Sub dgvVoucherDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVoucherDetails.CellEndEdit
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.calculateTotals()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmStaffPaymentsApprovals_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.lblPendingVouchers.Text = "Pending Vouchers:" + Me.PendingStaffPaymentsCount.ToString

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub stbPaymentVoucherNo_Enter(sender As Object, e As EventArgs) Handles stbPaymentVoucherNo.Enter
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.LoadPaymentData()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub stbPaymentVoucherNo_Leave(sender As Object, e As EventArgs) Handles stbPaymentVoucherNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.LoadPaymentData()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub stbPaymentVoucherNo_TextChanged(sender As Object, e As EventArgs) Handles stbPaymentVoucherNo.TextChanged

    End Sub

    Private Sub btnPendingApprovals_Click(sender As Object, e As EventArgs) Handles btnPendingApprovals.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim pendingStaffPayments As New frmPendingStaffPayments(Me.stbPaymentVoucherNo, True)
            pendingStaffPayments.ShowDialog()

            If Not (String.IsNullOrEmpty(StringMayBeEnteredIn(Me.stbPaymentVoucherNo))) Then
                Me.LoadPaymentData()
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region " Invoice Printing "

    Private Sub PrintVoucher()
        Dim oVisitType As New LookupDataID.VisitTypeID
        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvVoucherDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on IPD Voucher details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.stbVisitType.Text = GetLookupDataDes(oVisitType.InPatient) Then
                Me.IPDVoucherPrintData()
            ElseIf Me.stbVisitType.Text = GetLookupDataDes(oVisitType.OutPatient) Then
                Me.OPDVoucherPrintData()
            End If

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

            Dim title As String = AppData.ProductOwner.ToUpper() + " Approved Staff Payment Voucher".ToUpper()

            Dim voucherNo As String = StringMayBeEnteredIn(Me.stbPaymentVoucherNo)
            Dim StaffName As String = StringMayBeEnteredIn(Me.stbLastName) + " " + StringMayBeEnteredIn(Me.stbFirstName)
            Dim staffNo As String = SubstringEnteredIn(Me.stbStaffNo, "Staff!")
            Dim billModes As String = StringEnteredIn(Me.stbBillModes, "Bill Modes!")
            Dim startDateTime As String = FormatDate(DateMayBeEnteredIn(Me.stbStartDateTime))
            Dim endDateTime As String = FormatDate(DateMayBeEnteredIn(Me.stbEndDateTime))

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

                    .DrawString("Start DateTime: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End DateTime: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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

    Private Sub IPDVoucherPrintData()

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

            Dim startDateTime As Date = DateTimeEnteredIn(Me.stbStartDateTime, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.stbEndDateTime, "End Date")
            Dim staffNo As String = SubstringEnteredIn(Me.stbStaffNo, "Staff!")

            ' Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Visit No: ".PadRight(padVisitNo))
            tableHeader.Append("ExtraBillNo: ".PadRight(padExtraBillNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            ' tableHeader.Append("Item Category: ".PadRight(padItemCategory))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            'Dim tableData As New System.Text.StringBuilder(String.Empty)

            Dim voucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Invoice No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim voucherDetails = From data In Me.IPDVoucherPaymentDetailsList Group data By VisitNo = data.Item1, ExtraBillNo = data.Item2,
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

    Private Function IPDVoucherPaymentDetailsList() As List(Of Tuple(Of String, String, String, Decimal))

        Try
            Dim oClaimStatusID As New LookupDataID.ClaimStatusID
            ' Create list of tuples with two items each.
            Dim IPDvoucherPaymentDetails As New List(Of Tuple(Of String, String, String, Decimal))

            For rowNo As Integer = 0 To Me.dgvVoucherDetails.RowCount - 1

                If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, rowNo).Value) = True And (CStr(Me.dgvVoucherDetails.Item(Me.colVoucherApprovalStatus.Name, rowNo).Value) = CStr((oClaimStatusID.Approved))) Then


                    Dim cells As DataGridViewCellCollection = Me.dgvVoucherDetails.Rows(rowNo).Cells
                    Dim visitNo As String = StringEnteredIn(cells, Me.colVoucherVisitNo, "Visit No!")
                    Dim extraBillNo As String = StringEnteredIn(cells, Me.colVoucherExtraBillNo, "Extra BillNo!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colVoucherItemName, "Item Name!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colVoucherAmount, True, "Amount")

                    IPDvoucherPaymentDetails.Add(New Tuple(Of String, String, String, Decimal)(visitNo, extraBillNo, itemName, amount))

                End If
            Next

            Return IPDvoucherPaymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub OPDVoucherPrintData()

        Dim padVisitNo As Integer = 13
        Dim padPatientNo As Integer = 13
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

            Dim startDateTime As Date = DateTimeEnteredIn(Me.stbStartDateTime, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.stbEndDateTime, "End Date")
            Dim staffNo As String = SubstringEnteredIn(Me.stbStaffNo, "Staff!")

            ' Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Visit No: ".PadRight(padVisitNo))
            tableHeader.Append("PatientNo: ".PadRight(padPatientNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            ' tableHeader.Append("Item Category: ".PadRight(padItemCategory))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            voucherParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            'Dim tableData As New System.Text.StringBuilder(String.Empty)

            Dim voucherNo As String = RevertText(StringEnteredIn(Me.stbPaymentVoucherNo, "Invoice No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim voucherDetails = From data In Me.OPDVoucherPaymentDetailsList Group data By VisitNo = data.Item1, PatientNo = data.Item2,
                                ItemName = data.Item3, amount = data.Item4
                                 Into SumAmount = Sum(data.Item4) Select VisitNo, PatientNo, ItemName, amount

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each item In voucherDetails

                count += 1

                Dim itemNo As String = (count).ToString()
                Dim VisitNo As String = item.VisitNo
                Dim PatientNo As String = item.PatientNo
                Dim ItemName As String = item.ItemName
                Dim amount As String = FormatNumber(item.amount, AppData.DecimalPlaces)

                tableData.Append(VisitNo.PadRight(padVisitNo))
                tableData.Append(PatientNo.PadRight(padPatientNo))

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
            Dim oClaimStatusID As New LookupDataID.ClaimStatusID
            ' Create list of tuples with two items each.
            Dim OPDvoucherPaymentDetails As New List(Of Tuple(Of String, String, String, Decimal))

            For rowNo As Integer = 0 To Me.dgvVoucherDetails.RowCount - 1

                If CBool(Me.dgvVoucherDetails.Item(Me.colVoucherInclude.Name, rowNo).Value) = True And (CStr(Me.dgvVoucherDetails.Item(Me.colVoucherApprovalStatus.Name, rowNo).Value) = CStr((oClaimStatusID.Approved))) Then

                    Dim cells As DataGridViewCellCollection = Me.dgvVoucherDetails.Rows(rowNo).Cells
                    Dim visitNo As String = StringEnteredIn(cells, Me.colVoucherVisitNo, "Visit No!")
                    Dim patientNo As String = StringEnteredIn(cells, Me.colVoucherPatientNo, "Patient No!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colVoucherItemName, "Item Name!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colVoucherAmount, True, "Amount")

                    OPDvoucherPaymentDetails.Add(New Tuple(Of String, String, String, Decimal)(visitNo, patientNo, itemName, amount))

                End If
            Next

            Return OPDvoucherPaymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub
End Class