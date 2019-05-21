
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuppliers : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuppliers))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbContactPerson = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblContactPerson = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 187)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 10
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 187)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 11
        Me.fbnDelete.Tag = "Suppliers"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 214)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 12
        Me.ebnSaveUpdate.Tag = "Suppliers"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSupplierName, "SupplierName")
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(166, 26)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.Size = New System.Drawing.Size(222, 20)
        Me.stbSupplierName.TabIndex = 3
        '
        'stbContactPerson
        '
        Me.stbContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbContactPerson.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbContactPerson, "ContactPerson")
        Me.stbContactPerson.EntryErrorMSG = ""
        Me.stbContactPerson.Location = New System.Drawing.Point(166, 47)
        Me.stbContactPerson.MaxLength = 100
        Me.stbContactPerson.Name = "stbContactPerson"
        Me.stbContactPerson.RegularExpression = ""
        Me.stbContactPerson.Size = New System.Drawing.Size(222, 20)
        Me.stbContactPerson.TabIndex = 5
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(166, 68)
        Me.stbAddress.MaxLength = 200
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(222, 70)
        Me.stbAddress.TabIndex = 7
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(166, 139)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(222, 20)
        Me.stbPhone.TabIndex = 9
        '
        'cboSupplierNo
        '
        Me.cboSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboSupplierNo, "SupplierNo")
        Me.cboSupplierNo.DropDownWidth = 256
        Me.cboSupplierNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSupplierNo.FormattingEnabled = True
        Me.cboSupplierNo.ItemHeight = 13
        Me.cboSupplierNo.Location = New System.Drawing.Point(166, 5)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(222, 21)
        Me.cboSupplierNo.TabIndex = 15
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 214)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 13
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(12, 5)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(148, 20)
        Me.lblSupplierNo.TabIndex = 0
        Me.lblSupplierNo.Text = "Supplier No"
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(12, 26)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(148, 20)
        Me.lblSupplierName.TabIndex = 2
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblContactPerson
        '
        Me.lblContactPerson.Location = New System.Drawing.Point(12, 47)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(148, 20)
        Me.lblContactPerson.TabIndex = 4
        Me.lblContactPerson.Text = "Contact Person"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(12, 89)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(148, 20)
        Me.lblAddress.TabIndex = 6
        Me.lblAddress.Text = "Address"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(12, 139)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(148, 20)
        Me.lblPhone.TabIndex = 8
        Me.lblPhone.Text = "Phone"
        '
        'frmSuppliers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(407, 255)
        Me.Controls.Add(Me.cboSupplierNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblSupplierNo)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.stbContactPerson)
        Me.Controls.Add(Me.lblContactPerson)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSuppliers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suppliers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblSupplierNo As System.Windows.Forms.Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents stbContactPerson As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblContactPerson As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents cboSupplierNo As ComboBox
End Class