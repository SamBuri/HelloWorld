
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitInvoices : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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

    Public Sub New(visitNo As String, visitTypeID As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
        Me.visitTypeID = visitTypeID
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitInvoices))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lbInsuranceName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadVisits = New System.Windows.Forms.Button()
        Me.stbPackage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.tbcIPDInvoiceDetails = New SyncSoft.Common.Win.Controls.SmartTabControl()
        Me.tpgOPDInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.coIInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantityBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgIPDInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.dgvInvoiceExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.colIPDInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDInvoiceDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDQuantityBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDAmountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDPayNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkIncludeIPDInvoices = New System.Windows.Forms.CheckBox()
        Me.stbAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.stbAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountInWords = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.SmartTextBox1 = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.pnlVisitNo.SuspendLayout()
        Me.tbcIPDInvoiceDetails.SuspendLayout()
        Me.tpgOPDInvoiceDetails.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.tpgIPDInvoiceDetails.SuspendLayout()
        CType(Me.dgvInvoiceExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(894, 463)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(476, 30)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(151, 29)
        Me.stbBillCustomerName.TabIndex = 76
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(355, 32)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(91, 20)
        Me.lblBillCustomerName.TabIndex = 75
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(107, 6)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 54
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(140, 83)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(150, 20)
        Me.stbVisitDate.TabIndex = 66
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(140, 36)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(150, 20)
        Me.stbPatientNo.TabIndex = 70
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(9, 38)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(101, 20)
        Me.lblPatientsNo.TabIndex = 69
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(140, 157)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(151, 20)
        Me.stbBillMode.TabIndex = 80
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(12, 159)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(91, 20)
        Me.lblBillMode.TabIndex = 79
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbBillNo
        '
        Me.stbBillNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(476, 7)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(151, 20)
        Me.stbBillNo.TabIndex = 74
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BackColor = System.Drawing.SystemColors.Info
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.Enabled = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(476, 97)
        Me.stbInsuranceName.MaxLength = 60
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(156, 23)
        Me.stbInsuranceName.TabIndex = 72
        '
        'lbInsuranceName
        '
        Me.lbInsuranceName.Location = New System.Drawing.Point(356, 98)
        Me.lbInsuranceName.Name = "lbInsuranceName"
        Me.lbInsuranceName.Size = New System.Drawing.Size(101, 20)
        Me.lbInsuranceName.TabIndex = 71
        Me.lbInsuranceName.Text = "Insurance Name"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(355, 6)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(91, 20)
        Me.lblBillNo.TabIndex = 73
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(9, 85)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(93, 20)
        Me.lblVisitDate.TabIndex = 65
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BackColor = System.Drawing.SystemColors.Info
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(140, 59)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(150, 20)
        Me.stbFullName.TabIndex = 68
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(9, 58)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(94, 20)
        Me.lblFullName.TabIndex = 67
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(9, 8)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(52, 18)
        Me.lblVisitNo.TabIndex = 53
        Me.lblVisitNo.Text = "Visit No."
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadVisits)
        Me.pnlVisitNo.Location = New System.Drawing.Point(137, 2)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(206, 30)
        Me.pnlVisitNo.TabIndex = 55
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(3, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(150, 20)
        Me.stbVisitNo.TabIndex = 0
        '
        'btnLoadVisits
        '
        Me.btnLoadVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadVisits.Location = New System.Drawing.Point(156, 3)
        Me.btnLoadVisits.Name = "btnLoadVisits"
        Me.btnLoadVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadVisits.TabIndex = 1
        Me.btnLoadVisits.Tag = ""
        Me.btnLoadVisits.Text = "&Load"
        '
        'stbPackage
        '
        Me.stbPackage.BackColor = System.Drawing.SystemColors.Info
        Me.stbPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPackage.CapitalizeFirstLetter = False
        Me.stbPackage.Enabled = False
        Me.stbPackage.EntryErrorMSG = ""
        Me.stbPackage.Location = New System.Drawing.Point(810, 32)
        Me.stbPackage.MaxLength = 60
        Me.stbPackage.Name = "stbPackage"
        Me.stbPackage.RegularExpression = ""
        Me.stbPackage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPackage.Size = New System.Drawing.Size(151, 20)
        Me.stbPackage.TabIndex = 92
        '
        'lblPackageName
        '
        Me.lblPackageName.Location = New System.Drawing.Point(663, 28)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(114, 20)
        Me.lblPackageName.TabIndex = 91
        Me.lblPackageName.Text = "Package"
        '
        'stbAge
        '
        Me.stbAge.BackColor = System.Drawing.SystemColors.Info
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(476, 171)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(158, 20)
        Me.stbAge.TabIndex = 84
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(361, 167)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(98, 20)
        Me.lblAge.TabIndex = 83
        Me.lblAge.Text = "Age"
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(810, 9)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(150, 20)
        Me.nbxOutstandingBalance.TabIndex = 90
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(662, 8)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(115, 20)
        Me.lblOutstandingBalance.TabIndex = 89
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(476, 149)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(158, 20)
        Me.stbTotalVisits.TabIndex = 88
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(358, 146)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(98, 20)
        Me.lblTotalVisits.TabIndex = 87
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'stbGender
        '
        Me.stbGender.BackColor = System.Drawing.SystemColors.Info
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(476, 124)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(158, 20)
        Me.stbGender.TabIndex = 86
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(356, 120)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(98, 20)
        Me.lblGenderID.TabIndex = 85
        Me.lblGenderID.Text = "Gender"
        '
        'tbcIPDInvoiceDetails
        '
        Me.tbcIPDInvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcIPDInvoiceDetails.Controls.Add(Me.tpgOPDInvoiceDetails)
        Me.tbcIPDInvoiceDetails.Controls.Add(Me.tpgIPDInvoiceDetails)
        Me.tbcIPDInvoiceDetails.HotTrack = True
        Me.tbcIPDInvoiceDetails.Location = New System.Drawing.Point(8, 206)
        Me.tbcIPDInvoiceDetails.Name = "tbcIPDInvoiceDetails"
        Me.tbcIPDInvoiceDetails.SelectedIndex = 0
        Me.tbcIPDInvoiceDetails.Size = New System.Drawing.Size(957, 232)
        Me.tbcIPDInvoiceDetails.TabIndex = 93
        '
        'tpgOPDInvoiceDetails
        '
        Me.tpgOPDInvoiceDetails.Controls.Add(Me.dgvInvoiceDetails)
        Me.tpgOPDInvoiceDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDInvoiceDetails.Name = "tpgOPDInvoiceDetails"
        Me.tpgOPDInvoiceDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOPDInvoiceDetails.Size = New System.Drawing.Size(949, 206)
        Me.tpgOPDInvoiceDetails.TabIndex = 1
        Me.tpgOPDInvoiceDetails.Text = "OPD Invoice Details"
        Me.tpgOPDInvoiceDetails.UseVisualStyleBackColor = True
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
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.coIInvoiceNo, Me.colInvoiceDate, Me.colCategory, Me.colItemCode, Me.colItemName, Me.colQuantityBalance, Me.colUnitPrice, Me.colAmountBalance, Me.colDiscount, Me.colQuantity, Me.colAmount, Me.colPayStatus, Me.colItemStatus, Me.colPayType, Me.colMappedCode, Me.colItemCategoryID})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(943, 200)
        Me.dgvInvoiceDetails.TabIndex = 1
        Me.dgvInvoiceDetails.Text = "DataGridView1"
        '
        'coIInvoiceNo
        '
        Me.coIInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.coIInvoiceNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.coIInvoiceNo.HeaderText = "Invoice No"
        Me.coIInvoiceNo.Name = "coIInvoiceNo"
        Me.coIInvoiceNo.ReadOnly = True
        Me.coIInvoiceNo.Width = 75
        '
        'colInvoiceDate
        '
        Me.colInvoiceDate.DataPropertyName = "InvoiceDate"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.colInvoiceDate.HeaderText = "Invoice Date"
        Me.colInvoiceDate.Name = "colInvoiceDate"
        Me.colInvoiceDate.ReadOnly = True
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 70
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle5
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 65
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle6
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 150
        '
        'colQuantityBalance
        '
        Me.colQuantityBalance.DataPropertyName = "QuantityBalance"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colQuantityBalance.DefaultCellStyle = DataGridViewCellStyle7
        Me.colQuantityBalance.HeaderText = "Quantity"
        Me.colQuantityBalance.Name = "colQuantityBalance"
        Me.colQuantityBalance.ReadOnly = True
        Me.colQuantityBalance.Width = 80
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle8
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colAmountBalance
        '
        Me.colAmountBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colAmountBalance.DataPropertyName = "AmountBalance"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colAmountBalance.DefaultCellStyle = DataGridViewCellStyle9
        Me.colAmountBalance.HeaderText = "Amount"
        Me.colAmountBalance.Name = "colAmountBalance"
        Me.colAmountBalance.ReadOnly = True
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Width = 60
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle11
        Me.colQuantity.HeaderText = "Original Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 120
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAmount.HeaderText = "Original Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 120
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle13
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 80
        '
        'colItemStatus
        '
        Me.colItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colItemStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 70
        '
        'colPayType
        '
        Me.colPayType.DataPropertyName = "PayType"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colPayType.DefaultCellStyle = DataGridViewCellStyle15
        Me.colPayType.HeaderText = "Pay Type"
        Me.colPayType.Name = "colPayType"
        Me.colPayType.ReadOnly = True
        '
        'colMappedCode
        '
        Me.colMappedCode.DataPropertyName = "MappedCustomCode"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colMappedCode.DefaultCellStyle = DataGridViewCellStyle16
        Me.colMappedCode.HeaderText = "Mapped Code"
        Me.colMappedCode.Name = "colMappedCode"
        Me.colMappedCode.ReadOnly = True
        '
        'colItemCategoryID
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle17
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        Me.colItemCategoryID.Width = 10
        '
        'cmsInvoiceDetails
        '
        Me.cmsInvoiceDetails.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInvoiceDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceDetailsCopy, Me.cmsInvoiceDetailsSelectAll, Me.cmsDetails})
        Me.cmsInvoiceDetails.Name = "cmsSearch"
        Me.cmsInvoiceDetails.Size = New System.Drawing.Size(123, 70)
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
        'cmsDetails
        '
        Me.cmsDetails.Enabled = False
        Me.cmsDetails.Name = "cmsDetails"
        Me.cmsDetails.Size = New System.Drawing.Size(122, 22)
        Me.cmsDetails.Text = "Details"
        '
        'tpgIPDInvoiceDetails
        '
        Me.tpgIPDInvoiceDetails.Controls.Add(Me.dgvInvoiceExtraBillItems)
        Me.tpgIPDInvoiceDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDInvoiceDetails.Name = "tpgIPDInvoiceDetails"
        Me.tpgIPDInvoiceDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIPDInvoiceDetails.Size = New System.Drawing.Size(949, 206)
        Me.tpgIPDInvoiceDetails.TabIndex = 0
        Me.tpgIPDInvoiceDetails.Text = "IPD Invoice Details"
        Me.tpgIPDInvoiceDetails.UseVisualStyleBackColor = True
        '
        'dgvInvoiceExtraBillItems
        '
        Me.dgvInvoiceExtraBillItems.AllowUserToAddRows = False
        Me.dgvInvoiceExtraBillItems.AllowUserToDeleteRows = False
        Me.dgvInvoiceExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvInvoiceExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvInvoiceExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIPDInvoiceNo, Me.colIPDInvoiceDate, Me.colExtraBillNo, Me.colIPDItemCode, Me.colIPDItemName, Me.colIPDQuantityBalance, Me.colIPDUnitPrice, Me.colIPDAmountBalance, Me.colIPDQuantity, Me.colIPDAmount, Me.colIPDCategory, Me.colIPDPayType, Me.colIPDPayNo, Me.colIPDPayStatus, Me.colIPDDiscount, Me.colIPDMappedCode, Me.colIPDItemCategoryID})
        Me.dgvInvoiceExtraBillItems.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceExtraBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvInvoiceExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceExtraBillItems.Location = New System.Drawing.Point(3, 3)
        Me.dgvInvoiceExtraBillItems.Name = "dgvInvoiceExtraBillItems"
        Me.dgvInvoiceExtraBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle37.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgvInvoiceExtraBillItems.Size = New System.Drawing.Size(943, 200)
        Me.dgvInvoiceExtraBillItems.TabIndex = 0
        Me.dgvInvoiceExtraBillItems.Text = "DataGridView1"
        '
        'colIPDInvoiceNo
        '
        Me.colIPDInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colIPDInvoiceNo.DefaultCellStyle = DataGridViewCellStyle20
        Me.colIPDInvoiceNo.HeaderText = "Invoice No"
        Me.colIPDInvoiceNo.Name = "colIPDInvoiceNo"
        Me.colIPDInvoiceNo.ReadOnly = True
        Me.colIPDInvoiceNo.Width = 75
        '
        'colIPDInvoiceDate
        '
        Me.colIPDInvoiceDate.DataPropertyName = "InvoiceDate"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDInvoiceDate.DefaultCellStyle = DataGridViewCellStyle21
        Me.colIPDInvoiceDate.HeaderText = "Invoice Date"
        Me.colIPDInvoiceDate.Name = "colIPDInvoiceDate"
        Me.colIPDInvoiceDate.ReadOnly = True
        Me.colIPDInvoiceDate.Width = 80
        '
        'colExtraBillNo
        '
        Me.colExtraBillNo.DataPropertyName = "ExtraBillNo"
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillNo.DefaultCellStyle = DataGridViewCellStyle22
        Me.colExtraBillNo.HeaderText = "Bill No"
        Me.colExtraBillNo.Name = "colExtraBillNo"
        Me.colExtraBillNo.ReadOnly = True
        Me.colExtraBillNo.Width = 80
        '
        'colIPDItemCode
        '
        Me.colIPDItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle23.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colIPDItemCode.DefaultCellStyle = DataGridViewCellStyle23
        Me.colIPDItemCode.HeaderText = "Item Code"
        Me.colIPDItemCode.Name = "colIPDItemCode"
        Me.colIPDItemCode.ReadOnly = True
        Me.colIPDItemCode.Width = 65
        '
        'colIPDItemName
        '
        Me.colIPDItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colIPDItemName.DefaultCellStyle = DataGridViewCellStyle24
        Me.colIPDItemName.HeaderText = "Item Name"
        Me.colIPDItemName.Name = "colIPDItemName"
        Me.colIPDItemName.ReadOnly = True
        Me.colIPDItemName.Width = 80
        '
        'colIPDQuantityBalance
        '
        Me.colIPDQuantityBalance.DataPropertyName = "QuantityBalance"
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDQuantityBalance.DefaultCellStyle = DataGridViewCellStyle25
        Me.colIPDQuantityBalance.HeaderText = "Quantity"
        Me.colIPDQuantityBalance.Name = "colIPDQuantityBalance"
        Me.colIPDQuantityBalance.ReadOnly = True
        '
        'colIPDUnitPrice
        '
        Me.colIPDUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.NullValue = Nothing
        Me.colIPDUnitPrice.DefaultCellStyle = DataGridViewCellStyle26
        Me.colIPDUnitPrice.HeaderText = "Unit Price"
        Me.colIPDUnitPrice.Name = "colIPDUnitPrice"
        Me.colIPDUnitPrice.Width = 60
        '
        'colIPDAmountBalance
        '
        Me.colIPDAmountBalance.DataPropertyName = "AmountBalance"
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDAmountBalance.DefaultCellStyle = DataGridViewCellStyle27
        Me.colIPDAmountBalance.HeaderText = "Amount"
        Me.colIPDAmountBalance.Name = "colIPDAmountBalance"
        Me.colIPDAmountBalance.ReadOnly = True
        Me.colIPDAmountBalance.Width = 80
        '
        'colIPDQuantity
        '
        Me.colIPDQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle28.Format = "N0"
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle28.NullValue = Nothing
        Me.colIPDQuantity.DefaultCellStyle = DataGridViewCellStyle28
        Me.colIPDQuantity.HeaderText = "Original Quantity"
        Me.colIPDQuantity.Name = "colIPDQuantity"
        '
        'colIPDAmount
        '
        Me.colIPDAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colIPDAmount.DefaultCellStyle = DataGridViewCellStyle29
        Me.colIPDAmount.HeaderText = "Original Amount"
        Me.colIPDAmount.Name = "colIPDAmount"
        Me.colIPDAmount.ReadOnly = True
        '
        'colIPDCategory
        '
        Me.colIPDCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle30.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colIPDCategory.DefaultCellStyle = DataGridViewCellStyle30
        Me.colIPDCategory.HeaderText = "Category"
        Me.colIPDCategory.Name = "colIPDCategory"
        Me.colIPDCategory.ReadOnly = True
        Me.colIPDCategory.Width = 70
        '
        'colIPDPayType
        '
        Me.colIPDPayType.DataPropertyName = "PayType"
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDPayType.DefaultCellStyle = DataGridViewCellStyle31
        Me.colIPDPayType.HeaderText = "Pay Type"
        Me.colIPDPayType.Name = "colIPDPayType"
        Me.colIPDPayType.ReadOnly = True
        '
        'colIPDPayNo
        '
        Me.colIPDPayNo.DataPropertyName = "PayNo"
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDPayNo.DefaultCellStyle = DataGridViewCellStyle32
        Me.colIPDPayNo.HeaderText = "Pay No"
        Me.colIPDPayNo.Name = "colIPDPayNo"
        Me.colIPDPayNo.ReadOnly = True
        '
        'colIPDPayStatus
        '
        Me.colIPDPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDPayStatus.DefaultCellStyle = DataGridViewCellStyle33
        Me.colIPDPayStatus.HeaderText = "Pay Status"
        Me.colIPDPayStatus.Name = "colIPDPayStatus"
        Me.colIPDPayStatus.ReadOnly = True
        '
        'colIPDDiscount
        '
        Me.colIPDDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle34.Format = "N2"
        DataGridViewCellStyle34.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colIPDDiscount.DefaultCellStyle = DataGridViewCellStyle34
        Me.colIPDDiscount.HeaderText = "Discount"
        Me.colIPDDiscount.Name = "colIPDDiscount"
        Me.colIPDDiscount.Width = 60
        '
        'colIPDMappedCode
        '
        Me.colIPDMappedCode.DataPropertyName = "MappedCustomCode"
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDMappedCode.DefaultCellStyle = DataGridViewCellStyle35
        Me.colIPDMappedCode.HeaderText = "Mapped Code"
        Me.colIPDMappedCode.Name = "colIPDMappedCode"
        Me.colIPDMappedCode.ReadOnly = True
        '
        'colIPDItemCategoryID
        '
        Me.colIPDItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDItemCategoryID.DefaultCellStyle = DataGridViewCellStyle36
        Me.colIPDItemCategoryID.HeaderText = "Item Category ID"
        Me.colIPDItemCategoryID.Name = "colIPDItemCategoryID"
        Me.colIPDItemCategoryID.ReadOnly = True
        Me.colIPDItemCategoryID.Visible = False
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(20, 463)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 95
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(130, 463)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 24)
        Me.btnPrint.TabIndex = 94
        Me.btnPrint.Text = "&Print"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(267, 463)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 96
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 7)
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
        Me.navVisits.Location = New System.Drawing.Point(171, 1)
        Me.navVisits.Margin = New System.Windows.Forms.Padding(4)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'chkIncludeIPDInvoices
        '
        Me.chkIncludeIPDInvoices.AutoSize = True
        Me.chkIncludeIPDInvoices.Location = New System.Drawing.Point(140, 183)
        Me.chkIncludeIPDInvoices.Name = "chkIncludeIPDInvoices"
        Me.chkIncludeIPDInvoices.Size = New System.Drawing.Size(128, 17)
        Me.chkIncludeIPDInvoices.TabIndex = 97
        Me.chkIncludeIPDInvoices.Text = " Include IPD Invoices"
        '
        'stbAmount
        '
        Me.stbAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmount.CapitalizeFirstLetter = False
        Me.stbAmount.Enabled = False
        Me.stbAmount.EntryErrorMSG = ""
        Me.stbAmount.Location = New System.Drawing.Point(140, 107)
        Me.stbAmount.MaxLength = 60
        Me.stbAmount.Name = "stbAmount"
        Me.stbAmount.RegularExpression = ""
        Me.stbAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmount.Size = New System.Drawing.Size(151, 20)
        Me.stbAmount.TabIndex = 99
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(10, 104)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(114, 20)
        Me.lblAmount.TabIndex = 98
        Me.lblAmount.Text = "Amount"
        '
        'stbAmountInWords
        '
        Me.stbAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountInWords.CapitalizeFirstLetter = False
        Me.stbAmountInWords.Enabled = False
        Me.stbAmountInWords.EntryErrorMSG = ""
        Me.stbAmountInWords.Location = New System.Drawing.Point(809, 56)
        Me.stbAmountInWords.MaxLength = 60
        Me.stbAmountInWords.Multiline = True
        Me.stbAmountInWords.Name = "stbAmountInWords"
        Me.stbAmountInWords.RegularExpression = ""
        Me.stbAmountInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountInWords.Size = New System.Drawing.Size(151, 38)
        Me.stbAmountInWords.TabIndex = 101
        '
        'lblAmountInWords
        '
        Me.lblAmountInWords.Location = New System.Drawing.Point(663, 58)
        Me.lblAmountInWords.Name = "lblAmountInWords"
        Me.lblAmountInWords.Size = New System.Drawing.Size(114, 20)
        Me.lblAmountInWords.TabIndex = 100
        Me.lblAmountInWords.Text = "Amount In Words"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BackColor = System.Drawing.SystemColors.Info
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(140, 134)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(151, 20)
        Me.stbPrimaryDoctor.TabIndex = 103
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 133)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(114, 21)
        Me.lblPrimaryDoctor.TabIndex = 102
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.stbClaimReferenceNo.Enabled = False
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(809, 124)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(151, 20)
        Me.stbClaimReferenceNo.TabIndex = 107
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(662, 126)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblClaimReferenceNo.TabIndex = 106
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(356, 59)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblInsuranceNo.TabIndex = 112
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'SmartTextBox1
        '
        Me.SmartTextBox1.BackColor = System.Drawing.SystemColors.Info
        Me.SmartTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SmartTextBox1.CapitalizeFirstLetter = False
        Me.SmartTextBox1.EntryErrorMSG = ""
        Me.SmartTextBox1.Location = New System.Drawing.Point(476, 62)
        Me.SmartTextBox1.MaxLength = 41
        Me.SmartTextBox1.Multiline = True
        Me.SmartTextBox1.Name = "SmartTextBox1"
        Me.SmartTextBox1.ReadOnly = True
        Me.SmartTextBox1.RegularExpression = ""
        Me.SmartTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SmartTextBox1.Size = New System.Drawing.Size(171, 31)
        Me.SmartTextBox1.TabIndex = 113
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(809, 100)
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(151, 20)
        Me.stbMemberCardNo.TabIndex = 105
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(662, 100)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(114, 18)
        Me.lblMemberCardNo.TabIndex = 104
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BackColor = System.Drawing.SystemColors.Info
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(810, 147)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(151, 20)
        Me.stbMainMemberName.TabIndex = 115
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(662, 147)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(120, 18)
        Me.lblMainMemberName.TabIndex = 114
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'frmVisitInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(979, 511)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.SmartTextBox1)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.stbAmountInWords)
        Me.Controls.Add(Me.lblAmountInWords)
        Me.Controls.Add(Me.stbAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.chkIncludeIPDInvoices)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.tbcIPDInvoiceDetails)
        Me.Controls.Add(Me.stbPackage)
        Me.Controls.Add(Me.lblPackageName)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lbInsuranceName)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmVisitInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visit Invoices"
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.tbcIPDInvoiceDetails.ResumeLayout(False)
        Me.tpgOPDInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.tpgIPDInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lbInsuranceName As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadVisits As System.Windows.Forms.Button
    Friend WithEvents stbPackage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents tbcIPDInvoiceDetails As SyncSoft.Common.Win.Controls.SmartTabControl
    Friend WithEvents tpgIPDInvoiceDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvInvoiceExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents tpgOPDInvoiceDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkIncludeIPDInvoices As System.Windows.Forms.CheckBox
    Friend WithEvents stbAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents stbAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountInWords As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents SmartTextBox1 As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents coIInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantityBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDInvoiceDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDQuantityBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDAmountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDPayNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class