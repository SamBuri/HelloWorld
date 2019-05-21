
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClients : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClients))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboGenderID = New System.Windows.Forms.ComboBox()
        Me.stbPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDoctorSpecialtyID = New System.Windows.Forms.ComboBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.dtpAppointmentDate = New System.Windows.Forms.DateTimePicker()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblDoctorSpecialtyID = New System.Windows.Forms.Label()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.lblAppointmentDateTime = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 353)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 24
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(331, 353)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 25
        Me.fbnDelete.Tag = "Clients"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 380)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 26
        Me.ebnSaveUpdate.Tag = "Clients"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(157, 30)
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(214, 20)
        Me.stbFirstName.TabIndex = 3
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(157, 52)
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(214, 20)
        Me.stbLastName.TabIndex = 5
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        Me.stbMiddleName.Location = New System.Drawing.Point(157, 74)
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        Me.stbMiddleName.Size = New System.Drawing.Size(214, 20)
        Me.stbMiddleName.TabIndex = 7
        '
        'cboGenderID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGenderID, "Gender,GenderID")
        Me.cboGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGenderID.Location = New System.Drawing.Point(157, 96)
        Me.cboGenderID.Name = "cboGenderID"
        Me.cboGenderID.Size = New System.Drawing.Size(214, 21)
        Me.cboGenderID.TabIndex = 9
        '
        'stbPhoneNo
        '
        Me.stbPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhoneNo, "PhoneNo")
        Me.stbPhoneNo.EntryErrorMSG = ""
        Me.stbPhoneNo.Location = New System.Drawing.Point(157, 119)
        Me.stbPhoneNo.Name = "stbPhoneNo"
        Me.stbPhoneNo.RegularExpression = ""
        Me.stbPhoneNo.Size = New System.Drawing.Size(214, 20)
        Me.stbPhoneNo.TabIndex = 11
        '
        'stbDescription
        '
        Me.stbDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDescription.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDescription, "Description")
        Me.stbDescription.EntryErrorMSG = ""
        Me.stbDescription.Location = New System.Drawing.Point(157, 253)
        Me.stbDescription.Multiline = True
        Me.stbDescription.Name = "stbDescription"
        Me.stbDescription.RegularExpression = ""
        Me.stbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDescription.Size = New System.Drawing.Size(246, 85)
        Me.stbDescription.TabIndex = 23
        '
        'cboDoctorSpecialtyID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDoctorSpecialtyID, "DoctorSpecialty,DoctorSpecialtyID")
        Me.cboDoctorSpecialtyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctorSpecialtyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDoctorSpecialtyID.FormattingEnabled = True
        Me.cboDoctorSpecialtyID.ItemHeight = 13
        Me.cboDoctorSpecialtyID.Location = New System.Drawing.Point(157, 207)
        Me.cboDoctorSpecialtyID.Name = "cboDoctorSpecialtyID"
        Me.cboDoctorSpecialtyID.Size = New System.Drawing.Size(214, 21)
        Me.cboDoctorSpecialtyID.TabIndex = 19
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(157, 230)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(214, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 21
        '
        'dtpAppointmentDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpAppointmentDate, "AppointmentDateTime")
        Me.dtpAppointmentDate.Location = New System.Drawing.Point(157, 185)
        Me.dtpAppointmentDate.Name = "dtpAppointmentDate"
        Me.dtpAppointmentDate.ShowCheckBox = True
        Me.dtpAppointmentDate.Size = New System.Drawing.Size(214, 20)
        Me.dtpAppointmentDate.TabIndex = 17
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(157, 163)
        Me.nbxAge.MaxLength = 3
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(67, 20)
        Me.nbxAge.TabIndex = 15
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Location = New System.Drawing.Point(157, 141)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(214, 20)
        Me.dtpBirthDate.TabIndex = 13
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(331, 380)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 27
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        Me.stbReferenceNo.EntryErrorMSG = ""
        Me.stbReferenceNo.Location = New System.Drawing.Point(157, 8)
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        Me.stbReferenceNo.Size = New System.Drawing.Size(214, 20)
        Me.stbReferenceNo.TabIndex = 1
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Location = New System.Drawing.Point(6, 11)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(122, 20)
        Me.lblReferenceNo.TabIndex = 0
        Me.lblReferenceNo.Text = "Reference No"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(6, 33)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(122, 20)
        Me.lblFirstName.TabIndex = 2
        Me.lblFirstName.Text = "First Name"
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(6, 55)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(122, 20)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.Location = New System.Drawing.Point(6, 77)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(122, 20)
        Me.lblMiddleName.TabIndex = 6
        Me.lblMiddleName.Text = "Middle Name"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(6, 99)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(122, 20)
        Me.lblGenderID.TabIndex = 8
        Me.lblGenderID.Text = "Gender"
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(6, 121)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(122, 20)
        Me.lblPhoneNo.TabIndex = 10
        Me.lblPhoneNo.Text = "Phone No"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(6, 258)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(122, 20)
        Me.lblDescription.TabIndex = 22
        Me.lblDescription.Text = "Description"
        '
        'lblDoctorSpecialtyID
        '
        Me.lblDoctorSpecialtyID.Location = New System.Drawing.Point(6, 210)
        Me.lblDoctorSpecialtyID.Name = "lblDoctorSpecialtyID"
        Me.lblDoctorSpecialtyID.Size = New System.Drawing.Size(153, 21)
        Me.lblDoctorSpecialtyID.TabIndex = 18
        Me.lblDoctorSpecialtyID.Text = "To-See Doctor Specialty"
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(6, 233)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(153, 23)
        Me.lblStaff.TabIndex = 20
        Me.lblStaff.Text = "To-See Doctor  (Staff)"
        '
        'lblAppointmentDateTime
        '
        Me.lblAppointmentDateTime.Location = New System.Drawing.Point(6, 187)
        Me.lblAppointmentDateTime.Name = "lblAppointmentDateTime"
        Me.lblAppointmentDateTime.Size = New System.Drawing.Size(153, 21)
        Me.lblAppointmentDateTime.TabIndex = 16
        Me.lblAppointmentDateTime.Text = "Appointment Date"
        '
        'lblAge
        '
        Me.lblAge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAge.Location = New System.Drawing.Point(6, 163)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(122, 20)
        Me.lblAge.TabIndex = 14
        Me.lblAge.Text = "Age"
        '
        'lblDoB
        '
        Me.lblDoB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDoB.Location = New System.Drawing.Point(6, 143)
        Me.lblDoB.Name = "lblDoB"
        Me.lblDoB.Size = New System.Drawing.Size(122, 20)
        Me.lblDoB.TabIndex = 12
        Me.lblDoB.Text = "Date of Birth"
        '
        'frmClients
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 411)
        Me.Controls.Add(Me.nbxAge)
        Me.Controls.Add(Me.dtpBirthDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblDoB)
        Me.Controls.Add(Me.dtpAppointmentDate)
        Me.Controls.Add(Me.lblAppointmentDateTime)
        Me.Controls.Add(Me.cboDoctorSpecialtyID)
        Me.Controls.Add(Me.lblDoctorSpecialtyID)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbReferenceNo)
        Me.Controls.Add(Me.lblReferenceNo)
        Me.Controls.Add(Me.stbFirstName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.stbLastName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.stbMiddleName)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.cboGenderID)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbPhoneNo)
        Me.Controls.Add(Me.lblPhoneNo)
        Me.Controls.Add(Me.stbDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmClients"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clients"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents cboGenderID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
    Friend WithEvents stbDescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents cboDoctorSpecialtyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorSpecialtyID As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents dtpAppointmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAppointmentDateTime As System.Windows.Forms.Label
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblDoB As System.Windows.Forms.Label

End Class