
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberBenefits : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMemberBenefits))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbBenefitName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.cboBenefitCode = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBenefitCode = New System.Windows.Forms.Label()
        Me.lblBenefitName = New System.Windows.Forms.Label()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 79)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 6
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(238, 77)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 7
        Me.fbnDelete.Tag = "MemberBenefits"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 106)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 8
        Me.ebnSaveUpdate.Tag = "MemberBenefits"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbBenefitName
        '
        Me.stbBenefitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBenefitName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBenefitName, "BenefitName")
        Me.stbBenefitName.EntryErrorMSG = ""
        Me.stbBenefitName.Location = New System.Drawing.Point(140, 26)
        Me.stbBenefitName.MaxLength = 100
        Me.stbBenefitName.Name = "stbBenefitName"
        Me.stbBenefitName.RegularExpression = ""
        Me.stbBenefitName.Size = New System.Drawing.Size(170, 20)
        Me.stbBenefitName.TabIndex = 3
        '
        'cboItemCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboItemCategoryID, "ItemFullCategory")
        Me.cboItemCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.Location = New System.Drawing.Point(140, 48)
        Me.cboItemCategoryID.MaxLength = 124
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(170, 21)
        Me.cboItemCategoryID.TabIndex = 5
        '
        'cboBenefitCode
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBenefitCode, "ItemFullCategory")
        Me.cboBenefitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBenefitCode.Location = New System.Drawing.Point(140, 4)
        Me.cboBenefitCode.MaxLength = 124
        Me.cboBenefitCode.Name = "cboBenefitCode"
        Me.cboBenefitCode.Size = New System.Drawing.Size(170, 21)
        Me.cboBenefitCode.TabIndex = 11
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(238, 104)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 9
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblBenefitCode
        '
        Me.lblBenefitCode.Location = New System.Drawing.Point(12, 7)
        Me.lblBenefitCode.Name = "lblBenefitCode"
        Me.lblBenefitCode.Size = New System.Drawing.Size(122, 20)
        Me.lblBenefitCode.TabIndex = 0
        Me.lblBenefitCode.Text = "Benefit Code"
        '
        'lblBenefitName
        '
        Me.lblBenefitName.Location = New System.Drawing.Point(12, 28)
        Me.lblBenefitName.Name = "lblBenefitName"
        Me.lblBenefitName.Size = New System.Drawing.Size(122, 20)
        Me.lblBenefitName.TabIndex = 2
        Me.lblBenefitName.Text = "Benefit Name"
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(12, 50)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(122, 20)
        Me.lblItemCategoryID.TabIndex = 4
        Me.lblItemCategoryID.Text = "Item Category"
        '
        'frmMemberBenefits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(327, 144)
        Me.Controls.Add(Me.cboBenefitCode)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblBenefitCode)
        Me.Controls.Add(Me.stbBenefitName)
        Me.Controls.Add(Me.lblBenefitName)
        Me.Controls.Add(Me.cboItemCategoryID)
        Me.Controls.Add(Me.lblItemCategoryID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMemberBenefits"
        Me.Text = "Member Benefits"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblBenefitCode As System.Windows.Forms.Label
    Friend WithEvents stbBenefitName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBenefitName As System.Windows.Forms.Label
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents cboBenefitCode As ComboBox
End Class