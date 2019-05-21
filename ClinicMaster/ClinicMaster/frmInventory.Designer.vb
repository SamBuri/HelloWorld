
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmInventory : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal itemCategoryID As String)
        MyClass.New()
        Me.defaultItemCategoryID = itemCategoryID
    End Sub

    Public Sub New(ByVal itemCategoryID As String, ByVal itemCode As String)
        MyClass.New(itemCategoryID)
        Me.defaultItemCode = itemCode
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventory))
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.cboStockTypeID = New System.Windows.Forms.ComboBox()
        Me.lblStockTypeID = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.nbxQuantity = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.nbxBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.stbItemName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.stbUnitMeasure = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.pnlAlertItems = New System.Windows.Forms.Panel()
        Me.btnViewToExpireItemsList = New System.Windows.Forms.Button()
        Me.lblToExpireItems = New System.Windows.Forms.Label()
        Me.btnViewToOrderItemsList = New System.Windows.Forms.Button()
        Me.lblToOrderItems = New System.Windows.Forms.Label()
        Me.nbxOrderLevel = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOrderLevel = New System.Windows.Forms.Label()
        Me.pnlBatch = New System.Windows.Forms.Panel()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpiryDate = New System.Windows.Forms.Label()
        Me.stbBatchNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.btnEditItem = New System.Windows.Forms.Button()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkHalted = New System.Windows.Forms.CheckBox()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.lblLocationBalance = New System.Windows.Forms.Label()
        Me.nbxLocationBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dgvInventoryLocation = New System.Windows.Forms.DataGridView()
        Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsAtHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblPhysicalStock = New System.Windows.Forms.Label()
        Me.nbxPhysicalStock = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintInventoryOnSaving = New System.Windows.Forms.CheckBox()
        Me.stbBarCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBarCode = New System.Windows.Forms.Label()
        Me.pnlAlertItems.SuspendLayout()
        Me.pnlBatch.SuspendLayout()
        CType(Me.dgvInventoryLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboItemCode
        '
        Me.cboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCode.DropDownWidth = 300
        Me.cboItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Location = New System.Drawing.Point(141, 26)
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(174, 21)
        Me.cboItemCode.TabIndex = 3
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(10, 28)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(125, 21)
        Me.lblItemCode.TabIndex = 2
        Me.lblItemCode.Text = "Item Code"
        '
        'cboStockTypeID
        '
        Me.cboStockTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStockTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStockTypeID.FormattingEnabled = True
        Me.cboStockTypeID.Location = New System.Drawing.Point(141, 91)
        Me.cboStockTypeID.Name = "cboStockTypeID"
        Me.cboStockTypeID.Size = New System.Drawing.Size(174, 21)
        Me.cboStockTypeID.TabIndex = 9
        '
        'lblStockTypeID
        '
        Me.lblStockTypeID.Location = New System.Drawing.Point(10, 91)
        Me.lblStockTypeID.Name = "lblStockTypeID"
        Me.lblStockTypeID.Size = New System.Drawing.Size(125, 21)
        Me.lblStockTypeID.TabIndex = 8
        Me.lblStockTypeID.Text = "Stock Type"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(10, 114)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(125, 21)
        Me.lblQuantity.TabIndex = 10
        Me.lblQuantity.Text = "Quantity"
        '
        'nbxQuantity
        '
        Me.nbxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxQuantity.ControlCaption = "Quantity"
        Me.nbxQuantity.DecimalPlaces = -1
        Me.nbxQuantity.DenyNegativeEntryValue = True
        Me.nbxQuantity.Location = New System.Drawing.Point(141, 114)
        Me.nbxQuantity.MaxValue = 0.0R
        Me.nbxQuantity.MinValue = 0.0R
        Me.nbxQuantity.MustEnterNumeric = True
        Me.nbxQuantity.Name = "nbxQuantity"
        Me.nbxQuantity.Size = New System.Drawing.Size(174, 20)
        Me.nbxQuantity.TabIndex = 11
        Me.nbxQuantity.Value = ""
        '
        'lblBalance
        '
        Me.lblBalance.Location = New System.Drawing.Point(10, 135)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(125, 21)
        Me.lblBalance.TabIndex = 12
        Me.lblBalance.Text = "Balance"
        '
        'nbxBalance
        '
        Me.nbxBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBalance.ControlCaption = "Balance"
        Me.nbxBalance.DecimalPlaces = -1
        Me.nbxBalance.Enabled = False
        Me.nbxBalance.Location = New System.Drawing.Point(141, 135)
        Me.nbxBalance.MaxValue = 0.0R
        Me.nbxBalance.MinValue = 0.0R
        Me.nbxBalance.Name = "nbxBalance"
        Me.nbxBalance.Size = New System.Drawing.Size(174, 20)
        Me.nbxBalance.TabIndex = 13
        Me.nbxBalance.Value = ""
        '
        'stbDetails
        '
        Me.stbDetails.AcceptsReturn = True
        Me.stbDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDetails.CapitalizeFirstLetter = True
        Me.stbDetails.EntryErrorMSG = ""
        Me.stbDetails.Location = New System.Drawing.Point(141, 156)
        Me.stbDetails.MaxLength = 100
        Me.stbDetails.Multiline = True
        Me.stbDetails.Name = "stbDetails"
        Me.stbDetails.RegularExpression = ""
        Me.stbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDetails.Size = New System.Drawing.Size(174, 28)
        Me.stbDetails.TabIndex = 15
        '
        'lblDetails
        '
        Me.lblDetails.Location = New System.Drawing.Point(10, 158)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(125, 21)
        Me.lblDetails.TabIndex = 14
        Me.lblDetails.Text = "Details"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(17, 449)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Tag = "Inventory"
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(595, 449)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(72, 24)
        Me.btnClose.TabIndex = 38
        Me.btnClose.Text = "&Close"
        '
        'stbItemName
        '
        Me.stbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemName.CapitalizeFirstLetter = False
        Me.stbItemName.EntryErrorMSG = ""
        Me.stbItemName.Location = New System.Drawing.Point(474, 3)
        Me.stbItemName.MaxLength = 41
        Me.stbItemName.Multiline = True
        Me.stbItemName.Name = "stbItemName"
        Me.stbItemName.ReadOnly = True
        Me.stbItemName.RegularExpression = ""
        Me.stbItemName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbItemName.Size = New System.Drawing.Size(193, 26)
        Me.stbItemName.TabIndex = 20
        '
        'lblItemName
        '
        Me.lblItemName.Location = New System.Drawing.Point(328, 8)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(125, 21)
        Me.lblItemName.TabIndex = 19
        Me.lblItemName.Text = "Item Name"
        '
        'stbUnitMeasure
        '
        Me.stbUnitMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitMeasure.CapitalizeFirstLetter = True
        Me.stbUnitMeasure.Enabled = False
        Me.stbUnitMeasure.EntryErrorMSG = ""
        Me.stbUnitMeasure.Location = New System.Drawing.Point(474, 30)
        Me.stbUnitMeasure.MaxLength = 20
        Me.stbUnitMeasure.Name = "stbUnitMeasure"
        Me.stbUnitMeasure.RegularExpression = ""
        Me.stbUnitMeasure.Size = New System.Drawing.Size(193, 20)
        Me.stbUnitMeasure.TabIndex = 22
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.Location = New System.Drawing.Point(328, 29)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(125, 21)
        Me.lblUnitMeasure.TabIndex = 21
        Me.lblUnitMeasure.Text = "Unit of Measure"
        '
        'pnlAlertItems
        '
        Me.pnlAlertItems.Controls.Add(Me.btnViewToExpireItemsList)
        Me.pnlAlertItems.Controls.Add(Me.lblToExpireItems)
        Me.pnlAlertItems.Controls.Add(Me.btnViewToOrderItemsList)
        Me.pnlAlertItems.Controls.Add(Me.lblToOrderItems)
        Me.pnlAlertItems.Location = New System.Drawing.Point(323, 185)
        Me.pnlAlertItems.Name = "pnlAlertItems"
        Me.pnlAlertItems.Size = New System.Drawing.Size(353, 59)
        Me.pnlAlertItems.TabIndex = 33
        '
        'btnViewToExpireItemsList
        '
        Me.btnViewToExpireItemsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireItemsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireItemsList.Location = New System.Drawing.Point(276, 28)
        Me.btnViewToExpireItemsList.Name = "btnViewToExpireItemsList"
        Me.btnViewToExpireItemsList.Size = New System.Drawing.Size(68, 24)
        Me.btnViewToExpireItemsList.TabIndex = 3
        Me.btnViewToExpireItemsList.Tag = ""
        Me.btnViewToExpireItemsList.Text = "&View List"
        '
        'lblToExpireItems
        '
        Me.lblToExpireItems.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToExpireItems.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireItems.Location = New System.Drawing.Point(9, 32)
        Me.lblToExpireItems.Name = "lblToExpireItems"
        Me.lblToExpireItems.Size = New System.Drawing.Size(261, 20)
        Me.lblToExpireItems.TabIndex = 2
        Me.lblToExpireItems.Text = "To Expire/Expired Items: 0"
        '
        'btnViewToOrderItemsList
        '
        Me.btnViewToOrderItemsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderItemsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderItemsList.Location = New System.Drawing.Point(276, 3)
        Me.btnViewToOrderItemsList.Name = "btnViewToOrderItemsList"
        Me.btnViewToOrderItemsList.Size = New System.Drawing.Size(68, 24)
        Me.btnViewToOrderItemsList.TabIndex = 1
        Me.btnViewToOrderItemsList.Tag = ""
        Me.btnViewToOrderItemsList.Text = "&View List"
        '
        'lblToOrderItems
        '
        Me.lblToOrderItems.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToOrderItems.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderItems.Location = New System.Drawing.Point(9, 7)
        Me.lblToOrderItems.Name = "lblToOrderItems"
        Me.lblToOrderItems.Size = New System.Drawing.Size(261, 20)
        Me.lblToOrderItems.TabIndex = 0
        Me.lblToOrderItems.Text = "To Order Items: 0"
        '
        'nbxOrderLevel
        '
        Me.nbxOrderLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOrderLevel.ControlCaption = "Order Level"
        Me.nbxOrderLevel.DecimalPlaces = -1
        Me.nbxOrderLevel.Enabled = False
        Me.nbxOrderLevel.Location = New System.Drawing.Point(474, 51)
        Me.nbxOrderLevel.MaxValue = 0.0R
        Me.nbxOrderLevel.MinValue = 0.0R
        Me.nbxOrderLevel.MustEnterNumeric = True
        Me.nbxOrderLevel.Name = "nbxOrderLevel"
        Me.nbxOrderLevel.Size = New System.Drawing.Size(193, 20)
        Me.nbxOrderLevel.TabIndex = 24
        Me.nbxOrderLevel.Value = ""
        '
        'lblOrderLevel
        '
        Me.lblOrderLevel.Location = New System.Drawing.Point(328, 51)
        Me.lblOrderLevel.Name = "lblOrderLevel"
        Me.lblOrderLevel.Size = New System.Drawing.Size(125, 21)
        Me.lblOrderLevel.TabIndex = 23
        Me.lblOrderLevel.Text = "Order Level"
        '
        'pnlBatch
        '
        Me.pnlBatch.Controls.Add(Me.dtpExpiryDate)
        Me.pnlBatch.Controls.Add(Me.lblExpiryDate)
        Me.pnlBatch.Controls.Add(Me.stbBatchNo)
        Me.pnlBatch.Controls.Add(Me.lblBatchNo)
        Me.pnlBatch.Location = New System.Drawing.Point(4, 185)
        Me.pnlBatch.Name = "pnlBatch"
        Me.pnlBatch.Size = New System.Drawing.Size(321, 72)
        Me.pnlBatch.TabIndex = 16
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.Checked = False
        Me.dtpExpiryDate.Location = New System.Drawing.Point(137, 46)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.ShowCheckBox = True
        Me.dtpExpiryDate.Size = New System.Drawing.Size(174, 20)
        Me.dtpExpiryDate.TabIndex = 3
        '
        'lblExpiryDate
        '
        Me.lblExpiryDate.Location = New System.Drawing.Point(6, 48)
        Me.lblExpiryDate.Name = "lblExpiryDate"
        Me.lblExpiryDate.Size = New System.Drawing.Size(125, 21)
        Me.lblExpiryDate.TabIndex = 2
        Me.lblExpiryDate.Text = "Expiry Date"
        '
        'stbBatchNo
        '
        Me.stbBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBatchNo.CapitalizeFirstLetter = False
        Me.stbBatchNo.EntryErrorMSG = ""
        Me.stbBatchNo.Location = New System.Drawing.Point(137, 3)
        Me.stbBatchNo.MaxLength = 20
        Me.stbBatchNo.Name = "stbBatchNo"
        Me.stbBatchNo.RegularExpression = ""
        Me.stbBatchNo.Size = New System.Drawing.Size(174, 20)
        Me.stbBatchNo.TabIndex = 1
        '
        'lblBatchNo
        '
        Me.lblBatchNo.Location = New System.Drawing.Point(6, 4)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(125, 21)
        Me.lblBatchNo.TabIndex = 0
        Me.lblBatchNo.Text = "Batch No"
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Location = New System.Drawing.Point(141, 49)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ShowCheckBox = True
        Me.dtpTransactionDate.Size = New System.Drawing.Size(174, 20)
        Me.dtpTransactionDate.TabIndex = 5
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(10, 49)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(125, 21)
        Me.lblTransactionDate.TabIndex = 4
        Me.lblTransactionDate.Text = "Transaction Date"
        '
        'nbxUnitCost
        '
        Me.nbxUnitCost.BackColor = System.Drawing.SystemColors.Info
        Me.nbxUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitCost.ControlCaption = "Unit Cost"
        Me.nbxUnitCost.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxUnitCost.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitCost.DecimalPlaces = -1
        Me.nbxUnitCost.Location = New System.Drawing.Point(474, 72)
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.ReadOnly = True
        Me.nbxUnitCost.Size = New System.Drawing.Size(193, 20)
        Me.nbxUnitCost.TabIndex = 26
        Me.nbxUnitCost.Value = ""
        '
        'lblUnitCost
        '
        Me.lblUnitCost.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUnitCost.Location = New System.Drawing.Point(328, 72)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(125, 21)
        Me.lblUnitCost.TabIndex = 25
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = -1
        Me.nbxUnitPrice.Location = New System.Drawing.Point(474, 93)
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.ReadOnly = True
        Me.nbxUnitPrice.Size = New System.Drawing.Size(193, 20)
        Me.nbxUnitPrice.TabIndex = 28
        Me.nbxUnitPrice.Value = ""
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblUnitPrice.Location = New System.Drawing.Point(328, 93)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(125, 21)
        Me.lblUnitPrice.TabIndex = 27
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'btnEditItem
        '
        Me.btnEditItem.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEditItem.Enabled = False
        Me.btnEditItem.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditItem.Location = New System.Drawing.Point(279, 449)
        Me.btnEditItem.Name = "btnEditItem"
        Me.btnEditItem.Size = New System.Drawing.Size(106, 24)
        Me.btnEditItem.TabIndex = 36
        Me.btnEditItem.Tag = "Drugs"
        Me.btnEditItem.Text = "E&dit Item"
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHidden.Enabled = False
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(516, 137)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(151, 20)
        Me.chkHidden.TabIndex = 32
        Me.chkHidden.Text = "Hidden"
        '
        'chkHalted
        '
        Me.chkHalted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHalted.Enabled = False
        Me.chkHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHalted.Location = New System.Drawing.Point(328, 137)
        Me.chkHalted.Name = "chkHalted"
        Me.chkHalted.Size = New System.Drawing.Size(156, 20)
        Me.chkHalted.TabIndex = 31
        Me.chkHalted.Text = "Halted"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(141, 3)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(174, 21)
        Me.cboLocationID.TabIndex = 1
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(10, 4)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(125, 21)
        Me.lblLocationID.TabIndex = 0
        Me.lblLocationID.Text = "Location"
        '
        'lblLocationBalance
        '
        Me.lblLocationBalance.Location = New System.Drawing.Point(328, 114)
        Me.lblLocationBalance.Name = "lblLocationBalance"
        Me.lblLocationBalance.Size = New System.Drawing.Size(125, 21)
        Me.lblLocationBalance.TabIndex = 29
        Me.lblLocationBalance.Text = "Location Balance"
        '
        'nbxLocationBalance
        '
        Me.nbxLocationBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxLocationBalance.ControlCaption = "Location Balance"
        Me.nbxLocationBalance.DecimalPlaces = -1
        Me.nbxLocationBalance.Enabled = False
        Me.nbxLocationBalance.Location = New System.Drawing.Point(474, 114)
        Me.nbxLocationBalance.MaxValue = 0.0R
        Me.nbxLocationBalance.MinValue = 0.0R
        Me.nbxLocationBalance.Name = "nbxLocationBalance"
        Me.nbxLocationBalance.Size = New System.Drawing.Size(193, 20)
        Me.nbxLocationBalance.TabIndex = 30
        Me.nbxLocationBalance.Value = ""
        '
        'dgvInventoryLocation
        '
        Me.dgvInventoryLocation.AllowUserToAddRows = False
        Me.dgvInventoryLocation.AllowUserToDeleteRows = False
        Me.dgvInventoryLocation.AllowUserToOrderColumns = True
        Me.dgvInventoryLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryLocation.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInventoryLocation.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryLocation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryLocation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLocation, Me.colUnitsAtHand, Me.colBatchNo, Me.colExpiryDate})
        Me.dgvInventoryLocation.EnableHeadersVisualStyles = False
        Me.dgvInventoryLocation.GridColor = System.Drawing.Color.Khaki
        Me.dgvInventoryLocation.Location = New System.Drawing.Point(13, 263)
        Me.dgvInventoryLocation.Name = "dgvInventoryLocation"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryLocation.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInventoryLocation.RowHeadersVisible = False
        Me.dgvInventoryLocation.Size = New System.Drawing.Size(654, 172)
        Me.dgvInventoryLocation.TabIndex = 32
        Me.dgvInventoryLocation.Text = "DataGridView1"
        '
        'colLocation
        '
        Me.colLocation.DataPropertyName = "Location"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colLocation.DefaultCellStyle = DataGridViewCellStyle2
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.MaxInputLength = 100
        Me.colLocation.Name = "colLocation"
        Me.colLocation.ReadOnly = True
        Me.colLocation.Width = 250
        '
        'colUnitsAtHand
        '
        Me.colUnitsAtHand.DataPropertyName = "UnitsAtHand"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsAtHand.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitsAtHand.HeaderText = "Units At Hand"
        Me.colUnitsAtHand.Name = "colUnitsAtHand"
        Me.colUnitsAtHand.ReadOnly = True
        '
        'colBatchNo
        '
        Me.colBatchNo.DataPropertyName = "BatchNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colBatchNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 120
        '
        'lblPhysicalStock
        '
        Me.lblPhysicalStock.Location = New System.Drawing.Point(10, 69)
        Me.lblPhysicalStock.Name = "lblPhysicalStock"
        Me.lblPhysicalStock.Size = New System.Drawing.Size(125, 21)
        Me.lblPhysicalStock.TabIndex = 6
        Me.lblPhysicalStock.Text = "Physical Stock (Qty)"
        '
        'nbxPhysicalStock
        '
        Me.nbxPhysicalStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPhysicalStock.ControlCaption = "Physical Stock (Qty)"
        Me.nbxPhysicalStock.DecimalPlaces = -1
        Me.nbxPhysicalStock.DenyNegativeEntryValue = True
        Me.nbxPhysicalStock.Location = New System.Drawing.Point(141, 69)
        Me.nbxPhysicalStock.MaxValue = 0.0R
        Me.nbxPhysicalStock.MinValue = 0.0R
        Me.nbxPhysicalStock.MustEnterNumeric = True
        Me.nbxPhysicalStock.Name = "nbxPhysicalStock"
        Me.nbxPhysicalStock.Size = New System.Drawing.Size(174, 20)
        Me.nbxPhysicalStock.TabIndex = 7
        Me.nbxPhysicalStock.Value = ""
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(505, 449)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 24)
        Me.btnPrint.TabIndex = 37
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintInventoryOnSaving
        '
        Me.chkPrintInventoryOnSaving.AccessibleDescription = ""
        Me.chkPrintInventoryOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInventoryOnSaving.AutoSize = True
        Me.chkPrintInventoryOnSaving.Enabled = False
        Me.chkPrintInventoryOnSaving.Location = New System.Drawing.Point(95, 456)
        Me.chkPrintInventoryOnSaving.Name = "chkPrintInventoryOnSaving"
        Me.chkPrintInventoryOnSaving.Size = New System.Drawing.Size(103, 17)
        Me.chkPrintInventoryOnSaving.TabIndex = 35
        Me.chkPrintInventoryOnSaving.Text = " Print On Saving"
        '
        'stbBarCode
        '
        Me.stbBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBarCode.CapitalizeFirstLetter = False
        Me.stbBarCode.EntryErrorMSG = ""
        Me.stbBarCode.Location = New System.Drawing.Point(141, 209)
        Me.stbBarCode.MaxLength = 20
        Me.stbBarCode.Name = "stbBarCode"
        Me.stbBarCode.RegularExpression = ""
        Me.stbBarCode.Size = New System.Drawing.Size(174, 20)
        Me.stbBarCode.TabIndex = 18
        '
        'lblBarCode
        '
        Me.lblBarCode.Location = New System.Drawing.Point(10, 210)
        Me.lblBarCode.Name = "lblBarCode"
        Me.lblBarCode.Size = New System.Drawing.Size(125, 21)
        Me.lblBarCode.TabIndex = 17
        Me.lblBarCode.Text = "Bar Code"
        '
        'frmInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(685, 485)
        Me.Controls.Add(Me.stbBarCode)
        Me.Controls.Add(Me.lblBarCode)
        Me.Controls.Add(Me.chkPrintInventoryOnSaving)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblPhysicalStock)
        Me.Controls.Add(Me.nbxPhysicalStock)
        Me.Controls.Add(Me.dgvInventoryLocation)
        Me.Controls.Add(Me.lblLocationBalance)
        Me.Controls.Add(Me.nbxLocationBalance)
        Me.Controls.Add(Me.pnlAlertItems)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.chkHalted)
        Me.Controls.Add(Me.chkHidden)
        Me.Controls.Add(Me.btnEditItem)
        Me.Controls.Add(Me.nbxUnitCost)
        Me.Controls.Add(Me.lblUnitCost)
        Me.Controls.Add(Me.nbxUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.dtpTransactionDate)
        Me.Controls.Add(Me.lblTransactionDate)
        Me.Controls.Add(Me.pnlBatch)
        Me.Controls.Add(Me.nbxOrderLevel)
        Me.Controls.Add(Me.lblOrderLevel)
        Me.Controls.Add(Me.stbUnitMeasure)
        Me.Controls.Add(Me.lblUnitMeasure)
        Me.Controls.Add(Me.stbItemName)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.stbDetails)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.lblBalance)
        Me.Controls.Add(Me.nbxBalance)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.nbxQuantity)
        Me.Controls.Add(Me.cboItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.cboStockTypeID)
        Me.Controls.Add(Me.lblStockTypeID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInventory"
        Me.Text = "Inventory"
        Me.pnlAlertItems.ResumeLayout(False)
        Me.pnlBatch.ResumeLayout(False)
        Me.pnlBatch.PerformLayout()
        CType(Me.dgvInventoryLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents cboStockTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblStockTypeID As System.Windows.Forms.Label
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents nbxQuantity As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents nbxBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents stbDetails As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDetails As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents stbItemName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents stbUnitMeasure As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitMeasure As System.Windows.Forms.Label
    Friend WithEvents pnlAlertItems As System.Windows.Forms.Panel
    Friend WithEvents btnViewToOrderItemsList As System.Windows.Forms.Button
    Friend WithEvents lblToOrderItems As System.Windows.Forms.Label
    Friend WithEvents nbxOrderLevel As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOrderLevel As System.Windows.Forms.Label
    Friend WithEvents pnlBatch As System.Windows.Forms.Panel
    Friend WithEvents stbBatchNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents btnViewToExpireItemsList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireItems As System.Windows.Forms.Label
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents nbxUnitPrice As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents btnEditItem As System.Windows.Forms.Button
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents chkHalted As System.Windows.Forms.CheckBox
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents lblLocationBalance As System.Windows.Forms.Label
    Friend WithEvents nbxLocationBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dgvInventoryLocation As System.Windows.Forms.DataGridView
    Friend WithEvents lblPhysicalStock As System.Windows.Forms.Label
    Friend WithEvents nbxPhysicalStock As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsAtHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintInventoryOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents stbBarCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBarCode As System.Windows.Forms.Label
End Class
