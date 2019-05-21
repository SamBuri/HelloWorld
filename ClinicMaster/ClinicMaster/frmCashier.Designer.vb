<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCashier : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String, ByVal visitTypeID As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
        Me.defaultVisitType = visitTypeID
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCashier))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle90 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle91 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle73 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle74 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle75 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle76 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle77 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle78 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle79 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle80 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle81 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle85 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle86 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle87 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle88 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle89 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle110 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle111 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle93 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle94 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle95 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle96 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle97 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle98 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle99 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle100 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle101 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle102 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle103 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle104 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle105 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle106 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle107 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle108 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle109 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbcCashier = New System.Windows.Forms.TabControl()
        Me.tpgCashPayment = New System.Windows.Forms.TabPage()
        Me.dtpPayDate = New System.Windows.Forms.DateTimePicker()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.stbPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnExchangeRate = New System.Windows.Forms.Button()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblChange = New System.Windows.Forms.Label()
        Me.nbxAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmountTendered = New System.Windows.Forms.Label()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.cboCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblCurrenciesID = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.chkUseAccountBalance = New System.Windows.Forms.CheckBox()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.chkSendBalanceToAccount = New System.Windows.Forms.CheckBox()
        Me.btnPayingVisits = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.btnWaitingCashPayments = New System.Windows.Forms.Button()
        Me.lblAlertMessage = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.btnLoadPendingCashPayment = New System.Windows.Forms.Button()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmountPaid = New System.Windows.Forms.Label()
        Me.grpPaymentDetails = New System.Windows.Forms.GroupBox()
        Me.dgvPaymentDetails = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsPayments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPaymentsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPaymentsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPaymentsAddExtraCharge = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsPaymentsIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPaymentsIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDocumentNo = New System.Windows.Forms.Label()
        Me.stbDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.stbReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPayModes = New System.Windows.Forms.Label()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblPayDate = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.tpgBillFormPayment = New System.Windows.Forms.TabPage()
        Me.stbBFPInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBFPPhoneNo = New System.Windows.Forms.Label()
        Me.stbBFPPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tbcBillFormPayment = New System.Windows.Forms.TabControl()
        Me.tpgBillingForm = New System.Windows.Forms.TabPage()
        Me.dgvPaymentExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.colBFPInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colBFPExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPExtraBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgPendingBill = New System.Windows.Forms.TabPage()
        Me.dgvPendingBillItems = New System.Windows.Forms.DataGridView()
        Me.colPendingBillItemsInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPendingBillItemsRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsRoundDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPendingBillItemsItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbBFPCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPCustomerName = New System.Windows.Forms.Label()
        Me.btnBFPExchangeRate = New System.Windows.Forms.Button()
        Me.btnPayingExtraBills = New System.Windows.Forms.Button()
        Me.chkBFPSendBalanceToAccount = New System.Windows.Forms.CheckBox()
        Me.stbBFPChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPChange = New System.Windows.Forms.Label()
        Me.nbxBFPAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxBFPExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBFPAmountTendered = New System.Windows.Forms.Label()
        Me.lblBFPExchangeRate = New System.Windows.Forms.Label()
        Me.cboBFPCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblBFPCurrenciesID = New System.Windows.Forms.Label()
        Me.stbBFPBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPBillMode = New System.Windows.Forms.Label()
        Me.nbxBFPCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBFPCoPayValue = New System.Windows.Forms.Label()
        Me.nbxBFPCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBFPCoPayPercent = New System.Windows.Forms.Label()
        Me.stbBFPCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPCoPayType = New System.Windows.Forms.Label()
        Me.chkBFPUseAccountBalance = New System.Windows.Forms.CheckBox()
        Me.nbxBFPCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBFPCashAccountBalance = New System.Windows.Forms.Label()
        Me.stbBFPVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxBFPOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBFPOutstandingBalance = New System.Windows.Forms.Label()
        Me.btnLoadPendingBFPayment = New System.Windows.Forms.Button()
        Me.stbBFPPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPPatientsNo = New System.Windows.Forms.Label()
        Me.stbBFPVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPVisitDate = New System.Windows.Forms.Label()
        Me.btnBFPFindVisitNo = New System.Windows.Forms.Button()
        Me.stbBFPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPAmountWords = New System.Windows.Forms.Label()
        Me.stbBFPTotalAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPTotalAmountPaid = New System.Windows.Forms.Label()
        Me.lblBFPDocumentNo = New System.Windows.Forms.Label()
        Me.stbBFPDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBFPPayModesID = New System.Windows.Forms.ComboBox()
        Me.dtpBFPPayDate = New System.Windows.Forms.DateTimePicker()
        Me.lblBFPReceiptNo = New System.Windows.Forms.Label()
        Me.stbBFPReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPPayModes = New System.Windows.Forms.Label()
        Me.stbBFPNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBFPFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPFullName = New System.Windows.Forms.Label()
        Me.lblBFPNotes = New System.Windows.Forms.Label()
        Me.lblBFPPayDate = New System.Windows.Forms.Label()
        Me.lblBFPVisitNo = New System.Windows.Forms.Label()
        Me.tpgBillsPayment = New System.Windows.Forms.TabPage()
        Me.nbxBPGrandDiscount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblGrandDiscount = New System.Windows.Forms.Label()
        Me.nbxBPWithholdingTax = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnBPFindVisitNoByInvoiceNo = New System.Windows.Forms.Button()
        Me.btnBPExchangeRate = New System.Windows.Forms.Button()
        Me.stbBPVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnBPFindVisitNo = New System.Windows.Forms.Button()
        Me.stbBPCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBPCompanyNo = New System.Windows.Forms.ComboBox()
        Me.lblBPCompanyName = New System.Windows.Forms.Label()
        Me.lblBPCompanyNo = New System.Windows.Forms.Label()
        Me.chkBPUseAccountBalance = New System.Windows.Forms.CheckBox()
        Me.chkBPSendBalanceToAccount = New System.Windows.Forms.CheckBox()
        Me.stbBPChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBPChange = New System.Windows.Forms.Label()
        Me.nbxBPAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxBPExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblBPAmountTendered = New System.Windows.Forms.Label()
        Me.lblBPExchangeRate = New System.Windows.Forms.Label()
        Me.cboBPCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblBPCurrenciesID = New System.Windows.Forms.Label()
        Me.cboBPBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBPBillModesID = New System.Windows.Forms.Label()
        Me.grpBPSetParameters = New System.Windows.Forms.GroupBox()
        Me.chkExcludeNotInvoicedItem = New System.Windows.Forms.CheckBox()
        Me.pnlBPPeriod = New System.Windows.Forms.Panel()
        Me.dtpBPEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpBPStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnLoadPendingBillsPayment = New System.Windows.Forms.Button()
        Me.lblBPRecordsNo = New System.Windows.Forms.Label()
        Me.rdoBPGetPeriod = New System.Windows.Forms.RadioButton()
        Me.rdoBPGetAll = New System.Windows.Forms.RadioButton()
        Me.lblBPReceiptNo = New System.Windows.Forms.Label()
        Me.stbBPReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBPAmountWords = New System.Windows.Forms.Label()
        Me.stbBPAccountBalance = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.cboBPPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblBPPayModes = New System.Windows.Forms.Label()
        Me.lblBPVisitNo = New System.Windows.Forms.Label()
        Me.stbBPTotalBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBPTotalAmountPaid = New System.Windows.Forms.Label()
        Me.lblBPChequeNo = New System.Windows.Forms.Label()
        Me.stbBPDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBPNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBPNotes = New System.Windows.Forms.Label()
        Me.grpBillsPayment = New System.Windows.Forms.GroupBox()
        Me.dgvBillsPayment = New System.Windows.Forms.DataGridView()
        Me.colBPInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colBPPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPInvoiceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPCoPayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBPItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbBPBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBPBillAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblBPBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBPBillAccountNo = New System.Windows.Forms.Label()
        Me.tpgCreditBillFormPayment = New System.Windows.Forms.TabPage()
        Me.nbxCBFPGrandDiscount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCBFPGrandDiscount = New System.Windows.Forms.Label()
        Me.nbxCBFPWithholdingTax = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCBFPWithholdingTax = New System.Windows.Forms.Label()
        Me.btnCBFFindVisitNoByInvoiceNo = New System.Windows.Forms.Button()
        Me.btnCBFPExchangeRate = New System.Windows.Forms.Button()
        Me.grpCBFPExtraBillItems = New System.Windows.Forms.GroupBox()
        Me.dgvCBFPExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.colCBFPInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCBFPPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPExtraBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPInvoiceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPCoPayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCBFPItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCBFPFindVisitNo = New System.Windows.Forms.Button()
        Me.stbCBFPVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCBFPCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCBFPCompanyNo = New System.Windows.Forms.ComboBox()
        Me.lblCBFPCompanyName = New System.Windows.Forms.Label()
        Me.lblCBFPCompanyNo = New System.Windows.Forms.Label()
        Me.chkCBFPUseAccountBalance = New System.Windows.Forms.CheckBox()
        Me.chkCBFPSendBalanceToAccount = New System.Windows.Forms.CheckBox()
        Me.stbCBFPChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPChange = New System.Windows.Forms.Label()
        Me.nbxCBFPAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCBFPExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCBFPAmountTendered = New System.Windows.Forms.Label()
        Me.lblCBFPExchangeRate = New System.Windows.Forms.Label()
        Me.cboCBFPCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblCBFPCurrenciesID = New System.Windows.Forms.Label()
        Me.cboCBFPBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblCBFPBillModesID = New System.Windows.Forms.Label()
        Me.grpCBFPSetParameters = New System.Windows.Forms.GroupBox()
        Me.chkCBFPExcludeNotInvoicedItem = New System.Windows.Forms.CheckBox()
        Me.pnlCBFPPeriod = New System.Windows.Forms.Panel()
        Me.dtpCBFPEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCBFPStartDate = New System.Windows.Forms.Label()
        Me.dtpCBFPStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCBFPEndDate = New System.Windows.Forms.Label()
        Me.fbnCBFPExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnCBFPLoadPendingBillsPayment = New System.Windows.Forms.Button()
        Me.lblCBFPRecordsNo = New System.Windows.Forms.Label()
        Me.rdoCBFPGetPeriod = New System.Windows.Forms.RadioButton()
        Me.rdoCBFPGetAll = New System.Windows.Forms.RadioButton()
        Me.lblCBFPReceiptNo = New System.Windows.Forms.Label()
        Me.stbCBFPReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCBFPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPAmountWords = New System.Windows.Forms.Label()
        Me.stbCBFPAccountBalance = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPBalance = New System.Windows.Forms.Label()
        Me.cboCBFPPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblCBFPPayModes = New System.Windows.Forms.Label()
        Me.lblCBFPVisitNo = New System.Windows.Forms.Label()
        Me.stbCBFPTotalBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPTotalAmountPaid = New System.Windows.Forms.Label()
        Me.lblCBFPChequeNo = New System.Windows.Forms.Label()
        Me.stbCBFPDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCBFPNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPNotes = New System.Windows.Forms.Label()
        Me.stbCBFPBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCBFPBillAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblCBFPBillCustomerName = New System.Windows.Forms.Label()
        Me.lblCBFPBillAccountNo = New System.Windows.Forms.Label()
        Me.tpgManageAccounts = New System.Windows.Forms.TabPage()
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbAccountPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountGroupID = New System.Windows.Forms.ComboBox()
        Me.lblAccountGroupID = New System.Windows.Forms.Label()
        Me.btnAccountExchangeRate = New System.Windows.Forms.Button()
        Me.stbAccountChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountChange = New System.Windows.Forms.Label()
        Me.nbxAccountAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountAmountTendered = New System.Windows.Forms.Label()
        Me.lblAccountExchangeRate = New System.Windows.Forms.Label()
        Me.cboAccountCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblAccountCurrenciesID = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblAccountTranNo = New System.Windows.Forms.Label()
        Me.stbAccountTranNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountActionID = New System.Windows.Forms.ComboBox()
        Me.lblAccountActionID = New System.Windows.Forms.Label()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillModesID = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.cboAccountPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblAccountPayModes = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.lblAccountDocumentNo = New System.Windows.Forms.Label()
        Me.stbAccountDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountNotes = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.tpgOtherIncome = New System.Windows.Forms.TabPage()
        Me.cboOICurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblOICurrenciesID = New System.Windows.Forms.Label()
        Me.btnOIExchangeRate = New System.Windows.Forms.Button()
        Me.stbOIChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOIChange = New System.Windows.Forms.Label()
        Me.nbxOIAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxOIExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOIAmountTendered = New System.Windows.Forms.Label()
        Me.lblOIExchangeRate = New System.Windows.Forms.Label()
        Me.nbxOIAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOIDocumentNo = New System.Windows.Forms.Label()
        Me.stbOIDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboOIPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblOIPayModes = New System.Windows.Forms.Label()
        Me.lblIncomeNo = New System.Windows.Forms.Label()
        Me.stbIncomeNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOINotes = New System.Windows.Forms.Label()
        Me.lblOIAmount = New System.Windows.Forms.Label()
        Me.stbOINotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboIncomeSourcesID = New System.Windows.Forms.ComboBox()
        Me.lblIncomeSourcesID = New System.Windows.Forms.Label()
        Me.dtpIncomeDate = New System.Windows.Forms.DateTimePicker()
        Me.lblIncomeDate = New System.Windows.Forms.Label()
        Me.tpgRefunds = New System.Windows.Forms.TabPage()
        Me.btnFindReceiptNo = New System.Windows.Forms.Button()
        Me.dgvPaymentRefunds = New System.Windows.Forms.DataGridView()
        Me.colRefItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefSoldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coReflItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundReason = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colRefQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrevRefundedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefSalesUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcknowledgeable = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colPrevRefundedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblRefundInvoiceNo = New System.Windows.Forms.Label()
        Me.stbRefundInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.stbRefundRequestNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundRequestNo = New System.Windows.Forms.Label()
        Me.lblPendingRefundRequests = New System.Windows.Forms.Label()
        Me.btnLoadRefundRequests = New System.Windows.Forms.Button()
        Me.lblToRefundAmount = New System.Windows.Forms.Label()
        Me.nbxToRefundAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxRefundOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbAmountRefunded = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountRefunded = New System.Windows.Forms.Label()
        Me.nbxRefundAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundAccountBalance = New System.Windows.Forms.Label()
        Me.stbRefundAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundAmountPaid = New System.Windows.Forms.Label()
        Me.stbRefundPayDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundPayDate = New System.Windows.Forms.Label()
        Me.stbPayeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPayeeName = New System.Windows.Forms.Label()
        Me.stbRefundAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundAmountWords = New System.Windows.Forms.Label()
        Me.lblRefundReceiptNo = New System.Windows.Forms.Label()
        Me.stbRefundReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundNo = New System.Windows.Forms.Label()
        Me.stbRefundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundNotes = New System.Windows.Forms.Label()
        Me.lblRefundAmount = New System.Windows.Forms.Label()
        Me.stbRefundNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxTotalRefundAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpRefundDate = New System.Windows.Forms.DateTimePicker()
        Me.lblRefundDate = New System.Windows.Forms.Label()
        Me.tpgExpenditure = New System.Windows.Forms.TabPage()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.lblAmountWithdrawn = New System.Windows.Forms.Label()
        Me.nbxAmountWithdrawn = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.btnExRate = New System.Windows.Forms.Button()
        Me.nbxExchange = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAccountNames = New System.Windows.Forms.ComboBox()
        Me.nbxMaxAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMaxAmount = New System.Windows.Forms.Label()
        Me.lblAccount = New System.Windows.Forms.Label()
        Me.cboBankID = New System.Windows.Forms.ComboBox()
        Me.lblBankID = New System.Windows.Forms.Label()
        Me.cboExpenditureSourceType = New System.Windows.Forms.ComboBox()
        Me.lblExpenditureSourceType = New System.Windows.Forms.Label()
        Me.lblEXDocumentNo = New System.Windows.Forms.Label()
        Me.stbEXDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureNo = New System.Windows.Forms.Label()
        Me.stbExpenditureNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGivenTo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGivenTo = New System.Windows.Forms.Label()
        Me.stbEXDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEXDetails = New System.Windows.Forms.Label()
        Me.lblEXAmount = New System.Windows.Forms.Label()
        Me.nbxEXAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboExpenditureCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblExpenditureCategoryID = New System.Windows.Forms.Label()
        Me.dtpSpentDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSpentDate = New System.Windows.Forms.Label()
        Me.btnAddExtraBill = New System.Windows.Forms.Button()
        Me.chkPrintReceiptOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.btnManageAccounts = New System.Windows.Forms.Button()
        Me.btnSelfRequests = New System.Windows.Forms.Button()
        Me.tbcCashier.SuspendLayout()
        Me.tpgCashPayment.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.grpPaymentDetails.SuspendLayout()
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPayments.SuspendLayout()
        Me.tpgBillFormPayment.SuspendLayout()
        Me.tbcBillFormPayment.SuspendLayout()
        Me.tpgBillingForm.SuspendLayout()
        CType(Me.dgvPaymentExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPendingBill.SuspendLayout()
        CType(Me.dgvPendingBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgBillsPayment.SuspendLayout()
        Me.grpBPSetParameters.SuspendLayout()
        Me.pnlBPPeriod.SuspendLayout()
        Me.grpBillsPayment.SuspendLayout()
        CType(Me.dgvBillsPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgCreditBillFormPayment.SuspendLayout()
        Me.grpCBFPExtraBillItems.SuspendLayout()
        CType(Me.dgvCBFPExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCBFPSetParameters.SuspendLayout()
        Me.pnlCBFPPeriod.SuspendLayout()
        Me.tpgManageAccounts.SuspendLayout()
        Me.tpgOtherIncome.SuspendLayout()
        Me.tpgRefunds.SuspendLayout()
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgExpenditure.SuspendLayout()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcCashier
        '
        Me.tbcCashier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCashier.Controls.Add(Me.tpgCashPayment)
        Me.tbcCashier.Controls.Add(Me.tpgBillFormPayment)
        Me.tbcCashier.Controls.Add(Me.tpgBillsPayment)
        Me.tbcCashier.Controls.Add(Me.tpgCreditBillFormPayment)
        Me.tbcCashier.Controls.Add(Me.tpgManageAccounts)
        Me.tbcCashier.Controls.Add(Me.tpgOtherIncome)
        Me.tbcCashier.Controls.Add(Me.tpgRefunds)
        Me.tbcCashier.Controls.Add(Me.tpgExpenditure)
        Me.tbcCashier.HotTrack = True
        Me.tbcCashier.Location = New System.Drawing.Point(7, 12)
        Me.tbcCashier.Name = "tbcCashier"
        Me.tbcCashier.SelectedIndex = 0
        Me.tbcCashier.Size = New System.Drawing.Size(902, 508)
        Me.tbcCashier.TabIndex = 1
        '
        'tpgCashPayment
        '
        Me.tpgCashPayment.Controls.Add(Me.dtpPayDate)
        Me.tpgCashPayment.Controls.Add(Me.stbInvoiceNo)
        Me.tpgCashPayment.Controls.Add(Me.lblInvoiceNo)
        Me.tpgCashPayment.Controls.Add(Me.lblPhone)
        Me.tpgCashPayment.Controls.Add(Me.stbPhoneNo)
        Me.tpgCashPayment.Controls.Add(Me.stbBillCustomerName)
        Me.tpgCashPayment.Controls.Add(Me.btnExchangeRate)
        Me.tpgCashPayment.Controls.Add(Me.lblBillCustomerName)
        Me.tpgCashPayment.Controls.Add(Me.stbChange)
        Me.tpgCashPayment.Controls.Add(Me.lblChange)
        Me.tpgCashPayment.Controls.Add(Me.nbxAmountTendered)
        Me.tpgCashPayment.Controls.Add(Me.nbxExchangeRate)
        Me.tpgCashPayment.Controls.Add(Me.lblAmountTendered)
        Me.tpgCashPayment.Controls.Add(Me.lblExchangeRate)
        Me.tpgCashPayment.Controls.Add(Me.cboCurrenciesID)
        Me.tpgCashPayment.Controls.Add(Me.lblCurrenciesID)
        Me.tpgCashPayment.Controls.Add(Me.stbBillMode)
        Me.tpgCashPayment.Controls.Add(Me.lblBillMode)
        Me.tpgCashPayment.Controls.Add(Me.nbxCoPayValue)
        Me.tpgCashPayment.Controls.Add(Me.lblCoPayValue)
        Me.tpgCashPayment.Controls.Add(Me.nbxCoPayPercent)
        Me.tpgCashPayment.Controls.Add(Me.lblCoPayPercent)
        Me.tpgCashPayment.Controls.Add(Me.stbCoPayType)
        Me.tpgCashPayment.Controls.Add(Me.lblCoPayType)
        Me.tpgCashPayment.Controls.Add(Me.chkUseAccountBalance)
        Me.tpgCashPayment.Controls.Add(Me.nbxCashAccountBalance)
        Me.tpgCashPayment.Controls.Add(Me.lblCashAccountBalance)
        Me.tpgCashPayment.Controls.Add(Me.pnlAlerts)
        Me.tpgCashPayment.Controls.Add(Me.stbVisitNo)
        Me.tpgCashPayment.Controls.Add(Me.nbxOutstandingBalance)
        Me.tpgCashPayment.Controls.Add(Me.lblOutstandingBalance)
        Me.tpgCashPayment.Controls.Add(Me.btnLoadPendingCashPayment)
        Me.tpgCashPayment.Controls.Add(Me.stbPatientNo)
        Me.tpgCashPayment.Controls.Add(Me.lblPatientsNo)
        Me.tpgCashPayment.Controls.Add(Me.stbVisitDate)
        Me.tpgCashPayment.Controls.Add(Me.lblVisitDate)
        Me.tpgCashPayment.Controls.Add(Me.btnFindVisitNo)
        Me.tpgCashPayment.Controls.Add(Me.stbAmountWords)
        Me.tpgCashPayment.Controls.Add(Me.lblAmountWords)
        Me.tpgCashPayment.Controls.Add(Me.stbTotalAmountPaid)
        Me.tpgCashPayment.Controls.Add(Me.lblTotalAmountPaid)
        Me.tpgCashPayment.Controls.Add(Me.grpPaymentDetails)
        Me.tpgCashPayment.Controls.Add(Me.lblDocumentNo)
        Me.tpgCashPayment.Controls.Add(Me.stbDocumentNo)
        Me.tpgCashPayment.Controls.Add(Me.cboPayModesID)
        Me.tpgCashPayment.Controls.Add(Me.lblReceiptNo)
        Me.tpgCashPayment.Controls.Add(Me.stbReceiptNo)
        Me.tpgCashPayment.Controls.Add(Me.lblPayModes)
        Me.tpgCashPayment.Controls.Add(Me.stbNotes)
        Me.tpgCashPayment.Controls.Add(Me.stbFullName)
        Me.tpgCashPayment.Controls.Add(Me.lblFullName)
        Me.tpgCashPayment.Controls.Add(Me.lblNotes)
        Me.tpgCashPayment.Controls.Add(Me.lblPayDate)
        Me.tpgCashPayment.Controls.Add(Me.lblVisitNo)
        Me.tpgCashPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgCashPayment.Name = "tpgCashPayment"
        Me.tpgCashPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgCashPayment.Size = New System.Drawing.Size(894, 482)
        Me.tpgCashPayment.TabIndex = 0
        Me.tpgCashPayment.Tag = "CashPayments"
        Me.tpgCashPayment.Text = "Cash Payment"
        Me.tpgCashPayment.UseVisualStyleBackColor = True
        '
        'dtpPayDate
        '
        Me.dtpPayDate.Enabled = False
        Me.dtpPayDate.Location = New System.Drawing.Point(141, 113)
        Me.dtpPayDate.Name = "dtpPayDate"
        Me.dtpPayDate.ShowCheckBox = True
        Me.dtpPayDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpPayDate.TabIndex = 13
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(141, 71)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(169, 20)
        Me.stbInvoiceNo.TabIndex = 9
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(13, 71)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(118, 18)
        Me.lblInvoiceNo.TabIndex = 8
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(322, 25)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(104, 20)
        Me.lblPhone.TabIndex = 27
        Me.lblPhone.Text = "Phone"
        '
        'stbPhoneNo
        '
        Me.stbPhoneNo.BackColor = System.Drawing.SystemColors.Control
        Me.stbPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneNo.CapitalizeFirstLetter = True
        Me.stbPhoneNo.EntryErrorMSG = ""
        Me.stbPhoneNo.Location = New System.Drawing.Point(432, 25)
        Me.stbPhoneNo.MaxLength = 100
        Me.stbPhoneNo.Multiline = True
        Me.stbPhoneNo.Name = "stbPhoneNo"
        Me.stbPhoneNo.ReadOnly = True
        Me.stbPhoneNo.RegularExpression = ""
        Me.stbPhoneNo.Size = New System.Drawing.Size(155, 20)
        Me.stbPhoneNo.TabIndex = 28
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(432, 162)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(406, 24)
        Me.stbBillCustomerName.TabIndex = 40
        '
        'btnExchangeRate
        '
        Me.btnExchangeRate.Enabled = False
        Me.btnExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExchangeRate.Image = CType(resources.GetObject("btnExchangeRate.Image"), System.Drawing.Image)
        Me.btnExchangeRate.Location = New System.Drawing.Point(106, 204)
        Me.btnExchangeRate.Name = "btnExchangeRate"
        Me.btnExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnExchangeRate.TabIndex = 21
        Me.btnExchangeRate.Tag = "ExchangeRates"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(322, 165)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(104, 20)
        Me.lblBillCustomerName.TabIndex = 39
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbChange
        '
        Me.stbChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbChange.CapitalizeFirstLetter = False
        Me.stbChange.Enabled = False
        Me.stbChange.EntryErrorMSG = ""
        Me.stbChange.Location = New System.Drawing.Point(141, 227)
        Me.stbChange.MaxLength = 20
        Me.stbChange.Name = "stbChange"
        Me.stbChange.RegularExpression = ""
        Me.stbChange.Size = New System.Drawing.Size(169, 20)
        Me.stbChange.TabIndex = 24
        Me.stbChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblChange
        '
        Me.lblChange.Location = New System.Drawing.Point(13, 229)
        Me.lblChange.Name = "lblChange"
        Me.lblChange.Size = New System.Drawing.Size(118, 20)
        Me.lblChange.TabIndex = 23
        Me.lblChange.Text = "Change"
        '
        'nbxAmountTendered
        '
        Me.nbxAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmountTendered.DecimalPlaces = -1
        Me.nbxAmountTendered.DenyNegativeEntryValue = True
        Me.nbxAmountTendered.Location = New System.Drawing.Point(141, 185)
        Me.nbxAmountTendered.MaxValue = 0.0R
        Me.nbxAmountTendered.MinValue = 0.0R
        Me.nbxAmountTendered.MustEnterNumeric = True
        Me.nbxAmountTendered.Name = "nbxAmountTendered"
        Me.nbxAmountTendered.Size = New System.Drawing.Size(169, 20)
        Me.nbxAmountTendered.TabIndex = 19
        Me.nbxAmountTendered.Value = ""
        '
        'nbxExchangeRate
        '
        Me.nbxExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxExchangeRate.DecimalPlaces = -1
        Me.nbxExchangeRate.DenyZeroEntryValue = True
        Me.nbxExchangeRate.Location = New System.Drawing.Point(141, 206)
        Me.nbxExchangeRate.MaxValue = 0.0R
        Me.nbxExchangeRate.MinValue = 0.0R
        Me.nbxExchangeRate.MustEnterNumeric = True
        Me.nbxExchangeRate.Name = "nbxExchangeRate"
        Me.nbxExchangeRate.Size = New System.Drawing.Size(169, 20)
        Me.nbxExchangeRate.TabIndex = 22
        Me.nbxExchangeRate.Value = ""
        '
        'lblAmountTendered
        '
        Me.lblAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAmountTendered.Location = New System.Drawing.Point(13, 185)
        Me.lblAmountTendered.Name = "lblAmountTendered"
        Me.lblAmountTendered.Size = New System.Drawing.Size(118, 20)
        Me.lblAmountTendered.TabIndex = 18
        Me.lblAmountTendered.Text = "Amount Tendered"
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Location = New System.Drawing.Point(13, 207)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(87, 20)
        Me.lblExchangeRate.TabIndex = 20
        Me.lblExchangeRate.Text = "Exchange Rate"
        '
        'cboCurrenciesID
        '
        Me.cboCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrenciesID.FormattingEnabled = True
        Me.cboCurrenciesID.ItemHeight = 13
        Me.cboCurrenciesID.Location = New System.Drawing.Point(141, 161)
        Me.cboCurrenciesID.Name = "cboCurrenciesID"
        Me.cboCurrenciesID.Size = New System.Drawing.Size(169, 21)
        Me.cboCurrenciesID.TabIndex = 17
        '
        'lblCurrenciesID
        '
        Me.lblCurrenciesID.Location = New System.Drawing.Point(13, 161)
        Me.lblCurrenciesID.Name = "lblCurrenciesID"
        Me.lblCurrenciesID.Size = New System.Drawing.Size(118, 20)
        Me.lblCurrenciesID.TabIndex = 16
        Me.lblCurrenciesID.Text = "Pay in Currency"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(726, 86)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(112, 20)
        Me.stbBillMode.TabIndex = 47
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(593, 88)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(127, 20)
        Me.lblBillMode.TabIndex = 46
        Me.lblBillMode.Text = "Bill Mode"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(764, 138)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(74, 20)
        Me.nbxCoPayValue.TabIndex = 52
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(679, 139)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(79, 19)
        Me.lblCoPayValue.TabIndex = 51
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(618, 138)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(55, 20)
        Me.nbxCoPayPercent.TabIndex = 50
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(524, 139)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(88, 19)
        Me.lblCoPayPercent.TabIndex = 38
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(432, 139)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(86, 20)
        Me.stbCoPayType.TabIndex = 37
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(322, 139)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(76, 20)
        Me.lblCoPayType.TabIndex = 36
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'chkUseAccountBalance
        '
        Me.chkUseAccountBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseAccountBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseAccountBalance.Location = New System.Drawing.Point(321, 114)
        Me.chkUseAccountBalance.Name = "chkUseAccountBalance"
        Me.chkUseAccountBalance.Size = New System.Drawing.Size(197, 20)
        Me.chkUseAccountBalance.TabIndex = 35
        Me.chkUseAccountBalance.Text = "Use Account Balance"
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(726, 107)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(112, 20)
        Me.nbxCashAccountBalance.TabIndex = 49
        Me.nbxCashAccountBalance.Value = ""
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(593, 108)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(127, 20)
        Me.lblCashAccountBalance.TabIndex = 48
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.stbTotalVisits)
        Me.pnlAlerts.Controls.Add(Me.lblTotalVisits)
        Me.pnlAlerts.Controls.Add(Me.chkSendBalanceToAccount)
        Me.pnlAlerts.Controls.Add(Me.btnPayingVisits)
        Me.pnlAlerts.Controls.Add(Me.btnFindByFingerprint)
        Me.pnlAlerts.Controls.Add(Me.btnWaitingCashPayments)
        Me.pnlAlerts.Controls.Add(Me.lblAlertMessage)
        Me.pnlAlerts.Location = New System.Drawing.Point(316, 189)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(537, 56)
        Me.pnlAlerts.TabIndex = 41
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(468, 3)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(54, 20)
        Me.stbTotalVisits.TabIndex = 6
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(400, 4)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(62, 20)
        Me.lblTotalVisits.TabIndex = 4
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'chkSendBalanceToAccount
        '
        Me.chkSendBalanceToAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSendBalanceToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSendBalanceToAccount.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkSendBalanceToAccount.Location = New System.Drawing.Point(5, 30)
        Me.chkSendBalanceToAccount.Name = "chkSendBalanceToAccount"
        Me.chkSendBalanceToAccount.Size = New System.Drawing.Size(197, 20)
        Me.chkSendBalanceToAccount.TabIndex = 1
        Me.chkSendBalanceToAccount.Text = "Send Balance To Account"
        '
        'btnPayingVisits
        '
        Me.btnPayingVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPayingVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayingVisits.Location = New System.Drawing.Point(302, 27)
        Me.btnPayingVisits.Name = "btnPayingVisits"
        Me.btnPayingVisits.Size = New System.Drawing.Size(93, 23)
        Me.btnPayingVisits.TabIndex = 3
        Me.btnPayingVisits.Tag = ""
        Me.btnPayingVisits.Text = "&Paying Visits"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(403, 27)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(119, 23)
        Me.btnFindByFingerprint.TabIndex = 5
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'btnWaitingCashPayments
        '
        Me.btnWaitingCashPayments.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnWaitingCashPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWaitingCashPayments.Location = New System.Drawing.Point(302, 2)
        Me.btnWaitingCashPayments.Name = "btnWaitingCashPayments"
        Me.btnWaitingCashPayments.Size = New System.Drawing.Size(93, 23)
        Me.btnWaitingCashPayments.TabIndex = 2
        Me.btnWaitingCashPayments.Tag = ""
        Me.btnWaitingCashPayments.Text = "&View List"
        '
        'lblAlertMessage
        '
        Me.lblAlertMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlertMessage.ForeColor = System.Drawing.Color.Red
        Me.lblAlertMessage.Location = New System.Drawing.Point(9, 4)
        Me.lblAlertMessage.Name = "lblAlertMessage"
        Me.lblAlertMessage.Size = New System.Drawing.Size(287, 20)
        Me.lblAlertMessage.TabIndex = 0
        Me.lblAlertMessage.Text = "Waiting To Pay For Cash Items: 0"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(141, 8)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(141, 50)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(169, 20)
        Me.nbxOutstandingBalance.TabIndex = 7
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(13, 52)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(118, 20)
        Me.lblOutstandingBalance.TabIndex = 6
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'btnLoadPendingCashPayment
        '
        Me.btnLoadPendingCashPayment.AccessibleDescription = ""
        Me.btnLoadPendingCashPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingCashPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingCashPayment.Location = New System.Drawing.Point(262, 3)
        Me.btnLoadPendingCashPayment.Name = "btnLoadPendingCashPayment"
        Me.btnLoadPendingCashPayment.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingCashPayment.TabIndex = 3
        Me.btnLoadPendingCashPayment.Tag = ""
        Me.btnLoadPendingCashPayment.Text = "&Load"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(432, 4)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(155, 20)
        Me.stbPatientNo.TabIndex = 26
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(322, 5)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(104, 20)
        Me.lblPatientsNo.TabIndex = 25
        Me.lblPatientsNo.Text = "Patient's No"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(726, 4)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(112, 20)
        Me.stbVisitDate.TabIndex = 43
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(593, 5)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(127, 20)
        Me.lblVisitDate.TabIndex = 42
        Me.lblVisitDate.Text = "Visit Date"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(106, 6)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(593, 51)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(245, 33)
        Me.stbAmountWords.TabIndex = 45
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(593, 27)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(245, 21)
        Me.lblAmountWords.TabIndex = 44
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmountPaid
        '
        Me.stbTotalAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmountPaid.CapitalizeFirstLetter = False
        Me.stbTotalAmountPaid.Enabled = False
        Me.stbTotalAmountPaid.EntryErrorMSG = ""
        Me.stbTotalAmountPaid.Location = New System.Drawing.Point(432, 91)
        Me.stbTotalAmountPaid.MaxLength = 20
        Me.stbTotalAmountPaid.Name = "stbTotalAmountPaid"
        Me.stbTotalAmountPaid.RegularExpression = ""
        Me.stbTotalAmountPaid.Size = New System.Drawing.Size(155, 20)
        Me.stbTotalAmountPaid.TabIndex = 34
        Me.stbTotalAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmountPaid
        '
        Me.lblTotalAmountPaid.Location = New System.Drawing.Point(322, 93)
        Me.lblTotalAmountPaid.Name = "lblTotalAmountPaid"
        Me.lblTotalAmountPaid.Size = New System.Drawing.Size(104, 20)
        Me.lblTotalAmountPaid.TabIndex = 33
        Me.lblTotalAmountPaid.Text = "Total Bill"
        '
        'grpPaymentDetails
        '
        Me.grpPaymentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPaymentDetails.Controls.Add(Me.dgvPaymentDetails)
        Me.grpPaymentDetails.Location = New System.Drawing.Point(6, 250)
        Me.grpPaymentDetails.Name = "grpPaymentDetails"
        Me.grpPaymentDetails.Size = New System.Drawing.Size(870, 225)
        Me.grpPaymentDetails.TabIndex = 53
        Me.grpPaymentDetails.TabStop = False
        Me.grpPaymentDetails.Text = "Payment Details"
        '
        'dgvPaymentDetails
        '
        Me.dgvPaymentDetails.AllowUserToAddRows = False
        Me.dgvPaymentDetails.AllowUserToDeleteRows = False
        Me.dgvPaymentDetails.AllowUserToOrderColumns = True
        Me.dgvPaymentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPaymentDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPaymentDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colItemCode, Me.colItemName, Me.colInvoiceNo, Me.colCategory, Me.colQuantity, Me.colUnitPrice, Me.colDiscount, Me.colAmount, Me.colItemStatus, Me.colCashAmount, Me.colBillPrice, Me.colItemCategoryID, Me.colItemStatusID, Me.colItemDetails})
        Me.dgvPaymentDetails.ContextMenuStrip = Me.cmsPayments
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentDetails.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvPaymentDetails.EnableHeadersVisualStyles = False
        Me.dgvPaymentDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvPaymentDetails.Name = "dgvPaymentDetails"
        Me.dgvPaymentDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvPaymentDetails.RowHeadersVisible = False
        Me.dgvPaymentDetails.Size = New System.Drawing.Size(864, 206)
        Me.dgvPaymentDetails.TabIndex = 0
        Me.dgvPaymentDetails.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colItemCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 180
        '
        'colInvoiceNo
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colInvoiceNo.HeaderText = "Invoice No"
        Me.colInvoiceNo.Name = "colInvoiceNo"
        Me.colInvoiceNo.ReadOnly = True
        '
        'colCategory
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle5
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        '
        'colQuantity
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colUnitPrice
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
        '
        'colDiscount
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.Width = 80
        '
        'colAmount
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle9
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'colItemStatus
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colItemStatus.DefaultCellStyle = DataGridViewCellStyle10
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 70
        '
        'colCashAmount
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        Me.colCashAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colCashAmount.HeaderText = "Cash Amount"
        Me.colCashAmount.Name = "colCashAmount"
        '
        'colBillPrice
        '
        Me.colBillPrice.HeaderText = "Bill Price"
        Me.colBillPrice.Name = "colBillPrice"
        Me.colBillPrice.Visible = False
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.Visible = False
        '
        'colItemStatusID
        '
        Me.colItemStatusID.HeaderText = "Item Status ID"
        Me.colItemStatusID.Name = "colItemStatusID"
        Me.colItemStatusID.Visible = False
        '
        'colItemDetails
        '
        Me.colItemDetails.HeaderText = "Item Details"
        Me.colItemDetails.Name = "colItemDetails"
        Me.colItemDetails.Visible = False
        '
        'cmsPayments
        '
        Me.cmsPayments.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsPayments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPaymentsCopy, Me.cmsPaymentsSelectAll, Me.cmsPaymentsAddExtraCharge, Me.ToolStripMenuItem1, Me.cmsPaymentsIncludeAll, Me.cmsPaymentsIncludeNone})
        Me.cmsPayments.Name = "cmsSearch"
        Me.cmsPayments.Size = New System.Drawing.Size(175, 120)
        '
        'cmsPaymentsCopy
        '
        Me.cmsPaymentsCopy.Enabled = False
        Me.cmsPaymentsCopy.Image = CType(resources.GetObject("cmsPaymentsCopy.Image"), System.Drawing.Image)
        Me.cmsPaymentsCopy.Name = "cmsPaymentsCopy"
        Me.cmsPaymentsCopy.Size = New System.Drawing.Size(174, 22)
        Me.cmsPaymentsCopy.Text = "Copy"
        Me.cmsPaymentsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsPaymentsSelectAll
        '
        Me.cmsPaymentsSelectAll.Enabled = False
        Me.cmsPaymentsSelectAll.Name = "cmsPaymentsSelectAll"
        Me.cmsPaymentsSelectAll.Size = New System.Drawing.Size(174, 22)
        Me.cmsPaymentsSelectAll.Text = "Select All"
        '
        'cmsPaymentsAddExtraCharge
        '
        Me.cmsPaymentsAddExtraCharge.Enabled = False
        Me.cmsPaymentsAddExtraCharge.Image = CType(resources.GetObject("cmsPaymentsAddExtraCharge.Image"), System.Drawing.Image)
        Me.cmsPaymentsAddExtraCharge.Name = "cmsPaymentsAddExtraCharge"
        Me.cmsPaymentsAddExtraCharge.Size = New System.Drawing.Size(174, 22)
        Me.cmsPaymentsAddExtraCharge.Tag = "ExtraCharge"
        Me.cmsPaymentsAddExtraCharge.Text = "Add Extra Charge..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(171, 6)
        '
        'cmsPaymentsIncludeAll
        '
        Me.cmsPaymentsIncludeAll.Enabled = False
        Me.cmsPaymentsIncludeAll.Name = "cmsPaymentsIncludeAll"
        Me.cmsPaymentsIncludeAll.Size = New System.Drawing.Size(174, 22)
        Me.cmsPaymentsIncludeAll.Text = "Include All"
        '
        'cmsPaymentsIncludeNone
        '
        Me.cmsPaymentsIncludeNone.Enabled = False
        Me.cmsPaymentsIncludeNone.Name = "cmsPaymentsIncludeNone"
        Me.cmsPaymentsIncludeNone.Size = New System.Drawing.Size(174, 22)
        Me.cmsPaymentsIncludeNone.Text = "Include None"
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.Location = New System.Drawing.Point(322, 48)
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Size = New System.Drawing.Size(104, 20)
        Me.lblDocumentNo.TabIndex = 29
        Me.lblDocumentNo.Text = "Document No"
        '
        'stbDocumentNo
        '
        Me.stbDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDocumentNo.CapitalizeFirstLetter = False
        Me.stbDocumentNo.EntryErrorMSG = ""
        Me.stbDocumentNo.Location = New System.Drawing.Point(432, 47)
        Me.stbDocumentNo.MaxLength = 12
        Me.stbDocumentNo.Name = "stbDocumentNo"
        Me.stbDocumentNo.RegularExpression = ""
        Me.stbDocumentNo.Size = New System.Drawing.Size(155, 20)
        Me.stbDocumentNo.TabIndex = 30
        '
        'cboPayModesID
        '
        Me.cboPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayModesID.FormattingEnabled = True
        Me.cboPayModesID.ItemHeight = 13
        Me.cboPayModesID.Location = New System.Drawing.Point(141, 136)
        Me.cboPayModesID.Name = "cboPayModesID"
        Me.cboPayModesID.Size = New System.Drawing.Size(169, 21)
        Me.cboPayModesID.TabIndex = 15
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(13, 94)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(118, 20)
        Me.lblReceiptNo.TabIndex = 10
        Me.lblReceiptNo.Text = "Receipt No"
        '
        'stbReceiptNo
        '
        Me.stbReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReceiptNo.CapitalizeFirstLetter = False
        Me.stbReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbReceiptNo.EntryErrorMSG = ""
        Me.stbReceiptNo.Location = New System.Drawing.Point(141, 92)
        Me.stbReceiptNo.MaxLength = 20
        Me.stbReceiptNo.Name = "stbReceiptNo"
        Me.stbReceiptNo.RegularExpression = ""
        Me.stbReceiptNo.Size = New System.Drawing.Size(169, 20)
        Me.stbReceiptNo.TabIndex = 11
        '
        'lblPayModes
        '
        Me.lblPayModes.Location = New System.Drawing.Point(13, 136)
        Me.lblPayModes.Name = "lblPayModes"
        Me.lblPayModes.Size = New System.Drawing.Size(118, 20)
        Me.lblPayModes.TabIndex = 14
        Me.lblPayModes.Text = "Mode of Payment"
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(432, 69)
        Me.stbNotes.MaxLength = 100
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.Size = New System.Drawing.Size(155, 20)
        Me.stbNotes.TabIndex = 32
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(141, 29)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 5
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(13, 31)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(118, 20)
        Me.lblFullName.TabIndex = 4
        Me.lblFullName.Text = "Full Name"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(322, 71)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(104, 20)
        Me.lblNotes.TabIndex = 31
        Me.lblNotes.Text = "Notes"
        '
        'lblPayDate
        '
        Me.lblPayDate.Location = New System.Drawing.Point(13, 115)
        Me.lblPayDate.Name = "lblPayDate"
        Me.lblPayDate.Size = New System.Drawing.Size(118, 20)
        Me.lblPayDate.TabIndex = 12
        Me.lblPayDate.Text = "Pay Date"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(13, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(79, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
        '
        'tpgBillFormPayment
        '
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPInvoiceNo)
        Me.tpgBillFormPayment.Controls.Add(Me.Label3)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPPhoneNo)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPPhoneNo)
        Me.tpgBillFormPayment.Controls.Add(Me.tbcBillFormPayment)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPCustomerName)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCustomerName)
        Me.tpgBillFormPayment.Controls.Add(Me.btnBFPExchangeRate)
        Me.tpgBillFormPayment.Controls.Add(Me.btnPayingExtraBills)
        Me.tpgBillFormPayment.Controls.Add(Me.chkBFPSendBalanceToAccount)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPChange)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPChange)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPAmountTendered)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPExchangeRate)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPAmountTendered)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPExchangeRate)
        Me.tpgBillFormPayment.Controls.Add(Me.cboBFPCurrenciesID)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCurrenciesID)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPBillMode)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPBillMode)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPCoPayValue)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCoPayValue)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPCoPayPercent)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCoPayPercent)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPCoPayType)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCoPayType)
        Me.tpgBillFormPayment.Controls.Add(Me.chkBFPUseAccountBalance)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPCashAccountBalance)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPCashAccountBalance)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPVisitNo)
        Me.tpgBillFormPayment.Controls.Add(Me.nbxBFPOutstandingBalance)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPOutstandingBalance)
        Me.tpgBillFormPayment.Controls.Add(Me.btnLoadPendingBFPayment)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPPatientNo)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPPatientsNo)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPVisitDate)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPVisitDate)
        Me.tpgBillFormPayment.Controls.Add(Me.btnBFPFindVisitNo)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPAmountWords)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPAmountWords)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPTotalAmountPaid)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPTotalAmountPaid)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPDocumentNo)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPDocumentNo)
        Me.tpgBillFormPayment.Controls.Add(Me.cboBFPPayModesID)
        Me.tpgBillFormPayment.Controls.Add(Me.dtpBFPPayDate)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPReceiptNo)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPReceiptNo)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPPayModes)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPNotes)
        Me.tpgBillFormPayment.Controls.Add(Me.stbBFPFullName)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPFullName)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPNotes)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPPayDate)
        Me.tpgBillFormPayment.Controls.Add(Me.lblBFPVisitNo)
        Me.tpgBillFormPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillFormPayment.Name = "tpgBillFormPayment"
        Me.tpgBillFormPayment.Size = New System.Drawing.Size(894, 482)
        Me.tpgBillFormPayment.TabIndex = 5
        Me.tpgBillFormPayment.Tag = "BillFormPayment"
        Me.tpgBillFormPayment.Text = "Bill Form Payment"
        Me.tpgBillFormPayment.UseVisualStyleBackColor = True
        '
        'stbBFPInvoiceNo
        '
        Me.stbBFPInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPInvoiceNo.CapitalizeFirstLetter = False
        Me.stbBFPInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBFPInvoiceNo.EntryErrorMSG = ""
        Me.stbBFPInvoiceNo.Location = New System.Drawing.Point(141, 72)
        Me.stbBFPInvoiceNo.MaxLength = 20
        Me.stbBFPInvoiceNo.Name = "stbBFPInvoiceNo"
        Me.stbBFPInvoiceNo.RegularExpression = ""
        Me.stbBFPInvoiceNo.Size = New System.Drawing.Size(169, 20)
        Me.stbBFPInvoiceNo.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(13, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 18)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "Invoice No"
        '
        'lblBFPPhoneNo
        '
        Me.lblBFPPhoneNo.Location = New System.Drawing.Point(322, 26)
        Me.lblBFPPhoneNo.Name = "lblBFPPhoneNo"
        Me.lblBFPPhoneNo.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPPhoneNo.TabIndex = 57
        Me.lblBFPPhoneNo.Text = "Phone"
        '
        'stbBFPPhoneNo
        '
        Me.stbBFPPhoneNo.BackColor = System.Drawing.SystemColors.Control
        Me.stbBFPPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPPhoneNo.CapitalizeFirstLetter = True
        Me.stbBFPPhoneNo.EntryErrorMSG = ""
        Me.stbBFPPhoneNo.Location = New System.Drawing.Point(432, 26)
        Me.stbBFPPhoneNo.MaxLength = 100
        Me.stbBFPPhoneNo.Multiline = True
        Me.stbBFPPhoneNo.Name = "stbBFPPhoneNo"
        Me.stbBFPPhoneNo.ReadOnly = True
        Me.stbBFPPhoneNo.RegularExpression = ""
        Me.stbBFPPhoneNo.Size = New System.Drawing.Size(155, 20)
        Me.stbBFPPhoneNo.TabIndex = 56
        '
        'tbcBillFormPayment
        '
        Me.tbcBillFormPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcBillFormPayment.Controls.Add(Me.tpgBillingForm)
        Me.tbcBillFormPayment.Controls.Add(Me.tpgPendingBill)
        Me.tbcBillFormPayment.HotTrack = True
        Me.tbcBillFormPayment.Location = New System.Drawing.Point(3, 253)
        Me.tbcBillFormPayment.Name = "tbcBillFormPayment"
        Me.tbcBillFormPayment.SelectedIndex = 0
        Me.tbcBillFormPayment.Size = New System.Drawing.Size(897, 226)
        Me.tbcBillFormPayment.TabIndex = 51
        '
        'tpgBillingForm
        '
        Me.tpgBillingForm.Controls.Add(Me.dgvPaymentExtraBillItems)
        Me.tpgBillingForm.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillingForm.Name = "tpgBillingForm"
        Me.tpgBillingForm.Size = New System.Drawing.Size(889, 200)
        Me.tpgBillingForm.TabIndex = 6
        Me.tpgBillingForm.Tag = "IPDInvoices"
        Me.tpgBillingForm.Text = "Billing Form"
        Me.tpgBillingForm.UseVisualStyleBackColor = True
        '
        'dgvPaymentExtraBillItems
        '
        Me.dgvPaymentExtraBillItems.AllowUserToAddRows = False
        Me.dgvPaymentExtraBillItems.AllowUserToDeleteRows = False
        Me.dgvPaymentExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvPaymentExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPaymentExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPaymentExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPaymentExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBFPInclude, Me.colBFPExtraBillNo, Me.colBFPExtraBillDate, Me.colBFPItemCode, Me.colBFPItemName, Me.colBFPInvoiceNo, Me.colBFPCategory, Me.colBFPQuantity, Me.colBFPUnitPrice, Me.colBFPDiscount, Me.colBFPAmount, Me.colBFPEntryMode, Me.colBFPCashAmount, Me.colBFPRoundNo, Me.colBFPItemCategoryID})
        Me.dgvPaymentExtraBillItems.ContextMenuStrip = Me.cmsPayments
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentExtraBillItems.DefaultCellStyle = DataGridViewCellStyle28
        Me.dgvPaymentExtraBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvPaymentExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentExtraBillItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvPaymentExtraBillItems.Name = "dgvPaymentExtraBillItems"
        Me.dgvPaymentExtraBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvPaymentExtraBillItems.RowHeadersVisible = False
        Me.dgvPaymentExtraBillItems.Size = New System.Drawing.Size(889, 200)
        Me.dgvPaymentExtraBillItems.TabIndex = 1
        Me.dgvPaymentExtraBillItems.Text = "DataGridView1"
        '
        'colBFPInclude
        '
        Me.colBFPInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBFPInclude.HeaderText = "Include"
        Me.colBFPInclude.Name = "colBFPInclude"
        Me.colBFPInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBFPInclude.Width = 50
        '
        'colBFPExtraBillNo
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colBFPExtraBillNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.colBFPExtraBillNo.HeaderText = "Bill No"
        Me.colBFPExtraBillNo.Name = "colBFPExtraBillNo"
        Me.colBFPExtraBillNo.ReadOnly = True
        Me.colBFPExtraBillNo.Width = 80
        '
        'colBFPExtraBillDate
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colBFPExtraBillDate.DefaultCellStyle = DataGridViewCellStyle16
        Me.colBFPExtraBillDate.HeaderText = "Bill Date"
        Me.colBFPExtraBillDate.Name = "colBFPExtraBillDate"
        Me.colBFPExtraBillDate.ReadOnly = True
        Me.colBFPExtraBillDate.Width = 90
        '
        'colBFPItemCode
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBFPItemCode.DefaultCellStyle = DataGridViewCellStyle17
        Me.colBFPItemCode.HeaderText = "Item Code"
        Me.colBFPItemCode.Name = "colBFPItemCode"
        Me.colBFPItemCode.ReadOnly = True
        Me.colBFPItemCode.Width = 60
        '
        'colBFPItemName
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBFPItemName.DefaultCellStyle = DataGridViewCellStyle18
        Me.colBFPItemName.HeaderText = "Item Name"
        Me.colBFPItemName.Name = "colBFPItemName"
        Me.colBFPItemName.ReadOnly = True
        Me.colBFPItemName.Width = 120
        '
        'colBFPInvoiceNo
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colBFPInvoiceNo.DefaultCellStyle = DataGridViewCellStyle19
        Me.colBFPInvoiceNo.HeaderText = "Invoice No"
        Me.colBFPInvoiceNo.Name = "colBFPInvoiceNo"
        Me.colBFPInvoiceNo.ReadOnly = True
        '
        'colBFPCategory
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBFPCategory.DefaultCellStyle = DataGridViewCellStyle20
        Me.colBFPCategory.HeaderText = "Category"
        Me.colBFPCategory.Name = "colBFPCategory"
        Me.colBFPCategory.ReadOnly = True
        Me.colBFPCategory.Width = 70
        '
        'colBFPQuantity
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle21.Format = "N0"
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.NullValue = Nothing
        Me.colBFPQuantity.DefaultCellStyle = DataGridViewCellStyle21
        Me.colBFPQuantity.HeaderText = "Quantity"
        Me.colBFPQuantity.Name = "colBFPQuantity"
        Me.colBFPQuantity.ReadOnly = True
        Me.colBFPQuantity.Width = 60
        '
        'colBFPUnitPrice
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colBFPUnitPrice.DefaultCellStyle = DataGridViewCellStyle22
        Me.colBFPUnitPrice.HeaderText = "Unit Price"
        Me.colBFPUnitPrice.Name = "colBFPUnitPrice"
        Me.colBFPUnitPrice.ReadOnly = True
        Me.colBFPUnitPrice.Width = 80
        '
        'colBFPDiscount
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle23.NullValue = Nothing
        Me.colBFPDiscount.DefaultCellStyle = DataGridViewCellStyle23
        Me.colBFPDiscount.HeaderText = "Discount"
        Me.colBFPDiscount.Name = "colBFPDiscount"
        Me.colBFPDiscount.Width = 70
        '
        'colBFPAmount
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle24.NullValue = Nothing
        Me.colBFPAmount.DefaultCellStyle = DataGridViewCellStyle24
        Me.colBFPAmount.HeaderText = "Amount"
        Me.colBFPAmount.Name = "colBFPAmount"
        Me.colBFPAmount.ReadOnly = True
        Me.colBFPAmount.Width = 80
        '
        'colBFPEntryMode
        '
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        Me.colBFPEntryMode.DefaultCellStyle = DataGridViewCellStyle25
        Me.colBFPEntryMode.HeaderText = "Entry Mode"
        Me.colBFPEntryMode.Name = "colBFPEntryMode"
        Me.colBFPEntryMode.ReadOnly = True
        Me.colBFPEntryMode.Width = 80
        '
        'colBFPCashAmount
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle26.Format = "N2"
        Me.colBFPCashAmount.DefaultCellStyle = DataGridViewCellStyle26
        Me.colBFPCashAmount.HeaderText = "Cash Amount"
        Me.colBFPCashAmount.Name = "colBFPCashAmount"
        Me.colBFPCashAmount.ReadOnly = True
        '
        'colBFPRoundNo
        '
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        Me.colBFPRoundNo.DefaultCellStyle = DataGridViewCellStyle27
        Me.colBFPRoundNo.HeaderText = "Round No"
        Me.colBFPRoundNo.Name = "colBFPRoundNo"
        Me.colBFPRoundNo.ReadOnly = True
        Me.colBFPRoundNo.Visible = False
        '
        'colBFPItemCategoryID
        '
        Me.colBFPItemCategoryID.HeaderText = "Item Category ID"
        Me.colBFPItemCategoryID.Name = "colBFPItemCategoryID"
        Me.colBFPItemCategoryID.ReadOnly = True
        Me.colBFPItemCategoryID.Visible = False
        '
        'tpgPendingBill
        '
        Me.tpgPendingBill.Controls.Add(Me.dgvPendingBillItems)
        Me.tpgPendingBill.Location = New System.Drawing.Point(4, 22)
        Me.tpgPendingBill.Name = "tpgPendingBill"
        Me.tpgPendingBill.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPendingBill.Size = New System.Drawing.Size(889, 200)
        Me.tpgPendingBill.TabIndex = 8
        Me.tpgPendingBill.Tag = "IPDPendingBill"
        Me.tpgPendingBill.Text = "Pending Bill"
        Me.tpgPendingBill.UseVisualStyleBackColor = True
        '
        'dgvPendingBillItems
        '
        Me.dgvPendingBillItems.AllowUserToAddRows = False
        Me.dgvPendingBillItems.AllowUserToDeleteRows = False
        Me.dgvPendingBillItems.AllowUserToOrderColumns = True
        Me.dgvPendingBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvPendingBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPendingBillItemsInclude, Me.colPendingBillItemsRoundNo, Me.colPendingBillItemsRoundDateTime, Me.ColExtraBillNo, Me.colPendingBillItemsItemName, Me.colPendingBillItemsItemCode, Me.colPendingBillItemsCategoryID, Me.colPendingBillItemsCategory, Me.colPendingBillItemsQuantity, Me.colPendingBillItemsUnitPrice, Me.colPendingBillItemsDiscount, Me.colPendingBillItemsAmount, Me.colPendingBillItemsPayStatus, Me.colPendingBillItemsItemStatus})
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPendingBillItems.DefaultCellStyle = DataGridViewCellStyle43
        Me.dgvPendingBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendingBillItems.EnableHeadersVisualStyles = False
        Me.dgvPendingBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingBillItems.Location = New System.Drawing.Point(3, 3)
        Me.dgvPendingBillItems.Name = "dgvPendingBillItems"
        Me.dgvPendingBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle44.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle44
        Me.dgvPendingBillItems.RowHeadersVisible = False
        Me.dgvPendingBillItems.Size = New System.Drawing.Size(883, 194)
        Me.dgvPendingBillItems.TabIndex = 47
        Me.dgvPendingBillItems.Text = "DataGridView1"
        '
        'colPendingBillItemsInclude
        '
        Me.colPendingBillItemsInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPendingBillItemsInclude.HeaderText = "Include"
        Me.colPendingBillItemsInclude.Name = "colPendingBillItemsInclude"
        Me.colPendingBillItemsInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPendingBillItemsInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPendingBillItemsInclude.Width = 50
        '
        'colPendingBillItemsRoundNo
        '
        Me.colPendingBillItemsRoundNo.DataPropertyName = "RoundNo"
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsRoundNo.DefaultCellStyle = DataGridViewCellStyle31
        Me.colPendingBillItemsRoundNo.HeaderText = "Round No"
        Me.colPendingBillItemsRoundNo.Name = "colPendingBillItemsRoundNo"
        Me.colPendingBillItemsRoundNo.ReadOnly = True
        '
        'colPendingBillItemsRoundDateTime
        '
        Me.colPendingBillItemsRoundDateTime.DataPropertyName = "RoundDateTime"
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsRoundDateTime.DefaultCellStyle = DataGridViewCellStyle32
        Me.colPendingBillItemsRoundDateTime.HeaderText = "Round Date Time"
        Me.colPendingBillItemsRoundDateTime.Name = "colPendingBillItemsRoundDateTime"
        Me.colPendingBillItemsRoundDateTime.ReadOnly = True
        Me.colPendingBillItemsRoundDateTime.Width = 120
        '
        'ColExtraBillNo
        '
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        Me.ColExtraBillNo.DefaultCellStyle = DataGridViewCellStyle33
        Me.ColExtraBillNo.HeaderText = "Bill No"
        Me.ColExtraBillNo.Name = "ColExtraBillNo"
        Me.ColExtraBillNo.ReadOnly = True
        '
        'colPendingBillItemsItemName
        '
        Me.colPendingBillItemsItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle34.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colPendingBillItemsItemName.DefaultCellStyle = DataGridViewCellStyle34
        Me.colPendingBillItemsItemName.HeaderText = "Item Name"
        Me.colPendingBillItemsItemName.Name = "colPendingBillItemsItemName"
        Me.colPendingBillItemsItemName.ReadOnly = True
        Me.colPendingBillItemsItemName.Width = 150
        '
        'colPendingBillItemsItemCode
        '
        DataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsItemCode.DefaultCellStyle = DataGridViewCellStyle35
        Me.colPendingBillItemsItemCode.HeaderText = "ItemCode"
        Me.colPendingBillItemsItemCode.Name = "colPendingBillItemsItemCode"
        '
        'colPendingBillItemsCategoryID
        '
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsCategoryID.DefaultCellStyle = DataGridViewCellStyle36
        Me.colPendingBillItemsCategoryID.HeaderText = "CategoryID"
        Me.colPendingBillItemsCategoryID.Name = "colPendingBillItemsCategoryID"
        Me.colPendingBillItemsCategoryID.ReadOnly = True
        Me.colPendingBillItemsCategoryID.Visible = False
        Me.colPendingBillItemsCategoryID.Width = 60
        '
        'colPendingBillItemsCategory
        '
        Me.colPendingBillItemsCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colPendingBillItemsCategory.DefaultCellStyle = DataGridViewCellStyle37
        Me.colPendingBillItemsCategory.HeaderText = "Category"
        Me.colPendingBillItemsCategory.Name = "colPendingBillItemsCategory"
        Me.colPendingBillItemsCategory.ReadOnly = True
        Me.colPendingBillItemsCategory.Width = 60
        '
        'colPendingBillItemsQuantity
        '
        Me.colPendingBillItemsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle38.Format = "N0"
        DataGridViewCellStyle38.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle38.NullValue = Nothing
        Me.colPendingBillItemsQuantity.DefaultCellStyle = DataGridViewCellStyle38
        Me.colPendingBillItemsQuantity.HeaderText = "Quantity"
        Me.colPendingBillItemsQuantity.Name = "colPendingBillItemsQuantity"
        Me.colPendingBillItemsQuantity.ReadOnly = True
        Me.colPendingBillItemsQuantity.Width = 50
        '
        'colPendingBillItemsUnitPrice
        '
        Me.colPendingBillItemsUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle39.Format = "N2"
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle39.NullValue = Nothing
        Me.colPendingBillItemsUnitPrice.DefaultCellStyle = DataGridViewCellStyle39
        Me.colPendingBillItemsUnitPrice.HeaderText = "Unit Price"
        Me.colPendingBillItemsUnitPrice.Name = "colPendingBillItemsUnitPrice"
        Me.colPendingBillItemsUnitPrice.ReadOnly = True
        Me.colPendingBillItemsUnitPrice.Width = 65
        '
        'colPendingBillItemsDiscount
        '
        Me.colPendingBillItemsDiscount.HeaderText = "Discount"
        Me.colPendingBillItemsDiscount.Name = "colPendingBillItemsDiscount"
        '
        'colPendingBillItemsAmount
        '
        Me.colPendingBillItemsAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle40.NullValue = Nothing
        Me.colPendingBillItemsAmount.DefaultCellStyle = DataGridViewCellStyle40
        Me.colPendingBillItemsAmount.HeaderText = "Amount"
        Me.colPendingBillItemsAmount.Name = "colPendingBillItemsAmount"
        Me.colPendingBillItemsAmount.ReadOnly = True
        Me.colPendingBillItemsAmount.Width = 65
        '
        'colPendingBillItemsPayStatus
        '
        Me.colPendingBillItemsPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsPayStatus.DefaultCellStyle = DataGridViewCellStyle41
        Me.colPendingBillItemsPayStatus.HeaderText = "Pay Status"
        Me.colPendingBillItemsPayStatus.Name = "colPendingBillItemsPayStatus"
        Me.colPendingBillItemsPayStatus.ReadOnly = True
        Me.colPendingBillItemsPayStatus.Width = 70
        '
        'colPendingBillItemsItemStatus
        '
        Me.colPendingBillItemsItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Info
        Me.colPendingBillItemsItemStatus.DefaultCellStyle = DataGridViewCellStyle42
        Me.colPendingBillItemsItemStatus.HeaderText = "Item Status"
        Me.colPendingBillItemsItemStatus.Name = "colPendingBillItemsItemStatus"
        Me.colPendingBillItemsItemStatus.ReadOnly = True
        Me.colPendingBillItemsItemStatus.Width = 70
        '
        'stbBFPCustomerName
        '
        Me.stbBFPCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPCustomerName.CapitalizeFirstLetter = False
        Me.stbBFPCustomerName.EntryErrorMSG = ""
        Me.stbBFPCustomerName.Location = New System.Drawing.Point(432, 179)
        Me.stbBFPCustomerName.MaxLength = 41
        Me.stbBFPCustomerName.Multiline = True
        Me.stbBFPCustomerName.Name = "stbBFPCustomerName"
        Me.stbBFPCustomerName.ReadOnly = True
        Me.stbBFPCustomerName.RegularExpression = ""
        Me.stbBFPCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPCustomerName.Size = New System.Drawing.Size(406, 24)
        Me.stbBFPCustomerName.TabIndex = 47
        '
        'lblBFPCustomerName
        '
        Me.lblBFPCustomerName.Location = New System.Drawing.Point(322, 182)
        Me.lblBFPCustomerName.Name = "lblBFPCustomerName"
        Me.lblBFPCustomerName.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPCustomerName.TabIndex = 46
        Me.lblBFPCustomerName.Text = "To-Bill Customer"
        '
        'btnBFPExchangeRate
        '
        Me.btnBFPExchangeRate.Enabled = False
        Me.btnBFPExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnBFPExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBFPExchangeRate.Image = CType(resources.GetObject("btnBFPExchangeRate.Image"), System.Drawing.Image)
        Me.btnBFPExchangeRate.Location = New System.Drawing.Point(106, 205)
        Me.btnBFPExchangeRate.Name = "btnBFPExchangeRate"
        Me.btnBFPExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnBFPExchangeRate.TabIndex = 19
        Me.btnBFPExchangeRate.Tag = "ExchangeRates"
        '
        'btnPayingExtraBills
        '
        Me.btnPayingExtraBills.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPayingExtraBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayingExtraBills.Location = New System.Drawing.Point(728, 210)
        Me.btnPayingExtraBills.Name = "btnPayingExtraBills"
        Me.btnPayingExtraBills.Size = New System.Drawing.Size(110, 23)
        Me.btnPayingExtraBills.TabIndex = 49
        Me.btnPayingExtraBills.Tag = ""
        Me.btnPayingExtraBills.Text = "&To-Pay Bills"
        '
        'chkBFPSendBalanceToAccount
        '
        Me.chkBFPSendBalanceToAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBFPSendBalanceToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBFPSendBalanceToAccount.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkBFPSendBalanceToAccount.Location = New System.Drawing.Point(323, 206)
        Me.chkBFPSendBalanceToAccount.Name = "chkBFPSendBalanceToAccount"
        Me.chkBFPSendBalanceToAccount.Size = New System.Drawing.Size(195, 20)
        Me.chkBFPSendBalanceToAccount.TabIndex = 48
        Me.chkBFPSendBalanceToAccount.Text = "Send Balance To Account"
        '
        'stbBFPChange
        '
        Me.stbBFPChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbBFPChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPChange.CapitalizeFirstLetter = False
        Me.stbBFPChange.Enabled = False
        Me.stbBFPChange.EntryErrorMSG = ""
        Me.stbBFPChange.Location = New System.Drawing.Point(141, 228)
        Me.stbBFPChange.MaxLength = 20
        Me.stbBFPChange.Name = "stbBFPChange"
        Me.stbBFPChange.RegularExpression = ""
        Me.stbBFPChange.Size = New System.Drawing.Size(169, 20)
        Me.stbBFPChange.TabIndex = 22
        Me.stbBFPChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBFPChange
        '
        Me.lblBFPChange.Location = New System.Drawing.Point(13, 230)
        Me.lblBFPChange.Name = "lblBFPChange"
        Me.lblBFPChange.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPChange.TabIndex = 21
        Me.lblBFPChange.Text = "Change"
        '
        'nbxBFPAmountTendered
        '
        Me.nbxBFPAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxBFPAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBFPAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBFPAmountTendered.DecimalPlaces = -1
        Me.nbxBFPAmountTendered.DenyNegativeEntryValue = True
        Me.nbxBFPAmountTendered.Location = New System.Drawing.Point(141, 186)
        Me.nbxBFPAmountTendered.MaxValue = 0.0R
        Me.nbxBFPAmountTendered.MinValue = 0.0R
        Me.nbxBFPAmountTendered.MustEnterNumeric = True
        Me.nbxBFPAmountTendered.Name = "nbxBFPAmountTendered"
        Me.nbxBFPAmountTendered.Size = New System.Drawing.Size(169, 20)
        Me.nbxBFPAmountTendered.TabIndex = 17
        Me.nbxBFPAmountTendered.Value = ""
        '
        'nbxBFPExchangeRate
        '
        Me.nbxBFPExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxBFPExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBFPExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBFPExchangeRate.DecimalPlaces = -1
        Me.nbxBFPExchangeRate.DenyZeroEntryValue = True
        Me.nbxBFPExchangeRate.Location = New System.Drawing.Point(141, 207)
        Me.nbxBFPExchangeRate.MaxValue = 0.0R
        Me.nbxBFPExchangeRate.MinValue = 0.0R
        Me.nbxBFPExchangeRate.MustEnterNumeric = True
        Me.nbxBFPExchangeRate.Name = "nbxBFPExchangeRate"
        Me.nbxBFPExchangeRate.Size = New System.Drawing.Size(169, 20)
        Me.nbxBFPExchangeRate.TabIndex = 20
        Me.nbxBFPExchangeRate.Value = ""
        '
        'lblBFPAmountTendered
        '
        Me.lblBFPAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblBFPAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBFPAmountTendered.Location = New System.Drawing.Point(13, 186)
        Me.lblBFPAmountTendered.Name = "lblBFPAmountTendered"
        Me.lblBFPAmountTendered.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPAmountTendered.TabIndex = 16
        Me.lblBFPAmountTendered.Text = "Amount Tendered"
        '
        'lblBFPExchangeRate
        '
        Me.lblBFPExchangeRate.Location = New System.Drawing.Point(13, 208)
        Me.lblBFPExchangeRate.Name = "lblBFPExchangeRate"
        Me.lblBFPExchangeRate.Size = New System.Drawing.Size(87, 20)
        Me.lblBFPExchangeRate.TabIndex = 18
        Me.lblBFPExchangeRate.Text = "Exchange Rate"
        '
        'cboBFPCurrenciesID
        '
        Me.cboBFPCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBFPCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBFPCurrenciesID.FormattingEnabled = True
        Me.cboBFPCurrenciesID.ItemHeight = 13
        Me.cboBFPCurrenciesID.Location = New System.Drawing.Point(141, 162)
        Me.cboBFPCurrenciesID.Name = "cboBFPCurrenciesID"
        Me.cboBFPCurrenciesID.Size = New System.Drawing.Size(169, 21)
        Me.cboBFPCurrenciesID.TabIndex = 15
        '
        'lblBFPCurrenciesID
        '
        Me.lblBFPCurrenciesID.Location = New System.Drawing.Point(13, 162)
        Me.lblBFPCurrenciesID.Name = "lblBFPCurrenciesID"
        Me.lblBFPCurrenciesID.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPCurrenciesID.TabIndex = 14
        Me.lblBFPCurrenciesID.Text = "Pay in Currency"
        '
        'stbBFPBillMode
        '
        Me.stbBFPBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPBillMode.CapitalizeFirstLetter = False
        Me.stbBFPBillMode.Enabled = False
        Me.stbBFPBillMode.EntryErrorMSG = ""
        Me.stbBFPBillMode.Location = New System.Drawing.Point(726, 109)
        Me.stbBFPBillMode.MaxLength = 60
        Me.stbBFPBillMode.Name = "stbBFPBillMode"
        Me.stbBFPBillMode.RegularExpression = ""
        Me.stbBFPBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPBillMode.Size = New System.Drawing.Size(112, 20)
        Me.stbBFPBillMode.TabIndex = 37
        '
        'lblBFPBillMode
        '
        Me.lblBFPBillMode.Location = New System.Drawing.Point(593, 111)
        Me.lblBFPBillMode.Name = "lblBFPBillMode"
        Me.lblBFPBillMode.Size = New System.Drawing.Size(127, 20)
        Me.lblBFPBillMode.TabIndex = 36
        Me.lblBFPBillMode.Text = "Bill Mode"
        '
        'nbxBFPCoPayValue
        '
        Me.nbxBFPCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxBFPCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBFPCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBFPCoPayValue.DecimalPlaces = 2
        Me.nbxBFPCoPayValue.Location = New System.Drawing.Point(764, 155)
        Me.nbxBFPCoPayValue.MaxLength = 12
        Me.nbxBFPCoPayValue.MaxValue = 0.0R
        Me.nbxBFPCoPayValue.MinValue = 0.0R
        Me.nbxBFPCoPayValue.MustEnterNumeric = True
        Me.nbxBFPCoPayValue.Name = "nbxBFPCoPayValue"
        Me.nbxBFPCoPayValue.ReadOnly = True
        Me.nbxBFPCoPayValue.Size = New System.Drawing.Size(74, 20)
        Me.nbxBFPCoPayValue.TabIndex = 45
        Me.nbxBFPCoPayValue.Value = ""
        '
        'lblBFPCoPayValue
        '
        Me.lblBFPCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBFPCoPayValue.Location = New System.Drawing.Point(679, 156)
        Me.lblBFPCoPayValue.Name = "lblBFPCoPayValue"
        Me.lblBFPCoPayValue.Size = New System.Drawing.Size(79, 19)
        Me.lblBFPCoPayValue.TabIndex = 44
        Me.lblBFPCoPayValue.Text = "Co-Pay Value"
        '
        'nbxBFPCoPayPercent
        '
        Me.nbxBFPCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxBFPCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxBFPCoPayPercent.DecimalPlaces = 2
        Me.nbxBFPCoPayPercent.Enabled = False
        Me.nbxBFPCoPayPercent.Location = New System.Drawing.Point(618, 155)
        Me.nbxBFPCoPayPercent.MaxLength = 3
        Me.nbxBFPCoPayPercent.MaxValue = 100.0R
        Me.nbxBFPCoPayPercent.MinValue = 0.0R
        Me.nbxBFPCoPayPercent.MustEnterNumeric = True
        Me.nbxBFPCoPayPercent.Name = "nbxBFPCoPayPercent"
        Me.nbxBFPCoPayPercent.Size = New System.Drawing.Size(55, 20)
        Me.nbxBFPCoPayPercent.TabIndex = 43
        Me.nbxBFPCoPayPercent.Value = ""
        '
        'lblBFPCoPayPercent
        '
        Me.lblBFPCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBFPCoPayPercent.Location = New System.Drawing.Point(524, 156)
        Me.lblBFPCoPayPercent.Name = "lblBFPCoPayPercent"
        Me.lblBFPCoPayPercent.Size = New System.Drawing.Size(88, 19)
        Me.lblBFPCoPayPercent.TabIndex = 42
        Me.lblBFPCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbBFPCoPayType
        '
        Me.stbBFPCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPCoPayType.CapitalizeFirstLetter = False
        Me.stbBFPCoPayType.Enabled = False
        Me.stbBFPCoPayType.EntryErrorMSG = ""
        Me.stbBFPCoPayType.Location = New System.Drawing.Point(432, 155)
        Me.stbBFPCoPayType.MaxLength = 20
        Me.stbBFPCoPayType.Name = "stbBFPCoPayType"
        Me.stbBFPCoPayType.RegularExpression = ""
        Me.stbBFPCoPayType.Size = New System.Drawing.Size(86, 20)
        Me.stbBFPCoPayType.TabIndex = 41
        '
        'lblBFPCoPayType
        '
        Me.lblBFPCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBFPCoPayType.Location = New System.Drawing.Point(322, 155)
        Me.lblBFPCoPayType.Name = "lblBFPCoPayType"
        Me.lblBFPCoPayType.Size = New System.Drawing.Size(76, 20)
        Me.lblBFPCoPayType.TabIndex = 40
        Me.lblBFPCoPayType.Text = "Co-Pay Type"
        '
        'chkBFPUseAccountBalance
        '
        Me.chkBFPUseAccountBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBFPUseAccountBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBFPUseAccountBalance.Location = New System.Drawing.Point(321, 130)
        Me.chkBFPUseAccountBalance.Name = "chkBFPUseAccountBalance"
        Me.chkBFPUseAccountBalance.Size = New System.Drawing.Size(197, 20)
        Me.chkBFPUseAccountBalance.TabIndex = 31
        Me.chkBFPUseAccountBalance.Text = "Use Account Balance"
        '
        'nbxBFPCashAccountBalance
        '
        Me.nbxBFPCashAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxBFPCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxBFPCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBFPCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBFPCashAccountBalance.DecimalPlaces = -1
        Me.nbxBFPCashAccountBalance.Location = New System.Drawing.Point(726, 130)
        Me.nbxBFPCashAccountBalance.MaxValue = 0.0R
        Me.nbxBFPCashAccountBalance.MinValue = 0.0R
        Me.nbxBFPCashAccountBalance.MustEnterNumeric = True
        Me.nbxBFPCashAccountBalance.Name = "nbxBFPCashAccountBalance"
        Me.nbxBFPCashAccountBalance.ReadOnly = True
        Me.nbxBFPCashAccountBalance.Size = New System.Drawing.Size(112, 20)
        Me.nbxBFPCashAccountBalance.TabIndex = 39
        Me.nbxBFPCashAccountBalance.Value = ""
        '
        'lblBFPCashAccountBalance
        '
        Me.lblBFPCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblBFPCashAccountBalance.Location = New System.Drawing.Point(593, 131)
        Me.lblBFPCashAccountBalance.Name = "lblBFPCashAccountBalance"
        Me.lblBFPCashAccountBalance.Size = New System.Drawing.Size(127, 20)
        Me.lblBFPCashAccountBalance.TabIndex = 38
        Me.lblBFPCashAccountBalance.Text = "Cash Account Balance"
        '
        'stbBFPVisitNo
        '
        Me.stbBFPVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPVisitNo.CapitalizeFirstLetter = False
        Me.stbBFPVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBFPVisitNo.EntryErrorMSG = ""
        Me.stbBFPVisitNo.Location = New System.Drawing.Point(141, 9)
        Me.stbBFPVisitNo.MaxLength = 20
        Me.stbBFPVisitNo.Name = "stbBFPVisitNo"
        Me.stbBFPVisitNo.RegularExpression = ""
        Me.stbBFPVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbBFPVisitNo.TabIndex = 2
        '
        'nbxBFPOutstandingBalance
        '
        Me.nbxBFPOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxBFPOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBFPOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxBFPOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBFPOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBFPOutstandingBalance.DecimalPlaces = -1
        Me.nbxBFPOutstandingBalance.Location = New System.Drawing.Point(141, 51)
        Me.nbxBFPOutstandingBalance.MaxValue = 0.0R
        Me.nbxBFPOutstandingBalance.MinValue = 0.0R
        Me.nbxBFPOutstandingBalance.MustEnterNumeric = True
        Me.nbxBFPOutstandingBalance.Name = "nbxBFPOutstandingBalance"
        Me.nbxBFPOutstandingBalance.ReadOnly = True
        Me.nbxBFPOutstandingBalance.Size = New System.Drawing.Size(169, 20)
        Me.nbxBFPOutstandingBalance.TabIndex = 7
        Me.nbxBFPOutstandingBalance.Value = ""
        '
        'lblBFPOutstandingBalance
        '
        Me.lblBFPOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblBFPOutstandingBalance.Location = New System.Drawing.Point(13, 52)
        Me.lblBFPOutstandingBalance.Name = "lblBFPOutstandingBalance"
        Me.lblBFPOutstandingBalance.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPOutstandingBalance.TabIndex = 6
        Me.lblBFPOutstandingBalance.Text = "Outstanding Balance"
        '
        'btnLoadPendingBFPayment
        '
        Me.btnLoadPendingBFPayment.AccessibleDescription = ""
        Me.btnLoadPendingBFPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingBFPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingBFPayment.Location = New System.Drawing.Point(262, 5)
        Me.btnLoadPendingBFPayment.Name = "btnLoadPendingBFPayment"
        Me.btnLoadPendingBFPayment.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingBFPayment.TabIndex = 3
        Me.btnLoadPendingBFPayment.Tag = ""
        Me.btnLoadPendingBFPayment.Text = "&Load"
        '
        'stbBFPPatientNo
        '
        Me.stbBFPPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPPatientNo.CapitalizeFirstLetter = False
        Me.stbBFPPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBFPPatientNo.EntryErrorMSG = ""
        Me.stbBFPPatientNo.Location = New System.Drawing.Point(432, 5)
        Me.stbBFPPatientNo.MaxLength = 7
        Me.stbBFPPatientNo.Name = "stbBFPPatientNo"
        Me.stbBFPPatientNo.ReadOnly = True
        Me.stbBFPPatientNo.RegularExpression = ""
        Me.stbBFPPatientNo.Size = New System.Drawing.Size(155, 20)
        Me.stbBFPPatientNo.TabIndex = 24
        '
        'lblBFPPatientsNo
        '
        Me.lblBFPPatientsNo.Location = New System.Drawing.Point(322, 6)
        Me.lblBFPPatientsNo.Name = "lblBFPPatientsNo"
        Me.lblBFPPatientsNo.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPPatientsNo.TabIndex = 23
        Me.lblBFPPatientsNo.Text = "Patient's No"
        '
        'stbBFPVisitDate
        '
        Me.stbBFPVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPVisitDate.CapitalizeFirstLetter = False
        Me.stbBFPVisitDate.Enabled = False
        Me.stbBFPVisitDate.EntryErrorMSG = ""
        Me.stbBFPVisitDate.Location = New System.Drawing.Point(726, 5)
        Me.stbBFPVisitDate.MaxLength = 60
        Me.stbBFPVisitDate.Name = "stbBFPVisitDate"
        Me.stbBFPVisitDate.RegularExpression = ""
        Me.stbBFPVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPVisitDate.Size = New System.Drawing.Size(112, 20)
        Me.stbBFPVisitDate.TabIndex = 33
        '
        'lblBFPVisitDate
        '
        Me.lblBFPVisitDate.Location = New System.Drawing.Point(593, 6)
        Me.lblBFPVisitDate.Name = "lblBFPVisitDate"
        Me.lblBFPVisitDate.Size = New System.Drawing.Size(127, 20)
        Me.lblBFPVisitDate.TabIndex = 32
        Me.lblBFPVisitDate.Text = "Visit Date"
        '
        'btnBFPFindVisitNo
        '
        Me.btnBFPFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnBFPFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBFPFindVisitNo.Image = CType(resources.GetObject("btnBFPFindVisitNo.Image"), System.Drawing.Image)
        Me.btnBFPFindVisitNo.Location = New System.Drawing.Point(106, 7)
        Me.btnBFPFindVisitNo.Name = "btnBFPFindVisitNo"
        Me.btnBFPFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnBFPFindVisitNo.TabIndex = 1
        '
        'stbBFPAmountWords
        '
        Me.stbBFPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBFPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPAmountWords.CapitalizeFirstLetter = False
        Me.stbBFPAmountWords.EntryErrorMSG = ""
        Me.stbBFPAmountWords.Location = New System.Drawing.Point(593, 52)
        Me.stbBFPAmountWords.MaxLength = 100
        Me.stbBFPAmountWords.Multiline = True
        Me.stbBFPAmountWords.Name = "stbBFPAmountWords"
        Me.stbBFPAmountWords.ReadOnly = True
        Me.stbBFPAmountWords.RegularExpression = ""
        Me.stbBFPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPAmountWords.Size = New System.Drawing.Size(245, 54)
        Me.stbBFPAmountWords.TabIndex = 35
        '
        'lblBFPAmountWords
        '
        Me.lblBFPAmountWords.Location = New System.Drawing.Point(593, 28)
        Me.lblBFPAmountWords.Name = "lblBFPAmountWords"
        Me.lblBFPAmountWords.Size = New System.Drawing.Size(245, 21)
        Me.lblBFPAmountWords.TabIndex = 34
        Me.lblBFPAmountWords.Text = "Amount in Words"
        '
        'stbBFPTotalAmountPaid
        '
        Me.stbBFPTotalAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbBFPTotalAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPTotalAmountPaid.CapitalizeFirstLetter = False
        Me.stbBFPTotalAmountPaid.Enabled = False
        Me.stbBFPTotalAmountPaid.EntryErrorMSG = ""
        Me.stbBFPTotalAmountPaid.Location = New System.Drawing.Point(432, 107)
        Me.stbBFPTotalAmountPaid.MaxLength = 20
        Me.stbBFPTotalAmountPaid.Name = "stbBFPTotalAmountPaid"
        Me.stbBFPTotalAmountPaid.RegularExpression = ""
        Me.stbBFPTotalAmountPaid.Size = New System.Drawing.Size(155, 20)
        Me.stbBFPTotalAmountPaid.TabIndex = 30
        Me.stbBFPTotalAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBFPTotalAmountPaid
        '
        Me.lblBFPTotalAmountPaid.Location = New System.Drawing.Point(322, 104)
        Me.lblBFPTotalAmountPaid.Name = "lblBFPTotalAmountPaid"
        Me.lblBFPTotalAmountPaid.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPTotalAmountPaid.TabIndex = 29
        Me.lblBFPTotalAmountPaid.Text = "Total Bill"
        '
        'lblBFPDocumentNo
        '
        Me.lblBFPDocumentNo.Location = New System.Drawing.Point(322, 49)
        Me.lblBFPDocumentNo.Name = "lblBFPDocumentNo"
        Me.lblBFPDocumentNo.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPDocumentNo.TabIndex = 25
        Me.lblBFPDocumentNo.Text = "Document No"
        '
        'stbBFPDocumentNo
        '
        Me.stbBFPDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPDocumentNo.CapitalizeFirstLetter = False
        Me.stbBFPDocumentNo.EntryErrorMSG = ""
        Me.stbBFPDocumentNo.Location = New System.Drawing.Point(432, 48)
        Me.stbBFPDocumentNo.MaxLength = 12
        Me.stbBFPDocumentNo.Name = "stbBFPDocumentNo"
        Me.stbBFPDocumentNo.RegularExpression = ""
        Me.stbBFPDocumentNo.Size = New System.Drawing.Size(155, 20)
        Me.stbBFPDocumentNo.TabIndex = 26
        '
        'cboBFPPayModesID
        '
        Me.cboBFPPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBFPPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBFPPayModesID.FormattingEnabled = True
        Me.cboBFPPayModesID.ItemHeight = 13
        Me.cboBFPPayModesID.Location = New System.Drawing.Point(141, 137)
        Me.cboBFPPayModesID.Name = "cboBFPPayModesID"
        Me.cboBFPPayModesID.Size = New System.Drawing.Size(169, 21)
        Me.cboBFPPayModesID.TabIndex = 13
        '
        'dtpBFPPayDate
        '
        Me.dtpBFPPayDate.Enabled = False
        Me.dtpBFPPayDate.Location = New System.Drawing.Point(141, 114)
        Me.dtpBFPPayDate.Name = "dtpBFPPayDate"
        Me.dtpBFPPayDate.ShowCheckBox = True
        Me.dtpBFPPayDate.Size = New System.Drawing.Size(169, 20)
        Me.dtpBFPPayDate.TabIndex = 11
        '
        'lblBFPReceiptNo
        '
        Me.lblBFPReceiptNo.Location = New System.Drawing.Point(13, 95)
        Me.lblBFPReceiptNo.Name = "lblBFPReceiptNo"
        Me.lblBFPReceiptNo.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPReceiptNo.TabIndex = 8
        Me.lblBFPReceiptNo.Text = "Receipt No"
        '
        'stbBFPReceiptNo
        '
        Me.stbBFPReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPReceiptNo.CapitalizeFirstLetter = False
        Me.stbBFPReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBFPReceiptNo.EntryErrorMSG = ""
        Me.stbBFPReceiptNo.Location = New System.Drawing.Point(141, 93)
        Me.stbBFPReceiptNo.MaxLength = 20
        Me.stbBFPReceiptNo.Name = "stbBFPReceiptNo"
        Me.stbBFPReceiptNo.RegularExpression = ""
        Me.stbBFPReceiptNo.Size = New System.Drawing.Size(169, 20)
        Me.stbBFPReceiptNo.TabIndex = 9
        '
        'lblBFPPayModes
        '
        Me.lblBFPPayModes.Location = New System.Drawing.Point(13, 137)
        Me.lblBFPPayModes.Name = "lblBFPPayModes"
        Me.lblBFPPayModes.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPPayModes.TabIndex = 12
        Me.lblBFPPayModes.Text = "Mode of Payment"
        '
        'stbBFPNotes
        '
        Me.stbBFPNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPNotes.CapitalizeFirstLetter = True
        Me.stbBFPNotes.EntryErrorMSG = ""
        Me.stbBFPNotes.Location = New System.Drawing.Point(432, 69)
        Me.stbBFPNotes.MaxLength = 100
        Me.stbBFPNotes.Multiline = True
        Me.stbBFPNotes.Name = "stbBFPNotes"
        Me.stbBFPNotes.RegularExpression = ""
        Me.stbBFPNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPNotes.Size = New System.Drawing.Size(155, 37)
        Me.stbBFPNotes.TabIndex = 28
        '
        'stbBFPFullName
        '
        Me.stbBFPFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPFullName.CapitalizeFirstLetter = False
        Me.stbBFPFullName.Enabled = False
        Me.stbBFPFullName.EntryErrorMSG = ""
        Me.stbBFPFullName.Location = New System.Drawing.Point(141, 30)
        Me.stbBFPFullName.MaxLength = 60
        Me.stbBFPFullName.Name = "stbBFPFullName"
        Me.stbBFPFullName.RegularExpression = ""
        Me.stbBFPFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbBFPFullName.TabIndex = 5
        '
        'lblBFPFullName
        '
        Me.lblBFPFullName.Location = New System.Drawing.Point(13, 31)
        Me.lblBFPFullName.Name = "lblBFPFullName"
        Me.lblBFPFullName.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPFullName.TabIndex = 4
        Me.lblBFPFullName.Text = "Full Name"
        '
        'lblBFPNotes
        '
        Me.lblBFPNotes.Location = New System.Drawing.Point(322, 77)
        Me.lblBFPNotes.Name = "lblBFPNotes"
        Me.lblBFPNotes.Size = New System.Drawing.Size(104, 20)
        Me.lblBFPNotes.TabIndex = 27
        Me.lblBFPNotes.Text = "Notes"
        '
        'lblBFPPayDate
        '
        Me.lblBFPPayDate.Location = New System.Drawing.Point(13, 116)
        Me.lblBFPPayDate.Name = "lblBFPPayDate"
        Me.lblBFPPayDate.Size = New System.Drawing.Size(118, 20)
        Me.lblBFPPayDate.TabIndex = 10
        Me.lblBFPPayDate.Text = "Pay Date"
        '
        'lblBFPVisitNo
        '
        Me.lblBFPVisitNo.Location = New System.Drawing.Point(13, 9)
        Me.lblBFPVisitNo.Name = "lblBFPVisitNo"
        Me.lblBFPVisitNo.Size = New System.Drawing.Size(79, 21)
        Me.lblBFPVisitNo.TabIndex = 0
        Me.lblBFPVisitNo.Text = "Visit No"
        '
        'tpgBillsPayment
        '
        Me.tpgBillsPayment.Controls.Add(Me.nbxBPGrandDiscount)
        Me.tpgBillsPayment.Controls.Add(Me.lblGrandDiscount)
        Me.tpgBillsPayment.Controls.Add(Me.nbxBPWithholdingTax)
        Me.tpgBillsPayment.Controls.Add(Me.Label4)
        Me.tpgBillsPayment.Controls.Add(Me.btnBPFindVisitNoByInvoiceNo)
        Me.tpgBillsPayment.Controls.Add(Me.btnBPExchangeRate)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPVisitNo)
        Me.tpgBillsPayment.Controls.Add(Me.btnBPFindVisitNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPCompanyName)
        Me.tpgBillsPayment.Controls.Add(Me.cboBPCompanyNo)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPCompanyName)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPCompanyNo)
        Me.tpgBillsPayment.Controls.Add(Me.chkBPUseAccountBalance)
        Me.tpgBillsPayment.Controls.Add(Me.chkBPSendBalanceToAccount)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPChange)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPChange)
        Me.tpgBillsPayment.Controls.Add(Me.nbxBPAmountTendered)
        Me.tpgBillsPayment.Controls.Add(Me.nbxBPExchangeRate)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPAmountTendered)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPExchangeRate)
        Me.tpgBillsPayment.Controls.Add(Me.cboBPCurrenciesID)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPCurrenciesID)
        Me.tpgBillsPayment.Controls.Add(Me.cboBPBillModesID)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPBillModesID)
        Me.tpgBillsPayment.Controls.Add(Me.grpBPSetParameters)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPReceiptNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPReceiptNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPAmountWords)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPAmountWords)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPAccountBalance)
        Me.tpgBillsPayment.Controls.Add(Me.lblBalance)
        Me.tpgBillsPayment.Controls.Add(Me.cboBPPayModesID)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPPayModes)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPVisitNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPTotalBill)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPTotalAmountPaid)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPChequeNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPDocumentNo)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPNotes)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPNotes)
        Me.tpgBillsPayment.Controls.Add(Me.grpBillsPayment)
        Me.tpgBillsPayment.Controls.Add(Me.stbBPBillCustomerName)
        Me.tpgBillsPayment.Controls.Add(Me.cboBPBillAccountNo)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPBillCustomerName)
        Me.tpgBillsPayment.Controls.Add(Me.lblBPBillAccountNo)
        Me.tpgBillsPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillsPayment.Name = "tpgBillsPayment"
        Me.tpgBillsPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgBillsPayment.Size = New System.Drawing.Size(894, 482)
        Me.tpgBillsPayment.TabIndex = 1
        Me.tpgBillsPayment.Tag = "BillsPayment"
        Me.tpgBillsPayment.Text = "Credit Bills Payment"
        Me.tpgBillsPayment.UseVisualStyleBackColor = True
        '
        'nbxBPGrandDiscount
        '
        Me.nbxBPGrandDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBPGrandDiscount.ControlCaption = "Grand Discount"
        Me.nbxBPGrandDiscount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBPGrandDiscount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBPGrandDiscount.DecimalPlaces = -1
        Me.nbxBPGrandDiscount.DenyNegativeEntryValue = True
        Me.nbxBPGrandDiscount.Location = New System.Drawing.Point(448, 160)
        Me.nbxBPGrandDiscount.MaxValue = 0.0R
        Me.nbxBPGrandDiscount.MinValue = 0.0R
        Me.nbxBPGrandDiscount.MustEnterNumeric = True
        Me.nbxBPGrandDiscount.Name = "nbxBPGrandDiscount"
        Me.nbxBPGrandDiscount.Size = New System.Drawing.Size(166, 20)
        Me.nbxBPGrandDiscount.TabIndex = 28
        Me.nbxBPGrandDiscount.Value = ""
        '
        'lblGrandDiscount
        '
        Me.lblGrandDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblGrandDiscount.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGrandDiscount.Location = New System.Drawing.Point(323, 160)
        Me.lblGrandDiscount.Name = "lblGrandDiscount"
        Me.lblGrandDiscount.Size = New System.Drawing.Size(119, 18)
        Me.lblGrandDiscount.TabIndex = 27
        Me.lblGrandDiscount.Text = "Grand Discount"
        '
        'nbxBPWithholdingTax
        '
        Me.nbxBPWithholdingTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBPWithholdingTax.ControlCaption = "Withholding Tax"
        Me.nbxBPWithholdingTax.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBPWithholdingTax.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBPWithholdingTax.DecimalPlaces = -1
        Me.nbxBPWithholdingTax.DenyNegativeEntryValue = True
        Me.nbxBPWithholdingTax.Location = New System.Drawing.Point(448, 138)
        Me.nbxBPWithholdingTax.MaxValue = 0.0R
        Me.nbxBPWithholdingTax.MinValue = 0.0R
        Me.nbxBPWithholdingTax.MustEnterNumeric = True
        Me.nbxBPWithholdingTax.Name = "nbxBPWithholdingTax"
        Me.nbxBPWithholdingTax.Size = New System.Drawing.Size(166, 20)
        Me.nbxBPWithholdingTax.TabIndex = 26
        Me.nbxBPWithholdingTax.Value = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(326, 138)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 18)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Withholding Tax"
        '
        'btnBPFindVisitNoByInvoiceNo
        '
        Me.btnBPFindVisitNoByInvoiceNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnBPFindVisitNoByInvoiceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBPFindVisitNoByInvoiceNo.Image = CType(resources.GetObject("btnBPFindVisitNoByInvoiceNo.Image"), System.Drawing.Image)
        Me.btnBPFindVisitNoByInvoiceNo.Location = New System.Drawing.Point(284, 149)
        Me.btnBPFindVisitNoByInvoiceNo.Name = "btnBPFindVisitNoByInvoiceNo"
        Me.btnBPFindVisitNoByInvoiceNo.Size = New System.Drawing.Size(27, 21)
        Me.btnBPFindVisitNoByInvoiceNo.TabIndex = 13
        '
        'btnBPExchangeRate
        '
        Me.btnBPExchangeRate.Enabled = False
        Me.btnBPExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnBPExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBPExchangeRate.Image = CType(resources.GetObject("btnBPExchangeRate.Image"), System.Drawing.Image)
        Me.btnBPExchangeRate.Location = New System.Drawing.Point(417, 204)
        Me.btnBPExchangeRate.Name = "btnBPExchangeRate"
        Me.btnBPExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnBPExchangeRate.TabIndex = 32
        Me.btnBPExchangeRate.Tag = "ExchangeRates"
        '
        'stbBPVisitNo
        '
        Me.stbBPVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPVisitNo.CapitalizeFirstLetter = False
        Me.stbBPVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBPVisitNo.EntryErrorMSG = ""
        Me.stbBPVisitNo.Location = New System.Drawing.Point(156, 149)
        Me.stbBPVisitNo.MaxLength = 20
        Me.stbBPVisitNo.Name = "stbBPVisitNo"
        Me.stbBPVisitNo.RegularExpression = ""
        Me.stbBPVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.stbBPVisitNo.TabIndex = 12
        '
        'btnBPFindVisitNo
        '
        Me.btnBPFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnBPFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBPFindVisitNo.Image = CType(resources.GetObject("btnBPFindVisitNo.Image"), System.Drawing.Image)
        Me.btnBPFindVisitNo.Location = New System.Drawing.Point(121, 147)
        Me.btnBPFindVisitNo.Name = "btnBPFindVisitNo"
        Me.btnBPFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnBPFindVisitNo.TabIndex = 11
        '
        'stbBPCompanyName
        '
        Me.stbBPCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPCompanyName.CapitalizeFirstLetter = True
        Me.stbBPCompanyName.Enabled = False
        Me.stbBPCompanyName.EntryErrorMSG = ""
        Me.stbBPCompanyName.Location = New System.Drawing.Point(156, 114)
        Me.stbBPCompanyName.MaxLength = 60
        Me.stbBPCompanyName.Multiline = True
        Me.stbBPCompanyName.Name = "stbBPCompanyName"
        Me.stbBPCompanyName.ReadOnly = True
        Me.stbBPCompanyName.RegularExpression = ""
        Me.stbBPCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPCompanyName.Size = New System.Drawing.Size(157, 34)
        Me.stbBPCompanyName.TabIndex = 9
        '
        'cboBPCompanyNo
        '
        Me.cboBPCompanyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBPCompanyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBPCompanyNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBPCompanyNo.DropDownWidth = 256
        Me.cboBPCompanyNo.Enabled = False
        Me.cboBPCompanyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBPCompanyNo.FormattingEnabled = True
        Me.cboBPCompanyNo.ItemHeight = 13
        Me.cboBPCompanyNo.Location = New System.Drawing.Point(156, 91)
        Me.cboBPCompanyNo.Name = "cboBPCompanyNo"
        Me.cboBPCompanyNo.Size = New System.Drawing.Size(157, 21)
        Me.cboBPCompanyNo.TabIndex = 7
        '
        'lblBPCompanyName
        '
        Me.lblBPCompanyName.Enabled = False
        Me.lblBPCompanyName.Location = New System.Drawing.Point(7, 121)
        Me.lblBPCompanyName.Name = "lblBPCompanyName"
        Me.lblBPCompanyName.Size = New System.Drawing.Size(143, 18)
        Me.lblBPCompanyName.TabIndex = 8
        Me.lblBPCompanyName.Text = "To-Bill Company Name"
        '
        'lblBPCompanyNo
        '
        Me.lblBPCompanyNo.Enabled = False
        Me.lblBPCompanyNo.Location = New System.Drawing.Point(7, 92)
        Me.lblBPCompanyNo.Name = "lblBPCompanyNo"
        Me.lblBPCompanyNo.Size = New System.Drawing.Size(143, 18)
        Me.lblBPCompanyNo.TabIndex = 6
        Me.lblBPCompanyNo.Text = "To-Bill Company Number"
        '
        'chkBPUseAccountBalance
        '
        Me.chkBPUseAccountBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBPUseAccountBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBPUseAccountBalance.Location = New System.Drawing.Point(635, 223)
        Me.chkBPUseAccountBalance.Name = "chkBPUseAccountBalance"
        Me.chkBPUseAccountBalance.Size = New System.Drawing.Size(228, 18)
        Me.chkBPUseAccountBalance.TabIndex = 43
        Me.chkBPUseAccountBalance.Text = "Use Account Balance"
        '
        'chkBPSendBalanceToAccount
        '
        Me.chkBPSendBalanceToAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBPSendBalanceToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBPSendBalanceToAccount.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkBPSendBalanceToAccount.Location = New System.Drawing.Point(317, 252)
        Me.chkBPSendBalanceToAccount.Name = "chkBPSendBalanceToAccount"
        Me.chkBPSendBalanceToAccount.Size = New System.Drawing.Size(294, 20)
        Me.chkBPSendBalanceToAccount.TabIndex = 36
        Me.chkBPSendBalanceToAccount.Text = "Send Balance To Account"
        '
        'stbBPChange
        '
        Me.stbBPChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPChange.CapitalizeFirstLetter = False
        Me.stbBPChange.Enabled = False
        Me.stbBPChange.EntryErrorMSG = ""
        Me.stbBPChange.Location = New System.Drawing.Point(448, 226)
        Me.stbBPChange.MaxLength = 20
        Me.stbBPChange.Name = "stbBPChange"
        Me.stbBPChange.RegularExpression = ""
        Me.stbBPChange.Size = New System.Drawing.Size(166, 20)
        Me.stbBPChange.TabIndex = 35
        Me.stbBPChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBPChange
        '
        Me.lblBPChange.Location = New System.Drawing.Point(322, 228)
        Me.lblBPChange.Name = "lblBPChange"
        Me.lblBPChange.Size = New System.Drawing.Size(98, 18)
        Me.lblBPChange.TabIndex = 34
        Me.lblBPChange.Text = "Change"
        '
        'nbxBPAmountTendered
        '
        Me.nbxBPAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBPAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxBPAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBPAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBPAmountTendered.DecimalPlaces = -1
        Me.nbxBPAmountTendered.DenyNegativeEntryValue = True
        Me.nbxBPAmountTendered.Location = New System.Drawing.Point(448, 182)
        Me.nbxBPAmountTendered.MaxValue = 0.0R
        Me.nbxBPAmountTendered.MinValue = 0.0R
        Me.nbxBPAmountTendered.MustEnterNumeric = True
        Me.nbxBPAmountTendered.Name = "nbxBPAmountTendered"
        Me.nbxBPAmountTendered.Size = New System.Drawing.Size(166, 20)
        Me.nbxBPAmountTendered.TabIndex = 30
        Me.nbxBPAmountTendered.Value = ""
        '
        'nbxBPExchangeRate
        '
        Me.nbxBPExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBPExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxBPExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBPExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBPExchangeRate.DecimalPlaces = -1
        Me.nbxBPExchangeRate.DenyZeroEntryValue = True
        Me.nbxBPExchangeRate.Location = New System.Drawing.Point(448, 205)
        Me.nbxBPExchangeRate.MaxValue = 0.0R
        Me.nbxBPExchangeRate.MinValue = 0.0R
        Me.nbxBPExchangeRate.MustEnterNumeric = True
        Me.nbxBPExchangeRate.Name = "nbxBPExchangeRate"
        Me.nbxBPExchangeRate.Size = New System.Drawing.Size(166, 20)
        Me.nbxBPExchangeRate.TabIndex = 33
        Me.nbxBPExchangeRate.Value = ""
        '
        'lblBPAmountTendered
        '
        Me.lblBPAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblBPAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblBPAmountTendered.Location = New System.Drawing.Point(322, 182)
        Me.lblBPAmountTendered.Name = "lblBPAmountTendered"
        Me.lblBPAmountTendered.Size = New System.Drawing.Size(120, 18)
        Me.lblBPAmountTendered.TabIndex = 29
        Me.lblBPAmountTendered.Text = "Amount Tendered"
        '
        'lblBPExchangeRate
        '
        Me.lblBPExchangeRate.Location = New System.Drawing.Point(322, 206)
        Me.lblBPExchangeRate.Name = "lblBPExchangeRate"
        Me.lblBPExchangeRate.Size = New System.Drawing.Size(85, 18)
        Me.lblBPExchangeRate.TabIndex = 31
        Me.lblBPExchangeRate.Text = "Exchange Rate"
        '
        'cboBPCurrenciesID
        '
        Me.cboBPCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBPCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBPCurrenciesID.FormattingEnabled = True
        Me.cboBPCurrenciesID.ItemHeight = 13
        Me.cboBPCurrenciesID.Location = New System.Drawing.Point(156, 215)
        Me.cboBPCurrenciesID.Name = "cboBPCurrenciesID"
        Me.cboBPCurrenciesID.Size = New System.Drawing.Size(157, 21)
        Me.cboBPCurrenciesID.TabIndex = 19
        '
        'lblBPCurrenciesID
        '
        Me.lblBPCurrenciesID.Location = New System.Drawing.Point(7, 217)
        Me.lblBPCurrenciesID.Name = "lblBPCurrenciesID"
        Me.lblBPCurrenciesID.Size = New System.Drawing.Size(143, 18)
        Me.lblBPCurrenciesID.TabIndex = 18
        Me.lblBPCurrenciesID.Text = "Pay in Currency"
        '
        'cboBPBillModesID
        '
        Me.cboBPBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBPBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBPBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBPBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBPBillModesID.FormattingEnabled = True
        Me.cboBPBillModesID.ItemHeight = 13
        Me.cboBPBillModesID.Location = New System.Drawing.Point(156, 6)
        Me.cboBPBillModesID.Name = "cboBPBillModesID"
        Me.cboBPBillModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboBPBillModesID.TabIndex = 1
        '
        'lblBPBillModesID
        '
        Me.lblBPBillModesID.Location = New System.Drawing.Point(7, 9)
        Me.lblBPBillModesID.Name = "lblBPBillModesID"
        Me.lblBPBillModesID.Size = New System.Drawing.Size(143, 18)
        Me.lblBPBillModesID.TabIndex = 0
        Me.lblBPBillModesID.Text = "To-Bill Account Category"
        '
        'grpBPSetParameters
        '
        Me.grpBPSetParameters.Controls.Add(Me.chkExcludeNotInvoicedItem)
        Me.grpBPSetParameters.Controls.Add(Me.pnlBPPeriod)
        Me.grpBPSetParameters.Controls.Add(Me.fbnExportTo)
        Me.grpBPSetParameters.Controls.Add(Me.btnLoadPendingBillsPayment)
        Me.grpBPSetParameters.Controls.Add(Me.lblBPRecordsNo)
        Me.grpBPSetParameters.Controls.Add(Me.rdoBPGetPeriod)
        Me.grpBPSetParameters.Controls.Add(Me.rdoBPGetAll)
        Me.grpBPSetParameters.Location = New System.Drawing.Point(319, 5)
        Me.grpBPSetParameters.Name = "grpBPSetParameters"
        Me.grpBPSetParameters.Size = New System.Drawing.Size(535, 108)
        Me.grpBPSetParameters.TabIndex = 22
        Me.grpBPSetParameters.TabStop = False
        Me.grpBPSetParameters.Text = "Visit Period"
        '
        'chkExcludeNotInvoicedItem
        '
        Me.chkExcludeNotInvoicedItem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExcludeNotInvoicedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExcludeNotInvoicedItem.Location = New System.Drawing.Point(337, 55)
        Me.chkExcludeNotInvoicedItem.Name = "chkExcludeNotInvoicedItem"
        Me.chkExcludeNotInvoicedItem.Size = New System.Drawing.Size(192, 20)
        Me.chkExcludeNotInvoicedItem.TabIndex = 3
        Me.chkExcludeNotInvoicedItem.Text = "Exclude Non Invoiced Items"
        '
        'pnlBPPeriod
        '
        Me.pnlBPPeriod.Controls.Add(Me.dtpBPEndDate)
        Me.pnlBPPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlBPPeriod.Controls.Add(Me.dtpBPStartDate)
        Me.pnlBPPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlBPPeriod.Location = New System.Drawing.Point(5, 37)
        Me.pnlBPPeriod.Name = "pnlBPPeriod"
        Me.pnlBPPeriod.Size = New System.Drawing.Size(314, 53)
        Me.pnlBPPeriod.TabIndex = 2
        '
        'dtpBPEndDate
        '
        Me.dtpBPEndDate.Location = New System.Drawing.Point(121, 28)
        Me.dtpBPEndDate.Name = "dtpBPEndDate"
        Me.dtpBPEndDate.ShowCheckBox = True
        Me.dtpBPEndDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpBPEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(83, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpBPStartDate
        '
        Me.dtpBPStartDate.Location = New System.Drawing.Point(121, 5)
        Me.dtpBPStartDate.Name = "dtpBPStartDate"
        Me.dtpBPStartDate.ShowCheckBox = True
        Me.dtpBPStartDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpBPStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 28)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(83, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.Enabled = False
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(423, 78)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 24)
        Me.fbnExportTo.TabIndex = 5
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'btnLoadPendingBillsPayment
        '
        Me.btnLoadPendingBillsPayment.AccessibleDescription = ""
        Me.btnLoadPendingBillsPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingBillsPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingBillsPayment.Location = New System.Drawing.Point(337, 78)
        Me.btnLoadPendingBillsPayment.Name = "btnLoadPendingBillsPayment"
        Me.btnLoadPendingBillsPayment.Size = New System.Drawing.Size(80, 24)
        Me.btnLoadPendingBillsPayment.TabIndex = 4
        Me.btnLoadPendingBillsPayment.Tag = ""
        Me.btnLoadPendingBillsPayment.Text = "&Load"
        '
        'lblBPRecordsNo
        '
        Me.lblBPRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblBPRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblBPRecordsNo.Location = New System.Drawing.Point(337, 37)
        Me.lblBPRecordsNo.Name = "lblBPRecordsNo"
        Me.lblBPRecordsNo.Size = New System.Drawing.Size(192, 13)
        Me.lblBPRecordsNo.TabIndex = 2
        Me.lblBPRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdoBPGetPeriod
        '
        Me.rdoBPGetPeriod.Checked = True
        Me.rdoBPGetPeriod.Location = New System.Drawing.Point(10, 13)
        Me.rdoBPGetPeriod.Name = "rdoBPGetPeriod"
        Me.rdoBPGetPeriod.Size = New System.Drawing.Size(237, 20)
        Me.rdoBPGetPeriod.TabIndex = 0
        Me.rdoBPGetPeriod.TabStop = True
        Me.rdoBPGetPeriod.Text = "Get Pending Bills Payment for Set Period"
        '
        'rdoBPGetAll
        '
        Me.rdoBPGetAll.Location = New System.Drawing.Point(274, 14)
        Me.rdoBPGetAll.Name = "rdoBPGetAll"
        Me.rdoBPGetAll.Size = New System.Drawing.Size(177, 20)
        Me.rdoBPGetAll.TabIndex = 1
        Me.rdoBPGetAll.Text = "Get All Pending Bills Payment"
        '
        'lblBPReceiptNo
        '
        Me.lblBPReceiptNo.AccessibleDescription = ""
        Me.lblBPReceiptNo.Location = New System.Drawing.Point(7, 172)
        Me.lblBPReceiptNo.Name = "lblBPReceiptNo"
        Me.lblBPReceiptNo.Size = New System.Drawing.Size(143, 18)
        Me.lblBPReceiptNo.TabIndex = 14
        Me.lblBPReceiptNo.Text = "Receipt No"
        '
        'stbBPReceiptNo
        '
        Me.stbBPReceiptNo.AccessibleDescription = ""
        Me.stbBPReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPReceiptNo.CapitalizeFirstLetter = False
        Me.stbBPReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbBPReceiptNo.EntryErrorMSG = ""
        Me.stbBPReceiptNo.Location = New System.Drawing.Point(156, 170)
        Me.stbBPReceiptNo.MaxLength = 20
        Me.stbBPReceiptNo.Name = "stbBPReceiptNo"
        Me.stbBPReceiptNo.RegularExpression = ""
        Me.stbBPReceiptNo.Size = New System.Drawing.Size(157, 20)
        Me.stbBPReceiptNo.TabIndex = 15
        '
        'stbBPAmountWords
        '
        Me.stbBPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPAmountWords.CapitalizeFirstLetter = False
        Me.stbBPAmountWords.EntryErrorMSG = ""
        Me.stbBPAmountWords.Location = New System.Drawing.Point(620, 159)
        Me.stbBPAmountWords.MaxLength = 100
        Me.stbBPAmountWords.Multiline = True
        Me.stbBPAmountWords.Name = "stbBPAmountWords"
        Me.stbBPAmountWords.ReadOnly = True
        Me.stbBPAmountWords.RegularExpression = ""
        Me.stbBPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPAmountWords.Size = New System.Drawing.Size(234, 34)
        Me.stbBPAmountWords.TabIndex = 40
        '
        'lblBPAmountWords
        '
        Me.lblBPAmountWords.Location = New System.Drawing.Point(617, 143)
        Me.lblBPAmountWords.Name = "lblBPAmountWords"
        Me.lblBPAmountWords.Size = New System.Drawing.Size(237, 21)
        Me.lblBPAmountWords.TabIndex = 39
        Me.lblBPAmountWords.Text = "Amount in Words"
        '
        'stbBPAccountBalance
        '
        Me.stbBPAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPAccountBalance.CapitalizeFirstLetter = False
        Me.stbBPAccountBalance.Enabled = False
        Me.stbBPAccountBalance.EntryErrorMSG = ""
        Me.stbBPAccountBalance.Location = New System.Drawing.Point(720, 196)
        Me.stbBPAccountBalance.MaxLength = 20
        Me.stbBPAccountBalance.Name = "stbBPAccountBalance"
        Me.stbBPAccountBalance.RegularExpression = ""
        Me.stbBPAccountBalance.Size = New System.Drawing.Size(134, 20)
        Me.stbBPAccountBalance.TabIndex = 42
        Me.stbBPAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBalance
        '
        Me.lblBalance.ForeColor = System.Drawing.Color.Red
        Me.lblBalance.Location = New System.Drawing.Point(617, 198)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(97, 18)
        Me.lblBalance.TabIndex = 41
        Me.lblBalance.Text = "Account Balance"
        Me.lblBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboBPPayModesID
        '
        Me.cboBPPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBPPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBPPayModesID.FormattingEnabled = True
        Me.cboBPPayModesID.ItemHeight = 13
        Me.cboBPPayModesID.Location = New System.Drawing.Point(156, 193)
        Me.cboBPPayModesID.Name = "cboBPPayModesID"
        Me.cboBPPayModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboBPPayModesID.TabIndex = 17
        '
        'lblBPPayModes
        '
        Me.lblBPPayModes.Location = New System.Drawing.Point(7, 195)
        Me.lblBPPayModes.Name = "lblBPPayModes"
        Me.lblBPPayModes.Size = New System.Drawing.Size(143, 18)
        Me.lblBPPayModes.TabIndex = 16
        Me.lblBPPayModes.Text = "Mode of Payment"
        '
        'lblBPVisitNo
        '
        Me.lblBPVisitNo.Location = New System.Drawing.Point(7, 149)
        Me.lblBPVisitNo.Name = "lblBPVisitNo"
        Me.lblBPVisitNo.Size = New System.Drawing.Size(90, 18)
        Me.lblBPVisitNo.TabIndex = 10
        Me.lblBPVisitNo.Text = "Visit No"
        '
        'stbBPTotalBill
        '
        Me.stbBPTotalBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPTotalBill.CapitalizeFirstLetter = False
        Me.stbBPTotalBill.Enabled = False
        Me.stbBPTotalBill.EntryErrorMSG = ""
        Me.stbBPTotalBill.Location = New System.Drawing.Point(720, 118)
        Me.stbBPTotalBill.MaxLength = 20
        Me.stbBPTotalBill.Name = "stbBPTotalBill"
        Me.stbBPTotalBill.RegularExpression = ""
        Me.stbBPTotalBill.Size = New System.Drawing.Size(134, 20)
        Me.stbBPTotalBill.TabIndex = 38
        Me.stbBPTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBPTotalAmountPaid
        '
        Me.lblBPTotalAmountPaid.Location = New System.Drawing.Point(617, 118)
        Me.lblBPTotalAmountPaid.Name = "lblBPTotalAmountPaid"
        Me.lblBPTotalAmountPaid.Size = New System.Drawing.Size(97, 18)
        Me.lblBPTotalAmountPaid.TabIndex = 37
        Me.lblBPTotalAmountPaid.Text = "Total Bill"
        '
        'lblBPChequeNo
        '
        Me.lblBPChequeNo.Location = New System.Drawing.Point(326, 118)
        Me.lblBPChequeNo.Name = "lblBPChequeNo"
        Me.lblBPChequeNo.Size = New System.Drawing.Size(116, 18)
        Me.lblBPChequeNo.TabIndex = 23
        Me.lblBPChequeNo.Text = "Document No."
        '
        'stbBPDocumentNo
        '
        Me.stbBPDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPDocumentNo.CapitalizeFirstLetter = False
        Me.stbBPDocumentNo.EntryErrorMSG = ""
        Me.stbBPDocumentNo.Location = New System.Drawing.Point(447, 116)
        Me.stbBPDocumentNo.MaxLength = 12
        Me.stbBPDocumentNo.Name = "stbBPDocumentNo"
        Me.stbBPDocumentNo.RegularExpression = ""
        Me.stbBPDocumentNo.Size = New System.Drawing.Size(166, 20)
        Me.stbBPDocumentNo.TabIndex = 24
        '
        'stbBPNotes
        '
        Me.stbBPNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPNotes.CapitalizeFirstLetter = True
        Me.stbBPNotes.EntryErrorMSG = ""
        Me.stbBPNotes.Location = New System.Drawing.Point(145, 239)
        Me.stbBPNotes.MaxLength = 100
        Me.stbBPNotes.Multiline = True
        Me.stbBPNotes.Name = "stbBPNotes"
        Me.stbBPNotes.RegularExpression = ""
        Me.stbBPNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPNotes.Size = New System.Drawing.Size(166, 24)
        Me.stbBPNotes.TabIndex = 21
        '
        'lblBPNotes
        '
        Me.lblBPNotes.Location = New System.Drawing.Point(6, 241)
        Me.lblBPNotes.Name = "lblBPNotes"
        Me.lblBPNotes.Size = New System.Drawing.Size(107, 18)
        Me.lblBPNotes.TabIndex = 20
        Me.lblBPNotes.Text = "Notes"
        '
        'grpBillsPayment
        '
        Me.grpBillsPayment.AccessibleDescription = ""
        Me.grpBillsPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpBillsPayment.Controls.Add(Me.dgvBillsPayment)
        Me.grpBillsPayment.Location = New System.Drawing.Point(4, 273)
        Me.grpBillsPayment.Name = "grpBillsPayment"
        Me.grpBillsPayment.Size = New System.Drawing.Size(889, 203)
        Me.grpBillsPayment.TabIndex = 44
        Me.grpBillsPayment.TabStop = False
        Me.grpBillsPayment.Text = "Bills Payment Details"
        '
        'dgvBillsPayment
        '
        Me.dgvBillsPayment.AllowUserToAddRows = False
        Me.dgvBillsPayment.AllowUserToDeleteRows = False
        Me.dgvBillsPayment.AllowUserToOrderColumns = True
        Me.dgvBillsPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBillsPayment.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvBillsPayment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBillsPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle45.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillsPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgvBillsPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBPInclude, Me.colBPPatientNo, Me.colBPVisitNo, Me.colBPInvoiceNo, Me.colBPVisitDate, Me.colBPFullName, Me.colBPItemCode, Me.colBPItemName, Me.colBPCategory, Me.colBPQuantity, Me.colBPUnitPrice, Me.colBPBillPrice, Me.colBPDiscount, Me.colBPAmount, Me.colBPInvoiceAmount, Me.colBPItemStatus, Me.colBPMemberCardNo, Me.colBPBillCustomerName, Me.colBPCoPayType, Me.colBPCoPayPercent, Me.colBPCoPayValue, Me.colBPItemCategoryID})
        Me.dgvBillsPayment.ContextMenuStrip = Me.cmsPayments
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle65.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle65.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle65.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBillsPayment.DefaultCellStyle = DataGridViewCellStyle65
        Me.dgvBillsPayment.EnableHeadersVisualStyles = False
        Me.dgvBillsPayment.GridColor = System.Drawing.Color.Khaki
        Me.dgvBillsPayment.Location = New System.Drawing.Point(3, 19)
        Me.dgvBillsPayment.Name = "dgvBillsPayment"
        Me.dgvBillsPayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle66.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle66.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle66.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle66.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle66.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle66.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillsPayment.RowHeadersDefaultCellStyle = DataGridViewCellStyle66
        Me.dgvBillsPayment.RowHeadersVisible = False
        Me.dgvBillsPayment.Size = New System.Drawing.Size(883, 181)
        Me.dgvBillsPayment.TabIndex = 0
        Me.dgvBillsPayment.Text = "DataGridView1"
        '
        'colBPInclude
        '
        Me.colBPInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBPInclude.HeaderText = "Include"
        Me.colBPInclude.Name = "colBPInclude"
        Me.colBPInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBPInclude.Width = 50
        '
        'colBPPatientNo
        '
        Me.colBPPatientNo.DataPropertyName = "PatientNo"
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Info
        Me.colBPPatientNo.DefaultCellStyle = DataGridViewCellStyle46
        Me.colBPPatientNo.HeaderText = "Patient No"
        Me.colBPPatientNo.Name = "colBPPatientNo"
        Me.colBPPatientNo.ReadOnly = True
        Me.colBPPatientNo.Width = 70
        '
        'colBPVisitNo
        '
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBPVisitNo.DefaultCellStyle = DataGridViewCellStyle47
        Me.colBPVisitNo.HeaderText = "Visit No"
        Me.colBPVisitNo.Name = "colBPVisitNo"
        Me.colBPVisitNo.ReadOnly = True
        Me.colBPVisitNo.Width = 75
        '
        'colBPInvoiceNo
        '
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Info
        Me.colBPInvoiceNo.DefaultCellStyle = DataGridViewCellStyle48
        Me.colBPInvoiceNo.HeaderText = "Invoice No"
        Me.colBPInvoiceNo.Name = "colBPInvoiceNo"
        Me.colBPInvoiceNo.ReadOnly = True
        '
        'colBPVisitDate
        '
        DataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Info
        Me.colBPVisitDate.DefaultCellStyle = DataGridViewCellStyle49
        Me.colBPVisitDate.HeaderText = "Visit Date"
        Me.colBPVisitDate.Name = "colBPVisitDate"
        Me.colBPVisitDate.ReadOnly = True
        Me.colBPVisitDate.Width = 70
        '
        'colBPFullName
        '
        DataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.Info
        Me.colBPFullName.DefaultCellStyle = DataGridViewCellStyle50
        Me.colBPFullName.HeaderText = "Full Name"
        Me.colBPFullName.Name = "colBPFullName"
        Me.colBPFullName.ReadOnly = True
        Me.colBPFullName.Width = 80
        '
        'colBPItemCode
        '
        DataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle51.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBPItemCode.DefaultCellStyle = DataGridViewCellStyle51
        Me.colBPItemCode.HeaderText = "Item Code"
        Me.colBPItemCode.Name = "colBPItemCode"
        Me.colBPItemCode.ReadOnly = True
        Me.colBPItemCode.Width = 65
        '
        'colBPItemName
        '
        DataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle52.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBPItemName.DefaultCellStyle = DataGridViewCellStyle52
        Me.colBPItemName.HeaderText = "Item Name"
        Me.colBPItemName.Name = "colBPItemName"
        Me.colBPItemName.ReadOnly = True
        Me.colBPItemName.Width = 80
        '
        'colBPCategory
        '
        DataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle53.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBPCategory.DefaultCellStyle = DataGridViewCellStyle53
        Me.colBPCategory.HeaderText = "Category"
        Me.colBPCategory.Name = "colBPCategory"
        Me.colBPCategory.ReadOnly = True
        Me.colBPCategory.Width = 70
        '
        'colBPQuantity
        '
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle54.Format = "N0"
        DataGridViewCellStyle54.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle54.NullValue = Nothing
        Me.colBPQuantity.DefaultCellStyle = DataGridViewCellStyle54
        Me.colBPQuantity.HeaderText = "Quantity"
        Me.colBPQuantity.Name = "colBPQuantity"
        Me.colBPQuantity.ReadOnly = True
        Me.colBPQuantity.Width = 50
        '
        'colBPUnitPrice
        '
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle55.Format = "N2"
        DataGridViewCellStyle55.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle55.NullValue = Nothing
        Me.colBPUnitPrice.DefaultCellStyle = DataGridViewCellStyle55
        Me.colBPUnitPrice.HeaderText = "Unit Price"
        Me.colBPUnitPrice.Name = "colBPUnitPrice"
        Me.colBPUnitPrice.ReadOnly = True
        Me.colBPUnitPrice.Width = 60
        '
        'colBPBillPrice
        '
        Me.colBPBillPrice.HeaderText = "Bill Price"
        Me.colBPBillPrice.Name = "colBPBillPrice"
        Me.colBPBillPrice.ReadOnly = True
        Me.colBPBillPrice.Visible = False
        '
        'colBPDiscount
        '
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle56.Format = "N2"
        DataGridViewCellStyle56.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colBPDiscount.DefaultCellStyle = DataGridViewCellStyle56
        Me.colBPDiscount.HeaderText = "Discount"
        Me.colBPDiscount.Name = "colBPDiscount"
        Me.colBPDiscount.Width = 60
        '
        'colBPAmount
        '
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle57.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle57.Format = "N2"
        DataGridViewCellStyle57.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle57.NullValue = Nothing
        Me.colBPAmount.DefaultCellStyle = DataGridViewCellStyle57
        Me.colBPAmount.HeaderText = "Amount"
        Me.colBPAmount.Name = "colBPAmount"
        Me.colBPAmount.ReadOnly = True
        Me.colBPAmount.Width = 80
        '
        'colBPInvoiceAmount
        '
        Me.colBPInvoiceAmount.HeaderText = "‌Invoice Amount"
        Me.colBPInvoiceAmount.Name = "colBPInvoiceAmount"
        Me.colBPInvoiceAmount.ReadOnly = True
        '
        'colBPItemStatus
        '
        DataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Info
        Me.colBPItemStatus.DefaultCellStyle = DataGridViewCellStyle58
        Me.colBPItemStatus.HeaderText = "Item Status"
        Me.colBPItemStatus.Name = "colBPItemStatus"
        Me.colBPItemStatus.ReadOnly = True
        Me.colBPItemStatus.Width = 70
        '
        'colBPMemberCardNo
        '
        Me.colBPMemberCardNo.DataPropertyName = "MemberCardNo"
        DataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Info
        Me.colBPMemberCardNo.DefaultCellStyle = DataGridViewCellStyle59
        Me.colBPMemberCardNo.HeaderText = "Member Card No"
        Me.colBPMemberCardNo.Name = "colBPMemberCardNo"
        Me.colBPMemberCardNo.ReadOnly = True
        '
        'colBPBillCustomerName
        '
        DataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Info
        Me.colBPBillCustomerName.DefaultCellStyle = DataGridViewCellStyle60
        Me.colBPBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colBPBillCustomerName.Name = "colBPBillCustomerName"
        Me.colBPBillCustomerName.ReadOnly = True
        Me.colBPBillCustomerName.Width = 120
        '
        'colBPCoPayType
        '
        Me.colBPCoPayType.DataPropertyName = "CoPayType"
        DataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Info
        Me.colBPCoPayType.DefaultCellStyle = DataGridViewCellStyle61
        Me.colBPCoPayType.HeaderText = "Co-Pay Type"
        Me.colBPCoPayType.Name = "colBPCoPayType"
        Me.colBPCoPayType.ReadOnly = True
        Me.colBPCoPayType.Width = 80
        '
        'colBPCoPayPercent
        '
        Me.colBPCoPayPercent.DataPropertyName = "CoPayPercent"
        DataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle62.Format = "N2"
        DataGridViewCellStyle62.NullValue = Nothing
        Me.colBPCoPayPercent.DefaultCellStyle = DataGridViewCellStyle62
        Me.colBPCoPayPercent.HeaderText = "Co-Pay Percent"
        Me.colBPCoPayPercent.Name = "colBPCoPayPercent"
        Me.colBPCoPayPercent.ReadOnly = True
        '
        'colBPCoPayValue
        '
        Me.colBPCoPayValue.DataPropertyName = "CoPayValue"
        DataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle63.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle63.Format = "N2"
        DataGridViewCellStyle63.NullValue = Nothing
        Me.colBPCoPayValue.DefaultCellStyle = DataGridViewCellStyle63
        Me.colBPCoPayValue.HeaderText = "Co-Pay Value"
        Me.colBPCoPayValue.Name = "colBPCoPayValue"
        Me.colBPCoPayValue.ReadOnly = True
        Me.colBPCoPayValue.Width = 80
        '
        'colBPItemCategoryID
        '
        DataGridViewCellStyle64.BackColor = System.Drawing.SystemColors.Info
        Me.colBPItemCategoryID.DefaultCellStyle = DataGridViewCellStyle64
        Me.colBPItemCategoryID.HeaderText = "Item Category ID"
        Me.colBPItemCategoryID.Name = "colBPItemCategoryID"
        Me.colBPItemCategoryID.ReadOnly = True
        Me.colBPItemCategoryID.Visible = False
        '
        'stbBPBillCustomerName
        '
        Me.stbBPBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBPBillCustomerName.EntryErrorMSG = ""
        Me.stbBPBillCustomerName.Location = New System.Drawing.Point(156, 55)
        Me.stbBPBillCustomerName.MaxLength = 41
        Me.stbBPBillCustomerName.Multiline = True
        Me.stbBPBillCustomerName.Name = "stbBPBillCustomerName"
        Me.stbBPBillCustomerName.ReadOnly = True
        Me.stbBPBillCustomerName.RegularExpression = ""
        Me.stbBPBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPBillCustomerName.Size = New System.Drawing.Size(157, 34)
        Me.stbBPBillCustomerName.TabIndex = 5
        '
        'cboBPBillAccountNo
        '
        Me.cboBPBillAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBPBillAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBPBillAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboBPBillAccountNo.DropDownWidth = 276
        Me.cboBPBillAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBPBillAccountNo.FormattingEnabled = True
        Me.cboBPBillAccountNo.ItemHeight = 13
        Me.cboBPBillAccountNo.Location = New System.Drawing.Point(156, 29)
        Me.cboBPBillAccountNo.Name = "cboBPBillAccountNo"
        Me.cboBPBillAccountNo.Size = New System.Drawing.Size(157, 21)
        Me.cboBPBillAccountNo.TabIndex = 3
        '
        'lblBPBillCustomerName
        '
        Me.lblBPBillCustomerName.Location = New System.Drawing.Point(7, 62)
        Me.lblBPBillCustomerName.Name = "lblBPBillCustomerName"
        Me.lblBPBillCustomerName.Size = New System.Drawing.Size(143, 18)
        Me.lblBPBillCustomerName.TabIndex = 4
        Me.lblBPBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblBPBillAccountNo
        '
        Me.lblBPBillAccountNo.Location = New System.Drawing.Point(7, 32)
        Me.lblBPBillAccountNo.Name = "lblBPBillAccountNo"
        Me.lblBPBillAccountNo.Size = New System.Drawing.Size(143, 18)
        Me.lblBPBillAccountNo.TabIndex = 2
        Me.lblBPBillAccountNo.Text = "To-Bill Account Number"
        '
        'tpgCreditBillFormPayment
        '
        Me.tpgCreditBillFormPayment.Controls.Add(Me.nbxCBFPGrandDiscount)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPGrandDiscount)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.nbxCBFPWithholdingTax)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPWithholdingTax)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.btnCBFFindVisitNoByInvoiceNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.btnCBFPExchangeRate)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.grpCBFPExtraBillItems)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.btnCBFPFindVisitNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPVisitNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPCompanyName)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.cboCBFPCompanyNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPCompanyName)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPCompanyNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.chkCBFPUseAccountBalance)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.chkCBFPSendBalanceToAccount)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPChange)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPChange)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.nbxCBFPAmountTendered)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.nbxCBFPExchangeRate)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPAmountTendered)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPExchangeRate)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.cboCBFPCurrenciesID)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPCurrenciesID)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.cboCBFPBillModesID)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPBillModesID)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.grpCBFPSetParameters)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPReceiptNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPReceiptNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPAmountWords)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPAmountWords)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPAccountBalance)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPBalance)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.cboCBFPPayModesID)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPPayModes)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPVisitNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPTotalBill)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPTotalAmountPaid)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPChequeNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPDocumentNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPNotes)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPNotes)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.stbCBFPBillCustomerName)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.cboCBFPBillAccountNo)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPBillCustomerName)
        Me.tpgCreditBillFormPayment.Controls.Add(Me.lblCBFPBillAccountNo)
        Me.tpgCreditBillFormPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgCreditBillFormPayment.Name = "tpgCreditBillFormPayment"
        Me.tpgCreditBillFormPayment.Size = New System.Drawing.Size(894, 482)
        Me.tpgCreditBillFormPayment.TabIndex = 7
        Me.tpgCreditBillFormPayment.Tag = "CreditBillFormPayment"
        Me.tpgCreditBillFormPayment.Text = "Credit Bill Form Payment"
        Me.tpgCreditBillFormPayment.UseVisualStyleBackColor = True
        '
        'nbxCBFPGrandDiscount
        '
        Me.nbxCBFPGrandDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCBFPGrandDiscount.ControlCaption = "Grand Discount"
        Me.nbxCBFPGrandDiscount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCBFPGrandDiscount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCBFPGrandDiscount.DecimalPlaces = -1
        Me.nbxCBFPGrandDiscount.DenyNegativeEntryValue = True
        Me.nbxCBFPGrandDiscount.Location = New System.Drawing.Point(445, 157)
        Me.nbxCBFPGrandDiscount.MaxValue = 0.0R
        Me.nbxCBFPGrandDiscount.MinValue = 0.0R
        Me.nbxCBFPGrandDiscount.MustEnterNumeric = True
        Me.nbxCBFPGrandDiscount.Name = "nbxCBFPGrandDiscount"
        Me.nbxCBFPGrandDiscount.Size = New System.Drawing.Size(166, 20)
        Me.nbxCBFPGrandDiscount.TabIndex = 28
        Me.nbxCBFPGrandDiscount.Value = ""
        '
        'lblCBFPGrandDiscount
        '
        Me.lblCBFPGrandDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCBFPGrandDiscount.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCBFPGrandDiscount.Location = New System.Drawing.Point(320, 157)
        Me.lblCBFPGrandDiscount.Name = "lblCBFPGrandDiscount"
        Me.lblCBFPGrandDiscount.Size = New System.Drawing.Size(119, 18)
        Me.lblCBFPGrandDiscount.TabIndex = 27
        Me.lblCBFPGrandDiscount.Text = "Grand Discount"
        '
        'nbxCBFPWithholdingTax
        '
        Me.nbxCBFPWithholdingTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCBFPWithholdingTax.ControlCaption = "Withholding Tax"
        Me.nbxCBFPWithholdingTax.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCBFPWithholdingTax.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCBFPWithholdingTax.DecimalPlaces = -1
        Me.nbxCBFPWithholdingTax.DenyNegativeEntryValue = True
        Me.nbxCBFPWithholdingTax.Location = New System.Drawing.Point(445, 135)
        Me.nbxCBFPWithholdingTax.MaxValue = 0.0R
        Me.nbxCBFPWithholdingTax.MinValue = 0.0R
        Me.nbxCBFPWithholdingTax.MustEnterNumeric = True
        Me.nbxCBFPWithholdingTax.Name = "nbxCBFPWithholdingTax"
        Me.nbxCBFPWithholdingTax.Size = New System.Drawing.Size(166, 20)
        Me.nbxCBFPWithholdingTax.TabIndex = 26
        Me.nbxCBFPWithholdingTax.Value = ""
        '
        'lblCBFPWithholdingTax
        '
        Me.lblCBFPWithholdingTax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCBFPWithholdingTax.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCBFPWithholdingTax.Location = New System.Drawing.Point(321, 135)
        Me.lblCBFPWithholdingTax.Name = "lblCBFPWithholdingTax"
        Me.lblCBFPWithholdingTax.Size = New System.Drawing.Size(116, 18)
        Me.lblCBFPWithholdingTax.TabIndex = 25
        Me.lblCBFPWithholdingTax.Text = "Withholding Tax"
        '
        'btnCBFFindVisitNoByInvoiceNo
        '
        Me.btnCBFFindVisitNoByInvoiceNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnCBFFindVisitNoByInvoiceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCBFFindVisitNoByInvoiceNo.Image = CType(resources.GetObject("btnCBFFindVisitNoByInvoiceNo.Image"), System.Drawing.Image)
        Me.btnCBFFindVisitNoByInvoiceNo.Location = New System.Drawing.Point(286, 149)
        Me.btnCBFFindVisitNoByInvoiceNo.Name = "btnCBFFindVisitNoByInvoiceNo"
        Me.btnCBFFindVisitNoByInvoiceNo.Size = New System.Drawing.Size(27, 21)
        Me.btnCBFFindVisitNoByInvoiceNo.TabIndex = 13
        '
        'btnCBFPExchangeRate
        '
        Me.btnCBFPExchangeRate.Enabled = False
        Me.btnCBFPExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnCBFPExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCBFPExchangeRate.Image = CType(resources.GetObject("btnCBFPExchangeRate.Image"), System.Drawing.Image)
        Me.btnCBFPExchangeRate.Location = New System.Drawing.Point(414, 196)
        Me.btnCBFPExchangeRate.Name = "btnCBFPExchangeRate"
        Me.btnCBFPExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnCBFPExchangeRate.TabIndex = 32
        Me.btnCBFPExchangeRate.Tag = "ExchangeRates"
        '
        'grpCBFPExtraBillItems
        '
        Me.grpCBFPExtraBillItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpCBFPExtraBillItems.Controls.Add(Me.dgvCBFPExtraBillItems)
        Me.grpCBFPExtraBillItems.Location = New System.Drawing.Point(4, 276)
        Me.grpCBFPExtraBillItems.Name = "grpCBFPExtraBillItems"
        Me.grpCBFPExtraBillItems.Size = New System.Drawing.Size(875, 203)
        Me.grpCBFPExtraBillItems.TabIndex = 21
        Me.grpCBFPExtraBillItems.TabStop = False
        Me.grpCBFPExtraBillItems.Text = "Credit Bill Form Payment Details"
        '
        'dgvCBFPExtraBillItems
        '
        Me.dgvCBFPExtraBillItems.AllowUserToAddRows = False
        Me.dgvCBFPExtraBillItems.AllowUserToDeleteRows = False
        Me.dgvCBFPExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvCBFPExtraBillItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCBFPExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvCBFPExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCBFPExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle67.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCBFPExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle67
        Me.dgvCBFPExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCBFPInclude, Me.colCBFPPatientNo, Me.colCBFPVisitNo, Me.colCBFPInvoiceNo, Me.colCBFPVisitDate, Me.colCBFPFullName, Me.colCBFPExtraBillNo, Me.colCBFPExtraBillDate, Me.colCBFPItemCode, Me.colCBFPItemName, Me.colCBFPCategory, Me.colCBFPQuantity, Me.colCBFPUnitPrice, Me.colCBFPBillPrice, Me.colCBFPDiscount, Me.colCBFPAmount, Me.colCBFPInvoiceAmount, Me.colCBFPEntryMode, Me.colCBFPMemberCardNo, Me.colCBFPBillCustomerName, Me.colCBFPCoPayType, Me.colCBFPCoPayPercent, Me.colCBFPCoPayValue, Me.colCBFPCashAmount, Me.colCBFPRoundNo, Me.colCBFPItemCategoryID})
        Me.dgvCBFPExtraBillItems.ContextMenuStrip = Me.cmsPayments
        DataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle90.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle90.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle90.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle90.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle90.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCBFPExtraBillItems.DefaultCellStyle = DataGridViewCellStyle90
        Me.dgvCBFPExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvCBFPExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvCBFPExtraBillItems.Location = New System.Drawing.Point(3, 16)
        Me.dgvCBFPExtraBillItems.Name = "dgvCBFPExtraBillItems"
        Me.dgvCBFPExtraBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle91.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle91.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle91.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle91.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle91.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle91.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCBFPExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle91
        Me.dgvCBFPExtraBillItems.RowHeadersVisible = False
        Me.dgvCBFPExtraBillItems.Size = New System.Drawing.Size(869, 184)
        Me.dgvCBFPExtraBillItems.TabIndex = 0
        Me.dgvCBFPExtraBillItems.Text = "DataGridView1"
        '
        'colCBFPInclude
        '
        Me.colCBFPInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCBFPInclude.HeaderText = "Include"
        Me.colCBFPInclude.Name = "colCBFPInclude"
        Me.colCBFPInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colCBFPInclude.Width = 50
        '
        'colCBFPPatientNo
        '
        DataGridViewCellStyle68.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPPatientNo.DefaultCellStyle = DataGridViewCellStyle68
        Me.colCBFPPatientNo.HeaderText = "Patient No"
        Me.colCBFPPatientNo.Name = "colCBFPPatientNo"
        Me.colCBFPPatientNo.ReadOnly = True
        Me.colCBFPPatientNo.Width = 70
        '
        'colCBFPVisitNo
        '
        DataGridViewCellStyle69.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPVisitNo.DefaultCellStyle = DataGridViewCellStyle69
        Me.colCBFPVisitNo.HeaderText = "Visit No"
        Me.colCBFPVisitNo.Name = "colCBFPVisitNo"
        Me.colCBFPVisitNo.ReadOnly = True
        Me.colCBFPVisitNo.Width = 75
        '
        'colCBFPInvoiceNo
        '
        DataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPInvoiceNo.DefaultCellStyle = DataGridViewCellStyle70
        Me.colCBFPInvoiceNo.HeaderText = "Invoice No"
        Me.colCBFPInvoiceNo.Name = "colCBFPInvoiceNo"
        Me.colCBFPInvoiceNo.ReadOnly = True
        '
        'colCBFPVisitDate
        '
        DataGridViewCellStyle71.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPVisitDate.DefaultCellStyle = DataGridViewCellStyle71
        Me.colCBFPVisitDate.HeaderText = "Visit Date"
        Me.colCBFPVisitDate.Name = "colCBFPVisitDate"
        Me.colCBFPVisitDate.ReadOnly = True
        Me.colCBFPVisitDate.Width = 70
        '
        'colCBFPFullName
        '
        DataGridViewCellStyle72.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPFullName.DefaultCellStyle = DataGridViewCellStyle72
        Me.colCBFPFullName.HeaderText = "Full Name"
        Me.colCBFPFullName.Name = "colCBFPFullName"
        Me.colCBFPFullName.ReadOnly = True
        Me.colCBFPFullName.Width = 80
        '
        'colCBFPExtraBillNo
        '
        DataGridViewCellStyle73.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPExtraBillNo.DefaultCellStyle = DataGridViewCellStyle73
        Me.colCBFPExtraBillNo.HeaderText = "Bill No"
        Me.colCBFPExtraBillNo.Name = "colCBFPExtraBillNo"
        Me.colCBFPExtraBillNo.ReadOnly = True
        Me.colCBFPExtraBillNo.Width = 80
        '
        'colCBFPExtraBillDate
        '
        DataGridViewCellStyle74.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPExtraBillDate.DefaultCellStyle = DataGridViewCellStyle74
        Me.colCBFPExtraBillDate.HeaderText = "Bill Date"
        Me.colCBFPExtraBillDate.Name = "colCBFPExtraBillDate"
        Me.colCBFPExtraBillDate.ReadOnly = True
        Me.colCBFPExtraBillDate.Width = 90
        '
        'colCBFPItemCode
        '
        DataGridViewCellStyle75.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle75.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCBFPItemCode.DefaultCellStyle = DataGridViewCellStyle75
        Me.colCBFPItemCode.HeaderText = "Item Code"
        Me.colCBFPItemCode.Name = "colCBFPItemCode"
        Me.colCBFPItemCode.ReadOnly = True
        Me.colCBFPItemCode.Width = 60
        '
        'colCBFPItemName
        '
        DataGridViewCellStyle76.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle76.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCBFPItemName.DefaultCellStyle = DataGridViewCellStyle76
        Me.colCBFPItemName.HeaderText = "Item Name"
        Me.colCBFPItemName.Name = "colCBFPItemName"
        Me.colCBFPItemName.ReadOnly = True
        Me.colCBFPItemName.Width = 120
        '
        'colCBFPCategory
        '
        DataGridViewCellStyle77.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle77.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCBFPCategory.DefaultCellStyle = DataGridViewCellStyle77
        Me.colCBFPCategory.HeaderText = "Category"
        Me.colCBFPCategory.Name = "colCBFPCategory"
        Me.colCBFPCategory.ReadOnly = True
        Me.colCBFPCategory.Width = 70
        '
        'colCBFPQuantity
        '
        DataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle78.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle78.Format = "N0"
        DataGridViewCellStyle78.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle78.NullValue = Nothing
        Me.colCBFPQuantity.DefaultCellStyle = DataGridViewCellStyle78
        Me.colCBFPQuantity.HeaderText = "Quantity"
        Me.colCBFPQuantity.Name = "colCBFPQuantity"
        Me.colCBFPQuantity.ReadOnly = True
        Me.colCBFPQuantity.Width = 60
        '
        'colCBFPUnitPrice
        '
        DataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle79.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle79.Format = "N2"
        DataGridViewCellStyle79.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle79.NullValue = Nothing
        Me.colCBFPUnitPrice.DefaultCellStyle = DataGridViewCellStyle79
        Me.colCBFPUnitPrice.HeaderText = "Unit Price"
        Me.colCBFPUnitPrice.Name = "colCBFPUnitPrice"
        Me.colCBFPUnitPrice.ReadOnly = True
        Me.colCBFPUnitPrice.Width = 80
        '
        'colCBFPBillPrice
        '
        Me.colCBFPBillPrice.HeaderText = "Bill Price"
        Me.colCBFPBillPrice.Name = "colCBFPBillPrice"
        Me.colCBFPBillPrice.ReadOnly = True
        Me.colCBFPBillPrice.Visible = False
        '
        'colCBFPDiscount
        '
        DataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle80.Format = "N2"
        DataGridViewCellStyle80.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle80.NullValue = Nothing
        Me.colCBFPDiscount.DefaultCellStyle = DataGridViewCellStyle80
        Me.colCBFPDiscount.HeaderText = "Discount"
        Me.colCBFPDiscount.Name = "colCBFPDiscount"
        Me.colCBFPDiscount.Width = 70
        '
        'colCBFPAmount
        '
        DataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle81.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle81.Format = "N2"
        DataGridViewCellStyle81.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle81.NullValue = Nothing
        Me.colCBFPAmount.DefaultCellStyle = DataGridViewCellStyle81
        Me.colCBFPAmount.HeaderText = "Amount"
        Me.colCBFPAmount.Name = "colCBFPAmount"
        Me.colCBFPAmount.ReadOnly = True
        Me.colCBFPAmount.Width = 80
        '
        'colCBFPInvoiceAmount
        '
        Me.colCBFPInvoiceAmount.HeaderText = "Invoice Amount"
        Me.colCBFPInvoiceAmount.Name = "colCBFPInvoiceAmount"
        Me.colCBFPInvoiceAmount.ReadOnly = True
        '
        'colCBFPEntryMode
        '
        DataGridViewCellStyle82.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPEntryMode.DefaultCellStyle = DataGridViewCellStyle82
        Me.colCBFPEntryMode.HeaderText = "Entry Mode"
        Me.colCBFPEntryMode.Name = "colCBFPEntryMode"
        Me.colCBFPEntryMode.ReadOnly = True
        Me.colCBFPEntryMode.Width = 80
        '
        'colCBFPMemberCardNo
        '
        DataGridViewCellStyle83.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPMemberCardNo.DefaultCellStyle = DataGridViewCellStyle83
        Me.colCBFPMemberCardNo.HeaderText = "Member Card No"
        Me.colCBFPMemberCardNo.Name = "colCBFPMemberCardNo"
        Me.colCBFPMemberCardNo.ReadOnly = True
        '
        'colCBFPBillCustomerName
        '
        DataGridViewCellStyle84.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPBillCustomerName.DefaultCellStyle = DataGridViewCellStyle84
        Me.colCBFPBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colCBFPBillCustomerName.Name = "colCBFPBillCustomerName"
        Me.colCBFPBillCustomerName.ReadOnly = True
        Me.colCBFPBillCustomerName.Width = 120
        '
        'colCBFPCoPayType
        '
        DataGridViewCellStyle85.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPCoPayType.DefaultCellStyle = DataGridViewCellStyle85
        Me.colCBFPCoPayType.HeaderText = "Co-Pay Type"
        Me.colCBFPCoPayType.Name = "colCBFPCoPayType"
        Me.colCBFPCoPayType.ReadOnly = True
        Me.colCBFPCoPayType.Width = 80
        '
        'colCBFPCoPayPercent
        '
        DataGridViewCellStyle86.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPCoPayPercent.DefaultCellStyle = DataGridViewCellStyle86
        Me.colCBFPCoPayPercent.HeaderText = "Co-Pay Percent"
        Me.colCBFPCoPayPercent.Name = "colCBFPCoPayPercent"
        Me.colCBFPCoPayPercent.ReadOnly = True
        '
        'colCBFPCoPayValue
        '
        DataGridViewCellStyle87.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPCoPayValue.DefaultCellStyle = DataGridViewCellStyle87
        Me.colCBFPCoPayValue.HeaderText = "Co-Pay Value"
        Me.colCBFPCoPayValue.Name = "colCBFPCoPayValue"
        Me.colCBFPCoPayValue.ReadOnly = True
        Me.colCBFPCoPayValue.Width = 80
        '
        'colCBFPCashAmount
        '
        DataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle88.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle88.Format = "N2"
        Me.colCBFPCashAmount.DefaultCellStyle = DataGridViewCellStyle88
        Me.colCBFPCashAmount.HeaderText = "Cash Amount"
        Me.colCBFPCashAmount.Name = "colCBFPCashAmount"
        Me.colCBFPCashAmount.ReadOnly = True
        Me.colCBFPCashAmount.Visible = False
        '
        'colCBFPRoundNo
        '
        DataGridViewCellStyle89.BackColor = System.Drawing.SystemColors.Info
        Me.colCBFPRoundNo.DefaultCellStyle = DataGridViewCellStyle89
        Me.colCBFPRoundNo.HeaderText = "Round No"
        Me.colCBFPRoundNo.Name = "colCBFPRoundNo"
        Me.colCBFPRoundNo.ReadOnly = True
        Me.colCBFPRoundNo.Visible = False
        '
        'colCBFPItemCategoryID
        '
        Me.colCBFPItemCategoryID.HeaderText = "Item Category ID"
        Me.colCBFPItemCategoryID.Name = "colCBFPItemCategoryID"
        Me.colCBFPItemCategoryID.ReadOnly = True
        Me.colCBFPItemCategoryID.Visible = False
        '
        'btnCBFPFindVisitNo
        '
        Me.btnCBFPFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnCBFPFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCBFPFindVisitNo.Image = CType(resources.GetObject("btnCBFPFindVisitNo.Image"), System.Drawing.Image)
        Me.btnCBFPFindVisitNo.Location = New System.Drawing.Point(121, 147)
        Me.btnCBFPFindVisitNo.Name = "btnCBFPFindVisitNo"
        Me.btnCBFPFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnCBFPFindVisitNo.TabIndex = 11
        '
        'stbCBFPVisitNo
        '
        Me.stbCBFPVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPVisitNo.CapitalizeFirstLetter = False
        Me.stbCBFPVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbCBFPVisitNo.EntryErrorMSG = ""
        Me.stbCBFPVisitNo.Location = New System.Drawing.Point(156, 149)
        Me.stbCBFPVisitNo.MaxLength = 20
        Me.stbCBFPVisitNo.Name = "stbCBFPVisitNo"
        Me.stbCBFPVisitNo.RegularExpression = ""
        Me.stbCBFPVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.stbCBFPVisitNo.TabIndex = 12
        '
        'stbCBFPCompanyName
        '
        Me.stbCBFPCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPCompanyName.CapitalizeFirstLetter = True
        Me.stbCBFPCompanyName.Enabled = False
        Me.stbCBFPCompanyName.EntryErrorMSG = ""
        Me.stbCBFPCompanyName.Location = New System.Drawing.Point(156, 114)
        Me.stbCBFPCompanyName.MaxLength = 60
        Me.stbCBFPCompanyName.Multiline = True
        Me.stbCBFPCompanyName.Name = "stbCBFPCompanyName"
        Me.stbCBFPCompanyName.ReadOnly = True
        Me.stbCBFPCompanyName.RegularExpression = ""
        Me.stbCBFPCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCBFPCompanyName.Size = New System.Drawing.Size(157, 34)
        Me.stbCBFPCompanyName.TabIndex = 9
        '
        'cboCBFPCompanyNo
        '
        Me.cboCBFPCompanyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCBFPCompanyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCBFPCompanyNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboCBFPCompanyNo.DropDownWidth = 256
        Me.cboCBFPCompanyNo.Enabled = False
        Me.cboCBFPCompanyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCBFPCompanyNo.FormattingEnabled = True
        Me.cboCBFPCompanyNo.ItemHeight = 13
        Me.cboCBFPCompanyNo.Location = New System.Drawing.Point(156, 91)
        Me.cboCBFPCompanyNo.Name = "cboCBFPCompanyNo"
        Me.cboCBFPCompanyNo.Size = New System.Drawing.Size(157, 21)
        Me.cboCBFPCompanyNo.TabIndex = 7
        '
        'lblCBFPCompanyName
        '
        Me.lblCBFPCompanyName.Enabled = False
        Me.lblCBFPCompanyName.Location = New System.Drawing.Point(7, 121)
        Me.lblCBFPCompanyName.Name = "lblCBFPCompanyName"
        Me.lblCBFPCompanyName.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPCompanyName.TabIndex = 8
        Me.lblCBFPCompanyName.Text = "To-Bill Company Name"
        '
        'lblCBFPCompanyNo
        '
        Me.lblCBFPCompanyNo.Enabled = False
        Me.lblCBFPCompanyNo.Location = New System.Drawing.Point(7, 92)
        Me.lblCBFPCompanyNo.Name = "lblCBFPCompanyNo"
        Me.lblCBFPCompanyNo.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPCompanyNo.TabIndex = 6
        Me.lblCBFPCompanyNo.Text = "To-Bill Company Number"
        '
        'chkCBFPUseAccountBalance
        '
        Me.chkCBFPUseAccountBalance.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCBFPUseAccountBalance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCBFPUseAccountBalance.Location = New System.Drawing.Point(627, 227)
        Me.chkCBFPUseAccountBalance.Name = "chkCBFPUseAccountBalance"
        Me.chkCBFPUseAccountBalance.Size = New System.Drawing.Size(143, 18)
        Me.chkCBFPUseAccountBalance.TabIndex = 43
        Me.chkCBFPUseAccountBalance.Text = "Use Account Balance"
        '
        'chkCBFPSendBalanceToAccount
        '
        Me.chkCBFPSendBalanceToAccount.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCBFPSendBalanceToAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCBFPSendBalanceToAccount.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkCBFPSendBalanceToAccount.Location = New System.Drawing.Point(319, 241)
        Me.chkCBFPSendBalanceToAccount.Name = "chkCBFPSendBalanceToAccount"
        Me.chkCBFPSendBalanceToAccount.Size = New System.Drawing.Size(292, 20)
        Me.chkCBFPSendBalanceToAccount.TabIndex = 36
        Me.chkCBFPSendBalanceToAccount.Text = "Send Balance To Account"
        '
        'stbCBFPChange
        '
        Me.stbCBFPChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbCBFPChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPChange.CapitalizeFirstLetter = False
        Me.stbCBFPChange.Enabled = False
        Me.stbCBFPChange.EntryErrorMSG = ""
        Me.stbCBFPChange.Location = New System.Drawing.Point(445, 218)
        Me.stbCBFPChange.MaxLength = 20
        Me.stbCBFPChange.Name = "stbCBFPChange"
        Me.stbCBFPChange.RegularExpression = ""
        Me.stbCBFPChange.Size = New System.Drawing.Size(166, 20)
        Me.stbCBFPChange.TabIndex = 35
        Me.stbCBFPChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCBFPChange
        '
        Me.lblCBFPChange.Location = New System.Drawing.Point(319, 220)
        Me.lblCBFPChange.Name = "lblCBFPChange"
        Me.lblCBFPChange.Size = New System.Drawing.Size(98, 18)
        Me.lblCBFPChange.TabIndex = 34
        Me.lblCBFPChange.Text = "Change"
        '
        'nbxCBFPAmountTendered
        '
        Me.nbxCBFPAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCBFPAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxCBFPAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCBFPAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCBFPAmountTendered.DecimalPlaces = -1
        Me.nbxCBFPAmountTendered.DenyNegativeEntryValue = True
        Me.nbxCBFPAmountTendered.Location = New System.Drawing.Point(445, 176)
        Me.nbxCBFPAmountTendered.MaxValue = 0.0R
        Me.nbxCBFPAmountTendered.MinValue = 0.0R
        Me.nbxCBFPAmountTendered.MustEnterNumeric = True
        Me.nbxCBFPAmountTendered.Name = "nbxCBFPAmountTendered"
        Me.nbxCBFPAmountTendered.Size = New System.Drawing.Size(166, 20)
        Me.nbxCBFPAmountTendered.TabIndex = 30
        Me.nbxCBFPAmountTendered.Value = ""
        '
        'nbxCBFPExchangeRate
        '
        Me.nbxCBFPExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCBFPExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxCBFPExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCBFPExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCBFPExchangeRate.DecimalPlaces = -1
        Me.nbxCBFPExchangeRate.DenyZeroEntryValue = True
        Me.nbxCBFPExchangeRate.Location = New System.Drawing.Point(445, 197)
        Me.nbxCBFPExchangeRate.MaxValue = 0.0R
        Me.nbxCBFPExchangeRate.MinValue = 0.0R
        Me.nbxCBFPExchangeRate.MustEnterNumeric = True
        Me.nbxCBFPExchangeRate.Name = "nbxCBFPExchangeRate"
        Me.nbxCBFPExchangeRate.Size = New System.Drawing.Size(166, 20)
        Me.nbxCBFPExchangeRate.TabIndex = 33
        Me.nbxCBFPExchangeRate.Value = ""
        '
        'lblCBFPAmountTendered
        '
        Me.lblCBFPAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCBFPAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCBFPAmountTendered.Location = New System.Drawing.Point(319, 176)
        Me.lblCBFPAmountTendered.Name = "lblCBFPAmountTendered"
        Me.lblCBFPAmountTendered.Size = New System.Drawing.Size(98, 18)
        Me.lblCBFPAmountTendered.TabIndex = 29
        Me.lblCBFPAmountTendered.Text = "Amount Tendered"
        '
        'lblCBFPExchangeRate
        '
        Me.lblCBFPExchangeRate.Location = New System.Drawing.Point(319, 198)
        Me.lblCBFPExchangeRate.Name = "lblCBFPExchangeRate"
        Me.lblCBFPExchangeRate.Size = New System.Drawing.Size(89, 18)
        Me.lblCBFPExchangeRate.TabIndex = 31
        Me.lblCBFPExchangeRate.Text = "Exchange Rate"
        '
        'cboCBFPCurrenciesID
        '
        Me.cboCBFPCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBFPCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCBFPCurrenciesID.FormattingEnabled = True
        Me.cboCBFPCurrenciesID.ItemHeight = 13
        Me.cboCBFPCurrenciesID.Location = New System.Drawing.Point(156, 215)
        Me.cboCBFPCurrenciesID.Name = "cboCBFPCurrenciesID"
        Me.cboCBFPCurrenciesID.Size = New System.Drawing.Size(157, 21)
        Me.cboCBFPCurrenciesID.TabIndex = 19
        '
        'lblCBFPCurrenciesID
        '
        Me.lblCBFPCurrenciesID.Location = New System.Drawing.Point(7, 217)
        Me.lblCBFPCurrenciesID.Name = "lblCBFPCurrenciesID"
        Me.lblCBFPCurrenciesID.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPCurrenciesID.TabIndex = 18
        Me.lblCBFPCurrenciesID.Text = "Pay in Currency"
        '
        'cboCBFPBillModesID
        '
        Me.cboCBFPBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCBFPBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCBFPBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBFPBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCBFPBillModesID.FormattingEnabled = True
        Me.cboCBFPBillModesID.ItemHeight = 13
        Me.cboCBFPBillModesID.Location = New System.Drawing.Point(156, 6)
        Me.cboCBFPBillModesID.Name = "cboCBFPBillModesID"
        Me.cboCBFPBillModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboCBFPBillModesID.TabIndex = 1
        '
        'lblCBFPBillModesID
        '
        Me.lblCBFPBillModesID.Location = New System.Drawing.Point(7, 9)
        Me.lblCBFPBillModesID.Name = "lblCBFPBillModesID"
        Me.lblCBFPBillModesID.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPBillModesID.TabIndex = 0
        Me.lblCBFPBillModesID.Text = "To-Bill Account Category"
        '
        'grpCBFPSetParameters
        '
        Me.grpCBFPSetParameters.Controls.Add(Me.chkCBFPExcludeNotInvoicedItem)
        Me.grpCBFPSetParameters.Controls.Add(Me.pnlCBFPPeriod)
        Me.grpCBFPSetParameters.Controls.Add(Me.fbnCBFPExportTo)
        Me.grpCBFPSetParameters.Controls.Add(Me.btnCBFPLoadPendingBillsPayment)
        Me.grpCBFPSetParameters.Controls.Add(Me.lblCBFPRecordsNo)
        Me.grpCBFPSetParameters.Controls.Add(Me.rdoCBFPGetPeriod)
        Me.grpCBFPSetParameters.Controls.Add(Me.rdoCBFPGetAll)
        Me.grpCBFPSetParameters.Location = New System.Drawing.Point(319, 5)
        Me.grpCBFPSetParameters.Name = "grpCBFPSetParameters"
        Me.grpCBFPSetParameters.Size = New System.Drawing.Size(535, 103)
        Me.grpCBFPSetParameters.TabIndex = 22
        Me.grpCBFPSetParameters.TabStop = False
        Me.grpCBFPSetParameters.Text = "Visit Period"
        '
        'chkCBFPExcludeNotInvoicedItem
        '
        Me.chkCBFPExcludeNotInvoicedItem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCBFPExcludeNotInvoicedItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCBFPExcludeNotInvoicedItem.Location = New System.Drawing.Point(337, 50)
        Me.chkCBFPExcludeNotInvoicedItem.Name = "chkCBFPExcludeNotInvoicedItem"
        Me.chkCBFPExcludeNotInvoicedItem.Size = New System.Drawing.Size(192, 20)
        Me.chkCBFPExcludeNotInvoicedItem.TabIndex = 5
        Me.chkCBFPExcludeNotInvoicedItem.Text = "Exclude Non Invoiced Items"
        '
        'pnlCBFPPeriod
        '
        Me.pnlCBFPPeriod.Controls.Add(Me.dtpCBFPEndDate)
        Me.pnlCBFPPeriod.Controls.Add(Me.lblCBFPStartDate)
        Me.pnlCBFPPeriod.Controls.Add(Me.dtpCBFPStartDate)
        Me.pnlCBFPPeriod.Controls.Add(Me.lblCBFPEndDate)
        Me.pnlCBFPPeriod.Location = New System.Drawing.Point(5, 37)
        Me.pnlCBFPPeriod.Name = "pnlCBFPPeriod"
        Me.pnlCBFPPeriod.Size = New System.Drawing.Size(314, 53)
        Me.pnlCBFPPeriod.TabIndex = 3
        '
        'dtpCBFPEndDate
        '
        Me.dtpCBFPEndDate.Location = New System.Drawing.Point(121, 28)
        Me.dtpCBFPEndDate.Name = "dtpCBFPEndDate"
        Me.dtpCBFPEndDate.ShowCheckBox = True
        Me.dtpCBFPEndDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpCBFPEndDate.TabIndex = 3
        '
        'lblCBFPStartDate
        '
        Me.lblCBFPStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblCBFPStartDate.Name = "lblCBFPStartDate"
        Me.lblCBFPStartDate.Size = New System.Drawing.Size(83, 20)
        Me.lblCBFPStartDate.TabIndex = 0
        Me.lblCBFPStartDate.Text = "Start Date"
        Me.lblCBFPStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpCBFPStartDate
        '
        Me.dtpCBFPStartDate.Location = New System.Drawing.Point(121, 5)
        Me.dtpCBFPStartDate.Name = "dtpCBFPStartDate"
        Me.dtpCBFPStartDate.ShowCheckBox = True
        Me.dtpCBFPStartDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpCBFPStartDate.TabIndex = 1
        '
        'lblCBFPEndDate
        '
        Me.lblCBFPEndDate.Location = New System.Drawing.Point(10, 28)
        Me.lblCBFPEndDate.Name = "lblCBFPEndDate"
        Me.lblCBFPEndDate.Size = New System.Drawing.Size(83, 20)
        Me.lblCBFPEndDate.TabIndex = 2
        Me.lblCBFPEndDate.Text = "End Date"
        Me.lblCBFPEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnCBFPExportTo
        '
        Me.fbnCBFPExportTo.Enabled = False
        Me.fbnCBFPExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCBFPExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCBFPExportTo.Location = New System.Drawing.Point(423, 73)
        Me.fbnCBFPExportTo.Name = "fbnCBFPExportTo"
        Me.fbnCBFPExportTo.Size = New System.Drawing.Size(106, 24)
        Me.fbnCBFPExportTo.TabIndex = 0
        Me.fbnCBFPExportTo.Text = "Export to Excel..."
        '
        'btnCBFPLoadPendingBillsPayment
        '
        Me.btnCBFPLoadPendingBillsPayment.AccessibleDescription = ""
        Me.btnCBFPLoadPendingBillsPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnCBFPLoadPendingBillsPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCBFPLoadPendingBillsPayment.Location = New System.Drawing.Point(337, 73)
        Me.btnCBFPLoadPendingBillsPayment.Name = "btnCBFPLoadPendingBillsPayment"
        Me.btnCBFPLoadPendingBillsPayment.Size = New System.Drawing.Size(80, 24)
        Me.btnCBFPLoadPendingBillsPayment.TabIndex = 6
        Me.btnCBFPLoadPendingBillsPayment.Tag = ""
        Me.btnCBFPLoadPendingBillsPayment.Text = "&Load"
        '
        'lblCBFPRecordsNo
        '
        Me.lblCBFPRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCBFPRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblCBFPRecordsNo.Location = New System.Drawing.Point(337, 34)
        Me.lblCBFPRecordsNo.Name = "lblCBFPRecordsNo"
        Me.lblCBFPRecordsNo.Size = New System.Drawing.Size(192, 13)
        Me.lblCBFPRecordsNo.TabIndex = 4
        Me.lblCBFPRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdoCBFPGetPeriod
        '
        Me.rdoCBFPGetPeriod.Checked = True
        Me.rdoCBFPGetPeriod.Location = New System.Drawing.Point(10, 13)
        Me.rdoCBFPGetPeriod.Name = "rdoCBFPGetPeriod"
        Me.rdoCBFPGetPeriod.Size = New System.Drawing.Size(237, 20)
        Me.rdoCBFPGetPeriod.TabIndex = 0
        Me.rdoCBFPGetPeriod.TabStop = True
        Me.rdoCBFPGetPeriod.Text = "Get Pending Bills Payment for Set Period"
        '
        'rdoCBFPGetAll
        '
        Me.rdoCBFPGetAll.Location = New System.Drawing.Point(274, 14)
        Me.rdoCBFPGetAll.Name = "rdoCBFPGetAll"
        Me.rdoCBFPGetAll.Size = New System.Drawing.Size(177, 20)
        Me.rdoCBFPGetAll.TabIndex = 1
        Me.rdoCBFPGetAll.Text = "Get All Pending Bills Payment"
        '
        'lblCBFPReceiptNo
        '
        Me.lblCBFPReceiptNo.AccessibleDescription = ""
        Me.lblCBFPReceiptNo.Location = New System.Drawing.Point(7, 172)
        Me.lblCBFPReceiptNo.Name = "lblCBFPReceiptNo"
        Me.lblCBFPReceiptNo.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPReceiptNo.TabIndex = 14
        Me.lblCBFPReceiptNo.Text = "Receipt No"
        '
        'stbCBFPReceiptNo
        '
        Me.stbCBFPReceiptNo.AccessibleDescription = ""
        Me.stbCBFPReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPReceiptNo.CapitalizeFirstLetter = False
        Me.stbCBFPReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbCBFPReceiptNo.EntryErrorMSG = ""
        Me.stbCBFPReceiptNo.Location = New System.Drawing.Point(156, 170)
        Me.stbCBFPReceiptNo.MaxLength = 20
        Me.stbCBFPReceiptNo.Name = "stbCBFPReceiptNo"
        Me.stbCBFPReceiptNo.RegularExpression = ""
        Me.stbCBFPReceiptNo.Size = New System.Drawing.Size(157, 20)
        Me.stbCBFPReceiptNo.TabIndex = 15
        '
        'stbCBFPAmountWords
        '
        Me.stbCBFPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbCBFPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPAmountWords.CapitalizeFirstLetter = False
        Me.stbCBFPAmountWords.EntryErrorMSG = ""
        Me.stbCBFPAmountWords.Location = New System.Drawing.Point(620, 156)
        Me.stbCBFPAmountWords.MaxLength = 100
        Me.stbCBFPAmountWords.Multiline = True
        Me.stbCBFPAmountWords.Name = "stbCBFPAmountWords"
        Me.stbCBFPAmountWords.ReadOnly = True
        Me.stbCBFPAmountWords.RegularExpression = ""
        Me.stbCBFPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCBFPAmountWords.Size = New System.Drawing.Size(234, 34)
        Me.stbCBFPAmountWords.TabIndex = 40
        '
        'lblCBFPAmountWords
        '
        Me.lblCBFPAmountWords.Location = New System.Drawing.Point(617, 138)
        Me.lblCBFPAmountWords.Name = "lblCBFPAmountWords"
        Me.lblCBFPAmountWords.Size = New System.Drawing.Size(237, 21)
        Me.lblCBFPAmountWords.TabIndex = 39
        Me.lblCBFPAmountWords.Text = "Amount in Words"
        '
        'stbCBFPAccountBalance
        '
        Me.stbCBFPAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.stbCBFPAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPAccountBalance.CapitalizeFirstLetter = False
        Me.stbCBFPAccountBalance.Enabled = False
        Me.stbCBFPAccountBalance.EntryErrorMSG = ""
        Me.stbCBFPAccountBalance.Location = New System.Drawing.Point(720, 197)
        Me.stbCBFPAccountBalance.MaxLength = 20
        Me.stbCBFPAccountBalance.Name = "stbCBFPAccountBalance"
        Me.stbCBFPAccountBalance.RegularExpression = ""
        Me.stbCBFPAccountBalance.Size = New System.Drawing.Size(134, 20)
        Me.stbCBFPAccountBalance.TabIndex = 42
        Me.stbCBFPAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCBFPBalance
        '
        Me.lblCBFPBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCBFPBalance.Location = New System.Drawing.Point(617, 199)
        Me.lblCBFPBalance.Name = "lblCBFPBalance"
        Me.lblCBFPBalance.Size = New System.Drawing.Size(97, 18)
        Me.lblCBFPBalance.TabIndex = 41
        Me.lblCBFPBalance.Text = "Account Balance"
        Me.lblCBFPBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCBFPPayModesID
        '
        Me.cboCBFPPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCBFPPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCBFPPayModesID.FormattingEnabled = True
        Me.cboCBFPPayModesID.ItemHeight = 13
        Me.cboCBFPPayModesID.Location = New System.Drawing.Point(156, 193)
        Me.cboCBFPPayModesID.Name = "cboCBFPPayModesID"
        Me.cboCBFPPayModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboCBFPPayModesID.TabIndex = 17
        '
        'lblCBFPPayModes
        '
        Me.lblCBFPPayModes.Location = New System.Drawing.Point(7, 195)
        Me.lblCBFPPayModes.Name = "lblCBFPPayModes"
        Me.lblCBFPPayModes.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPPayModes.TabIndex = 16
        Me.lblCBFPPayModes.Text = "Mode of Payment"
        '
        'lblCBFPVisitNo
        '
        Me.lblCBFPVisitNo.Location = New System.Drawing.Point(7, 149)
        Me.lblCBFPVisitNo.Name = "lblCBFPVisitNo"
        Me.lblCBFPVisitNo.Size = New System.Drawing.Size(90, 18)
        Me.lblCBFPVisitNo.TabIndex = 10
        Me.lblCBFPVisitNo.Text = "Visit No"
        '
        'stbCBFPTotalBill
        '
        Me.stbCBFPTotalBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbCBFPTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPTotalBill.CapitalizeFirstLetter = False
        Me.stbCBFPTotalBill.Enabled = False
        Me.stbCBFPTotalBill.EntryErrorMSG = ""
        Me.stbCBFPTotalBill.Location = New System.Drawing.Point(720, 115)
        Me.stbCBFPTotalBill.MaxLength = 20
        Me.stbCBFPTotalBill.Name = "stbCBFPTotalBill"
        Me.stbCBFPTotalBill.RegularExpression = ""
        Me.stbCBFPTotalBill.Size = New System.Drawing.Size(134, 20)
        Me.stbCBFPTotalBill.TabIndex = 38
        Me.stbCBFPTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCBFPTotalAmountPaid
        '
        Me.lblCBFPTotalAmountPaid.Location = New System.Drawing.Point(617, 115)
        Me.lblCBFPTotalAmountPaid.Name = "lblCBFPTotalAmountPaid"
        Me.lblCBFPTotalAmountPaid.Size = New System.Drawing.Size(97, 18)
        Me.lblCBFPTotalAmountPaid.TabIndex = 37
        Me.lblCBFPTotalAmountPaid.Text = "Total Bill"
        '
        'lblCBFPChequeNo
        '
        Me.lblCBFPChequeNo.Location = New System.Drawing.Point(319, 114)
        Me.lblCBFPChequeNo.Name = "lblCBFPChequeNo"
        Me.lblCBFPChequeNo.Size = New System.Drawing.Size(98, 18)
        Me.lblCBFPChequeNo.TabIndex = 23
        Me.lblCBFPChequeNo.Text = "Document No."
        '
        'stbCBFPDocumentNo
        '
        Me.stbCBFPDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPDocumentNo.CapitalizeFirstLetter = False
        Me.stbCBFPDocumentNo.EntryErrorMSG = ""
        Me.stbCBFPDocumentNo.Location = New System.Drawing.Point(445, 112)
        Me.stbCBFPDocumentNo.MaxLength = 12
        Me.stbCBFPDocumentNo.Name = "stbCBFPDocumentNo"
        Me.stbCBFPDocumentNo.RegularExpression = ""
        Me.stbCBFPDocumentNo.Size = New System.Drawing.Size(166, 20)
        Me.stbCBFPDocumentNo.TabIndex = 24
        '
        'stbCBFPNotes
        '
        Me.stbCBFPNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPNotes.CapitalizeFirstLetter = True
        Me.stbCBFPNotes.EntryErrorMSG = ""
        Me.stbCBFPNotes.Location = New System.Drawing.Point(156, 240)
        Me.stbCBFPNotes.MaxLength = 100
        Me.stbCBFPNotes.Multiline = True
        Me.stbCBFPNotes.Name = "stbCBFPNotes"
        Me.stbCBFPNotes.RegularExpression = ""
        Me.stbCBFPNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCBFPNotes.Size = New System.Drawing.Size(155, 29)
        Me.stbCBFPNotes.TabIndex = 21
        '
        'lblCBFPNotes
        '
        Me.lblCBFPNotes.Location = New System.Drawing.Point(7, 241)
        Me.lblCBFPNotes.Name = "lblCBFPNotes"
        Me.lblCBFPNotes.Size = New System.Drawing.Size(98, 18)
        Me.lblCBFPNotes.TabIndex = 20
        Me.lblCBFPNotes.Text = "Notes"
        '
        'stbCBFPBillCustomerName
        '
        Me.stbCBFPBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCBFPBillCustomerName.CapitalizeFirstLetter = False
        Me.stbCBFPBillCustomerName.EntryErrorMSG = ""
        Me.stbCBFPBillCustomerName.Location = New System.Drawing.Point(156, 55)
        Me.stbCBFPBillCustomerName.MaxLength = 41
        Me.stbCBFPBillCustomerName.Multiline = True
        Me.stbCBFPBillCustomerName.Name = "stbCBFPBillCustomerName"
        Me.stbCBFPBillCustomerName.ReadOnly = True
        Me.stbCBFPBillCustomerName.RegularExpression = ""
        Me.stbCBFPBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCBFPBillCustomerName.Size = New System.Drawing.Size(157, 34)
        Me.stbCBFPBillCustomerName.TabIndex = 5
        '
        'cboCBFPBillAccountNo
        '
        Me.cboCBFPBillAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCBFPBillAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCBFPBillAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboCBFPBillAccountNo.DropDownWidth = 276
        Me.cboCBFPBillAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCBFPBillAccountNo.FormattingEnabled = True
        Me.cboCBFPBillAccountNo.ItemHeight = 13
        Me.cboCBFPBillAccountNo.Location = New System.Drawing.Point(156, 29)
        Me.cboCBFPBillAccountNo.Name = "cboCBFPBillAccountNo"
        Me.cboCBFPBillAccountNo.Size = New System.Drawing.Size(157, 21)
        Me.cboCBFPBillAccountNo.TabIndex = 3
        '
        'lblCBFPBillCustomerName
        '
        Me.lblCBFPBillCustomerName.Location = New System.Drawing.Point(7, 62)
        Me.lblCBFPBillCustomerName.Name = "lblCBFPBillCustomerName"
        Me.lblCBFPBillCustomerName.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPBillCustomerName.TabIndex = 4
        Me.lblCBFPBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblCBFPBillAccountNo
        '
        Me.lblCBFPBillAccountNo.Location = New System.Drawing.Point(7, 32)
        Me.lblCBFPBillAccountNo.Name = "lblCBFPBillAccountNo"
        Me.lblCBFPBillAccountNo.Size = New System.Drawing.Size(143, 18)
        Me.lblCBFPBillAccountNo.TabIndex = 2
        Me.lblCBFPBillAccountNo.Text = "To-Bill Account Number"
        '
        'tpgManageAccounts
        '
        Me.tpgManageAccounts.Controls.Add(Me.dtpTransactionDate)
        Me.tpgManageAccounts.Controls.Add(Me.Label1)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountPhone)
        Me.tpgManageAccounts.Controls.Add(Me.cboAccountGroupID)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountGroupID)
        Me.tpgManageAccounts.Controls.Add(Me.btnAccountExchangeRate)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountChange)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountChange)
        Me.tpgManageAccounts.Controls.Add(Me.nbxAccountAmountTendered)
        Me.tpgManageAccounts.Controls.Add(Me.nbxAccountExchangeRate)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountAmountTendered)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountExchangeRate)
        Me.tpgManageAccounts.Controls.Add(Me.cboAccountCurrenciesID)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountCurrenciesID)
        Me.tpgManageAccounts.Controls.Add(Me.cboAccountNo)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountTranNo)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountTranNo)
        Me.tpgManageAccounts.Controls.Add(Me.cboAccountActionID)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountActionID)
        Me.tpgManageAccounts.Controls.Add(Me.cboBillModesID)
        Me.tpgManageAccounts.Controls.Add(Me.lblBillModesID)
        Me.tpgManageAccounts.Controls.Add(Me.nbxAccountBalance)
        Me.tpgManageAccounts.Controls.Add(Me.nbxAccountAmount)
        Me.tpgManageAccounts.Controls.Add(Me.lblAmount)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountBalance)
        Me.tpgManageAccounts.Controls.Add(Me.cboAccountPayModesID)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountPayModes)
        Me.tpgManageAccounts.Controls.Add(Me.lblTransactionDate)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountDocumentNo)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountDocumentNo)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountNotes)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountNotes)
        Me.tpgManageAccounts.Controls.Add(Me.stbAccountName)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountName)
        Me.tpgManageAccounts.Controls.Add(Me.lblAccountNo)
        Me.tpgManageAccounts.Location = New System.Drawing.Point(4, 22)
        Me.tpgManageAccounts.Name = "tpgManageAccounts"
        Me.tpgManageAccounts.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgManageAccounts.Size = New System.Drawing.Size(894, 482)
        Me.tpgManageAccounts.TabIndex = 4
        Me.tpgManageAccounts.Tag = "Accounts"
        Me.tpgManageAccounts.Text = "Manage Accounts"
        Me.tpgManageAccounts.UseVisualStyleBackColor = True
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpTransactionDate.Enabled = False
        Me.dtpTransactionDate.Location = New System.Drawing.Point(147, 122)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ShowCheckBox = True
        Me.dtpTransactionDate.Size = New System.Drawing.Size(231, 20)
        Me.dtpTransactionDate.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Phone"
        '
        'stbAccountPhone
        '
        Me.stbAccountPhone.BackColor = System.Drawing.SystemColors.Control
        Me.stbAccountPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountPhone.CapitalizeFirstLetter = True
        Me.stbAccountPhone.EntryErrorMSG = ""
        Me.stbAccountPhone.Location = New System.Drawing.Point(147, 100)
        Me.stbAccountPhone.MaxLength = 100
        Me.stbAccountPhone.Multiline = True
        Me.stbAccountPhone.Name = "stbAccountPhone"
        Me.stbAccountPhone.ReadOnly = True
        Me.stbAccountPhone.RegularExpression = ""
        Me.stbAccountPhone.Size = New System.Drawing.Size(231, 20)
        Me.stbAccountPhone.TabIndex = 7
        '
        'cboAccountGroupID
        '
        Me.cboAccountGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountGroupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountGroupID.FormattingEnabled = True
        Me.cboAccountGroupID.ItemHeight = 13
        Me.cboAccountGroupID.Location = New System.Drawing.Point(147, 365)
        Me.cboAccountGroupID.Name = "cboAccountGroupID"
        Me.cboAccountGroupID.Size = New System.Drawing.Size(231, 21)
        Me.cboAccountGroupID.TabIndex = 32
        '
        'lblAccountGroupID
        '
        Me.lblAccountGroupID.Location = New System.Drawing.Point(12, 365)
        Me.lblAccountGroupID.Name = "lblAccountGroupID"
        Me.lblAccountGroupID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountGroupID.TabIndex = 31
        Me.lblAccountGroupID.Text = "Account Group"
        '
        'btnAccountExchangeRate
        '
        Me.btnAccountExchangeRate.Enabled = False
        Me.btnAccountExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAccountExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountExchangeRate.Image = CType(resources.GetObject("btnAccountExchangeRate.Image"), System.Drawing.Image)
        Me.btnAccountExchangeRate.Location = New System.Drawing.Point(114, 258)
        Me.btnAccountExchangeRate.Name = "btnAccountExchangeRate"
        Me.btnAccountExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnAccountExchangeRate.TabIndex = 21
        Me.btnAccountExchangeRate.Tag = "ExchangeRates"
        '
        'stbAccountChange
        '
        Me.stbAccountChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountChange.CapitalizeFirstLetter = False
        Me.stbAccountChange.Enabled = False
        Me.stbAccountChange.EntryErrorMSG = ""
        Me.stbAccountChange.Location = New System.Drawing.Point(147, 300)
        Me.stbAccountChange.MaxLength = 20
        Me.stbAccountChange.Name = "stbAccountChange"
        Me.stbAccountChange.RegularExpression = ""
        Me.stbAccountChange.Size = New System.Drawing.Size(231, 20)
        Me.stbAccountChange.TabIndex = 26
        Me.stbAccountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAccountChange
        '
        Me.lblAccountChange.Location = New System.Drawing.Point(12, 301)
        Me.lblAccountChange.Name = "lblAccountChange"
        Me.lblAccountChange.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountChange.TabIndex = 25
        Me.lblAccountChange.Text = "Change"
        '
        'nbxAccountAmountTendered
        '
        Me.nbxAccountAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxAccountAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmountTendered.DecimalPlaces = -1
        Me.nbxAccountAmountTendered.DenyNegativeEntryValue = True
        Me.nbxAccountAmountTendered.Location = New System.Drawing.Point(147, 237)
        Me.nbxAccountAmountTendered.MaxValue = 0.0R
        Me.nbxAccountAmountTendered.MinValue = 0.0R
        Me.nbxAccountAmountTendered.MustEnterNumeric = True
        Me.nbxAccountAmountTendered.Name = "nbxAccountAmountTendered"
        Me.nbxAccountAmountTendered.Size = New System.Drawing.Size(231, 20)
        Me.nbxAccountAmountTendered.TabIndex = 19
        Me.nbxAccountAmountTendered.Value = ""
        '
        'nbxAccountExchangeRate
        '
        Me.nbxAccountExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxAccountExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountExchangeRate.DecimalPlaces = -1
        Me.nbxAccountExchangeRate.DenyZeroEntryValue = True
        Me.nbxAccountExchangeRate.Location = New System.Drawing.Point(147, 258)
        Me.nbxAccountExchangeRate.MaxValue = 0.0R
        Me.nbxAccountExchangeRate.MinValue = 0.0R
        Me.nbxAccountExchangeRate.MustEnterNumeric = True
        Me.nbxAccountExchangeRate.Name = "nbxAccountExchangeRate"
        Me.nbxAccountExchangeRate.Size = New System.Drawing.Size(231, 20)
        Me.nbxAccountExchangeRate.TabIndex = 22
        Me.nbxAccountExchangeRate.Value = ""
        '
        'lblAccountAmountTendered
        '
        Me.lblAccountAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAccountAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAccountAmountTendered.Location = New System.Drawing.Point(12, 237)
        Me.lblAccountAmountTendered.Name = "lblAccountAmountTendered"
        Me.lblAccountAmountTendered.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountAmountTendered.TabIndex = 18
        Me.lblAccountAmountTendered.Text = "Amount Tendered"
        '
        'lblAccountExchangeRate
        '
        Me.lblAccountExchangeRate.Location = New System.Drawing.Point(12, 259)
        Me.lblAccountExchangeRate.Name = "lblAccountExchangeRate"
        Me.lblAccountExchangeRate.Size = New System.Drawing.Size(96, 18)
        Me.lblAccountExchangeRate.TabIndex = 20
        Me.lblAccountExchangeRate.Text = "Exchange Rate"
        '
        'cboAccountCurrenciesID
        '
        Me.cboAccountCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountCurrenciesID.FormattingEnabled = True
        Me.cboAccountCurrenciesID.ItemHeight = 13
        Me.cboAccountCurrenciesID.Location = New System.Drawing.Point(147, 213)
        Me.cboAccountCurrenciesID.Name = "cboAccountCurrenciesID"
        Me.cboAccountCurrenciesID.Size = New System.Drawing.Size(231, 21)
        Me.cboAccountCurrenciesID.TabIndex = 17
        '
        'lblAccountCurrenciesID
        '
        Me.lblAccountCurrenciesID.Location = New System.Drawing.Point(12, 213)
        Me.lblAccountCurrenciesID.Name = "lblAccountCurrenciesID"
        Me.lblAccountCurrenciesID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountCurrenciesID.TabIndex = 16
        Me.lblAccountCurrenciesID.Text = "Pay in Currency"
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccountNo.DropDownWidth = 256
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.ItemHeight = 13
        Me.cboAccountNo.Location = New System.Drawing.Point(147, 31)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(231, 21)
        Me.cboAccountNo.TabIndex = 3
        '
        'lblAccountTranNo
        '
        Me.lblAccountTranNo.Location = New System.Drawing.Point(12, 145)
        Me.lblAccountTranNo.Name = "lblAccountTranNo"
        Me.lblAccountTranNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountTranNo.TabIndex = 10
        Me.lblAccountTranNo.Text = "Transaction No"
        '
        'stbAccountTranNo
        '
        Me.stbAccountTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountTranNo.CapitalizeFirstLetter = False
        Me.stbAccountTranNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbAccountTranNo.EntryErrorMSG = ""
        Me.stbAccountTranNo.Location = New System.Drawing.Point(147, 145)
        Me.stbAccountTranNo.MaxLength = 20
        Me.stbAccountTranNo.Name = "stbAccountTranNo"
        Me.stbAccountTranNo.RegularExpression = ""
        Me.stbAccountTranNo.Size = New System.Drawing.Size(231, 20)
        Me.stbAccountTranNo.TabIndex = 11
        '
        'cboAccountActionID
        '
        Me.cboAccountActionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountActionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountActionID.FormattingEnabled = True
        Me.cboAccountActionID.Location = New System.Drawing.Point(147, 192)
        Me.cboAccountActionID.Name = "cboAccountActionID"
        Me.cboAccountActionID.Size = New System.Drawing.Size(231, 21)
        Me.cboAccountActionID.TabIndex = 15
        '
        'lblAccountActionID
        '
        Me.lblAccountActionID.Location = New System.Drawing.Point(12, 192)
        Me.lblAccountActionID.Name = "lblAccountActionID"
        Me.lblAccountActionID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountActionID.TabIndex = 14
        Me.lblAccountActionID.Text = "Account Action"
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(147, 8)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(231, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(12, 11)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(129, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "Account Category"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Enabled = False
        Me.nbxAccountBalance.Location = New System.Drawing.Point(147, 321)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.Size = New System.Drawing.Size(231, 20)
        Me.nbxAccountBalance.TabIndex = 28
        Me.nbxAccountBalance.Value = ""
        '
        'nbxAccountAmount
        '
        Me.nbxAccountAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmount.ControlCaption = "Amount"
        Me.nbxAccountAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmount.DecimalPlaces = -1
        Me.nbxAccountAmount.Enabled = False
        Me.nbxAccountAmount.Location = New System.Drawing.Point(147, 279)
        Me.nbxAccountAmount.MaxValue = 0.0R
        Me.nbxAccountAmount.MinValue = 0.0R
        Me.nbxAccountAmount.MustEnterNumeric = True
        Me.nbxAccountAmount.Name = "nbxAccountAmount"
        Me.nbxAccountAmount.Size = New System.Drawing.Size(231, 20)
        Me.nbxAccountAmount.TabIndex = 24
        Me.nbxAccountAmount.Value = ""
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(12, 278)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(129, 18)
        Me.lblAmount.TabIndex = 23
        Me.lblAmount.Text = "Amount"
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblAccountBalance.Location = New System.Drawing.Point(12, 321)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountBalance.TabIndex = 27
        Me.lblAccountBalance.Text = "Account Balance"
        '
        'cboAccountPayModesID
        '
        Me.cboAccountPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountPayModesID.FormattingEnabled = True
        Me.cboAccountPayModesID.ItemHeight = 13
        Me.cboAccountPayModesID.Location = New System.Drawing.Point(147, 168)
        Me.cboAccountPayModesID.Name = "cboAccountPayModesID"
        Me.cboAccountPayModesID.Size = New System.Drawing.Size(231, 21)
        Me.cboAccountPayModesID.TabIndex = 13
        '
        'lblAccountPayModes
        '
        Me.lblAccountPayModes.Location = New System.Drawing.Point(12, 171)
        Me.lblAccountPayModes.Name = "lblAccountPayModes"
        Me.lblAccountPayModes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountPayModes.TabIndex = 12
        Me.lblAccountPayModes.Text = "Mode of Payment"
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(12, 124)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(129, 18)
        Me.lblTransactionDate.TabIndex = 8
        Me.lblTransactionDate.Text = "Transaction Date"
        '
        'lblAccountDocumentNo
        '
        Me.lblAccountDocumentNo.Location = New System.Drawing.Point(12, 344)
        Me.lblAccountDocumentNo.Name = "lblAccountDocumentNo"
        Me.lblAccountDocumentNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountDocumentNo.TabIndex = 29
        Me.lblAccountDocumentNo.Text = "Document No"
        '
        'stbAccountDocumentNo
        '
        Me.stbAccountDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountDocumentNo.CapitalizeFirstLetter = False
        Me.stbAccountDocumentNo.EntryErrorMSG = ""
        Me.stbAccountDocumentNo.Location = New System.Drawing.Point(147, 342)
        Me.stbAccountDocumentNo.MaxLength = 12
        Me.stbAccountDocumentNo.Name = "stbAccountDocumentNo"
        Me.stbAccountDocumentNo.RegularExpression = ""
        Me.stbAccountDocumentNo.Size = New System.Drawing.Size(231, 20)
        Me.stbAccountDocumentNo.TabIndex = 30
        '
        'stbAccountNotes
        '
        Me.stbAccountNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNotes.CapitalizeFirstLetter = True
        Me.stbAccountNotes.EntryErrorMSG = ""
        Me.stbAccountNotes.Location = New System.Drawing.Point(147, 390)
        Me.stbAccountNotes.MaxLength = 100
        Me.stbAccountNotes.Multiline = True
        Me.stbAccountNotes.Name = "stbAccountNotes"
        Me.stbAccountNotes.RegularExpression = ""
        Me.stbAccountNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountNotes.Size = New System.Drawing.Size(231, 42)
        Me.stbAccountNotes.TabIndex = 34
        '
        'lblAccountNotes
        '
        Me.lblAccountNotes.Location = New System.Drawing.Point(12, 402)
        Me.lblAccountNotes.Name = "lblAccountNotes"
        Me.lblAccountNotes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNotes.TabIndex = 33
        Me.lblAccountNotes.Text = "Notes"
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = True
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(147, 55)
        Me.stbAccountName.MaxLength = 60
        Me.stbAccountName.Multiline = True
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountName.Size = New System.Drawing.Size(231, 44)
        Me.stbAccountName.TabIndex = 5
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(12, 68)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountName.TabIndex = 4
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(12, 31)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNo.TabIndex = 2
        Me.lblAccountNo.Text = "Account No"
        '
        'tpgOtherIncome
        '
        Me.tpgOtherIncome.Controls.Add(Me.cboOICurrenciesID)
        Me.tpgOtherIncome.Controls.Add(Me.lblOICurrenciesID)
        Me.tpgOtherIncome.Controls.Add(Me.btnOIExchangeRate)
        Me.tpgOtherIncome.Controls.Add(Me.stbOIChange)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIChange)
        Me.tpgOtherIncome.Controls.Add(Me.nbxOIAmountTendered)
        Me.tpgOtherIncome.Controls.Add(Me.nbxOIExchangeRate)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIAmountTendered)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIExchangeRate)
        Me.tpgOtherIncome.Controls.Add(Me.nbxOIAmount)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIDocumentNo)
        Me.tpgOtherIncome.Controls.Add(Me.stbOIDocumentNo)
        Me.tpgOtherIncome.Controls.Add(Me.cboOIPayModesID)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIPayModes)
        Me.tpgOtherIncome.Controls.Add(Me.lblIncomeNo)
        Me.tpgOtherIncome.Controls.Add(Me.stbIncomeNo)
        Me.tpgOtherIncome.Controls.Add(Me.lblOINotes)
        Me.tpgOtherIncome.Controls.Add(Me.lblOIAmount)
        Me.tpgOtherIncome.Controls.Add(Me.stbOINotes)
        Me.tpgOtherIncome.Controls.Add(Me.cboIncomeSourcesID)
        Me.tpgOtherIncome.Controls.Add(Me.lblIncomeSourcesID)
        Me.tpgOtherIncome.Controls.Add(Me.dtpIncomeDate)
        Me.tpgOtherIncome.Controls.Add(Me.lblIncomeDate)
        Me.tpgOtherIncome.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherIncome.Name = "tpgOtherIncome"
        Me.tpgOtherIncome.Size = New System.Drawing.Size(894, 482)
        Me.tpgOtherIncome.TabIndex = 2
        Me.tpgOtherIncome.Tag = "OtherIncome"
        Me.tpgOtherIncome.Text = "Other Income"
        Me.tpgOtherIncome.UseVisualStyleBackColor = True
        '
        'cboOICurrenciesID
        '
        Me.cboOICurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOICurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOICurrenciesID.FormattingEnabled = True
        Me.cboOICurrenciesID.ItemHeight = 13
        Me.cboOICurrenciesID.Location = New System.Drawing.Point(145, 98)
        Me.cboOICurrenciesID.Name = "cboOICurrenciesID"
        Me.cboOICurrenciesID.Size = New System.Drawing.Size(228, 21)
        Me.cboOICurrenciesID.TabIndex = 9
        '
        'lblOICurrenciesID
        '
        Me.lblOICurrenciesID.Location = New System.Drawing.Point(17, 98)
        Me.lblOICurrenciesID.Name = "lblOICurrenciesID"
        Me.lblOICurrenciesID.Size = New System.Drawing.Size(122, 21)
        Me.lblOICurrenciesID.TabIndex = 8
        Me.lblOICurrenciesID.Text = "Pay in Currency"
        '
        'btnOIExchangeRate
        '
        Me.btnOIExchangeRate.Enabled = False
        Me.btnOIExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnOIExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOIExchangeRate.Image = CType(resources.GetObject("btnOIExchangeRate.Image"), System.Drawing.Image)
        Me.btnOIExchangeRate.Location = New System.Drawing.Point(112, 143)
        Me.btnOIExchangeRate.Name = "btnOIExchangeRate"
        Me.btnOIExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnOIExchangeRate.TabIndex = 13
        Me.btnOIExchangeRate.Tag = "ExchangeRates"
        '
        'stbOIChange
        '
        Me.stbOIChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbOIChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOIChange.CapitalizeFirstLetter = False
        Me.stbOIChange.Enabled = False
        Me.stbOIChange.EntryErrorMSG = ""
        Me.stbOIChange.Location = New System.Drawing.Point(145, 185)
        Me.stbOIChange.MaxLength = 20
        Me.stbOIChange.Name = "stbOIChange"
        Me.stbOIChange.RegularExpression = ""
        Me.stbOIChange.Size = New System.Drawing.Size(228, 20)
        Me.stbOIChange.TabIndex = 18
        Me.stbOIChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblOIChange
        '
        Me.lblOIChange.Location = New System.Drawing.Point(17, 186)
        Me.lblOIChange.Name = "lblOIChange"
        Me.lblOIChange.Size = New System.Drawing.Size(122, 21)
        Me.lblOIChange.TabIndex = 17
        Me.lblOIChange.Text = "Change"
        '
        'nbxOIAmountTendered
        '
        Me.nbxOIAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOIAmountTendered.ControlCaption = "Amount Tendered"
        Me.nbxOIAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOIAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOIAmountTendered.DecimalPlaces = -1
        Me.nbxOIAmountTendered.DenyNegativeEntryValue = True
        Me.nbxOIAmountTendered.Location = New System.Drawing.Point(145, 122)
        Me.nbxOIAmountTendered.MaxValue = 0.0R
        Me.nbxOIAmountTendered.MinValue = 0.0R
        Me.nbxOIAmountTendered.MustEnterNumeric = True
        Me.nbxOIAmountTendered.Name = "nbxOIAmountTendered"
        Me.nbxOIAmountTendered.Size = New System.Drawing.Size(228, 20)
        Me.nbxOIAmountTendered.TabIndex = 11
        Me.nbxOIAmountTendered.Value = ""
        '
        'nbxOIExchangeRate
        '
        Me.nbxOIExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOIExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxOIExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOIExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOIExchangeRate.DecimalPlaces = -1
        Me.nbxOIExchangeRate.DenyZeroEntryValue = True
        Me.nbxOIExchangeRate.Location = New System.Drawing.Point(145, 143)
        Me.nbxOIExchangeRate.MaxValue = 0.0R
        Me.nbxOIExchangeRate.MinValue = 0.0R
        Me.nbxOIExchangeRate.MustEnterNumeric = True
        Me.nbxOIExchangeRate.Name = "nbxOIExchangeRate"
        Me.nbxOIExchangeRate.Size = New System.Drawing.Size(228, 20)
        Me.nbxOIExchangeRate.TabIndex = 14
        Me.nbxOIExchangeRate.Value = ""
        '
        'lblOIAmountTendered
        '
        Me.lblOIAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblOIAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblOIAmountTendered.Location = New System.Drawing.Point(17, 122)
        Me.lblOIAmountTendered.Name = "lblOIAmountTendered"
        Me.lblOIAmountTendered.Size = New System.Drawing.Size(122, 21)
        Me.lblOIAmountTendered.TabIndex = 10
        Me.lblOIAmountTendered.Text = "Amount Tendered"
        '
        'lblOIExchangeRate
        '
        Me.lblOIExchangeRate.Location = New System.Drawing.Point(17, 144)
        Me.lblOIExchangeRate.Name = "lblOIExchangeRate"
        Me.lblOIExchangeRate.Size = New System.Drawing.Size(89, 21)
        Me.lblOIExchangeRate.TabIndex = 12
        Me.lblOIExchangeRate.Text = "Exchange Rate"
        '
        'nbxOIAmount
        '
        Me.nbxOIAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOIAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOIAmount.ControlCaption = "Amount"
        Me.nbxOIAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOIAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOIAmount.DecimalPlaces = -1
        Me.nbxOIAmount.Enabled = False
        Me.nbxOIAmount.Location = New System.Drawing.Point(145, 164)
        Me.nbxOIAmount.MaxValue = 0.0R
        Me.nbxOIAmount.MinValue = 0.0R
        Me.nbxOIAmount.MustEnterNumeric = True
        Me.nbxOIAmount.Name = "nbxOIAmount"
        Me.nbxOIAmount.Size = New System.Drawing.Size(228, 20)
        Me.nbxOIAmount.TabIndex = 16
        Me.nbxOIAmount.Value = ""
        '
        'lblOIDocumentNo
        '
        Me.lblOIDocumentNo.Location = New System.Drawing.Point(17, 207)
        Me.lblOIDocumentNo.Name = "lblOIDocumentNo"
        Me.lblOIDocumentNo.Size = New System.Drawing.Size(122, 21)
        Me.lblOIDocumentNo.TabIndex = 19
        Me.lblOIDocumentNo.Text = "Document No"
        '
        'stbOIDocumentNo
        '
        Me.stbOIDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOIDocumentNo.CapitalizeFirstLetter = False
        Me.stbOIDocumentNo.EntryErrorMSG = ""
        Me.stbOIDocumentNo.Location = New System.Drawing.Point(145, 206)
        Me.stbOIDocumentNo.MaxLength = 20
        Me.stbOIDocumentNo.Name = "stbOIDocumentNo"
        Me.stbOIDocumentNo.RegularExpression = ""
        Me.stbOIDocumentNo.Size = New System.Drawing.Size(228, 20)
        Me.stbOIDocumentNo.TabIndex = 20
        '
        'cboOIPayModesID
        '
        Me.cboOIPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOIPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOIPayModesID.FormattingEnabled = True
        Me.cboOIPayModesID.ItemHeight = 13
        Me.cboOIPayModesID.Location = New System.Drawing.Point(145, 77)
        Me.cboOIPayModesID.Name = "cboOIPayModesID"
        Me.cboOIPayModesID.Size = New System.Drawing.Size(228, 21)
        Me.cboOIPayModesID.TabIndex = 7
        '
        'lblOIPayModes
        '
        Me.lblOIPayModes.Location = New System.Drawing.Point(17, 77)
        Me.lblOIPayModes.Name = "lblOIPayModes"
        Me.lblOIPayModes.Size = New System.Drawing.Size(122, 21)
        Me.lblOIPayModes.TabIndex = 6
        Me.lblOIPayModes.Text = "Mode of Payment"
        '
        'lblIncomeNo
        '
        Me.lblIncomeNo.Location = New System.Drawing.Point(17, 7)
        Me.lblIncomeNo.Name = "lblIncomeNo"
        Me.lblIncomeNo.Size = New System.Drawing.Size(122, 21)
        Me.lblIncomeNo.TabIndex = 0
        Me.lblIncomeNo.Text = "Income No"
        '
        'stbIncomeNo
        '
        Me.stbIncomeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIncomeNo.CapitalizeFirstLetter = False
        Me.stbIncomeNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbIncomeNo.EntryErrorMSG = ""
        Me.stbIncomeNo.Location = New System.Drawing.Point(145, 7)
        Me.stbIncomeNo.MaxLength = 20
        Me.stbIncomeNo.Name = "stbIncomeNo"
        Me.stbIncomeNo.RegularExpression = ""
        Me.stbIncomeNo.Size = New System.Drawing.Size(228, 20)
        Me.stbIncomeNo.TabIndex = 1
        '
        'lblOINotes
        '
        Me.lblOINotes.Location = New System.Drawing.Point(17, 240)
        Me.lblOINotes.Name = "lblOINotes"
        Me.lblOINotes.Size = New System.Drawing.Size(122, 21)
        Me.lblOINotes.TabIndex = 21
        Me.lblOINotes.Text = "Notes"
        '
        'lblOIAmount
        '
        Me.lblOIAmount.Location = New System.Drawing.Point(17, 164)
        Me.lblOIAmount.Name = "lblOIAmount"
        Me.lblOIAmount.Size = New System.Drawing.Size(122, 21)
        Me.lblOIAmount.TabIndex = 15
        Me.lblOIAmount.Text = "Amount"
        '
        'stbOINotes
        '
        Me.stbOINotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOINotes.CapitalizeFirstLetter = True
        Me.stbOINotes.EntryErrorMSG = ""
        Me.stbOINotes.Location = New System.Drawing.Point(145, 227)
        Me.stbOINotes.MaxLength = 200
        Me.stbOINotes.Multiline = True
        Me.stbOINotes.Name = "stbOINotes"
        Me.stbOINotes.RegularExpression = ""
        Me.stbOINotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOINotes.Size = New System.Drawing.Size(228, 49)
        Me.stbOINotes.TabIndex = 22
        '
        'cboIncomeSourcesID
        '
        Me.cboIncomeSourcesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboIncomeSourcesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboIncomeSourcesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboIncomeSourcesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboIncomeSourcesID.FormattingEnabled = True
        Me.cboIncomeSourcesID.Location = New System.Drawing.Point(145, 51)
        Me.cboIncomeSourcesID.Name = "cboIncomeSourcesID"
        Me.cboIncomeSourcesID.Size = New System.Drawing.Size(228, 21)
        Me.cboIncomeSourcesID.TabIndex = 5
        '
        'lblIncomeSourcesID
        '
        Me.lblIncomeSourcesID.Location = New System.Drawing.Point(17, 51)
        Me.lblIncomeSourcesID.Name = "lblIncomeSourcesID"
        Me.lblIncomeSourcesID.Size = New System.Drawing.Size(122, 21)
        Me.lblIncomeSourcesID.TabIndex = 4
        Me.lblIncomeSourcesID.Text = "Income Source"
        '
        'dtpIncomeDate
        '
        Me.dtpIncomeDate.Location = New System.Drawing.Point(145, 28)
        Me.dtpIncomeDate.Name = "dtpIncomeDate"
        Me.dtpIncomeDate.ShowCheckBox = True
        Me.dtpIncomeDate.Size = New System.Drawing.Size(228, 20)
        Me.dtpIncomeDate.TabIndex = 3
        '
        'lblIncomeDate
        '
        Me.lblIncomeDate.Location = New System.Drawing.Point(17, 28)
        Me.lblIncomeDate.Name = "lblIncomeDate"
        Me.lblIncomeDate.Size = New System.Drawing.Size(122, 21)
        Me.lblIncomeDate.TabIndex = 2
        Me.lblIncomeDate.Text = "Income Date"
        '
        'tpgRefunds
        '
        Me.tpgRefunds.Controls.Add(Me.btnFindReceiptNo)
        Me.tpgRefunds.Controls.Add(Me.dgvPaymentRefunds)
        Me.tpgRefunds.Controls.Add(Me.lblRefundInvoiceNo)
        Me.tpgRefunds.Controls.Add(Me.stbRefundInvoiceNo)
        Me.tpgRefunds.Controls.Add(Me.btnReject)
        Me.tpgRefunds.Controls.Add(Me.stbRefundRequestNo)
        Me.tpgRefunds.Controls.Add(Me.lblRefundRequestNo)
        Me.tpgRefunds.Controls.Add(Me.lblPendingRefundRequests)
        Me.tpgRefunds.Controls.Add(Me.btnLoadRefundRequests)
        Me.tpgRefunds.Controls.Add(Me.lblToRefundAmount)
        Me.tpgRefunds.Controls.Add(Me.nbxToRefundAmount)
        Me.tpgRefunds.Controls.Add(Me.nbxRefundOutstandingBalance)
        Me.tpgRefunds.Controls.Add(Me.lblRefundOutstandingBalance)
        Me.tpgRefunds.Controls.Add(Me.stbAmountRefunded)
        Me.tpgRefunds.Controls.Add(Me.lblAmountRefunded)
        Me.tpgRefunds.Controls.Add(Me.nbxRefundAccountBalance)
        Me.tpgRefunds.Controls.Add(Me.lblRefundAccountBalance)
        Me.tpgRefunds.Controls.Add(Me.stbRefundAmountPaid)
        Me.tpgRefunds.Controls.Add(Me.lblRefundAmountPaid)
        Me.tpgRefunds.Controls.Add(Me.stbRefundPayDate)
        Me.tpgRefunds.Controls.Add(Me.lblRefundPayDate)
        Me.tpgRefunds.Controls.Add(Me.stbPayeeName)
        Me.tpgRefunds.Controls.Add(Me.lblPayeeName)
        Me.tpgRefunds.Controls.Add(Me.stbRefundAmountWords)
        Me.tpgRefunds.Controls.Add(Me.lblRefundAmountWords)
        Me.tpgRefunds.Controls.Add(Me.lblRefundReceiptNo)
        Me.tpgRefunds.Controls.Add(Me.stbRefundReceiptNo)
        Me.tpgRefunds.Controls.Add(Me.lblRefundNo)
        Me.tpgRefunds.Controls.Add(Me.stbRefundNo)
        Me.tpgRefunds.Controls.Add(Me.lblRefundNotes)
        Me.tpgRefunds.Controls.Add(Me.lblRefundAmount)
        Me.tpgRefunds.Controls.Add(Me.stbRefundNotes)
        Me.tpgRefunds.Controls.Add(Me.nbxTotalRefundAmount)
        Me.tpgRefunds.Controls.Add(Me.dtpRefundDate)
        Me.tpgRefunds.Controls.Add(Me.lblRefundDate)
        Me.tpgRefunds.Location = New System.Drawing.Point(4, 22)
        Me.tpgRefunds.Name = "tpgRefunds"
        Me.tpgRefunds.Size = New System.Drawing.Size(894, 482)
        Me.tpgRefunds.TabIndex = 6
        Me.tpgRefunds.Tag = "Refunds"
        Me.tpgRefunds.Text = "Refunds"
        Me.tpgRefunds.UseVisualStyleBackColor = True
        '
        'btnFindReceiptNo
        '
        Me.btnFindReceiptNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindReceiptNo.Image = CType(resources.GetObject("btnFindReceiptNo.Image"), System.Drawing.Image)
        Me.btnFindReceiptNo.Location = New System.Drawing.Point(190, 4)
        Me.btnFindReceiptNo.Name = "btnFindReceiptNo"
        Me.btnFindReceiptNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindReceiptNo.TabIndex = 100
        '
        'dgvPaymentRefunds
        '
        Me.dgvPaymentRefunds.AllowUserToAddRows = False
        Me.dgvPaymentRefunds.AllowUserToOrderColumns = True
        Me.dgvPaymentRefunds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentRefunds.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle92.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle92.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle92.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle92.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle92.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle92
        Me.dgvPaymentRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRefItemCode, Me.colRefVisitNo, Me.colRefItemName, Me.colRefSoldQuantity, Me.colRefPaidAmount, Me.coReflItemCategory, Me.colRefundReason, Me.colRefQuantity, Me.colRefNewPrice, Me.colRefAmount, Me.colRefDiscount, Me.colPrevRefundedQuantity, Me.colRefSalesUnitPrice, Me.colAcknowledgeable, Me.colPrevRefundedAmount, Me.colRefInvoiceNo, Me.colRefItemStatusID, Me.colRefItemStatus, Me.colRefItemCategoryID})
        DataGridViewCellStyle110.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle110.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle110.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle110.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle110.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle110.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentRefunds.DefaultCellStyle = DataGridViewCellStyle110
        Me.dgvPaymentRefunds.EnableHeadersVisualStyles = False
        Me.dgvPaymentRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentRefunds.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvPaymentRefunds.Location = New System.Drawing.Point(4, 215)
        Me.dgvPaymentRefunds.Name = "dgvPaymentRefunds"
        DataGridViewCellStyle111.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle111.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle111.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle111.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle111.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle111.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle111
        Me.dgvPaymentRefunds.Size = New System.Drawing.Size(886, 269)
        Me.dgvPaymentRefunds.TabIndex = 99
        Me.dgvPaymentRefunds.Text = "DataGridView1"
        '
        'colRefItemCode
        '
        Me.colRefItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle93.BackColor = System.Drawing.SystemColors.Info
        Me.colRefItemCode.DefaultCellStyle = DataGridViewCellStyle93
        Me.colRefItemCode.HeaderText = "Item Code"
        Me.colRefItemCode.Name = "colRefItemCode"
        Me.colRefItemCode.ReadOnly = True
        Me.colRefItemCode.Visible = False
        Me.colRefItemCode.Width = 80
        '
        'colRefVisitNo
        '
        DataGridViewCellStyle94.BackColor = System.Drawing.SystemColors.Info
        Me.colRefVisitNo.DefaultCellStyle = DataGridViewCellStyle94
        Me.colRefVisitNo.HeaderText = "Visit No"
        Me.colRefVisitNo.Name = "colRefVisitNo"
        Me.colRefVisitNo.ReadOnly = True
        '
        'colRefItemName
        '
        Me.colRefItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle95.BackColor = System.Drawing.SystemColors.Info
        Me.colRefItemName.DefaultCellStyle = DataGridViewCellStyle95
        Me.colRefItemName.HeaderText = "Item Name"
        Me.colRefItemName.Name = "colRefItemName"
        '
        'colRefSoldQuantity
        '
        Me.colRefSoldQuantity.DataPropertyName = "SoldQuantity"
        DataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle96.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle96.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle96.NullValue = Nothing
        Me.colRefSoldQuantity.DefaultCellStyle = DataGridViewCellStyle96
        Me.colRefSoldQuantity.HeaderText = "Sold Qty"
        Me.colRefSoldQuantity.Name = "colRefSoldQuantity"
        Me.colRefSoldQuantity.ReadOnly = True
        Me.colRefSoldQuantity.Width = 80
        '
        'colRefPaidAmount
        '
        Me.colRefPaidAmount.DataPropertyName = "AmountPaid"
        DataGridViewCellStyle97.BackColor = System.Drawing.SystemColors.Info
        Me.colRefPaidAmount.DefaultCellStyle = DataGridViewCellStyle97
        Me.colRefPaidAmount.HeaderText = "Paid Amount"
        Me.colRefPaidAmount.Name = "colRefPaidAmount"
        Me.colRefPaidAmount.ReadOnly = True
        Me.colRefPaidAmount.Width = 80
        '
        'coReflItemCategory
        '
        Me.coReflItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle98.BackColor = System.Drawing.SystemColors.Info
        Me.coReflItemCategory.DefaultCellStyle = DataGridViewCellStyle98
        Me.coReflItemCategory.HeaderText = "Item Category"
        Me.coReflItemCategory.Name = "coReflItemCategory"
        Me.coReflItemCategory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colRefundReason
        '
        Me.colRefundReason.ControlCaption = Nothing
        Me.colRefundReason.DataPropertyName = "ReturnReasonID"
        DataGridViewCellStyle99.BackColor = System.Drawing.SystemColors.Info
        Me.colRefundReason.DefaultCellStyle = DataGridViewCellStyle99
        Me.colRefundReason.DisplayStyleForCurrentCellOnly = True
        Me.colRefundReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRefundReason.HeaderText = "Refund Reason"
        Me.colRefundReason.Name = "colRefundReason"
        Me.colRefundReason.ReadOnly = True
        Me.colRefundReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRefundReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colRefundReason.SourceColumn = Nothing
        Me.colRefundReason.Width = 120
        '
        'colRefQuantity
        '
        Me.colRefQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle100.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle100.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle100.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colRefQuantity.DefaultCellStyle = DataGridViewCellStyle100
        Me.colRefQuantity.HeaderText = "Return Qty"
        Me.colRefQuantity.Name = "colRefQuantity"
        Me.colRefQuantity.ReadOnly = True
        Me.colRefQuantity.Width = 90
        '
        'colRefNewPrice
        '
        Me.colRefNewPrice.DataPropertyName = "NewPrice"
        DataGridViewCellStyle101.BackColor = System.Drawing.SystemColors.Info
        Me.colRefNewPrice.DefaultCellStyle = DataGridViewCellStyle101
        Me.colRefNewPrice.HeaderText = "New Price"
        Me.colRefNewPrice.Name = "colRefNewPrice"
        Me.colRefNewPrice.ReadOnly = True
        '
        'colRefAmount
        '
        Me.colRefAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle102.BackColor = System.Drawing.SystemColors.Info
        Me.colRefAmount.DefaultCellStyle = DataGridViewCellStyle102
        Me.colRefAmount.HeaderText = "Refund Amount"
        Me.colRefAmount.Name = "colRefAmount"
        Me.colRefAmount.ReadOnly = True
        Me.colRefAmount.Width = 90
        '
        'colRefDiscount
        '
        Me.colRefDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle103.BackColor = System.Drawing.SystemColors.Info
        Me.colRefDiscount.DefaultCellStyle = DataGridViewCellStyle103
        Me.colRefDiscount.HeaderText = "Discount"
        Me.colRefDiscount.Name = "colRefDiscount"
        Me.colRefDiscount.ReadOnly = True
        Me.colRefDiscount.Visible = False
        Me.colRefDiscount.Width = 80
        '
        'colPrevRefundedQuantity
        '
        Me.colPrevRefundedQuantity.DataPropertyName = "RefundedQuantity"
        DataGridViewCellStyle104.BackColor = System.Drawing.SystemColors.Info
        Me.colPrevRefundedQuantity.DefaultCellStyle = DataGridViewCellStyle104
        Me.colPrevRefundedQuantity.FillWeight = 120.0!
        Me.colPrevRefundedQuantity.HeaderText = "Prev Refund Qty"
        Me.colPrevRefundedQuantity.Name = "colPrevRefundedQuantity"
        Me.colPrevRefundedQuantity.ReadOnly = True
        '
        'colRefSalesUnitPrice
        '
        Me.colRefSalesUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle105.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle105.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle105.NullValue = Nothing
        Me.colRefSalesUnitPrice.DefaultCellStyle = DataGridViewCellStyle105
        Me.colRefSalesUnitPrice.HeaderText = "Unit Price"
        Me.colRefSalesUnitPrice.Name = "colRefSalesUnitPrice"
        Me.colRefSalesUnitPrice.ReadOnly = True
        Me.colRefSalesUnitPrice.Width = 80
        '
        'colAcknowledgeable
        '
        Me.colAcknowledgeable.ControlCaption = Nothing
        DataGridViewCellStyle106.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle106.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle106.NullValue = False
        Me.colAcknowledgeable.DefaultCellStyle = DataGridViewCellStyle106
        Me.colAcknowledgeable.HeaderText = "Acknowledgeable"
        Me.colAcknowledgeable.Name = "colAcknowledgeable"
        Me.colAcknowledgeable.ReadOnly = True
        Me.colAcknowledgeable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAcknowledgeable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAcknowledgeable.SourceColumn = Nothing
        Me.colAcknowledgeable.Width = 60
        '
        'colPrevRefundedAmount
        '
        Me.colPrevRefundedAmount.DataPropertyName = "RefundedAmount"
        DataGridViewCellStyle107.BackColor = System.Drawing.SystemColors.Info
        Me.colPrevRefundedAmount.DefaultCellStyle = DataGridViewCellStyle107
        Me.colPrevRefundedAmount.FillWeight = 120.0!
        Me.colPrevRefundedAmount.HeaderText = "Prev Refund Amt"
        Me.colPrevRefundedAmount.Name = "colPrevRefundedAmount"
        Me.colPrevRefundedAmount.ReadOnly = True
        '
        'colRefInvoiceNo
        '
        Me.colRefInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle108.BackColor = System.Drawing.SystemColors.Info
        Me.colRefInvoiceNo.DefaultCellStyle = DataGridViewCellStyle108
        Me.colRefInvoiceNo.HeaderText = "Invoice No"
        Me.colRefInvoiceNo.Name = "colRefInvoiceNo"
        Me.colRefInvoiceNo.ReadOnly = True
        '
        'colRefItemStatusID
        '
        Me.colRefItemStatusID.HeaderText = "Item Status ID"
        Me.colRefItemStatusID.Name = "colRefItemStatusID"
        Me.colRefItemStatusID.ReadOnly = True
        Me.colRefItemStatusID.Visible = False
        '
        'colRefItemStatus
        '
        DataGridViewCellStyle109.BackColor = System.Drawing.SystemColors.Info
        Me.colRefItemStatus.DefaultCellStyle = DataGridViewCellStyle109
        Me.colRefItemStatus.HeaderText = "Item Status"
        Me.colRefItemStatus.Name = "colRefItemStatus"
        Me.colRefItemStatus.ReadOnly = True
        '
        'colRefItemCategoryID
        '
        Me.colRefItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.colRefItemCategoryID.HeaderText = "Item Category ID"
        Me.colRefItemCategoryID.Name = "colRefItemCategoryID"
        Me.colRefItemCategoryID.ReadOnly = True
        Me.colRefItemCategoryID.Visible = False
        '
        'lblRefundInvoiceNo
        '
        Me.lblRefundInvoiceNo.Location = New System.Drawing.Point(18, 54)
        Me.lblRefundInvoiceNo.Name = "lblRefundInvoiceNo"
        Me.lblRefundInvoiceNo.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundInvoiceNo.TabIndex = 97
        Me.lblRefundInvoiceNo.Text = "Receipt Invoice No"
        '
        'stbRefundInvoiceNo
        '
        Me.stbRefundInvoiceNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundInvoiceNo.CapitalizeFirstLetter = False
        Me.stbRefundInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRefundInvoiceNo.EntryErrorMSG = ""
        Me.stbRefundInvoiceNo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.stbRefundInvoiceNo.Location = New System.Drawing.Point(189, 49)
        Me.stbRefundInvoiceNo.MaxLength = 20
        Me.stbRefundInvoiceNo.Name = "stbRefundInvoiceNo"
        Me.stbRefundInvoiceNo.ReadOnly = True
        Me.stbRefundInvoiceNo.RegularExpression = ""
        Me.stbRefundInvoiceNo.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundInvoiceNo.TabIndex = 98
        '
        'btnReject
        '
        Me.btnReject.AccessibleDescription = ""
        Me.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Location = New System.Drawing.Point(695, 182)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(49, 24)
        Me.btnReject.TabIndex = 96
        Me.btnReject.Tag = ""
        Me.btnReject.Text = "&Reject"
        Me.btnReject.Visible = False
        '
        'stbRefundRequestNo
        '
        Me.stbRefundRequestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundRequestNo.CapitalizeFirstLetter = False
        Me.stbRefundRequestNo.EntryErrorMSG = ""
        Me.stbRefundRequestNo.Location = New System.Drawing.Point(220, 4)
        Me.stbRefundRequestNo.Name = "stbRefundRequestNo"
        Me.stbRefundRequestNo.RegularExpression = ""
        Me.stbRefundRequestNo.Size = New System.Drawing.Size(159, 20)
        Me.stbRefundRequestNo.TabIndex = 94
        '
        'lblRefundRequestNo
        '
        Me.lblRefundRequestNo.Location = New System.Drawing.Point(18, 4)
        Me.lblRefundRequestNo.Name = "lblRefundRequestNo"
        Me.lblRefundRequestNo.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundRequestNo.TabIndex = 95
        Me.lblRefundRequestNo.Text = "Refund Request No"
        '
        'lblPendingRefundRequests
        '
        Me.lblPendingRefundRequests.Font = New System.Drawing.Font("Verdana", 11.25!)
        Me.lblPendingRefundRequests.ForeColor = System.Drawing.Color.Red
        Me.lblPendingRefundRequests.Location = New System.Drawing.Point(396, 183)
        Me.lblPendingRefundRequests.Name = "lblPendingRefundRequests"
        Me.lblPendingRefundRequests.Size = New System.Drawing.Size(237, 23)
        Me.lblPendingRefundRequests.TabIndex = 93
        Me.lblPendingRefundRequests.Text = "Pending Requests"
        '
        'btnLoadRefundRequests
        '
        Me.btnLoadRefundRequests.AccessibleDescription = ""
        Me.btnLoadRefundRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadRefundRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadRefundRequests.Location = New System.Drawing.Point(638, 183)
        Me.btnLoadRefundRequests.Name = "btnLoadRefundRequests"
        Me.btnLoadRefundRequests.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadRefundRequests.TabIndex = 92
        Me.btnLoadRefundRequests.Tag = ""
        Me.btnLoadRefundRequests.Text = "&Load"
        '
        'lblToRefundAmount
        '
        Me.lblToRefundAmount.Location = New System.Drawing.Point(477, 46)
        Me.lblToRefundAmount.Name = "lblToRefundAmount"
        Me.lblToRefundAmount.Size = New System.Drawing.Size(169, 20)
        Me.lblToRefundAmount.TabIndex = 91
        Me.lblToRefundAmount.Text = "To-Refund Amount"
        '
        'nbxToRefundAmount
        '
        Me.nbxToRefundAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxToRefundAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxToRefundAmount.ControlCaption = "To-Refund Amount"
        Me.nbxToRefundAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxToRefundAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxToRefundAmount.DecimalPlaces = -1
        Me.nbxToRefundAmount.DenyNegativeEntryValue = True
        Me.nbxToRefundAmount.Location = New System.Drawing.Point(693, 43)
        Me.nbxToRefundAmount.MaxValue = 0.0R
        Me.nbxToRefundAmount.MinValue = 0.0R
        Me.nbxToRefundAmount.MustEnterNumeric = True
        Me.nbxToRefundAmount.Name = "nbxToRefundAmount"
        Me.nbxToRefundAmount.ReadOnly = True
        Me.nbxToRefundAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxToRefundAmount.TabIndex = 84
        Me.nbxToRefundAmount.Value = ""
        '
        'nbxRefundOutstandingBalance
        '
        Me.nbxRefundOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxRefundOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxRefundOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundOutstandingBalance.DecimalPlaces = -1
        Me.nbxRefundOutstandingBalance.Location = New System.Drawing.Point(189, 156)
        Me.nbxRefundOutstandingBalance.MaxValue = 0.0R
        Me.nbxRefundOutstandingBalance.MinValue = 0.0R
        Me.nbxRefundOutstandingBalance.MustEnterNumeric = True
        Me.nbxRefundOutstandingBalance.Name = "nbxRefundOutstandingBalance"
        Me.nbxRefundOutstandingBalance.ReadOnly = True
        Me.nbxRefundOutstandingBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundOutstandingBalance.TabIndex = 76
        Me.nbxRefundOutstandingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundOutstandingBalance.Value = ""
        '
        'lblRefundOutstandingBalance
        '
        Me.lblRefundOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundOutstandingBalance.Location = New System.Drawing.Point(18, 160)
        Me.lblRefundOutstandingBalance.Name = "lblRefundOutstandingBalance"
        Me.lblRefundOutstandingBalance.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundOutstandingBalance.TabIndex = 75
        Me.lblRefundOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbAmountRefunded
        '
        Me.stbAmountRefunded.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountRefunded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountRefunded.CapitalizeFirstLetter = False
        Me.stbAmountRefunded.Enabled = False
        Me.stbAmountRefunded.EntryErrorMSG = ""
        Me.stbAmountRefunded.Location = New System.Drawing.Point(189, 135)
        Me.stbAmountRefunded.MaxLength = 20
        Me.stbAmountRefunded.Name = "stbAmountRefunded"
        Me.stbAmountRefunded.RegularExpression = ""
        Me.stbAmountRefunded.Size = New System.Drawing.Size(190, 20)
        Me.stbAmountRefunded.TabIndex = 74
        Me.stbAmountRefunded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAmountRefunded
        '
        Me.lblAmountRefunded.Location = New System.Drawing.Point(18, 136)
        Me.lblAmountRefunded.Name = "lblAmountRefunded"
        Me.lblAmountRefunded.Size = New System.Drawing.Size(122, 20)
        Me.lblAmountRefunded.TabIndex = 73
        Me.lblAmountRefunded.Text = "Amount Refunded"
        '
        'nbxRefundAccountBalance
        '
        Me.nbxRefundAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundAccountBalance.ControlCaption = "Balance"
        Me.nbxRefundAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundAccountBalance.DecimalPlaces = -1
        Me.nbxRefundAccountBalance.Enabled = False
        Me.nbxRefundAccountBalance.Location = New System.Drawing.Point(189, 177)
        Me.nbxRefundAccountBalance.MaxValue = 0.0R
        Me.nbxRefundAccountBalance.MinValue = 0.0R
        Me.nbxRefundAccountBalance.MustEnterNumeric = True
        Me.nbxRefundAccountBalance.Name = "nbxRefundAccountBalance"
        Me.nbxRefundAccountBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundAccountBalance.TabIndex = 78
        Me.nbxRefundAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundAccountBalance.Value = ""
        '
        'lblRefundAccountBalance
        '
        Me.lblRefundAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundAccountBalance.Location = New System.Drawing.Point(18, 180)
        Me.lblRefundAccountBalance.Name = "lblRefundAccountBalance"
        Me.lblRefundAccountBalance.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundAccountBalance.TabIndex = 77
        Me.lblRefundAccountBalance.Text = "Account Balance"
        '
        'stbRefundAmountPaid
        '
        Me.stbRefundAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundAmountPaid.CapitalizeFirstLetter = False
        Me.stbRefundAmountPaid.Enabled = False
        Me.stbRefundAmountPaid.EntryErrorMSG = ""
        Me.stbRefundAmountPaid.Location = New System.Drawing.Point(189, 114)
        Me.stbRefundAmountPaid.MaxLength = 20
        Me.stbRefundAmountPaid.Name = "stbRefundAmountPaid"
        Me.stbRefundAmountPaid.RegularExpression = ""
        Me.stbRefundAmountPaid.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundAmountPaid.TabIndex = 72
        Me.stbRefundAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRefundAmountPaid
        '
        Me.lblRefundAmountPaid.Location = New System.Drawing.Point(18, 115)
        Me.lblRefundAmountPaid.Name = "lblRefundAmountPaid"
        Me.lblRefundAmountPaid.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundAmountPaid.TabIndex = 71
        Me.lblRefundAmountPaid.Text = "Amount Paid"
        '
        'stbRefundPayDate
        '
        Me.stbRefundPayDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundPayDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundPayDate.CapitalizeFirstLetter = False
        Me.stbRefundPayDate.Enabled = False
        Me.stbRefundPayDate.EntryErrorMSG = ""
        Me.stbRefundPayDate.Location = New System.Drawing.Point(189, 93)
        Me.stbRefundPayDate.MaxLength = 60
        Me.stbRefundPayDate.Name = "stbRefundPayDate"
        Me.stbRefundPayDate.ReadOnly = True
        Me.stbRefundPayDate.RegularExpression = ""
        Me.stbRefundPayDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundPayDate.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundPayDate.TabIndex = 70
        '
        'lblRefundPayDate
        '
        Me.lblRefundPayDate.Location = New System.Drawing.Point(18, 95)
        Me.lblRefundPayDate.Name = "lblRefundPayDate"
        Me.lblRefundPayDate.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundPayDate.TabIndex = 69
        Me.lblRefundPayDate.Text = "Pay Date"
        '
        'stbPayeeName
        '
        Me.stbPayeeName.BackColor = System.Drawing.SystemColors.Info
        Me.stbPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayeeName.CapitalizeFirstLetter = False
        Me.stbPayeeName.Enabled = False
        Me.stbPayeeName.EntryErrorMSG = ""
        Me.stbPayeeName.Location = New System.Drawing.Point(189, 72)
        Me.stbPayeeName.MaxLength = 60
        Me.stbPayeeName.Name = "stbPayeeName"
        Me.stbPayeeName.ReadOnly = True
        Me.stbPayeeName.RegularExpression = ""
        Me.stbPayeeName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPayeeName.Size = New System.Drawing.Size(190, 20)
        Me.stbPayeeName.TabIndex = 68
        '
        'lblPayeeName
        '
        Me.lblPayeeName.Location = New System.Drawing.Point(18, 75)
        Me.lblPayeeName.Name = "lblPayeeName"
        Me.lblPayeeName.Size = New System.Drawing.Size(122, 20)
        Me.lblPayeeName.TabIndex = 67
        Me.lblPayeeName.Text = "Payee Name"
        '
        'stbRefundAmountWords
        '
        Me.stbRefundAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundAmountWords.CapitalizeFirstLetter = False
        Me.stbRefundAmountWords.EntryErrorMSG = ""
        Me.stbRefundAmountWords.Location = New System.Drawing.Point(693, 88)
        Me.stbRefundAmountWords.MaxLength = 200
        Me.stbRefundAmountWords.Multiline = True
        Me.stbRefundAmountWords.Name = "stbRefundAmountWords"
        Me.stbRefundAmountWords.ReadOnly = True
        Me.stbRefundAmountWords.RegularExpression = ""
        Me.stbRefundAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundAmountWords.Size = New System.Drawing.Size(190, 38)
        Me.stbRefundAmountWords.TabIndex = 88
        '
        'lblRefundAmountWords
        '
        Me.lblRefundAmountWords.Location = New System.Drawing.Point(477, 99)
        Me.lblRefundAmountWords.Name = "lblRefundAmountWords"
        Me.lblRefundAmountWords.Size = New System.Drawing.Size(169, 20)
        Me.lblRefundAmountWords.TabIndex = 85
        Me.lblRefundAmountWords.Text = "Amount in Words"
        '
        'lblRefundReceiptNo
        '
        Me.lblRefundReceiptNo.Location = New System.Drawing.Point(18, 32)
        Me.lblRefundReceiptNo.Name = "lblRefundReceiptNo"
        Me.lblRefundReceiptNo.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundReceiptNo.TabIndex = 65
        Me.lblRefundReceiptNo.Text = "Refund Receipt No"
        '
        'stbRefundReceiptNo
        '
        Me.stbRefundReceiptNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundReceiptNo.CapitalizeFirstLetter = False
        Me.stbRefundReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRefundReceiptNo.EntryErrorMSG = ""
        Me.stbRefundReceiptNo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.stbRefundReceiptNo.Location = New System.Drawing.Point(189, 27)
        Me.stbRefundReceiptNo.MaxLength = 20
        Me.stbRefundReceiptNo.Name = "stbRefundReceiptNo"
        Me.stbRefundReceiptNo.ReadOnly = True
        Me.stbRefundReceiptNo.RegularExpression = ""
        Me.stbRefundReceiptNo.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundReceiptNo.TabIndex = 66
        '
        'lblRefundNo
        '
        Me.lblRefundNo.Location = New System.Drawing.Point(477, 4)
        Me.lblRefundNo.Name = "lblRefundNo"
        Me.lblRefundNo.Size = New System.Drawing.Size(169, 20)
        Me.lblRefundNo.TabIndex = 79
        Me.lblRefundNo.Text = "Refund No"
        '
        'stbRefundNo
        '
        Me.stbRefundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundNo.CapitalizeFirstLetter = False
        Me.stbRefundNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRefundNo.EntryErrorMSG = ""
        Me.stbRefundNo.Location = New System.Drawing.Point(693, 1)
        Me.stbRefundNo.MaxLength = 20
        Me.stbRefundNo.Name = "stbRefundNo"
        Me.stbRefundNo.RegularExpression = ""
        Me.stbRefundNo.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundNo.TabIndex = 80
        '
        'lblRefundNotes
        '
        Me.lblRefundNotes.Location = New System.Drawing.Point(477, 142)
        Me.lblRefundNotes.Name = "lblRefundNotes"
        Me.lblRefundNotes.Size = New System.Drawing.Size(169, 20)
        Me.lblRefundNotes.TabIndex = 87
        Me.lblRefundNotes.Text = "Notes"
        '
        'lblRefundAmount
        '
        Me.lblRefundAmount.Location = New System.Drawing.Point(477, 70)
        Me.lblRefundAmount.Name = "lblRefundAmount"
        Me.lblRefundAmount.Size = New System.Drawing.Size(169, 20)
        Me.lblRefundAmount.TabIndex = 83
        Me.lblRefundAmount.Text = "Total Refunded Amount"
        '
        'stbRefundNotes
        '
        Me.stbRefundNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundNotes.CapitalizeFirstLetter = True
        Me.stbRefundNotes.EntryErrorMSG = ""
        Me.stbRefundNotes.Location = New System.Drawing.Point(693, 127)
        Me.stbRefundNotes.MaxLength = 200
        Me.stbRefundNotes.Multiline = True
        Me.stbRefundNotes.Name = "stbRefundNotes"
        Me.stbRefundNotes.RegularExpression = ""
        Me.stbRefundNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundNotes.Size = New System.Drawing.Size(190, 50)
        Me.stbRefundNotes.TabIndex = 90
        '
        'nbxTotalRefundAmount
        '
        Me.nbxTotalRefundAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxTotalRefundAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTotalRefundAmount.ControlCaption = "To-Refund Amount"
        Me.nbxTotalRefundAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxTotalRefundAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxTotalRefundAmount.DecimalPlaces = -1
        Me.nbxTotalRefundAmount.DenyNegativeEntryValue = True
        Me.nbxTotalRefundAmount.Location = New System.Drawing.Point(693, 67)
        Me.nbxTotalRefundAmount.MaxValue = 0.0R
        Me.nbxTotalRefundAmount.MinValue = 0.0R
        Me.nbxTotalRefundAmount.MustEnterNumeric = True
        Me.nbxTotalRefundAmount.Name = "nbxTotalRefundAmount"
        Me.nbxTotalRefundAmount.ReadOnly = True
        Me.nbxTotalRefundAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxTotalRefundAmount.TabIndex = 86
        Me.nbxTotalRefundAmount.Value = ""
        '
        'dtpRefundDate
        '
        Me.dtpRefundDate.Location = New System.Drawing.Point(693, 22)
        Me.dtpRefundDate.Name = "dtpRefundDate"
        Me.dtpRefundDate.ShowCheckBox = True
        Me.dtpRefundDate.Size = New System.Drawing.Size(190, 20)
        Me.dtpRefundDate.TabIndex = 82
        '
        'lblRefundDate
        '
        Me.lblRefundDate.Location = New System.Drawing.Point(477, 25)
        Me.lblRefundDate.Name = "lblRefundDate"
        Me.lblRefundDate.Size = New System.Drawing.Size(169, 20)
        Me.lblRefundDate.TabIndex = 81
        Me.lblRefundDate.Text = "Refund Date"
        '
        'tpgExpenditure
        '
        Me.tpgExpenditure.Controls.Add(Me.cboCurrency)
        Me.tpgExpenditure.Controls.Add(Me.lblCurrency)
        Me.tpgExpenditure.Controls.Add(Me.lblAmountWithdrawn)
        Me.tpgExpenditure.Controls.Add(Me.nbxAmountWithdrawn)
        Me.tpgExpenditure.Controls.Add(Me.btnExRate)
        Me.tpgExpenditure.Controls.Add(Me.nbxExchange)
        Me.tpgExpenditure.Controls.Add(Me.Label2)
        Me.tpgExpenditure.Controls.Add(Me.cboAccountNames)
        Me.tpgExpenditure.Controls.Add(Me.nbxMaxAmount)
        Me.tpgExpenditure.Controls.Add(Me.lblMaxAmount)
        Me.tpgExpenditure.Controls.Add(Me.lblAccount)
        Me.tpgExpenditure.Controls.Add(Me.cboBankID)
        Me.tpgExpenditure.Controls.Add(Me.lblBankID)
        Me.tpgExpenditure.Controls.Add(Me.cboExpenditureSourceType)
        Me.tpgExpenditure.Controls.Add(Me.lblExpenditureSourceType)
        Me.tpgExpenditure.Controls.Add(Me.lblEXDocumentNo)
        Me.tpgExpenditure.Controls.Add(Me.stbEXDocumentNo)
        Me.tpgExpenditure.Controls.Add(Me.lblExpenditureNo)
        Me.tpgExpenditure.Controls.Add(Me.stbExpenditureNo)
        Me.tpgExpenditure.Controls.Add(Me.stbGivenTo)
        Me.tpgExpenditure.Controls.Add(Me.lblGivenTo)
        Me.tpgExpenditure.Controls.Add(Me.stbEXDetails)
        Me.tpgExpenditure.Controls.Add(Me.lblEXDetails)
        Me.tpgExpenditure.Controls.Add(Me.lblEXAmount)
        Me.tpgExpenditure.Controls.Add(Me.nbxEXAmount)
        Me.tpgExpenditure.Controls.Add(Me.cboExpenditureCategoryID)
        Me.tpgExpenditure.Controls.Add(Me.lblExpenditureCategoryID)
        Me.tpgExpenditure.Controls.Add(Me.dtpSpentDate)
        Me.tpgExpenditure.Controls.Add(Me.lblSpentDate)
        Me.tpgExpenditure.Location = New System.Drawing.Point(4, 22)
        Me.tpgExpenditure.Name = "tpgExpenditure"
        Me.tpgExpenditure.Size = New System.Drawing.Size(894, 482)
        Me.tpgExpenditure.TabIndex = 3
        Me.tpgExpenditure.Tag = "Expenditure"
        Me.tpgExpenditure.Text = "Expenditure"
        Me.tpgExpenditure.UseVisualStyleBackColor = True
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrency.Location = New System.Drawing.Point(215, 185)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(190, 21)
        Me.cboCurrency.TabIndex = 48
        '
        'lblCurrency
        '
        Me.lblCurrency.Location = New System.Drawing.Point(17, 183)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(156, 20)
        Me.lblCurrency.TabIndex = 47
        Me.lblCurrency.Text = "Currency"
        '
        'lblAmountWithdrawn
        '
        Me.lblAmountWithdrawn.Location = New System.Drawing.Point(17, 242)
        Me.lblAmountWithdrawn.Name = "lblAmountWithdrawn"
        Me.lblAmountWithdrawn.Size = New System.Drawing.Size(122, 20)
        Me.lblAmountWithdrawn.TabIndex = 45
        Me.lblAmountWithdrawn.Text = "Amount"
        '
        'nbxAmountWithdrawn
        '
        Me.nbxAmountWithdrawn.BackColor = System.Drawing.Color.White
        Me.nbxAmountWithdrawn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountWithdrawn.ControlCaption = "Amount"
        Me.nbxAmountWithdrawn.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAmountWithdrawn.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmountWithdrawn.DecimalPlaces = -1
        Me.nbxAmountWithdrawn.DenyNegativeEntryValue = True
        Me.nbxAmountWithdrawn.Location = New System.Drawing.Point(215, 242)
        Me.nbxAmountWithdrawn.MaxValue = 0.0R
        Me.nbxAmountWithdrawn.MinValue = 0.0R
        Me.nbxAmountWithdrawn.MustEnterNumeric = True
        Me.nbxAmountWithdrawn.Name = "nbxAmountWithdrawn"
        Me.nbxAmountWithdrawn.Size = New System.Drawing.Size(190, 20)
        Me.nbxAmountWithdrawn.TabIndex = 54
        Me.nbxAmountWithdrawn.Value = ""
        '
        'btnExRate
        '
        Me.btnExRate.Enabled = False
        Me.btnExRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnExRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExRate.Image = CType(resources.GetObject("btnExRate.Image"), System.Drawing.Image)
        Me.btnExRate.Location = New System.Drawing.Point(181, 212)
        Me.btnExRate.Name = "btnExRate"
        Me.btnExRate.Size = New System.Drawing.Size(27, 21)
        Me.btnExRate.TabIndex = 41
        Me.btnExRate.Tag = "ExchangeRates"
        '
        'nbxExchange
        '
        Me.nbxExchange.BackColor = System.Drawing.SystemColors.Info
        Me.nbxExchange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxExchange.ControlCaption = "Exchange Rate"
        Me.nbxExchange.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxExchange.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxExchange.DecimalPlaces = -1
        Me.nbxExchange.DenyZeroEntryValue = True
        Me.nbxExchange.Location = New System.Drawing.Point(215, 213)
        Me.nbxExchange.MaxValue = 0.0R
        Me.nbxExchange.MinValue = 0.0R
        Me.nbxExchange.MustEnterNumeric = True
        Me.nbxExchange.Name = "nbxExchange"
        Me.nbxExchange.Size = New System.Drawing.Size(190, 20)
        Me.nbxExchange.TabIndex = 50
        Me.nbxExchange.Value = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 215)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Exchange Rate"
        '
        'cboAccountNames
        '
        Me.cboAccountNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountNames.Enabled = False
        Me.cboAccountNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNames.Location = New System.Drawing.Point(215, 132)
        Me.cboAccountNames.Name = "cboAccountNames"
        Me.cboAccountNames.Size = New System.Drawing.Size(190, 21)
        Me.cboAccountNames.TabIndex = 22
        '
        'nbxMaxAmount
        '
        Me.nbxMaxAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxMaxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMaxAmount.CapitalizeFirstLetter = True
        Me.nbxMaxAmount.EntryErrorMSG = ""
        Me.nbxMaxAmount.Location = New System.Drawing.Point(215, 159)
        Me.nbxMaxAmount.MaxLength = 40
        Me.nbxMaxAmount.Name = "nbxMaxAmount"
        Me.nbxMaxAmount.ReadOnly = True
        Me.nbxMaxAmount.RegularExpression = ""
        Me.nbxMaxAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxMaxAmount.TabIndex = 20
        '
        'lblMaxAmount
        '
        Me.lblMaxAmount.Location = New System.Drawing.Point(17, 159)
        Me.lblMaxAmount.Name = "lblMaxAmount"
        Me.lblMaxAmount.Size = New System.Drawing.Size(122, 20)
        Me.lblMaxAmount.TabIndex = 21
        Me.lblMaxAmount.Text = "Maximum Amount"
        '
        'lblAccount
        '
        Me.lblAccount.Location = New System.Drawing.Point(17, 132)
        Me.lblAccount.Name = "lblAccount"
        Me.lblAccount.Size = New System.Drawing.Size(156, 21)
        Me.lblAccount.TabIndex = 18
        Me.lblAccount.Text = "Account"
        '
        'cboBankID
        '
        Me.cboBankID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBankID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBankID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankID.Enabled = False
        Me.cboBankID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBankID.FormattingEnabled = True
        Me.cboBankID.Location = New System.Drawing.Point(215, 105)
        Me.cboBankID.Name = "cboBankID"
        Me.cboBankID.Size = New System.Drawing.Size(190, 21)
        Me.cboBankID.TabIndex = 17
        '
        'lblBankID
        '
        Me.lblBankID.Location = New System.Drawing.Point(17, 105)
        Me.lblBankID.Name = "lblBankID"
        Me.lblBankID.Size = New System.Drawing.Size(156, 21)
        Me.lblBankID.TabIndex = 16
        Me.lblBankID.Text = "Bank"
        '
        'cboExpenditureSourceType
        '
        Me.cboExpenditureSourceType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboExpenditureSourceType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExpenditureSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpenditureSourceType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExpenditureSourceType.FormattingEnabled = True
        Me.cboExpenditureSourceType.Location = New System.Drawing.Point(215, 78)
        Me.cboExpenditureSourceType.Name = "cboExpenditureSourceType"
        Me.cboExpenditureSourceType.Size = New System.Drawing.Size(190, 21)
        Me.cboExpenditureSourceType.TabIndex = 15
        '
        'lblExpenditureSourceType
        '
        Me.lblExpenditureSourceType.Location = New System.Drawing.Point(17, 78)
        Me.lblExpenditureSourceType.Name = "lblExpenditureSourceType"
        Me.lblExpenditureSourceType.Size = New System.Drawing.Size(156, 21)
        Me.lblExpenditureSourceType.TabIndex = 14
        Me.lblExpenditureSourceType.Text = "Expenditure Source Type"
        '
        'lblEXDocumentNo
        '
        Me.lblEXDocumentNo.Location = New System.Drawing.Point(17, 316)
        Me.lblEXDocumentNo.Name = "lblEXDocumentNo"
        Me.lblEXDocumentNo.Size = New System.Drawing.Size(122, 21)
        Me.lblEXDocumentNo.TabIndex = 10
        Me.lblEXDocumentNo.Text = "Document No"
        '
        'stbEXDocumentNo
        '
        Me.stbEXDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEXDocumentNo.CapitalizeFirstLetter = False
        Me.stbEXDocumentNo.EntryErrorMSG = ""
        Me.stbEXDocumentNo.Location = New System.Drawing.Point(215, 316)
        Me.stbEXDocumentNo.MaxLength = 20
        Me.stbEXDocumentNo.Name = "stbEXDocumentNo"
        Me.stbEXDocumentNo.RegularExpression = ""
        Me.stbEXDocumentNo.Size = New System.Drawing.Size(190, 20)
        Me.stbEXDocumentNo.TabIndex = 60
        '
        'lblExpenditureNo
        '
        Me.lblExpenditureNo.Location = New System.Drawing.Point(17, 7)
        Me.lblExpenditureNo.Name = "lblExpenditureNo"
        Me.lblExpenditureNo.Size = New System.Drawing.Size(122, 20)
        Me.lblExpenditureNo.TabIndex = 0
        Me.lblExpenditureNo.Text = "Expenditure No"
        '
        'stbExpenditureNo
        '
        Me.stbExpenditureNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExpenditureNo.CapitalizeFirstLetter = False
        Me.stbExpenditureNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbExpenditureNo.EntryErrorMSG = ""
        Me.stbExpenditureNo.Location = New System.Drawing.Point(215, 7)
        Me.stbExpenditureNo.MaxLength = 20
        Me.stbExpenditureNo.Name = "stbExpenditureNo"
        Me.stbExpenditureNo.RegularExpression = ""
        Me.stbExpenditureNo.Size = New System.Drawing.Size(190, 20)
        Me.stbExpenditureNo.TabIndex = 1
        '
        'stbGivenTo
        '
        Me.stbGivenTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGivenTo.CapitalizeFirstLetter = True
        Me.stbGivenTo.EntryErrorMSG = ""
        Me.stbGivenTo.Location = New System.Drawing.Point(215, 290)
        Me.stbGivenTo.MaxLength = 40
        Me.stbGivenTo.Name = "stbGivenTo"
        Me.stbGivenTo.RegularExpression = ""
        Me.stbGivenTo.Size = New System.Drawing.Size(190, 20)
        Me.stbGivenTo.TabIndex = 58
        '
        'lblGivenTo
        '
        Me.lblGivenTo.Location = New System.Drawing.Point(17, 290)
        Me.lblGivenTo.Name = "lblGivenTo"
        Me.lblGivenTo.Size = New System.Drawing.Size(122, 20)
        Me.lblGivenTo.TabIndex = 6
        Me.lblGivenTo.Text = "Given To"
        '
        'stbEXDetails
        '
        Me.stbEXDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEXDetails.CapitalizeFirstLetter = True
        Me.stbEXDetails.EntryErrorMSG = ""
        Me.stbEXDetails.Location = New System.Drawing.Point(215, 342)
        Me.stbEXDetails.MaxLength = 100
        Me.stbEXDetails.Multiline = True
        Me.stbEXDetails.Name = "stbEXDetails"
        Me.stbEXDetails.RegularExpression = ""
        Me.stbEXDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbEXDetails.Size = New System.Drawing.Size(190, 63)
        Me.stbEXDetails.TabIndex = 62
        '
        'lblEXDetails
        '
        Me.lblEXDetails.Location = New System.Drawing.Point(17, 344)
        Me.lblEXDetails.Name = "lblEXDetails"
        Me.lblEXDetails.Size = New System.Drawing.Size(122, 21)
        Me.lblEXDetails.TabIndex = 12
        Me.lblEXDetails.Text = "Details"
        '
        'lblEXAmount
        '
        Me.lblEXAmount.Location = New System.Drawing.Point(17, 268)
        Me.lblEXAmount.Name = "lblEXAmount"
        Me.lblEXAmount.Size = New System.Drawing.Size(122, 20)
        Me.lblEXAmount.TabIndex = 8
        Me.lblEXAmount.Text = "Amount In UGX"
        '
        'nbxEXAmount
        '
        Me.nbxEXAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxEXAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxEXAmount.ControlCaption = "Amount"
        Me.nbxEXAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxEXAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxEXAmount.DecimalPlaces = -1
        Me.nbxEXAmount.DenyNegativeEntryValue = True
        Me.nbxEXAmount.Location = New System.Drawing.Point(215, 268)
        Me.nbxEXAmount.MaxValue = 0.0R
        Me.nbxEXAmount.MinValue = 0.0R
        Me.nbxEXAmount.MustEnterNumeric = True
        Me.nbxEXAmount.Name = "nbxEXAmount"
        Me.nbxEXAmount.ReadOnly = True
        Me.nbxEXAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxEXAmount.TabIndex = 56
        Me.nbxEXAmount.Value = ""
        '
        'cboExpenditureCategoryID
        '
        Me.cboExpenditureCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboExpenditureCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExpenditureCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpenditureCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExpenditureCategoryID.FormattingEnabled = True
        Me.cboExpenditureCategoryID.Location = New System.Drawing.Point(215, 51)
        Me.cboExpenditureCategoryID.Name = "cboExpenditureCategoryID"
        Me.cboExpenditureCategoryID.Size = New System.Drawing.Size(190, 21)
        Me.cboExpenditureCategoryID.TabIndex = 5
        '
        'lblExpenditureCategoryID
        '
        Me.lblExpenditureCategoryID.Location = New System.Drawing.Point(17, 51)
        Me.lblExpenditureCategoryID.Name = "lblExpenditureCategoryID"
        Me.lblExpenditureCategoryID.Size = New System.Drawing.Size(122, 21)
        Me.lblExpenditureCategoryID.TabIndex = 4
        Me.lblExpenditureCategoryID.Text = "Expenditure Category"
        '
        'dtpSpentDate
        '
        Me.dtpSpentDate.Location = New System.Drawing.Point(215, 28)
        Me.dtpSpentDate.Name = "dtpSpentDate"
        Me.dtpSpentDate.ShowCheckBox = True
        Me.dtpSpentDate.Size = New System.Drawing.Size(190, 20)
        Me.dtpSpentDate.TabIndex = 3
        '
        'lblSpentDate
        '
        Me.lblSpentDate.Location = New System.Drawing.Point(17, 28)
        Me.lblSpentDate.Name = "lblSpentDate"
        Me.lblSpentDate.Size = New System.Drawing.Size(122, 20)
        Me.lblSpentDate.TabIndex = 2
        Me.lblSpentDate.Text = "Spent Date"
        '
        'btnAddExtraBill
        '
        Me.btnAddExtraBill.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddExtraBill.Enabled = False
        Me.btnAddExtraBill.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddExtraBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddExtraBill.Location = New System.Drawing.Point(181, 526)
        Me.btnAddExtraBill.Name = "btnAddExtraBill"
        Me.btnAddExtraBill.Size = New System.Drawing.Size(121, 23)
        Me.btnAddExtraBill.TabIndex = 2
        Me.btnAddExtraBill.Tag = "ExtraCharge"
        Me.btnAddExtraBill.Text = "Add Extra Charge"
        Me.btnAddExtraBill.UseVisualStyleBackColor = True
        '
        'chkPrintReceiptOnSaving
        '
        Me.chkPrintReceiptOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintReceiptOnSaving.AutoSize = True
        Me.chkPrintReceiptOnSaving.Checked = True
        Me.chkPrintReceiptOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintReceiptOnSaving.Location = New System.Drawing.Point(12, 533)
        Me.chkPrintReceiptOnSaving.Name = "chkPrintReceiptOnSaving"
        Me.chkPrintReceiptOnSaving.Size = New System.Drawing.Size(143, 17)
        Me.chkPrintReceiptOnSaving.TabIndex = 1
        Me.chkPrintReceiptOnSaving.Text = " Print Receipt On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(801, 526)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(104, 24)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Print"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(12, 556)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 24)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Tag = "Payments"
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(801, 556)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 24)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "&Close"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(468, 526)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(109, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Tag = "Items"
        Me.btnEdit.Text = "&Edit"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(150, 551)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 8
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateVisits.Name = "chkNavigateVisits"
        Me.chkNavigateVisits.Size = New System.Drawing.Size(144, 20)
        Me.chkNavigateVisits.TabIndex = 0
        Me.chkNavigateVisits.Text = "Navigate Patient Visits"
        '
        'navVisits
        '
        Me.navVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navVisits.ColumnName = "VisitNo"
        Me.navVisits.DataSource = Nothing
        Me.navVisits.Location = New System.Drawing.Point(171, 2)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'btnManageAccounts
        '
        Me.btnManageAccounts.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnManageAccounts.Enabled = False
        Me.btnManageAccounts.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageAccounts.Location = New System.Drawing.Point(583, 526)
        Me.btnManageAccounts.Name = "btnManageAccounts"
        Me.btnManageAccounts.Size = New System.Drawing.Size(146, 23)
        Me.btnManageAccounts.TabIndex = 5
        Me.btnManageAccounts.Tag = "Accounts"
        Me.btnManageAccounts.Text = "Manage Cash Account"
        Me.btnManageAccounts.UseVisualStyleBackColor = True
        '
        'btnSelfRequests
        '
        Me.btnSelfRequests.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSelfRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSelfRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelfRequests.Location = New System.Drawing.Point(323, 526)
        Me.btnSelfRequests.Name = "btnSelfRequests"
        Me.btnSelfRequests.Size = New System.Drawing.Size(139, 23)
        Me.btnSelfRequests.TabIndex = 3
        Me.btnSelfRequests.Tag = "SelfRequests"
        Me.btnSelfRequests.Text = "&Self Requests"
        '
        'frmCashier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(917, 594)
        Me.Controls.Add(Me.btnSelfRequests)
        Me.Controls.Add(Me.btnManageAccounts)
        Me.Controls.Add(Me.btnAddExtraBill)
        Me.Controls.Add(Me.chkPrintReceiptOnSaving)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tbcCashier)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCashier"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cashier"
        Me.tbcCashier.ResumeLayout(False)
        Me.tpgCashPayment.ResumeLayout(False)
        Me.tpgCashPayment.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlAlerts.PerformLayout()
        Me.grpPaymentDetails.ResumeLayout(False)
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPayments.ResumeLayout(False)
        Me.tpgBillFormPayment.ResumeLayout(False)
        Me.tpgBillFormPayment.PerformLayout()
        Me.tbcBillFormPayment.ResumeLayout(False)
        Me.tpgBillingForm.ResumeLayout(False)
        CType(Me.dgvPaymentExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPendingBill.ResumeLayout(False)
        CType(Me.dgvPendingBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgBillsPayment.ResumeLayout(False)
        Me.tpgBillsPayment.PerformLayout()
        Me.grpBPSetParameters.ResumeLayout(False)
        Me.pnlBPPeriod.ResumeLayout(False)
        Me.grpBillsPayment.ResumeLayout(False)
        CType(Me.dgvBillsPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgCreditBillFormPayment.ResumeLayout(False)
        Me.tpgCreditBillFormPayment.PerformLayout()
        Me.grpCBFPExtraBillItems.ResumeLayout(False)
        CType(Me.dgvCBFPExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCBFPSetParameters.ResumeLayout(False)
        Me.pnlCBFPPeriod.ResumeLayout(False)
        Me.tpgManageAccounts.ResumeLayout(False)
        Me.tpgManageAccounts.PerformLayout()
        Me.tpgOtherIncome.ResumeLayout(False)
        Me.tpgOtherIncome.PerformLayout()
        Me.tpgRefunds.ResumeLayout(False)
        Me.tpgRefunds.PerformLayout()
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgExpenditure.ResumeLayout(False)
        Me.tpgExpenditure.PerformLayout()
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbcCashier As System.Windows.Forms.TabControl
    Friend WithEvents tpgCashPayment As System.Windows.Forms.TabPage
    Friend WithEvents tpgBillsPayment As System.Windows.Forms.TabPage
    Friend WithEvents stbTotalAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents grpPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPayModes As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblPayDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents chkPrintReceiptOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents tpgOtherIncome As System.Windows.Forms.TabPage
    Friend WithEvents tpgExpenditure As System.Windows.Forms.TabPage
    Friend WithEvents lblOINotes As System.Windows.Forms.Label
    Friend WithEvents lblOIAmount As System.Windows.Forms.Label
    Friend WithEvents stbOINotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboIncomeSourcesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblIncomeSourcesID As System.Windows.Forms.Label
    Friend WithEvents dtpIncomeDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIncomeDate As System.Windows.Forms.Label
    Friend WithEvents stbGivenTo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGivenTo As System.Windows.Forms.Label
    Friend WithEvents stbEXDetails As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEXDetails As System.Windows.Forms.Label
    Friend WithEvents lblEXAmount As System.Windows.Forms.Label
    Friend WithEvents nbxEXAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboExpenditureCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblExpenditureCategoryID As System.Windows.Forms.Label
    Friend WithEvents dtpSpentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSpentDate As System.Windows.Forms.Label
    Friend WithEvents grpBillsPayment As System.Windows.Forms.GroupBox
    Friend WithEvents stbBPBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBPBillAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBPBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblBPBillAccountNo As System.Windows.Forms.Label
    Friend WithEvents dgvBillsPayment As System.Windows.Forms.DataGridView
    Friend WithEvents stbBPTotalBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblBPChequeNo As System.Windows.Forms.Label
    Friend WithEvents stbBPDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBPNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPNotes As System.Windows.Forms.Label
    Friend WithEvents cboBPPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBPPayModes As System.Windows.Forms.Label
    Friend WithEvents lblBPVisitNo As System.Windows.Forms.Label
    Friend WithEvents ckcInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stbBPAccountBalance As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents tpgManageAccounts As System.Windows.Forms.TabPage
    Friend WithEvents nbxAccountAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents cboAccountPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountPayModes As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblAccountDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountNotes As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblIncomeNo As System.Windows.Forms.Label
    Friend WithEvents stbIncomeNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureNo As System.Windows.Forms.Label
    Friend WithEvents stbExpenditureNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPAmountWords As System.Windows.Forms.Label
    Friend WithEvents lblBPReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbBPReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingCashPayment As System.Windows.Forms.Button
    Friend WithEvents btnLoadPendingBillsPayment As System.Windows.Forms.Button
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnWaitingCashPayments As System.Windows.Forms.Button
    Friend WithEvents lblAlertMessage As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillModesID As System.Windows.Forms.Label
    Friend WithEvents cboAccountActionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountActionID As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents chkUseAccountBalance As System.Windows.Forms.CheckBox
    Friend WithEvents lblAccountTranNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountTranNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents btnAddExtraBill As System.Windows.Forms.Button
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents btnPayingVisits As System.Windows.Forms.Button
    Friend WithEvents btnManageAccounts As System.Windows.Forms.Button
    Friend WithEvents btnSelfRequests As System.Windows.Forms.Button
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents nbxAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmountTendered As System.Windows.Forms.Label
    Friend WithEvents nbxExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblExchangeRate As System.Windows.Forms.Label
    Friend WithEvents stbChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblChange As System.Windows.Forms.Label
    Friend WithEvents chkSendBalanceToAccount As System.Windows.Forms.CheckBox
    Friend WithEvents grpBPSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlBPPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpBPEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpBPStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents rdoBPGetPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents rdoBPGetAll As System.Windows.Forms.RadioButton
    Friend WithEvents lblBPRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cboBPBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBPBillModesID As System.Windows.Forms.Label
    Friend WithEvents stbBPChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPChange As System.Windows.Forms.Label
    Friend WithEvents nbxBPAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxBPExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBPAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblBPExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboBPCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBPCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents chkBPUseAccountBalance As System.Windows.Forms.CheckBox
    Friend WithEvents chkBPSendBalanceToAccount As System.Windows.Forms.CheckBox
    Friend WithEvents cmsPayments As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPaymentsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPaymentsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPaymentsAddExtraCharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbBPCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBPCompanyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBPCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblBPCompanyNo As System.Windows.Forms.Label
    Friend WithEvents stbBPVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnBPFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents tpgBillFormPayment As System.Windows.Forms.TabPage
    Friend WithEvents chkBFPSendBalanceToAccount As System.Windows.Forms.CheckBox
    Friend WithEvents stbBFPChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPChange As System.Windows.Forms.Label
    Friend WithEvents nbxBFPAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxBFPExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBFPAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblBFPExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboBFPCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBFPCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents stbBFPBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPBillMode As System.Windows.Forms.Label
    Friend WithEvents nbxBFPCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBFPCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxBFPCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBFPCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbBFPCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPCoPayType As System.Windows.Forms.Label
    Friend WithEvents chkBFPUseAccountBalance As System.Windows.Forms.CheckBox
    Friend WithEvents nbxBFPCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBFPCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents stbBFPVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxBFPOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBFPOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingBFPayment As System.Windows.Forms.Button
    Friend WithEvents stbBFPPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBFPVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnBFPFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbBFPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbBFPTotalAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblBFPDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbBFPDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBFPPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpBFPPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBFPReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbBFPReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPPayModes As System.Windows.Forms.Label
    Friend WithEvents stbBFPNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBFPFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPFullName As System.Windows.Forms.Label
    Friend WithEvents lblBFPNotes As System.Windows.Forms.Label
    Friend WithEvents lblBFPPayDate As System.Windows.Forms.Label
    Friend WithEvents lblBFPVisitNo As System.Windows.Forms.Label
    Friend WithEvents btnPayingExtraBills As System.Windows.Forms.Button
    Friend WithEvents tpgRefunds As System.Windows.Forms.TabPage
    Friend WithEvents cboOIPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblOIPayModes As System.Windows.Forms.Label
    Friend WithEvents lblOIDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbOIDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tpgCreditBillFormPayment As System.Windows.Forms.TabPage
    Friend WithEvents btnCBFPFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbCBFPVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbCBFPCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboCBFPCompanyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblCBFPCompanyNo As System.Windows.Forms.Label
    Friend WithEvents chkCBFPUseAccountBalance As System.Windows.Forms.CheckBox
    Friend WithEvents chkCBFPSendBalanceToAccount As System.Windows.Forms.CheckBox
    Friend WithEvents stbCBFPChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCBFPChange As System.Windows.Forms.Label
    Friend WithEvents nbxCBFPAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxCBFPExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCBFPAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblCBFPExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboCBFPCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents cboCBFPBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPBillModesID As System.Windows.Forms.Label
    Friend WithEvents grpCBFPSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlCBFPPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpCBFPEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCBFPStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpCBFPStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCBFPEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnCBFPExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnCBFPLoadPendingBillsPayment As System.Windows.Forms.Button
    Friend WithEvents lblCBFPRecordsNo As System.Windows.Forms.Label
    Friend WithEvents rdoCBFPGetPeriod As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCBFPGetAll As System.Windows.Forms.RadioButton
    Friend WithEvents lblCBFPReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbCBFPReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbCBFPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCBFPAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbCBFPAccountBalance As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCBFPBalance As System.Windows.Forms.Label
    Friend WithEvents cboCBFPPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPPayModes As System.Windows.Forms.Label
    Friend WithEvents lblCBFPVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbCBFPTotalBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCBFPTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents lblCBFPChequeNo As System.Windows.Forms.Label
    Friend WithEvents stbCBFPDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbCBFPNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCBFPNotes As System.Windows.Forms.Label
    Friend WithEvents stbCBFPBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboCBFPBillAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblCBFPBillAccountNo As System.Windows.Forms.Label
    Friend WithEvents grpCBFPExtraBillItems As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCBFPExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents stbAccountChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountChange As System.Windows.Forms.Label
    Friend WithEvents nbxAccountAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblAccountExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboAccountCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents btnBFPExchangeRate As System.Windows.Forms.Button
    Friend WithEvents btnExchangeRate As System.Windows.Forms.Button
    Friend WithEvents btnBPExchangeRate As System.Windows.Forms.Button
    Friend WithEvents btnCBFPExchangeRate As System.Windows.Forms.Button
    Friend WithEvents btnAccountExchangeRate As System.Windows.Forms.Button
    Friend WithEvents lblEXDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbEXDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnOIExchangeRate As System.Windows.Forms.Button
    Friend WithEvents stbOIChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOIChange As System.Windows.Forms.Label
    Friend WithEvents nbxOIAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxOIExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOIAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblOIExchangeRate As System.Windows.Forms.Label
    Friend WithEvents nbxOIAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboOICurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblOICurrenciesID As System.Windows.Forms.Label
    Friend WithEvents cboAccountGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountGroupID As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBFPCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPCustomerName As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsPaymentsIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPaymentsIncludeNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbcBillFormPayment As System.Windows.Forms.TabControl
    Friend WithEvents tpgBillingForm As System.Windows.Forms.TabPage
    Friend WithEvents dgvPaymentExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents tpgPendingBill As System.Windows.Forms.TabPage
    Friend WithEvents dgvPendingBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents stbPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbAccountPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxMaxAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMaxAmount As Label
    Friend WithEvents lblAccount As Label
    Friend WithEvents cboBankID As ComboBox
    Friend WithEvents lblBankID As Label
    Friend WithEvents cboExpenditureSourceType As ComboBox
    Friend WithEvents lblExpenditureSourceType As Label
    Friend WithEvents cboAccountNames As ComboBox
    Friend WithEvents btnExRate As Button
    Friend WithEvents nbxExchange As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAmountWithdrawn As Label
    Friend WithEvents nbxAmountWithdrawn As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboCurrency As ComboBox
    Friend WithEvents lblCurrency As Label
    Friend WithEvents lblBFPPhoneNo As System.Windows.Forms.Label
    Friend WithEvents stbBFPPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents stbBFPInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRefundInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents stbRefundInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents stbRefundRequestNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundRequestNo As System.Windows.Forms.Label
    Friend WithEvents lblPendingRefundRequests As System.Windows.Forms.Label
    Friend WithEvents btnLoadRefundRequests As System.Windows.Forms.Button
    Friend WithEvents lblToRefundAmount As System.Windows.Forms.Label
    Friend WithEvents nbxToRefundAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxRefundOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbAmountRefunded As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountRefunded As System.Windows.Forms.Label
    Friend WithEvents nbxRefundAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundAccountBalance As System.Windows.Forms.Label
    Friend WithEvents stbRefundAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundAmountPaid As System.Windows.Forms.Label
    Friend WithEvents stbRefundPayDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundPayDate As System.Windows.Forms.Label
    Friend WithEvents stbPayeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPayeeName As System.Windows.Forms.Label
    Friend WithEvents stbRefundAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundAmountWords As System.Windows.Forms.Label
    Friend WithEvents lblRefundReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbRefundReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundNo As System.Windows.Forms.Label
    Friend WithEvents stbRefundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundNotes As System.Windows.Forms.Label
    Friend WithEvents lblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents stbRefundNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxTotalRefundAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpRefundDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRefundDate As System.Windows.Forms.Label
    Friend WithEvents colPendingBillItemsInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPendingBillItemsRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsRoundDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPendingBillItemsItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkExcludeNotInvoicedItem As System.Windows.Forms.CheckBox
    Friend WithEvents btnBPFindVisitNoByInvoiceNo As System.Windows.Forms.Button
    Friend WithEvents chkCBFPExcludeNotInvoicedItem As System.Windows.Forms.CheckBox
    Friend WithEvents btnCBFFindVisitNoByInvoiceNo As System.Windows.Forms.Button
    Friend WithEvents dgvPaymentRefunds As System.Windows.Forms.DataGridView
    Friend WithEvents colRefItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefSoldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefPaidAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coReflItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundReason As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colRefQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefNewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrevRefundedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefSalesUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcknowledgeable As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colPrevRefundedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents nbxBPGrandDiscount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblGrandDiscount As System.Windows.Forms.Label
    Friend WithEvents nbxBPWithholdingTax As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nbxCBFPGrandDiscount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCBFPGrandDiscount As System.Windows.Forms.Label
    Friend WithEvents nbxCBFPWithholdingTax As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCBFPWithholdingTax As System.Windows.Forms.Label
    Friend WithEvents btnFindReceiptNo As System.Windows.Forms.Button
    Friend WithEvents colBFPInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colBFPExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPExtraBillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCBFPPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPExtraBillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPInvoiceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPCoPayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCBFPItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colBPPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPInvoiceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPCoPayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBPItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
