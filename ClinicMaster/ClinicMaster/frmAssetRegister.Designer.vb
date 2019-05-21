
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAssetRegister : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssetRegister))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboAssetSourceID = New System.Windows.Forms.ComboBox()
        Me.cboAssetCategoryID = New System.Windows.Forms.ComboBox()
        Me.cboDeptID = New System.Windows.Forms.ComboBox()
        Me.stbItemDescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBrand = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxQuantity = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpDateOfPurchase = New System.Windows.Forms.DateTimePicker()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpDateOfDelivery = New System.Windows.Forms.DateTimePicker()
        Me.nbxSalvageValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxDepreciationRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxUsefulLife = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboDepreciationMethodID = New System.Windows.Forms.ComboBox()
        Me.dtpDepreciationStartDate = New System.Windows.Forms.DateTimePicker()
        Me.stbAssignedTo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxServicingSchedule = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbSerialNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSerialNo = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblAssetSourceID = New System.Windows.Forms.Label()
        Me.lblAssetCategoryID = New System.Windows.Forms.Label()
        Me.lblDeptID = New System.Windows.Forms.Label()
        Me.lblItemDescription = New System.Windows.Forms.Label()
        Me.lblBrand = New System.Windows.Forms.Label()
        Me.lblQuantity = New System.Windows.Forms.Label()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.lblDateOfPurchase = New System.Windows.Forms.Label()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.lblDateOfDelivery = New System.Windows.Forms.Label()
        Me.lblSalvageValue = New System.Windows.Forms.Label()
        Me.lblDepreciationRate = New System.Windows.Forms.Label()
        Me.lblUsefulLife = New System.Windows.Forms.Label()
        Me.lblDepreciationMethodID = New System.Windows.Forms.Label()
        Me.lblDepreciationStartDate = New System.Windows.Forms.Label()
        Me.lblAssignedTo = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblServicingSchedule = New System.Windows.Forms.Label()
        Me.btnClearPhoto = New System.Windows.Forms.Button()
        Me.btnLoadPhoto = New System.Windows.Forms.Button()
        Me.stbInstitutionalID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInstitutionalID = New System.Windows.Forms.Label()
        Me.stbManufacturerID = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblManufactureID = New System.Windows.Forms.Label()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(18, 392)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 49
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(592, 392)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 51
        Me.fbnDelete.Tag = "AssetRegister"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(18, 419)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 50
        Me.ebnSaveUpdate.Tag = "AssetRegister"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboAssetSourceID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAssetSourceID, "AssetSource,AssetSourceID")
        Me.cboAssetSourceID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssetSourceID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAssetSourceID.Location = New System.Drawing.Point(169, 77)
        Me.cboAssetSourceID.Name = "cboAssetSourceID"
        Me.cboAssetSourceID.Size = New System.Drawing.Size(170, 21)
        Me.cboAssetSourceID.TabIndex = 7
        '
        'cboAssetCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAssetCategoryID, "AssetCategory,AssetCategoryID")
        Me.cboAssetCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssetCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAssetCategoryID.Location = New System.Drawing.Point(169, 102)
        Me.cboAssetCategoryID.Name = "cboAssetCategoryID"
        Me.cboAssetCategoryID.Size = New System.Drawing.Size(170, 21)
        Me.cboAssetCategoryID.TabIndex = 9
        '
        'cboDeptID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDeptID, "Dept,DeptID")
        Me.cboDeptID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeptID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDeptID.Location = New System.Drawing.Point(169, 125)
        Me.cboDeptID.Name = "cboDeptID"
        Me.cboDeptID.Size = New System.Drawing.Size(170, 21)
        Me.cboDeptID.TabIndex = 11
        '
        'stbItemDescription
        '
        Me.stbItemDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemDescription.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbItemDescription, "ItemDescription")
        Me.stbItemDescription.EntryErrorMSG = ""
        Me.stbItemDescription.Location = New System.Drawing.Point(169, 149)
        Me.stbItemDescription.Multiline = True
        Me.stbItemDescription.Name = "stbItemDescription"
        Me.stbItemDescription.RegularExpression = ""
        Me.stbItemDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbItemDescription.Size = New System.Drawing.Size(170, 55)
        Me.stbItemDescription.TabIndex = 13
        '
        'stbBrand
        '
        Me.stbBrand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBrand.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBrand, "Brand")
        Me.stbBrand.EntryErrorMSG = ""
        Me.stbBrand.Location = New System.Drawing.Point(169, 208)
        Me.stbBrand.Multiline = True
        Me.stbBrand.Name = "stbBrand"
        Me.stbBrand.RegularExpression = ""
        Me.stbBrand.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBrand.Size = New System.Drawing.Size(170, 64)
        Me.stbBrand.TabIndex = 15
        '
        'nbxValue
        '
        Me.nbxValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxValue.ControlCaption = "Quantity"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxValue, "Value")
        Me.nbxValue.DecimalPlaces = -1
        Me.nbxValue.Location = New System.Drawing.Point(169, 274)
        Me.nbxValue.MaxValue = 0.0R
        Me.nbxValue.MinValue = 0.0R
        Me.nbxValue.MustEnterNumeric = True
        Me.nbxValue.Name = "nbxValue"
        Me.nbxValue.Size = New System.Drawing.Size(170, 20)
        Me.nbxValue.TabIndex = 17
        Me.nbxValue.Value = ""
        '
        'nbxQuantity
        '
        Me.nbxQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.nbxQuantity, "Quantity")
        Me.nbxQuantity.DecimalPlaces = -1
        Me.nbxQuantity.Location = New System.Drawing.Point(169, 297)
        Me.nbxQuantity.MaxValue = 0.0R
        Me.nbxQuantity.MinValue = 0.0R
        Me.nbxQuantity.MustEnterNumeric = True
        Me.nbxQuantity.Name = "nbxQuantity"
        Me.nbxQuantity.Size = New System.Drawing.Size(170, 20)
        Me.nbxQuantity.TabIndex = 19
        Me.nbxQuantity.Value = ""
        '
        'dtpDateOfPurchase
        '
        Me.dtpDateOfPurchase.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDateOfPurchase, "DateOfPurchase")
        Me.dtpDateOfPurchase.Location = New System.Drawing.Point(169, 320)
        Me.dtpDateOfPurchase.Name = "dtpDateOfPurchase"
        Me.dtpDateOfPurchase.ShowCheckBox = True
        Me.dtpDateOfPurchase.Size = New System.Drawing.Size(170, 20)
        Me.dtpDateOfPurchase.TabIndex = 21
        '
        'cboSupplierNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSupplierNo, "SupplierFullName")
        Me.cboSupplierNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplierNo.DropDownWidth = 300
        Me.cboSupplierNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSupplierNo.Location = New System.Drawing.Point(169, 342)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(170, 21)
        Me.cboSupplierNo.TabIndex = 23
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInvoiceNo, "InvoiceNo")
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(494, 149)
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(170, 20)
        Me.stbInvoiceNo.TabIndex = 30
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpInvoiceDate, "InvoiceDate")
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(494, 172)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ShowCheckBox = True
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpInvoiceDate.TabIndex = 32
        '
        'dtpDateOfDelivery
        '
        Me.dtpDateOfDelivery.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDateOfDelivery, "DateOfDelivery")
        Me.dtpDateOfDelivery.Location = New System.Drawing.Point(494, 196)
        Me.dtpDateOfDelivery.Name = "dtpDateOfDelivery"
        Me.dtpDateOfDelivery.ShowCheckBox = True
        Me.dtpDateOfDelivery.Size = New System.Drawing.Size(170, 20)
        Me.dtpDateOfDelivery.TabIndex = 34
        '
        'nbxSalvageValue
        '
        Me.nbxSalvageValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSalvageValue.ControlCaption = "SalvageValue"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxSalvageValue, "SalvageValue")
        Me.nbxSalvageValue.DecimalPlaces = -1
        Me.nbxSalvageValue.Location = New System.Drawing.Point(494, 219)
        Me.nbxSalvageValue.MaxValue = 0.0R
        Me.nbxSalvageValue.MinValue = 0.0R
        Me.nbxSalvageValue.MustEnterNumeric = True
        Me.nbxSalvageValue.Name = "nbxSalvageValue"
        Me.nbxSalvageValue.Size = New System.Drawing.Size(170, 20)
        Me.nbxSalvageValue.TabIndex = 36
        Me.nbxSalvageValue.Value = ""
        '
        'nbxDepreciationRate
        '
        Me.nbxDepreciationRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxDepreciationRate.ControlCaption = "DepreciationRate"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxDepreciationRate, "DepreciationRate")
        Me.nbxDepreciationRate.DecimalPlaces = -1
        Me.nbxDepreciationRate.Location = New System.Drawing.Point(494, 242)
        Me.nbxDepreciationRate.MaxLength = 3
        Me.nbxDepreciationRate.MaxValue = 0.0R
        Me.nbxDepreciationRate.MinValue = 0.0R
        Me.nbxDepreciationRate.MustEnterNumeric = True
        Me.nbxDepreciationRate.Name = "nbxDepreciationRate"
        Me.nbxDepreciationRate.Size = New System.Drawing.Size(82, 20)
        Me.nbxDepreciationRate.TabIndex = 38
        Me.nbxDepreciationRate.Value = ""
        '
        'nbxUsefulLife
        '
        Me.nbxUsefulLife.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUsefulLife.ControlCaption = "UsefulLife"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUsefulLife, "UsefulLife")
        Me.nbxUsefulLife.DecimalPlaces = -1
        Me.nbxUsefulLife.Location = New System.Drawing.Point(494, 265)
        Me.nbxUsefulLife.MaxLength = 3
        Me.nbxUsefulLife.MaxValue = 0.0R
        Me.nbxUsefulLife.MinValue = 0.0R
        Me.nbxUsefulLife.MustEnterNumeric = True
        Me.nbxUsefulLife.Name = "nbxUsefulLife"
        Me.nbxUsefulLife.Size = New System.Drawing.Size(82, 20)
        Me.nbxUsefulLife.TabIndex = 40
        Me.nbxUsefulLife.Value = ""
        '
        'cboDepreciationMethodID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDepreciationMethodID, "DepreciationMethod,DepreciationMethodID")
        Me.cboDepreciationMethodID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepreciationMethodID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDepreciationMethodID.Location = New System.Drawing.Point(494, 288)
        Me.cboDepreciationMethodID.Name = "cboDepreciationMethodID"
        Me.cboDepreciationMethodID.Size = New System.Drawing.Size(170, 21)
        Me.cboDepreciationMethodID.TabIndex = 42
        '
        'dtpDepreciationStartDate
        '
        Me.dtpDepreciationStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDepreciationStartDate, "DepreciationStartDate")
        Me.dtpDepreciationStartDate.Location = New System.Drawing.Point(494, 311)
        Me.dtpDepreciationStartDate.Name = "dtpDepreciationStartDate"
        Me.dtpDepreciationStartDate.ShowCheckBox = True
        Me.dtpDepreciationStartDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpDepreciationStartDate.TabIndex = 44
        '
        'stbAssignedTo
        '
        Me.stbAssignedTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAssignedTo.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAssignedTo, "AssignedTo")
        Me.stbAssignedTo.EntryErrorMSG = ""
        Me.stbAssignedTo.Location = New System.Drawing.Point(494, 334)
        Me.stbAssignedTo.Name = "stbAssignedTo"
        Me.stbAssignedTo.RegularExpression = ""
        Me.stbAssignedTo.Size = New System.Drawing.Size(170, 20)
        Me.stbAssignedTo.TabIndex = 46
        '
        'stbLocation
        '
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLocation, "Location")
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(494, 357)
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(170, 20)
        Me.stbLocation.TabIndex = 48
        '
        'nbxServicingSchedule
        '
        Me.nbxServicingSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxServicingSchedule.ControlCaption = "ServicingSchedule"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxServicingSchedule, "ServicingSchedule")
        Me.nbxServicingSchedule.DecimalPlaces = -1
        Me.nbxServicingSchedule.Location = New System.Drawing.Point(496, 124)
        Me.nbxServicingSchedule.MaxLength = 3
        Me.nbxServicingSchedule.MaxValue = 0.0R
        Me.nbxServicingSchedule.MinValue = 0.0R
        Me.nbxServicingSchedule.MustEnterNumeric = True
        Me.nbxServicingSchedule.Name = "nbxServicingSchedule"
        Me.nbxServicingSchedule.Size = New System.Drawing.Size(168, 20)
        Me.nbxServicingSchedule.TabIndex = 28
        Me.nbxServicingSchedule.Value = ""
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(496, 5)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(100, 100)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 103
        Me.spbPhoto.TabStop = False
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(592, 419)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 52
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbSerialNo
        '
        Me.stbSerialNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSerialNo.CapitalizeFirstLetter = False
        Me.stbSerialNo.EntryErrorMSG = ""
        Me.stbSerialNo.Location = New System.Drawing.Point(169, 7)
        Me.stbSerialNo.Name = "stbSerialNo"
        Me.stbSerialNo.RegularExpression = ""
        Me.stbSerialNo.Size = New System.Drawing.Size(170, 20)
        Me.stbSerialNo.TabIndex = 1
        '
        'lblSerialNo
        '
        Me.lblSerialNo.Location = New System.Drawing.Point(12, 6)
        Me.lblSerialNo.Name = "lblSerialNo"
        Me.lblSerialNo.Size = New System.Drawing.Size(151, 20)
        Me.lblSerialNo.TabIndex = 0
        Me.lblSerialNo.Text = "Serial No"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(358, 13)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(127, 20)
        Me.lblPhoto.TabIndex = 24
        Me.lblPhoto.Text = "Photo"
        '
        'lblAssetSourceID
        '
        Me.lblAssetSourceID.Location = New System.Drawing.Point(12, 78)
        Me.lblAssetSourceID.Name = "lblAssetSourceID"
        Me.lblAssetSourceID.Size = New System.Drawing.Size(151, 20)
        Me.lblAssetSourceID.TabIndex = 6
        Me.lblAssetSourceID.Text = "Source"
        '
        'lblAssetCategoryID
        '
        Me.lblAssetCategoryID.Location = New System.Drawing.Point(12, 98)
        Me.lblAssetCategoryID.Name = "lblAssetCategoryID"
        Me.lblAssetCategoryID.Size = New System.Drawing.Size(151, 20)
        Me.lblAssetCategoryID.TabIndex = 8
        Me.lblAssetCategoryID.Text = "Asset Category"
        '
        'lblDeptID
        '
        Me.lblDeptID.Location = New System.Drawing.Point(12, 121)
        Me.lblDeptID.Name = "lblDeptID"
        Me.lblDeptID.Size = New System.Drawing.Size(151, 20)
        Me.lblDeptID.TabIndex = 10
        Me.lblDeptID.Text = "Department"
        '
        'lblItemDescription
        '
        Me.lblItemDescription.Location = New System.Drawing.Point(12, 153)
        Me.lblItemDescription.Name = "lblItemDescription"
        Me.lblItemDescription.Size = New System.Drawing.Size(151, 20)
        Me.lblItemDescription.TabIndex = 12
        Me.lblItemDescription.Text = "Description"
        '
        'lblBrand
        '
        Me.lblBrand.Location = New System.Drawing.Point(12, 212)
        Me.lblBrand.Name = "lblBrand"
        Me.lblBrand.Size = New System.Drawing.Size(151, 20)
        Me.lblBrand.TabIndex = 14
        Me.lblBrand.Text = "Brand/Make"
        '
        'lblQuantity
        '
        Me.lblQuantity.Location = New System.Drawing.Point(12, 299)
        Me.lblQuantity.Name = "lblQuantity"
        Me.lblQuantity.Size = New System.Drawing.Size(151, 20)
        Me.lblQuantity.TabIndex = 18
        Me.lblQuantity.Text = "Quantity"
        '
        'lblValue
        '
        Me.lblValue.Location = New System.Drawing.Point(12, 274)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(151, 20)
        Me.lblValue.TabIndex = 16
        Me.lblValue.Text = "Value"
        '
        'lblDateOfPurchase
        '
        Me.lblDateOfPurchase.Location = New System.Drawing.Point(12, 320)
        Me.lblDateOfPurchase.Name = "lblDateOfPurchase"
        Me.lblDateOfPurchase.Size = New System.Drawing.Size(151, 20)
        Me.lblDateOfPurchase.TabIndex = 20
        Me.lblDateOfPurchase.Text = "Date Of Purchase"
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(12, 346)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(151, 20)
        Me.lblSupplierNo.TabIndex = 22
        Me.lblSupplierNo.Text = "Supplier"
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(352, 149)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(136, 20)
        Me.lblInvoiceNo.TabIndex = 29
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(352, 173)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(136, 20)
        Me.lblInvoiceDate.TabIndex = 31
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'lblDateOfDelivery
        '
        Me.lblDateOfDelivery.Location = New System.Drawing.Point(352, 196)
        Me.lblDateOfDelivery.Name = "lblDateOfDelivery"
        Me.lblDateOfDelivery.Size = New System.Drawing.Size(136, 20)
        Me.lblDateOfDelivery.TabIndex = 33
        Me.lblDateOfDelivery.Text = "Date Of Delivery"
        '
        'lblSalvageValue
        '
        Me.lblSalvageValue.Location = New System.Drawing.Point(352, 219)
        Me.lblSalvageValue.Name = "lblSalvageValue"
        Me.lblSalvageValue.Size = New System.Drawing.Size(136, 20)
        Me.lblSalvageValue.TabIndex = 35
        Me.lblSalvageValue.Text = "Salvage Value"
        '
        'lblDepreciationRate
        '
        Me.lblDepreciationRate.Location = New System.Drawing.Point(352, 242)
        Me.lblDepreciationRate.Name = "lblDepreciationRate"
        Me.lblDepreciationRate.Size = New System.Drawing.Size(136, 20)
        Me.lblDepreciationRate.TabIndex = 37
        Me.lblDepreciationRate.Text = "Depreciation Rate"
        '
        'lblUsefulLife
        '
        Me.lblUsefulLife.Location = New System.Drawing.Point(352, 265)
        Me.lblUsefulLife.Name = "lblUsefulLife"
        Me.lblUsefulLife.Size = New System.Drawing.Size(136, 20)
        Me.lblUsefulLife.TabIndex = 39
        Me.lblUsefulLife.Text = "Useful Life"
        '
        'lblDepreciationMethodID
        '
        Me.lblDepreciationMethodID.Location = New System.Drawing.Point(352, 288)
        Me.lblDepreciationMethodID.Name = "lblDepreciationMethodID"
        Me.lblDepreciationMethodID.Size = New System.Drawing.Size(136, 20)
        Me.lblDepreciationMethodID.TabIndex = 41
        Me.lblDepreciationMethodID.Text = "Depreciation Method"
        '
        'lblDepreciationStartDate
        '
        Me.lblDepreciationStartDate.Location = New System.Drawing.Point(352, 311)
        Me.lblDepreciationStartDate.Name = "lblDepreciationStartDate"
        Me.lblDepreciationStartDate.Size = New System.Drawing.Size(136, 20)
        Me.lblDepreciationStartDate.TabIndex = 43
        Me.lblDepreciationStartDate.Text = "Depreciation StartDate"
        '
        'lblAssignedTo
        '
        Me.lblAssignedTo.Location = New System.Drawing.Point(352, 334)
        Me.lblAssignedTo.Name = "lblAssignedTo"
        Me.lblAssignedTo.Size = New System.Drawing.Size(136, 20)
        Me.lblAssignedTo.TabIndex = 45
        Me.lblAssignedTo.Text = "Assigned To"
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(352, 357)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(136, 20)
        Me.lblLocation.TabIndex = 47
        Me.lblLocation.Text = "Location"
        '
        'lblServicingSchedule
        '
        Me.lblServicingSchedule.Location = New System.Drawing.Point(352, 126)
        Me.lblServicingSchedule.Name = "lblServicingSchedule"
        Me.lblServicingSchedule.Size = New System.Drawing.Size(133, 20)
        Me.lblServicingSchedule.TabIndex = 27
        Me.lblServicingSchedule.Text = "Servicing Schedule (Days)"
        '
        'btnClearPhoto
        '
        Me.btnClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClearPhoto.Location = New System.Drawing.Point(606, 79)
        Me.btnClearPhoto.Name = "btnClearPhoto"
        Me.btnClearPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnClearPhoto.TabIndex = 26
        Me.btnClearPhoto.Text = "Clear"
        Me.btnClearPhoto.UseVisualStyleBackColor = True
        '
        'btnLoadPhoto
        '
        Me.btnLoadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPhoto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLoadPhoto.Location = New System.Drawing.Point(606, 8)
        Me.btnLoadPhoto.Name = "btnLoadPhoto"
        Me.btnLoadPhoto.Size = New System.Drawing.Size(58, 23)
        Me.btnLoadPhoto.TabIndex = 25
        Me.btnLoadPhoto.Text = "Load..."
        Me.btnLoadPhoto.UseVisualStyleBackColor = True
        '
        'stbInstitutionalID
        '
        Me.stbInstitutionalID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInstitutionalID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInstitutionalID, "InstitutionalID")
        Me.stbInstitutionalID.EntryErrorMSG = ""
        Me.stbInstitutionalID.Location = New System.Drawing.Point(169, 53)
        Me.stbInstitutionalID.Name = "stbInstitutionalID"
        Me.stbInstitutionalID.RegularExpression = ""
        Me.stbInstitutionalID.Size = New System.Drawing.Size(170, 20)
        Me.stbInstitutionalID.TabIndex = 5
        '
        'lblInstitutionalID
        '
        Me.lblInstitutionalID.Location = New System.Drawing.Point(12, 52)
        Me.lblInstitutionalID.Name = "lblInstitutionalID"
        Me.lblInstitutionalID.Size = New System.Drawing.Size(151, 20)
        Me.lblInstitutionalID.TabIndex = 4
        Me.lblInstitutionalID.Text = "Institutional ID"
        '
        'stbManufacturerID
        '
        Me.stbManufacturerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbManufacturerID.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbManufacturerID, "ManufacturerID")
        Me.stbManufacturerID.EntryErrorMSG = ""
        Me.stbManufacturerID.Location = New System.Drawing.Point(169, 30)
        Me.stbManufacturerID.Name = "stbManufacturerID"
        Me.stbManufacturerID.RegularExpression = ""
        Me.stbManufacturerID.Size = New System.Drawing.Size(170, 20)
        Me.stbManufacturerID.TabIndex = 3
        '
        'lblManufactureID
        '
        Me.lblManufactureID.Location = New System.Drawing.Point(12, 30)
        Me.lblManufactureID.Name = "lblManufactureID"
        Me.lblManufactureID.Size = New System.Drawing.Size(151, 20)
        Me.lblManufactureID.TabIndex = 2
        Me.lblManufactureID.Text = "Manufacture ID"
        '
        'frmAssetRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(676, 448)
        Me.Controls.Add(Me.stbManufacturerID)
        Me.Controls.Add(Me.lblManufactureID)
        Me.Controls.Add(Me.stbInstitutionalID)
        Me.Controls.Add(Me.lblInstitutionalID)
        Me.Controls.Add(Me.btnClearPhoto)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.btnLoadPhoto)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbSerialNo)
        Me.Controls.Add(Me.lblSerialNo)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.cboAssetSourceID)
        Me.Controls.Add(Me.lblAssetSourceID)
        Me.Controls.Add(Me.cboAssetCategoryID)
        Me.Controls.Add(Me.lblAssetCategoryID)
        Me.Controls.Add(Me.cboDeptID)
        Me.Controls.Add(Me.lblDeptID)
        Me.Controls.Add(Me.stbItemDescription)
        Me.Controls.Add(Me.lblItemDescription)
        Me.Controls.Add(Me.stbBrand)
        Me.Controls.Add(Me.lblBrand)
        Me.Controls.Add(Me.nbxValue)
        Me.Controls.Add(Me.lblQuantity)
        Me.Controls.Add(Me.nbxQuantity)
        Me.Controls.Add(Me.lblValue)
        Me.Controls.Add(Me.dtpDateOfPurchase)
        Me.Controls.Add(Me.lblDateOfPurchase)
        Me.Controls.Add(Me.cboSupplierNo)
        Me.Controls.Add(Me.lblSupplierNo)
        Me.Controls.Add(Me.stbInvoiceNo)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Controls.Add(Me.dtpDateOfDelivery)
        Me.Controls.Add(Me.lblDateOfDelivery)
        Me.Controls.Add(Me.nbxSalvageValue)
        Me.Controls.Add(Me.lblSalvageValue)
        Me.Controls.Add(Me.nbxDepreciationRate)
        Me.Controls.Add(Me.lblDepreciationRate)
        Me.Controls.Add(Me.nbxUsefulLife)
        Me.Controls.Add(Me.lblUsefulLife)
        Me.Controls.Add(Me.cboDepreciationMethodID)
        Me.Controls.Add(Me.lblDepreciationMethodID)
        Me.Controls.Add(Me.dtpDepreciationStartDate)
        Me.Controls.Add(Me.lblDepreciationStartDate)
        Me.Controls.Add(Me.stbAssignedTo)
        Me.Controls.Add(Me.lblAssignedTo)
        Me.Controls.Add(Me.stbLocation)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.nbxServicingSchedule)
        Me.Controls.Add(Me.lblServicingSchedule)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAssetRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "AssetRegister"
        Me.Text = "Asset Register"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbSerialNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSerialNo As System.Windows.Forms.Label
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents cboAssetSourceID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssetSourceID As System.Windows.Forms.Label
    Friend WithEvents cboAssetCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssetCategoryID As System.Windows.Forms.Label
    Friend WithEvents cboDeptID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeptID As System.Windows.Forms.Label
    Friend WithEvents stbItemDescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemDescription As System.Windows.Forms.Label
    Friend WithEvents stbBrand As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBrand As System.Windows.Forms.Label
    Friend WithEvents nbxValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblQuantity As System.Windows.Forms.Label
    Friend WithEvents nbxQuantity As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfPurchase As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateOfPurchase As System.Windows.Forms.Label
    Friend WithEvents cboSupplierNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierNo As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfDelivery As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateOfDelivery As System.Windows.Forms.Label
    Friend WithEvents nbxSalvageValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblSalvageValue As System.Windows.Forms.Label
    Friend WithEvents nbxDepreciationRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblDepreciationRate As System.Windows.Forms.Label
    Friend WithEvents nbxUsefulLife As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUsefulLife As System.Windows.Forms.Label
    Friend WithEvents cboDepreciationMethodID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDepreciationMethodID As System.Windows.Forms.Label
    Friend WithEvents dtpDepreciationStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDepreciationStartDate As System.Windows.Forms.Label
    Friend WithEvents stbAssignedTo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAssignedTo As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents nbxServicingSchedule As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblServicingSchedule As System.Windows.Forms.Label
    Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnLoadPhoto As System.Windows.Forms.Button
    Friend WithEvents stbInstitutionalID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInstitutionalID As System.Windows.Forms.Label
    Friend WithEvents stbManufacturerID As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblManufactureID As System.Windows.Forms.Label

End Class