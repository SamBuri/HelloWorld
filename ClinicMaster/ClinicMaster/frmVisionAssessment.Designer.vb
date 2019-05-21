
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisionAssessment : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultVisitNo = visitNo
        Me.noCallOnKeyEdit = disableCallOnKeyEdit
    End Sub

    Public Sub New(ByVal visitNo As String, ByVal eyeTestID As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New(visitNo, disableCallOnKeyEdit)
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisionAssessment))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboVisualAcuityRightID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityRightExtID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityLeftID = New System.Windows.Forms.ComboBox()
        Me.cboVisualAcuityLeftExtID = New System.Windows.Forms.ComboBox()
        Me.cboPreferentialLookingRightID = New System.Windows.Forms.ComboBox()
        Me.cboPreferentialLookingLeftID = New System.Windows.Forms.ComboBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboEyeTestID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblVisualAcuityRightID = New System.Windows.Forms.Label()
        Me.lblVisualAcuityRightExtID = New System.Windows.Forms.Label()
        Me.lblPreferentialLooking = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblHospitalPID = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.chkHideSelfRequest = New System.Windows.Forms.CheckBox()
        Me.btnPendingVisitTriage = New System.Windows.Forms.Button()
        Me.lblAlertMessage = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.lblEyeTest = New System.Windows.Forms.Label()
        Me.lblleft = New System.Windows.Forms.Label()
        Me.lblRight = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlerts.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(26, 414)
        Me.fbnSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(103, 28)
        Me.fbnSearch.TabIndex = 38
        Me.fbnSearch.Tag = "VisionAssessment"
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(639, 414)
        Me.fbnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(96, 30)
        Me.fbnDelete.TabIndex = 39
        Me.fbnDelete.Tag = "VisionAssessment"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(26, 447)
        Me.ebnSaveUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(103, 28)
        Me.ebnSaveUpdate.TabIndex = 36
        Me.ebnSaveUpdate.Tag = "VisionAssessment"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboVisualAcuityRightID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityRightID, "VisualAcuityRight,VisualAcuityRightID")
        Me.cboVisualAcuityRightID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityRightID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityRightID.Location = New System.Drawing.Point(192, 249)
        Me.cboVisualAcuityRightID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVisualAcuityRightID.Name = "cboVisualAcuityRightID"
        Me.cboVisualAcuityRightID.Size = New System.Drawing.Size(235, 24)
        Me.cboVisualAcuityRightID.TabIndex = 20
        '
        'cboVisualAcuityRightExtID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityRightExtID, "VisualAcuityRightExt,VisualAcuityRightExtID")
        Me.cboVisualAcuityRightExtID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityRightExtID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityRightExtID.Location = New System.Drawing.Point(192, 277)
        Me.cboVisualAcuityRightExtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVisualAcuityRightExtID.Name = "cboVisualAcuityRightExtID"
        Me.cboVisualAcuityRightExtID.Size = New System.Drawing.Size(235, 24)
        Me.cboVisualAcuityRightExtID.TabIndex = 23
        '
        'cboVisualAcuityLeftID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityLeftID, "VisualAcuityLeft,VisualAcuityLeftID")
        Me.cboVisualAcuityLeftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityLeftID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityLeftID.Location = New System.Drawing.Point(501, 249)
        Me.cboVisualAcuityLeftID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVisualAcuityLeftID.Name = "cboVisualAcuityLeftID"
        Me.cboVisualAcuityLeftID.Size = New System.Drawing.Size(235, 24)
        Me.cboVisualAcuityLeftID.TabIndex = 21
        '
        'cboVisualAcuityLeftExtID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisualAcuityLeftExtID, "VisualAcuityLeftExt,VisualAcuityLeftExtID")
        Me.cboVisualAcuityLeftExtID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisualAcuityLeftExtID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisualAcuityLeftExtID.Location = New System.Drawing.Point(501, 277)
        Me.cboVisualAcuityLeftExtID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboVisualAcuityLeftExtID.Name = "cboVisualAcuityLeftExtID"
        Me.cboVisualAcuityLeftExtID.Size = New System.Drawing.Size(235, 24)
        Me.cboVisualAcuityLeftExtID.TabIndex = 24
        '
        'cboPreferentialLookingRightID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPreferentialLookingRightID, "PreferentialLookingRight,PreferentialLookingRightID")
        Me.cboPreferentialLookingRightID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreferentialLookingRightID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPreferentialLookingRightID.Location = New System.Drawing.Point(193, 305)
        Me.cboPreferentialLookingRightID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPreferentialLookingRightID.Name = "cboPreferentialLookingRightID"
        Me.cboPreferentialLookingRightID.Size = New System.Drawing.Size(235, 24)
        Me.cboPreferentialLookingRightID.TabIndex = 29
        '
        'cboPreferentialLookingLeftID
        '
        Me.cboPreferentialLookingLeftID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPreferentialLookingLeftID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboPreferentialLookingLeftID, "PreferentialLookingLeft,PreferentialLookingLeftID")
        Me.cboPreferentialLookingLeftID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPreferentialLookingLeftID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPreferentialLookingLeftID.FormattingEnabled = True
        Me.cboPreferentialLookingLeftID.Location = New System.Drawing.Point(502, 306)
        Me.cboPreferentialLookingLeftID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboPreferentialLookingLeftID.Name = "cboPreferentialLookingLeftID"
        Me.cboPreferentialLookingLeftID.Size = New System.Drawing.Size(235, 24)
        Me.cboPreferentialLookingLeftID.TabIndex = 30
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(190, 335)
        Me.stbNotes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbNotes.MaxLength = 200
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(546, 71)
        Me.stbNotes.TabIndex = 34
        '
        'cboEyeTestID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboEyeTestID, "EyeTest,EyeTestID")
        Me.cboEyeTestID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEyeTestID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboEyeTestID.Location = New System.Drawing.Point(192, 188)
        Me.cboEyeTestID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboEyeTestID.Name = "cboEyeTestID"
        Me.cboEyeTestID.Size = New System.Drawing.Size(235, 24)
        Me.cboEyeTestID.TabIndex = 12
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(639, 447)
        Me.fbnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(96, 30)
        Me.fbnClose.TabIndex = 37
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(192, 85)
        Me.stbVisitNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(169, 22)
        Me.stbVisitNo.TabIndex = 3
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(24, 89)
        Me.lblVisitNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(105, 25)
        Me.lblVisitNo.TabIndex = 1
        Me.lblVisitNo.Text = "VisitNo"
        '
        'lblVisualAcuityRightID
        '
        Me.lblVisualAcuityRightID.Location = New System.Drawing.Point(24, 251)
        Me.lblVisualAcuityRightID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisualAcuityRightID.Name = "lblVisualAcuityRightID"
        Me.lblVisualAcuityRightID.Size = New System.Drawing.Size(149, 25)
        Me.lblVisualAcuityRightID.TabIndex = 19
        Me.lblVisualAcuityRightID.Text = "Visual Acuity"
        '
        'lblVisualAcuityRightExtID
        '
        Me.lblVisualAcuityRightExtID.Location = New System.Drawing.Point(24, 281)
        Me.lblVisualAcuityRightExtID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisualAcuityRightExtID.Name = "lblVisualAcuityRightExtID"
        Me.lblVisualAcuityRightExtID.Size = New System.Drawing.Size(149, 25)
        Me.lblVisualAcuityRightExtID.TabIndex = 22
        Me.lblVisualAcuityRightExtID.Text = "Visual Acuity Ext"
        '
        'lblPreferentialLooking
        '
        Me.lblPreferentialLooking.Location = New System.Drawing.Point(26, 305)
        Me.lblPreferentialLooking.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPreferentialLooking.Name = "lblPreferentialLooking"
        Me.lblPreferentialLooking.Size = New System.Drawing.Size(149, 25)
        Me.lblPreferentialLooking.TabIndex = 28
        Me.lblPreferentialLooking.Text = "Preferential Looking"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(23, 360)
        Me.lblNotes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(149, 25)
        Me.lblNotes.TabIndex = 33
        Me.lblNotes.Text = "Notes"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 25)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = False
        Me.stbClientMachine.EntryErrorMSG = ""
        Me.stbClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.stbClientMachine.Name = "stbClientMachine"
        Me.stbClientMachine.RegularExpression = ""
        Me.stbClientMachine.Size = New System.Drawing.Size(100, 22)
        Me.stbClientMachine.TabIndex = 0
        '
        'lblClientMachine
        '
        Me.lblClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.lblClientMachine.Name = "lblClientMachine"
        Me.lblClientMachine.Size = New System.Drawing.Size(100, 23)
        Me.lblClientMachine.TabIndex = 0
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(540, 156)
        Me.stbVisitDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(198, 22)
        Me.stbVisitDate.TabIndex = 14
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(443, 159)
        Me.lblVisitDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(81, 25)
        Me.lblVisitDate.TabIndex = 13
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(540, 182)
        Me.stbJoinDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(198, 22)
        Me.stbJoinDate.TabIndex = 16
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(443, 183)
        Me.lblJoinDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(81, 25)
        Me.lblJoinDate.TabIndex = 15
        Me.lblJoinDate.Text = "Join Date"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(540, 5)
        Me.spbPhoto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(133, 123)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 59
        Me.spbPhoto.TabStop = False
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(443, 44)
        Me.lblPhoto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(81, 25)
        Me.lblPhoto.TabIndex = 26
        Me.lblPhoto.Text = "Photo"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(192, 111)
        Me.stbPatientNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(235, 22)
        Me.stbPatientNo.TabIndex = 6
        '
        'lblHospitalPID
        '
        Me.lblHospitalPID.Location = New System.Drawing.Point(24, 112)
        Me.lblHospitalPID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHospitalPID.Name = "lblHospitalPID"
        Me.lblHospitalPID.Size = New System.Drawing.Size(149, 25)
        Me.lblHospitalPID.TabIndex = 5
        Me.lblHospitalPID.Text = "Patient No"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(192, 162)
        Me.stbAge.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(235, 22)
        Me.stbAge.TabIndex = 10
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(540, 130)
        Me.stbGender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(198, 22)
        Me.stbGender.TabIndex = 12
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(24, 164)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(149, 25)
        Me.lblAge.TabIndex = 9
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(443, 135)
        Me.lblGenderID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(81, 25)
        Me.lblGenderID.TabIndex = 11
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(192, 137)
        Me.stbFullName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(235, 22)
        Me.stbFullName.TabIndex = 8
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(24, 140)
        Me.lblName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(149, 25)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Patient's Name"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(369, 80)
        Me.btnLoadPeriodicVisits.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(59, 30)
        Me.btnLoadPeriodicVisits.TabIndex = 4
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(148, 81)
        Me.btnFindVisitNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(36, 26)
        Me.btnFindVisitNo.TabIndex = 2
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.chkHideSelfRequest)
        Me.pnlAlerts.Controls.Add(Me.btnPendingVisitTriage)
        Me.pnlAlerts.Controls.Add(Me.lblAlertMessage)
        Me.pnlAlerts.Location = New System.Drawing.Point(16, 5)
        Me.pnlAlerts.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(419, 73)
        Me.pnlAlerts.TabIndex = 0
        '
        'chkHideSelfRequest
        '
        Me.chkHideSelfRequest.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkHideSelfRequest.Checked = True
        Me.chkHideSelfRequest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideSelfRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHideSelfRequest.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkHideSelfRequest.Location = New System.Drawing.Point(8, 39)
        Me.chkHideSelfRequest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkHideSelfRequest.Name = "chkHideSelfRequest"
        Me.chkHideSelfRequest.Size = New System.Drawing.Size(320, 25)
        Me.chkHideSelfRequest.TabIndex = 2
        Me.chkHideSelfRequest.Text = "Hide Self Request (s)"
        '
        'btnPendingVisitTriage
        '
        Me.btnPendingVisitTriage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingVisitTriage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingVisitTriage.Location = New System.Drawing.Point(312, 6)
        Me.btnPendingVisitTriage.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPendingVisitTriage.Name = "btnPendingVisitTriage"
        Me.btnPendingVisitTriage.Size = New System.Drawing.Size(100, 30)
        Me.btnPendingVisitTriage.TabIndex = 1
        Me.btnPendingVisitTriage.Tag = ""
        Me.btnPendingVisitTriage.Text = "&View List"
        '
        'lblAlertMessage
        '
        Me.lblAlertMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertMessage.ForeColor = System.Drawing.Color.Red
        Me.lblAlertMessage.Location = New System.Drawing.Point(8, 9)
        Me.lblAlertMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAlertMessage.Name = "lblAlertMessage"
        Me.lblAlertMessage.Size = New System.Drawing.Size(296, 25)
        Me.lblAlertMessage.TabIndex = 0
        Me.lblAlertMessage.Text = "Visit(s) to Vision : 0"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'lblEyeTest
        '
        Me.lblEyeTest.Location = New System.Drawing.Point(24, 190)
        Me.lblEyeTest.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEyeTest.Name = "lblEyeTest"
        Me.lblEyeTest.Size = New System.Drawing.Size(149, 25)
        Me.lblEyeTest.TabIndex = 11
        Me.lblEyeTest.Text = "Eye Test"
        '
        'lblleft
        '
        Me.lblleft.Location = New System.Drawing.Point(501, 222)
        Me.lblleft.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblleft.Name = "lblleft"
        Me.lblleft.Size = New System.Drawing.Size(236, 25)
        Me.lblleft.TabIndex = 18
        Me.lblleft.Text = "Left"
        Me.lblleft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRight
        '
        Me.lblRight.Location = New System.Drawing.Point(192, 222)
        Me.lblRight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRight.Name = "lblRight"
        Me.lblRight.Size = New System.Drawing.Size(236, 25)
        Me.lblRight.TabIndex = 17
        Me.lblRight.Text = "Right"
        Me.lblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmVisionAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(768, 489)
        Me.Controls.Add(Me.lblleft)
        Me.Controls.Add(Me.lblRight)
        Me.Controls.Add(Me.cboEyeTestID)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.lblEyeTest)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.cboPreferentialLookingLeftID)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.lblPreferentialLooking)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.cboPreferentialLookingRightID)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.cboVisualAcuityLeftExtID)
        Me.Controls.Add(Me.lblHospitalPID)
        Me.Controls.Add(Me.cboVisualAcuityLeftID)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblVisualAcuityRightExtID)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.cboVisualAcuityRightExtID)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblVisualAcuityRightID)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.cboVisualAcuityRightID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmVisionAssessment"
        Me.Tag = ""
        Me.Text = "Vision Assessment"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlerts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
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
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHospitalPID As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents chkHideSelfRequest As System.Windows.Forms.CheckBox
    Friend WithEvents btnPendingVisitTriage As System.Windows.Forms.Button
    Friend WithEvents lblAlertMessage As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents cboEyeTestID As System.Windows.Forms.ComboBox
    Friend WithEvents lblEyeTest As System.Windows.Forms.Label
    Friend WithEvents lblleft As System.Windows.Forms.Label
    Friend WithEvents lblRight As System.Windows.Forms.Label

End Class