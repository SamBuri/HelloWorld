
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabTestsEXTPossibleResults : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabTestsEXTPossibleResults))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbTestName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcPossibleResultsItems = New System.Windows.Forms.TabControl()
        Me.tpgPossibleLabResults = New System.Windows.Forms.TabPage()
        Me.dgvLabTestsEXT = New System.Windows.Forms.DataGridView()
        Me.cboTestCode = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTestName = New System.Windows.Forms.Label()
        Me.colsubtestCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPossibleResults = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabEXTSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbcPossibleResultsItems.SuspendLayout()
        Me.tpgPossibleLabResults.SuspendLayout()
        CType(Me.dgvLabTestsEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(6, 297)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Enabled = False
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(515, 297)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "LabTestsEXTPossibleResults"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(6, 324)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "LabTestsEXTPossibleResults"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbTestName
        '
        Me.stbTestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTestName.CapitalizeFirstLetter = True
        Me.stbTestName.Enabled = False
        Me.stbTestName.EntryErrorMSG = ""
        Me.stbTestName.Location = New System.Drawing.Point(142, 36)
        Me.stbTestName.MaxLength = 100
        Me.stbTestName.Name = "stbTestName"
        Me.stbTestName.RegularExpression = ""
        Me.stbTestName.Size = New System.Drawing.Size(209, 20)
        Me.stbTestName.TabIndex = 14
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(515, 324)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'tbcPossibleResultsItems
        '
        Me.tbcPossibleResultsItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPossibleResultsItems.Controls.Add(Me.tpgPossibleLabResults)
        Me.tbcPossibleResultsItems.HotTrack = True
        Me.tbcPossibleResultsItems.Location = New System.Drawing.Point(8, 62)
        Me.tbcPossibleResultsItems.Name = "tbcPossibleResultsItems"
        Me.tbcPossibleResultsItems.SelectedIndex = 0
        Me.tbcPossibleResultsItems.Size = New System.Drawing.Size(587, 225)
        Me.tbcPossibleResultsItems.TabIndex = 10
        '
        'tpgPossibleLabResults
        '
        Me.tpgPossibleLabResults.Controls.Add(Me.dgvLabTestsEXT)
        Me.tpgPossibleLabResults.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleLabResults.Name = "tpgPossibleLabResults"
        Me.tpgPossibleLabResults.Size = New System.Drawing.Size(579, 199)
        Me.tpgPossibleLabResults.TabIndex = 5
        Me.tpgPossibleLabResults.Text = "Possible Lab Results"
        Me.tpgPossibleLabResults.UseVisualStyleBackColor = True
        '
        'dgvLabTestsEXT
        '
        Me.dgvLabTestsEXT.AllowUserToOrderColumns = True
        Me.dgvLabTestsEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTestsEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLabTestsEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colsubtestCode, Me.colPossibleResults, Me.colLabEXTSaved})
        Me.dgvLabTestsEXT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabTestsEXT.EnableHeadersVisualStyles = False
        Me.dgvLabTestsEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabTestsEXT.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabTestsEXT.Location = New System.Drawing.Point(0, 0)
        Me.dgvLabTestsEXT.Name = "dgvLabTestsEXT"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTestsEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvLabTestsEXT.Size = New System.Drawing.Size(579, 199)
        Me.dgvLabTestsEXT.TabIndex = 24
        Me.dgvLabTestsEXT.Text = "DataGridView1"
        '
        'cboTestCode
        '
        Me.cboTestCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTestCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTestCode.DropDownWidth = 350
        Me.cboTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTestCode.FormattingEnabled = True
        Me.cboTestCode.Location = New System.Drawing.Point(142, 12)
        Me.cboTestCode.MaxLength = 40
        Me.cboTestCode.Name = "cboTestCode"
        Me.cboTestCode.Size = New System.Drawing.Size(209, 21)
        Me.cboTestCode.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(15, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 21)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Test Code"
        '
        'lblTestName
        '
        Me.lblTestName.Location = New System.Drawing.Point(15, 36)
        Me.lblTestName.Name = "lblTestName"
        Me.lblTestName.Size = New System.Drawing.Size(121, 21)
        Me.lblTestName.TabIndex = 13
        Me.lblTestName.Text = "Test Name"
        '
        'colsubtestCode
        '
        Me.colsubtestCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colsubtestCode.DataPropertyName = "TestFullName"
        Me.colsubtestCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colsubtestCode.DisplayStyleForCurrentCellOnly = True
        Me.colsubtestCode.FillWeight = 68.02721!
        Me.colsubtestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colsubtestCode.HeaderText = "Sub Test Name"
        Me.colsubtestCode.Name = "colsubtestCode"
        Me.colsubtestCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colPossibleResults
        '
        Me.colPossibleResults.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPossibleResults.DataPropertyName = "PossibleResults"
        Me.colPossibleResults.FillWeight = 131.9728!
        Me.colPossibleResults.HeaderText = "Possibe Results"
        Me.colPossibleResults.MaxInputLength = 200
        Me.colPossibleResults.Name = "colPossibleResults"
        '
        'colLabEXTSaved
        '
        Me.colLabEXTSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colLabEXTSaved.DefaultCellStyle = DataGridViewCellStyle2
        Me.colLabEXTSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colLabEXTSaved.HeaderText = "Saved"
        Me.colLabEXTSaved.Name = "colLabEXTSaved"
        Me.colLabEXTSaved.ReadOnly = True
        Me.colLabEXTSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colLabEXTSaved.Width = 50
        '
        'frmLabTestsEXTPossibleResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(607, 356)
        Me.Controls.Add(Me.cboTestCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTestName)
        Me.Controls.Add(Me.stbTestName)
        Me.Controls.Add(Me.tbcPossibleResultsItems)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLabTestsEXTPossibleResults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Possible Lab Results (Sub Tests)"
        Me.tbcPossibleResultsItems.ResumeLayout(False)
        Me.tpgPossibleLabResults.ResumeLayout(False)
        CType(Me.dgvLabTestsEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcPossibleResultsItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgPossibleLabResults As System.Windows.Forms.TabPage
    Friend WithEvents dgvLabTestsEXT As System.Windows.Forms.DataGridView
    Friend WithEvents cboTestCode As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTestName As System.Windows.Forms.Label
    Friend WithEvents stbTestName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents colsubtestCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPossibleResults As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabEXTSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class