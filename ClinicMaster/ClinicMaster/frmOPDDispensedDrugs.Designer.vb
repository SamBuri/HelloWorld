
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOPDDispensedDrugs : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
    End Sub

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
    End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOPDDispensedDrugs))
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.rdoDispensedOPDDrugs = New System.Windows.Forms.RadioButton()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvDispensedOPDDrugs = New System.Windows.Forms.DataGridView()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDispensedOPDDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(145, 43)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpStartDate.TabIndex = 4
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Location = New System.Drawing.Point(494, 43)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(198, 20)
        Me.dtpEndDate.TabIndex = 6
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(782, 343)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(11, 43)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(128, 20)
        Me.lblStartDate.TabIndex = 5
        Me.lblStartDate.Text = "Start Date"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(352, 43)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(136, 20)
        Me.lblEndDate.TabIndex = 7
        Me.lblEndDate.Text = "End Date"
        '
        'rdoDispensedOPDDrugs
        '
        Me.rdoDispensedOPDDrugs.Location = New System.Drawing.Point(244, 12)
        Me.rdoDispensedOPDDrugs.Name = "rdoDispensedOPDDrugs"
        Me.rdoDispensedOPDDrugs.Size = New System.Drawing.Size(212, 20)
        Me.rdoDispensedOPDDrugs.TabIndex = 8
        Me.rdoDispensedOPDDrugs.Text = "Get All Dispensed OPD Drugs"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(698, 38)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(76, 25)
        Me.fbnLoad.TabIndex = 9
        Me.fbnLoad.Text = "Load..."
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(780, 41)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 10
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'dgvDispensedOPDDrugs
        '
        Me.dgvDispensedOPDDrugs.AllowUserToAddRows = False
        Me.dgvDispensedOPDDrugs.AllowUserToDeleteRows = False
        Me.dgvDispensedOPDDrugs.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDispensedOPDDrugs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDispensedOPDDrugs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDispensedOPDDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDispensedOPDDrugs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDispensedOPDDrugs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDispensedOPDDrugs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDispensedOPDDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDispensedOPDDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNo, Me.colVisitDate, Me.colFullName, Me.colItemCode, Me.colItemName, Me.colQuantity, Me.colGender, Me.colAge, Me.colRecordDate, Me.colRecordTime})
        Me.dgvDispensedOPDDrugs.EnableHeadersVisualStyles = False
        Me.dgvDispensedOPDDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvDispensedOPDDrugs.Location = New System.Drawing.Point(5, 85)
        Me.dgvDispensedOPDDrugs.Name = "dgvDispensedOPDDrugs"
        Me.dgvDispensedOPDDrugs.ReadOnly = True
        Me.dgvDispensedOPDDrugs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDispensedOPDDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDispensedOPDDrugs.RowHeadersVisible = False
        Me.dgvDispensedOPDDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDispensedOPDDrugs.Size = New System.Drawing.Size(849, 252)
        Me.dgvDispensedOPDDrugs.TabIndex = 11
        Me.dgvDispensedOPDDrugs.Text = "DataGridView1"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(491, 19)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(178, 13)
        Me.lblRecordsNo.TabIndex = 12
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 80
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 45
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
        'frmOPDDispensedDrugs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(860, 379)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.dgvDispensedOPDDrugs)
        Me.Controls.Add(Me.fbnExport)
        Me.Controls.Add(Me.fbnLoad)
        Me.Controls.Add(Me.rdoDispensedOPDDrugs)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOPDDispensedDrugs"
        Me.Text = "OPD Dispensed Drugs"
        CType(Me.dgvDispensedOPDDrugs,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents rdoDispensedOPDDrugs As System.Windows.Forms.RadioButton
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvDispensedOPDDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class