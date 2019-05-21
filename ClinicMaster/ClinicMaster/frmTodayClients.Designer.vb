<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTodayClients : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTodayClients))
        Me.grpTodayAppointments = New System.Windows.Forms.GroupBox()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvTodayClients = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeSpecialty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAppointmentDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpTodayAppointments.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvTodayClients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpTodayAppointments
        '
        Me.grpTodayAppointments.Controls.Add(Me.fbnLoad)
        Me.grpTodayAppointments.Controls.Add(Me.pnlPeriod)
        Me.grpTodayAppointments.Controls.Add(Me.fbnExport)
        Me.grpTodayAppointments.Controls.Add(Me.lblRecordsNo)
        Me.grpTodayAppointments.Location = New System.Drawing.Point(12, 4)
        Me.grpTodayAppointments.Name = "grpTodayAppointments"
        Me.grpTodayAppointments.Size = New System.Drawing.Size(842, 49)
        Me.grpTodayAppointments.TabIndex = 4
        Me.grpTodayAppointments.TabStop = False
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(539, 13)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(87, 28)
        Me.fbnLoad.TabIndex = 9
        Me.fbnLoad.Text = "Load..."
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(6, 12)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(527, 31)
        Me.pnlPeriod.TabIndex = 8
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd MMM yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(345, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(163, 20)
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
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(103, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(157, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(266, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(89, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(633, 14)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(87, 28)
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
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(268, 334)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvTodayClients
        '
        Me.dgvTodayClients.AllowUserToAddRows = False
        Me.dgvTodayClients.AllowUserToDeleteRows = False
        Me.dgvTodayClients.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTodayClients.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTodayClients.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTodayClients.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTodayClients.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTodayClients.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTodayClients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTodayClients.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTodayClients.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReferenceNo, Me.colFirstName, Me.ColLastName, Me.ColOtherName, Me.colGender, Me.colPhone, Me.ColAge, Me.colToSeeSpecialty, Me.colToSeeDoctor, Me.colAppointmentDes})
        Me.dgvTodayClients.EnableHeadersVisualStyles = False
        Me.dgvTodayClients.GridColor = System.Drawing.Color.Khaki
        Me.dgvTodayClients.Location = New System.Drawing.Point(6, 53)
        Me.dgvTodayClients.Name = "dgvTodayClients"
        Me.dgvTodayClients.ReadOnly = True
        Me.dgvTodayClients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTodayClients.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTodayClients.RowHeadersVisible = False
        Me.dgvTodayClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTodayClients.Size = New System.Drawing.Size(848, 275)
        Me.dgvTodayClients.TabIndex = 5
        Me.dgvTodayClients.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(779, 334)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'colReferenceNo
        '
        Me.colReferenceNo.DataPropertyName = "ReferenceNo"
        Me.colReferenceNo.HeaderText = "Ref No"
        Me.colReferenceNo.Name = "colReferenceNo"
        Me.colReferenceNo.ReadOnly = True
        Me.colReferenceNo.Width = 75
        '
        'colFirstName
        '
        Me.colFirstName.DataPropertyName = "FirstName"
        Me.colFirstName.HeaderText = "First Name"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        '
        'ColLastName
        '
        Me.ColLastName.DataPropertyName = "LastName"
        Me.ColLastName.HeaderText = "Last Name"
        Me.ColLastName.Name = "ColLastName"
        Me.ColLastName.ReadOnly = True
        '
        'ColOtherName
        '
        Me.ColOtherName.DataPropertyName = "MiddleName"
        Me.ColOtherName.HeaderText = "Other Name"
        Me.ColOtherName.Name = "ColOtherName"
        Me.ColOtherName.ReadOnly = True
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 65
        '
        'colPhone
        '
        Me.colPhone.DataPropertyName = "PhoneNo"
        Me.colPhone.HeaderText = "Phone Number"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        '
        'ColAge
        '
        Me.ColAge.DataPropertyName = "Age"
        Me.ColAge.HeaderText = "Age"
        Me.ColAge.Name = "ColAge"
        Me.ColAge.ReadOnly = True
        '
        'colToSeeSpecialty
        '
        Me.colToSeeSpecialty.DataPropertyName = "DoctorSpecialtyID"
        Me.colToSeeSpecialty.HeaderText = "To-See Specialty"
        Me.colToSeeSpecialty.Name = "colToSeeSpecialty"
        Me.colToSeeSpecialty.ReadOnly = True
        '
        'colToSeeDoctor
        '
        Me.colToSeeDoctor.DataPropertyName = "StaffFullName"
        Me.colToSeeDoctor.HeaderText = "To-See Doctor"
        Me.colToSeeDoctor.Name = "colToSeeDoctor"
        Me.colToSeeDoctor.ReadOnly = True
        '
        'colAppointmentDes
        '
        Me.colAppointmentDes.DataPropertyName = "Description"
        Me.colAppointmentDes.HeaderText = "Description"
        Me.colAppointmentDes.Name = "colAppointmentDes"
        Me.colAppointmentDes.ReadOnly = True
        '
        'frmTodayClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 363)
        Me.Controls.Add(Me.grpTodayAppointments)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvTodayClients)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmTodayClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clients"
        Me.grpTodayAppointments.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvTodayClients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpTodayAppointments As System.Windows.Forms.GroupBox
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvTodayClients As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeSpecialty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAppointmentDes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
