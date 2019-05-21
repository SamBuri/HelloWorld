
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhysicalStockCount : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhysicalStockCount))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbGeneralNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkClosed = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPSCNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPSCNo = New System.Windows.Forms.Label()
        Me.lblGeneralNotes = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(20, 152)
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
        Me.fbnDelete.Location = New System.Drawing.Point(339, 151)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "PhysicalStockCount"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(20, 179)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "PhysicalStockCount"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbGeneralNotes
        '
        Me.stbGeneralNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGeneralNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGeneralNotes, "GeneralNotes")
        Me.stbGeneralNotes.EntryErrorMSG = ""
        Me.stbGeneralNotes.Location = New System.Drawing.Point(221, 35)
        Me.stbGeneralNotes.Name = "stbGeneralNotes"
        Me.stbGeneralNotes.RegularExpression = ""
        Me.stbGeneralNotes.Size = New System.Drawing.Size(190, 20)
        Me.stbGeneralNotes.TabIndex = 8
        '
        'chkClosed
        '
        Me.chkClosed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkClosed, "Closed")
        Me.chkClosed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkClosed.Location = New System.Drawing.Point(15, 104)
        Me.chkClosed.Name = "chkClosed"
        Me.chkClosed.Size = New System.Drawing.Size(221, 20)
        Me.chkClosed.TabIndex = 14
        Me.chkClosed.Text = "Closed"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(339, 178)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPSCNo
        '
        Me.stbPSCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPSCNo.CapitalizeFirstLetter = False
        Me.stbPSCNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPSCNo.EntryErrorMSG = ""
        Me.stbPSCNo.Location = New System.Drawing.Point(221, 12)
        Me.stbPSCNo.Name = "stbPSCNo"
        Me.stbPSCNo.RegularExpression = ""
        Me.stbPSCNo.Size = New System.Drawing.Size(190, 20)
        Me.stbPSCNo.TabIndex = 6
        '
        'lblPSCNo
        '
        Me.lblPSCNo.Location = New System.Drawing.Point(15, 12)
        Me.lblPSCNo.Name = "lblPSCNo"
        Me.lblPSCNo.Size = New System.Drawing.Size(200, 20)
        Me.lblPSCNo.TabIndex = 7
        Me.lblPSCNo.Text = "PSCNo"
        '
        'lblGeneralNotes
        '
        Me.lblGeneralNotes.Location = New System.Drawing.Point(15, 35)
        Me.lblGeneralNotes.Name = "lblGeneralNotes"
        Me.lblGeneralNotes.Size = New System.Drawing.Size(200, 20)
        Me.lblGeneralNotes.TabIndex = 9
        Me.lblGeneralNotes.Text = "General Notes"
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(15, 58)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(200, 20)
        Me.lblStartDate.TabIndex = 11
        Me.lblStartDate.Text = "Start Date"
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(15, 81)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(200, 20)
        Me.lblEndDate.TabIndex = 13
        Me.lblEndDate.Text = "End Date"
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStartDateTime, "StartDate")
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(221, 57)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(190, 20)
        Me.dtpStartDateTime.TabIndex = 15
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEndDateTime, "EndDate")
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(221, 81)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(190, 20)
        Me.dtpEndDateTime.TabIndex = 16
        '
        'frmPhysicalStockCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(422, 234)
        Me.Controls.Add(Me.dtpEndDateTime)
        Me.Controls.Add(Me.dtpStartDateTime)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPSCNo)
        Me.Controls.Add(Me.lblPSCNo)
        Me.Controls.Add(Me.stbGeneralNotes)
        Me.Controls.Add(Me.lblGeneralNotes)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblEndDate)
        Me.Controls.Add(Me.chkClosed)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPhysicalStockCount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "Physical Stock Count"
        Me.Text = "Physical Stock Count"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPSCNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPSCNo As System.Windows.Forms.Label
    Friend WithEvents stbGeneralNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGeneralNotes As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker

End Class