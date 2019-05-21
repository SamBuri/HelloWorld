
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTBIntensifiedCaseFinding : Inherits System.Windows.Forms.Form


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTBIntensifiedCaseFinding))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCaseNo = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblHospitalPID = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblPulmonaryTBChronicCoughContactID = New System.Windows.Forms.Label()
        Me.cboPulmonaryTBChronicCoughContactID = New System.Windows.Forms.ComboBox()
        Me.lblPoorWeightGainID = New System.Windows.Forms.Label()
        Me.cboPoorWeightGainID = New System.Windows.Forms.ComboBox()
        Me.lblExcessiveNightSweatsID = New System.Windows.Forms.Label()
        Me.cboExcessiveNightSweatsID = New System.Windows.Forms.ComboBox()
        Me.lblNoticableWeightLossID = New System.Windows.Forms.Label()
        Me.cboNoticableWeightLossID = New System.Windows.Forms.ComboBox()
        Me.lblPersistantFeversID = New System.Windows.Forms.Label()
        Me.cboPersistantFeversID = New System.Windows.Forms.ComboBox()
        Me.lblCoughingTwoWeeksMoreID = New System.Windows.Forms.Label()
        Me.cboCoughingTwoWeeksMoreID = New System.Windows.Forms.ComboBox()
        Me.gbTbIntensifiedCaseFinding = New System.Windows.Forms.GroupBox()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbTbIntensifiedCaseFinding.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 342)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 16
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(543, 343)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 18
        Me.fbnDelete.Tag = "TBIntensifiedCaseFinding"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 369)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 17
        Me.ebnSaveUpdate.Tag = "TBIntensifiedCaseFinding"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(472, 7)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(137, 130)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 80
        Me.spbPhoto.TabStop = False
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(128, 54)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 5
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(128, 96)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 9
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(128, 117)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 11
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(128, 75)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(44, 20)
        Me.stbAge.TabIndex = 7
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(543, 369)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 19
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(128, 9)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitNo.TabIndex = 1
        '
        'lblCaseNo
        '
        Me.lblCaseNo.Location = New System.Drawing.Point(14, 7)
        Me.lblCaseNo.Name = "lblCaseNo"
        Me.lblCaseNo.Size = New System.Drawing.Size(108, 21)
        Me.lblCaseNo.TabIndex = 0
        Me.lblCaseNo.Text = "Visit No"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(391, 11)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(58, 20)
        Me.lblPhoto.TabIndex = 14
        Me.lblPhoto.Text = "Photo"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(14, 59)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(108, 20)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Patient's Name"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(14, 101)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(108, 20)
        Me.lblGenderID.TabIndex = 8
        Me.lblGenderID.Text = "Gender"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(14, 80)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 6
        Me.lblAge.Text = "Age"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(14, 122)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(108, 20)
        Me.lblJoinDate.TabIndex = 10
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(128, 32)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 3
        '
        'lblHospitalPID
        '
        Me.lblHospitalPID.Location = New System.Drawing.Point(14, 35)
        Me.lblHospitalPID.Name = "lblHospitalPID"
        Me.lblHospitalPID.Size = New System.Drawing.Size(108, 20)
        Me.lblHospitalPID.TabIndex = 2
        Me.lblHospitalPID.Text = "Patient No"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(128, 139)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitDate.TabIndex = 13
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(14, 142)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 12
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblPulmonaryTBChronicCoughContactID
        '
        Me.lblPulmonaryTBChronicCoughContactID.Location = New System.Drawing.Point(2, 132)
        Me.lblPulmonaryTBChronicCoughContactID.Name = "lblPulmonaryTBChronicCoughContactID"
        Me.lblPulmonaryTBChronicCoughContactID.Size = New System.Drawing.Size(426, 20)
        Me.lblPulmonaryTBChronicCoughContactID.TabIndex = 10
        Me.lblPulmonaryTBChronicCoughContactID.Text = "6. Has the child had contact with a person with Pulmonary TB/Chronic Cough"
        '
        'cboPulmonaryTBChronicCoughContactID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPulmonaryTBChronicCoughContactID, "PulmonaryTBChronicCoughContact,PulmonaryTBChronicCoughContactID")
        Me.cboPulmonaryTBChronicCoughContactID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPulmonaryTBChronicCoughContactID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPulmonaryTBChronicCoughContactID.Location = New System.Drawing.Point(434, 131)
        Me.cboPulmonaryTBChronicCoughContactID.Name = "cboPulmonaryTBChronicCoughContactID"
        Me.cboPulmonaryTBChronicCoughContactID.Size = New System.Drawing.Size(170, 21)
        Me.cboPulmonaryTBChronicCoughContactID.TabIndex = 11
        '
        'lblPoorWeightGainID
        '
        Me.lblPoorWeightGainID.Location = New System.Drawing.Point(2, 109)
        Me.lblPoorWeightGainID.Name = "lblPoorWeightGainID"
        Me.lblPoorWeightGainID.Size = New System.Drawing.Size(426, 20)
        Me.lblPoorWeightGainID.TabIndex = 8
        Me.lblPoorWeightGainID.Text = "5. Has the Child had poor weight gain in the last 1 month ? (Child < 5yrs)"
        '
        'cboPoorWeightGainID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPoorWeightGainID, "PoorWeightGain,PoorWeightGainID")
        Me.cboPoorWeightGainID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPoorWeightGainID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPoorWeightGainID.Location = New System.Drawing.Point(434, 108)
        Me.cboPoorWeightGainID.Name = "cboPoorWeightGainID"
        Me.cboPoorWeightGainID.Size = New System.Drawing.Size(170, 21)
        Me.cboPoorWeightGainID.TabIndex = 9
        '
        'lblExcessiveNightSweatsID
        '
        Me.lblExcessiveNightSweatsID.Location = New System.Drawing.Point(2, 86)
        Me.lblExcessiveNightSweatsID.Name = "lblExcessiveNightSweatsID"
        Me.lblExcessiveNightSweatsID.Size = New System.Drawing.Size(426, 20)
        Me.lblExcessiveNightSweatsID.TabIndex = 6
        Me.lblExcessiveNightSweatsID.Text = "4. Has Patient had excessive night sweats for 3 Weeks or more ? ( for Adults)"
        '
        'cboExcessiveNightSweatsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboExcessiveNightSweatsID, "ExcessiveNightSweats,ExcessiveNightSweatsID")
        Me.cboExcessiveNightSweatsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExcessiveNightSweatsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExcessiveNightSweatsID.Location = New System.Drawing.Point(434, 85)
        Me.cboExcessiveNightSweatsID.Name = "cboExcessiveNightSweatsID"
        Me.cboExcessiveNightSweatsID.Size = New System.Drawing.Size(170, 21)
        Me.cboExcessiveNightSweatsID.TabIndex = 7
        '
        'lblNoticableWeightLossID
        '
        Me.lblNoticableWeightLossID.Location = New System.Drawing.Point(2, 63)
        Me.lblNoticableWeightLossID.Name = "lblNoticableWeightLossID"
        Me.lblNoticableWeightLossID.Size = New System.Drawing.Size(426, 20)
        Me.lblNoticableWeightLossID.TabIndex = 4
        Me.lblNoticableWeightLossID.Text = "3. Has Patient had noticable weight loss (more than 3kg) ? "
        '
        'cboNoticableWeightLossID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboNoticableWeightLossID, "NoticableWeightLoss,NoticableWeightLossID")
        Me.cboNoticableWeightLossID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoticableWeightLossID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboNoticableWeightLossID.Location = New System.Drawing.Point(434, 62)
        Me.cboNoticableWeightLossID.Name = "cboNoticableWeightLossID"
        Me.cboNoticableWeightLossID.Size = New System.Drawing.Size(170, 21)
        Me.cboNoticableWeightLossID.TabIndex = 5
        '
        'lblPersistantFeversID
        '
        Me.lblPersistantFeversID.Location = New System.Drawing.Point(2, 40)
        Me.lblPersistantFeversID.Name = "lblPersistantFeversID"
        Me.lblPersistantFeversID.Size = New System.Drawing.Size(426, 20)
        Me.lblPersistantFeversID.TabIndex = 2
        Me.lblPersistantFeversID.Text = "2. Has patient had persistant fevers for 2 Weeks Or More ?"
        '
        'cboPersistantFeversID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPersistantFeversID, "PersistantFevers,PersistantFeversID")
        Me.cboPersistantFeversID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPersistantFeversID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPersistantFeversID.Location = New System.Drawing.Point(434, 39)
        Me.cboPersistantFeversID.Name = "cboPersistantFeversID"
        Me.cboPersistantFeversID.Size = New System.Drawing.Size(170, 21)
        Me.cboPersistantFeversID.TabIndex = 3
        '
        'lblCoughingTwoWeeksMoreID
        '
        Me.lblCoughingTwoWeeksMoreID.Location = New System.Drawing.Point(2, 17)
        Me.lblCoughingTwoWeeksMoreID.Name = "lblCoughingTwoWeeksMoreID"
        Me.lblCoughingTwoWeeksMoreID.Size = New System.Drawing.Size(426, 20)
        Me.lblCoughingTwoWeeksMoreID.TabIndex = 0
        Me.lblCoughingTwoWeeksMoreID.Text = "1. Has patient been coughing for 2 Weeks Or More ?"
        '
        'cboCoughingTwoWeeksMoreID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoughingTwoWeeksMoreID, "CoughingTwoWeeksMore,CoughingTwoWeeksMoreID")
        Me.cboCoughingTwoWeeksMoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoughingTwoWeeksMoreID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoughingTwoWeeksMoreID.Location = New System.Drawing.Point(434, 16)
        Me.cboCoughingTwoWeeksMoreID.Name = "cboCoughingTwoWeeksMoreID"
        Me.cboCoughingTwoWeeksMoreID.Size = New System.Drawing.Size(170, 21)
        Me.cboCoughingTwoWeeksMoreID.TabIndex = 1
        '
        'gbTbIntensifiedCaseFinding
        '
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboCoughingTwoWeeksMoreID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblCoughingTwoWeeksMoreID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboPersistantFeversID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblPersistantFeversID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboNoticableWeightLossID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblNoticableWeightLossID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboExcessiveNightSweatsID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblExcessiveNightSweatsID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboPoorWeightGainID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblPoorWeightGainID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.cboPulmonaryTBChronicCoughContactID)
        Me.gbTbIntensifiedCaseFinding.Controls.Add(Me.lblPulmonaryTBChronicCoughContactID)
        Me.gbTbIntensifiedCaseFinding.Location = New System.Drawing.Point(8, 166)
        Me.gbTbIntensifiedCaseFinding.Name = "gbTbIntensifiedCaseFinding"
        Me.gbTbIntensifiedCaseFinding.Size = New System.Drawing.Size(617, 168)
        Me.gbTbIntensifiedCaseFinding.TabIndex = 15
        Me.gbTbIntensifiedCaseFinding.TabStop = False
        '
        'frmTBIntensifiedCaseFinding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(632, 398)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblHospitalPID)
        Me.Controls.Add(Me.gbTbIntensifiedCaseFinding)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblCaseNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.Name = "frmTBIntensifiedCaseFinding"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TB Intensified Case Finding"
        CType(Me.spbPhoto,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbTbIntensifiedCaseFinding.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCaseNo As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHospitalPID As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblPulmonaryTBChronicCoughContactID As System.Windows.Forms.Label
    Friend WithEvents cboPulmonaryTBChronicCoughContactID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPoorWeightGainID As System.Windows.Forms.Label
    Friend WithEvents cboPoorWeightGainID As System.Windows.Forms.ComboBox
    Friend WithEvents lblExcessiveNightSweatsID As System.Windows.Forms.Label
    Friend WithEvents cboExcessiveNightSweatsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoticableWeightLossID As System.Windows.Forms.Label
    Friend WithEvents cboNoticableWeightLossID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPersistantFeversID As System.Windows.Forms.Label
    Friend WithEvents cboPersistantFeversID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoughingTwoWeeksMoreID As System.Windows.Forms.Label
    Friend WithEvents cboCoughingTwoWeeksMoreID As System.Windows.Forms.ComboBox
    Friend WithEvents gbTbIntensifiedCaseFinding As System.Windows.Forms.GroupBox

End Class