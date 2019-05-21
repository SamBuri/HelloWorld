
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmINTPara : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(ByVal admissionNo As String)
        MyClass.New()
        Me.defaultAdmissionNo = admissionNo
    End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmINTPara))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbStudyID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAssessmentSite = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpAssessmentDate = New System.Windows.Forms.DateTimePicker()
        Me.cboGenderID = New System.Windows.Forms.ComboBox()
        Me.nbxBirthYear = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxEstimatedYears = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxMUAC = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCalculatedZScoreAgeWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbTabletOxygenSaturation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxTabletHeartRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxSQI = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbSpO2TrendFile = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSP02RedFile = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSp02InfraredFile = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAnotherDeviceSOP2 = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboHIVStatus = New System.Windows.Forms.ComboBox()
        Me.nbxPostDischargeMortalityRisk = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.stbConfirmStudyID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpSpO2Time = New System.Windows.Forms.DateTimePicker()
        Me.cboBirthMonth = New System.Windows.Forms.ComboBox()
        Me.cbolastHospitalized = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.lblStudyID = New System.Windows.Forms.Label()
        Me.lblAssessmentSite = New System.Windows.Forms.Label()
        Me.lblAssessmentDate = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblBirthYear = New System.Windows.Forms.Label()
        Me.lblBirthMonth = New System.Windows.Forms.Label()
        Me.lblEstimatedYears = New System.Windows.Forms.Label()
        Me.lblLastHospitalized = New System.Windows.Forms.Label()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblMUAC = New System.Windows.Forms.Label()
        Me.lblCalculatedZScoreAgeWeight = New System.Windows.Forms.Label()
        Me.lblTabletOxygenSaturation = New System.Windows.Forms.Label()
        Me.lblTabletHeartRate = New System.Windows.Forms.Label()
        Me.lblSQI = New System.Windows.Forms.Label()
        Me.lblSpO2Time = New System.Windows.Forms.Label()
        Me.lblSpO2TrendFile = New System.Windows.Forms.Label()
        Me.lblSP02RedFile = New System.Windows.Forms.Label()
        Me.lblSp02InfraredFile = New System.Windows.Forms.Label()
        Me.lblAnotherDeviceSOP2 = New System.Windows.Forms.Label()
        Me.lblEyeMovement = New System.Windows.Forms.Label()
        Me.lblBestMotorResponse = New System.Windows.Forms.Label()
        Me.lblBestVerbalResponse = New System.Windows.Forms.Label()
        Me.lblHIVStatus = New System.Windows.Forms.Label()
        Me.lblPostDischargeMortalityRisk = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblBrthDate = New System.Windows.Forms.Label()
        Me.btnLoadAdmissions = New System.Windows.Forms.Button()
        Me.lblConfirmStudyID = New System.Windows.Forms.Label()
        Me.cboEyeMovement = New System.Windows.Forms.ComboBox()
        Me.cboBestMotorResponse = New System.Windows.Forms.ComboBox()
        Me.cboBestVerbalResponse = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 369)
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
        Me.fbnDelete.Location = New System.Drawing.Point(856, 368)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "INTPara"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 396)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "INTPara"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbStudyID
        '
        Me.stbStudyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStudyID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbStudyID, "StudyID")
        Me.stbStudyID.EntryErrorMSG = ""
        Me.stbStudyID.Location = New System.Drawing.Point(218, 35)
        Me.stbStudyID.Name = "stbStudyID"
        Me.stbStudyID.RegularExpression = ""
        Me.stbStudyID.Size = New System.Drawing.Size(211, 20)
        Me.stbStudyID.TabIndex = 8
        '
        'stbAssessmentSite
        '
        Me.stbAssessmentSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAssessmentSite.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAssessmentSite, "AssessmentSite")
        Me.stbAssessmentSite.EntryErrorMSG = ""
        Me.stbAssessmentSite.Location = New System.Drawing.Point(218, 84)
        Me.stbAssessmentSite.Name = "stbAssessmentSite"
        Me.stbAssessmentSite.RegularExpression = ""
        Me.stbAssessmentSite.Size = New System.Drawing.Size(211, 20)
        Me.stbAssessmentSite.TabIndex = 10
        '
        'dtpAssessmentDate
        '
        Me.dtpAssessmentDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpAssessmentDate, "AssessmentDate")
        Me.dtpAssessmentDate.Location = New System.Drawing.Point(218, 107)
        Me.dtpAssessmentDate.Name = "dtpAssessmentDate"
        Me.dtpAssessmentDate.ShowCheckBox = True
        Me.dtpAssessmentDate.Size = New System.Drawing.Size(211, 20)
        Me.dtpAssessmentDate.TabIndex = 12
        '
        'cboGenderID
        '
        Me.cboGenderID.BackColor = System.Drawing.SystemColors.Info
        Me.ebnSaveUpdate.SetDataMember(Me.cboGenderID, "Gender,GenderID")
        Me.cboGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGenderID.Enabled = False
        Me.cboGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGenderID.Location = New System.Drawing.Point(720, 79)
        Me.cboGenderID.Name = "cboGenderID"
        Me.cboGenderID.Size = New System.Drawing.Size(208, 21)
        Me.cboGenderID.TabIndex = 14
        '
        'nbxBirthYear
        '
        Me.nbxBirthYear.BackColor = System.Drawing.SystemColors.Info
        Me.nbxBirthYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBirthYear.ControlCaption = "Birth Year"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxBirthYear, "BirthYear")
        Me.nbxBirthYear.DecimalPlaces = -1
        Me.nbxBirthYear.Enabled = False
        Me.nbxBirthYear.Location = New System.Drawing.Point(720, 124)
        Me.nbxBirthYear.MaxValue = 0.0R
        Me.nbxBirthYear.MinValue = 0.0R
        Me.nbxBirthYear.MustEnterNumeric = True
        Me.nbxBirthYear.Name = "nbxBirthYear"
        Me.nbxBirthYear.Size = New System.Drawing.Size(208, 20)
        Me.nbxBirthYear.TabIndex = 16
        Me.nbxBirthYear.Value = ""
        '
        'nbxEstimatedYears
        '
        Me.nbxEstimatedYears.BackColor = System.Drawing.SystemColors.Info
        Me.nbxEstimatedYears.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxEstimatedYears.ControlCaption = "Estimated Age (years)"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxEstimatedYears, "EstimatedYears")
        Me.nbxEstimatedYears.DecimalPlaces = -1
        Me.nbxEstimatedYears.Enabled = False
        Me.nbxEstimatedYears.Location = New System.Drawing.Point(720, 102)
        Me.nbxEstimatedYears.MaxValue = 0.0R
        Me.nbxEstimatedYears.MinValue = 0.0R
        Me.nbxEstimatedYears.MustEnterNumeric = True
        Me.nbxEstimatedYears.Name = "nbxEstimatedYears"
        Me.nbxEstimatedYears.Size = New System.Drawing.Size(208, 20)
        Me.nbxEstimatedYears.TabIndex = 20
        Me.nbxEstimatedYears.Value = ""
        '
        'nbxWeight
        '
        Me.nbxWeight.BackColor = System.Drawing.SystemColors.Info
        Me.nbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxWeight.ControlCaption = "Weight"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxWeight, "Weight")
        Me.nbxWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxWeight.DecimalPlaces = -1
        Me.nbxWeight.Enabled = False
        Me.nbxWeight.Location = New System.Drawing.Point(721, 172)
        Me.nbxWeight.MaxValue = 0.0R
        Me.nbxWeight.MinValue = 0.0R
        Me.nbxWeight.MustEnterNumeric = True
        Me.nbxWeight.Name = "nbxWeight"
        Me.nbxWeight.Size = New System.Drawing.Size(208, 20)
        Me.nbxWeight.TabIndex = 24
        Me.nbxWeight.Value = ""
        '
        'nbxMUAC
        '
        Me.nbxMUAC.BackColor = System.Drawing.SystemColors.Window
        Me.nbxMUAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMUAC.ControlCaption = "Mid-Upper Arm Circumference"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMUAC, "MUAC")
        Me.nbxMUAC.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxMUAC.DecimalPlaces = -1
        Me.nbxMUAC.Location = New System.Drawing.Point(720, 195)
        Me.nbxMUAC.MaxValue = 0.0R
        Me.nbxMUAC.MinValue = 0.0R
        Me.nbxMUAC.MustEnterNumeric = True
        Me.nbxMUAC.Name = "nbxMUAC"
        Me.nbxMUAC.Size = New System.Drawing.Size(209, 20)
        Me.nbxMUAC.TabIndex = 26
        Me.nbxMUAC.Value = ""
        '
        'nbxCalculatedZScoreAgeWeight
        '
        Me.nbxCalculatedZScoreAgeWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCalculatedZScoreAgeWeight.ControlCaption = "Calculated Weight for Age Z-Score"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCalculatedZScoreAgeWeight, "CalculatedZScoreAgeWeight")
        Me.nbxCalculatedZScoreAgeWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCalculatedZScoreAgeWeight.DecimalPlaces = -1
        Me.nbxCalculatedZScoreAgeWeight.Location = New System.Drawing.Point(218, 156)
        Me.nbxCalculatedZScoreAgeWeight.MaxValue = 0.0R
        Me.nbxCalculatedZScoreAgeWeight.MinValue = 0.0R
        Me.nbxCalculatedZScoreAgeWeight.MustEnterNumeric = True
        Me.nbxCalculatedZScoreAgeWeight.Name = "nbxCalculatedZScoreAgeWeight"
        Me.nbxCalculatedZScoreAgeWeight.Size = New System.Drawing.Size(211, 20)
        Me.nbxCalculatedZScoreAgeWeight.TabIndex = 28
        Me.nbxCalculatedZScoreAgeWeight.Value = ""
        '
        'stbTabletOxygenSaturation
        '
        Me.stbTabletOxygenSaturation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTabletOxygenSaturation.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTabletOxygenSaturation, "TabletOxygenSaturation")
        Me.stbTabletOxygenSaturation.EntryErrorMSG = ""
        Me.stbTabletOxygenSaturation.Location = New System.Drawing.Point(218, 179)
        Me.stbTabletOxygenSaturation.Name = "stbTabletOxygenSaturation"
        Me.stbTabletOxygenSaturation.RegularExpression = ""
        Me.stbTabletOxygenSaturation.Size = New System.Drawing.Size(211, 20)
        Me.stbTabletOxygenSaturation.TabIndex = 30
        '
        'nbxTabletHeartRate
        '
        Me.nbxTabletHeartRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTabletHeartRate.ControlCaption = "Tablet heart rate"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxTabletHeartRate, "TabletHeartRate")
        Me.nbxTabletHeartRate.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxTabletHeartRate.DecimalPlaces = -1
        Me.nbxTabletHeartRate.Location = New System.Drawing.Point(218, 202)
        Me.nbxTabletHeartRate.MaxValue = 0.0R
        Me.nbxTabletHeartRate.MinValue = 0.0R
        Me.nbxTabletHeartRate.MustEnterNumeric = True
        Me.nbxTabletHeartRate.Name = "nbxTabletHeartRate"
        Me.nbxTabletHeartRate.Size = New System.Drawing.Size(211, 20)
        Me.nbxTabletHeartRate.TabIndex = 32
        Me.nbxTabletHeartRate.Value = ""
        '
        'nbxSQI
        '
        Me.nbxSQI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSQI.ControlCaption = "SQI"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxSQI, "SQI")
        Me.nbxSQI.DecimalPlaces = -1
        Me.nbxSQI.Location = New System.Drawing.Point(218, 225)
        Me.nbxSQI.MaxValue = 0.0R
        Me.nbxSQI.MinValue = 0.0R
        Me.nbxSQI.MustEnterNumeric = True
        Me.nbxSQI.Name = "nbxSQI"
        Me.nbxSQI.Size = New System.Drawing.Size(211, 20)
        Me.nbxSQI.TabIndex = 34
        Me.nbxSQI.Value = ""
        '
        'stbSpO2TrendFile
        '
        Me.stbSpO2TrendFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpO2TrendFile.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSpO2TrendFile, "SpO2TrendFile")
        Me.stbSpO2TrendFile.EntryErrorMSG = ""
        Me.stbSpO2TrendFile.Location = New System.Drawing.Point(218, 271)
        Me.stbSpO2TrendFile.Name = "stbSpO2TrendFile"
        Me.stbSpO2TrendFile.RegularExpression = ""
        Me.stbSpO2TrendFile.Size = New System.Drawing.Size(211, 20)
        Me.stbSpO2TrendFile.TabIndex = 38
        '
        'stbSP02RedFile
        '
        Me.stbSP02RedFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSP02RedFile.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSP02RedFile, "SP02RedFile")
        Me.stbSP02RedFile.EntryErrorMSG = ""
        Me.stbSP02RedFile.Location = New System.Drawing.Point(218, 294)
        Me.stbSP02RedFile.Name = "stbSP02RedFile"
        Me.stbSP02RedFile.RegularExpression = ""
        Me.stbSP02RedFile.Size = New System.Drawing.Size(211, 20)
        Me.stbSP02RedFile.TabIndex = 40
        '
        'stbSp02InfraredFile
        '
        Me.stbSp02InfraredFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSp02InfraredFile.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSp02InfraredFile, "Sp02InfraredFile")
        Me.stbSp02InfraredFile.EntryErrorMSG = ""
        Me.stbSp02InfraredFile.Location = New System.Drawing.Point(218, 317)
        Me.stbSp02InfraredFile.Name = "stbSp02InfraredFile"
        Me.stbSp02InfraredFile.RegularExpression = ""
        Me.stbSp02InfraredFile.Size = New System.Drawing.Size(211, 20)
        Me.stbSp02InfraredFile.TabIndex = 42
        '
        'stbAnotherDeviceSOP2
        '
        Me.stbAnotherDeviceSOP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAnotherDeviceSOP2.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAnotherDeviceSOP2, "AnotherDeviceSOP2")
        Me.stbAnotherDeviceSOP2.EntryErrorMSG = ""
        Me.stbAnotherDeviceSOP2.Location = New System.Drawing.Point(218, 339)
        Me.stbAnotherDeviceSOP2.Name = "stbAnotherDeviceSOP2"
        Me.stbAnotherDeviceSOP2.RegularExpression = ""
        Me.stbAnotherDeviceSOP2.Size = New System.Drawing.Size(211, 20)
        Me.stbAnotherDeviceSOP2.TabIndex = 44
        '
        'cboHIVStatus
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHIVStatus, "HIVStatus")
        Me.cboHIVStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHIVStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHIVStatus.Location = New System.Drawing.Point(721, 288)
        Me.cboHIVStatus.Name = "cboHIVStatus"
        Me.cboHIVStatus.Size = New System.Drawing.Size(208, 21)
        Me.cboHIVStatus.TabIndex = 52
        '
        'nbxPostDischargeMortalityRisk
        '
        Me.nbxPostDischargeMortalityRisk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPostDischargeMortalityRisk.ControlCaption = "Post-Discharge Risk of Mortality"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxPostDischargeMortalityRisk, "PostDischargeMortalityRisk")
        Me.nbxPostDischargeMortalityRisk.DecimalPlaces = -1
        Me.nbxPostDischargeMortalityRisk.Location = New System.Drawing.Point(721, 311)
        Me.nbxPostDischargeMortalityRisk.MaxValue = 0.0R
        Me.nbxPostDischargeMortalityRisk.MinValue = 0.0R
        Me.nbxPostDischargeMortalityRisk.MustEnterNumeric = True
        Me.nbxPostDischargeMortalityRisk.Name = "nbxPostDischargeMortalityRisk"
        Me.nbxPostDischargeMortalityRisk.Size = New System.Drawing.Size(208, 20)
        Me.nbxPostDischargeMortalityRisk.TabIndex = 54
        Me.nbxPostDischargeMortalityRisk.Value = ""
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(720, 10)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(208, 20)
        Me.stbPatientNo.TabIndex = 59
        '
        'stbFullName
        '
        Me.stbFullName.BackColor = System.Drawing.SystemColors.Info
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(720, 32)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(208, 20)
        Me.stbFullName.TabIndex = 57
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Enabled = False
        Me.dtpBirthDate.Location = New System.Drawing.Point(720, 56)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(206, 20)
        Me.dtpBirthDate.TabIndex = 60
        '
        'stbConfirmStudyID
        '
        Me.stbConfirmStudyID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConfirmStudyID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbConfirmStudyID, "StudyID")
        Me.stbConfirmStudyID.EntryErrorMSG = ""
        Me.stbConfirmStudyID.Location = New System.Drawing.Point(218, 58)
        Me.stbConfirmStudyID.Name = "stbConfirmStudyID"
        Me.stbConfirmStudyID.RegularExpression = ""
        Me.stbConfirmStudyID.Size = New System.Drawing.Size(211, 20)
        Me.stbConfirmStudyID.TabIndex = 63
        '
        'dtpSpO2Time
        '
        Me.dtpSpO2Time.Checked = False
        Me.dtpSpO2Time.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpSpO2Time, "SpO2Time")
        Me.dtpSpO2Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSpO2Time.Location = New System.Drawing.Point(218, 248)
        Me.dtpSpO2Time.Name = "dtpSpO2Time"
        Me.dtpSpO2Time.ShowCheckBox = True
        Me.dtpSpO2Time.Size = New System.Drawing.Size(211, 20)
        Me.dtpSpO2Time.TabIndex = 65
        '
        'cboBirthMonth
        '
        Me.cboBirthMonth.BackColor = System.Drawing.SystemColors.Info
        Me.ebnSaveUpdate.SetDataMember(Me.cboBirthMonth, "BirthMonth")
        Me.cboBirthMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBirthMonth.Enabled = False
        Me.cboBirthMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBirthMonth.Location = New System.Drawing.Point(720, 147)
        Me.cboBirthMonth.Name = "cboBirthMonth"
        Me.cboBirthMonth.Size = New System.Drawing.Size(208, 21)
        Me.cboBirthMonth.TabIndex = 66
        '
        'cbolastHospitalized
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cbolastHospitalized, "HIVStatus")
        Me.cbolastHospitalized.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbolastHospitalized.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbolastHospitalized.Location = New System.Drawing.Point(218, 130)
        Me.cbolastHospitalized.Name = "cbolastHospitalized"
        Me.cbolastHospitalized.Size = New System.Drawing.Size(208, 21)
        Me.cbolastHospitalized.TabIndex = 67
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(856, 395)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(218, 12)
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(153, 20)
        Me.stbAdmissionNo.TabIndex = 6
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.Location = New System.Drawing.Point(12, 12)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(200, 20)
        Me.lblAdmissionNo.TabIndex = 7
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'lblStudyID
        '
        Me.lblStudyID.Location = New System.Drawing.Point(12, 35)
        Me.lblStudyID.Name = "lblStudyID"
        Me.lblStudyID.Size = New System.Drawing.Size(200, 20)
        Me.lblStudyID.TabIndex = 9
        Me.lblStudyID.Text = "Study ID"
        '
        'lblAssessmentSite
        '
        Me.lblAssessmentSite.Location = New System.Drawing.Point(12, 84)
        Me.lblAssessmentSite.Name = "lblAssessmentSite"
        Me.lblAssessmentSite.Size = New System.Drawing.Size(200, 20)
        Me.lblAssessmentSite.TabIndex = 11
        Me.lblAssessmentSite.Text = "Assessment Site"
        '
        'lblAssessmentDate
        '
        Me.lblAssessmentDate.Location = New System.Drawing.Point(12, 107)
        Me.lblAssessmentDate.Name = "lblAssessmentDate"
        Me.lblAssessmentDate.Size = New System.Drawing.Size(200, 20)
        Me.lblAssessmentDate.TabIndex = 13
        Me.lblAssessmentDate.Text = "Assessment Date"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(460, 79)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(237, 20)
        Me.lblGenderID.TabIndex = 15
        Me.lblGenderID.Text = "Gender"
        '
        'lblBirthYear
        '
        Me.lblBirthYear.Location = New System.Drawing.Point(460, 126)
        Me.lblBirthYear.Name = "lblBirthYear"
        Me.lblBirthYear.Size = New System.Drawing.Size(237, 20)
        Me.lblBirthYear.TabIndex = 17
        Me.lblBirthYear.Text = "Birth Year"
        '
        'lblBirthMonth
        '
        Me.lblBirthMonth.Location = New System.Drawing.Point(460, 147)
        Me.lblBirthMonth.Name = "lblBirthMonth"
        Me.lblBirthMonth.Size = New System.Drawing.Size(237, 20)
        Me.lblBirthMonth.TabIndex = 19
        Me.lblBirthMonth.Text = "Birth Month"
        '
        'lblEstimatedYears
        '
        Me.lblEstimatedYears.Location = New System.Drawing.Point(460, 106)
        Me.lblEstimatedYears.Name = "lblEstimatedYears"
        Me.lblEstimatedYears.Size = New System.Drawing.Size(237, 20)
        Me.lblEstimatedYears.TabIndex = 21
        Me.lblEstimatedYears.Text = "Estimated Age (years)"
        '
        'lblLastHospitalized
        '
        Me.lblLastHospitalized.Location = New System.Drawing.Point(12, 133)
        Me.lblLastHospitalized.Name = "lblLastHospitalized"
        Me.lblLastHospitalized.Size = New System.Drawing.Size(200, 20)
        Me.lblLastHospitalized.TabIndex = 23
        Me.lblLastHospitalized.Text = "Last Hospitalized"
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(459, 169)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(237, 20)
        Me.lblWeight.TabIndex = 25
        Me.lblWeight.Text = "Weight"
        '
        'lblMUAC
        '
        Me.lblMUAC.Location = New System.Drawing.Point(460, 192)
        Me.lblMUAC.Name = "lblMUAC"
        Me.lblMUAC.Size = New System.Drawing.Size(237, 20)
        Me.lblMUAC.TabIndex = 27
        Me.lblMUAC.Text = "Mid-Upper Arm Circumference"
        '
        'lblCalculatedZScoreAgeWeight
        '
        Me.lblCalculatedZScoreAgeWeight.Location = New System.Drawing.Point(12, 156)
        Me.lblCalculatedZScoreAgeWeight.Name = "lblCalculatedZScoreAgeWeight"
        Me.lblCalculatedZScoreAgeWeight.Size = New System.Drawing.Size(200, 20)
        Me.lblCalculatedZScoreAgeWeight.TabIndex = 29
        Me.lblCalculatedZScoreAgeWeight.Text = "Calculated Weight for Age Z-Score"
        '
        'lblTabletOxygenSaturation
        '
        Me.lblTabletOxygenSaturation.Location = New System.Drawing.Point(12, 179)
        Me.lblTabletOxygenSaturation.Name = "lblTabletOxygenSaturation"
        Me.lblTabletOxygenSaturation.Size = New System.Drawing.Size(200, 20)
        Me.lblTabletOxygenSaturation.TabIndex = 31
        Me.lblTabletOxygenSaturation.Text = "Tablet oOxygen Saturation"
        '
        'lblTabletHeartRate
        '
        Me.lblTabletHeartRate.Location = New System.Drawing.Point(12, 202)
        Me.lblTabletHeartRate.Name = "lblTabletHeartRate"
        Me.lblTabletHeartRate.Size = New System.Drawing.Size(200, 20)
        Me.lblTabletHeartRate.TabIndex = 33
        Me.lblTabletHeartRate.Text = "Tablet heart rate"
        '
        'lblSQI
        '
        Me.lblSQI.Location = New System.Drawing.Point(12, 225)
        Me.lblSQI.Name = "lblSQI"
        Me.lblSQI.Size = New System.Drawing.Size(200, 20)
        Me.lblSQI.TabIndex = 35
        Me.lblSQI.Text = "SQI"
        '
        'lblSpO2Time
        '
        Me.lblSpO2Time.Location = New System.Drawing.Point(12, 248)
        Me.lblSpO2Time.Name = "lblSpO2Time"
        Me.lblSpO2Time.Size = New System.Drawing.Size(200, 20)
        Me.lblSpO2Time.TabIndex = 37
        Me.lblSpO2Time.Text = "SpO2 Time"
        '
        'lblSpO2TrendFile
        '
        Me.lblSpO2TrendFile.Location = New System.Drawing.Point(12, 271)
        Me.lblSpO2TrendFile.Name = "lblSpO2TrendFile"
        Me.lblSpO2TrendFile.Size = New System.Drawing.Size(200, 20)
        Me.lblSpO2TrendFile.TabIndex = 39
        Me.lblSpO2TrendFile.Text = "SpO2 Trend File"
        '
        'lblSP02RedFile
        '
        Me.lblSP02RedFile.Location = New System.Drawing.Point(12, 294)
        Me.lblSP02RedFile.Name = "lblSP02RedFile"
        Me.lblSP02RedFile.Size = New System.Drawing.Size(200, 20)
        Me.lblSP02RedFile.TabIndex = 41
        Me.lblSP02RedFile.Text = "SpO2 Red File"
        '
        'lblSp02InfraredFile
        '
        Me.lblSp02InfraredFile.Location = New System.Drawing.Point(12, 317)
        Me.lblSp02InfraredFile.Name = "lblSp02InfraredFile"
        Me.lblSp02InfraredFile.Size = New System.Drawing.Size(200, 20)
        Me.lblSp02InfraredFile.TabIndex = 43
        Me.lblSp02InfraredFile.Text = "SpO2 Infrared File"
        '
        'lblAnotherDeviceSOP2
        '
        Me.lblAnotherDeviceSOP2.Location = New System.Drawing.Point(12, 337)
        Me.lblAnotherDeviceSOP2.Name = "lblAnotherDeviceSOP2"
        Me.lblAnotherDeviceSOP2.Size = New System.Drawing.Size(200, 20)
        Me.lblAnotherDeviceSOP2.TabIndex = 45
        Me.lblAnotherDeviceSOP2.Text = "SpO2 from Another Device"
        '
        'lblEyeMovement
        '
        Me.lblEyeMovement.Location = New System.Drawing.Point(460, 218)
        Me.lblEyeMovement.Name = "lblEyeMovement"
        Me.lblEyeMovement.Size = New System.Drawing.Size(237, 20)
        Me.lblEyeMovement.TabIndex = 47
        Me.lblEyeMovement.Text = "Eye Movement (Blantyre Coma Scale)"
        '
        'lblBestMotorResponse
        '
        Me.lblBestMotorResponse.Location = New System.Drawing.Point(460, 241)
        Me.lblBestMotorResponse.Name = "lblBestMotorResponse"
        Me.lblBestMotorResponse.Size = New System.Drawing.Size(237, 20)
        Me.lblBestMotorResponse.TabIndex = 49
        Me.lblBestMotorResponse.Text = "Best Motor Response (Blantyre Coma Scale)"
        '
        'lblBestVerbalResponse
        '
        Me.lblBestVerbalResponse.Location = New System.Drawing.Point(460, 264)
        Me.lblBestVerbalResponse.Name = "lblBestVerbalResponse"
        Me.lblBestVerbalResponse.Size = New System.Drawing.Size(237, 20)
        Me.lblBestVerbalResponse.TabIndex = 51
        Me.lblBestVerbalResponse.Text = "Best Verbal Response (Blantyre Coma Scale)"
        '
        'lblHIVStatus
        '
        Me.lblHIVStatus.Location = New System.Drawing.Point(460, 287)
        Me.lblHIVStatus.Name = "lblHIVStatus"
        Me.lblHIVStatus.Size = New System.Drawing.Size(237, 20)
        Me.lblHIVStatus.TabIndex = 53
        Me.lblHIVStatus.Text = "HIV Status"
        '
        'lblPostDischargeMortalityRisk
        '
        Me.lblPostDischargeMortalityRisk.Location = New System.Drawing.Point(460, 313)
        Me.lblPostDischargeMortalityRisk.Name = "lblPostDischargeMortalityRisk"
        Me.lblPostDischargeMortalityRisk.Size = New System.Drawing.Size(237, 20)
        Me.lblPostDischargeMortalityRisk.TabIndex = 55
        Me.lblPostDischargeMortalityRisk.Text = "Post-Discharge Risk of Mortality"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(459, 14)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(238, 20)
        Me.lblPatientsNo.TabIndex = 58
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(459, 41)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(238, 20)
        Me.lblFullName.TabIndex = 56
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblBrthDate
        '
        Me.lblBrthDate.Location = New System.Drawing.Point(460, 61)
        Me.lblBrthDate.Name = "lblBrthDate"
        Me.lblBrthDate.Size = New System.Drawing.Size(236, 20)
        Me.lblBrthDate.TabIndex = 61
        Me.lblBrthDate.Text = "Birth Date"
        '
        'btnLoadAdmissions
        '
        Me.btnLoadAdmissions.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadAdmissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadAdmissions.Location = New System.Drawing.Point(377, 8)
        Me.btnLoadAdmissions.Name = "btnLoadAdmissions"
        Me.btnLoadAdmissions.Size = New System.Drawing.Size(52, 24)
        Me.btnLoadAdmissions.TabIndex = 62
        Me.btnLoadAdmissions.Tag = ""
        Me.btnLoadAdmissions.Text = "&Load"
        '
        'lblConfirmStudyID
        '
        Me.lblConfirmStudyID.Location = New System.Drawing.Point(12, 58)
        Me.lblConfirmStudyID.Name = "lblConfirmStudyID"
        Me.lblConfirmStudyID.Size = New System.Drawing.Size(200, 20)
        Me.lblConfirmStudyID.TabIndex = 64
        Me.lblConfirmStudyID.Text = "Confirm Study ID"
        '
        'cboEyeMovement
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEyeMovement, "HIVStatus")
        Me.cboEyeMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEyeMovement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEyeMovement.Location = New System.Drawing.Point(721, 218)
        Me.cboEyeMovement.Name = "cboEyeMovement"
        Me.cboEyeMovement.Size = New System.Drawing.Size(208, 21)
        Me.cboEyeMovement.TabIndex = 68
        '
        'cboBestMotorResponse
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBestMotorResponse, "BestMotorResponse")
        Me.cboBestMotorResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBestMotorResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBestMotorResponse.Location = New System.Drawing.Point(721, 242)
        Me.cboBestMotorResponse.Name = "cboBestMotorResponse"
        Me.cboBestMotorResponse.Size = New System.Drawing.Size(208, 21)
        Me.cboBestMotorResponse.TabIndex = 69
        '
        'cboBestVerbalResponse
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBestVerbalResponse, "BestVerbalResponse")
        Me.cboBestVerbalResponse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBestVerbalResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBestVerbalResponse.Location = New System.Drawing.Point(721, 266)
        Me.cboBestVerbalResponse.Name = "cboBestVerbalResponse"
        Me.cboBestVerbalResponse.Size = New System.Drawing.Size(208, 21)
        Me.cboBestVerbalResponse.TabIndex = 70
        '
        'frmINTPara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(933, 434)
        Me.Controls.Add(Me.cboBestVerbalResponse)
        Me.Controls.Add(Me.cboBestMotorResponse)
        Me.Controls.Add(Me.cboEyeMovement)
        Me.Controls.Add(Me.cbolastHospitalized)
        Me.Controls.Add(Me.cboBirthMonth)
        Me.Controls.Add(Me.dtpSpO2Time)
        Me.Controls.Add(Me.stbConfirmStudyID)
        Me.Controls.Add(Me.lblConfirmStudyID)
        Me.Controls.Add(Me.btnLoadAdmissions)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.lblBrthDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbStudyID)
        Me.Controls.Add(Me.lblStudyID)
        Me.Controls.Add(Me.stbAssessmentSite)
        Me.Controls.Add(Me.lblAssessmentSite)
        Me.Controls.Add(Me.dtpAssessmentDate)
        Me.Controls.Add(Me.lblAssessmentDate)
        Me.Controls.Add(Me.cboGenderID)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.nbxBirthYear)
        Me.Controls.Add(Me.lblBirthYear)
        Me.Controls.Add(Me.lblBirthMonth)
        Me.Controls.Add(Me.nbxEstimatedYears)
        Me.Controls.Add(Me.lblEstimatedYears)
        Me.Controls.Add(Me.lblLastHospitalized)
        Me.Controls.Add(Me.nbxWeight)
        Me.Controls.Add(Me.lblWeight)
        Me.Controls.Add(Me.nbxMUAC)
        Me.Controls.Add(Me.lblMUAC)
        Me.Controls.Add(Me.nbxCalculatedZScoreAgeWeight)
        Me.Controls.Add(Me.lblCalculatedZScoreAgeWeight)
        Me.Controls.Add(Me.stbTabletOxygenSaturation)
        Me.Controls.Add(Me.lblTabletOxygenSaturation)
        Me.Controls.Add(Me.nbxTabletHeartRate)
        Me.Controls.Add(Me.lblTabletHeartRate)
        Me.Controls.Add(Me.nbxSQI)
        Me.Controls.Add(Me.lblSQI)
        Me.Controls.Add(Me.lblSpO2Time)
        Me.Controls.Add(Me.stbSpO2TrendFile)
        Me.Controls.Add(Me.lblSpO2TrendFile)
        Me.Controls.Add(Me.stbSP02RedFile)
        Me.Controls.Add(Me.lblSP02RedFile)
        Me.Controls.Add(Me.stbSp02InfraredFile)
        Me.Controls.Add(Me.lblSp02InfraredFile)
        Me.Controls.Add(Me.stbAnotherDeviceSOP2)
        Me.Controls.Add(Me.lblAnotherDeviceSOP2)
        Me.Controls.Add(Me.lblEyeMovement)
        Me.Controls.Add(Me.lblBestMotorResponse)
        Me.Controls.Add(Me.lblBestVerbalResponse)
        Me.Controls.Add(Me.cboHIVStatus)
        Me.Controls.Add(Me.lblHIVStatus)
        Me.Controls.Add(Me.nbxPostDischargeMortalityRisk)
        Me.Controls.Add(Me.lblPostDischargeMortalityRisk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmINTPara"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Para"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents stbStudyID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStudyID As System.Windows.Forms.Label
    Friend WithEvents stbAssessmentSite As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAssessmentSite As System.Windows.Forms.Label
    Friend WithEvents dtpAssessmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAssessmentDate As System.Windows.Forms.Label
    Friend WithEvents cboGenderID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents nbxBirthYear As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBirthYear As System.Windows.Forms.Label
    Friend WithEvents lblBirthMonth As System.Windows.Forms.Label
    Friend WithEvents nbxEstimatedYears As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblEstimatedYears As System.Windows.Forms.Label
    Friend WithEvents lblLastHospitalized As System.Windows.Forms.Label
    Friend WithEvents nbxWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents nbxMUAC As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMUAC As System.Windows.Forms.Label
    Friend WithEvents nbxCalculatedZScoreAgeWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCalculatedZScoreAgeWeight As System.Windows.Forms.Label
    Friend WithEvents stbTabletOxygenSaturation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTabletOxygenSaturation As System.Windows.Forms.Label
    Friend WithEvents nbxTabletHeartRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblTabletHeartRate As System.Windows.Forms.Label
    Friend WithEvents nbxSQI As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblSQI As System.Windows.Forms.Label
    Friend WithEvents lblSpO2Time As System.Windows.Forms.Label
    Friend WithEvents stbSpO2TrendFile As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpO2TrendFile As System.Windows.Forms.Label
    Friend WithEvents stbSP02RedFile As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSP02RedFile As System.Windows.Forms.Label
    Friend WithEvents stbSp02InfraredFile As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSp02InfraredFile As System.Windows.Forms.Label
    Friend WithEvents stbAnotherDeviceSOP2 As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAnotherDeviceSOP2 As System.Windows.Forms.Label
    Friend WithEvents lblEyeMovement As System.Windows.Forms.Label
    Friend WithEvents lblBestMotorResponse As System.Windows.Forms.Label
    Friend WithEvents lblBestVerbalResponse As System.Windows.Forms.Label
    Friend WithEvents cboHIVStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblHIVStatus As System.Windows.Forms.Label
    Friend WithEvents nbxPostDischargeMortalityRisk As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblPostDischargeMortalityRisk As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBrthDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadAdmissions As System.Windows.Forms.Button
    Friend WithEvents stbConfirmStudyID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConfirmStudyID As System.Windows.Forms.Label
    Friend WithEvents dtpSpO2Time As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBirthMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cbolastHospitalized As System.Windows.Forms.ComboBox
    Friend WithEvents cboEyeMovement As System.Windows.Forms.ComboBox
    Friend WithEvents cboBestMotorResponse As System.Windows.Forms.ComboBox
    Friend WithEvents cboBestVerbalResponse As System.Windows.Forms.ComboBox

End Class