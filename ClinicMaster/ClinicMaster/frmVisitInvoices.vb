
Option Strict On
Option Infer On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports SyncSoft.Common.Structures

Public Class frmVisitInvoices

#Region " Fields "
    Private defaultVisitNo As String
    Private visitTypeID As String
    Private oVisitTypeID As New LookupDataID.VisitTypeID()

    Private WithEvents docInvoices As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private oVariousOptions As New VariousOptions()
    Private oCoPayTypeID As New LookupDataID.CoPayTypeID()
    Private printTitle As String
#End Region




    Private Sub frmVisitInvoices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = Me.defaultVisitNo

                If Me.visitTypeID.ToUpper.Equals(oVisitTypeID.InPatient) Then
                    Me.tbcIPDInvoiceDetails.SelectedTab = Me.tpgIPDInvoiceDetails
                Else
                    Me.tbcIPDInvoiceDetails.SelectedTab = Me.tpgOPDInvoiceDetails
                End If
                Me.LoadData()
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmVisitInvoices_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Dim oVariousOptions As New VariousOptions()
        Dim opatientallergies As New SyncSoft.SQLDb.PatientAllergies()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim hasPackage As Boolean = False
        Dim hasPaidPackage As Boolean = False
        Dim IsPackage As Boolean = False
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim patientAllergyMsg As String = " This Patient has Allergy(s)" + ControlChars.NewLine + "Please take note"

        Try


            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)


            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            Dim insuranceName As String = StringMayBeEnteredIn(row, "InsuranceName")

            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbInsuranceName.Text = insuranceName
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbAge.Text = GetAgeString(birthDate)
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")

            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")

            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")


            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbClaimReferenceNo.Text = StringMayBeEnteredIn(row, "ClaimReferenceNo")
            
           



            'Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            'Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            'Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            'Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            'Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

            Dim billMode As String = StringEnteredIn(row, "BillMode")
            Me.stbBillMode.Text = billMode

            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            hasPaidPackage = BooleanMayBeEnteredIn(row, "HasPaidPackage")
            Dim patientpackageNo As String = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billModesID As String = StringMayBeEnteredIn(row, "BillModesID")
            Dim associatedBillNo As String = StringMayBeEnteredIn(row, "AssociatedBillNo")


            Dim doctorServiceCode As String = StringMayBeEnteredIn(row, "DoctorServiceCode")





            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()

        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbPackage.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbAge.Clear()

        Me.stbTotalVisits.Clear()

        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)

        Me.stbBillMode.Clear()
        Me.dgvInvoiceDetails.Rows.Clear()
        Me.dgvInvoiceExtraBillItems.Rows.Clear()

    End Sub



    Private Sub LoadData()

        ClearControls()
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(stbVisitNo))
        Dim oInvoiceDetails As New InvoiceDetails()
        Dim oInvoiceExtraBillItems As New InvoiceExtraBillItems

        If String.IsNullOrEmpty(visitNo) Then Return

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ShowPatientDetails(visitNo)

            Dim invoiceDetails As DataTable = oInvoiceDetails.GetVisitInvoiceDetails(visitNo).Tables("InvoiceDetails")
            Dim invoiceExtraBillItems As DataTable = oInvoiceExtraBillItems.GetVisitInvoiceExtraBillItems(visitNo).Tables("InvoiceExtraBillItems")

            LoadGridData(Me.dgvInvoiceDetails, invoiceDetails)
            FormatGridRow(Me.dgvInvoiceDetails)

            LoadGridData(Me.dgvInvoiceExtraBillItems, invoiceExtraBillItems)
            FormatGridRow(Me.dgvInvoiceExtraBillItems)

            CalculateInvoiceAmount()

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub stbVisitNo_Leave(sender As Object, e As System.EventArgs) Handles stbVisitNo.Leave
        LoadData()
    End Sub

    Private Sub stbVisitNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbVisitNo.TextChanged
        ClearControls()
    End Sub

    Private Sub btnLoadVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadVisits.Click
        Try
            Me.Cursor = Cursors.WaitCursor


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInvoices As New frmPeriodicInvoicedVisits(Me.stbVisitNo)
            fPeriodicInvoices.ShowDialog(Me)



            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Dim oVisits As New SyncSoft.SQLDb.Visits()

           
            Me.LoadData()

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try


    End Sub



    Private Sub tbcIPDInvoiceDetails_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcIPDInvoiceDetails.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name
                Case Me.tpgOPDInvoiceDetails.Name
                    'ResetControlsIn(Me.pnlBill)
                    Me.chkIncludeIPDInvoices.Text = "Include IPD Invoices"
                   

                Case Me.tpgIPDInvoiceDetails.Name
                    Me.chkIncludeIPDInvoices.Text = "Include OPD Invoices"
                Case Else
                    Me.chkIncludeIPDInvoices.Text = "Include IPD Invoices"

            End Select
            Me.CalculateInvoiceAmount()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub




#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

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
          
            Me.SetPrintData()

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
            Me.SetPrintData()
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
            Dim title As String = AppData.ProductOwner.ToUpper() + " " + printTitle.ToUpper()
            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim visirNoNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)

            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            'Dim startDate As String = StringMayBeEnteredIn(Me.stbStartDate)
            'Dim endDate As String = StringMayBeEnteredIn(Me.stbEndDate)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim memberCardNo As String = StringMayBeEnteredIn(Me.stbMemberCardNo)
            Dim mainMemberName As String = StringMayBeEnteredIn(Me.stbMainMemberName)
            Dim claimReferenceNo As String = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)
            Dim visitType As String

            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name
                Case Me.tpgOPDInvoiceDetails.Name
                    visitType = GetLookupDataDes(oVisitTypeID.OutPatient)


                Case Me.tpgIPDInvoiceDetails.Name
                    visitType = GetLookupDataDes(oVisitTypeID.InPatient)
                Case Else
                    visitType = GetLookupDataDes(oVisitTypeID.OutPatient)

            End Select


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


    Private Function GetHeaderParagraph() As PrintParagraps

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
        Dim printParagraps As New PrintParagraps

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkIncludeIPDInvoices.Checked = True Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Disc: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))

                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                printParagraps = New PrintParagraps(bodyBoldFont, tableHeader.ToString())

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)

                    printParagraps = New PrintParagraps(bodyBoldFont, tableHeader.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))
                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    printParagraps = New PrintParagraps(bodyBoldFont, tableHeader.ToString())

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

                    printParagraps = New PrintParagraps(bodyBoldFont, tableHeader.ToString())


                Else

                    tableHeader.Append("No: ".PadRight(padItemNo))
                    tableHeader.Append("Item Name: ".PadRight(padItemName))
                    tableHeader.Append("Qty: ".PadLeft(padQuantity))
                    tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                    tableHeader.Append("Disc: ".PadLeft(padDiscount))
                    tableHeader.Append("Amount: ".PadLeft(padAmount))

                    tableHeader.Append(ControlChars.NewLine)
                    tableHeader.Append(ControlChars.NewLine)
                    printParagraps = New PrintParagraps(bodyBoldFont, tableHeader.ToString())

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If



        Catch ex As Exception
            Throw ex
        End Try
        Return printParagraps
    End Function



    Private Function GetVisitInvoicePrintData() As PrintParagraps

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

        Dim printParagraps As New PrintParagraps()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkIncludeIPDInvoices.Checked = True Then

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
                printParagraps = New PrintParagraps(bodyNormalFont, tableData.ToString())
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    printParagraps = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''


                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then


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
                    printParagraps = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then



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
                    printParagraps = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else


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
                    printParagraps = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If


            Return printParagraps
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
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantityBalance, "quantity balance!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unitPrice!")
                Dim discount As Decimal = DecimalEnteredIn(cells, Me.colDiscount, False, "discount!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmountBalance, False, "amount balance!")

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
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmountBalance, False, "amount balance!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function GetCategorizedInvoiceExtraBillItems() As List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceExtraBillItemsTurple As New List(Of Tuple(Of String, String, Integer, Decimal, Decimal, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceExtraBillItems.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceExtraBillItems.Rows(rowNo).Cells

                Dim category As String = cells.Item(Me.colIPDCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colIPDItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colIPDQuantityBalance, "quantity balance!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colIPDUnitPrice, False, "unitPrice!")
                Dim discount As Decimal = DecimalEnteredIn(cells, Me.colIPDDiscount, False, "discount!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colIPDAmountBalance, False, "amount balance!")

                invoiceExtraBillItemsTurple.Add(New Tuple(Of String, String, Integer, Decimal, Decimal, Decimal)(category, itemName, quantity, unitPrice, discount, amount))

            Next

            Return invoiceExtraBillItemsTurple

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetInvoiceExtraBillItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim InvoiceExtraBillItemsTurple As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvInvoiceExtraBillItems.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvInvoiceExtraBillItems.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colIPDCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colIPDAmountBalance, False, "amount balance!")

                InvoiceExtraBillItemsTurple.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return InvoiceExtraBillItemsTurple

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function GetInvoiceExtraBillItemsBodyPrintData() As PrintParagraps

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
        Dim paragraphy As New PrintParagraps
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)


            If chkIncludeIPDInvoices.Checked = True Then



                For rowNo As Integer = 0 To Me.dgvInvoiceExtraBillItems.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvInvoiceExtraBillItems.Rows(rowNo).Cells
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colIPDItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colIPDQuantityBalance.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colIPDUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colIPDDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colIPDAmountBalance.Name).Value.ToString()


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
                paragraphy = New PrintParagraps(bodyNormalFont, tableData.ToString())
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Else

                If oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    paragraphy = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




                ElseIf oVariousOptions.CategorizeVisitInvoiceDetails Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim invoiceExtraBillItems = From data In Me.GetInvoiceExtraBillItemsList Group data By CategoryName = data.Item1
                                         Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    Dim invoiceExtraBillItemsQuantities = From data In Me.GetInvoiceExtraBillItemsList Group data By CategoryName = data.Item1
                                        Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    For Each item In invoiceExtraBillItems

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

                        Dim categorizedInvoiceExtraBillItems = (From data In Me.GetCategorizedInvoiceExtraBillItems Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                        itemDiscount = data.Item5, itemAmount = data.Item6 Into CategoryAmount2 = Sum(data.Item6) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemDiscount, itemAmount Where
                                        CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                        CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                        For Each categorizedItem In categorizedInvoiceExtraBillItems
                            countExtra += 1
                            Dim categorizedItemNo As String = (countExtra).ToString()
                            Dim itemName As String = categorizedItem.itemName
                            Dim categorizedExtraBillItemslQuantity = From data In Me.GetCategorizedInvoiceExtraBillItems Group data By data.Item2 Into totalQuantity = Sum(data.Item3)
                                                                   Select totalQuantity, Item2
                                                                   Where Item2 = itemName

                            Dim itemQuantity As String = categorizedExtraBillItemslQuantity.ElementAt(0).totalQuantity.ToString
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
                    paragraphy = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ElseIf oVariousOptions.PrintItemCodesOnInvoices Then


                    For rowNo As Integer = 0 To Me.dgvInvoiceExtraBillItems.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceExtraBillItems.Rows(rowNo).Cells
                        count += 1

                        'im itemNo As String = (count).ToString()
                        Dim itemNo As String = cells.Item(Me.colIPDItemCode.Name).Value.ToString()
                        Dim itemName As String = cells.Item(Me.colIPDItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colIPDQuantityBalance.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colIPDUnitPrice.Name).Value.ToString()
                        'im discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colIPDAmountBalance.Name).Value.ToString()



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
                    paragraphy = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else

                    For rowNo As Integer = 0 To Me.dgvInvoiceExtraBillItems.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvInvoiceExtraBillItems.Rows(rowNo).Cells
                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim itemName As String = cells.Item(Me.colIPDItemName.Name).Value.ToString()
                        Dim quantity As String = cells.Item(Me.colIPDQuantityBalance.Name).Value.ToString()
                        Dim unitPrice As String = cells.Item(Me.colIPDUnitPrice.Name).Value.ToString()
                        Dim discount As String = cells.Item(Me.colIPDDiscount.Name).Value.ToString()
                        Dim amount As String = cells.Item(Me.colIPDAmountBalance.Name).Value.ToString()


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
                    paragraphy = New PrintParagraps(bodyNormalFont, tableData.ToString())
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                End If
            End If



        Catch ex As Exception
            Throw ex
        End Try
        Return paragraphy
    End Function

    Private Sub SetPrintData()
        Try
            Me.Cursor = Cursors.WaitCursor
            invoiceParagraphs = New Collection()
            Dim footerFont As New Font(printFontName, 9)

            Dim invoiceHeader As PrintParagraps = Me.GetHeaderParagraph()
            Dim invoiceDetails As PrintParagraps = Me.GetVisitInvoicePrintData()
            Dim invoiceExtraBill As PrintParagraps = Me.GetInvoiceExtraBillItemsBodyPrintData()
            Dim firstParagraph As PrintParagraps
            Dim secondParagraph As PrintParagraps
            Dim firstGrid As DataGridView
            Dim secondGrid As DataGridView
            Dim connectorString As String = String.Empty
            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name


                Case Me.tpgOPDInvoiceDetails.Name

                    firstParagraph = invoiceDetails
                    secondParagraph = invoiceExtraBill
                    connectorString = "IPD Invoices"
                    firstGrid = Me.dgvInvoiceDetails
                    secondGrid = Me.dgvInvoiceExtraBillItems
                Case Me.tpgIPDInvoiceDetails.Name
                    firstParagraph = invoiceExtraBill
                    secondParagraph = invoiceDetails
                    connectorString = "OPD Invoices"
                    firstGrid = Me.dgvInvoiceExtraBillItems
                    secondGrid = Me.dgvInvoiceDetails
                Case Else
                    firstParagraph = invoiceDetails
                    secondParagraph = invoiceExtraBill
                    connectorString = "IPD Invoices"
                    firstGrid = Me.dgvInvoiceDetails
                    secondGrid = Me.dgvInvoiceExtraBillItems
            End Select



            invoiceParagraphs.Add(invoiceHeader)
            invoiceParagraphs.Add(firstParagraph)
            If Me.chkIncludeIPDInvoices.Checked AndAlso IsPrintable(secondGrid) Then
                Dim connector As New System.Text.StringBuilder(String.Empty)
                connector.Append(ControlChars.NewLine)
                connector.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, connectorString))
                invoiceParagraphs.Add(secondParagraph)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim padTotalAmount As Integer = 60
            Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            Dim totalAmount As Decimal = DecimalMayBeEnteredIn(Me.stbAmount, True)
            totalAmountData.Append(ControlChars.NewLine)
            totalAmountData.Append("Total Amount: ")
            totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            totalAmountData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountInWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

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
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#End Region

#Region " Invoice Details Extras "

    Private Sub cmsInvoiceDetails_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInvoiceDetails.Opening


        Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name


            Case Me.tpgOPDInvoiceDetails.Name
                If Me.dgvInvoiceDetails.ColumnCount < 1 Then
                    Me.cmsInvoiceDetailsCopy.Enabled = False
                    Me.cmsInvoiceDetailsSelectAll.Enabled = False
                Else
                    Me.cmsInvoiceDetailsCopy.Enabled = True
                    Me.cmsInvoiceDetailsSelectAll.Enabled = True
                End If
                Me.cmsDetails.Enabled = Me.dgvInvoiceDetails.SelectedRows.Count < 2
            Case Me.tpgIPDInvoiceDetails.Name
                If Me.dgvInvoiceExtraBillItems.RowCount < 1 Then
                    Me.cmsInvoiceDetailsCopy.Enabled = False
                    Me.cmsInvoiceDetailsSelectAll.Enabled = False
                Else
                    Me.cmsInvoiceDetailsCopy.Enabled = True
                    Me.cmsInvoiceDetailsSelectAll.Enabled = True
                End If
                Me.cmsDetails.Enabled = Me.dgvInvoiceExtraBillItems.SelectedRows.Count < 2
        End Select

       
    End Sub

    Private Sub cmsInvoiceDetailsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name


                Case Me.tpgOPDInvoiceDetails.Name
                    Me.Copy(dgvInvoiceDetails)

                Case Me.tpgIPDInvoiceDetails.Name
                    Me.Copy(dgvInvoiceExtraBillItems)
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name

                Case Me.tpgOPDInvoiceDetails.Name
                    Me.dgvInvoiceDetails.SelectAll()
                Case Me.tpgIPDInvoiceDetails.Name
                    Me.dgvInvoiceExtraBillItems.SelectAll()
            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region


    Private Sub EnablePrintButtons(enabled As Boolean)
        Me.btnPrintPreview.Enabled = enabled
        Me.btnPrint.Enabled = enabled
    End Sub



    Private Sub CalculateInvoiceAmount()


        Dim totalAmount As Decimal
        If chkIncludeIPDInvoices.Checked Then
            totalAmount = (CalculateGridAmount(Me.dgvInvoiceDetails, Me.colAmountBalance) + CalculateGridAmount(Me.dgvInvoiceExtraBillItems, Me.colIPDAmountBalance))

            Me.printTitle = "OPD and IPD Invoices for " + stbVisitNo.Text
            Me.EnablePrintButtons(Me.dgvInvoiceDetails.RowCount > 0 OrElse Me.dgvInvoiceExtraBillItems.RowCount > 0)
        Else
            Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name


                Case Me.tpgIPDInvoiceDetails.Name
                    totalAmount = CalculateGridAmount(Me.dgvInvoiceExtraBillItems, Me.colIPDAmountBalance)
                    Me.printTitle = "IPD Invoices for " + stbVisitNo.Text
                    Me.EnablePrintButtons(Me.dgvInvoiceExtraBillItems.RowCount > 0)

                Case Me.tpgOPDInvoiceDetails.Name
                    totalAmount = CalculateGridAmount(Me.dgvInvoiceDetails, Me.colAmountBalance)
                    Me.printTitle = "OPD Invoices for " + stbVisitNo.Text
                    Me.EnablePrintButtons(Me.dgvInvoiceDetails.RowCount > 0)
            End Select
        End If
        Me.stbAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
        Me.stbAmountInWords.Text = NumberToWords(totalAmount)
    End Sub


    Private Sub chkIncludeIPDInvoices_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkIncludeIPDInvoices.CheckedChanged
        CalculateInvoiceAmount()
    End Sub

    Private Sub cmsDetails_Click(sender As System.Object, e As System.EventArgs) Handles cmsDetails.Click
        Dim rowIndex As Integer = Me.dgvInvoiceDetails.CurrentCell.RowIndex
        Dim invoiceNo As String = String.Empty
       
        Select Case Me.tbcIPDInvoiceDetails.SelectedTab.Name


            Case Me.tpgOPDInvoiceDetails.Name
                invoiceNo = Me.GetSearchInvoiceNo(dgvInvoiceDetails, Me.coIInvoiceNo)
            Case Me.tpgIPDInvoiceDetails.Name
                invoiceNo = Me.GetSearchInvoiceNo(dgvInvoiceExtraBillItems, Me.colIPDInvoiceNo)
        End Select
        If String.IsNullOrEmpty(invoiceNo) Then Return
        Dim fPrintVistsInvoice As New frmPrintVisitsInvoice(invoiceNo)
        fPrintVistsInvoice.Show()
    End Sub

    Private Sub Copy(dataGridView As DataGridView)
        If dataGridView.SelectedCells.Count < 1 Then Return
        Clipboard.SetText(CopyFromControl(dataGridView))

    End Sub

    Private Function GetSearchInvoiceNo(dataGridView As DataGridView, columnName As DataGridViewColumn) As String
        Dim rowIndex As Integer = dataGridView.CurrentCell.RowIndex
        Return StringEnteredIn(dataGridView.Rows(rowIndex).Cells, columnName, "Invoice No!")

    End Function

    Private Function IsPrintable(dataGridView As DataGridView) As Boolean
        Return dataGridView.Rows.Count > 0
    End Function

    Private Sub btnFindVisitNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVisitNo.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.LoadData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
End Class