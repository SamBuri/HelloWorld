
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryAcknowledges : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryAcknowledges))
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpReceivedDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbTransferNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTransferNo = New System.Windows.Forms.Label()
        Me.lblReceivedDate = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.lblTransferDate = New System.Windows.Forms.Label()
        Me.lblFromLocationID = New System.Windows.Forms.Label()
        Me.lblToLocationID = New System.Windows.Forms.Label()
        Me.stbToLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFromLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTransferDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadIssuedInventoryTransfers = New System.Windows.Forms.Button()
        Me.dgvInventoryAcknowledges = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFromLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.sbtOrderType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInventoryOrderType = New System.Windows.Forms.Label()
        Me.lblPendingIventoryAcknowledgements = New System.Windows.Forms.Label()
        Me.cboFromLocationID = New System.Windows.Forms.ComboBox()
        Me.lblMyLocation = New System.Windows.Forms.Label()
        Me.stbTransferReason = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTransferReason = New System.Windows.Forms.Label()
        CType(Me.dgvInventoryAcknowledges,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPrintOnSaving.SuspendLayout
        Me.SuspendLayout
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(16, 399)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(72, 24)
        Me.fbnSave.TabIndex = 12
        Me.fbnSave.Tag = "InventoryAcknowledges"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = false
        '
        'dtpReceivedDate
        '
        Me.dtpReceivedDate.Checked = false
        Me.dtpReceivedDate.Location = New System.Drawing.Point(138, 47)
        Me.dtpReceivedDate.Name = "dtpReceivedDate"
        Me.dtpReceivedDate.ShowCheckBox = true
        Me.dtpReceivedDate.Size = New System.Drawing.Size(218, 20)
        Me.dtpReceivedDate.TabIndex = 6
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(826, 403)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 14
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbTransferNo
        '
        Me.stbTransferNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferNo.CapitalizeFirstLetter = False
        Me.stbTransferNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbTransferNo.EntryErrorMSG = ""
        Me.stbTransferNo.Location = New System.Drawing.Point(138, 5)
        Me.stbTransferNo.MaxLength = 20
        Me.stbTransferNo.Name = "stbTransferNo"
        Me.stbTransferNo.RegularExpression = ""
        Me.stbTransferNo.Size = New System.Drawing.Size(163, 20)
        Me.stbTransferNo.TabIndex = 1
        '
        'lblTransferNo
        '
        Me.lblTransferNo.Location = New System.Drawing.Point(13, 5)
        Me.lblTransferNo.Name = "lblTransferNo"
        Me.lblTransferNo.Size = New System.Drawing.Size(119, 20)
        Me.lblTransferNo.TabIndex = 0
        Me.lblTransferNo.Text = "Transfer No"
        '
        'lblReceivedDate
        '
        Me.lblReceivedDate.Location = New System.Drawing.Point(13, 47)
        Me.lblReceivedDate.Name = "lblReceivedDate"
        Me.lblReceivedDate.Size = New System.Drawing.Size(119, 20)
        Me.lblReceivedDate.TabIndex = 5
        Me.lblReceivedDate.Text = "Received Date"
        '
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = False
        Me.stbClientMachine.EntryErrorMSG = ""
        Me.stbClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.stbClientMachine.Name = "stbClientMachine"
        Me.stbClientMachine.RegularExpression = ""
        Me.stbClientMachine.Size = New System.Drawing.Size(100, 20)
        Me.stbClientMachine.TabIndex = 0
        '
        'lblClientMachine
        '
        Me.lblClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.lblClientMachine.Name = "lblClientMachine"
        Me.lblClientMachine.Size = New System.Drawing.Size(100, 23)
        Me.lblClientMachine.TabIndex = 0
        '
        'lblTransferDate
        '
        Me.lblTransferDate.Location = New System.Drawing.Point(13, 27)
        Me.lblTransferDate.Name = "lblTransferDate"
        Me.lblTransferDate.Size = New System.Drawing.Size(119, 20)
        Me.lblTransferDate.TabIndex = 3
        Me.lblTransferDate.Text = "Transfer Date"
        '
        'lblFromLocationID
        '
        Me.lblFromLocationID.Location = New System.Drawing.Point(648, 4)
        Me.lblFromLocationID.Name = "lblFromLocationID"
        Me.lblFromLocationID.Size = New System.Drawing.Size(97, 20)
        Me.lblFromLocationID.TabIndex = 7
        Me.lblFromLocationID.Text = "From Location"
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(648, 25)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(97, 20)
        Me.lblToLocationID.TabIndex = 9
        Me.lblToLocationID.Text = "To Location"
        '
        'stbToLocation
        '
        Me.stbToLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbToLocation.CapitalizeFirstLetter = False
        Me.stbToLocation.Enabled = False
        Me.stbToLocation.EntryErrorMSG = ""
        Me.stbToLocation.Location = New System.Drawing.Point(751, 26)
        Me.stbToLocation.MaxLength = 100
        Me.stbToLocation.Name = "stbToLocation"
        Me.stbToLocation.RegularExpression = ""
        Me.stbToLocation.Size = New System.Drawing.Size(147, 20)
        Me.stbToLocation.TabIndex = 10
        '
        'stbFromLocation
        '
        Me.stbFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFromLocation.CapitalizeFirstLetter = False
        Me.stbFromLocation.Enabled = False
        Me.stbFromLocation.EntryErrorMSG = ""
        Me.stbFromLocation.Location = New System.Drawing.Point(751, 5)
        Me.stbFromLocation.MaxLength = 100
        Me.stbFromLocation.Name = "stbFromLocation"
        Me.stbFromLocation.RegularExpression = ""
        Me.stbFromLocation.Size = New System.Drawing.Size(147, 20)
        Me.stbFromLocation.TabIndex = 8
        '
        'stbTransferDate
        '
        Me.stbTransferDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferDate.CapitalizeFirstLetter = False
        Me.stbTransferDate.Enabled = False
        Me.stbTransferDate.EntryErrorMSG = ""
        Me.stbTransferDate.Location = New System.Drawing.Point(138, 26)
        Me.stbTransferDate.MaxLength = 30
        Me.stbTransferDate.Name = "stbTransferDate"
        Me.stbTransferDate.RegularExpression = ""
        Me.stbTransferDate.Size = New System.Drawing.Size(218, 20)
        Me.stbTransferDate.TabIndex = 4
        '
        'btnLoadIssuedInventoryTransfers
        '
        Me.btnLoadIssuedInventoryTransfers.AccessibleDescription = ""
        Me.btnLoadIssuedInventoryTransfers.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadIssuedInventoryTransfers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadIssuedInventoryTransfers.Location = New System.Drawing.Point(307, 1)
        Me.btnLoadIssuedInventoryTransfers.Name = "btnLoadIssuedInventoryTransfers"
        Me.btnLoadIssuedInventoryTransfers.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadIssuedInventoryTransfers.TabIndex = 2
        Me.btnLoadIssuedInventoryTransfers.Tag = ""
        Me.btnLoadIssuedInventoryTransfers.Text = "&Load"
        '
        'dgvInventoryAcknowledges
        '
        Me.dgvInventoryAcknowledges.AllowUserToAddRows = False
        Me.dgvInventoryAcknowledges.AllowUserToDeleteRows = False
        Me.dgvInventoryAcknowledges.AllowUserToOrderColumns = True
        Me.dgvInventoryAcknowledges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryAcknowledges.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInventoryAcknowledges.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryAcknowledges.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryAcknowledges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colFromLocationBalance, Me.colToLocationBalance, Me.colPack, Me.colPackSize, Me.colQuantity, Me.colTotalUnits, Me.colUnitCost, Me.colTotalCost, Me.colBatchNo, Me.colExpiryDate, Me.colStockStatus, Me.colItemCategoryID})
        Me.dgvInventoryAcknowledges.EnableHeadersVisualStyles = False
        Me.dgvInventoryAcknowledges.GridColor = System.Drawing.Color.Khaki
        Me.dgvInventoryAcknowledges.Location = New System.Drawing.Point(13, 103)
        Me.dgvInventoryAcknowledges.Name = "dgvInventoryAcknowledges"
        Me.dgvInventoryAcknowledges.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryAcknowledges.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvInventoryAcknowledges.RowHeadersVisible = False
        Me.dgvInventoryAcknowledges.Size = New System.Drawing.Size(887, 290)
        Me.dgvInventoryAcknowledges.TabIndex = 11
        Me.dgvInventoryAcknowledges.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItemName.Width = 180
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 80
        '
        'colFromLocationBalance
        '
        Me.colFromLocationBalance.DataPropertyName = "FromLocationBalance"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colFromLocationBalance.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFromLocationBalance.HeaderText = "From Location Balance"
        Me.colFromLocationBalance.MaxInputLength = 12
        Me.colFromLocationBalance.Name = "colFromLocationBalance"
        Me.colFromLocationBalance.ReadOnly = True
        Me.colFromLocationBalance.Width = 140
        '
        'colToLocationBalance
        '
        Me.colToLocationBalance.DataPropertyName = "ToLocationBalance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colToLocationBalance.DefaultCellStyle = DataGridViewCellStyle6
        Me.colToLocationBalance.HeaderText = "To Location Balance"
        Me.colToLocationBalance.MaxInputLength = 12
        Me.colToLocationBalance.Name = "colToLocationBalance"
        Me.colToLocationBalance.ReadOnly = True
        Me.colToLocationBalance.Width = 120
        '
        'colPack
        '
        Me.colPack.DataPropertyName = "Pack"
        Me.colPack.HeaderText = "Pack"
        Me.colPack.Name = "colPack"
        Me.colPack.ReadOnly = True
        '
        'colPackSize
        '
        Me.colPackSize.DataPropertyName = "PackSize"
        Me.colPackSize.HeaderText = "Pack Size"
        Me.colPackSize.Name = "colPackSize"
        Me.colPackSize.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colTotalUnits
        '
        Me.colTotalUnits.DataPropertyName = "TotalUnits"
        Me.colTotalUnits.HeaderText = "Total Units"
        Me.colTotalUnits.Name = "colTotalUnits"
        Me.colTotalUnits.ReadOnly = True
        '
        'colUnitCost
        '
        Me.colUnitCost.DataPropertyName = "UnitCost"
        Me.colUnitCost.HeaderText = "Unit Cost"
        Me.colUnitCost.Name = "colUnitCost"
        Me.colUnitCost.ReadOnly = True
        '
        'colTotalCost
        '
        Me.colTotalCost.DataPropertyName = "TotalCost"
        Me.colTotalCost.HeaderText = "Total Cost"
        Me.colTotalCost.Name = "colTotalCost"
        Me.colTotalCost.ReadOnly = True
        '
        'colBatchNo
        '
        Me.colBatchNo.DataPropertyName = "BatchNo"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colBatchNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.MaxInputLength = 20
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        Me.colBatchNo.Width = 80
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "D"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        '
        'colStockStatus
        '
        Me.colStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colStockStatus.DefaultCellStyle = DataGridViewCellStyle10
        Me.colStockStatus.HeaderText = "Stock Status"
        Me.colStockStatus.Name = "colStockStatus"
        Me.colStockStatus.ReadOnly = True
        Me.colStockStatus.Width = 80
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle11
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(94, 399)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(224, 31)
        Me.pnlPrintOnSaving.TabIndex = 13
        '
        'chkPrintOnSaving
        '
        Me.chkPrintOnSaving.AccessibleDescription = ""
        Me.chkPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintOnSaving.AutoSize = True
        Me.chkPrintOnSaving.Checked = True
        Me.chkPrintOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintOnSaving.Location = New System.Drawing.Point(12, 3)
        Me.chkPrintOnSaving.Name = "chkPrintOnSaving"
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(171, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print Acknowledge On Saving"
        '
        'sbtOrderType
        '
        Me.sbtOrderType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sbtOrderType.CapitalizeFirstLetter = False
        Me.sbtOrderType.Enabled = False
        Me.sbtOrderType.EntryErrorMSG = ""
        Me.sbtOrderType.Location = New System.Drawing.Point(481, 27)
        Me.sbtOrderType.MaxLength = 100
        Me.sbtOrderType.Name = "sbtOrderType"
        Me.sbtOrderType.RegularExpression = ""
        Me.sbtOrderType.Size = New System.Drawing.Size(161, 20)
        Me.sbtOrderType.TabIndex = 16
        '
        'lblInventoryOrderType
        '
        Me.lblInventoryOrderType.Location = New System.Drawing.Point(365, 28)
        Me.lblInventoryOrderType.Name = "lblInventoryOrderType"
        Me.lblInventoryOrderType.Size = New System.Drawing.Size(111, 20)
        Me.lblInventoryOrderType.TabIndex = 15
        Me.lblInventoryOrderType.Text = "Order Type"
        '
        'lblPendingIventoryAcknowledgements
        '
        Me.lblPendingIventoryAcknowledgements.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingIventoryAcknowledgements.ForeColor = System.Drawing.Color.Red
        Me.lblPendingIventoryAcknowledgements.Location = New System.Drawing.Point(14, 76)
        Me.lblPendingIventoryAcknowledgements.Name = "lblPendingIventoryAcknowledgements"
        Me.lblPendingIventoryAcknowledgements.Size = New System.Drawing.Size(270, 20)
        Me.lblPendingIventoryAcknowledgements.TabIndex = 17
        Me.lblPendingIventoryAcknowledgements.Text = "Pending Acknowledgements: 0"
        '
        'cboFromLocationID
        '
        Me.cboFromLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFromLocationID.Location = New System.Drawing.Point(481, 4)
        Me.cboFromLocationID.Name = "cboFromLocationID"
        Me.cboFromLocationID.Size = New System.Drawing.Size(161, 21)
        Me.cboFromLocationID.TabIndex = 20
        '
        'lblMyLocation
        '
        Me.lblMyLocation.Location = New System.Drawing.Point(365, 5)
        Me.lblMyLocation.Name = "lblMyLocation"
        Me.lblMyLocation.Size = New System.Drawing.Size(111, 20)
        Me.lblMyLocation.TabIndex = 19
        Me.lblMyLocation.Text = "My Location"
        '
        'stbTransferReason
        '
        Me.stbTransferReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferReason.CapitalizeFirstLetter = False
        Me.stbTransferReason.Enabled = False
        Me.stbTransferReason.EntryErrorMSG = ""
        Me.stbTransferReason.Location = New System.Drawing.Point(481, 49)
        Me.stbTransferReason.MaxLength = 100
        Me.stbTransferReason.Name = "stbTransferReason"
        Me.stbTransferReason.RegularExpression = ""
        Me.stbTransferReason.Size = New System.Drawing.Size(161, 20)
        Me.stbTransferReason.TabIndex = 22
        '
        'lblTransferReason
        '
        Me.lblTransferReason.Location = New System.Drawing.Point(365, 50)
        Me.lblTransferReason.Name = "lblTransferReason"
        Me.lblTransferReason.Size = New System.Drawing.Size(111, 20)
        Me.lblTransferReason.TabIndex = 21
        Me.lblTransferReason.Text = "Transfer Reason"
        '
        'frmInventoryAcknowledges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(912, 439)
        Me.Controls.Add(Me.stbTransferReason)
        Me.Controls.Add(Me.lblTransferReason)
        Me.Controls.Add(Me.cboFromLocationID)
        Me.Controls.Add(Me.lblMyLocation)
        Me.Controls.Add(Me.lblPendingIventoryAcknowledgements)
        Me.Controls.Add(Me.sbtOrderType)
        Me.Controls.Add(Me.lblInventoryOrderType)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.dgvInventoryAcknowledges)
        Me.Controls.Add(Me.btnLoadIssuedInventoryTransfers)
        Me.Controls.Add(Me.stbTransferDate)
        Me.Controls.Add(Me.stbFromLocation)
        Me.Controls.Add(Me.stbToLocation)
        Me.Controls.Add(Me.lblTransferDate)
        Me.Controls.Add(Me.lblFromLocationID)
        Me.Controls.Add(Me.lblToLocationID)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbTransferNo)
        Me.Controls.Add(Me.lblTransferNo)
        Me.Controls.Add(Me.dtpReceivedDate)
        Me.Controls.Add(Me.lblReceivedDate)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmInventoryAcknowledges"
        Me.Text = "Inventory Acknowledges"
        CType(Me.dgvInventoryAcknowledges,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPrintOnSaving.ResumeLayout(false)
        Me.pnlPrintOnSaving.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbTransferNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTransferNo As System.Windows.Forms.Label
    Friend WithEvents dtpReceivedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents lblTransferDate As System.Windows.Forms.Label
    Friend WithEvents lblFromLocationID As System.Windows.Forms.Label
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents stbToLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFromLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTransferDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadIssuedInventoryTransfers As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryAcknowledges As System.Windows.Forms.DataGridView
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents colInclude As DataGridViewCheckBoxColumn
    Friend WithEvents colItemCode As DataGridViewTextBoxColumn
    Friend WithEvents colItemName As DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As DataGridViewTextBoxColumn
    Friend WithEvents colFromLocationBalance As DataGridViewTextBoxColumn
    Friend WithEvents colToLocationBalance As DataGridViewTextBoxColumn
    Friend WithEvents colPack As DataGridViewTextBoxColumn
    Friend WithEvents colPackSize As DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colTotalUnits As DataGridViewTextBoxColumn
    Friend WithEvents colUnitCost As DataGridViewTextBoxColumn
    Friend WithEvents colTotalCost As DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As DataGridViewTextBoxColumn
    Friend WithEvents colStockStatus As DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As DataGridViewTextBoxColumn
    Friend WithEvents sbtOrderType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInventoryOrderType As Label
    Friend WithEvents lblPendingIventoryAcknowledgements As System.Windows.Forms.Label
    Friend WithEvents cboFromLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMyLocation As System.Windows.Forms.Label
    Friend WithEvents stbTransferReason As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTransferReason As System.Windows.Forms.Label
End Class