<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportBillCustomers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportBillCustomers))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvImportedData = New System.Windows.Forms.DataGridView()
        Me.fbnSaveAll = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpFileLocation = New System.Windows.Forms.GroupBox()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbWorksheetName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblWorksheetName = New System.Windows.Forms.Label()
        Me.lblRecordsImported = New System.Windows.Forms.Label()
        Me.fbnImport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbFileName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnBrowse = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSaveReport = New System.Windows.Forms.Label()
        Me.fbnErrorLog = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colContactPerson = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCreditLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAllowOnlyListedMember = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colUseCustomFee = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSmartCardApplicable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCaptureMemberCardNo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCaptureClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFileLocation.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(868, 464)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 5
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvImportedData
        '
        Me.dgvImportedData.AllowUserToAddRows = False
        Me.dgvImportedData.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvImportedData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImportedData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvImportedData.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvImportedData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvImportedData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvImportedData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportedData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvImportedData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colID, Me.colAccountNo, Me.colBillCustomerName, Me.colBillCustomerType, Me.colInsuranceNo, Me.colContactPerson, Me.colPhone, Me.colAddress, Me.colCoPayType, Me.colCoPayPercent, Me.colCoPayValue, Me.colCreditLimit, Me.colAllowOnlyListedMember, Me.colUseCustomFee, Me.colSmartCardApplicable, Me.colCaptureMemberCardNo, Me.colCaptureClaimReferenceNo})
        Me.dgvImportedData.EnableHeadersVisualStyles = False
        Me.dgvImportedData.GridColor = System.Drawing.Color.Khaki
        Me.dgvImportedData.Location = New System.Drawing.Point(12, 87)
        Me.dgvImportedData.Name = "dgvImportedData"
        Me.dgvImportedData.ReadOnly = True
        Me.dgvImportedData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportedData.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvImportedData.Size = New System.Drawing.Size(928, 362)
        Me.dgvImportedData.TabIndex = 1
        Me.dgvImportedData.Text = "DataGridView1"
        '
        'fbnSaveAll
        '
        Me.fbnSaveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSaveAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSaveAll.Location = New System.Drawing.Point(12, 464)
        Me.fbnSaveAll.Name = "fbnSaveAll"
        Me.fbnSaveAll.Size = New System.Drawing.Size(72, 24)
        Me.fbnSaveAll.TabIndex = 2
        Me.fbnSaveAll.Text = "&Save All"
        Me.fbnSaveAll.UseVisualStyleBackColor = False
        '
        'grpFileLocation
        '
        Me.grpFileLocation.BackColor = System.Drawing.Color.Transparent
        Me.grpFileLocation.Controls.Add(Me.fbnExport)
        Me.grpFileLocation.Controls.Add(Me.stbWorksheetName)
        Me.grpFileLocation.Controls.Add(Me.lblWorksheetName)
        Me.grpFileLocation.Controls.Add(Me.lblRecordsImported)
        Me.grpFileLocation.Controls.Add(Me.fbnImport)
        Me.grpFileLocation.Controls.Add(Me.stbFileName)
        Me.grpFileLocation.Controls.Add(Me.fbnBrowse)
        Me.grpFileLocation.Location = New System.Drawing.Point(12, 9)
        Me.grpFileLocation.Name = "grpFileLocation"
        Me.grpFileLocation.Size = New System.Drawing.Size(720, 72)
        Me.grpFileLocation.TabIndex = 0
        Me.grpFileLocation.TabStop = False
        Me.grpFileLocation.Text = "File Location"
        '
        'fbnExport
        '
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(642, 42)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(72, 24)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        Me.fbnExport.Visible = False
        '
        'stbWorksheetName
        '
        Me.stbWorksheetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWorksheetName.CapitalizeFirstLetter = False
        Me.stbWorksheetName.EntryErrorMSG = ""
        Me.stbWorksheetName.Location = New System.Drawing.Point(118, 44)
        Me.stbWorksheetName.MaxLength = 40
        Me.stbWorksheetName.Name = "stbWorksheetName"
        Me.stbWorksheetName.RegularExpression = ""
        Me.stbWorksheetName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbWorksheetName.Size = New System.Drawing.Size(102, 20)
        Me.stbWorksheetName.TabIndex = 3
        Me.stbWorksheetName.Text = "To-Bill Customers"
        '
        'lblWorksheetName
        '
        Me.lblWorksheetName.Location = New System.Drawing.Point(6, 45)
        Me.lblWorksheetName.Name = "lblWorksheetName"
        Me.lblWorksheetName.Size = New System.Drawing.Size(106, 20)
        Me.lblWorksheetName.TabIndex = 2
        Me.lblWorksheetName.Text = "Worksheet Name"
        '
        'lblRecordsImported
        '
        Me.lblRecordsImported.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsImported.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsImported.Location = New System.Drawing.Point(308, 47)
        Me.lblRecordsImported.Name = "lblRecordsImported"
        Me.lblRecordsImported.Size = New System.Drawing.Size(328, 13)
        Me.lblRecordsImported.TabIndex = 5
        '
        'fbnImport
        '
        Me.fbnImport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnImport.Location = New System.Drawing.Point(230, 42)
        Me.fbnImport.Name = "fbnImport"
        Me.fbnImport.Size = New System.Drawing.Size(72, 24)
        Me.fbnImport.TabIndex = 4
        Me.fbnImport.Text = "&Import"
        Me.fbnImport.UseVisualStyleBackColor = False
        '
        'stbFileName
        '
        Me.stbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFileName.CapitalizeFirstLetter = False
        Me.stbFileName.EntryErrorMSG = ""
        Me.stbFileName.Location = New System.Drawing.Point(6, 18)
        Me.stbFileName.Name = "stbFileName"
        Me.stbFileName.RegularExpression = ""
        Me.stbFileName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFileName.Size = New System.Drawing.Size(630, 20)
        Me.stbFileName.TabIndex = 0
        '
        'fbnBrowse
        '
        Me.fbnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnBrowse.Location = New System.Drawing.Point(642, 14)
        Me.fbnBrowse.Name = "fbnBrowse"
        Me.fbnBrowse.Size = New System.Drawing.Size(72, 24)
        Me.fbnBrowse.TabIndex = 1
        Me.fbnBrowse.Text = "&Browse..."
        Me.fbnBrowse.UseVisualStyleBackColor = False
        '
        'lblSaveReport
        '
        Me.lblSaveReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSaveReport.ForeColor = System.Drawing.Color.Blue
        Me.lblSaveReport.Location = New System.Drawing.Point(186, 470)
        Me.lblSaveReport.Name = "lblSaveReport"
        Me.lblSaveReport.Size = New System.Drawing.Size(670, 13)
        Me.lblSaveReport.TabIndex = 4
        '
        'fbnErrorLog
        '
        Me.fbnErrorLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnErrorLog.Enabled = False
        Me.fbnErrorLog.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnErrorLog.Location = New System.Drawing.Point(90, 464)
        Me.fbnErrorLog.Name = "fbnErrorLog"
        Me.fbnErrorLog.Size = New System.Drawing.Size(90, 24)
        Me.fbnErrorLog.TabIndex = 3
        Me.fbnErrorLog.Text = "&View Error Log"
        Me.fbnErrorLog.UseVisualStyleBackColor = False
        '
        'colID
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colID.DefaultCellStyle = DataGridViewCellStyle3
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Width = 50
        '
        'colAccountNo
        '
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.ReadOnly = True
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        Me.colBillCustomerName.Width = 120
        '
        'colBillCustomerType
        '
        Me.colBillCustomerType.HeaderText = "Bill Customer Type"
        Me.colBillCustomerType.Name = "colBillCustomerType"
        Me.colBillCustomerType.ReadOnly = True
        '
        'colInsuranceNo
        '
        Me.colInsuranceNo.HeaderText = "Insurance No"
        Me.colInsuranceNo.Name = "colInsuranceNo"
        Me.colInsuranceNo.ReadOnly = True
        '
        'colContactPerson
        '
        Me.colContactPerson.HeaderText = "Contact Person"
        Me.colContactPerson.Name = "colContactPerson"
        Me.colContactPerson.ReadOnly = True
        '
        'colPhone
        '
        Me.colPhone.HeaderText = "Phone No"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        '
        'colAddress
        '
        Me.colAddress.HeaderText = "Address"
        Me.colAddress.Name = "colAddress"
        Me.colAddress.ReadOnly = True
        '
        'colCoPayType
        '
        Me.colCoPayType.HeaderText = "Co-Pay Type"
        Me.colCoPayType.Name = "colCoPayType"
        Me.colCoPayType.ReadOnly = True
        '
        'colCoPayPercent
        '
        Me.colCoPayPercent.HeaderText = "Co-Pay Percent"
        Me.colCoPayPercent.Name = "colCoPayPercent"
        Me.colCoPayPercent.ReadOnly = True
        '
        'colCoPayValue
        '
        Me.colCoPayValue.HeaderText = "Co-Pay Value"
        Me.colCoPayValue.Name = "colCoPayValue"
        Me.colCoPayValue.ReadOnly = True
        '
        'colCreditLimit
        '
        Me.colCreditLimit.HeaderText = "Credit Limit"
        Me.colCreditLimit.Name = "colCreditLimit"
        Me.colCreditLimit.ReadOnly = True
        '
        'colAllowOnlyListedMember
        '
        Me.colAllowOnlyListedMember.HeaderText = "Allow Only Listed Member"
        Me.colAllowOnlyListedMember.Name = "colAllowOnlyListedMember"
        Me.colAllowOnlyListedMember.ReadOnly = True
        Me.colAllowOnlyListedMember.Width = 145
        '
        'colUseCustomFee
        '
        Me.colUseCustomFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colUseCustomFee.HeaderText = "Use Custom Fee"
        Me.colUseCustomFee.Name = "colUseCustomFee"
        Me.colUseCustomFee.ReadOnly = True
        Me.colUseCustomFee.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colUseCustomFee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colSmartCardApplicable
        '
        Me.colSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSmartCardApplicable.HeaderText = "Smart Card Applicable"
        Me.colSmartCardApplicable.Name = "colSmartCardApplicable"
        Me.colSmartCardApplicable.ReadOnly = True
        Me.colSmartCardApplicable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSmartCardApplicable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSmartCardApplicable.Width = 120
        '
        'colCaptureMemberCardNo
        '
        Me.colCaptureMemberCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCaptureMemberCardNo.HeaderText = "Capture Member Card No"
        Me.colCaptureMemberCardNo.Name = "colCaptureMemberCardNo"
        Me.colCaptureMemberCardNo.ReadOnly = True
        Me.colCaptureMemberCardNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCaptureMemberCardNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCaptureMemberCardNo.Width = 140
        '
        'colCaptureClaimReferenceNo
        '
        Me.colCaptureClaimReferenceNo.HeaderText = "Capture Claim Reference No"
        Me.colCaptureClaimReferenceNo.Name = "colCaptureClaimReferenceNo"
        Me.colCaptureClaimReferenceNo.ReadOnly = True
        Me.colCaptureClaimReferenceNo.Width = 150
        '
        'frmImportBillCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 507)
        Me.Controls.Add(Me.fbnErrorLog)
        Me.Controls.Add(Me.lblSaveReport)
        Me.Controls.Add(Me.grpFileLocation)
        Me.Controls.Add(Me.fbnSaveAll)
        Me.Controls.Add(Me.dgvImportedData)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportBillCustomers"
        Me.Text = "Import To-Bill Customers"
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFileLocation.ResumeLayout(False)
        Me.grpFileLocation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvImportedData As System.Windows.Forms.DataGridView
    Friend WithEvents fbnSaveAll As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpFileLocation As System.Windows.Forms.GroupBox
    Friend WithEvents fbnBrowse As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbFileName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnImport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsImported As System.Windows.Forms.Label
    Friend WithEvents lblSaveReport As System.Windows.Forms.Label
    Friend WithEvents stbWorksheetName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWorksheetName As System.Windows.Forms.Label
    Friend WithEvents fbnErrorLog As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContactPerson As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCreditLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAllowOnlyListedMember As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colUseCustomFee As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSmartCardApplicable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCaptureMemberCardNo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCaptureClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
