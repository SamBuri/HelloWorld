
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDVisionAssessment : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal admissionNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultadmissionNo = admissionNo
        Me.noCallOnKeyEdit = disableCallOnKeyEdit
    End Sub

    Public Sub New(ByVal admissionNo As String, ByVal eyeTestID As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New(admissionNo, disableCallOnKeyEdit)
        Me.defaultEyeTestID = eyeTestID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDVisionAssessment))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboEyeTestID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityRightID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityRightExtID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityLeftID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityLeftExtID = New System.Windows.Forms.ComboBox()
        Me.cboPreferentialLookingRightID = New System.Windows.Forms.ComboBox()
        Me.cboPreferentialLookingLeftID = New System.Windows.Forms.ComboBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTotalIPDDoctorRounds = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpRoundDateTime = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblEyeTestID = New System.Windows.Forms.Label()
        Me.lblVisualAcuityRightID = New System.Windows.Forms.Label()
        Me.lblVisualAcuityRightExtID = New System.Windows.Forms.Label()
        Me.lblPreferentialLooking = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblleft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalIPDDoctorRounds = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(8, 197)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 25
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(461, 197)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 26
        Me.fbnDelete.Tag = "IPDVisionAssessment"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(8, 223)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 23
        Me.ebnSaveUpdate.Tag = "IPDVisionAssessment"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboEyeTestID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEyeTestID, "EyeTest,EyeTestID")
        Me.cboEyeTestID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEyeTestID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEyeTestID.Location = New System.Drawing.Point(131, 15)
        Me.cboEyeTestID.Name = "cboEyeTestID"
        Me.cboEyeTestID.Size = New System.Drawing.Size(170, 21)
        Me.cboEyeTestID.TabIndex = 1
        '
        'cboVisualAcuityRightID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityRightID, "VisualAcuityRight,VisualAcuityRightID")
        Me.cboVisualAcuityRightID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityRightID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityRightID.Location = New System.Drawing.Point(131, 61)
        Me.cboVisualAcuityRightID.Name = "cboVisualAcuityRightID"
        Me.cboVisualAcuityRightID.Size = New System.Drawing.Size(170, 21)
        Me.cboVisualAcuityRightID.TabIndex = 5
        '
        'cboVisualAcuityRightExtID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityRightExtID, "VisualAcuityRightExt,VisualAcuityRightExtID")
        Me.cboVisualAcuityRightExtID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityRightExtID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityRightExtID.Location = New System.Drawing.Point(131, 84)
        Me.cboVisualAcuityRightExtID.Name = "cboVisualAcuityRightExtID"
        Me.cboVisualAcuityRightExtID.Size = New System.Drawing.Size(170, 21)
        Me.cboVisualAcuityRightExtID.TabIndex = 8
        '
        'cboVisualAcuityLeftID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityLeftID, "VisualAcuityLeft,VisualAcuityLeftID")
        Me.cboVisualAcuityLeftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityLeftID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityLeftID.Location = New System.Drawing.Point(360, 60)
        Me.cboVisualAcuityLeftID.Name = "cboVisualAcuityLeftID"
        Me.cboVisualAcuityLeftID.Size = New System.Drawing.Size(177, 21)
        Me.cboVisualAcuityLeftID.TabIndex = 6
        '
        'cboVisualAcuityLeftExtID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityLeftExtID, "VisualAcuityLeftExt,VisualAcuityLeftExtID")
        Me.cboVisualAcuityLeftExtID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityLeftExtID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityLeftExtID.Location = New System.Drawing.Point(360, 83)
        Me.cboVisualAcuityLeftExtID.Name = "cboVisualAcuityLeftExtID"
        Me.cboVisualAcuityLeftExtID.Size = New System.Drawing.Size(177, 21)
        Me.cboVisualAcuityLeftExtID.TabIndex = 9
        '
        'cboPreferentialLookingRightID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPreferentialLookingRightID, "PreferentialLookingRight,PreferentialLookingRightID")
        Me.cboPreferentialLookingRightID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreferentialLookingRightID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPreferentialLookingRightID.Location = New System.Drawing.Point(131, 107)
        Me.cboPreferentialLookingRightID.Name = "cboPreferentialLookingRightID"
        Me.cboPreferentialLookingRightID.Size = New System.Drawing.Size(170, 21)
        Me.cboPreferentialLookingRightID.TabIndex = 14
        '
        'cboPreferentialLookingLeftID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPreferentialLookingLeftID, "PreferentialLookingLeft,PreferentialLookingLeftID")
        Me.cboPreferentialLookingLeftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreferentialLookingLeftID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPreferentialLookingLeftID.Location = New System.Drawing.Point(360, 106)
        Me.cboPreferentialLookingLeftID.Name = "cboPreferentialLookingLeftID"
        Me.cboPreferentialLookingLeftID.Size = New System.Drawing.Size(177, 21)
        Me.cboPreferentialLookingLeftID.TabIndex = 15
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(131, 131)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(406, 60)
        Me.stbNotes.TabIndex = 22
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAdmissionNo, "AdmissionNo")
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(142, 9)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(158, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitDate, "VisitDate")
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(142, 72)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitDate.TabIndex = 9
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(142, 93)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(158, 20)
        Me.stbFullName.TabIndex = 11
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(142, 114)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(158, 20)
        Me.stbPatientNo.TabIndex = 13
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(142, 51)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitNo.TabIndex = 7
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAdmissionDateTime, "AdmissionDateTime")
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(436, 122)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbAdmissionDateTime.TabIndex = 22
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAdmissionStatus, "AdmissionStatus")
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(436, 100)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(113, 20)
        Me.stbAdmissionStatus.TabIndex = 20
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(142, 136)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(158, 20)
        Me.stbAge.TabIndex = 15
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(436, 143)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(113, 20)
        Me.stbJoinDate.TabIndex = 24
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(142, 158)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(158, 20)
        Me.stbGender.TabIndex = 17
        '
        'stbTotalIPDDoctorRounds
        '
        Me.stbTotalIPDDoctorRounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalIPDDoctorRounds.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTotalIPDDoctorRounds, "TotalIPDDoctorRounds")
        Me.stbTotalIPDDoctorRounds.Enabled = False
        Me.stbTotalIPDDoctorRounds.EntryErrorMSG = ""
        Me.stbTotalIPDDoctorRounds.Location = New System.Drawing.Point(436, 165)
        Me.stbTotalIPDDoctorRounds.MaxLength = 60
        Me.stbTotalIPDDoctorRounds.Name = "stbTotalIPDDoctorRounds"
        Me.stbTotalIPDDoctorRounds.RegularExpression = ""
        Me.stbTotalIPDDoctorRounds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalIPDDoctorRounds.Size = New System.Drawing.Size(113, 20)
        Me.stbTotalIPDDoctorRounds.TabIndex = 26
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(436, 4)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 94)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 77
        Me.spbPhoto.TabStop = False
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRoundNo, "VARoundNo")
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(142, 30)
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(103, 20)
        Me.stbRoundNo.TabIndex = 5
        '
        'dtpRoundDateTime
        '
        Me.dtpRoundDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpRoundDateTime, "IPDVARoundDateTime")
        Me.dtpRoundDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRoundDateTime.Location = New System.Drawing.Point(142, 180)
        Me.dtpRoundDateTime.Name = "dtpRoundDateTime"
        Me.dtpRoundDateTime.ShowCheckBox = True
        Me.dtpRoundDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpRoundDateTime.TabIndex = 79
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(461, 223)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 24
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblEyeTestID
        '
        Me.lblEyeTestID.Location = New System.Drawing.Point(6, 15)
        Me.lblEyeTestID.Name = "lblEyeTestID"
        Me.lblEyeTestID.Size = New System.Drawing.Size(115, 20)
        Me.lblEyeTestID.TabIndex = 0
        Me.lblEyeTestID.Text = "EyeTest"
        '
        'lblVisualAcuityRightID
        '
        Me.lblVisualAcuityRightID.Location = New System.Drawing.Point(6, 63)
        Me.lblVisualAcuityRightID.Name = "lblVisualAcuityRightID"
        Me.lblVisualAcuityRightID.Size = New System.Drawing.Size(115, 20)
        Me.lblVisualAcuityRightID.TabIndex = 4
        Me.lblVisualAcuityRightID.Text = "Visual Acuity"
        '
        'lblVisualAcuityRightExtID
        '
        Me.lblVisualAcuityRightExtID.Location = New System.Drawing.Point(6, 86)
        Me.lblVisualAcuityRightExtID.Name = "lblVisualAcuityRightExtID"
        Me.lblVisualAcuityRightExtID.Size = New System.Drawing.Size(115, 20)
        Me.lblVisualAcuityRightExtID.TabIndex = 7
        Me.lblVisualAcuityRightExtID.Text = "Visual Acuity Ext"
        '
        'lblPreferentialLooking
        '
        Me.lblPreferentialLooking.Location = New System.Drawing.Point(6, 110)
        Me.lblPreferentialLooking.Name = "lblPreferentialLooking"
        Me.lblPreferentialLooking.Size = New System.Drawing.Size(115, 20)
        Me.lblPreferentialLooking.TabIndex = 13
        Me.lblPreferentialLooking.Text = "Preferential Looking"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(6, 131)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(115, 20)
        Me.lblNotes.TabIndex = 21
        Me.lblNotes.Text = "Notes"
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(109, 9)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Round No"
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.AccessibleDescription = " "
        Me.lblAdmissionNo.Location = New System.Drawing.Point(12, 9)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(89, 20)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 74)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 8
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(12, 95)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(124, 20)
        Me.lblFullName.TabIndex = 10
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(12, 116)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 12
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 51)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitNo.TabIndex = 6
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(305, 117)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(125, 20)
        Me.lblAdmissionDateTime.TabIndex = 21
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(305, 95)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(125, 20)
        Me.lblAdmissionStatus.TabIndex = 19
        Me.lblAdmissionStatus.Text = "Status"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(305, 136)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(125, 20)
        Me.lblJoinDate.TabIndex = 23
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(12, 138)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(86, 20)
        Me.lblAge.TabIndex = 14
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(12, 160)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(86, 20)
        Me.lblGenderID.TabIndex = 16
        Me.lblGenderID.Text = "Gender"
        '
        'lblleft
        '
        Me.lblleft.Location = New System.Drawing.Point(360, 36)
        Me.lblleft.Name = "lblleft"
        Me.lblleft.Size = New System.Drawing.Size(177, 20)
        Me.lblleft.TabIndex = 3
        Me.lblleft.Text = "Left"
        Me.lblleft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRight
        '
        Me.lblRight.Location = New System.Drawing.Point(131, 36)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(177, 20)
        Me.lblRight.TabIndex = 2
        Me.lblRight.Text = "Right"
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblleft)
        Me.GroupBox1.Controls.Add(Me.lblRight)
        Me.GroupBox1.Controls.Add(Me.fbnSearch)
        Me.GroupBox1.Controls.Add(Me.fbnDelete)
        Me.GroupBox1.Controls.Add(Me.ebnSaveUpdate)
        Me.GroupBox1.Controls.Add(Me.fbnClose)
        Me.GroupBox1.Controls.Add(Me.cboEyeTestID)
        Me.GroupBox1.Controls.Add(Me.lblEyeTestID)
        Me.GroupBox1.Controls.Add(Me.cboVisualAcuityRightID)
        Me.GroupBox1.Controls.Add(Me.lblVisualAcuityRightID)
        Me.GroupBox1.Controls.Add(Me.cboVisualAcuityRightExtID)
        Me.GroupBox1.Controls.Add(Me.lblVisualAcuityRightExtID)
        Me.GroupBox1.Controls.Add(Me.cboVisualAcuityLeftID)
        Me.GroupBox1.Controls.Add(Me.cboVisualAcuityLeftExtID)
        Me.GroupBox1.Controls.Add(Me.cboPreferentialLookingRightID)
        Me.GroupBox1.Controls.Add(Me.lblPreferentialLooking)
        Me.GroupBox1.Controls.Add(Me.cboPreferentialLookingLeftID)
        Me.GroupBox1.Controls.Add(Me.stbNotes)
        Me.GroupBox1.Controls.Add(Me.lblNotes)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 203)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 262)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'lblTotalIPDDoctorRounds
        '
        Me.lblTotalIPDDoctorRounds.Location = New System.Drawing.Point(305, 156)
        Me.lblTotalIPDDoctorRounds.Name = "lblTotalIPDDoctorRounds"
        Me.lblTotalIPDDoctorRounds.Size = New System.Drawing.Size(125, 20)
        Me.lblTotalIPDDoctorRounds.TabIndex = 25
        Me.lblTotalIPDDoctorRounds.Text = "Total Rounds"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(305, 29)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(125, 20)
        Me.lblPhoto.TabIndex = 18
        Me.lblPhoto.Text = "Photo"
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(109, 32)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(12, 180)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(111, 20)
        Me.lblRoundDateTime.TabIndex = 78
        Me.lblRoundDateTime.Text = "Round Date Time"
        '
        'frmIPDVisionAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(571, 471)
        Me.Controls.Add(Me.dtpRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.btnFindRoundNo)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.stbTotalIPDDoctorRounds)
        Me.Controls.Add(Me.lblTotalIPDDoctorRounds)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbRoundNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmIPDVisionAssessment"
        Me.Text = "IPD Vision Assessment"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboEyeTestID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEyeTestID As System.Windows.Forms.Label
    Friend WithEvents cboVisualAcuityRightID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisualAcuityRightID As System.Windows.Forms.Label
    Friend WithEvents cboVisualAcuityRightExtID As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisualAcuityRightExtID As System.Windows.Forms.Label
    Friend WithEvents cboVisualAcuityLeftID As System.Windows.Forms.ComboBox
    Friend WithEvents cboVisualAcuityLeftExtID As System.Windows.Forms.ComboBox
    Friend WithEvents cboPreferentialLookingRightID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPreferentialLooking As System.Windows.Forms.Label
    Friend WithEvents cboPreferentialLookingLeftID As System.Windows.Forms.ComboBox
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblleft As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents stbTotalIPDDoctorRounds As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalIPDDoctorRounds As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents dtpRoundDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label

End Class