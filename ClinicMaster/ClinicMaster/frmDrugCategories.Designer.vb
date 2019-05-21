
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrugCategories : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugCategories))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbCategoryName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkVaryPrescribedQty = New System.Windows.Forms.CheckBox()
        Me.nbxDefaultPrescribedQty = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbDosageSeparator = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDosageCalculationID = New System.Windows.Forms.ComboBox()
        Me.stbDosageFormat = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblCategoryNo = New System.Windows.Forms.Label()
        Me.lblCategoryName = New System.Windows.Forms.Label()
        Me.lblDefaultPrescribedQty = New System.Windows.Forms.Label()
        Me.lblDosageSeparator = New System.Windows.Forms.Label()
        Me.lblDosageCalculationID = New System.Windows.Forms.Label()
        Me.lblDosageFormat = New System.Windows.Forms.Label()
        Me.cboCategoryNo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 160)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 15
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(274, 158)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 16
        Me.fbnDelete.Tag = "DrugCategories"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 186)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 17
        Me.ebnSaveUpdate.Tag = "DrugCategories"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbCategoryName
        '
        Me.stbCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCategoryName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCategoryName, "CategoryName")
        Me.stbCategoryName.EntryErrorMSG = ""
        Me.stbCategoryName.Location = New System.Drawing.Point(176, 26)
        Me.stbCategoryName.MaxLength = 40
        Me.stbCategoryName.Name = "stbCategoryName"
        Me.stbCategoryName.RegularExpression = ""
        Me.stbCategoryName.Size = New System.Drawing.Size(170, 20)
        Me.stbCategoryName.TabIndex = 3
        '
        'chkVaryPrescribedQty
        '
        Me.chkVaryPrescribedQty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkVaryPrescribedQty, "VaryPrescribedQty")
        Me.chkVaryPrescribedQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVaryPrescribedQty.Location = New System.Drawing.Point(13, 44)
        Me.chkVaryPrescribedQty.Name = "chkVaryPrescribedQty"
        Me.chkVaryPrescribedQty.Size = New System.Drawing.Size(174, 20)
        Me.chkVaryPrescribedQty.TabIndex = 6
        Me.chkVaryPrescribedQty.Text = "Vary Prescribed Quantity"
        '
        'nbxDefaultPrescribedQty
        '
        Me.nbxDefaultPrescribedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDefaultPrescribedQty.ControlCaption = "Default Prescribed Quantity"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDefaultPrescribedQty, "DefaultPrescribedQty")
        Me.nbxDefaultPrescribedQty.DecimalPlaces = -1
        Me.nbxDefaultPrescribedQty.Location = New System.Drawing.Point(177, 64)
        Me.nbxDefaultPrescribedQty.MaxValue = 0R
        Me.nbxDefaultPrescribedQty.MinValue = 0R
        Me.nbxDefaultPrescribedQty.MustEnterNumeric = True
        Me.nbxDefaultPrescribedQty.Name = "nbxDefaultPrescribedQty"
        Me.nbxDefaultPrescribedQty.Size = New System.Drawing.Size(170, 20)
        Me.nbxDefaultPrescribedQty.TabIndex = 8
        Me.nbxDefaultPrescribedQty.Value = ""
        '
        'stbDosageSeparator
        '
        Me.stbDosageSeparator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDosageSeparator.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDosageSeparator, "DosageSeparator")
        Me.stbDosageSeparator.EntryErrorMSG = ""
        Me.stbDosageSeparator.Location = New System.Drawing.Point(177, 86)
        Me.stbDosageSeparator.MaxLength = 1
        Me.stbDosageSeparator.Name = "stbDosageSeparator"
        Me.stbDosageSeparator.RegularExpression = ""
        Me.stbDosageSeparator.Size = New System.Drawing.Size(170, 20)
        Me.stbDosageSeparator.TabIndex = 10
        '
        'cboDosageCalculationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDosageCalculationID, "DosageCalculation,DosageCalculationID")
        Me.cboDosageCalculationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDosageCalculationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDosageCalculationID.Location = New System.Drawing.Point(177, 109)
        Me.cboDosageCalculationID.Name = "cboDosageCalculationID"
        Me.cboDosageCalculationID.Size = New System.Drawing.Size(170, 21)
        Me.cboDosageCalculationID.TabIndex = 12
        '
        'stbDosageFormat
        '
        Me.stbDosageFormat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDosageFormat.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDosageFormat, "DosageFormat")
        Me.stbDosageFormat.EntryErrorMSG = ""
        Me.stbDosageFormat.Location = New System.Drawing.Point(177, 132)
        Me.stbDosageFormat.MaxLength = 40
        Me.stbDosageFormat.Name = "stbDosageFormat"
        Me.stbDosageFormat.RegularExpression = ""
        Me.stbDosageFormat.Size = New System.Drawing.Size(170, 20)
        Me.stbDosageFormat.TabIndex = 14
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(274, 185)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 18
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblCategoryNo
        '
        Me.lblCategoryNo.Location = New System.Drawing.Point(12, 6)
        Me.lblCategoryNo.Name = "lblCategoryNo"
        Me.lblCategoryNo.Size = New System.Drawing.Size(158, 20)
        Me.lblCategoryNo.TabIndex = 0
        Me.lblCategoryNo.Text = "Category No"
        '
        'lblCategoryName
        '
        Me.lblCategoryName.Location = New System.Drawing.Point(12, 27)
        Me.lblCategoryName.Name = "lblCategoryName"
        Me.lblCategoryName.Size = New System.Drawing.Size(158, 20)
        Me.lblCategoryName.TabIndex = 2
        Me.lblCategoryName.Text = "Category Name"
        '
        'lblDefaultPrescribedQty
        '
        Me.lblDefaultPrescribedQty.Location = New System.Drawing.Point(13, 65)
        Me.lblDefaultPrescribedQty.Name = "lblDefaultPrescribedQty"
        Me.lblDefaultPrescribedQty.Size = New System.Drawing.Size(158, 20)
        Me.lblDefaultPrescribedQty.TabIndex = 7
        Me.lblDefaultPrescribedQty.Text = "Default Prescribed Quantity"
        '
        'lblDosageSeparator
        '
        Me.lblDosageSeparator.Location = New System.Drawing.Point(13, 87)
        Me.lblDosageSeparator.Name = "lblDosageSeparator"
        Me.lblDosageSeparator.Size = New System.Drawing.Size(158, 20)
        Me.lblDosageSeparator.TabIndex = 9
        Me.lblDosageSeparator.Text = "Dosage Separator"
        '
        'lblDosageCalculationID
        '
        Me.lblDosageCalculationID.Location = New System.Drawing.Point(13, 110)
        Me.lblDosageCalculationID.Name = "lblDosageCalculationID"
        Me.lblDosageCalculationID.Size = New System.Drawing.Size(158, 20)
        Me.lblDosageCalculationID.TabIndex = 11
        Me.lblDosageCalculationID.Text = "Dosage Calculation"
        '
        'lblDosageFormat
        '
        Me.lblDosageFormat.Location = New System.Drawing.Point(13, 133)
        Me.lblDosageFormat.Name = "lblDosageFormat"
        Me.lblDosageFormat.Size = New System.Drawing.Size(158, 20)
        Me.lblDosageFormat.TabIndex = 13
        Me.lblDosageFormat.Text = "Dosage Format"
        '
        'cboCategoryNo
        '
        Me.cboCategoryNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategoryNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCategoryNo.DropDownWidth = 300
        Me.cboCategoryNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCategoryNo.FormattingEnabled = True
        Me.cboCategoryNo.Location = New System.Drawing.Point(176, 3)
        Me.cboCategoryNo.MaxLength = 54
        Me.cboCategoryNo.Name = "cboCategoryNo"
        Me.cboCategoryNo.Size = New System.Drawing.Size(170, 21)
        Me.cboCategoryNo.TabIndex = 1
        '
        'frmDrugCategories
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(363, 218)
        Me.Controls.Add(Me.cboCategoryNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblCategoryNo)
        Me.Controls.Add(Me.stbCategoryName)
        Me.Controls.Add(Me.lblCategoryName)
        Me.Controls.Add(Me.chkVaryPrescribedQty)
        Me.Controls.Add(Me.nbxDefaultPrescribedQty)
        Me.Controls.Add(Me.lblDefaultPrescribedQty)
        Me.Controls.Add(Me.stbDosageSeparator)
        Me.Controls.Add(Me.lblDosageSeparator)
        Me.Controls.Add(Me.cboDosageCalculationID)
        Me.Controls.Add(Me.lblDosageCalculationID)
        Me.Controls.Add(Me.stbDosageFormat)
        Me.Controls.Add(Me.lblDosageFormat)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDrugCategories"
        Me.Text = "Drug Categories"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblCategoryNo As System.Windows.Forms.Label
    Friend WithEvents stbCategoryName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCategoryName As System.Windows.Forms.Label
    Friend WithEvents chkVaryPrescribedQty As System.Windows.Forms.CheckBox
    Friend WithEvents nbxDefaultPrescribedQty As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDefaultPrescribedQty As System.Windows.Forms.Label
    Friend WithEvents stbDosageSeparator As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDosageSeparator As System.Windows.Forms.Label
    Friend WithEvents cboDosageCalculationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDosageCalculationID As System.Windows.Forms.Label
    Friend WithEvents stbDosageFormat As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDosageFormat As System.Windows.Forms.Label
    Friend WithEvents cboCategoryNo As System.Windows.Forms.ComboBox

End Class