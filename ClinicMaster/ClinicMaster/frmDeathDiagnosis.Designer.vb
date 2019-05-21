<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeathDiagnosis
    Inherits System.Windows.Forms.Form
    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal patientNo As String)
        MyClass.New()
        Me._patientNo = patientNo
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeathDiagnosis))
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.chkShowAll = New System.Windows.Forms.CheckBox()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.tbcDeathDiagnosis = New System.Windows.Forms.TabControl()
        Me.tpgGeneralDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvGeneralDiagnosis = New System.Windows.Forms.DataGridView()
        Me.cmsDeathDiagnosis = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgCancerDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvCancerDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colCancerFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerMiddleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancervisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerDiseaseCategoriesID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerDiseaseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerDoctorSpecialty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCancerNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMiddleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategoriesID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DoctorSpeciality = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpPeriod.SuspendLayout()
        Me.tbcDeathDiagnosis.SuspendLayout()
        Me.tpgGeneralDiagnosis.SuspendLayout()
        CType(Me.dgvGeneralDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDeathDiagnosis.SuspendLayout()
        Me.tpgCancerDiagnosis.SuspendLayout()
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.chkShowAll)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(12, 12)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(909, 46)
        Me.grpPeriod.TabIndex = 4
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'chkShowAll
        '
        Me.chkShowAll.AutoSize = True
        Me.chkShowAll.Location = New System.Drawing.Point(16, 20)
        Me.chkShowAll.Name = "chkShowAll"
        Me.chkShowAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkShowAll.Size = New System.Drawing.Size(67, 17)
        Me.chkShowAll.TabIndex = 6
        Me.chkShowAll.Text = "Show All"
        Me.chkShowAll.UseVisualStyleBackColor = True
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(669, 15)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(116, 22)
        Me.fbnLoad.TabIndex = 0
        Me.fbnLoad.Text = "Load..."
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Location = New System.Drawing.Point(458, 16)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(398, 16)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(56, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(797, 14)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 4
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(197, 17)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(129, 16)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(63, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbcDeathDiagnosis
        '
        Me.tbcDeathDiagnosis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDeathDiagnosis.Controls.Add(Me.tpgGeneralDiagnosis)
        Me.tbcDeathDiagnosis.Controls.Add(Me.tpgCancerDiagnosis)
        Me.tbcDeathDiagnosis.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcDeathDiagnosis.HotTrack = True
        Me.tbcDeathDiagnosis.Location = New System.Drawing.Point(12, 64)
        Me.tbcDeathDiagnosis.Name = "tbcDeathDiagnosis"
        Me.tbcDeathDiagnosis.SelectedIndex = 0
        Me.tbcDeathDiagnosis.Size = New System.Drawing.Size(913, 373)
        Me.tbcDeathDiagnosis.TabIndex = 5
        '
        'tpgGeneralDiagnosis
        '
        Me.tpgGeneralDiagnosis.Controls.Add(Me.dgvGeneralDiagnosis)
        Me.tpgGeneralDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgGeneralDiagnosis.Name = "tpgGeneralDiagnosis"
        Me.tpgGeneralDiagnosis.Size = New System.Drawing.Size(905, 347)
        Me.tpgGeneralDiagnosis.TabIndex = 2
        Me.tpgGeneralDiagnosis.Tag = ""
        Me.tpgGeneralDiagnosis.Text = "General Diagnosis"
        Me.tpgGeneralDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvGeneralDiagnosis
        '
        Me.dgvGeneralDiagnosis.AllowUserToAddRows = False
        Me.dgvGeneralDiagnosis.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvGeneralDiagnosis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGeneralDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvGeneralDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvGeneralDiagnosis.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvGeneralDiagnosis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGeneralDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGeneralDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFirstName, Me.colLastName, Me.colMiddleName, Me.colVisitNo, Me.colvisitdate, Me.colDiseaseCategoriesID, Me.colDiseaseCategory, Me.colDiseaseCode, Me.colDiseaseName, Me.DoctorSpeciality, Me.colNotes})
        Me.dgvGeneralDiagnosis.ContextMenuStrip = Me.cmsDeathDiagnosis
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGeneralDiagnosis.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGeneralDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGeneralDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvGeneralDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvGeneralDiagnosis.Name = "dgvGeneralDiagnosis"
        Me.dgvGeneralDiagnosis.ReadOnly = True
        Me.dgvGeneralDiagnosis.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGeneralDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvGeneralDiagnosis.RowHeadersVisible = False
        Me.dgvGeneralDiagnosis.Size = New System.Drawing.Size(905, 347)
        Me.dgvGeneralDiagnosis.TabIndex = 21
        Me.dgvGeneralDiagnosis.Text = "DataGridView1"
        '
        'cmsDeathDiagnosis
        '
        Me.cmsDeathDiagnosis.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDeathDiagnosis.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsCopy, Me.cmsSelectAll})
        Me.cmsDeathDiagnosis.Name = "cmsSearch"
        Me.cmsDeathDiagnosis.Size = New System.Drawing.Size(123, 48)
        '
        'cmsCopy
        '
        Me.cmsCopy.Enabled = False
        Me.cmsCopy.Name = "cmsCopy"
        Me.cmsCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsCopy.Text = "Copy"
        Me.cmsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsSelectAll
        '
        Me.cmsSelectAll.Enabled = False
        Me.cmsSelectAll.Name = "cmsSelectAll"
        Me.cmsSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsSelectAll.Text = "Select All"
        '
        'tpgCancerDiagnosis
        '
        Me.tpgCancerDiagnosis.Controls.Add(Me.dgvCancerDiagnosis)
        Me.tpgCancerDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgCancerDiagnosis.Name = "tpgCancerDiagnosis"
        Me.tpgCancerDiagnosis.Size = New System.Drawing.Size(905, 347)
        Me.tpgCancerDiagnosis.TabIndex = 5
        Me.tpgCancerDiagnosis.Tag = ""
        Me.tpgCancerDiagnosis.Text = "Cancer Diagnosis"
        Me.tpgCancerDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvCancerDiagnosis
        '
        Me.dgvCancerDiagnosis.AllowUserToAddRows = False
        Me.dgvCancerDiagnosis.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvCancerDiagnosis.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCancerDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvCancerDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCancerDiagnosis.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCancerDiagnosis.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCancerDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCancerFirstName, Me.colCancerLastName, Me.colCancerMiddleName, Me.colCancerVisitNo, Me.colCancervisitdate, Me.colCancerDiseaseCategoriesID, Me.colCancerDiseaseCategory, Me.colCancerDiseaseCode, Me.colCancerDiseaseName, Me.colCancerDoctorSpecialty, Me.colCancerNotes})
        Me.dgvCancerDiagnosis.ContextMenuStrip = Me.cmsDeathDiagnosis
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCancerDiagnosis.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvCancerDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCancerDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvCancerDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvCancerDiagnosis.Name = "dgvCancerDiagnosis"
        Me.dgvCancerDiagnosis.ReadOnly = True
        Me.dgvCancerDiagnosis.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCancerDiagnosis.RowHeadersVisible = False
        Me.dgvCancerDiagnosis.Size = New System.Drawing.Size(905, 347)
        Me.dgvCancerDiagnosis.TabIndex = 23
        Me.dgvCancerDiagnosis.Text = "DataGridView1"
        '
        'colCancerFirstName
        '
        Me.colCancerFirstName.HeaderText = "First Name"
        Me.colCancerFirstName.Name = "colCancerFirstName"
        Me.colCancerFirstName.ReadOnly = True
        '
        'colCancerLastName
        '
        Me.colCancerLastName.HeaderText = "Last Name"
        Me.colCancerLastName.Name = "colCancerLastName"
        Me.colCancerLastName.ReadOnly = True
        '
        'colCancerMiddleName
        '
        Me.colCancerMiddleName.HeaderText = "Other Name"
        Me.colCancerMiddleName.Name = "colCancerMiddleName"
        Me.colCancerMiddleName.ReadOnly = True
        '
        'colCancerVisitNo
        '
        Me.colCancerVisitNo.HeaderText = "Visit No"
        Me.colCancerVisitNo.Name = "colCancerVisitNo"
        Me.colCancerVisitNo.ReadOnly = True
        '
        'colCancervisitdate
        '
        Me.colCancervisitdate.HeaderText = "Visit Date"
        Me.colCancervisitdate.Name = "colCancervisitdate"
        Me.colCancervisitdate.ReadOnly = True
        '
        'colCancerDiseaseCategoriesID
        '
        Me.colCancerDiseaseCategoriesID.HeaderText = "Disease Category ID"
        Me.colCancerDiseaseCategoriesID.Name = "colCancerDiseaseCategoriesID"
        Me.colCancerDiseaseCategoriesID.ReadOnly = True
        '
        'colCancerDiseaseCategory
        '
        Me.colCancerDiseaseCategory.HeaderText = "Disease Category"
        Me.colCancerDiseaseCategory.Name = "colCancerDiseaseCategory"
        Me.colCancerDiseaseCategory.ReadOnly = True
        '
        'colCancerDiseaseCode
        '
        Me.colCancerDiseaseCode.HeaderText = "Disease Code"
        Me.colCancerDiseaseCode.Name = "colCancerDiseaseCode"
        Me.colCancerDiseaseCode.ReadOnly = True
        '
        'colCancerDiseaseName
        '
        Me.colCancerDiseaseName.HeaderText = "Disease Name"
        Me.colCancerDiseaseName.Name = "colCancerDiseaseName"
        Me.colCancerDiseaseName.ReadOnly = True
        '
        'colCancerDoctorSpecialty
        '
        Me.colCancerDoctorSpecialty.HeaderText = "Doctor Specialty"
        Me.colCancerDoctorSpecialty.Name = "colCancerDoctorSpecialty"
        Me.colCancerDoctorSpecialty.ReadOnly = True
        '
        'colCancerNotes
        '
        Me.colCancerNotes.HeaderText = "Notes"
        Me.colCancerNotes.Name = "colCancerNotes"
        Me.colCancerNotes.ReadOnly = True
        '
        'colFirstName
        '
        Me.colFirstName.HeaderText = "First Name"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        '
        'colLastName
        '
        Me.colLastName.HeaderText = "Last Name"
        Me.colLastName.Name = "colLastName"
        Me.colLastName.ReadOnly = True
        '
        'colMiddleName
        '
        Me.colMiddleName.HeaderText = "Other Name"
        Me.colMiddleName.Name = "colMiddleName"
        Me.colMiddleName.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colvisitdate
        '
        Me.colvisitdate.HeaderText = "Visit Date"
        Me.colvisitdate.Name = "colvisitdate"
        Me.colvisitdate.ReadOnly = True
        '
        'colDiseaseCategoriesID
        '
        Me.colDiseaseCategoriesID.HeaderText = "Disease Categories ID"
        Me.colDiseaseCategoriesID.Name = "colDiseaseCategoriesID"
        Me.colDiseaseCategoriesID.ReadOnly = True
        Me.colDiseaseCategoriesID.Width = 150
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.HeaderText = "Disease Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        '
        'colDiseaseCode
        '
        Me.colDiseaseCode.HeaderText = "Disease Code"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.ReadOnly = True
        '
        'colDiseaseName
        '
        Me.colDiseaseName.HeaderText = "Disease Name"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        '
        'DoctorSpeciality
        '
        Me.DoctorSpeciality.HeaderText = "Doctor Speciality"
        Me.DoctorSpeciality.Name = "DoctorSpeciality"
        Me.DoctorSpeciality.ReadOnly = True
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        '
        'frmDeathDiagnosis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(937, 451)
        Me.Controls.Add(Me.tbcDeathDiagnosis)
        Me.Controls.Add(Me.grpPeriod)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDeathDiagnosis"
        Me.Text = "Diagnosis"
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        Me.tbcDeathDiagnosis.ResumeLayout(False)
        Me.tpgGeneralDiagnosis.ResumeLayout(False)
        CType(Me.dgvGeneralDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDeathDiagnosis.ResumeLayout(False)
        Me.tpgCancerDiagnosis.ResumeLayout(False)
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents tbcDeathDiagnosis As System.Windows.Forms.TabControl
    Friend WithEvents tpgGeneralDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvGeneralDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents tpgCancerDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvCancerDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colCancerFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerLastName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerMiddleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancervisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerDiseaseCategoriesID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerDiseaseCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerDoctorSpecialty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCancerNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsDeathDiagnosis As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkShowAll As System.Windows.Forms.CheckBox
    Friend WithEvents colFirstName As DataGridViewTextBoxColumn
    Friend WithEvents colLastName As DataGridViewTextBoxColumn
    Friend WithEvents colMiddleName As DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As DataGridViewTextBoxColumn
    Friend WithEvents colvisitdate As DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategoriesID As DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCode As DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseName As DataGridViewTextBoxColumn
    Friend WithEvents DoctorSpeciality As DataGridViewTextBoxColumn
    Friend WithEvents colNotes As DataGridViewTextBoxColumn
End Class
