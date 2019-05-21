
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetMaintainanceLog : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetMaintainanceLog))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbActionTaken = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMaintainedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxMaintainaceCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpNextDue = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbSerialNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSerialNo = New System.Windows.Forms.Label()
        Me.lblActionTaken = New System.Windows.Forms.Label()
        Me.dtpMaintainanceDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMaintainanceDate = New System.Windows.Forms.Label()
        Me.lblMaintainedBy = New System.Windows.Forms.Label()
        Me.lblMaintainaceCost = New System.Windows.Forms.Label()
        Me.lblNextDue = New System.Windows.Forms.Label()
        Me.stbItemDescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblItemDescription = New System.Windows.Forms.Label()
        Me.stbLastServiceDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 300)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 18
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 300)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 19
        Me.fbnDelete.Tag = "AssetMaintainanceLog"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 327)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 16
        Me.ebnSaveUpdate.Tag = "AssetMaintainanceLog"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbActionTaken
        '
        Me.stbActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbActionTaken.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbActionTaken, "ActionTaken")
        Me.stbActionTaken.EntryErrorMSG = ""
        Me.stbActionTaken.Location = New System.Drawing.Point(156, 116)
        Me.stbActionTaken.Multiline = True
        Me.stbActionTaken.Name = "stbActionTaken"
        Me.stbActionTaken.RegularExpression = ""
        Me.stbActionTaken.Size = New System.Drawing.Size(232, 75)
        Me.stbActionTaken.TabIndex = 7
        '
        'stbMaintainedBy
        '
        Me.stbMaintainedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMaintainedBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMaintainedBy, "MaintainedBy")
        Me.stbMaintainedBy.EntryErrorMSG = ""
        Me.stbMaintainedBy.Location = New System.Drawing.Point(156, 217)
        Me.stbMaintainedBy.Name = "stbMaintainedBy"
        Me.stbMaintainedBy.RegularExpression = ""
        Me.stbMaintainedBy.Size = New System.Drawing.Size(232, 20)
        Me.stbMaintainedBy.TabIndex = 11
        '
        'nbxMaintainaceCost
        '
        Me.nbxMaintainaceCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMaintainaceCost.ControlCaption = "Cost"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMaintainaceCost, "MaintainaceCost")
        Me.nbxMaintainaceCost.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxMaintainaceCost.DecimalPlaces = -1
        Me.nbxMaintainaceCost.Location = New System.Drawing.Point(156, 240)
        Me.nbxMaintainaceCost.MaxValue = 0.0R
        Me.nbxMaintainaceCost.MinValue = 0.0R
        Me.nbxMaintainaceCost.MustEnterNumeric = True
        Me.nbxMaintainaceCost.Name = "nbxMaintainaceCost"
        Me.nbxMaintainaceCost.Size = New System.Drawing.Size(232, 20)
        Me.nbxMaintainaceCost.TabIndex = 13
        Me.nbxMaintainaceCost.Value = ""
        '
        'dtpNextDue
        '
        Me.dtpNextDue.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpNextDue, "NextDue")
        Me.dtpNextDue.Location = New System.Drawing.Point(156, 263)
        Me.dtpNextDue.Name = "dtpNextDue"
        Me.dtpNextDue.ShowCheckBox = True
        Me.dtpNextDue.Size = New System.Drawing.Size(232, 20)
        Me.dtpNextDue.TabIndex = 15
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 327)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 17
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbSerialNo
        '
        Me.stbSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSerialNo.CapitalizeFirstLetter = True
        Me.stbSerialNo.EntryErrorMSG = ""
        Me.stbSerialNo.Location = New System.Drawing.Point(156, 12)
        Me.stbSerialNo.Name = "stbSerialNo"
        Me.stbSerialNo.RegularExpression = ""
        Me.stbSerialNo.Size = New System.Drawing.Size(232, 20)
        Me.stbSerialNo.TabIndex = 1
        '
        'lblSerialNo
        '
        Me.lblSerialNo.Location = New System.Drawing.Point(12, 12)
        Me.lblSerialNo.Name = "lblSerialNo"
        Me.lblSerialNo.Size = New System.Drawing.Size(127, 20)
        Me.lblSerialNo.TabIndex = 0
        Me.lblSerialNo.Text = "Serial No"
        '
        'lblActionTaken
        '
        Me.lblActionTaken.Location = New System.Drawing.Point(12, 116)
        Me.lblActionTaken.Name = "lblActionTaken"
        Me.lblActionTaken.Size = New System.Drawing.Size(127, 20)
        Me.lblActionTaken.TabIndex = 6
        Me.lblActionTaken.Text = "Action Taken"
        '
        'dtpMaintainanceDate
        '
        Me.dtpMaintainanceDate.Checked = False
        Me.dtpMaintainanceDate.Location = New System.Drawing.Point(156, 194)
        Me.dtpMaintainanceDate.Name = "dtpMaintainanceDate"
        Me.dtpMaintainanceDate.ShowCheckBox = True
        Me.dtpMaintainanceDate.Size = New System.Drawing.Size(232, 20)
        Me.dtpMaintainanceDate.TabIndex = 9
        '
        'lblMaintainanceDate
        '
        Me.lblMaintainanceDate.Location = New System.Drawing.Point(12, 194)
        Me.lblMaintainanceDate.Name = "lblMaintainanceDate"
        Me.lblMaintainanceDate.Size = New System.Drawing.Size(127, 20)
        Me.lblMaintainanceDate.TabIndex = 8
        Me.lblMaintainanceDate.Text = "Maintainance Date"
        '
        'lblMaintainedBy
        '
        Me.lblMaintainedBy.Location = New System.Drawing.Point(12, 217)
        Me.lblMaintainedBy.Name = "lblMaintainedBy"
        Me.lblMaintainedBy.Size = New System.Drawing.Size(127, 20)
        Me.lblMaintainedBy.TabIndex = 10
        Me.lblMaintainedBy.Text = "Maintained By"
        '
        'lblMaintainaceCost
        '
        Me.lblMaintainaceCost.Location = New System.Drawing.Point(12, 240)
        Me.lblMaintainaceCost.Name = "lblMaintainaceCost"
        Me.lblMaintainaceCost.Size = New System.Drawing.Size(127, 20)
        Me.lblMaintainaceCost.TabIndex = 12
        Me.lblMaintainaceCost.Text = "Cost"
        '
        'lblNextDue
        '
        Me.lblNextDue.Location = New System.Drawing.Point(12, 263)
        Me.lblNextDue.Name = "lblNextDue"
        Me.lblNextDue.Size = New System.Drawing.Size(127, 20)
        Me.lblNextDue.TabIndex = 14
        Me.lblNextDue.Text = "Next Due"
        '
        'stbItemDescription
        '
        Me.stbItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemDescription.CapitalizeFirstLetter = True
        Me.stbItemDescription.Enabled = False
        Me.stbItemDescription.EntryErrorMSG = ""
        Me.stbItemDescription.Location = New System.Drawing.Point(156, 34)
        Me.stbItemDescription.Multiline = True
        Me.stbItemDescription.Name = "stbItemDescription"
        Me.stbItemDescription.ReadOnly = True
        Me.stbItemDescription.RegularExpression = ""
        Me.stbItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbItemDescription.Size = New System.Drawing.Size(232, 58)
        Me.stbItemDescription.TabIndex = 3
        '
        'lblItemDescription
        '
        Me.lblItemDescription.Location = New System.Drawing.Point(12, 36)
        Me.lblItemDescription.Name = "lblItemDescription"
        Me.lblItemDescription.Size = New System.Drawing.Size(127, 20)
        Me.lblItemDescription.TabIndex = 2
        Me.lblItemDescription.Text = "Description"
        '
        'stbLastServiceDate
        '
        Me.stbLastServiceDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastServiceDate.CapitalizeFirstLetter = True
        Me.stbLastServiceDate.Enabled = False
        Me.stbLastServiceDate.EntryErrorMSG = ""
        Me.stbLastServiceDate.Location = New System.Drawing.Point(156, 94)
        Me.stbLastServiceDate.Name = "stbLastServiceDate"
        Me.stbLastServiceDate.ReadOnly = True
        Me.stbLastServiceDate.RegularExpression = ""
        Me.stbLastServiceDate.Size = New System.Drawing.Size(232, 20)
        Me.stbLastServiceDate.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Last Service Date"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(394, 12)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(135, 124)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 105
        Me.spbPhoto.TabStop = False
        '
        'frmAssetMaintainanceLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(536, 379)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.stbLastServiceDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbItemDescription)
        Me.Controls.Add(Me.lblItemDescription)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbSerialNo)
        Me.Controls.Add(Me.lblSerialNo)
        Me.Controls.Add(Me.stbActionTaken)
        Me.Controls.Add(Me.lblActionTaken)
        Me.Controls.Add(Me.dtpMaintainanceDate)
        Me.Controls.Add(Me.lblMaintainanceDate)
        Me.Controls.Add(Me.stbMaintainedBy)
        Me.Controls.Add(Me.lblMaintainedBy)
        Me.Controls.Add(Me.nbxMaintainaceCost)
        Me.Controls.Add(Me.lblMaintainaceCost)
        Me.Controls.Add(Me.dtpNextDue)
        Me.Controls.Add(Me.lblNextDue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAssetMaintainanceLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asset Maintainance Log"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbSerialNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSerialNo As System.Windows.Forms.Label
    Friend WithEvents stbActionTaken As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblActionTaken As System.Windows.Forms.Label
    Friend WithEvents dtpMaintainanceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMaintainanceDate As System.Windows.Forms.Label
    Friend WithEvents stbMaintainedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMaintainedBy As System.Windows.Forms.Label
    Friend WithEvents nbxMaintainaceCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMaintainaceCost As System.Windows.Forms.Label
    Friend WithEvents dtpNextDue As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNextDue As System.Windows.Forms.Label
    Friend WithEvents stbItemDescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemDescription As System.Windows.Forms.Label
    Friend WithEvents stbLastServiceDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox

End Class