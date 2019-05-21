<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingAllLabResults : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingAllLabResults))
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.fbnCall = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvPendingLabResults = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTokenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSpecimenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPatientAdmissionStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrawnDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpPeriod.SuspendLayout()
        CType(Me.dgvPendingLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.grpPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.grpPeriod.Controls.Add(Me.fbnCall)
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(8, 12)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(892, 46)
        Me.grpPeriod.TabIndex = 7
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Visit Period"
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(73, 17)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(203, 20)
        Me.dtpStartDateTime.TabIndex = 10
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(378, 16)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 9
        '
        'fbnCall
        '
        Me.fbnCall.Enabled = False
        Me.fbnCall.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCall.Location = New System.Drawing.Point(697, 16)
        Me.fbnCall.Name = "fbnCall"
        Me.fbnCall.Size = New System.Drawing.Size(75, 22)
        Me.fbnCall.TabIndex = 8
        Me.fbnCall.Text = "Enqueue"
        Me.fbnCall.Visible = False
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(727, 11)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(159, 13)
        Me.lblRecordsNo.TabIndex = 6
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(295, 16)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(77, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(620, 15)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(71, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(7, 17)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(60, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(218, 323)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvPendingLabResults
        '
        Me.dgvPendingLabResults.AllowUserToAddRows = False
        Me.dgvPendingLabResults.AllowUserToDeleteRows = False
        Me.dgvPendingLabResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPendingLabResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingLabResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPendingLabResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingLabResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingLabResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPendingLabResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingLabResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingLabResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFirstName, Me.colTokenNo, Me.colVisitNo, Me.colSpecimenNo, Me.colPatientNo, Me.ColPatientAdmissionStatus, Me.colTestName, Me.colVisitDate, Me.colFullName, Me.colGender, Me.colAge, Me.colDrawnDateTime})
        Me.dgvPendingLabResults.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPendingLabResults.EnableHeadersVisualStyles = False
        Me.dgvPendingLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingLabResults.Location = New System.Drawing.Point(9, 64)
        Me.dgvPendingLabResults.Name = "dgvPendingLabResults"
        Me.dgvPendingLabResults.ReadOnly = True
        Me.dgvPendingLabResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingLabResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPendingLabResults.RowHeadersVisible = False
        Me.dgvPendingLabResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPendingLabResults.Size = New System.Drawing.Size(894, 244)
        Me.dgvPendingLabResults.TabIndex = 4
        Me.dgvPendingLabResults.Text = "DataGridView1"
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
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(828, 323)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
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
        Me.colTokenNo.HeaderText = "TokenNo"
        Me.colTokenNo.Name = "colTokenNo"
        Me.colTokenNo.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No / Round No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 120
        '
        'colSpecimenNo
        '
        Me.colSpecimenNo.DataPropertyName = "SpecimenNo"
        Me.colSpecimenNo.HeaderText = "Specimen No"
        Me.colSpecimenNo.Name = "colSpecimenNo"
        Me.colSpecimenNo.ReadOnly = True
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'ColPatientAdmissionStatus
        '
        Me.ColPatientAdmissionStatus.DataPropertyName = "PatientAdmissionStatus"
        Me.ColPatientAdmissionStatus.HeaderText = "Patient Status"
        Me.ColPatientAdmissionStatus.Name = "ColPatientAdmissionStatus"
        Me.ColPatientAdmissionStatus.ReadOnly = True
        Me.ColPatientAdmissionStatus.Width = 120
        '
        'colTestName
        '
        Me.colTestName.DataPropertyName = "TestName"
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        Me.colTestName.Width = 150
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
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
        'colDrawnDateTime
        '
        Me.colDrawnDateTime.DataPropertyName = "DrawnDateTime"
        Me.colDrawnDateTime.HeaderText = "Drawn Date & Time"
        Me.colDrawnDateTime.Name = "colDrawnDateTime"
        Me.colDrawnDateTime.ReadOnly = True
        Me.colDrawnDateTime.Width = 120
        '
        'frmPendingAllLabResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 354)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPendingLabResults)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPendingAllLabResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending LabResults"
        Me.grpPeriod.ResumeLayout(False)
        CType(Me.dgvPendingLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents fbnCall As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvPendingLabResults As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTokenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecimenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPatientAdmissionStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrawnDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
