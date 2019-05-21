
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRevenueStreams : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRevenueStreams))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbRevenueStreamCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRevenueStreamCode = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 137)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 137)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "RevenueStreams"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 164)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "RevenueStreams"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbName
        '
        Me.stbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbName, "Name")
        Me.stbName.EntryErrorMSG = ""
        Me.stbName.Location = New System.Drawing.Point(218, 35)
        Me.stbName.Multiline = True
        Me.stbName.Name = "stbName"
        Me.stbName.RegularExpression = ""
        Me.stbName.Size = New System.Drawing.Size(170, 61)
        Me.stbName.TabIndex = 6
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(12, 107)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(200, 20)
        Me.chkHidden.TabIndex = 8
        Me.chkHidden.Text = "Hidden"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 164)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbRevenueStreamCode
        '
        Me.stbRevenueStreamCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRevenueStreamCode.CapitalizeFirstLetter = False
        Me.stbRevenueStreamCode.EntryErrorMSG = ""
        Me.stbRevenueStreamCode.Location = New System.Drawing.Point(218, 12)
        Me.stbRevenueStreamCode.Name = "stbRevenueStreamCode"
        Me.stbRevenueStreamCode.RegularExpression = ""
        Me.stbRevenueStreamCode.Size = New System.Drawing.Size(170, 20)
        Me.stbRevenueStreamCode.TabIndex = 4
        '
        'lblRevenueStreamCode
        '
        Me.lblRevenueStreamCode.Location = New System.Drawing.Point(12, 12)
        Me.lblRevenueStreamCode.Name = "lblRevenueStreamCode"
        Me.lblRevenueStreamCode.Size = New System.Drawing.Size(200, 20)
        Me.lblRevenueStreamCode.TabIndex = 5
        Me.lblRevenueStreamCode.Text = "Revenue Stream Code"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(12, 35)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(200, 20)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Name"
        '
        'frmRevenueStreams
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(406, 195)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbRevenueStreamCode)
        Me.Controls.Add(Me.lblRevenueStreamCode)
        Me.Controls.Add(Me.stbName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRevenueStreams"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revenue Streams"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub

Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents stbRevenueStreamCode As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblRevenueStreamCode As System.Windows.Forms.Label
Friend WithEvents stbName As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblName As System.Windows.Forms.Label
Friend WithEvents chkHidden As System.Windows.Forms.CheckBox

End Class