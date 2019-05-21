<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabResultsApproval
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabResultsApproval))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbAdmissionLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionLocation = New System.Windows.Forms.Label()
        Me.stbDrawnBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrawnBy = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
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
        Me.stbDrawnDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDrawnDateTime = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.pnlSpecimenNo = New System.Windows.Forms.Panel()
        Me.btnLoadList = New System.Windows.Forms.Button()
        Me.btnFindSpecimenNo = New System.Windows.Forms.Button()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.pnlNavigateLabResults = New System.Windows.Forms.Panel()
        Me.chkNavigateLabResults = New System.Windows.Forms.CheckBox()
        Me.navLabResults = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.clbRunby = New System.Windows.Forms.CheckedListBox()
        Me.lblRunby = New System.Windows.Forms.Label()
        Me.btnViewLabResultsList = New System.Windows.Forms.Button()
        Me.lblLabResultsAlerts = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnViewIPDLabRequests = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.tpgUnapprovedTests = New System.Windows.Forms.TabControl()
        Me.tpgReadyResults = New System.Windows.Forms.TabPage()
        Me.tpgPendingResults = New System.Windows.Forms.TabPage()
        Me.dgvPendingResults = New System.Windows.Forms.DataGridView()
        Me.ColSpecimenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkIsAdmitted = New System.Windows.Forms.CheckBox()
        Me.lblAgeString = New System.Windows.Forms.Label()
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSpecimenNo.SuspendLayout()
        Me.pnlNavigateLabResults.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.tpgUnapprovedTests.SuspendLayout()
        Me.tpgReadyResults.SuspendLayout()
        Me.tpgPendingResults.SuspendLayout()
        CType(Me.dgvPendingResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(429, 81)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitCategory.TabIndex = 108
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(332, 83)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(91, 20)
        Me.lblVisitCategory.TabIndex = 107
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionLocation
        '
        Me.stbAdmissionLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionLocation.CapitalizeFirstLetter = False
        Me.stbAdmissionLocation.Enabled = False
        Me.stbAdmissionLocation.EntryErrorMSG = ""
        Me.stbAdmissionLocation.Location = New System.Drawing.Point(660, 75)
        Me.stbAdmissionLocation.MaxLength = 200
        Me.stbAdmissionLocation.Multiline = True
        Me.stbAdmissionLocation.Name = "stbAdmissionLocation"
        Me.stbAdmissionLocation.RegularExpression = ""
        Me.stbAdmissionLocation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionLocation.Size = New System.Drawing.Size(159, 42)
        Me.stbAdmissionLocation.TabIndex = 104
        '
        'lblAdmissionLocation
        '
        Me.lblAdmissionLocation.Location = New System.Drawing.Point(590, 73)
        Me.lblAdmissionLocation.Name = "lblAdmissionLocation"
        Me.lblAdmissionLocation.Size = New System.Drawing.Size(64, 19)
        Me.lblAdmissionLocation.TabIndex = 103
        Me.lblAdmissionLocation.Text = "Location"
        '
        'stbDrawnBy
        '
        Me.stbDrawnBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrawnBy.CapitalizeFirstLetter = True
        Me.stbDrawnBy.Enabled = False
        Me.stbDrawnBy.EntryErrorMSG = ""
        Me.stbDrawnBy.Location = New System.Drawing.Point(140, 44)
        Me.stbDrawnBy.MaxLength = 20
        Me.stbDrawnBy.Name = "stbDrawnBy"
        Me.stbDrawnBy.RegularExpression = ""
        Me.stbDrawnBy.Size = New System.Drawing.Size(174, 20)
        Me.stbDrawnBy.TabIndex = 84
        '
        'lblDrawnBy
        '
        Me.lblDrawnBy.Location = New System.Drawing.Point(12, 45)
        Me.lblDrawnBy.Name = "lblDrawnBy"
        Me.lblDrawnBy.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnBy.TabIndex = 83
        Me.lblDrawnBy.Text = "Drawn By (Staff)"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(660, 54)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(159, 20)
        Me.stbBillMode.TabIndex = 102
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(590, 52)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(64, 19)
        Me.lblBillMode.TabIndex = 101
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(429, 50)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(158, 29)
        Me.stbBillCustomerName.TabIndex = 96
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(332, 53)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(91, 20)
        Me.lblBillCustomerName.TabIndex = 95
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(140, 107)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(174, 20)
        Me.stbVisitDate.TabIndex = 90
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 107)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 89
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(429, 8)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(158, 20)
        Me.stbFullName.TabIndex = 92
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(332, 8)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(91, 20)
        Me.lblFullName.TabIndex = 91
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(429, 29)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(158, 20)
        Me.stbPatientNo.TabIndex = 94
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(332, 29)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(91, 20)
        Me.lblPatientsNo.TabIndex = 93
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(660, 12)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(43, 20)
        Me.stbAge.TabIndex = 98
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(660, 33)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(159, 20)
        Me.stbGender.TabIndex = 100
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(590, 11)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(64, 19)
        Me.lblAge.TabIndex = 97
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(590, 32)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(64, 19)
        Me.lblGenderID.TabIndex = 99
        Me.lblGenderID.Text = "Gender"
        '
        'dgvLabResults
        '
        Me.dgvLabResults.AllowUserToAddRows = False
        Me.dgvLabResults.AllowUserToDeleteRows = False
        Me.dgvLabResults.AllowUserToOrderColumns = True
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
        Me.dgvLabResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabResults.EnableHeadersVisualStyles = False
        Me.dgvLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabResults.Location = New System.Drawing.Point(3, 3)
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
        Me.dgvLabResults.Size = New System.Drawing.Size(1000, 268)
        Me.dgvLabResults.TabIndex = 105
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
        'stbDrawnDateTime
        '
        Me.stbDrawnDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrawnDateTime.CapitalizeFirstLetter = False
        Me.stbDrawnDateTime.Enabled = False
        Me.stbDrawnDateTime.EntryErrorMSG = ""
        Me.stbDrawnDateTime.Location = New System.Drawing.Point(140, 65)
        Me.stbDrawnDateTime.MaxLength = 60
        Me.stbDrawnDateTime.Name = "stbDrawnDateTime"
        Me.stbDrawnDateTime.RegularExpression = ""
        Me.stbDrawnDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDrawnDateTime.Size = New System.Drawing.Size(174, 20)
        Me.stbDrawnDateTime.TabIndex = 86
        '
        'lblDrawnDateTime
        '
        Me.lblDrawnDateTime.Location = New System.Drawing.Point(12, 65)
        Me.lblDrawnDateTime.Name = "lblDrawnDateTime"
        Me.lblDrawnDateTime.Size = New System.Drawing.Size(120, 20)
        Me.lblDrawnDateTime.TabIndex = 85
        Me.lblDrawnDateTime.Text = "Drawn Date and Time"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = True
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(140, 86)
        Me.stbPrimaryDoctor.MaxLength = 20
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(174, 20)
        Me.stbPrimaryDoctor.TabIndex = 88
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 86)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(120, 20)
        Me.lblPrimaryDoctor.TabIndex = 87
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'pnlSpecimenNo
        '
        Me.pnlSpecimenNo.Controls.Add(Me.btnLoadList)
        Me.pnlSpecimenNo.Controls.Add(Me.btnFindSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.stbSpecimenNo)
        Me.pnlSpecimenNo.Controls.Add(Me.lblSpecimenNo)
        Me.pnlSpecimenNo.Location = New System.Drawing.Point(7, 11)
        Me.pnlSpecimenNo.Name = "pnlSpecimenNo"
        Me.pnlSpecimenNo.Size = New System.Drawing.Size(318, 31)
        Me.pnlSpecimenNo.TabIndex = 82
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
        'pnlNavigateLabResults
        '
        Me.pnlNavigateLabResults.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateLabResults.Controls.Add(Me.chkNavigateLabResults)
        Me.pnlNavigateLabResults.Controls.Add(Me.navLabResults)
        Me.pnlNavigateLabResults.Location = New System.Drawing.Point(203, 467)
        Me.pnlNavigateLabResults.Name = "pnlNavigateLabResults"
        Me.pnlNavigateLabResults.Size = New System.Drawing.Size(685, 54)
        Me.pnlNavigateLabResults.TabIndex = 111
        '
        'chkNavigateLabResults
        '
        Me.chkNavigateLabResults.AccessibleDescription = ""
        Me.chkNavigateLabResults.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateLabResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateLabResults.Location = New System.Drawing.Point(138, 0)
        Me.chkNavigateLabResults.Name = "chkNavigateLabResults"
        Me.chkNavigateLabResults.Size = New System.Drawing.Size(186, 20)
        Me.chkNavigateLabResults.TabIndex = 0
        Me.chkNavigateLabResults.Text = "Navigate Patient Lab Results"
        '
        'navLabResults
        '
        Me.navLabResults.ColumnName = "SpecimenNo"
        Me.navLabResults.DataSource = Nothing
        Me.navLabResults.Location = New System.Drawing.Point(21, 19)
        Me.navLabResults.Name = "navLabResults"
        Me.navLabResults.NavAllEnabled = False
        Me.navLabResults.NavLeftEnabled = False
        Me.navLabResults.NavRightEnabled = False
        Me.navLabResults.Size = New System.Drawing.Size(430, 32)
        Me.navLabResults.TabIndex = 1
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApprove.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Location = New System.Drawing.Point(18, 489)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(104, 24)
        Me.btnApprove.TabIndex = 109
        Me.btnApprove.Text = "&Approve"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(953, 489)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 112
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'clbRunby
        '
        Me.clbRunby.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbRunby.Enabled = False
        Me.clbRunby.FormattingEnabled = True
        Me.clbRunby.Location = New System.Drawing.Point(825, 34)
        Me.clbRunby.Name = "clbRunby"
        Me.clbRunby.Size = New System.Drawing.Size(199, 60)
        Me.clbRunby.TabIndex = 114
        '
        'lblRunby
        '
        Me.lblRunby.Location = New System.Drawing.Point(822, 11)
        Me.lblRunby.Name = "lblRunby"
        Me.lblRunby.Size = New System.Drawing.Size(93, 20)
        Me.lblRunby.TabIndex = 113
        Me.lblRunby.Text = "Run by"
        '
        'btnViewLabResultsList
        '
        Me.btnViewLabResultsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewLabResultsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewLabResultsList.Location = New System.Drawing.Point(269, 133)
        Me.btnViewLabResultsList.Name = "btnViewLabResultsList"
        Me.btnViewLabResultsList.Size = New System.Drawing.Size(73, 24)
        Me.btnViewLabResultsList.TabIndex = 116
        Me.btnViewLabResultsList.Tag = ""
        Me.btnViewLabResultsList.Text = "&View List"
        '
        'lblLabResultsAlerts
        '
        Me.lblLabResultsAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabResultsAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblLabResultsAlerts.Location = New System.Drawing.Point(11, 134)
        Me.lblLabResultsAlerts.Name = "lblLabResultsAlerts"
        Me.lblLabResultsAlerts.Size = New System.Drawing.Size(252, 20)
        Me.lblLabResultsAlerts.TabIndex = 115
        Me.lblLabResultsAlerts.Text = "Unapproved Ready Results: 0"
        Me.lblLabResultsAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnViewIPDLabRequests)
        Me.Panel1.Controls.Add(Me.lblIPDAlerts)
        Me.Panel1.Location = New System.Drawing.Point(699, 124)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 33)
        Me.Panel1.TabIndex = 118
        '
        'BtnViewIPDLabRequests
        '
        Me.BtnViewIPDLabRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnViewIPDLabRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewIPDLabRequests.Location = New System.Drawing.Point(255, 5)
        Me.BtnViewIPDLabRequests.Name = "BtnViewIPDLabRequests"
        Me.BtnViewIPDLabRequests.Size = New System.Drawing.Size(63, 24)
        Me.BtnViewIPDLabRequests.TabIndex = 1
        Me.BtnViewIPDLabRequests.Tag = ""
        Me.BtnViewIPDLabRequests.Text = "&View List"
        '
        'lblIPDAlerts
        '
        Me.lblIPDAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlerts.Location = New System.Drawing.Point(8, 7)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(233, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "IPD Doctor Lab Requests: 0"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(369, 123)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(325, 34)
        Me.pnlAlerts.TabIndex = 117
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(255, 6)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(63, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(6, 8)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(243, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Lab Requests: 0"
        '
        'tpgUnapprovedTests
        '
        Me.tpgUnapprovedTests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tpgUnapprovedTests.Controls.Add(Me.tpgReadyResults)
        Me.tpgUnapprovedTests.Controls.Add(Me.tpgPendingResults)
        Me.tpgUnapprovedTests.Location = New System.Drawing.Point(11, 161)
        Me.tpgUnapprovedTests.Name = "tpgUnapprovedTests"
        Me.tpgUnapprovedTests.SelectedIndex = 0
        Me.tpgUnapprovedTests.Size = New System.Drawing.Size(1014, 300)
        Me.tpgUnapprovedTests.TabIndex = 119
        '
        'tpgReadyResults
        '
        Me.tpgReadyResults.Controls.Add(Me.dgvLabResults)
        Me.tpgReadyResults.Location = New System.Drawing.Point(4, 22)
        Me.tpgReadyResults.Name = "tpgReadyResults"
        Me.tpgReadyResults.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgReadyResults.Size = New System.Drawing.Size(1006, 274)
        Me.tpgReadyResults.TabIndex = 0
        Me.tpgReadyResults.Text = "Ready Results"
        Me.tpgReadyResults.UseVisualStyleBackColor = True
        '
        'tpgPendingResults
        '
        Me.tpgPendingResults.Controls.Add(Me.dgvPendingResults)
        Me.tpgPendingResults.Location = New System.Drawing.Point(4, 22)
        Me.tpgPendingResults.Name = "tpgPendingResults"
        Me.tpgPendingResults.Size = New System.Drawing.Size(1006, 274)
        Me.tpgPendingResults.TabIndex = 1
        Me.tpgPendingResults.Text = "Pending Results"
        Me.tpgPendingResults.UseVisualStyleBackColor = True
        '
        'dgvPendingResults
        '
        Me.dgvPendingResults.AllowUserToAddRows = False
        Me.dgvPendingResults.AllowUserToDeleteRows = False
        Me.dgvPendingResults.AllowUserToOrderColumns = True
        Me.dgvPendingResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPendingResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColSpecimenNo, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.ColRecordDate, Me.ColRecordTime, Me.ColLoginID})
        Me.dgvPendingResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingResults.EnableHeadersVisualStyles = False
        Me.dgvPendingResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingResults.Location = New System.Drawing.Point(0, 0)
        Me.dgvPendingResults.Name = "dgvPendingResults"
        Me.dgvPendingResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvPendingResults.RowHeadersVisible = False
        Me.dgvPendingResults.Size = New System.Drawing.Size(1006, 274)
        Me.dgvPendingResults.TabIndex = 106
        Me.dgvPendingResults.Text = "DataGridView1"
        '
        'ColSpecimenNo
        '
        Me.ColSpecimenNo.DataPropertyName = "SpecimenNo"
        Me.ColSpecimenNo.HeaderText = "Specimen No"
        Me.ColSpecimenNo.Name = "ColSpecimenNo"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "TestCode"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn1.HeaderText = "Test Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 90
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "TestName"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn2.HeaderText = "Test Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Width = 190
        '
        'ColRecordDate
        '
        Me.ColRecordDate.DataPropertyName = "RecordDate"
        Me.ColRecordDate.HeaderText = "Record Date"
        Me.ColRecordDate.Name = "ColRecordDate"
        Me.ColRecordDate.Width = 120
        '
        'ColRecordTime
        '
        Me.ColRecordTime.DataPropertyName = "RecordTime"
        Me.ColRecordTime.HeaderText = "Record Time"
        Me.ColRecordTime.Name = "ColRecordTime"
        Me.ColRecordTime.Width = 120
        '
        'ColLoginID
        '
        Me.ColLoginID.DataPropertyName = "LoginID"
        Me.ColLoginID.HeaderText = "Login ID"
        Me.ColLoginID.Name = "ColLoginID"
        Me.ColLoginID.Width = 120
        '
        'chkIsAdmitted
        '
        Me.chkIsAdmitted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIsAdmitted.Enabled = False
        Me.chkIsAdmitted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIsAdmitted.Location = New System.Drawing.Point(335, 103)
        Me.chkIsAdmitted.Name = "chkIsAdmitted"
        Me.chkIsAdmitted.Size = New System.Drawing.Size(252, 20)
        Me.chkIsAdmitted.TabIndex = 120
        Me.chkIsAdmitted.Text = "Patient Admitted"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(706, 12)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(111, 19)
        Me.lblAgeString.TabIndex = 127
        '
        'frmLabResultsApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1037, 525)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.chkIsAdmitted)
        Me.Controls.Add(Me.tpgUnapprovedTests)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.btnViewLabResultsList)
        Me.Controls.Add(Me.lblLabResultsAlerts)
        Me.Controls.Add(Me.clbRunby)
        Me.Controls.Add(Me.lblRunby)
        Me.Controls.Add(Me.pnlNavigateLabResults)
        Me.Controls.Add(Me.btnApprove)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbAdmissionLocation)
        Me.Controls.Add(Me.lblAdmissionLocation)
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
        Me.Controls.Add(Me.stbDrawnDateTime)
        Me.Controls.Add(Me.lblDrawnDateTime)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.pnlSpecimenNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLabResultsApproval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Results Approval"
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSpecimenNo.ResumeLayout(False)
        Me.pnlSpecimenNo.PerformLayout()
        Me.pnlNavigateLabResults.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlAlerts.ResumeLayout(False)
        Me.tpgUnapprovedTests.ResumeLayout(False)
        Me.tpgReadyResults.ResumeLayout(False)
        Me.tpgPendingResults.ResumeLayout(False)
        CType(Me.dgvPendingResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionLocation As System.Windows.Forms.Label
    Friend WithEvents stbDrawnBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrawnBy As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
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
    Friend WithEvents dgvLabResults As System.Windows.Forms.DataGridView
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
    Friend WithEvents stbDrawnDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrawnDateTime As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents pnlSpecimenNo As System.Windows.Forms.Panel
    Friend WithEvents btnLoadList As System.Windows.Forms.Button
    Friend WithEvents btnFindSpecimenNo As System.Windows.Forms.Button
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label
    Friend WithEvents pnlNavigateLabResults As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateLabResults As System.Windows.Forms.CheckBox
    Friend WithEvents navLabResults As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents btnApprove As System.Windows.Forms.Button
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents clbRunby As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblRunby As System.Windows.Forms.Label
    Friend WithEvents btnViewLabResultsList As System.Windows.Forms.Button
    Friend WithEvents lblLabResultsAlerts As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnViewIPDLabRequests As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tpgUnapprovedTests As System.Windows.Forms.TabControl
    Friend WithEvents tpgReadyResults As System.Windows.Forms.TabPage
    Friend WithEvents chkIsAdmitted As System.Windows.Forms.CheckBox
    Friend WithEvents tpgPendingResults As System.Windows.Forms.TabPage
    Friend WithEvents dgvPendingResults As System.Windows.Forms.DataGridView
    Friend WithEvents ColSpecimenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
End Class
