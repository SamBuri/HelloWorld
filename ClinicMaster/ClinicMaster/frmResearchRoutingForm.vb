
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic
Imports SyncSoft.Common.Lookup
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Public Class frmResearchRoutingForm

#Region " Fields "
    Private defaultuCIID As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False
    Private oVariousOptions As New VariousOptions()
    Private oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oBillModesID As New LookupDataID.BillModesID()
    Dim oStatusID As New LookupCommDataID.StatusID()
#End Region

#Region "Validations"
    Private Sub ndpBirthDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetAge, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub nbxAge_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAge.Leave
        Try
            SetBirthDateAge(BirthDateAge.SetBirthDate, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub
#End Region

#Region " Location "

    Private Sub cboDistrictsID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDistrictsID.SelectedIndexChanged

        Try

            Dim districtsID As String = StringValueMayBeEnteredIn(Me.cboDistrictsID, "District!")
            Me.LoadCounties(districtsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboCountyCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountyCode.SelectedIndexChanged

        Try

            Dim countyCode As String = StringValueMayBeEnteredIn(Me.cboCountyCode, "County!")
            Me.LoadSubCounties(countyCode)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboSubCountyCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCountyCode.SelectedIndexChanged

        Try

            Dim subCountyCode As String = StringValueMayBeEnteredIn(Me.cboSubCountyCode, "Sub County!")
            Me.LoadParishes(subCountyCode)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboParishCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParishCode.SelectedIndexChanged

        Try

            Dim parishCode As String = StringValueMayBeEnteredIn(Me.cboParishCode, "Parish!")
            Me.LoadVillages(parishCode)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadCounties(ByVal districtsID As String)

        Dim oCounties As New SyncSoft.SQLDb.Counties()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboCountyCode.DataSource = Nothing
            If String.IsNullOrEmpty(districtsID) Then Return

            ' Load all from Counties
            Dim counties As DataTable = oCounties.GetCountiesByDistrictsID(districtsID).Tables("Counties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboCountyCode.Sorted = False
            Me.cboCountyCode.DataSource = counties
            Me.cboCountyCode.DisplayMember = "CountyName"
            Me.cboCountyCode.ValueMember = "CountyCode"

            Me.cboCountyCode.SelectedIndex = -1
            Me.cboCountyCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadSubCounties(ByVal countyCode As String)

        Dim oSubCounties As New SyncSoft.SQLDb.SubCounties()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboSubCountyCode.DataSource = Nothing
            If String.IsNullOrEmpty(countyCode) Then Return

            ' Load all from SubCounties
            Dim subCounties As DataTable = oSubCounties.GetSubCountiesByCountyCode(countyCode).Tables("SubCounties")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboSubCountyCode.Sorted = False
            Me.cboSubCountyCode.DataSource = subCounties
            Me.cboSubCountyCode.DisplayMember = "SubCountyName"
            Me.cboSubCountyCode.ValueMember = "SubCountyCode"

            Me.cboSubCountyCode.SelectedIndex = -1
            Me.cboSubCountyCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadParishes(ByVal subCountyCode As String)

        Dim oParishes As New SyncSoft.SQLDb.Parishes()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboParishCode.DataSource = Nothing
            If String.IsNullOrEmpty(subCountyCode) Then Return

            ' Load all from Parishes
            Dim parishes As DataTable = oParishes.GetParishesBySubCountyCode(subCountyCode).Tables("Parishes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboParishCode.Sorted = False
            Me.cboParishCode.DataSource = parishes
            Me.cboParishCode.DisplayMember = "ParishName"
            Me.cboParishCode.ValueMember = "ParishCode"

            Me.cboParishCode.SelectedIndex = -1
            Me.cboParishCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadVillages(ByVal parishCode As String)

        Dim oVillages As New SyncSoft.SQLDb.Villages()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboVillageCode.DataSource = Nothing
            If String.IsNullOrEmpty(parishCode) Then Return

            ' Load all from Villages
            Dim villages As DataTable = oVillages.GetVillagesByParishCode(parishCode).Tables("Villages")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboVillageCode.Sorted = False
            Me.cboVillageCode.DataSource = villages
            Me.cboVillageCode.DisplayMember = "VillageName"
            Me.cboVillageCode.ValueMember = "VillageCode"

            Me.cboVillageCode.SelectedIndex = -1
            Me.cboVillageCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub frmResearchRoutingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.LoadHealthUnits()
            LoadLookupDataCombo(Me.cboGenderID, LookupObjects.Gender, False)
            LoadLookupDataCombo(Me.cboEligibleForScreeningID, LookupObjects.YesNo, True)
            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)
            LoadLookupDataCombo(Me.cboReferralStudyCodeID, LookupObjects.ReferralStudyCode, False)
            LoadLookupDataCombo(Me.clbPatientScreenedBy, LookupObjects.StaffTitle, False)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.chkUseExistingPatient.Checked = True
            Me.ManagePatientStatus(True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not String.IsNullOrEmpty(defaultuCIID) Then
                Me.stbUCIID.Text = FormatText(defaultuCIID, "Patients", "PatientNo")
                Me.stbUCIID.ReadOnly = True
                Me.ProcessTabKey(True)
                Me.Search(defaultuCIID)
            Else : Me.stbUCIID.ReadOnly = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmResearchRoutingForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub SetNextResearchRoutingFormNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oResearchRoutingFormNo As New SyncSoft.SQLDb.ResearchRoutingForm()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim yearL2 As String = Today.Year.ToString().Substring(2)
            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("ResearchRoutingForm", "UCIID").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextResearchRoutingFormNo As String = CStr(oResearchRoutingFormNo.GetNextResearchRoutingFormID).PadLeft(paddingLEN, paddingCHAR)
            Me.stbUCIID.Text = FormatText(("U" + yearL2 + nextResearchRoutingFormNo).Trim(), "ResearchRoutingForm", "UCIID")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadHealthUnits()

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim healthUnits As DataTable = oHealthUnits.GetHealthUnits().Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboHealthUnitCode.Sorted = False
            LoadComboData(Me.cboHealthUnitCode, healthUnits, "HealthUnitCode", "HealthUnitName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oResearchRoutingForm.UCIID = StringEnteredIn(Me.stbUCIID, "UCI ID!")

            DisplayMessage(oResearchRoutingForm.Delete())
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
        Try
            Dim uCIID As String = RevertText(StringEnteredIn(Me.stbUCIID, "UCI ID!"))
            Me.Search(uCIID)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try



    End Sub

    Public Sub Search(ByVal uCIID As String)
        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()
        Dim oVillages As New SyncSoft.SQLDb.Villages()
        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor()
            uCIID = RevertText(StringEnteredIn(Me.stbUCIID, "Research No!"))
            Dim dataSource As DataTable = oResearchRoutingForm.GetResearchRoutingForm(uCIID).Tables("ResearchRoutingForm")
            Dim researchRoutingForm As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageCode As String = (From data In researchRoutingForm Select data.Field(Of String)("VillageCode")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageRow As DataRow = oVillages.GetVillages(villageCode).Tables("Villages").Rows(0)

            Dim districtsID As String = StringMayBeEnteredIn(villageRow, "DistrictsID")
            Dim countyCode As String = StringMayBeEnteredIn(villageRow, "CountyCode")
            Dim subCountyCode As String = StringMayBeEnteredIn(villageRow, "SubCountyCode")
            Dim parishCode As String = StringMayBeEnteredIn(villageRow, "ParishCode")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(districtsID) Then Me.LoadCounties(districtsID)
            If Not String.IsNullOrEmpty(countyCode) Then Me.LoadSubCounties(countyCode)
            If Not String.IsNullOrEmpty(subCountyCode) Then Me.LoadParishes(subCountyCode)
            If Not String.IsNullOrEmpty(parishCode) Then Me.LoadVillages(parishCode)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboDistrictsID.SelectedValue = districtsID
            Me.cboCountyCode.SelectedValue = countyCode
            Me.cboSubCountyCode.SelectedValue = subCountyCode
            Me.cboParishCode.SelectedValue = parishCode
            Me.cboVillageCode.SelectedValue = villageCode

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim healthUnitCode As String = (From data In researchRoutingForm Select data.Field(Of String)("HealthUnitCode")).First()

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim healthUnitsRow As DataRow = oHealthUnits.GetHealthUnits(healthUnitCode).Tables("HealthUnits").Rows(0)

            'Dim districtshealthUnitID As String = StringMayBeEnteredIn(healthUnitsRow, "DistrictsID")
            'Dim healthUnitID As String = StringMayBeEnteredIn(healthUnitsRow, "HealthUnitCode")
            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If Not String.IsNullOrEmpty(districtsID) Then Me.LoadHealthUnits(districtsID)

            ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.cboDistrictsID.SelectedValue = districtshealthUnitID
            'Me.cboHealthUnitCode.SelectedValue = healthUnitID
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()
        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Dim oYesNoID As New LookupDataID.YesNoID()
        Dim message As String
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim lResearchRoutingForm As New List(Of DBConnect)
            Dim lPatients As New List(Of DBConnect)


            If Not Me.chkUseExistingPatient.Checked Then

                With oPatients

                    .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's Number!"))
                    .ReferenceNo = String.Empty
                    .LastName = StringEnteredIn(Me.stbLastName, "Surname!")
                    .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                    .MiddleName = StringMayBeEnteredIn(Me.stbOtherName)
                    .BirthDate = DateEnteredIn(Me.dtpBirthDate, "Birth Date!")
                    .GenderID = StringValueEnteredIn(Me.cboGenderID, "Gender!")
                    .Fingerprint = Nothing
                    .JoinDate = Today
                    .Address = String.Empty
                    .Phone = StringMayBeEnteredIn(Me.stbPhone)
                    .BirthPlace = String.Empty
                    .Email = String.Empty
                    .NOKName = String.Empty
                    .NOKRelationship = String.Empty
                    .NOKPhone = String.Empty
                    .Occupation = String.Empty
                    .Location = String.Empty

                    If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) AndAlso
                     oCrossMatchTemplate.Fingerprint IsNot Nothing Then
                        .Fingerprint = oCrossMatchTemplate.Fingerprint

                    ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) AndAlso
                        (oDigitalPersonaTemplate.Template IsNot Nothing) Then
                        .Fingerprint = oDigitalPersonaTemplate.Template.Bytes

                    Else : .Fingerprint = Nothing
                    End If


                    .DefaultBillModesID = oBillModesID.Cash()
                    .DefaultBillNo = "CASH"
                    .DefaultMemberCardNo = String.Empty

                    .DefaultMainMemberName = String.Empty

                    .EnforceDefaultBillNo = True

                    .HideDetails = False
                    .StatusID = oStatusID.Active
                    .LoginID = CurrentUser.LoginID
                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If oPatients.DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then ValidateBillCustomerInsuranceDirect(oPatients.DefaultBillNo)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(oPatients.Phone.Trim()) Then
                    message = "You have not entered a phone number for this Patient. " +
                              "It’s recommended that you enter at least one phone number for contact purposes. " +
                               ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbPhone.Focus() : Return
                End If
                lPatients.Add(oPatients)
                transactions.Add(New TransactionList(Of DBConnect)(lPatients, Action.Save))
            End If

            With oResearchRoutingForm

                .UCIID = RevertText(StringEnteredIn(Me.stbUCIID, "Research No!"))
                If Me.chkUseExistingPatient.Checked Then
                    .PatientNo = RevertText(StringEnteredIn(stbPatientNo, "patient No"))
                Else
                    .PatientNo = RevertText(StringMayBeEnteredIn(stbPatientNo))

                End If
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .LastName = StringEnteredIn(Me.stbLastName, "Last Name!")
                .OtherName = StringMayBeEnteredIn(Me.stbOtherName)
                .ReferalInitials = StringEnteredIn(Me.stbReferalInitials, "Referal Initials!")
                .GenderID = StringValueEnteredIn(Me.cboGenderID, "Sex!")
                .BirthDate = DateEnteredIn(Me.dtpBirthDate, "BirthDate!")
                .VillageCode = StringValueEnteredIn(Me.cboVillageCode, "Village!")
                .ReferralDate = DateEnteredIn(Me.dtpReferralDate, "Referral Date!")
                .ReferralStudyCodeID = StringValueEnteredIn(Me.cboReferralStudyCodeID, "Referral Study Code!")
                .ReferralStudyName = StringEnteredIn(Me.stbReferralStudyName, "Referral Study Name!")
                .Diagnosis = StringEnteredIn(Me.stbDiagnosis, "Diagnosis!")
                .HealthUnitCode = StringValueEnteredIn(Me.cboHealthUnitCode, "Referral  Clinic!")
                .ReferredBy = StringEnteredIn(Me.stbReferredBy, "Referred By!")
                .PatientScreenedBy = StringToSplitSelectedInAtleastOne(Me.clbPatientScreenedBy, LookupObjects.StaffTitle, "Patient Screened By!")
                .ReferralInitials = StringEnteredIn(Me.stbReferralInitials, "Referral Initials!")
                .EligibleForScreeningID = StringValueEnteredIn(Me.cboEligibleForScreeningID, "Eligible For Screening!")
                If .EligibleForScreeningID.ToUpper().Equals(oYesNoID.No.ToUpper()) Then
                    .ExclusionReason = StringEnteredIn(Me.stbExclusionReason, "Exclusion Reason!")
                    .PatientReferedTo = StringEnteredIn(Me.stbPatientReferedTo, "Patient Refered To!")
                    .ReferredDate = DateEnteredIn(Me.dtpReferredDate, "Referred Date!")
                    .SCRNo = StringMayBeEnteredIn(Me.stbSCRNo)
                    .PID = StringMayBeEnteredIn(Me.stbPID)
                    .SID = StringMayBeEnteredIn(Me.stbSID)
                Else
                    .ExclusionReason = StringMayBeEnteredIn(Me.stbExclusionReason)
                    .PatientReferedTo = StringMayBeEnteredIn(Me.stbPatientReferedTo)
                    .ReferredDate = DateMayBeEnteredIn(Me.dtpReferredDate)
                    .SCRNo = StringEnteredIn(Me.stbSCRNo, "SCR No!")
                    .PID = StringEnteredIn(Me.stbPID, "PID!")
                    .SID = StringEnteredIn(Me.stbSID, "SID!")

                End If
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(pnlPatients)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    lResearchRoutingForm.Add(oResearchRoutingForm)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    transactions.Add(New TransactionList(Of DBConnect)(lResearchRoutingForm, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    message = "Research No : " + FormatText(oResearchRoutingForm.UCIID, "ResearchRoutingForm", "UCIID") +
                              ", was successfully assigned to " + oResearchRoutingForm.LastName + "!"

                    DisplayMessage(message)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "Would you like to capture Enrollment Information now?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                        Dim fEnrollmentInformation As New frmEnrollmentInformation(oResearchRoutingForm.UCIID, ItemsKeyNo.UCIID)
                        fEnrollmentInformation.Save()
                        fEnrollmentInformation.ShowDialog()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(pnlPatients)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    SetNextResearchRoutingFormNo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    DisplayMessage(oResearchRoutingForm.Update())
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

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        ResetControlsIn(Me)
        Me.chkUseExistingPatient.Checked = True
        Me.ManagePatientStatus(Me.chkUseExistingPatient.Checked)
        Me.chkUseExistingPatient.Enabled = True

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.SetNextResearchRoutingFormNo()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub cboEligibleForScreeningID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEligibleForScreeningID.SelectedIndexChanged
        Dim oYesNoID As New LookupDataID.YesNoID()
        If Me.cboEligibleForScreeningID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboEligibleForScreeningID.SelectedValue.ToString()) Then Return
        Dim _YesNoID As String = Me.cboEligibleForScreeningID.SelectedValue.ToString()
        If Not _YesNoID.ToUpper().Equals(oYesNoID.No.ToUpper()) Then
            Me.stbExclusionReason.Enabled = False
            Me.stbPatientReferedTo.Enabled = False
            Me.dtpReferredDate.Enabled = False
            Me.stbSCRNo.Enabled = True
            Me.stbSID.Enabled = True
            Me.stbPID.Enabled = True
        Else : Me.stbExclusionReason.Enabled = True
            Me.stbPatientReferedTo.Enabled = True
            Me.dtpReferredDate.Enabled = True
            Me.stbSCRNo.Enabled = False
            Me.stbSID.Enabled = False
            Me.stbPID.Enabled = False
        End If
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(patientNo) Then Return

            'Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

            Me.stbLastName.Text = StringEnteredIn(row, "LastName")
            Me.stbFirstName.Text = StringEnteredIn(row, "FirstName")
            Me.stbOtherName.Text = StringMayBeEnteredIn(row, "MiddleName")
            Me.dtpBirthDate.Value = DateEnteredIn(row, "BirthDate")
            Me.nbxAge.Value = StringEnteredIn(row, "Age")
            Me.cboGenderID.SelectedValue = StringEnteredIn(row, "GenderID")
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.SetNextVisitNo(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ' Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub chkUseExistingPatient_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseExistingPatient.CheckedChanged
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ManagePatientStatus(Me.chkUseExistingPatient.Checked)


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub



    Private Sub ManagePatientStatus(ByVal useExistingPatient As Boolean)

        Try

            If useExistingPatient Then
                ResetControlsIn(Me.pnlPatients)
                Me.btnLoad.Enabled = True
                Me.pnlPatients.Enabled = False
                Me.stbPatientNo.Clear()
                Me.stbPatientNo.ReadOnly = False
                'Me.SetDefaultPatientNo()
                Me.btnEnrollFingerprint.Enabled = False
            Else
                Me.pnlPatients.Enabled = True
                Me.btnLoad.Enabled = False
                Me.stbPatientNo.ReadOnly = InitOptions.PatientNoLocked
                Me.btnEnrollFingerprint.Enabled = True
                Me.SetNextPatientNo()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub SetNextPatientNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim selfRequestNoPrefix As String = oVariousOptions.SelfRequestNoPrefix + Today.Year.ToString().Substring(2)

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Patients", "PatientNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextPatientNo As String = CStr(oPatients.GetNextSelfRequestPatientID).PadLeft(paddingLEN, paddingCHAR)
            Dim patientNo As String = FormatText((selfRequestNoPrefix + nextPatientNo).Trim(), "Patients", "PatientNo")

            Me.stbPatientNo.Text = patientNo

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnFindByFingerprint_Click(sender As System.Object, e As System.EventArgs) Handles btnFindByFingerprint.Click
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

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
End Class