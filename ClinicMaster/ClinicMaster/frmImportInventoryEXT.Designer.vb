<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportInventoryEXT : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
    End Sub


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportInventoryEXT))
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.dgvInventoryEXT = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAgent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvInventoryEXT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(3, 215)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 24)
        Me.btnRefresh.TabIndex = 26
        Me.btnRefresh.Tag = ""
        Me.btnRefresh.Text = "&Refresh"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(160, 219)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 24
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvInventoryEXT
        '
        Me.dgvInventoryEXT.AllowUserToAddRows = False
        Me.dgvInventoryEXT.AllowUserToDeleteRows = False
        Me.dgvInventoryEXT.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvInventoryEXT.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInventoryEXT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInventoryEXT.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInventoryEXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInventoryEXT.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInventoryEXT.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryEXT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInventoryEXT.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colAgent})
        Me.dgvInventoryEXT.EnableHeadersVisualStyles = False
        Me.dgvInventoryEXT.GridColor = System.Drawing.Color.Khaki
        Me.dgvInventoryEXT.Location = New System.Drawing.Point(7, 2)
        Me.dgvInventoryEXT.Name = "dgvInventoryEXT"
        Me.dgvInventoryEXT.ReadOnly = True
        Me.dgvInventoryEXT.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventoryEXT.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInventoryEXT.RowHeadersVisible = False
        Me.dgvInventoryEXT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInventoryEXT.Size = New System.Drawing.Size(667, 207)
        Me.dgvInventoryEXT.TabIndex = 23
        Me.dgvInventoryEXT.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(580, 215)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 25
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'colItemCode
        '
        Me.colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colItemCategory
        '
        Me.colItemCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colAgent
        '
        Me.colAgent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAgent.DataPropertyName = "AgentNo"
        Me.colAgent.HeaderText = "Agent"
        Me.colAgent.Name = "colAgent"
        Me.colAgent.ReadOnly = True
        '
        'frmImportInventoryEXT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 245)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvInventoryEXT)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportInventoryEXT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory EXT"
        CType(Me.dgvInventoryEXT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents dgvInventoryEXT As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAgent As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
