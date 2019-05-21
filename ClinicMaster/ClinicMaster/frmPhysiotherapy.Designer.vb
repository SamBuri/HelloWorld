
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhysiotherapy : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhysiotherapy))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbStatusOfJoints = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSensitivity = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbWalkingAnalysis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboOnMedication = New System.Windows.Forms.ComboBox()
        Me.stbMedication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboPain24hrsOrVAS = New System.Windows.Forms.ComboBox()
        Me.cboLevelOfDependenceOrADLS = New System.Windows.Forms.ComboBox()
        Me.stbMuscleStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New System.Windows.Forms.TextBox()
        Me.stbJoinDate = New System.Windows.Forms.TextBox()
        Me.stbGender = New System.Windows.Forms.TextBox()
        Me.stbFullName = New System.Windows.Forms.TextBox()
        Me.stbPatientNo = New System.Windows.Forms.TextBox()
        Me.stbShortTermTreatmentTargets = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLongTermTreatmentTargets = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New System.Windows.Forms.TextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblStatusOfJoints = New System.Windows.Forms.Label()
        Me.lblSensibility = New System.Windows.Forms.Label()
        Me.lblWalkingAnalysis = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tpgPhysiotherapyTreatment = New System.Windows.Forms.TabPage()
        Me.dgvTreatmentPlan = New System.Windows.Forms.DataGridView()
        Me.colCategory = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colTherapyTechnique = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTherapyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhysiotherapyNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhysiotherapyTechniquesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbcPhysiotherapy = New System.Windows.Forms.TabControl()
        Me.tpgExamination = New System.Windows.Forms.TabPage()
        Me.stbTherapyNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTherapyNotes = New System.Windows.Forms.Label()
        Me.lblProvisionalDiagnosis = New System.Windows.Forms.Label()
        Me.stbProvisionalDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadTemplate = New System.Windows.Forms.Button()
        Me.lblOnMedication = New System.Windows.Forms.Label()
        Me.lblMedication = New System.Windows.Forms.Label()
        Me.lblPain24hoursOrVAS = New System.Windows.Forms.Label()
        Me.lblLevelOfDependenceOrADLS = New System.Windows.Forms.Label()
        Me.lblMuscleStatus = New System.Windows.Forms.Label()
        Me.tpgPhysiotherapyDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvPhysiotherapyDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colPhysioDiseaseDiagnosis = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPhysioDiagnosisNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgTreatmentTargets = New System.Windows.Forms.TabPage()
        Me.lblShortTermTreatmentTargets = New System.Windows.Forms.Label()
        Me.lblLongTermTreatmentTargets = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.btnAddConsumables = New System.Windows.Forms.Button()
        Me.btnAddExtraCharge = New System.Windows.Forms.Button()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.tpgPhysiotherapyTreatment.SuspendLayout()
        CType(Me.dgvTreatmentPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcPhysiotherapy.SuspendLayout()
        Me.tpgExamination.SuspendLayout()
        Me.tpgPhysiotherapyDiagnosis.SuspendLayout()
        CType(Me.dgvPhysiotherapyDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgTreatmentTargets.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(21, 343)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(674, 343)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "Physio"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(21, 370)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "Physiotherapy"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbStatusOfJoints
        '
        Me.stbStatusOfJoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatusOfJoints.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbStatusOfJoints, "StatusOfJoints")
        Me.stbStatusOfJoints.EntryErrorMSG = ""
        Me.stbStatusOfJoints.Location = New System.Drawing.Point(191, 129)
        Me.stbStatusOfJoints.Name = "stbStatusOfJoints"
        Me.stbStatusOfJoints.RegularExpression = ""
        Me.stbStatusOfJoints.Size = New System.Drawing.Size(158, 20)
        Me.stbStatusOfJoints.TabIndex = 16
        '
        'stbSensitivity
        '
        Me.stbSensitivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSensitivity.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSensitivity, "Sensibility")
        Me.stbSensitivity.EntryErrorMSG = ""
        Me.stbSensitivity.Location = New System.Drawing.Point(501, 12)
        Me.stbSensitivity.Name = "stbSensitivity"
        Me.stbSensitivity.RegularExpression = ""
        Me.stbSensitivity.Size = New System.Drawing.Size(191, 20)
        Me.stbSensitivity.TabIndex = 18
        '
        'stbWalkingAnalysis
        '
        Me.stbWalkingAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWalkingAnalysis.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbWalkingAnalysis, "WalkingAnalysis")
        Me.stbWalkingAnalysis.EntryErrorMSG = ""
        Me.stbWalkingAnalysis.Location = New System.Drawing.Point(501, 34)
        Me.stbWalkingAnalysis.Multiline = True
        Me.stbWalkingAnalysis.Name = "stbWalkingAnalysis"
        Me.stbWalkingAnalysis.RegularExpression = ""
        Me.stbWalkingAnalysis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbWalkingAnalysis.Size = New System.Drawing.Size(191, 42)
        Me.stbWalkingAnalysis.TabIndex = 20
        '
        'cboOnMedication
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboOnMedication, "OnMedication")
        Me.cboOnMedication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOnMedication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOnMedication.Location = New System.Drawing.Point(212, 8)
        Me.cboOnMedication.Name = "cboOnMedication"
        Me.cboOnMedication.Size = New System.Drawing.Size(137, 21)
        Me.cboOnMedication.TabIndex = 47
        '
        'stbMedication
        '
        Me.stbMedication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedication.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedication, "Medication")
        Me.stbMedication.EntryErrorMSG = ""
        Me.stbMedication.Location = New System.Drawing.Point(191, 32)
        Me.stbMedication.Name = "stbMedication"
        Me.stbMedication.RegularExpression = ""
        Me.stbMedication.Size = New System.Drawing.Size(158, 20)
        Me.stbMedication.TabIndex = 49
        '
        'cboPain24hrsOrVAS
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPain24hrsOrVAS, "Pain24hoursOrVAS")
        Me.cboPain24hrsOrVAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPain24hrsOrVAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPain24hrsOrVAS.Location = New System.Drawing.Point(212, 55)
        Me.cboPain24hrsOrVAS.Name = "cboPain24hrsOrVAS"
        Me.cboPain24hrsOrVAS.Size = New System.Drawing.Size(137, 21)
        Me.cboPain24hrsOrVAS.TabIndex = 51
        '
        'cboLevelOfDependenceOrADLS
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLevelOfDependenceOrADLS, "LevelOfDependenceOrADLS")
        Me.cboLevelOfDependenceOrADLS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLevelOfDependenceOrADLS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLevelOfDependenceOrADLS.Location = New System.Drawing.Point(212, 79)
        Me.cboLevelOfDependenceOrADLS.Name = "cboLevelOfDependenceOrADLS"
        Me.cboLevelOfDependenceOrADLS.Size = New System.Drawing.Size(137, 21)
        Me.cboLevelOfDependenceOrADLS.TabIndex = 53
        '
        'stbMuscleStatus
        '
        Me.stbMuscleStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMuscleStatus.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMuscleStatus, "MuscleStatus")
        Me.stbMuscleStatus.EntryErrorMSG = ""
        Me.stbMuscleStatus.Location = New System.Drawing.Point(191, 106)
        Me.stbMuscleStatus.Name = "stbMuscleStatus"
        Me.stbMuscleStatus.RegularExpression = ""
        Me.stbMuscleStatus.Size = New System.Drawing.Size(158, 20)
        Me.stbMuscleStatus.TabIndex = 55
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.Location = New System.Drawing.Point(476, 17)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(170, 20)
        Me.stbAge.TabIndex = 69
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.Location = New System.Drawing.Point(476, 59)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(170, 20)
        Me.stbJoinDate.TabIndex = 74
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.Location = New System.Drawing.Point(476, 38)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(170, 20)
        Me.stbGender.TabIndex = 71
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.Location = New System.Drawing.Point(154, 57)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.Size = New System.Drawing.Size(170, 20)
        Me.stbFullName.TabIndex = 67
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.Location = New System.Drawing.Point(154, 36)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 60
        '
        'stbShortTermTreatmentTargets
        '
        Me.stbShortTermTreatmentTargets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbShortTermTreatmentTargets.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbShortTermTreatmentTargets, "ShortTermTreatmentTargets")
        Me.stbShortTermTreatmentTargets.EntryErrorMSG = ""
        Me.stbShortTermTreatmentTargets.Location = New System.Drawing.Point(188, 13)
        Me.stbShortTermTreatmentTargets.Multiline = True
        Me.stbShortTermTreatmentTargets.Name = "stbShortTermTreatmentTargets"
        Me.stbShortTermTreatmentTargets.RegularExpression = ""
        Me.stbShortTermTreatmentTargets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbShortTermTreatmentTargets.Size = New System.Drawing.Size(191, 62)
        Me.stbShortTermTreatmentTargets.TabIndex = 26
        '
        'stbLongTermTreatmentTargets
        '
        Me.stbLongTermTreatmentTargets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLongTermTreatmentTargets.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLongTermTreatmentTargets, "ShortTermTreatmentTargets")
        Me.stbLongTermTreatmentTargets.EntryErrorMSG = ""
        Me.stbLongTermTreatmentTargets.Location = New System.Drawing.Point(188, 90)
        Me.stbLongTermTreatmentTargets.Multiline = True
        Me.stbLongTermTreatmentTargets.Name = "stbLongTermTreatmentTargets"
        Me.stbLongTermTreatmentTargets.RegularExpression = ""
        Me.stbLongTermTreatmentTargets.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbLongTermTreatmentTargets.Size = New System.Drawing.Size(191, 62)
        Me.stbLongTermTreatmentTargets.TabIndex = 30
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.Location = New System.Drawing.Point(154, 78)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 78
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(674, 370)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(22, 21)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(78, 20)
        Me.lblVisitNo.TabIndex = 5
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblStatusOfJoints
        '
        Me.lblStatusOfJoints.Location = New System.Drawing.Point(19, 129)
        Me.lblStatusOfJoints.Name = "lblStatusOfJoints"
        Me.lblStatusOfJoints.Size = New System.Drawing.Size(125, 20)
        Me.lblStatusOfJoints.TabIndex = 17
        Me.lblStatusOfJoints.Text = "Status Of Joints"
        '
        'lblSensibility
        '
        Me.lblSensibility.Location = New System.Drawing.Point(369, 12)
        Me.lblSensibility.Name = "lblSensibility"
        Me.lblSensibility.Size = New System.Drawing.Size(128, 20)
        Me.lblSensibility.TabIndex = 19
        Me.lblSensibility.Text = "Sensitivity"
        '
        'lblWalkingAnalysis
        '
        Me.lblWalkingAnalysis.Location = New System.Drawing.Point(369, 34)
        Me.lblWalkingAnalysis.Name = "lblWalkingAnalysis"
        Me.lblWalkingAnalysis.Size = New System.Drawing.Size(128, 20)
        Me.lblWalkingAnalysis.TabIndex = 21
        Me.lblWalkingAnalysis.Text = "Walking Analysis"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(123, 15)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 42
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(268, 11)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(56, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 44
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(154, 15)
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(106, 20)
        Me.stbVisitNo.TabIndex = 43
        '
        'tpgPhysiotherapyTreatment
        '
        Me.tpgPhysiotherapyTreatment.Controls.Add(Me.dgvTreatmentPlan)
        Me.tpgPhysiotherapyTreatment.Location = New System.Drawing.Point(4, 22)
        Me.tpgPhysiotherapyTreatment.Name = "tpgPhysiotherapyTreatment"
        Me.tpgPhysiotherapyTreatment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPhysiotherapyTreatment.Size = New System.Drawing.Size(783, 169)
        Me.tpgPhysiotherapyTreatment.TabIndex = 0
        Me.tpgPhysiotherapyTreatment.Text = "Treatment Plan"
        Me.tpgPhysiotherapyTreatment.UseVisualStyleBackColor = True
        '
        'dgvTreatmentPlan
        '
        Me.dgvTreatmentPlan.AllowUserToOrderColumns = True
        Me.dgvTreatmentPlan.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTreatmentPlan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvTreatmentPlan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCategory, Me.colTherapyTechnique, Me.colTherapyID, Me.colPhysiotherapyNotes, Me.colPhysiotherapyTechniquesSaved})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTreatmentPlan.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvTreatmentPlan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTreatmentPlan.EnableHeadersVisualStyles = False
        Me.dgvTreatmentPlan.GridColor = System.Drawing.Color.Khaki
        Me.dgvTreatmentPlan.Location = New System.Drawing.Point(3, 3)
        Me.dgvTreatmentPlan.Name = "dgvTreatmentPlan"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTreatmentPlan.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvTreatmentPlan.Size = New System.Drawing.Size(777, 163)
        Me.dgvTreatmentPlan.TabIndex = 2
        Me.dgvTreatmentPlan.Text = "DataGridView1"
        '
        'colCategory
        '
        Me.colCategory.DataPropertyName = "Category"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle12
        Me.colCategory.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colCategory.DisplayStyleForCurrentCellOnly = True
        Me.colCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCategory.Frozen = True
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.Width = 150
        '
        'colTherapyTechnique
        '
        Me.colTherapyTechnique.DataPropertyName = "TherapyTechniqueID"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colTherapyTechnique.DefaultCellStyle = DataGridViewCellStyle13
        Me.colTherapyTechnique.Frozen = True
        Me.colTherapyTechnique.HeaderText = "Therapy Technique"
        Me.colTherapyTechnique.Name = "colTherapyTechnique"
        Me.colTherapyTechnique.ReadOnly = True
        Me.colTherapyTechnique.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTherapyTechnique.Width = 140
        '
        'colTherapyID
        '
        Me.colTherapyID.DataPropertyName = "TherapyID"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colTherapyID.DefaultCellStyle = DataGridViewCellStyle14
        Me.colTherapyID.Frozen = True
        Me.colTherapyID.HeaderText = "Therapy ID"
        Me.colTherapyID.Name = "colTherapyID"
        Me.colTherapyID.ReadOnly = True
        '
        'colPhysiotherapyNotes
        '
        Me.colPhysiotherapyNotes.DataPropertyName = "Notes"
        Me.colPhysiotherapyNotes.HeaderText = "Notes"
        Me.colPhysiotherapyNotes.Name = "colPhysiotherapyNotes"
        Me.colPhysiotherapyNotes.Width = 220
        '
        'colPhysiotherapyTechniquesSaved
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.NullValue = False
        Me.colPhysiotherapyTechniquesSaved.DefaultCellStyle = DataGridViewCellStyle15
        Me.colPhysiotherapyTechniquesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPhysiotherapyTechniquesSaved.HeaderText = "Saved"
        Me.colPhysiotherapyTechniquesSaved.Name = "colPhysiotherapyTechniquesSaved"
        Me.colPhysiotherapyTechniquesSaved.ReadOnly = True
        Me.colPhysiotherapyTechniquesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPhysiotherapyTechniquesSaved.Width = 50
        '
        'tbcPhysiotherapy
        '
        Me.tbcPhysiotherapy.Controls.Add(Me.tpgExamination)
        Me.tbcPhysiotherapy.Controls.Add(Me.tpgPhysiotherapyDiagnosis)
        Me.tbcPhysiotherapy.Controls.Add(Me.tpgTreatmentTargets)
        Me.tbcPhysiotherapy.Controls.Add(Me.tpgPhysiotherapyTreatment)
        Me.tbcPhysiotherapy.Location = New System.Drawing.Point(17, 140)
        Me.tbcPhysiotherapy.Name = "tbcPhysiotherapy"
        Me.tbcPhysiotherapy.SelectedIndex = 0
        Me.tbcPhysiotherapy.Size = New System.Drawing.Size(735, 195)
        Me.tbcPhysiotherapy.TabIndex = 45
        '
        'tpgExamination
        '
        Me.tpgExamination.Controls.Add(Me.stbTherapyNotes)
        Me.tpgExamination.Controls.Add(Me.lblTherapyNotes)
        Me.tpgExamination.Controls.Add(Me.lblProvisionalDiagnosis)
        Me.tpgExamination.Controls.Add(Me.stbProvisionalDiagnosis)
        Me.tpgExamination.Controls.Add(Me.btnLoadTemplate)
        Me.tpgExamination.Controls.Add(Me.cboOnMedication)
        Me.tpgExamination.Controls.Add(Me.lblOnMedication)
        Me.tpgExamination.Controls.Add(Me.stbMedication)
        Me.tpgExamination.Controls.Add(Me.lblMedication)
        Me.tpgExamination.Controls.Add(Me.cboPain24hrsOrVAS)
        Me.tpgExamination.Controls.Add(Me.lblPain24hoursOrVAS)
        Me.tpgExamination.Controls.Add(Me.cboLevelOfDependenceOrADLS)
        Me.tpgExamination.Controls.Add(Me.lblLevelOfDependenceOrADLS)
        Me.tpgExamination.Controls.Add(Me.stbWalkingAnalysis)
        Me.tpgExamination.Controls.Add(Me.lblWalkingAnalysis)
        Me.tpgExamination.Controls.Add(Me.stbStatusOfJoints)
        Me.tpgExamination.Controls.Add(Me.stbMuscleStatus)
        Me.tpgExamination.Controls.Add(Me.lblStatusOfJoints)
        Me.tpgExamination.Controls.Add(Me.lblMuscleStatus)
        Me.tpgExamination.Controls.Add(Me.stbSensitivity)
        Me.tpgExamination.Controls.Add(Me.lblSensibility)
        Me.tpgExamination.Location = New System.Drawing.Point(4, 22)
        Me.tpgExamination.Name = "tpgExamination"
        Me.tpgExamination.Size = New System.Drawing.Size(721, 169)
        Me.tpgExamination.TabIndex = 1
        Me.tpgExamination.Text = "Examination"
        Me.tpgExamination.UseVisualStyleBackColor = True
        '
        'stbTherapyNotes
        '
        Me.stbTherapyNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTherapyNotes.CapitalizeFirstLetter = True
        Me.stbTherapyNotes.EntryErrorMSG = ""
        Me.stbTherapyNotes.Location = New System.Drawing.Point(501, 79)
        Me.stbTherapyNotes.MaxLength = 1000
        Me.stbTherapyNotes.Multiline = True
        Me.stbTherapyNotes.Name = "stbTherapyNotes"
        Me.stbTherapyNotes.RegularExpression = ""
        Me.stbTherapyNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTherapyNotes.Size = New System.Drawing.Size(191, 42)
        Me.stbTherapyNotes.TabIndex = 83
        '
        'lblTherapyNotes
        '
        Me.lblTherapyNotes.Location = New System.Drawing.Point(367, 78)
        Me.lblTherapyNotes.Name = "lblTherapyNotes"
        Me.lblTherapyNotes.Size = New System.Drawing.Size(128, 20)
        Me.lblTherapyNotes.TabIndex = 82
        Me.lblTherapyNotes.Text = "Therapy Notes"
        '
        'lblProvisionalDiagnosis
        '
        Me.lblProvisionalDiagnosis.Location = New System.Drawing.Point(369, 120)
        Me.lblProvisionalDiagnosis.Name = "lblProvisionalDiagnosis"
        Me.lblProvisionalDiagnosis.Size = New System.Drawing.Size(128, 22)
        Me.lblProvisionalDiagnosis.TabIndex = 79
        Me.lblProvisionalDiagnosis.Text = "Provisional Diagnosis"
        '
        'stbProvisionalDiagnosis
        '
        Me.stbProvisionalDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalDiagnosis.CapitalizeFirstLetter = True
        Me.stbProvisionalDiagnosis.EntryErrorMSG = ""
        Me.stbProvisionalDiagnosis.Location = New System.Drawing.Point(501, 123)
        Me.stbProvisionalDiagnosis.MaxLength = 1000
        Me.stbProvisionalDiagnosis.Multiline = True
        Me.stbProvisionalDiagnosis.Name = "stbProvisionalDiagnosis"
        Me.stbProvisionalDiagnosis.RegularExpression = ""
        Me.stbProvisionalDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProvisionalDiagnosis.Size = New System.Drawing.Size(191, 40)
        Me.stbProvisionalDiagnosis.TabIndex = 80
        '
        'btnLoadTemplate
        '
        Me.btnLoadTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoadTemplate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoadTemplate.Image = CType(resources.GetObject("btnLoadTemplate.Image"), System.Drawing.Image)
        Me.btnLoadTemplate.Location = New System.Drawing.Point(150, 101)
        Me.btnLoadTemplate.Name = "btnLoadTemplate"
        Me.btnLoadTemplate.Size = New System.Drawing.Size(23, 19)
        Me.btnLoadTemplate.TabIndex = 57
        Me.btnLoadTemplate.UseVisualStyleBackColor = False
        Me.btnLoadTemplate.Visible = False
        '
        'lblOnMedication
        '
        Me.lblOnMedication.Location = New System.Drawing.Point(17, 13)
        Me.lblOnMedication.Name = "lblOnMedication"
        Me.lblOnMedication.Size = New System.Drawing.Size(166, 20)
        Me.lblOnMedication.TabIndex = 48
        Me.lblOnMedication.Text = "On Medication"
        '
        'lblMedication
        '
        Me.lblMedication.Location = New System.Drawing.Point(17, 32)
        Me.lblMedication.Name = "lblMedication"
        Me.lblMedication.Size = New System.Drawing.Size(166, 20)
        Me.lblMedication.TabIndex = 50
        Me.lblMedication.Text = "Medication"
        '
        'lblPain24hoursOrVAS
        '
        Me.lblPain24hoursOrVAS.Location = New System.Drawing.Point(17, 58)
        Me.lblPain24hoursOrVAS.Name = "lblPain24hoursOrVAS"
        Me.lblPain24hoursOrVAS.Size = New System.Drawing.Size(166, 20)
        Me.lblPain24hoursOrVAS.TabIndex = 52
        Me.lblPain24hoursOrVAS.Text = "Pain 24 hours Or VAS"
        '
        'lblLevelOfDependenceOrADLS
        '
        Me.lblLevelOfDependenceOrADLS.Location = New System.Drawing.Point(17, 82)
        Me.lblLevelOfDependenceOrADLS.Name = "lblLevelOfDependenceOrADLS"
        Me.lblLevelOfDependenceOrADLS.Size = New System.Drawing.Size(166, 20)
        Me.lblLevelOfDependenceOrADLS.TabIndex = 54
        Me.lblLevelOfDependenceOrADLS.Text = "Level Of Dependence Or ADLS"
        '
        'lblMuscleStatus
        '
        Me.lblMuscleStatus.Location = New System.Drawing.Point(19, 106)
        Me.lblMuscleStatus.Name = "lblMuscleStatus"
        Me.lblMuscleStatus.Size = New System.Drawing.Size(125, 20)
        Me.lblMuscleStatus.TabIndex = 56
        Me.lblMuscleStatus.Text = "Muscle Status"
        '
        'tpgPhysiotherapyDiagnosis
        '
        Me.tpgPhysiotherapyDiagnosis.Controls.Add(Me.dgvPhysiotherapyDiagnosis)
        Me.tpgPhysiotherapyDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgPhysiotherapyDiagnosis.Name = "tpgPhysiotherapyDiagnosis"
        Me.tpgPhysiotherapyDiagnosis.Size = New System.Drawing.Size(727, 169)
        Me.tpgPhysiotherapyDiagnosis.TabIndex = 3
        Me.tpgPhysiotherapyDiagnosis.Text = "Diagnosis"
        Me.tpgPhysiotherapyDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvPhysiotherapyDiagnosis
        '
        Me.dgvPhysiotherapyDiagnosis.AllowUserToOrderColumns = True
        Me.dgvPhysiotherapyDiagnosis.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPhysiotherapyDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhysiotherapyDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvPhysiotherapyDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPhysioDiseaseDiagnosis, Me.colPhysioDiagnosisNotes, Me.colDiagnosisSaved})
        Me.dgvPhysiotherapyDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvPhysiotherapyDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvPhysiotherapyDiagnosis.Location = New System.Drawing.Point(0, 3)
        Me.dgvPhysiotherapyDiagnosis.Name = "dgvPhysiotherapyDiagnosis"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhysiotherapyDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvPhysiotherapyDiagnosis.Size = New System.Drawing.Size(724, 163)
        Me.dgvPhysiotherapyDiagnosis.TabIndex = 1
        Me.dgvPhysiotherapyDiagnosis.Text = "DataGridView1"
        '
        'colPhysioDiseaseDiagnosis
        '
        Me.colPhysioDiseaseDiagnosis.DisplayStyleForCurrentCellOnly = True
        Me.colPhysioDiseaseDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPhysioDiseaseDiagnosis.HeaderText = "Diagnosis"
        Me.colPhysioDiseaseDiagnosis.Name = "colPhysioDiseaseDiagnosis"
        Me.colPhysioDiseaseDiagnosis.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPhysioDiseaseDiagnosis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPhysioDiseaseDiagnosis.Width = 300
        '
        'colPhysioDiagnosisNotes
        '
        Me.colPhysioDiagnosisNotes.HeaderText = "Notes"
        Me.colPhysioDiagnosisNotes.MaxInputLength = 100
        Me.colPhysioDiagnosisNotes.Name = "colPhysioDiagnosisNotes"
        Me.colPhysioDiagnosisNotes.Width = 250
        '
        'colDiagnosisSaved
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle19.NullValue = False
        Me.colDiagnosisSaved.DefaultCellStyle = DataGridViewCellStyle19
        Me.colDiagnosisSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiagnosisSaved.HeaderText = "Saved"
        Me.colDiagnosisSaved.Name = "colDiagnosisSaved"
        Me.colDiagnosisSaved.ReadOnly = True
        Me.colDiagnosisSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDiagnosisSaved.Width = 50
        '
        'tpgTreatmentTargets
        '
        Me.tpgTreatmentTargets.Controls.Add(Me.stbLongTermTreatmentTargets)
        Me.tpgTreatmentTargets.Controls.Add(Me.stbShortTermTreatmentTargets)
        Me.tpgTreatmentTargets.Controls.Add(Me.lblShortTermTreatmentTargets)
        Me.tpgTreatmentTargets.Controls.Add(Me.lblLongTermTreatmentTargets)
        Me.tpgTreatmentTargets.Location = New System.Drawing.Point(4, 22)
        Me.tpgTreatmentTargets.Name = "tpgTreatmentTargets"
        Me.tpgTreatmentTargets.Size = New System.Drawing.Size(783, 169)
        Me.tpgTreatmentTargets.TabIndex = 2
        Me.tpgTreatmentTargets.Text = "Treatment Targets"
        Me.tpgTreatmentTargets.UseVisualStyleBackColor = True
        '
        'lblShortTermTreatmentTargets
        '
        Me.lblShortTermTreatmentTargets.Location = New System.Drawing.Point(6, 15)
        Me.lblShortTermTreatmentTargets.Name = "lblShortTermTreatmentTargets"
        Me.lblShortTermTreatmentTargets.Size = New System.Drawing.Size(166, 20)
        Me.lblShortTermTreatmentTargets.TabIndex = 27
        Me.lblShortTermTreatmentTargets.Text = "Short Term Treatment Targets"
        '
        'lblLongTermTreatmentTargets
        '
        Me.lblLongTermTreatmentTargets.Location = New System.Drawing.Point(6, 92)
        Me.lblLongTermTreatmentTargets.Name = "lblLongTermTreatmentTargets"
        Me.lblLongTermTreatmentTargets.Size = New System.Drawing.Size(166, 20)
        Me.lblLongTermTreatmentTargets.TabIndex = 29
        Me.lblLongTermTreatmentTargets.Text = "Long Term Treatment Targets"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(344, 61)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(126, 20)
        Me.lblJoinDate.TabIndex = 73
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(344, 19)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(126, 20)
        Me.lblAge.TabIndex = 68
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(344, 39)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(126, 20)
        Me.lblGenderID.TabIndex = 70
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(22, 59)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(126, 20)
        Me.lblName.TabIndex = 66
        Me.lblName.Text = "Patient's Name"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(22, 38)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(126, 20)
        Me.lblPatientNo.TabIndex = 59
        Me.lblPatientNo.Text = "Patient's No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(22, 80)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(126, 20)
        Me.lblVisitDate.TabIndex = 77
        Me.lblVisitDate.Text = "Visit Date"
        '
        'btnAddConsumables
        '
        Me.btnAddConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddConsumables.Location = New System.Drawing.Point(17, 110)
        Me.btnAddConsumables.Name = "btnAddConsumables"
        Me.btnAddConsumables.Size = New System.Drawing.Size(118, 23)
        Me.btnAddConsumables.TabIndex = 79
        Me.btnAddConsumables.Tag = "Consumables"
        Me.btnAddConsumables.Text = "Add &Consumables"
        Me.btnAddConsumables.UseVisualStyleBackColor = True
        '
        'btnAddExtraCharge
        '
        Me.btnAddExtraCharge.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddExtraCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddExtraCharge.Location = New System.Drawing.Point(156, 110)
        Me.btnAddExtraCharge.Name = "btnAddExtraCharge"
        Me.btnAddExtraCharge.Size = New System.Drawing.Size(104, 23)
        Me.btnAddExtraCharge.TabIndex = 80
        Me.btnAddExtraCharge.Tag = "ExtraCharge"
        Me.btnAddExtraCharge.Text = "Add &Extra Charge"
        Me.btnAddExtraCharge.UseVisualStyleBackColor = True
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(652, 17)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 81
        Me.spbPhoto.TabStop = False
        '
        'frmPhysiotherapy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(760, 400)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.btnAddExtraCharge)
        Me.Controls.Add(Me.btnAddConsumables)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.tbcPhysiotherapy)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblVisitNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPhysiotherapy"
        Me.Text = "Physiotherapy"
        Me.tpgPhysiotherapyTreatment.ResumeLayout(False)
        CType(Me.dgvTreatmentPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcPhysiotherapy.ResumeLayout(False)
        Me.tpgExamination.ResumeLayout(False)
        Me.tpgExamination.PerformLayout()
        Me.tpgPhysiotherapyDiagnosis.ResumeLayout(False)
        CType(Me.dgvPhysiotherapyDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgTreatmentTargets.ResumeLayout(False)
        Me.tpgTreatmentTargets.PerformLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbStatusOfJoints As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatusOfJoints As System.Windows.Forms.Label
    Friend WithEvents stbSensitivity As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSensibility As System.Windows.Forms.Label
    Friend WithEvents stbWalkingAnalysis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWalkingAnalysis As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tpgPhysiotherapyTreatment As System.Windows.Forms.TabPage
    Friend WithEvents tbcPhysiotherapy As System.Windows.Forms.TabControl
    Friend WithEvents dgvTreatmentPlan As System.Windows.Forms.DataGridView
    Friend WithEvents tpgExamination As System.Windows.Forms.TabPage
    Friend WithEvents cboOnMedication As System.Windows.Forms.ComboBox
    Friend WithEvents lblOnMedication As System.Windows.Forms.Label
    Friend WithEvents stbMedication As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMedication As System.Windows.Forms.Label
    Friend WithEvents cboPain24hrsOrVAS As System.Windows.Forms.ComboBox
    Friend WithEvents lblPain24hoursOrVAS As System.Windows.Forms.Label
    Friend WithEvents cboLevelOfDependenceOrADLS As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevelOfDependenceOrADLS As System.Windows.Forms.Label
    Friend WithEvents stbMuscleStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMuscleStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As System.Windows.Forms.TextBox
    Friend WithEvents stbJoinDate As System.Windows.Forms.TextBox
    Friend WithEvents stbGender As System.Windows.Forms.TextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As System.Windows.Forms.TextBox
    Friend WithEvents stbPatientNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadTemplate As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As System.Windows.Forms.TextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents tpgTreatmentTargets As System.Windows.Forms.TabPage
    Friend WithEvents stbLongTermTreatmentTargets As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbShortTermTreatmentTargets As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblShortTermTreatmentTargets As System.Windows.Forms.Label
    Friend WithEvents lblLongTermTreatmentTargets As System.Windows.Forms.Label
    Friend WithEvents lblProvisionalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents stbProvisionalDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTherapyNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTherapyNotes As System.Windows.Forms.Label
    Friend WithEvents tpgPhysiotherapyDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvPhysiotherapyDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colPhysioDiseaseDiagnosis As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPhysioDiagnosisNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTherapyTechnique As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTherapyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhysiotherapyNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhysiotherapyTechniquesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnAddConsumables As System.Windows.Forms.Button
    Friend WithEvents btnAddExtraCharge As System.Windows.Forms.Button
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox

End Class