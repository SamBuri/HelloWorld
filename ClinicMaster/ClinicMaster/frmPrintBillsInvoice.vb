
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPrintBillsInvoice

#Region " Fields "

    Private _PayTypeID As String
    Private ovariousOptions As New VariousOptions()

    Private WithEvents docInvoices As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region


    Private Sub frmPrintBillsInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub stbInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbInvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub ClearControls()

        Me.stbInvoiceDate.Clear()
        Me.stbStartDate.Clear()
        Me.stbEndDate.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInvoiceAmount.Clear()
        Me.stbAmountWords.Clear()
        Me.stbVisitType.Clear()
        Me.lblRecordsNo.Text = String.Empty
        Me.fbnExportTo.Enabled = False
        Me.dgvInvoiceDetails.Rows.Clear()

    End Sub

    Private Sub stbInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbInvoiceNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbInvoiceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbInvoiceNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim invoiceNo As String = RevertText(StringMayBeEnteredIn(Me.stbInvoiceNo))
            If String.IsNullOrEmpty(invoiceNo) Then Return
            Me.LoadInvoicesData(invoiceNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInvoicesData(ByVal invoiceNo As String)

        Try

            Me.ClearControls()
            Me.LoadInvoices(invoiceNo)
            Me.LoadInvoiceBillDetails(invoiceNo)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub btnLoadInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInvoices.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInvoices As New frmPeriodicInvoices(Me.stbInvoiceNo, Me._PayTypeID)
            fPeriodicInvoices.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoiceNo As String = RevertText(StringMayBeEnteredIn(Me.stbInvoiceNo))
            If String.IsNullOrEmpty(invoiceNo) Then Return
            Me.LoadInvoicesData(invoiceNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInvoices(ByVal invoiceNo As String)

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()

        Try

            Dim row As DataRow = oInvoices.GetInvoices(invoiceNo).Tables("Invoices").Rows(0)
            Dim payTypeID As String = StringMayBeEnteredIn(row, "PayTypeID")
            Dim billNo As String = RevertText(StringEnteredIn(row, "PayNo"))

            Me.stbInvoiceNo.Text = FormatText(invoiceNo, "Invoices", "InvoiceNo")

            Me.stbInvoiceDate.Text = FormatDate(DateEnteredIn(row, "InvoiceDate"))
            Me.stbStartDate.Text = FormatDate(DateEnteredIn(row, "StartDate"))
            Me.stbEndDate.Text = FormatDate(DateEnteredIn(row, "EndDate"))
            'Me.stbInvoiceAmount.Text = FormatNumber(DecimalMayBeEnteredIn(row, "InvoiceAmount"), AppData.DecimalPlaces)
            Me.stbAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbVisitType.Text = StringEnteredIn(row, "VisitType")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillDetails(payTypeID, billNo)

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadInvoiceBillDetails(ByVal invoiceNo As String)

        Dim invoiceBillDetails As New DataTable
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()
        Dim oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitType As String = StringEnteredIn(Me.stbVisitType, "Visit Type!")

            Me.dgvInvoiceDetails.Rows.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.InPatient).ToUpper()) Then
                invoiceBillDetails = oInvoiceExtraBillItems.GetInvoiceExtraBillDetails(invoiceNo).Tables("InvoiceExtraBillItems")
            ElseIf visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.OutPatient).ToUpper()) Then
                invoiceBillDetails = oInvoiceDetails.GetInvoiceBillDetails(invoiceNo).Tables("InvoiceDetails")
            ElseIf visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.Combined).ToUpper()) Then
                invoiceBillDetails = oInvoiceExtraBillItems.GetInvoiceExtraBillDetails(invoiceNo).Tables("InvoiceExtraBillItems")
                invoiceBillDetails.Merge(oInvoiceDetails.GetInvoiceBillDetails(invoiceNo).Tables("InvoiceDetails"))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInvoiceDetails, invoiceBillDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = " Returned Record(s): " + invoiceBillDetails.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateInvoiceAmount()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnExportTo.Enabled = Me.dgvInvoiceDetails.RowCount > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateInvoiceAmount()

        Dim InvoiceAmount As Decimal

        Me.stbInvoiceAmount.Clear()

        For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmountBalance)
            InvoiceAmount += amount
        Next

        Me.stbInvoiceAmount.Text = FormatNumber(InvoiceAmount, AppData.DecimalPlaces)


    End Sub

    Private Sub ShowBillDetails(ByVal payTypeID As String, ByVal billNo As String)

        Dim billCustomerName As String = String.Empty

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Dim oPayTypeID As New LookupDataID.PayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Clear()
            If String.IsNullOrEmpty(billNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case payTypeID.ToUpper()

                Case oPayTypeID.VisitBill.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oVisits.GetVisits(billNo).Tables("Visits").Rows(0)

                    Me.stbBillNo.Text = FormatText(billNo, "Visits", "VisitNo")
                    billCustomerName = StringMayBeEnteredIn(row, "FullName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oPayTypeID.AccountBill.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oBillCustomers.GetBillCustomers(billNo).Tables("BillCustomers").Rows(0)

                    Me.stbBillNo.Text = FormatText(billNo, "BillCustomers", "AccountNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oPayTypeID.InsuranceBill.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oInsurances.GetInsurances(billNo).Tables("Insurances").Rows(0)

                    Me.stbBillNo.Text = FormatText(billNo, "Insurances", "InsuranceNo").ToUpper()
                    billCustomerName = StringMayBeEnteredIn(row, "InsuranceName")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbBillCustomerName.Text = billCustomerName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)

            If String.IsNullOrEmpty(billNo) Then Return
            Dim startDate As Date = DateEnteredIn(Me.stbStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.stbEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim documentTitle As String = "Bill(s) for " + billCustomerName + " for the period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            fStatus.Show("Exporting Bill(s) Invoice for " + billCustomerName + " to Excel...", FormStartPosition.CenterScreen)
            ExportToExcel(Me.dgvInvoiceDetails, "Invoice for " + billCustomerName, documentTitle)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintInvoice()

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInvoiceDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on payment details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ovariousOptions.EnablePrintingInvoicesWithCompanyName Then
                Me.SetBillInvoicePrintDataWithOutVisitDate()
            Else
                Me.SetBillInvoicePrintData()
            End If



            With dlgPrintPreview
                .Document = docInvoices
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

#Region " Invoice Printing "

    Private Sub PrintInvoice()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInvoiceDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on invoice details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ovariousOptions.EnablePrintingInvoicesWithCompanyName Then
                Me.SetBillInvoicePrintDataWithOutVisitDate()
            Else
                Me.SetBillInvoicePrintData()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docInvoices
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInvoices.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInvoices_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInvoices.PrintPage

        Try

            Dim oVisitTypeID As New LookupDataID.VisitTypeID()

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Invoice".ToUpper()

            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbInvoiceNo)
            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim startDate As String = StringMayBeEnteredIn(Me.stbStartDate)
            Dim endDate As String = StringMayBeEnteredIn(Me.stbEndDate)
            Dim invoiceDate As String = FormatDate(DateMayBeEnteredIn(Me.stbInvoiceDate))
            Dim visitType As String = StringMayBeEnteredIn(Me.stbVisitType)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not ovariousOptions.HideInvoiceHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("To-Bill No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(billNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Start Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(startDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("End Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(endDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.InPatient).ToUpper()) Then
                        .DrawString("Invoive Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        .DrawString("Visit Type: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(visitType, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    Else
                        .DrawString("Invoive Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    End If

                    If Not String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso Not String.IsNullOrEmpty(oProductOwner.VATNo) Then

                        yPos += lineHeight

                        .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        .DrawString("VAT No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(oProductOwner.VATNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    ElseIf Not String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso String.IsNullOrEmpty(oProductOwner.VATNo) Then

                        .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    ElseIf String.IsNullOrEmpty(oProductOwner.TINNo) AndAlso Not String.IsNullOrEmpty(oProductOwner.VATNo) Then

                        .DrawString("VAT No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(oProductOwner.VATNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    End If

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

                If invoiceParagraphs Is Nothing Then Return

                Do While invoiceParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(invoiceParagraphs(1), PrintParagraps)
                    invoiceParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
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
                        invoiceParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (invoiceParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetBillInvoicePrintData()

        Dim padVisitNo As Integer = 15
        Dim padVisitDate As Integer = 12
        Dim padFullName As Integer = 21
        Dim padMemberCardNo As Integer = 15
        Dim padAmount As Integer = 12
        Dim padTotalAmount As Integer = 57

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Visit No: ".PadRight(padVisitNo))
            tableHeader.Append("Visit Date: ".PadRight(padVisitDate))
            tableHeader.Append("Patient's Name: ".PadRight(padFullName))
            tableHeader.Append("Member No: ".PadRight(padMemberCardNo))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells

                Dim visitNo As String = RevertText(cells.Item(Me.colVisitNo.Name).Value.ToString())
                Dim visitDate As String = cells.Item(Me.colVisitDate.Name).Value.ToString()
                Dim fullName As String = cells.Item(Me.colFullName.Name).Value.ToString()
                Dim memberCardNo As String = cells.Item(Me.colMemberCardNo.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()

                tableData.Append(visitNo.PadRight(padVisitNo))
                tableData.Append(visitDate.PadRight(padVisitDate))
                If fullName.Length >= padFullName Then
                    tableData.Append(fullName.Substring(0, padFullName - 1).PadRight(padFullName))
                Else : tableData.Append(fullName.PadRight(padFullName))
                End If

                Dim wrappedMemberCardNo As List(Of String) = WrapText(memberCardNo, padMemberCardNo)
                If wrappedMemberCardNo.Count > 1 Then
                    For pos As Integer = 0 To wrappedMemberCardNo.Count - 1
                        tableData.Append(FixDataLength(wrappedMemberCardNo(pos).Trim(), padMemberCardNo))
                        If Not pos = wrappedMemberCardNo.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(2 + padVisitNo + padVisitDate + padFullName))
                        Else : tableData.Append(amount.PadRight(padAmount))
                        End If
                    Next
                Else
                    tableData.Append(FixDataLength(memberCardNo, padMemberCardNo))
                    tableData.Append(amount.PadRight(padAmount))
                End If
                tableData.Append(ControlChars.NewLine)
            Next

            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Amount: ")
            totalAmount.Append(Me.stbInvoiceAmount.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetBillInvoicePrintDataWithOutVisitDate()

        Dim padVisitNo As Integer = 12
        Dim padVisitDate As Integer = 11
        Dim padFullName As Integer = 16
        Dim padMemberCardNo As Integer = 15
        Dim padAmount As Integer = 10
        Dim padTotalAmount As Integer = 57

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Patient No: ".PadRight(padVisitNo))
            tableHeader.Append("Patient's Name: ".PadRight(padFullName))
            tableHeader.Append("Company: ".PadRight(padFullName))
            tableHeader.Append("Member No: ".PadRight(padMemberCardNo))
            tableHeader.Append("Amount: ".PadRight(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells

                Dim patientNo As String = RevertText(cells.Item(Me.colPatientNo.Name).Value.ToString())
                Dim fullName As String = cells.Item(Me.colFullName.Name).Value.ToString()
                Dim company As String = cells.Item(Me.ColCompany.Name).Value.ToString()
                Dim memberCardNo As String = cells.Item(Me.colMemberCardNo.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()


                tableData.Append(patientNo.PadRight(padVisitNo))

                If fullName.Length > padFullName Then
                    tableData.Append(fullName.Substring(0, padFullName - 1).PadRight(padFullName))
                Else : tableData.Append(fullName.PadRight(padFullName))
                End If
                If company.Length > padFullName Then
                    tableData.Append(company.Substring(0, padFullName - 1).PadRight(padFullName))
                Else : tableData.Append(company.PadRight(padFullName))
                End If

                Dim wrappedMemberCardNo As List(Of String) = WrapText(memberCardNo, padMemberCardNo - 1)
                If wrappedMemberCardNo.Count > 1 Then
                    For pos As Integer = 0 To wrappedMemberCardNo.Count - 1
                        tableData.Append(FixDataLength(wrappedMemberCardNo(pos).Trim(), padMemberCardNo - 1))
                        If Not pos = wrappedMemberCardNo.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padVisitNo + padFullName + padFullName))
                        Else : tableData.Append(amount.PadRight(padAmount))
                        End If
                    Next
                Else
                    tableData.Append(memberCardNo.Trim().PadRight(padMemberCardNo))
                    tableData.Append(amount.PadRight(padAmount))
                End If
                tableData.Append(ControlChars.NewLine)
            Next

            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Amount: ")
            totalAmount.Append(Me.stbInvoiceAmount.Text.ToString().PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " State Methods "

    Public Sub BillState(ByVal state As String)
        Me._PayTypeID = state
        Me.ClearControls()
        Me.stbInvoiceNo.Clear()
    End Sub

#End Region

#Region " Invoice Details Extras "

    Private Sub cmsInvoiceDetails_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInvoiceDetails.Opening

        If Me.dgvInvoiceDetails.ColumnCount < 1 OrElse Me.dgvInvoiceDetails.RowCount < 1 Then
            Me.cmsInvoiceDetailsCopy.Enabled = False
            Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Else
            Me.cmsInvoiceDetailsCopy.Enabled = True
            Me.cmsInvoiceDetailsSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsInvoiceDetailsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvInvoiceDetails.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvInvoiceDetails))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvInvoiceDetails.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region


End Class