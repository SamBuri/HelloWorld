
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPathologyReports : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPathologyReports))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboReportTypeID = New System.Windows.Forms.ComboBox()
        Me.cboPathologist = New System.Windows.Forms.ComboBox()
        Me.cboPathologyTitleID = New System.Windows.Forms.ComboBox()
        Me.stbIndication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpExamDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbMacroscopic = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMicroscopic = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblReportTypeID = New System.Windows.Forms.Label()
        Me.lblPathologist = New System.Windows.Forms.Label()
        Me.lblPathologyTitleID = New System.Windows.Forms.Label()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.btnViewTemplates = New System.Windows.Forms.Button()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.btnLoadProcessingPathology = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbUnitPrice = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.cboExamFullName = New System.Windows.Forms.ComboBox()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.lblExamFullName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkPrintExamReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.tbcPathologyReport = New System.Windows.Forms.TabControl()
        Me.tpgPathologyDiagnosis = New System.Windows.Forms.TabPage()
        Me.lblMicroscopic = New System.Windows.Forms.Label()
        Me.lblmacroscopic = New System.Windows.Forms.Label()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.tpgPathologyImages = New System.Windows.Forms.TabPage()
        Me.dgvPathologyImages = New System.Windows.Forms.DataGridView()
        Me.colSelectImage = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colPathologyImage = New System.Windows.Forms.DataGridViewImageColumn()
        Me.colPathologymageName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyImagesSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.pnlVisitNo.SuspendLayout()
        Me.tbcPathologyReport.SuspendLayout()
        Me.tpgPathologyDiagnosis.SuspendLayout()
        Me.tpgPathologyImages.SuspendLayout()
        CType(Me.dgvPathologyImages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(22, 443)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 44
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(800, 442)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 49
        Me.fbnDelete.Tag = "PathologyReports"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(22, 470)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 45
        Me.ebnSaveUpdate.Tag = "PathologyReports"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboReportTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReportTypeID, "ReportType,ReportTypeID")
        Me.cboReportTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReportTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReportTypeID.Location = New System.Drawing.Point(156, 191)
        Me.cboReportTypeID.Name = "cboReportTypeID"
        Me.cboReportTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboReportTypeID.TabIndex = 14
        '
        'cboPathologist
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPathologist, "PathologistFullName")
        Me.cboPathologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPathologist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPathologist.Location = New System.Drawing.Point(156, 167)
        Me.cboPathologist.Name = "cboPathologist"
        Me.cboPathologist.Size = New System.Drawing.Size(170, 21)
        Me.cboPathologist.TabIndex = 12
        '
        'cboPathologyTitleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPathologyTitleID, "PathologyTitle,PathologyTitleID")
        Me.cboPathologyTitleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPathologyTitleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPathologyTitleID.Location = New System.Drawing.Point(156, 144)
        Me.cboPathologyTitleID.Name = "cboPathologyTitleID"
        Me.cboPathologyTitleID.Size = New System.Drawing.Size(170, 21)
        Me.cboPathologyTitleID.TabIndex = 10
        '
        'stbIndication
        '
        Me.stbIndication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIndication.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbIndication, "Indication")
        Me.stbIndication.EntryErrorMSG = ""
        Me.stbIndication.Location = New System.Drawing.Point(156, 72)
        Me.stbIndication.MaxLength = 4000
        Me.stbIndication.Multiline = True
        Me.stbIndication.Name = "stbIndication"
        Me.stbIndication.RegularExpression = ""
        Me.stbIndication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbIndication.Size = New System.Drawing.Size(170, 28)
        Me.stbIndication.TabIndex = 4
        '
        'dtpExamDateTime
        '
        Me.dtpExamDateTime.Checked = False
        Me.dtpExamDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExamDateTime, "ExamDateTime")
        Me.dtpExamDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExamDateTime.Location = New System.Drawing.Point(156, 122)
        Me.dtpExamDateTime.Name = "dtpExamDateTime"
        Me.dtpExamDateTime.ShowCheckBox = True
        Me.dtpExamDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpExamDateTime.TabIndex = 8
        '
        'stbMacroscopic
        '
        Me.stbMacroscopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMacroscopic.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMacroscopic, "Macroscopic")
        Me.stbMacroscopic.EntryErrorMSG = ""
        Me.stbMacroscopic.Location = New System.Drawing.Point(100, 8)
        Me.stbMacroscopic.Multiline = True
        Me.stbMacroscopic.Name = "stbMacroscopic"
        Me.stbMacroscopic.RegularExpression = ""
        Me.stbMacroscopic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMacroscopic.Size = New System.Drawing.Size(745, 57)
        Me.stbMacroscopic.TabIndex = 1
        '
        'stbMicroscopic
        '
        Me.stbMicroscopic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMicroscopic.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMicroscopic, "Microscopic")
        Me.stbMicroscopic.EntryErrorMSG = ""
        Me.stbMicroscopic.Location = New System.Drawing.Point(100, 67)
        Me.stbMicroscopic.Multiline = True
        Me.stbMicroscopic.Name = "stbMicroscopic"
        Me.stbMicroscopic.RegularExpression = ""
        Me.stbMicroscopic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMicroscopic.Size = New System.Drawing.Size(745, 64)
        Me.stbMicroscopic.TabIndex = 3
        Me.stbMicroscopic.Tag = ""
        '
        'stbDiagnosis
        '
        Me.stbDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiagnosis.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiagnosis, "Diagnosis")
        Me.stbDiagnosis.EntryErrorMSG = ""
        Me.stbDiagnosis.Location = New System.Drawing.Point(100, 133)
        Me.stbDiagnosis.Multiline = True
        Me.stbDiagnosis.Name = "stbDiagnosis"
        Me.stbDiagnosis.RegularExpression = ""
        Me.stbDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDiagnosis.Size = New System.Drawing.Size(745, 58)
        Me.stbDiagnosis.TabIndex = 5
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(800, 469)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 48
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblReportTypeID
        '
        Me.lblReportTypeID.Location = New System.Drawing.Point(17, 191)
        Me.lblReportTypeID.Name = "lblReportTypeID"
        Me.lblReportTypeID.Size = New System.Drawing.Size(123, 20)
        Me.lblReportTypeID.TabIndex = 13
        Me.lblReportTypeID.Text = "Report Type"
        '
        'lblPathologist
        '
        Me.lblPathologist.Location = New System.Drawing.Point(17, 171)
        Me.lblPathologist.Name = "lblPathologist"
        Me.lblPathologist.Size = New System.Drawing.Size(123, 20)
        Me.lblPathologist.TabIndex = 11
        Me.lblPathologist.Text = "Pathologist"
        '
        'lblPathologyTitleID
        '
        Me.lblPathologyTitleID.Location = New System.Drawing.Point(17, 147)
        Me.lblPathologyTitleID.Name = "lblPathologyTitleID"
        Me.lblPathologyTitleID.Size = New System.Drawing.Size(123, 20)
        Me.lblPathologyTitleID.TabIndex = 9
        Me.lblPathologyTitleID.Text = "PathologyTitle"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(726, 95)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(143, 20)
        Me.stbMemberCardNo.TabIndex = 40
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(599, 95)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(121, 20)
        Me.lblMemberCardNo.TabIndex = 39
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(748, 188)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 42
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'btnViewTemplates
        '
        Me.btnViewTemplates.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTemplates.Location = New System.Drawing.Point(599, 187)
        Me.btnViewTemplates.Name = "btnViewTemplates"
        Me.btnViewTemplates.Size = New System.Drawing.Size(117, 24)
        Me.btnViewTemplates.TabIndex = 41
        Me.btnViewTemplates.Tag = ""
        Me.btnViewTemplates.Text = "&View Templates"
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.btnLoadProcessingPathology)
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.Label1)
        Me.pnlVisitNo.Controls.Add(Me.btnFindVisitNo)
        Me.pnlVisitNo.Location = New System.Drawing.Point(11, 14)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(326, 31)
        Me.pnlVisitNo.TabIndex = 0
        '
        'btnLoadProcessingPathology
        '
        Me.btnLoadProcessingPathology.AccessibleDescription = ""
        Me.btnLoadProcessingPathology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadProcessingPathology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadProcessingPathology.Location = New System.Drawing.Point(272, 3)
        Me.btnLoadProcessingPathology.Name = "btnLoadProcessingPathology"
        Me.btnLoadProcessingPathology.Size = New System.Drawing.Size(45, 24)
        Me.btnLoadProcessingPathology.TabIndex = 3
        Me.btnLoadProcessingPathology.Tag = ""
        Me.btnLoadProcessingPathology.Text = "&Load"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 7)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Visit No."
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(113, 7)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(726, 65)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(143, 29)
        Me.stbBillCustomerName.TabIndex = 38
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(599, 69)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(121, 20)
        Me.lblBillCustomerName.TabIndex = 37
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbUnitPrice
        '
        Me.stbUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.stbUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitPrice.CapitalizeFirstLetter = False
        Me.stbUnitPrice.Enabled = False
        Me.stbUnitPrice.EntryErrorMSG = ""
        Me.stbUnitPrice.Location = New System.Drawing.Point(156, 101)
        Me.stbUnitPrice.MaxLength = 20
        Me.stbUnitPrice.Name = "stbUnitPrice"
        Me.stbUnitPrice.RegularExpression = ""
        Me.stbUnitPrice.Size = New System.Drawing.Size(170, 20)
        Me.stbUnitPrice.TabIndex = 6
        Me.stbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(17, 101)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(123, 20)
        Me.lblUnitPrice.TabIndex = 5
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'cboExamFullName
        '
        Me.cboExamFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboExamFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExamFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamFullName.DropDownWidth = 214
        Me.cboExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExamFullName.FormattingEnabled = True
        Me.cboExamFullName.Location = New System.Drawing.Point(156, 49)
        Me.cboExamFullName.Name = "cboExamFullName"
        Me.cboExamFullName.Size = New System.Drawing.Size(170, 21)
        Me.cboExamFullName.Sorted = True
        Me.cboExamFullName.TabIndex = 2
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(457, 86)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(126, 20)
        Me.stbPrimaryDoctor.TabIndex = 22
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(343, 85)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(108, 20)
        Me.lblPrimaryDoctor.TabIndex = 21
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(457, 149)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitDate.TabIndex = 28
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(343, 149)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 27
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(457, 170)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(126, 20)
        Me.stbFullName.TabIndex = 30
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(343, 170)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(108, 20)
        Me.lblFullName.TabIndex = 29
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(457, 23)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(126, 20)
        Me.stbPatientNo.TabIndex = 16
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(343, 23)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(108, 20)
        Me.lblPatientsNo.TabIndex = 15
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(726, 23)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(143, 20)
        Me.stbBillMode.TabIndex = 34
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(457, 65)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitCategory.TabIndex = 20
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(599, 23)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(121, 20)
        Me.lblBillMode.TabIndex = 33
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(343, 64)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCategory.TabIndex = 19
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(457, 128)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(126, 20)
        Me.stbStatus.TabIndex = 26
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(343, 128)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 20)
        Me.lblStatus.TabIndex = 25
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(457, 44)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(126, 20)
        Me.stbBillNo.TabIndex = 18
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(457, 107)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(126, 20)
        Me.stbAge.TabIndex = 24
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(726, 44)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(143, 20)
        Me.stbJoinDate.TabIndex = 36
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(457, 191)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(126, 20)
        Me.stbGender.TabIndex = 32
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(599, 44)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(121, 20)
        Me.lblJoinDate.TabIndex = 35
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(343, 44)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(108, 20)
        Me.lblBillNo.TabIndex = 17
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(343, 107)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 23
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(343, 190)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(108, 20)
        Me.lblGenderID.TabIndex = 31
        Me.lblGenderID.Text = "Gender"
        '
        'lblIndication
        '
        Me.lblIndication.Location = New System.Drawing.Point(17, 76)
        Me.lblIndication.Name = "lblIndication"
        Me.lblIndication.Size = New System.Drawing.Size(123, 20)
        Me.lblIndication.TabIndex = 3
        Me.lblIndication.Text = "Indication"
        '
        'lblExamFullName
        '
        Me.lblExamFullName.Location = New System.Drawing.Point(17, 49)
        Me.lblExamFullName.Name = "lblExamFullName"
        Me.lblExamFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblExamFullName.TabIndex = 1
        Me.lblExamFullName.Text = "Pathology Examination"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Exam Date Time"
        '
        'chkPrintExamReportOnSaving
        '
        Me.chkPrintExamReportOnSaving.AccessibleDescription = ""
        Me.chkPrintExamReportOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintExamReportOnSaving.AutoSize = True
        Me.chkPrintExamReportOnSaving.Location = New System.Drawing.Point(105, 474)
        Me.chkPrintExamReportOnSaving.Name = "chkPrintExamReportOnSaving"
        Me.chkPrintExamReportOnSaving.Size = New System.Drawing.Size(167, 17)
        Me.chkPrintExamReportOnSaving.TabIndex = 46
        Me.chkPrintExamReportOnSaving.Text = " Print Exam Report On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(717, 469)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 47
        Me.btnPrint.Text = "&Print"
        '
        'tbcPathologyReport
        '
        Me.tbcPathologyReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPathologyReport.Controls.Add(Me.tpgPathologyDiagnosis)
        Me.tbcPathologyReport.Controls.Add(Me.tpgPathologyImages)
        Me.tbcPathologyReport.HotTrack = True
        Me.tbcPathologyReport.Location = New System.Drawing.Point(20, 217)
        Me.tbcPathologyReport.Name = "tbcPathologyReport"
        Me.tbcPathologyReport.SelectedIndex = 0
        Me.tbcPathologyReport.Size = New System.Drawing.Size(856, 220)
        Me.tbcPathologyReport.TabIndex = 43
        '
        'tpgPathologyDiagnosis
        '
        Me.tpgPathologyDiagnosis.Controls.Add(Me.lblMicroscopic)
        Me.tpgPathologyDiagnosis.Controls.Add(Me.lblmacroscopic)
        Me.tpgPathologyDiagnosis.Controls.Add(Me.lblDiagnosis)
        Me.tpgPathologyDiagnosis.Controls.Add(Me.stbMacroscopic)
        Me.tpgPathologyDiagnosis.Controls.Add(Me.stbMicroscopic)
        Me.tpgPathologyDiagnosis.Controls.Add(Me.stbDiagnosis)
        Me.tpgPathologyDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgPathologyDiagnosis.Name = "tpgPathologyDiagnosis"
        Me.tpgPathologyDiagnosis.Size = New System.Drawing.Size(848, 194)
        Me.tpgPathologyDiagnosis.TabIndex = 2
        Me.tpgPathologyDiagnosis.Tag = "PathologyDiagnosis"
        Me.tpgPathologyDiagnosis.Text = "Diagnosis"
        Me.tpgPathologyDiagnosis.UseVisualStyleBackColor = True
        '
        'lblMicroscopic
        '
        Me.lblMicroscopic.Location = New System.Drawing.Point(6, 67)
        Me.lblMicroscopic.Name = "lblMicroscopic"
        Me.lblMicroscopic.Size = New System.Drawing.Size(88, 40)
        Me.lblMicroscopic.TabIndex = 2
        Me.lblMicroscopic.Text = "Microscopic Appearance"
        '
        'lblmacroscopic
        '
        Me.lblmacroscopic.Location = New System.Drawing.Point(8, 8)
        Me.lblmacroscopic.Name = "lblmacroscopic"
        Me.lblmacroscopic.Size = New System.Drawing.Size(86, 40)
        Me.lblmacroscopic.TabIndex = 0
        Me.lblmacroscopic.Text = "Macroscopic Apperance"
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.Location = New System.Drawing.Point(8, 135)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(86, 39)
        Me.lblDiagnosis.TabIndex = 4
        Me.lblDiagnosis.Text = "Diagnosis / Conclusion"
        '
        'tpgPathologyImages
        '
        Me.tpgPathologyImages.Controls.Add(Me.dgvPathologyImages)
        Me.tpgPathologyImages.Location = New System.Drawing.Point(4, 22)
        Me.tpgPathologyImages.Name = "tpgPathologyImages"
        Me.tpgPathologyImages.Size = New System.Drawing.Size(848, 178)
        Me.tpgPathologyImages.TabIndex = 1
        Me.tpgPathologyImages.Tag = "PathologyDiagnosis"
        Me.tpgPathologyImages.Text = "Images"
        Me.tpgPathologyImages.UseVisualStyleBackColor = True
        '
        'dgvPathologyImages
        '
        Me.dgvPathologyImages.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPathologyImages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPathologyImages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelectImage, Me.colPathologyImage, Me.colPathologymageName, Me.colPathologyImagesSaved})
        Me.dgvPathologyImages.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPathologyImages.EnableHeadersVisualStyles = False
        Me.dgvPathologyImages.GridColor = System.Drawing.Color.Khaki
        Me.dgvPathologyImages.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvPathologyImages.Location = New System.Drawing.Point(0, 0)
        Me.dgvPathologyImages.Name = "dgvPathologyImages"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPathologyImages.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPathologyImages.Size = New System.Drawing.Size(848, 178)
        Me.dgvPathologyImages.TabIndex = 105
        Me.dgvPathologyImages.Text = "DataGridView1"
        '
        'colSelectImage
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colSelectImage.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSelectImage.HeaderText = "Select"
        Me.colSelectImage.Name = "colSelectImage"
        Me.colSelectImage.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSelectImage.Text = ""
        Me.colSelectImage.Width = 50
        '
        'colPathologyImage
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colPathologyImage.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPathologyImage.HeaderText = "Image"
        Me.colPathologyImage.Name = "colPathologyImage"
        Me.colPathologyImage.ReadOnly = True
        Me.colPathologyImage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPathologyImage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPathologyImage.Width = 250
        '
        'colPathologymageName
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.colPathologymageName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPathologymageName.HeaderText = "Image Name"
        Me.colPathologymageName.Name = "colPathologymageName"
        Me.colPathologymageName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPathologymageName.Width = 210
        '
        'colPathologyImagesSaved
        '
        Me.colPathologyImagesSaved.ControlCaption = Nothing
        Me.colPathologyImagesSaved.HeaderText = "Saved"
        Me.colPathologyImagesSaved.Name = "colPathologyImagesSaved"
        Me.colPathologyImagesSaved.ReadOnly = True
        Me.colPathologyImagesSaved.SourceColumn = Nothing
        '
        'frmPathologyReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(887, 501)
        Me.Controls.Add(Me.dtpExamDateTime)
        Me.Controls.Add(Me.tbcPathologyReport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintExamReportOnSaving)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.btnViewTemplates)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.cboExamFullName)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.stbIndication)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblIndication)
        Me.Controls.Add(Me.lblExamFullName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.cboReportTypeID)
        Me.Controls.Add(Me.lblReportTypeID)
        Me.Controls.Add(Me.cboPathologist)
        Me.Controls.Add(Me.lblPathologist)
        Me.Controls.Add(Me.cboPathologyTitleID)
        Me.Controls.Add(Me.lblPathologyTitleID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPathologyReports"
        Me.Text = "Pathology Reports"
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.tbcPathologyReport.ResumeLayout(False)
        Me.tpgPathologyDiagnosis.ResumeLayout(False)
        Me.tpgPathologyDiagnosis.PerformLayout()
        Me.tpgPathologyImages.ResumeLayout(False)
        CType(Me.dgvPathologyImages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboReportTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReportTypeID As System.Windows.Forms.Label
    Friend WithEvents cboPathologist As System.Windows.Forms.ComboBox
    Friend WithEvents lblPathologist As System.Windows.Forms.Label
    Friend WithEvents cboPathologyTitleID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPathologyTitleID As System.Windows.Forms.Label
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents btnViewTemplates As System.Windows.Forms.Button
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents btnLoadProcessingPathology As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbUnitPrice As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents cboExamFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbIndication As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblIndication As System.Windows.Forms.Label
    Friend WithEvents lblExamFullName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkPrintExamReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents tbcPathologyReport As System.Windows.Forms.TabControl
    Friend WithEvents tpgPathologyDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents tpgPathologyImages As System.Windows.Forms.TabPage
    Friend WithEvents dgvPathologyImages As System.Windows.Forms.DataGridView
    Friend WithEvents colSelectImage As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colPathologyImage As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents colPathologymageName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyImagesSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents dtpExamDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMicroscopic As System.Windows.Forms.Label
    Friend WithEvents lblmacroscopic As System.Windows.Forms.Label
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents stbMacroscopic As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbMicroscopic As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox

End Class