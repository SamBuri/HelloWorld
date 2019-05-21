<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherPayments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVoucherPayments))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbcCashier = New System.Windows.Forms.TabControl()
        Me.tpgMedicalSupplierPayment = New System.Windows.Forms.TabPage()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.btnExchangeRate = New System.Windows.Forms.Button()
        Me.stbChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.nbxAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmountTendered = New System.Windows.Forms.Label()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.cboCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblCurrenciesID = New System.Windows.Forms.Label()
        Me.stbDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmountPaid = New System.Windows.Forms.Label()
        Me.lblDocumentNo = New System.Windows.Forms.Label()
        Me.cboPayModesID = New System.Windows.Forms.ComboBox()
        Me.dtpPayDate = New System.Windows.Forms.DateTimePicker()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.stbVoucherNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPayModes = New System.Windows.Forms.Label()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblPayDate = New System.Windows.Forms.Label()
        Me.tpgNonMedicalSupplierPayment = New System.Windows.Forms.TabPage()
        Me.nbxSPCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dgvServiceInvoices = New System.Windows.Forms.DataGridView()
        Me.ColSPInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColSPItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSPDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSPItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkSPSendBalanceToAccount = New System.Windows.Forms.CheckBox()
        Me.stbSPBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceNos = New System.Windows.Forms.Label()
        Me.btnServicePaymentExchangeRate = New System.Windows.Forms.Button()
        Me.stbSPChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nbxSPAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxSPExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboServicePaymentCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stbSPDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkSPUseAccountBalance = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.stbSeviceInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxSPOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLoadPendingCashServicesPayment = New System.Windows.Forms.Button()
        Me.stbSPSupplierNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.stbSPReceivedDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.stbSPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.stbSPTotalAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboServicePaymentPayModesID = New System.Windows.Forms.ComboBox()
        Me.dtpSPPayDate = New System.Windows.Forms.DateTimePicker()
        Me.lblServiceVoucherNo = New System.Windows.Forms.Label()
        Me.stbServiceVoucherNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.stbSPNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSPSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblServiceInvoiceNo = New System.Windows.Forms.Label()
        Me.tpgSupplierAccounts = New System.Windows.Forms.TabPage()
        Me.btnAccountExchangeRate = New System.Windows.Forms.Button()
        Me.cboAccountGroupID = New System.Windows.Forms.ComboBox()
        Me.lblAccountGroupID = New System.Windows.Forms.Label()
        Me.stbAccountChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountChange = New System.Windows.Forms.Label()
        Me.nbxAccountAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountAmountTendered = New System.Windows.Forms.Label()
        Me.lblAccountExchangeRate = New System.Windows.Forms.Label()
        Me.cboAccountCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblAccountCurrenciesID = New System.Windows.Forms.Label()
        Me.lblAccountTranNo = New System.Windows.Forms.Label()
        Me.stbAccountTranNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountActionID = New System.Windows.Forms.ComboBox()
        Me.lblAccountActionID = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.cboModeOfPaymentID = New System.Windows.Forms.ComboBox()
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblAccountPayModes = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.lblAccountDocumentNo = New System.Windows.Forms.Label()
        Me.stbAccountDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountNotes = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.tbcCashier.SuspendLayout()
        Me.tpgMedicalSupplierPayment.SuspendLayout()
        Me.tpgNonMedicalSupplierPayment.SuspendLayout()
        CType(Me.dgvServiceInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgSupplierAccounts.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcCashier
        '
        Me.tbcCashier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCashier.Controls.Add(Me.tpgMedicalSupplierPayment)
        Me.tbcCashier.Controls.Add(Me.tpgNonMedicalSupplierPayment)
        Me.tbcCashier.Controls.Add(Me.tpgSupplierAccounts)
        Me.tbcCashier.HotTrack = True
        Me.tbcCashier.Location = New System.Drawing.Point(-2, 2)
        Me.tbcCashier.Name = "tbcCashier"
        Me.tbcCashier.SelectedIndex = 0
        Me.tbcCashier.Size = New System.Drawing.Size(697, 398)
        Me.tbcCashier.TabIndex = 11
        '
        'tpgMedicalSupplierPayment
        '
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbSupplierName)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.cboSupplierNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblSupplierName)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblSupplierNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbInvoiceNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblInvoiceNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.btnExchangeRate)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbChange)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblChange)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.nbxAmountTendered)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.nbxExchangeRate)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblAmountTendered)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblExchangeRate)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.cboCurrenciesID)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblCurrenciesID)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbDocumentNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.nbxOutstandingBalance)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblOutstandingBalance)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbAmountWords)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblAmountWords)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbTotalAmountPaid)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblTotalAmountPaid)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblDocumentNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.cboPayModesID)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.dtpPayDate)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblReceiptNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbVoucherNo)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblPayModes)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.stbNotes)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblNotes)
        Me.tpgMedicalSupplierPayment.Controls.Add(Me.lblPayDate)
        Me.tpgMedicalSupplierPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgMedicalSupplierPayment.Name = "tpgMedicalSupplierPayment"
        Me.tpgMedicalSupplierPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgMedicalSupplierPayment.Size = New System.Drawing.Size(689, 372)
        Me.tpgMedicalSupplierPayment.TabIndex = 0
        Me.tpgMedicalSupplierPayment.Tag = "CashPayments"
        Me.tpgMedicalSupplierPayment.Text = "Supplier Payment"
        Me.tpgMedicalSupplierPayment.UseVisualStyleBackColor = True
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(168, 100)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(169, 20)
        Me.stbInvoiceNo.TabIndex = 9
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(7, 98)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(118, 18)
        Me.lblInvoiceNo.TabIndex = 8
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'btnExchangeRate
        '
        Me.btnExchangeRate.Enabled = False
        Me.btnExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExchangeRate.Image = CType(resources.GetObject("btnExchangeRate.Image"), System.Drawing.Image)
        Me.btnExchangeRate.Location = New System.Drawing.Point(100, 212)
        Me.btnExchangeRate.Name = "btnExchangeRate"
        Me.btnExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnExchangeRate.TabIndex = 21
        Me.btnExchangeRate.Tag = "ExchangeRates"
        '
        'stbChange
        '
        Me.stbChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbChange.CapitalizeFirstLetter = False
        Me.stbChange.Enabled = False
        Me.stbChange.EntryErrorMSG = ""
        Me.stbChange.Location = New System.Drawing.Point(168, 235)
        Me.stbChange.MaxLength = 20
        Me.stbChange.Name = "stbChange"
        Me.stbChange.RegularExpression = ""
        Me.stbChange.Size = New System.Drawing.Size(169, 20)
        Me.stbChange.TabIndex = 24
        Me.stbChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChange
        '
        Me.lblChange.Location = New System.Drawing.Point(7, 235)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(118, 20)
        Me.lblChange.TabIndex = 23
        Me.lblChange.Text = "Change"
        '
        'nbxAmountTendered
        '
        Me.nbxAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmountTendered.DecimalPlaces = -1
        Me.nbxAmountTendered.DenyNegativeEntryValue = True
        Me.nbxAmountTendered.Location = New System.Drawing.Point(168, 193)
        Me.nbxAmountTendered.MaxValue = 0.0R
        Me.nbxAmountTendered.MinValue = 0.0R
        Me.nbxAmountTendered.MustEnterNumeric = True
        Me.nbxAmountTendered.Name = "nbxAmountTendered"
        Me.nbxAmountTendered.Size = New System.Drawing.Size(169, 20)
        Me.nbxAmountTendered.TabIndex = 19
        Me.nbxAmountTendered.Value = ""
        '
        'nbxExchangeRate
        '
        Me.nbxExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxExchangeRate.DecimalPlaces = -1
        Me.nbxExchangeRate.DenyZeroEntryValue = True
        Me.nbxExchangeRate.Location = New System.Drawing.Point(168, 214)
        Me.nbxExchangeRate.MaxValue = 0.0R
        Me.nbxExchangeRate.MinValue = 0.0R
        Me.nbxExchangeRate.MustEnterNumeric = True
        Me.nbxExchangeRate.Name = "nbxExchangeRate"
        Me.nbxExchangeRate.Size = New System.Drawing.Size(169, 20)
        Me.nbxExchangeRate.TabIndex = 22
        Me.nbxExchangeRate.Value = ""
        '
        'lblAmountTendered
        '
        Me.lblAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAmountTendered.Location = New System.Drawing.Point(7, 191)
        Me.lblAmountTendered.Name = "lblAmountTendered"
        Me.lblAmountTendered.Size = New System.Drawing.Size(118, 20)
        Me.lblAmountTendered.TabIndex = 18
        Me.lblAmountTendered.Text = "Amount Tendered"
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Location = New System.Drawing.Point(7, 213)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(87, 20)
        Me.lblExchangeRate.TabIndex = 20
        Me.lblExchangeRate.Text = "Exchange Rate"
        '
        'cboCurrenciesID
        '
        Me.cboCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrenciesID.FormattingEnabled = True
        Me.cboCurrenciesID.ItemHeight = 13
        Me.cboCurrenciesID.Location = New System.Drawing.Point(168, 169)
        Me.cboCurrenciesID.Name = "cboCurrenciesID"
        Me.cboCurrenciesID.Size = New System.Drawing.Size(169, 21)
        Me.cboCurrenciesID.TabIndex = 17
        '
        'lblCurrenciesID
        '
        Me.lblCurrenciesID.Location = New System.Drawing.Point(7, 167)
        Me.lblCurrenciesID.Name = "lblCurrenciesID"
        Me.lblCurrenciesID.Size = New System.Drawing.Size(118, 20)
        Me.lblCurrenciesID.TabIndex = 16
        Me.lblCurrenciesID.Text = "Pay in Currency"
        '
        'stbDocumentNo
        '
        Me.stbDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDocumentNo.CapitalizeFirstLetter = False
        Me.stbDocumentNo.EntryErrorMSG = ""
        Me.stbDocumentNo.Location = New System.Drawing.Point(470, 33)
        Me.stbDocumentNo.MaxLength = 60
        Me.stbDocumentNo.Name = "stbDocumentNo"
        Me.stbDocumentNo.RegularExpression = ""
        Me.stbDocumentNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDocumentNo.Size = New System.Drawing.Size(112, 20)
        Me.stbDocumentNo.TabIndex = 47
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(470, 11)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(155, 20)
        Me.nbxOutstandingBalance.TabIndex = 7
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(363, 13)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(137, 20)
        Me.lblOutstandingBalance.TabIndex = 6
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(363, 126)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(262, 33)
        Me.stbAmountWords.TabIndex = 45
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(363, 102)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(245, 21)
        Me.lblAmountWords.TabIndex = 44
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmountPaid
        '
        Me.stbTotalAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmountPaid.CapitalizeFirstLetter = False
        Me.stbTotalAmountPaid.Enabled = False
        Me.stbTotalAmountPaid.EntryErrorMSG = ""
        Me.stbTotalAmountPaid.Location = New System.Drawing.Point(470, 78)
        Me.stbTotalAmountPaid.MaxLength = 20
        Me.stbTotalAmountPaid.Name = "stbTotalAmountPaid"
        Me.stbTotalAmountPaid.RegularExpression = ""
        Me.stbTotalAmountPaid.Size = New System.Drawing.Size(155, 20)
        Me.stbTotalAmountPaid.TabIndex = 34
        Me.stbTotalAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmountPaid
        '
        Me.lblTotalAmountPaid.Location = New System.Drawing.Point(363, 80)
        Me.lblTotalAmountPaid.Name = "lblTotalAmountPaid"
        Me.lblTotalAmountPaid.Size = New System.Drawing.Size(104, 20)
        Me.lblTotalAmountPaid.TabIndex = 33
        Me.lblTotalAmountPaid.Text = "Total Bill"
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.Location = New System.Drawing.Point(363, 35)
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Size = New System.Drawing.Size(104, 20)
        Me.lblDocumentNo.TabIndex = 29
        Me.lblDocumentNo.Text = "Document No"
        '
        'cboPayModesID
        '
        Me.cboPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayModesID.FormattingEnabled = True
        Me.cboPayModesID.ItemHeight = 13
        Me.cboPayModesID.Location = New System.Drawing.Point(168, 144)
        Me.cboPayModesID.Name = "cboPayModesID"
        Me.cboPayModesID.Size = New System.Drawing.Size(169, 21)
        Me.cboPayModesID.TabIndex = 15
        '
        'dtpPayDate
        '
        Me.dtpPayDate.Location = New System.Drawing.Point(168, 121)
        Me.dtpPayDate.Name = "dtpPayDate"
        Me.dtpPayDate.ShowCheckBox = True
        Me.dtpPayDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpPayDate.TabIndex = 13
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(7, 78)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(118, 20)
        Me.lblReceiptNo.TabIndex = 10
        Me.lblReceiptNo.Text = "Voucher No"
        '
        'stbVoucherNo
        '
        Me.stbVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVoucherNo.CapitalizeFirstLetter = False
        Me.stbVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVoucherNo.Enabled = False
        Me.stbVoucherNo.EntryErrorMSG = ""
        Me.stbVoucherNo.Location = New System.Drawing.Point(169, 78)
        Me.stbVoucherNo.MaxLength = 20
        Me.stbVoucherNo.Name = "stbVoucherNo"
        Me.stbVoucherNo.ReadOnly = True
        Me.stbVoucherNo.RegularExpression = ""
        Me.stbVoucherNo.Size = New System.Drawing.Size(169, 20)
        Me.stbVoucherNo.TabIndex = 11
        '
        'lblPayModes
        '
        Me.lblPayModes.Location = New System.Drawing.Point(7, 142)
        Me.lblPayModes.Name = "lblPayModes"
        Me.lblPayModes.Size = New System.Drawing.Size(118, 20)
        Me.lblPayModes.TabIndex = 14
        Me.lblPayModes.Text = "Mode of Payment"
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(470, 56)
        Me.stbNotes.MaxLength = 100
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.Size = New System.Drawing.Size(155, 20)
        Me.stbNotes.TabIndex = 32
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(363, 58)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(104, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'lblPayDate
        '
        Me.lblPayDate.Location = New System.Drawing.Point(7, 121)
        Me.lblPayDate.Name = "lblPayDate"
        Me.lblPayDate.Size = New System.Drawing.Size(118, 20)
        Me.lblPayDate.TabIndex = 12
        Me.lblPayDate.Text = "Pay Date"
        '
        'tpgNonMedicalSupplierPayment
        '
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.nbxSPCashAccountBalance)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.dgvServiceInvoices)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.chkSPSendBalanceToAccount)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPBillNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.lblInvoiceNos)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.btnServicePaymentExchangeRate)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPChange)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label2)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.nbxSPAmountTendered)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.nbxSPExchangeRate)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label3)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label4)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.cboServicePaymentCurrenciesID)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label5)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPDocumentNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.chkSPUseAccountBalance)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label7)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSeviceInvoiceNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.nbxSPOutstandingBalance)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label8)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.btnLoadPendingCashServicesPayment)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPSupplierNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label9)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPReceivedDate)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label10)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPAmountWords)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label11)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPTotalAmountPaid)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label12)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label13)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.cboServicePaymentPayModesID)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.dtpSPPayDate)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.lblServiceVoucherNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbServiceVoucherNo)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label15)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPNotes)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.stbSPSupplierName)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label16)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label17)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.Label18)
        Me.tpgNonMedicalSupplierPayment.Controls.Add(Me.lblServiceInvoiceNo)
        Me.tpgNonMedicalSupplierPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgNonMedicalSupplierPayment.Name = "tpgNonMedicalSupplierPayment"
        Me.tpgNonMedicalSupplierPayment.Size = New System.Drawing.Size(887, 455)
        Me.tpgNonMedicalSupplierPayment.TabIndex = 5
        Me.tpgNonMedicalSupplierPayment.Tag = "CashPayments"
        Me.tpgNonMedicalSupplierPayment.Text = " Service Payment"
        Me.tpgNonMedicalSupplierPayment.UseVisualStyleBackColor = True
        '
        'nbxSPCashAccountBalance
        '
        Me.nbxSPCashAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxSPCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSPCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxSPCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxSPCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxSPCashAccountBalance.DecimalPlaces = -1
        Me.nbxSPCashAccountBalance.Location = New System.Drawing.Point(756, 93)
        Me.nbxSPCashAccountBalance.MaxValue = 0.0R
        Me.nbxSPCashAccountBalance.MinValue = 0.0R
        Me.nbxSPCashAccountBalance.MustEnterNumeric = True
        Me.nbxSPCashAccountBalance.Name = "nbxSPCashAccountBalance"
        Me.nbxSPCashAccountBalance.ReadOnly = True
        Me.nbxSPCashAccountBalance.Size = New System.Drawing.Size(112, 20)
        Me.nbxSPCashAccountBalance.TabIndex = 93
        Me.nbxSPCashAccountBalance.Value = ""
        '
        'dgvServiceInvoices
        '
        Me.dgvServiceInvoices.AllowUserToAddRows = False
        Me.dgvServiceInvoices.AllowUserToDeleteRows = False
        Me.dgvServiceInvoices.AllowUserToOrderColumns = True
        Me.dgvServiceInvoices.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvServiceInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvServiceInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvServiceInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvServiceInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSPInclude, Me.ColSPItemCode, Me.ColSPItemName, Me.ColSPItemCategory, Me.ColSPReceivedQuantity, Me.ColSPRate, Me.colSPDiscount, Me.ColSPAmount, Me.ColSPItemCategoryID})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvServiceInvoices.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvServiceInvoices.EnableHeadersVisualStyles = False
        Me.dgvServiceInvoices.GridColor = System.Drawing.Color.Khaki
        Me.dgvServiceInvoices.Location = New System.Drawing.Point(8, 229)
        Me.dgvServiceInvoices.Name = "dgvServiceInvoices"
        Me.dgvServiceInvoices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvServiceInvoices.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvServiceInvoices.RowHeadersVisible = False
        Me.dgvServiceInvoices.Size = New System.Drawing.Size(869, 217)
        Me.dgvServiceInvoices.TabIndex = 92
        Me.dgvServiceInvoices.Text = "DataGridView1"
        '
        'ColSPInclude
        '
        Me.ColSPInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColSPInclude.HeaderText = "Include"
        Me.ColSPInclude.Name = "ColSPInclude"
        Me.ColSPInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColSPInclude.Width = 50
        '
        'ColSPItemCode
        '
        Me.ColSPItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.ColSPItemCode.DefaultCellStyle = DataGridViewCellStyle11
        Me.ColSPItemCode.HeaderText = "Item Code"
        Me.ColSPItemCode.Name = "ColSPItemCode"
        Me.ColSPItemCode.ReadOnly = True
        Me.ColSPItemCode.Width = 70
        '
        'ColSPItemName
        '
        Me.ColSPItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.ColSPItemName.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColSPItemName.HeaderText = "Item Name"
        Me.ColSPItemName.Name = "ColSPItemName"
        Me.ColSPItemName.ReadOnly = True
        Me.ColSPItemName.Width = 180
        '
        'ColSPItemCategory
        '
        Me.ColSPItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.ColSPItemCategory.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColSPItemCategory.HeaderText = "Category"
        Me.ColSPItemCategory.Name = "ColSPItemCategory"
        Me.ColSPItemCategory.ReadOnly = True
        '
        'ColSPReceivedQuantity
        '
        Me.ColSPReceivedQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.NullValue = Nothing
        Me.ColSPReceivedQuantity.DefaultCellStyle = DataGridViewCellStyle14
        Me.ColSPReceivedQuantity.HeaderText = "Quantity"
        Me.ColSPReceivedQuantity.Name = "ColSPReceivedQuantity"
        Me.ColSPReceivedQuantity.ReadOnly = True
        Me.ColSPReceivedQuantity.Width = 60
        '
        'ColSPRate
        '
        Me.ColSPRate.DataPropertyName = "Rate"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.NullValue = Nothing
        Me.ColSPRate.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColSPRate.HeaderText = "Unit Cost"
        Me.ColSPRate.Name = "ColSPRate"
        Me.ColSPRate.ReadOnly = True
        Me.ColSPRate.Width = 80
        '
        'colSPDiscount
        '
        Me.colSPDiscount.DataPropertyName = "Discount"
        Me.colSPDiscount.HeaderText = "Discount"
        Me.colSPDiscount.Name = "colSPDiscount"
        '
        'ColSPAmount
        '
        Me.ColSPAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.NullValue = Nothing
        Me.ColSPAmount.DefaultCellStyle = DataGridViewCellStyle16
        Me.ColSPAmount.HeaderText = "Amount"
        Me.ColSPAmount.Name = "ColSPAmount"
        Me.ColSPAmount.ReadOnly = True
        '
        'ColSPItemCategoryID
        '
        Me.ColSPItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.ColSPItemCategoryID.HeaderText = "Item Category"
        Me.ColSPItemCategoryID.Name = "ColSPItemCategoryID"
        Me.ColSPItemCategoryID.Visible = False
        '
        'chkSPSendBalanceToAccount
        '
        Me.chkSPSendBalanceToAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSPSendBalanceToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSPSendBalanceToAccount.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkSPSendBalanceToAccount.Location = New System.Drawing.Point(314, 170)
        Me.chkSPSendBalanceToAccount.Name = "chkSPSendBalanceToAccount"
        Me.chkSPSendBalanceToAccount.Size = New System.Drawing.Size(242, 20)
        Me.chkSPSendBalanceToAccount.TabIndex = 56
        Me.chkSPSendBalanceToAccount.Text = "Send Balance To Account"
        '
        'stbSPBillNo
        '
        Me.stbSPBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPBillNo.CapitalizeFirstLetter = False
        Me.stbSPBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSPBillNo.Enabled = False
        Me.stbSPBillNo.EntryErrorMSG = ""
        Me.stbSPBillNo.Location = New System.Drawing.Point(133, 55)
        Me.stbSPBillNo.MaxLength = 20
        Me.stbSPBillNo.Name = "stbSPBillNo"
        Me.stbSPBillNo.ReadOnly = True
        Me.stbSPBillNo.RegularExpression = ""
        Me.stbSPBillNo.Size = New System.Drawing.Size(169, 20)
        Me.stbSPBillNo.TabIndex = 61
        '
        'lblInvoiceNos
        '
        Me.lblInvoiceNos.Location = New System.Drawing.Point(5, 55)
        Me.lblInvoiceNos.Name = "lblInvoiceNos"
        Me.lblInvoiceNos.Size = New System.Drawing.Size(118, 18)
        Me.lblInvoiceNos.TabIndex = 60
        Me.lblInvoiceNos.Text = "Bill No"
        '
        'btnServicePaymentExchangeRate
        '
        Me.btnServicePaymentExchangeRate.Enabled = False
        Me.btnServicePaymentExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnServicePaymentExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnServicePaymentExchangeRate.Image = CType(resources.GetObject("btnServicePaymentExchangeRate.Image"), System.Drawing.Image)
        Me.btnServicePaymentExchangeRate.Location = New System.Drawing.Point(98, 167)
        Me.btnServicePaymentExchangeRate.Name = "btnServicePaymentExchangeRate"
        Me.btnServicePaymentExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnServicePaymentExchangeRate.TabIndex = 73
        Me.btnServicePaymentExchangeRate.Tag = "ExchangeRates"
        '
        'stbSPChange
        '
        Me.stbSPChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbSPChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPChange.CapitalizeFirstLetter = False
        Me.stbSPChange.Enabled = False
        Me.stbSPChange.EntryErrorMSG = ""
        Me.stbSPChange.Location = New System.Drawing.Point(133, 190)
        Me.stbSPChange.MaxLength = 20
        Me.stbSPChange.Name = "stbSPChange"
        Me.stbSPChange.RegularExpression = ""
        Me.stbSPChange.Size = New System.Drawing.Size(169, 20)
        Me.stbSPChange.TabIndex = 76
        Me.stbSPChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 192)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 20)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Change"
        '
        'nbxSPAmountTendered
        '
        Me.nbxSPAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSPAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxSPAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxSPAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxSPAmountTendered.DecimalPlaces = -1
        Me.nbxSPAmountTendered.DenyNegativeEntryValue = True
        Me.nbxSPAmountTendered.Location = New System.Drawing.Point(133, 148)
        Me.nbxSPAmountTendered.MaxValue = 0.0R
        Me.nbxSPAmountTendered.MinValue = 0.0R
        Me.nbxSPAmountTendered.MustEnterNumeric = True
        Me.nbxSPAmountTendered.Name = "nbxSPAmountTendered"
        Me.nbxSPAmountTendered.Size = New System.Drawing.Size(169, 20)
        Me.nbxSPAmountTendered.TabIndex = 71
        Me.nbxSPAmountTendered.Value = ""
        '
        'nbxSPExchangeRate
        '
        Me.nbxSPExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSPExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxSPExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxSPExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxSPExchangeRate.DecimalPlaces = -1
        Me.nbxSPExchangeRate.DenyZeroEntryValue = True
        Me.nbxSPExchangeRate.Location = New System.Drawing.Point(133, 169)
        Me.nbxSPExchangeRate.MaxValue = 0.0R
        Me.nbxSPExchangeRate.MinValue = 0.0R
        Me.nbxSPExchangeRate.MustEnterNumeric = True
        Me.nbxSPExchangeRate.Name = "nbxSPExchangeRate"
        Me.nbxSPExchangeRate.Size = New System.Drawing.Size(169, 20)
        Me.nbxSPExchangeRate.TabIndex = 74
        Me.nbxSPExchangeRate.Value = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(5, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Amount Tendered"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(5, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 20)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Exchange Rate"
        '
        'cboServicePaymentCurrenciesID
        '
        Me.cboServicePaymentCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicePaymentCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServicePaymentCurrenciesID.FormattingEnabled = True
        Me.cboServicePaymentCurrenciesID.ItemHeight = 13
        Me.cboServicePaymentCurrenciesID.Location = New System.Drawing.Point(133, 124)
        Me.cboServicePaymentCurrenciesID.Name = "cboServicePaymentCurrenciesID"
        Me.cboServicePaymentCurrenciesID.Size = New System.Drawing.Size(169, 21)
        Me.cboServicePaymentCurrenciesID.TabIndex = 69
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(5, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 20)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "Pay in Currency"
        '
        'stbSPDocumentNo
        '
        Me.stbSPDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPDocumentNo.CapitalizeFirstLetter = False
        Me.stbSPDocumentNo.EntryErrorMSG = ""
        Me.stbSPDocumentNo.Location = New System.Drawing.Point(457, 101)
        Me.stbSPDocumentNo.MaxLength = 60
        Me.stbSPDocumentNo.Name = "stbSPDocumentNo"
        Me.stbSPDocumentNo.RegularExpression = ""
        Me.stbSPDocumentNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSPDocumentNo.Size = New System.Drawing.Size(112, 20)
        Me.stbSPDocumentNo.TabIndex = 90
        '
        'chkSPUseAccountBalance
        '
        Me.chkSPUseAccountBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSPUseAccountBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSPUseAccountBalance.Location = New System.Drawing.Point(623, 119)
        Me.chkSPUseAccountBalance.Name = "chkSPUseAccountBalance"
        Me.chkSPUseAccountBalance.Size = New System.Drawing.Size(197, 20)
        Me.chkSPUseAccountBalance.TabIndex = 84
        Me.chkSPUseAccountBalance.Text = "Use Account Balance"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(623, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 20)
        Me.Label7.TabIndex = 91
        Me.Label7.Text = "Cash Account Balance"
        '
        'stbSeviceInvoiceNo
        '
        Me.stbSeviceInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSeviceInvoiceNo.CapitalizeFirstLetter = False
        Me.stbSeviceInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSeviceInvoiceNo.EntryErrorMSG = ""
        Me.stbSeviceInvoiceNo.Location = New System.Drawing.Point(133, 11)
        Me.stbSeviceInvoiceNo.MaxLength = 20
        Me.stbSeviceInvoiceNo.Name = "stbSeviceInvoiceNo"
        Me.stbSeviceInvoiceNo.RegularExpression = ""
        Me.stbSeviceInvoiceNo.Size = New System.Drawing.Size(115, 20)
        Me.stbSeviceInvoiceNo.TabIndex = 53
        '
        'nbxSPOutstandingBalance
        '
        Me.nbxSPOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxSPOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSPOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxSPOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxSPOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxSPOutstandingBalance.DecimalPlaces = -1
        Me.nbxSPOutstandingBalance.Location = New System.Drawing.Point(457, 79)
        Me.nbxSPOutstandingBalance.MaxValue = 0.0R
        Me.nbxSPOutstandingBalance.MinValue = 0.0R
        Me.nbxSPOutstandingBalance.MustEnterNumeric = True
        Me.nbxSPOutstandingBalance.Name = "nbxSPOutstandingBalance"
        Me.nbxSPOutstandingBalance.ReadOnly = True
        Me.nbxSPOutstandingBalance.Size = New System.Drawing.Size(155, 20)
        Me.nbxSPOutstandingBalance.TabIndex = 59
        Me.nbxSPOutstandingBalance.Value = ""
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.Color.Red
        Me.Label8.Location = New System.Drawing.Point(314, 82)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 20)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Outstanding Balance"
        '
        'btnLoadPendingCashServicesPayment
        '
        Me.btnLoadPendingCashServicesPayment.AccessibleDescription = ""
        Me.btnLoadPendingCashServicesPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingCashServicesPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingCashServicesPayment.Location = New System.Drawing.Point(254, 6)
        Me.btnLoadPendingCashServicesPayment.Name = "btnLoadPendingCashServicesPayment"
        Me.btnLoadPendingCashServicesPayment.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingCashServicesPayment.TabIndex = 54
        Me.btnLoadPendingCashServicesPayment.Tag = ""
        Me.btnLoadPendingCashServicesPayment.Text = "&Load"
        '
        'stbSPSupplierNo
        '
        Me.stbSPSupplierNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPSupplierNo.CapitalizeFirstLetter = False
        Me.stbSPSupplierNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSPSupplierNo.EntryErrorMSG = ""
        Me.stbSPSupplierNo.Location = New System.Drawing.Point(457, 32)
        Me.stbSPSupplierNo.MaxLength = 7
        Me.stbSPSupplierNo.Multiline = True
        Me.stbSPSupplierNo.Name = "stbSPSupplierNo"
        Me.stbSPSupplierNo.ReadOnly = True
        Me.stbSPSupplierNo.RegularExpression = ""
        Me.stbSPSupplierNo.Size = New System.Drawing.Size(155, 24)
        Me.stbSPSupplierNo.TabIndex = 78
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(314, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 20)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Suppliers's No"
        '
        'stbSPReceivedDate
        '
        Me.stbSPReceivedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPReceivedDate.CapitalizeFirstLetter = False
        Me.stbSPReceivedDate.Enabled = False
        Me.stbSPReceivedDate.EntryErrorMSG = ""
        Me.stbSPReceivedDate.Location = New System.Drawing.Point(457, 10)
        Me.stbSPReceivedDate.MaxLength = 60
        Me.stbSPReceivedDate.Name = "stbSPReceivedDate"
        Me.stbSPReceivedDate.RegularExpression = ""
        Me.stbSPReceivedDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSPReceivedDate.Size = New System.Drawing.Size(155, 20)
        Me.stbSPReceivedDate.TabIndex = 86
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(314, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 20)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "Bill Date"
        '
        'stbSPAmountWords
        '
        Me.stbSPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbSPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPAmountWords.CapitalizeFirstLetter = False
        Me.stbSPAmountWords.EntryErrorMSG = ""
        Me.stbSPAmountWords.Location = New System.Drawing.Point(623, 37)
        Me.stbSPAmountWords.MaxLength = 100
        Me.stbSPAmountWords.Multiline = True
        Me.stbSPAmountWords.Name = "stbSPAmountWords"
        Me.stbSPAmountWords.ReadOnly = True
        Me.stbSPAmountWords.RegularExpression = ""
        Me.stbSPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSPAmountWords.Size = New System.Drawing.Size(245, 33)
        Me.stbSPAmountWords.TabIndex = 88
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(623, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(245, 21)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Amount in Words"
        '
        'stbSPTotalAmountPaid
        '
        Me.stbSPTotalAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbSPTotalAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPTotalAmountPaid.CapitalizeFirstLetter = False
        Me.stbSPTotalAmountPaid.Enabled = False
        Me.stbSPTotalAmountPaid.EntryErrorMSG = ""
        Me.stbSPTotalAmountPaid.Location = New System.Drawing.Point(457, 146)
        Me.stbSPTotalAmountPaid.MaxLength = 20
        Me.stbSPTotalAmountPaid.Name = "stbSPTotalAmountPaid"
        Me.stbSPTotalAmountPaid.RegularExpression = ""
        Me.stbSPTotalAmountPaid.Size = New System.Drawing.Size(155, 20)
        Me.stbSPTotalAmountPaid.TabIndex = 83
        Me.stbSPTotalAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(314, 148)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(104, 20)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "Total Bill"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(314, 103)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 20)
        Me.Label13.TabIndex = 79
        Me.Label13.Text = "Document No"
        '
        'cboServicePaymentPayModesID
        '
        Me.cboServicePaymentPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicePaymentPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServicePaymentPayModesID.FormattingEnabled = True
        Me.cboServicePaymentPayModesID.ItemHeight = 13
        Me.cboServicePaymentPayModesID.Location = New System.Drawing.Point(133, 99)
        Me.cboServicePaymentPayModesID.Name = "cboServicePaymentPayModesID"
        Me.cboServicePaymentPayModesID.Size = New System.Drawing.Size(169, 21)
        Me.cboServicePaymentPayModesID.TabIndex = 67
        '
        'dtpSPPayDate
        '
        Me.dtpSPPayDate.Location = New System.Drawing.Point(133, 76)
        Me.dtpSPPayDate.Name = "dtpSPPayDate"
        Me.dtpSPPayDate.ShowCheckBox = True
        Me.dtpSPPayDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpSPPayDate.TabIndex = 65
        '
        'lblServiceVoucherNo
        '
        Me.lblServiceVoucherNo.Location = New System.Drawing.Point(5, 35)
        Me.lblServiceVoucherNo.Name = "lblServiceVoucherNo"
        Me.lblServiceVoucherNo.Size = New System.Drawing.Size(118, 20)
        Me.lblServiceVoucherNo.TabIndex = 62
        Me.lblServiceVoucherNo.Text = "Voucher No"
        '
        'stbServiceVoucherNo
        '
        Me.stbServiceVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbServiceVoucherNo.CapitalizeFirstLetter = False
        Me.stbServiceVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbServiceVoucherNo.Enabled = False
        Me.stbServiceVoucherNo.EntryErrorMSG = ""
        Me.stbServiceVoucherNo.Location = New System.Drawing.Point(134, 33)
        Me.stbServiceVoucherNo.MaxLength = 20
        Me.stbServiceVoucherNo.Name = "stbServiceVoucherNo"
        Me.stbServiceVoucherNo.ReadOnly = True
        Me.stbServiceVoucherNo.RegularExpression = ""
        Me.stbServiceVoucherNo.Size = New System.Drawing.Size(169, 20)
        Me.stbServiceVoucherNo.TabIndex = 63
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(5, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(118, 20)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Mode of Payment"
        '
        'stbSPNotes
        '
        Me.stbSPNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPNotes.CapitalizeFirstLetter = True
        Me.stbSPNotes.EntryErrorMSG = ""
        Me.stbSPNotes.Location = New System.Drawing.Point(457, 124)
        Me.stbSPNotes.MaxLength = 100
        Me.stbSPNotes.Multiline = True
        Me.stbSPNotes.Name = "stbSPNotes"
        Me.stbSPNotes.RegularExpression = ""
        Me.stbSPNotes.Size = New System.Drawing.Size(155, 20)
        Me.stbSPNotes.TabIndex = 81
        '
        'stbSPSupplierName
        '
        Me.stbSPSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSPSupplierName.CapitalizeFirstLetter = False
        Me.stbSPSupplierName.Enabled = False
        Me.stbSPSupplierName.EntryErrorMSG = ""
        Me.stbSPSupplierName.Location = New System.Drawing.Point(457, 58)
        Me.stbSPSupplierName.MaxLength = 60
        Me.stbSPSupplierName.Name = "stbSPSupplierName"
        Me.stbSPSupplierName.RegularExpression = ""
        Me.stbSPSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSPSupplierName.Size = New System.Drawing.Size(155, 20)
        Me.stbSPSupplierName.TabIndex = 57
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(314, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 20)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Supplier Name"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(314, 126)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 20)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Notes"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(5, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 20)
        Me.Label18.TabIndex = 64
        Me.Label18.Text = "Pay Date"
        '
        'lblServiceInvoiceNo
        '
        Me.lblServiceInvoiceNo.Location = New System.Drawing.Point(5, 12)
        Me.lblServiceInvoiceNo.Name = "lblServiceInvoiceNo"
        Me.lblServiceInvoiceNo.Size = New System.Drawing.Size(95, 21)
        Me.lblServiceInvoiceNo.TabIndex = 52
        Me.lblServiceInvoiceNo.Text = "Invoice No"
        '
        'tpgSupplierAccounts
        '
        Me.tpgSupplierAccounts.Controls.Add(Me.btnAccountExchangeRate)
        Me.tpgSupplierAccounts.Controls.Add(Me.cboAccountGroupID)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountGroupID)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountChange)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountChange)
        Me.tpgSupplierAccounts.Controls.Add(Me.nbxAccountAmountTendered)
        Me.tpgSupplierAccounts.Controls.Add(Me.nbxAccountExchangeRate)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountAmountTendered)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountExchangeRate)
        Me.tpgSupplierAccounts.Controls.Add(Me.cboAccountCurrenciesID)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountCurrenciesID)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountTranNo)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountTranNo)
        Me.tpgSupplierAccounts.Controls.Add(Me.cboAccountActionID)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountActionID)
        Me.tpgSupplierAccounts.Controls.Add(Me.nbxAccountBalance)
        Me.tpgSupplierAccounts.Controls.Add(Me.nbxAccountAmount)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAmount)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountNo)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountBalance)
        Me.tpgSupplierAccounts.Controls.Add(Me.cboModeOfPaymentID)
        Me.tpgSupplierAccounts.Controls.Add(Me.dtpTransactionDate)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountPayModes)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblTransactionDate)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountDocumentNo)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountDocumentNo)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountNotes)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountNotes)
        Me.tpgSupplierAccounts.Controls.Add(Me.stbAccountName)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountName)
        Me.tpgSupplierAccounts.Controls.Add(Me.lblAccountNo)
        Me.tpgSupplierAccounts.Location = New System.Drawing.Point(4, 22)
        Me.tpgSupplierAccounts.Name = "tpgSupplierAccounts"
        Me.tpgSupplierAccounts.Size = New System.Drawing.Size(887, 455)
        Me.tpgSupplierAccounts.TabIndex = 6
        Me.tpgSupplierAccounts.Tag = "Accounts"
        Me.tpgSupplierAccounts.Text = "Supplier Accounts"
        Me.tpgSupplierAccounts.UseVisualStyleBackColor = True
        '
        'btnAccountExchangeRate
        '
        Me.btnAccountExchangeRate.Enabled = False
        Me.btnAccountExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAccountExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountExchangeRate.Image = CType(resources.GetObject("btnAccountExchangeRate.Image"), System.Drawing.Image)
        Me.btnAccountExchangeRate.Location = New System.Drawing.Point(110, 187)
        Me.btnAccountExchangeRate.Name = "btnAccountExchangeRate"
        Me.btnAccountExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnAccountExchangeRate.TabIndex = 95
        Me.btnAccountExchangeRate.Tag = "ExchangeRates"
        '
        'cboAccountGroupID
        '
        Me.cboAccountGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountGroupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountGroupID.FormattingEnabled = True
        Me.cboAccountGroupID.ItemHeight = 13
        Me.cboAccountGroupID.Location = New System.Drawing.Point(143, 294)
        Me.cboAccountGroupID.Name = "cboAccountGroupID"
        Me.cboAccountGroupID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountGroupID.TabIndex = 106
        '
        'lblAccountGroupID
        '
        Me.lblAccountGroupID.Location = New System.Drawing.Point(8, 294)
        Me.lblAccountGroupID.Name = "lblAccountGroupID"
        Me.lblAccountGroupID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountGroupID.TabIndex = 105
        Me.lblAccountGroupID.Text = "Account Group"
        '
        'stbAccountChange
        '
        Me.stbAccountChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountChange.CapitalizeFirstLetter = False
        Me.stbAccountChange.Enabled = False
        Me.stbAccountChange.EntryErrorMSG = ""
        Me.stbAccountChange.Location = New System.Drawing.Point(143, 230)
        Me.stbAccountChange.MaxLength = 20
        Me.stbAccountChange.Name = "stbAccountChange"
        Me.stbAccountChange.RegularExpression = ""
        Me.stbAccountChange.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountChange.TabIndex = 100
        Me.stbAccountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAccountChange
        '
        Me.lblAccountChange.Location = New System.Drawing.Point(8, 231)
        Me.lblAccountChange.Name = "lblAccountChange"
        Me.lblAccountChange.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountChange.TabIndex = 99
        Me.lblAccountChange.Text = "Change"
        '
        'nbxAccountAmountTendered
        '
        Me.nbxAccountAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmountTendered.ControlCaption = "Unit Price"
        Me.nbxAccountAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmountTendered.DecimalPlaces = -1
        Me.nbxAccountAmountTendered.Location = New System.Drawing.Point(143, 167)
        Me.nbxAccountAmountTendered.MaxValue = 0.0R
        Me.nbxAccountAmountTendered.MinValue = 0.0R
        Me.nbxAccountAmountTendered.MustEnterNumeric = True
        Me.nbxAccountAmountTendered.Name = "nbxAccountAmountTendered"
        Me.nbxAccountAmountTendered.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmountTendered.TabIndex = 93
        Me.nbxAccountAmountTendered.Value = ""
        '
        'nbxAccountExchangeRate
        '
        Me.nbxAccountExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountExchangeRate.ControlCaption = "Unit Price"
        Me.nbxAccountExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountExchangeRate.DecimalPlaces = -1
        Me.nbxAccountExchangeRate.Location = New System.Drawing.Point(143, 188)
        Me.nbxAccountExchangeRate.MaxValue = 0.0R
        Me.nbxAccountExchangeRate.MinValue = 0.0R
        Me.nbxAccountExchangeRate.MustEnterNumeric = True
        Me.nbxAccountExchangeRate.Name = "nbxAccountExchangeRate"
        Me.nbxAccountExchangeRate.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountExchangeRate.TabIndex = 96
        Me.nbxAccountExchangeRate.Value = ""
        '
        'lblAccountAmountTendered
        '
        Me.lblAccountAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAccountAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAccountAmountTendered.Location = New System.Drawing.Point(8, 167)
        Me.lblAccountAmountTendered.Name = "lblAccountAmountTendered"
        Me.lblAccountAmountTendered.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountAmountTendered.TabIndex = 92
        Me.lblAccountAmountTendered.Text = "Amount Tendered"
        '
        'lblAccountExchangeRate
        '
        Me.lblAccountExchangeRate.Location = New System.Drawing.Point(8, 189)
        Me.lblAccountExchangeRate.Name = "lblAccountExchangeRate"
        Me.lblAccountExchangeRate.Size = New System.Drawing.Size(96, 18)
        Me.lblAccountExchangeRate.TabIndex = 94
        Me.lblAccountExchangeRate.Text = "Exchange Rate"
        '
        'cboAccountCurrenciesID
        '
        Me.cboAccountCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountCurrenciesID.FormattingEnabled = True
        Me.cboAccountCurrenciesID.ItemHeight = 13
        Me.cboAccountCurrenciesID.Location = New System.Drawing.Point(143, 144)
        Me.cboAccountCurrenciesID.Name = "cboAccountCurrenciesID"
        Me.cboAccountCurrenciesID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountCurrenciesID.TabIndex = 91
        '
        'lblAccountCurrenciesID
        '
        Me.lblAccountCurrenciesID.Location = New System.Drawing.Point(8, 144)
        Me.lblAccountCurrenciesID.Name = "lblAccountCurrenciesID"
        Me.lblAccountCurrenciesID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountCurrenciesID.TabIndex = 90
        Me.lblAccountCurrenciesID.Text = "Pay in Currency"
        '
        'lblAccountTranNo
        '
        Me.lblAccountTranNo.Location = New System.Drawing.Point(8, 76)
        Me.lblAccountTranNo.Name = "lblAccountTranNo"
        Me.lblAccountTranNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountTranNo.TabIndex = 84
        Me.lblAccountTranNo.Text = "Transaction No"
        '
        'stbAccountTranNo
        '
        Me.stbAccountTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountTranNo.CapitalizeFirstLetter = False
        Me.stbAccountTranNo.EntryErrorMSG = ""
        Me.stbAccountTranNo.Location = New System.Drawing.Point(143, 76)
        Me.stbAccountTranNo.MaxLength = 20
        Me.stbAccountTranNo.Name = "stbAccountTranNo"
        Me.stbAccountTranNo.RegularExpression = ""
        Me.stbAccountTranNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountTranNo.TabIndex = 85
        '
        'cboAccountActionID
        '
        Me.cboAccountActionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountActionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountActionID.FormattingEnabled = True
        Me.cboAccountActionID.Location = New System.Drawing.Point(143, 121)
        Me.cboAccountActionID.Name = "cboAccountActionID"
        Me.cboAccountActionID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountActionID.TabIndex = 89
        '
        'lblAccountActionID
        '
        Me.lblAccountActionID.Location = New System.Drawing.Point(8, 121)
        Me.lblAccountActionID.Name = "lblAccountActionID"
        Me.lblAccountActionID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountActionID.TabIndex = 88
        Me.lblAccountActionID.Text = "Account Action"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Enabled = False
        Me.nbxAccountBalance.Location = New System.Drawing.Point(143, 251)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountBalance.TabIndex = 102
        Me.nbxAccountBalance.Value = ""
        '
        'nbxAccountAmount
        '
        Me.nbxAccountAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmount.ControlCaption = "Amount"
        Me.nbxAccountAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmount.DecimalPlaces = -1
        Me.nbxAccountAmount.Enabled = False
        Me.nbxAccountAmount.Location = New System.Drawing.Point(143, 209)
        Me.nbxAccountAmount.MaxValue = 0.0R
        Me.nbxAccountAmount.MinValue = 0.0R
        Me.nbxAccountAmount.MustEnterNumeric = True
        Me.nbxAccountAmount.Name = "nbxAccountAmount"
        Me.nbxAccountAmount.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmount.TabIndex = 98
        Me.nbxAccountAmount.Value = ""
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(8, 209)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(129, 18)
        Me.lblAmount.TabIndex = 97
        Me.lblAmount.Text = "Amount"
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.CapitalizeFirstLetter = False
        Me.stbAccountNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbAccountNo.EntryErrorMSG = ""
        Me.stbAccountNo.Location = New System.Drawing.Point(143, 8)
        Me.stbAccountNo.MaxLength = 12
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.RegularExpression = ""
        Me.stbAccountNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountNo.TabIndex = 79
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(8, 251)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountBalance.TabIndex = 101
        Me.lblAccountBalance.Text = "Balance"
        '
        'cboModeOfPaymentID
        '
        Me.cboModeOfPaymentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModeOfPaymentID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboModeOfPaymentID.FormattingEnabled = True
        Me.cboModeOfPaymentID.ItemHeight = 13
        Me.cboModeOfPaymentID.Location = New System.Drawing.Point(143, 98)
        Me.cboModeOfPaymentID.Name = "cboModeOfPaymentID"
        Me.cboModeOfPaymentID.Size = New System.Drawing.Size(183, 21)
        Me.cboModeOfPaymentID.TabIndex = 87
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Enabled = False
        Me.dtpTransactionDate.Location = New System.Drawing.Point(143, 53)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ShowCheckBox = True
        Me.dtpTransactionDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpTransactionDate.TabIndex = 83
        '
        'lblAccountPayModes
        '
        Me.lblAccountPayModes.Location = New System.Drawing.Point(8, 101)
        Me.lblAccountPayModes.Name = "lblAccountPayModes"
        Me.lblAccountPayModes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountPayModes.TabIndex = 86
        Me.lblAccountPayModes.Text = "Mode of Payment"
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(8, 55)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(129, 18)
        Me.lblTransactionDate.TabIndex = 82
        Me.lblTransactionDate.Text = "Transaction Date"
        '
        'lblAccountDocumentNo
        '
        Me.lblAccountDocumentNo.Location = New System.Drawing.Point(8, 274)
        Me.lblAccountDocumentNo.Name = "lblAccountDocumentNo"
        Me.lblAccountDocumentNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountDocumentNo.TabIndex = 103
        Me.lblAccountDocumentNo.Text = "Document No."
        '
        'stbAccountDocumentNo
        '
        Me.stbAccountDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountDocumentNo.CapitalizeFirstLetter = False
        Me.stbAccountDocumentNo.EntryErrorMSG = ""
        Me.stbAccountDocumentNo.Location = New System.Drawing.Point(143, 272)
        Me.stbAccountDocumentNo.MaxLength = 12
        Me.stbAccountDocumentNo.Name = "stbAccountDocumentNo"
        Me.stbAccountDocumentNo.RegularExpression = ""
        Me.stbAccountDocumentNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountDocumentNo.TabIndex = 104
        '
        'stbAccountNotes
        '
        Me.stbAccountNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNotes.CapitalizeFirstLetter = True
        Me.stbAccountNotes.EntryErrorMSG = ""
        Me.stbAccountNotes.Location = New System.Drawing.Point(143, 317)
        Me.stbAccountNotes.MaxLength = 100
        Me.stbAccountNotes.Multiline = True
        Me.stbAccountNotes.Name = "stbAccountNotes"
        Me.stbAccountNotes.RegularExpression = ""
        Me.stbAccountNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountNotes.Size = New System.Drawing.Size(183, 41)
        Me.stbAccountNotes.TabIndex = 108
        '
        'lblAccountNotes
        '
        Me.lblAccountNotes.Location = New System.Drawing.Point(8, 327)
        Me.lblAccountNotes.Name = "lblAccountNotes"
        Me.lblAccountNotes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNotes.TabIndex = 107
        Me.lblAccountNotes.Text = "Notes"
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(143, 29)
        Me.stbAccountName.MaxLength = 41
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountName.TabIndex = 81
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(8, 30)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountName.TabIndex = 80
        Me.lblAccountName.Text = "Supplier Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(8, 8)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNo.TabIndex = 78
        Me.lblAccountNo.Text = "Supplier No"
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(160, 33)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSupplierName.Size = New System.Drawing.Size(179, 35)
        Me.stbSupplierName.TabIndex = 51
        '
        'cboSupplierNo
        '
        Me.cboSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboSupplierNo.DropDownWidth = 256
        Me.cboSupplierNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSupplierNo.FormattingEnabled = True
        Me.cboSupplierNo.ItemHeight = 13
        Me.cboSupplierNo.Location = New System.Drawing.Point(160, 10)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(179, 21)
        Me.cboSupplierNo.TabIndex = 49
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(7, 40)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierName.TabIndex = 50
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(7, 12)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierNo.TabIndex = 48
        Me.lblSupplierNo.Text = "Supplier Number"
        '
        'frmVoucherPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 412)
        Me.Controls.Add(Me.tbcCashier)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVoucherPayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Voucher Payments"
        Me.tbcCashier.ResumeLayout(False)
        Me.tpgMedicalSupplierPayment.ResumeLayout(False)
        Me.tpgMedicalSupplierPayment.PerformLayout()
        Me.tpgNonMedicalSupplierPayment.ResumeLayout(False)
        Me.tpgNonMedicalSupplierPayment.PerformLayout()
        CType(Me.dgvServiceInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgSupplierAccounts.ResumeLayout(False)
        Me.tpgSupplierAccounts.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcCashier As System.Windows.Forms.TabControl
    Friend WithEvents tpgMedicalSupplierPayment As System.Windows.Forms.TabPage
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents btnExchangeRate As System.Windows.Forms.Button
    Friend WithEvents stbChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblChange As System.Windows.Forms.Label
    Friend WithEvents nbxAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents stbDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblDocumentNo As System.Windows.Forms.Label
    Friend WithEvents cboPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbVoucherNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPayModes As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblPayDate As System.Windows.Forms.Label
    Friend WithEvents tpgNonMedicalSupplierPayment As System.Windows.Forms.TabPage
    Friend WithEvents nbxSPCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dgvServiceInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents ColSPInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColSPItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSPDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSPItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSPSendBalanceToAccount As System.Windows.Forms.CheckBox
    Friend WithEvents stbSPBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceNos As System.Windows.Forms.Label
    Friend WithEvents btnServicePaymentExchangeRate As System.Windows.Forms.Button
    Friend WithEvents stbSPChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nbxSPAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxSPExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboServicePaymentCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents stbSPDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents chkSPUseAccountBalance As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents stbSeviceInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxSPOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingCashServicesPayment As System.Windows.Forms.Button
    Friend WithEvents stbSPSupplierNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents stbSPReceivedDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents stbSPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents stbSPTotalAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboServicePaymentPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpSPPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblServiceVoucherNo As System.Windows.Forms.Label
    Friend WithEvents stbServiceVoucherNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents stbSPNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbSPSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblServiceInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents tpgSupplierAccounts As System.Windows.Forms.TabPage
    Friend WithEvents btnAccountExchangeRate As System.Windows.Forms.Button
    Friend WithEvents cboAccountGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountGroupID As System.Windows.Forms.Label
    Friend WithEvents stbAccountChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountChange As System.Windows.Forms.Label
    Friend WithEvents nbxAccountAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblAccountExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboAccountCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents lblAccountTranNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountTranNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboAccountActionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountActionID As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents cboModeOfPaymentID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAccountPayModes As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblAccountDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountNotes As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboSupplierNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblSupplierNo As System.Windows.Forms.Label
End Class
