
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchemeMembers : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal patients As SyncSoft.SQLDb.Patients)
        MyClass.New()
        oPatients = patients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchemeMembers))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSurname = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboGenderID = New System.Windows.Forms.ComboBox()
        Me.dtpJoinDate = New System.Windows.Forms.DateTimePicker()
        Me.cboMemberTypeID = New System.Windows.Forms.ComboBox()
        Me.dtpPolicyStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpPolicyEndDate = New System.Windows.Forms.DateTimePicker()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.fcbStatusID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.stbMainMemberNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCompanyNo = New System.Windows.Forms.ComboBox()
        Me.cboInsuranceNo = New System.Windows.Forms.ComboBox()
        Me.stbSchemeEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSchemeStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbPhoneWork = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhoneMobile = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhoneHome = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRelationship = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblMemberTypeID = New System.Windows.Forms.Label()
        Me.lblMainMemberNo = New System.Windows.Forms.Label()
        Me.lblPolicyStartDate = New System.Windows.Forms.Label()
        Me.lblPolicyEndDate = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.btnClearPhoto = New System.Windows.Forms.Button()
        Me.btnLoadPhoto = New System.Windows.Forms.Button()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.pnlStatusID = New System.Windows.Forms.Panel()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.cboPolicyNo = New System.Windows.Forms.ComboBox()
        Me.lblPolicyNo = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblCompanyNo = New System.Windows.Forms.Label()
        Me.lblSchemeEndDate = New System.Windows.Forms.Label()
        Me.lblSchemeStartDate = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblPhoneWork = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhoneMobile = New System.Windows.Forms.Label()
        Me.lblPhoneHome = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblRelationship = New System.Windows.Forms.Label()
        Me.cboMedicalCardNo = New System.Windows.Forms.ComboBox()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStatusID.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(14, 395)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 62
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(577, 395)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 64
        Me.fbnDelete.Tag = "SchemeMembers"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(14, 422)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 63
        Me.ebnSaveUpdate.Tag = "SchemeMembers"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferenceNo, "ReferenceNo")
        Me.stbReferenceNo.EntryErrorMSG = ""
        Me.stbReferenceNo.Location = New System.Drawing.Point(125, 177)
        Me.stbReferenceNo.MaxLength = 20
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        Me.stbReferenceNo.Size = New System.Drawing.Size(170, 20)
        Me.stbReferenceNo.TabIndex = 15
        '
        'stbSurname
        '
        Me.stbSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSurname.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSurname, "Surname")
        Me.stbSurname.EntryErrorMSG = ""
        Me.stbSurname.Location = New System.Drawing.Point(125, 198)
        Me.stbSurname.MaxLength = 20
        Me.stbSurname.Name = "stbSurname"
        Me.stbSurname.RegularExpression = ""
        Me.stbSurname.Size = New System.Drawing.Size(170, 20)
        Me.stbSurname.TabIndex = 17
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(125, 219)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(170, 20)
        Me.stbFirstName.TabIndex = 19
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        Me.stbMiddleName.Location = New System.Drawing.Point(125, 240)
        Me.stbMiddleName.MaxLength = 20
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        Me.stbMiddleName.Size = New System.Drawing.Size(170, 20)
        Me.stbMiddleName.TabIndex = 21
        '
        'cboGenderID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGenderID, "Gender,GenderID")
        Me.cboGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGenderID.Location = New System.Drawing.Point(125, 306)
        Me.cboGenderID.Name = "cboGenderID"
        Me.cboGenderID.Size = New System.Drawing.Size(170, 21)
        Me.cboGenderID.TabIndex = 27
        '
        'dtpJoinDate
        '
        Me.dtpJoinDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpJoinDate, "JoinDate")
        Me.dtpJoinDate.Location = New System.Drawing.Point(481, 161)
        Me.dtpJoinDate.Name = "dtpJoinDate"
        Me.dtpJoinDate.ShowCheckBox = True
        Me.dtpJoinDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpJoinDate.TabIndex = 44
        '
        'cboMemberTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMemberTypeID, "MemberType,MemberTypeID")
        Me.cboMemberTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMemberTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMemberTypeID.Location = New System.Drawing.Point(125, 4)
        Me.cboMemberTypeID.Name = "cboMemberTypeID"
        Me.cboMemberTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboMemberTypeID.TabIndex = 1
        '
        'dtpPolicyStartDate
        '
        Me.dtpPolicyStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpPolicyStartDate, "PolicyStartDate")
        Me.dtpPolicyStartDate.Location = New System.Drawing.Point(481, 202)
        Me.dtpPolicyStartDate.Name = "dtpPolicyStartDate"
        Me.dtpPolicyStartDate.ShowCheckBox = True
        Me.dtpPolicyStartDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpPolicyStartDate.TabIndex = 48
        '
        'dtpPolicyEndDate
        '
        Me.dtpPolicyEndDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpPolicyEndDate, "PolicyEndDate")
        Me.dtpPolicyEndDate.Location = New System.Drawing.Point(481, 225)
        Me.dtpPolicyEndDate.Name = "dtpPolicyEndDate"
        Me.dtpPolicyEndDate.ShowCheckBox = True
        Me.dtpPolicyEndDate.Size = New System.Drawing.Size(168, 20)
        Me.dtpPolicyEndDate.TabIndex = 50
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(481, 6)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(100, 100)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 47
        Me.spbPhoto.TabStop = False
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(125, 283)
        Me.nbxAge.MaxLength = 3
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(80, 20)
        Me.nbxAge.TabIndex = 25
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Location = New System.Drawing.Point(125, 261)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpBirthDate.TabIndex = 23
        '
        'fcbStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbStatusID, "MemberStatus,MemberStatusID")
        Me.fcbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbStatusID.FormattingEnabled = True
        Me.fcbStatusID.Location = New System.Drawing.Point(176, 4)
        Me.fcbStatusID.Name = "fcbStatusID"
        Me.fcbStatusID.ReadOnly = True
        Me.fcbStatusID.Size = New System.Drawing.Size(168, 21)
        Me.fcbStatusID.TabIndex = 1
        '
        'stbMainMemberNo
        '
        Me.stbMainMemberNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberNo, "MainMemberNo")
        Me.stbMainMemberNo.EntryErrorMSG = ""
        Me.stbMainMemberNo.Location = New System.Drawing.Point(125, 27)
        Me.stbMainMemberNo.MaxLength = 20
        Me.stbMainMemberNo.Name = "stbMainMemberNo"
        Me.stbMainMemberNo.RegularExpression = ""
        Me.stbMainMemberNo.Size = New System.Drawing.Size(170, 20)
        Me.stbMainMemberNo.TabIndex = 3
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCompanyName, "CompanyName")
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(125, 94)
        Me.stbCompanyName.MaxLength = 60
        Me.stbCompanyName.Multiline = True
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.ReadOnly = True
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCompanyName.Size = New System.Drawing.Size(170, 35)
        Me.stbCompanyName.TabIndex = 9
        '
        'cboCompanyNo
        '
        Me.cboCompanyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCompanyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompanyNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboCompanyNo, "CompanyNo")
        Me.cboCompanyNo.DropDownWidth = 256
        Me.cboCompanyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCompanyNo.FormattingEnabled = True
        Me.cboCompanyNo.ItemHeight = 13
        Me.cboCompanyNo.Location = New System.Drawing.Point(125, 70)
        Me.cboCompanyNo.Name = "cboCompanyNo"
        Me.cboCompanyNo.Size = New System.Drawing.Size(170, 21)
        Me.cboCompanyNo.TabIndex = 7
        '
        'cboInsuranceNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboInsuranceNo, "InsuranceNo")
        Me.cboInsuranceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInsuranceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInsuranceNo.Location = New System.Drawing.Point(125, 131)
        Me.cboInsuranceNo.Name = "cboInsuranceNo"
        Me.cboInsuranceNo.Size = New System.Drawing.Size(170, 21)
        Me.cboInsuranceNo.TabIndex = 11
        '
        'stbSchemeEndDate
        '
        Me.stbSchemeEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSchemeEndDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSchemeEndDate, "SchemeEndDate")
        Me.stbSchemeEndDate.Enabled = False
        Me.stbSchemeEndDate.EntryErrorMSG = ""
        Me.stbSchemeEndDate.Location = New System.Drawing.Point(481, 299)
        Me.stbSchemeEndDate.MaxLength = 20
        Me.stbSchemeEndDate.Name = "stbSchemeEndDate"
        Me.stbSchemeEndDate.RegularExpression = ""
        Me.stbSchemeEndDate.Size = New System.Drawing.Size(168, 20)
        Me.stbSchemeEndDate.TabIndex = 55
        '
        'stbSchemeStartDate
        '
        Me.stbSchemeStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSchemeStartDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSchemeStartDate, "SchemeStartDate")
        Me.stbSchemeStartDate.Enabled = False
        Me.stbSchemeStartDate.EntryErrorMSG = ""
        Me.stbSchemeStartDate.Location = New System.Drawing.Point(481, 278)
        Me.stbSchemeStartDate.MaxLength = 60
        Me.stbSchemeStartDate.Name = "stbSchemeStartDate"
        Me.stbSchemeStartDate.RegularExpression = ""
        Me.stbSchemeStartDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSchemeStartDate.Size = New System.Drawing.Size(168, 20)
        Me.stbSchemeStartDate.TabIndex = 53
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCoPayType, "CoPayType")
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(481, 320)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(168, 20)
        Me.stbCoPayType.TabIndex = 57
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(481, 341)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(168, 20)
        Me.nbxCoPayPercent.TabIndex = 59
        Me.nbxCoPayPercent.Value = ""
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(481, 362)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(168, 20)
        Me.nbxCoPayValue.TabIndex = 61
        Me.nbxCoPayValue.Value = ""
        '
        'stbPhoneWork
        '
        Me.stbPhoneWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneWork.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhoneWork, "PhoneWork")
        Me.stbPhoneWork.EntryErrorMSG = ""
        Me.stbPhoneWork.Location = New System.Drawing.Point(125, 329)
        Me.stbPhoneWork.MaxLength = 30
        Me.stbPhoneWork.Name = "stbPhoneWork"
        Me.stbPhoneWork.RegularExpression = ""
        Me.stbPhoneWork.Size = New System.Drawing.Size(170, 20)
        Me.stbPhoneWork.TabIndex = 29
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(481, 107)
        Me.stbAddress.MaxLength = 100
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(168, 32)
        Me.stbAddress.TabIndex = 40
        '
        'stbPhoneMobile
        '
        Me.stbPhoneMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneMobile.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhoneMobile, "PhoneMobile")
        Me.stbPhoneMobile.EntryErrorMSG = ""
        Me.stbPhoneMobile.Location = New System.Drawing.Point(125, 350)
        Me.stbPhoneMobile.MaxLength = 30
        Me.stbPhoneMobile.Name = "stbPhoneMobile"
        Me.stbPhoneMobile.RegularExpression = ""
        Me.stbPhoneMobile.Size = New System.Drawing.Size(170, 20)
        Me.stbPhoneMobile.TabIndex = 31
        '
        'stbPhoneHome
        '
        Me.stbPhoneHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneHome.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhoneHome, "PhoneHome")
        Me.stbPhoneHome.EntryErrorMSG = ""
        Me.stbPhoneHome.Location = New System.Drawing.Point(125, 371)
        Me.stbPhoneHome.MaxLength = 30
        Me.stbPhoneHome.Name = "stbPhoneHome"
        Me.stbPhoneHome.RegularExpression = ""
        Me.stbPhoneHome.Size = New System.Drawing.Size(170, 20)
        Me.stbPhoneHome.TabIndex = 33
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmail, "Email")
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbEmail.Location = New System.Drawing.Point(481, 140)
        Me.stbEmail.MaxLength = 40
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4" & _
    "}|[0-9]{1,3})(\]?)$"
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbEmail.Size = New System.Drawing.Size(168, 20)
        Me.stbEmail.TabIndex = 42
        '
        'stbRelationship
        '
        Me.stbRelationship.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRelationship.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbRelationship, "Relationship")
        Me.stbRelationship.EntryErrorMSG = ""
        Me.stbRelationship.Location = New System.Drawing.Point(481, 181)
        Me.stbRelationship.MaxLength = 41
        Me.stbRelationship.Name = "stbRelationship"
        Me.stbRelationship.RegularExpression = ""
        Me.stbRelationship.Size = New System.Drawing.Size(168, 20)
        Me.stbRelationship.TabIndex = 46
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(577, 422)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 65
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(11, 48)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(108, 20)
        Me.lblMedicalCardNo.TabIndex = 4
        Me.lblMedicalCardNo.Text = "Medical Card No"
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Location = New System.Drawing.Point(11, 177)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(108, 20)
        Me.lblReferenceNo.TabIndex = 14
        Me.lblReferenceNo.Text = "Reference No"
        '
        'lblSurname
        '
        Me.lblSurname.Location = New System.Drawing.Point(11, 198)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(108, 20)
        Me.lblSurname.TabIndex = 16
        Me.lblSurname.Text = "Surname"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(11, 219)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(108, 20)
        Me.lblFirstName.TabIndex = 18
        Me.lblFirstName.Text = "First Name"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.Location = New System.Drawing.Point(11, 240)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(108, 20)
        Me.lblMiddleName.TabIndex = 20
        Me.lblMiddleName.Text = "Middle Name"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(11, 306)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(108, 20)
        Me.lblGenderID.TabIndex = 26
        Me.lblGenderID.Text = "Gender"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(314, 161)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(160, 20)
        Me.lblJoinDate.TabIndex = 43
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblMemberTypeID
        '
        Me.lblMemberTypeID.Location = New System.Drawing.Point(11, 4)
        Me.lblMemberTypeID.Name = "lblMemberTypeID"
        Me.lblMemberTypeID.Size = New System.Drawing.Size(108, 20)
        Me.lblMemberTypeID.TabIndex = 0
        Me.lblMemberTypeID.Text = "Member Type"
        '
        'lblMainMemberNo
        '
        Me.lblMainMemberNo.Location = New System.Drawing.Point(11, 27)
        Me.lblMainMemberNo.Name = "lblMainMemberNo"
        Me.lblMainMemberNo.Size = New System.Drawing.Size(108, 20)
        Me.lblMainMemberNo.TabIndex = 2
        Me.lblMainMemberNo.Text = "Main Member No"
        '
        'lblPolicyStartDate
        '
        Me.lblPolicyStartDate.Location = New System.Drawing.Point(314, 202)
        Me.lblPolicyStartDate.Name = "lblPolicyStartDate"
        Me.lblPolicyStartDate.Size = New System.Drawing.Size(160, 20)
        Me.lblPolicyStartDate.TabIndex = 47
        Me.lblPolicyStartDate.Text = "Policy Start Date"
        '
        'lblPolicyEndDate
        '
        Me.lblPolicyEndDate.Location = New System.Drawing.Point(314, 225)
        Me.lblPolicyEndDate.Name = "lblPolicyEndDate"
        Me.lblPolicyEndDate.Size = New System.Drawing.Size(160, 20)
        Me.lblPolicyEndDate.TabIndex = 49
        Me.lblPolicyEndDate.Text = "Policy End Date"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(319, 55)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(155, 21)
        Me.chkFingerprintCaptured.TabIndex = 36
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(319, 80)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(155, 23)
        Me.btnEnrollFingerprint.TabIndex = 38
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'btnClearPhoto
        '
        Me.btnClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPhoto.Location = New System.Drawing.Point(591, 80)
        Me.btnClearPhoto.Name = "btnClearPhoto"
        Me.btnClearPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnClearPhoto.TabIndex = 37
        Me.btnClearPhoto.Text = "Clear"
        Me.btnClearPhoto.UseVisualStyleBackColor = True
        '
        'btnLoadPhoto
        '
        Me.btnLoadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPhoto.Location = New System.Drawing.Point(591, 9)
        Me.btnLoadPhoto.Name = "btnLoadPhoto"
        Me.btnLoadPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnLoadPhoto.TabIndex = 35
        Me.btnLoadPhoto.Text = "Load..."
        Me.btnLoadPhoto.UseVisualStyleBackColor = True
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(314, 19)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(160, 20)
        Me.lblPhoto.TabIndex = 34
        Me.lblPhoto.Text = "Photo"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(11, 283)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 24
        Me.lblAge.Text = "Age"
        '
        'lblDoB
        '
        Me.lblDoB.Location = New System.Drawing.Point(11, 261)
        Me.lblDoB.Name = "lblDoB"
        Me.lblDoB.Size = New System.Drawing.Size(108, 20)
        Me.lblDoB.TabIndex = 22
        Me.lblDoB.Text = "Date of Birth"
        '
        'pnlStatusID
        '
        Me.pnlStatusID.Controls.Add(Me.fcbStatusID)
        Me.pnlStatusID.Controls.Add(Me.lblStatusID)
        Me.pnlStatusID.Location = New System.Drawing.Point(305, 247)
        Me.pnlStatusID.Name = "pnlStatusID"
        Me.pnlStatusID.Size = New System.Drawing.Size(357, 29)
        Me.pnlStatusID.TabIndex = 51
        '
        'lblStatusID
        '
        Me.lblStatusID.Location = New System.Drawing.Point(9, 4)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(157, 21)
        Me.lblStatusID.TabIndex = 0
        Me.lblStatusID.Text = "Member Status"
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsuranceNo.Location = New System.Drawing.Point(11, 131)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(108, 20)
        Me.lblInsuranceNo.TabIndex = 10
        Me.lblInsuranceNo.Text = "Insurance Name"
        '
        'cboPolicyNo
        '
        Me.cboPolicyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPolicyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPolicyNo.Location = New System.Drawing.Point(125, 154)
        Me.cboPolicyNo.Name = "cboPolicyNo"
        Me.cboPolicyNo.Size = New System.Drawing.Size(170, 21)
        Me.cboPolicyNo.TabIndex = 13
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolicyNo.Location = New System.Drawing.Point(11, 154)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(108, 20)
        Me.lblPolicyNo.TabIndex = 12
        Me.lblPolicyNo.Text = "Policy Name"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Location = New System.Drawing.Point(11, 103)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(108, 20)
        Me.lblCompanyName.TabIndex = 8
        Me.lblCompanyName.Text = "Company Name"
        '
        'lblCompanyNo
        '
        Me.lblCompanyNo.Location = New System.Drawing.Point(11, 73)
        Me.lblCompanyNo.Name = "lblCompanyNo"
        Me.lblCompanyNo.Size = New System.Drawing.Size(108, 20)
        Me.lblCompanyNo.TabIndex = 6
        Me.lblCompanyNo.Text = "Company Number"
        '
        'lblSchemeEndDate
        '
        Me.lblSchemeEndDate.Location = New System.Drawing.Point(314, 301)
        Me.lblSchemeEndDate.Name = "lblSchemeEndDate"
        Me.lblSchemeEndDate.Size = New System.Drawing.Size(160, 20)
        Me.lblSchemeEndDate.TabIndex = 54
        Me.lblSchemeEndDate.Text = "Scheme End Date"
        '
        'lblSchemeStartDate
        '
        Me.lblSchemeStartDate.Location = New System.Drawing.Point(314, 280)
        Me.lblSchemeStartDate.Name = "lblSchemeStartDate"
        Me.lblSchemeStartDate.Size = New System.Drawing.Size(160, 20)
        Me.lblSchemeStartDate.TabIndex = 52
        Me.lblSchemeStartDate.Text = "Scheme Start Date"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.Location = New System.Drawing.Point(314, 322)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(160, 20)
        Me.lblCoPayType.TabIndex = 56
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.Location = New System.Drawing.Point(314, 342)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(160, 20)
        Me.lblCoPayPercent.TabIndex = 58
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.Location = New System.Drawing.Point(314, 363)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(160, 20)
        Me.lblCoPayValue.TabIndex = 60
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblPhoneWork
        '
        Me.lblPhoneWork.Location = New System.Drawing.Point(11, 331)
        Me.lblPhoneWork.Name = "lblPhoneWork"
        Me.lblPhoneWork.Size = New System.Drawing.Size(108, 20)
        Me.lblPhoneWork.TabIndex = 28
        Me.lblPhoneWork.Text = "Phone Work"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(314, 115)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(160, 20)
        Me.lblAddress.TabIndex = 39
        Me.lblAddress.Text = "Physical Address"
        '
        'lblPhoneMobile
        '
        Me.lblPhoneMobile.Location = New System.Drawing.Point(11, 352)
        Me.lblPhoneMobile.Name = "lblPhoneMobile"
        Me.lblPhoneMobile.Size = New System.Drawing.Size(108, 20)
        Me.lblPhoneMobile.TabIndex = 30
        Me.lblPhoneMobile.Text = "Phone Mobile"
        '
        'lblPhoneHome
        '
        Me.lblPhoneHome.Location = New System.Drawing.Point(11, 373)
        Me.lblPhoneHome.Name = "lblPhoneHome"
        Me.lblPhoneHome.Size = New System.Drawing.Size(108, 20)
        Me.lblPhoneHome.TabIndex = 32
        Me.lblPhoneHome.Text = "Phone Home"
        '
        'lblEmail
        '
        Me.lblEmail.Location = New System.Drawing.Point(314, 141)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(160, 20)
        Me.lblEmail.TabIndex = 41
        Me.lblEmail.Text = "E-Mail"
        '
        'lblRelationship
        '
        Me.lblRelationship.Location = New System.Drawing.Point(314, 181)
        Me.lblRelationship.Name = "lblRelationship"
        Me.lblRelationship.Size = New System.Drawing.Size(160, 20)
        Me.lblRelationship.TabIndex = 45
        Me.lblRelationship.Text = "Relationship"
        '
        'cboMedicalCardNo
        '
        Me.cboMedicalCardNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedicalCardNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedicalCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboMedicalCardNo.DropDownWidth = 256
        Me.cboMedicalCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMedicalCardNo.FormattingEnabled = True
        Me.cboMedicalCardNo.ItemHeight = 13
        Me.cboMedicalCardNo.Location = New System.Drawing.Point(125, 48)
        Me.cboMedicalCardNo.Name = "cboMedicalCardNo"
        Me.cboMedicalCardNo.Size = New System.Drawing.Size(170, 21)
        Me.cboMedicalCardNo.TabIndex = 5
        '
        'frmSchemeMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(670, 459)
        Me.Controls.Add(Me.cboMedicalCardNo)
        Me.Controls.Add(Me.stbRelationship)
        Me.Controls.Add(Me.lblRelationship)
        Me.Controls.Add(Me.stbEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.stbPhoneHome)
        Me.Controls.Add(Me.lblPhoneHome)
        Me.Controls.Add(Me.stbPhoneMobile)
        Me.Controls.Add(Me.lblPhoneMobile)
        Me.Controls.Add(Me.stbPhoneWork)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.lblPhoneWork)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbSchemeEndDate)
        Me.Controls.Add(Me.lblSchemeEndDate)
        Me.Controls.Add(Me.stbSchemeStartDate)
        Me.Controls.Add(Me.lblSchemeStartDate)
        Me.Controls.Add(Me.cboInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.cboPolicyNo)
        Me.Controls.Add(Me.lblPolicyNo)
        Me.Controls.Add(Me.stbCompanyName)
        Me.Controls.Add(Me.cboCompanyNo)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblCompanyNo)
        Me.Controls.Add(Me.stbMainMemberNo)
        Me.Controls.Add(Me.pnlStatusID)
        Me.Controls.Add(Me.nbxAge)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblDoB)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.btnEnrollFingerprint)
        Me.Controls.Add(Me.btnClearPhoto)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.btnLoadPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.stbReferenceNo)
        Me.Controls.Add(Me.lblReferenceNo)
        Me.Controls.Add(Me.stbSurname)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.stbFirstName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.stbMiddleName)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.cboGenderID)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.dtpJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.cboMemberTypeID)
        Me.Controls.Add(Me.lblMemberTypeID)
        Me.Controls.Add(Me.lblMainMemberNo)
        Me.Controls.Add(Me.dtpPolicyStartDate)
        Me.Controls.Add(Me.lblPolicyStartDate)
        Me.Controls.Add(Me.dtpPolicyEndDate)
        Me.Controls.Add(Me.lblPolicyEndDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmSchemeMembers"
        Me.Text = "Scheme Members"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStatusID.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbSurname As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents cboGenderID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents dtpJoinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents cboMemberTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblMemberTypeID As System.Windows.Forms.Label
    Friend WithEvents lblMainMemberNo As System.Windows.Forms.Label
    Friend WithEvents dtpPolicyStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicyStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpPolicyEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicyEndDate As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
    Friend WithEvents btnLoadPhoto As System.Windows.Forms.Button
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblDoB As System.Windows.Forms.Label
    Friend WithEvents pnlStatusID As System.Windows.Forms.Panel
    Friend WithEvents fcbStatusID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboInsuranceNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents cboPolicyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboCompanyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblCompanyNo As System.Windows.Forms.Label
    Friend WithEvents stbSchemeEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSchemeEndDate As System.Windows.Forms.Label
    Friend WithEvents stbSchemeStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSchemeStartDate As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents stbPhoneWork As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneWork As System.Windows.Forms.Label
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhoneMobile As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneMobile As System.Windows.Forms.Label
    Friend WithEvents stbPhoneHome As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneHome As System.Windows.Forms.Label
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents stbRelationship As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRelationship As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents cboMedicalCardNo As ComboBox
End Class