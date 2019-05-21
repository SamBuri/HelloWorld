
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarCodeDetails : Inherits System.Windows.Forms.Form
    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal itemCategoryID As String)
        MyClass.New()
        Me.defaultItemCategoryID = itemCategoryID
    End Sub

    Public Sub New(ByVal itemCategoryID As String, ByVal itemCode As String)
        MyClass.New(itemCategoryID)
        Me.defaultItemCode = itemCode
    End Sub


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarCodeDetails))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbBarCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBarCode = New System.Windows.Forms.Label()
        Me.cboItemCode = New System.Windows.Forms.ComboBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.stbUnitMeasure = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitMeasure = New System.Windows.Forms.Label()
        Me.stbItemName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblItemName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 131)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 8
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(276, 131)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 9
        Me.fbnDelete.Tag = "BarCodeDetails"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 158)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 10
        Me.ebnSaveUpdate.Tag = "BarCodeDetails"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbBarCode
        '
        Me.stbBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBarCode.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBarCode, "BarCode")
        Me.stbBarCode.EntryErrorMSG = ""
        Me.stbBarCode.Location = New System.Drawing.Point(155, 105)
        Me.stbBarCode.Name = "stbBarCode"
        Me.stbBarCode.RegularExpression = ""
        Me.stbBarCode.Size = New System.Drawing.Size(196, 20)
        Me.stbBarCode.TabIndex = 7
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(276, 158)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblBarCode
        '
        Me.lblBarCode.Location = New System.Drawing.Point(9, 107)
        Me.lblBarCode.Name = "lblBarCode"
        Me.lblBarCode.Size = New System.Drawing.Size(140, 20)
        Me.lblBarCode.TabIndex = 6
        Me.lblBarCode.Text = "BarCode"
        '
        'cboItemCode
        '
        Me.cboItemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCode.DropDownWidth = 300
        Me.cboItemCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCode.FormattingEnabled = True
        Me.cboItemCode.Location = New System.Drawing.Point(155, 14)
        Me.cboItemCode.Name = "cboItemCode"
        Me.cboItemCode.Size = New System.Drawing.Size(196, 21)
        Me.cboItemCode.TabIndex = 1
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(9, 17)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(140, 21)
        Me.lblItemCode.TabIndex = 0
        Me.lblItemCode.Text = "Item Code"
        '
        'stbUnitMeasure
        '
        Me.stbUnitMeasure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitMeasure.CapitalizeFirstLetter = True
        Me.stbUnitMeasure.Enabled = False
        Me.stbUnitMeasure.EntryErrorMSG = ""
        Me.stbUnitMeasure.Location = New System.Drawing.Point(155, 83)
        Me.stbUnitMeasure.MaxLength = 20
        Me.stbUnitMeasure.Name = "stbUnitMeasure"
        Me.stbUnitMeasure.RegularExpression = ""
        Me.stbUnitMeasure.Size = New System.Drawing.Size(196, 20)
        Me.stbUnitMeasure.TabIndex = 5
        '
        'lblUnitMeasure
        '
        Me.lblUnitMeasure.Location = New System.Drawing.Point(9, 85)
        Me.lblUnitMeasure.Name = "lblUnitMeasure"
        Me.lblUnitMeasure.Size = New System.Drawing.Size(140, 21)
        Me.lblUnitMeasure.TabIndex = 4
        Me.lblUnitMeasure.Text = "Unit of Measure"
        '
        'stbItemName
        '
        Me.stbItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemName.CapitalizeFirstLetter = False
        Me.stbItemName.EntryErrorMSG = ""
        Me.stbItemName.Location = New System.Drawing.Point(155, 39)
        Me.stbItemName.MaxLength = 41
        Me.stbItemName.Multiline = True
        Me.stbItemName.Name = "stbItemName"
        Me.stbItemName.ReadOnly = True
        Me.stbItemName.RegularExpression = ""
        Me.stbItemName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbItemName.Size = New System.Drawing.Size(196, 42)
        Me.stbItemName.TabIndex = 3
        '
        'lblItemName
        '
        Me.lblItemName.Location = New System.Drawing.Point(9, 41)
        Me.lblItemName.Name = "lblItemName"
        Me.lblItemName.Size = New System.Drawing.Size(140, 21)
        Me.lblItemName.TabIndex = 2
        Me.lblItemName.Text = "Item Name"
        '
        'frmBarCodeDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(375, 190)
        Me.Controls.Add(Me.stbUnitMeasure)
        Me.Controls.Add(Me.lblUnitMeasure)
        Me.Controls.Add(Me.stbItemName)
        Me.Controls.Add(Me.lblItemName)
        Me.Controls.Add(Me.cboItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbBarCode)
        Me.Controls.Add(Me.lblBarCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBarCodeDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bar Code Details"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbBarCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBarCode As System.Windows.Forms.Label
    Friend WithEvents cboItemCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents stbUnitMeasure As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitMeasure As System.Windows.Forms.Label
    Friend WithEvents stbItemName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemName As System.Windows.Forms.Label

End Class