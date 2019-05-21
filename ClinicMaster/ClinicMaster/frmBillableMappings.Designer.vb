
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillableMappings : Inherits System.Windows.Forms.Form


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal ItemCode As String, ByVal ItemCategoryID As String)
        MyClass.New()
        Me.defaultItemCode = ItemCode
        Me.defaultItemCategoryID = ItemCategoryID

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillableMappings))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.stbItemCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.lblAgentNo = New System.Windows.Forms.Label()
        Me.grpBillableMappings = New System.Windows.Forms.GroupBox()
        Me.dgvBillableMappings = New System.Windows.Forms.DataGridView()
        Me.colMappedTypeID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMappedCodeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboAgentNo = New System.Windows.Forms.ComboBox()
        Me.grpBillableMappings.SuspendLayout()
        CType(Me.dgvBillableMappings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 342)
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
        Me.fbnDelete.Location = New System.Drawing.Point(440, 341)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 8
        Me.fbnDelete.Tag = "BillableMappings"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 369)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 9
        Me.ebnSaveUpdate.Tag = "BillableMappings"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboItemCategoryID
        '
        Me.cboItemCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.Location = New System.Drawing.Point(135, 12)
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(170, 21)
        Me.cboItemCategoryID.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(440, 368)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 10
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(12, 12)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(135, 20)
        Me.lblItemCategoryID.TabIndex = 0
        Me.lblItemCategoryID.Text = "Item Category"
        '
        'stbItemCode
        '
        Me.stbItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemCode.CapitalizeFirstLetter = False
        Me.stbItemCode.EntryErrorMSG = ""
        Me.stbItemCode.Location = New System.Drawing.Point(135, 35)
        Me.stbItemCode.Name = "stbItemCode"
        Me.stbItemCode.RegularExpression = ""
        Me.stbItemCode.Size = New System.Drawing.Size(170, 20)
        Me.stbItemCode.TabIndex = 3
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(12, 35)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(135, 20)
        Me.lblItemCode.TabIndex = 2
        Me.lblItemCode.Text = "ItemCode"
        '
        'lblAgentNo
        '
        Me.lblAgentNo.Location = New System.Drawing.Point(15, 58)
        Me.lblAgentNo.Name = "lblAgentNo"
        Me.lblAgentNo.Size = New System.Drawing.Size(71, 20)
        Me.lblAgentNo.TabIndex = 4
        Me.lblAgentNo.Text = "Agent No"
        '
        'grpBillableMappings
        '
        Me.grpBillableMappings.Controls.Add(Me.dgvBillableMappings)
        Me.grpBillableMappings.Location = New System.Drawing.Point(12, 97)
        Me.grpBillableMappings.Name = "grpBillableMappings"
        Me.grpBillableMappings.Size = New System.Drawing.Size(503, 238)
        Me.grpBillableMappings.TabIndex = 6
        Me.grpBillableMappings.TabStop = False
        Me.grpBillableMappings.Text = "Billable Mappings"
        '
        'dgvBillableMappings
        '
        Me.dgvBillableMappings.AllowUserToOrderColumns = True
        Me.dgvBillableMappings.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillableMappings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBillableMappings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMappedTypeID, Me.colMappedCode, Me.colMappedCodeSaved})
        Me.dgvBillableMappings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBillableMappings.EnableHeadersVisualStyles = False
        Me.dgvBillableMappings.GridColor = System.Drawing.Color.Khaki
        Me.dgvBillableMappings.Location = New System.Drawing.Point(3, 16)
        Me.dgvBillableMappings.Name = "dgvBillableMappings"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillableMappings.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBillableMappings.Size = New System.Drawing.Size(497, 219)
        Me.dgvBillableMappings.TabIndex = 1
        Me.dgvBillableMappings.Text = "DataGridView1"
        '
        'colMappedTypeID
        '
        Me.colMappedTypeID.DataPropertyName = "MappedTypeID"
        Me.colMappedTypeID.DisplayStyleForCurrentCellOnly = True
        Me.colMappedTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colMappedTypeID.HeaderText = "Mapped Type"
        Me.colMappedTypeID.Name = "colMappedTypeID"
        Me.colMappedTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMappedTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colMappedTypeID.Width = 250
        '
        'colMappedCode
        '
        Me.colMappedCode.DataPropertyName = "MappedCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colMappedCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colMappedCode.HeaderText = "Mapped Code"
        Me.colMappedCode.Name = "colMappedCode"
        Me.colMappedCode.ReadOnly = True
        Me.colMappedCode.Width = 150
        '
        'colMappedCodeSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colMappedCodeSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colMappedCodeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colMappedCodeSaved.HeaderText = "Saved"
        Me.colMappedCodeSaved.Name = "colMappedCodeSaved"
        Me.colMappedCodeSaved.ReadOnly = True
        Me.colMappedCodeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colMappedCodeSaved.Width = 50
        '
        'cboAgentNo
        '
        Me.cboAgentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgentNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAgentNo.Location = New System.Drawing.Point(135, 58)
        Me.cboAgentNo.Name = "cboAgentNo"
        Me.cboAgentNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAgentNo.TabIndex = 11
        '
        'frmBillableMappings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(530, 396)
        Me.Controls.Add(Me.cboAgentNo)
        Me.Controls.Add(Me.cboItemCategoryID)
        Me.Controls.Add(Me.grpBillableMappings)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblItemCategoryID)
        Me.Controls.Add(Me.stbItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.lblAgentNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBillableMappings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "BillableMappings"
        Me.Text = "Billable Mappings"
        Me.grpBillableMappings.ResumeLayout(false)
        CType(Me.dgvBillableMappings,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents stbItemCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents lblAgentNo As System.Windows.Forms.Label
    Friend WithEvents grpBillableMappings As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBillableMappings As System.Windows.Forms.DataGridView
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents colMappedTypeID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMappedCodeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboAgentNo As System.Windows.Forms.ComboBox

End Class