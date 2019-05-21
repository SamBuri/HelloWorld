<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagnosisReattendances
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnosisReattendances))
        Me.tbcDiagnosisSummaries = New System.Windows.Forms.TabControl()
        Me.tpgReattendances = New System.Windows.Forms.TabPage()
        Me.dgvOPDReattendances = New System.Windows.Forms.DataGridView()
        Me.ColPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBirthPlace = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOccupation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReattnDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOccurances = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPatientStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcDiagnosisSummaries.SuspendLayout()
        Me.tpgReattendances.SuspendLayout()
        CType(Me.dgvOPDReattendances, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcDiagnosisSummaries
        '
        Me.tbcDiagnosisSummaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDiagnosisSummaries.Controls.Add(Me.tpgReattendances)
        Me.tbcDiagnosisSummaries.HotTrack = True
        Me.tbcDiagnosisSummaries.Location = New System.Drawing.Point(4, 114)
        Me.tbcDiagnosisSummaries.Name = "tbcDiagnosisSummaries"
        Me.tbcDiagnosisSummaries.SelectedIndex = 0
        Me.tbcDiagnosisSummaries.Size = New System.Drawing.Size(1014, 348)
        Me.tbcDiagnosisSummaries.TabIndex = 5
        '
        'tpgReattendances
        '
        Me.tpgReattendances.Controls.Add(Me.dgvOPDReattendances)
        Me.tpgReattendances.Location = New System.Drawing.Point(4, 22)
        Me.tpgReattendances.Name = "tpgReattendances"
        Me.tpgReattendances.Size = New System.Drawing.Size(1006, 322)
        Me.tpgReattendances.TabIndex = 6
        Me.tpgReattendances.Text = "OPD Re Attendances"
        Me.tpgReattendances.UseVisualStyleBackColor = True
        '
        'dgvOPDReattendances
        '
        Me.dgvOPDReattendances.AllowUserToAddRows = False
        Me.dgvOPDReattendances.AllowUserToDeleteRows = False
        Me.dgvOPDReattendances.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOPDReattendances.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOPDReattendances.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDReattendances.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDReattendances.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOPDReattendances.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDReattendances.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOPDReattendances.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColPatientNo, Me.ColFullName, Me.ColGender, Me.ColAge, Me.DataGridViewTextBoxColumn3, Me.ColBirthPlace, Me.ColAddress, Me.ColOccupation, Me.ColReattnDiseaseName, Me.ColOccurances, Me.ColPatientStatus})
        Me.dgvOPDReattendances.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOPDReattendances.EnableHeadersVisualStyles = False
        Me.dgvOPDReattendances.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDReattendances.Location = New System.Drawing.Point(0, 0)
        Me.dgvOPDReattendances.Name = "dgvOPDReattendances"
        Me.dgvOPDReattendances.ReadOnly = True
        Me.dgvOPDReattendances.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDReattendances.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOPDReattendances.RowHeadersVisible = False
        Me.dgvOPDReattendances.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOPDReattendances.Size = New System.Drawing.Size(1006, 322)
        Me.dgvOPDReattendances.TabIndex = 3
        Me.dgvOPDReattendances.Text = "DataGridView1"
        '
        'ColPatientNo
        '
        Me.ColPatientNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPatientNo.DataPropertyName = "PatientNo"
        Me.ColPatientNo.HeaderText = "Patient No"
        Me.ColPatientNo.Name = "ColPatientNo"
        Me.ColPatientNo.ReadOnly = True
        '
        'ColFullName
        '
        Me.ColFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColFullName.DataPropertyName = "FullName"
        Me.ColFullName.HeaderText = "Patient Full Name"
        Me.ColFullName.Name = "ColFullName"
        Me.ColFullName.ReadOnly = True
        '
        'ColGender
        '
        Me.ColGender.DataPropertyName = "Gender"
        Me.ColGender.HeaderText = "Gender"
        Me.ColGender.Name = "ColGender"
        Me.ColGender.ReadOnly = True
        '
        'ColAge
        '
        Me.ColAge.DataPropertyName = "Age"
        Me.ColAge.HeaderText = "Age"
        Me.ColAge.Name = "ColAge"
        Me.ColAge.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Phone"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Phone Number"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'ColBirthPlace
        '
        Me.ColBirthPlace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColBirthPlace.DataPropertyName = "BirthPlace"
        Me.ColBirthPlace.HeaderText = "Birth Place"
        Me.ColBirthPlace.Name = "ColBirthPlace"
        Me.ColBirthPlace.ReadOnly = True
        '
        'ColAddress
        '
        Me.ColAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColAddress.DataPropertyName = "Address"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColAddress.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColAddress.HeaderText = "Address"
        Me.ColAddress.Name = "ColAddress"
        Me.ColAddress.ReadOnly = True
        '
        'ColOccupation
        '
        Me.ColOccupation.DataPropertyName = "Occupation"
        Me.ColOccupation.HeaderText = "Occupation"
        Me.ColOccupation.Name = "ColOccupation"
        Me.ColOccupation.ReadOnly = True
        '
        'ColReattnDiseaseName
        '
        Me.ColReattnDiseaseName.DataPropertyName = "DiseaseName"
        Me.ColReattnDiseaseName.HeaderText = "Disease Name"
        Me.ColReattnDiseaseName.Name = "ColReattnDiseaseName"
        Me.ColReattnDiseaseName.ReadOnly = True
        '
        'ColOccurances
        '
        Me.ColOccurances.DataPropertyName = "Occurances"
        Me.ColOccurances.HeaderText = "Occurances"
        Me.ColOccurances.Name = "ColOccurances"
        Me.ColOccurances.ReadOnly = True
        '
        'ColPatientStatus
        '
        Me.ColPatientStatus.DataPropertyName = "PatientStatus"
        Me.ColPatientStatus.HeaderText = "Patient Status"
        Me.ColPatientStatus.Name = "ColPatientStatus"
        Me.ColPatientStatus.ReadOnly = True
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(4, 12)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(1014, 96)
        Me.grpPeriod.TabIndex = 4
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(632, 16)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(257, 13)
        Me.lblRecordsNo.TabIndex = 8
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(682, 64)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(80, 22)
        Me.fbnLoad.TabIndex = 9
        Me.fbnLoad.Text = "Load..."
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Location = New System.Drawing.Point(374, 15)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(226, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(305, 15)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(63, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.Enabled = False
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(768, 64)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(112, 22)
        Me.fbnExportTo.TabIndex = 10
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(76, 15)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(223, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(7, 15)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(92, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(939, 468)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "Close"
        '
        'frmDiagnosisReattendances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 504)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.tbcDiagnosisSummaries)
        Me.Controls.Add(Me.grpPeriod)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDiagnosisReattendances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Diagnosis Reattendances"
        Me.tbcDiagnosisSummaries.ResumeLayout(False)
        Me.tpgReattendances.ResumeLayout(False)
        CType(Me.dgvOPDReattendances, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcDiagnosisSummaries As System.Windows.Forms.TabControl
    Friend WithEvents tpgReattendances As System.Windows.Forms.TabPage
    Friend WithEvents dgvOPDReattendances As System.Windows.Forms.DataGridView
    Friend WithEvents ColPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBirthPlace As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOccupation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReattnDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOccurances As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPatientStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
End Class
