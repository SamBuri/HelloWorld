
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsurancePolicies : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsurancePolicies))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPolicyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboInsuranceNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblPolicyNo = New System.Windows.Forms.Label()
        Me.lblPolicyName = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.cboPolicyNo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 131)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 8
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(287, 130)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 9
        Me.fbnDelete.Tag = "InsurancePolicies"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 158)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 10
        Me.ebnSaveUpdate.Tag = "InsurancePolicies"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPolicyName
        '
        Me.stbPolicyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyName, "PolicyName")
        Me.stbPolicyName.EntryErrorMSG = ""
        Me.stbPolicyName.Location = New System.Drawing.Point(171, 92)
        Me.stbPolicyName.MaxLength = 40
        Me.stbPolicyName.Name = "stbPolicyName"
        Me.stbPolicyName.RegularExpression = ""
        Me.stbPolicyName.Size = New System.Drawing.Size(188, 20)
        Me.stbPolicyName.TabIndex = 7
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(171, 31)
        Me.stbInsuranceName.MaxLength = 60
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(188, 38)
        Me.stbInsuranceName.TabIndex = 3
        '
        'cboInsuranceNo
        '
        Me.cboInsuranceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInsuranceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInsuranceNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboInsuranceNo, "InsuranceNo")
        Me.cboInsuranceNo.DropDownWidth = 256
        Me.cboInsuranceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInsuranceNo.FormattingEnabled = True
        Me.cboInsuranceNo.ItemHeight = 13
        Me.cboInsuranceNo.Location = New System.Drawing.Point(171, 6)
        Me.cboInsuranceNo.Name = "cboInsuranceNo"
        Me.cboInsuranceNo.Size = New System.Drawing.Size(188, 21)
        Me.cboInsuranceNo.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(287, 157)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.Location = New System.Drawing.Point(12, 71)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(151, 20)
        Me.lblPolicyNo.TabIndex = 4
        Me.lblPolicyNo.Text = "Policy No"
        '
        'lblPolicyName
        '
        Me.lblPolicyName.Location = New System.Drawing.Point(12, 92)
        Me.lblPolicyName.Name = "lblPolicyName"
        Me.lblPolicyName.Size = New System.Drawing.Size(151, 20)
        Me.lblPolicyName.TabIndex = 6
        Me.lblPolicyName.Text = "Policy Name"
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
        'lblInsuranceName
        '
        Me.lblInsuranceName.Location = New System.Drawing.Point(12, 40)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(151, 20)
        Me.lblInsuranceName.TabIndex = 2
        Me.lblInsuranceName.Text = "Insurance Name"
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(12, 9)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(151, 20)
        Me.lblInsuranceNo.TabIndex = 0
        Me.lblInsuranceNo.Text = "Insurance Number"
        '
        'cboPolicyNo
        '
        Me.cboPolicyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPolicyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPolicyNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboPolicyNo.DropDownWidth = 256
        Me.cboPolicyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPolicyNo.FormattingEnabled = True
        Me.cboPolicyNo.ItemHeight = 13
        Me.cboPolicyNo.Location = New System.Drawing.Point(171, 70)
        Me.cboPolicyNo.Name = "cboPolicyNo"
        Me.cboPolicyNo.Size = New System.Drawing.Size(188, 21)
        Me.cboPolicyNo.TabIndex = 13
        '
        'frmInsurancePolicies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(376, 198)
        Me.Controls.Add(Me.cboPolicyNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.cboInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceName)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblPolicyNo)
        Me.Controls.Add(Me.stbPolicyName)
        Me.Controls.Add(Me.lblPolicyName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInsurancePolicies"
        Me.Text = "Insurance Policies"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents stbPolicyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyName As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboInsuranceNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents cboPolicyNo As ComboBox
End Class