<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPatients : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal patientNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultPatientNo = patientNo
        Me.noCallOnKeyEdit = disableCallOnKeyEdit
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Sub New(ByVal keyNo As String, ByVal itemsKeyNo As ItemsKeyNo)
        MyClass.New()
        Me.defaultKeyNo = keyNo
        Me.enrollmentKeyNo = itemsKeyNo
    End Sub

    Public Sub New(ByVal currentEnrollmentInformation As CurrentEnrollmentInformation)
        MyClass.New()
        Me.oCurrentEnrollmentInformation = currentEnrollmentInformation
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatients))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbDefaultMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkCaptureMemberCardNo = New System.Windows.Forms.CheckBox()
        Me.stbDefaultMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDefaultBillModesID = New System.Windows.Forms.ComboBox()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHideDetails = New System.Windows.Forms.CheckBox()
        Me.stbNOKName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbNOKPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkEnforceDefaultBillNo = New System.Windows.Forms.CheckBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDefaultBillNo = New System.Windows.Forms.ComboBox()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpJoinDate = New System.Windows.Forms.DateTimePicker()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBirthPlace = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fcbGenderID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fcbStatusID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.cboBloodGroupID = New System.Windows.Forms.ComboBox()
        Me.cboTribeID = New System.Windows.Forms.ComboBox()
        Me.cboReligionID = New System.Windows.Forms.ComboBox()
        Me.stbEmployer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEmployerAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferringMedicalOfficer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbNearestDispensary = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPreviousAdmissions = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbChronicDiseases = New System.Windows.Forms.CheckedListBox()
        Me.cboCareEntryPointID = New System.Windows.Forms.ComboBox()
        Me.cboMaritalStatusID = New System.Windows.Forms.ComboBox()
        Me.cboCountryID = New System.Windows.Forms.ComboBox()
        Me.stbNIN = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkPoliceNotified = New System.Windows.Forms.CheckBox()
        Me.chkInfectiousDiseasesNotified = New System.Windows.Forms.CheckBox()
        Me.stbMedicalConditions = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxXrayNumbers = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbProvisionalDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboNOKRelationship = New System.Windows.Forms.ComboBox()
        Me.cboCommunityID = New System.Windows.Forms.ComboBox()
        Me.cboOccupationID = New System.Windows.Forms.ComboBox()
        Me.cboEducationLevelID = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvPatientsEXT = New System.Windows.Forms.DataGridView()
        Me.colAlternateNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientsEXTSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbcPatients = New System.Windows.Forms.TabControl()
        Me.tpgGeneral = New System.Windows.Forms.TabPage()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnLoadCamera = New System.Windows.Forms.Button()
        Me.lblNIN = New System.Windows.Forms.Label()
        Me.lblDefaultMainMemberName = New System.Windows.Forms.Label()
        Me.lblDefaultMemberCardNo = New System.Windows.Forms.Label()
        Me.btnFindMedicalCardNo = New System.Windows.Forms.Button()
        Me.lblDefaultBillModesID = New System.Windows.Forms.Label()
        Me.lblNOKRelationship = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.lblNOKName = New System.Windows.Forms.Label()
        Me.lblNOKPhone = New System.Windows.Forms.Label()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.btnClearPhoto = New System.Windows.Forms.Button()
        Me.btnLoadPhoto = New System.Windows.Forms.Button()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblDefaultBillCustomerName = New System.Windows.Forms.Label()
        Me.lblDefaultBillNo = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblBirthPlace = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.pnlStatusID = New System.Windows.Forms.Panel()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblOccupation = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.tpgMiscellaneous = New System.Windows.Forms.TabPage()
        Me.grpGeographicalLocation = New System.Windows.Forms.GroupBox()
        Me.cboVillageCode = New System.Windows.Forms.ComboBox()
        Me.lblVillageCode = New System.Windows.Forms.Label()
        Me.lblCountyCode = New System.Windows.Forms.Label()
        Me.cboCountyCode = New System.Windows.Forms.ComboBox()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.lblParishCode = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.cboParishCode = New System.Windows.Forms.ComboBox()
        Me.lblSubCountyCode = New System.Windows.Forms.Label()
        Me.cboSubCountyCode = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEducationLevel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.pnlMaritalStatus = New System.Windows.Forms.Panel()
        Me.lblMaritalStatusID = New System.Windows.Forms.Label()
        Me.pnlCareEntryPointID = New System.Windows.Forms.Panel()
        Me.lblCommunityID = New System.Windows.Forms.Label()
        Me.lblCareEntryPointID = New System.Windows.Forms.Label()
        Me.lblChronicDiseases = New System.Windows.Forms.Label()
        Me.lblEmployer = New System.Windows.Forms.Label()
        Me.lblEmployerAddress = New System.Windows.Forms.Label()
        Me.lblReferringMedicalOfficer = New System.Windows.Forms.Label()
        Me.lblNearestDispensary = New System.Windows.Forms.Label()
        Me.lblPreviousAdmissions = New System.Windows.Forms.Label()
        Me.pnlReligionID = New System.Windows.Forms.Panel()
        Me.lblReligionID = New System.Windows.Forms.Label()
        Me.pnlTribeID = New System.Windows.Forms.Panel()
        Me.lblTribeID = New System.Windows.Forms.Label()
        Me.pnlBloodGroupID = New System.Windows.Forms.Panel()
        Me.lblBloodGroupID = New System.Windows.Forms.Label()
        Me.tpgPatientAllergies = New System.Windows.Forms.TabPage()
        Me.dgvPatientAllergies = New System.Windows.Forms.DataGridView()
        Me.colAllergyNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAllergyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientAllergiesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgProvisionalDiagnosis = New System.Windows.Forms.TabPage()
        Me.btnLoadProvisionalTemplate = New System.Windows.Forms.Button()
        Me.lblProvisionalDiagnosis = New System.Windows.Forms.Label()
        Me.tpgMedicalCondtions = New System.Windows.Forms.TabPage()
        Me.btnLoadTemplate = New System.Windows.Forms.Button()
        Me.lblMedicalConditions = New System.Windows.Forms.Label()
        Me.tpgPatientsEXT = New System.Windows.Forms.TabPage()
        Me.chkPrintFaceSheetOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.btnViewClients = New System.Windows.Forms.Button()
        Me.btnprintBioData = New System.Windows.Forms.Button()
        Me.chkPrintBioData = New System.Windows.Forms.CheckBox()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPatientsEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcPatients.SuspendLayout()
        Me.tpgGeneral.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusID.SuspendLayout()
        Me.tpgMiscellaneous.SuspendLayout()
        Me.grpGeographicalLocation.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlMaritalStatus.SuspendLayout()
        Me.pnlCareEntryPointID.SuspendLayout()
        Me.pnlReligionID.SuspendLayout()
        Me.pnlTribeID.SuspendLayout()
        Me.pnlBloodGroupID.SuspendLayout()
        Me.tpgPatientAllergies.SuspendLayout()
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgProvisionalDiagnosis.SuspendLayout()
        Me.tpgMedicalCondtions.SuspendLayout()
        Me.tpgPatientsEXT.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.fbnClose, "fbnClose")
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.ebnSaveUpdate, "ebnSaveUpdate")
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Tag = "Patients"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbDefaultMainMemberName
        '
        Me.stbDefaultMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDefaultMainMemberName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDefaultMainMemberName, "DefaultMainMemberName")
        Me.stbDefaultMainMemberName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbDefaultMainMemberName, "stbDefaultMainMemberName")
        Me.stbDefaultMainMemberName.Name = "stbDefaultMainMemberName"
        Me.stbDefaultMainMemberName.RegularExpression = ""
        '
        'chkCaptureMemberCardNo
        '
        resources.ApplyResources(Me.chkCaptureMemberCardNo, "chkCaptureMemberCardNo")
        Me.ebnSaveUpdate.SetDataMember(Me.chkCaptureMemberCardNo, "CaptureMemberCardNo")
        Me.chkCaptureMemberCardNo.Name = "chkCaptureMemberCardNo"
        '
        'stbDefaultMemberCardNo
        '
        Me.stbDefaultMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDefaultMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDefaultMemberCardNo, "DefaultMemberCardNo")
        Me.stbDefaultMemberCardNo.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbDefaultMemberCardNo, "stbDefaultMemberCardNo")
        Me.stbDefaultMemberCardNo.Name = "stbDefaultMemberCardNo"
        Me.stbDefaultMemberCardNo.RegularExpression = ""
        '
        'cboDefaultBillModesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDefaultBillModesID, "DefaultBillModes,DefaultBillModesID")
        Me.cboDefaultBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDefaultBillModesID, "cboDefaultBillModesID")
        Me.cboDefaultBillModesID.Name = "cboDefaultBillModesID"
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferenceNo, "ReferenceNo")
        Me.stbReferenceNo.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbReferenceNo, "stbReferenceNo")
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        '
        'chkHideDetails
        '
        resources.ApplyResources(Me.chkHideDetails, "chkHideDetails")
        Me.ebnSaveUpdate.SetDataMember(Me.chkHideDetails, "HideDetails")
        Me.chkHideDetails.Name = "chkHideDetails"
        '
        'stbNOKName
        '
        Me.stbNOKName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNOKName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNOKName, "NOKName")
        Me.stbNOKName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbNOKName, "stbNOKName")
        Me.stbNOKName.Name = "stbNOKName"
        Me.stbNOKName.RegularExpression = ""
        '
        'stbNOKPhone
        '
        Me.stbNOKPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNOKPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNOKPhone, "NOKPhone")
        Me.stbNOKPhone.EntryErrorMSG = "Invalid phone number"
        resources.ApplyResources(Me.stbNOKPhone, "stbNOKPhone")
        Me.stbNOKPhone.Name = "stbNOKPhone"
        Me.stbNOKPhone.RegularExpression = "^\+?\d{10,15}(,\+?\d{10,15})*$"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbInsuranceName, "stbInsuranceName")
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        resources.ApplyResources(Me.spbPhoto, "spbPhoto")
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.TabStop = False
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbMiddleName, "stbMiddleName")
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        '
        'chkEnforceDefaultBillNo
        '
        resources.ApplyResources(Me.chkEnforceDefaultBillNo, "chkEnforceDefaultBillNo")
        Me.ebnSaveUpdate.SetDataMember(Me.chkEnforceDefaultBillNo, "EnforceDefaultBillNo")
        Me.chkEnforceDefaultBillNo.Name = "chkEnforceDefaultBillNo"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbBillCustomerName, "stbBillCustomerName")
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        '
        'cboDefaultBillNo
        '
        Me.cboDefaultBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDefaultBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDefaultBillNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboDefaultBillNo, "DefaultBillNo")
        Me.cboDefaultBillNo.DropDownWidth = 256
        resources.ApplyResources(Me.cboDefaultBillNo, "cboDefaultBillNo")
        Me.cboDefaultBillNo.FormattingEnabled = True
        Me.cboDefaultBillNo.Name = "cboDefaultBillNo"
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLocation, "Location")
        Me.stbLocation.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbLocation, "stbLocation")
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        '
        'dtpJoinDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpJoinDate, "JoinDate")
        resources.ApplyResources(Me.dtpJoinDate, "dtpJoinDate")
        Me.dtpJoinDate.Name = "dtpJoinDate"
        Me.dtpJoinDate.ShowCheckBox = True
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmail, "Email")
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        resources.ApplyResources(Me.stbEmail, "stbEmail")
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4" & _
    "}|[0-9]{1,3})(\]?)$"
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        '
        'stbBirthPlace
        '
        Me.stbBirthPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBirthPlace.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBirthPlace, "BirthPlace")
        Me.stbBirthPlace.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbBirthPlace, "stbBirthPlace")
        Me.stbBirthPlace.Name = "stbBirthPlace"
        Me.stbBirthPlace.RegularExpression = ""
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = "Invalid phone number (number should not exceed 15 digits. In the case of 2 number" & _
    "s, please separate them with a comma. + is allowed)"
        resources.ApplyResources(Me.stbPhone, "stbPhone")
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = "^\+?\d{10,15}(,\+?\d{10,15})*$"
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbAddress, "stbAddress")
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        '
        'fcbGenderID
        '
        Me.fcbGenderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbGenderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbGenderID, "Gender,GenderID")
        Me.fcbGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.fcbGenderID, "fcbGenderID")
        Me.fcbGenderID.FormattingEnabled = True
        Me.fcbGenderID.Name = "fcbGenderID"
        Me.fcbGenderID.ReadOnly = True
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        resources.ApplyResources(Me.nbxAge, "nbxAge")
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        resources.ApplyResources(Me.dtpBirthDate, "dtpBirthDate")
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbLastName, "stbLastName")
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbFirstName, "stbFirstName")
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        '
        'fcbStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbStatusID, "Status,StatusID")
        Me.fcbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.fcbStatusID, "fcbStatusID")
        Me.fcbStatusID.FormattingEnabled = True
        Me.fcbStatusID.Name = "fcbStatusID"
        Me.fcbStatusID.ReadOnly = True
        '
        'cboBloodGroupID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBloodGroupID, "BloodGroup,BloodGroupID")
        Me.cboBloodGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboBloodGroupID, "cboBloodGroupID")
        Me.cboBloodGroupID.Name = "cboBloodGroupID"
        '
        'cboTribeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTribeID, "Tribe,TribeID")
        Me.cboTribeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboTribeID, "cboTribeID")
        Me.cboTribeID.Name = "cboTribeID"
        '
        'cboReligionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReligionID, "Religion,ReligionID")
        Me.cboReligionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboReligionID, "cboReligionID")
        Me.cboReligionID.Name = "cboReligionID"
        '
        'stbEmployer
        '
        Me.stbEmployer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmployer.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmployer, "Employer")
        Me.stbEmployer.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbEmployer, "stbEmployer")
        Me.stbEmployer.Name = "stbEmployer"
        Me.stbEmployer.RegularExpression = ""
        '
        'stbEmployerAddress
        '
        Me.stbEmployerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmployerAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmployerAddress, "EmployerAddress")
        Me.stbEmployerAddress.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbEmployerAddress, "stbEmployerAddress")
        Me.stbEmployerAddress.Name = "stbEmployerAddress"
        Me.stbEmployerAddress.RegularExpression = ""
        '
        'stbReferringMedicalOfficer
        '
        Me.stbReferringMedicalOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferringMedicalOfficer.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferringMedicalOfficer, "ReferringMedicalOfficer")
        Me.stbReferringMedicalOfficer.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbReferringMedicalOfficer, "stbReferringMedicalOfficer")
        Me.stbReferringMedicalOfficer.Name = "stbReferringMedicalOfficer"
        Me.stbReferringMedicalOfficer.RegularExpression = ""
        '
        'stbNearestDispensary
        '
        Me.stbNearestDispensary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNearestDispensary.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNearestDispensary, "NearestDispensary")
        Me.stbNearestDispensary.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbNearestDispensary, "stbNearestDispensary")
        Me.stbNearestDispensary.Name = "stbNearestDispensary"
        Me.stbNearestDispensary.RegularExpression = ""
        '
        'stbPreviousAdmissions
        '
        Me.stbPreviousAdmissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPreviousAdmissions.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPreviousAdmissions, "PreviousAdmissions")
        Me.stbPreviousAdmissions.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbPreviousAdmissions, "stbPreviousAdmissions")
        Me.stbPreviousAdmissions.Name = "stbPreviousAdmissions"
        Me.stbPreviousAdmissions.RegularExpression = ""
        '
        'clbChronicDiseases
        '
        Me.clbChronicDiseases.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbChronicDiseases, "ChronicDiseases")
        Me.clbChronicDiseases.FormattingEnabled = True
        resources.ApplyResources(Me.clbChronicDiseases, "clbChronicDiseases")
        Me.clbChronicDiseases.Name = "clbChronicDiseases"
        '
        'cboCareEntryPointID
        '
        Me.cboCareEntryPointID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCareEntryPointID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCareEntryPointID, "CareEntryPoint,CareEntryPointID")
        Me.cboCareEntryPointID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCareEntryPointID, "cboCareEntryPointID")
        Me.cboCareEntryPointID.Name = "cboCareEntryPointID"
        '
        'cboMaritalStatusID
        '
        Me.cboMaritalStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMaritalStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboMaritalStatusID, "MaritalStatus,MaritalStatusID")
        Me.cboMaritalStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboMaritalStatusID, "cboMaritalStatusID")
        Me.cboMaritalStatusID.Name = "cboMaritalStatusID"
        '
        'cboCountryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCountryID, "Country,CountryID")
        Me.cboCountryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCountryID, "cboCountryID")
        Me.cboCountryID.Name = "cboCountryID"
        '
        'stbNIN
        '
        Me.stbNIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNIN.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNIN, "NationalIDNo")
        Me.stbNIN.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbNIN, "stbNIN")
        Me.stbNIN.Name = "stbNIN"
        Me.stbNIN.RegularExpression = ""
        '
        'chkPoliceNotified
        '
        resources.ApplyResources(Me.chkPoliceNotified, "chkPoliceNotified")
        Me.ebnSaveUpdate.SetDataMember(Me.chkPoliceNotified, "PoliceNotified")
        Me.chkPoliceNotified.Name = "chkPoliceNotified"
        '
        'chkInfectiousDiseasesNotified
        '
        resources.ApplyResources(Me.chkInfectiousDiseasesNotified, "chkInfectiousDiseasesNotified")
        Me.ebnSaveUpdate.SetDataMember(Me.chkInfectiousDiseasesNotified, "InfectiousDiseasesNotified")
        Me.chkInfectiousDiseasesNotified.Name = "chkInfectiousDiseasesNotified"
        '
        'stbMedicalConditions
        '
        Me.stbMedicalConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalConditions.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedicalConditions, "MedicalConditions")
        Me.stbMedicalConditions.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbMedicalConditions, "stbMedicalConditions")
        Me.stbMedicalConditions.Name = "stbMedicalConditions"
        Me.stbMedicalConditions.RegularExpression = ""
        '
        'nbxXrayNumbers
        '
        Me.nbxXrayNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxXrayNumbers.ControlCaption = "Xray Numbers"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxXrayNumbers, "XrayNumbers")
        Me.nbxXrayNumbers.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxXrayNumbers.DecimalPlaces = 2
        resources.ApplyResources(Me.nbxXrayNumbers, "nbxXrayNumbers")
        Me.nbxXrayNumbers.MaxValue = 1000.0R
        Me.nbxXrayNumbers.MinValue = 0.0R
        Me.nbxXrayNumbers.MustEnterNumeric = True
        Me.nbxXrayNumbers.Name = "nbxXrayNumbers"
        Me.nbxXrayNumbers.Value = ""
        '
        'stbProvisionalDiagnosis
        '
        Me.stbProvisionalDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalDiagnosis.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbProvisionalDiagnosis, "ProvisionalDiagnosis")
        Me.stbProvisionalDiagnosis.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbProvisionalDiagnosis, "stbProvisionalDiagnosis")
        Me.stbProvisionalDiagnosis.Name = "stbProvisionalDiagnosis"
        Me.stbProvisionalDiagnosis.RegularExpression = ""
        '
        'cboNOKRelationship
        '
        Me.cboNOKRelationship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNOKRelationship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNOKRelationship.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboNOKRelationship, "NOKRelationship")
        Me.cboNOKRelationship.DropDownWidth = 256
        resources.ApplyResources(Me.cboNOKRelationship, "cboNOKRelationship")
        Me.cboNOKRelationship.FormattingEnabled = True
        Me.cboNOKRelationship.Name = "cboNOKRelationship"
        '
        'cboCommunityID
        '
        Me.cboCommunityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommunityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCommunityID, "CommunityID")
        Me.cboCommunityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCommunityID, "cboCommunityID")
        Me.cboCommunityID.Name = "cboCommunityID"
        '
        'cboOccupationID
        '
        Me.cboOccupationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOccupationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOccupationID.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboOccupationID, "Occupation")
        Me.cboOccupationID.DropDownWidth = 256
        resources.ApplyResources(Me.cboOccupationID, "cboOccupationID")
        Me.cboOccupationID.FormattingEnabled = True
        Me.cboOccupationID.Name = "cboOccupationID"
        '
        'cboEducationLevelID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEducationLevelID, "EducationLevel,EducationLevelID")
        Me.cboEducationLevelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboEducationLevelID, "cboEducationLevelID")
        Me.cboEducationLevelID.Name = "cboEducationLevelID"
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Tag = "Patients"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnSearch, "btnSearch")
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvPatientsEXT
        '
        Me.dgvPatientsEXT.AllowUserToOrderColumns = True
        Me.dgvPatientsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPatientsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAlternateNo, Me.colNotes, Me.colPatientsEXTSaved})
        resources.ApplyResources(Me.dgvPatientsEXT, "dgvPatientsEXT")
        Me.dgvPatientsEXT.EnableHeadersVisualStyles = False
        Me.dgvPatientsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientsEXT.Name = "dgvPatientsEXT"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        '
        'colAlternateNo
        '
        Me.colAlternateNo.DataPropertyName = "AlternateNo"
        resources.ApplyResources(Me.colAlternateNo, "colAlternateNo")
        Me.colAlternateNo.MaxInputLength = 20
        Me.colAlternateNo.Name = "colAlternateNo"
        Me.colAlternateNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colNotes, "colNotes")
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        '
        'colPatientsEXTSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colPatientsEXTSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPatientsEXTSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.colPatientsEXTSaved, "colPatientsEXTSaved")
        Me.colPatientsEXTSaved.Name = "colPatientsEXTSaved"
        Me.colPatientsEXTSaved.ReadOnly = True
        Me.colPatientsEXTSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'tbcPatients
        '
        Me.tbcPatients.Controls.Add(Me.tpgGeneral)
        Me.tbcPatients.Controls.Add(Me.tpgMiscellaneous)
        Me.tbcPatients.Controls.Add(Me.tpgPatientAllergies)
        Me.tbcPatients.Controls.Add(Me.tpgProvisionalDiagnosis)
        Me.tbcPatients.Controls.Add(Me.tpgMedicalCondtions)
        Me.tbcPatients.Controls.Add(Me.tpgPatientsEXT)
        Me.tbcPatients.HotTrack = True
        resources.ApplyResources(Me.tbcPatients, "tbcPatients")
        Me.tbcPatients.Name = "tbcPatients"
        Me.tbcPatients.SelectedIndex = 0
        '
        'tpgGeneral
        '
        Me.tpgGeneral.Controls.Add(Me.imgIDAutomation)
        Me.tpgGeneral.Controls.Add(Me.cboOccupationID)
        Me.tpgGeneral.Controls.Add(Me.cboNOKRelationship)
        Me.tpgGeneral.Controls.Add(Me.btnLoad)
        Me.tpgGeneral.Controls.Add(Me.btnLoadCamera)
        Me.tpgGeneral.Controls.Add(Me.stbNIN)
        Me.tpgGeneral.Controls.Add(Me.lblNIN)
        Me.tpgGeneral.Controls.Add(Me.stbDefaultMainMemberName)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultMainMemberName)
        Me.tpgGeneral.Controls.Add(Me.chkCaptureMemberCardNo)
        Me.tpgGeneral.Controls.Add(Me.stbDefaultMemberCardNo)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultMemberCardNo)
        Me.tpgGeneral.Controls.Add(Me.btnFindMedicalCardNo)
        Me.tpgGeneral.Controls.Add(Me.cboDefaultBillModesID)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultBillModesID)
        Me.tpgGeneral.Controls.Add(Me.lblNOKRelationship)
        Me.tpgGeneral.Controls.Add(Me.chkFingerprintCaptured)
        Me.tpgGeneral.Controls.Add(Me.btnEnrollFingerprint)
        Me.tpgGeneral.Controls.Add(Me.stbReferenceNo)
        Me.tpgGeneral.Controls.Add(Me.lblReferenceNo)
        Me.tpgGeneral.Controls.Add(Me.chkHideDetails)
        Me.tpgGeneral.Controls.Add(Me.stbNOKName)
        Me.tpgGeneral.Controls.Add(Me.lblNOKName)
        Me.tpgGeneral.Controls.Add(Me.stbNOKPhone)
        Me.tpgGeneral.Controls.Add(Me.lblNOKPhone)
        Me.tpgGeneral.Controls.Add(Me.stbInsuranceName)
        Me.tpgGeneral.Controls.Add(Me.lblInsuranceName)
        Me.tpgGeneral.Controls.Add(Me.btnClearPhoto)
        Me.tpgGeneral.Controls.Add(Me.spbPhoto)
        Me.tpgGeneral.Controls.Add(Me.btnLoadPhoto)
        Me.tpgGeneral.Controls.Add(Me.lblPhoto)
        Me.tpgGeneral.Controls.Add(Me.stbMiddleName)
        Me.tpgGeneral.Controls.Add(Me.lblMiddleName)
        Me.tpgGeneral.Controls.Add(Me.chkEnforceDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.stbBillCustomerName)
        Me.tpgGeneral.Controls.Add(Me.cboDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultBillCustomerName)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.stbLocation)
        Me.tpgGeneral.Controls.Add(Me.lblLocation)
        Me.tpgGeneral.Controls.Add(Me.dtpJoinDate)
        Me.tpgGeneral.Controls.Add(Me.stbEmail)
        Me.tpgGeneral.Controls.Add(Me.lblJoinDate)
        Me.tpgGeneral.Controls.Add(Me.lblEmail)
        Me.tpgGeneral.Controls.Add(Me.stbBirthPlace)
        Me.tpgGeneral.Controls.Add(Me.lblBirthPlace)
        Me.tpgGeneral.Controls.Add(Me.stbPhone)
        Me.tpgGeneral.Controls.Add(Me.stbAddress)
        Me.tpgGeneral.Controls.Add(Me.fcbGenderID)
        Me.tpgGeneral.Controls.Add(Me.nbxAge)
        Me.tpgGeneral.Controls.Add(Me.dtpBirthDate)
        Me.tpgGeneral.Controls.Add(Me.stbLastName)
        Me.tpgGeneral.Controls.Add(Me.stbFirstName)
        Me.tpgGeneral.Controls.Add(Me.stbPatientNo)
        Me.tpgGeneral.Controls.Add(Me.pnlStatusID)
        Me.tpgGeneral.Controls.Add(Me.lblPhoneNo)
        Me.tpgGeneral.Controls.Add(Me.lblOccupation)
        Me.tpgGeneral.Controls.Add(Me.lblAge)
        Me.tpgGeneral.Controls.Add(Me.lblSurname)
        Me.tpgGeneral.Controls.Add(Me.lblAddress)
        Me.tpgGeneral.Controls.Add(Me.lblGenderID)
        Me.tpgGeneral.Controls.Add(Me.lblFirstName)
        Me.tpgGeneral.Controls.Add(Me.lblDoB)
        Me.tpgGeneral.Controls.Add(Me.lblPatientsNo)
        resources.ApplyResources(Me.tpgGeneral, "tpgGeneral")
        Me.tpgGeneral.Name = "tpgGeneral"
        Me.tpgGeneral.Tag = "Patients"
        Me.tpgGeneral.UseVisualStyleBackColor = True
        '
        'imgIDAutomation
        '
        resources.ApplyResources(Me.imgIDAutomation, "imgIDAutomation")
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.TabStop = False
        '
        'btnLoad
        '
        resources.ApplyResources(Me.btnLoad, "btnLoad")
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Tag = ""
        '
        'btnLoadCamera
        '
        Me.btnLoadCamera.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnLoadCamera, "btnLoadCamera")
        Me.btnLoadCamera.Name = "btnLoadCamera"
        Me.btnLoadCamera.UseVisualStyleBackColor = True
        '
        'lblNIN
        '
        resources.ApplyResources(Me.lblNIN, "lblNIN")
        Me.lblNIN.Name = "lblNIN"
        '
        'lblDefaultMainMemberName
        '
        resources.ApplyResources(Me.lblDefaultMainMemberName, "lblDefaultMainMemberName")
        Me.lblDefaultMainMemberName.Name = "lblDefaultMainMemberName"
        '
        'lblDefaultMemberCardNo
        '
        resources.ApplyResources(Me.lblDefaultMemberCardNo, "lblDefaultMemberCardNo")
        Me.lblDefaultMemberCardNo.Name = "lblDefaultMemberCardNo"
        '
        'btnFindMedicalCardNo
        '
        Me.btnFindMedicalCardNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnFindMedicalCardNo, "btnFindMedicalCardNo")
        Me.btnFindMedicalCardNo.Name = "btnFindMedicalCardNo"
        '
        'lblDefaultBillModesID
        '
        resources.ApplyResources(Me.lblDefaultBillModesID, "lblDefaultBillModesID")
        Me.lblDefaultBillModesID.Name = "lblDefaultBillModesID"
        '
        'lblNOKRelationship
        '
        resources.ApplyResources(Me.lblNOKRelationship, "lblNOKRelationship")
        Me.lblNOKRelationship.Name = "lblNOKRelationship"
        '
        'chkFingerprintCaptured
        '
        resources.ApplyResources(Me.chkFingerprintCaptured, "chkFingerprintCaptured")
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnEnrollFingerprint, "btnEnrollFingerprint")
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'lblReferenceNo
        '
        resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
        Me.lblReferenceNo.Name = "lblReferenceNo"
        '
        'lblNOKName
        '
        resources.ApplyResources(Me.lblNOKName, "lblNOKName")
        Me.lblNOKName.Name = "lblNOKName"
        '
        'lblNOKPhone
        '
        resources.ApplyResources(Me.lblNOKPhone, "lblNOKPhone")
        Me.lblNOKPhone.Name = "lblNOKPhone"
        '
        'lblInsuranceName
        '
        resources.ApplyResources(Me.lblInsuranceName, "lblInsuranceName")
        Me.lblInsuranceName.Name = "lblInsuranceName"
        '
        'btnClearPhoto
        '
        Me.btnClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnClearPhoto, "btnClearPhoto")
        Me.btnClearPhoto.Name = "btnClearPhoto"
        Me.btnClearPhoto.UseVisualStyleBackColor = True
        '
        'btnLoadPhoto
        '
        Me.btnLoadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnLoadPhoto, "btnLoadPhoto")
        Me.btnLoadPhoto.Name = "btnLoadPhoto"
        Me.btnLoadPhoto.UseVisualStyleBackColor = True
        '
        'lblPhoto
        '
        resources.ApplyResources(Me.lblPhoto, "lblPhoto")
        Me.lblPhoto.Name = "lblPhoto"
        '
        'lblMiddleName
        '
        resources.ApplyResources(Me.lblMiddleName, "lblMiddleName")
        Me.lblMiddleName.Name = "lblMiddleName"
        '
        'lblDefaultBillCustomerName
        '
        resources.ApplyResources(Me.lblDefaultBillCustomerName, "lblDefaultBillCustomerName")
        Me.lblDefaultBillCustomerName.Name = "lblDefaultBillCustomerName"
        '
        'lblDefaultBillNo
        '
        resources.ApplyResources(Me.lblDefaultBillNo, "lblDefaultBillNo")
        Me.lblDefaultBillNo.Name = "lblDefaultBillNo"
        Me.lblDefaultBillNo.Tag = ""
        '
        'lblLocation
        '
        resources.ApplyResources(Me.lblLocation, "lblLocation")
        Me.lblLocation.Name = "lblLocation"
        '
        'lblJoinDate
        '
        resources.ApplyResources(Me.lblJoinDate, "lblJoinDate")
        Me.lblJoinDate.Name = "lblJoinDate"
        '
        'lblEmail
        '
        resources.ApplyResources(Me.lblEmail, "lblEmail")
        Me.lblEmail.Name = "lblEmail"
        '
        'lblBirthPlace
        '
        resources.ApplyResources(Me.lblBirthPlace, "lblBirthPlace")
        Me.lblBirthPlace.Name = "lblBirthPlace"
        '
        'stbPatientNo
        '
        resources.ApplyResources(Me.stbPatientNo, "stbPatientNo")
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        '
        'pnlStatusID
        '
        Me.pnlStatusID.Controls.Add(Me.fcbStatusID)
        Me.pnlStatusID.Controls.Add(Me.lblStatusID)
        resources.ApplyResources(Me.pnlStatusID, "pnlStatusID")
        Me.pnlStatusID.Name = "pnlStatusID"
        '
        'lblStatusID
        '
        resources.ApplyResources(Me.lblStatusID, "lblStatusID")
        Me.lblStatusID.Name = "lblStatusID"
        '
        'lblPhoneNo
        '
        resources.ApplyResources(Me.lblPhoneNo, "lblPhoneNo")
        Me.lblPhoneNo.Name = "lblPhoneNo"
        '
        'lblOccupation
        '
        resources.ApplyResources(Me.lblOccupation, "lblOccupation")
        Me.lblOccupation.Name = "lblOccupation"
        '
        'lblAge
        '
        resources.ApplyResources(Me.lblAge, "lblAge")
        Me.lblAge.Name = "lblAge"
        '
        'lblSurname
        '
        resources.ApplyResources(Me.lblSurname, "lblSurname")
        Me.lblSurname.Name = "lblSurname"
        '
        'lblAddress
        '
        resources.ApplyResources(Me.lblAddress, "lblAddress")
        Me.lblAddress.Name = "lblAddress"
        '
        'lblGenderID
        '
        resources.ApplyResources(Me.lblGenderID, "lblGenderID")
        Me.lblGenderID.Name = "lblGenderID"
        '
        'lblFirstName
        '
        resources.ApplyResources(Me.lblFirstName, "lblFirstName")
        Me.lblFirstName.Name = "lblFirstName"
        '
        'lblDoB
        '
        resources.ApplyResources(Me.lblDoB, "lblDoB")
        Me.lblDoB.Name = "lblDoB"
        '
        'lblPatientsNo
        '
        resources.ApplyResources(Me.lblPatientsNo, "lblPatientsNo")
        Me.lblPatientsNo.Name = "lblPatientsNo"
        '
        'tpgMiscellaneous
        '
        Me.tpgMiscellaneous.Controls.Add(Me.grpGeographicalLocation)
        Me.tpgMiscellaneous.Controls.Add(Me.Panel2)
        Me.tpgMiscellaneous.Controls.Add(Me.nbxXrayNumbers)
        Me.tpgMiscellaneous.Controls.Add(Me.chkInfectiousDiseasesNotified)
        Me.tpgMiscellaneous.Controls.Add(Me.Label1)
        Me.tpgMiscellaneous.Controls.Add(Me.Panel1)
        Me.tpgMiscellaneous.Controls.Add(Me.pnlMaritalStatus)
        Me.tpgMiscellaneous.Controls.Add(Me.pnlCareEntryPointID)
        Me.tpgMiscellaneous.Controls.Add(Me.lblChronicDiseases)
        Me.tpgMiscellaneous.Controls.Add(Me.clbChronicDiseases)
        Me.tpgMiscellaneous.Controls.Add(Me.stbEmployer)
        Me.tpgMiscellaneous.Controls.Add(Me.lblEmployer)
        Me.tpgMiscellaneous.Controls.Add(Me.stbEmployerAddress)
        Me.tpgMiscellaneous.Controls.Add(Me.lblEmployerAddress)
        Me.tpgMiscellaneous.Controls.Add(Me.stbReferringMedicalOfficer)
        Me.tpgMiscellaneous.Controls.Add(Me.lblReferringMedicalOfficer)
        Me.tpgMiscellaneous.Controls.Add(Me.stbNearestDispensary)
        Me.tpgMiscellaneous.Controls.Add(Me.lblNearestDispensary)
        Me.tpgMiscellaneous.Controls.Add(Me.stbPreviousAdmissions)
        Me.tpgMiscellaneous.Controls.Add(Me.lblPreviousAdmissions)
        Me.tpgMiscellaneous.Controls.Add(Me.pnlReligionID)
        Me.tpgMiscellaneous.Controls.Add(Me.pnlTribeID)
        Me.tpgMiscellaneous.Controls.Add(Me.pnlBloodGroupID)
        Me.tpgMiscellaneous.Controls.Add(Me.chkPoliceNotified)
        resources.ApplyResources(Me.tpgMiscellaneous, "tpgMiscellaneous")
        Me.tpgMiscellaneous.Name = "tpgMiscellaneous"
        Me.tpgMiscellaneous.Tag = "Patients"
        Me.tpgMiscellaneous.UseVisualStyleBackColor = True
        '
        'grpGeographicalLocation
        '
        Me.grpGeographicalLocation.Controls.Add(Me.cboVillageCode)
        Me.grpGeographicalLocation.Controls.Add(Me.lblVillageCode)
        Me.grpGeographicalLocation.Controls.Add(Me.lblCountyCode)
        Me.grpGeographicalLocation.Controls.Add(Me.cboCountyCode)
        Me.grpGeographicalLocation.Controls.Add(Me.cboDistrictsID)
        Me.grpGeographicalLocation.Controls.Add(Me.lblParishCode)
        Me.grpGeographicalLocation.Controls.Add(Me.lblDistrictsID)
        Me.grpGeographicalLocation.Controls.Add(Me.cboParishCode)
        Me.grpGeographicalLocation.Controls.Add(Me.lblSubCountyCode)
        Me.grpGeographicalLocation.Controls.Add(Me.cboSubCountyCode)
        resources.ApplyResources(Me.grpGeographicalLocation, "grpGeographicalLocation")
        Me.grpGeographicalLocation.Name = "grpGeographicalLocation"
        Me.grpGeographicalLocation.TabStop = False
        '
        'cboVillageCode
        '
        Me.cboVillageCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboVillageCode, "cboVillageCode")
        Me.cboVillageCode.Name = "cboVillageCode"
        '
        'lblVillageCode
        '
        resources.ApplyResources(Me.lblVillageCode, "lblVillageCode")
        Me.lblVillageCode.Name = "lblVillageCode"
        '
        'lblCountyCode
        '
        resources.ApplyResources(Me.lblCountyCode, "lblCountyCode")
        Me.lblCountyCode.Name = "lblCountyCode"
        '
        'cboCountyCode
        '
        Me.cboCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboCountyCode, "cboCountyCode")
        Me.cboCountyCode.Name = "cboCountyCode"
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboDistrictsID, "cboDistrictsID")
        Me.cboDistrictsID.Name = "cboDistrictsID"
        '
        'lblParishCode
        '
        resources.ApplyResources(Me.lblParishCode, "lblParishCode")
        Me.lblParishCode.Name = "lblParishCode"
        '
        'lblDistrictsID
        '
        resources.ApplyResources(Me.lblDistrictsID, "lblDistrictsID")
        Me.lblDistrictsID.Name = "lblDistrictsID"
        '
        'cboParishCode
        '
        Me.cboParishCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboParishCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboParishCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboParishCode, "cboParishCode")
        Me.cboParishCode.Name = "cboParishCode"
        '
        'lblSubCountyCode
        '
        resources.ApplyResources(Me.lblSubCountyCode, "lblSubCountyCode")
        Me.lblSubCountyCode.Name = "lblSubCountyCode"
        '
        'cboSubCountyCode
        '
        Me.cboSubCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSubCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSubCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSubCountyCode, "cboSubCountyCode")
        Me.cboSubCountyCode.Name = "cboSubCountyCode"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cboEducationLevelID)
        Me.Panel2.Controls.Add(Me.lblEducationLevel)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'lblEducationLevel
        '
        resources.ApplyResources(Me.lblEducationLevel, "lblEducationLevel")
        Me.lblEducationLevel.Name = "lblEducationLevel"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboCountryID)
        Me.Panel1.Controls.Add(Me.lblCountry)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'lblCountry
        '
        resources.ApplyResources(Me.lblCountry, "lblCountry")
        Me.lblCountry.Name = "lblCountry"
        '
        'pnlMaritalStatus
        '
        Me.pnlMaritalStatus.Controls.Add(Me.cboMaritalStatusID)
        Me.pnlMaritalStatus.Controls.Add(Me.lblMaritalStatusID)
        resources.ApplyResources(Me.pnlMaritalStatus, "pnlMaritalStatus")
        Me.pnlMaritalStatus.Name = "pnlMaritalStatus"
        '
        'lblMaritalStatusID
        '
        resources.ApplyResources(Me.lblMaritalStatusID, "lblMaritalStatusID")
        Me.lblMaritalStatusID.Name = "lblMaritalStatusID"
        '
        'pnlCareEntryPointID
        '
        Me.pnlCareEntryPointID.Controls.Add(Me.cboCommunityID)
        Me.pnlCareEntryPointID.Controls.Add(Me.lblCommunityID)
        Me.pnlCareEntryPointID.Controls.Add(Me.cboCareEntryPointID)
        Me.pnlCareEntryPointID.Controls.Add(Me.lblCareEntryPointID)
        resources.ApplyResources(Me.pnlCareEntryPointID, "pnlCareEntryPointID")
        Me.pnlCareEntryPointID.Name = "pnlCareEntryPointID"
        '
        'lblCommunityID
        '
        resources.ApplyResources(Me.lblCommunityID, "lblCommunityID")
        Me.lblCommunityID.Name = "lblCommunityID"
        '
        'lblCareEntryPointID
        '
        resources.ApplyResources(Me.lblCareEntryPointID, "lblCareEntryPointID")
        Me.lblCareEntryPointID.Name = "lblCareEntryPointID"
        '
        'lblChronicDiseases
        '
        resources.ApplyResources(Me.lblChronicDiseases, "lblChronicDiseases")
        Me.lblChronicDiseases.Name = "lblChronicDiseases"
        '
        'lblEmployer
        '
        resources.ApplyResources(Me.lblEmployer, "lblEmployer")
        Me.lblEmployer.Name = "lblEmployer"
        '
        'lblEmployerAddress
        '
        resources.ApplyResources(Me.lblEmployerAddress, "lblEmployerAddress")
        Me.lblEmployerAddress.Name = "lblEmployerAddress"
        '
        'lblReferringMedicalOfficer
        '
        resources.ApplyResources(Me.lblReferringMedicalOfficer, "lblReferringMedicalOfficer")
        Me.lblReferringMedicalOfficer.Name = "lblReferringMedicalOfficer"
        '
        'lblNearestDispensary
        '
        resources.ApplyResources(Me.lblNearestDispensary, "lblNearestDispensary")
        Me.lblNearestDispensary.Name = "lblNearestDispensary"
        '
        'lblPreviousAdmissions
        '
        resources.ApplyResources(Me.lblPreviousAdmissions, "lblPreviousAdmissions")
        Me.lblPreviousAdmissions.Name = "lblPreviousAdmissions"
        '
        'pnlReligionID
        '
        Me.pnlReligionID.Controls.Add(Me.cboReligionID)
        Me.pnlReligionID.Controls.Add(Me.lblReligionID)
        resources.ApplyResources(Me.pnlReligionID, "pnlReligionID")
        Me.pnlReligionID.Name = "pnlReligionID"
        '
        'lblReligionID
        '
        resources.ApplyResources(Me.lblReligionID, "lblReligionID")
        Me.lblReligionID.Name = "lblReligionID"
        '
        'pnlTribeID
        '
        Me.pnlTribeID.Controls.Add(Me.cboTribeID)
        Me.pnlTribeID.Controls.Add(Me.lblTribeID)
        resources.ApplyResources(Me.pnlTribeID, "pnlTribeID")
        Me.pnlTribeID.Name = "pnlTribeID"
        '
        'lblTribeID
        '
        resources.ApplyResources(Me.lblTribeID, "lblTribeID")
        Me.lblTribeID.Name = "lblTribeID"
        '
        'pnlBloodGroupID
        '
        Me.pnlBloodGroupID.Controls.Add(Me.cboBloodGroupID)
        Me.pnlBloodGroupID.Controls.Add(Me.lblBloodGroupID)
        resources.ApplyResources(Me.pnlBloodGroupID, "pnlBloodGroupID")
        Me.pnlBloodGroupID.Name = "pnlBloodGroupID"
        '
        'lblBloodGroupID
        '
        resources.ApplyResources(Me.lblBloodGroupID, "lblBloodGroupID")
        Me.lblBloodGroupID.Name = "lblBloodGroupID"
        '
        'tpgPatientAllergies
        '
        Me.tpgPatientAllergies.Controls.Add(Me.dgvPatientAllergies)
        resources.ApplyResources(Me.tpgPatientAllergies, "tpgPatientAllergies")
        Me.tpgPatientAllergies.Name = "tpgPatientAllergies"
        Me.tpgPatientAllergies.Tag = "PatientAllergies"
        Me.tpgPatientAllergies.UseVisualStyleBackColor = True
        '
        'dgvPatientAllergies
        '
        Me.dgvPatientAllergies.AllowUserToOrderColumns = True
        Me.dgvPatientAllergies.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPatientAllergies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAllergyNo, Me.colAllergyCategory, Me.colReaction, Me.colPatientAllergiesSaved})
        resources.ApplyResources(Me.dgvPatientAllergies, "dgvPatientAllergies")
        Me.dgvPatientAllergies.EnableHeadersVisualStyles = False
        Me.dgvPatientAllergies.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientAllergies.Name = "dgvPatientAllergies"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        '
        'colAllergyNo
        '
        Me.colAllergyNo.DataPropertyName = "AllergyNo"
        Me.colAllergyNo.DisplayStyleForCurrentCellOnly = True
        Me.colAllergyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.colAllergyNo, "colAllergyNo")
        Me.colAllergyNo.Name = "colAllergyNo"
        Me.colAllergyNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAllergyNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colAllergyCategory
        '
        Me.colAllergyCategory.DataPropertyName = "AllergyCategory"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colAllergyCategory.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.colAllergyCategory, "colAllergyCategory")
        Me.colAllergyCategory.Name = "colAllergyCategory"
        Me.colAllergyCategory.ReadOnly = True
        '
        'colReaction
        '
        Me.colReaction.DataPropertyName = "Reaction"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colReaction.DefaultCellStyle = DataGridViewCellStyle7
        resources.ApplyResources(Me.colReaction, "colReaction")
        Me.colReaction.MaxInputLength = 200
        Me.colReaction.Name = "colReaction"
        '
        'colPatientAllergiesSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colPatientAllergiesSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPatientAllergiesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.colPatientAllergiesSaved, "colPatientAllergiesSaved")
        Me.colPatientAllergiesSaved.Name = "colPatientAllergiesSaved"
        Me.colPatientAllergiesSaved.ReadOnly = True
        Me.colPatientAllergiesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'tpgProvisionalDiagnosis
        '
        Me.tpgProvisionalDiagnosis.Controls.Add(Me.btnLoadProvisionalTemplate)
        Me.tpgProvisionalDiagnosis.Controls.Add(Me.stbProvisionalDiagnosis)
        Me.tpgProvisionalDiagnosis.Controls.Add(Me.lblProvisionalDiagnosis)
        resources.ApplyResources(Me.tpgProvisionalDiagnosis, "tpgProvisionalDiagnosis")
        Me.tpgProvisionalDiagnosis.Name = "tpgProvisionalDiagnosis"
        Me.tpgProvisionalDiagnosis.UseVisualStyleBackColor = True
        '
        'btnLoadProvisionalTemplate
        '
        Me.btnLoadProvisionalTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoadProvisionalTemplate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnLoadProvisionalTemplate, "btnLoadProvisionalTemplate")
        Me.btnLoadProvisionalTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoadProvisionalTemplate.Name = "btnLoadProvisionalTemplate"
        Me.btnLoadProvisionalTemplate.UseVisualStyleBackColor = False
        '
        'lblProvisionalDiagnosis
        '
        resources.ApplyResources(Me.lblProvisionalDiagnosis, "lblProvisionalDiagnosis")
        Me.lblProvisionalDiagnosis.Name = "lblProvisionalDiagnosis"
        '
        'tpgMedicalCondtions
        '
        Me.tpgMedicalCondtions.Controls.Add(Me.btnLoadTemplate)
        Me.tpgMedicalCondtions.Controls.Add(Me.stbMedicalConditions)
        Me.tpgMedicalCondtions.Controls.Add(Me.lblMedicalConditions)
        resources.ApplyResources(Me.tpgMedicalCondtions, "tpgMedicalCondtions")
        Me.tpgMedicalCondtions.Name = "tpgMedicalCondtions"
        Me.tpgMedicalCondtions.UseVisualStyleBackColor = True
        '
        'btnLoadTemplate
        '
        Me.btnLoadTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoadTemplate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnLoadTemplate, "btnLoadTemplate")
        Me.btnLoadTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoadTemplate.Name = "btnLoadTemplate"
        Me.btnLoadTemplate.UseVisualStyleBackColor = False
        '
        'lblMedicalConditions
        '
        resources.ApplyResources(Me.lblMedicalConditions, "lblMedicalConditions")
        Me.lblMedicalConditions.Name = "lblMedicalConditions"
        '
        'tpgPatientsEXT
        '
        Me.tpgPatientsEXT.Controls.Add(Me.dgvPatientsEXT)
        resources.ApplyResources(Me.tpgPatientsEXT, "tpgPatientsEXT")
        Me.tpgPatientsEXT.Name = "tpgPatientsEXT"
        Me.tpgPatientsEXT.Tag = "PatientsEXT"
        Me.tpgPatientsEXT.UseVisualStyleBackColor = True
        '
        'chkPrintFaceSheetOnSaving
        '
        Me.chkPrintFaceSheetOnSaving.Checked = True
        Me.chkPrintFaceSheetOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintFaceSheetOnSaving, "chkPrintFaceSheetOnSaving")
        Me.chkPrintFaceSheetOnSaving.Name = "chkPrintFaceSheetOnSaving"
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnPrintBarcode, "btnPrintBarcode")
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        '
        'btnViewClients
        '
        Me.btnViewClients.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnViewClients, "btnViewClients")
        Me.btnViewClients.Name = "btnViewClients"
        Me.btnViewClients.Tag = "Clients"
        '
        'btnprintBioData
        '
        Me.btnprintBioData.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnprintBioData, "btnprintBioData")
        Me.btnprintBioData.Name = "btnprintBioData"
        '
        'chkPrintBioData
        '
        Me.chkPrintBioData.Checked = True
        Me.chkPrintBioData.CheckState = System.Windows.Forms.CheckState.Checked
        resources.ApplyResources(Me.chkPrintBioData, "chkPrintBioData")
        Me.chkPrintBioData.Name = "chkPrintBioData"
        '
        'frmPatients
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.Controls.Add(Me.chkPrintBioData)
        Me.Controls.Add(Me.btnprintBioData)
        Me.Controls.Add(Me.btnViewClients)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.chkPrintFaceSheetOnSaving)
        Me.Controls.Add(Me.tbcPatients)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPatients"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPatientsEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcPatients.ResumeLayout(False)
        Me.tpgGeneral.ResumeLayout(False)
        Me.tpgGeneral.PerformLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusID.ResumeLayout(False)
        Me.tpgMiscellaneous.ResumeLayout(False)
        Me.tpgMiscellaneous.PerformLayout()
        Me.grpGeographicalLocation.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlMaritalStatus.ResumeLayout(False)
        Me.pnlCareEntryPointID.ResumeLayout(False)
        Me.pnlReligionID.ResumeLayout(False)
        Me.pnlTribeID.ResumeLayout(False)
        Me.pnlBloodGroupID.ResumeLayout(False)
        Me.tpgPatientAllergies.ResumeLayout(False)
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgProvisionalDiagnosis.ResumeLayout(False)
        Me.tpgProvisionalDiagnosis.PerformLayout()
        Me.tpgMedicalCondtions.ResumeLayout(False)
        Me.tpgMedicalCondtions.PerformLayout()
        Me.tpgPatientsEXT.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvPatientsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents colAlternateNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientsEXTSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tbcPatients As System.Windows.Forms.TabControl
    Friend WithEvents tpgPatientsEXT As System.Windows.Forms.TabPage
    Friend WithEvents tpgPatientAllergies As System.Windows.Forms.TabPage
    Friend WithEvents dgvPatientAllergies As System.Windows.Forms.DataGridView
    Friend WithEvents colAllergyNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAllergyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientAllergiesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents stbDefaultMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDefaultMainMemberName As System.Windows.Forms.Label
    Friend WithEvents chkCaptureMemberCardNo As System.Windows.Forms.CheckBox
    Friend WithEvents stbDefaultMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDefaultMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents btnFindMedicalCardNo As System.Windows.Forms.Button
    Friend WithEvents cboDefaultBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDefaultBillModesID As System.Windows.Forms.Label
    Friend WithEvents lblNOKRelationship As System.Windows.Forms.Label
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents chkHideDetails As System.Windows.Forms.CheckBox
    Friend WithEvents stbNOKName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNOKName As System.Windows.Forms.Label
    Friend WithEvents stbNOKPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNOKPhone As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
    Friend WithEvents btnLoadPhoto As System.Windows.Forms.Button
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents chkEnforceDefaultBillNo As System.Windows.Forms.CheckBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboDefaultBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDefaultBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblDefaultBillNo As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents dtpJoinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents stbBirthPlace As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBirthPlace As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fcbGenderID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlStatusID As System.Windows.Forms.Panel
    Friend WithEvents fcbStatusID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
    Friend WithEvents lblOccupation As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblDoB As System.Windows.Forms.Label
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents tpgMiscellaneous As System.Windows.Forms.TabPage
    Friend WithEvents pnlBloodGroupID As System.Windows.Forms.Panel
    Friend WithEvents cboBloodGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBloodGroupID As System.Windows.Forms.Label
    Friend WithEvents pnlTribeID As System.Windows.Forms.Panel
    Friend WithEvents cboTribeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTribeID As System.Windows.Forms.Label
    Friend WithEvents pnlReligionID As System.Windows.Forms.Panel
    Friend WithEvents cboReligionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReligionID As System.Windows.Forms.Label
    Friend WithEvents stbEmployer As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmployer As System.Windows.Forms.Label
    Friend WithEvents stbEmployerAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmployerAddress As System.Windows.Forms.Label
    Friend WithEvents stbReferringMedicalOfficer As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferringMedicalOfficer As System.Windows.Forms.Label
    Friend WithEvents stbNearestDispensary As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNearestDispensary As System.Windows.Forms.Label
    Friend WithEvents stbPreviousAdmissions As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPreviousAdmissions As System.Windows.Forms.Label
    Friend WithEvents grpGeographicalLocation As System.Windows.Forms.GroupBox
    Friend WithEvents cboVillageCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblVillageCode As System.Windows.Forms.Label
    Friend WithEvents lblCountyCode As System.Windows.Forms.Label
    Friend WithEvents cboCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblParishCode As System.Windows.Forms.Label
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents cboParishCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubCountyCode As System.Windows.Forms.Label
    Friend WithEvents cboSubCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents clbChronicDiseases As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblChronicDiseases As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents chkPrintFaceSheetOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCareEntryPointID As System.Windows.Forms.Panel
    Friend WithEvents cboCareEntryPointID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCareEntryPointID As System.Windows.Forms.Label
    Friend WithEvents pnlMaritalStatus As System.Windows.Forms.Panel
    Friend WithEvents cboMaritalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaritalStatusID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCountryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents stbNIN As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNIN As System.Windows.Forms.Label
    Friend WithEvents tpgProvisionalDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents chkInfectiousDiseasesNotified As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkPoliceNotified As System.Windows.Forms.CheckBox
    Friend WithEvents tpgMedicalCondtions As System.Windows.Forms.TabPage
    Friend WithEvents stbMedicalConditions As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMedicalConditions As System.Windows.Forms.Label
    Friend WithEvents nbxXrayNumbers As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents stbProvisionalDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProvisionalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents btnLoadCamera As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cboNOKRelationship As System.Windows.Forms.ComboBox
    Friend WithEvents cboCommunityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommunityID As System.Windows.Forms.Label
    Friend WithEvents cboOccupationID As System.Windows.Forms.ComboBox
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents btnViewClients As System.Windows.Forms.Button
    Friend WithEvents btnprintBioData As System.Windows.Forms.Button
    Friend WithEvents chkPrintBioData As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboEducationLevelID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEducationLevel As System.Windows.Forms.Label
    Friend WithEvents btnLoadProvisionalTemplate As System.Windows.Forms.Button
    Friend WithEvents btnLoadTemplate As System.Windows.Forms.Button
End Class
