
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeliveryNote : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeliveryNote))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.stbTransferNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDeliveryLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblTransferNo = New System.Windows.Forms.Label()
        Me.lblDeliveryDate = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblDeliveryLocation = New System.Windows.Forms.Label()
        Me.dgvDeliveryNote = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CType(Me.dgvDeliveryNote, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 397)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(890, 396)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "DeliveryNote"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 424)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "DeliveryNote"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpDeliveryDate
        '
        Me.dtpDeliveryDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDeliveryDate, "DeliveryDate")
        Me.dtpDeliveryDate.Location = New System.Drawing.Point(211, 35)
        Me.dtpDeliveryDate.Name = "dtpDeliveryDate"
        Me.dtpDeliveryDate.ShowCheckBox = True
        Me.dtpDeliveryDate.Size = New System.Drawing.Size(225, 20)
        Me.dtpDeliveryDate.TabIndex = 8
        '
        'stbTransferNo
        '
        Me.stbTransferNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTransferNo, "TransferNo")
        Me.stbTransferNo.EntryErrorMSG = ""
        Me.stbTransferNo.Location = New System.Drawing.Point(211, 12)
        Me.stbTransferNo.Name = "stbTransferNo"
        Me.stbTransferNo.RegularExpression = ""
        Me.stbTransferNo.Size = New System.Drawing.Size(170, 20)
        Me.stbTransferNo.TabIndex = 13
        '
        'stbDeliveryLocation
        '
        Me.stbDeliveryLocation.BackColor = System.Drawing.SystemColors.Info
        Me.stbDeliveryLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDeliveryLocation.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDeliveryLocation, "TransferNo")
        Me.stbDeliveryLocation.EntryErrorMSG = ""
        Me.stbDeliveryLocation.Location = New System.Drawing.Point(211, 56)
        Me.stbDeliveryLocation.Name = "stbDeliveryLocation"
        Me.stbDeliveryLocation.ReadOnly = True
        Me.stbDeliveryLocation.RegularExpression = ""
        Me.stbDeliveryLocation.Size = New System.Drawing.Size(225, 20)
        Me.stbDeliveryLocation.TabIndex = 16
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(890, 423)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblTransferNo
        '
        Me.lblTransferNo.Location = New System.Drawing.Point(5, 11)
        Me.lblTransferNo.Name = "lblTransferNo"
        Me.lblTransferNo.Size = New System.Drawing.Size(200, 20)
        Me.lblTransferNo.TabIndex = 7
        Me.lblTransferNo.Text = "Transfer No"
        '
        'lblDeliveryDate
        '
        Me.lblDeliveryDate.Location = New System.Drawing.Point(5, 35)
        Me.lblDeliveryDate.Name = "lblDeliveryDate"
        Me.lblDeliveryDate.Size = New System.Drawing.Size(200, 20)
        Me.lblDeliveryDate.TabIndex = 9
        Me.lblDeliveryDate.Text = "Delivery Date"
        '
        'btnLoad
        '
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(386, 9)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(49, 24)
        Me.btnLoad.TabIndex = 14
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'lblDeliveryLocation
        '
        Me.lblDeliveryLocation.Location = New System.Drawing.Point(5, 55)
        Me.lblDeliveryLocation.Name = "lblDeliveryLocation"
        Me.lblDeliveryLocation.Size = New System.Drawing.Size(200, 20)
        Me.lblDeliveryLocation.TabIndex = 15
        Me.lblDeliveryLocation.Text = "Delivery Location"
        '
        'dgvDeliveryNote
        '
        Me.dgvDeliveryNote.AllowUserToAddRows = False
        Me.dgvDeliveryNote.AllowUserToDeleteRows = False
        Me.dgvDeliveryNote.AllowUserToOrderColumns = True
        Me.dgvDeliveryNote.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDeliveryNote.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDeliveryNote.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeliveryNote.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDeliveryNote.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colItemCategoryID, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colFromLocationBalance, Me.colToLocationBalance, Me.colPack, Me.colPackSize, Me.colQuantity, Me.colTotalUnits, Me.colUnitCost, Me.colTotalCost, Me.colBatchNo, Me.colExpiryDate, Me.colStockStatus})
        Me.dgvDeliveryNote.EnableHeadersVisualStyles = False
        Me.dgvDeliveryNote.GridColor = System.Drawing.Color.Khaki
        Me.dgvDeliveryNote.Location = New System.Drawing.Point(5, 78)
        Me.dgvDeliveryNote.Name = "dgvDeliveryNote"
        Me.dgvDeliveryNote.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDeliveryNote.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvDeliveryNote.RowHeadersVisible = False
        Me.dgvDeliveryNote.Size = New System.Drawing.Size(957, 311)
        Me.dgvDeliveryNote.TabIndex = 17
        Me.dgvDeliveryNote.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItemName.Width = 180
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle5
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 80
        '
        'colFromLocationBalance
        '
        Me.colFromLocationBalance.DataPropertyName = "FromLocationBalance"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colFromLocationBalance.DefaultCellStyle = DataGridViewCellStyle6
        Me.colFromLocationBalance.HeaderText = "From Location Balance"
        Me.colFromLocationBalance.MaxInputLength = 12
        Me.colFromLocationBalance.Name = "colFromLocationBalance"
        Me.colFromLocationBalance.ReadOnly = True
        Me.colFromLocationBalance.Width = 140
        '
        'colToLocationBalance
        '
        Me.colToLocationBalance.DataPropertyName = "ToLocationBalance"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colToLocationBalance.DefaultCellStyle = DataGridViewCellStyle7
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
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Honeydew
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colBatchNo.DefaultCellStyle = DataGridViewCellStyle9
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.MaxInputLength = 20
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        Me.colBatchNo.Width = 80
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "D"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle10
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        '
        'colStockStatus
        '
        Me.colStockStatus.DataPropertyName = "StockStatus"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colStockStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colStockStatus.HeaderText = "Stock Status"
        Me.colStockStatus.Name = "colStockStatus"
        Me.colStockStatus.ReadOnly = True
        Me.colStockStatus.Width = 80
        '
        'frmDeliveryNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(966, 459)
        Me.Controls.Add(Me.dgvDeliveryNote)
        Me.Controls.Add(Me.stbDeliveryLocation)
        Me.Controls.Add(Me.lblDeliveryLocation)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbTransferNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblTransferNo)
        Me.Controls.Add(Me.dtpDeliveryDate)
        Me.Controls.Add(Me.lblDeliveryDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDeliveryNote"
        Me.Text = "Delivery Note"
        CType(Me.dgvDeliveryNote, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblTransferNo As System.Windows.Forms.Label
    Friend WithEvents dtpDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDeliveryDate As System.Windows.Forms.Label
    Friend WithEvents stbTransferNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents stbDeliveryLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDeliveryLocation As Label
    Friend WithEvents dgvDeliveryNote As DataGridView
    Friend WithEvents colInclude As DataGridViewCheckBoxColumn
    Friend WithEvents colItemCategoryID As DataGridViewTextBoxColumn
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
End Class