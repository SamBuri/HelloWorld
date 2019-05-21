
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhysicalStockCountReport : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPhysicalStockCountReport))
        Me.stbGeneralNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRecordDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPSCNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPSCNo = New System.Windows.Forms.Label()
        Me.lblGeneralNotes = New System.Windows.Forms.Label()
        Me.lblRecordDateTime = New System.Windows.Forms.Label()
        Me.dgvPhysicalStockCountDetails = New System.Windows.Forms.DataGridView()
        Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSystemQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhysicalCountQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVariance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblRecordsImported = New System.Windows.Forms.Label()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvPhysicalStockCountDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbGeneralNotes
        '
        Me.stbGeneralNotes.BackColor = System.Drawing.SystemColors.Info
        Me.stbGeneralNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGeneralNotes.CapitalizeFirstLetter = False
        Me.stbGeneralNotes.EntryErrorMSG = ""
        Me.stbGeneralNotes.Location = New System.Drawing.Point(630, 5)
        Me.stbGeneralNotes.Multiline = True
        Me.stbGeneralNotes.Name = "stbGeneralNotes"
        Me.stbGeneralNotes.ReadOnly = True
        Me.stbGeneralNotes.RegularExpression = ""
        Me.stbGeneralNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbGeneralNotes.Size = New System.Drawing.Size(342, 30)
        Me.stbGeneralNotes.TabIndex = 6
        '
        'stbRecordDate
        '
        Me.stbRecordDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRecordDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRecordDate.CapitalizeFirstLetter = False
        Me.stbRecordDate.EntryErrorMSG = ""
        Me.stbRecordDate.Location = New System.Drawing.Point(218, 34)
        Me.stbRecordDate.Name = "stbRecordDate"
        Me.stbRecordDate.ReadOnly = True
        Me.stbRecordDate.RegularExpression = ""
        Me.stbRecordDate.Size = New System.Drawing.Size(170, 20)
        Me.stbRecordDate.TabIndex = 57
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(917, 419)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPSCNo
        '
        Me.stbPSCNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPSCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPSCNo.CapitalizeFirstLetter = False
        Me.stbPSCNo.EntryErrorMSG = ""
        Me.stbPSCNo.Location = New System.Drawing.Point(218, 12)
        Me.stbPSCNo.Name = "stbPSCNo"
        Me.stbPSCNo.ReadOnly = True
        Me.stbPSCNo.RegularExpression = ""
        Me.stbPSCNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPSCNo.TabIndex = 4
        '
        'lblPSCNo
        '
        Me.lblPSCNo.Location = New System.Drawing.Point(12, 12)
        Me.lblPSCNo.Name = "lblPSCNo"
        Me.lblPSCNo.Size = New System.Drawing.Size(200, 20)
        Me.lblPSCNo.TabIndex = 5
        Me.lblPSCNo.Text = "PSC No"
        '
        'lblGeneralNotes
        '
        Me.lblGeneralNotes.Location = New System.Drawing.Point(493, 5)
        Me.lblGeneralNotes.Name = "lblGeneralNotes"
        Me.lblGeneralNotes.Size = New System.Drawing.Size(131, 20)
        Me.lblGeneralNotes.TabIndex = 7
        Me.lblGeneralNotes.Text = "General Notes"
        '
        'lblRecordDateTime
        '
        Me.lblRecordDateTime.Location = New System.Drawing.Point(12, 36)
        Me.lblRecordDateTime.Name = "lblRecordDateTime"
        Me.lblRecordDateTime.Size = New System.Drawing.Size(200, 20)
        Me.lblRecordDateTime.TabIndex = 9
        Me.lblRecordDateTime.Text = "RecordDateTime"
        '
        'dgvPhysicalStockCountDetails
        '
        Me.dgvPhysicalStockCountDetails.AccessibleDescription = ""
        Me.dgvPhysicalStockCountDetails.AllowUserToAddRows = False
        Me.dgvPhysicalStockCountDetails.AllowUserToDeleteRows = False
        Me.dgvPhysicalStockCountDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPhysicalStockCountDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPhysicalStockCountDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPhysicalStockCountDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPhysicalStockCountDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPhysicalStockCountDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPhysicalStockCountDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhysicalStockCountDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPhysicalStockCountDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLocation, Me.colItemCategory, Me.colItemCode, Me.colItemName, Me.colSystemQuantity, Me.colPhysicalCountQuantity, Me.colVariance, Me.colNotes, Me.colLoginID, Me.colRecordDate, Me.colRecordTime})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPhysicalStockCountDetails.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvPhysicalStockCountDetails.EnableHeadersVisualStyles = False
        Me.dgvPhysicalStockCountDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvPhysicalStockCountDetails.Location = New System.Drawing.Point(12, 64)
        Me.dgvPhysicalStockCountDetails.Name = "dgvPhysicalStockCountDetails"
        Me.dgvPhysicalStockCountDetails.ReadOnly = True
        Me.dgvPhysicalStockCountDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhysicalStockCountDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPhysicalStockCountDetails.RowHeadersVisible = False
        Me.dgvPhysicalStockCountDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPhysicalStockCountDetails.Size = New System.Drawing.Size(980, 342)
        Me.dgvPhysicalStockCountDetails.TabIndex = 10
        Me.dgvPhysicalStockCountDetails.Text = "DataGridView1"
        '
        'colLocation
        '
        Me.colLocation.DataPropertyName = "Location"
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.Name = "colLocation"
        Me.colLocation.ReadOnly = True
        Me.colLocation.Width = 60
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "ItemCategory"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 150
        '
        'colSystemQuantity
        '
        Me.colSystemQuantity.DataPropertyName = "SystemQuantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colSystemQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colSystemQuantity.HeaderText = "System Quantity"
        Me.colSystemQuantity.Name = "colSystemQuantity"
        Me.colSystemQuantity.ReadOnly = True
        Me.colSystemQuantity.Width = 150
        '
        'colPhysicalCountQuantity
        '
        Me.colPhysicalCountQuantity.DataPropertyName = "PhysicalCountQuantity"
        Me.colPhysicalCountQuantity.HeaderText = "Physical Count"
        Me.colPhysicalCountQuantity.Name = "colPhysicalCountQuantity"
        Me.colPhysicalCountQuantity.ReadOnly = True
        Me.colPhysicalCountQuantity.Width = 150
        '
        'colVariance
        '
        Me.colVariance.DataPropertyName = "Variance"
        Me.colVariance.HeaderText = "Variance"
        Me.colVariance.Name = "colVariance"
        Me.colVariance.ReadOnly = True
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        '
        'colLoginID
        '
        Me.colLoginID.DataPropertyName = "LoginID"
        Me.colLoginID.HeaderText = "Login ID"
        Me.colLoginID.Name = "colLoginID"
        Me.colLoginID.ReadOnly = True
        Me.colLoginID.Width = 80
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        Me.colRecordDate.Width = 80
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 80
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(392, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 56
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(111, 419)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 81
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 419)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 80
        Me.btnPrint.Text = "&Print"
        '
        'lblRecordsImported
        '
        Me.lblRecordsImported.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsImported.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsImported.Location = New System.Drawing.Point(547, 43)
        Me.lblRecordsImported.Name = "lblRecordsImported"
        Me.lblRecordsImported.Size = New System.Drawing.Size(280, 18)
        Me.lblRecordsImported.TabIndex = 83
        '
        'fbnExport
        '
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(833, 38)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(72, 24)
        Me.fbnExport.TabIndex = 84
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        Me.fbnExport.Visible = False
        '
        'frmPhysicalStockCountReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1001, 452)
        Me.Controls.Add(Me.lblRecordsImported)
        Me.Controls.Add(Me.fbnExport)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbRecordDate)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.dgvPhysicalStockCountDetails)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPSCNo)
        Me.Controls.Add(Me.lblPSCNo)
        Me.Controls.Add(Me.stbGeneralNotes)
        Me.Controls.Add(Me.lblGeneralNotes)
        Me.Controls.Add(Me.lblRecordDateTime)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPhysicalStockCountReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Physical Stock Count Report"
        CType(Me.dgvPhysicalStockCountDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPSCNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPSCNo As System.Windows.Forms.Label
    Friend WithEvents stbGeneralNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGeneralNotes As System.Windows.Forms.Label
    Friend WithEvents lblRecordDateTime As System.Windows.Forms.Label
    Friend WithEvents dgvPhysicalStockCountDetails As DataGridView
    Friend WithEvents colLocation As DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As DataGridViewTextBoxColumn
    Friend WithEvents colItemName As DataGridViewTextBoxColumn
    Friend WithEvents colSystemQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colPhysicalCountQuantity As DataGridViewTextBoxColumn
    Friend WithEvents colVariance As DataGridViewTextBoxColumn
    Friend WithEvents colNotes As DataGridViewTextBoxColumn
    Friend WithEvents colLoginID As DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As DataGridViewTextBoxColumn
    Friend WithEvents btnLoad As Button
    Friend WithEvents stbRecordDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblRecordsImported As System.Windows.Forms.Label
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
End Class