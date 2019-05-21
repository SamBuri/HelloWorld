<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPathologyRequests
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPathologyRequests))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadPathologyToVisits = New System.Windows.Forms.Button()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForPathology = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForPathology = New System.Windows.Forms.Label()
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintPathologyRequestOnSaving = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPathologyRequests = New System.Windows.Forms.DataGridView()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExamCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyExamination = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIndication = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBill.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        CType(Me.dgvPathologyRequests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(446, 55)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbMemberCardNo.Size = New System.Drawing.Size(139, 20)
        Me.stbMemberCardNo.TabIndex = 47
        Me.stbMemberCardNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbMemberCardNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(334, 55)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(106, 20)
        Me.lblMemberCardNo.TabIndex = 46
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(331, 99)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(180, 20)
        Me.chkSmartCardApplicable.TabIndex = 58
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(147, 14)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitNo.TabIndex = 32
        Me.stbVisitNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'btnLoadPathologyToVisits
        '
        Me.btnLoadPathologyToVisits.AccessibleDescription = ""
        Me.btnLoadPathologyToVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPathologyToVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPathologyToVisits.Location = New System.Drawing.Point(268, 11)
        Me.btnLoadPathologyToVisits.Name = "btnLoadPathologyToVisits"
        Me.btnLoadPathologyToVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPathologyToVisits.TabIndex = 33
        Me.btnLoadPathologyToVisits.Tag = ""
        Me.btnLoadPathologyToVisits.Text = "&Load"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(446, 34)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(139, 20)
        Me.stbPrimaryDoctor.TabIndex = 45
        Me.stbPrimaryDoctor.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPrimaryDoctor.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(334, 33)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(106, 20)
        Me.lblPrimaryDoctor.TabIndex = 44
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.btnFindByFingerprint)
        Me.pnlBill.Controls.Add(Me.pnlAlerts)
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForPathology)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForPathology)
        Me.pnlBill.Location = New System.Drawing.Point(10, 127)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(794, 70)
        Me.pnlBill.TabIndex = 59
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(659, 41)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 5
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(3, 27)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(427, 34)
        Me.pnlAlerts.TabIndex = 4
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(326, 6)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(63, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(1, 8)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(305, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Pathology Requests: 0"
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(325, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(103, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForPathology
        '
        Me.stbBillForPathology.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForPathology.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForPathology.CapitalizeFirstLetter = False
        Me.stbBillForPathology.Enabled = False
        Me.stbBillForPathology.EntryErrorMSG = ""
        Me.stbBillForPathology.Location = New System.Drawing.Point(137, 4)
        Me.stbBillForPathology.MaxLength = 20
        Me.stbBillForPathology.Name = "stbBillForPathology"
        Me.stbBillForPathology.RegularExpression = ""
        Me.stbBillForPathology.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillForPathology.Size = New System.Drawing.Size(169, 20)
        Me.stbBillForPathology.TabIndex = 1
        Me.stbBillForPathology.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.stbBillForPathology.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillForPathology.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(436, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(345, 35)
        Me.stbBillWords.TabIndex = 3
        Me.stbBillWords.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillWords.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillForPathology
        '
        Me.lblBillForPathology.Location = New System.Drawing.Point(3, 6)
        Me.lblBillForPathology.Name = "lblBillForPathology"
        Me.lblBillForPathology.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForPathology.TabIndex = 0
        Me.lblBillForPathology.Text = "Bill for Pathology"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(114, 14)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 31
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(147, 36)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(169, 20)
        Me.stbVisitDate.TabIndex = 35
        Me.stbVisitDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(11, 36)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(89, 20)
        Me.lblVisitDate.TabIndex = 34
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(147, 57)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 37
        Me.stbFullName.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbFullName.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(11, 57)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(89, 20)
        Me.lblFullName.TabIndex = 36
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(147, 78)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPatientNo.Size = New System.Drawing.Size(169, 20)
        Me.stbPatientNo.TabIndex = 39
        Me.stbPatientNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPatientNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(11, 78)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(89, 20)
        Me.lblPatientsNo.TabIndex = 38
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(446, 76)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(139, 20)
        Me.stbBillMode.TabIndex = 49
        Me.stbBillMode.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillMode.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(446, 13)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(139, 20)
        Me.stbVisitCategory.TabIndex = 43
        Me.stbVisitCategory.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitCategory.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(334, 78)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(106, 20)
        Me.lblBillMode.TabIndex = 48
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(334, 12)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(106, 20)
        Me.lblVisitCategory.TabIndex = 42
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(669, 33)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(122, 20)
        Me.stbStatus.TabIndex = 53
        Me.stbStatus.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbStatus.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(591, 33)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(72, 20)
        Me.lblStatus.TabIndex = 52
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(147, 99)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(169, 20)
        Me.stbBillNo.TabIndex = 41
        Me.stbBillNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(669, 12)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(122, 20)
        Me.stbAge.TabIndex = 51
        Me.stbAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbAge.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(669, 75)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(122, 20)
        Me.stbJoinDate.TabIndex = 57
        Me.stbJoinDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbJoinDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(669, 54)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(122, 20)
        Me.stbGender.TabIndex = 55
        Me.stbGender.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbGender.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(591, 78)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(72, 20)
        Me.lblJoinDate.TabIndex = 56
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(11, 99)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(89, 20)
        Me.lblBillNo.TabIndex = 40
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(591, 11)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(72, 20)
        Me.lblAge.TabIndex = 50
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(591, 55)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(72, 20)
        Me.lblGenderID.TabIndex = 54
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(11, 14)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(89, 20)
        Me.lblVisitNo.TabIndex = 30
        Me.lblVisitNo.Text = "Visit No."
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(21, 423)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 61
        Me.btnSave.Tag = "ClinicalFindings"
        Me.btnSave.Text = "&Save"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(648, 423)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 63
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintPathologyRequestOnSaving
        '
        Me.chkPrintPathologyRequestOnSaving.AccessibleDescription = ""
        Me.chkPrintPathologyRequestOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintPathologyRequestOnSaving.AutoSize = True
        Me.chkPrintPathologyRequestOnSaving.Checked = True
        Me.chkPrintPathologyRequestOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintPathologyRequestOnSaving.Location = New System.Drawing.Point(99, 430)
        Me.chkPrintPathologyRequestOnSaving.Name = "chkPrintPathologyRequestOnSaving"
        Me.chkPrintPathologyRequestOnSaving.Size = New System.Drawing.Size(196, 17)
        Me.chkPrintPathologyRequestOnSaving.TabIndex = 62
        Me.chkPrintPathologyRequestOnSaving.Text = " Print Pathology Request On Saving"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(726, 423)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 64
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPathologyRequests
        '
        Me.dgvPathologyRequests.AllowUserToAddRows = False
        Me.dgvPathologyRequests.AllowUserToDeleteRows = False
        Me.dgvPathologyRequests.AllowUserToOrderColumns = True
        Me.dgvPathologyRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPathologyRequests.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPathologyRequests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPathologyRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPathologyRequests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPathologyRequests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colExamCode, Me.colPathologyExamination, Me.colIndication, Me.colCategory, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colPayStatus})
        Me.dgvPathologyRequests.EnableHeadersVisualStyles = False
        Me.dgvPathologyRequests.GridColor = System.Drawing.Color.Khaki
        Me.dgvPathologyRequests.Location = New System.Drawing.Point(16, 207)
        Me.dgvPathologyRequests.Name = "dgvPathologyRequests"
        Me.dgvPathologyRequests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPathologyRequests.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPathologyRequests.RowHeadersVisible = False
        Me.dgvPathologyRequests.Size = New System.Drawing.Size(781, 210)
        Me.dgvPathologyRequests.TabIndex = 60
        Me.dgvPathologyRequests.Text = "DataGridView1"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colExamCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colExamCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExamCode.HeaderText = "Exam Code"
        Me.colExamCode.Name = "colExamCode"
        Me.colExamCode.ReadOnly = True
        Me.colExamCode.Width = 70
        '
        'colPathologyExamination
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colPathologyExamination.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPathologyExamination.HeaderText = "Pathology Examination"
        Me.colPathologyExamination.Name = "colPathologyExamination"
        Me.colPathologyExamination.ReadOnly = True
        Me.colPathologyExamination.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPathologyExamination.Width = 140
        '
        'colIndication
        '
        Me.colIndication.HeaderText = "Indication"
        Me.colIndication.MaxInputLength = 200
        Me.colIndication.Name = "colIndication"
        Me.colIndication.Width = 150
        '
        'colCategory
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 75
        '
        'colQuantity
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
        '
        'colAmount
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 80
        '
        'colPayStatus
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'frmPathologyRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 460)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintPathologyRequestOnSaving)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvPathologyRequests)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.btnLoadPathologyToVisits)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.btnFindVisitNo)
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
        Me.Controls.Add(Me.lblVisitNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPathologyRequests"
        Me.Text = "Pathology Requests"
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        CType(Me.dgvPathologyRequests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadPathologyToVisits As System.Windows.Forms.Button
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForPathology As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForPathology As System.Windows.Forms.Label
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
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintPathologyRequestOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPathologyRequests As System.Windows.Forms.DataGridView
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExamCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyExamination As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIndication As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
