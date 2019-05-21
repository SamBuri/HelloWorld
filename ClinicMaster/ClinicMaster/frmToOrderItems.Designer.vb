
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToOrderItems : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal drugItemsTo As ItemsTo, ByVal itemCategoryID As String, inlcudeState As Boolean)
        MyClass.New()
        Me.drugItemsTo = drugItemsTo
        Me.defaultItemCategoryID = itemCategoryID
        Me.inlcudeState = inlcudeState
    End Sub

    Public Sub New(ByVal drugItemsTo As ItemsTo, ByVal itemCategoryID As String, ByVal controlAlertNo As Control, inlcudeState As Boolean)
        MyClass.New(drugItemsTo, itemCategoryID, inlcudeState)
        Me.alertNoControl = controlAlertNo
        Me.inlcudeState = inlcudeState
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToOrderItems))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.colInclude = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colKeepingUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryRemainingDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncludeAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncludeNoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnOrders = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnOk = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(783, 313)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvItems
        '
        Me.dgvItems.AccessibleDescription = ""
        Me.dgvItems.AllowUserToAddRows = False
        Me.dgvItems.AllowUserToDeleteRows = False
        Me.dgvItems.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colItemCode, Me.colItemName, Me.colUnitsInStock, Me.colOrderLevel, Me.colKeepingUnit, Me.colUnitCost, Me.colUnitPrice, Me.colExpiryDate, Me.colBatchNo, Me.colExpiryRemainingDays, Me.colUnitMeasure, Me.colItemFullName})
        Me.dgvItems.ContextMenuStrip = Me.cmsAlertList
        Me.dgvItems.EnableHeadersVisualStyles = False
        Me.dgvItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvItems.Location = New System.Drawing.Point(8, 40)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvItems.RowHeadersVisible = False
        Me.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvItems.Size = New System.Drawing.Size(847, 266)
        Me.dgvItems.TabIndex = 1
        Me.dgvItems.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.ControlCaption = Nothing
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.ReadOnly = True
        Me.colInclude.SourceColumn = Nothing
        Me.colInclude.Width = 45
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 150
        '
        'colUnitsInStock
        '
        Me.colUnitsInStock.DataPropertyName = "UnitsInStock"
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colOrderLevel
        '
        Me.colOrderLevel.DataPropertyName = "OrderLevel"
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Width = 70
        '
        'colKeepingUnit
        '
        Me.colKeepingUnit.DataPropertyName = "KeepingUnit"
        Me.colKeepingUnit.HeaderText = "Keeping Unit"
        Me.colKeepingUnit.Name = "colKeepingUnit"
        Me.colKeepingUnit.ReadOnly = True
        Me.colKeepingUnit.Width = 80
        '
        'colUnitCost
        '
        Me.colUnitCost.DataPropertyName = "UnitCost"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitCost.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitCost.HeaderText = "Unit Cost"
        Me.colUnitCost.Name = "colUnitCost"
        Me.colUnitCost.ReadOnly = True
        Me.colUnitCost.Width = 70
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle4
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 70
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 80
        '
        'colBatchNo
        '
        Me.colBatchNo.DataPropertyName = "BatchNo"
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        Me.colBatchNo.Width = 60
        '
        'colExpiryRemainingDays
        '
        Me.colExpiryRemainingDays.DataPropertyName = "ExpiryRemainingDays"
        Me.colExpiryRemainingDays.HeaderText = "Expiry Remaining Days"
        Me.colExpiryRemainingDays.Name = "colExpiryRemainingDays"
        Me.colExpiryRemainingDays.ReadOnly = True
        Me.colExpiryRemainingDays.Width = 120
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 80
        '
        'colItemFullName
        '
        Me.colItemFullName.DataPropertyName = "ItemFullName"
        Me.colItemFullName.HeaderText = "Item Full Name"
        Me.colItemFullName.Name = "colItemFullName"
        Me.colItemFullName.ReadOnly = True
        Me.colItemFullName.Visible = False
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll, Me.cmsAlertListInventory, Me.IncludeAllToolStripMenuItem, Me.IncludeNoneToolStripMenuItem})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(157, 114)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(156, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(156, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'cmsAlertListInventory
        '
        Me.cmsAlertListInventory.Enabled = False
        Me.cmsAlertListInventory.Image = CType(resources.GetObject("cmsAlertListInventory.Image"), System.Drawing.Image)
        Me.cmsAlertListInventory.Name = "cmsAlertListInventory"
        Me.cmsAlertListInventory.Size = New System.Drawing.Size(156, 22)
        Me.cmsAlertListInventory.Tag = "DrugInventory"
        Me.cmsAlertListInventory.Text = "Go to Inventory"
        '
        'IncludeAllToolStripMenuItem
        '
        Me.IncludeAllToolStripMenuItem.Enabled = False
        Me.IncludeAllToolStripMenuItem.Name = "IncludeAllToolStripMenuItem"
        Me.IncludeAllToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.IncludeAllToolStripMenuItem.Text = "Include All"
        '
        'IncludeNoneToolStripMenuItem
        '
        Me.IncludeNoneToolStripMenuItem.Enabled = False
        Me.IncludeNoneToolStripMenuItem.Name = "IncludeNoneToolStripMenuItem"
        Me.IncludeNoneToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.IncludeNoneToolStripMenuItem.Text = "Include None"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(264, 317)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(12, 12)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 0
        Me.fbnExportTo.Text = "&Export to Excel..."
        '
        'fbnOrders
        '
        Me.fbnOrders.Enabled = False
        Me.fbnOrders.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOrders.Location = New System.Drawing.Point(747, 12)
        Me.fbnOrders.Name = "fbnOrders"
        Me.fbnOrders.Size = New System.Drawing.Size(106, 22)
        Me.fbnOrders.TabIndex = 4
        Me.fbnOrders.Tag = "InventoryOrders"
        Me.fbnOrders.Text = "&Inventory Orders..."
        Me.fbnOrders.Visible = False
        '
        'fbnOk
        '
        Me.fbnOk.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOk.Location = New System.Drawing.Point(12, 315)
        Me.fbnOk.Name = "fbnOk"
        Me.fbnOk.Size = New System.Drawing.Size(83, 22)
        Me.fbnOk.TabIndex = 11
        Me.fbnOk.Tag = ""
        Me.fbnOk.Text = "Ok"
        Me.fbnOk.Visible = False
        '
        'frmToOrderItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(865, 349)
        Me.Controls.Add(Me.fbnOk)
        Me.Controls.Add(Me.fbnOrders)
        Me.Controls.Add(Me.fbnExportTo)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmToOrderItems"
        Me.Text = "To Order Drugs List"
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cmsAlertListInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbnOrders As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colInclude As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colKeepingUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryRemainingDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IncludeAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncludeNoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbnOk As SyncSoft.Common.Win.Controls.FlatButton

End Class