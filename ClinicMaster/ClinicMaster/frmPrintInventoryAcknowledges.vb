
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports System.Drawing.Printing

Public Class frmPrintInventoryAcknowledges

#Region " Fields "

    'Private fromLocationID As String = String.Empty
    'Private toLocationID As String = String.Empty

    Private WithEvents docInventoryAcknowledges As New PrintDocument()

    ' The paragraphs.
    Private transferParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmPrintInventoryAcknowledges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPrintInventoryAcknowledges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInventoryAcknowledges As New frmPeriodicInventoryAcknowledges(Me.stbTransferNo)
            fPeriodicInventoryAcknowledges.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowInventoryTransfers()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbTransferNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbTransferNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.Leave

        Try

            Me.ShowInventoryTransfers()

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbTransferDate.Clear()
        Me.stbTransferDate.Clear()
        Me.stbFromLocation.Clear()
        Me.stbToLocation.Clear()
        Me.dgvInventoryAcknowledges.Rows.Clear()
        Me.btnPrint.Enabled = False
        Me.btnPrintPreview.Enabled = False

    End Sub

    Private Sub ShowInventoryTransfers()

        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim transferNo As String = RevertText(StringMayBeEnteredIn(Me.stbTransferNo))
            If String.IsNullOrEmpty(transferNo) Then Return

            Dim inventoryTransfers As DataTable = oInventoryTransfers.GetInventoryTransfers(transferNo).Tables("InventoryTransfers")
            Dim row As DataRow = inventoryTransfers.Rows(0)
            
            Me.stbTransferDate.Text = FormatDate(DateEnteredIn(row, "TransferDate"))
            Me.stbFromLocation.Text = StringEnteredIn(row, "FromLocation")
            Me.stbToLocation.Text = StringEnteredIn(row, "ToLocation")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInventoryAcknowledges(transferNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnPrint.Enabled = True
            Me.btnPrintPreview.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInventoryAcknowledges(ByVal transferNo As String)

        Dim oInventoryAcknowledges As New SyncSoft.SQLDb.InventoryAcknowledges()

        Try

            Me.dgvInventoryAcknowledges.Rows.Clear()

            ' Load InventoryAcknowledges

            Dim inventoryAcknowledges As DataTable = oInventoryAcknowledges.GetInventoryAcknowledges(transferNo).Tables("InventoryAcknowledges")
            If inventoryAcknowledges Is Nothing OrElse inventoryAcknowledges.Rows.Count < 1 Then
                DisplayMessage("No inventory acknowledges found!")
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim row As DataRow = inventoryAcknowledges.Rows(0)
            Me.stbReceivedDate.Text = FormatDate(DateEnteredIn(row, "ReceivedDate"))

            LoadGridData(Me.dgvInventoryAcknowledges, inventoryAcknowledges)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " InventoryAcknowledges Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintInventoryAcknowledges()

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

            Me.SetInventoryAcknowledgesPrintData()

            With dlgPrintPreview
                .Document = docInventoryAcknowledges
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

    Private Sub PrintInventoryAcknowledges()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInventoryAcknowledges.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry on Transfer details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInventoryAcknowledgesPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInventoryAcknowledges
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInventoryAcknowledges.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInventoryAcknowledges_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInventoryAcknowledges.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Internal Inventory Acknowledges".ToUpper()

            Dim transferNo As String = StringMayBeEnteredIn(Me.stbTransferNo)
            Dim transferDate As String = FormatDate(DateMayBeEnteredIn(Me.stbTransferDate))
            Dim receivedDate As String = FormatDate(DateMayBeEnteredIn(Me.stbReceivedDate))
            Dim fromLocation As String = StringMayBeEnteredIn(Me.stbFromLocation)
            Dim toLocation As String = StringMayBeEnteredIn(Me.stbToLocation)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Transfer No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(transferNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Transfer Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(transferDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Received Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receivedDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("From Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("To Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(toLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If transferParagraphs Is Nothing Then Return

                Do While transferParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(transferParagraphs(1), PrintParagraps)
                    transferParagraphs.Remove(1)

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
                        transferParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (transferParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInventoryAcknowledgesPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 25
        Dim padQuantity As Integer = 12
        Dim padBatchNo As Integer = 14
        Dim padExpiryDate As Integer = 12

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        transferParagraphs = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Quantity: ".PadLeft(padQuantity))
            tableHeader.Append(GetSpaces(1) + "Batch No: ".PadRight(padBatchNo))
            tableHeader.Append("Expiry Date: ".PadRight(padExpiryDate))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvInventoryAcknowledges.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInventoryAcknowledges.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colItemName)
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colQuantity)
                Dim batchNo As String = StringMayBeEnteredIn(cells, Me.colBatchNo)
                Dim expiryDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colExpiryDate))

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 25 Then
                    tableData.Append(itemName.Substring(0, 25).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(GetSpaces(1) + batchNo.PadRight(padBatchNo))
                tableData.Append(expiryDate.PadRight(padExpiryDate))

                tableData.Append(ControlChars.NewLine)

            Next

            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class