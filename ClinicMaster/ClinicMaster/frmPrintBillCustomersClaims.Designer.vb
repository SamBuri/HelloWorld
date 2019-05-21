
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintBillCustomersClaims : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBillCustomersClaims))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.tbcClaims = New System.Windows.Forms.TabControl()
        Me.tpgClaimDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgClaimDetails = New System.Windows.Forms.TabPage()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
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
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcClaims.SuspendLayout()
        Me.tpgClaimDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgClaimDetails.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(675, 443)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(100, 24)
        Me.fbnClose.TabIndex = 48
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
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
        'tbcClaims
        '
        Me.tbcClaims.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDiagnosis)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDetails)
        Me.tbcClaims.HotTrack = True
        Me.tbcClaims.Location = New System.Drawing.Point(15, 203)
        Me.tbcClaims.Name = "tbcClaims"
        Me.tbcClaims.SelectedIndex = 0
        Me.tbcClaims.Size = New System.Drawing.Size(760, 234)
        Me.tbcClaims.TabIndex = 45
        '
        'tpgClaimDiagnosis
        '
        Me.tpgClaimDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgClaimDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDiagnosis.Name = "tpgClaimDiagnosis"
        Me.tpgClaimDiagnosis.Size = New System.Drawing.Size(752, 208)
        Me.tpgClaimDiagnosis.TabIndex = 2
        Me.tpgClaimDiagnosis.Tag = "ClaimDiagnosis"
        Me.tpgClaimDiagnosis.Text = "Diagnosis"
        Me.tpgClaimDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToAddRows = False
        Me.dgvDiagnosis.AllowUserToOrderColumns = True
        Me.dgvDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseName, Me.colDiseaseCategory})
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDiagnosis.Size = New System.Drawing.Size(752, 208)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseName
        '
        Me.colDiseaseName.DataPropertyName = "DiseaseName"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseName.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDiseaseName.HeaderText = "Diagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        Me.colDiseaseName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseName.Width = 400
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.DataPropertyName = "DiseaseCategories"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'tpgClaimDetails
        '
        Me.tpgClaimDetails.Controls.Add(Me.dgvInvoiceDetails)
        Me.tpgClaimDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDetails.Name = "tpgClaimDetails"
        Me.tpgClaimDetails.Size = New System.Drawing.Size(752, 208)
        Me.tpgClaimDetails.TabIndex = 1
        Me.tpgClaimDetails.Tag = "ClaimDetails"
        Me.tpgClaimDetails.Text = "Services"
        Me.tpgClaimDetails.UseVisualStyleBackColor = True
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToDeleteRows = False
        Me.dgvInvoiceDetails.AllowUserToOrderColumns = True
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colCategory, Me.colQuantity, Me.colUnitPrice, Me.colAmount})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.ReadOnly = True
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInvoiceDetails.RowHeadersVisible = False
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(752, 208)
        Me.dgvInvoiceDetails.TabIndex = 1
        Me.dgvInvoiceDetails.Text = "DataGridView1"
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
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(124, 443)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 47
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 443)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(103, 24)
        Me.btnPrint.TabIndex = 46
        Me.btnPrint.Text = "&Print"
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.stbClaimReferenceNo.Enabled = False
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(424, 69)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(171, 20)
        Me.stbClaimReferenceNo.TabIndex = 26
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(304, 69)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblClaimReferenceNo.TabIndex = 25
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(703, 129)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayValue.TabIndex = 42
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(605, 132)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(93, 20)
        Me.lblCoPayValue.TabIndex = 41
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(703, 108)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayPercent.TabIndex = 40
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(605, 111)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(93, 20)
        Me.lblCoPayPercent.TabIndex = 39
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(703, 87)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(71, 20)
        Me.stbCoPayType.TabIndex = 38
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(605, 89)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(93, 20)
        Me.lblCoPayType.TabIndex = 37
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(424, 143)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(171, 20)
        Me.stbInsuranceNo.TabIndex = 32
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(304, 144)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(114, 18)
        Me.lblInsuranceNo.TabIndex = 31
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(424, 164)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(171, 31)
        Me.stbInsuranceName.TabIndex = 34
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(304, 173)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(114, 18)
        Me.lblBillInsuranceName.TabIndex = 33
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(124, 154)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(169, 20)
        Me.stbPrimaryDoctor.TabIndex = 16
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(13, 154)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(101, 21)
        Me.lblPrimaryDoctor.TabIndex = 15
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(424, 111)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(171, 31)
        Me.stbBillCustomerName.TabIndex = 30
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(304, 117)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(114, 18)
        Me.lblBillCustomerName.TabIndex = 29
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(424, 90)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(171, 20)
        Me.stbBillNo.TabIndex = 28
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(304, 90)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(114, 18)
        Me.lblBillNo.TabIndex = 27
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(424, 48)
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(171, 20)
        Me.stbMemberCardNo.TabIndex = 24
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(304, 48)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(114, 18)
        Me.lblMemberCardNo.TabIndex = 23
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'btnLoadInvoices
        '
        Me.btnLoadInvoices.AccessibleDescription = ""
        Me.btnLoadInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadInvoices.Location = New System.Drawing.Point(247, 3)
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
        Me.stbInvoiceDate.Location = New System.Drawing.Point(124, 112)
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
        Me.stbVisitNo.Location = New System.Drawing.Point(124, 91)
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
        Me.stbPatientNo.Location = New System.Drawing.Point(124, 49)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(169, 20)
        Me.stbPatientNo.TabIndex = 6
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(13, 49)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(101, 21)
        Me.lblPatientsNo.TabIndex = 5
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(124, 70)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(169, 20)
        Me.stbVisitDate.TabIndex = 8
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(13, 70)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(101, 21)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(607, 33)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(167, 53)
        Me.stbAmountWords.TabIndex = 36
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(601, 9)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(173, 21)
        Me.lblAmountWords.TabIndex = 35
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbInvoiceAmount
        '
        Me.stbInvoiceAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceAmount.CapitalizeFirstLetter = False
        Me.stbInvoiceAmount.Enabled = False
        Me.stbInvoiceAmount.EntryErrorMSG = ""
        Me.stbInvoiceAmount.Location = New System.Drawing.Point(124, 133)
        Me.stbInvoiceAmount.MaxLength = 20
        Me.stbInvoiceAmount.Name = "stbInvoiceAmount"
        Me.stbInvoiceAmount.RegularExpression = ""
        Me.stbInvoiceAmount.Size = New System.Drawing.Size(169, 20)
        Me.stbInvoiceAmount.TabIndex = 14
        Me.stbInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInvoiceAmount
        '
        Me.lblInvoiceAmount.Location = New System.Drawing.Point(13, 132)
        Me.lblInvoiceAmount.Name = "lblInvoiceAmount"
        Me.lblInvoiceAmount.Size = New System.Drawing.Size(101, 21)
        Me.lblInvoiceAmount.TabIndex = 13
        Me.lblInvoiceAmount.Text = "Invoice Amount"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(13, 7)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(101, 21)
        Me.lblInvoiceNo.TabIndex = 0
        Me.lblInvoiceNo.Text = "Invoice No."
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(124, 7)
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
        Me.stbFullName.Location = New System.Drawing.Point(124, 28)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 4
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(13, 28)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(101, 21)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(13, 112)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(101, 21)
        Me.lblInvoiceDate.TabIndex = 11
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(13, 90)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(101, 21)
        Me.lblVisitNo.TabIndex = 9
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(124, 176)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(169, 20)
        Me.stbAge.TabIndex = 18
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(424, 5)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(171, 20)
        Me.stbGender.TabIndex = 20
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(13, 178)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(101, 18)
        Me.lblAge.TabIndex = 17
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(304, 7)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(114, 18)
        Me.lblGenderID.TabIndex = 19
        Me.lblGenderID.Text = "Gender"
        '
        'stbVisitType
        '
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.stbVisitType.Enabled = False
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(703, 150)
        Me.stbVisitType.MaxLength = 60
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitType.Size = New System.Drawing.Size(71, 20)
        Me.stbVisitType.TabIndex = 44
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(605, 151)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(92, 18)
        Me.lblVisitType.TabIndex = 43
        Me.lblVisitType.Text = "Visit Type"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(424, 27)
        Me.stbPhone.MaxLength = 60
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPhone.Size = New System.Drawing.Size(171, 20)
        Me.stbPhone.TabIndex = 22
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(304, 28)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(114, 18)
        Me.lblPhone.TabIndex = 21
        Me.lblPhone.Text = "Phone"
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
        Me.colItemName.Width = 300
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle7
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 80
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "DisplayAmount"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'frmPrintBillCustomersClaims
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(792, 474)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.stbVisitType)
        Me.Controls.Add(Me.lblVisitType)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
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
        Me.Controls.Add(Me.tbcClaims)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPrintBillCustomersClaims"
        Me.Text = "Print To-Bill Customers Claims"
        Me.tbcClaims.ResumeLayout(False)
        Me.tpgClaimDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgClaimDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents tbcClaims As System.Windows.Forms.TabControl
    Friend WithEvents tpgClaimDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents tpgClaimDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents colDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
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
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn

End Class