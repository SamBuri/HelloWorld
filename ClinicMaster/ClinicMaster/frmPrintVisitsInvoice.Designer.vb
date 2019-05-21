<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrintVisitsInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal invoiceNo As String)
        MyClass.New()
        Me.defaultInvoiceNo = invoiceNo
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintVisitsInvoice))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnLoadInvoices = New System.Windows.Forms.Button()
        Me.stbInvoiceDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbInvoiceAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceAmount = New System.Windows.Forms.Label()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.stbStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.chkPrintInvoiceDetailedOnSaving = New System.Windows.Forms.CheckBox()
        Me.tbcAccountStatement = New System.Windows.Forms.TabControl()
        Me.tpgInvoices = New System.Windows.Forms.TabPage()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.tpgAdjustments = New System.Windows.Forms.TabPage()
        Me.dgvAdjustments = New System.Windows.Forms.DataGridView()
        Me.colAdjItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjAMount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkPrintNetFiguresOnly = New System.Windows.Forms.CheckBox()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOriginalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOriginalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantityBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.tbcAccountStatement.SuspendLayout()
        Me.tpgInvoices.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAdjustments.SuspendLayout()
        CType(Me.dgvAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 443)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 24)
        Me.btnPrint.TabIndex = 46
        Me.btnPrint.Text = "&Print"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(769, 443)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 24)
        Me.btnClose.TabIndex = 48
        Me.btnClose.Text = "&Close"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(122, 443)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 47
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnLoadInvoices
        '
        Me.btnLoadInvoices.AccessibleDescription = ""
        Me.btnLoadInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadInvoices.Location = New System.Drawing.Point(249, 5)
        Me.btnLoadInvoices.Name = "btnLoadInvoices"
        Me.btnLoadInvoices.Size = New System.Drawing.Size(46, 24)
        Me.btnLoadInvoices.TabIndex = 2
        Me.btnLoadInvoices.Tag = ""
        Me.btnLoadInvoices.Text = "&Load"
        '
        'stbInvoiceDate
        '
        Me.stbInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceDate.CapitalizeFirstLetter = False
        Me.stbInvoiceDate.Enabled = False
        Me.stbInvoiceDate.EntryErrorMSG = ""
        Me.stbInvoiceDate.Location = New System.Drawing.Point(126, 114)
        Me.stbInvoiceDate.MaxLength = 20
        Me.stbInvoiceDate.Name = "stbInvoiceDate"
        Me.stbInvoiceDate.RegularExpression = ""
        Me.stbInvoiceDate.Size = New System.Drawing.Size(169, 20)
        Me.stbInvoiceDate.TabIndex = 12
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(126, 93)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(169, 20)
        Me.stbVisitNo.TabIndex = 10
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(126, 51)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(169, 20)
        Me.stbPatientNo.TabIndex = 6
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(12, 51)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(104, 21)
        Me.lblPatientsNo.TabIndex = 5
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(126, 72)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(169, 20)
        Me.stbVisitDate.TabIndex = 8
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 72)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(104, 21)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(614, 35)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(258, 53)
        Me.stbAmountWords.TabIndex = 34
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(603, 11)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(269, 21)
        Me.lblAmountWords.TabIndex = 33
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbInvoiceAmount
        '
        Me.stbInvoiceAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceAmount.CapitalizeFirstLetter = False
        Me.stbInvoiceAmount.Enabled = False
        Me.stbInvoiceAmount.EntryErrorMSG = ""
        Me.stbInvoiceAmount.Location = New System.Drawing.Point(126, 135)
        Me.stbInvoiceAmount.MaxLength = 20
        Me.stbInvoiceAmount.Name = "stbInvoiceAmount"
        Me.stbInvoiceAmount.RegularExpression = ""
        Me.stbInvoiceAmount.Size = New System.Drawing.Size(169, 20)
        Me.stbInvoiceAmount.TabIndex = 14
        Me.stbInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInvoiceAmount
        '
        Me.lblInvoiceAmount.Location = New System.Drawing.Point(12, 134)
        Me.lblInvoiceAmount.Name = "lblInvoiceAmount"
        Me.lblInvoiceAmount.Size = New System.Drawing.Size(104, 21)
        Me.lblInvoiceAmount.TabIndex = 13
        Me.lblInvoiceAmount.Text = "Invoice Amount"
        '
        'cmsInvoiceDetails
        '
        Me.cmsInvoiceDetails.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInvoiceDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceDetailsCopy, Me.cmsInvoiceDetailsSelectAll})
        Me.cmsInvoiceDetails.Name = "cmsSearch"
        Me.cmsInvoiceDetails.Size = New System.Drawing.Size(123, 48)
        '
        'cmsInvoiceDetailsCopy
        '
        Me.cmsInvoiceDetailsCopy.Enabled = False
        Me.cmsInvoiceDetailsCopy.Image = CType(resources.GetObject("cmsInvoiceDetailsCopy.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsCopy.Name = "cmsInvoiceDetailsCopy"
        Me.cmsInvoiceDetailsCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsInvoiceDetailsCopy.Text = "Copy"
        Me.cmsInvoiceDetailsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsInvoiceDetailsSelectAll
        '
        Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Me.cmsInvoiceDetailsSelectAll.Name = "cmsInvoiceDetailsSelectAll"
        Me.cmsInvoiceDetailsSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsInvoiceDetailsSelectAll.Text = "Select All"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(12, 9)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(104, 21)
        Me.lblInvoiceNo.TabIndex = 0
        Me.lblInvoiceNo.Text = "Invoice No."
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(126, 9)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(117, 20)
        Me.stbInvoiceNo.TabIndex = 1
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(126, 30)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 4
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(12, 30)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(104, 21)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(12, 114)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(104, 21)
        Me.lblInvoiceDate.TabIndex = 11
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 92)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(104, 21)
        Me.lblVisitNo.TabIndex = 9
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbEndDate
        '
        Me.stbEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEndDate.CapitalizeFirstLetter = False
        Me.stbEndDate.Enabled = False
        Me.stbEndDate.EntryErrorMSG = ""
        Me.stbEndDate.Location = New System.Drawing.Point(426, 26)
        Me.stbEndDate.MaxLength = 20
        Me.stbEndDate.Name = "stbEndDate"
        Me.stbEndDate.RegularExpression = ""
        Me.stbEndDate.Size = New System.Drawing.Size(171, 20)
        Me.stbEndDate.TabIndex = 20
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(306, 28)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(114, 18)
        Me.lblEndDate.TabIndex = 19
        Me.lblEndDate.Text = "End Date"
        '
        'stbStartDate
        '
        Me.stbStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStartDate.CapitalizeFirstLetter = False
        Me.stbStartDate.Enabled = False
        Me.stbStartDate.EntryErrorMSG = ""
        Me.stbStartDate.Location = New System.Drawing.Point(426, 5)
        Me.stbStartDate.MaxLength = 60
        Me.stbStartDate.Name = "stbStartDate"
        Me.stbStartDate.RegularExpression = ""
        Me.stbStartDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStartDate.Size = New System.Drawing.Size(171, 20)
        Me.stbStartDate.TabIndex = 18
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(306, 7)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(114, 18)
        Me.lblStartDate.TabIndex = 17
        Me.lblStartDate.Text = "Start Date"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(426, 47)
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(171, 20)
        Me.stbMemberCardNo.TabIndex = 22
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(306, 47)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(114, 18)
        Me.lblMemberCardNo.TabIndex = 21
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(426, 110)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(171, 31)
        Me.stbBillCustomerName.TabIndex = 28
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(306, 116)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(114, 18)
        Me.lblBillCustomerName.TabIndex = 27
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(426, 89)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(171, 20)
        Me.stbBillNo.TabIndex = 26
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(306, 89)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(114, 18)
        Me.lblBillNo.TabIndex = 25
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(126, 156)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(169, 20)
        Me.stbPrimaryDoctor.TabIndex = 16
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 156)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(104, 21)
        Me.lblPrimaryDoctor.TabIndex = 15
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(426, 142)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(171, 20)
        Me.stbInsuranceNo.TabIndex = 30
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(306, 143)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblInsuranceNo.TabIndex = 29
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(426, 163)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(171, 31)
        Me.stbInsuranceName.TabIndex = 32
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(306, 172)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(114, 18)
        Me.lblBillInsuranceName.TabIndex = 31
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(729, 131)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(143, 20)
        Me.nbxCoPayValue.TabIndex = 40
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(603, 133)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(120, 18)
        Me.lblCoPayValue.TabIndex = 39
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(729, 110)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(143, 20)
        Me.nbxCoPayPercent.TabIndex = 38
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(603, 112)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(120, 18)
        Me.lblCoPayPercent.TabIndex = 37
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(729, 89)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(143, 20)
        Me.stbCoPayType.TabIndex = 36
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(603, 91)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(120, 18)
        Me.lblCoPayType.TabIndex = 35
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.stbClaimReferenceNo.Enabled = False
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(426, 68)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(171, 20)
        Me.stbClaimReferenceNo.TabIndex = 24
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(306, 68)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblClaimReferenceNo.TabIndex = 23
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'stbVisitType
        '
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.stbVisitType.Enabled = False
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(729, 152)
        Me.stbVisitType.MaxLength = 60
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitType.Size = New System.Drawing.Size(143, 20)
        Me.stbVisitType.TabIndex = 42
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(603, 153)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(120, 18)
        Me.lblVisitType.TabIndex = 41
        Me.lblVisitType.Text = "Visit Type"
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(729, 173)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(143, 20)
        Me.stbMainMemberName.TabIndex = 44
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(603, 173)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(120, 18)
        Me.lblMainMemberName.TabIndex = 43
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'chkPrintInvoiceDetailedOnSaving
        '
        Me.chkPrintInvoiceDetailedOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInvoiceDetailedOnSaving.AutoSize = True
        Me.chkPrintInvoiceDetailedOnSaving.Location = New System.Drawing.Point(388, 449)
        Me.chkPrintInvoiceDetailedOnSaving.Name = "chkPrintInvoiceDetailedOnSaving"
        Me.chkPrintInvoiceDetailedOnSaving.Size = New System.Drawing.Size(130, 17)
        Me.chkPrintInvoiceDetailedOnSaving.TabIndex = 49
        Me.chkPrintInvoiceDetailedOnSaving.Text = " Print Detailed Invoice"
        '
        'tbcAccountStatement
        '
        Me.tbcAccountStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcAccountStatement.Controls.Add(Me.tpgInvoices)
        Me.tbcAccountStatement.Controls.Add(Me.tpgAdjustments)
        Me.tbcAccountStatement.HotTrack = True
        Me.tbcAccountStatement.Location = New System.Drawing.Point(11, 206)
        Me.tbcAccountStatement.Name = "tbcAccountStatement"
        Me.tbcAccountStatement.SelectedIndex = 0
        Me.tbcAccountStatement.Size = New System.Drawing.Size(862, 236)
        Me.tbcAccountStatement.TabIndex = 51
        '
        'tpgInvoices
        '
        Me.tpgInvoices.Controls.Add(Me.dgvInvoiceDetails)
        Me.tpgInvoices.Location = New System.Drawing.Point(4, 22)
        Me.tpgInvoices.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpgInvoices.Name = "tpgInvoices"
        Me.tpgInvoices.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpgInvoices.Size = New System.Drawing.Size(854, 210)
        Me.tpgInvoices.TabIndex = 10
        Me.tpgInvoices.Text = "Invoice Details"
        Me.tpgInvoices.UseVisualStyleBackColor = True
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToDeleteRows = False
        Me.dgvInvoiceDetails.AllowUserToOrderColumns = True
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.ColMappedCode, Me.colItemName, Me.colCategory, Me.colUnitPrice, Me.colOriginalQuantity, Me.colOriginalAmount, Me.colDiscount, Me.colQuantityBalance, Me.colAmountBalance, Me.colItemCategoryID})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(2, 2)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.ReadOnly = True
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvInvoiceDetails.RowHeadersVisible = False
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(850, 206)
        Me.dgvInvoiceDetails.TabIndex = 0
        Me.dgvInvoiceDetails.Text = "DataGridView1"
        '
        'tpgAdjustments
        '
        Me.tpgAdjustments.Controls.Add(Me.dgvAdjustments)
        Me.tpgAdjustments.Location = New System.Drawing.Point(4, 22)
        Me.tpgAdjustments.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpgAdjustments.Name = "tpgAdjustments"
        Me.tpgAdjustments.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.tpgAdjustments.Size = New System.Drawing.Size(854, 210)
        Me.tpgAdjustments.TabIndex = 11
        Me.tpgAdjustments.Text = "Adjustment"
        Me.tpgAdjustments.UseVisualStyleBackColor = True
        '
        'dgvAdjustments
        '
        Me.dgvAdjustments.AllowUserToAddRows = False
        Me.dgvAdjustments.AllowUserToDeleteRows = False
        Me.dgvAdjustments.AllowUserToOrderColumns = True
        Me.dgvAdjustments.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAdjustments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAdjustments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdjustments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAdjItemCode, Me.colAdjMappedCode, Me.colAdjItemName, Me.colAdjCategory, Me.colAdjQuantity, Me.colAdjAMount, Me.DataGridViewTextBoxColumn11})
        Me.dgvAdjustments.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvAdjustments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAdjustments.EnableHeadersVisualStyles = False
        Me.dgvAdjustments.GridColor = System.Drawing.Color.Khaki
        Me.dgvAdjustments.Location = New System.Drawing.Point(2, 2)
        Me.dgvAdjustments.Name = "dgvAdjustments"
        Me.dgvAdjustments.ReadOnly = True
        Me.dgvAdjustments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdjustments.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvAdjustments.RowHeadersVisible = False
        Me.dgvAdjustments.Size = New System.Drawing.Size(850, 206)
        Me.dgvAdjustments.TabIndex = 1
        Me.dgvAdjustments.Text = "DataGridView1"
        '
        'colAdjItemCode
        '
        Me.colAdjItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colAdjItemCode.DefaultCellStyle = DataGridViewCellStyle15
        Me.colAdjItemCode.HeaderText = "Item Code"
        Me.colAdjItemCode.Name = "colAdjItemCode"
        Me.colAdjItemCode.ReadOnly = True
        '
        'colAdjMappedCode
        '
        Me.colAdjMappedCode.DataPropertyName = "MappedCustomCode"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colAdjMappedCode.DefaultCellStyle = DataGridViewCellStyle16
        Me.colAdjMappedCode.HeaderText = "Mapped Code"
        Me.colAdjMappedCode.Name = "colAdjMappedCode"
        Me.colAdjMappedCode.ReadOnly = True
        Me.colAdjMappedCode.Width = 120
        '
        'colAdjItemName
        '
        Me.colAdjItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colAdjItemName.DefaultCellStyle = DataGridViewCellStyle17
        Me.colAdjItemName.HeaderText = "Item Name"
        Me.colAdjItemName.Name = "colAdjItemName"
        Me.colAdjItemName.ReadOnly = True
        Me.colAdjItemName.Width = 250
        '
        'colAdjCategory
        '
        Me.colAdjCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colAdjCategory.DefaultCellStyle = DataGridViewCellStyle18
        Me.colAdjCategory.HeaderText = "Category"
        Me.colAdjCategory.Name = "colAdjCategory"
        Me.colAdjCategory.ReadOnly = True
        '
        'colAdjQuantity
        '
        Me.colAdjQuantity.DataPropertyName = "TotalQuantity"
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colAdjQuantity.DefaultCellStyle = DataGridViewCellStyle19
        Me.colAdjQuantity.HeaderText = "Quantity"
        Me.colAdjQuantity.Name = "colAdjQuantity"
        Me.colAdjQuantity.ReadOnly = True
        '
        'colAdjAMount
        '
        Me.colAdjAMount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colAdjAMount.DefaultCellStyle = DataGridViewCellStyle20
        Me.colAdjAMount.HeaderText = "Amount "
        Me.colAdjAMount.Name = "colAdjAMount"
        Me.colAdjAMount.ReadOnly = True
        Me.colAdjAMount.Width = 120
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn11.HeaderText = "Item Category ID"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'chkPrintNetFiguresOnly
        '
        Me.chkPrintNetFiguresOnly.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintNetFiguresOnly.AutoSize = True
        Me.chkPrintNetFiguresOnly.Location = New System.Drawing.Point(232, 448)
        Me.chkPrintNetFiguresOnly.Name = "chkPrintNetFiguresOnly"
        Me.chkPrintNetFiguresOnly.Size = New System.Drawing.Size(131, 17)
        Me.chkPrintNetFiguresOnly.TabIndex = 52
        Me.chkPrintNetFiguresOnly.Text = " Print Net Figures Only"
        Me.chkPrintNetFiguresOnly.Visible = False
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 80
        '
        'ColMappedCode
        '
        Me.ColMappedCode.DataPropertyName = "MappedCustomCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.ColMappedCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColMappedCode.HeaderText = "Mapped Code"
        Me.ColMappedCode.Name = "ColMappedCode"
        Me.ColMappedCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 140
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 80
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        '
        'colOriginalQuantity
        '
        Me.colOriginalQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colOriginalQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOriginalQuantity.HeaderText = "Quantity"
        Me.colOriginalQuantity.Name = "colOriginalQuantity"
        Me.colOriginalQuantity.ReadOnly = True
        '
        'colOriginalAmount
        '
        Me.colOriginalAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colOriginalAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colOriginalAmount.HeaderText = "Amount"
        Me.colOriginalAmount.Name = "colOriginalAmount"
        Me.colOriginalAmount.ReadOnly = True
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Width = 60
        '
        'colQuantityBalance
        '
        Me.colQuantityBalance.DataPropertyName = "QuantityBalance"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colQuantityBalance.DefaultCellStyle = DataGridViewCellStyle10
        Me.colQuantityBalance.HeaderText = "Quantity Balance"
        Me.colQuantityBalance.Name = "colQuantityBalance"
        Me.colQuantityBalance.ReadOnly = True
        Me.colQuantityBalance.Visible = False
        Me.colQuantityBalance.Width = 120
        '
        'colAmountBalance
        '
        Me.colAmountBalance.DataPropertyName = "AmountBalance"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colAmountBalance.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAmountBalance.HeaderText = "Amount Balance"
        Me.colAmountBalance.Name = "colAmountBalance"
        Me.colAmountBalance.ReadOnly = True
        Me.colAmountBalance.Visible = False
        Me.colAmountBalance.Width = 120
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle12
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'frmPrintVisitsInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(883, 477)
        Me.Controls.Add(Me.chkPrintNetFiguresOnly)
        Me.Controls.Add(Me.tbcAccountStatement)
        Me.Controls.Add(Me.chkPrintInvoiceDetailedOnSaving)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.stbVisitType)
        Me.Controls.Add(Me.lblVisitType)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.stbEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.stbStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.btnLoadInvoices)
        Me.Controls.Add(Me.stbInvoiceDate)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.stbInvoiceAmount)
        Me.Controls.Add(Me.lblInvoiceAmount)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.stbInvoiceNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPrintVisitsInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visit's Invoice"
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.tbcAccountStatement.ResumeLayout(False)
        Me.tpgInvoices.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAdjustments.ResumeLayout(False)
        CType(Me.dgvAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ckcInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnLoadInvoices As System.Windows.Forms.Button
    Friend WithEvents stbInvoiceDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceAmount As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents stbStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents chkPrintInvoiceDetailedOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents tbcAccountStatement As System.Windows.Forms.TabControl
    Friend WithEvents tpgInvoices As System.Windows.Forms.TabPage
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tpgAdjustments As System.Windows.Forms.TabPage
    Friend WithEvents dgvAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents colAdjItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjAMount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkPrintNetFiguresOnly As System.Windows.Forms.CheckBox
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOriginalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOriginalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantityBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
