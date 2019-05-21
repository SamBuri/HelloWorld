<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsumableInventorySummaries : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsumableInventorySummaries))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcPeriodicReport = New System.Windows.Forms.TabControl()
        Me.tpgConsumablePeriodicInventory = New System.Windows.Forms.TabPage()
        Me.dgvConsumablePeriodicInventory = New System.Windows.Forms.DataGridView()
        Me.cmsConsumableInventorySummaries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblEndDateAndTime = New System.Windows.Forms.Label()
        Me.lblStartDateAndTime = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.cboConsumableNo = New System.Windows.Forms.ComboBox()
        Me.stbConsumableName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblConsumableNo = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblTotalStockCostValue = New System.Windows.Forms.Label()
        Me.lblStockCostTotalValue = New System.Windows.Forms.Label()
        Me.stbTotalStockSellingValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTotalStockCostValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNetStockSellingValue = New System.Windows.Forms.Label()
        Me.stbNetSellingValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVATValue = New System.Windows.Forms.Label()
        Me.stbVATValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsAtHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockCostValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockSellingValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpectedIssuedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalManualIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSystemIsssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcPeriodicReport.SuspendLayout()
        Me.tpgConsumablePeriodicInventory.SuspendLayout()
        CType(Me.dgvConsumablePeriodicInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsConsumableInventorySummaries.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(976, 518)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(83, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "Close"
        '
        'tbcPeriodicReport
        '
        Me.tbcPeriodicReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgConsumablePeriodicInventory)
        Me.tbcPeriodicReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcPeriodicReport.HotTrack = True
        Me.tbcPeriodicReport.Location = New System.Drawing.Point(15, 95)
        Me.tbcPeriodicReport.Name = "tbcPeriodicReport"
        Me.tbcPeriodicReport.SelectedIndex = 0
        Me.tbcPeriodicReport.Size = New System.Drawing.Size(1044, 351)
        Me.tbcPeriodicReport.TabIndex = 1
        '
        'tpgConsumablePeriodicInventory
        '
        Me.tpgConsumablePeriodicInventory.Controls.Add(Me.dgvConsumablePeriodicInventory)
        Me.tpgConsumablePeriodicInventory.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumablePeriodicInventory.Name = "tpgConsumablePeriodicInventory"
        Me.tpgConsumablePeriodicInventory.Size = New System.Drawing.Size(1036, 325)
        Me.tpgConsumablePeriodicInventory.TabIndex = 1
        Me.tpgConsumablePeriodicInventory.Text = "Consumable Periodic Inventory"
        Me.tpgConsumablePeriodicInventory.UseVisualStyleBackColor = True
        '
        'dgvConsumablePeriodicInventory
        '
        Me.dgvConsumablePeriodicInventory.AccessibleDescription = ""
        Me.dgvConsumablePeriodicInventory.AllowUserToAddRows = False
        Me.dgvConsumablePeriodicInventory.AllowUserToDeleteRows = False
        Me.dgvConsumablePeriodicInventory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvConsumablePeriodicInventory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsumablePeriodicInventory.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvConsumablePeriodicInventory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvConsumablePeriodicInventory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvConsumablePeriodicInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumablePeriodicInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvConsumablePeriodicInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableNo, Me.colConsumableName, Me.colOrderLevel, Me.colUnitCost, Me.colUnitPrice, Me.colStartBalance, Me.colUnitsInStock, Me.colUnitsAtHand, Me.colStockCostValue, Me.colStockSellingValue, Me.colVATValue, Me.colEndBalance, Me.colTotalReceived, Me.colTotalIssued, Me.colExpectedIssuedAmount, Me.colTotalManualIssued, Me.colSystemIsssued})
        Me.dgvConsumablePeriodicInventory.ContextMenuStrip = Me.cmsConsumableInventorySummaries
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsumablePeriodicInventory.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvConsumablePeriodicInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumablePeriodicInventory.EnableHeadersVisualStyles = False
        Me.dgvConsumablePeriodicInventory.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumablePeriodicInventory.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumablePeriodicInventory.Name = "dgvConsumablePeriodicInventory"
        Me.dgvConsumablePeriodicInventory.ReadOnly = True
        Me.dgvConsumablePeriodicInventory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumablePeriodicInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvConsumablePeriodicInventory.RowHeadersVisible = False
        Me.dgvConsumablePeriodicInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvConsumablePeriodicInventory.Size = New System.Drawing.Size(1036, 325)
        Me.dgvConsumablePeriodicInventory.TabIndex = 0
        Me.dgvConsumablePeriodicInventory.Text = "DataGridView1"
        '
        'cmsConsumableInventorySummaries
        '
        Me.cmsConsumableInventorySummaries.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsConsumableInventorySummaries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsCopy, Me.cmsSelectAll})
        Me.cmsConsumableInventorySummaries.Name = "cmsSearch"
        Me.cmsConsumableInventorySummaries.Size = New System.Drawing.Size(123, 48)
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
        Me.fbnLoad.Location = New System.Drawing.Point(789, 57)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(116, 22)
        Me.fbnLoad.TabIndex = 10
        Me.fbnLoad.Text = "Load..."
        '
        'lblEndDateAndTime
        '
        Me.lblEndDateAndTime.Location = New System.Drawing.Point(461, 15)
        Me.lblEndDateAndTime.Name = "lblEndDateAndTime"
        Me.lblEndDateAndTime.Size = New System.Drawing.Size(129, 20)
        Me.lblEndDateAndTime.TabIndex = 2
        Me.lblEndDateAndTime.Text = "End Date And Time"
        Me.lblEndDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDateAndTime
        '
        Me.lblStartDateAndTime.Location = New System.Drawing.Point(7, 15)
        Me.lblStartDateAndTime.Name = "lblStartDateAndTime"
        Me.lblStartDateAndTime.Size = New System.Drawing.Size(124, 20)
        Me.lblStartDateAndTime.TabIndex = 0
        Me.lblStartDateAndTime.Text = "Start Date and Time"
        Me.lblStartDateAndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(917, 56)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 11
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.grpPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.grpPeriod.Controls.Add(Me.cboLocationID)
        Me.grpPeriod.Controls.Add(Me.lblLocationID)
        Me.grpPeriod.Controls.Add(Me.cboConsumableNo)
        Me.grpPeriod.Controls.Add(Me.stbConsumableName)
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.lblConsumableNo)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.lblEndDateAndTime)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.lblStartDateAndTime)
        Me.grpPeriod.Location = New System.Drawing.Point(15, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(1040, 84)
        Me.grpPeriod.TabIndex = 0
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(579, 15)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 20
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(247, 15)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 19
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(247, 35)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(189, 21)
        Me.cboLocationID.TabIndex = 6
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(7, 37)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(124, 20)
        Me.lblLocationID.TabIndex = 5
        Me.lblLocationID.Text = "Location"
        '
        'cboConsumableNo
        '
        Me.cboConsumableNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsumableNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsumableNo.DropDownWidth = 300
        Me.cboConsumableNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConsumableNo.FormattingEnabled = True
        Me.cboConsumableNo.Location = New System.Drawing.Point(247, 57)
        Me.cboConsumableNo.MaxLength = 40
        Me.cboConsumableNo.Name = "cboConsumableNo"
        Me.cboConsumableNo.Size = New System.Drawing.Size(189, 21)
        Me.cboConsumableNo.TabIndex = 8
        '
        'stbConsumableName
        '
        Me.stbConsumableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumableName.CapitalizeFirstLetter = True
        Me.stbConsumableName.EntryErrorMSG = ""
        Me.stbConsumableName.Location = New System.Drawing.Point(464, 58)
        Me.stbConsumableName.MaxLength = 40
        Me.stbConsumableName.Name = "stbConsumableName"
        Me.stbConsumableName.ReadOnly = True
        Me.stbConsumableName.RegularExpression = ""
        Me.stbConsumableName.Size = New System.Drawing.Size(304, 20)
        Me.stbConsumableName.TabIndex = 9
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(774, 19)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(249, 13)
        Me.lblRecordsNo.TabIndex = 4
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblConsumableNo
        '
        Me.lblConsumableNo.Location = New System.Drawing.Point(7, 60)
        Me.lblConsumableNo.Name = "lblConsumableNo"
        Me.lblConsumableNo.Size = New System.Drawing.Size(234, 20)
        Me.lblConsumableNo.TabIndex = 7
        Me.lblConsumableNo.Text = "Consumable No (Leave blank or use ‘*’ for all)"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(19, 511)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 24)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        '
        'lblTotalStockCostValue
        '
        Me.lblTotalStockCostValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalStockCostValue.Location = New System.Drawing.Point(689, 448)
        Me.lblTotalStockCostValue.Name = "lblTotalStockCostValue"
        Me.lblTotalStockCostValue.Size = New System.Drawing.Size(144, 20)
        Me.lblTotalStockCostValue.TabIndex = 33
        Me.lblTotalStockCostValue.Text = "Total Stock Selling Value"
        '
        'lblStockCostTotalValue
        '
        Me.lblStockCostTotalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStockCostTotalValue.Location = New System.Drawing.Point(14, 458)
        Me.lblStockCostTotalValue.Name = "lblStockCostTotalValue"
        Me.lblStockCostTotalValue.Size = New System.Drawing.Size(139, 20)
        Me.lblStockCostTotalValue.TabIndex = 35
        Me.lblStockCostTotalValue.Text = "Total Stock Cost Value"
        '
        'stbTotalStockSellingValue
        '
        Me.stbTotalStockSellingValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalStockSellingValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalStockSellingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalStockSellingValue.CapitalizeFirstLetter = False
        Me.stbTotalStockSellingValue.Enabled = False
        Me.stbTotalStockSellingValue.EntryErrorMSG = ""
        Me.stbTotalStockSellingValue.Location = New System.Drawing.Point(876, 448)
        Me.stbTotalStockSellingValue.MaxLength = 20
        Me.stbTotalStockSellingValue.Name = "stbTotalStockSellingValue"
        Me.stbTotalStockSellingValue.RegularExpression = ""
        Me.stbTotalStockSellingValue.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalStockSellingValue.TabIndex = 34
        Me.stbTotalStockSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbTotalStockCostValue
        '
        Me.stbTotalStockCostValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalStockCostValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalStockCostValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalStockCostValue.CapitalizeFirstLetter = False
        Me.stbTotalStockCostValue.Enabled = False
        Me.stbTotalStockCostValue.EntryErrorMSG = ""
        Me.stbTotalStockCostValue.Location = New System.Drawing.Point(159, 456)
        Me.stbTotalStockCostValue.MaxLength = 20
        Me.stbTotalStockCostValue.Name = "stbTotalStockCostValue"
        Me.stbTotalStockCostValue.RegularExpression = ""
        Me.stbTotalStockCostValue.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalStockCostValue.TabIndex = 36
        Me.stbTotalStockCostValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNetStockSellingValue
        '
        Me.lblNetStockSellingValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNetStockSellingValue.Location = New System.Drawing.Point(689, 491)
        Me.lblNetStockSellingValue.Name = "lblNetStockSellingValue"
        Me.lblNetStockSellingValue.Size = New System.Drawing.Size(144, 20)
        Me.lblNetStockSellingValue.TabIndex = 37
        Me.lblNetStockSellingValue.Text = "Net Stock Selling Value"
        '
        'stbNetSellingValue
        '
        Me.stbNetSellingValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbNetSellingValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbNetSellingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNetSellingValue.CapitalizeFirstLetter = False
        Me.stbNetSellingValue.Enabled = False
        Me.stbNetSellingValue.EntryErrorMSG = ""
        Me.stbNetSellingValue.Location = New System.Drawing.Point(875, 491)
        Me.stbNetSellingValue.MaxLength = 20
        Me.stbNetSellingValue.Name = "stbNetSellingValue"
        Me.stbNetSellingValue.RegularExpression = ""
        Me.stbNetSellingValue.Size = New System.Drawing.Size(184, 20)
        Me.stbNetSellingValue.TabIndex = 38
        Me.stbNetSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblVATValue
        '
        Me.lblVATValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVATValue.Location = New System.Drawing.Point(688, 470)
        Me.lblVATValue.Name = "lblVATValue"
        Me.lblVATValue.Size = New System.Drawing.Size(144, 20)
        Me.lblVATValue.TabIndex = 39
        Me.lblVATValue.Text = "Total VAT Value"
        '
        'stbVATValue
        '
        Me.stbVATValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbVATValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbVATValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVATValue.CapitalizeFirstLetter = False
        Me.stbVATValue.Enabled = False
        Me.stbVATValue.EntryErrorMSG = ""
        Me.stbVATValue.Location = New System.Drawing.Point(875, 470)
        Me.stbVATValue.MaxLength = 20
        Me.stbVATValue.Name = "stbVATValue"
        Me.stbVATValue.RegularExpression = ""
        Me.stbVATValue.Size = New System.Drawing.Size(184, 20)
        Me.stbVATValue.TabIndex = 40
        Me.stbVATValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(108, 511)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 84
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'colConsumableNo
        '
        Me.colConsumableNo.DataPropertyName = "ConsumableNo"
        Me.colConsumableNo.HeaderText = "Consumable No"
        Me.colConsumableNo.Name = "colConsumableNo"
        Me.colConsumableNo.ReadOnly = True
        '
        'colConsumableName
        '
        Me.colConsumableName.DataPropertyName = "ConsumableName"
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Width = 120
        '
        'colOrderLevel
        '
        Me.colOrderLevel.DataPropertyName = "OrderLevel"
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Width = 70
        '
        'colUnitCost
        '
        Me.colUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitCost.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitCost.HeaderText = "Unit Cost"
        Me.colUnitCost.Name = "colUnitCost"
        Me.colUnitCost.ReadOnly = True
        Me.colUnitCost.Width = 60
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle4
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colStartBalance
        '
        Me.colStartBalance.DataPropertyName = "StartBalance"
        Me.colStartBalance.HeaderText = "Units At Start"
        Me.colStartBalance.Name = "colStartBalance"
        Me.colStartBalance.ReadOnly = True
        Me.colStartBalance.Width = 80
        '
        'colUnitsInStock
        '
        Me.colUnitsInStock.DataPropertyName = "UnitsInStock"
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colUnitsAtHand
        '
        Me.colUnitsAtHand.DataPropertyName = "UnitsAtHand"
        Me.colUnitsAtHand.HeaderText = "Units At Hand"
        Me.colUnitsAtHand.Name = "colUnitsAtHand"
        Me.colUnitsAtHand.ReadOnly = True
        Me.colUnitsAtHand.Width = 80
        '
        'colStockCostValue
        '
        Me.colStockCostValue.DataPropertyName = "StockCostValue"
        Me.colStockCostValue.HeaderText = "Stock Cost Value "
        Me.colStockCostValue.Name = "colStockCostValue"
        Me.colStockCostValue.ReadOnly = True
        Me.colStockCostValue.Width = 150
        '
        'colStockSellingValue
        '
        Me.colStockSellingValue.DataPropertyName = "StockSellingValue"
        Me.colStockSellingValue.HeaderText = "Stock Selling Value"
        Me.colStockSellingValue.Name = "colStockSellingValue"
        Me.colStockSellingValue.ReadOnly = True
        Me.colStockSellingValue.Width = 150
        '
        'colVATValue
        '
        Me.colVATValue.DataPropertyName = "VATValue"
        Me.colVATValue.HeaderText = "VAT Value"
        Me.colVATValue.Name = "colVATValue"
        Me.colVATValue.ReadOnly = True
        '
        'colEndBalance
        '
        Me.colEndBalance.DataPropertyName = "EndBalance"
        Me.colEndBalance.HeaderText = "Units At End"
        Me.colEndBalance.Name = "colEndBalance"
        Me.colEndBalance.ReadOnly = True
        Me.colEndBalance.Width = 80
        '
        'colTotalReceived
        '
        Me.colTotalReceived.DataPropertyName = "TotalReceived"
        Me.colTotalReceived.HeaderText = "Total Received"
        Me.colTotalReceived.Name = "colTotalReceived"
        Me.colTotalReceived.ReadOnly = True
        Me.colTotalReceived.Width = 90
        '
        'colTotalIssued
        '
        Me.colTotalIssued.DataPropertyName = "TotalIssued"
        Me.colTotalIssued.HeaderText = "Total Issued"
        Me.colTotalIssued.Name = "colTotalIssued"
        Me.colTotalIssued.ReadOnly = True
        Me.colTotalIssued.Width = 70
        '
        'colExpectedIssuedAmount
        '
        Me.colExpectedIssuedAmount.DataPropertyName = "ExpectedIssuedAmount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colExpectedIssuedAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExpectedIssuedAmount.HeaderText = "Expected Issued Amount"
        Me.colExpectedIssuedAmount.Name = "colExpectedIssuedAmount"
        Me.colExpectedIssuedAmount.ReadOnly = True
        Me.colExpectedIssuedAmount.Width = 140
        '
        'colTotalManualIssued
        '
        Me.colTotalManualIssued.DataPropertyName = "TotalManualIssued"
        Me.colTotalManualIssued.HeaderText = "Total Manual Issued"
        Me.colTotalManualIssued.Name = "colTotalManualIssued"
        Me.colTotalManualIssued.ReadOnly = True
        Me.colTotalManualIssued.Width = 120
        '
        'colSystemIsssued
        '
        Me.colSystemIsssued.DataPropertyName = "TotalSystemIssued"
        Me.colSystemIsssued.HeaderText = "System Issued"
        Me.colSystemIsssued.Name = "colSystemIsssued"
        Me.colSystemIsssued.ReadOnly = True
        '
        'frmConsumableInventorySummaries
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1071, 547)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.lblVATValue)
        Me.Controls.Add(Me.stbVATValue)
        Me.Controls.Add(Me.lblNetStockSellingValue)
        Me.Controls.Add(Me.stbNetSellingValue)
        Me.Controls.Add(Me.lblTotalStockCostValue)
        Me.Controls.Add(Me.lblStockCostTotalValue)
        Me.Controls.Add(Me.stbTotalStockSellingValue)
        Me.Controls.Add(Me.stbTotalStockCostValue)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.tbcPeriodicReport)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsumableInventorySummaries"
        Me.Text = "Consumable Inventory Summaries"
        Me.tbcPeriodicReport.ResumeLayout(False)
        Me.tpgConsumablePeriodicInventory.ResumeLayout(False)
        CType(Me.dgvConsumablePeriodicInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsConsumableInventorySummaries.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcPeriodicReport As System.Windows.Forms.TabControl
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgConsumablePeriodicInventory As System.Windows.Forms.TabPage
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDateAndTime As System.Windows.Forms.Label
    Friend WithEvents lblStartDateAndTime As System.Windows.Forms.Label
    Friend WithEvents dgvConsumablePeriodicInventory As System.Windows.Forms.DataGridView
    Friend WithEvents lblConsumableNo As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cmsConsumableInventorySummaries As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbConsumableName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboConsumableNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTotalStockCostValue As Label
    Friend WithEvents lblStockCostTotalValue As Label
    Friend WithEvents stbTotalStockSellingValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTotalStockCostValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNetStockSellingValue As Label
    Friend WithEvents stbNetSellingValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVATValue As Label
    Friend WithEvents stbVATValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsAtHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockCostValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockSellingValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalIssued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpectedIssuedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalManualIssued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSystemIsssued As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
