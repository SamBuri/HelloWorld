
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryTransfers : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal orderNo As String)
        MyClass.New()
        Me.defaultOrderNo = orderNo
    End Sub

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryTransfers))
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpTransferDate = New System.Windows.Forms.DateTimePicker()
        Me.cboFromLocationID = New System.Windows.Forms.ComboBox()
        Me.cboToLocationID = New System.Windows.Forms.ComboBox()
        Me.stbOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboOrderType = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbTransferNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTransferNo = New System.Windows.Forms.Label()
        Me.lblTransferDate = New System.Windows.Forms.Label()
        Me.lblFromLocationID = New System.Windows.Forms.Label()
        Me.lblToLocationID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.tbcInventoryTransfers = New System.Windows.Forms.TabControl()
        Me.tpgDrugs = New System.Windows.Forms.TabPage()
        Me.dgvDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFromLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugToLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDrugPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsInventoryTransfers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInventoryTransfersQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableFromLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableToLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumablePackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOtherItems = New System.Windows.Forms.TabPage()
        Me.dgvOtherItems = New System.Windows.Forms.DataGridView()
        Me.colOtherItemsItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsFromLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsToLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colOtherItemsPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.stbOrderDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.stbConsumableCost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblConsumableCost = New System.Windows.Forms.Label()
        Me.stbTotalcost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbDrugCost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrugCost = New System.Windows.Forms.Label()
        Me.lblOrderType = New System.Windows.Forms.Label()
        Me.fbnLoadOrders = New System.Windows.Forms.Button()
        Me.stbOtherItems = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOtherItemsCost = New System.Windows.Forms.Label()
        Me.cboTransferReasonID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbcInventoryTransfers.SuspendLayout()
        Me.tpgDrugs.SuspendLayout()
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInventoryTransfers.SuspendLayout()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOtherItems.SuspendLayout()
        CType(Me.dgvOtherItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrintOnSaving.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 402)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 13
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(960, 402)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 14
        Me.fbnDelete.Tag = "InventoryTransfers"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 429)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 15
        Me.ebnSaveUpdate.Tag = "InventoryTransfers"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpTransferDate
        '
        Me.dtpTransferDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTransferDate, "TransferDate")
        Me.dtpTransferDate.Location = New System.Drawing.Point(137, 29)
        Me.dtpTransferDate.Name = "dtpTransferDate"
        Me.dtpTransferDate.ShowCheckBox = True
        Me.dtpTransferDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpTransferDate.TabIndex = 3
        '
        'cboFromLocationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFromLocationID, "FromLocation,FromLocationID")
        Me.cboFromLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFromLocationID.Location = New System.Drawing.Point(461, 29)
        Me.cboFromLocationID.Name = "cboFromLocationID"
        Me.cboFromLocationID.Size = New System.Drawing.Size(180, 21)
        Me.cboFromLocationID.TabIndex = 7
        '
        'cboToLocationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboToLocationID, "ToLocation,ToLocationID")
        Me.cboToLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboToLocationID.Location = New System.Drawing.Point(461, 52)
        Me.cboToLocationID.Name = "cboToLocationID"
        Me.cboToLocationID.Size = New System.Drawing.Size(180, 21)
        Me.cboToLocationID.TabIndex = 9
        '
        'stbOrderNo
        '
        Me.stbOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderNo.CapitalizeFirstLetter = False
        Me.stbOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbOrderNo, "OrderNo")
        Me.stbOrderNo.EntryErrorMSG = ""
        Me.stbOrderNo.Location = New System.Drawing.Point(461, 5)
        Me.stbOrderNo.MaxLength = 20
        Me.stbOrderNo.Name = "stbOrderNo"
        Me.stbOrderNo.RegularExpression = ""
        Me.stbOrderNo.Size = New System.Drawing.Size(125, 20)
        Me.stbOrderNo.TabIndex = 11
        '
        'cboOrderType
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboOrderType, "OrderType,OrderTypeID")
        Me.cboOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderType.Enabled = False
        Me.cboOrderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOrderType.Location = New System.Drawing.Point(811, 91)
        Me.cboOrderType.Name = "cboOrderType"
        Me.cboOrderType.Size = New System.Drawing.Size(180, 21)
        Me.cboOrderType.TabIndex = 35
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(960, 429)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 18
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbTransferNo
        '
        Me.stbTransferNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferNo.CapitalizeFirstLetter = False
        Me.stbTransferNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbTransferNo.EntryErrorMSG = ""
        Me.stbTransferNo.Location = New System.Drawing.Point(137, 8)
        Me.stbTransferNo.MaxLength = 20
        Me.stbTransferNo.Name = "stbTransferNo"
        Me.stbTransferNo.RegularExpression = ""
        Me.stbTransferNo.Size = New System.Drawing.Size(128, 20)
        Me.stbTransferNo.TabIndex = 1
        '
        'lblTransferNo
        '
        Me.lblTransferNo.Location = New System.Drawing.Point(12, 9)
        Me.lblTransferNo.Name = "lblTransferNo"
        Me.lblTransferNo.Size = New System.Drawing.Size(119, 20)
        Me.lblTransferNo.TabIndex = 0
        Me.lblTransferNo.Text = "Transfer No"
        '
        'lblTransferDate
        '
        Me.lblTransferDate.Location = New System.Drawing.Point(12, 30)
        Me.lblTransferDate.Name = "lblTransferDate"
        Me.lblTransferDate.Size = New System.Drawing.Size(119, 20)
        Me.lblTransferDate.TabIndex = 2
        Me.lblTransferDate.Text = "Transfer Date"
        '
        'lblFromLocationID
        '
        Me.lblFromLocationID.Location = New System.Drawing.Point(336, 29)
        Me.lblFromLocationID.Name = "lblFromLocationID"
        Me.lblFromLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblFromLocationID.TabIndex = 6
        Me.lblFromLocationID.Text = "From Location"
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(336, 52)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblToLocationID.TabIndex = 8
        Me.lblToLocationID.Text = "To Location"
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
        'tbcInventoryTransfers
        '
        Me.tbcInventoryTransfers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcInventoryTransfers.Controls.Add(Me.tpgDrugs)
        Me.tbcInventoryTransfers.Controls.Add(Me.tpgConsumables)
        Me.tbcInventoryTransfers.Controls.Add(Me.tpgOtherItems)
        Me.tbcInventoryTransfers.HotTrack = True
        Me.tbcInventoryTransfers.Location = New System.Drawing.Point(12, 118)
        Me.tbcInventoryTransfers.Name = "tbcInventoryTransfers"
        Me.tbcInventoryTransfers.SelectedIndex = 0
        Me.tbcInventoryTransfers.Size = New System.Drawing.Size(1027, 278)
        Me.tbcInventoryTransfers.TabIndex = 12
        '
        'tpgDrugs
        '
        Me.tpgDrugs.Controls.Add(Me.dgvDrugs)
        Me.tpgDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgDrugs.Name = "tpgDrugs"
        Me.tpgDrugs.Size = New System.Drawing.Size(1019, 252)
        Me.tpgDrugs.TabIndex = 2
        Me.tpgDrugs.Tag = "DrugInventoryTransfers"
        Me.tpgDrugs.Text = "Drugs"
        Me.tpgDrugs.UseVisualStyleBackColor = True
        '
        'dgvDrugs
        '
        Me.dgvDrugs.AllowUserToOrderColumns = True
        Me.dgvDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugNo, Me.colDrugName, Me.colDrugFromLocationBalance, Me.colDrugToLocationBalance, Me.colDrugQuantity, Me.colDrugPack, Me.colDrugPackSize, Me.colDrugTotalUnits, Me.colDrugUnitCost, Me.colDrugTotalCost, Me.colDrugBatchNo, Me.colDrugExpiryDate, Me.colDrugStockStatus, Me.colDrugsSaved})
        Me.dgvDrugs.ContextMenuStrip = Me.cmsInventoryTransfers
        Me.dgvDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrugs.EnableHeadersVisualStyles = False
        Me.dgvDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrugs.Name = "dgvDrugs"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDrugs.Size = New System.Drawing.Size(1019, 252)
        Me.dgvDrugs.TabIndex = 0
        Me.dgvDrugs.Text = "DataGridView1"
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "ItemCode"
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.MaxInputLength = 20
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugNo.Width = 90
        '
        'colDrugName
        '
        Me.colDrugName.DataPropertyName = "ItemName"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugName.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.MaxInputLength = 100
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
        Me.colDrugName.Width = 120
        '
        'colDrugFromLocationBalance
        '
        Me.colDrugFromLocationBalance.DataPropertyName = "FromLocationBalance"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colDrugFromLocationBalance.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrugFromLocationBalance.HeaderText = "From Location Balance"
        Me.colDrugFromLocationBalance.MaxInputLength = 12
        Me.colDrugFromLocationBalance.Name = "colDrugFromLocationBalance"
        Me.colDrugFromLocationBalance.ReadOnly = True
        Me.colDrugFromLocationBalance.Width = 140
        '
        'colDrugToLocationBalance
        '
        Me.colDrugToLocationBalance.DataPropertyName = "ToLocationBalance"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colDrugToLocationBalance.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugToLocationBalance.HeaderText = "To Location Balance"
        Me.colDrugToLocationBalance.MaxInputLength = 12
        Me.colDrugToLocationBalance.Name = "colDrugToLocationBalance"
        Me.colDrugToLocationBalance.ReadOnly = True
        Me.colDrugToLocationBalance.Width = 120
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugPack
        '
        Me.colDrugPack.HeaderText = "Pack"
        Me.colDrugPack.Name = "colDrugPack"
        Me.colDrugPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colDrugPackSize
        '
        Me.colDrugPackSize.DataPropertyName = "PackSize"
        Me.colDrugPackSize.HeaderText = "PackSize"
        Me.colDrugPackSize.Name = "colDrugPackSize"
        '
        'colDrugTotalUnits
        '
        Me.colDrugTotalUnits.DataPropertyName = "TotalUnits"
        Me.colDrugTotalUnits.HeaderText = "Total Units"
        Me.colDrugTotalUnits.Name = "colDrugTotalUnits"
        Me.colDrugTotalUnits.ReadOnly = True
        '
        'colDrugUnitCost
        '
        Me.colDrugUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugUnitCost.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugUnitCost.HeaderText = "Unit Cost"
        Me.colDrugUnitCost.Name = "colDrugUnitCost"
        Me.colDrugUnitCost.ReadOnly = True
        '
        'colDrugTotalCost
        '
        Me.colDrugTotalCost.DataPropertyName = "TotalCost"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugTotalCost.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugTotalCost.HeaderText = "Total Cost"
        Me.colDrugTotalCost.Name = "colDrugTotalCost"
        Me.colDrugTotalCost.ReadOnly = True
        '
        'colDrugBatchNo
        '
        Me.colDrugBatchNo.DataPropertyName = "BatchNo"
        Me.colDrugBatchNo.HeaderText = "Batch No"
        Me.colDrugBatchNo.MaxInputLength = 20
        Me.colDrugBatchNo.Name = "colDrugBatchNo"
        '
        'colDrugExpiryDate
        '
        Me.colDrugExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle8.Format = "D"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colDrugExpiryDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDrugExpiryDate.HeaderText = "Expiry Date"
        Me.colDrugExpiryDate.Name = "colDrugExpiryDate"
        Me.colDrugExpiryDate.Width = 80
        '
        'colDrugStockStatus
        '
        Me.colDrugStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugStockStatus.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDrugStockStatus.HeaderText = "Stock Status"
        Me.colDrugStockStatus.Name = "colDrugStockStatus"
        Me.colDrugStockStatus.ReadOnly = True
        Me.colDrugStockStatus.Width = 80
        '
        'colDrugsSaved
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = False
        Me.colDrugsSaved.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugsSaved.HeaderText = "Saved"
        Me.colDrugsSaved.Name = "colDrugsSaved"
        Me.colDrugsSaved.ReadOnly = True
        Me.colDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugsSaved.Width = 50
        '
        'cmsInventoryTransfers
        '
        Me.cmsInventoryTransfers.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInventoryTransfers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInventoryTransfersQuickSearch})
        Me.cmsInventoryTransfers.Name = "cmsSearch"
        Me.cmsInventoryTransfers.Size = New System.Drawing.Size(144, 26)
        '
        'cmsInventoryTransfersQuickSearch
        '
        Me.cmsInventoryTransfersQuickSearch.Image = CType(resources.GetObject("cmsInventoryTransfersQuickSearch.Image"), System.Drawing.Image)
        Me.cmsInventoryTransfersQuickSearch.Name = "cmsInventoryTransfersQuickSearch"
        Me.cmsInventoryTransfersQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsInventoryTransfersQuickSearch.Text = "Quick Search"
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(1019, 252)
        Me.tpgConsumables.TabIndex = 12
        Me.tpgConsumables.Tag = "ConsumableInventoryTransfers"
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableNo, Me.colConsumableName, Me.colConsumableFromLocationBalance, Me.colConsumableToLocationBalance, Me.colConsumablePack, Me.colConsumablePackSize, Me.colConsumableQuantity, Me.colConsumableTotalUnits, Me.colConsumableUnitCost, Me.colConsumableTotalCost, Me.colConsumableBatchNo, Me.colConsumableExpiryDate, Me.colConsumableStockStatus, Me.colConsumablesSaved})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsInventoryTransfers
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvConsumables.Size = New System.Drawing.Size(1019, 252)
        Me.dgvConsumables.TabIndex = 44
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableNo
        '
        Me.colConsumableNo.DataPropertyName = "ItemCode"
        Me.colConsumableNo.HeaderText = "Consumable No"
        Me.colConsumableNo.MaxInputLength = 20
        Me.colConsumableNo.Name = "colConsumableNo"
        Me.colConsumableNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumableNo.Width = 90
        '
        'colConsumableName
        '
        Me.colConsumableName.DataPropertyName = "ItemName"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.MaxInputLength = 100
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Width = 120
        '
        'colConsumableFromLocationBalance
        '
        Me.colConsumableFromLocationBalance.DataPropertyName = "FromLocationBalance"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.Format = "N0"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.colConsumableFromLocationBalance.DefaultCellStyle = DataGridViewCellStyle14
        Me.colConsumableFromLocationBalance.HeaderText = "From Location Balance"
        Me.colConsumableFromLocationBalance.MaxInputLength = 12
        Me.colConsumableFromLocationBalance.Name = "colConsumableFromLocationBalance"
        Me.colConsumableFromLocationBalance.ReadOnly = True
        Me.colConsumableFromLocationBalance.Width = 140
        '
        'colConsumableToLocationBalance
        '
        Me.colConsumableToLocationBalance.DataPropertyName = "ToLocationBalance"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.Format = "N0"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colConsumableToLocationBalance.DefaultCellStyle = DataGridViewCellStyle15
        Me.colConsumableToLocationBalance.HeaderText = "To Location Balance"
        Me.colConsumableToLocationBalance.MaxInputLength = 12
        Me.colConsumableToLocationBalance.Name = "colConsumableToLocationBalance"
        Me.colConsumableToLocationBalance.ReadOnly = True
        Me.colConsumableToLocationBalance.Width = 120
        '
        'colConsumablePack
        '
        Me.colConsumablePack.HeaderText = "Pack"
        Me.colConsumablePack.Name = "colConsumablePack"
        Me.colConsumablePack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumablePack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colConsumablePackSize
        '
        Me.colConsumablePackSize.DataPropertyName = "PackSize"
        Me.colConsumablePackSize.HeaderText = "Pack Size"
        Me.colConsumablePackSize.Name = "colConsumablePackSize"
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 50
        '
        'colConsumableTotalUnits
        '
        Me.colConsumableTotalUnits.DataPropertyName = "TotalUnits"
        Me.colConsumableTotalUnits.HeaderText = "Total Units"
        Me.colConsumableTotalUnits.Name = "colConsumableTotalUnits"
        Me.colConsumableTotalUnits.ReadOnly = True
        '
        'colConsumableUnitCost
        '
        Me.colConsumableUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitCost.DefaultCellStyle = DataGridViewCellStyle17
        Me.colConsumableUnitCost.HeaderText = "Unit Cost"
        Me.colConsumableUnitCost.Name = "colConsumableUnitCost"
        Me.colConsumableUnitCost.ReadOnly = True
        '
        'colConsumableTotalCost
        '
        Me.colConsumableTotalCost.DataPropertyName = "TotalCost"
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableTotalCost.DefaultCellStyle = DataGridViewCellStyle18
        Me.colConsumableTotalCost.HeaderText = "Total Cost"
        Me.colConsumableTotalCost.Name = "colConsumableTotalCost"
        Me.colConsumableTotalCost.ReadOnly = True
        '
        'colConsumableBatchNo
        '
        Me.colConsumableBatchNo.DataPropertyName = "BatchNo"
        Me.colConsumableBatchNo.HeaderText = "Batch No"
        Me.colConsumableBatchNo.MaxInputLength = 20
        Me.colConsumableBatchNo.Name = "colConsumableBatchNo"
        '
        'colConsumableExpiryDate
        '
        Me.colConsumableExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle19.Format = "D"
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.NullValue = Nothing
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle19
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.MaxInputLength = 20
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.Width = 80
        '
        'colConsumableStockStatus
        '
        Me.colConsumableStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableStockStatus.DefaultCellStyle = DataGridViewCellStyle20
        Me.colConsumableStockStatus.HeaderText = "Stock Status"
        Me.colConsumableStockStatus.Name = "colConsumableStockStatus"
        Me.colConsumableStockStatus.ReadOnly = True
        Me.colConsumableStockStatus.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle21
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'tpgOtherItems
        '
        Me.tpgOtherItems.Controls.Add(Me.dgvOtherItems)
        Me.tpgOtherItems.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherItems.Name = "tpgOtherItems"
        Me.tpgOtherItems.Size = New System.Drawing.Size(1019, 252)
        Me.tpgOtherItems.TabIndex = 13
        Me.tpgOtherItems.Text = "Other Items"
        Me.tpgOtherItems.UseVisualStyleBackColor = True
        '
        'dgvOtherItems
        '
        Me.dgvOtherItems.AllowUserToOrderColumns = True
        Me.dgvOtherItems.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvOtherItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOtherItemsItemCode, Me.colOtherItemsItemName, Me.colOtherItemsFromLocationBalance, Me.colOtherItemsToLocationBalance, Me.colOtherItemsPack, Me.colOtherItemsPackSize, Me.colOtherItemsQuantity, Me.colOtherItemsTotalUnits, Me.colOtherItemsUnitCost, Me.colOtherItemsTotalCost, Me.colOtherItemsBatchNo, Me.colOtherItemsExpiryDate, Me.colOtherItemsStockStatus, Me.colOtherItemsSaved})
        Me.dgvOtherItems.ContextMenuStrip = Me.cmsInventoryTransfers
        Me.dgvOtherItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOtherItems.EnableHeadersVisualStyles = False
        Me.dgvOtherItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOtherItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvOtherItems.Name = "dgvOtherItems"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.dgvOtherItems.Size = New System.Drawing.Size(1019, 252)
        Me.dgvOtherItems.TabIndex = 45
        Me.dgvOtherItems.Text = "DataGridView1"
        '
        'colOtherItemsItemCode
        '
        Me.colOtherItemsItemCode.DataPropertyName = "ItemCode"
        Me.colOtherItemsItemCode.HeaderText = "Item Code"
        Me.colOtherItemsItemCode.MaxInputLength = 20
        Me.colOtherItemsItemCode.Name = "colOtherItemsItemCode"
        Me.colOtherItemsItemCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsItemCode.Width = 90
        '
        'colOtherItemsItemName
        '
        Me.colOtherItemsItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsItemName.DefaultCellStyle = DataGridViewCellStyle24
        Me.colOtherItemsItemName.HeaderText = "Item Name"
        Me.colOtherItemsItemName.MaxInputLength = 100
        Me.colOtherItemsItemName.Name = "colOtherItemsItemName"
        Me.colOtherItemsItemName.ReadOnly = True
        Me.colOtherItemsItemName.Width = 120
        '
        'colOtherItemsFromLocationBalance
        '
        Me.colOtherItemsFromLocationBalance.DataPropertyName = "FromLocationBalance"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle25.Format = "N0"
        DataGridViewCellStyle25.NullValue = Nothing
        Me.colOtherItemsFromLocationBalance.DefaultCellStyle = DataGridViewCellStyle25
        Me.colOtherItemsFromLocationBalance.HeaderText = "From Location Balance"
        Me.colOtherItemsFromLocationBalance.MaxInputLength = 12
        Me.colOtherItemsFromLocationBalance.Name = "colOtherItemsFromLocationBalance"
        Me.colOtherItemsFromLocationBalance.ReadOnly = True
        Me.colOtherItemsFromLocationBalance.Width = 140
        '
        'colOtherItemsToLocationBalance
        '
        Me.colOtherItemsToLocationBalance.DataPropertyName = "ToLocationBalance"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle26.Format = "N0"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.colOtherItemsToLocationBalance.DefaultCellStyle = DataGridViewCellStyle26
        Me.colOtherItemsToLocationBalance.HeaderText = "To Location Balance"
        Me.colOtherItemsToLocationBalance.MaxInputLength = 12
        Me.colOtherItemsToLocationBalance.Name = "colOtherItemsToLocationBalance"
        Me.colOtherItemsToLocationBalance.ReadOnly = True
        Me.colOtherItemsToLocationBalance.Width = 120
        '
        'colOtherItemsPack
        '
        Me.colOtherItemsPack.HeaderText = "Pack"
        Me.colOtherItemsPack.Name = "colOtherItemsPack"
        Me.colOtherItemsPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colOtherItemsPackSize
        '
        Me.colOtherItemsPackSize.DataPropertyName = "PackSize"
        Me.colOtherItemsPackSize.HeaderText = "Pack Size"
        Me.colOtherItemsPackSize.Name = "colOtherItemsPackSize"
        '
        'colOtherItemsQuantity
        '
        Me.colOtherItemsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N0"
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle27.NullValue = Nothing
        Me.colOtherItemsQuantity.DefaultCellStyle = DataGridViewCellStyle27
        Me.colOtherItemsQuantity.HeaderText = "Quantity"
        Me.colOtherItemsQuantity.MaxInputLength = 12
        Me.colOtherItemsQuantity.Name = "colOtherItemsQuantity"
        Me.colOtherItemsQuantity.Width = 50
        '
        'colOtherItemsTotalUnits
        '
        Me.colOtherItemsTotalUnits.DataPropertyName = "TotalUnits"
        Me.colOtherItemsTotalUnits.HeaderText = "Total Units"
        Me.colOtherItemsTotalUnits.Name = "colOtherItemsTotalUnits"
        Me.colOtherItemsTotalUnits.ReadOnly = True
        '
        'colOtherItemsUnitCost
        '
        Me.colOtherItemsUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsUnitCost.DefaultCellStyle = DataGridViewCellStyle28
        Me.colOtherItemsUnitCost.HeaderText = "Unit Cost"
        Me.colOtherItemsUnitCost.Name = "colOtherItemsUnitCost"
        Me.colOtherItemsUnitCost.ReadOnly = True
        '
        'colOtherItemsTotalCost
        '
        Me.colOtherItemsTotalCost.DataPropertyName = "TotalCost"
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsTotalCost.DefaultCellStyle = DataGridViewCellStyle29
        Me.colOtherItemsTotalCost.HeaderText = "Total Cost"
        Me.colOtherItemsTotalCost.Name = "colOtherItemsTotalCost"
        Me.colOtherItemsTotalCost.ReadOnly = True
        '
        'colOtherItemsBatchNo
        '
        Me.colOtherItemsBatchNo.DataPropertyName = "BatchNo"
        Me.colOtherItemsBatchNo.HeaderText = "Batch No"
        Me.colOtherItemsBatchNo.MaxInputLength = 20
        Me.colOtherItemsBatchNo.Name = "colOtherItemsBatchNo"
        '
        'colOtherItemsExpiryDate
        '
        Me.colOtherItemsExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle30.Format = "D"
        DataGridViewCellStyle30.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle30.NullValue = Nothing
        Me.colOtherItemsExpiryDate.DefaultCellStyle = DataGridViewCellStyle30
        Me.colOtherItemsExpiryDate.HeaderText = "Expiry Date"
        Me.colOtherItemsExpiryDate.MaxInputLength = 20
        Me.colOtherItemsExpiryDate.Name = "colOtherItemsExpiryDate"
        Me.colOtherItemsExpiryDate.Width = 80
        '
        'colOtherItemsStockStatus
        '
        Me.colOtherItemsStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsStockStatus.DefaultCellStyle = DataGridViewCellStyle31
        Me.colOtherItemsStockStatus.HeaderText = "Stock Status"
        Me.colOtherItemsStockStatus.Name = "colOtherItemsStockStatus"
        Me.colOtherItemsStockStatus.ReadOnly = True
        Me.colOtherItemsStockStatus.Width = 80
        '
        'colOtherItemsSaved
        '
        Me.colOtherItemsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle32.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle32.NullValue = False
        Me.colOtherItemsSaved.DefaultCellStyle = DataGridViewCellStyle32
        Me.colOtherItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemsSaved.HeaderText = "Saved"
        Me.colOtherItemsSaved.Name = "colOtherItemsSaved"
        Me.colOtherItemsSaved.ReadOnly = True
        Me.colOtherItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemsSaved.Width = 50
        '
        'lblOrderNo
        '
        Me.lblOrderNo.Location = New System.Drawing.Point(336, 6)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(119, 20)
        Me.lblOrderNo.TabIndex = 10
        Me.lblOrderNo.Text = "Order No"
        '
        'stbOrderDate
        '
        Me.stbOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderDate.CapitalizeFirstLetter = False
        Me.stbOrderDate.Enabled = False
        Me.stbOrderDate.EntryErrorMSG = ""
        Me.stbOrderDate.Location = New System.Drawing.Point(137, 51)
        Me.stbOrderDate.MaxLength = 30
        Me.stbOrderDate.Name = "stbOrderDate"
        Me.stbOrderDate.RegularExpression = ""
        Me.stbOrderDate.Size = New System.Drawing.Size(180, 20)
        Me.stbOrderDate.TabIndex = 5
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(12, 52)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(119, 20)
        Me.lblOrderDate.TabIndex = 4
        Me.lblOrderDate.Text = "Order Date"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(882, 429)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 17
        Me.btnPrint.Text = "&Print"
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(98, 429)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(191, 31)
        Me.pnlPrintOnSaving.TabIndex = 16
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
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(145, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print Transfer On Saving"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(271, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 19
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'stbConsumableCost
        '
        Me.stbConsumableCost.BackColor = System.Drawing.SystemColors.Info
        Me.stbConsumableCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumableCost.CapitalizeFirstLetter = False
        Me.stbConsumableCost.Enabled = False
        Me.stbConsumableCost.EntryErrorMSG = ""
        Me.stbConsumableCost.Location = New System.Drawing.Point(811, 25)
        Me.stbConsumableCost.MaxLength = 20
        Me.stbConsumableCost.Name = "stbConsumableCost"
        Me.stbConsumableCost.RegularExpression = ""
        Me.stbConsumableCost.Size = New System.Drawing.Size(180, 20)
        Me.stbConsumableCost.TabIndex = 33
        Me.stbConsumableCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConsumableCost
        '
        Me.lblConsumableCost.Location = New System.Drawing.Point(698, 26)
        Me.lblConsumableCost.Name = "lblConsumableCost"
        Me.lblConsumableCost.Size = New System.Drawing.Size(107, 18)
        Me.lblConsumableCost.TabIndex = 32
        Me.lblConsumableCost.Text = "Consumable Cost"
        '
        'stbTotalcost
        '
        Me.stbTotalcost.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalcost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalcost.CapitalizeFirstLetter = False
        Me.stbTotalcost.Enabled = False
        Me.stbTotalcost.EntryErrorMSG = ""
        Me.stbTotalcost.Location = New System.Drawing.Point(811, 68)
        Me.stbTotalcost.MaxLength = 20
        Me.stbTotalcost.Name = "stbTotalcost"
        Me.stbTotalcost.RegularExpression = ""
        Me.stbTotalcost.Size = New System.Drawing.Size(180, 20)
        Me.stbTotalcost.TabIndex = 31
        Me.stbTotalcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(698, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Total Cost"
        '
        'stbDrugCost
        '
        Me.stbDrugCost.BackColor = System.Drawing.SystemColors.Info
        Me.stbDrugCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrugCost.CapitalizeFirstLetter = False
        Me.stbDrugCost.Enabled = False
        Me.stbDrugCost.EntryErrorMSG = ""
        Me.stbDrugCost.Location = New System.Drawing.Point(811, 3)
        Me.stbDrugCost.MaxLength = 20
        Me.stbDrugCost.Name = "stbDrugCost"
        Me.stbDrugCost.RegularExpression = ""
        Me.stbDrugCost.Size = New System.Drawing.Size(180, 20)
        Me.stbDrugCost.TabIndex = 29
        Me.stbDrugCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDrugCost
        '
        Me.lblDrugCost.Location = New System.Drawing.Point(698, 6)
        Me.lblDrugCost.Name = "lblDrugCost"
        Me.lblDrugCost.Size = New System.Drawing.Size(107, 18)
        Me.lblDrugCost.TabIndex = 28
        Me.lblDrugCost.Text = "Drug Cost"
        '
        'lblOrderType
        '
        Me.lblOrderType.Location = New System.Drawing.Point(698, 92)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(107, 20)
        Me.lblOrderType.TabIndex = 34
        Me.lblOrderType.Text = "Order Type"
        '
        'fbnLoadOrders
        '
        Me.fbnLoadOrders.AccessibleDescription = ""
        Me.fbnLoadOrders.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoadOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoadOrders.Location = New System.Drawing.Point(592, 1)
        Me.fbnLoadOrders.Name = "fbnLoadOrders"
        Me.fbnLoadOrders.Size = New System.Drawing.Size(49, 24)
        Me.fbnLoadOrders.TabIndex = 36
        Me.fbnLoadOrders.Tag = ""
        Me.fbnLoadOrders.Text = "&Load"
        '
        'stbOtherItems
        '
        Me.stbOtherItems.BackColor = System.Drawing.SystemColors.Info
        Me.stbOtherItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherItems.CapitalizeFirstLetter = False
        Me.stbOtherItems.Enabled = False
        Me.stbOtherItems.EntryErrorMSG = ""
        Me.stbOtherItems.Location = New System.Drawing.Point(811, 46)
        Me.stbOtherItems.MaxLength = 20
        Me.stbOtherItems.Name = "stbOtherItems"
        Me.stbOtherItems.RegularExpression = ""
        Me.stbOtherItems.Size = New System.Drawing.Size(180, 20)
        Me.stbOtherItems.TabIndex = 38
        Me.stbOtherItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOtherItemsCost
        '
        Me.lblOtherItemsCost.Location = New System.Drawing.Point(698, 47)
        Me.lblOtherItemsCost.Name = "lblOtherItemsCost"
        Me.lblOtherItemsCost.Size = New System.Drawing.Size(107, 18)
        Me.lblOtherItemsCost.TabIndex = 37
        Me.lblOtherItemsCost.Text = "Other Items Cost"
        '
        'cboTransferReasonID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTransferReasonID, "TransferReason,TransferReasonID")
        Me.cboTransferReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransferReasonID.Enabled = False
        Me.cboTransferReasonID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTransferReasonID.Location = New System.Drawing.Point(461, 76)
        Me.cboTransferReasonID.Name = "cboTransferReasonID"
        Me.cboTransferReasonID.Size = New System.Drawing.Size(180, 21)
        Me.cboTransferReasonID.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(336, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 20)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Transfer Reason"
        '
        'frmInventoryTransfers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1044, 471)
        Me.Controls.Add(Me.cboTransferReasonID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.stbOtherItems)
        Me.Controls.Add(Me.lblOtherItemsCost)
        Me.Controls.Add(Me.fbnLoadOrders)
        Me.Controls.Add(Me.cboOrderType)
        Me.Controls.Add(Me.lblOrderType)
        Me.Controls.Add(Me.stbConsumableCost)
        Me.Controls.Add(Me.lblConsumableCost)
        Me.Controls.Add(Me.stbTotalcost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbDrugCost)
        Me.Controls.Add(Me.lblDrugCost)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.stbOrderDate)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.stbOrderNo)
        Me.Controls.Add(Me.lblOrderNo)
        Me.Controls.Add(Me.tbcInventoryTransfers)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbTransferNo)
        Me.Controls.Add(Me.lblTransferNo)
        Me.Controls.Add(Me.dtpTransferDate)
        Me.Controls.Add(Me.lblTransferDate)
        Me.Controls.Add(Me.cboFromLocationID)
        Me.Controls.Add(Me.lblFromLocationID)
        Me.Controls.Add(Me.cboToLocationID)
        Me.Controls.Add(Me.lblToLocationID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInventoryTransfers"
        Me.Text = "Inventory Transfers"
        Me.tbcInventoryTransfers.ResumeLayout(False)
        Me.tpgDrugs.ResumeLayout(False)
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInventoryTransfers.ResumeLayout(False)
        Me.tpgConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOtherItems.ResumeLayout(False)
        CType(Me.dgvOtherItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrintOnSaving.ResumeLayout(False)
        Me.pnlPrintOnSaving.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbTransferNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTransferNo As System.Windows.Forms.Label
    Friend WithEvents dtpTransferDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransferDate As System.Windows.Forms.Label
    Friend WithEvents cboFromLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFromLocationID As System.Windows.Forms.Label
    Friend WithEvents cboToLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents tbcInventoryTransfers As System.Windows.Forms.TabControl
    Friend WithEvents tpgDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents cmsInventoryTransfers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInventoryTransfersQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents stbOrderDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbConsumableCost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConsumableCost As Label
    Friend WithEvents stbTotalcost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents stbDrugCost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrugCost As Label
    Friend WithEvents cboOrderType As ComboBox
    Friend WithEvents lblOrderType As Label
    Friend WithEvents fbnLoadOrders As Button
    Friend WithEvents tpgOtherItems As System.Windows.Forms.TabPage
    Friend WithEvents dgvOtherItems As System.Windows.Forms.DataGridView
    Friend WithEvents stbOtherItems As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOtherItemsCost As System.Windows.Forms.Label
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFromLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugToLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDrugPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableFromLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableToLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumablePackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOtherItemsItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsFromLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsToLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOtherItemsPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboTransferReasonID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class