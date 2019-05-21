
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Collections.Generic
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports SyncSoft.Common.Structures

Imports System.Drawing.Printing
Imports System.Net.NetworkInformation

Public Class frmVisits

#Region " Fields "

    Private defaultKeyNo As String = String.Empty
    Private visitsKeyNo As ItemsKeyNo
    Private oCurrentVisit As CurrentVisit

    Private Const _CashCustomer As String = "Cash Customer"

    Private billCustomers As DataTable
    Private tipFeeWords As New ToolTip()
    Private tipCoPayValueWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipMemberLimitBalanceWords As New ToolTip()
    Private allowOnlyListedMember As Boolean
    Private captureMemberCardNo As Boolean
    Private captureClaimReferenceNo As Boolean
    Private packagestatus As Boolean = False
    Private companyNo As String = Nothing
    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private oVariousOptions As New VariousOptions()
    Private tipCashAccountBalanceWords As New ToolTip()
    Private smartLocationID As Integer = 2
    Private genderID As String
    Private tribeName As String
    Private villageName As String

    Private bioDataParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private WithEvents docBarcodes As New PrintDocument()
    Private WithEvents docBioData As New PrintDocument()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
#End Region

#Region " Validations "

    Private Sub dtpVisitDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpVisitDate.Validating

        Dim errorMSG As String = "Visit date can't be before join date!"

        Try

            Dim joinDate As Date = DateMayBeEnteredIn(Me.stbJoinDate)
            Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate)

            If visitDate = AppData.NullDateValue Then Return

            If visitDate < joinDate Then
                ErrProvider.SetError(Me.dtpVisitDate, errorMSG)
                Me.dtpVisitDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpVisitDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVisitStatusID As New LookupDataID.VisitStatusID()

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dtpVisitDate.MaxDate = Today

            Me.LoadServices()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDoctorSpecialtyID, LookupObjects.DoctorSpecialty, False)
            LoadLookupDataCombo(Me.cboVisitCategoryID, LookupObjects.VisitCategory, False)
            LoadLookupDataCombo(Me.cboVisitStatusID, LookupObjects.VisitStatus, False)
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboCoPayTypeID, LookupObjects.CoPayType, False)
            LoadLookupDataCombo(Me.cboVisitPriority, LookupObjects.Priority, True)
            LoadLookupDataCombo(Me.cboCommunityID, LookupObjects.Community, True)
            Me.cboVisitStatusID.SelectedValue = oVisitStatusID.Doctor
            Me.LoadPackages()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.HideAccessCashServicesAtVisits Then
                Me.chkAccessCashServices.Visible = False
            Else : Me.chkAccessCashServices.Visible = True
            End If

            If oVariousOptions.EnableVisitDate Then
                Me.dtpVisitDate.Enabled = True
                Me.dtpVisitDate.Value = Today
            Else

                Me.dtpVisitDate.Checked = True
                Me.dtpVisitDate.Value = Today
                Me.dtpVisitDate.Enabled = False
            End If



            If Not oVariousOptions.AllowPrintingForm5 Then
                Me.ChkPrintFormFive.Visible = False
                Me.btnPrintForm5.Visible = False

            Else
                Me.ChkPrintFormFive.Visible = True
                Me.btnPrintForm5.Visible = True
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oCurrentVisit IsNot Nothing AndAlso Not String.IsNullOrEmpty(oCurrentVisit.VisitNo) Then

                Me.ShowPatientDetails(oCurrentVisit.PatientNo)
                Me.ProcessTabKey(True)
                Me.DetailBillClient()

                Me.dtpVisitDate.Value = oCurrentVisit.VisitDate
                Me.dtpVisitDate.Checked = True
                Me.cboDoctorSpecialtyID.SelectedValue = oCurrentVisit.DoctorSpecialtyID
                Me.cboStaffNo.Text = oCurrentVisit.StaffNo
                Me.cboVisitCategoryID.SelectedValue = oCurrentVisit.VisitCategoryID
                Me.stbReferredBy.Text = oCurrentVisit.ReferredBy
                Me.cboServiceCode.SelectedValue = oCurrentVisit.ServiceCode
                Me.stbMemberCardNo.Text = oCurrentVisit.MemberCardNo
                Me.stbMainMemberName.Text = oCurrentVisit.MainMemberName

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.dtpVisitDate.Enabled = False
                Me.cboDoctorSpecialtyID.Enabled = False
                Me.cboStaffNo.Enabled = False
                Me.cboVisitCategoryID.Enabled = False
                Me.stbReferredBy.ReadOnly = True
                Me.cboServiceCode.Enabled = False
                Me.stbMemberCardNo.Enabled = False
                Me.stbMainMemberName.Enabled = False

                Me.btnFindByFingerprint.Enabled = False
                Me.btnViewTodayAppointments.Enabled = False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf Not String.IsNullOrEmpty(defaultKeyNo) AndAlso visitsKeyNo = ItemsKeyNo.PatientNo Then

                Me.ShowPatientDetails(defaultKeyNo)

                Me.stbPatientNo.ReadOnly = True
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)

            ElseIf Not String.IsNullOrEmpty(defaultKeyNo) AndAlso visitsKeyNo = ItemsKeyNo.VisitNo Then

                Me.stbVisitNo.Text = FormatText(defaultKeyNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.ProcessTabKey(True)
                Me.Search(defaultKeyNo)

            Else : Me.stbVisitNo.ReadOnly = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    

    Private Sub frmVisits_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim message As String = "Current visit record is not saved." + ControlChars.NewLine + "Just close anyway?"
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub SetSmartCardPatientAuthorized()

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate, Today)
            Dim smartCardApplicable As Boolean = oSmartCardAuthorisations.IsSmartCardApplicable(billModesID, billNo)

            If smartCardApplicable Then
                Dim authorized As Boolean = IsSmartCardPatientAuthorized(patientNo, billModesID, billNo, visitDate)
                If authorized Then
                    Me.chkSmartCardApplicable.Enabled = authorized
                Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                End If

            Else : Me.chkSmartCardApplicable.Enabled = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.chkSmartCardApplicable.Enabled = False
            Return
        End Try

    End Sub

    Private Sub SetAccessCashServices()

        Try
            Dim oAccessCashServices As New SyncSoft.SQLDb.AccessedCashServices()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim accessedCashServicesApplicable As Boolean = oAccessCashServices.IsAccessedCashServicesAuthorized(visitNo)
            If accessedCashServicesApplicable Then
                Me.chkAccessCashServices.Checked = True
            Else : Me.chkAccessCashServices.Checked = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.chkAccessCashServices.Checked = False
            Return
        End Try

    End Sub

    Private Sub dtpVisitDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpVisitDate.ValueChanged
        Me.SetSmartCardPatientAuthorized()
        Me.SetAccessCashServices()
    End Sub

    Private Sub btnFindPatientNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindPatientNo.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim fFindObject As New frmFindObject(ObjectName.PatientNo)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim patientNo As String = RevertText(fFindObject.GetPatientNo())
                Me.stbPatientNo.Text = patientNo
                Me.ShowPatientDetails(patientNo)
            End If

        Catch eX As Exception
            ErrorMessage(eX)
            Me.btnFindPatientNo.PerformClick()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbVisitNo.Focus()
    End Sub

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

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetDefaultVisitCategory()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.VisitCategory) Then
                Me.cboVisitCategoryID.SelectedValue = GetLookupDataID(LookupObjects.VisitCategory, InitOptions.VisitCategory)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadStaff(ByVal doctorSpecialtyID As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''
            Me.cboStaffNo.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''

            ' Load all from Staff
            Dim staff As DataTable = oStaff.GetStaffByDoctorSpecialty(oStaffTitleID.Doctor, doctorSpecialtyID).Tables("Staff")

            If oVariousOptions.RestrictSelectionOfOnlyLoggedInDoctors Then
                staff = oStaff.GetLoggedInStaffByDoctorSpecialty(oStaffTitleID.Doctor, doctorSpecialtyID).Tables("Staff")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            Me.cboStaffNo.Items.Insert(0, String.Empty)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPackageToBillServices(ByVal packageNo As String)

        Dim oPackagesEXt As New SyncSoft.SQLDb.PackagesEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboServiceCode.Items.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Load all from Staff
            Dim packagesEXt As DataTable = oPackagesEXt.GetPackageServices(packageNo).Tables("PackagesEXT")

            Me.cboServiceCode.Sorted = False
            Me.cboServiceCode.DataSource = packagesEXt
            Me.cboServiceCode.DisplayMember = "ServiceName"
            Me.cboServiceCode.ValueMember = "ServiceCode"
            'Me.cboStaffNo.Items.Insert(0, String.Empty)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPackages()

        Dim oPackages As New SyncSoft.SQLDb.Packages()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Packages
            If oVariousOptions.EnablePackages Then
                Dim packageName As DataTable = oPackages.GetPackageName.Tables("Packages")
                LoadComboData(Me.cboPackageName, packageName, "PackageFullName")
                Me.cboPackageName.Items.Insert(0, "")
            Else : Me.cboPackageName.Enabled = False
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServicePointID As New LookupDataID.ServicePointID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from services
            Dim services As DataTable = oServices.GetServicesAtServicePoint(oServicePointID.Visit).Tables("Services")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboServiceCode.Sorted = False
            Me.cboServiceCode.DataSource = services
            Me.cboServiceCode.DisplayMember = "ServiceName"
            Me.cboServiceCode.ValueMember = "ServiceCode"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextVisitNo(ByVal patientNo As String)

        Try

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Visits", "VisitNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim visitID As String = oVisits.GetNextVisitID(patientNo).ToString()
            visitID = visitID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbVisitNo.Text = FormatText(patientNo + visitID.Trim(), "Visits", "VisitNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub frmVisits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.lblAgeString.Text = String.Empty
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbPhone.Clear()
        Me.stbLastVisitDate.Clear()
        Me.stbTotalVisits.Clear()
        Me.cboBillModesID.SelectedIndex = -1
        Me.cboBillModesID.SelectedIndex = -1
        Me.cboBillNo.Text = String.Empty
        Me.ResetBillControls()
        Me.stbCombination.Clear()
        Me.nbxMemberLimitBalance.Value = String.Empty
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.spbPhoto.Image = Nothing
        Me.tipFeeWords.RemoveAll()
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.tipMemberLimitBalanceWords.RemoveAll()
        Me.oCrossMatchTemplate.Fingerprint = Nothing
        Me.oDigitalPersonaTemplate.Template = Nothing
        Me.chkFingerprintCaptured.Checked = False
        Me.btnEditPatient.Enabled = False
        Me.chkAccessCashServices.Checked = False
        Me.chkHasPackage.Checked = False
        packagestatus = False
        companyNo = Nothing
        genderID = Nothing
        villageName = Nothing
        tribeName = Nothing

    End Sub

    Private Sub stbPatientNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPatientNo.Leave

        Try

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            ErrProvider.Clear()
            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowPatientDetails(patientNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
        Dim oAccessCashServices As New SyncSoft.SQLDb.AccessedCashServices()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"
        Dim debitBalanceErrorMSG As String = "This Patient has a debt!! Debit balance should be cleared first!"
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()
            Me.tipCashAccountBalanceWords.RemoveAll()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            tribeName = StringMayBeEnteredIn(row, "Tribe")
            villageName = StringMayBeEnteredIn(row, "Address")
            Dim defaultBillModesID As String = StringEnteredIn(row, "DefaultBillModesID")
            Dim enforceDefaultBillNo As Boolean = BooleanEnteredIn(row, "EnforceDefaultBillNo")
            Dim smartCardApplicable As Boolean = BooleanMayBeEnteredIn(row, "SmartCardApplicable")

            If oCurrentVisit IsNot Nothing AndAlso Not String.IsNullOrEmpty(oCurrentVisit.VisitNo) Then
                Me.stbVisitNo.Text = FormatText(oCurrentVisit.VisitNo, "Visits", "VisitNo")
                Me.cboBillModesID.SelectedValue = oCurrentVisit.BillModesID
                Me.cboBillNo.Text = oCurrentVisit.BillNo
                Me.stbMemberCardNo.Text = oCurrentVisit.MemberCardNo
                Me.stbMainMemberName.Text = oCurrentVisit.MainMemberName
                Me.GetCurrentMemberPremiumBalance(oCurrentVisit.MemberCardNo)
            Else
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.SetNextVisitNo(patientNo)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim defaultMemberCardNo As String = StringMayBeEnteredIn(row, "DefaultMemberCardNo")
                Me.cboBillModesID.SelectedValue = defaultBillModesID
                Me.cboBillNo.Text = StringEnteredIn(row, "DefaultBillNo")
                Me.stbMemberCardNo.Text = defaultMemberCardNo
                Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "DefaultMainMemberName")
                Me.GetCurrentMemberPremiumBalance(defaultMemberCardNo)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Me.stbBillCustomerName.Text = StringEnteredIn(row, "BillCustomerName")
            Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            Me.chkSmartCardApplicable.Checked = smartCardApplicable
            Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(row, "DebitCashAccountBalance")
            Me.nbxCashAccountBalance.Value = FormatNumber(cashAccountBalance, AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(cashAccountBalance))
            Me.stbCombination.Text = StringMayBeEnteredIn(row, "Combination")

            companyNo = StringMayBeEnteredIn(row, "CompanyNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            allowOnlyListedMember = BooleanMayBeEnteredIn(row, "AllowOnlyListedMember")
            captureMemberCardNo = BooleanMayBeEnteredIn(row, "CaptureMemberCardNo")
            captureClaimReferenceNo = BooleanMayBeEnteredIn(row, "CaptureClaimReferenceNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

            If cashAccountBalance < 0 Then
                ErrProvider.SetError(Me.nbxCashAccountBalance, debitBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxCashAccountBalance, String.Empty)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If enforceDefaultBillNo Then
                Me.cboBillModesID.Enabled = False
                Me.cboBillNo.Enabled = False
            Else
                Me.cboBillModesID.Enabled = True
                If Not defaultBillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then Me.cboBillNo.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If smartCardApplicable Then
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                Dim billNo As String = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
                Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate, Today)
                Dim authorized As Boolean = IsSmartCardPatientAuthorized(patientNo, billModesID, billNo, visitDate)
                If authorized Then
                    Me.chkSmartCardApplicable.Enabled = authorized
                Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                End If

            Else : Me.chkSmartCardApplicable.Enabled = False
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim avisitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate, Today)
            Dim VisitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim accessedCashServicesApplicable As Boolean = oAccessCashServices.IsAccessedCashServicesAuthorized(VisitNo)
            If accessedCashServicesApplicable Then
                Me.chkAccessCashServices.Checked = True
            Else : Me.chkAccessCashServices.Checked = False
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pt As EnumerableRowCollection(Of DataRow) = patients.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fingerprint As Byte() = (From data In pt Select data.Field(Of Byte())("Fingerprint")).First()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Me.oCrossMatchTemplate.Fingerprint = fingerprint
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Me.oDigitalPersonaTemplate.Template = GetDigitalPersonaTemplate(fingerprint)
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnEditPatient.Enabled = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave
        Me.stbVisitNo.Text = FormatText(Me.stbVisitNo.Text.Trim(), "Visits", "VisitNo")
    End Sub

    Private Sub cbodoctorSpecialtyID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDoctorSpecialtyID.SelectedIndexChanged

        Try

            Dim doctorSpecialtyID As String = StringValueMayBeEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
            ErrProvider.Clear()
            If String.IsNullOrEmpty(doctorSpecialtyID) Then Return

            Me.LoadStaff(doctorSpecialtyID)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub cboStaffNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStaffNo.SelectedIndexChanged
        Me.ResetServicesControls()
    End Sub

    Private Sub ResetServicesControls()

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        If cboServiceCode.SelectedValue Is Nothing OrElse cboServiceCode.SelectedValue.ToString() = String.Empty Then Return

        Me.cboServiceCode.SelectedIndex = -1
        Me.cboServiceCode.SelectedIndex = -1

        Me.nbxToBillServiceFee.Value = String.Empty

    End Sub

    Private Sub cboServiceCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiceCode.SelectedIndexChanged

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.nbxToBillServiceFee.Enabled = True
        If (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) Then Me.LoadPackageAvailability()

    End Sub

    Private Sub cboServiceCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServiceCode.Leave

        Dim oBillModesID As New LookupDataID.BillModesID()
        Try
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            Dim serviceCode As String = StringValueMayBeEnteredIn(Me.cboServiceCode)
            If String.IsNullOrEmpty(serviceCode) Then Return
            Me.ShowToBillServiceFee(serviceCode)

            Select Case billModesID.ToUpper()
                Case oBillModesID.Cash.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case oBillModesID.Account.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If Convert.ToDouble(nbxCoPayPercent.Value) > 0 Then
                        Dim CoPayAmount As Double = Me.nbxToBillServiceFee.GetDouble() * Me.nbxCoPayPercent.GetDouble() / 100
                        Dim errorMSG As String = "Client Should Be Reminded To Pay CoPay Amount " + FormatNumber(CoPayAmount, AppData.DecimalPlaces).ToString + " At Cashier!"
                        ErrProvider.Clear()
                        ErrProvider.SetError(Me.nbxCoPayPercent, errorMSG)
                        Me.nbxCoPayPercent.Focus()
                    ElseIf Convert.ToDouble(nbxCoPayValue.Value) > 0 Then
                        Dim CoPayAmount As Double = Convert.ToDouble(nbxCoPayValue.Value)
                        Dim errorMSG As String = "Client Should Be Reminded To Pay CoPay Amount " + FormatNumber(CoPayAmount, AppData.DecimalPlaces).ToString + " At Cashier!"
                        ErrProvider.Clear()
                        ErrProvider.SetError(Me.nbxCoPayValue, errorMSG)
                        Me.nbxCoPayValue.Focus()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case oBillModesID.Insurance.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
        End Try

    End Sub

    Private Sub cboVisitCategoryID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVisitCategoryID.SelectedIndexChanged

        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oLookupData As New LookupData()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()

        ErrProvider.Clear()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Dim visitCategoryID As String = StringValueMayBeEnteredIn(Me.cboVisitCategoryID)
        If String.IsNullOrEmpty(visitCategoryID) Then Return

        If Not visitCategoryID.ToUpper().Equals(oVisitCategoryID.Refferal.ToUpper()) Then
            Me.stbReferredBy.Clear()
            Me.stbReferredBy.ReadOnly = True
        Else : Me.stbReferredBy.ReadOnly = False
        End If

        If visitCategoryID.ToUpper().Equals(oVisitCategoryID.Refill.ToUpper()) Then
            Me.cboVisitStatusID.SelectedValue = oVisitStatusID.Completed
        Else : Me.cboVisitStatusID.SelectedValue = oVisitStatusID.Doctor
        End If

    End Sub

    Private Sub cboBillModesID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillModesID.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                If String.IsNullOrEmpty(billModesID) Then Return
                Me.LoadBillClients(billModesID)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.LoadBillClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillControls()

        Me.cboBillNo.DataSource = Nothing
        Me.cboBillNo.Items.Clear()
        Me.cboBillNo.Text = String.Empty
        Me.ResetBillControls()

    End Sub

    Private Sub ResetBillControls()

        allowOnlyListedMember = False
        captureMemberCardNo = False
        captureClaimReferenceNo = False

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            Me.stbMemberCardNo.Clear()
            Me.stbMainMemberName.Clear()
            Me.stbClaimReferenceNo.Clear()
        End If

        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceNo.Clear()
        Me.stbInsuranceName.Clear()
        Me.ResetAssociatedBillControls(False)
        Me.chkSmartCardApplicable.Checked = False
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()

    End Sub

    Private Sub GetCurrentMemberPremiumBalance(mainMemberNo As String)


        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim remainingAmount As Decimal = GetMemberPremiumUsageBalance(mainMemberNo)
            Me.nbxMemberLimitBalance.Text = FormatNumber(remainingAmount, AppData.DecimalPlaces)

            Me.tipMemberLimitBalanceWords.SetToolTip(Me.nbxMemberLimitBalance, NumberToWords(remainingAmount))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)


        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableSetAssociatedBillCustomer()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim associatedBillCustomer As String = StringMayBeEnteredIn(Me.cboAssociatedBillNo)
            If Not oVariousOptions.EnableSetAssociatedBillCustomer AndAlso Not String.IsNullOrEmpty(associatedBillCustomer) Then
                Me.cboAssociatedBillNo.Enabled = False
            Else : Me.cboAssociatedBillNo.Enabled = True
            End If

        Catch ex As Exception
            Me.cboAssociatedBillNo.Enabled = True
        End Try

    End Sub

    Private Sub ResetAssociatedBillControls(ByVal state As Boolean)

        If Not state Then Me.cboAssociatedBillNo.Items.Clear()
        Me.lblAssociatedBillNo.Enabled = state
        Me.cboAssociatedBillNo.Enabled = state

    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oVariousOptions As New VariousOptions()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadCASHCustomer()
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = False
                    Me.chkAccessCashServices.Checked = False
                    Me.chkAccessCashServices.Enabled = oVariousOptions.EnableAccessCashServices
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillNo, billCustomers, "BillCustomerFullName")
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = True
                    Me.stbMainMemberName.Enabled = True
                    Me.stbClaimReferenceNo.Enabled = True
                    Me.chkAccessCashServices.Checked = False
                    Me.chkAccessCashServices.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Medical Card No"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = True
                    Me.chkAccessCashServices.Checked = False
                    Me.chkAccessCashServices.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub OrganizeBillControls(ByVal billModesID As String)

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = False
                    Me.lblBillNo.Text = "To-Bill Medical Card No"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCASHCustomer()

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = oBillModesID.Cash
            Me.cboBillNo.Text = accountNo
            Me.stbBillCustomerName.Text = _CashCustomer
            Me.stbInsuranceNo.Clear()
            Me.stbInsuranceName.Clear()
            Me.chkSmartCardApplicable.Checked = False
            Me.chkSmartCardApplicable.Enabled = False
            Me.stbMemberCardNo.Clear()
            Me.stbMainMemberName.Clear()
            Me.stbClaimReferenceNo.Clear()
            allowOnlyListedMember = False
            captureMemberCardNo = False
            captureClaimReferenceNo = False
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadAssociatedBillCustomers(accountNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
            Me.cboCoPayTypeID.SelectedValue = oCoPayTypeID.NA
            Me.nbxCoPayPercent.Value = "0".ToString()
            Me.nbxCoPayValue.Value = "0.00".ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadAssociatedBillCustomers(ByVal accountNo As String)

        Dim oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboAssociatedBillNo.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Load all from AssociatedBillCustomers
            Dim associatedBillCustomers As DataTable = oAssociatedBillCustomers.GetAssociatedBillCustomers(accountNo).Tables("AssociatedBillCustomers")

            If associatedBillCustomers IsNot Nothing AndAlso associatedBillCustomers.Rows.Count > 0 Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.ResetAssociatedBillControls(True)
                LoadComboData(Me.cboAssociatedBillNo, associatedBillCustomers, "AssociatedFullBillCustomer")
                Me.cboAssociatedBillNo.Items.Insert(0, String.Empty)

                Me.cboAssociatedBillNo.Text = InitOptions.AssociatedBillCustomer
                Me.EnableSetAssociatedBillCustomer()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else : Me.ResetAssociatedBillControls(False)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillCustomerName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillNo.SelectedIndexChanged, cboBillNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ResetBillControls()
    End Sub

    Private Sub cboBillAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillNo.Leave
        Me.DetailBillClient()
    End Sub

    Private Sub DetailBillClient()

        Dim oVariousOptions As New VariousOptions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Return

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillNo)))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    Me.ResetBillControls()

                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        Dim smartCardApplicable As Boolean = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
                        allowOnlyListedMember = BooleanMayBeEnteredIn(row, "AllowOnlyListedMember")
                        captureMemberCardNo = BooleanMayBeEnteredIn(row, "CaptureMemberCardNo")
                        captureClaimReferenceNo = BooleanMayBeEnteredIn(row, "CaptureClaimReferenceNo")
                        ' companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                        Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                        Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
                        Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "BillCustomerInsurance")
                        Me.chkSmartCardApplicable.Checked = smartCardApplicable
                        Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                        Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                        Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                        Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

                        If smartCardApplicable Then

                            Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate, Today)
                            Dim authorized As Boolean = IsSmartCardPatientAuthorized(patientNo, billModesID, accountNo, visitDate)
                            If authorized Then
                                Me.chkSmartCardApplicable.Enabled = authorized
                            Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                            End If

                        Else : Me.chkSmartCardApplicable.Enabled = False
                        End If

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetBillControls()
                    Dim medicalCardNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
                    If String.IsNullOrEmpty(medicalCardNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(medicalCardNo.ToUpper(), "SchemeMembers", "MedicalCardNo")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)
                    Me.stbMemberCardNo.Text = medicalCardNo.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim smartCardApplicable As Boolean = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
                    Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "CompanyName")
                    Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
                    companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                    Me.chkSmartCardApplicable.Checked = smartCardApplicable
                    Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                    Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                    Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

                    Me.GetCurrentMemberPremiumBalance(medicalCardNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If smartCardApplicable Then
                        Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate, Today)
                        Dim authorized As Boolean = IsSmartCardPatientAuthorized(patientNo, billModesID, medicalCardNo, visitDate)
                        If authorized Then
                            Me.chkSmartCardApplicable.Enabled = authorized
                        Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                        End If

                    Else : Me.chkSmartCardApplicable.Enabled = False
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowToBillServiceFee(ByVal serviceCode As String)

        Dim standardFee As Decimal
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim oServices As New SyncSoft.SQLDb.Services()

            Me.nbxToBillServiceFee.Value = String.Empty
            Me.tipFeeWords.RemoveAll()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                Try
                    Dim items As DataTable = oItems.GetItem(visitNo, serviceCode, oItemCategoryID.Service).Tables("Items")
                    Dim itemsRow As DataRow = items.Rows(0)
                    standardFee = DecimalMayBeEnteredIn(itemsRow, "UnitPrice")
                Catch ex As Exception
                    standardFee = 0
                End Try
            Else

                Dim doctorSpecialtyID As String = StringValueMayBeEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                Dim associatedBillNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAssociatedBillNo)))

                'Check if the doctor has special consultation fee
                If Me.cboStaffNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboStaffNo.Text) Then

                    Try

                        Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "To See Doctor!")
                        standardFee = GetServicesStaffFee(serviceCode, staffNo, billNo, billModesID, associatedBillNo)

                    Catch ex As Exception
                        ErrorMessage(ex)
                        standardFee = GetCustomFee(serviceCode, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
                    End Try

                ElseIf Not String.IsNullOrEmpty(doctorSpecialtyID) Then

                    Try
                        standardFee = GetServicesDrSpecialtyFee(serviceCode, doctorSpecialtyID, billNo, billModesID, associatedBillNo)

                    Catch ex As Exception
                        ErrorMessage(ex)
                        standardFee = GetCustomFee(serviceCode, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
                    End Try

                Else : standardFee = GetCustomFee(serviceCode, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
                End If

            End If

            Me.nbxToBillServiceFee.Value = FormatNumber(standardFee, AppData.DecimalPlaces)
            Me.tipFeeWords.SetToolTip(Me.nbxToBillServiceFee, NumberToWords(standardFee))

            If serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then
                Me.nbxToBillServiceFee.Value = String.Empty
                Me.nbxToBillServiceFee.Enabled = False
            Else
                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
                Me.nbxToBillServiceFee.Enabled = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub nbxToBillServiceFee_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxToBillServiceFee.Leave

        Try

            Dim consultationFee As Decimal = DecimalMayBeEnteredIn(Me.nbxToBillServiceFee, False)
            Me.tipFeeWords.SetToolTip(Me.nbxToBillServiceFee, NumberToWords(consultationFee))

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim doctorSpecialtyID As String = StringMayBeEnteredIn(Me.cboDoctorSpecialtyID)
            ' Dim visitCategoryID As String = StringMayBeEnteredIn(Me.cboVisitCategoryID)
            Dim serviceCode As String = StringMayBeEnteredIn(Me.cboServiceCode)
            Dim billModesID As String = StringMayBeEnteredIn(Me.cboBillModesID)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.cboBillNo)

            'Not String.IsNullOrEmpty(visitCategoryID) OrElse
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' ''If Not String.IsNullOrEmpty(patientNo) OrElse Not String.IsNullOrEmpty(visitNo) OrElse
            ' ''Not String.IsNullOrEmpty(doctorSpecialtyID) OrElse Not String.IsNullOrEmpty(serviceCode) OrElse
            ' ''Not String.IsNullOrEmpty(billModesID) OrElse Not String.IsNullOrEmpty(billAccountNo) Then
            ' ''    If Not hideMessage Then DisplayMessage("Please ensure that current visit record is saved!")
            ' ''    Me.ebnSaveUpdate.Focus()
            ' ''    Me.BringToFront()
            ' ''    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
            ' ''    Return False
            ' ''End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnEditPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditPatient.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            If Not oVariousOptions.EnableSecondPatientForm Then
                Dim fPatients As New frmPatients(patientNo, True)

                fPatients.Edit()
                fPatients.ShowDialog()
            Else
                Dim f2Patients As New frmPatientsTwo(patientNo, True)

                f2Patients.Edit()
                f2Patients.ShowDialog()
            End If

            If oCurrentVisit Is Nothing OrElse String.IsNullOrEmpty(oCurrentVisit.VisitNo) Then Me.ShowPatientDetails(patientNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnViewTodayAppointments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTodayAppointments.Click

        Try

            Me.Cursor = Cursors.WaitCursor()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fTodayAppointments As New frmTodayAppointments(Me.stbPatientNo)
            fTodayAppointments.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oAppointments As New SyncSoft.SQLDb.Appointments()

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim startDate As Date = Today

            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowPatientDetails(patientNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appointments As DataTable = oAppointments.GetAppointments(patientNo, startDate).Tables("Appointments")
            If appointments Is Nothing OrElse appointments.Rows.Count < 1 Then Return

            Dim row As DataRow = appointments.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpVisitDate.Value = startDate
            Me.dtpVisitDate.Checked = True
            Me.cboDoctorSpecialtyID.SelectedValue = StringMayBeEnteredIn(row, "DoctorSpecialtyID")
            Me.cboStaffNo.Text = StringMayBeEnteredIn(row, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientFingerprints As DataTable = GetPatientFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, patientFingerprints, "PatientNo")
                fFingerprintCapture.ShowDialog()

                Dim patientNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(patientNo) Then Return
                Me.ShowPatientDetails(patientNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(patientFingerprints, "PatientNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.ShowPatientDetails(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oVisits.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oVisits.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Me.Search(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub Search(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillControls()

            Dim dataSource As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = dataSource.Rows(0)

            Me.DisplayData(dataSource)

            Me.dtpVisitDate.Checked = True
            Me.stbReferredBy.ReadOnly = True

            Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
            Me.ShowToBillServiceFee(serviceCode)

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Me.OrganizeBillControls(billModesID)

            If oVariousOptions.EnableAccessCashServices Then
                Me.chkAccessCashServices.Enabled = billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper())
            Else : Me.chkAccessCashServices.Enabled = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()
            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                Me.LoadAssociatedBillCustomers(accountNo)
                Me.cboAssociatedBillNo.Text = StringMayBeEnteredIn(row, "AssociatedFullBillCustomer")
                Me.EnableSetAssociatedBillCustomer()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetSmartCardPatientAuthorized()
            Me.SetAccessCashServices()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim ARTCurrentlyOn As New DataTable()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()

        Dim lItems As New List(Of DBConnect)
        Dim lSmartCardItems As New List(Of SmartCardItems)
        Dim lItemsCASH As New List(Of DBConnect)
        Dim lVisits As New List(Of DBConnect)
        Dim lpackages As New List(Of DBConnect)
        Dim lpackageVisits As New List(Of DBConnect)
        Dim lpackageDetails As New List(Of DBConnect)
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oARTStatusID As New LookupDataID.ARTStatusID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oYesNoID As New LookupDataID.YesNoID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()
        Dim oGenderID As New LookupDataID.GenderID()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oVariousOptions As New VariousOptions()
        Dim oSmartCardMembers As New SmartCardMembers()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Dim oPriorityID As New LookupDataID.PriorityID
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "PatientNo!"))


        Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)


            Select Case billModesID.ToUpper()
                Case oBillModesID.Account.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Convert.ToDouble(nbxCoPayPercent.Value) > 0 Then
                        ErrProvider.SetError(Me.nbxCoPayPercent, String.Empty)

                    ElseIf Convert.ToDouble(nbxCoPayValue.Value) > 0 Then
                        ErrProvider.SetError(Me.nbxCoPayValue, String.Empty)
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case oBillModesID.Insurance.ToUpper()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oVisits

                .PatientNo = patientNo
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .VisitDate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                .DoctorSpecialtyID = StringValueEnteredIn(Me.cboDoctorSpecialtyID, "Doctor Specialty!")
                If Me.cboStaffNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboStaffNo.Text) Then
                    .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "To See Doctor!")
                Else : .StaffNo = String.Empty
                End If
                .VisitCategoryID = StringValueEnteredIn(Me.cboVisitCategoryID, "Visit Category!")
                If .VisitCategoryID.ToUpper().Equals(oVisitCategoryID.Refferal.ToUpper()) Then
                    .ReferredBy = StringEnteredIn(Me.stbReferredBy, "Referred By!")
                Else : .ReferredBy = StringMayBeEnteredIn(Me.stbReferredBy)
                End If

                .BillModesID = StringValueEnteredIn(Me.cboBillModesID, "Bill Mode!")
                .BillNo = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
                .InsuranceNo = StringMayBeEnteredIn(Me.stbInsuranceNo)

                If (Me.cboAssociatedBillNo.Text IsNot Nothing AndAlso
                    Not String.IsNullOrEmpty(Me.cboAssociatedBillNo.Text)) OrElse Me.cboAssociatedBillNo.Items.Count > 0 Then
                    .AssociatedBillNo = RevertText(SubstringEnteredIn(Me.cboAssociatedBillNo, "Associated Bill Customer!"))
                Else : .AssociatedBillNo = String.Empty
                End If

                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso captureMemberCardNo Then
                    .MemberCardNo = StringEnteredIn(Me.stbMemberCardNo, "Member Card No!")
                Else : .MemberCardNo = StringMayBeEnteredIn(Me.stbMemberCardNo)
                End If
                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso oVariousOptions.ForceAccountMainMemberName Then
                    .MainMemberName = StringEnteredIn(Me.stbMainMemberName, "Main Member Name!")
                Else : .MainMemberName = StringMayBeEnteredIn(Me.stbMainMemberName)
                End If
                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso captureClaimReferenceNo Then
                    .ClaimReferenceNo = StringEnteredIn(Me.stbClaimReferenceNo, "Claim Reference No!")
                Else : .ClaimReferenceNo = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
                End If

                .ServiceCode = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")

                ' Check for all possible states that the front desk is capable of authorizing
                If .VisitCategoryID.ToUpper().Equals(oVisitCategoryID.Refill.ToUpper()) AndAlso
                    Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                    Using oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()
                        ARTCurrentlyOn = oARTRegimenDetails.GetARTCurrentlyOn(oVisits.PatientNo, oARTStatusID.On).Tables("ARTCurrentlyOn")
                    End Using
                    If ARTCurrentlyOn.Rows.Count < 1 Then
                        Throw New ArgumentException("This patient has no ART Regimen registered yet or stopped ART." +
                                                    ControlChars.NewLine + "You can't select refill category?")
                    End If
                    .VisitStatusID = oVisitStatusID.Completed
                Else : .VisitStatusID = StringValueEnteredIn(Me.cboVisitStatusID, "Visit Status!")
                End If

                .AccessCashServices = Me.chkAccessCashServices.Checked
                .FingerprintVerified = Me.chkFingerprintCaptured.Checked
                .CoPayTypeID = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
                .CoPayPercent = Me.nbxCoPayPercent.GetSingle()
                .CoPayValue = Me.nbxCoPayValue.GetDecimal(False)
                .VisitsPriorityID = StringValueEnteredIn(Me.cboVisitPriority, "VisitsPriorityID!")
                .SmartCardApplicable = Me.chkSmartCardApplicable.Checked
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(.MainMemberName) AndAlso Not String.IsNullOrEmpty(.InsuranceNo) AndAlso
                    .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then

                    message = "You have not entered main member name for this member on To-Bill Insurance Name: " +
                       StringMayBeEnteredIn(Me.stbInsuranceName) + "." + ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lVisits.Add(oVisits)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Packages check

            If (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) AndAlso Me.chkHasPackage.Checked = False Then

                Dim opackage As New SyncSoft.SQLDb.Items()
                Dim Opackages As New SyncSoft.SQLDb.Packages()
                Dim oAttachPackages As New SyncSoft.SQLDb.AttachPackage()
                Dim PackageNo As String = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))
                Dim packages As DataTable = Opackages.GetPackages(PackageNo).Tables("Packages")
                If packages.Rows.Count < 1 Then Return
                Dim packageRow As DataRow = packages.Rows(0)
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(packageRow, "UnitPrice")
                Dim PackageName As String = StringMayBeEnteredIn(packageRow, "PackageName")

                With opackage
                    .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                    .ItemCode = PackageNo
                    .Quantity = 1
                    .UnitPrice = unitPrice
                    .ItemDetails = PackageName
                    .LastUpdate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                    .ItemCategoryID = oItemCategoryID.Packages
                    .ItemStatusID = oItemStatusID.Pending
                    .PayStatusID = oPayStatusID.NotPaid
                    .LoginID = CurrentUser.LoginID


                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lpackages.Add(opackage)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                With oAttachPackages

                    .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                    .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "PatientNo!"))
                    .PackageNo = PackageNo
                    .PackageVisitNo = GetNextPackageVisit()
                    .Details = "Attached at Visits"
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lpackageDetails.Add(oAttachPackages)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) Then

                Dim opackageVisits As New SyncSoft.SQLDb.PackageVisits()


                With opackageVisits
                    .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                    .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Visit No!"))
                    .PackageNo = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))

                End With
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lpackageVisits.Add(opackageVisits)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If
            'End of packages


            Dim services As DataTable = oServices.GetServices(oVisits.ServiceCode).Tables("Services")
            Dim serviceName As String = services.Rows(0).Item("ServiceName").ToString()
            Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso
               oVisits.BillNo.ToUpper().Equals(GetLookupDataDes(oBillModesID.Cash).ToUpper()) Then
                Me.cboBillModesID.Focus()
                Throw New ArgumentException("To-Bill Mode for Cash Customer can’t be Account!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then ValidateBillCustomerInsuranceDirect(oVisits.BillNo)
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then IsBillCustomerActive(oVisits.BillNo)
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then IsBillCustomerActive(oVisits.InsuranceNo)
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then IsBillCustomerMemberActive(oVisits.MemberCardNo, oVisits.BillNo)
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso allowOnlyListedMember Then
                IsBillCustomerMemberListed(oVisits.MemberCardNo, oVisits.BillNo)
            End If
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then IsSchemeMemberActive(oVisits.BillNo)
            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then IsInsuranceFingerprintVerified(oVisits.PatientNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.IncorporateFingerprintCapture Then
                        If Not Me.chkFingerprintCaptured.Checked Then
                            If InitOptions.ForceFingerprintCapture Then
                                Dim age As Integer = IntegerMayBeEnteredIn(Me.stbAge, GetAge(AppData.NullDateValue))
                                If age >= oVariousOptions.FingerprintCaptureAgeLimit Then
                                    message = "You have not enrolled fingerprint for this Patient. " +
                                               "The system does not allow registration of a visit without a Patient's fingerprint captured!"
                                    Throw New ArgumentException(message)
                                Else
                                    message = "You have not enrolled fingerprint for this Patient. " +
                                              "The system has noted that this patient is below the set fingerprint capture age limit of " +
                                              oVariousOptions.FingerprintCaptureAgeLimit.ToString() + " year(s). " +
                                              "However, it’s recommended that you enroll fingerprint through Patients edit form for verification purposes. " +
                                         ControlChars.NewLine + "Are you sure you want to save?"
                                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                                End If
                            Else
                                message = "You have not enrolled fingerprint for this Patient. " +
                                            "It’s recommended that you enroll fingerprint through Patients edit form for verification purposes. " +
                                            ControlChars.NewLine + "Are you sure you want to save?"
                                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                            End If
                        End If
                    End If



                    If oVariousOptions.EnableMemberLimitBalanceTracking AndAlso oVisits.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        Dim serviceFee As Decimal = nbxToBillServiceFee.GetDecimal(False)
                        Dim consumedAmount As Decimal = Me.nbxMemberLimitBalance.GetDecimal(True)
                        If consumedAmount < serviceFee Then
                            message = "This Patient's Premium is Done. " +
                                       "The system does not allow registration of a visit of a Patient who has consumed all their premium!"
                            Throw New ArgumentException(message)
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim visitDate As Date = DateMayBeEnteredIn(Me.stbLastVisitDate)
                    Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")

                    Dim remainingDays As Integer = (Today - visitDate).Days
                    If serviceCode.ToUpper().Equals(oServiceCodes.Review.ToUpper()) And remainingDays > oVariousOptions.VisitReviewDays Then
                        message = "The visit that you want to create is past the maximum Number of days allowed for a review." +
                                    ControlChars.NewLine + "The system is set not to allow Reviews to a patient after " +
                                    oVariousOptions.VisitReviewDays.ToString() + " day(s)."
                        Throw New ArgumentException(message)


                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oPatients.HasInWardAdmission(oVisits.PatientNo) Then
                        message = "The Patient No: " + oVisits.PatientNo + ", is known to have an active admission. " +
                                  ControlChars.NewLine + "You can't register a new visit before discharging previous admission."
                        Throw New ArgumentException(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastVisitDate As Date = DateMayBeEnteredIn(Me.stbLastVisitDate)

                    If lastVisitDate > AppData.NullDateValue AndAlso lastVisitDate > oVisits.VisitDate Then
                        message = "Visit date is before last visit date. " + ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVisits.IsVisitDateSaved(oVisits.PatientNo, oVisits.VisitDate, oVisits.DoctorSpecialtyID) Then
                        If oVariousOptions.AllowCreateMultipleSpecialityVisits Then
                            message = "To-See Doctor Specialty " + GetLookupDataDes(oVisits.DoctorSpecialtyID) +
                                      ", already has a visit on " + FormatDate(oVisits.VisitDate) +
                                      ". If the previous visit is no longer needed, it can be deleted via visits edit sub menu." +
                                       ControlChars.NewLine + "Are you sure you want to save?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                        Else
                            message = "To-See Doctor Specialty " + GetLookupDataDes(oVisits.DoctorSpecialtyID) +
                                      ", already has a visit on " + FormatDate(oVisits.VisitDate) +
                                      ". If the previous visit is no longer needed, it can be deleted via visits edit sub menu. " +
                                      "The system is set not to allow multiple speciaity visits on the same date. " +
                                      "Please contact the administrator if you still need to create this visit."
                            Throw New ArgumentException(message)
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVisits.IsVisitDateSaved(oVisits.PatientNo, oVisits.VisitDate) Then
                        If oVariousOptions.AllowCreateMultipleVisits Then
                            message = "You already have a visit on " + FormatDate(oVisits.VisitDate) + ". " +
                                      "If the previous visit is no longer needed, it can be deleted via visits edit sub menu." +
                                       ControlChars.NewLine + "Are you sure you want to save?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                        Else
                            message = "You already have a visit on " + FormatDate(oVisits.VisitDate) + ". " +
                                      "If the previous visit is no longer needed, it can be deleted via visits edit sub menu. " +
                                      "The system is set not to allow multiple visits on the same date. " +
                                      "Please contact the administrator if you still need to create this visit."
                            Throw New ArgumentException(message)
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) AndAlso
                        oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso
                        oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                        oVisits.AccessCashServices.Equals(True) AndAlso
                        Not oVisits.ServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then
                        message = "Setting Access Cash Services to true, means you are allowing this visit to receive cash services before payment. " +
                                                         ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                        message = "To-Bill Service " + Me.cboServiceCode.Text.ToString() + ", will be billed at this stage. " +
                                   ControlChars.NewLine + "You won’t be able to change it." +
                                   ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    End If


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If InitOptions.ForceVisitBillConfirmation Then
                        If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then

                            message = "All bills for this visit will be sent to " + Me.stbBillCustomerName.Text.Trim() + ". " +
                                      "Please confirm with the patient that this is the correct bill mode. " +
                                       ControlChars.NewLine + "Are you sure you want to save?"

                        ElseIf oVisits.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then

                            message = "All bills for this visit will be sent to " + Me.stbInsuranceName.Text.Trim() + ". " +
                                      "Please confirm with the patient that this is the correct bill mode. " +
                                       ControlChars.NewLine + "Are you sure you want to save?"

                        ElseIf oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso
                                oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                                oVisits.AccessCashServices.Equals(False) And packagestatus.Equals(False) Then

                            message = "All bills for this visit will require cash payment before accessing the service." +
                                          ControlChars.NewLine + "Please confirm with the patient that this is the correct bill mode. " +
                                          ControlChars.NewLine + "Are you sure you want to save?"

                        ElseIf oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso
                         oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                         oVisits.AccessCashServices.Equals(False) And packagestatus.Equals(False) AndAlso
                         (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) Then

                            message = "All bills for this visit will require cash payment before accessing the package." +
                                          ControlChars.NewLine + "Please confirm with the patient that he/she is going to pay for the selected Package. " +
                                          ControlChars.NewLine + "Are you sure you want to save?"


                        ElseIf oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) AndAlso
                            oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                            oVisits.AccessCashServices.Equals(False) And packagestatus.Equals(True) Then

                            message = "All bills for this visit will consume the Patient's Package." +
                                          ControlChars.NewLine + "Please confirm with the patient whether he/she is going to use the " + Me.cboPackageName.Text.Trim() + " Package. " +
                                          ControlChars.NewLine + "Are you sure you want to save?"

                        Else : message = "All bills for this visit will require cash payment. " +
                                          ControlChars.NewLine + "Please confirm with the patient that this is the correct bill mode. " +
                                          ControlChars.NewLine + "Are you sure you want to save?"
                        End If

                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lpackages, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lpackageDetails, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lpackageVisits, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVisits.VisitCategoryID.ToUpper().Equals(oVisitCategoryID.Refill.ToUpper()) Then

                        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
                        Dim lDoctorVisits As New List(Of DBConnect)
                        Dim lRefillItems As New List(Of DBConnect)
                        Dim lRefillItemsEXT As New List(Of DBConnect)
                        Dim lRefillItemsCASH As New List(Of DBConnect)
                        Dim lAlerts As New List(Of DBConnect)
                        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

                        'We need to get drugs picked from ART Regimen Details table and get to pay for drugs

                        Dim staffNo As String = CStr(ARTCurrentlyOn.Rows(0).Item("StaffNo"))

                        With oDoctorVisits
                            .VisitNo = oVisits.VisitNo
                            .StaffNo = staffNo
                            .ServiceCode = oVisits.ServiceCode
                            .LoginID = CurrentUser.LoginID
                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lDoctorVisits.Add(oDoctorVisits)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lDoctorVisits, Action.Save))

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        For pos As Integer = 0 To ARTCurrentlyOn.Rows.Count - 1

                            Dim row As DataRow = ARTCurrentlyOn.Rows(pos)
                            Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                            Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                            Dim cashAmount As Decimal = CDec(quantity * unitPrice * oVisits.CoPayPercent) / 100

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Using oItems As New SyncSoft.SQLDb.Items()
                                With oItems
                                    .VisitNo = oVisits.VisitNo
                                    .ItemCode = StringEnteredIn(row, "DrugNo")
                                    .ItemCategoryID = oItemCategoryID.Drug
                                    .Quantity = quantity
                                    .UnitPrice = unitPrice
                                    .ItemDetails = StringMayBeEnteredIn(row, "Formula")
                                    .LastUpdate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                                    .ItemStatusID = oItemStatusID.Pending
                                    .PayStatusID = oPayStatusID.NotPaid
                                    .LoginID = CurrentUser.LoginID
                                End With
                                lRefillItems.Add(oItems)
                            End Using

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Using oItemsEXT As New SyncSoft.SQLDb.ItemsEXT()
                                With oItemsEXT
                                    .VisitNo = oVisits.VisitNo
                                    .ItemCode = StringEnteredIn(row, "DrugNo")
                                    .ItemCategoryID = oItemCategoryID.Drug
                                    .Dosage = StringEnteredIn(row, "Dosage")
                                    .Duration = IntegerEnteredIn(row, "Duration")
                                    .DrQuantity = quantity
                                End With
                                lRefillItemsEXT.Add(oItemsEXT)
                            End Using

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If oVisits.CoPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                                Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                    With oItemsCASH
                                        .VisitNo = oVisits.VisitNo
                                        .ItemCode = StringEnteredIn(row, "DrugNo")
                                        .ItemCategoryID = oItemCategoryID.Drug
                                        .CashAmount = cashAmount
                                        .CashPayStatusID = oPayStatusID.NotPaid
                                    End With
                                    lRefillItemsCASH.Add(oItemsCASH)
                                End Using
                            End If
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Next

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lRefillItems, Action.Save))
                        transactions.Add(New TransactionList(Of DBConnect)(lRefillItemsEXT, Action.Save))
                        If oVisits.CoPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                            transactions.Add(New TransactionList(Of DBConnect)(lRefillItemsCASH, Action.Save))
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts
                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .VisitNo = oVisits.VisitNo
                                        .StaffNo = staffNo
                                        .Notes = ARTCurrentlyOn.Rows.Count.ToString() + " Prescription(s) sent"
                                        .LoginID = CurrentUser.LoginID
                                    End With
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    lAlerts.Add(oAlerts)
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                End Using
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lAlerts, Action.Save))
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Catch ex As Exception
                            Exit Try
                        End Try
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End If

                    'If patient has come for consultation, then payment has to be effected
                    If Not oVisits.ServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                        Dim quantity As Integer = 1
                        Dim unitPrice As Decimal = Me.nbxToBillServiceFee.GetDecimal(False)
                        Dim cashAmount As Decimal = CDec(quantity * unitPrice * oVisits.CoPayPercent) / 100

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim lInsuranceItemsCASH As New List(Of DBConnect)
                        Dim oSmartCardItems As SmartCardItems
                        Dim smardCardNo As String = String.Empty
                        Dim medicalCardNo As String = RevertText(RevertText(oVisits.MemberCardNo, "/"c))
                        Dim coverAmount As Decimal
                        Dim billFee As Decimal = unitPrice

                        If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then
                           
                            oSmartCardMembers = ProcessSmartCardData(patientNo)

                            smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                            coverAmount = oSmartCardMembers.CoverAmount
                            
                            If billFee > coverAmount Then unitPrice = coverAmount

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Using oItems As New SyncSoft.SQLDb.Items()

                            With oItems

                                .VisitNo = oVisits.VisitNo
                                .ItemCode = oVisits.ServiceCode
                                .ItemCategoryID = oItemCategoryID.Service
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = serviceName + " Service"
                                .LastUpdate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                                If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                                    .ItemStatusID = oItemStatusID.Offered

                                Else : .ItemStatusID = oItemStatusID.Pending
                                End If
                                If (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) Then
                                    .PayStatusID = oPayStatusID.NA
                                Else
                                    .PayStatusID = oPayStatusID.NotPaid
                                End If
                                .LoginID = CurrentUser.LoginID
                            End With

                            lItems.Add(oItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If oVisits.CoPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = oVisits.VisitNo
                                    .ItemCode = oVisits.ServiceCode
                                    .ItemCategoryID = oItemCategoryID.Service
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If Not medicalCardNo.ToUpper().Equals(smardCardNo.ToUpper()) Then
                                message = "The medical card number  (" + oVisits.MemberCardNo + ") for this member is not the same " +
                                          "as that forwarded from smart card (" + oSmartCardMembers.MedicalCardNumber + ") " +
                                          ", the system does not allow to process numbers that don’t match"
                                Throw New ArgumentException(message)
                            End If

                            If billFee > coverAmount Then
                                message = "The benefit for the patient you are registering is not sufficient to cover this service. " +
                                         ControlChars.NewLine + "Would you like to forward the balance as cash payment?"

                                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                                If oVisits.CoPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                                    message = "Action not allowed for patients with a co-pay percent! "
                                    Throw New ArgumentException(message)
                                End If

                                Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                    With oItemsCASH
                                        .VisitNo = oVisits.VisitNo
                                        .ItemCode = oVisits.ServiceCode
                                        .ItemCategoryID = oItemCategoryID.Service
                                        .CashAmount = billFee - coverAmount
                                        .CashPayStatusID = oPayStatusID.NotPaid
                                    End With

                                    lInsuranceItemsCASH.Add(oItemsCASH)
                                End Using
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lInsuranceItemsCASH, Action.Save))
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            oSmartCardItems = New SmartCardItems()

                            With oSmartCardItems

                                .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                                .TransactionTime = GetTime(Now)
                                .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                                .DiagnosisCode = (0).ToString()
                                .DiagnosisDescription = "Unknown Disease"
                                .EncounterType = "CONSULTATION"
                                .CodeType = "Mcode"
                                .Code = (1).ToString()
                                .CodeDescription = serviceName
                                .Quantity = quantity.ToString()
                                .Amount = (quantity * unitPrice).ToString()

                            End With

                            lSmartCardItems.Add(oSmartCardItems)

                            oSmartCardMembers.InvoiceNo = oVisits.VisitNo
                            oSmartCardMembers.TotalBill = quantity * unitPrice
                            oSmartCardMembers.TotalServices = lSmartCardItems.Count()
                            oSmartCardMembers.CopayType = oVisits.CoPayTypeID
                            oSmartCardMembers.CopayAmount = oVisits.CoPayValue
                            oSmartCardMembers.Gender = genderID

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            Dim oVisitTypeID As New LookupDataID.VisitTypeID()
                            If Not UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, oVisits.VisitNo, oVisitTypeID.OutPatient) Then
                                Throw New ArgumentException("Error processing smart card information. Please edit the transactions and try again")
                                Return
                            End If

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                            If oVisits.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then

                                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                                Dim oEntryModeID As New LookupDataID.EntryModeID()

                                Dim lClaims As New List(Of DBConnect)

                                Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                                Dim lClaimsEXT As New List(Of DBConnect)
                                Dim lClaimDetails As New List(Of DBConnect)

                                Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(oVisits.VisitNo)

                                Using oClaims As New SyncSoft.SQLDb.Claims()

                                    With oClaims

                                        .MedicalCardNo = RevertText(StringEnteredIn(Me.cboBillNo, "Medical Card No!"))
                                        .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                        .PatientNo = oVisits.PatientNo
                                        .VisitDate = oVisits.VisitDate
                                        .VisitTime = GetTime(Now)
                                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                        .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))
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
                                            .VisitNo = oVisits.VisitNo
                                        End With

                                        lClaimsEXT.Add(oClaimsEXT)

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        claimNo = oClaims.ClaimNo
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    End If
                                End Using

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim limitBalance As Decimal
                                Dim limitAmount As Decimal = GetPolicyLimit(oVisits.BillNo, oBenefitCodes.Service)
                                Dim consumedAmount As Decimal = GetPolicyConsumedAmount(oVisits.BillNo, oBenefitCodes.Service)
                                If limitAmount > 0 Then
                                    limitBalance = limitAmount - consumedAmount
                                Else : limitBalance = 0
                                End If

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                                    With oClaimDetails

                                        .ClaimNo = claimNo
                                        .ItemName = serviceName
                                        .BenefitCode = oBenefitCodes.Service
                                        .Quantity = 1
                                        .UnitPrice = unitPrice
                                        .Adjustment = 0
                                        .Amount = .Quantity * .UnitPrice
                                        .Notes = serviceName + " offered to Visit No: " + oVisits.VisitNo
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
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVisits.CoPayTypeID.ToUpper().Equals(oCoPayTypeID.Value.ToUpper()) Then

                        Dim lCOPAYVALUEItems As New List(Of DBConnect)
                        Dim lCOPAYVALUEItemsCASH As New List(Of DBConnect)
                        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = oVisits.VisitNo
                                .ItemCode = oExtraItemCodes.COPAYVALUE
                                .ItemCategoryID = oItemCategoryID.Extras
                                .Quantity = 1
                                .UnitPrice = -oVisits.CoPayValue
                                .ItemDetails = "Co-Pay Value of: " + FormatNumber(oVisits.CoPayValue, AppData.DecimalPlaces)
                                .LastUpdate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                                .ItemStatusID = oItemStatusID.Offered
                                .PayStatusID = oPayStatusID.NotPaid
                                .LoginID = CurrentUser.LoginID
                            End With
                            lCOPAYVALUEItems.Add(oItems)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lCOPAYVALUEItems, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = oVisits.VisitNo
                                .ItemCode = oExtraItemCodes.COPAYVALUE
                                .ItemCategoryID = oItemCategoryID.Extras
                                .CashAmount = oVisits.CoPayValue
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lCOPAYVALUEItemsCASH.Add(oItemsCASH)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lCOPAYVALUEItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        message = "Co-Pay Value of " + FormatNumber(oVisits.CoPayValue, AppData.DecimalPlaces) +
                                  " will automatically be marked as offered. You won’t be able to remove it. " +
                                  ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                  
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim lservicePoint As New List(Of String)
                    Dim oServicePointID As New LookupDataID.ServicePointID
                    lservicePoint.Add(oServicePointID.Triage())
                    lservicePoint.Add(oServicePointID.Doctor())

                    If (oVisits.BillModesID.ToUpper.Equals(oBillModesID.Cash().ToUpper())) Then
                        lservicePoint.Add(oServicePointID.Cashier())
                    End If

                    Dim lQueues As New List(Of DBConnect)

                    lQueues = GetQueuesList(oVisits.VisitNo, oServicePointID.Visit(), oVisits.VisitsPriorityID, lservicePoint)


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lQueues, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If IntegerMayBeEnteredIn(Me.stbAge).Equals(GetAge(AppData.NullDateValue)) Then
                        message = "This Patient has an unknown Date of Birth value registered. " +
                                  "It’s recommended that you edit this Patient to enter a correct Date of Birth." +
                                    ControlChars.NewLine + "Would you like to edit now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.btnEditPatient.PerformClick()
                    End If

                    If Not (StringMayBeEnteredIn(Me.stbGender).ToUpper().Equals(GetLookupDataDes(oGenderID.Male).ToUpper()) OrElse
                            StringMayBeEnteredIn(Me.stbGender).ToUpper().Equals(GetLookupDataDes(oGenderID.Female).ToUpper())) Then
                        message = "This Patient has an unknown Gender value registered. " +
                                  "It’s recommended that you edit this Patient to enter a correct Gender." +
                                    ControlChars.NewLine + "Would you like to edit now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.btnEditPatient.PerformClick()
                    End If

                    If DateMayBeEnteredIn(Me.stbJoinDate).Equals(AppData.NullDateValue) Then
                        message = "This Patient has an unknown Join Date value registered. " +
                                  "It’s recommended that you edit this Patient to enter a correct Join Date." +
                                    ControlChars.NewLine + "Would you like to edit now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.btnEditPatient.PerformClick()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim totalVisits As Integer = IntegerMayBeEnteredIn(Me.stbTotalVisits)

                    If InitOptions.PromptForExtraChargeRegistration AndAlso totalVisits = 0 AndAlso
                        oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then

                        message = "The system has detected that this is the first visit for this cash patient who is expected to pay for a file." +
                                    ControlChars.NewLine + "Would you like to register for file charge now?"

                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                            Dim fExtraCharge As New frmExtraCharge(oVisits.VisitNo)
                            fExtraCharge.ShowDialog()
                        End If

                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.SMSNotificationAtVisits Then
                        Dim oPatient As New SyncSoft.SQLDb.Patients()
                        oPatient.GetPatient(patientNo)
                        If stbPhone.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhone.Text) Then
                            Dim productOwner As String = AppData.ProductOwner
                            Dim recipients As String = stbPhone.Text
                            Dim txtmessage As String = ("Hi" + " " + oPatient.FirstName.ToString + " " + RevertText(stbVisitNo.Text) + " " + "is your Visit No present it at every service point you visit today" + " " + productOwner + " " + "-Via ClinicMaster")
                            SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanVisits)

                        End If
                    End If

                    If oVariousOptions.EnableRegistrationShortCuts Then

                        Dim fOpenOptions As New frmOpenVisitOptions(oVisits.VisitNo)
                        fOpenOptions.ShowDialog()
                    End If


                    If oVariousOptions.AllowPrintingForm5 Then
                        If ChkPrintFormFive.Checked = False Then
                            message = "You have not checked Print Form 5 On Saving. " + ControlChars.NewLine + "Would you want the Form 5 Data printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintForm5(True)
                        Else : Me.PrintForm5(True)
                        End If
                    End If


                    If oVariousOptions.OpenInvoicesAfterVisits And Not (oVisits.ServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper())) Then

                        Dim billMode As String = StringValueMayBeEnteredIn(Me.cboBillModesID)
                        Dim cashBillMode As String = oBillModesID.Cash
                        Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
                        Dim fInvoices As New frmInvoices(visitNo)
                        Dim fCashier As New frmCashier(visitNo, oVisitTypeID.OutPatient)
                        If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then
                            fInvoices.ShowDialog()
                        Else

                            fCashier.ShowDialog()
                        End If

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.dtpVisitDate.Value = Today
                    Me.dtpVisitDate.Checked = True
                    Me.SetDefaultVisitCategory()
                    Me.chkAccessCashServices.Enabled = oVariousOptions.EnableAccessCashServices
                    Me.chkSmartCardApplicable.Enabled = False
                    Me.cboVisitPriority.SelectedValue = oPriorityID.Normal

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(defaultKeyNo) AndAlso visitsKeyNo = ItemsKeyNo.PatientNo Then Me.Close()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    If Me.cboBillModesID.Enabled Then

                        message = "You need to make sure that this visit is not opened at cashier to process payment. " +
                                    "Otherwise it may lead to both you and cahier succeeding, " +
                                    "with cahier processing payment under the bill that you are about to update!" +
                                    ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                    DisplayMessage(oVisits.Update())
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

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True

        Me.stbVisitNo.ReadOnly = False
        Me.btnFindPatientNo.Enabled = False
        Me.btnFindVisitNo.Visible = True

        Me.chkAccessCashServices.Enabled = False
        Me.chkSmartCardApplicable.Enabled = False
        Me.ChkPrintFormFive.Visible = False
        ResetControlsIn(Me.pnlVisitStatus)
        ResetControlsIn(Me)
        Me.EnableVisitsCTLS(False)
        Me.ResetAssociatedBillControls(False)
        SetComboDefaultValue(InitOptions.Community, cboCommunityID, LookupObjects.Community)
    End Sub

    Public Sub Save()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        If Not Me.RecordSaved(False) Then Return
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = False

        Me.stbVisitNo.ReadOnly = InitOptions.VisitNoLocked
        Me.nbxToBillServiceFee.ReadOnly = InitOptions.ToBillServiceFeeLocked
        Me.chkSmartCardApplicable.Enabled = False

        Me.btnFindPatientNo.Enabled = True
        Me.btnFindVisitNo.Visible = False

        Me.chkAccessCashServices.Enabled = oVariousOptions.EnableAccessCashServices

        Me.EnableVisitsCTLS(True)
        Me.ResetAssociatedBillControls(False)
        ResetControlsIn(Me)
        Me.dtpVisitDate.Value = Today
        Me.dtpVisitDate.Checked = True
        Me.SetDefaultVisitCategory()
        Me.ChkPrintFormFive.Checked = oVariousOptions.AllowPrintingForm5
        Me.btnPrintForm5.Visible = False
        SetComboDefaultValue(InitOptions.Community, cboCommunityID, LookupObjects.Community)
    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0
            Me.btnPrintForm5.Visible = oVariousOptions.AllowPrintingForm5
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

    Private Sub EnableVisitsCTLS(ByVal state As Boolean)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.stbPatientNo.Enabled = state
        Me.btnLoad.Enabled = state
        'Me.dtpVisitDate.Enabled = state
        Me.cboDoctorSpecialtyID.Enabled = state
        Me.cboStaffNo.Enabled = oVariousOptions.EnableVisitToSeeDoctorSelection
        Me.cboVisitCategoryID.Enabled = state
        Me.cboServiceCode.Enabled = state
        Me.nbxToBillServiceFee.Enabled = state
        If state Then
            Me.cboBillModesID.Enabled = state
        Else : Me.cboBillModesID.Enabled = oVariousOptions.AllowExtendedVisitEdits
        End If
        Me.stbReferredBy.ReadOnly = Not state
        Me.nbxToBillServiceFee.Enabled = state
        Me.cboBillNo.Enabled = state
        Me.stbMemberCardNo.Enabled = state
        Me.stbMainMemberName.Enabled = state
        Me.stbClaimReferenceNo.Enabled = state
        Me.chkFingerprintCaptured.Visible = state
        Me.btnFindByFingerprint.Visible = state
        Me.btnEditPatient.Visible = state
        Me.cboVisitStatusID.Enabled = Not state

    End Sub


#End Region

    Private Sub btnViewTodaysBirthdays_Click(sender As System.Object, e As System.EventArgs) Handles btnViewTodaysBirthdays.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fTodaysBirthdays As New frmBirthdays
        fTodaysBirthdays.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub LoadPackageAvailability()

        Dim Opackages As New SyncSoft.SQLDb.Packages()
        Dim OpackageEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim PatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
        Dim serviceCode As String = StringValueMayBeEnteredIn(Me.cboServiceCode, "To-Bill Service!")

        Try
            Me.Cursor = Cursors.WaitCursor

            If (Me.cboPackageName.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboPackageName.Text)) Then

                Dim PackageNo As String = RevertText(SubstringEnteredIn(Me.cboPackageName, "Package Name!"))
                Dim packages As Boolean = Opackages.IsPackageStillOn(PatientNo, PackageNo, serviceCode, oItemCategoryID.Service)
                Dim packageItemUnitPrice As Decimal = OpackageEXT.GetPackageItemUnitPrice(PackageNo, serviceCode, oItemCategoryID.Service)
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

                If packages.Equals(True) Then
                    Me.chkHasPackage.Checked = True
                    Me.nbxToBillServiceFee.Value = FormatNumber(packageItemUnitPrice, AppData.DecimalPlaces)

                Else : Me.chkHasPackage.Checked = False
                    Me.nbxToBillServiceFee.Value = FormatNumber(packageItemUnitPrice, AppData.DecimalPlaces)
                End If

                If Me.chkHasPackage.Checked = False AndAlso billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                    Dim message As String = "Please Notify this Patient that he/she has to Pay for the package before access (Incase of previous attachment,please tell the Patient that the Package Expired) !!! "
                    DisplayMessage(message, MessageBoxIcon.Information)
                End If
            Else
                Me.ShowToBillServiceFee(serviceCode)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboPackageName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPackageName.SelectedIndexChanged
        Try

            LoadPackageAvailability()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

#Region "Print Form 5"
    Private Sub PrintForm5(ByVal facesheetSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docBioData
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBioData.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docBioData_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBioData.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)
            Dim sf As New StringFormat
            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Out Patient Department".ToUpper()

            Dim lName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim tribe As String = tribeName
            Dim village As String = villageName
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos - 70)
                    yPos += lineHeight
                    .DrawString("Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos - 60)
                    .DrawString(lName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos - 60)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos - 60)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos - 60)
                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, widthTopThird, yPos - 60)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, widthTopFourth, yPos - 60)
                    yPos += lineHeight

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos - 60)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos - 60)
                    .DrawString("Address: ", bodyNormalFont, Brushes.Black, widthTopThird, yPos - 60)
                    .DrawString(villageName, bodyBoldFont, Brushes.Black, widthTopFourth, yPos - 60)
                    yPos += lineHeight

                    .DrawString("Tribe: ", bodyNormalFont, Brushes.Black, xPos, yPos - 60)
                    .DrawString(tribe, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos - 60)

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

                If bioDataParagraphs Is Nothing Then Return

                Do While bioDataParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(bioDataParagraphs(1), PrintParagraps)
                    bioDataParagraphs.Remove(1)

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
                        bioDataParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (bioDataParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnPrintForm5_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintForm5.Click
        Try
            PrintForm5(True)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region


End Class