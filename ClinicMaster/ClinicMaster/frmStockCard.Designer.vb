<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockCard : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal itemCategoryID As String)
        MyClass.New()
        Me.defaultItemCategoryID = itemCategoryID
    End Sub

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStockCard))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcStockCard = New System.Windows.Forms.TabControl()
        Me.tpgStockCard = New System.Windows.Forms.TabPage()
        Me.dgvStockCard = New System.Windows.Forms.DataGridView()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTransactionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocationUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsStockCard = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblEndDateAndTime = New System.Windows.Forms.Label()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblOpeningBalance = New System.Windows.Forms.Label()
        Me.nbxOpeningLocationUnits = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOpeningLocationUnits = New System.Windows.Forms.Label()
        Me.nbxOpeningBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.stbItemName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.tbcStockCard.SuspendLayout()
        Me.tpgStockCard.SuspendLayout()
        CType(Me.dgvStockCard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsStockCard.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(883, 425)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(83, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "Close"
        '
        'tbcStockCard
        '
        Me.tbcStockCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcStockCard.Controls.Add(Me.tpgStockCard)
        Me.tbcStockCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcStockCard.HotTrack = True
        Me.tbcStockCard.Location = New System.Drawing.Point(15, 163)
        Me.tbcStockCard.Name = "tbcStockCard"
        Me.tbcStockCard.SelectedIndex = 0
        Me.tbcStockCard.Size = New System.Drawing.Size(951, 256)
        Me.tbcStockCard.TabIndex = 1
        '
        'tpgStockCard
        '
        Me.tpgStockCard.Controls.Add(Me.dgvStockCard)
        Me.tpgStockCard.Location = New System.Drawing.Point(4, 22)
        Me.tpgStockCard.Name = "tpgStockCard"
        Me.tpgStockCard.Size = New System.Drawing.Size(943, 230)
        Me.tpgStockCard.TabIndex = 1
        Me.tpgStockCard.Text = "Stock Card"
        Me.tpgStockCard.UseVisualStyleBackColor = True
        '
        'dgvStockCard
        '
        Me.dgvStockCard.AccessibleDescription = ""
        Me.dgvStockCard.AllowUserToAddRows = False
        Me.dgvStockCard.AllowUserToDeleteRows = False
        Me.dgvStockCard.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvStockCard.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvStockCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStockCard.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvStockCard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStockCard.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvStockCard.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStockCard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRecordDate, Me.colRecordTime, Me.ColTransactionDate, Me.colLocation, Me.colStockType, Me.colQuantity, Me.colLocationUnits, Me.colBalance, Me.colDetails, Me.colLoginID})
        Me.dgvStockCard.ContextMenuStrip = Me.cmsStockCard
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockCard.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvStockCard.EnableHeadersVisualStyles = False
        Me.dgvStockCard.GridColor = System.Drawing.Color.Khaki
        Me.dgvStockCard.Location = New System.Drawing.Point(0, 0)
        Me.dgvStockCard.Name = "dgvStockCard"
        Me.dgvStockCard.ReadOnly = True
        Me.dgvStockCard.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockCard.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvStockCard.RowHeadersVisible = False
        Me.dgvStockCard.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvStockCard.Size = New System.Drawing.Size(943, 230)
        Me.dgvStockCard.TabIndex = 0
        Me.dgvStockCard.Text = "DataGridView1"
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 80
        '
        'ColTransactionDate
        '
        Me.ColTransactionDate.DataPropertyName = "TranDate"
        Me.ColTransactionDate.HeaderText = "Transaction Date"
        Me.ColTransactionDate.Name = "ColTransactionDate"
        Me.ColTransactionDate.ReadOnly = True
        '
        'colLocation
        '
        Me.colLocation.DataPropertyName = "Location"
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.Name = "colLocation"
        Me.colLocation.ReadOnly = True
        '
        'colStockType
        '
        Me.colStockType.DataPropertyName = "StockType"
        Me.colStockType.HeaderText = "Stock Type"
        Me.colStockType.Name = "colStockType"
        Me.colStockType.ReadOnly = True
        Me.colStockType.Width = 80
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colLocationUnits
        '
        Me.colLocationUnits.DataPropertyName = "LocationUnits"
        Me.colLocationUnits.HeaderText = "Location Units"
        Me.colLocationUnits.Name = "colLocationUnits"
        Me.colLocationUnits.ReadOnly = True
        Me.colLocationUnits.Width = 80
        '
        'colBalance
        '
        Me.colBalance.DataPropertyName = "Balance"
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        Me.colBalance.Width = 80
        '
        'colDetails
        '
        Me.colDetails.DataPropertyName = "Details"
        Me.colDetails.HeaderText = "Details"
        Me.colDetails.Name = "colDetails"
        Me.colDetails.ReadOnly = True
        Me.colDetails.Width = 160
        '
        'colLoginID
        '
        Me.colLoginID.DataPropertyName = "LoginID"
        Me.colLoginID.HeaderText = "Login ID"
        Me.colLoginID.MaxInputLength = 20
        Me.colLoginID.Name = "colLoginID"
        Me.colLoginID.ReadOnly = True
        '
        'cmsStockCard
        '
        Me.cmsStockCard.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsStockCard.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsCopy, Me.cmsSelectAll})
        Me.cmsStockCard.Name = "cmsSearch"
        Me.cmsStockCard.Size = New System.Drawing.Size(123, 48)
        '
        'cmsCopy
        '
        Me.cmsCopy.Enabled = False
        Me.cmsCopy.Image = CType(resources.GetObject("cmsCopy.Image"), System.Drawing.Image)
        Me.cmsCopy.Name = "cmsCopy"
        Me.cmsCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsCopy.Text = "Copy"
        Me.cmsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsSelectAll
        '
        Me.cmsSelectAll.Enabled = False
        Me.cmsSelectAll.Name = "cmsSelectAll"
        Me.cmsSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsSelectAll.Text = "Select All"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(521, 94)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(116, 22)
        Me.fbnLoad.TabIndex = 15
        Me.fbnLoad.Text = "Load..."
        '
        'lblEndDateAndTime
        '
        Me.lblEndDateAndTime.Location = New System.Drawing.Point(418, 12)
        Me.lblEndDateAndTime.Name = "lblEndDateAndTime"
        Me.lblEndDateAndTime.Size = New System.Drawing.Size(136, 20)
        Me.lblEndDateAndTime.TabIndex = 2
        Me.lblEndDateAndTime.Text = "End Date and Time"
        Me.lblEndDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(12, 15)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(134, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Date and Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(643, 93)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 16
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.lblLoginID)
        Me.grpPeriod.Controls.Add(Me.cboLoginID)
        Me.grpPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.grpPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.grpPeriod.Controls.Add(Me.lblOpeningBalance)
        Me.grpPeriod.Controls.Add(Me.nbxOpeningLocationUnits)
        Me.grpPeriod.Controls.Add(Me.lblOpeningLocationUnits)
        Me.grpPeriod.Controls.Add(Me.nbxOpeningBalance)
        Me.grpPeriod.Controls.Add(Me.lblItemName)
        Me.grpPeriod.Controls.Add(Me.cboLocationID)
        Me.grpPeriod.Controls.Add(Me.lblLocationID)
        Me.grpPeriod.Controls.Add(Me.cboItemCode)
        Me.grpPeriod.Controls.Add(Me.stbItemName)
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.lblItemCode)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.lblEndDateAndTime)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.lblStartDateTime)
        Me.grpPeriod.Location = New System.Drawing.Point(15, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(765, 152)
        Me.grpPeriod.TabIndex = 0
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(12, 117)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(195, 20)
        Me.lblLoginID.TabIndex = 21
        Me.lblLoginID.Text = "Login ID (Leave blank or use ‘*’ for all)"
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
        Me.cboLoginID.Location = New System.Drawing.Point(215, 114)
        Me.cboLoginID.MaxLength = 20
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(189, 21)
        Me.cboLoginID.TabIndex = 20
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(560, 13)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 18
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(215, 17)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 17
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.Location = New System.Drawing.Point(418, 55)
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        Me.lblOpeningBalance.Size = New System.Drawing.Size(136, 20)
        Me.lblOpeningBalance.TabIndex = 10
        Me.lblOpeningBalance.Text = "Opening Balance"
        '
        'nbxOpeningLocationUnits
        '
        Me.nbxOpeningLocationUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOpeningLocationUnits.ControlCaption = "Opening Location Units"
        Me.nbxOpeningLocationUnits.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxOpeningLocationUnits.DecimalPlaces = 2
        Me.nbxOpeningLocationUnits.Enabled = False
        Me.nbxOpeningLocationUnits.Location = New System.Drawing.Point(560, 33)
        Me.nbxOpeningLocationUnits.MaxLength = 6
        Me.nbxOpeningLocationUnits.MaxValue = 200.0R
        Me.nbxOpeningLocationUnits.MinValue = 1.0R
        Me.nbxOpeningLocationUnits.Name = "nbxOpeningLocationUnits"
        Me.nbxOpeningLocationUnits.Size = New System.Drawing.Size(189, 20)
        Me.nbxOpeningLocationUnits.TabIndex = 7
        Me.nbxOpeningLocationUnits.Value = ""
        '
        'lblOpeningLocationUnits
        '
        Me.lblOpeningLocationUnits.Location = New System.Drawing.Point(418, 34)
        Me.lblOpeningLocationUnits.Name = "lblOpeningLocationUnits"
        Me.lblOpeningLocationUnits.Size = New System.Drawing.Size(136, 20)
        Me.lblOpeningLocationUnits.TabIndex = 6
        Me.lblOpeningLocationUnits.Text = "Opening Location Units"
        '
        'nbxOpeningBalance
        '
        Me.nbxOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOpeningBalance.ControlCaption = "Opening Balance"
        Me.nbxOpeningBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxOpeningBalance.DecimalPlaces = 2
        Me.nbxOpeningBalance.Enabled = False
        Me.nbxOpeningBalance.Location = New System.Drawing.Point(560, 54)
        Me.nbxOpeningBalance.MaxLength = 5
        Me.nbxOpeningBalance.MaxValue = 45.0R
        Me.nbxOpeningBalance.MinValue = 30.0R
        Me.nbxOpeningBalance.Name = "nbxOpeningBalance"
        Me.nbxOpeningBalance.Size = New System.Drawing.Size(189, 20)
        Me.nbxOpeningBalance.TabIndex = 11
        Me.nbxOpeningBalance.Value = ""
        '
        'lblItemName
        '
        Me.lblItemName.Location = New System.Drawing.Point(12, 60)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(134, 20)
        Me.lblItemName.TabIndex = 8
        Me.lblItemName.Text = "Item Name"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(215, 92)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(189, 21)
        Me.cboLocationID.TabIndex = 14
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(12, 95)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(134, 20)
        Me.lblLocationID.TabIndex = 13
        Me.lblLocationID.Text = "Location"
        '
        'cboItemCode
        '
        Me.cboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCode.DropDownWidth = 300
        Me.cboItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Location = New System.Drawing.Point(215, 37)
        Me.cboItemCode.MaxLength = 40
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(189, 21)
        Me.cboItemCode.TabIndex = 5
        '
        'stbItemName
        '
        Me.stbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemName.CapitalizeFirstLetter = True
        Me.stbItemName.EntryErrorMSG = ""
        Me.stbItemName.Location = New System.Drawing.Point(215, 58)
        Me.stbItemName.MaxLength = 40
        Me.stbItemName.Multiline = True
        Me.stbItemName.Name = "stbItemName"
        Me.stbItemName.ReadOnly = True
        Me.stbItemName.RegularExpression = ""
        Me.stbItemName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbItemName.Size = New System.Drawing.Size(189, 34)
        Me.stbItemName.TabIndex = 9
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(421, 77)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(328, 13)
        Me.lblRecordsNo.TabIndex = 12
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(12, 40)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(134, 20)
        Me.lblItemCode.TabIndex = 4
        Me.lblItemCode.Text = "Item Code"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 425)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 24)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        '
        'frmStockCard
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(978, 461)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.tbcStockCard)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmStockCard"
        Me.Text = "Stock Card"
        Me.tbcStockCard.ResumeLayout(False)
        Me.tpgStockCard.ResumeLayout(False)
        CType(Me.dgvStockCard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsStockCard.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcStockCard As System.Windows.Forms.TabControl
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgStockCard As System.Windows.Forms.TabPage
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDateAndTime As System.Windows.Forms.Label
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dgvStockCard As System.Windows.Forms.DataGridView
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cmsStockCard As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbItemName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents lblOpeningBalance As System.Windows.Forms.Label
    Friend WithEvents nbxOpeningLocationUnits As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOpeningLocationUnits As System.Windows.Forms.Label
    Friend WithEvents nbxOpeningBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTransactionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocationUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblLoginID As Label
End Class
