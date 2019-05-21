
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImmunisationVaccines : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String)
        MyClass.New()
        Me.defaultPatientNo = keyNo

    End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImmunisationVaccines))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMothersName = New System.Windows.Forms.TextBox()
        Me.stbImmunisationNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.tbcImmunisation = New System.Windows.Forms.TabControl()
        Me.tpgVaccines = New System.Windows.Forms.TabPage()
        Me.dgvImmunisationVaccines = New System.Windows.Forms.DataGridView()
        Me.colVaccineName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colVaccineReceived = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDateGiven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPlaceReceived = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colImmunisationNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colImmunisationSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgImmunisationHistory = New System.Windows.Forms.TabPage()
        Me.dgvImmunisationHistory = New System.Windows.Forms.DataGridView()
        Me.colHistoryVaccineName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHistoryDateGiven = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColHistoryPlaceReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMothersName = New System.Windows.Forms.Label()
        Me.lblImmunisationNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcImmunisation.SuspendLayout()
        Me.tpgVaccines.SuspendLayout()
        CType(Me.dgvImmunisationVaccines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgImmunisationHistory.SuspendLayout()
        CType(Me.dgvImmunisationHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 295)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(72, 24)
        Me.fbnSearch.TabIndex = 21
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(659, 294)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 22
        Me.fbnDelete.Tag = "ImmunisationVaccines"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 322)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(72, 24)
        Me.ebnSaveUpdate.TabIndex = 23
        Me.ebnSaveUpdate.Tag = "ImmunisationVaccines"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(157, 6)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(124, 20)
        Me.stbPatientNo.TabIndex = 1
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(157, 91)
        Me.nbxAge.MaxValue = 0.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.MustEnterNumeric = True
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(178, 20)
        Me.nbxAge.TabIndex = 10
        Me.nbxAge.Value = ""
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(157, 70)
        Me.stbLocation.MaxLength = 40
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(178, 20)
        Me.stbLocation.TabIndex = 8
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(453, 50)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(175, 20)
        Me.stbLastVisitDate.TabIndex = 16
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(634, 6)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(90, 87)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 118
        Me.spbPhoto.TabStop = False
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(157, 49)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(178, 20)
        Me.stbFullName.TabIndex = 6
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(452, 6)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(176, 20)
        Me.stbGender.TabIndex = 12
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(453, 28)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(175, 20)
        Me.stbJoinDate.TabIndex = 14
        '
        'stbMothersName
        '
        Me.stbMothersName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMothersName.Location = New System.Drawing.Point(453, 71)
        Me.stbMothersName.MaxLength = 60
        Me.stbMothersName.Name = "stbMothersName"
        Me.stbMothersName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMothersName.Size = New System.Drawing.Size(175, 20)
        Me.stbMothersName.TabIndex = 18
        '
        'stbImmunisationNo
        '
        Me.stbImmunisationNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbImmunisationNo.CapitalizeFirstLetter = False
        Me.stbImmunisationNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbImmunisationNo.EntryErrorMSG = ""
        Me.stbImmunisationNo.Location = New System.Drawing.Point(157, 28)
        Me.stbImmunisationNo.MaxLength = 20
        Me.stbImmunisationNo.Name = "stbImmunisationNo"
        Me.stbImmunisationNo.RegularExpression = ""
        Me.stbImmunisationNo.Size = New System.Drawing.Size(178, 20)
        Me.stbImmunisationNo.TabIndex = 4
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(659, 321)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 24
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(19, 96)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(102, 20)
        Me.lblAge.TabIndex = 9
        Me.lblAge.Text = "Age"
        '
        'lblLocation
        '
        Me.lblLocation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLocation.Location = New System.Drawing.Point(19, 73)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(102, 20)
        Me.lblLocation.TabIndex = 7
        Me.lblLocation.Text = "Location/Address"
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(355, 52)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(83, 17)
        Me.lblLastVisitDate.TabIndex = 15
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(643, 100)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(63, 20)
        Me.lblPhoto.TabIndex = 19
        Me.lblPhoto.Text = "Photo"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(19, 54)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(102, 20)
        Me.lblName.TabIndex = 5
        Me.lblName.Text = "Patient's Name"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(354, 8)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(83, 20)
        Me.lblGenderID.TabIndex = 11
        Me.lblGenderID.Text = "Gender"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(355, 31)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(83, 20)
        Me.lblJoinDate.TabIndex = 13
        Me.lblJoinDate.Text = "Join Date"
        '
        'tbcImmunisation
        '
        Me.tbcImmunisation.Controls.Add(Me.tpgVaccines)
        Me.tbcImmunisation.Controls.Add(Me.tpgImmunisationHistory)
        Me.tbcImmunisation.Location = New System.Drawing.Point(12, 123)
        Me.tbcImmunisation.Name = "tbcImmunisation"
        Me.tbcImmunisation.SelectedIndex = 0
        Me.tbcImmunisation.Size = New System.Drawing.Size(719, 165)
        Me.tbcImmunisation.TabIndex = 20
        '
        'tpgVaccines
        '
        Me.tpgVaccines.Controls.Add(Me.dgvImmunisationVaccines)
        Me.tpgVaccines.Location = New System.Drawing.Point(4, 22)
        Me.tpgVaccines.Name = "tpgVaccines"
        Me.tpgVaccines.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgVaccines.Size = New System.Drawing.Size(711, 139)
        Me.tpgVaccines.TabIndex = 0
        Me.tpgVaccines.Text = "Vaccines"
        Me.tpgVaccines.UseVisualStyleBackColor = True
        '
        'dgvImmunisationVaccines
        '
        Me.dgvImmunisationVaccines.AllowUserToOrderColumns = True
        Me.dgvImmunisationVaccines.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImmunisationVaccines.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImmunisationVaccines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVaccineName, Me.colVaccineReceived, Me.colDateGiven, Me.colPlaceReceived, Me.colImmunisationNotes, Me.colImmunisationSaved})
        Me.dgvImmunisationVaccines.EnableHeadersVisualStyles = False
        Me.dgvImmunisationVaccines.GridColor = System.Drawing.Color.Khaki
        Me.dgvImmunisationVaccines.Location = New System.Drawing.Point(3, 3)
        Me.dgvImmunisationVaccines.Name = "dgvImmunisationVaccines"
        Me.dgvImmunisationVaccines.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImmunisationVaccines.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvImmunisationVaccines.Size = New System.Drawing.Size(705, 138)
        Me.dgvImmunisationVaccines.TabIndex = 0
        Me.dgvImmunisationVaccines.Text = "DataGridView1"
        '
        'colVaccineName
        '
        Me.colVaccineName.DataPropertyName = "VaccineName"
        Me.colVaccineName.DisplayStyleForCurrentCellOnly = True
        Me.colVaccineName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colVaccineName.HeaderText = "Vaccine Name"
        Me.colVaccineName.Name = "colVaccineName"
        Me.colVaccineName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVaccineName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colVaccineName.Width = 180
        '
        'colVaccineReceived
        '
        Me.colVaccineReceived.DisplayStyleForCurrentCellOnly = True
        Me.colVaccineReceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colVaccineReceived.HeaderText = "Received"
        Me.colVaccineReceived.Name = "colVaccineReceived"
        Me.colVaccineReceived.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colVaccineReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colVaccineReceived.Width = 80
        '
        'colDateGiven
        '
        Me.colDateGiven.HeaderText = "DateGiven"
        Me.colDateGiven.Name = "colDateGiven"
        '
        'colPlaceReceived
        '
        Me.colPlaceReceived.DataPropertyName = "PlaceReceivedID"
        Me.colPlaceReceived.DisplayStyleForCurrentCellOnly = True
        Me.colPlaceReceived.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPlaceReceived.HeaderText = "Place Received"
        Me.colPlaceReceived.Name = "colPlaceReceived"
        Me.colPlaceReceived.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPlaceReceived.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colImmunisationNotes
        '
        Me.colImmunisationNotes.HeaderText = "Notes"
        Me.colImmunisationNotes.Name = "colImmunisationNotes"
        Me.colImmunisationNotes.Width = 150
        '
        'colImmunisationSaved
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colImmunisationSaved.DefaultCellStyle = DataGridViewCellStyle2
        Me.colImmunisationSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colImmunisationSaved.HeaderText = "Saved"
        Me.colImmunisationSaved.Name = "colImmunisationSaved"
        Me.colImmunisationSaved.ReadOnly = True
        Me.colImmunisationSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colImmunisationSaved.Width = 50
        '
        'tpgImmunisationHistory
        '
        Me.tpgImmunisationHistory.Controls.Add(Me.dgvImmunisationHistory)
        Me.tpgImmunisationHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgImmunisationHistory.Name = "tpgImmunisationHistory"
        Me.tpgImmunisationHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgImmunisationHistory.Size = New System.Drawing.Size(711, 139)
        Me.tpgImmunisationHistory.TabIndex = 1
        Me.tpgImmunisationHistory.Text = "Immunisation History"
        Me.tpgImmunisationHistory.UseVisualStyleBackColor = True
        '
        'dgvImmunisationHistory
        '
        Me.dgvImmunisationHistory.AllowUserToAddRows = False
        Me.dgvImmunisationHistory.AllowUserToDeleteRows = False
        Me.dgvImmunisationHistory.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvImmunisationHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvImmunisationHistory.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvImmunisationHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvImmunisationHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvImmunisationHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImmunisationHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvImmunisationHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colHistoryVaccineName, Me.ColHistoryDateGiven, Me.ColHistoryPlaceReceived})
        Me.dgvImmunisationHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvImmunisationHistory.EnableHeadersVisualStyles = False
        Me.dgvImmunisationHistory.GridColor = System.Drawing.Color.Khaki
        Me.dgvImmunisationHistory.Location = New System.Drawing.Point(3, 3)
        Me.dgvImmunisationHistory.Name = "dgvImmunisationHistory"
        Me.dgvImmunisationHistory.ReadOnly = True
        Me.dgvImmunisationHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImmunisationHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvImmunisationHistory.RowHeadersVisible = False
        Me.dgvImmunisationHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvImmunisationHistory.Size = New System.Drawing.Size(705, 133)
        Me.dgvImmunisationHistory.TabIndex = 4
        Me.dgvImmunisationHistory.Text = "DataGridView2"
        '
        'colHistoryVaccineName
        '
        Me.colHistoryVaccineName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colHistoryVaccineName.DataPropertyName = "VaccineNameID"
        Me.colHistoryVaccineName.HeaderText = "Vaccine Name"
        Me.colHistoryVaccineName.Name = "colHistoryVaccineName"
        Me.colHistoryVaccineName.ReadOnly = True
        '
        'ColHistoryDateGiven
        '
        Me.ColHistoryDateGiven.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColHistoryDateGiven.DataPropertyName = "DateGiven"
        Me.ColHistoryDateGiven.HeaderText = "Date Given"
        Me.ColHistoryDateGiven.Name = "ColHistoryDateGiven"
        Me.ColHistoryDateGiven.ReadOnly = True
        '
        'ColHistoryPlaceReceived
        '
        Me.ColHistoryPlaceReceived.DataPropertyName = "PlaceReceivedID"
        Me.ColHistoryPlaceReceived.HeaderText = "Place Received"
        Me.ColHistoryPlaceReceived.Name = "ColHistoryPlaceReceived"
        Me.ColHistoryPlaceReceived.ReadOnly = True
        '
        'lblMothersName
        '
        Me.lblMothersName.Location = New System.Drawing.Point(355, 73)
        Me.lblMothersName.Name = "lblMothersName"
        Me.lblMothersName.Size = New System.Drawing.Size(83, 20)
        Me.lblMothersName.TabIndex = 17
        Me.lblMothersName.Text = "Mother's Name"
        '
        'lblImmunisationNo
        '
        Me.lblImmunisationNo.Location = New System.Drawing.Point(19, 33)
        Me.lblImmunisationNo.Name = "lblImmunisationNo"
        Me.lblImmunisationNo.Size = New System.Drawing.Size(102, 20)
        Me.lblImmunisationNo.TabIndex = 3
        Me.lblImmunisationNo.Text = "Immunisation No"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(282, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(52, 24)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(20, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Patient No"
        '
        'frmImmunisationVaccines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(743, 364)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbImmunisationNo)
        Me.Controls.Add(Me.lblImmunisationNo)
        Me.Controls.Add(Me.stbMothersName)
        Me.Controls.Add(Me.lblMothersName)
        Me.Controls.Add(Me.tbcImmunisation)
        Me.Controls.Add(Me.nbxAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.Name = "frmImmunisationVaccines"
        Me.Text = "Immunisation"
        CType(Me.spbPhoto,System.ComponentModel.ISupportInitialize).EndInit
        Me.tbcImmunisation.ResumeLayout(false)
        Me.tpgVaccines.ResumeLayout(false)
        CType(Me.dgvImmunisationVaccines,System.ComponentModel.ISupportInitialize).EndInit
        Me.tpgImmunisationHistory.ResumeLayout(false)
        CType(Me.dgvImmunisationHistory,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tbcImmunisation As System.Windows.Forms.TabControl
    Friend WithEvents tpgVaccines As System.Windows.Forms.TabPage
    Friend WithEvents tpgImmunisationHistory As System.Windows.Forms.TabPage
    Friend WithEvents dgvImmunisationHistory As System.Windows.Forms.DataGridView
    Friend WithEvents stbMothersName As System.Windows.Forms.TextBox
    Friend WithEvents lblMothersName As System.Windows.Forms.Label
    Friend WithEvents lblImmunisationNo As System.Windows.Forms.Label
    Friend WithEvents stbImmunisationNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colHistoryVaccineName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHistoryDateGiven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColHistoryPlaceReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents dgvImmunisationVaccines As System.Windows.Forms.DataGridView
    Friend WithEvents colVaccineName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colVaccineReceived As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDateGiven As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPlaceReceived As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colImmunisationNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colImmunisationSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class