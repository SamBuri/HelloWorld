
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHealthUnits : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHealthUnits))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbHealthUnitName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.stbContactPerson = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblHealthUnitCode = New System.Windows.Forms.Label()
        Me.lblHealthUnitName = New System.Windows.Forms.Label()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.lblContactPerson = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.cboHealthUnitCode = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 166)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 12
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 166)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 13
        Me.fbnDelete.Tag = "HealthUnits"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 193)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 14
        Me.ebnSaveUpdate.Tag = "HealthUnits"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbHealthUnitName
        '
        Me.stbHealthUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHealthUnitName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbHealthUnitName, "HealthUnitName")
        Me.stbHealthUnitName.EntryErrorMSG = ""
        Me.stbHealthUnitName.Location = New System.Drawing.Point(194, 33)
        Me.stbHealthUnitName.MaxLength = 41
        Me.stbHealthUnitName.Name = "stbHealthUnitName"
        Me.stbHealthUnitName.RegularExpression = ""
        Me.stbHealthUnitName.Size = New System.Drawing.Size(194, 20)
        Me.stbHealthUnitName.TabIndex = 3
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDistrictsID, "Districts,DistrictsID")
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(194, 55)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(194, 21)
        Me.cboDistrictsID.TabIndex = 5
        '
        'stbContactPerson
        '
        Me.stbContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbContactPerson.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbContactPerson, "ContactPerson")
        Me.stbContactPerson.EntryErrorMSG = ""
        Me.stbContactPerson.Location = New System.Drawing.Point(194, 78)
        Me.stbContactPerson.MaxLength = 100
        Me.stbContactPerson.Name = "stbContactPerson"
        Me.stbContactPerson.RegularExpression = ""
        Me.stbContactPerson.Size = New System.Drawing.Size(194, 20)
        Me.stbContactPerson.TabIndex = 7
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(194, 99)
        Me.stbAddress.MaxLength = 200
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(194, 36)
        Me.stbAddress.TabIndex = 9
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(194, 136)
        Me.stbPhone.MaxLength = 100
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(194, 20)
        Me.stbPhone.TabIndex = 11
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 193)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 15
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblHealthUnitCode
        '
        Me.lblHealthUnitCode.Location = New System.Drawing.Point(12, 12)
        Me.lblHealthUnitCode.Name = "lblHealthUnitCode"
        Me.lblHealthUnitCode.Size = New System.Drawing.Size(158, 20)
        Me.lblHealthUnitCode.TabIndex = 0
        Me.lblHealthUnitCode.Text = "Health Unit Code"
        '
        'lblHealthUnitName
        '
        Me.lblHealthUnitName.Location = New System.Drawing.Point(12, 33)
        Me.lblHealthUnitName.Name = "lblHealthUnitName"
        Me.lblHealthUnitName.Size = New System.Drawing.Size(158, 20)
        Me.lblHealthUnitName.TabIndex = 2
        Me.lblHealthUnitName.Text = "Health Unit Name"
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Location = New System.Drawing.Point(12, 55)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(158, 20)
        Me.lblDistrictsID.TabIndex = 4
        Me.lblDistrictsID.Text = "District"
        '
        'lblContactPerson
        '
        Me.lblContactPerson.Location = New System.Drawing.Point(12, 78)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(158, 20)
        Me.lblContactPerson.TabIndex = 6
        Me.lblContactPerson.Text = "Contact Person"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(12, 108)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(158, 20)
        Me.lblAddress.TabIndex = 8
        Me.lblAddress.Text = "Address"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(12, 136)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(158, 20)
        Me.lblPhone.TabIndex = 10
        Me.lblPhone.Text = "Phone"
        '
        'cboHealthUnitCode
        '
        Me.cboHealthUnitCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHealthUnitCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboHealthUnitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnitCode.Location = New System.Drawing.Point(194, 9)
        Me.cboHealthUnitCode.Name = "cboHealthUnitCode"
        Me.cboHealthUnitCode.Size = New System.Drawing.Size(194, 21)
        Me.cboHealthUnitCode.TabIndex = 17
        '
        'frmHealthUnits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 239)
        Me.Controls.Add(Me.cboHealthUnitCode)
        Me.Controls.Add(Me.stbContactPerson)
        Me.Controls.Add(Me.lblContactPerson)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblHealthUnitCode)
        Me.Controls.Add(Me.stbHealthUnitName)
        Me.Controls.Add(Me.lblHealthUnitName)
        Me.Controls.Add(Me.cboDistrictsID)
        Me.Controls.Add(Me.lblDistrictsID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmHealthUnits"
        Me.Text = "Health Units"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblHealthUnitCode As System.Windows.Forms.Label
    Friend WithEvents stbHealthUnitName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHealthUnitName As System.Windows.Forms.Label
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents stbContactPerson As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblContactPerson As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents cboHealthUnitCode As ComboBox
End Class