<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPrintBillsInvoice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBillsInvoice))
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnLoadInvoices = New System.Windows.Forms.Button()
        Me.stbInvoiceDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbInvoiceAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceAmount = New System.Windows.Forms.Label()
        Me.grpPaymentDetails = New System.Windows.Forms.GroupBox()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCompany = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.stbEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.stbStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.grpPaymentDetails.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 428)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 24)
        Me.btnPrint.TabIndex = 22
        Me.btnPrint.Text = "&Print"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(815, 428)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 24)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "&Close"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(122, 428)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 23
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnLoadInvoices
        '
        Me.btnLoadInvoices.AccessibleDescription = ""
        Me.btnLoadInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadInvoices.Location = New System.Drawing.Point(343, 4)
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
        Me.stbInvoiceDate.Location = New System.Drawing.Point(204, 29)
        Me.stbInvoiceDate.MaxLength = 20
        Me.stbInvoiceDate.Name = "stbInvoiceDate"
        Me.stbInvoiceDate.RegularExpression = ""
        Me.stbInvoiceDate.Size = New System.Drawing.Size(185, 20)
        Me.stbInvoiceDate.TabIndex = 4
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(756, 31)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(162, 60)
        Me.stbAmountWords.TabIndex = 19
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(753, 7)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(165, 21)
        Me.lblAmountWords.TabIndex = 18
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbInvoiceAmount
        '
        Me.stbInvoiceAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceAmount.CapitalizeFirstLetter = False
        Me.stbInvoiceAmount.Enabled = False
        Me.stbInvoiceAmount.EntryErrorMSG = ""
        Me.stbInvoiceAmount.Location = New System.Drawing.Point(541, 55)
        Me.stbInvoiceAmount.MaxLength = 20
        Me.stbInvoiceAmount.Name = "stbInvoiceAmount"
        Me.stbInvoiceAmount.RegularExpression = ""
        Me.stbInvoiceAmount.Size = New System.Drawing.Size(182, 20)
        Me.stbInvoiceAmount.TabIndex = 14
        Me.stbInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInvoiceAmount
        '
        Me.lblInvoiceAmount.Location = New System.Drawing.Point(421, 56)
        Me.lblInvoiceAmount.Name = "lblInvoiceAmount"
        Me.lblInvoiceAmount.Size = New System.Drawing.Size(93, 21)
        Me.lblInvoiceAmount.TabIndex = 13
        Me.lblInvoiceAmount.Text = "Invoice Amount"
        '
        'grpPaymentDetails
        '
        Me.grpPaymentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPaymentDetails.Controls.Add(Me.dgvInvoiceDetails)
        Me.grpPaymentDetails.Location = New System.Drawing.Point(5, 126)
        Me.grpPaymentDetails.Name = "grpPaymentDetails"
        Me.grpPaymentDetails.Size = New System.Drawing.Size(913, 296)
        Me.grpPaymentDetails.TabIndex = 21
        Me.grpPaymentDetails.TabStop = False
        Me.grpPaymentDetails.Text = "Bill Invoice Details"
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
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.ColCompany, Me.colVisitNo, Me.colVisitDate, Me.colFullName, Me.colGender, Me.colAge, Me.colMemberCardNo, Me.colAmountBalance, Me.colAmount})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.ReadOnly = True
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvInvoiceDetails.RowHeadersVisible = False
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(907, 277)
        Me.dgvInvoiceDetails.TabIndex = 0
        Me.dgvInvoiceDetails.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colPatientNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        '
        'ColCompany
        '
        Me.ColCompany.DataPropertyName = "BillCustomerName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.ColCompany.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColCompany.HeaderText = "Company"
        Me.ColCompany.Name = "ColCompany"
        Me.ColCompany.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colVisitDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colFullName.DefaultCellStyle = DataGridViewCellStyle6
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 150
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colGender.DefaultCellStyle = DataGridViewCellStyle7
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 60
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colAge.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 40
        '
        'colMemberCardNo
        '
        Me.colMemberCardNo.DataPropertyName = "MemberCardNo"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colMemberCardNo.DefaultCellStyle = DataGridViewCellStyle9
        Me.colMemberCardNo.HeaderText = "Member Card No"
        Me.colMemberCardNo.Name = "colMemberCardNo"
        Me.colMemberCardNo.ReadOnly = True
        '
        'colAmountBalance
        '
        Me.colAmountBalance.DataPropertyName = "AmountBalance"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colAmountBalance.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAmountBalance.HeaderText = "Amount "
        Me.colAmountBalance.Name = "colAmountBalance"
        Me.colAmountBalance.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "VisitAmount"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAmount.HeaderText = "Original Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
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
        Me.lblInvoiceNo.Location = New System.Drawing.Point(12, 7)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(172, 21)
        Me.lblInvoiceNo.TabIndex = 0
        Me.lblInvoiceNo.Text = "Invoice No."
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(204, 8)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(133, 20)
        Me.stbInvoiceNo.TabIndex = 1
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(12, 28)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(172, 21)
        Me.lblInvoiceDate.TabIndex = 3
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'stbEndDate
        '
        Me.stbEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEndDate.CapitalizeFirstLetter = False
        Me.stbEndDate.Enabled = False
        Me.stbEndDate.EntryErrorMSG = ""
        Me.stbEndDate.Location = New System.Drawing.Point(204, 71)
        Me.stbEndDate.MaxLength = 20
        Me.stbEndDate.Name = "stbEndDate"
        Me.stbEndDate.RegularExpression = ""
        Me.stbEndDate.Size = New System.Drawing.Size(185, 20)
        Me.stbEndDate.TabIndex = 8
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(12, 72)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(172, 21)
        Me.lblEndDate.TabIndex = 7
        Me.lblEndDate.Text = "End Date"
        '
        'stbStartDate
        '
        Me.stbStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStartDate.CapitalizeFirstLetter = False
        Me.stbStartDate.Enabled = False
        Me.stbStartDate.EntryErrorMSG = ""
        Me.stbStartDate.Location = New System.Drawing.Point(204, 50)
        Me.stbStartDate.MaxLength = 60
        Me.stbStartDate.Name = "stbStartDate"
        Me.stbStartDate.RegularExpression = ""
        Me.stbStartDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStartDate.Size = New System.Drawing.Size(185, 20)
        Me.stbStartDate.TabIndex = 6
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(12, 51)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(172, 21)
        Me.lblStartDate.TabIndex = 5
        Me.lblStartDate.Text = "Start Date"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(541, 25)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(182, 29)
        Me.stbBillCustomerName.TabIndex = 12
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(421, 33)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(93, 21)
        Me.lblBillCustomerName.TabIndex = 11
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(541, 4)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(182, 20)
        Me.stbBillNo.TabIndex = 10
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(421, 6)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(93, 21)
        Me.lblBillNo.TabIndex = 9
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(492, 99)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(299, 13)
        Me.lblRecordsNo.TabIndex = 17
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnExportTo
        '
        Me.fbnExportTo.Enabled = False
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(809, 92)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 24)
        Me.fbnExportTo.TabIndex = 20
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'stbVisitType
        '
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.stbVisitType.Enabled = False
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(541, 76)
        Me.stbVisitType.MaxLength = 60
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitType.Size = New System.Drawing.Size(182, 20)
        Me.stbVisitType.TabIndex = 16
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(421, 79)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(93, 21)
        Me.lblVisitType.TabIndex = 15
        Me.lblVisitType.Text = "Visit Type"
        '
        'frmPrintBillsInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(935, 462)
        Me.Controls.Add(Me.stbVisitType)
        Me.Controls.Add(Me.lblVisitType)
        Me.Controls.Add(Me.fbnExportTo)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.stbStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.btnLoadInvoices)
        Me.Controls.Add(Me.stbInvoiceDate)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.stbInvoiceAmount)
        Me.Controls.Add(Me.lblInvoiceAmount)
        Me.Controls.Add(Me.grpPaymentDetails)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.stbInvoiceNo)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPrintBillsInvoice"
        Me.Text = "Bill's Invoice"
        Me.grpPaymentDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ckcInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnLoadInvoices As System.Windows.Forms.Button
    Friend WithEvents stbInvoiceDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceAmount As System.Windows.Forms.Label
    Friend WithEvents grpPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents stbEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents stbStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCompany As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
