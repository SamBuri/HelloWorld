
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankAccounts : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankAccounts))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBankNameID = New System.Windows.Forms.ComboBox()
        Me.cboCurrencyID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblBankNameID = New System.Windows.Forms.Label()
        Me.lblCurrencyID = New System.Windows.Forms.Label()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 114)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 114)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 12
        Me.fbnDelete.Tag = "BankAccounts"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 141)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 11
        Me.ebnSaveUpdate.Tag = "BankAccounts"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAccountName, "AccountName")
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(218, 33)
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(170, 20)
        Me.stbAccountName.TabIndex = 3
        '
        'cboBankNameID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBankNameID, "BankName,BankNameID")
        Me.cboBankNameID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankNameID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBankNameID.Location = New System.Drawing.Point(218, 55)
        Me.cboBankNameID.Name = "cboBankNameID"
        Me.cboBankNameID.Size = New System.Drawing.Size(170, 21)
        Me.cboBankNameID.TabIndex = 5
        '
        'cboCurrencyID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCurrencyID, "Currency,CurrencyID")
        Me.cboCurrencyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrencyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrencyID.Location = New System.Drawing.Point(218, 78)
        Me.cboCurrencyID.Name = "cboCurrencyID"
        Me.cboCurrencyID.Size = New System.Drawing.Size(170, 21)
        Me.cboCurrencyID.TabIndex = 7
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 141)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 13
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(12, 12)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountNo.TabIndex = 0
        Me.lblAccountNo.Text = "Account No"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(12, 33)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountName.TabIndex = 2
        Me.lblAccountName.Text = "Account Name"
        '
        'lblBankNameID
        '
        Me.lblBankNameID.Location = New System.Drawing.Point(12, 55)
        Me.lblBankNameID.Name = "lblBankNameID"
        Me.lblBankNameID.Size = New System.Drawing.Size(200, 20)
        Me.lblBankNameID.TabIndex = 4
        Me.lblBankNameID.Text = "Bank Name"
        '
        'lblCurrencyID
        '
        Me.lblCurrencyID.Location = New System.Drawing.Point(12, 78)
        Me.lblCurrencyID.Name = "lblCurrencyID"
        Me.lblCurrencyID.Size = New System.Drawing.Size(200, 20)
        Me.lblCurrencyID.TabIndex = 6
        Me.lblCurrencyID.Text = "Currency"
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.stbAccountNo.DecimalPlaces = -1
        Me.stbAccountNo.DenyNegativeEntryValue = True
        Me.stbAccountNo.DenyZeroEntryValue = True
        Me.stbAccountNo.Location = New System.Drawing.Point(218, 10)
        Me.stbAccountNo.MaxLength = 17
        Me.stbAccountNo.MaxValue = 0.0R
        Me.stbAccountNo.MinValue = 0.0R
        Me.stbAccountNo.MustEnterNumeric = True
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.Size = New System.Drawing.Size(169, 20)
        Me.stbAccountNo.TabIndex = 1
        Me.stbAccountNo.Value = ""
        '
        'frmBankAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(406, 180)
        Me.Controls.Add(Me.stbAccountNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.cboBankNameID)
        Me.Controls.Add(Me.lblBankNameID)
        Me.Controls.Add(Me.cboCurrencyID)
        Me.Controls.Add(Me.lblCurrencyID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBankAccounts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BankAccounts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents cboBankNameID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBankNameID As System.Windows.Forms.Label
    Friend WithEvents cboCurrencyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrencyID As System.Windows.Forms.Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.NumericBox
End Class