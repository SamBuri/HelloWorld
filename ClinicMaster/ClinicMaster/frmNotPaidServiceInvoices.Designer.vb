<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotPaidServiceInvoices
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotPaidServiceInvoices))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvPeriodicServiceInvoices = New System.Windows.Forms.DataGridView()
        Me.ColInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPurchaseOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNotPaidFor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        CType(Me.dgvPeriodicServiceInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(123, 48)
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(798, 336)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(413, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(231, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(84, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(220, 20)
        Me.dtpStartDate.TabIndex = 1
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
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(332, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(73, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(4, 3)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(866, 63)
        Me.grpSetParameters.TabIndex = 8
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Service Period"
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
        Me.lblMessage.Location = New System.Drawing.Point(227, 336)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 10
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPeriodicServiceInvoices
        '
        Me.dgvPeriodicServiceInvoices.AllowUserToAddRows = False
        Me.dgvPeriodicServiceInvoices.AllowUserToDeleteRows = False
        Me.dgvPeriodicServiceInvoices.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicServiceInvoices.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodicServiceInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPeriodicServiceInvoices.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPeriodicServiceInvoices.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodicServiceInvoices.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPeriodicServiceInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicServiceInvoices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPeriodicServiceInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInvoiceNo, Me.colPurchaseOrderNo, Me.colOrderDate, Me.colSupplierName, Me.colOrderAmount, Me.ColNotPaidFor, Me.ColAmountPaid, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicServiceInvoices.EnableHeadersVisualStyles = False
        Me.dgvPeriodicServiceInvoices.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicServiceInvoices.Location = New System.Drawing.Point(5, 72)
        Me.dgvPeriodicServiceInvoices.Name = "dgvPeriodicServiceInvoices"
        Me.dgvPeriodicServiceInvoices.ReadOnly = True
        Me.dgvPeriodicServiceInvoices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicServiceInvoices.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPeriodicServiceInvoices.RowHeadersVisible = False
        Me.dgvPeriodicServiceInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPeriodicServiceInvoices.Size = New System.Drawing.Size(865, 254)
        Me.dgvPeriodicServiceInvoices.TabIndex = 9
        Me.dgvPeriodicServiceInvoices.Text = "DataGridView1"
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
        'frmNotPaidServiceInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 363)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPeriodicServiceInvoices)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNotPaidServiceInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UnPaid Service Invoices"
        Me.cmsAlertList.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        CType(Me.dgvPeriodicServiceInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvPeriodicServiceInvoices As System.Windows.Forms.DataGridView
    Friend WithEvents ColInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPurchaseOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNotPaidFor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
