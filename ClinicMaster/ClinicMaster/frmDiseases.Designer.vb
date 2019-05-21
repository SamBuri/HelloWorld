
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiseases : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDiseases))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbDiseaseName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.cboDiseaseCategoriesID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDiseaseCode = New System.Windows.Forms.Label()
        Me.lblDiseaseName = New System.Windows.Forms.Label()
        Me.lblDiseaseCategoriesID = New System.Windows.Forms.Label()
        Me.cboDiseaseCode = New System.Windows.Forms.ComboBox()
        Me.tbcPossibleAttachedItems = New System.Windows.Forms.TabControl()
        Me.tpgPrescription = New System.Windows.Forms.TabPage()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.tpgPossibleLabTests = New System.Windows.Forms.TabPage()
        Me.dgvLabTests = New System.Windows.Forms.DataGridView()
        Me.ColDrugselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.ColLabSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColTestNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLabQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLabNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabTestsSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.tbcPossibleAttachedItems.SuspendLayout()
        Me.tpgPrescription.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPossibleLabTests.SuspendLayout()
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 405)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 7
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(609, 405)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 8
        Me.fbnDelete.Tag = "Diseases"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 432)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 9
        Me.ebnSaveUpdate.Tag = "Diseases"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbDiseaseName
        '
        Me.stbDiseaseName.AcceptsReturn = True
        Me.stbDiseaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDiseaseName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDiseaseName, "DiseaseName")
        Me.stbDiseaseName.EntryErrorMSG = ""
        Me.stbDiseaseName.Location = New System.Drawing.Point(159, 35)
        Me.stbDiseaseName.MaxLength = 800
        Me.stbDiseaseName.Multiline = True
        Me.stbDiseaseName.Name = "stbDiseaseName"
        Me.stbDiseaseName.RegularExpression = ""
        Me.stbDiseaseName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDiseaseName.Size = New System.Drawing.Size(318, 95)
        Me.stbDiseaseName.TabIndex = 3
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(9, 156)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(161, 20)
        Me.chkHidden.TabIndex = 6
        Me.chkHidden.Text = "Hidden"
        '
        'cboDiseaseCategoriesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDiseaseCategoriesID, "DiseaseCategories,DiseaseCategoriesID")
        Me.cboDiseaseCategoriesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDiseaseCategoriesID.DropDownWidth = 351
        Me.cboDiseaseCategoriesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiseaseCategoriesID.Location = New System.Drawing.Point(159, 132)
        Me.cboDiseaseCategoriesID.Name = "cboDiseaseCategoriesID"
        Me.cboDiseaseCategoriesID.Size = New System.Drawing.Size(318, 21)
        Me.cboDiseaseCategoriesID.TabIndex = 5
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(609, 432)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 10
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDiseaseCode
        '
        Me.lblDiseaseCode.Location = New System.Drawing.Point(9, 12)
        Me.lblDiseaseCode.Name = "lblDiseaseCode"
        Me.lblDiseaseCode.Size = New System.Drawing.Size(144, 20)
        Me.lblDiseaseCode.TabIndex = 0
        Me.lblDiseaseCode.Text = "Disease Code"
        '
        'lblDiseaseName
        '
        Me.lblDiseaseName.Location = New System.Drawing.Point(9, 61)
        Me.lblDiseaseName.Name = "lblDiseaseName"
        Me.lblDiseaseName.Size = New System.Drawing.Size(144, 20)
        Me.lblDiseaseName.TabIndex = 2
        Me.lblDiseaseName.Text = "Disease Name"
        '
        'lblDiseaseCategoriesID
        '
        Me.lblDiseaseCategoriesID.Location = New System.Drawing.Point(9, 137)
        Me.lblDiseaseCategoriesID.Name = "lblDiseaseCategoriesID"
        Me.lblDiseaseCategoriesID.Size = New System.Drawing.Size(144, 20)
        Me.lblDiseaseCategoriesID.TabIndex = 4
        Me.lblDiseaseCategoriesID.Text = "Disease Category"
        '
        'cboDiseaseCode
        '
        Me.cboDiseaseCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDiseaseCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDiseaseCode.DropDownWidth = 200
        Me.cboDiseaseCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDiseaseCode.FormattingEnabled = True
        Me.cboDiseaseCode.Location = New System.Drawing.Point(159, 8)
        Me.cboDiseaseCode.MaxLength = 64
        Me.cboDiseaseCode.Name = "cboDiseaseCode"
        Me.cboDiseaseCode.Size = New System.Drawing.Size(318, 21)
        Me.cboDiseaseCode.TabIndex = 11
        '
        'tbcPossibleAttachedItems
        '
        Me.tbcPossibleAttachedItems.Controls.Add(Me.tpgPrescription)
        Me.tbcPossibleAttachedItems.Controls.Add(Me.tpgPossibleLabTests)
        Me.tbcPossibleAttachedItems.Location = New System.Drawing.Point(1, 182)
        Me.tbcPossibleAttachedItems.Name = "tbcPossibleAttachedItems"
        Me.tbcPossibleAttachedItems.SelectedIndex = 0
        Me.tbcPossibleAttachedItems.Size = New System.Drawing.Size(688, 217)
        Me.tbcPossibleAttachedItems.TabIndex = 13
        '
        'tpgPrescription
        '
        Me.tpgPrescription.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescription.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescription.Name = "tpgPrescription"
        Me.tpgPrescription.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPrescription.Size = New System.Drawing.Size(680, 191)
        Me.tpgPrescription.TabIndex = 0
        Me.tpgPrescription.Text = "Possible Drugs"
        Me.tpgPrescription.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColDrugselect, Me.colDrugNo, Me.colDrug, Me.colDrugQuantity, Me.colDrugNotes, Me.colPrescriptionSaved})
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(3, 3)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPrescription.Size = New System.Drawing.Size(674, 185)
        Me.dgvPrescription.TabIndex = 13
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'tpgPossibleLabTests
        '
        Me.tpgPossibleLabTests.Controls.Add(Me.dgvLabTests)
        Me.tpgPossibleLabTests.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleLabTests.Name = "tpgPossibleLabTests"
        Me.tpgPossibleLabTests.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPossibleLabTests.Size = New System.Drawing.Size(680, 191)
        Me.tpgPossibleLabTests.TabIndex = 1
        Me.tpgPossibleLabTests.Text = "Possible Lab Tests"
        Me.tpgPossibleLabTests.UseVisualStyleBackColor = True
        '
        'dgvLabTests
        '
        Me.dgvLabTests.AllowUserToOrderColumns = True
        Me.dgvLabTests.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvLabTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColLabSelect, Me.ColTestNo, Me.ColTestName, Me.ColLabQuantity, Me.ColLabNotes, Me.colLabTestsSaved})
        Me.dgvLabTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabTests.EnableHeadersVisualStyles = False
        Me.dgvLabTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabTests.Location = New System.Drawing.Point(3, 3)
        Me.dgvLabTests.Name = "dgvLabTests"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvLabTests.Size = New System.Drawing.Size(674, 185)
        Me.dgvLabTests.TabIndex = 14
        Me.dgvLabTests.Text = "DataGridView1"
        '
        'ColDrugselect
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.ColDrugselect.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColDrugselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColDrugselect.HeaderText = "Select"
        Me.ColDrugselect.Name = "ColDrugselect"
        Me.ColDrugselect.ReadOnly = True
        Me.ColDrugselect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDrugselect.Text = "•••"
        Me.ColDrugselect.Width = 50
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "ItemCode"
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Width = 90
        '
        'colDrug
        '
        Me.colDrug.DataPropertyName = "DrugName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDrug.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.ReadOnly = True
        Me.colDrug.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrug.Width = 150
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugNotes
        '
        Me.colDrugNotes.DataPropertyName = "Notes"
        Me.colDrugNotes.HeaderText = "Notes"
        Me.colDrugNotes.MaxInputLength = 100
        Me.colDrugNotes.Name = "colDrugNotes"
        '
        'colPrescriptionSaved
        '
        Me.colPrescriptionSaved.ControlCaption = Nothing
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.SourceColumn = Nothing
        Me.colPrescriptionSaved.Width = 50
        '
        'ColLabSelect
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.ColLabSelect.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColLabSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColLabSelect.HeaderText = "Select"
        Me.ColLabSelect.Name = "ColLabSelect"
        Me.ColLabSelect.ReadOnly = True
        Me.ColLabSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColLabSelect.Text = "•••"
        Me.ColLabSelect.Width = 50
        '
        'ColTestNo
        '
        Me.ColTestNo.DataPropertyName = "ItemCode"
        Me.ColTestNo.HeaderText = "Test No"
        Me.ColTestNo.Name = "ColTestNo"
        Me.ColTestNo.Width = 90
        '
        'ColTestName
        '
        Me.ColTestName.DataPropertyName = "TestName"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.ColTestName.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColTestName.HeaderText = "Test"
        Me.ColTestName.Name = "ColTestName"
        Me.ColTestName.ReadOnly = True
        Me.ColTestName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColTestName.Width = 150
        '
        'ColLabQuantity
        '
        Me.ColLabQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.ColLabQuantity.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColLabQuantity.HeaderText = "Quantity"
        Me.ColLabQuantity.Name = "ColLabQuantity"
        Me.ColLabQuantity.Width = 50
        '
        'ColLabNotes
        '
        Me.ColLabNotes.DataPropertyName = "Notes"
        Me.ColLabNotes.HeaderText = "Notes"
        Me.ColLabNotes.MaxInputLength = 100
        Me.ColLabNotes.Name = "ColLabNotes"
        '
        'colLabTestsSaved
        '
        Me.colLabTestsSaved.ControlCaption = Nothing
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle11.NullValue = False
        Me.colLabTestsSaved.DefaultCellStyle = DataGridViewCellStyle11
        Me.colLabTestsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colLabTestsSaved.HeaderText = "Saved"
        Me.colLabTestsSaved.Name = "colLabTestsSaved"
        Me.colLabTestsSaved.ReadOnly = True
        Me.colLabTestsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colLabTestsSaved.SourceColumn = Nothing
        Me.colLabTestsSaved.Width = 50
        '
        'frmDiseases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(693, 463)
        Me.Controls.Add(Me.tbcPossibleAttachedItems)
        Me.Controls.Add(Me.cboDiseaseCode)
        Me.Controls.Add(Me.cboDiseaseCategoriesID)
        Me.Controls.Add(Me.lblDiseaseCategoriesID)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblDiseaseCode)
        Me.Controls.Add(Me.stbDiseaseName)
        Me.Controls.Add(Me.lblDiseaseName)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDiseases"
        Me.Text = "Diseases"
        Me.tbcPossibleAttachedItems.ResumeLayout(False)
        Me.tpgPrescription.ResumeLayout(False)
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPossibleLabTests.ResumeLayout(False)
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDiseaseCode As System.Windows.Forms.Label
    Friend WithEvents stbDiseaseName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDiseaseName As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents cboDiseaseCategoriesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDiseaseCategoriesID As System.Windows.Forms.Label
    Friend WithEvents cboDiseaseCode As ComboBox
    Friend WithEvents tbcPossibleAttachedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgPrescription As System.Windows.Forms.TabPage
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents tpgPossibleLabTests As System.Windows.Forms.TabPage
    Friend WithEvents dgvLabTests As System.Windows.Forms.DataGridView
    Friend WithEvents ColDrugselect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents ColLabSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColTestNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLabQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLabNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabTestsSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
End Class