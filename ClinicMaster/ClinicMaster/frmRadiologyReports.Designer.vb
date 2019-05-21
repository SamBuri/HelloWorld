
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRadiologyReports : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRadiologyReports))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpExamDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbConclusion = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboRadiologist = New System.Windows.Forms.ComboBox()
        Me.stbIndication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboRadiologyTitleID = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblExamFullName = New System.Windows.Forms.Label()
        Me.lblExamDateTime = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.lblConclusion = New System.Windows.Forms.Label()
        Me.lblRadiologist = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
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
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintExamReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.cboExamFullName = New System.Windows.Forms.ComboBox()
        Me.stbUnitPrice = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.btnLoadProcessingRadiology = New System.Windows.Forms.Button()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.btnViewTemplates = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.lblRadiologyTitleID = New System.Windows.Forms.Label()
        Me.stbPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.pnlVisitNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(11, 395)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 46
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.Enabled = False
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(791, 394)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 51
        Me.fbnDelete.Tag = "RadiologyReports"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 422)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 47
        Me.ebnSaveUpdate.Tag = "RadiologyReports"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpExamDateTime
        '
        Me.dtpExamDateTime.Checked = False
        Me.dtpExamDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExamDateTime, "ExamDateTime")
        Me.dtpExamDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExamDateTime.Location = New System.Drawing.Point(152, 109)
        Me.dtpExamDateTime.Name = "dtpExamDateTime"
        Me.dtpExamDateTime.ShowCheckBox = True
        Me.dtpExamDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpExamDateTime.TabIndex = 8
        '
        'stbReport
        '
        Me.stbReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReport, "Report")
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(152, 183)
        Me.stbReport.MaxLength = 4000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.RegularExpression = ""
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(711, 144)
        Me.stbReport.TabIndex = 43
        '
        'stbConclusion
        '
        Me.stbConclusion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbConclusion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConclusion.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbConclusion, "Conclusion")
        Me.stbConclusion.EntryErrorMSG = ""
        Me.stbConclusion.Location = New System.Drawing.Point(152, 328)
        Me.stbConclusion.MaxLength = 4000
        Me.stbConclusion.Multiline = True
        Me.stbConclusion.Name = "stbConclusion"
        Me.stbConclusion.RegularExpression = ""
        Me.stbConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbConclusion.Size = New System.Drawing.Size(711, 60)
        Me.stbConclusion.TabIndex = 45
        '
        'cboRadiologist
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboRadiologist, "RadiologistFullName")
        Me.cboRadiologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRadiologist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRadiologist.Location = New System.Drawing.Point(152, 130)
        Me.cboRadiologist.Name = "cboRadiologist"
        Me.cboRadiologist.Size = New System.Drawing.Size(170, 21)
        Me.cboRadiologist.TabIndex = 10
        '
        'stbIndication
        '
        Me.stbIndication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIndication.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbIndication, "Indication")
        Me.stbIndication.EntryErrorMSG = ""
        Me.stbIndication.Location = New System.Drawing.Point(152, 59)
        Me.stbIndication.MaxLength = 4000
        Me.stbIndication.Multiline = True
        Me.stbIndication.Name = "stbIndication"
        Me.stbIndication.RegularExpression = ""
        Me.stbIndication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbIndication.Size = New System.Drawing.Size(170, 28)
        Me.stbIndication.TabIndex = 4
        '
        'cboRadiologyTitleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboRadiologyTitleID, "RadiologyTitle,RadiologyTitleID")
        Me.cboRadiologyTitleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRadiologyTitleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRadiologyTitleID.Location = New System.Drawing.Point(152, 154)
        Me.cboRadiologyTitleID.Name = "cboRadiologyTitleID"
        Me.cboRadiologyTitleID.Size = New System.Drawing.Size(170, 21)
        Me.cboRadiologyTitleID.TabIndex = 12
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
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(791, 421)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 52
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblExamFullName
        '
        Me.lblExamFullName.Location = New System.Drawing.Point(11, 36)
        Me.lblExamFullName.Name = "lblExamFullName"
        Me.lblExamFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblExamFullName.TabIndex = 1
        Me.lblExamFullName.Text = "Radiology Examination"
        '
        'lblExamDateTime
        '
        Me.lblExamDateTime.Location = New System.Drawing.Point(11, 112)
        Me.lblExamDateTime.Name = "lblExamDateTime"
        Me.lblExamDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblExamDateTime.TabIndex = 7
        Me.lblExamDateTime.Text = "Exam Date Time"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 241)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 42
        Me.lblReport.Text = "Report"
        '
        'lblConclusion
        '
        Me.lblConclusion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConclusion.Location = New System.Drawing.Point(11, 343)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(123, 20)
        Me.lblConclusion.TabIndex = 44
        Me.lblConclusion.Text = "Conclusion"
        '
        'lblRadiologist
        '
        Me.lblRadiologist.Location = New System.Drawing.Point(11, 134)
        Me.lblRadiologist.Name = "lblRadiologist"
        Me.lblRadiologist.Size = New System.Drawing.Size(123, 20)
        Me.lblRadiologist.TabIndex = 9
        Me.lblRadiologist.Text = "Radiologist"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(451, 73)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(126, 20)
        Me.stbPrimaryDoctor.TabIndex = 20
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(337, 72)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(108, 20)
        Me.lblPrimaryDoctor.TabIndex = 19
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
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
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(451, 136)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitDate.TabIndex = 26
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(337, 136)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 25
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(451, 157)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(126, 20)
        Me.stbFullName.TabIndex = 28
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(337, 157)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(108, 20)
        Me.lblFullName.TabIndex = 27
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(451, 10)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(126, 20)
        Me.stbPatientNo.TabIndex = 14
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(337, 10)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(108, 20)
        Me.lblPatientsNo.TabIndex = 13
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(720, 47)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(143, 20)
        Me.stbBillMode.TabIndex = 32
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(451, 52)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitCategory.TabIndex = 18
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(596, 47)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(118, 20)
        Me.lblBillMode.TabIndex = 31
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(337, 51)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCategory.TabIndex = 17
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(451, 115)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(126, 20)
        Me.stbStatus.TabIndex = 24
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(337, 115)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 20)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(451, 31)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(126, 20)
        Me.stbBillNo.TabIndex = 16
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(451, 94)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(126, 20)
        Me.stbAge.TabIndex = 22
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(720, 68)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(143, 20)
        Me.stbJoinDate.TabIndex = 34
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(720, 5)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(143, 20)
        Me.stbGender.TabIndex = 30
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(596, 68)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(118, 20)
        Me.lblJoinDate.TabIndex = 33
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(337, 31)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(108, 20)
        Me.lblBillNo.TabIndex = 15
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(337, 94)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 21
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(596, 5)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(118, 20)
        Me.lblGenderID.TabIndex = 29
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(11, 7)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(89, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'lblIndication
        '
        Me.lblIndication.Location = New System.Drawing.Point(11, 63)
        Me.lblIndication.Name = "lblIndication"
        Me.lblIndication.Size = New System.Drawing.Size(123, 20)
        Me.lblIndication.TabIndex = 3
        Me.lblIndication.Text = "Indication"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(707, 421)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 50
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintExamReportOnSaving
        '
        Me.chkPrintExamReportOnSaving.AccessibleDescription = ""
        Me.chkPrintExamReportOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintExamReportOnSaving.AutoSize = True
        Me.chkPrintExamReportOnSaving.Location = New System.Drawing.Point(94, 430)
        Me.chkPrintExamReportOnSaving.Name = "chkPrintExamReportOnSaving"
        Me.chkPrintExamReportOnSaving.Size = New System.Drawing.Size(167, 17)
        Me.chkPrintExamReportOnSaving.TabIndex = 48
        Me.chkPrintExamReportOnSaving.Text = " Print Exam Report On Saving"
        '
        'cboExamFullName
        '
        Me.cboExamFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboExamFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExamFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamFullName.DropDownWidth = 214
        Me.cboExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExamFullName.FormattingEnabled = True
        Me.cboExamFullName.Location = New System.Drawing.Point(152, 36)
        Me.cboExamFullName.Name = "cboExamFullName"
        Me.cboExamFullName.Size = New System.Drawing.Size(170, 21)
        Me.cboExamFullName.Sorted = True
        Me.cboExamFullName.TabIndex = 2
        '
        'stbUnitPrice
        '
        Me.stbUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.stbUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitPrice.CapitalizeFirstLetter = False
        Me.stbUnitPrice.Enabled = False
        Me.stbUnitPrice.EntryErrorMSG = ""
        Me.stbUnitPrice.Location = New System.Drawing.Point(152, 88)
        Me.stbUnitPrice.MaxLength = 20
        Me.stbUnitPrice.Name = "stbUnitPrice"
        Me.stbUnitPrice.RegularExpression = ""
        Me.stbUnitPrice.Size = New System.Drawing.Size(170, 20)
        Me.stbUnitPrice.TabIndex = 6
        Me.stbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(11, 88)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(123, 20)
        Me.lblUnitPrice.TabIndex = 5
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'btnLoadProcessingRadiology
        '
        Me.btnLoadProcessingRadiology.AccessibleDescription = ""
        Me.btnLoadProcessingRadiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadProcessingRadiology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadProcessingRadiology.Location = New System.Drawing.Point(272, 3)
        Me.btnLoadProcessingRadiology.Name = "btnLoadProcessingRadiology"
        Me.btnLoadProcessingRadiology.Size = New System.Drawing.Size(45, 24)
        Me.btnLoadProcessingRadiology.TabIndex = 3
        Me.btnLoadProcessingRadiology.Tag = ""
        Me.btnLoadProcessingRadiology.Text = "&Load"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(720, 89)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(143, 29)
        Me.stbBillCustomerName.TabIndex = 36
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(596, 93)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(118, 20)
        Me.lblBillCustomerName.TabIndex = 35
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.btnLoadProcessingRadiology)
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.lblVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnFindVisitNo)
        Me.pnlVisitNo.Location = New System.Drawing.Point(5, 1)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(326, 31)
        Me.pnlVisitNo.TabIndex = 0
        '
        'btnViewTemplates
        '
        Me.btnViewTemplates.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTemplates.Location = New System.Drawing.Point(593, 152)
        Me.btnViewTemplates.Name = "btnViewTemplates"
        Me.btnViewTemplates.Size = New System.Drawing.Size(117, 24)
        Me.btnViewTemplates.TabIndex = 40
        Me.btnViewTemplates.Tag = ""
        Me.btnViewTemplates.Text = "&View Templates"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(742, 153)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 41
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(720, 119)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(143, 20)
        Me.stbMemberCardNo.TabIndex = 38
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(596, 119)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(118, 20)
        Me.lblMemberCardNo.TabIndex = 37
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'lblRadiologyTitleID
        '
        Me.lblRadiologyTitleID.Location = New System.Drawing.Point(11, 154)
        Me.lblRadiologyTitleID.Name = "lblRadiologyTitleID"
        Me.lblRadiologyTitleID.Size = New System.Drawing.Size(123, 20)
        Me.lblRadiologyTitleID.TabIndex = 11
        Me.lblRadiologyTitleID.Text = "Radiology Title"
        '
        'stbPhoneNo
        '
        Me.stbPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneNo.CapitalizeFirstLetter = False
        Me.stbPhoneNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPhoneNo.Enabled = False
        Me.stbPhoneNo.EntryErrorMSG = ""
        Me.stbPhoneNo.Location = New System.Drawing.Point(720, 26)
        Me.stbPhoneNo.MaxLength = 7
        Me.stbPhoneNo.Name = "stbPhoneNo"
        Me.stbPhoneNo.RegularExpression = ""
        Me.stbPhoneNo.Size = New System.Drawing.Size(143, 20)
        Me.stbPhoneNo.TabIndex = 54
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(596, 26)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(118, 20)
        Me.lblPhoneNo.TabIndex = 53
        Me.lblPhoneNo.Text = "Phone No."
        '
        'frmRadiologyReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(884, 461)
        Me.Controls.Add(Me.stbPhoneNo)
        Me.Controls.Add(Me.lblPhoneNo)
        Me.Controls.Add(Me.cboRadiologyTitleID)
        Me.Controls.Add(Me.lblRadiologyTitleID)
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
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintExamReportOnSaving)
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
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblExamFullName)
        Me.Controls.Add(Me.dtpExamDateTime)
        Me.Controls.Add(Me.lblExamDateTime)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.stbConclusion)
        Me.Controls.Add(Me.lblConclusion)
        Me.Controls.Add(Me.cboRadiologist)
        Me.Controls.Add(Me.lblRadiologist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmRadiologyReports"
        Me.Text = "Radiology Reports"
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblExamFullName As System.Windows.Forms.Label
    Friend WithEvents dtpExamDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExamDateTime As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents stbConclusion As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConclusion As System.Windows.Forms.Label
    Friend WithEvents cboRadiologist As System.Windows.Forms.ComboBox
    Friend WithEvents lblRadiologist As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbIndication As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
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
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents lblIndication As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintExamReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cboExamFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbUnitPrice As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnLoadProcessingRadiology As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents btnViewTemplates As System.Windows.Forms.Button
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents cboRadiologyTitleID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRadiologyTitleID As System.Windows.Forms.Label
    Friend WithEvents stbPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label

End Class