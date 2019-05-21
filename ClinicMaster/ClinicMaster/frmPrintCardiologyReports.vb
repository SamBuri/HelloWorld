
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPrintCardiologyReports

#Region " Fields "

    Private defaultVisitNo As String = String.Empty
    Private WithEvents docCardiology As New PrintDocument()
    ' The paragraphs.
    Private CardiologyParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmCardiologyReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.ReadOnly = True
                If Not String.IsNullOrEmpty(defaultVisitNo) Then Me.LoadCardiology(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else : Me.stbVisitNo.ReadOnly = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadDoneCardiology_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDoneCardiology.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fDoneItems As New frmDoneItems(Me.stbVisitNo, AlertItemCategory.Cardiology)
            fDoneItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadCardiology(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
            fFindVisitNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadCardiology(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadCardiologyRequests(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboExamFullName.Items.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim items As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Cardiology, oItemStatusID.Done).Tables("Items")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items Is Nothing OrElse items.Rows.Count < 1 Then Throw New ArgumentException("This visit has no done Cardiology examination!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboExamFullName, items, "ItemFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadCardiology(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbIndication.Clear()
        Me.stbBillCustomerName.Clear()
        Me.cboExamFullName.SelectedIndex = -1
        Me.cboExamFullName.SelectedIndex = -1
        Me.ResetControls()

    End Sub

    Private Sub ResetControls()

        Me.stbIndication.Clear()
        Me.stbExamDateTime.Clear()
        Me.stbReport.Clear()
        Me.stbConclusion.Clear()
        Me.stbCardiologist.Clear()
        Me.stbCardiologyTitle.Clear()

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCardiology(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadCardiologyRequests(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboExamFullName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamFullName.SelectedIndexChanged
        Me.GetCardiologyDetails()
    End Sub

    Private Sub GetCardiologyDetails()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oCardiologyReports As New SyncSoft.SQLDb.CardiologyReports()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim examCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboExamFullName))

            If String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(examCode) Then Return

            Dim CardiologyReports As DataTable = oCardiologyReports.GetCardiologyReports(visitNo, examCode, oItemCategoryID.Cardiology).Tables("CardiologyReports")

            If CardiologyReports Is Nothing OrElse CardiologyReports.Rows.Count < 1 Then Return
            Dim row As DataRow = CardiologyReports.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExamDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "ExamDateTime"))
            Me.stbIndication.Text = StringMayBeEnteredIn(row, "Indication")
            Me.stbReport.Text = StringEnteredIn(row, "Report")
            Me.stbConclusion.Text = StringEnteredIn(row, "Conclusion")
            Me.stbCardiologist.Text = StringEnteredIn(row, "CardiologistName")
            Me.stbCardiologyTitle.Text = StringEnteredIn(row, "CardiologyTitle")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " Cardiology Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            StringEnteredIn(cboExamFullName, "Cardiology Examination!")

            Me.PrintCardiology()

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

            StringEnteredIn(cboExamFullName, "Cardiology Examination!")

            Me.SetCardiologyPrintData()
            Dim docTypeID As New LookupDataID.DocumentTypeID()
            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
            Dim docNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
            Dim printdesc As String = (stbFullName.Text + " 's" + " Cardiology Report (Preview)")
            SavePrintDetails(patientNo, docNo, printdesc, docTypeID.Cardiology)

                With dlgPrintPreview
                    .Document = docCardiology
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

    Private Sub PrintCardiology()

        Dim dlgPrint As New PrintDialog()
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim docNo As String = RevertText(StringEnteredIn(Me.stbVisitNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Cardiology Report")
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCardiologyPrintData()
            SavePrintDetails(patientNo, docNo, printdesc, docTypeID.Cardiology)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docCardiology
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docCardiology.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docCardiology_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCardiology.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Cardiology Report".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

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

                If CardiologyParagraphs Is Nothing Then Return

                Do While CardiologyParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(CardiologyParagraphs(1), PrintParagraps)
                    CardiologyParagraphs.Remove(1)

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
                        CardiologyParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (CardiologyParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetCardiologyPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        CardiologyParagraphs = New Collection

        Try

            '''''''''''''''EXAMINATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examTitle As New System.Text.StringBuilder(String.Empty)
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append("EXAMINATION: " + SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName)))
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examTitle.ToString()))

            '''''''''''''''INDICATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim indicationTitle As New System.Text.StringBuilder(String.Empty)
            indicationTitle.Append("INDICATION ")
            indicationTitle.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, indicationTitle.ToString()))

            Dim indicationBody As New System.Text.StringBuilder(String.Empty)
            indicationBody.Append(StringMayBeEnteredIn(Me.stbIndication))
            indicationBody.Append(ControlChars.NewLine)
            indicationBody.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, indicationBody.ToString()))

            '''''''''''''''REPORT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim reportTitle As New System.Text.StringBuilder(String.Empty)
            reportTitle.Append("REPORT ")
            reportTitle.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, reportTitle.ToString()))

            Dim reportBody As New System.Text.StringBuilder(String.Empty)
            reportBody.Append(StringMayBeEnteredIn(Me.stbReport))
            reportBody.Append(ControlChars.NewLine)
            reportBody.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, reportBody.ToString()))


            '''''''''''''''CONCLUSION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim conclusionTitle As New System.Text.StringBuilder(String.Empty)
            conclusionTitle.Append("CONCLUSION ")
            conclusionTitle.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, conclusionTitle.ToString()))

            Dim conclusionBody As New System.Text.StringBuilder(String.Empty)
            conclusionBody.Append(StringMayBeEnteredIn(Me.stbConclusion))
            conclusionBody.Append(ControlChars.NewLine)
            conclusionBody.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, conclusionBody.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim cardiologist As String = StringMayBeEnteredIn(Me.stbCardiologist)
            Dim CardiologyTitle As String = StringMayBeEnteredIn(Me.stbCardiologyTitle)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(FixDataLength(cardiologist, footerLEN))
            footerData.Append(ControlChars.NewLine)
            footerData.Append(CardiologyTitle.ToUpper())
            footerData.Append(ControlChars.NewLine)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) + _
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            CardiologyParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

End Class