<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintLabResults
    Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal specimenNo As String)
        MyClass.New()
        Me.defaultSpecimenNo = specimenNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintLabResults))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.pnlSpecimenNo = New System.Windows.Forms.Panel()
        Me.btnLoadList = New System.Windows.Forms.Button()
        Me.btnFindSpecimenNo = New System.Windows.Forms.Button()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbDrawnDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrawnDateTime = New System.Windows.Forms.Label()
        Me.dgvLabResults = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResults = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNormalRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHasSubResults = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExcludeSubResults = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colUnitMeasureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblDrawnBy = New System.Windows.Forms.Label()
        Me.stbDrawnBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRunby = New System.Windows.Forms.Label()
        Me.cboCrosscheckedby = New System.Windows.Forms.ComboBox()
        Me.lblCrosscheckedby = New System.Windows.Forms.Label()
        Me.clbRunby = New System.Windows.Forms.CheckedListBox()
        Me.pnlNavigateLabResults = New System.Windows.Forms.Panel()
        Me.chkNavigateLabResults = New System.Windows.Forms.CheckBox()
        Me.navLabResults = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.stbAdmissionLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionLocation = New System.Windows.Forms.Label()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.pnlSpecimenNo.SuspendLayout()
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateLabResults.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = True
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(140, 82)
        Me.stbPrimaryDoctor.MaxLength = 20
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(174, 20)
        Me.stbPrimaryDoctor.TabIndex = 6
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(801, 469)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 31
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
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
        Me.stbSpecimenNo.Size = New System.Drawing.Size(116, 20)
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
        'pnlSpecimenNo
        '
        Me.pnlSpecimenNo.Controls.Add(Me.btnLoadList)
        Me.pnlSpecimenNo.Controls.Add(Me.btnFindSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.stbSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.lblSpecimenNo)
        Me.pnlSpecimenNo.Location = New System.Drawing.Point(7, 7)
        Me.pnlSpecimenNo.Name = "pnlSpecimenNo"
        Me.pnlSpecimenNo.Size = New System.Drawing.Size(318, 31)
        Me.pnlSpecimenNo.TabIndex = 0
        '
        'btnLoadList
        '
        Me.btnLoadList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadList.Location = New System.Drawing.Point(255, 3)
        Me.btnLoadList.Name = "btnLoadList"
        Me.btnLoadList.Size = New System.Drawing.Size(52, 24)
        Me.btnLoadList.TabIndex = 3
        Me.btnLoadList.Tag = ""
        Me.btnLoadList.Text = "&Load "
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
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 82)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(120, 20)
        Me.lblPrimaryDoctor.TabIndex = 5
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbDrawnDateTime
        '
        Me.stbDrawnDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrawnDateTime.CapitalizeFirstLetter = False
        Me.stbDrawnDateTime.Enabled = False
        Me.stbDrawnDateTime.EntryErrorMSG = ""
        Me.stbDrawnDateTime.Location = New System.Drawing.Point(140, 61)
        Me.stbDrawnDateTime.MaxLength = 60
        Me.stbDrawnDateTime.Name = "stbDrawnDateTime"
        Me.stbDrawnDateTime.RegularExpression = ""
        Me.stbDrawnDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDrawnDateTime.Size = New System.Drawing.Size(174, 20)
        Me.stbDrawnDateTime.TabIndex = 4
        '
        'lblDrawnDateTime
        '
        Me.lblDrawnDateTime.Location = New System.Drawing.Point(12, 61)
        Me.lblDrawnDateTime.Name = "lblDrawnDateTime"
        Me.lblDrawnDateTime.Size = New System.Drawing.Size(120, 20)
        Me.lblDrawnDateTime.TabIndex = 3
        Me.lblDrawnDateTime.Text = "Drawn Date and Time"
        '
        'dgvLabResults
        '
        Me.dgvLabResults.AllowUserToAddRows = False
        Me.dgvLabResults.AllowUserToDeleteRows = False
        Me.dgvLabResults.AllowUserToOrderColumns = True
        Me.dgvLabResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLabResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvLabResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLabResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLabResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTestCode, Me.colTestName, Me.colResults, Me.colUnitMeasure, Me.colResultFlag, Me.colNormalRange, Me.colReport, Me.colHasSubResults, Me.colExcludeSubResults, Me.colUnitMeasureID, Me.colResult, Me.ColTestDescription})
        Me.dgvLabResults.EnableHeadersVisualStyles = False
        Me.dgvLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabResults.Location = New System.Drawing.Point(15, 126)
        Me.dgvLabResults.Name = "dgvLabResults"
        Me.dgvLabResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvLabResults.RowHeadersVisible = False
        Me.dgvLabResults.Size = New System.Drawing.Size(859, 248)
        Me.dgvLabResults.TabIndex = 23
        Me.dgvLabResults.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colTestCode
        '
        Me.colTestCode.DataPropertyName = "TestCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colTestCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTestCode.HeaderText = "Test Code"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.ReadOnly = True
        Me.colTestCode.Width = 70
        '
        'colTestName
        '
        Me.colTestName.DataPropertyName = "TestName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colTestName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        Me.colTestName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestName.Width = 80
        '
        'colResults
        '
        Me.colResults.DataPropertyName = "Results"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colResults.DefaultCellStyle = DataGridViewCellStyle4
        Me.colResults.HeaderText = "Result(s)"
        Me.colResults.Name = "colResults"
        Me.colResults.ReadOnly = True
        Me.colResults.Width = 120
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle5
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.MaxInputLength = 100
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 75
        '
        'colResultFlag
        '
        Me.colResultFlag.DataPropertyName = "ResultFlag"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colResultFlag.DefaultCellStyle = DataGridViewCellStyle6
        Me.colResultFlag.HeaderText = "Flag"
        Me.colResultFlag.MaxInputLength = 100
        Me.colResultFlag.Name = "colResultFlag"
        Me.colResultFlag.ReadOnly = True
        Me.colResultFlag.Width = 50
        '
        'colNormalRange
        '
        Me.colNormalRange.DataPropertyName = "NormalRange"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colNormalRange.DefaultCellStyle = DataGridViewCellStyle7
        Me.colNormalRange.HeaderText = "Normal Range"
        Me.colNormalRange.Name = "colNormalRange"
        Me.colNormalRange.ReadOnly = True
        Me.colNormalRange.Width = 80
        '
        'colReport
        '
        Me.colReport.DataPropertyName = "Report"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colReport.DefaultCellStyle = DataGridViewCellStyle8
        Me.colReport.HeaderText = "Report"
        Me.colReport.MaxInputLength = 2000
        Me.colReport.Name = "colReport"
        Me.colReport.ReadOnly = True
        Me.colReport.Width = 70
        '
        'colHasSubResults
        '
        Me.colHasSubResults.DataPropertyName = "HasSubResults"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.NullValue = False
        Me.colHasSubResults.DefaultCellStyle = DataGridViewCellStyle9
        Me.colHasSubResults.HeaderText = "Has Sub Results"
        Me.colHasSubResults.Name = "colHasSubResults"
        Me.colHasSubResults.ReadOnly = True
        Me.colHasSubResults.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHasSubResults.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colExcludeSubResults
        '
        Me.colExcludeSubResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExcludeSubResults.HeaderText = "Exclude Sub Results"
        Me.colExcludeSubResults.Name = "colExcludeSubResults"
        Me.colExcludeSubResults.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExcludeSubResults.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExcludeSubResults.Width = 120
        '
        'colUnitMeasureID
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasureID.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitMeasureID.HeaderText = "Unit Measure ID"
        Me.colUnitMeasureID.Name = "colUnitMeasureID"
        Me.colUnitMeasureID.ReadOnly = True
        Me.colUnitMeasureID.Visible = False
        '
        'colResult
        '
        Me.colResult.DataPropertyName = "Result"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colResult.DefaultCellStyle = DataGridViewCellStyle11
        Me.colResult.HeaderText = "Result"
        Me.colResult.Name = "colResult"
        Me.colResult.ReadOnly = True
        Me.colResult.Visible = False
        '
        'ColTestDescription
        '
        Me.ColTestDescription.DataPropertyName = "TestDescription"
        Me.ColTestDescription.HeaderText = "Test Description"
        Me.ColTestDescription.Name = "ColTestDescription"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 469)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 24)
        Me.btnPrint.TabIndex = 28
        Me.btnPrint.Text = "&Print"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(125, 469)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 29
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(140, 103)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(174, 20)
        Me.stbVisitDate.TabIndex = 8
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 103)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(446, 4)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(158, 20)
        Me.stbFullName.TabIndex = 10
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(332, 4)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(108, 20)
        Me.lblFullName.TabIndex = 9
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(446, 25)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(158, 20)
        Me.stbPatientNo.TabIndex = 12
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(332, 25)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(108, 20)
        Me.lblPatientsNo.TabIndex = 11
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(680, 8)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(159, 20)
        Me.stbAge.TabIndex = 16
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(680, 29)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(159, 20)
        Me.stbGender.TabIndex = 18
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(610, 7)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(64, 19)
        Me.lblAge.TabIndex = 15
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(610, 28)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(64, 19)
        Me.lblGenderID.TabIndex = 17
        Me.lblGenderID.Text = "Gender"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(446, 46)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(158, 29)
        Me.stbBillCustomerName.TabIndex = 14
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(332, 49)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(108, 20)
        Me.lblBillCustomerName.TabIndex = 13
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(680, 50)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(159, 20)
        Me.stbBillMode.TabIndex = 20
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(610, 48)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(64, 19)
        Me.lblBillMode.TabIndex = 19
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblDrawnBy
        '
        Me.lblDrawnBy.Location = New System.Drawing.Point(12, 41)
        Me.lblDrawnBy.Name = "lblDrawnBy"
        Me.lblDrawnBy.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnBy.TabIndex = 1
        Me.lblDrawnBy.Text = "Drawn By (Staff)"
        '
        'stbDrawnBy
        '
        Me.stbDrawnBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrawnBy.CapitalizeFirstLetter = True
        Me.stbDrawnBy.Enabled = False
        Me.stbDrawnBy.EntryErrorMSG = ""
        Me.stbDrawnBy.Location = New System.Drawing.Point(140, 40)
        Me.stbDrawnBy.MaxLength = 20
        Me.stbDrawnBy.Name = "stbDrawnBy"
        Me.stbDrawnBy.RegularExpression = ""
        Me.stbDrawnBy.Size = New System.Drawing.Size(174, 20)
        Me.stbDrawnBy.TabIndex = 2
        '
        'lblRunby
        '
        Me.lblRunby.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRunby.Location = New System.Drawing.Point(15, 403)
        Me.lblRunby.Name = "lblRunby"
        Me.lblRunby.Size = New System.Drawing.Size(117, 20)
        Me.lblRunby.TabIndex = 24
        Me.lblRunby.Text = "Run by"
        '
        'cboCrosscheckedby
        '
        Me.cboCrosscheckedby.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboCrosscheckedby.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCrosscheckedby.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCrosscheckedby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCrosscheckedby.DropDownWidth = 230
        Me.cboCrosscheckedby.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCrosscheckedby.FormattingEnabled = True
        Me.cboCrosscheckedby.Location = New System.Drawing.Point(446, 380)
        Me.cboCrosscheckedby.Name = "cboCrosscheckedby"
        Me.cboCrosscheckedby.Size = New System.Drawing.Size(186, 21)
        Me.cboCrosscheckedby.Sorted = True
        Me.cboCrosscheckedby.TabIndex = 27
        '
        'lblCrosscheckedby
        '
        Me.lblCrosscheckedby.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCrosscheckedby.Location = New System.Drawing.Point(335, 381)
        Me.lblCrosscheckedby.Name = "lblCrosscheckedby"
        Me.lblCrosscheckedby.Size = New System.Drawing.Size(105, 20)
        Me.lblCrosscheckedby.TabIndex = 26
        Me.lblCrosscheckedby.Text = "Cross checked by"
        '
        'clbRunby
        '
        Me.clbRunby.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.clbRunby.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbRunby.FormattingEnabled = True
        Me.clbRunby.Location = New System.Drawing.Point(138, 380)
        Me.clbRunby.Name = "clbRunby"
        Me.clbRunby.Size = New System.Drawing.Size(164, 75)
        Me.clbRunby.TabIndex = 25
        '
        'pnlNavigateLabResults
        '
        Me.pnlNavigateLabResults.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateLabResults.Controls.Add(Me.chkNavigateLabResults)
        Me.pnlNavigateLabResults.Controls.Add(Me.navLabResults)
        Me.pnlNavigateLabResults.Location = New System.Drawing.Point(325, 436)
        Me.pnlNavigateLabResults.Name = "pnlNavigateLabResults"
        Me.pnlNavigateLabResults.Size = New System.Drawing.Size(453, 65)
        Me.pnlNavigateLabResults.TabIndex = 30
        '
        'chkNavigateLabResults
        '
        Me.chkNavigateLabResults.AccessibleDescription = ""
        Me.chkNavigateLabResults.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateLabResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateLabResults.Location = New System.Drawing.Point(138, 4)
        Me.chkNavigateLabResults.Name = "chkNavigateLabResults"
        Me.chkNavigateLabResults.Size = New System.Drawing.Size(186, 20)
        Me.chkNavigateLabResults.TabIndex = 0
        Me.chkNavigateLabResults.Text = "Navigate Patient Lab Results"
        '
        'navLabResults
        '
        Me.navLabResults.ColumnName = "SpecimenNo"
        Me.navLabResults.DataSource = Nothing
        Me.navLabResults.Location = New System.Drawing.Point(13, 30)
        Me.navLabResults.Name = "navLabResults"
        Me.navLabResults.NavAllEnabled = False
        Me.navLabResults.NavLeftEnabled = False
        Me.navLabResults.NavRightEnabled = False
        Me.navLabResults.Size = New System.Drawing.Size(430, 32)
        Me.navLabResults.TabIndex = 1
        '
        'stbAdmissionLocation
        '
        Me.stbAdmissionLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionLocation.CapitalizeFirstLetter = False
        Me.stbAdmissionLocation.Enabled = False
        Me.stbAdmissionLocation.EntryErrorMSG = ""
        Me.stbAdmissionLocation.Location = New System.Drawing.Point(680, 71)
        Me.stbAdmissionLocation.MaxLength = 60
        Me.stbAdmissionLocation.Name = "stbAdmissionLocation"
        Me.stbAdmissionLocation.RegularExpression = ""
        Me.stbAdmissionLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionLocation.Size = New System.Drawing.Size(159, 20)
        Me.stbAdmissionLocation.TabIndex = 22
        '
        'lblAdmissionLocation
        '
        Me.lblAdmissionLocation.Location = New System.Drawing.Point(610, 69)
        Me.lblAdmissionLocation.Name = "lblAdmissionLocation"
        Me.lblAdmissionLocation.Size = New System.Drawing.Size(64, 19)
        Me.lblAdmissionLocation.TabIndex = 21
        Me.lblAdmissionLocation.Text = "Location"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(718, 97)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 32
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(446, 77)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitCategory.TabIndex = 34
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(332, 79)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCategory.TabIndex = 33
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(446, 101)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(158, 21)
        Me.chkFingerprintCaptured.TabIndex = 81
        Me.chkFingerprintCaptured.Text = "Fingerprint Verified"
        '
        'frmPrintLabResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(888, 507)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.stbAdmissionLocation)
        Me.Controls.Add(Me.lblAdmissionLocation)
        Me.Controls.Add(Me.pnlNavigateLabResults)
        Me.Controls.Add(Me.clbRunby)
        Me.Controls.Add(Me.cboCrosscheckedby)
        Me.Controls.Add(Me.lblCrosscheckedby)
        Me.Controls.Add(Me.lblRunby)
        Me.Controls.Add(Me.stbDrawnBy)
        Me.Controls.Add(Me.lblDrawnBy)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvLabResults)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbDrawnDateTime)
        Me.Controls.Add(Me.lblDrawnDateTime)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.pnlSpecimenNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPrintLabResults"
        Me.Text = "Print Lab Results"
        Me.pnlSpecimenNo.ResumeLayout(False)
        Me.pnlSpecimenNo.PerformLayout()
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateLabResults.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label
    Friend WithEvents pnlSpecimenNo As System.Windows.Forms.Panel
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbDrawnDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrawnDateTime As System.Windows.Forms.Label
    Friend WithEvents btnFindSpecimenNo As System.Windows.Forms.Button
    Friend WithEvents dgvLabResults As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblDrawnBy As System.Windows.Forms.Label
    Friend WithEvents stbDrawnBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRunby As System.Windows.Forms.Label
    Friend WithEvents cboCrosscheckedby As System.Windows.Forms.ComboBox
    Friend WithEvents lblCrosscheckedby As System.Windows.Forms.Label
    Friend WithEvents clbRunby As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnLoadList As System.Windows.Forms.Button
    Friend WithEvents pnlNavigateLabResults As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateLabResults As System.Windows.Forms.CheckBox
    Friend WithEvents navLabResults As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents stbAdmissionLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionLocation As System.Windows.Forms.Label
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResults As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResultFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNormalRange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHasSubResults As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExcludeSubResults As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colUnitMeasureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestDescription As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
