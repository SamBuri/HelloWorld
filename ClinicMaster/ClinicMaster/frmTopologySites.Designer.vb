
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTopologySites : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTopologySites))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboTopologySiteCodeID = New System.Windows.Forms.ComboBox()
        Me.stbTopologySiteName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblTopographicalNo = New System.Windows.Forms.Label()
        Me.lblTopologySiteCodeID = New System.Windows.Forms.Label()
        Me.lblTopologySiteName = New System.Windows.Forms.Label()
        Me.cboTopographicalNo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 206)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 206)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "TopologySites"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 233)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "TopologySites"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboTopologySiteCodeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboTopologySiteCodeID, "TopologySiteCode,TopologySiteCodeID")
        Me.cboTopologySiteCodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTopologySiteCodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTopologySiteCodeID.Location = New System.Drawing.Point(173, 35)
        Me.cboTopologySiteCodeID.Name = "cboTopologySiteCodeID"
        Me.cboTopologySiteCodeID.Size = New System.Drawing.Size(215, 21)
        Me.cboTopologySiteCodeID.TabIndex = 6
        '
        'stbTopologySiteName
        '
        Me.stbTopologySiteName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTopologySiteName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTopologySiteName, "TopologySiteName")
        Me.stbTopologySiteName.EntryErrorMSG = ""
        Me.stbTopologySiteName.Location = New System.Drawing.Point(173, 58)
        Me.stbTopologySiteName.Multiline = True
        Me.stbTopologySiteName.Name = "stbTopologySiteName"
        Me.stbTopologySiteName.RegularExpression = ""
        Me.stbTopologySiteName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTopologySiteName.Size = New System.Drawing.Size(215, 115)
        Me.stbTopologySiteName.TabIndex = 8
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(12, 176)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(171, 20)
        Me.chkHidden.TabIndex = 10
        Me.chkHidden.Text = "Hidden"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 233)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblTopographicalNo
        '
        Me.lblTopographicalNo.Location = New System.Drawing.Point(12, 12)
        Me.lblTopographicalNo.Name = "lblTopographicalNo"
        Me.lblTopographicalNo.Size = New System.Drawing.Size(144, 20)
        Me.lblTopographicalNo.TabIndex = 5
        Me.lblTopographicalNo.Text = "Topographical No"
        '
        'lblTopologySiteCodeID
        '
        Me.lblTopologySiteCodeID.Location = New System.Drawing.Point(12, 35)
        Me.lblTopologySiteCodeID.Name = "lblTopologySiteCodeID"
        Me.lblTopologySiteCodeID.Size = New System.Drawing.Size(144, 20)
        Me.lblTopologySiteCodeID.TabIndex = 7
        Me.lblTopologySiteCodeID.Text = "Topology Site"
        '
        'lblTopologySiteName
        '
        Me.lblTopologySiteName.Location = New System.Drawing.Point(12, 58)
        Me.lblTopologySiteName.Name = "lblTopologySiteName"
        Me.lblTopologySiteName.Size = New System.Drawing.Size(144, 20)
        Me.lblTopologySiteName.TabIndex = 9
        Me.lblTopologySiteName.Text = "Topology Site Name"
        '
        'cboTopographicalNo
        '
        Me.cboTopographicalNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTopographicalNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTopographicalNo.DropDownWidth = 200
        Me.cboTopographicalNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTopographicalNo.FormattingEnabled = True
        Me.cboTopographicalNo.Location = New System.Drawing.Point(173, 8)
        Me.cboTopographicalNo.MaxLength = 64
        Me.cboTopographicalNo.Name = "cboTopographicalNo"
        Me.cboTopographicalNo.Size = New System.Drawing.Size(221, 21)
        Me.cboTopographicalNo.TabIndex = 14
        '
        'frmTopologySites
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 269)
        Me.Controls.Add(Me.cboTopographicalNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblTopographicalNo)
        Me.Controls.Add(Me.cboTopologySiteCodeID)
        Me.Controls.Add(Me.lblTopologySiteCodeID)
        Me.Controls.Add(Me.stbTopologySiteName)
        Me.Controls.Add(Me.lblTopologySiteName)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTopologySites"
        Me.Text = "Topology Sites"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblTopographicalNo As System.Windows.Forms.Label
    Friend WithEvents cboTopologySiteCodeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblTopologySiteCodeID As System.Windows.Forms.Label
    Friend WithEvents stbTopologySiteName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTopologySiteName As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents cboTopographicalNo As ComboBox
End Class