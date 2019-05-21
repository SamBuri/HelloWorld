
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSymptomsHistory : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSymptomsHistory))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboFever = New System.Windows.Forms.ComboBox()
        Me.cboCough = New System.Windows.Forms.ComboBox()
        Me.cboCoughMoreThanTwoWeeks = New System.Windows.Forms.ComboBox()
        Me.cboDifficultyInBreathing = New System.Windows.Forms.ComboBox()
        Me.cboConvulsions = New System.Windows.Forms.ComboBox()
        Me.cboAlteredConsciousness = New System.Windows.Forms.ComboBox()
        Me.cboVomiting = New System.Windows.Forms.ComboBox()
        Me.cboUnableToDrinkBreastfeed = New System.Windows.Forms.ComboBox()
        Me.cboDiarrhoea = New System.Windows.Forms.ComboBox()
        Me.cboDiarrhoeaLongerThanTwoWeeks = New System.Windows.Forms.ComboBox()
        Me.cboBloodDiarrhoea = New System.Windows.Forms.ComboBox()
        Me.cboPassingTeaColouredUrine = New System.Windows.Forms.ComboBox()
        Me.cboImmunizationDetails = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFeedingHistory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPastMedicalHistory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbOtherHistory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxMUAC = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxHeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboJaundice = New System.Windows.Forms.ComboBox()
        Me.cboSunkenEyes = New System.Windows.Forms.ComboBox()
        Me.cboPallor = New System.Windows.Forms.ComboBox()
        Me.cboEdema = New System.Windows.Forms.ComboBox()
        Me.cboSkinPinchReturn = New System.Windows.Forms.ComboBox()
        Me.cboSevereWasting = New System.Windows.Forms.ComboBox()
        Me.cboCrackles = New System.Windows.Forms.ComboBox()
        Me.cboAirway = New System.Windows.Forms.ComboBox()
        Me.cboPleuralRub = New System.Windows.Forms.ComboBox()
        Me.cboWheezing = New System.Windows.Forms.ComboBox()
        Me.cboCapRefill = New System.Windows.Forms.ComboBox()
        Me.cboPulse = New System.Windows.Forms.ComboBox()
        Me.cboSubcostalRecession = New System.Windows.Forms.ComboBox()
        Me.cboDeepBreathing = New System.Windows.Forms.ComboBox()
        Me.cboIntercostalRecession = New System.Windows.Forms.ComboBox()
        Me.cboFlaringOfNostrils = New System.Windows.Forms.ComboBox()
        Me.cboKerningsSign = New System.Windows.Forms.ComboBox()
        Me.cboStiffNeck = New System.Windows.Forms.ComboBox()
        Me.cboBulgingFontanelle = New System.Windows.Forms.ComboBox()
        Me.cboUnconscious = New System.Windows.Forms.ComboBox()
        Me.cboUnableToSitStand = New System.Windows.Forms.ComboBox()
        Me.cboLethargic = New System.Windows.Forms.ComboBox()
        Me.dtpTransfusionDate = New System.Windows.Forms.DateTimePicker()
        Me.clbBloodTransfusionNotGivenStateReasons = New System.Windows.Forms.CheckedListBox()
        Me.clbBloodTransfusionStateReasons = New System.Windows.Forms.CheckedListBox()
        Me.cboIfDesiredWasBloodGiven = New System.Windows.Forms.ComboBox()
        Me.cboIsBloodTransfusionDesired = New System.Windows.Forms.ComboBox()
        Me.clbOtherFormsOfSupportiveCare = New System.Windows.Forms.CheckedListBox()
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria = New System.Windows.Forms.CheckedListBox()
        Me.clbReasonsForAdmissionWithPositiveMalariaTest = New System.Windows.Forms.CheckedListBox()
        Me.nbxIfYesVolume = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxBloodUnits = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.tbcSymptomsHistory = New System.Windows.Forms.TabControl()
        Me.tbpHistorySymptomsCheckList = New System.Windows.Forms.TabPage()
        Me.pnlHistorySymptomCheckList = New System.Windows.Forms.Panel()
        Me.lblFever = New System.Windows.Forms.Label()
        Me.lblImmunizationDetails = New System.Windows.Forms.Label()
        Me.lblFeedingHistory = New System.Windows.Forms.Label()
        Me.lblPassingTeaColouredUrine = New System.Windows.Forms.Label()
        Me.lblCough = New System.Windows.Forms.Label()
        Me.lblBloodDiarrhoea = New System.Windows.Forms.Label()
        Me.lblCoughMoreThanTwoWeeks = New System.Windows.Forms.Label()
        Me.lblDiarrhoeaLongerThanTwoWeeks = New System.Windows.Forms.Label()
        Me.lblDifficultyInBreathing = New System.Windows.Forms.Label()
        Me.lblDiarrhoea = New System.Windows.Forms.Label()
        Me.lblOtherHistory = New System.Windows.Forms.Label()
        Me.lblPastMedicalHistory = New System.Windows.Forms.Label()
        Me.lblConvulsions = New System.Windows.Forms.Label()
        Me.lblUnableToDrinkBreastfeed = New System.Windows.Forms.Label()
        Me.lblAlteredConsciousness = New System.Windows.Forms.Label()
        Me.lblVomiting = New System.Windows.Forms.Label()
        Me.tbpTriage = New System.Windows.Forms.TabPage()
        Me.pnlTriage = New System.Windows.Forms.Panel()
        Me.nbxHeartRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblHeartRate = New System.Windows.Forms.Label()
        Me.lblOxygenSaturation = New System.Windows.Forms.Label()
        Me.nbxOxygenSaturation = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxRespirationRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRespirationRate = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.nbxBMI = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxPulse = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBMI = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnTriage = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stbBloodPressure = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBloodPressure = New System.Windows.Forms.Label()
        Me.nbxWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.NumericBox1 = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBodySurfaceArea = New System.Windows.Forms.Label()
        Me.nbxHeadCircum = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblHeadCircum = New System.Windows.Forms.Label()
        Me.nbxBodySurfaceArea = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxTemperature = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.tbpGeneralExamination = New System.Windows.Forms.TabPage()
        Me.pnlGeneralExamination = New System.Windows.Forms.Panel()
        Me.lblHeightCm = New System.Windows.Forms.Label()
        Me.lblMuacCm = New System.Windows.Forms.Label()
        Me.lblPallor = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblMUAC = New System.Windows.Forms.Label()
        Me.lblJaundice = New System.Windows.Forms.Label()
        Me.lblSunkenEyes = New System.Windows.Forms.Label()
        Me.lblEdema = New System.Windows.Forms.Label()
        Me.lblSevereWasting = New System.Windows.Forms.Label()
        Me.lblSkinPinchReturn = New System.Windows.Forms.Label()
        Me.tbpRespiratorySystem = New System.Windows.Forms.TabPage()
        Me.pnlRespiratorySystem = New System.Windows.Forms.Panel()
        Me.lblAirway = New System.Windows.Forms.Label()
        Me.lblCrackles = New System.Windows.Forms.Label()
        Me.lblPleuralRub = New System.Windows.Forms.Label()
        Me.lblWheezing = New System.Windows.Forms.Label()
        Me.lblDeepBreathing = New System.Windows.Forms.Label()
        Me.lblCapRefill = New System.Windows.Forms.Label()
        Me.lblPulse = New System.Windows.Forms.Label()
        Me.lblSubcostalRecession = New System.Windows.Forms.Label()
        Me.lblIntercostalRecession = New System.Windows.Forms.Label()
        Me.lblFlaringOfNostrils = New System.Windows.Forms.Label()
        Me.tbpCentralNervousSystem = New System.Windows.Forms.TabPage()
        Me.pnlCentralNervousSystem = New System.Windows.Forms.Panel()
        Me.lblUnconscious = New System.Windows.Forms.Label()
        Me.lblKerningsSign = New System.Windows.Forms.Label()
        Me.lblStiffNeck = New System.Windows.Forms.Label()
        Me.lblBulgingFontanelle = New System.Windows.Forms.Label()
        Me.lblUnableToSitStand = New System.Windows.Forms.Label()
        Me.lblLethargic = New System.Windows.Forms.Label()
        Me.tbpInitialLaboratoryResults = New System.Windows.Forms.TabPage()
        Me.pnlInitialLaboratoryResults = New System.Windows.Forms.Panel()
        Me.dgvLabResults = New System.Windows.Forms.DataGridView()
        Me.colSpecimenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResult = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultFlag = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNormalRange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResultDataType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbpSupportiveCarePlan = New System.Windows.Forms.TabPage()
        Me.tbcSupportiveCarePlan = New System.Windows.Forms.TabControl()
        Me.tbpBloodTransfusion = New System.Windows.Forms.TabPage()
        Me.pnlBloodTransfusion = New System.Windows.Forms.Panel()
        Me.pnlBloodTransfusionNotGivenStateReasons = New System.Windows.Forms.Panel()
        Me.lblBloodUnits = New System.Windows.Forms.Label()
        Me.lblTransfusionDate = New System.Windows.Forms.Label()
        Me.lblMl = New System.Windows.Forms.Label()
        Me.lblIfYesVolume = New System.Windows.Forms.Label()
        Me.pnlBloodTransfusionStateReasons = New System.Windows.Forms.Panel()
        Me.lblIfDesiredWasBloodGiven = New System.Windows.Forms.Label()
        Me.lblIfYesStateReasons = New System.Windows.Forms.Label()
        Me.lblIsBloodTransfusionDesired = New System.Windows.Forms.Label()
        Me.tbpOtherFormsOfSupportiveCare = New System.Windows.Forms.TabPage()
        Me.pnlOtherFormsOfSupportiveCare = New System.Windows.Forms.Panel()
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria = New System.Windows.Forms.TabPage()
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria = New System.Windows.Forms.Panel()
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest = New System.Windows.Forms.TabPage()
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest = New System.Windows.Forms.Panel()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblHospitalPID = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.stbphoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisistCategory = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pnlPatientDetails = New System.Windows.Forms.Panel()
        Me.tbcSymptomsHistory.SuspendLayout()
        Me.tbpHistorySymptomsCheckList.SuspendLayout()
        Me.pnlHistorySymptomCheckList.SuspendLayout()
        Me.tbpTriage.SuspendLayout()
        Me.pnlTriage.SuspendLayout()
        Me.tbpGeneralExamination.SuspendLayout()
        Me.pnlGeneralExamination.SuspendLayout()
        Me.tbpRespiratorySystem.SuspendLayout()
        Me.pnlRespiratorySystem.SuspendLayout()
        Me.tbpCentralNervousSystem.SuspendLayout()
        Me.pnlCentralNervousSystem.SuspendLayout()
        Me.tbpInitialLaboratoryResults.SuspendLayout()
        Me.pnlInitialLaboratoryResults.SuspendLayout()
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpSupportiveCarePlan.SuspendLayout()
        Me.tbcSupportiveCarePlan.SuspendLayout()
        Me.tbpBloodTransfusion.SuspendLayout()
        Me.pnlBloodTransfusion.SuspendLayout()
        Me.pnlBloodTransfusionNotGivenStateReasons.SuspendLayout()
        Me.pnlBloodTransfusionStateReasons.SuspendLayout()
        Me.tbpOtherFormsOfSupportiveCare.SuspendLayout()
        Me.pnlOtherFormsOfSupportiveCare.SuspendLayout()
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.SuspendLayout()
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.SuspendLayout()
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.SuspendLayout()
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.SuspendLayout()
        CType(Me.stbphoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPatientDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 448)
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
        Me.fbnDelete.Location = New System.Drawing.Point(872, 447)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "SymptomsHistory"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 477)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "SymptomsHistory"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboFever
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFever, "Fever")
        Me.cboFever.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFever.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFever.Location = New System.Drawing.Point(211, 7)
        Me.cboFever.Name = "cboFever"
        Me.cboFever.Size = New System.Drawing.Size(93, 21)
        Me.cboFever.TabIndex = 1
        '
        'cboCough
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCough, "Cough")
        Me.cboCough.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCough.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCough.Location = New System.Drawing.Point(211, 30)
        Me.cboCough.Name = "cboCough"
        Me.cboCough.Size = New System.Drawing.Size(93, 21)
        Me.cboCough.TabIndex = 3
        '
        'cboCoughMoreThanTwoWeeks
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoughMoreThanTwoWeeks, "CoughMoreThanTwoWeeks")
        Me.cboCoughMoreThanTwoWeeks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoughMoreThanTwoWeeks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoughMoreThanTwoWeeks.Location = New System.Drawing.Point(211, 53)
        Me.cboCoughMoreThanTwoWeeks.Name = "cboCoughMoreThanTwoWeeks"
        Me.cboCoughMoreThanTwoWeeks.Size = New System.Drawing.Size(93, 21)
        Me.cboCoughMoreThanTwoWeeks.TabIndex = 5
        '
        'cboDifficultyInBreathing
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDifficultyInBreathing, "DifficultyInBreathing")
        Me.cboDifficultyInBreathing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDifficultyInBreathing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDifficultyInBreathing.Location = New System.Drawing.Point(211, 76)
        Me.cboDifficultyInBreathing.Name = "cboDifficultyInBreathing"
        Me.cboDifficultyInBreathing.Size = New System.Drawing.Size(93, 21)
        Me.cboDifficultyInBreathing.TabIndex = 7
        '
        'cboConvulsions
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboConvulsions, "Convulsions")
        Me.cboConvulsions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConvulsions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConvulsions.Location = New System.Drawing.Point(514, 7)
        Me.cboConvulsions.Name = "cboConvulsions"
        Me.cboConvulsions.Size = New System.Drawing.Size(93, 21)
        Me.cboConvulsions.TabIndex = 13
        '
        'cboAlteredConsciousness
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAlteredConsciousness, "AlteredConsciousness")
        Me.cboAlteredConsciousness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlteredConsciousness.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAlteredConsciousness.Location = New System.Drawing.Point(514, 30)
        Me.cboAlteredConsciousness.Name = "cboAlteredConsciousness"
        Me.cboAlteredConsciousness.Size = New System.Drawing.Size(93, 21)
        Me.cboAlteredConsciousness.TabIndex = 15
        '
        'cboVomiting
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVomiting, "Vomiting")
        Me.cboVomiting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVomiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVomiting.Location = New System.Drawing.Point(514, 53)
        Me.cboVomiting.Name = "cboVomiting"
        Me.cboVomiting.Size = New System.Drawing.Size(93, 21)
        Me.cboVomiting.TabIndex = 17
        '
        'cboUnableToDrinkBreastfeed
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboUnableToDrinkBreastfeed, "UnableToDrinkBreastfeed")
        Me.cboUnableToDrinkBreastfeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnableToDrinkBreastfeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboUnableToDrinkBreastfeed.Location = New System.Drawing.Point(514, 76)
        Me.cboUnableToDrinkBreastfeed.Name = "cboUnableToDrinkBreastfeed"
        Me.cboUnableToDrinkBreastfeed.Size = New System.Drawing.Size(93, 21)
        Me.cboUnableToDrinkBreastfeed.TabIndex = 19
        '
        'cboDiarrhoea
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDiarrhoea, "Diarrhoea")
        Me.cboDiarrhoea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiarrhoea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiarrhoea.Location = New System.Drawing.Point(819, 7)
        Me.cboDiarrhoea.Name = "cboDiarrhoea"
        Me.cboDiarrhoea.Size = New System.Drawing.Size(93, 21)
        Me.cboDiarrhoea.TabIndex = 23
        '
        'cboDiarrhoeaLongerThanTwoWeeks
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDiarrhoeaLongerThanTwoWeeks, "DiarrhoeaLongerThanTwoWeeks")
        Me.cboDiarrhoeaLongerThanTwoWeeks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiarrhoeaLongerThanTwoWeeks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiarrhoeaLongerThanTwoWeeks.Location = New System.Drawing.Point(819, 30)
        Me.cboDiarrhoeaLongerThanTwoWeeks.Name = "cboDiarrhoeaLongerThanTwoWeeks"
        Me.cboDiarrhoeaLongerThanTwoWeeks.Size = New System.Drawing.Size(93, 21)
        Me.cboDiarrhoeaLongerThanTwoWeeks.TabIndex = 25
        '
        'cboBloodDiarrhoea
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBloodDiarrhoea, "BloodDiarrhoea")
        Me.cboBloodDiarrhoea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBloodDiarrhoea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBloodDiarrhoea.Location = New System.Drawing.Point(819, 53)
        Me.cboBloodDiarrhoea.Name = "cboBloodDiarrhoea"
        Me.cboBloodDiarrhoea.Size = New System.Drawing.Size(93, 21)
        Me.cboBloodDiarrhoea.TabIndex = 27
        '
        'cboPassingTeaColouredUrine
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPassingTeaColouredUrine, "PassingTeaColouredUrine")
        Me.cboPassingTeaColouredUrine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPassingTeaColouredUrine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPassingTeaColouredUrine.Location = New System.Drawing.Point(819, 76)
        Me.cboPassingTeaColouredUrine.Name = "cboPassingTeaColouredUrine"
        Me.cboPassingTeaColouredUrine.Size = New System.Drawing.Size(93, 21)
        Me.cboPassingTeaColouredUrine.TabIndex = 29
        '
        'cboImmunizationDetails
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboImmunizationDetails, "ImmunizationDetails")
        Me.cboImmunizationDetails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImmunizationDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboImmunizationDetails.Location = New System.Drawing.Point(211, 99)
        Me.cboImmunizationDetails.Name = "cboImmunizationDetails"
        Me.cboImmunizationDetails.Size = New System.Drawing.Size(93, 21)
        Me.cboImmunizationDetails.TabIndex = 9
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(113, 9)
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(111, 20)
        Me.stbVisitNo.TabIndex = 4
        '
        'stbFeedingHistory
        '
        Me.stbFeedingHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFeedingHistory.CapitalizeFirstLetter = False
        Me.stbFeedingHistory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbFeedingHistory, "FeedingHistory")
        Me.stbFeedingHistory.EntryErrorMSG = ""
        Me.stbFeedingHistory.Location = New System.Drawing.Point(612, 153)
        Me.stbFeedingHistory.MaxLength = 2000
        Me.stbFeedingHistory.Multiline = True
        Me.stbFeedingHistory.Name = "stbFeedingHistory"
        Me.stbFeedingHistory.RegularExpression = ""
        Me.stbFeedingHistory.Size = New System.Drawing.Size(300, 88)
        Me.stbFeedingHistory.TabIndex = 31
        '
        'stbPastMedicalHistory
        '
        Me.stbPastMedicalHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPastMedicalHistory.CapitalizeFirstLetter = False
        Me.stbPastMedicalHistory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPastMedicalHistory, "PastMedicalHistory")
        Me.stbPastMedicalHistory.EntryErrorMSG = ""
        Me.stbPastMedicalHistory.Location = New System.Drawing.Point(310, 153)
        Me.stbPastMedicalHistory.MaxLength = 2000
        Me.stbPastMedicalHistory.Multiline = True
        Me.stbPastMedicalHistory.Name = "stbPastMedicalHistory"
        Me.stbPastMedicalHistory.RegularExpression = ""
        Me.stbPastMedicalHistory.Size = New System.Drawing.Size(296, 88)
        Me.stbPastMedicalHistory.TabIndex = 21
        '
        'stbOtherHistory
        '
        Me.stbOtherHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherHistory.CapitalizeFirstLetter = True
        Me.stbOtherHistory.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbOtherHistory, "OtherHistory")
        Me.stbOtherHistory.EntryErrorMSG = ""
        Me.stbOtherHistory.Location = New System.Drawing.Point(8, 153)
        Me.stbOtherHistory.MaxLength = 2000
        Me.stbOtherHistory.Multiline = True
        Me.stbOtherHistory.Name = "stbOtherHistory"
        Me.stbOtherHistory.RegularExpression = ""
        Me.stbOtherHistory.Size = New System.Drawing.Size(296, 88)
        Me.stbOtherHistory.TabIndex = 11
        '
        'nbxMUAC
        '
        Me.nbxMUAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMUAC.ControlCaption = "Muac Cm"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMUAC, "MUAC")
        Me.nbxMUAC.DecimalPlaces = -1
        Me.nbxMUAC.Location = New System.Drawing.Point(572, 17)
        Me.nbxMUAC.MaxValue = 0.0R
        Me.nbxMUAC.MinValue = 0.0R
        Me.nbxMUAC.MustEnterNumeric = True
        Me.nbxMUAC.Name = "nbxMUAC"
        Me.nbxMUAC.Size = New System.Drawing.Size(93, 20)
        Me.nbxMUAC.TabIndex = 13
        Me.nbxMUAC.Value = ""
        '
        'nbxHeight
        '
        Me.nbxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeight.ControlCaption = "Height Cm"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxHeight, "Height")
        Me.nbxHeight.DecimalPlaces = -1
        Me.nbxHeight.Location = New System.Drawing.Point(572, 39)
        Me.nbxHeight.MaxValue = 0.0R
        Me.nbxHeight.MinValue = 0.0R
        Me.nbxHeight.MustEnterNumeric = True
        Me.nbxHeight.Name = "nbxHeight"
        Me.nbxHeight.Size = New System.Drawing.Size(93, 20)
        Me.nbxHeight.TabIndex = 16
        Me.nbxHeight.Value = ""
        '
        'cboJaundice
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboJaundice, "Jaundice")
        Me.cboJaundice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJaundice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboJaundice.Location = New System.Drawing.Point(231, 131)
        Me.cboJaundice.Name = "cboJaundice"
        Me.cboJaundice.Size = New System.Drawing.Size(93, 21)
        Me.cboJaundice.TabIndex = 11
        '
        'cboSunkenEyes
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSunkenEyes, "SunkenEyes")
        Me.cboSunkenEyes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSunkenEyes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSunkenEyes.Location = New System.Drawing.Point(231, 108)
        Me.cboSunkenEyes.Name = "cboSunkenEyes"
        Me.cboSunkenEyes.Size = New System.Drawing.Size(93, 21)
        Me.cboSunkenEyes.TabIndex = 9
        '
        'cboPallor
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPallor, "Pallor")
        Me.cboPallor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPallor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPallor.Location = New System.Drawing.Point(231, 16)
        Me.cboPallor.Name = "cboPallor"
        Me.cboPallor.Size = New System.Drawing.Size(93, 21)
        Me.cboPallor.TabIndex = 1
        '
        'cboEdema
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEdema, "Edema")
        Me.cboEdema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEdema.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEdema.Location = New System.Drawing.Point(231, 85)
        Me.cboEdema.Name = "cboEdema"
        Me.cboEdema.Size = New System.Drawing.Size(93, 21)
        Me.cboEdema.TabIndex = 7
        '
        'cboSkinPinchReturn
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSkinPinchReturn, "SkinPinchReturn")
        Me.cboSkinPinchReturn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSkinPinchReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSkinPinchReturn.Location = New System.Drawing.Point(231, 39)
        Me.cboSkinPinchReturn.Name = "cboSkinPinchReturn"
        Me.cboSkinPinchReturn.Size = New System.Drawing.Size(93, 21)
        Me.cboSkinPinchReturn.TabIndex = 3
        '
        'cboSevereWasting
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSevereWasting, "SevereWasting")
        Me.cboSevereWasting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSevereWasting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSevereWasting.Location = New System.Drawing.Point(231, 62)
        Me.cboSevereWasting.Name = "cboSevereWasting"
        Me.cboSevereWasting.Size = New System.Drawing.Size(93, 21)
        Me.cboSevereWasting.TabIndex = 5
        '
        'cboCrackles
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCrackles, "Crackles")
        Me.cboCrackles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCrackles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCrackles.Location = New System.Drawing.Point(229, 217)
        Me.cboCrackles.Name = "cboCrackles"
        Me.cboCrackles.Size = New System.Drawing.Size(93, 21)
        Me.cboCrackles.TabIndex = 92
        '
        'cboAirway
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAirway, "AirWay")
        Me.cboAirway.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAirway.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAirway.Location = New System.Drawing.Point(229, 148)
        Me.cboAirway.Name = "cboAirway"
        Me.cboAirway.Size = New System.Drawing.Size(93, 21)
        Me.cboAirway.TabIndex = 86
        '
        'cboPleuralRub
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPleuralRub, "PleuralRub")
        Me.cboPleuralRub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPleuralRub.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPleuralRub.Location = New System.Drawing.Point(229, 194)
        Me.cboPleuralRub.Name = "cboPleuralRub"
        Me.cboPleuralRub.Size = New System.Drawing.Size(93, 21)
        Me.cboPleuralRub.TabIndex = 90
        '
        'cboWheezing
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWheezing, "Wheezing")
        Me.cboWheezing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWheezing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWheezing.Location = New System.Drawing.Point(229, 171)
        Me.cboWheezing.Name = "cboWheezing"
        Me.cboWheezing.Size = New System.Drawing.Size(93, 21)
        Me.cboWheezing.TabIndex = 88
        '
        'cboCapRefill
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCapRefill, "CapRefill")
        Me.cboCapRefill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCapRefill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCapRefill.Location = New System.Drawing.Point(229, 125)
        Me.cboCapRefill.Name = "cboCapRefill"
        Me.cboCapRefill.Size = New System.Drawing.Size(93, 21)
        Me.cboCapRefill.TabIndex = 84
        '
        'cboPulse
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPulse, "Pulse")
        Me.cboPulse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPulse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPulse.Location = New System.Drawing.Point(229, 102)
        Me.cboPulse.Name = "cboPulse"
        Me.cboPulse.Size = New System.Drawing.Size(93, 21)
        Me.cboPulse.TabIndex = 82
        '
        'cboSubcostalRecession
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSubcostalRecession, "SubcostalRecession")
        Me.cboSubcostalRecession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubcostalRecession.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubcostalRecession.Location = New System.Drawing.Point(229, 79)
        Me.cboSubcostalRecession.Name = "cboSubcostalRecession"
        Me.cboSubcostalRecession.Size = New System.Drawing.Size(93, 21)
        Me.cboSubcostalRecession.TabIndex = 80
        '
        'cboDeepBreathing
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDeepBreathing, "DeepBreathing")
        Me.cboDeepBreathing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeepBreathing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDeepBreathing.Location = New System.Drawing.Point(229, 10)
        Me.cboDeepBreathing.Name = "cboDeepBreathing"
        Me.cboDeepBreathing.Size = New System.Drawing.Size(93, 21)
        Me.cboDeepBreathing.TabIndex = 74
        '
        'cboIntercostalRecession
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboIntercostalRecession, "InterCostalRecession")
        Me.cboIntercostalRecession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIntercostalRecession.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIntercostalRecession.Location = New System.Drawing.Point(229, 56)
        Me.cboIntercostalRecession.Name = "cboIntercostalRecession"
        Me.cboIntercostalRecession.Size = New System.Drawing.Size(93, 21)
        Me.cboIntercostalRecession.TabIndex = 78
        '
        'cboFlaringOfNostrils
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFlaringOfNostrils, "FlaringOfNostrils")
        Me.cboFlaringOfNostrils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFlaringOfNostrils.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFlaringOfNostrils.Location = New System.Drawing.Point(229, 33)
        Me.cboFlaringOfNostrils.Name = "cboFlaringOfNostrils"
        Me.cboFlaringOfNostrils.Size = New System.Drawing.Size(93, 21)
        Me.cboFlaringOfNostrils.TabIndex = 76
        '
        'cboKerningsSign
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboKerningsSign, "KerningsSign")
        Me.cboKerningsSign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKerningsSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboKerningsSign.Location = New System.Drawing.Point(227, 128)
        Me.cboKerningsSign.Name = "cboKerningsSign"
        Me.cboKerningsSign.Size = New System.Drawing.Size(93, 21)
        Me.cboKerningsSign.TabIndex = 88
        '
        'cboStiffNeck
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboStiffNeck, "StiffNeck")
        Me.cboStiffNeck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStiffNeck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStiffNeck.Location = New System.Drawing.Point(227, 105)
        Me.cboStiffNeck.Name = "cboStiffNeck"
        Me.cboStiffNeck.Size = New System.Drawing.Size(93, 21)
        Me.cboStiffNeck.TabIndex = 86
        '
        'cboBulgingFontanelle
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBulgingFontanelle, "BulgingFontanelle")
        Me.cboBulgingFontanelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBulgingFontanelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBulgingFontanelle.Location = New System.Drawing.Point(227, 82)
        Me.cboBulgingFontanelle.Name = "cboBulgingFontanelle"
        Me.cboBulgingFontanelle.Size = New System.Drawing.Size(93, 21)
        Me.cboBulgingFontanelle.TabIndex = 84
        '
        'cboUnconscious
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboUnconscious, "Unconscious")
        Me.cboUnconscious.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnconscious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboUnconscious.Location = New System.Drawing.Point(227, 13)
        Me.cboUnconscious.Name = "cboUnconscious"
        Me.cboUnconscious.Size = New System.Drawing.Size(93, 21)
        Me.cboUnconscious.TabIndex = 78
        '
        'cboUnableToSitStand
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboUnableToSitStand, "UnableToSitStand")
        Me.cboUnableToSitStand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnableToSitStand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboUnableToSitStand.Location = New System.Drawing.Point(227, 59)
        Me.cboUnableToSitStand.Name = "cboUnableToSitStand"
        Me.cboUnableToSitStand.Size = New System.Drawing.Size(93, 21)
        Me.cboUnableToSitStand.TabIndex = 82
        '
        'cboLethargic
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLethargic, "Lethargic")
        Me.cboLethargic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLethargic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLethargic.Location = New System.Drawing.Point(227, 36)
        Me.cboLethargic.Name = "cboLethargic"
        Me.cboLethargic.Size = New System.Drawing.Size(93, 21)
        Me.cboLethargic.TabIndex = 80
        '
        'dtpTransfusionDate
        '
        Me.dtpTransfusionDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTransfusionDate, "TransfusionDate")
        Me.dtpTransfusionDate.Location = New System.Drawing.Point(209, 31)
        Me.dtpTransfusionDate.Name = "dtpTransfusionDate"
        Me.dtpTransfusionDate.ShowCheckBox = True
        Me.dtpTransfusionDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpTransfusionDate.TabIndex = 58
        '
        'clbBloodTransfusionNotGivenStateReasons
        '
        Me.clbBloodTransfusionNotGivenStateReasons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbBloodTransfusionNotGivenStateReasons, "BloodTransfusionNotGivenStateReasons")
        Me.clbBloodTransfusionNotGivenStateReasons.FormattingEnabled = True
        Me.clbBloodTransfusionNotGivenStateReasons.Location = New System.Drawing.Point(7, 85)
        Me.clbBloodTransfusionNotGivenStateReasons.Name = "clbBloodTransfusionNotGivenStateReasons"
        Me.clbBloodTransfusionNotGivenStateReasons.Size = New System.Drawing.Size(373, 105)
        Me.clbBloodTransfusionNotGivenStateReasons.TabIndex = 53
        '
        'clbBloodTransfusionStateReasons
        '
        Me.clbBloodTransfusionStateReasons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbBloodTransfusionStateReasons, "BloodTransfusionStateReasons")
        Me.clbBloodTransfusionStateReasons.FormattingEnabled = True
        Me.clbBloodTransfusionStateReasons.Location = New System.Drawing.Point(6, 8)
        Me.clbBloodTransfusionStateReasons.Name = "clbBloodTransfusionStateReasons"
        Me.clbBloodTransfusionStateReasons.Size = New System.Drawing.Size(296, 150)
        Me.clbBloodTransfusionStateReasons.TabIndex = 42
        '
        'cboIfDesiredWasBloodGiven
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboIfDesiredWasBloodGiven, "IfDesiredWasBloodGiven")
        Me.cboIfDesiredWasBloodGiven.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIfDesiredWasBloodGiven.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIfDesiredWasBloodGiven.Location = New System.Drawing.Point(626, 4)
        Me.cboIfDesiredWasBloodGiven.Name = "cboIfDesiredWasBloodGiven"
        Me.cboIfDesiredWasBloodGiven.Size = New System.Drawing.Size(93, 21)
        Me.cboIfDesiredWasBloodGiven.TabIndex = 59
        '
        'cboIsBloodTransfusionDesired
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboIsBloodTransfusionDesired, "IsBloodTransfusionDesired")
        Me.cboIsBloodTransfusionDesired.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIsBloodTransfusionDesired.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIsBloodTransfusionDesired.Location = New System.Drawing.Point(219, 7)
        Me.cboIsBloodTransfusionDesired.Name = "cboIsBloodTransfusionDesired"
        Me.cboIsBloodTransfusionDesired.Size = New System.Drawing.Size(93, 21)
        Me.cboIsBloodTransfusionDesired.TabIndex = 56
        '
        'clbOtherFormsOfSupportiveCare
        '
        Me.clbOtherFormsOfSupportiveCare.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbOtherFormsOfSupportiveCare, "OtherFormsOfSupportiveCare")
        Me.clbOtherFormsOfSupportiveCare.FormattingEnabled = True
        Me.clbOtherFormsOfSupportiveCare.Location = New System.Drawing.Point(3, 5)
        Me.clbOtherFormsOfSupportiveCare.Name = "clbOtherFormsOfSupportiveCare"
        Me.clbOtherFormsOfSupportiveCare.Size = New System.Drawing.Size(896, 210)
        Me.clbOtherFormsOfSupportiveCare.TabIndex = 44
        '
        'clbReasonsForDiagnosisOfSevereComplicatedMalaria
        '
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria, "ReasonsForDiagnosisOfSevereComplicatedMalaria")
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.FormattingEnabled = True
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.Location = New System.Drawing.Point(3, 5)
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.Name = "clbReasonsForDiagnosisOfSevereComplicatedMalaria"
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.Size = New System.Drawing.Size(895, 210)
        Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria.TabIndex = 46
        '
        'clbReasonsForAdmissionWithPositiveMalariaTest
        '
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbReasonsForAdmissionWithPositiveMalariaTest, "ReasonsForAdmissionWithPositiveMalariaTest")
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.FormattingEnabled = True
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.Location = New System.Drawing.Point(3, 5)
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.Name = "clbReasonsForAdmissionWithPositiveMalariaTest"
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.Size = New System.Drawing.Size(891, 210)
        Me.clbReasonsForAdmissionWithPositiveMalariaTest.TabIndex = 46
        '
        'nbxIfYesVolume
        '
        Me.nbxIfYesVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxIfYesVolume.ControlCaption = "If Yes Volume"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxIfYesVolume, "IfYesVolume")
        Me.nbxIfYesVolume.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxIfYesVolume.DecimalPlaces = 2
        Me.nbxIfYesVolume.Location = New System.Drawing.Point(209, 6)
        Me.nbxIfYesVolume.MaxLength = 20
        Me.nbxIfYesVolume.MaxValue = 10000.0R
        Me.nbxIfYesVolume.MinValue = 0.0R
        Me.nbxIfYesVolume.MustEnterNumeric = True
        Me.nbxIfYesVolume.Name = "nbxIfYesVolume"
        Me.nbxIfYesVolume.Size = New System.Drawing.Size(168, 20)
        Me.nbxIfYesVolume.TabIndex = 63
        Me.nbxIfYesVolume.Value = ""
        '
        'nbxBloodUnits
        '
        Me.nbxBloodUnits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBloodUnits.ControlCaption = "Blood Units"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxBloodUnits, "BloodUnits")
        Me.nbxBloodUnits.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBloodUnits.DecimalPlaces = -1
        Me.nbxBloodUnits.Location = New System.Drawing.Point(209, 55)
        Me.nbxBloodUnits.MaxLength = 20
        Me.nbxBloodUnits.MaxValue = 10000.0R
        Me.nbxBloodUnits.MinValue = 0.0R
        Me.nbxBloodUnits.MustEnterNumeric = True
        Me.nbxBloodUnits.Name = "nbxBloodUnits"
        Me.nbxBloodUnits.Size = New System.Drawing.Size(168, 20)
        Me.nbxBloodUnits.TabIndex = 64
        Me.nbxBloodUnits.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(872, 476)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(8, 8)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(81, 20)
        Me.lblVisitNo.TabIndex = 5
        Me.lblVisitNo.Text = "VisitNo"
        '
        'tbcSymptomsHistory
        '
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpHistorySymptomsCheckList)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpTriage)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpGeneralExamination)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpRespiratorySystem)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpCentralNervousSystem)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpInitialLaboratoryResults)
        Me.tbcSymptomsHistory.Controls.Add(Me.tbpSupportiveCarePlan)
        Me.tbcSymptomsHistory.Location = New System.Drawing.Point(12, 121)
        Me.tbcSymptomsHistory.Name = "tbcSymptomsHistory"
        Me.tbcSymptomsHistory.SelectedIndex = 0
        Me.tbcSymptomsHistory.Size = New System.Drawing.Size(932, 302)
        Me.tbcSymptomsHistory.TabIndex = 79
        '
        'tbpHistorySymptomsCheckList
        '
        Me.tbpHistorySymptomsCheckList.BackColor = System.Drawing.Color.Transparent
        Me.tbpHistorySymptomsCheckList.Controls.Add(Me.pnlHistorySymptomCheckList)
        Me.tbpHistorySymptomsCheckList.Location = New System.Drawing.Point(4, 22)
        Me.tbpHistorySymptomsCheckList.Name = "tbpHistorySymptomsCheckList"
        Me.tbpHistorySymptomsCheckList.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpHistorySymptomsCheckList.Size = New System.Drawing.Size(924, 266)
        Me.tbpHistorySymptomsCheckList.TabIndex = 0
        Me.tbpHistorySymptomsCheckList.Text = "History/Symptom Check List"
        '
        'pnlHistorySymptomCheckList
        '
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.stbFeedingHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.stbPastMedicalHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblFever)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.stbOtherHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblImmunizationDetails)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboImmunizationDetails)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboFever)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblFeedingHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblPassingTeaColouredUrine)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboCough)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboPassingTeaColouredUrine)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblCough)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblBloodDiarrhoea)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboCoughMoreThanTwoWeeks)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboBloodDiarrhoea)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblCoughMoreThanTwoWeeks)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblDiarrhoeaLongerThanTwoWeeks)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboDifficultyInBreathing)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboDiarrhoeaLongerThanTwoWeeks)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblDifficultyInBreathing)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblDiarrhoea)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblOtherHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboDiarrhoea)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboConvulsions)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblPastMedicalHistory)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblConvulsions)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblUnableToDrinkBreastfeed)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboAlteredConsciousness)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboUnableToDrinkBreastfeed)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblAlteredConsciousness)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.lblVomiting)
        Me.pnlHistorySymptomCheckList.Controls.Add(Me.cboVomiting)
        Me.pnlHistorySymptomCheckList.Location = New System.Drawing.Point(3, 3)
        Me.pnlHistorySymptomCheckList.Name = "pnlHistorySymptomCheckList"
        Me.pnlHistorySymptomCheckList.Size = New System.Drawing.Size(918, 257)
        Me.pnlHistorySymptomCheckList.TabIndex = 101
        '
        'lblFever
        '
        Me.lblFever.Location = New System.Drawing.Point(5, 7)
        Me.lblFever.Name = "lblFever"
        Me.lblFever.Size = New System.Drawing.Size(200, 20)
        Me.lblFever.TabIndex = 0
        Me.lblFever.Text = "Fever"
        '
        'lblImmunizationDetails
        '
        Me.lblImmunizationDetails.Location = New System.Drawing.Point(5, 99)
        Me.lblImmunizationDetails.Name = "lblImmunizationDetails"
        Me.lblImmunizationDetails.Size = New System.Drawing.Size(200, 20)
        Me.lblImmunizationDetails.TabIndex = 8
        Me.lblImmunizationDetails.Text = "Immunization Details"
        '
        'lblFeedingHistory
        '
        Me.lblFeedingHistory.Location = New System.Drawing.Point(613, 130)
        Me.lblFeedingHistory.Name = "lblFeedingHistory"
        Me.lblFeedingHistory.Size = New System.Drawing.Size(200, 20)
        Me.lblFeedingHistory.TabIndex = 30
        Me.lblFeedingHistory.Text = "Feeding History"
        '
        'lblPassingTeaColouredUrine
        '
        Me.lblPassingTeaColouredUrine.Location = New System.Drawing.Point(613, 76)
        Me.lblPassingTeaColouredUrine.Name = "lblPassingTeaColouredUrine"
        Me.lblPassingTeaColouredUrine.Size = New System.Drawing.Size(200, 20)
        Me.lblPassingTeaColouredUrine.TabIndex = 28
        Me.lblPassingTeaColouredUrine.Text = "Passing Tea Coloured Urine"
        '
        'lblCough
        '
        Me.lblCough.Location = New System.Drawing.Point(5, 31)
        Me.lblCough.Name = "lblCough"
        Me.lblCough.Size = New System.Drawing.Size(200, 20)
        Me.lblCough.TabIndex = 2
        Me.lblCough.Text = "Cough"
        '
        'lblBloodDiarrhoea
        '
        Me.lblBloodDiarrhoea.Location = New System.Drawing.Point(613, 53)
        Me.lblBloodDiarrhoea.Name = "lblBloodDiarrhoea"
        Me.lblBloodDiarrhoea.Size = New System.Drawing.Size(200, 20)
        Me.lblBloodDiarrhoea.TabIndex = 26
        Me.lblBloodDiarrhoea.Text = "Blood Diarrhoea"
        '
        'lblCoughMoreThanTwoWeeks
        '
        Me.lblCoughMoreThanTwoWeeks.Location = New System.Drawing.Point(5, 53)
        Me.lblCoughMoreThanTwoWeeks.Name = "lblCoughMoreThanTwoWeeks"
        Me.lblCoughMoreThanTwoWeeks.Size = New System.Drawing.Size(200, 20)
        Me.lblCoughMoreThanTwoWeeks.TabIndex = 4
        Me.lblCoughMoreThanTwoWeeks.Text = "Cough More Than Two Weeks"
        '
        'lblDiarrhoeaLongerThanTwoWeeks
        '
        Me.lblDiarrhoeaLongerThanTwoWeeks.Location = New System.Drawing.Point(613, 30)
        Me.lblDiarrhoeaLongerThanTwoWeeks.Name = "lblDiarrhoeaLongerThanTwoWeeks"
        Me.lblDiarrhoeaLongerThanTwoWeeks.Size = New System.Drawing.Size(200, 20)
        Me.lblDiarrhoeaLongerThanTwoWeeks.TabIndex = 24
        Me.lblDiarrhoeaLongerThanTwoWeeks.Text = "Diarrhoea Longer Two Weeks"
        '
        'lblDifficultyInBreathing
        '
        Me.lblDifficultyInBreathing.Location = New System.Drawing.Point(5, 76)
        Me.lblDifficultyInBreathing.Name = "lblDifficultyInBreathing"
        Me.lblDifficultyInBreathing.Size = New System.Drawing.Size(200, 20)
        Me.lblDifficultyInBreathing.TabIndex = 6
        Me.lblDifficultyInBreathing.Text = "Difficulty In Breathing"
        '
        'lblDiarrhoea
        '
        Me.lblDiarrhoea.Location = New System.Drawing.Point(613, 7)
        Me.lblDiarrhoea.Name = "lblDiarrhoea"
        Me.lblDiarrhoea.Size = New System.Drawing.Size(200, 20)
        Me.lblDiarrhoea.TabIndex = 22
        Me.lblDiarrhoea.Text = "Diarrhoea"
        '
        'lblOtherHistory
        '
        Me.lblOtherHistory.Location = New System.Drawing.Point(5, 130)
        Me.lblOtherHistory.Name = "lblOtherHistory"
        Me.lblOtherHistory.Size = New System.Drawing.Size(200, 20)
        Me.lblOtherHistory.TabIndex = 10
        Me.lblOtherHistory.Text = "Other History"
        '
        'lblPastMedicalHistory
        '
        Me.lblPastMedicalHistory.Location = New System.Drawing.Point(308, 130)
        Me.lblPastMedicalHistory.Name = "lblPastMedicalHistory"
        Me.lblPastMedicalHistory.Size = New System.Drawing.Size(200, 20)
        Me.lblPastMedicalHistory.TabIndex = 20
        Me.lblPastMedicalHistory.Text = "Past Medical History"
        '
        'lblConvulsions
        '
        Me.lblConvulsions.Location = New System.Drawing.Point(308, 7)
        Me.lblConvulsions.Name = "lblConvulsions"
        Me.lblConvulsions.Size = New System.Drawing.Size(200, 20)
        Me.lblConvulsions.TabIndex = 12
        Me.lblConvulsions.Text = "Convulsions"
        '
        'lblUnableToDrinkBreastfeed
        '
        Me.lblUnableToDrinkBreastfeed.Location = New System.Drawing.Point(308, 76)
        Me.lblUnableToDrinkBreastfeed.Name = "lblUnableToDrinkBreastfeed"
        Me.lblUnableToDrinkBreastfeed.Size = New System.Drawing.Size(200, 20)
        Me.lblUnableToDrinkBreastfeed.TabIndex = 18
        Me.lblUnableToDrinkBreastfeed.Text = "Unable To Drink  Breastfeed"
        '
        'lblAlteredConsciousness
        '
        Me.lblAlteredConsciousness.Location = New System.Drawing.Point(308, 30)
        Me.lblAlteredConsciousness.Name = "lblAlteredConsciousness"
        Me.lblAlteredConsciousness.Size = New System.Drawing.Size(200, 20)
        Me.lblAlteredConsciousness.TabIndex = 14
        Me.lblAlteredConsciousness.Text = "Altered Consciousness"
        '
        'lblVomiting
        '
        Me.lblVomiting.Location = New System.Drawing.Point(308, 53)
        Me.lblVomiting.Name = "lblVomiting"
        Me.lblVomiting.Size = New System.Drawing.Size(200, 20)
        Me.lblVomiting.TabIndex = 16
        Me.lblVomiting.Text = "Vomiting"
        '
        'tbpTriage
        '
        Me.tbpTriage.Controls.Add(Me.pnlTriage)
        Me.tbpTriage.Location = New System.Drawing.Point(4, 22)
        Me.tbpTriage.Name = "tbpTriage"
        Me.tbpTriage.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpTriage.Size = New System.Drawing.Size(924, 276)
        Me.tbpTriage.TabIndex = 4
        Me.tbpTriage.Text = "Triage"
        Me.tbpTriage.UseVisualStyleBackColor = True
        '
        'pnlTriage
        '
        Me.pnlTriage.Controls.Add(Me.nbxHeartRate)
        Me.pnlTriage.Controls.Add(Me.lblHeartRate)
        Me.pnlTriage.Controls.Add(Me.lblOxygenSaturation)
        Me.pnlTriage.Controls.Add(Me.nbxOxygenSaturation)
        Me.pnlTriage.Controls.Add(Me.lblNotes)
        Me.pnlTriage.Controls.Add(Me.stbNotes)
        Me.pnlTriage.Controls.Add(Me.nbxRespirationRate)
        Me.pnlTriage.Controls.Add(Me.lblRespirationRate)
        Me.pnlTriage.Controls.Add(Me.lblTemperature)
        Me.pnlTriage.Controls.Add(Me.nbxBMI)
        Me.pnlTriage.Controls.Add(Me.nbxPulse)
        Me.pnlTriage.Controls.Add(Me.lblBMI)
        Me.pnlTriage.Controls.Add(Me.Label1)
        Me.pnlTriage.Controls.Add(Me.btnTriage)
        Me.pnlTriage.Controls.Add(Me.Label2)
        Me.pnlTriage.Controls.Add(Me.stbBloodPressure)
        Me.pnlTriage.Controls.Add(Me.lblBloodPressure)
        Me.pnlTriage.Controls.Add(Me.nbxWeight)
        Me.pnlTriage.Controls.Add(Me.NumericBox1)
        Me.pnlTriage.Controls.Add(Me.lblBodySurfaceArea)
        Me.pnlTriage.Controls.Add(Me.nbxHeadCircum)
        Me.pnlTriage.Controls.Add(Me.lblWeight)
        Me.pnlTriage.Controls.Add(Me.lblHeadCircum)
        Me.pnlTriage.Controls.Add(Me.nbxBodySurfaceArea)
        Me.pnlTriage.Controls.Add(Me.nbxTemperature)
        Me.pnlTriage.Location = New System.Drawing.Point(3, 3)
        Me.pnlTriage.Name = "pnlTriage"
        Me.pnlTriage.Size = New System.Drawing.Size(918, 260)
        Me.pnlTriage.TabIndex = 98
        '
        'nbxHeartRate
        '
        Me.nbxHeartRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeartRate.ControlCaption = "Heart Rate"
        Me.nbxHeartRate.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxHeartRate.DecimalPlaces = -1
        Me.nbxHeartRate.Enabled = False
        Me.nbxHeartRate.Location = New System.Drawing.Point(157, 203)
        Me.nbxHeartRate.MaxLength = 3
        Me.nbxHeartRate.MaxValue = 250.0R
        Me.nbxHeartRate.MinValue = 0.0R
        Me.nbxHeartRate.MustEnterNumeric = True
        Me.nbxHeartRate.Name = "nbxHeartRate"
        Me.nbxHeartRate.Size = New System.Drawing.Size(83, 20)
        Me.nbxHeartRate.TabIndex = 122
        Me.nbxHeartRate.Value = ""
        '
        'lblHeartRate
        '
        Me.lblHeartRate.Location = New System.Drawing.Point(17, 203)
        Me.lblHeartRate.Name = "lblHeartRate"
        Me.lblHeartRate.Size = New System.Drawing.Size(134, 21)
        Me.lblHeartRate.TabIndex = 121
        Me.lblHeartRate.Text = "Heart Rate (B/min)"
        '
        'lblOxygenSaturation
        '
        Me.lblOxygenSaturation.Location = New System.Drawing.Point(17, 182)
        Me.lblOxygenSaturation.Name = "lblOxygenSaturation"
        Me.lblOxygenSaturation.Size = New System.Drawing.Size(134, 21)
        Me.lblOxygenSaturation.TabIndex = 119
        Me.lblOxygenSaturation.Text = "Oxygen Saturation (%)"
        '
        'nbxOxygenSaturation
        '
        Me.nbxOxygenSaturation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOxygenSaturation.ControlCaption = "Oxygen Saturation"
        Me.nbxOxygenSaturation.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxOxygenSaturation.DecimalPlaces = 2
        Me.nbxOxygenSaturation.Enabled = False
        Me.nbxOxygenSaturation.Location = New System.Drawing.Point(157, 182)
        Me.nbxOxygenSaturation.MaxLength = 8
        Me.nbxOxygenSaturation.MaxValue = 100.0R
        Me.nbxOxygenSaturation.MinValue = 0.0R
        Me.nbxOxygenSaturation.Name = "nbxOxygenSaturation"
        Me.nbxOxygenSaturation.Size = New System.Drawing.Size(83, 20)
        Me.nbxOxygenSaturation.TabIndex = 120
        Me.nbxOxygenSaturation.Value = ""
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(246, 59)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(75, 21)
        Me.lblNotes.TabIndex = 117
        Me.lblNotes.Text = "Notes"
        '
        'stbNotes
        '
        Me.stbNotes.AcceptsReturn = True
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(327, 22)
        Me.stbNotes.MaxLength = 2000
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.ReadOnly = True
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(384, 188)
        Me.stbNotes.TabIndex = 118
        '
        'nbxRespirationRate
        '
        Me.nbxRespirationRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRespirationRate.ControlCaption = "Respiration Rate"
        Me.nbxRespirationRate.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxRespirationRate.DecimalPlaces = -1
        Me.nbxRespirationRate.Enabled = False
        Me.nbxRespirationRate.Location = New System.Drawing.Point(157, 161)
        Me.nbxRespirationRate.MaxLength = 3
        Me.nbxRespirationRate.MaxValue = 150.0R
        Me.nbxRespirationRate.MinValue = 10.0R
        Me.nbxRespirationRate.MustEnterNumeric = True
        Me.nbxRespirationRate.Name = "nbxRespirationRate"
        Me.nbxRespirationRate.Size = New System.Drawing.Size(83, 20)
        Me.nbxRespirationRate.TabIndex = 113
        Me.nbxRespirationRate.Value = ""
        '
        'lblRespirationRate
        '
        Me.lblRespirationRate.Location = New System.Drawing.Point(17, 161)
        Me.lblRespirationRate.Name = "lblRespirationRate"
        Me.lblRespirationRate.Size = New System.Drawing.Size(134, 21)
        Me.lblRespirationRate.TabIndex = 112
        Me.lblRespirationRate.Text = "Respiration Rate (B/min)"
        '
        'lblTemperature
        '
        Me.lblTemperature.Location = New System.Drawing.Point(17, 35)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(134, 21)
        Me.lblTemperature.TabIndex = 100
        Me.lblTemperature.Text = "Temperature (Celc.)"
        '
        'nbxBMI
        '
        Me.nbxBMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBMI.ControlCaption = "BMI"
        Me.nbxBMI.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBMI.DecimalPlaces = 2
        Me.nbxBMI.Enabled = False
        Me.nbxBMI.Location = New System.Drawing.Point(157, 224)
        Me.nbxBMI.MaxLength = 12
        Me.nbxBMI.MaxValue = 0.0R
        Me.nbxBMI.MinValue = 0.0R
        Me.nbxBMI.MustEnterNumeric = True
        Me.nbxBMI.Name = "nbxBMI"
        Me.nbxBMI.Size = New System.Drawing.Size(83, 20)
        Me.nbxBMI.TabIndex = 115
        Me.nbxBMI.Value = ""
        '
        'nbxPulse
        '
        Me.nbxPulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPulse.ControlCaption = "Pulse"
        Me.nbxPulse.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxPulse.DecimalPlaces = -1
        Me.nbxPulse.Enabled = False
        Me.nbxPulse.Location = New System.Drawing.Point(157, 77)
        Me.nbxPulse.MaxLength = 3
        Me.nbxPulse.MaxValue = 250.0R
        Me.nbxPulse.MinValue = 50.0R
        Me.nbxPulse.Name = "nbxPulse"
        Me.nbxPulse.Size = New System.Drawing.Size(83, 20)
        Me.nbxPulse.TabIndex = 105
        Me.nbxPulse.Value = ""
        '
        'lblBMI
        '
        Me.lblBMI.Location = New System.Drawing.Point(17, 224)
        Me.lblBMI.Name = "lblBMI"
        Me.lblBMI.Size = New System.Drawing.Size(134, 21)
        Me.lblBMI.TabIndex = 114
        Me.lblBMI.Text = "BMI (Kg/M²)"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 21)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Pulse (B/min)"
        '
        'btnTriage
        '
        Me.btnTriage.Enabled = False
        Me.btnTriage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnTriage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTriage.Location = New System.Drawing.Point(251, 224)
        Me.btnTriage.Name = "btnTriage"
        Me.btnTriage.Size = New System.Drawing.Size(131, 23)
        Me.btnTriage.TabIndex = 116
        Me.btnTriage.Tag = "Triage"
        Me.btnTriage.Text = "Register Triage..."
        Me.btnTriage.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 21)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Height (cm)"
        '
        'stbBloodPressure
        '
        Me.stbBloodPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBloodPressure.CapitalizeFirstLetter = False
        Me.stbBloodPressure.Enabled = False
        Me.stbBloodPressure.EntryErrorMSG = "Must enter in the form 999/999"
        Me.stbBloodPressure.Location = New System.Drawing.Point(157, 98)
        Me.stbBloodPressure.MaxLength = 7
        Me.stbBloodPressure.Name = "stbBloodPressure"
        Me.stbBloodPressure.RegularExpression = "^[0-9]{1,3}/[0-9]{1,3}$"
        Me.stbBloodPressure.Size = New System.Drawing.Size(83, 20)
        Me.stbBloodPressure.TabIndex = 107
        '
        'lblBloodPressure
        '
        Me.lblBloodPressure.Location = New System.Drawing.Point(17, 98)
        Me.lblBloodPressure.Name = "lblBloodPressure"
        Me.lblBloodPressure.Size = New System.Drawing.Size(134, 21)
        Me.lblBloodPressure.TabIndex = 106
        Me.lblBloodPressure.Text = "Blood Pressure (mmHg)"
        '
        'nbxWeight
        '
        Me.nbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxWeight.ControlCaption = "Weight"
        Me.nbxWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxWeight.DecimalPlaces = 2
        Me.nbxWeight.Enabled = False
        Me.nbxWeight.Location = New System.Drawing.Point(157, 14)
        Me.nbxWeight.MaxLength = 6
        Me.nbxWeight.MaxValue = 200.0R
        Me.nbxWeight.MinValue = 1.0R
        Me.nbxWeight.Name = "nbxWeight"
        Me.nbxWeight.Size = New System.Drawing.Size(83, 20)
        Me.nbxWeight.TabIndex = 99
        Me.nbxWeight.Value = ""
        '
        'NumericBox1
        '
        Me.NumericBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericBox1.ControlCaption = "Height"
        Me.NumericBox1.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.NumericBox1.DecimalPlaces = 2
        Me.NumericBox1.Enabled = False
        Me.NumericBox1.Location = New System.Drawing.Point(157, 56)
        Me.NumericBox1.MaxLength = 6
        Me.NumericBox1.MaxValue = 250.0R
        Me.NumericBox1.MinValue = 50.0R
        Me.NumericBox1.Name = "NumericBox1"
        Me.NumericBox1.Size = New System.Drawing.Size(83, 20)
        Me.NumericBox1.TabIndex = 103
        Me.NumericBox1.Value = ""
        '
        'lblBodySurfaceArea
        '
        Me.lblBodySurfaceArea.Location = New System.Drawing.Point(17, 140)
        Me.lblBodySurfaceArea.Name = "lblBodySurfaceArea"
        Me.lblBodySurfaceArea.Size = New System.Drawing.Size(134, 21)
        Me.lblBodySurfaceArea.TabIndex = 110
        Me.lblBodySurfaceArea.Text = "Body Surface Area (cm)"
        '
        'nbxHeadCircum
        '
        Me.nbxHeadCircum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeadCircum.ControlCaption = "Head Circum"
        Me.nbxHeadCircum.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxHeadCircum.DecimalPlaces = 2
        Me.nbxHeadCircum.Enabled = False
        Me.nbxHeadCircum.Location = New System.Drawing.Point(157, 119)
        Me.nbxHeadCircum.MaxLength = 6
        Me.nbxHeadCircum.MaxValue = 100.0R
        Me.nbxHeadCircum.MinValue = 30.0R
        Me.nbxHeadCircum.MustEnterNumeric = True
        Me.nbxHeadCircum.Name = "nbxHeadCircum"
        Me.nbxHeadCircum.Size = New System.Drawing.Size(83, 20)
        Me.nbxHeadCircum.TabIndex = 109
        Me.nbxHeadCircum.Value = ""
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(17, 14)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(134, 21)
        Me.lblWeight.TabIndex = 98
        Me.lblWeight.Text = "Weight (Kg)"
        '
        'lblHeadCircum
        '
        Me.lblHeadCircum.Location = New System.Drawing.Point(17, 119)
        Me.lblHeadCircum.Name = "lblHeadCircum"
        Me.lblHeadCircum.Size = New System.Drawing.Size(134, 21)
        Me.lblHeadCircum.TabIndex = 108
        Me.lblHeadCircum.Text = "Head Circum (cm)"
        '
        'nbxBodySurfaceArea
        '
        Me.nbxBodySurfaceArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBodySurfaceArea.ControlCaption = "Body Surface Area"
        Me.nbxBodySurfaceArea.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBodySurfaceArea.DecimalPlaces = 2
        Me.nbxBodySurfaceArea.Enabled = False
        Me.nbxBodySurfaceArea.Location = New System.Drawing.Point(157, 140)
        Me.nbxBodySurfaceArea.MaxLength = 8
        Me.nbxBodySurfaceArea.MaxValue = 0.0R
        Me.nbxBodySurfaceArea.MinValue = 0.0R
        Me.nbxBodySurfaceArea.Name = "nbxBodySurfaceArea"
        Me.nbxBodySurfaceArea.Size = New System.Drawing.Size(83, 20)
        Me.nbxBodySurfaceArea.TabIndex = 111
        Me.nbxBodySurfaceArea.Value = ""
        '
        'nbxTemperature
        '
        Me.nbxTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTemperature.ControlCaption = "Temperature"
        Me.nbxTemperature.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxTemperature.DecimalPlaces = 2
        Me.nbxTemperature.Enabled = False
        Me.nbxTemperature.Location = New System.Drawing.Point(157, 35)
        Me.nbxTemperature.MaxLength = 5
        Me.nbxTemperature.MaxValue = 45.0R
        Me.nbxTemperature.MinValue = 30.0R
        Me.nbxTemperature.Name = "nbxTemperature"
        Me.nbxTemperature.Size = New System.Drawing.Size(83, 20)
        Me.nbxTemperature.TabIndex = 101
        Me.nbxTemperature.Value = ""
        '
        'tbpGeneralExamination
        '
        Me.tbpGeneralExamination.BackColor = System.Drawing.SystemColors.Control
        Me.tbpGeneralExamination.Controls.Add(Me.pnlGeneralExamination)
        Me.tbpGeneralExamination.Location = New System.Drawing.Point(4, 22)
        Me.tbpGeneralExamination.Name = "tbpGeneralExamination"
        Me.tbpGeneralExamination.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpGeneralExamination.Size = New System.Drawing.Size(924, 266)
        Me.tbpGeneralExamination.TabIndex = 1
        Me.tbpGeneralExamination.Text = "General Examination"
        '
        'pnlGeneralExamination
        '
        Me.pnlGeneralExamination.Controls.Add(Me.lblHeightCm)
        Me.pnlGeneralExamination.Controls.Add(Me.lblMuacCm)
        Me.pnlGeneralExamination.Controls.Add(Me.lblPallor)
        Me.pnlGeneralExamination.Controls.Add(Me.nbxMUAC)
        Me.pnlGeneralExamination.Controls.Add(Me.lblHeight)
        Me.pnlGeneralExamination.Controls.Add(Me.nbxHeight)
        Me.pnlGeneralExamination.Controls.Add(Me.lblMUAC)
        Me.pnlGeneralExamination.Controls.Add(Me.lblJaundice)
        Me.pnlGeneralExamination.Controls.Add(Me.cboJaundice)
        Me.pnlGeneralExamination.Controls.Add(Me.lblSunkenEyes)
        Me.pnlGeneralExamination.Controls.Add(Me.cboSunkenEyes)
        Me.pnlGeneralExamination.Controls.Add(Me.cboPallor)
        Me.pnlGeneralExamination.Controls.Add(Me.lblEdema)
        Me.pnlGeneralExamination.Controls.Add(Me.cboEdema)
        Me.pnlGeneralExamination.Controls.Add(Me.cboSkinPinchReturn)
        Me.pnlGeneralExamination.Controls.Add(Me.lblSevereWasting)
        Me.pnlGeneralExamination.Controls.Add(Me.lblSkinPinchReturn)
        Me.pnlGeneralExamination.Controls.Add(Me.cboSevereWasting)
        Me.pnlGeneralExamination.Location = New System.Drawing.Point(3, 6)
        Me.pnlGeneralExamination.Name = "pnlGeneralExamination"
        Me.pnlGeneralExamination.Size = New System.Drawing.Size(915, 254)
        Me.pnlGeneralExamination.TabIndex = 81
        '
        'lblHeightCm
        '
        Me.lblHeightCm.Location = New System.Drawing.Point(671, 40)
        Me.lblHeightCm.Name = "lblHeightCm"
        Me.lblHeightCm.Size = New System.Drawing.Size(200, 20)
        Me.lblHeightCm.TabIndex = 17
        Me.lblHeightCm.Text = "cm"
        '
        'lblMuacCm
        '
        Me.lblMuacCm.Location = New System.Drawing.Point(671, 16)
        Me.lblMuacCm.Name = "lblMuacCm"
        Me.lblMuacCm.Size = New System.Drawing.Size(200, 20)
        Me.lblMuacCm.TabIndex = 14
        Me.lblMuacCm.Text = "cm"
        '
        'lblPallor
        '
        Me.lblPallor.Location = New System.Drawing.Point(25, 17)
        Me.lblPallor.Name = "lblPallor"
        Me.lblPallor.Size = New System.Drawing.Size(200, 20)
        Me.lblPallor.TabIndex = 0
        Me.lblPallor.Text = "Pallor"
        '
        'lblHeight
        '
        Me.lblHeight.Location = New System.Drawing.Point(366, 39)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(200, 20)
        Me.lblHeight.TabIndex = 15
        Me.lblHeight.Text = "Height"
        '
        'lblMUAC
        '
        Me.lblMUAC.Location = New System.Drawing.Point(366, 17)
        Me.lblMUAC.Name = "lblMUAC"
        Me.lblMUAC.Size = New System.Drawing.Size(200, 20)
        Me.lblMUAC.TabIndex = 12
        Me.lblMUAC.Text = "MUAC"
        '
        'lblJaundice
        '
        Me.lblJaundice.Location = New System.Drawing.Point(25, 131)
        Me.lblJaundice.Name = "lblJaundice"
        Me.lblJaundice.Size = New System.Drawing.Size(200, 20)
        Me.lblJaundice.TabIndex = 10
        Me.lblJaundice.Text = "Jaundice"
        '
        'lblSunkenEyes
        '
        Me.lblSunkenEyes.Location = New System.Drawing.Point(25, 108)
        Me.lblSunkenEyes.Name = "lblSunkenEyes"
        Me.lblSunkenEyes.Size = New System.Drawing.Size(200, 20)
        Me.lblSunkenEyes.TabIndex = 8
        Me.lblSunkenEyes.Text = "Sunken Eyes"
        '
        'lblEdema
        '
        Me.lblEdema.Location = New System.Drawing.Point(25, 85)
        Me.lblEdema.Name = "lblEdema"
        Me.lblEdema.Size = New System.Drawing.Size(200, 20)
        Me.lblEdema.TabIndex = 6
        Me.lblEdema.Text = "Edema"
        '
        'lblSevereWasting
        '
        Me.lblSevereWasting.Location = New System.Drawing.Point(25, 62)
        Me.lblSevereWasting.Name = "lblSevereWasting"
        Me.lblSevereWasting.Size = New System.Drawing.Size(200, 20)
        Me.lblSevereWasting.TabIndex = 4
        Me.lblSevereWasting.Text = "Severe Wasting"
        '
        'lblSkinPinchReturn
        '
        Me.lblSkinPinchReturn.Location = New System.Drawing.Point(25, 40)
        Me.lblSkinPinchReturn.Name = "lblSkinPinchReturn"
        Me.lblSkinPinchReturn.Size = New System.Drawing.Size(200, 20)
        Me.lblSkinPinchReturn.TabIndex = 2
        Me.lblSkinPinchReturn.Text = "Skin Pinch Return"
        '
        'tbpRespiratorySystem
        '
        Me.tbpRespiratorySystem.BackColor = System.Drawing.SystemColors.Control
        Me.tbpRespiratorySystem.Controls.Add(Me.pnlRespiratorySystem)
        Me.tbpRespiratorySystem.Location = New System.Drawing.Point(4, 22)
        Me.tbpRespiratorySystem.Name = "tbpRespiratorySystem"
        Me.tbpRespiratorySystem.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRespiratorySystem.Size = New System.Drawing.Size(924, 266)
        Me.tbpRespiratorySystem.TabIndex = 2
        Me.tbpRespiratorySystem.Text = "Respiratory System"
        '
        'pnlRespiratorySystem
        '
        Me.pnlRespiratorySystem.Controls.Add(Me.lblAirway)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblCrackles)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboCrackles)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboAirway)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblPleuralRub)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboPleuralRub)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboWheezing)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblWheezing)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblDeepBreathing)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblCapRefill)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboCapRefill)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblPulse)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboPulse)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblSubcostalRecession)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboSubcostalRecession)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboDeepBreathing)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblIntercostalRecession)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboIntercostalRecession)
        Me.pnlRespiratorySystem.Controls.Add(Me.cboFlaringOfNostrils)
        Me.pnlRespiratorySystem.Controls.Add(Me.lblFlaringOfNostrils)
        Me.pnlRespiratorySystem.Location = New System.Drawing.Point(7, 6)
        Me.pnlRespiratorySystem.Name = "pnlRespiratorySystem"
        Me.pnlRespiratorySystem.Size = New System.Drawing.Size(911, 254)
        Me.pnlRespiratorySystem.TabIndex = 74
        '
        'lblAirway
        '
        Me.lblAirway.Location = New System.Drawing.Point(23, 148)
        Me.lblAirway.Name = "lblAirway"
        Me.lblAirway.Size = New System.Drawing.Size(200, 20)
        Me.lblAirway.TabIndex = 87
        Me.lblAirway.Text = "Airway"
        '
        'lblCrackles
        '
        Me.lblCrackles.Location = New System.Drawing.Point(23, 217)
        Me.lblCrackles.Name = "lblCrackles"
        Me.lblCrackles.Size = New System.Drawing.Size(200, 20)
        Me.lblCrackles.TabIndex = 93
        Me.lblCrackles.Text = "Crackles"
        '
        'lblPleuralRub
        '
        Me.lblPleuralRub.Location = New System.Drawing.Point(23, 194)
        Me.lblPleuralRub.Name = "lblPleuralRub"
        Me.lblPleuralRub.Size = New System.Drawing.Size(200, 20)
        Me.lblPleuralRub.TabIndex = 91
        Me.lblPleuralRub.Text = "Pleural Rub"
        '
        'lblWheezing
        '
        Me.lblWheezing.Location = New System.Drawing.Point(23, 171)
        Me.lblWheezing.Name = "lblWheezing"
        Me.lblWheezing.Size = New System.Drawing.Size(200, 20)
        Me.lblWheezing.TabIndex = 89
        Me.lblWheezing.Text = "Wheezing"
        '
        'lblDeepBreathing
        '
        Me.lblDeepBreathing.Location = New System.Drawing.Point(23, 10)
        Me.lblDeepBreathing.Name = "lblDeepBreathing"
        Me.lblDeepBreathing.Size = New System.Drawing.Size(200, 20)
        Me.lblDeepBreathing.TabIndex = 75
        Me.lblDeepBreathing.Text = "Deep Breathing"
        '
        'lblCapRefill
        '
        Me.lblCapRefill.Location = New System.Drawing.Point(23, 125)
        Me.lblCapRefill.Name = "lblCapRefill"
        Me.lblCapRefill.Size = New System.Drawing.Size(200, 20)
        Me.lblCapRefill.TabIndex = 85
        Me.lblCapRefill.Text = "Cap Refill"
        '
        'lblPulse
        '
        Me.lblPulse.Location = New System.Drawing.Point(23, 102)
        Me.lblPulse.Name = "lblPulse"
        Me.lblPulse.Size = New System.Drawing.Size(200, 20)
        Me.lblPulse.TabIndex = 83
        Me.lblPulse.Text = "Pulse"
        '
        'lblSubcostalRecession
        '
        Me.lblSubcostalRecession.Location = New System.Drawing.Point(23, 79)
        Me.lblSubcostalRecession.Name = "lblSubcostalRecession"
        Me.lblSubcostalRecession.Size = New System.Drawing.Size(200, 20)
        Me.lblSubcostalRecession.TabIndex = 81
        Me.lblSubcostalRecession.Text = "Subcostal Recession "
        '
        'lblIntercostalRecession
        '
        Me.lblIntercostalRecession.Location = New System.Drawing.Point(23, 56)
        Me.lblIntercostalRecession.Name = "lblIntercostalRecession"
        Me.lblIntercostalRecession.Size = New System.Drawing.Size(200, 20)
        Me.lblIntercostalRecession.TabIndex = 79
        Me.lblIntercostalRecession.Text = "Intercostal Recession "
        '
        'lblFlaringOfNostrils
        '
        Me.lblFlaringOfNostrils.Location = New System.Drawing.Point(23, 33)
        Me.lblFlaringOfNostrils.Name = "lblFlaringOfNostrils"
        Me.lblFlaringOfNostrils.Size = New System.Drawing.Size(200, 20)
        Me.lblFlaringOfNostrils.TabIndex = 77
        Me.lblFlaringOfNostrils.Text = "Flaring Of Nostrils"
        '
        'tbpCentralNervousSystem
        '
        Me.tbpCentralNervousSystem.BackColor = System.Drawing.SystemColors.Control
        Me.tbpCentralNervousSystem.Controls.Add(Me.pnlCentralNervousSystem)
        Me.tbpCentralNervousSystem.Location = New System.Drawing.Point(4, 22)
        Me.tbpCentralNervousSystem.Name = "tbpCentralNervousSystem"
        Me.tbpCentralNervousSystem.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCentralNervousSystem.Size = New System.Drawing.Size(924, 266)
        Me.tbpCentralNervousSystem.TabIndex = 3
        Me.tbpCentralNervousSystem.Text = "Central Nervous System"
        '
        'pnlCentralNervousSystem
        '
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblUnconscious)
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblKerningsSign)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboKerningsSign)
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblStiffNeck)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboStiffNeck)
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblBulgingFontanelle)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboBulgingFontanelle)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboUnconscious)
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblUnableToSitStand)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboUnableToSitStand)
        Me.pnlCentralNervousSystem.Controls.Add(Me.cboLethargic)
        Me.pnlCentralNervousSystem.Controls.Add(Me.lblLethargic)
        Me.pnlCentralNervousSystem.Location = New System.Drawing.Point(3, 7)
        Me.pnlCentralNervousSystem.Name = "pnlCentralNervousSystem"
        Me.pnlCentralNervousSystem.Size = New System.Drawing.Size(915, 253)
        Me.pnlCentralNervousSystem.TabIndex = 78
        '
        'lblUnconscious
        '
        Me.lblUnconscious.Location = New System.Drawing.Point(21, 13)
        Me.lblUnconscious.Name = "lblUnconscious"
        Me.lblUnconscious.Size = New System.Drawing.Size(200, 20)
        Me.lblUnconscious.TabIndex = 79
        Me.lblUnconscious.Text = "Unconscious"
        '
        'lblKerningsSign
        '
        Me.lblKerningsSign.Location = New System.Drawing.Point(21, 128)
        Me.lblKerningsSign.Name = "lblKerningsSign"
        Me.lblKerningsSign.Size = New System.Drawing.Size(200, 20)
        Me.lblKerningsSign.TabIndex = 89
        Me.lblKerningsSign.Text = "Kernings Sign"
        '
        'lblStiffNeck
        '
        Me.lblStiffNeck.Location = New System.Drawing.Point(21, 105)
        Me.lblStiffNeck.Name = "lblStiffNeck"
        Me.lblStiffNeck.Size = New System.Drawing.Size(200, 20)
        Me.lblStiffNeck.TabIndex = 87
        Me.lblStiffNeck.Text = "Stiff Neck"
        '
        'lblBulgingFontanelle
        '
        Me.lblBulgingFontanelle.Location = New System.Drawing.Point(21, 82)
        Me.lblBulgingFontanelle.Name = "lblBulgingFontanelle"
        Me.lblBulgingFontanelle.Size = New System.Drawing.Size(200, 20)
        Me.lblBulgingFontanelle.TabIndex = 85
        Me.lblBulgingFontanelle.Text = "Bulging Fontanelle"
        '
        'lblUnableToSitStand
        '
        Me.lblUnableToSitStand.Location = New System.Drawing.Point(21, 59)
        Me.lblUnableToSitStand.Name = "lblUnableToSitStand"
        Me.lblUnableToSitStand.Size = New System.Drawing.Size(200, 20)
        Me.lblUnableToSitStand.TabIndex = 83
        Me.lblUnableToSitStand.Text = "Unable To Sit  Stand"
        '
        'lblLethargic
        '
        Me.lblLethargic.Location = New System.Drawing.Point(21, 36)
        Me.lblLethargic.Name = "lblLethargic"
        Me.lblLethargic.Size = New System.Drawing.Size(200, 20)
        Me.lblLethargic.TabIndex = 81
        Me.lblLethargic.Text = "Lethargic"
        '
        'tbpInitialLaboratoryResults
        '
        Me.tbpInitialLaboratoryResults.Controls.Add(Me.pnlInitialLaboratoryResults)
        Me.tbpInitialLaboratoryResults.Location = New System.Drawing.Point(4, 22)
        Me.tbpInitialLaboratoryResults.Name = "tbpInitialLaboratoryResults"
        Me.tbpInitialLaboratoryResults.Size = New System.Drawing.Size(924, 266)
        Me.tbpInitialLaboratoryResults.TabIndex = 5
        Me.tbpInitialLaboratoryResults.Text = "Initial Laboratory Results"
        Me.tbpInitialLaboratoryResults.UseVisualStyleBackColor = True
        '
        'pnlInitialLaboratoryResults
        '
        Me.pnlInitialLaboratoryResults.Controls.Add(Me.dgvLabResults)
        Me.pnlInitialLaboratoryResults.Location = New System.Drawing.Point(0, 0)
        Me.pnlInitialLaboratoryResults.Name = "pnlInitialLaboratoryResults"
        Me.pnlInitialLaboratoryResults.Size = New System.Drawing.Size(921, 266)
        Me.pnlInitialLaboratoryResults.TabIndex = 0
        '
        'dgvLabResults
        '
        Me.dgvLabResults.AllowUserToAddRows = False
        Me.dgvLabResults.AllowUserToDeleteRows = False
        Me.dgvLabResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvLabResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLabResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvLabResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvLabResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvLabResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvLabResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSpecimenNo, Me.colTestDateTime, Me.colTestCode, Me.colTestName, Me.colResult, Me.colUnitMeasure, Me.colResultFlag, Me.colNormalRange, Me.colReport, Me.colResultDataType})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLabResults.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLabResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabResults.EnableHeadersVisualStyles = False
        Me.dgvLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabResults.Location = New System.Drawing.Point(0, 0)
        Me.dgvLabResults.Name = "dgvLabResults"
        Me.dgvLabResults.ReadOnly = True
        Me.dgvLabResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLabResults.RowHeadersVisible = False
        Me.dgvLabResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvLabResults.Size = New System.Drawing.Size(921, 266)
        Me.dgvLabResults.TabIndex = 4
        Me.dgvLabResults.Text = "DataGridView1"
        '
        'colSpecimenNo
        '
        Me.colSpecimenNo.DataPropertyName = "SpecimenNo"
        Me.colSpecimenNo.HeaderText = "Specimen No"
        Me.colSpecimenNo.Name = "colSpecimenNo"
        Me.colSpecimenNo.ReadOnly = True
        Me.colSpecimenNo.Width = 80
        '
        'colTestDateTime
        '
        Me.colTestDateTime.DataPropertyName = "TestDateTime"
        Me.colTestDateTime.HeaderText = "Test Date & Time"
        Me.colTestDateTime.Name = "colTestDateTime"
        Me.colTestDateTime.ReadOnly = True
        Me.colTestDateTime.Width = 125
        '
        'colTestCode
        '
        Me.colTestCode.DataPropertyName = "TestCode"
        Me.colTestCode.HeaderText = "Test Code"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.ReadOnly = True
        Me.colTestCode.Width = 70
        '
        'colTestName
        '
        Me.colTestName.DataPropertyName = "TestName"
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        Me.colTestName.Width = 120
        '
        'colResult
        '
        Me.colResult.DataPropertyName = "Result"
        Me.colResult.HeaderText = "Result"
        Me.colResult.Name = "colResult"
        Me.colResult.ReadOnly = True
        Me.colResult.Width = 170
        '
        'colUnitMeasure
        '
        Me.colUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 80
        '
        'colResultFlag
        '
        Me.colResultFlag.DataPropertyName = "ResultFlag"
        Me.colResultFlag.HeaderText = "Flag"
        Me.colResultFlag.Name = "colResultFlag"
        Me.colResultFlag.ReadOnly = True
        Me.colResultFlag.Width = 55
        '
        'colNormalRange
        '
        Me.colNormalRange.DataPropertyName = "NormalRange"
        Me.colNormalRange.HeaderText = "Normal Range"
        Me.colNormalRange.Name = "colNormalRange"
        Me.colNormalRange.ReadOnly = True
        Me.colNormalRange.Width = 85
        '
        'colReport
        '
        Me.colReport.DataPropertyName = "Report"
        Me.colReport.HeaderText = "Report"
        Me.colReport.Name = "colReport"
        Me.colReport.ReadOnly = True
        Me.colReport.Width = 120
        '
        'colResultDataType
        '
        Me.colResultDataType.DataPropertyName = "ResultDataType"
        Me.colResultDataType.HeaderText = "Result Data Type"
        Me.colResultDataType.Name = "colResultDataType"
        Me.colResultDataType.ReadOnly = True
        Me.colResultDataType.Visible = False
        '
        'tbpSupportiveCarePlan
        '
        Me.tbpSupportiveCarePlan.Controls.Add(Me.tbcSupportiveCarePlan)
        Me.tbpSupportiveCarePlan.Location = New System.Drawing.Point(4, 22)
        Me.tbpSupportiveCarePlan.Name = "tbpSupportiveCarePlan"
        Me.tbpSupportiveCarePlan.Size = New System.Drawing.Size(924, 266)
        Me.tbpSupportiveCarePlan.TabIndex = 7
        Me.tbpSupportiveCarePlan.Text = "Supportive Care Plan"
        Me.tbpSupportiveCarePlan.UseVisualStyleBackColor = True
        '
        'tbcSupportiveCarePlan
        '
        Me.tbcSupportiveCarePlan.Controls.Add(Me.tbpBloodTransfusion)
        Me.tbcSupportiveCarePlan.Controls.Add(Me.tbpOtherFormsOfSupportiveCare)
        Me.tbcSupportiveCarePlan.Controls.Add(Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria)
        Me.tbcSupportiveCarePlan.Controls.Add(Me.tbpReasonsForAdmissionWithPositiveMalariaTest)
        Me.tbcSupportiveCarePlan.Location = New System.Drawing.Point(3, 4)
        Me.tbcSupportiveCarePlan.Name = "tbcSupportiveCarePlan"
        Me.tbcSupportiveCarePlan.SelectedIndex = 0
        Me.tbcSupportiveCarePlan.Size = New System.Drawing.Size(918, 259)
        Me.tbcSupportiveCarePlan.TabIndex = 0
        '
        'tbpBloodTransfusion
        '
        Me.tbpBloodTransfusion.Controls.Add(Me.pnlBloodTransfusion)
        Me.tbpBloodTransfusion.Location = New System.Drawing.Point(4, 22)
        Me.tbpBloodTransfusion.Name = "tbpBloodTransfusion"
        Me.tbpBloodTransfusion.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpBloodTransfusion.Size = New System.Drawing.Size(910, 233)
        Me.tbpBloodTransfusion.TabIndex = 0
        Me.tbpBloodTransfusion.Text = "Blood Transfusion"
        Me.tbpBloodTransfusion.UseVisualStyleBackColor = True
        '
        'pnlBloodTransfusion
        '
        Me.pnlBloodTransfusion.Controls.Add(Me.pnlBloodTransfusionNotGivenStateReasons)
        Me.pnlBloodTransfusion.Controls.Add(Me.pnlBloodTransfusionStateReasons)
        Me.pnlBloodTransfusion.Controls.Add(Me.cboIfDesiredWasBloodGiven)
        Me.pnlBloodTransfusion.Controls.Add(Me.lblIfDesiredWasBloodGiven)
        Me.pnlBloodTransfusion.Controls.Add(Me.lblIfYesStateReasons)
        Me.pnlBloodTransfusion.Controls.Add(Me.cboIsBloodTransfusionDesired)
        Me.pnlBloodTransfusion.Controls.Add(Me.lblIsBloodTransfusionDesired)
        Me.pnlBloodTransfusion.Location = New System.Drawing.Point(6, 3)
        Me.pnlBloodTransfusion.Name = "pnlBloodTransfusion"
        Me.pnlBloodTransfusion.Size = New System.Drawing.Size(901, 227)
        Me.pnlBloodTransfusion.TabIndex = 56
        '
        'pnlBloodTransfusionNotGivenStateReasons
        '
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.nbxBloodUnits)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.nbxIfYesVolume)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.lblBloodUnits)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.dtpTransfusionDate)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.lblTransfusionDate)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.lblMl)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.lblIfYesVolume)
        Me.pnlBloodTransfusionNotGivenStateReasons.Controls.Add(Me.clbBloodTransfusionNotGivenStateReasons)
        Me.pnlBloodTransfusionNotGivenStateReasons.Location = New System.Drawing.Point(416, 29)
        Me.pnlBloodTransfusionNotGivenStateReasons.Name = "pnlBloodTransfusionNotGivenStateReasons"
        Me.pnlBloodTransfusionNotGivenStateReasons.Size = New System.Drawing.Size(410, 193)
        Me.pnlBloodTransfusionNotGivenStateReasons.TabIndex = 62
        '
        'lblBloodUnits
        '
        Me.lblBloodUnits.Location = New System.Drawing.Point(3, 57)
        Me.lblBloodUnits.Name = "lblBloodUnits"
        Me.lblBloodUnits.Size = New System.Drawing.Size(200, 20)
        Me.lblBloodUnits.TabIndex = 59
        Me.lblBloodUnits.Text = "Blood Units #:"
        '
        'lblTransfusionDate
        '
        Me.lblTransfusionDate.Location = New System.Drawing.Point(3, 31)
        Me.lblTransfusionDate.Name = "lblTransfusionDate"
        Me.lblTransfusionDate.Size = New System.Drawing.Size(200, 20)
        Me.lblTransfusionDate.TabIndex = 57
        Me.lblTransfusionDate.Text = "Transfusion Date"
        '
        'lblMl
        '
        Me.lblMl.Location = New System.Drawing.Point(385, 5)
        Me.lblMl.Name = "lblMl"
        Me.lblMl.Size = New System.Drawing.Size(22, 20)
        Me.lblMl.TabIndex = 56
        Me.lblMl.Text = "ml"
        '
        'lblIfYesVolume
        '
        Me.lblIfYesVolume.Location = New System.Drawing.Point(3, 10)
        Me.lblIfYesVolume.Name = "lblIfYesVolume"
        Me.lblIfYesVolume.Size = New System.Drawing.Size(200, 20)
        Me.lblIfYesVolume.TabIndex = 54
        Me.lblIfYesVolume.Text = "If Yes, Volume"
        '
        'pnlBloodTransfusionStateReasons
        '
        Me.pnlBloodTransfusionStateReasons.Controls.Add(Me.clbBloodTransfusionStateReasons)
        Me.pnlBloodTransfusionStateReasons.Location = New System.Drawing.Point(10, 52)
        Me.pnlBloodTransfusionStateReasons.Name = "pnlBloodTransfusionStateReasons"
        Me.pnlBloodTransfusionStateReasons.Size = New System.Drawing.Size(309, 170)
        Me.pnlBloodTransfusionStateReasons.TabIndex = 61
        '
        'lblIfDesiredWasBloodGiven
        '
        Me.lblIfDesiredWasBloodGiven.Location = New System.Drawing.Point(420, 7)
        Me.lblIfDesiredWasBloodGiven.Name = "lblIfDesiredWasBloodGiven"
        Me.lblIfDesiredWasBloodGiven.Size = New System.Drawing.Size(200, 20)
        Me.lblIfDesiredWasBloodGiven.TabIndex = 60
        Me.lblIfDesiredWasBloodGiven.Text = "If Desired, Was Blood Given"
        '
        'lblIfYesStateReasons
        '
        Me.lblIfYesStateReasons.Location = New System.Drawing.Point(13, 29)
        Me.lblIfYesStateReasons.Name = "lblIfYesStateReasons"
        Me.lblIfYesStateReasons.Size = New System.Drawing.Size(200, 20)
        Me.lblIfYesStateReasons.TabIndex = 58
        Me.lblIfYesStateReasons.Text = "If Yes, State Reasons"
        '
        'lblIsBloodTransfusionDesired
        '
        Me.lblIsBloodTransfusionDesired.Location = New System.Drawing.Point(13, 7)
        Me.lblIsBloodTransfusionDesired.Name = "lblIsBloodTransfusionDesired"
        Me.lblIsBloodTransfusionDesired.Size = New System.Drawing.Size(200, 20)
        Me.lblIsBloodTransfusionDesired.TabIndex = 57
        Me.lblIsBloodTransfusionDesired.Text = "Is Blood Transfusion Desired"
        '
        'tbpOtherFormsOfSupportiveCare
        '
        Me.tbpOtherFormsOfSupportiveCare.Controls.Add(Me.pnlOtherFormsOfSupportiveCare)
        Me.tbpOtherFormsOfSupportiveCare.Location = New System.Drawing.Point(4, 22)
        Me.tbpOtherFormsOfSupportiveCare.Name = "tbpOtherFormsOfSupportiveCare"
        Me.tbpOtherFormsOfSupportiveCare.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpOtherFormsOfSupportiveCare.Size = New System.Drawing.Size(910, 233)
        Me.tbpOtherFormsOfSupportiveCare.TabIndex = 1
        Me.tbpOtherFormsOfSupportiveCare.Text = "Other Forms Of Supportive Care"
        Me.tbpOtherFormsOfSupportiveCare.UseVisualStyleBackColor = True
        '
        'pnlOtherFormsOfSupportiveCare
        '
        Me.pnlOtherFormsOfSupportiveCare.Controls.Add(Me.clbOtherFormsOfSupportiveCare)
        Me.pnlOtherFormsOfSupportiveCare.Location = New System.Drawing.Point(3, 6)
        Me.pnlOtherFormsOfSupportiveCare.Name = "pnlOtherFormsOfSupportiveCare"
        Me.pnlOtherFormsOfSupportiveCare.Size = New System.Drawing.Size(901, 221)
        Me.pnlOtherFormsOfSupportiveCare.TabIndex = 44
        '
        'tpgReasonsForDiagnosisOfSevereComplicatedMalaria
        '
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Controls.Add(Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria)
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Location = New System.Drawing.Point(4, 22)
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Name = "tpgReasonsForDiagnosisOfSevereComplicatedMalaria"
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Size = New System.Drawing.Size(910, 233)
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.TabIndex = 2
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.Text = "Reasons For Diagnosis Of Severe/Complicated Malaria"
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.UseVisualStyleBackColor = True
        '
        'pnlReasonsForDiagnosisOfSevereComplicationMalaria
        '
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.Controls.Add(Me.clbReasonsForDiagnosisOfSevereComplicatedMalaria)
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.Location = New System.Drawing.Point(3, 7)
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.Name = "pnlReasonsForDiagnosisOfSevereComplicationMalaria"
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.Size = New System.Drawing.Size(901, 220)
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.TabIndex = 0
        '
        'tbpReasonsForAdmissionWithPositiveMalariaTest
        '
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Controls.Add(Me.pnlReasonsForAdmissionWithPositiveMalariaTest)
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Location = New System.Drawing.Point(4, 22)
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Name = "tbpReasonsForAdmissionWithPositiveMalariaTest"
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Size = New System.Drawing.Size(910, 233)
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.TabIndex = 3
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.Text = "Reasons For Admission With Positive Malaria Test"
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.UseVisualStyleBackColor = True
        '
        'pnlReasonsForAdmissionWithPositiveMalariaTest
        '
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.Controls.Add(Me.clbReasonsForAdmissionWithPositiveMalariaTest)
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.Location = New System.Drawing.Point(7, 7)
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.Name = "pnlReasonsForAdmissionWithPositiveMalariaTest"
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.Size = New System.Drawing.Size(897, 220)
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.TabIndex = 0
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(230, 5)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 81
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(80, 8)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 80
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(645, 9)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ReadOnly = True
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitDate.TabIndex = 92
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(540, 9)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(99, 20)
        Me.lblVisitDate.TabIndex = 91
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(645, 30)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ReadOnly = True
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 94
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(540, 30)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(99, 20)
        Me.lblJoinDate.TabIndex = 93
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(113, 31)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 84
        '
        'lblHospitalPID
        '
        Me.lblHospitalPID.Location = New System.Drawing.Point(8, 33)
        Me.lblHospitalPID.Name = "lblHospitalPID"
        Me.lblHospitalPID.Size = New System.Drawing.Size(99, 20)
        Me.lblHospitalPID.TabIndex = 83
        Me.lblHospitalPID.Text = "Patient No"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(385, 8)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.ReadOnly = True
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(149, 20)
        Me.stbAge.TabIndex = 88
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(385, 51)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 90
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(281, 10)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(99, 20)
        Me.lblAge.TabIndex = 87
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(280, 53)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(99, 20)
        Me.lblGenderID.TabIndex = 89
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(113, 53)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 86
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(9, 56)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(99, 20)
        Me.lblName.TabIndex = 85
        Me.lblName.Text = "Patient's Name"
        '
        'stbphoto
        '
        Me.stbphoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbphoto.Image = CType(resources.GetObject("stbphoto.Image"), System.Drawing.Image)
        Me.stbphoto.ImageSizeLimit = CType(200000, Long)
        Me.stbphoto.InitialImage = CType(resources.GetObject("stbphoto.InitialImage"), System.Drawing.Image)
        Me.stbphoto.Location = New System.Drawing.Point(800, 7)
        Me.stbphoto.Name = "stbphoto"
        Me.stbphoto.ReadOnly = True
        Me.stbphoto.Size = New System.Drawing.Size(100, 100)
        Me.stbphoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.stbphoto.TabIndex = 96
        Me.stbphoto.TabStop = False
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(645, 51)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.ReadOnly = True
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitCategory.TabIndex = 100
        '
        'lblVisistCategory
        '
        Me.lblVisistCategory.Location = New System.Drawing.Point(540, 51)
        Me.lblVisistCategory.Name = "lblVisistCategory"
        Me.lblVisistCategory.Size = New System.Drawing.Size(99, 20)
        Me.lblVisistCategory.TabIndex = 99
        Me.lblVisistCategory.Text = "Visist Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(385, 29)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.ReadOnly = True
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(149, 20)
        Me.stbStatus.TabIndex = 98
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(281, 31)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(99, 20)
        Me.lblStatus.TabIndex = 97
        Me.lblStatus.Text = "Status"
        '
        'pnlPatientDetails
        '
        Me.pnlPatientDetails.Controls.Add(Me.stbPatientNo)
        Me.pnlPatientDetails.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.pnlPatientDetails.Controls.Add(Me.btnFindVisitNo)
        Me.pnlPatientDetails.Controls.Add(Me.stbVisitCategory)
        Me.pnlPatientDetails.Controls.Add(Me.lblName)
        Me.pnlPatientDetails.Controls.Add(Me.lblVisistCategory)
        Me.pnlPatientDetails.Controls.Add(Me.stbFullName)
        Me.pnlPatientDetails.Controls.Add(Me.stbStatus)
        Me.pnlPatientDetails.Controls.Add(Me.lblGenderID)
        Me.pnlPatientDetails.Controls.Add(Me.stbVisitNo)
        Me.pnlPatientDetails.Controls.Add(Me.lblStatus)
        Me.pnlPatientDetails.Controls.Add(Me.lblVisitNo)
        Me.pnlPatientDetails.Controls.Add(Me.lblAge)
        Me.pnlPatientDetails.Controls.Add(Me.stbphoto)
        Me.pnlPatientDetails.Controls.Add(Me.stbGender)
        Me.pnlPatientDetails.Controls.Add(Me.stbVisitDate)
        Me.pnlPatientDetails.Controls.Add(Me.stbAge)
        Me.pnlPatientDetails.Controls.Add(Me.lblVisitDate)
        Me.pnlPatientDetails.Controls.Add(Me.lblHospitalPID)
        Me.pnlPatientDetails.Controls.Add(Me.stbJoinDate)
        Me.pnlPatientDetails.Controls.Add(Me.lblJoinDate)
        Me.pnlPatientDetails.Location = New System.Drawing.Point(19, 4)
        Me.pnlPatientDetails.Name = "pnlPatientDetails"
        Me.pnlPatientDetails.Size = New System.Drawing.Size(918, 111)
        Me.pnlPatientDetails.TabIndex = 101
        '
        'frmSymptomsHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(951, 517)
        Me.Controls.Add(Me.pnlPatientDetails)
        Me.Controls.Add(Me.tbcSymptomsHistory)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSymptomsHistory"
        Me.Text = "Symptoms History"
        Me.tbcSymptomsHistory.ResumeLayout(False)
        Me.tbpHistorySymptomsCheckList.ResumeLayout(False)
        Me.pnlHistorySymptomCheckList.ResumeLayout(False)
        Me.pnlHistorySymptomCheckList.PerformLayout()
        Me.tbpTriage.ResumeLayout(False)
        Me.pnlTriage.ResumeLayout(False)
        Me.pnlTriage.PerformLayout()
        Me.tbpGeneralExamination.ResumeLayout(False)
        Me.pnlGeneralExamination.ResumeLayout(False)
        Me.pnlGeneralExamination.PerformLayout()
        Me.tbpRespiratorySystem.ResumeLayout(False)
        Me.pnlRespiratorySystem.ResumeLayout(False)
        Me.tbpCentralNervousSystem.ResumeLayout(False)
        Me.pnlCentralNervousSystem.ResumeLayout(False)
        Me.tbpInitialLaboratoryResults.ResumeLayout(False)
        Me.pnlInitialLaboratoryResults.ResumeLayout(False)
        CType(Me.dgvLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpSupportiveCarePlan.ResumeLayout(False)
        Me.tbcSupportiveCarePlan.ResumeLayout(False)
        Me.tbpBloodTransfusion.ResumeLayout(False)
        Me.pnlBloodTransfusion.ResumeLayout(False)
        Me.pnlBloodTransfusionNotGivenStateReasons.ResumeLayout(False)
        Me.pnlBloodTransfusionNotGivenStateReasons.PerformLayout()
        Me.pnlBloodTransfusionStateReasons.ResumeLayout(False)
        Me.tbpOtherFormsOfSupportiveCare.ResumeLayout(False)
        Me.pnlOtherFormsOfSupportiveCare.ResumeLayout(False)
        Me.tpgReasonsForDiagnosisOfSevereComplicatedMalaria.ResumeLayout(False)
        Me.pnlReasonsForDiagnosisOfSevereComplicationMalaria.ResumeLayout(False)
        Me.tbpReasonsForAdmissionWithPositiveMalariaTest.ResumeLayout(False)
        Me.pnlReasonsForAdmissionWithPositiveMalariaTest.ResumeLayout(False)
        CType(Me.stbphoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPatientDetails.ResumeLayout(False)
        Me.pnlPatientDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents tbcSymptomsHistory As System.Windows.Forms.TabControl
    Friend WithEvents tbpHistorySymptomsCheckList As System.Windows.Forms.TabPage
    Friend WithEvents tbpGeneralExamination As System.Windows.Forms.TabPage
    Friend WithEvents cboFever As System.Windows.Forms.ComboBox
    Friend WithEvents lblFever As System.Windows.Forms.Label
    Friend WithEvents cboCough As System.Windows.Forms.ComboBox
    Friend WithEvents lblCough As System.Windows.Forms.Label
    Friend WithEvents cboCoughMoreThanTwoWeeks As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoughMoreThanTwoWeeks As System.Windows.Forms.Label
    Friend WithEvents cboDifficultyInBreathing As System.Windows.Forms.ComboBox
    Friend WithEvents lblDifficultyInBreathing As System.Windows.Forms.Label
    Friend WithEvents lblOtherHistory As System.Windows.Forms.Label
    Friend WithEvents cboConvulsions As System.Windows.Forms.ComboBox
    Friend WithEvents lblConvulsions As System.Windows.Forms.Label
    Friend WithEvents cboAlteredConsciousness As System.Windows.Forms.ComboBox
    Friend WithEvents lblAlteredConsciousness As System.Windows.Forms.Label
    Friend WithEvents cboVomiting As System.Windows.Forms.ComboBox
    Friend WithEvents lblVomiting As System.Windows.Forms.Label
    Friend WithEvents cboUnableToDrinkBreastfeed As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnableToDrinkBreastfeed As System.Windows.Forms.Label
    Friend WithEvents lblPastMedicalHistory As System.Windows.Forms.Label
    Friend WithEvents cboDiarrhoea As System.Windows.Forms.ComboBox
    Friend WithEvents lblDiarrhoea As System.Windows.Forms.Label
    Friend WithEvents cboDiarrhoeaLongerThanTwoWeeks As System.Windows.Forms.ComboBox
    Friend WithEvents lblDiarrhoeaLongerThanTwoWeeks As System.Windows.Forms.Label
    Friend WithEvents cboBloodDiarrhoea As System.Windows.Forms.ComboBox
    Friend WithEvents lblBloodDiarrhoea As System.Windows.Forms.Label
    Friend WithEvents cboPassingTeaColouredUrine As System.Windows.Forms.ComboBox
    Friend WithEvents lblPassingTeaColouredUrine As System.Windows.Forms.Label
    Friend WithEvents lblFeedingHistory As System.Windows.Forms.Label
    Friend WithEvents cboImmunizationDetails As System.Windows.Forms.ComboBox
    Friend WithEvents lblImmunizationDetails As System.Windows.Forms.Label
    Friend WithEvents tbpRespiratorySystem As System.Windows.Forms.TabPage
    Friend WithEvents tbpCentralNervousSystem As System.Windows.Forms.TabPage
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHospitalPID As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbphoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents tbpTriage As System.Windows.Forms.TabPage
    Friend WithEvents tbpInitialLaboratoryResults As System.Windows.Forms.TabPage
    Friend WithEvents tbpSupportiveCarePlan As System.Windows.Forms.TabPage
    Friend WithEvents tbcSupportiveCarePlan As System.Windows.Forms.TabControl
    Friend WithEvents tbpBloodTransfusion As System.Windows.Forms.TabPage
    Friend WithEvents tbpOtherFormsOfSupportiveCare As System.Windows.Forms.TabPage
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisistCategory As System.Windows.Forms.Label
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbFeedingHistory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPastMedicalHistory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbOtherHistory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tpgReasonsForDiagnosisOfSevereComplicatedMalaria As System.Windows.Forms.TabPage
    Friend WithEvents tbpReasonsForAdmissionWithPositiveMalariaTest As System.Windows.Forms.TabPage
    Friend WithEvents pnlHistorySymptomCheckList As System.Windows.Forms.Panel
    Friend WithEvents pnlTriage As System.Windows.Forms.Panel
    Friend WithEvents nbxHeartRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeartRate As System.Windows.Forms.Label
    Friend WithEvents lblOxygenSaturation As System.Windows.Forms.Label
    Friend WithEvents nbxOxygenSaturation As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxRespirationRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRespirationRate As System.Windows.Forms.Label
    Friend WithEvents lblTemperature As System.Windows.Forms.Label
    Friend WithEvents nbxBMI As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxPulse As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBMI As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTriage As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stbBloodPressure As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBloodPressure As System.Windows.Forms.Label
    Friend WithEvents nbxWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents NumericBox1 As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBodySurfaceArea As System.Windows.Forms.Label
    Friend WithEvents nbxHeadCircum As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lblHeadCircum As System.Windows.Forms.Label
    Friend WithEvents nbxBodySurfaceArea As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxTemperature As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents pnlGeneralExamination As System.Windows.Forms.Panel
    Friend WithEvents lblHeightCm As System.Windows.Forms.Label
    Friend WithEvents lblMuacCm As System.Windows.Forms.Label
    Friend WithEvents lblPallor As System.Windows.Forms.Label
    Friend WithEvents nbxMUAC As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents nbxHeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMUAC As System.Windows.Forms.Label
    Friend WithEvents lblJaundice As System.Windows.Forms.Label
    Friend WithEvents cboJaundice As System.Windows.Forms.ComboBox
    Friend WithEvents lblSunkenEyes As System.Windows.Forms.Label
    Friend WithEvents cboSunkenEyes As System.Windows.Forms.ComboBox
    Friend WithEvents cboPallor As System.Windows.Forms.ComboBox
    Friend WithEvents lblEdema As System.Windows.Forms.Label
    Friend WithEvents cboEdema As System.Windows.Forms.ComboBox
    Friend WithEvents cboSkinPinchReturn As System.Windows.Forms.ComboBox
    Friend WithEvents lblSevereWasting As System.Windows.Forms.Label
    Friend WithEvents lblSkinPinchReturn As System.Windows.Forms.Label
    Friend WithEvents cboSevereWasting As System.Windows.Forms.ComboBox
    Friend WithEvents pnlRespiratorySystem As System.Windows.Forms.Panel
    Friend WithEvents lblAirway As System.Windows.Forms.Label
    Friend WithEvents lblCrackles As System.Windows.Forms.Label
    Friend WithEvents cboCrackles As System.Windows.Forms.ComboBox
    Friend WithEvents cboAirway As System.Windows.Forms.ComboBox
    Friend WithEvents lblPleuralRub As System.Windows.Forms.Label
    Friend WithEvents cboPleuralRub As System.Windows.Forms.ComboBox
    Friend WithEvents cboWheezing As System.Windows.Forms.ComboBox
    Friend WithEvents lblWheezing As System.Windows.Forms.Label
    Friend WithEvents lblDeepBreathing As System.Windows.Forms.Label
    Friend WithEvents lblCapRefill As System.Windows.Forms.Label
    Friend WithEvents cboCapRefill As System.Windows.Forms.ComboBox
    Friend WithEvents lblPulse As System.Windows.Forms.Label
    Friend WithEvents cboPulse As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubcostalRecession As System.Windows.Forms.Label
    Friend WithEvents cboSubcostalRecession As System.Windows.Forms.ComboBox
    Friend WithEvents cboDeepBreathing As System.Windows.Forms.ComboBox
    Friend WithEvents lblIntercostalRecession As System.Windows.Forms.Label
    Friend WithEvents cboIntercostalRecession As System.Windows.Forms.ComboBox
    Friend WithEvents cboFlaringOfNostrils As System.Windows.Forms.ComboBox
    Friend WithEvents lblFlaringOfNostrils As System.Windows.Forms.Label
    Friend WithEvents pnlCentralNervousSystem As System.Windows.Forms.Panel
    Friend WithEvents lblUnconscious As System.Windows.Forms.Label
    Friend WithEvents lblKerningsSign As System.Windows.Forms.Label
    Friend WithEvents cboKerningsSign As System.Windows.Forms.ComboBox
    Friend WithEvents lblStiffNeck As System.Windows.Forms.Label
    Friend WithEvents cboStiffNeck As System.Windows.Forms.ComboBox
    Friend WithEvents lblBulgingFontanelle As System.Windows.Forms.Label
    Friend WithEvents cboBulgingFontanelle As System.Windows.Forms.ComboBox
    Friend WithEvents cboUnconscious As System.Windows.Forms.ComboBox
    Friend WithEvents lblUnableToSitStand As System.Windows.Forms.Label
    Friend WithEvents cboUnableToSitStand As System.Windows.Forms.ComboBox
    Friend WithEvents cboLethargic As System.Windows.Forms.ComboBox
    Friend WithEvents lblLethargic As System.Windows.Forms.Label
    Friend WithEvents pnlInitialLaboratoryResults As System.Windows.Forms.Panel
    Friend WithEvents dgvLabResults As System.Windows.Forms.DataGridView
    Friend WithEvents colSpecimenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResult As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResultFlag As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNormalRange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResultDataType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlBloodTransfusion As System.Windows.Forms.Panel
    Friend WithEvents pnlBloodTransfusionNotGivenStateReasons As System.Windows.Forms.Panel
    Friend WithEvents lblBloodUnits As System.Windows.Forms.Label
    Friend WithEvents dtpTransfusionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTransfusionDate As System.Windows.Forms.Label
    Friend WithEvents lblMl As System.Windows.Forms.Label
    Friend WithEvents lblIfYesVolume As System.Windows.Forms.Label
    Friend WithEvents clbBloodTransfusionNotGivenStateReasons As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlBloodTransfusionStateReasons As System.Windows.Forms.Panel
    Friend WithEvents clbBloodTransfusionStateReasons As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboIfDesiredWasBloodGiven As System.Windows.Forms.ComboBox
    Friend WithEvents lblIfDesiredWasBloodGiven As System.Windows.Forms.Label
    Friend WithEvents lblIfYesStateReasons As System.Windows.Forms.Label
    Friend WithEvents cboIsBloodTransfusionDesired As System.Windows.Forms.ComboBox
    Friend WithEvents lblIsBloodTransfusionDesired As System.Windows.Forms.Label
    Friend WithEvents pnlOtherFormsOfSupportiveCare As System.Windows.Forms.Panel
    Friend WithEvents clbOtherFormsOfSupportiveCare As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlReasonsForDiagnosisOfSevereComplicationMalaria As System.Windows.Forms.Panel
    Friend WithEvents clbReasonsForDiagnosisOfSevereComplicatedMalaria As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlReasonsForAdmissionWithPositiveMalariaTest As System.Windows.Forms.Panel
    Friend WithEvents clbReasonsForAdmissionWithPositiveMalariaTest As System.Windows.Forms.CheckedListBox
    Friend WithEvents nbxBloodUnits As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxIfYesVolume As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents pnlPatientDetails As System.Windows.Forms.Panel

End Class