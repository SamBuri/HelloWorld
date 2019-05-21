
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports System.Drawing.Printing

Public Class frmPrintInsuranceClaims

#Region " Fields "

    Private insuranceNo As String = String.Empty
    Private WithEvents docClaims As New PrintDocument()

    Private padLineNo As Integer = 4
    Private padService As Integer = 24
    Private padBenefitName As Integer = 10
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 14
    Private padAmount As Integer = 14
    Private padTotalAmount As Integer = 56

    ' The paragraphs.
    Private claimsParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmPrintInsuranceClaims_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPrintInsuranceClaims_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbClaimNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbClaimNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub btnFindClaimNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindClaimNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindClaimNo As New frmFindAutoNo(Me.stbClaimNo, AutoNumber.ClaimNo)
        fFindClaimNo.ShowDialog(Me)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowClaims()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicClaims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicClaims.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicClaims As New frmPeriodicClaims(Me.stbClaimNo)
            fPeriodicClaims.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowClaims()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbMedicalCardNo.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitDate.Clear()
        Me.stbVisitTime.Clear()
        Me.stbHealthUnitName.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbClaimStatus.Clear()
        Me.stbClaimEntry.Clear()
        Me.stbTotalAmount.Clear()
        Me.stbAmountWords.Clear()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbMemberType.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbCompanyName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbPolicyName.Clear()
        Me.stbPolicyStartDate.Clear()
        Me.stbPolicyEndDate.Clear()
        Me.stbVisitNo.Clear()
        Me.dgvDiagnosis.Rows.Clear()
        Me.dgvClaimDetails.Rows.Clear()
        insuranceNo = String.Empty

    End Sub

    Private Sub stbClaimNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbClaimNo.Leave
        Me.ShowClaims()
    End Sub

    Private Sub ShowClaims()

        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim claimNo As String = RevertText(StringMayBeEnteredIn(Me.stbClaimNo))
            If String.IsNullOrEmpty(claimNo) Then Return

            Me.ClearControls()

            Dim row As DataRow = oClaims.GetClaims(claimNo).Tables("Claims").Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbMedicalCardNo.Text = StringEnteredIn(row, "MedicalCardNo")
            Me.stbPatientNo.Text = StringMayBeEnteredIn(row, "PatientNo")
            Me.stbVisitDate.Text = StringMayBeEnteredIn(row, "VisitDate")
            Me.stbVisitTime.Text = StringMayBeEnteredIn(row, "VisitTime")
            Me.stbHealthUnitName.Text = StringMayBeEnteredIn(row, "HealthUnitName")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            Me.stbClaimStatus.Text = StringMayBeEnteredIn(row, "ClaimStatus")
            Me.stbClaimEntry.Text = StringMayBeEnteredIn(row, "ClaimEntry")
            Me.stbVisitNo.Text = StringMayBeEnteredIn(row, "VisitNo")
            insuranceNo = StringMayBeEnteredIn(row, "InsuranceNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbMemberType.Text = StringEnteredIn(row, "MemberType")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbCompanyName.Text = StringEnteredIn(row, "CompanyName")
            Me.stbInsuranceName.Text = StringEnteredIn(row, "InsuranceName")
            Me.stbPolicyName.Text = StringEnteredIn(row, "PolicyName")
            Me.stbPolicyStartDate.Text = FormatDate(DateEnteredIn(row, "PolicyStartDate"))
            Me.stbPolicyEndDate.Text = FormatDate(DateEnteredIn(row, "PolicyEndDate"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClaimDiagnosis(claimNo)
            Me.LoadClaimDetails(claimNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Diagnosis - Grid "

    Private Sub LoadClaimDiagnosis(ByVal claimNo As String)

        Dim oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim claimDiagnosis As DataTable = oClaimDiagnosis.GetClaimDiagnosis(claimNo).Tables("ClaimDiagnosis")
            If claimDiagnosis Is Nothing OrElse claimDiagnosis.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDiagnosis, claimDiagnosis)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " ClaimDetails - Grid "

    Private Sub CalculateTotalAmount()

        Dim totalAmount As Decimal

        For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 1

            If IsNumeric(Me.dgvClaimDetails.Item(Me.colAmount.Name, rowNo).Value) Then
                totalAmount += CDec(Me.dgvClaimDetails.Item(Me.colAmount.Name, rowNo).Value)
            Else : totalAmount += 0
            End If
        Next

        Me.stbTotalAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalAmount)

    End Sub

    Private Sub LoadClaimDetails(ByVal claimNo As String)

        Dim oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

        Try

            Me.dgvClaimDetails.Rows.Clear()

            ' Load ClaimDetails

            Dim claimDetails As DataTable = oClaimDetails.GetClaimDetails(claimNo).Tables("ClaimDetails")
            If claimDetails Is Nothing OrElse claimDetails.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvClaimDetails, claimDetails)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalAmount()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Claims Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintClaims()

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

            Me.SetClaimsPrintData()

            With dlgPrintPreview
                .Document = docClaims
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

    Private Sub PrintClaims()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetClaimsPrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docClaims
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docClaims.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docClaims_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docClaims.PrintPage

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top
            Dim yImagePos As Single = CSng(yPos / 10)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim medicalCardNo As String = StringMayBeEnteredIn(Me.stbMedicalCardNo)
            Dim memberType As String = StringMayBeEnteredIn(Me.stbMemberType)
            Dim visitTime As String = StringMayBeEnteredIn(Me.stbVisitTime)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim policyName As String = StringMayBeEnteredIn(Me.stbPolicyName)
            Dim mainMemberName As String = StringMayBeEnteredIn(Me.stbMainMemberName)
            Dim companyName As String = StringMayBeEnteredIn(Me.stbCompanyName)
            Dim healthUnitName As String = StringMayBeEnteredIn(Me.stbHealthUnitName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim oInsurances As Insurances = GetInsurancesInfo(insuranceNo)
                    Dim title As String = oInsurances.InsuranceName.ToUpper() + " Medical Scheme".ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oInsurances.LogoPhoto IsNot Nothing Then
                        .DrawImage(oInsurances.LogoPhoto, 3 * xPos, yImagePos)
                        yPos += 1.8F * oInsurances.LogoPhoto.Height / 4.0F
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Address) Then
                        .DrawString(oInsurances.Address, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        Dim addressLines As Integer = oInsurances.Address.Split(CChar(ControlChars.NewLine)).Length
                        yPos += addressLines * lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Phone) Then
                        .DrawString("Tel: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("     " + oInsurances.Phone, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Fax) Then
                        .DrawString("Fax: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("     " + oInsurances.Fax, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Email) Then
                        .DrawString("Email: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("       " + oInsurances.Email, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Website) Then
                        .DrawString("Website: ", bodyNormalFont, Brushes.Black, 3 * xPos, yPos)
                        .DrawString("         " + oInsurances.Website, bodyBoldFont, Brushes.Black, 3 * xPos, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(oInsurances.Address) OrElse Not String.IsNullOrEmpty(oInsurances.Phone) OrElse
                       Not String.IsNullOrEmpty(oInsurances.Fax) OrElse Not String.IsNullOrEmpty(oInsurances.Email) OrElse
                       Not String.IsNullOrEmpty(oInsurances.Website) Then
                        yPos += 2 * lineHeight
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Member Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Medical Card No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(medicalCardNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Member Type: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(memberType, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Policy Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(policyName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Time: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitTime, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Company Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(companyName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Main Member: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(mainMemberName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Health Unit: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(healthUnitName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If claimsParagraphs Is Nothing Then Return

                Do While claimsParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(claimsParagraphs(1), PrintParagraps)
                    claimsParagraphs.Remove(1)

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
                        claimsParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (claimsParagraphs.Count > 0)

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetClaimsPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        claimsParagraphs = New Collection()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oInsurances As Insurances = GetInsurancesInfo(insuranceNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''DIAGNOSIS''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)

            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))

            If String.IsNullOrEmpty(Me.DiagnosisData()) Then
                Dim diagnosisEmptyData As New System.Text.StringBuilder(String.Empty)
                diagnosisEmptyData.Append(ControlChars.NewLine)
                diagnosisEmptyData.Append(GetSpaces(10))
                diagnosisEmptyData.Append(GetCharacters("."c, 62))
                diagnosisEmptyData.Append(ControlChars.NewLine)
                claimsParagraphs.Add(New PrintParagraps(footerFont, diagnosisEmptyData.ToString()))

            Else : claimsParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))
            End If

            ''''''''''''''''SERVICES'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesTitle As New System.Text.StringBuilder(String.Empty)
            servicesTitle.Append(ControlChars.NewLine)
            servicesTitle.Append("Services: ".ToUpper())
            servicesTitle.Append(ControlChars.NewLine)

            Dim servicesHeader As New System.Text.StringBuilder(String.Empty)
            servicesHeader.Append("No: ".PadRight(padLineNo))
            servicesHeader.Append("Service: ".PadRight(padService))
            servicesHeader.Append("Category: ".PadRight(padBenefitName))
            servicesHeader.Append("Qty: ".PadLeft(padQuantity))
            servicesHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            servicesHeader.Append("Amount: ".PadLeft(padAmount))
            servicesHeader.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, servicesTitle.ToString()))
            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, servicesHeader.ToString()))
            claimsParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ServicesData()))

            '''''''''''''''''''Total Amount''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmount, True)
            totalAmount.Append(ControlChars.NewLine)

            totalAmount.Append("Total Amount: ")
            totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))

            totalAmount.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            '''''''''''''''Member's Declaration'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberDeclarationTitle As New System.Text.StringBuilder(String.Empty)
            memberDeclarationTitle.Append(ControlChars.NewLine)
            memberDeclarationTitle.Append("Member's Declaration: ".ToUpper())
            memberDeclarationTitle.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, memberDeclarationTitle.ToString()))
            claimsParagraphs.Add(New PrintParagraps(bodyNormalFont, oInsurances.MemberDeclaration))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim memberSignData As New System.Text.StringBuilder(String.Empty)
            memberSignData.Append(ControlChars.NewLine)

            memberSignData.Append("Signed:   " + GetCharacters("."c, 30))
            memberSignData.Append(GetSpaces(4))
            memberSignData.Append("Date:  " + GetCharacters("."c, 20))
            memberSignData.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(footerFont, memberSignData.ToString()))

            '''''''''''''''Doctor's Declaration'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorDeclarationTitle As New System.Text.StringBuilder(String.Empty)
            doctorDeclarationTitle.Append(ControlChars.NewLine)
            doctorDeclarationTitle.Append("Doctor's Declaration: ".ToUpper())
            doctorDeclarationTitle.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(bodyBoldFont, doctorDeclarationTitle.ToString()))
            claimsParagraphs.Add(New PrintParagraps(bodyNormalFont, oInsurances.DoctorDeclaration))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Signed:   " + GetCharacters("."c, 30))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 20))
            doctorSignData.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim stampData As New System.Text.StringBuilder(String.Empty)
            stampData.Append(ControlChars.NewLine)

            stampData.Append("Stamp:    " + GetCharacters("."c, 30))
            stampData.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(footerFont, stampData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            claimsParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function DiagnosisData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseName)
                tableData.Append(diagnosisDisplay)

                If rowNo < Me.dgvDiagnosis.RowCount - 1 Then tableData.Append(", ")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ServicesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvClaimDetails.Rows(rowNo).Cells

                Dim lineNo As String = (rowNo + 1).ToString()
                Dim service As String = StringMayBeEnteredIn(cells, Me.colItemName)
                Dim benefitName As String = StringMayBeEnteredIn(cells, Me.colBenefitName)
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colAmount)

                tableData.Append(lineNo.PadRight(padLineNo))
                If service.Length > 24 Then
                    tableData.Append(service.Substring(0, 23).PadRight(padService))
                Else : tableData.Append(service.PadRight(padService))
                End If

                If benefitName.Length > 10 Then
                    tableData.Append(benefitName.Substring(0, 9).PadRight(padBenefitName))
                Else : tableData.Append(benefitName.PadRight(padBenefitName))
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

End Class