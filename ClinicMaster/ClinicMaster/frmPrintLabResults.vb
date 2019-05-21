
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Public Class frmPrintLabResults

#Region " Fields "
    Private defaultSpecimenNo As String = String.Empty
    Private WithEvents docLaboratory As New PrintDocument()
    ' The paragraphs.
    Private laboratoryParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private m_PagesPrinted As Integer

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
    Private visitServiceCode As String = String.Empty
#End Region

    Private Sub frmLabResults_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadStaff()
            If Not String.IsNullOrEmpty(defaultSpecimenNo) Then
                Me.stbSpecimenNo.ReadOnly = True
                If Not String.IsNullOrEmpty(defaultSpecimenNo) Then Me.LoadLabResults(defaultSpecimenNo)
                ResetControlsIn(Me.pnlNavigateLabResults)
                Me.ProcessTabKey(True)
            Else : Me.stbSpecimenNo.ReadOnly = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmLabResults_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindSpecimenNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindSpecimenNo.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindSpecimenNo As New frmFindAutoNo(Me.stbSpecimenNo, AutoNumber.SpecimenNo)
        fFindSpecimenNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fDoneLabResults As New frmDoneLabResults(Me.stbSpecimenNo)
        fDoneLabResults.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowLabResultsData()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub ClearControls()

        Me.stbDrawnBy.Clear()
        Me.stbDrawnDateTime.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbBillMode.Clear()
        Me.stbAdmissionLocation.Clear()
        Me.dgvLabResults.Rows.Clear()
        Me.clbRunby.Items.Clear()
        Me.stbVisitCategory.Clear()
        Me.chkFingerprintCaptured.Checked = False
    End Sub

    Private Sub stbSpecimenNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.Leave
        Me.ShowLabResultsData()
    End Sub

    Private Sub stbSpecimenNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbSpecimenNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.LabTechnologist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCrosscheckedby, staff, "FullName")
            Me.cboCrosscheckedby.Items.Insert(0, "")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowLabResultsData()

        Try
            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(stbSpecimenNo))
            If Not String.IsNullOrEmpty(specimenNo) Then Me.LoadLabResults(specimenNo)
            ResetControlsIn(Me.pnlNavigateLabResults)
            m_PagesPrinted = 0

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateLabResults)
        End Try

    End Sub

    Private Sub LoadLabResults(ByVal specimenNo As String)

        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim labResults As DataTable = oLabResults.GetLabResults(specimenNo).Tables("LabResults")
            If labResults Is Nothing OrElse labResults.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowResultsDetails(specimenNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabResults, labResults)

            For Each row As DataGridViewRow In Me.dgvLabResults.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabResults.Item(Me.colInclude.Name, row.Index).Value = True
                If CBool(Me.dgvLabResults.Item(Me.colHasSubResults.Name, row.Index).Value).Equals(True) AndAlso
                    Not String.IsNullOrEmpty(Me.dgvLabResults.Item(Me.colResult.Name, row.Index).Value.ToString()) Then
                    Me.dgvLabResults.Item(Me.colExcludeSubResults.Name, row.Index).Value = True
                Else : Me.dgvLabResults.Item(Me.colExcludeSubResults.Name, row.Index).Value = False
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labStaff As EnumerableRowCollection(Of DataRow) = labResults.AsEnumerable()
            Dim runby As String = (From data In labStaff Select data.Field(Of String)("LabTechnologistName")).Distinct.First()
            Dim labTechnologists As IEnumerable(Of String) = (From data In labStaff Select
                                                              data.Field(Of String)("LabTechnologistName")).Distinct

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.clbRunby.Items.Clear()
            For Each labTechnologistName As String In labTechnologists
                Me.clbRunby.Items.Add(labTechnologistName, True)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowResultsDetails(ByVal specimenNo As String)

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oVisits As New SyncSoft.SQLDb.Visits()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim requestRow As DataRow = labRequests.Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(requestRow, "VisitNo"))

            Me.stbDrawnBy.Text = StringEnteredIn(requestRow, "DrawnByName")
            Me.stbDrawnDateTime.Text = FormatDateTime(DateTimeEnteredIn(requestRow, "DrawnDateTime"))
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(requestRow, "PrimaryDoctor")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim visitRow As DataRow = visits.Rows(0)
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(visitRow, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(visitRow, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(visitRow, "FullName")
            Me.stbGender.Text = StringEnteredIn(visitRow, "Gender")
            Me.stbAge.Text = StringEnteredIn(visitRow, "Age")
            Me.stbBillCustomerName.Text = StringEnteredIn(visitRow, "BillCustomerName")
            Me.stbBillMode.Text = StringEnteredIn(visitRow, "BillMode")
            Me.stbAdmissionLocation.Text = StringmaybeEnteredIn(visitRow, "AdmissionLocation")
            Me.stbVisitCategory.Text = StringEnteredIn(visitRow, "VisitCategory")
          
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Lab Results Navigate "

    Private Sub EnableNavigateLabResultsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim labResults As DataTable
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim specimenNo As String = RevertText(StringEnteredIn(Me.stbSpecimenNo, "Specimen No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                labResults = oLabResults.GetLabResultsByPatientNo(patientNo).Tables("LabResults")

                For pos As Integer = 0 To labResults.Rows.Count - 1
                    If specimenNo.ToUpper().Equals(labResults.Rows(pos).Item("SpecimenNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navLabResults.DataSource = labResults
                Me.navLabResults.Navigate(startPosition)

            Else : Me.navLabResults.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateLabResults.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateLabResults_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateLabResults.Click
        Me.EnableNavigateLabResultsCTLS(Me.chkNavigateLabResults.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navLabResults.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim specimenNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(specimenNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbSpecimenNo.Text = FormatText(specimenNo, "LabRequests", "SpecimenNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLabResults(specimenNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Laboratory Printing "

    Private Sub ValidateExcludedSubResults()

        Try

            For Each row As DataGridViewRow In Me.dgvLabResults.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvLabResults.Item(Me.colHasSubResults.Name, row.Index).Value).Equals(True) AndAlso
                    Me.dgvLabResults.Item(Me.colExcludeSubResults.Name, row.Index).Value.Equals(True) AndAlso
                    String.IsNullOrEmpty(Me.dgvLabResults.Item(Me.colResult.Name, row.Index).Value.ToString()) Then
                    Throw New ArgumentException("Excluding Sub Results with no header result value entered, not allowed!")
                End If
            Next

        Catch eX As Exception
            Throw eX
        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim ovariousoptions As New VariousOptions
            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
            Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim requestRow As DataRow = labRequests.Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(requestRow, "VisitNo"))
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim visitCategory As String = visits.Rows(0).Item("VisitCategoryID").ToString()
            Dim docTypeID As New LookupDataID.DocumentTypeID()
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))

            Dim printdesc As String = (stbFullName.Text + " 's" + " Lab Results Report")

            If ovariousoptions.ForceFingerPrintOnSelfRequestLabReport AndAlso visitCategory.ToUpper().Equals(oVisitCategoryID.SelfRequest.ToUpper()) AndAlso chkFingerprintCaptured.Checked = False Then
                Throw New ArgumentException("Printing This Lab Report Requires the Patient :  " + Me.stbFullName.Text + "  to Provide a Fingerprint. Please Click FindbyFingerPrint to Proceed.")
            End If
            Me.ValidateExcludedSubResults()
            Me.PrintLaboratory()
            SavePrintDetails(patientNo, specimenNo, printdesc, docTypeID.LabReport)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click


            Try

            Me.Cursor = Cursors.WaitCursor
            Dim ovariousoptions As New VariousOptions
            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(Me.stbSpecimenNo))
            Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
            Dim oLabRequests As New SyncSoft.SQLDb.LabRequests()
            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim labRequests As DataTable = oLabRequests.GetLabRequests(specimenNo).Tables("LabRequests")
            Dim requestRow As DataRow = labRequests.Rows(0)
            Dim visitNo As String = RevertText(StringEnteredIn(requestRow, "VisitNo"))
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
            Dim docTypeID As New LookupDataID.DocumentTypeID()
            Dim printdesc As String = (stbFullName.Text + " 's" + " Lab Results Report (Print Preview)")
            Dim visitCategory As String = visits.Rows(0).Item("VisitCategoryID").ToString()
                If ovariousoptions.ForceFingerPrintOnSelfRequestLabReport AndAlso visitCategory.ToUpper().Equals(oVisitCategoryID.SelfRequest.ToUpper()) AndAlso chkFingerprintCaptured.Checked = False Then
                    Throw New ArgumentException("Previewing This Lab Report Requires the Patient :  " + Me.stbFullName.Text + " to Provide a Fingerprint. Please Click FindbyFingerPrint to Proceed.")
                End If
                m_PagesPrinted = 0

                ' Make a PrintDocument and attach it to the PrintPreview dialog.
                Dim dlgPrintPreview As New PrintPreviewDialog()

                Me.ValidateExcludedSubResults()
            Me.SetLaboratoryPrintData()

            SavePrintDetails(patientNo, specimenNo, printdesc, docTypeID.LabReport)

                With dlgPrintPreview
                    .Document = docLaboratory
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

    Private Sub PrintLaboratory()

        Dim dlgPrint As New PrintDialog()
        Dim print_document As New PrintDocument
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetLaboratoryPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docLaboratory
            'AddHandler print_document.BeginPrint, AddressOf Print_BeginPrint
            'AddHandler print_document.QueryPageSettings, AddressOf Print_QueryPageSettings
            ''dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docLaboratory.Print()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    ' Get ready to print pages.
    Private Sub Print_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)
        ' We have not yet printed any pages.
        m_PagesPrinted = 0
    End Sub

    Private Sub Print_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs)
        ' Use a 1 inch gutter (printer units are 100 per inch).
        Const gutter As Integer = 100

        ' See if the next page will be the first, odd, or even.
        If m_PagesPrinted = 0 Then
            ' The next page is the first.
            ' Increase the left margin.
            e.PageSettings.Margins.Left += gutter
        ElseIf (m_PagesPrinted Mod 2) = 0 Then
            ' The next page will be odd.
            ' Shift the margins right.
            e.PageSettings.Margins.Left += gutter
            e.PageSettings.Margins.Right -= gutter
        Else
            ' The next page will be even.
            ' Shift the margins left.
            e.PageSettings.Margins.Left -= gutter
            e.PageSettings.Margins.Right += gutter
        End If
    End Sub

    Private Sub docLaboratory_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docLaboratory.PrintPage

        Try
            Dim mPageNumber As Integer = 1

        

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 2)
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Laboratory Result(s)".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim specimenNo As String = StringMayBeEnteredIn(Me.stbSpecimenNo)
            Dim drawnBy As String = StringMayBeEnteredIn(Me.stbDrawnBy)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim drawnDateTime As String = StringMayBeEnteredIn(Me.stbDrawnDateTime)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim admissionLocation As String = StringMayBeEnteredIn(Me.stbAdmissionLocation)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)



            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont, True)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Specimen No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(specimenNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Drawn Date/Time: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(drawnDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Drawn By: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(drawnBy, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If Not String.IsNullOrEmpty(admissionLocation) Then
                        .DrawString("Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(admissionLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If laboratoryParagraphs Is Nothing Then Return

                Do While laboratoryParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(laboratoryParagraphs(1), PrintParagraps)
                    laboratoryParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.MarginBounds.Width + 2.75F * xPos, e.MarginBounds.Bottom - yPos)

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
                        laboratoryParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If

                Loop

                m_PagesPrinted += 1

                ' Print the page number right justified 
                ' in the upper corner opposite the gutter
                ' and outside of the margin.
                Dim x As Integer
                Dim string_format As New StringFormat
                x = (e.MarginBounds.Left + e.PageBounds.Left)
                string_format.Alignment = StringAlignment.Center
             
                e.Graphics.DrawString("Page " & m_PagesPrinted.ToString, _
                    bodyNormalFont, Brushes.Black, x, _
                    (e.MarginBounds.Bottom + e.PageBounds.Bottom) \ 2, _
                    string_format)

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (laboratoryParagraphs.Count > 0)

                If e.HasMorePages = (laboratoryParagraphs.Count < 0) Then
                    m_PagesPrinted = 0


                End If


            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

 
    Private Sub SetLaboratoryPrintData()

        Dim itemNameLEN As Integer = 30
        Dim resultsLEN As Integer = 26
        Dim normalRangeLEN As Integer = 32

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        laboratoryParagraphs = New Collection()

        Dim oResultFlagID As New LookupDataID.ResultFlagID()
        Dim oUnitMeasureID As New LookupDataID.UnitMeasureID()
        Dim oLabResultsEXT As New SyncSoft.SQLDb.LabResultsEXT()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim resultHeader As New System.Text.StringBuilder(String.Empty)

            resultHeader.Append(GetSpaces(15) + GetCharacters("-"c, 50))
            resultHeader.Append(ControlChars.NewLine)
            resultHeader.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(footerFont, resultHeader.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)

            tableHeader.Append(FixDataLength("Test Name: ", itemNameLEN))
            tableHeader.Append(FixDataLength("Result: ", resultsLEN))
            tableHeader.Append(FixDataLength("Normal Range: ", normalRangeLEN))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvLabResults.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvLabResults.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvLabResults.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim specimenNo As String = RevertText(StringMayBeEnteredIn(stbSpecimenNo))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvLabResults.RowCount - 1

                If CBool(Me.dgvLabResults.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvLabResults.Rows(rowNo).Cells

                    Dim testCode As String = StringMayBeEnteredIn(cells, Me.colTestCode)
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colTestName)
                    Dim results As String = StringMayBeEnteredIn(cells, Me.colResults)
                    Dim unitMeasure As String = StringMayBeEnteredIn(cells, Me.colUnitMeasure)
                    Dim resultFlag As String = StringMayBeEnteredIn(cells, Me.colResultFlag)
                    Dim normalRange As String = StringMayBeEnteredIn(cells, Me.colNormalRange)
                    Dim report As String = StringMayBeEnteredIn(cells, Me.colReport)
                    Dim hasSubResults As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasSubResults)
                    Dim excludeSubResults As Boolean = BooleanMayBeEnteredIn(cells, Me.colExcludeSubResults)
                    Dim result As String = StringMayBeEnteredIn(cells, Me.colResult)
                    Dim testDescription As String = StringMayBeEnteredIn(cells, Me.ColTestDescription)

                    If hasSubResults AndAlso Not excludeSubResults Then

                        Dim displayItemNameEXT As String = itemName
                        Dim wrappedItemName As List(Of String) = WrapText(displayItemNameEXT, itemNameLEN)
                        If wrappedItemName.Count > 1 Then
                            For pos As Integer = 0 To wrappedItemName.Count - 1
                                tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), itemNameLEN))
                                If Not pos = wrappedItemName.Count - 1 Then

                                    tableData.Append(GetSpaces(itemNameLEN + resultsLEN + normalRangeLEN))
                                    tableData.Append(ControlChars.NewLine)
                                End If
                            Next
                        Else
                            tableData.Append(FixDataLength(displayItemNameEXT, itemNameLEN))
                            tableData.Append(GetSpaces(itemNameLEN + resultsLEN + normalRangeLEN))

                        End If


                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim labResultsEXT As DataTable = oLabResultsEXT.GetLabResultsEXT(specimenNo, testCode).Tables("LabResultsEXT")
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        For pos As Integer = 0 To labResultsEXT.Rows.Count - 1

                            Dim row As DataRow = labResultsEXT.Rows(pos)

                            Dim itemNameEXT As String = StringEnteredIn(row, "SubTestName")
                            Dim resultsEXT As String = StringEnteredIn(row, "Result")
                            Dim unitMeasureEXT As String = StringMayBeEnteredIn(row, "UnitMeasure")
                            Dim resultFlagEXT As String = StringMayBeEnteredIn(row, "ResultFlag")
                            Dim normalRangeEXT As String = StringMayBeEnteredIn(row, "NormalRange")
                            Dim reportEXT As String = StringMayBeEnteredIn(row, "Report")

                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(FixDataLength(GetSpaces(2) + itemNameEXT, itemNameLEN))

                            Dim displayResultsEXT As String
                            If unitMeasureEXT.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                                displayResultsEXT = resultsEXT
                            Else : displayResultsEXT = resultsEXT + " " + unitMeasureEXT
                            End If

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If resultFlagEXT.ToUpper().Equals(GetLookupDataDes(oResultFlagID.Low).ToUpper()) OrElse
                                resultFlagEXT.ToUpper().Equals(GetLookupDataDes(oResultFlagID.High).ToUpper()) Then
                                displayResultsEXT = displayResultsEXT + " (" + resultFlagEXT.Substring(0, 1).ToUpper() + ")"
                            End If

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim wrappedResultsEXT As List(Of String) = WrapText(displayResultsEXT, resultsLEN)
                            If wrappedResultsEXT.Count > 1 Then
                                For posEXT As Integer = 0 To wrappedResultsEXT.Count - 1
                                    tableData.Append(FixDataLength(wrappedResultsEXT(posEXT).Trim(), resultsLEN))
                                    If posEXT = wrappedResultsEXT.Count - 1 Then
                                        Dim wrappedNormalRangeEXT As List(Of String) = WrapText(normalRangeEXT, normalRangeLEN)
                                        If wrappedNormalRangeEXT.Count > 1 Then
                                            For count As Integer = 0 To wrappedNormalRangeEXT.Count - 1
                                                tableData.Append(FixDataLength(wrappedNormalRangeEXT(count).Trim(), normalRangeLEN))
                                                If Not count = wrappedNormalRangeEXT.Count - 1 Then tableData.Append(ControlChars.NewLine)
                                                tableData.Append(GetSpaces(itemNameLEN + resultsLEN))
                                            Next
                                        Else : tableData.Append(FixDataLength(normalRangeEXT, normalRangeLEN))
                                        End If
                                    End If
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(itemNameLEN))
                                Next
                            Else
                                tableData.Append(FixDataLength(displayResultsEXT, resultsLEN))
                                Dim wrappedNormalRangeEXT As List(Of String) = WrapText(normalRangeEXT, normalRangeLEN)
                                If wrappedNormalRangeEXT.Count > 1 Then
                                    For count As Integer = 0 To wrappedNormalRangeEXT.Count - 1
                                        tableData.Append(FixDataLength(wrappedNormalRangeEXT(count).Trim(), normalRangeLEN))
                                        If Not count = wrappedNormalRangeEXT.Count - 1 Then tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(itemNameLEN + resultsLEN))
                                    Next
                                Else : tableData.Append(FixDataLength(normalRangeEXT, normalRangeLEN))
                                End If

                            End If
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If Not String.IsNullOrEmpty(reportEXT) Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(4) + "Report / Comment: " + reportEXT)
                                tableData.Append(ControlChars.NewLine)
                            End If

                            If Not String.IsNullOrEmpty(testDescription) Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(1) + "Reference: " + testDescription)
                                tableData.Append(ControlChars.NewLine)
                            End If
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Next

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not String.IsNullOrEmpty(report) Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(2) + "Report / Comment: " + report)
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        tableData.Append(ControlChars.NewLine)
                    Else
                        tableData.Append(FixDataLength(itemName, itemNameLEN))
                        Dim displayResults As String
                        If excludeSubResults Then results = result
                        If unitMeasure.ToUpper().Equals(GetLookupDataDes(oUnitMeasureID.NA).ToUpper()) Then
                            displayResults = results
                        Else : displayResults = results + " " + unitMeasure
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.Low).ToUpper()) OrElse
                            resultFlag.ToUpper().Equals(GetLookupDataDes(oResultFlagID.High).ToUpper()) Then
                            displayResults = displayResults + " (" + resultFlag.Substring(0, 1).ToUpper() + ")"
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim wrappedResults As List(Of String) = WrapText(displayResults, resultsLEN)
                        If wrappedResults.Count > 1 Then
                            For pos As Integer = 0 To wrappedResults.Count - 1
                                tableData.Append(FixDataLength(wrappedResults(pos).Trim(), resultsLEN))
                                If pos = wrappedResults.Count - 1 Then

                                    Dim wrappedNormalRange As List(Of String) = WrapText(normalRange, normalRangeLEN)
                                    If wrappedNormalRange.Count > 1 Then
                                        For count As Integer = 0 To wrappedNormalRange.Count - 1
                                            tableData.Append(FixDataLength(wrappedNormalRange(count).Trim(), normalRangeLEN))
                                            If Not count = wrappedNormalRange.Count - 1 Then tableData.Append(ControlChars.NewLine)
                                            tableData.Append(GetSpaces(itemNameLEN + resultsLEN))
                                        Next
                                    Else : tableData.Append(FixDataLength(normalRange, normalRangeLEN))
                                    End If

                                End If
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(itemNameLEN))
                            Next
                        Else
                            tableData.Append(FixDataLength(displayResults, resultsLEN))
                            Dim wrappedNormalRange As List(Of String) = WrapText(normalRange, normalRangeLEN)
                            If wrappedNormalRange.Count > 1 Then
                                For count As Integer = 0 To wrappedNormalRange.Count - 1
                                    tableData.Append(FixDataLength(wrappedNormalRange(count).Trim(), normalRangeLEN))
                                    If Not count = wrappedNormalRange.Count - 1 Then tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(itemNameLEN + resultsLEN))
                                Next
                            Else : tableData.Append(FixDataLength(normalRange, normalRangeLEN))
                            End If

                        End If

                        If Not String.IsNullOrEmpty(report) Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(2) + "Report / Comment: " + report)
                            tableData.Append(ControlChars.NewLine)
                        End If
                        If Not String.IsNullOrEmpty(testDescription) Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(1) + "Reference: " + testDescription)
                            tableData.Append(ControlChars.NewLine)
                        End If
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            laboratoryParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim OvariousOptions As New VariousOptions()

            If OvariousOptions.EnableCommentsAtPrintingLabReport.Equals(True) Then
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)

                footerData.Append("Comments  " + GetCharacters("."c, 56))
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)
                footerData.Append(GetSpaces(10) + GetCharacters("."c, 56))
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)
            End If
            If Me.clbRunby.CheckedItems.Count > 0 Then
                For Each checkedItem As String In Me.clbRunby.CheckedItems
                    footerData.Append("Run by:           " + FixDataLength(checkedItem, footerLEN) + "  Sign: ....................")
                    If Me.clbRunby.CheckedItems.IndexOf(checkedItem) < Me.clbRunby.CheckedItems.Count - 1 Then
                        footerData.Append(ControlChars.NewLine)
                        footerData.Append(ControlChars.NewLine)
                    End If
                Next
            Else : footerData.Append("Run by:           " + FixDataLength("....................", footerLEN) + "  Sign: ....................")
            End If
            Dim crosscheckedby As String = StringMayBeEnteredIn(Me.cboCrosscheckedby)
            If String.IsNullOrEmpty(crosscheckedby) Then crosscheckedby = "...................."
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Cross checked by: " + FixDataLength(crosscheckedby, footerLEN) + "  Sign: ....................")
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            laboratoryParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region

    Private Sub btnFindByFingerprint_Click(sender As System.Object, e As System.EventArgs) Handles btnFindByFingerprint.Click
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientFingerprints As DataTable = GetLabResultsFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, patientFingerprints, "SpecimenNo")
                fFingerprintCapture.ShowDialog()

                Dim patientNo As String = RevertText(Me.oCrossMatchTemplate.ID)
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(patientNo) Then Return

                Me.LoadLabResults(patientNo)
            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(patientFingerprints, "SpecimenNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadLabResults(RevertText(Me.oDigitalPersonaTemplate.ID))
                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then
                    Me.chkFingerprintCaptured.Checked = True
                End If
            End If
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

   
End Class