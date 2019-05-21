
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnrollmentInformation : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String, ByVal itemsKeyNo As ItemsKeyNo)
        MyClass.New()
        Me.defaultKeyNo = keyNo
        Me.enrollmentKeyNo = itemsKeyNo
    End Sub

    Public Sub New(ByVal currentEnrollmentInformation As CurrentEnrollmentInformation)
        MyClass.New()
        Me.oCurrentEnrollmentInformation = currentEnrollmentInformation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnrollmentInformation))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboEnrolledID = New System.Windows.Forms.ComboBox()
        Me.cboCoEnrolledID = New System.Windows.Forms.ComboBox()
        Me.cboCoEnrolledStudyCodeID = New System.Windows.Forms.ComboBox()
        Me.stbCCInitials = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbExclusionReason = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpEnrollmentDate = New System.Windows.Forms.DateTimePicker()
        Me.stbPatientReferred = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpReferredDate = New System.Windows.Forms.DateTimePicker()
        Me.cboReferralStudyCodeID = New System.Windows.Forms.ComboBox()
        Me.stbReferalInitials = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSCRNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbUCIID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUCIID = New System.Windows.Forms.Label()
        Me.lblReferralStudyCodeID = New System.Windows.Forms.Label()
        Me.lblEnrolledID = New System.Windows.Forms.Label()
        Me.lblCoEnrolledID = New System.Windows.Forms.Label()
        Me.lblCoEnrolledStudyCodeID = New System.Windows.Forms.Label()
        Me.lblCCInitials = New System.Windows.Forms.Label()
        Me.lblExclusionReason = New System.Windows.Forms.Label()
        Me.lblEnrollmentDate = New System.Windows.Forms.Label()
        Me.lblPatientReferred = New System.Windows.Forms.Label()
        Me.lblReferredDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblReferalInitials = New System.Windows.Forms.Label()
        Me.lblSCRNo = New System.Windows.Forms.Label()
        Me.lblPID = New System.Windows.Forms.Label()
        Me.lblSID = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 322)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 22
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(605, 321)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 23
        Me.fbnDelete.Tag = "EnrollmentInformation"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 349)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 20
        Me.ebnSaveUpdate.Tag = ""
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboEnrolledID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEnrolledID, "Enrolled,EnrolledID")
        Me.cboEnrolledID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEnrolledID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEnrolledID.Location = New System.Drawing.Point(192, 56)
        Me.cboEnrolledID.Name = "cboEnrolledID"
        Me.cboEnrolledID.Size = New System.Drawing.Size(200, 21)
        Me.cboEnrolledID.TabIndex = 5
        '
        'cboCoEnrolledID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoEnrolledID, "CoEnrolled,CoEnrolledID")
        Me.cboCoEnrolledID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoEnrolledID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoEnrolledID.Location = New System.Drawing.Point(192, 80)
        Me.cboCoEnrolledID.Name = "cboCoEnrolledID"
        Me.cboCoEnrolledID.Size = New System.Drawing.Size(200, 21)
        Me.cboCoEnrolledID.TabIndex = 7
        '
        'cboCoEnrolledStudyCodeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoEnrolledStudyCodeID, "CoEnrolledStudyCode,CoEnrolledStudyCodeID")
        Me.cboCoEnrolledStudyCodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoEnrolledStudyCodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoEnrolledStudyCodeID.Location = New System.Drawing.Point(192, 103)
        Me.cboCoEnrolledStudyCodeID.Name = "cboCoEnrolledStudyCodeID"
        Me.cboCoEnrolledStudyCodeID.Size = New System.Drawing.Size(200, 21)
        Me.cboCoEnrolledStudyCodeID.TabIndex = 9
        '
        'stbCCInitials
        '
        Me.stbCCInitials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCCInitials.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCCInitials, "CCInitials")
        Me.stbCCInitials.EntryErrorMSG = ""
        Me.stbCCInitials.Location = New System.Drawing.Point(192, 126)
        Me.stbCCInitials.Name = "stbCCInitials"
        Me.stbCCInitials.RegularExpression = ""
        Me.stbCCInitials.Size = New System.Drawing.Size(200, 20)
        Me.stbCCInitials.TabIndex = 11
        '
        'stbExclusionReason
        '
        Me.stbExclusionReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExclusionReason.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbExclusionReason, "ExclusionReason")
        Me.stbExclusionReason.EntryErrorMSG = ""
        Me.stbExclusionReason.Location = New System.Drawing.Point(192, 148)
        Me.stbExclusionReason.Multiline = True
        Me.stbExclusionReason.Name = "stbExclusionReason"
        Me.stbExclusionReason.RegularExpression = ""
        Me.stbExclusionReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExclusionReason.Size = New System.Drawing.Size(200, 52)
        Me.stbExclusionReason.TabIndex = 13
        '
        'dtpEnrollmentDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEnrollmentDate, "EnrollmentDate")
        Me.dtpEnrollmentDate.Location = New System.Drawing.Point(192, 202)
        Me.dtpEnrollmentDate.Name = "dtpEnrollmentDate"
        Me.dtpEnrollmentDate.ShowCheckBox = True
        Me.dtpEnrollmentDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEnrollmentDate.TabIndex = 15
        '
        'stbPatientReferred
        '
        Me.stbPatientReferred.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientReferred.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientReferred, "PatientReferred")
        Me.stbPatientReferred.EntryErrorMSG = ""
        Me.stbPatientReferred.Location = New System.Drawing.Point(192, 224)
        Me.stbPatientReferred.Multiline = True
        Me.stbPatientReferred.Name = "stbPatientReferred"
        Me.stbPatientReferred.RegularExpression = ""
        Me.stbPatientReferred.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPatientReferred.Size = New System.Drawing.Size(200, 66)
        Me.stbPatientReferred.TabIndex = 17
        '
        'dtpReferredDate
        '
        Me.dtpReferredDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReferredDate, "ReferredDate")
        Me.dtpReferredDate.Location = New System.Drawing.Point(192, 292)
        Me.dtpReferredDate.Name = "dtpReferredDate"
        Me.dtpReferredDate.ShowCheckBox = True
        Me.dtpReferredDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpReferredDate.TabIndex = 19
        '
        'cboReferralStudyCodeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReferralStudyCodeID, "ReferralStudyCode,ReferralStudyCodeID")
        Me.cboReferralStudyCodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReferralStudyCodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReferralStudyCodeID.Location = New System.Drawing.Point(192, 32)
        Me.cboReferralStudyCodeID.Name = "cboReferralStudyCodeID"
        Me.cboReferralStudyCodeID.Size = New System.Drawing.Size(200, 21)
        Me.cboReferralStudyCodeID.TabIndex = 3
        '
        'stbReferalInitials
        '
        Me.stbReferalInitials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferalInitials.CapitalizeFirstLetter = True
        Me.stbReferalInitials.Enabled = False
        Me.stbReferalInitials.EntryErrorMSG = ""
        Me.stbReferalInitials.Location = New System.Drawing.Point(509, 40)
        Me.stbReferalInitials.Name = "stbReferalInitials"
        Me.stbReferalInitials.RegularExpression = ""
        Me.stbReferalInitials.Size = New System.Drawing.Size(170, 20)
        Me.stbReferalInitials.TabIndex = 27
        '
        'stbSCRNo
        '
        Me.stbSCRNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSCRNo.CapitalizeFirstLetter = False
        Me.stbSCRNo.Enabled = False
        Me.stbSCRNo.EntryErrorMSG = ""
        Me.stbSCRNo.Location = New System.Drawing.Point(509, 105)
        Me.stbSCRNo.Name = "stbSCRNo"
        Me.stbSCRNo.RegularExpression = ""
        Me.stbSCRNo.Size = New System.Drawing.Size(170, 20)
        Me.stbSCRNo.TabIndex = 33
        '
        'stbPID
        '
        Me.stbPID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPID.CapitalizeFirstLetter = False
        Me.stbPID.Enabled = False
        Me.stbPID.EntryErrorMSG = ""
        Me.stbPID.Location = New System.Drawing.Point(509, 126)
        Me.stbPID.Name = "stbPID"
        Me.stbPID.RegularExpression = ""
        Me.stbPID.Size = New System.Drawing.Size(170, 20)
        Me.stbPID.TabIndex = 35
        '
        'stbSID
        '
        Me.stbSID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSID.CapitalizeFirstLetter = False
        Me.stbSID.Enabled = False
        Me.stbSID.EntryErrorMSG = ""
        Me.stbSID.Location = New System.Drawing.Point(509, 148)
        Me.stbSID.Name = "stbSID"
        Me.stbSID.RegularExpression = ""
        Me.stbSID.Size = New System.Drawing.Size(170, 20)
        Me.stbSID.TabIndex = 37
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(509, 62)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(170, 20)
        Me.stbGender.TabIndex = 29
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(509, 83)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(170, 20)
        Me.stbAge.TabIndex = 31
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(605, 348)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 21
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbUCIID
        '
        Me.stbUCIID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUCIID.CapitalizeFirstLetter = False
        Me.stbUCIID.EntryErrorMSG = ""
        Me.stbUCIID.Location = New System.Drawing.Point(192, 10)
        Me.stbUCIID.Name = "stbUCIID"
        Me.stbUCIID.RegularExpression = ""
        Me.stbUCIID.Size = New System.Drawing.Size(145, 20)
        Me.stbUCIID.TabIndex = 1
        '
        'lblUCIID
        '
        Me.lblUCIID.Location = New System.Drawing.Point(12, 12)
        Me.lblUCIID.Name = "lblUCIID"
        Me.lblUCIID.Size = New System.Drawing.Size(159, 20)
        Me.lblUCIID.TabIndex = 0
        Me.lblUCIID.Text = "Research No"
        '
        'lblReferralStudyCodeID
        '
        Me.lblReferralStudyCodeID.Location = New System.Drawing.Point(12, 35)
        Me.lblReferralStudyCodeID.Name = "lblReferralStudyCodeID"
        Me.lblReferralStudyCodeID.Size = New System.Drawing.Size(159, 20)
        Me.lblReferralStudyCodeID.TabIndex = 2
        Me.lblReferralStudyCodeID.Text = "Referral Study Code"
        '
        'lblEnrolledID
        '
        Me.lblEnrolledID.Location = New System.Drawing.Point(12, 58)
        Me.lblEnrolledID.Name = "lblEnrolledID"
        Me.lblEnrolledID.Size = New System.Drawing.Size(159, 20)
        Me.lblEnrolledID.TabIndex = 4
        Me.lblEnrolledID.Text = "Enrolled"
        '
        'lblCoEnrolledID
        '
        Me.lblCoEnrolledID.Location = New System.Drawing.Point(12, 82)
        Me.lblCoEnrolledID.Name = "lblCoEnrolledID"
        Me.lblCoEnrolledID.Size = New System.Drawing.Size(159, 20)
        Me.lblCoEnrolledID.TabIndex = 6
        Me.lblCoEnrolledID.Text = "Co Enrolled"
        '
        'lblCoEnrolledStudyCodeID
        '
        Me.lblCoEnrolledStudyCodeID.Location = New System.Drawing.Point(12, 105)
        Me.lblCoEnrolledStudyCodeID.Name = "lblCoEnrolledStudyCodeID"
        Me.lblCoEnrolledStudyCodeID.Size = New System.Drawing.Size(159, 20)
        Me.lblCoEnrolledStudyCodeID.TabIndex = 8
        Me.lblCoEnrolledStudyCodeID.Text = "CoEnrolled Study Code"
        '
        'lblCCInitials
        '
        Me.lblCCInitials.Location = New System.Drawing.Point(12, 128)
        Me.lblCCInitials.Name = "lblCCInitials"
        Me.lblCCInitials.Size = New System.Drawing.Size(159, 20)
        Me.lblCCInitials.TabIndex = 10
        Me.lblCCInitials.Text = "CC Initials"
        '
        'lblExclusionReason
        '
        Me.lblExclusionReason.Location = New System.Drawing.Point(12, 149)
        Me.lblExclusionReason.Name = "lblExclusionReason"
        Me.lblExclusionReason.Size = New System.Drawing.Size(159, 20)
        Me.lblExclusionReason.TabIndex = 12
        Me.lblExclusionReason.Text = "Exclusion Reason"
        '
        'lblEnrollmentDate
        '
        Me.lblEnrollmentDate.Location = New System.Drawing.Point(12, 204)
        Me.lblEnrollmentDate.Name = "lblEnrollmentDate"
        Me.lblEnrollmentDate.Size = New System.Drawing.Size(159, 20)
        Me.lblEnrollmentDate.TabIndex = 14
        Me.lblEnrollmentDate.Text = "Date"
        '
        'lblPatientReferred
        '
        Me.lblPatientReferred.Location = New System.Drawing.Point(12, 224)
        Me.lblPatientReferred.Name = "lblPatientReferred"
        Me.lblPatientReferred.Size = New System.Drawing.Size(159, 66)
        Me.lblPatientReferred.TabIndex = 16
        Me.lblPatientReferred.Text = "Where was the patient referred if not enrolled?"
        '
        'lblReferredDate
        '
        Me.lblReferredDate.Location = New System.Drawing.Point(12, 294)
        Me.lblReferredDate.Name = "lblReferredDate"
        Me.lblReferredDate.Size = New System.Drawing.Size(159, 20)
        Me.lblReferredDate.TabIndex = 18
        Me.lblReferredDate.Text = "Referred Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(400, 85)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(99, 20)
        Me.lblAge.TabIndex = 30
        Me.lblAge.Text = "Age"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = True
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(509, 18)
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(170, 20)
        Me.stbFullName.TabIndex = 25
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(400, 18)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(99, 20)
        Me.lblFullName.TabIndex = 24
        Me.lblFullName.Text = "Full Name"
        '
        'lblReferalInitials
        '
        Me.lblReferalInitials.Location = New System.Drawing.Point(400, 40)
        Me.lblReferalInitials.Name = "lblReferalInitials"
        Me.lblReferalInitials.Size = New System.Drawing.Size(99, 20)
        Me.lblReferalInitials.TabIndex = 26
        Me.lblReferalInitials.Text = "Referal Initials"
        '
        'lblSCRNo
        '
        Me.lblSCRNo.Location = New System.Drawing.Point(400, 106)
        Me.lblSCRNo.Name = "lblSCRNo"
        Me.lblSCRNo.Size = New System.Drawing.Size(99, 20)
        Me.lblSCRNo.TabIndex = 32
        Me.lblSCRNo.Text = "SCR No"
        '
        'lblPID
        '
        Me.lblPID.Location = New System.Drawing.Point(400, 127)
        Me.lblPID.Name = "lblPID"
        Me.lblPID.Size = New System.Drawing.Size(99, 20)
        Me.lblPID.TabIndex = 34
        Me.lblPID.Text = "PID"
        '
        'lblSID
        '
        Me.lblSID.Location = New System.Drawing.Point(400, 149)
        Me.lblSID.Name = "lblSID"
        Me.lblSID.Size = New System.Drawing.Size(99, 20)
        Me.lblSID.TabIndex = 36
        Me.lblSID.Text = "SID"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(400, 62)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(99, 20)
        Me.lblGenderID.TabIndex = 28
        Me.lblGenderID.Text = "Gender"
        '
        'btnLoad
        '
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(343, 6)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(49, 24)
        Me.btnLoad.TabIndex = 38
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'frmEnrollmentInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(689, 381)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboReferralStudyCodeID)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbSCRNo)
        Me.Controls.Add(Me.lblSCRNo)
        Me.Controls.Add(Me.stbPID)
        Me.Controls.Add(Me.lblPID)
        Me.Controls.Add(Me.stbSID)
        Me.Controls.Add(Me.lblSID)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbReferalInitials)
        Me.Controls.Add(Me.lblReferalInitials)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbUCIID)
        Me.Controls.Add(Me.lblUCIID)
        Me.Controls.Add(Me.lblReferralStudyCodeID)
        Me.Controls.Add(Me.cboEnrolledID)
        Me.Controls.Add(Me.lblEnrolledID)
        Me.Controls.Add(Me.cboCoEnrolledID)
        Me.Controls.Add(Me.lblCoEnrolledID)
        Me.Controls.Add(Me.cboCoEnrolledStudyCodeID)
        Me.Controls.Add(Me.lblCoEnrolledStudyCodeID)
        Me.Controls.Add(Me.stbCCInitials)
        Me.Controls.Add(Me.lblCCInitials)
        Me.Controls.Add(Me.stbExclusionReason)
        Me.Controls.Add(Me.lblExclusionReason)
        Me.Controls.Add(Me.dtpEnrollmentDate)
        Me.Controls.Add(Me.lblEnrollmentDate)
        Me.Controls.Add(Me.stbPatientReferred)
        Me.Controls.Add(Me.lblPatientReferred)
        Me.Controls.Add(Me.dtpReferredDate)
        Me.Controls.Add(Me.lblReferredDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmEnrollmentInformation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Enrollment Information"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbUCIID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUCIID As System.Windows.Forms.Label
    Friend WithEvents lblReferralStudyCodeID As System.Windows.Forms.Label
    Friend WithEvents cboEnrolledID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEnrolledID As System.Windows.Forms.Label
    Friend WithEvents cboCoEnrolledID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoEnrolledID As System.Windows.Forms.Label
    Friend WithEvents cboCoEnrolledStudyCodeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoEnrolledStudyCodeID As System.Windows.Forms.Label
    Friend WithEvents stbCCInitials As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCCInitials As System.Windows.Forms.Label
    Friend WithEvents stbExclusionReason As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExclusionReason As System.Windows.Forms.Label
    Friend WithEvents dtpEnrollmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEnrollmentDate As System.Windows.Forms.Label
    Friend WithEvents stbPatientReferred As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientReferred As System.Windows.Forms.Label
    Friend WithEvents dtpReferredDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReferredDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbReferalInitials As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferalInitials As System.Windows.Forms.Label
    Friend WithEvents stbSCRNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSCRNo As System.Windows.Forms.Label
    Friend WithEvents stbPID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPID As System.Windows.Forms.Label
    Friend WithEvents stbSID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSID As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboReferralStudyCodeID As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button

End Class