
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRooms : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRooms))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbRoomName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboWardsID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.lblRoomName = New System.Windows.Forms.Label()
        Me.lblWardsID = New System.Windows.Forms.Label()
        Me.grpLocation = New System.Windows.Forms.GroupBox()
        Me.cboRoomNo = New System.Windows.Forms.ComboBox()
        Me.grpLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(25, 109)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 5
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(324, 109)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 6
        Me.fbnDelete.Tag = "Rooms"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(25, 136)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 7
        Me.ebnSaveUpdate.Tag = "Rooms"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbRoomName
        '
        Me.stbRoomName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoomName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbRoomName, "RoomName")
        Me.stbRoomName.EntryErrorMSG = ""
        Me.stbRoomName.Location = New System.Drawing.Point(226, 77)
        Me.stbRoomName.MaxLength = 41
        Me.stbRoomName.Name = "stbRoomName"
        Me.stbRoomName.RegularExpression = ""
        Me.stbRoomName.Size = New System.Drawing.Size(170, 20)
        Me.stbRoomName.TabIndex = 4
        '
        'cboWardsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWardsID, "Wards,WardsID")
        Me.cboWardsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWardsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWardsID.Location = New System.Drawing.Point(214, 17)
        Me.cboWardsID.Name = "cboWardsID"
        Me.cboWardsID.Size = New System.Drawing.Size(170, 21)
        Me.cboWardsID.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(324, 136)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Location = New System.Drawing.Point(26, 54)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(174, 20)
        Me.lblRoomNo.TabIndex = 1
        Me.lblRoomNo.Text = "Room No"
        '
        'lblRoomName
        '
        Me.lblRoomName.Location = New System.Drawing.Point(26, 77)
        Me.lblRoomName.Name = "lblRoomName"
        Me.lblRoomName.Size = New System.Drawing.Size(174, 20)
        Me.lblRoomName.TabIndex = 3
        Me.lblRoomName.Text = "Room Name"
        '
        'lblWardsID
        '
        Me.lblWardsID.Location = New System.Drawing.Point(11, 17)
        Me.lblWardsID.Name = "lblWardsID"
        Me.lblWardsID.Size = New System.Drawing.Size(177, 20)
        Me.lblWardsID.TabIndex = 0
        Me.lblWardsID.Text = "Ward"
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.cboWardsID)
        Me.grpLocation.Controls.Add(Me.lblWardsID)
        Me.grpLocation.Location = New System.Drawing.Point(12, 3)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(390, 46)
        Me.grpLocation.TabIndex = 0
        Me.grpLocation.TabStop = False
        Me.grpLocation.Text = "Location"
        '
        'cboRoomNo
        '
        Me.cboRoomNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRoomNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRoomNo.DropDownWidth = 200
        Me.cboRoomNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoomNo.FormattingEnabled = True
        Me.cboRoomNo.Location = New System.Drawing.Point(226, 51)
        Me.cboRoomNo.MaxLength = 64
        Me.cboRoomNo.Name = "cboRoomNo"
        Me.cboRoomNo.Size = New System.Drawing.Size(170, 21)
        Me.cboRoomNo.TabIndex = 9
        '
        'frmRooms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(412, 185)
        Me.Controls.Add(Me.cboRoomNo)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblRoomNo)
        Me.Controls.Add(Me.stbRoomName)
        Me.Controls.Add(Me.lblRoomName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRooms"
        Me.Text = "Rooms"
        Me.grpLocation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents stbRoomName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoomName As System.Windows.Forms.Label
    Friend WithEvents lblWardsID As System.Windows.Forms.Label
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents cboRoomNo As ComboBox
    Friend WithEvents cboWardsID As ComboBox
End Class