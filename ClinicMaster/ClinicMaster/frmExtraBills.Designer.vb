
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExtraBills : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String, ByVal visitTypeID As String)
        MyClass.New()
        Me.keyNo = keyNo
        Me.defaultVisitType = visitTypeID
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExtraBills))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle73 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle80 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle74 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle75 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle76 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle77 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle78 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle79 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle81 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle88 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle85 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle86 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle87 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle89 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle96 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle90 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle91 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle93 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle94 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle95 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle97 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle109 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle110 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle117 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle111 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle112 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle113 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle114 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle115 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle116 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpExtraBillDate = New System.Windows.Forms.DateTimePicker()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbExtraBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExtraBillNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.btnFindExtraBillNo = New System.Windows.Forms.Button()
        Me.navExtraBills = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateExtraBills = New System.Windows.Forms.CheckBox()
        Me.pnlNavigateExtraBills = New System.Windows.Forms.Panel()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.lblExtraBillDate = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.tbcExtraBills = New System.Windows.Forms.TabControl()
        Me.tpgAdmission = New System.Windows.Forms.TabPage()
        Me.dgvAdmission = New System.Windows.Forms.DataGridView()
        Me.colAdmissionBedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionBedName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgServices = New System.Windows.Forms.TabPage()
        Me.dgvServices = New System.Windows.Forms.DataGridView()
        Me.colServiceCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colServiceQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServicePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServicesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsExtraBills = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsExtraBillsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgLaboratory = New System.Windows.Forms.TabPage()
        Me.dgvLabTests = New System.Windows.Forms.DataGridView()
        Me.colTest = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colLTQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabTestsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgRadiology = New System.Windows.Forms.TabPage()
        Me.dgvRadiology = New System.Windows.Forms.DataGridView()
        Me.colExamFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colRadiologyQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPrescriptions = New System.Windows.Forms.TabPage()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHasAlternateDrugs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDugAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgProcedures = New System.Windows.Forms.TabPage()
        Me.dgvProcedures = New System.Windows.Forms.DataGridView()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colProcedureQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedurePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProceduresSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgDental = New System.Windows.Forms.TabPage()
        Me.dgvDental = New System.Windows.Forms.DataGridView()
        Me.colDentalCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDentalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgTheatre = New System.Windows.Forms.TabPage()
        Me.dgvTheatre = New System.Windows.Forms.DataGridView()
        Me.colTheatreCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colTheatreQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatrePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOptical = New System.Windows.Forms.TabPage()
        Me.dgvOptical = New System.Windows.Forms.DataGridView()
        Me.colOpticalCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colOpticalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgMaternity = New System.Windows.Forms.TabPage()
        Me.dgvMaternity = New System.Windows.Forms.DataGridView()
        Me.colMaternityCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMaternityQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternityUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternityAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternityNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternityPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternityEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMaternitySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgICU = New System.Windows.Forms.TabPage()
        Me.dgvICU = New System.Windows.Forms.DataGridView()
        Me.colICUCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colICUQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colICUSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgExtraCharge = New System.Windows.Forms.TabPage()
        Me.dgvExtraCharge = New System.Windows.Forms.DataGridView()
        Me.colExtraItemFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colExtraChargeQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintInvoiceOnSaving = New System.Windows.Forms.CheckBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.fbnViewFullInvoice = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.pnlNavigateExtraBills.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.tbcExtraBills.SuspendLayout()
        Me.tpgAdmission.SuspendLayout()
        CType(Me.dgvAdmission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgServices.SuspendLayout()
        CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsExtraBills.SuspendLayout()
        Me.tpgLaboratory.SuspendLayout()
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgRadiology.SuspendLayout()
        CType(Me.dgvRadiology, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPrescriptions.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgProcedures.SuspendLayout()
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgDental.SuspendLayout()
        CType(Me.dgvDental, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgTheatre.SuspendLayout()
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOptical.SuspendLayout()
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgMaternity.SuspendLayout()
        CType(Me.dgvMaternity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgICU.SuspendLayout()
        CType(Me.dgvICU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgExtraCharge.SuspendLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 449)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 45
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(831, 449)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 48
        Me.fbnDelete.Tag = "ExtraBills"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 476)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 49
        Me.ebnSaveUpdate.Tag = "ExtraBills"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(142, 6)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'dtpExtraBillDate
        '
        Me.dtpExtraBillDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExtraBillDate, "ExtraBillDate")
        Me.dtpExtraBillDate.Location = New System.Drawing.Point(142, 48)
        Me.dtpExtraBillDate.Name = "dtpExtraBillDate"
        Me.dtpExtraBillDate.ShowCheckBox = True
        Me.dtpExtraBillDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpExtraBillDate.TabIndex = 8
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(740, 108)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayValue.TabIndex = 16
        Me.nbxCoPayValue.Value = ""
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(739, 151)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayPercent.TabIndex = 14
        Me.nbxCoPayPercent.Value = ""
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCoPayType, "CoPayType")
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(739, 130)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(170, 20)
        Me.stbCoPayType.TabIndex = 12
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitDate, "VisitDate")
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(740, 66)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 18
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(142, 91)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 20
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillMode, "BillMode")
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(464, 26)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(169, 20)
        Me.stbBillMode.TabIndex = 40
        '
        'stbVisitStatus
        '
        Me.stbVisitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitStatus.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitStatus, "VisitStatus")
        Me.stbVisitStatus.Enabled = False
        Me.stbVisitStatus.EntryErrorMSG = ""
        Me.stbVisitStatus.Location = New System.Drawing.Point(740, 45)
        Me.stbVisitStatus.MaxLength = 60
        Me.stbVisitStatus.Name = "stbVisitStatus"
        Me.stbVisitStatus.RegularExpression = ""
        Me.stbVisitStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitStatus.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitStatus.TabIndex = 36
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(740, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(170, 20)
        Me.stbAge.TabIndex = 34
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(740, 87)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(170, 20)
        Me.stbJoinDate.TabIndex = 32
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(740, 24)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(170, 20)
        Me.stbGender.TabIndex = 38
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(143, 112)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(169, 20)
        Me.stbFullName.TabIndex = 22
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(464, 47)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(169, 28)
        Me.stbBillCustomerName.TabIndex = 26
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillNo, "BillNo")
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(464, 5)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(169, 20)
        Me.stbBillNo.TabIndex = 24
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCashAccountBalance, "CashAccountBalance")
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(464, 135)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(169, 20)
        Me.nbxCashAccountBalance.TabIndex = 30
        Me.nbxCashAccountBalance.Value = ""
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRoundNo, "RoundNo")
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(464, 114)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.ReadOnly = True
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(169, 20)
        Me.stbRoundNo.TabIndex = 28
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(464, 76)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(169, 37)
        Me.stbInsuranceName.TabIndex = 42
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(142, 68)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(170, 21)
        Me.cboStaffNo.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(831, 476)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 52
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbExtraBillNo
        '
        Me.stbExtraBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillNo.CapitalizeFirstLetter = False
        Me.stbExtraBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbExtraBillNo.EntryErrorMSG = ""
        Me.stbExtraBillNo.Location = New System.Drawing.Point(142, 27)
        Me.stbExtraBillNo.MaxLength = 20
        Me.stbExtraBillNo.Name = "stbExtraBillNo"
        Me.stbExtraBillNo.RegularExpression = ""
        Me.stbExtraBillNo.Size = New System.Drawing.Size(170, 20)
        Me.stbExtraBillNo.TabIndex = 6
        '
        'lblExtraBillNo
        '
        Me.lblExtraBillNo.Location = New System.Drawing.Point(12, 27)
        Me.lblExtraBillNo.Name = "lblExtraBillNo"
        Me.lblExtraBillNo.Size = New System.Drawing.Size(91, 20)
        Me.lblExtraBillNo.TabIndex = 4
        Me.lblExtraBillNo.Text = "Extra Bill No"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 6)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(91, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
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
        'btnFindExtraBillNo
        '
        Me.btnFindExtraBillNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindExtraBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExtraBillNo.Image = CType(resources.GetObject("btnFindExtraBillNo.Image"), System.Drawing.Image)
        Me.btnFindExtraBillNo.Location = New System.Drawing.Point(114, 27)
        Me.btnFindExtraBillNo.Name = "btnFindExtraBillNo"
        Me.btnFindExtraBillNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindExtraBillNo.TabIndex = 5
        '
        'navExtraBills
        '
        Me.navExtraBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navExtraBills.ColumnName = "ExtraBillNo"
        Me.navExtraBills.DataSource = Nothing
        Me.navExtraBills.Location = New System.Drawing.Point(15, 28)
        Me.navExtraBills.Name = "navExtraBills"
        Me.navExtraBills.NavAllEnabled = False
        Me.navExtraBills.NavLeftEnabled = False
        Me.navExtraBills.NavRightEnabled = False
        Me.navExtraBills.Size = New System.Drawing.Size(413, 32)
        Me.navExtraBills.TabIndex = 1
        '
        'chkNavigateExtraBills
        '
        Me.chkNavigateExtraBills.AccessibleDescription = ""
        Me.chkNavigateExtraBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateExtraBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateExtraBills.Location = New System.Drawing.Point(154, 3)
        Me.chkNavigateExtraBills.Name = "chkNavigateExtraBills"
        Me.chkNavigateExtraBills.Size = New System.Drawing.Size(161, 20)
        Me.chkNavigateExtraBills.TabIndex = 0
        Me.chkNavigateExtraBills.Text = "Navigate Extra Bills"
        '
        'pnlNavigateExtraBills
        '
        Me.pnlNavigateExtraBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateExtraBills.Controls.Add(Me.navExtraBills)
        Me.pnlNavigateExtraBills.Controls.Add(Me.chkNavigateExtraBills)
        Me.pnlNavigateExtraBills.Location = New System.Drawing.Point(274, 443)
        Me.pnlNavigateExtraBills.Name = "pnlNavigateExtraBills"
        Me.pnlNavigateExtraBills.Size = New System.Drawing.Size(443, 64)
        Me.pnlNavigateExtraBills.TabIndex = 47
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(114, 5)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(268, 2)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'lblExtraBillDate
        '
        Me.lblExtraBillDate.Location = New System.Drawing.Point(12, 48)
        Me.lblExtraBillDate.Name = "lblExtraBillDate"
        Me.lblExtraBillDate.Size = New System.Drawing.Size(124, 20)
        Me.lblExtraBillDate.TabIndex = 7
        Me.lblExtraBillDate.Text = "Extra Bill Date"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(642, 109)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(92, 20)
        Me.lblCoPayValue.TabIndex = 15
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(642, 152)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(92, 20)
        Me.lblCoPayPercent.TabIndex = 13
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(642, 130)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(92, 20)
        Me.lblCoPayType.TabIndex = 11
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(12, 91)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 19
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(642, 68)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(92, 20)
        Me.lblVisitDate.TabIndex = 17
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(320, 29)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(137, 18)
        Me.lblBillMode.TabIndex = 39
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(642, 47)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(92, 18)
        Me.lblVisitStatus.TabIndex = 35
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(642, 89)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(92, 18)
        Me.lblJoinDate.TabIndex = 31
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(642, 5)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(92, 18)
        Me.lblAge.TabIndex = 33
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(642, 26)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(92, 18)
        Me.lblGenderID.TabIndex = 37
        Me.lblGenderID.Text = "Gender"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(12, 110)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(91, 20)
        Me.lblFullName.TabIndex = 21
        Me.lblFullName.Text = "Full Name"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(320, 52)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(137, 20)
        Me.lblBillCustomerName.TabIndex = 25
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(320, 7)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(137, 20)
        Me.lblBillNo.TabIndex = 23
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(5, 173)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(905, 41)
        Me.pnlBill.TabIndex = 43
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(313, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(137, 20)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(137, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(170, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(459, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(443, 34)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(7, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(124, 20)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Admission"
        '
        'tbcExtraBills
        '
        Me.tbcExtraBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcExtraBills.Controls.Add(Me.tpgAdmission)
        Me.tbcExtraBills.Controls.Add(Me.tpgServices)
        Me.tbcExtraBills.Controls.Add(Me.tpgLaboratory)
        Me.tbcExtraBills.Controls.Add(Me.tpgRadiology)
        Me.tbcExtraBills.Controls.Add(Me.tpgPrescriptions)
        Me.tbcExtraBills.Controls.Add(Me.tpgProcedures)
        Me.tbcExtraBills.Controls.Add(Me.tpgDental)
        Me.tbcExtraBills.Controls.Add(Me.tpgTheatre)
        Me.tbcExtraBills.Controls.Add(Me.tpgOptical)
        Me.tbcExtraBills.Controls.Add(Me.tpgMaternity)
        Me.tbcExtraBills.Controls.Add(Me.tpgICU)
        Me.tbcExtraBills.Controls.Add(Me.tpgConsumables)
        Me.tbcExtraBills.Controls.Add(Me.tpgExtraCharge)
        Me.tbcExtraBills.HotTrack = True
        Me.tbcExtraBills.Location = New System.Drawing.Point(15, 218)
        Me.tbcExtraBills.Name = "tbcExtraBills"
        Me.tbcExtraBills.SelectedIndex = 0
        Me.tbcExtraBills.Size = New System.Drawing.Size(888, 221)
        Me.tbcExtraBills.TabIndex = 44
        '
        'tpgAdmission
        '
        Me.tpgAdmission.Controls.Add(Me.dgvAdmission)
        Me.tpgAdmission.Location = New System.Drawing.Point(4, 22)
        Me.tpgAdmission.Name = "tpgAdmission"
        Me.tpgAdmission.Size = New System.Drawing.Size(880, 195)
        Me.tpgAdmission.TabIndex = 13
        Me.tpgAdmission.Text = "Admission"
        Me.tpgAdmission.UseVisualStyleBackColor = True
        '
        'dgvAdmission
        '
        Me.dgvAdmission.AllowUserToAddRows = False
        Me.dgvAdmission.AllowUserToOrderColumns = True
        Me.dgvAdmission.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdmission.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAdmission.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAdmissionBedNo, Me.colAdmissionBedName, Me.colAdmissionQuantity, Me.colAdmissionUnitPrice, Me.colAdmissionAmount, Me.colAdmissionNotes, Me.colAdmissionPayStatus, Me.colAdmissionEntryMode, Me.colAdmissionSaved})
        Me.dgvAdmission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAdmission.EnableHeadersVisualStyles = False
        Me.dgvAdmission.GridColor = System.Drawing.Color.Khaki
        Me.dgvAdmission.Location = New System.Drawing.Point(0, 0)
        Me.dgvAdmission.Name = "dgvAdmission"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdmission.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAdmission.Size = New System.Drawing.Size(880, 195)
        Me.dgvAdmission.TabIndex = 21
        Me.dgvAdmission.Text = "DataGridView1"
        '
        'colAdmissionBedNo
        '
        Me.colAdmissionBedNo.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colAdmissionBedNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAdmissionBedNo.HeaderText = "Bed No"
        Me.colAdmissionBedNo.Name = "colAdmissionBedNo"
        Me.colAdmissionBedNo.ReadOnly = True
        Me.colAdmissionBedNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAdmissionBedNo.Width = 80
        '
        'colAdmissionBedName
        '
        Me.colAdmissionBedName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colAdmissionBedName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAdmissionBedName.HeaderText = "Bed Name"
        Me.colAdmissionBedName.Name = "colAdmissionBedName"
        Me.colAdmissionBedName.ReadOnly = True
        Me.colAdmissionBedName.Width = 180
        '
        'colAdmissionQuantity
        '
        Me.colAdmissionQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colAdmissionQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colAdmissionQuantity.HeaderText = "Quantity"
        Me.colAdmissionQuantity.Name = "colAdmissionQuantity"
        Me.colAdmissionQuantity.Width = 50
        '
        'colAdmissionUnitPrice
        '
        Me.colAdmissionUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colAdmissionUnitPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.colAdmissionUnitPrice.HeaderText = "Unit Price"
        Me.colAdmissionUnitPrice.Name = "colAdmissionUnitPrice"
        Me.colAdmissionUnitPrice.ReadOnly = True
        Me.colAdmissionUnitPrice.Width = 65
        '
        'colAdmissionAmount
        '
        Me.colAdmissionAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colAdmissionAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colAdmissionAmount.HeaderText = "Amount"
        Me.colAdmissionAmount.Name = "colAdmissionAmount"
        Me.colAdmissionAmount.ReadOnly = True
        Me.colAdmissionAmount.Width = 65
        '
        'colAdmissionNotes
        '
        Me.colAdmissionNotes.DataPropertyName = "Notes"
        Me.colAdmissionNotes.HeaderText = "Notes"
        Me.colAdmissionNotes.MaxInputLength = 200
        Me.colAdmissionNotes.Name = "colAdmissionNotes"
        '
        'colAdmissionPayStatus
        '
        Me.colAdmissionPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colAdmissionPayStatus.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAdmissionPayStatus.HeaderText = "Pay Status"
        Me.colAdmissionPayStatus.Name = "colAdmissionPayStatus"
        Me.colAdmissionPayStatus.ReadOnly = True
        Me.colAdmissionPayStatus.Width = 80
        '
        'colAdmissionEntryMode
        '
        Me.colAdmissionEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colAdmissionEntryMode.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAdmissionEntryMode.HeaderText = "Entry Mode"
        Me.colAdmissionEntryMode.Name = "colAdmissionEntryMode"
        Me.colAdmissionEntryMode.ReadOnly = True
        Me.colAdmissionEntryMode.Width = 80
        '
        'colAdmissionSaved
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colAdmissionSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colAdmissionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAdmissionSaved.HeaderText = "Saved"
        Me.colAdmissionSaved.Name = "colAdmissionSaved"
        Me.colAdmissionSaved.ReadOnly = True
        Me.colAdmissionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAdmissionSaved.Width = 50
        '
        'tpgServices
        '
        Me.tpgServices.Controls.Add(Me.dgvServices)
        Me.tpgServices.Location = New System.Drawing.Point(4, 22)
        Me.tpgServices.Name = "tpgServices"
        Me.tpgServices.Size = New System.Drawing.Size(880, 195)
        Me.tpgServices.TabIndex = 7
        Me.tpgServices.Text = "Services"
        Me.tpgServices.UseVisualStyleBackColor = True
        '
        'dgvServices
        '
        Me.dgvServices.AllowUserToOrderColumns = True
        Me.dgvServices.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvServices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colServiceCode, Me.colServiceQuantity, Me.colServiceUnitPrice, Me.colServiceAmount, Me.colServiceNotes, Me.colServicePayStatus, Me.colServiceEntryMode, Me.colServicesSaved})
        Me.dgvServices.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvServices.EnableHeadersVisualStyles = False
        Me.dgvServices.GridColor = System.Drawing.Color.Khaki
        Me.dgvServices.Location = New System.Drawing.Point(0, 0)
        Me.dgvServices.Name = "dgvServices"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvServices.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvServices.Size = New System.Drawing.Size(880, 195)
        Me.dgvServices.TabIndex = 0
        Me.dgvServices.Text = "DataGridView1"
        '
        'colServiceCode
        '
        Me.colServiceCode.DataPropertyName = "ItemCode"
        Me.colServiceCode.DisplayStyleForCurrentCellOnly = True
        Me.colServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colServiceCode.HeaderText = "Service"
        Me.colServiceCode.Name = "colServiceCode"
        Me.colServiceCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colServiceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colServiceCode.Width = 260
        '
        'colServiceQuantity
        '
        Me.colServiceQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colServiceQuantity.DefaultCellStyle = DataGridViewCellStyle12
        Me.colServiceQuantity.HeaderText = "Quantity"
        Me.colServiceQuantity.Name = "colServiceQuantity"
        Me.colServiceQuantity.Width = 50
        '
        'colServiceUnitPrice
        '
        Me.colServiceUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colServiceUnitPrice.DefaultCellStyle = DataGridViewCellStyle13
        Me.colServiceUnitPrice.HeaderText = "Unit Price"
        Me.colServiceUnitPrice.Name = "colServiceUnitPrice"
        Me.colServiceUnitPrice.Width = 65
        '
        'colServiceAmount
        '
        Me.colServiceAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.colServiceAmount.DefaultCellStyle = DataGridViewCellStyle14
        Me.colServiceAmount.HeaderText = "Amount"
        Me.colServiceAmount.Name = "colServiceAmount"
        Me.colServiceAmount.ReadOnly = True
        Me.colServiceAmount.Width = 65
        '
        'colServiceNotes
        '
        Me.colServiceNotes.DataPropertyName = "Notes"
        Me.colServiceNotes.HeaderText = "Notes"
        Me.colServiceNotes.MaxInputLength = 200
        Me.colServiceNotes.Name = "colServiceNotes"
        '
        'colServicePayStatus
        '
        Me.colServicePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colServicePayStatus.DefaultCellStyle = DataGridViewCellStyle15
        Me.colServicePayStatus.HeaderText = "Pay Status"
        Me.colServicePayStatus.Name = "colServicePayStatus"
        Me.colServicePayStatus.ReadOnly = True
        Me.colServicePayStatus.Width = 80
        '
        'colServiceEntryMode
        '
        Me.colServiceEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colServiceEntryMode.DefaultCellStyle = DataGridViewCellStyle16
        Me.colServiceEntryMode.HeaderText = "Entry Mode"
        Me.colServiceEntryMode.Name = "colServiceEntryMode"
        Me.colServiceEntryMode.ReadOnly = True
        Me.colServiceEntryMode.Width = 80
        '
        'colServicesSaved
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = False
        Me.colServicesSaved.DefaultCellStyle = DataGridViewCellStyle17
        Me.colServicesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colServicesSaved.HeaderText = "Saved"
        Me.colServicesSaved.Name = "colServicesSaved"
        Me.colServicesSaved.ReadOnly = True
        Me.colServicesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colServicesSaved.Width = 50
        '
        'cmsExtraBills
        '
        Me.cmsExtraBills.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsExtraBills.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsExtraBillsQuickSearch})
        Me.cmsExtraBills.Name = "cmsSearch"
        Me.cmsExtraBills.Size = New System.Drawing.Size(144, 26)
        '
        'cmsExtraBillsQuickSearch
        '
        Me.cmsExtraBillsQuickSearch.Image = CType(resources.GetObject("cmsExtraBillsQuickSearch.Image"), System.Drawing.Image)
        Me.cmsExtraBillsQuickSearch.Name = "cmsExtraBillsQuickSearch"
        Me.cmsExtraBillsQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsExtraBillsQuickSearch.Text = "Quick Search"
        '
        'tpgLaboratory
        '
        Me.tpgLaboratory.Controls.Add(Me.dgvLabTests)
        Me.tpgLaboratory.Location = New System.Drawing.Point(4, 22)
        Me.tpgLaboratory.Name = "tpgLaboratory"
        Me.tpgLaboratory.Size = New System.Drawing.Size(880, 195)
        Me.tpgLaboratory.TabIndex = 0
        Me.tpgLaboratory.Tag = ""
        Me.tpgLaboratory.Text = "Laboratory"
        Me.tpgLaboratory.UseVisualStyleBackColor = True
        '
        'dgvLabTests
        '
        Me.dgvLabTests.AllowUserToOrderColumns = True
        Me.dgvLabTests.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvLabTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTest, Me.colLTQuantity, Me.colLTUnitPrice, Me.colLTAmount, Me.colLTNotes, Me.colLTPayStatus, Me.colLTEntryMode, Me.colLabTestsSaved})
        Me.dgvLabTests.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvLabTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabTests.EnableHeadersVisualStyles = False
        Me.dgvLabTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabTests.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabTests.Location = New System.Drawing.Point(0, 0)
        Me.dgvLabTests.Name = "dgvLabTests"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvLabTests.Size = New System.Drawing.Size(880, 195)
        Me.dgvLabTests.TabIndex = 0
        Me.dgvLabTests.Text = "DataGridView1"
        '
        'colTest
        '
        Me.colTest.DataPropertyName = "ItemFullName"
        Me.colTest.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colTest.DisplayStyleForCurrentCellOnly = True
        Me.colTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTest.HeaderText = "Test"
        Me.colTest.Name = "colTest"
        Me.colTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTest.Width = 260
        '
        'colLTQuantity
        '
        Me.colLTQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colLTQuantity.DefaultCellStyle = DataGridViewCellStyle20
        Me.colLTQuantity.HeaderText = "Quantity"
        Me.colLTQuantity.Name = "colLTQuantity"
        Me.colLTQuantity.Width = 50
        '
        'colLTUnitPrice
        '
        Me.colLTUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.NullValue = Nothing
        Me.colLTUnitPrice.DefaultCellStyle = DataGridViewCellStyle21
        Me.colLTUnitPrice.HeaderText = "Unit Price"
        Me.colLTUnitPrice.Name = "colLTUnitPrice"
        Me.colLTUnitPrice.Width = 65
        '
        'colLTAmount
        '
        Me.colLTAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colLTAmount.DefaultCellStyle = DataGridViewCellStyle22
        Me.colLTAmount.HeaderText = "Amount"
        Me.colLTAmount.Name = "colLTAmount"
        Me.colLTAmount.ReadOnly = True
        Me.colLTAmount.Width = 65
        '
        'colLTNotes
        '
        Me.colLTNotes.DataPropertyName = "Notes"
        Me.colLTNotes.HeaderText = "Notes"
        Me.colLTNotes.MaxInputLength = 200
        Me.colLTNotes.Name = "colLTNotes"
        '
        'colLTPayStatus
        '
        Me.colLTPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colLTPayStatus.DefaultCellStyle = DataGridViewCellStyle23
        Me.colLTPayStatus.HeaderText = "Pay Status"
        Me.colLTPayStatus.Name = "colLTPayStatus"
        Me.colLTPayStatus.ReadOnly = True
        Me.colLTPayStatus.Width = 80
        '
        'colLTEntryMode
        '
        Me.colLTEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colLTEntryMode.DefaultCellStyle = DataGridViewCellStyle24
        Me.colLTEntryMode.HeaderText = "Entry Mode"
        Me.colLTEntryMode.Name = "colLTEntryMode"
        Me.colLTEntryMode.ReadOnly = True
        Me.colLTEntryMode.Width = 80
        '
        'colLabTestsSaved
        '
        Me.colLabTestsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.NullValue = False
        Me.colLabTestsSaved.DefaultCellStyle = DataGridViewCellStyle25
        Me.colLabTestsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colLabTestsSaved.HeaderText = "Saved"
        Me.colLabTestsSaved.Name = "colLabTestsSaved"
        Me.colLabTestsSaved.ReadOnly = True
        Me.colLabTestsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colLabTestsSaved.Width = 50
        '
        'tpgRadiology
        '
        Me.tpgRadiology.Controls.Add(Me.dgvRadiology)
        Me.tpgRadiology.Location = New System.Drawing.Point(4, 22)
        Me.tpgRadiology.Name = "tpgRadiology"
        Me.tpgRadiology.Size = New System.Drawing.Size(880, 195)
        Me.tpgRadiology.TabIndex = 3
        Me.tpgRadiology.Tag = ""
        Me.tpgRadiology.Text = "Radiology"
        Me.tpgRadiology.UseVisualStyleBackColor = True
        '
        'dgvRadiology
        '
        Me.dgvRadiology.AllowUserToOrderColumns = True
        Me.dgvRadiology.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadiology.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvRadiology.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExamFullName, Me.colRadiologyQuantity, Me.colRadiologyUnitPrice, Me.colRadiologyAmount, Me.colRadiologyNotes, Me.colRadiologyPayStatus, Me.colRadiologyEntryMode, Me.colRadiologySaved})
        Me.dgvRadiology.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvRadiology.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRadiology.EnableHeadersVisualStyles = False
        Me.dgvRadiology.GridColor = System.Drawing.Color.Khaki
        Me.dgvRadiology.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvRadiology.Location = New System.Drawing.Point(0, 0)
        Me.dgvRadiology.Name = "dgvRadiology"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadiology.RowHeadersDefaultCellStyle = DataGridViewCellStyle34
        Me.dgvRadiology.Size = New System.Drawing.Size(880, 195)
        Me.dgvRadiology.TabIndex = 22
        Me.dgvRadiology.Text = "DataGridView1"
        '
        'colExamFullName
        '
        Me.colExamFullName.DataPropertyName = "ItemFullName"
        Me.colExamFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colExamFullName.DisplayStyleForCurrentCellOnly = True
        Me.colExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExamFullName.HeaderText = "Radiology Examination"
        Me.colExamFullName.Name = "colExamFullName"
        Me.colExamFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExamFullName.Width = 260
        '
        'colRadiologyQuantity
        '
        Me.colRadiologyQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle28.Format = "N0"
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle28.NullValue = Nothing
        Me.colRadiologyQuantity.DefaultCellStyle = DataGridViewCellStyle28
        Me.colRadiologyQuantity.HeaderText = "Quantity"
        Me.colRadiologyQuantity.Name = "colRadiologyQuantity"
        Me.colRadiologyQuantity.Width = 50
        '
        'colRadiologyUnitPrice
        '
        Me.colRadiologyUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colRadiologyUnitPrice.DefaultCellStyle = DataGridViewCellStyle29
        Me.colRadiologyUnitPrice.HeaderText = "Unit Price"
        Me.colRadiologyUnitPrice.Name = "colRadiologyUnitPrice"
        Me.colRadiologyUnitPrice.Width = 65
        '
        'colRadiologyAmount
        '
        Me.colRadiologyAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle30.Format = "N2"
        DataGridViewCellStyle30.NullValue = Nothing
        Me.colRadiologyAmount.DefaultCellStyle = DataGridViewCellStyle30
        Me.colRadiologyAmount.HeaderText = "Amount"
        Me.colRadiologyAmount.Name = "colRadiologyAmount"
        Me.colRadiologyAmount.ReadOnly = True
        Me.colRadiologyAmount.Width = 65
        '
        'colRadiologyNotes
        '
        Me.colRadiologyNotes.DataPropertyName = "Notes"
        Me.colRadiologyNotes.HeaderText = "Notes"
        Me.colRadiologyNotes.MaxInputLength = 200
        Me.colRadiologyNotes.Name = "colRadiologyNotes"
        '
        'colRadiologyPayStatus
        '
        Me.colRadiologyPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colRadiologyPayStatus.DefaultCellStyle = DataGridViewCellStyle31
        Me.colRadiologyPayStatus.HeaderText = "Pay Status"
        Me.colRadiologyPayStatus.Name = "colRadiologyPayStatus"
        Me.colRadiologyPayStatus.ReadOnly = True
        Me.colRadiologyPayStatus.Width = 80
        '
        'colRadiologyEntryMode
        '
        Me.colRadiologyEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        Me.colRadiologyEntryMode.DefaultCellStyle = DataGridViewCellStyle32
        Me.colRadiologyEntryMode.HeaderText = "Entry Mode"
        Me.colRadiologyEntryMode.Name = "colRadiologyEntryMode"
        Me.colRadiologyEntryMode.ReadOnly = True
        Me.colRadiologyEntryMode.Width = 80
        '
        'colRadiologySaved
        '
        Me.colRadiologySaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle33.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle33.NullValue = False
        Me.colRadiologySaved.DefaultCellStyle = DataGridViewCellStyle33
        Me.colRadiologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRadiologySaved.HeaderText = "Saved"
        Me.colRadiologySaved.Name = "colRadiologySaved"
        Me.colRadiologySaved.ReadOnly = True
        Me.colRadiologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colRadiologySaved.Width = 50
        '
        'tpgPrescriptions
        '
        Me.tpgPrescriptions.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescriptions.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescriptions.Name = "tpgPrescriptions"
        Me.tpgPrescriptions.Size = New System.Drawing.Size(880, 195)
        Me.tpgPrescriptions.TabIndex = 2
        Me.tpgPrescriptions.Tag = ""
        Me.tpgPrescriptions.Text = "Drugs"
        Me.tpgPrescriptions.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDrugQuantity, Me.colDrugUnitPrice, Me.colDrugAmount, Me.colDrugNotes, Me.colDrugPayStatus, Me.colDrugLocationBalance, Me.colDrugUnitsInStock, Me.colDrugExpiryDate, Me.colDrugOrderLevel, Me.colHasAlternateDrugs, Me.colDugAlternateName, Me.colDrugEntryMode, Me.colPrescriptionSaved})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgvPrescription.Size = New System.Drawing.Size(880, 195)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DataPropertyName = "ItemFullName"
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 260
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle36
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugUnitPrice
        '
        Me.colDrugUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle37.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle37
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.Width = 65
        '
        'colDrugAmount
        '
        Me.colDrugAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle38.Format = "N2"
        DataGridViewCellStyle38.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle38.NullValue = Nothing
        Me.colDrugAmount.DefaultCellStyle = DataGridViewCellStyle38
        Me.colDrugAmount.HeaderText = "Amount"
        Me.colDrugAmount.Name = "colDrugAmount"
        Me.colDrugAmount.ReadOnly = True
        Me.colDrugAmount.Width = 65
        '
        'colDrugNotes
        '
        Me.colDrugNotes.DataPropertyName = "Notes"
        Me.colDrugNotes.HeaderText = "Notes"
        Me.colDrugNotes.MaxInputLength = 200
        Me.colDrugNotes.Name = "colDrugNotes"
        '
        'colDrugPayStatus
        '
        Me.colDrugPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle39
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 80
        '
        'colDrugLocationBalance
        '
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugLocationBalance.DefaultCellStyle = DataGridViewCellStyle40
        Me.colDrugLocationBalance.HeaderText = "Location Balance"
        Me.colDrugLocationBalance.Name = "colDrugLocationBalance"
        Me.colDrugLocationBalance.ReadOnly = True
        '
        'colDrugUnitsInStock
        '
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugUnitsInStock.DefaultCellStyle = DataGridViewCellStyle41
        Me.colDrugUnitsInStock.HeaderText = "Units In Stock"
        Me.colDrugUnitsInStock.Name = "colDrugUnitsInStock"
        Me.colDrugUnitsInStock.ReadOnly = True
        '
        'colDrugExpiryDate
        '
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugExpiryDate.DefaultCellStyle = DataGridViewCellStyle42
        Me.colDrugExpiryDate.HeaderText = "Expiry Date"
        Me.colDrugExpiryDate.Name = "colDrugExpiryDate"
        Me.colDrugExpiryDate.ReadOnly = True
        '
        'colDrugOrderLevel
        '
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugOrderLevel.DefaultCellStyle = DataGridViewCellStyle43
        Me.colDrugOrderLevel.HeaderText = "Order Level"
        Me.colDrugOrderLevel.Name = "colDrugOrderLevel"
        Me.colDrugOrderLevel.ReadOnly = True
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle44.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle44
        Me.colHasAlternateDrugs.HeaderText = "Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        '
        'colDugAlternateName
        '
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Info
        Me.colDugAlternateName.DefaultCellStyle = DataGridViewCellStyle45
        Me.colDugAlternateName.HeaderText = "Alternate Name"
        Me.colDugAlternateName.Name = "colDugAlternateName"
        Me.colDugAlternateName.ReadOnly = True
        '
        'colDrugEntryMode
        '
        Me.colDrugEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugEntryMode.DefaultCellStyle = DataGridViewCellStyle46
        Me.colDrugEntryMode.HeaderText = "Entry Mode"
        Me.colDrugEntryMode.Name = "colDrugEntryMode"
        Me.colDrugEntryMode.ReadOnly = True
        Me.colDrugEntryMode.Width = 80
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle47.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle47
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'tpgProcedures
        '
        Me.tpgProcedures.Controls.Add(Me.dgvProcedures)
        Me.tpgProcedures.Location = New System.Drawing.Point(4, 22)
        Me.tpgProcedures.Name = "tpgProcedures"
        Me.tpgProcedures.Size = New System.Drawing.Size(880, 195)
        Me.tpgProcedures.TabIndex = 4
        Me.tpgProcedures.Tag = ""
        Me.tpgProcedures.Text = "Procedures"
        Me.tpgProcedures.UseVisualStyleBackColor = True
        '
        'dgvProcedures
        '
        Me.dgvProcedures.AllowUserToOrderColumns = True
        Me.dgvProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProcedureCode, Me.colProcedureQuantity, Me.colProcedureUnitPrice, Me.colProcedureAmount, Me.colProcedureNotes, Me.colProcedurePayStatus, Me.colProcedureEntryMode, Me.colProceduresSaved})
        Me.dgvProcedures.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcedures.EnableHeadersVisualStyles = False
        Me.dgvProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvProcedures.Location = New System.Drawing.Point(0, 0)
        Me.dgvProcedures.Name = "dgvProcedures"
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle56.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle56
        Me.dgvProcedures.Size = New System.Drawing.Size(880, 195)
        Me.dgvProcedures.TabIndex = 1
        Me.dgvProcedures.Text = "DataGridView1"
        '
        'colProcedureCode
        '
        Me.colProcedureCode.DataPropertyName = "ItemCode"
        Me.colProcedureCode.DisplayStyleForCurrentCellOnly = True
        Me.colProcedureCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProcedureCode.HeaderText = "Procedure"
        Me.colProcedureCode.Name = "colProcedureCode"
        Me.colProcedureCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProcedureCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colProcedureCode.Width = 260
        '
        'colProcedureQuantity
        '
        Me.colProcedureQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle50.Format = "N0"
        DataGridViewCellStyle50.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle50.NullValue = Nothing
        Me.colProcedureQuantity.DefaultCellStyle = DataGridViewCellStyle50
        Me.colProcedureQuantity.HeaderText = "Quantity"
        Me.colProcedureQuantity.Name = "colProcedureQuantity"
        Me.colProcedureQuantity.Width = 50
        '
        'colProcedureUnitPrice
        '
        Me.colProcedureUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle51.Format = "N2"
        DataGridViewCellStyle51.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle51.NullValue = Nothing
        Me.colProcedureUnitPrice.DefaultCellStyle = DataGridViewCellStyle51
        Me.colProcedureUnitPrice.HeaderText = "Unit Price"
        Me.colProcedureUnitPrice.Name = "colProcedureUnitPrice"
        Me.colProcedureUnitPrice.Width = 65
        '
        'colProcedureAmount
        '
        Me.colProcedureAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedureAmount.DefaultCellStyle = DataGridViewCellStyle52
        Me.colProcedureAmount.HeaderText = "Amount"
        Me.colProcedureAmount.Name = "colProcedureAmount"
        Me.colProcedureAmount.ReadOnly = True
        Me.colProcedureAmount.Width = 65
        '
        'colProcedureNotes
        '
        Me.colProcedureNotes.DataPropertyName = "Notes"
        Me.colProcedureNotes.HeaderText = "Notes"
        Me.colProcedureNotes.MaxInputLength = 200
        Me.colProcedureNotes.Name = "colProcedureNotes"
        '
        'colProcedurePayStatus
        '
        Me.colProcedurePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedurePayStatus.DefaultCellStyle = DataGridViewCellStyle53
        Me.colProcedurePayStatus.HeaderText = "Pay Status"
        Me.colProcedurePayStatus.Name = "colProcedurePayStatus"
        Me.colProcedurePayStatus.ReadOnly = True
        Me.colProcedurePayStatus.Width = 80
        '
        'colProcedureEntryMode
        '
        Me.colProcedureEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedureEntryMode.DefaultCellStyle = DataGridViewCellStyle54
        Me.colProcedureEntryMode.HeaderText = "Entry Mode"
        Me.colProcedureEntryMode.Name = "colProcedureEntryMode"
        Me.colProcedureEntryMode.ReadOnly = True
        Me.colProcedureEntryMode.Width = 80
        '
        'colProceduresSaved
        '
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle55.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle55.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle55.NullValue = False
        Me.colProceduresSaved.DefaultCellStyle = DataGridViewCellStyle55
        Me.colProceduresSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProceduresSaved.HeaderText = "Saved"
        Me.colProceduresSaved.Name = "colProceduresSaved"
        Me.colProceduresSaved.ReadOnly = True
        Me.colProceduresSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colProceduresSaved.Width = 50
        '
        'tpgDental
        '
        Me.tpgDental.Controls.Add(Me.dgvDental)
        Me.tpgDental.Location = New System.Drawing.Point(4, 22)
        Me.tpgDental.Name = "tpgDental"
        Me.tpgDental.Size = New System.Drawing.Size(880, 195)
        Me.tpgDental.TabIndex = 5
        Me.tpgDental.Tag = ""
        Me.tpgDental.Text = "Dental"
        Me.tpgDental.UseVisualStyleBackColor = True
        '
        'dgvDental
        '
        Me.dgvDental.AllowUserToOrderColumns = True
        Me.dgvDental.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle57.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDental.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle57
        Me.dgvDental.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDentalCode, Me.colDentalQuantity, Me.colDentalUnitPrice, Me.colDentalAmount, Me.colDentalNotes, Me.colDentalPayStatus, Me.colDentalEntryMode, Me.colDentalSaved})
        Me.dgvDental.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvDental.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDental.EnableHeadersVisualStyles = False
        Me.dgvDental.GridColor = System.Drawing.Color.Khaki
        Me.dgvDental.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDental.Location = New System.Drawing.Point(0, 0)
        Me.dgvDental.Name = "dgvDental"
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle64.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle64.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle64.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle64.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDental.RowHeadersDefaultCellStyle = DataGridViewCellStyle64
        Me.dgvDental.Size = New System.Drawing.Size(880, 195)
        Me.dgvDental.TabIndex = 24
        Me.dgvDental.Text = "DataGridView1"
        '
        'colDentalCode
        '
        Me.colDentalCode.DataPropertyName = "ItemCode"
        Me.colDentalCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDentalCode.DisplayStyleForCurrentCellOnly = True
        Me.colDentalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDentalCode.HeaderText = "Dental"
        Me.colDentalCode.Name = "colDentalCode"
        Me.colDentalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDentalCode.Width = 260
        '
        'colDentalQuantity
        '
        Me.colDentalQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle58.Format = "N0"
        DataGridViewCellStyle58.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle58.NullValue = Nothing
        Me.colDentalQuantity.DefaultCellStyle = DataGridViewCellStyle58
        Me.colDentalQuantity.HeaderText = "Quantity"
        Me.colDentalQuantity.MaxInputLength = 12
        Me.colDentalQuantity.Name = "colDentalQuantity"
        Me.colDentalQuantity.Width = 50
        '
        'colDentalUnitPrice
        '
        Me.colDentalUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle59.Format = "N2"
        DataGridViewCellStyle59.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle59.NullValue = Nothing
        Me.colDentalUnitPrice.DefaultCellStyle = DataGridViewCellStyle59
        Me.colDentalUnitPrice.HeaderText = "Unit Price"
        Me.colDentalUnitPrice.Name = "colDentalUnitPrice"
        Me.colDentalUnitPrice.Width = 65
        '
        'colDentalAmount
        '
        Me.colDentalAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle60.Format = "N2"
        Me.colDentalAmount.DefaultCellStyle = DataGridViewCellStyle60
        Me.colDentalAmount.HeaderText = "Amount"
        Me.colDentalAmount.Name = "colDentalAmount"
        Me.colDentalAmount.ReadOnly = True
        Me.colDentalAmount.Width = 65
        '
        'colDentalNotes
        '
        Me.colDentalNotes.DataPropertyName = "Notes"
        Me.colDentalNotes.HeaderText = "Notes"
        Me.colDentalNotes.MaxInputLength = 200
        Me.colDentalNotes.Name = "colDentalNotes"
        '
        'colDentalPayStatus
        '
        Me.colDentalPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Info
        Me.colDentalPayStatus.DefaultCellStyle = DataGridViewCellStyle61
        Me.colDentalPayStatus.HeaderText = "Pay Status"
        Me.colDentalPayStatus.Name = "colDentalPayStatus"
        Me.colDentalPayStatus.ReadOnly = True
        Me.colDentalPayStatus.Width = 80
        '
        'colDentalEntryMode
        '
        Me.colDentalEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Info
        Me.colDentalEntryMode.DefaultCellStyle = DataGridViewCellStyle62
        Me.colDentalEntryMode.HeaderText = "Entry Mode"
        Me.colDentalEntryMode.Name = "colDentalEntryMode"
        Me.colDentalEntryMode.ReadOnly = True
        Me.colDentalEntryMode.Width = 80
        '
        'colDentalSaved
        '
        Me.colDentalSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle63.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle63.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle63.NullValue = False
        Me.colDentalSaved.DefaultCellStyle = DataGridViewCellStyle63
        Me.colDentalSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDentalSaved.HeaderText = "Saved"
        Me.colDentalSaved.Name = "colDentalSaved"
        Me.colDentalSaved.ReadOnly = True
        Me.colDentalSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDentalSaved.Width = 50
        '
        'tpgTheatre
        '
        Me.tpgTheatre.Controls.Add(Me.dgvTheatre)
        Me.tpgTheatre.Location = New System.Drawing.Point(4, 22)
        Me.tpgTheatre.Name = "tpgTheatre"
        Me.tpgTheatre.Size = New System.Drawing.Size(880, 195)
        Me.tpgTheatre.TabIndex = 8
        Me.tpgTheatre.Text = "Theatre"
        Me.tpgTheatre.UseVisualStyleBackColor = True
        '
        'dgvTheatre
        '
        Me.dgvTheatre.AllowUserToOrderColumns = True
        Me.dgvTheatre.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle65.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle65.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle65.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle65.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle65
        Me.dgvTheatre.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTheatreCode, Me.colTheatreQuantity, Me.colTheatreUnitPrice, Me.colTheatreAmount, Me.colTheatreNotes, Me.colTheatrePayStatus, Me.colTheatreEntryMode, Me.colTheatreSaved})
        Me.dgvTheatre.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvTheatre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTheatre.EnableHeadersVisualStyles = False
        Me.dgvTheatre.GridColor = System.Drawing.Color.Khaki
        Me.dgvTheatre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvTheatre.Location = New System.Drawing.Point(0, 0)
        Me.dgvTheatre.Name = "dgvTheatre"
        DataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle72.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle72.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle72.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle72.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle72.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.RowHeadersDefaultCellStyle = DataGridViewCellStyle72
        Me.dgvTheatre.Size = New System.Drawing.Size(880, 195)
        Me.dgvTheatre.TabIndex = 27
        Me.dgvTheatre.Text = "DataGridView1"
        '
        'colTheatreCode
        '
        Me.colTheatreCode.DataPropertyName = "ItemCode"
        Me.colTheatreCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colTheatreCode.DisplayStyleForCurrentCellOnly = True
        Me.colTheatreCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreCode.HeaderText = "Theatre"
        Me.colTheatreCode.Name = "colTheatreCode"
        Me.colTheatreCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTheatreCode.Width = 260
        '
        'colTheatreQuantity
        '
        Me.colTheatreQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle66.Format = "N0"
        DataGridViewCellStyle66.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle66.NullValue = Nothing
        Me.colTheatreQuantity.DefaultCellStyle = DataGridViewCellStyle66
        Me.colTheatreQuantity.HeaderText = "Quantity"
        Me.colTheatreQuantity.MaxInputLength = 12
        Me.colTheatreQuantity.Name = "colTheatreQuantity"
        Me.colTheatreQuantity.Width = 50
        '
        'colTheatreUnitPrice
        '
        Me.colTheatreUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle67.Format = "N2"
        DataGridViewCellStyle67.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle67.NullValue = Nothing
        Me.colTheatreUnitPrice.DefaultCellStyle = DataGridViewCellStyle67
        Me.colTheatreUnitPrice.HeaderText = "Unit Price"
        Me.colTheatreUnitPrice.Name = "colTheatreUnitPrice"
        Me.colTheatreUnitPrice.Width = 65
        '
        'colTheatreAmount
        '
        Me.colTheatreAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle68.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle68.Format = "N2"
        Me.colTheatreAmount.DefaultCellStyle = DataGridViewCellStyle68
        Me.colTheatreAmount.HeaderText = "Amount"
        Me.colTheatreAmount.Name = "colTheatreAmount"
        Me.colTheatreAmount.ReadOnly = True
        Me.colTheatreAmount.Width = 65
        '
        'colTheatreNotes
        '
        Me.colTheatreNotes.DataPropertyName = "Notes"
        Me.colTheatreNotes.HeaderText = "Notes"
        Me.colTheatreNotes.MaxInputLength = 200
        Me.colTheatreNotes.Name = "colTheatreNotes"
        '
        'colTheatrePayStatus
        '
        Me.colTheatrePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle69.BackColor = System.Drawing.SystemColors.Info
        Me.colTheatrePayStatus.DefaultCellStyle = DataGridViewCellStyle69
        Me.colTheatrePayStatus.HeaderText = "Pay Status"
        Me.colTheatrePayStatus.Name = "colTheatrePayStatus"
        Me.colTheatrePayStatus.ReadOnly = True
        Me.colTheatrePayStatus.Width = 80
        '
        'colTheatreEntryMode
        '
        Me.colTheatreEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle70.BackColor = System.Drawing.SystemColors.Info
        Me.colTheatreEntryMode.DefaultCellStyle = DataGridViewCellStyle70
        Me.colTheatreEntryMode.HeaderText = "Entry Mode"
        Me.colTheatreEntryMode.Name = "colTheatreEntryMode"
        Me.colTheatreEntryMode.ReadOnly = True
        Me.colTheatreEntryMode.Width = 80
        '
        'colTheatreSaved
        '
        Me.colTheatreSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle71.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle71.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle71.NullValue = False
        Me.colTheatreSaved.DefaultCellStyle = DataGridViewCellStyle71
        Me.colTheatreSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreSaved.HeaderText = "Saved"
        Me.colTheatreSaved.Name = "colTheatreSaved"
        Me.colTheatreSaved.ReadOnly = True
        Me.colTheatreSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTheatreSaved.Width = 50
        '
        'tpgOptical
        '
        Me.tpgOptical.Controls.Add(Me.dgvOptical)
        Me.tpgOptical.Location = New System.Drawing.Point(4, 22)
        Me.tpgOptical.Name = "tpgOptical"
        Me.tpgOptical.Size = New System.Drawing.Size(880, 195)
        Me.tpgOptical.TabIndex = 9
        Me.tpgOptical.Text = "Optical"
        Me.tpgOptical.UseVisualStyleBackColor = True
        '
        'dgvOptical
        '
        Me.dgvOptical.AllowUserToOrderColumns = True
        Me.dgvOptical.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle73.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle73.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle73.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle73.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle73.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle73.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle73
        Me.dgvOptical.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOpticalCode, Me.colOpticalQuantity, Me.colOpticalUnitPrice, Me.colOpticalAmount, Me.colOpticalNotes, Me.colOpticalPayStatus, Me.colOpticalEntryMode, Me.colOpticalSaved})
        Me.dgvOptical.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvOptical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptical.EnableHeadersVisualStyles = False
        Me.dgvOptical.GridColor = System.Drawing.Color.Khaki
        Me.dgvOptical.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOptical.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptical.Name = "dgvOptical"
        DataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle80.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle80.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle80.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle80.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle80.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.RowHeadersDefaultCellStyle = DataGridViewCellStyle80
        Me.dgvOptical.Size = New System.Drawing.Size(880, 195)
        Me.dgvOptical.TabIndex = 27
        Me.dgvOptical.Text = "DataGridView1"
        '
        'colOpticalCode
        '
        Me.colOpticalCode.DataPropertyName = "ItemCode"
        Me.colOpticalCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colOpticalCode.DisplayStyleForCurrentCellOnly = True
        Me.colOpticalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOpticalCode.HeaderText = "Optical"
        Me.colOpticalCode.Name = "colOpticalCode"
        Me.colOpticalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOpticalCode.Width = 260
        '
        'colOpticalQuantity
        '
        Me.colOpticalQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle74.Format = "N0"
        DataGridViewCellStyle74.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle74.NullValue = Nothing
        Me.colOpticalQuantity.DefaultCellStyle = DataGridViewCellStyle74
        Me.colOpticalQuantity.HeaderText = "Quantity"
        Me.colOpticalQuantity.MaxInputLength = 12
        Me.colOpticalQuantity.Name = "colOpticalQuantity"
        Me.colOpticalQuantity.Width = 50
        '
        'colOpticalUnitPrice
        '
        Me.colOpticalUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle75.Format = "N2"
        DataGridViewCellStyle75.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle75.NullValue = Nothing
        Me.colOpticalUnitPrice.DefaultCellStyle = DataGridViewCellStyle75
        Me.colOpticalUnitPrice.HeaderText = "Unit Price"
        Me.colOpticalUnitPrice.Name = "colOpticalUnitPrice"
        Me.colOpticalUnitPrice.Width = 65
        '
        'colOpticalAmount
        '
        Me.colOpticalAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle76.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle76.Format = "N2"
        Me.colOpticalAmount.DefaultCellStyle = DataGridViewCellStyle76
        Me.colOpticalAmount.HeaderText = "Amount"
        Me.colOpticalAmount.Name = "colOpticalAmount"
        Me.colOpticalAmount.ReadOnly = True
        Me.colOpticalAmount.Width = 65
        '
        'colOpticalNotes
        '
        Me.colOpticalNotes.DataPropertyName = "Notes"
        Me.colOpticalNotes.HeaderText = "Notes"
        Me.colOpticalNotes.MaxInputLength = 200
        Me.colOpticalNotes.Name = "colOpticalNotes"
        '
        'colOpticalPayStatus
        '
        Me.colOpticalPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle77.BackColor = System.Drawing.SystemColors.Info
        Me.colOpticalPayStatus.DefaultCellStyle = DataGridViewCellStyle77
        Me.colOpticalPayStatus.HeaderText = "Pay Status"
        Me.colOpticalPayStatus.Name = "colOpticalPayStatus"
        Me.colOpticalPayStatus.ReadOnly = True
        Me.colOpticalPayStatus.Width = 80
        '
        'colOpticalEntryMode
        '
        Me.colOpticalEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle78.BackColor = System.Drawing.SystemColors.Info
        Me.colOpticalEntryMode.DefaultCellStyle = DataGridViewCellStyle78
        Me.colOpticalEntryMode.HeaderText = "Entry Mode"
        Me.colOpticalEntryMode.Name = "colOpticalEntryMode"
        Me.colOpticalEntryMode.ReadOnly = True
        Me.colOpticalEntryMode.Width = 80
        '
        'colOpticalSaved
        '
        Me.colOpticalSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle79.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle79.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle79.NullValue = False
        Me.colOpticalSaved.DefaultCellStyle = DataGridViewCellStyle79
        Me.colOpticalSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOpticalSaved.HeaderText = "Saved"
        Me.colOpticalSaved.Name = "colOpticalSaved"
        Me.colOpticalSaved.ReadOnly = True
        Me.colOpticalSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOpticalSaved.Width = 50
        '
        'tpgMaternity
        '
        Me.tpgMaternity.Controls.Add(Me.dgvMaternity)
        Me.tpgMaternity.Location = New System.Drawing.Point(4, 22)
        Me.tpgMaternity.Name = "tpgMaternity"
        Me.tpgMaternity.Size = New System.Drawing.Size(880, 195)
        Me.tpgMaternity.TabIndex = 10
        Me.tpgMaternity.Text = "Maternity"
        Me.tpgMaternity.UseVisualStyleBackColor = True
        '
        'dgvMaternity
        '
        Me.dgvMaternity.AllowUserToOrderColumns = True
        Me.dgvMaternity.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle81.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle81.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle81.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle81.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle81.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaternity.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle81
        Me.dgvMaternity.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMaternityCode, Me.colMaternityQuantity, Me.colMaternityUnitPrice, Me.colMaternityAmount, Me.colMaternityNotes, Me.colMaternityPayStatus, Me.colMaternityEntryMode, Me.colMaternitySaved})
        Me.dgvMaternity.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvMaternity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaternity.EnableHeadersVisualStyles = False
        Me.dgvMaternity.GridColor = System.Drawing.Color.Khaki
        Me.dgvMaternity.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMaternity.Location = New System.Drawing.Point(0, 0)
        Me.dgvMaternity.Name = "dgvMaternity"
        DataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle88.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle88.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle88.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle88.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle88.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaternity.RowHeadersDefaultCellStyle = DataGridViewCellStyle88
        Me.dgvMaternity.Size = New System.Drawing.Size(880, 195)
        Me.dgvMaternity.TabIndex = 27
        Me.dgvMaternity.Text = "DataGridView1"
        '
        'colMaternityCode
        '
        Me.colMaternityCode.DataPropertyName = "ItemCode"
        Me.colMaternityCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colMaternityCode.DisplayStyleForCurrentCellOnly = True
        Me.colMaternityCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colMaternityCode.HeaderText = "Maternity"
        Me.colMaternityCode.Name = "colMaternityCode"
        Me.colMaternityCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colMaternityCode.Width = 260
        '
        'colMaternityQuantity
        '
        Me.colMaternityQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle82.Format = "N0"
        DataGridViewCellStyle82.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle82.NullValue = Nothing
        Me.colMaternityQuantity.DefaultCellStyle = DataGridViewCellStyle82
        Me.colMaternityQuantity.HeaderText = "Quantity"
        Me.colMaternityQuantity.MaxInputLength = 12
        Me.colMaternityQuantity.Name = "colMaternityQuantity"
        Me.colMaternityQuantity.Width = 50
        '
        'colMaternityUnitPrice
        '
        Me.colMaternityUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle83.Format = "N2"
        DataGridViewCellStyle83.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle83.NullValue = Nothing
        Me.colMaternityUnitPrice.DefaultCellStyle = DataGridViewCellStyle83
        Me.colMaternityUnitPrice.HeaderText = "Unit Price"
        Me.colMaternityUnitPrice.Name = "colMaternityUnitPrice"
        Me.colMaternityUnitPrice.Width = 65
        '
        'colMaternityAmount
        '
        Me.colMaternityAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle84.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle84.Format = "N2"
        Me.colMaternityAmount.DefaultCellStyle = DataGridViewCellStyle84
        Me.colMaternityAmount.HeaderText = "Amount"
        Me.colMaternityAmount.Name = "colMaternityAmount"
        Me.colMaternityAmount.ReadOnly = True
        Me.colMaternityAmount.Width = 65
        '
        'colMaternityNotes
        '
        Me.colMaternityNotes.DataPropertyName = "Notes"
        Me.colMaternityNotes.HeaderText = "Notes"
        Me.colMaternityNotes.MaxInputLength = 200
        Me.colMaternityNotes.Name = "colMaternityNotes"
        '
        'colMaternityPayStatus
        '
        Me.colMaternityPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle85.BackColor = System.Drawing.SystemColors.Info
        Me.colMaternityPayStatus.DefaultCellStyle = DataGridViewCellStyle85
        Me.colMaternityPayStatus.HeaderText = "Pay Status"
        Me.colMaternityPayStatus.Name = "colMaternityPayStatus"
        Me.colMaternityPayStatus.ReadOnly = True
        Me.colMaternityPayStatus.Width = 80
        '
        'colMaternityEntryMode
        '
        Me.colMaternityEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle86.BackColor = System.Drawing.SystemColors.Info
        Me.colMaternityEntryMode.DefaultCellStyle = DataGridViewCellStyle86
        Me.colMaternityEntryMode.HeaderText = "Entry Mode"
        Me.colMaternityEntryMode.Name = "colMaternityEntryMode"
        Me.colMaternityEntryMode.ReadOnly = True
        Me.colMaternityEntryMode.Width = 80
        '
        'colMaternitySaved
        '
        Me.colMaternitySaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle87.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle87.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle87.NullValue = False
        Me.colMaternitySaved.DefaultCellStyle = DataGridViewCellStyle87
        Me.colMaternitySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colMaternitySaved.HeaderText = "Saved"
        Me.colMaternitySaved.Name = "colMaternitySaved"
        Me.colMaternitySaved.ReadOnly = True
        Me.colMaternitySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colMaternitySaved.Width = 50
        '
        'tpgICU
        '
        Me.tpgICU.Controls.Add(Me.dgvICU)
        Me.tpgICU.Location = New System.Drawing.Point(4, 22)
        Me.tpgICU.Name = "tpgICU"
        Me.tpgICU.Size = New System.Drawing.Size(880, 195)
        Me.tpgICU.TabIndex = 11
        Me.tpgICU.Text = "ICU"
        Me.tpgICU.UseVisualStyleBackColor = True
        '
        'dgvICU
        '
        Me.dgvICU.AllowUserToOrderColumns = True
        Me.dgvICU.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle89.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle89.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle89.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle89.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle89.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle89.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvICU.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle89
        Me.dgvICU.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colICUCode, Me.colICUQuantity, Me.colICUUnitPrice, Me.colICUAmount, Me.colICUNotes, Me.colICUPayStatus, Me.colICUEntryMode, Me.colICUSaved})
        Me.dgvICU.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvICU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvICU.EnableHeadersVisualStyles = False
        Me.dgvICU.GridColor = System.Drawing.Color.Khaki
        Me.dgvICU.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvICU.Location = New System.Drawing.Point(0, 0)
        Me.dgvICU.Name = "dgvICU"
        DataGridViewCellStyle96.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle96.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle96.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle96.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle96.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle96.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle96.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvICU.RowHeadersDefaultCellStyle = DataGridViewCellStyle96
        Me.dgvICU.Size = New System.Drawing.Size(880, 195)
        Me.dgvICU.TabIndex = 27
        Me.dgvICU.Text = "DataGridView1"
        '
        'colICUCode
        '
        Me.colICUCode.DataPropertyName = "ItemCode"
        Me.colICUCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colICUCode.DisplayStyleForCurrentCellOnly = True
        Me.colICUCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colICUCode.HeaderText = "ICU"
        Me.colICUCode.Name = "colICUCode"
        Me.colICUCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colICUCode.Width = 260
        '
        'colICUQuantity
        '
        Me.colICUQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle90.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle90.Format = "N0"
        DataGridViewCellStyle90.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle90.NullValue = Nothing
        Me.colICUQuantity.DefaultCellStyle = DataGridViewCellStyle90
        Me.colICUQuantity.HeaderText = "Quantity"
        Me.colICUQuantity.MaxInputLength = 12
        Me.colICUQuantity.Name = "colICUQuantity"
        Me.colICUQuantity.Width = 50
        '
        'colICUUnitPrice
        '
        Me.colICUUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle91.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle91.Format = "N2"
        DataGridViewCellStyle91.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle91.NullValue = Nothing
        Me.colICUUnitPrice.DefaultCellStyle = DataGridViewCellStyle91
        Me.colICUUnitPrice.HeaderText = "Unit Price"
        Me.colICUUnitPrice.Name = "colICUUnitPrice"
        Me.colICUUnitPrice.Width = 65
        '
        'colICUAmount
        '
        Me.colICUAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle92.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle92.Format = "N2"
        Me.colICUAmount.DefaultCellStyle = DataGridViewCellStyle92
        Me.colICUAmount.HeaderText = "Amount"
        Me.colICUAmount.Name = "colICUAmount"
        Me.colICUAmount.ReadOnly = True
        Me.colICUAmount.Width = 65
        '
        'colICUNotes
        '
        Me.colICUNotes.DataPropertyName = "Notes"
        Me.colICUNotes.HeaderText = "Notes"
        Me.colICUNotes.MaxInputLength = 200
        Me.colICUNotes.Name = "colICUNotes"
        '
        'colICUPayStatus
        '
        Me.colICUPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle93.BackColor = System.Drawing.SystemColors.Info
        Me.colICUPayStatus.DefaultCellStyle = DataGridViewCellStyle93
        Me.colICUPayStatus.HeaderText = "Pay Status"
        Me.colICUPayStatus.Name = "colICUPayStatus"
        Me.colICUPayStatus.ReadOnly = True
        Me.colICUPayStatus.Width = 80
        '
        'colICUEntryMode
        '
        Me.colICUEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle94.BackColor = System.Drawing.SystemColors.Info
        Me.colICUEntryMode.DefaultCellStyle = DataGridViewCellStyle94
        Me.colICUEntryMode.HeaderText = "Entry Mode"
        Me.colICUEntryMode.Name = "colICUEntryMode"
        Me.colICUEntryMode.ReadOnly = True
        Me.colICUEntryMode.Width = 80
        '
        'colICUSaved
        '
        Me.colICUSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle95.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle95.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle95.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle95.NullValue = False
        Me.colICUSaved.DefaultCellStyle = DataGridViewCellStyle95
        Me.colICUSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colICUSaved.HeaderText = "Saved"
        Me.colICUSaved.Name = "colICUSaved"
        Me.colICUSaved.ReadOnly = True
        Me.colICUSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colICUSaved.Width = 50
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(880, 195)
        Me.tpgConsumables.TabIndex = 12
        Me.tpgConsumables.Tag = "Consumables"
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle97.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle97.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle97.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle97.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle97.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle97.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle97
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableQuantity, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumableNotes, Me.colConsumablePayStatus, Me.colConsumableLocationBalance, Me.colUnitsInStock, Me.colExpiryDate, Me.colOrderLevel, Me.colAlternateName, Me.colConsumableEntryMode, Me.colConsumablesSaved})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle109.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle109.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle109.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle109.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle109.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle109.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle109.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle109
        Me.dgvConsumables.Size = New System.Drawing.Size(880, 195)
        Me.dgvConsumables.TabIndex = 44
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.DataPropertyName = "ItemFullName"
        Me.colConsumableName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colConsumableName.DisplayStyleForCurrentCellOnly = True
        Me.colConsumableName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.Sorted = True
        Me.colConsumableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableName.Width = 260
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle98.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle98.Format = "N0"
        DataGridViewCellStyle98.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle98.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle98
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 50
        '
        'colConsumableUnitPrice
        '
        Me.colConsumableUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle99.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle99.Format = "N2"
        DataGridViewCellStyle99.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle99.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle99
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.Width = 65
        '
        'colConsumableAmount
        '
        Me.colConsumableAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle100.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle100.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle100.Format = "N2"
        DataGridViewCellStyle100.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle100
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 65
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.DataPropertyName = "Notes"
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        '
        'colConsumablePayStatus
        '
        Me.colConsumablePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle101.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablePayStatus.DefaultCellStyle = DataGridViewCellStyle101
        Me.colConsumablePayStatus.HeaderText = "Pay Status"
        Me.colConsumablePayStatus.Name = "colConsumablePayStatus"
        Me.colConsumablePayStatus.ReadOnly = True
        Me.colConsumablePayStatus.Width = 80
        '
        'colConsumableLocationBalance
        '
        DataGridViewCellStyle102.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableLocationBalance.DefaultCellStyle = DataGridViewCellStyle102
        Me.colConsumableLocationBalance.HeaderText = "Location Balance"
        Me.colConsumableLocationBalance.Name = "colConsumableLocationBalance"
        Me.colConsumableLocationBalance.ReadOnly = True
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle103.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle103
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        '
        'colExpiryDate
        '
        DataGridViewCellStyle104.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle104
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        '
        'colOrderLevel
        '
        DataGridViewCellStyle105.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle105
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        '
        'colAlternateName
        '
        DataGridViewCellStyle106.BackColor = System.Drawing.SystemColors.Info
        Me.colAlternateName.DefaultCellStyle = DataGridViewCellStyle106
        Me.colAlternateName.HeaderText = "Alternate Name"
        Me.colAlternateName.Name = "colAlternateName"
        Me.colAlternateName.ReadOnly = True
        '
        'colConsumableEntryMode
        '
        Me.colConsumableEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle107.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableEntryMode.DefaultCellStyle = DataGridViewCellStyle107
        Me.colConsumableEntryMode.HeaderText = "Entry Mode"
        Me.colConsumableEntryMode.Name = "colConsumableEntryMode"
        Me.colConsumableEntryMode.ReadOnly = True
        Me.colConsumableEntryMode.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle108.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle108.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle108.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle108.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle108
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'tpgExtraCharge
        '
        Me.tpgExtraCharge.Controls.Add(Me.dgvExtraCharge)
        Me.tpgExtraCharge.Location = New System.Drawing.Point(4, 22)
        Me.tpgExtraCharge.Name = "tpgExtraCharge"
        Me.tpgExtraCharge.Size = New System.Drawing.Size(880, 195)
        Me.tpgExtraCharge.TabIndex = 6
        Me.tpgExtraCharge.Tag = ""
        Me.tpgExtraCharge.Text = "Other Items"
        Me.tpgExtraCharge.UseVisualStyleBackColor = True
        '
        'dgvExtraCharge
        '
        Me.dgvExtraCharge.AllowUserToOrderColumns = True
        Me.dgvExtraCharge.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle110.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle110.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle110.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle110.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle110.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle110.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle110
        Me.dgvExtraCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExtraItemFullName, Me.colExtraChargeQuantity, Me.colExtraChargeUnitPrice, Me.colExtraChargeAmount, Me.colExtraChargeNotes, Me.colExtraChargePayStatus, Me.colExtraChargeEntryMode, Me.colExtraChargeSaved})
        Me.dgvExtraCharge.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvExtraCharge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtraCharge.EnableHeadersVisualStyles = False
        Me.dgvExtraCharge.GridColor = System.Drawing.Color.Khaki
        Me.dgvExtraCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvExtraCharge.Location = New System.Drawing.Point(0, 0)
        Me.dgvExtraCharge.Name = "dgvExtraCharge"
        DataGridViewCellStyle117.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle117.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle117.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle117.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle117.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle117.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle117.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.RowHeadersDefaultCellStyle = DataGridViewCellStyle117
        Me.dgvExtraCharge.Size = New System.Drawing.Size(880, 195)
        Me.dgvExtraCharge.TabIndex = 0
        Me.dgvExtraCharge.Text = "DataGridView1"
        '
        'colExtraItemFullName
        '
        Me.colExtraItemFullName.DataPropertyName = "ItemFullName"
        Me.colExtraItemFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colExtraItemFullName.DisplayStyleForCurrentCellOnly = True
        Me.colExtraItemFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraItemFullName.HeaderText = "Item Name"
        Me.colExtraItemFullName.Name = "colExtraItemFullName"
        Me.colExtraItemFullName.Sorted = True
        Me.colExtraItemFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExtraItemFullName.Width = 260
        '
        'colExtraChargeQuantity
        '
        Me.colExtraChargeQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle111.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle111.Format = "N0"
        DataGridViewCellStyle111.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle111.NullValue = Nothing
        Me.colExtraChargeQuantity.DefaultCellStyle = DataGridViewCellStyle111
        Me.colExtraChargeQuantity.HeaderText = "Quantity"
        Me.colExtraChargeQuantity.MaxInputLength = 12
        Me.colExtraChargeQuantity.Name = "colExtraChargeQuantity"
        Me.colExtraChargeQuantity.Width = 50
        '
        'colExtraChargeUnitPrice
        '
        Me.colExtraChargeUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle112.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle112.Format = "N2"
        DataGridViewCellStyle112.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle112.NullValue = Nothing
        Me.colExtraChargeUnitPrice.DefaultCellStyle = DataGridViewCellStyle112
        Me.colExtraChargeUnitPrice.HeaderText = "Unit Price"
        Me.colExtraChargeUnitPrice.Name = "colExtraChargeUnitPrice"
        Me.colExtraChargeUnitPrice.Width = 65
        '
        'colExtraChargeAmount
        '
        Me.colExtraChargeAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle113.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle113.Format = "N2"
        DataGridViewCellStyle113.NullValue = Nothing
        Me.colExtraChargeAmount.DefaultCellStyle = DataGridViewCellStyle113
        Me.colExtraChargeAmount.HeaderText = "Amount"
        Me.colExtraChargeAmount.Name = "colExtraChargeAmount"
        Me.colExtraChargeAmount.ReadOnly = True
        Me.colExtraChargeAmount.Width = 65
        '
        'colExtraChargeNotes
        '
        Me.colExtraChargeNotes.DataPropertyName = "Notes"
        Me.colExtraChargeNotes.HeaderText = "Notes"
        Me.colExtraChargeNotes.MaxInputLength = 200
        Me.colExtraChargeNotes.Name = "colExtraChargeNotes"
        '
        'colExtraChargePayStatus
        '
        Me.colExtraChargePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle114.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraChargePayStatus.DefaultCellStyle = DataGridViewCellStyle114
        Me.colExtraChargePayStatus.HeaderText = "Pay Status"
        Me.colExtraChargePayStatus.Name = "colExtraChargePayStatus"
        Me.colExtraChargePayStatus.ReadOnly = True
        Me.colExtraChargePayStatus.Width = 80
        '
        'colExtraChargeEntryMode
        '
        Me.colExtraChargeEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle115.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraChargeEntryMode.DefaultCellStyle = DataGridViewCellStyle115
        Me.colExtraChargeEntryMode.HeaderText = "Entry Mode"
        Me.colExtraChargeEntryMode.Name = "colExtraChargeEntryMode"
        Me.colExtraChargeEntryMode.ReadOnly = True
        Me.colExtraChargeEntryMode.Width = 80
        '
        'colExtraChargeSaved
        '
        Me.colExtraChargeSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle116.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle116.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle116.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle116.NullValue = False
        Me.colExtraChargeSaved.DefaultCellStyle = DataGridViewCellStyle116
        Me.colExtraChargeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraChargeSaved.HeaderText = "Saved"
        Me.colExtraChargeSaved.Name = "colExtraChargeSaved"
        Me.colExtraChargeSaved.ReadOnly = True
        Me.colExtraChargeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExtraChargeSaved.Width = 50
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(753, 476)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 51
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintInvoiceOnSaving
        '
        Me.chkPrintInvoiceOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInvoiceOnSaving.AutoSize = True
        Me.chkPrintInvoiceOnSaving.Checked = True
        Me.chkPrintInvoiceOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintInvoiceOnSaving.Location = New System.Drawing.Point(96, 482)
        Me.chkPrintInvoiceOnSaving.Name = "chkPrintInvoiceOnSaving"
        Me.chkPrintInvoiceOnSaving.Size = New System.Drawing.Size(141, 17)
        Me.chkPrintInvoiceOnSaving.TabIndex = 50
        Me.chkPrintInvoiceOnSaving.Text = " Print Invoice On Saving"
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(320, 136)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(137, 20)
        Me.lblCashAccountBalance.TabIndex = 29
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(320, 113)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(137, 20)
        Me.lblRoundNo.TabIndex = 27
        Me.lblRoundNo.Text = "Round No"
        '
        'fbnViewFullInvoice
        '
        Me.fbnViewFullInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnViewFullInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnViewFullInvoice.Enabled = False
        Me.fbnViewFullInvoice.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnViewFullInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnViewFullInvoice.Location = New System.Drawing.Point(96, 448)
        Me.fbnViewFullInvoice.Name = "fbnViewFullInvoice"
        Me.fbnViewFullInvoice.Size = New System.Drawing.Size(141, 24)
        Me.fbnViewFullInvoice.TabIndex = 46
        Me.fbnViewFullInvoice.Tag = "ExtraBills"
        Me.fbnViewFullInvoice.Text = "&View Full Invoice"
        Me.fbnViewFullInvoice.UseVisualStyleBackColor = False
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(320, 84)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(133, 18)
        Me.lblBillInsuranceName.TabIndex = 41
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(12, 71)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(124, 20)
        Me.lblStaffNo.TabIndex = 9
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(142, 134)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(170, 21)
        Me.cboLocationID.TabIndex = 62
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(12, 137)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(124, 20)
        Me.lblLocationID.TabIndex = 61
        Me.lblLocationID.Text = "Location"
        '
        'frmExtraBills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(920, 515)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.fbnViewFullInvoice)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.nbxCashAccountBalance)
        Me.Controls.Add(Me.lblCashAccountBalance)
        Me.Controls.Add(Me.chkPrintInvoiceOnSaving)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.tbcExtraBills)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbVisitStatus)
        Me.Controls.Add(Me.lblVisitStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.dtpExtraBillDate)
        Me.Controls.Add(Me.lblExtraBillDate)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.pnlNavigateExtraBills)
        Me.Controls.Add(Me.btnFindExtraBillNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbExtraBillNo)
        Me.Controls.Add(Me.lblExtraBillNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmExtraBills"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Billing Form"
        Me.pnlNavigateExtraBills.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.tbcExtraBills.ResumeLayout(False)
        Me.tpgAdmission.ResumeLayout(False)
        CType(Me.dgvAdmission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgServices.ResumeLayout(False)
        CType(Me.dgvServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsExtraBills.ResumeLayout(False)
        Me.tpgLaboratory.ResumeLayout(False)
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgRadiology.ResumeLayout(False)
        CType(Me.dgvRadiology, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPrescriptions.ResumeLayout(False)
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgProcedures.ResumeLayout(False)
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgDental.ResumeLayout(False)
        CType(Me.dgvDental, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgTheatre.ResumeLayout(False)
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOptical.ResumeLayout(False)
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgMaternity.ResumeLayout(False)
        CType(Me.dgvMaternity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgICU.ResumeLayout(False)
        CType(Me.dgvICU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgExtraCharge.ResumeLayout(False)
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbExtraBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExtraBillNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindExtraBillNo As System.Windows.Forms.Button
    Friend WithEvents navExtraBills As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateExtraBills As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNavigateExtraBills As System.Windows.Forms.Panel
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents dtpExtraBillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExtraBillDate As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbVisitStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents tbcExtraBills As System.Windows.Forms.TabControl
    Friend WithEvents tpgLaboratory As System.Windows.Forms.TabPage
    Friend WithEvents dgvLabTests As System.Windows.Forms.DataGridView
    Friend WithEvents tpgRadiology As System.Windows.Forms.TabPage
    Friend WithEvents dgvRadiology As System.Windows.Forms.DataGridView
    Friend WithEvents tpgPrescriptions As System.Windows.Forms.TabPage
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents tpgProcedures As System.Windows.Forms.TabPage
    Friend WithEvents dgvProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents tpgDental As System.Windows.Forms.TabPage
    Friend WithEvents dgvDental As System.Windows.Forms.DataGridView
    Friend WithEvents tpgExtraCharge As System.Windows.Forms.TabPage
    Friend WithEvents dgvExtraCharge As System.Windows.Forms.DataGridView
    Friend WithEvents tpgServices As System.Windows.Forms.TabPage
    Friend WithEvents dgvServices As System.Windows.Forms.DataGridView
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintInvoiceOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents tpgTheatre As System.Windows.Forms.TabPage
    Friend WithEvents tpgOptical As System.Windows.Forms.TabPage
    Friend WithEvents tpgMaternity As System.Windows.Forms.TabPage
    Friend WithEvents tpgICU As System.Windows.Forms.TabPage
    Friend WithEvents dgvTheatre As System.Windows.Forms.DataGridView
    Friend WithEvents dgvOptical As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMaternity As System.Windows.Forms.DataGridView
    Friend WithEvents dgvICU As System.Windows.Forms.DataGridView
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents colServiceCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colServiceQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServicePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServicesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExamFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colRadiologyQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colProcedureQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedurePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProceduresSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDentalCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDentalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colOpticalCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOpticalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMaternityCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMaternityQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternityUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternityAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternityNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternityPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternityEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMaternitySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colICUCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colICUQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colICUSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExtraItemFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colExtraChargeQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents fbnViewFullInvoice As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents colTheatreCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTheatreQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatrePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents tpgAdmission As System.Windows.Forms.TabPage
    Friend WithEvents dgvAdmission As System.Windows.Forms.DataGridView
    Friend WithEvents colAdmissionBedNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionBedName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmsExtraBills As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsExtraBillsQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colTest As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLTQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabTestsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHasAlternateDrugs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDugAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class