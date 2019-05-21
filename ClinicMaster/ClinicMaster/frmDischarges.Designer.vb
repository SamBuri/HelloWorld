
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDischarges : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDischarges))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpDischargeDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbDischargeNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDischargeStatusID = New System.Windows.Forms.ComboBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.dtpReviewDate = New System.Windows.Forms.DateTimePicker()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbExamination = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbKeyFindInvestigation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbHistory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTreatmentOnWard = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTreatmentOutcome = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbKeyRecommendations = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbServiceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.lblDischargeDateTime = New System.Windows.Forms.Label()
        Me.lblDischargeStatusID = New System.Windows.Forms.Label()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblServiceName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbBedNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRoomNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.lblBedNo = New System.Windows.Forms.Label()
        Me.stbWard = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblWard = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.stbLastRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastRoundDateTime = New System.Windows.Forms.Label()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.lblReviewDate = New System.Windows.Forms.Label()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.tbcDrRoles = New System.Windows.Forms.TabControl()
        Me.tpgDischargeNotes = New System.Windows.Forms.TabPage()
        Me.lblSilentFeatures = New System.Windows.Forms.Label()
        Me.lblHistory = New System.Windows.Forms.Label()
        Me.lblExamination = New System.Windows.Forms.Label()
        Me.lblKeyFindInvestigation = New System.Windows.Forms.Label()
        Me.lblTreatmentOnWard = New System.Windows.Forms.Label()
        Me.lblTreatmentOutcome = New System.Windows.Forms.Label()
        Me.lblKeyRecommendations = New System.Windows.Forms.Label()
        Me.lblOtherNotes = New System.Windows.Forms.Label()
        Me.tpgPrescriptions = New System.Windows.Forms.TabPage()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvailableStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colHasAlternateDrugs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsDischarges = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsDischargesQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colICDDiagnosisCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.chkPrintDischargeReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.pnlGenerateInvoice = New System.Windows.Forms.Panel()
        Me.chkGenerateInvoiceOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnGenerateInvoice = New System.Windows.Forms.Button()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.chkReconciliationRequired = New System.Windows.Forms.CheckBox()
        Me.tbcDrRoles.SuspendLayout()
        Me.tpgDischargeNotes.SuspendLayout()
        Me.tpgPrescriptions.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDischarges.SuspendLayout()
        Me.tpgDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.pnlGenerateInvoice.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(14, 516)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 50
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(880, 516)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 57
        Me.fbnDelete.Tag = "Discharges"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(14, 543)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 51
        Me.ebnSaveUpdate.Tag = "Discharges"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpDischargeDateTime
        '
        Me.dtpDischargeDateTime.Checked = False
        Me.dtpDischargeDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDischargeDateTime, "DischargeDateTime")
        Me.dtpDischargeDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDischargeDateTime.Location = New System.Drawing.Point(136, 70)
        Me.dtpDischargeDateTime.Name = "dtpDischargeDateTime"
        Me.dtpDischargeDateTime.ShowCheckBox = True
        Me.dtpDischargeDateTime.Size = New System.Drawing.Size(164, 20)
        Me.dtpDischargeDateTime.TabIndex = 9
        '
        'stbDischargeNotes
        '
        Me.stbDischargeNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDischargeNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDischargeNotes, "DischargeNotes")
        Me.stbDischargeNotes.EntryErrorMSG = ""
        Me.stbDischargeNotes.Location = New System.Drawing.Point(480, 231)
        Me.stbDischargeNotes.MaxLength = 400
        Me.stbDischargeNotes.Multiline = True
        Me.stbDischargeNotes.Name = "stbDischargeNotes"
        Me.stbDischargeNotes.RegularExpression = ""
        Me.stbDischargeNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDischargeNotes.Size = New System.Drawing.Size(442, 50)
        Me.stbDischargeNotes.TabIndex = 9
        '
        'cboDischargeStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDischargeStatusID, "DischargeStatus,DischargeStatusID")
        Me.cboDischargeStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDischargeStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDischargeStatusID.Location = New System.Drawing.Point(136, 90)
        Me.cboDischargeStatusID.Name = "cboDischargeStatusID"
        Me.cboDischargeStatusID.Size = New System.Drawing.Size(164, 21)
        Me.cboDischargeStatusID.TabIndex = 11
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(136, 27)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(164, 21)
        Me.cboStaffNo.TabIndex = 5
        '
        'dtpReviewDate
        '
        Me.dtpReviewDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReviewDate, "ReviewDate")
        Me.dtpReviewDate.Location = New System.Drawing.Point(136, 113)
        Me.dtpReviewDate.Name = "dtpReviewDate"
        Me.dtpReviewDate.ShowCheckBox = True
        Me.dtpReviewDate.Size = New System.Drawing.Size(164, 20)
        Me.dtpReviewDate.TabIndex = 13
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRoundNo, "RoundNo")
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(136, 49)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(164, 20)
        Me.stbRoundNo.TabIndex = 7
        '
        'stbExamination
        '
        Me.stbExamination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExamination.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbExamination, "Examination")
        Me.stbExamination.EntryErrorMSG = ""
        Me.stbExamination.Location = New System.Drawing.Point(36, 128)
        Me.stbExamination.MaxLength = 400
        Me.stbExamination.Multiline = True
        Me.stbExamination.Name = "stbExamination"
        Me.stbExamination.RegularExpression = ""
        Me.stbExamination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExamination.Size = New System.Drawing.Size(417, 66)
        Me.stbExamination.TabIndex = 2
        '
        'stbKeyFindInvestigation
        '
        Me.stbKeyFindInvestigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbKeyFindInvestigation.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbKeyFindInvestigation, "KeyFindingsInvestigation")
        Me.stbKeyFindInvestigation.EntryErrorMSG = ""
        Me.stbKeyFindInvestigation.Location = New System.Drawing.Point(11, 215)
        Me.stbKeyFindInvestigation.MaxLength = 400
        Me.stbKeyFindInvestigation.Multiline = True
        Me.stbKeyFindInvestigation.Name = "stbKeyFindInvestigation"
        Me.stbKeyFindInvestigation.RegularExpression = ""
        Me.stbKeyFindInvestigation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbKeyFindInvestigation.Size = New System.Drawing.Size(442, 66)
        Me.stbKeyFindInvestigation.TabIndex = 8
        '
        'stbHistory
        '
        Me.stbHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHistory.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbHistory, "History")
        Me.stbHistory.EntryErrorMSG = ""
        Me.stbHistory.Location = New System.Drawing.Point(36, 44)
        Me.stbHistory.MaxLength = 400
        Me.stbHistory.Multiline = True
        Me.stbHistory.Name = "stbHistory"
        Me.stbHistory.RegularExpression = ""
        Me.stbHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbHistory.Size = New System.Drawing.Size(417, 66)
        Me.stbHistory.TabIndex = 1
        '
        'stbTreatmentOnWard
        '
        Me.stbTreatmentOnWard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTreatmentOnWard.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbTreatmentOnWard, "TreatmentOnWard")
        Me.stbTreatmentOnWard.EntryErrorMSG = ""
        Me.stbTreatmentOnWard.Location = New System.Drawing.Point(478, 21)
        Me.stbTreatmentOnWard.MaxLength = 400
        Me.stbTreatmentOnWard.Multiline = True
        Me.stbTreatmentOnWard.Name = "stbTreatmentOnWard"
        Me.stbTreatmentOnWard.RegularExpression = ""
        Me.stbTreatmentOnWard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTreatmentOnWard.Size = New System.Drawing.Size(442, 50)
        Me.stbTreatmentOnWard.TabIndex = 4
        '
        'stbTreatmentOutcome
        '
        Me.stbTreatmentOutcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTreatmentOutcome.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbTreatmentOutcome, "OutcomeOfTreatment")
        Me.stbTreatmentOutcome.EntryErrorMSG = ""
        Me.stbTreatmentOutcome.Location = New System.Drawing.Point(478, 89)
        Me.stbTreatmentOutcome.MaxLength = 400
        Me.stbTreatmentOutcome.Multiline = True
        Me.stbTreatmentOutcome.Name = "stbTreatmentOutcome"
        Me.stbTreatmentOutcome.RegularExpression = ""
        Me.stbTreatmentOutcome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTreatmentOutcome.Size = New System.Drawing.Size(442, 50)
        Me.stbTreatmentOutcome.TabIndex = 5
        '
        'stbKeyRecommendations
        '
        Me.stbKeyRecommendations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbKeyRecommendations.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbKeyRecommendations, "KeyRecommendations")
        Me.stbKeyRecommendations.EntryErrorMSG = ""
        Me.stbKeyRecommendations.Location = New System.Drawing.Point(480, 160)
        Me.stbKeyRecommendations.MaxLength = 400
        Me.stbKeyRecommendations.Multiline = True
        Me.stbKeyRecommendations.Name = "stbKeyRecommendations"
        Me.stbKeyRecommendations.RegularExpression = ""
        Me.stbKeyRecommendations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbKeyRecommendations.Size = New System.Drawing.Size(442, 50)
        Me.stbKeyRecommendations.TabIndex = 6
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(429, 65)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(125, 20)
        Me.stbAdmissionDateTime.TabIndex = 24
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(429, 2)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(125, 20)
        Me.stbPatientNo.TabIndex = 18
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(881, 45)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(74, 20)
        Me.stbBillMode.TabIndex = 43
        '
        'stbServiceName
        '
        Me.stbServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbServiceName.CapitalizeFirstLetter = False
        Me.stbServiceName.Enabled = False
        Me.stbServiceName.EntryErrorMSG = ""
        Me.stbServiceName.Location = New System.Drawing.Point(660, 2)
        Me.stbServiceName.MaxLength = 60
        Me.stbServiceName.Name = "stbServiceName"
        Me.stbServiceName.RegularExpression = ""
        Me.stbServiceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbServiceName.Size = New System.Drawing.Size(145, 20)
        Me.stbServiceName.TabIndex = 31
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(660, 23)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(145, 20)
        Me.stbBillNo.TabIndex = 33
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(881, 24)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(74, 20)
        Me.stbAge.TabIndex = 41
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(881, 3)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(74, 20)
        Me.stbGender.TabIndex = 39
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(136, 134)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(164, 20)
        Me.stbFullName.TabIndex = 15
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(880, 543)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 56
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(136, 6)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(116, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.Location = New System.Drawing.Point(11, 5)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(86, 20)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'lblDischargeDateTime
        '
        Me.lblDischargeDateTime.Location = New System.Drawing.Point(11, 72)
        Me.lblDischargeDateTime.Name = "lblDischargeDateTime"
        Me.lblDischargeDateTime.Size = New System.Drawing.Size(119, 18)
        Me.lblDischargeDateTime.TabIndex = 8
        Me.lblDischargeDateTime.Text = "Discharge Date Time"
        '
        'lblDischargeStatusID
        '
        Me.lblDischargeStatusID.Location = New System.Drawing.Point(11, 93)
        Me.lblDischargeStatusID.Name = "lblDischargeStatusID"
        Me.lblDischargeStatusID.Size = New System.Drawing.Size(119, 18)
        Me.lblDischargeStatusID.TabIndex = 10
        Me.lblDischargeStatusID.Text = "Discharge Status"
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(103, 6)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(306, 3)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(117, 18)
        Me.lblPatientsNo.TabIndex = 17
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(811, 45)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(64, 18)
        Me.lblBillMode.TabIndex = 42
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblServiceName
        '
        Me.lblServiceName.Location = New System.Drawing.Point(560, 2)
        Me.lblServiceName.Name = "lblServiceName"
        Me.lblServiceName.Size = New System.Drawing.Size(94, 18)
        Me.lblServiceName.TabIndex = 30
        Me.lblServiceName.Text = "To-Bill Service"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(560, 21)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(94, 18)
        Me.lblBillNo.TabIndex = 32
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(811, 24)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(64, 18)
        Me.lblAge.TabIndex = 40
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(811, 3)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(64, 18)
        Me.lblGenderID.TabIndex = 38
        Me.lblGenderID.Text = "Gender"
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(306, 65)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(117, 18)
        Me.lblAdmissionDateTime.TabIndex = 23
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(11, 138)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(119, 18)
        Me.lblFullName.TabIndex = 14
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(429, 44)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(125, 20)
        Me.stbVisitDate.TabIndex = 22
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(306, 44)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(117, 18)
        Me.lblVisitDate.TabIndex = 21
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(429, 23)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(125, 20)
        Me.stbVisitNo.TabIndex = 20
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(306, 23)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(117, 18)
        Me.lblVisitNo.TabIndex = 19
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbBedNo
        '
        Me.stbBedNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBedNo.CapitalizeFirstLetter = False
        Me.stbBedNo.Enabled = False
        Me.stbBedNo.EntryErrorMSG = ""
        Me.stbBedNo.Location = New System.Drawing.Point(881, 108)
        Me.stbBedNo.MaxLength = 60
        Me.stbBedNo.Name = "stbBedNo"
        Me.stbBedNo.RegularExpression = ""
        Me.stbBedNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBedNo.Size = New System.Drawing.Size(74, 20)
        Me.stbBedNo.TabIndex = 49
        '
        'stbRoomNo
        '
        Me.stbRoomNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoomNo.CapitalizeFirstLetter = False
        Me.stbRoomNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRoomNo.Enabled = False
        Me.stbRoomNo.EntryErrorMSG = ""
        Me.stbRoomNo.Location = New System.Drawing.Point(881, 87)
        Me.stbRoomNo.MaxLength = 7
        Me.stbRoomNo.Name = "stbRoomNo"
        Me.stbRoomNo.RegularExpression = ""
        Me.stbRoomNo.Size = New System.Drawing.Size(74, 20)
        Me.stbRoomNo.TabIndex = 47
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Location = New System.Drawing.Point(811, 88)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(64, 18)
        Me.lblRoomNo.TabIndex = 46
        Me.lblRoomNo.Text = "Room No"
        '
        'lblBedNo
        '
        Me.lblBedNo.Location = New System.Drawing.Point(811, 108)
        Me.lblBedNo.Name = "lblBedNo"
        Me.lblBedNo.Size = New System.Drawing.Size(64, 18)
        Me.lblBedNo.TabIndex = 48
        Me.lblBedNo.Text = "Bed No"
        '
        'stbWard
        '
        Me.stbWard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWard.CapitalizeFirstLetter = False
        Me.stbWard.Enabled = False
        Me.stbWard.EntryErrorMSG = ""
        Me.stbWard.Location = New System.Drawing.Point(881, 66)
        Me.stbWard.MaxLength = 60
        Me.stbWard.Name = "stbWard"
        Me.stbWard.RegularExpression = ""
        Me.stbWard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbWard.Size = New System.Drawing.Size(74, 20)
        Me.stbWard.TabIndex = 45
        '
        'lblWard
        '
        Me.lblWard.Location = New System.Drawing.Point(811, 67)
        Me.lblWard.Name = "lblWard"
        Me.lblWard.Size = New System.Drawing.Size(64, 18)
        Me.lblWard.TabIndex = 44
        Me.lblWard.Text = "Ward"
        '
        'btnLoad
        '
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(258, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(42, 24)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'stbLastRoundDateTime
        '
        Me.stbLastRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastRoundDateTime.CapitalizeFirstLetter = False
        Me.stbLastRoundDateTime.Enabled = False
        Me.stbLastRoundDateTime.EntryErrorMSG = ""
        Me.stbLastRoundDateTime.Location = New System.Drawing.Point(429, 86)
        Me.stbLastRoundDateTime.MaxLength = 60
        Me.stbLastRoundDateTime.Name = "stbLastRoundDateTime"
        Me.stbLastRoundDateTime.RegularExpression = ""
        Me.stbLastRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbLastRoundDateTime.Size = New System.Drawing.Size(125, 20)
        Me.stbLastRoundDateTime.TabIndex = 26
        '
        'lblLastRoundDateTime
        '
        Me.lblLastRoundDateTime.Location = New System.Drawing.Point(306, 86)
        Me.lblLastRoundDateTime.Name = "lblLastRoundDateTime"
        Me.lblLastRoundDateTime.Size = New System.Drawing.Size(117, 18)
        Me.lblLastRoundDateTime.TabIndex = 25
        Me.lblLastRoundDateTime.Text = "Last Round Date Time"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(11, 30)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(119, 18)
        Me.lblStaffNo.TabIndex = 4
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'lblReviewDate
        '
        Me.lblReviewDate.Location = New System.Drawing.Point(11, 116)
        Me.lblReviewDate.Name = "lblReviewDate"
        Me.lblReviewDate.Size = New System.Drawing.Size(119, 18)
        Me.lblReviewDate.TabIndex = 12
        Me.lblReviewDate.Text = "Review Date"
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(11, 51)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(119, 18)
        Me.lblRoundNo.TabIndex = 6
        Me.lblRoundNo.Text = "Round No"
        '
        'tbcDrRoles
        '
        Me.tbcDrRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDrRoles.Controls.Add(Me.tpgDischargeNotes)
        Me.tbcDrRoles.Controls.Add(Me.tpgPrescriptions)
        Me.tbcDrRoles.Controls.Add(Me.tpgDiagnosis)
        Me.tbcDrRoles.HotTrack = True
        Me.tbcDrRoles.Location = New System.Drawing.Point(12, 196)
        Me.tbcDrRoles.Name = "tbcDrRoles"
        Me.tbcDrRoles.SelectedIndex = 0
        Me.tbcDrRoles.Size = New System.Drawing.Size(940, 317)
        Me.tbcDrRoles.TabIndex = 50
        '
        'tpgDischargeNotes
        '
        Me.tpgDischargeNotes.Controls.Add(Me.stbKeyFindInvestigation)
        Me.tpgDischargeNotes.Controls.Add(Me.stbKeyRecommendations)
        Me.tpgDischargeNotes.Controls.Add(Me.stbTreatmentOutcome)
        Me.tpgDischargeNotes.Controls.Add(Me.stbTreatmentOnWard)
        Me.tpgDischargeNotes.Controls.Add(Me.stbHistory)
        Me.tpgDischargeNotes.Controls.Add(Me.stbExamination)
        Me.tpgDischargeNotes.Controls.Add(Me.lblSilentFeatures)
        Me.tpgDischargeNotes.Controls.Add(Me.lblHistory)
        Me.tpgDischargeNotes.Controls.Add(Me.lblExamination)
        Me.tpgDischargeNotes.Controls.Add(Me.lblKeyFindInvestigation)
        Me.tpgDischargeNotes.Controls.Add(Me.lblTreatmentOnWard)
        Me.tpgDischargeNotes.Controls.Add(Me.lblTreatmentOutcome)
        Me.tpgDischargeNotes.Controls.Add(Me.stbDischargeNotes)
        Me.tpgDischargeNotes.Controls.Add(Me.lblKeyRecommendations)
        Me.tpgDischargeNotes.Controls.Add(Me.lblOtherNotes)
        Me.tpgDischargeNotes.Location = New System.Drawing.Point(4, 22)
        Me.tpgDischargeNotes.Name = "tpgDischargeNotes"
        Me.tpgDischargeNotes.Size = New System.Drawing.Size(932, 291)
        Me.tpgDischargeNotes.TabIndex = 9
        Me.tpgDischargeNotes.Tag = "Discharges"
        Me.tpgDischargeNotes.Text = "Discharge Notes"
        Me.tpgDischargeNotes.UseVisualStyleBackColor = True
        '
        'lblSilentFeatures
        '
        Me.lblSilentFeatures.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSilentFeatures.Location = New System.Drawing.Point(8, 5)
        Me.lblSilentFeatures.Name = "lblSilentFeatures"
        Me.lblSilentFeatures.Size = New System.Drawing.Size(262, 18)
        Me.lblSilentFeatures.TabIndex = 0
        Me.lblSilentFeatures.Text = "Silent features at admission"
        '
        'lblHistory
        '
        Me.lblHistory.Location = New System.Drawing.Point(33, 27)
        Me.lblHistory.Name = "lblHistory"
        Me.lblHistory.Size = New System.Drawing.Size(94, 18)
        Me.lblHistory.TabIndex = 60
        Me.lblHistory.Text = "History"
        '
        'lblExamination
        '
        Me.lblExamination.Location = New System.Drawing.Point(33, 113)
        Me.lblExamination.Name = "lblExamination"
        Me.lblExamination.Size = New System.Drawing.Size(94, 18)
        Me.lblExamination.TabIndex = 4
        Me.lblExamination.Text = "Examination"
        '
        'lblKeyFindInvestigation
        '
        Me.lblKeyFindInvestigation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyFindInvestigation.Location = New System.Drawing.Point(8, 198)
        Me.lblKeyFindInvestigation.Name = "lblKeyFindInvestigation"
        Me.lblKeyFindInvestigation.Size = New System.Drawing.Size(262, 18)
        Me.lblKeyFindInvestigation.TabIndex = 60
        Me.lblKeyFindInvestigation.Text = "Key findings at investigation"
        '
        'lblTreatmentOnWard
        '
        Me.lblTreatmentOnWard.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTreatmentOnWard.Location = New System.Drawing.Point(475, 5)
        Me.lblTreatmentOnWard.Name = "lblTreatmentOnWard"
        Me.lblTreatmentOnWard.Size = New System.Drawing.Size(262, 18)
        Me.lblTreatmentOnWard.TabIndex = 1
        Me.lblTreatmentOnWard.Text = "Treatment while on ward"
        '
        'lblTreatmentOutcome
        '
        Me.lblTreatmentOutcome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTreatmentOutcome.Location = New System.Drawing.Point(475, 73)
        Me.lblTreatmentOutcome.Name = "lblTreatmentOutcome"
        Me.lblTreatmentOutcome.Size = New System.Drawing.Size(262, 18)
        Me.lblTreatmentOutcome.TabIndex = 60
        Me.lblTreatmentOutcome.Text = "Out come of treatment"
        '
        'lblKeyRecommendations
        '
        Me.lblKeyRecommendations.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyRecommendations.Location = New System.Drawing.Point(475, 143)
        Me.lblKeyRecommendations.Name = "lblKeyRecommendations"
        Me.lblKeyRecommendations.Size = New System.Drawing.Size(262, 18)
        Me.lblKeyRecommendations.TabIndex = 62
        Me.lblKeyRecommendations.Text = "Key Recommendations"
        '
        'lblOtherNotes
        '
        Me.lblOtherNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOtherNotes.Location = New System.Drawing.Point(475, 213)
        Me.lblOtherNotes.Name = "lblOtherNotes"
        Me.lblOtherNotes.Size = New System.Drawing.Size(262, 18)
        Me.lblOtherNotes.TabIndex = 60
        Me.lblOtherNotes.Text = "Other Notes"
        '
        'tpgPrescriptions
        '
        Me.tpgPrescriptions.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescriptions.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescriptions.Name = "tpgPrescriptions"
        Me.tpgPrescriptions.Size = New System.Drawing.Size(932, 291)
        Me.tpgPrescriptions.TabIndex = 2
        Me.tpgPrescriptions.Tag = "DoctorPrescription"
        Me.tpgPrescriptions.Text = "Prescription"
        Me.tpgPrescriptions.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDosage, Me.colDuration, Me.colDrugQuantity, Me.colDrugFormula, Me.colAvailableStock, Me.colOrderLevel, Me.colPrescriptionUnitMeasure, Me.colDrugUnitPrice, Me.colAmount, Me.colPrescriptionSaved, Me.colExpiryDate, Me.colUnitsInStock, Me.colPrescriptionGroup, Me.colAlternateName, Me.colDrugItemStatus, Me.colDrugPayStatus, Me.colHalted, Me.colHasAlternateDrugs})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsDischarges
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvPrescription.Size = New System.Drawing.Size(932, 291)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 240
        '
        'colDosage
        '
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        Me.colDosage.Width = 50
        '
        'colDuration
        '
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 50
        '
        'colDrugQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugFormula
        '
        Me.colDrugFormula.HeaderText = "Notes"
        Me.colDrugFormula.MaxInputLength = 100
        Me.colDrugFormula.Name = "colDrugFormula"
        Me.colDrugFormula.Width = 70
        '
        'colAvailableStock
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colAvailableStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 90
        '
        'colOrderLevel
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle4
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Visible = False
        Me.colOrderLevel.Width = 70
        '
        'colPrescriptionUnitMeasure
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionUnitMeasure.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPrescriptionUnitMeasure.HeaderText = "Unit Measure"
        Me.colPrescriptionUnitMeasure.Name = "colPrescriptionUnitMeasure"
        Me.colPrescriptionUnitMeasure.ReadOnly = True
        Me.colPrescriptionUnitMeasure.Width = 80
        '
        'colDrugUnitPrice
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 65
        '
        'colAmount
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'colExpiryDate
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 80
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colPrescriptionGroup
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionGroup.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPrescriptionGroup.HeaderText = "Group"
        Me.colPrescriptionGroup.Name = "colPrescriptionGroup"
        Me.colPrescriptionGroup.ReadOnly = True
        Me.colPrescriptionGroup.Width = 80
        '
        'colAlternateName
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colAlternateName.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAlternateName.HeaderText = "Alternate Name"
        Me.colAlternateName.Name = "colAlternateName"
        Me.colAlternateName.ReadOnly = True
        Me.colAlternateName.Width = 90
        '
        'colDrugItemStatus
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugItemStatus.DefaultCellStyle = DataGridViewCellStyle13
        Me.colDrugItemStatus.HeaderText = "Item Status"
        Me.colDrugItemStatus.Name = "colDrugItemStatus"
        Me.colDrugItemStatus.ReadOnly = True
        Me.colDrugItemStatus.Width = 80
        '
        'colDrugPayStatus
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 80
        '
        'colHalted
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.NullValue = False
        Me.colHalted.DefaultCellStyle = DataGridViewCellStyle15
        Me.colHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHalted.HeaderText = "Halted"
        Me.colHalted.Name = "colHalted"
        Me.colHalted.ReadOnly = True
        Me.colHalted.Width = 50
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle16
        Me.colHasAlternateDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHasAlternateDrugs.HeaderText = "Has Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        Me.colHasAlternateDrugs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHasAlternateDrugs.Width = 110
        '
        'cmsDischarges
        '
        Me.cmsDischarges.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDischarges.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsDischargesQuickSearch})
        Me.cmsDischarges.Name = "cmsSearch"
        Me.cmsDischarges.Size = New System.Drawing.Size(144, 26)
        Me.cmsDischarges.Tag = ""
        '
        'cmsDischargesQuickSearch
        '
        Me.cmsDischargesQuickSearch.Image = CType(resources.GetObject("cmsDischargesQuickSearch.Image"), System.Drawing.Image)
        Me.cmsDischargesQuickSearch.Name = "cmsDischargesQuickSearch"
        Me.cmsDischargesQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsDischargesQuickSearch.Text = "Quick Search"
        '
        'tpgDiagnosis
        '
        Me.tpgDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosis.Name = "tpgDiagnosis"
        Me.tpgDiagnosis.Size = New System.Drawing.Size(932, 291)
        Me.tpgDiagnosis.TabIndex = 10
        Me.tpgDiagnosis.Text = "Diagnosis"
        Me.tpgDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToOrderColumns = True
        Me.dgvDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseCode, Me.colICDDiagnosisCode, Me.colDiseaseCategory, Me.colNotes, Me.colDiagnosisSaved})
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvDiagnosis.Size = New System.Drawing.Size(932, 291)
        Me.dgvDiagnosis.TabIndex = 1
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseCode
        '
        Me.colDiseaseCode.DisplayStyleForCurrentCellOnly = True
        Me.colDiseaseCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiseaseCode.HeaderText = "Diagnosis"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDiseaseCode.Width = 300
        '
        'colICDDiagnosisCode
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colICDDiagnosisCode.DefaultCellStyle = DataGridViewCellStyle19
        Me.colICDDiagnosisCode.HeaderText = "Code"
        Me.colICDDiagnosisCode.Name = "colICDDiagnosisCode"
        Me.colICDDiagnosisCode.ReadOnly = True
        Me.colICDDiagnosisCode.Width = 80
        '
        'colDiseaseCategory
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle20
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 200
        '
        'colDiagnosisSaved
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle21.NullValue = False
        Me.colDiagnosisSaved.DefaultCellStyle = DataGridViewCellStyle21
        Me.colDiagnosisSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiagnosisSaved.HeaderText = "Saved"
        Me.colDiagnosisSaved.Name = "colDiagnosisSaved"
        Me.colDiagnosisSaved.ReadOnly = True
        Me.colDiagnosisSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDiagnosisSaved.Width = 50
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(10, 156)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(808, 38)
        Me.pnlBill.TabIndex = 16
        Me.pnlBill.Visible = False
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(299, 8)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(94, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(126, 5)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(164, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(419, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(376, 31)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(3, 7)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(117, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(802, 543)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 58
        Me.btnPrint.Text = "&Print"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(660, 44)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(145, 42)
        Me.stbBillCustomerName.TabIndex = 35
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(560, 57)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(94, 18)
        Me.lblBillCustomerName.TabIndex = 34
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(660, 87)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(145, 44)
        Me.stbInsuranceName.TabIndex = 37
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(560, 93)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(94, 18)
        Me.lblBillInsuranceName.TabIndex = 36
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'chkPrintDischargeReportOnSaving
        '
        Me.chkPrintDischargeReportOnSaving.AccessibleDescription = ""
        Me.chkPrintDischargeReportOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDischargeReportOnSaving.AutoSize = True
        Me.chkPrintDischargeReportOnSaving.Location = New System.Drawing.Point(103, 549)
        Me.chkPrintDischargeReportOnSaving.Name = "chkPrintDischargeReportOnSaving"
        Me.chkPrintDischargeReportOnSaving.Size = New System.Drawing.Size(189, 17)
        Me.chkPrintDischargeReportOnSaving.TabIndex = 52
        Me.chkPrintDischargeReportOnSaving.Text = " Print Discharge Report On Saving"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(703, 543)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(93, 24)
        Me.btnPrintPreview.TabIndex = 55
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'pnlGenerateInvoice
        '
        Me.pnlGenerateInvoice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlGenerateInvoice.Controls.Add(Me.chkGenerateInvoiceOnSaving)
        Me.pnlGenerateInvoice.Location = New System.Drawing.Point(335, 539)
        Me.pnlGenerateInvoice.Name = "pnlGenerateInvoice"
        Me.pnlGenerateInvoice.Size = New System.Drawing.Size(176, 31)
        Me.pnlGenerateInvoice.TabIndex = 53
        '
        'chkGenerateInvoiceOnSaving
        '
        Me.chkGenerateInvoiceOnSaving.AccessibleDescription = ""
        Me.chkGenerateInvoiceOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGenerateInvoiceOnSaving.AutoSize = True
        Me.chkGenerateInvoiceOnSaving.Checked = True
        Me.chkGenerateInvoiceOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGenerateInvoiceOnSaving.Location = New System.Drawing.Point(3, 9)
        Me.chkGenerateInvoiceOnSaving.Name = "chkGenerateInvoiceOnSaving"
        Me.chkGenerateInvoiceOnSaving.Size = New System.Drawing.Size(161, 17)
        Me.chkGenerateInvoiceOnSaving.TabIndex = 0
        Me.chkGenerateInvoiceOnSaving.Text = "Generate Invoice On Saving"
        '
        'btnGenerateInvoice
        '
        Me.btnGenerateInvoice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGenerateInvoice.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateInvoice.Location = New System.Drawing.Point(517, 543)
        Me.btnGenerateInvoice.Name = "btnGenerateInvoice"
        Me.btnGenerateInvoice.Size = New System.Drawing.Size(117, 24)
        Me.btnGenerateInvoice.TabIndex = 54
        Me.btnGenerateInvoice.Tag = "Invoices"
        Me.btnGenerateInvoice.Text = "Generate Invoice"
        Me.btnGenerateInvoice.UseVisualStyleBackColor = True
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(305, 129)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(249, 20)
        Me.chkSmartCardApplicable.TabIndex = 29
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(429, 107)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.ReadOnly = True
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(125, 20)
        Me.stbMemberCardNo.TabIndex = 28
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(306, 107)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(117, 18)
        Me.lblMemberCardNo.TabIndex = 27
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'chkReconciliationRequired
        '
        Me.chkReconciliationRequired.AccessibleDescription = ""
        Me.chkReconciliationRequired.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReconciliationRequired.Enabled = False
        Me.chkReconciliationRequired.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReconciliationRequired.ForeColor = System.Drawing.Color.Red
        Me.chkReconciliationRequired.Location = New System.Drawing.Point(563, 133)
        Me.chkReconciliationRequired.Name = "chkReconciliationRequired"
        Me.chkReconciliationRequired.Size = New System.Drawing.Size(233, 20)
        Me.chkReconciliationRequired.TabIndex = 59
        Me.chkReconciliationRequired.Text = "Reconciliation Required"
        '
        'frmDischarges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(968, 571)
        Me.Controls.Add(Me.chkReconciliationRequired)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.pnlGenerateInvoice)
        Me.Controls.Add(Me.btnGenerateInvoice)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.chkPrintDischargeReportOnSaving)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.tbcDrRoles)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.dtpReviewDate)
        Me.Controls.Add(Me.lblReviewDate)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.stbLastRoundDateTime)
        Me.Controls.Add(Me.lblLastRoundDateTime)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbBedNo)
        Me.Controls.Add(Me.stbRoomNo)
        Me.Controls.Add(Me.lblRoomNo)
        Me.Controls.Add(Me.lblBedNo)
        Me.Controls.Add(Me.stbWard)
        Me.Controls.Add(Me.lblWard)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbServiceName)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblServiceName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.dtpDischargeDateTime)
        Me.Controls.Add(Me.lblDischargeDateTime)
        Me.Controls.Add(Me.cboDischargeStatusID)
        Me.Controls.Add(Me.lblDischargeStatusID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDischarges"
        Me.Text = "Discharges"
        Me.tbcDrRoles.ResumeLayout(False)
        Me.tpgDischargeNotes.ResumeLayout(False)
        Me.tpgDischargeNotes.PerformLayout()
        Me.tpgPrescriptions.ResumeLayout(False)
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDischarges.ResumeLayout(False)
        Me.tpgDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlGenerateInvoice.ResumeLayout(False)
        Me.pnlGenerateInvoice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents dtpDischargeDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDischargeDateTime As System.Windows.Forms.Label
    Friend WithEvents stbDischargeNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboDischargeStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDischargeStatusID As System.Windows.Forms.Label
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbServiceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblServiceName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbBedNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbRoomNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents lblBedNo As System.Windows.Forms.Label
    Friend WithEvents stbWard As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWard As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbLastRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents dtpReviewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReviewDate As System.Windows.Forms.Label
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents tbcDrRoles As System.Windows.Forms.TabControl
    Friend WithEvents tpgDischargeNotes As System.Windows.Forms.TabPage
    Friend WithEvents tpgPrescriptions As System.Windows.Forms.TabPage
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvailableStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHalted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colHasAlternateDrugs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents chkPrintDischargeReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents cmsDischarges As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsDischargesQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlGenerateInvoice As System.Windows.Forms.Panel
    Friend WithEvents chkGenerateInvoiceOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnGenerateInvoice As System.Windows.Forms.Button
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents lblHistory As Label
    Friend WithEvents lblExamination As Label
    Friend WithEvents lblKeyFindInvestigation As Label
    Friend WithEvents lblTreatmentOnWard As Label
    Friend WithEvents lblTreatmentOutcome As Label
    Friend WithEvents lblOtherNotes As Label
    Friend WithEvents stbKeyFindInvestigation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbKeyRecommendations As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTreatmentOutcome As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTreatmentOnWard As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbHistory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbExamination As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSilentFeatures As Label
    Friend WithEvents lblKeyRecommendations As Label
    Friend WithEvents tpgDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colDiseaseCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colICDDiagnosisCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkReconciliationRequired As System.Windows.Forms.CheckBox
End Class