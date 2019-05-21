<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotPaidGRNs
    Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotPaidGRNs))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvPeriodicPurchaseOrders = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColGRNNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPurchaseOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNotPaidFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIsPurchaseOrderReceived = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvPeriodicPurchaseOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 8)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(866, 63)
        Me.grpSetParameters.TabIndex = 4
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Order Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 17)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(650, 31)
        Me.pnlPeriod.TabIndex = 0
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(413, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(231, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(7, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(73, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(84, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(220, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(332, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(73, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(674, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(178, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(677, 29)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 28)
        Me.fbnLoad.TabIndex = 2
        Me.fbnLoad.Text = "Load..."
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(230, 341)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPeriodicPurchaseOrders
        '
        Me.dgvPeriodicPurchaseOrders.AllowUserToAddRows = False
        Me.dgvPeriodicPurchaseOrders.AllowUserToDeleteRows = False
        Me.dgvPeriodicPurchaseOrders.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicPurchaseOrders.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodicPurchaseOrders.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.dgvPeriodicPurchaseOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColGRNNo, Me.colPurchaseOrderNo, Me.colOrderDate, Me.colDocumentNo, Me.colSupplierName, Me.colOrderAmount, Me.ColNotPaidFor, Me.ColAmountPaid, Me.colIsPurchaseOrderReceived, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicPurchaseOrders.EnableHeadersVisualStyles = False
        Me.dgvPeriodicPurchaseOrders.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicPurchaseOrders.Location = New System.Drawing.Point(8, 77)
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
        Me.dgvPeriodicPurchaseOrders.Size = New System.Drawing.Size(865, 254)
        Me.dgvPeriodicPurchaseOrders.TabIndex = 5
        Me.dgvPeriodicPurchaseOrders.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(801, 341)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(123, 48)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'ColGRNNo
        '
        Me.ColGRNNo.DataPropertyName = "GRNNo"
        Me.ColGRNNo.HeaderText = "GRNNo"
        Me.ColGRNNo.Name = "ColGRNNo"
        Me.ColGRNNo.ReadOnly = True
        '
        'colPurchaseOrderNo
        '
        Me.colPurchaseOrderNo.DataPropertyName = "PurchaseOrderNo"
        Me.colPurchaseOrderNo.HeaderText = "Order No"
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
        'colDocumentNo
        '
        Me.colDocumentNo.DataPropertyName = "DocumentNo"
        Me.colDocumentNo.HeaderText = "Document No"
        Me.colDocumentNo.Name = "colDocumentNo"
        Me.colDocumentNo.ReadOnly = True
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colOrderAmount.DefaultCellStyle = DataGridViewCellStyle3
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
        'colIsPurchaseOrderReceived
        '
        Me.colIsPurchaseOrderReceived.DataPropertyName = "IsPurchaseOrderReceived"
        Me.colIsPurchaseOrderReceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colIsPurchaseOrderReceived.HeaderText = "Order Received"
        Me.colIsPurchaseOrderReceived.Name = "colIsPurchaseOrderReceived"
        Me.colIsPurchaseOrderReceived.ReadOnly = True
        Me.colIsPurchaseOrderReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        'frmNotPaidGRNs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 373)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPeriodicPurchaseOrders)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmNotPaidGRNs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodic Goods Received Notes"
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvPeriodicPurchaseOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvPeriodicPurchaseOrders As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColGRNNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPurchaseOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDocumentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNotPaidFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIsPurchaseOrderReceived As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
