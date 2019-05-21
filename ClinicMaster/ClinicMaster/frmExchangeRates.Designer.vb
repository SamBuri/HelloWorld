
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExchangeRates : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExchangeRates))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.dgvExchangeRates = New System.Windows.Forms.DataGridView()
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBuying = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSelling = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExchangeRatesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.dgvExchangeRates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(426, 204)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'dgvExchangeRates
        '
        Me.dgvExchangeRates.AllowUserToOrderColumns = True
        Me.dgvExchangeRates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExchangeRates.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExchangeRates.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExchangeRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCurrenciesID, Me.colBuying, Me.colSelling, Me.colExchangeRatesSaved})
        Me.dgvExchangeRates.EnableHeadersVisualStyles = False
        Me.dgvExchangeRates.GridColor = System.Drawing.Color.Khaki
        Me.dgvExchangeRates.Location = New System.Drawing.Point(12, 12)
        Me.dgvExchangeRates.Name = "dgvExchangeRates"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExchangeRates.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvExchangeRates.Size = New System.Drawing.Size(486, 186)
        Me.dgvExchangeRates.TabIndex = 0
        Me.dgvExchangeRates.Text = "DataGridView1"
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(12, 204)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(72, 24)
        Me.fbnSave.TabIndex = 1
        Me.fbnSave.Tag = "ExchangeRates"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = False
        '
        'colCurrenciesID
        '
        Me.colCurrenciesID.DataPropertyName = "CurrenciesID"
        Me.colCurrenciesID.DisplayStyleForCurrentCellOnly = True
        Me.colCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCurrenciesID.HeaderText = "Currency"
        Me.colCurrenciesID.Name = "colCurrenciesID"
        Me.colCurrenciesID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCurrenciesID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCurrenciesID.Width = 180
        '
        'colBuying
        '
        Me.colBuying.DataPropertyName = "Buying"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colBuying.DefaultCellStyle = DataGridViewCellStyle2
        Me.colBuying.HeaderText = "Buying (Cashier)"
        Me.colBuying.MaxInputLength = 12
        Me.colBuying.Name = "colBuying"
        '
        'colSelling
        '
        Me.colSelling.DataPropertyName = "Selling"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colSelling.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSelling.HeaderText = "Selling (Billing)"
        Me.colSelling.MaxInputLength = 12
        Me.colSelling.Name = "colSelling"
        '
        'colExchangeRatesSaved
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = False
        Me.colExchangeRatesSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colExchangeRatesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExchangeRatesSaved.HeaderText = "Saved"
        Me.colExchangeRatesSaved.Name = "colExchangeRatesSaved"
        Me.colExchangeRatesSaved.ReadOnly = True
        Me.colExchangeRatesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExchangeRatesSaved.Width = 50
        '
        'frmExchangeRates
        '
        Me.AcceptButton = Me.fbnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(510, 240)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.dgvExchangeRates)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExchangeRates"
        Me.Text = "Exchange Rates"
        CType(Me.dgvExchangeRates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents dgvExchangeRates As System.Windows.Forms.DataGridView
    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colCurrenciesID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colBuying As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSelling As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExchangeRatesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class