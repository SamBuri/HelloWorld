
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAccessedCashServices : Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccessedCashServices))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAuthorisedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAuthorisationReason = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpToVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToVisitDate = New System.Windows.Forms.Label()
        Me.lblAuthorisedBy = New System.Windows.Forms.Label()
        Me.lblAuthorisationReason = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblHospitalPID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 256)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(297, 256)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "AccessedCashServices"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 283)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "AccessedCashServices"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAuthorisedBy
        '
        Me.stbAuthorisedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAuthorisedBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAuthorisedBy, "AuthorisedBy")
        Me.stbAuthorisedBy.EntryErrorMSG = ""
        Me.stbAuthorisedBy.Location = New System.Drawing.Point(198, 181)
        Me.stbAuthorisedBy.Multiline = True
        Me.stbAuthorisedBy.Name = "stbAuthorisedBy"
        Me.stbAuthorisedBy.RegularExpression = ""
        Me.stbAuthorisedBy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAuthorisedBy.Size = New System.Drawing.Size(170, 48)
        Me.stbAuthorisedBy.TabIndex = 8
        '
        'cboAuthorisationReason
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAuthorisationReason, "AuthorisationReasonDesc,AuthorisationReason")
        Me.cboAuthorisationReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuthorisationReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAuthorisationReason.Location = New System.Drawing.Point(198, 231)
        Me.cboAuthorisationReason.Name = "cboAuthorisationReason"
        Me.cboAuthorisationReason.Size = New System.Drawing.Size(170, 21)
        Me.cboAuthorisationReason.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(297, 283)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(198, 34)
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 4
        '
        'dtpToVisitDate
        '
        Me.dtpToVisitDate.Enabled = False
        Me.dtpToVisitDate.Location = New System.Drawing.Point(198, 160)
        Me.dtpToVisitDate.Name = "dtpToVisitDate"
        Me.dtpToVisitDate.ShowCheckBox = True
        Me.dtpToVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpToVisitDate.TabIndex = 6
        '
        'lblToVisitDate
        '
        Me.lblToVisitDate.Location = New System.Drawing.Point(18, 158)
        Me.lblToVisitDate.Name = "lblToVisitDate"
        Me.lblToVisitDate.Size = New System.Drawing.Size(150, 20)
        Me.lblToVisitDate.TabIndex = 7
        Me.lblToVisitDate.Text = "Authorisation Date"
        '
        'lblAuthorisedBy
        '
        Me.lblAuthorisedBy.Location = New System.Drawing.Point(18, 179)
        Me.lblAuthorisedBy.Name = "lblAuthorisedBy"
        Me.lblAuthorisedBy.Size = New System.Drawing.Size(150, 20)
        Me.lblAuthorisedBy.TabIndex = 9
        Me.lblAuthorisedBy.Text = "Authorised By"
        '
        'lblAuthorisationReason
        '
        Me.lblAuthorisationReason.Location = New System.Drawing.Point(18, 229)
        Me.lblAuthorisationReason.Name = "lblAuthorisationReason"
        Me.lblAuthorisationReason.Size = New System.Drawing.Size(150, 20)
        Me.lblAuthorisationReason.TabIndex = 11
        Me.lblAuthorisationReason.Text = "Authorisation Reason"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(198, 76)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(120, 20)
        Me.stbGender.TabIndex = 16
        '
        'lblGender
        '
        Me.lblGender.Location = New System.Drawing.Point(18, 74)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(150, 20)
        Me.lblGender.TabIndex = 15
        Me.lblGender.Text = "Gender"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(198, 97)
        Me.stbAge.MaxLength = 20
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.Size = New System.Drawing.Size(120, 20)
        Me.stbAge.TabIndex = 18
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(18, 96)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(150, 20)
        Me.lblAge.TabIndex = 17
        Me.lblAge.Text = "Age"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(198, 139)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(171, 20)
        Me.stbLastVisitDate.TabIndex = 22
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(18, 137)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(150, 20)
        Me.lblLastVisitDate.TabIndex = 21
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(198, 118)
        Me.stbJoinDate.MaxLength = 20
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.Size = New System.Drawing.Size(171, 20)
        Me.stbJoinDate.TabIndex = 20
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(18, 117)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(150, 20)
        Me.lblJoinDate.TabIndex = 19
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(198, 55)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(171, 20)
        Me.stbFullName.TabIndex = 14
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(18, 54)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(150, 20)
        Me.lblFullName.TabIndex = 13
        Me.lblFullName.Text = "Patient's Name"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(163, 11)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 24
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(329, 7)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 26
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(198, 13)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(127, 20)
        Me.stbVisitNo.TabIndex = 25
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(18, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(79, 20)
        Me.lblVisitNo.TabIndex = 23
        Me.lblVisitNo.Text = "VisitNo"
        '
        'lblHospitalPID
        '
        Me.lblHospitalPID.Location = New System.Drawing.Point(18, 33)
        Me.lblHospitalPID.Name = "lblHospitalPID"
        Me.lblHospitalPID.Size = New System.Drawing.Size(112, 20)
        Me.lblHospitalPID.TabIndex = 27
        Me.lblHospitalPID.Text = "Patient No"
        '
        'frmAccessedCashServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(381, 311)
        Me.Controls.Add(Me.lblHospitalPID)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.dtpToVisitDate)
        Me.Controls.Add(Me.lblToVisitDate)
        Me.Controls.Add(Me.stbAuthorisedBy)
        Me.Controls.Add(Me.lblAuthorisedBy)
        Me.Controls.Add(Me.cboAuthorisationReason)
        Me.Controls.Add(Me.lblAuthorisationReason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAccessedCashServices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Accessed Cash Services"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dtpToVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblToVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbAuthorisedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAuthorisedBy As System.Windows.Forms.Label
    Friend WithEvents cboAuthorisationReason As System.Windows.Forms.ComboBox
    Friend WithEvents lblAuthorisationReason As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGender As Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents btnFindVisitNo As Button
    Friend WithEvents btnLoadPeriodicVisits As Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As Label
    Friend WithEvents lblHospitalPID As Label
End Class