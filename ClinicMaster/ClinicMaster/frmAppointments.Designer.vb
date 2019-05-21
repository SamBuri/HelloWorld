
Option Strict On

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAppointments : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal _NextAppointment As NextAppointment)
        MyClass.New()
        Me.oNextAppointment = _NextAppointment
    End Sub

    Public Sub New(ByVal patientNo As String)
        MyClass.New()
        Me.defaultPatientNo = patientNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAppointments))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAppointmentDes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cboAppointmentStatusID = New System.Windows.Forms.ComboBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.rdoRange = New System.Windows.Forms.RadioButton()
        Me.rdoExact = New System.Windows.Forms.RadioButton()
        Me.nbxDuration = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboDoctorSpecialtyID = New System.Windows.Forms.ComboBox()
        Me.stpStartTime = New SyncSoft.Common.Win.Controls.SmartTimePicker()
        Me.cboAppointmentCategoryID = New System.Windows.Forms.ComboBox()
        Me.cboCommunityID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblAppointmentDes = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.pnlAppointmentStatusID = New System.Windows.Forms.Panel()
        Me.lblAppointmentStatusID = New System.Windows.Forms.Label()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.grpAppointmentPrecision = New System.Windows.Forms.GroupBox()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.lblDoctorSpecialtyID = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.stbPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblAppointmentCategory = New System.Windows.Forms.Label()
        Me.pnlCommunity = New System.Windows.Forms.Panel()
        Me.lblCommunityID = New System.Windows.Forms.Label()
        Me.pnlAppointmentStatusID.SuspendLayout()
        Me.grpAppointmentPrecision.SuspendLayout()
        Me.pnlCommunity.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(12, 405)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 17
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = False
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(284, 405)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Tag = "Appointments"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 434)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 19
        Me.ebnSaveUpdate.Tag = "Appointments"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAppointmentDes
        '
        Me.stbAppointmentDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAppointmentDes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAppointmentDes, "AppointmentDes")
        Me.stbAppointmentDes.EntryErrorMSG = ""
        Me.stbAppointmentDes.Location = New System.Drawing.Point(174, 321)
        Me.stbAppointmentDes.MaxLength = 100
        Me.stbAppointmentDes.Multiline = True
        Me.stbAppointmentDes.Name = "stbAppointmentDes"
        Me.stbAppointmentDes.RegularExpression = ""
        Me.stbAppointmentDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAppointmentDes.Size = New System.Drawing.Size(188, 46)
        Me.stbAppointmentDes.TabIndex = 15
        '
        'dtpEndDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEndDate, "EndDate")
        Me.dtpEndDate.Location = New System.Drawing.Point(175, 195)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpEndDate.TabIndex = 9
        '
        'cboAppointmentStatusID
        '
        Me.cboAppointmentStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAppointmentStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboAppointmentStatusID, "AppointmentStatus,AppointmentStatusID")
        Me.cboAppointmentStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppointmentStatusID.Enabled = False
        Me.cboAppointmentStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAppointmentStatusID.FormattingEnabled = True
        Me.cboAppointmentStatusID.Location = New System.Drawing.Point(163, 3)
        Me.cboAppointmentStatusID.Name = "cboAppointmentStatusID"
        Me.cboAppointmentStatusID.Size = New System.Drawing.Size(188, 21)
        Me.cboAppointmentStatusID.TabIndex = 1
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(175, 240)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(188, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 13
        '
        'rdoRange
        '
        Me.ebnSaveUpdate.SetDataMember(Me.rdoRange, "AppointmentPrecision")
        Me.rdoRange.Location = New System.Drawing.Point(16, 19)
        Me.rdoRange.Name = "rdoRange"
        Me.rdoRange.Size = New System.Drawing.Size(103, 20)
        Me.rdoRange.TabIndex = 0
        Me.rdoRange.Text = "Range"
        '
        'rdoExact
        '
        Me.ebnSaveUpdate.SetDataMember(Me.rdoExact, "AppointmentPrecision")
        Me.rdoExact.Location = New System.Drawing.Point(16, 45)
        Me.rdoExact.Name = "rdoExact"
        Me.rdoExact.Size = New System.Drawing.Size(103, 20)
        Me.rdoExact.TabIndex = 1
        Me.rdoExact.Text = "Exact"
        '
        'nbxDuration
        '
        Me.nbxDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDuration.ControlCaption = "Duration"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDuration, "Duration")
        Me.nbxDuration.DecimalPlaces = -1
        Me.nbxDuration.Location = New System.Drawing.Point(223, 68)
        Me.nbxDuration.MaxValue = 240.0R
        Me.nbxDuration.MinValue = 1.0R
        Me.nbxDuration.MustEnterNumeric = True
        Me.nbxDuration.Name = "nbxDuration"
        Me.nbxDuration.Size = New System.Drawing.Size(90, 20)
        Me.nbxDuration.TabIndex = 5
        Me.nbxDuration.Value = ""
        Me.nbxDuration.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'cboDoctorSpecialtyID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDoctorSpecialtyID, "DoctorSpecialty,DoctorSpecialtyID")
        Me.cboDoctorSpecialtyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctorSpecialtyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDoctorSpecialtyID.FormattingEnabled = True
        Me.cboDoctorSpecialtyID.ItemHeight = 13
        Me.cboDoctorSpecialtyID.Location = New System.Drawing.Point(175, 217)
        Me.cboDoctorSpecialtyID.Name = "cboDoctorSpecialtyID"
        Me.cboDoctorSpecialtyID.Size = New System.Drawing.Size(188, 21)
        Me.cboDoctorSpecialtyID.TabIndex = 11
        '
        'stpStartTime
        '
        Me.stpStartTime.Checked = False
        Me.stpStartTime.CustomFormat = "hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.stpStartTime, "StartTime")
        Me.stpStartTime.Location = New System.Drawing.Point(223, 45)
        Me.stpStartTime.Name = "stpStartTime"
        Me.stpStartTime.ShowCheckBox = True
        Me.stpStartTime.ShowUpDown = True
        Me.stpStartTime.Size = New System.Drawing.Size(90, 20)
        Me.stpStartTime.TabIndex = 3
        Me.stpStartTime.Value = New Date(2011, 9, 19, 13, 49, 25, 18)
        '
        'cboAppointmentCategoryID
        '
        Me.cboAppointmentCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAppointmentCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboAppointmentCategoryID, "AppointmentCategory,AppointmentCategoryID")
        Me.cboAppointmentCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppointmentCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAppointmentCategoryID.FormattingEnabled = True
        Me.cboAppointmentCategoryID.ItemHeight = 13
        Me.cboAppointmentCategoryID.Location = New System.Drawing.Point(175, 264)
        Me.cboAppointmentCategoryID.Name = "cboAppointmentCategoryID"
        Me.cboAppointmentCategoryID.Size = New System.Drawing.Size(188, 21)
        Me.cboAppointmentCategoryID.TabIndex = 48
        '
        'cboCommunityID
        '
        Me.cboCommunityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommunityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCommunityID, "CommunityID")
        Me.cboCommunityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommunityID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCommunityID.Location = New System.Drawing.Point(173, 3)
        Me.cboCommunityID.Name = "cboCommunityID"
        Me.cboCommunityID.Size = New System.Drawing.Size(188, 21)
        Me.cboCommunityID.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(284, 435)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 20
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(175, 30)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(188, 20)
        Me.stbFullName.TabIndex = 4
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(175, 9)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(135, 20)
        Me.stbPatientNo.TabIndex = 1
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(16, 30)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(139, 21)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "Patient's Name"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(16, 9)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(139, 21)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'lblAppointmentDes
        '
        Me.lblAppointmentDes.Location = New System.Drawing.Point(15, 334)
        Me.lblAppointmentDes.Name = "lblAppointmentDes"
        Me.lblAppointmentDes.Size = New System.Drawing.Size(139, 21)
        Me.lblAppointmentDes.TabIndex = 14
        Me.lblAppointmentDes.Text = "Appointment Description"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(175, 73)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(188, 20)
        Me.dtpStartDate.TabIndex = 6
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(16, 73)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(139, 21)
        Me.lblStartDate.TabIndex = 5
        Me.lblStartDate.Text = "Start Date"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(16, 195)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(139, 21)
        Me.lblEndDate.TabIndex = 8
        Me.lblEndDate.Text = "End Date"
        '
        'pnlAppointmentStatusID
        '
        Me.pnlAppointmentStatusID.Controls.Add(Me.cboAppointmentStatusID)
        Me.pnlAppointmentStatusID.Controls.Add(Me.lblAppointmentStatusID)
        Me.pnlAppointmentStatusID.Location = New System.Drawing.Point(11, 369)
        Me.pnlAppointmentStatusID.Name = "pnlAppointmentStatusID"
        Me.pnlAppointmentStatusID.Size = New System.Drawing.Size(354, 28)
        Me.pnlAppointmentStatusID.TabIndex = 16
        '
        'lblAppointmentStatusID
        '
        Me.lblAppointmentStatusID.Enabled = False
        Me.lblAppointmentStatusID.Location = New System.Drawing.Point(4, 3)
        Me.lblAppointmentStatusID.Name = "lblAppointmentStatusID"
        Me.lblAppointmentStatusID.Size = New System.Drawing.Size(139, 21)
        Me.lblAppointmentStatusID.TabIndex = 0
        Me.lblAppointmentStatusID.Text = "Appointment Status"
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(16, 240)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(139, 23)
        Me.lblStaff.TabIndex = 12
        Me.lblStaff.Text = "To-See Doctor  (Staff)"
        '
        'grpAppointmentPrecision
        '
        Me.grpAppointmentPrecision.Controls.Add(Me.stpStartTime)
        Me.grpAppointmentPrecision.Controls.Add(Me.lblDuration)
        Me.grpAppointmentPrecision.Controls.Add(Me.nbxDuration)
        Me.grpAppointmentPrecision.Controls.Add(Me.lblStartTime)
        Me.grpAppointmentPrecision.Controls.Add(Me.rdoRange)
        Me.grpAppointmentPrecision.Controls.Add(Me.rdoExact)
        Me.grpAppointmentPrecision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grpAppointmentPrecision.Location = New System.Drawing.Point(19, 96)
        Me.grpAppointmentPrecision.Name = "grpAppointmentPrecision"
        Me.grpAppointmentPrecision.Size = New System.Drawing.Size(343, 93)
        Me.grpAppointmentPrecision.TabIndex = 7
        Me.grpAppointmentPrecision.TabStop = False
        Me.grpAppointmentPrecision.Text = "Appointment Precision"
        '
        'lblDuration
        '
        Me.lblDuration.Location = New System.Drawing.Point(126, 68)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(91, 20)
        Me.lblDuration.TabIndex = 4
        Me.lblDuration.Text = "Duration (Min)"
        '
        'lblStartTime
        '
        Me.lblStartTime.Location = New System.Drawing.Point(126, 45)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(91, 20)
        Me.lblStartTime.TabIndex = 2
        Me.lblStartTime.Text = "Start Time"
        '
        'lblDoctorSpecialtyID
        '
        Me.lblDoctorSpecialtyID.Location = New System.Drawing.Point(16, 218)
        Me.lblDoctorSpecialtyID.Name = "lblDoctorSpecialtyID"
        Me.lblDoctorSpecialtyID.Size = New System.Drawing.Size(139, 21)
        Me.lblDoctorSpecialtyID.TabIndex = 10
        Me.lblDoctorSpecialtyID.Text = "To-See Doctor Specialty"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(316, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'stbPhoneNo
        '
        Me.stbPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneNo.CapitalizeFirstLetter = False
        Me.stbPhoneNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPhoneNo.Enabled = False
        Me.stbPhoneNo.EntryErrorMSG = ""
        Me.stbPhoneNo.Location = New System.Drawing.Point(175, 51)
        Me.stbPhoneNo.MaxLength = 7
        Me.stbPhoneNo.Name = "stbPhoneNo"
        Me.stbPhoneNo.RegularExpression = ""
        Me.stbPhoneNo.Size = New System.Drawing.Size(187, 20)
        Me.stbPhoneNo.TabIndex = 46
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(16, 51)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(139, 20)
        Me.lblPhoneNo.TabIndex = 45
        Me.lblPhoneNo.Text = "Phone No."
        '
        'lblAppointmentCategory
        '
        Me.lblAppointmentCategory.Location = New System.Drawing.Point(16, 265)
        Me.lblAppointmentCategory.Name = "lblAppointmentCategory"
        Me.lblAppointmentCategory.Size = New System.Drawing.Size(139, 20)
        Me.lblAppointmentCategory.TabIndex = 47
        Me.lblAppointmentCategory.Text = "Appointment Category"
        '
        'pnlCommunity
        '
        Me.pnlCommunity.Controls.Add(Me.lblCommunityID)
        Me.pnlCommunity.Controls.Add(Me.cboCommunityID)
        Me.pnlCommunity.Location = New System.Drawing.Point(3, 288)
        Me.pnlCommunity.Name = "pnlCommunity"
        Me.pnlCommunity.Size = New System.Drawing.Size(370, 28)
        Me.pnlCommunity.TabIndex = 79
        '
        'lblCommunityID
        '
        Me.lblCommunityID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCommunityID.Location = New System.Drawing.Point(15, 4)
        Me.lblCommunityID.Name = "lblCommunityID"
        Me.lblCommunityID.Size = New System.Drawing.Size(139, 20)
        Me.lblCommunityID.TabIndex = 0
        Me.lblCommunityID.Text = "Community "
        '
        'frmAppointments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(385, 467)
        Me.Controls.Add(Me.pnlCommunity)
        Me.Controls.Add(Me.cboAppointmentCategoryID)
        Me.Controls.Add(Me.lblAppointmentCategory)
        Me.Controls.Add(Me.stbPhoneNo)
        Me.Controls.Add(Me.lblPhoneNo)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboDoctorSpecialtyID)
        Me.Controls.Add(Me.lblDoctorSpecialtyID)
        Me.Controls.Add(Me.grpAppointmentPrecision)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.pnlAppointmentStatusID)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.stbAppointmentDes)
        Me.Controls.Add(Me.lblAppointmentDes)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAppointments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Appointments"
        Me.pnlAppointmentStatusID.ResumeLayout(False)
        Me.grpAppointmentPrecision.ResumeLayout(False)
        Me.grpAppointmentPrecision.PerformLayout()
        Me.pnlCommunity.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents stbAppointmentDes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAppointmentDes As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents pnlAppointmentStatusID As System.Windows.Forms.Panel
    Friend WithEvents cboAppointmentStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAppointmentStatusID As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents grpAppointmentPrecision As System.Windows.Forms.GroupBox
    Friend WithEvents rdoRange As System.Windows.Forms.RadioButton
    Friend WithEvents rdoExact As System.Windows.Forms.RadioButton
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents nbxDuration As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboDoctorSpecialtyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorSpecialtyID As System.Windows.Forms.Label
    Friend WithEvents stpStartTime As SyncSoft.Common.Win.Controls.SmartTimePicker
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As Label
    Friend WithEvents cboAppointmentCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAppointmentCategory As System.Windows.Forms.Label
    Friend WithEvents pnlCommunity As System.Windows.Forms.Panel
    Friend WithEvents lblCommunityID As System.Windows.Forms.Label
    Friend WithEvents cboCommunityID As System.Windows.Forms.ComboBox
End Class
