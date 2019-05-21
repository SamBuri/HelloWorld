Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPrintGoodsReceivedNotes
#Region " Fields "

    Private WithEvents docGoodsReceivedNote As New PrintDocument()

    ' The paragraphs.
    Private _GRNParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)



    Private padItemNo As Integer = 11
    Private padItemName As Integer = 20
    Private padNotes As Integer = 14
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 12
    Private padAmount As Integer = 12

#End Region


    Private Sub frmPrintGoodsReceivedNotes_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub frmPrintGoodsReceivedNotes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicGoodsReceivedNote As New frmPeriodicGoodsReceivedNote(Me.stbGRNNo)
            fPeriodicGoodsReceivedNote.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbGRNNo))
            Me.ShowGoodsReceivedNote(_GRNNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbGRNNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbGRNNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbGRNNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbGRNNo.Leave

        Try

            Dim _GRNNo As String = RevertText(StringMayBeEnteredIn(Me.stbGRNNo))
            Me.ShowGoodsReceivedNote(_GRNNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbPurchaseOrderNo.Clear()
        Me.stbReceivedDate.Clear()
        Me.stbAdviceNoteNo.Clear()
        Me.stbDeliveryLocation.Clear()
        Me.stbOrderDate.Clear()
        Me.stbSupplierName.Clear()
        Me.stbGrossAmount.Clear()
        Me.nbxDiscountTotal.Value = String.Empty
        Me.nbxTotalVAT.Value = String.Empty
        Me.stbBillForItem.Clear()
        Me.stbBillWords.Clear()
        Me.dgvGoodsReceivedNoteDetails.Rows.Clear()
        Me.btnPrint.Enabled = False
        Me.btnPrintPreview.Enabled = False

    End Sub

    Private Sub ShowGoodsReceivedNote(_GRNNo As String)

        Dim oGoodsReceivedNote As New SyncSoft.SQLDb.GoodsReceivedNote()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(_GRNNo) Then Return

            Dim goodsReceivedNote As DataTable = oGoodsReceivedNote.GetGoodsReceivedNote(_GRNNo).Tables("GoodsReceivedNote")
            Dim row As DataRow = goodsReceivedNote.Rows(0)
            Dim purchaseOrderNo As String = StringMayBeEnteredIn(row, "PurchaseOrderNo")

            Me.stbGRNNo.Text = FormatText(_GRNNo, "GoodsReceivedNote", "GRNNo")
            Me.stbPurchaseOrderNo.Text = FormatText(purchaseOrderNo, "PurchaseOrders", "PurchaseOrderNo")
            Me.stbReceivedDate.Text = FormatDate(DateMayBeEnteredIn(row, "ReceivedDate"))
            Me.stbAdviceNoteNo.Text = StringMayBeEnteredIn(row, "AdviceNoteNo")
            Me.stbDeliveryLocation.Text = StringMayBeEnteredIn(row, "DeliveryLocation")
            Me.stbOrderDate.Text = FormatDate(DateMayBeEnteredIn(row, "OrderDate"))
            Me.stbSupplierName.Text = StringMayBeEnteredIn(row, "SupplierName")
            Me.stbGrossAmount.Text = FormatNumber(DecimalMayBeEnteredIn(row, "GrossAmount"), AppData.DecimalPlaces)
            Me.nbxDiscountTotal.Value = FormatNumber(DecimalMayBeEnteredIn(row, "DiscountTotal"), AppData.DecimalPlaces)
            Me.nbxTotalVAT.Value = FormatNumber(DecimalMayBeEnteredIn(row, "TotalVAT"), AppData.DecimalPlaces)
            Me.stbBillForItem.Text = FormatNumber(DecimalMayBeEnteredIn(row, "GRNAmount"), AppData.DecimalPlaces)
            Me.stbBillWords.Text = StringMayBeEnteredIn(row, "AmountWords")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadGoodsReceivedNoteDetails(_GRNNo)
            Me.LoadGoodsReturnedNoteDetails(_GRNNo)
            CalculateTotalReturnAmount()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnPrint.Enabled = True
            Me.btnPrintPreview.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadGoodsReceivedNoteDetails(ByVal _GRNNo As String)

        Dim oGoodsReceivedNoteDetails As New SyncSoft.SQLDb.GoodsReceivedNoteDetails()

        Try

            Me.dgvGoodsReceivedNoteDetails.Rows.Clear()

            ' Load GoodsReceivedNoteDetails

            Dim goodsReceivedNoteDetails As DataTable = oGoodsReceivedNoteDetails.GetGoodsReceivedNoteDetails(_GRNNo).Tables("GoodsReceivedNoteDetails")
            If goodsReceivedNoteDetails Is Nothing OrElse goodsReceivedNoteDetails.Rows.Count < 1 Then
                DisplayMessage("No goods received note details to view!")
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvGoodsReceivedNoteDetails, goodsReceivedNoteDetails)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadGoodsReturnedNoteDetails(ByVal _GRNNo As String)

        Dim oGoodsReturnedNoteDetails As New SyncSoft.SQLDb.GoodsReturnedNoteDetails()

        Try

            Me.dgvGoodsReturnedNoteDetails.Rows.Clear()

            ' Load GoodsReturnedNoteDetails

            Dim goodsReturnedNoteDetails As DataTable = oGoodsReturnedNoteDetails.GetReturnedGoods(_GRNNo).Tables("GoodsReturnedNoteDetails")
            If goodsReturnedNoteDetails Is Nothing OrElse goodsReturnedNoteDetails.Rows.Count < 1 Then
                ' DisplayMessage("No goods received note details to view!")

                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvGoodsReturnedNoteDetails, goodsReturnedNoteDetails)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateTotalReturnAmount()

        Dim totalReturn As Decimal

        For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells
            Dim returnQuantity As Decimal = IntegerMayBeEnteredIn(cells, Me.colReturnQuantity)
            Dim rate As Decimal = DecimalMayBeEnteredIn(cells, Me.colRate)
            Dim amount As Decimal = (returnQuantity * rate)

            totalReturn += amount
        Next
        Dim totalBill As Decimal = DecimalMayBeEnteredIn(stbBillForItem)
        Dim netBill As Decimal = totalBill - totalReturn
        Me.stbReturnTotal.Text = FormatNumber(totalReturn, AppData.DecimalPlaces)
        Me.stbNetBill.Text = FormatNumber(netBill, AppData.DecimalPlaces)
        Me.stbnetBillInWords.Text = NumberToWords(netBill)
        'Me.stbnetBillInWords.Text = NumberToWords(totalBill)


    End Sub

#Region " GoodsReceivedNote Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintGoodsReceivedNote()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()


            Me.SetBillPrintData()

            With dlgPrintPreview
                .Document = docGoodsReceivedNote
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintGoodsReceivedNote()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReceivedNoteDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on GRN details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetBillPrintData()

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

            Dim title As String = AppData.ProductOwner.ToUpper() + " Goods Received Note (Copy)".ToUpper()

            Dim _GRNNo As String = StringMayBeEnteredIn(Me.stbGRNNo)
            Dim orderNo As String = StringMayBeEnteredIn(Me.stbPurchaseOrderNo)
            Dim receivedDate As String = FormatDate(DateMayBeEnteredIn(Me.stbReceivedDate))
            Dim orderDate As String = FormatDate(DateMayBeEnteredIn(Me.stbOrderDate))
            Dim adviceNoteNo As String = StringMayBeEnteredIn(Me.stbAdviceNoteNo)
            Dim deliveryLocation As String = StringMayBeEnteredIn(Me.stbDeliveryLocation)
            Dim supplierName As String = StringMayBeEnteredIn(Me.stbSupplierName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Dim padDate As Integer = 12
        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 18
        Dim padQuantity As Integer = 8
        Dim padReturned As Integer = 8
        Dim padUnitMeasure As Integer = 8
        Dim padRate As Integer = 10
        Dim padAmount As Integer = 12
        Dim padNetAmount As Integer = 58

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        _GRNParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Date: ".PadRight(padDate))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Rate: ".PadLeft(padRate))
            tableHeader.Append("Bill: ".PadLeft(padAmount))
            tableHeader.Append("Returned: ".PadLeft(padReturned))


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
                Dim transactionDate As String = cells.Item(Me.colReceivedDate.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()

                Dim returnedQuantity As String = cells.Item(Me.colReturnQuantity.Name).Value.ToString()
                Dim bonusQuantity As Integer = IntegerMayBeEnteredIn(cells, Me.colBonusQuantity)
                Dim returned As Decimal = (DecimalMayBeEnteredIn(cells, Me.colRate) * IntegerMayBeEnteredIn(cells, colReturnQuantity))
                Dim receivedQuantity As String = cells.Item(Me.colReceivedQuantity.Name).Value.ToString()
                If bonusQuantity > 0 Then
                    quantity = receivedQuantity + "(" + bonusQuantity.ToString() + ")"
                Else : quantity = receivedQuantity
                End If

                Dim rate As String = cells.Item(Me.colRate.Name).Value.ToString()
                Dim bill As String = cells.Item(Me.colAmount.Name).Value.ToString()

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
                            tableData.Append(transactionDate.PadLeft(padDate))
                            tableData.Append(quantity.PadLeft(padQuantity))

                            tableData.Append(rate.PadLeft(padRate))

                            tableData.Append(bill.PadLeft(padAmount))
                            tableData.Append(returned.ToString().PadLeft(padReturned))
                        End If
                    Next

                Else
                    tableData.Append(transactionDate.PadLeft(padDate))
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))


                    tableData.Append(rate.PadLeft(padRate))
                    tableData.Append(bill.PadLeft(padAmount))
                    tableData.Append(returned.ToString().PadLeft(padReturned))
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Returned''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim returnCounter As Integer = 0
            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells

                returnCounter += 1

                Dim itemNo As String = (returnCounter).ToString()
                Dim transactionDate As String = cells.Item(Me.colReturnDate.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colReturnItemName.Name).Value.ToString()

                Dim returnedQuantity As String = cells.Item(Me.colReturnedQuantity.Name).Value.ToString()


                Dim rate As String = cells.Item(Me.colreturnRate.Name).Value.ToString()
                Dim bill As String = cells.Item(Me.colreturnmount.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemNo, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(transactionDate.PadLeft(padDate))

                            tableData.Append(rate.PadLeft(padRate))

                            tableData.Append(bill.PadLeft(padAmount))

                        End If
                    Next

                Else
                    tableData.Append(transactionDate.PadLeft(padDate))
                    tableData.Append(FixDataLength(itemName, padItemName))


                    tableData.Append(rate.PadLeft(padRate))
                    tableData.Append(bill.PadLeft(padAmount))

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next


            _GRNParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim billAmount As New System.Text.StringBuilder(String.Empty)
            Dim netBillInWords As New System.Text.StringBuilder(String.Empty)

            Dim returnAmountData As New System.Text.StringBuilder(String.Empty)
            Dim returnAmountWords As New System.Text.StringBuilder(String.Empty)

            Dim grossAmount As Decimal = DecimalMayBeEnteredIn(Me.stbGrossAmount, True)
            Dim billforAmount As Decimal = DecimalMayBeEnteredIn(Me.stbBillForItem, True)
            Dim billWords As String = StringMayBeEnteredIn(Me.stbBillWords)

            Dim returnTotal As Decimal = DecimalMayBeEnteredIn(Me.stbReturnTotal, True)
            Dim netBill As Decimal = DecimalMayBeEnteredIn(Me.stbNetBill, True)
            Dim netBillWords As String = StringMayBeEnteredIn(Me.stbnetBillInWords)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim discountTotal As Decimal = DecimalMayBeEnteredIn(Me.nbxDiscountTotal, False)
            Dim totalVAT As Single = DecimalMayBeEnteredIn(Me.nbxTotalVAT)


            If discountTotal = 0 AndAlso totalVAT = 0 Then

                billAmount.Append(ControlChars.NewLine)
                billAmount.Append("Initial Bill: ")

            Else

                Dim grossAmountData As New System.Text.StringBuilder(String.Empty)
                grossAmountData.Append(ControlChars.NewLine)
                grossAmountData.Append("Bill Amount: ")
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
                    _VATData.Append(FormatNumber(totalVAT, AppData.DecimalPlaces).PadLeft(padNetAmount))
                    _VATData.Append(ControlChars.NewLine)
                    _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, _VATData.ToString()))

                End If

                billAmount.Append(ControlChars.NewLine)
                billAmount.Append("Total Bill: " + GetSpaces(2))

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            billAmount.Append(FormatNumber(billforAmount, AppData.DecimalPlaces - 1).PadLeft(padNetAmount))
            billAmount.Append(ControlChars.NewLine)
            billAmount.Append("Returned")
            billAmount.Append(FormatNumber(returnTotal, AppData.DecimalPlaces).PadLeft(padNetAmount))
            billAmount.Append(ControlChars.NewLine)
            billAmount.Append("Net Bill")
            billAmount.Append(FormatNumber(netBill, AppData.DecimalPlaces).PadLeft(padNetAmount))
            billAmount.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, billAmount.ToString()))


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            netBillInWords.Append("(" + netBillWords.Trim() + " ONLY)")
            netBillInWords.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, netBillInWords.ToString()))

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

    Private Sub SetBillPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        _GRNParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padNotes))
            tableHeader.Append("Date: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Rate: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            _GRNParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ReceivedGoodsData()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvGoodsReturnedNoteDetails.Rows.Count > 0 Then
                Dim returnsHeader As New System.Text.StringBuilder(String.Empty)
                returnsHeader.Append(ControlChars.NewLine)
                returnsHeader.Append("Returns: ")
                returnsHeader.Append(ControlChars.NewLine)
                _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, returnsHeader.ToString()))
                _GRNParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ReturnedGoodsData()))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalBillInvoice As Decimal = DecimalMayBeEnteredIn(stbNetBill)
            Dim totalAmount As New System.Text.StringBuilder(String.Empty)


            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Bill Amount: " + GetSpaces(5))
            totalAmount.Append(FormatNumber(totalBillInvoice).PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = stbnetBillInWords.Text
            amountWordsData.Append("(" + amountWords.Trim() + " ONLY)")
            amountWordsData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, amountWordsData.ToString()))

            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxDiscountTotal, True)
            Dim cashAccountBalanceData As New System.Text.StringBuilder(String.Empty)
            cashAccountBalanceData.Append(ControlChars.NewLine)
            If cashAccountBalance < 0 Then
                cashAccountBalanceData.Append("Cash Account Balance (DR): ")
            Else : cashAccountBalanceData.Append("Cash Account Balance (CR): ")
            End If
            cashAccountBalanceData.Append(FormatNumber(cashAccountBalance, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            Dim balanceDue As Decimal = totalBillInvoice - cashAccountBalance
            cashAccountBalanceData.Append("Balance Due: " + GetSpaces(14))
            cashAccountBalanceData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            If Not cashAccountBalance = 0 Then _GRNParagraphs.Add(New PrintParagraps(bodyBoldFont, cashAccountBalanceData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:   " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Received From: " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            _GRNParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ReceivedGoodsData() As String



        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim quantity As String
            Dim count As Integer = 0
            For rowNo As Integer = 0 To Me.dgvGoodsReceivedNoteDetails.RowCount - 1
                count += 1
                Dim cells As DataGridViewCellCollection = Me.dgvGoodsReceivedNoteDetails.Rows(rowNo).Cells

                Dim receiveDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colReceivedDate), "dd MMM yy")


                Dim itemNo As String = (count).ToString()
                Dim transactionDate As String = cells.Item(Me.colReceivedDate.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()

                Dim returnedQuantity As String = cells.Item(Me.colReturnQuantity.Name).Value.ToString()
                Dim bonusQuantity As Integer = IntegerMayBeEnteredIn(cells, Me.colBonusQuantity)
                Dim returned As Decimal = (DecimalMayBeEnteredIn(cells, Me.colRate) * IntegerMayBeEnteredIn(cells, colReturnQuantity))

                Dim receivedQuantity As String = cells.Item(Me.colReceivedQuantity.Name).Value.ToString()
                If bonusQuantity > 0 Then
                    quantity = receivedQuantity + "(" + bonusQuantity.ToString() + ")"
                Else : quantity = receivedQuantity
                End If

                Dim rate As String = cells.Item(Me.colRate.Name).Value.ToString()
                Dim bill As String = cells.Item(Me.colAmount.Name).Value.ToString()


                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(receiveDate.PadRight(padItemNo))
                If itemName.Length > 17 Then
                    tableData.Append(itemName.Substring(0, 17).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If



                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(rate.PadLeft(padUnitPrice))
                tableData.Append(bill.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)


            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ReturnedGoodsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim counter As Integer = 0
            For rowNo As Integer = 0 To Me.dgvGoodsReturnedNoteDetails.RowCount - 1

                counter += 1

                Dim cells As DataGridViewCellCollection = Me.dgvGoodsReturnedNoteDetails.Rows(rowNo).Cells
                Dim itemNo As String = (counter).ToString
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colReturnItemName)
                Dim returnDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colReturnDate), "dd MMM yy")
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colReturnedQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colreturnRate)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colreturnmount)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(quantity) AndAlso Not quantity = "0" Then quantity = "-" + quantity
                If Not String.IsNullOrEmpty(amount) AndAlso Not amount = "0" Then amount = "-" + amount
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(returnDate.PadRight(padItemNo))
                If itemName.Length > 17 Then
                    tableData.Append(itemName.Substring(0, 17).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If

                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

            Next

            If tableData.Length > 1 Then tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region


End Class