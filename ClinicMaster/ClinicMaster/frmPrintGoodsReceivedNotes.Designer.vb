<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintGoodsReceivedNotes
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintGoodsReceivedNotes))
        Me.stbNetBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblNetBill = New System.Windows.Forms.Label()
        Me.lblNetBillWords = New System.Windows.Forms.Label()
        Me.stbReturnTotal = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbnetBillInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lbReturnTotal = New System.Windows.Forms.Label()
        Me.tbcGoodsReceived = New System.Windows.Forms.TabControl()
        Me.tpgGoodsReceived = New System.Windows.Forms.TabPage()
        Me.dgvGoodsReceivedNoteDetails = New System.Windows.Forms.DataGridView()
        Me.tpgReturnedGoods = New System.Windows.Forms.TabPage()
        Me.dgvGoodsReturnedNoteDetails = New System.Windows.Forms.DataGridView()
        Me.colReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colreturnRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colreturnmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbGrossAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrossAmount = New System.Windows.Forms.Label()
        Me.lblVATPercent = New System.Windows.Forms.Label()
        Me.lblDiscountTotal = New System.Windows.Forms.Label()
        Me.nbxDiscountTotal = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxTotalVAT = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbDeliveryLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReceivedDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.stbOrderDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblOrderDate = New System.Windows.Forms.Label()
        Me.stbPurchaseOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbGRNNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGRNNo = New System.Windows.Forms.Label()
        Me.lblPurchaseOrderNo = New System.Windows.Forms.Label()
        Me.lblReceivedDate = New System.Windows.Forms.Label()
        Me.stbAdviceNoteNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdviceNoteNo = New System.Windows.Forms.Label()
        Me.lblDeliveryLocationID = New System.Windows.Forms.Label()
        Me.colReceivedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBonusQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcGoodsReceived.SuspendLayout()
        Me.tpgGoodsReceived.SuspendLayout()
        CType(Me.dgvGoodsReceivedNoteDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgReturnedGoods.SuspendLayout()
        CType(Me.dgvGoodsReturnedNoteDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbNetBill
        '
        Me.stbNetBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbNetBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNetBill.CapitalizeFirstLetter = False
        Me.stbNetBill.Enabled = False
        Me.stbNetBill.EntryErrorMSG = ""
        Me.stbNetBill.Location = New System.Drawing.Point(723, 52)
        Me.stbNetBill.MaxLength = 20
        Me.stbNetBill.Name = "stbNetBill"
        Me.stbNetBill.RegularExpression = ""
        Me.stbNetBill.Size = New System.Drawing.Size(206, 20)
        Me.stbNetBill.TabIndex = 87
        Me.stbNetBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNetBill
        '
        Me.lblNetBill.Location = New System.Drawing.Point(614, 53)
        Me.lblNetBill.Name = "lblNetBill"
        Me.lblNetBill.Size = New System.Drawing.Size(103, 18)
        Me.lblNetBill.TabIndex = 86
        Me.lblNetBill.Text = "Net Bill"
        '
        'lblNetBillWords
        '
        Me.lblNetBillWords.Location = New System.Drawing.Point(614, 117)
        Me.lblNetBillWords.Name = "lblNetBillWords"
        Me.lblNetBillWords.Size = New System.Drawing.Size(103, 18)
        Me.lblNetBillWords.TabIndex = 84
        Me.lblNetBillWords.Text = "Net Bill in Words"
        '
        'stbReturnTotal
        '
        Me.stbReturnTotal.BackColor = System.Drawing.SystemColors.Info
        Me.stbReturnTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReturnTotal.CapitalizeFirstLetter = False
        Me.stbReturnTotal.Enabled = False
        Me.stbReturnTotal.EntryErrorMSG = ""
        Me.stbReturnTotal.Location = New System.Drawing.Point(723, 31)
        Me.stbReturnTotal.MaxLength = 20
        Me.stbReturnTotal.Name = "stbReturnTotal"
        Me.stbReturnTotal.RegularExpression = ""
        Me.stbReturnTotal.Size = New System.Drawing.Size(206, 20)
        Me.stbReturnTotal.TabIndex = 83
        Me.stbReturnTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbnetBillInWords
        '
        Me.stbnetBillInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbnetBillInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbnetBillInWords.CapitalizeFirstLetter = False
        Me.stbnetBillInWords.EntryErrorMSG = ""
        Me.stbnetBillInWords.Location = New System.Drawing.Point(723, 113)
        Me.stbnetBillInWords.MaxLength = 0
        Me.stbnetBillInWords.Multiline = True
        Me.stbnetBillInWords.Name = "stbnetBillInWords"
        Me.stbnetBillInWords.ReadOnly = True
        Me.stbnetBillInWords.RegularExpression = ""
        Me.stbnetBillInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbnetBillInWords.Size = New System.Drawing.Size(223, 39)
        Me.stbnetBillInWords.TabIndex = 85
        '
        'lbReturnTotal
        '
        Me.lbReturnTotal.Location = New System.Drawing.Point(614, 32)
        Me.lbReturnTotal.Name = "lbReturnTotal"
        Me.lbReturnTotal.Size = New System.Drawing.Size(103, 18)
        Me.lbReturnTotal.TabIndex = 82
        Me.lbReturnTotal.Text = "Total Return"
        '
        'tbcGoodsReceived
        '
        Me.tbcGoodsReceived.Controls.Add(Me.tpgGoodsReceived)
        Me.tbcGoodsReceived.Controls.Add(Me.tpgReturnedGoods)
        Me.tbcGoodsReceived.HotTrack = True
        Me.tbcGoodsReceived.Location = New System.Drawing.Point(12, 158)
        Me.tbcGoodsReceived.Name = "tbcGoodsReceived"
        Me.tbcGoodsReceived.SelectedIndex = 0
        Me.tbcGoodsReceived.Size = New System.Drawing.Size(934, 266)
        Me.tbcGoodsReceived.TabIndex = 81
        '
        'tpgGoodsReceived
        '
        Me.tpgGoodsReceived.Controls.Add(Me.dgvGoodsReceivedNoteDetails)
        Me.tpgGoodsReceived.Location = New System.Drawing.Point(4, 22)
        Me.tpgGoodsReceived.Name = "tpgGoodsReceived"
        Me.tpgGoodsReceived.Size = New System.Drawing.Size(926, 240)
        Me.tpgGoodsReceived.TabIndex = 0
        Me.tpgGoodsReceived.Tag = ""
        Me.tpgGoodsReceived.Text = "Received Goods"
        Me.tpgGoodsReceived.UseVisualStyleBackColor = True
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
        Me.dgvGoodsReceivedNoteDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReceivedDate, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colUnitMeasure, Me.colOrderedQuantity, Me.colReceivedQuantity, Me.colReturnQuantity, Me.colBonusQuantity, Me.colRate, Me.colDiscount, Me.colAmount, Me.colBatchNo, Me.colExpiryDate, Me.colNotes})
        Me.dgvGoodsReceivedNoteDetails.EnableHeadersVisualStyles = False
        Me.dgvGoodsReceivedNoteDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvGoodsReceivedNoteDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgvGoodsReceivedNoteDetails.Name = "dgvGoodsReceivedNoteDetails"
        Me.dgvGoodsReceivedNoteDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReceivedNoteDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvGoodsReceivedNoteDetails.RowHeadersVisible = False
        Me.dgvGoodsReceivedNoteDetails.Size = New System.Drawing.Size(927, 218)
        Me.dgvGoodsReceivedNoteDetails.TabIndex = 25
        Me.dgvGoodsReceivedNoteDetails.Text = "DataGridView1"
        '
        'tpgReturnedGoods
        '
        Me.tpgReturnedGoods.Controls.Add(Me.dgvGoodsReturnedNoteDetails)
        Me.tpgReturnedGoods.Location = New System.Drawing.Point(4, 22)
        Me.tpgReturnedGoods.Name = "tpgReturnedGoods"
        Me.tpgReturnedGoods.Size = New System.Drawing.Size(926, 240)
        Me.tpgReturnedGoods.TabIndex = 3
        Me.tpgReturnedGoods.Tag = ""
        Me.tpgReturnedGoods.Text = "Returned Goods Details"
        Me.tpgReturnedGoods.UseVisualStyleBackColor = True
        '
        'dgvGoodsReturnedNoteDetails
        '
        Me.dgvGoodsReturnedNoteDetails.AllowUserToAddRows = False
        Me.dgvGoodsReturnedNoteDetails.AllowUserToDeleteRows = False
        Me.dgvGoodsReturnedNoteDetails.AllowUserToOrderColumns = True
        Me.dgvGoodsReturnedNoteDetails.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReturnedNoteDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvGoodsReturnedNoteDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReturnDate, Me.colItemCategoryID, Me.colReturnItemName, Me.colReturnedQuantity, Me.colreturnRate, Me.colreturnmount})
        Me.dgvGoodsReturnedNoteDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGoodsReturnedNoteDetails.EnableHeadersVisualStyles = False
        Me.dgvGoodsReturnedNoteDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvGoodsReturnedNoteDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvGoodsReturnedNoteDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvGoodsReturnedNoteDetails.Name = "dgvGoodsReturnedNoteDetails"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReturnedNoteDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvGoodsReturnedNoteDetails.Size = New System.Drawing.Size(926, 240)
        Me.dgvGoodsReturnedNoteDetails.TabIndex = 22
        Me.dgvGoodsReturnedNoteDetails.Text = "DataGridView1"
        '
        'colReturnDate
        '
        Me.colReturnDate.DataPropertyName = "ReturnDate"
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnDate.DefaultCellStyle = DataGridViewCellStyle19
        Me.colReturnDate.HeaderText = "Return Date"
        Me.colReturnDate.Name = "colReturnDate"
        Me.colReturnDate.ReadOnly = True
        Me.colReturnDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colReturnDate.Width = 300
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle20
        Me.colItemCategoryID.HeaderText = "Item Category"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Width = 120
        '
        'colReturnItemName
        '
        Me.colReturnItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnItemName.DefaultCellStyle = DataGridViewCellStyle21
        Me.colReturnItemName.HeaderText = "Item Name"
        Me.colReturnItemName.Name = "colReturnItemName"
        Me.colReturnItemName.ReadOnly = True
        Me.colReturnItemName.Width = 150
        '
        'colReturnedQuantity
        '
        Me.colReturnedQuantity.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colReturnedQuantity.DefaultCellStyle = DataGridViewCellStyle22
        Me.colReturnedQuantity.HeaderText = "Return Quantity"
        Me.colReturnedQuantity.Name = "colReturnedQuantity"
        Me.colReturnedQuantity.ReadOnly = True
        Me.colReturnedQuantity.Width = 120
        '
        'colreturnRate
        '
        Me.colreturnRate.DataPropertyName = "Rate"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colreturnRate.DefaultCellStyle = DataGridViewCellStyle23
        Me.colreturnRate.HeaderText = "Rate"
        Me.colreturnRate.Name = "colreturnRate"
        Me.colreturnRate.ReadOnly = True
        '
        'colreturnmount
        '
        Me.colreturnmount.DataPropertyName = "amount"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colreturnmount.DefaultCellStyle = DataGridViewCellStyle24
        Me.colreturnmount.HeaderText = "Amount"
        Me.colreturnmount.Name = "colreturnmount"
        Me.colreturnmount.ReadOnly = True
        '
        'stbGrossAmount
        '
        Me.stbGrossAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrossAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrossAmount.CapitalizeFirstLetter = False
        Me.stbGrossAmount.Enabled = False
        Me.stbGrossAmount.EntryErrorMSG = ""
        Me.stbGrossAmount.Location = New System.Drawing.Point(432, 54)
        Me.stbGrossAmount.MaxLength = 20
        Me.stbGrossAmount.Name = "stbGrossAmount"
        Me.stbGrossAmount.RegularExpression = ""
        Me.stbGrossAmount.Size = New System.Drawing.Size(160, 20)
        Me.stbGrossAmount.TabIndex = 69
        Me.stbGrossAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrossAmount
        '
        Me.lblGrossAmount.Location = New System.Drawing.Point(315, 55)
        Me.lblGrossAmount.Name = "lblGrossAmount"
        Me.lblGrossAmount.Size = New System.Drawing.Size(111, 20)
        Me.lblGrossAmount.TabIndex = 68
        Me.lblGrossAmount.Text = "Gross Amount"
        '
        'lblVATPercent
        '
        Me.lblVATPercent.Location = New System.Drawing.Point(315, 97)
        Me.lblVATPercent.Name = "lblVATPercent"
        Me.lblVATPercent.Size = New System.Drawing.Size(111, 20)
        Me.lblVATPercent.TabIndex = 72
        Me.lblVATPercent.Text = "Total VAT"
        '
        'lblDiscountTotal
        '
        Me.lblDiscountTotal.Location = New System.Drawing.Point(315, 75)
        Me.lblDiscountTotal.Name = "lblDiscountTotal"
        Me.lblDiscountTotal.Size = New System.Drawing.Size(111, 20)
        Me.lblDiscountTotal.TabIndex = 70
        Me.lblDiscountTotal.Text = "Discount On Total"
        '
        'nbxDiscountTotal
        '
        Me.nbxDiscountTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDiscountTotal.ControlCaption = "Discount On Total"
        Me.nbxDiscountTotal.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxDiscountTotal.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxDiscountTotal.DecimalPlaces = -1
        Me.nbxDiscountTotal.DenyNegativeEntryValue = True
        Me.nbxDiscountTotal.Enabled = False
        Me.nbxDiscountTotal.Location = New System.Drawing.Point(432, 75)
        Me.nbxDiscountTotal.MaxLength = 12
        Me.nbxDiscountTotal.MaxValue = 0R
        Me.nbxDiscountTotal.MinValue = 0R
        Me.nbxDiscountTotal.MustEnterNumeric = True
        Me.nbxDiscountTotal.Name = "nbxDiscountTotal"
        Me.nbxDiscountTotal.Size = New System.Drawing.Size(160, 20)
        Me.nbxDiscountTotal.TabIndex = 71
        Me.nbxDiscountTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxDiscountTotal.Value = ""
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
        Me.nbxTotalVAT.Location = New System.Drawing.Point(432, 96)
        Me.nbxTotalVAT.MaxLength = 5
        Me.nbxTotalVAT.MaxValue = 100.0R
        Me.nbxTotalVAT.MinValue = 0R
        Me.nbxTotalVAT.MustEnterNumeric = True
        Me.nbxTotalVAT.Name = "nbxTotalVAT"
        Me.nbxTotalVAT.Size = New System.Drawing.Size(160, 20)
        Me.nbxTotalVAT.TabIndex = 73
        Me.nbxTotalVAT.Value = ""
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(108, 424)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 79
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 424)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 78
        Me.btnPrint.Text = "&Print"
        '
        'stbDeliveryLocation
        '
        Me.stbDeliveryLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDeliveryLocation.CapitalizeFirstLetter = False
        Me.stbDeliveryLocation.Enabled = False
        Me.stbDeliveryLocation.EntryErrorMSG = ""
        Me.stbDeliveryLocation.Location = New System.Drawing.Point(139, 94)
        Me.stbDeliveryLocation.MaxLength = 20
        Me.stbDeliveryLocation.Name = "stbDeliveryLocation"
        Me.stbDeliveryLocation.RegularExpression = ""
        Me.stbDeliveryLocation.Size = New System.Drawing.Size(170, 20)
        Me.stbDeliveryLocation.TabIndex = 63
        '
        'stbReceivedDate
        '
        Me.stbReceivedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReceivedDate.CapitalizeFirstLetter = False
        Me.stbReceivedDate.Enabled = False
        Me.stbReceivedDate.EntryErrorMSG = ""
        Me.stbReceivedDate.Location = New System.Drawing.Point(139, 52)
        Me.stbReceivedDate.MaxLength = 20
        Me.stbReceivedDate.Name = "stbReceivedDate"
        Me.stbReceivedDate.RegularExpression = ""
        Me.stbReceivedDate.Size = New System.Drawing.Size(170, 20)
        Me.stbReceivedDate.TabIndex = 59
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(614, 77)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(103, 18)
        Me.lblBillWords.TabIndex = 76
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(723, 10)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(206, 20)
        Me.stbBillForItem.TabIndex = 75
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(723, 73)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(223, 39)
        Me.stbBillWords.TabIndex = 77
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(263, 7)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 55
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(614, 11)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(103, 18)
        Me.lblBillForItem.TabIndex = 74
        Me.lblBillForItem.Text = "Bill for Items"
        '
        'stbOrderDate
        '
        Me.stbOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOrderDate.CapitalizeFirstLetter = False
        Me.stbOrderDate.Enabled = False
        Me.stbOrderDate.EntryErrorMSG = ""
        Me.stbOrderDate.Location = New System.Drawing.Point(139, 115)
        Me.stbOrderDate.MaxLength = 20
        Me.stbOrderDate.Name = "stbOrderDate"
        Me.stbOrderDate.RegularExpression = ""
        Me.stbOrderDate.Size = New System.Drawing.Size(170, 20)
        Me.stbOrderDate.TabIndex = 65
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(432, 10)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSupplierName.Size = New System.Drawing.Size(176, 43)
        Me.stbSupplierName.TabIndex = 67
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(315, 22)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(111, 20)
        Me.lblSupplierName.TabIndex = 66
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblOrderDate
        '
        Me.lblOrderDate.Location = New System.Drawing.Point(12, 115)
        Me.lblOrderDate.Name = "lblOrderDate"
        Me.lblOrderDate.Size = New System.Drawing.Size(121, 20)
        Me.lblOrderDate.TabIndex = 64
        Me.lblOrderDate.Text = "Order Date"
        '
        'stbPurchaseOrderNo
        '
        Me.stbPurchaseOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPurchaseOrderNo.CapitalizeFirstLetter = False
        Me.stbPurchaseOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPurchaseOrderNo.EntryErrorMSG = ""
        Me.stbPurchaseOrderNo.Location = New System.Drawing.Point(139, 31)
        Me.stbPurchaseOrderNo.MaxLength = 20
        Me.stbPurchaseOrderNo.Name = "stbPurchaseOrderNo"
        Me.stbPurchaseOrderNo.ReadOnly = True
        Me.stbPurchaseOrderNo.RegularExpression = ""
        Me.stbPurchaseOrderNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPurchaseOrderNo.TabIndex = 57
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(856, 424)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(90, 24)
        Me.fbnClose.TabIndex = 80
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbGRNNo
        '
        Me.stbGRNNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGRNNo.CapitalizeFirstLetter = False
        Me.stbGRNNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbGRNNo.EntryErrorMSG = ""
        Me.stbGRNNo.Location = New System.Drawing.Point(139, 10)
        Me.stbGRNNo.MaxLength = 20
        Me.stbGRNNo.Name = "stbGRNNo"
        Me.stbGRNNo.RegularExpression = ""
        Me.stbGRNNo.Size = New System.Drawing.Size(118, 20)
        Me.stbGRNNo.TabIndex = 54
        '
        'lblGRNNo
        '
        Me.lblGRNNo.Location = New System.Drawing.Point(12, 12)
        Me.lblGRNNo.Name = "lblGRNNo"
        Me.lblGRNNo.Size = New System.Drawing.Size(121, 20)
        Me.lblGRNNo.TabIndex = 53
        Me.lblGRNNo.Text = "GRN No"
        '
        'lblPurchaseOrderNo
        '
        Me.lblPurchaseOrderNo.Location = New System.Drawing.Point(12, 33)
        Me.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo"
        Me.lblPurchaseOrderNo.Size = New System.Drawing.Size(121, 20)
        Me.lblPurchaseOrderNo.TabIndex = 56
        Me.lblPurchaseOrderNo.Text = "Purchase Order No"
        '
        'lblReceivedDate
        '
        Me.lblReceivedDate.Location = New System.Drawing.Point(12, 54)
        Me.lblReceivedDate.Name = "lblReceivedDate"
        Me.lblReceivedDate.Size = New System.Drawing.Size(121, 20)
        Me.lblReceivedDate.TabIndex = 58
        Me.lblReceivedDate.Text = "Received Date"
        '
        'stbAdviceNoteNo
        '
        Me.stbAdviceNoteNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdviceNoteNo.CapitalizeFirstLetter = False
        Me.stbAdviceNoteNo.Enabled = False
        Me.stbAdviceNoteNo.EntryErrorMSG = ""
        Me.stbAdviceNoteNo.Location = New System.Drawing.Point(139, 73)
        Me.stbAdviceNoteNo.MaxLength = 20
        Me.stbAdviceNoteNo.Name = "stbAdviceNoteNo"
        Me.stbAdviceNoteNo.RegularExpression = ""
        Me.stbAdviceNoteNo.Size = New System.Drawing.Size(170, 20)
        Me.stbAdviceNoteNo.TabIndex = 61
        '
        'lblAdviceNoteNo
        '
        Me.lblAdviceNoteNo.Location = New System.Drawing.Point(12, 75)
        Me.lblAdviceNoteNo.Name = "lblAdviceNoteNo"
        Me.lblAdviceNoteNo.Size = New System.Drawing.Size(121, 20)
        Me.lblAdviceNoteNo.TabIndex = 60
        Me.lblAdviceNoteNo.Text = "Advice Note No"
        '
        'lblDeliveryLocationID
        '
        Me.lblDeliveryLocationID.Location = New System.Drawing.Point(12, 96)
        Me.lblDeliveryLocationID.Name = "lblDeliveryLocationID"
        Me.lblDeliveryLocationID.Size = New System.Drawing.Size(121, 20)
        Me.lblDeliveryLocationID.TabIndex = 62
        Me.lblDeliveryLocationID.Text = "Delivery Location"
        '
        'colReceivedDate
        '
        Me.colReceivedDate.DataPropertyName = "ReceivedDate"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colReceivedDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.colReceivedDate.HeaderText = "Receive Date"
        Me.colReceivedDate.Name = "colReceivedDate"
        Me.colReceivedDate.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 60
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MaxInputLength = 800
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle5
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 70
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 80
        '
        'colOrderedQuantity
        '
        Me.colOrderedQuantity.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colOrderedQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOrderedQuantity.HeaderText = "Total Ordered"
        Me.colOrderedQuantity.MaxInputLength = 12
        Me.colOrderedQuantity.Name = "colOrderedQuantity"
        Me.colOrderedQuantity.ReadOnly = True
        Me.colOrderedQuantity.Width = 80
        '
        'colReceivedQuantity
        '
        Me.colReceivedQuantity.DataPropertyName = "TotalReceived"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReceivedQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colReceivedQuantity.HeaderText = "Total Received"
        Me.colReceivedQuantity.MaxInputLength = 12
        Me.colReceivedQuantity.Name = "colReceivedQuantity"
        Me.colReceivedQuantity.ReadOnly = True
        '
        'colReturnQuantity
        '
        Me.colReturnQuantity.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnQuantity.DefaultCellStyle = DataGridViewCellStyle9
        Me.colReturnQuantity.HeaderText = "Return Qty"
        Me.colReturnQuantity.Name = "colReturnQuantity"
        Me.colReturnQuantity.ReadOnly = True
        '
        'colBonusQuantity
        '
        Me.colBonusQuantity.DataPropertyName = "BonusQuantity"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colBonusQuantity.DefaultCellStyle = DataGridViewCellStyle10
        Me.colBonusQuantity.HeaderText = "Bonus Qty"
        Me.colBonusQuantity.MaxInputLength = 12
        Me.colBonusQuantity.Name = "colBonusQuantity"
        Me.colBonusQuantity.ReadOnly = True
        Me.colBonusQuantity.Width = 70
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colRate.DefaultCellStyle = DataGridViewCellStyle11
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        Me.colRate.Width = 60
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Width = 60
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle13
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 60
        '
        'colBatchNo
        '
        Me.colBatchNo.DataPropertyName = "BatchNo"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colBatchNo.DefaultCellStyle = DataGridViewCellStyle14
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.MaxInputLength = 20
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        Me.colBatchNo.Width = 60
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle15
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.MaxInputLength = 20
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 70
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle16
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        Me.colNotes.Width = 70
        '
        'frmPrintGoodsReceivedNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 454)
        Me.Controls.Add(Me.stbNetBill)
        Me.Controls.Add(Me.lblNetBill)
        Me.Controls.Add(Me.lblNetBillWords)
        Me.Controls.Add(Me.stbReturnTotal)
        Me.Controls.Add(Me.stbnetBillInWords)
        Me.Controls.Add(Me.lbReturnTotal)
        Me.Controls.Add(Me.tbcGoodsReceived)
        Me.Controls.Add(Me.stbGrossAmount)
        Me.Controls.Add(Me.lblGrossAmount)
        Me.Controls.Add(Me.lblVATPercent)
        Me.Controls.Add(Me.lblDiscountTotal)
        Me.Controls.Add(Me.nbxDiscountTotal)
        Me.Controls.Add(Me.nbxTotalVAT)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbDeliveryLocation)
        Me.Controls.Add(Me.stbReceivedDate)
        Me.Controls.Add(Me.lblBillWords)
        Me.Controls.Add(Me.stbBillForItem)
        Me.Controls.Add(Me.stbBillWords)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lblBillForItem)
        Me.Controls.Add(Me.stbOrderDate)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.lblOrderDate)
        Me.Controls.Add(Me.stbPurchaseOrderNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbGRNNo)
        Me.Controls.Add(Me.lblGRNNo)
        Me.Controls.Add(Me.lblPurchaseOrderNo)
        Me.Controls.Add(Me.lblReceivedDate)
        Me.Controls.Add(Me.stbAdviceNoteNo)
        Me.Controls.Add(Me.lblAdviceNoteNo)
        Me.Controls.Add(Me.lblDeliveryLocationID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintGoodsReceivedNotes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Goods Received Note"
        Me.tbcGoodsReceived.ResumeLayout(False)
        Me.tpgGoodsReceived.ResumeLayout(False)
        CType(Me.dgvGoodsReceivedNoteDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgReturnedGoods.ResumeLayout(False)
        CType(Me.dgvGoodsReturnedNoteDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbNetBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNetBill As System.Windows.Forms.Label
    Friend WithEvents lblNetBillWords As System.Windows.Forms.Label
    Friend WithEvents stbReturnTotal As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbnetBillInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lbReturnTotal As System.Windows.Forms.Label
    Friend WithEvents tbcGoodsReceived As System.Windows.Forms.TabControl
    Friend WithEvents tpgGoodsReceived As System.Windows.Forms.TabPage
    Friend WithEvents dgvGoodsReceivedNoteDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tpgReturnedGoods As System.Windows.Forms.TabPage
    Friend WithEvents dgvGoodsReturnedNoteDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colreturnRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colreturnmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbGrossAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrossAmount As System.Windows.Forms.Label
    Friend WithEvents lblVATPercent As System.Windows.Forms.Label
    Friend WithEvents lblDiscountTotal As System.Windows.Forms.Label
    Friend WithEvents nbxDiscountTotal As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxTotalVAT As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbDeliveryLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbReceivedDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents stbOrderDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblOrderDate As System.Windows.Forms.Label
    Friend WithEvents stbPurchaseOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbGRNNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGRNNo As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseOrderNo As System.Windows.Forms.Label
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents stbAdviceNoteNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdviceNoteNo As System.Windows.Forms.Label
    Friend WithEvents lblDeliveryLocationID As System.Windows.Forms.Label
    Friend WithEvents colReceivedDate As DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As DataGridViewTextBoxColumn
    Friend WithEvents colItemName As DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As DataGridViewTextBoxColumn
    Friend WithEvents colOrderedQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colReceivedQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colReturnQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colBonusQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colRate As DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As DataGridViewTextBoxColumn
    Friend WithEvents colAmount As DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As DataGridViewTextBoxColumn
    Friend WithEvents colNotes As DataGridViewTextBoxColumn
End Class
