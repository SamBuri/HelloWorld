
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Drawing.Printing
Imports SyncSoft.Common.Structures

Public Class frmDrugInventorySummaries

#Region " Fields "
    Private Const splitCHAR As Char = ","c
    Private drugs As DataTable

    '--------------------------------------------------------------------------------------------------------------------------
    Private WithEvents docDrugInventory As New PrintDocument()
    Private drugInventoryParagraph As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 6, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 6)

#End Region

    Private Sub frmDrugInventorySummaries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MaxDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataIn(Me.cboLocationID, LookupObjects.Location, False, "DataDes")
            Me.cboLocationID.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadDrugs()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmDrugInventorySummaries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadDrugs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDrugNo.Items.Clear()
            LoadComboData(Me.cboDrugNo, drugs, "DrugFullName")
            Me.cboDrugNo.Items.Insert(0, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboDrugNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDrugNo.Leave

        Try

            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboDrugNo)).ToUpper()
            Me.cboDrugNo.Text = drugNo.ToUpper()
            Me.stbDrugName.Clear()

            For Each row As DataRow In drugs.Select("DrugNo = '" + drugNo + "'")
                Dim drugName As String = StringMayBeEnteredIn(row, "DrugName")
                If Not String.IsNullOrEmpty(drugName) Then Me.cboDrugNo.Text = drugNo.ToUpper()
                Me.stbDrugName.Text = drugName
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboDrugNo_Leave(Me, EventArgs.Empty)

            Dim locationID As String

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Record Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Record Date")
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboDrugNo))

            If Not String.IsNullOrEmpty(location) Then
                locationID = GetLookupDataID(LookupObjects.Location, location)
            Else : locationID = location
            End If

            Me.ShowDrugPeriodicInventory(startDateTime, endDateTime, locationID, drugNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDrugPeriodicInventory(ByVal startDateTime As Date, ByVal endDateTime As Date, ByVal locationID As String, ByVal drugNo As String)

        Dim periodicDrugs As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try
            Dim message As String

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If endDateTime < startDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")
            ' Load from Payments

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(drugNo) OrElse drugNo.Equals("*") Then
                periodicDrugs = oDrugs.GetDrugPeriodicInventory(startDateTime, endDateTime, locationID).Tables("Drugs")
            Else : periodicDrugs = oDrugs.GetDrugPeriodicInventory(startDateTime, endDateTime, locationID, drugNo).Tables("Drugs")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDrugPeriodicInventory, periodicDrugs)
            FormatGridRow(Me.dgvDrugPeriodicInventory)
            calculateTotals()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcPeriodicReport.SelectedTab.Name

                Case Me.tpgDrugPeriodicInventory.Name

                    If Me.dgvDrugPeriodicInventory.RowCount <= 0 Then

                        If String.IsNullOrEmpty(drugNo) OrElse drugNo.Equals("*") Then
                            message = "No " + Me.tpgDrugPeriodicInventory.Text + " record(s) found for period between " +
                                FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + "!"

                        Else : message = "No " + Me.tpgDrugPeriodicInventory.Text + " record(s) found for period between " +
                            FormatDateTime(startDateTime) + " and " + FormatDateTime(endDateTime) + " and Drug No: " + drugNo + "!"
                        End If

                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim rowCount As Integer = Me.dgvDrugPeriodicInventory.RowCount
                    Me.fbnExportTo.Enabled = rowCount > 0
                    btnPrint.Enabled = rowCount > 0
                    btnPrintPreview.Enabled = rowCount > 0
                    Me.lblRecordsNo.Text = Me.tpgDrugPeriodicInventory.Text + " Returned Record(s): " + rowCount.ToString()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim _objectCaption As String = Me.tbcPeriodicReport.SelectedTab.Text
            Dim startDate As Date = DateEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDateTime, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim documentTitle As String = "Inventory summaries for the period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            If Me.tbcPeriodicReport.SelectedTab.Name.Equals(Me.tpgDrugPeriodicInventory.Name) Then
                ExportToExcel(Me.dgvDrugPeriodicInventory, _objectCaption, documentTitle)
            End If

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Drug Periodic Inventory "

    Private Sub cmsDrugInventorySummaries_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDrugInventorySummaries.Opening

        If Me.dgvDrugPeriodicInventory.ColumnCount < 1 OrElse Me.dgvDrugPeriodicInventory.RowCount < 1 Then
            Me.cmsCopy.Enabled = False
            Me.cmsSelectAll.Enabled = False
        Else
            Me.cmsCopy.Enabled = True
            Me.cmsSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvDrugPeriodicInventory.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvDrugPeriodicInventory))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvDrugPeriodicInventory.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
    Private Sub calculateTotals()

        Dim stockCostValue As Decimal = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colStockCostValue)
        Dim stockSellingValue As Decimal = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colStockSellingValue)
        Dim totalVATValue As Decimal = CalculateGridAmount(Me.dgvDrugPeriodicInventory, Me.colVATValue)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.stbTotalStockSellingValue.Text = FormatNumber(stockSellingValue, AppData.DecimalPlaces)
        Me.stbVATValue.Text = FormatNumber(totalVATValue, AppData.DecimalPlaces)
        Me.stbNetSellingValue.Text = FormatNumber((stockSellingValue - totalVATValue), AppData.DecimalPlaces)
        Me.stbTotalStockCostValue.Text = FormatNumber(stockCostValue, AppData.DecimalPlaces)

    End Sub



#End Region

#Region "Print"

    Private Sub PrintDrugsInventory()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugPeriodicInventory.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry one item!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDrugInventoryPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docDrugInventory
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDrugInventory.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docDrugInventory_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDrugInventory.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Drug Inventory Report"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim startDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpStartDateTime))
            Dim endDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpEndDateTime))
            Dim location As String = StringMayBeEnteredIn(cboLocationID)
            Dim drugNo As String = StringMayBeEnteredIn(cboDrugNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalCostValue As String = StringMayBeEnteredIn(stbTotalStockCostValue)
            Dim totalSellingValue As String = FormatNumber(DecimalMayBeEnteredIn(stbTotalStockSellingValue), AppData.DecimalPlaces)
            Dim totalVATValue As String = FormatNumber(DecimalMayBeEnteredIn(stbVATValue))
            Dim netSellingValue As String = FormatNumber(DecimalMayBeEnteredIn(stbNetSellingValue))

            If Not String.IsNullOrEmpty(drugNo) Then
                title += " by Login ID: " + drugNo
            End If


            If Not String.IsNullOrEmpty(location) Then
                title += " at " + location
            End If
            title = title.ToUpper()
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

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Total Cost Value: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalCostValue, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Total Selling Value: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalSellingValue, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Total VAT Value: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(totalVATValue, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Net Selling Value: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(netSellingValue, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If drugInventoryParagraph Is Nothing Then Return

                Do While drugInventoryParagraph.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(drugInventoryParagraph(1), PrintParagraps)
                    drugInventoryParagraph.Remove(1)

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
                        drugInventoryParagraph.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (drugInventoryParagraph.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugInventoryPrintData()

        Dim padItemNo As Integer = 3
        Dim padItemName As Integer = 15
        Dim padUnitCost As Integer = 15
        Dim padUnitPrice As Integer = 13
        Dim padUnitsInStock As Integer = 15
        Dim padUnitsAtHand As Integer = 15
        Dim padCostValue As Integer = 13
        Dim padSellingValue As Integer = 12
        Dim padVATValue As Integer = 12


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        drugInventoryParagraph = New Collection()

        Try


            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("No".PadRight(padItemNo))
            tableHeader.Append("Item Name".PadRight(padItemName))
            tableHeader.Append("Unit Cost".PadRight(padUnitCost))
            tableHeader.Append("Unit Price".PadRight(padUnitPrice))
            tableHeader.Append("Units in Stock".PadRight(padUnitsInStock))
            tableHeader.Append("Units at Hand".PadRight(padUnitsAtHand))
            tableHeader.Append("Cost Value".PadRight(padUnitsAtHand))
            tableHeader.Append("Selling Value".PadRight(padSellingValue))
            tableHeader.Append("VAT Value".PadRight(padVATValue))

            tableHeader.Append(ControlChars.NewLine)
            drugInventoryParagraph.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim itemCount As Integer = 0

            For rowNo As Integer = 0 To Me.dgvDrugPeriodicInventory.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvDrugPeriodicInventory.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrugName)
                Dim unitCost As String = StringMayBeEnteredIn(cells, Me.colUnitCost)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colUnitPrice)
                Dim unitsInStock As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colUnitsInStock), AppData.DecimalPlaces)
                Dim unitsAtHand As String = FormatNumber(DecimalMayBeEnteredIn(cells, Me.colUnitsAtHand), AppData.DecimalPlaces)
                Dim costValue As String = StringMayBeEnteredIn(cells, Me.colStockCostValue)
                Dim sellingValue As String = StringMayBeEnteredIn(cells, Me.colStockSellingValue)
                Dim _VATValue As String = StringMayBeEnteredIn(cells, Me.colVATValue)





                tableData.Append(itemNo.PadRight(padItemNo))

                If itemName.Length > 14 Then
                    tableData.Append(itemName.Substring(0, 14).PadRight(padItemName))
                Else
                    tableData.Append(itemName.PadRight(padItemName))

                End If
                tableData.Append(unitCost.PadRight(padUnitCost))
                tableData.Append(unitPrice.PadRight(padUnitPrice))
                tableData.Append(unitsInStock.PadRight(padUnitsInStock))
                tableData.Append(unitsAtHand.PadRight(padUnitsAtHand))
                tableData.Append(costValue.PadRight(padCostValue))

                tableData.Append(sellingValue.PadRight(padSellingValue))
                tableData.Append(_VATValue.PadRight(padVATValue))


                tableData.Append(ControlChars.NewLine)

            Next

            drugInventoryParagraph.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Received By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            drugInventoryParagraph.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            drugInventoryParagraph.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            drugInventoryParagraph.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintPreview_Click(sender As Object, e As EventArgs) Handles btnPrintPreview.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetDrugInventoryPrintData()

            With dlgPrintPreview
                .Document = docDrugInventory
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

            Me.PrintDrugsInventory()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



#End Region

End Class