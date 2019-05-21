
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Collections.Generic
Imports SyncSoft.Lookup.SQL

Public Class frmRefundApprovals

#Region " Fields "
    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Dim oItemStatusID As New LookupDataID.ItemStatusID
    Private visitTypeID As String = String.Empty
#End Region


    Private Sub frmRefundApprovals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(colRefundReason, SyncSoft.SQLDb.Lookup.LookupObjects.ReturnReasonTypeID, False)
            ShowToApproveRefundRequest()
            Me.LoadApproalStatus()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmRefundApprovals_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oRefundApprovals As New SyncSoft.SQLDb.RefundApprovals()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oRefundApprovals.RefundRequestNo = StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!")

            DisplayMessage(oRefundApprovals.Delete())
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

        Dim oRefundApprovals As New SyncSoft.SQLDb.RefundApprovals()

        Try
            Me.Cursor = Cursors.WaitCursor()

            refundRequestNo = StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!")

            Dim dataSource As DataTable = oRefundApprovals.GetRefundApprovals(refundRequestNo).Tables("RefundApprovals")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oRefundApprovals As New SyncSoft.SQLDb.RefundApprovals()

        Try
            

            With oRefundApprovals

                .RefundRequestNo = RevertText(StringEnteredIn(Me.stbRefundRequestNo, "Refund Request No!"))
                .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                .AttendingPersonel = StringEnteredIn(Me.stbAttendingPersonel, "Attending Personal!")
                .ApprovalStausID = StringValueEnteredIn(Me.cboApprovalStatusID, "Approval Status!")
                .LoginID = CurrentUser.LoginID

                .RecordDateTime = Now()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    oRefundApprovals.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ShowToApproveRefundRequest()


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oRefundApprovals.Update())
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

    Private Sub ShowToApproveRefundRequest()

        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim pendingRefundRequests As DataTable = oRefundRequests.GetToApproveRefundRequests(String.Empty).Tables("RefundRequests")

            Dim pendingRequests As Integer = pendingRefundRequests.Rows.Count
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblPendingRefundRequests.Text = "Pending Request(s): " + pendingRequests.ToString()
            '   Me.btnLoadRefundRequests.Visible = pendingRequests > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

 


    Private Sub LoadRefundRequests(refundRequestNo As String)


        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()

        Try


            ClearControls()

            refundRequestNo = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))

            Me.Cursor = Cursors.WaitCursor()

            If String.IsNullOrEmpty(refundRequestNo) Then Return

            Dim dataSource As DataTable = oRefundRequests.GetToApproveRefundRequests(refundRequestNo).Tables("RefundRequests")
            Dim row As DataRow = dataSource.Rows(0)

            Dim receiptNo As String = StringEnteredIn(row, "ReceiptNo")
            Dim visitTypeID As String = StringEnteredIn(row, "VisitTypeID")

            If visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                Me.colVisitNo.DataPropertyName = "ExtraBillNo"
                Me.colVisitNo.HeaderText = "Extra Bill No"
                Me.colItemStatus.DataPropertyName = "EntryMode"
                Me.colItemStatus.HeaderText = "Entry Mode"
                Me.colItemStatusID.DataPropertyName = "EntryModeID"
                Me.colItemStatusID.HeaderText = "Entry Mode ID"
            Else : visitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient().ToUpper())

                Me.colVisitNo.DataPropertyName = "VisitNo"
                Me.colVisitNo.HeaderText = "Visit No"
                Me.colItemStatus.DataPropertyName = "ItemStatus"
                Me.colItemStatus.HeaderText = "Item Status"
                Me.colItemStatusID.DataPropertyName = "ItemStatusID"
                Me.colItemStatusID.HeaderText = "Item Status ID"

            End If


            ShowPayments(receiptNo)

            Me.ShowRefund(refundRequestNo)
            
            Me.LoadRefundRequestDetails(refundRequestNo)
            Me.btnLoadRefundRequests.Visible = True
            Me.lblPendingRefundRequests.Visible = True
            Me.cboReceiptNo.Text = receiptNo

        Catch ex As Exception
            ' ErrorMessage(ex)
            Throw ex
        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub CalculateRefundAmount()

        Dim refundAmount As Decimal = CalculateGridAmount(dgvPaymentRefunds, Me.colRefAmount)
        Dim previousRefunded As Decimal = DecimalMayBeEnteredIn(stbAmountRefunded)
        Dim amountAmount As Decimal = (refundAmount + previousRefunded)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        nbxTotalRefundAmount.Text = FormatNumber(amountAmount, AppData.DecimalPlaces)
        stbAmountRefunded.Value = FormatNumber(refundAmount, AppData.DecimalPlaces)

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


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbAttendingPersonel.Text = CurrentUser.FullName

            Me.stbPayeeName.Text = StringEnteredIn(row, "PayeeName")
            Me.stbRefundPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbRefundAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.nbxTotalRefundAmount.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountRefunded"), AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxRefundOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxRefundOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundOutstandingBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String
            Dim payeeNo As String = StringEnteredIn(row, "PayeeNo")
            Dim payTypeID As String = StringEnteredIn(row, "PayTypeID")
            Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")

            If payTypeID.ToUpper().Equals(oPayTypeID.VisitBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.ExtraBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.IPDRoundBill.ToUpper()) Then
                billModesID = oBillModesID.Cash

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.AccountBill.ToUpper()) Then
                billModesID = oBillModesID.Account

            ElseIf payTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                billModesID = oBillModesID.Insurance

            Else : billModesID = String.Empty
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountBalance As Decimal = GetAccountBalance(billModesID, payeeNo)
            Me.nbxRefundAccountBalance.Value = FormatNumber(accountBalance, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If accountBalance < 0 Then
                ErrProvider.SetError(Me.nbxRefundAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxRefundAccountBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim payDate As Date = DateEnteredIn(row, "PayDate")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '  Me.ApplySecurity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ShowRefund(ByVal refundRequestNo As String)

        Dim oRefunds As New SyncSoft.SQLDb.Refunds()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                      ControlChars.NewLine + "Please advice accordingly!"
            Dim debitBalanceErrorMSG As String = "Debit balance should be cleared first!"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim refunds As DataTable = oRefunds.uspGetRefundByRequestNo(refundRequestNo).Tables("Refunds")

            If refunds.Rows.Count < 1 Then Return
            Dim row As DataRow = refunds.Rows(0)
            Dim refundNo As String = StringEnteredIn(row, "RefundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRefundNo.Text = FormatText(refundNo, "Refunds", "refundNo")
            Me.stbRefundDate.Text = StringEnteredIn(row, "RefundDate")
            Me.stbRefudNotes.Text = StringMayBeEnteredIn(row, "Notes")

            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadRefundRequestDetails(refundRequentNo As String)
        Try

            Dim oRefundRequestDetails As New RefundRequestDetails()
            Dim oRefundRequestExtraBillItems As New RefundRequestExtraBillItems()
            Dim refundRequestDetails As DataTable = New DataTable

            dgvPaymentRefunds.Rows.Clear()

            If String.IsNullOrEmpty(Me.visitTypeID) Then Return

            If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                refundRequestDetails = oRefundRequestExtraBillItems.GetRefundRequestExtraBillItemsByRequestNo(refundRequentNo).Tables("RefundRequestExtraBillItems")

            ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient.ToUpper) Then
                refundRequestDetails = oRefundRequestDetails.GetRefundRequestDetailsByRequestNo(refundRequentNo).Tables("RefundRequestDetails")

            ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.Combined.ToUpper) Then
                refundRequestDetails = oRefundRequestDetails.GetRefundRequestDetailsByRequestNo(refundRequentNo).Tables("RefundRequestDetails")
                refundRequestDetails.Merge(oRefundRequestExtraBillItems.GetRefundRequestExtraBillItemsByRequestNo(refundRequentNo).Tables("RefundRequestExtraBillItems"))
            End If


            LoadGridData(Me.dgvPaymentRefunds, refundRequestDetails)
            FormatGridRow(dgvPaymentRefunds)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally

        End Try
    End Sub


    Private Sub btnLoadRefundRequests_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadRefundRequests.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim fPendingRefundRequests As New frmPendingRefundRequests(Me.stbRefundRequestNo, True)

            fPendingRefundRequests.ShowDialog(Me)

            Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))
            Me.LoadRefundRequests(refundRequestNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub stbRefundRequestNo_Leave(sender As Object, e As System.EventArgs) Handles stbRefundRequestNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor


            Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundRequestNo))
            Me.LoadRefundRequests(refundRequestNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LoadApproalStatus()
        Dim lItemStatusID As New List(Of LookupData)
        Dim oApprovedItemStatus As New LookupData()
        oApprovedItemStatus.DataID = oItemStatusID.Approved()
        oApprovedItemStatus.DataDes = GetLookupDataDes(oItemStatusID.Approved())
        Dim oCancelled As New LookupData()
        oCancelled.DataID = oItemStatusID.Canceled()
        oCancelled.DataDes = GetLookupDataDes(oItemStatusID.Canceled())

        lItemStatusID.Add(oApprovedItemStatus)
        lItemStatusID.Add(oCancelled)

        With cboApprovalStatusID
            .DataSource = Nothing
            .DataSource = lItemStatusID
            .DisplayMember = "DataDes"
            .ValueMember = "DataID"
            .SelectedIndex = -1
        End With



    End Sub


    Private Sub ClearControls()
        Me.stbPayeeName.Clear()
        Me.stbRefundPayDate.Clear()
        Me.stbRefudNotes.Clear()
        Me.stbAttendingPersonel.Clear()
        Me.stbNotes.Clear()
        Me.stbRefundNo.Clear()
        Me.stbRefundDate.Clear()
        Me.stbPayeeName.Clear()
        Me.cboReceiptNo.SelectedItem = String.Empty
        Me.stbAmountRefunded.Clear()
        Me.stbRefundAmountPaid.Clear()
        Me.nbxRefundAccountBalance.Clear()
        Me.nbxRefundOutstandingBalance.Clear()
        Me.nbxTotalRefundAmount.Clear()

        dgvPaymentRefunds.Rows.Clear()
    End Sub

  
    Private Sub frmRefundApprovals_Activated(sender As System.Object, e As System.EventArgs) Handles MyBase.Activated
        Try
            ShowToApproveRefundRequest()
        Catch ex As Exception

        End Try
    End Sub
End Class