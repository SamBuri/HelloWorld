<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetToCountInventoryLocation
    Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Public Sub New(ByVal drugItemsTo As ItemsTo, ByVal itemCategoryID As String, ByVal LocationID As String)
    '    MyClass.New()
    '    Me.drugItemsTo = drugItemsTo
    '    Me.defaultItemCategoryID = itemCategoryID
    '    Me.LocationID = LocationID
    'End Sub
    Public Sub New(ByVal LocationID As String, ByVal ItemCategoryID As String, ByVal drugItemsTo As ItemsTo)
        MyClass.New()
        Me.LocationID = LocationID
        Me.ItemCategoryID = ItemCategoryID
        Me.drugItemsTo = drugItemsTo
    End Sub

    Public Sub New(ByVal LocationID As String, ByVal ItemCategoryID As String, ByVal drugItemsTo As ItemsTo, ByVal HideOptions As Boolean)
        MyClass.New()
        Me.LocationID = LocationID
        Me.ItemCategoryID = ItemCategoryID
        Me.drugItemsTo = drugItemsTo
        Me.HideOptions = HideOptions
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetToCountInventoryLocation))
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.ColInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.StorageLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryRemainingDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsItemsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsItemsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsItemsIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsItemsIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnOk = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(12, 9)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 5
        Me.fbnExportTo.Text = "&Export to Excel..."
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
        Me.dgvItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInclude, Me.StorageLocation, Me.colItemCode, Me.colItemName, Me.colUnitsInStock, Me.colOrderLevel, Me.colUnitCost, Me.colExpiryDate, Me.colBatchNo, Me.colExpiryRemainingDays, Me.colUnitMeasure, Me.colItemFullName})
        Me.dgvItems.ContextMenuStrip = Me.cmsItems
        Me.dgvItems.EnableHeadersVisualStyles = False
        Me.dgvItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvItems.Location = New System.Drawing.Point(8, 37)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.ReadOnly = True
        Me.dgvItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItems.RowHeadersVisible = False
        Me.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvItems.Size = New System.Drawing.Size(939, 326)
        Me.dgvItems.TabIndex = 6
        Me.dgvItems.Text = "DataGridView1"
        '
        'ColInclude
        '
        Me.ColInclude.HeaderText = "Include"
        Me.ColInclude.Name = "ColInclude"
        Me.ColInclude.ReadOnly = True
        Me.ColInclude.Width = 45
        '
        'StorageLocation
        '
        Me.StorageLocation.DataPropertyName = "Location"
        Me.StorageLocation.HeaderText = "Storage Location"
        Me.StorageLocation.MaxInputLength = 20
        Me.StorageLocation.Name = "StorageLocation"
        Me.StorageLocation.ReadOnly = True
        Me.StorageLocation.Width = 150
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
        Me.colUnitsInStock.DataPropertyName = "UnitsAtHand"
        Me.colUnitsInStock.HeaderText = "Units At Hand"
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
        'cmsItems
        '
        Me.cmsItems.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsItemsCopy, Me.cmsItemsSelectAll, Me.ToolStripMenuItem1, Me.cmsItemsIncludeAll, Me.cmsItemsIncludeNone})
        Me.cmsItems.Name = "cmsSearch"
        Me.cmsItems.Size = New System.Drawing.Size(146, 98)
        '
        'cmsItemsCopy
        '
        Me.cmsItemsCopy.Image = CType(resources.GetObject("cmsItemsCopy.Image"), System.Drawing.Image)
        Me.cmsItemsCopy.Name = "cmsItemsCopy"
        Me.cmsItemsCopy.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsCopy.Text = "Copy"
        Me.cmsItemsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsItemsSelectAll
        '
        Me.cmsItemsSelectAll.Name = "cmsItemsSelectAll"
        Me.cmsItemsSelectAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsSelectAll.Text = "Select All"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(142, 6)
        '
        'cmsItemsIncludeAll
        '
        Me.cmsItemsIncludeAll.Name = "cmsItemsIncludeAll"
        Me.cmsItemsIncludeAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsIncludeAll.Text = "Include All"
        '
        'cmsItemsIncludeNone
        '
        Me.cmsItemsIncludeNone.Name = "cmsItemsIncludeNone"
        Me.cmsItemsIncludeNone.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsIncludeNone.Text = "Include None"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(875, 395)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'fbnOk
        '
        Me.fbnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnOk.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOk.Location = New System.Drawing.Point(13, 397)
        Me.fbnOk.Name = "fbnOk"
        Me.fbnOk.Size = New System.Drawing.Size(83, 22)
        Me.fbnOk.TabIndex = 10
        Me.fbnOk.Tag = ""
        Me.fbnOk.Text = "Ok"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(323, 394)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 12
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmGetToCountInventoryLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 428)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnOk)
        Me.Controls.Add(Me.fbnExportTo)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmGetToCountInventoryLocation"
        Me.Text = "To Order Items Per Location"
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsItems.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvItems As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ColInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents StorageLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryRemainingDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnOk As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmsItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsItemsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsItemsIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsIncludeNone As System.Windows.Forms.ToolStripMenuItem
End Class
