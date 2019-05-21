<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmARTRegimen : Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmARTRegimen))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboCombination = New System.Windows.Forms.ComboBox()
        Me.cboDrugLinesID = New System.Windows.Forms.ComboBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboWHOStageID = New System.Windows.Forms.ComboBox()
        Me.cboARTCategoryID = New System.Windows.Forms.ComboBox()
        Me.nbxRefillDuration = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.clbWhyEligible = New System.Windows.Forms.CheckedListBox()
        Me.clbARTSwitchReasons = New System.Windows.Forms.CheckedListBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.lblDrugLinesID = New System.Windows.Forms.Label()
        Me.pnlDrugLine = New System.Windows.Forms.Panel()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblWHOStageID = New System.Windows.Forms.Label()
        Me.pnlARTCategory = New System.Windows.Forms.Panel()
        Me.lblARTCategoryID = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblRefillDuration = New System.Windows.Forms.Label()
        Me.lblWhyEligible = New System.Windows.Forms.Label()
        Me.lblARTSwitchReasons = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDrugLine.SuspendLayout()
        Me.pnlARTCategory.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(682, 26)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(115, 20)
        Me.stbStatus.TabIndex = 33
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(607, 25)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(68, 20)
        Me.lblStatus.TabIndex = 32
        Me.lblStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(682, 5)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(115, 20)
        Me.stbAge.TabIndex = 31
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(682, 110)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(115, 20)
        Me.stbJoinDate.TabIndex = 41
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(682, 47)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(115, 20)
        Me.stbGender.TabIndex = 35
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(607, 110)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(68, 20)
        Me.lblJoinDate.TabIndex = 40
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(607, 4)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(68, 20)
        Me.lblAge.TabIndex = 30
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(607, 47)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(68, 20)
        Me.lblGenderID.TabIndex = 34
        Me.lblGenderID.Text = "Gender"
        '
        'dtpStartDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStartDate, "StartDate")
        Me.dtpStartDate.Location = New System.Drawing.Point(137, 52)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(164, 20)
        Me.dtpStartDate.TabIndex = 7
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(17, 51)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(99, 21)
        Me.lblStartDate.TabIndex = 6
        Me.lblStartDate.Text = "Start Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(458, 153)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(143, 20)
        Me.stbFullName.TabIndex = 25
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(319, 153)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(133, 20)
        Me.lblFullName.TabIndex = 24
        Me.lblFullName.Text = "Full Name"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(682, 68)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(115, 20)
        Me.stbBillMode.TabIndex = 37
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(458, 174)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(143, 20)
        Me.stbVisitCategory.TabIndex = 27
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(607, 70)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(68, 20)
        Me.lblBillMode.TabIndex = 36
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(319, 176)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitCategory.TabIndex = 26
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(458, 195)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(143, 20)
        Me.stbBillNo.TabIndex = 29
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(319, 197)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(133, 20)
        Me.lblBillNo.TabIndex = 28
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(17, 7)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(81, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(682, 89)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitDate.TabIndex = 39
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(458, 132)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(143, 20)
        Me.stbPatientNo.TabIndex = 23
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(319, 132)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(133, 20)
        Me.lblPatientsNo.TabIndex = 22
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(607, 89)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(68, 20)
        Me.lblVisitDate.TabIndex = 38
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = True
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(137, 7)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(114, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(17, 433)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 23)
        Me.btnSearch.TabIndex = 43
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
        Me.btnDelete.Location = New System.Drawing.Point(711, 433)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 24)
        Me.btnDelete.TabIndex = 44
        Me.btnDelete.Tag = "ARTRegimen"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 462)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(94, 23)
        Me.ebnSaveUpdate.TabIndex = 45
        Me.ebnSaveUpdate.Tag = "ARTRegimen"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboCombination
        '
        Me.cboCombination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCombination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCombination, "Combination")
        Me.cboCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCombination.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCombination.FormattingEnabled = True
        Me.cboCombination.Location = New System.Drawing.Point(137, 29)
        Me.cboCombination.Name = "cboCombination"
        Me.cboCombination.Size = New System.Drawing.Size(164, 21)
        Me.cboCombination.TabIndex = 5
        '
        'cboDrugLinesID
        '
        Me.cboDrugLinesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDrugLinesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDrugLinesID, "DrugLines,DrugLinesID")
        Me.cboDrugLinesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDrugLinesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDrugLinesID.FormattingEnabled = True
        Me.cboDrugLinesID.Location = New System.Drawing.Point(125, 3)
        Me.cboDrugLinesID.Name = "cboDrugLinesID"
        Me.cboDrugLinesID.Size = New System.Drawing.Size(164, 21)
        Me.cboDrugLinesID.TabIndex = 1
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(137, 125)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(164, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 12
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(458, 69)
        Me.stbNotes.MaxLength = 100
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(143, 41)
        Me.stbNotes.TabIndex = 19
        '
        'cboWHOStageID
        '
        Me.cboWHOStageID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWHOStageID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboWHOStageID, "WHOStage,WHOStageID")
        Me.cboWHOStageID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWHOStageID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWHOStageID.FormattingEnabled = True
        Me.cboWHOStageID.Location = New System.Drawing.Point(137, 74)
        Me.cboWHOStageID.Name = "cboWHOStageID"
        Me.cboWHOStageID.Size = New System.Drawing.Size(164, 21)
        Me.cboWHOStageID.TabIndex = 9
        '
        'cboARTCategoryID
        '
        Me.cboARTCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboARTCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboARTCategoryID, "ARTCategory,ARTCategoryID")
        Me.cboARTCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboARTCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboARTCategoryID.FormattingEnabled = True
        Me.cboARTCategoryID.Location = New System.Drawing.Point(125, 3)
        Me.cboARTCategoryID.Name = "cboARTCategoryID"
        Me.cboARTCategoryID.Size = New System.Drawing.Size(164, 21)
        Me.cboARTCategoryID.TabIndex = 1
        '
        'nbxRefillDuration
        '
        Me.nbxRefillDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefillDuration.ControlCaption = "Refill Duration"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxRefillDuration, "RefillDuration")
        Me.nbxRefillDuration.DecimalPlaces = -1
        Me.nbxRefillDuration.Location = New System.Drawing.Point(458, 111)
        Me.nbxRefillDuration.MaxLength = 3
        Me.nbxRefillDuration.MaxValue = 999.0R
        Me.nbxRefillDuration.MinValue = 0.0R
        Me.nbxRefillDuration.MustEnterNumeric = True
        Me.nbxRefillDuration.Name = "nbxRefillDuration"
        Me.nbxRefillDuration.Size = New System.Drawing.Size(143, 20)
        Me.nbxRefillDuration.TabIndex = 21
        Me.nbxRefillDuration.Value = ""
        Me.nbxRefillDuration.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'clbWhyEligible
        '
        Me.clbWhyEligible.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbWhyEligible, "WhyEligible")
        Me.clbWhyEligible.Enabled = False
        Me.clbWhyEligible.FormattingEnabled = True
        Me.clbWhyEligible.Location = New System.Drawing.Point(137, 181)
        Me.clbWhyEligible.Name = "clbWhyEligible"
        Me.clbWhyEligible.Size = New System.Drawing.Size(164, 60)
        Me.clbWhyEligible.TabIndex = 15
        '
        'clbARTSwitchReasons
        '
        Me.clbARTSwitchReasons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbARTSwitchReasons, "ARTSwitchReasons")
        Me.clbARTSwitchReasons.Enabled = False
        Me.clbARTSwitchReasons.FormattingEnabled = True
        Me.clbARTSwitchReasons.Location = New System.Drawing.Point(458, 6)
        Me.clbARTSwitchReasons.Name = "clbARTSwitchReasons"
        Me.clbARTSwitchReasons.Size = New System.Drawing.Size(143, 60)
        Me.clbARTSwitchReasons.TabIndex = 17
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(711, 463)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(86, 24)
        Me.fbnClose.TabIndex = 46
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDosage, Me.colDuration, Me.colDrugQuantity, Me.colDrugFormula, Me.colPrescriptionSaved})
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(17, 247)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPrescription.Size = New System.Drawing.Size(780, 180)
        Me.dgvPrescription.TabIndex = 42
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(17, 29)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(99, 21)
        Me.lblCombination.TabIndex = 4
        Me.lblCombination.Text = "Combination"
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(17, 125)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(99, 21)
        Me.lblStaff.TabIndex = 11
        Me.lblStaff.Text = "Doctor (Staff)"
        '
        'lblDrugLinesID
        '
        Me.lblDrugLinesID.Location = New System.Drawing.Point(5, 3)
        Me.lblDrugLinesID.Name = "lblDrugLinesID"
        Me.lblDrugLinesID.Size = New System.Drawing.Size(99, 21)
        Me.lblDrugLinesID.TabIndex = 0
        Me.lblDrugLinesID.Text = "Drug Line"
        '
        'pnlDrugLine
        '
        Me.pnlDrugLine.Controls.Add(Me.cboDrugLinesID)
        Me.pnlDrugLine.Controls.Add(Me.lblDrugLinesID)
        Me.pnlDrugLine.Location = New System.Drawing.Point(12, 97)
        Me.pnlDrugLine.Name = "pnlDrugLine"
        Me.pnlDrugLine.Size = New System.Drawing.Size(300, 28)
        Me.pnlDrugLine.TabIndex = 10
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(319, 80)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(133, 20)
        Me.lblNotes.TabIndex = 18
        Me.lblNotes.Text = "Notes"
        '
        'lblWHOStageID
        '
        Me.lblWHOStageID.Location = New System.Drawing.Point(17, 74)
        Me.lblWHOStageID.Name = "lblWHOStageID"
        Me.lblWHOStageID.Size = New System.Drawing.Size(99, 21)
        Me.lblWHOStageID.TabIndex = 8
        Me.lblWHOStageID.Text = "WHO Stage"
        '
        'pnlARTCategory
        '
        Me.pnlARTCategory.Controls.Add(Me.cboARTCategoryID)
        Me.pnlARTCategory.Controls.Add(Me.lblARTCategoryID)
        Me.pnlARTCategory.Location = New System.Drawing.Point(12, 149)
        Me.pnlARTCategory.Name = "pnlARTCategory"
        Me.pnlARTCategory.Size = New System.Drawing.Size(300, 28)
        Me.pnlARTCategory.TabIndex = 13
        '
        'lblARTCategoryID
        '
        Me.lblARTCategoryID.Location = New System.Drawing.Point(5, 3)
        Me.lblARTCategoryID.Name = "lblARTCategoryID"
        Me.lblARTCategoryID.Size = New System.Drawing.Size(99, 21)
        Me.lblARTCategoryID.TabIndex = 0
        Me.lblARTCategoryID.Text = "ART Category"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(104, 6)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'lblRefillDuration
        '
        Me.lblRefillDuration.Location = New System.Drawing.Point(319, 111)
        Me.lblRefillDuration.Name = "lblRefillDuration"
        Me.lblRefillDuration.Size = New System.Drawing.Size(133, 20)
        Me.lblRefillDuration.TabIndex = 20
        Me.lblRefillDuration.Text = "Refill Duration (Days)"
        '
        'lblWhyEligible
        '
        Me.lblWhyEligible.Location = New System.Drawing.Point(20, 195)
        Me.lblWhyEligible.Name = "lblWhyEligible"
        Me.lblWhyEligible.Size = New System.Drawing.Size(78, 21)
        Me.lblWhyEligible.TabIndex = 14
        Me.lblWhyEligible.Text = "Why Eligible"
        Me.lblWhyEligible.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblARTSwitchReasons
        '
        Me.lblARTSwitchReasons.Location = New System.Drawing.Point(319, 26)
        Me.lblARTSwitchReasons.Name = "lblARTSwitchReasons"
        Me.lblARTSwitchReasons.Size = New System.Drawing.Size(133, 20)
        Me.lblARTSwitchReasons.TabIndex = 16
        Me.lblARTSwitchReasons.Text = "ART Switch Reason(s)"
        Me.lblARTSwitchReasons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(257, 4)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'colDrug
        '
        Me.colDrug.DataPropertyName = "DrugFullName"
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.Sorted = True
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 270
        '
        'colDosage
        '
        Me.colDosage.DataPropertyName = "Dosage"
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        '
        'colDuration
        '
        Me.colDuration.DataPropertyName = "Duration"
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 75
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 75
        '
        'colDrugFormula
        '
        Me.colDrugFormula.DataPropertyName = "Formula"
        Me.colDrugFormula.HeaderText = "Notes"
        Me.colDrugFormula.MaxInputLength = 100
        Me.colDrugFormula.Name = "colDrugFormula"
        Me.colDrugFormula.Width = 150
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'frmARTRegimen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(812, 500)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.lblWhyEligible)
        Me.Controls.Add(Me.lblARTSwitchReasons)
        Me.Controls.Add(Me.clbWhyEligible)
        Me.Controls.Add(Me.clbARTSwitchReasons)
        Me.Controls.Add(Me.nbxRefillDuration)
        Me.Controls.Add(Me.lblRefillDuration)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.pnlARTCategory)
        Me.Controls.Add(Me.cboWHOStageID)
        Me.Controls.Add(Me.lblWHOStageID)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.pnlDrugLine)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.cboCombination)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.dgvPrescription)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmARTRegimen"
        Me.Text = "ART Regimen"
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDrugLine.ResumeLayout(False)
        Me.pnlARTCategory.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents cboCombination As System.Windows.Forms.ComboBox
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents cboDrugLinesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDrugLinesID As System.Windows.Forms.Label
    Friend WithEvents pnlDrugLine As System.Windows.Forms.Panel
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents cboWHOStageID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWHOStageID As System.Windows.Forms.Label
    Friend WithEvents pnlARTCategory As System.Windows.Forms.Panel
    Friend WithEvents cboARTCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblARTCategoryID As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents nbxRefillDuration As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefillDuration As System.Windows.Forms.Label
    Friend WithEvents lblWhyEligible As System.Windows.Forms.Label
    Friend WithEvents lblARTSwitchReasons As System.Windows.Forms.Label
    Friend WithEvents clbWhyEligible As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbARTSwitchReasons As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
