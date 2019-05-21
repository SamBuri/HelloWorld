<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmStaff
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStaff))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbQualifications = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblQualifications = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSpeciality = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fcbGenderID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblFristName = New System.Windows.Forms.Label()
        Me.lblSpeciality = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fcbStaffTitleID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.stbLoginID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDoctorSpecialtyID = New System.Windows.Forms.ComboBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.spbSignature = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.lblStaffTitleID = New System.Windows.Forms.Label()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.lblDoctorSpecialtyID = New System.Windows.Forms.Label()
        Me.btnClearSignature = New System.Windows.Forms.Button()
        Me.btnLoadSignature = New System.Windows.Forms.Button()
        Me.lblSignature = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        CType(Me.spbSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(277, 419)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 33
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLocation, "Location")
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(181, 202)
        Me.stbLocation.MaxLength = 20
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(168, 20)
        Me.stbLocation.TabIndex = 19
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(12, 204)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(138, 21)
        Me.lblLocation.TabIndex = 18
        Me.lblLocation.Text = "Location"
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmail, "Email")
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbEmail.Location = New System.Drawing.Point(181, 160)
        Me.stbEmail.MaxLength = 40
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4" & _
    "}|[0-9]{1,3})(\]?)$"
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbEmail.Size = New System.Drawing.Size(168, 20)
        Me.stbEmail.TabIndex = 15
        '
        'stbQualifications
        '
        Me.stbQualifications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbQualifications.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbQualifications, "Qualifications")
        Me.stbQualifications.EntryErrorMSG = ""
        Me.stbQualifications.Location = New System.Drawing.Point(181, 139)
        Me.stbQualifications.MaxLength = 40
        Me.stbQualifications.Name = "stbQualifications"
        Me.stbQualifications.RegularExpression = ""
        Me.stbQualifications.Size = New System.Drawing.Size(168, 20)
        Me.stbQualifications.TabIndex = 13
        '
        'lblQualifications
        '
        Me.lblQualifications.Location = New System.Drawing.Point(12, 141)
        Me.lblQualifications.Name = "lblQualifications"
        Me.lblQualifications.Size = New System.Drawing.Size(138, 21)
        Me.lblQualifications.TabIndex = 12
        Me.lblQualifications.Text = "Qualifications"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(181, 181)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(168, 20)
        Me.stbPhone.TabIndex = 17
        '
        'stbSpeciality
        '
        Me.stbSpeciality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpeciality.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSpeciality, "Speciality")
        Me.stbSpeciality.EntryErrorMSG = ""
        Me.stbSpeciality.Location = New System.Drawing.Point(181, 118)
        Me.stbSpeciality.MaxLength = 20
        Me.stbSpeciality.Name = "stbSpeciality"
        Me.stbSpeciality.RegularExpression = ""
        Me.stbSpeciality.Size = New System.Drawing.Size(168, 20)
        Me.stbSpeciality.TabIndex = 11
        '
        'fcbGenderID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbGenderID, "Gender,GenderID")
        Me.fcbGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbGenderID.FormattingEnabled = True
        Me.fcbGenderID.Location = New System.Drawing.Point(181, 73)
        Me.fcbGenderID.Name = "fcbGenderID"
        Me.fcbGenderID.ReadOnly = True
        Me.fcbGenderID.Size = New System.Drawing.Size(168, 21)
        Me.fcbGenderID.TabIndex = 7
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(181, 52)
        Me.stbLastName.MaxLength = 20
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(168, 20)
        Me.stbLastName.TabIndex = 5
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(181, 31)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(168, 20)
        Me.stbFirstName.TabIndex = 3
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(12, 183)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(138, 21)
        Me.lblPhoneNo.TabIndex = 16
        Me.lblPhoneNo.Text = "Phone Number"
        '
        'lblEmail
        '
        Me.lblEmail.Location = New System.Drawing.Point(12, 162)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(138, 21)
        Me.lblEmail.TabIndex = 14
        Me.lblEmail.Text = "E-mail"
        '
        'lblFristName
        '
        Me.lblFristName.Location = New System.Drawing.Point(12, 31)
        Me.lblFristName.Name = "lblFristName"
        Me.lblFristName.Size = New System.Drawing.Size(138, 21)
        Me.lblFristName.TabIndex = 2
        Me.lblFristName.Text = "First Name"
        '
        'lblSpeciality
        '
        Me.lblSpeciality.Location = New System.Drawing.Point(12, 120)
        Me.lblSpeciality.Name = "lblSpeciality"
        Me.lblSpeciality.Size = New System.Drawing.Size(138, 21)
        Me.lblSpeciality.TabIndex = 10
        Me.lblSpeciality.Text = "Speciality"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(12, 76)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(138, 21)
        Me.lblGenderID.TabIndex = 6
        Me.lblGenderID.Text = "Gender"
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(12, 52)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(138, 21)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(12, 10)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(138, 21)
        Me.lblStaffNo.TabIndex = 0
        Me.lblStaffNo.Text = "Staff Number"
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(12, 389)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(277, 389)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 31
        Me.btnDelete.Tag = "Staff"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 418)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 32
        Me.ebnSaveUpdate.Tag = "Staff"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'fcbStaffTitleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbStaffTitleID, "StaffTitle,StaffTitleID")
        Me.fcbStaffTitleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbStaffTitleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbStaffTitleID.FormattingEnabled = True
        Me.fcbStaffTitleID.Location = New System.Drawing.Point(181, 95)
        Me.fcbStaffTitleID.Name = "fcbStaffTitleID"
        Me.fcbStaffTitleID.ReadOnly = False
        Me.fcbStaffTitleID.Size = New System.Drawing.Size(168, 21)
        Me.fcbStaffTitleID.TabIndex = 9
        '
        'stbLoginID
        '
        Me.stbLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLoginID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLoginID, "LoginID")
        Me.stbLoginID.EntryErrorMSG = ""
        Me.stbLoginID.Location = New System.Drawing.Point(181, 336)
        Me.stbLoginID.MaxLength = 20
        Me.stbLoginID.Name = "stbLoginID"
        Me.stbLoginID.RegularExpression = ""
        Me.stbLoginID.Size = New System.Drawing.Size(168, 20)
        Me.stbLoginID.TabIndex = 28
        '
        'cboDoctorSpecialtyID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDoctorSpecialtyID, "DoctorSpecialty,DoctorSpecialtyID")
        Me.cboDoctorSpecialtyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctorSpecialtyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDoctorSpecialtyID.FormattingEnabled = True
        Me.cboDoctorSpecialtyID.ItemHeight = 13
        Me.cboDoctorSpecialtyID.Location = New System.Drawing.Point(181, 224)
        Me.cboDoctorSpecialtyID.Name = "cboDoctorSpecialtyID"
        Me.cboDoctorSpecialtyID.Size = New System.Drawing.Size(168, 21)
        Me.cboDoctorSpecialtyID.TabIndex = 21
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(10, 359)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(181, 20)
        Me.chkHidden.TabIndex = 29
        Me.chkHidden.Text = "Hidden"
        '
        'spbSignature
        '
        Me.spbSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbSignature, "Signature")
        Me.spbSignature.Image = CType(resources.GetObject("spbSignature.Image"), System.Drawing.Image)
        Me.spbSignature.ImageSizeLimit = CType(200000, Long)
        Me.spbSignature.InitialImage = CType(resources.GetObject("spbSignature.InitialImage"), System.Drawing.Image)
        Me.spbSignature.Location = New System.Drawing.Point(181, 275)
        Me.spbSignature.Name = "spbSignature"
        Me.spbSignature.ReadOnly = False
        Me.spbSignature.Size = New System.Drawing.Size(100, 60)
        Me.spbSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbSignature.TabIndex = 45
        Me.spbSignature.TabStop = False
        '
        'lblStaffTitleID
        '
        Me.lblStaffTitleID.Location = New System.Drawing.Point(12, 95)
        Me.lblStaffTitleID.Name = "lblStaffTitleID"
        Me.lblStaffTitleID.Size = New System.Drawing.Size(138, 21)
        Me.lblStaffTitleID.TabIndex = 8
        Me.lblStaffTitleID.Text = "Staff Title"
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(12, 335)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(138, 21)
        Me.lblLoginID.TabIndex = 27
        Me.lblLoginID.Text = "Associated Login ID"
        '
        'lblDoctorSpecialtyID
        '
        Me.lblDoctorSpecialtyID.Location = New System.Drawing.Point(12, 225)
        Me.lblDoctorSpecialtyID.Name = "lblDoctorSpecialtyID"
        Me.lblDoctorSpecialtyID.Size = New System.Drawing.Size(138, 21)
        Me.lblDoctorSpecialtyID.TabIndex = 20
        Me.lblDoctorSpecialtyID.Text = "Doctor Specialty"
        '
        'btnClearSignature
        '
        Me.btnClearSignature.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearSignature.Location = New System.Drawing.Point(291, 312)
        Me.btnClearSignature.Name = "btnClearSignature"
        Me.btnClearSignature.Size = New System.Drawing.Size(58, 23)
        Me.btnClearSignature.TabIndex = 26
        Me.btnClearSignature.Text = "Clear"
        Me.btnClearSignature.UseVisualStyleBackColor = True
        '
        'btnLoadSignature
        '
        Me.btnLoadSignature.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadSignature.Location = New System.Drawing.Point(291, 277)
        Me.btnLoadSignature.Name = "btnLoadSignature"
        Me.btnLoadSignature.Size = New System.Drawing.Size(58, 23)
        Me.btnLoadSignature.TabIndex = 25
        Me.btnLoadSignature.Text = "Load..."
        Me.btnLoadSignature.UseVisualStyleBackColor = True
        '
        'lblSignature
        '
        Me.lblSignature.Location = New System.Drawing.Point(12, 296)
        Me.lblSignature.Name = "lblSignature"
        Me.lblSignature.Size = New System.Drawing.Size(138, 21)
        Me.lblSignature.TabIndex = 24
        Me.lblSignature.Text = "Signature"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(12, 249)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(179, 21)
        Me.chkFingerprintCaptured.TabIndex = 22
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(194, 247)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(155, 23)
        Me.btnEnrollFingerprint.TabIndex = 23
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AllowDrop = True
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStaffNo.DropDownWidth = 300
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(181, 7)
        Me.cboStaffNo.MaxLength = 224
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(168, 21)
        Me.cboStaffNo.TabIndex = 46
        '
        'frmStaff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(365, 452)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.btnEnrollFingerprint)
        Me.Controls.Add(Me.btnClearSignature)
        Me.Controls.Add(Me.spbSignature)
        Me.Controls.Add(Me.btnLoadSignature)
        Me.Controls.Add(Me.lblSignature)
        Me.Controls.Add(Me.chkHidden)
        Me.Controls.Add(Me.cboDoctorSpecialtyID)
        Me.Controls.Add(Me.lblDoctorSpecialtyID)
        Me.Controls.Add(Me.stbLoginID)
        Me.Controls.Add(Me.lblLoginID)
        Me.Controls.Add(Me.fcbStaffTitleID)
        Me.Controls.Add(Me.lblStaffTitleID)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.stbLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.stbEmail)
        Me.Controls.Add(Me.stbQualifications)
        Me.Controls.Add(Me.lblQualifications)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.stbSpeciality)
        Me.Controls.Add(Me.fcbGenderID)
        Me.Controls.Add(Me.stbLastName)
        Me.Controls.Add(Me.stbFirstName)
        Me.Controls.Add(Me.lblPhoneNo)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.lblFristName)
        Me.Controls.Add(Me.lblSpeciality)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmStaff"
        Me.Text = "Staff"
        CType(Me.spbSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbQualifications As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblQualifications As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbSpeciality As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fcbGenderID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblFristName As System.Windows.Forms.Label
    Friend WithEvents lblSpeciality As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fcbStaffTitleID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblStaffTitleID As System.Windows.Forms.Label
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbLoginID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboDoctorSpecialtyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorSpecialtyID As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearSignature As System.Windows.Forms.Button
    Protected WithEvents spbSignature As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnLoadSignature As System.Windows.Forms.Button
    Friend WithEvents lblSignature As System.Windows.Forms.Label
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents cboStaffNo As ComboBox
End Class
