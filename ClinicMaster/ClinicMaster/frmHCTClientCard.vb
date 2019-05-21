
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports System.Drawing.Printing

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmHCTClientCard

#Region " Fields "
    Private itemCount As Integer
    Private WithEvents docHCTClientCard As New PrintDocument()
    Private WithEvents docHCTConsent As New PrintDocument()
    ' The paragraphs.
    Private HCTClientCardParagraphs As Collection
    Private HCTconsentParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

    Private Sub ClearControls()

        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbPatientNo.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbVillage.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVillage.Clear()
        Me.stbSubCounty.Clear()

        '''''''''''''''''''''''''''''''''''''
        Me.cboDistrictsID.SelectedIndex = -1

        ' Me.cboDistrictsID.Text = String.Empty
        Me.stbHSD.Clear()
        Me.cboCenterTypeID.SelectedIndex = -1
        Me.cboTestingPointID.SelectedIndex = -1
        Me.cboAccompaniedByID.SelectedIndex = -1
        Me.cboPreTestCounselingID.SelectedIndex = -1
        Me.cboCounseledAsID.SelectedIndex = -1
        Me.cboHCTEntryPoint.SelectedIndex = -1
        Me.cboMaritalStatusID.SelectedIndex = -1
        Me.nbxSexualPatnerNo.Clear()
        Me.cboTestedHIVBeforeID.SelectedIndex = -1
        Me.cboHIVTestThreeMonthsID.SelectedIndex = -1
        Me.cboHIVTestSixMonthsID.SelectedIndex = -1
        Me.cboHIVTestTwelveMonthsID.SelectedIndex = -1
        Me.cboResultThreeMonthsID.SelectedIndex = -1
        Me.cboResultSixMonthsID.SelectedIndex = -1
        Me.cboResultTwelveMonthsID.SelectedIndex = -1
        Me.cboNoTestsInTwelveMonthsID.SelectedIndex = -1
        Me.cboPatnerTestedHIVID.SelectedIndex = -1
        Me.cboPatnerTypeID.SelectedIndex = -1
        Me.cboPatnerResultID.SelectedIndex = -1
        Me.cboConsentID.SelectedIndex = -1
        Me.cboHIVResultID.SelectedIndex = -1
        Me.stbTestDoneBy.Clear()
        Me.stbDesignation.Clear()
        Me.dtpTestDate.Value = DateTime.Today
        Me.cboResultReceivedID.SelectedIndex = -1
        Me.cboResultReceivedAsCoupleID.SelectedIndex = -1
        Me.cboCoupleResultsID.SelectedIndex = -1
        Me.cboTBSuspicionID.SelectedIndex = -1
        Me.cboSTIID.SelectedIndex = -1
        Me.cboStartedCotrimoxazoleID.SelectedIndex = -1
        Me.cboLinkedToCareID.SelectedIndex = -1
        Me.stbReferralReason.Clear()
        Me.stbCounselorName.Clear()
        Me.dtpCounselDate.Value = DateTime.Today
        Me.cboHealthUnitCode.SelectedIndex = -1
        Me.cboWhereLinkedToCareID.SelectedIndex = -1

        For i As Integer = 0 To clbKnowAboutServiceID.Items.Count - 1
            clbKnowAboutServiceID.SetItemChecked(i, False)
        Next

        For i As Integer = 0 To clbNoConsentReason.Items.Count - 1
            clbNoConsentReason.SetItemChecked(i, False)
        Next
        '''''''''''''''''''''''''''''''''''''

        Me.clbNoConsentReason.ClearSelected()

    End Sub



#Region " HCT Client Card HIV results Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If cboHIVResultID.Text.ToLower() = "NA".ToLower() Or cboHIVResultID.Text.ToLower() = String.Empty Or cboHIVResultID.Text.ToLower() = "Unknown".ToLower() Then
            MessageBox.Show("The client's HIV test results haven't been entered, therefore the client's slip can't be printed!")
            Return
        End If

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintHCTClientCard()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintHCTClientCard()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPrintHCTClientCardPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docHCTClientCard
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docHCTClientCard.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docHCTConsent_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docHCTClientCard.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim RegNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim title As String = AppData.ProductOwner.ToUpper() + " CLIENT'S SLIP".ToUpper()
            Dim ClientsName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim DistrictName As String = StringMayBeEnteredIn(Me.cboDistrictsID)
            Dim TestDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpTestDate))
            Dim TestResult As String = StringMayBeEnteredIn(Me.cboHIVResultID)
            Dim HealthFacility As String = StringMayBeEnteredIn(Me.cboHealthUnitCode)
            Dim Sex As String = StringMayBeEnteredIn(Me.stbGender)
            Dim Age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim counselorsName As String = StringMayBeEnteredIn(Me.stbCounselorName)
            Dim CounselDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpCounselDate))

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst
                Dim widthTopFifth As Single = 35 * widthTopFirst
                Dim widthTopSith As Single = 43 * widthTopFirst


                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Date:", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(TestDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Reg. No:", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(RegNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth * 0.9F, yPos)
                    yPos += lineHeight

                    .DrawString("Client's Name:", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ClientsName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Sex:", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(Sex, bodyBoldFont, Brushes.Black, xPos + widthTopFourth * 0.9F, yPos)
                    .DrawString("Age:", bodyNormalFont, Brushes.Black, xPos + widthTopFifth * 0.87F, yPos)
                    .DrawString(Age + " (in years)", bodyBoldFont, Brushes.Black, xPos + widthTopFifth * 0.95F, yPos)
                    yPos += lineHeight

                    .DrawString("District's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(DistrictName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Health Facility:", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(HealthFacility, bodyBoldFont, Brushes.Black, xPos + widthTopFourth + widthTopFirst * 0.9F, yPos)
                    yPos += lineHeight

                    .DrawString("Test Results: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(TestResult, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Referral notes:", bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

                    .DrawString("______________________________________________________________________________", bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight
                    .DrawString("______________________________________________________________________________", bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Counselors Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(counselorsName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopFourth + widthTopSecond * 0.5F, yPos)
                    .DrawString(CounselDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth + widthTopSecond * 0.85F, yPos)
                    yPos += lineHeight

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

                If HCTClientCardParagraphs Is Nothing Then Return

                Do While HCTClientCardParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(HCTClientCardParagraphs(1), PrintParagraps)
                    HCTClientCardParagraphs.Remove(1)

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
                        HCTClientCardParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (HCTClientCardParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPrintHCTClientCardPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        HCTClientCardParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            HCTClientCardParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " HCT Client HIV test Consent Printing "

    Private Sub btnPrintConsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintConsent.Click


        If cboConsentID.Text = "No" Or cboConsentID.Text = String.Empty Then
            MessageBox.Show("The client hasn't consented for an HIV test therefore the consent slip can't be printed!")
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.PrintHCTConsent()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintHCTConsent()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPrintHCTConsentPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docHCTConsent
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docHCTConsent.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docdocHCTConsent_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docHCTConsent.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top
            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)


            'Dim RegNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim title As String = AppData.ProductOwner.ToUpper() + " HIV TEST CONSENT FORM".ToUpper()
            Dim ClientsName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim ConsentDate As String = FormatDate(DateTime.Now)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst
                Dim widthTopFifth As Single = 35 * widthTopFirst
                Dim widthTopSith As Single = 43 * widthTopFirst


                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("I", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ClientsName, bodyBoldFont, Brushes.Black, xPos + widthTopFirst, yPos)
                    .DrawString("having received pre-test counseling from my", bodyNormalFont, Brushes.Black, xPos + widthTopSecond * 1.5F, yPos)
                    yPos += lineHeight * 2
                    .DrawString("counselor hereby voluntarily decide and consent for an HIV test.", bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight * 2

                    .DrawString("Signature", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString("Date", bodyNormalFont, Brushes.Black, xPos + widthTopFourth + widthTopSecond * 0.15F, yPos)
                    .DrawString(ConsentDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth + widthTopSecond * 0.42F, yPos)
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

                If HCTconsentParagraphs Is Nothing Then Return

                Do While HCTconsentParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(HCTconsentParagraphs(1), PrintParagraps)
                    HCTconsentParagraphs.Remove(1)

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
                        HCTconsentParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (HCTconsentParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPrintHCTConsentPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        HCTconsentParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            HCTconsentParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

    Private Sub LoadHealthUnits(ByVal districtsID As String)

        Dim healthUnits As DataTable
        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            healthUnits = oHealthUnits.GetHealthUnitsByDistrictsID(districtsID).Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboHealthUnitCode.Sorted = False
            Me.cboHealthUnitCode.DataSource = healthUnits
            Me.cboHealthUnitCode.DisplayMember = "HealthUnitName"
            Me.cboHealthUnitCode.ValueMember = "HealthUnitCode"

            Me.cboHealthUnitCode.SelectedIndex = -1
            Me.cboHealthUnitCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAllHealthUnits(ByVal cbohealthunits As ComboBox)

        Dim healthUnits As DataTable
        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            healthUnits = oHealthUnits.GetHealthUnits().Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            cbohealthunits.Sorted = False
            cbohealthunits.DataSource = healthUnits
            cbohealthunits.DisplayMember = "HealthUnitName"
            cbohealthunits.ValueMember = "HealthUnitCode"

            cbohealthunits.SelectedIndex = -1
            cbohealthunits.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCounties(ByVal districtsID As String)

        Dim oCounties As New SyncSoft.SQLDb.Counties()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Me.cboCountyCode.DataSource = Nothing
            If String.IsNullOrEmpty(districtsID) Then Return

            ' Load all from Counties
            Dim counties As DataTable = oCounties.GetCountiesByDistrictsID(districtsID).Tables("Counties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim oVillages As New SyncSoft.SQLDb.Villages()

            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbOccupation.Text = StringMayBeEnteredIn(row, "Occupation")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim PatientNo As String = RevertText(StringEnteredIn(row, "PatientNo"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dataSource As DataTable = oPatients.GetPatients(PatientNo).Tables("Patients")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patient As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageCode As String = (From data In patient Select data.Field(Of String)("VillageCode")).First()
            If String.IsNullOrEmpty(villageCode) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageRow As DataRow = oVillages.GetVillages(villageCode).Tables("Villages").Rows(0)

            Me.stbDistrict.Text = StringMayBeEnteredIn(villageRow, "District")
            Me.stbSubCounty.Text = StringMayBeEnteredIn(villageRow, "SubCountyName")
            Me.stbParish.Text = StringMayBeEnteredIn(villageRow, "ParishName")
            Me.stbVillage.Text = StringMayBeEnteredIn(villageRow, "VillageName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmHCTClientCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpCounselDate.MaxDate = Today
            Me.dtpTestDate.MaxDate = Today
            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)
            LoadLookupDataCombo(Me.cboCenterTypeID, LookupObjects.CentreType, False)
            LoadLookupDataCombo(Me.cboTestingPointID, LookupObjects.TestingPoint, False)
            LoadLookupDataCombo(Me.cboAccompaniedByID, LookupObjects.Accompaniedby, False)
            LoadLookupDataCombo(Me.cboPreTestCounselingID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCounseledAsID, LookupObjects.CounseledAs, False)
            LoadLookupDataCombo(Me.cboHCTEntryPoint, LookupObjects.HCTEntryPoint, False)
            LoadLookupDataCombo(Me.cboMaritalStatusID, LookupObjects.MaritalStatus, False)
            LoadLookupDataCombo(Me.cboTestedHIVBeforeID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboHIVTestThreeMonthsID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboHIVTestSixMonthsID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboHIVTestTwelveMonthsID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboResultThreeMonthsID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.cboResultSixMonthsID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.cboResultTwelveMonthsID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.cboNoTestsInTwelveMonthsID, LookupObjects.NoOfTestsInTwelveMonths, False)
            LoadLookupDataCombo(Me.cboPatnerTestedHIVID, LookupObjects.YesNoUnknown, False)
            LoadLookupDataCombo(Me.cboPatnerTypeID, LookupObjects.PartnerType, False)
            LoadLookupDataCombo(Me.cboPatnerResultID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.clbKnowAboutServiceID, LookupObjects.KnowAboutService, False)
            LoadLookupDataCombo(Me.cboConsentID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.clbNoConsentReason, LookupObjects.NoConsentReason, False)

            LoadLookupDataCombo(Me.cboHIVResultID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.cboResultReceivedID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboResultReceivedAsCoupleID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboCoupleResultsID, LookupObjects.HIVCoupleResults, False)
            LoadLookupDataCombo(Me.cboTBSuspicionID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboSTIID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboStartedCotrimoxazoleID, LookupObjects.YesNo, False)
            LoadLookupDataCombo(Me.cboLinkedToCareID, LookupObjects.YesNo, False)
            LoadAllHealthUnits(Me.cboWhereLinkedToCareID)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmHCTClientCard_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oHCTClientCard As New SyncSoft.SQLDb.HCTClientCard()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oHCTClientCard.VisitNo = StringEnteredIn(Me.stbVisitNo, "Visit No!")

            DisplayMessage(oHCTClientCard.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim visitNo As String

        Dim oHCTClientCard As New SyncSoft.SQLDb.HCTClientCard()

        Try
            Me.Cursor = Cursors.WaitCursor()

            visitNo = StringEnteredIn(Me.stbVisitNo, "Visit No!")

            Dim dataSource As DataTable = oHCTClientCard.GetHCTClientCard(visitNo).Tables("HCTClientCard")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        btnPrint.Enabled = False
        btnPrintConsent.Enabled = False
        chkPrintConsent.Enabled = False
        chkPrintTestResults.Enabled = False
        chkPrintConsent.Checked = False
        chkPrintTestResults.Checked = False
        ResetControlsIn(Me)

    End Sub

    Public Sub IsPrintControlsEnabled(ByVal flag As Boolean)
        If flag Then
            btnPrint.Enabled = True
            btnPrintConsent.Enabled = True
            chkPrintConsent.Enabled = True
            chkPrintTestResults.Enabled = True
            chkPrintConsent.Checked = True
            chkPrintTestResults.Checked = True
        Else
            btnPrint.Enabled = False
            btnPrintConsent.Enabled = False
            chkPrintConsent.Enabled = False
            chkPrintTestResults.Enabled = False
            chkPrintConsent.Checked = False
            chkPrintTestResults.Checked = False
        End If
    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try
            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

            Dim row As DataRow = dataSource.Rows(0)
            Me.cboHealthUnitCode.SelectedValue = StringMayBeEnteredIn(row, "HealthUnitCode")
            Me.cboWhereLinkedToCareID.SelectedValue = StringMayBeEnteredIn(row, "WhereLinkedToCareID")

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub cboDistrictsID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrictsID.SelectedIndexChanged
        Try

            If Me.cboDistrictsID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboDistrictsID.SelectedValue.ToString()) Then Return

            Dim districtsID As String = StringValueEnteredIn(Me.cboDistrictsID, "District!")
            If String.IsNullOrEmpty(districtsID) Then Return

            Me.LoadHealthUnits(districtsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim oHctClientCard As New SyncSoft.SQLDb.HCTClientCard()
        Dim message As String

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oHctClientCard
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
                .DistrictsID = StringValueEnteredIn(Me.cboDistrictsID, "District!")
                .HealthUnitCode = StringValueEnteredIn(Me.cboHealthUnitCode, "Name of Health Unit!")
                .HSD = StringMayBeEnteredIn(Me.stbHSD)
                .CenterTypeID = StringValueEnteredIn(Me.cboCenterTypeID, "Is centre static or outreach!")
                .TestingPointID = StringValueEnteredIn(Me.cboTestingPointID, "Point Of Testing!")
                .AccompaniedByID = StringValueEnteredIn(Me.cboAccompaniedByID, "Accompanied By!")
                .PreTestCounselingID = StringValueEnteredIn(Me.cboPreTestCounselingID, "Pre-Test Counselling Done!")
                .CounseledAsID = StringValueEnteredIn(Me.cboCounseledAsID, "Counseled As!")
                .HCTEntryPoint = StringValueEnteredIn(Me.cboHCTEntryPoint, "HCT-Entry Point!")
                .MaritalStatusID = StringValueEnteredIn(Me.cboMaritalStatusID, "Marital Status!")
                .SexualPatnerNo = IntegerEnteredIn(Me.nbxSexualPatnerNo, "No of Sexual Partners in last 12 Months!")
                .TestedHIVBeforeID = StringValueEnteredIn(Me.cboTestedHIVBeforeID, "Have you ever tested HIV Before!")
                .HIVTestThreeMonthsID = StringValueEnteredIn(Me.cboHIVTestThreeMonthsID, "Have you Tested HIV in last 3 Months!")
                .HIVTestSixMonthsID = StringValueEnteredIn(Me.cboHIVTestSixMonthsID, "Have you Tested HIV in last 6 Months!")
                .HIVTestTwelveMonthsID = StringValueEnteredIn(Me.cboHIVTestTwelveMonthsID, "Have you Tested HIV in last 12 Months!")
                .ResultThreeMonthsID = StringValueEnteredIn(Me.cboResultThreeMonthsID, "HIV Results in 3 Months!")
                .ResultSixMonthsID = StringValueEnteredIn(Me.cboResultSixMonthsID, "HIV Results in 6 Months!")
                .ResultTwelveMonthsID = StringValueEnteredIn(Me.cboResultTwelveMonthsID, "HIV Results in 12 Months!")
                .NoTestsInTwelveMonthsID = StringValueEnteredIn(Me.cboNoTestsInTwelveMonthsID, "No of Tests in last 12 Months!")
                .PatnerTestedHIVID = StringValueEnteredIn(Me.cboPatnerTestedHIVID, "Has partner been Tested for HIV!")
                .PatnerTypeID = StringValueEnteredIn(Me.cboPatnerTypeID, "Partner Type!")
                .PatnerResultID = StringValueEnteredIn(Me.cboPatnerResultID, "Partner HIV Status!")
                .KnowAboutServiceID = StringToSplitSelectedInAtleastOne(Me.clbKnowAboutServiceID, LookupObjects.KnowAboutService, "How did you Know About Service!")
                .ConsentID = StringValueEnteredIn(Me.cboConsentID, "Do you Consent!")
                .NoConsentReasonID = StringToSplitSelectedInAtleastOne(Me.clbNoConsentReason, LookupObjects.NoConsentReason, "Reason for not consenting!")
                .HIVResultID = StringValueEnteredIn(Me.cboHIVResultID, "HIV Result!")
                .TestDoneBy = StringMayBeEnteredIn(Me.stbTestDoneBy)
                .Designation = StringMayBeEnteredIn(Me.stbDesignation)
                .TestDate = DateMayBeEnteredIn(Me.dtpTestDate)
                .ResultReceivedID = StringValueEnteredIn(Me.cboResultReceivedAsCoupleID, "Results Received!")
                .ResultReceivedAsCoupleID = StringValueEnteredIn(Me.cboResultReceivedAsCoupleID, "Results Received as a couple!")
                .CoupleResultsID = StringValueEnteredIn(Me.cboCoupleResultsID, "Couple Results!")
                .TBSuspicionID = StringValueEnteredIn(Me.cboTBSuspicionID, "Is there TB Suspicion!")
                .STIID = StringValueEnteredIn(Me.cboSTIID, "STI!")
                .StartedCotrimoxazoleID = StringValueEnteredIn(Me.cboStartedCotrimoxazoleID, "Has Client Started Cotrimoxazole prophylaxis!")
                .LinkedToCareID = StringValueEnteredIn(Me.cboLinkedToCareID, "Has Client been Linked To Care!")
                .WhereLinkedToCareID = StringValueEnteredIn(Me.cboWhereLinkedToCareID, "Where!")
                .ReferralReason = StringMayBeEnteredIn(Me.stbReferralReason)
                .CounselorName = StringMayBeEnteredIn(Me.stbCounselorName)
                .CounselDate = DateMayBeEnteredIn(Me.dtpCounselDate)
                .LoginID = CurrentUser.LoginID
                .ClientMachine = My.Computer.Name
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    If oHctClientCard.Save() Then

                        If Not Me.chkPrintConsent.Checked Then
                            message = "You have not checked Print consent On Saving. " + ControlChars.NewLine + "Would you want a consent form printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                                chkPrintConsent.Checked = True
                                btnPrintConsent_Click(Me, System.EventArgs.Empty)
                            End If
                        End If

                        If Not Me.chkPrintTestResults.Checked Then
                            message = "You have not checked Print Test Results On Saving. " + ControlChars.NewLine + "Would you want a result slip printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                                chkPrintTestResults.Checked = True
                                btnPrint_Click(Me, System.EventArgs.Empty)
                            End If
                        End If

                        If Me.chkPrintConsent.Checked And Me.chkPrintTestResults.Checked Then
                            btnPrintConsent_Click(Me, System.EventArgs.Empty)
                            btnPrint_Click(Me, System.EventArgs.Empty)
                        End If

                    End If

                    ClearControls()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        Me.displayHCTData(stbVisitNo)
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
        Me.ClearControls()
    End Sub

    Private Sub displayHCTData(ByVal stbVisitNo As SmartTextBox)

        Dim oHCTClientCard As New SyncSoft.SQLDb.HCTClientCard()

        Try

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Me.Cursor = Cursors.WaitCursor

            Dim dataSource As DataTable = oHCTClientCard.GetHCTClientCard(visitNo).Tables("HCTClientCard")

            If dataSource.Rows.Count = 0 Then
                IsPrintControlsEnabled(False)
                Return
            End If

            Me.DisplayData(dataSource)

            IsPrintControlsEnabled(True)


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oHCTClientCard As New SyncSoft.SQLDb.HCTClientCard()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oHCTClientCard.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oHCTClientCard.Delete())
            ClearControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return

        Me.ShowPatientDetails(visitNo)
        stbVisitNo_Leave(Me, System.EventArgs.Empty)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            stbVisitNo_Leave(Me, System.EventArgs.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub
End Class