
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes

Public Class frmRefundRequests

#Region " Fields "
    Private visitTypeID As String
    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oReturnResaonType As New LookupDataID.ReturnReasonTypeID()
    Dim oItemStatusID As New LookupDataID.ItemStatusID
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oDocumentTypeID As New LookupDataID.DocumentTypeID()

#End Region
    Dim defaultItemCategoryID As String
    Private visityTypeID As String
    Private billNo As String
    Private visitNo As String
    Dim billModesID As String
    Private AmountRefunded As Decimal
    Private oVariousOptions As New VariousOptions()
    Dim oBillModesID As New LookupDataID.BillModesID

 
    Private Sub frmRefundRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(colRefundReason, LookupObjects.ReturnReasonTypeID, False)
            SetFormText()
            SetIntegrationAdjustment()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetIntegrationAdjustment()

        Try
            Me.Cursor = Cursors.WaitCursor
            If oVariousOptions.EnableIntegrationN001 Then

                Me.rdoReduceQuantity.Checked = True
                Me.rdoReducePrice.Checked = False
                Me.rdoReducePrice.Enabled = False
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub SetFormText()
        If Not String.IsNullOrEmpty(Me.defaultItemCategoryID) Then
            Me.Text = "Refund Requests for " + GetLookupDataDes(Me.defaultItemCategoryID)
        Else
            Me.Text = "Refund Requests "
        End If

    End Sub

    Private Sub frmRefundRequests_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oRefundRequests.RefundRequestNo = StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!")

            DisplayMessage(oRefundRequests.Delete())
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

        Dim refundRequestNo As String

        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

        Try
            Me.Cursor = Cursors.WaitCursor()

            refundRequestNo = StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!")

            Dim dataSource As DataTable = oRefundRequests.GetRefundRequests(refundRequestNo).Tables("RefundRequests")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        
        Try
            Me.Cursor = Cursors.WaitCursor()

           
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPaymentRefunds.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPaymentRefunds.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvPaymentRefunds.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one entry!")



            Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()
            Dim refundRequestNo As String = RevertText(StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!"))
            Dim receiptNo As String = RevertText(StringEnteredIn(Me.cboReceiptNo, "Receipt No!"))
            Dim lRefundRequestItemsList As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim lRefundRequests As New List(Of DBConnect)
            

            With oRefundRequests

                .RefundRequestNo = refundRequestNo
                .ReceiptNo = receiptNo
                .Amount = nbxToRefundAmount.GetDecimal(False)
                .RequestStatusID = oItemStatusID.Pending()
                .ApprovalStatusID = oItemStatusID.Pending()
                .VisitTypeID = Me.visitTypeID
                .RequestedBy = StringEnteredIn(Me.stbRequestedBy, "Requested By!")
                .LoginID = CurrentUser.LoginID



                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lRefundRequests.Add(oRefundRequests)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvPaymentRefunds.Rows.Count - 1



                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells

                    Dim include As Boolean = CBool(BooleanMayBeEnteredIn(cells, colInclude))
                    Dim itemCode As String = StringEnteredIn(cells, Me.colReturnItemCode, "Item Code!")


                    If include Then
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category ID!")
                        Dim reason As String = StringEnteredIn(cells, Me.colRefundReason, "Refund Reason")
                        Dim quantity As Integer = IntegerEnteredIn(cells, Me.colReturnedQuantity, "Return  Quantity!")
                        Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colBillUnitPrice, False)
                        Dim newPrice As Decimal = DecimalEnteredIn(cells, Me.colNewPrice, False)
                        Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVisitNo, "Visit No"))
                        Dim amount As Decimal = DecimalEnteredIn(cells, Me.colReturnAmount, False)
                        Dim billAmount As Decimal = DecimalEnteredIn(cells, Me.colAmountBalance, False)
                        Dim billQuantity As Integer = IntegerEnteredIn(cells, Me.colBillQuantity, "Return  Quantity!")

                        Dim pos As Integer = rowNo + 1
                        If quantity < 1 AndAlso rdoReduceQuantity.Checked Then Throw New ArgumentException("Returned quantity  can't be less than one at row " + pos.ToString + "!")
                        If amount < 1 AndAlso rdoReducePrice.Checked Then Throw New ArgumentException("Returned Amount  can't be less than one at row " + pos.ToString + "!")
                        If quantity < 1 AndAlso amount < 1 Then Throw New ArgumentException("Returned quantity and return Amount can’t be less than one " + pos.ToString + "!")
                        If quantity > billQuantity Then Throw New ArgumentException("returned quantity can’t be more than bill quantity " + pos.ToString + "!")
                        If amount > billAmount Then Throw New ArgumentException("returned amount can’t be more than bill amount!" + pos.ToString + "!")

                        If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient) Then

                            Using oRefundRequestExtraBillItems As New SyncSoft.SQLDb.RefundRequestExtraBillItems()


                                With oRefundRequestExtraBillItems

                                    .RefundRequestNo = refundRequestNo
                                    .ReceiptNo = receiptNo
                                    .ExtraBillNo = visitNo
                                    .ItemCategoryID = itemCategoryID
                                    .ItemCode = itemCode
                                    .Quantity = quantity
                                    .Amount = amount
                                    .NewPrice = newPrice
                                    .ReturnReasonID = reason
                                    .LoginID = CurrentUser.LoginID
                                End With
                                lRefundRequestItemsList.Add(oRefundRequestExtraBillItems)
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End Using

                        Else

                            Using oRefundRequestDetails As New SyncSoft.SQLDb.RefundRequestDetails()


                                With oRefundRequestDetails

                                    .RefundRequestNo = refundRequestNo
                                    .ReceiptNo = receiptNo
                                    .VisitNo = visitNo
                                    .ItemCategoryID = itemCategoryID
                                    .ItemCode = itemCode
                                    .Quantity = quantity
                                    .Amount = amount
                                    .NewPrice = newPrice
                                    .ReturnReasonID = reason
                                    .LoginID = CurrentUser.LoginID
                                End With
                                lRefundRequestItemsList.Add(oRefundRequestDetails)
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End Using
                        End If

                    End If

                    'Dim pendingRequests As DataTable = oRefundRequestDetails.GetPendingRefundRequestDetailsByItemCategoryItemCode(receiptNo, itemCategoryID, itemCode).Tables("RefundRequestDetails")
                    'If pendingRequests.Rows.Count > 0 Then
                    '    If WarningMessage("The Category " + GetLookupDataDes(itemCategoryID) + " and Item Code " + itemCode + " at row " + (rowNo + 1).ToString + " has Pending request, Are you sure you need to create another one") = Windows.Forms.DialogResult.Yes Then
                    '        lRefundRequestDetails.Add(oRefundRequestDetails)
                    '    End If
                    'Else
                    '    lRefundRequestDetails.Add(oRefundRequestDetails)
                    'End If

                Next


            End With



            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    transactions.Add(New TransactionList(Of DBConnect)(lRefundRequests, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lRefundRequestItemsList, Action.Save))

                    Dim records As Integer = DoTransactions(transactions)

                    DisplayMessage(records.ToString + " record(s) saved")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)

                    SetNextRefundRequestNo()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    transactions.Add(New TransactionList(Of DBConnect)(lRefundRequests, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(lRefundRequestItemsList, Action.Update))

                    Dim records As Integer = DoTransactions(transactions)

                    DisplayMessage(records.ToString + " record(s) saved")


                    ClearControls()
                    Me.CallOnKeyEdit()
                    SetIntegrationAdjustment()
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
        SetNextRefundRequestNo()

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

    Private Sub SetNextRefundRequestNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("RefundRequests", "RefundRequestNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextRefundRequestNo As String = CStr(oRefundRequests.GetNextRefundRequestID).PadLeft(paddingLEN, paddingCHAR)
            Me.stbRefundRequestNo.Text = FormatText((yearL2 + nextRefundRequestNo).Trim(), "RefundRequests", "RefundRequestNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPayments(ByVal receiptNo As String)

        Dim oPayments As New SyncSoft.SQLDb.Payments()
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                      ControlChars.NewLine + "Please advice accordingly!"
            Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim payments As DataTable = oPayments.GetPayments(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRequestedBy.Text = CurrentUser.FullName
            Me.stbPayeeName.Text = StringEnteredIn(row, "PayeeName")
            Me.stbVisitType.Text = StringEnteredIn(row, "VisitType")
            Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")
            Me.stbRefundPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbRefundAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.AmountRefunded = DecimalMayBeEnteredIn(row, "AmountRefunded")
            Me.stbAmountRefunded.Text = FormatNumber(AmountRefunded, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxRefundOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxRefundOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundOutstandingBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim payeeNo As String = StringEnteredIn(row, "PayeeNo")
            Me.billNo = payeeNo
            Dim payTypeID As String = StringEnteredIn(row, "PayTypeID")
            Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")
            Dim payDate As Date = DateEnteredIn(row, "PayDate")

            If payTypeID.ToUpper().Equals(oPayTypeID.VisitBill.ToUpper()) Then
                Me.billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.ExtraBill.ToUpper()) Then
                Me.billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.IPDRoundBill.ToUpper()) Then
                Me.billModesID = oBillModesID.Cash


            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.AccountBill.ToUpper()) Then
                Me.billModesID = oBillModesID.Account

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                Me.billModesID = oBillModesID.Insurance

            Else : Me.billModesID = String.Empty
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountBalance As Decimal = GetAccountBalance(billModesID, payeeNo)
            Me.nbxRefundAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)
            Me.stbBillMode.Text = GetLookupDataDes(billModesID)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                ErrProvider.SetError(Me.nbxRefundAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundAccountBalance, String.Empty)
            End If

            If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient) Then
                Me.colVisitNo.DataPropertyName = "ExtraBillNo"
                Me.colVisitNo.HeaderText = "Extra Bill No"
            Else
                Me.colVisitNo.DataPropertyName = "VisitNo"
                Me.colVisitNo.HeaderText = "Visit No"
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billModesID.Equals(oBillModesID.Cash) Then
                Me.LoadPaymentDetails(receiptNo)

                Me.stbVisitNo.ReadOnly = True

            Else
                Dim message As String = String.Empty
                If oVariousOptions.AllowAccountReceiptsRefunds() Then
                    message = "The Receipt No you have entered is for account payment, you will need to enter the visit no you want to refund in order to continue"
                    Me.stbVisitNo.ReadOnly = False
                    Me.stbVisitNo.Focus()
                Else
                    message = "This receipt is for account Patients. The system is not set allow refund of non cash receipts"
                    Me.stbVisitNo.ReadOnly = True
                End If

                If Not String.IsNullOrEmpty(message) Then DisplayMessage(message)


            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub


    Private Sub LoadPaymentDetails(receiptNo As String)
        Try

            Dim oPaymentDetails As New PaymentDetails()
            Dim oPaymentExtraBillItems As New PaymentExtraBillItems()
            Dim paymentDetails As DataTable = New DataTable

            Dim visitLabel As String = "Visit No"

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dgvPaymentRefunds.Rows.Clear()

            If String.IsNullOrEmpty(Me.visitTypeID) Then Return

            If String.IsNullOrEmpty(Me.defaultItemCategoryID) Then
                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                    paymentDetails = oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo).Tables("PaymentExtraBillItems")


                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetPaymentDetails(receiptNo).Tables("PaymentDetails")


                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetPaymentDetails(receiptNo).Tables("PaymentDetails")
                    paymentDetails.Merge(oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo).Tables("PaymentExtraBillItems"))
                End If

                ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                    paymentDetails = oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo, Me.defaultItemCategoryID).Tables("PaymentExtraBillItems")



                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetPaymentDetails(receiptNo, Me.defaultItemCategoryID).Tables("PaymentDetails")

                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetPaymentDetails(receiptNo, Me.defaultItemCategoryID).Tables("PaymentDetails")
                    paymentDetails.Merge(oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo, Me.defaultItemCategoryID).Tables("PaymentExtraBillItems"))
                End If
            End If


            Dim message As String = "No receipt details found for receipt No " + receiptNo


            If Not String.IsNullOrEmpty(defaultItemCategoryID) Then
                message = "No receipt details found for receipt No " + receiptNo + " and Item Category " + GetLookupDataDes(Me.defaultItemCategoryID)
            End If


            If paymentDetails.Rows.Count < 1 Then
                DisplayMessage(message)
            Else

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim row As DataRow = paymentDetails.Rows(0)
                visitNo = StringEnteredIn(row, "VisitNo")
                Me.stbVisitNo.Text = visitNo

                LoadGridData(Me.dgvPaymentRefunds, paymentDetails)
                FormatGridRow(dgvPaymentRefunds)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
    End Sub

    Private Sub LoadPaymentDetails(receiptNo As String, visitNo As String)
        Try

            Dim oPaymentDetails As New PaymentDetails()
            Dim oPaymentExtraBillItems As New PaymentExtraBillItems()
            Dim paymentDetails As DataTable = New DataTable


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dgvPaymentRefunds.Rows.Clear()

            If String.IsNullOrEmpty(Me.visitTypeID) Then Return

            If String.IsNullOrEmpty(Me.defaultItemCategoryID) Then
                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                    paymentDetails = oPaymentExtraBillItems.GetVisitPaymentExtraBillItems(receiptNo, visitNo).Tables("PaymentExtraBillItems")

                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetVisitPaymentDetails(receiptNo, visitNo).Tables("PaymentDetails")


                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetVisitPaymentDetails(receiptNo, visitNo).Tables("PaymentDetails")
                    paymentDetails.Merge(oPaymentExtraBillItems.GetVisitPaymentExtraBillItems(receiptNo, visitNo).Tables("PaymentExtraBillItems"))
                End If

                ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                    paymentDetails = oPaymentExtraBillItems.GetVisitPaymentExtraBillItems(receiptNo, visitNo, Me.defaultItemCategoryID).Tables("PaymentExtraBillItems")

                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetVisitPaymentDetails(receiptNo, visitNo, Me.defaultItemCategoryID).Tables("PaymentDetails")

                ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                    paymentDetails = oPaymentDetails.GetVisitPaymentDetails(receiptNo, visitNo, Me.defaultItemCategoryID).Tables("PaymentDetails")
                    paymentDetails.Merge(oPaymentExtraBillItems.GetVisitPaymentExtraBillItems(receiptNo, visitNo, Me.defaultItemCategoryID).Tables("PaymentExtraBillItems"))
                End If
            End If


            Dim message As String = "No receipt details found for receipt No " + receiptNo + " and Visit No. " + visitNo


            If Not String.IsNullOrEmpty(defaultItemCategoryID) Then
                message = "No receipt details found for receipt No " + receiptNo + " and Item Category " + GetLookupDataDes(Me.defaultItemCategoryID) + " and " +
                "Visit No: " + visitNo
            End If


            If paymentDetails.Rows.Count < 1 Then
                DisplayMessage(message)
            Else

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                LoadGridData(Me.dgvPaymentRefunds, paymentDetails)
                FormatGridRow(dgvPaymentRefunds)


            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
    End Sub


    Private Sub cboReceiptNo_Leave(sender As Object, e As System.EventArgs) Handles cboReceiptNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            ClearControls()
            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.cboReceiptNo))

            If String.IsNullOrEmpty(receiptNo) Then Return

            Me.ShowPayments(receiptNo)

            If billModesID.Equals(oBillModesID.Cash) Then

                Me.stbVisitNo.ReadOnly = True

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub CalculateTotalRefundAmount()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colReturnAmount)
        nbxToRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)

        Dim previousRefunded As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colPreviousRefundedAmount)
        nbxTotalRefundAmount.Text = FormatNumber((refundAmount + previousRefunded), AppData.DecimalPlaces)
    End Sub



    Private Sub dgvPaymentRefunds_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPaymentRefunds.CellEndEdit
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim row As Integer = e.RowIndex
            If row < 0 Then Return


            Dim include As Boolean = CBool(BooleanMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(row).Cells, colInclude))

            If e.ColumnIndex.Equals(Me.colInclude.Index) Then
                SetEditableColumns(include, row)

            ElseIf e.ColumnIndex.Equals(Me.colReturnedQuantity.Index) Then
                Me.CalculateReturnAmount(row)

            ElseIf e.ColumnIndex.Equals(Me.colReturnAmount.Index) Then

                Me.CalculateReturnNewPrice(row)

            ElseIf e.ColumnIndex.Equals(Me.colNewPrice.Index) Then
                Me.CalculateReturnAmountOnNewPrice(row)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub SetEditableColumns(editable As Boolean, row As Integer)


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not editable Then

            Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, row).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, row).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).Value = String.Empty

            Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, row).ReadOnly = True
            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).ReadOnly = True
            Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, row).ReadOnly = True
            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).ReadOnly = True
            Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).Value = String.Empty

        Else
            If rdoReducePrice.Checked Then

                Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, row).ReadOnly = False
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).ReadOnly = False
                Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).Value = String.Empty

            ElseIf rdoReduceQuantity.Checked Then

                Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, row).ReadOnly = False
                Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).Value = String.Empty

            Else

                Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, row).ReadOnly = True
                Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).Value = String.Empty

            End If
            Me.dgvPaymentRefunds.Item(Me.colRefundReason.Name, row).ReadOnly = Not editable
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub

    Private Sub stbVisitNo_Leave(sender As Object, e As System.EventArgs) Handles stbVisitNo.Leave
        Try
            If oVariousOptions.AllowAccountReceiptsRefunds() AndAlso Not Me.billModesID.Equals(oBillModesID.Cash) Then
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(stbVisitNo))
                If String.IsNullOrEmpty(visitNo) Then Return
                Dim receiptNo As String = RevertText(StringEnteredIn(cboReceiptNo, "Receipt No"))
                Me.LoadPaymentDetails(receiptNo, visitNo)

            End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ClearControls()
        Me.stbPayeeName.Clear()
        Me.stbRefundPayDate.Clear()
        Me.stbRequestedBy.Clear()
        Me.stbBillMode.Clear()
        Me.stbVisitNo.Clear()
        Me.stbVisitType.Clear()
        Me.nbxTotalRefundAmount.Clear()
        Me.nbxRefundAccountBalance.Clear()
        nbxRefundOutstandingBalance.Clear()
        nbxToRefundAmount.Clear()
        dgvPaymentRefunds.Rows.Clear()
    End Sub


    Private Sub CalculateReturnAmount(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colBillUnitPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colReturnAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colAmountBalance, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim returnQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colReturnedQuantity)
           
            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colPreviousRefundedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colPreviousRefundedQuantity)

            Dim toReturnQuantity As Integer = 0


            Dim toReturnAmount As Decimal = returnQuantity * unitPrice
            Dim totalReturnAmount As Decimal = previousReturnedAmount + toReturnAmount
            Dim totalReturnQuantity As Integer = returnQuantity + previousReturnedQuantity

            If returnQuantity > billQuantity Then
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return quantity: " + amount.ToString + " cannot be greater than bill quantity: " + billQuantity.ToString)
            ElseIf toReturnAmount > billAmount Then
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return amount: " + returnQuantity.ToString + " cannot be greater than bill amount: " + billAmount.ToString)

            End If



            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(toReturnAmount, AppData.DecimalPlaces)
            Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            Me.dgvPaymentRefunds.Item(Me.colTotalReturnQuantity.Name, selectedRow).Value = (returnQuantity + previousReturnedQuantity)
            Me.dgvPaymentRefunds.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)


            Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colReturnAmount)
            Dim totalAmount As Decimal = (DecimalMayBeEnteredIn(Me.stbAmountRefunded) + refundAmount)
            nbxToRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)
            nbxTotalRefundAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnNewPrice(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colBillUnitPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colReturnAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colAmountBalance, False)
            Dim itemCategory As String = StringEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colItemCategory, "ItemCategory")

            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colPreviousRefundedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colPreviousRefundedQuantity)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, colBillQuantity)




            Dim totalReturnAmount As Decimal = previousReturnedAmount + amount


            If amount > billAmount Then
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = String.Empty
                Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, selectedRow).Value = 0
                Throw New ArgumentException("Return amount: " + amount.ToString + " cannot be greater than bill amount: " + billAmount.ToString)


            End If



            Dim newPrice As Decimal = 0
            If billAmount = amount Then
                newPrice = 0
            Else : newPrice = (billAmount - amount) / (billQuantity)
            End If
            Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, selectedRow).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)

            Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber((newPrice), AppData.DecimalPlaces)

            Me.dgvPaymentRefunds.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)

            Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colReturnAmount)
            Dim totalAmount As Decimal = (DecimalMayBeEnteredIn(Me.stbAmountRefunded) + refundAmount)
            nbxToRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)
            nbxTotalRefundAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)


        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnAmountOnNewPrice(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colBillUnitPrice, False)
            Dim newPrice As Decimal = DecimalEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colNewPrice, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colAmountBalance, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvPaymentRefunds.Rows(selectedRow).Cells, Me.colPreviousRefundedAmount, False)

            If newPrice > unitPrice Then
                Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, selectedRow).Value = String.Empty
                Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                Throw New ArgumentException("The new price: " + newPrice.ToString + " cannot be greater than unit price: " + unitPrice.ToString)

            End If

            Dim returnAmount As Decimal
            If newPrice = unitPrice Then
                returnAmount = 0
            Else
                returnAmount = billQuantity * (unitPrice - newPrice)
            End If

            Me.dgvPaymentRefunds.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(returnAmount, AppData.DecimalPlaces)
            Me.dgvPaymentRefunds.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(newPrice, AppData.DecimalPlaces)
            Me.dgvPaymentRefunds.Item(Me.colReturnedQuantity.Name, selectedRow).Value = 0
            Me.dgvPaymentRefunds.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((previousReturnedAmount + returnAmount), AppData.DecimalPlaces)

            Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colReturnAmount)
            Dim totalAmount As Decimal = (DecimalMayBeEnteredIn(Me.stbAmountRefunded) + refundAmount)
            nbxToRefundAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)
            nbxTotalRefundAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    

    Private Sub rdoReduceQuantity_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoReduceQuantity.CheckedChanged
        Me.cboReceiptNo_Leave(Me, EventArgs.Empty)
        EnableColumns()
    End Sub

    Private Sub rdoReducePrice_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoReducePrice.CheckedChanged
        Me.cboReceiptNo_Leave(Me, EventArgs.Empty)
        EnableColumns()
    End Sub
    Private Sub EnableColumns()


        If Me.rdoReduceQuantity.Checked Then
            Me.colNewPrice.Visible = False
            Me.colReturnAmount.ReadOnly = True
            Me.colReturnedQuantity.Visible = True
        Else
            Me.colNewPrice.Visible = True
            Me.colReturnAmount.ReadOnly = False
            Me.colReturnedQuantity.Visible = False
        End If
    End Sub

   
    Private Sub cboReceiptNo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReceiptNo.SelectedIndexChanged

    End Sub
End Class