
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Structures
Imports System.Drawing.Printing
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmDeaths

#Region "Fields"
    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padNotes As Integer = 16
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 13
    Private padAmount As Integer = 14

    Private WithEvents docDeathForm As New PrintDocument()

    ' The paragraphs.
    Private DeathParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

#Region " Validations "
    Dim defaultPatientNo As String

    Private Sub dtpDeathDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDeathDate.Validating

        Dim errorMSG As String = "Death date can't be before last visit date!"

        Try

            Dim lastVisitDate As Date = DateMayBeEnteredIn(Me.stbLastVisitDate)
            Dim deathDate As Date = DateMayBeEnteredIn(Me.dtpDeathDate)

            If deathDate = AppData.NullDateValue Then Return

            If deathDate < lastVisitDate Then
                ErrProvider.SetError(Me.dtpDeathDate, errorMSG)
                Me.dtpDeathDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpDeathDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmDeaths_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpDeathDate.MaxDate = Today
        Me.fbnShowDiagnosis.Enabled = False
        Me.LoadStaff()

        If Not String.IsNullOrEmpty(Me.defaultPatientNo) Then
            Me.stbPatientNo.Text = defaultPatientNo
            Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub frmDeaths_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()
        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbLastVisitDate.Clear()
        Me.fbnShowDiagnosis.Enabled = False
    End Sub

    Private Sub stbPatientNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPatientNo.Leave

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If String.IsNullOrEmpty(patientNo) Then Return

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbLastVisitDate.Text = FormatDate(DateEnteredIn(row, "LastVisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

            Me.fbnShowDiagnosis.Enabled = True

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        Me.ClearControls()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oDeaths As New SyncSoft.SQLDb.Deaths()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oDeaths.PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            DisplayMessage(oDeaths.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oDeaths As New SyncSoft.SQLDb.Deaths()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim dataSource As DataTable = oDeaths.GetDeaths(patientNo).Tables("Deaths")

            If dataSource.Rows.Count < 1 Then
                Me.btnPrint.Enabled = False
            Else
                Me.btnPrint.Enabled = True

            End If

            Me.DisplayData(dataSource)
            Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try
            Dim message As String
            Me.Cursor = Cursors.WaitCursor
            Dim oDeaths As New SyncSoft.SQLDb.Deaths()

            With oDeaths

                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
                .DeathDate = DateEnteredIn(Me.dtpDeathDate, "Death Date!")
                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .LoginID = CurrentUser.LoginID
                .TimeOfDeath = TimeEnteredIn(Me.stpDeathTime, "Time Of Death")
                .PrimaryCauseOfDeath = StringEnteredIn(Me.stbPrimaryDeathCause, "Condition directly leading to death")
                .SecondaryCauseOfDeath = StringMayBeEnteredIn(Me.stbSecondaryDeathCause)
                .OtherCauseOfDeath = StringMayBeEnteredIn(Me.stbOtherDeathCause)
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Doctor's Name !")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    If Me.chkPrintDeathForm.Checked = False Then
                        Message = "You have not checked Print Death Form On Saving. " + ControlChars.NewLine + "Would you want a Death Form  printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintDeathForm()
                    Else : Me.PrintDeathForm()
                    End If

                    oDeaths.Save()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oDeaths.Update())

                    Me.CallOnKeyEdit()

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True
        Me.btnLoad.Enabled = False
        Me.btnPrint.Enabled = False
        Me.chkPrintDeathForm.Checked = False
        Me.chkPrintDeathForm.Enabled = False

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False
        Me.btnLoad.Enabled = True
        Me.btnPrint.Enabled = False
        Me.chkPrintDeathForm.Enabled = True
        Me.chkPrintDeathForm.Checked = True

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

#End Region

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo_Leave(Me, System.EventArgs.Empty)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oPatients.GetPatient(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbFullName.Text = oPatients.FullName
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub fbnShowDiagnosis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnShowDiagnosis.Click
        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
        'If String.IsNullOrEmpty(patientNo) Then Return
        Dim fDeathDiagnosis As New frmDeathDiagnosis(patientNo)
        fDeathDiagnosis.ShowDialog(Me)
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboStaffNo.Items.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Insert(0, "")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Death form Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintDeathForm()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintDeathForm()

        Dim dlgPrint As New PrintDialog()
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Death Certificate")
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDeathFormPrintData()
            SavePrintDetails(patientNo, patientNo, printdesc, docTypeID.DeathCertificate)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDeathForm
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDeathForm.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docDeathForm_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDeathForm.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " DEATH CERTIFICATE".ToUpper()
            Dim patientName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim joinDate As String = FormatDate(DateMayBeEnteredIn(Me.stbJoinDate))
            Dim lastVisitDate As String = FormatDate(DateMayBeEnteredIn(Me.stbLastVisitDate))
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim deathDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpDeathDate))
            Dim deathTime As String = StringMayBeEnteredIn(Me.stpDeathTime)
            Dim primaryDeathCause As String = StringMayBeEnteredIn(Me.stbPrimaryDeathCause)
            Dim SecondDeathCause As String = StringMayBeEnteredIn(Me.stbSecondaryDeathCause)
            Dim otherDeathCause As String = StringMayBeEnteredIn(Me.stbOtherDeathCause)
            Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)
            Dim doctorName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))


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
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight
                    .DrawString("Date of Death: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(deathDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight


                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Time of Death: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(deathTime, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Join Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(joinDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Last Visit On: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(lastVisitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Doctor's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(doctorName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)


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

                If DeathParagraphs Is Nothing Then Return

                Do While DeathParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(DeathParagraphs(1), PrintParagraps)
                    DeathParagraphs.Remove(1)

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
                        DeathParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (DeathParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDeathFormPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        Dim PrimaryCause As String = StringMayBeEnteredIn(Me.stbPrimaryDeathCause)
        Dim SecondaryCause As String = StringMayBeEnteredIn(Me.stbSecondaryDeathCause)
        Dim OtherCause As String = StringMayBeEnteredIn(Me.stbOtherDeathCause)
        Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)

        Dim primaryDeathCause As New System.Text.StringBuilder(String.Empty)
        Dim secondaryDeathCause As New System.Text.StringBuilder(String.Empty)
        Dim otherDeathCause As New System.Text.StringBuilder(String.Empty)


        DeathParagraphs = New Collection()

        Try

            If Not (String.IsNullOrEmpty(PrimaryCause) Or String.IsNullOrWhiteSpace(PrimaryCause)) Then
                primaryDeathCause.Append("Disease or condition directly leading to death.".PadRight(padItemNo))
                primaryDeathCause.Append(ControlChars.NewLine)
                'primaryDeathCause.Append(ControlChars.NewLine)
                DeathParagraphs.Add(New PrintParagraps(bodyBoldFont, primaryDeathCause.ToString()))
                DeathParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrimaryDeathCauseData()))
            End If

            If Not (String.IsNullOrEmpty(SecondaryCause) Or String.IsNullOrWhiteSpace(SecondaryCause)) Then
                secondaryDeathCause.Append("Antecedent causes giving rise to the above cause.".PadRight(padItemNo))
                secondaryDeathCause.Append(ControlChars.NewLine)
                'secondaryDeathCause.Append(ControlChars.NewLine)
                DeathParagraphs.Add(New PrintParagraps(bodyBoldFont, secondaryDeathCause.ToString()))
                DeathParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.SecondaryDeathCauseData()))
            End If

            If Not (String.IsNullOrEmpty(OtherCause) Or String.IsNullOrWhiteSpace(OtherCause)) Then
                otherDeathCause.Append("other significant conditions contributing to death.".PadRight(padItemNo))
                otherDeathCause.Append(ControlChars.NewLine)
                'otherDeathCause.Append(ControlChars.NewLine)
                DeathParagraphs.Add(New PrintParagraps(bodyBoldFont, otherDeathCause.ToString()))
                DeathParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherDeathCauseData()))
            End If

            If Not (String.IsNullOrEmpty(notes) Or String.IsNullOrWhiteSpace(notes)) Then
                Dim deathNotes As New System.Text.StringBuilder(String.Empty)
                deathNotes.Append("Notes.".PadRight(padItemNo))
                deathNotes.Append(ControlChars.NewLine)
                'otherDeathCause.Append(ControlChars.NewLine)
                DeathParagraphs.Add(New PrintParagraps(bodyBoldFont, deathNotes.ToString()))
                DeathParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.deathNotes()))
            End If

            Dim signArea As New System.Text.StringBuilder(String.Empty)
            signArea.Append(ControlChars.NewLine)
            signArea.Append("Doctor's Sign:")
            signArea.Append(GetSpaces(1))
            signArea.Append(GetCharacters("."c, 20))
            signArea.Append(GetSpaces(3))
            signArea.Append(" Date:")
            signArea.Append(GetSpaces(1))
            signArea.Append(GetCharacters("."c, 20))
            DeathParagraphs.Add(New PrintParagraps(bodyNormalFont, signArea.ToString()))
            signArea.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            DeathParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''            
            'Reset pageNo so that one can print header data on other death forms without first closing the form
            pageNo = 0
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function PrimaryDeathCauseData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbPrimaryDeathCause.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function SecondaryDeathCauseData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbSecondaryDeathCause.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function OtherDeathCauseData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbOtherDeathCause.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function deathNotes() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbNotes.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

End Class