<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrfrequentlyprescribeddrugs
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrfrequentlyprescribeddrugs))
        Me.dgvfrequentlyPrescribedDrugs = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colhidden = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.fbnOK = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fcbCategoryNo = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.lblCategoryNo = New System.Windows.Forms.Label()
        CType(Me.dgvfrequentlyPrescribedDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvfrequentlyPrescribedDrugs
        '
        Me.dgvfrequentlyPrescribedDrugs.AllowUserToAddRows = False
        Me.dgvfrequentlyPrescribedDrugs.AllowUserToDeleteRows = False
        Me.dgvfrequentlyPrescribedDrugs.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvfrequentlyPrescribedDrugs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvfrequentlyPrescribedDrugs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvfrequentlyPrescribedDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvfrequentlyPrescribedDrugs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvfrequentlyPrescribedDrugs.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvfrequentlyPrescribedDrugs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfrequentlyPrescribedDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvfrequentlyPrescribedDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.ColItemCode, Me.colDrugName, Me.Colhidden})
        Me.dgvfrequentlyPrescribedDrugs.EnableHeadersVisualStyles = False
        Me.dgvfrequentlyPrescribedDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvfrequentlyPrescribedDrugs.Location = New System.Drawing.Point(6, 35)
        Me.dgvfrequentlyPrescribedDrugs.Name = "dgvfrequentlyPrescribedDrugs"
        Me.dgvfrequentlyPrescribedDrugs.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvfrequentlyPrescribedDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvfrequentlyPrescribedDrugs.RowHeadersVisible = False
        Me.dgvfrequentlyPrescribedDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvfrequentlyPrescribedDrugs.Size = New System.Drawing.Size(549, 217)
        Me.dgvfrequentlyPrescribedDrugs.TabIndex = 1
        Me.dgvfrequentlyPrescribedDrugs.Text = "DataGridView1"
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
        'ColItemCode
        '
        Me.ColItemCode.DataPropertyName = "ItemCode"
        Me.ColItemCode.HeaderText = "Drug No"
        Me.ColItemCode.Name = "ColItemCode"
        '
        'colDrugName
        '
        Me.colDrugName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
        Me.colDrugName.Width = 300
        '
        'Colhidden
        '
        Me.Colhidden.ControlCaption = Nothing
        Me.Colhidden.DataPropertyName = "Hidden"
        Me.Colhidden.HeaderText = "Hidden"
        Me.Colhidden.Name = "Colhidden"
        Me.Colhidden.ReadOnly = True
        Me.Colhidden.SourceColumn = Nothing
        Me.Colhidden.Width = 60
        '
        'fbnOK
        '
        Me.fbnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOK.Location = New System.Drawing.Point(2, 261)
        Me.fbnOK.Name = "fbnOK"
        Me.fbnOK.Size = New System.Drawing.Size(72, 24)
        Me.fbnOK.TabIndex = 5
        Me.fbnOK.Text = "&OK"
        Me.fbnOK.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(62, 265)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(314, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(409, 261)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'fcbCategoryNo
        '
        Me.fcbCategoryNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbCategoryNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.fcbCategoryNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbCategoryNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbCategoryNo.FormattingEnabled = True
        Me.fcbCategoryNo.Location = New System.Drawing.Point(107, 8)
        Me.fcbCategoryNo.Name = "fcbCategoryNo"
        Me.fcbCategoryNo.ReadOnly = True
        Me.fcbCategoryNo.Size = New System.Drawing.Size(230, 21)
        Me.fcbCategoryNo.TabIndex = 9
        '
        'lblCategoryNo
        '
        Me.lblCategoryNo.Location = New System.Drawing.Point(6, 11)
        Me.lblCategoryNo.Name = "lblCategoryNo"
        Me.lblCategoryNo.Size = New System.Drawing.Size(95, 21)
        Me.lblCategoryNo.TabIndex = 8
        Me.lblCategoryNo.Text = "Drug Group"
        '
        'frmDrfrequentlyprescribeddrugs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 294)
        Me.Controls.Add(Me.fcbCategoryNo)
        Me.Controls.Add(Me.lblCategoryNo)
        Me.Controls.Add(Me.fbnOK)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvfrequentlyPrescribedDrugs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDrfrequentlyprescribeddrugs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Doctor Frequently Prescribed Drugs"
        CType(Me.dgvfrequentlyPrescribedDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvfrequentlyPrescribedDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents fbnOK As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fcbCategoryNo As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblCategoryNo As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colhidden As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
End Class
