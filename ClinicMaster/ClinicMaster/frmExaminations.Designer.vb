
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExaminations : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExaminations))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboExamVisitTypeID = New System.Windows.Forms.ComboBox()
        Me.cboPregnancyStatusID = New System.Windows.Forms.ComboBox()
        Me.dtpExpectedDeliveryDate = New System.Windows.Forms.DateTimePicker()
        Me.chkPMTCT = New System.Windows.Forms.CheckBox()
        Me.nbxGestationalAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboTBStatusID = New System.Windows.Forms.ComboBox()
        Me.dtpTBRxStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpTBRxStopDate = New System.Windows.Forms.DateTimePicker()
        Me.stbTBRegNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboWHOStageID = New System.Windows.Forms.ComboBox()
        Me.nbxCPTDuration = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbOtherMeds = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCombination = New System.Windows.Forms.ComboBox()
        Me.nbxCD4ABS = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCD4PCT = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbRefer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxDaysHOSP = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtPrimaryDoctor = New System.Windows.Forms.TextBox()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtPatientNo = New System.Windows.Forms.TextBox()
        Me.clbFPMethods = New System.Windows.Forms.CheckedListBox()
        Me.clbSideEffects = New System.Windows.Forms.CheckedListBox()
        Me.clbNewOI = New System.Windows.Forms.CheckedListBox()
        Me.clbARVAdhereWhy = New System.Windows.Forms.CheckedListBox()
        Me.clbInvestigations = New System.Windows.Forms.CheckedListBox()
        Me.cboFunctionalStatusID = New System.Windows.Forms.ComboBox()
        Me.cboOedemaID = New System.Windows.Forms.ComboBox()
        Me.cboCPTAdhereID = New System.Windows.Forms.ComboBox()
        Me.nbxCPTDosage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboMUACStatusID = New System.Windows.Forms.ComboBox()
        Me.cboARVAdhereID = New System.Windows.Forms.ComboBox()
        Me.nbxARVDosage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxARVDuration = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboNutritionalSupID = New System.Windows.Forms.ComboBox()
        Me.txtVisitDate = New System.Windows.Forms.TextBox()
        Me.dtpFollowupDate = New System.Windows.Forms.DateTimePicker()
        Me.nbxDurationStartART = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxDurationCurrentART = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxHeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblExamVisitTypeID = New System.Windows.Forms.Label()
        Me.lblFollowupDate = New System.Windows.Forms.Label()
        Me.lblDurationStartART = New System.Windows.Forms.Label()
        Me.lblDurationCurrentART = New System.Windows.Forms.Label()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblOedema = New System.Windows.Forms.Label()
        Me.lblPregnancyStatusID = New System.Windows.Forms.Label()
        Me.lblExpectedDeliveryDate = New System.Windows.Forms.Label()
        Me.lblGestationalAge = New System.Windows.Forms.Label()
        Me.lblMUACStatusID = New System.Windows.Forms.Label()
        Me.lblFPMethods = New System.Windows.Forms.Label()
        Me.lblTBStatusID = New System.Windows.Forms.Label()
        Me.lblTBRxStartDate = New System.Windows.Forms.Label()
        Me.lblTBRxStopDate = New System.Windows.Forms.Label()
        Me.lblTBRegNo = New System.Windows.Forms.Label()
        Me.lblSideEffects = New System.Windows.Forms.Label()
        Me.lblNewOI = New System.Windows.Forms.Label()
        Me.lbFunctionalStatusID = New System.Windows.Forms.Label()
        Me.lblWHOStageID = New System.Windows.Forms.Label()
        Me.lblCPTAdhere = New System.Windows.Forms.Label()
        Me.lblCPTDosage = New System.Windows.Forms.Label()
        Me.lblCPTDuration = New System.Windows.Forms.Label()
        Me.lblOtherMeds = New System.Windows.Forms.Label()
        Me.lblARVAdhere = New System.Windows.Forms.Label()
        Me.lblARVAdhereWhy = New System.Windows.Forms.Label()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.lblARVDosage = New System.Windows.Forms.Label()
        Me.lblCD4ABS = New System.Windows.Forms.Label()
        Me.lblCD4PCT = New System.Windows.Forms.Label()
        Me.lblInvestigations = New System.Windows.Forms.Label()
        Me.lblRefer = New System.Windows.Forms.Label()
        Me.lblDaysHOSP = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblARVDuration = New System.Windows.Forms.Label()
        Me.lblNutritionalSupID = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 612)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 86
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(587, 614)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 87
        Me.fbnDelete.Tag = "Examinations"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 639)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 88
        Me.ebnSaveUpdate.Tag = "Examinations"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboExamVisitTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboExamVisitTypeID, "ExamVisitType,ExamVisitTypeID")
        Me.cboExamVisitTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamVisitTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExamVisitTypeID.Location = New System.Drawing.Point(168, 53)
        Me.cboExamVisitTypeID.Name = "cboExamVisitTypeID"
        Me.cboExamVisitTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboExamVisitTypeID.TabIndex = 6
        '
        'cboPregnancyStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPregnancyStatusID, "PregnancyStatus,PregnancyStatusID")
        Me.cboPregnancyStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPregnancyStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPregnancyStatusID.Location = New System.Drawing.Point(168, 215)
        Me.cboPregnancyStatusID.Name = "cboPregnancyStatusID"
        Me.cboPregnancyStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboPregnancyStatusID.TabIndex = 20
        '
        'dtpExpectedDeliveryDate
        '
        Me.dtpExpectedDeliveryDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExpectedDeliveryDate, "ExpectedDeliveryDate")
        Me.dtpExpectedDeliveryDate.Location = New System.Drawing.Point(168, 238)
        Me.dtpExpectedDeliveryDate.Name = "dtpExpectedDeliveryDate"
        Me.dtpExpectedDeliveryDate.ShowCheckBox = True
        Me.dtpExpectedDeliveryDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpExpectedDeliveryDate.TabIndex = 22
        '
        'chkPMTCT
        '
        Me.chkPMTCT.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkPMTCT, "PMTCT")
        Me.chkPMTCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPMTCT.Location = New System.Drawing.Point(12, 261)
        Me.chkPMTCT.Name = "chkPMTCT"
        Me.chkPMTCT.Size = New System.Drawing.Size(171, 20)
        Me.chkPMTCT.TabIndex = 23
        Me.chkPMTCT.Text = "PMTCT"
        '
        'nbxGestationalAge
        '
        Me.nbxGestationalAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxGestationalAge.ControlCaption = "Gestational Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxGestationalAge, "GestationalAge")
        Me.nbxGestationalAge.DecimalPlaces = -1
        Me.nbxGestationalAge.Location = New System.Drawing.Point(168, 284)
        Me.nbxGestationalAge.MaxLength = 6
        Me.nbxGestationalAge.MaxValue = 0.0R
        Me.nbxGestationalAge.MinValue = 0.0R
        Me.nbxGestationalAge.MustEnterNumeric = True
        Me.nbxGestationalAge.Name = "nbxGestationalAge"
        Me.nbxGestationalAge.Size = New System.Drawing.Size(170, 20)
        Me.nbxGestationalAge.TabIndex = 25
        Me.nbxGestationalAge.Value = ""
        '
        'cboTBStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTBStatusID, "TBStatus,TBStatusID")
        Me.cboTBStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTBStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTBStatusID.Location = New System.Drawing.Point(168, 379)
        Me.cboTBStatusID.Name = "cboTBStatusID"
        Me.cboTBStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboTBStatusID.TabIndex = 31
        '
        'dtpTBRxStartDate
        '
        Me.dtpTBRxStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTBRxStartDate, "TBRxStartDate")
        Me.dtpTBRxStartDate.Location = New System.Drawing.Point(168, 402)
        Me.dtpTBRxStartDate.Name = "dtpTBRxStartDate"
        Me.dtpTBRxStartDate.ShowCheckBox = True
        Me.dtpTBRxStartDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpTBRxStartDate.TabIndex = 33
        '
        'dtpTBRxStopDate
        '
        Me.dtpTBRxStopDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTBRxStopDate, "TBRxStopDate")
        Me.dtpTBRxStopDate.Location = New System.Drawing.Point(168, 425)
        Me.dtpTBRxStopDate.Name = "dtpTBRxStopDate"
        Me.dtpTBRxStopDate.ShowCheckBox = True
        Me.dtpTBRxStopDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpTBRxStopDate.TabIndex = 35
        '
        'stbTBRegNo
        '
        Me.stbTBRegNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTBRegNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTBRegNo, "TBRegNo")
        Me.stbTBRegNo.EntryErrorMSG = ""
        Me.stbTBRegNo.Location = New System.Drawing.Point(168, 448)
        Me.stbTBRegNo.MaxLength = 20
        Me.stbTBRegNo.Name = "stbTBRegNo"
        Me.stbTBRegNo.RegularExpression = ""
        Me.stbTBRegNo.Size = New System.Drawing.Size(170, 20)
        Me.stbTBRegNo.TabIndex = 37
        '
        'cboWHOStageID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWHOStageID, "WHOStage,WHOStageID")
        Me.cboWHOStageID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWHOStageID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWHOStageID.Location = New System.Drawing.Point(489, 146)
        Me.cboWHOStageID.Name = "cboWHOStageID"
        Me.cboWHOStageID.Size = New System.Drawing.Size(170, 21)
        Me.cboWHOStageID.TabIndex = 55
        '
        'nbxCPTDuration
        '
        Me.nbxCPTDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCPTDuration.ControlCaption = "CPT Duration (Days)"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCPTDuration, "CPTDuration")
        Me.nbxCPTDuration.DecimalPlaces = -1
        Me.nbxCPTDuration.Location = New System.Drawing.Point(489, 216)
        Me.nbxCPTDuration.MaxLength = 6
        Me.nbxCPTDuration.MaxValue = 0.0R
        Me.nbxCPTDuration.MinValue = 0.0R
        Me.nbxCPTDuration.MustEnterNumeric = True
        Me.nbxCPTDuration.Name = "nbxCPTDuration"
        Me.nbxCPTDuration.Size = New System.Drawing.Size(170, 20)
        Me.nbxCPTDuration.TabIndex = 61
        Me.nbxCPTDuration.Value = ""
        '
        'stbOtherMeds
        '
        Me.stbOtherMeds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherMeds.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbOtherMeds, "OtherMeds")
        Me.stbOtherMeds.EntryErrorMSG = ""
        Me.stbOtherMeds.Location = New System.Drawing.Point(489, 238)
        Me.stbOtherMeds.MaxLength = 200
        Me.stbOtherMeds.Multiline = True
        Me.stbOtherMeds.Name = "stbOtherMeds"
        Me.stbOtherMeds.RegularExpression = ""
        Me.stbOtherMeds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOtherMeds.Size = New System.Drawing.Size(170, 35)
        Me.stbOtherMeds.TabIndex = 63
        '
        'cboCombination
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCombination, "Combination")
        Me.cboCombination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCombination.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCombination.Location = New System.Drawing.Point(489, 372)
        Me.cboCombination.Name = "cboCombination"
        Me.cboCombination.Size = New System.Drawing.Size(170, 21)
        Me.cboCombination.TabIndex = 71
        '
        'nbxCD4ABS
        '
        Me.nbxCD4ABS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCD4ABS.ControlCaption = "CD4 ABS"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCD4ABS, "CD4ABS")
        Me.nbxCD4ABS.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCD4ABS.DecimalPlaces = -1
        Me.nbxCD4ABS.Location = New System.Drawing.Point(489, 441)
        Me.nbxCD4ABS.MaxLength = 12
        Me.nbxCD4ABS.MaxValue = 0.0R
        Me.nbxCD4ABS.MinValue = 0.0R
        Me.nbxCD4ABS.MustEnterNumeric = True
        Me.nbxCD4ABS.Name = "nbxCD4ABS"
        Me.nbxCD4ABS.Size = New System.Drawing.Size(170, 20)
        Me.nbxCD4ABS.TabIndex = 77
        Me.nbxCD4ABS.Value = ""
        '
        'nbxCD4PCT
        '
        Me.nbxCD4PCT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCD4PCT.ControlCaption = "CD4 PCT"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCD4PCT, "CD4PCT")
        Me.nbxCD4PCT.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCD4PCT.DecimalPlaces = -1
        Me.nbxCD4PCT.Location = New System.Drawing.Point(489, 464)
        Me.nbxCD4PCT.MaxLength = 3
        Me.nbxCD4PCT.MaxValue = 0.0R
        Me.nbxCD4PCT.MinValue = 0.0R
        Me.nbxCD4PCT.MustEnterNumeric = True
        Me.nbxCD4PCT.Name = "nbxCD4PCT"
        Me.nbxCD4PCT.Size = New System.Drawing.Size(170, 20)
        Me.nbxCD4PCT.TabIndex = 79
        Me.nbxCD4PCT.Value = ""
        '
        'stbRefer
        '
        Me.stbRefer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefer.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRefer, "Refer")
        Me.stbRefer.EntryErrorMSG = ""
        Me.stbRefer.Location = New System.Drawing.Point(489, 537)
        Me.stbRefer.MaxLength = 40
        Me.stbRefer.Name = "stbRefer"
        Me.stbRefer.RegularExpression = ""
        Me.stbRefer.Size = New System.Drawing.Size(170, 20)
        Me.stbRefer.TabIndex = 83
        '
        'nbxDaysHOSP
        '
        Me.nbxDaysHOSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDaysHOSP.ControlCaption = "Days HOSP"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDaysHOSP, "DaysHOSP")
        Me.nbxDaysHOSP.DecimalPlaces = -1
        Me.nbxDaysHOSP.Location = New System.Drawing.Point(489, 560)
        Me.nbxDaysHOSP.MaxLength = 6
        Me.nbxDaysHOSP.MaxValue = 0.0R
        Me.nbxDaysHOSP.MinValue = 0.0R
        Me.nbxDaysHOSP.MustEnterNumeric = True
        Me.nbxDaysHOSP.Name = "nbxDaysHOSP"
        Me.nbxDaysHOSP.Size = New System.Drawing.Size(170, 20)
        Me.nbxDaysHOSP.TabIndex = 85
        Me.nbxDaysHOSP.Value = ""
        '
        'txtAge
        '
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.txtAge, "Age")
        Me.txtAge.Enabled = False
        Me.txtAge.Location = New System.Drawing.Point(489, 51)
        Me.txtAge.MaxLength = 60
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAge.Size = New System.Drawing.Size(170, 20)
        Me.txtAge.TabIndex = 47
        '
        'txtPrimaryDoctor
        '
        Me.txtPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.txtPrimaryDoctor, "PrimaryDoctor")
        Me.txtPrimaryDoctor.Enabled = False
        Me.txtPrimaryDoctor.Location = New System.Drawing.Point(489, 99)
        Me.txtPrimaryDoctor.MaxLength = 60
        Me.txtPrimaryDoctor.Name = "txtPrimaryDoctor"
        Me.txtPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPrimaryDoctor.Size = New System.Drawing.Size(170, 20)
        Me.txtPrimaryDoctor.TabIndex = 51
        '
        'txtGender
        '
        Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.txtGender, "Gender")
        Me.txtGender.Enabled = False
        Me.txtGender.Location = New System.Drawing.Point(489, 75)
        Me.txtGender.MaxLength = 60
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGender.Size = New System.Drawing.Size(170, 20)
        Me.txtGender.TabIndex = 49
        '
        'txtFullName
        '
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.txtFullName, "FullName")
        Me.txtFullName.Enabled = False
        Me.txtFullName.Location = New System.Drawing.Point(489, 28)
        Me.txtFullName.MaxLength = 41
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(170, 20)
        Me.txtFullName.TabIndex = 45
        '
        'txtPatientNo
        '
        Me.txtPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.txtPatientNo, "PatientNo")
        Me.txtPatientNo.Enabled = False
        Me.txtPatientNo.Location = New System.Drawing.Point(168, 6)
        Me.txtPatientNo.MaxLength = 20
        Me.txtPatientNo.Name = "txtPatientNo"
        Me.txtPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.txtPatientNo.TabIndex = 1
        '
        'clbFPMethods
        '
        Me.clbFPMethods.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbFPMethods, "FPMethods")
        Me.clbFPMethods.FormattingEnabled = True
        Me.clbFPMethods.Location = New System.Drawing.Point(168, 307)
        Me.clbFPMethods.Name = "clbFPMethods"
        Me.clbFPMethods.Size = New System.Drawing.Size(170, 45)
        Me.clbFPMethods.TabIndex = 27
        '
        'clbSideEffects
        '
        Me.clbSideEffects.AccessibleDescription = ""
        Me.clbSideEffects.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbSideEffects, "SideEffects")
        Me.clbSideEffects.FormattingEnabled = True
        Me.clbSideEffects.Location = New System.Drawing.Point(168, 471)
        Me.clbSideEffects.Name = "clbSideEffects"
        Me.clbSideEffects.Size = New System.Drawing.Size(170, 45)
        Me.clbSideEffects.TabIndex = 39
        '
        'clbNewOI
        '
        Me.clbNewOI.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbNewOI, "NewOI")
        Me.clbNewOI.FormattingEnabled = True
        Me.clbNewOI.Location = New System.Drawing.Point(168, 521)
        Me.clbNewOI.Name = "clbNewOI"
        Me.clbNewOI.Size = New System.Drawing.Size(170, 45)
        Me.clbNewOI.TabIndex = 41
        '
        'clbARVAdhereWhy
        '
        Me.clbARVAdhereWhy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbARVAdhereWhy, "ARVAdhereWhy")
        Me.clbARVAdhereWhy.FormattingEnabled = True
        Me.clbARVAdhereWhy.Location = New System.Drawing.Point(489, 324)
        Me.clbARVAdhereWhy.Name = "clbARVAdhereWhy"
        Me.clbARVAdhereWhy.Size = New System.Drawing.Size(170, 45)
        Me.clbARVAdhereWhy.TabIndex = 69
        '
        'clbInvestigations
        '
        Me.clbInvestigations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbInvestigations, "Investigations")
        Me.clbInvestigations.FormattingEnabled = True
        Me.clbInvestigations.Location = New System.Drawing.Point(489, 488)
        Me.clbInvestigations.Name = "clbInvestigations"
        Me.clbInvestigations.Size = New System.Drawing.Size(170, 45)
        Me.clbInvestigations.TabIndex = 81
        '
        'cboFunctionalStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboFunctionalStatusID, "FunctionalStatus,FunctionalStatusID")
        Me.cboFunctionalStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFunctionalStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboFunctionalStatusID.Location = New System.Drawing.Point(489, 122)
        Me.cboFunctionalStatusID.Name = "cboFunctionalStatusID"
        Me.cboFunctionalStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboFunctionalStatusID.TabIndex = 53
        '
        'cboOedemaID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboOedemaID, "Oedema,OedemaID")
        Me.cboOedemaID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOedemaID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOedemaID.Items.AddRange(New Object() {"0", "+", "++", "+++"})
        Me.cboOedemaID.Location = New System.Drawing.Point(168, 191)
        Me.cboOedemaID.Name = "cboOedemaID"
        Me.cboOedemaID.Size = New System.Drawing.Size(170, 21)
        Me.cboOedemaID.TabIndex = 18
        '
        'cboCPTAdhereID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCPTAdhereID, "CPTAdhere,CPTAdhereID")
        Me.cboCPTAdhereID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCPTAdhereID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCPTAdhereID.Location = New System.Drawing.Point(489, 170)
        Me.cboCPTAdhereID.Name = "cboCPTAdhereID"
        Me.cboCPTAdhereID.Size = New System.Drawing.Size(170, 21)
        Me.cboCPTAdhereID.TabIndex = 57
        '
        'nbxCPTDosage
        '
        Me.nbxCPTDosage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCPTDosage.ControlCaption = "CPT Dosage"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCPTDosage, "CPTDosage")
        Me.nbxCPTDosage.DecimalPlaces = -1
        Me.nbxCPTDosage.Location = New System.Drawing.Point(489, 194)
        Me.nbxCPTDosage.MaxLength = 6
        Me.nbxCPTDosage.MaxValue = 0.0R
        Me.nbxCPTDosage.MinValue = 0.0R
        Me.nbxCPTDosage.MustEnterNumeric = True
        Me.nbxCPTDosage.Name = "nbxCPTDosage"
        Me.nbxCPTDosage.Size = New System.Drawing.Size(170, 20)
        Me.nbxCPTDosage.TabIndex = 59
        Me.nbxCPTDosage.Value = ""
        '
        'cboMUACStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMUACStatusID, "MUACStatus,MUACStatusID")
        Me.cboMUACStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMUACStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMUACStatusID.Location = New System.Drawing.Point(168, 355)
        Me.cboMUACStatusID.Name = "cboMUACStatusID"
        Me.cboMUACStatusID.Size = New System.Drawing.Size(170, 21)
        Me.cboMUACStatusID.TabIndex = 29
        '
        'cboARVAdhereID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboARVAdhereID, "ARVAdhere,ARVAdhereID")
        Me.cboARVAdhereID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboARVAdhereID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboARVAdhereID.Location = New System.Drawing.Point(489, 300)
        Me.cboARVAdhereID.Name = "cboARVAdhereID"
        Me.cboARVAdhereID.Size = New System.Drawing.Size(170, 21)
        Me.cboARVAdhereID.TabIndex = 67
        '
        'nbxARVDosage
        '
        Me.nbxARVDosage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxARVDosage.ControlCaption = "ARV Dosage"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxARVDosage, "ARVDosage")
        Me.nbxARVDosage.DecimalPlaces = -1
        Me.nbxARVDosage.Location = New System.Drawing.Point(489, 396)
        Me.nbxARVDosage.MaxLength = 6
        Me.nbxARVDosage.MaxValue = 0.0R
        Me.nbxARVDosage.MinValue = 0.0R
        Me.nbxARVDosage.MustEnterNumeric = True
        Me.nbxARVDosage.Name = "nbxARVDosage"
        Me.nbxARVDosage.Size = New System.Drawing.Size(170, 20)
        Me.nbxARVDosage.TabIndex = 73
        Me.nbxARVDosage.Value = ""
        '
        'nbxARVDuration
        '
        Me.nbxARVDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxARVDuration.ControlCaption = "ARV Duration"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxARVDuration, "ARVDuration")
        Me.nbxARVDuration.DecimalPlaces = -1
        Me.nbxARVDuration.Location = New System.Drawing.Point(489, 419)
        Me.nbxARVDuration.MaxLength = 6
        Me.nbxARVDuration.MaxValue = 0.0R
        Me.nbxARVDuration.MinValue = 0.0R
        Me.nbxARVDuration.MustEnterNumeric = True
        Me.nbxARVDuration.Name = "nbxARVDuration"
        Me.nbxARVDuration.Size = New System.Drawing.Size(170, 20)
        Me.nbxARVDuration.TabIndex = 75
        Me.nbxARVDuration.Value = ""
        '
        'cboNutritionalSupID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboNutritionalSupID, "NutritionalSup,NutritionalSupID")
        Me.cboNutritionalSupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNutritionalSupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNutritionalSupID.Location = New System.Drawing.Point(489, 276)
        Me.cboNutritionalSupID.Name = "cboNutritionalSupID"
        Me.cboNutritionalSupID.Size = New System.Drawing.Size(170, 21)
        Me.cboNutritionalSupID.TabIndex = 65
        '
        'txtVisitDate
        '
        Me.txtVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.txtVisitDate, "VisitDate")
        Me.txtVisitDate.Enabled = False
        Me.txtVisitDate.Location = New System.Drawing.Point(489, 4)
        Me.txtVisitDate.MaxLength = 60
        Me.txtVisitDate.Name = "txtVisitDate"
        Me.txtVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.txtVisitDate.TabIndex = 43
        '
        'dtpFollowupDate
        '
        Me.dtpFollowupDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpFollowupDate, "FollowupDate")
        Me.dtpFollowupDate.Location = New System.Drawing.Point(168, 77)
        Me.dtpFollowupDate.Name = "dtpFollowupDate"
        Me.dtpFollowupDate.ShowCheckBox = True
        Me.dtpFollowupDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpFollowupDate.TabIndex = 8
        '
        'nbxDurationStartART
        '
        Me.nbxDurationStartART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDurationStartART.ControlCaption = "Duration Start ART"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDurationStartART, "DurationStartART")
        Me.nbxDurationStartART.DecimalPlaces = -1
        Me.nbxDurationStartART.Location = New System.Drawing.Point(168, 100)
        Me.nbxDurationStartART.MaxLength = 6
        Me.nbxDurationStartART.MaxValue = 0.0R
        Me.nbxDurationStartART.MinValue = 0.0R
        Me.nbxDurationStartART.MustEnterNumeric = True
        Me.nbxDurationStartART.Name = "nbxDurationStartART"
        Me.nbxDurationStartART.Size = New System.Drawing.Size(170, 20)
        Me.nbxDurationStartART.TabIndex = 10
        Me.nbxDurationStartART.Value = ""
        '
        'nbxDurationCurrentART
        '
        Me.nbxDurationCurrentART.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDurationCurrentART.ControlCaption = "Duration Current ART"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDurationCurrentART, "DurationCurrentART")
        Me.nbxDurationCurrentART.DecimalPlaces = -1
        Me.nbxDurationCurrentART.Location = New System.Drawing.Point(168, 123)
        Me.nbxDurationCurrentART.MaxLength = 6
        Me.nbxDurationCurrentART.MaxValue = 0.0R
        Me.nbxDurationCurrentART.MinValue = 0.0R
        Me.nbxDurationCurrentART.MustEnterNumeric = True
        Me.nbxDurationCurrentART.Name = "nbxDurationCurrentART"
        Me.nbxDurationCurrentART.Size = New System.Drawing.Size(170, 20)
        Me.nbxDurationCurrentART.TabIndex = 12
        Me.nbxDurationCurrentART.Value = ""
        '
        'nbxWeight
        '
        Me.nbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxWeight.ControlCaption = "Weight"
        Me.nbxWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxWeight.DecimalPlaces = -1
        Me.nbxWeight.Enabled = False
        Me.nbxWeight.Location = New System.Drawing.Point(168, 146)
        Me.nbxWeight.MaxLength = 4
        Me.nbxWeight.MaxValue = 0.0R
        Me.nbxWeight.MinValue = 0.0R
        Me.nbxWeight.MustEnterNumeric = True
        Me.nbxWeight.Name = "nbxWeight"
        Me.nbxWeight.Size = New System.Drawing.Size(170, 20)
        Me.nbxWeight.TabIndex = 14
        Me.nbxWeight.Value = ""
        '
        'nbxHeight
        '
        Me.nbxHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxHeight.ControlCaption = "Height"
        Me.nbxHeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxHeight.DecimalPlaces = -1
        Me.nbxHeight.Enabled = False
        Me.nbxHeight.Location = New System.Drawing.Point(168, 169)
        Me.nbxHeight.MaxLength = 4
        Me.nbxHeight.MaxValue = 0.0R
        Me.nbxHeight.MinValue = 0.0R
        Me.nbxHeight.MustEnterNumeric = True
        Me.nbxHeight.Name = "nbxHeight"
        Me.nbxHeight.Size = New System.Drawing.Size(170, 20)
        Me.nbxHeight.TabIndex = 16
        Me.nbxHeight.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(587, 641)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 89
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(168, 30)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitNo.TabIndex = 4
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 28)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(95, 20)
        Me.lblVisitNo.TabIndex = 2
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblExamVisitTypeID
        '
        Me.lblExamVisitTypeID.Location = New System.Drawing.Point(12, 53)
        Me.lblExamVisitTypeID.Name = "lblExamVisitTypeID"
        Me.lblExamVisitTypeID.Size = New System.Drawing.Size(96, 20)
        Me.lblExamVisitTypeID.TabIndex = 5
        Me.lblExamVisitTypeID.Text = "Exam Visit Type"
        '
        'lblFollowupDate
        '
        Me.lblFollowupDate.Location = New System.Drawing.Point(12, 77)
        Me.lblFollowupDate.Name = "lblFollowupDate"
        Me.lblFollowupDate.Size = New System.Drawing.Size(134, 20)
        Me.lblFollowupDate.TabIndex = 7
        Me.lblFollowupDate.Text = "Followup Date"
        '
        'lblDurationStartART
        '
        Me.lblDurationStartART.Location = New System.Drawing.Point(12, 100)
        Me.lblDurationStartART.Name = "lblDurationStartART"
        Me.lblDurationStartART.Size = New System.Drawing.Size(134, 20)
        Me.lblDurationStartART.TabIndex = 9
        Me.lblDurationStartART.Text = "Duration Start ART"
        '
        'lblDurationCurrentART
        '
        Me.lblDurationCurrentART.Location = New System.Drawing.Point(12, 123)
        Me.lblDurationCurrentART.Name = "lblDurationCurrentART"
        Me.lblDurationCurrentART.Size = New System.Drawing.Size(134, 20)
        Me.lblDurationCurrentART.TabIndex = 11
        Me.lblDurationCurrentART.Text = "Duration Current ART"
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(12, 146)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(134, 20)
        Me.lblWeight.TabIndex = 13
        Me.lblWeight.Text = "Weight"
        '
        'lblHeight
        '
        Me.lblHeight.Location = New System.Drawing.Point(12, 169)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(134, 20)
        Me.lblHeight.TabIndex = 15
        Me.lblHeight.Text = "Height"
        '
        'lblOedema
        '
        Me.lblOedema.Location = New System.Drawing.Point(12, 192)
        Me.lblOedema.Name = "lblOedema"
        Me.lblOedema.Size = New System.Drawing.Size(134, 20)
        Me.lblOedema.TabIndex = 17
        Me.lblOedema.Text = "Oedema"
        '
        'lblPregnancyStatusID
        '
        Me.lblPregnancyStatusID.Location = New System.Drawing.Point(12, 215)
        Me.lblPregnancyStatusID.Name = "lblPregnancyStatusID"
        Me.lblPregnancyStatusID.Size = New System.Drawing.Size(134, 20)
        Me.lblPregnancyStatusID.TabIndex = 19
        Me.lblPregnancyStatusID.Text = "Pregnancy Status"
        '
        'lblExpectedDeliveryDate
        '
        Me.lblExpectedDeliveryDate.Location = New System.Drawing.Point(12, 238)
        Me.lblExpectedDeliveryDate.Name = "lblExpectedDeliveryDate"
        Me.lblExpectedDeliveryDate.Size = New System.Drawing.Size(134, 20)
        Me.lblExpectedDeliveryDate.TabIndex = 21
        Me.lblExpectedDeliveryDate.Text = "Expected Delivery Date"
        '
        'lblGestationalAge
        '
        Me.lblGestationalAge.Location = New System.Drawing.Point(12, 284)
        Me.lblGestationalAge.Name = "lblGestationalAge"
        Me.lblGestationalAge.Size = New System.Drawing.Size(134, 20)
        Me.lblGestationalAge.TabIndex = 24
        Me.lblGestationalAge.Text = "Gestational Age"
        '
        'lblMUACStatusID
        '
        Me.lblMUACStatusID.Location = New System.Drawing.Point(12, 355)
        Me.lblMUACStatusID.Name = "lblMUACStatusID"
        Me.lblMUACStatusID.Size = New System.Drawing.Size(134, 20)
        Me.lblMUACStatusID.TabIndex = 28
        Me.lblMUACStatusID.Text = "MUAC Status"
        '
        'lblFPMethods
        '
        Me.lblFPMethods.Location = New System.Drawing.Point(12, 305)
        Me.lblFPMethods.Name = "lblFPMethods"
        Me.lblFPMethods.Size = New System.Drawing.Size(134, 20)
        Me.lblFPMethods.TabIndex = 26
        Me.lblFPMethods.Text = "FP Methods"
        '
        'lblTBStatusID
        '
        Me.lblTBStatusID.Location = New System.Drawing.Point(12, 379)
        Me.lblTBStatusID.Name = "lblTBStatusID"
        Me.lblTBStatusID.Size = New System.Drawing.Size(134, 20)
        Me.lblTBStatusID.TabIndex = 30
        Me.lblTBStatusID.Text = "TB Status"
        '
        'lblTBRxStartDate
        '
        Me.lblTBRxStartDate.Location = New System.Drawing.Point(12, 402)
        Me.lblTBRxStartDate.Name = "lblTBRxStartDate"
        Me.lblTBRxStartDate.Size = New System.Drawing.Size(134, 20)
        Me.lblTBRxStartDate.TabIndex = 32
        Me.lblTBRxStartDate.Text = "TB Rx Start Date"
        '
        'lblTBRxStopDate
        '
        Me.lblTBRxStopDate.Location = New System.Drawing.Point(12, 425)
        Me.lblTBRxStopDate.Name = "lblTBRxStopDate"
        Me.lblTBRxStopDate.Size = New System.Drawing.Size(134, 20)
        Me.lblTBRxStopDate.TabIndex = 34
        Me.lblTBRxStopDate.Text = "TB Rx Stop Date"
        '
        'lblTBRegNo
        '
        Me.lblTBRegNo.Location = New System.Drawing.Point(12, 448)
        Me.lblTBRegNo.Name = "lblTBRegNo"
        Me.lblTBRegNo.Size = New System.Drawing.Size(134, 20)
        Me.lblTBRegNo.TabIndex = 36
        Me.lblTBRegNo.Text = "TB Reg No"
        '
        'lblSideEffects
        '
        Me.lblSideEffects.Location = New System.Drawing.Point(12, 481)
        Me.lblSideEffects.Name = "lblSideEffects"
        Me.lblSideEffects.Size = New System.Drawing.Size(134, 20)
        Me.lblSideEffects.TabIndex = 38
        Me.lblSideEffects.Text = "Side Effects"
        '
        'lblNewOI
        '
        Me.lblNewOI.Location = New System.Drawing.Point(12, 531)
        Me.lblNewOI.Name = "lblNewOI"
        Me.lblNewOI.Size = New System.Drawing.Size(134, 20)
        Me.lblNewOI.TabIndex = 40
        Me.lblNewOI.Text = "New OI"
        '
        'lbFunctionalStatusID
        '
        Me.lbFunctionalStatusID.Location = New System.Drawing.Point(348, 128)
        Me.lbFunctionalStatusID.Name = "lbFunctionalStatusID"
        Me.lbFunctionalStatusID.Size = New System.Drawing.Size(135, 20)
        Me.lbFunctionalStatusID.TabIndex = 52
        Me.lbFunctionalStatusID.Text = "Functional Status"
        '
        'lblWHOStageID
        '
        Me.lblWHOStageID.Location = New System.Drawing.Point(348, 152)
        Me.lblWHOStageID.Name = "lblWHOStageID"
        Me.lblWHOStageID.Size = New System.Drawing.Size(135, 20)
        Me.lblWHOStageID.TabIndex = 54
        Me.lblWHOStageID.Text = "WHO Stage"
        '
        'lblCPTAdhere
        '
        Me.lblCPTAdhere.Location = New System.Drawing.Point(348, 173)
        Me.lblCPTAdhere.Name = "lblCPTAdhere"
        Me.lblCPTAdhere.Size = New System.Drawing.Size(135, 20)
        Me.lblCPTAdhere.TabIndex = 56
        Me.lblCPTAdhere.Text = "CPT Adhere"
        '
        'lblCPTDosage
        '
        Me.lblCPTDosage.Location = New System.Drawing.Point(348, 195)
        Me.lblCPTDosage.Name = "lblCPTDosage"
        Me.lblCPTDosage.Size = New System.Drawing.Size(135, 20)
        Me.lblCPTDosage.TabIndex = 58
        Me.lblCPTDosage.Text = "CPT Dosage"
        '
        'lblCPTDuration
        '
        Me.lblCPTDuration.Location = New System.Drawing.Point(348, 220)
        Me.lblCPTDuration.Name = "lblCPTDuration"
        Me.lblCPTDuration.Size = New System.Drawing.Size(135, 20)
        Me.lblCPTDuration.TabIndex = 60
        Me.lblCPTDuration.Text = "CPT Duration (Days)"
        '
        'lblOtherMeds
        '
        Me.lblOtherMeds.Location = New System.Drawing.Point(348, 250)
        Me.lblOtherMeds.Name = "lblOtherMeds"
        Me.lblOtherMeds.Size = New System.Drawing.Size(135, 20)
        Me.lblOtherMeds.TabIndex = 62
        Me.lblOtherMeds.Text = "Other Meds"
        '
        'lblARVAdhere
        '
        Me.lblARVAdhere.Location = New System.Drawing.Point(348, 302)
        Me.lblARVAdhere.Name = "lblARVAdhere"
        Me.lblARVAdhere.Size = New System.Drawing.Size(135, 20)
        Me.lblARVAdhere.TabIndex = 66
        Me.lblARVAdhere.Text = "ARV Adhere"
        '
        'lblARVAdhereWhy
        '
        Me.lblARVAdhereWhy.Location = New System.Drawing.Point(348, 326)
        Me.lblARVAdhereWhy.Name = "lblARVAdhereWhy"
        Me.lblARVAdhereWhy.Size = New System.Drawing.Size(135, 20)
        Me.lblARVAdhereWhy.TabIndex = 68
        Me.lblARVAdhereWhy.Text = "ARV Adhere Why"
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(348, 371)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(135, 20)
        Me.lblCombination.TabIndex = 70
        Me.lblCombination.Text = "Combination"
        '
        'lblARVDosage
        '
        Me.lblARVDosage.Location = New System.Drawing.Point(348, 396)
        Me.lblARVDosage.Name = "lblARVDosage"
        Me.lblARVDosage.Size = New System.Drawing.Size(135, 20)
        Me.lblARVDosage.TabIndex = 72
        Me.lblARVDosage.Text = "ARVs Dosage"
        '
        'lblCD4ABS
        '
        Me.lblCD4ABS.Location = New System.Drawing.Point(348, 442)
        Me.lblCD4ABS.Name = "lblCD4ABS"
        Me.lblCD4ABS.Size = New System.Drawing.Size(135, 20)
        Me.lblCD4ABS.TabIndex = 76
        Me.lblCD4ABS.Text = "CD4 ABS"
        '
        'lblCD4PCT
        '
        Me.lblCD4PCT.Location = New System.Drawing.Point(348, 465)
        Me.lblCD4PCT.Name = "lblCD4PCT"
        Me.lblCD4PCT.Size = New System.Drawing.Size(135, 20)
        Me.lblCD4PCT.TabIndex = 78
        Me.lblCD4PCT.Text = "CD4 PCT"
        '
        'lblInvestigations
        '
        Me.lblInvestigations.Location = New System.Drawing.Point(348, 494)
        Me.lblInvestigations.Name = "lblInvestigations"
        Me.lblInvestigations.Size = New System.Drawing.Size(135, 20)
        Me.lblInvestigations.TabIndex = 80
        Me.lblInvestigations.Text = "Investigations"
        '
        'lblRefer
        '
        Me.lblRefer.Location = New System.Drawing.Point(348, 538)
        Me.lblRefer.Name = "lblRefer"
        Me.lblRefer.Size = New System.Drawing.Size(135, 20)
        Me.lblRefer.TabIndex = 82
        Me.lblRefer.Text = "Refer"
        '
        'lblDaysHOSP
        '
        Me.lblDaysHOSP.Location = New System.Drawing.Point(348, 561)
        Me.lblDaysHOSP.Name = "lblDaysHOSP"
        Me.lblDaysHOSP.Size = New System.Drawing.Size(135, 20)
        Me.lblDaysHOSP.TabIndex = 84
        Me.lblDaysHOSP.Text = "Days HOSP"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(135, 29)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 3
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(348, 101)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(135, 20)
        Me.lblPrimaryDoctor.TabIndex = 50
        Me.lblPrimaryDoctor.Text = "Attending Clinician"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(348, 51)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(135, 20)
        Me.lblAge.TabIndex = 46
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(348, 75)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(135, 20)
        Me.lblGenderID.TabIndex = 48
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(348, 28)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(135, 20)
        Me.lblName.TabIndex = 44
        Me.lblName.Text = "Patient's Name"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(12, 5)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(111, 20)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'lblARVDuration
        '
        Me.lblARVDuration.Location = New System.Drawing.Point(348, 420)
        Me.lblARVDuration.Name = "lblARVDuration"
        Me.lblARVDuration.Size = New System.Drawing.Size(135, 20)
        Me.lblARVDuration.TabIndex = 74
        Me.lblARVDuration.Text = "ARVs Duration (Days)"
        '
        'lblNutritionalSupID
        '
        Me.lblNutritionalSupID.Location = New System.Drawing.Point(348, 277)
        Me.lblNutritionalSupID.Name = "lblNutritionalSupID"
        Me.lblNutritionalSupID.Size = New System.Drawing.Size(135, 20)
        Me.lblNutritionalSupID.TabIndex = 64
        Me.lblNutritionalSupID.Text = "Nutritional Supplement"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(348, 4)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(135, 20)
        Me.lblVisitDate.TabIndex = 42
        Me.lblVisitDate.Text = "Visit Date"
        '
        'frmExaminations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(674, 679)
        Me.Controls.Add(Me.txtVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.cboNutritionalSupID)
        Me.Controls.Add(Me.lblNutritionalSupID)
        Me.Controls.Add(Me.nbxARVDosage)
        Me.Controls.Add(Me.nbxARVDuration)
        Me.Controls.Add(Me.lblARVDuration)
        Me.Controls.Add(Me.cboARVAdhereID)
        Me.Controls.Add(Me.cboMUACStatusID)
        Me.Controls.Add(Me.cboCPTAdhereID)
        Me.Controls.Add(Me.nbxCPTDosage)
        Me.Controls.Add(Me.cboOedemaID)
        Me.Controls.Add(Me.cboFunctionalStatusID)
        Me.Controls.Add(Me.clbInvestigations)
        Me.Controls.Add(Me.clbARVAdhereWhy)
        Me.Controls.Add(Me.clbNewOI)
        Me.Controls.Add(Me.clbSideEffects)
        Me.Controls.Add(Me.clbFPMethods)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtPrimaryDoctor)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtPatientNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboExamVisitTypeID)
        Me.Controls.Add(Me.lblExamVisitTypeID)
        Me.Controls.Add(Me.dtpFollowupDate)
        Me.Controls.Add(Me.lblFollowupDate)
        Me.Controls.Add(Me.nbxDurationStartART)
        Me.Controls.Add(Me.lblDurationStartART)
        Me.Controls.Add(Me.nbxDurationCurrentART)
        Me.Controls.Add(Me.lblDurationCurrentART)
        Me.Controls.Add(Me.nbxWeight)
        Me.Controls.Add(Me.lblWeight)
        Me.Controls.Add(Me.nbxHeight)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblOedema)
        Me.Controls.Add(Me.cboPregnancyStatusID)
        Me.Controls.Add(Me.lblPregnancyStatusID)
        Me.Controls.Add(Me.dtpExpectedDeliveryDate)
        Me.Controls.Add(Me.lblExpectedDeliveryDate)
        Me.Controls.Add(Me.chkPMTCT)
        Me.Controls.Add(Me.nbxGestationalAge)
        Me.Controls.Add(Me.lblGestationalAge)
        Me.Controls.Add(Me.lblMUACStatusID)
        Me.Controls.Add(Me.lblFPMethods)
        Me.Controls.Add(Me.cboTBStatusID)
        Me.Controls.Add(Me.lblTBStatusID)
        Me.Controls.Add(Me.dtpTBRxStartDate)
        Me.Controls.Add(Me.lblTBRxStartDate)
        Me.Controls.Add(Me.dtpTBRxStopDate)
        Me.Controls.Add(Me.lblTBRxStopDate)
        Me.Controls.Add(Me.stbTBRegNo)
        Me.Controls.Add(Me.lblTBRegNo)
        Me.Controls.Add(Me.lblSideEffects)
        Me.Controls.Add(Me.lblNewOI)
        Me.Controls.Add(Me.lbFunctionalStatusID)
        Me.Controls.Add(Me.cboWHOStageID)
        Me.Controls.Add(Me.lblWHOStageID)
        Me.Controls.Add(Me.lblCPTAdhere)
        Me.Controls.Add(Me.lblCPTDosage)
        Me.Controls.Add(Me.nbxCPTDuration)
        Me.Controls.Add(Me.lblCPTDuration)
        Me.Controls.Add(Me.stbOtherMeds)
        Me.Controls.Add(Me.lblOtherMeds)
        Me.Controls.Add(Me.lblARVAdhere)
        Me.Controls.Add(Me.lblARVAdhereWhy)
        Me.Controls.Add(Me.cboCombination)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.lblARVDosage)
        Me.Controls.Add(Me.nbxCD4ABS)
        Me.Controls.Add(Me.lblCD4ABS)
        Me.Controls.Add(Me.nbxCD4PCT)
        Me.Controls.Add(Me.lblCD4PCT)
        Me.Controls.Add(Me.lblInvestigations)
        Me.Controls.Add(Me.stbRefer)
        Me.Controls.Add(Me.lblRefer)
        Me.Controls.Add(Me.nbxDaysHOSP)
        Me.Controls.Add(Me.lblDaysHOSP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExaminations"
        Me.Text = "Follow-up"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboExamVisitTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblExamVisitTypeID As System.Windows.Forms.Label
    Friend WithEvents dtpFollowupDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFollowupDate As System.Windows.Forms.Label
    Friend WithEvents nbxDurationStartART As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDurationStartART As System.Windows.Forms.Label
    Friend WithEvents nbxDurationCurrentART As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDurationCurrentART As System.Windows.Forms.Label
    Friend WithEvents nbxWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents nbxHeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblOedema As System.Windows.Forms.Label
    Friend WithEvents cboPregnancyStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPregnancyStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpExpectedDeliveryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpectedDeliveryDate As System.Windows.Forms.Label
    Friend WithEvents chkPMTCT As System.Windows.Forms.CheckBox
    Friend WithEvents nbxGestationalAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblGestationalAge As System.Windows.Forms.Label
    Friend WithEvents lblMUACStatusID As System.Windows.Forms.Label
    Friend WithEvents lblFPMethods As System.Windows.Forms.Label
    Friend WithEvents cboTBStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTBStatusID As System.Windows.Forms.Label
    Friend WithEvents dtpTBRxStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTBRxStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpTBRxStopDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTBRxStopDate As System.Windows.Forms.Label
    Friend WithEvents stbTBRegNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTBRegNo As System.Windows.Forms.Label
    Friend WithEvents lblSideEffects As System.Windows.Forms.Label
    Friend WithEvents lblNewOI As System.Windows.Forms.Label
    Friend WithEvents lbFunctionalStatusID As System.Windows.Forms.Label
    Friend WithEvents cboWHOStageID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWHOStageID As System.Windows.Forms.Label
    Friend WithEvents lblCPTAdhere As System.Windows.Forms.Label
    Friend WithEvents lblCPTDosage As System.Windows.Forms.Label
    Friend WithEvents nbxCPTDuration As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCPTDuration As System.Windows.Forms.Label
    Friend WithEvents stbOtherMeds As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOtherMeds As System.Windows.Forms.Label
    Friend WithEvents lblARVAdhere As System.Windows.Forms.Label
    Friend WithEvents lblARVAdhereWhy As System.Windows.Forms.Label
    Friend WithEvents cboCombination As System.Windows.Forms.ComboBox
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents lblARVDosage As System.Windows.Forms.Label
    Friend WithEvents nbxCD4ABS As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCD4ABS As System.Windows.Forms.Label
    Friend WithEvents nbxCD4PCT As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCD4PCT As System.Windows.Forms.Label
    Friend WithEvents lblInvestigations As System.Windows.Forms.Label
    Friend WithEvents stbRefer As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefer As System.Windows.Forms.Label
    Friend WithEvents nbxDaysHOSP As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDaysHOSP As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimaryDoctor As System.Windows.Forms.TextBox
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents txtPatientNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents clbFPMethods As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbSideEffects As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbNewOI As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbARVAdhereWhy As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbInvestigations As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboFunctionalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents cboOedemaID As System.Windows.Forms.ComboBox
    Friend WithEvents cboCPTAdhereID As System.Windows.Forms.ComboBox
    Friend WithEvents nbxCPTDosage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboMUACStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents cboARVAdhereID As System.Windows.Forms.ComboBox
    Friend WithEvents nbxARVDosage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxARVDuration As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblARVDuration As System.Windows.Forms.Label
    Friend WithEvents cboNutritionalSupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblNutritionalSupID As System.Windows.Forms.Label
    Friend WithEvents txtVisitDate As System.Windows.Forms.TextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label

End Class