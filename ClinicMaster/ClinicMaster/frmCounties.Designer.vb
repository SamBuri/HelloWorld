
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCounties : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCounties))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbCountyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblCountyCode = New System.Windows.Forms.Label()
        Me.lblCountyName = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.grpLocation = New System.Windows.Forms.GroupBox()
        Me.cboCountyCode = New System.Windows.Forms.ComboBox()
        Me.grpLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 113)
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
        Me.fbnDelete.Location = New System.Drawing.Point(248, 112)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 6
        Me.fbnDelete.Tag = "Counties"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 140)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 7
        Me.ebnSaveUpdate.Tag = "Counties"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbCountyName
        '
        Me.stbCountyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCountyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCountyName, "CountyName")
        Me.stbCountyName.EntryErrorMSG = ""
        Me.stbCountyName.Location = New System.Drawing.Point(150, 79)
        Me.stbCountyName.MaxLength = 41
        Me.stbCountyName.Name = "stbCountyName"
        Me.stbCountyName.RegularExpression = ""
        Me.stbCountyName.Size = New System.Drawing.Size(170, 20)
        Me.stbCountyName.TabIndex = 4
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDistrictsID, "Districts,DistrictsID")
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(143, 17)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(170, 21)
        Me.cboDistrictsID.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(248, 139)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblCountyCode
        '
        Me.lblCountyCode.Location = New System.Drawing.Point(11, 56)
        Me.lblCountyCode.Name = "lblCountyCode"
        Me.lblCountyCode.Size = New System.Drawing.Size(122, 20)
        Me.lblCountyCode.TabIndex = 1
        Me.lblCountyCode.Text = "County Code"
        '
        'lblCountyName
        '
        Me.lblCountyName.Location = New System.Drawing.Point(11, 79)
        Me.lblCountyName.Name = "lblCountyName"
        Me.lblCountyName.Size = New System.Drawing.Size(122, 20)
        Me.lblCountyName.TabIndex = 3
        Me.lblCountyName.Text = "County Name"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Location = New System.Drawing.Point(6, 20)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(122, 20)
        Me.lblDistrictsID.TabIndex = 0
        Me.lblDistrictsID.Text = "District"
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.cboDistrictsID)
        Me.grpLocation.Controls.Add(Me.lblDistrictsID)
        Me.grpLocation.Location = New System.Drawing.Point(7, 7)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(327, 46)
        Me.grpLocation.TabIndex = 0
        Me.grpLocation.TabStop = False
        Me.grpLocation.Text = "Location"
        '
        'cboCountyCode
        '
        Me.cboCountyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCountyCode.Location = New System.Drawing.Point(150, 55)
        Me.cboCountyCode.Name = "cboCountyCode"
        Me.cboCountyCode.Size = New System.Drawing.Size(170, 21)
        Me.cboCountyCode.TabIndex = 9
        '
        'frmCounties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(345, 180)
        Me.Controls.Add(Me.cboCountyCode)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblCountyCode)
        Me.Controls.Add(Me.stbCountyName)
        Me.Controls.Add(Me.lblCountyName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCounties"
        Me.Text = "Counties"
        Me.grpLocation.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblCountyCode As System.Windows.Forms.Label
    Friend WithEvents stbCountyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCountyName As System.Windows.Forms.Label
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents cboCountyCode As ComboBox
End Class