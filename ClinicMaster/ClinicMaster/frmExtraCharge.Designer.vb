
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtraCharge : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtraCharge))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.dgvExtraCharge = New System.Windows.Forms.DataGridView()
        Me.colItemName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(735, 420)
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
        Me.stbVisitNo.Location = New System.Drawing.Point(135, 7)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitNo.Size = New System.Drawing.Size(81, 20)
        Me.stbVisitNo.TabIndex = 2
        Me.stbVisitNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(10, 7)
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
        Me.btnFindVisitNo.Location = New System.Drawing.Point(91, 7)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(13, 420)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 40
        Me.btnSave.TabStop = False
        Me.btnSave.Tag = "ExtraCharge"
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
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(135, 95)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(131, 20)
        Me.nbxOutstandingBalance.TabIndex = 11
        Me.nbxOutstandingBalance.Value = ""
        Me.nbxOutstandingBalance.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(10, 96)
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
        Me.stbCashAccountBalance.Location = New System.Drawing.Point(407, 69)
        Me.stbCashAccountBalance.MaxLength = 20
        Me.stbCashAccountBalance.Name = "stbCashAccountBalance"
        Me.stbCashAccountBalance.ReadOnly = True
        Me.stbCashAccountBalance.RegularExpression = ""
        Me.stbCashAccountBalance.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbCashAccountBalance.Size = New System.Drawing.Size(132, 20)
        Me.stbCashAccountBalance.TabIndex = 23
        Me.stbCashAccountBalance.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbCashAccountBalance.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(279, 72)
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
        Me.stbBillCustomerName.Location = New System.Drawing.Point(407, 91)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(132, 45)
        Me.stbBillCustomerName.TabIndex = 25
        Me.stbBillCustomerName.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillCustomerName.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(279, 97)
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
        Me.stbTotalVisits.Location = New System.Drawing.Point(618, 90)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(85, 20)
        Me.stbTotalVisits.TabIndex = 37
        Me.stbTotalVisits.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbTotalVisits.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(548, 91)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(64, 18)
        Me.lblTotalVisits.TabIndex = 36
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(709, 6)
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
        Me.stbVisitDate.Location = New System.Drawing.Point(135, 73)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(131, 20)
        Me.stbVisitDate.TabIndex = 9
        Me.stbVisitDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(135, 51)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPatientNo.Size = New System.Drawing.Size(131, 20)
        Me.stbPatientNo.TabIndex = 7
        Me.stbPatientNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPatientNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(10, 51)
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
        Me.stbBillMode.Location = New System.Drawing.Point(618, 69)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(85, 20)
        Me.stbBillMode.TabIndex = 35
        Me.stbBillMode.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillMode.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(548, 71)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(64, 18)
        Me.lblBillMode.TabIndex = 34
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(618, 27)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(85, 20)
        Me.stbStatus.TabIndex = 31
        Me.stbStatus.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbStatus.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(548, 27)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(64, 18)
        Me.lblStatus.TabIndex = 30
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(407, 6)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(132, 20)
        Me.stbBillNo.TabIndex = 17
        Me.stbBillNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(618, 6)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(85, 20)
        Me.stbAge.TabIndex = 29
        Me.stbAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbAge.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(407, 48)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(132, 20)
        Me.stbJoinDate.TabIndex = 21
        Me.stbJoinDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbJoinDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(618, 48)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(85, 20)
        Me.stbGender.TabIndex = 33
        Me.stbGender.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbGender.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(279, 51)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(122, 20)
        Me.lblJoinDate.TabIndex = 20
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNumber
        '
        Me.lblBillNumber.Location = New System.Drawing.Point(279, 6)
        Me.lblBillNumber.Name = "lblBillNumber"
        Me.lblBillNumber.Size = New System.Drawing.Size(122, 20)
        Me.lblBillNumber.TabIndex = 16
        Me.lblBillNumber.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(548, 6)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(64, 18)
        Me.lblAge.TabIndex = 28
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(548, 48)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(64, 18)
        Me.lblGenderID.TabIndex = 32
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(10, 73)
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
        Me.stbFullName.Location = New System.Drawing.Point(135, 29)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(131, 20)
        Me.stbFullName.TabIndex = 5
        Me.stbFullName.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbFullName.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(10, 29)
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
        Me.pnlBill.Location = New System.Drawing.Point(2, 160)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(805, 42)
        Me.pnlBill.TabIndex = 38
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(280, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(100, 20)
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
        Me.stbBillForItem.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillForItem.Size = New System.Drawing.Size(131, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.stbBillForItem.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillForItem.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(405, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(292, 36)
        Me.stbBillWords.TabIndex = 3
        Me.stbBillWords.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillWords.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(8, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(111, 20)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Extra Item"
        '
        'dgvExtraCharge
        '
        Me.dgvExtraCharge.AllowUserToOrderColumns = True
        Me.dgvExtraCharge.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExtraCharge.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colNotes, Me.colExtraChargeQuantity, Me.colExtraChargeUnitPrice, Me.colExtraChargeAmount, Me.colExtraChargeSaved})
        Me.dgvExtraCharge.EnableHeadersVisualStyles = False
        Me.dgvExtraCharge.GridColor = System.Drawing.Color.Khaki
        Me.dgvExtraCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvExtraCharge.Location = New System.Drawing.Point(13, 208)
        Me.dgvExtraCharge.Name = "dgvExtraCharge"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvExtraCharge.Size = New System.Drawing.Size(794, 206)
        Me.dgvExtraCharge.TabIndex = 39
        Me.dgvExtraCharge.Text = "DataGridView1"
        '
        'colItemName
        '
        Me.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colItemName.DisplayStyleForCurrentCellOnly = True
        Me.colItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Sorted = True
        Me.colItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colItemName.Width = 180
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 40
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 180
        '
        'colExtraChargeQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colExtraChargeQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExtraChargeQuantity.HeaderText = "Quantity"
        Me.colExtraChargeQuantity.MaxInputLength = 12
        Me.colExtraChargeQuantity.Name = "colExtraChargeQuantity"
        Me.colExtraChargeQuantity.Width = 60
        '
        'colExtraChargeUnitPrice
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colExtraChargeUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.colExtraChargeUnitPrice.HeaderText = "Unit Price"
        Me.colExtraChargeUnitPrice.MaxInputLength = 12
        Me.colExtraChargeUnitPrice.Name = "colExtraChargeUnitPrice"
        Me.colExtraChargeUnitPrice.Width = 120
        '
        'colExtraChargeAmount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colExtraChargeAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colExtraChargeAmount.HeaderText = "Amount"
        Me.colExtraChargeAmount.MaxInputLength = 12
        Me.colExtraChargeAmount.Name = "colExtraChargeAmount"
        Me.colExtraChargeAmount.ReadOnly = True
        Me.colExtraChargeAmount.Width = 120
        '
        'colExtraChargeSaved
        '
        Me.colExtraChargeSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = False
        Me.colExtraChargeSaved.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExtraChargeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraChargeSaved.HeaderText = "Saved"
        Me.colExtraChargeSaved.Name = "colExtraChargeSaved"
        Me.colExtraChargeSaved.ReadOnly = True
        Me.colExtraChargeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExtraChargeSaved.Width = 50
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(407, 138)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(132, 20)
        Me.nbxCoPayValue.TabIndex = 27
        Me.nbxCoPayValue.Value = ""
        Me.nbxCoPayValue.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(279, 139)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(122, 20)
        Me.lblCoPayValue.TabIndex = 26
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.General
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(135, 137)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(131, 20)
        Me.nbxCoPayPercent.TabIndex = 15
        Me.nbxCoPayPercent.Value = ""
        Me.nbxCoPayPercent.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(10, 138)
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
        Me.stbCoPayType.Location = New System.Drawing.Point(135, 116)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbCoPayType.Size = New System.Drawing.Size(131, 20)
        Me.stbCoPayType.TabIndex = 13
        Me.stbCoPayType.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbCoPayType.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(10, 116)
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
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(407, 27)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(132, 20)
        Me.stbPrimaryDoctor.TabIndex = 19
        Me.stbPrimaryDoctor.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPrimaryDoctor.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(279, 28)
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
        'frmExtraCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(825, 456)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.dgvExtraCharge)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExtraCharge"
        Me.Text = "Extra Charge"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dgvExtraCharge As System.Windows.Forms.DataGridView
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button

End Class