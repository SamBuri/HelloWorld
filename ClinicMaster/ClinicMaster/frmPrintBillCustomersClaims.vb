
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing

Public Class frmPrintBillCustomersClaims

#Region " Fields "

    Private provisionalDiagnosis As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()
    Private WithEvents docInvoices As New PrintDocument()

    Private padLineNo As Integer = 4
    Private padService As Integer = 24
    Private padCategory As Integer = 10
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 14
    Private padAmount As Integer = 14
    Private padTotalAmount As Integer = 56

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmPrintBillCustomersClaims_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmPrintBillCustomersClaims_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
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
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbPhone.Clear()
        Me.stbInvoiceDate.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbMemberCardNo.Clear()
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
        provisionalDiagnosis = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.dgvDiagnosis.Rows.Clear()
        Me.dgvInvoiceDetails.Rows.Clear()

    End Sub

    Private Sub stbInvoiceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbInvoiceNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbInvoiceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbInvoiceNo.Leave
        Me.LoadInvoicesData()
    End Sub

    Private Sub btnLoadInvoices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadInvoices.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oPayTypeID As New LookupDataID.PayTypeID()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInvoices As New frmPeriodicInvoices(Me.stbInvoiceNo, oPayTypeID.VisitBill)
            fPeriodicInvoices.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInvoicesData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInvoicesData()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim invoiceNo As String = RevertText(StringMayBeEnteredIn(Me.stbInvoiceNo))
            If String.IsNullOrEmpty(invoiceNo) Then Return

            Me.ClearControls()
            Me.LoadInvoices(invoiceNo)
            Me.LoadInvoiceDetails(invoiceNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInvoices(ByVal invoiceNo As String)

        Dim oInvoices As New SyncSoft.SQLDb.Invoices()
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Dim invoicesRow As DataRow = oInvoices.GetInvoices(invoiceNo).Tables("Invoices").Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(invoicesRow, "PayNo"))
            Dim visitsRow As DataRow = oVisits.GetVisits(visitNo).Tables("Visits").Rows(0)

            Dim patientNo As String = RevertText(StringEnteredIn(visitsRow, "PatientNo"))

            Me.stbInvoiceNo.Text = FormatText(invoiceNo, "Invoices", "InvoiceNo")
            Me.stbFullName.Text = StringEnteredIn(visitsRow, "FullName")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(visitsRow, "VisitDate"))
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbGender.Text = StringEnteredIn(visitsRow, "Gender")
            Me.stbPhone.Text = StringMayBeEnteredIn(visitsRow, "Phone")
            Me.stbAge.Text = StringEnteredIn(visitsRow, "Age")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(visitsRow, "PrimaryDoctor")
            provisionalDiagnosis = StringMayBeEnteredIn(visitsRow, "ProvisionalDiagnosis")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(visitsRow, "MemberCardNo")
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
           
            Me.stbVisitType.Text = StringEnteredIn(invoicesRow, "VisitType")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDiagnosis(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

#Region " Diagnosis - Grid "

    Private Sub LoadDiagnosis(ByVal visitNo As String)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim diagnosis As DataTable = oDiagnosis.GetDiagnosis(visitNo).Tables("Diagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDiagnosis, diagnosis)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

    Private Sub LoadInvoiceDetails(ByVal invoiceNo As String)

        Dim invoiceDetails As DataTable
        Dim oVisitTypeID As New LookupDataID.VisitTypeID()
        Dim oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()
        Dim oInvoiceExtraBillItems As New SyncSoft.SQLDb.InvoiceExtraBillItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitType As String = StringEnteredIn(Me.stbVisitType, "Visit Type!")

            Me.dgvInvoiceDetails.Rows.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If visitType.ToUpper().Equals(GetLookupDataDes(oVisitTypeID.InPatient).ToUpper()) Then
                invoiceDetails = oInvoiceExtraBillItems.GetInvoiceExtraBillItems(invoiceNo).Tables("InvoiceExtraBillItems")
            Else : invoiceDetails = oInvoiceDetails.GetInvoiceDetails(invoiceNo).Tables("InvoiceDetails")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInvoiceDetails, invoiceDetails)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmount As Decimal = CalculateGridAmount(dgvInvoiceDetails, colAmount)
            Me.stbInvoiceAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
            Me.stbAmountWords.Text = NumberToWords(totalAmount)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
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
            Me.SetInvoicePrintData()

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInvoiceDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on invoice details!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInvoicePrintData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInvoices
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInvoices.Print()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim yImagePos As Single = CSng(yPos / 10)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbInvoiceNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim memberCardNo As String = StringMayBeEnteredIn(Me.stbMemberCardNo)
            Dim claimReferenceNo As String = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)
            Dim visitType As String = StringMayBeEnteredIn(Me.stbVisitType)
            Dim phone As String = StringMayBeEnteredIn(Me.stbPhone)
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 25 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim insuranceNo As String
                    insuranceNo = RevertText(StringMayBeEnteredIn(Me.stbInsuranceNo))
                    If String.IsNullOrEmpty(insuranceNo) Then insuranceNo = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim oBillCustomers As BillCustomers = GetBillCustomersInfo(insuranceNo)

                    Dim title As String = oBillCustomers.BillCustomerName.ToUpper() + " Claim Form".ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oBillCustomers.LogoPhoto IsNot Nothing Then
                        .DrawImage(oBillCustomers.LogoPhoto, 3 * xPos, yImagePos)
                        yPos += 1.8F * oBillCustomers.LogoPhoto.Height / 4.0F
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Address) Then
                        .DrawString(oBillCustomers.Address, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        Dim addressLines As Integer = oBillCustomers.Address.Split(CChar(ControlChars.NewLine)).Length
                        yPos += addressLines * lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Phone) Then
                        .DrawString("Tel: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("     " + oBillCustomers.Phone, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Fax) Then
                        .DrawString("Fax: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("     " + oBillCustomers.Fax, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Email) Then
                        .DrawString("Email: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("       " + oBillCustomers.Email, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Website) Then
                        .DrawString("Website: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("         " + oBillCustomers.Website, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oBillCustomers.Address) OrElse Not String.IsNullOrEmpty(oBillCustomers.Phone) OrElse _
                       Not String.IsNullOrEmpty(oBillCustomers.Fax) OrElse Not String.IsNullOrEmpty(oBillCustomers.Email) OrElse _
                       Not String.IsNullOrEmpty(oBillCustomers.Website) Then
                        yPos += lineHeight
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Phone No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(phone, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight
                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

    Private Sub SetInvoicePrintData()

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        invoiceParagraphs = New Collection()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim insuranceNo As String
            insuranceNo = RevertText(StringMayBeEnteredIn(Me.stbInsuranceNo))
            If String.IsNullOrEmpty(insuranceNo) Then insuranceNo = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oBillCustomers As BillCustomers = GetBillCustomersInfo(insuranceNo)

            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)

            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))

            If Not String.IsNullOrEmpty(Me.DiagnosisData()) Then
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))

            ElseIf String.IsNullOrEmpty(provisionalDiagnosis) Then
                Dim diagnosisEmptyData As New System.Text.StringBuilder(String.Empty)
                diagnosisEmptyData.Append(ControlChars.NewLine)
                diagnosisEmptyData.Append(GetSpaces(10))
                diagnosisEmptyData.Append(GetCharacters("."c, 62))
                diagnosisEmptyData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(footerFont, diagnosisEmptyData.ToString()))
            Else : invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, provisionalDiagnosis))
            End If

            ''''''''''''''''SERVICES'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesTitle As New System.Text.StringBuilder(String.Empty)
            servicesTitle.Append(ControlChars.NewLine)
            servicesTitle.Append("Services: ".ToUpper())
            servicesTitle.Append(ControlChars.NewLine)

            Dim servicesHeader As New System.Text.StringBuilder(String.Empty)
            servicesHeader.Append("No: ".PadRight(padLineNo))
            servicesHeader.Append("Service: ".PadRight(padService))
            servicesHeader.Append("Category: ".PadRight(padCategory))
            servicesHeader.Append("Qty: ".PadLeft(padQuantity))
            servicesHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            servicesHeader.Append("Amount: ".PadLeft(padAmount))
            servicesHeader.Append(ControlChars.NewLine)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, servicesTitle.ToString()))
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, servicesHeader.ToString()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ServicesData()))

            '''''''''''''''''''Total Amount'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            Dim totalAmount As Decimal = DecimalMayBeEnteredIn(Me.stbInvoiceAmount, True)
            totalAmountData.Append(ControlChars.NewLine)

            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))

            totalAmountData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)

            If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                Dim coPayAmount As Decimal = CDec(totalAmount * coPayPercent) / 100
                Dim balanceDue As Decimal = totalAmount - coPayAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim coPayAmountData As New System.Text.StringBuilder(String.Empty)
                coPayAmountData.Append("Co-Pay Amount: ")
                coPayAmountData.Append(FormatNumber(coPayAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 1))
                coPayAmountData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, coPayAmountData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim balanceDueData As New System.Text.StringBuilder(String.Empty)
                balanceDueData.Append("Balance Due: ")
                balanceDueData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount + 1))
                balanceDueData.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceDueData.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            '''''''''''''''Member's Declaration'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberDeclarationTitle As New System.Text.StringBuilder(String.Empty)
            memberDeclarationTitle.Append(ControlChars.NewLine)
            memberDeclarationTitle.Append("Member's Declaration: ".ToUpper())
            memberDeclarationTitle.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, memberDeclarationTitle.ToString()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, oBillCustomers.MemberDeclaration))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberSignData As New System.Text.StringBuilder(String.Empty)
            memberSignData.Append(ControlChars.NewLine)

            memberSignData.Append("Signed:   " + GetCharacters("."c, 30))
            memberSignData.Append(GetSpaces(4))
            memberSignData.Append("Date:  " + GetCharacters("."c, 20))
            memberSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, memberSignData.ToString()))

            '''''''''''''''Doctor's Declaration'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorDeclarationTitle As New System.Text.StringBuilder(String.Empty)
            doctorDeclarationTitle.Append(ControlChars.NewLine)
            doctorDeclarationTitle.Append("Doctor's Declaration: ".ToUpper())
            doctorDeclarationTitle.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, doctorDeclarationTitle.ToString()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, oBillCustomers.DoctorDeclaration))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Signed:   " + GetCharacters("."c, 30))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 20))
            doctorSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim stampData As New System.Text.StringBuilder(String.Empty)
            stampData.Append(ControlChars.NewLine)

            stampData.Append("Stamp:    " + GetCharacters("."c, 30))
            stampData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, stampData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function DiagnosisData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseName)
                tableData.Append(diagnosisDisplay)

                If rowNo < Me.dgvDiagnosis.RowCount - 1 Then tableData.Append(", ")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ServicesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvInvoiceDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceDetails.Rows(rowNo).Cells

                Dim lineNo As String = (rowNo + 1).ToString()
                Dim service As String = StringMayBeEnteredIn(cells, Me.colItemName)
                Dim category As String = StringMayBeEnteredIn(cells, Me.colCategory)
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colAmount)

                tableData.Append(lineNo.PadRight(padLineNo))
                If service.Length > 24 Then
                    tableData.Append(service.Substring(0, 23).PadRight(padService))
                Else : tableData.Append(service.PadRight(padService))
                End If

                If category.Length > 10 Then
                    tableData.Append(category.Substring(0, 9).PadRight(padCategory))
                Else : tableData.Append(category.PadRight(padCategory))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

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