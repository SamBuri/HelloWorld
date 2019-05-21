<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodicReturnedExtraBillItems
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


    Public Sub New(ByVal visitState As Boolean, ByVal controlAlertNo As Control)
        MyClass.New()
        Me._VisitState = visitState
        Me.alertNoControl = controlAlertNo
    End Sub

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodicReturnedExtraBillItems))
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvReturnedExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.rdoGetPeriod = New System.Windows.Forms.RadioButton()
        Me.rdoGetAll = New System.Windows.Forms.RadioButton()
        Me.pnlReturnedExtraBillItems = New System.Windows.Forms.Panel()
        Me.colExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugDispensedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemTransferStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvReturnedExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlReturnedExtraBillItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 35)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(854, 63)
        Me.grpSetParameters.TabIndex = 1
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Bill Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 17)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(641, 31)
        Me.pnlPeriod.TabIndex = 4
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDate.Location = New System.Drawing.Point(410, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(216, 20)
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
        Me.dtpStartDate.CustomFormat = "dd MMM yyyy"
        Me.dtpStartDate.Location = New System.Drawing.Point(103, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(204, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(315, 5)
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
        Me.lblRecordsNo.Location = New System.Drawing.Point(658, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(178, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(730, 29)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 28)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'dgvReturnedExtraBillItems
        '
        Me.dgvReturnedExtraBillItems.AllowUserToAddRows = False
        Me.dgvReturnedExtraBillItems.AllowUserToDeleteRows = False
        Me.dgvReturnedExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvReturnedExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvReturnedExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvReturnedExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnedExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExtraBillNo, Me.colItemCode, Me.colItem, Me.colDrugReturnDate, Me.colDrugNotes, Me.colDrugReturnedQuantity, Me.colDrugDispensedQuantity, Me.colDrugUnitPrice, Me.colDrugPayStatus, Me.colItemTransferStatus, Me.colDrugEntryMode})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReturnedExtraBillItems.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvReturnedExtraBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReturnedExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvReturnedExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvReturnedExtraBillItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvReturnedExtraBillItems.Name = "dgvReturnedExtraBillItems"
        Me.dgvReturnedExtraBillItems.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvReturnedExtraBillItems.RowHeadersVisible = False
        Me.dgvReturnedExtraBillItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvReturnedExtraBillItems.Size = New System.Drawing.Size(1034, 249)
        Me.dgvReturnedExtraBillItems.TabIndex = 2
        Me.dgvReturnedExtraBillItems.Text = "DataGridView1"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(327, 389)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(968, 385)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 5
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'rdoGetPeriod
        '
        Me.rdoGetPeriod.Checked = True
        Me.rdoGetPeriod.Location = New System.Drawing.Point(17, 12)
        Me.rdoGetPeriod.Name = "rdoGetPeriod"
        Me.rdoGetPeriod.Size = New System.Drawing.Size(346, 20)
        Me.rdoGetPeriod.TabIndex = 6
        Me.rdoGetPeriod.TabStop = True
        Me.rdoGetPeriod.Text = "Get Pending Items for Set Period"
        '
        'rdoGetAll
        '
        Me.rdoGetAll.Location = New System.Drawing.Point(369, 13)
        Me.rdoGetAll.Name = "rdoGetAll"
        Me.rdoGetAll.Size = New System.Drawing.Size(200, 20)
        Me.rdoGetAll.TabIndex = 7
        Me.rdoGetAll.Text = "Get All Pending Items"
        '
        'pnlReturnedExtraBillItems
        '
        Me.pnlReturnedExtraBillItems.Controls.Add(Me.dgvReturnedExtraBillItems)
        Me.pnlReturnedExtraBillItems.Location = New System.Drawing.Point(12, 117)
        Me.pnlReturnedExtraBillItems.Name = "pnlReturnedExtraBillItems"
        Me.pnlReturnedExtraBillItems.Size = New System.Drawing.Size(1034, 249)
        Me.pnlReturnedExtraBillItems.TabIndex = 8
        '
        'colExtraBillNo
        '
        Me.colExtraBillNo.DataPropertyName = "ExtraBillNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExtraBillNo.HeaderText = "ExtraBill No"
        Me.colExtraBillNo.Name = "colExtraBillNo"
        Me.colExtraBillNo.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemCode.HeaderText = "Item"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 50
        '
        'colItem
        '
        Me.colItem.DataPropertyName = "ItemFullName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItem.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItem.HeaderText = "Item Name"
        Me.colItem.Name = "colItem"
        Me.colItem.ReadOnly = True
        Me.colItem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItem.Width = 200
        '
        'colDrugReturnDate
        '
        Me.colDrugReturnDate.DataPropertyName = "AdjustmentDate"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugReturnDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDrugReturnDate.HeaderText = "Adjustment Date"
        Me.colDrugReturnDate.Name = "colDrugReturnDate"
        Me.colDrugReturnDate.ReadOnly = True
        Me.colDrugReturnDate.Width = 90
        '
        'colDrugNotes
        '
        Me.colDrugNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugNotes.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugNotes.HeaderText = "Notes"
        Me.colDrugNotes.MaxInputLength = 200
        Me.colDrugNotes.Name = "colDrugNotes"
        Me.colDrugNotes.ReadOnly = True
        '
        'colDrugReturnedQuantity
        '
        Me.colDrugReturnedQuantity.DataPropertyName = "ReturnedQuantity"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugReturnedQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugReturnedQuantity.HeaderText = "Returned Qty"
        Me.colDrugReturnedQuantity.Name = "colDrugReturnedQuantity"
        Me.colDrugReturnedQuantity.ReadOnly = True
        '
        'colDrugDispensedQuantity
        '
        Me.colDrugDispensedQuantity.DataPropertyName = "DispensedQuantity"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colDrugDispensedQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDrugDispensedQuantity.HeaderText = "Dispensed Qty"
        Me.colDrugDispensedQuantity.Name = "colDrugDispensedQuantity"
        Me.colDrugDispensedQuantity.ReadOnly = True
        '
        'colDrugUnitPrice
        '
        Me.colDrugUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 80
        '
        'colDrugPayStatus
        '
        Me.colDrugPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 80
        '
        'colItemTransferStatus
        '
        Me.colItemTransferStatus.DataPropertyName = "IsAcknowledged"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colItemTransferStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colItemTransferStatus.HeaderText = "Acknowledged"
        Me.colItemTransferStatus.Name = "colItemTransferStatus"
        Me.colItemTransferStatus.ReadOnly = True
        '
        'colDrugEntryMode
        '
        Me.colDrugEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugEntryMode.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDrugEntryMode.HeaderText = "Entry Mode"
        Me.colDrugEntryMode.Name = "colDrugEntryMode"
        Me.colDrugEntryMode.ReadOnly = True
        Me.colDrugEntryMode.Width = 80
        '
        'frmPeriodicReturnedExtraBillItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1052, 421)
        Me.Controls.Add(Me.pnlReturnedExtraBillItems)
        Me.Controls.Add(Me.rdoGetPeriod)
        Me.Controls.Add(Me.rdoGetAll)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPeriodicReturnedExtraBillItems"
        Me.Text = "Periodic Returned Extra Bill Items"
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvReturnedExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlReturnedExtraBillItems.ResumeLayout(False)
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
    Friend WithEvents dgvReturnedExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents rdoGetPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGetAll As System.Windows.Forms.RadioButton
    Friend WithEvents pnlReturnedExtraBillItems As System.Windows.Forms.Panel
    Friend WithEvents colExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugDispensedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemTransferStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
