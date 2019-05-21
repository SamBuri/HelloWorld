
Option Strict On

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

Public Class frmGoodsReceivedNote

#Region " Fields "
    Private oVariousOptions As New VariousOptions()
    Private currentAllSaved As Boolean = True
    Private currentPurchaseOrderNo As String = String.Empty

    Private WithEvents docGoodsReceivedNote As New PrintDocument()

    ' The paragraphs.
    Private _GRNParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)


    Private oPackSize As New LookupDataID.PackID

#End Region

#Region " Validations "

    Private Sub dtpReceivedDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpReceivedDate.Validating

        Dim errorMSG As String = "Received date can't be before order date!"

        Try

            Dim orderDate As Date = DateMayBeEnteredIn(Me.stbOrderDate)
            Dim receivedDate As Date = DateMayBeEnteredIn(Me.dtpReceivedDate)

            If receivedDate = AppData.NullDateValue Then Return

            If receivedDate < orderDate Then
                ErrProvider.SetError(Me.dtpReceivedDate, errorMSG)
                Me.dtpReceivedDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpReceivedDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmGoodsReceivedNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    
        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.useInventoryPacks()
            '''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpReceivedDate.MaxDate = Today
            Me.dtpReceivedDate.Checked = True
            '''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGRNNo.ReadOnly = InitOptions.GRNNoLocked
            Me.SetDefaultLocation()
            '''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmGoodsReceivedNote_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            If Not Me.AllSaved() Then
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                End If
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub frmGoodsReceivedNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        If Me.AllSaved() Then Me.Close()
    End Sub

    Private Sub stbPurchaseOrderNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbPurchaseOrderNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentPurchaseOrderNo = StringMayBeEnteredIn(Me.stbPurchaseOrderNo)
                ProcessTabKey(True)
            Else : currentPurchaseOrderNo = String.Empty
            End If

        Catch ex As Exception
            currentPurchaseOrderNo = String.Empty
        End Try

    End Sub

    Private Sub stbPurchaseOrderNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbPurchaseOrderNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentPurchaseOrderNo) Then
            Me.stbPurchaseOrderNo.Text = currentPurchaseOrderNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbPurchaseOrderNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbPurchaseOrderNo.Leave

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentPurchaseOrderNo) Then
                Me.stbPurchaseOrderNo.Text = currentPurchaseOrderNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim purchaseOrderNo As String = RevertText(StringMayBeEnteredIn(Me.stbPurchaseOrderNo))
            Me.ShowPurchaseOrders(purchaseOrderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicPurchaseOrders As New frmPeriodicPurchaseOrders(Me.stbPurchaseOrderNo, False)
            fPeriodicPurchaseOrders.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim purchaseOrderNo As String = RevertText(StringMayBeEnteredIn(Me.stbPurchaseOrderNo))
            Me.ShowPurchaseOrders(purchaseOrderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub nbxDiscountTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxDiscountTotal.TextChanged
        Me.CalculateBillForItems()
    End Sub

    Private Sub nbxCreditNoteOnTotal_TextChanged(sender As System.Object, e As System.EventArgs)
        Me.CalculateBillForItems()
    End Sub

    Private Sub nbxVATPercent_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxTotalVAT.TextChanged
        Me.CalculateBillForItems()
    End Sub

    Private Sub EnableSetInventoryLocation()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim location As String = StringMayBeEnteredIn(Me.cboDeliveryLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(location) Then
                Me.cboDeliveryLocationID.Enabled = False
            Else : Me.cboDeliveryLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboDeliveryLocationID.Enabled = True
        End Try

    End Sub

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDeliveryLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboDeliveryLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub useInventoryPacks()

        If Not oVariousOptions.UseOfInventoryPackSizes Then
            colPack.Visible = False
            colPackSize.Visible = False
            colTotalOrdered.Visible = False
            colTotalReceived.Visible = False
        End If
    End Sub
    Private Sub ClearControls()

        Me.stbGRNNo.Clear()
        Me.stbOrderDate.Clear()
        Me.stbSupplierName.Clear()
        Me.nbxDiscountTotal.Value = (0).ToString()
        Me.nbxTotalVAT.Value = (0).ToString()
        Me.ClearBillControls()
        Me.dgvGoodsReceivedNoteDetails.Rows.Clear()
        Me.btnEditPurchaseOrders.Enabled = False

    End Sub

    Private Sub ClearBillControls()
        ResetControlsIn(Me.pnlBill)
        Me.stbGrossAmount.Clear()
    End Sub

    Private Sub SetNextGRNNo(purchaseOrderNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oGoodsReceivedNote As New SyncSoft.SQLDb.GoodsReceivedNote()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("GoodsReceivedNote", "GRNNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextGRNID As String = oGoodsReceivedNote.GetNextGRNID(purchaseOrderNo).ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbGRNNo.Text = FormatText(purchaseOrderNo + nextGRNID.Trim(), "GoodsReceivedNote", "GRNNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPurchaseOrders(purchaseOrderNo As String)

        Dim oPurchaseOrders As New SyncSoft.SQLDb.PurchaseOrders()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(purchaseOrderNo) Then Return

            Dim message As String = "Purchase Order No: " + purchaseOrderNo + ", is already received!"
            If oPurchaseOrders.IsPurchaseOrderReceived(purchaseOrderNo) Then Throw New ArgumentException(message)

            Dim purchaseOrders As DataTable = oPurchaseOrders.GetPurchaseOrders(purchaseOrderNo).Tables("PurchaseOrders")
            Dim row As DataRow = purchaseOrders.Rows(0)

            Me.stbPurchaseOrderNo.Text = FormatText(purchaseOrderNo, "PurchaseOrders", "PurchaseOrderNo")
            Me.stbOrderDate.Text = FormatDate(DateEnteredIn(row, "OrderDate"))
            Me.stbSupplierName.Text = StringEnteredIn(row, "SupplierName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextGRNNo(purchaseOrderNo)
            Me.LoadPurchaseOrderDetails(purchaseOrderNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnEditPurchaseOrders, AccessRights.Update)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPurchaseOrderDetails(ByVal purchaseOrderNo As String)

        Dim styleUnitPrice As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oPurchaseOrderDetails As New SyncSoft.SQLDb.PurchaseOrderDetails()

        Try

            styleUnitPrice.BackColor = Color.MistyRose
            styleUnitPrice.Font = font

            Me.dgvGoodsReceivedNoteDetails.Rows.Clear()

            ' Load PurchaseOrderDetails
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderDetails As DataTable = oPurchaseOrderDetails.GetPurchaseOrderDetails(purchaseOrderNo).Tables("PurchaseOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then
                DisplayMessage("No pending purchase order waiting to be received!")
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvGoodsReceivedNoteDetails, orderDetails)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvGoodsReceivedNoteDetails.Rows

                If row.IsNewRow Then Exit For
                Me.dgvGoodsReceivedNoteDetails.Item(Me.colBonusQuantity.Name, row.Index).Value = 0
                Me.dgvGoodsReceivedNoteDetails.Item(Me.colDiscount.Name, row.Index).Value = FormatNumber(0)

                Dim unitPrice As Decimal
                Dim itemCode As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(row.Index).Cells, Me.colItemCode)
                Dim itemCategoryID As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(row.Index).Cells, Me.colItemCategoryID)
                Dim totalReceived As Integer = IntegerEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(row.Index).Cells, Me.colTotalOrdered)
                Dim rate As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(row.Index).Cells, Me.colRate)

                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                    Using oDrugs As New SyncSoft.SQLDb.Drugs()
                        Dim dataRow As DataRow = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                        unitPrice = DecimalMayBeEnteredIn(dataRow, "UnitPrice")
                    End Using

                ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                    Using oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
                        Dim dataRow As DataRow = oConsumableItems.GetConsumableItems(itemCode).Tables("ConsumableItems").Rows(0)
                        unitPrice = DecimalMayBeEnteredIn(dataRow, "UnitPrice")
                    End Using

                Else : unitPrice = 0

                End If

                Me.dgvGoodsReceivedNoteDetails.Item(Me.colTotalReceived.Name, row.Index).Value = totalReceived
                Me.dgvGoodsReceivedNoteDetails.Item(Me.colUnitPrice.Name, row.Index).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If rate >= unitPrice Then Me.dgvGoodsReceivedNoteDetails.Rows(row.Index).Cells(Me.colUnitPrice.Name).Style.ApplyStyle(styleUnitPrice)

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForItems()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub fbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSave.Click

        Dim message As String
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oGoodsReceivedNote As New SyncSoft.SQLDb.GoodsReceivedNote()
            Dim lGoodsReceivedNote As New List(Of DBConnect)

            With oGoodsReceivedNote

                .PurchaseOrderNo = RevertText(StringEnteredIn(Me.stbPurchaseOrderNo, "Purchase Order No!"))
                .GRNNo = RevertText(StringEnteredIn(Me.stbGRNNo, "GRN No!"))
                .ReceivedDate = DateEnteredIn(Me.dtpReceivedDate, "Received Date!")
                .AdviceNoteNo = StringMayBeEnteredIn(Me.stbAdviceNoteNo)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim deliveryLocationID As String = StringValueEnteredIn(Me.cboDeliveryLocationID, "Delivery Location!")
                If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                   Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(deliveryLocationID).ToUpper()) Then

                    message = "Selected from location " + Me.cboDeliveryLocationID.Text + " is not the same as " + InitOptions.Location +
                              " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboDeliveryLocationID.Focus() : Return

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DeliveryLocationID = deliveryLocationID
                .DiscountTotal = Me.nbxDiscountTotal.GetDecimal(False)
                .TotalVAT = Me.nbxTotalVAT.GetDecimal(False)
                .AmountWords = StringMayBeEnteredIn(Me.stbBillWords)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                'ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lGoodsReceivedNote.Add(oGoodsReceivedNote)

            transactions.Add(New TransactionList(Of DBConnect)(lGoodsReceivedNote, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.GoodsReceivedNoteDetailsList, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.InventoryList, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.BarCodeDetailsList, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.ItemUnitCostList, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(Me.VATPercentageList, Action.Update))


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            message = "You are about to perform an irreversible action that affects inventory stock. " +
                    ControlChars.NewLine + "Are you sure you want to save?"

            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            records = DoTransactions(transactions)
            DisplayMessage(records.ToString() + " record(s) affected!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkPrintOnSaving.Checked Then
                message = "You have not checked Print a GRN On Saving. " + ControlChars.NewLine + "Would you want a GRN printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintGoodsReceivedNote()
            Else : Me.PrintGoodsReceivedNote()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            Me.ClearBillControls()
            Me.SetDefaultLocation()
            Me.useInventoryPacks()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function GoodsReceivedNoteDetailsList() As List(Of DBConnect)
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim lGoodsReceivedNoteDetails As New List(Of DBConnect)

        Try

            Dim _GRNNo As String = RevertText(StringEnteredIn(Me.stbGRNNo, "GRN No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then Throw New ArgumentException("Must Register At least one item!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.Rows.Count - 1

                Using oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim orderedQuantity As Integer = IntegerEnteredIn(cells, Me.colOrderedQuantity, "Ordered Quantity!")
                    Dim receivedQuantity As Integer = IntegerEnteredIn(cells, Me.colReceivedQuantity, "Received Quantity!")
                    Dim pack As String = StringMayBeEnteredIn(cells, Me.colPack)
                    Dim PackSize As Integer = IntegerMayBeEnteredIn(cells, Me.colPackSize)
                    Dim bonusQuantity As Integer = IntegerEnteredIn(cells, Me.colBonusQuantity, "Bonus Quantity!")
                    Dim quantity As Integer = receivedQuantity + bonusQuantity

                    If String.IsNullOrEmpty(pack) Then
                        pack = oPackSize.NA
                    Else pack = GetLookupDataID(LookupObjects.Packs, pack)
                    End If
                  

                    With oGoodsReceivedNoteDetails

                        .GRNNo = _GRNNo
                        .ItemCategoryID = itemCategoryID
                        .ItemCode = itemCode
                        .ItemName = itemName
                        .UnitMeasure = StringMayBeEnteredIn(cells, Me.colUnitMeasure)
                        .OrderedQuantity = orderedQuantity
                        .ReceivedQuantity = receivedQuantity
                        .BonusQuantity = bonusQuantity
                        .Rate = DecimalEnteredIn(cells, Me.colRate, False, "Rate!")
                        .PackID = pack
                        .PackSize = PackSize
                        .Discount = DecimalEnteredIn(cells, Me.colDiscount, False, "Discount!")
                        .VATValue = DecimalEnteredIn(cells, Me.colVATValue, False, "VAT Value!")
                        .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "Amount!")
                        If quantity > 0 Then
                            .BatchNo = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                            .ExpiryDate = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")
                        Else
                            .BatchNo = StringMayBeEnteredIn(cells, Me.colBatchNo)
                            .ExpiryDate = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                        End If
                        If (receivedQuantity > orderedQuantity) Then
                            .Notes = StringEnteredIn(cells, Me.colNotes, "Notes (You are Receiving More Quantities than Ordered else Enter those Quantities as Bonus Quantities")
                        Else
                            .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                        End If
                        .PaystatusID = oPayStatusID.NotPaid
                        .LoginID = CurrentUser.LoginID

                    End With

                    lGoodsReceivedNoteDetails.Add(oGoodsReceivedNoteDetails)

                End Using

            Next

            Return lGoodsReceivedNoteDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InventoryList() As List(Of DBConnect)

        Dim lInventory As New List(Of DBConnect)
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Try

            Dim _GRNNo As String = RevertText(StringEnteredIn(Me.stbGRNNo, "GRN No!"))
            Dim locationID As String = StringValueEnteredIn(Me.cboDeliveryLocationID, "Delivery Location!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then Throw New ArgumentException("Must Register At least one item!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.Rows.Count - 1

                Using oInventory As New SyncSoft.SQLDb.Inventory()

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                    Dim receivedQuantity As Integer = IntegerEnteredIn(cells, Me.colReceivedQuantity, "Received Quantity!")
                    Dim bonusQuantity As Integer = IntegerEnteredIn(cells, Me.colBonusQuantity, "Bonus Quantity!")
                    Dim pack As String = StringMayBeEnteredIn(cells, Me.colPack)
                    Dim PackSize As Integer = IntegerMayBeEnteredIn(cells, colPackSize)
                    Dim quantity As Integer
                    If String.IsNullOrEmpty(pack) OrElse pack.Equals(oPackSize.NA) Then
                        quantity = receivedQuantity + bonusQuantity


                    Else : quantity = (PackSize * receivedQuantity) + bonusQuantity
                    End If

                    If quantity <= 0 Then Continue For
                    Dim batchNo As String = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                    Dim expiryDate As Date = DateEnteredIn(cells, Me.colExpiryDate, "Expiry Date!")
                    With oInventory

                        .LocationID = locationID
                        .ItemCode = itemCode
                        .ItemCategoryID = itemCategoryID
                        .TranDate = DateEnteredIn(Me.dtpReceivedDate, "Received Date!")
                        .StockTypeID = oStockTypeID.Received
                        .Quantity = quantity
                        .Details = "New Stock (" + itemName + ") Received via GRN No: " + _GRNNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        .BatchNo = batchNo
                        .ExpiryDate = expiryDate

                    End With

                    lInventory.Add(oInventory)

                End Using

            Next

            Return lInventory

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function VATPercentageList() As List(Of DBConnect)

        Dim lItemVATPercentage As New List(Of DBConnect)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.Rows.Count - 1

                Using oItemVATPercentage As New SyncSoft.SQLDb.ItemsVATPercentage

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                    Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colItemCode)
                    Dim itemCategoryID As String = StringMayBeEnteredIn(cells, Me.colItemCategoryID)
                    Dim _VATPercentage As Decimal = DecimalMayBeEnteredIn(cells, Me.colVATPercentage)

                    If _VATPercentage > 0 Then

                        With oItemVATPercentage
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .VATPercentage = _VATPercentage

                        End With

                        lItemVATPercentage.Add(oItemVATPercentage)
                    End If
                End Using

            Next


            Return lItemVATPercentage

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Private Function BarCodeDetailsList() As List(Of DBConnect)

        Dim lBarCodeDetails As New List(Of DBConnect)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.Rows.Count - 1

                Using oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                    Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colItemCode)
                    Dim itemCategoryID As String = StringMayBeEnteredIn(cells, Me.colItemCategoryID)
                    Dim barCode As String = StringMayBeEnteredIn(cells, Me.ColBarCode)

                    If Not String.IsNullOrEmpty(barCode) Then

                        With oBarCodeDetails
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .BarCode = barCode
                            .LoginID = CurrentUser.LoginID
                        End With

                        lBarCodeDetails.Add(oBarCodeDetails)
                    End If
                End Using

            Next


            Return lBarCodeDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ItemUnitCostList() As List(Of DBConnect)

        Dim lItemUnitCost As New List(Of DBConnect)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then Throw New ArgumentException("Must Register At least one item!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.Rows.Count - 1

                Using oItemUnitPrice As New SyncSoft.SQLDb.ItemUnitPrice()

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim rate As Decimal = DecimalEnteredIn(cells, Me.colRate, False, "Rate!")

                    With oItemUnitPrice

                        .VisitNo = String.Empty
                        .ItemCategoryID = itemCategoryID
                        .ItemCode = itemCode
                        .UnitPrice = Nothing
                        .UnitCost = rate

                    End With

                    lItemUnitCost.Add(oItemUnitPrice)

                End Using

            Next

            Return lItemUnitCost

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function AllSaved() As Boolean

        Try

            Dim message As String = "Please ensure that all items are saved on Goods Received Note!"
            Dim purchaseOrderNo As String = StringMayBeEnteredIn(Me.stbPurchaseOrderNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(purchaseOrderNo) Then Return True

            If Me.dgvGoodsReceivedNoteDetails.Rows.Count > 0 Then
                DisplayMessage(message)
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnEditPurchaseOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPurchaseOrders.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim purchaseOrderNo As String = RevertText(StringEnteredIn(Me.stbPurchaseOrderNo, "Purchase Order No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPurchaseOrders As New frmPurchaseOrders(purchaseOrderNo)
            fPurchaseOrders.Edit()
            fPurchaseOrders.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPurchaseOrders(purchaseOrderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " GoodsReceivedNote - Grid "

    Private Sub dgvGoodsReceivedNoteDetails_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGoodsReceivedNoteDetails.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim expiryDate As Date = DateMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(e.RowIndex).Cells, Me.colExpiryDate)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(expiryDate, "Expiry Date", Today, AppData.MaximumDate,
                                                                     Me.dgvGoodsReceivedNoteDetails, Me.colExpiryDate, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colExpiryDate.Index.Equals(e.ColumnIndex) AndAlso Me.dgvGoodsReceivedNoteDetails.Rows(e.RowIndex).IsNewRow Then

                Me.dgvGoodsReceivedNoteDetails.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(e.RowIndex).Cells, Me.colExpiryDate)
                If enteredDate = AppData.NullDateValue Then Me.dgvGoodsReceivedNoteDetails.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.colExpiryDate.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvGoodsReceivedNote_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGoodsReceivedNoteDetails.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvGoodsReceivedNoteDetails.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colReceivedQuantity.Index) Then
                Me.CalculateItemAmount(selectedRow)
                Me.CalculateBillForItems()

            ElseIf e.ColumnIndex.Equals(Me.colRate.Index) Then
                Me.CalculateItemAmount(selectedRow)
                Me.CalculateBillForItems()

            ElseIf e.ColumnIndex.Equals(Me.colDiscount.Index) Then
                Me.CalculateItemAmount(selectedRow)
                Me.CalculateBillForItems()

            ElseIf e.ColumnIndex.Equals(Me.colVATPercentage.Index) Then
                Me.CalculateItemAmount(selectedRow)
                Me.CalculateBillForItems()

            ElseIf e.ColumnIndex.Equals(Me.colAmount.Index) Then
                Me.CalculateItemRate(selectedRow)
                Me.CalculateBillForItems()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvGoodsReceivedNote_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvGoodsReceivedNoteDetails.UserDeletedRow
        Me.CalculateBillForItems()
    End Sub

    Private Sub dgvGoodsReceivedNote_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvGoodsReceivedNoteDetails.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForItems()

        Try

            Me.ClearBillControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim grossAmount As Decimal = CalculateGridAmount(Me.dgvGoodsReceivedNoteDetails, Me.colAmount)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim discountTotal As Decimal = DecimalMayBeEnteredIn(Me.nbxDiscountTotal, False)
            Dim totalVAT As Decimal = CalculateGridAmount(Me.dgvGoodsReceivedNoteDetails, Me.colVATValue)

            Dim netAmount As Decimal = grossAmount - discountTotal

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If grossAmount > 0 Then
                Me.nbxDiscountTotal.MaxValue = grossAmount
            Else : Me.nbxDiscountTotal.MaxValue = 0
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGrossAmount.Text = FormatNumber(grossAmount, AppData.DecimalPlaces)
            Me.stbBillForItem.Text = FormatNumber(netAmount, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(netAmount)

            Me.nbxTotalVAT.Text = FormatNumber(totalVAT, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub CalculateItemAmount(ByVal selectedRow As Integer)

        Dim quantity As Integer = IntegerEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colReceivedQuantity)
        Dim rate As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colRate)
        Dim discount As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colDiscount)
        Dim _VATPercentage As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colVATPercentage)
        Dim pack As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colPackSize)
        Dim PackSize As Single = IntegerEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colPackSize)
        Dim totalReceived As Integer

        If (String.IsNullOrEmpty(pack) OrElse GetLookupDataID(LookupObjects.Packs, pack).Equals(oPackSize.NA)) Then
            totalReceived = quantity
        Else
            totalReceived = CInt(quantity * PackSize)
        End If
        Dim amountBeforeVAT As Decimal = (totalReceived * rate) - discount

        Dim _VATValue As Decimal = (amountBeforeVAT * _VATPercentage / 100)

        If (_VATValue < 0) Then
            _VATValue = 0
        End If

        Dim amount As Decimal = amountBeforeVAT + _VATValue

        If (amount < 0) Then
            amount = 0
        End If




        Me.dgvGoodsReceivedNoteDetails.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)
        Me.dgvGoodsReceivedNoteDetails.Item(Me.colVATValue.Name, selectedRow).Value = FormatNumber(_VATValue, AppData.DecimalPlaces)
        Me.dgvGoodsReceivedNoteDetails.Item(Me.colTotalReceived.Name, selectedRow).Value = totalReceived
    End Sub

    Private Sub CalculateItemRate(ByVal selectedRow As Integer)

        Dim rate As Decimal
        Dim quantity As Single = IntegerEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colReceivedQuantity)
        Dim discount As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colDiscount)
        Dim amount As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colAmount)
        Dim _VATValue As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colVATValue)
        Dim totalReceived As Integer = IntegerEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(selectedRow).Cells, Me.colTotalReceived)

        If quantity = 0 Then
            rate = 0
        Else
            rate = (amount + discount - _VATValue) / totalReceived


        End If

        Me.dgvGoodsReceivedNoteDetails.Item(Me.colRate.Name, selectedRow).Value = FormatNumber(rate, AppData.DecimalPlaces)

    End Sub
#End Region

#Region " GoodsReceivedNote Printing "

    Private Sub PrintGoodsReceivedNote()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on GRN details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetGoodsReceivedNotePrintData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docGoodsReceivedNote
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docGoodsReceivedNote.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docGoodsReceivedNote_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docGoodsReceivedNote.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Goods Received Note".ToUpper()

            Dim _GRNNo As String = StringMayBeEnteredIn(Me.stbGRNNo)
            Dim orderNo As String = StringMayBeEnteredIn(Me.stbPurchaseOrderNo)
            Dim receivedDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpReceivedDate))
            Dim orderDate As String = FormatDate(DateMayBeEnteredIn(Me.stbOrderDate))
            Dim adviceNoteNo As String = StringMayBeEnteredIn(Me.stbAdviceNoteNo)
            Dim deliveryLocation As String = StringMayBeEnteredIn(Me.cboDeliveryLocationID)
            Dim supplierName As String = StringMayBeEnteredIn(Me.stbSupplierName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("GRN No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(_GRNNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Order No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(orderNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Received Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receivedDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Order Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(orderDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Advice Note No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(adviceNoteNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Delivery Location: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(deliveryLocation, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Supplier's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(supplierName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

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

                If _GRNParagraphs Is Nothing Then Return

                Do While _GRNParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(_GRNParagraphs(1), PrintParagraps)
                    _GRNParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        _GRNParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (_GRNParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetGoodsReceivedNotePrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 12
        Dim padQuantity As Integer = 4
        Dim padUnitMeasure As Integer = 8
        Dim padRate As Integer = 8
        Dim padDiscount As Integer = 6
        Dim padVAT As Integer = 6
        Dim padAmount As Integer = 12
        Dim padtotalVAT As Integer = 40
        Dim padNetAmount As Integer = 50


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        _GRNParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("UOM: ".PadRight(padUnitMeasure))
            tableHeader.Append("Rate: ".PadLeft(padRate))
            tableHeader.Append("Disc: ".PadLeft(padDiscount))
            tableHeader.Append("VAT: ".PadLeft(padVAT))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim quantity As String
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                count += 1

                Dim itemNo As String = (count).ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim totalReceived As String = cells.Item(Me.colTotalReceived.Name).Value.ToString()
                Dim bonusQuantity As Integer = IntegerMayBeEnteredIn(cells, Me.colBonusQuantity)
                If bonusQuantity > 0 Then
                    quantity = totalReceived + "(" + bonusQuantity.ToString() + ")"
                Else : quantity = totalReceived
                End If
                Dim unitMeasure As String = cells.Item(Me.colUnitMeasure.Name).Value.ToString()
                Dim rate As String = cells.Item(Me.colRate.Name).Value.ToString()
                Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                Dim _VATPercentage As String = cells.Item(Me.colVATValue.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(quantity.PadLeft(padQuantity))
                            If unitMeasure.Length > 8 Then
                                tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 8).PadRight(padUnitMeasure))
                            Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
                            End If
                            tableData.Append(rate.PadLeft(padRate))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(_VATPercentage.PadLeft(padVAT))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))
                    If unitMeasure.Length > 8 Then
                        tableData.Append(GetSpaces(1) + unitMeasure.Substring(0, 8).PadRight(padUnitMeasure))
                    Else : tableData.Append(GetSpaces(1) + unitMeasure.PadRight(padUnitMeasure))
                    End If
                    tableData.Append(rate.PadLeft(padRate))
                    tableData.Append(discount.PadLeft(padDiscount))
                    tableData.Append(_VATPercentage.PadLeft(padVAT))
                    tableData.Append(amount.PadLeft(padAmount))
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            _GRNParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim netAmountData As New System.Text.StringBuilder(String.Empty)
            Dim netAmountWords As New System.Text.StringBuilder(String.Empty)

            Dim grossAmount As Decimal = DecimalMayBeEnteredIn(Me.stbGrossAmount, True)
            Dim netAmount As Decimal = DecimalMayBeEnteredIn(Me.stbBillForItem, True)
            Dim billWords As String = StringMayBeEnteredIn(Me.stbBillWords)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim discountTotal As Decimal = DecimalMayBeEnteredIn(Me.nbxDiscountTotal, False)
            Dim totalVAT As Decimal = DecimalMayBeEnteredIn(Me.nbxTotalVAT, False)
            'Dim _VATValue As Decimal = CDec(((grossAmount - (discountTotal)) * _VATPercent) / 100)

            If discountTotal = 0 AndAlso totalVAT = 0 Then

                netAmountData.Append(ControlChars.NewLine)
                netAmountData.Append("Total Amount: ")

            Else

                Dim grossAmountData As New System.Text.StringBuilder(String.Empty)
                grossAmountData.Append(ControlChars.NewLine)
                grossAmountData.Append("Gross Amount: ")
                grossAmountData.Append(FormatNumber(grossAmount, AppData.DecimalPlaces).PadLeft(padNetAmount))
                grossAmountData.Append(ControlChars.NewLine)
                _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, grossAmountData.ToString()))

                If Not discountTotal = 0 Then

                    Dim discountData As New System.Text.StringBuilder(String.Empty)
                    discountData.Append("Discount on Total: ")
                    discountData.Append(FormatNumber(discountTotal, AppData.DecimalPlaces).PadLeft(padNetAmount - 5))
                    discountData.Append(ControlChars.NewLine)
                    _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, discountData.ToString()))

                End If

                If Not totalVAT = 0 Then

                    Dim _VATData As New System.Text.StringBuilder(String.Empty)
                    _VATData.Append("Total VAT " + GetSpaces(3))
                    _VATData.Append(FormatNumber(totalVAT, AppData.DecimalPlaces).PadLeft(padtotalVAT))
                    _VATData.Append(ControlChars.NewLine)
                    _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, _VATData.ToString()))

                End If

                netAmountData.Append(ControlChars.NewLine)
                netAmountData.Append("Net Amount: " + GetSpaces(2))

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            netAmountData.Append(FormatNumber(netAmount, AppData.DecimalPlaces).PadLeft(padNetAmount))
            netAmountData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, netAmountData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            netAmountWords.Append("(" + billWords.Trim() + " ONLY)")
            netAmountWords.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, netAmountWords.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region

#Region " GoodsReceivedNote Extras "

    Private Sub cmsGoodsReceivedNoteDetails_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsGoodsReceivedNote.Opening

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Me.dgvGoodsReceivedNoteDetails.ColumnCount < 1 OrElse Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then
                Me.cmsGoodsReceivedNoteCopy.Enabled = False
                Me.cmsGoodsReceivedNoteSelectAll.Enabled = False
                Me.cmsGoodsReceivedNoteEditItem.Enabled = False
                Me.cmsGoodsReceivedNotesRefresh.Enabled = False

            Else
                Dim rowIndex As Integer = Me.dgvGoodsReceivedNoteDetails.CurrentCell.RowIndex
                Dim itemCategoryID As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(rowIndex).Cells, Me.colItemCategoryID)

                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then
                    Me.cmsGoodsReceivedNoteEditItem.Tag = "Drugs"
                    Me.cmsGoodsReceivedNoteEditItem.Text = "&Edit Drug"
                ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then
                    Me.cmsGoodsReceivedNoteEditItem.Tag = "ConsumableItems"
                    Me.cmsGoodsReceivedNoteEditItem.Text = "&Edit Consumable "
                End If

                Me.cmsGoodsReceivedNoteCopy.Enabled = True
                Me.cmsGoodsReceivedNoteSelectAll.Enabled = True
                Me.cmsGoodsReceivedNoteEditItem.Enabled = True
                Me.cmsGoodsReceivedNotesRefresh.Enabled = True
                Security.Apply(Me.cmsGoodsReceivedNote, AccessRights.Update)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsGoodsReceivedNoteDetailsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsGoodsReceivedNoteCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvGoodsReceivedNoteDetails.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvGoodsReceivedNoteDetails))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsGoodsReceivedNoteDetailsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsGoodsReceivedNoteSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvGoodsReceivedNoteDetails.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsGoodsReceivedNoteEditItem_Click(sender As System.Object, e As System.EventArgs) Handles cmsGoodsReceivedNoteEditItem.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim rowIndex As Integer = Me.dgvGoodsReceivedNoteDetails.CurrentCell.RowIndex
            Dim itemCode As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(rowIndex).Cells, Me.colItemCode)
            Dim itemCategoryID As String = StringMayBeEnteredIn(Me.dgvGoodsReceivedNoteDetails.Rows(rowIndex).Cells, Me.colItemCategoryID)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                Dim fDrugs As New frmDrugs(itemCode, True)
                fDrugs.Edit()
                fDrugs.ShowDialog()

            ElseIf itemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                Dim fConsumableItems As New frmConsumableItems(itemCode, True)
                fConsumableItems.Edit()
                fConsumableItems.ShowDialog()

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsGoodsReceivedNoteDetailsRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmsGoodsReceivedNotesRefresh.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim purchaseOrderNo As String = RevertText(StringEnteredIn(Me.stbPurchaseOrderNo, "Purchase Order No!"))
            Me.ShowPurchaseOrders(purchaseOrderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



#End Region

End Class