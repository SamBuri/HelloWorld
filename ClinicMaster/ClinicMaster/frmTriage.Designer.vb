
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTriage : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultVisitNo = visitNo
        Me.noCallOnKeyEdit = disableCallOnKeyEdit
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTriage))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.nbxWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxTemperature = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxHeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxPulse = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxHeadCircum = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxBodySurfaceArea = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBloodPressure = New System.Windows.Forms.Label()
        Me.stbBloodPressure = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxBMI = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxRespirationRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxHeartRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxOxygenSaturation = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboTriagePriority = New System.Windows.Forms.ComboBox()
        Me.cboBMIStatusID = New System.Windows.Forms.ComboBox()
        Me.cboMUACStatusID = New System.Windows.Forms.ComboBox()
        Me.nbxMUAC = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblTemperature = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblPulse = New System.Windows.Forms.Label()
        Me.lblHeadCircum = New System.Windows.Forms.Label()
        Me.lblBodySurfaceArea = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHospitalPID = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.lblBMI = New System.Windows.Forms.Label()
        Me.lblRespirationRate = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.chkHideSelfRequest = New System.Windows.Forms.CheckBox()
        Me.btnPendingVisitTriage = New System.Windows.Forms.Button()
        Me.lblAlertMessage = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.lblHeartRate = New System.Windows.Forms.Label()
        Me.lblOxygenSaturation = New System.Windows.Forms.Label()
        Me.pnlVisitsPriority = New System.Windows.Forms.Panel()
        Me.lblVisitPriority = New System.Windows.Forms.Label()
        Me.stbDoctorSpecialty = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDoctorSpecialty = New System.Windows.Forms.Label()
        Me.stbTToSeeDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblToSeeDoctor = New System.Windows.Forms.Label()
        Me.lblBMIStatusID = New System.Windows.Forms.Label()
        Me.lblMUACStatusID = New System.Windows.Forms.Label()
        Me.lblMUAC = New System.Windows.Forms.Label()
        Me.EditBtnTB = New SyncSoft.Common.Win.Controls.EditButton()
        Me.EditPatients = New SyncSoft.Common.Win.Controls.EditButton()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlerts.SuspendLayout()
        Me.pnlVisitsPriority.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 438)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 53
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(496, 437)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 57
        Me.fbnDelete.Tag = "Triage"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 465)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 54
        Me.ebnSaveUpdate.Tag = "Triage"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'nbxWeight
        '
        Me.nbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxWeight.ControlCaption = "Weight"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxWeight, "Weight")
        Me.nbxWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxWeight.DecimalPlaces = 2
        Me.nbxWeight.Location = New System.Drawing.Point(159, 89)
        Me.nbxWeight.MaxLength = 6
        Me.nbxWeight.MaxValue = 200.0R
        Me.nbxWeight.MinValue = 1.0R
        Me.nbxWeight.MustEnterNumeric = True
        Me.nbxWeight.Name = "nbxWeight"
        Me.nbxWeight.Size = New System.Drawing.Size(149, 20)
        Me.nbxWeight.TabIndex = 6
        Me.nbxWeight.Value = ""
        '
        'nbxTemperature
        '
        Me.nbxTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTemperature.ControlCaption = "Temperature"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxTemperature, "Temperature")
        Me.nbxTemperature.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxTemperature.DecimalPlaces = 2
        Me.nbxTemperature.Location = New System.Drawing.Point(159, 110)
        Me.nbxTemperature.MaxLength = 5
        Me.nbxTemperature.MaxValue = 45.0R
        Me.nbxTemperature.MinValue = 30.0R
        Me.nbxTemperature.MustEnterNumeric = True
        Me.nbxTemperature.Name = "nbxTemperature"
        Me.nbxTemperature.Size = New System.Drawing.Size(149, 20)
        Me.nbxTemperature.TabIndex = 8
        Me.nbxTemperature.Value = ""
        '
        'nbxHeight
        '
        Me.nbxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeight.ControlCaption = "Height"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxHeight, "Height")
        Me.nbxHeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxHeight.DecimalPlaces = 2
        Me.nbxHeight.Location = New System.Drawing.Point(159, 153)
        Me.nbxHeight.MaxLength = 6
        Me.nbxHeight.MaxValue = 300.0R
        Me.nbxHeight.MinValue = 20.0R
        Me.nbxHeight.MustEnterNumeric = True
        Me.nbxHeight.Name = "nbxHeight"
        Me.nbxHeight.Size = New System.Drawing.Size(149, 20)
        Me.nbxHeight.TabIndex = 12
        Me.nbxHeight.Value = ""
        '
        'nbxPulse
        '
        Me.nbxPulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPulse.ControlCaption = "Pulse"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxPulse, "Pulse")
        Me.nbxPulse.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxPulse.DecimalPlaces = -1
        Me.nbxPulse.Location = New System.Drawing.Point(159, 174)
        Me.nbxPulse.MaxLength = 3
        Me.nbxPulse.MaxValue = 250.0R
        Me.nbxPulse.MinValue = 20.0R
        Me.nbxPulse.MustEnterNumeric = True
        Me.nbxPulse.Name = "nbxPulse"
        Me.nbxPulse.Size = New System.Drawing.Size(149, 20)
        Me.nbxPulse.TabIndex = 14
        Me.nbxPulse.Value = ""
        '
        'nbxHeadCircum
        '
        Me.nbxHeadCircum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeadCircum.ControlCaption = "Head Circum"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxHeadCircum, "HeadCircum")
        Me.nbxHeadCircum.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxHeadCircum.DecimalPlaces = 2
        Me.nbxHeadCircum.Location = New System.Drawing.Point(159, 216)
        Me.nbxHeadCircum.MaxLength = 6
        Me.nbxHeadCircum.MaxValue = 100.0R
        Me.nbxHeadCircum.MinValue = 30.0R
        Me.nbxHeadCircum.MustEnterNumeric = True
        Me.nbxHeadCircum.Name = "nbxHeadCircum"
        Me.nbxHeadCircum.Size = New System.Drawing.Size(149, 20)
        Me.nbxHeadCircum.TabIndex = 18
        Me.nbxHeadCircum.Value = ""
        '
        'nbxBodySurfaceArea
        '
        Me.nbxBodySurfaceArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBodySurfaceArea.ControlCaption = "Body Surface Area"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxBodySurfaceArea, "BodySurfaceArea")
        Me.nbxBodySurfaceArea.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBodySurfaceArea.DecimalPlaces = 2
        Me.nbxBodySurfaceArea.Location = New System.Drawing.Point(159, 237)
        Me.nbxBodySurfaceArea.MaxLength = 8
        Me.nbxBodySurfaceArea.MaxValue = 0.0R
        Me.nbxBodySurfaceArea.MinValue = 0.0R
        Me.nbxBodySurfaceArea.MustEnterNumeric = True
        Me.nbxBodySurfaceArea.Name = "nbxBodySurfaceArea"
        Me.nbxBodySurfaceArea.Size = New System.Drawing.Size(149, 20)
        Me.nbxBodySurfaceArea.TabIndex = 20
        Me.nbxBodySurfaceArea.Value = ""
        '
        'lblBloodPressure
        '
        Me.ebnSaveUpdate.SetDataMember(Me.lblBloodPressure, "BloodPressure")
        Me.lblBloodPressure.Location = New System.Drawing.Point(10, 195)
        Me.lblBloodPressure.Name = "lblBloodPressure"
        Me.lblBloodPressure.Size = New System.Drawing.Size(143, 21)
        Me.lblBloodPressure.TabIndex = 15
        Me.lblBloodPressure.Text = "Blood Pressure (mmHg)"
        '
        'stbBloodPressure
        '
        Me.stbBloodPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBloodPressure.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBloodPressure, "BloodPressure")
        Me.stbBloodPressure.EntryErrorMSG = "Must enter in the form 999/999"
        Me.stbBloodPressure.Location = New System.Drawing.Point(159, 195)
        Me.stbBloodPressure.MaxLength = 7
        Me.stbBloodPressure.Name = "stbBloodPressure"
        Me.stbBloodPressure.RegularExpression = "^[0-9]{1,3}/[0-9]{1,3}$"
        Me.stbBloodPressure.Size = New System.Drawing.Size(149, 20)
        Me.stbBloodPressure.TabIndex = 16
        '
        'nbxBMI
        '
        Me.nbxBMI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBMI.ControlCaption = "BMI"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxBMI, "BMI")
        Me.nbxBMI.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBMI.DecimalPlaces = 2
        Me.nbxBMI.Enabled = False
        Me.nbxBMI.Location = New System.Drawing.Point(159, 321)
        Me.nbxBMI.MaxLength = 12
        Me.nbxBMI.MaxValue = 0.0R
        Me.nbxBMI.MinValue = 0.0R
        Me.nbxBMI.MustEnterNumeric = True
        Me.nbxBMI.Name = "nbxBMI"
        Me.nbxBMI.Size = New System.Drawing.Size(149, 20)
        Me.nbxBMI.TabIndex = 28
        Me.nbxBMI.Value = ""
        '
        'nbxRespirationRate
        '
        Me.nbxRespirationRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRespirationRate.ControlCaption = "Respiration Rate"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxRespirationRate, "RespirationRate")
        Me.nbxRespirationRate.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxRespirationRate.DecimalPlaces = -1
        Me.nbxRespirationRate.Location = New System.Drawing.Point(159, 258)
        Me.nbxRespirationRate.MaxLength = 3
        Me.nbxRespirationRate.MaxValue = 150.0R
        Me.nbxRespirationRate.MinValue = 10.0R
        Me.nbxRespirationRate.MustEnterNumeric = True
        Me.nbxRespirationRate.Name = "nbxRespirationRate"
        Me.nbxRespirationRate.Size = New System.Drawing.Size(149, 20)
        Me.nbxRespirationRate.TabIndex = 22
        Me.nbxRespirationRate.Value = ""
        '
        'stbNotes
        '
        Me.stbNotes.AcceptsReturn = True
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(159, 370)
        Me.stbNotes.MaxLength = 2000
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(409, 62)
        Me.stbNotes.TabIndex = 31
        '
        'nbxHeartRate
        '
        Me.nbxHeartRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeartRate.ControlCaption = "Heart Rate"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxHeartRate, "HeartRate")
        Me.nbxHeartRate.DataType = SyncSoft.Common.Win.Controls.Number.[Short]
        Me.nbxHeartRate.DecimalPlaces = -1
        Me.nbxHeartRate.Location = New System.Drawing.Point(159, 300)
        Me.nbxHeartRate.MaxLength = 3
        Me.nbxHeartRate.MaxValue = 250.0R
        Me.nbxHeartRate.MinValue = 0.0R
        Me.nbxHeartRate.MustEnterNumeric = True
        Me.nbxHeartRate.Name = "nbxHeartRate"
        Me.nbxHeartRate.Size = New System.Drawing.Size(149, 20)
        Me.nbxHeartRate.TabIndex = 26
        Me.nbxHeartRate.Value = ""
        '
        'nbxOxygenSaturation
        '
        Me.nbxOxygenSaturation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOxygenSaturation.ControlCaption = "Oxygen Saturation"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxOxygenSaturation, "OxygenSaturation")
        Me.nbxOxygenSaturation.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxOxygenSaturation.DecimalPlaces = 2
        Me.nbxOxygenSaturation.Location = New System.Drawing.Point(159, 279)
        Me.nbxOxygenSaturation.MaxLength = 3
        Me.nbxOxygenSaturation.MaxValue = 100.0R
        Me.nbxOxygenSaturation.MinValue = 0.0R
        Me.nbxOxygenSaturation.MustEnterNumeric = True
        Me.nbxOxygenSaturation.Name = "nbxOxygenSaturation"
        Me.nbxOxygenSaturation.Size = New System.Drawing.Size(149, 20)
        Me.nbxOxygenSaturation.TabIndex = 24
        Me.nbxOxygenSaturation.Value = ""
        '
        'cboTriagePriority
        '
        Me.cboTriagePriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTriagePriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboTriagePriority, "Priority,TriagePriorityID")
        Me.cboTriagePriority.DisplayMember = "Priority"
        Me.cboTriagePriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTriagePriority.DropDownWidth = 220
        Me.cboTriagePriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTriagePriority.FormattingEnabled = True
        Me.cboTriagePriority.ItemHeight = 13
        Me.cboTriagePriority.Location = New System.Drawing.Point(156, 3)
        Me.cboTriagePriority.Name = "cboTriagePriority"
        Me.cboTriagePriority.Size = New System.Drawing.Size(158, 21)
        Me.cboTriagePriority.TabIndex = 1
        Me.cboTriagePriority.Tag = "Priority"
        '
        'cboBMIStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBMIStatusID, "BMIStatus,BMIStatusID")
        Me.cboBMIStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBMIStatusID.Enabled = False
        Me.cboBMIStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBMIStatusID.Location = New System.Drawing.Point(419, 273)
        Me.cboBMIStatusID.Name = "cboBMIStatusID"
        Me.cboBMIStatusID.Size = New System.Drawing.Size(149, 21)
        Me.cboBMIStatusID.TabIndex = 50
        '
        'cboMUACStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMUACStatusID, "MUACStatus,MUACStatusID")
        Me.cboMUACStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUACStatusID.Enabled = False
        Me.cboMUACStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMUACStatusID.Location = New System.Drawing.Point(419, 297)
        Me.cboMUACStatusID.Name = "cboMUACStatusID"
        Me.cboMUACStatusID.Size = New System.Drawing.Size(149, 21)
        Me.cboMUACStatusID.TabIndex = 52
        '
        'nbxMUAC
        '
        Me.nbxMUAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMUAC.ControlCaption = "MUAC"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMUAC, "MUAC")
        Me.nbxMUAC.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxMUAC.DecimalPlaces = 2
        Me.nbxMUAC.Location = New System.Drawing.Point(159, 131)
        Me.nbxMUAC.MaxLength = 6
        Me.nbxMUAC.MaxValue = 100.0R
        Me.nbxMUAC.MinValue = 1.0R
        Me.nbxMUAC.MustEnterNumeric = True
        Me.nbxMUAC.Name = "nbxMUAC"
        Me.nbxMUAC.Size = New System.Drawing.Size(149, 20)
        Me.nbxMUAC.TabIndex = 10
        Me.nbxMUAC.Value = ""
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(419, 104)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 34
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(419, 146)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(149, 20)
        Me.stbAge.TabIndex = 38
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(419, 167)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 40
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(419, 125)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 36
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(496, 464)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 58
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(159, 68)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(99, 20)
        Me.stbVisitNo.TabIndex = 3
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(10, 68)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(112, 21)
        Me.lblVisitNo.TabIndex = 1
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(10, 89)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(143, 21)
        Me.lblWeight.TabIndex = 5
        Me.lblWeight.Text = "Weight (Kg)"
        '
        'lblTemperature
        '
        Me.lblTemperature.Location = New System.Drawing.Point(10, 110)
        Me.lblTemperature.Name = "lblTemperature"
        Me.lblTemperature.Size = New System.Drawing.Size(143, 21)
        Me.lblTemperature.TabIndex = 7
        Me.lblTemperature.Text = "Temperature (Celc.)"
        '
        'lblHeight
        '
        Me.lblHeight.Location = New System.Drawing.Point(10, 153)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(143, 21)
        Me.lblHeight.TabIndex = 11
        Me.lblHeight.Text = "Height/Length (cm)"
        '
        'lblPulse
        '
        Me.lblPulse.Location = New System.Drawing.Point(10, 174)
        Me.lblPulse.Name = "lblPulse"
        Me.lblPulse.Size = New System.Drawing.Size(143, 21)
        Me.lblPulse.TabIndex = 13
        Me.lblPulse.Text = "Pulse (B/min)"
        '
        'lblHeadCircum
        '
        Me.lblHeadCircum.Location = New System.Drawing.Point(10, 216)
        Me.lblHeadCircum.Name = "lblHeadCircum"
        Me.lblHeadCircum.Size = New System.Drawing.Size(143, 21)
        Me.lblHeadCircum.TabIndex = 17
        Me.lblHeadCircum.Text = "Head Circum (cm)"
        '
        'lblBodySurfaceArea
        '
        Me.lblBodySurfaceArea.Location = New System.Drawing.Point(10, 237)
        Me.lblBodySurfaceArea.Name = "lblBodySurfaceArea"
        Me.lblBodySurfaceArea.Size = New System.Drawing.Size(143, 21)
        Me.lblBodySurfaceArea.TabIndex = 19
        Me.lblBodySurfaceArea.Text = "Body Surface Area (cm)"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(126, 68)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 2
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(314, 148)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(99, 20)
        Me.lblAge.TabIndex = 37
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(314, 169)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(99, 20)
        Me.lblGenderID.TabIndex = 39
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(314, 128)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(99, 20)
        Me.lblName.TabIndex = 35
        Me.lblName.Text = "Patient's Name"
        '
        'lblHospitalPID
        '
        Me.lblHospitalPID.Location = New System.Drawing.Point(314, 105)
        Me.lblHospitalPID.Name = "lblHospitalPID"
        Me.lblHospitalPID.Size = New System.Drawing.Size(99, 20)
        Me.lblHospitalPID.TabIndex = 33
        Me.lblHospitalPID.Text = "Patient No"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(342, 13)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(71, 20)
        Me.lblPhoto.TabIndex = 32
        Me.lblPhoto.Text = "Photo"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(419, 3)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 100)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 45
        Me.spbPhoto.TabStop = False
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(419, 188)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitDate.TabIndex = 42
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(314, 188)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(99, 20)
        Me.lblVisitDate.TabIndex = 41
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(419, 209)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 44
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(314, 209)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(99, 20)
        Me.lblJoinDate.TabIndex = 43
        Me.lblJoinDate.Text = "Join Date"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(264, 64)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 4
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'lblBMI
        '
        Me.lblBMI.Location = New System.Drawing.Point(10, 322)
        Me.lblBMI.Name = "lblBMI"
        Me.lblBMI.Size = New System.Drawing.Size(143, 21)
        Me.lblBMI.TabIndex = 27
        Me.lblBMI.Text = "BMI (Kg/M²)"
        '
        'lblRespirationRate
        '
        Me.lblRespirationRate.Location = New System.Drawing.Point(10, 258)
        Me.lblRespirationRate.Name = "lblRespirationRate"
        Me.lblRespirationRate.Size = New System.Drawing.Size(143, 21)
        Me.lblRespirationRate.TabIndex = 21
        Me.lblRespirationRate.Text = "Respiration Rate (B/min)"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(10, 388)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(143, 21)
        Me.lblNotes.TabIndex = 30
        Me.lblNotes.Text = "Notes"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.chkHideSelfRequest)
        Me.pnlAlerts.Controls.Add(Me.btnPendingVisitTriage)
        Me.pnlAlerts.Controls.Add(Me.lblAlertMessage)
        Me.pnlAlerts.Location = New System.Drawing.Point(3, 2)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(333, 59)
        Me.pnlAlerts.TabIndex = 0
        '
        'chkHideSelfRequest
        '
        Me.chkHideSelfRequest.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHideSelfRequest.Checked = True
        Me.chkHideSelfRequest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideSelfRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHideSelfRequest.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkHideSelfRequest.Location = New System.Drawing.Point(6, 32)
        Me.chkHideSelfRequest.Name = "chkHideSelfRequest"
        Me.chkHideSelfRequest.Size = New System.Drawing.Size(233, 20)
        Me.chkHideSelfRequest.TabIndex = 2
        Me.chkHideSelfRequest.Text = "Hide Self Request (s)"
        '
        'btnPendingVisitTriage
        '
        Me.btnPendingVisitTriage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingVisitTriage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingVisitTriage.Location = New System.Drawing.Point(227, 5)
        Me.btnPendingVisitTriage.Name = "btnPendingVisitTriage"
        Me.btnPendingVisitTriage.Size = New System.Drawing.Size(78, 24)
        Me.btnPendingVisitTriage.TabIndex = 1
        Me.btnPendingVisitTriage.Tag = ""
        Me.btnPendingVisitTriage.Text = "&View List"
        '
        'lblAlertMessage
        '
        Me.lblAlertMessage.Font = New System.Drawing.Font("Verdana", 11.25!)
        Me.lblAlertMessage.ForeColor = System.Drawing.Color.Red
        Me.lblAlertMessage.Location = New System.Drawing.Point(6, 7)
        Me.lblAlertMessage.Name = "lblAlertMessage"
        Me.lblAlertMessage.Size = New System.Drawing.Size(182, 20)
        Me.lblAlertMessage.TabIndex = 0
        Me.lblAlertMessage.Text = "Visit(s) to Triage: 0"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'lblHeartRate
        '
        Me.lblHeartRate.Location = New System.Drawing.Point(10, 300)
        Me.lblHeartRate.Name = "lblHeartRate"
        Me.lblHeartRate.Size = New System.Drawing.Size(143, 21)
        Me.lblHeartRate.TabIndex = 25
        Me.lblHeartRate.Text = "Heart Rate (B/min)"
        '
        'lblOxygenSaturation
        '
        Me.lblOxygenSaturation.Location = New System.Drawing.Point(10, 279)
        Me.lblOxygenSaturation.Name = "lblOxygenSaturation"
        Me.lblOxygenSaturation.Size = New System.Drawing.Size(143, 21)
        Me.lblOxygenSaturation.TabIndex = 23
        Me.lblOxygenSaturation.Text = "Oxygen Saturation (%)"
        '
        'pnlVisitsPriority
        '
        Me.pnlVisitsPriority.Controls.Add(Me.cboTriagePriority)
        Me.pnlVisitsPriority.Controls.Add(Me.lblVisitPriority)
        Me.pnlVisitsPriority.Location = New System.Drawing.Point(3, 343)
        Me.pnlVisitsPriority.Name = "pnlVisitsPriority"
        Me.pnlVisitsPriority.Size = New System.Drawing.Size(319, 28)
        Me.pnlVisitsPriority.TabIndex = 29
        '
        'lblVisitPriority
        '
        Me.lblVisitPriority.Location = New System.Drawing.Point(6, 4)
        Me.lblVisitPriority.Name = "lblVisitPriority"
        Me.lblVisitPriority.Size = New System.Drawing.Size(151, 20)
        Me.lblVisitPriority.TabIndex = 0
        Me.lblVisitPriority.Text = "Visit Priority"
        '
        'stbDoctorSpecialty
        '
        Me.stbDoctorSpecialty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDoctorSpecialty.CapitalizeFirstLetter = False
        Me.stbDoctorSpecialty.Enabled = False
        Me.stbDoctorSpecialty.EntryErrorMSG = ""
        Me.stbDoctorSpecialty.Location = New System.Drawing.Point(419, 230)
        Me.stbDoctorSpecialty.MaxLength = 60
        Me.stbDoctorSpecialty.Name = "stbDoctorSpecialty"
        Me.stbDoctorSpecialty.RegularExpression = ""
        Me.stbDoctorSpecialty.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDoctorSpecialty.Size = New System.Drawing.Size(149, 20)
        Me.stbDoctorSpecialty.TabIndex = 46
        '
        'lblDoctorSpecialty
        '
        Me.lblDoctorSpecialty.Location = New System.Drawing.Point(314, 230)
        Me.lblDoctorSpecialty.Name = "lblDoctorSpecialty"
        Me.lblDoctorSpecialty.Size = New System.Drawing.Size(99, 20)
        Me.lblDoctorSpecialty.TabIndex = 45
        Me.lblDoctorSpecialty.Text = "Doctor Specialty"
        '
        'stbTToSeeDoctor
        '
        Me.stbTToSeeDoctor.AcceptsReturn = True
        Me.stbTToSeeDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTToSeeDoctor.CapitalizeFirstLetter = False
        Me.stbTToSeeDoctor.Enabled = False
        Me.stbTToSeeDoctor.EntryErrorMSG = ""
        Me.stbTToSeeDoctor.Location = New System.Drawing.Point(419, 251)
        Me.stbTToSeeDoctor.MaxLength = 60
        Me.stbTToSeeDoctor.Name = "stbTToSeeDoctor"
        Me.stbTToSeeDoctor.RegularExpression = ""
        Me.stbTToSeeDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTToSeeDoctor.Size = New System.Drawing.Size(149, 20)
        Me.stbTToSeeDoctor.TabIndex = 48
        '
        'lblToSeeDoctor
        '
        Me.lblToSeeDoctor.Location = New System.Drawing.Point(314, 251)
        Me.lblToSeeDoctor.Name = "lblToSeeDoctor"
        Me.lblToSeeDoctor.Size = New System.Drawing.Size(99, 20)
        Me.lblToSeeDoctor.TabIndex = 47
        Me.lblToSeeDoctor.Text = "To See Doctor"
        '
        'lblBMIStatusID
        '
        Me.lblBMIStatusID.Location = New System.Drawing.Point(314, 273)
        Me.lblBMIStatusID.Name = "lblBMIStatusID"
        Me.lblBMIStatusID.Size = New System.Drawing.Size(99, 20)
        Me.lblBMIStatusID.TabIndex = 49
        Me.lblBMIStatusID.Text = "BMI Status"
        '
        'lblMUACStatusID
        '
        Me.lblMUACStatusID.Location = New System.Drawing.Point(314, 298)
        Me.lblMUACStatusID.Name = "lblMUACStatusID"
        Me.lblMUACStatusID.Size = New System.Drawing.Size(99, 20)
        Me.lblMUACStatusID.TabIndex = 51
        Me.lblMUACStatusID.Text = "MUAC Status"
        '
        'lblMUAC
        '
        Me.lblMUAC.Location = New System.Drawing.Point(10, 133)
        Me.lblMUAC.Name = "lblMUAC"
        Me.lblMUAC.Size = New System.Drawing.Size(141, 20)
        Me.lblMUAC.TabIndex = 9
        Me.lblMUAC.Text = "MUAC"
        '
        'EditBtnTB
        '
        Me.EditBtnTB.DataSource = Nothing
        Me.EditBtnTB.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.EditBtnTB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditBtnTB.Location = New System.Drawing.Point(317, 465)
        Me.EditBtnTB.Name = "EditBtnTB"
        Me.EditBtnTB.Size = New System.Drawing.Size(162, 23)
        Me.EditBtnTB.TabIndex = 56
        Me.EditBtnTB.Tag = "TBIntensifiedCaseFinding"
        Me.EditBtnTB.Text = "&TB Intensified Case Finding"
        Me.EditBtnTB.UseVisualStyleBackColor = False
        '
        'EditPatients
        '
        Me.EditPatients.DataSource = Nothing
        Me.EditPatients.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.EditPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditPatients.Location = New System.Drawing.Point(185, 465)
        Me.EditPatients.Name = "EditPatients"
        Me.EditPatients.Size = New System.Drawing.Size(126, 23)
        Me.EditPatients.TabIndex = 55
        Me.EditPatients.Tag = "Patients"
        Me.EditPatients.Text = "&Register Allergies"
        Me.EditPatients.UseVisualStyleBackColor = False
        '
        'frmTriage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(573, 495)
        Me.Controls.Add(Me.EditPatients)
        Me.Controls.Add(Me.EditBtnTB)
        Me.Controls.Add(Me.nbxMUAC)
        Me.Controls.Add(Me.lblMUAC)
        Me.Controls.Add(Me.cboBMIStatusID)
        Me.Controls.Add(Me.lblBMIStatusID)
        Me.Controls.Add(Me.cboMUACStatusID)
        Me.Controls.Add(Me.lblMUACStatusID)
        Me.Controls.Add(Me.stbDoctorSpecialty)
        Me.Controls.Add(Me.lblDoctorSpecialty)
        Me.Controls.Add(Me.stbTToSeeDoctor)
        Me.Controls.Add(Me.lblToSeeDoctor)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.pnlVisitsPriority)
        Me.Controls.Add(Me.nbxHeartRate)
        Me.Controls.Add(Me.lblHeartRate)
        Me.Controls.Add(Me.nbxOxygenSaturation)
        Me.Controls.Add(Me.lblOxygenSaturation)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.nbxRespirationRate)
        Me.Controls.Add(Me.lblRespirationRate)
        Me.Controls.Add(Me.nbxBMI)
        Me.Controls.Add(Me.lblBMI)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblHospitalPID)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbBloodPressure)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.nbxWeight)
        Me.Controls.Add(Me.lblWeight)
        Me.Controls.Add(Me.nbxTemperature)
        Me.Controls.Add(Me.lblTemperature)
        Me.Controls.Add(Me.nbxHeight)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.nbxPulse)
        Me.Controls.Add(Me.lblPulse)
        Me.Controls.Add(Me.lblBloodPressure)
        Me.Controls.Add(Me.nbxHeadCircum)
        Me.Controls.Add(Me.lblHeadCircum)
        Me.Controls.Add(Me.nbxBodySurfaceArea)
        Me.Controls.Add(Me.lblBodySurfaceArea)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTriage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Triage"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlVisitsPriority.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents nbxWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents nbxTemperature As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblTemperature As System.Windows.Forms.Label
    Friend WithEvents nbxHeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents nbxPulse As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblPulse As System.Windows.Forms.Label
    Friend WithEvents lblBloodPressure As System.Windows.Forms.Label
    Friend WithEvents nbxHeadCircum As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeadCircum As System.Windows.Forms.Label
    Friend WithEvents nbxBodySurfaceArea As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBodySurfaceArea As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbBloodPressure As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHospitalPID As System.Windows.Forms.Label
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents lblBMI As System.Windows.Forms.Label
    Friend WithEvents nbxBMI As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxRespirationRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRespirationRate As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents chkHideSelfRequest As System.Windows.Forms.CheckBox
    Friend WithEvents btnPendingVisitTriage As System.Windows.Forms.Button
    Friend WithEvents lblAlertMessage As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents nbxHeartRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeartRate As System.Windows.Forms.Label
    Friend WithEvents nbxOxygenSaturation As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOxygenSaturation As System.Windows.Forms.Label
    Friend WithEvents pnlVisitsPriority As System.Windows.Forms.Panel
    Friend WithEvents cboTriagePriority As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitPriority As System.Windows.Forms.Label
    Friend WithEvents stbDoctorSpecialty As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDoctorSpecialty As System.Windows.Forms.Label
    Friend WithEvents stbTToSeeDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblToSeeDoctor As System.Windows.Forms.Label
    Friend WithEvents cboBMIStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBMIStatusID As System.Windows.Forms.Label
    Friend WithEvents cboMUACStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMUACStatusID As System.Windows.Forms.Label
    Friend WithEvents nbxMUAC As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMUAC As System.Windows.Forms.Label
    Friend WithEvents EditBtnTB As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents EditPatients As SyncSoft.Common.Win.Controls.EditButton

End Class