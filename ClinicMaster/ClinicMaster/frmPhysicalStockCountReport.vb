
Option Strict On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures

Public Class frmPhysicalStockCountReport
    Private WithEvents docPhysicalStockCount As New PrintDocument()
    Private physicalStockCountDetailsParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)


#Region " Fields "

#End Region

    Private Sub frmPhysicalStockCount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPhysicalStockCount_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oPhysicalStockCount.PSCNo = StringEnteredIn(Me.stbPSCNo, "PSC No!")

            DisplayMessage(oPhysicalStockCount.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim pSCNo As String

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor()

            pSCNo = StringEnteredIn(Me.stbPSCNo, "PSC No!")

            Dim dataSource As DataTable = oPhysicalStockCount.GetPhysicalStockCount(pSCNo).Tables("PhysicalStockCount")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicPhysicalStockCount As New frmPeriodicPhysicalStockCount(stbPSCNo)
            fPeriodicPhysicalStockCount.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _PSCNo As String = RevertText(StringMayBeEnteredIn(Me.stbPSCNo))
            Me.ShowPhysicalStockCounts(_PSCNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPhysicalStockCounts(_PSCNo As String)

        Dim oPhysicalStockCount As New SyncSoft.SQLDb.PhysicalStockCount()

        Try
            Me.Cursor = Cursors.WaitCursor


            If String.IsNullOrEmpty(_PSCNo) Then Return

            Dim message As String = "Purchase Order No: " + _PSCNo + ", is already received!"

            Dim physicalStockCount As DataTable = oPhysicalStockCount.GetPhysicalStockCount(_PSCNo).Tables("PhysicalStockCount")
            Dim row As DataRow = physicalStockCount.Rows(0)

            Me.stbPSCNo.Text = FormatText(_PSCNo, "PSCNo", "PSCNo")
            Me.stbRecordDate.Text = FormatDate(DateEnteredIn(row, "RecordDate"))
            Me.stbGeneralNotes.Text = StringEnteredIn(row, "GeneralNotes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadPhysicalStockCountDetails(_PSCNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadPhysicalStockCountDetails(ByVal _PSCNo As String)

        Dim styleUnitPrice As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

        Dim oPhysicalStockCountDetails As New SyncSoft.SQLDb.PhysicalStockCountDetails()

        Try

            styleUnitPrice.BackColor = Color.MistyRose
            styleUnitPrice.Font = font

            Me.dgvPhysicalStockCountDetails.Rows.Clear()

            ' Load PhysicalStockCountDetails
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim physicalStockCountDetails As DataTable = oPhysicalStockCountDetails.GetPhysicalStockCountDetails(_PSCNo).Tables("PhysicalStockCountDetails")
            If physicalStockCountDetails Is Nothing OrElse physicalStockCountDetails.Rows.Count < 1 Then
                DisplayMessage("No pending Physical stock count!")
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPhysicalStockCountDetails, physicalStockCountDetails)

            Me.btnPrint.Enabled = True
            Me.btnPrintPreview.Enabled = True
            Me.fbnExport.Visible = True
            Me.lblRecordsImported.Text = physicalStockCountDetails.Rows.Count.ToString + " row(s) Returned"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region "Print"

    Private Sub PrintPhysicalStockCount()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPhysicalStockCountDetails.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry one item!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPhysicalStockCountDetailPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPhysicalStockCount
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPhysicalStockCount.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPhysicalStockCount_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPhysicalStockCount.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + "Period Physical Stock Count".ToUpper()

            Dim _PSCNo As String = StringMayBeEnteredIn(Me.stbPSCNo)
            Dim recordDate As String = FormatDate(DateMayBeEnteredIn(Me.stbRecordDate))
            Dim generalNotes As String = FormatDate(DateMayBeEnteredIn(Me.stbGeneralNotes))


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

                    .DrawString("PSC No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(_PSCNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Record Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(recordDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("General Notes: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(generalNotes, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight



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

                If physicalStockCountDetailsParagraphs Is Nothing Then Return

                Do While physicalStockCountDetailsParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(physicalStockCountDetailsParagraphs(1), PrintParagraps)
                    physicalStockCountDetailsParagraphs.Remove(1)

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
                        physicalStockCountDetailsParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (physicalStockCountDetailsParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPhysicalStockCountDetailPrintData()

        Dim padItemNo As Integer = 3
        Dim padlocation As Integer = 10
        Dim padItemCategory As Integer = 9
        Dim padItemCode As Integer = 10
        Dim padItemName As Integer = 10
        Dim padSystemQuantity As Integer = 8
        Dim padphysicalCountQuanty As Integer = 8
        Dim padVariance As Integer = 5
        Dim padNotes As Integer = 10

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        physicalStockCountDetailsParagraphs = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Location".PadRight(padlocation))
            tableHeader.Append("Category".PadRight(padItemCategory))
            tableHeader.Append("Item Code".PadRight(padItemCode))
            tableHeader.Append("Item Name".PadRight(padItemName))
            tableHeader.Append("Sy Qty".PadRight(padSystemQuantity))
            tableHeader.Append("Psc Qty".PadRight(padphysicalCountQuanty))
            tableHeader.Append("Diff".PadRight(padVariance))
            tableHeader.Append("Notes".PadRight(padNotes))
            tableHeader.Append(ControlChars.NewLine)
            physicalStockCountDetailsParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvPhysicalStockCountDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvPhysicalStockCountDetails.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim location As String = StringMayBeEnteredIn(cells, Me.colLocation)
                Dim itemCategory As String = StringMayBeEnteredIn(cells, Me.colItemCategory)
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colItemCode)
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colItemName)
                Dim systemStockQuatity As String = StringMayBeEnteredIn(cells, Me.colSystemQuantity)
                Dim stockCountQuantity As String = StringMayBeEnteredIn(cells, Me.colPhysicalCountQuantity)
                Dim variance As String = StringMayBeEnteredIn(cells, Me.colVariance)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)



                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(location.PadRight(padlocation))
                tableData.Append(itemCategory.PadRight(padItemCategory))
                tableData.Append(itemCode.PadRight(padItemCode))
                If itemName.Length > 8 Then
                    tableData.Append(itemName.Substring(0, 8).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(systemStockQuatity.PadRight(padSystemQuantity))
                tableData.Append(stockCountQuantity.PadRight(padphysicalCountQuanty))
                tableData.Append(variance.PadRight(padVariance))
                If notes.Length > 10 Then
                    tableData.Append(notes.Substring(0, 10).PadRight(padNotes))
                Else : tableData.Append(notes.PadRight(padNotes))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            physicalStockCountDetailsParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            physicalStockCountDetailsParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            physicalStockCountDetailsParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            physicalStockCountDetailsParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetPhysicalStockCountDetailPrintData()

            With dlgPrintPreview
                .Document = docPhysicalStockCount
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintPhysicalStockCount()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ExportToExcel(Me.dgvPhysicalStockCountDetails, Me.Text)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class