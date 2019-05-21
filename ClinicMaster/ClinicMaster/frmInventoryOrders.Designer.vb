
Imports System.Collections.Generic

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryOrders : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal itemCategoryID As String, ByVal itemsList As List(Of String))

        MyClass.New()
        Me.defaultItemCategoryID = itemCategoryID
        Me.defaultItemsList = itemsList

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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryOrders))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.cboFromLocationID = New System.Windows.Forms.ComboBox()
        Me.cboToLocationID = New System.Windows.Forms.ComboBox()
        Me.cboOrderType = New System.Windows.Forms.ComboBox()
        Me.cboTransferReasonID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.lblFromLocationID = New System.Windows.Forms.Label()
        Me.lblToLocationID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.tbcInventoryOrders = New System.Windows.Forms.TabControl()
        Me.tpgDrugs = New System.Windows.Forms.TabPage()
        Me.dgvDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDrugPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsInventoryOrders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInventoryOrdersQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePack = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colConsumablePackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableTotalUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOtherItems = New System.Windows.Forms.TabPage()
        Me.dgvOtherItems = New System.Windows.Forms.DataGridView()
        Me.ColOtherItemsSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColOtherItemsItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsPack = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.ColOtherItemsPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsTotalCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnViewToExpireDrugsList = New System.Windows.Forms.Button()
        Me.lblToExpireDrugs = New System.Windows.Forms.Label()
        Me.btnViewToOrderDrugsList = New System.Windows.Forms.Button()
        Me.lblToOrderDrugs = New System.Windows.Forms.Label()
        Me.lblOrderType = New System.Windows.Forms.Label()
        Me.stbDrugCost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrugCost = New System.Windows.Forms.Label()
        Me.stbTotalcost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbConsumableCost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblConsumableCost = New System.Windows.Forms.Label()
        Me.btnPendingIventoryAcknowledgements = New System.Windows.Forms.Button()
        Me.lblPendingIventoryAcknowledgements = New System.Windows.Forms.Label()
        Me.stbOtherItemsCost = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOtherItemscost = New System.Windows.Forms.Label()
        Me.lblTransferReasonID = New System.Windows.Forms.Label()
        Me.tbcInventoryOrders.SuspendLayout
        Me.tpgDrugs.SuspendLayout
        CType(Me.dgvDrugs,System.ComponentModel.ISupportInitialize).BeginInit
        Me.cmsInventoryOrders.SuspendLayout
        Me.tpgConsumables.SuspendLayout
        CType(Me.dgvConsumables,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tpgOtherItems.SuspendLayout
        CType(Me.dgvOtherItems,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlPrintOnSaving.SuspendLayout
        Me.SuspendLayout
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 409)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 26
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = true
        Me.fbnSearch.Visible = false
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(882, 408)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 30
        Me.fbnDelete.Tag = "InventoryOrders"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = false
        Me.fbnDelete.Visible = false
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 436)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 27
        Me.ebnSaveUpdate.Tag = "InventoryOrders"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = false
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Checked = false
        Me.ebnSaveUpdate.SetDataMember(Me.dtpOrderDate, "OrderDate")
        Me.dtpOrderDate.Location = New System.Drawing.Point(104, 27)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.ShowCheckBox = true
        Me.dtpOrderDate.Size = New System.Drawing.Size(243, 20)
        Me.dtpOrderDate.TabIndex = 4
        '
        'cboFromLocationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFromLocationID, "FromLocation,FromLocationID")
        Me.cboFromLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFromLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFromLocationID.Location = New System.Drawing.Point(478, 5)
        Me.cboFromLocationID.Name = "cboFromLocationID"
        Me.cboFromLocationID.Size = New System.Drawing.Size(161, 21)
        Me.cboFromLocationID.TabIndex = 6
        '
        'cboToLocationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboToLocationID, "ToLocation,ToLocationID")
        Me.cboToLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboToLocationID.Location = New System.Drawing.Point(478, 29)
        Me.cboToLocationID.Name = "cboToLocationID"
        Me.cboToLocationID.Size = New System.Drawing.Size(161, 21)
        Me.cboToLocationID.TabIndex = 8
        '
        'cboOrderType
        '
        Me.cboOrderType.BackColor = System.Drawing.SystemColors.Control
        Me.ebnSaveUpdate.SetDataMember(Me.cboOrderType, "OrderType,OrderTypeID")
        Me.cboOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderType.Enabled = false
        Me.cboOrderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOrderType.Location = New System.Drawing.Point(772, 94)
        Me.cboOrderType.Name = "cboOrderType"
        Me.cboOrderType.Size = New System.Drawing.Size(180, 21)
        Me.cboOrderType.TabIndex = 18
        '
        'cboTransferReasonID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTransferReasonID, "TransferReason,TransferReasonID")
        Me.cboTransferReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransferReasonID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTransferReasonID.Location = New System.Drawing.Point(478, 53)
        Me.cboTransferReasonID.Name = "cboTransferReasonID"
        Me.cboTransferReasonID.Size = New System.Drawing.Size(161, 21)
        Me.cboTransferReasonID.TabIndex = 33
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(882, 435)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 31
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = false
        '
        'stbOrderNo
        '
        Me.stbOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderNo.CapitalizeFirstLetter = false
        Me.stbOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbOrderNo.EntryErrorMSG = ""
        Me.stbOrderNo.Location = New System.Drawing.Point(104, 4)
        Me.stbOrderNo.MaxLength = 20
        Me.stbOrderNo.Name = "stbOrderNo"
        Me.stbOrderNo.RegularExpression = ""
        Me.stbOrderNo.Size = New System.Drawing.Size(191, 20)
        Me.stbOrderNo.TabIndex = 1
        '
        'lblOrderNo
        '
        Me.lblOrderNo.Location = New System.Drawing.Point(12, 5)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(96, 20)
        Me.lblOrderNo.TabIndex = 0
        Me.lblOrderNo.Text = "Order No"
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(12, 32)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(96, 20)
        Me.lblOrderDate.TabIndex = 3
        Me.lblOrderDate.Text = "Order Date"
        '
        'lblFromLocationID
        '
        Me.lblFromLocationID.Location = New System.Drawing.Point(353, 7)
        Me.lblFromLocationID.Name = "lblFromLocationID"
        Me.lblFromLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblFromLocationID.TabIndex = 5
        Me.lblFromLocationID.Text = "Order From Location"
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(353, 33)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblToLocationID.TabIndex = 7
        Me.lblToLocationID.Text = "Order To Location"
        '
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = false
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
        'tbcInventoryOrders
        '
        Me.tbcInventoryOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tbcInventoryOrders.Controls.Add(Me.tpgDrugs)
        Me.tbcInventoryOrders.Controls.Add(Me.tpgConsumables)
        Me.tbcInventoryOrders.Controls.Add(Me.tpgOtherItems)
        Me.tbcInventoryOrders.HotTrack = true
        Me.tbcInventoryOrders.Location = New System.Drawing.Point(15, 121)
        Me.tbcInventoryOrders.Name = "tbcInventoryOrders"
        Me.tbcInventoryOrders.SelectedIndex = 0
        Me.tbcInventoryOrders.Size = New System.Drawing.Size(944, 282)
        Me.tbcInventoryOrders.TabIndex = 25
        '
        'tpgDrugs
        '
        Me.tpgDrugs.Controls.Add(Me.dgvDrugs)
        Me.tpgDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgDrugs.Name = "tpgDrugs"
        Me.tpgDrugs.Size = New System.Drawing.Size(936, 256)
        Me.tpgDrugs.TabIndex = 2
        Me.tpgDrugs.Tag = "DrugInventoryOrders"
        Me.tpgDrugs.Text = "Drugs"
        Me.tpgDrugs.UseVisualStyleBackColor = true
        '
        'dgvDrugs
        '
        Me.dgvDrugs.AllowUserToOrderColumns = true
        Me.dgvDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugSelect, Me.colDrugNo, Me.colDrugName, Me.colDrugLocationBalance, Me.colDrugItemStatus, Me.colDrugPack, Me.colDrugPackSize, Me.colDrugQuantity, Me.colDrugTotalUnits, Me.colDrugUnitCost, Me.colDrugTotalCost, Me.colDrugsSaved})
        Me.dgvDrugs.ContextMenuStrip = Me.cmsInventoryOrders
        Me.dgvDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrugs.EnableHeadersVisualStyles = false
        Me.dgvDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrugs.Name = "dgvDrugs"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDrugs.Size = New System.Drawing.Size(936, 256)
        Me.dgvDrugs.TabIndex = 0
        Me.dgvDrugs.Text = "DataGridView1"
        '
        'colDrugSelect
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colDrugSelect.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugSelect.HeaderText = "Select"
        Me.colDrugSelect.Name = "colDrugSelect"
        Me.colDrugSelect.ReadOnly = true
        Me.colDrugSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugSelect.Text = "•••"
        Me.colDrugSelect.UseColumnTextForButtonValue = true
        Me.colDrugSelect.Width = 50
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
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.MaxInputLength = 100
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = true
        Me.colDrugName.Width = 160
        '
        'colDrugLocationBalance
        '
        Me.colDrugLocationBalance.DataPropertyName = "LocationBalance"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugLocationBalance.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugLocationBalance.HeaderText = "From Location Balance"
        Me.colDrugLocationBalance.MaxInputLength = 12
        Me.colDrugLocationBalance.Name = "colDrugLocationBalance"
        Me.colDrugLocationBalance.ReadOnly = true
        Me.colDrugLocationBalance.Width = 150
        '
        'colDrugItemStatus
        '
        Me.colDrugItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugItemStatus.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDrugItemStatus.HeaderText = "Item Status"
        Me.colDrugItemStatus.Name = "colDrugItemStatus"
        Me.colDrugItemStatus.ReadOnly = true
        Me.colDrugItemStatus.Width = 70
        '
        'colDrugPack
        '
        Me.colDrugPack.HeaderText = "Pack"
        Me.colDrugPack.Name = "colDrugPack"
        Me.colDrugPack.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colDrugPackSize
        '
        Me.colDrugPackSize.DataPropertyName = "PackSize"
        Me.colDrugPackSize.HeaderText = "Pack Size"
        Me.colDrugPackSize.Name = "colDrugPackSize"
        Me.colDrugPackSize.Width = 80
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 80
        '
        'colDrugTotalUnits
        '
        Me.colDrugTotalUnits.DataPropertyName = "TotalUnits"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugTotalUnits.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugTotalUnits.HeaderText = "Total Units"
        Me.colDrugTotalUnits.Name = "colDrugTotalUnits"
        Me.colDrugTotalUnits.ReadOnly = true
        Me.colDrugTotalUnits.Width = 80
        '
        'colDrugUnitCost
        '
        Me.colDrugUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugUnitCost.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDrugUnitCost.HeaderText = "Unit Cost"
        Me.colDrugUnitCost.Name = "colDrugUnitCost"
        Me.colDrugUnitCost.ReadOnly = true
        Me.colDrugUnitCost.Width = 80
        '
        'colDrugTotalCost
        '
        Me.colDrugTotalCost.DataPropertyName = "TotalCost"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugTotalCost.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDrugTotalCost.HeaderText = "Total Cost"
        Me.colDrugTotalCost.Name = "colDrugTotalCost"
        Me.colDrugTotalCost.ReadOnly = true
        '
        'colDrugsSaved
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = false
        Me.colDrugsSaved.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugsSaved.HeaderText = "Saved"
        Me.colDrugsSaved.Name = "colDrugsSaved"
        Me.colDrugsSaved.ReadOnly = true
        Me.colDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugsSaved.Width = 50
        '
        'cmsInventoryOrders
        '
        Me.cmsInventoryOrders.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInventoryOrders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInventoryOrdersQuickSearch})
        Me.cmsInventoryOrders.Name = "cmsSearch"
        Me.cmsInventoryOrders.Size = New System.Drawing.Size(144, 26)
        '
        'cmsInventoryOrdersQuickSearch
        '
        Me.cmsInventoryOrdersQuickSearch.Name = "cmsInventoryOrdersQuickSearch"
        Me.cmsInventoryOrdersQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsInventoryOrdersQuickSearch.Text = "Quick Search"
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(936, 256)
        Me.tpgConsumables.TabIndex = 12
        Me.tpgConsumables.Tag = "ConsumableInventoryOrders"
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = true
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = true
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableSelect, Me.colConsumableNo, Me.colConsumableName, Me.colConsumableLocationBalance, Me.colConsumableItemStatus, Me.colConsumablePack, Me.colConsumablePackSize, Me.colConsumableQuantity, Me.colConsumableTotalUnit, Me.colConsumableUnitCost, Me.colConsumableTotalCost, Me.colConsumablesSaved})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsInventoryOrders
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = false
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvConsumables.Size = New System.Drawing.Size(936, 256)
        Me.dgvConsumables.TabIndex = 44
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableSelect
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colConsumableSelect.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableSelect.HeaderText = "Select"
        Me.colConsumableSelect.Name = "colConsumableSelect"
        Me.colConsumableSelect.ReadOnly = true
        Me.colConsumableSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumableSelect.Text = "•••"
        Me.colConsumableSelect.UseColumnTextForButtonValue = true
        Me.colConsumableSelect.Width = 50
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
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle14
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.MaxInputLength = 100
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = true
        Me.colConsumableName.Width = 160
        '
        'colConsumableLocationBalance
        '
        Me.colConsumableLocationBalance.DataPropertyName = "LocationBalance"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableLocationBalance.DefaultCellStyle = DataGridViewCellStyle15
        Me.colConsumableLocationBalance.HeaderText = "Location Balance"
        Me.colConsumableLocationBalance.MaxInputLength = 12
        Me.colConsumableLocationBalance.Name = "colConsumableLocationBalance"
        Me.colConsumableLocationBalance.ReadOnly = true
        '
        'colConsumableItemStatus
        '
        Me.colConsumableItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableItemStatus.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumableItemStatus.HeaderText = "Item Status"
        Me.colConsumableItemStatus.Name = "colConsumableItemStatus"
        Me.colConsumableItemStatus.ReadOnly = true
        Me.colConsumableItemStatus.Width = 70
        '
        'colConsumablePack
        '
        Me.colConsumablePack.ControlCaption = Nothing
        Me.colConsumablePack.DisplayStyleForCurrentCellOnly = true
        Me.colConsumablePack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablePack.HeaderText = "Pack"
        Me.colConsumablePack.Name = "colConsumablePack"
        Me.colConsumablePack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumablePack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumablePack.SourceColumn = Nothing
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
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle17
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 80
        '
        'colConsumableTotalUnit
        '
        Me.colConsumableTotalUnit.DataPropertyName = "TotalUnits"
        Me.colConsumableTotalUnit.HeaderText = "Total Units"
        Me.colConsumableTotalUnit.Name = "colConsumableTotalUnit"
        '
        'colConsumableUnitCost
        '
        Me.colConsumableUnitCost.DataPropertyName = "UnitCost"
        Me.colConsumableUnitCost.HeaderText = "Unit Cost"
        Me.colConsumableUnitCost.Name = "colConsumableUnitCost"
        '
        'colConsumableTotalCost
        '
        Me.colConsumableTotalCost.DataPropertyName = "TotalCost"
        Me.colConsumableTotalCost.HeaderText = "Total Cost"
        Me.colConsumableTotalCost.Name = "colConsumableTotalCost"
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.NullValue = false
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle18
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = true
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'tpgOtherItems
        '
        Me.tpgOtherItems.Controls.Add(Me.dgvOtherItems)
        Me.tpgOtherItems.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherItems.Name = "tpgOtherItems"
        Me.tpgOtherItems.Size = New System.Drawing.Size(936, 256)
        Me.tpgOtherItems.TabIndex = 13
        Me.tpgOtherItems.Tag = "OtherItems"
        Me.tpgOtherItems.Text = "Non Medical Items"
        Me.tpgOtherItems.UseVisualStyleBackColor = true
        '
        'dgvOtherItems
        '
        Me.dgvOtherItems.AllowUserToOrderColumns = true
        Me.dgvOtherItems.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvOtherItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColOtherItemsSelect, Me.ColOtherItemsItemCode, Me.ColOtherItemsName, Me.ColOtherItemsLocationBalance, Me.ColOtherItemsItemStatus, Me.ColOtherItemsPack, Me.ColOtherItemsPackSize, Me.ColOtherItemsQuantity, Me.ColOtherItemsTotalUnits, Me.ColOtherItemsUnitCost, Me.ColOtherItemsTotalCost, Me.colOtherItemsSaved})
        Me.dgvOtherItems.ContextMenuStrip = Me.cmsInventoryOrders
        Me.dgvOtherItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOtherItems.EnableHeadersVisualStyles = false
        Me.dgvOtherItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOtherItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvOtherItems.Name = "dgvOtherItems"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvOtherItems.Size = New System.Drawing.Size(936, 256)
        Me.dgvOtherItems.TabIndex = 0
        Me.dgvOtherItems.Text = "DataGridView1"
        '
        'ColOtherItemsSelect
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.ColOtherItemsSelect.DefaultCellStyle = DataGridViewCellStyle21
        Me.ColOtherItemsSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColOtherItemsSelect.HeaderText = "Select"
        Me.ColOtherItemsSelect.Name = "ColOtherItemsSelect"
        Me.ColOtherItemsSelect.ReadOnly = true
        Me.ColOtherItemsSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColOtherItemsSelect.Text = "•••"
        Me.ColOtherItemsSelect.UseColumnTextForButtonValue = true
        Me.ColOtherItemsSelect.Width = 50
        '
        'ColOtherItemsItemCode
        '
        Me.ColOtherItemsItemCode.DataPropertyName = "ItemCode"
        Me.ColOtherItemsItemCode.HeaderText = "Item Code"
        Me.ColOtherItemsItemCode.MaxInputLength = 20
        Me.ColOtherItemsItemCode.Name = "ColOtherItemsItemCode"
        Me.ColOtherItemsItemCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColOtherItemsItemCode.Width = 90
        '
        'ColOtherItemsName
        '
        Me.ColOtherItemsName.DataPropertyName = "ItemName"
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.ColOtherItemsName.DefaultCellStyle = DataGridViewCellStyle22
        Me.ColOtherItemsName.HeaderText = "Item Name"
        Me.ColOtherItemsName.MaxInputLength = 100
        Me.ColOtherItemsName.Name = "ColOtherItemsName"
        Me.ColOtherItemsName.ReadOnly = true
        Me.ColOtherItemsName.Width = 160
        '
        'ColOtherItemsLocationBalance
        '
        Me.ColOtherItemsLocationBalance.DataPropertyName = "LocationBalance"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.ColOtherItemsLocationBalance.DefaultCellStyle = DataGridViewCellStyle23
        Me.ColOtherItemsLocationBalance.HeaderText = "Location Balance"
        Me.ColOtherItemsLocationBalance.MaxInputLength = 12
        Me.ColOtherItemsLocationBalance.Name = "ColOtherItemsLocationBalance"
        Me.ColOtherItemsLocationBalance.ReadOnly = true
        '
        'ColOtherItemsItemStatus
        '
        Me.ColOtherItemsItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.ColOtherItemsItemStatus.DefaultCellStyle = DataGridViewCellStyle24
        Me.ColOtherItemsItemStatus.HeaderText = "Item Status"
        Me.ColOtherItemsItemStatus.Name = "ColOtherItemsItemStatus"
        Me.ColOtherItemsItemStatus.ReadOnly = true
        Me.ColOtherItemsItemStatus.Width = 70
        '
        'ColOtherItemsPack
        '
        Me.ColOtherItemsPack.ControlCaption = Nothing
        Me.ColOtherItemsPack.DisplayStyleForCurrentCellOnly = true
        Me.ColOtherItemsPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColOtherItemsPack.HeaderText = "Pack"
        Me.ColOtherItemsPack.Name = "ColOtherItemsPack"
        Me.ColOtherItemsPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColOtherItemsPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColOtherItemsPack.SourceColumn = Nothing
        '
        'ColOtherItemsPackSize
        '
        Me.ColOtherItemsPackSize.DataPropertyName = "PackSize"
        Me.ColOtherItemsPackSize.HeaderText = "Pack Size"
        Me.ColOtherItemsPackSize.Name = "ColOtherItemsPackSize"
        '
        'ColOtherItemsQuantity
        '
        Me.ColOtherItemsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N0"
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.NullValue = Nothing
        Me.ColOtherItemsQuantity.DefaultCellStyle = DataGridViewCellStyle25
        Me.ColOtherItemsQuantity.HeaderText = "Quantity"
        Me.ColOtherItemsQuantity.MaxInputLength = 12
        Me.ColOtherItemsQuantity.Name = "ColOtherItemsQuantity"
        Me.ColOtherItemsQuantity.Width = 80
        '
        'ColOtherItemsTotalUnits
        '
        Me.ColOtherItemsTotalUnits.DataPropertyName = "TotalUnits"
        Me.ColOtherItemsTotalUnits.HeaderText = "Total Units"
        Me.ColOtherItemsTotalUnits.Name = "ColOtherItemsTotalUnits"
        '
        'ColOtherItemsUnitCost
        '
        Me.ColOtherItemsUnitCost.DataPropertyName = "UnitCost"
        Me.ColOtherItemsUnitCost.HeaderText = "Unit Cost"
        Me.ColOtherItemsUnitCost.Name = "ColOtherItemsUnitCost"
        '
        'ColOtherItemsTotalCost
        '
        Me.ColOtherItemsTotalCost.DataPropertyName = "TotalCost"
        Me.ColOtherItemsTotalCost.HeaderText = "Total Cost"
        Me.ColOtherItemsTotalCost.Name = "ColOtherItemsTotalCost"
        '
        'colOtherItemsSaved
        '
        Me.colOtherItemsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.NullValue = false
        Me.colOtherItemsSaved.DefaultCellStyle = DataGridViewCellStyle26
        Me.colOtherItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemsSaved.HeaderText = "Saved"
        Me.colOtherItemsSaved.Name = "colOtherItemsSaved"
        Me.colOtherItemsSaved.ReadOnly = true
        Me.colOtherItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemsSaved.Width = 50
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = false
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(804, 435)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 29
        Me.btnPrint.Text = "&Print"
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(98, 430)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(176, 31)
        Me.pnlPrintOnSaving.TabIndex = 28
        '
        'chkPrintOnSaving
        '
        Me.chkPrintOnSaving.AccessibleDescription = ""
        Me.chkPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.chkPrintOnSaving.AutoSize = true
        Me.chkPrintOnSaving.Checked = true
        Me.chkPrintOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintOnSaving.Location = New System.Drawing.Point(12, 3)
        Me.chkPrintOnSaving.Name = "chkPrintOnSaving"
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(132, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print Order On Saving"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(301, 3)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'btnViewToExpireDrugsList
        '
        Me.btnViewToExpireDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireDrugsList.Location = New System.Drawing.Point(276, 80)
        Me.btnViewToExpireDrugsList.Name = "btnViewToExpireDrugsList"
        Me.btnViewToExpireDrugsList.Size = New System.Drawing.Size(71, 24)
        Me.btnViewToExpireDrugsList.TabIndex = 24
        Me.btnViewToExpireDrugsList.Tag = ""
        Me.btnViewToExpireDrugsList.Text = "&View List"
        '
        'lblToExpireDrugs
        '
        Me.lblToExpireDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblToExpireDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireDrugs.Location = New System.Drawing.Point(17, 80)
        Me.lblToExpireDrugs.Name = "lblToExpireDrugs"
        Me.lblToExpireDrugs.Size = New System.Drawing.Size(258, 20)
        Me.lblToExpireDrugs.TabIndex = 23
        Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: 0"
        '
        'btnViewToOrderDrugsList
        '
        Me.btnViewToOrderDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderDrugsList.Location = New System.Drawing.Point(580, 83)
        Me.btnViewToOrderDrugsList.Name = "btnViewToOrderDrugsList"
        Me.btnViewToOrderDrugsList.Size = New System.Drawing.Size(60, 24)
        Me.btnViewToOrderDrugsList.TabIndex = 20
        Me.btnViewToOrderDrugsList.Tag = ""
        Me.btnViewToOrderDrugsList.Text = "&View List"
        '
        'lblToOrderDrugs
        '
        Me.lblToOrderDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblToOrderDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderDrugs.Location = New System.Drawing.Point(353, 84)
        Me.lblToOrderDrugs.Name = "lblToOrderDrugs"
        Me.lblToOrderDrugs.Size = New System.Drawing.Size(221, 20)
        Me.lblToOrderDrugs.TabIndex = 19
        Me.lblToOrderDrugs.Text = "To Order Drugs: 0"
        '
        'lblOrderType
        '
        Me.lblOrderType.Location = New System.Drawing.Point(658, 95)
        Me.lblOrderType.Name = "lblOrderType"
        Me.lblOrderType.Size = New System.Drawing.Size(107, 20)
        Me.lblOrderType.TabIndex = 17
        Me.lblOrderType.Text = "Order Type"
        '
        'stbDrugCost
        '
        Me.stbDrugCost.BackColor = System.Drawing.SystemColors.Control
        Me.stbDrugCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrugCost.CapitalizeFirstLetter = false
        Me.stbDrugCost.Enabled = false
        Me.stbDrugCost.EntryErrorMSG = ""
        Me.stbDrugCost.Location = New System.Drawing.Point(771, 4)
        Me.stbDrugCost.MaxLength = 20
        Me.stbDrugCost.Name = "stbDrugCost"
        Me.stbDrugCost.ReadOnly = true
        Me.stbDrugCost.RegularExpression = ""
        Me.stbDrugCost.Size = New System.Drawing.Size(181, 20)
        Me.stbDrugCost.TabIndex = 10
        Me.stbDrugCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDrugCost
        '
        Me.lblDrugCost.Location = New System.Drawing.Point(658, 4)
        Me.lblDrugCost.Name = "lblDrugCost"
        Me.lblDrugCost.Size = New System.Drawing.Size(107, 18)
        Me.lblDrugCost.TabIndex = 9
        Me.lblDrugCost.Text = "Drug Cost"
        '
        'stbTotalcost
        '
        Me.stbTotalcost.BackColor = System.Drawing.SystemColors.Control
        Me.stbTotalcost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalcost.CapitalizeFirstLetter = false
        Me.stbTotalcost.Enabled = false
        Me.stbTotalcost.EntryErrorMSG = ""
        Me.stbTotalcost.Location = New System.Drawing.Point(771, 70)
        Me.stbTotalcost.MaxLength = 20
        Me.stbTotalcost.Name = "stbTotalcost"
        Me.stbTotalcost.ReadOnly = true
        Me.stbTotalcost.RegularExpression = ""
        Me.stbTotalcost.Size = New System.Drawing.Size(181, 20)
        Me.stbTotalcost.TabIndex = 16
        Me.stbTotalcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(658, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 18)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Total Cost"
        '
        'stbConsumableCost
        '
        Me.stbConsumableCost.BackColor = System.Drawing.SystemColors.Control
        Me.stbConsumableCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumableCost.CapitalizeFirstLetter = false
        Me.stbConsumableCost.Enabled = false
        Me.stbConsumableCost.EntryErrorMSG = ""
        Me.stbConsumableCost.Location = New System.Drawing.Point(771, 26)
        Me.stbConsumableCost.MaxLength = 20
        Me.stbConsumableCost.Name = "stbConsumableCost"
        Me.stbConsumableCost.ReadOnly = true
        Me.stbConsumableCost.RegularExpression = ""
        Me.stbConsumableCost.Size = New System.Drawing.Size(181, 20)
        Me.stbConsumableCost.TabIndex = 12
        Me.stbConsumableCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConsumableCost
        '
        Me.lblConsumableCost.Location = New System.Drawing.Point(658, 26)
        Me.lblConsumableCost.Name = "lblConsumableCost"
        Me.lblConsumableCost.Size = New System.Drawing.Size(107, 18)
        Me.lblConsumableCost.TabIndex = 11
        Me.lblConsumableCost.Text = "Consumable Cost"
        '
        'btnPendingIventoryAcknowledgements
        '
        Me.btnPendingIventoryAcknowledgements.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingIventoryAcknowledgements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingIventoryAcknowledgements.Location = New System.Drawing.Point(276, 52)
        Me.btnPendingIventoryAcknowledgements.Name = "btnPendingIventoryAcknowledgements"
        Me.btnPendingIventoryAcknowledgements.Size = New System.Drawing.Size(71, 24)
        Me.btnPendingIventoryAcknowledgements.TabIndex = 22
        Me.btnPendingIventoryAcknowledgements.Tag = ""
        Me.btnPendingIventoryAcknowledgements.Text = "&View List"
        '
        'lblPendingIventoryAcknowledgements
        '
        Me.lblPendingIventoryAcknowledgements.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPendingIventoryAcknowledgements.ForeColor = System.Drawing.Color.Red
        Me.lblPendingIventoryAcknowledgements.Location = New System.Drawing.Point(17, 58)
        Me.lblPendingIventoryAcknowledgements.Name = "lblPendingIventoryAcknowledgements"
        Me.lblPendingIventoryAcknowledgements.Size = New System.Drawing.Size(218, 20)
        Me.lblPendingIventoryAcknowledgements.TabIndex = 21
        Me.lblPendingIventoryAcknowledgements.Text = "Pending Ack: 0"
        '
        'stbOtherItemsCost
        '
        Me.stbOtherItemsCost.BackColor = System.Drawing.SystemColors.Control
        Me.stbOtherItemsCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherItemsCost.CapitalizeFirstLetter = false
        Me.stbOtherItemsCost.Enabled = false
        Me.stbOtherItemsCost.EntryErrorMSG = ""
        Me.stbOtherItemsCost.Location = New System.Drawing.Point(771, 48)
        Me.stbOtherItemsCost.MaxLength = 20
        Me.stbOtherItemsCost.Name = "stbOtherItemsCost"
        Me.stbOtherItemsCost.ReadOnly = true
        Me.stbOtherItemsCost.RegularExpression = ""
        Me.stbOtherItemsCost.Size = New System.Drawing.Size(181, 20)
        Me.stbOtherItemsCost.TabIndex = 14
        Me.stbOtherItemsCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOtherItemscost
        '
        Me.lblOtherItemscost.Location = New System.Drawing.Point(658, 48)
        Me.lblOtherItemscost.Name = "lblOtherItemscost"
        Me.lblOtherItemscost.Size = New System.Drawing.Size(107, 18)
        Me.lblOtherItemscost.TabIndex = 13
        Me.lblOtherItemscost.Text = "Other Items Cost"
        '
        'lblTransferReasonID
        '
        Me.lblTransferReasonID.Location = New System.Drawing.Point(353, 57)
        Me.lblTransferReasonID.Name = "lblTransferReasonID"
        Me.lblTransferReasonID.Size = New System.Drawing.Size(119, 20)
        Me.lblTransferReasonID.TabIndex = 32
        Me.lblTransferReasonID.Text = "Transfer Reason"
        '
        'frmInventoryOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(970, 467)
        Me.Controls.Add(Me.cboTransferReasonID)
        Me.Controls.Add(Me.lblTransferReasonID)
        Me.Controls.Add(Me.stbOtherItemsCost)
        Me.Controls.Add(Me.lblOtherItemscost)
        Me.Controls.Add(Me.btnPendingIventoryAcknowledgements)
        Me.Controls.Add(Me.lblPendingIventoryAcknowledgements)
        Me.Controls.Add(Me.stbConsumableCost)
        Me.Controls.Add(Me.lblConsumableCost)
        Me.Controls.Add(Me.stbTotalcost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbDrugCost)
        Me.Controls.Add(Me.lblDrugCost)
        Me.Controls.Add(Me.cboOrderType)
        Me.Controls.Add(Me.lblOrderType)
        Me.Controls.Add(Me.btnViewToExpireDrugsList)
        Me.Controls.Add(Me.lblToExpireDrugs)
        Me.Controls.Add(Me.btnViewToOrderDrugsList)
        Me.Controls.Add(Me.lblToOrderDrugs)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.tbcInventoryOrders)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbOrderNo)
        Me.Controls.Add(Me.lblOrderNo)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.cboFromLocationID)
        Me.Controls.Add(Me.lblFromLocationID)
        Me.Controls.Add(Me.cboToLocationID)
        Me.Controls.Add(Me.lblToLocationID)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmInventoryOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory Orders"
        Me.tbcInventoryOrders.ResumeLayout(false)
        Me.tpgDrugs.ResumeLayout(false)
        CType(Me.dgvDrugs,System.ComponentModel.ISupportInitialize).EndInit
        Me.cmsInventoryOrders.ResumeLayout(false)
        Me.tpgConsumables.ResumeLayout(false)
        CType(Me.dgvConsumables,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgOtherItems.ResumeLayout(false)
        CType(Me.dgvOtherItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPrintOnSaving.ResumeLayout(false)
        Me.pnlPrintOnSaving.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents cboFromLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFromLocationID As System.Windows.Forms.Label
    Friend WithEvents cboToLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents tbcInventoryOrders As System.Windows.Forms.TabControl
    Friend WithEvents tpgDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents cmsInventoryOrders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInventoryOrdersQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnViewToExpireDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireDrugs As System.Windows.Forms.Label
    Friend WithEvents btnViewToOrderDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToOrderDrugs As System.Windows.Forms.Label
    Friend WithEvents cboOrderType As ComboBox
    Friend WithEvents lblOrderType As Label
    Friend WithEvents stbDrugCost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrugCost As Label
    Friend WithEvents stbTotalcost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents stbConsumableCost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConsumableCost As Label
    Friend WithEvents colDrugSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDrugPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePack As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colConsumablePackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableTotalUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnPendingIventoryAcknowledgements As System.Windows.Forms.Button
    Friend WithEvents lblPendingIventoryAcknowledgements As System.Windows.Forms.Label
    Friend WithEvents tpgOtherItems As System.Windows.Forms.TabPage
    Friend WithEvents dgvOtherItems As System.Windows.Forms.DataGridView
    Friend WithEvents ColOtherItemsSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColOtherItemsItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsPack As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents ColOtherItemsPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsTotalCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stbOtherItemsCost As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOtherItemscost As System.Windows.Forms.Label
    Friend WithEvents cboTransferReasonID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransferReasonID As System.Windows.Forms.Label
End Class