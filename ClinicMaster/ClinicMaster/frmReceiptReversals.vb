
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmReceiptReversals

#Region " Fields "
    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oBillModesID As New LookupDataID.BillModesID()
    Private payNo As String
    Private visitType As String = String.Empty
    Private billModesID As String
#End Region

Private Sub frmReceiptReversals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

	Try
		Me.Cursor = Cursors.WaitCursor()



	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

    End Sub

    Private Sub LoadRefundRequests(refundRequestNo As String)


        Dim oRefundRequests As New SyncSoft.SQLDb.RefundDetails()

        Try
            Me.Cursor = Cursors.WaitCursor()
           
            Dim dataSource As DataTable = oRefundRequests.GetAllRefundDetails(refundRequestNo).Tables("RefundDetails")

            If dataSource.Rows.Count < 1 Then Return

            Dim row As DataRow = dataSource.Rows(0)

            Dim receiptNo As String = StringMayBeEnteredIn(row, "ReceiptNo")
            Dim visitNo As String = StringMayBeEnteredIn(row, "VisitNo")
            Dim fullName As String = StringMayBeEnteredIn(row, "FullName")
            Dim paydate As String = StringMayBeEnteredIn(row, "PayDate")
            Me.ShowPayments(receiptNo)
            Me.LoadRefundDetails(refundRequestNo)
            Me.stbReceiptNo.Text = receiptNo
            Me.stbPayeeName.Text = fullName
            Me.stbRefundPayDate.Text = paydate





        Catch ex As Exception
            If ex.Message.Contains("There is No") OrElse ex.Message.EndsWith("Position 0") Then
                Dim Message As String = "The Refund No: " + Me.stbRefundNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine _
                        + "If you are attempting to reverse it, Please note that it has already been Reversed! ." + ControlChars.NewLine _
                        + "Proceed to Cashier to receive the funds."
            Else
                ErrorMessage(ex)
                Me.clearControls()
            End If
        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Sub LoadRefundDetails(ByVal refundNo As String)

        Dim oPayments As New SyncSoft.SQLDb.RefundDetails()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RefundDetails
         

            Dim refundDetails As DataTable = oPayments.GetAllRefundDetails(refundNo).Tables("RefundDetails")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPaymentRefunds, refundDetails)
            FormatGridRow(Me.dgvPaymentRefunds)

            Dim Message As String = "The Refund No: " + Me.stbRefundNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine _
                     + "If you are attempting to reverse it, Please note that it has already been Reversed! ." + ControlChars.NewLine _
                     + "Proceed to Cashier to receive the funds."
            If refundDetails.Rows.Count < 1 Then DisplayMessage(Message)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

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
            Dim payments As DataTable = oPayments.GetPayments(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPayeeName.Text = StringEnteredIn(row, "PayeeName")
            Me.stbRefundPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
           
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim payeeNo As String = StringEnteredIn(row, "PayeeNo")
            Dim payTypeID As String = StringEnteredIn(row, "PayTypeID")
            Me.visitType = StringEnteredIn(row, "VisitTypeID")

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

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

Private Sub frmReceiptReversals_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
	If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
End Sub

Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
	Me.Close()
End Sub

Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

Dim oReceiptReversals As New SyncSoft.SQLDb.ReceiptReversals()

	Try
		Me.Cursor = Cursors.WaitCursor()

		'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
		If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

		oReceiptReversals.RefundNo = StringEnteredIn(Me.stbRefundNo, "Refund No!")

		DisplayMessage(oReceiptReversals.Delete())
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

Dim refundNo As String

Dim oReceiptReversals As New SyncSoft.SQLDb.ReceiptReversals()

	Try
		Me.Cursor = Cursors.WaitCursor()

		refundNo = StringEnteredIn(Me.stbRefundNo, "Refund No!")

		Dim dataSource As DataTable = oReceiptReversals.GetReceiptReversals(refundNo).Tables("ReceiptReversals")
		Me.DisplayData(dataSource)

	Catch ex As Exception
		ErrorMessage(ex)

	Finally
		Me.Cursor = Cursors.Default()

	End Try

End Sub

Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oReceiptReversals As New SyncSoft.SQLDb.ReceiptReversals()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim lItems As New List(Of DBConnect)
        Dim lReceiptReversals As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))


	Try
		Me.Cursor = Cursors.WaitCursor()
            

            With oReceiptReversals

                .ReceiptNo = RevertText(StringEnteredIn(Me.stbReceiptNo, "Receipt No!"))
                .RefundNo = RevertText(StringEnteredIn(Me.stbRefundNo, "Refund No!"))
                .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            lReceiptReversals.Add(oReceiptReversals)

            For rowNo As Integer = 0 To Me.dgvPaymentRefunds.RowCount - 1


                Dim cells As DataGridViewCellCollection = Me.dgvPaymentRefunds.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colReturnItemCode, "item!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategory)
                Dim VisitNo As String = RevertText(StringEnteredIn(cells, Me.ColVisitNo))
                Using oReceiptReversalsEXT As New SyncSoft.SQLDb.ReceiptReversalsEXT()
                    With oReceiptReversalsEXT

                        .ReceiptNo = RevertText(StringEnteredIn(Me.stbReceiptNo, "Receipt No!"))
                        .VisitNo = VisitNo
                        .ItemCode = itemCode
                        .ItemCategoryID = itemCategoryID

                    End With

                    lItems.Add(oReceiptReversalsEXT)

                End Using
            Next
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

            transactions.Add(New TransactionList(Of DBConnect)(lReceiptReversals, Action.Save))


            If dgvPaymentRefunds.RowCount > 0 Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim Message As String = "You are about to perform an irreversible action please ensure that you using the right Refund No! " +
                    "(Refund No: " + Me.stbRefundNo.Text + ", Receipt No: " + Me.stbReceiptNo.Text + ") " +
                    "will be Reversed." + ControlChars.NewLine + "Are you sure you want to save?"

                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            DoTransactions(transactions)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

End Sub

#Region " Edit Methods "

Public Sub Edit()

        'Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
	Me.ebnSaveUpdate.Enabled = False
	Me.fbnDelete.Visible = True
	Me.fbnDelete.Enabled = False
	Me.fbnSearch.Visible = True

	ResetControlsIn(Me)

End Sub

Public Sub Save()

	Me.ebnSaveUpdate.Enabled = True
	Me.fbnDelete.Visible = False
	Me.fbnDelete.Enabled = True
	Me.fbnSearch.Visible = False

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

    Private Sub stbRefundNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbRefundNo.Leave
        Dim refundRequestNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundNo))
        If String.IsNullOrEmpty(refundRequestNo) Then Return

        Me.LoadRefundRequests(refundRequestNo)
    End Sub

    Private Sub stbRefundNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbRefundNo.TextChanged

    End Sub
    Private Sub clearControls()
        Me.stbNotes.Clear()
        Me.stbPayeeName.Clear()
        Me.stbReceiptNo.Clear()
        Me.stbRefundPayDate.Clear()
        Me.stbRefundNo.Clear()
        Me.dgvPaymentRefunds.Rows.Clear()
    End Sub
End Class