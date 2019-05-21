
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsumables : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsumables))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConsumableOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsConsumables = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsConsumablesQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.stbPackage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.stbPackageNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsConsumables.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(841, 458)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 41
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
        Me.btnSave.Location = New System.Drawing.Point(13, 458)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 40
        Me.btnSave.TabStop = False
        Me.btnSave.Tag = "Consumables"
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
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(135, 91)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(131, 20)
        Me.nbxOutstandingBalance.TabIndex = 11
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(10, 92)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(119, 20)
        Me.lblOutstandingBalance.TabIndex = 10
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
        Me.stbCashAccountBalance.TabIndex = 23
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(272, 69)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(122, 20)
        Me.lblCashAccountBalance.TabIndex = 22
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
        Me.stbBillCustomerName.TabIndex = 25
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(272, 94)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(122, 20)
        Me.lblBillCustomerName.TabIndex = 24
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(623, 87)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(85, 20)
        Me.stbTotalVisits.TabIndex = 37
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(544, 88)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(73, 18)
        Me.lblTotalVisits.TabIndex = 36
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(726, 6)
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
        Me.stbVisitDate.Location = New System.Drawing.Point(135, 70)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(131, 20)
        Me.stbVisitDate.TabIndex = 9
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(135, 49)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(131, 20)
        Me.stbPatientNo.TabIndex = 7
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(10, 49)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(119, 20)
        Me.lblPatientsNo.TabIndex = 6
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(623, 66)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(85, 20)
        Me.stbBillMode.TabIndex = 35
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(544, 68)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(73, 18)
        Me.lblBillMode.TabIndex = 34
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(623, 24)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(85, 20)
        Me.stbStatus.TabIndex = 31
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(544, 24)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(73, 18)
        Me.lblStatus.TabIndex = 30
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
        Me.stbBillNo.TabIndex = 17
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(623, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(85, 20)
        Me.stbAge.TabIndex = 29
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
        Me.stbJoinDate.TabIndex = 21
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(623, 45)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(85, 20)
        Me.stbGender.TabIndex = 33
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(272, 48)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(122, 20)
        Me.lblJoinDate.TabIndex = 20
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNumber
        '
        Me.lblBillNumber.Location = New System.Drawing.Point(272, 3)
        Me.lblBillNumber.Name = "lblBillNumber"
        Me.lblBillNumber.Size = New System.Drawing.Size(122, 20)
        Me.lblBillNumber.TabIndex = 16
        Me.lblBillNumber.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(544, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(73, 18)
        Me.lblAge.TabIndex = 28
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(544, 45)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(73, 18)
        Me.lblGenderID.TabIndex = 32
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(10, 70)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(119, 20)
        Me.lblVisitDate.TabIndex = 8
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
        Me.pnlBill.Location = New System.Drawing.Point(2, 156)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(917, 42)
        Me.pnlBill.TabIndex = 38
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(271, 6)
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
        Me.stbBillWords.Size = New System.Drawing.Size(405, 36)
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
        'dgvConsumables
        '
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
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitsInStock, Me.colConsumableUnitMeasure, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumableExpiryDate, Me.colConsumablesSaved, Me.colConsumableOrderLevel, Me.colConsumableAlternateName, Me.colConsumableItemStatus, Me.colConsumablePayStatus, Me.colConsumableHalted})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsConsumables
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(13, 204)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvConsumables.Size = New System.Drawing.Size(900, 248)
        Me.dgvConsumables.TabIndex = 39
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colConsumableName.DisplayStyleForCurrentCellOnly = True
        Me.colConsumableName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.Sorted = True
        Me.colConsumableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableName.Width = 200
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        '
        'colConsumableQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitsInStock
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitsInStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.colConsumableUnitsInStock.HeaderText = "Units In Stock"
        Me.colConsumableUnitsInStock.Name = "colConsumableUnitsInStock"
        Me.colConsumableUnitsInStock.ReadOnly = True
        Me.colConsumableUnitsInStock.Width = 80
        '
        'colConsumableUnitMeasure
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitMeasure.DefaultCellStyle = DataGridViewCellStyle4
        Me.colConsumableUnitMeasure.HeaderText = "Unit Measure"
        Me.colConsumableUnitMeasure.Name = "colConsumableUnitMeasure"
        Me.colConsumableUnitMeasure.ReadOnly = True
        Me.colConsumableUnitMeasure.Width = 80
        '
        'colConsumableUnitPrice
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        Me.colConsumableExpiryDate.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle9
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        Me.colConsumableOrderLevel.Width = 70
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle10
        Me.colConsumableAlternateName.HeaderText = "Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 90
        '
        'colConsumableItemStatus
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableItemStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colConsumableItemStatus.HeaderText = "Item Status"
        Me.colConsumableItemStatus.Name = "colConsumableItemStatus"
        Me.colConsumableItemStatus.ReadOnly = True
        Me.colConsumableItemStatus.Width = 80
        '
        'colConsumablePayStatus
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablePayStatus.DefaultCellStyle = DataGridViewCellStyle12
        Me.colConsumablePayStatus.HeaderText = "Pay Status"
        Me.colConsumablePayStatus.Name = "colConsumablePayStatus"
        Me.colConsumablePayStatus.ReadOnly = True
        Me.colConsumablePayStatus.Width = 70
        '
        'colConsumableHalted
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.NullValue = False
        Me.colConsumableHalted.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableHalted.HeaderText = "Halted"
        Me.colConsumableHalted.Name = "colConsumableHalted"
        Me.colConsumableHalted.ReadOnly = True
        Me.colConsumableHalted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableHalted.Width = 50
        '
        'cmsConsumables
        '
        Me.cmsConsumables.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsConsumables.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsConsumablesQuickSearch})
        Me.cmsConsumables.Name = "cmsSearch"
        Me.cmsConsumables.Size = New System.Drawing.Size(144, 26)
        '
        'cmsConsumablesQuickSearch
        '
        Me.cmsConsumablesQuickSearch.Image = CType(resources.GetObject("cmsConsumablesQuickSearch.Image"), System.Drawing.Image)
        Me.cmsConsumablesQuickSearch.Name = "cmsConsumablesQuickSearch"
        Me.cmsConsumablesQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsConsumablesQuickSearch.Text = "Quick Search"
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
        Me.nbxCoPayValue.TabIndex = 27
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(272, 131)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(122, 20)
        Me.lblCoPayValue.TabIndex = 26
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(135, 133)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(131, 20)
        Me.nbxCoPayPercent.TabIndex = 15
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(10, 134)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(119, 20)
        Me.lblCoPayPercent.TabIndex = 14
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(135, 112)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(131, 20)
        Me.stbCoPayType.TabIndex = 13
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(10, 112)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(119, 20)
        Me.lblCoPayType.TabIndex = 12
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
        Me.stbPrimaryDoctor.TabIndex = 19
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(272, 26)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(122, 20)
        Me.lblPrimaryDoctor.TabIndex = 18
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(222, 3)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'stbPackage
        '
        Me.stbPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPackage.CapitalizeFirstLetter = False
        Me.stbPackage.Enabled = False
        Me.stbPackage.EntryErrorMSG = ""
        Me.stbPackage.Location = New System.Drawing.Point(623, 129)
        Me.stbPackage.MaxLength = 60
        Me.stbPackage.Name = "stbPackage"
        Me.stbPackage.RegularExpression = ""
        Me.stbPackage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPackage.Size = New System.Drawing.Size(207, 20)
        Me.stbPackage.TabIndex = 76
        '
        'lblPackageName
        '
        Me.lblPackageName.Location = New System.Drawing.Point(544, 129)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(73, 20)
        Me.lblPackageName.TabIndex = 75
        Me.lblPackageName.Text = "Package"
        '
        'stbPackageNo
        '
        Me.stbPackageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPackageNo.CapitalizeFirstLetter = False
        Me.stbPackageNo.Enabled = False
        Me.stbPackageNo.EntryErrorMSG = ""
        Me.stbPackageNo.Location = New System.Drawing.Point(623, 108)
        Me.stbPackageNo.MaxLength = 60
        Me.stbPackageNo.Name = "stbPackageNo"
        Me.stbPackageNo.RegularExpression = ""
        Me.stbPackageNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPackageNo.Size = New System.Drawing.Size(85, 20)
        Me.stbPackageNo.TabIndex = 78
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(544, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 18)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Package No"
        '
        'frmConsumables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(922, 494)
        Me.Controls.Add(Me.stbPackageNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbPackage)
        Me.Controls.Add(Me.lblPackageName)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsumables"
        Me.Text = "Consumables"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsConsumables.ResumeLayout(False)
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
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
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
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableHalted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmsConsumables As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsConsumablesQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbPackage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents stbPackageNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class