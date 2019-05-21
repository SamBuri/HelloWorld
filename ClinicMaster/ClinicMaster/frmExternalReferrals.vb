
Option Strict On
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing

Public Class frmExternalReferrals

#Region " Fields "
    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docReferralForm As New PrintDocument()
    Private WithEvents docReferralFormReport As New PrintDocument()

    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private ReferralFormParagraphs As Collection
    Private ReferralFormReportParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmExternalReferrals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.LoadStaff()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
    Private Sub frmExternalReferrals_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oExternalReferrals As New SyncSoft.SQLDb.ExternalReferrals()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oExternalReferrals.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))

            DisplayMessage(oExternalReferrals.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click



        Dim oExternalReferrals As New SyncSoft.SQLDb.ExternalReferrals()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
            Dim dataSource As DataTable = oExternalReferrals.GetExternalReferrals(visitNo).Tables("ExternalReferrals")
            Me.DisplayData(dataSource)
            Me.ShowPatientDetails(visitNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim message As String
        Dim oExternalReferrals As New SyncSoft.SQLDb.ExternalReferrals()

        Try
            Me.Cursor = Cursors.WaitCursor()

            With oExternalReferrals

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "VisitNo!"))
                .ProcedurePaidBy = StringMayBeEnteredIn(Me.stbProcedurePaidBy)
                .EmployeeName = StringMayBeEnteredIn(Me.stbEmployeeName)
                .RefferedTo = StringEnteredIn(Me.stbReferredTo, "Reffered To!")
                .DepartureTime = TimeEnteredIn(Me.stpStartTime, "Departure Time!")
                .DateOfReferral = DateEnteredIn(Me.dtpDateOfReferral, "Date Of Referral!")
                .HistoryAndSymptoms = StringEnteredIn(Me.stbHistoryAndSymptoms, "History And Symptoms!")
                .Diagnosis = StringEnteredIn(Me.stbDiagnosis, "Diagnosis!")
                .TreatmentGiven = StringEnteredIn(Me.stbTreatmentGiven, "Treatment Given!")
                .ReasonForReferral = StringEnteredIn(Me.stbReasonForReferral, "Reason For Referral!")
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Name Of Clinician!")
                .AuthorisedBy = StringMayBeEnteredIn(Me.stbAuthorisedBy)
                .TreatmentLimit = DecimalMayBeEnteredIn(Me.nbxTreatmentLimit)
                .LabInvestigations = StringMayBeEnteredIn(Me.stbInvestigationsMade)
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save


                    If Me.chkPrintReferralNoteOnSaving.Checked = False Then
                        message = "You have not checked Print Referral Form On Saving. " + ControlChars.NewLine + "Would you want a Referral Form  printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintReferralForm()
                    Else : Me.PrintReferralForm()
                    End If


                    oExternalReferrals.Save()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oExternalReferrals.Update())
                    Me.CallOnKeyEdit()

            End Select

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
        Me.btnFindVisitNo.Visible = False
        Me.btnLoadPeriodicVisits.Visible = False
        Me.chkPrintReferralNoteOnSaving.Visible = False
        Me.btnPrint.Visible = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

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

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.ShowPatientDetails(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.ShowPatientDetails(Me.oDigitalPersonaTemplate.ID)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbVisitDate.Clear()
        Me.stbPhone.Clear()
        Me.stbLastVisitDate.Clear()
        Me.stbTotalVisits.Clear()

        Me.stbAddress.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.spbPhoto.Image = Nothing


    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"

        Try


            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbAge.Text = GetAgeString(birthDate)
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")

            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.stbAddress.Text = StringMayBeEnteredIn(row, "Address")
            Dim billMode As String = StringEnteredIn(row, "BillMode")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

        Catch ex As Exception
            Exit Try
        End Try



    End Sub

    Private Sub btnFindVisitNo_Click(sender As Object, e As EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbVisitNo.Focus()
    End Sub

    Private Sub stbVisitNo_TextChanged(sender As Object, e As EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub



    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave
        Me.stbVisitNo.Text = FormatText(Me.stbVisitNo.Text.Trim(), "Visits", "VisitNo")
    End Sub

    Private Sub btnLoadPeriodicVisits_Click(sender As Object, e As EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.ShowPatientDetails(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#Region "Print ReferralForm"

    Private Sub PrintReferralForm()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetReferralFormReportPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docReferralFormReport
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docReferralFormReport.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docReferralFormReport_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docReferralFormReport.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " PATIENT'S Referral Form ".ToUpper()
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)


            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

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

                If ReferralFormReportParagraphs Is Nothing Then Return

                Do While ReferralFormReportParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(ReferralFormReportParagraphs(1), PrintParagraps)
                    ReferralFormReportParagraphs.Remove(1)

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
                        ReferralFormReportParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (ReferralFormReportParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function ReferralFormData() As String

        Try
            Dim textData As New System.Text.StringBuilder(String.Empty)
            Dim firstvisit As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim departdate As String = StringMayBeEnteredIn(Me.dtpDateOfReferral)
            Dim departtime As String = StringMayBeEnteredIn(Me.stpStartTime)
            Dim referredTo As String = StringMayBeEnteredIn(Me.stbReferredTo)
            Dim referralNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim fullname As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim historyandsymptoms As String = StringMayBeEnteredIn(Me.stbHistoryAndSymptoms)
            Dim diagnosis As String = StringMayBeEnteredIn(Me.stbDiagnosis)
            Dim treatmentgiven As String = StringMayBeEnteredIn(Me.stbTreatmentGiven)
            Dim reasonforreferral As String = StringMayBeEnteredIn(Me.stbReasonForReferral)
            Dim nameofclinician As String = StringMayBeEnteredIn(Me.cboStaffNo)
            Dim approvedby As String = StringMayBeEnteredIn(Me.stbAuthorisedBy)
            Dim labInvestigations As String = StringMayBeEnteredIn(Me.stbInvestigationsMade)
            Dim limitonvalue As String = StringMayBeEnteredIn(Me.nbxTreatmentLimit)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim address As String = StringMayBeEnteredIn(Me.stbAddress)


            If Not String.IsNullOrEmpty(firstvisit) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("First Visit: " + firstvisit)
                Else : textData.Append("First Visit: " + firstvisit)
                End If
            End If
            If Not String.IsNullOrEmpty(departdate) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Date of Referral: " + departdate)
                Else : textData.Append("Date of Referral: " + departdate)
                End If
            End If
            If Not String.IsNullOrEmpty(departtime) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Departure time: " + departtime)
                Else : textData.Append("Departure time: " + departtime)
                End If
            End If
            If Not String.IsNullOrEmpty(referredTo) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Referred To: " + referredTo)
                Else : textData.Append("Referred To: " + referredTo)
                End If
            End If
            If Not String.IsNullOrEmpty(referralNo) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Referral No: " + referralNo)
                Else : textData.Append("Referral No: " + referralNo)
                End If
            End If
            If Not String.IsNullOrEmpty(age) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Age: " + age)
                Else : textData.Append("Age: " + age)
                End If
            End If
            If Not String.IsNullOrEmpty(address) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Address: " + address)
                Else : textData.Append("Address: " + address)
                End If
            End If
            If Not String.IsNullOrEmpty(fullname) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Patient / Client Name: " + fullname)
                Else : textData.Append("Patient / Client Name: " + fullname)
                End If
            End If
            If Not String.IsNullOrEmpty(patientNo) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Patient No: " + patientNo)
                Else : textData.Append("Patient No: " + patientNo)
                End If
            End If
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("PLEASE ATTEND TO THE ABOVE PERSON WE ARE REFERRING TO YOUR HEALTH UNIT/ HOSPITAL FOR FURTHER MANAGEMENT".ToUpper())
            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(historyandsymptoms) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("History and symptoms: " + historyandsymptoms)
                Else : textData.Append("History and symptoms: " + historyandsymptoms)
                End If
            End If


            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(labInvestigations) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Lab Investigations: " + labInvestigations)
                Else : textData.Append("Lab Investigations: " + labInvestigations)
                End If
            End If

            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(diagnosis) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Diagnosis: " + diagnosis)
                Else : textData.Append("Diagnosis: " + diagnosis)
                End If
            End If
            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(treatmentgiven) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Treatment given: " + treatmentgiven)
                Else : textData.Append("Treatment given: " + treatmentgiven)
                End If
            End If
            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(reasonforreferral) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Reason for referral: " + reasonforreferral)
                Else : textData.Append("Reason for referral: " + reasonforreferral)
                End If
            End If
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("PLEASE COMPLETE THIS NOTE ON DISCHARGE AND SEND IT BACK TO OUR UNIT".ToUpper())
            textData.Append(ControlChars.NewLine)
            If Not String.IsNullOrEmpty(nameofclinician) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Name of clinician: " + nameofclinician)
                Else : textData.Append("Name of clinician: " + nameofclinician)
                End If
            End If
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Signature:" + GetCharacters("."c, 30))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("TO BE COMPLETED AT REFERRAL SITE".ToUpper())
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Date of arrival:" + GetCharacters("."c, 12))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Date of Discharge:" + GetCharacters("."c, 12))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Diagnosis:" + GetCharacters("."c, 40))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Treatment Given:" + GetCharacters("."c, 40))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("TREATMENT OR SURVEILLANCE TO BE CONTINUED".ToUpper())
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Remarks: " + GetCharacters("."c, 40))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Name of Clinician: " + GetCharacters("."c, 40))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)
            textData.Append("Signature: " + GetCharacters("."c, 40))
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)


            If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

            Return textData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub SetReferralFormReportPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        ReferralFormReportParagraphs = New Collection()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ReferralFormReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ReferralFormData()))

            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            ReferralFormReportParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintReferralForm()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

#End Region

#End Region

End Class