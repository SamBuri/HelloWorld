
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodicInventoryTransfers : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodicInventoryTransfers))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPeriodicInventoryTransfers = New System.Windows.Forms.DataGridView()
        Me.colTransferNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransferDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFromLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvPeriodicInventoryTransfers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(818, 347)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPeriodicInventoryTransfers
        '
        Me.dgvPeriodicInventoryTransfers.AllowUserToAddRows = False
        Me.dgvPeriodicInventoryTransfers.AllowUserToDeleteRows = False
        Me.dgvPeriodicInventoryTransfers.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicInventoryTransfers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodicInventoryTransfers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPeriodicInventoryTransfers.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPeriodicInventoryTransfers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodicInventoryTransfers.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPeriodicInventoryTransfers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicInventoryTransfers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPeriodicInventoryTransfers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTransferNo, Me.colOrderNo, Me.colTransferDate, Me.colFromLocation, Me.colToLocation, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicInventoryTransfers.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPeriodicInventoryTransfers.EnableHeadersVisualStyles = False
        Me.dgvPeriodicInventoryTransfers.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicInventoryTransfers.Location = New System.Drawing.Point(8, 86)
        Me.dgvPeriodicInventoryTransfers.Name = "dgvPeriodicInventoryTransfers"
        Me.dgvPeriodicInventoryTransfers.ReadOnly = True
        Me.dgvPeriodicInventoryTransfers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicInventoryTransfers.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPeriodicInventoryTransfers.RowHeadersVisible = False
        Me.dgvPeriodicInventoryTransfers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPeriodicInventoryTransfers.Size = New System.Drawing.Size(882, 252)
        Me.dgvPeriodicInventoryTransfers.TabIndex = 1
        Me.dgvPeriodicInventoryTransfers.Text = "DataGridView1"
        '
        'colTransferNo
        '
        Me.colTransferNo.DataPropertyName = "TransferNo"
        Me.colTransferNo.HeaderText = "Transfer No"
        Me.colTransferNo.Name = "colTransferNo"
        Me.colTransferNo.ReadOnly = True
        '
        'colOrderNo
        '
        Me.colOrderNo.DataPropertyName = "OrderNo"
        Me.colOrderNo.HeaderText = "Order No"
        Me.colOrderNo.Name = "colOrderNo"
        Me.colOrderNo.ReadOnly = True
        '
        'colTransferDate
        '
        Me.colTransferDate.DataPropertyName = "TransferDate"
        Me.colTransferDate.HeaderText = "Transfer Date"
        Me.colTransferDate.Name = "colTransferDate"
        Me.colTransferDate.ReadOnly = True
        '
        'colFromLocation
        '
        Me.colFromLocation.DataPropertyName = "FromLocation"
        Me.colFromLocation.HeaderText = "From Location"
        Me.colFromLocation.Name = "colFromLocation"
        Me.colFromLocation.ReadOnly = True
        Me.colFromLocation.Width = 120
        '
        'colToLocation
        '
        Me.colToLocation.DataPropertyName = "ToLocation"
        Me.colToLocation.HeaderText = "To Location"
        Me.colToLocation.Name = "colToLocation"
        Me.colToLocation.ReadOnly = True
        Me.colToLocation.Width = 120
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 80
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
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(282, 351)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(881, 63)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Transfer Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 17)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(676, 31)
        Me.pnlPeriod.TabIndex = 0
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(444, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(222, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(83, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(103, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(234, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(372, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(66, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(695, 11)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(178, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(769, 29)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 28)
        Me.fbnLoad.TabIndex = 2
        Me.fbnLoad.Text = "Load..."
        '
        'frmPeriodicInventoryTransfers
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(900, 383)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPeriodicInventoryTransfers)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPeriodicInventoryTransfers"
        Me.Tag = ""
        Me.Text = "Periodic Inventory Transfers"
        CType(Me.dgvPeriodicInventoryTransfers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPeriodicInventoryTransfers As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents colTransferNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransferDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFromLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class