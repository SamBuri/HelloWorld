<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabReport
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabReport))
        Me.tbcLabTestsReport = New System.Windows.Forms.TabControl()
        Me.tpgTestsDone = New System.Windows.Forms.TabPage()
        Me.dgvTestsDone = New System.Windows.Forms.DataGridView()
        Me.colTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestsDoneMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestsDoneFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestsDoneTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgtestsext = New System.Windows.Forms.TabPage()
        Me.dgvTestsEXT = New System.Windows.Forms.DataGridView()
        Me.ColItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNoOfPatients = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPending = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProcessing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgTestResults = New System.Windows.Forms.TabPage()
        Me.dgvTestResults = New System.Windows.Forms.DataGridView()
        Me.colTestResultTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestResultTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestResultsTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboSearchAgeByID = New System.Windows.Forms.ComboBox()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSearchAgeBy = New System.Windows.Forms.Label()
        Me.nbxEndAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxStartAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblEndAge = New System.Windows.Forms.Label()
        Me.lblStartAge = New System.Windows.Forms.Label()
        Me.fbClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tpglabResultsEXt = New System.Windows.Forms.TabPage()
        Me.dgvTestResultsEXT = New System.Windows.Forms.DataGridView()
        Me.ColTestResultsEXTTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsEXTTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsEXTResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsEXTMale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsEXTFemale = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestResultsOccurances = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcLabTestsReport.SuspendLayout()
        Me.tpgTestsDone.SuspendLayout()
        CType(Me.dgvTestsDone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgtestsext.SuspendLayout()
        CType(Me.dgvTestsEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgTestResults.SuspendLayout()
        CType(Me.dgvTestResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.tpglabResultsEXt.SuspendLayout()
        CType(Me.dgvTestResultsEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcLabTestsReport
        '
        Me.tbcLabTestsReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLabTestsReport.Controls.Add(Me.tpgTestsDone)
        Me.tbcLabTestsReport.Controls.Add(Me.tpgtestsext)
        Me.tbcLabTestsReport.Controls.Add(Me.tpgTestResults)
        Me.tbcLabTestsReport.Controls.Add(Me.tpglabResultsEXt)
        Me.tbcLabTestsReport.HotTrack = True
        Me.tbcLabTestsReport.Location = New System.Drawing.Point(12, 101)
        Me.tbcLabTestsReport.Name = "tbcLabTestsReport"
        Me.tbcLabTestsReport.SelectedIndex = 0
        Me.tbcLabTestsReport.Size = New System.Drawing.Size(946, 372)
        Me.tbcLabTestsReport.TabIndex = 7
        '
        'tpgTestsDone
        '
        Me.tpgTestsDone.Controls.Add(Me.dgvTestsDone)
        Me.tpgTestsDone.Location = New System.Drawing.Point(4, 22)
        Me.tpgTestsDone.Name = "tpgTestsDone"
        Me.tpgTestsDone.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTestsDone.Size = New System.Drawing.Size(938, 346)
        Me.tpgTestsDone.TabIndex = 12
        Me.tpgTestsDone.Text = "Tests Done"
        Me.tpgTestsDone.UseVisualStyleBackColor = True
        '
        'dgvTestsDone
        '
        Me.dgvTestsDone.AllowUserToAddRows = False
        Me.dgvTestsDone.AllowUserToDeleteRows = False
        Me.dgvTestsDone.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTestsDone.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTestsDone.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTestsDone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTestsDone.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTestsDone.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestsDone.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTestsDone.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTestCode, Me.colTestName, Me.ColTestsDoneMale, Me.ColTestsDoneFemale, Me.colTestsDoneTotal})
        Me.dgvTestsDone.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTestsDone.EnableHeadersVisualStyles = False
        Me.dgvTestsDone.GridColor = System.Drawing.Color.Khaki
        Me.dgvTestsDone.Location = New System.Drawing.Point(3, 3)
        Me.dgvTestsDone.Name = "dgvTestsDone"
        Me.dgvTestsDone.ReadOnly = True
        Me.dgvTestsDone.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestsDone.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTestsDone.RowHeadersVisible = False
        Me.dgvTestsDone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTestsDone.Size = New System.Drawing.Size(932, 340)
        Me.dgvTestsDone.TabIndex = 2
        Me.dgvTestsDone.Text = "DataGridView1"
        '
        'colTestCode
        '
        Me.colTestCode.DataPropertyName = "TestCode"
        Me.colTestCode.HeaderText = "Test Code"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.ReadOnly = True
        '
        'colTestName
        '
        Me.colTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTestName.DataPropertyName = "TestName"
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        '
        'ColTestsDoneMale
        '
        Me.ColTestsDoneMale.DataPropertyName = "Male"
        Me.ColTestsDoneMale.HeaderText = "Male"
        Me.ColTestsDoneMale.Name = "ColTestsDoneMale"
        Me.ColTestsDoneMale.ReadOnly = True
        '
        'ColTestsDoneFemale
        '
        Me.ColTestsDoneFemale.DataPropertyName = "Female"
        Me.ColTestsDoneFemale.HeaderText = "Female"
        Me.ColTestsDoneFemale.Name = "ColTestsDoneFemale"
        Me.ColTestsDoneFemale.ReadOnly = True
        '
        'colTestsDoneTotal
        '
        Me.colTestsDoneTotal.DataPropertyName = "Total"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTestsDoneTotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTestsDoneTotal.HeaderText = "Total"
        Me.colTestsDoneTotal.Name = "colTestsDoneTotal"
        Me.colTestsDoneTotal.ReadOnly = True
        Me.colTestsDoneTotal.Width = 120
        '
        'tpgtestsext
        '
        Me.tpgtestsext.Controls.Add(Me.dgvTestsEXT)
        Me.tpgtestsext.Location = New System.Drawing.Point(4, 22)
        Me.tpgtestsext.Name = "tpgtestsext"
        Me.tpgtestsext.Size = New System.Drawing.Size(938, 346)
        Me.tpgtestsext.TabIndex = 11
        Me.tpgtestsext.Text = "Test Details"
        Me.tpgtestsext.UseVisualStyleBackColor = True
        '
        'dgvTestsEXT
        '
        Me.dgvTestsEXT.AllowUserToAddRows = False
        Me.dgvTestsEXT.AllowUserToDeleteRows = False
        Me.dgvTestsEXT.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTestsEXT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTestsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTestsEXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTestsEXT.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTestsEXT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTestsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColItemName, Me.ColNoOfPatients, Me.ColDone, Me.ColPending, Me.ColProcessing})
        Me.dgvTestsEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTestsEXT.EnableHeadersVisualStyles = False
        Me.dgvTestsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvTestsEXT.Location = New System.Drawing.Point(0, 0)
        Me.dgvTestsEXT.Name = "dgvTestsEXT"
        Me.dgvTestsEXT.ReadOnly = True
        Me.dgvTestsEXT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvTestsEXT.RowHeadersVisible = False
        Me.dgvTestsEXT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTestsEXT.Size = New System.Drawing.Size(938, 346)
        Me.dgvTestsEXT.TabIndex = 1
        Me.dgvTestsEXT.Text = "DataGridView1"
        '
        'ColItemName
        '
        Me.ColItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColItemName.DataPropertyName = "ItemName"
        Me.ColItemName.HeaderText = "Test Name"
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.ReadOnly = True
        '
        'ColNoOfPatients
        '
        Me.ColNoOfPatients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColNoOfPatients.DataPropertyName = "NoOfPatients"
        Me.ColNoOfPatients.HeaderText = "No Of Patients"
        Me.ColNoOfPatients.Name = "ColNoOfPatients"
        Me.ColNoOfPatients.ReadOnly = True
        '
        'ColDone
        '
        Me.ColDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColDone.DataPropertyName = "Offered"
        Me.ColDone.HeaderText = "Done"
        Me.ColDone.Name = "ColDone"
        Me.ColDone.ReadOnly = True
        '
        'ColPending
        '
        Me.ColPending.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColPending.DataPropertyName = "Pending"
        Me.ColPending.HeaderText = "Pending"
        Me.ColPending.Name = "ColPending"
        Me.ColPending.ReadOnly = True
        '
        'ColProcessing
        '
        Me.ColProcessing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColProcessing.DataPropertyName = "Processing"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColProcessing.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColProcessing.HeaderText = "Processing"
        Me.ColProcessing.Name = "ColProcessing"
        Me.ColProcessing.ReadOnly = True
        '
        'tpgTestResults
        '
        Me.tpgTestResults.Controls.Add(Me.dgvTestResults)
        Me.tpgTestResults.Location = New System.Drawing.Point(4, 22)
        Me.tpgTestResults.Name = "tpgTestResults"
        Me.tpgTestResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTestResults.Size = New System.Drawing.Size(938, 346)
        Me.tpgTestResults.TabIndex = 13
        Me.tpgTestResults.Text = "Test Results"
        Me.tpgTestResults.UseVisualStyleBackColor = True
        '
        'dgvTestResults
        '
        Me.dgvTestResults.AllowUserToAddRows = False
        Me.dgvTestResults.AllowUserToDeleteRows = False
        Me.dgvTestResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTestResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvTestResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTestResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTestResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTestResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvTestResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTestResultTestCode, Me.colTestResultTestName, Me.ColResult, Me.ColTestResultsMale, Me.ColTestResultsFemale, Me.colTestResultsTotal})
        Me.dgvTestResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTestResults.EnableHeadersVisualStyles = False
        Me.dgvTestResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvTestResults.Location = New System.Drawing.Point(3, 3)
        Me.dgvTestResults.Name = "dgvTestResults"
        Me.dgvTestResults.ReadOnly = True
        Me.dgvTestResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTestResults.RowHeadersVisible = False
        Me.dgvTestResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTestResults.Size = New System.Drawing.Size(932, 340)
        Me.dgvTestResults.TabIndex = 3
        Me.dgvTestResults.Text = "DataGridView2"
        '
        'colTestResultTestCode
        '
        Me.colTestResultTestCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTestResultTestCode.DataPropertyName = "TestCode"
        Me.colTestResultTestCode.HeaderText = "Test Code"
        Me.colTestResultTestCode.Name = "colTestResultTestCode"
        Me.colTestResultTestCode.ReadOnly = True
        '
        'colTestResultTestName
        '
        Me.colTestResultTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTestResultTestName.DataPropertyName = "TestName"
        Me.colTestResultTestName.HeaderText = "Test Name"
        Me.colTestResultTestName.Name = "colTestResultTestName"
        Me.colTestResultTestName.ReadOnly = True
        '
        'ColResult
        '
        Me.ColResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColResult.DataPropertyName = "Result"
        Me.ColResult.HeaderText = "Result"
        Me.ColResult.Name = "ColResult"
        Me.ColResult.ReadOnly = True
        '
        'ColTestResultsMale
        '
        Me.ColTestResultsMale.HeaderText = "Male"
        Me.ColTestResultsMale.Name = "ColTestResultsMale"
        Me.ColTestResultsMale.ReadOnly = True
        '
        'ColTestResultsFemale
        '
        Me.ColTestResultsFemale.HeaderText = "Female"
        Me.ColTestResultsFemale.Name = "ColTestResultsFemale"
        Me.ColTestResultsFemale.ReadOnly = True
        '
        'colTestResultsTotal
        '
        Me.colTestResultsTotal.DataPropertyName = "Occurances"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colTestResultsTotal.DefaultCellStyle = DataGridViewCellStyle11
        Me.colTestResultsTotal.HeaderText = "Total"
        Me.colTestResultsTotal.Name = "colTestResultsTotal"
        Me.colTestResultsTotal.ReadOnly = True
        Me.colTestResultsTotal.Width = 120
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Location = New System.Drawing.Point(5, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(953, 91)
        Me.grpSetParameters.TabIndex = 6
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Collection Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.lblRecordsNo)
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.fbnLoad)
        Me.pnlPeriod.Controls.Add(Me.cboSearchAgeByID)
        Me.pnlPeriod.Controls.Add(Me.fbnExport)
        Me.pnlPeriod.Controls.Add(Me.lblSearchAgeBy)
        Me.pnlPeriod.Controls.Add(Me.nbxEndAge)
        Me.pnlPeriod.Controls.Add(Me.nbxStartAge)
        Me.pnlPeriod.Controls.Add(Me.lblEndAge)
        Me.pnlPeriod.Controls.Add(Me.lblStartAge)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 15)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(942, 66)
        Me.pnlPeriod.TabIndex = 0
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(653, 10)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(267, 15)
        Me.lblRecordsNo.TabIndex = 23
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Location = New System.Drawing.Point(417, 9)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(226, 20)
        Me.dtpEndDate.TabIndex = 22
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(348, 9)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(63, 20)
        Me.lblEndDate.TabIndex = 21
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(119, 9)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(223, 20)
        Me.dtpStartDate.TabIndex = 20
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(50, 9)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(92, 20)
        Me.lblStartDate.TabIndex = 19
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(779, 31)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 6
        Me.fbnLoad.Text = "&Load"
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
        Me.cboSearchAgeByID.Location = New System.Drawing.Point(119, 32)
        Me.cboSearchAgeByID.Name = "cboSearchAgeByID"
        Me.cboSearchAgeByID.Size = New System.Drawing.Size(189, 21)
        Me.cboSearchAgeByID.TabIndex = 18
        '
        'fbnExport
        '
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(862, 31)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblSearchAgeBy
        '
        Me.lblSearchAgeBy.Location = New System.Drawing.Point(52, 31)
        Me.lblSearchAgeBy.Name = "lblSearchAgeBy"
        Me.lblSearchAgeBy.Size = New System.Drawing.Size(61, 20)
        Me.lblSearchAgeBy.TabIndex = 17
        Me.lblSearchAgeBy.Text = "Search By"
        '
        'nbxEndAge
        '
        Me.nbxEndAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxEndAge.ControlCaption = "End Age"
        Me.nbxEndAge.DecimalPlaces = -1
        Me.nbxEndAge.Location = New System.Drawing.Point(631, 32)
        Me.nbxEndAge.MaxLength = 3
        Me.nbxEndAge.MaxValue = 200.0R
        Me.nbxEndAge.MinValue = 0.0R
        Me.nbxEndAge.MustEnterNumeric = True
        Me.nbxEndAge.Name = "nbxEndAge"
        Me.nbxEndAge.Size = New System.Drawing.Size(135, 20)
        Me.nbxEndAge.TabIndex = 16
        Me.nbxEndAge.Value = ""
        Me.nbxEndAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'nbxStartAge
        '
        Me.nbxStartAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxStartAge.ControlCaption = "Start Age"
        Me.nbxStartAge.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxStartAge.DecimalPlaces = -1
        Me.nbxStartAge.Location = New System.Drawing.Point(417, 33)
        Me.nbxStartAge.MaxLength = 3
        Me.nbxStartAge.MaxValue = 200.0R
        Me.nbxStartAge.MinValue = 0.0R
        Me.nbxStartAge.MustEnterNumeric = True
        Me.nbxStartAge.Name = "nbxStartAge"
        Me.nbxStartAge.Size = New System.Drawing.Size(137, 20)
        Me.nbxStartAge.TabIndex = 14
        Me.nbxStartAge.Value = ""
        Me.nbxStartAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'lblEndAge
        '
        Me.lblEndAge.Location = New System.Drawing.Point(560, 35)
        Me.lblEndAge.Name = "lblEndAge"
        Me.lblEndAge.Size = New System.Drawing.Size(65, 20)
        Me.lblEndAge.TabIndex = 15
        Me.lblEndAge.Text = "End Age"
        '
        'lblStartAge
        '
        Me.lblStartAge.Location = New System.Drawing.Point(348, 33)
        Me.lblStartAge.Name = "lblStartAge"
        Me.lblStartAge.Size = New System.Drawing.Size(63, 20)
        Me.lblStartAge.TabIndex = 13
        Me.lblStartAge.Text = "Start Age"
        '
        'fbClose
        '
        Me.fbClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbClose.Location = New System.Drawing.Point(876, 482)
        Me.fbClose.Name = "fbClose"
        Me.fbClose.Size = New System.Drawing.Size(74, 22)
        Me.fbClose.TabIndex = 8
        Me.fbClose.Text = "&Close"
        Me.fbClose.UseVisualStyleBackColor = False
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(779, 31)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(74, 22)
        Me.fbnExportTo.TabIndex = 6
        Me.fbnExportTo.Text = "&Load"
        '
        'tpglabResultsEXt
        '
        Me.tpglabResultsEXt.Controls.Add(Me.dgvTestResultsEXT)
        Me.tpglabResultsEXt.Location = New System.Drawing.Point(4, 22)
        Me.tpglabResultsEXt.Name = "tpglabResultsEXt"
        Me.tpglabResultsEXt.Size = New System.Drawing.Size(938, 346)
        Me.tpglabResultsEXt.TabIndex = 14
        Me.tpglabResultsEXt.Text = "Test Results EXT"
        Me.tpglabResultsEXt.UseVisualStyleBackColor = True
        '
        'dgvTestResultsEXT
        '
        Me.dgvTestResultsEXT.AllowUserToAddRows = False
        Me.dgvTestResultsEXT.AllowUserToDeleteRows = False
        Me.dgvTestResultsEXT.AllowUserToOrderColumns = True
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTestResultsEXT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvTestResultsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTestResultsEXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTestResultsEXT.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTestResultsEXT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestResultsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvTestResultsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTestResultsEXTTestCode, Me.ColTestResultsEXTTestName, Me.ColTestResultsEXTResult, Me.ColTestResultsEXTMale, Me.ColTestResultsEXTFemale, Me.ColTestResultsOccurances})
        Me.dgvTestResultsEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTestResultsEXT.EnableHeadersVisualStyles = False
        Me.dgvTestResultsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvTestResultsEXT.Location = New System.Drawing.Point(0, 0)
        Me.dgvTestResultsEXT.Name = "dgvTestResultsEXT"
        Me.dgvTestResultsEXT.ReadOnly = True
        Me.dgvTestResultsEXT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTestResultsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvTestResultsEXT.RowHeadersVisible = False
        Me.dgvTestResultsEXT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTestResultsEXT.Size = New System.Drawing.Size(938, 346)
        Me.dgvTestResultsEXT.TabIndex = 4
        Me.dgvTestResultsEXT.Text = "DataGridView2"
        '
        'ColTestResultsEXTTestCode
        '
        Me.ColTestResultsEXTTestCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTestResultsEXTTestCode.DataPropertyName = "TestCode"
        Me.ColTestResultsEXTTestCode.HeaderText = "Test Code"
        Me.ColTestResultsEXTTestCode.Name = "ColTestResultsEXTTestCode"
        Me.ColTestResultsEXTTestCode.ReadOnly = True
        '
        'ColTestResultsEXTTestName
        '
        Me.ColTestResultsEXTTestName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTestResultsEXTTestName.DataPropertyName = "TestName"
        Me.ColTestResultsEXTTestName.HeaderText = "Test Name"
        Me.ColTestResultsEXTTestName.Name = "ColTestResultsEXTTestName"
        Me.ColTestResultsEXTTestName.ReadOnly = True
        '
        'ColTestResultsEXTResult
        '
        Me.ColTestResultsEXTResult.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColTestResultsEXTResult.DataPropertyName = "Result"
        Me.ColTestResultsEXTResult.HeaderText = "Result"
        Me.ColTestResultsEXTResult.Name = "ColTestResultsEXTResult"
        Me.ColTestResultsEXTResult.ReadOnly = True
        '
        'ColTestResultsEXTMale
        '
        Me.ColTestResultsEXTMale.DataPropertyName = "Male"
        Me.ColTestResultsEXTMale.HeaderText = "Male"
        Me.ColTestResultsEXTMale.Name = "ColTestResultsEXTMale"
        Me.ColTestResultsEXTMale.ReadOnly = True
        '
        'ColTestResultsEXTFemale
        '
        Me.ColTestResultsEXTFemale.DataPropertyName = "Female"
        Me.ColTestResultsEXTFemale.HeaderText = "Female"
        Me.ColTestResultsEXTFemale.Name = "ColTestResultsEXTFemale"
        Me.ColTestResultsEXTFemale.ReadOnly = True
        '
        'ColTestResultsOccurances
        '
        Me.ColTestResultsOccurances.DataPropertyName = "Occurances"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColTestResultsOccurances.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColTestResultsOccurances.HeaderText = "Total"
        Me.ColTestResultsOccurances.Name = "ColTestResultsOccurances"
        Me.ColTestResultsOccurances.ReadOnly = True
        Me.ColTestResultsOccurances.Width = 120
        '
        'frmLabReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 513)
        Me.Controls.Add(Me.fbClose)
        Me.Controls.Add(Me.tbcLabTestsReport)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLabReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Report"
        Me.tbcLabTestsReport.ResumeLayout(False)
        Me.tpgTestsDone.ResumeLayout(False)
        CType(Me.dgvTestsDone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgtestsext.ResumeLayout(False)
        CType(Me.dgvTestsEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgTestResults.ResumeLayout(False)
        CType(Me.dgvTestResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.tpglabResultsEXt.ResumeLayout(False)
        CType(Me.dgvTestResultsEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcLabTestsReport As System.Windows.Forms.TabControl
    Friend WithEvents tpgTestsDone As System.Windows.Forms.TabPage
    Friend WithEvents tpgtestsext As System.Windows.Forms.TabPage
    Friend WithEvents dgvTestsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents tpgTestResults As System.Windows.Forms.TabPage
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dgvTestsDone As System.Windows.Forms.DataGridView
    Friend WithEvents dgvTestResults As System.Windows.Forms.DataGridView
    Friend WithEvents fbClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboSearchAgeByID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSearchAgeBy As System.Windows.Forms.Label
    Friend WithEvents nbxEndAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxStartAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblEndAge As System.Windows.Forms.Label
    Friend WithEvents lblStartAge As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestsDoneMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestsDoneFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestsDoneTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestResultTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestResultTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestResultsTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents ColItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNoOfPatients As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPending As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProcessing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpglabResultsEXt As System.Windows.Forms.TabPage
    Friend WithEvents dgvTestResultsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents ColTestResultsEXTTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsEXTTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsEXTResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsEXTMale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsEXTFemale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestResultsOccurances As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
