
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
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPathologyReports

#Region " Fields "

    Private accessCashServices As Boolean = False

    Private billCustomerName As String = String.Empty
    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty
    Private pathologyRequestsCount As Integer = 0
    Private totalpathologyRequests As Integer = 0

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docpathology As New PrintDocument()
    ' The paragraphs.
    Private pathologyParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
#End Region

#Region " Validations "

    Private Sub dtpExamDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim errorMSG As String = "pathology exam date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim examDateTime As Date = DateMayBeEnteredIn(Me.dtpExamDateTime)

            If examDateTime = AppData.NullDateValue Then Return

            If examDateTime < visitDate Then
                ErrProvider.SetError(Me.dtpExamDateTime, errorMSG)
                Me.dtpExamDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpExamDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

#Region " Utilities "

    Private Sub btnViewTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTemplates.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.PathologyReports, Me.stbDiagnosis)
        fGetTemplates.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub
#End Region

    Private Sub frmPathologyReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.LoadStaff()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboReportTypeID, LookupObjects.PathologyCategory, False)
            LoadLookupDataCombo(Me.cboPathologyTitleID, LookupObjects.PathologyTitles, False)
            clearImagefield()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPathologyReports_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadProcessingPathology_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadProcessingPathology.Click

        Try


            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.PathologyProcessing)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadPathologyData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

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
        Me.LoadPathologyData(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Pathologist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboPathologist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPathologyRequests(ByVal visitNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim items As New DataTable()
        Dim oItems As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboExamFullName.Items.Clear()
            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                items = oItems.GetItems(visitNo, oItemCategoryID.Pathology, oItemStatusID.Processing).Tables("Items")

                If items Is Nothing OrElse items.Rows.Count < 1 Then
                    Dim message As String = "This visit has no processing pathology examination!"
                    DisplayMessage(message)
                    pathologyRequestsCount = 0
                    Return
                Else : pathologyRequestsCount = items.Rows.Count
                End If

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                items = oItems.GetItems(visitNo, oItemCategoryID.Pathology, oItemStatusID.Done).Tables("Items")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboExamFullName, items, "ItemFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadPathologyData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadPathologyData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadPathologyData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPathologyData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadPathologyRequests(visitNo)

        Catch ex As Exception
            Throw ex

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
        billCustomerName = String.Empty
        billModesID = String.Empty
        doctorStaffNo = String.Empty
        Me.stbMemberCardNo.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbIndication.Clear()
        Me.stbUnitPrice.Clear()
        Me.stbBillCustomerName.Clear()
        accessCashServices = False
        Me.cboPathologist.SelectedIndex = -1
        Me.cboPathologist.SelectedIndex = -1
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.cboExamFullName.SelectedIndex = -1
            Me.cboExamFullName.SelectedIndex = -1
        End If
        Me.ResetControls()

    End Sub

    Private Sub ResetControls()

        Me.stbIndication.Clear()
        Me.stbUnitPrice.Clear()
        Me.dtpExamDateTime.Value = Now
        Me.dtpExamDateTime.Checked = False
        Me.stbDiagnosis.Clear()
        Me.cboPathologyTitleID.SelectedIndex = -1
        Me.cboPathologyTitleID.SelectedIndex = -1
        Me.dgvPathologyImages.Rows.Clear()

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            doctorStaffNo = StringMayBeEnteredIn(row, "DoctorStaffNo")
            totalpathologyRequests = IntegerMayBeEnteredIn(row, "TotalPathologyRequests")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPathologist.Text = oStaff.GetCurrentStaffFullName

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
                If Not visitDate.Equals(Today) Then
                    Me.dtpExamDateTime.Value = visitDate
                    Me.dtpExamDateTime.Checked = False
                Else : Me.dtpExamDateTime.Value = Now
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboExamFullName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboExamFullName.SelectedIndexChanged
        Me.GetPathologyDetails()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub GetPathologyDetails()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim examCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboExamFullName))

            If String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(examCode) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim items As DataTable = oItems.GetItem(visitNo, examCode, oItemCategoryID.Pathology).Tables("Items")
            If items Is Nothing OrElse items.Rows.Count < 1 Then Return
            Dim row As DataRow = items.Rows(0)

            Me.stbUnitPrice.Text = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.stbIndication.Text = StringMayBeEnteredIn(row, "ItemDetails")
                Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
                If Not visitDate.Equals(Today) AndAlso Not visitDate.Equals(AppData.NullDateValue) Then
                    Me.dtpExamDateTime.Value = visitDate
                    Me.dtpExamDateTime.Checked = False
                Else : Me.dtpExamDateTime.Value = Now
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oPathologyReports As New SyncSoft.SQLDb.PathologyReports()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Pathology Examination!")

            Dim dataSource As DataTable = oPathologyReports.GetPathologyReports(visitNo, examCode, oItemCategoryID.Pathology).Tables("PathologyReports")
            Me.DisplayData(dataSource)
            Me.LoadPathologyImagesData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try
            Me.Cursor = Cursors.WaitCursor()

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    SavePathologyImages()
                    SavePathologyReports()

                Case ButtonCaption.Update
                    SavePathologyImages()
                    SavePathologyReports()
            End Select
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()
        End Try

    End Sub

    Public Shared Function ConvertBitmapToByteArray(ByVal bmpImage As Bitmap) As Byte()

        Dim bitmapBytes As Byte()
        ' If bmpImage Is Nothing Then Throw New ArgumentException("Must select an image")
        Using stream As New System.IO.MemoryStream
            bmpImage.Save(stream, bmpImage.RawFormat)
            bitmapBytes = stream.ToArray
        End Using
        Return bitmapBytes

    End Function

    Private Sub clearImagefield()
        dgvPathologyImages.Rows(dgvPathologyImages.Rows.Count - 1).Cells(1).Value = DirectCast(dgvPathologyImages.Columns(1), DataGridViewImageColumn).Image
    End Sub

    Private Sub SavePathologyImages()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            For rowNo As Integer = 0 To Me.dgvPathologyImages.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvPathologyImages.Rows(rowNo).Cells
                Try
                    Using oPathologyImages As New SyncSoft.SQLDb.PathologyImages()
                        With oPathologyImages
                            .ImageName = StringEnteredIn(cells, Me.colPathologymageName)
                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .PathologyImage = ConvertBitmapToByteArray(CType(dgvPathologyImages.Rows(rowNo).Cells("colPathologyImage").Value, Bitmap))
                            .LoginID = CurrentUser.LoginID
                        End With

                        Select Case Me.ebnSaveUpdate.ButtonText

                            Case ButtonCaption.Save
                                oPathologyImages.Save()

                            Case ButtonCaption.Update
                                oPathologyImages.Update()

                        End Select
                    End Using
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPathologyImages.Item(Me.colPathologyImagesSaved.Name, rowNo).Value = True

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub SavePathologyReports()

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim lItems As New List(Of DBConnect)
        Dim oVariousOptions As New VariousOptions()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oPathologyReports As New SyncSoft.SQLDb.PathologyReports()
            Dim lPathologyReports As New List(Of DBConnect)

            Dim pathologist As String
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Pathology Examination!")

            With oPathologyReports

                .VisitNo = visitNo
                .ItemCode = examCode
                .ItemCategoryID = oItemCategoryID.Pathology
                .ReportTypeID = StringValueEnteredIn(Me.cboReportTypeID, "Report Type!")
                .ExamDateTime = DateEnteredIn(Me.dtpExamDateTime, "Exam Date Time!")
                .Diagnosis = StringEnteredIn(Me.stbDiagnosis, "Diagnosis!")
                .Macroscopic = StringEnteredIn(Me.stbMacroscopic, "Macroscopic!")
                .Microscopic = StringEnteredIn(Me.stbMicroscopic, "Microscopic!")
                .Indication = StringEnteredIn(Me.stbIndication, "Indication!")
                pathologist = SubstringEnteredIn(Me.cboPathologist, "Pathologist (Staff)!")
                .Pathologist = pathologist
                .PathologyTitleID = StringValueEnteredIn(Me.cboPathologyTitleID, "Pathology Title!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(Pathologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictPathologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Pathologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Pathologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Pathologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPathologyReports.Add(oPathologyReports)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
                    Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
                    Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)
                    Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))

                    Dim quantity As Integer = 1
                    Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.stbUnitPrice, True)
                    Dim examName As String = SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName))
                    Dim amount As Decimal = quantity * unitPrice

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then IsInsuranceFingerprintVerified(patientNo)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = examCode
                            .ItemCategoryID = oItemCategoryID.Pathology
                            .LastUpdate = DateEnteredIn(Me.dtpExamDateTime, "Examination Date!")
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Done
                        End With
                        lItems.Add(oItems)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                        Dim oEntryModeID As New LookupDataID.EntryModeID()

                        Dim lClaims As New List(Of DBConnect)

                        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                        Dim lClaimsEXT As New List(Of DBConnect)
                        Dim lClaimDetails As New List(Of DBConnect)

                        Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

                        Using oClaims As New SyncSoft.SQLDb.Claims()

                            With oClaims

                                .MedicalCardNo = billNo
                                .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                .PatientNo = patientNo
                                .VisitDate = DateEnteredIn(Me.dtpExamDateTime, "Exam Date!")
                                .VisitTime = GetTime(Now)
                                .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                .PrimaryDoctor = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
                                .ClaimStatusID = oClaimStatusID.Pending
                                .ClaimEntryID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID

                            End With

                            lClaims.Add(oClaims)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If String.IsNullOrEmpty(claimNo) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                With oClaimsEXT
                                    .ClaimNo = oClaims.ClaimNo
                                    .VisitNo = visitNo
                                End With

                                lClaimsEXT.Add(oClaimsEXT)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                claimNo = oClaims.ClaimNo
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If

                        End Using

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Pathology)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Pathology)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = examName
                                .BenefitCode = oBenefitCodes.Pathology
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = "Pathology examination, done to Patient No: " + patientNo
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance

                            End With

                            lClaimDetails.Add(oClaimDetails)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End Using

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lPathologyReports, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintExamReportOnSaving.Checked Then Me.PrintPathology()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadPathologyRequests(visitNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If GetShortDate(DateMayBeEnteredIn(Me.dtpExamDateTime)) >= GetShortDate(Today.AddHours(-12)) AndAlso
                        Not String.IsNullOrEmpty(doctorStaffNo) Then
                        Using oAlerts As New SyncSoft.SQLDb.Alerts()
                            With oAlerts

                                .AlertTypeID = oAlertTypeID.RadiologyReports
                                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo))
                                .StaffNo = doctorStaffNo
                                .Notes = (totalpathologyRequests - pathologyRequestsCount).ToString() + " of " + totalpathologyRequests.ToString() + " Done"
                                .LoginID = CurrentUser.LoginID

                                .Save()

                            End With
                        End Using
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lPathologyReports, Action.Update, "PathologyReports"))
                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub dgvPathologyImages_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPathologyImages.CellClick

        If Me.colSelectImage.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPathologyImages.Rows(e.RowIndex).IsNewRow Then
            Dim ofdimage As New OpenFileDialog()
            ofdimage.Filter = "Image Files(*.JPG;*.PNG;*.BMP;*.GIF;*TIF)|*.JPG;*.PNG;*.BMP;*.GIF;*TIF"
            Try
                If (ofdimage.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

                    Me.dgvPathologyImages.CurrentCell.OwningRow.Cells("colPathologyImage").Value = Image.FromFile(ofdimage.FileName)
                    End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        ElseIf Me.colSelectImage.Index.Equals(e.ColumnIndex) Then

            Dim ofdimage As New OpenFileDialog()
            ofdimage.Filter = "Image Files(*.JPG;*.PNG;*.BMP;*.GIF;*.ICO;*TIF)|*.JPG;*.PNG;*.BMP;*.GIF;*.ICO;*TIF"
            Try
                If (ofdimage.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then

                    Me.dgvPathologyImages.CurrentCell.OwningRow.Cells("colPathologyImage").Value = Image.FromFile(ofdimage.FileName)

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If

    End Sub

    Private Sub LoadPathologyImagesData(ByVal dataSource As DataTable)

        Dim oPathologyImages As New SyncSoft.SQLDb.PathologyImages()
        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
        Try

            ' Load from Lab PathologyImages
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathologyImages As DataTable = oPathologyImages.GetPathologyImages(RevertText(visitNo)).Tables("PathologyImages")

            If pathologyImages Is Nothing Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvPathologyImages.Rows.Clear()

            If pathologyImages Is Nothing OrElse pathologyImages.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To pathologyImages.Rows.Count - 1

                Dim row As DataRow = pathologyImages.Rows(pos)
                With Me.dgvPathologyImages

                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colPathologyImage.Name, pos).Value = ImageEnteredIn(row, "PathologyImage")
                    .Item(Me.colPathologymageName.Name, pos).Value = StringEnteredIn(row, "ImageName")
                    .Item(Me.colPathologyImagesSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvPathologyImages_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPathologyImages.UserDeletingRow

        Dim oPathologyImages As New PathologyImages()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvPathologyImages.Item(Me.colPathologyImagesSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim ImageName As String = e.Row.Cells("colPathologymageName").Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            With oPathologyImages
                .VisitNo = visitNo
                .ImageName = ImageName
            End With

            DisplayMessage(oPathologyImages.Delete())

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Pathology Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            If cboExamFullName.Text = "" Then
                DisplayMessage("You must select the Pathology Examination!")
            Else

                Me.PrintPathology()
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintPathology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPathologyPrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docpathology
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docpathology.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPathology_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docpathology.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Histopathology Report".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim examinationDate As String = StringMayBeEnteredIn(Me.dtpExamDateTime)
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                    .DrawString("Reported on: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(examinationDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 3 * lineHeight

                    ''''''''''''''''''''''''''''''''''''PRINTING IMAGES
                    Dim ImagesOnRow As Integer = 0
                    Dim xposOriginal As Single = xPos
                    Dim imagecount As Single = dgvPathologyImages.Rows.Count - 2   '-2 caters for the extra 1 row of the default image

                    For Each rrow As DataGridViewRow In dgvPathologyImages.Rows
                        If imagecount >= 0 Then

                            ImagesOnRow += 1
                            '.DrawImage(DirectCast(rrow.Cells("colPathologyImage").Value, Image), xPos, yPos)
                            .DrawImage(New Bitmap(DirectCast(rrow.Cells("colPathologyImage").Value, Image), New Size(300, 200)), xPos, yPos)
                            '.DrawString(rrow.Cells("colPathologymageName").Value.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos + 210)

                            .DrawString(StringEnteredIn(rrow.Cells, Me.colPathologymageName), bodyNormalFont, Brushes.Black, xPos, yPos + 210)

                            xPos += System.Drawing.GraphicsUnit.Pixel * 150
                            If ImagesOnRow = 2 Then 'yPos will be incremented after printing 2 images on one row i.e x = 2. xPos will be reset
                                yPos += System.Drawing.GraphicsUnit.Pixel * 150
                                xPos = xposOriginal
                                ImagesOnRow = 0
                            End If

                            imagecount -= 1
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''
                    'add space of 15 lines after an even number of images has been printed
                    If dgvPathologyImages.Rows.Count > 0 AndAlso dgvPathologyImages.Rows.Count Mod 2 = 0 Then
                        yPos += 15 * lineHeight
                    End If

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

                If pathologyParagraphs Is Nothing Then Return

                Do While pathologyParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(pathologyParagraphs(1), PrintParagraps)
                    pathologyParagraphs.Remove(1)

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
                        pathologyParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (pathologyParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPathologyPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        pathologyParagraphs = New Collection()

        Try
            
            '''''''''''''''REPORT TYPE'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim reportTitle As New System.Text.StringBuilder(String.Empty)
            reportTitle.Append(ControlChars.NewLine)
            reportTitle.Append("REPORT TYPE: " + SubstringLeft(StringMayBeEnteredIn(Me.cboReportTypeID)))
            reportTitle.Append(ControlChars.NewLine)
            reportTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, reportTitle.ToString()))
            '''''''''''''''EXAMINATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examTitle As New System.Text.StringBuilder(String.Empty)
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append("EXAMINATION: " + SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName)))
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examTitle.ToString()))

            '''''''''''''''INDICATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim indicationTitle As New System.Text.StringBuilder(String.Empty)
            indicationTitle.Append("INDICATION ")
            indicationTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, indicationTitle.ToString()))

            Dim indicationBody As New System.Text.StringBuilder(String.Empty)
            indicationBody.Append(StringMayBeEnteredIn(Me.stbIndication))
            indicationBody.Append(ControlChars.NewLine)
            indicationBody.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, indicationBody.ToString()))


            '''''''''''''''Macroscopic'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim macroscopicTitle As New System.Text.StringBuilder(String.Empty)
            macroscopicTitle.Append("Macroscopic Appearance")
            macroscopicTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, macroscopicTitle.ToString()))

            Dim macroscopicBody As New System.Text.StringBuilder(String.Empty)
            macroscopicBody.Append(StringMayBeEnteredIn(Me.stbMacroscopic))
            macroscopicBody.Append(ControlChars.NewLine)
            macroscopicBody.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, macroscopicBody.ToString()))
       

            '''''''''''''''Microscopic'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim microscopicTitle As New System.Text.StringBuilder(String.Empty)
            microscopicTitle.Append("Microscopic Appearance")
            microscopicTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, microscopicTitle.ToString()))

            Dim microscopicBody As New System.Text.StringBuilder(String.Empty)
            microscopicBody.Append(StringMayBeEnteredIn(Me.stbMicroscopic))
            microscopicBody.Append(ControlChars.NewLine)
            microscopicBody.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, microscopicBody.ToString()))


            '''''''''''''''CONCLUSION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim conclusionTitle As New System.Text.StringBuilder(String.Empty)
            conclusionTitle.Append("Diagnosis/Conclusion ")
            conclusionTitle.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyBoldFont, conclusionTitle.ToString()))

            Dim conclusionBody As New System.Text.StringBuilder(String.Empty)
            conclusionBody.Append(StringMayBeEnteredIn(Me.stbDiagnosis))
            conclusionBody.Append(ControlChars.NewLine)
            conclusionBody.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(bodyNormalFont, conclusionBody.ToString()))
            


            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim pathologist As String = SubstringLeft(StringMayBeEnteredIn(Me.cboPathologist))
            Dim pathologyTitle As String = StringMayBeEnteredIn(Me.cboPathologyTitleID)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(FixDataLength(pathologist, footerLEN))
            footerData.Append(ControlChars.NewLine)
            footerData.Append(pathologyTitle.ToUpper())
            footerData.Append(ControlChars.NewLine)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            pathologyParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        Me.chkPrintExamReportOnSaving.Visible = False

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.btnPrint.Visible = False

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

#End Region

End Class