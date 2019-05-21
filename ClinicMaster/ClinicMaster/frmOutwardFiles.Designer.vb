
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOutwardFiles : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal fileNo As String, ByVal billAccountName As String, ByVal visitNo As String)
        MyClass.New()
        Me.defaultFileNo = fileNo
        Me.defaultBillAccountName = billAccountName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOutwardFiles))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbBillAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpTakenDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbFileNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboTakenBy = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblFileNo = New System.Windows.Forms.Label()
        Me.lblTakenDateTime = New System.Windows.Forms.Label()
        Me.lblTakenBy = New System.Windows.Forms.Label()
        Me.lblBillAccountName = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnFindOutwardNo = New System.Windows.Forms.Button()
        Me.stbOutwardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOutwardNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 245)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 23
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(282, 244)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 24
        Me.fbnDelete.Tag = "OutwardFiles"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 272)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 25
        Me.ebnSaveUpdate.Tag = "OutwardFiles"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbBillAccountName
        '
        Me.stbBillAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillAccountName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillAccountName, "BillAccountName")
        Me.stbBillAccountName.EntryErrorMSG = ""
        Me.stbBillAccountName.Location = New System.Drawing.Point(190, 198)
        Me.stbBillAccountName.MaxLength = 100
        Me.stbBillAccountName.Name = "stbBillAccountName"
        Me.stbBillAccountName.RegularExpression = ""
        Me.stbBillAccountName.Size = New System.Drawing.Size(164, 20)
        Me.stbBillAccountName.TabIndex = 20
        '
        'dtpTakenDateTime
        '
        Me.dtpTakenDateTime.Checked = False
        Me.dtpTakenDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpTakenDateTime, "TakenDateTime")
        Me.dtpTakenDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTakenDateTime.Location = New System.Drawing.Point(190, 156)
        Me.dtpTakenDateTime.Name = "dtpTakenDateTime"
        Me.dtpTakenDateTime.ShowCheckBox = True
        Me.dtpTakenDateTime.Size = New System.Drawing.Size(164, 20)
        Me.dtpTakenDateTime.TabIndex = 16
        '
        'stbFileNo
        '
        Me.stbFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFileNo.CapitalizeFirstLetter = False
        Me.stbFileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbFileNo, "FileNo")
        Me.stbFileNo.EntryErrorMSG = ""
        Me.stbFileNo.Location = New System.Drawing.Point(190, 9)
        Me.stbFileNo.MaxLength = 20
        Me.stbFileNo.Name = "stbFileNo"
        Me.stbFileNo.RegularExpression = ""
        Me.stbFileNo.Size = New System.Drawing.Size(115, 20)
        Me.stbFileNo.TabIndex = 1
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(190, 72)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(78, 20)
        Me.stbGender.TabIndex = 8
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(190, 93)
        Me.stbAge.MaxLength = 20
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.Size = New System.Drawing.Size(78, 20)
        Me.stbAge.TabIndex = 10
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastVisitDate, "LastVisitDate")
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(190, 135)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(164, 20)
        Me.stbLastVisitDate.TabIndex = 14
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(190, 114)
        Me.stbJoinDate.MaxLength = 20
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.Size = New System.Drawing.Size(164, 20)
        Me.stbJoinDate.TabIndex = 12
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(190, 51)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(164, 20)
        Me.stbFullName.TabIndex = 6
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(190, 219)
        Me.stbVisitNo.MaxLength = 100
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(164, 20)
        Me.stbVisitNo.TabIndex = 22
        '
        'cboTakenBy
        '
        Me.cboTakenBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTakenBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTakenBy.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboTakenBy, "TakenBy")
        Me.cboTakenBy.DropDownWidth = 256
        Me.cboTakenBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTakenBy.FormattingEnabled = True
        Me.cboTakenBy.ItemHeight = 13
        Me.cboTakenBy.Location = New System.Drawing.Point(190, 176)
        Me.cboTakenBy.MaxLength = 100
        Me.cboTakenBy.Name = "cboTakenBy"
        Me.cboTakenBy.Size = New System.Drawing.Size(164, 21)
        Me.cboTakenBy.TabIndex = 18
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(282, 271)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 26
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblFileNo
        '
        Me.lblFileNo.Location = New System.Drawing.Point(12, 9)
        Me.lblFileNo.Name = "lblFileNo"
        Me.lblFileNo.Size = New System.Drawing.Size(141, 20)
        Me.lblFileNo.TabIndex = 0
        Me.lblFileNo.Text = "File/Patient No"
        '
        'lblTakenDateTime
        '
        Me.lblTakenDateTime.Location = New System.Drawing.Point(12, 156)
        Me.lblTakenDateTime.Name = "lblTakenDateTime"
        Me.lblTakenDateTime.Size = New System.Drawing.Size(141, 20)
        Me.lblTakenDateTime.TabIndex = 15
        Me.lblTakenDateTime.Text = "Taken Date Time"
        '
        'lblTakenBy
        '
        Me.lblTakenBy.Location = New System.Drawing.Point(12, 177)
        Me.lblTakenBy.Name = "lblTakenBy"
        Me.lblTakenBy.Size = New System.Drawing.Size(141, 20)
        Me.lblTakenBy.TabIndex = 17
        Me.lblTakenBy.Text = "Taken By"
        '
        'lblBillAccountName
        '
        Me.lblBillAccountName.Location = New System.Drawing.Point(12, 198)
        Me.lblBillAccountName.Name = "lblBillAccountName"
        Me.lblBillAccountName.Size = New System.Drawing.Size(141, 20)
        Me.lblBillAccountName.TabIndex = 19
        Me.lblBillAccountName.Text = "To-Bill Account Name"
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
        Me.lblGender.Location = New System.Drawing.Point(12, 72)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(141, 20)
        Me.lblGender.TabIndex = 7
        Me.lblGender.Text = "Gender"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(12, 92)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(141, 20)
        Me.lblAge.TabIndex = 9
        Me.lblAge.Text = "Age"
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(12, 135)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(141, 20)
        Me.lblLastVisitDate.TabIndex = 13
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(12, 114)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(141, 20)
        Me.lblJoinDate.TabIndex = 11
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(12, 50)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(141, 20)
        Me.lblFullName.TabIndex = 5
        Me.lblFullName.Text = "Patient's Name"
        '
        'btnFindOutwardNo
        '
        Me.btnFindOutwardNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindOutwardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindOutwardNo.Image = CType(resources.GetObject("btnFindOutwardNo.Image"), System.Drawing.Image)
        Me.btnFindOutwardNo.Location = New System.Drawing.Point(157, 29)
        Me.btnFindOutwardNo.Name = "btnFindOutwardNo"
        Me.btnFindOutwardNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindOutwardNo.TabIndex = 3
        '
        'stbOutwardNo
        '
        Me.stbOutwardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOutwardNo.CapitalizeFirstLetter = False
        Me.stbOutwardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbOutwardNo.EntryErrorMSG = ""
        Me.stbOutwardNo.Location = New System.Drawing.Point(190, 30)
        Me.stbOutwardNo.MaxLength = 20
        Me.stbOutwardNo.Name = "stbOutwardNo"
        Me.stbOutwardNo.RegularExpression = ""
        Me.stbOutwardNo.Size = New System.Drawing.Size(164, 20)
        Me.stbOutwardNo.TabIndex = 4
        '
        'lblOutwardNo
        '
        Me.lblOutwardNo.Location = New System.Drawing.Point(12, 30)
        Me.lblOutwardNo.Name = "lblOutwardNo"
        Me.lblOutwardNo.Size = New System.Drawing.Size(108, 20)
        Me.lblOutwardNo.TabIndex = 2
        Me.lblOutwardNo.Text = "Outward Number"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 219)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(141, 20)
        Me.lblVisitNo.TabIndex = 21
        Me.lblVisitNo.Text = "Visit No"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(308, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 27
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'frmOutwardFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(370, 306)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboTakenBy)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.btnFindOutwardNo)
        Me.Controls.Add(Me.stbOutwardNo)
        Me.Controls.Add(Me.lblOutwardNo)
        Me.Controls.Add(Me.dtpTakenDateTime)
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
        Me.Controls.Add(Me.stbFileNo)
        Me.Controls.Add(Me.lblFileNo)
        Me.Controls.Add(Me.lblTakenDateTime)
        Me.Controls.Add(Me.lblTakenBy)
        Me.Controls.Add(Me.stbBillAccountName)
        Me.Controls.Add(Me.lblBillAccountName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOutwardFiles"
        Me.Text = "Outward Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbFileNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFileNo As System.Windows.Forms.Label
    Friend WithEvents lblTakenDateTime As System.Windows.Forms.Label
    Friend WithEvents lblTakenBy As System.Windows.Forms.Label
    Friend WithEvents stbBillAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillAccountName As System.Windows.Forms.Label
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
    Friend WithEvents dtpTakenDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnFindOutwardNo As System.Windows.Forms.Button
    Friend WithEvents stbOutwardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOutwardNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboTakenBy As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button

End Class