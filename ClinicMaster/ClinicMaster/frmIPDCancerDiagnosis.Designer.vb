
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDCancerDiagnosis : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
    End Sub

    Public Sub New()
        InitializeComponent()
    End Sub


    Public Sub New(ByVal visitNo As String, ByVal staffFullName As String)
        MyClass.New()
        Me.roundNo = visitNo
        Me.doctorFullName = staffFullName
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDCancerDiagnosis))
        Me.tbcDrCancerRoles = New System.Windows.Forms.TabControl()
        Me.tpgDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvCancerDiagnosis = New System.Windows.Forms.DataGridView()
        Me.ColTopology = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCancerDiagnosisCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBasisOfDiagnosis = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColCancerStage = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsDoctor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsDoctorCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDoctorSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDoctorQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillAccountNo = New System.Windows.Forms.Label()
        Me.cboRoundNo = New System.Windows.Forms.ComboBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.dtpRoundDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.stbPackage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.stbTotalIPDDoctorRounds = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalIPDDoctorRounds = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.pnlNavigateRounds = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnLoadRounds = New System.Windows.Forms.Button()
        Me.tbcDrCancerRoles.SuspendLayout()
        Me.tpgDiagnosis.SuspendLayout()
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDoctor.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateRounds.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcDrCancerRoles
        '
        Me.tbcDrCancerRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDrCancerRoles.Controls.Add(Me.tpgDiagnosis)
        Me.tbcDrCancerRoles.HotTrack = True
        Me.tbcDrCancerRoles.Location = New System.Drawing.Point(12, 129)
        Me.tbcDrCancerRoles.Name = "tbcDrCancerRoles"
        Me.tbcDrCancerRoles.SelectedIndex = 0
        Me.tbcDrCancerRoles.Size = New System.Drawing.Size(925, 265)
        Me.tbcDrCancerRoles.TabIndex = 90
        '
        'tpgDiagnosis
        '
        Me.tpgDiagnosis.Controls.Add(Me.dgvCancerDiagnosis)
        Me.tpgDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosis.Name = "tpgDiagnosis"
        Me.tpgDiagnosis.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgDiagnosis.Size = New System.Drawing.Size(917, 239)
        Me.tpgDiagnosis.TabIndex = 6
        Me.tpgDiagnosis.Tag = "Diagnosis"
        Me.tpgDiagnosis.Text = "Diagnosis"
        Me.tpgDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvCancerDiagnosis
        '
        Me.dgvCancerDiagnosis.AllowUserToOrderColumns = True
        Me.dgvCancerDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCancerDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTopology, Me.colDiseaseCode, Me.colCancerDiagnosisCode, Me.colDiseaseCategory, Me.ColBasisOfDiagnosis, Me.ColCancerStage, Me.colNotes, Me.colDiagnosisSaved})
        Me.dgvCancerDiagnosis.ContextMenuStrip = Me.cmsDoctor
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCancerDiagnosis.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCancerDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCancerDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvCancerDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvCancerDiagnosis.Location = New System.Drawing.Point(3, 3)
        Me.dgvCancerDiagnosis.Name = "dgvCancerDiagnosis"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvCancerDiagnosis.Size = New System.Drawing.Size(911, 233)
        Me.dgvCancerDiagnosis.TabIndex = 0
        Me.dgvCancerDiagnosis.Text = "DataGridView1"
        '
        'ColTopology
        '
        Me.ColTopology.DisplayStyleForCurrentCellOnly = True
        Me.ColTopology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColTopology.HeaderText = "Topology / Site"
        Me.ColTopology.Name = "ColTopology"
        Me.ColTopology.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColTopology.Width = 150
        '
        'colDiseaseCode
        '
        Me.colDiseaseCode.DisplayStyleForCurrentCellOnly = True
        Me.colDiseaseCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiseaseCode.HeaderText = "Diagnosis"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDiseaseCode.Width = 200
        '
        'colCancerDiagnosisCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colCancerDiagnosisCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCancerDiagnosisCode.HeaderText = "Code"
        Me.colCancerDiagnosisCode.Name = "colCancerDiagnosisCode"
        Me.colCancerDiagnosisCode.ReadOnly = True
        Me.colCancerDiagnosisCode.Width = 80
        '
        'colDiseaseCategory
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        '
        'ColBasisOfDiagnosis
        '
        Me.ColBasisOfDiagnosis.DisplayStyleForCurrentCellOnly = True
        Me.ColBasisOfDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColBasisOfDiagnosis.HeaderText = "Basis Of Diagnosis"
        Me.ColBasisOfDiagnosis.Name = "ColBasisOfDiagnosis"
        Me.ColBasisOfDiagnosis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColBasisOfDiagnosis.Width = 120
        '
        'ColCancerStage
        '
        Me.ColCancerStage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColCancerStage.HeaderText = "Stage"
        Me.ColCancerStage.Name = "ColCancerStage"
        Me.ColCancerStage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColCancerStage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColCancerStage.Width = 50
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 120
        '
        'colDiagnosisSaved
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.NullValue = False
        Me.colDiagnosisSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDiagnosisSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiagnosisSaved.HeaderText = "Saved"
        Me.colDiagnosisSaved.Name = "colDiagnosisSaved"
        Me.colDiagnosisSaved.ReadOnly = True
        Me.colDiagnosisSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDiagnosisSaved.Width = 50
        '
        'cmsDoctor
        '
        Me.cmsDoctor.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDoctor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsDoctorCopy, Me.cmsDoctorSelectAll, Me.cmsDoctorQuickSearch})
        Me.cmsDoctor.Name = "cmsSearch"
        Me.cmsDoctor.Size = New System.Drawing.Size(144, 70)
        '
        'cmsDoctorCopy
        '
        Me.cmsDoctorCopy.Enabled = False
        Me.cmsDoctorCopy.Image = CType(resources.GetObject("cmsDoctorCopy.Image"), System.Drawing.Image)
        Me.cmsDoctorCopy.Name = "cmsDoctorCopy"
        Me.cmsDoctorCopy.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorCopy.Text = "Copy"
        Me.cmsDoctorCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsDoctorSelectAll
        '
        Me.cmsDoctorSelectAll.Enabled = False
        Me.cmsDoctorSelectAll.Name = "cmsDoctorSelectAll"
        Me.cmsDoctorSelectAll.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorSelectAll.Text = "Select All"
        '
        'cmsDoctorQuickSearch
        '
        Me.cmsDoctorQuickSearch.Image = CType(resources.GetObject("cmsDoctorQuickSearch.Image"), System.Drawing.Image)
        Me.cmsDoctorQuickSearch.Name = "cmsDoctorQuickSearch"
        Me.cmsDoctorQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorQuickSearch.Text = "Quick Search"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(448, 72)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(145, 20)
        Me.stbVisitNo.TabIndex = 136
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(325, 72)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(117, 20)
        Me.lblVisitNo.TabIndex = 135
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(448, 51)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(145, 20)
        Me.stbAdmissionDateTime.TabIndex = 134
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(325, 50)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(117, 20)
        Me.lblAdmissionDateTime.TabIndex = 133
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(448, 94)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(145, 29)
        Me.stbBillCustomerName.TabIndex = 138
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(325, 97)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(117, 20)
        Me.lblBillCustomerName.TabIndex = 137
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(448, 8)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(145, 20)
        Me.stbPatientNo.TabIndex = 130
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(325, 8)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(117, 20)
        Me.lblPatientsNo.TabIndex = 129
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillAccountNo
        '
        Me.stbBillAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillAccountNo.CapitalizeFirstLetter = False
        Me.stbBillAccountNo.Enabled = False
        Me.stbBillAccountNo.EntryErrorMSG = ""
        Me.stbBillAccountNo.Location = New System.Drawing.Point(448, 29)
        Me.stbBillAccountNo.MaxLength = 60
        Me.stbBillAccountNo.Name = "stbBillAccountNo"
        Me.stbBillAccountNo.RegularExpression = ""
        Me.stbBillAccountNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillAccountNo.Size = New System.Drawing.Size(145, 20)
        Me.stbBillAccountNo.TabIndex = 132
        '
        'lblBillAccountNo
        '
        Me.lblBillAccountNo.Location = New System.Drawing.Point(325, 28)
        Me.lblBillAccountNo.Name = "lblBillAccountNo"
        Me.lblBillAccountNo.Size = New System.Drawing.Size(117, 20)
        Me.lblBillAccountNo.TabIndex = 131
        Me.lblBillAccountNo.Text = "To-Bill Account No"
        '
        'cboRoundNo
        '
        Me.cboRoundNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRoundNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoundNo.FormattingEnabled = True
        Me.cboRoundNo.Location = New System.Drawing.Point(146, 4)
        Me.cboRoundNo.MaxLength = 20
        Me.cboRoundNo.Name = "cboRoundNo"
        Me.cboRoundNo.Size = New System.Drawing.Size(115, 21)
        Me.cboRoundNo.TabIndex = 144
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(138, 29)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(176, 20)
        Me.stbAdmissionNo.TabIndex = 141
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(105, 6)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 140
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.Location = New System.Drawing.Point(15, 31)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(84, 20)
        Me.lblAdmissionNo.TabIndex = 139
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(138, 98)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(176, 20)
        Me.stbFullName.TabIndex = 150
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(14, 98)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(111, 20)
        Me.lblFullName.TabIndex = 149
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(16, 9)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(84, 20)
        Me.lblRoundNo.TabIndex = 142
        Me.lblRoundNo.Text = "Round No"
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(138, 52)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(176, 21)
        Me.cboStaffNo.TabIndex = 146
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(14, 55)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(111, 20)
        Me.lblStaffNo.TabIndex = 145
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'dtpRoundDateTime
        '
        Me.dtpRoundDateTime.Checked = False
        Me.dtpRoundDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpRoundDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRoundDateTime.Location = New System.Drawing.Point(138, 75)
        Me.dtpRoundDateTime.Name = "dtpRoundDateTime"
        Me.dtpRoundDateTime.ShowCheckBox = True
        Me.dtpRoundDateTime.Size = New System.Drawing.Size(176, 20)
        Me.dtpRoundDateTime.TabIndex = 148
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(14, 78)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(111, 20)
        Me.lblRoundDateTime.TabIndex = 147
        Me.lblRoundDateTime.Text = "Round Date Time"
        '
        'stbPackage
        '
        Me.stbPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPackage.CapitalizeFirstLetter = False
        Me.stbPackage.Enabled = False
        Me.stbPackage.EntryErrorMSG = ""
        Me.stbPackage.Location = New System.Drawing.Point(676, 115)
        Me.stbPackage.MaxLength = 60
        Me.stbPackage.Name = "stbPackage"
        Me.stbPackage.RegularExpression = ""
        Me.stbPackage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPackage.Size = New System.Drawing.Size(90, 20)
        Me.stbPackage.TabIndex = 163
        '
        'lblPackageName
        '
        Me.lblPackageName.Location = New System.Drawing.Point(603, 115)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(53, 20)
        Me.lblPackageName.TabIndex = 162
        Me.lblPackageName.Text = "Package"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(676, 94)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(90, 20)
        Me.stbAdmissionStatus.TabIndex = 160
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(599, 94)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(71, 20)
        Me.lblAdmissionStatus.TabIndex = 159
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbTotalIPDDoctorRounds
        '
        Me.stbTotalIPDDoctorRounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalIPDDoctorRounds.CapitalizeFirstLetter = False
        Me.stbTotalIPDDoctorRounds.Enabled = False
        Me.stbTotalIPDDoctorRounds.EntryErrorMSG = ""
        Me.stbTotalIPDDoctorRounds.Location = New System.Drawing.Point(676, 73)
        Me.stbTotalIPDDoctorRounds.MaxLength = 60
        Me.stbTotalIPDDoctorRounds.Name = "stbTotalIPDDoctorRounds"
        Me.stbTotalIPDDoctorRounds.RegularExpression = ""
        Me.stbTotalIPDDoctorRounds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalIPDDoctorRounds.Size = New System.Drawing.Size(90, 20)
        Me.stbTotalIPDDoctorRounds.TabIndex = 158
        '
        'lblTotalIPDDoctorRounds
        '
        Me.lblTotalIPDDoctorRounds.Location = New System.Drawing.Point(599, 73)
        Me.lblTotalIPDDoctorRounds.Name = "lblTotalIPDDoctorRounds"
        Me.lblTotalIPDDoctorRounds.Size = New System.Drawing.Size(71, 20)
        Me.lblTotalIPDDoctorRounds.TabIndex = 157
        Me.lblTotalIPDDoctorRounds.Text = "Total Rounds"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(774, 11)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 161
        Me.spbPhoto.TabStop = False
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(676, 52)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(90, 20)
        Me.stbBillMode.TabIndex = 156
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(599, 54)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(71, 20)
        Me.lblBillMode.TabIndex = 155
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(676, 10)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(90, 20)
        Me.stbAge.TabIndex = 152
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(676, 31)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(90, 20)
        Me.stbGender.TabIndex = 154
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(599, 10)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(71, 20)
        Me.lblAge.TabIndex = 151
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(599, 31)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(71, 20)
        Me.lblGenderID.TabIndex = 153
        Me.lblGenderID.Text = "Gender"
        '
        'pnlNavigateRounds
        '
        Me.pnlNavigateRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateRounds.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateRounds.Controls.Add(Me.navVisits)
        Me.pnlNavigateRounds.Location = New System.Drawing.Point(108, 400)
        Me.pnlNavigateRounds.Name = "pnlNavigateRounds"
        Me.pnlNavigateRounds.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateRounds.TabIndex = 165
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateVisits.Name = "chkNavigateVisits"
        Me.chkNavigateVisits.Size = New System.Drawing.Size(144, 20)
        Me.chkNavigateVisits.TabIndex = 0
        Me.chkNavigateVisits.Text = "Navigate Patient Visits"
        '
        'navVisits
        '
        Me.navVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navVisits.ColumnName = "VisitNo"
        Me.navVisits.DataSource = Nothing
        Me.navVisits.Location = New System.Drawing.Point(171, 2)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(806, 402)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(59, 24)
        Me.btnPrint.TabIndex = 167
        Me.btnPrint.Text = "&Print"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(745, 402)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 24)
        Me.btnDelete.TabIndex = 166
        Me.btnDelete.Tag = "ClinicalFindings"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(11, 400)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(57, 24)
        Me.btnSave.TabIndex = 164
        Me.btnSave.Tag = ""
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(871, 402)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 24)
        Me.btnClose.TabIndex = 168
        Me.btnClose.Text = "&Close"
        '
        'btnLoadRounds
        '
        Me.btnLoadRounds.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadRounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadRounds.Location = New System.Drawing.Point(265, 4)
        Me.btnLoadRounds.Name = "btnLoadRounds"
        Me.btnLoadRounds.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadRounds.TabIndex = 169
        Me.btnLoadRounds.Tag = ""
        Me.btnLoadRounds.Text = "&Load"
        '
        'frmIPDCancerDiagnosis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(941, 438)
        Me.Controls.Add(Me.btnLoadRounds)
        Me.Controls.Add(Me.pnlNavigateRounds)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.stbPackage)
        Me.Controls.Add(Me.lblPackageName)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.stbTotalIPDDoctorRounds)
        Me.Controls.Add(Me.lblTotalIPDDoctorRounds)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.cboRoundNo)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.dtpRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillAccountNo)
        Me.Controls.Add(Me.lblBillAccountNo)
        Me.Controls.Add(Me.tbcDrCancerRoles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmIPDCancerDiagnosis"
        Me.Text = "IPD Cancer Diagnosis"
        Me.tbcDrCancerRoles.ResumeLayout(False)
        Me.tpgDiagnosis.ResumeLayout(False)
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDoctor.ResumeLayout(False)
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateRounds.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub

    Friend WithEvents tbcDrCancerRoles As System.Windows.Forms.TabControl
    Friend WithEvents tpgDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvCancerDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents ColTopology As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDiseaseCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCancerDiagnosisCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBasisOfDiagnosis As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColCancerStage As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillAccountNo As System.Windows.Forms.Label
    Friend WithEvents cboRoundNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents dtpRoundDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents stbPackage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents stbTotalIPDDoctorRounds As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalIPDDoctorRounds As System.Windows.Forms.Label
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents pnlNavigateRounds As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnLoadRounds As System.Windows.Forms.Button
    Friend WithEvents cmsDoctor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsDoctorCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDoctorSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDoctorQuickSearch As System.Windows.Forms.ToolStripMenuItem

End Class