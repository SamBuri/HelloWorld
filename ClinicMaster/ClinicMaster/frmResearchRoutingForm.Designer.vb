
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResearchRoutingForm : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal uCIID As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultuCIID = uCIID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResearchRoutingForm))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbOtherName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferalInitials = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboGenderID = New System.Windows.Forms.ComboBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.cboVillageCode = New System.Windows.Forms.ComboBox()
        Me.dtpReferralDate = New System.Windows.Forms.DateTimePicker()
        Me.stbReferralStudyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferredBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferralInitials = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboEligibleForScreeningID = New System.Windows.Forms.ComboBox()
        Me.stbExclusionReason = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientReferedTo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpReferredDate = New System.Windows.Forms.DateTimePicker()
        Me.stbSCRNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbPatientScreenedBy = New System.Windows.Forms.CheckedListBox()
        Me.cboReferralStudyCodeID = New System.Windows.Forms.ComboBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboHealthUnitCode = New System.Windows.Forms.ComboBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbUCIID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUCIID = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblOtherName = New System.Windows.Forms.Label()
        Me.lblReferalInitials = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblBirthDate = New System.Windows.Forms.Label()
        Me.lblVillageCode = New System.Windows.Forms.Label()
        Me.lblReferralDate = New System.Windows.Forms.Label()
        Me.lblReferralCode = New System.Windows.Forms.Label()
        Me.lblReferralStudyName = New System.Windows.Forms.Label()
        Me.lblDiagnosis = New System.Windows.Forms.Label()
        Me.lblReferralClinic = New System.Windows.Forms.Label()
        Me.lblReferredBy = New System.Windows.Forms.Label()
        Me.lblPatientScreenedBy = New System.Windows.Forms.Label()
        Me.lblReferralInitials = New System.Windows.Forms.Label()
        Me.lblEligibleForScreeningID = New System.Windows.Forms.Label()
        Me.lblExclusionReason = New System.Windows.Forms.Label()
        Me.lblPatientReferedTo = New System.Windows.Forms.Label()
        Me.lblReferredDate = New System.Windows.Forms.Label()
        Me.lblSCRNo = New System.Windows.Forms.Label()
        Me.lblPID = New System.Windows.Forms.Label()
        Me.lblSID = New System.Windows.Forms.Label()
        Me.lblCountyCode = New System.Windows.Forms.Label()
        Me.cboCountyCode = New System.Windows.Forms.ComboBox()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.lblParishCode = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.cboParishCode = New System.Windows.Forms.ComboBox()
        Me.lblSubCountyCode = New System.Windows.Forms.Label()
        Me.cboSubCountyCode = New System.Windows.Forms.ComboBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.chkUseExistingPatient = New System.Windows.Forms.CheckBox()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.pnlPatients = New System.Windows.Forms.Panel()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.pnlPatients.SuspendLayout
        Me.SuspendLayout
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 483)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 60
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(599, 482)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 61
        Me.fbnDelete.Tag = "ResearchRoutingForm"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 510)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 58
        Me.ebnSaveUpdate.Tag = "ResearchRoutingForm"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(145, 3)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(170, 20)
        Me.stbFirstName.TabIndex = 3
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(145, 24)
        Me.stbLastName.MaxLength = 20
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(170, 20)
        Me.stbLastName.TabIndex = 5
        '
        'stbOtherName
        '
        Me.stbOtherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbOtherName, "OtherName")
        Me.stbOtherName.EntryErrorMSG = ""
        Me.stbOtherName.Location = New System.Drawing.Point(145, 45)
        Me.stbOtherName.MaxLength = 20
        Me.stbOtherName.Name = "stbOtherName"
        Me.stbOtherName.RegularExpression = ""
        Me.stbOtherName.Size = New System.Drawing.Size(170, 20)
        Me.stbOtherName.TabIndex = 7
        '
        'stbReferalInitials
        '
        Me.stbReferalInitials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferalInitials.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferalInitials, "ReferalInitials")
        Me.stbReferalInitials.EntryErrorMSG = ""
        Me.stbReferalInitials.Location = New System.Drawing.Point(157, 256)
        Me.stbReferalInitials.MaxLength = 3
        Me.stbReferalInitials.Name = "stbReferalInitials"
        Me.stbReferalInitials.RegularExpression = ""
        Me.stbReferalInitials.Size = New System.Drawing.Size(170, 20)
        Me.stbReferalInitials.TabIndex = 9
        '
        'cboGenderID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGenderID, "Gender,GenderID")
        Me.cboGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGenderID.Location = New System.Drawing.Point(145, 69)
        Me.cboGenderID.Name = "cboGenderID"
        Me.cboGenderID.Size = New System.Drawing.Size(170, 21)
        Me.cboGenderID.TabIndex = 11
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Location = New System.Drawing.Point(148, 96)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpBirthDate.TabIndex = 13
        '
        'cboVillageCode
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVillageCode, "VillageCode")
        Me.cboVillageCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVillageCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVillageCode.Location = New System.Drawing.Point(154, 374)
        Me.cboVillageCode.Name = "cboVillageCode"
        Me.cboVillageCode.Size = New System.Drawing.Size(170, 21)
        Me.cboVillageCode.TabIndex = 25
        '
        'dtpReferralDate
        '
        Me.dtpReferralDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReferralDate, "ReferralDate")
        Me.dtpReferralDate.Location = New System.Drawing.Point(154, 397)
        Me.dtpReferralDate.Name = "dtpReferralDate"
        Me.dtpReferralDate.ShowCheckBox = True
        Me.dtpReferralDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpReferralDate.TabIndex = 27
        '
        'stbReferralStudyName
        '
        Me.stbReferralStudyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferralStudyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferralStudyName, "ReferralStudyName")
        Me.stbReferralStudyName.EntryErrorMSG = ""
        Me.stbReferralStudyName.Location = New System.Drawing.Point(154, 441)
        Me.stbReferralStudyName.MaxLength = 100
        Me.stbReferralStudyName.Name = "stbReferralStudyName"
        Me.stbReferralStudyName.RegularExpression = ""
        Me.stbReferralStudyName.Size = New System.Drawing.Size(170, 20)
        Me.stbReferralStudyName.TabIndex = 31
        '
        'stbDiagnosis
        '
        Me.stbDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiagnosis.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiagnosis, "Diagnosis")
        Me.stbDiagnosis.EntryErrorMSG = ""
        Me.stbDiagnosis.Location = New System.Drawing.Point(487, 5)
        Me.stbDiagnosis.MaxLength = 1000
        Me.stbDiagnosis.Multiline = True
        Me.stbDiagnosis.Name = "stbDiagnosis"
        Me.stbDiagnosis.RegularExpression = ""
        Me.stbDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDiagnosis.Size = New System.Drawing.Size(193, 62)
        Me.stbDiagnosis.TabIndex = 33
        '
        'stbReferredBy
        '
        Me.stbReferredBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferredBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferredBy, "ReferredBy")
        Me.stbReferredBy.EntryErrorMSG = ""
        Me.stbReferredBy.Location = New System.Drawing.Point(489, 93)
        Me.stbReferredBy.MaxLength = 20
        Me.stbReferredBy.Name = "stbReferredBy"
        Me.stbReferredBy.RegularExpression = ""
        Me.stbReferredBy.Size = New System.Drawing.Size(193, 20)
        Me.stbReferredBy.TabIndex = 39
        '
        'stbReferralInitials
        '
        Me.stbReferralInitials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferralInitials.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferralInitials, "ReferralInitials")
        Me.stbReferralInitials.EntryErrorMSG = ""
        Me.stbReferralInitials.Location = New System.Drawing.Point(489, 208)
        Me.stbReferralInitials.MaxLength = 3
        Me.stbReferralInitials.Name = "stbReferralInitials"
        Me.stbReferralInitials.RegularExpression = ""
        Me.stbReferralInitials.Size = New System.Drawing.Size(193, 20)
        Me.stbReferralInitials.TabIndex = 43
        '
        'cboEligibleForScreeningID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEligibleForScreeningID, "EligibleForScreening,EligibleForScreeningID")
        Me.cboEligibleForScreeningID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEligibleForScreeningID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEligibleForScreeningID.Location = New System.Drawing.Point(489, 230)
        Me.cboEligibleForScreeningID.Name = "cboEligibleForScreeningID"
        Me.cboEligibleForScreeningID.Size = New System.Drawing.Size(193, 21)
        Me.cboEligibleForScreeningID.TabIndex = 45
        '
        'stbExclusionReason
        '
        Me.stbExclusionReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExclusionReason.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbExclusionReason, "ExclusionReason")
        Me.stbExclusionReason.Enabled = False
        Me.stbExclusionReason.EntryErrorMSG = ""
        Me.stbExclusionReason.Location = New System.Drawing.Point(489, 254)
        Me.stbExclusionReason.MaxLength = 1000
        Me.stbExclusionReason.Multiline = True
        Me.stbExclusionReason.Name = "stbExclusionReason"
        Me.stbExclusionReason.RegularExpression = ""
        Me.stbExclusionReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExclusionReason.Size = New System.Drawing.Size(193, 67)
        Me.stbExclusionReason.TabIndex = 47
        '
        'stbPatientReferedTo
        '
        Me.stbPatientReferedTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientReferedTo.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientReferedTo, "PatientReferedTo")
        Me.stbPatientReferedTo.Enabled = False
        Me.stbPatientReferedTo.EntryErrorMSG = ""
        Me.stbPatientReferedTo.Location = New System.Drawing.Point(489, 322)
        Me.stbPatientReferedTo.MaxLength = 200
        Me.stbPatientReferedTo.Name = "stbPatientReferedTo"
        Me.stbPatientReferedTo.RegularExpression = ""
        Me.stbPatientReferedTo.Size = New System.Drawing.Size(193, 20)
        Me.stbPatientReferedTo.TabIndex = 49
        '
        'dtpReferredDate
        '
        Me.dtpReferredDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReferredDate, "ReferredDate")
        Me.dtpReferredDate.Enabled = False
        Me.dtpReferredDate.Location = New System.Drawing.Point(489, 343)
        Me.dtpReferredDate.Name = "dtpReferredDate"
        Me.dtpReferredDate.ShowCheckBox = True
        Me.dtpReferredDate.Size = New System.Drawing.Size(193, 20)
        Me.dtpReferredDate.TabIndex = 51
        '
        'stbSCRNo
        '
        Me.stbSCRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSCRNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSCRNo, "SCRNo")
        Me.stbSCRNo.EntryErrorMSG = ""
        Me.stbSCRNo.Location = New System.Drawing.Point(489, 364)
        Me.stbSCRNo.MaxLength = 20
        Me.stbSCRNo.Name = "stbSCRNo"
        Me.stbSCRNo.RegularExpression = ""
        Me.stbSCRNo.Size = New System.Drawing.Size(193, 20)
        Me.stbSCRNo.TabIndex = 53
        '
        'stbPID
        '
        Me.stbPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPID, "PID")
        Me.stbPID.EntryErrorMSG = ""
        Me.stbPID.Location = New System.Drawing.Point(489, 385)
        Me.stbPID.MaxLength = 20
        Me.stbPID.Name = "stbPID"
        Me.stbPID.RegularExpression = ""
        Me.stbPID.Size = New System.Drawing.Size(193, 20)
        Me.stbPID.TabIndex = 55
        '
        'stbSID
        '
        Me.stbSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSID, "SID")
        Me.stbSID.EntryErrorMSG = ""
        Me.stbSID.Location = New System.Drawing.Point(489, 406)
        Me.stbSID.MaxLength = 20
        Me.stbSID.Name = "stbSID"
        Me.stbSID.RegularExpression = ""
        Me.stbSID.Size = New System.Drawing.Size(193, 20)
        Me.stbSID.TabIndex = 57
        '
        'clbPatientScreenedBy
        '
        Me.clbPatientScreenedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbPatientScreenedBy, "PatientScreenedBy")
        Me.clbPatientScreenedBy.FormattingEnabled = True
        Me.clbPatientScreenedBy.Location = New System.Drawing.Point(489, 116)
        Me.clbPatientScreenedBy.Name = "clbPatientScreenedBy"
        Me.clbPatientScreenedBy.Size = New System.Drawing.Size(193, 90)
        Me.clbPatientScreenedBy.TabIndex = 41
        '
        'cboReferralStudyCodeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReferralStudyCodeID, "ReferralStudyCodeID")
        Me.cboReferralStudyCodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferralStudyCodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReferralStudyCodeID.Location = New System.Drawing.Point(154, 418)
        Me.cboReferralStudyCodeID.Name = "cboReferralStudyCodeID"
        Me.cboReferralStudyCodeID.Size = New System.Drawing.Size(170, 21)
        Me.cboReferralStudyCodeID.TabIndex = 29
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(148, 117)
        Me.nbxAge.MaxLength = 3
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(67, 20)
        Me.nbxAge.TabIndex = 15
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'cboHealthUnitCode
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHealthUnitCode, "HealthUnitCode,HealthUnitCode")
        Me.cboHealthUnitCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHealthUnitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnitCode.Location = New System.Drawing.Point(489, 70)
        Me.cboHealthUnitCode.Name = "cboHealthUnitCode"
        Me.cboHealthUnitCode.Size = New System.Drawing.Size(193, 21)
        Me.cboHealthUnitCode.TabIndex = 37
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(155, 32)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(169, 20)
        Me.stbPatientNo.TabIndex = 65
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(143, 139)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(172, 20)
        Me.stbPhone.TabIndex = 17
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(599, 509)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 59
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbUCIID
        '
        Me.stbUCIID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUCIID.CapitalizeFirstLetter = False
        Me.stbUCIID.EntryErrorMSG = ""
        Me.stbUCIID.Location = New System.Drawing.Point(154, 54)
        Me.stbUCIID.MaxLength = 20
        Me.stbUCIID.Name = "stbUCIID"
        Me.stbUCIID.RegularExpression = ""
        Me.stbUCIID.Size = New System.Drawing.Size(170, 20)
        Me.stbUCIID.TabIndex = 1
        '
        'lblUCIID
        '
        Me.lblUCIID.Location = New System.Drawing.Point(16, 54)
        Me.lblUCIID.Name = "lblUCIID"
        Me.lblUCIID.Size = New System.Drawing.Size(132, 20)
        Me.lblUCIID.TabIndex = 0
        Me.lblUCIID.Text = "Research No"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(7, 3)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(132, 20)
        Me.lblFirstName.TabIndex = 2
        Me.lblFirstName.Text = "First Name"
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(7, 24)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(132, 20)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name"
        '
        'lblOtherName
        '
        Me.lblOtherName.Location = New System.Drawing.Point(7, 45)
        Me.lblOtherName.Name = "lblOtherName"
        Me.lblOtherName.Size = New System.Drawing.Size(132, 20)
        Me.lblOtherName.TabIndex = 6
        Me.lblOtherName.Text = "Other Name"
        '
        'lblReferalInitials
        '
        Me.lblReferalInitials.Location = New System.Drawing.Point(19, 256)
        Me.lblReferalInitials.Name = "lblReferalInitials"
        Me.lblReferalInitials.Size = New System.Drawing.Size(132, 20)
        Me.lblReferalInitials.TabIndex = 8
        Me.lblReferalInitials.Text = "Referal Initials"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(7, 69)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(132, 20)
        Me.lblGenderID.TabIndex = 10
        Me.lblGenderID.Text = "Sex"
        '
        'lblBirthDate
        '
        Me.lblBirthDate.Location = New System.Drawing.Point(10, 96)
        Me.lblBirthDate.Name = "lblBirthDate"
        Me.lblBirthDate.Size = New System.Drawing.Size(132, 20)
        Me.lblBirthDate.TabIndex = 12
        Me.lblBirthDate.Text = "BirthDate"
        '
        'lblVillageCode
        '
        Me.lblVillageCode.Location = New System.Drawing.Point(16, 374)
        Me.lblVillageCode.Name = "lblVillageCode"
        Me.lblVillageCode.Size = New System.Drawing.Size(132, 20)
        Me.lblVillageCode.TabIndex = 24
        Me.lblVillageCode.Text = "Village"
        '
        'lblReferralDate
        '
        Me.lblReferralDate.Location = New System.Drawing.Point(16, 397)
        Me.lblReferralDate.Name = "lblReferralDate"
        Me.lblReferralDate.Size = New System.Drawing.Size(132, 20)
        Me.lblReferralDate.TabIndex = 26
        Me.lblReferralDate.Text = "Referral Date"
        '
        'lblReferralCode
        '
        Me.lblReferralCode.Location = New System.Drawing.Point(16, 419)
        Me.lblReferralCode.Name = "lblReferralCode"
        Me.lblReferralCode.Size = New System.Drawing.Size(132, 20)
        Me.lblReferralCode.TabIndex = 28
        Me.lblReferralCode.Text = "Referral Code"
        '
        'lblReferralStudyName
        '
        Me.lblReferralStudyName.Location = New System.Drawing.Point(16, 441)
        Me.lblReferralStudyName.Name = "lblReferralStudyName"
        Me.lblReferralStudyName.Size = New System.Drawing.Size(132, 20)
        Me.lblReferralStudyName.TabIndex = 30
        Me.lblReferralStudyName.Text = "Referral Study Name"
        '
        'lblDiagnosis
        '
        Me.lblDiagnosis.Location = New System.Drawing.Point(349, 9)
        Me.lblDiagnosis.Name = "lblDiagnosis"
        Me.lblDiagnosis.Size = New System.Drawing.Size(132, 20)
        Me.lblDiagnosis.TabIndex = 32
        Me.lblDiagnosis.Text = "Diagnosis"
        '
        'lblReferralClinic
        '
        Me.lblReferralClinic.Location = New System.Drawing.Point(349, 68)
        Me.lblReferralClinic.Name = "lblReferralClinic"
        Me.lblReferralClinic.Size = New System.Drawing.Size(132, 20)
        Me.lblReferralClinic.TabIndex = 36
        Me.lblReferralClinic.Text = "Referral  Clinic"
        '
        'lblReferredBy
        '
        Me.lblReferredBy.Location = New System.Drawing.Point(349, 94)
        Me.lblReferredBy.Name = "lblReferredBy"
        Me.lblReferredBy.Size = New System.Drawing.Size(132, 20)
        Me.lblReferredBy.TabIndex = 38
        Me.lblReferredBy.Text = "Referred By"
        '
        'lblPatientScreenedBy
        '
        Me.lblPatientScreenedBy.Location = New System.Drawing.Point(349, 117)
        Me.lblPatientScreenedBy.Name = "lblPatientScreenedBy"
        Me.lblPatientScreenedBy.Size = New System.Drawing.Size(132, 20)
        Me.lblPatientScreenedBy.TabIndex = 40
        Me.lblPatientScreenedBy.Text = "Patient Screened By"
        '
        'lblReferralInitials
        '
        Me.lblReferralInitials.Location = New System.Drawing.Point(349, 209)
        Me.lblReferralInitials.Name = "lblReferralInitials"
        Me.lblReferralInitials.Size = New System.Drawing.Size(132, 20)
        Me.lblReferralInitials.TabIndex = 42
        Me.lblReferralInitials.Text = "Screened By Initials"
        '
        'lblEligibleForScreeningID
        '
        Me.lblEligibleForScreeningID.Location = New System.Drawing.Point(349, 231)
        Me.lblEligibleForScreeningID.Name = "lblEligibleForScreeningID"
        Me.lblEligibleForScreeningID.Size = New System.Drawing.Size(132, 20)
        Me.lblEligibleForScreeningID.TabIndex = 44
        Me.lblEligibleForScreeningID.Text = "Eligible For Screening"
        '
        'lblExclusionReason
        '
        Me.lblExclusionReason.Location = New System.Drawing.Point(349, 255)
        Me.lblExclusionReason.Name = "lblExclusionReason"
        Me.lblExclusionReason.Size = New System.Drawing.Size(132, 20)
        Me.lblExclusionReason.TabIndex = 46
        Me.lblExclusionReason.Text = "Exclusion Reason"
        '
        'lblPatientReferedTo
        '
        Me.lblPatientReferedTo.Location = New System.Drawing.Point(349, 323)
        Me.lblPatientReferedTo.Name = "lblPatientReferedTo"
        Me.lblPatientReferedTo.Size = New System.Drawing.Size(132, 20)
        Me.lblPatientReferedTo.TabIndex = 48
        Me.lblPatientReferedTo.Text = "Patient Refered To"
        '
        'lblReferredDate
        '
        Me.lblReferredDate.Location = New System.Drawing.Point(349, 344)
        Me.lblReferredDate.Name = "lblReferredDate"
        Me.lblReferredDate.Size = New System.Drawing.Size(132, 20)
        Me.lblReferredDate.TabIndex = 50
        Me.lblReferredDate.Text = "Referred Date"
        '
        'lblSCRNo
        '
        Me.lblSCRNo.Location = New System.Drawing.Point(349, 365)
        Me.lblSCRNo.Name = "lblSCRNo"
        Me.lblSCRNo.Size = New System.Drawing.Size(132, 20)
        Me.lblSCRNo.TabIndex = 52
        Me.lblSCRNo.Text = "SCR No"
        '
        'lblPID
        '
        Me.lblPID.Location = New System.Drawing.Point(349, 386)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(132, 20)
        Me.lblPID.TabIndex = 54
        Me.lblPID.Text = "PID"
        '
        'lblSID
        '
        Me.lblSID.Location = New System.Drawing.Point(349, 407)
        Me.lblSID.Name = "lblSID"
        Me.lblSID.Size = New System.Drawing.Size(132, 20)
        Me.lblSID.TabIndex = 56
        Me.lblSID.Text = "SID"
        '
        'lblCountyCode
        '
        Me.lblCountyCode.Location = New System.Drawing.Point(16, 309)
        Me.lblCountyCode.Name = "lblCountyCode"
        Me.lblCountyCode.Size = New System.Drawing.Size(132, 20)
        Me.lblCountyCode.TabIndex = 18
        Me.lblCountyCode.Text = "County"
        '
        'cboCountyCode
        '
        Me.cboCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCountyCode.Location = New System.Drawing.Point(154, 305)
        Me.cboCountyCode.Name = "cboCountyCode"
        Me.cboCountyCode.Size = New System.Drawing.Size(170, 21)
        Me.cboCountyCode.TabIndex = 19
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(154, 282)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(170, 21)
        Me.cboDistrictsID.TabIndex = 17
        '
        'lblParishCode
        '
        Me.lblParishCode.Location = New System.Drawing.Point(16, 351)
        Me.lblParishCode.Name = "lblParishCode"
        Me.lblParishCode.Size = New System.Drawing.Size(132, 20)
        Me.lblParishCode.TabIndex = 22
        Me.lblParishCode.Text = "Parish"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Location = New System.Drawing.Point(16, 283)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(132, 20)
        Me.lblDistrictsID.TabIndex = 16
        Me.lblDistrictsID.Text = "District"
        '
        'cboParishCode
        '
        Me.cboParishCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboParishCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboParishCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParishCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboParishCode.Location = New System.Drawing.Point(154, 351)
        Me.cboParishCode.Name = "cboParishCode"
        Me.cboParishCode.Size = New System.Drawing.Size(170, 21)
        Me.cboParishCode.TabIndex = 23
        '
        'lblSubCountyCode
        '
        Me.lblSubCountyCode.Location = New System.Drawing.Point(16, 329)
        Me.lblSubCountyCode.Name = "lblSubCountyCode"
        Me.lblSubCountyCode.Size = New System.Drawing.Size(132, 20)
        Me.lblSubCountyCode.TabIndex = 20
        Me.lblSubCountyCode.Text = "Sub County"
        '
        'cboSubCountyCode
        '
        Me.cboSubCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSubCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSubCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubCountyCode.Location = New System.Drawing.Point(154, 328)
        Me.cboSubCountyCode.Name = "cboSubCountyCode"
        Me.cboSubCountyCode.Size = New System.Drawing.Size(170, 21)
        Me.cboSubCountyCode.TabIndex = 21
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(10, 119)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(132, 20)
        Me.lblAge.TabIndex = 14
        Me.lblAge.Text = "Age"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(266, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 63
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'chkUseExistingPatient
        '
        Me.chkUseExistingPatient.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseExistingPatient.Enabled = False
        Me.chkUseExistingPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseExistingPatient.Location = New System.Drawing.Point(11, 6)
        Me.chkUseExistingPatient.Name = "chkUseExistingPatient"
        Me.chkUseExistingPatient.Size = New System.Drawing.Size(159, 20)
        Me.chkUseExistingPatient.TabIndex = 62
        Me.chkUseExistingPatient.Text = "Use Existing Patient"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(16, 32)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(140, 20)
        Me.lblPatientNo.TabIndex = 64
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'pnlPatients
        '
        Me.pnlPatients.Controls.Add(Me.stbPhone)
        Me.pnlPatients.Controls.Add(Me.lblPhoneNo)
        Me.pnlPatients.Controls.Add(Me.stbFirstName)
        Me.pnlPatients.Controls.Add(Me.lblLastName)
        Me.pnlPatients.Controls.Add(Me.stbLastName)
        Me.pnlPatients.Controls.Add(Me.lblFirstName)
        Me.pnlPatients.Controls.Add(Me.stbOtherName)
        Me.pnlPatients.Controls.Add(Me.nbxAge)
        Me.pnlPatients.Controls.Add(Me.lblOtherName)
        Me.pnlPatients.Controls.Add(Me.lblAge)
        Me.pnlPatients.Controls.Add(Me.cboGenderID)
        Me.pnlPatients.Controls.Add(Me.lblGenderID)
        Me.pnlPatients.Controls.Add(Me.dtpBirthDate)
        Me.pnlPatients.Controls.Add(Me.lblBirthDate)
        Me.pnlPatients.Location = New System.Drawing.Point(12, 77)
        Me.pnlPatients.Name = "pnlPatients"
        Me.pnlPatients.Size = New System.Drawing.Size(318, 168)
        Me.pnlPatients.TabIndex = 66
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(10, 139)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(126, 20)
        Me.lblPhoneNo.TabIndex = 16
        Me.lblPhoneNo.Text = "Phone Number"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(513, 435)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(13, 21)
        Me.chkFingerprintCaptured.TabIndex = 68
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(352, 432)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(155, 24)
        Me.btnEnrollFingerprint.TabIndex = 69
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(532, 432)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 67
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'frmResearchRoutingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(683, 545)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.btnEnrollFingerprint)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.pnlPatients)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.chkUseExistingPatient)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.cboReferralStudyCodeID)
        Me.Controls.Add(Me.clbPatientScreenedBy)
        Me.Controls.Add(Me.lblCountyCode)
        Me.Controls.Add(Me.cboCountyCode)
        Me.Controls.Add(Me.cboDistrictsID)
        Me.Controls.Add(Me.lblParishCode)
        Me.Controls.Add(Me.lblDistrictsID)
        Me.Controls.Add(Me.cboParishCode)
        Me.Controls.Add(Me.lblSubCountyCode)
        Me.Controls.Add(Me.cboSubCountyCode)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbUCIID)
        Me.Controls.Add(Me.lblUCIID)
        Me.Controls.Add(Me.stbReferalInitials)
        Me.Controls.Add(Me.lblReferalInitials)
        Me.Controls.Add(Me.cboVillageCode)
        Me.Controls.Add(Me.lblVillageCode)
        Me.Controls.Add(Me.dtpReferralDate)
        Me.Controls.Add(Me.lblReferralDate)
        Me.Controls.Add(Me.lblReferralCode)
        Me.Controls.Add(Me.stbReferralStudyName)
        Me.Controls.Add(Me.lblReferralStudyName)
        Me.Controls.Add(Me.stbDiagnosis)
        Me.Controls.Add(Me.lblDiagnosis)
        Me.Controls.Add(Me.cboHealthUnitCode)
        Me.Controls.Add(Me.lblReferralClinic)
        Me.Controls.Add(Me.stbReferredBy)
        Me.Controls.Add(Me.lblReferredBy)
        Me.Controls.Add(Me.lblPatientScreenedBy)
        Me.Controls.Add(Me.stbReferralInitials)
        Me.Controls.Add(Me.lblReferralInitials)
        Me.Controls.Add(Me.cboEligibleForScreeningID)
        Me.Controls.Add(Me.lblEligibleForScreeningID)
        Me.Controls.Add(Me.stbExclusionReason)
        Me.Controls.Add(Me.lblExclusionReason)
        Me.Controls.Add(Me.stbPatientReferedTo)
        Me.Controls.Add(Me.lblPatientReferedTo)
        Me.Controls.Add(Me.dtpReferredDate)
        Me.Controls.Add(Me.lblReferredDate)
        Me.Controls.Add(Me.stbSCRNo)
        Me.Controls.Add(Me.lblSCRNo)
        Me.Controls.Add(Me.stbPID)
        Me.Controls.Add(Me.lblPID)
        Me.Controls.Add(Me.stbSID)
        Me.Controls.Add(Me.lblSID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmResearchRoutingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Deaths"
        Me.Text = "Referred Patient Tracking and Routing"
        Me.pnlPatients.ResumeLayout(false)
        Me.pnlPatients.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbUCIID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUCIID As System.Windows.Forms.Label
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents stbOtherName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOtherName As System.Windows.Forms.Label
    Friend WithEvents stbReferalInitials As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferalInitials As System.Windows.Forms.Label
    Friend WithEvents cboGenderID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBirthDate As System.Windows.Forms.Label
    Friend WithEvents cboVillageCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblVillageCode As System.Windows.Forms.Label
    Friend WithEvents dtpReferralDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReferralDate As System.Windows.Forms.Label
    Friend WithEvents lblReferralCode As System.Windows.Forms.Label
    Friend WithEvents stbReferralStudyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferralStudyName As System.Windows.Forms.Label
    Friend WithEvents stbDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiagnosis As System.Windows.Forms.Label
    Friend WithEvents cboHealthUnitCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblReferralClinic As System.Windows.Forms.Label
    Friend WithEvents stbReferredBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferredBy As System.Windows.Forms.Label
    Friend WithEvents lblPatientScreenedBy As System.Windows.Forms.Label
    Friend WithEvents stbReferralInitials As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferralInitials As System.Windows.Forms.Label
    Friend WithEvents cboEligibleForScreeningID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEligibleForScreeningID As System.Windows.Forms.Label
    Friend WithEvents stbExclusionReason As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExclusionReason As System.Windows.Forms.Label
    Friend WithEvents stbPatientReferedTo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientReferedTo As System.Windows.Forms.Label
    Friend WithEvents dtpReferredDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReferredDate As System.Windows.Forms.Label
    Friend WithEvents stbSCRNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSCRNo As System.Windows.Forms.Label
    Friend WithEvents stbPID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents stbSID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSID As System.Windows.Forms.Label
    Friend WithEvents lblCountyCode As System.Windows.Forms.Label
    Friend WithEvents cboCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblParishCode As System.Windows.Forms.Label
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents cboParishCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubCountyCode As System.Windows.Forms.Label
    Friend WithEvents cboSubCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents clbPatientScreenedBy As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboReferralStudyCodeID As System.Windows.Forms.ComboBox
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents chkUseExistingPatient As System.Windows.Forms.CheckBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents pnlPatients As System.Windows.Forms.Panel
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button

End Class