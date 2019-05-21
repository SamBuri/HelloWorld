
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceAdjustments : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceAdjustments))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboInvoiceNo = New System.Windows.Forms.ComboBox()
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker()
        Me.nbxAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAdjustmentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdjustmentNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblAdjustmentDate = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.dgvInvoiceAdjustments = New System.Windows.Forms.DataGridView()
        Me.colInclude = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundReason = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReturnAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousReturnedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcknowledgeable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colVATIdentifier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbPayNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.stbStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.stbInvoiceDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.stbInvoiceAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceAmount = New System.Windows.Forms.Label()
        Me.stbPayeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.cboReversalActionID = New System.Windows.Forms.ComboBox()
        Me.lblReversalActionID = New System.Windows.Forms.Label()
        Me.cboCancellationReason = New System.Windows.Forms.ComboBox()
        Me.lblCancellationReason = New System.Windows.Forms.Label()
        CType(Me.dgvInvoiceAdjustments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 503)
        Me.fbnSearch.Margin = New System.Windows.Forms.Padding(4)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(103, 28)
        Me.fbnSearch.TabIndex = 27
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(1087, 503)
        Me.fbnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(96, 30)
        Me.fbnDelete.TabIndex = 29
        Me.fbnDelete.Tag = "InvoiceAdjustments"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 537)
        Me.ebnSaveUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(103, 28)
        Me.ebnSaveUpdate.TabIndex = 28
        Me.ebnSaveUpdate.Tag = "InvoiceAdjustments"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboInvoiceNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboInvoiceNo, "InvoiceNo")
        Me.cboInvoiceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInvoiceNo.Location = New System.Drawing.Point(291, 9)
        Me.cboInvoiceNo.Margin = New System.Windows.Forms.Padding(4)
        Me.cboInvoiceNo.Name = "cboInvoiceNo"
        Me.cboInvoiceNo.Size = New System.Drawing.Size(264, 24)
        Me.cboInvoiceNo.TabIndex = 1
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpAdjustmentDate, "AdjustmentDate")
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(291, 87)
        Me.dtpAdjustmentDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.ShowCheckBox = True
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(264, 22)
        Me.dtpAdjustmentDate.TabIndex = 7
        '
        'nbxAmount
        '
        Me.nbxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmount.ControlCaption = "Amount"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAmount, "Amount")
        Me.nbxAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmount.DecimalPlaces = -1
        Me.nbxAmount.Location = New System.Drawing.Point(291, 113)
        Me.nbxAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.nbxAmount.MaxValue = 0.0R
        Me.nbxAmount.MinValue = 0.0R
        Me.nbxAmount.MustEnterNumeric = True
        Me.nbxAmount.Name = "nbxAmount"
        Me.nbxAmount.Size = New System.Drawing.Size(265, 22)
        Me.nbxAmount.TabIndex = 9
        Me.nbxAmount.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(1087, 537)
        Me.fbnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(96, 30)
        Me.fbnClose.TabIndex = 30
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbAdjustmentNo
        '
        Me.stbAdjustmentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdjustmentNo.CapitalizeFirstLetter = False
        Me.stbAdjustmentNo.EntryErrorMSG = ""
        Me.stbAdjustmentNo.Location = New System.Drawing.Point(291, 36)
        Me.stbAdjustmentNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbAdjustmentNo.Name = "stbAdjustmentNo"
        Me.stbAdjustmentNo.RegularExpression = ""
        Me.stbAdjustmentNo.Size = New System.Drawing.Size(265, 22)
        Me.stbAdjustmentNo.TabIndex = 3
        '
        'lblAdjustmentNo
        '
        Me.lblAdjustmentNo.Location = New System.Drawing.Point(16, 36)
        Me.lblAdjustmentNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentNo.Name = "lblAdjustmentNo"
        Me.lblAdjustmentNo.Size = New System.Drawing.Size(267, 25)
        Me.lblAdjustmentNo.TabIndex = 2
        Me.lblAdjustmentNo.Text = "Adjustment No"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(16, 60)
        Me.lblVisitNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(267, 25)
        Me.lblVisitNo.TabIndex = 4
        Me.lblVisitNo.Text = "Pay No"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(16, 9)
        Me.lblInvoiceNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(267, 25)
        Me.lblInvoiceNo.TabIndex = 0
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblAdjustmentDate
        '
        Me.lblAdjustmentDate.Location = New System.Drawing.Point(16, 89)
        Me.lblAdjustmentDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentDate.Name = "lblAdjustmentDate"
        Me.lblAdjustmentDate.Size = New System.Drawing.Size(267, 25)
        Me.lblAdjustmentDate.TabIndex = 6
        Me.lblAdjustmentDate.Text = "Adjustment Date"
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(16, 112)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(267, 25)
        Me.lblAmount.TabIndex = 8
        Me.lblAmount.Text = "Amount"
        '
        'dgvInvoiceAdjustments
        '
        Me.dgvInvoiceAdjustments.AllowUserToAddRows = False
        Me.dgvInvoiceAdjustments.AllowUserToOrderColumns = True
        Me.dgvInvoiceAdjustments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceAdjustments.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceAdjustments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceAdjustments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colVisitNo, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colRefundReason, Me.colQuantity, Me.colNewPrice, Me.colReturnAmount, Me.colBillQuantity, Me.colBillPrice, Me.colBillAmount, Me.colTotalReturnQuantity, Me.colTotalReturnAmount, Me.colUnitMeasure, Me.colPreviousReturnedQuantity, Me.colPreviousReturnedAmount, Me.colAcknowledgeable, Me.colVATIdentifier, Me.colDiscount, Me.colPayStatus, Me.colItemStatus, Me.colItemCategoryID, Me.colPayStatusID, Me.colItemStatusID})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInvoiceAdjustments.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvInvoiceAdjustments.EnableHeadersVisualStyles = False
        Me.dgvInvoiceAdjustments.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceAdjustments.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvInvoiceAdjustments.Location = New System.Drawing.Point(7, 198)
        Me.dgvInvoiceAdjustments.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvInvoiceAdjustments.Name = "dgvInvoiceAdjustments"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceAdjustments.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvInvoiceAdjustments.Size = New System.Drawing.Size(1180, 298)
        Me.dgvInvoiceAdjustments.TabIndex = 0
        Me.dgvInvoiceAdjustments.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.ControlCaption = Nothing
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.SourceColumn = Nothing
        Me.colInclude.Width = 45
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Visible = False
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Width = 120
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 80
        '
        'colRefundReason
        '
        Me.colRefundReason.ControlCaption = Nothing
        Me.colRefundReason.DisplayStyleForCurrentCellOnly = True
        Me.colRefundReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRefundReason.HeaderText = "Reason"
        Me.colRefundReason.Name = "colRefundReason"
        Me.colRefundReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRefundReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colRefundReason.SourceColumn = Nothing
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colNewPrice
        '
        Me.colNewPrice.HeaderText = "New Price"
        Me.colNewPrice.Name = "colNewPrice"
        Me.colNewPrice.Visible = False
        '
        'colReturnAmount
        '
        Me.colReturnAmount.HeaderText = "Amount"
        Me.colReturnAmount.Name = "colReturnAmount"
        Me.colReturnAmount.ReadOnly = True
        Me.colReturnAmount.Width = 90
        '
        'colBillQuantity
        '
        Me.colBillQuantity.DataPropertyName = "BillQuantity"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colBillQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colBillQuantity.HeaderText = "Bill Qty"
        Me.colBillQuantity.Name = "colBillQuantity"
        Me.colBillQuantity.ReadOnly = True
        Me.colBillQuantity.Width = 60
        '
        'colBillPrice
        '
        Me.colBillPrice.DataPropertyName = "BillPrice"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colBillPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colBillPrice.HeaderText = "Bill Price"
        Me.colBillPrice.Name = "colBillPrice"
        Me.colBillPrice.ReadOnly = True
        Me.colBillPrice.Width = 60
        '
        'colBillAmount
        '
        Me.colBillAmount.DataPropertyName = "BillAmount"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colBillAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBillAmount.HeaderText = "Bill Amount"
        Me.colBillAmount.Name = "colBillAmount"
        Me.colBillAmount.ReadOnly = True
        '
        'colTotalReturnQuantity
        '
        Me.colTotalReturnQuantity.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colTotalReturnQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colTotalReturnQuantity.HeaderText = "Total Return Qty"
        Me.colTotalReturnQuantity.Name = "colTotalReturnQuantity"
        Me.colTotalReturnQuantity.ReadOnly = True
        '
        'colTotalReturnAmount
        '
        Me.colTotalReturnAmount.DataPropertyName = "ReturnAmount"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colTotalReturnAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.colTotalReturnAmount.HeaderText = "Total Return Amt"
        Me.colTotalReturnAmount.Name = "colTotalReturnAmount"
        Me.colTotalReturnAmount.ReadOnly = True
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitMeasure.HeaderText = "Unit of Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colUnitMeasure.Width = 90
        '
        'colPreviousReturnedQuantity
        '
        Me.colPreviousReturnedQuantity.DataPropertyName = "ReturnQuantity"
        Me.colPreviousReturnedQuantity.HeaderText = "Prev Return Qty"
        Me.colPreviousReturnedQuantity.Name = "colPreviousReturnedQuantity"
        Me.colPreviousReturnedQuantity.ReadOnly = True
        Me.colPreviousReturnedQuantity.Visible = False
        '
        'colPreviousReturnedAmount
        '
        Me.colPreviousReturnedAmount.DataPropertyName = "ReturnAmount"
        Me.colPreviousReturnedAmount.HeaderText = "Prev Return Amt"
        Me.colPreviousReturnedAmount.Name = "colPreviousReturnedAmount"
        Me.colPreviousReturnedAmount.ReadOnly = True
        Me.colPreviousReturnedAmount.Visible = False
        '
        'colAcknowledgeable
        '
        Me.colAcknowledgeable.HeaderText = "Acknowledgeable"
        Me.colAcknowledgeable.Name = "colAcknowledgeable"
        Me.colAcknowledgeable.ReadOnly = True
        Me.colAcknowledgeable.Width = 60
        '
        'colVATIdentifier
        '
        Me.colVATIdentifier.DataPropertyName = "VATIdentifier"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colVATIdentifier.DefaultCellStyle = DataGridViewCellStyle11
        Me.colVATIdentifier.HeaderText = "VAT Identifier"
        Me.colVATIdentifier.Name = "colVATIdentifier"
        Me.colVATIdentifier.ReadOnly = True
        Me.colVATIdentifier.Width = 80
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Visible = False
        Me.colDiscount.Width = 60
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle13
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'colItemStatus
        '
        Me.colItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colItemStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 70
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle15
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        Me.colItemCategoryID.Width = 80
        '
        'colPayStatusID
        '
        Me.colPayStatusID.DataPropertyName = "PayStatusID"
        Me.colPayStatusID.HeaderText = "Pay Status ID"
        Me.colPayStatusID.Name = "colPayStatusID"
        Me.colPayStatusID.ReadOnly = True
        Me.colPayStatusID.Visible = False
        '
        'colItemStatusID
        '
        Me.colItemStatusID.DataPropertyName = "ItemStatusID"
        Me.colItemStatusID.HeaderText = "Item Status ID"
        Me.colItemStatusID.Name = "colItemStatusID"
        Me.colItemStatusID.ReadOnly = True
        Me.colItemStatusID.Visible = False
        '
        'stbPayNo
        '
        Me.stbPayNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayNo.CapitalizeFirstLetter = False
        Me.stbPayNo.EntryErrorMSG = ""
        Me.stbPayNo.Location = New System.Drawing.Point(291, 62)
        Me.stbPayNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbPayNo.Name = "stbPayNo"
        Me.stbPayNo.ReadOnly = True
        Me.stbPayNo.RegularExpression = ""
        Me.stbPayNo.Size = New System.Drawing.Size(265, 22)
        Me.stbPayNo.TabIndex = 5
        '
        'stbEndDate
        '
        Me.stbEndDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEndDate.CapitalizeFirstLetter = False
        Me.stbEndDate.Enabled = False
        Me.stbEndDate.EntryErrorMSG = ""
        Me.stbEndDate.Location = New System.Drawing.Point(892, 36)
        Me.stbEndDate.Margin = New System.Windows.Forms.Padding(4)
        Me.stbEndDate.MaxLength = 20
        Me.stbEndDate.Name = "stbEndDate"
        Me.stbEndDate.RegularExpression = ""
        Me.stbEndDate.Size = New System.Drawing.Size(290, 22)
        Me.stbEndDate.TabIndex = 17
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(645, 38)
        Me.lblEndDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(239, 22)
        Me.lblEndDate.TabIndex = 16
        Me.lblEndDate.Text = "End Date"
        '
        'stbStartDate
        '
        Me.stbStartDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStartDate.CapitalizeFirstLetter = False
        Me.stbStartDate.Enabled = False
        Me.stbStartDate.EntryErrorMSG = ""
        Me.stbStartDate.Location = New System.Drawing.Point(892, 10)
        Me.stbStartDate.Margin = New System.Windows.Forms.Padding(4)
        Me.stbStartDate.MaxLength = 60
        Me.stbStartDate.Name = "stbStartDate"
        Me.stbStartDate.RegularExpression = ""
        Me.stbStartDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStartDate.Size = New System.Drawing.Size(290, 22)
        Me.stbStartDate.TabIndex = 15
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(645, 11)
        Me.lblStartDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(239, 22)
        Me.lblStartDate.TabIndex = 14
        Me.lblStartDate.Text = "Start Date"
        '
        'stbInvoiceDate
        '
        Me.stbInvoiceDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceDate.CapitalizeFirstLetter = False
        Me.stbInvoiceDate.Enabled = False
        Me.stbInvoiceDate.EntryErrorMSG = ""
        Me.stbInvoiceDate.Location = New System.Drawing.Point(892, 62)
        Me.stbInvoiceDate.Margin = New System.Windows.Forms.Padding(4)
        Me.stbInvoiceDate.MaxLength = 20
        Me.stbInvoiceDate.Name = "stbInvoiceDate"
        Me.stbInvoiceDate.RegularExpression = ""
        Me.stbInvoiceDate.Size = New System.Drawing.Size(290, 22)
        Me.stbInvoiceDate.TabIndex = 19
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(645, 64)
        Me.lblInvoiceDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(239, 26)
        Me.lblInvoiceDate.TabIndex = 18
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'stbInvoiceAmount
        '
        Me.stbInvoiceAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceAmount.CapitalizeFirstLetter = False
        Me.stbInvoiceAmount.Enabled = False
        Me.stbInvoiceAmount.EntryErrorMSG = ""
        Me.stbInvoiceAmount.Location = New System.Drawing.Point(892, 90)
        Me.stbInvoiceAmount.Margin = New System.Windows.Forms.Padding(4)
        Me.stbInvoiceAmount.MaxLength = 20
        Me.stbInvoiceAmount.Name = "stbInvoiceAmount"
        Me.stbInvoiceAmount.RegularExpression = ""
        Me.stbInvoiceAmount.Size = New System.Drawing.Size(290, 22)
        Me.stbInvoiceAmount.TabIndex = 21
        '
        'lblInvoiceAmount
        '
        Me.lblInvoiceAmount.Location = New System.Drawing.Point(645, 90)
        Me.lblInvoiceAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInvoiceAmount.Name = "lblInvoiceAmount"
        Me.lblInvoiceAmount.Size = New System.Drawing.Size(239, 25)
        Me.lblInvoiceAmount.TabIndex = 20
        Me.lblInvoiceAmount.Text = "Invoice Amount"
        '
        'stbPayeeName
        '
        Me.stbPayeeName.BackColor = System.Drawing.SystemColors.Info
        Me.stbPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayeeName.CapitalizeFirstLetter = True
        Me.stbPayeeName.Enabled = False
        Me.stbPayeeName.EntryErrorMSG = ""
        Me.stbPayeeName.Location = New System.Drawing.Point(892, 142)
        Me.stbPayeeName.Margin = New System.Windows.Forms.Padding(4)
        Me.stbPayeeName.MaxLength = 41
        Me.stbPayeeName.Name = "stbPayeeName"
        Me.stbPayeeName.RegularExpression = ""
        Me.stbPayeeName.Size = New System.Drawing.Size(290, 22)
        Me.stbPayeeName.TabIndex = 25
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(645, 144)
        Me.lblMainMemberName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(239, 22)
        Me.lblMainMemberName.TabIndex = 24
        Me.lblMainMemberName.Text = "Payee Name"
        '
        'stbVisitType
        '
        Me.stbVisitType.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.stbVisitType.Enabled = False
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(892, 116)
        Me.stbVisitType.Margin = New System.Windows.Forms.Padding(4)
        Me.stbVisitType.MaxLength = 60
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitType.Size = New System.Drawing.Size(290, 22)
        Me.stbVisitType.TabIndex = 23
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(645, 117)
        Me.lblVisitType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(239, 22)
        Me.lblVisitType.TabIndex = 22
        Me.lblVisitType.Text = "Visit Type"
        '
        'cboReversalActionID
        '
        Me.cboReversalActionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReversalActionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReversalActionID.FormattingEnabled = True
        Me.cboReversalActionID.ItemHeight = 16
        Me.cboReversalActionID.Location = New System.Drawing.Point(291, 138)
        Me.cboReversalActionID.Margin = New System.Windows.Forms.Padding(4)
        Me.cboReversalActionID.Name = "cboReversalActionID"
        Me.cboReversalActionID.Size = New System.Drawing.Size(264, 24)
        Me.cboReversalActionID.TabIndex = 11
        '
        'lblReversalActionID
        '
        Me.lblReversalActionID.Location = New System.Drawing.Point(16, 135)
        Me.lblReversalActionID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblReversalActionID.Name = "lblReversalActionID"
        Me.lblReversalActionID.Size = New System.Drawing.Size(267, 25)
        Me.lblReversalActionID.TabIndex = 10
        Me.lblReversalActionID.Text = "Reversal Action"
        '
        'cboCancellationReason
        '
        Me.cboCancellationReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCancellationReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCancellationReason.FormattingEnabled = True
        Me.cboCancellationReason.ItemHeight = 16
        Me.cboCancellationReason.Location = New System.Drawing.Point(291, 166)
        Me.cboCancellationReason.Margin = New System.Windows.Forms.Padding(4)
        Me.cboCancellationReason.Name = "cboCancellationReason"
        Me.cboCancellationReason.Size = New System.Drawing.Size(264, 24)
        Me.cboCancellationReason.TabIndex = 13
        '
        'lblCancellationReason
        '
        Me.lblCancellationReason.Location = New System.Drawing.Point(16, 163)
        Me.lblCancellationReason.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCancellationReason.Name = "lblCancellationReason"
        Me.lblCancellationReason.Size = New System.Drawing.Size(267, 25)
        Me.lblCancellationReason.TabIndex = 12
        Me.lblCancellationReason.Text = "Caancellation Reason"
        '
        'frmInvoiceAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1189, 574)
        Me.Controls.Add(Me.cboCancellationReason)
        Me.Controls.Add(Me.lblCancellationReason)
        Me.Controls.Add(Me.cboReversalActionID)
        Me.Controls.Add(Me.lblReversalActionID)
        Me.Controls.Add(Me.stbPayeeName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.stbVisitType)
        Me.Controls.Add(Me.lblVisitType)
        Me.Controls.Add(Me.stbInvoiceAmount)
        Me.Controls.Add(Me.lblInvoiceAmount)
        Me.Controls.Add(Me.stbInvoiceDate)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Controls.Add(Me.stbEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.stbStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.stbPayNo)
        Me.Controls.Add(Me.dgvInvoiceAdjustments)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbAdjustmentNo)
        Me.Controls.Add(Me.lblAdjustmentNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboInvoiceNo)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.dtpAdjustmentDate)
        Me.Controls.Add(Me.lblAdjustmentDate)
        Me.Controls.Add(Me.nbxAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmInvoiceAdjustments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "InvoiceAdjustments"
        Me.Text = "Invoice Adjustments"
        CType(Me.dgvInvoiceAdjustments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbAdjustmentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdjustmentNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboInvoiceNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAdjustmentDate As System.Windows.Forms.Label
    Friend WithEvents nbxAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceAdjustments As System.Windows.Forms.DataGridView
    Friend WithEvents stbPayNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents stbStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceAmount As System.Windows.Forms.Label
    Friend WithEvents stbPayeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents cboReversalActionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReversalActionID As System.Windows.Forms.Label
    Friend WithEvents cboCancellationReason As System.Windows.Forms.ComboBox
    Friend WithEvents lblCancellationReason As System.Windows.Forms.Label
    Friend WithEvents colInclude As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundReason As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReturnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReturnAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousReturnedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcknowledgeable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVATIdentifier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatusID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class