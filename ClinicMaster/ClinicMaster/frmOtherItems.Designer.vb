
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtherItems : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtherItems))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbItemName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxQuantity = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.fcbUnitMeasurID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.nbxVATPercentage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboGroupsID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.lblUnitMeasureID = New System.Windows.Forms.Label()
        Me.lblVATPercentage = New System.Windows.Forms.Label()
        Me.lblGroupsID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(29, 338)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 22
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(328, 338)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 24
        Me.fbnDelete.Tag = "OtherItems"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(29, 365)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 23
        Me.ebnSaveUpdate.Tag = "OtherItems"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbItemName
        '
        Me.stbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbItemName, "ItemName")
        Me.stbItemName.EntryErrorMSG = ""
        Me.stbItemName.Location = New System.Drawing.Point(169, 32)
        Me.stbItemName.MaxLength = 200
        Me.stbItemName.Name = "stbItemName"
        Me.stbItemName.RegularExpression = ""
        Me.stbItemName.Size = New System.Drawing.Size(224, 20)
        Me.stbItemName.TabIndex = 3
        '
        'cboItemCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboItemCategoryID, "ItemCategory")
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.Location = New System.Drawing.Point(169, 55)
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(224, 21)
        Me.cboItemCategoryID.TabIndex = 5
        '
        'nbxUnitCost
        '
        Me.nbxUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitCost.ControlCaption = "UnitCost"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitCost, "UnitPrice")
        Me.nbxUnitCost.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitCost.DecimalPlaces = -1
        Me.nbxUnitCost.Location = New System.Drawing.Point(169, 78)
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.Size = New System.Drawing.Size(224, 20)
        Me.nbxUnitCost.TabIndex = 7
        Me.nbxUnitCost.Value = ""
        '
        'nbxQuantity
        '
        Me.nbxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxQuantity.ControlCaption = "Quantity"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxQuantity, "Quantity")
        Me.nbxQuantity.DecimalPlaces = -1
        Me.nbxQuantity.Location = New System.Drawing.Point(169, 99)
        Me.nbxQuantity.MaxValue = 0.0R
        Me.nbxQuantity.MinValue = 0.0R
        Me.nbxQuantity.MustEnterNumeric = True
        Me.nbxQuantity.Name = "nbxQuantity"
        Me.nbxQuantity.Size = New System.Drawing.Size(224, 20)
        Me.nbxQuantity.TabIndex = 9
        Me.nbxQuantity.Value = ""
        '
        'stbDetails
        '
        Me.stbDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDetails.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDetails, "Details")
        Me.stbDetails.EntryErrorMSG = ""
        Me.stbDetails.Location = New System.Drawing.Point(169, 188)
        Me.stbDetails.MaxLength = 1000
        Me.stbDetails.Multiline = True
        Me.stbDetails.Name = "stbDetails"
        Me.stbDetails.RegularExpression = ""
        Me.stbDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDetails.Size = New System.Drawing.Size(224, 93)
        Me.stbDetails.TabIndex = 18
        '
        'cboLocationID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboLocationID, "Location,LocationID")
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.Location = New System.Drawing.Point(169, 284)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(224, 21)
        Me.cboLocationID.TabIndex = 20
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(24, 310)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(134, 20)
        Me.chkHidden.TabIndex = 21
        Me.chkHidden.Text = "Hidden"
        '
        'fcbUnitMeasurID
        '
        Me.fcbUnitMeasurID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbUnitMeasurID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbUnitMeasurID, "UnitMeasure,UnitMeasureID")
        Me.fcbUnitMeasurID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbUnitMeasurID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbUnitMeasurID.FormattingEnabled = True
        Me.fcbUnitMeasurID.Location = New System.Drawing.Point(169, 121)
        Me.fcbUnitMeasurID.Name = "fcbUnitMeasurID"
        Me.fcbUnitMeasurID.ReadOnly = True
        Me.fcbUnitMeasurID.Size = New System.Drawing.Size(224, 21)
        Me.fcbUnitMeasurID.TabIndex = 11
        '
        'nbxVATPercentage
        '
        Me.nbxVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVATPercentage.ControlCaption = "VAT Percentage"
        Me.nbxVATPercentage.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxVATPercentage, "VATPercentage")
        Me.nbxVATPercentage.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxVATPercentage.DecimalPlaces = -1
        Me.nbxVATPercentage.Location = New System.Drawing.Point(169, 144)
        Me.nbxVATPercentage.MaxValue = 0.0R
        Me.nbxVATPercentage.MinValue = 0.0R
        Me.nbxVATPercentage.MustEnterNumeric = True
        Me.nbxVATPercentage.Name = "nbxVATPercentage"
        Me.nbxVATPercentage.Size = New System.Drawing.Size(224, 20)
        Me.nbxVATPercentage.TabIndex = 13
        Me.nbxVATPercentage.Value = ""
        '
        'cboGroupsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGroupsID, "Groups,GroupsID")
        Me.cboGroupsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroupsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGroupsID.Location = New System.Drawing.Point(169, 166)
        Me.cboGroupsID.Name = "cboGroupsID"
        Me.cboGroupsID.Size = New System.Drawing.Size(224, 21)
        Me.cboGroupsID.TabIndex = 15
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(328, 365)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 0
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(24, 9)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(134, 20)
        Me.lblItemCode.TabIndex = 0
        Me.lblItemCode.Text = "Item Code"
        '
        'lblItemName
        '
        Me.lblItemName.Location = New System.Drawing.Point(24, 32)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(134, 20)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Text = "Item Name"
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(24, 55)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(134, 20)
        Me.lblItemCategoryID.TabIndex = 4
        Me.lblItemCategoryID.Text = "Item Category"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Location = New System.Drawing.Point(24, 78)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(134, 20)
        Me.lblUnitCost.TabIndex = 6
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(24, 99)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(134, 20)
        Me.lblQuantity.TabIndex = 8
        Me.lblQuantity.Text = "Quantity"
        '
        'lblDetails
        '
        Me.lblDetails.Location = New System.Drawing.Point(24, 188)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(134, 20)
        Me.lblDetails.TabIndex = 16
        Me.lblDetails.Text = "Details"
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(24, 284)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(134, 20)
        Me.lblLocationID.TabIndex = 19
        Me.lblLocationID.Text = "Location"
        '
        'cboItemCode
        '
        Me.cboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCode.DropDownWidth = 300
        Me.cboItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Location = New System.Drawing.Point(169, 8)
        Me.cboItemCode.MaxLength = 20
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(224, 21)
        Me.cboItemCode.TabIndex = 1
        '
        'lblUnitMeasureID
        '
        Me.lblUnitMeasureID.Location = New System.Drawing.Point(24, 124)
        Me.lblUnitMeasureID.Name = "lblUnitMeasureID"
        Me.lblUnitMeasureID.Size = New System.Drawing.Size(134, 20)
        Me.lblUnitMeasureID.TabIndex = 10
        Me.lblUnitMeasureID.Text = "Unit Measure"
        '
        'lblVATPercentage
        '
        Me.lblVATPercentage.Location = New System.Drawing.Point(24, 144)
        Me.lblVATPercentage.Name = "lblVATPercentage"
        Me.lblVATPercentage.Size = New System.Drawing.Size(134, 20)
        Me.lblVATPercentage.TabIndex = 12
        Me.lblVATPercentage.Text = "VAT Percentage"
        '
        'lblGroupsID
        '
        Me.lblGroupsID.Location = New System.Drawing.Point(24, 166)
        Me.lblGroupsID.Name = "lblGroupsID"
        Me.lblGroupsID.Size = New System.Drawing.Size(134, 20)
        Me.lblGroupsID.TabIndex = 14
        Me.lblGroupsID.Text = "Group"
        '
        'frmOtherItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(410, 396)
        Me.Controls.Add(Me.cboGroupsID)
        Me.Controls.Add(Me.lblGroupsID)
        Me.Controls.Add(Me.nbxVATPercentage)
        Me.Controls.Add(Me.lblVATPercentage)
        Me.Controls.Add(Me.fcbUnitMeasurID)
        Me.Controls.Add(Me.lblUnitMeasureID)
        Me.Controls.Add(Me.cboItemCode)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.stbItemName)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.cboItemCategoryID)
        Me.Controls.Add(Me.lblItemCategoryID)
        Me.Controls.Add(Me.nbxUnitCost)
        Me.Controls.Add(Me.lblUnitCost)
        Me.Controls.Add(Me.nbxQuantity)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.stbDetails)
        Me.Controls.Add(Me.lblDetails)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOtherItems"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Medical Items"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents stbItemName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
Friend WithEvents nbxQuantity As SyncSoft.Common.Win.Controls.NumericBox
Friend WithEvents lblQuantity As System.Windows.Forms.Label
Friend WithEvents stbDetails As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblDetails As System.Windows.Forms.Label
Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents fcbUnitMeasurID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblUnitMeasureID As System.Windows.Forms.Label
    Friend WithEvents nbxVATPercentage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblVATPercentage As System.Windows.Forms.Label
    Friend WithEvents cboGroupsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblGroupsID As System.Windows.Forms.Label

End Class