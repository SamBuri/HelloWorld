<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToSeeDoctorsVisits
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToSeeDoctorsVisits))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.dgvSeeDoctorVisits = New System.Windows.Forms.DataGridView()
        Me.colStaffNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStaffName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeenVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotSeenVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancelledVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInPatientVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalConsultationFeeSeenVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalConsultationFeeUnSeenVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalConsultationFeeInPatientVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalConsultationFeeCancelledVisits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlPeriod.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.cmsAlertList.SuspendLayout()
        CType(Me.dgvSeeDoctorVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(637, 31)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 22)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(397, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(6, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(102, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(117, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(317, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(75, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.cboStaffNo)
        Me.pnlPeriod.Controls.Add(Me.lblStaff)
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(20, 25)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(594, 52)
        Me.pnlPeriod.TabIndex = 4
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.DropDownWidth = 220
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(117, 27)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(184, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 7
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(6, 27)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(102, 20)
        Me.lblStaff.TabIndex = 6
        Me.lblStaff.Text = "Primary Dr. (Staff)"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(6, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(855, 85)
        Me.grpSetParameters.TabIndex = 4
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(637, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(206, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(296, 358)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
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
        'dgvSeeDoctorVisits
        '
        Me.dgvSeeDoctorVisits.AllowUserToAddRows = False
        Me.dgvSeeDoctorVisits.AllowUserToDeleteRows = False
        Me.dgvSeeDoctorVisits.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSeeDoctorVisits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSeeDoctorVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSeeDoctorVisits.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSeeDoctorVisits.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSeeDoctorVisits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSeeDoctorVisits.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSeeDoctorVisits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSeeDoctorVisits.ColumnHeadersHeight = 25
        Me.dgvSeeDoctorVisits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStaffNo, Me.colStaffName, Me.colSeenVisits, Me.colNotSeenVisits, Me.colCancelledVisits, Me.colInPatientVisits, Me.colTotalConsultationFeeSeenVisits, Me.colTotalConsultationFeeUnSeenVisits, Me.colTotalConsultationFeeInPatientVisits, Me.colTotalConsultationFeeCancelledVisits})
        Me.dgvSeeDoctorVisits.ContextMenuStrip = Me.cmsAlertList
        Me.dgvSeeDoctorVisits.EnableHeadersVisualStyles = False
        Me.dgvSeeDoctorVisits.GridColor = System.Drawing.Color.Khaki
        Me.dgvSeeDoctorVisits.Location = New System.Drawing.Point(6, 95)
        Me.dgvSeeDoctorVisits.Name = "dgvSeeDoctorVisits"
        Me.dgvSeeDoctorVisits.ReadOnly = True
        Me.dgvSeeDoctorVisits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSeeDoctorVisits.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSeeDoctorVisits.RowHeadersVisible = False
        Me.dgvSeeDoctorVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSeeDoctorVisits.Size = New System.Drawing.Size(843, 254)
        Me.dgvSeeDoctorVisits.TabIndex = 5
        Me.dgvSeeDoctorVisits.Text = "DataGridView1"
        '
        'colStaffNo
        '
        Me.colStaffNo.DataPropertyName = "StaffNo"
        Me.colStaffNo.HeaderText = "Staff No"
        Me.colStaffNo.Name = "colStaffNo"
        Me.colStaffNo.ReadOnly = True
        '
        'colStaffName
        '
        Me.colStaffName.DataPropertyName = "StaffName"
        Me.colStaffName.HeaderText = "Staff Name"
        Me.colStaffName.Name = "colStaffName"
        Me.colStaffName.ReadOnly = True
        Me.colStaffName.Width = 134
        '
        'colSeenVisits
        '
        Me.colSeenVisits.DataPropertyName = "SeenVisits"
        Me.colSeenVisits.HeaderText = "Seen Visits"
        Me.colSeenVisits.Name = "colSeenVisits"
        Me.colSeenVisits.ReadOnly = True
        '
        'colNotSeenVisits
        '
        Me.colNotSeenVisits.DataPropertyName = "NotSeenVisits"
        Me.colNotSeenVisits.HeaderText = "UnSeen Visits"
        Me.colNotSeenVisits.Name = "colNotSeenVisits"
        Me.colNotSeenVisits.ReadOnly = True
        '
        'colCancelledVisits
        '
        Me.colCancelledVisits.DataPropertyName = "CancelledVisits"
        Me.colCancelledVisits.HeaderText = "Cancelled Visits"
        Me.colCancelledVisits.Name = "colCancelledVisits"
        Me.colCancelledVisits.ReadOnly = True
        Me.colCancelledVisits.Width = 143
        '
        'colInPatientVisits
        '
        Me.colInPatientVisits.DataPropertyName = "InPatientVisits"
        Me.colInPatientVisits.HeaderText = "In Patient Visits"
        Me.colInPatientVisits.Name = "colInPatientVisits"
        Me.colInPatientVisits.ReadOnly = True
        Me.colInPatientVisits.Width = 144
        '
        'colTotalConsultationFeeSeenVisits
        '
        Me.colTotalConsultationFeeSeenVisits.DataPropertyName = "TotalConsultationFeeSeenVisits"
        Me.colTotalConsultationFeeSeenVisits.HeaderText = "Total Seen Visits"
        Me.colTotalConsultationFeeSeenVisits.Name = "colTotalConsultationFeeSeenVisits"
        Me.colTotalConsultationFeeSeenVisits.ReadOnly = True
        Me.colTotalConsultationFeeSeenVisits.Width = 143
        '
        'colTotalConsultationFeeUnSeenVisits
        '
        Me.colTotalConsultationFeeUnSeenVisits.DataPropertyName = "TotalConsultationFeeUnSeenVisits"
        Me.colTotalConsultationFeeUnSeenVisits.HeaderText = "Total UnSeen Visits"
        Me.colTotalConsultationFeeUnSeenVisits.Name = "colTotalConsultationFeeUnSeenVisits"
        Me.colTotalConsultationFeeUnSeenVisits.ReadOnly = True
        Me.colTotalConsultationFeeUnSeenVisits.Width = 144
        '
        'colTotalConsultationFeeInPatientVisits
        '
        Me.colTotalConsultationFeeInPatientVisits.DataPropertyName = "TotalConsultationFeeInPatientVisits"
        Me.colTotalConsultationFeeInPatientVisits.HeaderText = "Total InPatient Visits"
        Me.colTotalConsultationFeeInPatientVisits.Name = "colTotalConsultationFeeInPatientVisits"
        Me.colTotalConsultationFeeInPatientVisits.ReadOnly = True
        Me.colTotalConsultationFeeInPatientVisits.Width = 143
        '
        'colTotalConsultationFeeCancelledVisits
        '
        Me.colTotalConsultationFeeCancelledVisits.DataPropertyName = "TotalConsultationFeeCancelledVisits"
        Me.colTotalConsultationFeeCancelledVisits.HeaderText = "Total Cancelled Visits"
        Me.colTotalConsultationFeeCancelledVisits.Name = "colTotalConsultationFeeCancelledVisits"
        Me.colTotalConsultationFeeCancelledVisits.ReadOnly = True
        Me.colTotalConsultationFeeCancelledVisits.Width = 144
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(786, 353)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmToSeeDoctorsVisits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(866, 386)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvSeeDoctorVisits)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmToSeeDoctorsVisits"
        Me.Text = "Doctor Visits"
        Me.pnlPeriod.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.cmsAlertList.ResumeLayout(False)
        CType(Me.dgvSeeDoctorVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents dgvSeeDoctorVisits As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents colStaffNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeenVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotSeenVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancelledVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInPatientVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalConsultationFeeSeenVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalConsultationFeeUnSeenVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalConsultationFeeInPatientVisits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalConsultationFeeCancelledVisits As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
