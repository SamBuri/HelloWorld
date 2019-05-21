
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetTemplates : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal templateTypeID As String, ByVal controlTemplateNo As Control)
        MyClass.New()
        Me.templateTypeID = templateTypeID
        Me.templateNoControl = controlTemplateNo
    End Sub

    Public Sub New(ByVal templateTypeID As String, ByVal controlTemplateNo As Control, ByVal allowSelectMultiple As Boolean)
        MyClass.New(templateTypeID, controlTemplateNo)
        Me._AllowSelectMultiple = allowSelectMultiple
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetTemplates))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvTemplates = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTemplateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTemplateType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsTemplateList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsTemplateListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsTemplateListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnOK = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnAddNew = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTemplateList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(612, 246)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 4
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvTemplates
        '
        Me.dgvTemplates.AllowUserToAddRows = False
        Me.dgvTemplates.AllowUserToDeleteRows = False
        Me.dgvTemplates.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTemplates.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTemplates.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTemplates.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTemplates.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvTemplates.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTemplates.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTemplates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTemplateName, Me.colTemplateType, Me.colNotes})
        Me.dgvTemplates.ContextMenuStrip = Me.cmsTemplateList
        Me.dgvTemplates.EnableHeadersVisualStyles = False
        Me.dgvTemplates.GridColor = System.Drawing.Color.Khaki
        Me.dgvTemplates.Location = New System.Drawing.Point(8, 8)
        Me.dgvTemplates.Name = "dgvTemplates"
        Me.dgvTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTemplates.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTemplates.RowHeadersVisible = False
        Me.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTemplates.Size = New System.Drawing.Size(676, 231)
        Me.dgvTemplates.TabIndex = 0
        Me.dgvTemplates.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInclude.Width = 50
        '
        'colTemplateName
        '
        Me.colTemplateName.DataPropertyName = "TemplateName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colTemplateName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTemplateName.HeaderText = "Template Name"
        Me.colTemplateName.MaxInputLength = 40
        Me.colTemplateName.Name = "colTemplateName"
        Me.colTemplateName.ReadOnly = True
        Me.colTemplateName.Width = 150
        '
        'colTemplateType
        '
        Me.colTemplateType.DataPropertyName = "TemplateType"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colTemplateType.DefaultCellStyle = DataGridViewCellStyle4
        Me.colTemplateType.HeaderText = "Template Type"
        Me.colTemplateType.Name = "colTemplateType"
        Me.colTemplateType.ReadOnly = True
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle5
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        Me.colNotes.Width = 350
        '
        'cmsTemplateList
        '
        Me.cmsTemplateList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsTemplateList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsTemplateListCopy, Me.cmsTemplateListSelectAll})
        Me.cmsTemplateList.Name = "cmsSearch"
        Me.cmsTemplateList.Size = New System.Drawing.Size(123, 48)
        '
        'cmsTemplateListCopy
        '
        Me.cmsTemplateListCopy.AccessibleDescription = ""
        Me.cmsTemplateListCopy.Enabled = False
        Me.cmsTemplateListCopy.Image = CType(resources.GetObject("cmsTemplateListCopy.Image"), System.Drawing.Image)
        Me.cmsTemplateListCopy.Name = "cmsTemplateListCopy"
        Me.cmsTemplateListCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsTemplateListCopy.Text = "Copy"
        Me.cmsTemplateListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsTemplateListSelectAll
        '
        Me.cmsTemplateListSelectAll.Enabled = False
        Me.cmsTemplateListSelectAll.Name = "cmsTemplateListSelectAll"
        Me.cmsTemplateListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsTemplateListSelectAll.Text = "Select All"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(152, 253)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(314, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnOK
        '
        Me.fbnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOK.Location = New System.Drawing.Point(12, 246)
        Me.fbnOK.Name = "fbnOK"
        Me.fbnOK.Size = New System.Drawing.Size(72, 24)
        Me.fbnOK.TabIndex = 1
        Me.fbnOK.Text = "&OK"
        Me.fbnOK.UseVisualStyleBackColor = False
        '
        'fbnAddNew
        '
        Me.fbnAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnAddNew.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnAddNew.Location = New System.Drawing.Point(534, 246)
        Me.fbnAddNew.Name = "fbnAddNew"
        Me.fbnAddNew.Size = New System.Drawing.Size(72, 24)
        Me.fbnAddNew.TabIndex = 3
        Me.fbnAddNew.Text = "&Add New"
        Me.fbnAddNew.UseVisualStyleBackColor = False
        '
        'frmGetTemplates
        '
        Me.AcceptButton = Me.fbnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(694, 282)
        Me.Controls.Add(Me.fbnAddNew)
        Me.Controls.Add(Me.fbnOK)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvTemplates)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetTemplates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Templates"
        CType(Me.dgvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTemplateList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvTemplates As System.Windows.Forms.DataGridView
    Friend WithEvents cmsTemplateList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsTemplateListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsTemplateListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnOK As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTemplateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTemplateType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnAddNew As SyncSoft.Common.Win.Controls.FlatButton

End Class