<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientsTwo : Inherits System.Windows.Forms.Form

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


    Public Sub New(ByVal keyNo As String, ByVal itemsKeyNo As ItemsKeyNo)
        MyClass.New()
        Me.defaultKeyNo = keyNo
        Me.enrollmentKeyNo = itemsKeyNo
    End Sub

    Public Sub New(ByVal currentEnrollmentInformation As CurrentEnrollmentInformation)
        MyClass.New()
        Me.oCurrentEnrollmentInformation = currentEnrollmentInformation
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientsTwo))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.chkReceiveMedicalSMS = New System.Windows.Forms.CheckBox()
        Me.tbcPatients = New System.Windows.Forms.TabControl()
        Me.tpgGeneral = New System.Windows.Forms.TabPage()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.stbReferringFacility = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferringfacility = New System.Windows.Forms.Label()
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
        Me.pnlReligionID = New System.Windows.Forms.Panel()
        Me.cboReligionID = New System.Windows.Forms.ComboBox()
        Me.lblReligionID = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboCountryID = New System.Windows.Forms.ComboBox()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.pnlTribeID = New System.Windows.Forms.Panel()
        Me.cboTribeID = New System.Windows.Forms.ComboBox()
        Me.lblTribeID = New System.Windows.Forms.Label()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.cboOccupationID = New System.Windows.Forms.ComboBox()
        Me.cboNOKRelationship = New System.Windows.Forms.ComboBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnLoadCamera = New System.Windows.Forms.Button()
        Me.stbNIN = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNIN = New System.Windows.Forms.Label()
        Me.stbDefaultMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDefaultMainMemberName = New System.Windows.Forms.Label()
        Me.chkCaptureMemberCardNo = New System.Windows.Forms.CheckBox()
        Me.stbDefaultMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDefaultMemberCardNo = New System.Windows.Forms.Label()
        Me.btnFindMedicalCardNo = New System.Windows.Forms.Button()
        Me.cboDefaultBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblDefaultBillModesID = New System.Windows.Forms.Label()
        Me.lblNOKRelationship = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.chkHideDetails = New System.Windows.Forms.CheckBox()
        Me.stbNOKName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNOKName = New System.Windows.Forms.Label()
        Me.stbNOKPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNOKPhone = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.btnClearPhoto = New System.Windows.Forms.Button()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.btnLoadPhoto = New System.Windows.Forms.Button()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.chkEnforceDefaultBillNo = New System.Windows.Forms.CheckBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDefaultBillNo = New System.Windows.Forms.ComboBox()
        Me.lblDefaultBillCustomerName = New System.Windows.Forms.Label()
        Me.lblDefaultBillNo = New System.Windows.Forms.Label()
        Me.dtpJoinDate = New System.Windows.Forms.DateTimePicker()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fcbGenderID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.pnlStatusID = New System.Windows.Forms.Panel()
        Me.fcbStatusID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblOccupation = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.grpGeographicalLocation = New System.Windows.Forms.GroupBox()
        Me.tpgMiscellaneous = New System.Windows.Forms.TabPage()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.stbBirthPlace = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBirthPlace = New System.Windows.Forms.Label()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboEducationLevelID = New System.Windows.Forms.ComboBox()
        Me.lblEducationLevel = New System.Windows.Forms.Label()
        Me.nbxXrayNumbers = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkInfectiousDiseasesNotified = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlMaritalStatus = New System.Windows.Forms.Panel()
        Me.cboMaritalStatusID = New System.Windows.Forms.ComboBox()
        Me.lblMaritalStatusID = New System.Windows.Forms.Label()
        Me.pnlCareEntryPointID = New System.Windows.Forms.Panel()
        Me.cboCommunityID = New System.Windows.Forms.ComboBox()
        Me.lblCommunityID = New System.Windows.Forms.Label()
        Me.cboCareEntryPointID = New System.Windows.Forms.ComboBox()
        Me.lblCareEntryPointID = New System.Windows.Forms.Label()
        Me.lblChronicDiseases = New System.Windows.Forms.Label()
        Me.clbChronicDiseases = New System.Windows.Forms.CheckedListBox()
        Me.stbEmployer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEmployer = New System.Windows.Forms.Label()
        Me.stbEmployerAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEmployerAddress = New System.Windows.Forms.Label()
        Me.stbReferringMedicalOfficer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferringMedicalOfficer = New System.Windows.Forms.Label()
        Me.stbNearestDispensary = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNearestDispensary = New System.Windows.Forms.Label()
        Me.stbPreviousAdmissions = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPreviousAdmissions = New System.Windows.Forms.Label()
        Me.pnlBloodGroupID = New System.Windows.Forms.Panel()
        Me.cboBloodGroupID = New System.Windows.Forms.ComboBox()
        Me.lblBloodGroupID = New System.Windows.Forms.Label()
        Me.chkPoliceNotified = New System.Windows.Forms.CheckBox()
        Me.tpgPatientAllergies = New System.Windows.Forms.TabPage()
        Me.dgvPatientAllergies = New System.Windows.Forms.DataGridView()
        Me.colAllergyNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAllergyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientAllergiesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgProvisionalDiagnosis = New System.Windows.Forms.TabPage()
        Me.stbProvisionalDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblProvisionalDiagnosis = New System.Windows.Forms.Label()
        Me.tpgMedicalCondtions = New System.Windows.Forms.TabPage()
        Me.stbMedicalConditions = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMedicalConditions = New System.Windows.Forms.Label()
        Me.tpgPatientsEXT = New System.Windows.Forms.TabPage()
        Me.dgvPatientsEXT = New System.Windows.Forms.DataGridView()
        Me.colAlternateNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientsEXTSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnprintBioData = New System.Windows.Forms.Button()
        Me.btnViewClients = New System.Windows.Forms.Button()
        Me.chkPrintFaceSheetOnSaving = New System.Windows.Forms.CheckBox()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.chkPrintBioData = New System.Windows.Forms.CheckBox()
        Me.tbcPatients.SuspendLayout()
        Me.tpgGeneral.SuspendLayout()
        Me.pnlReligionID.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlTribeID.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusID.SuspendLayout()
        Me.tpgMiscellaneous.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlMaritalStatus.SuspendLayout()
        Me.pnlCareEntryPointID.SuspendLayout()
        Me.pnlBloodGroupID.SuspendLayout()
        Me.tpgPatientAllergies.SuspendLayout()
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgProvisionalDiagnosis.SuspendLayout()
        Me.tpgMedicalCondtions.SuspendLayout()
        Me.tpgPatientsEXT.SuspendLayout()
        CType(Me.dgvPatientsEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkReceiveMedicalSMS
        '
        Me.chkReceiveMedicalSMS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReceiveMedicalSMS.Checked = True
        Me.chkReceiveMedicalSMS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReceiveMedicalSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReceiveMedicalSMS.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkReceiveMedicalSMS.Location = New System.Drawing.Point(347, 442)
        Me.chkReceiveMedicalSMS.Name = "chkReceiveMedicalSMS"
        Me.chkReceiveMedicalSMS.Size = New System.Drawing.Size(178, 17)
        Me.chkReceiveMedicalSMS.TabIndex = 66
        Me.chkReceiveMedicalSMS.Text = "Receive Medical SMS Alerts"
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
        Me.tbcPatients.Location = New System.Drawing.Point(7, 0)
        Me.tbcPatients.Name = "tbcPatients"
        Me.tbcPatients.SelectedIndex = 0
        Me.tbcPatients.Size = New System.Drawing.Size(703, 517)
        Me.tbcPatients.TabIndex = 0
        '
        'tpgGeneral
        '
        Me.tpgGeneral.Controls.Add(Me.stbLocation)
        Me.tpgGeneral.Controls.Add(Me.lblLocation)
        Me.tpgGeneral.Controls.Add(Me.stbReferringFacility)
        Me.tpgGeneral.Controls.Add(Me.lblReferringfacility)
        Me.tpgGeneral.Controls.Add(Me.cboVillageCode)
        Me.tpgGeneral.Controls.Add(Me.lblVillageCode)
        Me.tpgGeneral.Controls.Add(Me.lblCountyCode)
        Me.tpgGeneral.Controls.Add(Me.cboCountyCode)
        Me.tpgGeneral.Controls.Add(Me.cboDistrictsID)
        Me.tpgGeneral.Controls.Add(Me.lblParishCode)
        Me.tpgGeneral.Controls.Add(Me.lblDistrictsID)
        Me.tpgGeneral.Controls.Add(Me.cboParishCode)
        Me.tpgGeneral.Controls.Add(Me.lblSubCountyCode)
        Me.tpgGeneral.Controls.Add(Me.cboSubCountyCode)
        Me.tpgGeneral.Controls.Add(Me.pnlReligionID)
        Me.tpgGeneral.Controls.Add(Me.Panel1)
        Me.tpgGeneral.Controls.Add(Me.pnlTribeID)
        Me.tpgGeneral.Controls.Add(Me.chkReceiveMedicalSMS)
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
        Me.tpgGeneral.Controls.Add(Me.chkEnforceDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.stbBillCustomerName)
        Me.tpgGeneral.Controls.Add(Me.cboDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultBillCustomerName)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultBillNo)
        Me.tpgGeneral.Controls.Add(Me.dtpJoinDate)
        Me.tpgGeneral.Controls.Add(Me.lblJoinDate)
        Me.tpgGeneral.Controls.Add(Me.stbPhone)
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
        Me.tpgGeneral.Controls.Add(Me.lblGenderID)
        Me.tpgGeneral.Controls.Add(Me.lblFirstName)
        Me.tpgGeneral.Controls.Add(Me.lblDoB)
        Me.tpgGeneral.Controls.Add(Me.lblPatientsNo)
        Me.tpgGeneral.Controls.Add(Me.grpGeographicalLocation)
        Me.tpgGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpgGeneral.Name = "tpgGeneral"
        Me.tpgGeneral.Size = New System.Drawing.Size(695, 491)
        Me.tpgGeneral.TabIndex = 4
        Me.tpgGeneral.Tag = "Patients"
        Me.tpgGeneral.Text = "General"
        Me.tpgGeneral.UseVisualStyleBackColor = True
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLocation, "Location")
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(510, 109)
        Me.stbLocation.MaxLength = 40
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(163, 20)
        Me.stbLocation.TabIndex = 48
        '
        'lblLocation
        '
        Me.lblLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocation.Location = New System.Drawing.Point(347, 108)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(157, 20)
        Me.lblLocation.TabIndex = 47
        Me.lblLocation.Text = "Ancestral Home"
        '
        'stbReferringFacility
        '
        Me.stbReferringFacility.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferringFacility.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferringFacility, "NOKPhone")
        Me.stbReferringFacility.EntryErrorMSG = ""
        Me.stbReferringFacility.Location = New System.Drawing.Point(511, 131)
        Me.stbReferringFacility.MaxLength = 30
        Me.stbReferringFacility.Name = "stbReferringFacility"
        Me.stbReferringFacility.RegularExpression = ""
        Me.stbReferringFacility.Size = New System.Drawing.Size(163, 20)
        Me.stbReferringFacility.TabIndex = 50
        '
        'lblReferringfacility
        '
        Me.lblReferringfacility.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferringfacility.Location = New System.Drawing.Point(347, 132)
        Me.lblReferringfacility.Name = "lblReferringfacility"
        Me.lblReferringfacility.Size = New System.Drawing.Size(165, 20)
        Me.lblReferringfacility.TabIndex = 49
        Me.lblReferringfacility.Text = "Referring Facility"
        '
        'cboVillageCode
        '
        Me.cboVillageCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVillageCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVillageCode.Location = New System.Drawing.Point(182, 409)
        Me.cboVillageCode.Name = "cboVillageCode"
        Me.cboVillageCode.Size = New System.Drawing.Size(157, 21)
        Me.cboVillageCode.TabIndex = 38
        '
        'lblVillageCode
        '
        Me.lblVillageCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVillageCode.Location = New System.Drawing.Point(9, 409)
        Me.lblVillageCode.Name = "lblVillageCode"
        Me.lblVillageCode.Size = New System.Drawing.Size(162, 20)
        Me.lblVillageCode.TabIndex = 37
        Me.lblVillageCode.Text = "Village"
        '
        'lblCountyCode
        '
        Me.lblCountyCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountyCode.Location = New System.Drawing.Point(9, 342)
        Me.lblCountyCode.Name = "lblCountyCode"
        Me.lblCountyCode.Size = New System.Drawing.Size(162, 20)
        Me.lblCountyCode.TabIndex = 31
        Me.lblCountyCode.Text = "County"
        '
        'cboCountyCode
        '
        Me.cboCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCountyCode.Location = New System.Drawing.Point(182, 339)
        Me.cboCountyCode.Name = "cboCountyCode"
        Me.cboCountyCode.Size = New System.Drawing.Size(157, 21)
        Me.cboCountyCode.TabIndex = 32
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(182, 316)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(157, 21)
        Me.cboDistrictsID.TabIndex = 30
        '
        'lblParishCode
        '
        Me.lblParishCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblParishCode.Location = New System.Drawing.Point(9, 386)
        Me.lblParishCode.Name = "lblParishCode"
        Me.lblParishCode.Size = New System.Drawing.Size(162, 20)
        Me.lblParishCode.TabIndex = 35
        Me.lblParishCode.Text = "Parish"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDistrictsID.Location = New System.Drawing.Point(9, 317)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(162, 20)
        Me.lblDistrictsID.TabIndex = 29
        Me.lblDistrictsID.Text = "District"
        '
        'cboParishCode
        '
        Me.cboParishCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboParishCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboParishCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParishCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboParishCode.Location = New System.Drawing.Point(182, 386)
        Me.cboParishCode.Name = "cboParishCode"
        Me.cboParishCode.Size = New System.Drawing.Size(157, 21)
        Me.cboParishCode.TabIndex = 36
        '
        'lblSubCountyCode
        '
        Me.lblSubCountyCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSubCountyCode.Location = New System.Drawing.Point(9, 363)
        Me.lblSubCountyCode.Name = "lblSubCountyCode"
        Me.lblSubCountyCode.Size = New System.Drawing.Size(162, 20)
        Me.lblSubCountyCode.TabIndex = 33
        Me.lblSubCountyCode.Text = "Sub County"
        '
        'cboSubCountyCode
        '
        Me.cboSubCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSubCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSubCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubCountyCode.Location = New System.Drawing.Point(182, 363)
        Me.cboSubCountyCode.Name = "cboSubCountyCode"
        Me.cboSubCountyCode.Size = New System.Drawing.Size(157, 21)
        Me.cboSubCountyCode.TabIndex = 34
        '
        'pnlReligionID
        '
        Me.pnlReligionID.Controls.Add(Me.cboReligionID)
        Me.pnlReligionID.Controls.Add(Me.lblReligionID)
        Me.pnlReligionID.Location = New System.Drawing.Point(3, 457)
        Me.pnlReligionID.Name = "pnlReligionID"
        Me.pnlReligionID.Size = New System.Drawing.Size(347, 29)
        Me.pnlReligionID.TabIndex = 40
        '
        'cboReligionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReligionID, "Religion,ReligionID")
        Me.cboReligionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReligionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReligionID.Location = New System.Drawing.Point(179, 4)
        Me.cboReligionID.Name = "cboReligionID"
        Me.cboReligionID.Size = New System.Drawing.Size(155, 21)
        Me.cboReligionID.TabIndex = 1
        '
        'lblReligionID
        '
        Me.lblReligionID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReligionID.Location = New System.Drawing.Point(9, 4)
        Me.lblReligionID.Name = "lblReligionID"
        Me.lblReligionID.Size = New System.Drawing.Size(162, 20)
        Me.lblReligionID.TabIndex = 0
        Me.lblReligionID.Text = "Religion"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboCountryID)
        Me.Panel1.Controls.Add(Me.lblCountry)
        Me.Panel1.Location = New System.Drawing.Point(3, 285)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(347, 29)
        Me.Panel1.TabIndex = 28
        '
        'cboCountryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCountryID, "Country,CountryID")
        Me.cboCountryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCountryID.Location = New System.Drawing.Point(179, 4)
        Me.cboCountryID.Name = "cboCountryID"
        Me.cboCountryID.Size = New System.Drawing.Size(155, 21)
        Me.cboCountryID.TabIndex = 1
        '
        'lblCountry
        '
        Me.lblCountry.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCountry.Location = New System.Drawing.Point(9, 4)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(159, 20)
        Me.lblCountry.TabIndex = 0
        Me.lblCountry.Text = "Country"
        '
        'pnlTribeID
        '
        Me.pnlTribeID.Controls.Add(Me.cboTribeID)
        Me.pnlTribeID.Controls.Add(Me.lblTribeID)
        Me.pnlTribeID.Location = New System.Drawing.Point(3, 431)
        Me.pnlTribeID.Name = "pnlTribeID"
        Me.pnlTribeID.Size = New System.Drawing.Size(347, 29)
        Me.pnlTribeID.TabIndex = 39
        '
        'cboTribeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTribeID, "Tribe,TribeID")
        Me.cboTribeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTribeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTribeID.Location = New System.Drawing.Point(179, 4)
        Me.cboTribeID.Name = "cboTribeID"
        Me.cboTribeID.Size = New System.Drawing.Size(155, 21)
        Me.cboTribeID.TabIndex = 1
        '
        'lblTribeID
        '
        Me.lblTribeID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTribeID.Location = New System.Drawing.Point(9, 4)
        Me.lblTribeID.Name = "lblTribeID"
        Me.lblTribeID.Size = New System.Drawing.Size(162, 20)
        Me.lblTribeID.TabIndex = 0
        Me.lblTribeID.Text = "Tribe"
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.imgIDAutomation.Location = New System.Drawing.Point(481, 389)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 50)
        Me.imgIDAutomation.TabIndex = 101
        Me.imgIDAutomation.TabStop = False
        '
        'cboOccupationID
        '
        Me.cboOccupationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOccupationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOccupationID.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboOccupationID, "Occupation")
        Me.cboOccupationID.DropDownWidth = 256
        Me.cboOccupationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOccupationID.FormattingEnabled = True
        Me.cboOccupationID.ItemHeight = 13
        Me.cboOccupationID.Location = New System.Drawing.Point(182, 155)
        Me.cboOccupationID.MaxLength = 100
        Me.cboOccupationID.Name = "cboOccupationID"
        Me.cboOccupationID.Size = New System.Drawing.Size(155, 21)
        Me.cboOccupationID.TabIndex = 17
        '
        'cboNOKRelationship
        '
        Me.cboNOKRelationship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboNOKRelationship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNOKRelationship.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboNOKRelationship, "NOKRelationship")
        Me.cboNOKRelationship.DropDownWidth = 256
        Me.cboNOKRelationship.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNOKRelationship.FormattingEnabled = True
        Me.cboNOKRelationship.ItemHeight = 13
        Me.cboNOKRelationship.Location = New System.Drawing.Point(182, 241)
        Me.cboNOKRelationship.MaxLength = 100
        Me.cboNOKRelationship.Name = "cboNOKRelationship"
        Me.cboNOKRelationship.Size = New System.Drawing.Size(155, 21)
        Me.cboNOKRelationship.TabIndex = 25
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLoad.Location = New System.Drawing.Point(350, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'btnLoadCamera
        '
        Me.btnLoadCamera.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLoadCamera.Location = New System.Drawing.Point(629, 39)
        Me.btnLoadCamera.Name = "btnLoadCamera"
        Me.btnLoadCamera.Size = New System.Drawing.Size(58, 23)
        Me.btnLoadCamera.TabIndex = 44
        Me.btnLoadCamera.Text = "Camera"
        Me.btnLoadCamera.UseVisualStyleBackColor = True
        '
        'stbNIN
        '
        Me.stbNIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNIN.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNIN, "NationalIDNo")
        Me.stbNIN.EntryErrorMSG = ""
        Me.stbNIN.Location = New System.Drawing.Point(182, 26)
        Me.stbNIN.MaxLength = 14
        Me.stbNIN.Name = "stbNIN"
        Me.stbNIN.RegularExpression = ""
        Me.stbNIN.Size = New System.Drawing.Size(155, 20)
        Me.stbNIN.TabIndex = 5
        '
        'lblNIN
        '
        Me.lblNIN.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNIN.Location = New System.Drawing.Point(9, 27)
        Me.lblNIN.Name = "lblNIN"
        Me.lblNIN.Size = New System.Drawing.Size(174, 20)
        Me.lblNIN.TabIndex = 4
        Me.lblNIN.Text = "National ID No (NIN)"
        '
        'stbDefaultMainMemberName
        '
        Me.stbDefaultMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDefaultMainMemberName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDefaultMainMemberName, "DefaultMainMemberName")
        Me.stbDefaultMainMemberName.EntryErrorMSG = ""
        Me.stbDefaultMainMemberName.Location = New System.Drawing.Point(513, 291)
        Me.stbDefaultMainMemberName.MaxLength = 41
        Me.stbDefaultMainMemberName.Name = "stbDefaultMainMemberName"
        Me.stbDefaultMainMemberName.RegularExpression = ""
        Me.stbDefaultMainMemberName.Size = New System.Drawing.Size(163, 20)
        Me.stbDefaultMainMemberName.TabIndex = 62
        '
        'lblDefaultMainMemberName
        '
        Me.lblDefaultMainMemberName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDefaultMainMemberName.Location = New System.Drawing.Point(347, 291)
        Me.lblDefaultMainMemberName.Name = "lblDefaultMainMemberName"
        Me.lblDefaultMainMemberName.Size = New System.Drawing.Size(160, 20)
        Me.lblDefaultMainMemberName.TabIndex = 61
        Me.lblDefaultMainMemberName.Text = "Default Main Member Name"
        '
        'chkCaptureMemberCardNo
        '
        Me.chkCaptureMemberCardNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkCaptureMemberCardNo, "CaptureMemberCardNo")
        Me.chkCaptureMemberCardNo.Enabled = False
        Me.chkCaptureMemberCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCaptureMemberCardNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkCaptureMemberCardNo.Location = New System.Drawing.Point(347, 366)
        Me.chkCaptureMemberCardNo.Name = "chkCaptureMemberCardNo"
        Me.chkCaptureMemberCardNo.Size = New System.Drawing.Size(178, 17)
        Me.chkCaptureMemberCardNo.TabIndex = 65
        Me.chkCaptureMemberCardNo.Text = "Capture Member Card No"
        '
        'stbDefaultMemberCardNo
        '
        Me.stbDefaultMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDefaultMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDefaultMemberCardNo, "DefaultMemberCardNo")
        Me.stbDefaultMemberCardNo.EntryErrorMSG = ""
        Me.stbDefaultMemberCardNo.Location = New System.Drawing.Point(513, 199)
        Me.stbDefaultMemberCardNo.MaxLength = 30
        Me.stbDefaultMemberCardNo.Name = "stbDefaultMemberCardNo"
        Me.stbDefaultMemberCardNo.RegularExpression = ""
        Me.stbDefaultMemberCardNo.Size = New System.Drawing.Size(163, 20)
        Me.stbDefaultMemberCardNo.TabIndex = 56
        '
        'lblDefaultMemberCardNo
        '
        Me.lblDefaultMemberCardNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDefaultMemberCardNo.Location = New System.Drawing.Point(347, 199)
        Me.lblDefaultMemberCardNo.Name = "lblDefaultMemberCardNo"
        Me.lblDefaultMemberCardNo.Size = New System.Drawing.Size(160, 20)
        Me.lblDefaultMemberCardNo.TabIndex = 55
        Me.lblDefaultMemberCardNo.Text = "Default Member Card No"
        '
        'btnFindMedicalCardNo
        '
        Me.btnFindMedicalCardNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindMedicalCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindMedicalCardNo.Image = CType(resources.GetObject("btnFindMedicalCardNo.Image"), System.Drawing.Image)
        Me.btnFindMedicalCardNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFindMedicalCardNo.Location = New System.Drawing.Point(149, 4)
        Me.btnFindMedicalCardNo.Name = "btnFindMedicalCardNo"
        Me.btnFindMedicalCardNo.Size = New System.Drawing.Size(28, 21)
        Me.btnFindMedicalCardNo.TabIndex = 1
        '
        'cboDefaultBillModesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDefaultBillModesID, "DefaultBillModes,DefaultBillModesID")
        Me.cboDefaultBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDefaultBillModesID.Location = New System.Drawing.Point(513, 152)
        Me.cboDefaultBillModesID.Name = "cboDefaultBillModesID"
        Me.cboDefaultBillModesID.Size = New System.Drawing.Size(163, 21)
        Me.cboDefaultBillModesID.TabIndex = 52
        '
        'lblDefaultBillModesID
        '
        Me.lblDefaultBillModesID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDefaultBillModesID.Location = New System.Drawing.Point(347, 156)
        Me.lblDefaultBillModesID.Name = "lblDefaultBillModesID"
        Me.lblDefaultBillModesID.Size = New System.Drawing.Size(160, 20)
        Me.lblDefaultBillModesID.TabIndex = 51
        Me.lblDefaultBillModesID.Text = "Default Bill Mode"
        '
        'lblNOKRelationship
        '
        Me.lblNOKRelationship.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNOKRelationship.Location = New System.Drawing.Point(9, 243)
        Me.lblNOKRelationship.Name = "lblNOKRelationship"
        Me.lblNOKRelationship.Size = New System.Drawing.Size(165, 20)
        Me.lblNOKRelationship.TabIndex = 24
        Me.lblNOKRelationship.Text = "Next of Kin Relationship"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(352, 53)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(160, 21)
        Me.chkFingerprintCaptured.TabIndex = 43
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(357, 78)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(155, 23)
        Me.btnEnrollFingerprint.TabIndex = 45
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'chkHideDetails
        '
        Me.chkHideDetails.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHideDetails, "HideDetails")
        Me.chkHideDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHideDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkHideDetails.Location = New System.Drawing.Point(540, 314)
        Me.chkHideDetails.Name = "chkHideDetails"
        Me.chkHideDetails.Size = New System.Drawing.Size(141, 15)
        Me.chkHideDetails.TabIndex = 64
        Me.chkHideDetails.Text = "Hide Details"
        '
        'stbNOKName
        '
        Me.stbNOKName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNOKName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNOKName, "NOKName")
        Me.stbNOKName.EntryErrorMSG = ""
        Me.stbNOKName.Location = New System.Drawing.Point(182, 220)
        Me.stbNOKName.MaxLength = 41
        Me.stbNOKName.Name = "stbNOKName"
        Me.stbNOKName.RegularExpression = ""
        Me.stbNOKName.Size = New System.Drawing.Size(155, 20)
        Me.stbNOKName.TabIndex = 23
        '
        'lblNOKName
        '
        Me.lblNOKName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNOKName.Location = New System.Drawing.Point(9, 222)
        Me.lblNOKName.Name = "lblNOKName"
        Me.lblNOKName.Size = New System.Drawing.Size(165, 20)
        Me.lblNOKName.TabIndex = 22
        Me.lblNOKName.Text = "Next of Kin Name"
        '
        'stbNOKPhone
        '
        Me.stbNOKPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNOKPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNOKPhone, "NOKPhone")
        Me.stbNOKPhone.EntryErrorMSG = "Invalid phone number"
        Me.stbNOKPhone.Location = New System.Drawing.Point(182, 264)
        Me.stbNOKPhone.MaxLength = 30
        Me.stbNOKPhone.Name = "stbNOKPhone"
        Me.stbNOKPhone.RegularExpression = "^\+?\d{10,15}(,\+?\d{10,15})*$"
        Me.stbNOKPhone.Size = New System.Drawing.Size(155, 20)
        Me.stbNOKPhone.TabIndex = 27
        '
        'lblNOKPhone
        '
        Me.lblNOKPhone.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNOKPhone.Location = New System.Drawing.Point(9, 265)
        Me.lblNOKPhone.Name = "lblNOKPhone"
        Me.lblNOKPhone.Size = New System.Drawing.Size(165, 20)
        Me.lblNOKPhone.TabIndex = 26
        Me.lblNOKPhone.Text = "Next of Kin Phone Number"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(513, 257)
        Me.stbInsuranceName.MaxLength = 60
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(163, 32)
        Me.stbInsuranceName.TabIndex = 60
        '
        'lblInsuranceName
        '
        Me.lblInsuranceName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInsuranceName.Location = New System.Drawing.Point(347, 262)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(160, 20)
        Me.lblInsuranceName.TabIndex = 59
        Me.lblInsuranceName.Text = "Default Insurance Name"
        '
        'btnClearPhoto
        '
        Me.btnClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClearPhoto.Location = New System.Drawing.Point(629, 78)
        Me.btnClearPhoto.Name = "btnClearPhoto"
        Me.btnClearPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnClearPhoto.TabIndex = 46
        Me.btnClearPhoto.Text = "Clear"
        Me.btnClearPhoto.UseVisualStyleBackColor = True
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(519, 4)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(100, 100)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 100
        Me.spbPhoto.TabStop = False
        '
        'btnLoadPhoto
        '
        Me.btnLoadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLoadPhoto.Location = New System.Drawing.Point(629, 7)
        Me.btnLoadPhoto.Name = "btnLoadPhoto"
        Me.btnLoadPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnLoadPhoto.TabIndex = 42
        Me.btnLoadPhoto.Text = "Load..."
        Me.btnLoadPhoto.UseVisualStyleBackColor = True
        '
        'lblPhoto
        '
        Me.lblPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPhoto.Location = New System.Drawing.Point(428, 8)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(84, 20)
        Me.lblPhoto.TabIndex = 41
        Me.lblPhoto.Text = "Photo"
        '
        'chkEnforceDefaultBillNo
        '
        Me.chkEnforceDefaultBillNo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkEnforceDefaultBillNo, "EnforceDefaultBillNo")
        Me.chkEnforceDefaultBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnforceDefaultBillNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkEnforceDefaultBillNo.Location = New System.Drawing.Point(347, 314)
        Me.chkEnforceDefaultBillNo.Name = "chkEnforceDefaultBillNo"
        Me.chkEnforceDefaultBillNo.Size = New System.Drawing.Size(178, 15)
        Me.chkEnforceDefaultBillNo.TabIndex = 63
        Me.chkEnforceDefaultBillNo.Text = "Enforce Default Bill"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(513, 221)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(163, 34)
        Me.stbBillCustomerName.TabIndex = 58
        '
        'cboDefaultBillNo
        '
        Me.cboDefaultBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDefaultBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDefaultBillNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboDefaultBillNo, "DefaultBillNo")
        Me.cboDefaultBillNo.DropDownWidth = 256
        Me.cboDefaultBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDefaultBillNo.FormattingEnabled = True
        Me.cboDefaultBillNo.ItemHeight = 13
        Me.cboDefaultBillNo.Location = New System.Drawing.Point(513, 175)
        Me.cboDefaultBillNo.MaxLength = 20
        Me.cboDefaultBillNo.Name = "cboDefaultBillNo"
        Me.cboDefaultBillNo.Size = New System.Drawing.Size(163, 21)
        Me.cboDefaultBillNo.TabIndex = 54
        '
        'lblDefaultBillCustomerName
        '
        Me.lblDefaultBillCustomerName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDefaultBillCustomerName.Location = New System.Drawing.Point(347, 226)
        Me.lblDefaultBillCustomerName.Name = "lblDefaultBillCustomerName"
        Me.lblDefaultBillCustomerName.Size = New System.Drawing.Size(160, 20)
        Me.lblDefaultBillCustomerName.TabIndex = 57
        Me.lblDefaultBillCustomerName.Text = "Default Bill Customer Name"
        '
        'lblDefaultBillNo
        '
        Me.lblDefaultBillNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDefaultBillNo.Location = New System.Drawing.Point(347, 179)
        Me.lblDefaultBillNo.Name = "lblDefaultBillNo"
        Me.lblDefaultBillNo.Size = New System.Drawing.Size(160, 20)
        Me.lblDefaultBillNo.TabIndex = 53
        Me.lblDefaultBillNo.Tag = ""
        Me.lblDefaultBillNo.Text = "Default Bill Number"
        '
        'dtpJoinDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpJoinDate, "JoinDate")
        Me.dtpJoinDate.Location = New System.Drawing.Point(182, 178)
        Me.dtpJoinDate.Name = "dtpJoinDate"
        Me.dtpJoinDate.ShowCheckBox = True
        Me.dtpJoinDate.Size = New System.Drawing.Size(155, 20)
        Me.dtpJoinDate.TabIndex = 19
        '
        'lblJoinDate
        '
        Me.lblJoinDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblJoinDate.Location = New System.Drawing.Point(9, 179)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(174, 20)
        Me.lblJoinDate.TabIndex = 18
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = "Invalid phone number (number should not exceed 15 digits. In the case of 2 number" & _
    "s, please separate them with a comma. + is allowed)"
        Me.stbPhone.Location = New System.Drawing.Point(182, 199)
        Me.stbPhone.MaxLength = 33
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = "^\+?\d{10,15}(,\+?\d{10,15})*$"
        Me.stbPhone.Size = New System.Drawing.Size(155, 20)
        Me.stbPhone.TabIndex = 21
        '
        'fcbGenderID
        '
        Me.fcbGenderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbGenderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbGenderID, "Gender,GenderID")
        Me.fcbGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbGenderID.FormattingEnabled = True
        Me.fcbGenderID.Location = New System.Drawing.Point(182, 133)
        Me.fcbGenderID.Name = "fcbGenderID"
        Me.fcbGenderID.ReadOnly = True
        Me.fcbGenderID.Size = New System.Drawing.Size(155, 21)
        Me.fcbGenderID.TabIndex = 15
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(182, 111)
        Me.nbxAge.MaxLength = 3
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(65, 20)
        Me.nbxAge.TabIndex = 13
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Location = New System.Drawing.Point(182, 90)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(155, 20)
        Me.dtpBirthDate.TabIndex = 11
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(182, 47)
        Me.stbLastName.MaxLength = 20
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(155, 20)
        Me.stbLastName.TabIndex = 7
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(182, 68)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(155, 20)
        Me.stbFirstName.TabIndex = 9
        '
        'stbPatientNo
        '
        Me.stbPatientNo.AccessibleDescription = ""
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(182, 5)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(155, 20)
        Me.stbPatientNo.TabIndex = 2
        '
        'pnlStatusID
        '
        Me.pnlStatusID.Controls.Add(Me.fcbStatusID)
        Me.pnlStatusID.Controls.Add(Me.lblStatusID)
        Me.pnlStatusID.Location = New System.Drawing.Point(344, 334)
        Me.pnlStatusID.Name = "pnlStatusID"
        Me.pnlStatusID.Size = New System.Drawing.Size(350, 29)
        Me.pnlStatusID.TabIndex = 52
        '
        'fcbStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbStatusID, "Status,StatusID")
        Me.fcbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbStatusID.FormattingEnabled = True
        Me.fcbStatusID.Location = New System.Drawing.Point(169, 4)
        Me.fcbStatusID.Name = "fcbStatusID"
        Me.fcbStatusID.ReadOnly = True
        Me.fcbStatusID.Size = New System.Drawing.Size(163, 21)
        Me.fcbStatusID.TabIndex = 1
        '
        'lblStatusID
        '
        Me.lblStatusID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStatusID.Location = New System.Drawing.Point(4, 4)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(162, 21)
        Me.lblStatusID.TabIndex = 0
        Me.lblStatusID.Text = "Status"
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPhoneNo.Location = New System.Drawing.Point(9, 202)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(178, 20)
        Me.lblPhoneNo.TabIndex = 20
        Me.lblPhoneNo.Text = "Phone N&o (Comma Separated)"
        '
        'lblOccupation
        '
        Me.lblOccupation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblOccupation.Location = New System.Drawing.Point(9, 158)
        Me.lblOccupation.Name = "lblOccupation"
        Me.lblOccupation.Size = New System.Drawing.Size(178, 20)
        Me.lblOccupation.TabIndex = 16
        Me.lblOccupation.Text = "Occupation"
        '
        'lblAge
        '
        Me.lblAge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAge.Location = New System.Drawing.Point(9, 112)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(174, 20)
        Me.lblAge.TabIndex = 12
        Me.lblAge.Text = "Age"
        '
        'lblSurname
        '
        Me.lblSurname.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSurname.Location = New System.Drawing.Point(9, 49)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(174, 20)
        Me.lblSurname.TabIndex = 6
        Me.lblSurname.Text = "Surname (Local Name)"
        '
        'lblGenderID
        '
        Me.lblGenderID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGenderID.Location = New System.Drawing.Point(9, 135)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(174, 20)
        Me.lblGenderID.TabIndex = 14
        Me.lblGenderID.Text = "Gender"
        '
        'lblFirstName
        '
        Me.lblFirstName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFirstName.Location = New System.Drawing.Point(9, 70)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(174, 20)
        Me.lblFirstName.TabIndex = 8
        Me.lblFirstName.Text = "First Name"
        '
        'lblDoB
        '
        Me.lblDoB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDoB.Location = New System.Drawing.Point(9, 91)
        Me.lblDoB.Name = "lblDoB"
        Me.lblDoB.Size = New System.Drawing.Size(174, 20)
        Me.lblDoB.TabIndex = 10
        Me.lblDoB.Text = "Date of Birth"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPatientsNo.Location = New System.Drawing.Point(9, 6)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(95, 20)
        Me.lblPatientsNo.TabIndex = 0
        Me.lblPatientsNo.Text = "Patient's Number"
        '
        'grpGeographicalLocation
        '
        Me.grpGeographicalLocation.Location = New System.Drawing.Point(-1, 306)
        Me.grpGeographicalLocation.Name = "grpGeographicalLocation"
        Me.grpGeographicalLocation.Size = New System.Drawing.Size(346, 123)
        Me.grpGeographicalLocation.TabIndex = 102
        Me.grpGeographicalLocation.TabStop = False
        Me.grpGeographicalLocation.Visible = False
        '
        'tpgMiscellaneous
        '
        Me.tpgMiscellaneous.Controls.Add(Me.stbMiddleName)
        Me.tpgMiscellaneous.Controls.Add(Me.lblMiddleName)
        Me.tpgMiscellaneous.Controls.Add(Me.stbReferenceNo)
        Me.tpgMiscellaneous.Controls.Add(Me.lblReferenceNo)
        Me.tpgMiscellaneous.Controls.Add(Me.stbEmail)
        Me.tpgMiscellaneous.Controls.Add(Me.lblEmail)
        Me.tpgMiscellaneous.Controls.Add(Me.stbBirthPlace)
        Me.tpgMiscellaneous.Controls.Add(Me.lblBirthPlace)
        Me.tpgMiscellaneous.Controls.Add(Me.stbAddress)
        Me.tpgMiscellaneous.Controls.Add(Me.lblAddress)
        Me.tpgMiscellaneous.Controls.Add(Me.Panel2)
        Me.tpgMiscellaneous.Controls.Add(Me.nbxXrayNumbers)
        Me.tpgMiscellaneous.Controls.Add(Me.chkInfectiousDiseasesNotified)
        Me.tpgMiscellaneous.Controls.Add(Me.Label1)
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
        Me.tpgMiscellaneous.Controls.Add(Me.pnlBloodGroupID)
        Me.tpgMiscellaneous.Controls.Add(Me.chkPoliceNotified)
        Me.tpgMiscellaneous.Location = New System.Drawing.Point(4, 22)
        Me.tpgMiscellaneous.Name = "tpgMiscellaneous"
        Me.tpgMiscellaneous.Size = New System.Drawing.Size(695, 491)
        Me.tpgMiscellaneous.TabIndex = 5
        Me.tpgMiscellaneous.Tag = "Patients"
        Me.tpgMiscellaneous.Text = "Miscellaneous"
        Me.tpgMiscellaneous.UseVisualStyleBackColor = True
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        Me.stbMiddleName.Location = New System.Drawing.Point(194, 39)
        Me.stbMiddleName.MaxLength = 20
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        Me.stbMiddleName.Size = New System.Drawing.Size(155, 20)
        Me.stbMiddleName.TabIndex = 2
        '
        'lblMiddleName
        '
        Me.lblMiddleName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMiddleName.Location = New System.Drawing.Point(14, 40)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(156, 20)
        Me.lblMiddleName.TabIndex = 1
        Me.lblMiddleName.Text = "Other Name"
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferenceNo, "ReferenceNo")
        Me.stbReferenceNo.EntryErrorMSG = ""
        Me.stbReferenceNo.Location = New System.Drawing.Point(194, 162)
        Me.stbReferenceNo.MaxLength = 20
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        Me.stbReferenceNo.Size = New System.Drawing.Size(155, 20)
        Me.stbReferenceNo.TabIndex = 12
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferenceNo.Location = New System.Drawing.Point(13, 160)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(127, 20)
        Me.lblReferenceNo.TabIndex = 11
        Me.lblReferenceNo.Text = "Reference No"
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmail, "Email")
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbEmail.Location = New System.Drawing.Point(194, 104)
        Me.stbEmail.MaxLength = 40
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4" & _
    "}|[0-9]{1,3})(\]?)$"
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbEmail.Size = New System.Drawing.Size(155, 20)
        Me.stbEmail.TabIndex = 8
        '
        'lblEmail
        '
        Me.lblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmail.Location = New System.Drawing.Point(13, 110)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(157, 20)
        Me.lblEmail.TabIndex = 7
        Me.lblEmail.Text = "E-Mail"
        '
        'stbBirthPlace
        '
        Me.stbBirthPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBirthPlace.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBirthPlace, "BirthPlace")
        Me.stbBirthPlace.EntryErrorMSG = ""
        Me.stbBirthPlace.Location = New System.Drawing.Point(194, 83)
        Me.stbBirthPlace.MaxLength = 20
        Me.stbBirthPlace.Name = "stbBirthPlace"
        Me.stbBirthPlace.RegularExpression = ""
        Me.stbBirthPlace.Size = New System.Drawing.Size(155, 20)
        Me.stbBirthPlace.TabIndex = 6
        '
        'lblBirthPlace
        '
        Me.lblBirthPlace.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBirthPlace.Location = New System.Drawing.Point(13, 81)
        Me.lblBirthPlace.Name = "lblBirthPlace"
        Me.lblBirthPlace.Size = New System.Drawing.Size(127, 20)
        Me.lblBirthPlace.TabIndex = 5
        Me.lblBirthPlace.Text = "Birth Place"
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(194, 127)
        Me.stbAddress.MaxLength = 100
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(155, 32)
        Me.stbAddress.TabIndex = 10
        '
        'lblAddress
        '
        Me.lblAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAddress.Location = New System.Drawing.Point(13, 140)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(157, 20)
        Me.lblAddress.TabIndex = 9
        Me.lblAddress.Text = "Address"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.cboEducationLevelID)
        Me.Panel2.Controls.Add(Me.lblEducationLevel)
        Me.Panel2.Location = New System.Drawing.Point(2, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(350, 29)
        Me.Panel2.TabIndex = 0
        '
        'cboEducationLevelID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEducationLevelID, "EducationLevel,EducationLevelID")
        Me.cboEducationLevelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEducationLevelID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEducationLevelID.Location = New System.Drawing.Point(177, 4)
        Me.cboEducationLevelID.Name = "cboEducationLevelID"
        Me.cboEducationLevelID.Size = New System.Drawing.Size(170, 21)
        Me.cboEducationLevelID.TabIndex = 1
        '
        'lblEducationLevel
        '
        Me.lblEducationLevel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEducationLevel.Location = New System.Drawing.Point(9, 4)
        Me.lblEducationLevel.Name = "lblEducationLevel"
        Me.lblEducationLevel.Size = New System.Drawing.Size(159, 20)
        Me.lblEducationLevel.TabIndex = 0
        Me.lblEducationLevel.Text = "Education Level"
        '
        'nbxXrayNumbers
        '
        Me.nbxXrayNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxXrayNumbers.ControlCaption = "Xray Numbers"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxXrayNumbers, "XrayNumbers")
        Me.nbxXrayNumbers.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxXrayNumbers.DecimalPlaces = 2
        Me.nbxXrayNumbers.Location = New System.Drawing.Point(194, 184)
        Me.nbxXrayNumbers.MaxLength = 5
        Me.nbxXrayNumbers.MaxValue = 1000.0R
        Me.nbxXrayNumbers.MinValue = 0.0R
        Me.nbxXrayNumbers.MustEnterNumeric = True
        Me.nbxXrayNumbers.Name = "nbxXrayNumbers"
        Me.nbxXrayNumbers.Size = New System.Drawing.Size(155, 20)
        Me.nbxXrayNumbers.TabIndex = 14
        Me.nbxXrayNumbers.Value = ""
        '
        'chkInfectiousDiseasesNotified
        '
        Me.chkInfectiousDiseasesNotified.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkInfectiousDiseasesNotified, "InfectiousDiseasesNotified")
        Me.chkInfectiousDiseasesNotified.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkInfectiousDiseasesNotified.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkInfectiousDiseasesNotified.Location = New System.Drawing.Point(359, 165)
        Me.chkInfectiousDiseasesNotified.Name = "chkInfectiousDiseasesNotified"
        Me.chkInfectiousDiseasesNotified.Size = New System.Drawing.Size(300, 23)
        Me.chkInfectiousDiseasesNotified.TabIndex = 29
        Me.chkInfectiousDiseasesNotified.Text = "Infectious Diseases Notified"
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(13, 184)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "X-ray Numbers"
        '
        'pnlMaritalStatus
        '
        Me.pnlMaritalStatus.Controls.Add(Me.cboMaritalStatusID)
        Me.pnlMaritalStatus.Controls.Add(Me.lblMaritalStatusID)
        Me.pnlMaritalStatus.Location = New System.Drawing.Point(355, 39)
        Me.pnlMaritalStatus.Name = "pnlMaritalStatus"
        Me.pnlMaritalStatus.Size = New System.Drawing.Size(320, 31)
        Me.pnlMaritalStatus.TabIndex = 26
        '
        'cboMaritalStatusID
        '
        Me.cboMaritalStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMaritalStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboMaritalStatusID, "MaritalStatus,MaritalStatusID")
        Me.cboMaritalStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaritalStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMaritalStatusID.Location = New System.Drawing.Point(157, 6)
        Me.cboMaritalStatusID.Name = "cboMaritalStatusID"
        Me.cboMaritalStatusID.Size = New System.Drawing.Size(155, 21)
        Me.cboMaritalStatusID.TabIndex = 1
        '
        'lblMaritalStatusID
        '
        Me.lblMaritalStatusID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMaritalStatusID.Location = New System.Drawing.Point(12, 9)
        Me.lblMaritalStatusID.Name = "lblMaritalStatusID"
        Me.lblMaritalStatusID.Size = New System.Drawing.Size(148, 20)
        Me.lblMaritalStatusID.TabIndex = 0
        Me.lblMaritalStatusID.Text = "Marital Status"
        '
        'pnlCareEntryPointID
        '
        Me.pnlCareEntryPointID.Controls.Add(Me.cboCommunityID)
        Me.pnlCareEntryPointID.Controls.Add(Me.lblCommunityID)
        Me.pnlCareEntryPointID.Controls.Add(Me.cboCareEntryPointID)
        Me.pnlCareEntryPointID.Controls.Add(Me.lblCareEntryPointID)
        Me.pnlCareEntryPointID.Location = New System.Drawing.Point(355, 71)
        Me.pnlCareEntryPointID.Name = "pnlCareEntryPointID"
        Me.pnlCareEntryPointID.Size = New System.Drawing.Size(321, 67)
        Me.pnlCareEntryPointID.TabIndex = 27
        '
        'cboCommunityID
        '
        Me.cboCommunityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommunityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCommunityID, "CommunityID")
        Me.cboCommunityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommunityID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCommunityID.Location = New System.Drawing.Point(157, 29)
        Me.cboCommunityID.Name = "cboCommunityID"
        Me.cboCommunityID.Size = New System.Drawing.Size(155, 21)
        Me.cboCommunityID.TabIndex = 3
        '
        'lblCommunityID
        '
        Me.lblCommunityID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCommunityID.Location = New System.Drawing.Point(13, 29)
        Me.lblCommunityID.Name = "lblCommunityID"
        Me.lblCommunityID.Size = New System.Drawing.Size(147, 20)
        Me.lblCommunityID.TabIndex = 2
        Me.lblCommunityID.Text = "Community "
        '
        'cboCareEntryPointID
        '
        Me.cboCareEntryPointID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCareEntryPointID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCareEntryPointID, "CareEntryPoint,CareEntryPointID")
        Me.cboCareEntryPointID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCareEntryPointID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCareEntryPointID.Location = New System.Drawing.Point(157, 6)
        Me.cboCareEntryPointID.Name = "cboCareEntryPointID"
        Me.cboCareEntryPointID.Size = New System.Drawing.Size(155, 21)
        Me.cboCareEntryPointID.TabIndex = 1
        '
        'lblCareEntryPointID
        '
        Me.lblCareEntryPointID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCareEntryPointID.Location = New System.Drawing.Point(13, 6)
        Me.lblCareEntryPointID.Name = "lblCareEntryPointID"
        Me.lblCareEntryPointID.Size = New System.Drawing.Size(147, 20)
        Me.lblCareEntryPointID.TabIndex = 0
        Me.lblCareEntryPointID.Text = "Care Entry Point"
        '
        'lblChronicDiseases
        '
        Me.lblChronicDiseases.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblChronicDiseases.Location = New System.Drawing.Point(356, 200)
        Me.lblChronicDiseases.Name = "lblChronicDiseases"
        Me.lblChronicDiseases.Size = New System.Drawing.Size(317, 20)
        Me.lblChronicDiseases.TabIndex = 30
        Me.lblChronicDiseases.Text = "Chronic Diseases"
        Me.lblChronicDiseases.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'clbChronicDiseases
        '
        Me.clbChronicDiseases.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbChronicDiseases, "ChronicDiseases")
        Me.clbChronicDiseases.FormattingEnabled = True
        Me.clbChronicDiseases.Location = New System.Drawing.Point(360, 223)
        Me.clbChronicDiseases.Name = "clbChronicDiseases"
        Me.clbChronicDiseases.Size = New System.Drawing.Size(327, 150)
        Me.clbChronicDiseases.TabIndex = 31
        '
        'stbEmployer
        '
        Me.stbEmployer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmployer.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmployer, "Employer")
        Me.stbEmployer.EntryErrorMSG = ""
        Me.stbEmployer.Location = New System.Drawing.Point(194, 206)
        Me.stbEmployer.MaxLength = 41
        Me.stbEmployer.Name = "stbEmployer"
        Me.stbEmployer.RegularExpression = ""
        Me.stbEmployer.Size = New System.Drawing.Size(155, 20)
        Me.stbEmployer.TabIndex = 16
        '
        'lblEmployer
        '
        Me.lblEmployer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmployer.Location = New System.Drawing.Point(13, 205)
        Me.lblEmployer.Name = "lblEmployer"
        Me.lblEmployer.Size = New System.Drawing.Size(127, 20)
        Me.lblEmployer.TabIndex = 15
        Me.lblEmployer.Text = "Employer"
        '
        'stbEmployerAddress
        '
        Me.stbEmployerAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmployerAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmployerAddress, "EmployerAddress")
        Me.stbEmployerAddress.EntryErrorMSG = ""
        Me.stbEmployerAddress.Location = New System.Drawing.Point(194, 227)
        Me.stbEmployerAddress.MaxLength = 100
        Me.stbEmployerAddress.Multiline = True
        Me.stbEmployerAddress.Name = "stbEmployerAddress"
        Me.stbEmployerAddress.RegularExpression = ""
        Me.stbEmployerAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbEmployerAddress.Size = New System.Drawing.Size(155, 30)
        Me.stbEmployerAddress.TabIndex = 18
        '
        'lblEmployerAddress
        '
        Me.lblEmployerAddress.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblEmployerAddress.Location = New System.Drawing.Point(13, 230)
        Me.lblEmployerAddress.Name = "lblEmployerAddress"
        Me.lblEmployerAddress.Size = New System.Drawing.Size(157, 20)
        Me.lblEmployerAddress.TabIndex = 17
        Me.lblEmployerAddress.Text = "Employer Address"
        '
        'stbReferringMedicalOfficer
        '
        Me.stbReferringMedicalOfficer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferringMedicalOfficer.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferringMedicalOfficer, "ReferringMedicalOfficer")
        Me.stbReferringMedicalOfficer.EntryErrorMSG = ""
        Me.stbReferringMedicalOfficer.Location = New System.Drawing.Point(194, 258)
        Me.stbReferringMedicalOfficer.MaxLength = 41
        Me.stbReferringMedicalOfficer.Name = "stbReferringMedicalOfficer"
        Me.stbReferringMedicalOfficer.RegularExpression = ""
        Me.stbReferringMedicalOfficer.Size = New System.Drawing.Size(155, 20)
        Me.stbReferringMedicalOfficer.TabIndex = 20
        '
        'lblReferringMedicalOfficer
        '
        Me.lblReferringMedicalOfficer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblReferringMedicalOfficer.Location = New System.Drawing.Point(13, 257)
        Me.lblReferringMedicalOfficer.Name = "lblReferringMedicalOfficer"
        Me.lblReferringMedicalOfficer.Size = New System.Drawing.Size(175, 20)
        Me.lblReferringMedicalOfficer.TabIndex = 19
        Me.lblReferringMedicalOfficer.Text = "Referring Medical Officer"
        '
        'stbNearestDispensary
        '
        Me.stbNearestDispensary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNearestDispensary.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNearestDispensary, "NearestDispensary")
        Me.stbNearestDispensary.EntryErrorMSG = ""
        Me.stbNearestDispensary.Location = New System.Drawing.Point(194, 279)
        Me.stbNearestDispensary.MaxLength = 30
        Me.stbNearestDispensary.Name = "stbNearestDispensary"
        Me.stbNearestDispensary.RegularExpression = ""
        Me.stbNearestDispensary.Size = New System.Drawing.Size(155, 20)
        Me.stbNearestDispensary.TabIndex = 22
        '
        'lblNearestDispensary
        '
        Me.lblNearestDispensary.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblNearestDispensary.Location = New System.Drawing.Point(13, 278)
        Me.lblNearestDispensary.Name = "lblNearestDispensary"
        Me.lblNearestDispensary.Size = New System.Drawing.Size(157, 20)
        Me.lblNearestDispensary.TabIndex = 21
        Me.lblNearestDispensary.Text = "Nearest Dispensary"
        '
        'stbPreviousAdmissions
        '
        Me.stbPreviousAdmissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPreviousAdmissions.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPreviousAdmissions, "PreviousAdmissions")
        Me.stbPreviousAdmissions.EntryErrorMSG = ""
        Me.stbPreviousAdmissions.Location = New System.Drawing.Point(194, 300)
        Me.stbPreviousAdmissions.MaxLength = 30
        Me.stbPreviousAdmissions.Name = "stbPreviousAdmissions"
        Me.stbPreviousAdmissions.RegularExpression = ""
        Me.stbPreviousAdmissions.Size = New System.Drawing.Size(155, 20)
        Me.stbPreviousAdmissions.TabIndex = 24
        '
        'lblPreviousAdmissions
        '
        Me.lblPreviousAdmissions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPreviousAdmissions.Location = New System.Drawing.Point(13, 299)
        Me.lblPreviousAdmissions.Name = "lblPreviousAdmissions"
        Me.lblPreviousAdmissions.Size = New System.Drawing.Size(157, 20)
        Me.lblPreviousAdmissions.TabIndex = 23
        Me.lblPreviousAdmissions.Text = "Previous Admissions"
        '
        'pnlBloodGroupID
        '
        Me.pnlBloodGroupID.Controls.Add(Me.cboBloodGroupID)
        Me.pnlBloodGroupID.Controls.Add(Me.lblBloodGroupID)
        Me.pnlBloodGroupID.Location = New System.Drawing.Point(355, 9)
        Me.pnlBloodGroupID.Name = "pnlBloodGroupID"
        Me.pnlBloodGroupID.Size = New System.Drawing.Size(318, 29)
        Me.pnlBloodGroupID.TabIndex = 25
        '
        'cboBloodGroupID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBloodGroupID, "BloodGroup,BloodGroupID")
        Me.cboBloodGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBloodGroupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBloodGroupID.Location = New System.Drawing.Point(157, 4)
        Me.cboBloodGroupID.Name = "cboBloodGroupID"
        Me.cboBloodGroupID.Size = New System.Drawing.Size(155, 21)
        Me.cboBloodGroupID.TabIndex = 1
        '
        'lblBloodGroupID
        '
        Me.lblBloodGroupID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBloodGroupID.Location = New System.Drawing.Point(12, 4)
        Me.lblBloodGroupID.Name = "lblBloodGroupID"
        Me.lblBloodGroupID.Size = New System.Drawing.Size(148, 20)
        Me.lblBloodGroupID.TabIndex = 0
        Me.lblBloodGroupID.Text = "Blood Group"
        '
        'chkPoliceNotified
        '
        Me.chkPoliceNotified.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkPoliceNotified, "PoliceNotified")
        Me.chkPoliceNotified.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPoliceNotified.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPoliceNotified.Location = New System.Drawing.Point(360, 144)
        Me.chkPoliceNotified.Name = "chkPoliceNotified"
        Me.chkPoliceNotified.Size = New System.Drawing.Size(298, 22)
        Me.chkPoliceNotified.TabIndex = 28
        Me.chkPoliceNotified.Text = "Police Notified"
        '
        'tpgPatientAllergies
        '
        Me.tpgPatientAllergies.Controls.Add(Me.dgvPatientAllergies)
        Me.tpgPatientAllergies.Location = New System.Drawing.Point(4, 22)
        Me.tpgPatientAllergies.Name = "tpgPatientAllergies"
        Me.tpgPatientAllergies.Size = New System.Drawing.Size(695, 491)
        Me.tpgPatientAllergies.TabIndex = 3
        Me.tpgPatientAllergies.Tag = "PatientAllergies"
        Me.tpgPatientAllergies.Text = "Allergies"
        Me.tpgPatientAllergies.UseVisualStyleBackColor = True
        '
        'dgvPatientAllergies
        '
        Me.dgvPatientAllergies.AllowUserToOrderColumns = True
        Me.dgvPatientAllergies.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPatientAllergies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAllergyNo, Me.colAllergyCategory, Me.colReaction, Me.colPatientAllergiesSaved})
        Me.dgvPatientAllergies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPatientAllergies.EnableHeadersVisualStyles = False
        Me.dgvPatientAllergies.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientAllergies.Location = New System.Drawing.Point(0, 0)
        Me.dgvPatientAllergies.Name = "dgvPatientAllergies"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPatientAllergies.Size = New System.Drawing.Size(695, 491)
        Me.dgvPatientAllergies.TabIndex = 0
        Me.dgvPatientAllergies.Text = "DataGridView1"
        '
        'colAllergyNo
        '
        Me.colAllergyNo.DataPropertyName = "AllergyNo"
        Me.colAllergyNo.DisplayStyleForCurrentCellOnly = True
        Me.colAllergyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAllergyNo.HeaderText = "Allergy"
        Me.colAllergyNo.Name = "colAllergyNo"
        Me.colAllergyNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAllergyNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAllergyNo.Width = 250
        '
        'colAllergyCategory
        '
        Me.colAllergyCategory.DataPropertyName = "AllergyCategory"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colAllergyCategory.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAllergyCategory.HeaderText = "Category"
        Me.colAllergyCategory.Name = "colAllergyCategory"
        Me.colAllergyCategory.ReadOnly = True
        Me.colAllergyCategory.Width = 80
        '
        'colReaction
        '
        Me.colReaction.DataPropertyName = "Reaction"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colReaction.DefaultCellStyle = DataGridViewCellStyle3
        Me.colReaction.HeaderText = "Reaction"
        Me.colReaction.MaxInputLength = 200
        Me.colReaction.Name = "colReaction"
        Me.colReaction.Width = 180
        '
        'colPatientAllergiesSaved
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = False
        Me.colPatientAllergiesSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPatientAllergiesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPatientAllergiesSaved.HeaderText = "Saved"
        Me.colPatientAllergiesSaved.Name = "colPatientAllergiesSaved"
        Me.colPatientAllergiesSaved.ReadOnly = True
        Me.colPatientAllergiesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPatientAllergiesSaved.Width = 50
        '
        'tpgProvisionalDiagnosis
        '
        Me.tpgProvisionalDiagnosis.Controls.Add(Me.stbProvisionalDiagnosis)
        Me.tpgProvisionalDiagnosis.Controls.Add(Me.lblProvisionalDiagnosis)
        Me.tpgProvisionalDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgProvisionalDiagnosis.Name = "tpgProvisionalDiagnosis"
        Me.tpgProvisionalDiagnosis.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgProvisionalDiagnosis.Size = New System.Drawing.Size(695, 491)
        Me.tpgProvisionalDiagnosis.TabIndex = 6
        Me.tpgProvisionalDiagnosis.Text = "Provisional Diagnosis"
        Me.tpgProvisionalDiagnosis.UseVisualStyleBackColor = True
        '
        'stbProvisionalDiagnosis
        '
        Me.stbProvisionalDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalDiagnosis.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbProvisionalDiagnosis, "ProvisionalDiagnosis")
        Me.stbProvisionalDiagnosis.EntryErrorMSG = ""
        Me.stbProvisionalDiagnosis.Location = New System.Drawing.Point(184, 6)
        Me.stbProvisionalDiagnosis.MaxLength = 2000
        Me.stbProvisionalDiagnosis.Multiline = True
        Me.stbProvisionalDiagnosis.Name = "stbProvisionalDiagnosis"
        Me.stbProvisionalDiagnosis.RegularExpression = ""
        Me.stbProvisionalDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProvisionalDiagnosis.Size = New System.Drawing.Size(494, 38)
        Me.stbProvisionalDiagnosis.TabIndex = 61
        '
        'lblProvisionalDiagnosis
        '
        Me.lblProvisionalDiagnosis.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProvisionalDiagnosis.Location = New System.Drawing.Point(7, 16)
        Me.lblProvisionalDiagnosis.Name = "lblProvisionalDiagnosis"
        Me.lblProvisionalDiagnosis.Size = New System.Drawing.Size(171, 20)
        Me.lblProvisionalDiagnosis.TabIndex = 60
        Me.lblProvisionalDiagnosis.Text = "Provisional Diagnosis"
        '
        'tpgMedicalCondtions
        '
        Me.tpgMedicalCondtions.Controls.Add(Me.stbMedicalConditions)
        Me.tpgMedicalCondtions.Controls.Add(Me.lblMedicalConditions)
        Me.tpgMedicalCondtions.Location = New System.Drawing.Point(4, 22)
        Me.tpgMedicalCondtions.Name = "tpgMedicalCondtions"
        Me.tpgMedicalCondtions.Size = New System.Drawing.Size(695, 491)
        Me.tpgMedicalCondtions.TabIndex = 7
        Me.tpgMedicalCondtions.Text = "Medical Condtions"
        Me.tpgMedicalCondtions.UseVisualStyleBackColor = True
        '
        'stbMedicalConditions
        '
        Me.stbMedicalConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalConditions.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedicalConditions, "MedicalConditions")
        Me.stbMedicalConditions.EntryErrorMSG = ""
        Me.stbMedicalConditions.Location = New System.Drawing.Point(185, 7)
        Me.stbMedicalConditions.MaxLength = 2000
        Me.stbMedicalConditions.Multiline = True
        Me.stbMedicalConditions.Name = "stbMedicalConditions"
        Me.stbMedicalConditions.RegularExpression = ""
        Me.stbMedicalConditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMedicalConditions.Size = New System.Drawing.Size(494, 38)
        Me.stbMedicalConditions.TabIndex = 59
        '
        'lblMedicalConditions
        '
        Me.lblMedicalConditions.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMedicalConditions.Location = New System.Drawing.Point(8, 17)
        Me.lblMedicalConditions.Name = "lblMedicalConditions"
        Me.lblMedicalConditions.Size = New System.Drawing.Size(171, 20)
        Me.lblMedicalConditions.TabIndex = 58
        Me.lblMedicalConditions.Text = "Medical Conditions"
        '
        'tpgPatientsEXT
        '
        Me.tpgPatientsEXT.Controls.Add(Me.dgvPatientsEXT)
        Me.tpgPatientsEXT.Location = New System.Drawing.Point(4, 22)
        Me.tpgPatientsEXT.Name = "tpgPatientsEXT"
        Me.tpgPatientsEXT.Size = New System.Drawing.Size(695, 491)
        Me.tpgPatientsEXT.TabIndex = 2
        Me.tpgPatientsEXT.Tag = "PatientsEXT"
        Me.tpgPatientsEXT.Text = "Alternate Numbers"
        Me.tpgPatientsEXT.UseVisualStyleBackColor = True
        '
        'dgvPatientsEXT
        '
        Me.dgvPatientsEXT.AllowUserToOrderColumns = True
        Me.dgvPatientsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPatientsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAlternateNo, Me.colNotes, Me.colPatientsEXTSaved})
        Me.dgvPatientsEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPatientsEXT.EnableHeadersVisualStyles = False
        Me.dgvPatientsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientsEXT.Location = New System.Drawing.Point(0, 0)
        Me.dgvPatientsEXT.Name = "dgvPatientsEXT"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPatientsEXT.Size = New System.Drawing.Size(695, 491)
        Me.dgvPatientsEXT.TabIndex = 0
        Me.dgvPatientsEXT.Text = "DataGridView1"
        '
        'colAlternateNo
        '
        Me.colAlternateNo.DataPropertyName = "AlternateNo"
        Me.colAlternateNo.HeaderText = "Alternate No"
        Me.colAlternateNo.MaxInputLength = 20
        Me.colAlternateNo.Name = "colAlternateNo"
        Me.colAlternateNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAlternateNo.Width = 150
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle7
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 300
        '
        'colPatientsEXTSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colPatientsEXTSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPatientsEXTSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPatientsEXTSaved.HeaderText = "Saved"
        Me.colPatientsEXTSaved.Name = "colPatientsEXTSaved"
        Me.colPatientsEXTSaved.ReadOnly = True
        Me.colPatientsEXTSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPatientsEXTSaved.Width = 50
        '
        'btnprintBioData
        '
        Me.btnprintBioData.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnprintBioData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnprintBioData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnprintBioData.Location = New System.Drawing.Point(284, 546)
        Me.btnprintBioData.Name = "btnprintBioData"
        Me.btnprintBioData.Size = New System.Drawing.Size(109, 24)
        Me.btnprintBioData.TabIndex = 6
        Me.btnprintBioData.Text = "&Print Bio Data"
        Me.btnprintBioData.Visible = False
        '
        'btnViewClients
        '
        Me.btnViewClients.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewClients.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnViewClients.Location = New System.Drawing.Point(397, 546)
        Me.btnViewClients.Name = "btnViewClients"
        Me.btnViewClients.Size = New System.Drawing.Size(109, 24)
        Me.btnViewClients.TabIndex = 7
        Me.btnViewClients.Tag = "Clients"
        Me.btnViewClients.Text = "&View Clients"
        '
        'chkPrintFaceSheetOnSaving
        '
        Me.chkPrintFaceSheetOnSaving.Checked = True
        Me.chkPrintFaceSheetOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintFaceSheetOnSaving.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPrintFaceSheetOnSaving.Location = New System.Drawing.Point(78, 551)
        Me.chkPrintFaceSheetOnSaving.Name = "chkPrintFaceSheetOnSaving"
        Me.chkPrintFaceSheetOnSaving.Size = New System.Drawing.Size(200, 20)
        Me.chkPrintFaceSheetOnSaving.TabIndex = 5
        Me.chkPrintFaceSheetOnSaving.Text = " Print Face Sheet On Saving"
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(6, 546)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(66, 24)
        Me.ebnSaveUpdate.TabIndex = 3
        Me.ebnSaveUpdate.Tag = "Patients"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fbnClose.Location = New System.Drawing.Point(643, 546)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(66, 24)
        Me.fbnClose.TabIndex = 9
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(6, 520)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(66, 24)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDelete.Location = New System.Drawing.Point(643, 520)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(66, 24)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Tag = "Patients"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrintBarcode.Location = New System.Drawing.Point(510, 546)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(129, 24)
        Me.btnPrintBarcode.TabIndex = 8
        Me.btnPrintBarcode.Text = "&Print Patient Sticker"
        Me.btnPrintBarcode.Visible = False
        '
        'chkPrintBioData
        '
        Me.chkPrintBioData.Checked = True
        Me.chkPrintBioData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintBioData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkPrintBioData.Location = New System.Drawing.Point(79, 529)
        Me.chkPrintBioData.Name = "chkPrintBioData"
        Me.chkPrintBioData.Size = New System.Drawing.Size(173, 20)
        Me.chkPrintBioData.TabIndex = 4
        Me.chkPrintBioData.Text = " Print Client Bio Data"
        '
        'frmPatientsTwo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 574)
        Me.Controls.Add(Me.tbcPatients)
        Me.Controls.Add(Me.btnprintBioData)
        Me.Controls.Add(Me.btnViewClients)
        Me.Controls.Add(Me.chkPrintFaceSheetOnSaving)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.chkPrintBioData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPatientsTwo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patients"
        Me.tbcPatients.ResumeLayout(False)
        Me.tpgGeneral.ResumeLayout(False)
        Me.tpgGeneral.PerformLayout()
        Me.pnlReligionID.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlTribeID.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusID.ResumeLayout(False)
        Me.tpgMiscellaneous.ResumeLayout(False)
        Me.tpgMiscellaneous.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlMaritalStatus.ResumeLayout(False)
        Me.pnlCareEntryPointID.ResumeLayout(False)
        Me.pnlBloodGroupID.ResumeLayout(False)
        Me.tpgPatientAllergies.ResumeLayout(False)
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgProvisionalDiagnosis.ResumeLayout(False)
        Me.tpgProvisionalDiagnosis.PerformLayout()
        Me.tpgMedicalCondtions.ResumeLayout(False)
        Me.tpgMedicalCondtions.PerformLayout()
        Me.tpgPatientsEXT.ResumeLayout(False)
        CType(Me.dgvPatientsEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkReceiveMedicalSMS As System.Windows.Forms.CheckBox
    Friend WithEvents tbcPatients As System.Windows.Forms.TabControl
    Friend WithEvents tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents cboOccupationID As System.Windows.Forms.ComboBox
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents cboNOKRelationship As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnLoadCamera As System.Windows.Forms.Button
    Friend WithEvents stbNIN As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNIN As System.Windows.Forms.Label
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
    Friend WithEvents chkHideDetails As System.Windows.Forms.CheckBox
    Friend WithEvents stbNOKName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNOKName As System.Windows.Forms.Label
    Friend WithEvents stbNOKPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNOKPhone As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnLoadPhoto As System.Windows.Forms.Button
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents chkEnforceDefaultBillNo As System.Windows.Forms.CheckBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboDefaultBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDefaultBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblDefaultBillNo As System.Windows.Forms.Label
    Friend WithEvents dtpJoinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
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
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblDoB As System.Windows.Forms.Label
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents tpgMiscellaneous As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboEducationLevelID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEducationLevel As System.Windows.Forms.Label
    Friend WithEvents nbxXrayNumbers As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents chkInfectiousDiseasesNotified As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlMaritalStatus As System.Windows.Forms.Panel
    Friend WithEvents cboMaritalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMaritalStatusID As System.Windows.Forms.Label
    Friend WithEvents pnlCareEntryPointID As System.Windows.Forms.Panel
    Friend WithEvents cboCommunityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommunityID As System.Windows.Forms.Label
    Friend WithEvents cboCareEntryPointID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCareEntryPointID As System.Windows.Forms.Label
    Friend WithEvents lblChronicDiseases As System.Windows.Forms.Label
    Friend WithEvents clbChronicDiseases As System.Windows.Forms.CheckedListBox
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
    Friend WithEvents pnlBloodGroupID As System.Windows.Forms.Panel
    Friend WithEvents cboBloodGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBloodGroupID As System.Windows.Forms.Label
    Friend WithEvents chkPoliceNotified As System.Windows.Forms.CheckBox
    Friend WithEvents tpgPatientAllergies As System.Windows.Forms.TabPage
    Friend WithEvents dgvPatientAllergies As System.Windows.Forms.DataGridView
    Friend WithEvents colAllergyNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAllergyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientAllergiesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgProvisionalDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents stbProvisionalDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProvisionalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents tpgMedicalCondtions As System.Windows.Forms.TabPage
    Friend WithEvents stbMedicalConditions As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMedicalConditions As System.Windows.Forms.Label
    Friend WithEvents tpgPatientsEXT As System.Windows.Forms.TabPage
    Friend WithEvents dgvPatientsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents colAlternateNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientsEXTSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnprintBioData As System.Windows.Forms.Button
    Friend WithEvents btnViewClients As System.Windows.Forms.Button
    Friend WithEvents chkPrintFaceSheetOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents chkPrintBioData As System.Windows.Forms.CheckBox
    Friend WithEvents pnlReligionID As System.Windows.Forms.Panel
    Friend WithEvents cboReligionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReligionID As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboCountryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents pnlTribeID As System.Windows.Forms.Panel
    Friend WithEvents cboTribeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTribeID As System.Windows.Forms.Label
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents stbBirthPlace As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBirthPlace As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
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
    Friend WithEvents stbReferringFacility As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferringfacility As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents grpGeographicalLocation As System.Windows.Forms.GroupBox
End Class
