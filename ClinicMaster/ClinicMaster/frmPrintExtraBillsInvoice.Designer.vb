
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintExtraBillsInvoice : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintExtraBillsInvoice))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.dgvExtraBillsInvoice = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAttendingDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsEditBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsEditReturns = New System.Windows.Forms.ToolStripMenuItem()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.chkIncludePaidFor = New System.Windows.Forms.CheckBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.fbnAddBill = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.chkIncludeOPDBill = New System.Windows.Forms.CheckBox()
        Me.tbcExtraBillsInvoice = New System.Windows.Forms.TabControl()
        Me.tpgBillingForm = New System.Windows.Forms.TabPage()
        Me.tpgOPDBill = New System.Windows.Forms.TabPage()
        Me.dgvOPDBillsInvoice = New System.Windows.Forms.DataGridView()
        Me.colOPDInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colOPDItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDPrimaryDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgAdjustments = New System.Windows.Forms.TabPage()
        Me.dgvReturnedExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.tpgPendingBill = New System.Windows.Forms.TabPage()
        Me.dgvPendingBill = New System.Windows.Forms.DataGridView()
        Me.colPendingBillInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPendingBillRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillRoundDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillAttendingDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkIncludePendingBill = New System.Windows.Forms.CheckBox()
        Me.colReturnsInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colReturnsExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjustmentType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnsAttendingDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvExtraBillsInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.tbcExtraBillsInvoice.SuspendLayout()
        Me.tpgBillingForm.SuspendLayout()
        Me.tpgOPDBill.SuspendLayout()
        CType(Me.dgvOPDBillsInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAdjustments.SuspendLayout()
        CType(Me.dgvReturnedExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPendingBill.SuspendLayout()
        CType(Me.dgvPendingBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(142, 6)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(142, 90)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayValue.TabIndex = 11
        Me.nbxCoPayValue.Value = ""
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(142, 69)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayPercent.TabIndex = 9
        Me.nbxCoPayPercent.Value = ""
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(142, 48)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(170, 20)
        Me.stbCoPayType.TabIndex = 7
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(142, 27)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 5
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(451, 6)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(127, 20)
        Me.stbPatientNo.TabIndex = 17
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(710, 70)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(150, 20)
        Me.stbBillMode.TabIndex = 37
        '
        'stbVisitStatus
        '
        Me.stbVisitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitStatus.CapitalizeFirstLetter = False
        Me.stbVisitStatus.Enabled = False
        Me.stbVisitStatus.EntryErrorMSG = ""
        Me.stbVisitStatus.Location = New System.Drawing.Point(710, 49)
        Me.stbVisitStatus.MaxLength = 60
        Me.stbVisitStatus.Name = "stbVisitStatus"
        Me.stbVisitStatus.RegularExpression = ""
        Me.stbVisitStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitStatus.Size = New System.Drawing.Size(150, 20)
        Me.stbVisitStatus.TabIndex = 35
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(631, 4)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(83, 20)
        Me.stbAge.TabIndex = 29
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(710, 28)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(150, 20)
        Me.stbJoinDate.TabIndex = 33
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(777, 4)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(83, 20)
        Me.stbGender.TabIndex = 31
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(451, 27)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(127, 20)
        Me.stbFullName.TabIndex = 19
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(451, 69)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(127, 33)
        Me.stbBillCustomerName.TabIndex = 23
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(451, 48)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(127, 20)
        Me.stbBillNo.TabIndex = 21
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(834, 501)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(85, 24)
        Me.fbnClose.TabIndex = 48
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 6)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(91, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
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
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(114, 5)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(268, 2)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(12, 91)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayValue.TabIndex = 10
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(12, 70)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayPercent.TabIndex = 8
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(12, 48)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayType.TabIndex = 6
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(318, 6)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(127, 20)
        Me.lblPatientsNo.TabIndex = 16
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 27)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 4
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(584, 73)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(120, 18)
        Me.lblBillMode.TabIndex = 36
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(584, 49)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(120, 18)
        Me.lblVisitStatus.TabIndex = 34
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(584, 29)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(120, 18)
        Me.lblJoinDate.TabIndex = 32
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(584, 5)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(41, 18)
        Me.lblAge.TabIndex = 28
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(720, 5)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(51, 18)
        Me.lblGenderID.TabIndex = 30
        Me.lblGenderID.Text = "Gender"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(318, 27)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(127, 20)
        Me.lblFullName.TabIndex = 18
        Me.lblFullName.Text = "Full Name"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(318, 74)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(127, 20)
        Me.lblBillCustomerName.TabIndex = 22
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(318, 48)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(127, 20)
        Me.lblBillNo.TabIndex = 20
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(5, 167)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(870, 41)
        Me.pnlBill.TabIndex = 42
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(313, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(127, 20)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(137, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(170, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(446, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(409, 34)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(5, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(121, 20)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Total for Billing Form"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 501)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(85, 24)
        Me.btnPrint.TabIndex = 44
        Me.btnPrint.Text = "&Print"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(106, 501)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(85, 24)
        Me.btnPrintPreview.TabIndex = 45
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'dgvExtraBillsInvoice
        '
        Me.dgvExtraBillsInvoice.AllowUserToAddRows = False
        Me.dgvExtraBillsInvoice.AllowUserToDeleteRows = False
        Me.dgvExtraBillsInvoice.AllowUserToOrderColumns = True
        Me.dgvExtraBillsInvoice.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvExtraBillsInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvExtraBillsInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraBillsInvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraBillsInvoice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colExtraBillNo, Me.colExtraBillDate, Me.colItemName, Me.colItemCategory, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colPayStatus, Me.colEntryMode, Me.colAttendingDoctor, Me.colNotes})
        Me.dgvExtraBillsInvoice.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvExtraBillsInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtraBillsInvoice.EnableHeadersVisualStyles = False
        Me.dgvExtraBillsInvoice.GridColor = System.Drawing.Color.Khaki
        Me.dgvExtraBillsInvoice.Location = New System.Drawing.Point(0, 0)
        Me.dgvExtraBillsInvoice.Name = "dgvExtraBillsInvoice"
        Me.dgvExtraBillsInvoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraBillsInvoice.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvExtraBillsInvoice.RowHeadersVisible = False
        Me.dgvExtraBillsInvoice.Size = New System.Drawing.Size(910, 227)
        Me.dgvExtraBillsInvoice.TabIndex = 0
        Me.dgvExtraBillsInvoice.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colExtraBillNo
        '
        Me.colExtraBillNo.DataPropertyName = "ExtraBillNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExtraBillNo.HeaderText = "Bill No"
        Me.colExtraBillNo.Name = "colExtraBillNo"
        Me.colExtraBillNo.ReadOnly = True
        Me.colExtraBillNo.Width = 80
        '
        'colExtraBillDate
        '
        Me.colExtraBillDate.DataPropertyName = "ExtraBillDate"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.Format = "D"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colExtraBillDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.colExtraBillDate.HeaderText = "Bill Date"
        Me.colExtraBillDate.Name = "colExtraBillDate"
        Me.colExtraBillDate.ReadOnly = True
        Me.colExtraBillDate.Width = 80
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
        Me.colItemName.Width = 150
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle5
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 60
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 80
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle9
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'colEntryMode
        '
        Me.colEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colEntryMode.DefaultCellStyle = DataGridViewCellStyle10
        Me.colEntryMode.HeaderText = "Entry Mode"
        Me.colEntryMode.Name = "colEntryMode"
        Me.colEntryMode.ReadOnly = True
        Me.colEntryMode.Width = 70
        '
        'colAttendingDoctor
        '
        Me.colAttendingDoctor.DataPropertyName = "AttendingDoctor"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colAttendingDoctor.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAttendingDoctor.HeaderText = "Attending Doctor"
        Me.colAttendingDoctor.Name = "colAttendingDoctor"
        Me.colAttendingDoctor.ReadOnly = True
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle12
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        '
        'cmsInvoiceDetails
        '
        Me.cmsInvoiceDetails.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInvoiceDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceDetailsCopy, Me.cmsInvoiceDetailsSelectAll, Me.cmsInvoiceDetailsEditBill, Me.cmsInvoiceDetailsEditReturns})
        Me.cmsInvoiceDetails.Name = "cmsSearch"
        Me.cmsInvoiceDetails.Size = New System.Drawing.Size(138, 92)
        '
        'cmsInvoiceDetailsCopy
        '
        Me.cmsInvoiceDetailsCopy.Enabled = False
        Me.cmsInvoiceDetailsCopy.Image = CType(resources.GetObject("cmsInvoiceDetailsCopy.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsCopy.Name = "cmsInvoiceDetailsCopy"
        Me.cmsInvoiceDetailsCopy.Size = New System.Drawing.Size(137, 22)
        Me.cmsInvoiceDetailsCopy.Text = "Copy"
        Me.cmsInvoiceDetailsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsInvoiceDetailsSelectAll
        '
        Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Me.cmsInvoiceDetailsSelectAll.Name = "cmsInvoiceDetailsSelectAll"
        Me.cmsInvoiceDetailsSelectAll.Size = New System.Drawing.Size(137, 22)
        Me.cmsInvoiceDetailsSelectAll.Text = "Select All"
        '
        'cmsInvoiceDetailsEditBill
        '
        Me.cmsInvoiceDetailsEditBill.Enabled = False
        Me.cmsInvoiceDetailsEditBill.Image = CType(resources.GetObject("cmsInvoiceDetailsEditBill.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsEditBill.Name = "cmsInvoiceDetailsEditBill"
        Me.cmsInvoiceDetailsEditBill.Size = New System.Drawing.Size(137, 22)
        Me.cmsInvoiceDetailsEditBill.Tag = "ExtraBills"
        Me.cmsInvoiceDetailsEditBill.Text = "Edit Bill"
        '
        'cmsInvoiceDetailsEditReturns
        '
        Me.cmsInvoiceDetailsEditReturns.Enabled = False
        Me.cmsInvoiceDetailsEditReturns.Image = CType(resources.GetObject("cmsInvoiceDetailsEditReturns.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsEditReturns.Name = "cmsInvoiceDetailsEditReturns"
        Me.cmsInvoiceDetailsEditReturns.Size = New System.Drawing.Size(137, 22)
        Me.cmsInvoiceDetailsEditReturns.Tag = "ReturnedExtraBillItems"
        Me.cmsInvoiceDetailsEditReturns.Text = "Edit Returns"
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(451, 103)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(127, 20)
        Me.nbxCashAccountBalance.TabIndex = 25
        Me.nbxCashAccountBalance.Value = ""
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(318, 103)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(127, 20)
        Me.lblCashAccountBalance.TabIndex = 24
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'chkIncludePaidFor
        '
        Me.chkIncludePaidFor.AccessibleDescription = ""
        Me.chkIncludePaidFor.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludePaidFor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludePaidFor.Location = New System.Drawing.Point(10, 146)
        Me.chkIncludePaidFor.Name = "chkIncludePaidFor"
        Me.chkIncludePaidFor.Size = New System.Drawing.Size(143, 20)
        Me.chkIncludePaidFor.TabIndex = 14
        Me.chkIncludePaidFor.Text = "Include Paid For"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(142, 111)
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(170, 20)
        Me.stbMemberCardNo.TabIndex = 13
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(12, 112)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(124, 20)
        Me.lblMemberCardNo.TabIndex = 12
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(451, 124)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.ReadOnly = True
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(127, 20)
        Me.stbClaimReferenceNo.TabIndex = 27
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(318, 126)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(127, 20)
        Me.lblClaimReferenceNo.TabIndex = 26
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'fbnAddBill
        '
        Me.fbnAddBill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnAddBill.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnAddBill.Enabled = False
        Me.fbnAddBill.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnAddBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnAddBill.Location = New System.Drawing.Point(743, 501)
        Me.fbnAddBill.Name = "fbnAddBill"
        Me.fbnAddBill.Size = New System.Drawing.Size(85, 24)
        Me.fbnAddBill.TabIndex = 47
        Me.fbnAddBill.Tag = "ExtraBills"
        Me.fbnAddBill.Text = "&Add Bill"
        Me.fbnAddBill.UseVisualStyleBackColor = False
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(710, 91)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(150, 34)
        Me.stbInsuranceName.TabIndex = 39
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(584, 99)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(120, 18)
        Me.lblBillInsuranceName.TabIndex = 38
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'chkIncludeOPDBill
        '
        Me.chkIncludeOPDBill.AccessibleDescription = ""
        Me.chkIncludeOPDBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeOPDBill.Enabled = False
        Me.chkIncludeOPDBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludeOPDBill.Location = New System.Drawing.Point(166, 146)
        Me.chkIncludeOPDBill.Name = "chkIncludeOPDBill"
        Me.chkIncludeOPDBill.Size = New System.Drawing.Size(146, 20)
        Me.chkIncludeOPDBill.TabIndex = 15
        Me.chkIncludeOPDBill.Text = "Include OPD Bill"
        '
        'tbcExtraBillsInvoice
        '
        Me.tbcExtraBillsInvoice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcExtraBillsInvoice.Controls.Add(Me.tpgBillingForm)
        Me.tbcExtraBillsInvoice.Controls.Add(Me.tpgOPDBill)
        Me.tbcExtraBillsInvoice.Controls.Add(Me.tpgAdjustments)
        Me.tbcExtraBillsInvoice.Controls.Add(Me.tpgPendingBill)
        Me.tbcExtraBillsInvoice.HotTrack = True
        Me.tbcExtraBillsInvoice.Location = New System.Drawing.Point(5, 214)
        Me.tbcExtraBillsInvoice.Name = "tbcExtraBillsInvoice"
        Me.tbcExtraBillsInvoice.SelectedIndex = 0
        Me.tbcExtraBillsInvoice.Size = New System.Drawing.Size(918, 253)
        Me.tbcExtraBillsInvoice.TabIndex = 43
        '
        'tpgBillingForm
        '
        Me.tpgBillingForm.Controls.Add(Me.dgvExtraBillsInvoice)
        Me.tpgBillingForm.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillingForm.Name = "tpgBillingForm"
        Me.tpgBillingForm.Size = New System.Drawing.Size(910, 227)
        Me.tpgBillingForm.TabIndex = 6
        Me.tpgBillingForm.Tag = "IPDInvoices"
        Me.tpgBillingForm.Text = "Billing Form"
        Me.tpgBillingForm.UseVisualStyleBackColor = True
        '
        'tpgOPDBill
        '
        Me.tpgOPDBill.Controls.Add(Me.dgvOPDBillsInvoice)
        Me.tpgOPDBill.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDBill.Name = "tpgOPDBill"
        Me.tpgOPDBill.Size = New System.Drawing.Size(910, 227)
        Me.tpgOPDBill.TabIndex = 0
        Me.tpgOPDBill.Tag = "Invoices"
        Me.tpgOPDBill.Text = "OPD Bill"
        Me.tpgOPDBill.UseVisualStyleBackColor = True
        '
        'dgvOPDBillsInvoice
        '
        Me.dgvOPDBillsInvoice.AllowUserToAddRows = False
        Me.dgvOPDBillsInvoice.AllowUserToDeleteRows = False
        Me.dgvOPDBillsInvoice.AllowUserToOrderColumns = True
        Me.dgvOPDBillsInvoice.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDBillsInvoice.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDBillsInvoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDBillsInvoice.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvOPDBillsInvoice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOPDInclude, Me.colOPDItemName, Me.colOPDItemCategory, Me.colOPDQuantity, Me.colOPDUnitPrice, Me.colOPDAmount, Me.colOPDPayStatus, Me.colOPDItemStatus, Me.colOPDPrimaryDoctor})
        Me.dgvOPDBillsInvoice.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvOPDBillsInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOPDBillsInvoice.EnableHeadersVisualStyles = False
        Me.dgvOPDBillsInvoice.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDBillsInvoice.Location = New System.Drawing.Point(0, 0)
        Me.dgvOPDBillsInvoice.Name = "dgvOPDBillsInvoice"
        Me.dgvOPDBillsInvoice.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDBillsInvoice.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvOPDBillsInvoice.RowHeadersVisible = False
        Me.dgvOPDBillsInvoice.Size = New System.Drawing.Size(910, 227)
        Me.dgvOPDBillsInvoice.TabIndex = 44
        Me.dgvOPDBillsInvoice.Text = "DataGridView1"
        '
        'colOPDInclude
        '
        Me.colOPDInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOPDInclude.HeaderText = "Include"
        Me.colOPDInclude.Name = "colOPDInclude"
        Me.colOPDInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOPDInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOPDInclude.Width = 50
        '
        'colOPDItemName
        '
        Me.colOPDItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colOPDItemName.DefaultCellStyle = DataGridViewCellStyle15
        Me.colOPDItemName.HeaderText = "Item Name"
        Me.colOPDItemName.Name = "colOPDItemName"
        Me.colOPDItemName.ReadOnly = True
        Me.colOPDItemName.Width = 250
        '
        'colOPDItemCategory
        '
        Me.colOPDItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colOPDItemCategory.DefaultCellStyle = DataGridViewCellStyle16
        Me.colOPDItemCategory.HeaderText = "Category"
        Me.colOPDItemCategory.Name = "colOPDItemCategory"
        Me.colOPDItemCategory.ReadOnly = True
        Me.colOPDItemCategory.Width = 60
        '
        'colOPDQuantity
        '
        Me.colOPDQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colOPDQuantity.DefaultCellStyle = DataGridViewCellStyle17
        Me.colOPDQuantity.HeaderText = "Quantity"
        Me.colOPDQuantity.Name = "colOPDQuantity"
        Me.colOPDQuantity.ReadOnly = True
        Me.colOPDQuantity.Width = 50
        '
        'colOPDUnitPrice
        '
        Me.colOPDUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.NullValue = Nothing
        Me.colOPDUnitPrice.DefaultCellStyle = DataGridViewCellStyle18
        Me.colOPDUnitPrice.HeaderText = "Unit Price"
        Me.colOPDUnitPrice.Name = "colOPDUnitPrice"
        Me.colOPDUnitPrice.ReadOnly = True
        Me.colOPDUnitPrice.Width = 80
        '
        'colOPDAmount
        '
        Me.colOPDAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.NullValue = Nothing
        Me.colOPDAmount.DefaultCellStyle = DataGridViewCellStyle19
        Me.colOPDAmount.HeaderText = "Amount"
        Me.colOPDAmount.Name = "colOPDAmount"
        Me.colOPDAmount.ReadOnly = True
        Me.colOPDAmount.Width = 80
        '
        'colOPDPayStatus
        '
        Me.colOPDPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colOPDPayStatus.DefaultCellStyle = DataGridViewCellStyle20
        Me.colOPDPayStatus.HeaderText = "Pay Status"
        Me.colOPDPayStatus.Name = "colOPDPayStatus"
        Me.colOPDPayStatus.ReadOnly = True
        Me.colOPDPayStatus.Width = 70
        '
        'colOPDItemStatus
        '
        Me.colOPDItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colOPDItemStatus.DefaultCellStyle = DataGridViewCellStyle21
        Me.colOPDItemStatus.HeaderText = "Item Status"
        Me.colOPDItemStatus.Name = "colOPDItemStatus"
        Me.colOPDItemStatus.ReadOnly = True
        Me.colOPDItemStatus.Width = 70
        '
        'colOPDPrimaryDoctor
        '
        Me.colOPDPrimaryDoctor.DataPropertyName = "PrimaryDoctor"
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colOPDPrimaryDoctor.DefaultCellStyle = DataGridViewCellStyle22
        Me.colOPDPrimaryDoctor.HeaderText = "Primary Doctor"
        Me.colOPDPrimaryDoctor.Name = "colOPDPrimaryDoctor"
        Me.colOPDPrimaryDoctor.ReadOnly = True
        Me.colOPDPrimaryDoctor.Width = 120
        '
        'tpgAdjustments
        '
        Me.tpgAdjustments.Controls.Add(Me.dgvReturnedExtraBillItems)
        Me.tpgAdjustments.Location = New System.Drawing.Point(4, 22)
        Me.tpgAdjustments.Name = "tpgAdjustments"
        Me.tpgAdjustments.Size = New System.Drawing.Size(910, 227)
        Me.tpgAdjustments.TabIndex = 7
        Me.tpgAdjustments.Tag = "BillAdjustments"
        Me.tpgAdjustments.Text = "Adjustments"
        Me.tpgAdjustments.UseVisualStyleBackColor = True
        '
        'dgvReturnedExtraBillItems
        '
        Me.dgvReturnedExtraBillItems.AllowUserToAddRows = False
        Me.dgvReturnedExtraBillItems.AllowUserToDeleteRows = False
        Me.dgvReturnedExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvReturnedExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvReturnedExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReturnedExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgvReturnedExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReturnsInclude, Me.colReturnsExtraBillNo, Me.colReturnDate, Me.colReturnsItemName, Me.colReturnsItemCategory, Me.colAdjustmentType, Me.colReturnsQuantity, Me.colReturnsUnitPrice, Me.colReturnsAmount, Me.colReturnsPayStatus, Me.colReturnsEntryMode, Me.colReturnsAttendingDoctor})
        Me.dgvReturnedExtraBillItems.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvReturnedExtraBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReturnedExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvReturnedExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvReturnedExtraBillItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvReturnedExtraBillItems.Name = "dgvReturnedExtraBillItems"
        Me.dgvReturnedExtraBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle35.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvReturnedExtraBillItems.RowHeadersVisible = False
        Me.dgvReturnedExtraBillItems.Size = New System.Drawing.Size(910, 227)
        Me.dgvReturnedExtraBillItems.TabIndex = 46
        Me.dgvReturnedExtraBillItems.Text = "DataGridView1"
        '
        'tpgPendingBill
        '
        Me.tpgPendingBill.Controls.Add(Me.dgvPendingBill)
        Me.tpgPendingBill.Location = New System.Drawing.Point(4, 22)
        Me.tpgPendingBill.Name = "tpgPendingBill"
        Me.tpgPendingBill.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPendingBill.Size = New System.Drawing.Size(910, 227)
        Me.tpgPendingBill.TabIndex = 8
        Me.tpgPendingBill.Text = "Pending Bill"
        Me.tpgPendingBill.UseVisualStyleBackColor = True
        '
        'dgvPendingBill
        '
        Me.dgvPendingBill.AllowUserToAddRows = False
        Me.dgvPendingBill.AllowUserToDeleteRows = False
        Me.dgvPendingBill.AllowUserToOrderColumns = True
        Me.dgvPendingBill.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingBill.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingBill.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle36.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingBill.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle36
        Me.dgvPendingBill.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPendingBillInclude, Me.colPendingBillRoundNo, Me.colPendingBillRoundDateTime, Me.colPendingBillItemName, Me.colPendingBillCategory, Me.colPendingBillQuantity, Me.colPendingBillUnitPrice, Me.colPendingBillAmount, Me.colPendingBillPayStatus, Me.colPendingBillItemStatus, Me.colPendingBillAttendingDoctor})
        Me.dgvPendingBill.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvPendingBill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingBill.EnableHeadersVisualStyles = False
        Me.dgvPendingBill.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingBill.Location = New System.Drawing.Point(3, 3)
        Me.dgvPendingBill.Name = "dgvPendingBill"
        Me.dgvPendingBill.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingBill.RowHeadersDefaultCellStyle = DataGridViewCellStyle47
        Me.dgvPendingBill.RowHeadersVisible = False
        Me.dgvPendingBill.Size = New System.Drawing.Size(904, 221)
        Me.dgvPendingBill.TabIndex = 47
        Me.dgvPendingBill.Text = "DataGridView1"
        '
        'colPendingBillInclude
        '
        Me.colPendingBillInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPendingBillInclude.HeaderText = "Include"
        Me.colPendingBillInclude.Name = "colPendingBillInclude"
        Me.colPendingBillInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPendingBillInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPendingBillInclude.Width = 50
        '
        'colPendingBillRoundNo
        '
        Me.colPendingBillRoundNo.DataPropertyName = "RoundNo"
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillRoundNo.DefaultCellStyle = DataGridViewCellStyle37
        Me.colPendingBillRoundNo.HeaderText = "Round No"
        Me.colPendingBillRoundNo.Name = "colPendingBillRoundNo"
        Me.colPendingBillRoundNo.ReadOnly = True
        '
        'colPendingBillRoundDateTime
        '
        Me.colPendingBillRoundDateTime.DataPropertyName = "RoundDateTime"
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillRoundDateTime.DefaultCellStyle = DataGridViewCellStyle38
        Me.colPendingBillRoundDateTime.HeaderText = "Round Date Time"
        Me.colPendingBillRoundDateTime.Name = "colPendingBillRoundDateTime"
        Me.colPendingBillRoundDateTime.ReadOnly = True
        Me.colPendingBillRoundDateTime.Width = 120
        '
        'colPendingBillItemName
        '
        Me.colPendingBillItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colPendingBillItemName.DefaultCellStyle = DataGridViewCellStyle39
        Me.colPendingBillItemName.HeaderText = "Item Name"
        Me.colPendingBillItemName.Name = "colPendingBillItemName"
        Me.colPendingBillItemName.ReadOnly = True
        Me.colPendingBillItemName.Width = 150
        '
        'colPendingBillCategory
        '
        Me.colPendingBillCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle40.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colPendingBillCategory.DefaultCellStyle = DataGridViewCellStyle40
        Me.colPendingBillCategory.HeaderText = "Category"
        Me.colPendingBillCategory.Name = "colPendingBillCategory"
        Me.colPendingBillCategory.ReadOnly = True
        Me.colPendingBillCategory.Width = 60
        '
        'colPendingBillQuantity
        '
        Me.colPendingBillQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle41.Format = "N0"
        DataGridViewCellStyle41.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle41.NullValue = Nothing
        Me.colPendingBillQuantity.DefaultCellStyle = DataGridViewCellStyle41
        Me.colPendingBillQuantity.HeaderText = "Quantity"
        Me.colPendingBillQuantity.Name = "colPendingBillQuantity"
        Me.colPendingBillQuantity.ReadOnly = True
        Me.colPendingBillQuantity.Width = 50
        '
        'colPendingBillUnitPrice
        '
        Me.colPendingBillUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle42.NullValue = Nothing
        Me.colPendingBillUnitPrice.DefaultCellStyle = DataGridViewCellStyle42
        Me.colPendingBillUnitPrice.HeaderText = "Unit Price"
        Me.colPendingBillUnitPrice.Name = "colPendingBillUnitPrice"
        Me.colPendingBillUnitPrice.ReadOnly = True
        Me.colPendingBillUnitPrice.Width = 65
        '
        'colPendingBillAmount
        '
        Me.colPendingBillAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle43.Format = "N2"
        DataGridViewCellStyle43.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle43.NullValue = Nothing
        Me.colPendingBillAmount.DefaultCellStyle = DataGridViewCellStyle43
        Me.colPendingBillAmount.HeaderText = "Amount"
        Me.colPendingBillAmount.Name = "colPendingBillAmount"
        Me.colPendingBillAmount.ReadOnly = True
        Me.colPendingBillAmount.Width = 65
        '
        'colPendingBillPayStatus
        '
        Me.colPendingBillPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillPayStatus.DefaultCellStyle = DataGridViewCellStyle44
        Me.colPendingBillPayStatus.HeaderText = "Pay Status"
        Me.colPendingBillPayStatus.Name = "colPendingBillPayStatus"
        Me.colPendingBillPayStatus.ReadOnly = True
        Me.colPendingBillPayStatus.Width = 70
        '
        'colPendingBillItemStatus
        '
        Me.colPendingBillItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemStatus.DefaultCellStyle = DataGridViewCellStyle45
        Me.colPendingBillItemStatus.HeaderText = "Item Status"
        Me.colPendingBillItemStatus.Name = "colPendingBillItemStatus"
        Me.colPendingBillItemStatus.ReadOnly = True
        Me.colPendingBillItemStatus.Width = 70
        '
        'colPendingBillAttendingDoctor
        '
        Me.colPendingBillAttendingDoctor.DataPropertyName = "AttendingDoctor"
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillAttendingDoctor.DefaultCellStyle = DataGridViewCellStyle46
        Me.colPendingBillAttendingDoctor.HeaderText = "Attending Doctor"
        Me.colPendingBillAttendingDoctor.Name = "colPendingBillAttendingDoctor"
        Me.colPendingBillAttendingDoctor.ReadOnly = True
        Me.colPendingBillAttendingDoctor.Width = 120
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(710, 126)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(150, 20)
        Me.stbMainMemberName.TabIndex = 41
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(584, 126)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(120, 18)
        Me.lblMainMemberName.TabIndex = 40
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(197, 473)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(540, 61)
        Me.pnlNavigateVisits.TabIndex = 46
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(203, 5)
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
        Me.navVisits.Location = New System.Drawing.Point(65, 25)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'chkIncludePendingBill
        '
        Me.chkIncludePendingBill.AccessibleDescription = ""
        Me.chkIncludePendingBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludePendingBill.Enabled = False
        Me.chkIncludePendingBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludePendingBill.Location = New System.Drawing.Point(321, 146)
        Me.chkIncludePendingBill.Name = "chkIncludePendingBill"
        Me.chkIncludePendingBill.Size = New System.Drawing.Size(143, 20)
        Me.chkIncludePendingBill.TabIndex = 49
        Me.chkIncludePendingBill.Text = "Include Pending Bill"
        '
        'colReturnsInclude
        '
        Me.colReturnsInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colReturnsInclude.HeaderText = "Include"
        Me.colReturnsInclude.Name = "colReturnsInclude"
        Me.colReturnsInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colReturnsInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colReturnsInclude.Width = 50
        '
        'colReturnsExtraBillNo
        '
        Me.colReturnsExtraBillNo.DataPropertyName = "ExtraBillNo"
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnsExtraBillNo.DefaultCellStyle = DataGridViewCellStyle25
        Me.colReturnsExtraBillNo.HeaderText = "Bill No"
        Me.colReturnsExtraBillNo.Name = "colReturnsExtraBillNo"
        Me.colReturnsExtraBillNo.ReadOnly = True
        Me.colReturnsExtraBillNo.Width = 60
        '
        'colReturnDate
        '
        Me.colReturnDate.DataPropertyName = "ReturnDate"
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnDate.DefaultCellStyle = DataGridViewCellStyle26
        Me.colReturnDate.HeaderText = "Return Date"
        Me.colReturnDate.Name = "colReturnDate"
        Me.colReturnDate.ReadOnly = True
        Me.colReturnDate.Width = 80
        '
        'colReturnsItemName
        '
        Me.colReturnsItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReturnsItemName.DefaultCellStyle = DataGridViewCellStyle27
        Me.colReturnsItemName.HeaderText = "Item Name"
        Me.colReturnsItemName.Name = "colReturnsItemName"
        Me.colReturnsItemName.ReadOnly = True
        Me.colReturnsItemName.Width = 150
        '
        'colReturnsItemCategory
        '
        Me.colReturnsItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReturnsItemCategory.DefaultCellStyle = DataGridViewCellStyle28
        Me.colReturnsItemCategory.HeaderText = "Category"
        Me.colReturnsItemCategory.Name = "colReturnsItemCategory"
        Me.colReturnsItemCategory.ReadOnly = True
        Me.colReturnsItemCategory.Width = 60
        '
        'colAdjustmentType
        '
        Me.colAdjustmentType.DataPropertyName = "AdjustmentType"
        Me.colAdjustmentType.HeaderText = "Adjustment Type"
        Me.colAdjustmentType.Name = "colAdjustmentType"
        Me.colAdjustmentType.ReadOnly = True
        '
        'colReturnsQuantity
        '
        Me.colReturnsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle29.Format = "N0"
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colReturnsQuantity.DefaultCellStyle = DataGridViewCellStyle29
        Me.colReturnsQuantity.HeaderText = "Quantity"
        Me.colReturnsQuantity.Name = "colReturnsQuantity"
        Me.colReturnsQuantity.ReadOnly = True
        Me.colReturnsQuantity.Width = 50
        '
        'colReturnsUnitPrice
        '
        Me.colReturnsUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle30.Format = "N2"
        DataGridViewCellStyle30.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle30.NullValue = Nothing
        Me.colReturnsUnitPrice.DefaultCellStyle = DataGridViewCellStyle30
        Me.colReturnsUnitPrice.HeaderText = "Unit Price"
        Me.colReturnsUnitPrice.Name = "colReturnsUnitPrice"
        Me.colReturnsUnitPrice.ReadOnly = True
        Me.colReturnsUnitPrice.Width = 65
        '
        'colReturnsAmount
        '
        Me.colReturnsAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle31.Format = "N2"
        DataGridViewCellStyle31.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle31.NullValue = Nothing
        Me.colReturnsAmount.DefaultCellStyle = DataGridViewCellStyle31
        Me.colReturnsAmount.HeaderText = "Amount"
        Me.colReturnsAmount.Name = "colReturnsAmount"
        Me.colReturnsAmount.ReadOnly = True
        Me.colReturnsAmount.Width = 65
        '
        'colReturnsPayStatus
        '
        Me.colReturnsPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnsPayStatus.DefaultCellStyle = DataGridViewCellStyle32
        Me.colReturnsPayStatus.HeaderText = "Pay Status"
        Me.colReturnsPayStatus.Name = "colReturnsPayStatus"
        Me.colReturnsPayStatus.ReadOnly = True
        Me.colReturnsPayStatus.Width = 70
        '
        'colReturnsEntryMode
        '
        Me.colReturnsEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnsEntryMode.DefaultCellStyle = DataGridViewCellStyle33
        Me.colReturnsEntryMode.HeaderText = "Entry Mode"
        Me.colReturnsEntryMode.Name = "colReturnsEntryMode"
        Me.colReturnsEntryMode.ReadOnly = True
        Me.colReturnsEntryMode.Width = 70
        '
        'colReturnsAttendingDoctor
        '
        Me.colReturnsAttendingDoctor.DataPropertyName = "AttendingDoctor"
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnsAttendingDoctor.DefaultCellStyle = DataGridViewCellStyle34
        Me.colReturnsAttendingDoctor.HeaderText = "Attending Doctor"
        Me.colReturnsAttendingDoctor.Name = "colReturnsAttendingDoctor"
        Me.colReturnsAttendingDoctor.ReadOnly = True
        Me.colReturnsAttendingDoctor.Width = 120
        '
        'frmPrintExtraBillsInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(938, 540)
        Me.Controls.Add(Me.chkIncludePendingBill)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.tbcExtraBillsInvoice)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.chkIncludeOPDBill)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.fbnAddBill)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkIncludePaidFor)
        Me.Controls.Add(Me.nbxCashAccountBalance)
        Me.Controls.Add(Me.lblCashAccountBalance)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbVisitStatus)
        Me.Controls.Add(Me.lblVisitStatus)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPrintExtraBillsInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Billing Form Invoice"
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvExtraBillsInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.tbcExtraBillsInvoice.ResumeLayout(False)
        Me.tpgBillingForm.ResumeLayout(False)
        Me.tpgOPDBill.ResumeLayout(False)
        CType(Me.dgvOPDBillsInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAdjustments.ResumeLayout(False)
        CType(Me.dgvReturnedExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPendingBill.ResumeLayout(False)
        CType(Me.dgvPendingBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbVisitStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents dgvExtraBillsInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents chkIncludePaidFor As System.Windows.Forms.CheckBox
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents cmsInvoiceDetailsEditBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbnAddBill As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents chkIncludeOPDBill As System.Windows.Forms.CheckBox
    Friend WithEvents tbcExtraBillsInvoice As System.Windows.Forms.TabControl
    Friend WithEvents tpgBillingForm As System.Windows.Forms.TabPage
    Friend WithEvents tpgOPDBill As System.Windows.Forms.TabPage
    Friend WithEvents dgvOPDBillsInvoice As System.Windows.Forms.DataGridView
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraBillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAttendingDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOPDItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents tpgAdjustments As System.Windows.Forms.TabPage
    Friend WithEvents dgvReturnedExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents cmsInvoiceDetailsEditReturns As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents tpgPendingBill As System.Windows.Forms.TabPage
    Friend WithEvents dgvPendingBill As System.Windows.Forms.DataGridView
    Friend WithEvents chkIncludePendingBill As System.Windows.Forms.CheckBox
    Friend WithEvents colPendingBillInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPendingBillRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillRoundDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillAttendingDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colReturnsExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjustmentType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnsAttendingDoctor As System.Windows.Forms.DataGridViewTextBoxColumn

End Class