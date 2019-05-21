<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrugInventorySummaries : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugInventorySummaries))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcPeriodicReport = New System.Windows.Forms.TabControl()
        Me.tpgDrugPeriodicInventory = New System.Windows.Forms.TabPage()
        Me.dgvDrugPeriodicInventory = New System.Windows.Forms.DataGridView()
        Me.cmsDrugInventorySummaries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStockCostTotalValue = New System.Windows.Forms.Label()
        Me.stbTotalStockCostValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalStockCostValue = New System.Windows.Forms.Label()
        Me.stbTotalStockSellingValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.cboDrugNo = New System.Windows.Forms.ComboBox()
        Me.stbDrugName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblDrugNo = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblVATValue = New System.Windows.Forms.Label()
        Me.stbVATValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNetStockSellingValue = New System.Windows.Forms.Label()
        Me.stbNetSellingValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsAtHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockCostValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockSellingValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockValueAtStart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockValueAtStartCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockValueAtEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStockValueAtEndSelling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpectedIssuedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalManualIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSystemIssued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcPeriodicReport.SuspendLayout()
        Me.tpgDrugPeriodicInventory.SuspendLayout()
        CType(Me.dgvDrugPeriodicInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDrugInventorySummaries.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(979, 476)
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
        Me.tbcPeriodicReport.Controls.Add(Me.tpgDrugPeriodicInventory)
        Me.tbcPeriodicReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcPeriodicReport.HotTrack = True
        Me.tbcPeriodicReport.Location = New System.Drawing.Point(15, 95)
        Me.tbcPeriodicReport.Name = "tbcPeriodicReport"
        Me.tbcPeriodicReport.SelectedIndex = 0
        Me.tbcPeriodicReport.Size = New System.Drawing.Size(1047, 317)
        Me.tbcPeriodicReport.TabIndex = 1
        '
        'tpgDrugPeriodicInventory
        '
        Me.tpgDrugPeriodicInventory.Controls.Add(Me.dgvDrugPeriodicInventory)
        Me.tpgDrugPeriodicInventory.Location = New System.Drawing.Point(4, 22)
        Me.tpgDrugPeriodicInventory.Name = "tpgDrugPeriodicInventory"
        Me.tpgDrugPeriodicInventory.Size = New System.Drawing.Size(1039, 291)
        Me.tpgDrugPeriodicInventory.TabIndex = 1
        Me.tpgDrugPeriodicInventory.Text = "Drug Periodic Inventory"
        Me.tpgDrugPeriodicInventory.UseVisualStyleBackColor = True
        '
        'dgvDrugPeriodicInventory
        '
        Me.dgvDrugPeriodicInventory.AccessibleDescription = ""
        Me.dgvDrugPeriodicInventory.AllowUserToAddRows = False
        Me.dgvDrugPeriodicInventory.AllowUserToDeleteRows = False
        Me.dgvDrugPeriodicInventory.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDrugPeriodicInventory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDrugPeriodicInventory.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDrugPeriodicInventory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDrugPeriodicInventory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDrugPeriodicInventory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugPeriodicInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDrugPeriodicInventory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugNo, Me.colDrugName, Me.colOrderLevel, Me.colUnitCost, Me.colUnitPrice, Me.colUnitsInStock, Me.colUnitsAtHand, Me.colStockCostValue, Me.colStockSellingValue, Me.colVATValue, Me.colStartBalance, Me.ColStockValueAtStart, Me.ColStockValueAtStartCost, Me.colEndBalance, Me.ColStockValueAtEnd, Me.ColStockValueAtEndSelling, Me.colTotalReceived, Me.colTotalIssued, Me.colExpectedIssuedAmount, Me.colTotalManualIssued, Me.colSystemIssued})
        Me.dgvDrugPeriodicInventory.ContextMenuStrip = Me.cmsDrugInventorySummaries
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDrugPeriodicInventory.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDrugPeriodicInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrugPeriodicInventory.EnableHeadersVisualStyles = False
        Me.dgvDrugPeriodicInventory.GridColor = System.Drawing.Color.Khaki
        Me.dgvDrugPeriodicInventory.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrugPeriodicInventory.Name = "dgvDrugPeriodicInventory"
        Me.dgvDrugPeriodicInventory.ReadOnly = True
        Me.dgvDrugPeriodicInventory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugPeriodicInventory.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDrugPeriodicInventory.RowHeadersVisible = False
        Me.dgvDrugPeriodicInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDrugPeriodicInventory.Size = New System.Drawing.Size(1039, 291)
        Me.dgvDrugPeriodicInventory.TabIndex = 0
        Me.dgvDrugPeriodicInventory.Text = "DataGridView1"
        '
        'cmsDrugInventorySummaries
        '
        Me.cmsDrugInventorySummaries.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDrugInventorySummaries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsCopy, Me.cmsSelectAll})
        Me.cmsDrugInventorySummaries.Name = "cmsSearch"
        Me.cmsDrugInventorySummaries.Size = New System.Drawing.Size(123, 48)
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
        'lblStockCostTotalValue
        '
        Me.lblStockCostTotalValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblStockCostTotalValue.Location = New System.Drawing.Point(16, 416)
        Me.lblStockCostTotalValue.Name = "lblStockCostTotalValue"
        Me.lblStockCostTotalValue.Size = New System.Drawing.Size(139, 20)
        Me.lblStockCostTotalValue.TabIndex = 31
        Me.lblStockCostTotalValue.Text = "Total Stock Cost Value"
        '
        'stbTotalStockCostValue
        '
        Me.stbTotalStockCostValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalStockCostValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalStockCostValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalStockCostValue.CapitalizeFirstLetter = False
        Me.stbTotalStockCostValue.Enabled = False
        Me.stbTotalStockCostValue.EntryErrorMSG = ""
        Me.stbTotalStockCostValue.Location = New System.Drawing.Point(161, 414)
        Me.stbTotalStockCostValue.MaxLength = 20
        Me.stbTotalStockCostValue.Name = "stbTotalStockCostValue"
        Me.stbTotalStockCostValue.RegularExpression = ""
        Me.stbTotalStockCostValue.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalStockCostValue.TabIndex = 32
        Me.stbTotalStockCostValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalStockCostValue
        '
        Me.lblTotalStockCostValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalStockCostValue.Location = New System.Drawing.Point(687, 414)
        Me.lblTotalStockCostValue.Name = "lblTotalStockCostValue"
        Me.lblTotalStockCostValue.Size = New System.Drawing.Size(144, 20)
        Me.lblTotalStockCostValue.TabIndex = 29
        Me.lblTotalStockCostValue.Text = "Total Stock Selling Value"
        '
        'stbTotalStockSellingValue
        '
        Me.stbTotalStockSellingValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalStockSellingValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalStockSellingValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalStockSellingValue.CapitalizeFirstLetter = False
        Me.stbTotalStockSellingValue.Enabled = False
        Me.stbTotalStockSellingValue.EntryErrorMSG = ""
        Me.stbTotalStockSellingValue.Location = New System.Drawing.Point(874, 414)
        Me.stbTotalStockSellingValue.MaxLength = 20
        Me.stbTotalStockSellingValue.Name = "stbTotalStockSellingValue"
        Me.stbTotalStockSellingValue.RegularExpression = ""
        Me.stbTotalStockSellingValue.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalStockSellingValue.TabIndex = 30
        Me.stbTotalStockSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(793, 57)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(116, 22)
        Me.fbnLoad.TabIndex = 10
        Me.fbnLoad.Text = "Load..."
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(436, 15)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(107, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date and Time"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(7, 15)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(124, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date and Time"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(921, 56)
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
        Me.grpPeriod.Controls.Add(Me.cboDrugNo)
        Me.grpPeriod.Controls.Add(Me.stbDrugName)
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.lblDrugNo)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(15, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(1043, 84)
        Me.grpPeriod.TabIndex = 0
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(549, 15)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 19
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(217, 15)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 18
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(219, 35)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(187, 21)
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
        'cboDrugNo
        '
        Me.cboDrugNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDrugNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDrugNo.DropDownWidth = 300
        Me.cboDrugNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDrugNo.FormattingEnabled = True
        Me.cboDrugNo.Location = New System.Drawing.Point(219, 57)
        Me.cboDrugNo.MaxLength = 40
        Me.cboDrugNo.Name = "cboDrugNo"
        Me.cboDrugNo.Size = New System.Drawing.Size(187, 21)
        Me.cboDrugNo.TabIndex = 8
        '
        'stbDrugName
        '
        Me.stbDrugName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrugName.CapitalizeFirstLetter = True
        Me.stbDrugName.EntryErrorMSG = ""
        Me.stbDrugName.Location = New System.Drawing.Point(439, 58)
        Me.stbDrugName.MaxLength = 40
        Me.stbDrugName.Name = "stbDrugName"
        Me.stbDrugName.ReadOnly = True
        Me.stbDrugName.RegularExpression = ""
        Me.stbDrugName.Size = New System.Drawing.Size(299, 20)
        Me.stbDrugName.TabIndex = 9
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(744, 16)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(270, 13)
        Me.lblRecordsNo.TabIndex = 4
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDrugNo
        '
        Me.lblDrugNo.Location = New System.Drawing.Point(7, 60)
        Me.lblDrugNo.Name = "lblDrugNo"
        Me.lblDrugNo.Size = New System.Drawing.Size(204, 20)
        Me.lblDrugNo.TabIndex = 7
        Me.lblDrugNo.Text = "Drug No (Leave blank or use ‘*’ for all)"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 476)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(83, 24)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        '
        'lblVATValue
        '
        Me.lblVATValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblVATValue.Location = New System.Drawing.Point(687, 434)
        Me.lblVATValue.Name = "lblVATValue"
        Me.lblVATValue.Size = New System.Drawing.Size(144, 20)
        Me.lblVATValue.TabIndex = 43
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
        Me.stbVATValue.Location = New System.Drawing.Point(874, 434)
        Me.stbVATValue.MaxLength = 20
        Me.stbVATValue.Name = "stbVATValue"
        Me.stbVATValue.RegularExpression = ""
        Me.stbVATValue.Size = New System.Drawing.Size(184, 20)
        Me.stbVATValue.TabIndex = 44
        Me.stbVATValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNetStockSellingValue
        '
        Me.lblNetStockSellingValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblNetStockSellingValue.Location = New System.Drawing.Point(688, 455)
        Me.lblNetStockSellingValue.Name = "lblNetStockSellingValue"
        Me.lblNetStockSellingValue.Size = New System.Drawing.Size(144, 20)
        Me.lblNetStockSellingValue.TabIndex = 41
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
        Me.stbNetSellingValue.Location = New System.Drawing.Point(874, 455)
        Me.stbNetSellingValue.MaxLength = 20
        Me.stbNetSellingValue.Name = "stbNetSellingValue"
        Me.stbNetSellingValue.RegularExpression = ""
        Me.stbNetSellingValue.Size = New System.Drawing.Size(184, 20)
        Me.stbNetSellingValue.TabIndex = 42
        Me.stbNetSellingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(101, 476)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 85
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "DrugNo"
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.ReadOnly = True
        Me.colDrugNo.Width = 60
        '
        'colDrugName
        '
        Me.colDrugName.DataPropertyName = "DrugName"
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
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
        Me.colStockCostValue.HeaderText = "Stock Value (Cost)"
        Me.colStockCostValue.Name = "colStockCostValue"
        Me.colStockCostValue.ReadOnly = True
        Me.colStockCostValue.Width = 170
        '
        'colStockSellingValue
        '
        Me.colStockSellingValue.DataPropertyName = "StockSellingValue"
        Me.colStockSellingValue.HeaderText = "Stock Value (Selling)"
        Me.colStockSellingValue.Name = "colStockSellingValue"
        Me.colStockSellingValue.ReadOnly = True
        Me.colStockSellingValue.Width = 170
        '
        'colVATValue
        '
        Me.colVATValue.DataPropertyName = "VATValue"
        Me.colVATValue.HeaderText = "Excepted VAT Value"
        Me.colVATValue.Name = "colVATValue"
        Me.colVATValue.ReadOnly = True
        Me.colVATValue.Width = 150
        '
        'colStartBalance
        '
        Me.colStartBalance.DataPropertyName = "StartBalance"
        Me.colStartBalance.HeaderText = "Units At Start"
        Me.colStartBalance.Name = "colStartBalance"
        Me.colStartBalance.ReadOnly = True
        Me.colStartBalance.Width = 80
        '
        'ColStockValueAtStart
        '
        Me.ColStockValueAtStart.DataPropertyName = "openingStockCostValue"
        Me.ColStockValueAtStart.HeaderText = "Stock Value At Start (Cost)"
        Me.ColStockValueAtStart.Name = "ColStockValueAtStart"
        Me.ColStockValueAtStart.ReadOnly = True
        Me.ColStockValueAtStart.Width = 170
        '
        'ColStockValueAtStartCost
        '
        Me.ColStockValueAtStartCost.DataPropertyName = "openingStockUnitValue"
        Me.ColStockValueAtStartCost.HeaderText = "Stock Value At Start (Selling)"
        Me.ColStockValueAtStartCost.Name = "ColStockValueAtStartCost"
        Me.ColStockValueAtStartCost.ReadOnly = True
        Me.ColStockValueAtStartCost.Width = 170
        '
        'colEndBalance
        '
        Me.colEndBalance.DataPropertyName = "EndBalance"
        Me.colEndBalance.HeaderText = "Units At End"
        Me.colEndBalance.Name = "colEndBalance"
        Me.colEndBalance.ReadOnly = True
        Me.colEndBalance.Width = 80
        '
        'ColStockValueAtEnd
        '
        Me.ColStockValueAtEnd.DataPropertyName = "EndBalanceStockCostValue"
        Me.ColStockValueAtEnd.HeaderText = "Stock Value At End (Cost)"
        Me.ColStockValueAtEnd.Name = "ColStockValueAtEnd"
        Me.ColStockValueAtEnd.ReadOnly = True
        Me.ColStockValueAtEnd.Width = 170
        '
        'ColStockValueAtEndSelling
        '
        Me.ColStockValueAtEndSelling.DataPropertyName = "EndBalanceStockUnitValue"
        Me.ColStockValueAtEndSelling.HeaderText = "Stock Value At End (Selling)"
        Me.ColStockValueAtEndSelling.Name = "ColStockValueAtEndSelling"
        Me.ColStockValueAtEndSelling.ReadOnly = True
        Me.ColStockValueAtEndSelling.Width = 170
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
        'colSystemIssued
        '
        Me.colSystemIssued.DataPropertyName = "TotalSystemIssued"
        Me.colSystemIssued.HeaderText = "System Issued"
        Me.colSystemIssued.Name = "colSystemIssued"
        Me.colSystemIssued.ReadOnly = True
        '
        'frmDrugInventorySummaries
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1074, 512)
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
        Me.Name = "frmDrugInventorySummaries"
        Me.Text = "Drug Inventory Summaries"
        Me.tbcPeriodicReport.ResumeLayout(False)
        Me.tpgDrugPeriodicInventory.ResumeLayout(False)
        CType(Me.dgvDrugPeriodicInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDrugInventorySummaries.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcPeriodicReport As System.Windows.Forms.TabControl
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgDrugPeriodicInventory As System.Windows.Forms.TabPage
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dgvDrugPeriodicInventory As System.Windows.Forms.DataGridView
    Friend WithEvents lblDrugNo As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cmsDrugInventorySummaries As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbDrugName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboDrugNo As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStockCostTotalValue As Label
    Friend WithEvents stbTotalStockCostValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalStockCostValue As Label
    Friend WithEvents stbTotalStockSellingValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVATValue As Label
    Friend WithEvents stbVATValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNetStockSellingValue As Label
    Friend WithEvents stbNetSellingValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsAtHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockCostValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockSellingValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStockValueAtStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStockValueAtStartCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStockValueAtEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStockValueAtEndSelling As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalIssued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpectedIssuedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalManualIssued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSystemIssued As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
