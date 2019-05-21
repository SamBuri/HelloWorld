
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports System.IO
Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona
Imports System.Drawing.Printing
Imports GenCode128

Public Class frmPatients

#Region " Fields "
    Private defaultKeyNo As String = String.Empty
    Private enrollmentKeyNo As ItemsKeyNo
    Private oCurrentEnrollmentInformation As CurrentEnrollmentInformation
    Private defaultPatientNo As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False

    Private Const _CashCustomer As String = "Cash Customer"
    Private allergies As DataTable
    Private diagnosis As DataTable
    Private diseases As DataTable
    Private oVariousOptions As New VariousOptions()
    Private oTemplateTypeID As New LookupDataID.TemplateTypeID()

    Private patientNoPrefix As String = oVariousOptions.PatientNoPrefix + Today.Year.ToString().Substring(2)
    Private billCustomers As DataTable
    Private _AlternateNoValue As String = String.Empty
    Private _AllergyNoValue As String = String.Empty
    Private _DiagnosisCode As String = String.Empty


    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docFaceSheet As New PrintDocument()
    'Private WithEvents docFaceSheetReport As New PrintDocument()

    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private facesheetParagraphs As Collection
    Private bioDataParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
    Private WithEvents docBarcodes As New PrintDocument()
    Private WithEvents docBioData As New PrintDocument()
    Private allergy As DataTable
#End Region

#Region " Validations "

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

    Private Sub frmPatients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpBirthDate.Value = Today
            Me.dtpBirthDate.Checked = False
            Me.dtpBirthDate.MaxDate = Today
            Me.dtpJoinDate.MaxDate = Today

            Me.LoadAllergies()
            Me.PatientStatus()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBloodGroupID, LookupObjects.BloodGroup, True)
            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)
            LoadLookupDataCombo(Me.cboMaritalStatusID, LookupObjects.MaritalStatus, True)
            LoadLookupDataCombo(Me.cboCareEntryPointID, LookupObjects.CareEntryPoint, True)
            LoadLookupDataCombo(Me.cboCommunityID, LookupObjects.Community, True)
            LoadLookupDataCombo(Me.cboTribeID, LookupObjects.Tribe, True)
            LoadLookupDataCombo(Me.cboReligionID, LookupObjects.Religion, True)
            LoadLookupDataCombo(Me.clbChronicDiseases, LookupObjects.ChronicDiseases, False)
            LoadLookupDataCombo(Me.cboCountryID, LookupObjects.Countries, True)
            LoadLookupDataCombo(Me.cboNOKRelationship, LookupObjects.NOKRelationship, False)
            LoadLookupDataCombo(Me.cboOccupationID, LookupObjects.OccupationID, False)
            LoadLookupDataCombo(Me.cboEducationLevelID, LookupObjects.EducationAttained, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not String.IsNullOrEmpty(defaultPatientNo) Then
                Me.stbPatientNo.Text = FormatText(defaultPatientNo, "Patients", "PatientNo")
                Me.stbPatientNo.ReadOnly = True
                Me.ProcessTabKey(True)
                Me.Search(defaultPatientNo)
            Else : Me.stbPatientNo.ReadOnly = False
            End If

            If Not oVariousOptions.AllowPrintingPatientFaceSheet Then
                    Me.chkPrintFaceSheetOnSaving.Visible = False
                Else
                    Me.chkPrintFaceSheetOnSaving.Visible = True
            End If

            If Not oVariousOptions.AllowPrintingPatientBioData Then
                Me.chkPrintBioData.Visible = False
                Me.btnprintBioData.Enabled = False
            Else
                Me.chkPrintBioData.Visible = True
                Me.btnprintBioData.Enabled = True
            End If



            If Not String.IsNullOrEmpty(defaultKeyNo) AndAlso enrollmentKeyNo = ItemsKeyNo.UCIID Then

                Me.ShowresearchRoutingFormDetails(defaultKeyNo)
                Me.stbReferenceNo.ReadOnly = True
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)
            Else : Me.stbReferenceNo.ReadOnly = False
            End If

            SetComboDefaultValue(InitOptions.Community, cboCommunityID, LookupObjects.Community)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub setImage(image As Image)
        spbPhoto.Image = image
    End Sub

    Private Sub frmPatients_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not Me.RecordSaved(True) Then
            Dim message As String
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                message = "Current patient is not saved." + ControlChars.NewLine + "Just close anyway?"
            Else : message = "Current patient is not updated." + ControlChars.NewLine + "Just close anyway?"
            End If
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub frmPatients_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowSchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oPatients As New SyncSoft.SQLDb.Patients()

            With oPatients

                .DefaultBillNo = RevertText(StringMayBeEnteredIn(Me.cboDefaultBillNo))
                .ReferenceNo = StringMayBeEnteredIn(Me.stbReferenceNo)
                .Surname = StringMayBeEnteredIn(Me.stbLastName)
                .FirstName = StringMayBeEnteredIn(Me.stbFirstName)
                .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                .BirthDate = DateMayBeEnteredIn(Me.dtpBirthDate)
                .Photo = BytesMayBeEnteredIn(Me.spbPhoto)
                .GenderID = StringValueMayBeEnteredIn(Me.fcbGenderID)
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .Email = StringMayBeEnteredIn(Me.stbEmail)

            End With

            Dim fSchemeMembers As New frmSchemeMembers(oPatients)
            fSchemeMembers.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        Me.GenerateBarcode()

        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
    End Sub

    Private Sub stbPatientNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.Enter
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save OrElse noCallOnKeyEdit Then Return
        If Not Me.RecordSaved(False) Then ProcessTabKey(True)
    End Sub


    Private Sub btnLoadPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto.Click
        Me.spbPhoto.LoadPhoto(Me.spbPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPhoto.Click
        Me.spbPhoto.DeletePhoto()
    End Sub

    Private Sub btnFindMedicalCardNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindMedicalCardNo.Click

        Try

            Dim fFindObject As New frmFindObject(ObjectName.SchemeMembers)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Me.LoadSchemeMember(fFindObject.GetSchemeMember())

        Catch eX As Exception
            ErrorMessage(eX)
            Me.btnFindMedicalCardNo.PerformClick()

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadSchemeMember(ByVal schemeMembers As DataTable)

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()

            If schemeMembers Is Nothing OrElse schemeMembers.Rows.Count < 1 Then Return

            Dim row As DataRow = schemeMembers.Rows(0)

            Me.stbReferenceNo.Text = StringMayBeEnteredIn(row, "ReferenceNo")
            Me.stbLastName.Text = StringMayBeEnteredIn(row, "Surname")
            Me.stbFirstName.Text = StringMayBeEnteredIn(row, "FirstName")
            Me.stbMiddleName.Text = StringMayBeEnteredIn(row, "MiddleName")
            Me.dtpBirthDate.Value = DateMayBeEnteredIn(row, "BirthDate")
            Me.nbxAge.Value = StringMayBeEnteredIn(row, "Age")
            Me.fcbGenderID.SelectedValue = StringMayBeEnteredIn(row, "GenderID")
            Me.dtpJoinDate.Value = DateMayBeEnteredIn(row, "JoinDate")
            Me.stbAddress.Text = StringMayBeEnteredIn(row, "Address")
            Dim poneWork As String = StringMayBeEnteredIn(row, "PhoneWork")
            Dim phoneMobile As String = StringMayBeEnteredIn(row, "PhoneMobile")
            Dim phoneHome As String = StringMayBeEnteredIn(row, "PhoneHome")
            If Not String.IsNullOrEmpty(poneWork) Then
                Me.stbPhone.Text = StringMayBeEnteredIn(row, "PhoneWork")
            ElseIf Not String.IsNullOrEmpty(phoneMobile) Then
                Me.stbPhone.Text = StringMayBeEnteredIn(row, "PhoneMobile")
            ElseIf Not String.IsNullOrEmpty(phoneHome) Then
                Me.stbPhone.Text = StringMayBeEnteredIn(row, "PhoneHome")
            End If
            Me.stbEmail.Text = StringMayBeEnteredIn(row, "Email")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Me.cboDefaultBillModesID.SelectedValue = oBillModesID.Insurance

            Dim medicalCardNo As String = StringMayBeEnteredIn(row, "MedicalCardNo").ToUpper()
            Me.cboDefaultBillNo.Text = FormatText(medicalCardNo, "SchemeMembers", "MedicalCardNo")
            Me.stbDefaultMemberCardNo.Text = FormatText(medicalCardNo, "SchemeMembers", "MedicalCardNo")

            Me.stbDefaultMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "CompanyName")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboDefaultBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboDefaultBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.LoadBillClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillControls()
        Me.cboDefaultBillNo.DataSource = Nothing
        Me.cboDefaultBillNo.Items.Clear()
        Me.cboDefaultBillNo.Text = String.Empty
        Me.ResetBillControls()
    End Sub

    Private Sub ResetBillControls()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.chkCaptureMemberCardNo.Checked = False
    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadCASHCustomer()
                    Me.cboDefaultBillNo.Enabled = False
                    Me.lblDefaultBillNo.Text = "Default Bill Number"
                    Me.stbDefaultMemberCardNo.Enabled = False
                    Me.stbDefaultMainMemberName.Enabled = False

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
                    LoadComboData(Me.cboDefaultBillNo, billCustomers, "BillCustomerFullName")
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboDefaultBillNo.Enabled = True
                    Me.lblDefaultBillNo.Text = "Default Bill Number"
                    Me.stbDefaultMemberCardNo.Enabled = True
                    Me.stbDefaultMainMemberName.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboDefaultBillNo.Enabled = True
                    Me.lblDefaultBillNo.Text = "Default Medical Card No"
                    Me.stbDefaultMemberCardNo.Enabled = False
                    Me.stbDefaultMainMemberName.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAllergies()

        Dim oAllergies As New SyncSoft.SQLDb.Allergies()

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Load from allergies
            allergies = oAllergies.GetAllergies().Tables("Allergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colAllergyNo.Sorted = False
            LoadComboData(Me.colAllergyNo, allergies, "AllergyNo", "AllergyName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PatientStatus()

        Dim oLookupData As New LookupData()
        Dim oGenderID As New LookupDataID.GenderID()
        Dim oStatusID As New LookupCommDataID.StatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDefaultBillModesID, LookupObjects.BillModes, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim genderLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.Gender).Tables("LookupData")

            If genderLookupData IsNot Nothing Then

                For Each row As DataRow In genderLookupData.Rows
                    If Not (oGenderID.Male.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                            oGenderID.Female.ToUpper().Equals(row.Item("DataID").ToString().ToUpper())) Then
                        row.Delete()
                    End If
                Next

                Me.fcbGenderID.DataSource = genderLookupData

                Me.fcbGenderID.DisplayMember = "DataDes"
                Me.fcbGenderID.ValueMember = "DataID"

                Me.fcbGenderID.SelectedIndex = -1
                Me.fcbGenderID.SelectedIndex = -1

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                    oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then

                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.fcbStatusID.DataSource = statusLookupData

            Me.fcbStatusID.DisplayMember = "DataDes"
            Me.fcbStatusID.ValueMember = "DataID"

            Me.fcbStatusID.SelectedValue = oStatusID.Active
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextPatientNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Patients", "PatientNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim nextPatientNo As String = CStr(oPatients.GetNextPatientID).PadLeft(paddingLEN, paddingCHAR)
            Me.stbPatientNo.Text = FormatText((patientNoPrefix + nextPatientNo).Trim(), "Patients", "PatientNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillCustomerName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDefaultBillNo.SelectedIndexChanged, cboDefaultBillNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ResetBillControls()
    End Sub

    Private Sub cboDefaultBillNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDefaultBillNo.Leave
        Me.DetailBillClient()
    End Sub

    Private Sub DetailBillClient()

        Dim message As String
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboDefaultBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Return

                Case oBillModesID.Account.ToUpper()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboDefaultBillNo)))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.cboDefaultBillNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    Me.ResetBillControls()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                        Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "BillCustomerInsurance")
                        Me.chkCaptureMemberCardNo.Checked = BooleanMayBeEnteredIn(row, "CaptureMemberCardNo")
                    Next
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    Try
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.ResetBillControls()
                        Me.stbDefaultMemberCardNo.Clear()
                        Me.stbDefaultMainMemberName.Clear()

                        Dim medicalCardNo As String = StringMayBeEnteredIn(Me.cboDefaultBillNo)
                        If String.IsNullOrEmpty(medicalCardNo) Then Return

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.cboDefaultBillNo.Text = FormatText(medicalCardNo.ToUpper(), "SchemeMembers", "MedicalCardNo")

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim schemeMembers As DataTable = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers")
                        Me.stbDefaultMemberCardNo.Text = medicalCardNo.ToUpper()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _InsuranceSchemes As EnumerableRowCollection(Of DataRow) = schemeMembers.AsEnumerable()
                        Me.stbBillCustomerName.Text = (From data In _InsuranceSchemes Select data.Field(Of String)("CompanyName")).First()
                        Me.stbInsuranceName.Text = (From data In _InsuranceSchemes Select data.Field(Of String)("InsuranceName")).First()
                        Me.stbDefaultMainMemberName.Text = (From data In _InsuranceSchemes Select data.Field(Of String)("MainMemberName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Catch ex As Exception

                        If ex.Message.Contains("The record with") OrElse ex.Message.EndsWith("Scheme Members") Then
                            message = ex.Message + ControlChars.NewLine + "Would you like to register the Scheme Member now?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.ShowSchemeMembers()
                        Else : ErrorMessage(ex)
                        End If

                    End Try

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadCASHCustomer()

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()

            Me.cboDefaultBillModesID.SelectedValue = oBillModesID.Cash
            Me.cboDefaultBillNo.Text = GetLookupDataDes(oBillModesID.Cash).ToUpper()
            Me.stbBillCustomerName.Text = _CashCustomer
            Me.stbInsuranceName.Clear()
            Me.stbDefaultMemberCardNo.Clear()
            Me.stbDefaultMainMemberName.Clear()

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lastName As String = StringMayBeEnteredIn(Me.stbLastName)
                Dim middleName As String = StringMayBeEnteredIn(Me.stbMiddleName)
                Dim firstName As String = StringMayBeEnteredIn(Me.stbFirstName)
                Dim birthDate As Date = DateMayBeEnteredIn(Me.dtpBirthDate)
                Dim genderID As String = StringMayBeEnteredIn(Me.fcbGenderID)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(lastName) OrElse Not String.IsNullOrEmpty(middleName) OrElse
                Not String.IsNullOrEmpty(firstName) OrElse Not birthDate.Equals(AppData.NullDateValue) OrElse
                Not String.IsNullOrEmpty(genderID) Then
                    If Not hideMessage Then DisplayMessage("Please ensure that current patient record is saved!")
                    Me.ebnSaveUpdate.Focus()
                    Me.BringToFront()
                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                    Return False
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update AndAlso Me.ebnSaveUpdate.Enabled Then

                If hideMessage Then Return Not Me.ebnSaveUpdate.Enabled
                Dim message As String = "Current patient is not updated." + ControlChars.NewLine + "Just continue anyway?"
                Dim result As DialogResult = WarningMessage(message)
                If result = Windows.Forms.DialogResult.No Then Return False

            End If

            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

#Region " Fingerprint Enrollment "

    Private Sub btnEnrollFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnrollFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Enroll)
                fFingerprintCapture.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Dim fEnrollment As New Enrollment()
                fEnrollment.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

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

    Private Sub ResetControls()
        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgMiscellaneous)
        ResetControlsIn(Me.grpGeographicalLocation)
        ResetControlsIn(Me.tpgPatientsEXT)
        ResetControlsIn(Me.tpgPatientAllergies)
        ResetControlsIn(Me.tpgMedicalCondtions)
        ResetControlsIn(Me.tpgProvisionalDiagnosis)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oPatients.PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Paient's Number!"))
            DisplayMessage(oPatients.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetControls()

            Me.dtpBirthDate.Value = Today

            Me.oCrossMatchTemplate.Fingerprint = Nothing
            Me.oDigitalPersonaTemplate.Template = Nothing

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CallOnKeyEdit()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.tbcPatients.SelectTab(Me.tpgGeneral.Name)
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's Number"))
            Me.Search(patientNo)

        Catch ex As Exception
            Me.tbcPatients.SelectTab(Me.tpgGeneral.Name)
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowresearchRoutingFormDetails(ByVal uCIID As String)

        Dim oResearchRoutingForm As New SyncSoft.SQLDb.ResearchRoutingForm()
        Dim oVillages As New SyncSoft.SQLDb.Villages()
        Try
            Me.Cursor = Cursors.WaitCursor


            Dim researchRoutingForm As DataTable = oResearchRoutingForm.GetResearchRoutingForm(uCIID).Tables("ResearchRoutingForm")
            Dim row As DataRow = researchRoutingForm.Rows(0)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbReferenceNo.Text = FormatText(uCIID, "ResearchRoutingForm", "UCIID")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFirstName.Text = StringMayBeEnteredIn(row, "FirstName")
            Me.stbLastName.Text = StringMayBeEnteredIn(row, "LastName")
            Me.stbMiddleName.Text = StringMayBeEnteredIn(row, "OtherName")
            Me.fcbGenderID.Text = StringMayBeEnteredIn(row, "Sex")
            Me.dtpBirthDate.Text = StringMayBeEnteredIn(row, "BirthDate")
            Me.nbxAge.Text = StringMayBeEnteredIn(row, "Age")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageCode As String = (From data In researchRoutingForm Select data.Field(Of String)("VillageCode")).First()
            If String.IsNullOrEmpty(villageCode) Then ResetControlsIn(Me.grpGeographicalLocation) : Return

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


        Catch eX As Exception

            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub Search(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVillages As New SyncSoft.SQLDb.Villages()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.grpGeographicalLocation)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dataSource As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Me.DisplayData(dataSource)

            Me.LoadPatientsEXT(patientNo)
            Me.LoadPatientAllergies(patientNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patient As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim fingerprint As Byte() = (From data In patient Select data.Field(Of Byte())("Fingerprint")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Me.oCrossMatchTemplate.Fingerprint = fingerprint
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Me.oDigitalPersonaTemplate.Template = GetDigitalPersonaTemplate(fingerprint)
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim villageCode As String = (From data In patient Select data.Field(Of String)("VillageCode")).First()
            If String.IsNullOrEmpty(villageCode) Then ResetControlsIn(Me.grpGeographicalLocation) : Return

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

        Catch ex As Exception
            Me.tbcPatients.SelectTab(Me.tpgGeneral.Name)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim records As Integer
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim lPatients As New List(Of DBConnect)
            Dim oVariousOptions As New VariousOptions()

            With oPatients

                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's Number!"))
                .ReferenceNo = RevertText(StringMayBeEnteredIn(Me.stbReferenceNo))
                .NationalIDNo = RevertText(StringMayBeEnteredIn(Me.stbNIN))
                .LastName = StringEnteredIn(Me.stbLastName, "Surname!")
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                .BirthDate = DateEnteredIn(Me.dtpBirthDate, "Birth Date!")
                .GenderID = StringValueEnteredIn(Me.fcbGenderID, "Gender!")
                .Photo = BytesMayBeEnteredIn(Me.spbPhoto)

                If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) AndAlso
                     oCrossMatchTemplate.Fingerprint IsNot Nothing Then
                    .Fingerprint = oCrossMatchTemplate.Fingerprint

                ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) AndAlso
                    (oDigitalPersonaTemplate.Template IsNot Nothing) Then
                    .Fingerprint = oDigitalPersonaTemplate.Template.Bytes

                Else : .Fingerprint = Nothing
                End If

                .JoinDate = DateEnteredIn(Me.dtpJoinDate, "Join Date!")


                If oVariousOptions.ForcePatientAddress Then
                    .Phone = StringEnteredIn(Me.stbPhone, "Phone Number!")
                    .NOKName = StringEnteredIn(Me.stbNOKName, "NOK Name!")
                    .NOKRelationship = StringEnteredIn(Me.cboNOKRelationship, "NOK Relationship!")
                    .Address = StringEnteredIn(Me.stbAddress, "Address!")

                Else : .NOKRelationship = StringMayBeEnteredIn(Me.cboNOKRelationship)
                    .Phone = StringMayBeEnteredIn(Me.stbPhone)
                    .NOKName = StringMayBeEnteredIn(Me.stbNOKName)
                    .Address = StringMayBeEnteredIn(Me.stbAddress)
                End If

                .BirthPlace = StringMayBeEnteredIn(Me.stbBirthPlace)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .NOKPhone = StringMayBeEnteredIn(Me.stbNOKPhone)
                .Occupation = StringMayBeEnteredIn(Me.cboOccupationID)
                .Location = StringMayBeEnteredIn(Me.stbLocation)

                .DefaultBillModesID = StringValueEnteredIn(Me.cboDefaultBillModesID, "Default Bill Mode!")
                .DefaultBillNo = RevertText(StringEnteredIn(Me.cboDefaultBillNo, "Default Bill Customer's No!"))
                If .DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso Me.chkCaptureMemberCardNo.Checked Then
                    .DefaultMemberCardNo = StringEnteredIn(Me.stbDefaultMemberCardNo, "Default Member Card No!")
                Else : .DefaultMemberCardNo = StringMayBeEnteredIn(Me.stbDefaultMemberCardNo)
                End If

                If .DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso oVariousOptions.ForceAccountMainMemberName Then
                    .DefaultMainMemberName = StringEnteredIn(Me.stbDefaultMainMemberName, "Default Main Member Name!")
                Else : .DefaultMainMemberName = StringMayBeEnteredIn(Me.stbDefaultMainMemberName)
                End If

                .EnforceDefaultBillNo = Me.chkEnforceDefaultBillNo.Checked
                .HideDetails = Me.chkHideDetails.Checked
                .StatusID = StringValueEnteredIn(Me.fcbStatusID, "Status!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''' Optional Fields '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                .BloodGroupID = StringValueMayBeEnteredIn(Me.cboBloodGroupID, "Blood Group!")
                .MaritalStatusID = StringValueEnteredIn(Me.cboMaritalStatusID, "Marital Status!")
                .CareEntryPointID = StringValueEnteredIn(Me.cboCareEntryPointID, "Care Entry Point!")
                .CommunityID = StringValueEnteredIn(Me.cboCommunityID, "Community!")
                .CountryID = StringValueEnteredIn(Me.cboCountryID, "Country!")
                .EducationLevelID = StringValueEnteredIn(Me.cboEducationLevelID, "Education Level!")
                If oVariousOptions.ForcePatientGeographicalLocation Then
                    StringValueEnteredIn(Me.cboDistrictsID, "District!")
                    StringValueEnteredIn(Me.cboCountyCode, "County!")
                    StringValueEnteredIn(Me.cboSubCountyCode, "Sub County!")
                    StringValueEnteredIn(Me.cboParishCode, "Parish!")
                    .VillageCode = StringValueEnteredIn(Me.cboVillageCode, "Village!")
                Else : .VillageCode = StringValueMayBeEnteredIn(Me.cboVillageCode, "Village!")
                End If

                .TribeID = StringValueMayBeEnteredIn(Me.cboTribeID, "Tribe!")
                .ReligionID = StringValueMayBeEnteredIn(Me.cboReligionID, "Religion!")
                .Employer = StringMayBeEnteredIn(Me.stbEmployer)
                .EmployerAddress = StringMayBeEnteredIn(Me.stbEmployerAddress)
                .ReferringMedicalOfficer = StringMayBeEnteredIn(Me.stbReferringMedicalOfficer)
                .NearestDispensary = StringMayBeEnteredIn(Me.stbNearestDispensary)
                .PreviousAdmissions = StringMayBeEnteredIn(Me.stbPreviousAdmissions)
                .ChronicDiseases = StringToSplitSelectedIn(Me.clbChronicDiseases, LookupObjects.ChronicDiseases)

                .PoliceNotified = Me.chkPoliceNotified.Checked
                .XrayNumbers = DecimalMayBeEnteredIn(Me.nbxXrayNumbers)
                .InfectiousDiseasesNotified = Me.chkInfectiousDiseasesNotified.Checked
                .MedicalConditions = StringMayBeEnteredIn(Me.stbMedicalConditions)
                .ProvisionalDiagnosis = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgGeneral)
                ValidateEntriesIn(Me.tpgMiscellaneous)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lPatients.Add(oPatients)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oPatients.BirthDate.Equals(AppData.NullDateValue) AndAlso Not oPatients.JoinDate.Equals(AppData.NullDateValue) Then
                message = "Join date can't be before birth date!"
                If oPatients.JoinDate < oPatients.BirthDate Then Throw New ArgumentException(message)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oPatients.DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso
               oPatients.DefaultBillNo.ToUpper().Equals(GetLookupDataDes(oBillModesID.Cash).ToUpper()) Then
                Me.cboDefaultBillNo.Focus()
                Throw New ArgumentException("Default Bill No for Bill Mode Account can’t be Cash!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oPatients.DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then ValidateBillCustomerInsuranceDirect(oPatients.DefaultBillNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(oPatients.NationalIDNo.Trim()) Then
                message = "You have not entered the National ID No(NIN) for this Patient. " +
                          "It’s recommended that you enter it for proper Identification. " +
                           ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbNIN.Focus() : Return
            End If

            If String.IsNullOrEmpty(oPatients.Phone.Trim()) Then
                message = "You have not entered a phone number for this Patient. " +
                          "It’s recommended that you enter at least one phone number for contact purposes. " +
                           ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbPhone.Focus() : Return
            End If


            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.IncorporateFingerprintCapture Then
                        If (oPatients.Fingerprint Is Nothing) Then
                            If InitOptions.ForceFingerprintCapture Then
                                Dim age As Integer = GetAge(oPatients.BirthDate)
                                If age >= oVariousOptions.FingerprintCaptureAgeLimit Then
                                    message = "You have not enrolled fingerprint for this Patient. " +
                                           "The system does not allow registration of a patient without a fingerprint!"
                                    Throw New ArgumentException(message)
                                Else
                                    message = "You have not enrolled fingerprint for this Patient. " +
                                              "The system has noted that this patient is below the set fingerprint capture age limit of " +
                                              oVariousOptions.FingerprintCaptureAgeLimit.ToString() + " year(s). " +
                                              "However, it’s recommended that you enroll fingerprint for verification purposes. " +
                                         ControlChars.NewLine + "Are you sure you want to save?"
                                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                                End If
                            Else
                                message = "You have not enrolled fingerprint for this Patient. " +
                                          "It’s recommended that you enroll fingerprint for verification purposes. " +
                                           ControlChars.NewLine + "Are you sure you want to save?"
                                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.btnEnrollFingerprint.Focus() : Return
                            End If
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If patientNoPrefix.ToUpper().Equals(oPatients.PatientNo.Substring(0, patientNoPrefix.Length)) Then
                        Dim currentPatientID As Integer
                        If Integer.TryParse(oPatients.PatientNo.Substring(patientNoPrefix.Length), currentPatientID) Then
                            Dim nextPatientID As Integer = oPatients.GetNextPatientID()
                            If currentPatientID > nextPatientID Then
                                message = "You have set the Patient No higher than the current number sequence; " +
                                          "this is going to alter the global sequence of all the numbers." +
                                           ControlChars.NewLine + "Are you sure that this is the right thing to do?"
                                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbPatientNo.Focus() : Return
                            End If
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If IsCharacterInString(oPatients.PatientNo) Then
                        message = "Patient No contains a space (' '), an invalid character. " +
                                   ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbPatientNo.Focus() : Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oPatients.IsFullNameSaved(oPatients.FullName) Then
                        message = "You already have a patient with the name " + oPatients.FullName +
                                   ControlChars.NewLine + "Are you sure this is a different person?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lPatients, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PatientsEXTList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PatientAllergiesList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    message = "Patient No : " + FormatText(oPatients.PatientNo, "Patients", "PatientNo") +
                              ", was successfully assigned to " + oPatients.FullName + "!"

                    DisplayMessage(message)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.SMSNotificationAtPatientRegistration Then
                        If stbPhone.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhone.Text) Then
                            Dim productOwner As String = AppData.ProductOwner
                            Dim recipients As String = oPatients.Phone
                            Dim txtmessage As String = ("Hi" + " " + oPatients.FirstName + " " + oPatients.PatientNo + " " + "is your PatientNo present it everytime you visit " + " " + productOwner + " " + "-Via ClinicMaster")
                            SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanPatientReg)
                        End If
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.AllowPrintingPatientFaceSheet Then
                        If chkPrintFaceSheetOnSaving.Checked = False Then
                            message = "You have not checked Print FaceSheet On Saving. " + ControlChars.NewLine + "Would you want a FaceSheet printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.Printfacesheet(True)
                        Else : Me.Printfacesheet(True)
                        End If
                    End If

                    If oVariousOptions.AllowPrintingPatientBioData Then
                        If chkPrintBioData.Checked = False Then
                            message = "You have not checked Print Bio Data On Saving. " + ControlChars.NewLine + "Would you want the Client Bio Data printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintBioData(True)
                        Else : Me.PrintBioData(True)
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.EnableRegistrationShortCuts Then

                        message = "Would you like to open visits registration form now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                            Dim fVisits As New frmVisits(oPatients.PatientNo, ItemsKeyNo.PatientNo)
                            fVisits.Save()
                            fVisits.ShowDialog()
                        End If
                    Else

                        Dim fOpenOptions As New frmOpenOptions(oPatients.PatientNo)
                        fOpenOptions.ShowDialog()

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetControls()
                    Me.dtpBirthDate.Value = Today
                    Me.dtpJoinDate.Value = Today
                    Me.dtpJoinDate.Checked = True
                    Me.SetNextPatientNo()
                    Me.LoadCASHCustomer()
                    Me.oCrossMatchTemplate.Fingerprint = Nothing
                    Me.oDigitalPersonaTemplate.Template = Nothing
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.IncorporateFingerprintCapture Then
                        If (oPatients.Fingerprint Is Nothing) Then
                            message = "You have not enrolled fingerprint for this Patient. " +
                                      "It’s recommended that you enroll fingerprint for verification purposes. " +
                                       ControlChars.NewLine + "Are you sure you want to update?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.btnEnrollFingerprint.Focus() : Return
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oPatients.BirthDate.Equals(AppData.NullDateValue) Then
                        message = "This Patient has an unknown Date of Birth value registered. " +
                                   "It’s recommended that you enter a correct Date of Birth. " +
                                    ControlChars.NewLine + "Would you like to correct it now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.dtpBirthDate.Focus() : Return
                    End If

                    If oPatients.JoinDate.Equals(AppData.NullDateValue) Then
                        message = "This Patient has an unknown Join Date value registered. " +
                                  "It’s recommended that you enter a correct Join Date. " +
                                   ControlChars.NewLine + "Would you like to correct it now?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.dtpJoinDate.Focus() : Return
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.AllowPrintingPatientFaceSheet Then
                        If chkPrintFaceSheetOnSaving.Checked = False Then
                            message = "You have not checked Print FaceSheet On Saving. " + ControlChars.NewLine + "Would you want a FaceSheet printed?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.Printfacesheet(True)
                        Else : Me.Printfacesheet(True)
                        End If
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lPatients, Action.Update, "Patients"))
                    transactions.Add(New TransactionList(Of DBConnect)(PatientsEXTList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PatientAllergiesList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPatientsEXT.RowCount - 2
                Me.dgvPatientsEXT.Item(Me.colPatientsEXTSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2
                Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If eX.Message.Contains("The Patient No:") OrElse eX.Message.EndsWith("already exists") Then
                message = "The Patient No: " + Me.stbPatientNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine _
                        + "If you are using the system generated number, probably another user has already taken it." + ControlChars.NewLine _
                        + "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextPatientNo()
                Me.GenerateBarcode()
            Else : ErrorMessage(eX)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnLoadCamera_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadCamera.Click
        frmCamera.SetControl(spbPhoto)
        frmCamera.ShowDialog()
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.Search(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function PatientsEXTList() As List(Of DBConnect)

        Dim lPatientsEXT As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvPatientsEXT.RowCount - 2

                Using oPatientsEXT As New SyncSoft.SQLDb.PatientsEXT()

                    Dim cells As DataGridViewCellCollection = Me.dgvPatientsEXT.Rows(rowNo).Cells

                    With oPatientsEXT

                        .PatientNo = patientNo
                        .AlternateNo = StringEnteredIn(cells, Me.colAlternateNo, "Alternate No!")
                        .Notes = StringMayBeEnteredIn(cells, Me.colNotes)

                    End With

                    lPatientsEXT.Add(oPatientsEXT)

                End Using

            Next

            Return lPatientsEXT

        Catch ex As Exception
            Me.tbcPatients.SelectTab(Me.tpgPatientsEXT.Name)
            Throw ex

        End Try

    End Function

    Private Function PatientAllergiesList() As List(Of DBConnect)

        Dim lPatientAllergies As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2

                Using oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()

                    Dim cells As DataGridViewCellCollection = Me.dgvPatientAllergies.Rows(rowNo).Cells

                    With oPatientAllergies

                        .PatientNo = patientNo
                        .AllergyNo = StringEnteredIn(cells, Me.colAllergyNo, "Allergy No!")
                        .Reaction = StringMayBeEnteredIn(cells, Me.colReaction)

                    End With

                    lPatientAllergies.Add(oPatientAllergies)

                End Using

            Next

            Return lPatientAllergies

        Catch ex As Exception
            Me.tbcPatients.SelectTab(Me.tpgPatientAllergies.Name)
            Throw ex

        End Try

    End Function

#Region " PatientsEXT - Grid "

    Private Sub dgvPatientsEXT_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPatientsEXT.CellBeginEdit
        If e.ColumnIndex <> Me.colAlternateNo.Index OrElse Me.dgvPatientsEXT.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPatientsEXT.CurrentCell.RowIndex
        _AlternateNoValue = StringMayBeEnteredIn(Me.dgvPatientsEXT.Rows(selectedRow).Cells, Me.colAlternateNo)
    End Sub

    Private Sub dgvPatientsEXT_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPatientsEXT.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colAlternateNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPatientsEXT.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPatientsEXT.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPatientsEXT.Rows(selectedRow).Cells, Me.colAlternateNo)

                    If CBool(Me.dgvPatientsEXT.Item(Me.colPatientsEXTSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Alternate No (" + _AlternateNoValue + ") can't be edited!")
                        Me.dgvPatientsEXT.Item(Me.colAlternateNo.Name, selectedRow).Value = _AlternateNoValue
                        Me.dgvPatientsEXT.Item(Me.colAlternateNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPatientsEXT.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPatientsEXT.Rows(rowNo).Cells, Me.colAlternateNo)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Alternate No (" + enteredItem + ") already entered!")
                                Me.dgvPatientsEXT.Item(Me.colAlternateNo.Name, selectedRow).Value = _AlternateNoValue
                                Me.dgvPatientsEXT.Item(Me.colAlternateNo.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvPatientsEXT_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPatientsEXT.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPatientsEXT As New SyncSoft.SQLDb.PatientsEXT()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPatientsEXT.Item(Me.colPatientsEXTSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim alternateNo As String = CStr(Me.dgvPatientsEXT.Item(Me.colAlternateNo.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.btnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPatientsEXT
                .PatientNo = patientNo
                .AlternateNo = alternateNo
            End With

            DisplayMessage(oPatientsEXT.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPatientsEXT(ByVal PatientNo As String)

        Dim patientsEXT As New DataTable()
        Dim oPatientsEXT As New SyncSoft.SQLDb.PatientsEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            patientsEXT = oPatientsEXT.GetPatientsEXT(RevertText(PatientNo)).Tables("PatientsEXT")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPatientsEXT, patientsEXT)

            For Each row As DataGridViewRow In Me.dgvPatientsEXT.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPatientsEXT.Item(Me.colPatientsEXTSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " PatientAllergies - Grid "

    Private Sub dgvPatientAllergies_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPatientAllergies.CellBeginEdit

        If e.ColumnIndex <> Me.colAllergyNo.Index OrElse Me.dgvPatientAllergies.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPatientAllergies.CurrentCell.RowIndex
        _AllergyNoValue = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(selectedRow).Cells, Me.colAllergyNo)

    End Sub

    Private Sub dgvPatientAllergies_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPatientAllergies.CellEndEdit

        Try

            If Me.colAllergyNo.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colAllergyNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPatientAllergies.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPatientAllergies.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(selectedRow).Cells, Me.colAllergyNo)

                    If CBool(Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, selectedRow).Value).Equals(True) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Allergies As EnumerableRowCollection(Of DataRow) = allergies.AsEnumerable()
                        Dim allergyDisplay As String = (From data In _Allergies _
                                            Where data.Field(Of String)("AllergyNo").ToUpper().Equals(_AllergyNoValue.ToUpper()) _
                                            Select data.Field(Of String)("AllergyName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Allergy (" + allergyDisplay + ") can't be edited!")
                        Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Value = _AllergyNoValue
                        Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPatientAllergies.Rows(rowNo).Cells, Me.colAllergyNo)
                            If enteredItem.Equals(selectedItem) Then
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Alergies As EnumerableRowCollection(Of DataRow) = allergies.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Alergies _
                                                    Where data.Field(Of String)("AllergyNo").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("AllergyName")).First()
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Allergy (" + enteredDisplay + ") already entered!")
                                Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Value = _AllergyNoValue
                                Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If allergies Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

                    For Each row As DataRow In allergies.Select("AllergyNo = '" + selectedItem + "'")
                        Me.dgvPatientAllergies.Item(Me.colAllergyCategory.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AllergyCategory")
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvPatientAllergies_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPatientAllergies.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim allergyNo As String = CStr(Me.dgvPatientAllergies.Item(Me.colAllergyNo.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.btnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oPatientAllergies
                .PatientNo = patientNo
                .AllergyNo = allergyNo
            End With

            DisplayMessage(oPatientAllergies.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPatientAllergies(ByVal patientNo As String)

        Dim oPatientAllergies As New SyncSoft.SQLDb.PatientAllergies()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientAllergies As DataTable = oPatientAllergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPatientAllergies, patientAllergies)

            For Each row As DataGridViewRow In Me.dgvPatientAllergies.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnPrintBarcode.Visible = True
        Me.btnSearch.Visible = True
        Me.btnprintBioData.Visible = True
        Me.btnLoad.Enabled = True
        Me.btnLoad.Visible = True
        Me.stbPatientNo.ReadOnly = False
        Me.pnlStatusID.Enabled = True
        Me.btnFindMedicalCardNo.Enabled = False

        ResetControlsIn(Me.pnlStatusID)
        ResetControlsIn(Me.pnlBloodGroupID)
        ResetControlsIn(Me.pnlTribeID)
        ResetControlsIn(Me.pnlReligionID)

        Me.ResetControls()
        Me.oCrossMatchTemplate.Fingerprint = Nothing
        Me.oDigitalPersonaTemplate.Template = Nothing

    End Sub

    Public Sub Save()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False
        Me.btnprintBioData.Visible = False
        Me.btnPrintBarcode.Visible = False
        Me.btnLoad.Visible = False
        Me.stbPatientNo.ReadOnly = InitOptions.PatientNoLocked
        Me.pnlStatusID.Enabled = False
        Me.btnFindMedicalCardNo.Enabled = True

        Me.ResetControls()
        Me.dtpJoinDate.Value = Today
        Me.dtpJoinDate.Checked = True

        Me.PatientStatus()
        Me.SetNextPatientNo()

        Me.LoadCASHCustomer()
        Me.oCrossMatchTemplate.Fingerprint = Nothing
        Me.oDigitalPersonaTemplate.Template = Nothing

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


#Region "Print FaceSheet"

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

            Dim fullNameFacesheet As String

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " PATIENT'S FACESHEET".ToUpper()



            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim fName As String = StringMayBeEnteredIn(Me.stbFirstName)
            Dim lName As String = StringMayBeEnteredIn(Me.stbLastName)
            Dim oName As String = StringMayBeEnteredIn(Me.stbMiddleName)
            Dim gender As String = StringMayBeEnteredIn(Me.fcbGenderID)
            Dim careEntryPoint As String = StringMayBeEnteredIn(Me.cboCareEntryPointID)
            Dim nationalIDNo As String = StringMayBeEnteredIn(Me.stbNIN)
            Dim nin As String = StringMayBeEnteredIn(Me.stbNIN)
            Dim refNo As String = StringMayBeEnteredIn(Me.stbReferenceNo)


            If Not String.IsNullOrEmpty(oName) Then
                fullNameFacesheet = (lName + " " + oName + " " + fName).ToUpper
            Else : fullNameFacesheet = (lName + " " + fName).ToUpper
            End If

            Dim age As String = StringMayBeEnteredIn(Me.nbxAge)
            Dim dob As String = FormatDate(DateMayBeEnteredIn(Me.dtpBirthDate))
            Dim joinDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpJoinDate))
            Dim tribe As String = StringMayBeEnteredIn(Me.cboTribeID)
            Dim religion As String = StringMayBeEnteredIn(Me.cboReligionID)
            Dim employer As String = StringMayBeEnteredIn(Me.stbEmployer)
            Dim employerAddress As String = StringMayBeEnteredIn(Me.stbEmployerAddress)
            Dim referringMedicalOfficer As String = StringMayBeEnteredIn(Me.stbReferringMedicalOfficer)
            Dim nearestDispensary As String = StringMayBeEnteredIn(Me.stbNearestDispensary)
            Dim previousAdmissions As String = StringMayBeEnteredIn(Me.stbPreviousAdmissions)
            Dim district As String = StringMayBeEnteredIn(Me.cboDistrictsID)
            Dim county As String = StringMayBeEnteredIn(Me.cboCountyCode)
            Dim subCounty As String = StringMayBeEnteredIn(Me.cboSubCountyCode)
            Dim parish As String = StringMayBeEnteredIn(Me.cboParishCode)
            Dim villageCode As String = StringMayBeEnteredIn(Me.cboVillageCode)
            Dim address As String = StringMayBeEnteredIn(Me.stbAddress)
            Dim phone As String = StringMayBeEnteredIn(Me.stbPhone)
            Dim birthPlace As String = StringMayBeEnteredIn(Me.stbBirthPlace)
            Dim email As String = StringMayBeEnteredIn(Me.stbEmail)
            Dim nOKName As String = StringMayBeEnteredIn(Me.stbNOKName)
            Dim nOKRelationship As String = StringEnteredIn(Me.cboNOKRelationship)
            Dim nOKPhone As String = StringMayBeEnteredIn(Me.stbNOKPhone)
            Dim occupation As String = StringMayBeEnteredIn(Me.cboOccupationID)
            Dim maritalStatus As String = StringMayBeEnteredIn(Me.cboMaritalStatusID)
            Dim careEntry As String = StringMayBeEnteredIn(Me.cboCareEntryPointID)
            Dim educationLevel As String = StringMayBeEnteredIn(Me.cboEducationLevelID)
            Dim policeNotified As Boolean = (Me.chkPoliceNotified.Checked)
            Dim policeNotification As String
            If policeNotified = False Then
                policeNotification = "No"
            Else
                policeNotification = "Yes"
            End If


            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

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

                    ''Draw the patient Picture
                    If spbPhoto.Image IsNot Nothing Then

                        Dim imagerect As New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        e.Graphics.DrawRectangle(Pens.White, imagerect)
                        Dim imageheight, imagewidth As Integer
                        imagewidth = spbPhoto.Width
                        imageheight = spbPhoto.Height
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), imagewidth, imageheight)
                        e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        e.Graphics.DrawImage(spbPhoto.Image, imagerect)
                        e.Graphics.DrawRectangle(Pens.White, imagerect)
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), 280, 15)
                    End If
                   
                    yPos += 8 * lineHeight
                    .DrawString("Patient Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullNameFacesheet, bodyBoldFont, Brushes.Black, widthTopThird, yPos)
                    yPos += lineHeight

                    .DrawString("Registration No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, widthTopSecond + 35, yPos)
                    .DrawString("National ID No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nationalIDNo, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight


                    .DrawString("Radiotherapy No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(refNo, bodyBoldFont, Brushes.Black, widthTopSecond + 35, yPos)

                    .DrawString("Care Entry Point: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(careEntryPoint, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("Phone: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(phone, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight
                    .DrawString("D.O.B: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(dob, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("Join Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(joinDate, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Religion: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(religion, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("District: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(district, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight
                   
                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("Birth Place: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(birthPlace, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    '
                    .DrawString("Tribe: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(tribe, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("County: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(county, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("SubCounty: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(subCounty, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("Village: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(villageCode, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight


                    .DrawString("Address: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(address, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)
                    .DrawString("NOK Name: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nOKName, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("NOK Phone: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(nOKPhone, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)

                    .DrawString("NOK Relation: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nOKRelationship, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight
                    .DrawString("Occupation: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(occupation, bodyBoldFont, Brushes.Black, widthTopSecond, yPos)
                    .DrawString("Employer: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(employer, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight
                    .DrawString("Previous Admissions: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(previousAdmissions, bodyBoldFont, Brushes.Black, widthTopFifth, yPos)
                    .DrawString("Employer Address: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(employerAddress, bodyBoldFont, Brushes.Black, widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Police Notified: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(policeNotification, bodyBoldFont, Brushes.Black, widthTopFifth, yPos)
                    .DrawString("Refering Medical Officer: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(referringMedicalOfficer, bodyBoldFont, Brushes.Black, widthTopSixth, yPos)
                    yPos += lineHeight

                    .DrawString("Nearest Dispensary: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nearestDispensary, bodyBoldFont, Brushes.Black, widthTopSixth, yPos)
                    yPos += lineHeight

                    .DrawString("Education Level: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(educationLevel, bodyBoldFont, Brushes.Black, widthTopSixth, yPos)
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

        Dim xrayNos As String = StringMayBeEnteredIn(Me.nbxXrayNumbers)
        Dim provisionalDiagnosis As String = StringMayBeEnteredIn(Me.stbProvisionalDiagnosis)
        Dim infectiousdiseases As Boolean = (Me.chkInfectiousDiseasesNotified.Checked)
        Dim InfectiousDiseasesNotified As String
        If infectiousdiseases = False Then
            InfectiousDiseasesNotified = "No"
        Else
            InfectiousDiseasesNotified = "Yes"
        End If

        pageNo = 0
        facesheetParagraphs = New Collection()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' facesheetParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.docFaceSheet.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim tempfields As New System.Text.StringBuilder(String.Empty)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("Infectious disease notified:" + " " + InfectiousDiseasesNotified)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("X-ray Numbers:" + " " + xrayNos)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("Consultants:" + GetCharacters("."c, 12))
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Registrar:" + GetCharacters("."c, 12))
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Houseman: " + GetCharacters("."c, 12))
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("Provisional Diagnosis: " + " " + provisionalDiagnosis)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("FINAL DIAGONOSES & OPERATIONS" + GetCharacters("."c, 50))
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Classification:" + GetCharacters("."c, 15))
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("FINAL DIAGONOSES & OPERATIONS" + GetCharacters("."c, 50))
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Classification:" + GetCharacters("."c, 15))
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("FINAL DIAGONOSES & OPERATIONS" + GetCharacters("."c, 50))
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Classification:" + GetCharacters("."c, 15))
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("RESULT:")
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Cured")
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Improved")
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Unimproved")
            tempfields.Append(GetSpaces(2))
            tempfields.Append("Died")
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("SUMMARY" + GetCharacters("."c, 120))
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append(ControlChars.NewLine)
            tempfields.Append("Signature" + GetCharacters("."c, 20))
            facesheetParagraphs.Add(New PrintParagraps(bodyNormalFont, tempfields.ToString()))
            tempfields.Append(ControlChars.NewLine)

            Dim authorizations As New System.Text.StringBuilder(String.Empty)
            authorizations.Append(ControlChars.NewLine)
            authorizations.Append("AUTHORIZATIONS".ToUpper())
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, authorizations.ToString()))
            authorizations.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim surgicaltitle As New System.Text.StringBuilder(String.Empty)

            surgicaltitle.Append("A. SURGICAL AND/OR MEDICAL TREATMENT".ToUpper())
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, surgicaltitle.ToString()))
            surgicaltitle.Append(ControlChars.NewLine)
            surgicaltitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim surgicalData As New System.Text.StringBuilder(String.Empty)
            surgicalData.Append("I,   " + GetCharacters("."c, 25))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Having been/admitted my: " + GetCharacters("."c, 25))
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("(stated relationship) as a patient Uganda Cancer Institute consect to")
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("Dr" + GetCharacters("."c, 40))
            surgicalData.Append("and/or any other surgeon and/or physician in whose care I shall be from time to time, doing and performing all such treatments,such as anaesthexia, and the performing of such operations as they or any of them consider necessary or desirable in the best interest of my/his/her health.")
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("Signature (Patient /Patient Next of Kin):   " + GetCharacters("."c, 20))
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append(ControlChars.NewLine)
            surgicalData.Append("Witness:   " + GetCharacters("."c, 15))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Thumbprint:   " + GetCharacters("."c, 15))
            surgicalData.Append(GetSpaces(2))
            surgicalData.Append("Date:  " + GetCharacters("."c, 15))
            surgicalData.Append(ControlChars.NewLine)

            facesheetParagraphs.Add(New PrintParagraps(footerFont, surgicalData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dischargetitle As New System.Text.StringBuilder(String.Empty)
            dischargetitle.Append(ControlChars.NewLine)
            dischargetitle.Append(ControlChars.NewLine)
            dischargetitle.Append("B. DISCHARGE AGAINST ADVICE".ToUpper())
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, dischargetitle.ToString()))
            dischargetitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dischargeData As New System.Text.StringBuilder(String.Empty)
            dischargeData.Append("I,   " + GetCharacters("."c, 25))
            dischargeData.Append(GetSpaces(2))
            dischargeData.Append("Have refused to consent to the treatment/operation")
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append("and advised for myself/child/relative" + GetCharacters("."c, 25))
            dischargeData.Append("and request discharge from hospital of myself/child/relative without such treatment.")
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append("Signature (Patient/Patient Next of Kin):   " + GetCharacters("."c, 30))
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append(ControlChars.NewLine)
            dischargeData.Append("Witness:   " + GetCharacters("."c, 15))
            dischargeData.Append(GetSpaces(2))
            dischargeData.Append("Thumbprint:   " + GetCharacters("."c, 15))
            dischargeData.Append(GetSpaces(2))
            dischargeData.Append("Date:  " + GetCharacters("."c, 15))
            dischargeData.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(footerFont, dischargeData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sterilizationtitle As New System.Text.StringBuilder(String.Empty)
            sterilizationtitle.Append(ControlChars.NewLine)
            sterilizationtitle.Append(ControlChars.NewLine)
            sterilizationtitle.Append("C. STERILIZATION".ToUpper())
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, sterilizationtitle.ToString()))
            sterilizationtitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim sterilizationData As New System.Text.StringBuilder(String.Empty)
            sterilizationData.Append("I,   " + GetCharacters("."c, 25))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Husband of the undersigned,consent to the sterization of my wife,")
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("whose Name is" + GetCharacters("."c, 25))
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("if the surgeon considers this necessary. I understand the implications And that such sterilization is permanent.")
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("Signature (husband): " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Thumbprint: " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Date: " + GetCharacters("."c, 10))
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("I,   " + GetCharacters("."c, 25))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Wife of the above named signatory,consent to the operation of sterilization being carried out on myself if the surgeon considers this necessary")
            sterilizationData.Append(ControlChars.NewLine)
            sterilizationData.Append("Signature (Wife): " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Thumbprint: " + GetCharacters("."c, 15))
            sterilizationData.Append(GetSpaces(2))
            sterilizationData.Append("Date:  " + GetCharacters("."c, 10))
            sterilizationData.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(footerFont, sterilizationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amputationtitle As New System.Text.StringBuilder(String.Empty)
            amputationtitle.Append(ControlChars.NewLine)
            amputationtitle.Append(ControlChars.NewLine)
            amputationtitle.Append("D. AMPUTATION".ToUpper())
            facesheetParagraphs.Add(New PrintParagraps(bodyBoldFont, amputationtitle.ToString()))
            amputationtitle.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim amputationData As New System.Text.StringBuilder(String.Empty)
            amputationData.Append("I,   " + GetCharacters("."c, 25))
            amputationData.Append(GetSpaces(2))
            amputationData.Append(", hereby given my consent of the approval by ")
            amputationData.Append("operation of from myself/from" + GetCharacters("."c, 25) + "my relative in accordance with medical advice.")
            amputationData.Append(ControlChars.NewLine)
            amputationData.Append(ControlChars.NewLine)
            amputationData.Append("Signature (Patient/Patient Next of Kin):   " + GetCharacters("."c, 30))
            amputationData.Append(ControlChars.NewLine)
            amputationData.Append(ControlChars.NewLine)
            amputationData.Append("Witness:   " + GetCharacters("."c, 15))
            amputationData.Append(GetSpaces(2))
            amputationData.Append("Thumbprint:   " + GetCharacters("."c, 15))
            amputationData.Append(GetSpaces(2))
            amputationData.Append("Date:  " + GetCharacters("."c, 15))
            amputationData.Append(ControlChars.NewLine)
            facesheetParagraphs.Add(New PrintParagraps(footerFont, amputationData.ToString()))

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

#Region "Barcode Details"

    Private Sub GenerateBarcode()
        Try
            Dim imageweight As Integer = 2
            'Barcode using the GenCode128
            If Not String.IsNullOrEmpty(stbPatientNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(stbPatientNo.Text.ToString(), Integer.Parse(imageweight.ToString()), True)
                imgIDAutomation.Image = barcodeImage
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub docBarcodes_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBarcodes.PrintPage
        Try
            If imgIDAutomation IsNot Nothing Then

                Dim rect As New Rectangle(0, 10, 200, 85)
                Dim sf As New StringFormat
                sf.LineAlignment = StringAlignment.Center
                Dim printFont10_Normal As New Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point)
                rect = New Rectangle(0, 10, 200, 15)
                e.Graphics.DrawRectangle(Pens.White, rect)

                Dim h, w As Integer


                w = imgIDAutomation.Width
                h = imgIDAutomation.Height
                rect = New Rectangle(0, 0, w, h)
                e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                e.Graphics.DrawImage(imgIDAutomation.Image, rect)
                rect = New Rectangle(35, 0, w, 125)
                e.Graphics.DrawString(stbPatientNo.Text.ToString(), printFont10_Normal, Brushes.Black, rect, sf)
                
                e.Graphics.DrawRectangle(Pens.White, rect)


            End If
        Catch ex As Exception

            Throw (ex)
        End Try

    End Sub

    Private Sub stbPatientNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.Leave
        Try
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnPrintBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintBarcode.Click
        Dim dlgPrint As New PrintDialog()

        Try

            If imgIDAutomation IsNot Nothing Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                dlgPrint.Document = docBarcodes

                dlgPrint.Document.PrinterSettings.Collate = True
                If dlgPrint.ShowDialog = DialogResult.OK Then docBarcodes.Print()
            Else
                MessageBox.Show("No Barcode Information is available")
            End If
        Catch ex As Exception
            Throw ex

        End Try
    End Sub

#End Region

#Region "Print Patient Bio Data"

    Private Sub PrintBioData(ByVal facesheetSaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetBioPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim title As String = AppData.ProductOwner.ToUpper() + " Client Bio Data".ToUpper()

            Dim lName As String = StringMayBeEnteredIn(Me.stbLastName)
            Dim fName As String = StringMayBeEnteredIn(Me.stbFirstName)
            Dim mName As String = StringMayBeEnteredIn(Me.stbMiddleName)
            Dim gender As String = StringMayBeEnteredIn(Me.fcbGenderID)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim nin As String = StringMayBeEnteredIn(Me.stbNIN)
            Dim age As String = StringMayBeEnteredIn(Me.nbxAge)
            Dim passportphoto As Image = Me.spbPhoto.Image
            Dim patientbarcode As Image = Me.imgIDAutomation.Image
            Dim nationality As String = StringMayBeEnteredIn(Me.cboCountryID)
            Dim religion As String = StringMayBeEnteredIn(Me.cboReligionID)
            Dim tribe As String = StringMayBeEnteredIn(Me.cboTribeID)
            Dim address As String = StringMayBeEnteredIn(Me.stbAddress)
            Dim marital As String = StringMayBeEnteredIn(Me.cboMaritalStatusID)
            Dim phone As String = StringMayBeEnteredIn(Me.stbPhone)
            Dim email As String = StringMayBeEnteredIn(Me.stbEmail)
            Dim occupation As String = StringMayBeEnteredIn(Me.cboOccupationID)
            Dim nok As String = StringMayBeEnteredIn(Me.stbNOKName)
            Dim nokrelation As String = StringMayBeEnteredIn(Me.cboNOKRelationship)
            Dim nokphone As String = StringMayBeEnteredIn(Me.stbNOKPhone)
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

                    ''Draw the patient Picture
                    If spbPhoto.Image IsNot Nothing Then

                        Dim imagerect As New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        e.Graphics.DrawRectangle(Pens.White, imagerect)
                        Dim imageheight, imagewidth As Integer
                        imagewidth = spbPhoto.Width
                        imageheight = spbPhoto.Height
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), imagewidth, imageheight)
                        e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        e.Graphics.DrawImage(spbPhoto.Image, imagerect)
                        e.Graphics.DrawRectangle(Pens.White, imagerect)
                        imagerect = New Rectangle(CInt(xPos), CInt(yPos), 280, 15)
                    End If
                    ''Draw the barcode
                    If imgIDAutomation.Image IsNot Nothing Then
                        Dim rect As New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        rect = New Rectangle(CInt(xPos), CInt(yPos), CInt(xPos), CInt(yPos))
                        e.Graphics.DrawRectangle(Pens.White, rect)
                        Dim h, w As Integer
                        w = imgIDAutomation.Width
                        h = imgIDAutomation.Height
                        If spbPhoto.Image IsNot Nothing Then
                            rect = New Rectangle(CInt(xPos + 100), CInt(yPos), w, h)
                        Else
                            rect = New Rectangle(CInt(xPos), CInt(yPos), w, h)
                        End If
                        e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        e.Graphics.DrawImage(imgIDAutomation.Image, rect)
                    
                    End If
                    yPos += 8 * lineHeight


                    .DrawString("Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(lName + " " + mName + " " + fName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight
                    .DrawString("National ID No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(nin, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Nationality: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(nationality, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Religion: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(religion, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Tribe: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(tribe, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Marital Status: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(marital, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Address: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(address, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    ''baby

                    .DrawString("Phone: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(phone, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Email: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(email, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Occupation: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(occupation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("NOK: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nok, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("NOK Relation: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(nokrelation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("NOK Phone: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(nokphone, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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

    Private Sub SetBioPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        bioDataParagraphs = New Collection()

        Try


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dataclerkSignData As New System.Text.StringBuilder(String.Empty)
            dataclerkSignData.Append(ControlChars.NewLine)
            dataclerkSignData.Append(ControlChars.NewLine)

            dataclerkSignData.Append("Sign:   " + GetCharacters("."c, 20))
            dataclerkSignData.Append(GetSpaces(4))
            dataclerkSignData.Append("Date:  " + GetCharacters("."c, 20))
            dataclerkSignData.Append(ControlChars.NewLine)
            bioDataParagraphs.Add(New PrintParagraps(footerFont, dataclerkSignData.ToString()))

            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            bioDataParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function AllergiesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvPatientAllergies.RowCount - 1

                If CBool(Me.dgvPatientAllergies.Item(Me.colPatientAllergiesSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPatientAllergies.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim biodataDisplay As String = StringMayBeEnteredIn(cells, Me.colAllergyNo)
                    'Dim _allergy As EnumerableRowCollection(Of DataRow) = allergy.AsEnumerable()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colReaction)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedbiodataDisplay As List(Of String) = WrapText(biodataDisplay, padService)
                    If wrappedbiodataDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedbiodataDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedbiodataDisplay(pos).Trim(), padService))
                            If pos = wrappedbiodataDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(biodataDisplay, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


#End Region



    Private Sub btnprintBioData_Click(sender As System.Object, e As System.EventArgs) Handles btnprintBioData.Click
        Try
            Dim message As String = "No Patient Details to Print"
            Me.Cursor = Cursors.WaitCursor
            If stbPatientNo.Text IsNot Nothing Then
                Me.PrintBioData(True)
            Else
                MessageBox.Show(message)
            End If


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnViewClients_Click(sender As System.Object, e As System.EventArgs) Handles btnViewClients.Click

        Try

            Me.Cursor = Cursors.WaitCursor()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fTodayClients As New frmTodayClients(Me.stbReferenceNo)
            fTodayClients.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oClients As New SyncSoft.SQLDb.Clients()

            Dim refNo As String = RevertText(StringMayBeEnteredIn(Me.stbReferenceNo))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim clients As DataTable = oClients.GetClients(refNo).Tables("Clients")
            If clients Is Nothing OrElse clients.Rows.Count < 1 Then Return

            Dim row As DataRow = clients.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbLastName.Text = StringMayBeEnteredIn(row, "LastName")
            Me.stbFirstName.Text = StringMayBeEnteredIn(row, "FirstName")
            Me.stbMiddleName.Text = StringMayBeEnteredIn(row, "MiddleName")
            Me.fcbGenderID.SelectedValue = StringMayBeEnteredIn(row, "GenderID")
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "PhoneNo")
            Me.nbxAge.Text = StringMayBeEnteredIn(row, "Age")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub btnLoadTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadTemplate.Click
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.MedicalConditions, Me.stbMedicalConditions, True)
        fGetTemplates.ShowDialog(Me)
    End Sub

    Private Sub btnLoadProvisionalTemplate_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadProvisionalTemplate.Click
        Dim fGetTemplates As New frmGetTemplates(oTemplateTypeID.ProvisionalDiagnosis, Me.stbProvisionalDiagnosis, True)
        fGetTemplates.ShowDialog(Me)
    End Sub
End Class