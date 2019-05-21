
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaternalEnrollment : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaternalEnrollment))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnSave = New SyncSoft.Common.Win.Controls.EditButton()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.txtVisitDate = New System.Windows.Forms.TextBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.clbSocialHistory = New System.Windows.Forms.CheckedListBox()
        Me.stbSocialHistoryNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbSurgicalHistory = New System.Windows.Forms.CheckedListBox()
        Me.stbSurgicalHistoryNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbFamilyHistory = New System.Windows.Forms.CheckedListBox()
        Me.stbFamilyHistoryNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbGynaecologicalHistory = New System.Windows.Forms.CheckedListBox()
        Me.stbGynHistoryNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbMedicalHistory = New System.Windows.Forms.CheckedListBox()
        Me.dtpBloodTransfusionDate = New System.Windows.Forms.DateTimePicker()
        Me.stbMedicalHistoryNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkLNMPDateReliable = New System.Windows.Forms.CheckBox()
        Me.cboCycleRegularID = New System.Windows.Forms.ComboBox()
        Me.stbJoinDate = New System.Windows.Forms.TextBox()
        Me.stbTotalVisits = New System.Windows.Forms.TextBox()
        Me.stbBloodGroup = New System.Windows.Forms.TextBox()
        Me.cboHIVStatusID = New System.Windows.Forms.ComboBox()
        Me.cboBloodTransfusion = New System.Windows.Forms.ComboBox()
        Me.tbcMaternalEnrollment = New System.Windows.Forms.TabControl()
        Me.tpgCurrentPregnancy = New System.Windows.Forms.TabPage()
        Me.tbcCurrentPregnancy = New System.Windows.Forms.TabControl()
        Me.tpgMenstruationHistory = New System.Windows.Forms.TabPage()
        Me.dtpLNMP = New System.Windows.Forms.DateTimePicker()
        Me.dtpEDD = New System.Windows.Forms.DateTimePicker()
        Me.dtpScanDate = New System.Windows.Forms.DateTimePicker()
        Me.lblScanDate = New System.Windows.Forms.Label()
        Me.lblCycleRegularID = New System.Windows.Forms.Label()
        Me.lblEDD = New System.Windows.Forms.Label()
        Me.lblLNMP = New System.Windows.Forms.Label()
        Me.tpgContraceptivesHistory = New System.Windows.Forms.TabPage()
        Me.dgvContraceptives = New System.Windows.Forms.DataGridView()
        Me.colContraceptiveID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colComplications = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colComplicationDetails = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colContraceptiveDateStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContraceptiveDiscontinued = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colContraceptiveRemovalReasons = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colContraceptiveNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContraceptiveSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPreviousIllnesses = New System.Windows.Forms.TabPage()
        Me.grpMedicalHistory = New System.Windows.Forms.GroupBox()
        Me.lblBloodTransfusion = New System.Windows.Forms.Label()
        Me.lblMedicalHistory = New System.Windows.Forms.Label()
        Me.lblBloodTransfusionDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpOBSGyn = New System.Windows.Forms.GroupBox()
        Me.lblGynHistoryNotes = New System.Windows.Forms.Label()
        Me.lblGynaecologicalHistory = New System.Windows.Forms.Label()
        Me.grpSurgicalHistory = New System.Windows.Forms.GroupBox()
        Me.lblSurgicalHistoryNotes = New System.Windows.Forms.Label()
        Me.lblSurgicalHistory = New System.Windows.Forms.Label()
        Me.tpgFamilySocialHistory = New System.Windows.Forms.TabPage()
        Me.grpFamilyHistory = New System.Windows.Forms.GroupBox()
        Me.lblFamilyHistory = New System.Windows.Forms.Label()
        Me.lblFamilyHistoryNotes = New System.Windows.Forms.Label()
        Me.grpSocialHistory = New System.Windows.Forms.GroupBox()
        Me.lblSocialHistoryNotes = New System.Windows.Forms.Label()
        Me.lblSocialHistory = New System.Windows.Forms.Label()
        Me.tpgObstetricHistory = New System.Windows.Forms.TabPage()
        Me.dgvOBHistory = New System.Windows.Forms.DataGridView()
        Me.colObstetricPregnancy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObstetricYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObstetricAbortionID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricAbortionPeriodID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colTypeOfDelivery = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricThirdStageID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricPeurPerinumID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricChildStatusID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricGenderID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colObstetricBirthWeight = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObstetricImmunised = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colObstetricHealthCondition = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObstetricSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPatientAllergies = New System.Windows.Forms.TabPage()
        Me.dgvPatientAllergies = New System.Windows.Forms.DataGridView()
        Me.colAllergyNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAllergyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReaction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientAllergiesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.stbANCNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboPartnersHIVStatusID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHIVStatus = New System.Windows.Forms.Label()
        Me.stbAdress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stbOccupation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOccupation = New System.Windows.Forms.Label()
        Me.stbMaritalStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMaritalStatus = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblNoOfVisits = New System.Windows.Forms.Label()
        Me.lblBloodGroup = New System.Windows.Forms.Label()
        Me.lblGravida = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nbxPara = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxGravida = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblANCNo = New System.Windows.Forms.Label()
        Me.btnFindANCNo = New System.Windows.Forms.Button()
        Me.lblPartnerHIVStatus = New System.Windows.Forms.Label()
        Me.pnlStatusID = New System.Windows.Forms.Panel()
        Me.fcbStatusID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.lblStatusID = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcMaternalEnrollment.SuspendLayout()
        Me.tpgCurrentPregnancy.SuspendLayout()
        Me.tbcCurrentPregnancy.SuspendLayout()
        Me.tpgMenstruationHistory.SuspendLayout()
        Me.tpgContraceptivesHistory.SuspendLayout()
        CType(Me.dgvContraceptives, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPreviousIllnesses.SuspendLayout()
        Me.grpMedicalHistory.SuspendLayout()
        Me.grpOBSGyn.SuspendLayout()
        Me.grpSurgicalHistory.SuspendLayout()
        Me.tpgFamilySocialHistory.SuspendLayout()
        Me.grpFamilyHistory.SuspendLayout()
        Me.grpSocialHistory.SuspendLayout()
        Me.tpgObstetricHistory.SuspendLayout()
        CType(Me.dgvOBHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPatientAllergies.SuspendLayout()
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusID.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(21, 416)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(958, 416)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "MaternalEnrollment"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.btnSave.DataSource = Nothing
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(21, 389)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Tag = "MaternalEnrollment"
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(929, 5)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(108, 111)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 60
        Me.spbPhoto.TabStop = False
        '
        'txtVisitDate
        '
        Me.txtVisitDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.txtVisitDate, "VisitDate")
        Me.txtVisitDate.Enabled = False
        Me.txtVisitDate.Location = New System.Drawing.Point(782, 69)
        Me.txtVisitDate.MaxLength = 60
        Me.txtVisitDate.Name = "txtVisitDate"
        Me.txtVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVisitDate.Size = New System.Drawing.Size(130, 20)
        Me.txtVisitDate.TabIndex = 32
        '
        'txtAge
        '
        Me.txtAge.BackColor = System.Drawing.SystemColors.Control
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.txtAge, "Age")
        Me.txtAge.Enabled = False
        Me.txtAge.Location = New System.Drawing.Point(782, 4)
        Me.txtAge.MaxLength = 60
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAge.Size = New System.Drawing.Size(130, 20)
        Me.txtAge.TabIndex = 26
        '
        'txtFullName
        '
        Me.txtFullName.BackColor = System.Drawing.SystemColors.Control
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.txtFullName, "FullName")
        Me.txtFullName.Enabled = False
        Me.txtFullName.Location = New System.Drawing.Point(168, 49)
        Me.txtFullName.MaxLength = 41
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(170, 20)
        Me.txtFullName.TabIndex = 8
        '
        'clbSocialHistory
        '
        Me.clbSocialHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.btnSave.SetDataMember(Me.clbSocialHistory, "SocialHistory")
        Me.clbSocialHistory.FormattingEnabled = True
        Me.clbSocialHistory.Location = New System.Drawing.Point(120, 25)
        Me.clbSocialHistory.Name = "clbSocialHistory"
        Me.clbSocialHistory.Size = New System.Drawing.Size(170, 45)
        Me.clbSocialHistory.TabIndex = 1
        '
        'stbSocialHistoryNotes
        '
        Me.stbSocialHistoryNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSocialHistoryNotes.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbSocialHistoryNotes, "SocialHistory")
        Me.stbSocialHistoryNotes.EntryErrorMSG = ""
        Me.stbSocialHistoryNotes.Location = New System.Drawing.Point(120, 101)
        Me.stbSocialHistoryNotes.Multiline = True
        Me.stbSocialHistoryNotes.Name = "stbSocialHistoryNotes"
        Me.stbSocialHistoryNotes.RegularExpression = ""
        Me.stbSocialHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbSocialHistoryNotes.Size = New System.Drawing.Size(170, 44)
        Me.stbSocialHistoryNotes.TabIndex = 2
        '
        'clbSurgicalHistory
        '
        Me.clbSurgicalHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.btnSave.SetDataMember(Me.clbSurgicalHistory, "SurgicalHistory")
        Me.clbSurgicalHistory.FormattingEnabled = True
        Me.clbSurgicalHistory.Location = New System.Drawing.Point(142, 23)
        Me.clbSurgicalHistory.Name = "clbSurgicalHistory"
        Me.clbSurgicalHistory.Size = New System.Drawing.Size(170, 60)
        Me.clbSurgicalHistory.TabIndex = 1
        '
        'stbSurgicalHistoryNotes
        '
        Me.stbSurgicalHistoryNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSurgicalHistoryNotes.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbSurgicalHistoryNotes, "SurgicalHistory")
        Me.stbSurgicalHistoryNotes.EntryErrorMSG = ""
        Me.stbSurgicalHistoryNotes.Location = New System.Drawing.Point(142, 101)
        Me.stbSurgicalHistoryNotes.Multiline = True
        Me.stbSurgicalHistoryNotes.Name = "stbSurgicalHistoryNotes"
        Me.stbSurgicalHistoryNotes.RegularExpression = ""
        Me.stbSurgicalHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbSurgicalHistoryNotes.Size = New System.Drawing.Size(170, 55)
        Me.stbSurgicalHistoryNotes.TabIndex = 3
        '
        'clbFamilyHistory
        '
        Me.clbFamilyHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.btnSave.SetDataMember(Me.clbFamilyHistory, "FamilyHistory")
        Me.clbFamilyHistory.FormattingEnabled = True
        Me.clbFamilyHistory.Location = New System.Drawing.Point(113, 26)
        Me.clbFamilyHistory.Name = "clbFamilyHistory"
        Me.clbFamilyHistory.Size = New System.Drawing.Size(170, 75)
        Me.clbFamilyHistory.TabIndex = 1
        '
        'stbFamilyHistoryNotes
        '
        Me.stbFamilyHistoryNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFamilyHistoryNotes.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbFamilyHistoryNotes, "FamilyHistory")
        Me.stbFamilyHistoryNotes.EntryErrorMSG = ""
        Me.stbFamilyHistoryNotes.Location = New System.Drawing.Point(113, 108)
        Me.stbFamilyHistoryNotes.Multiline = True
        Me.stbFamilyHistoryNotes.Name = "stbFamilyHistoryNotes"
        Me.stbFamilyHistoryNotes.RegularExpression = ""
        Me.stbFamilyHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbFamilyHistoryNotes.Size = New System.Drawing.Size(170, 41)
        Me.stbFamilyHistoryNotes.TabIndex = 3
        '
        'clbGynaecologicalHistory
        '
        Me.clbGynaecologicalHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.btnSave.SetDataMember(Me.clbGynaecologicalHistory, "GynaecologicalHistory")
        Me.clbGynaecologicalHistory.FormattingEnabled = True
        Me.clbGynaecologicalHistory.Location = New System.Drawing.Point(142, 26)
        Me.clbGynaecologicalHistory.Name = "clbGynaecologicalHistory"
        Me.clbGynaecologicalHistory.Size = New System.Drawing.Size(170, 60)
        Me.clbGynaecologicalHistory.TabIndex = 1
        '
        'stbGynHistoryNotes
        '
        Me.stbGynHistoryNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGynHistoryNotes.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbGynHistoryNotes, "GynaecologicalHistory")
        Me.stbGynHistoryNotes.EntryErrorMSG = ""
        Me.stbGynHistoryNotes.Location = New System.Drawing.Point(142, 106)
        Me.stbGynHistoryNotes.Multiline = True
        Me.stbGynHistoryNotes.Name = "stbGynHistoryNotes"
        Me.stbGynHistoryNotes.RegularExpression = ""
        Me.stbGynHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbGynHistoryNotes.Size = New System.Drawing.Size(170, 50)
        Me.stbGynHistoryNotes.TabIndex = 3
        '
        'clbMedicalHistory
        '
        Me.clbMedicalHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.btnSave.SetDataMember(Me.clbMedicalHistory, "MedicalHistory")
        Me.clbMedicalHistory.FormattingEnabled = True
        Me.clbMedicalHistory.Location = New System.Drawing.Point(142, 17)
        Me.clbMedicalHistory.Name = "clbMedicalHistory"
        Me.clbMedicalHistory.Size = New System.Drawing.Size(170, 75)
        Me.clbMedicalHistory.TabIndex = 1
        '
        'dtpBloodTransfusionDate
        '
        Me.btnSave.SetDataMember(Me.dtpBloodTransfusionDate, "LNMP")
        Me.dtpBloodTransfusionDate.Location = New System.Drawing.Point(142, 122)
        Me.dtpBloodTransfusionDate.MaxDate = New Date(2018, 5, 4, 0, 0, 0, 0)
        Me.dtpBloodTransfusionDate.Name = "dtpBloodTransfusionDate"
        Me.dtpBloodTransfusionDate.ShowCheckBox = True
        Me.dtpBloodTransfusionDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpBloodTransfusionDate.TabIndex = 5
        Me.dtpBloodTransfusionDate.Value = New Date(2018, 5, 4, 0, 0, 0, 0)
        '
        'stbMedicalHistoryNotes
        '
        Me.stbMedicalHistoryNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalHistoryNotes.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbMedicalHistoryNotes, "MedicalHistory")
        Me.stbMedicalHistoryNotes.EntryErrorMSG = ""
        Me.stbMedicalHistoryNotes.Location = New System.Drawing.Point(142, 145)
        Me.stbMedicalHistoryNotes.Multiline = True
        Me.stbMedicalHistoryNotes.Name = "stbMedicalHistoryNotes"
        Me.stbMedicalHistoryNotes.RegularExpression = ""
        Me.stbMedicalHistoryNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbMedicalHistoryNotes.Size = New System.Drawing.Size(170, 35)
        Me.stbMedicalHistoryNotes.TabIndex = 7
        '
        'chkLNMPDateReliable
        '
        Me.chkLNMPDateReliable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.SetDataMember(Me.chkLNMPDateReliable, "LNMPDateReliable")
        Me.chkLNMPDateReliable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLNMPDateReliable.Location = New System.Drawing.Point(6, 35)
        Me.chkLNMPDateReliable.Name = "chkLNMPDateReliable"
        Me.chkLNMPDateReliable.Size = New System.Drawing.Size(322, 20)
        Me.chkLNMPDateReliable.TabIndex = 2
        Me.chkLNMPDateReliable.Text = "LNMP Date Reliable"
        '
        'cboCycleRegularID
        '
        Me.btnSave.SetDataMember(Me.cboCycleRegularID, "CycleRegular,CycleRegularID")
        Me.cboCycleRegularID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCycleRegularID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCycleRegularID.Location = New System.Drawing.Point(139, 87)
        Me.cboCycleRegularID.Name = "cboCycleRegularID"
        Me.cboCycleRegularID.Size = New System.Drawing.Size(189, 21)
        Me.cboCycleRegularID.TabIndex = 6
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BackColor = System.Drawing.SystemColors.Control
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.stbJoinDate, "VisitDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.Location = New System.Drawing.Point(782, 48)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(130, 20)
        Me.stbJoinDate.TabIndex = 30
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BackColor = System.Drawing.SystemColors.Control
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.stbTotalVisits, "VisitDate")
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.Location = New System.Drawing.Point(782, 90)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(130, 20)
        Me.stbTotalVisits.TabIndex = 34
        '
        'stbBloodGroup
        '
        Me.stbBloodGroup.BackColor = System.Drawing.SystemColors.Control
        Me.stbBloodGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.btnSave.SetDataMember(Me.stbBloodGroup, "VisitDate")
        Me.stbBloodGroup.Enabled = False
        Me.stbBloodGroup.Location = New System.Drawing.Point(499, 4)
        Me.stbBloodGroup.MaxLength = 60
        Me.stbBloodGroup.Name = "stbBloodGroup"
        Me.stbBloodGroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBloodGroup.Size = New System.Drawing.Size(151, 20)
        Me.stbBloodGroup.TabIndex = 16
        '
        'cboHIVStatusID
        '
        Me.btnSave.SetDataMember(Me.cboHIVStatusID, "CycleRegular,CycleRegularID")
        Me.cboHIVStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVStatusID.Location = New System.Drawing.Point(168, 116)
        Me.cboHIVStatusID.Name = "cboHIVStatusID"
        Me.cboHIVStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboHIVStatusID.TabIndex = 14
        '
        'cboBloodTransfusion
        '
        Me.btnSave.SetDataMember(Me.cboBloodTransfusion, "CycleRegular,CycleRegularID")
        Me.cboBloodTransfusion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBloodTransfusion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBloodTransfusion.Location = New System.Drawing.Point(142, 98)
        Me.cboBloodTransfusion.Name = "cboBloodTransfusion"
        Me.cboBloodTransfusion.Size = New System.Drawing.Size(170, 21)
        Me.cboBloodTransfusion.TabIndex = 3
        '
        'tbcMaternalEnrollment
        '
        Me.tbcMaternalEnrollment.Controls.Add(Me.tpgCurrentPregnancy)
        Me.tbcMaternalEnrollment.Controls.Add(Me.tpgPreviousIllnesses)
        Me.tbcMaternalEnrollment.Controls.Add(Me.tpgFamilySocialHistory)
        Me.tbcMaternalEnrollment.Controls.Add(Me.tpgObstetricHistory)
        Me.tbcMaternalEnrollment.Controls.Add(Me.tpgPatientAllergies)
        Me.btnSave.SetDataMember(Me.tbcMaternalEnrollment, "PatientStatus,PatientStatusID")
        Me.tbcMaternalEnrollment.Location = New System.Drawing.Point(21, 144)
        Me.tbcMaternalEnrollment.Name = "tbcMaternalEnrollment"
        Me.tbcMaternalEnrollment.SelectedIndex = 0
        Me.tbcMaternalEnrollment.Size = New System.Drawing.Size(1013, 239)
        Me.tbcMaternalEnrollment.TabIndex = 38
        '
        'tpgCurrentPregnancy
        '
        Me.tpgCurrentPregnancy.Controls.Add(Me.tbcCurrentPregnancy)
        Me.tpgCurrentPregnancy.Location = New System.Drawing.Point(4, 22)
        Me.tpgCurrentPregnancy.Name = "tpgCurrentPregnancy"
        Me.tpgCurrentPregnancy.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgCurrentPregnancy.Size = New System.Drawing.Size(1005, 213)
        Me.tpgCurrentPregnancy.TabIndex = 0
        Me.tpgCurrentPregnancy.Text = "Current pregnancy "
        Me.tpgCurrentPregnancy.UseVisualStyleBackColor = True
        '
        'tbcCurrentPregnancy
        '
        Me.tbcCurrentPregnancy.Controls.Add(Me.tpgMenstruationHistory)
        Me.tbcCurrentPregnancy.Controls.Add(Me.tpgContraceptivesHistory)
        Me.tbcCurrentPregnancy.Location = New System.Drawing.Point(0, 0)
        Me.tbcCurrentPregnancy.Name = "tbcCurrentPregnancy"
        Me.tbcCurrentPregnancy.SelectedIndex = 0
        Me.tbcCurrentPregnancy.Size = New System.Drawing.Size(1003, 217)
        Me.tbcCurrentPregnancy.TabIndex = 0
        '
        'tpgMenstruationHistory
        '
        Me.tpgMenstruationHistory.Controls.Add(Me.dtpLNMP)
        Me.tpgMenstruationHistory.Controls.Add(Me.dtpEDD)
        Me.tpgMenstruationHistory.Controls.Add(Me.dtpScanDate)
        Me.tpgMenstruationHistory.Controls.Add(Me.lblScanDate)
        Me.tpgMenstruationHistory.Controls.Add(Me.cboCycleRegularID)
        Me.tpgMenstruationHistory.Controls.Add(Me.lblCycleRegularID)
        Me.tpgMenstruationHistory.Controls.Add(Me.chkLNMPDateReliable)
        Me.tpgMenstruationHistory.Controls.Add(Me.lblEDD)
        Me.tpgMenstruationHistory.Controls.Add(Me.lblLNMP)
        Me.tpgMenstruationHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgMenstruationHistory.Name = "tpgMenstruationHistory"
        Me.tpgMenstruationHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgMenstruationHistory.Size = New System.Drawing.Size(995, 191)
        Me.tpgMenstruationHistory.TabIndex = 0
        Me.tpgMenstruationHistory.Text = "Menstruation History"
        Me.tpgMenstruationHistory.UseVisualStyleBackColor = True
        '
        'dtpLNMP
        '
        Me.dtpLNMP.CustomFormat = "dd MMM yyyy"
        Me.dtpLNMP.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLNMP.Location = New System.Drawing.Point(139, 9)
        Me.dtpLNMP.Name = "dtpLNMP"
        Me.dtpLNMP.ShowCheckBox = True
        Me.dtpLNMP.Size = New System.Drawing.Size(189, 20)
        Me.dtpLNMP.TabIndex = 1
        '
        'dtpEDD
        '
        Me.dtpEDD.CustomFormat = "dd MMM yyyy"
        Me.dtpEDD.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEDD.Location = New System.Drawing.Point(139, 55)
        Me.dtpEDD.Name = "dtpEDD"
        Me.dtpEDD.ShowCheckBox = True
        Me.dtpEDD.Size = New System.Drawing.Size(189, 20)
        Me.dtpEDD.TabIndex = 4
        Me.dtpEDD.Value = New Date(2019, 4, 6, 0, 0, 0, 0)
        '
        'dtpScanDate
        '
        Me.dtpScanDate.CustomFormat = "dd MMM yyyy"
        Me.dtpScanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpScanDate.Location = New System.Drawing.Point(139, 114)
        Me.dtpScanDate.Name = "dtpScanDate"
        Me.dtpScanDate.ShowCheckBox = True
        Me.dtpScanDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpScanDate.TabIndex = 8
        '
        'lblScanDate
        '
        Me.lblScanDate.Location = New System.Drawing.Point(6, 114)
        Me.lblScanDate.Name = "lblScanDate"
        Me.lblScanDate.Size = New System.Drawing.Size(96, 20)
        Me.lblScanDate.TabIndex = 7
        Me.lblScanDate.Text = "Scan Date"
        '
        'lblCycleRegularID
        '
        Me.lblCycleRegularID.Location = New System.Drawing.Point(6, 84)
        Me.lblCycleRegularID.Name = "lblCycleRegularID"
        Me.lblCycleRegularID.Size = New System.Drawing.Size(107, 20)
        Me.lblCycleRegularID.TabIndex = 5
        Me.lblCycleRegularID.Text = "Cycle Regular"
        '
        'lblEDD
        '
        Me.lblEDD.Location = New System.Drawing.Point(6, 61)
        Me.lblEDD.Name = "lblEDD"
        Me.lblEDD.Size = New System.Drawing.Size(96, 20)
        Me.lblEDD.TabIndex = 3
        Me.lblEDD.Text = "EDD"
        '
        'lblLNMP
        '
        Me.lblLNMP.Location = New System.Drawing.Point(6, 10)
        Me.lblLNMP.Name = "lblLNMP"
        Me.lblLNMP.Size = New System.Drawing.Size(96, 20)
        Me.lblLNMP.TabIndex = 0
        Me.lblLNMP.Text = "LNMP"
        '
        'tpgContraceptivesHistory
        '
        Me.tpgContraceptivesHistory.AccessibleName = ""
        Me.tpgContraceptivesHistory.Controls.Add(Me.dgvContraceptives)
        Me.tpgContraceptivesHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgContraceptivesHistory.Name = "tpgContraceptivesHistory"
        Me.tpgContraceptivesHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgContraceptivesHistory.Size = New System.Drawing.Size(995, 191)
        Me.tpgContraceptivesHistory.TabIndex = 1
        Me.tpgContraceptivesHistory.Text = "Contraceptives History"
        Me.tpgContraceptivesHistory.UseVisualStyleBackColor = True
        '
        'dgvContraceptives
        '
        Me.dgvContraceptives.AllowUserToOrderColumns = True
        Me.dgvContraceptives.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContraceptives.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvContraceptives.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colContraceptiveID, Me.colComplications, Me.colComplicationDetails, Me.colContraceptiveDateStarted, Me.colContraceptiveDiscontinued, Me.colContraceptiveRemovalReasons, Me.colContraceptiveNotes, Me.colContraceptiveSaved})
        Me.dgvContraceptives.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContraceptives.EnableHeadersVisualStyles = False
        Me.dgvContraceptives.GridColor = System.Drawing.Color.Khaki
        Me.dgvContraceptives.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvContraceptives.Location = New System.Drawing.Point(3, 3)
        Me.dgvContraceptives.Name = "dgvContraceptives"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContraceptives.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvContraceptives.Size = New System.Drawing.Size(989, 185)
        Me.dgvContraceptives.TabIndex = 24
        Me.dgvContraceptives.Text = "DataGridView1"
        '
        'colContraceptiveID
        '
        Me.colContraceptiveID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colContraceptiveID.HeaderText = "Contraceptive"
        Me.colContraceptiveID.Name = "colContraceptiveID"
        Me.colContraceptiveID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colContraceptiveID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colContraceptiveID.Width = 200
        '
        'colComplications
        '
        Me.colComplications.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colComplications.HeaderText = "Complications"
        Me.colComplications.Name = "colComplications"
        Me.colComplications.Width = 80
        '
        'colComplicationDetails
        '
        Me.colComplicationDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colComplicationDetails.HeaderText = "Details"
        Me.colComplicationDetails.Name = "colComplicationDetails"
        Me.colComplicationDetails.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colComplicationDetails.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colComplicationDetails.Width = 120
        '
        'colContraceptiveDateStarted
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colContraceptiveDateStarted.DefaultCellStyle = DataGridViewCellStyle2
        Me.colContraceptiveDateStarted.HeaderText = "Date Started"
        Me.colContraceptiveDateStarted.MaxInputLength = 12
        Me.colContraceptiveDateStarted.Name = "colContraceptiveDateStarted"
        '
        'colContraceptiveDiscontinued
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.colContraceptiveDiscontinued.DefaultCellStyle = DataGridViewCellStyle3
        Me.colContraceptiveDiscontinued.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colContraceptiveDiscontinued.HeaderText = "Discontinued"
        Me.colContraceptiveDiscontinued.Name = "colContraceptiveDiscontinued"
        Me.colContraceptiveDiscontinued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colContraceptiveDiscontinued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colContraceptiveRemovalReasons
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N2"
        Me.colContraceptiveRemovalReasons.DefaultCellStyle = DataGridViewCellStyle4
        Me.colContraceptiveRemovalReasons.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colContraceptiveRemovalReasons.HeaderText = "Reason For Removal"
        Me.colContraceptiveRemovalReasons.Name = "colContraceptiveRemovalReasons"
        Me.colContraceptiveRemovalReasons.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colContraceptiveRemovalReasons.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colContraceptiveRemovalReasons.Width = 150
        '
        'colContraceptiveNotes
        '
        Me.colContraceptiveNotes.HeaderText = "Notes"
        Me.colContraceptiveNotes.MaxInputLength = 200
        Me.colContraceptiveNotes.Name = "colContraceptiveNotes"
        Me.colContraceptiveNotes.Width = 200
        '
        'colContraceptiveSaved
        '
        Me.colContraceptiveSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = False
        Me.colContraceptiveSaved.DefaultCellStyle = DataGridViewCellStyle5
        Me.colContraceptiveSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colContraceptiveSaved.HeaderText = "Saved"
        Me.colContraceptiveSaved.Name = "colContraceptiveSaved"
        Me.colContraceptiveSaved.ReadOnly = True
        Me.colContraceptiveSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colContraceptiveSaved.Width = 50
        '
        'tpgPreviousIllnesses
        '
        Me.tpgPreviousIllnesses.Controls.Add(Me.grpMedicalHistory)
        Me.tpgPreviousIllnesses.Controls.Add(Me.grpOBSGyn)
        Me.tpgPreviousIllnesses.Controls.Add(Me.grpSurgicalHistory)
        Me.tpgPreviousIllnesses.Location = New System.Drawing.Point(4, 22)
        Me.tpgPreviousIllnesses.Name = "tpgPreviousIllnesses"
        Me.tpgPreviousIllnesses.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPreviousIllnesses.Size = New System.Drawing.Size(1005, 213)
        Me.tpgPreviousIllnesses.TabIndex = 2
        Me.tpgPreviousIllnesses.Text = "Previous Conditions"
        Me.tpgPreviousIllnesses.UseVisualStyleBackColor = True
        '
        'grpMedicalHistory
        '
        Me.grpMedicalHistory.Controls.Add(Me.cboBloodTransfusion)
        Me.grpMedicalHistory.Controls.Add(Me.lblBloodTransfusion)
        Me.grpMedicalHistory.Controls.Add(Me.clbMedicalHistory)
        Me.grpMedicalHistory.Controls.Add(Me.lblMedicalHistory)
        Me.grpMedicalHistory.Controls.Add(Me.dtpBloodTransfusionDate)
        Me.grpMedicalHistory.Controls.Add(Me.lblBloodTransfusionDate)
        Me.grpMedicalHistory.Controls.Add(Me.Label1)
        Me.grpMedicalHistory.Controls.Add(Me.stbMedicalHistoryNotes)
        Me.grpMedicalHistory.Location = New System.Drawing.Point(7, 19)
        Me.grpMedicalHistory.Name = "grpMedicalHistory"
        Me.grpMedicalHistory.Size = New System.Drawing.Size(328, 191)
        Me.grpMedicalHistory.TabIndex = 0
        Me.grpMedicalHistory.TabStop = False
        Me.grpMedicalHistory.Text = "MEDICAL HISTORY"
        '
        'lblBloodTransfusion
        '
        Me.lblBloodTransfusion.Location = New System.Drawing.Point(5, 101)
        Me.lblBloodTransfusion.Name = "lblBloodTransfusion"
        Me.lblBloodTransfusion.Size = New System.Drawing.Size(132, 20)
        Me.lblBloodTransfusion.TabIndex = 2
        Me.lblBloodTransfusion.Text = "Blood Transfusion"
        '
        'lblMedicalHistory
        '
        Me.lblMedicalHistory.Location = New System.Drawing.Point(6, 15)
        Me.lblMedicalHistory.Name = "lblMedicalHistory"
        Me.lblMedicalHistory.Size = New System.Drawing.Size(107, 20)
        Me.lblMedicalHistory.TabIndex = 0
        Me.lblMedicalHistory.Text = "Medical History"
        '
        'lblBloodTransfusionDate
        '
        Me.lblBloodTransfusionDate.Location = New System.Drawing.Point(6, 122)
        Me.lblBloodTransfusionDate.Name = "lblBloodTransfusionDate"
        Me.lblBloodTransfusionDate.Size = New System.Drawing.Size(133, 20)
        Me.lblBloodTransfusionDate.TabIndex = 4
        Me.lblBloodTransfusionDate.Text = "Blood transfusion Date"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 145)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Medical History Notes"
        '
        'grpOBSGyn
        '
        Me.grpOBSGyn.Controls.Add(Me.lblGynHistoryNotes)
        Me.grpOBSGyn.Controls.Add(Me.clbGynaecologicalHistory)
        Me.grpOBSGyn.Controls.Add(Me.stbGynHistoryNotes)
        Me.grpOBSGyn.Controls.Add(Me.lblGynaecologicalHistory)
        Me.grpOBSGyn.Location = New System.Drawing.Point(683, 19)
        Me.grpOBSGyn.Name = "grpOBSGyn"
        Me.grpOBSGyn.Size = New System.Drawing.Size(318, 191)
        Me.grpOBSGyn.TabIndex = 2
        Me.grpOBSGyn.TabStop = False
        Me.grpOBSGyn.Text = "OBS/GYN"
        '
        'lblGynHistoryNotes
        '
        Me.lblGynHistoryNotes.Location = New System.Drawing.Point(6, 108)
        Me.lblGynHistoryNotes.Name = "lblGynHistoryNotes"
        Me.lblGynHistoryNotes.Size = New System.Drawing.Size(133, 20)
        Me.lblGynHistoryNotes.TabIndex = 2
        Me.lblGynHistoryNotes.Text = "Gyn History Notes"
        '
        'lblGynaecologicalHistory
        '
        Me.lblGynaecologicalHistory.Location = New System.Drawing.Point(6, 29)
        Me.lblGynaecologicalHistory.Name = "lblGynaecologicalHistory"
        Me.lblGynaecologicalHistory.Size = New System.Drawing.Size(133, 20)
        Me.lblGynaecologicalHistory.TabIndex = 0
        Me.lblGynaecologicalHistory.Text = "Gynaecological History"
        '
        'grpSurgicalHistory
        '
        Me.grpSurgicalHistory.Controls.Add(Me.stbSurgicalHistoryNotes)
        Me.grpSurgicalHistory.Controls.Add(Me.lblSurgicalHistoryNotes)
        Me.grpSurgicalHistory.Controls.Add(Me.lblSurgicalHistory)
        Me.grpSurgicalHistory.Controls.Add(Me.clbSurgicalHistory)
        Me.grpSurgicalHistory.Location = New System.Drawing.Point(350, 19)
        Me.grpSurgicalHistory.Name = "grpSurgicalHistory"
        Me.grpSurgicalHistory.Size = New System.Drawing.Size(318, 191)
        Me.grpSurgicalHistory.TabIndex = 1
        Me.grpSurgicalHistory.TabStop = False
        Me.grpSurgicalHistory.Text = "SURGICAL HISTORY"
        '
        'lblSurgicalHistoryNotes
        '
        Me.lblSurgicalHistoryNotes.Location = New System.Drawing.Point(6, 103)
        Me.lblSurgicalHistoryNotes.Name = "lblSurgicalHistoryNotes"
        Me.lblSurgicalHistoryNotes.Size = New System.Drawing.Size(133, 20)
        Me.lblSurgicalHistoryNotes.TabIndex = 2
        Me.lblSurgicalHistoryNotes.Text = "Surgical History Notes"
        '
        'lblSurgicalHistory
        '
        Me.lblSurgicalHistory.Location = New System.Drawing.Point(6, 25)
        Me.lblSurgicalHistory.Name = "lblSurgicalHistory"
        Me.lblSurgicalHistory.Size = New System.Drawing.Size(133, 20)
        Me.lblSurgicalHistory.TabIndex = 0
        Me.lblSurgicalHistory.Text = "Surgical History"
        '
        'tpgFamilySocialHistory
        '
        Me.tpgFamilySocialHistory.Controls.Add(Me.grpFamilyHistory)
        Me.tpgFamilySocialHistory.Controls.Add(Me.grpSocialHistory)
        Me.tpgFamilySocialHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgFamilySocialHistory.Name = "tpgFamilySocialHistory"
        Me.tpgFamilySocialHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgFamilySocialHistory.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpgFamilySocialHistory.Size = New System.Drawing.Size(1005, 213)
        Me.tpgFamilySocialHistory.TabIndex = 1
        Me.tpgFamilySocialHistory.Text = "Family & Social"
        Me.tpgFamilySocialHistory.UseVisualStyleBackColor = True
        '
        'grpFamilyHistory
        '
        Me.grpFamilyHistory.Controls.Add(Me.clbFamilyHistory)
        Me.grpFamilyHistory.Controls.Add(Me.lblFamilyHistory)
        Me.grpFamilyHistory.Controls.Add(Me.stbFamilyHistoryNotes)
        Me.grpFamilyHistory.Controls.Add(Me.lblFamilyHistoryNotes)
        Me.grpFamilyHistory.Location = New System.Drawing.Point(6, 16)
        Me.grpFamilyHistory.Name = "grpFamilyHistory"
        Me.grpFamilyHistory.Size = New System.Drawing.Size(317, 164)
        Me.grpFamilyHistory.TabIndex = 0
        Me.grpFamilyHistory.TabStop = False
        Me.grpFamilyHistory.Text = "FAMILY HISTORY"
        '
        'lblFamilyHistory
        '
        Me.lblFamilyHistory.Location = New System.Drawing.Point(6, 26)
        Me.lblFamilyHistory.Name = "lblFamilyHistory"
        Me.lblFamilyHistory.Size = New System.Drawing.Size(134, 20)
        Me.lblFamilyHistory.TabIndex = 0
        Me.lblFamilyHistory.Text = "Family History"
        '
        'lblFamilyHistoryNotes
        '
        Me.lblFamilyHistoryNotes.Location = New System.Drawing.Point(6, 108)
        Me.lblFamilyHistoryNotes.Name = "lblFamilyHistoryNotes"
        Me.lblFamilyHistoryNotes.Size = New System.Drawing.Size(101, 20)
        Me.lblFamilyHistoryNotes.TabIndex = 2
        Me.lblFamilyHistoryNotes.Text = " Notes"
        '
        'grpSocialHistory
        '
        Me.grpSocialHistory.Controls.Add(Me.lblSocialHistoryNotes)
        Me.grpSocialHistory.Controls.Add(Me.clbSocialHistory)
        Me.grpSocialHistory.Controls.Add(Me.stbSocialHistoryNotes)
        Me.grpSocialHistory.Controls.Add(Me.lblSocialHistory)
        Me.grpSocialHistory.Location = New System.Drawing.Point(390, 16)
        Me.grpSocialHistory.Name = "grpSocialHistory"
        Me.grpSocialHistory.Size = New System.Drawing.Size(307, 164)
        Me.grpSocialHistory.TabIndex = 0
        Me.grpSocialHistory.TabStop = False
        Me.grpSocialHistory.Text = "SOCIAL HISTORY"
        '
        'lblSocialHistoryNotes
        '
        Me.lblSocialHistoryNotes.Location = New System.Drawing.Point(6, 103)
        Me.lblSocialHistoryNotes.Name = "lblSocialHistoryNotes"
        Me.lblSocialHistoryNotes.Size = New System.Drawing.Size(109, 20)
        Me.lblSocialHistoryNotes.TabIndex = 2
        Me.lblSocialHistoryNotes.Text = "Social History Notes"
        '
        'lblSocialHistory
        '
        Me.lblSocialHistory.Location = New System.Drawing.Point(7, 25)
        Me.lblSocialHistory.Name = "lblSocialHistory"
        Me.lblSocialHistory.Size = New System.Drawing.Size(101, 20)
        Me.lblSocialHistory.TabIndex = 0
        Me.lblSocialHistory.Text = "Social History"
        '
        'tpgObstetricHistory
        '
        Me.tpgObstetricHistory.Controls.Add(Me.dgvOBHistory)
        Me.tpgObstetricHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgObstetricHistory.Name = "tpgObstetricHistory"
        Me.tpgObstetricHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgObstetricHistory.Size = New System.Drawing.Size(1005, 213)
        Me.tpgObstetricHistory.TabIndex = 3
        Me.tpgObstetricHistory.Text = "Obstetric"
        Me.tpgObstetricHistory.UseVisualStyleBackColor = True
        '
        'dgvOBHistory
        '
        Me.dgvOBHistory.AllowUserToOrderColumns = True
        Me.dgvOBHistory.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOBHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvOBHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObstetricPregnancy, Me.colObstetricYear, Me.colObstetricAbortionID, Me.colObstetricAbortionPeriodID, Me.colTypeOfDelivery, Me.colObstetricThirdStageID, Me.colObstetricPeurPerinumID, Me.colObstetricChildStatusID, Me.colObstetricGenderID, Me.colObstetricBirthWeight, Me.colObstetricImmunised, Me.colObstetricHealthCondition, Me.colObstetricSaved})
        Me.dgvOBHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOBHistory.EnableHeadersVisualStyles = False
        Me.dgvOBHistory.GridColor = System.Drawing.Color.Khaki
        Me.dgvOBHistory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOBHistory.Location = New System.Drawing.Point(3, 3)
        Me.dgvOBHistory.Name = "dgvOBHistory"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOBHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvOBHistory.Size = New System.Drawing.Size(999, 207)
        Me.dgvOBHistory.TabIndex = 25
        Me.dgvOBHistory.Text = "DataGridView1"
        '
        'colObstetricPregnancy
        '
        Me.colObstetricPregnancy.HeaderText = "Pregnancy"
        Me.colObstetricPregnancy.Name = "colObstetricPregnancy"
        Me.colObstetricPregnancy.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricPregnancy.Width = 60
        '
        'colObstetricYear
        '
        Me.colObstetricYear.HeaderText = "Year"
        Me.colObstetricYear.Name = "colObstetricYear"
        Me.colObstetricYear.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colObstetricYear.Width = 50
        '
        'colObstetricAbortionID
        '
        Me.colObstetricAbortionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricAbortionID.HeaderText = "Abortion"
        Me.colObstetricAbortionID.Name = "colObstetricAbortionID"
        Me.colObstetricAbortionID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricAbortionID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colObstetricAbortionID.Width = 80
        '
        'colObstetricAbortionPeriodID
        '
        Me.colObstetricAbortionPeriodID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricAbortionPeriodID.HeaderText = "Abortion Period"
        Me.colObstetricAbortionPeriodID.Name = "colObstetricAbortionPeriodID"
        '
        'colTypeOfDelivery
        '
        Me.colTypeOfDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTypeOfDelivery.HeaderText = "Type Of Delivery"
        Me.colTypeOfDelivery.Name = "colTypeOfDelivery"
        Me.colTypeOfDelivery.Width = 120
        '
        'colObstetricThirdStageID
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        Me.colObstetricThirdStageID.DefaultCellStyle = DataGridViewCellStyle8
        Me.colObstetricThirdStageID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricThirdStageID.HeaderText = "Third Stage"
        Me.colObstetricThirdStageID.Name = "colObstetricThirdStageID"
        Me.colObstetricThirdStageID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricThirdStageID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colObstetricPeurPerinumID
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.colObstetricPeurPerinumID.DefaultCellStyle = DataGridViewCellStyle9
        Me.colObstetricPeurPerinumID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricPeurPerinumID.HeaderText = "Peur Perium"
        Me.colObstetricPeurPerinumID.Name = "colObstetricPeurPerinumID"
        Me.colObstetricPeurPerinumID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricPeurPerinumID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colObstetricChildStatusID
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        Me.colObstetricChildStatusID.DefaultCellStyle = DataGridViewCellStyle10
        Me.colObstetricChildStatusID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colObstetricChildStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricChildStatusID.HeaderText = "Child Status"
        Me.colObstetricChildStatusID.Name = "colObstetricChildStatusID"
        Me.colObstetricChildStatusID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricChildStatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colObstetricGenderID
        '
        Me.colObstetricGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricGenderID.HeaderText = "Gender"
        Me.colObstetricGenderID.Name = "colObstetricGenderID"
        Me.colObstetricGenderID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricGenderID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colObstetricGenderID.Width = 80
        '
        'colObstetricBirthWeight
        '
        Me.colObstetricBirthWeight.HeaderText = "Birth Weight"
        Me.colObstetricBirthWeight.Name = "colObstetricBirthWeight"
        '
        'colObstetricImmunised
        '
        Me.colObstetricImmunised.HeaderText = "Child Immunised"
        Me.colObstetricImmunised.Name = "colObstetricImmunised"
        Me.colObstetricImmunised.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colObstetricImmunised.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colObstetricHealthCondition
        '
        Me.colObstetricHealthCondition.HeaderText = "Child Health"
        Me.colObstetricHealthCondition.Name = "colObstetricHealthCondition"
        Me.colObstetricHealthCondition.Width = 150
        '
        'colObstetricSaved
        '
        Me.colObstetricSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = False
        Me.colObstetricSaved.DefaultCellStyle = DataGridViewCellStyle11
        Me.colObstetricSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colObstetricSaved.HeaderText = "Saved"
        Me.colObstetricSaved.Name = "colObstetricSaved"
        Me.colObstetricSaved.ReadOnly = True
        Me.colObstetricSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colObstetricSaved.Width = 50
        '
        'tpgPatientAllergies
        '
        Me.tpgPatientAllergies.Controls.Add(Me.dgvPatientAllergies)
        Me.tpgPatientAllergies.Location = New System.Drawing.Point(4, 22)
        Me.tpgPatientAllergies.Name = "tpgPatientAllergies"
        Me.tpgPatientAllergies.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPatientAllergies.Size = New System.Drawing.Size(1005, 213)
        Me.tpgPatientAllergies.TabIndex = 4
        Me.tpgPatientAllergies.Text = "Allergies"
        Me.tpgPatientAllergies.UseVisualStyleBackColor = True
        '
        'dgvPatientAllergies
        '
        Me.dgvPatientAllergies.AllowUserToOrderColumns = True
        Me.dgvPatientAllergies.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPatientAllergies.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAllergyNo, Me.colAllergyCategory, Me.colReaction, Me.colPatientAllergiesSaved})
        Me.dgvPatientAllergies.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPatientAllergies.EnableHeadersVisualStyles = False
        Me.dgvPatientAllergies.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientAllergies.Location = New System.Drawing.Point(3, 3)
        Me.dgvPatientAllergies.Name = "dgvPatientAllergies"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientAllergies.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvPatientAllergies.Size = New System.Drawing.Size(999, 207)
        Me.dgvPatientAllergies.TabIndex = 1
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
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colAllergyCategory.DefaultCellStyle = DataGridViewCellStyle14
        Me.colAllergyCategory.HeaderText = "Category"
        Me.colAllergyCategory.Name = "colAllergyCategory"
        Me.colAllergyCategory.ReadOnly = True
        Me.colAllergyCategory.Width = 80
        '
        'colReaction
        '
        Me.colReaction.DataPropertyName = "Reaction"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colReaction.DefaultCellStyle = DataGridViewCellStyle15
        Me.colReaction.HeaderText = "Reaction"
        Me.colReaction.MaxInputLength = 200
        Me.colReaction.Name = "colReaction"
        Me.colReaction.Width = 180
        '
        'colPatientAllergiesSaved
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.NullValue = False
        Me.colPatientAllergiesSaved.DefaultCellStyle = DataGridViewCellStyle16
        Me.colPatientAllergiesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPatientAllergiesSaved.HeaderText = "Saved"
        Me.colPatientAllergiesSaved.Name = "colPatientAllergiesSaved"
        Me.colPatientAllergiesSaved.ReadOnly = True
        Me.colPatientAllergiesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPatientAllergiesSaved.Width = 50
        '
        'stbANCNo
        '
        Me.stbANCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbANCNo.CapitalizeFirstLetter = False
        Me.btnSave.SetDataMember(Me.stbANCNo, "ANCNo")
        Me.stbANCNo.EntryErrorMSG = ""
        Me.stbANCNo.Location = New System.Drawing.Point(168, 27)
        Me.stbANCNo.Name = "stbANCNo"
        Me.stbANCNo.RegularExpression = ""
        Me.stbANCNo.Size = New System.Drawing.Size(170, 20)
        Me.stbANCNo.TabIndex = 6
        '
        'cboPartnersHIVStatusID
        '
        Me.btnSave.SetDataMember(Me.cboPartnersHIVStatusID, "CycleRegular,CycleRegularID")
        Me.cboPartnersHIVStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPartnersHIVStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPartnersHIVStatusID.Location = New System.Drawing.Point(499, 111)
        Me.cboPartnersHIVStatusID.Name = "cboPartnersHIVStatusID"
        Me.cboPartnersHIVStatusID.Size = New System.Drawing.Size(151, 21)
        Me.cboPartnersHIVStatusID.TabIndex = 24
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(958, 389)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(168, 5)
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(113, 20)
        Me.stbPatientNo.TabIndex = 2
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(30, 5)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(97, 20)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient No"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(948, 120)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(89, 20)
        Me.lblPhoto.TabIndex = 36
        Me.lblPhoto.Text = "Photo"
        Me.lblPhoto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(678, 71)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(77, 20)
        Me.lblVisitDate.TabIndex = 31
        Me.lblVisitDate.Text = "Last Visit Date"
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.Location = New System.Drawing.Point(137, 4)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(27, 21)
        Me.btnSearch.TabIndex = 1
        '
        'btnLoad
        '
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(287, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(51, 24)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(678, 5)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(89, 20)
        Me.lblAge.TabIndex = 25
        Me.lblAge.Text = "Age"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(30, 54)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(126, 20)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Patient's Name"
        '
        'lblHIVStatus
        '
        Me.lblHIVStatus.Location = New System.Drawing.Point(30, 117)
        Me.lblHIVStatus.Name = "lblHIVStatus"
        Me.lblHIVStatus.Size = New System.Drawing.Size(97, 20)
        Me.lblHIVStatus.TabIndex = 13
        Me.lblHIVStatus.Text = "HIV Status"
        '
        'stbAdress
        '
        Me.stbAdress.BackColor = System.Drawing.SystemColors.Control
        Me.stbAdress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdress.CapitalizeFirstLetter = True
        Me.stbAdress.Enabled = False
        Me.stbAdress.EntryErrorMSG = ""
        Me.stbAdress.Location = New System.Drawing.Point(499, 67)
        Me.stbAdress.MaxLength = 41
        Me.stbAdress.Multiline = True
        Me.stbAdress.Name = "stbAdress"
        Me.stbAdress.RegularExpression = ""
        Me.stbAdress.Size = New System.Drawing.Size(151, 41)
        Me.stbAdress.TabIndex = 22
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(358, 69)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(77, 20)
        Me.lblAddress.TabIndex = 21
        Me.lblAddress.Text = "Address"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(782, 26)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.ReadOnly = True
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(130, 20)
        Me.stbPhone.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(678, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 20)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Telephone"
        '
        'stbOccupation
        '
        Me.stbOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOccupation.CapitalizeFirstLetter = False
        Me.stbOccupation.Enabled = False
        Me.stbOccupation.EntryErrorMSG = ""
        Me.stbOccupation.Location = New System.Drawing.Point(499, 25)
        Me.stbOccupation.Name = "stbOccupation"
        Me.stbOccupation.ReadOnly = True
        Me.stbOccupation.RegularExpression = ""
        Me.stbOccupation.Size = New System.Drawing.Size(151, 20)
        Me.stbOccupation.TabIndex = 18
        '
        'lblOccupation
        '
        Me.lblOccupation.Location = New System.Drawing.Point(358, 27)
        Me.lblOccupation.Name = "lblOccupation"
        Me.lblOccupation.Size = New System.Drawing.Size(77, 20)
        Me.lblOccupation.TabIndex = 17
        Me.lblOccupation.Text = "Occupation"
        '
        'stbMaritalStatus
        '
        Me.stbMaritalStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMaritalStatus.CapitalizeFirstLetter = False
        Me.stbMaritalStatus.Enabled = False
        Me.stbMaritalStatus.EntryErrorMSG = ""
        Me.stbMaritalStatus.Location = New System.Drawing.Point(499, 46)
        Me.stbMaritalStatus.Name = "stbMaritalStatus"
        Me.stbMaritalStatus.ReadOnly = True
        Me.stbMaritalStatus.RegularExpression = ""
        Me.stbMaritalStatus.Size = New System.Drawing.Size(151, 20)
        Me.stbMaritalStatus.TabIndex = 20
        '
        'lblMaritalStatus
        '
        Me.lblMaritalStatus.Location = New System.Drawing.Point(358, 48)
        Me.lblMaritalStatus.Name = "lblMaritalStatus"
        Me.lblMaritalStatus.Size = New System.Drawing.Size(77, 20)
        Me.lblMaritalStatus.TabIndex = 19
        Me.lblMaritalStatus.Text = "Marital Status"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(678, 50)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(77, 20)
        Me.lblJoinDate.TabIndex = 29
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblNoOfVisits
        '
        Me.lblNoOfVisits.Location = New System.Drawing.Point(678, 92)
        Me.lblNoOfVisits.Name = "lblNoOfVisits"
        Me.lblNoOfVisits.Size = New System.Drawing.Size(77, 20)
        Me.lblNoOfVisits.TabIndex = 33
        Me.lblNoOfVisits.Text = "Total Visits"
        '
        'lblBloodGroup
        '
        Me.lblBloodGroup.Location = New System.Drawing.Point(358, 9)
        Me.lblBloodGroup.Name = "lblBloodGroup"
        Me.lblBloodGroup.Size = New System.Drawing.Size(71, 20)
        Me.lblBloodGroup.TabIndex = 15
        Me.lblBloodGroup.Text = "Blood Group"
        '
        'lblGravida
        '
        Me.lblGravida.Location = New System.Drawing.Point(30, 76)
        Me.lblGravida.Name = "lblGravida"
        Me.lblGravida.Size = New System.Drawing.Size(126, 20)
        Me.lblGravida.TabIndex = 9
        Me.lblGravida.Text = "Gravida"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(30, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Para"
        '
        'nbxPara
        '
        Me.nbxPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPara.ControlCaption = "Gravidity"
        Me.nbxPara.DecimalPlaces = -1
        Me.nbxPara.Location = New System.Drawing.Point(168, 93)
        Me.nbxPara.MaxValue = 0.0R
        Me.nbxPara.MinValue = 0.0R
        Me.nbxPara.MustEnterNumeric = True
        Me.nbxPara.Name = "nbxPara"
        Me.nbxPara.Size = New System.Drawing.Size(170, 20)
        Me.nbxPara.TabIndex = 12
        Me.nbxPara.Value = ""
        '
        'nbxGravida
        '
        Me.nbxGravida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxGravida.ControlCaption = "Gravidity"
        Me.nbxGravida.DecimalPlaces = -1
        Me.nbxGravida.Location = New System.Drawing.Point(168, 71)
        Me.nbxGravida.MaxValue = 0.0R
        Me.nbxGravida.MinValue = 0.0R
        Me.nbxGravida.MustEnterNumeric = True
        Me.nbxGravida.Name = "nbxGravida"
        Me.nbxGravida.Size = New System.Drawing.Size(170, 20)
        Me.nbxGravida.TabIndex = 10
        Me.nbxGravida.Value = ""
        '
        'lblANCNo
        '
        Me.lblANCNo.Location = New System.Drawing.Point(30, 26)
        Me.lblANCNo.Name = "lblANCNo"
        Me.lblANCNo.Size = New System.Drawing.Size(97, 20)
        Me.lblANCNo.TabIndex = 4
        Me.lblANCNo.Text = "ANC No"
        '
        'btnFindANCNo
        '
        Me.btnFindANCNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindANCNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindANCNo.Image = CType(resources.GetObject("btnFindANCNo.Image"), System.Drawing.Image)
        Me.btnFindANCNo.Location = New System.Drawing.Point(137, 27)
        Me.btnFindANCNo.Name = "btnFindANCNo"
        Me.btnFindANCNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindANCNo.TabIndex = 5
        '
        'lblPartnerHIVStatus
        '
        Me.lblPartnerHIVStatus.Location = New System.Drawing.Point(358, 112)
        Me.lblPartnerHIVStatus.Name = "lblPartnerHIVStatus"
        Me.lblPartnerHIVStatus.Size = New System.Drawing.Size(135, 20)
        Me.lblPartnerHIVStatus.TabIndex = 23
        Me.lblPartnerHIVStatus.Text = "Partner's HIV Status"
        '
        'pnlStatusID
        '
        Me.pnlStatusID.Controls.Add(Me.fcbStatusID)
        Me.pnlStatusID.Controls.Add(Me.lblStatusID)
        Me.pnlStatusID.Location = New System.Drawing.Point(656, 112)
        Me.pnlStatusID.Name = "pnlStatusID"
        Me.pnlStatusID.Size = New System.Drawing.Size(256, 29)
        Me.pnlStatusID.TabIndex = 35
        '
        'fcbStatusID
        '
        Me.fcbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbStatusID.FormattingEnabled = True
        Me.fcbStatusID.Location = New System.Drawing.Point(126, 5)
        Me.fcbStatusID.Name = "fcbStatusID"
        Me.fcbStatusID.ReadOnly = True
        Me.fcbStatusID.Size = New System.Drawing.Size(127, 21)
        Me.fcbStatusID.TabIndex = 1
        '
        'lblStatusID
        '
        Me.lblStatusID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStatusID.Location = New System.Drawing.Point(22, 4)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(95, 21)
        Me.lblStatusID.TabIndex = 0
        Me.lblStatusID.Text = "Status"
        '
        'frmMaternalEnrollment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1073, 444)
        Me.Controls.Add(Me.pnlStatusID)
        Me.Controls.Add(Me.cboPartnersHIVStatusID)
        Me.Controls.Add(Me.lblPartnerHIVStatus)
        Me.Controls.Add(Me.btnFindANCNo)
        Me.Controls.Add(Me.stbANCNo)
        Me.Controls.Add(Me.lblANCNo)
        Me.Controls.Add(Me.nbxGravida)
        Me.Controls.Add(Me.nbxPara)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblGravida)
        Me.Controls.Add(Me.cboHIVStatusID)
        Me.Controls.Add(Me.stbBloodGroup)
        Me.Controls.Add(Me.lblBloodGroup)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblNoOfVisits)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbMaritalStatus)
        Me.Controls.Add(Me.lblMaritalStatus)
        Me.Controls.Add(Me.stbOccupation)
        Me.Controls.Add(Me.lblOccupation)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.stbAdress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.lblHIVStatus)
        Me.Controls.Add(Me.tbcMaternalEnrollment)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMaternalEnrollment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "MaternalEnrollment"
        Me.Text = "Maternal Enrollment"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcMaternalEnrollment.ResumeLayout(False)
        Me.tpgCurrentPregnancy.ResumeLayout(False)
        Me.tbcCurrentPregnancy.ResumeLayout(False)
        Me.tpgMenstruationHistory.ResumeLayout(False)
        Me.tpgContraceptivesHistory.ResumeLayout(False)
        CType(Me.dgvContraceptives, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPreviousIllnesses.ResumeLayout(False)
        Me.grpMedicalHistory.ResumeLayout(False)
        Me.grpMedicalHistory.PerformLayout()
        Me.grpOBSGyn.ResumeLayout(False)
        Me.grpOBSGyn.PerformLayout()
        Me.grpSurgicalHistory.ResumeLayout(False)
        Me.grpSurgicalHistory.PerformLayout()
        Me.tpgFamilySocialHistory.ResumeLayout(False)
        Me.grpFamilyHistory.ResumeLayout(False)
        Me.grpFamilyHistory.PerformLayout()
        Me.grpSocialHistory.ResumeLayout(False)
        Me.grpSocialHistory.PerformLayout()
        Me.tpgObstetricHistory.ResumeLayout(False)
        CType(Me.dgvOBHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPatientAllergies.ResumeLayout(False)
        CType(Me.dgvPatientAllergies, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusID.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnSave As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents txtVisitDate As System.Windows.Forms.TextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents tbcMaternalEnrollment As System.Windows.Forms.TabControl
    Friend WithEvents tpgCurrentPregnancy As System.Windows.Forms.TabPage
    Friend WithEvents tpgFamilySocialHistory As System.Windows.Forms.TabPage
    Friend WithEvents grpFamilyHistory As System.Windows.Forms.GroupBox
    Friend WithEvents clbFamilyHistory As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblFamilyHistory As System.Windows.Forms.Label
    Friend WithEvents stbFamilyHistoryNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFamilyHistoryNotes As System.Windows.Forms.Label
    Friend WithEvents grpSocialHistory As System.Windows.Forms.GroupBox
    Friend WithEvents lblSocialHistoryNotes As System.Windows.Forms.Label
    Friend WithEvents clbSocialHistory As System.Windows.Forms.CheckedListBox
    Friend WithEvents stbSocialHistoryNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSocialHistory As System.Windows.Forms.Label
    Friend WithEvents tpgPreviousIllnesses As System.Windows.Forms.TabPage
    Friend WithEvents grpSurgicalHistory As System.Windows.Forms.GroupBox
    Friend WithEvents stbSurgicalHistoryNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSurgicalHistoryNotes As System.Windows.Forms.Label
    Friend WithEvents lblSurgicalHistory As System.Windows.Forms.Label
    Friend WithEvents clbSurgicalHistory As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblHIVStatus As System.Windows.Forms.Label
    Friend WithEvents grpMedicalHistory As System.Windows.Forms.GroupBox
    Friend WithEvents clbMedicalHistory As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblMedicalHistory As System.Windows.Forms.Label
    Friend WithEvents dtpBloodTransfusionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBloodTransfusionDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbMedicalHistoryNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents grpOBSGyn As System.Windows.Forms.GroupBox
    Friend WithEvents lblGynHistoryNotes As System.Windows.Forms.Label
    Friend WithEvents clbGynaecologicalHistory As System.Windows.Forms.CheckedListBox
    Friend WithEvents stbGynHistoryNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGynaecologicalHistory As System.Windows.Forms.Label
    Friend WithEvents lblLNMP As System.Windows.Forms.Label
    Friend WithEvents chkLNMPDateReliable As System.Windows.Forms.CheckBox
    Friend WithEvents tbcCurrentPregnancy As System.Windows.Forms.TabControl
    Friend WithEvents tpgMenstruationHistory As System.Windows.Forms.TabPage
    Friend WithEvents cboCycleRegularID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCycleRegularID As System.Windows.Forms.Label
    Friend WithEvents lblEDD As System.Windows.Forms.Label
    Friend WithEvents tpgContraceptivesHistory As System.Windows.Forms.TabPage
    Friend WithEvents dgvContraceptives As System.Windows.Forms.DataGridView
    Friend WithEvents stbAdress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblScanDate As System.Windows.Forms.Label
    Friend WithEvents stbOccupation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOccupation As System.Windows.Forms.Label
    Friend WithEvents stbMaritalStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMaritalStatus As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As System.Windows.Forms.TextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As System.Windows.Forms.TextBox
    Friend WithEvents lblNoOfVisits As System.Windows.Forms.Label
    Friend WithEvents colContraceptiveID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colComplications As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colComplicationDetails As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colContraceptiveDateStarted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContraceptiveDiscontinued As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colContraceptiveRemovalReasons As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colContraceptiveNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContraceptiveSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgObstetricHistory As System.Windows.Forms.TabPage
    Friend WithEvents dgvOBHistory As System.Windows.Forms.DataGridView
    Friend WithEvents stbBloodGroup As System.Windows.Forms.TextBox
    Friend WithEvents lblBloodGroup As System.Windows.Forms.Label
    Friend WithEvents cboHIVStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGravida As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nbxPara As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxGravida As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboBloodTransfusion As System.Windows.Forms.ComboBox
    Friend WithEvents lblBloodTransfusion As System.Windows.Forms.Label
    Friend WithEvents tpgPatientAllergies As System.Windows.Forms.TabPage
    Friend WithEvents dgvPatientAllergies As System.Windows.Forms.DataGridView
    Friend WithEvents colAllergyNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAllergyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientAllergiesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stbANCNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblANCNo As System.Windows.Forms.Label
    Friend WithEvents btnFindANCNo As System.Windows.Forms.Button
    Friend WithEvents cboPartnersHIVStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPartnerHIVStatus As System.Windows.Forms.Label
    Friend WithEvents colObstetricPregnancy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObstetricYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObstetricAbortionID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricAbortionPeriodID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTypeOfDelivery As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricThirdStageID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricPeurPerinumID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricChildStatusID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricGenderID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colObstetricBirthWeight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObstetricImmunised As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colObstetricHealthCondition As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObstetricSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pnlStatusID As System.Windows.Forms.Panel
    Friend WithEvents fcbStatusID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpLNMP As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEDD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpScanDate As System.Windows.Forms.DateTimePicker

End Class