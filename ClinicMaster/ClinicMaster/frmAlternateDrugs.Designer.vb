
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAlternateDrugs : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal drugNo As String)
        MyClass.New()
        Me.drugNo = drugNo
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAlternateDrugs))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton
        Me.dgvAlternateDrugs = New System.Windows.Forms.DataGridView
        Me.colAlternateDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAlternateDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAvailableStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem
        Me.lblMessage = New System.Windows.Forms.Label
        CType(Me.dgvAlternateDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(451, 214)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvAlternateDrugs
        '
        Me.dgvAlternateDrugs.AllowUserToAddRows = False
        Me.dgvAlternateDrugs.AllowUserToDeleteRows = False
        Me.dgvAlternateDrugs.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAlternateDrugs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAlternateDrugs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAlternateDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAlternateDrugs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAlternateDrugs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAlternateDrugs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAlternateDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAlternateDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAlternateDrugNo, Me.colAlternateDrugName, Me.colAvailableStock})
        Me.dgvAlternateDrugs.ContextMenuStrip = Me.cmsAlertList
        Me.dgvAlternateDrugs.EnableHeadersVisualStyles = False
        Me.dgvAlternateDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvAlternateDrugs.Location = New System.Drawing.Point(8, 41)
        Me.dgvAlternateDrugs.Name = "dgvAlternateDrugs"
        Me.dgvAlternateDrugs.ReadOnly = True
        Me.dgvAlternateDrugs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAlternateDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAlternateDrugs.RowHeadersVisible = False
        Me.dgvAlternateDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAlternateDrugs.Size = New System.Drawing.Size(515, 166)
        Me.dgvAlternateDrugs.TabIndex = 1
        Me.dgvAlternateDrugs.Text = "DataGridView1"
        '
        'colAlternateDrugNo
        '
        Me.colAlternateDrugNo.DataPropertyName = "AlternateDrugNo"
        Me.colAlternateDrugNo.HeaderText = "Alternate Drug No"
        Me.colAlternateDrugNo.Name = "colAlternateDrugNo"
        Me.colAlternateDrugNo.ReadOnly = True
        '
        'colAlternateDrugName
        '
        Me.colAlternateDrugName.DataPropertyName = "AlternateDrugName"
        Me.colAlternateDrugName.HeaderText = "Alternate Drug Name"
        Me.colAlternateDrugName.Name = "colAlternateDrugName"
        Me.colAlternateDrugName.ReadOnly = True
        Me.colAlternateDrugName.Width = 300
        '
        'colAvailableStock
        '
        Me.colAvailableStock.DataPropertyName = "AvailableStock"
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 90
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(123, 48)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(12, 9)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(511, 29)
        Me.lblMessage.TabIndex = 0
        Me.lblMessage.Text = "Alternate drug(s) for: "
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmAlternateDrugs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(533, 250)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvAlternateDrugs)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAlternateDrugs"
        Me.Text = "Alternate Drug(s)"
        CType(Me.dgvAlternateDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvAlternateDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colAlternateDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvailableStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.Label

End Class