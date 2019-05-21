
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoctorIPDItems : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal doctorItemCategory As AlertItemCategory)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me.doctorItemCategory = doctorItemCategory
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDoctorIPDItems))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvDoctorItems = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoundDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAttendingDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.chkShowOnlyPending = New System.Windows.Forms.CheckBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.rdoGetDoctor = New System.Windows.Forms.RadioButton()
        Me.rdoGetAll = New System.Windows.Forms.RadioButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvDoctorItems, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.fbnClose.Location = New System.Drawing.Point(774, 324)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvDoctorItems
        '
        Me.dgvDoctorItems.AllowUserToAddRows = False
        Me.dgvDoctorItems.AllowUserToDeleteRows = False
        Me.dgvDoctorItems.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDoctorItems.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDoctorItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDoctorItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDoctorItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDoctorItems.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDoctorItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDoctorItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDoctorItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colRoundNo, Me.colRoundDateTime, Me.colItemName, Me.colFullName, Me.colGender, Me.colAge, Me.colQuantity, Me.colUnitPrice, Me.colItemStatus, Me.colPayStatus, Me.colDrQuantity, Me.colBillCustomerName, Me.colAttendingDoctor})
        Me.dgvDoctorItems.ContextMenuStrip = Me.cmsAlertList
        Me.dgvDoctorItems.EnableHeadersVisualStyles = False
        Me.dgvDoctorItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvDoctorItems.Location = New System.Drawing.Point(8, 86)
        Me.dgvDoctorItems.Name = "dgvDoctorItems"
        Me.dgvDoctorItems.ReadOnly = True
        Me.dgvDoctorItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDoctorItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDoctorItems.RowHeadersVisible = False
        Me.dgvDoctorItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDoctorItems.Size = New System.Drawing.Size(838, 229)
        Me.dgvDoctorItems.TabIndex = 1
        Me.dgvDoctorItems.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colRoundNo
        '
        Me.colRoundNo.DataPropertyName = "RoundNo"
        Me.colRoundNo.HeaderText = "Round No"
        Me.colRoundNo.Name = "colRoundNo"
        Me.colRoundNo.ReadOnly = True
        Me.colRoundNo.Width = 80
        '
        'colRoundDateTime
        '
        Me.colRoundDateTime.DataPropertyName = "RoundDateTime"
        Me.colRoundDateTime.HeaderText = "Round Date & Time"
        Me.colRoundDateTime.Name = "colRoundDateTime"
        Me.colRoundDateTime.ReadOnly = True
        Me.colRoundDateTime.Width = 120
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
        'colItemStatus
        '
        Me.colItemStatus.DataPropertyName = "ItemStatus"
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 65
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 65
        '
        'colDrQuantity
        '
        Me.colDrQuantity.DataPropertyName = "DrQuantity"
        Me.colDrQuantity.HeaderText = "Dr. Quantity"
        Me.colDrQuantity.Name = "colDrQuantity"
        Me.colDrQuantity.ReadOnly = True
        Me.colDrQuantity.Width = 70
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'colAttendingDoctor
        '
        Me.colAttendingDoctor.DataPropertyName = "AttendingDoctor"
        Me.colAttendingDoctor.HeaderText = "Attending Doctor"
        Me.colAttendingDoctor.Name = "colAttendingDoctor"
        Me.colAttendingDoctor.ReadOnly = True
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
        Me.lblMessage.Location = New System.Drawing.Point(260, 328)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.chkShowOnlyPending)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.rdoGetDoctor)
        Me.grpSetParameters.Controls.Add(Me.rdoGetAll)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(839, 76)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'chkShowOnlyPending
        '
        Me.chkShowOnlyPending.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkShowOnlyPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkShowOnlyPending.Location = New System.Drawing.Point(560, 42)
        Me.chkShowOnlyPending.Name = "chkShowOnlyPending"
        Me.chkShowOnlyPending.Size = New System.Drawing.Size(135, 20)
        Me.chkShowOnlyPending.TabIndex = 4
        Me.chkShowOnlyPending.Text = "Show Only Pending"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 37)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(549, 31)
        Me.pnlPeriod.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(357, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(155, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(72, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(88, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(154, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(248, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(82, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'rdoGetDoctor
        '
        Me.rdoGetDoctor.Checked = True
        Me.rdoGetDoctor.Location = New System.Drawing.Point(10, 13)
        Me.rdoGetDoctor.Name = "rdoGetDoctor"
        Me.rdoGetDoctor.Size = New System.Drawing.Size(346, 20)
        Me.rdoGetDoctor.TabIndex = 0
        Me.rdoGetDoctor.TabStop = True
        Me.rdoGetDoctor.Text = "Get Doctor Items for Set Period"
        '
        'rdoGetAll
        '
        Me.rdoGetAll.Location = New System.Drawing.Point(362, 14)
        Me.rdoGetAll.Name = "rdoGetAll"
        Me.rdoGetAll.Size = New System.Drawing.Size(200, 20)
        Me.rdoGetAll.TabIndex = 1
        Me.rdoGetAll.Text = "Get All Doctor Items"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(568, 14)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(253, 13)
        Me.lblRecordsNo.TabIndex = 2
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(715, 39)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 26)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'frmDoctorIPDItems
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(856, 360)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvDoctorItems)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDoctorIPDItems"
        Me.Tag = ""
        Me.Text = "Doctor IPD Items"
        CType(Me.dgvDoctorItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvDoctorItems As System.Windows.Forms.DataGridView
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
    Friend WithEvents rdoGetDoctor As System.Windows.Forms.RadioButton
    Friend WithEvents rdoGetAll As System.Windows.Forms.RadioButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents chkShowOnlyPending As System.Windows.Forms.CheckBox
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoundDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAttendingDoctor As System.Windows.Forms.DataGridViewTextBoxColumn

End Class