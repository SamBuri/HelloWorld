
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhysioDiseases : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhysioDiseases))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbDiseaseName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboPhysioDiseaseCategoriesID = New System.Windows.Forms.ComboBox()
        Me.stbDiseaseCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPhysioDiseaseNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDiseaseNo = New System.Windows.Forms.Label()
        Me.lblDiseaseName = New System.Windows.Forms.Label()
        Me.lblPhysioDiseaseCategoriesID = New System.Windows.Forms.Label()
        Me.lblDiseaseCode = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 157)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 157)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "PhysioDiseases"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 184)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "PhysioDiseases"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbDiseaseName
        '
        Me.stbDiseaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiseaseName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiseaseName, "DiseaseName")
        Me.stbDiseaseName.EntryErrorMSG = ""
        Me.stbDiseaseName.Location = New System.Drawing.Point(218, 81)
        Me.stbDiseaseName.Multiline = True
        Me.stbDiseaseName.Name = "stbDiseaseName"
        Me.stbDiseaseName.RegularExpression = ""
        Me.stbDiseaseName.Size = New System.Drawing.Size(170, 70)
        Me.stbDiseaseName.TabIndex = 10
        '
        'cboPhysioDiseaseCategoriesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPhysioDiseaseCategoriesID, "PhysioDiseaseCategories,PhysioDiseaseCategoriesID")
        Me.cboPhysioDiseaseCategoriesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPhysioDiseaseCategoriesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPhysioDiseaseCategoriesID.Location = New System.Drawing.Point(218, 12)
        Me.cboPhysioDiseaseCategoriesID.Name = "cboPhysioDiseaseCategoriesID"
        Me.cboPhysioDiseaseCategoriesID.Size = New System.Drawing.Size(170, 21)
        Me.cboPhysioDiseaseCategoriesID.TabIndex = 12
        '
        'stbDiseaseCode
        '
        Me.stbDiseaseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiseaseCode.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiseaseCode, "DiseaseCode")
        Me.stbDiseaseCode.EntryErrorMSG = ""
        Me.stbDiseaseCode.Location = New System.Drawing.Point(218, 37)
        Me.stbDiseaseCode.Name = "stbDiseaseCode"
        Me.stbDiseaseCode.RegularExpression = ""
        Me.stbDiseaseCode.Size = New System.Drawing.Size(170, 20)
        Me.stbDiseaseCode.TabIndex = 14
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 184)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPhysioDiseaseNo
        '
        Me.stbPhysioDiseaseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhysioDiseaseNo.CapitalizeFirstLetter = False
        Me.stbPhysioDiseaseNo.EntryErrorMSG = ""
        Me.stbPhysioDiseaseNo.Location = New System.Drawing.Point(218, 59)
        Me.stbPhysioDiseaseNo.Name = "stbPhysioDiseaseNo"
        Me.stbPhysioDiseaseNo.RegularExpression = ""
        Me.stbPhysioDiseaseNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPhysioDiseaseNo.TabIndex = 6
        '
        'lblDiseaseNo
        '
        Me.lblDiseaseNo.Location = New System.Drawing.Point(12, 58)
        Me.lblDiseaseNo.Name = "lblDiseaseNo"
        Me.lblDiseaseNo.Size = New System.Drawing.Size(200, 20)
        Me.lblDiseaseNo.TabIndex = 7
        Me.lblDiseaseNo.Text = "Disease No"
        '
        'lblDiseaseName
        '
        Me.lblDiseaseName.Location = New System.Drawing.Point(12, 81)
        Me.lblDiseaseName.Name = "lblDiseaseName"
        Me.lblDiseaseName.Size = New System.Drawing.Size(200, 20)
        Me.lblDiseaseName.TabIndex = 11
        Me.lblDiseaseName.Text = "Disease Name"
        '
        'lblPhysioDiseaseCategoriesID
        '
        Me.lblPhysioDiseaseCategoriesID.Location = New System.Drawing.Point(12, 12)
        Me.lblPhysioDiseaseCategoriesID.Name = "lblPhysioDiseaseCategoriesID"
        Me.lblPhysioDiseaseCategoriesID.Size = New System.Drawing.Size(200, 20)
        Me.lblPhysioDiseaseCategoriesID.TabIndex = 13
        Me.lblPhysioDiseaseCategoriesID.Text = "Physiotherapy Disease Categories"
        '
        'lblDiseaseCode
        '
        Me.lblDiseaseCode.Location = New System.Drawing.Point(14, 36)
        Me.lblDiseaseCode.Name = "lblDiseaseCode"
        Me.lblDiseaseCode.Size = New System.Drawing.Size(200, 20)
        Me.lblDiseaseCode.TabIndex = 15
        Me.lblDiseaseCode.Text = "Disease Code"
        '
        'frmPhysioDiseases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 234)
        Me.Controls.Add(Me.stbDiseaseCode)
        Me.Controls.Add(Me.lblDiseaseCode)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPhysioDiseaseNo)
        Me.Controls.Add(Me.lblDiseaseNo)
        Me.Controls.Add(Me.stbDiseaseName)
        Me.Controls.Add(Me.lblDiseaseName)
        Me.Controls.Add(Me.cboPhysioDiseaseCategoriesID)
        Me.Controls.Add(Me.lblPhysioDiseaseCategoriesID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPhysioDiseases"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "PhysioDiseases"
        Me.Text = "Physio Diseases"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPhysioDiseaseNo As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblDiseaseNo As System.Windows.Forms.Label
    Friend WithEvents stbDiseaseName As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblDiseaseName As System.Windows.Forms.Label
Friend WithEvents cboPhysioDiseaseCategoriesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPhysioDiseaseCategoriesID As System.Windows.Forms.Label
    Friend WithEvents stbDiseaseCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiseaseCode As System.Windows.Forms.Label

End Class