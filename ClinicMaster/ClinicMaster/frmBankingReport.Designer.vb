
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankingReport : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankingReport))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.cboBankNamesID = New System.Windows.Forms.ComboBox()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblBankID = New System.Windows.Forms.Label()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvBankingRegister = New System.Windows.Forms.DataGridView()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.colExpenditureNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colColectionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCollectionEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBankingDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBankName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountCollected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmoutBanked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBankedInShillings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountInWords = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExchangeRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpenditureLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpenditureRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBankedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvBankingRegister, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(973, 444)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.stbAccountNo)
        Me.grpSetParameters.Controls.Add(Me.Label1)
        Me.grpSetParameters.Controls.Add(Me.cboAccountNo)
        Me.grpSetParameters.Controls.Add(Me.lblAccountNo)
        Me.grpSetParameters.Controls.Add(Me.cboBankNamesID)
        Me.grpSetParameters.Controls.Add(Me.cboLoginID)
        Me.grpSetParameters.Controls.Add(Me.lblBankID)
        Me.grpSetParameters.Controls.Add(Me.fbnRefresh)
        Me.grpSetParameters.Controls.Add(Me.fbnExport)
        Me.grpSetParameters.Controls.Add(Me.lblLoginID)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(13, 8)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1032, 103)
        Me.grpSetParameters.TabIndex = 10
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Banking Period"
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.CapitalizeFirstLetter = False
        Me.stbAccountNo.EntryErrorMSG = ""
        Me.stbAccountNo.Location = New System.Drawing.Point(580, 76)
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.ReadOnly = True
        Me.stbAccountNo.RegularExpression = ""
        Me.stbAccountNo.Size = New System.Drawing.Size(182, 20)
        Me.stbAccountNo.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(393, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 20)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Account No"
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccountNo.DropDownWidth = 203
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.ItemHeight = 13
        Me.cboAccountNo.Location = New System.Drawing.Point(580, 52)
        Me.cboAccountNo.MaxLength = 20
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(182, 21)
        Me.cboAccountNo.TabIndex = 19
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(393, 53)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(181, 20)
        Me.lblAccountNo.TabIndex = 18
        Me.lblAccountNo.Text = "Account Name (Leave blank for all)"
        '
        'cboBankNamesID
        '
        Me.cboBankNamesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankNamesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankNamesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBankNamesID.FormattingEnabled = True
        Me.cboBankNamesID.Location = New System.Drawing.Point(205, 75)
        Me.cboBankNamesID.Name = "cboBankNamesID"
        Me.cboBankNamesID.Size = New System.Drawing.Size(182, 21)
        Me.cboBankNamesID.TabIndex = 17
        '
        'cboLoginID
        '
        Me.cboLoginID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoginID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoginID.BackColor = System.Drawing.SystemColors.Window
        Me.cboLoginID.DropDownWidth = 203
        Me.cboLoginID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLoginID.FormattingEnabled = True
        Me.cboLoginID.ItemHeight = 13
        Me.cboLoginID.Location = New System.Drawing.Point(205, 52)
        Me.cboLoginID.MaxLength = 20
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(182, 21)
        Me.cboLoginID.TabIndex = 3
        '
        'lblBankID
        '
        Me.lblBankID.Location = New System.Drawing.Point(2, 75)
        Me.lblBankID.Name = "lblBankID"
        Me.lblBankID.Size = New System.Drawing.Size(218, 20)
        Me.lblBankID.TabIndex = 16
        Me.lblBankID.Text = " Bank Name (Leave blank  for all)"
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(866, 70)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 5
        Me.fbnRefresh.Text = "&Refresh"
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(946, 71)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(6, 51)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(214, 20)
        Me.lblLoginID.TabIndex = 2
        Me.lblLoginID.Text = "Login ID (Leave blank for all)"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDateTime)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 15)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(700, 31)
        Me.pnlPeriod.TabIndex = 0
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(502, 5)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(137, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Bank Record "
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(153, 5)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(198, 20)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(357, 5)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(139, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Bank Date "
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(715, 20)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(266, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(790, 70)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "&Load"
        '
        'dgvBankingRegister
        '
        Me.dgvBankingRegister.AllowUserToAddRows = False
        Me.dgvBankingRegister.AllowUserToDeleteRows = False
        Me.dgvBankingRegister.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvBankingRegister.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBankingRegister.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBankingRegister.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvBankingRegister.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBankingRegister.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBankingRegister.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBankingRegister.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBankingRegister.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExpenditureNo, Me.colColectionDate, Me.colCollectionEndDate, Me.colBankingDate, Me.colAccountName, Me.colBankName, Me.colAccountNo, Me.colAmountCollected, Me.colAmoutBanked, Me.colBankedInShillings, Me.colAmountInWords, Me.colCurrency, Me.colExchangeRate, Me.colAccountCurrency, Me.colExpenditureLoginID, Me.colExpenditureRecordDate, Me.colBankedBy})
        Me.dgvBankingRegister.EnableHeadersVisualStyles = False
        Me.dgvBankingRegister.GridColor = System.Drawing.Color.Khaki
        Me.dgvBankingRegister.Location = New System.Drawing.Point(13, 123)
        Me.dgvBankingRegister.Name = "dgvBankingRegister"
        Me.dgvBankingRegister.ReadOnly = True
        Me.dgvBankingRegister.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBankingRegister.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBankingRegister.RowHeadersVisible = False
        Me.dgvBankingRegister.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBankingRegister.Size = New System.Drawing.Size(1032, 303)
        Me.dgvBankingRegister.TabIndex = 11
        Me.dgvBankingRegister.Text = "DataGridView1"
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.Location = New System.Drawing.Point(226, 444)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblTotalAmount.TabIndex = 12
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmountWords.Location = New System.Drawing.Point(526, 444)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(110, 21)
        Me.lblAmountWords.TabIndex = 14
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(337, 442)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(167, 20)
        Me.stbTotalAmount.TabIndex = 13
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbAmountWords
        '
        Me.stbAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(642, 429)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(325, 39)
        Me.stbAmountWords.TabIndex = 15
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(111, 444)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 83
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 444)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 82
        Me.btnPrint.Text = "&Print"
        '
        'colExpenditureNo
        '
        Me.colExpenditureNo.DataPropertyName = "RegisterNo"
        Me.colExpenditureNo.HeaderText = "Register No"
        Me.colExpenditureNo.Name = "colExpenditureNo"
        Me.colExpenditureNo.ReadOnly = True
        '
        'colColectionDate
        '
        Me.colColectionDate.DataPropertyName = "CollectionStartDate"
        Me.colColectionDate.HeaderText = "Collection Start Date"
        Me.colColectionDate.Name = "colColectionDate"
        Me.colColectionDate.ReadOnly = True
        Me.colColectionDate.Width = 150
        '
        'colCollectionEndDate
        '
        Me.colCollectionEndDate.DataPropertyName = "CollectionEndDate"
        Me.colCollectionEndDate.HeaderText = "Collection End Date"
        Me.colCollectionEndDate.Name = "colCollectionEndDate"
        Me.colCollectionEndDate.ReadOnly = True
        Me.colCollectionEndDate.Width = 150
        '
        'colBankingDate
        '
        Me.colBankingDate.DataPropertyName = "BankingDate"
        Me.colBankingDate.HeaderText = "Banking Date"
        Me.colBankingDate.Name = "colBankingDate"
        Me.colBankingDate.ReadOnly = True
        Me.colBankingDate.Width = 120
        '
        'colAccountName
        '
        Me.colAccountName.DataPropertyName = "AccountName"
        Me.colAccountName.HeaderText = "Account Name"
        Me.colAccountName.Name = "colAccountName"
        Me.colAccountName.ReadOnly = True
        '
        'colBankName
        '
        Me.colBankName.DataPropertyName = "BankName"
        Me.colBankName.HeaderText = "Bank Name"
        Me.colBankName.Name = "colBankName"
        Me.colBankName.ReadOnly = True
        '
        'colAccountNo
        '
        Me.colAccountNo.DataPropertyName = "AccountNo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAccountNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.ReadOnly = True
        Me.colAccountNo.Width = 80
        '
        'colAmountCollected
        '
        Me.colAmountCollected.DataPropertyName = "AmountCollected"
        Me.colAmountCollected.HeaderText = "Net Cash Collected"
        Me.colAmountCollected.Name = "colAmountCollected"
        Me.colAmountCollected.ReadOnly = True
        Me.colAmountCollected.Width = 150
        '
        'colAmoutBanked
        '
        Me.colAmoutBanked.DataPropertyName = "AmountBanked"
        Me.colAmoutBanked.HeaderText = "AmoutBanked"
        Me.colAmoutBanked.Name = "colAmoutBanked"
        Me.colAmoutBanked.ReadOnly = True
        '
        'colBankedInShillings
        '
        Me.colBankedInShillings.DataPropertyName = "BankedInShillings"
        Me.colBankedInShillings.HeaderText = "Banked In Shillings"
        Me.colBankedInShillings.Name = "colBankedInShillings"
        Me.colBankedInShillings.ReadOnly = True
        Me.colBankedInShillings.Width = 200
        '
        'colAmountInWords
        '
        Me.colAmountInWords.DataPropertyName = "AmountInWords"
        Me.colAmountInWords.HeaderText = "Amount In Words"
        Me.colAmountInWords.Name = "colAmountInWords"
        Me.colAmountInWords.ReadOnly = True
        Me.colAmountInWords.Width = 250
        '
        'colCurrency
        '
        Me.colCurrency.DataPropertyName = "Currency"
        Me.colCurrency.HeaderText = "Currency"
        Me.colCurrency.Name = "colCurrency"
        Me.colCurrency.ReadOnly = True
        '
        'colExchangeRate
        '
        Me.colExchangeRate.DataPropertyName = "ExchangeRate"
        Me.colExchangeRate.HeaderText = "Exchange Rate"
        Me.colExchangeRate.Name = "colExchangeRate"
        Me.colExchangeRate.ReadOnly = True
        '
        'colAccountCurrency
        '
        Me.colAccountCurrency.DataPropertyName = "AccountCurrency"
        Me.colAccountCurrency.HeaderText = "Account Currency"
        Me.colAccountCurrency.Name = "colAccountCurrency"
        Me.colAccountCurrency.ReadOnly = True
        '
        'colExpenditureLoginID
        '
        Me.colExpenditureLoginID.DataPropertyName = "LoginID"
        Me.colExpenditureLoginID.HeaderText = "Login ID"
        Me.colExpenditureLoginID.Name = "colExpenditureLoginID"
        Me.colExpenditureLoginID.ReadOnly = True
        Me.colExpenditureLoginID.Width = 60
        '
        'colExpenditureRecordDate
        '
        Me.colExpenditureRecordDate.DataPropertyName = "RecordDateTime"
        Me.colExpenditureRecordDate.HeaderText = "Record Date"
        Me.colExpenditureRecordDate.Name = "colExpenditureRecordDate"
        Me.colExpenditureRecordDate.ReadOnly = True
        Me.colExpenditureRecordDate.Width = 80
        '
        'colBankedBy
        '
        Me.colBankedBy.DataPropertyName = "BankedBy"
        Me.colBankedBy.HeaderText = "Banked By"
        Me.colBankedBy.Name = "colBankedBy"
        Me.colBankedBy.ReadOnly = True
        '
        'frmBankingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1057, 480)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.stbTotalAmount)
        Me.Controls.Add(Me.dgvBankingRegister)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBankingReport"
        Me.Text = "Banking Report"
        Me.grpSetParameters.ResumeLayout(False)
        Me.grpSetParameters.PerformLayout()
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvBankingRegister, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpSetParameters As GroupBox
    Friend WithEvents cboBankNamesID As ComboBox
    Friend WithEvents cboLoginID As ComboBox
    Friend WithEvents lblBankID As Label
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblLoginID As Label
    Friend WithEvents pnlPeriod As Panel
    Friend WithEvents dtpEndDateTime As DateTimePicker
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents dtpStartDateTime As DateTimePicker
    Friend WithEvents lblEndDateTime As Label
    Friend WithEvents lblRecordsNo As Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvBankingRegister As DataGridView
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblAmountWords As Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents cboAccountNo As ComboBox
    Friend WithEvents lblAccountNo As Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents colExpenditureNo As DataGridViewTextBoxColumn
    Friend WithEvents colColectionDate As DataGridViewTextBoxColumn
    Friend WithEvents colCollectionEndDate As DataGridViewTextBoxColumn
    Friend WithEvents colBankingDate As DataGridViewTextBoxColumn
    Friend WithEvents colAccountName As DataGridViewTextBoxColumn
    Friend WithEvents colBankName As DataGridViewTextBoxColumn
    Friend WithEvents colAccountNo As DataGridViewTextBoxColumn
    Friend WithEvents colAmountCollected As DataGridViewTextBoxColumn
    Friend WithEvents colAmoutBanked As DataGridViewTextBoxColumn
    Friend WithEvents colBankedInShillings As DataGridViewTextBoxColumn
    Friend WithEvents colAmountInWords As DataGridViewTextBoxColumn
    Friend WithEvents colCurrency As DataGridViewTextBoxColumn
    Friend WithEvents colExchangeRate As DataGridViewTextBoxColumn
    Friend WithEvents colAccountCurrency As DataGridViewTextBoxColumn
    Friend WithEvents colExpenditureLoginID As DataGridViewTextBoxColumn
    Friend WithEvents colExpenditureRecordDate As DataGridViewTextBoxColumn
    Friend WithEvents colBankedBy As DataGridViewTextBoxColumn
End Class