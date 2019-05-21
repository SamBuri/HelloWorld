
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSupplierHistory : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSupplierHistory))
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvSupplierHistory = New System.Windows.Forms.DataGridView()
        Me.colSupplierNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhoneNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantityReturned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnAmont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.cboItemCategory = New System.Windows.Forms.ComboBox()
        Me.lblItemCategory = New System.Windows.Forms.Label()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvSupplierHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(122, 450)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 92
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(26, 450)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 91
        Me.btnPrint.Text = "&Print"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(547, 403)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(473, 39)
        Me.stbAmountWords.TabIndex = 90
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.Location = New System.Drawing.Point(23, 408)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(124, 20)
        Me.lblTotalAmount.TabIndex = 87
        Me.lblTotalAmount.Text = "Total Net Amount"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmountWords.Location = New System.Drawing.Point(397, 408)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(144, 21)
        Me.lblAmountWords.TabIndex = 89
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
        Me.stbTotalAmount.Location = New System.Drawing.Point(150, 406)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(206, 20)
        Me.stbTotalAmount.TabIndex = 88
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvSupplierHistory
        '
        Me.dgvSupplierHistory.AllowUserToAddRows = False
        Me.dgvSupplierHistory.AllowUserToDeleteRows = False
        Me.dgvSupplierHistory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSupplierHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSupplierHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSupplierHistory.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSupplierHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSupplierHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSupplierHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplierHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSupplierHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSupplierNo, Me.colSupplierName, Me.colPhoneNo, Me.colItemCategory, Me.colItemCode, Me.colItemName, Me.colTotalReceived, Me.colQuantityReturned, Me.colRate, Me.colVATValue, Me.colTotalAmount, Me.colReturnAmont, Me.colNetAmount, Me.colRecordDateTime, Me.colLoginID})
        Me.dgvSupplierHistory.EnableHeadersVisualStyles = False
        Me.dgvSupplierHistory.GridColor = System.Drawing.Color.Khaki
        Me.dgvSupplierHistory.Location = New System.Drawing.Point(12, 121)
        Me.dgvSupplierHistory.Name = "dgvSupplierHistory"
        Me.dgvSupplierHistory.ReadOnly = True
        Me.dgvSupplierHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplierHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSupplierHistory.RowHeadersVisible = False
        Me.dgvSupplierHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSupplierHistory.Size = New System.Drawing.Size(1015, 276)
        Me.dgvSupplierHistory.TabIndex = 86
        Me.dgvSupplierHistory.Text = "DataGridView1"
        '
        'colSupplierNo
        '
        Me.colSupplierNo.DataPropertyName = "SupplierNo"
        Me.colSupplierNo.HeaderText = "Supplier No"
        Me.colSupplierNo.Name = "colSupplierNo"
        Me.colSupplierNo.ReadOnly = True
        '
        'colSupplierName
        '
        Me.colSupplierName.DataPropertyName = "SupplierName"
        Me.colSupplierName.HeaderText = "Supplier Name"
        Me.colSupplierName.Name = "colSupplierName"
        Me.colSupplierName.ReadOnly = True
        Me.colSupplierName.Width = 120
        '
        'colPhoneNo
        '
        Me.colPhoneNo.DataPropertyName = "Phone"
        Me.colPhoneNo.HeaderText = "Phone No"
        Me.colPhoneNo.Name = "colPhoneNo"
        Me.colPhoneNo.ReadOnly = True
        Me.colPhoneNo.Visible = False
        Me.colPhoneNo.Width = 80
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colTotalReceived
        '
        Me.colTotalReceived.DataPropertyName = "TotalReceived"
        Me.colTotalReceived.HeaderText = "Quantity Received"
        Me.colTotalReceived.Name = "colTotalReceived"
        Me.colTotalReceived.ReadOnly = True
        '
        'colQuantityReturned
        '
        Me.colQuantityReturned.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQuantityReturned.DefaultCellStyle = DataGridViewCellStyle3
        Me.colQuantityReturned.HeaderText = "Quantity Returned"
        Me.colQuantityReturned.Name = "colQuantityReturned"
        Me.colQuantityReturned.ReadOnly = True
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        Me.colRate.Width = 80
        '
        'colVATValue
        '
        Me.colVATValue.DataPropertyName = "VATValue"
        Me.colVATValue.HeaderText = "VAT VAlue"
        Me.colVATValue.Name = "colVATValue"
        Me.colVATValue.ReadOnly = True
        Me.colVATValue.Width = 80
        '
        'colTotalAmount
        '
        Me.colTotalAmount.DataPropertyName = "TotalReceivedAmount"
        Me.colTotalAmount.HeaderText = "Total Amount"
        Me.colTotalAmount.Name = "colTotalAmount"
        Me.colTotalAmount.ReadOnly = True
        '
        'colReturnAmont
        '
        Me.colReturnAmont.DataPropertyName = "ReturnAmount"
        Me.colReturnAmont.HeaderText = "Return Amount"
        Me.colReturnAmont.Name = "colReturnAmont"
        Me.colReturnAmont.ReadOnly = True
        '
        'colNetAmount
        '
        Me.colNetAmount.DataPropertyName = "NetAmount"
        Me.colNetAmount.HeaderText = "Net Amount"
        Me.colNetAmount.Name = "colNetAmount"
        Me.colNetAmount.ReadOnly = True
        '
        'colRecordDateTime
        '
        Me.colRecordDateTime.DataPropertyName = "RecordDateTime"
        Me.colRecordDateTime.HeaderText = "Record Date Time"
        Me.colRecordDateTime.Name = "colRecordDateTime"
        Me.colRecordDateTime.ReadOnly = True
        '
        'colLoginID
        '
        Me.colLoginID.DataPropertyName = "LoginID"
        Me.colLoginID.HeaderText = "Login ID"
        Me.colLoginID.Name = "colLoginID"
        Me.colLoginID.ReadOnly = True
        Me.colLoginID.Width = 80
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.cboItemCode)
        Me.grpSetParameters.Controls.Add(Me.lblItemCode)
        Me.grpSetParameters.Controls.Add(Me.cboSupplierNo)
        Me.grpSetParameters.Controls.Add(Me.lblSupplierNo)
        Me.grpSetParameters.Controls.Add(Me.stbSupplierName)
        Me.grpSetParameters.Controls.Add(Me.lblSupplierName)
        Me.grpSetParameters.Controls.Add(Me.cboItemCategory)
        Me.grpSetParameters.Controls.Add(Me.lblItemCategory)
        Me.grpSetParameters.Controls.Add(Me.fbnRefresh)
        Me.grpSetParameters.Controls.Add(Me.fbnExport)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 14)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1015, 103)
        Me.grpSetParameters.TabIndex = 85
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Period"
        '
        'cboItemCode
        '
        Me.cboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCode.BackColor = System.Drawing.SystemColors.Window
        Me.cboItemCode.DropDownWidth = 203
        Me.cboItemCode.Enabled = False
        Me.cboItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.ItemHeight = 13
        Me.cboItemCode.Location = New System.Drawing.Point(571, 74)
        Me.cboItemCode.MaxLength = 20
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(182, 21)
        Me.cboItemCode.TabIndex = 27
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(373, 76)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(181, 20)
        Me.lblItemCode.TabIndex = 26
        Me.lblItemCode.Text = "Item Code"
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
        Me.cboSupplierNo.Location = New System.Drawing.Point(158, 51)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(198, 21)
        Me.cboSupplierNo.TabIndex = 25
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(4, 54)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(148, 20)
        Me.lblSupplierNo.TabIndex = 22
        Me.lblSupplierNo.Text = "Supplier No"
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(158, 74)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.Size = New System.Drawing.Size(198, 20)
        Me.stbSupplierName.TabIndex = 24
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(4, 76)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(148, 20)
        Me.lblSupplierName.TabIndex = 23
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'cboItemCategory
        '
        Me.cboItemCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCategory.BackColor = System.Drawing.SystemColors.Window
        Me.cboItemCategory.DropDownWidth = 203
        Me.cboItemCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategory.FormattingEnabled = True
        Me.cboItemCategory.ItemHeight = 13
        Me.cboItemCategory.Location = New System.Drawing.Point(571, 51)
        Me.cboItemCategory.MaxLength = 20
        Me.cboItemCategory.Name = "cboItemCategory"
        Me.cboItemCategory.Size = New System.Drawing.Size(182, 21)
        Me.cboItemCategory.TabIndex = 19
        '
        'lblItemCategory
        '
        Me.lblItemCategory.Location = New System.Drawing.Point(373, 51)
        Me.lblItemCategory.Name = "lblItemCategory"
        Me.lblItemCategory.Size = New System.Drawing.Size(181, 20)
        Me.lblItemCategory.TabIndex = 18
        Me.lblItemCategory.Text = "Item Category"
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(847, 72)
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
        Me.fbnExport.Location = New System.Drawing.Point(927, 72)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
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
        Me.fbnLoad.Location = New System.Drawing.Point(767, 71)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "&Load"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(955, 453)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 84
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmSupplierHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1040, 489)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.stbTotalAmount)
        Me.Controls.Add(Me.dgvSupplierHistory)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmSupplierHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier History"
        CType(Me.dgvSupplierHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.grpSetParameters.PerformLayout()
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As Label
    Friend WithEvents lblAmountWords As Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvSupplierHistory As DataGridView
    Friend WithEvents grpSetParameters As GroupBox
    Friend WithEvents cboItemCategory As ComboBox
    Friend WithEvents lblItemCategory As Label
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlPeriod As Panel
    Friend WithEvents dtpEndDateTime As DateTimePicker
    Friend WithEvents lblStartDateTime As Label
    Friend WithEvents dtpStartDateTime As DateTimePicker
    Friend WithEvents lblEndDateTime As Label
    Friend WithEvents lblRecordsNo As Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboSupplierNo As ComboBox
    Friend WithEvents lblSupplierNo As Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSupplierName As Label
    Friend WithEvents cboItemCode As ComboBox
    Friend WithEvents lblItemCode As Label
    Friend WithEvents colSupplierNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhoneNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantityReturned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnAmont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class