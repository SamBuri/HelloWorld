
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefundRequests : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
End Sub

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(defaultemCategoryID As String)
        MyClass.New()
        Me.defaultItemCategoryID = defaultemCategoryID
        

    End Sub
'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRefundRequests))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.stbRequestedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPayeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbRefundRequestNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundRequestNo = New System.Windows.Forms.Label()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.lblPayName = New System.Windows.Forms.Label()
        Me.lblRequestedBy = New System.Windows.Forms.Label()
        Me.dgvPaymentRefunds = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundReason = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousRefundedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousRefundedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReturnAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nbxRefundOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbAmountRefunded = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountRefunded = New System.Windows.Forms.Label()
        Me.nbxRefundAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundAccountBalance = New System.Windows.Forms.Label()
        Me.stbRefundAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundAmountPaid = New System.Windows.Forms.Label()
        Me.stbRefundPayDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundPayDate = New System.Windows.Forms.Label()
        Me.lblToRefundAmount = New System.Windows.Forms.Label()
        Me.nbxToRefundAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundAmount = New System.Windows.Forms.Label()
        Me.nbxTotalRefundAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.rdoReducePrice = New System.Windows.Forms.RadioButton()
        Me.rdoReduceQuantity = New System.Windows.Forms.RadioButton()
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(7, 453)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(836, 452)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "RefundRequests"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(7, 480)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "RefundRequests"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboReceiptNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReceiptNo, "ReceiptNo")
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReceiptNo.Location = New System.Drawing.Point(226, 31)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(170, 21)
        Me.cboReceiptNo.TabIndex = 6
        '
        'stbRequestedBy
        '
        Me.stbRequestedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRequestedBy.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRequestedBy, "RequestedBy")
        Me.stbRequestedBy.EntryErrorMSG = ""
        Me.stbRequestedBy.Location = New System.Drawing.Point(708, 95)
        Me.stbRequestedBy.Name = "stbRequestedBy"
        Me.stbRequestedBy.RegularExpression = ""
        Me.stbRequestedBy.Size = New System.Drawing.Size(190, 20)
        Me.stbRequestedBy.TabIndex = 10
        '
        'stbPayeeName
        '
        Me.stbPayeeName.BackColor = System.Drawing.SystemColors.Info
        Me.stbPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayeeName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPayeeName, "PayeeName")
        Me.stbPayeeName.EntryErrorMSG = ""
        Me.stbPayeeName.Location = New System.Drawing.Point(226, 54)
        Me.stbPayeeName.Name = "stbPayeeName"
        Me.stbPayeeName.ReadOnly = True
        Me.stbPayeeName.RegularExpression = ""
        Me.stbPayeeName.Size = New System.Drawing.Size(170, 20)
        Me.stbPayeeName.TabIndex = 65
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(836, 479)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbRefundRequestNo
        '
        Me.stbRefundRequestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundRequestNo.CapitalizeFirstLetter = False
        Me.stbRefundRequestNo.EntryErrorMSG = ""
        Me.stbRefundRequestNo.Location = New System.Drawing.Point(226, 8)
        Me.stbRefundRequestNo.Name = "stbRefundRequestNo"
        Me.stbRefundRequestNo.RegularExpression = ""
        Me.stbRefundRequestNo.Size = New System.Drawing.Size(170, 20)
        Me.stbRefundRequestNo.TabIndex = 4
        '
        'lblRefundRequestNo
        '
        Me.lblRefundRequestNo.Location = New System.Drawing.Point(18, 8)
        Me.lblRefundRequestNo.Name = "lblRefundRequestNo"
        Me.lblRefundRequestNo.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundRequestNo.TabIndex = 5
        Me.lblRefundRequestNo.Text = "Refund Request No"
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(18, 31)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(200, 20)
        Me.lblReceiptNo.TabIndex = 7
        Me.lblReceiptNo.Text = "Receipt No"
        '
        'lblPayName
        '
        Me.lblPayName.Location = New System.Drawing.Point(18, 54)
        Me.lblPayName.Name = "lblPayName"
        Me.lblPayName.Size = New System.Drawing.Size(200, 20)
        Me.lblPayName.TabIndex = 9
        Me.lblPayName.Text = "Payee Name"
        '
        'lblRequestedBy
        '
        Me.lblRequestedBy.Location = New System.Drawing.Point(484, 96)
        Me.lblRequestedBy.Name = "lblRequestedBy"
        Me.lblRequestedBy.Size = New System.Drawing.Size(178, 20)
        Me.lblRequestedBy.TabIndex = 11
        Me.lblRequestedBy.Text = "Requested By"
        '
        'dgvPaymentRefunds
        '
        Me.dgvPaymentRefunds.AllowUserToAddRows = False
        Me.dgvPaymentRefunds.AllowUserToOrderColumns = True
        Me.dgvPaymentRefunds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentRefunds.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPaymentRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colVisitNo, Me.colReturnItemCode, Me.colReturnItemName, Me.colItemCategory, Me.colRefundReason, Me.colReturnedQuantity, Me.colNewPrice, Me.colReturnAmount, Me.colBillQuantity, Me.colAmountBalance, Me.colBillUnitPrice, Me.colReturnDiscount, Me.colPreviousRefundedQuantity, Me.colPreviousRefundedAmount, Me.colItemCategoryID, Me.colTotalReturnQuantity, Me.colTotalReturnAmount})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentRefunds.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPaymentRefunds.EnableHeadersVisualStyles = False
        Me.dgvPaymentRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentRefunds.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvPaymentRefunds.Location = New System.Drawing.Point(7, 228)
        Me.dgvPaymentRefunds.Name = "dgvPaymentRefunds"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPaymentRefunds.Size = New System.Drawing.Size(901, 219)
        Me.dgvPaymentRefunds.TabIndex = 54
        Me.dgvPaymentRefunds.Text = "DataGridView1"
        '
        'colInclude
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colInclude.DefaultCellStyle = DataGridViewCellStyle2
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colVisitNo
        '
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colReturnItemCode
        '
        Me.colReturnItemCode.DataPropertyName = "ItemCode"
        Me.colReturnItemCode.HeaderText = "Item Code"
        Me.colReturnItemCode.Name = "colReturnItemCode"
        Me.colReturnItemCode.ReadOnly = True
        Me.colReturnItemCode.Visible = False
        Me.colReturnItemCode.Width = 80
        '
        'colReturnItemName
        '
        Me.colReturnItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colReturnItemName.HeaderText = "Item Name"
        Me.colReturnItemName.Name = "colReturnItemName"
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colRefundReason
        '
        Me.colRefundReason.ControlCaption = Nothing
        Me.colRefundReason.DisplayStyleForCurrentCellOnly = True
        Me.colRefundReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRefundReason.HeaderText = "Refund Reason"
        Me.colRefundReason.Name = "colRefundReason"
        Me.colRefundReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRefundReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colRefundReason.SourceColumn = Nothing
        Me.colRefundReason.Width = 120
        '
        'colReturnedQuantity
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReturnedQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colReturnedQuantity.HeaderText = "Return Qty"
        Me.colReturnedQuantity.Name = "colReturnedQuantity"
        Me.colReturnedQuantity.ReadOnly = True
        Me.colReturnedQuantity.Width = 90
        '
        'colNewPrice
        '
        Me.colNewPrice.HeaderText = "New Price"
        Me.colNewPrice.Name = "colNewPrice"
        '
        'colReturnAmount
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        Me.colReturnAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.colReturnAmount.HeaderText = "Refund Amount"
        Me.colReturnAmount.Name = "colReturnAmount"
        Me.colReturnAmount.ReadOnly = True
        Me.colReturnAmount.Width = 90
        '
        'colBillQuantity
        '
        Me.colBillQuantity.DataPropertyName = "BillQuantity"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colBillQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colBillQuantity.HeaderText = "Bill Qty"
        Me.colBillQuantity.Name = "colBillQuantity"
        Me.colBillQuantity.ReadOnly = True
        Me.colBillQuantity.Width = 80
        '
        'colAmountBalance
        '
        Me.colAmountBalance.DataPropertyName = "AmountBalance"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colAmountBalance.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmountBalance.HeaderText = "Amount Balance"
        Me.colAmountBalance.Name = "colAmountBalance"
        Me.colAmountBalance.ReadOnly = True
        '
        'colBillUnitPrice
        '
        Me.colBillUnitPrice.DataPropertyName = "BillPrice"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colBillUnitPrice.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBillUnitPrice.HeaderText = "Bill Price"
        Me.colBillUnitPrice.Name = "colBillUnitPrice"
        Me.colBillUnitPrice.ReadOnly = True
        Me.colBillUnitPrice.Width = 80
        '
        'colReturnDiscount
        '
        Me.colReturnDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnDiscount.DefaultCellStyle = DataGridViewCellStyle9
        Me.colReturnDiscount.HeaderText = "Discount"
        Me.colReturnDiscount.Name = "colReturnDiscount"
        Me.colReturnDiscount.ReadOnly = True
        Me.colReturnDiscount.Width = 70
        '
        'colPreviousRefundedQuantity
        '
        Me.colPreviousRefundedQuantity.DataPropertyName = "RefundedQuantity"
        Me.colPreviousRefundedQuantity.FillWeight = 120.0!
        Me.colPreviousRefundedQuantity.HeaderText = "Prev Refund Qty"
        Me.colPreviousRefundedQuantity.Name = "colPreviousRefundedQuantity"
        Me.colPreviousRefundedQuantity.ReadOnly = True
        '
        'colPreviousRefundedAmount
        '
        Me.colPreviousRefundedAmount.DataPropertyName = "RefundedAmount"
        Me.colPreviousRefundedAmount.FillWeight = 120.0!
        Me.colPreviousRefundedAmount.HeaderText = "Prev Refund Amt"
        Me.colPreviousRefundedAmount.Name = "colPreviousRefundedAmount"
        Me.colPreviousRefundedAmount.ReadOnly = True
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItemCategoryID.Visible = False
        '
        'colTotalReturnQuantity
        '
        Me.colTotalReturnQuantity.HeaderText = "Total Return Quantity"
        Me.colTotalReturnQuantity.Name = "colTotalReturnQuantity"
        Me.colTotalReturnQuantity.ReadOnly = True
        Me.colTotalReturnQuantity.Visible = False
        '
        'colTotalReturnAmount
        '
        Me.colTotalReturnAmount.HeaderText = "Total Return Amount"
        Me.colTotalReturnAmount.Name = "colTotalReturnAmount"
        Me.colTotalReturnAmount.ReadOnly = True
        Me.colTotalReturnAmount.Visible = False
        '
        'nbxRefundOutstandingBalance
        '
        Me.nbxRefundOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxRefundOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxRefundOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundOutstandingBalance.DecimalPlaces = -1
        Me.nbxRefundOutstandingBalance.Location = New System.Drawing.Point(708, 26)
        Me.nbxRefundOutstandingBalance.MaxValue = 0.0R
        Me.nbxRefundOutstandingBalance.MinValue = 0.0R
        Me.nbxRefundOutstandingBalance.MustEnterNumeric = True
        Me.nbxRefundOutstandingBalance.Name = "nbxRefundOutstandingBalance"
        Me.nbxRefundOutstandingBalance.ReadOnly = True
        Me.nbxRefundOutstandingBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundOutstandingBalance.TabIndex = 62
        Me.nbxRefundOutstandingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundOutstandingBalance.Value = ""
        '
        'lblRefundOutstandingBalance
        '
        Me.lblRefundOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundOutstandingBalance.Location = New System.Drawing.Point(484, 29)
        Me.lblRefundOutstandingBalance.Name = "lblRefundOutstandingBalance"
        Me.lblRefundOutstandingBalance.Size = New System.Drawing.Size(178, 20)
        Me.lblRefundOutstandingBalance.TabIndex = 61
        Me.lblRefundOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbAmountRefunded
        '
        Me.stbAmountRefunded.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountRefunded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountRefunded.CapitalizeFirstLetter = False
        Me.stbAmountRefunded.Enabled = False
        Me.stbAmountRefunded.EntryErrorMSG = ""
        Me.stbAmountRefunded.Location = New System.Drawing.Point(708, 72)
        Me.stbAmountRefunded.MaxLength = 20
        Me.stbAmountRefunded.Name = "stbAmountRefunded"
        Me.stbAmountRefunded.RegularExpression = ""
        Me.stbAmountRefunded.Size = New System.Drawing.Size(190, 20)
        Me.stbAmountRefunded.TabIndex = 60
        Me.stbAmountRefunded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAmountRefunded
        '
        Me.lblAmountRefunded.Location = New System.Drawing.Point(484, 74)
        Me.lblAmountRefunded.Name = "lblAmountRefunded"
        Me.lblAmountRefunded.Size = New System.Drawing.Size(178, 20)
        Me.lblAmountRefunded.TabIndex = 59
        Me.lblAmountRefunded.Text = "Amount Refunded"
        '
        'nbxRefundAccountBalance
        '
        Me.nbxRefundAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundAccountBalance.ControlCaption = "Balance"
        Me.nbxRefundAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundAccountBalance.DecimalPlaces = -1
        Me.nbxRefundAccountBalance.Enabled = False
        Me.nbxRefundAccountBalance.Location = New System.Drawing.Point(708, 49)
        Me.nbxRefundAccountBalance.MaxValue = 0.0R
        Me.nbxRefundAccountBalance.MinValue = 0.0R
        Me.nbxRefundAccountBalance.MustEnterNumeric = True
        Me.nbxRefundAccountBalance.Name = "nbxRefundAccountBalance"
        Me.nbxRefundAccountBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundAccountBalance.TabIndex = 64
        Me.nbxRefundAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundAccountBalance.Value = ""
        '
        'lblRefundAccountBalance
        '
        Me.lblRefundAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundAccountBalance.Location = New System.Drawing.Point(484, 51)
        Me.lblRefundAccountBalance.Name = "lblRefundAccountBalance"
        Me.lblRefundAccountBalance.Size = New System.Drawing.Size(178, 20)
        Me.lblRefundAccountBalance.TabIndex = 63
        Me.lblRefundAccountBalance.Text = "Account Balance"
        '
        'stbRefundAmountPaid
        '
        Me.stbRefundAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundAmountPaid.CapitalizeFirstLetter = False
        Me.stbRefundAmountPaid.Enabled = False
        Me.stbRefundAmountPaid.EntryErrorMSG = ""
        Me.stbRefundAmountPaid.Location = New System.Drawing.Point(708, 3)
        Me.stbRefundAmountPaid.MaxLength = 20
        Me.stbRefundAmountPaid.Name = "stbRefundAmountPaid"
        Me.stbRefundAmountPaid.RegularExpression = ""
        Me.stbRefundAmountPaid.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundAmountPaid.TabIndex = 58
        Me.stbRefundAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRefundAmountPaid
        '
        Me.lblRefundAmountPaid.Location = New System.Drawing.Point(484, 7)
        Me.lblRefundAmountPaid.Name = "lblRefundAmountPaid"
        Me.lblRefundAmountPaid.Size = New System.Drawing.Size(178, 20)
        Me.lblRefundAmountPaid.TabIndex = 57
        Me.lblRefundAmountPaid.Text = "Amount Paid"
        '
        'stbRefundPayDate
        '
        Me.stbRefundPayDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundPayDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundPayDate.CapitalizeFirstLetter = False
        Me.stbRefundPayDate.Enabled = False
        Me.stbRefundPayDate.EntryErrorMSG = ""
        Me.stbRefundPayDate.Location = New System.Drawing.Point(226, 76)
        Me.stbRefundPayDate.MaxLength = 60
        Me.stbRefundPayDate.Name = "stbRefundPayDate"
        Me.stbRefundPayDate.ReadOnly = True
        Me.stbRefundPayDate.RegularExpression = ""
        Me.stbRefundPayDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundPayDate.Size = New System.Drawing.Size(170, 20)
        Me.stbRefundPayDate.TabIndex = 56
        '
        'lblRefundPayDate
        '
        Me.lblRefundPayDate.Location = New System.Drawing.Point(18, 77)
        Me.lblRefundPayDate.Name = "lblRefundPayDate"
        Me.lblRefundPayDate.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundPayDate.TabIndex = 55
        Me.lblRefundPayDate.Text = "Pay Date"
        '
        'lblToRefundAmount
        '
        Me.lblToRefundAmount.Location = New System.Drawing.Point(484, 120)
        Me.lblToRefundAmount.Name = "lblToRefundAmount"
        Me.lblToRefundAmount.Size = New System.Drawing.Size(178, 20)
        Me.lblToRefundAmount.TabIndex = 69
        Me.lblToRefundAmount.Text = "To-Refund Amount"
        '
        'nbxToRefundAmount
        '
        Me.nbxToRefundAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxToRefundAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxToRefundAmount.ControlCaption = "To-Refund Amount"
        Me.nbxToRefundAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxToRefundAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxToRefundAmount.DecimalPlaces = -1
        Me.nbxToRefundAmount.DenyNegativeEntryValue = True
        Me.nbxToRefundAmount.Location = New System.Drawing.Point(708, 118)
        Me.nbxToRefundAmount.MaxValue = 0.0R
        Me.nbxToRefundAmount.MinValue = 0.0R
        Me.nbxToRefundAmount.MustEnterNumeric = True
        Me.nbxToRefundAmount.Name = "nbxToRefundAmount"
        Me.nbxToRefundAmount.ReadOnly = True
        Me.nbxToRefundAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxToRefundAmount.TabIndex = 67
        Me.nbxToRefundAmount.Value = ""
        '
        'lblRefundAmount
        '
        Me.lblRefundAmount.Location = New System.Drawing.Point(484, 140)
        Me.lblRefundAmount.Name = "lblRefundAmount"
        Me.lblRefundAmount.Size = New System.Drawing.Size(178, 20)
        Me.lblRefundAmount.TabIndex = 66
        Me.lblRefundAmount.Text = "Total Refunded Amount"
        '
        'nbxTotalRefundAmount
        '
        Me.nbxTotalRefundAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxTotalRefundAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTotalRefundAmount.ControlCaption = "To-Refund Amount"
        Me.nbxTotalRefundAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxTotalRefundAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxTotalRefundAmount.DecimalPlaces = -1
        Me.nbxTotalRefundAmount.DenyNegativeEntryValue = True
        Me.nbxTotalRefundAmount.Location = New System.Drawing.Point(708, 140)
        Me.nbxTotalRefundAmount.MaxValue = 0.0R
        Me.nbxTotalRefundAmount.MinValue = 0.0R
        Me.nbxTotalRefundAmount.MustEnterNumeric = True
        Me.nbxTotalRefundAmount.Name = "nbxTotalRefundAmount"
        Me.nbxTotalRefundAmount.ReadOnly = True
        Me.nbxTotalRefundAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxTotalRefundAmount.TabIndex = 68
        Me.nbxTotalRefundAmount.Value = ""
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(226, 124)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitNo.TabIndex = 71
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(18, 127)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(200, 21)
        Me.lblVisitNo.TabIndex = 70
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbVisitType
        '
        Me.stbVisitType.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.stbVisitType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(226, 147)
        Me.stbVisitType.MaxLength = 20
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.ReadOnly = True
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitType.TabIndex = 73
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(18, 150)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(200, 21)
        Me.lblVisitType.TabIndex = 72
        Me.lblVisitType.Text = "Visit Type"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(18, 99)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(200, 20)
        Me.lblBillMode.TabIndex = 75
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbBillMode
        '
        Me.stbBillMode.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(226, 99)
        Me.stbBillMode.MaxLength = 20
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.ReadOnly = True
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.Size = New System.Drawing.Size(170, 20)
        Me.stbBillMode.TabIndex = 76
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.rdoReducePrice)
        Me.grpSetParameters.Controls.Add(Me.rdoReduceQuantity)
        Me.grpSetParameters.Location = New System.Drawing.Point(26, 173)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(882, 48)
        Me.grpSetParameters.TabIndex = 77
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Return Category"
        '
        'rdoReducePrice
        '
        Me.rdoReducePrice.Location = New System.Drawing.Point(368, 18)
        Me.rdoReducePrice.Name = "rdoReducePrice"
        Me.rdoReducePrice.Size = New System.Drawing.Size(264, 20)
        Me.rdoReducePrice.TabIndex = 2
        Me.rdoReducePrice.Text = "Reduce Price"
        '
        'rdoReduceQuantity
        '
        Me.rdoReduceQuantity.Checked = True
        Me.rdoReduceQuantity.Location = New System.Drawing.Point(129, 18)
        Me.rdoReduceQuantity.Name = "rdoReduceQuantity"
        Me.rdoReduceQuantity.Size = New System.Drawing.Size(211, 20)
        Me.rdoReduceQuantity.TabIndex = 1
        Me.rdoReduceQuantity.TabStop = True
        Me.rdoReduceQuantity.Text = "Reduce Quantity"
        '
        'frmRefundRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(915, 519)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbVisitType)
        Me.Controls.Add(Me.lblVisitType)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.lblToRefundAmount)
        Me.Controls.Add(Me.nbxToRefundAmount)
        Me.Controls.Add(Me.lblRefundAmount)
        Me.Controls.Add(Me.nbxTotalRefundAmount)
        Me.Controls.Add(Me.stbPayeeName)
        Me.Controls.Add(Me.nbxRefundOutstandingBalance)
        Me.Controls.Add(Me.lblRefundOutstandingBalance)
        Me.Controls.Add(Me.stbAmountRefunded)
        Me.Controls.Add(Me.lblAmountRefunded)
        Me.Controls.Add(Me.nbxRefundAccountBalance)
        Me.Controls.Add(Me.lblRefundAccountBalance)
        Me.Controls.Add(Me.stbRefundAmountPaid)
        Me.Controls.Add(Me.lblRefundAmountPaid)
        Me.Controls.Add(Me.stbRefundPayDate)
        Me.Controls.Add(Me.lblRefundPayDate)
        Me.Controls.Add(Me.dgvPaymentRefunds)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbRefundRequestNo)
        Me.Controls.Add(Me.lblRefundRequestNo)
        Me.Controls.Add(Me.cboReceiptNo)
        Me.Controls.Add(Me.lblReceiptNo)
        Me.Controls.Add(Me.lblPayName)
        Me.Controls.Add(Me.stbRequestedBy)
        Me.Controls.Add(Me.lblRequestedBy)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmRefundRequests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refund Requests"
        CType(Me.dgvPaymentRefunds,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpSetParameters.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbRefundRequestNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundRequestNo As System.Windows.Forms.Label
    Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents lblPayName As System.Windows.Forms.Label
    Friend WithEvents stbRequestedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRequestedBy As System.Windows.Forms.Label
    Friend WithEvents dgvPaymentRefunds As System.Windows.Forms.DataGridView
    Friend WithEvents nbxRefundOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbAmountRefunded As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountRefunded As System.Windows.Forms.Label
    Friend WithEvents nbxRefundAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundAccountBalance As System.Windows.Forms.Label
    Friend WithEvents stbRefundAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundAmountPaid As System.Windows.Forms.Label
    Friend WithEvents stbRefundPayDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundPayDate As System.Windows.Forms.Label
    Friend WithEvents stbPayeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblToRefundAmount As System.Windows.Forms.Label
    Friend WithEvents nbxToRefundAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents nbxTotalRefundAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents rdoReducePrice As System.Windows.Forms.RadioButton
    Friend WithEvents rdoReduceQuantity As System.Windows.Forms.RadioButton
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundReason As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousRefundedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousRefundedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReturnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReturnAmount As System.Windows.Forms.DataGridViewTextBoxColumn

End Class