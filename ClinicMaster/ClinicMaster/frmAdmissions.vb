
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Imports System.Drawing.Printing

Imports System.Drawing.Imaging
Imports GenCode128
Imports SyncSoft.Common.Structures
Imports SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmAdmissions

#Region " Fields "

    Private defaultVisitNo As String = String.Empty
    Private doctorFullName As String = String.Empty

    Private billModesID As String = String.Empty
    ' Private associatedBillNo As String = String.Empty
    Private companyNo As String = Nothing
    Private billCustomers As DataTable
    Private allowOnlyListedMember As Boolean
    Private captureMemberCardNo As Boolean
    Private captureClaimReferenceNo As Boolean
    Dim _AdmissionsDiagnosisValue As String = String.Empty
    Private Const _CashCustomer As String = "Cash Customer"
    Private oVariousOptions As New VariousOptions()
    Private WithEvents docBarcodes As New PrintDocument()
    Private WithEvents docAdmissionForm As New PrintDocument()
    Private facesheetParagraphs As Collection
    Private WithEvents docFaceSheet As New PrintDocument()
    Private tipFeeWords As New ToolTip()
    Private oEntryModeID As New LookupDataID.EntryModeID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oBenefitCodes As New LookupDataID.BenefitCodes()
    Private oBillModesID As New LookupDataID.BillModesID()
    Private oCoPayTypeID As New LookupDataID.CoPayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()


    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padNotes As Integer = 16
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 13
    Private padAmount As Integer = 14

    ' The paragraphs.
    Private AdmissionParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private smartCardApplicable As Boolean
    Private oSmartCardMembers As New SmartCardMembers()
    Private oIntegrationAgentID As New IntegrationAgentID()
    Private patientNo As String
    Private tribe As String
    Private religion As String
    Private NOKName As String
    Private NOKPhone As String
    Private address As String
    Private phoneNo As String

    Private AdmissionFaceSheetParagraphs As Collection
    Private WithEvents docAdmissionFaceSheet As New PrintDocument()
#End Region

#Region " Validations "


    Private Sub dtpAdmissionDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpAdmissionDateTime.Validating

        Dim errorMSG As String = "Admission Date Time can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim admissionDateTime As Date = DateMayBeEnteredIn(Me.dtpAdmissionDateTime)

            If admissionDateTime = AppData.NullDateValue Then Return

            If admissionDateTime < visitDate Then
                ErrProvider.SetError(Me.dtpAdmissionDateTime, errorMSG)
                Me.dtpAdmissionDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpAdmissionDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub frmAdmissions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpAdmissionDateTime.MaxDate = Today.AddDays(1)
            Me.dtpAdmissionDateTime.Value = Now
            Me.chkPrintAdmissionConsent.Checked = True
            If oVariousOptions.AllowPrintingAdmissionFaceSheet Then
                Me.chkPrintAdmissionFaceSheet.Visible = True
                Me.chkPrintAdmissionFaceSheet.Checked = True
            End If
            Me.LoadStaff()
            Me.PopulateForm()
            Me.LoadServices()

            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboCoPayTypeID, LookupObjects.CoPayType, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then

                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.cboStaffNo.Text = doctorFullName
                Me.ProcessTabKey(True)
                Me.ShowPatientDetails(defaultVisitNo)

            Else : Me.stbVisitNo.ReadOnly = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.HideAccessCashServicesAtVisits Then
                Me.chkAccessCashServices.Visible = False
            Else : Me.chkAccessCashServices.Visible = True
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbAdmissionNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.TextChanged
        GenerateBarcode()
        Me.CallOnKeyEdit()
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim services As DataTable = oServices.GetServicesAtServicePoint(oServicePointID.Admission).Tables("Services")

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

    Private Sub PopulateForm()

        Try

            Me.Cursor = Cursors.WaitCursor

            LoadLookupDataCombo(Me.cboWardsID, LookupObjects.Wards, False)
            LoadLookupDataCombo(Me.cboAdmissionStatusID, LookupObjects.AdmissionStatus, True)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

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

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click
        Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fFindAdmissionNo.ShowDialog(Me)
        Me.stbAdmissionNo.Focus()
    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.lblAgeString.Text = String.Empty
        Me.stbBillCustomerName.Clear()
        Me.stbServiceName.Clear()
        billModesID = String.Empty
        tribe = String.Empty
        religion = String.Empty
        NOKName = String.Empty
        NOKPhone = String.Empty
        address = String.Empty
        phoneNo = String.Empty
        Me.tipFeeWords.RemoveAll()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            Me.GenerateBarcode()
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)
            Me.patientNo = StringEnteredIn(row, "PatientNo")
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")

            smartCardApplicable = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.lblAgeString.Text = GetAgeString(birthDate, True)
            Me.stbGender.Text = StringEnteredIn(row, "Gender")

            Me.stbServiceName.Text = StringMayBeEnteredIn(row, "ServiceName")
            Dim billNo As String = StringMayBeEnteredIn(row, "BillNo")
            Me.cboBillModesID.Text = StringMayBeEnteredIn(row, "BillMode")
            Me.cboBillNo.Text = billNo
            Me.cboAssociatedBillNo.Text = StringMayBeEnteredIn(row, "AssociatedFullBillCustomer")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbClaimReferenceNo.Text = StringMayBeEnteredIn(row, "ClaimReferenceNo")
            Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            tribe = StringMayBeEnteredIn(row, "Tribe")
            religion = StringMayBeEnteredIn(row, "Religion")
            NOKName = StringMayBeEnteredIn(row, "NOKName")
            NOKPhone = StringMayBeEnteredIn(row, "NOKPhone")
            address = StringMayBeEnteredIn(row, "Address")
            phoneNo = StringMayBeEnteredIn(row, "Phone")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkSmartCardApplicable.Checked = smartCardApplicable
            If smartCardApplicable Then
                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                Dim authorized As Boolean = IsSmartCardPatientAuthorized(patientNo, billModesID, billNo, visitDate)
                If authorized Then
                    Me.chkSmartCardApplicable.Enabled = authorized
                Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                End If

            Else : Me.chkSmartCardApplicable.Enabled = False
            End If


            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                If visitDate = Today Then
                    Me.dtpAdmissionDateTime.Value = Now
                Else : Me.dtpAdmissionDateTime.Value = visitDate
                End If
                Me.dtpAdmissionDateTime.Checked = GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12))
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowCustomAdmissionNoFormat Then Me.SetNextAdmissionNo(visitNo, patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetSmartCardPatientAuthorized()
        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub Enablecontrols()
        Me.cboBillNo.Enabled = False
        Me.cboBillModesID.Enabled = False
        Me.cboAssociatedBillNo.Enabled = False
        Me.cboCoPayTypeID.Enabled = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMainMemberName.Enabled = False
        Me.stbClaimReferenceNo.Enabled = False
        Me.nbxCoPayPercent.Enabled = False
    End Sub

    Private Sub SetNextAdmissionNo(ByVal visitNo As String, ByVal patientNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Me.stbAdmissionNo.Clear()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Admissions", "AdmissionNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim admissionID As String = oAdmissions.GetNextAdmissionID(visitNo).ToString()
            admissionID = admissionID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbAdmissionNo.Text = FormatText(patientNo + admissionID.Trim(), "Admissions", "AdmissionNo")

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextCustomAdmissionNo()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Me.stbAdmissionNo.Clear()

            Dim currentYear As String = Today.Year.ToString().Substring(2)
            Dim currentMonth As String = Today.Month.ToString().PadLeft(2, "0"c)

            Dim wardName As String = StringMayBeEnteredIn(Me.cboWardsID)

            Dim wardInitial As String = oAdmissions.GetWardInitial(wardName)
            Dim admissionNoPrefix As String = wardInitial + currentYear + currentMonth

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Admissions", "AdmissionNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim admissionID As String = oAdmissions.GetNextCustomAdmissionID(wardInitial).ToString()
            admissionID = admissionID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbAdmissionNo.Text = FormatText(admissionNoPrefix + admissionID.Trim(), "Admissions", "AdmissionNo")

        Catch ex As Exception
            Return

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
        SetSmartMemberLimit()
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

                    Me.LoadBedPrice()
                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        Dim smartCardApplicable As Boolean = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
                        allowOnlyListedMember = BooleanMayBeEnteredIn(row, "AllowOnlyListedMember")
                        captureMemberCardNo = BooleanMayBeEnteredIn(row, "CaptureMemberCardNo")
                        captureClaimReferenceNo = BooleanMayBeEnteredIn(row, "CaptureClaimReferenceNo")
                        ' companyNo = StringMayBeEnteredIn(row, "CompanyNo")
                        Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                        Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
                        Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "BillCustomerInsurance")
                        Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                        Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                        Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)

                        Me.chkSmartCardApplicable.Checked = smartCardApplicable

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetBillControls()
                    Me.LoadBedPrice()
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
                    Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                    Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                    Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    Me.chkSmartCardApplicable.Checked = smartCardApplicable

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select
            
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

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
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillNo)))
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillNo, billCustomers, "BillCustomerFullName")
                    Me.cboBillNo.Enabled = True
                    Me.stbMemberCardNo.Enabled = True
                    Me.stbMainMemberName.Enabled = True
                    Me.stbClaimReferenceNo.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        Dim smartCardApplicable As Boolean = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
                        Me.chkSmartCardApplicable.Checked = smartCardApplicable
                        If smartCardApplicable Then

                            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate, Today)
                            Dim authorized As Boolean = IsSmartCardPatientAuthorized(Me.patientNo, billModesID, accountNo, visitDate)
                            If authorized Then
                                Me.chkSmartCardApplicable.Enabled = authorized
                            Else : Me.chkSmartCardApplicable.Enabled = oVariousOptions.AllowSmartCardApplicableVisit
                            End If

                        Else : Me.chkSmartCardApplicable.Enabled = False
                        End If

                    Next

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = True
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    Me.stbClaimReferenceNo.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oAdmissions.AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            DisplayMessage(oAdmissions.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.grpLocation)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            Dim dataSource As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(stbVisitNo))
            Dim row As DataRow = dataSource.Rows(0)

     
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissions As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim wardsID As String = (From data In admissions Select data.Field(Of String)("WardsID")).First()
            Dim roomNo As String = (From data In admissions Select data.Field(Of String)("RoomNo")).First()
            Dim bedNo As String = (From data In admissions Select data.Field(Of String)("BedNo")).First()

            If Not String.IsNullOrEmpty(wardsID) Then Me.LoadRooms(wardsID)
            If Not String.IsNullOrEmpty(roomNo) Then Me.LoadBeds(roomNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboWardsID.SelectedValue = wardsID
            Me.cboRoomNo.SelectedValue = roomNo
            Me.cboBedNo.SelectedValue = bedNo

            tribe = StringMayBeEnteredIn(row, "Tribe")
            religion = StringMayBeEnteredIn(row, "Religion")
            NOKName = StringMayBeEnteredIn(row, "NOKName")
            NOKPhone = StringMayBeEnteredIn(row, "NOKPhone")
            address = StringMayBeEnteredIn(row, "Address")
            phoneNo = StringMayBeEnteredIn(row, "Phone")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
         
            Me.DisplayData(dataSource)

          

                Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
                Me.OrganizeBillControls(billModesID)

                Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()
                If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                    Me.LoadAssociatedBillCustomers(accountNo)
                    Me.cboAssociatedBillNo.Text = StringMayBeEnteredIn(row, "AssociatedFullBillCustomer")
                    Me.EnableSetAssociatedBillCustomer()
                End If


            Dim admissionStatusID As String = (From data In admissions Select data.Field(Of String)("AdmissionStatusID")).First()
            Me.dtpAdmissionDateTime.Enabled = Not admissionStatusID.ToUpper().Equals(oAdmissionStatusID.Discharged.ToUpper())
            Me.SetSmartCardPatientAuthorized()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

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

    Private Sub nbxToBillServiceFee_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxToBillServiceFee.Leave

        Try

            Dim consultationFee As Decimal = DecimalMayBeEnteredIn(Me.nbxToBillServiceFee, False)
            Me.tipFeeWords.SetToolTip(Me.nbxToBillServiceFee, NumberToWords(consultationFee))

        Catch ex As Exception
            Return

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


    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim Message As String
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim lINTAdmissions As New List(Of DBConnect)
        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim lAdmissions As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim serviceName As String = StringMayBeEnteredIn(cboServiceCode)
        Try

            Me.Cursor = Cursors.WaitCursor()
            Dim oBillModesID As New LookupDataID.BillModesID()

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


            Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            With oAdmissions

                .AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                .VisitNo = visitNo
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                StringValueEnteredIn(Me.cboWardsID, "Ward!")
                StringValueEnteredIn(Me.cboRoomNo, "Room No!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .BedNo = StringValueEnteredIn(Me.cboBedNo, "Bed No!")
                .AdmissionDateTime = DateTimeEnteredIn(Me.dtpAdmissionDateTime, "Admission Date Time!")
                .AdmissionNotes = StringEnteredIn(Me.stbAdmissionNotes, "Admission Notes")
                .ChartNumber = StringMayBeEnteredIn(Me.stbChartNumber)
                .AdmissionStatusID = StringValueEnteredIn(Me.cboAdmissionStatusID, "Admission Status!")
                If Me.cboServiceCode.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboServiceCode.Text) Then
                    .ServiceCode = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
                Else : .ServiceCode = String.Empty
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
                .ProvisionalDiagnosis = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)
                .CoPayTypeID = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
                .CoPayPercent = Me.nbxCoPayPercent.GetSingle()
                .CoPayValue = Me.nbxCoPayValue.GetDecimal(False)
                .SmartCardApplicable = Me.chkSmartCardApplicable.Checked
                .AccessCashServices = Me.chkAccessCashServices.Checked
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lAdmissions.Add(oAdmissions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'If patient has an admission service to be paid for, then payment has to be effected
            If oVariousOptions.EnableAdmissionBillServiceFee Then

                If Not oAdmissions.ServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim minTran As New List(Of TransactionList(Of DBConnect))
                    Dim billNo As String = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill Account No!"))
                    Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
                    Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oAdmissions.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then

                        Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                        Using oClaims As New SyncSoft.SQLDb.Claims()

                            With oClaims
                                .MedicalCardNo = billNo
                                .ClaimNo = GetNextClaimNo(billNo)
                                .PatientNo = patientNo
                                .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .VisitTime = GetTime(Now)
                                .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                .PrimaryDoctor = String.Empty
                                .ClaimStatusID = oClaimStatusID.Pending
                                .ClaimEntryID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID
                            End With
                            lClaims.Add(oClaims)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If String.IsNullOrEmpty(claimNo) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                With oClaimsEXT
                                    .ClaimNo = oClaims.ClaimNo
                                    .VisitNo = visitNo
                                End With

                                lClaimsEXT.Add(oClaimsEXT)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DoTransactions(minTran)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                claimNo = oClaims.ClaimNo
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If
                        End Using
                    End If



                    Dim quantity As Integer = 1
                    Dim unitPrice As Decimal = Me.nbxToBillServiceFee.GetDecimal(False)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * oAdmissions.CoPayPercent) / 100

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lInsuranceItemsCASH As New List(Of DBConnect)
                    Dim smardCardNo As String = String.Empty
                    Dim medicalCardNo As String = RevertText(RevertText(oAdmissions.MemberCardNo, "/"c))
                    Dim coverAmount As Decimal
                    Dim billFee As Decimal = unitPrice
                   

                    Dim extraBillNo As String = GetNextExtraBillNo(visitNo, patientNo)

                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardMembers = ProcessSmartCardData(patientNo)

                        smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                        coverAmount = oSmartCardMembers.CoverAmount

                        If billFee > coverAmount Then unitPrice = coverAmount

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBills As New List(Of DBConnect)

                    Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()
                        With oExtraBills

                            .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                            .ExtraBillNo = extraBillNo
                            .ExtraBillDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Attending Doctor!")
                            .LoginID = CurrentUser.LoginID

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lExtraBills.Add(oExtraBills)

                    End Using

                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = oAdmissions.ServiceCode
                            .ItemCategoryID = oItemCategoryID.Service
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = "Bill No: " + extraBillNo + " - " + serviceName
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .PayStatusID = oPayStatusID.NotPaid
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oAdmissions.CoPayTypeID.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then

                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = oAdmissions.ServiceCode
                                .ItemCategoryID = oItemCategoryID.Service
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oAdmissions.BillModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Service)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Service)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = cboServiceCode.Text
                                .BenefitCode = oBenefitCodes.Service
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = "Bill No: " + extraBillNo + " - " + cboServiceCode.Text
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End If
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save


                    transactions.Add(New TransactionList(Of DBConnect)(lAdmissions, Action.Save))


                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then


                        Using oINTAdmissions As New INTAdmissions()
                            With oINTAdmissions

                                .AgentNo = oIntegrationAgentID.SMART
                                .AdmissionNo = admissionNo
                                .MemberLimit = DecimalMayBeEnteredIn(nbxCoverAmount)
                                .LoginID = CurrentUser.LoginID
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                ValidateEntriesIn(Me)
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End With
                            lINTAdmissions.Add(oINTAdmissions)
                        End Using
                        UpdateResultFile(oSmartCardMembers.Id, String.Empty)
                        transactions.Add(New TransactionList(Of DBConnect)(lINTAdmissions, Action.Save))
                    End If

                    records = DoTransactions(transactions)


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.UpdateVisitStatus(visitNo)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Message = "Admission No : " + FormatText(oAdmissions.AdmissionNo, "Admissions", "AdmissionNo") +
                              ", was successfully assigned to " + stbFullName.Text + "!"

                    DisplayMessage(Message)
                    If Me.chkPrintAdmissionForm.Checked = False Then
                        Message = "You have not checked Print Admission Form On Saving. " + ControlChars.NewLine + "Would you want an Admission Form  printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintAdmissionForm()
                    Else : Me.PrintAdmissionForm()
                    End If

                    If Me.chkPrintAdmissionConsent.Checked = False Then
                        Message = "You have not checked Print Admission Consent Form On Saving. " + ControlChars.NewLine + "Would you want an Admission Consent  printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.Printfacesheet(True)
                    Else : Me.Printfacesheet(True)
                    End If

                    If oVariousOptions.AllowPrintingAdmissionFaceSheet Then
                        If Me.chkPrintAdmissionFaceSheet.Checked = False Then
                            Message = "You have not checked Print Admission Face Sheet On Saving. " + ControlChars.NewLine + "Would you want an Admission Face Sheet  printed?"
                            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintAdmissionFaceSheet(True)
                        Else : Me.PrintAdmissionFaceSheet(True)
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.OpenCashierFormOnAdmission Then
                        Dim billMode As String = StringValueMayBeEnteredIn(Me.cboBillModesID)
                        Dim cashBillMode As String = oBillModesID.Cash
                        Dim fInvoices As New frmIPDInvoices(visitNo)
                        Dim fCashier As New frmCashier(visitNo, oVisitTypeID.InPatient)
                        If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then
                            fInvoices.ShowDialog()
                        Else

                            fCashier.ShowDialog()
                        End If
                    End If

                    ResetControlsIn(Me)
                    ResetControlsIn(Me.grpLocation)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case ButtonCaption.Update




                    transactions.Add(New TransactionList(Of DBConnect)(lAdmissions, Action.Update, "Admissions"))
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")

                    If Me.chkPrintAdmissionForm.Checked = False Then
                        Message = "You have not checked Print Admission Form On Saving. " + ControlChars.NewLine + "Would you want an Admission Form  printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintAdmissionForm()
                    Else : Me.PrintAdmissionForm()
                    End If

                    If Me.chkPrintAdmissionConsent.Checked = False Then
                        Message = "You have not checked Print Admission Consent Form On Saving. " + ControlChars.NewLine + "Would you want an Admission Consent  printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.Printfacesheet(True)
                    Else : Me.Printfacesheet(True)
                    End If

                    If oVariousOptions.AllowPrintingAdmissionFaceSheet Then
                        If Me.chkPrintAdmissionFaceSheet.Checked = False Then
                            Message = "You have not checked Print Admission Face Sheet On Saving. " + ControlChars.NewLine + "Would you want an Admission Face Sheet  printed?"
                            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintAdmissionFaceSheet(True)
                        Else : Me.PrintAdmissionFaceSheet(True)
                        End If
                    End If
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub UpdateVisitStatus(ByVal visitNo As String)

        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim lVisits As New List(Of DBConnect)

            If String.IsNullOrEmpty(visitNo) Then Return

            With oVisits

                .VisitNo = visitNo
                .VisitStatusID = oVisitStatusID.InPatient
                .VisitDate = AppData.NullDateValue
                .AccessCashServices = Nothing
                .LoginID = String.Empty

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lVisits.Add(oVisits)
            transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Update))

            DoTransactions(transactions)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " Location "

    Private Sub cboWardsID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWardsID.SelectedIndexChanged

        Try
            Dim wardsID As String
            If Me.cboWardsID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboWardsID.SelectedValue.ToString()) Then
                wardsID = String.Empty
            Else : wardsID = StringValueEnteredIn(Me.cboWardsID, "Ward!")
            End If

            Me.LoadRooms(wardsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboWardsID_Leave(sender As System.Object, e As System.EventArgs) Handles cboWardsID.Leave

        Try

            Dim oVariousOptions As New VariousOptions()
            If oVariousOptions.AllowCustomAdmissionNoFormat Then Me.SetNextCustomAdmissionNo()
            Me.GenerateBarcode()
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadRooms(ByVal WardsID As String)

        Dim oRooms As New SyncSoft.SQLDb.Rooms()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboRoomNo.DataSource = Nothing
            If String.IsNullOrEmpty(WardsID) Then Return

            ' Load all from Rooms
            Dim rooms As DataTable = oRooms.GetRoomsBywardsID(WardsID).Tables("Rooms")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoomNo.Sorted = False
            Me.cboRoomNo.DataSource = rooms
            Me.cboRoomNo.DisplayMember = "RoomName"
            Me.cboRoomNo.ValueMember = "RoomNo"

            Me.cboRoomNo.SelectedIndex = -1
            Me.cboRoomNo.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboRoomNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRoomNo.SelectedIndexChanged

        Try

            Dim roomNo As String
            If Me.cboRoomNo.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboRoomNo.SelectedValue.ToString()) Then
                roomNo = String.Empty
            Else : roomNo = StringValueEnteredIn(Me.cboRoomNo, "Room No!")
            End If

            Me.LoadBeds(roomNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadBeds(ByVal roomNo As String)

        Dim oBeds As New SyncSoft.SQLDb.Beds()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboBedNo.DataSource = Nothing

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxUnitPrice.Value = String.Empty
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roomNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from Beds
            Dim beds As DataTable = oBeds.GetBedsByRoomNo(roomNo).Tables("Beds")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBedNo.Sorted = False
            Me.cboBedNo.DataSource = beds
            Me.cboBedNo.DisplayMember = "BedName"
            Me.cboBedNo.ValueMember = "BedNo"

            Me.cboBedNo.SelectedIndex = -1
            Me.cboBedNo.SelectedIndex = -1
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBedPrice()


        Dim oBeds As New SyncSoft.SQLDb.Beds()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxUnitPrice.Value = String.Empty

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim bedNo As String = StringValueMayBeEnteredIn(Me.cboBedNo, "Bed No!")
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim associatedBillNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAssociatedBillNo)))

            If String.IsNullOrEmpty(bedNo) Then Return

            Dim beds As DataTable = oBeds.GetBeds(bedNo).Tables("Beds")
            Dim row As DataRow = beds.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim unitPrice As Decimal = GetCustomFee(bedNo, oItemCategoryID.Admission, billNo, billModesID, associatedBillNo)
            Me.nbxUnitPrice.Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub cboBedNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBedNo.Leave
        Me.LoadBedPrice()
        SetSmartMemberLimit()
    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.dtpAdmissionDateTime.Enabled = True

        Me.stbVisitNo.Enabled = False
        Me.btnFindVisitNo.Enabled = False
        Me.btnLoadPeriodicVisits.Enabled = False
        Me.btnFindAdmissionNo.Enabled = True
        Me.stbAdmissionNo.ReadOnly = False

        Me.chkPrintAdmissionForm.Checked = False
        Me.chkPrintAdmissionForm.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)
        ResetControlsIn(Me.pnlAdmissionStatusID)
        EnableEditAdmissionsCTLS(False)
    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.chkPrintAdmissionForm.Enabled = True
        Me.chkPrintAdmissionForm.Checked = True

        Me.dtpAdmissionDateTime.Enabled = True

        Me.stbVisitNo.Enabled = True
        Me.btnFindVisitNo.Enabled = True
        Me.btnLoadPeriodicVisits.Enabled = True
        Me.btnFindAdmissionNo.Enabled = False
        Me.stbAdmissionNo.ReadOnly = InitOptions.AdmissionNoLocked
        Me.nbxToBillServiceFee.ReadOnly = InitOptions.ToBillServiceFeeLocked
        EnableAdmissionsCTLS(True)
        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)
        Me.PopulateForm()

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

    Private Sub EnableAdmissionsCTLS(ByVal state As Boolean)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.stbPatientNo.Enabled = state
        Me.cboServiceCode.Enabled = oVariousOptions.EnableAdmissionBillServiceFee
        Me.nbxToBillServiceFee.Enabled = oVariousOptions.EnableAdmissionBillServiceFee
        If state Then
            Me.cboBillModesID.Enabled = state
        Else : Me.cboBillModesID.Enabled = oVariousOptions.AllowExtendedVisitEdits
        End If
        Me.nbxToBillServiceFee.Enabled = state
        Me.cboBillNo.Enabled = state
        Me.stbMemberCardNo.Enabled = state
        Me.stbMainMemberName.Enabled = state
        Me.stbClaimReferenceNo.Enabled = state


    End Sub

    Private Sub EnableEditAdmissionsCTLS(ByVal state As Boolean)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.stbPatientNo.Enabled = state
        Me.cboStaffNo.Enabled = oVariousOptions.EnableVisitToSeeDoctorSelection
        Me.cboServiceCode.Enabled = state
        Me.nbxToBillServiceFee.Enabled = state
        If state Then
            Me.cboBillModesID.Enabled = state
        Else : Me.cboBillModesID.Enabled = oVariousOptions.AllowExtendedVisitEdits
        End If
        Me.nbxToBillServiceFee.Enabled = state
        Me.cboBillNo.Enabled = state
        Me.stbMemberCardNo.Enabled = state
        Me.stbMainMemberName.Enabled = state
        Me.stbClaimReferenceNo.Enabled = state


    End Sub


#End Region

#Region "Bracode Details"

    Private Sub GenerateBarcode()
        Try
            Dim imageweight As Integer = 2
            'Barcode using the GenCode128
            If Not String.IsNullOrEmpty(stbAdmissionNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(stbAdmissionNo.Text.ToString(), Integer.Parse(imageweight.ToString()), True)
                imgIDAutomation.Image = barcodeImage

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub docBarcodes_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBarcodes.PrintPage
        Try

            Dim rect As New Rectangle(0, 10, 280, 85)

            rect = New Rectangle(0, 10, 280, 15)

            e.Graphics.DrawRectangle(Pens.White, rect)

            Dim h, w As Integer


            w = imgIDAutomation.Width
            h = imgIDAutomation.Height
            rect = New Rectangle(50, 130, w, h)
            e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(imgIDAutomation.Image, rect)
            e.Graphics.DrawRectangle(Pens.White, rect)

            rect = New Rectangle(70, 185, 280, 15)
            rect = New Rectangle(0, 215, 280, 15)

        Catch ex As Exception

            Throw (ex)
        End Try

    End Sub

    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs)
        Try
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnPrintBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBarcode.Click
        Dim dlgPrint As New PrintDialog()

        Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docBarcodes

            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBarcodes.Print()

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

#End Region

#Region "Print Admission"
    Private Sub PrintAdmissionForm()

        Dim dlgPrint As New PrintDialog()
        Dim docTypeID As New LookupDataID.DocumentTypeID()
        Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo))
        Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo))
        Dim printdesc As String = (stbFullName.Text + " 's" + " Admission Details")
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetAdmissionFormPrintData()
            SavePrintDetails(patientNo, admissionNo, printdesc, docTypeID.Admission)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docAdmissionForm
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docAdmissionForm.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetAdmissionFormPrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)


        Dim chartNumber As String = StringMayBeEnteredIn(Me.stbChartNumber)
        Dim admissionNotes As String = StringMayBeEnteredIn(Me.stbAdmissionNotes)
        Dim provisionalDiagnosis As String = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)
        Dim currentChartNumber As New System.Text.StringBuilder(String.Empty)
        Dim currentAdmissionNotes As New System.Text.StringBuilder(String.Empty)
        Dim currentProvisionalDiagnosis As New System.Text.StringBuilder(String.Empty)

        AdmissionParagraphs = New Collection()

        Try


            If Not (String.IsNullOrEmpty(chartNumber) Or String.IsNullOrWhiteSpace(chartNumber)) Then
                currentChartNumber.Append("Chart Number.".PadRight(padItemNo))
                currentChartNumber.Append(ControlChars.NewLine)
                 AdmissionParagraphs.Add(New PrintParagraps(bodyBoldFont, currentChartNumber.ToString()))
                AdmissionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.chartNumber()))
            End If

            If Not (String.IsNullOrEmpty(provisionalDiagnosis) Or String.IsNullOrWhiteSpace(provisionalDiagnosis)) Then
                currentProvisionalDiagnosis.Append("Provisional Diagnosis.".PadRight(padItemNo))
                currentProvisionalDiagnosis.Append(ControlChars.NewLine)
                AdmissionParagraphs.Add(New PrintParagraps(bodyBoldFont, currentProvisionalDiagnosis.ToString()))
                AdmissionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.provisionalDiagnosis()))
            End If

            If Not (String.IsNullOrEmpty(admissionNotes) Or String.IsNullOrWhiteSpace(admissionNotes)) Then
                 currentAdmissionNotes.Append("Admission Notes.".PadRight(padItemNo))
                currentAdmissionNotes.Append(ControlChars.NewLine)
                 AdmissionParagraphs.Add(New PrintParagraps(bodyBoldFont, currentAdmissionNotes.ToString()))
                AdmissionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.AdmissionNotes()))
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
            AdmissionParagraphs.Add(New PrintParagraps(bodyNormalFont, signArea.ToString()))
            signArea.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            AdmissionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''            
             pageNo = 0
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub docAdmissionForm_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docAdmissionForm.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " ADMISSION DETAILS".ToUpper()
            Dim patientName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim admissionNo As String = StringMayBeEnteredIn(Me.stbAdmissionNo)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim admissionDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpAdmissionDateTime))
            Dim wardNo As String = StringValueMayBeEnteredIn(Me.cboWardsID)
            Dim roomNo As String = StringValueMayBeEnteredIn(Me.cboRoomNo)
            Dim bedNo As String = StringValueMayBeEnteredIn(Me.cboBedNo)
            Dim admissionStatus As String = StringValueMayBeEnteredIn(Me.cboAdmissionStatusID)
            Dim chartNumber As String = StringMayBeEnteredIn(Me.stbChartNumber)
            Dim admissionNotes As String = StringMayBeEnteredIn(Me.stbAdmissionNotes)

            '        ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

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

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Ward No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(wardNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Admission No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(admissionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Room No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(roomNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Admission Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(admissionDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Bed No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(bedNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight


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

                If AdmissionParagraphs Is Nothing Then Return

                Do While AdmissionParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(AdmissionParagraphs(1), PrintParagraps)
                    AdmissionParagraphs.Remove(1)

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
                        AdmissionParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (AdmissionParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    
    Public Function chartNumber() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbChartNumber.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ProvisionalDiagnosis() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbProvisionalDiagnosis.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function AdmissionNotes() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            tableData.Append(stbAdmissionNotes.Text)
            tableData.Append(ControlChars.NewLine)
            tableData.Append(ControlChars.NewLine)
            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region "Print Admission Consent"

    Private Sub Printfacesheet(ByVal facesheetSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetfacesheetReportPrintData()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docFaceSheet
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docFaceSheet.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docFaceSheet_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docFaceSheet.PrintPage

        Try


            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " PATIENT'S CONSENT".ToUpper()



            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim fullname As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim ward As String = StringMayBeEnteredIn(Me.cboWardsID)
            Dim admissionNo As String = StringMayBeEnteredIn(Me.stbAdmissionNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim chatNo As String = StringMayBeEnteredIn(Me.stbChartNumber)
            Dim gender As String = StringEnteredIn(Me.stbGender)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 13 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 33 * widthTopFirst
                Dim widthTopFifth As Single = 17 * widthTopFirst
                Dim widthTopSixth As Single = 37 * widthTopFirst
                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Center
                Dim printFont10_Normal As New Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point)
                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight


                    ''Draw the barcode
                    If imgIDAutomation.Image IsNot Nothing Then
                        Dim rect As New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        rect = New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        e.Graphics.DrawRectangle(Pens.White, rect)
                        Dim h, w As Integer
                        w = imgIDAutomation.Width
                        h = imgIDAutomation.Height

                        rect = New Rectangle(CInt(xPos), CInt(yPos), w, h)

                        e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        e.Graphics.DrawImage(imgIDAutomation.Image, rect)
                        e.Graphics.DrawRectangle(Pens.White, rect)
                    End If

                    yPos += 8 * lineHeight
                    .DrawString("Patient Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullname, bodyBoldFont, Brushes.Black, widthTopThird, yPos)
                    yPos += lineHeight

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)
                    .DrawString("Admission No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(admissionNo, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight


                    .DrawString("Chart No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(chatNo, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)
                    .DrawString("Ward: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(ward, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight


                End If
                yPos += 2 * lineHeight

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

                If facesheetParagraphs Is Nothing Then Return

                Do While facesheetParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(facesheetParagraphs(1), PrintParagraps)
                    facesheetParagraphs.Remove(1)

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
                        facesheetParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (facesheetParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetfacesheetReportPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)



        pageNo = 0
        facesheetParagraphs = New Collection()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim surgicaltitle As New System.Text.StringBuilder(String.Empty)

            surgicaltitle.Append("CONSENT FOR ADMISSION AND TREATMENT".ToUpper())
            surgicaltitle.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, surgicaltitle.ToString()))
            surgicaltitle.Append(ControlChars.NewLine)
            surgicaltitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim surgicalData As New System.Text.StringBuilder(String.Empty)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("I/My,   " + GetCharacters("."c, 25))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("agree to be admitted to " + AppData.ProductOwner)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("I hereby consent to Medical or Surgical Treatments that shall be performed from time to time by the Medical Team that shall be considered beneficial to my health.")
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("Signature/Thumb Print:   " + GetCharacters("."c, 12))

            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Date:  " + GetCharacters("."c, 12))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Time:  " + GetCharacters("."c, 12))

            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("Witness: Name  " + GetCharacters("."c, 10))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Title:   " + GetCharacters("."c, 10))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Signature:  " + GetCharacters("."c, 10))
            surgicalData.Append(ControlChars.NewLine)

            facesheetParagraphs.Add(New PrintParagraps(footerFont, surgicalData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dischargetitle As New System.Text.StringBuilder(String.Empty)
            dischargetitle.Append(ControlChars.NewLine)
            dischargetitle.Append(ControlChars.NewLine)
            dischargetitle.Append("CONSENT FOR SURGICAL OPERATIONS OR PROCEDURES".ToUpper())

            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, dischargetitle.ToString()))
            dischargetitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dischargeData As New System.Text.StringBuilder(String.Empty)
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append("I / My,   " + GetCharacters("."c, 25))
            dischargeData.Append(GetSpaces(2))
            dischargeData.Append("Consent to such operation under anaesthesia being performed on me / my")

            dischargeData.Append(GetSpaces(2))
            dischargeData.Append(GetCharacters("."c, 25) + "As decided by the Surgeon in the best interest of my / his/ her health")
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append("Witness: I hereby certify that I have explained the above agreement to the  signee and I am satisfied that he / she has understood its consent and agree to the operation unconditionally.")

            facesheetParagraphs.Add(New PrintParagraps(footerFont, dischargeData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sterilizationtitle As New System.Text.StringBuilder(String.Empty)
            sterilizationtitle.Append(ControlChars.NewLine)
            sterilizationtitle.Append(ControlChars.NewLine)
            sterilizationtitle.Append("DISCHARGE AGAINST MEDICAL ADVICE".ToUpper())
            sterilizationtitle.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, sterilizationtitle.ToString()))
            sterilizationtitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sterilizationData As New System.Text.StringBuilder(String.Empty)
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("Name: " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Of (Address): " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Wish to take my discharge or wish to discharge my")
            sterilizationtitle.Append(ControlChars.NewLine)
            sterilizationData.Append(GetCharacters("."c, 25) + "I appreciate that this is against the  advice  and wishes of the Medical Team.  I acknowledge that I have been informed of the danger of doing so and I accept full responsibility for my actions and consequences arising there from")
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("Sign: " + GetCharacters("."c, 10))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Date: " + GetCharacters("."c, 10))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Relationship to patient,   " + GetCharacters("."c, 25))
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("The dangers that might arise out of his/her decision to take his/her own discharge")
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("Sign: " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("(Medical Practitioner) " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Date: " + GetCharacters("."c, 10))
            sterilizationData.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(footerFont, sterilizationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            facesheetParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region "Print Patient Bio Data"

    Private Sub PrintAdmissionFaceSheet(ByVal facesheetSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetBioPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docAdmissionFaceSheet
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docAdmissionFaceSheet.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docAdmissionFaceSheet_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docAdmissionFaceSheet.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)
            Dim sf As New StringFormat
            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Admission Face Sheet".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim admissionNo As String = StringMayBeEnteredIn(Me.stbAdmissionNo)
            Dim admissionWard As String = StringMayBeEnteredIn(Me.cboWardsID)
            Dim patientID As String = StringEnteredIn(stbPatientNo)
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

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight


                    .DrawString("Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight


                    .DrawString("Admission No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(admissionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("W.O.A: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(admissionWard, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientID, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Address: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(address, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Phone No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(phoneNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Tribe: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(tribe, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Religion: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(religion, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight



                    .DrawString("Next Of Kin: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(NOKName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("NOK Phone: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(NOKPhone, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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

                If AdmissionFaceSheetParagraphs Is Nothing Then Return

                Do While AdmissionFaceSheetParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(AdmissionFaceSheetParagraphs(1), PrintParagraps)
                    AdmissionFaceSheetParagraphs.Remove(1)

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
                        AdmissionFaceSheetParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (AdmissionFaceSheetParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetBioPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        AdmissionFaceSheetParagraphs = New Collection()

        Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim provisionalData As New System.Text.StringBuilder(String.Empty)
            provisionalData.Append(ControlChars.NewLine)
            provisionalData.Append(ControlChars.NewLine)
            provisionalData.Append("Provisional Diagnosis :" + GetCharacters("."c, 56))
            provisionalData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, provisionalData.ToString()))


            Dim commentsData As New System.Text.StringBuilder(String.Empty)
            commentsData.Append(ControlChars.NewLine)
            commentsData.Append(ControlChars.NewLine)
            commentsData.Append("Date Of Discharge :" + GetCharacters("."c, 56))
            commentsData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, commentsData.ToString()))


            Dim dischargingData As New System.Text.StringBuilder(String.Empty)
            dischargingData.Append(ControlChars.NewLine)
            dischargingData.Append("Discharging Ward :" + GetCharacters("."c, 56))
            dischargingData.Append(ControlChars.NewLine)
            dischargingData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, dischargingData.ToString()))

            Dim dischargdiagnosisData As New System.Text.StringBuilder(String.Empty)
            dischargdiagnosisData.Append(ControlChars.NewLine)
            dischargdiagnosisData.Append("Discharge Diagnosis :" + GetCharacters("."c, 56))
            dischargdiagnosisData.Append(ControlChars.NewLine)
            dischargdiagnosisData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, dischargdiagnosisData.ToString()))

            Dim statusiagnosisData As New System.Text.StringBuilder(String.Empty)
            statusiagnosisData.Append(ControlChars.NewLine)
            statusiagnosisData.Append("Status Of Discharge : 1) Recovered (R), 2) Improved (I), 3) Unchanged (U), 4) Self-Discharged (S), 5) Referred (T), 6) Dead (DD)")
            statusiagnosisData.Append(ControlChars.NewLine)
            statusiagnosisData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, statusiagnosisData.ToString()))



            Dim remarksData As New System.Text.StringBuilder(String.Empty)
            remarksData.Append(ControlChars.NewLine)
            remarksData.Append("Remarks :" + GetCharacters("."c, 56))
            remarksData.Append(ControlChars.NewLine)
            remarksData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, remarksData.ToString()))

            Dim dataclerkSignData As New System.Text.StringBuilder(String.Empty)
            dataclerkSignData.Append(ControlChars.NewLine)
            dataclerkSignData.Append(ControlChars.NewLine)

            dataclerkSignData.Append("Discharged By :   " + GetCharacters("."c, 20))
            dataclerkSignData.Append(GetSpaces(4))
            dataclerkSignData.Append("Date:  " + GetCharacters("."c, 20))
            dataclerkSignData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, dataclerkSignData.ToString()))




            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim propertyData As New System.Text.StringBuilder(String.Empty)
            propertyData.Append(ControlChars.NewLine)
            propertyData.Append("This is property of " + AppData.AppTitle + " . It must not be taken outside the Hospital without permission.")
            propertyData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, propertyData.ToString()))


            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            AdmissionFaceSheetParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

  
#End Region



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
        chkSmartCardApplicable.Checked = False
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
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty



        Me.chkPrintAdmissionConsent.Checked = True
        If oVariousOptions.AllowPrintingAdmissionFaceSheet Then
            Me.chkPrintAdmissionFaceSheet.Visible = True
            Me.chkPrintAdmissionFaceSheet.Checked = True
        End If
        Me.chkSmartCardApplicable.Checked = False
        Me.nbxCoverAmount.Clear()
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



    Private Sub SetSmartCardPatientAuthorized()

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim oSmartCardAuthorisations As New SyncSoft.SQLDb.SmartCardAuthorisations()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate, Today)
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



    Private Sub SetSmartMemberLimit()
        Try
            Dim smardCardNo As String
            Dim coverAmount As Decimal
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)

                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount
                Me.nbxCoverAmount.Value = FormatNumber(coverAmount, AppData.DecimalPlaces)

            End If
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

 
    Private Sub btnLoadProvisionalTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadProvisionalTemplate.Click
        Dim oTemplateTypeID As New LookupDataID.TemplateTypeID()
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ProvisionalDiagnosis, Me.stbProvisionalDiagnosis, True)
        fGetTemplates.ShowDialog(Me)
    End Sub
End Class