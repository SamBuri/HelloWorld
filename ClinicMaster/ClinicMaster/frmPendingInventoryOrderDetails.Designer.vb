
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingInventoryOrderDetails : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingInventoryOrderDetails))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPendingInventoryOrderDetails = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.cboToLocationID = New System.Windows.Forms.ComboBox()
        Me.lblToLocationID = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFromLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPendingInventoryOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.fbnClose.Location = New System.Drawing.Point(790, 347)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPendingInventoryOrderDetails
        '
        Me.dgvPendingInventoryOrderDetails.AllowUserToAddRows = False
        Me.dgvPendingInventoryOrderDetails.AllowUserToDeleteRows = False
        Me.dgvPendingInventoryOrderDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPendingInventoryOrderDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingInventoryOrderDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPendingInventoryOrderDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingInventoryOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingInventoryOrderDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPendingInventoryOrderDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingInventoryOrderDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingInventoryOrderDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOrderNo, Me.colOrderDate, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colFromLocation, Me.colToLocation, Me.colQuantity, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPendingInventoryOrderDetails.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPendingInventoryOrderDetails.EnableHeadersVisualStyles = False
        Me.dgvPendingInventoryOrderDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingInventoryOrderDetails.Location = New System.Drawing.Point(8, 91)
        Me.dgvPendingInventoryOrderDetails.Name = "dgvPendingInventoryOrderDetails"
        Me.dgvPendingInventoryOrderDetails.ReadOnly = True
        Me.dgvPendingInventoryOrderDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingInventoryOrderDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPendingInventoryOrderDetails.RowHeadersVisible = False
        Me.dgvPendingInventoryOrderDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPendingInventoryOrderDetails.Size = New System.Drawing.Size(854, 247)
        Me.dgvPendingInventoryOrderDetails.TabIndex = 1
        Me.dgvPendingInventoryOrderDetails.Text = "DataGridView1"
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
        Me.lblMessage.Location = New System.Drawing.Point(268, 351)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.cboToLocationID)
        Me.grpSetParameters.Controls.Add(Me.lblToLocationID)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(855, 81)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Order Period"
        '
        'cboToLocationID
        '
        Me.cboToLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboToLocationID.Location = New System.Drawing.Point(108, 20)
        Me.cboToLocationID.Name = "cboToLocationID"
        Me.cboToLocationID.Size = New System.Drawing.Size(184, 21)
        Me.cboToLocationID.TabIndex = 1
        '
        'lblToLocationID
        '
        Me.lblToLocationID.Location = New System.Drawing.Point(18, 21)
        Me.lblToLocationID.Name = "lblToLocationID"
        Me.lblToLocationID.Size = New System.Drawing.Size(80, 20)
        Me.lblToLocationID.TabIndex = 0
        Me.lblToLocationID.Text = "To Location"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 44)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(594, 31)
        Me.pnlPeriod.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(397, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
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
        Me.dtpStartDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(296, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(89, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(606, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(237, 13)
        Me.lblRecordsNo.TabIndex = 2
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(737, 40)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'colOrderNo
        '
        Me.colOrderNo.DataPropertyName = "OrderNo"
        Me.colOrderNo.HeaderText = "Order No"
        Me.colOrderNo.Name = "colOrderNo"
        Me.colOrderNo.ReadOnly = True
        Me.colOrderNo.Width = 80
        '
        'colOrderDate
        '
        Me.colOrderDate.DataPropertyName = "OrderDate"
        Me.colOrderDate.HeaderText = "Order Date"
        Me.colOrderDate.Name = "colOrderDate"
        Me.colOrderDate.ReadOnly = True
        Me.colOrderDate.Width = 80
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 80
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Width = 80
        '
        'colFromLocation
        '
        Me.colFromLocation.DataPropertyName = "FromLocation"
        Me.colFromLocation.HeaderText = "From Location"
        Me.colFromLocation.Name = "colFromLocation"
        Me.colFromLocation.ReadOnly = True
        '
        'colToLocation
        '
        Me.colToLocation.DataPropertyName = "ToLocation"
        Me.colToLocation.HeaderText = "To Location"
        Me.colToLocation.Name = "colToLocation"
        Me.colToLocation.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
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
        'frmPendingInventoryOrderDetails
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(872, 383)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPendingInventoryOrderDetails)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPendingInventoryOrderDetails"
        Me.Tag = ""
        Me.Text = "Pending Inventory Order Details"
        CType(Me.dgvPendingInventoryOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPendingInventoryOrderDetails As System.Windows.Forms.DataGridView
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
    Friend WithEvents cboToLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToLocationID As System.Windows.Forms.Label
    Friend WithEvents colOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFromLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class