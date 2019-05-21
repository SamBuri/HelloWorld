
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseOrders : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal purchaseOrderNo As String)
        MyClass.New()
        Me.defaultPurchaseOrderNo = purchaseOrderNo
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchaseOrders))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.stbDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbShipAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPurchaseOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPurchaseOrderNo = New System.Windows.Forms.Label()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.cmsPurchaseOrders = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPurchaseOrdersQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDocumentNo = New System.Windows.Forms.Label()
        Me.lblShipAddress = New System.Windows.Forms.Label()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnViewToExpireDrugsList = New System.Windows.Forms.Button()
        Me.lblToExpireDrugs = New System.Windows.Forms.Label()
        Me.btnViewToOrderDrugsList = New System.Windows.Forms.Button()
        Me.lblToOrderDrugs = New System.Windows.Forms.Label()
        Me.tbcPurchaseOrders = New System.Windows.Forms.TabControl()
        Me.tpgDrugs = New System.Windows.Forms.TabPage()
        Me.dgvDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugsPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDrugsPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOptical = New System.Windows.Forms.TabPage()
        Me.dgvOptical = New System.Windows.Forms.DataGridView()
        Me.colOpticalselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColOpticalNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalTotalOrdered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOpticalSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOthers = New System.Windows.Forms.TabPage()
        Me.dgvOtherItems = New System.Windows.Forms.DataGridView()
        Me.colOtherItemselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colOtherItemsNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColOtherItemsPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemstockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVATValue = New System.Windows.Forms.Label()
        Me.stbVATValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.cmsPurchaseOrders.SuspendLayout()
        Me.pnlPrintOnSaving.SuspendLayout()
        Me.tbcPurchaseOrders.SuspendLayout()
        Me.tpgDrugs.SuspendLayout()
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOptical.SuspendLayout()
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOthers.SuspendLayout()
        CType(Me.dgvOtherItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 427)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 15
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(975, 426)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 16
        Me.fbnDelete.Tag = "PurchaseOrders"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 452)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 17
        Me.ebnSaveUpdate.Tag = "PurchaseOrders"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpOrderDate, "OrderDate")
        Me.dtpOrderDate.Location = New System.Drawing.Point(165, 26)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.ShowCheckBox = True
        Me.dtpOrderDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpOrderDate.TabIndex = 4
        '
        'stbDocumentNo
        '
        Me.stbDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDocumentNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDocumentNo, "DocumentNo")
        Me.stbDocumentNo.EntryErrorMSG = ""
        Me.stbDocumentNo.Location = New System.Drawing.Point(165, 46)
        Me.stbDocumentNo.MaxLength = 20
        Me.stbDocumentNo.Name = "stbDocumentNo"
        Me.stbDocumentNo.RegularExpression = ""
        Me.stbDocumentNo.Size = New System.Drawing.Size(179, 20)
        Me.stbDocumentNo.TabIndex = 6
        '
        'stbShipAddress
        '
        Me.stbShipAddress.AcceptsReturn = True
        Me.stbShipAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbShipAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbShipAddress, "ShipAddress")
        Me.stbShipAddress.EntryErrorMSG = ""
        Me.stbShipAddress.Location = New System.Drawing.Point(509, 6)
        Me.stbShipAddress.MaxLength = 300
        Me.stbShipAddress.Multiline = True
        Me.stbShipAddress.Name = "stbShipAddress"
        Me.stbShipAddress.RegularExpression = ""
        Me.stbShipAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbShipAddress.Size = New System.Drawing.Size(304, 60)
        Me.stbShipAddress.TabIndex = 12
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSupplierName, "SupplierName")
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(165, 90)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSupplierName.Size = New System.Drawing.Size(179, 35)
        Me.stbSupplierName.TabIndex = 10
        '
        'cboSupplierNo
        '
        Me.cboSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboSupplierNo, "SupplierNo")
        Me.cboSupplierNo.DropDownWidth = 256
        Me.cboSupplierNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSupplierNo.FormattingEnabled = True
        Me.cboSupplierNo.ItemHeight = 13
        Me.cboSupplierNo.Location = New System.Drawing.Point(165, 67)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(179, 21)
        Me.cboSupplierNo.TabIndex = 8
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(975, 452)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 20
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPurchaseOrderNo
        '
        Me.stbPurchaseOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPurchaseOrderNo.CapitalizeFirstLetter = False
        Me.stbPurchaseOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPurchaseOrderNo.EntryErrorMSG = ""
        Me.stbPurchaseOrderNo.Location = New System.Drawing.Point(165, 5)
        Me.stbPurchaseOrderNo.MaxLength = 20
        Me.stbPurchaseOrderNo.Name = "stbPurchaseOrderNo"
        Me.stbPurchaseOrderNo.RegularExpression = ""
        Me.stbPurchaseOrderNo.Size = New System.Drawing.Size(127, 20)
        Me.stbPurchaseOrderNo.TabIndex = 1
        '
        'lblPurchaseOrderNo
        '
        Me.lblPurchaseOrderNo.Location = New System.Drawing.Point(12, 7)
        Me.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo"
        Me.lblPurchaseOrderNo.Size = New System.Drawing.Size(147, 20)
        Me.lblPurchaseOrderNo.TabIndex = 0
        Me.lblPurchaseOrderNo.Text = "Purchase Order No"
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(12, 28)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(147, 20)
        Me.lblOrderDate.TabIndex = 3
        Me.lblOrderDate.Text = "Order Date"
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
        'cmsPurchaseOrders
        '
        Me.cmsPurchaseOrders.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsPurchaseOrders.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPurchaseOrdersQuickSearch})
        Me.cmsPurchaseOrders.Name = "cmsSearch"
        Me.cmsPurchaseOrders.Size = New System.Drawing.Size(144, 26)
        '
        'cmsPurchaseOrdersQuickSearch
        '
        Me.cmsPurchaseOrdersQuickSearch.Name = "cmsPurchaseOrdersQuickSearch"
        Me.cmsPurchaseOrdersQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsPurchaseOrdersQuickSearch.Text = "Quick Search"
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.Location = New System.Drawing.Point(12, 47)
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Size = New System.Drawing.Size(147, 20)
        Me.lblDocumentNo.TabIndex = 5
        Me.lblDocumentNo.Text = "Document No"
        '
        'lblShipAddress
        '
        Me.lblShipAddress.Location = New System.Drawing.Point(365, 9)
        Me.lblShipAddress.Name = "lblShipAddress"
        Me.lblShipAddress.Size = New System.Drawing.Size(141, 20)
        Me.lblShipAddress.TabIndex = 11
        Me.lblShipAddress.Text = "Ship To Address"
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(12, 97)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierName.TabIndex = 9
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(12, 69)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierNo.TabIndex = 7
        Me.lblSupplierNo.Text = "Supplier Number"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(298, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(98, 452)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(176, 31)
        Me.pnlPrintOnSaving.TabIndex = 18
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
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(132, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print Order On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(897, 452)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 19
        Me.btnPrint.Text = "&Print"
        '
        'btnViewToExpireDrugsList
        '
        Me.btnViewToExpireDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireDrugsList.Location = New System.Drawing.Point(762, 128)
        Me.btnViewToExpireDrugsList.Name = "btnViewToExpireDrugsList"
        Me.btnViewToExpireDrugsList.Size = New System.Drawing.Size(84, 24)
        Me.btnViewToExpireDrugsList.TabIndex = 24
        Me.btnViewToExpireDrugsList.Tag = ""
        Me.btnViewToExpireDrugsList.Text = "&View List"
        '
        'lblToExpireDrugs
        '
        Me.lblToExpireDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToExpireDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireDrugs.Location = New System.Drawing.Point(444, 130)
        Me.lblToExpireDrugs.Name = "lblToExpireDrugs"
        Me.lblToExpireDrugs.Size = New System.Drawing.Size(312, 20)
        Me.lblToExpireDrugs.TabIndex = 23
        Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: 0"
        '
        'btnViewToOrderDrugsList
        '
        Me.btnViewToOrderDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderDrugsList.Location = New System.Drawing.Point(350, 130)
        Me.btnViewToOrderDrugsList.Name = "btnViewToOrderDrugsList"
        Me.btnViewToOrderDrugsList.Size = New System.Drawing.Size(84, 24)
        Me.btnViewToOrderDrugsList.TabIndex = 22
        Me.btnViewToOrderDrugsList.Tag = ""
        Me.btnViewToOrderDrugsList.Text = "&View List"
        '
        'lblToOrderDrugs
        '
        Me.lblToOrderDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToOrderDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderDrugs.Location = New System.Drawing.Point(20, 131)
        Me.lblToOrderDrugs.Name = "lblToOrderDrugs"
        Me.lblToOrderDrugs.Size = New System.Drawing.Size(312, 20)
        Me.lblToOrderDrugs.TabIndex = 21
        Me.lblToOrderDrugs.Text = "To Order Drugs: 0"
        '
        'tbcPurchaseOrders
        '
        Me.tbcPurchaseOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPurchaseOrders.Controls.Add(Me.tpgDrugs)
        Me.tbcPurchaseOrders.Controls.Add(Me.tpgConsumables)
        Me.tbcPurchaseOrders.Controls.Add(Me.tpgOptical)
        Me.tbcPurchaseOrders.Controls.Add(Me.tpgOthers)
        Me.tbcPurchaseOrders.HotTrack = True
        Me.tbcPurchaseOrders.Location = New System.Drawing.Point(19, 160)
        Me.tbcPurchaseOrders.Name = "tbcPurchaseOrders"
        Me.tbcPurchaseOrders.SelectedIndex = 0
        Me.tbcPurchaseOrders.Size = New System.Drawing.Size(1037, 261)
        Me.tbcPurchaseOrders.TabIndex = 25
        '
        'tpgDrugs
        '
        Me.tpgDrugs.Controls.Add(Me.dgvDrugs)
        Me.tpgDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgDrugs.Name = "tpgDrugs"
        Me.tpgDrugs.Size = New System.Drawing.Size(1029, 235)
        Me.tpgDrugs.TabIndex = 2
        Me.tpgDrugs.Tag = "DrugPurchaseOrders"
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
        Me.dgvDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugSelect, Me.colDrugNo, Me.colDrugName, Me.colDrugUnitMeasure, Me.colDrugItemGroup, Me.colDrugsPack, Me.colDrugsPackSize, Me.colDrugQuantity, Me.colDrugTotalUnits, Me.colDrugRate, Me.colDrugVATPercentage, Me.colDrugVATValue, Me.colDrugAmount, Me.colDrugNotes, Me.colDrugStockStatus, Me.colDrugsSaved})
        Me.dgvDrugs.ContextMenuStrip = Me.cmsPurchaseOrders
        Me.dgvDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDrugs.EnableHeadersVisualStyles = False
        Me.dgvDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvDrugs.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvDrugs.Name = "dgvDrugs"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvDrugs.Size = New System.Drawing.Size(1029, 235)
        Me.dgvDrugs.TabIndex = 46
        Me.dgvDrugs.Text = "DataGridView2"
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
        Me.colDrugSelect.ReadOnly = True
        Me.colDrugSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugSelect.Text = "•••"
        Me.colDrugSelect.UseColumnTextForButtonValue = True
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
        Me.colDrugName.HeaderText = "Dug Name"
        Me.colDrugName.MaxInputLength = 100
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
        Me.colDrugName.Width = 140
        '
        'colDrugUnitMeasure
        '
        Me.colDrugUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.colDrugUnitMeasure.HeaderText = "Unit Measure"
        Me.colDrugUnitMeasure.MaxInputLength = 100
        Me.colDrugUnitMeasure.Name = "colDrugUnitMeasure"
        Me.colDrugUnitMeasure.Width = 80
        '
        'colDrugItemGroup
        '
        Me.colDrugItemGroup.DataPropertyName = "ItemGroup"
        Me.colDrugItemGroup.HeaderText = "Item Group"
        Me.colDrugItemGroup.MaxInputLength = 100
        Me.colDrugItemGroup.Name = "colDrugItemGroup"
        Me.colDrugItemGroup.Width = 80
        '
        'colDrugsPack
        '
        Me.colDrugsPack.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrugsPack.HeaderText = "Pack"
        Me.colDrugsPack.Name = "colDrugsPack"
        Me.colDrugsPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugsPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colDrugsPackSize
        '
        Me.colDrugsPackSize.DataPropertyName = "PackSize"
        Me.colDrugsPackSize.HeaderText = "PackSize"
        Me.colDrugsPackSize.Name = "colDrugsPackSize"
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.MaxInputLength = 12
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 60
        '
        'colDrugTotalUnits
        '
        Me.colDrugTotalUnits.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugTotalUnits.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDrugTotalUnits.HeaderText = "Total Units"
        Me.colDrugTotalUnits.Name = "colDrugTotalUnits"
        Me.colDrugTotalUnits.ReadOnly = True
        '
        'colDrugRate
        '
        Me.colDrugRate.DataPropertyName = "Rate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colDrugRate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugRate.HeaderText = "Rate"
        Me.colDrugRate.MaxInputLength = 12
        Me.colDrugRate.Name = "colDrugRate"
        Me.colDrugRate.Width = 80
        '
        'colDrugVATPercentage
        '
        Me.colDrugVATPercentage.DataPropertyName = "VATPercentage"
        Me.colDrugVATPercentage.HeaderText = "VAT Percentage"
        Me.colDrugVATPercentage.Name = "colDrugVATPercentage"
        Me.colDrugVATPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'colDrugVATValue
        '
        Me.colDrugVATValue.DataPropertyName = "VATValue"
        Me.colDrugVATValue.HeaderText = "VAT Value"
        Me.colDrugVATValue.Name = "colDrugVATValue"
        Me.colDrugVATValue.ReadOnly = True
        '
        'colDrugAmount
        '
        Me.colDrugAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colDrugAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugAmount.HeaderText = "Amount"
        Me.colDrugAmount.MaxInputLength = 12
        Me.colDrugAmount.Name = "colDrugAmount"
        '
        'colDrugNotes
        '
        Me.colDrugNotes.DataPropertyName = "Notes"
        Me.colDrugNotes.HeaderText = "Notes"
        Me.colDrugNotes.MaxInputLength = 200
        Me.colDrugNotes.Name = "colDrugNotes"
        Me.colDrugNotes.Width = 80
        '
        'colDrugStockStatus
        '
        Me.colDrugStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugStockStatus.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDrugStockStatus.HeaderText = "Stock Status"
        Me.colDrugStockStatus.MaxInputLength = 100
        Me.colDrugStockStatus.Name = "colDrugStockStatus"
        Me.colDrugStockStatus.ReadOnly = True
        Me.colDrugStockStatus.Width = 80
        '
        'colDrugsSaved
        '
        Me.colDrugsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colDrugsSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugsSaved.HeaderText = "Saved"
        Me.colDrugsSaved.Name = "colDrugsSaved"
        Me.colDrugsSaved.ReadOnly = True
        Me.colDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDrugsSaved.Width = 50
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(1029, 235)
        Me.tpgConsumables.TabIndex = 12
        Me.tpgConsumables.Tag = "ConsumablePurchaseOrders"
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableSelect, Me.colConsumableNo, Me.colConsumableName, Me.colConsumableUnitMeasure, Me.colConsumableItemGroup, Me.colPack, Me.colPackSize, Me.colConsumableQuantity, Me.colTotalUnits, Me.colConsumableRate, Me.colConsumableVATPercentage, Me.colConsumableVATValue, Me.colConsumableAmount, Me.colConsumableNotes, Me.colConsumableStockStatus, Me.colConsumablesSaved})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsPurchaseOrders
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvConsumables.Size = New System.Drawing.Size(1029, 235)
        Me.dgvConsumables.TabIndex = 44
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableSelect
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colConsumableSelect.DefaultCellStyle = DataGridViewCellStyle12
        Me.colConsumableSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableSelect.HeaderText = "Select"
        Me.colConsumableSelect.Name = "colConsumableSelect"
        Me.colConsumableSelect.ReadOnly = True
        Me.colConsumableSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumableSelect.Text = "•••"
        Me.colConsumableSelect.UseColumnTextForButtonValue = True
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
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.MaxInputLength = 100
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Width = 140
        '
        'colConsumableUnitMeasure
        '
        Me.colConsumableUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.colConsumableUnitMeasure.HeaderText = "Unit Measure"
        Me.colConsumableUnitMeasure.MaxInputLength = 100
        Me.colConsumableUnitMeasure.Name = "colConsumableUnitMeasure"
        Me.colConsumableUnitMeasure.Width = 80
        '
        'colConsumableItemGroup
        '
        Me.colConsumableItemGroup.DataPropertyName = "ItemGroup"
        Me.colConsumableItemGroup.HeaderText = "Item Group"
        Me.colConsumableItemGroup.MaxInputLength = 100
        Me.colConsumableItemGroup.Name = "colConsumableItemGroup"
        Me.colConsumableItemGroup.Width = 80
        '
        'colPack
        '
        Me.colPack.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colPack.HeaderText = "Pack"
        Me.colPack.Name = "colPack"
        Me.colPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colPackSize
        '
        Me.colPackSize.DataPropertyName = "PackSize"
        Me.colPackSize.HeaderText = "PackSize"
        Me.colPackSize.Name = "colPackSize"
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle14
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 60
        '
        'colTotalUnits
        '
        Me.colTotalUnits.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colTotalUnits.DefaultCellStyle = DataGridViewCellStyle15
        Me.colTotalUnits.HeaderText = "Total Units"
        Me.colTotalUnits.Name = "colTotalUnits"
        Me.colTotalUnits.ReadOnly = True
        '
        'colConsumableRate
        '
        Me.colConsumableRate.DataPropertyName = "Rate"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colConsumableRate.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumableRate.HeaderText = "Rate"
        Me.colConsumableRate.MaxInputLength = 12
        Me.colConsumableRate.Name = "colConsumableRate"
        Me.colConsumableRate.Width = 80
        '
        'colConsumableVATPercentage
        '
        Me.colConsumableVATPercentage.DataPropertyName = "VATPercentage"
        Me.colConsumableVATPercentage.HeaderText = "VAT Percentage"
        Me.colConsumableVATPercentage.Name = "colConsumableVATPercentage"
        '
        'colConsumableVATValue
        '
        Me.colConsumableVATValue.DataPropertyName = "VATValue"
        Me.colConsumableVATValue.HeaderText = "VAT Value"
        Me.colConsumableVATValue.Name = "colConsumableVATValue"
        Me.colConsumableVATValue.ReadOnly = True
        '
        'colConsumableAmount
        '
        Me.colConsumableAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle17
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.DataPropertyName = "Notes"
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 200
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.Width = 80
        '
        'colConsumableStockStatus
        '
        Me.colConsumableStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableStockStatus.DefaultCellStyle = DataGridViewCellStyle18
        Me.colConsumableStockStatus.HeaderText = "Stock Status"
        Me.colConsumableStockStatus.MaxInputLength = 100
        Me.colConsumableStockStatus.Name = "colConsumableStockStatus"
        Me.colConsumableStockStatus.ReadOnly = True
        Me.colConsumableStockStatus.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle19
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'tpgOptical
        '
        Me.tpgOptical.Controls.Add(Me.dgvOptical)
        Me.tpgOptical.Location = New System.Drawing.Point(4, 22)
        Me.tpgOptical.Name = "tpgOptical"
        Me.tpgOptical.Size = New System.Drawing.Size(1029, 235)
        Me.tpgOptical.TabIndex = 14
        Me.tpgOptical.Text = "Optical"
        Me.tpgOptical.UseVisualStyleBackColor = True
        '
        'dgvOptical
        '
        Me.dgvOptical.AllowUserToOrderColumns = True
        Me.dgvOptical.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvOptical.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOpticalselect, Me.ColOpticalNo, Me.ColOpticalItemName, Me.ColOpticalUnitMeasure, Me.ColOpticalItemGroup, Me.ColOpticalQuantity, Me.ColOpticalTotalOrdered, Me.ColOpticalRate, Me.ColOpticalVATPercentage, Me.ColOpticalVATValue, Me.ColOpticalAmount, Me.ColOpticalNotes, Me.ColOpticalStockStatus, Me.ColOpticalSaved})
        Me.dgvOptical.ContextMenuStrip = Me.cmsPurchaseOrders
        Me.dgvOptical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptical.EnableHeadersVisualStyles = False
        Me.dgvOptical.GridColor = System.Drawing.Color.Khaki
        Me.dgvOptical.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOptical.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptical.Name = "dgvOptical"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvOptical.Size = New System.Drawing.Size(1029, 235)
        Me.dgvOptical.TabIndex = 48
        Me.dgvOptical.Text = "DataGridView2"
        '
        'colOpticalselect
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colOpticalselect.DefaultCellStyle = DataGridViewCellStyle22
        Me.colOpticalselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOpticalselect.HeaderText = "Select"
        Me.colOpticalselect.Name = "colOpticalselect"
        Me.colOpticalselect.ReadOnly = True
        Me.colOpticalselect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOpticalselect.Text = "•••"
        Me.colOpticalselect.UseColumnTextForButtonValue = True
        Me.colOpticalselect.Width = 50
        '
        'ColOpticalNo
        '
        Me.ColOpticalNo.DataPropertyName = "ItemCode"
        Me.ColOpticalNo.HeaderText = "Item No"
        Me.ColOpticalNo.MaxInputLength = 20
        Me.ColOpticalNo.Name = "ColOpticalNo"
        Me.ColOpticalNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColOpticalNo.Width = 90
        '
        'ColOpticalItemName
        '
        Me.ColOpticalItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.ColOpticalItemName.DefaultCellStyle = DataGridViewCellStyle23
        Me.ColOpticalItemName.HeaderText = "Optical"
        Me.ColOpticalItemName.MaxInputLength = 100
        Me.ColOpticalItemName.Name = "ColOpticalItemName"
        Me.ColOpticalItemName.ReadOnly = True
        Me.ColOpticalItemName.Width = 140
        '
        'ColOpticalUnitMeasure
        '
        Me.ColOpticalUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.ColOpticalUnitMeasure.HeaderText = "Unit Measure"
        Me.ColOpticalUnitMeasure.MaxInputLength = 100
        Me.ColOpticalUnitMeasure.Name = "ColOpticalUnitMeasure"
        Me.ColOpticalUnitMeasure.Width = 80
        '
        'ColOpticalItemGroup
        '
        Me.ColOpticalItemGroup.DataPropertyName = "ItemGroup"
        Me.ColOpticalItemGroup.HeaderText = "Item Group"
        Me.ColOpticalItemGroup.MaxInputLength = 100
        Me.ColOpticalItemGroup.Name = "ColOpticalItemGroup"
        Me.ColOpticalItemGroup.Width = 80
        '
        'ColOpticalQuantity
        '
        Me.ColOpticalQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle24.NullValue = Nothing
        Me.ColOpticalQuantity.DefaultCellStyle = DataGridViewCellStyle24
        Me.ColOpticalQuantity.HeaderText = "Quantity"
        Me.ColOpticalQuantity.MaxInputLength = 12
        Me.ColOpticalQuantity.Name = "ColOpticalQuantity"
        Me.ColOpticalQuantity.Width = 60
        '
        'ColOpticalTotalOrdered
        '
        Me.ColOpticalTotalOrdered.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        Me.ColOpticalTotalOrdered.DefaultCellStyle = DataGridViewCellStyle25
        Me.ColOpticalTotalOrdered.HeaderText = "Total Units"
        Me.ColOpticalTotalOrdered.Name = "ColOpticalTotalOrdered"
        Me.ColOpticalTotalOrdered.ReadOnly = True
        '
        'ColOpticalRate
        '
        Me.ColOpticalRate.DataPropertyName = "Rate"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.Format = "N0"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.ColOpticalRate.DefaultCellStyle = DataGridViewCellStyle26
        Me.ColOpticalRate.HeaderText = "Rate"
        Me.ColOpticalRate.MaxInputLength = 12
        Me.ColOpticalRate.Name = "ColOpticalRate"
        Me.ColOpticalRate.Width = 80
        '
        'ColOpticalVATPercentage
        '
        Me.ColOpticalVATPercentage.DataPropertyName = "VATPercentage"
        Me.ColOpticalVATPercentage.HeaderText = "VAT Percentage"
        Me.ColOpticalVATPercentage.Name = "ColOpticalVATPercentage"
        Me.ColOpticalVATPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ColOpticalVATValue
        '
        Me.ColOpticalVATValue.DataPropertyName = "VATValue"
        Me.ColOpticalVATValue.HeaderText = "VAT Value"
        Me.ColOpticalVATValue.Name = "ColOpticalVATValue"
        Me.ColOpticalVATValue.ReadOnly = True
        '
        'ColOpticalAmount
        '
        Me.ColOpticalAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N0"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.ColOpticalAmount.DefaultCellStyle = DataGridViewCellStyle27
        Me.ColOpticalAmount.HeaderText = "Amount"
        Me.ColOpticalAmount.MaxInputLength = 12
        Me.ColOpticalAmount.Name = "ColOpticalAmount"
        '
        'ColOpticalNotes
        '
        Me.ColOpticalNotes.DataPropertyName = "Notes"
        Me.ColOpticalNotes.HeaderText = "Notes"
        Me.ColOpticalNotes.MaxInputLength = 200
        Me.ColOpticalNotes.Name = "ColOpticalNotes"
        Me.ColOpticalNotes.Width = 80
        '
        'ColOpticalStockStatus
        '
        Me.ColOpticalStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.ColOpticalStockStatus.DefaultCellStyle = DataGridViewCellStyle28
        Me.ColOpticalStockStatus.HeaderText = "Stock Status"
        Me.ColOpticalStockStatus.MaxInputLength = 100
        Me.ColOpticalStockStatus.Name = "ColOpticalStockStatus"
        Me.ColOpticalStockStatus.ReadOnly = True
        Me.ColOpticalStockStatus.Width = 80
        '
        'ColOpticalSaved
        '
        Me.ColOpticalSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.NullValue = False
        Me.ColOpticalSaved.DefaultCellStyle = DataGridViewCellStyle29
        Me.ColOpticalSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColOpticalSaved.HeaderText = "Saved"
        Me.ColOpticalSaved.Name = "ColOpticalSaved"
        Me.ColOpticalSaved.ReadOnly = True
        Me.ColOpticalSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColOpticalSaved.Width = 50
        '
        'tpgOthers
        '
        Me.tpgOthers.Controls.Add(Me.dgvOtherItems)
        Me.tpgOthers.Location = New System.Drawing.Point(4, 22)
        Me.tpgOthers.Name = "tpgOthers"
        Me.tpgOthers.Size = New System.Drawing.Size(1029, 235)
        Me.tpgOthers.TabIndex = 13
        Me.tpgOthers.Text = "Non Medical Items"
        Me.tpgOthers.UseVisualStyleBackColor = True
        '
        'dgvOtherItems
        '
        Me.dgvOtherItems.AllowUserToOrderColumns = True
        Me.dgvOtherItems.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvOtherItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOtherItemselect, Me.colOtherItemsNo, Me.ColOtherItemsItemName, Me.ColOtherItemsUnitMeasure, Me.ColOtherItemsItemGroup, Me.colOtherItemsPack, Me.ColOtherItemsPackSize, Me.ColOtherItemsQuantity, Me.colOtherItemsTotalUnits, Me.ColOtherItemsRate, Me.ColOtherItemsVATPercentage, Me.ColOtherItemsVATValue, Me.ColOtherItemsAmount, Me.ColOtherItemsNotes, Me.colOtherItemstockStatus, Me.colOtherItemsSaved})
        Me.dgvOtherItems.ContextMenuStrip = Me.cmsPurchaseOrders
        Me.dgvOtherItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOtherItems.EnableHeadersVisualStyles = False
        Me.dgvOtherItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOtherItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvOtherItems.Name = "dgvOtherItems"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle40
        Me.dgvOtherItems.Size = New System.Drawing.Size(1029, 235)
        Me.dgvOtherItems.TabIndex = 47
        Me.dgvOtherItems.Text = "DataGridView2"
        '
        'colOtherItemselect
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle32.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colOtherItemselect.DefaultCellStyle = DataGridViewCellStyle32
        Me.colOtherItemselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemselect.HeaderText = "Select"
        Me.colOtherItemselect.Name = "colOtherItemselect"
        Me.colOtherItemselect.ReadOnly = True
        Me.colOtherItemselect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemselect.Text = "•••"
        Me.colOtherItemselect.UseColumnTextForButtonValue = True
        Me.colOtherItemselect.Width = 50
        '
        'colOtherItemsNo
        '
        Me.colOtherItemsNo.DataPropertyName = "ItemCode"
        Me.colOtherItemsNo.HeaderText = "Item No"
        Me.colOtherItemsNo.MaxInputLength = 20
        Me.colOtherItemsNo.Name = "colOtherItemsNo"
        Me.colOtherItemsNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsNo.Width = 90
        '
        'ColOtherItemsItemName
        '
        Me.ColOtherItemsItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        Me.ColOtherItemsItemName.DefaultCellStyle = DataGridViewCellStyle33
        Me.ColOtherItemsItemName.HeaderText = "Item Name"
        Me.ColOtherItemsItemName.MaxInputLength = 100
        Me.ColOtherItemsItemName.Name = "ColOtherItemsItemName"
        Me.ColOtherItemsItemName.ReadOnly = True
        Me.ColOtherItemsItemName.Width = 140
        '
        'ColOtherItemsUnitMeasure
        '
        Me.ColOtherItemsUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.ColOtherItemsUnitMeasure.HeaderText = "Unit Measure"
        Me.ColOtherItemsUnitMeasure.MaxInputLength = 100
        Me.ColOtherItemsUnitMeasure.Name = "ColOtherItemsUnitMeasure"
        Me.ColOtherItemsUnitMeasure.Width = 80
        '
        'ColOtherItemsItemGroup
        '
        Me.ColOtherItemsItemGroup.DataPropertyName = "ItemGroup"
        Me.ColOtherItemsItemGroup.HeaderText = "Item Group"
        Me.ColOtherItemsItemGroup.MaxInputLength = 100
        Me.ColOtherItemsItemGroup.Name = "ColOtherItemsItemGroup"
        Me.ColOtherItemsItemGroup.Width = 80
        '
        'colOtherItemsPack
        '
        Me.colOtherItemsPack.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colOtherItemsPack.HeaderText = "Pack"
        Me.colOtherItemsPack.Name = "colOtherItemsPack"
        Me.colOtherItemsPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColOtherItemsPackSize
        '
        Me.ColOtherItemsPackSize.DataPropertyName = "PackSize"
        Me.ColOtherItemsPackSize.HeaderText = "PackSize"
        Me.ColOtherItemsPackSize.Name = "ColOtherItemsPackSize"
        '
        'ColOtherItemsQuantity
        '
        Me.ColOtherItemsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle34.NullValue = Nothing
        Me.ColOtherItemsQuantity.DefaultCellStyle = DataGridViewCellStyle34
        Me.ColOtherItemsQuantity.HeaderText = "Quantity"
        Me.ColOtherItemsQuantity.MaxInputLength = 12
        Me.ColOtherItemsQuantity.Name = "ColOtherItemsQuantity"
        Me.ColOtherItemsQuantity.Width = 60
        '
        'colOtherItemsTotalUnits
        '
        Me.colOtherItemsTotalUnits.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsTotalUnits.DefaultCellStyle = DataGridViewCellStyle35
        Me.colOtherItemsTotalUnits.HeaderText = "Total Units"
        Me.colOtherItemsTotalUnits.Name = "colOtherItemsTotalUnits"
        Me.colOtherItemsTotalUnits.ReadOnly = True
        '
        'ColOtherItemsRate
        '
        Me.ColOtherItemsRate.DataPropertyName = "Rate"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.Format = "N0"
        DataGridViewCellStyle36.NullValue = Nothing
        Me.ColOtherItemsRate.DefaultCellStyle = DataGridViewCellStyle36
        Me.ColOtherItemsRate.HeaderText = "Rate"
        Me.ColOtherItemsRate.MaxInputLength = 12
        Me.ColOtherItemsRate.Name = "ColOtherItemsRate"
        Me.ColOtherItemsRate.Width = 80
        '
        'ColOtherItemsVATPercentage
        '
        Me.ColOtherItemsVATPercentage.DataPropertyName = "VATPercentage"
        Me.ColOtherItemsVATPercentage.HeaderText = "VAT Percentage"
        Me.ColOtherItemsVATPercentage.Name = "ColOtherItemsVATPercentage"
        Me.ColOtherItemsVATPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ColOtherItemsVATValue
        '
        Me.ColOtherItemsVATValue.DataPropertyName = "VATValue"
        Me.ColOtherItemsVATValue.HeaderText = "VAT Value"
        Me.ColOtherItemsVATValue.Name = "ColOtherItemsVATValue"
        Me.ColOtherItemsVATValue.ReadOnly = True
        '
        'ColOtherItemsAmount
        '
        Me.ColOtherItemsAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N0"
        DataGridViewCellStyle37.NullValue = Nothing
        Me.ColOtherItemsAmount.DefaultCellStyle = DataGridViewCellStyle37
        Me.ColOtherItemsAmount.HeaderText = "Amount"
        Me.ColOtherItemsAmount.MaxInputLength = 12
        Me.ColOtherItemsAmount.Name = "ColOtherItemsAmount"
        '
        'ColOtherItemsNotes
        '
        Me.ColOtherItemsNotes.DataPropertyName = "Notes"
        Me.ColOtherItemsNotes.HeaderText = "Notes"
        Me.ColOtherItemsNotes.MaxInputLength = 200
        Me.ColOtherItemsNotes.Name = "ColOtherItemsNotes"
        Me.ColOtherItemsNotes.Width = 80
        '
        'colOtherItemstockStatus
        '
        Me.colOtherItemstockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemstockStatus.DefaultCellStyle = DataGridViewCellStyle38
        Me.colOtherItemstockStatus.HeaderText = "Stock Status"
        Me.colOtherItemstockStatus.MaxInputLength = 100
        Me.colOtherItemstockStatus.Name = "colOtherItemstockStatus"
        Me.colOtherItemstockStatus.ReadOnly = True
        Me.colOtherItemstockStatus.Width = 80
        '
        'colOtherItemsSaved
        '
        Me.colOtherItemsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle39.NullValue = False
        Me.colOtherItemsSaved.DefaultCellStyle = DataGridViewCellStyle39
        Me.colOtherItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemsSaved.HeaderText = "Saved"
        Me.colOtherItemsSaved.Name = "colOtherItemsSaved"
        Me.colOtherItemsSaved.ReadOnly = True
        Me.colOtherItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemsSaved.Width = 50
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblVATValue)
        Me.pnlBill.Controls.Add(Me.stbVATValue)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(350, 68)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(702, 49)
        Me.pnlBill.TabIndex = 26
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(366, 7)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(86, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(162, 26)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(198, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(458, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(238, 43)
        Me.stbBillWords.TabIndex = 3
        '
        'lblVATValue
        '
        Me.lblVATValue.Location = New System.Drawing.Point(14, 7)
        Me.lblVATValue.Name = "lblVATValue"
        Me.lblVATValue.Size = New System.Drawing.Size(142, 18)
        Me.lblVATValue.TabIndex = 0
        Me.lblVATValue.Text = "VAT Value"
        '
        'stbVATValue
        '
        Me.stbVATValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbVATValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVATValue.CapitalizeFirstLetter = False
        Me.stbVATValue.Enabled = False
        Me.stbVATValue.EntryErrorMSG = ""
        Me.stbVATValue.Location = New System.Drawing.Point(162, 5)
        Me.stbVATValue.MaxLength = 20
        Me.stbVATValue.Name = "stbVATValue"
        Me.stbVATValue.RegularExpression = ""
        Me.stbVATValue.Size = New System.Drawing.Size(198, 20)
        Me.stbVATValue.TabIndex = 1
        Me.stbVATValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(14, 28)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(142, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Drugs"
        '
        'frmPurchaseOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1059, 487)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.tbcPurchaseOrders)
        Me.Controls.Add(Me.btnViewToExpireDrugsList)
        Me.Controls.Add(Me.lblToExpireDrugs)
        Me.Controls.Add(Me.btnViewToOrderDrugsList)
        Me.Controls.Add(Me.lblToOrderDrugs)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.cboSupplierNo)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.lblSupplierNo)
        Me.Controls.Add(Me.stbDocumentNo)
        Me.Controls.Add(Me.lblDocumentNo)
        Me.Controls.Add(Me.stbShipAddress)
        Me.Controls.Add(Me.lblShipAddress)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPurchaseOrderNo)
        Me.Controls.Add(Me.lblPurchaseOrderNo)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPurchaseOrders"
        Me.Text = "Purchase Orders"
        Me.cmsPurchaseOrders.ResumeLayout(False)
        Me.pnlPrintOnSaving.ResumeLayout(False)
        Me.pnlPrintOnSaving.PerformLayout()
        Me.tbcPurchaseOrders.ResumeLayout(False)
        Me.tpgDrugs.ResumeLayout(False)
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOptical.ResumeLayout(False)
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOthers.ResumeLayout(False)
        CType(Me.dgvOtherItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPurchaseOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPurchaseOrderNo As System.Windows.Forms.Label
    Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents cmsPurchaseOrders As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPurchaseOrdersQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbShipAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblShipAddress As System.Windows.Forms.Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboSupplierNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblSupplierNo As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnViewToExpireDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireDrugs As System.Windows.Forms.Label
    Friend WithEvents btnViewToOrderDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToOrderDrugs As System.Windows.Forms.Label
    Friend WithEvents tbcPurchaseOrders As TabControl
    Friend WithEvents tpgDrugs As TabPage
    Friend WithEvents dgvDrugs As DataGridView
    Friend WithEvents tpgConsumables As TabPage
    Friend WithEvents dgvConsumables As DataGridView
    Friend WithEvents pnlBill As Panel
    Friend WithEvents lblBillWords As Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVATValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As Label
    Friend WithEvents lblVATValue As Label
    Friend WithEvents tpgOthers As System.Windows.Forms.TabPage
    Friend WithEvents dgvOtherItems As System.Windows.Forms.DataGridView
    Friend WithEvents colDrugSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugsPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDrugsPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgOptical As System.Windows.Forms.TabPage
    Friend WithEvents dgvOptical As System.Windows.Forms.DataGridView
    Friend WithEvents colOtherItemselect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colOtherItemsNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColOtherItemsPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemstockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOpticalselect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColOpticalNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalTotalOrdered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOpticalSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class