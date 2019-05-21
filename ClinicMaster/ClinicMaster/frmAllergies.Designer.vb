
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllergies : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAllergies))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAllergyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAllergyCategoryID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblAllergyNo = New System.Windows.Forms.Label()
        Me.lblAllergyName = New System.Windows.Forms.Label()
        Me.lblAllergyCategoryID = New System.Windows.Forms.Label()
        Me.dgvAllergyDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAllergyDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboAllergyNo = New System.Windows.Forms.ComboBox()
        CType(Me.dgvAllergyDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 256)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 6
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 256)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 7
        Me.fbnDelete.Tag = "Allergies"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 283)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 8
        Me.ebnSaveUpdate.Tag = "Allergies"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAllergyName
        '
        Me.stbAllergyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAllergyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAllergyName, "AllergyName")
        Me.stbAllergyName.EntryErrorMSG = ""
        Me.stbAllergyName.Location = New System.Drawing.Point(218, 33)
        Me.stbAllergyName.MaxLength = 60
        Me.stbAllergyName.Name = "stbAllergyName"
        Me.stbAllergyName.RegularExpression = ""
        Me.stbAllergyName.Size = New System.Drawing.Size(170, 20)
        Me.stbAllergyName.TabIndex = 3
        '
        'cboAllergyCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAllergyCategoryID, "AllergyCategory,AllergyCategoryID")
        Me.cboAllergyCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAllergyCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAllergyCategoryID.Location = New System.Drawing.Point(218, 54)
        Me.cboAllergyCategoryID.Name = "cboAllergyCategoryID"
        Me.cboAllergyCategoryID.Size = New System.Drawing.Size(170, 21)
        Me.cboAllergyCategoryID.TabIndex = 5
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 283)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 9
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblAllergyNo
        '
        Me.lblAllergyNo.Location = New System.Drawing.Point(12, 12)
        Me.lblAllergyNo.Name = "lblAllergyNo"
        Me.lblAllergyNo.Size = New System.Drawing.Size(200, 20)
        Me.lblAllergyNo.TabIndex = 0
        Me.lblAllergyNo.Text = "Allergy No"
        '
        'lblAllergyName
        '
        Me.lblAllergyName.Location = New System.Drawing.Point(12, 33)
        Me.lblAllergyName.Name = "lblAllergyName"
        Me.lblAllergyName.Size = New System.Drawing.Size(200, 20)
        Me.lblAllergyName.TabIndex = 2
        Me.lblAllergyName.Text = "Allergy Name"
        '
        'lblAllergyCategoryID
        '
        Me.lblAllergyCategoryID.Location = New System.Drawing.Point(12, 54)
        Me.lblAllergyCategoryID.Name = "lblAllergyCategoryID"
        Me.lblAllergyCategoryID.Size = New System.Drawing.Size(200, 20)
        Me.lblAllergyCategoryID.TabIndex = 4
        Me.lblAllergyCategoryID.Text = "Allergy Category"
        '
        'dgvAllergyDrugs
        '
        Me.dgvAllergyDrugs.AllowUserToOrderColumns = True
        Me.dgvAllergyDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllergyDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAllergyDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugNo, Me.colAllergyDrugsSaved})
        Me.dgvAllergyDrugs.EnableHeadersVisualStyles = False
        Me.dgvAllergyDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvAllergyDrugs.Location = New System.Drawing.Point(15, 81)
        Me.dgvAllergyDrugs.Name = "dgvAllergyDrugs"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllergyDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAllergyDrugs.Size = New System.Drawing.Size(373, 169)
        Me.dgvAllergyDrugs.TabIndex = 20
        Me.dgvAllergyDrugs.Text = "DataGridView1"
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "DrugNo"
        Me.colDrugNo.DisplayStyleForCurrentCellOnly = True
        Me.colDrugNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugNo.HeaderText = "Drug"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrugNo.Width = 250
        '
        'colAllergyDrugsSaved
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colAllergyDrugsSaved.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAllergyDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAllergyDrugsSaved.HeaderText = "Saved"
        Me.colAllergyDrugsSaved.Name = "colAllergyDrugsSaved"
        Me.colAllergyDrugsSaved.ReadOnly = True
        Me.colAllergyDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAllergyDrugsSaved.Width = 50
        '
        'cboAllergyNo
        '
        Me.cboAllergyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAllergyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAllergyNo.DropDownWidth = 200
        Me.cboAllergyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAllergyNo.FormattingEnabled = True
        Me.cboAllergyNo.Location = New System.Drawing.Point(218, 9)
        Me.cboAllergyNo.MaxLength = 64
        Me.cboAllergyNo.Name = "cboAllergyNo"
        Me.cboAllergyNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAllergyNo.TabIndex = 21
        '
        'frmAllergies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(407, 322)
        Me.Controls.Add(Me.cboAllergyNo)
        Me.Controls.Add(Me.dgvAllergyDrugs)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblAllergyNo)
        Me.Controls.Add(Me.stbAllergyName)
        Me.Controls.Add(Me.lblAllergyName)
        Me.Controls.Add(Me.cboAllergyCategoryID)
        Me.Controls.Add(Me.lblAllergyCategoryID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAllergies"
        Me.Text = "Allergies"
        CType(Me.dgvAllergyDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblAllergyNo As System.Windows.Forms.Label
    Friend WithEvents stbAllergyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAllergyName As System.Windows.Forms.Label
    Friend WithEvents cboAllergyCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAllergyCategoryID As System.Windows.Forms.Label
    Friend WithEvents dgvAllergyDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAllergyDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboAllergyNo As ComboBox
End Class