
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelfRequests : Inherits System.Windows.Forms.Form

 
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
    End Sub

    Public Sub New(ByVal setCurrentPatient As Boolean)
        MyClass.New()
        Me._SetCurrentPatient = setCurrentPatient
    End Sub

    Public Sub New(ByVal setCurrentPatient As Boolean, ByVal existingPatientNo As String)
        MyClass.New(setCurrentPatient)
        Me._ExistingPatientNo = existingPatientNo
    End Sub

    Public Sub New(ByVal setCurrentPatient As Boolean, ByVal existingPatientNo As String, ByVal existingVisitNo As String)
        MyClass.New(setCurrentPatient)
        Me._ExistingPatientNo = existingPatientNo
        Me.existingVisitNo = existingVisitNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelfRequests))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle76 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle73 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle74 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle75 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle77 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle84 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle78 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle79 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle80 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle81 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle82 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle83 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle85 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle93 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle86 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle87 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle88 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle89 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle90 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle91 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle92 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle94 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle109 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fcbGenderID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.nbxAge = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBillNo = New System.Windows.Forms.ComboBox()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCoPayTypeID = New System.Windows.Forms.ComboBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboAssociatedBillNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.tbcDrRoles = New System.Windows.Forms.TabControl()
        Me.tpgExtraCharge = New System.Windows.Forms.TabPage()
        Me.dgvExtraCharge = New System.Windows.Forms.DataGridView()
        Me.colItemName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsSelfRequests = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsSelfRequestsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.tpgLaboratory = New System.Windows.Forms.TabPage()
        Me.dgvLabTests = New System.Windows.Forms.DataGridView()
        Me.colTest = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColLabNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLaboratoryUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLTPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLabTestsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgRadiology = New System.Windows.Forms.TabPage()
        Me.dgvRadiology = New System.Windows.Forms.DataGridView()
        Me.colExamFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colRadiologyIndication = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologyPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPathology = New System.Windows.Forms.TabPage()
        Me.dgvHistopathologyRequisition = New System.Windows.Forms.DataGridView()
        Me.colPathologyExamFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPathologyIndication = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologyPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPathologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPrescriptions = New System.Windows.Forms.TabPage()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.ColDrugselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvailableStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colHasAlternateDrugs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgProcedures = New System.Windows.Forms.TabPage()
        Me.dgvProcedures = New System.Windows.Forms.DataGridView()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colICDProcedureCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedurePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProceduresSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgcardiology = New System.Windows.Forms.TabPage()
        Me.dgvCardiology = New System.Windows.Forms.DataGridView()
        Me.colCardiologyExamFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCardiologyIndication = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologySite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyRequest = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologyPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCardiologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgTheatre = New System.Windows.Forms.TabPage()
        Me.dgvTheatre = New System.Windows.Forms.DataGridView()
        Me.colTheatreCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colICDTheatreCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatrePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgDental = New System.Windows.Forms.TabPage()
        Me.dgvDental = New System.Windows.Forms.DataGridView()
        Me.colDentalCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDentalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDentalSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgOptical = New System.Windows.Forms.TabPage()
        Me.dgvOptical = New System.Windows.Forms.DataGridView()
        Me.colOpticalCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colOpticalCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOpticalSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.ColConsSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ColConsumableBarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConsumableOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.pnlPatients = New System.Windows.Forms.Panel()
        Me.lblPhoneNo = New System.Windows.Forms.Label()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.chkUseExistingPatient = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintVisitOnSaving = New System.Windows.Forms.CheckBox()
        Me.pnlPrintVisitOnSaving = New System.Windows.Forms.Panel()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblAssociatedBillNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.cmsFrequentlyRequestedTests = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbcDrRoles.SuspendLayout()
        Me.tpgExtraCharge.SuspendLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsSelfRequests.SuspendLayout()
        Me.tpgLaboratory.SuspendLayout()
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgRadiology.SuspendLayout()
        CType(Me.dgvRadiology, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPathology.SuspendLayout()
        CType(Me.dgvHistopathologyRequisition, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPrescriptions.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgProcedures.SuspendLayout()
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgcardiology.SuspendLayout()
        CType(Me.dgvCardiology, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgTheatre.SuspendLayout()
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgDental.SuspendLayout()
        CType(Me.dgvDental, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOptical.SuspendLayout()
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.pnlPatients.SuspendLayout()
        Me.pnlPrintVisitOnSaving.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(123, 47)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 5
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(4, 455)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(837, 454)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 34
        Me.btnDelete.Tag = "SelfRequests"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(4, 484)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 35
        Me.ebnSaveUpdate.Tag = "SelfRequests"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(152, 26)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(145, 20)
        Me.stbPatientNo.TabIndex = 3
        '
        'dtpVisitDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpVisitDate, "VisitDate")
        Me.dtpVisitDate.Location = New System.Drawing.Point(152, 68)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.ShowCheckBox = True
        Me.dtpVisitDate.Size = New System.Drawing.Size(145, 20)
        Me.dtpVisitDate.TabIndex = 8
        '
        'cboBillModesID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillModesID, "BillMode,BillModesID")
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(152, 88)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(145, 21)
        Me.cboBillModesID.TabIndex = 10
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        Me.stbMiddleName.Location = New System.Drawing.Point(122, 45)
        Me.stbMiddleName.MaxLength = 20
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        Me.stbMiddleName.Size = New System.Drawing.Size(153, 20)
        Me.stbMiddleName.TabIndex = 5
        '
        'fcbGenderID
        '
        Me.fcbGenderID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbGenderID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbGenderID, "Gender,GenderID")
        Me.fcbGenderID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbGenderID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbGenderID.FormattingEnabled = True
        Me.fcbGenderID.Location = New System.Drawing.Point(122, 107)
        Me.fcbGenderID.Name = "fcbGenderID"
        Me.fcbGenderID.ReadOnly = True
        Me.fcbGenderID.Size = New System.Drawing.Size(91, 21)
        Me.fcbGenderID.TabIndex = 11
        '
        'nbxAge
        '
        Me.nbxAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAge.ControlCaption = "Age"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAge, "Age")
        Me.nbxAge.DecimalPlaces = -1
        Me.nbxAge.Location = New System.Drawing.Point(122, 86)
        Me.nbxAge.MaxLength = 3
        Me.nbxAge.MaxValue = 200.0R
        Me.nbxAge.MinValue = 0.0R
        Me.nbxAge.Name = "nbxAge"
        Me.nbxAge.Size = New System.Drawing.Size(91, 20)
        Me.nbxAge.TabIndex = 9
        Me.nbxAge.Value = ""
        Me.nbxAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.Standard
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBirthDate, "BirthDate")
        Me.dtpBirthDate.Location = New System.Drawing.Point(122, 66)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(153, 20)
        Me.dtpBirthDate.TabIndex = 7
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastName, "LastName")
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(122, 3)
        Me.stbLastName.MaxLength = 20
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(153, 20)
        Me.stbLastName.TabIndex = 1
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(122, 24)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(153, 20)
        Me.stbFirstName.TabIndex = 3
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(122, 130)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(153, 20)
        Me.stbPhone.TabIndex = 13
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(733, 4)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(159, 23)
        Me.stbBillCustomerName.TabIndex = 20
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(733, 28)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(159, 23)
        Me.stbInsuranceName.TabIndex = 22
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberCardNo, "MemberCardNo")
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(152, 133)
        Me.stbMemberCardNo.MaxLength = 30
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(145, 20)
        Me.stbMemberCardNo.TabIndex = 14
        '
        'cboBillNo
        '
        Me.cboBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillNo, "BillNo")
        Me.cboBillNo.DropDownWidth = 256
        Me.cboBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillNo.FormattingEnabled = True
        Me.cboBillNo.ItemHeight = 13
        Me.cboBillNo.Location = New System.Drawing.Point(152, 110)
        Me.cboBillNo.Name = "cboBillNo"
        Me.cboBillNo.Size = New System.Drawing.Size(145, 21)
        Me.cboBillNo.TabIndex = 12
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberName, "MainMemberName")
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(152, 154)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(145, 20)
        Me.stbMainMemberName.TabIndex = 16
        '
        'cboCoPayTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoPayTypeID, "CoPayType,CoPayTypeID")
        Me.cboCoPayTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoPayTypeID.Enabled = False
        Me.cboCoPayTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoPayTypeID.Location = New System.Drawing.Point(733, 74)
        Me.cboCoPayTypeID.Name = "cboCoPayTypeID"
        Me.cboCoPayTypeID.Size = New System.Drawing.Size(159, 21)
        Me.cboCoPayTypeID.TabIndex = 26
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(733, 97)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(159, 20)
        Me.nbxCoPayPercent.TabIndex = 28
        Me.nbxCoPayPercent.Value = ""
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(733, 118)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(159, 20)
        Me.nbxCoPayValue.TabIndex = 30
        Me.nbxCoPayValue.Value = ""
        '
        'cboAssociatedBillNo
        '
        Me.cboAssociatedBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssociatedBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboAssociatedBillNo, "AssociatedFullBillCustomer")
        Me.cboAssociatedBillNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssociatedBillNo.DropDownWidth = 230
        Me.cboAssociatedBillNo.Enabled = False
        Me.cboAssociatedBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAssociatedBillNo.FormattingEnabled = True
        Me.cboAssociatedBillNo.Location = New System.Drawing.Point(733, 52)
        Me.cboAssociatedBillNo.Name = "cboAssociatedBillNo"
        Me.cboAssociatedBillNo.Size = New System.Drawing.Size(159, 21)
        Me.cboAssociatedBillNo.Sorted = True
        Me.cboAssociatedBillNo.TabIndex = 24
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(837, 483)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 38
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(152, 47)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(145, 20)
        Me.stbVisitNo.TabIndex = 6
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(6, 70)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(140, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(6, 48)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(91, 18)
        Me.lblVisitNo.TabIndex = 4
        Me.lblVisitNo.Text = "Visit Number"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(6, 26)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(140, 20)
        Me.lblPatientNo.TabIndex = 2
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'tbcDrRoles
        '
        Me.tbcDrRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDrRoles.Controls.Add(Me.tpgExtraCharge)
        Me.tbcDrRoles.Controls.Add(Me.tpgLaboratory)
        Me.tbcDrRoles.Controls.Add(Me.tpgRadiology)
        Me.tbcDrRoles.Controls.Add(Me.tpgPathology)
        Me.tbcDrRoles.Controls.Add(Me.tpgPrescriptions)
        Me.tbcDrRoles.Controls.Add(Me.tpgProcedures)
        Me.tbcDrRoles.Controls.Add(Me.tpgcardiology)
        Me.tbcDrRoles.Controls.Add(Me.tpgTheatre)
        Me.tbcDrRoles.Controls.Add(Me.tpgDental)
        Me.tbcDrRoles.Controls.Add(Me.tpgOptical)
        Me.tbcDrRoles.Controls.Add(Me.tpgConsumables)
        Me.tbcDrRoles.HotTrack = True
        Me.tbcDrRoles.Location = New System.Drawing.Point(4, 222)
        Me.tbcDrRoles.Name = "tbcDrRoles"
        Me.tbcDrRoles.SelectedIndex = 0
        Me.tbcDrRoles.Size = New System.Drawing.Size(916, 227)
        Me.tbcDrRoles.TabIndex = 32
        '
        'tpgExtraCharge
        '
        Me.tpgExtraCharge.Controls.Add(Me.dgvExtraCharge)
        Me.tpgExtraCharge.Location = New System.Drawing.Point(4, 22)
        Me.tpgExtraCharge.Name = "tpgExtraCharge"
        Me.tpgExtraCharge.Size = New System.Drawing.Size(884, 201)
        Me.tpgExtraCharge.TabIndex = 6
        Me.tpgExtraCharge.Tag = "ExtraCharge"
        Me.tpgExtraCharge.Text = "Extra Charge"
        Me.tpgExtraCharge.UseVisualStyleBackColor = True
        '
        'dgvExtraCharge
        '
        Me.dgvExtraCharge.AllowUserToOrderColumns = True
        Me.dgvExtraCharge.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colNotes, Me.colExtraChargeQuantity, Me.colExtraChargeUnitPrice, Me.colExtraChargeAmount, Me.colExtraChargeSaved})
        Me.dgvExtraCharge.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvExtraCharge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtraCharge.EnableHeadersVisualStyles = False
        Me.dgvExtraCharge.GridColor = System.Drawing.Color.Khaki
        Me.dgvExtraCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvExtraCharge.Location = New System.Drawing.Point(0, 0)
        Me.dgvExtraCharge.Name = "dgvExtraCharge"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvExtraCharge.Size = New System.Drawing.Size(884, 201)
        Me.dgvExtraCharge.TabIndex = 0
        Me.dgvExtraCharge.Text = "DataGridView1"
        '
        'colItemName
        '
        Me.colItemName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colItemName.DisplayStyleForCurrentCellOnly = True
        Me.colItemName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Sorted = True
        Me.colItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colItemName.Width = 200
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 40
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 200
        '
        'colExtraChargeQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colExtraChargeQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExtraChargeQuantity.HeaderText = "Quantity"
        Me.colExtraChargeQuantity.MaxInputLength = 12
        Me.colExtraChargeQuantity.Name = "colExtraChargeQuantity"
        Me.colExtraChargeQuantity.Width = 80
        '
        'colExtraChargeUnitPrice
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colExtraChargeUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.colExtraChargeUnitPrice.HeaderText = "Unit Price"
        Me.colExtraChargeUnitPrice.Name = "colExtraChargeUnitPrice"
        Me.colExtraChargeUnitPrice.Width = 120
        '
        'colExtraChargeAmount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colExtraChargeAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colExtraChargeAmount.HeaderText = "Amount"
        Me.colExtraChargeAmount.MaxInputLength = 12
        Me.colExtraChargeAmount.Name = "colExtraChargeAmount"
        Me.colExtraChargeAmount.ReadOnly = True
        Me.colExtraChargeAmount.Width = 120
        '
        'colExtraChargeSaved
        '
        Me.colExtraChargeSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = False
        Me.colExtraChargeSaved.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExtraChargeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraChargeSaved.HeaderText = "Saved"
        Me.colExtraChargeSaved.Name = "colExtraChargeSaved"
        Me.colExtraChargeSaved.ReadOnly = True
        Me.colExtraChargeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExtraChargeSaved.Width = 50
        '
        'cmsSelfRequests
        '
        Me.cmsSelfRequests.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsSelfRequests.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsSelfRequestsQuickSearch, Me.cmsFrequentlyRequestedTests})
        Me.cmsSelfRequests.Name = "cmsSearch"
        Me.cmsSelfRequests.Size = New System.Drawing.Size(218, 48)
        '
        'cmsSelfRequestsQuickSearch
        '
        Me.cmsSelfRequestsQuickSearch.Image = CType(resources.GetObject("cmsSelfRequestsQuickSearch.Image"), System.Drawing.Image)
        Me.cmsSelfRequestsQuickSearch.Name = "cmsSelfRequestsQuickSearch"
        Me.cmsSelfRequestsQuickSearch.Size = New System.Drawing.Size(217, 22)
        Me.cmsSelfRequestsQuickSearch.Text = "Quick Search"
        '
        'tpgLaboratory
        '
        Me.tpgLaboratory.Controls.Add(Me.dgvLabTests)
        Me.tpgLaboratory.Location = New System.Drawing.Point(4, 22)
        Me.tpgLaboratory.Name = "tpgLaboratory"
        Me.tpgLaboratory.Size = New System.Drawing.Size(908, 201)
        Me.tpgLaboratory.TabIndex = 0
        Me.tpgLaboratory.Tag = "DoctorLaboratory"
        Me.tpgLaboratory.Text = "Laboratory"
        Me.tpgLaboratory.UseVisualStyleBackColor = True
        '
        'dgvLabTests
        '
        Me.dgvLabTests.AllowUserToOrderColumns = True
        Me.dgvLabTests.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvLabTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTest, Me.ColLabNotes, Me.colLTQuantity, Me.colLaboratoryUnitMeasure, Me.colLTUnitPrice, Me.colLTItemStatus, Me.colLTPayStatus, Me.colLabTestsSaved})
        Me.dgvLabTests.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvLabTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLabTests.EnableHeadersVisualStyles = False
        Me.dgvLabTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvLabTests.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabTests.Location = New System.Drawing.Point(0, 0)
        Me.dgvLabTests.Name = "dgvLabTests"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLabTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvLabTests.Size = New System.Drawing.Size(908, 201)
        Me.dgvLabTests.TabIndex = 0
        Me.dgvLabTests.Text = "DataGridView1"
        '
        'colTest
        '
        Me.colTest.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colTest.DisplayStyleForCurrentCellOnly = True
        Me.colTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTest.HeaderText = "Test"
        Me.colTest.Name = "colTest"
        Me.colTest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTest.Width = 250
        '
        'ColLabNotes
        '
        Me.ColLabNotes.HeaderText = "Notes"
        Me.ColLabNotes.MaxInputLength = 800
        Me.ColLabNotes.Name = "ColLabNotes"
        Me.ColLabNotes.Width = 140
        '
        'colLTQuantity
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colLTQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colLTQuantity.HeaderText = "Quantity"
        Me.colLTQuantity.Name = "colLTQuantity"
        Me.colLTQuantity.ReadOnly = True
        Me.colLTQuantity.Width = 80
        '
        'colLaboratoryUnitMeasure
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colLaboratoryUnitMeasure.DefaultCellStyle = DataGridViewCellStyle9
        Me.colLaboratoryUnitMeasure.HeaderText = "Unit Measure"
        Me.colLaboratoryUnitMeasure.Name = "colLaboratoryUnitMeasure"
        Me.colLaboratoryUnitMeasure.ReadOnly = True
        Me.colLaboratoryUnitMeasure.Width = 80
        '
        'colLTUnitPrice
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colLTUnitPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.colLTUnitPrice.HeaderText = "Unit Price"
        Me.colLTUnitPrice.Name = "colLTUnitPrice"
        Me.colLTUnitPrice.ReadOnly = True
        Me.colLTUnitPrice.Width = 80
        '
        'colLTItemStatus
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colLTItemStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colLTItemStatus.HeaderText = "Item Status"
        Me.colLTItemStatus.Name = "colLTItemStatus"
        Me.colLTItemStatus.ReadOnly = True
        Me.colLTItemStatus.Width = 80
        '
        'colLTPayStatus
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colLTPayStatus.DefaultCellStyle = DataGridViewCellStyle12
        Me.colLTPayStatus.HeaderText = "Pay Status"
        Me.colLTPayStatus.Name = "colLTPayStatus"
        Me.colLTPayStatus.ReadOnly = True
        Me.colLTPayStatus.Width = 80
        '
        'colLabTestsSaved
        '
        Me.colLabTestsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.NullValue = False
        Me.colLabTestsSaved.DefaultCellStyle = DataGridViewCellStyle13
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
        Me.tpgRadiology.Size = New System.Drawing.Size(884, 201)
        Me.tpgRadiology.TabIndex = 3
        Me.tpgRadiology.Tag = "DoctorRadiology"
        Me.tpgRadiology.Text = "Radiology"
        Me.tpgRadiology.UseVisualStyleBackColor = True
        '
        'dgvRadiology
        '
        Me.dgvRadiology.AllowUserToOrderColumns = True
        Me.dgvRadiology.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadiology.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvRadiology.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExamFullName, Me.colRadiologyIndication, Me.colRadiologyCategory, Me.colRadiologyQuantity, Me.colRadiologyUnitPrice, Me.colRadiologyItemStatus, Me.colRadiologyPayStatus, Me.colRadiologySaved})
        Me.dgvRadiology.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvRadiology.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRadiology.EnableHeadersVisualStyles = False
        Me.dgvRadiology.GridColor = System.Drawing.Color.Khaki
        Me.dgvRadiology.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvRadiology.Location = New System.Drawing.Point(0, 0)
        Me.dgvRadiology.Name = "dgvRadiology"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRadiology.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvRadiology.Size = New System.Drawing.Size(884, 201)
        Me.dgvRadiology.TabIndex = 22
        Me.dgvRadiology.Text = "DataGridView1"
        '
        'colExamFullName
        '
        Me.colExamFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colExamFullName.DisplayStyleForCurrentCellOnly = True
        Me.colExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExamFullName.HeaderText = "Radiology Examination"
        Me.colExamFullName.Name = "colExamFullName"
        Me.colExamFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExamFullName.Width = 230
        '
        'colRadiologyIndication
        '
        Me.colRadiologyIndication.HeaderText = "Indication"
        Me.colRadiologyIndication.MaxInputLength = 800
        Me.colRadiologyIndication.Name = "colRadiologyIndication"
        Me.colRadiologyIndication.Width = 120
        '
        'colRadiologyCategory
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colRadiologyCategory.DefaultCellStyle = DataGridViewCellStyle16
        Me.colRadiologyCategory.HeaderText = "Category"
        Me.colRadiologyCategory.Name = "colRadiologyCategory"
        Me.colRadiologyCategory.ReadOnly = True
        Me.colRadiologyCategory.Width = 80
        '
        'colRadiologyQuantity
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.Format = "N0"
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colRadiologyQuantity.DefaultCellStyle = DataGridViewCellStyle17
        Me.colRadiologyQuantity.HeaderText = "Quantity"
        Me.colRadiologyQuantity.Name = "colRadiologyQuantity"
        Me.colRadiologyQuantity.ReadOnly = True
        Me.colRadiologyQuantity.Width = 75
        '
        'colRadiologyUnitPrice
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.Format = "N2"
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.NullValue = Nothing
        Me.colRadiologyUnitPrice.DefaultCellStyle = DataGridViewCellStyle18
        Me.colRadiologyUnitPrice.HeaderText = "Unit Price"
        Me.colRadiologyUnitPrice.Name = "colRadiologyUnitPrice"
        Me.colRadiologyUnitPrice.ReadOnly = True
        Me.colRadiologyUnitPrice.Width = 80
        '
        'colRadiologyItemStatus
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colRadiologyItemStatus.DefaultCellStyle = DataGridViewCellStyle19
        Me.colRadiologyItemStatus.HeaderText = "Item Status"
        Me.colRadiologyItemStatus.Name = "colRadiologyItemStatus"
        Me.colRadiologyItemStatus.ReadOnly = True
        Me.colRadiologyItemStatus.Width = 80
        '
        'colRadiologyPayStatus
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colRadiologyPayStatus.DefaultCellStyle = DataGridViewCellStyle20
        Me.colRadiologyPayStatus.HeaderText = "Pay Status"
        Me.colRadiologyPayStatus.Name = "colRadiologyPayStatus"
        Me.colRadiologyPayStatus.ReadOnly = True
        Me.colRadiologyPayStatus.Width = 80
        '
        'colRadiologySaved
        '
        Me.colRadiologySaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.NullValue = False
        Me.colRadiologySaved.DefaultCellStyle = DataGridViewCellStyle21
        Me.colRadiologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRadiologySaved.HeaderText = "Saved"
        Me.colRadiologySaved.Name = "colRadiologySaved"
        Me.colRadiologySaved.ReadOnly = True
        Me.colRadiologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colRadiologySaved.Width = 50
        '
        'tpgPathology
        '
        Me.tpgPathology.Controls.Add(Me.dgvHistopathologyRequisition)
        Me.tpgPathology.Location = New System.Drawing.Point(4, 22)
        Me.tpgPathology.Name = "tpgPathology"
        Me.tpgPathology.Size = New System.Drawing.Size(884, 201)
        Me.tpgPathology.TabIndex = 10
        Me.tpgPathology.Tag = "DoctorPathology"
        Me.tpgPathology.Text = "Pathology"
        Me.tpgPathology.UseVisualStyleBackColor = True
        '
        'dgvHistopathologyRequisition
        '
        Me.dgvHistopathologyRequisition.AllowUserToOrderColumns = True
        Me.dgvHistopathologyRequisition.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistopathologyRequisition.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvHistopathologyRequisition.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPathologyExamFullName, Me.colPathologyIndication, Me.colPathologyCategory, Me.colPathologyQuantity, Me.colPathologyUnitPrice, Me.colPathologyItemStatus, Me.colPathologyPayStatus, Me.colPathologySaved})
        Me.dgvHistopathologyRequisition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvHistopathologyRequisition.EnableHeadersVisualStyles = False
        Me.dgvHistopathologyRequisition.GridColor = System.Drawing.Color.Khaki
        Me.dgvHistopathologyRequisition.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvHistopathologyRequisition.Location = New System.Drawing.Point(0, 0)
        Me.dgvHistopathologyRequisition.Name = "dgvHistopathologyRequisition"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHistopathologyRequisition.RowHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvHistopathologyRequisition.Size = New System.Drawing.Size(884, 201)
        Me.dgvHistopathologyRequisition.TabIndex = 23
        Me.dgvHistopathologyRequisition.Text = "DataGridView1"
        '
        'colPathologyExamFullName
        '
        Me.colPathologyExamFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colPathologyExamFullName.DisplayStyleForCurrentCellOnly = True
        Me.colPathologyExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPathologyExamFullName.HeaderText = "Test"
        Me.colPathologyExamFullName.Name = "colPathologyExamFullName"
        Me.colPathologyExamFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPathologyExamFullName.Width = 250
        '
        'colPathologyIndication
        '
        Me.colPathologyIndication.HeaderText = "Indication"
        Me.colPathologyIndication.MaxInputLength = 800
        Me.colPathologyIndication.Name = "colPathologyIndication"
        Me.colPathologyIndication.Width = 120
        '
        'colPathologyCategory
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colPathologyCategory.DefaultCellStyle = DataGridViewCellStyle24
        Me.colPathologyCategory.HeaderText = "Category"
        Me.colPathologyCategory.Name = "colPathologyCategory"
        Me.colPathologyCategory.ReadOnly = True
        Me.colPathologyCategory.Width = 80
        '
        'colPathologyQuantity
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle25.Format = "N0"
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.NullValue = Nothing
        Me.colPathologyQuantity.DefaultCellStyle = DataGridViewCellStyle25
        Me.colPathologyQuantity.HeaderText = "Quantity"
        Me.colPathologyQuantity.Name = "colPathologyQuantity"
        Me.colPathologyQuantity.ReadOnly = True
        Me.colPathologyQuantity.Width = 75
        '
        'colPathologyUnitPrice
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.NullValue = Nothing
        Me.colPathologyUnitPrice.DefaultCellStyle = DataGridViewCellStyle26
        Me.colPathologyUnitPrice.HeaderText = "Unit Price"
        Me.colPathologyUnitPrice.Name = "colPathologyUnitPrice"
        Me.colPathologyUnitPrice.ReadOnly = True
        Me.colPathologyUnitPrice.Width = 80
        '
        'colPathologyItemStatus
        '
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        Me.colPathologyItemStatus.DefaultCellStyle = DataGridViewCellStyle27
        Me.colPathologyItemStatus.HeaderText = "Item Status"
        Me.colPathologyItemStatus.Name = "colPathologyItemStatus"
        Me.colPathologyItemStatus.ReadOnly = True
        Me.colPathologyItemStatus.Width = 70
        '
        'colPathologyPayStatus
        '
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.colPathologyPayStatus.DefaultCellStyle = DataGridViewCellStyle28
        Me.colPathologyPayStatus.HeaderText = "Pay Status"
        Me.colPathologyPayStatus.Name = "colPathologyPayStatus"
        Me.colPathologyPayStatus.ReadOnly = True
        Me.colPathologyPayStatus.Width = 70
        '
        'colPathologySaved
        '
        Me.colPathologySaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.NullValue = False
        Me.colPathologySaved.DefaultCellStyle = DataGridViewCellStyle29
        Me.colPathologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPathologySaved.HeaderText = "Saved"
        Me.colPathologySaved.Name = "colPathologySaved"
        Me.colPathologySaved.ReadOnly = True
        Me.colPathologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPathologySaved.Width = 50
        '
        'tpgPrescriptions
        '
        Me.tpgPrescriptions.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescriptions.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescriptions.Name = "tpgPrescriptions"
        Me.tpgPrescriptions.Size = New System.Drawing.Size(884, 201)
        Me.tpgPrescriptions.TabIndex = 2
        Me.tpgPrescriptions.Tag = "DoctorPrescription"
        Me.tpgPrescriptions.Text = "Prescription"
        Me.tpgPrescriptions.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle31
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColDrugselect, Me.ColBarCode, Me.colDrugNo, Me.colDrug, Me.colPrescriptionUnitMeasure, Me.colDosage, Me.colDuration, Me.colDrugQuantity, Me.colDrugFormula, Me.colAlternateName, Me.colAvailableStock, Me.colOrderLevel, Me.colDrugUnitPrice, Me.colAmount, Me.colPrescriptionSaved, Me.colExpiryDate, Me.colUnitsInStock, Me.colPrescriptionGroup, Me.colDrugItemStatus, Me.colDrugPayStatus, Me.colHalted, Me.colHasAlternateDrugs})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvPrescription.Size = New System.Drawing.Size(884, 201)
        Me.dgvPrescription.TabIndex = 1
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'ColDrugselect
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle32.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.ColDrugselect.DefaultCellStyle = DataGridViewCellStyle32
        Me.ColDrugselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColDrugselect.HeaderText = "Select"
        Me.ColDrugselect.Name = "ColDrugselect"
        Me.ColDrugselect.ReadOnly = True
        Me.ColDrugselect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDrugselect.Text = "•••"
        Me.ColDrugselect.Width = 50
        '
        'ColBarCode
        '
        Me.ColBarCode.HeaderText = "Bar Code"
        Me.ColBarCode.Name = "ColBarCode"
        Me.ColBarCode.Width = 120
        '
        'colDrugNo
        '
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Width = 90
        '
        'colDrug
        '
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        Me.colDrug.DefaultCellStyle = DataGridViewCellStyle33
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.ReadOnly = True
        Me.colDrug.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrug.Width = 220
        '
        'colPrescriptionUnitMeasure
        '
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionUnitMeasure.DefaultCellStyle = DataGridViewCellStyle34
        Me.colPrescriptionUnitMeasure.HeaderText = "Unit Measure"
        Me.colPrescriptionUnitMeasure.Name = "colPrescriptionUnitMeasure"
        Me.colPrescriptionUnitMeasure.ReadOnly = True
        Me.colPrescriptionUnitMeasure.Width = 80
        '
        'colDosage
        '
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        Me.colDosage.Width = 50
        '
        'colDuration
        '
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 50
        '
        'colDrugQuantity
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle35
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugFormula
        '
        Me.colDrugFormula.HeaderText = "Notes"
        Me.colDrugFormula.MaxInputLength = 100
        Me.colDrugFormula.Name = "colDrugFormula"
        Me.colDrugFormula.Width = 70
        '
        'colAlternateName
        '
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Info
        Me.colAlternateName.DefaultCellStyle = DataGridViewCellStyle36
        Me.colAlternateName.HeaderText = "Alternate Name"
        Me.colAlternateName.Name = "colAlternateName"
        Me.colAlternateName.ReadOnly = True
        Me.colAlternateName.Width = 90
        '
        'colAvailableStock
        '
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Info
        Me.colAvailableStock.DefaultCellStyle = DataGridViewCellStyle37
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 90
        '
        'colOrderLevel
        '
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle38
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Visible = False
        Me.colOrderLevel.Width = 70
        '
        'colDrugUnitPrice
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle39.Format = "N2"
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle39.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle39
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 65
        '
        'colAmount
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle40.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle40
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle41.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle41.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle41
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'colExpiryDate
        '
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle42
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 80
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle43
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colPrescriptionGroup
        '
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionGroup.DefaultCellStyle = DataGridViewCellStyle44
        Me.colPrescriptionGroup.HeaderText = "Group"
        Me.colPrescriptionGroup.Name = "colPrescriptionGroup"
        Me.colPrescriptionGroup.ReadOnly = True
        Me.colPrescriptionGroup.Width = 80
        '
        'colDrugItemStatus
        '
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugItemStatus.DefaultCellStyle = DataGridViewCellStyle45
        Me.colDrugItemStatus.HeaderText = "Item Status"
        Me.colDrugItemStatus.Name = "colDrugItemStatus"
        Me.colDrugItemStatus.ReadOnly = True
        Me.colDrugItemStatus.Width = 70
        '
        'colDrugPayStatus
        '
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle46
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 70
        '
        'colHalted
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle47.NullValue = False
        Me.colHalted.DefaultCellStyle = DataGridViewCellStyle47
        Me.colHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHalted.HeaderText = "Halted"
        Me.colHalted.Name = "colHalted"
        Me.colHalted.ReadOnly = True
        Me.colHalted.Width = 50
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle48.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle48
        Me.colHasAlternateDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHasAlternateDrugs.HeaderText = "Has Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        Me.colHasAlternateDrugs.Width = 110
        '
        'tpgProcedures
        '
        Me.tpgProcedures.Controls.Add(Me.dgvProcedures)
        Me.tpgProcedures.Location = New System.Drawing.Point(4, 22)
        Me.tpgProcedures.Name = "tpgProcedures"
        Me.tpgProcedures.Size = New System.Drawing.Size(884, 201)
        Me.tpgProcedures.TabIndex = 4
        Me.tpgProcedures.Tag = "DoctorProcedures"
        Me.tpgProcedures.Text = "Procedures"
        Me.tpgProcedures.UseVisualStyleBackColor = True
        '
        'dgvProcedures
        '
        Me.dgvProcedures.AllowUserToOrderColumns = True
        Me.dgvProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle50.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle50
        Me.dgvProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProcedureCode, Me.colICDProcedureCode, Me.colQuantity, Me.colUnitPrice, Me.colProcedureNotes, Me.colProcedureItemStatus, Me.colProcedurePayStatus, Me.colProceduresSaved})
        Me.dgvProcedures.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcedures.EnableHeadersVisualStyles = False
        Me.dgvProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvProcedures.Location = New System.Drawing.Point(0, 0)
        Me.dgvProcedures.Name = "dgvProcedures"
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle57.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle57.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle57.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle57.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle57.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle57.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle57
        Me.dgvProcedures.Size = New System.Drawing.Size(884, 201)
        Me.dgvProcedures.TabIndex = 1
        Me.dgvProcedures.Text = "DataGridView1"
        '
        'colProcedureCode
        '
        Me.colProcedureCode.DisplayStyleForCurrentCellOnly = True
        Me.colProcedureCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProcedureCode.HeaderText = "Procedure"
        Me.colProcedureCode.Name = "colProcedureCode"
        Me.colProcedureCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProcedureCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colProcedureCode.Width = 260
        '
        'colICDProcedureCode
        '
        DataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Info
        Me.colICDProcedureCode.DefaultCellStyle = DataGridViewCellStyle51
        Me.colICDProcedureCode.HeaderText = "Code"
        Me.colICDProcedureCode.Name = "colICDProcedureCode"
        Me.colICDProcedureCode.ReadOnly = True
        Me.colICDProcedureCode.Width = 80
        '
        'colQuantity
        '
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle52.Format = "N0"
        DataGridViewCellStyle52.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle52.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle52
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colUnitPrice
        '
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle53.Format = "N2"
        DataGridViewCellStyle53.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle53.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle53
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.Width = 80
        '
        'colProcedureNotes
        '
        Me.colProcedureNotes.HeaderText = "Notes"
        Me.colProcedureNotes.MaxInputLength = 40
        Me.colProcedureNotes.Name = "colProcedureNotes"
        Me.colProcedureNotes.Width = 120
        '
        'colProcedureItemStatus
        '
        DataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedureItemStatus.DefaultCellStyle = DataGridViewCellStyle54
        Me.colProcedureItemStatus.HeaderText = "Item Status"
        Me.colProcedureItemStatus.Name = "colProcedureItemStatus"
        Me.colProcedureItemStatus.ReadOnly = True
        Me.colProcedureItemStatus.Width = 70
        '
        'colProcedurePayStatus
        '
        DataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedurePayStatus.DefaultCellStyle = DataGridViewCellStyle55
        Me.colProcedurePayStatus.HeaderText = "Pay Status"
        Me.colProcedurePayStatus.Name = "colProcedurePayStatus"
        Me.colProcedurePayStatus.ReadOnly = True
        Me.colProcedurePayStatus.Width = 70
        '
        'colProceduresSaved
        '
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle56.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle56.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle56.NullValue = False
        Me.colProceduresSaved.DefaultCellStyle = DataGridViewCellStyle56
        Me.colProceduresSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProceduresSaved.HeaderText = "Saved"
        Me.colProceduresSaved.Name = "colProceduresSaved"
        Me.colProceduresSaved.ReadOnly = True
        Me.colProceduresSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colProceduresSaved.Width = 50
        '
        'tpgcardiology
        '
        Me.tpgcardiology.Controls.Add(Me.dgvCardiology)
        Me.tpgcardiology.Location = New System.Drawing.Point(4, 22)
        Me.tpgcardiology.Name = "tpgcardiology"
        Me.tpgcardiology.Size = New System.Drawing.Size(884, 201)
        Me.tpgcardiology.TabIndex = 11
        Me.tpgcardiology.Tag = "DoctorCardiology"
        Me.tpgcardiology.Text = "Cardiology"
        Me.tpgcardiology.UseVisualStyleBackColor = True
        '
        'dgvCardiology
        '
        Me.dgvCardiology.AllowUserToOrderColumns = True
        Me.dgvCardiology.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle58.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle58.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCardiology.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle58
        Me.dgvCardiology.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCardiologyExamFullName, Me.colCardiologyIndication, Me.colCardiologyCategory, Me.colCardiologySite, Me.colCardiologyQuantity, Me.colCardiologyUnitPrice, Me.colCardiologyRequest, Me.colCardiologyItemStatus, Me.colCardiologyPayStatus, Me.colCardiologySaved})
        Me.dgvCardiology.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCardiology.EnableHeadersVisualStyles = False
        Me.dgvCardiology.GridColor = System.Drawing.Color.Khaki
        Me.dgvCardiology.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvCardiology.Location = New System.Drawing.Point(0, 0)
        Me.dgvCardiology.Name = "dgvCardiology"
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle67.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle67.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle67.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle67.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle67.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCardiology.RowHeadersDefaultCellStyle = DataGridViewCellStyle67
        Me.dgvCardiology.Size = New System.Drawing.Size(884, 201)
        Me.dgvCardiology.TabIndex = 23
        Me.dgvCardiology.Text = "DataGridView1"
        '
        'colCardiologyExamFullName
        '
        Me.colCardiologyExamFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colCardiologyExamFullName.DisplayStyleForCurrentCellOnly = True
        Me.colCardiologyExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCardiologyExamFullName.HeaderText = "Cardiology Examination"
        Me.colCardiologyExamFullName.Name = "colCardiologyExamFullName"
        Me.colCardiologyExamFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCardiologyExamFullName.Width = 250
        '
        'colCardiologyIndication
        '
        Me.colCardiologyIndication.HeaderText = "Indication"
        Me.colCardiologyIndication.MaxInputLength = 800
        Me.colCardiologyIndication.Name = "colCardiologyIndication"
        Me.colCardiologyIndication.Width = 120
        '
        'colCardiologyCategory
        '
        DataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Info
        Me.colCardiologyCategory.DefaultCellStyle = DataGridViewCellStyle59
        Me.colCardiologyCategory.HeaderText = "Category"
        Me.colCardiologyCategory.Name = "colCardiologyCategory"
        Me.colCardiologyCategory.ReadOnly = True
        Me.colCardiologyCategory.Width = 80
        '
        'colCardiologySite
        '
        DataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Info
        Me.colCardiologySite.DefaultCellStyle = DataGridViewCellStyle60
        Me.colCardiologySite.HeaderText = "Site"
        Me.colCardiologySite.Name = "colCardiologySite"
        Me.colCardiologySite.ReadOnly = True
        Me.colCardiologySite.Width = 80
        '
        'colCardiologyQuantity
        '
        DataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle61.Format = "N0"
        DataGridViewCellStyle61.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle61.NullValue = Nothing
        Me.colCardiologyQuantity.DefaultCellStyle = DataGridViewCellStyle61
        Me.colCardiologyQuantity.HeaderText = "Quantity"
        Me.colCardiologyQuantity.Name = "colCardiologyQuantity"
        Me.colCardiologyQuantity.ReadOnly = True
        Me.colCardiologyQuantity.Width = 75
        '
        'colCardiologyUnitPrice
        '
        DataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle62.Format = "N2"
        DataGridViewCellStyle62.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle62.NullValue = Nothing
        Me.colCardiologyUnitPrice.DefaultCellStyle = DataGridViewCellStyle62
        Me.colCardiologyUnitPrice.HeaderText = "Unit Price"
        Me.colCardiologyUnitPrice.Name = "colCardiologyUnitPrice"
        Me.colCardiologyUnitPrice.ReadOnly = True
        Me.colCardiologyUnitPrice.Width = 80
        '
        'colCardiologyRequest
        '
        DataGridViewCellStyle63.BackColor = System.Drawing.SystemColors.Info
        Me.colCardiologyRequest.DefaultCellStyle = DataGridViewCellStyle63
        Me.colCardiologyRequest.HeaderText = "Requested By"
        Me.colCardiologyRequest.Name = "colCardiologyRequest"
        Me.colCardiologyRequest.ReadOnly = True
        '
        'colCardiologyItemStatus
        '
        DataGridViewCellStyle64.BackColor = System.Drawing.SystemColors.Info
        Me.colCardiologyItemStatus.DefaultCellStyle = DataGridViewCellStyle64
        Me.colCardiologyItemStatus.HeaderText = "Item Status"
        Me.colCardiologyItemStatus.Name = "colCardiologyItemStatus"
        Me.colCardiologyItemStatus.ReadOnly = True
        Me.colCardiologyItemStatus.Width = 70
        '
        'colCardiologyPayStatus
        '
        DataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Info
        Me.colCardiologyPayStatus.DefaultCellStyle = DataGridViewCellStyle65
        Me.colCardiologyPayStatus.HeaderText = "Pay Status"
        Me.colCardiologyPayStatus.Name = "colCardiologyPayStatus"
        Me.colCardiologyPayStatus.ReadOnly = True
        Me.colCardiologyPayStatus.Width = 70
        '
        'colCardiologySaved
        '
        Me.colCardiologySaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle66.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle66.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle66.NullValue = False
        Me.colCardiologySaved.DefaultCellStyle = DataGridViewCellStyle66
        Me.colCardiologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCardiologySaved.HeaderText = "Saved"
        Me.colCardiologySaved.Name = "colCardiologySaved"
        Me.colCardiologySaved.ReadOnly = True
        Me.colCardiologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colCardiologySaved.Width = 50
        '
        'tpgTheatre
        '
        Me.tpgTheatre.Controls.Add(Me.dgvTheatre)
        Me.tpgTheatre.Location = New System.Drawing.Point(4, 22)
        Me.tpgTheatre.Name = "tpgTheatre"
        Me.tpgTheatre.Size = New System.Drawing.Size(884, 201)
        Me.tpgTheatre.TabIndex = 7
        Me.tpgTheatre.Tag = "DoctorTheatre"
        Me.tpgTheatre.Text = "Theatre"
        Me.tpgTheatre.UseVisualStyleBackColor = True
        '
        'dgvTheatre
        '
        Me.dgvTheatre.AllowUserToOrderColumns = True
        Me.dgvTheatre.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle68.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle68.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle68.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle68.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle68.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle68
        Me.dgvTheatre.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTheatreCode, Me.colICDTheatreCode, Me.colTheatreQuantity, Me.colTheatreUnitPrice, Me.colTheatreAmount, Me.colTheatreNotes, Me.colTheatreItemStatus, Me.colTheatrePayStatus, Me.colTheatreSaved})
        Me.dgvTheatre.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvTheatre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTheatre.EnableHeadersVisualStyles = False
        Me.dgvTheatre.GridColor = System.Drawing.Color.Khaki
        Me.dgvTheatre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvTheatre.Location = New System.Drawing.Point(0, 0)
        Me.dgvTheatre.Name = "dgvTheatre"
        DataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle76.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle76.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle76.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle76.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle76.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.RowHeadersDefaultCellStyle = DataGridViewCellStyle76
        Me.dgvTheatre.Size = New System.Drawing.Size(884, 201)
        Me.dgvTheatre.TabIndex = 25
        Me.dgvTheatre.Text = "DataGridView1"
        '
        'colTheatreCode
        '
        Me.colTheatreCode.DataPropertyName = "ItemCode"
        Me.colTheatreCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colTheatreCode.DisplayStyleForCurrentCellOnly = True
        Me.colTheatreCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreCode.HeaderText = "Theatre Service"
        Me.colTheatreCode.Name = "colTheatreCode"
        Me.colTheatreCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTheatreCode.Width = 220
        '
        'colICDTheatreCode
        '
        Me.colICDTheatreCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle69.BackColor = System.Drawing.SystemColors.Info
        Me.colICDTheatreCode.DefaultCellStyle = DataGridViewCellStyle69
        Me.colICDTheatreCode.HeaderText = "Code"
        Me.colICDTheatreCode.Name = "colICDTheatreCode"
        Me.colICDTheatreCode.ReadOnly = True
        Me.colICDTheatreCode.Width = 80
        '
        'colTheatreQuantity
        '
        Me.colTheatreQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle70.Format = "N0"
        DataGridViewCellStyle70.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle70.NullValue = Nothing
        Me.colTheatreQuantity.DefaultCellStyle = DataGridViewCellStyle70
        Me.colTheatreQuantity.HeaderText = "Quantity"
        Me.colTheatreQuantity.MaxInputLength = 12
        Me.colTheatreQuantity.Name = "colTheatreQuantity"
        Me.colTheatreQuantity.Width = 60
        '
        'colTheatreUnitPrice
        '
        Me.colTheatreUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle71.Format = "N2"
        DataGridViewCellStyle71.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle71.NullValue = Nothing
        Me.colTheatreUnitPrice.DefaultCellStyle = DataGridViewCellStyle71
        Me.colTheatreUnitPrice.HeaderText = "Unit Price"
        Me.colTheatreUnitPrice.Name = "colTheatreUnitPrice"
        Me.colTheatreUnitPrice.Width = 80
        '
        'colTheatreAmount
        '
        Me.colTheatreAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle72.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle72.Format = "N2"
        Me.colTheatreAmount.DefaultCellStyle = DataGridViewCellStyle72
        Me.colTheatreAmount.HeaderText = "Amount"
        Me.colTheatreAmount.Name = "colTheatreAmount"
        Me.colTheatreAmount.ReadOnly = True
        Me.colTheatreAmount.Width = 90
        '
        'colTheatreNotes
        '
        Me.colTheatreNotes.DataPropertyName = "ItemDetails"
        Me.colTheatreNotes.HeaderText = "Notes"
        Me.colTheatreNotes.MaxInputLength = 200
        Me.colTheatreNotes.Name = "colTheatreNotes"
        Me.colTheatreNotes.Width = 90
        '
        'colTheatreItemStatus
        '
        Me.colTheatreItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle73.BackColor = System.Drawing.SystemColors.Info
        Me.colTheatreItemStatus.DefaultCellStyle = DataGridViewCellStyle73
        Me.colTheatreItemStatus.HeaderText = "Item Status"
        Me.colTheatreItemStatus.Name = "colTheatreItemStatus"
        Me.colTheatreItemStatus.ReadOnly = True
        Me.colTheatreItemStatus.Width = 70
        '
        'colTheatrePayStatus
        '
        Me.colTheatrePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle74.BackColor = System.Drawing.SystemColors.Info
        Me.colTheatrePayStatus.DefaultCellStyle = DataGridViewCellStyle74
        Me.colTheatrePayStatus.HeaderText = "Pay Status"
        Me.colTheatrePayStatus.Name = "colTheatrePayStatus"
        Me.colTheatrePayStatus.ReadOnly = True
        Me.colTheatrePayStatus.Width = 70
        '
        'colTheatreSaved
        '
        Me.colTheatreSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle75.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle75.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle75.NullValue = False
        Me.colTheatreSaved.DefaultCellStyle = DataGridViewCellStyle75
        Me.colTheatreSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreSaved.HeaderText = "Saved"
        Me.colTheatreSaved.Name = "colTheatreSaved"
        Me.colTheatreSaved.ReadOnly = True
        Me.colTheatreSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTheatreSaved.Width = 50
        '
        'tpgDental
        '
        Me.tpgDental.Controls.Add(Me.dgvDental)
        Me.tpgDental.Location = New System.Drawing.Point(4, 22)
        Me.tpgDental.Name = "tpgDental"
        Me.tpgDental.Size = New System.Drawing.Size(884, 201)
        Me.tpgDental.TabIndex = 5
        Me.tpgDental.Tag = "DoctorDental"
        Me.tpgDental.Text = "Dental"
        Me.tpgDental.UseVisualStyleBackColor = True
        '
        'dgvDental
        '
        Me.dgvDental.AllowUserToOrderColumns = True
        Me.dgvDental.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle77.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle77.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle77.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle77.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle77.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDental.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle77
        Me.dgvDental.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDentalCode, Me.colDentalNotes, Me.colDentalQuantity, Me.colDentalUnitPrice, Me.colDentalAmount, Me.colDentalItemStatus, Me.colDentalPayStatus, Me.colDentalSaved})
        Me.dgvDental.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvDental.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDental.EnableHeadersVisualStyles = False
        Me.dgvDental.GridColor = System.Drawing.Color.Khaki
        Me.dgvDental.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDental.Location = New System.Drawing.Point(0, 0)
        Me.dgvDental.Name = "dgvDental"
        DataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle84.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle84.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle84.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle84.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle84.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDental.RowHeadersDefaultCellStyle = DataGridViewCellStyle84
        Me.dgvDental.Size = New System.Drawing.Size(884, 201)
        Me.dgvDental.TabIndex = 24
        Me.dgvDental.Text = "DataGridView1"
        '
        'colDentalCode
        '
        Me.colDentalCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDentalCode.DisplayStyleForCurrentCellOnly = True
        Me.colDentalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDentalCode.HeaderText = "Dental"
        Me.colDentalCode.Name = "colDentalCode"
        Me.colDentalCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDentalCode.Width = 250
        '
        'colDentalNotes
        '
        Me.colDentalNotes.HeaderText = "Notes"
        Me.colDentalNotes.MaxInputLength = 200
        Me.colDentalNotes.Name = "colDentalNotes"
        '
        'colDentalQuantity
        '
        DataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle78.Format = "N0"
        DataGridViewCellStyle78.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle78.NullValue = Nothing
        Me.colDentalQuantity.DefaultCellStyle = DataGridViewCellStyle78
        Me.colDentalQuantity.HeaderText = "Quantity"
        Me.colDentalQuantity.MaxInputLength = 12
        Me.colDentalQuantity.Name = "colDentalQuantity"
        Me.colDentalQuantity.Width = 75
        '
        'colDentalUnitPrice
        '
        DataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle79.Format = "N2"
        DataGridViewCellStyle79.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle79.NullValue = Nothing
        Me.colDentalUnitPrice.DefaultCellStyle = DataGridViewCellStyle79
        Me.colDentalUnitPrice.HeaderText = "Unit Price"
        Me.colDentalUnitPrice.Name = "colDentalUnitPrice"
        Me.colDentalUnitPrice.Width = 80
        '
        'colDentalAmount
        '
        DataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle80.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle80.Format = "N2"
        Me.colDentalAmount.DefaultCellStyle = DataGridViewCellStyle80
        Me.colDentalAmount.HeaderText = "Amount"
        Me.colDentalAmount.Name = "colDentalAmount"
        Me.colDentalAmount.ReadOnly = True
        Me.colDentalAmount.Width = 90
        '
        'colDentalItemStatus
        '
        DataGridViewCellStyle81.BackColor = System.Drawing.SystemColors.Info
        Me.colDentalItemStatus.DefaultCellStyle = DataGridViewCellStyle81
        Me.colDentalItemStatus.HeaderText = "Item Status"
        Me.colDentalItemStatus.Name = "colDentalItemStatus"
        Me.colDentalItemStatus.ReadOnly = True
        Me.colDentalItemStatus.Width = 70
        '
        'colDentalPayStatus
        '
        DataGridViewCellStyle82.BackColor = System.Drawing.SystemColors.Info
        Me.colDentalPayStatus.DefaultCellStyle = DataGridViewCellStyle82
        Me.colDentalPayStatus.HeaderText = "Pay Status"
        Me.colDentalPayStatus.Name = "colDentalPayStatus"
        Me.colDentalPayStatus.ReadOnly = True
        Me.colDentalPayStatus.Width = 70
        '
        'colDentalSaved
        '
        Me.colDentalSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle83.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle83.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle83.NullValue = False
        Me.colDentalSaved.DefaultCellStyle = DataGridViewCellStyle83
        Me.colDentalSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDentalSaved.HeaderText = "Saved"
        Me.colDentalSaved.Name = "colDentalSaved"
        Me.colDentalSaved.ReadOnly = True
        Me.colDentalSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDentalSaved.Width = 50
        '
        'tpgOptical
        '
        Me.tpgOptical.Controls.Add(Me.dgvOptical)
        Me.tpgOptical.Location = New System.Drawing.Point(4, 22)
        Me.tpgOptical.Name = "tpgOptical"
        Me.tpgOptical.Size = New System.Drawing.Size(884, 201)
        Me.tpgOptical.TabIndex = 8
        Me.tpgOptical.Tag = "DoctorOptical"
        Me.tpgOptical.Text = "Optical"
        Me.tpgOptical.UseVisualStyleBackColor = True
        '
        'dgvOptical
        '
        Me.dgvOptical.AllowUserToOrderColumns = True
        Me.dgvOptical.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle85.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle85.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle85.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle85.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle85.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle85.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle85
        Me.dgvOptical.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOpticalCode, Me.colOpticalCategory, Me.colOpticalQuantity, Me.colOpticalUnitPrice, Me.colOpticalAmount, Me.colOpticalNotes, Me.colOpticalItemStatus, Me.colOpticalPayStatus, Me.colOpticalSaved})
        Me.dgvOptical.ContextMenuStrip = Me.cmsSelfRequests
        Me.dgvOptical.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOptical.EnableHeadersVisualStyles = False
        Me.dgvOptical.GridColor = System.Drawing.Color.Khaki
        Me.dgvOptical.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOptical.Location = New System.Drawing.Point(0, 0)
        Me.dgvOptical.Name = "dgvOptical"
        DataGridViewCellStyle93.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle93.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle93.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle93.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle93.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle93.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptical.RowHeadersDefaultCellStyle = DataGridViewCellStyle93
        Me.dgvOptical.Size = New System.Drawing.Size(884, 201)
        Me.dgvOptical.TabIndex = 29
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
        Me.colOpticalCode.Width = 240
        '
        'colOpticalCategory
        '
        Me.colOpticalCategory.DataPropertyName = "OpticalCategory"
        DataGridViewCellStyle86.BackColor = System.Drawing.SystemColors.Info
        Me.colOpticalCategory.DefaultCellStyle = DataGridViewCellStyle86
        Me.colOpticalCategory.HeaderText = "Category"
        Me.colOpticalCategory.Name = "colOpticalCategory"
        Me.colOpticalCategory.ReadOnly = True
        Me.colOpticalCategory.Width = 80
        '
        'colOpticalQuantity
        '
        Me.colOpticalQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle87.Format = "N0"
        DataGridViewCellStyle87.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle87.NullValue = Nothing
        Me.colOpticalQuantity.DefaultCellStyle = DataGridViewCellStyle87
        Me.colOpticalQuantity.HeaderText = "Quantity"
        Me.colOpticalQuantity.MaxInputLength = 12
        Me.colOpticalQuantity.Name = "colOpticalQuantity"
        Me.colOpticalQuantity.Width = 50
        '
        'colOpticalUnitPrice
        '
        Me.colOpticalUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle88.Format = "N2"
        DataGridViewCellStyle88.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle88.NullValue = Nothing
        Me.colOpticalUnitPrice.DefaultCellStyle = DataGridViewCellStyle88
        Me.colOpticalUnitPrice.HeaderText = "Unit Price"
        Me.colOpticalUnitPrice.Name = "colOpticalUnitPrice"
        Me.colOpticalUnitPrice.Width = 65
        '
        'colOpticalAmount
        '
        Me.colOpticalAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle89.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle89.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle89.Format = "N2"
        Me.colOpticalAmount.DefaultCellStyle = DataGridViewCellStyle89
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
        'colOpticalItemStatus
        '
        Me.colOpticalItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle90.BackColor = System.Drawing.SystemColors.Info
        Me.colOpticalItemStatus.DefaultCellStyle = DataGridViewCellStyle90
        Me.colOpticalItemStatus.HeaderText = "Item Status"
        Me.colOpticalItemStatus.Name = "colOpticalItemStatus"
        Me.colOpticalItemStatus.ReadOnly = True
        Me.colOpticalItemStatus.Width = 70
        '
        'colOpticalPayStatus
        '
        Me.colOpticalPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle91.BackColor = System.Drawing.SystemColors.Info
        Me.colOpticalPayStatus.DefaultCellStyle = DataGridViewCellStyle91
        Me.colOpticalPayStatus.HeaderText = "Pay Status"
        Me.colOpticalPayStatus.Name = "colOpticalPayStatus"
        Me.colOpticalPayStatus.ReadOnly = True
        Me.colOpticalPayStatus.Width = 80
        '
        'colOpticalSaved
        '
        Me.colOpticalSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle92.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle92.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle92.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle92.NullValue = False
        Me.colOpticalSaved.DefaultCellStyle = DataGridViewCellStyle92
        Me.colOpticalSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOpticalSaved.HeaderText = "Saved"
        Me.colOpticalSaved.Name = "colOpticalSaved"
        Me.colOpticalSaved.ReadOnly = True
        Me.colOpticalSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOpticalSaved.Width = 50
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(884, 201)
        Me.tpgConsumables.TabIndex = 9
        Me.tpgConsumables.Tag = "Consumables"
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle94.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle94.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle94.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle94.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle94.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle94.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle94.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle94
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColConsSelect, Me.ColConsumableBarCode, Me.ColConsumableNo, Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitsInStock, Me.colConsumableUnitMeasure, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumableExpiryDate, Me.colConsumablesSaved, Me.colConsumableOrderLevel, Me.colConsumableAlternateName, Me.colConsumableItemStatus, Me.colConsumablePayStatus, Me.colConsumableHalted})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsSelfRequests
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
        Me.dgvConsumables.Size = New System.Drawing.Size(884, 201)
        Me.dgvConsumables.TabIndex = 43
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'ColConsSelect
        '
        DataGridViewCellStyle95.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle95.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle95.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle95.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle95.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.ColConsSelect.DefaultCellStyle = DataGridViewCellStyle95
        Me.ColConsSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColConsSelect.HeaderText = "Select"
        Me.ColConsSelect.Name = "ColConsSelect"
        Me.ColConsSelect.ReadOnly = True
        Me.ColConsSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColConsSelect.Text = "•••"
        Me.ColConsSelect.Width = 50
        '
        'ColConsumableBarCode
        '
        Me.ColConsumableBarCode.HeaderText = "Bar Code"
        Me.ColConsumableBarCode.Name = "ColConsumableBarCode"
        Me.ColConsumableBarCode.Width = 120
        '
        'ColConsumableNo
        '
        Me.ColConsumableNo.HeaderText = "Consumable No"
        Me.ColConsumableNo.Name = "ColConsumableNo"
        '
        'colConsumableName
        '
        DataGridViewCellStyle96.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle96
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumableName.Width = 200
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        '
        'colConsumableQuantity
        '
        DataGridViewCellStyle97.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle97.Format = "N0"
        DataGridViewCellStyle97.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle97.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle97
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitsInStock
        '
        DataGridViewCellStyle98.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitsInStock.DefaultCellStyle = DataGridViewCellStyle98
        Me.colConsumableUnitsInStock.HeaderText = "Units In Stock"
        Me.colConsumableUnitsInStock.Name = "colConsumableUnitsInStock"
        Me.colConsumableUnitsInStock.ReadOnly = True
        Me.colConsumableUnitsInStock.Width = 80
        '
        'colConsumableUnitMeasure
        '
        DataGridViewCellStyle99.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitMeasure.DefaultCellStyle = DataGridViewCellStyle99
        Me.colConsumableUnitMeasure.HeaderText = "Unit Measure"
        Me.colConsumableUnitMeasure.Name = "colConsumableUnitMeasure"
        Me.colConsumableUnitMeasure.ReadOnly = True
        Me.colConsumableUnitMeasure.Width = 80
        '
        'colConsumableUnitPrice
        '
        DataGridViewCellStyle100.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle100.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle100.Format = "N2"
        DataGridViewCellStyle100.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle100.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle100
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        DataGridViewCellStyle101.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle101.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle101.Format = "N2"
        DataGridViewCellStyle101.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle101
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle102.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle102
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        Me.colConsumableExpiryDate.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle103.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle103.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle103.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle103.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle103
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle104.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle104
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        Me.colConsumableOrderLevel.Width = 70
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle105.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle105
        Me.colConsumableAlternateName.HeaderText = "Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 90
        '
        'colConsumableItemStatus
        '
        DataGridViewCellStyle106.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableItemStatus.DefaultCellStyle = DataGridViewCellStyle106
        Me.colConsumableItemStatus.HeaderText = "Item Status"
        Me.colConsumableItemStatus.Name = "colConsumableItemStatus"
        Me.colConsumableItemStatus.ReadOnly = True
        Me.colConsumableItemStatus.Width = 80
        '
        'colConsumablePayStatus
        '
        DataGridViewCellStyle107.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablePayStatus.DefaultCellStyle = DataGridViewCellStyle107
        Me.colConsumablePayStatus.HeaderText = "Pay Status"
        Me.colConsumablePayStatus.Name = "colConsumablePayStatus"
        Me.colConsumablePayStatus.ReadOnly = True
        Me.colConsumablePayStatus.Width = 70
        '
        'colConsumableHalted
        '
        DataGridViewCellStyle108.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle108.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle108.NullValue = False
        Me.colConsumableHalted.DefaultCellStyle = DataGridViewCellStyle108
        Me.colConsumableHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableHalted.HeaderText = "Halted"
        Me.colConsumableHalted.Name = "colConsumableHalted"
        Me.colConsumableHalted.ReadOnly = True
        Me.colConsumableHalted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableHalted.Width = 50
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(4, 176)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(892, 40)
        Me.pnlBill.TabIndex = 31
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(306, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(106, 18)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(148, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(145, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(421, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(467, 34)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(4, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(138, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(6, 91)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(140, 20)
        Me.lblBillMode.TabIndex = 9
        Me.lblBillMode.Text = "To-Bill Mode"
        '
        'pnlPatients
        '
        Me.pnlPatients.Controls.Add(Me.stbPhone)
        Me.pnlPatients.Controls.Add(Me.lblPhoneNo)
        Me.pnlPatients.Controls.Add(Me.stbMiddleName)
        Me.pnlPatients.Controls.Add(Me.lblMiddleName)
        Me.pnlPatients.Controls.Add(Me.fcbGenderID)
        Me.pnlPatients.Controls.Add(Me.nbxAge)
        Me.pnlPatients.Controls.Add(Me.dtpBirthDate)
        Me.pnlPatients.Controls.Add(Me.stbLastName)
        Me.pnlPatients.Controls.Add(Me.stbFirstName)
        Me.pnlPatients.Controls.Add(Me.lblAge)
        Me.pnlPatients.Controls.Add(Me.lblSurname)
        Me.pnlPatients.Controls.Add(Me.lblGenderID)
        Me.pnlPatients.Controls.Add(Me.lblFirstName)
        Me.pnlPatients.Controls.Add(Me.lblDoB)
        Me.pnlPatients.Location = New System.Drawing.Point(303, 3)
        Me.pnlPatients.Name = "pnlPatients"
        Me.pnlPatients.Size = New System.Drawing.Size(279, 170)
        Me.pnlPatients.TabIndex = 17
        '
        'lblPhoneNo
        '
        Me.lblPhoneNo.Location = New System.Drawing.Point(7, 132)
        Me.lblPhoneNo.Name = "lblPhoneNo"
        Me.lblPhoneNo.Size = New System.Drawing.Size(109, 20)
        Me.lblPhoneNo.TabIndex = 12
        Me.lblPhoneNo.Text = "Phone Number"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.Location = New System.Drawing.Point(7, 45)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(109, 20)
        Me.lblMiddleName.TabIndex = 4
        Me.lblMiddleName.Text = "Other Name"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(7, 86)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(109, 20)
        Me.lblAge.TabIndex = 8
        Me.lblAge.Text = "Age"
        '
        'lblSurname
        '
        Me.lblSurname.Location = New System.Drawing.Point(7, 4)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(109, 20)
        Me.lblSurname.TabIndex = 0
        Me.lblSurname.Text = "Surname"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(7, 108)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(109, 20)
        Me.lblGenderID.TabIndex = 10
        Me.lblGenderID.Text = "Gender"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(7, 25)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(109, 20)
        Me.lblFirstName.TabIndex = 2
        Me.lblFirstName.Text = "First Name"
        '
        'lblDoB
        '
        Me.lblDoB.Location = New System.Drawing.Point(7, 66)
        Me.lblDoB.Name = "lblDoB"
        Me.lblDoB.Size = New System.Drawing.Size(109, 20)
        Me.lblDoB.TabIndex = 6
        Me.lblDoB.Text = "Date of Birth"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(588, 31)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(139, 20)
        Me.lblBillInsuranceName.TabIndex = 21
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(588, 9)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(139, 20)
        Me.lblBillCustomerName.TabIndex = 19
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'chkUseExistingPatient
        '
        Me.chkUseExistingPatient.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUseExistingPatient.Enabled = False
        Me.chkUseExistingPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseExistingPatient.Location = New System.Drawing.Point(4, 3)
        Me.chkUseExistingPatient.Name = "chkUseExistingPatient"
        Me.chkUseExistingPatient.Size = New System.Drawing.Size(159, 20)
        Me.chkUseExistingPatient.TabIndex = 0
        Me.chkUseExistingPatient.Text = "Use Existing Patient"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(759, 483)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 37
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintVisitOnSaving
        '
        Me.chkPrintVisitOnSaving.AccessibleDescription = ""
        Me.chkPrintVisitOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintVisitOnSaving.AutoSize = True
        Me.chkPrintVisitOnSaving.Location = New System.Drawing.Point(5, 8)
        Me.chkPrintVisitOnSaving.Name = "chkPrintVisitOnSaving"
        Me.chkPrintVisitOnSaving.Size = New System.Drawing.Size(125, 17)
        Me.chkPrintVisitOnSaving.TabIndex = 0
        Me.chkPrintVisitOnSaving.Text = " Print Visit On Saving"
        '
        'pnlPrintVisitOnSaving
        '
        Me.pnlPrintVisitOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintVisitOnSaving.Controls.Add(Me.chkPrintVisitOnSaving)
        Me.pnlPrintVisitOnSaving.Location = New System.Drawing.Point(87, 483)
        Me.pnlPrintVisitOnSaving.Name = "pnlPrintVisitOnSaving"
        Me.pnlPrintVisitOnSaving.Size = New System.Drawing.Size(169, 30)
        Me.pnlPrintVisitOnSaving.TabIndex = 36
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(6, 133)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(140, 20)
        Me.lblMemberCardNo.TabIndex = 13
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(6, 113)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(140, 20)
        Me.lblBillNo.TabIndex = 11
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(6, 154)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(140, 20)
        Me.lblMainMemberName.TabIndex = 15
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.Location = New System.Drawing.Point(588, 98)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(139, 20)
        Me.lblCoPayPercent.TabIndex = 27
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.Location = New System.Drawing.Point(588, 119)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(139, 20)
        Me.lblCoPayValue.TabIndex = 29
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.Location = New System.Drawing.Point(588, 78)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(139, 20)
        Me.lblCoPayType.TabIndex = 25
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblAssociatedBillNo
        '
        Me.lblAssociatedBillNo.Enabled = False
        Me.lblAssociatedBillNo.Location = New System.Drawing.Point(588, 55)
        Me.lblAssociatedBillNo.Name = "lblAssociatedBillNo"
        Me.lblAssociatedBillNo.Size = New System.Drawing.Size(139, 20)
        Me.lblAssociatedBillNo.TabIndex = 23
        Me.lblAssociatedBillNo.Text = "Associated Bill Customer"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(251, 1)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(771, 141)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 39
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(752, 144)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(13, 21)
        Me.chkFingerprintCaptured.TabIndex = 41
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(591, 141)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(155, 24)
        Me.btnEnrollFingerprint.TabIndex = 42
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
        '
        'cmsFrequentlyRequestedTests
        '
        Me.cmsFrequentlyRequestedTests.Image = CType(resources.GetObject("cmsFrequentlyRequestedTests.Image"), System.Drawing.Image)
        Me.cmsFrequentlyRequestedTests.Name = "cmsFrequentlyRequestedTests"
        Me.cmsFrequentlyRequestedTests.Size = New System.Drawing.Size(217, 22)
        Me.cmsFrequentlyRequestedTests.Text = "Frequently Requested Tests"
        '
        'frmSelfRequests
        '
        Me.AcceptButton = Me.ebnSaveUpdate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(925, 521)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.btnEnrollFingerprint)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboAssociatedBillNo)
        Me.Controls.Add(Me.lblAssociatedBillNo)
        Me.Controls.Add(Me.cboCoPayTypeID)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.cboBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.pnlPrintVisitOnSaving)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.chkUseExistingPatient)
        Me.Controls.Add(Me.pnlPatients)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.tbcDrRoles)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.dtpVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmSelfRequests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Self Requests"
        Me.tbcDrRoles.ResumeLayout(False)
        Me.tpgExtraCharge.ResumeLayout(False)
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsSelfRequests.ResumeLayout(False)
        Me.tpgLaboratory.ResumeLayout(False)
        CType(Me.dgvLabTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgRadiology.ResumeLayout(False)
        CType(Me.dgvRadiology, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPathology.ResumeLayout(False)
        CType(Me.dgvHistopathologyRequisition, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPrescriptions.ResumeLayout(False)
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgProcedures.ResumeLayout(False)
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgcardiology.ResumeLayout(False)
        CType(Me.dgvCardiology, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgTheatre.ResumeLayout(False)
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgDental.ResumeLayout(False)
        CType(Me.dgvDental, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOptical.ResumeLayout(False)
        CType(Me.dgvOptical, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlPatients.ResumeLayout(False)
        Me.pnlPatients.PerformLayout()
        Me.pnlPrintVisitOnSaving.ResumeLayout(False)
        Me.pnlPrintVisitOnSaving.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dtpVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents tbcDrRoles As System.Windows.Forms.TabControl
    Friend WithEvents tpgLaboratory As System.Windows.Forms.TabPage
    Friend WithEvents dgvLabTests As System.Windows.Forms.DataGridView
    Friend WithEvents tpgPrescriptions As System.Windows.Forms.TabPage
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents pnlPatients As System.Windows.Forms.Panel
    Friend WithEvents chkUseExistingPatient As System.Windows.Forms.CheckBox
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents fcbGenderID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents nbxAge As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblDoB As System.Windows.Forms.Label
    Friend WithEvents tpgRadiology As System.Windows.Forms.TabPage
    Friend WithEvents dgvRadiology As System.Windows.Forms.DataGridView
    Friend WithEvents colExamFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colRadiologyIndication As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologyPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRadiologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgProcedures As System.Windows.Forms.TabPage
    Friend WithEvents tpgDental As System.Windows.Forms.TabPage
    Friend WithEvents tpgExtraCharge As System.Windows.Forms.TabPage
    Friend WithEvents dgvProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colICDProcedureCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedurePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProceduresSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvDental As System.Windows.Forms.DataGridView
    Friend WithEvents colDentalCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDentalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDentalSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvExtraCharge As System.Windows.Forms.DataGridView
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintVisitOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents pnlPrintVisitOnSaving As System.Windows.Forms.Panel
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
    Friend WithEvents tpgTheatre As System.Windows.Forms.TabPage
    Friend WithEvents tpgOptical As System.Windows.Forms.TabPage
    Friend WithEvents dgvTheatre As System.Windows.Forms.DataGridView
    Friend WithEvents colTheatreCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colICDTheatreCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatrePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvOptical As System.Windows.Forms.DataGridView
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents cboBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents cboCoPayTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents colOpticalCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colOpticalCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOpticalSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboAssociatedBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssociatedBillNo As System.Windows.Forms.Label
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents cmsSelfRequests As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsSelfRequestsQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents tpgPathology As System.Windows.Forms.TabPage
    Friend WithEvents dgvHistopathologyRequisition As System.Windows.Forms.DataGridView
    Friend WithEvents colPathologyExamFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPathologyIndication As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologyPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPathologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents ColDrugselect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvailableStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHalted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colHasAlternateDrugs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColConsSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ColConsumableBarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableHalted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents colTest As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColLabNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLaboratoryUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLTPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLabTestsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgcardiology As System.Windows.Forms.TabPage
    Friend WithEvents dgvCardiology As System.Windows.Forms.DataGridView
    Friend WithEvents colCardiologyExamFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCardiologyIndication As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologySite As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyRequest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologyPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCardiologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmsFrequentlyRequestedTests As System.Windows.Forms.ToolStripMenuItem
End Class