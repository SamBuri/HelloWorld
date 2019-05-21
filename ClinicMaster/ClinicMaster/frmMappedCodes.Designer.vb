
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMappedCodes : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMappedCodes))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbItemCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.stbCustomCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCustomCode = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 190)
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
        Me.fbnDelete.Location = New System.Drawing.Point(317, 190)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "MappedCodes"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 217)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "MappedCodes"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboItemCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboItemCategoryID, "ItemCategory,ItemCategoryID")
        Me.cboItemCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.Location = New System.Drawing.Point(183, 139)
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(205, 21)
        Me.cboItemCategoryID.TabIndex = 16
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(317, 217)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbItemCode
        '
        Me.stbItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemCode.CapitalizeFirstLetter = True
        Me.stbItemCode.EntryErrorMSG = ""
        Me.stbItemCode.Location = New System.Drawing.Point(183, 117)
        Me.stbItemCode.Name = "stbItemCode"
        Me.stbItemCode.RegularExpression = ""
        Me.stbItemCode.Size = New System.Drawing.Size(205, 20)
        Me.stbItemCode.TabIndex = 6
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(13, 119)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(149, 20)
        Me.lblItemCode.TabIndex = 7
        Me.lblItemCode.Text = "Item Code"
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(14, 143)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(149, 20)
        Me.lblItemCategoryID.TabIndex = 9
        Me.lblItemCategoryID.Text = "Item Category"
        '
        'stbCustomCode
        '
        Me.stbCustomCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCustomCode.CapitalizeFirstLetter = True
        Me.stbCustomCode.EntryErrorMSG = ""
        Me.stbCustomCode.Location = New System.Drawing.Point(183, 164)
        Me.stbCustomCode.Name = "stbCustomCode"
        Me.stbCustomCode.RegularExpression = ""
        Me.stbCustomCode.Size = New System.Drawing.Size(205, 20)
        Me.stbCustomCode.TabIndex = 10
        '
        'lblCustomCode
        '
        Me.lblCustomCode.Location = New System.Drawing.Point(13, 166)
        Me.lblCustomCode.Name = "lblCustomCode"
        Me.lblCustomCode.Size = New System.Drawing.Size(149, 20)
        Me.lblCustomCode.TabIndex = 11
        Me.lblCustomCode.Text = "Custom Code"
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.DropDownWidth = 300
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.Location = New System.Drawing.Point(183, 12)
        Me.cboAccountNo.MaxLength = 40
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(205, 21)
        Me.cboAccountNo.TabIndex = 13
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = True
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(183, 38)
        Me.stbBillCustomerName.MaxLength = 40
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(205, 77)
        Me.stbBillCustomerName.TabIndex = 15
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(14, 37)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(149, 20)
        Me.lblBillCustomerName.TabIndex = 14
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(14, 9)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(149, 20)
        Me.lblAccountNo.TabIndex = 12
        Me.lblAccountNo.Text = "Account Number"
        '
        'frmMappedCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(401, 252)
        Me.Controls.Add(Me.cboItemCategoryID)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.lblItemCategoryID)
        Me.Controls.Add(Me.stbCustomCode)
        Me.Controls.Add(Me.lblCustomCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMappedCodes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Code Mapping"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbItemCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents stbCustomCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCustomCode As System.Windows.Forms.Label
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox

End Class