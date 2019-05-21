
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInwardFiles : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInwardFiles))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpReturnDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFileNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTakenDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbOutwardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOutwardNo = New System.Windows.Forms.Label()
        Me.lblReturnDateTime = New System.Windows.Forms.Label()
        Me.lblReturnedBy = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblFileNo = New System.Windows.Forms.Label()
        Me.btnFindOutwardNo = New System.Windows.Forms.Button()
        Me.lblTakenDateTime = New System.Windows.Forms.Label()
        Me.cboReturnedBy = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 218)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 21
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(248, 218)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 22
        Me.fbnDelete.Tag = "InwardFiles"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 245)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 23
        Me.ebnSaveUpdate.Tag = "InwardFiles"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpReturnDateTime
        '
        Me.dtpReturnDateTime.Checked = False
        Me.dtpReturnDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReturnDateTime, "ReturnDateTime")
        Me.dtpReturnDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReturnDateTime.Location = New System.Drawing.Point(142, 172)
        Me.dtpReturnDateTime.Name = "dtpReturnDateTime"
        Me.dtpReturnDateTime.ShowCheckBox = True
        Me.dtpReturnDateTime.Size = New System.Drawing.Size(178, 20)
        Me.dtpReturnDateTime.TabIndex = 18
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(142, 67)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(92, 20)
        Me.stbGender.TabIndex = 8
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(142, 88)
        Me.stbAge.MaxLength = 20
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.Size = New System.Drawing.Size(92, 20)
        Me.stbAge.TabIndex = 10
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastVisitDate, "LastVisitDate")
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(142, 130)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(178, 20)
        Me.stbLastVisitDate.TabIndex = 14
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(142, 109)
        Me.stbJoinDate.MaxLength = 20
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.Size = New System.Drawing.Size(178, 20)
        Me.stbJoinDate.TabIndex = 12
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(142, 46)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(178, 20)
        Me.stbFullName.TabIndex = 6
        '
        'stbFileNo
        '
        Me.stbFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFileNo.CapitalizeFirstLetter = False
        Me.stbFileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbFileNo, "FileNo")
        Me.stbFileNo.Enabled = False
        Me.stbFileNo.EntryErrorMSG = ""
        Me.stbFileNo.Location = New System.Drawing.Point(142, 25)
        Me.stbFileNo.MaxLength = 20
        Me.stbFileNo.Name = "stbFileNo"
        Me.stbFileNo.RegularExpression = ""
        Me.stbFileNo.Size = New System.Drawing.Size(178, 20)
        Me.stbFileNo.TabIndex = 4
        '
        'stbTakenDateTime
        '
        Me.stbTakenDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTakenDateTime.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTakenDateTime, "TakenDateTime")
        Me.stbTakenDateTime.Enabled = False
        Me.stbTakenDateTime.EntryErrorMSG = ""
        Me.stbTakenDateTime.Location = New System.Drawing.Point(142, 151)
        Me.stbTakenDateTime.MaxLength = 20
        Me.stbTakenDateTime.Name = "stbTakenDateTime"
        Me.stbTakenDateTime.RegularExpression = ""
        Me.stbTakenDateTime.Size = New System.Drawing.Size(178, 20)
        Me.stbTakenDateTime.TabIndex = 16
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(248, 245)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 24
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbOutwardNo
        '
        Me.stbOutwardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOutwardNo.CapitalizeFirstLetter = False
        Me.stbOutwardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbOutwardNo.EntryErrorMSG = ""
        Me.stbOutwardNo.Location = New System.Drawing.Point(142, 4)
        Me.stbOutwardNo.MaxLength = 20
        Me.stbOutwardNo.Name = "stbOutwardNo"
        Me.stbOutwardNo.RegularExpression = ""
        Me.stbOutwardNo.Size = New System.Drawing.Size(178, 20)
        Me.stbOutwardNo.TabIndex = 2
        '
        'lblOutwardNo
        '
        Me.lblOutwardNo.Location = New System.Drawing.Point(9, 4)
        Me.lblOutwardNo.Name = "lblOutwardNo"
        Me.lblOutwardNo.Size = New System.Drawing.Size(94, 20)
        Me.lblOutwardNo.TabIndex = 0
        Me.lblOutwardNo.Text = "Outward No"
        '
        'lblReturnDateTime
        '
        Me.lblReturnDateTime.Location = New System.Drawing.Point(9, 172)
        Me.lblReturnDateTime.Name = "lblReturnDateTime"
        Me.lblReturnDateTime.Size = New System.Drawing.Size(102, 20)
        Me.lblReturnDateTime.TabIndex = 17
        Me.lblReturnDateTime.Text = "Return Date Time"
        '
        'lblReturnedBy
        '
        Me.lblReturnedBy.Location = New System.Drawing.Point(9, 193)
        Me.lblReturnedBy.Name = "lblReturnedBy"
        Me.lblReturnedBy.Size = New System.Drawing.Size(102, 20)
        Me.lblReturnedBy.TabIndex = 19
        Me.lblReturnedBy.Text = "Returned By"
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
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = False
        Me.stbClientMachine.EntryErrorMSG = ""
        Me.stbClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.stbClientMachine.Name = "stbClientMachine"
        Me.stbClientMachine.RegularExpression = ""
        Me.stbClientMachine.Size = New System.Drawing.Size(100, 20)
        Me.stbClientMachine.TabIndex = 0
        '
        'lblClientMachine
        '
        Me.lblClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.lblClientMachine.Name = "lblClientMachine"
        Me.lblClientMachine.Size = New System.Drawing.Size(100, 23)
        Me.lblClientMachine.TabIndex = 0
        '
        'lblGender
        '
        Me.lblGender.Location = New System.Drawing.Point(9, 67)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(102, 20)
        Me.lblGender.TabIndex = 7
        Me.lblGender.Text = "Gender"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(9, 87)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(102, 20)
        Me.lblAge.TabIndex = 9
        Me.lblAge.Text = "Age"
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(9, 130)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(102, 20)
        Me.lblLastVisitDate.TabIndex = 13
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(9, 109)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(102, 20)
        Me.lblJoinDate.TabIndex = 11
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(9, 45)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(102, 20)
        Me.lblFullName.TabIndex = 5
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblFileNo
        '
        Me.lblFileNo.Location = New System.Drawing.Point(9, 25)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(102, 20)
        Me.lblFileNo.TabIndex = 3
        Me.lblFileNo.Text = "File/Patient No"
        '
        'btnFindOutwardNo
        '
        Me.btnFindOutwardNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindOutwardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindOutwardNo.Image = CType(resources.GetObject("btnFindOutwardNo.Image"), System.Drawing.Image)
        Me.btnFindOutwardNo.Location = New System.Drawing.Point(109, 4)
        Me.btnFindOutwardNo.Name = "btnFindOutwardNo"
        Me.btnFindOutwardNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindOutwardNo.TabIndex = 1
        '
        'lblTakenDateTime
        '
        Me.lblTakenDateTime.Location = New System.Drawing.Point(9, 151)
        Me.lblTakenDateTime.Name = "lblTakenDateTime"
        Me.lblTakenDateTime.Size = New System.Drawing.Size(102, 20)
        Me.lblTakenDateTime.TabIndex = 15
        Me.lblTakenDateTime.Text = "Taken Date Time"
        '
        'cboReturnedBy
        '
        Me.cboReturnedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboReturnedBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnedBy.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboReturnedBy, "ReturnedBy")
        Me.cboReturnedBy.DropDownWidth = 256
        Me.cboReturnedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReturnedBy.FormattingEnabled = True
        Me.cboReturnedBy.ItemHeight = 13
        Me.cboReturnedBy.Location = New System.Drawing.Point(142, 192)
        Me.cboReturnedBy.MaxLength = 100
        Me.cboReturnedBy.Name = "cboReturnedBy"
        Me.cboReturnedBy.Size = New System.Drawing.Size(178, 21)
        Me.cboReturnedBy.TabIndex = 20
        '
        'frmInwardFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(335, 286)
        Me.Controls.Add(Me.cboReturnedBy)
        Me.Controls.Add(Me.stbTakenDateTime)
        Me.Controls.Add(Me.lblTakenDateTime)
        Me.Controls.Add(Me.btnFindOutwardNo)
        Me.Controls.Add(Me.stbFileNo)
        Me.Controls.Add(Me.lblFileNo)
        Me.Controls.Add(Me.dtpReturnDateTime)
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
        Me.Controls.Add(Me.stbOutwardNo)
        Me.Controls.Add(Me.lblOutwardNo)
        Me.Controls.Add(Me.lblReturnDateTime)
        Me.Controls.Add(Me.lblReturnedBy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInwardFiles"
        Me.Text = "Inward Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbOutwardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOutwardNo As System.Windows.Forms.Label
    Friend WithEvents lblReturnDateTime As System.Windows.Forms.Label
    Friend WithEvents lblReturnedBy As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents dtpReturnDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbFileNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents btnFindOutwardNo As System.Windows.Forms.Button
    Friend WithEvents stbTakenDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTakenDateTime As System.Windows.Forms.Label
    Friend WithEvents cboReturnedBy As System.Windows.Forms.ComboBox

End Class