
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStaffLocations : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStaffLocations))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbStaffLoginID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStaffLoginID = New System.Windows.Forms.Label()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.stbStaffName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDentalName = New System.Windows.Forms.Label()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.stbLoginLevel = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLoginLevel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 221)
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
        Me.fbnDelete.Location = New System.Drawing.Point(315, 221)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "StaffLocations"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 248)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "StaffLocations"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(169, 147)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(218, 59)
        Me.stbNotes.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(315, 248)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbStaffLoginID
        '
        Me.stbStaffLoginID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffLoginID.CapitalizeFirstLetter = False
        Me.stbStaffLoginID.EntryErrorMSG = ""
        Me.stbStaffLoginID.Location = New System.Drawing.Point(170, 10)
        Me.stbStaffLoginID.Name = "stbStaffLoginID"
        Me.stbStaffLoginID.RegularExpression = ""
        Me.stbStaffLoginID.Size = New System.Drawing.Size(218, 20)
        Me.stbStaffLoginID.TabIndex = 4
        '
        'lblStaffLoginID
        '
        Me.lblStaffLoginID.Location = New System.Drawing.Point(12, 12)
        Me.lblStaffLoginID.Name = "lblStaffLoginID"
        Me.lblStaffLoginID.Size = New System.Drawing.Size(134, 20)
        Me.lblStaffLoginID.TabIndex = 5
        Me.lblStaffLoginID.Text = "Login ID"
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(11, 97)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(134, 20)
        Me.lblLocationID.TabIndex = 7
        Me.lblLocationID.Text = "Branch"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(169, 124)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(218, 20)
        Me.dtpStartDate.TabIndex = 8
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(11, 124)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(134, 20)
        Me.lblStartDate.TabIndex = 9
        Me.lblStartDate.Text = "Start Date"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(11, 147)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(134, 20)
        Me.lblNotes.TabIndex = 11
        Me.lblNotes.Text = "Notes"
        '
        'stbStaffName
        '
        Me.stbStaffName.AcceptsReturn = True
        Me.stbStaffName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffName.CapitalizeFirstLetter = True
        Me.stbStaffName.Enabled = False
        Me.stbStaffName.EntryErrorMSG = ""
        Me.stbStaffName.Location = New System.Drawing.Point(170, 32)
        Me.stbStaffName.MaxLength = 200
        Me.stbStaffName.Multiline = True
        Me.stbStaffName.Name = "stbStaffName"
        Me.stbStaffName.ReadOnly = True
        Me.stbStaffName.RegularExpression = ""
        Me.stbStaffName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStaffName.Size = New System.Drawing.Size(218, 39)
        Me.stbStaffName.TabIndex = 27
        '
        'lblDentalName
        '
        Me.lblDentalName.Location = New System.Drawing.Point(12, 40)
        Me.lblDentalName.Name = "lblDentalName"
        Me.lblDentalName.Size = New System.Drawing.Size(134, 20)
        Me.lblDentalName.TabIndex = 26
        Me.lblDentalName.Tag = ""
        Me.lblDentalName.Text = "Staff Name"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.Location = New System.Drawing.Point(170, 99)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(204, 21)
        Me.cboLocationID.TabIndex = 28
        '
        'stbLoginLevel
        '
        Me.stbLoginLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLoginLevel.CapitalizeFirstLetter = True
        Me.stbLoginLevel.Enabled = False
        Me.stbLoginLevel.EntryErrorMSG = ""
        Me.stbLoginLevel.Location = New System.Drawing.Point(169, 76)
        Me.stbLoginLevel.Name = "stbLoginLevel"
        Me.stbLoginLevel.ReadOnly = True
        Me.stbLoginLevel.RegularExpression = ""
        Me.stbLoginLevel.Size = New System.Drawing.Size(218, 20)
        Me.stbLoginLevel.TabIndex = 30
        '
        'lblLoginLevel
        '
        Me.lblLoginLevel.Location = New System.Drawing.Point(11, 78)
        Me.lblLoginLevel.Name = "lblLoginLevel"
        Me.lblLoginLevel.Size = New System.Drawing.Size(127, 20)
        Me.lblLoginLevel.TabIndex = 29
        Me.lblLoginLevel.Text = "Staff Role"
        '
        'frmStaffLocations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(394, 281)
        Me.Controls.Add(Me.stbLoginLevel)
        Me.Controls.Add(Me.lblLoginLevel)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.stbStaffName)
        Me.Controls.Add(Me.lblDentalName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbStaffLoginID)
        Me.Controls.Add(Me.lblStaffLoginID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmStaffLocations"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Staff Locations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbStaffLoginID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStaffLoginID As System.Windows.Forms.Label
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbStaffName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDentalName As System.Windows.Forms.Label
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents stbLoginLevel As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLoginLevel As System.Windows.Forms.Label

End Class