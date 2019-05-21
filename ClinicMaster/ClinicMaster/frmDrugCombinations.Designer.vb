<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrugCombinations
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugCombinations))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbCombinationDes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblCombinationDes = New System.Windows.Forms.Label()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.dgvDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboCombination = New System.Windows.Forms.ComboBox()
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(16, 336)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(352, 335)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Tag = "DrugCombinations"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 365)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 7
        Me.ebnSaveUpdate.Tag = "DrugCombinations"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbCombinationDes
        '
        Me.stbCombinationDes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombinationDes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCombinationDes, "CombinationDes")
        Me.stbCombinationDes.EntryErrorMSG = ""
        Me.stbCombinationDes.Location = New System.Drawing.Point(174, 29)
        Me.stbCombinationDes.MaxLength = 100
        Me.stbCombinationDes.Multiline = True
        Me.stbCombinationDes.Name = "stbCombinationDes"
        Me.stbCombinationDes.RegularExpression = ""
        Me.stbCombinationDes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCombinationDes.Size = New System.Drawing.Size(250, 52)
        Me.stbCombinationDes.TabIndex = 3
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(352, 365)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblCombinationDes
        '
        Me.lblCombinationDes.Location = New System.Drawing.Point(13, 29)
        Me.lblCombinationDes.Name = "lblCombinationDes"
        Me.lblCombinationDes.Size = New System.Drawing.Size(135, 20)
        Me.lblCombinationDes.TabIndex = 2
        Me.lblCombinationDes.Text = "Combination Description"
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(13, 8)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(135, 20)
        Me.lblCombination.TabIndex = 0
        Me.lblCombination.Text = "Combination"
        '
        'dgvDrugs
        '
        Me.dgvDrugs.AllowUserToOrderColumns = True
        Me.dgvDrugs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colSaved})
        Me.dgvDrugs.EnableHeadersVisualStyles = False
        Me.dgvDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvDrugs.Location = New System.Drawing.Point(16, 87)
        Me.dgvDrugs.Name = "dgvDrugs"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDrugs.Size = New System.Drawing.Size(408, 243)
        Me.dgvDrugs.TabIndex = 4
        Me.dgvDrugs.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DataPropertyName = "DrugFullName"
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.Sorted = True
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 300
        '
        'colSaved
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.Width = 50
        '
        'cboCombination
        '
        Me.cboCombination.AllowDrop = True
        Me.cboCombination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCombination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCombination.DropDownWidth = 300
        Me.cboCombination.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCombination.FormattingEnabled = True
        Me.cboCombination.Location = New System.Drawing.Point(174, 5)
        Me.cboCombination.MaxLength = 224
        Me.cboCombination.Name = "cboCombination"
        Me.cboCombination.Size = New System.Drawing.Size(250, 21)
        Me.cboCombination.TabIndex = 47
        '
        'frmDrugCombinations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(440, 398)
        Me.Controls.Add(Me.cboCombination)
        Me.Controls.Add(Me.dgvDrugs)
        Me.Controls.Add(Me.stbCombinationDes)
        Me.Controls.Add(Me.lblCombinationDes)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDrugCombinations"
        Me.Text = "Drug Combinations"
        CType(Me.dgvDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbCombinationDes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCombinationDes As System.Windows.Forms.Label
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents dgvDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboCombination As ComboBox
End Class
