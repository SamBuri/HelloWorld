
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBulkMessaging : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBulkMessaging))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMessage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMessageNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessageNo = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(144, 310)
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
        Me.fbnDelete.Location = New System.Drawing.Point(564, 310)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "BulkMessaging"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(144, 337)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "BulkMessaging"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(146, 38)
        Me.stbPhone.Multiline = True
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(490, 99)
        Me.stbPhone.TabIndex = 6
        '
        'stbMessage
        '
        Me.stbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMessage.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMessage, "Message")
        Me.stbMessage.EntryErrorMSG = ""
        Me.stbMessage.Location = New System.Drawing.Point(146, 143)
        Me.stbMessage.MaxLength = 120
        Me.stbMessage.Multiline = True
        Me.stbMessage.Name = "stbMessage"
        Me.stbMessage.RegularExpression = ""
        Me.stbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMessage.Size = New System.Drawing.Size(490, 146)
        Me.stbMessage.TabIndex = 8
        '
        'stbMessageNo
        '
        Me.stbMessageNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMessageNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMessageNo, "MessageNo")
        Me.stbMessageNo.EntryErrorMSG = ""
        Me.stbMessageNo.Location = New System.Drawing.Point(146, 17)
        Me.stbMessageNo.Name = "stbMessageNo"
        Me.stbMessageNo.ReadOnly = True
        Me.stbMessageNo.RegularExpression = ""
        Me.stbMessageNo.Size = New System.Drawing.Size(152, 20)
        Me.stbMessageNo.TabIndex = 4
        Me.stbMessageNo.Tag = "bulkmessaging"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(564, 337)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblMessageNo
        '
        Me.lblMessageNo.Location = New System.Drawing.Point(12, 18)
        Me.lblMessageNo.Name = "lblMessageNo"
        Me.lblMessageNo.Size = New System.Drawing.Size(87, 16)
        Me.lblMessageNo.TabIndex = 5
        Me.lblMessageNo.Text = "MessageNo"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(11, 40)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(129, 43)
        Me.lblPhone.TabIndex = 7
        Me.lblPhone.Text = "Phone Numbers (Comma separated)"
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(56, 145)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(84, 20)
        Me.lblMessage.TabIndex = 9
        Me.lblMessage.Text = "Message"
        '
        'lblNote
        '
        Me.lblNote.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblNote.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblNote.Location = New System.Drawing.Point(140, 363)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(497, 30)
        Me.lblNote.TabIndex = 10
        Me.lblNote.Text = "Note: Facility name is automaically attached onto the Message"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(303, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 11
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'frmBulkMessaging
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(702, 402)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lblNote)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbMessageNo)
        Me.Controls.Add(Me.lblMessageNo)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.stbMessage)
        Me.Controls.Add(Me.lblMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBulkMessaging"
        Me.Text = "Bulk Messaging"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbMessageNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMessageNo As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents stbMessage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button

End Class