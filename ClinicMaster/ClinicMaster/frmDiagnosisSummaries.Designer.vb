<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiagnosisSummaries : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiagnosisSummaries))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cmsDiagnosisSummaries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.cboSearchAgeByID = New System.Windows.Forms.ComboBox()
        Me.lblSearchAgeBy = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.nbxEndAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxStartAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblEndAge = New System.Windows.Forms.Label()
        Me.lblStartAge = New System.Windows.Forms.Label()
        Me.dgvDiagnosisSummaries = New System.Windows.Forms.DataGridView()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcDiagnosisSummaries = New System.Windows.Forms.TabControl()
        Me.tpgDiagnosisSummaries = New System.Windows.Forms.TabPage()
        Me.tpgDiseaseCategorySummaries = New System.Windows.Forms.TabPage()
        Me.dgvDiseaseCategorySummaries = New System.Windows.Forms.DataGridView()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDCMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDCFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDCTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDDiagnosisSummaries = New System.Windows.Forms.TabPage()
        Me.dgvIPDDiagnosisSummaries = New System.Windows.Forms.DataGridView()
        Me.colIPDDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDDiseaseCategorySummaries = New System.Windows.Forms.TabPage()
        Me.dgvIPDDiseaseCategorySummaries = New System.Windows.Forms.DataGridView()
        Me.ColIPDDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDiseaseMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDiseaseFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDiseaseTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsDiagnosisSummaries.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        CType(Me.dgvDiagnosisSummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDiagnosisSummaries.SuspendLayout()
        Me.tpgDiagnosisSummaries.SuspendLayout()
        Me.tpgDiseaseCategorySummaries.SuspendLayout()
        CType(Me.dgvDiseaseCategorySummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDDiagnosisSummaries.SuspendLayout()
        CType(Me.dgvIPDDiagnosisSummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDDiseaseCategorySummaries.SuspendLayout()
        CType(Me.dgvIPDDiseaseCategorySummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(897, 491)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "Close"
        '
        'cmsDiagnosisSummaries
        '
        Me.cmsDiagnosisSummaries.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDiagnosisSummaries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsCopy, Me.cmsSelectAll})
        Me.cmsDiagnosisSummaries.Name = "cmsSearch"
        Me.cmsDiagnosisSummaries.Size = New System.Drawing.Size(123, 48)
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
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.cboSearchAgeByID)
        Me.grpPeriod.Controls.Add(Me.lblSearchAgeBy)
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.nbxEndAge)
        Me.grpPeriod.Controls.Add(Me.nbxStartAge)
        Me.grpPeriod.Controls.Add(Me.lblEndAge)
        Me.grpPeriod.Controls.Add(Me.lblStartAge)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(12, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(964, 96)
        Me.grpPeriod.TabIndex = 0
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'cboSearchAgeByID
        '
        Me.cboSearchAgeByID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSearchAgeByID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSearchAgeByID.BackColor = System.Drawing.SystemColors.Window
        Me.cboSearchAgeByID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchAgeByID.DropDownWidth = 256
        Me.cboSearchAgeByID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSearchAgeByID.FormattingEnabled = True
        Me.cboSearchAgeByID.ItemHeight = 13
        Me.cboSearchAgeByID.Location = New System.Drawing.Point(76, 38)
        Me.cboSearchAgeByID.Name = "cboSearchAgeByID"
        Me.cboSearchAgeByID.Size = New System.Drawing.Size(223, 21)
        Me.cboSearchAgeByID.TabIndex = 12
        '
        'lblSearchAgeBy
        '
        Me.lblSearchAgeBy.Location = New System.Drawing.Point(9, 41)
        Me.lblSearchAgeBy.Name = "lblSearchAgeBy"
        Me.lblSearchAgeBy.Size = New System.Drawing.Size(61, 20)
        Me.lblSearchAgeBy.TabIndex = 11
        Me.lblSearchAgeBy.Text = "Search By"
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
        'nbxEndAge
        '
        Me.nbxEndAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxEndAge.ControlCaption = "End Age"
        Me.nbxEndAge.DecimalPlaces = -1
        Me.nbxEndAge.Location = New System.Drawing.Point(635, 38)
        Me.nbxEndAge.MaxLength = 3
        Me.nbxEndAge.MaxValue = 200.0R
        Me.nbxEndAge.MinValue = 0.0R
        Me.nbxEndAge.MustEnterNumeric = True
        Me.nbxEndAge.Name = "nbxEndAge"
        Me.nbxEndAge.Size = New System.Drawing.Size(135, 20)
        Me.nbxEndAge.TabIndex = 7
        Me.nbxEndAge.Value = ""
        Me.nbxEndAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'nbxStartAge
        '
        Me.nbxStartAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxStartAge.ControlCaption = "Start Age"
        Me.nbxStartAge.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxStartAge.DecimalPlaces = -1
        Me.nbxStartAge.Location = New System.Drawing.Point(374, 39)
        Me.nbxStartAge.MaxLength = 3
        Me.nbxStartAge.MaxValue = 200.0R
        Me.nbxStartAge.MinValue = 0.0R
        Me.nbxStartAge.MustEnterNumeric = True
        Me.nbxStartAge.Name = "nbxStartAge"
        Me.nbxStartAge.Size = New System.Drawing.Size(165, 20)
        Me.nbxStartAge.TabIndex = 5
        Me.nbxStartAge.Value = ""
        Me.nbxStartAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'lblEndAge
        '
        Me.lblEndAge.Location = New System.Drawing.Point(550, 41)
        Me.lblEndAge.Name = "lblEndAge"
        Me.lblEndAge.Size = New System.Drawing.Size(65, 20)
        Me.lblEndAge.TabIndex = 6
        Me.lblEndAge.Text = "End Age"
        '
        'lblStartAge
        '
        Me.lblStartAge.Location = New System.Drawing.Point(305, 41)
        Me.lblStartAge.Name = "lblStartAge"
        Me.lblStartAge.Size = New System.Drawing.Size(63, 20)
        Me.lblStartAge.TabIndex = 4
        Me.lblStartAge.Text = "Start Age"
        '
        'dgvDiagnosisSummaries
        '
        Me.dgvDiagnosisSummaries.AllowUserToAddRows = False
        Me.dgvDiagnosisSummaries.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDiagnosisSummaries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnosisSummaries.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDiagnosisSummaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDiagnosisSummaries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDiagnosisSummaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosisSummaries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDiagnosisSummaries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseName, Me.colMale, Me.colFemale, Me.colTotal})
        Me.dgvDiagnosisSummaries.ContextMenuStrip = Me.cmsDiagnosisSummaries
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiagnosisSummaries.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDiagnosisSummaries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosisSummaries.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosisSummaries.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosisSummaries.Name = "dgvDiagnosisSummaries"
        Me.dgvDiagnosisSummaries.ReadOnly = True
        Me.dgvDiagnosisSummaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosisSummaries.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDiagnosisSummaries.RowHeadersVisible = False
        Me.dgvDiagnosisSummaries.Size = New System.Drawing.Size(972, 341)
        Me.dgvDiagnosisSummaries.TabIndex = 1
        Me.dgvDiagnosisSummaries.Tag = "DiagnosisSummaries"
        Me.dgvDiagnosisSummaries.Text = "DataGridView1"
        '
        'colDiseaseName
        '
        Me.colDiseaseName.DataPropertyName = "DiseaseName"
        Me.colDiseaseName.HeaderText = "Diagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        Me.colDiseaseName.Width = 480
        '
        'colMale
        '
        Me.colMale.DataPropertyName = "Male"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colMale.DefaultCellStyle = DataGridViewCellStyle3
        Me.colMale.HeaderText = "Male"
        Me.colMale.Name = "colMale"
        Me.colMale.ReadOnly = True
        '
        'colFemale
        '
        Me.colFemale.DataPropertyName = "Female"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colFemale.DefaultCellStyle = DataGridViewCellStyle4
        Me.colFemale.HeaderText = "Female"
        Me.colFemale.Name = "colFemale"
        Me.colFemale.ReadOnly = True
        '
        'colTotal
        '
        Me.colTotal.DataPropertyName = "Total"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTotal.HeaderText = "Total"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        '
        'tbcDiagnosisSummaries
        '
        Me.tbcDiagnosisSummaries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDiagnosisSummaries.Controls.Add(Me.tpgDiagnosisSummaries)
        Me.tbcDiagnosisSummaries.Controls.Add(Me.tpgDiseaseCategorySummaries)
        Me.tbcDiagnosisSummaries.Controls.Add(Me.tpgIPDDiagnosisSummaries)
        Me.tbcDiagnosisSummaries.Controls.Add(Me.tpgIPDDiseaseCategorySummaries)
        Me.tbcDiagnosisSummaries.HotTrack = True
        Me.tbcDiagnosisSummaries.Location = New System.Drawing.Point(12, 107)
        Me.tbcDiagnosisSummaries.Name = "tbcDiagnosisSummaries"
        Me.tbcDiagnosisSummaries.SelectedIndex = 0
        Me.tbcDiagnosisSummaries.Size = New System.Drawing.Size(980, 367)
        Me.tbcDiagnosisSummaries.TabIndex = 3
        '
        'tpgDiagnosisSummaries
        '
        Me.tpgDiagnosisSummaries.Controls.Add(Me.dgvDiagnosisSummaries)
        Me.tpgDiagnosisSummaries.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosisSummaries.Name = "tpgDiagnosisSummaries"
        Me.tpgDiagnosisSummaries.Size = New System.Drawing.Size(972, 341)
        Me.tpgDiagnosisSummaries.TabIndex = 3
        Me.tpgDiagnosisSummaries.Tag = ""
        Me.tpgDiagnosisSummaries.Text = "Diagnosis Summaries"
        Me.tpgDiagnosisSummaries.UseVisualStyleBackColor = True
        '
        'tpgDiseaseCategorySummaries
        '
        Me.tpgDiseaseCategorySummaries.Controls.Add(Me.dgvDiseaseCategorySummaries)
        Me.tpgDiseaseCategorySummaries.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiseaseCategorySummaries.Name = "tpgDiseaseCategorySummaries"
        Me.tpgDiseaseCategorySummaries.Size = New System.Drawing.Size(972, 341)
        Me.tpgDiseaseCategorySummaries.TabIndex = 2
        Me.tpgDiseaseCategorySummaries.Tag = ""
        Me.tpgDiseaseCategorySummaries.Text = "Disease Category Summaries"
        Me.tpgDiseaseCategorySummaries.UseVisualStyleBackColor = True
        '
        'dgvDiseaseCategorySummaries
        '
        Me.dgvDiseaseCategorySummaries.AllowUserToAddRows = False
        Me.dgvDiseaseCategorySummaries.AllowUserToDeleteRows = False
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDiseaseCategorySummaries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDiseaseCategorySummaries.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDiseaseCategorySummaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDiseaseCategorySummaries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDiseaseCategorySummaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiseaseCategorySummaries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDiseaseCategorySummaries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseCategory, Me.colDCMale, Me.colDCFemale, Me.colDCTotal})
        Me.dgvDiseaseCategorySummaries.ContextMenuStrip = Me.cmsDiagnosisSummaries
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiseaseCategorySummaries.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgvDiseaseCategorySummaries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiseaseCategorySummaries.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiseaseCategorySummaries.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiseaseCategorySummaries.Name = "dgvDiseaseCategorySummaries"
        Me.dgvDiseaseCategorySummaries.ReadOnly = True
        Me.dgvDiseaseCategorySummaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiseaseCategorySummaries.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvDiseaseCategorySummaries.RowHeadersVisible = False
        Me.dgvDiseaseCategorySummaries.Size = New System.Drawing.Size(972, 341)
        Me.dgvDiseaseCategorySummaries.TabIndex = 21
        Me.dgvDiseaseCategorySummaries.Tag = "DiseaseCategorySummaries"
        Me.dgvDiseaseCategorySummaries.Text = "DataGridView1"
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.DataPropertyName = "DiseaseCategory"
        Me.colDiseaseCategory.HeaderText = "Disease Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 480
        '
        'colDCMale
        '
        Me.colDCMale.DataPropertyName = "Male"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colDCMale.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDCMale.HeaderText = "Male"
        Me.colDCMale.Name = "colDCMale"
        Me.colDCMale.ReadOnly = True
        '
        'colDCFemale
        '
        Me.colDCFemale.DataPropertyName = "Female"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colDCFemale.DefaultCellStyle = DataGridViewCellStyle11
        Me.colDCFemale.HeaderText = "Female"
        Me.colDCFemale.Name = "colDCFemale"
        Me.colDCFemale.ReadOnly = True
        '
        'colDCTotal
        '
        Me.colDCTotal.DataPropertyName = "Total"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colDCTotal.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDCTotal.HeaderText = "Total"
        Me.colDCTotal.Name = "colDCTotal"
        Me.colDCTotal.ReadOnly = True
        '
        'tpgIPDDiagnosisSummaries
        '
        Me.tpgIPDDiagnosisSummaries.Controls.Add(Me.dgvIPDDiagnosisSummaries)
        Me.tpgIPDDiagnosisSummaries.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDDiagnosisSummaries.Name = "tpgIPDDiagnosisSummaries"
        Me.tpgIPDDiagnosisSummaries.Size = New System.Drawing.Size(972, 341)
        Me.tpgIPDDiagnosisSummaries.TabIndex = 4
        Me.tpgIPDDiagnosisSummaries.Text = "IPD Diagnosis Summaries"
        Me.tpgIPDDiagnosisSummaries.UseVisualStyleBackColor = True
        '
        'dgvIPDDiagnosisSummaries
        '
        Me.dgvIPDDiagnosisSummaries.AllowUserToAddRows = False
        Me.dgvIPDDiagnosisSummaries.AllowUserToDeleteRows = False
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDDiagnosisSummaries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvIPDDiagnosisSummaries.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDDiagnosisSummaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPDDiagnosisSummaries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDDiagnosisSummaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDDiagnosisSummaries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvIPDDiagnosisSummaries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIPDDiseaseName, Me.ColIPDMale, Me.ColIPDFemale, Me.ColIPDTotal})
        Me.dgvIPDDiagnosisSummaries.ContextMenuStrip = Me.cmsDiagnosisSummaries
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDDiagnosisSummaries.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgvIPDDiagnosisSummaries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDDiagnosisSummaries.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDDiagnosisSummaries.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDDiagnosisSummaries.Name = "dgvIPDDiagnosisSummaries"
        Me.dgvIPDDiagnosisSummaries.ReadOnly = True
        Me.dgvIPDDiagnosisSummaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDDiagnosisSummaries.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvIPDDiagnosisSummaries.RowHeadersVisible = False
        Me.dgvIPDDiagnosisSummaries.Size = New System.Drawing.Size(972, 341)
        Me.dgvIPDDiagnosisSummaries.TabIndex = 2
        Me.dgvIPDDiagnosisSummaries.Tag = "DiagnosisSummaries"
        Me.dgvIPDDiagnosisSummaries.Text = "DataGridView1"
        '
        'colIPDDiseaseName
        '
        Me.colIPDDiseaseName.DataPropertyName = "DiseaseName"
        Me.colIPDDiseaseName.HeaderText = "Diagnosis"
        Me.colIPDDiseaseName.Name = "colIPDDiseaseName"
        Me.colIPDDiseaseName.ReadOnly = True
        Me.colIPDDiseaseName.Width = 480
        '
        'ColIPDMale
        '
        Me.ColIPDMale.DataPropertyName = "Male"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDMale.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColIPDMale.HeaderText = "Male"
        Me.ColIPDMale.Name = "ColIPDMale"
        Me.ColIPDMale.ReadOnly = True
        '
        'ColIPDFemale
        '
        Me.ColIPDFemale.DataPropertyName = "Female"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDFemale.DefaultCellStyle = DataGridViewCellStyle18
        Me.ColIPDFemale.HeaderText = "Female"
        Me.ColIPDFemale.Name = "ColIPDFemale"
        Me.ColIPDFemale.ReadOnly = True
        '
        'ColIPDTotal
        '
        Me.ColIPDTotal.DataPropertyName = "Total"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDTotal.DefaultCellStyle = DataGridViewCellStyle19
        Me.ColIPDTotal.HeaderText = "Total"
        Me.ColIPDTotal.Name = "ColIPDTotal"
        Me.ColIPDTotal.ReadOnly = True
        '
        'tpgIPDDiseaseCategorySummaries
        '
        Me.tpgIPDDiseaseCategorySummaries.Controls.Add(Me.dgvIPDDiseaseCategorySummaries)
        Me.tpgIPDDiseaseCategorySummaries.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDDiseaseCategorySummaries.Name = "tpgIPDDiseaseCategorySummaries"
        Me.tpgIPDDiseaseCategorySummaries.Size = New System.Drawing.Size(972, 341)
        Me.tpgIPDDiseaseCategorySummaries.TabIndex = 5
        Me.tpgIPDDiseaseCategorySummaries.Text = "IPD Disease Category Summaries"
        Me.tpgIPDDiseaseCategorySummaries.UseVisualStyleBackColor = True
        '
        'dgvIPDDiseaseCategorySummaries
        '
        Me.dgvIPDDiseaseCategorySummaries.AllowUserToAddRows = False
        Me.dgvIPDDiseaseCategorySummaries.AllowUserToDeleteRows = False
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDDiseaseCategorySummaries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvIPDDiseaseCategorySummaries.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDDiseaseCategorySummaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPDDiseaseCategorySummaries.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDDiseaseCategorySummaries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDDiseaseCategorySummaries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvIPDDiseaseCategorySummaries.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDDiseaseCategory, Me.ColIPDDiseaseMale, Me.ColIPDDiseaseFemale, Me.ColIPDDiseaseTotal})
        Me.dgvIPDDiseaseCategorySummaries.ContextMenuStrip = Me.cmsDiagnosisSummaries
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDDiseaseCategorySummaries.DefaultCellStyle = DataGridViewCellStyle27
        Me.dgvIPDDiseaseCategorySummaries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDDiseaseCategorySummaries.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDDiseaseCategorySummaries.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDDiseaseCategorySummaries.Name = "dgvIPDDiseaseCategorySummaries"
        Me.dgvIPDDiseaseCategorySummaries.ReadOnly = True
        Me.dgvIPDDiseaseCategorySummaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDDiseaseCategorySummaries.RowHeadersDefaultCellStyle = DataGridViewCellStyle28
        Me.dgvIPDDiseaseCategorySummaries.RowHeadersVisible = False
        Me.dgvIPDDiseaseCategorySummaries.Size = New System.Drawing.Size(972, 341)
        Me.dgvIPDDiseaseCategorySummaries.TabIndex = 22
        Me.dgvIPDDiseaseCategorySummaries.Tag = "DiseaseCategorySummaries"
        Me.dgvIPDDiseaseCategorySummaries.Text = "DataGridView1"
        '
        'ColIPDDiseaseCategory
        '
        Me.ColIPDDiseaseCategory.DataPropertyName = "DiseaseCategory"
        Me.ColIPDDiseaseCategory.HeaderText = "Disease Category"
        Me.ColIPDDiseaseCategory.Name = "ColIPDDiseaseCategory"
        Me.ColIPDDiseaseCategory.ReadOnly = True
        Me.ColIPDDiseaseCategory.Width = 480
        '
        'ColIPDDiseaseMale
        '
        Me.ColIPDDiseaseMale.DataPropertyName = "Male"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDDiseaseMale.DefaultCellStyle = DataGridViewCellStyle24
        Me.ColIPDDiseaseMale.HeaderText = "Male"
        Me.ColIPDDiseaseMale.Name = "ColIPDDiseaseMale"
        Me.ColIPDDiseaseMale.ReadOnly = True
        '
        'ColIPDDiseaseFemale
        '
        Me.ColIPDDiseaseFemale.DataPropertyName = "Female"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDDiseaseFemale.DefaultCellStyle = DataGridViewCellStyle25
        Me.ColIPDDiseaseFemale.HeaderText = "Female"
        Me.ColIPDDiseaseFemale.Name = "ColIPDDiseaseFemale"
        Me.ColIPDDiseaseFemale.ReadOnly = True
        '
        'ColIPDDiseaseTotal
        '
        Me.ColIPDDiseaseTotal.DataPropertyName = "Total"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDDiseaseTotal.DefaultCellStyle = DataGridViewCellStyle26
        Me.ColIPDDiseaseTotal.HeaderText = "Total"
        Me.ColIPDDiseaseTotal.Name = "ColIPDDiseaseTotal"
        Me.ColIPDDiseaseTotal.ReadOnly = True
        '
        'frmDiagnosisSummaries
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(992, 527)
        Me.Controls.Add(Me.tbcDiagnosisSummaries)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmDiagnosisSummaries"
        Me.Text = "Diagnosis Summaries"
        Me.cmsDiagnosisSummaries.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        CType(Me.dgvDiagnosisSummaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDiagnosisSummaries.ResumeLayout(False)
        Me.tpgDiagnosisSummaries.ResumeLayout(False)
        Me.tpgDiseaseCategorySummaries.ResumeLayout(False)
        CType(Me.dgvDiseaseCategorySummaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDDiagnosisSummaries.ResumeLayout(False)
        CType(Me.dgvIPDDiagnosisSummaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDDiseaseCategorySummaries.ResumeLayout(False)
        CType(Me.dgvIPDDiseaseCategorySummaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents cmsDiagnosisSummaries As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvDiagnosisSummaries As System.Windows.Forms.DataGridView
    Friend WithEvents lblStartAge As System.Windows.Forms.Label
    Friend WithEvents lblEndAge As System.Windows.Forms.Label
    Friend WithEvents colDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nbxEndAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxStartAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents tbcDiagnosisSummaries As System.Windows.Forms.TabControl
    Friend WithEvents tpgDiagnosisSummaries As System.Windows.Forms.TabPage
    Friend WithEvents tpgDiseaseCategorySummaries As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiseaseCategorySummaries As System.Windows.Forms.DataGridView
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDCMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDCFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDCTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpgIPDDiagnosisSummaries As System.Windows.Forms.TabPage
    Friend WithEvents dgvIPDDiagnosisSummaries As System.Windows.Forms.DataGridView
    Friend WithEvents tpgIPDDiseaseCategorySummaries As System.Windows.Forms.TabPage
    Friend WithEvents colIPDDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvIPDDiseaseCategorySummaries As System.Windows.Forms.DataGridView
    Friend WithEvents ColIPDDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDiseaseMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDiseaseFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDiseaseTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboSearchAgeByID As ComboBox
    Friend WithEvents lblSearchAgeBy As Label
End Class
