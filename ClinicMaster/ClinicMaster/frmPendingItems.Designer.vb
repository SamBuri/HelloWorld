
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingItems : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal pendingItemCategory As AlertItemCategory)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me.pendingItemCategory = pendingItemCategory
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingItems))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPendingItems = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.fbnCall = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.rdoGetPeriod = New System.Windows.Forms.RadioButton()
        Me.rdoGetAll = New System.Windows.Forms.RadioButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTokenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrimaryDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDoctorContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoctorSpecialty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPendingItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.fbnClose.Location = New System.Drawing.Point(875, 324)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPendingItems
        '
        Me.dgvPendingItems.AllowUserToAddRows = False
        Me.dgvPendingItems.AllowUserToDeleteRows = False
        Me.dgvPendingItems.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPendingItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPendingItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPendingItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colFirstName, Me.colTokenNo, Me.colVisitNo, Me.colVisitDate, Me.colItemName, Me.colFullName, Me.colGender, Me.colAge, Me.colBillCustomerName, Me.colPayStatus, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colPrimaryDoctor, Me.ColDoctorContact, Me.colDoctorSpecialty, Me.colRecordDate, Me.colRecordTime, Me.colItemStatus})
        Me.dgvPendingItems.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPendingItems.EnableHeadersVisualStyles = False
        Me.dgvPendingItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingItems.Location = New System.Drawing.Point(8, 86)
        Me.dgvPendingItems.Name = "dgvPendingItems"
        Me.dgvPendingItems.ReadOnly = True
        Me.dgvPendingItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPendingItems.RowHeadersVisible = False
        Me.dgvPendingItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPendingItems.Size = New System.Drawing.Size(939, 229)
        Me.dgvPendingItems.TabIndex = 1
        Me.dgvPendingItems.Text = "DataGridView1"
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
        Me.lblMessage.Location = New System.Drawing.Point(310, 328)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.fbnCall)
        Me.grpSetParameters.Controls.Add(Me.fbnExportTo)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.rdoGetPeriod)
        Me.grpSetParameters.Controls.Add(Me.rdoGetAll)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(940, 76)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'fbnCall
        '
        Me.fbnCall.Enabled = False
        Me.fbnCall.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCall.Location = New System.Drawing.Point(858, 46)
        Me.fbnCall.Name = "fbnCall"
        Me.fbnCall.Size = New System.Drawing.Size(76, 22)
        Me.fbnCall.TabIndex = 7
        Me.fbnCall.Text = "Enqueue"
        Me.fbnCall.Visible = False
        '
        'fbnExportTo
        '
        Me.fbnExportTo.Enabled = False
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(746, 46)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 5
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 37)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(649, 31)
        Me.pnlPeriod.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(424, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(220, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(78, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(94, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(223, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(330, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(89, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoGetPeriod
        '
        Me.rdoGetPeriod.Checked = True
        Me.rdoGetPeriod.Location = New System.Drawing.Point(10, 13)
        Me.rdoGetPeriod.Name = "rdoGetPeriod"
        Me.rdoGetPeriod.Size = New System.Drawing.Size(346, 20)
        Me.rdoGetPeriod.TabIndex = 0
        Me.rdoGetPeriod.TabStop = True
        Me.rdoGetPeriod.Text = "Get Pending Items for Set Period"
        '
        'rdoGetAll
        '
        Me.rdoGetAll.Location = New System.Drawing.Point(362, 14)
        Me.rdoGetAll.Name = "rdoGetAll"
        Me.rdoGetAll.Size = New System.Drawing.Size(200, 20)
        Me.rdoGetAll.TabIndex = 1
        Me.rdoGetAll.Text = "Get All Pending Items"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(605, 14)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(290, 13)
        Me.lblRecordsNo.TabIndex = 2
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(660, 46)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(81, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colFirstName
        '
        Me.colFirstName.DataPropertyName = "FirstName"
        Me.colFirstName.HeaderText = "First Name"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        '
        'colTokenNo
        '
        Me.colTokenNo.DataPropertyName = "TokenNo"
        Me.colTokenNo.HeaderText = "Token No"
        Me.colTokenNo.Name = "colTokenNo"
        Me.colTokenNo.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 80
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 120
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 120
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 50
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 30
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 65
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 65
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colPrimaryDoctor
        '
        Me.colPrimaryDoctor.DataPropertyName = "PrimaryDoctor"
        Me.colPrimaryDoctor.HeaderText = "Primary Doctor"
        Me.colPrimaryDoctor.Name = "colPrimaryDoctor"
        Me.colPrimaryDoctor.ReadOnly = True
        '
        'ColDoctorContact
        '
        Me.ColDoctorContact.DataPropertyName = "DoctorContact"
        Me.ColDoctorContact.HeaderText = "Doctor Contact"
        Me.ColDoctorContact.Name = "ColDoctorContact"
        Me.ColDoctorContact.ReadOnly = True
        '
        'colDoctorSpecialty
        '
        Me.colDoctorSpecialty.DataPropertyName = "DoctorSpecialty"
        Me.colDoctorSpecialty.HeaderText = "Doctor Specialty"
        Me.colDoctorSpecialty.Name = "colDoctorSpecialty"
        Me.colDoctorSpecialty.ReadOnly = True
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
        'colItemStatus
        '
        Me.colItemStatus.DataPropertyName = "ItemStatus"
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 65
        '
        'frmPendingItems
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(957, 360)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPendingItems)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPendingItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "Pending Items"
        CType(Me.dgvPendingItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPendingItems As System.Windows.Forms.DataGridView
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
    Friend WithEvents rdoGetPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGetAll As System.Windows.Forms.RadioButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnCall As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTokenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDoctorContact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDoctorSpecialty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class