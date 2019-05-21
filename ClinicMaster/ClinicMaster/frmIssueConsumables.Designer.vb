
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIssueConsumables : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIssueConsumables))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbCashAccountBalance = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblBillNumber = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsConsumables = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsConsumablesCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsConsumablesSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsConsumablesInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsConsumablesEditConsumables = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsConsumablesRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnLoadToIssueConsumables = New System.Windows.Forms.Button()
        Me.pnlConsumables = New System.Windows.Forms.Panel()
        Me.btnViewToExpireConsumablesList = New System.Windows.Forms.Button()
        Me.lblToExpireConsumables = New System.Windows.Forms.Label()
        Me.btnViewToOrderConsumablesList = New System.Windows.Forms.Button()
        Me.lblToOrderConsumables = New System.Windows.Forms.Label()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.chkPrintDrugBarcode = New System.Windows.Forms.CheckBox()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsConsumables.SuspendLayout()
        Me.pnlConsumables.SuspendLayout()
        Me.pnlNavigateVisits.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(841, 460)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 48
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(135, 6)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(81, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(10, 6)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(70, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(91, 6)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(13, 460)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 46
        Me.btnSave.TabStop = False
        Me.btnSave.Tag = "IssueConsumables"
        Me.btnSave.Text = "&Save"
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(135, 114)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(131, 20)
        Me.nbxOutstandingBalance.TabIndex = 13
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(10, 115)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(119, 20)
        Me.lblOutstandingBalance.TabIndex = 12
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbCashAccountBalance
        '
        Me.stbCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCashAccountBalance.CapitalizeFirstLetter = False
        Me.stbCashAccountBalance.EntryErrorMSG = ""
        Me.stbCashAccountBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.stbCashAccountBalance.Location = New System.Drawing.Point(400, 66)
        Me.stbCashAccountBalance.MaxLength = 20
        Me.stbCashAccountBalance.Name = "stbCashAccountBalance"
        Me.stbCashAccountBalance.ReadOnly = True
        Me.stbCashAccountBalance.RegularExpression = ""
        Me.stbCashAccountBalance.Size = New System.Drawing.Size(138, 20)
        Me.stbCashAccountBalance.TabIndex = 25
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(272, 69)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(122, 20)
        Me.lblCashAccountBalance.TabIndex = 24
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(400, 87)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(138, 42)
        Me.stbBillCustomerName.TabIndex = 27
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(272, 94)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(122, 20)
        Me.lblBillCustomerName.TabIndex = 26
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(400, 151)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(138, 20)
        Me.stbTotalVisits.TabIndex = 31
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(272, 152)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(122, 20)
        Me.lblTotalVisits.TabIndex = 30
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(762, 3)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 74
        Me.spbPhoto.TabStop = False
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(135, 93)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(131, 20)
        Me.stbVisitDate.TabIndex = 11
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(135, 72)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(131, 20)
        Me.stbPatientNo.TabIndex = 9
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(10, 72)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(119, 20)
        Me.lblPatientsNo.TabIndex = 8
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(660, 66)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(96, 20)
        Me.stbBillMode.TabIndex = 39
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(544, 68)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(110, 18)
        Me.lblBillMode.TabIndex = 38
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(660, 24)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(96, 20)
        Me.stbStatus.TabIndex = 35
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(544, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(110, 18)
        Me.lblStatus.TabIndex = 34
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(400, 3)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(138, 20)
        Me.stbBillNo.TabIndex = 19
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(660, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(96, 20)
        Me.stbAge.TabIndex = 33
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(400, 45)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(138, 20)
        Me.stbJoinDate.TabIndex = 23
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(660, 45)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(96, 20)
        Me.stbGender.TabIndex = 37
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(272, 48)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(122, 20)
        Me.lblJoinDate.TabIndex = 22
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNumber
        '
        Me.lblBillNumber.Location = New System.Drawing.Point(272, 3)
        Me.lblBillNumber.Name = "lblBillNumber"
        Me.lblBillNumber.Size = New System.Drawing.Size(122, 20)
        Me.lblBillNumber.TabIndex = 18
        Me.lblBillNumber.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(544, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(110, 18)
        Me.lblAge.TabIndex = 32
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(544, 45)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(110, 18)
        Me.lblGenderID.TabIndex = 36
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(10, 93)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(119, 20)
        Me.lblVisitDate.TabIndex = 10
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(135, 28)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(131, 20)
        Me.stbFullName.TabIndex = 5
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(10, 28)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(119, 20)
        Me.lblFullName.TabIndex = 4
        Me.lblFullName.Text = "Patient's Name"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(2, 205)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(917, 43)
        Me.pnlBill.TabIndex = 44
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(271, 3)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(107, 20)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(133, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(131, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(398, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(510, 36)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(8, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(111, 20)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Consumables"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(5, 53)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(367, 35)
        Me.pnlAlerts.TabIndex = 4
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(291, 5)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(72, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(5, 9)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(213, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Sent Consumables: 0"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(9, 177)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(124, 23)
        Me.btnFindByFingerprint.TabIndex = 5
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToAddRows = False
        Me.dgvConsumables.AllowUserToDeleteRows = False
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colConsumableNo, Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitMeasure, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumablePayStatus, Me.colConsumableLocationBalance, Me.colConsumableUnitsInStock, Me.colConsumableExpiryDate, Me.colConsumableOrderLevel, Me.colCashAmount, Me.colCashPayStatus, Me.colConsumableAlternateName})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsConsumables
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(13, 248)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvConsumables.RowHeadersVisible = False
        Me.dgvConsumables.Size = New System.Drawing.Size(900, 186)
        Me.dgvConsumables.TabIndex = 45
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colConsumableNo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colConsumableNo.HeaderText = "Consumable No"
        Me.colConsumableNo.MaxInputLength = 20
        Me.colConsumableNo.Name = "colConsumableNo"
        Me.colConsumableNo.ReadOnly = True
        Me.colConsumableNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colConsumableName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Width = 120
        '
        'colConsumableNotes
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNotes.DefaultCellStyle = DataGridViewCellStyle4
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.ReadOnly = True
        '
        'colConsumableQuantity
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.ReadOnly = True
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitMeasure
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitMeasure.DefaultCellStyle = DataGridViewCellStyle6
        Me.colConsumableUnitMeasure.HeaderText = "Unit Measure"
        Me.colConsumableUnitMeasure.Name = "colConsumableUnitMeasure"
        Me.colConsumableUnitMeasure.ReadOnly = True
        Me.colConsumableUnitMeasure.Width = 80
        '
        'colConsumableUnitPrice
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'colConsumablePayStatus
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablePayStatus.DefaultCellStyle = DataGridViewCellStyle9
        Me.colConsumablePayStatus.HeaderText = "Pay Status"
        Me.colConsumablePayStatus.Name = "colConsumablePayStatus"
        Me.colConsumablePayStatus.ReadOnly = True
        Me.colConsumablePayStatus.Width = 70
        '
        'colConsumableLocationBalance
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableLocationBalance.DefaultCellStyle = DataGridViewCellStyle10
        Me.colConsumableLocationBalance.HeaderText = "Location Balance"
        Me.colConsumableLocationBalance.Name = "colConsumableLocationBalance"
        Me.colConsumableLocationBalance.ReadOnly = True
        '
        'colConsumableUnitsInStock
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitsInStock.DefaultCellStyle = DataGridViewCellStyle11
        Me.colConsumableUnitsInStock.HeaderText = "Units In Stock"
        Me.colConsumableUnitsInStock.Name = "colConsumableUnitsInStock"
        Me.colConsumableUnitsInStock.ReadOnly = True
        Me.colConsumableUnitsInStock.Width = 80
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        Me.colConsumableExpiryDate.Width = 80
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        Me.colConsumableOrderLevel.Width = 70
        '
        'colCashAmount
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.Format = "N2"
        Me.colCashAmount.DefaultCellStyle = DataGridViewCellStyle14
        Me.colCashAmount.HeaderText = "Cash Co-Pay Amount"
        Me.colCashAmount.Name = "colCashAmount"
        Me.colCashAmount.ReadOnly = True
        Me.colCashAmount.Width = 120
        '
        'colCashPayStatus
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colCashPayStatus.DefaultCellStyle = DataGridViewCellStyle15
        Me.colCashPayStatus.HeaderText = "Cash Pay Status"
        Me.colCashPayStatus.Name = "colCashPayStatus"
        Me.colCashPayStatus.ReadOnly = True
        Me.colCashPayStatus.Width = 110
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumableAlternateName.HeaderText = "Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 90
        '
        'cmsConsumables
        '
        Me.cmsConsumables.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsConsumables.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsConsumablesCopy, Me.cmsConsumablesSelectAll, Me.cmsConsumablesInventory, Me.cmsConsumablesEditConsumables, Me.ToolStripSeparator1, Me.cmsConsumablesRefresh})
        Me.cmsConsumables.Name = "cmsSearch"
        Me.cmsConsumables.Size = New System.Drawing.Size(170, 120)
        '
        'cmsConsumablesCopy
        '
        Me.cmsConsumablesCopy.Enabled = False
        Me.cmsConsumablesCopy.Image = CType(resources.GetObject("cmsConsumablesCopy.Image"), System.Drawing.Image)
        Me.cmsConsumablesCopy.Name = "cmsConsumablesCopy"
        Me.cmsConsumablesCopy.Size = New System.Drawing.Size(169, 22)
        Me.cmsConsumablesCopy.Text = "Copy"
        Me.cmsConsumablesCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsConsumablesSelectAll
        '
        Me.cmsConsumablesSelectAll.Enabled = False
        Me.cmsConsumablesSelectAll.Name = "cmsConsumablesSelectAll"
        Me.cmsConsumablesSelectAll.Size = New System.Drawing.Size(169, 22)
        Me.cmsConsumablesSelectAll.Text = "Select All"
        '
        'cmsConsumablesInventory
        '
        Me.cmsConsumablesInventory.Enabled = False
        Me.cmsConsumablesInventory.Image = CType(resources.GetObject("cmsConsumablesInventory.Image"), System.Drawing.Image)
        Me.cmsConsumablesInventory.Name = "cmsConsumablesInventory"
        Me.cmsConsumablesInventory.Size = New System.Drawing.Size(169, 22)
        Me.cmsConsumablesInventory.Tag = "ConsumableInventory"
        Me.cmsConsumablesInventory.Text = "Go to Inventory"
        '
        'cmsConsumablesEditConsumables
        '
        Me.cmsConsumablesEditConsumables.Enabled = False
        Me.cmsConsumablesEditConsumables.Image = CType(resources.GetObject("cmsConsumablesEditConsumables.Image"), System.Drawing.Image)
        Me.cmsConsumablesEditConsumables.Name = "cmsConsumablesEditConsumables"
        Me.cmsConsumablesEditConsumables.Size = New System.Drawing.Size(169, 22)
        Me.cmsConsumablesEditConsumables.Tag = "Consumables"
        Me.cmsConsumablesEditConsumables.Text = "Edit Consumables"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        'cmsConsumablesRefresh
        '
        Me.cmsConsumablesRefresh.Enabled = False
        Me.cmsConsumablesRefresh.Image = CType(resources.GetObject("cmsConsumablesRefresh.Image"), System.Drawing.Image)
        Me.cmsConsumablesRefresh.Name = "cmsConsumablesRefresh"
        Me.cmsConsumablesRefresh.Size = New System.Drawing.Size(169, 22)
        Me.cmsConsumablesRefresh.Text = "Refresh"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(400, 130)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(138, 20)
        Me.nbxCoPayValue.TabIndex = 29
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(272, 131)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(122, 20)
        Me.lblCoPayValue.TabIndex = 28
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(135, 156)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(131, 20)
        Me.nbxCoPayPercent.TabIndex = 17
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(10, 157)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(119, 20)
        Me.lblCoPayPercent.TabIndex = 16
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(135, 135)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(131, 20)
        Me.stbCoPayType.TabIndex = 15
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(10, 135)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(119, 20)
        Me.lblCoPayType.TabIndex = 14
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(400, 24)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(138, 20)
        Me.stbPrimaryDoctor.TabIndex = 21
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(272, 26)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(122, 20)
        Me.lblPrimaryDoctor.TabIndex = 20
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'btnLoadToIssueConsumables
        '
        Me.btnLoadToIssueConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadToIssueConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadToIssueConsumables.Location = New System.Drawing.Point(222, 3)
        Me.btnLoadToIssueConsumables.Name = "btnLoadToIssueConsumables"
        Me.btnLoadToIssueConsumables.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadToIssueConsumables.TabIndex = 3
        Me.btnLoadToIssueConsumables.Tag = ""
        Me.btnLoadToIssueConsumables.Text = "&Load"
        '
        'pnlConsumables
        '
        Me.pnlConsumables.Controls.Add(Me.pnlAlerts)
        Me.pnlConsumables.Controls.Add(Me.btnViewToExpireConsumablesList)
        Me.pnlConsumables.Controls.Add(Me.lblToExpireConsumables)
        Me.pnlConsumables.Controls.Add(Me.btnViewToOrderConsumablesList)
        Me.pnlConsumables.Controls.Add(Me.lblToOrderConsumables)
        Me.pnlConsumables.Location = New System.Drawing.Point(544, 115)
        Me.pnlConsumables.Name = "pnlConsumables"
        Me.pnlConsumables.Size = New System.Drawing.Size(378, 91)
        Me.pnlConsumables.TabIndex = 43
        '
        'btnViewToExpireConsumablesList
        '
        Me.btnViewToExpireConsumablesList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireConsumablesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireConsumablesList.Location = New System.Drawing.Point(300, 28)
        Me.btnViewToExpireConsumablesList.Name = "btnViewToExpireConsumablesList"
        Me.btnViewToExpireConsumablesList.Size = New System.Drawing.Size(72, 24)
        Me.btnViewToExpireConsumablesList.TabIndex = 3
        Me.btnViewToExpireConsumablesList.Tag = ""
        Me.btnViewToExpireConsumablesList.Text = "&View List"
        '
        'lblToExpireConsumables
        '
        Me.lblToExpireConsumables.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToExpireConsumables.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireConsumables.Location = New System.Drawing.Point(3, 29)
        Me.lblToExpireConsumables.Name = "lblToExpireConsumables"
        Me.lblToExpireConsumables.Size = New System.Drawing.Size(291, 20)
        Me.lblToExpireConsumables.TabIndex = 2
        Me.lblToExpireConsumables.Text = "To Expire/Expired Consumables: 0"
        '
        'btnViewToOrderConsumablesList
        '
        Me.btnViewToOrderConsumablesList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderConsumablesList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderConsumablesList.Location = New System.Drawing.Point(300, 3)
        Me.btnViewToOrderConsumablesList.Name = "btnViewToOrderConsumablesList"
        Me.btnViewToOrderConsumablesList.Size = New System.Drawing.Size(72, 24)
        Me.btnViewToOrderConsumablesList.TabIndex = 1
        Me.btnViewToOrderConsumablesList.Tag = ""
        Me.btnViewToOrderConsumablesList.Text = "&View List"
        '
        'lblToOrderConsumables
        '
        Me.lblToOrderConsumables.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToOrderConsumables.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderConsumables.Location = New System.Drawing.Point(3, 6)
        Me.lblToOrderConsumables.Name = "lblToOrderConsumables"
        Me.lblToOrderConsumables.Size = New System.Drawing.Size(291, 20)
        Me.lblToOrderConsumables.TabIndex = 0
        Me.lblToOrderConsumables.Text = "To Order Consumables: 0"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(135, 49)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(131, 21)
        Me.cboLocationID.TabIndex = 7
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(10, 50)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblLocationID.TabIndex = 6
        Me.lblLocationID.Text = "Location"
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(762, 93)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(149, 20)
        Me.chkSmartCardApplicable.TabIndex = 42
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(660, 87)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.ReadOnly = True
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(96, 20)
        Me.stbMemberCardNo.TabIndex = 41
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(544, 87)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(110, 18)
        Me.lblMemberCardNo.TabIndex = 40
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(173, 449)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 47
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateVisits.Name = "chkNavigateVisits"
        Me.chkNavigateVisits.Size = New System.Drawing.Size(144, 20)
        Me.chkNavigateVisits.TabIndex = 0
        Me.chkNavigateVisits.Text = "Navigate Patient Visits"
        '
        'navVisits
        '
        Me.navVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navVisits.ColumnName = "VisitNo"
        Me.navVisits.DataSource = Nothing
        Me.navVisits.Location = New System.Drawing.Point(171, 2)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.Location = New System.Drawing.Point(713, 119)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 40)
        Me.imgIDAutomation.TabIndex = 75
        Me.imgIDAutomation.TabStop = False
        '
        'chkPrintDrugBarcode
        '
        Me.chkPrintDrugBarcode.AccessibleDescription = ""
        Me.chkPrintDrugBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDrugBarcode.AutoSize = True
        Me.chkPrintDrugBarcode.Location = New System.Drawing.Point(13, 440)
        Me.chkPrintDrugBarcode.Name = "chkPrintDrugBarcode"
        Me.chkPrintDrugBarcode.Size = New System.Drawing.Size(154, 17)
        Me.chkPrintDrugBarcode.TabIndex = 76
        Me.chkPrintDrugBarcode.Text = " Print Consumable Barcode"
        '
        'frmIssueConsumables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(922, 494)
        Me.Controls.Add(Me.chkPrintDrugBarcode)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.pnlConsumables)
        Me.Controls.Add(Me.btnLoadToIssueConsumables)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.dgvConsumables)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCashAccountBalance)
        Me.Controls.Add(Me.lblCashAccountBalance)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblBillNumber)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.imgIDAutomation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIssueConsumables"
        Me.Text = "Issue Consumables"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsConsumables.ResumeLayout(False)
        Me.pnlConsumables.ResumeLayout(False)
        Me.pnlNavigateVisits.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbCashAccountBalance As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblBillNumber As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents btnLoadToIssueConsumables As System.Windows.Forms.Button
    Friend WithEvents pnlConsumables As System.Windows.Forms.Panel
    Friend WithEvents btnViewToExpireConsumablesList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireConsumables As System.Windows.Forms.Label
    Friend WithEvents btnViewToOrderConsumablesList As System.Windows.Forms.Button
    Friend WithEvents lblToOrderConsumables As System.Windows.Forms.Label
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents cmsConsumables As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsConsumablesCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsConsumablesSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsConsumablesInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsConsumablesEditConsumables As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsConsumablesRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents chkPrintDrugBarcode As System.Windows.Forms.CheckBox

End Class