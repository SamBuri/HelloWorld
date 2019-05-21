
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancerDiseases : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancerDiseases))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbDiseaseCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDiseaseName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCancerDiseaseCategoriesID = New System.Windows.Forms.ComboBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDiseaseNo = New System.Windows.Forms.Label()
        Me.lblDiseaseCode = New System.Windows.Forms.Label()
        Me.lblDiseaseName = New System.Windows.Forms.Label()
        Me.lblCancerDiseaseCategoriesID = New System.Windows.Forms.Label()
        Me.cboDiseaseNo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(32, 255)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 11
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(331, 255)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 12
        Me.fbnDelete.Tag = "CancerDiseases"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(32, 282)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 9
        Me.ebnSaveUpdate.Tag = "CancerDiseases"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbDiseaseCode
        '
        Me.stbDiseaseCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiseaseCode.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiseaseCode, "DiseaseCode")
        Me.stbDiseaseCode.Enabled = False
        Me.stbDiseaseCode.EntryErrorMSG = ""
        Me.stbDiseaseCode.Location = New System.Drawing.Point(167, 39)
        Me.stbDiseaseCode.Name = "stbDiseaseCode"
        Me.stbDiseaseCode.ReadOnly = True
        Me.stbDiseaseCode.RegularExpression = ""
        Me.stbDiseaseCode.Size = New System.Drawing.Size(221, 20)
        Me.stbDiseaseCode.TabIndex = 3
        '
        'stbDiseaseName
        '
        Me.stbDiseaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiseaseName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiseaseName, "DiseaseName")
        Me.stbDiseaseName.EntryErrorMSG = ""
        Me.stbDiseaseName.Location = New System.Drawing.Point(167, 84)
        Me.stbDiseaseName.Multiline = True
        Me.stbDiseaseName.Name = "stbDiseaseName"
        Me.stbDiseaseName.RegularExpression = ""
        Me.stbDiseaseName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDiseaseName.Size = New System.Drawing.Size(221, 132)
        Me.stbDiseaseName.TabIndex = 7
        '
        'cboCancerDiseaseCategoriesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCancerDiseaseCategoriesID, "CancerDiseaseCategories,CancerDiseaseCategoriesID")
        Me.cboCancerDiseaseCategoriesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCancerDiseaseCategoriesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCancerDiseaseCategoriesID.Location = New System.Drawing.Point(167, 14)
        Me.cboCancerDiseaseCategoriesID.Name = "cboCancerDiseaseCategoriesID"
        Me.cboCancerDiseaseCategoriesID.Size = New System.Drawing.Size(221, 21)
        Me.cboCancerDiseaseCategoriesID.TabIndex = 5
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(12, 224)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(163, 20)
        Me.chkHidden.TabIndex = 8
        Me.chkHidden.Text = "Hidden"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(331, 282)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 10
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDiseaseNo
        '
        Me.lblDiseaseNo.Location = New System.Drawing.Point(12, 61)
        Me.lblDiseaseNo.Name = "lblDiseaseNo"
        Me.lblDiseaseNo.Size = New System.Drawing.Size(149, 20)
        Me.lblDiseaseNo.TabIndex = 0
        Me.lblDiseaseNo.Text = "Disease No"
        '
        'lblDiseaseCode
        '
        Me.lblDiseaseCode.Location = New System.Drawing.Point(12, 39)
        Me.lblDiseaseCode.Name = "lblDiseaseCode"
        Me.lblDiseaseCode.Size = New System.Drawing.Size(149, 20)
        Me.lblDiseaseCode.TabIndex = 2
        Me.lblDiseaseCode.Text = "Disease Code"
        '
        'lblDiseaseName
        '
        Me.lblDiseaseName.Location = New System.Drawing.Point(12, 84)
        Me.lblDiseaseName.Name = "lblDiseaseName"
        Me.lblDiseaseName.Size = New System.Drawing.Size(149, 20)
        Me.lblDiseaseName.TabIndex = 6
        Me.lblDiseaseName.Text = "Disease Name"
        '
        'lblCancerDiseaseCategoriesID
        '
        Me.lblCancerDiseaseCategoriesID.Location = New System.Drawing.Point(12, 14)
        Me.lblCancerDiseaseCategoriesID.Name = "lblCancerDiseaseCategoriesID"
        Me.lblCancerDiseaseCategoriesID.Size = New System.Drawing.Size(149, 20)
        Me.lblCancerDiseaseCategoriesID.TabIndex = 4
        Me.lblCancerDiseaseCategoriesID.Text = "Cancer Disease Category"
        '
        'cboDiseaseNo
        '
        Me.cboDiseaseNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDiseaseNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiseaseNo.DropDownWidth = 200
        Me.cboDiseaseNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiseaseNo.FormattingEnabled = True
        Me.cboDiseaseNo.Location = New System.Drawing.Point(167, 61)
        Me.cboDiseaseNo.MaxLength = 64
        Me.cboDiseaseNo.Name = "cboDiseaseNo"
        Me.cboDiseaseNo.Size = New System.Drawing.Size(221, 21)
        Me.cboDiseaseNo.TabIndex = 13
        '
        'frmCancerDiseases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 320)
        Me.Controls.Add(Me.cboDiseaseNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblDiseaseNo)
        Me.Controls.Add(Me.stbDiseaseCode)
        Me.Controls.Add(Me.lblDiseaseCode)
        Me.Controls.Add(Me.stbDiseaseName)
        Me.Controls.Add(Me.lblDiseaseName)
        Me.Controls.Add(Me.cboCancerDiseaseCategoriesID)
        Me.Controls.Add(Me.lblCancerDiseaseCategoriesID)
        Me.Controls.Add(Me.chkHidden)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCancerDiseases"
        Me.Text = "Cancer Diseases"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDiseaseNo As System.Windows.Forms.Label
    Friend WithEvents stbDiseaseCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiseaseCode As System.Windows.Forms.Label
    Friend WithEvents stbDiseaseName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiseaseName As System.Windows.Forms.Label
    Friend WithEvents cboCancerDiseaseCategoriesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCancerDiseaseCategoriesID As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents cboDiseaseNo As ComboBox
End Class