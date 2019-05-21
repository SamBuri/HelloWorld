
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintInventoryAcknowledges : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintInventoryAcknowledges))
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
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.dgvInventoryAcknowledges = New System.Windows.Forms.DataGridView()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFromLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbReceivedDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        CType(Me.dgvInventoryAcknowledges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(806, 399)
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
        Me.stbTransferNo.Size = New System.Drawing.Size(130, 20)
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
        Me.lblFromLocationID.Location = New System.Drawing.Point(324, 5)
        Me.lblFromLocationID.Name = "lblFromLocationID"
        Me.lblFromLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblFromLocationID.TabIndex = 7
        Me.lblFromLocationID.Text = "From Location"
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(324, 26)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(119, 20)
        Me.lblToLocationID.TabIndex = 9
        Me.lblToLocationID.Text = "To Location"
        '
        'stbToLocation
        '
        Me.stbToLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbToLocation.CapitalizeFirstLetter = False
        Me.stbToLocation.Enabled = False
        Me.stbToLocation.EntryErrorMSG = ""
        Me.stbToLocation.Location = New System.Drawing.Point(449, 26)
        Me.stbToLocation.MaxLength = 100
        Me.stbToLocation.Name = "stbToLocation"
        Me.stbToLocation.RegularExpression = ""
        Me.stbToLocation.Size = New System.Drawing.Size(180, 20)
        Me.stbToLocation.TabIndex = 10
        '
        'stbFromLocation
        '
        Me.stbFromLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFromLocation.CapitalizeFirstLetter = False
        Me.stbFromLocation.Enabled = False
        Me.stbFromLocation.EntryErrorMSG = ""
        Me.stbFromLocation.Location = New System.Drawing.Point(449, 5)
        Me.stbFromLocation.MaxLength = 100
        Me.stbFromLocation.Name = "stbFromLocation"
        Me.stbFromLocation.RegularExpression = ""
        Me.stbFromLocation.Size = New System.Drawing.Size(180, 20)
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
        Me.stbTransferDate.Size = New System.Drawing.Size(180, 20)
        Me.stbTransferDate.TabIndex = 4
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(269, 1)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(49, 24)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
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
        Me.dgvInventoryAcknowledges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colFromLocationBalance, Me.colToLocationBalance, Me.colQuantity, Me.colBatchNo, Me.colExpiryDate, Me.colStockStatus})
        Me.dgvInventoryAcknowledges.EnableHeadersVisualStyles = False
        Me.dgvInventoryAcknowledges.GridColor = System.Drawing.Color.Khaki
        Me.dgvInventoryAcknowledges.Location = New System.Drawing.Point(16, 73)
        Me.dgvInventoryAcknowledges.Name = "dgvInventoryAcknowledges"
        Me.dgvInventoryAcknowledges.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryAcknowledges.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInventoryAcknowledges.RowHeadersVisible = False
        Me.dgvInventoryAcknowledges.Size = New System.Drawing.Size(862, 320)
        Me.dgvInventoryAcknowledges.TabIndex = 11
        Me.dgvInventoryAcknowledges.Text = "DataGridView1"
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
        'stbReceivedDate
        '
        Me.stbReceivedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReceivedDate.CapitalizeFirstLetter = False
        Me.stbReceivedDate.Enabled = False
        Me.stbReceivedDate.EntryErrorMSG = ""
        Me.stbReceivedDate.Location = New System.Drawing.Point(138, 47)
        Me.stbReceivedDate.MaxLength = 100
        Me.stbReceivedDate.Name = "stbReceivedDate"
        Me.stbReceivedDate.RegularExpression = ""
        Me.stbReceivedDate.Size = New System.Drawing.Size(180, 20)
        Me.stbReceivedDate.TabIndex = 6
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(111, 399)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 13
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 399)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 12
        Me.btnPrint.Text = "&Print"
        '
        'frmPrintInventoryAcknowledges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(890, 439)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbReceivedDate)
        Me.Controls.Add(Me.dgvInventoryAcknowledges)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbTransferDate)
        Me.Controls.Add(Me.stbFromLocation)
        Me.Controls.Add(Me.stbToLocation)
        Me.Controls.Add(Me.lblTransferDate)
        Me.Controls.Add(Me.lblFromLocationID)
        Me.Controls.Add(Me.lblToLocationID)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbTransferNo)
        Me.Controls.Add(Me.lblTransferNo)
        Me.Controls.Add(Me.lblReceivedDate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPrintInventoryAcknowledges"
        Me.Text = "Print Inventory Acknowledges"
        CType(Me.dgvInventoryAcknowledges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbTransferNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTransferNo As System.Windows.Forms.Label
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents lblTransferDate As System.Windows.Forms.Label
    Friend WithEvents lblFromLocationID As System.Windows.Forms.Label
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents stbToLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFromLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTransferDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents dgvInventoryAcknowledges As System.Windows.Forms.DataGridView
    Friend WithEvents stbReceivedDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFromLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class