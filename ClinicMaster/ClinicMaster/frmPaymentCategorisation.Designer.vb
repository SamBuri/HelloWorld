<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentCategorisation
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentCategorisation))
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tpgInPatient = New System.Windows.Forms.TabPage()
        Me.dgvIPDPatientPaymentCategorisation = New System.Windows.Forms.DataGridView()
        Me.stbPatientChequePaymentsWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbPatientChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dgvOutPatientPaymentCategorisation = New System.Windows.Forms.DataGridView()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tpgOutpatient = New System.Windows.Forms.TabPage()
        Me.tbcPaymentCategorisation = New System.Windows.Forms.TabControl()
        Me.tpgAccounts = New System.Windows.Forms.TabPage()
        Me.dgvAccounts = New System.Windows.Forms.DataGridView()
        Me.ColTransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransactionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountsNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgOPDInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.dgvOPDAccountDetails = New System.Windows.Forms.DataGridView()
        Me.colOADPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADOptical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADICU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOADNonMedical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOADTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.dgvIPDAccountDetails = New System.Windows.Forms.DataGridView()
        Me.colIADPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADvisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADOptical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADICU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIADNonMedical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIADTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.cboBillMode = New System.Windows.Forms.ComboBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.nbxOutstandingBill = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBill = New System.Windows.Forms.Label()
        Me.ColInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalBill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountTendered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCollections = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreditSales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOptical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNonMedical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWithholdingTax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGrandDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDpaydate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPayNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDTotalBill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDAmountTendered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDCollections = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDCreditSales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDRefundAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDICU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDNonMedical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDGrandDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDWithholdingTax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgInPatient.SuspendLayout()
        CType(Me.dgvIPDPatientPaymentCategorisation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOutPatientPaymentCategorisation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOutpatient.SuspendLayout()
        Me.tbcPaymentCategorisation.SuspendLayout()
        Me.tpgAccounts.SuspendLayout()
        CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOPDInvoiceDetails.SuspendLayout()
        CType(Me.dgvOPDAccountDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDInvoiceDetails.SuspendLayout()
        CType(Me.dgvIPDAccountDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(792, 101)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 67
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(836, 420)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 50
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'tpgInPatient
        '
        Me.tpgInPatient.Controls.Add(Me.dgvIPDPatientPaymentCategorisation)
        Me.tpgInPatient.Controls.Add(Me.stbPatientChequePaymentsWords)
        Me.tpgInPatient.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgInPatient.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgInPatient.Controls.Add(Me.stbPatientChequePayments)
        Me.tpgInPatient.Location = New System.Drawing.Point(4, 22)
        Me.tpgInPatient.Name = "tpgInPatient"
        Me.tpgInPatient.Size = New System.Drawing.Size(899, 259)
        Me.tpgInPatient.TabIndex = 7
        Me.tpgInPatient.Tag = ""
        Me.tpgInPatient.Text = "In Patient"
        Me.tpgInPatient.UseVisualStyleBackColor = True
        '
        'dgvIPDPatientPaymentCategorisation
        '
        Me.dgvIPDPatientPaymentCategorisation.AllowUserToAddRows = False
        Me.dgvIPDPatientPaymentCategorisation.AllowUserToDeleteRows = False
        Me.dgvIPDPatientPaymentCategorisation.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDPatientPaymentCategorisation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPDPatientPaymentCategorisation.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDPatientPaymentCategorisation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDPatientPaymentCategorisation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDPatientPaymentCategorisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDPatientPaymentCategorisation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIPDPatientPaymentCategorisation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIPDReceiptNo, Me.colIPDAccountNo, Me.colPatientName, Me.colIPDpaydate, Me.ColIPDPayNo, Me.colIPDTotalBill, Me.colIPDAmountTendered, Me.colIPDCollections, Me.colIPDCreditSales, Me.colIPDRefundAmount, Me.colIPDNetAmount, Me.colIPDservices, Me.colIPDDrug, Me.colIPDConsumable, Me.colIPDLaboratory, Me.colIPDRadiology, Me.colIPDPathology, Me.colIPDDental, Me.colIPDTheatre, Me.DataGridViewTextBoxColumn17, Me.colIPDProcedureID, Me.colIPDExtras, Me.colIPDMaternity, Me.colIPDEye, Me.colIPDAdmission, Me.colIPDPackages, Me.colIPDICU, Me.colIPDNonMedical, Me.colIPDTotal, Me.colIPDGrandDiscount, Me.colIPDWithholdingTax})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDPatientPaymentCategorisation.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIPDPatientPaymentCategorisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDPatientPaymentCategorisation.EnableHeadersVisualStyles = False
        Me.dgvIPDPatientPaymentCategorisation.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDPatientPaymentCategorisation.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDPatientPaymentCategorisation.Name = "dgvIPDPatientPaymentCategorisation"
        Me.dgvIPDPatientPaymentCategorisation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDPatientPaymentCategorisation.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIPDPatientPaymentCategorisation.RowHeadersVisible = False
        Me.dgvIPDPatientPaymentCategorisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDPatientPaymentCategorisation.Size = New System.Drawing.Size(899, 259)
        Me.dgvIPDPatientPaymentCategorisation.TabIndex = 13
        Me.dgvIPDPatientPaymentCategorisation.Text = "DataGridView1"
        '
        'stbPatientChequePaymentsWords
        '
        Me.stbPatientChequePaymentsWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePaymentsWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePaymentsWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePaymentsWords.CapitalizeFirstLetter = False
        Me.stbPatientChequePaymentsWords.EntryErrorMSG = ""
        Me.stbPatientChequePaymentsWords.Location = New System.Drawing.Point(419, 353)
        Me.stbPatientChequePaymentsWords.MaxLength = 100
        Me.stbPatientChequePaymentsWords.Multiline = True
        Me.stbPatientChequePaymentsWords.Name = "stbPatientChequePaymentsWords"
        Me.stbPatientChequePaymentsWords.ReadOnly = True
        Me.stbPatientChequePaymentsWords.RegularExpression = ""
        Me.stbPatientChequePaymentsWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPatientChequePaymentsWords.Size = New System.Drawing.Size(377, 39)
        Me.stbPatientChequePaymentsWords.TabIndex = 12
        '
        'lblExpenditureTotalAmount
        '
        Me.lblExpenditureTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(7, 366)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 9
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(287, 366)
        Me.lblExpenditureAmountWords.Name = "lblExpenditureAmountWords"
        Me.lblExpenditureAmountWords.Size = New System.Drawing.Size(126, 21)
        Me.lblExpenditureAmountWords.TabIndex = 11
        Me.lblExpenditureAmountWords.Text = "Amount in Words"
        '
        'stbPatientChequePayments
        '
        Me.stbPatientChequePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePayments.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePayments.CapitalizeFirstLetter = False
        Me.stbPatientChequePayments.Enabled = False
        Me.stbPatientChequePayments.EntryErrorMSG = ""
        Me.stbPatientChequePayments.Location = New System.Drawing.Point(97, 364)
        Me.stbPatientChequePayments.MaxLength = 20
        Me.stbPatientChequePayments.Name = "stbPatientChequePayments"
        Me.stbPatientChequePayments.RegularExpression = ""
        Me.stbPatientChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbPatientChequePayments.TabIndex = 10
        Me.stbPatientChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(208, 36)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDateTime.TabIndex = 54
        '
        'dgvOutPatientPaymentCategorisation
        '
        Me.dgvOutPatientPaymentCategorisation.AllowUserToAddRows = False
        Me.dgvOutPatientPaymentCategorisation.AllowUserToDeleteRows = False
        Me.dgvOutPatientPaymentCategorisation.AllowUserToOrderColumns = True
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOutPatientPaymentCategorisation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvOutPatientPaymentCategorisation.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOutPatientPaymentCategorisation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOutPatientPaymentCategorisation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOutPatientPaymentCategorisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutPatientPaymentCategorisation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvOutPatientPaymentCategorisation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInvoiceNo, Me.colAccountNo, Me.colFullName, Me.colvisitdate, Me.colPayNo, Me.colTotalBill, Me.colAmountTendered, Me.colCollections, Me.colCreditSales, Me.colRefundAmount, Me.colNetAmount, Me.colservices, Me.ColDrug, Me.ColConsumable, Me.ColLaboratory, Me.ColRadiology, Me.ColPathology, Me.colDental, Me.ColTheatre, Me.ColOptical, Me.ColProcedureID, Me.ColExtras, Me.ColMaternity, Me.ColEye, Me.ColAdmission, Me.ColPackages, Me.colICU, Me.colNonMedical, Me.ColTotal, Me.colWithholdingTax, Me.colGrandDiscount})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOutPatientPaymentCategorisation.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvOutPatientPaymentCategorisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOutPatientPaymentCategorisation.EnableHeadersVisualStyles = False
        Me.dgvOutPatientPaymentCategorisation.GridColor = System.Drawing.Color.Khaki
        Me.dgvOutPatientPaymentCategorisation.Location = New System.Drawing.Point(0, 0)
        Me.dgvOutPatientPaymentCategorisation.Name = "dgvOutPatientPaymentCategorisation"
        Me.dgvOutPatientPaymentCategorisation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutPatientPaymentCategorisation.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvOutPatientPaymentCategorisation.RowHeadersVisible = False
        Me.dgvOutPatientPaymentCategorisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOutPatientPaymentCategorisation.Size = New System.Drawing.Size(899, 259)
        Me.dgvOutPatientPaymentCategorisation.TabIndex = 0
        Me.dgvOutPatientPaymentCategorisation.Text = "DataGridView1"
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(14, 40)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(188, 20)
        Me.lblEndDateTime.TabIndex = 53
        Me.lblEndDateTime.Text = "End Record Date Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(208, 14)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpStartDateTime.TabIndex = 52
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(14, 16)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(188, 20)
        Me.lblStartDateTime.TabIndex = 51
        Me.lblStartDateTime.Text = "Start Record Date Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(712, 101)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 62
        Me.fbnRefresh.Text = "&Refresh"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(632, 101)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 61
        Me.fbnLoad.Text = "&Load"
        '
        'tpgOutpatient
        '
        Me.tpgOutpatient.Controls.Add(Me.dgvOutPatientPaymentCategorisation)
        Me.tpgOutpatient.Location = New System.Drawing.Point(4, 22)
        Me.tpgOutpatient.Name = "tpgOutpatient"
        Me.tpgOutpatient.Size = New System.Drawing.Size(899, 259)
        Me.tpgOutpatient.TabIndex = 8
        Me.tpgOutpatient.Tag = ""
        Me.tpgOutpatient.Text = "Out patient"
        Me.tpgOutpatient.UseVisualStyleBackColor = True
        '
        'tbcPaymentCategorisation
        '
        Me.tbcPaymentCategorisation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPaymentCategorisation.Controls.Add(Me.tpgOutpatient)
        Me.tbcPaymentCategorisation.Controls.Add(Me.tpgInPatient)
        Me.tbcPaymentCategorisation.Controls.Add(Me.tpgAccounts)
        Me.tbcPaymentCategorisation.Controls.Add(Me.tpgOPDInvoiceDetails)
        Me.tbcPaymentCategorisation.Controls.Add(Me.tpgIPDInvoiceDetails)
        Me.tbcPaymentCategorisation.HotTrack = True
        Me.tbcPaymentCategorisation.Location = New System.Drawing.Point(5, 129)
        Me.tbcPaymentCategorisation.Name = "tbcPaymentCategorisation"
        Me.tbcPaymentCategorisation.SelectedIndex = 0
        Me.tbcPaymentCategorisation.Size = New System.Drawing.Size(907, 285)
        Me.tbcPaymentCategorisation.TabIndex = 47
        '
        'tpgAccounts
        '
        Me.tpgAccounts.Controls.Add(Me.dgvAccounts)
        Me.tpgAccounts.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccounts.Name = "tpgAccounts"
        Me.tpgAccounts.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAccounts.Size = New System.Drawing.Size(899, 259)
        Me.tpgAccounts.TabIndex = 11
        Me.tpgAccounts.Text = "Accounts"
        Me.tpgAccounts.UseVisualStyleBackColor = True
        '
        'dgvAccounts
        '
        Me.dgvAccounts.AllowUserToAddRows = False
        Me.dgvAccounts.AllowUserToDeleteRows = False
        Me.dgvAccounts.AllowUserToOrderColumns = True
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvAccounts.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAccounts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccounts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTransactionDate, Me.colTransactionNo, Me.colAccountsNo, Me.colAccountName, Me.colAmount, Me.colBalance})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccounts.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvAccounts.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAccounts.EnableHeadersVisualStyles = False
        Me.dgvAccounts.GridColor = System.Drawing.Color.Khaki
        Me.dgvAccounts.Location = New System.Drawing.Point(3, 3)
        Me.dgvAccounts.Name = "dgvAccounts"
        Me.dgvAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccounts.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvAccounts.RowHeadersVisible = False
        Me.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAccounts.Size = New System.Drawing.Size(893, 253)
        Me.dgvAccounts.TabIndex = 2
        Me.dgvAccounts.Text = "DataGridView1"
        '
        'ColTransactionDate
        '
        Me.ColTransactionDate.DataPropertyName = "TransactionDate"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.ColTransactionDate.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColTransactionDate.HeaderText = "Transaction Date"
        Me.ColTransactionDate.Name = "ColTransactionDate"
        '
        'colTransactionNo
        '
        Me.colTransactionNo.DataPropertyName = "TranNo"
        Me.colTransactionNo.HeaderText = "Transaction No"
        Me.colTransactionNo.Name = "colTransactionNo"
        '
        'colAccountsNo
        '
        Me.colAccountsNo.DataPropertyName = "AccountBillNo"
        Me.colAccountsNo.HeaderText = "Account No"
        Me.colAccountsNo.Name = "colAccountsNo"
        '
        'colAccountName
        '
        Me.colAccountName.DataPropertyName = "AccountName"
        Me.colAccountName.HeaderText = "Account Name"
        Me.colAccountName.Name = "colAccountName"
        Me.colAccountName.Width = 150
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Deposit"
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        '
        'colBalance
        '
        Me.colBalance.DataPropertyName = "Balance"
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        '
        'tpgOPDInvoiceDetails
        '
        Me.tpgOPDInvoiceDetails.Controls.Add(Me.dgvOPDAccountDetails)
        Me.tpgOPDInvoiceDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDInvoiceDetails.Name = "tpgOPDInvoiceDetails"
        Me.tpgOPDInvoiceDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOPDInvoiceDetails.Size = New System.Drawing.Size(899, 259)
        Me.tpgOPDInvoiceDetails.TabIndex = 9
        Me.tpgOPDInvoiceDetails.Text = "OPD Invoice Details"
        Me.tpgOPDInvoiceDetails.UseVisualStyleBackColor = True
        '
        'dgvOPDAccountDetails
        '
        Me.dgvOPDAccountDetails.AllowUserToAddRows = False
        Me.dgvOPDAccountDetails.AllowUserToDeleteRows = False
        Me.dgvOPDAccountDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOPDAccountDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvOPDAccountDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDAccountDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDAccountDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOPDAccountDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDAccountDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvOPDAccountDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOADPatientNo, Me.colOADFullName, Me.colOADvisitdate, Me.colOADVisitNo, Me.colOADservices, Me.ColOADDrug, Me.ColOADConsumable, Me.ColOADLaboratory, Me.ColOADRadiology, Me.ColOADPathology, Me.colOADDental, Me.ColOADTheatre, Me.ColOADOptical, Me.ColOADProcedureID, Me.ColOADExtras, Me.ColOADMaternity, Me.ColOADEye, Me.ColOADAdmission, Me.colOADPackages, Me.colOADICU, Me.colOADNonMedical, Me.ColOADTotal})
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOPDAccountDetails.DefaultCellStyle = DataGridViewCellStyle24
        Me.dgvOPDAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOPDAccountDetails.EnableHeadersVisualStyles = False
        Me.dgvOPDAccountDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDAccountDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgvOPDAccountDetails.Name = "dgvOPDAccountDetails"
        Me.dgvOPDAccountDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDAccountDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvOPDAccountDetails.RowHeadersVisible = False
        Me.dgvOPDAccountDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOPDAccountDetails.Size = New System.Drawing.Size(893, 253)
        Me.dgvOPDAccountDetails.TabIndex = 2
        Me.dgvOPDAccountDetails.Text = "DataGridView1"
        '
        'colOADPatientNo
        '
        Me.colOADPatientNo.DataPropertyName = "PatientNo"
        Me.colOADPatientNo.HeaderText = "Patient No"
        Me.colOADPatientNo.Name = "colOADPatientNo"
        '
        'colOADFullName
        '
        Me.colOADFullName.DataPropertyName = "FullName"
        Me.colOADFullName.HeaderText = "Patient  Name"
        Me.colOADFullName.Name = "colOADFullName"
        Me.colOADFullName.Width = 150
        '
        'colOADvisitdate
        '
        Me.colOADvisitdate.DataPropertyName = "VisitDate"
        DataGridViewCellStyle22.Format = "d"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colOADvisitdate.DefaultCellStyle = DataGridViewCellStyle22
        Me.colOADvisitdate.HeaderText = "Visit Date"
        Me.colOADvisitdate.Name = "colOADvisitdate"
        Me.colOADvisitdate.Width = 70
        '
        'colOADVisitNo
        '
        Me.colOADVisitNo.DataPropertyName = "VisitNo"
        Me.colOADVisitNo.HeaderText = "Visit No"
        Me.colOADVisitNo.Name = "colOADVisitNo"
        '
        'colOADservices
        '
        Me.colOADservices.DataPropertyName = "services"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.colOADservices.DefaultCellStyle = DataGridViewCellStyle23
        Me.colOADservices.HeaderText = "Services"
        Me.colOADservices.Name = "colOADservices"
        '
        'ColOADDrug
        '
        Me.ColOADDrug.DataPropertyName = "Drug"
        Me.ColOADDrug.HeaderText = "Drug"
        Me.ColOADDrug.Name = "ColOADDrug"
        '
        'ColOADConsumable
        '
        Me.ColOADConsumable.DataPropertyName = "Consumable"
        Me.ColOADConsumable.HeaderText = "Consumables"
        Me.ColOADConsumable.Name = "ColOADConsumable"
        '
        'ColOADLaboratory
        '
        Me.ColOADLaboratory.DataPropertyName = "Laboratory"
        Me.ColOADLaboratory.HeaderText = "Laboratory"
        Me.ColOADLaboratory.Name = "ColOADLaboratory"
        '
        'ColOADRadiology
        '
        Me.ColOADRadiology.DataPropertyName = "Radiology"
        Me.ColOADRadiology.HeaderText = "Radiology"
        Me.ColOADRadiology.Name = "ColOADRadiology"
        '
        'ColOADPathology
        '
        Me.ColOADPathology.DataPropertyName = "Pathology"
        Me.ColOADPathology.HeaderText = "Pathology"
        Me.ColOADPathology.Name = "ColOADPathology"
        '
        'colOADDental
        '
        Me.colOADDental.DataPropertyName = "Dental"
        Me.colOADDental.HeaderText = "Dental"
        Me.colOADDental.Name = "colOADDental"
        '
        'ColOADTheatre
        '
        Me.ColOADTheatre.DataPropertyName = "Theatre"
        Me.ColOADTheatre.HeaderText = "Theatre"
        Me.ColOADTheatre.Name = "ColOADTheatre"
        '
        'ColOADOptical
        '
        Me.ColOADOptical.DataPropertyName = "Optical"
        Me.ColOADOptical.HeaderText = "Optical"
        Me.ColOADOptical.Name = "ColOADOptical"
        '
        'ColOADProcedureID
        '
        Me.ColOADProcedureID.DataPropertyName = "ProcedureID"
        Me.ColOADProcedureID.HeaderText = "Procedure"
        Me.ColOADProcedureID.Name = "ColOADProcedureID"
        '
        'ColOADExtras
        '
        Me.ColOADExtras.DataPropertyName = "Extras"
        Me.ColOADExtras.HeaderText = "Extras"
        Me.ColOADExtras.Name = "ColOADExtras"
        '
        'ColOADMaternity
        '
        Me.ColOADMaternity.DataPropertyName = "Maternity"
        Me.ColOADMaternity.HeaderText = "Maternity"
        Me.ColOADMaternity.Name = "ColOADMaternity"
        '
        'ColOADEye
        '
        Me.ColOADEye.DataPropertyName = "Eye"
        Me.ColOADEye.HeaderText = "Eye"
        Me.ColOADEye.Name = "ColOADEye"
        '
        'ColOADAdmission
        '
        Me.ColOADAdmission.DataPropertyName = "Admission"
        Me.ColOADAdmission.HeaderText = "Admission"
        Me.ColOADAdmission.Name = "ColOADAdmission"
        '
        'colOADPackages
        '
        Me.colOADPackages.DataPropertyName = "Packages"
        Me.colOADPackages.HeaderText = "Packages"
        Me.colOADPackages.Name = "colOADPackages"
        '
        'colOADICU
        '
        Me.colOADICU.DataPropertyName = "ICU"
        Me.colOADICU.HeaderText = "ICU"
        Me.colOADICU.Name = "colOADICU"
        '
        'colOADNonMedical
        '
        Me.colOADNonMedical.DataPropertyName = "NonMedical"
        Me.colOADNonMedical.HeaderText = "Non Medical"
        Me.colOADNonMedical.Name = "colOADNonMedical"
        '
        'ColOADTotal
        '
        Me.ColOADTotal.DataPropertyName = "Total"
        Me.ColOADTotal.HeaderText = "Total"
        Me.ColOADTotal.Name = "ColOADTotal"
        '
        'tpgIPDInvoiceDetails
        '
        Me.tpgIPDInvoiceDetails.Controls.Add(Me.dgvIPDAccountDetails)
        Me.tpgIPDInvoiceDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDInvoiceDetails.Name = "tpgIPDInvoiceDetails"
        Me.tpgIPDInvoiceDetails.Size = New System.Drawing.Size(899, 259)
        Me.tpgIPDInvoiceDetails.TabIndex = 10
        Me.tpgIPDInvoiceDetails.Text = "IPD Invoice Details"
        Me.tpgIPDInvoiceDetails.UseVisualStyleBackColor = True
        '
        'dgvIPDAccountDetails
        '
        Me.dgvIPDAccountDetails.AllowUserToAddRows = False
        Me.dgvIPDAccountDetails.AllowUserToDeleteRows = False
        Me.dgvIPDAccountDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDAccountDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvIPDAccountDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDAccountDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDAccountDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDAccountDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDAccountDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvIPDAccountDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIADPatientNo, Me.colIADFullName, Me.colIADvisitdate, Me.colIADvisitNo, Me.colIADservices, Me.ColIADDrug, Me.ColIADConsumable, Me.ColIADLaboratory, Me.ColIADRadiology, Me.ColIADPathology, Me.colIADDental, Me.ColIADTheatre, Me.ColIADOptical, Me.ColIADProcedureID, Me.ColIADExtras, Me.ColIADMaternity, Me.ColIADEye, Me.ColIADAdmission, Me.ColIADPackages, Me.colIADICU, Me.colIADNonMedical, Me.ColIADTotal})
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDAccountDetails.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgvIPDAccountDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDAccountDetails.EnableHeadersVisualStyles = False
        Me.dgvIPDAccountDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDAccountDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDAccountDetails.Name = "dgvIPDAccountDetails"
        Me.dgvIPDAccountDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDAccountDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvIPDAccountDetails.RowHeadersVisible = False
        Me.dgvIPDAccountDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDAccountDetails.Size = New System.Drawing.Size(899, 259)
        Me.dgvIPDAccountDetails.TabIndex = 2
        Me.dgvIPDAccountDetails.Text = "DataGridView1"
        '
        'colIADPatientNo
        '
        Me.colIADPatientNo.DataPropertyName = "PatientNo"
        Me.colIADPatientNo.HeaderText = "Patient No"
        Me.colIADPatientNo.Name = "colIADPatientNo"
        '
        'colIADFullName
        '
        Me.colIADFullName.DataPropertyName = "FullName"
        Me.colIADFullName.HeaderText = "Patient  Name"
        Me.colIADFullName.Name = "colIADFullName"
        Me.colIADFullName.Width = 150
        '
        'colIADvisitdate
        '
        Me.colIADvisitdate.DataPropertyName = "visitDate"
        DataGridViewCellStyle28.Format = "d"
        DataGridViewCellStyle28.NullValue = Nothing
        Me.colIADvisitdate.DefaultCellStyle = DataGridViewCellStyle28
        Me.colIADvisitdate.HeaderText = "Visit Date"
        Me.colIADvisitdate.Name = "colIADvisitdate"
        Me.colIADvisitdate.Width = 70
        '
        'colIADvisitNo
        '
        Me.colIADvisitNo.DataPropertyName = "visitNo"
        Me.colIADvisitNo.HeaderText = "visit No"
        Me.colIADvisitNo.Name = "colIADvisitNo"
        '
        'colIADservices
        '
        Me.colIADservices.DataPropertyName = "services"
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colIADservices.DefaultCellStyle = DataGridViewCellStyle29
        Me.colIADservices.HeaderText = "Services"
        Me.colIADservices.Name = "colIADservices"
        '
        'ColIADDrug
        '
        Me.ColIADDrug.DataPropertyName = "Drug"
        Me.ColIADDrug.HeaderText = "Drug"
        Me.ColIADDrug.Name = "ColIADDrug"
        '
        'ColIADConsumable
        '
        Me.ColIADConsumable.DataPropertyName = "Consumable"
        Me.ColIADConsumable.HeaderText = "Consumables"
        Me.ColIADConsumable.Name = "ColIADConsumable"
        '
        'ColIADLaboratory
        '
        Me.ColIADLaboratory.DataPropertyName = "Laboratory"
        Me.ColIADLaboratory.HeaderText = "Laboratory"
        Me.ColIADLaboratory.Name = "ColIADLaboratory"
        '
        'ColIADRadiology
        '
        Me.ColIADRadiology.DataPropertyName = "Radiology"
        Me.ColIADRadiology.HeaderText = "Radiology"
        Me.ColIADRadiology.Name = "ColIADRadiology"
        '
        'ColIADPathology
        '
        Me.ColIADPathology.DataPropertyName = "Pathology"
        Me.ColIADPathology.HeaderText = "Pathology"
        Me.ColIADPathology.Name = "ColIADPathology"
        '
        'colIADDental
        '
        Me.colIADDental.DataPropertyName = "Dental"
        Me.colIADDental.HeaderText = "Dental"
        Me.colIADDental.Name = "colIADDental"
        '
        'ColIADTheatre
        '
        Me.ColIADTheatre.DataPropertyName = "Theatre"
        Me.ColIADTheatre.HeaderText = "Theatre"
        Me.ColIADTheatre.Name = "ColIADTheatre"
        '
        'ColIADOptical
        '
        Me.ColIADOptical.DataPropertyName = "Optical"
        Me.ColIADOptical.HeaderText = "Optical"
        Me.ColIADOptical.Name = "ColIADOptical"
        '
        'ColIADProcedureID
        '
        Me.ColIADProcedureID.DataPropertyName = "ProcedureID"
        Me.ColIADProcedureID.HeaderText = "Procedure"
        Me.ColIADProcedureID.Name = "ColIADProcedureID"
        '
        'ColIADExtras
        '
        Me.ColIADExtras.DataPropertyName = "Extras"
        Me.ColIADExtras.HeaderText = "Extras"
        Me.ColIADExtras.Name = "ColIADExtras"
        '
        'ColIADMaternity
        '
        Me.ColIADMaternity.DataPropertyName = "Maternity"
        Me.ColIADMaternity.HeaderText = "Maternity"
        Me.ColIADMaternity.Name = "ColIADMaternity"
        '
        'ColIADEye
        '
        Me.ColIADEye.DataPropertyName = "Eye"
        Me.ColIADEye.HeaderText = "Eye"
        Me.ColIADEye.Name = "ColIADEye"
        '
        'ColIADAdmission
        '
        Me.ColIADAdmission.DataPropertyName = "Admission"
        Me.ColIADAdmission.HeaderText = "Admission"
        Me.ColIADAdmission.Name = "ColIADAdmission"
        '
        'ColIADPackages
        '
        Me.ColIADPackages.DataPropertyName = "Packages"
        Me.ColIADPackages.HeaderText = "Packages"
        Me.ColIADPackages.Name = "ColIADPackages"
        '
        'colIADICU
        '
        Me.colIADICU.DataPropertyName = "ICU"
        Me.colIADICU.HeaderText = "ICU"
        Me.colIADICU.Name = "colIADICU"
        '
        'colIADNonMedical
        '
        Me.colIADNonMedical.DataPropertyName = "NonMedical"
        Me.colIADNonMedical.HeaderText = "Non Medical"
        Me.colIADNonMedical.Name = "colIADNonMedical"
        '
        'ColIADTotal
        '
        Me.ColIADTotal.DataPropertyName = "Total"
        Me.ColIADTotal.HeaderText = "Total"
        Me.ColIADTotal.Name = "ColIADTotal"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(583, 83)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(283, 13)
        Me.lblRecordsNo.TabIndex = 68
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(397, 80)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 89
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.Visible = False
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccountNo.DropDownWidth = 256
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.ItemHeight = 13
        Me.cboAccountNo.Location = New System.Drawing.Point(208, 83)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountNo.TabIndex = 88
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(14, 81)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(188, 18)
        Me.lblAccountNo.TabIndex = 87
        Me.lblAccountNo.Text = "Account No ( Leave Blank for all )"
        '
        'cboBillMode
        '
        Me.cboBillMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillMode.DropDownWidth = 300
        Me.cboBillMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillMode.FormattingEnabled = True
        Me.cboBillMode.Location = New System.Drawing.Point(208, 59)
        Me.cboBillMode.MaxLength = 20
        Me.cboBillMode.Name = "cboBillMode"
        Me.cboBillMode.Size = New System.Drawing.Size(183, 21)
        Me.cboBillMode.TabIndex = 80
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(14, 60)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(188, 20)
        Me.lblBillMode.TabIndex = 79
        Me.lblBillMode.Text = "Account Category"
        '
        'stbAccountName
        '
        Me.stbAccountName.AllowDrop = True
        Me.stbAccountName.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(696, 18)
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(170, 20)
        Me.stbAccountName.TabIndex = 82
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(490, 18)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountName.TabIndex = 81
        Me.lblAccountName.Text = "Account Name"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.AllowDrop = True
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Account Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Location = New System.Drawing.Point(696, 39)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.ReadOnly = True
        Me.nbxAccountBalance.Size = New System.Drawing.Size(170, 20)
        Me.nbxAccountBalance.TabIndex = 84
        Me.nbxAccountBalance.Value = ""
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(490, 38)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountBalance.TabIndex = 83
        Me.lblAccountBalance.Text = "Account Balance"
        '
        'nbxOutstandingBill
        '
        Me.nbxOutstandingBill.AllowDrop = True
        Me.nbxOutstandingBill.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBill.ControlCaption = "Outstanding Bill"
        Me.nbxOutstandingBill.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBill.DecimalPlaces = -1
        Me.nbxOutstandingBill.Location = New System.Drawing.Point(696, 60)
        Me.nbxOutstandingBill.MaxValue = 0.0R
        Me.nbxOutstandingBill.MinValue = 0.0R
        Me.nbxOutstandingBill.MustEnterNumeric = True
        Me.nbxOutstandingBill.Name = "nbxOutstandingBill"
        Me.nbxOutstandingBill.ReadOnly = True
        Me.nbxOutstandingBill.Size = New System.Drawing.Size(170, 20)
        Me.nbxOutstandingBill.TabIndex = 86
        Me.nbxOutstandingBill.Value = ""
        '
        'lblOutstandingBill
        '
        Me.lblOutstandingBill.Location = New System.Drawing.Point(490, 60)
        Me.lblOutstandingBill.Name = "lblOutstandingBill"
        Me.lblOutstandingBill.Size = New System.Drawing.Size(200, 20)
        Me.lblOutstandingBill.TabIndex = 85
        Me.lblOutstandingBill.Text = "Outstanding Bill"
        '
        'ColInvoiceNo
        '
        Me.ColInvoiceNo.DataPropertyName = "ReceiptNo"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.ColInvoiceNo.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColInvoiceNo.HeaderText = "Receipt No"
        Me.ColInvoiceNo.Name = "ColInvoiceNo"
        '
        'colAccountNo
        '
        Me.colAccountNo.DataPropertyName = "AccountNo"
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Patient  Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.Width = 150
        '
        'colvisitdate
        '
        Me.colvisitdate.DataPropertyName = "paydate"
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colvisitdate.DefaultCellStyle = DataGridViewCellStyle11
        Me.colvisitdate.HeaderText = "Pay Date"
        Me.colvisitdate.Name = "colvisitdate"
        Me.colvisitdate.Width = 70
        '
        'colPayNo
        '
        Me.colPayNo.DataPropertyName = "PayNo"
        Me.colPayNo.HeaderText = "Pay No"
        Me.colPayNo.Name = "colPayNo"
        '
        'colTotalBill
        '
        Me.colTotalBill.DataPropertyName = "TotalBill"
        Me.colTotalBill.HeaderText = "Total Bill"
        Me.colTotalBill.Name = "colTotalBill"
        '
        'colAmountTendered
        '
        Me.colAmountTendered.DataPropertyName = "AmountTendered"
        Me.colAmountTendered.HeaderText = "Amount Tendered"
        Me.colAmountTendered.Name = "colAmountTendered"
        '
        'colCollections
        '
        Me.colCollections.DataPropertyName = "Collections"
        Me.colCollections.HeaderText = "Collections"
        Me.colCollections.Name = "colCollections"
        '
        'colCreditSales
        '
        Me.colCreditSales.DataPropertyName = "CreditSales"
        Me.colCreditSales.HeaderText = "Credit Sales"
        Me.colCreditSales.Name = "colCreditSales"
        '
        'colRefundAmount
        '
        Me.colRefundAmount.DataPropertyName = "AmountRefunded"
        Me.colRefundAmount.HeaderText = "Refund Amount"
        Me.colRefundAmount.Name = "colRefundAmount"
        Me.colRefundAmount.ReadOnly = True
        '
        'colNetAmount
        '
        Me.colNetAmount.DataPropertyName = "NetAmount"
        Me.colNetAmount.HeaderText = "Net Amount"
        Me.colNetAmount.Name = "colNetAmount"
        Me.colNetAmount.ReadOnly = True
        '
        'colservices
        '
        Me.colservices.DataPropertyName = "services"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colservices.DefaultCellStyle = DataGridViewCellStyle12
        Me.colservices.HeaderText = "Services"
        Me.colservices.Name = "colservices"
        '
        'ColDrug
        '
        Me.ColDrug.DataPropertyName = "Drug"
        Me.ColDrug.HeaderText = "Drug"
        Me.ColDrug.Name = "ColDrug"
        '
        'ColConsumable
        '
        Me.ColConsumable.DataPropertyName = "Consumable"
        Me.ColConsumable.HeaderText = "Consumables"
        Me.ColConsumable.Name = "ColConsumable"
        '
        'ColLaboratory
        '
        Me.ColLaboratory.DataPropertyName = "Laboratory"
        Me.ColLaboratory.HeaderText = "Laboratory"
        Me.ColLaboratory.Name = "ColLaboratory"
        '
        'ColRadiology
        '
        Me.ColRadiology.DataPropertyName = "Radiology"
        Me.ColRadiology.HeaderText = "Radiology"
        Me.ColRadiology.Name = "ColRadiology"
        '
        'ColPathology
        '
        Me.ColPathology.DataPropertyName = "Pathology"
        Me.ColPathology.HeaderText = "Pathology"
        Me.ColPathology.Name = "ColPathology"
        '
        'colDental
        '
        Me.colDental.DataPropertyName = "Dental"
        Me.colDental.HeaderText = "Dental"
        Me.colDental.Name = "colDental"
        '
        'ColTheatre
        '
        Me.ColTheatre.DataPropertyName = "Theatre"
        Me.ColTheatre.HeaderText = "Theatre"
        Me.ColTheatre.Name = "ColTheatre"
        '
        'ColOptical
        '
        Me.ColOptical.DataPropertyName = "Optical"
        Me.ColOptical.HeaderText = "Optical"
        Me.ColOptical.Name = "ColOptical"
        '
        'ColProcedureID
        '
        Me.ColProcedureID.DataPropertyName = "ProcedureID"
        Me.ColProcedureID.HeaderText = "Procedure"
        Me.ColProcedureID.Name = "ColProcedureID"
        '
        'ColExtras
        '
        Me.ColExtras.DataPropertyName = "Extras"
        Me.ColExtras.HeaderText = "Extras"
        Me.ColExtras.Name = "ColExtras"
        '
        'ColMaternity
        '
        Me.ColMaternity.DataPropertyName = "Maternity"
        Me.ColMaternity.HeaderText = "Maternity"
        Me.ColMaternity.Name = "ColMaternity"
        '
        'ColEye
        '
        Me.ColEye.DataPropertyName = "Eye"
        Me.ColEye.HeaderText = "Eye"
        Me.ColEye.Name = "ColEye"
        '
        'ColAdmission
        '
        Me.ColAdmission.DataPropertyName = "Admission"
        Me.ColAdmission.HeaderText = "Admission"
        Me.ColAdmission.Name = "ColAdmission"
        '
        'ColPackages
        '
        Me.ColPackages.DataPropertyName = "Packages"
        Me.ColPackages.HeaderText = "Packages"
        Me.ColPackages.Name = "ColPackages"
        '
        'colICU
        '
        Me.colICU.DataPropertyName = "ICU"
        Me.colICU.HeaderText = "ICU"
        Me.colICU.Name = "colICU"
        '
        'colNonMedical
        '
        Me.colNonMedical.DataPropertyName = "NonMedical"
        Me.colNonMedical.HeaderText = "Non Medical"
        Me.colNonMedical.Name = "colNonMedical"
        '
        'ColTotal
        '
        Me.ColTotal.DataPropertyName = "Total"
        Me.ColTotal.HeaderText = "Total"
        Me.ColTotal.Name = "ColTotal"
        '
        'colWithholdingTax
        '
        Me.colWithholdingTax.DataPropertyName = "WithholdingTax"
        Me.colWithholdingTax.HeaderText = "Withholding Tax"
        Me.colWithholdingTax.Name = "colWithholdingTax"
        Me.colWithholdingTax.ReadOnly = True
        '
        'colGrandDiscount
        '
        Me.colGrandDiscount.DataPropertyName = "GrandDiscount"
        Me.colGrandDiscount.HeaderText = "Grand Discount"
        Me.colGrandDiscount.Name = "colGrandDiscount"
        Me.colGrandDiscount.ReadOnly = True
        '
        'colIPDReceiptNo
        '
        Me.colIPDReceiptNo.DataPropertyName = "ReceiptNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colIPDReceiptNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colIPDReceiptNo.HeaderText = "Receipt No"
        Me.colIPDReceiptNo.Name = "colIPDReceiptNo"
        '
        'colIPDAccountNo
        '
        Me.colIPDAccountNo.DataPropertyName = "AccountNo"
        Me.colIPDAccountNo.HeaderText = "Account No"
        Me.colIPDAccountNo.Name = "colIPDAccountNo"
        '
        'colPatientName
        '
        Me.colPatientName.DataPropertyName = "FullName"
        Me.colPatientName.HeaderText = "Patient  Name"
        Me.colPatientName.Name = "colPatientName"
        Me.colPatientName.Width = 150
        '
        'colIPDpaydate
        '
        Me.colIPDpaydate.DataPropertyName = "paydate"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colIPDpaydate.DefaultCellStyle = DataGridViewCellStyle4
        Me.colIPDpaydate.HeaderText = "Pay Date"
        Me.colIPDpaydate.Name = "colIPDpaydate"
        Me.colIPDpaydate.Width = 70
        '
        'ColIPDPayNo
        '
        Me.ColIPDPayNo.DataPropertyName = "PayNo"
        Me.ColIPDPayNo.HeaderText = "Pay No"
        Me.ColIPDPayNo.Name = "ColIPDPayNo"
        '
        'colIPDTotalBill
        '
        Me.colIPDTotalBill.DataPropertyName = "TotalBill"
        Me.colIPDTotalBill.HeaderText = "Total Bill"
        Me.colIPDTotalBill.Name = "colIPDTotalBill"
        '
        'colIPDAmountTendered
        '
        Me.colIPDAmountTendered.DataPropertyName = "AmountTendered"
        Me.colIPDAmountTendered.HeaderText = "Amount Tendered"
        Me.colIPDAmountTendered.Name = "colIPDAmountTendered"
        '
        'colIPDCollections
        '
        Me.colIPDCollections.DataPropertyName = "Collections"
        Me.colIPDCollections.HeaderText = "Collections"
        Me.colIPDCollections.Name = "colIPDCollections"
        '
        'colIPDCreditSales
        '
        Me.colIPDCreditSales.DataPropertyName = "CreditSales"
        Me.colIPDCreditSales.HeaderText = "Credit Sales"
        Me.colIPDCreditSales.Name = "colIPDCreditSales"
        '
        'colIPDRefundAmount
        '
        Me.colIPDRefundAmount.DataPropertyName = "AmountRefunded"
        Me.colIPDRefundAmount.HeaderText = "Refund Amount"
        Me.colIPDRefundAmount.Name = "colIPDRefundAmount"
        Me.colIPDRefundAmount.ReadOnly = True
        '
        'colIPDNetAmount
        '
        Me.colIPDNetAmount.DataPropertyName = "NetAmount"
        Me.colIPDNetAmount.HeaderText = "Net Amount"
        Me.colIPDNetAmount.Name = "colIPDNetAmount"
        Me.colIPDNetAmount.ReadOnly = True
        '
        'colIPDservices
        '
        Me.colIPDservices.DataPropertyName = "services"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colIPDservices.DefaultCellStyle = DataGridViewCellStyle5
        Me.colIPDservices.HeaderText = "Services"
        Me.colIPDservices.Name = "colIPDservices"
        '
        'colIPDDrug
        '
        Me.colIPDDrug.DataPropertyName = "Drug"
        Me.colIPDDrug.HeaderText = "Drug"
        Me.colIPDDrug.Name = "colIPDDrug"
        '
        'colIPDConsumable
        '
        Me.colIPDConsumable.DataPropertyName = "Consumable"
        Me.colIPDConsumable.HeaderText = "Consumables"
        Me.colIPDConsumable.Name = "colIPDConsumable"
        '
        'colIPDLaboratory
        '
        Me.colIPDLaboratory.DataPropertyName = "Laboratory"
        Me.colIPDLaboratory.HeaderText = "Laboratory"
        Me.colIPDLaboratory.Name = "colIPDLaboratory"
        '
        'colIPDRadiology
        '
        Me.colIPDRadiology.DataPropertyName = "Radiology"
        Me.colIPDRadiology.HeaderText = "Radiology"
        Me.colIPDRadiology.Name = "colIPDRadiology"
        '
        'colIPDPathology
        '
        Me.colIPDPathology.DataPropertyName = "Pathology"
        Me.colIPDPathology.HeaderText = "Pathology"
        Me.colIPDPathology.Name = "colIPDPathology"
        '
        'colIPDDental
        '
        Me.colIPDDental.DataPropertyName = "Dental"
        Me.colIPDDental.HeaderText = "Dental"
        Me.colIPDDental.Name = "colIPDDental"
        '
        'colIPDTheatre
        '
        Me.colIPDTheatre.DataPropertyName = "Theatre"
        Me.colIPDTheatre.HeaderText = "Theatre"
        Me.colIPDTheatre.Name = "colIPDTheatre"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Optical"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Optical"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'colIPDProcedureID
        '
        Me.colIPDProcedureID.DataPropertyName = "ProcedureID"
        Me.colIPDProcedureID.HeaderText = "Procedure"
        Me.colIPDProcedureID.Name = "colIPDProcedureID"
        '
        'colIPDExtras
        '
        Me.colIPDExtras.DataPropertyName = "Extras"
        Me.colIPDExtras.HeaderText = "Extras"
        Me.colIPDExtras.Name = "colIPDExtras"
        '
        'colIPDMaternity
        '
        Me.colIPDMaternity.DataPropertyName = "Maternity"
        Me.colIPDMaternity.HeaderText = "Maternity"
        Me.colIPDMaternity.Name = "colIPDMaternity"
        '
        'colIPDEye
        '
        Me.colIPDEye.DataPropertyName = "Eye"
        Me.colIPDEye.HeaderText = "Eye"
        Me.colIPDEye.Name = "colIPDEye"
        '
        'colIPDAdmission
        '
        Me.colIPDAdmission.DataPropertyName = "Admission"
        Me.colIPDAdmission.HeaderText = "Admission"
        Me.colIPDAdmission.Name = "colIPDAdmission"
        '
        'colIPDPackages
        '
        Me.colIPDPackages.DataPropertyName = "Packages"
        Me.colIPDPackages.HeaderText = "Packages"
        Me.colIPDPackages.Name = "colIPDPackages"
        '
        'colIPDICU
        '
        Me.colIPDICU.DataPropertyName = "ICU"
        Me.colIPDICU.HeaderText = "ICU"
        Me.colIPDICU.Name = "colIPDICU"
        '
        'colIPDNonMedical
        '
        Me.colIPDNonMedical.DataPropertyName = "NonMedical"
        Me.colIPDNonMedical.HeaderText = "Non Medical"
        Me.colIPDNonMedical.Name = "colIPDNonMedical"
        '
        'colIPDTotal
        '
        Me.colIPDTotal.DataPropertyName = "Total"
        Me.colIPDTotal.HeaderText = "Total"
        Me.colIPDTotal.Name = "colIPDTotal"
        '
        'colIPDGrandDiscount
        '
        Me.colIPDGrandDiscount.DataPropertyName = "GrandDiscount"
        Me.colIPDGrandDiscount.HeaderText = "Grand Discount"
        Me.colIPDGrandDiscount.Name = "colIPDGrandDiscount"
        Me.colIPDGrandDiscount.ReadOnly = True
        '
        'colIPDWithholdingTax
        '
        Me.colIPDWithholdingTax.DataPropertyName = "WithholdingTax"
        Me.colIPDWithholdingTax.HeaderText = "Withholding Tax"
        Me.colIPDWithholdingTax.Name = "colIPDWithholdingTax"
        Me.colIPDWithholdingTax.ReadOnly = True
        '
        'frmPaymentCategorisation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 460)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.cboBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.nbxOutstandingBill)
        Me.Controls.Add(Me.lblOutstandingBill)
        Me.Controls.Add(Me.fbnExport)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dtpEndDateTime)
        Me.Controls.Add(Me.lblEndDateTime)
        Me.Controls.Add(Me.dtpStartDateTime)
        Me.Controls.Add(Me.lblStartDateTime)
        Me.Controls.Add(Me.fbnRefresh)
        Me.Controls.Add(Me.fbnLoad)
        Me.Controls.Add(Me.tbcPaymentCategorisation)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPaymentCategorisation"
        Me.Text = "Payment Categorisation"
        Me.tpgInPatient.ResumeLayout(False)
        Me.tpgInPatient.PerformLayout()
        CType(Me.dgvIPDPatientPaymentCategorisation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOutPatientPaymentCategorisation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOutpatient.ResumeLayout(False)
        Me.tbcPaymentCategorisation.ResumeLayout(False)
        Me.tpgAccounts.ResumeLayout(False)
        CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOPDInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvOPDAccountDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvIPDAccountDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgInPatient As System.Windows.Forms.TabPage
    Friend WithEvents stbPatientChequePaymentsWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblExpenditureAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbPatientChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvOutPatientPaymentCategorisation As System.Windows.Forms.DataGridView
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgOutpatient As System.Windows.Forms.TabPage
    Friend WithEvents tbcPaymentCategorisation As System.Windows.Forms.TabControl
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents dgvIPDPatientPaymentCategorisation As System.Windows.Forms.DataGridView
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents cboBillMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBill As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBill As System.Windows.Forms.Label
    Friend WithEvents tpgOPDInvoiceDetails As System.Windows.Forms.TabPage
    Friend WithEvents tpgIPDInvoiceDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvOPDAccountDetails As System.Windows.Forms.DataGridView
    Friend WithEvents dgvIPDAccountDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colOADPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADvisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADOptical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADICU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOADNonMedical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOADTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADvisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADvisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADOptical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADICU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIADNonMedical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIADTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpgAccounts As System.Windows.Forms.TabPage
    Friend WithEvents dgvAccounts As System.Windows.Forms.DataGridView
    Friend WithEvents ColTransactionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransactionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountsNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDpaydate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPayNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDTotalBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDAmountTendered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDCollections As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDCreditSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDRefundAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDICU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDNonMedical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDGrandDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDWithholdingTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colvisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountTendered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCollections As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreditSales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOptical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNonMedical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWithholdingTax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGrandDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
