
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVillages : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVillages))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbVillageName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboParishCode = New System.Windows.Forms.ComboBox()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.cboSubCountyCode = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblVillageCode = New System.Windows.Forms.Label()
        Me.lblVillageName = New System.Windows.Forms.Label()
        Me.lblParishCode = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.lblSubCountyCode = New System.Windows.Forms.Label()
        Me.grpLocation = New System.Windows.Forms.GroupBox()
        Me.lblCountyCode = New System.Windows.Forms.Label()
        Me.cboCountyCode = New System.Windows.Forms.ComboBox()
        Me.cboVillageCode = New System.Windows.Forms.ComboBox()
        Me.grpLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 174)
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
        Me.fbnDelete.Location = New System.Drawing.Point(261, 173)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 6
        Me.fbnDelete.Tag = "Villages"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 201)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 7
        Me.ebnSaveUpdate.Tag = "Villages"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbVillageName
        '
        Me.stbVillageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVillageName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbVillageName, "VillageName")
        Me.stbVillageName.EntryErrorMSG = ""
        Me.stbVillageName.Location = New System.Drawing.Point(163, 145)
        Me.stbVillageName.MaxLength = 41
        Me.stbVillageName.Name = "stbVillageName"
        Me.stbVillageName.RegularExpression = ""
        Me.stbVillageName.Size = New System.Drawing.Size(170, 20)
        Me.stbVillageName.TabIndex = 4
        '
        'cboParishCode
        '
        Me.cboParishCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboParishCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboParishCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParishCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboParishCode.Location = New System.Drawing.Point(151, 86)
        Me.cboParishCode.Name = "cboParishCode"
        Me.cboParishCode.Size = New System.Drawing.Size(170, 21)
        Me.cboParishCode.TabIndex = 7
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(151, 16)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(170, 21)
        Me.cboDistrictsID.TabIndex = 1
        '
        'cboSubCountyCode
        '
        Me.cboSubCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSubCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSubCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubCountyCode.Location = New System.Drawing.Point(151, 63)
        Me.cboSubCountyCode.Name = "cboSubCountyCode"
        Me.cboSubCountyCode.Size = New System.Drawing.Size(170, 21)
        Me.cboSubCountyCode.TabIndex = 5
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(261, 200)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblVillageCode
        '
        Me.lblVillageCode.Location = New System.Drawing.Point(24, 124)
        Me.lblVillageCode.Name = "lblVillageCode"
        Me.lblVillageCode.Size = New System.Drawing.Size(122, 20)
        Me.lblVillageCode.TabIndex = 1
        Me.lblVillageCode.Text = "Village Code"
        '
        'lblVillageName
        '
        Me.lblVillageName.Location = New System.Drawing.Point(24, 145)
        Me.lblVillageName.Name = "lblVillageName"
        Me.lblVillageName.Size = New System.Drawing.Size(122, 20)
        Me.lblVillageName.TabIndex = 3
        Me.lblVillageName.Text = "Village Name"
        '
        'lblParishCode
        '
        Me.lblParishCode.Location = New System.Drawing.Point(12, 86)
        Me.lblParishCode.Name = "lblParishCode"
        Me.lblParishCode.Size = New System.Drawing.Size(122, 20)
        Me.lblParishCode.TabIndex = 6
        Me.lblParishCode.Text = "Parish"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Location = New System.Drawing.Point(12, 17)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(122, 20)
        Me.lblDistrictsID.TabIndex = 0
        Me.lblDistrictsID.Text = "District"
        '
        'lblSubCountyCode
        '
        Me.lblSubCountyCode.Location = New System.Drawing.Point(12, 63)
        Me.lblSubCountyCode.Name = "lblSubCountyCode"
        Me.lblSubCountyCode.Size = New System.Drawing.Size(122, 20)
        Me.lblSubCountyCode.TabIndex = 4
        Me.lblSubCountyCode.Text = "Sub County"
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.lblCountyCode)
        Me.grpLocation.Controls.Add(Me.cboCountyCode)
        Me.grpLocation.Controls.Add(Me.cboDistrictsID)
        Me.grpLocation.Controls.Add(Me.lblParishCode)
        Me.grpLocation.Controls.Add(Me.lblDistrictsID)
        Me.grpLocation.Controls.Add(Me.cboParishCode)
        Me.grpLocation.Controls.Add(Me.lblSubCountyCode)
        Me.grpLocation.Controls.Add(Me.cboSubCountyCode)
        Me.grpLocation.Location = New System.Drawing.Point(12, 5)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(327, 115)
        Me.grpLocation.TabIndex = 0
        Me.grpLocation.TabStop = False
        Me.grpLocation.Text = "Location"
        '
        'lblCountyCode
        '
        Me.lblCountyCode.Location = New System.Drawing.Point(12, 42)
        Me.lblCountyCode.Name = "lblCountyCode"
        Me.lblCountyCode.Size = New System.Drawing.Size(122, 20)
        Me.lblCountyCode.TabIndex = 2
        Me.lblCountyCode.Text = "County"
        '
        'cboCountyCode
        '
        Me.cboCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCountyCode.Location = New System.Drawing.Point(151, 39)
        Me.cboCountyCode.Name = "cboCountyCode"
        Me.cboCountyCode.Size = New System.Drawing.Size(170, 21)
        Me.cboCountyCode.TabIndex = 3
        '
        'cboVillageCode
        '
        Me.cboVillageCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVillageCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVillageCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVillageCode.Location = New System.Drawing.Point(163, 121)
        Me.cboVillageCode.Name = "cboVillageCode"
        Me.cboVillageCode.Size = New System.Drawing.Size(170, 21)
        Me.cboVillageCode.TabIndex = 9
        '
        'frmVillages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(351, 242)
        Me.Controls.Add(Me.cboVillageCode)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblVillageCode)
        Me.Controls.Add(Me.stbVillageName)
        Me.Controls.Add(Me.lblVillageName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmVillages"
        Me.Text = "Villages"
        Me.grpLocation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblVillageCode As System.Windows.Forms.Label
    Friend WithEvents stbVillageName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVillageName As System.Windows.Forms.Label
    Friend WithEvents cboParishCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblParishCode As System.Windows.Forms.Label
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents cboSubCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblSubCountyCode As System.Windows.Forms.Label
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents lblCountyCode As System.Windows.Forms.Label
    Friend WithEvents cboCountyCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboVillageCode As ComboBox
End Class