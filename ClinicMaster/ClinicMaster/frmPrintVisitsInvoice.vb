
Option Strict On
Option Infer On
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Text

Public Class frmPrintVisitsInvoice

#Region " Fields "

    Private tipCoPayValueWords As New ToolTip()
    Private WithEvents docInvoices As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private oVariousOptions As New VariousOptions()
    Dim defaultInvoiceNo As String
    Private payTypeID As String
    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

#End Region


    Private Sub frmPrintVisitsInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tbcAccountStatement.TabPages.Remove(tpgAdjustments)
        If Not oVariousOptions.EnablePrintInvoiceDetailesCheck Then
            Me.chkPrintInvoiceDetailedOnSaving.Visible = False
        Else
            Me.chkPrintInvoiceDetailedOnSaving.Visible = True
        End If

        If Not String.IsNullOrEmpty(Me.defaultInvoiceNo) Then
            Me.stbInvoiceNo.Text = Me.defaultInvoiceNo
            Me.LoadInvoicesData(RevertText(defaultInvoiceNo))
        End If

    End Sub

    Private Sub frmPrintVisitsInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub stbInvoiceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbInvoiceNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitDate.Clear()
        Me.stbVisitNo.Clear()
        Me.stbInvoiceDate.Clear()
        Me.stbStartDate.Clear()
        Me.stbEndDate.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbMemberCardNo.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbClaimReferenceNo.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceNo.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbInvoiceAmount.Clear()
        Me.stbAmountWords.Clear()
        Me.stbVisitType.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.dgvInvoiceDetails.Rows.Clear()
        Me.dgvAdjustments.Rows.Clear()

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

    Private Sub btnLoadInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInvoices.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oPayTypeID As New LookupDataID.PayTypeID()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInvoices As New frmPeriodicInvoices(Me.stbInvoiceNo, oPayTypeID.VisitBill)
            fPeriodicInvoices.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim invoiceNo As String = RevertText(StringMayBeEnteredIn(Me.stbInvoiceNo))
            If String.IsNullOrEmpty(invoiceNo) Then Return
            Me.LoadInvoicesData(invoiceNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInvoicesData(ByVal invoiceNo As String)

        Try

            '''''''''''''''''''''''''''''''''
            Me.ClearControls()

            '''''''''''''''''''''''''''''''''
            Me.LoadInvoices(invoiceNo)
            Me.LoadInvoiceDetails(invoiceNo)
            '''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadInvoices(ByVal invoiceNo As String)

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Dim invoicesRow As DataRow = oInvoices.GetInvoices(invoiceNo).Tables("Invoices").Rows(0)
            Dim visitsRow As DataRow
            Dim visitNo As String = RevertText(StringEnteredIn(invoicesRow, "PayNo"))
            Dim visitTypeID As String = RevertText(StringEnteredIn(invoicesRow, "VisitTypeID"))
            If visitTypeID.ToUpper().Equals(oVisitTypeID.InPatient().ToUpper()) Then
                visitsRow = oVisits.GetAdmissionsDetails(visitNo).Tables("Visits").Rows(0)
            Else
                visitsRow = oVisits.GetVisits(visitNo).Tables("Visits").Rows(0)
            End If


            Dim patientNo As String = RevertText(StringEnteredIn(visitsRow, "PatientNo"))

            'Me.stbInvoiceNo.Text = FormatText(invoiceNo, "Invoices", "InvoiceNo")
            Me.stbFullName.Text = StringEnteredIn(visitsRow, "FullName")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(visitsRow, "VisitDate"))
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(visitsRow, "PrimaryDoctor")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(visitsRow, "MemberCardNo")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(visitsRow, "MainMemberName")
            Me.stbClaimReferenceNo.Text = StringMayBeEnteredIn(visitsRow, "ClaimReferenceNo")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(visitsRow, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(visitsRow, "BillCustomerName")
            Me.stbInsuranceNo.Text = FormatText(StringMayBeEnteredIn(visitsRow, "InsuranceNo"), "Insurances", "InsuranceNo")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(visitsRow, "InsuranceName")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(visitsRow, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(visitsRow, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(visitsRow, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(visitsRow, "CoPayValue")))

            Me.stbInvoiceDate.Text = FormatDate(DateEnteredIn(invoicesRow, "InvoiceDate"))
            Me.stbStartDate.Text = FormatDate(DateEnteredIn(invoicesRow, "StartDate"))
            Me.stbEndDate.Text = FormatDate(DateEnteredIn(invoicesRow, "EndDate"))
            'Me.stbInvoiceAmount.Text = FormatNumber(DecimalMayBeEnteredIn(invoicesRow, "NetAmount"), AppData.DecimalPlaces)
            ' Me.stbAmountWords.Text = StringMayBeEnteredIn(invoicesRow, "AmountWords")
            Me.stbVisitType.Text = StringEnteredIn(invoicesRow, "VisitType")
            Me.payTypeID = StringEnteredIn(invoicesRow, "PayTypeID")
            

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadInvoiceDetails(ByVal invoiceNo As String)

        Dim invoiceDetails As New DataTable
        Dim adjustments As New DataTable
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()
        Dim oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems()
        Dim oInvoiceDetailAdjustments As New SyncSoft.SQLDb.InvoiceDetailAdjustments()
        Dim onvoiceExtraBillItemAdjustments As New SyncSoft.SQLDb.InvoiceExtraBillItemAdjustments()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitType As String = StringEnteredIn(Me.stbVisitType, "Visit Type!")

            Me.dgvInvoiceDetails.Rows.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.InPatient).ToUpper()) Then
                invoiceDetails = oInvoiceExtraBillItems.GetInvoiceExtraBillItems(invoiceNo).Tables("InvoiceExtraBillItems")
                adjustments = onvoiceExtraBillItemAdjustments.GetInvoiceExtraBillItemAdjustmentsByInvoiceNo(invoiceNo).Tables("InvoiceExtraBillItemAdjustments")
            ElseIf visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.OutPatient).ToUpper()) Then
                invoiceDetails = oInvoiceDetails.GetInvoiceDetails(invoiceNo).Tables("InvoiceDetails")
                adjustments = oInvoiceDetailAdjustments.GetInvoiceDetailAdjustmentsByInvoiceNo(invoiceNo).Tables("InvoiceDetailAdjustments")
            ElseIf visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.Combined).ToUpper()) Then
                invoiceDetails = oInvoiceDetails.GetInvoiceDetails(invoiceNo).Tables("InvoiceDetails")
                invoiceDetails.Merge(oInvoiceExtraBillItems.GetInvoiceExtraBillItems(invoiceNo).Tables("InvoiceExtraBillItems"))

                adjustments = onvoiceExtraBillItemAdjustments.GetInvoiceExtraBillItemAdjustmentsByInvoiceNo(invoiceNo).Tables("InvoiceExtraBillItemAdjustments")
                adjustments.Merge(oInvoiceDetailAdjustments.GetInvoiceDetailAdjustmentsByInvoiceNo(invoiceNo).Tables("InvoiceDetailAdjustments"))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInvoiceDetails, invoiceDetails)
            LoadGridData(Me.dgvAdjustments, adjustments)

            If Not Me.payTypeID.ToUpper().Equals(oPayTypeID.VisitBillCASH.ToUpper()) Then
                calculculateDisplayAmount()

            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If adjustments.Rows.Count > 0 Then
                If Not tbcAccountStatement.Contains(tpgAdjustments) Then Me.tbcAccountStatement.TabPages.Add(tpgAdjustments)
                Me.chkPrintNetFiguresOnly.Visible = True
            Else
                If tbcAccountStatement.Contains(tpgAdjustments) Then Me.tbcAccountStatement.TabPages.Remove(tpgAdjustments)
                Me.chkPrintNetFiguresOnly.Visible = False
            End If

            Dim originalInvoicedAmount As Decimal = CalculateGridAmount(dgvInvoiceDetails, colOriginalAmount)
            Dim adjustedAmount As Decimal = CalculateGridAmount(dgvAdjustments, colAdjAMount)
            Dim netInvoicedAmount As Decimal = originalInvoicedAmount - adjustedAmount
            Me.stbInvoiceAmount.Text = FormatNumber(netInvoicedAmount, AppData.DecimalPlaces)
            Me.stbAmountWords.Text = NumberToWords(netInvoicedAmount)



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub calculculateDisplayAmount()
        Try
            Dim totalAmount As Decimal = 0
            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "item!")
                Dim discount = DecimalEnteredIn(cells, Me.colDiscount, False, "Discount!")
                Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                Dim unitPrice As Decimal = 0
                Dim amount As Decimal = 0



                If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                              (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                    unitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!")
                Else
                    unitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                End If

                amount = (DecimalEnteredIn(cells, Me.colOriginalQuantity, False, "Quantity!") * unitPrice) - discount


                dgvInvoiceDetails.Item(Me.colOriginalAmount.Name, rowNo).Value = FormatNumber(amount, AppData.DecimalPlaces)
            Next

        Catch ex As Exception
            Throw ex
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



#Region " Invoice Printing "

    Private Sub PrintInvoice()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInvoiceDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on invoice details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetVisitInvoicePrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
            Dim title As String = AppData.ProductOwner.ToUpper() + " Invoice".ToUpper()
            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbInvoiceNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim invoiceDate As String = FormatDate(DateMayBeEnteredIn(Me.stbInvoiceDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim startDate As String = StringMayBeEnteredIn(Me.stbStartDate)
            Dim endDate As String = StringMayBeEnteredIn(Me.stbEndDate)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim memberCardNo As String = StringMayBeEnteredIn(Me.stbMemberCardNo)
            Dim mainMemberName As String = StringMayBeEnteredIn(Me.stbMainMemberName)
            Dim claimReferenceNo As String = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)
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
                    If Not oVariousOptions.HideInvoiceHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Invoive Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("To-Bill No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(billNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.InPatient).ToUpper()) Then
                        .DrawString("Visit Type: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(visitType, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        .DrawString("Ref. Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                        yPos += lineHeight
                    Else
                        .DrawString("Ref. Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(memberCardNo) Then
                        .DrawString("Member Card No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(memberCardNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(mainMemberName) Then
                        .DrawString("Main Member Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(mainMemberName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(claimReferenceNo) Then
                        .DrawString("Claim Reference No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(claimReferenceNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    If Not String.IsNullOrEmpty(insuranceName) Then
                        yPos += lineHeight

                        .DrawString("Bill Insurance Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(insuranceName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    End If

                    If Not String.IsNullOrEmpty(oProductOwner.TINNo) Then

                        yPos += lineHeight
                        .DrawString("TIN No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(oProductOwner.TINNo, bodyBoldFont, Brushes.Black, 35 + widthTopFourth, yPos)


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

    
    Private Sub SetVisitInvoicePrintDataBackup()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkPrintInvoiceDetailedOnSaving.Checked = True Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Disc: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))

                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()


                    tableData.Append(itemNo.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(discount.PadLeft(padDiscount))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(discount.PadLeft(padDiscount))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If

                    tableData.Append(ControlChars.NewLine)
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount



                    For Each item In invoiceDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                        tableData.Append(itemNo.PadRight(padItemNo))

                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                        Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                        End If
                        tableData.Append(categoryAmount.PadLeft(padAmount))
                        tableData.Append(ControlChars.NewLine)

                    Next
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim invoiceDetailQuantities = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    For Each item In invoiceDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        tableData.Append(GetSpaces(padItemNo))
                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                        Else : tableData.Append(categoryName.PadRight(padItemName))
                        End If
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)

                        Dim categorizedInvoiceDetails = (From data In Me.GetCategorizedInvoiceDetails Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                        itemDiscount = data.Item5, itemAmount = data.Item6 Into CategoryAmount2 = Sum(data.Item6) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemDiscount, itemAmount Where
                                        CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                        CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                        For Each categorizedItem In categorizedInvoiceDetails
                            countExtra += 1
                            Dim categorizedItemNo As String = (countExtra).ToString()
                            Dim itemName As String = categorizedItem.itemName
                            Dim categorizedInvoiceDetailQuantity = From data In Me.GetCategorizedInvoiceDetails Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                   Select totalQuantity, Item2
                                                                   Where Item2 = itemName

                            Dim itemQuantity As String = categorizedInvoiceDetailQuantity.ElementAt(0).totalQuantity.ToString
                            Dim ItemUnitPrice As String = FormatNumber(categorizedItem.itemUnitPrice, AppData.DecimalPlaces)
                            Dim itemDiscount As String = FormatNumber(categorizedItem.itemDiscount, AppData.DecimalPlaces)
                            Dim itemAmount As String = FormatNumber(categorizedItem.itemAmount, AppData.DecimalPlaces)

                            tableData.Append(categorizedItemNo.PadRight(padItemNo))

                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padItemNo))
                                    Else
                                        tableData.Append(itemQuantity.PadLeft(padQuantity))
                                        tableData.Append(itemAmount.PadLeft(padAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padItemName))
                                tableData.Append(itemQuantity.PadLeft(padQuantity))
                                tableData.Append(itemAmount.PadLeft(padAmount))
                            End If
                            tableData.Append(ControlChars.NewLine)
                        Next
                        tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                        tableData.Append(categoryAmount.PadLeft(padAmount + 41))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)
                        countExtra = 0
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then

                    tableHeader.Append("Code: ".PadRight(padICItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padICItemName))
                    tableHeader.Append("Qty: ".PadRight(padICQuantity))
                    tableHeader.Append("Unit Price: ".PadRight(padICUnitPrice))
                    'tableHeader.Append("Discount: ".PadRight(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padICAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        'im itemNo As String = (count).ToString()
                        Dim itemNo As String = cells.Item(Me.colItemCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        'im discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()



                        tableData.Append(itemNo.PadRight(padICItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padICItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padICItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padICItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padICQuantity))
                                    tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                                    'tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padICAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padICItemName))
                            tableData.Append(quantity.PadLeft(padICQuantity))
                            tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                            'tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padICAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                    tableHeader.Append("Disc: ".PadLeft(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()


                        tableData.Append(itemNo.PadRight(padItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padQuantity))
                                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                    tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(quantity.PadLeft(padQuantity))
                            tableData.Append(unitPrice.PadLeft(padUnitPrice))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If


            Dim adjustmentHeader As StringBuilder = Me.GetVisitInvoiceAdjustmentHeaderPrintData()
            Dim adjustmentBody As StringBuilder = Me.GetVisitInvoiceAdjustmentPrintData()
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, "Adjustments"))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, "Adjustments2"))
            MsgBox(adjustmentHeader.ToString())
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, adjustmentHeader.ToString()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, adjustmentBody.ToString()))

            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)

            Dim totalAmount As Decimal = GetInvoiceTotalAmount()
            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)

            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                Dim coPayAmount As Decimal = CDec(totalAmount * coPayPercent) / 100
                Dim balanceDue As Decimal = totalAmount - coPayAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim coPayAmountData As New System.Text.StringBuilder(String.Empty)
                coPayAmountData.Append("Co-Pay Amount: ")
                coPayAmountData.Append(FormatNumber(coPayAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 1))
                coPayAmountData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, coPayAmountData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueData As New System.Text.StringBuilder(String.Empty)
                balanceDueData.Append("Balance Due: ")
                balanceDueData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount + 1))
                balanceDueData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceDueData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueWordsData As New System.Text.StringBuilder(String.Empty)
                balanceDueWordsData.Append("(" + NumberToWords(balanceDue).Trim() + " ONLY)")
                balanceDueWordsData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, balanceDueWordsData.ToString()))

            Else
                Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
                Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
                totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
                totalAmountWords.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.DisablePatientSignOnInvoices Then

                Dim patientSignData As New System.Text.StringBuilder(String.Empty)
                patientSignData.Append(ControlChars.NewLine)
                patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
                patientSignData.Append(GetSpaces(4))
                patientSignData.Append("Date:  " + GetCharacters("."c, 20))
                patientSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
                checkedSignData.Append(ControlChars.NewLine)

                checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                checkedSignData.Append(GetSpaces(4))
                checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                checkedSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


   
    Private Function GetInvoiceTotalAmount() As Decimal
        Try
            Return CalculateGridAmount(dgvInvoiceDetails, Me.colOriginalAmount)
        Catch ex As Exception
            Throw ex
        End Try

    End Function



    Private Function GetCategorizedInvoiceDetails() As List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetailsExtra2 As New List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colOriginalQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unitPrice!")
                Dim discount As Decimal = DecimalEnteredIn(cells, Me.colDiscount, False, "discount!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOriginalAmount, False, "amount!")

                invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal, Decimal)(category, itemName, quantity, unitPrice, discount, amount))

            Next

            Return invoiceDetailsExtra2

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetInvoiceDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOriginalAmount, False, "amount!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub SetVisitInvoicePrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

           

            Dim OriginalHeader As StringBuilder = Me.GetOriginalVisitInvoiceHeaderPrintData()
            Dim originalBody As StringBuilder = Me.GetOriginalVisitInvoicePrintData
            Dim adjustmentHeader As StringBuilder = Me.GetVisitInvoiceAdjustmentHeaderPrintData()
            Dim adjustmentBody As StringBuilder = Me.GetVisitInvoiceAdjustmentPrintData()
            Dim netInvoiceData As StringBuilder = GetNetVisitInvoicePrintData()
            Dim totalLebel As String = "Total Amount: "
            Dim seperator As New System.Text.StringBuilder(String.Empty)
            Dim totalAmount As Decimal = GetInvoiceTotalAmount()
            Dim adjustedAmount As Decimal = CalculateGridAmount(dgvAdjustments, colAdjAMount)
            Dim netAmount As Decimal = totalAmount - adjustedAmount

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, OriginalHeader.ToString()))
            If chkPrintNetFiguresOnly.Checked Then
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, netInvoiceData.ToString()))
                netAmount = CalculateGridAmount(dgvInvoiceDetails, colAmountBalance)
            Else
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, originalBody.ToString()))


                If adjustmentBody.Length > 0 Then
                    seperator.Append(ControlChars.NewLine)
                    seperator.Append("Adjustments")
                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, seperator.ToString()))

                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, adjustmentHeader.ToString()))

                    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, adjustmentBody.ToString()))
                    totalLebel = "Net Amount: "
                End If
            End If


            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)

            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append(totalLebel)
            totalAmountData.Append(FormatNumber(netAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)

            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) AndAlso Me.payTypeID.Equals(oPayTypeID.VisitBill()) Then

                Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                Dim coPayAmount As Decimal = CDec(totalAmount * coPayPercent) / 100
                Dim balanceDue As Decimal = totalAmount - coPayAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim coPayAmountData As New System.Text.StringBuilder(String.Empty)
                coPayAmountData.Append("Co-Pay Amount: ")
                coPayAmountData.Append(FormatNumber(coPayAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 1))
                coPayAmountData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, coPayAmountData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueData As New System.Text.StringBuilder(String.Empty)
                balanceDueData.Append("Balance Due: ")
                balanceDueData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount + 1))
                balanceDueData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceDueData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueWordsData As New System.Text.StringBuilder(String.Empty)
                balanceDueWordsData.Append("(" + NumberToWords(balanceDue).Trim() + " ONLY)")
                balanceDueWordsData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, balanceDueWordsData.ToString()))

            Else
                Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
                Dim amountWords As String = NumberToWords(netAmount)
                If netAmount > 0 Then totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
                totalAmountWords.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.DisablePatientSignOnInvoices Then

                Dim patientSignData As New System.Text.StringBuilder(String.Empty)
                patientSignData.Append(ControlChars.NewLine)
                patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
                patientSignData.Append(GetSpaces(4))
                patientSignData.Append("Date:  " + GetCharacters("."c, 20))
                patientSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
                checkedSignData.Append(ControlChars.NewLine)

                checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                checkedSignData.Append(GetSpaces(4))
                checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                checkedSignData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Function GetOriginalVisitInvoiceHeaderPrintData() As StringBuilder

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkPrintInvoiceDetailedOnSaving.Checked = True Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Disc: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))

                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                Return tableHeader
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    Return tableHeader
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    Return tableHeader
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then

                    tableHeader.Append("Code: ".PadRight(padICItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padICItemName))
                    tableHeader.Append("Qty: ".PadRight(padICQuantity))
                    tableHeader.Append("Unit Price: ".PadRight(padICUnitPrice))
                    'tableHeader.Append("Discount: ".PadRight(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padICAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    Return tableHeader
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                    tableHeader.Append("Disc: ".PadLeft(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    Return tableHeader
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetOriginalVisitInvoicePrintData() As StringBuilder

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkPrintInvoiceDetailedOnSaving.Checked = True Then



                For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colOriginalQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colOriginalAmount.Name).Value.ToString()


                    tableData.Append(itemNo.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(discount.PadLeft(padDiscount))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(discount.PadLeft(padDiscount))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If

                    tableData.Append(ControlChars.NewLine)
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Return tableData
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then


                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount



                    For Each item In invoiceDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                        tableData.Append(itemNo.PadRight(padItemNo))

                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                        Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                        End If
                        tableData.Append(categoryAmount.PadLeft(padAmount))
                        tableData.Append(ControlChars.NewLine)

                    Next
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim invoiceDetailQuantities = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    For Each item In invoiceDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        tableData.Append(GetSpaces(padItemNo))
                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                        Else : tableData.Append(categoryName.PadRight(padItemName))
                        End If
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)

                        Dim categorizedInvoiceDetails = (From data In Me.GetCategorizedInvoiceDetails Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                        itemDiscount = data.Item5, itemAmount = data.Item6 Into CategoryAmount2 = Sum(data.Item6) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemDiscount, itemAmount Where
                                        CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                        CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                        For Each categorizedItem In categorizedInvoiceDetails
                            countExtra += 1
                            Dim categorizedItemNo As String = (countExtra).ToString()
                            Dim itemName As String = categorizedItem.itemName
                            Dim categorizedInvoiceDetailQuantity = From data In Me.GetCategorizedInvoiceDetails Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                   Select totalQuantity, Item2
                                                                   Where Item2 = itemName

                            Dim itemQuantity As String = categorizedInvoiceDetailQuantity.ElementAt(0).totalQuantity.ToString
                            Dim ItemUnitPrice As String = FormatNumber(categorizedItem.itemUnitPrice, AppData.DecimalPlaces)
                            Dim itemDiscount As String = FormatNumber(categorizedItem.itemDiscount, AppData.DecimalPlaces)
                            Dim itemAmount As String = FormatNumber(categorizedItem.itemAmount, AppData.DecimalPlaces)

                            tableData.Append(categorizedItemNo.PadRight(padItemNo))

                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padItemNo))
                                    Else
                                        tableData.Append(itemQuantity.PadLeft(padQuantity))
                                        tableData.Append(itemAmount.PadLeft(padAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padItemName))
                                tableData.Append(itemQuantity.PadLeft(padQuantity))
                                tableData.Append(itemAmount.PadLeft(padAmount))
                            End If
                            tableData.Append(ControlChars.NewLine)
                        Next
                        tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                        tableData.Append(categoryAmount.PadLeft(padAmount + 41))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)
                        countExtra = 0
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then


                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        'im itemNo As String = (count).ToString()
                        Dim itemNo As String = cells.Item(Me.colItemCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colOriginalQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        'im discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colOriginalAmount.Name).Value.ToString()



                        tableData.Append(itemNo.PadRight(padICItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padICItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padICItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padICItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padICQuantity))
                                    tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                                    'tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padICAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padICItemName))
                            tableData.Append(quantity.PadLeft(padICQuantity))
                            tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                            'tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padICAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else


                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colOriginalQuantity.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colOriginalAmount.Name).Value.ToString()


                        tableData.Append(itemNo.PadRight(padItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padQuantity))
                                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                    tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(quantity.PadLeft(padQuantity))
                            tableData.Append(unitPrice.PadLeft(padUnitPrice))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If



        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "Net Invoice"

    Private Function GetNetVisitInvoicePrintData() As StringBuilder

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkPrintInvoiceDetailedOnSaving.Checked = True Then



                For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells


                   
                    Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()

                    If CDec(amount) > 0 Then
                        count += 1
                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()

                        tableData.Append(itemNo.PadRight(padItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padQuantity))
                                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                    tableData.Append(discount.PadLeft(padDiscount))
                                    tableData.Append(amount.PadLeft(padAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(quantity.PadLeft(padQuantity))
                            tableData.Append(unitPrice.PadLeft(padUnitPrice))
                            tableData.Append(discount.PadLeft(padDiscount))
                            tableData.Append(amount.PadLeft(padAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    End If
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Return tableData
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then


                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetNetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount



                    For Each item In invoiceDetails




                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        If CDec(categoryAmount) > 0 Then
                            count += 1
                            Dim itemNo As String = (count).ToString()
                            Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                            tableData.Append(itemNo.PadRight(padItemNo))

                            If categoryName.Length > 47 Then
                                tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                            Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                            End If
                            tableData.Append(categoryAmount.PadLeft(padAmount))
                            tableData.Append(ControlChars.NewLine)
                        End If
                    Next
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceDetails = From data In Me.GetNetInvoiceDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim invoiceDetailQuantities = From data In Me.GetNetInvoiceDetailsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    For Each item In invoiceDetails

                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        If CDec(categoryAmount) > 0 Then

                            count += 1

                            Dim itemNo As String = (count).ToString()
                            Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                            tableData.Append(GetSpaces(padItemNo))
                            If categoryName.Length > 47 Then
                                tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                            Else : tableData.Append(categoryName.PadRight(padItemName))
                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)

                            Dim categorizedInvoiceDetails = (From data In Me.GetNetCategorizedInvoiceDetails Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                            itemDiscount = data.Item5, itemAmount = data.Item6 Into CategoryAmount2 = Sum(data.Item6) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemDiscount, itemAmount Where
                                            CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                            CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                            For Each categorizedItem In categorizedInvoiceDetails
                                countExtra += 1
                                Dim categorizedItemNo As String = (countExtra).ToString()
                                Dim itemName As String = categorizedItem.itemName
                                Dim categorizedInvoiceDetailQuantity = From data In Me.GetNetCategorizedInvoiceDetails Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                       Select totalQuantity, Item2
                                                                       Where Item2 = itemName

                                Dim itemQuantity As String = categorizedInvoiceDetailQuantity.ElementAt(0).totalQuantity.ToString
                                Dim ItemUnitPrice As String = FormatNumber(categorizedItem.itemUnitPrice, AppData.DecimalPlaces)
                                Dim itemDiscount As String = FormatNumber(categorizedItem.itemDiscount, AppData.DecimalPlaces)
                                Dim itemAmount As String = FormatNumber(categorizedItem.itemAmount, AppData.DecimalPlaces)

                                tableData.Append(categorizedItemNo.PadRight(padItemNo))

                                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                                If wrappeditemName.Count > 1 Then
                                    For pos As Integer = 0 To wrappeditemName.Count - 1
                                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                        If Not pos = wrappeditemName.Count - 1 Then
                                            tableData.Append(ControlChars.NewLine)
                                            tableData.Append(GetSpaces(padItemNo))
                                        Else
                                            tableData.Append(itemQuantity.PadLeft(padQuantity))
                                            tableData.Append(itemAmount.PadLeft(padAmount))
                                        End If
                                    Next

                                Else
                                    tableData.Append(FixDataLength(itemName, padItemName))
                                    tableData.Append(itemQuantity.PadLeft(padQuantity))
                                    tableData.Append(itemAmount.PadLeft(padAmount))
                                End If
                                tableData.Append(ControlChars.NewLine)
                            Next
                            tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                            tableData.Append(categoryAmount.PadLeft(padAmount + 41))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            countExtra = 0
                        End If
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then


                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells


                        Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()
                        If CDec(amount) > 0 Then
                            count += 1
                            Dim itemNo As String = cells.Item(Me.colItemCode.Name).Value.ToString()
                            Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                            Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                            Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()

                            tableData.Append(itemNo.PadRight(padICItemNo))
                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padICItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padICItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padICItemNo))
                                    Else
                                        tableData.Append(quantity.PadLeft(padICQuantity))
                                        tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                                        'tableData.Append(discount.PadLeft(padDiscount))
                                        tableData.Append(amount.PadLeft(padICAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padICItemName))
                                tableData.Append(quantity.PadLeft(padICQuantity))
                                tableData.Append(unitPrice.PadLeft(padICUnitPrice))
                                'tableData.Append(discount.PadLeft(padDiscount))
                                tableData.Append(amount.PadLeft(padICAmount))
                            End If

                            tableData.Append(ControlChars.NewLine)

                        End If
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else


                    For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                        
                       
                        Dim amount As String = cells.Item(Me.colAmountBalance.Name).Value.ToString()

                        If CDec(amount) > 0 Then
                            count += 1

                            Dim itemNo As String = (count).ToString()
                            Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                            Dim quantity As String = cells.Item(Me.colQuantityBalance.Name).Value.ToString()
                            Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                            Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()

                            tableData.Append(itemNo.PadRight(padItemNo))
                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padItemNo))
                                    Else
                                        tableData.Append(quantity.PadLeft(padQuantity))
                                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                        tableData.Append(discount.PadLeft(padDiscount))
                                        tableData.Append(amount.PadLeft(padAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padItemName))
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(discount.PadLeft(padDiscount))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If

                            tableData.Append(ControlChars.NewLine)
                        End If
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If



        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function GetNetCategorizedInvoiceDetails() As List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetailsExtra2 As New List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantityBalance, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unitPrice!")
                Dim discount As Decimal = DecimalEnteredIn(cells, Me.colDiscount, False, "discount!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmountBalance, False, "amount!")

                invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal, Decimal)(category, itemName, quantity, unitPrice, discount, amount))

            Next

            Return invoiceDetailsExtra2

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetNetInvoiceDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmountBalance, False, "amount!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region

#Region "Invoice Adjustments"

    Private Function GetCategorizedInvoiceAdjustmentDetails() As List(Of Tuple(Of String, String, Integer, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetailAdjustement As New List(Of Tuple(Of String, String, Integer, Decimal))

            For rowNo As Integer = 0 To Me.dgvAdjustments.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvAdjustments.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colAdjCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colAdjItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colAdjQuantity, "quantity!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAdjAMount, False, "amount!")
                invoiceDetailAdjustement.Add(New Tuple(Of String, String, Integer, Decimal)(category, itemName, quantity, amount))

            Next

            Return invoiceDetailAdjustement

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function GetInvoiceAdjustmentDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvAdjustments.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvAdjustments.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colAdjCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAdjAMount, False, "amount!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function GetVisitInvoiceAdjustmentHeaderPrintData() As StringBuilder

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 7
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4

        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20


        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()
        Dim tableHeader As New System.Text.StringBuilder(String.Empty)
        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkPrintInvoiceDetailedOnSaving.Checked = True Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Amount: ".PadLeft(padUnitPrice + padDiscount + padAmount))

                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)



            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)



                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then

                    tableHeader.Append("Code: ".PadRight(padICItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padICItemName))
                    tableHeader.Append("Qty: ".PadRight(padICQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padUnitPrice + padICAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padUnitPrice + padDiscount + padAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
        Return tableHeader
    End Function


    Private Function GetVisitInvoiceAdjustmentPrintData() As StringBuilder

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 27
        Dim padQuantity As Integer = 4
        Dim padICUnitPrice As Integer = 14
        Dim padICDiscount As Integer = 9
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 60


        Dim padICItemNo As Integer = 9
        Dim padICItemName As Integer = 34
        Dim padICQuantity As Integer = 4

        Dim padICAmount As Integer = 14
        Dim padICTotalAmount As Integer = 60

        Dim padAmountTendered As Integer = 53
        Dim padBalance As Integer = 56

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20


        pageNo = 0
        invoiceParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()
        Dim tableData As New System.Text.StringBuilder(String.Empty)

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)



            If chkPrintInvoiceDetailedOnSaving.Checked = True Then


                For rowNo As Integer = 0 To Me.dgvAdjustments.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvAdjustments.Rows(rowNo).Cells
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colAdjItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colAdjQuantity.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colAdjAMount.Name).Value.ToString()


                    tableData.Append(itemNo.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(quantity.PadLeft(padQuantity))

                                tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICDiscount + padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICDiscount + padAmount))
                    End If

                    tableData.Append(ControlChars.NewLine)
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Return tableData

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceAdjustmentDetails = From data In Me.GetInvoiceAdjustmentDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount



                    For Each item In invoiceAdjustmentDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                        tableData.Append(itemNo.PadRight(padItemNo))

                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                        Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                        End If
                        tableData.Append(("-" + categoryAmount).PadLeft(padAmount))
                        tableData.Append(ControlChars.NewLine)

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    Return tableData
                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim invoiceAdjustmentDetails = From data In Me.GetInvoiceAdjustmentDetailsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim AdjustedQuantities = From data In Me.GetInvoiceAdjustmentDetailsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    For Each item In invoiceAdjustmentDetails

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                        Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)
                        tableData.Append(GetSpaces(padItemNo))
                        If categoryName.Length > 47 Then
                            tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                        Else : tableData.Append(categoryName.PadRight(padItemName))
                        End If
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)

                        Dim categorizedInvoiceDetails = (From data In Me.GetCategorizedInvoiceAdjustmentDetails Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3,
                                         itemAmount = data.Item4 Into CategoryAmount2 = Sum(data.Item4) Select CategoryNameExtra, itemName, itemQuantity, itemAmount Where
                                        CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                        CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                        For Each categorizedItem In categorizedInvoiceDetails
                            countExtra += 1
                            Dim categorizedItemNo As String = (countExtra).ToString()
                            Dim itemName As String = categorizedItem.itemName
                            Dim categorizedInvoiceDetailQuantity = From data In Me.GetCategorizedInvoiceDetails Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                   Select totalQuantity, Item2
                                                                   Where Item2 = itemName

                            Dim itemQuantity As String = categorizedInvoiceDetailQuantity.ElementAt(0).totalQuantity.ToString

                            Dim itemAmount As String = FormatNumber(categorizedItem.itemAmount, AppData.DecimalPlaces)

                            tableData.Append(categorizedItemNo.PadRight(padItemNo))

                            Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                            If wrappeditemName.Count > 1 Then
                                For pos As Integer = 0 To wrappeditemName.Count - 1
                                    tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                    If Not pos = wrappeditemName.Count - 1 Then
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padItemNo))
                                    Else
                                        tableData.Append(itemQuantity.PadLeft(padQuantity))
                                        tableData.Append(("-" + itemAmount).PadLeft(padAmount))
                                    End If
                                Next

                            Else
                                tableData.Append(FixDataLength(itemName, padItemName))
                                tableData.Append(itemQuantity.PadLeft(padQuantity))
                                tableData.Append(("-" + itemAmount).PadLeft(padAmount))
                            End If
                            tableData.Append(ControlChars.NewLine)
                        Next
                        tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                        tableData.Append("-" + categoryAmount.PadLeft(padAmount + 41))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(ControlChars.NewLine)
                        countExtra = 0
                    Next
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Return tableData
                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)

                    For rowNo As Integer = 0 To Me.dgvAdjustments.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvAdjustments.Rows(rowNo).Cells
                        count += 1

                        'im itemNo As String = (count).ToString()
                        Dim itemNo As String = cells.Item(Me.colAdjItemCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colAdjItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colAdjQuantity.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colAdjAMount.Name).Value.ToString()



                        tableData.Append(itemNo.PadRight(padICItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padICItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padICItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padICItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padICQuantity))

                                    tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padICItemName))
                            tableData.Append(quantity.PadLeft(padICQuantity))
                            tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    Return tableData

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)

                    For rowNo As Integer = 0 To Me.dgvAdjustments.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvAdjustments.Rows(rowNo).Cells
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colAdjItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colAdjQuantity.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colAdjAMount.Name).Value.ToString()


                        tableData.Append(itemNo.PadRight(padItemNo))
                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(quantity.PadLeft(padQuantity))
                                    tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICDiscount + padAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(quantity.PadLeft(padQuantity))
                            tableData.Append(("-" + amount).PadLeft(padICUnitPrice + padICDiscount + padAmount))
                        End If

                        tableData.Append(ControlChars.NewLine)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Return tableData

                End If
            End If




            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

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


    Private Sub btnPrintPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.SetVisitInvoicePrintData()

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

End Class