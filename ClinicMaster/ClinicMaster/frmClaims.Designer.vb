
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaims : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaims))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.cboHealthUnitCode = New System.Windows.Forms.ComboBox()
        Me.cboClaimStatusID = New System.Windows.Forms.ComboBox()
        Me.stpVisitTime = New SyncSoft.Common.Win.Controls.SmartTimePicker()
        Me.stbMedicalCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboClaimEntryID = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbClaimNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimNo = New System.Windows.Forms.Label()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblVisitTime = New System.Windows.Forms.Label()
        Me.lblHealthUnitCode = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.lblClaimStatusID = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.tbcClaims = New System.Windows.Forms.TabControl()
        Me.tpgClaimDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsClaims = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsClaimsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgClaimDetails = New System.Windows.Forms.TabPage()
        Me.dgvClaimDetails = New System.Windows.Forms.DataGridView()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblPolicyName = New System.Windows.Forms.Label()
        Me.lblPolicyStartDate = New System.Windows.Forms.Label()
        Me.lblPolicyEndDate = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberType = New System.Windows.Forms.Label()
        Me.btnFindClaimNo = New System.Windows.Forms.Button()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.lblClaimEntry = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.navClaims = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateClaims = New System.Windows.Forms.CheckBox()
        Me.pnlNavigateClaims = New System.Windows.Forms.Panel()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBenefitCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjustment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimDetailsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colLimitAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLimitBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcClaims.SuspendLayout()
        Me.tpgClaimDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsClaims.SuspendLayout()
        Me.tpgClaimDetails.SuspendLayout()
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateClaims.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 476)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 48
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(656, 476)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 50
        Me.fbnDelete.Tag = "Claims"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 503)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 49
        Me.ebnSaveUpdate.Tag = "Claims"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(142, 48)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 6
        '
        'dtpVisitDate
        '
        Me.dtpVisitDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpVisitDate, "VisitDate")
        Me.dtpVisitDate.Location = New System.Drawing.Point(142, 69)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.ShowCheckBox = True
        Me.dtpVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpVisitDate.TabIndex = 8
        '
        'cboHealthUnitCode
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHealthUnitCode, "HealthUnitName,HealthUnitCode")
        Me.cboHealthUnitCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHealthUnitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnitCode.Location = New System.Drawing.Point(142, 111)
        Me.cboHealthUnitCode.Name = "cboHealthUnitCode"
        Me.cboHealthUnitCode.Size = New System.Drawing.Size(170, 21)
        Me.cboHealthUnitCode.TabIndex = 12
        '
        'cboClaimStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboClaimStatusID, "ClaimStatus,ClaimStatusID")
        Me.cboClaimStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClaimStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboClaimStatusID.Location = New System.Drawing.Point(142, 155)
        Me.cboClaimStatusID.Name = "cboClaimStatusID"
        Me.cboClaimStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboClaimStatusID.TabIndex = 16
        '
        'stpVisitTime
        '
        Me.stpVisitTime.Checked = False
        Me.stpVisitTime.CustomFormat = "HH:mm:ss"
        Me.ebnSaveUpdate.SetDataMember(Me.stpVisitTime, "VisitTime")
        Me.stpVisitTime.Location = New System.Drawing.Point(142, 90)
        Me.stpVisitTime.Name = "stpVisitTime"
        Me.stpVisitTime.ShowCheckBox = True
        Me.stpVisitTime.ShowUpDown = True
        Me.stpVisitTime.Size = New System.Drawing.Size(86, 20)
        Me.stpVisitTime.TabIndex = 10
        Me.stpVisitTime.TimeFormat = SyncSoft.Common.Win.Controls.TimeFormat.HHmmss
        Me.stpVisitTime.Value = New Date(2011, 9, 19, 0, 0, 0, 0)
        '
        'stbMedicalCardNo
        '
        Me.stbMedicalCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalCardNo.CapitalizeFirstLetter = False
        Me.stbMedicalCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedicalCardNo, "MedicalCardNo")
        Me.stbMedicalCardNo.EntryErrorMSG = ""
        Me.stbMedicalCardNo.Location = New System.Drawing.Point(142, 6)
        Me.stbMedicalCardNo.MaxLength = 20
        Me.stbMedicalCardNo.Name = "stbMedicalCardNo"
        Me.stbMedicalCardNo.RegularExpression = ""
        Me.stbMedicalCardNo.Size = New System.Drawing.Size(170, 20)
        Me.stbMedicalCardNo.TabIndex = 1
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(462, 25)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(172, 20)
        Me.stbAge.TabIndex = 26
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(462, 67)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(172, 20)
        Me.stbJoinDate.TabIndex = 30
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(462, 46)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(172, 20)
        Me.stbGender.TabIndex = 28
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(462, 4)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(172, 20)
        Me.stbFullName.TabIndex = 24
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(462, 160)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(172, 29)
        Me.stbInsuranceName.TabIndex = 38
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCompanyName, "CompanyName")
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(462, 130)
        Me.stbCompanyName.MaxLength = 41
        Me.stbCompanyName.Multiline = True
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.ReadOnly = True
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCompanyName.Size = New System.Drawing.Size(172, 29)
        Me.stbCompanyName.TabIndex = 36
        '
        'stbPolicyName
        '
        Me.stbPolicyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyName, "PolicyName")
        Me.stbPolicyName.Enabled = False
        Me.stbPolicyName.EntryErrorMSG = ""
        Me.stbPolicyName.Location = New System.Drawing.Point(462, 190)
        Me.stbPolicyName.MaxLength = 40
        Me.stbPolicyName.Name = "stbPolicyName"
        Me.stbPolicyName.RegularExpression = ""
        Me.stbPolicyName.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyName.TabIndex = 40
        '
        'stbPolicyStartDate
        '
        Me.stbPolicyStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyStartDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyStartDate, "PolicyStartDate")
        Me.stbPolicyStartDate.Enabled = False
        Me.stbPolicyStartDate.EntryErrorMSG = ""
        Me.stbPolicyStartDate.Location = New System.Drawing.Point(462, 211)
        Me.stbPolicyStartDate.MaxLength = 20
        Me.stbPolicyStartDate.Name = "stbPolicyStartDate"
        Me.stbPolicyStartDate.RegularExpression = ""
        Me.stbPolicyStartDate.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyStartDate.TabIndex = 42
        '
        'stbPolicyEndDate
        '
        Me.stbPolicyEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyEndDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyEndDate, "PolicyEndDate")
        Me.stbPolicyEndDate.Enabled = False
        Me.stbPolicyEndDate.EntryErrorMSG = ""
        Me.stbPolicyEndDate.Location = New System.Drawing.Point(462, 232)
        Me.stbPolicyEndDate.MaxLength = 20
        Me.stbPolicyEndDate.Name = "stbPolicyEndDate"
        Me.stbPolicyEndDate.RegularExpression = ""
        Me.stbPolicyEndDate.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyEndDate.TabIndex = 44
        '
        'stbMemberType
        '
        Me.stbMemberType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberType, "MemberType")
        Me.stbMemberType.Enabled = False
        Me.stbMemberType.EntryErrorMSG = ""
        Me.stbMemberType.Location = New System.Drawing.Point(462, 88)
        Me.stbMemberType.MaxLength = 60
        Me.stbMemberType.Name = "stbMemberType"
        Me.stbMemberType.RegularExpression = ""
        Me.stbMemberType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMemberType.Size = New System.Drawing.Size(172, 20)
        Me.stbMemberType.TabIndex = 32
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPrimaryDoctor, "PrimaryDoctor")
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(142, 134)
        Me.stbPrimaryDoctor.MaxLength = 41
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(170, 20)
        Me.stbPrimaryDoctor.TabIndex = 14
        '
        'cboClaimEntryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboClaimEntryID, "ClaimEntry,ClaimEntryID")
        Me.cboClaimEntryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClaimEntryID.Enabled = False
        Me.cboClaimEntryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboClaimEntryID.Location = New System.Drawing.Point(142, 178)
        Me.cboClaimEntryID.Name = "cboClaimEntryID"
        Me.cboClaimEntryID.Size = New System.Drawing.Size(170, 21)
        Me.cboClaimEntryID.TabIndex = 18
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(462, 253)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(172, 20)
        Me.stbVisitNo.TabIndex = 46
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberName, "MainMemberName")
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(462, 109)
        Me.stbMainMemberName.MaxLength = 60
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMainMemberName.Size = New System.Drawing.Size(172, 20)
        Me.stbMainMemberName.TabIndex = 34
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = True
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(142, 222)
        Me.stbAmountWords.MaxLength = 200
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(170, 30)
        Me.stbAmountWords.TabIndex = 22
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Location = New System.Drawing.Point(12, 202)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(124, 20)
        Me.lblTotalAmount.TabIndex = 19
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(656, 503)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 51
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbClaimNo
        '
        Me.stbClaimNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimNo.CapitalizeFirstLetter = False
        Me.stbClaimNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbClaimNo.EntryErrorMSG = ""
        Me.stbClaimNo.Location = New System.Drawing.Point(142, 27)
        Me.stbClaimNo.MaxLength = 20
        Me.stbClaimNo.Name = "stbClaimNo"
        Me.stbClaimNo.RegularExpression = ""
        Me.stbClaimNo.Size = New System.Drawing.Size(170, 20)
        Me.stbClaimNo.TabIndex = 4
        '
        'lblClaimNo
        '
        Me.lblClaimNo.Location = New System.Drawing.Point(12, 27)
        Me.lblClaimNo.Name = "lblClaimNo"
        Me.lblClaimNo.Size = New System.Drawing.Size(91, 20)
        Me.lblClaimNo.TabIndex = 2
        Me.lblClaimNo.Text = "Claim No"
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(12, 6)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(124, 20)
        Me.lblMedicalCardNo.TabIndex = 0
        Me.lblMedicalCardNo.Text = "Medical Card No"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(12, 48)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientNo.TabIndex = 5
        Me.lblPatientNo.Text = "Patient No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 69)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblVisitTime
        '
        Me.lblVisitTime.Location = New System.Drawing.Point(12, 90)
        Me.lblVisitTime.Name = "lblVisitTime"
        Me.lblVisitTime.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitTime.TabIndex = 9
        Me.lblVisitTime.Text = "Visit Time"
        '
        'lblHealthUnitCode
        '
        Me.lblHealthUnitCode.Location = New System.Drawing.Point(12, 111)
        Me.lblHealthUnitCode.Name = "lblHealthUnitCode"
        Me.lblHealthUnitCode.Size = New System.Drawing.Size(124, 20)
        Me.lblHealthUnitCode.TabIndex = 11
        Me.lblHealthUnitCode.Text = "Health Unit"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(12, 226)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(124, 20)
        Me.lblAmountWords.TabIndex = 21
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'lblClaimStatusID
        '
        Me.lblClaimStatusID.Location = New System.Drawing.Point(12, 156)
        Me.lblClaimStatusID.Name = "lblClaimStatusID"
        Me.lblClaimStatusID.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimStatusID.TabIndex = 15
        Me.lblClaimStatusID.Text = "Claim Status"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'tbcClaims
        '
        Me.tbcClaims.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDiagnosis)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDetails)
        Me.tbcClaims.HotTrack = True
        Me.tbcClaims.Location = New System.Drawing.Point(15, 279)
        Me.tbcClaims.Name = "tbcClaims"
        Me.tbcClaims.SelectedIndex = 0
        Me.tbcClaims.Size = New System.Drawing.Size(713, 185)
        Me.tbcClaims.TabIndex = 47
        '
        'tpgClaimDiagnosis
        '
        Me.tpgClaimDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgClaimDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDiagnosis.Name = "tpgClaimDiagnosis"
        Me.tpgClaimDiagnosis.Size = New System.Drawing.Size(697, 159)
        Me.tpgClaimDiagnosis.TabIndex = 2
        Me.tpgClaimDiagnosis.Tag = "ClaimDiagnosis"
        Me.tpgClaimDiagnosis.Text = "Diagnosis"
        Me.tpgClaimDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToOrderColumns = True
        Me.dgvDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseCode, Me.colDiseaseCategory, Me.colDiagnosisSaved})
        Me.dgvDiagnosis.ContextMenuStrip = Me.cmsClaims
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDiagnosis.Size = New System.Drawing.Size(697, 159)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseCode
        '
        Me.colDiseaseCode.DisplayStyleForCurrentCellOnly = True
        Me.colDiseaseCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiseaseCode.HeaderText = "Diagnosis"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDiseaseCode.Width = 350
        '
        'colDiseaseCategory
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'colDiagnosisSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.NullValue = False
        Me.colDiagnosisSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiagnosisSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiagnosisSaved.HeaderText = "Saved"
        Me.colDiagnosisSaved.Name = "colDiagnosisSaved"
        Me.colDiagnosisSaved.ReadOnly = True
        Me.colDiagnosisSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDiagnosisSaved.Width = 50
        '
        'cmsClaims
        '
        Me.cmsClaims.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsClaims.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsClaimsQuickSearch})
        Me.cmsClaims.Name = "cmsSearch"
        Me.cmsClaims.Size = New System.Drawing.Size(144, 26)
        '
        'cmsClaimsQuickSearch
        '
        Me.cmsClaimsQuickSearch.Image = CType(resources.GetObject("cmsClaimsQuickSearch.Image"), System.Drawing.Image)
        Me.cmsClaimsQuickSearch.Name = "cmsClaimsQuickSearch"
        Me.cmsClaimsQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsClaimsQuickSearch.Text = "Quick Search"
        '
        'tpgClaimDetails
        '
        Me.tpgClaimDetails.Controls.Add(Me.dgvClaimDetails)
        Me.tpgClaimDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDetails.Name = "tpgClaimDetails"
        Me.tpgClaimDetails.Size = New System.Drawing.Size(705, 159)
        Me.tpgClaimDetails.TabIndex = 1
        Me.tpgClaimDetails.Tag = "ClaimDetails"
        Me.tpgClaimDetails.Text = "Services"
        Me.tpgClaimDetails.UseVisualStyleBackColor = True
        '
        'dgvClaimDetails
        '
        Me.dgvClaimDetails.AllowUserToOrderColumns = True
        Me.dgvClaimDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvClaimDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colBenefitCode, Me.colQuantity, Me.colUnitPrice, Me.colAdjustment, Me.colAmount, Me.colNotes, Me.colClaimDetailsSaved, Me.colLimitAmount, Me.colConsumedAmount, Me.colLimitBalance})
        Me.dgvClaimDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClaimDetails.EnableHeadersVisualStyles = False
        Me.dgvClaimDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvClaimDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvClaimDetails.Name = "dgvClaimDetails"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvClaimDetails.Size = New System.Drawing.Size(705, 159)
        Me.dgvClaimDetails.TabIndex = 1
        Me.dgvClaimDetails.Text = "DataGridView1"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(326, 69)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(130, 20)
        Me.lblJoinDate.TabIndex = 29
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(326, 27)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(130, 20)
        Me.lblAge.TabIndex = 25
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(326, 48)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(130, 20)
        Me.lblGenderID.TabIndex = 27
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(326, 6)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(130, 20)
        Me.lblName.TabIndex = 23
        Me.lblName.Text = "Member's Name"
        '
        'lblInsuranceName
        '
        Me.lblInsuranceName.Location = New System.Drawing.Point(326, 166)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(130, 20)
        Me.lblInsuranceName.TabIndex = 37
        Me.lblInsuranceName.Text = "Insurance Name"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(326, 135)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(130, 20)
        Me.lblBillCustomerName.TabIndex = 35
        Me.lblBillCustomerName.Text = "Company Name"
        '
        'lblPolicyName
        '
        Me.lblPolicyName.Location = New System.Drawing.Point(326, 190)
        Me.lblPolicyName.Name = "lblPolicyName"
        Me.lblPolicyName.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyName.TabIndex = 39
        Me.lblPolicyName.Text = "Policy Name"
        '
        'lblPolicyStartDate
        '
        Me.lblPolicyStartDate.Location = New System.Drawing.Point(326, 212)
        Me.lblPolicyStartDate.Name = "lblPolicyStartDate"
        Me.lblPolicyStartDate.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyStartDate.TabIndex = 41
        Me.lblPolicyStartDate.Text = "Policy Start Date"
        '
        'lblPolicyEndDate
        '
        Me.lblPolicyEndDate.Location = New System.Drawing.Point(326, 234)
        Me.lblPolicyEndDate.Name = "lblPolicyEndDate"
        Me.lblPolicyEndDate.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyEndDate.TabIndex = 43
        Me.lblPolicyEndDate.Text = "Policy End Date"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(142, 201)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(170, 20)
        Me.stbTotalAmount.TabIndex = 20
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMemberType
        '
        Me.lblMemberType.Location = New System.Drawing.Point(326, 90)
        Me.lblMemberType.Name = "lblMemberType"
        Me.lblMemberType.Size = New System.Drawing.Size(130, 20)
        Me.lblMemberType.TabIndex = 31
        Me.lblMemberType.Text = "Member Type"
        '
        'btnFindClaimNo
        '
        Me.btnFindClaimNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindClaimNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindClaimNo.Image = CType(resources.GetObject("btnFindClaimNo.Image"), System.Drawing.Image)
        Me.btnFindClaimNo.Location = New System.Drawing.Point(114, 26)
        Me.btnFindClaimNo.Name = "btnFindClaimNo"
        Me.btnFindClaimNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindClaimNo.TabIndex = 3
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 134)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblPrimaryDoctor.TabIndex = 13
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'lblClaimEntry
        '
        Me.lblClaimEntry.Location = New System.Drawing.Point(12, 179)
        Me.lblClaimEntry.Name = "lblClaimEntry"
        Me.lblClaimEntry.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimEntry.TabIndex = 17
        Me.lblClaimEntry.Text = "Claim Entry"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(326, 253)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(130, 20)
        Me.lblVisitNo.TabIndex = 45
        Me.lblVisitNo.Text = "Visit No"
        '
        'navClaims
        '
        Me.navClaims.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navClaims.ColumnName = "ClaimNo"
        Me.navClaims.DataSource = Nothing
        Me.navClaims.Location = New System.Drawing.Point(24, 28)
        Me.navClaims.Name = "navClaims"
        Me.navClaims.NavAllEnabled = False
        Me.navClaims.NavLeftEnabled = False
        Me.navClaims.NavRightEnabled = False
        Me.navClaims.Size = New System.Drawing.Size(413, 32)
        Me.navClaims.TabIndex = 1
        '
        'chkNavigateClaims
        '
        Me.chkNavigateClaims.AccessibleDescription = ""
        Me.chkNavigateClaims.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateClaims.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateClaims.Location = New System.Drawing.Point(154, 3)
        Me.chkNavigateClaims.Name = "chkNavigateClaims"
        Me.chkNavigateClaims.Size = New System.Drawing.Size(161, 20)
        Me.chkNavigateClaims.TabIndex = 0
        Me.chkNavigateClaims.Text = "Navigate Member Claims"
        '
        'pnlNavigateClaims
        '
        Me.pnlNavigateClaims.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateClaims.Controls.Add(Me.navClaims)
        Me.pnlNavigateClaims.Controls.Add(Me.chkNavigateClaims)
        Me.pnlNavigateClaims.Location = New System.Drawing.Point(143, 470)
        Me.pnlNavigateClaims.Name = "pnlNavigateClaims"
        Me.pnlNavigateClaims.Size = New System.Drawing.Size(460, 64)
        Me.pnlNavigateClaims.TabIndex = 52
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(326, 111)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(130, 20)
        Me.lblMainMemberName.TabIndex = 33
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MaxInputLength = 100
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Width = 150
        '
        'colBenefitCode
        '
        Me.colBenefitCode.DataPropertyName = "BenefitCode"
        Me.colBenefitCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colBenefitCode.DisplayStyleForCurrentCellOnly = True
        Me.colBenefitCode.DropDownWidth = 10
        Me.colBenefitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBenefitCode.HeaderText = "Benefit Name"
        Me.colBenefitCode.Name = "colBenefitCode"
        Me.colBenefitCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBenefitCode.Width = 80
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.Width = 65
        '
        'colAdjustment
        '
        Me.colAdjustment.DataPropertyName = "Adjustment"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colAdjustment.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAdjustment.HeaderText = "Adjustment"
        Me.colAdjustment.Name = "colAdjustment"
        Me.colAdjustment.Width = 65
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 400
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 120
        '
        'colClaimDetailsSaved
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = False
        Me.colClaimDetailsSaved.DefaultCellStyle = DataGridViewCellStyle10
        Me.colClaimDetailsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colClaimDetailsSaved.HeaderText = "Saved"
        Me.colClaimDetailsSaved.Name = "colClaimDetailsSaved"
        Me.colClaimDetailsSaved.ReadOnly = True
        Me.colClaimDetailsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colClaimDetailsSaved.Width = 50
        '
        'colLimitAmount
        '
        Me.colLimitAmount.DataPropertyName = "LimitAmount"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colLimitAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colLimitAmount.HeaderText = "Limit Amount"
        Me.colLimitAmount.Name = "colLimitAmount"
        Me.colLimitAmount.ReadOnly = True
        Me.colLimitAmount.Width = 85
        '
        'colConsumedAmount
        '
        Me.colConsumedAmount.DataPropertyName = "ConsumedAmount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colConsumedAmount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colConsumedAmount.HeaderText = "Consumed Amount"
        Me.colConsumedAmount.Name = "colConsumedAmount"
        Me.colConsumedAmount.ReadOnly = True
        Me.colConsumedAmount.Width = 110
        '
        'colLimitBalance
        '
        Me.colLimitBalance.DataPropertyName = "LimitBalance"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colLimitBalance.DefaultCellStyle = DataGridViewCellStyle13
        Me.colLimitBalance.HeaderText = "Limit Balance"
        Me.colLimitBalance.Name = "colLimitBalance"
        Me.colLimitBalance.ReadOnly = True
        Me.colLimitBalance.Width = 85
        '
        'frmClaims
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(745, 542)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.pnlNavigateClaims)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboClaimEntryID)
        Me.Controls.Add(Me.lblClaimEntry)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.btnFindClaimNo)
        Me.Controls.Add(Me.stbMemberType)
        Me.Controls.Add(Me.lblMemberType)
        Me.Controls.Add(Me.stbTotalAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.stbPolicyEndDate)
        Me.Controls.Add(Me.lblPolicyEndDate)
        Me.Controls.Add(Me.stbPolicyStartDate)
        Me.Controls.Add(Me.lblPolicyStartDate)
        Me.Controls.Add(Me.stbPolicyName)
        Me.Controls.Add(Me.lblPolicyName)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblInsuranceName)
        Me.Controls.Add(Me.stbCompanyName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbMedicalCardNo)
        Me.Controls.Add(Me.stpVisitTime)
        Me.Controls.Add(Me.tbcClaims)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbClaimNo)
        Me.Controls.Add(Me.lblClaimNo)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.dtpVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.lblVisitTime)
        Me.Controls.Add(Me.cboHealthUnitCode)
        Me.Controls.Add(Me.lblHealthUnitCode)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.cboClaimStatusID)
        Me.Controls.Add(Me.lblClaimStatusID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmClaims"
        Me.Text = "Claims"
        Me.tbcClaims.ResumeLayout(False)
        Me.tpgClaimDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsClaims.ResumeLayout(False)
        Me.tpgClaimDetails.ResumeLayout(False)
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateClaims.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbClaimNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimNo As System.Windows.Forms.Label
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents dtpVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitTime As System.Windows.Forms.Label
    Friend WithEvents cboHealthUnitCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblHealthUnitCode As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents cboClaimStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblClaimStatusID As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents tbcClaims As System.Windows.Forms.TabControl
    Friend WithEvents tpgClaimDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents tpgClaimDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colDiseaseCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stpVisitTime As SyncSoft.Common.Win.Controls.SmartTimePicker
    Friend WithEvents stbMedicalCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbPolicyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyName As System.Windows.Forms.Label
    Friend WithEvents stbPolicyStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyStartDate As System.Windows.Forms.Label
    Friend WithEvents stbPolicyEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyEndDate As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents stbMemberType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberType As System.Windows.Forms.Label
    Friend WithEvents dgvClaimDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnFindClaimNo As System.Windows.Forms.Button
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents lblClaimEntry As System.Windows.Forms.Label
    Friend WithEvents cboClaimEntryID As System.Windows.Forms.ComboBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents navClaims As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateClaims As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNavigateClaims As System.Windows.Forms.Panel
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents cmsClaims As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsClaimsQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBenefitCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjustment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimDetailsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colLimitAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLimitBalance As System.Windows.Forms.DataGridViewTextBoxColumn

End Class