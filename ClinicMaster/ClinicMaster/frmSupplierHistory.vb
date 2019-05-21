
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports System.Collections.Generic
Imports SyncSoft.Lookup.SQL
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures

Public Class frmSupplierHistory

#Region " Fields "
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()

    Private WithEvents docPrintSupplierHistory As New PrintDocument()
    Private supplierHistoryParagraph As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

    Private Sub frmSupplierHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadSuppliers()
            LoadItemCategories()
            Me.LoadGoodsReceivedNoteDetailsSupplierHistory(Today, Now)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmSupplierHistory_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub




    Private Sub LoadSuppliers()

        Dim oSuppliers As New SyncSoft.SQLDb.Suppliers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Suppliers

            Dim suppliers As DataTable = oSuppliers.GetSuppliers().Tables("Suppliers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboSupplierNo, suppliers, "SupplierFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim itemCategory As String = StringValueMayBeEnteredIn(cboItemCategory)

            If String.IsNullOrEmpty(itemCategory) Then Return
            cboItemCode.Enabled = True
            Dim oDrug As New Drugs()
            Dim oConsumableItem As New ConsumableItems()
            Dim datable As New DataTable()

            If itemCategory.Equals(oItemCategoryID.Drug) Then
                datable = oDrug.GetDrugs().Tables("Drugs")

                LoadComboData(Me.cboItemCode, datable, "DrugFullName")

            ElseIf itemCategory.Equals(oItemCategoryID.Consumable)
                datable = oConsumableItem.GetConsumableItems().Tables("ConsumableItems")
                LoadComboData(Me.cboItemCode, datable, "ConsumableFullName")
            End If



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Public Function GetSupplierHistory(ByVal SupplierNo As String, ByVal ItemCategoryID As String, ByVal ItemCode As String, startDate As Date, endDate As Date) As DataSet
        Dim OGoodsReceivedNoteDetails As New GoodsReceivedNoteDetails()

        If String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, String.Empty, String.Empty, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(SupplierNo, String.Empty, String.Empty, startDate, endDate)

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, ItemCategoryID, String.Empty, startDate, endDate)

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, String.Empty, ItemCode, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(SupplierNo, ItemCategoryID, String.Empty, startDate, endDate)

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(SupplierNo, String.Empty, ItemCode, startDate, endDate)

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(String.Empty, ItemCategoryID, ItemCode, startDate, endDate)

        Else
            Return OGoodsReceivedNoteDetails.GoodsReceivedDetailsSupplierHistory(SupplierNo, ItemCategoryID, ItemCode, startDate, endDate)
        End If

    End Function

    Public Function GetMessage(ByVal SupplierNo As String, ByVal ItemCategoryID As String, ByVal ItemCode As String, startDate As Date, endDate As Date) As String

        Dim startPeriod As String = FormatDate(startDate)
        Dim endPeriod As String = FormatDate(endDate)

        If String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Supplier: " + stbSupplierName.Text

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Item Category: " + GetLookupDataDes(ItemCategoryID)

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for ItemCode " + ItemCode

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Item Category: " + GetLookupDataDes(ItemCategoryID) + " and " + stbSupplierName.Text

        ElseIf String.IsNullOrEmpty(SupplierNo) AndAlso Not String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Item Category: " + GetLookupDataDes(ItemCategoryID) + " and " + ItemCode

        ElseIf Not String.IsNullOrEmpty(SupplierNo) AndAlso String.IsNullOrEmpty(ItemCategoryID) AndAlso Not String.IsNullOrEmpty(ItemCode) Then
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Supplier: " + stbSupplierName.Text + " ItemCode: " + ItemCode



        Else
            Return "No records found between " + startPeriod + " and " + endPeriod + " for Supplier: " + stbSupplierName.Text + " and Item Category " + GetLookupDataDes(ItemCategoryID) + " and Item Code " + ItemCode
        End If

    End Function

    Private Sub LoadGoodsReceivedNoteDetailsSupplierHistory(startDateTime As Date, endDateTime As Date)

        Dim GoodsReceivedNoteDetails As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim supplierNo As String = RevertText(StringMayBeEnteredIn(cboSupplierNo))
            Dim itemCategoryID As String = StringValueMayBeEnteredIn(cboItemCategory)
            Dim itemCode As String = RevertText(SubstringRight(StringMayBeEnteredIn(cboItemCode)))


            GoodsReceivedNoteDetails = GetSupplierHistory(supplierNo, itemCategoryID, itemCode, startDateTime, endDateTime).Tables("GoodsReceivedNoteDetails")
            Dim rows As Integer = GoodsReceivedNoteDetails.Rows.Count()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSupplierHistory, GoodsReceivedNoteDetails)
            FormatGridRow(Me.dgvSupplierHistory)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If rows < 1 Then
                DisplayMessage(GetMessage(supplierNo, itemCategoryID, itemCode, startDateTime, endDateTime))

            End If

            fbnExport.Enabled = rows > 0
            btnPrintPreview.Enabled = rows > 0
            btnPrint.Enabled = rows > 0
            lblRecordsNo.Text = "Returned  Record(s): " + rows.ToString


            Me.CalculateTotal()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotal()
        Try
            Cursor = Cursors.WaitCursor
            stbTotalAmount.Clear()
            stbAmountWords.Clear()

            Dim netSupplied As Decimal = CalculateGridAmount(Me.dgvSupplierHistory, Me.colNetAmount)

            stbTotalAmount.Text = FormatNumber(netSupplied, AppData.DecimalPlaces)

            If netSupplied < 1 Then Return
            stbAmountWords.Text = NumberToWords(netSupplied)
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click
        Dim startDate As Date = DateTimeEnteredIn(dtpStartDateTime)
        Dim endDate As Date = DateTimeEnteredIn(dtpEndDateTime)
        LoadGoodsReceivedNoteDetailsSupplierHistory(startDate, endDate)
    End Sub

    Private Sub cboSupplierNo_Leave(sender As Object, e As EventArgs) Handles cboSupplierNo.Leave
        Me.stbSupplierName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboSupplierNo)))
        Me.cboSupplierNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboSupplierNo)))
    End Sub

    Private Sub LoadItemCategories()
        Dim lItemCategory As New List(Of LookupData)
        Dim oConsumable As New LookupData()
        Dim consumableID As String = oItemCategoryID.Consumable()
        oConsumable.DataID = consumableID
        oConsumable.DataDes = GetLookupDataDes(consumableID)

        Dim drugID As String = oItemCategoryID.Drug()
        Dim oDrugID As New LookupData()
        oDrugID.DataID = drugID
        oDrugID.DataDes = GetLookupDataDes(drugID)
        lItemCategory.Add(oConsumable)
        lItemCategory.Add(oDrugID)

        cboItemCategory.DataSource = Nothing
        cboItemCategory.DataSource = lItemCategory
        cboItemCategory.DisplayMember = "DataDes"
        cboItemCategory.ValueMember = "DataID"
        cboItemCategory.SelectedIndex = -1

    End Sub

    Private Sub cboItemCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemCategory.SelectedIndexChanged
        LoadItems()
    End Sub

    Private Sub fbnExport_Click(sender As Object, e As EventArgs) Handles fbnExport.Click
        ExportToExcel(dgvSupplierHistory)
    End Sub

#Region "Print"

    Private Sub docSupplierHistory_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPrintSupplierHistory.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Supplier History "

            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDateTime))
            Dim supplierName As String = StringMayBeEnteredIn(stbSupplierName)
            Dim itemCategory As String = StringMayBeEnteredIn(cboItemCategory)
            Dim itemCode As String = StringMayBeEnteredIn(cboItemCode)
            Dim totalSupplyAmount As String = FormatNumber(DecimalMayBeEnteredIn(stbTotalAmount), AppData.DecimalPlaces)
            Dim totalSuppliedInWords As String = StringMayBeEnteredIn(stbAmountWords)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 20 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If Not String.IsNullOrEmpty(supplierName) Then
                        .DrawString("Supplier: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(supplierName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight


                    End If

                    If Not String.IsNullOrEmpty(itemCategory) Then
                        .DrawString("Item Category: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(itemCategory, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight

                    End If


                    If Not String.IsNullOrEmpty(itemCode) Then

                        .DrawString("Item Code: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(itemCode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight

                    End If
                    title = title.ToUpper()
                    title += (ControlChars.NewLine)


                    .DrawString("Total Banked: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalSupplyAmount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Amount In Words: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalSuppliedInWords, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If supplierHistoryParagraph Is Nothing Then Return

                Do While supplierHistoryParagraph.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(supplierHistoryParagraph(1), PrintParagraps)
                    supplierHistoryParagraph.Remove(1)

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
                        supplierHistoryParagraph.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (supplierHistoryParagraph.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetSupplierHistoryPrintData()

        Dim padItemNo As Integer = 3
        Dim padSupplierName As Integer = 14
        Dim padItemCategory As Integer = 9
        Dim padItemName As Integer = 15
        Dim padQuantity As Integer = 7
        Dim padRate As Integer = 10
        Dim padReceiveAmount As Integer = 14
        Dim padReturnAmount As Integer = 14
        Dim padNetAmount As Integer = 10


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        supplierHistoryParagraph = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Supplier Name".PadRight(padSupplierName))
            'tableHeader.Append("Category".PadRight(padItemCategory))
            tableHeader.Append("Item Name".PadRight(padItemName))
            tableHeader.Append("Qty".PadRight(padQuantity))
            tableHeader.Append("Rate".PadRight(padRate))
            tableHeader.Append("Recv Amt".PadRight(padReceiveAmount))
            tableHeader.Append("Retn Amt".PadRight(padReturnAmount))
            'tableHeader.Append("Net Amt".PadRight(padNetAmount))

            tableHeader.Append(ControlChars.NewLine)
            supplierHistoryParagraph.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvSupplierHistory.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvSupplierHistory.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim supplierName As String = StringMayBeEnteredIn(cells, Me.colSupplierName)
                ' Dim itemCategory As String = StringMayBeEnteredIn(cells, Me.colItemCategory)
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colItemName)
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colTotalReceived)
                Dim rate As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colRate), AppData.DecimalPlaces)
                Dim receiveAmount As String = StringMayBeEnteredIn(cells, Me.colTotalAmount)
                Dim returnAmount As String = StringMayBeEnteredIn(cells, Me.colReturnAmont)
                Dim netAmount As String = StringMayBeEnteredIn(cells, Me.colNetAmount)



                tableData.Append(itemNo.PadRight(padItemNo))

                If supplierName.Length > padSupplierName Then
                    tableData.Append(supplierName.Substring(0, (padSupplierName - 1)).PadRight(padSupplierName))
                Else : tableData.Append(supplierName.PadRight(padSupplierName))
                End If

                'tableData.Append(itemCategory.PadRight(padItemCategory))

                

                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo + padSupplierName))
                        Else
                            tableData.Append(quantity.PadRight(padQuantity))
                            tableData.Append(rate.PadRight(padRate))
                            tableData.Append(receiveAmount.PadRight(padReceiveAmount))
                            tableData.Append(returnAmount.PadRight(padReturnAmount))
                            ' tableData.Append(netAmount.PadRight(padNetAmount))

                        End If
                    Next
                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadRight(padQuantity))
                    tableData.Append(rate.PadRight(padRate))
                    tableData.Append(receiveAmount.PadRight(padReceiveAmount))
                    tableData.Append(returnAmount.PadRight(padReturnAmount))
                    'tableData.Append(netAmount.PadRight(padNetAmount))
                End If
                

                tableData.Append(ControlChars.NewLine)

            Next

            supplierHistoryParagraph.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            supplierHistoryParagraph.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            supplierHistoryParagraph.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            supplierHistoryParagraph.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetSupplierHistoryPrintData()

            With dlgPrintPreview
                .Document = docPrintSupplierHistory
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

            Me.PrintSupplierHistory()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintSupplierHistory()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvSupplierHistory.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry one item!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetSupplierHistoryPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docPrintSupplierHistory
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPrintSupplierHistory.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


#End Region

    Private Sub fbnClose_Click_1(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub
End Class