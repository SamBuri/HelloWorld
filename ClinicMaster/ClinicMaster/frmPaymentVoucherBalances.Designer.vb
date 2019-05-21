<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentVoucherBalances
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentVoucherBalances))
        Me.tbcPaymentVouchers = New System.Windows.Forms.TabControl()
        Me.tpgGoodsInvoices = New System.Windows.Forms.TabPage()
        Me.dgvPeriodicPurchaseOrders = New System.Windows.Forms.DataGridView()
        Me.tpgServiceInvoices = New System.Windows.Forms.TabPage()
        Me.dgvPeriodicServiceInvoices = New System.Windows.Forms.DataGridView()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ColGRNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGIPurchaseOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGIOrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGISupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGIOrderAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGINotPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGIPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAccountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsPurchaseOrderReceived = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColGIRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPurchaseOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNotPaidFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSIAccountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcPaymentVouchers.SuspendLayout()
        Me.tpgGoodsInvoices.SuspendLayout()
        CType(Me.dgvPeriodicPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgServiceInvoices.SuspendLayout()
        CType(Me.dgvPeriodicServiceInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcPaymentVouchers
        '
        Me.tbcPaymentVouchers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPaymentVouchers.Controls.Add(Me.tpgGoodsInvoices)
        Me.tbcPaymentVouchers.Controls.Add(Me.tpgServiceInvoices)
        Me.tbcPaymentVouchers.HotTrack = True
        Me.tbcPaymentVouchers.Location = New System.Drawing.Point(12, 85)
        Me.tbcPaymentVouchers.Name = "tbcPaymentVouchers"
        Me.tbcPaymentVouchers.SelectedIndex = 0
        Me.tbcPaymentVouchers.Size = New System.Drawing.Size(1017, 411)
        Me.tbcPaymentVouchers.TabIndex = 5
        '
        'tpgGoodsInvoices
        '
        Me.tpgGoodsInvoices.Controls.Add(Me.dgvPeriodicPurchaseOrders)
        Me.tpgGoodsInvoices.Location = New System.Drawing.Point(4, 22)
        Me.tpgGoodsInvoices.Name = "tpgGoodsInvoices"
        Me.tpgGoodsInvoices.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgGoodsInvoices.Size = New System.Drawing.Size(1009, 385)
        Me.tpgGoodsInvoices.TabIndex = 0
        Me.tpgGoodsInvoices.Tag = "PaymentVouchers"
        Me.tpgGoodsInvoices.Text = "Goods Invoices"
        Me.tpgGoodsInvoices.UseVisualStyleBackColor = True
        '
        'dgvPeriodicPurchaseOrders
        '
        Me.dgvPeriodicPurchaseOrders.AllowUserToAddRows = False
        Me.dgvPeriodicPurchaseOrders.AllowUserToDeleteRows = False
        Me.dgvPeriodicPurchaseOrders.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicPurchaseOrders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodicPurchaseOrders.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPeriodicPurchaseOrders.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodicPurchaseOrders.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPeriodicPurchaseOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicPurchaseOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPeriodicPurchaseOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColGRNNo, Me.ColGIPurchaseOrderNo, Me.ColGIOrderDate, Me.colDocumentNo, Me.ColGISupplierName, Me.ColGIOrderAmount, Me.ColGINotPaidAmount, Me.ColGIPaidAmount, Me.ColAccountBalance, Me.colIsPurchaseOrderReceived, Me.ColGIRecordDate, Me.DataGridViewTextBoxColumn8})
        Me.dgvPeriodicPurchaseOrders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPeriodicPurchaseOrders.EnableHeadersVisualStyles = False
        Me.dgvPeriodicPurchaseOrders.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicPurchaseOrders.Location = New System.Drawing.Point(3, 3)
        Me.dgvPeriodicPurchaseOrders.Name = "dgvPeriodicPurchaseOrders"
        Me.dgvPeriodicPurchaseOrders.ReadOnly = True
        Me.dgvPeriodicPurchaseOrders.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicPurchaseOrders.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPeriodicPurchaseOrders.RowHeadersVisible = False
        Me.dgvPeriodicPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPeriodicPurchaseOrders.Size = New System.Drawing.Size(1003, 379)
        Me.dgvPeriodicPurchaseOrders.TabIndex = 7
        Me.dgvPeriodicPurchaseOrders.Text = "DataGridView1"
        '
        'tpgServiceInvoices
        '
        Me.tpgServiceInvoices.Controls.Add(Me.dgvPeriodicServiceInvoices)
        Me.tpgServiceInvoices.Location = New System.Drawing.Point(4, 22)
        Me.tpgServiceInvoices.Name = "tpgServiceInvoices"
        Me.tpgServiceInvoices.Size = New System.Drawing.Size(1009, 385)
        Me.tpgServiceInvoices.TabIndex = 11
        Me.tpgServiceInvoices.Tag = "PaymentVouchers"
        Me.tpgServiceInvoices.Text = "Service Invoices"
        Me.tpgServiceInvoices.UseVisualStyleBackColor = True
        '
        'dgvPeriodicServiceInvoices
        '
        Me.dgvPeriodicServiceInvoices.AllowUserToAddRows = False
        Me.dgvPeriodicServiceInvoices.AllowUserToDeleteRows = False
        Me.dgvPeriodicServiceInvoices.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicServiceInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPeriodicServiceInvoices.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPeriodicServiceInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodicServiceInvoices.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPeriodicServiceInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicServiceInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPeriodicServiceInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInvoiceNo, Me.colPurchaseOrderNo, Me.colOrderDate, Me.colSupplierName, Me.colOrderAmount, Me.ColNotPaidFor, Me.ColAmountPaid, Me.ColSIAccountBalance, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicServiceInvoices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPeriodicServiceInvoices.EnableHeadersVisualStyles = False
        Me.dgvPeriodicServiceInvoices.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicServiceInvoices.Location = New System.Drawing.Point(0, 0)
        Me.dgvPeriodicServiceInvoices.Name = "dgvPeriodicServiceInvoices"
        Me.dgvPeriodicServiceInvoices.ReadOnly = True
        Me.dgvPeriodicServiceInvoices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicServiceInvoices.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPeriodicServiceInvoices.RowHeadersVisible = False
        Me.dgvPeriodicServiceInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPeriodicServiceInvoices.Size = New System.Drawing.Size(1009, 385)
        Me.dgvPeriodicServiceInvoices.TabIndex = 10
        Me.dgvPeriodicServiceInvoices.Text = "DataGridView1"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.dtpEndDate)
        Me.grpSetParameters.Controls.Add(Me.lblEndDateTime)
        Me.grpSetParameters.Controls.Add(Me.fbnRefresh)
        Me.grpSetParameters.Controls.Add(Me.lblStartDateTime)
        Me.grpSetParameters.Controls.Add(Me.fbnExport)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.dtpStartDate)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 3)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1013, 76)
        Me.grpSetParameters.TabIndex = 4
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Collection Period"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(569, 14)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(425, 16)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(138, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(838, 42)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 5
        Me.fbnRefresh.Text = "&Refresh"
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(12, 16)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(186, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Record Date && Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(917, 42)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(447, 47)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(283, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(212, 16)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(203, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(760, 42)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "&Load"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(957, 502)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 12
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'ColGRNNo
        '
        Me.ColGRNNo.DataPropertyName = "GRNNo"
        Me.ColGRNNo.HeaderText = "GRNNo"
        Me.ColGRNNo.Name = "ColGRNNo"
        Me.ColGRNNo.ReadOnly = True
        '
        'ColGIPurchaseOrderNo
        '
        Me.ColGIPurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        Me.ColGIPurchaseOrderNo.HeaderText = "Order No"
        Me.ColGIPurchaseOrderNo.Name = "ColGIPurchaseOrderNo"
        Me.ColGIPurchaseOrderNo.ReadOnly = True
        Me.ColGIPurchaseOrderNo.Width = 80
        '
        'ColGIOrderDate
        '
        Me.ColGIOrderDate.DataPropertyName = "OrderDate"
        Me.ColGIOrderDate.HeaderText = "Order Date"
        Me.ColGIOrderDate.Name = "ColGIOrderDate"
        Me.ColGIOrderDate.ReadOnly = True
        Me.ColGIOrderDate.Width = 80
        '
        'colDocumentNo
        '
        Me.colDocumentNo.DataPropertyName = "DocumentNo"
        Me.colDocumentNo.HeaderText = "Document No"
        Me.colDocumentNo.Name = "colDocumentNo"
        Me.colDocumentNo.ReadOnly = True
        '
        'ColGISupplierName
        '
        Me.ColGISupplierName.DataPropertyName = "SupplierName"
        Me.ColGISupplierName.HeaderText = "Supplier Name"
        Me.ColGISupplierName.Name = "ColGISupplierName"
        Me.ColGISupplierName.ReadOnly = True
        Me.ColGISupplierName.Width = 150
        '
        'ColGIOrderAmount
        '
        Me.ColGIOrderAmount.DataPropertyName = "OrderAmount"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ColGIOrderAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColGIOrderAmount.HeaderText = "Order Amount"
        Me.ColGIOrderAmount.Name = "ColGIOrderAmount"
        Me.ColGIOrderAmount.ReadOnly = True
        '
        'ColGINotPaidAmount
        '
        Me.ColGINotPaidAmount.DataPropertyName = "NotPaidAmount"
        Me.ColGINotPaidAmount.HeaderText = "Amount Not Paid"
        Me.ColGINotPaidAmount.Name = "ColGINotPaidAmount"
        Me.ColGINotPaidAmount.ReadOnly = True
        '
        'ColGIPaidAmount
        '
        Me.ColGIPaidAmount.DataPropertyName = "PaidAmount"
        Me.ColGIPaidAmount.HeaderText = "Amount Paid"
        Me.ColGIPaidAmount.Name = "ColGIPaidAmount"
        Me.ColGIPaidAmount.ReadOnly = True
        '
        'ColAccountBalance
        '
        Me.ColAccountBalance.DataPropertyName = "AccountBalance"
        Me.ColAccountBalance.HeaderText = "Account Balance"
        Me.ColAccountBalance.Name = "ColAccountBalance"
        Me.ColAccountBalance.ReadOnly = True
        '
        'colIsPurchaseOrderReceived
        '
        Me.colIsPurchaseOrderReceived.DataPropertyName = "IsPurchaseOrderReceived"
        Me.colIsPurchaseOrderReceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colIsPurchaseOrderReceived.HeaderText = "Order Received"
        Me.colIsPurchaseOrderReceived.Name = "colIsPurchaseOrderReceived"
        Me.colIsPurchaseOrderReceived.ReadOnly = True
        Me.colIsPurchaseOrderReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColGIRecordDate
        '
        Me.ColGIRecordDate.DataPropertyName = "RecordDate"
        Me.ColGIRecordDate.HeaderText = "Record Date"
        Me.ColGIRecordDate.Name = "ColGIRecordDate"
        Me.ColGIRecordDate.ReadOnly = True
        Me.ColGIRecordDate.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "RecordTime"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Record Time"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 75
        '
        'ColInvoiceNo
        '
        Me.ColInvoiceNo.DataPropertyName = "ServiceInvoiceNo"
        Me.ColInvoiceNo.HeaderText = "Invoice No"
        Me.ColInvoiceNo.Name = "ColInvoiceNo"
        Me.ColInvoiceNo.ReadOnly = True
        '
        'colPurchaseOrderNo
        '
        Me.colPurchaseOrderNo.DataPropertyName = "DocumentNo"
        Me.colPurchaseOrderNo.HeaderText = "Document No"
        Me.colPurchaseOrderNo.Name = "colPurchaseOrderNo"
        Me.colPurchaseOrderNo.ReadOnly = True
        Me.colPurchaseOrderNo.Width = 80
        '
        'colOrderDate
        '
        Me.colOrderDate.DataPropertyName = "OrderDate"
        Me.colOrderDate.HeaderText = "Order Date"
        Me.colOrderDate.Name = "colOrderDate"
        Me.colOrderDate.ReadOnly = True
        Me.colOrderDate.Width = 80
        '
        'colSupplierName
        '
        Me.colSupplierName.DataPropertyName = "SupplierName"
        Me.colSupplierName.HeaderText = "Supplier Name"
        Me.colSupplierName.Name = "colSupplierName"
        Me.colSupplierName.ReadOnly = True
        Me.colSupplierName.Width = 150
        '
        'colOrderAmount
        '
        Me.colOrderAmount.DataPropertyName = "OrderAmount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colOrderAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colOrderAmount.HeaderText = "Order Amount"
        Me.colOrderAmount.Name = "colOrderAmount"
        Me.colOrderAmount.ReadOnly = True
        '
        'ColNotPaidFor
        '
        Me.ColNotPaidFor.DataPropertyName = "NotPaidAmount"
        Me.ColNotPaidFor.HeaderText = "Amount Not Paid"
        Me.ColNotPaidFor.Name = "ColNotPaidFor"
        Me.ColNotPaidFor.ReadOnly = True
        '
        'ColAmountPaid
        '
        Me.ColAmountPaid.DataPropertyName = "PaidAmount"
        Me.ColAmountPaid.HeaderText = "Amount Paid"
        Me.ColAmountPaid.Name = "ColAmountPaid"
        Me.ColAmountPaid.ReadOnly = True
        '
        'ColSIAccountBalance
        '
        Me.ColSIAccountBalance.DataPropertyName = "AccountBalance"
        Me.ColSIAccountBalance.HeaderText = "Account Balance"
        Me.ColSIAccountBalance.Name = "ColSIAccountBalance"
        Me.ColSIAccountBalance.ReadOnly = True
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        Me.colRecordDate.Width = 80
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 75
        '
        'frmPaymentVoucherBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 538)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.tbcPaymentVouchers)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPaymentVoucherBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Voucher Balances"
        Me.tbcPaymentVouchers.ResumeLayout(False)
        Me.tpgGoodsInvoices.ResumeLayout(False)
        CType(Me.dgvPeriodicPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgServiceInvoices.ResumeLayout(False)
        CType(Me.dgvPeriodicServiceInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcPaymentVouchers As System.Windows.Forms.TabControl
    Friend WithEvents tpgGoodsInvoices As System.Windows.Forms.TabPage
    Friend WithEvents tpgServiceInvoices As System.Windows.Forms.TabPage
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPeriodicPurchaseOrders As System.Windows.Forms.DataGridView
    Friend WithEvents dgvPeriodicServiceInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents ColGRNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGIPurchaseOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGIOrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocumentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGISupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGIOrderAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGINotPaidAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGIPaidAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAccountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsPurchaseOrderReceived As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColGIRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPurchaseOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNotPaidFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSIAccountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
