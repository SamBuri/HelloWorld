<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDLabResults
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDLabResults))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpTestDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboLabTechnologist = New System.Windows.Forms.ComboBox()
        Me.cboResult = New System.Windows.Forms.ComboBox()
        Me.stbUnitMeasure = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboResultFlagID = New System.Windows.Forms.ComboBox()
        Me.cboEntryModeID = New System.Windows.Forms.ComboBox()
        Me.stbNormalRange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboTestCode = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSpecimenDes = New System.Windows.Forms.Label()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.lblTestCode = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.lblTestDateTime = New System.Windows.Forms.Label()
        Me.pnlSpecimenNo = New System.Windows.Forms.Panel()
        Me.btnFindSpecimenNo = New System.Windows.Forms.Button()
        Me.lblNormalRange = New System.Windows.Forms.Label()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.stbDrawnDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrawnDateTime = New System.Windows.Forms.Label()
        Me.lblLabTechnologist = New System.Windows.Forms.Label()
        Me.dgvLabResultsEXT = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSubTestCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNormalRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultFlagID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colResultDataTypeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpLabResultsEXT = New System.Windows.Forms.GroupBox()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnLoadList = New System.Windows.Forms.Button()
        Me.lblPendingResults = New System.Windows.Forms.Label()
        Me.btnViewTemplates = New System.Windows.Forms.Button()
        Me.lblResultFlagID = New System.Windows.Forms.Label()
        Me.lblEntryModeID = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.btnImportLabResults = New System.Windows.Forms.Button()
        Me.clbSpecimenDescription = New System.Windows.Forms.CheckedListBox()
        Me.pnlSpecimenNo.SuspendLayout
        CType(Me.dgvLabResultsEXT,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpLabResultsEXT.SuspendLayout
        Me.pnlAlerts.SuspendLayout
        Me.SuspendLayout
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(12, 543)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 47
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(716, 539)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 48
        Me.btnDelete.Tag = "LabResults"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 572)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 49
        Me.ebnSaveUpdate.Tag = "LabResults"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbReport
        '
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReport, "Report")
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(452, 97)
        Me.stbReport.MaxLength = 2000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.RegularExpression = ""
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(168, 32)
        Me.stbReport.TabIndex = 28
        '
        'dtpTestDateTime
        '
        Me.dtpTestDateTime.Checked = False
        Me.dtpTestDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTestDateTime, "TestDateTime")
        Me.dtpTestDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTestDateTime.Location = New System.Drawing.Point(140, 141)
        Me.dtpTestDateTime.Name = "dtpTestDateTime"
        Me.dtpTestDateTime.ShowCheckBox = True
        Me.dtpTestDateTime.Size = New System.Drawing.Size(171, 20)
        Me.dtpTestDateTime.TabIndex = 8
        '
        'cboLabTechnologist
        '
        Me.cboLabTechnologist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLabTechnologist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboLabTechnologist, "LabTechnologistFullName")
        Me.cboLabTechnologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabTechnologist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLabTechnologist.FormattingEnabled = True
        Me.cboLabTechnologist.Location = New System.Drawing.Point(452, 131)
        Me.cboLabTechnologist.Name = "cboLabTechnologist"
        Me.cboLabTechnologist.Size = New System.Drawing.Size(168, 21)
        Me.cboLabTechnologist.TabIndex = 30
        '
        'cboResult
        '
        Me.cboResult.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboResult.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboResult, "Result")
        Me.cboResult.DropDownWidth = 400
        Me.cboResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResult.FormattingEnabled = True
        Me.cboResult.Location = New System.Drawing.Point(452, 28)
        Me.cboResult.MaxLength = 200
        Me.cboResult.Name = "cboResult"
        Me.cboResult.Size = New System.Drawing.Size(168, 21)
        Me.cboResult.TabIndex = 22
        '
        'stbUnitMeasure
        '
        Me.stbUnitMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitMeasure.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbUnitMeasure, "UnitMeasure")
        Me.stbUnitMeasure.Enabled = False
        Me.stbUnitMeasure.EntryErrorMSG = ""
        Me.stbUnitMeasure.Location = New System.Drawing.Point(452, 74)
        Me.stbUnitMeasure.MaxLength = 100
        Me.stbUnitMeasure.Name = "stbUnitMeasure"
        Me.stbUnitMeasure.RegularExpression = ""
        Me.stbUnitMeasure.Size = New System.Drawing.Size(168, 20)
        Me.stbUnitMeasure.TabIndex = 26
        '
        'cboResultFlagID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboResultFlagID, "ResultFlag,ResultFlagID")
        Me.cboResultFlagID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboResultFlagID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboResultFlagID.Location = New System.Drawing.Point(452, 51)
        Me.cboResultFlagID.Name = "cboResultFlagID"
        Me.cboResultFlagID.Size = New System.Drawing.Size(168, 21)
        Me.cboResultFlagID.TabIndex = 24
        '
        'cboEntryModeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEntryModeID, "EntryMode,EntryModeID")
        Me.cboEntryModeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntryModeID.Enabled = False
        Me.cboEntryModeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEntryModeID.Location = New System.Drawing.Point(452, 154)
        Me.cboEntryModeID.Name = "cboEntryModeID"
        Me.cboEntryModeID.Size = New System.Drawing.Size(168, 21)
        Me.cboEntryModeID.TabIndex = 32
        '
        'stbNormalRange
        '
        Me.stbNormalRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNormalRange.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNormalRange, "NormalRange")
        Me.stbNormalRange.EntryErrorMSG = ""
        Me.stbNormalRange.Location = New System.Drawing.Point(452, 6)
        Me.stbNormalRange.MaxLength = 800
        Me.stbNormalRange.Name = "stbNormalRange"
        Me.stbNormalRange.RegularExpression = ""
        Me.stbNormalRange.Size = New System.Drawing.Size(168, 20)
        Me.stbNormalRange.TabIndex = 20
        '
        'cboTestCode
        '
        Me.cboTestCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTestCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTestCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTestCode.DropDownWidth = 214
        Me.cboTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTestCode.FormattingEnabled = True
        Me.cboTestCode.Location = New System.Drawing.Point(140, 117)
        Me.cboTestCode.Name = "cboTestCode"
        Me.cboTestCode.Size = New System.Drawing.Size(171, 21)
        Me.cboTestCode.Sorted = True
        Me.cboTestCode.TabIndex = 6
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(716, 569)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 50
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblSpecimenDes
        '
        Me.lblSpecimenDes.Location = New System.Drawing.Point(12, 57)
        Me.lblSpecimenDes.Name = "lblSpecimenDes"
        Me.lblSpecimenDes.Size = New System.Drawing.Size(120, 20)
        Me.lblSpecimenDes.TabIndex = 1
        Me.lblSpecimenDes.Text = "Specimen Description"
        '
        'stbSpecimenNo
        '
        Me.stbSpecimenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpecimenNo.CapitalizeFirstLetter = False
        Me.stbSpecimenNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSpecimenNo.EntryErrorMSG = ""
        Me.stbSpecimenNo.Location = New System.Drawing.Point(133, 5)
        Me.stbSpecimenNo.MaxLength = 20
        Me.stbSpecimenNo.Name = "stbSpecimenNo"
        Me.stbSpecimenNo.RegularExpression = ""
        Me.stbSpecimenNo.Size = New System.Drawing.Size(168, 20)
        Me.stbSpecimenNo.TabIndex = 2
        '
        'lblSpecimenNo
        '
        Me.lblSpecimenNo.Location = New System.Drawing.Point(5, 5)
        Me.lblSpecimenNo.Name = "lblSpecimenNo"
        Me.lblSpecimenNo.Size = New System.Drawing.Size(89, 20)
        Me.lblSpecimenNo.TabIndex = 0
        Me.lblSpecimenNo.Text = "Specimen No."
        '
        'lblTestCode
        '
        Me.lblTestCode.Location = New System.Drawing.Point(12, 117)
        Me.lblTestCode.Name = "lblTestCode"
        Me.lblTestCode.Size = New System.Drawing.Size(120, 20)
        Me.lblTestCode.TabIndex = 5
        Me.lblTestCode.Text = "Lab Test"
        '
        'lblResult
        '
        Me.lblResult.Location = New System.Drawing.Point(317, 31)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(129, 20)
        Me.lblResult.TabIndex = 21
        Me.lblResult.Text = "Result"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(317, 106)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(129, 20)
        Me.lblReport.TabIndex = 27
        Me.lblReport.Text = "Report"
        '
        'lblTestDateTime
        '
        Me.lblTestDateTime.Location = New System.Drawing.Point(12, 141)
        Me.lblTestDateTime.Name = "lblTestDateTime"
        Me.lblTestDateTime.Size = New System.Drawing.Size(120, 20)
        Me.lblTestDateTime.TabIndex = 7
        Me.lblTestDateTime.Text = "Test Date and Time"
        '
        'pnlSpecimenNo
        '
        Me.pnlSpecimenNo.Controls.Add(Me.btnFindSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.stbSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.lblSpecimenNo)
        Me.pnlSpecimenNo.Location = New System.Drawing.Point(7, 10)
        Me.pnlSpecimenNo.Name = "pnlSpecimenNo"
        Me.pnlSpecimenNo.Size = New System.Drawing.Size(304, 31)
        Me.pnlSpecimenNo.TabIndex = 0
        '
        'btnFindSpecimenNo
        '
        Me.btnFindSpecimenNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindSpecimenNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindSpecimenNo.Image = CType(resources.GetObject("btnFindSpecimenNo.Image"), System.Drawing.Image)
        Me.btnFindSpecimenNo.Location = New System.Drawing.Point(101, 5)
        Me.btnFindSpecimenNo.Name = "btnFindSpecimenNo"
        Me.btnFindSpecimenNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindSpecimenNo.TabIndex = 1
        '
        'lblNormalRange
        '
        Me.lblNormalRange.Location = New System.Drawing.Point(317, 6)
        Me.lblNormalRange.Name = "lblNormalRange"
        Me.lblNormalRange.Size = New System.Drawing.Size(129, 20)
        Me.lblNormalRange.TabIndex = 19
        Me.lblNormalRange.Text = "Normal Range"
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.Location = New System.Drawing.Point(317, 76)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(129, 20)
        Me.lblUnitMeasure.TabIndex = 25
        Me.lblUnitMeasure.Text = "Unit of Measure"
        '
        'stbDrawnDateTime
        '
        Me.stbDrawnDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrawnDateTime.CapitalizeFirstLetter = False
        Me.stbDrawnDateTime.Enabled = False
        Me.stbDrawnDateTime.EntryErrorMSG = ""
        Me.stbDrawnDateTime.Location = New System.Drawing.Point(140, 94)
        Me.stbDrawnDateTime.MaxLength = 60
        Me.stbDrawnDateTime.Name = "stbDrawnDateTime"
        Me.stbDrawnDateTime.RegularExpression = ""
        Me.stbDrawnDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDrawnDateTime.Size = New System.Drawing.Size(171, 20)
        Me.stbDrawnDateTime.TabIndex = 4
        '
        'lblDrawnDateTime
        '
        Me.lblDrawnDateTime.Location = New System.Drawing.Point(12, 92)
        Me.lblDrawnDateTime.Name = "lblDrawnDateTime"
        Me.lblDrawnDateTime.Size = New System.Drawing.Size(120, 20)
        Me.lblDrawnDateTime.TabIndex = 3
        Me.lblDrawnDateTime.Text = "Drawn Date and Time"
        '
        'lblLabTechnologist
        '
        Me.lblLabTechnologist.Location = New System.Drawing.Point(317, 135)
        Me.lblLabTechnologist.Name = "lblLabTechnologist"
        Me.lblLabTechnologist.Size = New System.Drawing.Size(129, 20)
        Me.lblLabTechnologist.TabIndex = 29
        Me.lblLabTechnologist.Text = "Lab Technologist (Staff)"
        '
        'dgvLabResultsEXT
        '
        Me.dgvLabResultsEXT.AllowUserToOrderColumns = True
        Me.dgvLabResultsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResultsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLabResultsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colSubTestCode, Me.colResult, Me.colNormalRange, Me.colResultFlagID, Me.colUnitMeasure, Me.colReport, Me.colSaved, Me.colResultDataTypeID})
        Me.dgvLabResultsEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabResultsEXT.EnableHeadersVisualStyles = False
        Me.dgvLabResultsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabResultsEXT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabResultsEXT.Location = New System.Drawing.Point(3, 16)
        Me.dgvLabResultsEXT.Name = "dgvLabResultsEXT"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResultsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvLabResultsEXT.Size = New System.Drawing.Size(767, 229)
        Me.dgvLabResultsEXT.TabIndex = 0
        Me.dgvLabResultsEXT.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colSubTestCode
        '
        Me.colSubTestCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colSubTestCode.DisplayStyleForCurrentCellOnly = True
        Me.colSubTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSubTestCode.HeaderText = "Sub Test Name"
        Me.colSubTestCode.Name = "colSubTestCode"
        Me.colSubTestCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSubTestCode.Width = 150
        '
        'colResult
        '
        Me.colResult.HeaderText = "Result"
        Me.colResult.MaxInputLength = 200
        Me.colResult.Name = "colResult"
        '
        'colNormalRange
        '
        Me.colNormalRange.HeaderText = "Normal Range"
        Me.colNormalRange.MaxInputLength = 800
        Me.colNormalRange.Name = "colNormalRange"
        Me.colNormalRange.Width = 85
        '
        'colResultFlagID
        '
        Me.colResultFlagID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colResultFlagID.DisplayStyleForCurrentCellOnly = True
        Me.colResultFlagID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colResultFlagID.HeaderText = "Result Flag"
        Me.colResultFlagID.Name = "colResultFlagID"
        Me.colResultFlagID.Width = 80
        '
        'colUnitMeasure
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle2
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.MaxInputLength = 100
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 80
        '
        'colReport
        '
        Me.colReport.HeaderText = "Report"
        Me.colReport.MaxInputLength = 2000
        Me.colReport.Name = "colReport"
        '
        'colSaved
        '
        Me.colSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.Width = 50
        '
        'colResultDataTypeID
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colResultDataTypeID.DefaultCellStyle = DataGridViewCellStyle4
        Me.colResultDataTypeID.HeaderText = "Result Data Type ID"
        Me.colResultDataTypeID.Name = "colResultDataTypeID"
        Me.colResultDataTypeID.ReadOnly = True
        Me.colResultDataTypeID.Visible = False
        Me.colResultDataTypeID.Width = 50
        '
        'grpLabResultsEXT
        '
        Me.grpLabResultsEXT.Controls.Add(Me.dgvLabResultsEXT)
        Me.grpLabResultsEXT.Location = New System.Drawing.Point(15, 273)
        Me.grpLabResultsEXT.Name = "grpLabResultsEXT"
        Me.grpLabResultsEXT.Size = New System.Drawing.Size(773, 248)
        Me.grpLabResultsEXT.TabIndex = 46
        Me.grpLabResultsEXT.TabStop = False
        Me.grpLabResultsEXT.Text = "Lab Results EXTRA"
        Me.grpLabResultsEXT.Visible = False
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(452, 178)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(168, 20)
        Me.stbAttendingDoctor.TabIndex = 34
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(317, 179)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(129, 20)
        Me.lblAttendingDoctor.TabIndex = 33
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(140, 163)
        Me.stbVisitNo.MaxLength = 7
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(171, 20)
        Me.stbVisitNo.TabIndex = 10
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 163)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.lblVisitNo.TabIndex = 9
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(140, 226)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(102, 20)
        Me.stbAge.TabIndex = 16
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(12, 226)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(120, 20)
        Me.lblAge.TabIndex = 15
        Me.lblAge.Text = "Age"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(140, 247)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(102, 20)
        Me.stbGender.TabIndex = 18
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(12, 247)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(120, 20)
        Me.lblGenderID.TabIndex = 17
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(140, 184)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(171, 20)
        Me.stbFullName.TabIndex = 12
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(12, 184)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(120, 20)
        Me.lblFullName.TabIndex = 11
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(140, 205)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(171, 20)
        Me.stbPatientNo.TabIndex = 14
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(12, 205)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(120, 20)
        Me.lblPatientsNo.TabIndex = 13
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnLoadList)
        Me.pnlAlerts.Controls.Add(Me.lblPendingResults)
        Me.pnlAlerts.Location = New System.Drawing.Point(248, 234)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(254, 29)
        Me.pnlAlerts.TabIndex = 37
        '
        'btnLoadList
        '
        Me.btnLoadList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadList.Location = New System.Drawing.Point(161, 3)
        Me.btnLoadList.Name = "btnLoadList"
        Me.btnLoadList.Size = New System.Drawing.Size(86, 24)
        Me.btnLoadList.TabIndex = 1
        Me.btnLoadList.Tag = ""
        Me.btnLoadList.Text = "&Load List"
        '
        'lblPendingResults
        '
        Me.lblPendingResults.AccessibleDescription = ""
        Me.lblPendingResults.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingResults.ForeColor = System.Drawing.Color.Red
        Me.lblPendingResults.Location = New System.Drawing.Point(7, 4)
        Me.lblPendingResults.Name = "lblPendingResults"
        Me.lblPendingResults.Size = New System.Drawing.Size(148, 20)
        Me.lblPendingResults.TabIndex = 0
        Me.lblPendingResults.Text = "Pending Results:"
        Me.lblPendingResults.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnViewTemplates
        '
        Me.btnViewTemplates.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTemplates.Location = New System.Drawing.Point(508, 237)
        Me.btnViewTemplates.Name = "btnViewTemplates"
        Me.btnViewTemplates.Size = New System.Drawing.Size(112, 24)
        Me.btnViewTemplates.TabIndex = 38
        Me.btnViewTemplates.Tag = ""
        Me.btnViewTemplates.Text = "&View Templates"
        '
        'lblResultFlagID
        '
        Me.lblResultFlagID.Location = New System.Drawing.Point(317, 51)
        Me.lblResultFlagID.Name = "lblResultFlagID"
        Me.lblResultFlagID.Size = New System.Drawing.Size(129, 20)
        Me.lblResultFlagID.TabIndex = 23
        Me.lblResultFlagID.Text = "Result Flag"
        '
        'lblEntryModeID
        '
        Me.lblEntryModeID.Location = New System.Drawing.Point(317, 155)
        Me.lblEntryModeID.Name = "lblEntryModeID"
        Me.lblEntryModeID.Size = New System.Drawing.Size(129, 20)
        Me.lblEntryModeID.TabIndex = 31
        Me.lblEntryModeID.Text = "Entry Mode"
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.Enabled = False
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(452, 199)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(168, 20)
        Me.stbRoundNo.TabIndex = 36
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(317, 200)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(129, 20)
        Me.lblRoundNo.TabIndex = 35
        Me.lblRoundNo.Text = "Round No"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(723, 48)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(65, 20)
        Me.nbxCoPayValue.TabIndex = 45
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(626, 49)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(91, 20)
        Me.lblCoPayValue.TabIndex = 44
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(723, 27)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(65, 20)
        Me.nbxCoPayPercent.TabIndex = 43
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(626, 28)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(91, 20)
        Me.lblCoPayPercent.TabIndex = 42
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(723, 6)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(65, 20)
        Me.stbCoPayType.TabIndex = 41
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(626, 6)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(91, 20)
        Me.lblCoPayType.TabIndex = 40
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'btnImportLabResults
        '
        Me.btnImportLabResults.Enabled = False
        Me.btnImportLabResults.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnImportLabResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportLabResults.Location = New System.Drawing.Point(629, 237)
        Me.btnImportLabResults.Name = "btnImportLabResults"
        Me.btnImportLabResults.Size = New System.Drawing.Size(113, 24)
        Me.btnImportLabResults.TabIndex = 39
        Me.btnImportLabResults.Tag = ""
        Me.btnImportLabResults.Text = "&Import Lab Results"
        Me.btnImportLabResults.Visible = False
        '
        'clbSpecimenDescription
        '
        Me.clbSpecimenDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbSpecimenDescription.Enabled = False
        Me.clbSpecimenDescription.FormattingEnabled = True
        Me.clbSpecimenDescription.Location = New System.Drawing.Point(140, 47)
        Me.clbSpecimenDescription.Name = "clbSpecimenDescription"
        Me.clbSpecimenDescription.Size = New System.Drawing.Size(168, 45)
        Me.clbSpecimenDescription.TabIndex = 2
        '
        'frmIPDLabResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(803, 610)
        Me.Controls.Add(Me.clbSpecimenDescription)
        Me.Controls.Add(Me.btnImportLabResults)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.cboEntryModeID)
        Me.Controls.Add(Me.lblEntryModeID)
        Me.Controls.Add(Me.cboResultFlagID)
        Me.Controls.Add(Me.lblResultFlagID)
        Me.Controls.Add(Me.btnViewTemplates)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbAttendingDoctor)
        Me.Controls.Add(Me.lblAttendingDoctor)
        Me.Controls.Add(Me.cboResult)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.cboLabTechnologist)
        Me.Controls.Add(Me.lblLabTechnologist)
        Me.Controls.Add(Me.stbDrawnDateTime)
        Me.Controls.Add(Me.lblDrawnDateTime)
        Me.Controls.Add(Me.stbUnitMeasure)
        Me.Controls.Add(Me.lblUnitMeasure)
        Me.Controls.Add(Me.stbNormalRange)
        Me.Controls.Add(Me.lblNormalRange)
        Me.Controls.Add(Me.pnlSpecimenNo)
        Me.Controls.Add(Me.lblTestDateTime)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.dtpTestDateTime)
        Me.Controls.Add(Me.cboTestCode)
        Me.Controls.Add(Me.lblTestCode)
        Me.Controls.Add(Me.lblSpecimenDes)
        Me.Controls.Add(Me.grpLabResultsEXT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmIPDLabResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IPD Lab Results"
        Me.pnlSpecimenNo.ResumeLayout(false)
        Me.pnlSpecimenNo.PerformLayout
        CType(Me.dgvLabResultsEXT,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpLabResultsEXT.ResumeLayout(false)
        Me.pnlAlerts.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblSpecimenDes As System.Windows.Forms.Label
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label
    Friend WithEvents cboTestCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblTestCode As System.Windows.Forms.Label
    Friend WithEvents dtpTestDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents lblTestDateTime As System.Windows.Forms.Label
    Friend WithEvents pnlSpecimenNo As System.Windows.Forms.Panel
    Friend WithEvents stbNormalRange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNormalRange As System.Windows.Forms.Label
    Friend WithEvents stbUnitMeasure As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitMeasure As System.Windows.Forms.Label
    Friend WithEvents stbDrawnDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrawnDateTime As System.Windows.Forms.Label
    Friend WithEvents lblLabTechnologist As System.Windows.Forms.Label
    Friend WithEvents cboLabTechnologist As System.Windows.Forms.ComboBox
    Friend WithEvents dgvLabResultsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents grpLabResultsEXT As System.Windows.Forms.GroupBox
    Friend WithEvents btnFindSpecimenNo As System.Windows.Forms.Button
    Friend WithEvents cboResult As System.Windows.Forms.ComboBox
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnLoadList As System.Windows.Forms.Button
    Friend WithEvents lblPendingResults As System.Windows.Forms.Label
    Friend WithEvents btnViewTemplates As System.Windows.Forms.Button
    Friend WithEvents cboResultFlagID As System.Windows.Forms.ComboBox
    Friend WithEvents lblResultFlagID As System.Windows.Forms.Label
    Friend WithEvents cboEntryModeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEntryModeID As System.Windows.Forms.Label
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSubTestCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNormalRange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResultFlagID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colResultDataTypeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnImportLabResults As System.Windows.Forms.Button
    Friend WithEvents clbSpecimenDescription As System.Windows.Forms.CheckedListBox
End Class
