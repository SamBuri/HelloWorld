
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOccupationalTherapy : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOccupationalTherapy))
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboSightID = New System.Windows.Forms.ComboBox()
        Me.cboTasteID = New System.Windows.Forms.ComboBox()
        Me.cboPainID = New System.Windows.Forms.ComboBox()
        Me.cboVestibularID = New System.Windows.Forms.ComboBox()
        Me.cboTemperatureAndPressureID = New System.Windows.Forms.ComboBox()
        Me.cboTouchID = New System.Windows.Forms.ComboBox()
        Me.cboSmellID = New System.Windows.Forms.ComboBox()
        Me.cboHearingID = New System.Windows.Forms.ComboBox()
        Me.cboThoughtID = New System.Windows.Forms.ComboBox()
        Me.cboMemoryID = New System.Windows.Forms.ComboBox()
        Me.cboPerceptionID = New System.Windows.Forms.ComboBox()
        Me.cboAttentionID = New System.Windows.Forms.ComboBox()
        Me.cboImpulseControlID = New System.Windows.Forms.ComboBox()
        Me.cboSleepID = New System.Windows.Forms.ComboBox()
        Me.cboCognitionID = New System.Windows.Forms.ComboBox()
        Me.cboWorkPlaySchoolID = New System.Windows.Forms.ComboBox()
        Me.cboLeisureID = New System.Windows.Forms.ComboBox()
        Me.cboCommunicationID = New System.Windows.Forms.ComboBox()
        Me.cboFeedingID = New System.Windows.Forms.ComboBox()
        Me.cboGroomingID = New System.Windows.Forms.ComboBox()
        Me.cboMealPreparationID = New System.Windows.Forms.ComboBox()
        Me.cboHandFunctionID = New System.Windows.Forms.ComboBox()
        Me.cboWashingID = New System.Windows.Forms.ComboBox()
        Me.cboDressingID = New System.Windows.Forms.ComboBox()
        Me.cboWalkingID = New System.Windows.Forms.ComboBox()
        Me.cboSitStandTransfersID = New System.Windows.Forms.ComboBox()
        Me.cboBathingID = New System.Windows.Forms.ComboBox()
        Me.cboToiletingID = New System.Windows.Forms.ComboBox()
        Me.chkHealthEducation = New System.Windows.Forms.CheckBox()
        Me.chkTherapeuticGroupActivities = New System.Windows.Forms.CheckBox()
        Me.chkCognitiveAssessment = New System.Windows.Forms.CheckBox()
        Me.chkHandTherapy = New System.Windows.Forms.CheckBox()
        Me.chkHomebasedRehabilitation = New System.Windows.Forms.CheckBox()
        Me.chkAssistiveDevices = New System.Windows.Forms.CheckBox()
        Me.chkMobilitySkillsTraining = New System.Windows.Forms.CheckBox()
        Me.chkNeurocognitiveRehabilitation = New System.Windows.Forms.CheckBox()
        Me.chkOrientationTechniques = New System.Windows.Forms.CheckBox()
        Me.chkVocationalRehabilitation = New System.Windows.Forms.CheckBox()
        Me.stbOtherAssessment = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboLeadTherapist = New System.Windows.Forms.ComboBox()
        Me.cboInterventionType = New System.Windows.Forms.ComboBox()
        Me.chkStressManagement = New System.Windows.Forms.CheckBox()
        Me.chkPlayTherapy = New System.Windows.Forms.CheckBox()
        Me.chkSelfCareTraining = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcOccupationalTherapy = New System.Windows.Forms.TabControl()
        Me.tpgOTEvaluation = New System.Windows.Forms.TabPage()
        Me.grpADL = New System.Windows.Forms.GroupBox()
        Me.lblWalkingID = New System.Windows.Forms.Label()
        Me.lblSitStandTransfersID = New System.Windows.Forms.Label()
        Me.lblBathingID = New System.Windows.Forms.Label()
        Me.lblToiletingID = New System.Windows.Forms.Label()
        Me.lblHandFunctionID = New System.Windows.Forms.Label()
        Me.lblWashingID = New System.Windows.Forms.Label()
        Me.lblDressingID = New System.Windows.Forms.Label()
        Me.lblFeedingID = New System.Windows.Forms.Label()
        Me.lblGroomingID = New System.Windows.Forms.Label()
        Me.lblMealPreparationID = New System.Windows.Forms.Label()
        Me.lblWorkPlaySchoolID = New System.Windows.Forms.Label()
        Me.lblLeisureID = New System.Windows.Forms.Label()
        Me.lblCommunicationID = New System.Windows.Forms.Label()
        Me.grpMentalFunctions = New System.Windows.Forms.GroupBox()
        Me.lblCognitionID = New System.Windows.Forms.Label()
        Me.lblAttentionID = New System.Windows.Forms.Label()
        Me.lblImpulseControlID = New System.Windows.Forms.Label()
        Me.lblSleepID = New System.Windows.Forms.Label()
        Me.lblThoughtID = New System.Windows.Forms.Label()
        Me.lblMemoryID = New System.Windows.Forms.Label()
        Me.lblPerceptionID = New System.Windows.Forms.Label()
        Me.grpSensoryFunctions = New System.Windows.Forms.GroupBox()
        Me.lblTouchID = New System.Windows.Forms.Label()
        Me.lblSmellID = New System.Windows.Forms.Label()
        Me.lblHearingID = New System.Windows.Forms.Label()
        Me.lblPainID = New System.Windows.Forms.Label()
        Me.lblVestibularID = New System.Windows.Forms.Label()
        Me.lblTemperatureAndPressureID = New System.Windows.Forms.Label()
        Me.lblSightID = New System.Windows.Forms.Label()
        Me.lblTasteID = New System.Windows.Forms.Label()
        Me.tpgIntervention = New System.Windows.Forms.TabPage()
        Me.grpOTInterventionActivities = New System.Windows.Forms.GroupBox()
        Me.lblOtherAssessment = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.FlatButton1 = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSave = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadOTVisits = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblTherapist = New System.Windows.Forms.Label()
        Me.lblInterventionType = New System.Windows.Forms.Label()
        Me.tbcOccupationalTherapy.SuspendLayout()
        Me.tpgOTEvaluation.SuspendLayout()
        Me.grpADL.SuspendLayout()
        Me.grpMentalFunctions.SuspendLayout()
        Me.grpSensoryFunctions.SuspendLayout()
        Me.tpgIntervention.SuspendLayout()
        Me.grpOTInterventionActivities.SuspendLayout()
        Me.pnlVisitNo.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlerts.SuspendLayout()
        Me.SuspendLayout()
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 759)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "OccupationalTherapy"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboSightID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSightID, "Sight,SightID")
        Me.cboSightID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSightID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSightID.Location = New System.Drawing.Point(193, 13)
        Me.cboSightID.Name = "cboSightID"
        Me.cboSightID.Size = New System.Drawing.Size(150, 21)
        Me.cboSightID.TabIndex = 78
        '
        'cboTasteID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTasteID, "Taste,TasteID")
        Me.cboTasteID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTasteID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTasteID.Location = New System.Drawing.Point(193, 34)
        Me.cboTasteID.Name = "cboTasteID"
        Me.cboTasteID.Size = New System.Drawing.Size(150, 21)
        Me.cboTasteID.TabIndex = 80
        '
        'cboPainID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPainID, "Pain,PainID")
        Me.cboPainID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPainID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPainID.Location = New System.Drawing.Point(193, 117)
        Me.cboPainID.Name = "cboPainID"
        Me.cboPainID.Size = New System.Drawing.Size(150, 21)
        Me.cboPainID.TabIndex = 102
        '
        'cboVestibularID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVestibularID, "Vestibular,VestibularID")
        Me.cboVestibularID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVestibularID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVestibularID.Location = New System.Drawing.Point(193, 138)
        Me.cboVestibularID.Name = "cboVestibularID"
        Me.cboVestibularID.Size = New System.Drawing.Size(150, 21)
        Me.cboVestibularID.TabIndex = 104
        '
        'cboTemperatureAndPressureID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTemperatureAndPressureID, "TemperatureAndPressure,TemperatureAndPressureID")
        Me.cboTemperatureAndPressureID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemperatureAndPressureID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTemperatureAndPressureID.Location = New System.Drawing.Point(193, 158)
        Me.cboTemperatureAndPressureID.Name = "cboTemperatureAndPressureID"
        Me.cboTemperatureAndPressureID.Size = New System.Drawing.Size(150, 21)
        Me.cboTemperatureAndPressureID.TabIndex = 106
        '
        'cboTouchID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTouchID, "Touch,TouchID")
        Me.cboTouchID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTouchID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTouchID.Location = New System.Drawing.Point(193, 76)
        Me.cboTouchID.Name = "cboTouchID"
        Me.cboTouchID.Size = New System.Drawing.Size(150, 21)
        Me.cboTouchID.TabIndex = 110
        '
        'cboSmellID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSmellID, "Smell,SmellID")
        Me.cboSmellID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmellID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSmellID.Location = New System.Drawing.Point(193, 96)
        Me.cboSmellID.Name = "cboSmellID"
        Me.cboSmellID.Size = New System.Drawing.Size(150, 21)
        Me.cboSmellID.TabIndex = 112
        '
        'cboHearingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHearingID, "Hearing,HearingID")
        Me.cboHearingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHearingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHearingID.Location = New System.Drawing.Point(193, 55)
        Me.cboHearingID.Name = "cboHearingID"
        Me.cboHearingID.Size = New System.Drawing.Size(150, 21)
        Me.cboHearingID.TabIndex = 108
        '
        'cboThoughtID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboThoughtID, "Thought,ThoughtID")
        Me.cboThoughtID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboThoughtID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboThoughtID.Location = New System.Drawing.Point(195, 139)
        Me.cboThoughtID.Name = "cboThoughtID"
        Me.cboThoughtID.Size = New System.Drawing.Size(150, 21)
        Me.cboThoughtID.TabIndex = 82
        '
        'cboMemoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMemoryID, "Memory,MemoryID")
        Me.cboMemoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMemoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMemoryID.Location = New System.Drawing.Point(195, 97)
        Me.cboMemoryID.Name = "cboMemoryID"
        Me.cboMemoryID.Size = New System.Drawing.Size(150, 21)
        Me.cboMemoryID.TabIndex = 78
        '
        'cboPerceptionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPerceptionID, "Perception,PerceptionID")
        Me.cboPerceptionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPerceptionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPerceptionID.Location = New System.Drawing.Point(195, 118)
        Me.cboPerceptionID.Name = "cboPerceptionID"
        Me.cboPerceptionID.Size = New System.Drawing.Size(150, 21)
        Me.cboPerceptionID.TabIndex = 80
        '
        'cboAttentionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAttentionID, "Attention,AttentionID")
        Me.cboAttentionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttentionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAttentionID.Location = New System.Drawing.Point(195, 36)
        Me.cboAttentionID.Name = "cboAttentionID"
        Me.cboAttentionID.Size = New System.Drawing.Size(150, 21)
        Me.cboAttentionID.TabIndex = 84
        '
        'cboImpulseControlID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboImpulseControlID, "ImpulseControl,ImpulseControlID")
        Me.cboImpulseControlID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImpulseControlID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboImpulseControlID.Location = New System.Drawing.Point(195, 56)
        Me.cboImpulseControlID.Name = "cboImpulseControlID"
        Me.cboImpulseControlID.Size = New System.Drawing.Size(150, 21)
        Me.cboImpulseControlID.TabIndex = 86
        '
        'cboSleepID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSleepID, "Sleep,SleepID")
        Me.cboSleepID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSleepID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSleepID.Location = New System.Drawing.Point(195, 77)
        Me.cboSleepID.Name = "cboSleepID"
        Me.cboSleepID.Size = New System.Drawing.Size(150, 21)
        Me.cboSleepID.TabIndex = 88
        '
        'cboCognitionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCognitionID, "Cognition,CognitionID")
        Me.cboCognitionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCognitionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCognitionID.Location = New System.Drawing.Point(193, 16)
        Me.cboCognitionID.Name = "cboCognitionID"
        Me.cboCognitionID.Size = New System.Drawing.Size(152, 21)
        Me.cboCognitionID.TabIndex = 92
        '
        'cboWorkPlaySchoolID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWorkPlaySchoolID, "WorkPlaySchool,WorkPlaySchoolID")
        Me.cboWorkPlaySchoolID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWorkPlaySchoolID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWorkPlaySchoolID.Location = New System.Drawing.Point(155, 227)
        Me.cboWorkPlaySchoolID.Name = "cboWorkPlaySchoolID"
        Me.cboWorkPlaySchoolID.Size = New System.Drawing.Size(186, 21)
        Me.cboWorkPlaySchoolID.TabIndex = 90
        '
        'cboLeisureID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLeisureID, "Leisure,LeisureID")
        Me.cboLeisureID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeisureID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLeisureID.Location = New System.Drawing.Point(155, 248)
        Me.cboLeisureID.Name = "cboLeisureID"
        Me.cboLeisureID.Size = New System.Drawing.Size(186, 21)
        Me.cboLeisureID.TabIndex = 92
        '
        'cboCommunicationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCommunicationID, "Communication,CommunicationID")
        Me.cboCommunicationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommunicationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCommunicationID.Location = New System.Drawing.Point(155, 269)
        Me.cboCommunicationID.Name = "cboCommunicationID"
        Me.cboCommunicationID.Size = New System.Drawing.Size(186, 21)
        Me.cboCommunicationID.TabIndex = 94
        '
        'cboFeedingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFeedingID, "Feeding,FeedingID")
        Me.cboFeedingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeedingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFeedingID.Location = New System.Drawing.Point(155, 165)
        Me.cboFeedingID.Name = "cboFeedingID"
        Me.cboFeedingID.Size = New System.Drawing.Size(186, 21)
        Me.cboFeedingID.TabIndex = 96
        '
        'cboGroomingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGroomingID, "Grooming,GroomingID")
        Me.cboGroomingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroomingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGroomingID.Location = New System.Drawing.Point(155, 186)
        Me.cboGroomingID.Name = "cboGroomingID"
        Me.cboGroomingID.Size = New System.Drawing.Size(186, 21)
        Me.cboGroomingID.TabIndex = 98
        '
        'cboMealPreparationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMealPreparationID, "MealPreparation,MealPreparationID")
        Me.cboMealPreparationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMealPreparationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMealPreparationID.Location = New System.Drawing.Point(155, 207)
        Me.cboMealPreparationID.Name = "cboMealPreparationID"
        Me.cboMealPreparationID.Size = New System.Drawing.Size(186, 21)
        Me.cboMealPreparationID.TabIndex = 100
        '
        'cboHandFunctionID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHandFunctionID, "HandFunction,HandFunctionID")
        Me.cboHandFunctionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHandFunctionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHandFunctionID.Location = New System.Drawing.Point(155, 123)
        Me.cboHandFunctionID.Name = "cboHandFunctionID"
        Me.cboHandFunctionID.Size = New System.Drawing.Size(186, 21)
        Me.cboHandFunctionID.TabIndex = 104
        '
        'cboWashingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWashingID, "Washing,WashingID")
        Me.cboWashingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWashingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWashingID.Location = New System.Drawing.Point(155, 144)
        Me.cboWashingID.Name = "cboWashingID"
        Me.cboWashingID.Size = New System.Drawing.Size(186, 21)
        Me.cboWashingID.TabIndex = 106
        '
        'cboDressingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDressingID, "Dressing,DressingID")
        Me.cboDressingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDressingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDressingID.Location = New System.Drawing.Point(155, 101)
        Me.cboDressingID.Name = "cboDressingID"
        Me.cboDressingID.Size = New System.Drawing.Size(186, 21)
        Me.cboDressingID.TabIndex = 102
        '
        'cboWalkingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWalkingID, "Walking,WalkingID")
        Me.cboWalkingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWalkingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWalkingID.Location = New System.Drawing.Point(155, 19)
        Me.cboWalkingID.Name = "cboWalkingID"
        Me.cboWalkingID.Size = New System.Drawing.Size(186, 21)
        Me.cboWalkingID.TabIndex = 108
        '
        'cboSitStandTransfersID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSitStandTransfersID, "SitStandTransfers,SitStandTransfersID")
        Me.cboSitStandTransfersID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSitStandTransfersID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSitStandTransfersID.Location = New System.Drawing.Point(155, 39)
        Me.cboSitStandTransfersID.Name = "cboSitStandTransfersID"
        Me.cboSitStandTransfersID.Size = New System.Drawing.Size(186, 21)
        Me.cboSitStandTransfersID.TabIndex = 110
        '
        'cboBathingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBathingID, "Bathing,BathingID")
        Me.cboBathingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBathingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBathingID.Location = New System.Drawing.Point(155, 59)
        Me.cboBathingID.Name = "cboBathingID"
        Me.cboBathingID.Size = New System.Drawing.Size(186, 21)
        Me.cboBathingID.TabIndex = 112
        '
        'cboToiletingID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboToiletingID, "Toileting,ToiletingID")
        Me.cboToiletingID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboToiletingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboToiletingID.Location = New System.Drawing.Point(155, 80)
        Me.cboToiletingID.Name = "cboToiletingID"
        Me.cboToiletingID.Size = New System.Drawing.Size(186, 21)
        Me.cboToiletingID.TabIndex = 114
        '
        'chkHealthEducation
        '
        Me.chkHealthEducation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHealthEducation, "HealthEducation")
        Me.chkHealthEducation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHealthEducation.Location = New System.Drawing.Point(17, 66)
        Me.chkHealthEducation.Name = "chkHealthEducation"
        Me.chkHealthEducation.Size = New System.Drawing.Size(266, 20)
        Me.chkHealthEducation.TabIndex = 28
        Me.chkHealthEducation.Text = "Health Education"
        '
        'chkTherapeuticGroupActivities
        '
        Me.chkTherapeuticGroupActivities.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkTherapeuticGroupActivities, "TherapeuticGroupActivities")
        Me.chkTherapeuticGroupActivities.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTherapeuticGroupActivities.Location = New System.Drawing.Point(17, 89)
        Me.chkTherapeuticGroupActivities.Name = "chkTherapeuticGroupActivities"
        Me.chkTherapeuticGroupActivities.Size = New System.Drawing.Size(266, 20)
        Me.chkTherapeuticGroupActivities.TabIndex = 29
        Me.chkTherapeuticGroupActivities.Text = "Therapeutic Group Activities"
        '
        'chkCognitiveAssessment
        '
        Me.chkCognitiveAssessment.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkCognitiveAssessment, "CognitiveAssessment")
        Me.chkCognitiveAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCognitiveAssessment.Location = New System.Drawing.Point(17, 20)
        Me.chkCognitiveAssessment.Name = "chkCognitiveAssessment"
        Me.chkCognitiveAssessment.Size = New System.Drawing.Size(266, 20)
        Me.chkCognitiveAssessment.TabIndex = 26
        Me.chkCognitiveAssessment.Text = "Cognitive Assessment"
        '
        'chkHandTherapy
        '
        Me.chkHandTherapy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHandTherapy, "HandTherapy")
        Me.chkHandTherapy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHandTherapy.Location = New System.Drawing.Point(17, 43)
        Me.chkHandTherapy.Name = "chkHandTherapy"
        Me.chkHandTherapy.Size = New System.Drawing.Size(266, 20)
        Me.chkHandTherapy.TabIndex = 27
        Me.chkHandTherapy.Text = "Hand Therapy"
        '
        'chkHomebasedRehabilitation
        '
        Me.chkHomebasedRehabilitation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHomebasedRehabilitation, "HomebasedRehabilitation")
        Me.chkHomebasedRehabilitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHomebasedRehabilitation.Location = New System.Drawing.Point(17, 113)
        Me.chkHomebasedRehabilitation.Name = "chkHomebasedRehabilitation"
        Me.chkHomebasedRehabilitation.Size = New System.Drawing.Size(266, 20)
        Me.chkHomebasedRehabilitation.TabIndex = 30
        Me.chkHomebasedRehabilitation.Text = "Homebased Rehabilitation"
        '
        'chkAssistiveDevices
        '
        Me.chkAssistiveDevices.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkAssistiveDevices, "AssistiveDevices")
        Me.chkAssistiveDevices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAssistiveDevices.Location = New System.Drawing.Point(17, 136)
        Me.chkAssistiveDevices.Name = "chkAssistiveDevices"
        Me.chkAssistiveDevices.Size = New System.Drawing.Size(266, 20)
        Me.chkAssistiveDevices.TabIndex = 31
        Me.chkAssistiveDevices.Text = "Assistive Devices"
        '
        'chkMobilitySkillsTraining
        '
        Me.chkMobilitySkillsTraining.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkMobilitySkillsTraining, "MobilitySkillsTraining")
        Me.chkMobilitySkillsTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMobilitySkillsTraining.Location = New System.Drawing.Point(17, 159)
        Me.chkMobilitySkillsTraining.Name = "chkMobilitySkillsTraining"
        Me.chkMobilitySkillsTraining.Size = New System.Drawing.Size(266, 20)
        Me.chkMobilitySkillsTraining.TabIndex = 32
        Me.chkMobilitySkillsTraining.Text = "Mobility Skills Training"
        '
        'chkNeurocognitiveRehabilitation
        '
        Me.chkNeurocognitiveRehabilitation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkNeurocognitiveRehabilitation, "NeurocognitiveRehabilitation")
        Me.chkNeurocognitiveRehabilitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNeurocognitiveRehabilitation.Location = New System.Drawing.Point(17, 182)
        Me.chkNeurocognitiveRehabilitation.Name = "chkNeurocognitiveRehabilitation"
        Me.chkNeurocognitiveRehabilitation.Size = New System.Drawing.Size(266, 20)
        Me.chkNeurocognitiveRehabilitation.TabIndex = 33
        Me.chkNeurocognitiveRehabilitation.Text = "Neurocognitive Rehabilitation"
        '
        'chkOrientationTechniques
        '
        Me.chkOrientationTechniques.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkOrientationTechniques, "OrientationTechniques")
        Me.chkOrientationTechniques.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOrientationTechniques.Location = New System.Drawing.Point(17, 205)
        Me.chkOrientationTechniques.Name = "chkOrientationTechniques"
        Me.chkOrientationTechniques.Size = New System.Drawing.Size(266, 20)
        Me.chkOrientationTechniques.TabIndex = 34
        Me.chkOrientationTechniques.Text = "Orientation Techniques"
        '
        'chkVocationalRehabilitation
        '
        Me.chkVocationalRehabilitation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkVocationalRehabilitation, "VocationalRehabilitation")
        Me.chkVocationalRehabilitation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVocationalRehabilitation.Location = New System.Drawing.Point(17, 227)
        Me.chkVocationalRehabilitation.Name = "chkVocationalRehabilitation"
        Me.chkVocationalRehabilitation.Size = New System.Drawing.Size(266, 20)
        Me.chkVocationalRehabilitation.TabIndex = 35
        Me.chkVocationalRehabilitation.Text = "Vocational Rehabilitation"
        '
        'stbOtherAssessment
        '
        Me.stbOtherAssessment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherAssessment.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbOtherAssessment, "OtherAssessment")
        Me.stbOtherAssessment.EntryErrorMSG = ""
        Me.stbOtherAssessment.Location = New System.Drawing.Point(454, 22)
        Me.stbOtherAssessment.Multiline = True
        Me.stbOtherAssessment.Name = "stbOtherAssessment"
        Me.stbOtherAssessment.RegularExpression = ""
        Me.stbOtherAssessment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbOtherAssessment.Size = New System.Drawing.Size(277, 41)
        Me.stbOtherAssessment.TabIndex = 39
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(454, 67)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbNotes.Size = New System.Drawing.Size(277, 59)
        Me.stbNotes.TabIndex = 41
        '
        'cboLeadTherapist
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLeadTherapist, "TherapistFullName")
        Me.cboLeadTherapist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeadTherapist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLeadTherapist.Location = New System.Drawing.Point(112, 43)
        Me.cboLeadTherapist.Name = "cboLeadTherapist"
        Me.cboLeadTherapist.Size = New System.Drawing.Size(176, 21)
        Me.cboLeadTherapist.TabIndex = 125
        '
        'cboInterventionType
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboInterventionType, "ReferedBy")
        Me.cboInterventionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInterventionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInterventionType.Location = New System.Drawing.Point(112, 67)
        Me.cboInterventionType.Name = "cboInterventionType"
        Me.cboInterventionType.Size = New System.Drawing.Size(176, 21)
        Me.cboInterventionType.TabIndex = 127
        '
        'chkStressManagement
        '
        Me.chkStressManagement.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkStressManagement, "StressManagement")
        Me.chkStressManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkStressManagement.Location = New System.Drawing.Point(17, 295)
        Me.chkStressManagement.Name = "chkStressManagement"
        Me.chkStressManagement.Size = New System.Drawing.Size(266, 20)
        Me.chkStressManagement.TabIndex = 38
        Me.chkStressManagement.Text = "Stress Management"
        '
        'chkPlayTherapy
        '
        Me.chkPlayTherapy.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkPlayTherapy, "PlayTherapy")
        Me.chkPlayTherapy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPlayTherapy.Location = New System.Drawing.Point(17, 272)
        Me.chkPlayTherapy.Name = "chkPlayTherapy"
        Me.chkPlayTherapy.Size = New System.Drawing.Size(266, 20)
        Me.chkPlayTherapy.TabIndex = 37
        Me.chkPlayTherapy.Text = "Play Therapy"
        '
        'chkSelfCareTraining
        '
        Me.chkSelfCareTraining.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkSelfCareTraining, "SelfCareTraining")
        Me.chkSelfCareTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSelfCareTraining.Location = New System.Drawing.Point(17, 249)
        Me.chkSelfCareTraining.Name = "chkSelfCareTraining"
        Me.chkSelfCareTraining.Size = New System.Drawing.Size(266, 20)
        Me.chkSelfCareTraining.TabIndex = 36
        Me.chkSelfCareTraining.Text = "Self Care Training"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 759)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'tbcOccupationalTherapy
        '
        Me.tbcOccupationalTherapy.Controls.Add(Me.tpgOTEvaluation)
        Me.tbcOccupationalTherapy.Controls.Add(Me.tpgIntervention)
        Me.tbcOccupationalTherapy.Location = New System.Drawing.Point(12, 113)
        Me.tbcOccupationalTherapy.Name = "tbcOccupationalTherapy"
        Me.tbcOccupationalTherapy.SelectedIndex = 0
        Me.tbcOccupationalTherapy.Size = New System.Drawing.Size(864, 414)
        Me.tbcOccupationalTherapy.TabIndex = 66
        '
        'tpgOTEvaluation
        '
        Me.tpgOTEvaluation.Controls.Add(Me.grpADL)
        Me.tpgOTEvaluation.Controls.Add(Me.grpMentalFunctions)
        Me.tpgOTEvaluation.Controls.Add(Me.grpSensoryFunctions)
        Me.tpgOTEvaluation.Location = New System.Drawing.Point(4, 22)
        Me.tpgOTEvaluation.Name = "tpgOTEvaluation"
        Me.tpgOTEvaluation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOTEvaluation.Size = New System.Drawing.Size(856, 388)
        Me.tpgOTEvaluation.TabIndex = 0
        Me.tpgOTEvaluation.Text = "Evaluation"
        Me.tpgOTEvaluation.UseVisualStyleBackColor = True
        '
        'grpADL
        '
        Me.grpADL.Controls.Add(Me.cboWalkingID)
        Me.grpADL.Controls.Add(Me.lblWalkingID)
        Me.grpADL.Controls.Add(Me.cboSitStandTransfersID)
        Me.grpADL.Controls.Add(Me.lblSitStandTransfersID)
        Me.grpADL.Controls.Add(Me.cboBathingID)
        Me.grpADL.Controls.Add(Me.lblBathingID)
        Me.grpADL.Controls.Add(Me.cboToiletingID)
        Me.grpADL.Controls.Add(Me.lblToiletingID)
        Me.grpADL.Controls.Add(Me.cboHandFunctionID)
        Me.grpADL.Controls.Add(Me.lblHandFunctionID)
        Me.grpADL.Controls.Add(Me.cboWashingID)
        Me.grpADL.Controls.Add(Me.lblWashingID)
        Me.grpADL.Controls.Add(Me.cboDressingID)
        Me.grpADL.Controls.Add(Me.lblDressingID)
        Me.grpADL.Controls.Add(Me.cboFeedingID)
        Me.grpADL.Controls.Add(Me.lblFeedingID)
        Me.grpADL.Controls.Add(Me.cboGroomingID)
        Me.grpADL.Controls.Add(Me.lblGroomingID)
        Me.grpADL.Controls.Add(Me.cboMealPreparationID)
        Me.grpADL.Controls.Add(Me.lblMealPreparationID)
        Me.grpADL.Controls.Add(Me.cboWorkPlaySchoolID)
        Me.grpADL.Controls.Add(Me.lblWorkPlaySchoolID)
        Me.grpADL.Controls.Add(Me.cboLeisureID)
        Me.grpADL.Controls.Add(Me.lblLeisureID)
        Me.grpADL.Controls.Add(Me.cboCommunicationID)
        Me.grpADL.Controls.Add(Me.lblCommunicationID)
        Me.grpADL.Location = New System.Drawing.Point(13, 32)
        Me.grpADL.Name = "grpADL"
        Me.grpADL.Size = New System.Drawing.Size(364, 311)
        Me.grpADL.TabIndex = 104
        Me.grpADL.TabStop = False
        Me.grpADL.Text = "ADL/ PERFORMANCE ISSUES"
        '
        'lblWalkingID
        '
        Me.lblWalkingID.Location = New System.Drawing.Point(7, 19)
        Me.lblWalkingID.Name = "lblWalkingID"
        Me.lblWalkingID.Size = New System.Drawing.Size(115, 21)
        Me.lblWalkingID.TabIndex = 109
        Me.lblWalkingID.Text = "Walking"
        '
        'lblSitStandTransfersID
        '
        Me.lblSitStandTransfersID.Location = New System.Drawing.Point(7, 39)
        Me.lblSitStandTransfersID.Name = "lblSitStandTransfersID"
        Me.lblSitStandTransfersID.Size = New System.Drawing.Size(115, 21)
        Me.lblSitStandTransfersID.TabIndex = 111
        Me.lblSitStandTransfersID.Text = "Sit /Stand Transfers"
        '
        'lblBathingID
        '
        Me.lblBathingID.Location = New System.Drawing.Point(7, 59)
        Me.lblBathingID.Name = "lblBathingID"
        Me.lblBathingID.Size = New System.Drawing.Size(115, 21)
        Me.lblBathingID.TabIndex = 113
        Me.lblBathingID.Text = "Bathing"
        '
        'lblToiletingID
        '
        Me.lblToiletingID.Location = New System.Drawing.Point(7, 80)
        Me.lblToiletingID.Name = "lblToiletingID"
        Me.lblToiletingID.Size = New System.Drawing.Size(115, 21)
        Me.lblToiletingID.TabIndex = 115
        Me.lblToiletingID.Text = "Toileting"
        '
        'lblHandFunctionID
        '
        Me.lblHandFunctionID.Location = New System.Drawing.Point(7, 126)
        Me.lblHandFunctionID.Name = "lblHandFunctionID"
        Me.lblHandFunctionID.Size = New System.Drawing.Size(115, 21)
        Me.lblHandFunctionID.TabIndex = 105
        Me.lblHandFunctionID.Text = "Hand Function"
        '
        'lblWashingID
        '
        Me.lblWashingID.Location = New System.Drawing.Point(7, 144)
        Me.lblWashingID.Name = "lblWashingID"
        Me.lblWashingID.Size = New System.Drawing.Size(115, 21)
        Me.lblWashingID.TabIndex = 107
        Me.lblWashingID.Text = "Washing"
        '
        'lblDressingID
        '
        Me.lblDressingID.Location = New System.Drawing.Point(7, 106)
        Me.lblDressingID.Name = "lblDressingID"
        Me.lblDressingID.Size = New System.Drawing.Size(115, 21)
        Me.lblDressingID.TabIndex = 103
        Me.lblDressingID.Text = "Dressing"
        '
        'lblFeedingID
        '
        Me.lblFeedingID.Location = New System.Drawing.Point(7, 165)
        Me.lblFeedingID.Name = "lblFeedingID"
        Me.lblFeedingID.Size = New System.Drawing.Size(115, 21)
        Me.lblFeedingID.TabIndex = 97
        Me.lblFeedingID.Text = "Feeding"
        '
        'lblGroomingID
        '
        Me.lblGroomingID.Location = New System.Drawing.Point(7, 186)
        Me.lblGroomingID.Name = "lblGroomingID"
        Me.lblGroomingID.Size = New System.Drawing.Size(115, 21)
        Me.lblGroomingID.TabIndex = 99
        Me.lblGroomingID.Text = "Grooming"
        '
        'lblMealPreparationID
        '
        Me.lblMealPreparationID.Location = New System.Drawing.Point(7, 207)
        Me.lblMealPreparationID.Name = "lblMealPreparationID"
        Me.lblMealPreparationID.Size = New System.Drawing.Size(115, 21)
        Me.lblMealPreparationID.TabIndex = 101
        Me.lblMealPreparationID.Text = "Meal Preparation"
        '
        'lblWorkPlaySchoolID
        '
        Me.lblWorkPlaySchoolID.Location = New System.Drawing.Point(7, 227)
        Me.lblWorkPlaySchoolID.Name = "lblWorkPlaySchoolID"
        Me.lblWorkPlaySchoolID.Size = New System.Drawing.Size(115, 21)
        Me.lblWorkPlaySchoolID.TabIndex = 91
        Me.lblWorkPlaySchoolID.Text = "Work/ Play/ School"
        '
        'lblLeisureID
        '
        Me.lblLeisureID.Location = New System.Drawing.Point(7, 248)
        Me.lblLeisureID.Name = "lblLeisureID"
        Me.lblLeisureID.Size = New System.Drawing.Size(115, 21)
        Me.lblLeisureID.TabIndex = 93
        Me.lblLeisureID.Text = "Leisure"
        '
        'lblCommunicationID
        '
        Me.lblCommunicationID.Location = New System.Drawing.Point(7, 269)
        Me.lblCommunicationID.Name = "lblCommunicationID"
        Me.lblCommunicationID.Size = New System.Drawing.Size(115, 21)
        Me.lblCommunicationID.TabIndex = 95
        Me.lblCommunicationID.Text = "Communication"
        '
        'grpMentalFunctions
        '
        Me.grpMentalFunctions.Controls.Add(Me.cboCognitionID)
        Me.grpMentalFunctions.Controls.Add(Me.lblCognitionID)
        Me.grpMentalFunctions.Controls.Add(Me.cboAttentionID)
        Me.grpMentalFunctions.Controls.Add(Me.lblAttentionID)
        Me.grpMentalFunctions.Controls.Add(Me.cboImpulseControlID)
        Me.grpMentalFunctions.Controls.Add(Me.lblImpulseControlID)
        Me.grpMentalFunctions.Controls.Add(Me.cboSleepID)
        Me.grpMentalFunctions.Controls.Add(Me.lblSleepID)
        Me.grpMentalFunctions.Controls.Add(Me.cboThoughtID)
        Me.grpMentalFunctions.Controls.Add(Me.lblThoughtID)
        Me.grpMentalFunctions.Controls.Add(Me.cboMemoryID)
        Me.grpMentalFunctions.Controls.Add(Me.lblMemoryID)
        Me.grpMentalFunctions.Controls.Add(Me.cboPerceptionID)
        Me.grpMentalFunctions.Controls.Add(Me.lblPerceptionID)
        Me.grpMentalFunctions.Location = New System.Drawing.Point(394, 6)
        Me.grpMentalFunctions.Name = "grpMentalFunctions"
        Me.grpMentalFunctions.Size = New System.Drawing.Size(380, 170)
        Me.grpMentalFunctions.TabIndex = 103
        Me.grpMentalFunctions.TabStop = False
        Me.grpMentalFunctions.Text = "MENTAL FUNCTIONS"
        '
        'lblCognitionID
        '
        Me.lblCognitionID.Location = New System.Drawing.Point(14, 17)
        Me.lblCognitionID.Name = "lblCognitionID"
        Me.lblCognitionID.Size = New System.Drawing.Size(144, 21)
        Me.lblCognitionID.TabIndex = 93
        Me.lblCognitionID.Text = "Cognition"
        '
        'lblAttentionID
        '
        Me.lblAttentionID.Location = New System.Drawing.Point(14, 36)
        Me.lblAttentionID.Name = "lblAttentionID"
        Me.lblAttentionID.Size = New System.Drawing.Size(144, 21)
        Me.lblAttentionID.TabIndex = 85
        Me.lblAttentionID.Text = "Attention"
        '
        'lblImpulseControlID
        '
        Me.lblImpulseControlID.Location = New System.Drawing.Point(14, 56)
        Me.lblImpulseControlID.Name = "lblImpulseControlID"
        Me.lblImpulseControlID.Size = New System.Drawing.Size(144, 21)
        Me.lblImpulseControlID.TabIndex = 87
        Me.lblImpulseControlID.Text = "Impulse Control"
        '
        'lblSleepID
        '
        Me.lblSleepID.Location = New System.Drawing.Point(14, 77)
        Me.lblSleepID.Name = "lblSleepID"
        Me.lblSleepID.Size = New System.Drawing.Size(144, 21)
        Me.lblSleepID.TabIndex = 89
        Me.lblSleepID.Text = "Sleep"
        '
        'lblThoughtID
        '
        Me.lblThoughtID.Location = New System.Drawing.Point(14, 139)
        Me.lblThoughtID.Name = "lblThoughtID"
        Me.lblThoughtID.Size = New System.Drawing.Size(144, 21)
        Me.lblThoughtID.TabIndex = 83
        Me.lblThoughtID.Text = "Thought"
        '
        'lblMemoryID
        '
        Me.lblMemoryID.Location = New System.Drawing.Point(14, 97)
        Me.lblMemoryID.Name = "lblMemoryID"
        Me.lblMemoryID.Size = New System.Drawing.Size(144, 21)
        Me.lblMemoryID.TabIndex = 79
        Me.lblMemoryID.Text = "Memory"
        '
        'lblPerceptionID
        '
        Me.lblPerceptionID.Location = New System.Drawing.Point(14, 118)
        Me.lblPerceptionID.Name = "lblPerceptionID"
        Me.lblPerceptionID.Size = New System.Drawing.Size(144, 21)
        Me.lblPerceptionID.TabIndex = 81
        Me.lblPerceptionID.Text = "Perception"
        '
        'grpSensoryFunctions
        '
        Me.grpSensoryFunctions.Controls.Add(Me.cboTouchID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblTouchID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboSmellID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblSmellID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboHearingID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblHearingID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboPainID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblPainID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboVestibularID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblVestibularID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboTemperatureAndPressureID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblTemperatureAndPressureID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblSightID)
        Me.grpSensoryFunctions.Controls.Add(Me.lblTasteID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboTasteID)
        Me.grpSensoryFunctions.Controls.Add(Me.cboSightID)
        Me.grpSensoryFunctions.Location = New System.Drawing.Point(397, 180)
        Me.grpSensoryFunctions.Name = "grpSensoryFunctions"
        Me.grpSensoryFunctions.Size = New System.Drawing.Size(375, 185)
        Me.grpSensoryFunctions.TabIndex = 102
        Me.grpSensoryFunctions.TabStop = False
        Me.grpSensoryFunctions.Text = "SENSORY FUNCTIONS"
        '
        'lblTouchID
        '
        Me.lblTouchID.Location = New System.Drawing.Point(14, 79)
        Me.lblTouchID.Name = "lblTouchID"
        Me.lblTouchID.Size = New System.Drawing.Size(144, 21)
        Me.lblTouchID.TabIndex = 111
        Me.lblTouchID.Text = "Touch"
        '
        'lblSmellID
        '
        Me.lblSmellID.Location = New System.Drawing.Point(14, 99)
        Me.lblSmellID.Name = "lblSmellID"
        Me.lblSmellID.Size = New System.Drawing.Size(144, 21)
        Me.lblSmellID.TabIndex = 113
        Me.lblSmellID.Text = "Smell"
        '
        'lblHearingID
        '
        Me.lblHearingID.Location = New System.Drawing.Point(14, 58)
        Me.lblHearingID.Name = "lblHearingID"
        Me.lblHearingID.Size = New System.Drawing.Size(144, 21)
        Me.lblHearingID.TabIndex = 109
        Me.lblHearingID.Text = "Hearing"
        '
        'lblPainID
        '
        Me.lblPainID.Location = New System.Drawing.Point(14, 120)
        Me.lblPainID.Name = "lblPainID"
        Me.lblPainID.Size = New System.Drawing.Size(144, 21)
        Me.lblPainID.TabIndex = 103
        Me.lblPainID.Text = "Pain"
        '
        'lblVestibularID
        '
        Me.lblVestibularID.Location = New System.Drawing.Point(14, 141)
        Me.lblVestibularID.Name = "lblVestibularID"
        Me.lblVestibularID.Size = New System.Drawing.Size(144, 21)
        Me.lblVestibularID.TabIndex = 105
        Me.lblVestibularID.Text = "Vestibular"
        '
        'lblTemperatureAndPressureID
        '
        Me.lblTemperatureAndPressureID.Location = New System.Drawing.Point(14, 161)
        Me.lblTemperatureAndPressureID.Name = "lblTemperatureAndPressureID"
        Me.lblTemperatureAndPressureID.Size = New System.Drawing.Size(144, 21)
        Me.lblTemperatureAndPressureID.TabIndex = 107
        Me.lblTemperatureAndPressureID.Text = "Temperature And Pressure"
        '
        'lblSightID
        '
        Me.lblSightID.Location = New System.Drawing.Point(14, 16)
        Me.lblSightID.Name = "lblSightID"
        Me.lblSightID.Size = New System.Drawing.Size(144, 21)
        Me.lblSightID.TabIndex = 79
        Me.lblSightID.Text = "Sight"
        '
        'lblTasteID
        '
        Me.lblTasteID.Location = New System.Drawing.Point(14, 37)
        Me.lblTasteID.Name = "lblTasteID"
        Me.lblTasteID.Size = New System.Drawing.Size(144, 21)
        Me.lblTasteID.TabIndex = 81
        Me.lblTasteID.Text = "Taste"
        '
        'tpgIntervention
        '
        Me.tpgIntervention.Controls.Add(Me.grpOTInterventionActivities)
        Me.tpgIntervention.Location = New System.Drawing.Point(4, 22)
        Me.tpgIntervention.Name = "tpgIntervention"
        Me.tpgIntervention.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIntervention.Size = New System.Drawing.Size(856, 388)
        Me.tpgIntervention.TabIndex = 1
        Me.tpgIntervention.Text = "Intervention"
        Me.tpgIntervention.UseVisualStyleBackColor = True
        '
        'grpOTInterventionActivities
        '
        Me.grpOTInterventionActivities.Controls.Add(Me.stbOtherAssessment)
        Me.grpOTInterventionActivities.Controls.Add(Me.lblOtherAssessment)
        Me.grpOTInterventionActivities.Controls.Add(Me.stbNotes)
        Me.grpOTInterventionActivities.Controls.Add(Me.lblNotes)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkHomebasedRehabilitation)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkAssistiveDevices)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkMobilitySkillsTraining)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkNeurocognitiveRehabilitation)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkOrientationTechniques)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkVocationalRehabilitation)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkSelfCareTraining)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkPlayTherapy)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkStressManagement)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkHealthEducation)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkTherapeuticGroupActivities)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkCognitiveAssessment)
        Me.grpOTInterventionActivities.Controls.Add(Me.chkHandTherapy)
        Me.grpOTInterventionActivities.Location = New System.Drawing.Point(6, 14)
        Me.grpOTInterventionActivities.Name = "grpOTInterventionActivities"
        Me.grpOTInterventionActivities.Size = New System.Drawing.Size(762, 327)
        Me.grpOTInterventionActivities.TabIndex = 27
        Me.grpOTInterventionActivities.TabStop = False
        Me.grpOTInterventionActivities.Text = "INTERVENTION ACTIVITIES"
        '
        'lblOtherAssessment
        '
        Me.lblOtherAssessment.Location = New System.Drawing.Point(328, 22)
        Me.lblOtherAssessment.Name = "lblOtherAssessment"
        Me.lblOtherAssessment.Size = New System.Drawing.Size(120, 20)
        Me.lblOtherAssessment.TabIndex = 40
        Me.lblOtherAssessment.Text = "Other Assessment"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(328, 83)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(86, 20)
        Me.lblNotes.TabIndex = 42
        Me.lblNotes.Text = "NOTES"
        '
        'FlatButton1
        '
        Me.FlatButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.FlatButton1.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.FlatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FlatButton1.Location = New System.Drawing.Point(800, 572)
        Me.FlatButton1.Name = "FlatButton1"
        Me.FlatButton1.Size = New System.Drawing.Size(72, 25)
        Me.FlatButton1.TabIndex = 70
        Me.FlatButton1.Text = "&Close"
        Me.FlatButton1.UseVisualStyleBackColor = False
        '
        'ebnSave
        '
        Me.ebnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSave.DataSource = Nothing
        Me.ebnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSave.Location = New System.Drawing.Point(16, 573)
        Me.ebnSave.Name = "ebnSave"
        Me.ebnSave.Size = New System.Drawing.Size(77, 25)
        Me.ebnSave.TabIndex = 69
        Me.ebnSave.Tag = "OccupationalTherapy"
        Me.ebnSave.Text = "&Save"
        Me.ebnSave.UseVisualStyleBackColor = False
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 544)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 25)
        Me.fbnSearch.TabIndex = 67
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(800, 543)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 25)
        Me.fbnDelete.TabIndex = 68
        Me.fbnDelete.Tag = "OccupationalTherapy"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(75, 13)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 72
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(8, 15)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(52, 18)
        Me.lblVisitNo.TabIndex = 71
        Me.lblVisitNo.Text = "Visit No."
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadOTVisits)
        Me.pnlVisitNo.Location = New System.Drawing.Point(108, 8)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(180, 30)
        Me.pnlVisitNo.TabIndex = 73
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(4, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(116, 20)
        Me.stbVisitNo.TabIndex = 0
        '
        'btnLoadOTVisits
        '
        Me.btnLoadOTVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadOTVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadOTVisits.Location = New System.Drawing.Point(126, 3)
        Me.btnLoadOTVisits.Name = "btnLoadOTVisits"
        Me.btnLoadOTVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadOTVisits.TabIndex = 1
        Me.btnLoadOTVisits.Tag = ""
        Me.btnLoadOTVisits.Text = "&Load"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(415, 71)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(146, 20)
        Me.stbVisitDate.TabIndex = 77
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(311, 71)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(94, 20)
        Me.lblVisitDate.TabIndex = 76
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(415, 27)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(146, 20)
        Me.stbPatientNo.TabIndex = 81
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(311, 29)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(90, 20)
        Me.lblPatientsNo.TabIndex = 80
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(415, 6)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(146, 20)
        Me.stbFullName.TabIndex = 79
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(311, 7)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(90, 20)
        Me.lblFullName.TabIndex = 78
        Me.lblFullName.Text = "Patient's Name"
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(691, 4)
        Me.nbxAge.MaxValue = 0.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.MustEnterNumeric = True
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(125, 20)
        Me.nbxAge.TabIndex = 85
        Me.nbxAge.Value = ""
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(589, 6)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(95, 20)
        Me.lblAge.TabIndex = 84
        Me.lblAge.Text = "Age"
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(691, 27)
        Me.stbLocation.MaxLength = 40
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(125, 20)
        Me.stbLocation.TabIndex = 83
        '
        'lblLocation
        '
        Me.lblLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocation.Location = New System.Drawing.Point(587, 29)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(95, 20)
        Me.lblLocation.TabIndex = 82
        Me.lblLocation.Text = "Location/Address"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(415, 49)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(146, 20)
        Me.stbLastVisitDate.TabIndex = 87
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(311, 50)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(83, 17)
        Me.lblLastVisitDate.TabIndex = 86
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(862, 112)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(63, 20)
        Me.lblPhoto.TabIndex = 119
        Me.lblPhoto.Text = "Photo"
        Me.lblPhoto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(828, 10)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(97, 91)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 120
        Me.spbPhoto.TabStop = False
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(562, 75)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(265, 34)
        Me.pnlAlerts.TabIndex = 121
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(192, 5)
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
        Me.lblAlerts.Size = New System.Drawing.Size(186, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Forwarded for OT: 0"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = True
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(691, 49)
        Me.stbPhone.MaxLength = 20
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(125, 20)
        Me.stbPhone.TabIndex = 123
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(587, 51)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(94, 20)
        Me.lblPhone.TabIndex = 122
        Me.lblPhone.Text = "Phone"
        '
        'lblTherapist
        '
        Me.lblTherapist.Location = New System.Drawing.Point(9, 42)
        Me.lblTherapist.Name = "lblTherapist"
        Me.lblTherapist.Size = New System.Drawing.Size(94, 20)
        Me.lblTherapist.TabIndex = 124
        Me.lblTherapist.Text = "Lead Therapist"
        '
        'lblInterventionType
        '
        Me.lblInterventionType.Location = New System.Drawing.Point(9, 66)
        Me.lblInterventionType.Name = "lblInterventionType"
        Me.lblInterventionType.Size = New System.Drawing.Size(94, 20)
        Me.lblInterventionType.TabIndex = 126
        Me.lblInterventionType.Text = "Intervention Type"
        '
        'frmOccupationalTherapy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(937, 610)
        Me.Controls.Add(Me.cboInterventionType)
        Me.Controls.Add(Me.lblInterventionType)
        Me.Controls.Add(Me.cboLeadTherapist)
        Me.Controls.Add(Me.lblTherapist)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.nbxAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.FlatButton1)
        Me.Controls.Add(Me.ebnSave)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.tbcOccupationalTherapy)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOccupationalTherapy"
        Me.Text = "Occupational Therapy"
        Me.tbcOccupationalTherapy.ResumeLayout(False)
        Me.tpgOTEvaluation.ResumeLayout(False)
        Me.grpADL.ResumeLayout(False)
        Me.grpMentalFunctions.ResumeLayout(False)
        Me.grpSensoryFunctions.ResumeLayout(False)
        Me.tpgIntervention.ResumeLayout(False)
        Me.grpOTInterventionActivities.ResumeLayout(False)
        Me.grpOTInterventionActivities.PerformLayout()
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlerts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcOccupationalTherapy As System.Windows.Forms.TabControl
    Friend WithEvents tpgOTEvaluation As System.Windows.Forms.TabPage
    Friend WithEvents cboSightID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSightID As System.Windows.Forms.Label
    Friend WithEvents cboTasteID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTasteID As System.Windows.Forms.Label
    Friend WithEvents tpgIntervention As System.Windows.Forms.TabPage
    Friend WithEvents FlatButton1 As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSave As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadOTVisits As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents grpSensoryFunctions As System.Windows.Forms.GroupBox
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents grpADL As System.Windows.Forms.GroupBox
    Friend WithEvents cboWalkingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWalkingID As System.Windows.Forms.Label
    Friend WithEvents cboSitStandTransfersID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSitStandTransfersID As System.Windows.Forms.Label
    Friend WithEvents cboBathingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBathingID As System.Windows.Forms.Label
    Friend WithEvents cboToiletingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblToiletingID As System.Windows.Forms.Label
    Friend WithEvents cboHandFunctionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHandFunctionID As System.Windows.Forms.Label
    Friend WithEvents cboWashingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWashingID As System.Windows.Forms.Label
    Friend WithEvents cboDressingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDressingID As System.Windows.Forms.Label
    Friend WithEvents cboFeedingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFeedingID As System.Windows.Forms.Label
    Friend WithEvents cboGroomingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGroomingID As System.Windows.Forms.Label
    Friend WithEvents cboMealPreparationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMealPreparationID As System.Windows.Forms.Label
    Friend WithEvents cboWorkPlaySchoolID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWorkPlaySchoolID As System.Windows.Forms.Label
    Friend WithEvents cboLeisureID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLeisureID As System.Windows.Forms.Label
    Friend WithEvents cboCommunicationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommunicationID As System.Windows.Forms.Label
    Friend WithEvents grpMentalFunctions As System.Windows.Forms.GroupBox
    Friend WithEvents cboCognitionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCognitionID As System.Windows.Forms.Label
    Friend WithEvents cboAttentionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAttentionID As System.Windows.Forms.Label
    Friend WithEvents cboImpulseControlID As System.Windows.Forms.ComboBox
    Friend WithEvents lblImpulseControlID As System.Windows.Forms.Label
    Friend WithEvents cboSleepID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSleepID As System.Windows.Forms.Label
    Friend WithEvents cboThoughtID As System.Windows.Forms.ComboBox
    Friend WithEvents lblThoughtID As System.Windows.Forms.Label
    Friend WithEvents cboMemoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMemoryID As System.Windows.Forms.Label
    Friend WithEvents cboPerceptionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPerceptionID As System.Windows.Forms.Label
    Friend WithEvents cboTouchID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTouchID As System.Windows.Forms.Label
    Friend WithEvents cboSmellID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSmellID As System.Windows.Forms.Label
    Friend WithEvents cboHearingID As System.Windows.Forms.ComboBox
    Friend WithEvents lblHearingID As System.Windows.Forms.Label
    Friend WithEvents cboPainID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPainID As System.Windows.Forms.Label
    Friend WithEvents cboVestibularID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVestibularID As System.Windows.Forms.Label
    Friend WithEvents cboTemperatureAndPressureID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTemperatureAndPressureID As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents grpOTInterventionActivities As System.Windows.Forms.GroupBox
    Friend WithEvents chkHealthEducation As System.Windows.Forms.CheckBox
    Friend WithEvents chkTherapeuticGroupActivities As System.Windows.Forms.CheckBox
    Friend WithEvents chkCognitiveAssessment As System.Windows.Forms.CheckBox
    Friend WithEvents chkHandTherapy As System.Windows.Forms.CheckBox
    Friend WithEvents chkHomebasedRehabilitation As System.Windows.Forms.CheckBox
    Friend WithEvents chkAssistiveDevices As System.Windows.Forms.CheckBox
    Friend WithEvents chkMobilitySkillsTraining As System.Windows.Forms.CheckBox
    Friend WithEvents chkNeurocognitiveRehabilitation As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrientationTechniques As System.Windows.Forms.CheckBox
    Friend WithEvents chkVocationalRehabilitation As System.Windows.Forms.CheckBox
    Friend WithEvents stbOtherAssessment As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOtherAssessment As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents lblTherapist As System.Windows.Forms.Label
    Friend WithEvents cboLeadTherapist As System.Windows.Forms.ComboBox
    Friend WithEvents cboInterventionType As System.Windows.Forms.ComboBox
    Friend WithEvents lblInterventionType As System.Windows.Forms.Label
    Friend WithEvents chkSelfCareTraining As System.Windows.Forms.CheckBox
    Friend WithEvents chkPlayTherapy As System.Windows.Forms.CheckBox
    Friend WithEvents chkStressManagement As System.Windows.Forms.CheckBox

End Class