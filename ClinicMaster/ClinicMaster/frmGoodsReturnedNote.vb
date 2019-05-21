

Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.SQLDb
Imports SyncSoft.SQLDb.Lookup
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures

Public Class frmGoodsReturnedNote

#Region " Fields "
    Dim locationID As String
    Dim returnQuantity As Integer
    Dim receivedQuantity As Integer
    Dim returnAmount As Integer
    Dim rate As Integer
    Dim returnReasonID As String
    Dim itemCategoryID As String
    Dim _itemNo As String = String.Empty
    Private WithEvents docGoodsReturnedNote As New PrintDocument()

    ' The paragraphs.
    Private _ReturnNoteParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region


#Region " Edit Methods "

    Private Sub frmGoodsReturnedNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            LoadLookupDataCombo(Me.colReturnReason, LookupObjects.ReasonsToReturnGoods, False)
            Me.dtpReturnDate.MinDate = Today
            Me.stbTotalReturnAmount.Text = "0"


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmGoodsReturnedNote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSave.Click
        Dim message As String
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oGoodsReturnedNote As New SyncSoft.SQLDb.GoodsReturnedNote()
            Dim lGoodsReturnedNote As New List(Of DBConnect)

            With oGoodsReturnedNote
                .ReturnNo = RevertText(StringEnteredIn(Me.stbReturnNo, "Return No!"))
                .GRNNo = RevertText(StringEnteredIn(Me.stbGoodReceivedNoteNo, "GRN No!"))
                .ReturnDate = DateEnteredIn(Me.dtpReturnDate, "Return Date!")
                .AmountWords = StringEnteredIn(Me.stbReturnAmountWords, "Amount In Words!")
                .Notes = StringEnteredIn(Me.stbNotes, "Notes!")
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lGoodsReturnedNote.Add(oGoodsReturnedNote)
            transactions.Add(New TransactionList(Of DBConnect)(lGoodsReturnedNote, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.GoodsReturnedNoteDetailsList, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(Me.InventoryList, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            message = "You are about to perform an irreversible action that affects inventory stock. " +
                            ControlChars.NewLine + "Are you sure you want to save?"

            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            records = DoTransactions(transactions)
            DisplayMessage(records.ToString() + " record(s) affected!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not Me.chkPrintOnSaving.Checked Then
                message = "You have not checked Print a GRN On Saving. " + ControlChars.NewLine + "Would you want a GRN printed?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintGoodsReturnedNote()
            Else : Me.PrintGoodsReturnedNote()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim fPeriodicGoodsReceivedNote As New frmPeriodicGoodsReceivedNote((Me.stbGoodReceivedNoteNo))
            fPeriodicGoodsReceivedNote.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim GoodsReceivedNo As String = RevertText(StringMayBeEnteredIn(Me.stbGoodReceivedNoteNo))
            Me.ShowGoodsReceivedNotes(GoodsReceivedNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbGoodReceivedNoteNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbGoodReceivedNoteNo.Leave
        Try
            Dim GoodsReceivedNo As String = RevertText(StringMayBeEnteredIn(Me.stbGoodReceivedNoteNo))
            Me.ShowGoodsReceivedNotes(GoodsReceivedNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try


    End Sub

    Private Sub ShowGoodsReceivedNotes(ByVal GoodsReceivedNo As String)

        Dim oGoodsReceivedNote As New SyncSoft.SQLDb.GoodsReceivedNote()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.ClearControls()

            If String.IsNullOrEmpty(GoodsReceivedNo) Then Return

            'If oGoodsReceivedNote.IsGoodRecievedNoteProcessed(GoodsReceivedNo) Then
            '    Throw New ArgumentException("Goods Received Note with GRNNo: " + GoodsReceivedNo + " has already been processed")
            'End If

            Dim goodsRecievedNotes As DataTable = oGoodsReceivedNote.GetGoodsReceivedNote(GoodsReceivedNo).Tables("GoodsReceivedNote")
            Dim row As DataRow = goodsRecievedNotes.Rows(0)

            Me.dtpRecievedDate.Text = FormatDate(DateEnteredIn(row, "ReceivedDate"))
            Me.stbSupplierName.Text = StringEnteredIn(row, "SupplierName")
            Me.stbPurchaseOrderNo.Text = StringEnteredIn(row, "PurchaseOrderNo")
            Me.stbAmountWords.Text = StringEnteredIn(row, "AmountWords")
            Me.stbLocation.Text = StringEnteredIn(row, "DeliveryLocation")
            locationID = StringEnteredIn(row, "DeliveryLocationID")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextReturnNo(GoodsReceivedNo)
            ' Me.LoadGoodsReceivedNoteDetails(GoodsReceivedNo, locationID)
            Me.colSelect.Visible = True
        Catch ex As Exception
            ErrorMessage(ex)
            Me.ClearControls()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadGoodsReceivedNoteDetails(ByVal GRNNo As String, ByVal LocationID As String)

        Dim oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()

        Try

            Me.dgvGoodsReturnedNoteDetails.Rows.Clear()

            Dim NoteDetails As DataTable = oGoodsReceivedNoteDetails.GetGoodsReceivedNoteDetailsToReturn(GRNNo, LocationID).Tables("GoodsReceivedNoteDetails")

            Dim row As DataRow = NoteDetails.Rows(0)

            If NoteDetails Is Nothing OrElse NoteDetails.Rows.Count < 1 Then
                DisplayMessage("No pending Goods Received Notes waiting to be processed!")
                Return
            End If

            itemCategoryID = StringEnteredIn(row, "itemCategoryID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvGoodsReturnedNoteDetails, NoteDetails)

            If Me.dgvGoodsReturnedNoteDetails.RowCount < 2 Then
                Me.fbnSave.Enabled = False
            Else
                Me.fbnSave.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Public Sub SetNextReturnNo(ByVal GRNNo As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oGoodsReturnedNote As New SyncSoft.SQLDb.GoodsReturnedNote()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("GoodsReturnedNote", "ReturnNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim returnID As String = oGoodsReturnedNote.GetNextReturnID(GRNNo).ToString()
            returnID = returnID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbReturnNo.Text = FormatText(GRNNo + returnID.Trim(), "GoodsReturnedNote", "ReturnNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub ClearControls()
        Me.stbAmountWords.Clear()
        Me.stbNotes.Clear()
        Me.stbPurchaseOrderNo.Clear()
        Me.stbSupplierName.Clear()
        Me.stbReturnNo.Clear()
        Me.stbTotalReturnAmount.Text = "0"
    End Sub

    Private Function GoodsReturnedNoteDetailsList() As List(Of DBConnect)
        Dim lGoodsReturnedNoteDetails As New List(Of DBConnect)


        Try
            Dim _ReturnNo As String = RevertText(StringEnteredIn(Me.stbReturnNo, "Return No!"))
            Dim _GRNNo As String = RevertText(StringEnteredIn(Me.stbGoodReceivedNoteNo, "GRNN No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReturnedNoteDetails.RowCount < 2 Then Throw New ArgumentException("Must Register At least one item!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.Rows.Count - 2
                Using oGoodsReturnedNoteDetails As New SyncSoft.SQLDb.GoodsReturnedNoteDetails()

                    Dim rows As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(rows, Me.colItemCode, "Item Code!")
                    itemCategoryID = StringEnteredIn(rows, Me.colItemCategoryID, "Item Category ID!")

                    Dim itemName As String = StringEnteredIn(rows, Me.colItemName, "Item Name!")
                    Dim receivedQuantity As Integer = IntegerEnteredIn(rows, Me.colReceivedQuantity, "Received Quantity!")

                    returnReasonID = StringEnteredIn(rows, Me.colReturnReason, "Return Reason!")
                    returnQuantity = IntegerEnteredIn(rows, Me.colReturnQuantity, "Return Quantity!")
                    Dim unitsAtHand As Integer = IntegerEnteredIn(rows, Me.colReturnQuantity, "Return Quantity!")

                    '  rate = Integer.Parse(StringEnteredIn(rows, Me.colRate).Replace(",", ""))

                    If returnQuantity < 1 Then
                        Throw New ArgumentException("Cumulative Return Quantity can't be less that 1 !")

                    End If

                    With oGoodsReturnedNoteDetails
                        .ReturnNo = _ReturnNo
                        .ItemCategoryID = itemCategoryID
                        .ItemCode = itemCode
                        .ItemName = itemName
                        .ReturnQuantity = returnQuantity
                        .GoodsReturnReasonID = returnReasonID
                        .LoginID = CurrentUser.LoginID
                    End With

                    lGoodsReturnedNoteDetails.Add(oGoodsReturnedNoteDetails)
                End Using
            Next

            Return lGoodsReturnedNoteDetails

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Throw ex


        End Try

    End Function

    Private Function InventoryList() As List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Try
            Dim returnNo As String = StringEnteredIn(Me.stbReturnNo, "Return No!")

            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.Rows.Count - 2

                Using oInventory As New SyncSoft.SQLDb.Inventory()

                    Dim cells As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                    Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID, "Item Category!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colReturnQuantity, "Return Quantity!")
                    Dim batchNo As String = StringEnteredIn(cells, Me.colBatchNo, "Batch No!")
                    Dim expiryDate As Date = CDate(FormatDate(DateEnteredIn(cells, Me.colExpiryDate, "ExpiryDate")))

                    With oInventory

                        .LocationID = locationID
                        .ItemCode = itemCode
                        .ItemCategoryID = itemCategoryID
                        .TranDate = Today
                        .StockTypeID = oStockTypeID.Issued
                        .Quantity = quantity
                        .Details = "Stock (" + itemName + ") Returned via Return No: " + returnNo
                        .EntryModeID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                        .BatchNo = batchNo
                        .ExpiryDate = expiryDate

                    End With

                    lInventory.Add(oInventory)

                End Using

            Next




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return lInventory
    End Function

#End Region

#Region "Grid"


    Private Sub dgvGoodsReturnedNoteDetails_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateAmount(ByVal selectedRow As Integer)
        Try


            Dim _quantity As Single = SingleMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedRow).Cells, Me.colReturnQuantity)
            Dim _rate As Decimal = DecimalMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedRow).Cells, Me.colRate)
            If (Not String.IsNullOrEmpty(_quantity.ToString) AndAlso Not String.IsNullOrEmpty(_rate.ToString)) Then
                Me.dgvGoodsReturnedNoteDetails.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(_quantity * _rate, AppData.DecimalPlaces)

                Me.CalculateTotalReturnAmount()
            End If

        Catch ex As Exception
            Throw ex

        Finally
        End Try

    End Sub

#End Region

    Private Sub CalculateTotalReturnAmount()

        Dim totalBill As Decimal

        For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
            totalBill += amount
        Next

        Me.stbTotalReturnAmount.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbReturnAmountWords.Text = NumberToWords(totalBill)

    End Sub


#Region " GoodsReturnedNote Printing "

    Private Sub PrintGoodsReturnedNote()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReturnedNoteDetails.RowCount < 2 Then Throw New ArgumentException("Must set at least one entry on Goods Returned Note details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetGoodsReturnedNotePrintData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docGoodsReturnedNote
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docGoodsReturnedNote.Print()

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub SetGoodsReturnedNotePrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 18
        Dim padReturnedQuantity As Integer = 10
        Dim padRate As Integer = 16
        Dim padDiscount As Integer = 11
        Dim padAmount As Integer = 12
        Dim padTotalAmount As Integer = 58
        Dim totalAmount As Integer

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        _ReturnNoteParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No ".PadRight(padItemNo))
            tableHeader.Append("Item Name ".PadRight(padItemName))
            tableHeader.Append("Returned Qty".PadRight(padReturnedQuantity))
            tableHeader.Append("Rate ".PadLeft(padRate))
            tableHeader.Append("Discount".PadLeft(padDiscount))
            tableHeader.Append("Amount ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            _ReturnNoteParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells

                count += 1

                Dim itemNo As String = (count).ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim rate As String = cells.Item(Me.colRate.Name).Value.ToString()
                Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()
                returnQuantity = CInt(cells.Item(colReturnQuantity.Name).Value)
                totalAmount = totalAmount + CInt(amount)

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
                            tableData.Append(returnQuantity.ToString().PadLeft(padReturnedQuantity))
                            tableData.Append(rate.PadLeft(padRate))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(returnQuantity.ToString().PadLeft(padReturnedQuantity))
                    tableData.Append(rate.PadLeft(padRate))
                    tableData.Append(discount.PadLeft(padDiscount))
                    tableData.Append(amount.PadLeft(padAmount))
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            _ReturnNoteParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            _ReturnNoteParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Processed By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            _ReturnNoteParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:        " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            _ReturnNoteParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            _ReturnNoteParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub docGoodsReturnedNote_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docGoodsReturnedNote.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Goods Returned Note".ToUpper()


            Dim ReturnNo As String = StringEnteredIn(Me.stbReturnNo)
            Dim _GRNNo As String = StringEnteredIn(Me.stbGoodReceivedNoteNo)
            Dim purchaseNo As String = StringEnteredIn(Me.stbPurchaseOrderNo)
            Dim ReturnDate As String = FormatDate(DateEnteredIn(Me.dtpReturnDate))
            '  Dim ReturnReason As String = StringEnteredIn(Me.colReturnReason)
            Dim SupplierName As String = StringEnteredIn(Me.stbSupplierName)
            Dim Notes As String = StringEnteredIn(Me.stbNotes)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Return No:  ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ReturnNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond + 15, yPos)
                    .DrawString("GRN No:  ", bodyNormalFont, Brushes.Black, xPos + widthTopThird * 1.5F, yPos)
                    .DrawString(_GRNNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird * 1.75F, yPos)
                    yPos += lineHeight

                    .DrawString("Purchase Order No:  ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(purchaseNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond + 15, yPos)
                    yPos += lineHeight

                    .DrawString("Supplier Name:  ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(SupplierName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond + 15, yPos)
                    yPos += lineHeight


                    .DrawString("Return Date:  ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ReturnDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond + 15, yPos)
                    yPos += lineHeight

                    '     .DrawString("Reason To Return:", bodyNormalFont, Brushes.Black, xPos, yPos)
                    '   .DrawString(ReturnReason, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    '   yPos += lineHeight

                    .DrawString("Notes:  ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(Notes, bodyBoldFont, Brushes.Black, xPos + widthTopSecond + 15, yPos)
                    yPos += lineHeight

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

                If _ReturnNoteParagraphs Is Nothing Then Return

                Do While _ReturnNoteParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(_ReturnNoteParagraphs(1), PrintParagraps)
                    _ReturnNoteParagraphs.Remove(1)

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
                        _ReturnNoteParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (_ReturnNoteParagraphs.Count > 0)

            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintGoodsReturnedNote()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region


    Private Function GetItemsToReTurn() As DataTable

        Dim oSetupData As New SetupData()
        Dim GoodsReceivedNo As String = RevertText(StringMayBeEnteredIn(Me.stbGoodReceivedNoteNo))




        Dim NoteDetails As DataTable = New DataTable()
        Try
            If (Not String.IsNullOrEmpty(GoodsReceivedNo) OrElse Not String.IsNullOrEmpty(locationID)) Then

                Dim oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()
                NoteDetails = oGoodsReceivedNoteDetails.GetGoodsReceivedNoteDetailsToReturn(GoodsReceivedNo, locationID).Tables("GoodsReceivedNoteDetails")

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return NoteDetails
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub dgvGoodsReturnedNoteDetails_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGoodsReturnedNoteDetails.CellClick
        Me.Cursor = Cursors.WaitCursor

        If e.RowIndex < 0 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Received Items", "Item Code", "Item Name", Me.GetItemsToReTurn(),
                                                                     "ItemFullName", "ItemCode", "ItemName", Me.dgvGoodsReturnedNoteDetails, Me.colItemCode, e.RowIndex)

        _itemNo = StringMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(e.RowIndex).Cells, Me.colItemCode)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvGoodsReturnedNoteDetails.Rows(e.RowIndex).IsNewRow Then

            Me.dgvGoodsReturnedNoteDetails.Rows.Add()

            fSelectItem.ShowDialog(Me)
            Me.SetReturnedEntries(e.RowIndex)

        ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

            fSelectItem.ShowDialog(Me)
            Me.SetReturnedEntries(e.RowIndex)

        End If
        Me.Cursor = Cursors.Default

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
        If Me.dgvGoodsReturnedNoteDetails.RowCount < 1 Then
            Me.fbnSave.Enabled = False
        Else
            Me.fbnSave.Enabled = True
        End If
    End Sub


    Private Sub SetReturnedEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedRow).Cells, Me.colItemCode))
            Me.SetReturnedEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetReturnedEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells, Me.colItemCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Item No (" + enteredItem + ") already selected!")
                        Me.dgvGoodsReturnedNoteDetails.Rows.RemoveAt(selectedRow)
                        Me.dgvGoodsReturnedNoteDetails.Item(Me.colItemCode.Name, selectedRow).Value = _itemNo
                        Me.dgvGoodsReturnedNoteDetails.Item(Me.colItemCode.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailReturns(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailReturns(ByVal selectedRow As Integer)

        Try

            Dim oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()
            Dim itemNo As String = String.Empty
            Dim _GRNNo As String = RevertText(StringEnteredIn(stbGoodReceivedNoteNo, "GRNNo!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReturnedNoteDetails.Rows.Count > 1 Then
                itemNo = SubstringRight(StringMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedRow).Cells, Me.colItemCode))
            End If

            If String.IsNullOrEmpty(itemNo) OrElse String.IsNullOrEmpty(_GRNNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim returnedItems As DataTable = oGoodsReceivedNoteDetails.GetGoodsReceivedNoteDetailsToReturn(_GRNNo, locationID, itemNo).Tables("GoodsReceivedNoteDetails")


            Dim row As DataRow = returnedItems.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemName As String = StringEnteredIn(row, "ItemName", "Item Name!")
            Dim ItemCategoryID As String = StringMayBeEnteredIn(row, "ItemCategoryID")
            Dim ItemCategory As String = StringMayBeEnteredIn(row, "ItemCategory")
            Dim ExpiryDate As String = StringMayBeEnteredIn(row, "ExpiryDate")
            Dim BatchNo As String = StringMayBeEnteredIn(row, "BatchNo")
            Dim totalReceived As String = StringMayBeEnteredIn(row, "TotalReceived")
            Dim previousReturned As String = StringMayBeEnteredIn(row, "PreviousReturned")
            Dim Rate As String = StringMayBeEnteredIn(row, "Rate")
            Dim Discount As String = StringMayBeEnteredIn(row, "Discount")
            Dim UnitsAtHand As String = StringMayBeEnteredIn(row, "UnitsAtHand")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvGoodsReturnedNoteDetails

                .Item(Me.colItemCode.Name, selectedRow).Value = itemNo.ToUpper()
                .Item(Me.colItemName.Name, selectedRow).Value = itemName
                .Item(Me.colItemCategory.Name, selectedRow).Value = ItemCategory
                .Item(Me.colItemCategoryID.Name, selectedRow).Value = ItemCategoryID
                .Item(Me.colPreviousReturned.Name, selectedRow).Value = previousReturned
                .Item(Me.colBatchNo.Name, selectedRow).Value = BatchNo
                .Item(Me.colExpiryDate.Name, selectedRow).Value = ExpiryDate
                .Item(Me.colReceivedQuantity.Name, selectedRow).Value = totalReceived
                .Item(Me.colRate.Name, selectedRow).Value = Rate
                .Item(Me.colDiscount.Name, selectedRow).Value = Discount
                .Item(Me.colUnitsAtHand.Name, selectedRow).Value = UnitsAtHand

                CalculateTotalReturnAmount()

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvGoodsReturnedNoteDetails.Item(Me.colItemCode.Name, selectedRow).Value = Me._itemNo.ToUpper()
            Throw ex

        End Try

    End Sub


    Private Sub dgvGoodsReturnedNoteDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGoodsReturnedNoteDetails.CellEndEdit
        Try
            Dim selectedrow As Integer = Me.dgvGoodsReturnedNoteDetails.CurrentCell.RowIndex
            returnQuantity = IntegerMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedrow).Cells, Me.colReturnQuantity)
            ''''''''''''''''''

            receivedQuantity = IntegerMayBeEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedrow).Cells, Me.colReceivedQuantity)
            Dim unitsAtHand As Integer = IntegerEnteredIn(Me.dgvGoodsReturnedNoteDetails.Rows(selectedrow).Cells, Me.colUnitsAtHand)

            If returnQuantity < 1 Then
                Throw New ArgumentException("Return Quantity can't be less that 1 !")
            ElseIf Not (returnQuantity <= receivedQuantity AndAlso returnQuantity <= unitsAtHand) Then
                Throw New ArgumentException("Return Quantity can't be more than Received Quantity or Units At Hand!")
            End If
            ''''''''''''''''''
            Me.CalculateAmount(selectedrow)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub dgvGoodsReturnedNoteDetails_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvGoodsReturnedNoteDetails.UserDeletedRow
        Me.CalculateTotalReturnAmount()
    End Sub
End Class