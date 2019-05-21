
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
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmRadiologyReports

#Region " Fields "

    Private accessCashServices As Boolean = False

    Private billCustomerName As String = String.Empty
    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty
    Private radiologyRequestsCount As Integer = 0
    Private totalRadiologyRequests As Integer = 0

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docRadiology As New PrintDocument()
    ' The paragraphs.
    Private radiologyParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private priorityID As String

#End Region

#Region " Validations "

    Private Sub dtpExamDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpExamDateTime.Validating

        Dim errorMSG As String = "Radiology exam date can't be before visit date!"

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

    Private Sub frmRadiologyReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.LoadStaff()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboRadiologyTitleID, LookupObjects.RadiologyTitle, False)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub btnLoadProcessingRadiology_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadProcessingRadiology.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.RadiologyProcessing)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadRadiologyData(visitNo)
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
        Me.LoadRadiologyData(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Radiologist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboRadiologist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadRadiologyRequests(ByVal visitNo As String)

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

                items = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Processing).Tables("Items")

                If items Is Nothing OrElse items.Rows.Count < 1 Then
                    Dim message As String = "This visit has no processing radiology examination!"
                    DisplayMessage(message)
                    radiologyRequestsCount = 0
                    Return
                Else : radiologyRequestsCount = items.Rows.Count
                End If

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                items = oItems.GetItems(visitNo, oItemCategoryID.Radiology, oItemStatusID.Done).Tables("Items")
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

                Me.LoadRadiologyData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadRadiologyData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

#Region " Utilities "

    Private Sub btnViewTemplates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTemplates.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.RadiologyReports, Me.stbReport)
        fGetTemplates.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

#End Region

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadRadiologyData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadRadiologyData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadRadiologyRequests(visitNo)

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
        Me.cboRadiologist.SelectedIndex = -1
        Me.cboRadiologist.SelectedIndex = -1
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
        Me.stbReport.Clear()
        Me.stbConclusion.Clear()
        Me.cboRadiologyTitleID.SelectedIndex = -1
        Me.cboRadiologyTitleID.SelectedIndex = -1

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
            Me.stbPhoneNo.Text = StringMayBeEnteredIn(row, "Phone")
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
            totalRadiologyRequests = IntegerMayBeEnteredIn(row, "TotalRadiologyRequests")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            Me.priorityID = GetLookupDataID(LookupObjects.Priority, StringEnteredIn(row, "PriorityID"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRadiologist.Text = oStaff.GetCurrentStaffFullName

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
        Me.GetRadiologyDetails()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub GetRadiologyDetails()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetControls()

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim examCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboExamFullName))

            If String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(examCode) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim items As DataTable = oItems.GetItem(visitNo, examCode, oItemCategoryID.Radiology).Tables("Items")
            If Items Is Nothing OrElse Items.Rows.Count < 1 Then Return
            Dim row As DataRow = Items.Rows(0)

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

        'Dim oRadiologyReports As New SyncSoft.SQLDb.RadiologyReports()
        'Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        'Try
        '    Me.Cursor = Cursors.WaitCursor()

        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

        '    With oRadiologyReports
        '        .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
        '        .ItemCode = SubstringEnteredIn(Me.cboExamFullName, "Radiology Examination!")
        '        .ItemCategoryID = oItemCategoryID.Radiology
        '    End With

        '    DisplayMessage(oRadiologyReports.Delete())
        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '    ResetControlsIn(Me)
        '    Me.CallOnKeyEdit()

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default()

        'End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oRadiologyReports As New SyncSoft.SQLDb.RadiologyReports()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Radiology Examination!")

            Dim dataSource As DataTable = oRadiologyReports.GetRadiologyReports(visitNo, examCode, oItemCategoryID.Radiology).Tables("RadiologyReports")
            Me.DisplayData(dataSource)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim message As String
        Dim oStaff As New SyncSoft.SQLDb.Staff()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim lItems As New List(Of DBConnect)
        Dim oVariousOptions As New VariousOptions()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oRadiologyReports As New SyncSoft.SQLDb.RadiologyReports()
            Dim lRadiologyReports As New List(Of DBConnect)

            Dim radiologist As String
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim examCode As String = SubstringEnteredIn(Me.cboExamFullName, "Radiology Examination!")

            With oRadiologyReports

                .VisitNo = visitNo
                .ItemCode = examCode
                .ItemCategoryID = oItemCategoryID.Radiology
                .ExamDateTime = DateTimeEnteredIn(Me.dtpExamDateTime, "Exam Date Time!")
                .Indication = StringEnteredIn(Me.stbIndication, "Indication!")
                radiologist = SubstringEnteredIn(Me.cboRadiologist, "Radiologist (Staff)!")
                .Radiologist = radiologist
                .RadiologyTitleID = StringValueEnteredIn(Me.cboRadiologyTitleID, "Radiology Title!")
                .Report = StringEnteredIn(Me.stbReport, "Report!")
                .Conclusion = StringEnteredIn(Me.stbConclusion, "Conclusion!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(radiologist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictRadiologistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The Radiologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The Radiologist (Staff) you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The Radiologist (Staff) you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lRadiologyReports.Add(oRadiologyReports)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lservicePoints As New List(Of String)
            Dim oServicePoint As New LookupDataID.ServicePointID()
            lservicePoints.Add(oServicePoint.Doctor())
            Dim lWaitingPatient As New List(Of DBConnect)



            ''''make queue
            lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Radiology(), Me.priorityID, lservicePoints)
            transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
                            .ItemCategoryID = oItemCategoryID.Radiology
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
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Radiology)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Radiology)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = examName
                                .BenefitCode = oBenefitCodes.Radiology
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = "Radiology examination, done to Patient No: " + patientNo
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
                    transactions.Add(New TransactionList(Of DBConnect)(lRadiologyReports, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))

                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintExamReportOnSaving.Checked Then Me.PrintRadiology()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadRadiologyRequests(visitNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If GetShortDate(DateMayBeEnteredIn(Me.dtpExamDateTime)) >= GetShortDate(Today.AddHours(-12)) AndAlso
                        Not String.IsNullOrEmpty(doctorStaffNo) Then
                        Using oAlerts As New SyncSoft.SQLDb.Alerts()
                            With oAlerts

                                .AlertTypeID = oAlertTypeID.RadiologyReports
                                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo))
                                .StaffNo = doctorStaffNo
                                .Notes = (totalRadiologyRequests - radiologyRequestsCount).ToString() + " of " + totalRadiologyRequests.ToString() + " Done"
                                .LoginID = CurrentUser.LoginID

                                .Save()

                            End With
                        End Using
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.SMSNotificationAtRadiology Then
                        If stbPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhoneNo.Text) Then
                            Dim oPatients As New SyncSoft.SQLDb.Patients()
                            oPatients.GetPatient(patientNo)
                            Dim recipients As String = stbPhoneNo.Text
                            Dim productOwner As String = AppData.ProductOwner
                            Dim txtmessage As String = ("Hi" + " " + oPatients.FirstName.ToString + " " + " Your Radiology Report is done check with DR." + " " + stbPrimaryDoctor.Text + " " + "at" + " " + (productOwner) + " " +
                            "- Via ClinicMaster")
                            SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanRadiology)

                        End If

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lRadiologyReports, Action.Update, "RadiologyReports"))
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

#Region " Radiology Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintRadiology()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintRadiology()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetRadiologyPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docRadiology
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docRadiology.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docRadiology_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docRadiology.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Radiology Report".ToUpper()

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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
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

                If radiologyParagraphs Is Nothing Then Return

                Do While radiologyParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(radiologyParagraphs(1), PrintParagraps)
                    radiologyParagraphs.Remove(1)

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
                        radiologyParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (radiologyParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetRadiologyPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        radiologyParagraphs = New Collection

        Try

            '''''''''''''''EXAMINATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examTitle As New System.Text.StringBuilder(String.Empty)
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append("EXAMINATION: " + SubstringLeft(StringMayBeEnteredIn(Me.cboExamFullName)))
            examTitle.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examTitle.ToString()))

            '''''''''''''''EXAMINATION DATE'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim examinationDate As New System.Text.StringBuilder(String.Empty)
            examinationDate.Append("EXAMINATION DATE & TIME: " + (StringMayBeEnteredIn(Me.dtpExamDateTime)))
            examinationDate.Append(ControlChars.NewLine)
            examTitle.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, examinationDate.ToString()))

            '''''''''''''''INDICATION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim indicationTitle As New System.Text.StringBuilder(String.Empty)
            indicationTitle.Append("INDICATION ")
            indicationTitle.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, indicationTitle.ToString()))

            Dim indicationBody As New System.Text.StringBuilder(String.Empty)
            indicationBody.Append(StringMayBeEnteredIn(Me.stbIndication))
            indicationBody.Append(ControlChars.NewLine)
            indicationBody.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, indicationBody.ToString()))

            '''''''''''''''REPORT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim reportTitle As New System.Text.StringBuilder(String.Empty)
            reportTitle.Append("REPORT ")
            reportTitle.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, reportTitle.ToString()))

            Dim reportBody As New System.Text.StringBuilder(String.Empty)
            reportBody.Append(StringMayBeEnteredIn(Me.stbReport))
            reportBody.Append(ControlChars.NewLine)
            reportBody.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, reportBody.ToString()))


            '''''''''''''''CONCLUSION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim conclusionTitle As New System.Text.StringBuilder(String.Empty)
            conclusionTitle.Append("CONCLUSION ")
            conclusionTitle.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyBoldFont, conclusionTitle.ToString()))

            Dim conclusionBody As New System.Text.StringBuilder(String.Empty)
            conclusionBody.Append(StringMayBeEnteredIn(Me.stbConclusion))
            conclusionBody.Append(ControlChars.NewLine)
            conclusionBody.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(bodyNormalFont, conclusionBody.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            Dim radiologist As String = SubstringLeft(StringMayBeEnteredIn(Me.cboRadiologist))
            Dim radiologyTitle As String = StringMayBeEnteredIn(Me.cboRadiologyTitleID)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(FixDataLength(radiologist, footerLEN))
            footerData.Append(ControlChars.NewLine)
            footerData.Append(radiologyTitle.ToUpper())
            footerData.Append(ControlChars.NewLine)

            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) + _
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            radiologyParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        'Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.btnLoadProcessingRadiology.Enabled = False
        Me.btnPrint.Visible = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlVisitNo)
        Me.chkPrintExamReportOnSaving.Visible = False
        Me.chkPrintExamReportOnSaving.Checked = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        'Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.btnLoadProcessingRadiology.Enabled = True
        Me.btnPrint.Visible = True

        Me.dtpExamDateTime.MaxDate = Today.AddDays(1)

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlVisitNo)

        Me.chkPrintExamReportOnSaving.Visible = True
        Me.chkPrintExamReportOnSaving.Checked = True

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