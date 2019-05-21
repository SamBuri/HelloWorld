
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExternalReferrals : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExternalReferrals))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbProcedurePaidBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEmployeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferredTo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpDateOfReferral = New System.Windows.Forms.DateTimePicker()
        Me.stbHistoryAndSymptoms = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTreatmentGiven = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReasonForReferral = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.stbAuthorisedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxTreatmentLimit = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stpStartTime = New SyncSoft.Common.Win.Controls.SmartTimePicker()
        Me.stbDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblProcedurePaidBy = New System.Windows.Forms.Label()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.lblRefferedTo = New System.Windows.Forms.Label()
        Me.lblDepartureTime = New System.Windows.Forms.Label()
        Me.lblDateOfReferral = New System.Windows.Forms.Label()
        Me.lblHistoryAndSymptoms = New System.Windows.Forms.Label()
        Me.lblTreatmentGiven = New System.Windows.Forms.Label()
        Me.lblReasonForReferral = New System.Windows.Forms.Label()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.lblAuthorisedBy = New System.Windows.Forms.Label()
        Me.lblTreatmentLimit = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.chkPrintReferralNoteOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbInvestigationsMade = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvestigationsMade = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(9, 468)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 57
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(589, 467)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 60
        Me.fbnDelete.Tag = "ExternalReferrals"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(9, 495)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 58
        Me.ebnSaveUpdate.Tag = "ExternalReferrals"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbProcedurePaidBy
        '
        Me.stbProcedurePaidBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProcedurePaidBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbProcedurePaidBy, "ProcedurePaidBy")
        Me.stbProcedurePaidBy.EntryErrorMSG = ""
        Me.stbProcedurePaidBy.Location = New System.Drawing.Point(150, 29)
        Me.stbProcedurePaidBy.MaxLength = 200
        Me.stbProcedurePaidBy.Name = "stbProcedurePaidBy"
        Me.stbProcedurePaidBy.RegularExpression = ""
        Me.stbProcedurePaidBy.Size = New System.Drawing.Size(244, 20)
        Me.stbProcedurePaidBy.TabIndex = 5
        '
        'stbEmployeeName
        '
        Me.stbEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmployeeName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmployeeName, "EmployeeName")
        Me.stbEmployeeName.EntryErrorMSG = ""
        Me.stbEmployeeName.Location = New System.Drawing.Point(150, 50)
        Me.stbEmployeeName.MaxLength = 200
        Me.stbEmployeeName.Name = "stbEmployeeName"
        Me.stbEmployeeName.RegularExpression = ""
        Me.stbEmployeeName.Size = New System.Drawing.Size(244, 20)
        Me.stbEmployeeName.TabIndex = 7
        '
        'stbReferredTo
        '
        Me.stbReferredTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferredTo.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferredTo, "ReferredTo")
        Me.stbReferredTo.EntryErrorMSG = ""
        Me.stbReferredTo.Location = New System.Drawing.Point(150, 71)
        Me.stbReferredTo.MaxLength = 200
        Me.stbReferredTo.Name = "stbReferredTo"
        Me.stbReferredTo.RegularExpression = ""
        Me.stbReferredTo.Size = New System.Drawing.Size(244, 20)
        Me.stbReferredTo.TabIndex = 9
        '
        'dtpDateOfReferral
        '
        Me.dtpDateOfReferral.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDateOfReferral, "DateOfReferral")
        Me.dtpDateOfReferral.Location = New System.Drawing.Point(150, 112)
        Me.dtpDateOfReferral.Name = "dtpDateOfReferral"
        Me.dtpDateOfReferral.ShowCheckBox = True
        Me.dtpDateOfReferral.Size = New System.Drawing.Size(170, 20)
        Me.dtpDateOfReferral.TabIndex = 13
        '
        'stbHistoryAndSymptoms
        '
        Me.stbHistoryAndSymptoms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHistoryAndSymptoms.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbHistoryAndSymptoms, "HistoryAndSymptoms")
        Me.stbHistoryAndSymptoms.EntryErrorMSG = ""
        Me.stbHistoryAndSymptoms.Location = New System.Drawing.Point(150, 133)
        Me.stbHistoryAndSymptoms.MaxLength = 2000
        Me.stbHistoryAndSymptoms.Multiline = True
        Me.stbHistoryAndSymptoms.Name = "stbHistoryAndSymptoms"
        Me.stbHistoryAndSymptoms.RegularExpression = ""
        Me.stbHistoryAndSymptoms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbHistoryAndSymptoms.Size = New System.Drawing.Size(244, 48)
        Me.stbHistoryAndSymptoms.TabIndex = 15
        '
        'stbTreatmentGiven
        '
        Me.stbTreatmentGiven.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTreatmentGiven.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbTreatmentGiven, "TreatmentGiven")
        Me.stbTreatmentGiven.EntryErrorMSG = ""
        Me.stbTreatmentGiven.Location = New System.Drawing.Point(150, 272)
        Me.stbTreatmentGiven.MaxLength = 2000
        Me.stbTreatmentGiven.Multiline = True
        Me.stbTreatmentGiven.Name = "stbTreatmentGiven"
        Me.stbTreatmentGiven.RegularExpression = ""
        Me.stbTreatmentGiven.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTreatmentGiven.Size = New System.Drawing.Size(244, 48)
        Me.stbTreatmentGiven.TabIndex = 21
        '
        'stbReasonForReferral
        '
        Me.stbReasonForReferral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReasonForReferral.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReasonForReferral, "ReasonForReferral")
        Me.stbReasonForReferral.EntryErrorMSG = ""
        Me.stbReasonForReferral.Location = New System.Drawing.Point(150, 321)
        Me.stbReasonForReferral.MaxLength = 2000
        Me.stbReasonForReferral.Multiline = True
        Me.stbReasonForReferral.Name = "stbReasonForReferral"
        Me.stbReasonForReferral.RegularExpression = ""
        Me.stbReasonForReferral.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReasonForReferral.Size = New System.Drawing.Size(244, 48)
        Me.stbReasonForReferral.TabIndex = 23
        '
        'cboStaffNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(150, 371)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(244, 21)
        Me.cboStaffNo.TabIndex = 25
        '
        'stbAuthorisedBy
        '
        Me.stbAuthorisedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAuthorisedBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAuthorisedBy, "AuthorisedBy")
        Me.stbAuthorisedBy.EntryErrorMSG = ""
        Me.stbAuthorisedBy.Location = New System.Drawing.Point(150, 394)
        Me.stbAuthorisedBy.Name = "stbAuthorisedBy"
        Me.stbAuthorisedBy.RegularExpression = ""
        Me.stbAuthorisedBy.Size = New System.Drawing.Size(244, 20)
        Me.stbAuthorisedBy.TabIndex = 27
        '
        'nbxTreatmentLimit
        '
        Me.nbxTreatmentLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTreatmentLimit.ControlCaption = "TreatmentLimit"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxTreatmentLimit, "TreatmentLimit")
        Me.nbxTreatmentLimit.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxTreatmentLimit.DecimalPlaces = -1
        Me.nbxTreatmentLimit.Location = New System.Drawing.Point(150, 415)
        Me.nbxTreatmentLimit.MaxValue = 0.0R
        Me.nbxTreatmentLimit.MinValue = 0.0R
        Me.nbxTreatmentLimit.MustEnterNumeric = True
        Me.nbxTreatmentLimit.Name = "nbxTreatmentLimit"
        Me.nbxTreatmentLimit.Size = New System.Drawing.Size(244, 20)
        Me.nbxTreatmentLimit.TabIndex = 29
        Me.nbxTreatmentLimit.Value = ""
        '
        'stpStartTime
        '
        Me.stpStartTime.Checked = False
        Me.stpStartTime.CustomFormat = "hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.stpStartTime, "DepartureTime")
        Me.stpStartTime.Location = New System.Drawing.Point(150, 91)
        Me.stpStartTime.Name = "stpStartTime"
        Me.stpStartTime.ShowCheckBox = True
        Me.stpStartTime.ShowUpDown = True
        Me.stpStartTime.Size = New System.Drawing.Size(90, 20)
        Me.stpStartTime.TabIndex = 11
        Me.stpStartTime.Value = New Date(2011, 9, 19, 13, 49, 25, 18)
        '
        'stbDiagnosis
        '
        Me.stbDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiagnosis.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiagnosis, "Diagnosis")
        Me.stbDiagnosis.EntryErrorMSG = ""
        Me.stbDiagnosis.Location = New System.Drawing.Point(150, 228)
        Me.stbDiagnosis.MaxLength = 2000
        Me.stbDiagnosis.Multiline = True
        Me.stbDiagnosis.Name = "stbDiagnosis"
        Me.stbDiagnosis.RegularExpression = ""
        Me.stbDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDiagnosis.Size = New System.Drawing.Size(244, 42)
        Me.stbDiagnosis.TabIndex = 19
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(574, 298)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(149, 20)
        Me.stbInsuranceNo.TabIndex = 52
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = False
        Me.stbAddress.Enabled = False
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(574, 354)
        Me.stbAddress.MaxLength = 41
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.ReadOnly = True
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.Size = New System.Drawing.Size(149, 47)
        Me.stbAddress.TabIndex = 56
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(574, 214)
        Me.stbPhone.MaxLength = 60
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.ReadOnly = True
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPhone.Size = New System.Drawing.Size(149, 20)
        Me.stbPhone.TabIndex = 44
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(574, 277)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(149, 20)
        Me.nbxOutstandingBalance.TabIndex = 50
        Me.nbxOutstandingBalance.Value = ""
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(574, 256)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.ReadOnly = True
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(149, 20)
        Me.stbTotalVisits.TabIndex = 48
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(574, 319)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(149, 34)
        Me.stbInsuranceName.TabIndex = 54
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(574, 235)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.ReadOnly = True
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbLastVisitDate.TabIndex = 46
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(574, 193)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ReadOnly = True
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitDate.TabIndex = 42
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(574, 5)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 100)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 83
        Me.spbPhoto.TabStop = False
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(574, 151)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.ReadOnly = True
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(44, 20)
        Me.stbAge.TabIndex = 38
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(574, 172)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
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
        Me.stbFullName.Location = New System.Drawing.Point(574, 109)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 34
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(589, 494)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 61
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblProcedurePaidBy
        '
        Me.lblProcedurePaidBy.Location = New System.Drawing.Point(7, 31)
        Me.lblProcedurePaidBy.Name = "lblProcedurePaidBy"
        Me.lblProcedurePaidBy.Size = New System.Drawing.Size(137, 20)
        Me.lblProcedurePaidBy.TabIndex = 4
        Me.lblProcedurePaidBy.Text = "Procedure Paid By"
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.Location = New System.Drawing.Point(7, 52)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(137, 20)
        Me.lblEmployeeName.TabIndex = 6
        Me.lblEmployeeName.Text = "Employee Name"
        '
        'lblRefferedTo
        '
        Me.lblRefferedTo.Location = New System.Drawing.Point(7, 71)
        Me.lblRefferedTo.Name = "lblRefferedTo"
        Me.lblRefferedTo.Size = New System.Drawing.Size(137, 20)
        Me.lblRefferedTo.TabIndex = 8
        Me.lblRefferedTo.Text = "Reffered To"
        '
        'lblDepartureTime
        '
        Me.lblDepartureTime.Location = New System.Drawing.Point(7, 91)
        Me.lblDepartureTime.Name = "lblDepartureTime"
        Me.lblDepartureTime.Size = New System.Drawing.Size(137, 20)
        Me.lblDepartureTime.TabIndex = 10
        Me.lblDepartureTime.Text = "Departure Time"
        '
        'lblDateOfReferral
        '
        Me.lblDateOfReferral.Location = New System.Drawing.Point(7, 112)
        Me.lblDateOfReferral.Name = "lblDateOfReferral"
        Me.lblDateOfReferral.Size = New System.Drawing.Size(137, 20)
        Me.lblDateOfReferral.TabIndex = 12
        Me.lblDateOfReferral.Text = "Date Of Referral"
        '
        'lblHistoryAndSymptoms
        '
        Me.lblHistoryAndSymptoms.Location = New System.Drawing.Point(7, 133)
        Me.lblHistoryAndSymptoms.Name = "lblHistoryAndSymptoms"
        Me.lblHistoryAndSymptoms.Size = New System.Drawing.Size(137, 20)
        Me.lblHistoryAndSymptoms.TabIndex = 14
        Me.lblHistoryAndSymptoms.Text = "History And Symptoms"
        '
        'lblTreatmentGiven
        '
        Me.lblTreatmentGiven.Location = New System.Drawing.Point(7, 274)
        Me.lblTreatmentGiven.Name = "lblTreatmentGiven"
        Me.lblTreatmentGiven.Size = New System.Drawing.Size(137, 20)
        Me.lblTreatmentGiven.TabIndex = 20
        Me.lblTreatmentGiven.Text = "Treatment Given"
        '
        'lblReasonForReferral
        '
        Me.lblReasonForReferral.Location = New System.Drawing.Point(7, 321)
        Me.lblReasonForReferral.Name = "lblReasonForReferral"
        Me.lblReasonForReferral.Size = New System.Drawing.Size(137, 20)
        Me.lblReasonForReferral.TabIndex = 22
        Me.lblReasonForReferral.Text = "Reason For Referral"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(7, 371)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(137, 20)
        Me.lblStaffNo.TabIndex = 24
        Me.lblStaffNo.Text = "Name Of Clinician"
        '
        'lblAuthorisedBy
        '
        Me.lblAuthorisedBy.Location = New System.Drawing.Point(7, 394)
        Me.lblAuthorisedBy.Name = "lblAuthorisedBy"
        Me.lblAuthorisedBy.Size = New System.Drawing.Size(137, 20)
        Me.lblAuthorisedBy.TabIndex = 26
        Me.lblAuthorisedBy.Text = "Authorised By"
        '
        'lblTreatmentLimit
        '
        Me.lblTreatmentLimit.Location = New System.Drawing.Point(7, 415)
        Me.lblTreatmentLimit.Name = "lblTreatmentLimit"
        Me.lblTreatmentLimit.Size = New System.Drawing.Size(137, 20)
        Me.lblTreatmentLimit.TabIndex = 28
        Me.lblTreatmentLimit.Text = "Treatment Limit"
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(420, 299)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(148, 20)
        Me.lblInsuranceNo.TabIndex = 51
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(420, 216)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(148, 20)
        Me.lblPhone.TabIndex = 43
        Me.lblPhone.Text = "Phone"
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(420, 279)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(148, 20)
        Me.lblOutstandingBalance.TabIndex = 49
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(420, 257)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(148, 20)
        Me.lblTotalVisits.TabIndex = 47
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(420, 356)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(148, 18)
        Me.lblAddress.TabIndex = 55
        Me.lblAddress.Text = "Address"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(420, 328)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(148, 20)
        Me.lblBillInsuranceName.TabIndex = 53
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(420, 237)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(148, 20)
        Me.lblLastVisitDate.TabIndex = 45
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(420, 195)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(148, 20)
        Me.lblVisitDate.TabIndex = 41
        Me.lblVisitDate.Text = "Visit Date"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(418, 31)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(145, 21)
        Me.chkFingerprintCaptured.TabIndex = 31
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(423, 79)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(145, 23)
        Me.btnFindByFingerprint.TabIndex = 32
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(420, 9)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(148, 20)
        Me.lblPhoto.TabIndex = 30
        Me.lblPhoto.Text = "Photo"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(420, 153)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(148, 20)
        Me.lblAge.TabIndex = 37
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(420, 174)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(148, 20)
        Me.lblGenderID.TabIndex = 39
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(420, 111)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(148, 20)
        Me.lblName.TabIndex = 33
        Me.lblName.Text = "Patient's Name"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(117, 7)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(150, 8)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(154, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(7, 11)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(101, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit Number"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(574, 130)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 36
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(420, 130)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(148, 20)
        Me.lblPatientsNo.TabIndex = 35
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(307, 4)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.Location = New System.Drawing.Point(7, 228)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(137, 20)
        Me.lblDiagnosis.TabIndex = 18
        Me.lblDiagnosis.Text = "Diagnosis"
        '
        'chkPrintReferralNoteOnSaving
        '
        Me.chkPrintReferralNoteOnSaving.AutoSize = True
        Me.chkPrintReferralNoteOnSaving.Checked = True
        Me.chkPrintReferralNoteOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintReferralNoteOnSaving.Location = New System.Drawing.Point(92, 499)
        Me.chkPrintReferralNoteOnSaving.Name = "chkPrintReferralNoteOnSaving"
        Me.chkPrintReferralNoteOnSaving.Size = New System.Drawing.Size(166, 17)
        Me.chkPrintReferralNoteOnSaving.TabIndex = 59
        Me.chkPrintReferralNoteOnSaving.Text = "Print Referral Note On Saving"
        Me.chkPrintReferralNoteOnSaving.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(667, 494)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 62
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        Me.btnPrint.Visible = False
        '
        'stbInvestigationsMade
        '
        Me.stbInvestigationsMade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvestigationsMade.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbInvestigationsMade, "LabInvestigations")
        Me.stbInvestigationsMade.EntryErrorMSG = ""
        Me.stbInvestigationsMade.Location = New System.Drawing.Point(150, 183)
        Me.stbInvestigationsMade.MaxLength = 2000
        Me.stbInvestigationsMade.Multiline = True
        Me.stbInvestigationsMade.Name = "stbInvestigationsMade"
        Me.stbInvestigationsMade.RegularExpression = ""
        Me.stbInvestigationsMade.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInvestigationsMade.Size = New System.Drawing.Size(244, 42)
        Me.stbInvestigationsMade.TabIndex = 17
        '
        'lblInvestigationsMade
        '
        Me.lblInvestigationsMade.Location = New System.Drawing.Point(7, 185)
        Me.lblInvestigationsMade.Name = "lblInvestigationsMade"
        Me.lblInvestigationsMade.Size = New System.Drawing.Size(137, 20)
        Me.lblInvestigationsMade.TabIndex = 16
        Me.lblInvestigationsMade.Text = "Lab Investigations"
        '
        'frmExternalReferrals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(748, 527)
        Me.Controls.Add(Me.stbInvestigationsMade)
        Me.Controls.Add(Me.lblInvestigationsMade)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintReferralNoteOnSaving)
        Me.Controls.Add(Me.stbDiagnosis)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stpStartTime)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbProcedurePaidBy)
        Me.Controls.Add(Me.lblProcedurePaidBy)
        Me.Controls.Add(Me.stbEmployeeName)
        Me.Controls.Add(Me.lblEmployeeName)
        Me.Controls.Add(Me.stbReferredTo)
        Me.Controls.Add(Me.lblRefferedTo)
        Me.Controls.Add(Me.lblDepartureTime)
        Me.Controls.Add(Me.dtpDateOfReferral)
        Me.Controls.Add(Me.lblDateOfReferral)
        Me.Controls.Add(Me.stbHistoryAndSymptoms)
        Me.Controls.Add(Me.lblHistoryAndSymptoms)
        Me.Controls.Add(Me.stbTreatmentGiven)
        Me.Controls.Add(Me.lblTreatmentGiven)
        Me.Controls.Add(Me.stbReasonForReferral)
        Me.Controls.Add(Me.lblReasonForReferral)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.stbAuthorisedBy)
        Me.Controls.Add(Me.lblAuthorisedBy)
        Me.Controls.Add(Me.nbxTreatmentLimit)
        Me.Controls.Add(Me.lblTreatmentLimit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExternalReferrals"
        Me.Text = "External Referrals"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbProcedurePaidBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProcedurePaidBy As System.Windows.Forms.Label
    Friend WithEvents stbEmployeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmployeeName As System.Windows.Forms.Label
    Friend WithEvents stbReferredTo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefferedTo As System.Windows.Forms.Label
    Friend WithEvents lblDepartureTime As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfReferral As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateOfReferral As System.Windows.Forms.Label
    Friend WithEvents stbHistoryAndSymptoms As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHistoryAndSymptoms As System.Windows.Forms.Label
    Friend WithEvents stbTreatmentGiven As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTreatmentGiven As System.Windows.Forms.Label
    Friend WithEvents stbReasonForReferral As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReasonForReferral As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents stbAuthorisedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAuthorisedBy As System.Windows.Forms.Label
    Friend WithEvents nbxTreatmentLimit As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblTreatmentLimit As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As Label
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents chkFingerprintCaptured As CheckBox
    Friend WithEvents btnFindByFingerprint As Button
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents lblGenderID As Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As Label
    Friend WithEvents btnFindVisitNo As Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As Label
    Friend WithEvents stpStartTime As SyncSoft.Common.Win.Controls.SmartTimePicker
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As Label
    Friend WithEvents btnLoadPeriodicVisits As Button
    Friend WithEvents stbDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiagnosis As Label
    Friend WithEvents chkPrintReferralNoteOnSaving As CheckBox
    Friend WithEvents btnPrint As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbInvestigationsMade As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvestigationsMade As System.Windows.Forms.Label
End Class