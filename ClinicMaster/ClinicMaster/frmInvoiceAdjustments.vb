
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports System.Collections.Generic
Imports SyncSoft.SQLDb
Imports SyncSoft.Common.SQL.Classes

Public Class frmInvoiceAdjustments

#Region " Fields "
    Dim oItemStatusID As New LookupDataID.ItemStatusID
    Dim oEntryModeID As New LookupDataID.EntryModeID
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oDocumentTypeID As New LookupDataID.DocumentTypeID()
    Private oAdjustmentTypeID As New LookupDataID.AdjustmentTypeID()
    Private oReversalActionID As New LookupDataID.ReversalActionID()
    Private visitTypeID As String
    Private extraBillNo As String
#End Region

    Private Property newPrice As Integer

    Private Sub frmInvoiceAdjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(colRefundReason, LookupObjects.ReturnReasonTypeID, False)
            LoadLookupDataCombo(cboCancellationReason, LookupObjects.ReturnReasonTypeID, False)
            LoadLookupDataCombo(cboReversalActionID, LookupObjects.ReversalAction, True)
            Me.dtpAdjustmentDate.MaxDate = Today

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInvoiceAdjustments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInvoiceAdjustments As New SyncSoft.SQLDb.InvoiceAdjustments()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oInvoiceAdjustments.AdjustmentNo = StringEnteredIn(Me.stbAdjustmentNo, "Adjustment No!")

            DisplayMessage(oInvoiceAdjustments.Delete())
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

        Dim AdjustmentNo As String

        Dim oInvoiceAdjustments As New SyncSoft.SQLDb.InvoiceAdjustments()

        Try
            Me.Cursor = Cursors.WaitCursor()

            AdjustmentNo = StringEnteredIn(Me.stbAdjustmentNo, "Adjustment No!")

            Dim dataSource As DataTable = oInvoiceAdjustments.GetInvoiceAdjustments(AdjustmentNo).Tables("InvoiceAdjustments")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click



        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.WaitCursor()


            Me.SaveInvoiceAdjustments()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetNextAdjustmentNo(ByVal invoiceNo As String)

        Try
            Me.stbAdjustmentNo.Clear()

            If String.IsNullOrEmpty(invoiceNo) Then Return

            Dim oInvoiceAdjustment As New SyncSoft.SQLDb.InvoiceAdjustments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("InvoiceAdjustments", "AdjustmentNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim InvoiceAdjustmentID As String = oInvoiceAdjustment.GetNextAdjustmentID(invoiceNo).ToString()
            InvoiceAdjustmentID = InvoiceAdjustmentID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbAdjustmentNo.Text = FormatText(invoiceNo + InvoiceAdjustmentID.Trim(), "InvoiceAdjustments", "AdjustmentNo")

        Catch ex As Exception
            Return
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


    Private Sub LoadInvoices(ByVal invoiceNo As String)

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Me.nbxAmount.Clear()

        Try
            If String.IsNullOrEmpty(invoiceNo) Then Return

            Dim row As DataRow = oInvoices.GetInvoices(invoiceNo).Tables("Invoices").Rows(0)
            Dim payTypeID As String = StringEnteredIn(row, "PayTypeID")
            Dim payNo As String = RevertText(StringEnteredIn(row, "PayNo"))
            Me.visitTypeID = StringEnteredIn(row, "VisitTypeID")
            Dim locked As Boolean = BooleanEnteredIn(row, "Locked")
            Dim cancelled As Boolean = BooleanEnteredIn(row, "Cancelled")

            Me.stbPayNo.Text = payNo
            Me.stbInvoiceDate.Text = FormatDate(DateEnteredIn(row, "InvoiceDate"))

            Me.stbStartDate.Text = FormatDate(DateEnteredIn(row, "StartDate"))
            Me.stbEndDate.Text = FormatDate(DateEnteredIn(row, "EndDate"))
            Me.stbInvoiceAmount.Text = FormatNumber(DecimalMayBeEnteredIn(row, "NetAmount"), AppData.DecimalPlaces)
            Me.stbPayeeName.Text = StringMayBeEnteredIn(row, "PayeeName")
            Me.stbVisitType.Text = StringEnteredIn(row, "VisitType")

            If cancelled Then Throw New ArgumentException("The Invoice No: " + invoiceNo + " is cancelled and  cannot be adjusted")

            LoadInvoiceBillDetails(invoiceNo, visitTypeID)


        Catch eX As Exception
            ErrorMessage(eX)
            ResetControlsIn(Me)
            Me.stbAdjustmentNo.Clear()
        End Try

    End Sub

    Private Sub LoadInvoiceBillDetails(ByVal invoiceNo As String, visitTypeID As String)

        Dim invoiceBillDetails As New DataTable
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()
        Dim oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems()

        Try

            Me.Cursor = Cursors.WaitCursor



            Me.dgvInvoiceAdjustments.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            If visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                invoiceBillDetails = oInvoiceExtraBillItems.GetToAdjustInvoiceExtraBillItems(invoiceNo).Tables("InvoiceExtraBillItems")
                Me.colVisitNo.DataPropertyName = "ExtraBillNo"
                Me.colVisitNo.HeaderText = "Extra Bill No"
                Me.colItemStatus.DataPropertyName = "EntryMode"
                Me.colItemStatus.HeaderText = "Entry Mode"
                Me.colItemStatusID.DataPropertyName = "EntryModeID"
                Me.colItemStatusID.HeaderText = "Entry Mode ID"
            ElseIf visitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient().ToUpper()) Then
                invoiceBillDetails = oInvoiceDetails.GetToAdjustInvoiceDetails(invoiceNo).Tables("InvoiceDetails")
                Me.colVisitNo.DataPropertyName = "VisitNo"
                Me.colVisitNo.HeaderText = "Visit No"
                Me.colItemStatus.DataPropertyName = "ItemStatus"
                Me.colItemStatus.HeaderText = "Item Status"
                Me.colItemStatusID.DataPropertyName = "ItemStatusID"
                Me.colItemStatusID.HeaderText = "Item Status ID"
            ElseIf visitTypeID.ToUpper().Equals(oVisitTypeID.Combined().ToUpper()) Then
                invoiceBillDetails = oInvoiceExtraBillItems.GetToAdjustInvoiceExtraBillItems(invoiceNo).Tables("InvoiceExtraBillItems")
                invoiceBillDetails.Merge(oInvoiceDetails.GetToAdjustInvoiceDetails(invoiceNo).Tables("InvoiceDetails"))
                Me.colVisitNo.DataPropertyName = "VisitNo"
                Me.colVisitNo.HeaderText = "Visit No"
            End If



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInvoiceAdjustments, invoiceBillDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = invoiceBillDetails.Rows.Count()

            If records < 1 Then Throw New ArgumentException("No returned records for the invoice no " + invoiceNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboInvoiceNo_Leave(sender As Object, e As System.EventArgs) Handles cboInvoiceNo.Leave
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim invoiceNo As String = RevertText(cboInvoiceNo.Text)
            Me.LoadInvoices(invoiceNo)
            SetNextAdjustmentNo(invoiceNo)
        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub dgvCreditNoDetails_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceAdjustments.CellEndEdit
        Dim row As Integer = e.RowIndex
        If row < 0 Then Return

        Dim returnPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(row).Cells, colReturnAmount, False)
        Dim include As Boolean = CBool(BooleanMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(row).Cells, colInclude))

        If e.ColumnIndex.Equals(Me.colInclude.Index) Then
            Me.SetEditableColumns(include, row)

        ElseIf e.ColumnIndex.Equals(Me.colQuantity.Index) Then
            Me.CalculateReturnAmount(row)

        ElseIf e.ColumnIndex.Equals(Me.colReturnAmount.Index) Then

            Me.CalculateReturnNewPrice(row)

        ElseIf e.ColumnIndex.Equals(Me.colNewPrice.Index) Then
            Me.CalculateReturnAmountOnNewPrice(row)

        End If



    End Sub



    Private Sub SetEditableColumns(editable As Boolean, row As Integer)


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not editable Then

            Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, row).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, row).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colRefundReason.Name, row).Value = String.Empty

            Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, row).ReadOnly = True
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).ReadOnly = True
            Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, row).ReadOnly = True
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).ReadOnly = True
            Me.dgvInvoiceAdjustments.Item(Me.colRefundReason.Name, row).Value = String.Empty

        Else
           

                Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, row).ReadOnly = False
                Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, row).ReadOnly = True
                Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).ReadOnly = True
                Me.dgvInvoiceAdjustments.Item(Me.colRefundReason.Name, row).Value = String.Empty

          
            Me.dgvInvoiceAdjustments.Item(Me.colRefundReason.Name, row).ReadOnly = Not editable
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub


    Private Function GetNextBillAdjustmentID(ByVal billNo As String) As String

        Dim creditNo As String = String.Empty
        Try

            Dim oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BillAdjustments", "AdjustmentNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim InventoryReturnsID As String = oBillAdjustments.GetNextBillAdjustmentID(billNo).ToString()
            InventoryReturnsID = InventoryReturnsID.PadLeft(paddingLEN, paddingCHAR)

            creditNo = FormatText(billNo + InventoryReturnsID.Trim(), "BillAdjustments", "AdjustmentNo")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

        Return creditNo
    End Function



    Private Sub SaveInvoiceAdjustments()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dgvInvoiceAdjustments.RowCount < 1 Then Throw New ArgumentException("Must Register At least one item!")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim AdjustmentNo As String = RevertText(StringEnteredIn(Me.stbAdjustmentNo, "Adjustment No!"))
            Dim invoiceNo As String = RevertText(StringEnteredIn(Me.cboInvoiceNo, "Invoice No!"))
            Dim payNo As String = RevertText(StringEnteredIn(Me.stbPayNo, "Pay No!"))
            Dim AdjustmentDate As Date = DateEnteredIn(Me.dtpAdjustmentDate, "Adjustment Date!")
            Dim adjustmentTypeID As String = oAdjustmentTypeID.Down()
            Dim reversalActionID As String = StringValueEnteredIn(Me.cboReversalActionID, "Reversal Action")
            Dim returnReasonID As String = String.Empty
            If reversalActionID.ToUpper().Equals(oReversalActionID.Cancellation().ToUpper()) Then returnReasonID = StringValueEnteredIn(Me.cboCancellationReason, "Cancellation Reason")
            Dim entryLevelID As String = oDocumentTypeID.CreditNote()
            Dim toAcknowledgeQuantity As Integer = 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim lInvoiceAdjustments As New List(Of DBConnect)
            Dim lInvoiceAdjustmentsDetail As New List(Of DBConnect)
            Dim lReturns As New List(Of DBConnect)
            Dim lReturnItems As New List(Of DBConnect)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oInvoiceAdjustments As New InvoiceAdjustments()

                With oInvoiceAdjustments

                    .AdjustmentNo = AdjustmentNo
                    .InvoiceNo = invoiceNo
                    .VisitTypeID = Me.visitTypeID
                    .AdjustmentTypeID = adjustmentTypeID
                    .ReversalActionID = reversalActionID
                    .EntryLevelID = oDocumentTypeID.CreditNote()
                    .AdjustmentDate = AdjustmentDate
                    .Amount = Me.nbxAmount.GetDecimal(False)
                    .LoginID = CurrentUser.LoginID


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lInvoiceAdjustments.Add(oInvoiceAdjustments)
                End With
            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each visitNo As String In Me.GetVisitNoList()

                Using oBillAdjustments As New SyncSoft.SQLDb.BillAdjustments()
                    With oBillAdjustments
                        .AdjustmentNo = RevertText(Me.GetNextBillAdjustmentID(visitNo))
                        .BillNo = visitNo
                        .AdjustmenTypeID = adjustmentTypeID
                        .VisitTypeID = Me.visitTypeID
                        .AdjustmentDate = AdjustmentDate
                        .LoginID = CurrentUser.LoginID

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With
                    lReturns.Add(oBillAdjustments)
                End Using
            Next

            For rowNo As Integer = 0 To Me.dgvInvoiceAdjustments.Rows.Count - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceAdjustments.Rows(rowNo).Cells
                Dim include As Boolean = CBool(BooleanMayBeEnteredIn(cells, colInclude))

                If include Then

                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                    Dim amount As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colReturnAmount, False)
                    Dim returnable As Boolean = CBool(BooleanMayBeEnteredIn(cells, colAcknowledgeable))

                    If reversalActionID.ToUpper().Equals(oReversalActionID.Adjustment) Then
                        returnReasonID = StringEnteredIn(cells, Me.colRefundReason, "Refund Reason!")
                    End If
                    Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVisitNo, "VisitNo!"))
                    Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colBillPrice, False)
                    Dim newPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colBillPrice, False)
                    Dim Quantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colQuantity)
                    Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colBillQuantity)
                    Dim billAmount As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(rowNo).Cells, colBillAmount, False)
                    Dim returnReasonDes As String = GetLookupDataDes(returnReasonID)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim pos As Integer = rowNo + 1

                    If AdjustmentDate > Today Then Throw New ArgumentException("Return date can’t be ahead of today!")

                    If reversalActionID.ToUpper().Equals(oReversalActionID.Adjustment().ToUpper()) Then
                        If Quantity < 1 Then Throw New ArgumentException("Returned quantity  can't be less than one at row " + pos.ToString + "!")
                        If Quantity < 1 AndAlso amount < 1 Then Throw New ArgumentException("Returned quantity and return Amount can’t be less than one " + pos.ToString + "!")
                        If Quantity > billQuantity Then Throw New ArgumentException("returned quantity can’t be more than bill quantity " + pos.ToString + "!")
                        If (amount > billAmount) AndAlso adjustmentTypeID.ToUpper.Equals(oAdjustmentTypeID.Down.ToUpper) Then Throw New ArgumentException("returned amount can’t be more than bill amount for down adjustment row" + pos.ToString + "!")
                        If (newPrice < unitPrice) AndAlso adjustmentTypeID.ToUpper.Equals(oAdjustmentTypeID.Up.ToUpper) Then Throw New ArgumentException("The new price can’t be less than bill price for up adjustments row " + pos.ToString + "!")
                        If (Quantity > 1) AndAlso adjustmentTypeID.ToUpper.Equals(oAdjustmentTypeID.Up.ToUpper) Then Throw New ArgumentException("returned Quantity cannot be greater than zero for up adjustments row" + pos.ToString + "!")
                    ElseIf reversalActionID.ToUpper().Equals(oReversalActionID.Cancellation().ToUpper()) Then
                        If Not Quantity = billQuantity Then Throw New ArgumentException("returned quantity must be equal to bill quantity at row " + pos.ToString + " for Invoice Cancellation!")
                        If (Not amount = billAmount) Then Throw New ArgumentException("returned amount  must be equal to bill amount  to bill quantity at row!" + pos.ToString + "for Invoice Cancellation!")
                    End If


                    ValidateEntriesIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.OutPatient) Then
                        Using oInvoiceDetailAdjustments As New SyncSoft.SQLDb.InvoiceDetailAdjustments()

                            With oInvoiceDetailAdjustments
                                .AdjustmentNo = AdjustmentNo
                                .InvoiceNo = invoiceNo
                                .VisitNo = visitNo
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .Quantity = Quantity
                                .Amount = amount
                                .ReturnReasonID = returnReasonID
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With

                            lInvoiceAdjustmentsDetail.Add(oInvoiceDetailAdjustments)
                        End Using

                    ElseIf Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient.ToUpper) Then
                        Using oInvoiceExtraBillItemAdjustments As New SyncSoft.SQLDb.InvoiceExtraBillItemAdjustments()

                            With oInvoiceExtraBillItemAdjustments
                                .AdjustmentNo = AdjustmentNo
                                .InvoiceNo = invoiceNo
                                .ExtraBillNo = visitNo
                                .ItemCategoryID = itemCategoryID
                                .ItemCode = itemCode
                                .Quantity = Quantity
                                .Amount = amount
                                .ReturnReasonID = returnReasonID
                                .LoginID = CurrentUser.LoginID


                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            End With

                            lInvoiceAdjustmentsDetail.Add(oInvoiceExtraBillItemAdjustments)
                        End Using
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.visitTypeID.ToUpper().Equals(oVisitTypeID.OutPatient.ToUpper()) Then

                        Using oItemAdjustments As New SyncSoft.SQLDb.ItemAdjustments()

                            With oItemAdjustments
                                .VisitNo = visitNo
                                .AdjustmentNo = Me.GetNextBillAdjustmentID(visitNo)
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .Quantity = Quantity
                                .Amount = amount
                                .NewPrice = newPrice
                                .Acknowledgeable = returnable
                                .EntryLevelID = entryLevelID
                                .Notes = returnReasonDes
                                .LoginID = CurrentUser.LoginID
                            End With

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lReturnItems.Add(oItemAdjustments)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                    ElseIf Me.visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()

                            With oExtraBillItemAdjustments
                                .ExtraBillNo = visitNo
                                .AdjustmentNo = Me.GetNextBillAdjustmentID(visitNo)
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .EntryLevelID = entryLevelID
                                .Quantity = Quantity
                                .Amount = amount
                                .NewPrice = newPrice
                                .Acknowledgeable = returnable
                                .Notes = returnReasonDes
                                .LoginID = CurrentUser.LoginID
                            End With

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lReturnItems.Add(oExtraBillItemAdjustments)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    If returnable Then toAcknowledgeQuantity += 1
                End If



            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If WarningMessage("You are about to perform an irreversible action are you sure you want to continue?") = Windows.Forms.DialogResult.No Then Return


            transactions.Add(New TransactionList(Of DBConnect)(lInvoiceAdjustments, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInvoiceAdjustmentsDetail, Action.Save))
            If reversalActionID.ToUpper().Equals(oReversalActionID.Adjustment().ToUpper()) Then
                transactions.Add(New TransactionList(Of DBConnect)(lReturns, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lReturnItems, Action.Save))
            End If
            DoTransactions(transactions)

            If toAcknowledgeQuantity > 0 AndAlso reversalActionID.ToUpper().Equals(oReversalActionID.Adjustment().ToUpper()) Then
                DisplayMessage(toAcknowledgeQuantity.ToString + " has been returned. Please ensure that " + Me.stbVisitType.Text + " acknowledgement is done")
            End If

            ResetControlsIn(Me)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub CalculateReturnAmount(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colReturnAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim returnQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colQuantity)
            Dim itemCategoryID As String = StringEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colItemCategoryID, "Item Category ID")
             Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colPreviousReturnedQuantity)

            Dim toReturnQuantity As Integer = 0

            Dim toReturnAmount As Decimal = returnQuantity * unitPrice
            Dim totalReturnAmount As Decimal = previousReturnedAmount + toReturnAmount
            Dim totalReturnQuantity As Integer = returnQuantity + previousReturnedQuantity





            If returnQuantity > billQuantity Then
                Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return quantity: " + amount.ToString + " cannot be greater than bill quantity: " + billQuantity.ToString)
            ElseIf toReturnAmount > billAmount Then
                Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, selectedRow).Value = 0
                Throw New ArgumentException("return amount: " + toReturnAmount.ToString + " cannot be greater than bill amount: " + billAmount.ToString)

            End If
            totalReturnAmount += amount




            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(toReturnAmount, AppData.DecimalPlaces)
            Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            Me.dgvInvoiceAdjustments.Item(Me.colTotalReturnQuantity.Name, selectedRow).Value = (returnQuantity + previousReturnedQuantity)
            Me.dgvInvoiceAdjustments.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)



            If (itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) OrElse
                itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) OrElse
                itemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper())) AndAlso returnQuantity > 0 Then
                Me.dgvInvoiceAdjustments.Item(Me.colAcknowledgeable.Name, selectedRow).ReadOnly = False
                Me.dgvInvoiceAdjustments.Item(Me.colAcknowledgeable.Name, selectedRow).Value = True

            Else
                Me.dgvInvoiceAdjustments.Item(Me.colAcknowledgeable.Name, selectedRow).ReadOnly = True
                Me.dgvInvoiceAdjustments.Item(Me.colAcknowledgeable.Name, selectedRow).Value = False

            End If

            Dim refundAmount As Decimal = CalculateGridAmount(dgvInvoiceAdjustments, Me.colReturnAmount)
            nbxAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnNewPrice(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillPrice, False)
            Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colReturnAmount, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim itemCategory As String = StringEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colItemCategory, "ItemCategory")

            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim previousReturnedQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colPreviousReturnedQuantity)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillQuantity)

            Dim adjustmentTypeID As String = StringValueEnteredIn(cboReversalActionID, "Adjustment Type")
            Dim newPrice As Decimal = 0

            Dim totalReturnAmount As Decimal = previousReturnedAmount + amount

            If adjustmentTypeID.ToUpper().Equals(oAdjustmentTypeID.Down().ToUpper()) Then


                If amount > billAmount Then
                    Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = String.Empty
                    Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = 0
                    Throw New ArgumentException("Adjusted amount: " + amount.ToString + " cannot be greater than bill amount: " + billAmount.ToString + " for down adjustment")


                End If

                If billAmount = amount Then
                    newPrice = 0
                Else : newPrice = (billAmount - amount) / (billQuantity)
                End If
            Else

                newPrice = (billAmount + amount) / (billQuantity)

            End If
            Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, selectedRow).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)

            Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber((newPrice), AppData.DecimalPlaces)

            Me.dgvInvoiceAdjustments.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)

            Dim refundAmount As Decimal = CalculateGridAmount(dgvInvoiceAdjustments, Me.colReturnAmount)
            nbxAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)


        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub CalculateReturnAmountOnNewPrice(selectedRow As Integer)


        Try
            Dim unitPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillPrice, False)
            Dim newPrice As Decimal = DecimalEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colNewPrice, False)
            Dim billAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillAmount, False)
            Dim billQuantity As Integer = IntegerEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colBillQuantity)
            Dim previousReturnedAmount As Decimal = DecimalMayBeEnteredIn(Me.dgvInvoiceAdjustments.Rows(selectedRow).Cells, Me.colPreviousReturnedAmount, False)
            Dim returnAmount As Decimal
            Dim adjustmentTypeID As String = StringValueEnteredIn(cboReversalActionID, "Adjustment Type")
            Dim totalReturnAmount As Decimal
            If adjustmentTypeID.ToUpper().Equals(oAdjustmentTypeID.Down().ToUpper()) Then

                If newPrice > unitPrice Then
                    Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = String.Empty
                    Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                    Throw New ArgumentException("The new price: " + newPrice.ToString + " cannot be greater than unit price: " + unitPrice.ToString + " for down adjustment")

                End If


                If newPrice = unitPrice Then
                    returnAmount = 0
                Else
                    returnAmount = billQuantity * (unitPrice - newPrice)
                End If
                totalReturnAmount += returnAmount
            Else
                If newPrice < unitPrice Then
                    Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = String.Empty
                    Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = 0
                    Throw New ArgumentException("The new price: " + newPrice.ToString + " cannot be less than unit price: " + unitPrice.ToString + " for up adjustments")

                End If

                returnAmount = billQuantity * (unitPrice + newPrice)


            End If
            Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, selectedRow).Value = FormatNumber(returnAmount, AppData.DecimalPlaces)
            Me.dgvInvoiceAdjustments.Item(Me.colNewPrice.Name, selectedRow).Value = FormatNumber(newPrice, AppData.DecimalPlaces)
            Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, selectedRow).Value = 0
            Me.dgvInvoiceAdjustments.Item(Me.colTotalReturnAmount.Name, selectedRow).Value = FormatNumber((totalReturnAmount), AppData.DecimalPlaces)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

        Dim refundAmount As Decimal = CalculateGridAmount(dgvInvoiceAdjustments, Me.colReturnAmount)
        nbxAmount.Text = FormatNumber(refundAmount, AppData.DecimalPlaces)

    End Sub


   


    Private Function GetVisitNoList() As List(Of String)
        Dim lvisitNo As New List(Of String)

        For rowNo As Integer = 0 To Me.dgvInvoiceAdjustments.Rows.Count - 1

            Dim cells As DataGridViewCellCollection = Me.dgvInvoiceAdjustments.Rows(rowNo).Cells
            Dim include As Boolean = CBool(BooleanMayBeEnteredIn(cells, colInclude))

            If include Then
                Dim visitNo As String = RevertText(StringEnteredIn(cells, Me.colVisitNo, "VisitNo!"))
                If Not lvisitNo.Contains(visitNo) Then lvisitNo.Add(visitNo)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Next
        Return lvisitNo
    End Function

    Private Sub EnableCheckItems()
        Try
            Me.Cursor = Cursors.WaitCursor
            'Me.cboInvoiceNo_Leave(Me, EventArgs.Empty)
            Me.nbxAmount.Clear()
            Dim reversalActionID As String = StringValueMayBeEnteredIn(cboReversalActionID)

            If String.IsNullOrEmpty(reversalActionID) Then Return
            If reversalActionID.Equals(oReversalActionID.Cancellation) Then
                For row As Integer = 0 To dgvInvoiceAdjustments.RowCount - 1
                    Me.dgvInvoiceAdjustments.Item(Me.colInclude.Name, row).Value = True
                    Me.dgvInvoiceAdjustments.Item(Me.colQuantity.Name, row).Value = Me.dgvInvoiceAdjustments.Item(Me.colBillQuantity.Name, row).Value
                    Me.dgvInvoiceAdjustments.Item(Me.colReturnAmount.Name, row).Value = Me.dgvInvoiceAdjustments.Item(Me.colBillAmount.Name, row).Value
                Next
                Me.cboCancellationReason.Enabled = True
                Me.dgvInvoiceAdjustments.ReadOnly = True
                Dim totalAmount As Decimal = CalculateGridAmount(dgvInvoiceAdjustments, colReturnAmount)
                Me.nbxAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
            Else
                Me.dgvInvoiceAdjustments.ReadOnly = False
                Me.cboCancellationReason.Enabled = False
                Me.cboCancellationReason.SelectedIndex = -1
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAdjustmentTypeID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboReversalActionID.SelectedIndexChanged
        EnableCheckItems()
    End Sub

    Private Sub dgvInvoiceAdjustments_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoiceAdjustments.CellContentClick

    End Sub
End Class