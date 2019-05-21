
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountStatement : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountStatement))
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxOutstandingBill = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.lblOutstandingBill = New System.Windows.Forms.Label()
        Me.tbcAccountStatement = New System.Windows.Forms.TabControl()
        Me.tpgOPDItems = New System.Windows.Forms.TabPage()
        Me.stbTotalOPDBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stbTotalOPDBills = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalOPDBills = New System.Windows.Forms.Label()
        Me.dgvOPDBills = New System.Windows.Forms.DataGridView()
        Me.colOPDBillViistNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOPDBillAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDItems = New System.Windows.Forms.TabPage()
        Me.stbTotalIPDBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stblTotalIPDBills = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalIPDBills = New System.Windows.Forms.Label()
        Me.dgvIPDBills = New System.Windows.Forms.DataGridView()
        Me.colIPDBillExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDBillAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgVisitPayment = New System.Windows.Forms.TabPage()
        Me.stbTotalPaymentWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stbTotalPayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalPayments = New System.Windows.Forms.Label()
        Me.dgvCashReceipts = New System.Windows.Forms.DataGridView()
        Me.colPayReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgRefunds = New System.Windows.Forms.TabPage()
        Me.stbTotalRefundWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbTotalRefunds = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalRefunds = New System.Windows.Forms.Label()
        Me.dgvRefunds = New System.Windows.Forms.DataGridView()
        Me.colRefTransactionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgAccountTransactions = New System.Windows.Forms.TabPage()
        Me.stbNetAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNetAmountWords = New System.Windows.Forms.Label()
        Me.stbNetAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNetAmount = New System.Windows.Forms.Label()
        Me.stbTotalCredit = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalCredit = New System.Windows.Forms.Label()
        Me.stbTotalDebit = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalDebit = New System.Windows.Forms.Label()
        Me.stbPatientChequePaymentsWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbPatientChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvAccountTrasaction = New System.Windows.Forms.DataGridView()
        Me.cboBillMode = New System.Windows.Forms.ComboBox()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.chkIncludeProcessing = New System.Windows.Forms.CheckBox()
        Me.stbBalance = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.stbBalanceWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBalanceWords = New System.Windows.Forms.Label()
        Me.chkIncludePending = New System.Windows.Forms.CheckBox()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.colTranNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTranDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.collAccAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcAccountStatement.SuspendLayout()
        Me.tpgOPDItems.SuspendLayout()
        CType(Me.dgvOPDBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDItems.SuspendLayout()
        CType(Me.dgvIPDBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgVisitPayment.SuspendLayout()
        CType(Me.dgvCashReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgRefunds.SuspendLayout()
        CType(Me.dgvRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAccountTransactions.SuspendLayout()
        CType(Me.dgvAccountTrasaction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbAccountName
        '
        Me.stbAccountName.AllowDrop = True
        Me.stbAccountName.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(675, 8)
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(170, 20)
        Me.stbAccountName.TabIndex = 10
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.AllowDrop = True
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Account Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Location = New System.Drawing.Point(675, 29)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.ReadOnly = True
        Me.nbxAccountBalance.Size = New System.Drawing.Size(170, 20)
        Me.nbxAccountBalance.TabIndex = 13
        Me.nbxAccountBalance.Value = ""
        '
        'nbxOutstandingBill
        '
        Me.nbxOutstandingBill.AllowDrop = True
        Me.nbxOutstandingBill.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBill.ControlCaption = "Outstanding Bill"
        Me.nbxOutstandingBill.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBill.DecimalPlaces = -1
        Me.nbxOutstandingBill.Location = New System.Drawing.Point(675, 51)
        Me.nbxOutstandingBill.MaxValue = 0.0R
        Me.nbxOutstandingBill.MinValue = 0.0R
        Me.nbxOutstandingBill.MustEnterNumeric = True
        Me.nbxOutstandingBill.Name = "nbxOutstandingBill"
        Me.nbxOutstandingBill.ReadOnly = True
        Me.nbxOutstandingBill.Size = New System.Drawing.Size(170, 20)
        Me.nbxOutstandingBill.TabIndex = 15
        Me.nbxOutstandingBill.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(776, 468)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(15, 13)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(181, 20)
        Me.lblBillMode.TabIndex = 0
        Me.lblBillMode.Text = "Account Category"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(475, 10)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(143, 20)
        Me.lblAccountName.TabIndex = 9
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(475, 30)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(143, 20)
        Me.lblAccountBalance.TabIndex = 11
        Me.lblAccountBalance.Text = "Account Balance"
        '
        'lblOutstandingBill
        '
        Me.lblOutstandingBill.Location = New System.Drawing.Point(475, 53)
        Me.lblOutstandingBill.Name = "lblOutstandingBill"
        Me.lblOutstandingBill.Size = New System.Drawing.Size(143, 20)
        Me.lblOutstandingBill.TabIndex = 14
        Me.lblOutstandingBill.Text = "Outstanding Bill"
        '
        'tbcAccountStatement
        '
        Me.tbcAccountStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcAccountStatement.Controls.Add(Me.tpgOPDItems)
        Me.tbcAccountStatement.Controls.Add(Me.tpgIPDItems)
        Me.tbcAccountStatement.Controls.Add(Me.tpgVisitPayment)
        Me.tbcAccountStatement.Controls.Add(Me.tpgRefunds)
        Me.tbcAccountStatement.Controls.Add(Me.tpgAccountTransactions)
        Me.tbcAccountStatement.HotTrack = True
        Me.tbcAccountStatement.Location = New System.Drawing.Point(12, 128)
        Me.tbcAccountStatement.Name = "tbcAccountStatement"
        Me.tbcAccountStatement.SelectedIndex = 0
        Me.tbcAccountStatement.Size = New System.Drawing.Size(840, 306)
        Me.tbcAccountStatement.TabIndex = 0
        '
        'tpgOPDItems
        '
        Me.tpgOPDItems.Controls.Add(Me.stbTotalOPDBillWords)
        Me.tpgOPDItems.Controls.Add(Me.Label4)
        Me.tpgOPDItems.Controls.Add(Me.stbTotalOPDBills)
        Me.tpgOPDItems.Controls.Add(Me.lblTotalOPDBills)
        Me.tpgOPDItems.Controls.Add(Me.dgvOPDBills)
        Me.tpgOPDItems.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDItems.Name = "tpgOPDItems"
        Me.tpgOPDItems.Size = New System.Drawing.Size(832, 280)
        Me.tpgOPDItems.TabIndex = 10
        Me.tpgOPDItems.Text = "OPD Bills"
        Me.tpgOPDItems.UseVisualStyleBackColor = True
        '
        'stbTotalOPDBillWords
        '
        Me.stbTotalOPDBillWords.AllowDrop = True
        Me.stbTotalOPDBillWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalOPDBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalOPDBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalOPDBillWords.CapitalizeFirstLetter = False
        Me.stbTotalOPDBillWords.EntryErrorMSG = ""
        Me.stbTotalOPDBillWords.Location = New System.Drawing.Point(483, 247)
        Me.stbTotalOPDBillWords.Multiline = True
        Me.stbTotalOPDBillWords.Name = "stbTotalOPDBillWords"
        Me.stbTotalOPDBillWords.ReadOnly = True
        Me.stbTotalOPDBillWords.RegularExpression = ""
        Me.stbTotalOPDBillWords.Size = New System.Drawing.Size(335, 30)
        Me.stbTotalOPDBillWords.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(336, 253)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 20)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Net Amount In Words"
        '
        'stbTotalOPDBills
        '
        Me.stbTotalOPDBills.AllowDrop = True
        Me.stbTotalOPDBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalOPDBills.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalOPDBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalOPDBills.CapitalizeFirstLetter = False
        Me.stbTotalOPDBills.EntryErrorMSG = ""
        Me.stbTotalOPDBills.Location = New System.Drawing.Point(155, 253)
        Me.stbTotalOPDBills.Name = "stbTotalOPDBills"
        Me.stbTotalOPDBills.ReadOnly = True
        Me.stbTotalOPDBills.RegularExpression = ""
        Me.stbTotalOPDBills.Size = New System.Drawing.Size(170, 20)
        Me.stbTotalOPDBills.TabIndex = 12
        '
        'lblTotalOPDBills
        '
        Me.lblTotalOPDBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalOPDBills.Location = New System.Drawing.Point(9, 252)
        Me.lblTotalOPDBills.Name = "lblTotalOPDBills"
        Me.lblTotalOPDBills.Size = New System.Drawing.Size(136, 20)
        Me.lblTotalOPDBills.TabIndex = 11
        Me.lblTotalOPDBills.Text = "Total Amount"
        '
        'dgvOPDBills
        '
        Me.dgvOPDBills.AllowUserToAddRows = False
        Me.dgvOPDBills.AllowUserToDeleteRows = False
        Me.dgvOPDBills.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOPDBills.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOPDBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOPDBills.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDBills.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDBills.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOPDBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDBills.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOPDBills.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOPDBillViistNo, Me.colOPDBillAmount, Me.colVisitDate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOPDBills.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOPDBills.EnableHeadersVisualStyles = False
        Me.dgvOPDBills.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDBills.Location = New System.Drawing.Point(0, 0)
        Me.dgvOPDBills.Name = "dgvOPDBills"
        Me.dgvOPDBills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDBills.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOPDBills.RowHeadersVisible = False
        Me.dgvOPDBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOPDBills.Size = New System.Drawing.Size(832, 236)
        Me.dgvOPDBills.TabIndex = 1
        Me.dgvOPDBills.Text = "DataGridView1"
        '
        'colOPDBillViistNo
        '
        Me.colOPDBillViistNo.DataPropertyName = "VisitNo"
        Me.colOPDBillViistNo.HeaderText = "Visit No"
        Me.colOPDBillViistNo.Name = "colOPDBillViistNo"
        '
        'colOPDBillAmount
        '
        Me.colOPDBillAmount.DataPropertyName = "Amount"
        Me.colOPDBillAmount.HeaderText = "Amount"
        Me.colOPDBillAmount.Name = "colOPDBillAmount"
        Me.colOPDBillAmount.Width = 80
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        '
        'tpgIPDItems
        '
        Me.tpgIPDItems.Controls.Add(Me.stbTotalIPDBillWords)
        Me.tpgIPDItems.Controls.Add(Me.Label3)
        Me.tpgIPDItems.Controls.Add(Me.stblTotalIPDBills)
        Me.tpgIPDItems.Controls.Add(Me.lblTotalIPDBills)
        Me.tpgIPDItems.Controls.Add(Me.dgvIPDBills)
        Me.tpgIPDItems.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDItems.Name = "tpgIPDItems"
        Me.tpgIPDItems.Size = New System.Drawing.Size(832, 280)
        Me.tpgIPDItems.TabIndex = 11
        Me.tpgIPDItems.Text = "IPD Items"
        Me.tpgIPDItems.UseVisualStyleBackColor = True
        '
        'stbTotalIPDBillWords
        '
        Me.stbTotalIPDBillWords.AllowDrop = True
        Me.stbTotalIPDBillWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalIPDBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalIPDBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalIPDBillWords.CapitalizeFirstLetter = False
        Me.stbTotalIPDBillWords.EntryErrorMSG = ""
        Me.stbTotalIPDBillWords.Location = New System.Drawing.Point(483, 244)
        Me.stbTotalIPDBillWords.Multiline = True
        Me.stbTotalIPDBillWords.Name = "stbTotalIPDBillWords"
        Me.stbTotalIPDBillWords.ReadOnly = True
        Me.stbTotalIPDBillWords.RegularExpression = ""
        Me.stbTotalIPDBillWords.Size = New System.Drawing.Size(335, 30)
        Me.stbTotalIPDBillWords.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(336, 250)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Net Amount In Words"
        '
        'stblTotalIPDBills
        '
        Me.stblTotalIPDBills.AllowDrop = True
        Me.stblTotalIPDBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stblTotalIPDBills.BackColor = System.Drawing.SystemColors.Info
        Me.stblTotalIPDBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stblTotalIPDBills.CapitalizeFirstLetter = False
        Me.stblTotalIPDBills.EntryErrorMSG = ""
        Me.stblTotalIPDBills.Location = New System.Drawing.Point(151, 251)
        Me.stblTotalIPDBills.Name = "stblTotalIPDBills"
        Me.stblTotalIPDBills.ReadOnly = True
        Me.stblTotalIPDBills.RegularExpression = ""
        Me.stblTotalIPDBills.Size = New System.Drawing.Size(174, 20)
        Me.stblTotalIPDBills.TabIndex = 14
        '
        'lblTotalIPDBills
        '
        Me.lblTotalIPDBills.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalIPDBills.Location = New System.Drawing.Point(5, 253)
        Me.lblTotalIPDBills.Name = "lblTotalIPDBills"
        Me.lblTotalIPDBills.Size = New System.Drawing.Size(143, 20)
        Me.lblTotalIPDBills.TabIndex = 13
        Me.lblTotalIPDBills.Text = "Total Amount"
        '
        'dgvIPDBills
        '
        Me.dgvIPDBills.AllowUserToAddRows = False
        Me.dgvIPDBills.AllowUserToDeleteRows = False
        Me.dgvIPDBills.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDBills.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIPDBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIPDBills.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDBills.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDBills.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDBills.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDBills.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIPDBills.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIPDBillExtraBillNo, Me.colIPDBillAmount, Me.colExtraBillDate})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDBills.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIPDBills.EnableHeadersVisualStyles = False
        Me.dgvIPDBills.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDBills.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDBills.Name = "dgvIPDBills"
        Me.dgvIPDBills.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDBills.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDBills.RowHeadersVisible = False
        Me.dgvIPDBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDBills.Size = New System.Drawing.Size(832, 237)
        Me.dgvIPDBills.TabIndex = 1
        Me.dgvIPDBills.Text = "DataGridView1"
        '
        'colIPDBillExtraBillNo
        '
        Me.colIPDBillExtraBillNo.DataPropertyName = "ExtraBillNo"
        Me.colIPDBillExtraBillNo.HeaderText = "Extra Bill No"
        Me.colIPDBillExtraBillNo.Name = "colIPDBillExtraBillNo"
        '
        'colIPDBillAmount
        '
        Me.colIPDBillAmount.DataPropertyName = "Amount"
        Me.colIPDBillAmount.HeaderText = "Amount"
        Me.colIPDBillAmount.Name = "colIPDBillAmount"
        Me.colIPDBillAmount.Width = 80
        '
        'colExtraBillDate
        '
        Me.colExtraBillDate.DataPropertyName = "ExtraBillDate"
        Me.colExtraBillDate.HeaderText = "Extra Bill Date"
        Me.colExtraBillDate.Name = "colExtraBillDate"
        Me.colExtraBillDate.ReadOnly = True
        '
        'tpgVisitPayment
        '
        Me.tpgVisitPayment.Controls.Add(Me.stbTotalPaymentWords)
        Me.tpgVisitPayment.Controls.Add(Me.Label2)
        Me.tpgVisitPayment.Controls.Add(Me.stbTotalPayments)
        Me.tpgVisitPayment.Controls.Add(Me.lblTotalPayments)
        Me.tpgVisitPayment.Controls.Add(Me.dgvCashReceipts)
        Me.tpgVisitPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgVisitPayment.Name = "tpgVisitPayment"
        Me.tpgVisitPayment.Size = New System.Drawing.Size(832, 280)
        Me.tpgVisitPayment.TabIndex = 8
        Me.tpgVisitPayment.Tag = "Visit Payment"
        Me.tpgVisitPayment.Text = "Visit Payment"
        Me.tpgVisitPayment.UseVisualStyleBackColor = True
        '
        'stbTotalPaymentWords
        '
        Me.stbTotalPaymentWords.AllowDrop = True
        Me.stbTotalPaymentWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalPaymentWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalPaymentWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalPaymentWords.CapitalizeFirstLetter = False
        Me.stbTotalPaymentWords.EntryErrorMSG = ""
        Me.stbTotalPaymentWords.Location = New System.Drawing.Point(483, 247)
        Me.stbTotalPaymentWords.Multiline = True
        Me.stbTotalPaymentWords.Name = "stbTotalPaymentWords"
        Me.stbTotalPaymentWords.ReadOnly = True
        Me.stbTotalPaymentWords.RegularExpression = ""
        Me.stbTotalPaymentWords.Size = New System.Drawing.Size(335, 30)
        Me.stbTotalPaymentWords.TabIndex = 33
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(336, 253)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 20)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Net Amount In Words"
        '
        'stbTotalPayments
        '
        Me.stbTotalPayments.AllowDrop = True
        Me.stbTotalPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalPayments.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalPayments.CapitalizeFirstLetter = False
        Me.stbTotalPayments.EntryErrorMSG = ""
        Me.stbTotalPayments.Location = New System.Drawing.Point(154, 254)
        Me.stbTotalPayments.Name = "stbTotalPayments"
        Me.stbTotalPayments.ReadOnly = True
        Me.stbTotalPayments.RegularExpression = ""
        Me.stbTotalPayments.Size = New System.Drawing.Size(171, 20)
        Me.stbTotalPayments.TabIndex = 16
        '
        'lblTotalPayments
        '
        Me.lblTotalPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalPayments.Location = New System.Drawing.Point(9, 255)
        Me.lblTotalPayments.Name = "lblTotalPayments"
        Me.lblTotalPayments.Size = New System.Drawing.Size(126, 20)
        Me.lblTotalPayments.TabIndex = 15
        Me.lblTotalPayments.Text = "Total Amount"
        '
        'dgvCashReceipts
        '
        Me.dgvCashReceipts.AllowUserToAddRows = False
        Me.dgvCashReceipts.AllowUserToDeleteRows = False
        Me.dgvCashReceipts.AllowUserToOrderColumns = True
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvCashReceipts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvCashReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCashReceipts.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvCashReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCashReceipts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCashReceipts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCashReceipts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvCashReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPayReceiptNo, Me.colPayNo, Me.colPayDate, Me.colPayAmount, Me.colPayNotes, Me.colPayRecordDate, Me.colPayRecordTime})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCashReceipts.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvCashReceipts.EnableHeadersVisualStyles = False
        Me.dgvCashReceipts.GridColor = System.Drawing.Color.Khaki
        Me.dgvCashReceipts.Location = New System.Drawing.Point(0, 0)
        Me.dgvCashReceipts.Name = "dgvCashReceipts"
        Me.dgvCashReceipts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCashReceipts.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvCashReceipts.RowHeadersVisible = False
        Me.dgvCashReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCashReceipts.Size = New System.Drawing.Size(832, 236)
        Me.dgvCashReceipts.TabIndex = 0
        Me.dgvCashReceipts.Text = "DataGridView1"
        '
        'colPayReceiptNo
        '
        Me.colPayReceiptNo.DataPropertyName = "ReceiptNo"
        Me.colPayReceiptNo.HeaderText = "Receipt No"
        Me.colPayReceiptNo.Name = "colPayReceiptNo"
        '
        'colPayNo
        '
        Me.colPayNo.DataPropertyName = "PayNo"
        Me.colPayNo.HeaderText = "Pay No"
        Me.colPayNo.Name = "colPayNo"
        Me.colPayNo.ReadOnly = True
        '
        'colPayDate
        '
        Me.colPayDate.DataPropertyName = "PayDate"
        Me.colPayDate.HeaderText = "Pay Date"
        Me.colPayDate.Name = "colPayDate"
        Me.colPayDate.Width = 120
        '
        'colPayAmount
        '
        Me.colPayAmount.DataPropertyName = "AmountPaid"
        Me.colPayAmount.HeaderText = "Amount"
        Me.colPayAmount.Name = "colPayAmount"
        Me.colPayAmount.Width = 80
        '
        'colPayNotes
        '
        Me.colPayNotes.DataPropertyName = "Notes"
        Me.colPayNotes.HeaderText = "Notes"
        Me.colPayNotes.Name = "colPayNotes"
        Me.colPayNotes.ReadOnly = True
        Me.colPayNotes.Width = 200
        '
        'colPayRecordDate
        '
        Me.colPayRecordDate.DataPropertyName = "RecordDate"
        Me.colPayRecordDate.HeaderText = "Record Date"
        Me.colPayRecordDate.Name = "colPayRecordDate"
        Me.colPayRecordDate.ReadOnly = True
        '
        'colPayRecordTime
        '
        Me.colPayRecordTime.DataPropertyName = "RecordTime"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colPayRecordTime.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPayRecordTime.HeaderText = "Record Time"
        Me.colPayRecordTime.Name = "colPayRecordTime"
        Me.colPayRecordTime.Width = 150
        '
        'tpgRefunds
        '
        Me.tpgRefunds.Controls.Add(Me.stbTotalRefundWords)
        Me.tpgRefunds.Controls.Add(Me.Label1)
        Me.tpgRefunds.Controls.Add(Me.stbTotalRefunds)
        Me.tpgRefunds.Controls.Add(Me.lblTotalRefunds)
        Me.tpgRefunds.Controls.Add(Me.dgvRefunds)
        Me.tpgRefunds.Location = New System.Drawing.Point(4, 22)
        Me.tpgRefunds.Name = "tpgRefunds"
        Me.tpgRefunds.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgRefunds.Size = New System.Drawing.Size(832, 280)
        Me.tpgRefunds.TabIndex = 9
        Me.tpgRefunds.Text = "Refunds"
        Me.tpgRefunds.UseVisualStyleBackColor = True
        '
        'stbTotalRefundWords
        '
        Me.stbTotalRefundWords.AllowDrop = True
        Me.stbTotalRefundWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalRefundWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalRefundWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalRefundWords.CapitalizeFirstLetter = False
        Me.stbTotalRefundWords.EntryErrorMSG = ""
        Me.stbTotalRefundWords.Location = New System.Drawing.Point(483, 246)
        Me.stbTotalRefundWords.Multiline = True
        Me.stbTotalRefundWords.Name = "stbTotalRefundWords"
        Me.stbTotalRefundWords.ReadOnly = True
        Me.stbTotalRefundWords.RegularExpression = ""
        Me.stbTotalRefundWords.Size = New System.Drawing.Size(343, 30)
        Me.stbTotalRefundWords.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(344, 252)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 20)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Net Amount In Words"
        '
        'stbTotalRefunds
        '
        Me.stbTotalRefunds.AllowDrop = True
        Me.stbTotalRefunds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalRefunds.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalRefunds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalRefunds.CapitalizeFirstLetter = False
        Me.stbTotalRefunds.EntryErrorMSG = ""
        Me.stbTotalRefunds.Location = New System.Drawing.Point(151, 253)
        Me.stbTotalRefunds.Name = "stbTotalRefunds"
        Me.stbTotalRefunds.ReadOnly = True
        Me.stbTotalRefunds.RegularExpression = ""
        Me.stbTotalRefunds.Size = New System.Drawing.Size(174, 20)
        Me.stbTotalRefunds.TabIndex = 18
        '
        'lblTotalRefunds
        '
        Me.lblTotalRefunds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalRefunds.Location = New System.Drawing.Point(5, 255)
        Me.lblTotalRefunds.Name = "lblTotalRefunds"
        Me.lblTotalRefunds.Size = New System.Drawing.Size(127, 20)
        Me.lblTotalRefunds.TabIndex = 17
        Me.lblTotalRefunds.Text = "Total Amount"
        '
        'dgvRefunds
        '
        Me.dgvRefunds.AllowUserToAddRows = False
        Me.dgvRefunds.AllowUserToDeleteRows = False
        Me.dgvRefunds.AllowUserToOrderColumns = True
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvRefunds.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvRefunds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRefunds.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvRefunds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRefunds.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvRefunds.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRefunds.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRefTransactionNo, Me.colRefundDate, Me.colRefAmount, Me.colRefNotes, Me.colRefundRecordDate, Me.colRefTime})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRefunds.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvRefunds.EnableHeadersVisualStyles = False
        Me.dgvRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvRefunds.Location = New System.Drawing.Point(3, 3)
        Me.dgvRefunds.Name = "dgvRefunds"
        Me.dgvRefunds.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvRefunds.RowHeadersVisible = False
        Me.dgvRefunds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvRefunds.Size = New System.Drawing.Size(826, 239)
        Me.dgvRefunds.TabIndex = 15
        Me.dgvRefunds.Text = "DataGridView1"
        '
        'colRefTransactionNo
        '
        Me.colRefTransactionNo.DataPropertyName = "RefundNo"
        Me.colRefTransactionNo.HeaderText = "Transaction No"
        Me.colRefTransactionNo.Name = "colRefTransactionNo"
        '
        'colRefundDate
        '
        Me.colRefundDate.DataPropertyName = "RefundDate"
        Me.colRefundDate.HeaderText = "Refund Date"
        Me.colRefundDate.Name = "colRefundDate"
        Me.colRefundDate.ReadOnly = True
        '
        'colRefAmount
        '
        Me.colRefAmount.DataPropertyName = "Amount"
        Me.colRefAmount.HeaderText = "Amount"
        Me.colRefAmount.Name = "colRefAmount"
        Me.colRefAmount.ReadOnly = True
        '
        'colRefNotes
        '
        Me.colRefNotes.DataPropertyName = "Notes"
        Me.colRefNotes.HeaderText = "Notes"
        Me.colRefNotes.Name = "colRefNotes"
        Me.colRefNotes.Width = 200
        '
        'colRefundRecordDate
        '
        Me.colRefundRecordDate.DataPropertyName = "RecordDate"
        Me.colRefundRecordDate.HeaderText = "Record Date"
        Me.colRefundRecordDate.Name = "colRefundRecordDate"
        Me.colRefundRecordDate.ReadOnly = True
        '
        'colRefTime
        '
        Me.colRefTime.DataPropertyName = "RecordTime"
        Me.colRefTime.HeaderText = "Record Time"
        Me.colRefTime.Name = "colRefTime"
        '
        'tpgAccountTransactions
        '
        Me.tpgAccountTransactions.Controls.Add(Me.stbNetAmountWords)
        Me.tpgAccountTransactions.Controls.Add(Me.lblNetAmountWords)
        Me.tpgAccountTransactions.Controls.Add(Me.stbNetAmount)
        Me.tpgAccountTransactions.Controls.Add(Me.lblNetAmount)
        Me.tpgAccountTransactions.Controls.Add(Me.stbTotalCredit)
        Me.tpgAccountTransactions.Controls.Add(Me.lblTotalCredit)
        Me.tpgAccountTransactions.Controls.Add(Me.stbTotalDebit)
        Me.tpgAccountTransactions.Controls.Add(Me.lblTotalDebit)
        Me.tpgAccountTransactions.Controls.Add(Me.stbPatientChequePaymentsWords)
        Me.tpgAccountTransactions.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgAccountTransactions.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgAccountTransactions.Controls.Add(Me.stbPatientChequePayments)
        Me.tpgAccountTransactions.Controls.Add(Me.dgvAccountTrasaction)
        Me.tpgAccountTransactions.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccountTransactions.Name = "tpgAccountTransactions"
        Me.tpgAccountTransactions.Size = New System.Drawing.Size(832, 280)
        Me.tpgAccountTransactions.TabIndex = 7
        Me.tpgAccountTransactions.Tag = "Account TransactionsDeposits"
        Me.tpgAccountTransactions.Text = "Account Transactions"
        Me.tpgAccountTransactions.UseVisualStyleBackColor = True
        '
        'stbNetAmountWords
        '
        Me.stbNetAmountWords.AllowDrop = True
        Me.stbNetAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbNetAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbNetAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNetAmountWords.CapitalizeFirstLetter = False
        Me.stbNetAmountWords.EntryErrorMSG = ""
        Me.stbNetAmountWords.Location = New System.Drawing.Point(483, 244)
        Me.stbNetAmountWords.Multiline = True
        Me.stbNetAmountWords.Name = "stbNetAmountWords"
        Me.stbNetAmountWords.ReadOnly = True
        Me.stbNetAmountWords.RegularExpression = ""
        Me.stbNetAmountWords.Size = New System.Drawing.Size(335, 30)
        Me.stbNetAmountWords.TabIndex = 29
        '
        'lblNetAmountWords
        '
        Me.lblNetAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNetAmountWords.Location = New System.Drawing.Point(336, 250)
        Me.lblNetAmountWords.Name = "lblNetAmountWords"
        Me.lblNetAmountWords.Size = New System.Drawing.Size(131, 20)
        Me.lblNetAmountWords.TabIndex = 28
        Me.lblNetAmountWords.Text = "Net Amount In Words"
        '
        'stbNetAmount
        '
        Me.stbNetAmount.AllowDrop = True
        Me.stbNetAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbNetAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNetAmount.CapitalizeFirstLetter = False
        Me.stbNetAmount.EntryErrorMSG = ""
        Me.stbNetAmount.Location = New System.Drawing.Point(152, 252)
        Me.stbNetAmount.Name = "stbNetAmount"
        Me.stbNetAmount.ReadOnly = True
        Me.stbNetAmount.RegularExpression = ""
        Me.stbNetAmount.Size = New System.Drawing.Size(173, 20)
        Me.stbNetAmount.TabIndex = 27
        '
        'lblNetAmount
        '
        Me.lblNetAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNetAmount.Location = New System.Drawing.Point(3, 254)
        Me.lblNetAmount.Name = "lblNetAmount"
        Me.lblNetAmount.Size = New System.Drawing.Size(111, 20)
        Me.lblNetAmount.TabIndex = 26
        Me.lblNetAmount.Text = "Net Amount"
        '
        'stbTotalCredit
        '
        Me.stbTotalCredit.AllowDrop = True
        Me.stbTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalCredit.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalCredit.CapitalizeFirstLetter = False
        Me.stbTotalCredit.EntryErrorMSG = ""
        Me.stbTotalCredit.Location = New System.Drawing.Point(152, 204)
        Me.stbTotalCredit.Name = "stbTotalCredit"
        Me.stbTotalCredit.ReadOnly = True
        Me.stbTotalCredit.RegularExpression = ""
        Me.stbTotalCredit.Size = New System.Drawing.Size(173, 20)
        Me.stbTotalCredit.TabIndex = 25
        '
        'lblTotalCredit
        '
        Me.lblTotalCredit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCredit.Location = New System.Drawing.Point(5, 204)
        Me.lblTotalCredit.Name = "lblTotalCredit"
        Me.lblTotalCredit.Size = New System.Drawing.Size(109, 20)
        Me.lblTotalCredit.TabIndex = 24
        Me.lblTotalCredit.Text = "Credit"
        '
        'stbTotalDebit
        '
        Me.stbTotalDebit.AllowDrop = True
        Me.stbTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalDebit.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalDebit.CapitalizeFirstLetter = False
        Me.stbTotalDebit.EntryErrorMSG = ""
        Me.stbTotalDebit.Location = New System.Drawing.Point(152, 227)
        Me.stbTotalDebit.Name = "stbTotalDebit"
        Me.stbTotalDebit.ReadOnly = True
        Me.stbTotalDebit.RegularExpression = ""
        Me.stbTotalDebit.Size = New System.Drawing.Size(173, 20)
        Me.stbTotalDebit.TabIndex = 23
        '
        'lblTotalDebit
        '
        Me.lblTotalDebit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDebit.Location = New System.Drawing.Point(5, 229)
        Me.lblTotalDebit.Name = "lblTotalDebit"
        Me.lblTotalDebit.Size = New System.Drawing.Size(109, 20)
        Me.lblTotalDebit.TabIndex = 22
        Me.lblTotalDebit.Text = "Debit"
        '
        'stbPatientChequePaymentsWords
        '
        Me.stbPatientChequePaymentsWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePaymentsWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePaymentsWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePaymentsWords.CapitalizeFirstLetter = False
        Me.stbPatientChequePaymentsWords.EntryErrorMSG = ""
        Me.stbPatientChequePaymentsWords.Location = New System.Drawing.Point(419, 338)
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
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(7, 351)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 9
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(287, 351)
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
        Me.stbPatientChequePayments.Location = New System.Drawing.Point(97, 349)
        Me.stbPatientChequePayments.MaxLength = 20
        Me.stbPatientChequePayments.Name = "stbPatientChequePayments"
        Me.stbPatientChequePayments.RegularExpression = ""
        Me.stbPatientChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbPatientChequePayments.TabIndex = 10
        Me.stbPatientChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvAccountTrasaction
        '
        Me.dgvAccountTrasaction.AllowUserToAddRows = False
        Me.dgvAccountTrasaction.AllowUserToDeleteRows = False
        Me.dgvAccountTrasaction.AllowUserToOrderColumns = True
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAccountTrasaction.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvAccountTrasaction.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccountTrasaction.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAccountTrasaction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAccountTrasaction.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAccountTrasaction.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountTrasaction.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvAccountTrasaction.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTranNo, Me.colTranDate, Me.collAccAmount, Me.colCredit, Me.colDebit, Me.colBalance, Me.colAccNotes, Me.colAccDate, Me.colAccTime})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccountTrasaction.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvAccountTrasaction.EnableHeadersVisualStyles = False
        Me.dgvAccountTrasaction.GridColor = System.Drawing.Color.Khaki
        Me.dgvAccountTrasaction.Location = New System.Drawing.Point(0, 0)
        Me.dgvAccountTrasaction.Name = "dgvAccountTrasaction"
        Me.dgvAccountTrasaction.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountTrasaction.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvAccountTrasaction.RowHeadersVisible = False
        Me.dgvAccountTrasaction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAccountTrasaction.Size = New System.Drawing.Size(832, 201)
        Me.dgvAccountTrasaction.TabIndex = 2
        Me.dgvAccountTrasaction.Text = "DataGridView1"
        '
        'cboBillMode
        '
        Me.cboBillMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillMode.DropDownWidth = 300
        Me.cboBillMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillMode.FormattingEnabled = True
        Me.cboBillMode.Location = New System.Drawing.Point(212, 10)
        Me.cboBillMode.MaxLength = 20
        Me.cboBillMode.Name = "cboBillMode"
        Me.cboBillMode.Size = New System.Drawing.Size(200, 21)
        Me.cboBillMode.TabIndex = 2
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(563, 100)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 18
        Me.fbnRefresh.Text = "&Refresh"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(483, 100)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 17
        Me.fbnLoad.Text = "&Load"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(110, 468)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 2
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(14, 468)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(16, 77)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(180, 20)
        Me.lblEndDateTime.TabIndex = 7
        Me.lblEndDateTime.Text = "End Date"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(15, 52)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(181, 20)
        Me.lblStartDateTime.TabIndex = 5
        Me.lblStartDateTime.Text = "Start Date"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.cboAccountNo.Location = New System.Drawing.Point(212, 34)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(152, 21)
        Me.cboAccountNo.TabIndex = 21
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(15, 34)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(181, 18)
        Me.lblAccountNo.TabIndex = 20
        Me.lblAccountNo.Text = "Account No"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(366, 34)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 22
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.Visible = False
        '
        'chkIncludeProcessing
        '
        Me.chkIncludeProcessing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeProcessing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludeProcessing.Location = New System.Drawing.Point(12, 102)
        Me.chkIncludeProcessing.Name = "chkIncludeProcessing"
        Me.chkIncludeProcessing.Size = New System.Drawing.Size(194, 20)
        Me.chkIncludeProcessing.TabIndex = 23
        Me.chkIncludeProcessing.Text = "Include Processing"
        '
        'stbBalance
        '
        Me.stbBalance.AllowDrop = True
        Me.stbBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbBalance.BackColor = System.Drawing.SystemColors.Info
        Me.stbBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBalance.CapitalizeFirstLetter = False
        Me.stbBalance.EntryErrorMSG = ""
        Me.stbBalance.Location = New System.Drawing.Point(167, 437)
        Me.stbBalance.Name = "stbBalance"
        Me.stbBalance.ReadOnly = True
        Me.stbBalance.RegularExpression = ""
        Me.stbBalance.Size = New System.Drawing.Size(174, 20)
        Me.stbBalance.TabIndex = 25
        '
        'lblBalance
        '
        Me.lblBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBalance.Location = New System.Drawing.Point(21, 440)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(130, 20)
        Me.lblBalance.TabIndex = 24
        Me.lblBalance.Text = "Balance"
        '
        'stbBalanceWords
        '
        Me.stbBalanceWords.AllowDrop = True
        Me.stbBalanceWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbBalanceWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBalanceWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBalanceWords.CapitalizeFirstLetter = False
        Me.stbBalanceWords.EntryErrorMSG = ""
        Me.stbBalanceWords.Location = New System.Drawing.Point(499, 434)
        Me.stbBalanceWords.Multiline = True
        Me.stbBalanceWords.Name = "stbBalanceWords"
        Me.stbBalanceWords.ReadOnly = True
        Me.stbBalanceWords.RegularExpression = ""
        Me.stbBalanceWords.Size = New System.Drawing.Size(335, 30)
        Me.stbBalanceWords.TabIndex = 33
        '
        'lblBalanceWords
        '
        Me.lblBalanceWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBalanceWords.Location = New System.Drawing.Point(352, 437)
        Me.lblBalanceWords.Name = "lblBalanceWords"
        Me.lblBalanceWords.Size = New System.Drawing.Size(131, 20)
        Me.lblBalanceWords.TabIndex = 32
        Me.lblBalanceWords.Text = "Grand Total Amount"
        '
        'chkIncludePending
        '
        Me.chkIncludePending.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludePending.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludePending.Location = New System.Drawing.Point(212, 103)
        Me.chkIncludePending.Name = "chkIncludePending"
        Me.chkIncludePending.Size = New System.Drawing.Size(184, 20)
        Me.chkIncludePending.TabIndex = 34
        Me.chkIncludePending.Text = "Include Pending"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(212, 61)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 35
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(212, 80)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 36
        '
        'colTranNo
        '
        Me.colTranNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTranNo.DataPropertyName = "TranNo"
        Me.colTranNo.HeaderText = "Tran No"
        Me.colTranNo.Name = "colTranNo"
        '
        'colTranDate
        '
        Me.colTranDate.DataPropertyName = "TranDate"
        Me.colTranDate.HeaderText = "Tran Date"
        Me.colTranDate.Name = "colTranDate"
        Me.colTranDate.ReadOnly = True
        '
        'collAccAmount
        '
        Me.collAccAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.collAccAmount.DataPropertyName = "Amount"
        Me.collAccAmount.HeaderText = "Amount"
        Me.collAccAmount.Name = "collAccAmount"
        Me.collAccAmount.ReadOnly = True
        '
        'colCredit
        '
        Me.colCredit.DataPropertyName = "Credit"
        Me.colCredit.HeaderText = "Credit"
        Me.colCredit.Name = "colCredit"
        Me.colCredit.ReadOnly = True
        '
        'colDebit
        '
        Me.colDebit.DataPropertyName = "Debit"
        Me.colDebit.HeaderText = "Debit"
        Me.colDebit.Name = "colDebit"
        Me.colDebit.ReadOnly = True
        '
        'colBalance
        '
        Me.colBalance.DataPropertyName = "Balance"
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        '
        'colAccNotes
        '
        Me.colAccNotes.DataPropertyName = "Notes"
        Me.colAccNotes.HeaderText = "Notes"
        Me.colAccNotes.Name = "colAccNotes"
        Me.colAccNotes.ReadOnly = True
        Me.colAccNotes.Width = 150
        '
        'colAccDate
        '
        Me.colAccDate.DataPropertyName = "RecordDate"
        Me.colAccDate.HeaderText = "Record Date"
        Me.colAccDate.Name = "colAccDate"
        Me.colAccDate.Width = 80
        '
        'colAccTime
        '
        Me.colAccTime.DataPropertyName = "RecordTime"
        Me.colAccTime.HeaderText = "Time"
        Me.colAccTime.Name = "colAccTime"
        Me.colAccTime.ReadOnly = True
        Me.colAccTime.Width = 80
        '
        'frmAccountStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(864, 504)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.chkIncludePending)
        Me.Controls.Add(Me.stbBalanceWords)
        Me.Controls.Add(Me.lblBalanceWords)
        Me.Controls.Add(Me.stbBalance)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.chkIncludeProcessing)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.lblEndDateTime)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblStartDateTime)
        Me.Controls.Add(Me.fbnRefresh)
        Me.Controls.Add(Me.fbnLoad)
        Me.Controls.Add(Me.cboBillMode)
        Me.Controls.Add(Me.tbcAccountStatement)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.nbxOutstandingBill)
        Me.Controls.Add(Me.lblOutstandingBill)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmAccountStatement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Statement"
        Me.tbcAccountStatement.ResumeLayout(false)
        Me.tpgOPDItems.ResumeLayout(false)
        Me.tpgOPDItems.PerformLayout
        CType(Me.dgvOPDBills,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgIPDItems.ResumeLayout(false)
        Me.tpgIPDItems.PerformLayout
        CType(Me.dgvIPDBills,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgVisitPayment.ResumeLayout(false)
        Me.tpgVisitPayment.PerformLayout
        CType(Me.dgvCashReceipts,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgRefunds.ResumeLayout(false)
        Me.tpgRefunds.PerformLayout
        CType(Me.dgvRefunds,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgAccountTransactions.ResumeLayout(false)
        Me.tpgAccountTransactions.PerformLayout
        CType(Me.dgvAccountTrasaction,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBill As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBill As System.Windows.Forms.Label
    Friend WithEvents tbcAccountStatement As TabControl
    Friend WithEvents tpgVisitPayment As TabPage
    Friend WithEvents dgvCashReceipts As DataGridView
    Friend WithEvents tpgAccountTransactions As TabPage
    Friend WithEvents stbPatientChequePaymentsWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As Label
    Friend WithEvents lblExpenditureAmountWords As Label
    Friend WithEvents stbPatientChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvAccountTrasaction As DataGridView
    Friend WithEvents tpgRefunds As TabPage
    Friend WithEvents dgvRefunds As DataGridView
    Friend WithEvents cboBillMode As ComboBox
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblEndDateTime As Label
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents cboAccountNo As ComboBox
    Friend WithEvents lblAccountNo As Label
    Friend WithEvents btnLoad As Button
    Friend WithEvents tpgOPDItems As System.Windows.Forms.TabPage
    Friend WithEvents dgvOPDBills As System.Windows.Forms.DataGridView
    Friend WithEvents tpgIPDItems As System.Windows.Forms.TabPage
    Friend WithEvents dgvIPDBills As System.Windows.Forms.DataGridView
    Friend WithEvents chkIncludeProcessing As System.Windows.Forms.CheckBox
    Friend WithEvents stbTotalOPDBills As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalOPDBills As System.Windows.Forms.Label
    Friend WithEvents stblTotalIPDBills As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalIPDBills As System.Windows.Forms.Label
    Friend WithEvents stbTotalPayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalPayments As System.Windows.Forms.Label
    Friend WithEvents stbTotalRefunds As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalRefunds As System.Windows.Forms.Label
    Friend WithEvents stbNetAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNetAmount As System.Windows.Forms.Label
    Friend WithEvents stbTotalCredit As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalCredit As System.Windows.Forms.Label
    Friend WithEvents stbTotalDebit As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalDebit As System.Windows.Forms.Label
    Friend WithEvents stbBalance As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents stbNetAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNetAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbTotalOPDBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents stbTotalIPDBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stbTotalPaymentWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stbTotalRefundWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbBalanceWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBalanceWords As System.Windows.Forms.Label
    Friend WithEvents chkIncludePending As System.Windows.Forms.CheckBox
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents colIPDBillExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDBillAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraBillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefTransactionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDBillViistNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOPDBillAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTranNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTranDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents collAccAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class