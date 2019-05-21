
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessInventoryOrders : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessInventoryOrders))
        Me.fbnInventoryTransfers = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOrderNo = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.lblFromLocationID = New System.Windows.Forms.Label()
        Me.lblToLocationID = New System.Windows.Forms.Label()
        Me.stbToLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFromLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbOrderDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadPendingInventoryOrders = New System.Windows.Forms.Button()
        Me.dgvInventoryOrderDetails = New System.Windows.Forms.DataGridView()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUnProcessedIventoryOrders = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvInventoryOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnInventoryTransfers
        '
        Me.fbnInventoryTransfers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnInventoryTransfers.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnInventoryTransfers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnInventoryTransfers.Location = New System.Drawing.Point(16, 354)
        Me.fbnInventoryTransfers.Name = "fbnInventoryTransfers"
        Me.fbnInventoryTransfers.Size = New System.Drawing.Size(116, 24)
        Me.fbnInventoryTransfers.TabIndex = 10
        Me.fbnInventoryTransfers.Tag = "InventoryTransfers"
        Me.fbnInventoryTransfers.Text = "&Inventory Transfers"
        Me.fbnInventoryTransfers.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(558, 354)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbOrderNo
        '
        Me.stbOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderNo.CapitalizeFirstLetter = False
        Me.stbOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbOrderNo.EntryErrorMSG = ""
        Me.stbOrderNo.Location = New System.Drawing.Point(138, 23)
        Me.stbOrderNo.MaxLength = 20
        Me.stbOrderNo.Name = "stbOrderNo"
        Me.stbOrderNo.RegularExpression = ""
        Me.stbOrderNo.Size = New System.Drawing.Size(130, 20)
        Me.stbOrderNo.TabIndex = 1
        '
        'lblOrderNo
        '
        Me.lblOrderNo.Location = New System.Drawing.Point(13, 23)
        Me.lblOrderNo.Name = "lblOrderNo"
        Me.lblOrderNo.Size = New System.Drawing.Size(119, 20)
        Me.lblOrderNo.TabIndex = 0
        Me.lblOrderNo.Text = "Order No"
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
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(13, 45)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(119, 20)
        Me.lblOrderDate.TabIndex = 3
        Me.lblOrderDate.Text = "Order Date"
        '
        'lblFromLocationID
        '
        Me.lblFromLocationID.Location = New System.Drawing.Point(324, 23)
        Me.lblFromLocationID.Name = "lblFromLocationID"
        Me.lblFromLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblFromLocationID.TabIndex = 5
        Me.lblFromLocationID.Text = "From Location"
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(324, 44)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblToLocationID.TabIndex = 7
        Me.lblToLocationID.Text = "To Location"
        '
        'stbToLocation
        '
        Me.stbToLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbToLocation.CapitalizeFirstLetter = False
        Me.stbToLocation.Enabled = False
        Me.stbToLocation.EntryErrorMSG = ""
        Me.stbToLocation.Location = New System.Drawing.Point(449, 44)
        Me.stbToLocation.MaxLength = 100
        Me.stbToLocation.Name = "stbToLocation"
        Me.stbToLocation.RegularExpression = ""
        Me.stbToLocation.Size = New System.Drawing.Size(180, 20)
        Me.stbToLocation.TabIndex = 8
        '
        'stbFromLocation
        '
        Me.stbFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFromLocation.CapitalizeFirstLetter = False
        Me.stbFromLocation.Enabled = False
        Me.stbFromLocation.EntryErrorMSG = ""
        Me.stbFromLocation.Location = New System.Drawing.Point(449, 23)
        Me.stbFromLocation.MaxLength = 100
        Me.stbFromLocation.Name = "stbFromLocation"
        Me.stbFromLocation.RegularExpression = ""
        Me.stbFromLocation.Size = New System.Drawing.Size(180, 20)
        Me.stbFromLocation.TabIndex = 6
        '
        'stbOrderDate
        '
        Me.stbOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderDate.CapitalizeFirstLetter = False
        Me.stbOrderDate.Enabled = False
        Me.stbOrderDate.EntryErrorMSG = ""
        Me.stbOrderDate.Location = New System.Drawing.Point(138, 44)
        Me.stbOrderDate.MaxLength = 30
        Me.stbOrderDate.Name = "stbOrderDate"
        Me.stbOrderDate.RegularExpression = ""
        Me.stbOrderDate.Size = New System.Drawing.Size(180, 20)
        Me.stbOrderDate.TabIndex = 4
        '
        'btnLoadPendingInventoryOrders
        '
        Me.btnLoadPendingInventoryOrders.AccessibleDescription = ""
        Me.btnLoadPendingInventoryOrders.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingInventoryOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingInventoryOrders.Location = New System.Drawing.Point(269, 19)
        Me.btnLoadPendingInventoryOrders.Name = "btnLoadPendingInventoryOrders"
        Me.btnLoadPendingInventoryOrders.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingInventoryOrders.TabIndex = 2
        Me.btnLoadPendingInventoryOrders.Tag = ""
        Me.btnLoadPendingInventoryOrders.Text = "&Load"
        '
        'dgvInventoryOrderDetails
        '
        Me.dgvInventoryOrderDetails.AllowUserToAddRows = False
        Me.dgvInventoryOrderDetails.AllowUserToDeleteRows = False
        Me.dgvInventoryOrderDetails.AllowUserToOrderColumns = True
        Me.dgvInventoryOrderDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryOrderDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInventoryOrderDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryOrderDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryOrderDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colLocationBalance, Me.colQuantity, Me.colItemCategoryID})
        Me.dgvInventoryOrderDetails.EnableHeadersVisualStyles = False
        Me.dgvInventoryOrderDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInventoryOrderDetails.Location = New System.Drawing.Point(16, 89)
        Me.dgvInventoryOrderDetails.Name = "dgvInventoryOrderDetails"
        Me.dgvInventoryOrderDetails.ReadOnly = True
        Me.dgvInventoryOrderDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryOrderDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInventoryOrderDetails.RowHeadersVisible = False
        Me.dgvInventoryOrderDetails.Size = New System.Drawing.Size(614, 259)
        Me.dgvInventoryOrderDetails.TabIndex = 9
        Me.dgvInventoryOrderDetails.Text = "DataGridView1"
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 80
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
        Me.colItemName.Width = 250
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colLocationBalance
        '
        Me.colLocationBalance.DataPropertyName = "LocationBalance"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colLocationBalance.DefaultCellStyle = DataGridViewCellStyle5
        Me.colLocationBalance.HeaderText = "Location Balance"
        Me.colLocationBalance.MaxInputLength = 12
        Me.colLocationBalance.Name = "colLocationBalance"
        Me.colLocationBalance.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle7
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'lblUnProcessedIventoryOrders
        '
        Me.lblUnProcessedIventoryOrders.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnProcessedIventoryOrders.ForeColor = System.Drawing.Color.Red
        Me.lblUnProcessedIventoryOrders.Location = New System.Drawing.Point(13, 66)
        Me.lblUnProcessedIventoryOrders.Name = "lblUnProcessedIventoryOrders"
        Me.lblUnProcessedIventoryOrders.Size = New System.Drawing.Size(266, 20)
        Me.lblUnProcessedIventoryOrders.TabIndex = 12
        Me.lblUnProcessedIventoryOrders.Text = "UnProcessed Iventory Orders: 0"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'frmProcessInventoryOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(642, 394)
        Me.Controls.Add(Me.lblUnProcessedIventoryOrders)
        Me.Controls.Add(Me.dgvInventoryOrderDetails)
        Me.Controls.Add(Me.btnLoadPendingInventoryOrders)
        Me.Controls.Add(Me.stbOrderDate)
        Me.Controls.Add(Me.stbFromLocation)
        Me.Controls.Add(Me.stbToLocation)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.lblFromLocationID)
        Me.Controls.Add(Me.lblToLocationID)
        Me.Controls.Add(Me.fbnInventoryTransfers)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbOrderNo)
        Me.Controls.Add(Me.lblOrderNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmProcessInventoryOrders"
        Me.Text = "Process Inventory Orders"
        CType(Me.dgvInventoryOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnInventoryTransfers As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOrderNo As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents lblFromLocationID As System.Windows.Forms.Label
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents stbToLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFromLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbOrderDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadPendingInventoryOrders As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryOrderDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblUnProcessedIventoryOrders As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer

End Class