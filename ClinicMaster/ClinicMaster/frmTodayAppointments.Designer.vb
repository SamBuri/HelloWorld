
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTodayAppointments : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me._AlertNoControl = controlAlertNo
    End Sub

    Public Sub New(ByVal onlyCurrentUser As Boolean)
        MyClass.New()
        Me._OnlyCurrentUser = onlyCurrentUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTodayAppointments))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvTodayAppointments = New System.Windows.Forms.DataGridView()
        Me.ColInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAppointmentPrecision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeSpecialty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAppointmentDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpTodayAppointments = New System.Windows.Forms.GroupBox()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.btnSendSMS = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvTodayAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.grpTodayAppointments.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(711, 316)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvTodayAppointments
        '
        Me.dgvTodayAppointments.AllowUserToAddRows = False
        Me.dgvTodayAppointments.AllowUserToDeleteRows = False
        Me.dgvTodayAppointments.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTodayAppointments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTodayAppointments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTodayAppointments.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTodayAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTodayAppointments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTodayAppointments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTodayAppointments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTodayAppointments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInclude, Me.colPatientNo, Me.colFullName, Me.colGender, Me.colAge, Me.colPhone, Me.colStartDate, Me.colAppointmentPrecision, Me.colStartTime, Me.colDuration, Me.colEndDate, Me.colToSeeSpecialty, Me.colToSeeDoctor, Me.colAppointmentDes})
        Me.dgvTodayAppointments.ContextMenuStrip = Me.cmsAlertList
        Me.dgvTodayAppointments.EnableHeadersVisualStyles = False
        Me.dgvTodayAppointments.GridColor = System.Drawing.Color.Khaki
        Me.dgvTodayAppointments.Location = New System.Drawing.Point(8, 53)
        Me.dgvTodayAppointments.Name = "dgvTodayAppointments"
        Me.dgvTodayAppointments.ReadOnly = True
        Me.dgvTodayAppointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTodayAppointments.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTodayAppointments.RowHeadersVisible = False
        Me.dgvTodayAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTodayAppointments.Size = New System.Drawing.Size(775, 253)
        Me.dgvTodayAppointments.TabIndex = 1
        Me.dgvTodayAppointments.Text = "DataGridView1"
        '
        'ColInclude
        '
        Me.ColInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColInclude.HeaderText = "Sms"
        Me.ColInclude.Name = "ColInclude"
        Me.ColInclude.ReadOnly = True
        Me.ColInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColInclude.TrueValue = ""
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 150
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 65
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 45
        '
        'colPhone
        '
        Me.colPhone.DataPropertyName = "Phone"
        Me.colPhone.HeaderText = "Phone Number"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        '
        'colStartDate
        '
        Me.colStartDate.DataPropertyName = "StartDate"
        Me.colStartDate.HeaderText = "Start Date"
        Me.colStartDate.Name = "colStartDate"
        Me.colStartDate.ReadOnly = True
        Me.colStartDate.Width = 80
        '
        'colAppointmentPrecision
        '
        Me.colAppointmentPrecision.DataPropertyName = "AppointmentPrecision"
        Me.colAppointmentPrecision.HeaderText = "Appointment Precision"
        Me.colAppointmentPrecision.Name = "colAppointmentPrecision"
        Me.colAppointmentPrecision.ReadOnly = True
        Me.colAppointmentPrecision.Width = 120
        '
        'colStartTime
        '
        Me.colStartTime.DataPropertyName = "StartTime"
        Me.colStartTime.HeaderText = "Start Time"
        Me.colStartTime.Name = "colStartTime"
        Me.colStartTime.ReadOnly = True
        Me.colStartTime.Width = 75
        '
        'colDuration
        '
        Me.colDuration.DataPropertyName = "Duration"
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ReadOnly = True
        Me.colDuration.Width = 60
        '
        'colEndDate
        '
        Me.colEndDate.DataPropertyName = "EndDate"
        Me.colEndDate.HeaderText = "End Date"
        Me.colEndDate.Name = "colEndDate"
        Me.colEndDate.ReadOnly = True
        Me.colEndDate.Width = 80
        '
        'colToSeeSpecialty
        '
        Me.colToSeeSpecialty.DataPropertyName = "ToSeeSpecialty"
        Me.colToSeeSpecialty.HeaderText = "To-See Specialty"
        Me.colToSeeSpecialty.Name = "colToSeeSpecialty"
        Me.colToSeeSpecialty.ReadOnly = True
        '
        'colToSeeDoctor
        '
        Me.colToSeeDoctor.DataPropertyName = "ToSeeDoctor"
        Me.colToSeeDoctor.HeaderText = "To-See Doctor"
        Me.colToSeeDoctor.Name = "colToSeeDoctor"
        Me.colToSeeDoctor.ReadOnly = True
        '
        'colAppointmentDes
        '
        Me.colAppointmentDes.DataPropertyName = "AppointmentDes"
        Me.colAppointmentDes.HeaderText = "Description"
        Me.colAppointmentDes.Name = "colAppointmentDes"
        Me.colAppointmentDes.ReadOnly = True
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
        Me.lblMessage.Location = New System.Drawing.Point(228, 317)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpTodayAppointments
        '
        Me.grpTodayAppointments.Controls.Add(Me.fbnExport)
        Me.grpTodayAppointments.Controls.Add(Me.lblRecordsNo)
        Me.grpTodayAppointments.Location = New System.Drawing.Point(8, 5)
        Me.grpTodayAppointments.Name = "grpTodayAppointments"
        Me.grpTodayAppointments.Size = New System.Drawing.Size(775, 42)
        Me.grpTodayAppointments.TabIndex = 0
        Me.grpTodayAppointments.TabStop = False
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(682, 14)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(87, 22)
        Me.fbnExport.TabIndex = 1
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(6, 18)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(228, 13)
        Me.lblRecordsNo.TabIndex = 0
        '
        'btnSendSMS
        '
        Me.btnSendSMS.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendSMS.Location = New System.Drawing.Point(535, 317)
        Me.btnSendSMS.Name = "btnSendSMS"
        Me.btnSendSMS.Size = New System.Drawing.Size(170, 24)
        Me.btnSendSMS.TabIndex = 4
        Me.btnSendSMS.Text = "&Send SMS Reminder "
        Me.btnSendSMS.UseVisualStyleBackColor = False
        '
        'frmTodayAppointments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(793, 349)
        Me.Controls.Add(Me.btnSendSMS)
        Me.Controls.Add(Me.grpTodayAppointments)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvTodayAppointments)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTodayAppointments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Today's Appointments"
        CType(Me.dgvTodayAppointments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpTodayAppointments.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvTodayAppointments As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpTodayAppointments As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnSendSMS As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ColInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAppointmentPrecision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeSpecialty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAppointmentDes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class