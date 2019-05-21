
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodsReceivedNote : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGoodsReceivedNote))
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpReceivedDate = New System.Windows.Forms.DateTimePicker()
        Me.stbAdviceNoteNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDeliveryLocationID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbGRNNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGRNNo = New System.Windows.Forms.Label()
        Me.lblPurchaseOrderNo = New System.Windows.Forms.Label()
        Me.lblReceivedDate = New System.Windows.Forms.Label()
        Me.lblAdviceNoteNo = New System.Windows.Forms.Label()
        Me.lblDeliveryLocationID = New System.Windows.Forms.Label()
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvGoodsReceivedNoteDetails = New System.Windows.Forms.DataGridView()
        Me.cmsGoodsReceivedNote = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsGoodsReceivedNoteCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsGoodsReceivedNoteSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsGoodsReceivedNoteEditItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsGoodsReceivedNotesRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.stbPurchaseOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.stbOrderDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.nbxTotalVAT = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxDiscountTotal = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblDiscountTotal = New System.Windows.Forms.Label()
        Me.lbltotalVAT = New System.Windows.Forms.Label()
        Me.stbGrossAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrossAmount = New System.Windows.Forms.Label()
        Me.btnEditPurchaseOrders = New System.Windows.Forms.Button()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOrderNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBonusQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPack = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalOrdered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvGoodsReceivedNoteDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsGoodsReceivedNote.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.pnlPrintOnSaving.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpReceivedDate
        '
        Me.dtpReceivedDate.Checked = False
        Me.dtpReceivedDate.Location = New System.Drawing.Point(139, 48)
        Me.dtpReceivedDate.Name = "dtpReceivedDate"
        Me.dtpReceivedDate.ShowCheckBox = True
        Me.dtpReceivedDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpReceivedDate.TabIndex = 6
        '
        'stbAdviceNoteNo
        '
        Me.stbAdviceNoteNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdviceNoteNo.CapitalizeFirstLetter = False
        Me.stbAdviceNoteNo.EntryErrorMSG = ""
        Me.stbAdviceNoteNo.Location = New System.Drawing.Point(139, 69)
        Me.stbAdviceNoteNo.MaxLength = 20
        Me.stbAdviceNoteNo.Name = "stbAdviceNoteNo"
        Me.stbAdviceNoteNo.RegularExpression = ""
        Me.stbAdviceNoteNo.Size = New System.Drawing.Size(170, 20)
        Me.stbAdviceNoteNo.TabIndex = 8
        '
        'cboDeliveryLocationID
        '
        Me.cboDeliveryLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeliveryLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDeliveryLocationID.Location = New System.Drawing.Point(139, 91)
        Me.cboDeliveryLocationID.Name = "cboDeliveryLocationID"
        Me.cboDeliveryLocationID.Size = New System.Drawing.Size(170, 21)
        Me.cboDeliveryLocationID.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(940, 418)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 26
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbGRNNo
        '
        Me.stbGRNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGRNNo.CapitalizeFirstLetter = False
        Me.stbGRNNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbGRNNo.EntryErrorMSG = ""
        Me.stbGRNNo.Location = New System.Drawing.Point(139, 27)
        Me.stbGRNNo.MaxLength = 20
        Me.stbGRNNo.Name = "stbGRNNo"
        Me.stbGRNNo.RegularExpression = ""
        Me.stbGRNNo.Size = New System.Drawing.Size(170, 20)
        Me.stbGRNNo.TabIndex = 4
        '
        'lblGRNNo
        '
        Me.lblGRNNo.Location = New System.Drawing.Point(12, 29)
        Me.lblGRNNo.Name = "lblGRNNo"
        Me.lblGRNNo.Size = New System.Drawing.Size(121, 20)
        Me.lblGRNNo.TabIndex = 3
        Me.lblGRNNo.Text = "GRN No"
        '
        'lblPurchaseOrderNo
        '
        Me.lblPurchaseOrderNo.Location = New System.Drawing.Point(12, 8)
        Me.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo"
        Me.lblPurchaseOrderNo.Size = New System.Drawing.Size(121, 20)
        Me.lblPurchaseOrderNo.TabIndex = 0
        Me.lblPurchaseOrderNo.Text = "Purchase Order No"
        '
        'lblReceivedDate
        '
        Me.lblReceivedDate.Location = New System.Drawing.Point(12, 50)
        Me.lblReceivedDate.Name = "lblReceivedDate"
        Me.lblReceivedDate.Size = New System.Drawing.Size(121, 20)
        Me.lblReceivedDate.TabIndex = 5
        Me.lblReceivedDate.Text = "Received Date"
        '
        'lblAdviceNoteNo
        '
        Me.lblAdviceNoteNo.Location = New System.Drawing.Point(12, 71)
        Me.lblAdviceNoteNo.Name = "lblAdviceNoteNo"
        Me.lblAdviceNoteNo.Size = New System.Drawing.Size(121, 20)
        Me.lblAdviceNoteNo.TabIndex = 7
        Me.lblAdviceNoteNo.Text = "Advice Note No"
        '
        'lblDeliveryLocationID
        '
        Me.lblDeliveryLocationID.Location = New System.Drawing.Point(12, 93)
        Me.lblDeliveryLocationID.Name = "lblDeliveryLocationID"
        Me.lblDeliveryLocationID.Size = New System.Drawing.Size(121, 20)
        Me.lblDeliveryLocationID.TabIndex = 9
        Me.lblDeliveryLocationID.Text = "Delivery Location"
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(15, 418)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(72, 24)
        Me.fbnSave.TabIndex = 23
        Me.fbnSave.Tag = "GoodsReceivedNote"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = False
        '
        'dgvGoodsReceivedNoteDetails
        '
        Me.dgvGoodsReceivedNoteDetails.AllowUserToAddRows = False
        Me.dgvGoodsReceivedNoteDetails.AllowUserToDeleteRows = False
        Me.dgvGoodsReceivedNoteDetails.AllowUserToOrderColumns = True
        Me.dgvGoodsReceivedNoteDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGoodsReceivedNoteDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvGoodsReceivedNoteDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReceivedNoteDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGoodsReceivedNoteDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colUnitMeasure, Me.ColOrderNotes, Me.colOrderedQuantity, Me.colBonusQuantity, Me.colUnitPrice, Me.colPack, Me.colPackSize, Me.colReceivedQuantity, Me.colTotalOrdered, Me.colTotalReceived, Me.colRate, Me.colDiscount, Me.colVATPercentage, Me.colVATValue, Me.colAmount, Me.colBatchNo, Me.colExpiryDate, Me.ColBarCode, Me.colNotes, Me.colItemCategoryID})
        Me.dgvGoodsReceivedNoteDetails.ContextMenuStrip = Me.cmsGoodsReceivedNote
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGoodsReceivedNoteDetails.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvGoodsReceivedNoteDetails.EnableHeadersVisualStyles = False
        Me.dgvGoodsReceivedNoteDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvGoodsReceivedNoteDetails.Location = New System.Drawing.Point(12, 140)
        Me.dgvGoodsReceivedNoteDetails.Name = "dgvGoodsReceivedNoteDetails"
        Me.dgvGoodsReceivedNoteDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReceivedNoteDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvGoodsReceivedNoteDetails.RowHeadersVisible = False
        Me.dgvGoodsReceivedNoteDetails.Size = New System.Drawing.Size(1000, 272)
        Me.dgvGoodsReceivedNoteDetails.TabIndex = 22
        Me.dgvGoodsReceivedNoteDetails.Text = "DataGridView1"
        '
        'cmsGoodsReceivedNote
        '
        Me.cmsGoodsReceivedNote.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsGoodsReceivedNote.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsGoodsReceivedNoteCopy, Me.cmsGoodsReceivedNoteSelectAll, Me.cmsGoodsReceivedNoteEditItem, Me.ToolStripMenuItem1, Me.cmsGoodsReceivedNotesRefresh})
        Me.cmsGoodsReceivedNote.Name = "cmsSearch"
        Me.cmsGoodsReceivedNote.Size = New System.Drawing.Size(123, 98)
        '
        'cmsGoodsReceivedNoteCopy
        '
        Me.cmsGoodsReceivedNoteCopy.Enabled = False
        Me.cmsGoodsReceivedNoteCopy.Image = CType(resources.GetObject("cmsGoodsReceivedNoteCopy.Image"), System.Drawing.Image)
        Me.cmsGoodsReceivedNoteCopy.Name = "cmsGoodsReceivedNoteCopy"
        Me.cmsGoodsReceivedNoteCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsGoodsReceivedNoteCopy.Text = "&Copy"
        Me.cmsGoodsReceivedNoteCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsGoodsReceivedNoteSelectAll
        '
        Me.cmsGoodsReceivedNoteSelectAll.Enabled = False
        Me.cmsGoodsReceivedNoteSelectAll.Name = "cmsGoodsReceivedNoteSelectAll"
        Me.cmsGoodsReceivedNoteSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsGoodsReceivedNoteSelectAll.Text = "Select &All"
        '
        'cmsGoodsReceivedNoteEditItem
        '
        Me.cmsGoodsReceivedNoteEditItem.Enabled = False
        Me.cmsGoodsReceivedNoteEditItem.Image = CType(resources.GetObject("cmsGoodsReceivedNoteEditItem.Image"), System.Drawing.Image)
        Me.cmsGoodsReceivedNoteEditItem.Name = "cmsGoodsReceivedNoteEditItem"
        Me.cmsGoodsReceivedNoteEditItem.Size = New System.Drawing.Size(122, 22)
        Me.cmsGoodsReceivedNoteEditItem.Tag = ""
        Me.cmsGoodsReceivedNoteEditItem.Text = "&Edit Item"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(119, 6)
        '
        'cmsGoodsReceivedNotesRefresh
        '
        Me.cmsGoodsReceivedNotesRefresh.Enabled = False
        Me.cmsGoodsReceivedNotesRefresh.Image = CType(resources.GetObject("cmsGoodsReceivedNotesRefresh.Image"), System.Drawing.Image)
        Me.cmsGoodsReceivedNotesRefresh.Name = "cmsGoodsReceivedNotesRefresh"
        Me.cmsGoodsReceivedNotesRefresh.Size = New System.Drawing.Size(122, 22)
        Me.cmsGoodsReceivedNotesRefresh.Text = "&Refresh"
        '
        'stbPurchaseOrderNo
        '
        Me.stbPurchaseOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPurchaseOrderNo.CapitalizeFirstLetter = False
        Me.stbPurchaseOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPurchaseOrderNo.EntryErrorMSG = ""
        Me.stbPurchaseOrderNo.Location = New System.Drawing.Point(139, 6)
        Me.stbPurchaseOrderNo.MaxLength = 20
        Me.stbPurchaseOrderNo.Name = "stbPurchaseOrderNo"
        Me.stbPurchaseOrderNo.RegularExpression = ""
        Me.stbPurchaseOrderNo.Size = New System.Drawing.Size(118, 20)
        Me.stbPurchaseOrderNo.TabIndex = 1
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(432, 5)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSupplierName.Size = New System.Drawing.Size(176, 35)
        Me.stbSupplierName.TabIndex = 14
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(315, 12)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(111, 20)
        Me.lblSupplierName.TabIndex = 13
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(12, 114)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(121, 20)
        Me.lblOrderDate.TabIndex = 11
        Me.lblOrderDate.Text = "Order Date"
        '
        'stbOrderDate
        '
        Me.stbOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderDate.CapitalizeFirstLetter = False
        Me.stbOrderDate.Enabled = False
        Me.stbOrderDate.EntryErrorMSG = ""
        Me.stbOrderDate.Location = New System.Drawing.Point(139, 114)
        Me.stbOrderDate.MaxLength = 20
        Me.stbOrderDate.Name = "stbOrderDate"
        Me.stbOrderDate.RegularExpression = ""
        Me.stbOrderDate.Size = New System.Drawing.Size(170, 20)
        Me.stbOrderDate.TabIndex = 12
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(614, 3)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(332, 67)
        Me.pnlBill.TabIndex = 21
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(3, 28)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(99, 18)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(108, 3)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(191, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(108, 24)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(208, 34)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(3, 4)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(99, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Items"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(263, 3)
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
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(93, 418)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(176, 31)
        Me.pnlPrintOnSaving.TabIndex = 24
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
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(130, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print GRN On Saving"
        '
        'nbxTotalVAT
        '
        Me.nbxTotalVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTotalVAT.ControlCaption = "Total VAT"
        Me.nbxTotalVAT.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Currency
        Me.nbxTotalVAT.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxTotalVAT.DecimalPlaces = 2
        Me.nbxTotalVAT.DenyNegativeEntryValue = True
        Me.nbxTotalVAT.Enabled = False
        Me.nbxTotalVAT.Location = New System.Drawing.Point(432, 83)
        Me.nbxTotalVAT.MaxLength = 5
        Me.nbxTotalVAT.MaxValue = 100.0R
        Me.nbxTotalVAT.MinValue = 0.0R
        Me.nbxTotalVAT.MustEnterNumeric = True
        Me.nbxTotalVAT.Name = "nbxTotalVAT"
        Me.nbxTotalVAT.Size = New System.Drawing.Size(160, 20)
        Me.nbxTotalVAT.TabIndex = 20
        Me.nbxTotalVAT.Text = "0"
        Me.nbxTotalVAT.Value = "0"
        '
        'nbxDiscountTotal
        '
        Me.nbxDiscountTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDiscountTotal.ControlCaption = "Discount On Total"
        Me.nbxDiscountTotal.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxDiscountTotal.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxDiscountTotal.DecimalPlaces = -1
        Me.nbxDiscountTotal.DenyNegativeEntryValue = True
        Me.nbxDiscountTotal.Location = New System.Drawing.Point(432, 62)
        Me.nbxDiscountTotal.MaxLength = 12
        Me.nbxDiscountTotal.MaxValue = 0.0R
        Me.nbxDiscountTotal.MinValue = 0.0R
        Me.nbxDiscountTotal.MustEnterNumeric = True
        Me.nbxDiscountTotal.Name = "nbxDiscountTotal"
        Me.nbxDiscountTotal.Size = New System.Drawing.Size(160, 20)
        Me.nbxDiscountTotal.TabIndex = 18
        Me.nbxDiscountTotal.Text = "0"
        Me.nbxDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxDiscountTotal.Value = "0"
        '
        'lblDiscountTotal
        '
        Me.lblDiscountTotal.Location = New System.Drawing.Point(315, 62)
        Me.lblDiscountTotal.Name = "lblDiscountTotal"
        Me.lblDiscountTotal.Size = New System.Drawing.Size(111, 20)
        Me.lblDiscountTotal.TabIndex = 17
        Me.lblDiscountTotal.Text = "Discount On Total"
        '
        'lbltotalVAT
        '
        Me.lbltotalVAT.Location = New System.Drawing.Point(315, 84)
        Me.lbltotalVAT.Name = "lbltotalVAT"
        Me.lbltotalVAT.Size = New System.Drawing.Size(111, 20)
        Me.lbltotalVAT.TabIndex = 19
        Me.lbltotalVAT.Text = "Total VAT"
        '
        'stbGrossAmount
        '
        Me.stbGrossAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrossAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrossAmount.CapitalizeFirstLetter = False
        Me.stbGrossAmount.Enabled = False
        Me.stbGrossAmount.EntryErrorMSG = ""
        Me.stbGrossAmount.Location = New System.Drawing.Point(432, 41)
        Me.stbGrossAmount.MaxLength = 20
        Me.stbGrossAmount.Name = "stbGrossAmount"
        Me.stbGrossAmount.RegularExpression = ""
        Me.stbGrossAmount.Size = New System.Drawing.Size(160, 20)
        Me.stbGrossAmount.TabIndex = 16
        Me.stbGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrossAmount
        '
        Me.lblGrossAmount.Location = New System.Drawing.Point(315, 42)
        Me.lblGrossAmount.Name = "lblGrossAmount"
        Me.lblGrossAmount.Size = New System.Drawing.Size(111, 20)
        Me.lblGrossAmount.TabIndex = 15
        Me.lblGrossAmount.Text = "Gross Amount"
        '
        'btnEditPurchaseOrders
        '
        Me.btnEditPurchaseOrders.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEditPurchaseOrders.Enabled = False
        Me.btnEditPurchaseOrders.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEditPurchaseOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditPurchaseOrders.Location = New System.Drawing.Point(465, 418)
        Me.btnEditPurchaseOrders.Name = "btnEditPurchaseOrders"
        Me.btnEditPurchaseOrders.Size = New System.Drawing.Size(135, 24)
        Me.btnEditPurchaseOrders.TabIndex = 25
        Me.btnEditPurchaseOrders.Tag = "PurchaseOrders"
        Me.btnEditPurchaseOrders.Text = "E&dit Purchase Order"
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.MaxInputLength = 20
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 60
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MaxInputLength = 800
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.MaxInputLength = 100
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 70
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle5
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.MaxInputLength = 100
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 80
        '
        'ColOrderNotes
        '
        Me.ColOrderNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.ColOrderNotes.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColOrderNotes.HeaderText = "Order Notes"
        Me.ColOrderNotes.Name = "ColOrderNotes"
        Me.ColOrderNotes.ReadOnly = True
        '
        'colOrderedQuantity
        '
        Me.colOrderedQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colOrderedQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOrderedQuantity.HeaderText = "Ordered Qty"
        Me.colOrderedQuantity.MaxInputLength = 12
        Me.colOrderedQuantity.Name = "colOrderedQuantity"
        Me.colOrderedQuantity.ReadOnly = True
        Me.colOrderedQuantity.Width = 80
        '
        'colBonusQuantity
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBonusQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBonusQuantity.HeaderText = "Bonus Qty"
        Me.colBonusQuantity.MaxInputLength = 12
        Me.colBonusQuantity.Name = "colBonusQuantity"
        Me.colBonusQuantity.Width = 70
        '
        'colUnitPrice
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.MaxInputLength = 12
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 65
        '
        'colPack
        '
        Me.colPack.DataPropertyName = "Pack"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colPack.DefaultCellStyle = DataGridViewCellStyle10
        Me.colPack.HeaderText = "Pack"
        Me.colPack.Name = "colPack"
        Me.colPack.ReadOnly = True
        Me.colPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colPackSize
        '
        Me.colPackSize.DataPropertyName = "PackSize"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colPackSize.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPackSize.HeaderText = "Pack Size"
        Me.colPackSize.Name = "colPackSize"
        Me.colPackSize.ReadOnly = True
        '
        'colReceivedQuantity
        '
        Me.colReceivedQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReceivedQuantity.DefaultCellStyle = DataGridViewCellStyle12
        Me.colReceivedQuantity.HeaderText = "Received Qty"
        Me.colReceivedQuantity.MaxInputLength = 12
        Me.colReceivedQuantity.Name = "colReceivedQuantity"
        Me.colReceivedQuantity.Width = 80
        '
        'colTotalOrdered
        '
        Me.colTotalOrdered.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colTotalOrdered.DefaultCellStyle = DataGridViewCellStyle13
        Me.colTotalOrdered.HeaderText = "Total Ordered"
        Me.colTotalOrdered.Name = "colTotalOrdered"
        Me.colTotalOrdered.ReadOnly = True
        '
        'colTotalReceived
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colTotalReceived.DefaultCellStyle = DataGridViewCellStyle14
        Me.colTotalReceived.HeaderText = "Total Received"
        Me.colTotalReceived.Name = "colTotalReceived"
        Me.colTotalReceived.ReadOnly = True
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colRate.DefaultCellStyle = DataGridViewCellStyle15
        Me.colRate.HeaderText = "Rate"
        Me.colRate.MaxInputLength = 12
        Me.colRate.Name = "colRate"
        Me.colRate.Width = 60
        '
        'colDiscount
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle16
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.MaxInputLength = 12
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.Width = 60
        '
        'colVATPercentage
        '
        Me.colVATPercentage.DataPropertyName = "VATPercentage"
        Me.colVATPercentage.HeaderText = "VAT Percentage"
        Me.colVATPercentage.Name = "colVATPercentage"
        Me.colVATPercentage.Width = 95
        '
        'colVATValue
        '
        Me.colVATValue.DataPropertyName = "VATValue"
        Me.colVATValue.HeaderText = "VAT Value"
        Me.colVATValue.Name = "colVATValue"
        Me.colVATValue.ReadOnly = True
        Me.colVATValue.Width = 90
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle17
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.MaxInputLength = 12
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Width = 60
        '
        'colBatchNo
        '
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.MaxInputLength = 20
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.Width = 60
        '
        'colExpiryDate
        '
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.MaxInputLength = 20
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.Width = 70
        '
        'ColBarCode
        '
        Me.ColBarCode.HeaderText = "Bar Code"
        Me.ColBarCode.MaxInputLength = 2000
        Me.ColBarCode.Name = "ColBarCode"
        Me.ColBarCode.Width = 150
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 70
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle18
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'frmGoodsReceivedNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1024, 454)
        Me.Controls.Add(Me.btnEditPurchaseOrders)
        Me.Controls.Add(Me.stbGrossAmount)
        Me.Controls.Add(Me.lblGrossAmount)
        Me.Controls.Add(Me.lbltotalVAT)
        Me.Controls.Add(Me.lblDiscountTotal)
        Me.Controls.Add(Me.nbxDiscountTotal)
        Me.Controls.Add(Me.nbxTotalVAT)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbOrderDate)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.stbPurchaseOrderNo)
        Me.Controls.Add(Me.dgvGoodsReceivedNoteDetails)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbGRNNo)
        Me.Controls.Add(Me.lblGRNNo)
        Me.Controls.Add(Me.lblPurchaseOrderNo)
        Me.Controls.Add(Me.dtpReceivedDate)
        Me.Controls.Add(Me.lblReceivedDate)
        Me.Controls.Add(Me.stbAdviceNoteNo)
        Me.Controls.Add(Me.lblAdviceNoteNo)
        Me.Controls.Add(Me.cboDeliveryLocationID)
        Me.Controls.Add(Me.lblDeliveryLocationID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmGoodsReceivedNote"
        Me.Text = "Goods Received Note"
        CType(Me.dgvGoodsReceivedNoteDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsGoodsReceivedNote.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlPrintOnSaving.ResumeLayout(False)
        Me.pnlPrintOnSaving.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbGRNNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGRNNo As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseOrderNo As System.Windows.Forms.Label
    Friend WithEvents dtpReceivedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents stbAdviceNoteNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdviceNoteNo As System.Windows.Forms.Label
    Friend WithEvents cboDeliveryLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeliveryLocationID As System.Windows.Forms.Label
    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvGoodsReceivedNoteDetails As System.Windows.Forms.DataGridView
    Friend WithEvents stbPurchaseOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents stbOrderDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents nbxTotalVAT As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxDiscountTotal As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDiscountTotal As System.Windows.Forms.Label
    Friend WithEvents lbltotalVAT As System.Windows.Forms.Label
    Friend WithEvents stbGrossAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrossAmount As System.Windows.Forms.Label
    Friend WithEvents btnEditPurchaseOrders As System.Windows.Forms.Button
    Friend WithEvents cmsGoodsReceivedNote As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsGoodsReceivedNoteCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsGoodsReceivedNoteSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsGoodsReceivedNoteEditItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsGoodsReceivedNotesRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOrderNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBonusQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPack As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalOrdered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class