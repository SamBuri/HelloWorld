
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInWardAdmissions : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal autoNumber As AutoNumber)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._AutoNumber = autoNumber
    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal autoNumber As AutoNumber, ByVal IPDNurseState As Boolean)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._AutoNumber = autoNumber
        Me._IPDNurseState = IPDNurseState
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInWardAdmissions))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvInWardAdmissions = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBedName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoomNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoomName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        CType(Me.dgvInWardAdmissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(742, 318)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvInWardAdmissions
        '
        Me.dgvInWardAdmissions.AllowUserToAddRows = False
        Me.dgvInWardAdmissions.AllowUserToDeleteRows = False
        Me.dgvInWardAdmissions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvInWardAdmissions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInWardAdmissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInWardAdmissions.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInWardAdmissions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInWardAdmissions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInWardAdmissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInWardAdmissions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInWardAdmissions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNo, Me.colAdmissionNo, Me.colAdmissionDateTime, Me.colFullName, Me.colGender, Me.colAge, Me.colVisitDate, Me.colBillCustomerName, Me.colWard, Me.colBedNo, Me.colBedName, Me.colRoomNo, Me.colRoomName})
        Me.dgvInWardAdmissions.ContextMenuStrip = Me.cmsAlertList
        Me.dgvInWardAdmissions.EnableHeadersVisualStyles = False
        Me.dgvInWardAdmissions.GridColor = System.Drawing.Color.Khaki
        Me.dgvInWardAdmissions.Location = New System.Drawing.Point(8, 73)
        Me.dgvInWardAdmissions.Name = "dgvInWardAdmissions"
        Me.dgvInWardAdmissions.ReadOnly = True
        Me.dgvInWardAdmissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInWardAdmissions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInWardAdmissions.RowHeadersVisible = False
        Me.dgvInWardAdmissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInWardAdmissions.Size = New System.Drawing.Size(806, 236)
        Me.dgvInWardAdmissions.TabIndex = 0
        Me.dgvInWardAdmissions.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 80
        '
        'colAdmissionNo
        '
        Me.colAdmissionNo.DataPropertyName = "AdmissionNo"
        Me.colAdmissionNo.HeaderText = "Admission No"
        Me.colAdmissionNo.Name = "colAdmissionNo"
        Me.colAdmissionNo.ReadOnly = True
        Me.colAdmissionNo.Width = 80
        '
        'colAdmissionDateTime
        '
        Me.colAdmissionDateTime.DataPropertyName = "AdmissionDateTime"
        Me.colAdmissionDateTime.HeaderText = "Admission Date & Time"
        Me.colAdmissionDateTime.Name = "colAdmissionDateTime"
        Me.colAdmissionDateTime.ReadOnly = True
        Me.colAdmissionDateTime.Width = 120
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
        Me.colGender.Width = 60
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 40
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'colWard
        '
        Me.colWard.DataPropertyName = "Ward"
        Me.colWard.HeaderText = "Ward"
        Me.colWard.Name = "colWard"
        Me.colWard.ReadOnly = True
        Me.colWard.Width = 80
        '
        'colBedNo
        '
        Me.colBedNo.DataPropertyName = "BedNo"
        Me.colBedNo.HeaderText = "Bed No"
        Me.colBedNo.Name = "colBedNo"
        Me.colBedNo.ReadOnly = True
        Me.colBedNo.Width = 60
        '
        'colBedName
        '
        Me.colBedName.DataPropertyName = "BedName"
        Me.colBedName.HeaderText = "Bed Name"
        Me.colBedName.Name = "colBedName"
        Me.colBedName.ReadOnly = True
        Me.colBedName.Width = 80
        '
        'colRoomNo
        '
        Me.colRoomNo.DataPropertyName = "RoomNo"
        Me.colRoomNo.HeaderText = "Room No"
        Me.colRoomNo.Name = "colRoomNo"
        Me.colRoomNo.ReadOnly = True
        Me.colRoomNo.Width = 60
        '
        'colRoomName
        '
        Me.colRoomName.DataPropertyName = "RoomName"
        Me.colRoomName.HeaderText = "Room Name"
        Me.colRoomName.Name = "colRoomName"
        Me.colRoomName.ReadOnly = True
        Me.colRoomName.Width = 80
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
        Me.lblMessage.Location = New System.Drawing.Point(244, 322)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(7, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(796, 62)
        Me.grpPeriod.TabIndex = 3
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Admission Period"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.AccessibleDescription = ""
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(395, 38)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(156, 13)
        Me.lblRecordsNo.TabIndex = 6
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(392, 13)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(221, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(321, 13)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(65, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(619, 13)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(82, 15)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(222, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(6, 14)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(70, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmInWardAdmissions
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(824, 354)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvInWardAdmissions)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInWardAdmissions"
        Me.Tag = ""
        Me.Text = "In Ward Admissions"
        CType(Me.dgvInWardAdmissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvInWardAdmissions As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBedNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBedName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoomNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoomName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class