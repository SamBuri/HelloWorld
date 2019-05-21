
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLookupDataMappings : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLookupDataMappings))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboObjectName = New System.Windows.Forms.ComboBox()
        Me.cboAgentNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblObjectName = New System.Windows.Forms.Label()
        Me.dgvLookupDataMappings = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDataID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataDes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAgentDataID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAgentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblAgentNo = New System.Windows.Forms.Label()
        CType(Me.dgvLookupDataMappings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 270)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(550, 270)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "LookupDataMappings"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 297)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "LookupDataMappings"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboObjectName
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboObjectName, "ObjectID")
        Me.cboObjectName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboObjectName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboObjectName.Location = New System.Drawing.Point(95, 6)
        Me.cboObjectName.Name = "cboObjectName"
        Me.cboObjectName.Size = New System.Drawing.Size(170, 21)
        Me.cboObjectName.TabIndex = 13
        '
        'cboAgentNo
        '
        Me.cboAgentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgentNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAgentNo.Location = New System.Drawing.Point(452, 6)
        Me.cboAgentNo.Name = "cboAgentNo"
        Me.cboAgentNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAgentNo.TabIndex = 15
        Me.cboAgentNo.Visible = False
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(550, 297)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblObjectName
        '
        Me.lblObjectName.Location = New System.Drawing.Point(12, 10)
        Me.lblObjectName.Name = "lblObjectName"
        Me.lblObjectName.Size = New System.Drawing.Size(77, 20)
        Me.lblObjectName.TabIndex = 11
        Me.lblObjectName.Text = "Object Name"
        '
        'dgvLookupDataMappings
        '
        Me.dgvLookupDataMappings.AllowUserToAddRows = False
        Me.dgvLookupDataMappings.AllowUserToDeleteRows = False
        Me.dgvLookupDataMappings.AllowUserToOrderColumns = True
        Me.dgvLookupDataMappings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvLookupDataMappings.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLookupDataMappings.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLookupDataMappings.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colDataID, Me.colDataDes, Me.colAgentDataID, Me.colAgentNo, Me.colSaved})
        Me.dgvLookupDataMappings.EnableHeadersVisualStyles = False
        Me.dgvLookupDataMappings.GridColor = System.Drawing.Color.Khaki
        Me.dgvLookupDataMappings.Location = New System.Drawing.Point(12, 40)
        Me.dgvLookupDataMappings.Name = "dgvLookupDataMappings"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLookupDataMappings.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLookupDataMappings.Size = New System.Drawing.Size(610, 224)
        Me.dgvLookupDataMappings.TabIndex = 12
        Me.dgvLookupDataMappings.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInclude.Width = 60
        '
        'colDataID
        '
        Me.colDataID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDataID.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDataID.HeaderText = "Data ID"
        Me.colDataID.Name = "colDataID"
        Me.colDataID.ReadOnly = True
        '
        'colDataDes
        '
        Me.colDataDes.HeaderText = "Description"
        Me.colDataDes.Name = "colDataDes"
        '
        'colAgentDataID
        '
        Me.colAgentDataID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAgentDataID.HeaderText = "Agent Data ID"
        Me.colAgentDataID.Name = "colAgentDataID"
        Me.colAgentDataID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colAgentNo
        '
        Me.colAgentNo.FillWeight = 50.0!
        Me.colAgentNo.HeaderText = "Agent No"
        Me.colAgentNo.Name = "colAgentNo"
        '
        'colSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.Width = 50
        '
        'lblAgentNo
        '
        Me.lblAgentNo.Location = New System.Drawing.Point(369, 10)
        Me.lblAgentNo.Name = "lblAgentNo"
        Me.lblAgentNo.Size = New System.Drawing.Size(77, 20)
        Me.lblAgentNo.TabIndex = 14
        Me.lblAgentNo.Text = "Agent No"
        Me.lblAgentNo.Visible = False
        '
        'frmLookupDataMappings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(639, 331)
        Me.Controls.Add(Me.cboAgentNo)
        Me.Controls.Add(Me.lblAgentNo)
        Me.Controls.Add(Me.cboObjectName)
        Me.Controls.Add(Me.dgvLookupDataMappings)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblObjectName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLookupDataMappings"
        Me.Text = "Lookup Data Mappings"
        CType(Me.dgvLookupDataMappings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblObjectName As System.Windows.Forms.Label
    Friend WithEvents dgvLookupDataMappings As System.Windows.Forms.DataGridView
    Friend WithEvents cboObjectName As System.Windows.Forms.ComboBox
    Friend WithEvents cboAgentNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAgentNo As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDataID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataDes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAgentDataID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAgentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class