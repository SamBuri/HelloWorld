<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHasSubTests : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal testcode As String, dataGridView As DataGridView, dataGridColumn As DataGridViewTextBoxColumn, selectedRow As Integer)
        MyClass.New()
        Me.defaultTestCode = testcode
        Me.selectedRow = selectedRow
        Me.dataGridView = dataGridView
        Me.dataGridColumn = dataGridColumn

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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHasSubTests))
        Me.dgvTemplates = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTsubTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPossibleResults = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnOK = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvTemplates
        '
        Me.dgvTemplates.AllowUserToAddRows = False
        Me.dgvTemplates.AllowUserToDeleteRows = False
        Me.dgvTemplates.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvTemplates.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
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
        Me.dgvTemplates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTsubTestName, Me.colPossibleResults})
        Me.dgvTemplates.EnableHeadersVisualStyles = False
        Me.dgvTemplates.GridColor = System.Drawing.Color.Khaki
        Me.dgvTemplates.Location = New System.Drawing.Point(12, 1)
        Me.dgvTemplates.Name = "dgvTemplates"
        Me.dgvTemplates.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTemplates.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTemplates.RowHeadersVisible = False
        Me.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTemplates.Size = New System.Drawing.Size(508, 196)
        Me.dgvTemplates.TabIndex = 1
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
        'colTsubTestName
        '
        Me.colTsubTestName.DataPropertyName = "SubTestName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colTsubTestName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTsubTestName.HeaderText = "Sub Test Name"
        Me.colTsubTestName.MaxInputLength = 40
        Me.colTsubTestName.Name = "colTsubTestName"
        Me.colTsubTestName.ReadOnly = True
        Me.colTsubTestName.Width = 150
        '
        'colPossibleResults
        '
        Me.colPossibleResults.DataPropertyName = "PossibleResults"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colPossibleResults.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPossibleResults.HeaderText = "Possible Result"
        Me.colPossibleResults.Name = "colPossibleResults"
        Me.colPossibleResults.ReadOnly = True
        Me.colPossibleResults.Width = 250
        '
        'fbnOK
        '
        Me.fbnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOK.Location = New System.Drawing.Point(8, 211)
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
        Me.lblMessage.Location = New System.Drawing.Point(99, 212)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(314, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: Check Include and then OK"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(438, 211)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmHasSubTests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 247)
        Me.Controls.Add(Me.fbnOK)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvTemplates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmHasSubTests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Has SubTests Possible Results"
        CType(Me.dgvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvTemplates As System.Windows.Forms.DataGridView
    Friend WithEvents fbnOK As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTsubTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPossibleResults As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
