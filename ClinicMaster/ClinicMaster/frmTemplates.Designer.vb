
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTemplates : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal templateTypeID As String)
        MyClass.New()
        Me.defaultTemplateTypeID = templateTypeID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTemplates))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboTemplateTypeID = New System.Windows.Forms.ComboBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbTemplateName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTemplateName = New System.Windows.Forms.Label()
        Me.lblTemplateTypeID = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 180)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 180)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "Templates"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 207)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "Templates"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboTemplateTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTemplateTypeID, "TemplateType,TemplateTypeID")
        Me.cboTemplateTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTemplateTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTemplateTypeID.Location = New System.Drawing.Point(169, 35)
        Me.cboTemplateTypeID.Name = "cboTemplateTypeID"
        Me.cboTemplateTypeID.Size = New System.Drawing.Size(219, 21)
        Me.cboTemplateTypeID.TabIndex = 6
        '
        'stbNotes
        '
        Me.stbNotes.AcceptsReturn = True
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(169, 58)
        Me.stbNotes.MaxLength = 2000
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(219, 116)
        Me.stbNotes.TabIndex = 8
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 207)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbTemplateName
        '
        Me.stbTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTemplateName.CapitalizeFirstLetter = False
        Me.stbTemplateName.EntryErrorMSG = ""
        Me.stbTemplateName.Location = New System.Drawing.Point(169, 12)
        Me.stbTemplateName.MaxLength = 40
        Me.stbTemplateName.Name = "stbTemplateName"
        Me.stbTemplateName.RegularExpression = ""
        Me.stbTemplateName.Size = New System.Drawing.Size(219, 20)
        Me.stbTemplateName.TabIndex = 4
        '
        'lblTemplateName
        '
        Me.lblTemplateName.Location = New System.Drawing.Point(12, 12)
        Me.lblTemplateName.Name = "lblTemplateName"
        Me.lblTemplateName.Size = New System.Drawing.Size(123, 20)
        Me.lblTemplateName.TabIndex = 5
        Me.lblTemplateName.Text = "Template Name"
        '
        'lblTemplateTypeID
        '
        Me.lblTemplateTypeID.Location = New System.Drawing.Point(12, 35)
        Me.lblTemplateTypeID.Name = "lblTemplateTypeID"
        Me.lblTemplateTypeID.Size = New System.Drawing.Size(123, 20)
        Me.lblTemplateTypeID.TabIndex = 7
        Me.lblTemplateTypeID.Text = "Template Type"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(12, 104)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(123, 20)
        Me.lblNotes.TabIndex = 9
        Me.lblNotes.Text = "Notes"
        '
        'frmTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(405, 246)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbTemplateName)
        Me.Controls.Add(Me.lblTemplateName)
        Me.Controls.Add(Me.cboTemplateTypeID)
        Me.Controls.Add(Me.lblTemplateTypeID)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTemplates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Templates"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents stbTemplateName As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblTemplateName As System.Windows.Forms.Label
Friend WithEvents cboTemplateTypeID As System.Windows.Forms.ComboBox
Friend WithEvents lblTemplateTypeID As System.Windows.Forms.Label
Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblNotes As System.Windows.Forms.Label

End Class