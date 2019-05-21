
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports GenCode128



Public Class frmPharmacy

#Region " Fields "

    Private defaultVisitNo As String = String.Empty

    Private pharmacyPrinterPaperSize As String = String.Empty

    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty
    Private hasServiceFee As Boolean = False
    Private Const EditText As String = "&Edit"
    Private Const UpdateText As String = "&Update"

    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private billModesID As String = String.Empty
    Private accessCashServices As Boolean = False
    Private provisionalDiagnosis As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private WithEvents docPrescription As New PrintDocument()
    Private WithEvents docPharmacyThermalPrescription As New PrintDocument()
    Private WithEvents docDrugLabel As New PrintDocument()
    Private WithEvents docBarcodes As New PrintDocument()

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 40
    Private padFullDosage As Integer = 20

    ' The paragraphs.

    Private PharmacyThermalPrescriptionParagraphs As Collection
    Private prescriptionParagraphs As Collection
    Private DrugLabelParagraphs As Collection
    Private DrugLabelBarCode As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private drugLabelBodyBoldFont As New Font(printFontName, 9, FontStyle.Bold)
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private PriorityID As String

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oVariousOptions As New VariousOptions()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private toPrintRow As Integer = -1

#End Region

#Region " Validations "
    Dim smartLocationID As Integer
    Dim genderID As String
    Dim copayTypeID As String

    Private Sub dtpIssueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpIssueDate.Validating

        Dim errorMSG As String = "Issue date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim issueDate As Date = DateMayBeEnteredIn(Me.dtpIssueDate)

            If issueDate = AppData.NullDateValue Then Return

            If issueDate < visitDate Then
                ErrProvider.SetError(Me.dtpIssueDate, errorMSG)
                Me.dtpIssueDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpIssueDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmPharmacy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.dtpIssueDate.MaxDate = Today

            Me.ShowSentAlerts()
            Me.ShowToOrderDrugs()
            Me.ShowToExpireDrugs()
            Me.SetDefaultLocation()
            Me.LoadStaff()
            Me.SetDefaultPrinter()
            Me.ShowConsumableSentAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnEdit, AccessRights.Update)
            Security.Apply(Me.btnGenerateInvoice, AccessRights.Write)
            Me.btnPrint.Enabled = oVariousOptions.AllowPrintingBeforeDispensing

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.ShowDispensingData()
                Me.ProcessTabKey(True)

            Else : Me.stbVisitNo.ReadOnly = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmPharmacy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvPrescription.RowCount = 1 Then
            message = "Current prescription is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current prescriptions are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub frmPharmacy_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowSentAlerts()
        Me.ShowConsumableSentAlerts()
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
            fFindVisitNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadToPharmacyVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToPharmacyVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Drug)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Pharmacist).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboPharmacist, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableSetInventoryLocation()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(location) Then
                Me.cboLocationID.Enabled = False
            Else : Me.cboLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboLocationID.Enabled = True

        End Try

    End Sub

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, False)

            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub GenerateBarcode()
        Try
            Dim imageweight As Integer = 2
            'Barcode using the GenCode128
            If Not String.IsNullOrEmpty(stbVisitNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(stbVisitNo.Text.ToString(), Integer.Parse(imageweight.ToString()), True)
                imgIDAutomation.Image = barcodeImage

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SetDefaultPrinter()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.PharmacyPrinterPaperSize) Then
                Me.pharmacyPrinterPaperSize = GetLookupDataDes(GetLookupDataID(LookupObjects.PrinterPaperSize, InitOptions.PharmacyPrinterPaperSize))
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentAllSaved = Me.RecordSaved(False)
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
                Me.stbVisitNo.Text = currentVisitNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLocationID.SelectedIndexChanged
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboLocationID)
              Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If String.IsNullOrEmpty(LocationID) Then Return
            If (LocationID = "") Then
                Me.CountToOrderInventoryLocation(oItemCategoryID.Drug, LocationID)
                Me.CountToExpireInventoryLocation(oItemCategoryID.Drug, LocationID)

            ElseIf (Not (LocationID = "")) Then

                Me.CountToOrderInventoryLocation(oItemCategoryID.Drug, LocationID)
                Me.CountToExpireInventoryLocation(oItemCategoryID.Drug, LocationID)
                Me.GetAllPendingOrderDetails(LocationID)
            End If
            Select Case Me.tbcPharmacy.SelectedTab.Name
                Case Me.tpgPrescription.Name
                    '    Me.DetailConsumableLocationBalance()
                
                    Me.DetailDrugLocationBalance()
            End Select
                
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbVisitDate.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbPatientNo.Clear()
        Me.stbPhoneNo.Clear()
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        billModesID = String.Empty
        accessCashServices = False
        provisionalDiagnosis = String.Empty
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbVisitCategory.Clear()
        Me.stbRefillDuration.Clear()
        Me.lblRefillDuration.Visible = False
        Me.stbRefillDuration.Visible = False
        Me.nbxWeight.Value = String.Empty
        Me.btnAddConsumables.Enabled = False
        Me.btnAddExtraCharge.Enabled = False
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgPrescription)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgDiagnosis)
        Me.EnableEditColumns(False)
        hasServiceFee = False
    End Sub

    Private Function CountToOrderInventoryLocation(ItemCategoryID As String, LocationID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
       
        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToOrderInventoryLocation(ItemCategoryID, LocationID)
            Me.lblToOrderDrugs.Text = "To Order Drugs: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function GetAllPendingOrderDetails(locationCode As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.GetAllPendingOrderDetails(locationCode)

            Me.lblPendingIventoryAcknowledgements.Text = "Pending Ack: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function CountToExpireInventoryLocation(ItemCategoryID As String, LocationID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()
      
        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToExpireInventoryLocation(ItemCategoryID, LocationID, oVariousOptions.ExpiryWarningDays)
            Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Sub ShowDispensingData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.pnlNavigateVisits)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadDrugsData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateVisits)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugsData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadDrugsToIssue(visitNo)
            Me.LoadDiagnosis(visitNo)
            Me.LoadConsumables(visitNo)
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim opatientallergies As New SyncSoft.SQLDb.PatientAllergies()
        Dim patientAllergyMsg As String = " This Patient has Allergy(s)" + ControlChars.NewLine + "Please take note"

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim allergyList As DataTable = opatientallergies.GetPatientAllergies(patientNo).Tables("PatientAllergies")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbPhoneNo.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            Me.chkSmartCardApplicable.Checked = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            provisionalDiagnosis = StringMayBeEnteredIn(row, "ProvisionalDiagnosis")
            Me.nbxWeight.Value = StringMayBeEnteredIn(row, "Weight")
            Me.PriorityID = GetLookupDataID(LookupObjects.Priority, StringEnteredIn(row, "PriorityID"))
            Me.stbAppointmentDetails.Text = StringMayBeEnteredIn(row, "PatientAppointmentsDetails")
            Me.stbNextAppointmentDate.Text = StringMayBeEnteredIn(row, "PatientAppointmentsDate")
            hasServiceFee = BooleanMayBeEnteredIn(row, "HasServiceFee")
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.copayTypeID = StringEnteredIn(row, "CoPayTypeID")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPharmacist.Text = oStaff.GetCurrentStaffFullName
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnAddConsumables.Enabled = True
            Security.Apply(Me.btnAddConsumables, AccessRights.Write)

            Me.btnAddExtraCharge.Enabled = True
            Security.Apply(Me.btnAddExtraCharge, AccessRights.Write)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.dtpIssueDate.Value = visitDate
            Me.dtpIssueDate.Checked = GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12))


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If allergyList.Rows.Count > 0 Then

                ErrProvider.SetError(Me.tbcPharmacy, patientAllergyMsg)
                ErrProvider.SetIconAlignment(Me.tbcPharmacy, ErrorIconAlignment.TopLeft)
                ErrProvider.SetIconPadding(Me.tbcPharmacy, -8)

            Else
                ErrProvider.SetError(Me.tbcPharmacy, String.Empty)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If GetLookupDataDes(oVisitCategoryID.Refill).Equals(Me.stbVisitCategory.Text.Trim()) Then
                Me.stbRefillDuration.Text = CStr(GetRefillDuration(patientNo))
                Me.lblRefillDuration.Visible = True
                Me.stbRefillDuration.Visible = True
            Else
                Me.lblRefillDuration.Visible = False
                Me.stbRefillDuration.Visible = False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugsToIssue(ByVal visitNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        PharmacyPrescription.Balance.Clear()
        PharmacyPrescription.Quantity.Clear()
        PharmacyPrescription.DrQuantity.Clear()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvPrescription.Rows.Clear()
            If String.IsNullOrEmpty(visitNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drugsToIssue As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug, oItemStatusID.Pending).Tables("Items")
           If drugsToIssue Is Nothing OrElse drugsToIssue.Rows.Count < 1 Then Throw New ArgumentException("This visit has no pending prescription!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To drugsToIssue.Rows.Count - 1

                Dim row As DataRow = drugsToIssue.Rows(pos)

                Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim Doctorquantity As Integer = IntegerMayBeEnteredIn(row, "Doctorquantity")
                Dim Balance As Integer = IntegerMayBeEnteredIn(row, "Balance")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice
                Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row, "CashAmount")

                With Me.dgvPrescription

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colDrugNo.Name, pos).Value = drugNo
                    .Item(Me.colDrugName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colDrQuantity.Name, pos).Value = Doctorquantity
                    .Item(Me.colBalance.Name, pos).Value = Balance
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "PayStatus")
                    Me.ShowDrugDetails(drugNo, pos)
                    .Item(Me.colCashPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "CashPayStatus")
                    .Item(Me.colCashAmount.Name, pos).Value = FormatNumber(cashAmount, AppData.DecimalPlaces)

                End With

            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculatePrescriptionTotalBill()
            Me.DetailDrugLocationBalance()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For count As Integer = 0 To dgvPrescription.Rows.Count - 1
                PharmacyPrescription.Balance.Add(count, Convert.ToInt32(Me.dgvPrescription.Item(Me.colBalance.Name, count).Value))
                PharmacyPrescription.Quantity.Add(count, Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, count).Value))
                PharmacyPrescription.DrQuantity.Add(count, Convert.ToInt32(Me.dgvPrescription.Item(Me.colDrQuantity.Name, count).Value))
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDrugDetails(ByVal drugNo As String, ByVal pos As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugNo Is Nothing Then Return
            Dim row As DataRow = drugs.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colAvailableStock.Name, pos).Value = GetAvailableStock(drugNo)
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colHasAlternateDrugs.Name, pos).Value = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadConsumables(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumables As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable).Tables("Items")
            If consumables Is Nothing OrElse consumables.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, consumables)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesTotalBill()
            Me.CalculateGrandTotalAmount()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadDiagnosis(ByVal visitNo As String)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosis As DataTable = oDiagnosis.GetDiagnosis(visitNo).Tables("Diagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDiagnosis, diagnosis)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAddConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fConsumables As New frmConsumables(visitNo)
            fConsumables.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadConsumables(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.btnEdit.Text = UpdateText Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

                If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must Register At least one entry for prescription!")

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows

                    If row.IsNewRow Then Exit For

                    StringEnteredIn(row.Cells, Me.colDrugNo, "drug!")
                    StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                    IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    IntegerEnteredIn(row.Cells, Me.colBalance, "Balance!")
                    DecimalEnteredIn(row.Cells, Me.colUnitPrice, False, "unit price!")
                    DecimalEnteredIn(row.Cells, Me.colAmount, False, "amount!")
                    StringMayBeEnteredIn(row.Cells, Me.colFormula)
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")
                Next

                Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

                For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                    Dim lItems As New List(Of DBConnect)
                    Dim lItemsBalanceDetails As New List(Of DBConnect)
                    Dim lItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                    Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo)
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)
                    Dim Balance As Integer = IntegerEnteredIn(cells, Me.colBalance)
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                    Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100

                    Try
                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colFormula)
                                .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .ItemCategoryID = oItemCategoryID.Drug
                                .ItemStatusID = oItemStatusID.Pending
                                .PayStatusID = oPayStatusID.NotPaid
                                .LoginID = CurrentUser.LoginID
                            End With
                            lItems.Add(oItems)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        'Using oItemBalanceDetails As New SyncSoft.SQLDb.itemsBalanceDetails()
                        '    With oItemBalanceDetails
                        '        .VisitNo = visitNo
                        '        .ItemCode = itemCode
                        '        .ItemCategoryID = oItemCategoryID.Drug
                        '        .Balance = Balance
                        '        .LoginID = CurrentUser.LoginID
                        '    End With
                        '    lItemsBalanceDetails.Add(oItemBalanceDetails)
                        'End Using

                        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'transactions.Add(New TransactionList(Of DBConnect)(litemsBalanceDetails, Action.Save))

                        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = visitNo
                                    .ItemCode = itemCode
                                    .ItemCategoryID = oItemCategoryID.Drug
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(transactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Catch ex As Exception
                        ErrorMessage(ex)

                    End Try

                Next

                '''''''''''''''''''''''''''''''''''''''''''
                Me.LoadDrugsToIssue(visitNo)
                Me.EnableEditColumns(False)
                '''''''''''''''''''''''''''''''''''''''''''

            Else : Me.EnableEditColumns(True)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnableEditColumns(ByVal state As Boolean)

        Dim cellStyleQuantity As New System.Windows.Forms.DataGridViewCellStyle(Me.colQuantity.DefaultCellStyle)
        Dim cellStyleUnitPrice As New System.Windows.Forms.DataGridViewCellStyle(Me.colUnitPrice.DefaultCellStyle)
        Dim cellStyleBalance As New System.Windows.Forms.DataGridViewCellStyle(Me.colBalance.DefaultCellStyle)

        If state Then
            cellStyleQuantity.BackColor = System.Drawing.SystemColors.Window
            cellStyleUnitPrice.BackColor = System.Drawing.SystemColors.Window
            cellStyleBalance.BackColor = System.Drawing.SystemColors.Info
            Me.btnEdit.Text = UpdateText
        Else
            cellStyleQuantity.BackColor = System.Drawing.SystemColors.Info
            cellStyleUnitPrice.BackColor = System.Drawing.SystemColors.Info
            cellStyleBalance.BackColor = System.Drawing.SystemColors.Info
            Me.btnEdit.Text = EditText
        End If

        Me.colQuantity.ReadOnly = Not state
        '  Me.colUnitPrice.ReadOnly = Not state
        Me.btnSave.Enabled = Not state
        Me.btnPrint.Visible = Not state
        Me.colQuantity.DefaultCellStyle = cellStyleQuantity
        ' Me.colUnitPrice.DefaultCellStyle = cellStyleUnitPrice

    End Sub

    Private Sub btnGenerateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateInvoice.Click

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim cashBillMode As String = GetLookupDataDes(oBillModesID.Cash)

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim fInvoices As New frmInvoices(visitNo)

            If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then fInvoices.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oAlertTypeID As New LookupDataID.AlertTypeID()
            Dim fAlerts As New frmAlerts(oAlertTypeID.Prescription, Me.stbVisitNo)
            fAlerts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If Not String.IsNullOrEmpty(visitNo) Then : Me.LoadDrugsData(visitNo)
            Else : Me.stbVisitNo.Focus()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnViewToOrderDrugsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToOrderDrugsList.Click
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim LocationID As String = StringValueEnteredIn(Me.cboLocationID, "location!")
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim GetToCountToOrderInventoryLocation As New frmGetToCountInventoryLocation(LocationID, oItemCategoryID.Drug, ItemsTo.Order, True)
            GetToCountToOrderInventoryLocation.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CountToOrderInventoryLocation(oItemCategoryID.Drug, LocationID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnViewToExpireDrugsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToExpireDrugsList.Click

  
        Try
            Dim LocationID As String = StringValueEnteredIn(Me.cboLocationID, "location!")
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim GetToCountToOrderInventoryLocation As New frmGetToCountInventoryLocation(LocationID, oItemCategoryID.Drug, ItemsTo.Expire, True)
            GetToCountToOrderInventoryLocation.ShowDialog(Me)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CountToExpireInventoryLocation(oItemCategoryID.Drug, LocationID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub


#Region " Alerts "

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.Prescription).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Prescription: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowConsumableSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.Consumable).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblConsumableAlerts.Text = "Sent Consumables: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowToOrderDrugs() As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToOrderDrugs()
            Me.lblToOrderDrugs.Text = "To Order Drugs: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowToExpireDrugs() As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToExpireDrugs(oVariousOptions.ExpiryWarningDays)
            Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Sub DeleteAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If alerts Is Nothing OrElse alerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = alerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts
                                        Where data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                        GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate))
                                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, alertsStartDateTime, Now)
            If period >= InitOptions.AlertCheckPeriod Then
                If Me.ShowSentAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
                If Me.ShowConsumableSentAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadDrugsData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadDrugsData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub tbcPharmacy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcPharmacy.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcPharmacy.SelectedTab.Name

                Case Me.tpgPrescription.Name

                    Me.pnlPrintPrescription.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnAddConsumables.Visible = True
                    Me.btnAddExtraCharge.Visible = True
                    Me.btnEdit.Visible = True
                    Me.pnlGenerateInvoice.Visible = True
                    Me.btnGenerateInvoice.Visible = True
                    Me.pnlNavigateVisits.Visible = True
                    Me.btnPrint.Visible = True

                Case Me.tpgConsumables.Name

                    Me.pnlPrintPrescription.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnAddConsumables.Visible = True
                    Me.btnAddExtraCharge.Visible = True
                    Me.btnEdit.Visible = False
                    Me.pnlGenerateInvoice.Visible = False
                    Me.btnGenerateInvoice.Visible = False
                    Me.pnlNavigateVisits.Visible = False
                    Me.btnPrint.Visible = False

                Case Me.tpgDiagnosis.Name

                    Me.pnlPrintPrescription.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnAddConsumables.Visible = False
                    Me.btnAddExtraCharge.Visible = False
                    Me.btnEdit.Visible = False
                    Me.pnlGenerateInvoice.Visible = False
                    Me.btnGenerateInvoice.Visible = False
                    Me.pnlNavigateVisits.Visible = False
                    Me.btnPrint.Visible = False

                Case Else

                    Me.pnlPrintPrescription.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnAddConsumables.Visible = True
                    Me.btnAddExtraCharge.Visible = True
                    Me.btnEdit.Visible = True
                    Me.pnlGenerateInvoice.Visible = True
                    Me.btnGenerateInvoice.Visible = True
                    Me.pnlNavigateVisits.Visible = True
                    Me.btnPrint.Visible = True

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount >= 1 Then
                If Me.dgvPrescription.RowCount = 1 Then
                    message = "Please ensure that current prescription is saved!"
                Else : message = "Please ensure that current prescriptions are saved!"
                End If
                If Not hideMessage Then DisplayMessage(message)
                Me.btnSave.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim message As String
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oServicePoint As New LookupDataID.ServicePointID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lWaitingPatient As New List(Of DBConnect)
        Dim lservicePoints As New List(Of String)
        Dim lItems As New List(Of DBConnect)
        Dim lServiceFee As New List(Of DBConnect)
        Dim lItemsBalanceDetails As New List(Of DBConnect)
        Dim lClaims As New List(Of DBConnect)
        Dim lItemsEXT As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim linvoices As New List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)
        Dim oSmartCardMembers As New SmartCardMembers()
        Dim lSmartCardItems As New List(Of SmartCardItems)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim issueDate As Date = DateEnteredIn(Me.dtpIssueDate, "Issue Date!")
            Dim pharmacist As String = SubstringEnteredIn(Me.cboPharmacist, "Pharmacist (Staff)!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))

            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must register at least one entry for drugs " +
                                                ControlChars.NewLine + "If this is a cash patient, ensure that payment is done first!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for drugs!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim _NACoPayType As String = GetLookupDataDes(oCoPayTypeID.NA)
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso
                billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
                        Dim amount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso amount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow dispensing of not paid for drug(s) for a cash visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowAccessCoPayServices AndAlso Not coPayType.ToUpper().Equals(_NACoPayType.ToUpper()) AndAlso
             Not billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringMayBeEnteredIn(row.Cells, Me.colCashPayStatus)
                        Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCashAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso cashAmount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow dispensing of drug(s) whose co-pay percent or value is not paid for a co-pay visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me, ErrProvider)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staffRow As DataRow = oStaff.GetStaff(pharmacist).Tables("Staff").Rows(0)
            Dim userLoginID As String = StringMayBeEnteredIn(staffRow, "LoginID")

            If oVariousOptions.RestrictPharmacistLoginID AndAlso Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then

                message = "The pharmacist you have selected has a different associated login ID from that " +
                "of the current user." + ControlChars.NewLine + "The system is set not to allow a login ID not associated with selected staff. " +
               "Contact administrator if you still need to do this."

                Throw New ArgumentException(message)

            ElseIf String.IsNullOrEmpty(userLoginID) Then
                message = "The pharmacist you have selected does not have an associated login ID. We recommend " +
               "that you contact the administrator to have this fixed. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not userLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The pharmacist you have selected has a different associated login ID from that " +
                "of the current user. " + ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
            If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
               Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                message = "Selected location " + location + " is not the same as " + InitOptions.Location +
                    " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then IsInsuranceFingerprintVerified(patientNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = issueDate
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID

                    End With

                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lInsuranceItemsCASH As New List(Of DBConnect)
            Dim oSmartCardItems As SmartCardItems
            Dim smardCardNo As String = String.Empty
            Dim medicalCardNo As String = RevertText(RevertText(StringMayBeEnteredIn(Me.stbMemberCardNo), "/"c))
            Dim coverAmount As Decimal
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForPrescription, True, "Bill for Prescription!")
            Dim totalCashAmount As Decimal = 0

            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)
                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not medicalCardNo.ToUpper().Equals(smardCardNo.ToUpper()) Then
                    message = "The medical card number  (" + StringMayBeEnteredIn(Me.stbMemberCardNo) + ") for this member is not the same " +
                              "as that forwarded from smart card (" + oSmartCardMembers.MedicalCardNumber + ") " +
                              ", the system does not allow to process numbers that don’t match"
                    Throw New ArgumentException(message)
                End If

                If billFee > coverAmount Then Throw New ArgumentException("The benefit for this patient is not sufficient to cover the bill!")
                oSmartCardMembers.InvoiceNo = visitNo

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.GenerateInventoryInvoiceOnDispensingOnly() Then
                Dim invoiceNo As String = RevertText(Me.GetNextInvoiceNo())
                lInvoiceDetails = Me.GetInvoiceDetails(visitNo, invoiceNo)
                Using oInvoice As New Invoices()
                    With oInvoice

                        .InvoiceNo = invoiceNo
                        .PayTypeID = oPayTypeID.VisitBill
                        .PayNo = visitNo
                        .InvoiceDate = issueDate
                        .StartDate = issueDate
                        .EndDate = issueDate
                        .AmountWords = NumberToWords(DecimalMayBeEnteredIn(stbBillForPrescription))
                        .VisitTypeID = oVisitTypeID.OutPatient
                        .Locked = True
                        .LoginID = CurrentUser.LoginID

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ValidateEntriesIn(Me)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End With
                    linvoices.Add(oInvoice)
                End Using
                transactions.Add(New TransactionList(Of DBConnect)(linvoices, Action.Save))
                transactions.Add(New TransactionList(Of DBConnect)(lInvoiceDetails, Action.Save))

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    Dim drugNo As String = StringEnteredIn(cells, Me.colDrugNo, "drug no!")
                    Dim drugName As String = StringEnteredIn(cells, Me.colDrugName, "drug name!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                    Dim balance As Integer = IntegerEnteredIn(cells, Me.colBalance, "balance!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                    Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasAlternateDrugs)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If quantity > 0 AndAlso unitsInStock < quantity Then
                        If Not oVariousOptions.AllowDispensingToNegative() Then
                            If hasAlternateDrugs Then
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                  (quantity - unitsInStock).ToString() + " and has registered alternatives that shows at doctor. " +
                                  "The system does not allow to dispense a drug that is out of stock. Please re-stock appropriately! "
                            Else
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                    (quantity - unitsInStock).ToString() + " and has no registered alternatives to show at doctor. " +
                                    "The system does not allow to dispence a drug that is out of stock. Please re-stock appropriately! "
                            End If
                            Throw New ArgumentException(message)
                        Else
                            message = "Insufficient stock to dispense for " + drugName +
                                      " with a deficit of " + (quantity - unitsInStock).ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf orderLevel >= unitsInStock - quantity Then

                        If Not hasAlternateDrugs Then
                            message = "Stock level for " + drugName + " is running low with no registered alternatives to show at doctor. " +
                                  "Please re-stock appropriately!"
                        Else : message = "Stock level for " + drugName + " is running low. Please re-stock appropriately!"
                        End If
                        DisplayMessage(message)

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Drug, drugNo)
                    If quantity > 0 AndAlso locationBalance < quantity Then
                        If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                            message = "The system does not allow issuing of drug: " + drugName + ", with unit(s) not present at " + location + "!"
                            Throw New ArgumentException(message)
                        Else
                            message = "You are about to issue drug: " + drugName + ", with unit(s) not present at " + location + ". " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowDispensingExpiredDrugs() Then
                            message = "Expiry date for " + drugName + " had reached. " +
                                "The system does not allow to dispence a drug that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + drugName + " had reached. " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Drug: " + drugName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                        DisplayMessage(message)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .LastUpdate = issueDate
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Offered

                        End With

                        lItems.Add(oItems)

                    End Using


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItemsEXT As New SyncSoft.SQLDb.ItemsEXT()
                        With oItemsEXT

                            .VisitNo = visitNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Pharmacist = pharmacist
                            .LocationID = locationID
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItemsEXT.Add(oItemsEXT)

                    End Using

                    If oVariousOptions.AllowDrugsServiceFee AndAlso hasServiceFee.Equals(True) AndAlso Me.dgvPrescription.RowCount > 0 Then
                        Using oServiceFee As New SyncSoft.SQLDb.Items()
                            With oServiceFee
                                .VisitNo = visitNo
                                .ItemCode = oServiceCodes.ServiceFee
                                .LastUpdate = issueDate
                                .ItemCategoryID = oItemCategoryID.Service
                                .ItemStatusID = oItemStatusID.Done
                                .PayStatusID = String.Empty
                                .LoginID = CurrentUser.LoginID


                            End With
                            lServiceFee.Add(oServiceFee)
                        End Using
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'If Convert.ToInt32(Me.dgvPrescription.Item(Me.colBalance.Name, rowNo).Value) > 0 Then
                    If balance > 0 Then
                        Using oItemBalanceDetails As New SyncSoft.SQLDb.ItemsBalanceDetails()
                            With oItemBalanceDetails
                                .VisitNo = visitNo
                                .ItemCategoryID = oItemCategoryID.Drug
                                .ItemCode = drugNo
                                .Balance = balance
                                '.BalanceStatus = oItemStatusID.Pending
                                .LoginID = CurrentUser.LoginID
                            End With
                            lItemsBalanceDetails.Add(oItemBalanceDetails)
                        End Using
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardItems = New SmartCardItems()

                        With oSmartCardItems

                            .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                            .TransactionTime = GetTime(Now)
                            .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                            .DiagnosisCode = (0).ToString()
                            .DiagnosisDescription = "Unknown Disease"
                            .EncounterType = GetEncounterType(oItemCategoryID.Drug)
                            .CodeType = "Mcode"
                            .Code = drugNo
                            .CodeDescription = drugName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim dosage As String = cells.Item(Me.colDosage.Name).Value.ToString()
                        Dim duration As String = cells.Item(Me.colDuration.Name).Value.ToString()

                        Dim fullDosage As String
                        If duration.Trim().Equals("1") Then
                            fullDosage = dosage + " for " + duration + " day"
                        Else : fullDosage = dosage + " for " + duration + " days"
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Drug)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Drug)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = drugName
                                .BenefitCode = oBenefitCodes.Drug
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = fullDosage
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance

                            End With

                            lClaimDetails.Add(oClaimDetails)

                        End Using

                    End If

                    Using oInventory As New SyncSoft.SQLDb.Inventory()
                        With oInventory
                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = drugNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = quantity
                            .Details = "Drug(s) Issued to Visit No: " + visitNo
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = String.Empty
                            .ExpiryDate = AppData.NullDateValue
                        End With

                        lInventory.Add(oInventory)

                    End Using
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

           

            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then
                oSmartCardMembers.InvoiceNo = visitNo
                oSmartCardMembers.TotalBill = billFee
                oSmartCardMembers.TotalServices = lSmartCardItems.Count()
                oSmartCardMembers.CopayType = copayTypeID
                oSmartCardMembers.CopayAmount = totalCashAmount
                oSmartCardMembers.Gender = genderID
                Dim oVisitTypeID As New LookupDataID.VisitTypeID()

                If Not UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, visitNo, oVisitTypeID.OutPatient) Then
                    Throw New ArgumentException("Error processing smart card information. Please edit the transactions and try again")
                    Return
                End If

            End If

            lservicePoints.Add(oServicePoint.Pharmacy())
            lservicePoints.Add(oServicePoint.Doctor())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lWaitingPatient = GetQueuesList(visitNo, oServicePoint.Pharmacy(), Me.PriorityID, lservicePoints)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lItemsEXT, Action.Update))

            If oVariousOptions.AllowDrugsServiceFee AndAlso Me.dgvPrescription.RowCount > 0 Then
                transactions.Add(New TransactionList(Of DBConnect)(lServiceFee, Action.Update))
            End If
            transactions.Add(New TransactionList(Of DBConnect)(lItemsBalanceDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lWaitingPatient, Action.Save))
            DoTransactions(transactions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If GetLookupDataDes(oVisitCategoryID.Refill).Equals(Me.stbVisitCategory.Text.Trim()) Then Me.SaveNextAppointment()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.SMSNotificationAtPharmacy Then
                If stbPhoneNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(stbPhoneNo.Text) Then
                    Dim ppatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
                    Dim oPatient As New SyncSoft.SQLDb.Patients()
                    oPatient.GetPatient(ppatientNo)
                    Dim productOwner As String = AppData.ProductOwner
                    Dim recipients As String = stbPhoneNo.Text
                    Dim txtmessage As String = ("Hi" + " " + oPatient.FirstName.ToString + " " + "Your drugs at" + " " + productOwner + " " + "are ready,Remember to take them as directed & on time  " + "-Via ClinicMaster")
                    SaveTextMessage(txtmessage, recipients, Now, oVariousOptions.SMSLifeSpanPharmacy)
                End If
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkGenerateInvoiceOnSaving.Checked Then Me.btnGenerateInvoice.PerformClick()
            If Me.chkPrintPrescriptionOnSaving.Checked Then Me.PrintPrescription()
            If Me.chkPrintDrugLabel.Checked Then Me.PrintDrugLabel()
            If Me.chkPrintDrugBarcode.Checked Then Me.PrintDrugBarcodes()
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadDrugsToIssue(visitNo)
                    Exit For
                End If
                allSelected = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.OpenPharmacyAfterCashier Then
                If dgvConsumables.RowCount > 0 Then
                    Dim fIssueConsumables As New frmIssueConsumables(visitNo)
                    fIssueConsumables.ShowDialog()
                End If

            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If dgvConsumables.RowCount > 0 Then
                message = "This Patient has Pending Consumables Would you like to issue them  now?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIssueConsumables As New frmIssueConsumables(visitNo)
                    fIssueConsumables.ShowDialog()
                End If
            End If

            If allSelected Then
                Me.dgvPrescription.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlNavigateVisits)
                Me.ClearControls()
                Me.SetDefaultLocation()
            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()
            Me.ShowToOrderDrugs()
            Me.ShowConsumableSentAlerts()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.tbcPharmacy.SelectTab(Me.tpgPrescription.Name)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit
        Try
            If e.ColumnIndex.Equals(Me.colInclude.Index) OrElse e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse e.ColumnIndex.Equals(Me.colUnitPrice.Index) Then
                'xaxa()
                If PharmacyPrescription.Quantity.ContainsKey(Convert.ToInt32(Me.dgvPrescription.CurrentCell.RowIndex)) Then

                    Dim Balance, Quantity, Difference As Integer
                    If Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value) < 0 Then
                        Quantity = PharmacyPrescription.Quantity(Me.dgvPrescription.CurrentCell.RowIndex)
                        DisplayMessage("Quantity Cannot Be More Less Than Zero")
                        Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value = Quantity

                    ElseIf (Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value) >= 0 And Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value) < PharmacyPrescription.DrQuantity(Me.dgvPrescription.CurrentCell.RowIndex)) Then
                        Difference = PharmacyPrescription.DrQuantity(Me.dgvPrescription.CurrentCell.RowIndex) - Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value)
                        Balance = Difference
                        ' Balance = PharmacyPrescription.Balance(Me.dgvPrescription.CurrentCell.RowIndex) + Difference
                        Me.dgvPrescription.Item(Me.colBalance.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value = Balance
                        Me.CalculatePrescriptionAmount(Me.dgvPrescription.CurrentCell.RowIndex)
                        Me.CalculatePrescriptionTotalBill()
                    ElseIf (Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value) >= 0 And Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value) > PharmacyPrescription.DrQuantity(Me.dgvPrescription.CurrentCell.RowIndex)) Then
                        'Difference = PharmacyPrescription.Quantity(Me.dgvPrescription.CurrentCell.RowIndex) - Convert.ToInt32(Me.dgvPrescription.Item(Me.colQuantity.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value)
                        'Balance = PharmacyPrescription.Balance(Me.dgvPrescription.CurrentCell.RowIndex) + Difference
                        Me.dgvPrescription.Item(Me.colBalance.Name, Me.dgvPrescription.CurrentCell.RowIndex).Value = 0
                        Me.CalculatePrescriptionAmount(Me.dgvPrescription.CurrentCell.RowIndex)
                        Me.CalculatePrescriptionTotalBill()
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CalculatePrescriptionAmount(selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colUnitPrice)

        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculatePrescriptionTotalBill()

        Dim totalBill As Decimal

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.stbBillForPrescription.Clear()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                totalBill += amount
            End If
        Next

        Me.stbBillForPrescription.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CalculateGrandTotalAmount()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DetailDrugLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                Dim drugNo As String = StringMayBeEnteredIn(row.Cells, Me.colDrugNo)
                If String.IsNullOrEmpty(drugNo) Then Continue For

                Me.dgvPrescription.Item(Me.colDrugLocationBalance.Name, row.Index).Value = String.Empty
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvPrescription.Item(Me.colDrugLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub CalculateConsumablesTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForConsumables.Clear()

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
            totalBill += amount
        Next

        Me.stbBillForConsumables.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbConsumablesAmountWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateGrandTotalAmount()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbGrandTotalAmount.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billForPrescription As Decimal = DecimalMayBeEnteredIn(Me.stbBillForPrescription, True)
            Dim billForConsumables As Decimal = DecimalMayBeEnteredIn(Me.stbBillForConsumables, True)
            Dim grandTotal As Decimal = billForPrescription + billForConsumables

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If grandTotal = 0 Then
                Me.stbGrandTotalAmount.Clear()
                Me.stbGrandAmountWords.Clear()
            Else
                Me.stbGrandTotalAmount.Text = FormatNumber(grandTotal, AppData.DecimalPlaces)
                Me.stbGrandAmountWords.Text = NumberToWords(grandTotal)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub SaveNextAppointment()

        Dim oNextAppointment As New NextAppointment()
        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
        Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()

        Try

            Dim appointmentMSG As String = "It’s recommended that you schedule an appointment for the next refill date." +
                                            ControlChars.NewLine + "Would you like to schedule next refill appointment now?"

            Dim issueDate As Date = DateMayBeEnteredIn(Me.dtpIssueDate)
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim refillDuration As Integer = IntegerMayBeEnteredIn(Me.stbRefillDuration)

            If refillDuration < 1 OrElse issueDate.AddDays(refillDuration) < Today Then Return

            If WarningMessage(appointmentMSG) = DialogResult.No Then Return

            oDoctorVisits.GetDoctorVisit(visitNo)

            With oNextAppointment
                .PatientNo = StringMayBeEnteredIn(Me.stbPatientNo)
                .FullName = StringMayBeEnteredIn(Me.stbFullName)
                .StartDate = issueDate.AddDays(refillDuration)
                .AppointmentPrecisionID = oAppointmentPrecisionID.Range
                .StartTime = String.Empty
                .Duration = 0
                .EndDate = issueDate.AddDays(refillDuration)
                .StaffFullName = oDoctorVisits.StaffFullName
                .AppointmentDes = "Drug Refill"
            End With

            Dim fAppointments As frmAppointments = New frmAppointments(oNextAppointment)
            fAppointments.NextAppointment()
            fAppointments.ShowDialog(Me)

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Prescription Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.chkPrintDrugLabel.Checked = True Then Me.PrintDrugLabel()

            Me.PrintPrescription()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintPrescription()

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Me.Cursor = Cursors.WaitCursor
           
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for prescription!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for prescription!")

            Select Case pharmacyPrinterPaperSize

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintPharmacyThermalPrescription()

                Case Else

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetPrescriptionPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docPrescription
                    'dlgPrint.AllowPrintToFile = True
                    'dlgPrint.AllowSelection = True
                    'dlgPrint.AllowSomePages = True
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docPrescription.Print()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPrescription_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPrescription.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)
            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine
            Dim prescriptiontitle As String = ControlChars.NewLine + "Prescription".ToUpper()
            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)
            Dim NextAppointmentDate As String = StringMayBeEnteredIn(Me.stbNextAppointmentDate)
            Dim AppointmentDetails As String = StringMayBeEnteredIn(Me.stbAppointmentDetails)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 6 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst
                Dim widthTopFourth As Single = 20 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString(prescriptiontitle, titleFont, Brushes.Black, xPos + widthTopThird, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    If Not String.IsNullOrEmpty(insuranceName) Then
                        yPos += lineHeight

                        .DrawString("Bill Insurance Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(insuranceName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    End If

                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If prescriptionParagraphs Is Nothing Then Return

                Do While prescriptionParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(prescriptionParagraphs(1), PrintParagraps)
                    prescriptionParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        prescriptionParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (prescriptionParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPrescriptionPrintData()

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        prescriptionParagraphs = New Collection()

        Try

            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)

            prescriptionParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))

            If Not String.IsNullOrEmpty(Me.DiagnosisData()) Then
                prescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))

            ElseIf String.IsNullOrEmpty(provisionalDiagnosis) Then
                Dim diagnosisEmptyData As New System.Text.StringBuilder(String.Empty)
                diagnosisEmptyData.Append(ControlChars.NewLine)
                diagnosisEmptyData.Append(GetSpaces(10))
                diagnosisEmptyData.Append(GetCharacters("."c, 62))
                diagnosisEmptyData.Append(ControlChars.NewLine)
                prescriptionParagraphs.Add(New PrintParagraps(footerFont, diagnosisEmptyData.ToString()))
            Else : prescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, provisionalDiagnosis))
            End If

            ''''''''''''''''PRESCRIPTION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("PRESCRIPTION: ".ToUpper)
            prescriptionTitle.Append(ControlChars.NewLine)

            Dim prescriptionHeader As New System.Text.StringBuilder(String.Empty)
            prescriptionHeader.Append("No: ".PadRight(padItemNo))
            prescriptionHeader.Append("Drug Name: ".PadRight(padItemName))
            prescriptionHeader.Append("  ")
            prescriptionHeader.Append("Dosage: ".PadRight(padFullDosage))
            prescriptionHeader.Append(ControlChars.NewLine)
            prescriptionHeader.Append(ControlChars.NewLine)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            prescriptionParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionTitle.ToString()))
            prescriptionParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionHeader.ToString()))
            prescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionData()))

            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append(ControlChars.NewLine)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim NextAppointmentDate As String = StringMayBeEnteredIn(Me.stbNextAppointmentDate)
            Dim AppointmentDetails As String = StringMayBeEnteredIn(Me.stbAppointmentDetails)
            Dim textData As New System.Text.StringBuilder(String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            textData.Append(ControlChars.NewLine)
            textData.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(NextAppointmentDate) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Next Appointment (Review) Date: " + NextAppointmentDate)
                Else
                    textData.Append("Next Appointment (Review) Date: " + NextAppointmentDate)
                End If
            End If

                    If Not String.IsNullOrEmpty(AppointmentDetails) Then
                        If textData.Length > 1 Then
                            textData.Append(ControlChars.NewLine)
                            textData.Append(ControlChars.NewLine)
                    textData.Append("Appointment (Review) Details: " + AppointmentDetails)
                        Else
                    textData.Append("Appointment (Review) Details: " + AppointmentDetails)
                        End If
                    End If
            Dim prescribedby As String = StringMayBeEnteredIn(Me.cboPharmacist)

            prescriptionParagraphs.Add(New PrintParagraps(bodyBoldFont, textData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Dispensed by: " + prescribedby.Substring(0, prescribedby.IndexOf("-"c)))
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
                    footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                                      Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
                    footerData.Append(ControlChars.NewLine)
                    prescriptionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function DiagnosisData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseName)
                tableData.Append(diagnosisDisplay)

                If rowNo < Me.dgvDiagnosis.RowCount - 1 Then tableData.Append(", ")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionData() As String

        Try

            Dim itemNo As String = 0.ToString()
            Dim notPaifForItemNo As String = 0.ToString()

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim tableDataNotPaidFor As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    'Dim itemNo As String = (count).ToString()
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrugName)
                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)
                    Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)

                    Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()

                    Dim fullDosage As String
                    If String.IsNullOrEmpty(notes) Then
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " for " + duration + " day"
                        Else : fullDosage = dosage + " for " + duration + " days"
                        End If
                    Else
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage + " (" + notes + ")"
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
                        Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
                        End If
                    End If

                    If CType(quantity, Integer) = 0 Then
                        notPaifForItemNo = (CType(notPaifForItemNo, Integer) + 1).ToString()

                        tableDataNotPaidFor.Append(notPaifForItemNo.PadRight(padItemNo))
                        tableDataNotPaidFor.Append(itemName.PadRight(padItemName))
                        tableDataNotPaidFor.Append(GetSpaces(2))

                        Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
                        If wrappedfullDosage.Count > 1 Then
                            For pos As Integer = 0 To wrappedfullDosage.Count - 1
                                tableDataNotPaidFor.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                                tableDataNotPaidFor.Append(ControlChars.NewLine)
                                tableDataNotPaidFor.Append(GetSpaces(padItemNo + padItemName + 2))
                            Next
                        Else : tableDataNotPaidFor.Append(FixDataLength(fullDosage, padFullDosage))
                        End If
                        tableDataNotPaidFor.Append(ControlChars.NewLine)

                    Else

                        itemNo = (CType(itemNo, Integer) + 1).ToString()

                        tableData.Append(itemNo.PadRight(padItemNo))
                        tableData.Append(itemName.PadRight(padItemName))
                        tableData.Append(GetSpaces(2))

                        Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
                        If wrappedfullDosage.Count > 1 Then
                            For pos As Integer = 0 To wrappedfullDosage.Count - 1
                                tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo + padItemName + 2))
                            Next
                        Else : tableData.Append(FixDataLength(fullDosage, padFullDosage))
                        End If
                        tableData.Append(ControlChars.NewLine)
                    End If
                End If
            Next

            If CType(notPaifForItemNo, Integer) > 0 Then

                Dim NotPaidFortableHeader As New System.Text.StringBuilder(String.Empty)
                NotPaidFortableHeader.Append(ControlChars.NewLine)
                NotPaidFortableHeader.Append("DRUGS NOT PAID FOR".ToUpper())
                NotPaidFortableHeader.Append(ControlChars.NewLine)
                NotPaidFortableHeader.Append(ControlChars.NewLine)
                NotPaidFortableHeader.Append("No: ".PadRight(padItemNo))
                NotPaidFortableHeader.Append("Drug Name: ".PadRight(padItemName))
                NotPaidFortableHeader.Append(" ")
                NotPaidFortableHeader.Append("Dosage: ".PadRight(padFullDosage))
                NotPaidFortableHeader.Append(ControlChars.NewLine)
                NotPaidFortableHeader.Append(ControlChars.NewLine)

                tableData.Append(NotPaidFortableHeader.ToString())

                tableData.Append(tableDataNotPaidFor.ToString())

                Return tableData.ToString()

            Else
                Return tableData.ToString()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

    '#Region "PHARMACY THERMAL Prescription PRINTOUT"


    '    Private Sub PrintPharmacyThermalPrescription()

    '        Dim dlgPrint As New PrintDialog()

    '        Try

    '            Me.Cursor = Cursors.WaitCursor

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Prescription!")

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Dim nonSelected As Boolean = False

    '            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
    '                If row.IsNewRow Then Exit For
    '                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
    '                    nonSelected = False
    '                    Exit For
    '                End If
    '                nonSelected = True
    '            Next

    '            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Prescription !")

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            Me.SetPharmacyThermalPrescriptionPrintData()
    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            dlgPrint.Document = docPharmacyThermalPrescription
    '            'dlgPrint.AllowPrintToFile = True
    '            'dlgPrint.AllowSelection = True
    '            'dlgPrint.AllowSomePages = True
    '            dlgPrint.Document.PrinterSettings.Collate = True
    '            If dlgPrint.ShowDialog = DialogResult.OK Then docPharmacyThermalPrescription.Print()

    '        Catch ex As Exception
    '            Throw ex

    '        End Try

    '    End Sub

    '    Private Sub docPharmacyThermalPrescription_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPharmacyThermalPrescription.PrintPage

    '        Try

    '            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

    '            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
    '            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)
    '            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
    '            Dim title As String = AppData.ProductOwner.ToUpper()
    '            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
    '            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
    '            Dim VisitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
    '            Dim VisitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
    '            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
    '            Dim BillCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)


    '            ' Increment the page number.
    '            pageNo += 1

    '            With e.Graphics

    '                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
    '                Dim widthTopSecond As Single = 9 * widthTopFirst
    '                Dim widthTopThird As Single = 11 * widthTopFirst

    '                If pageNo < 2 Then

    '                    If (title.Length > 25) Then
    '                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
    '                        yPos += lineHeight
    '                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
    '                        yPos += lineHeight
    '                        .DrawString("Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
    '                        yPos += 3 * lineHeight
    '                    Else
    '                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
    '                        yPos += lineHeight
    '                        .DrawString("Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
    '                        yPos += 3 * lineHeight
    '                    End If


    '                    If (fullName.Length > 14) Then
    '                        .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                        .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += lineHeight
    '                        .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += lineHeight
    '                    Else
    '                        .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                        .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += lineHeight
    '                    End If


    '                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight

    '                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(VisitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight

    '                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(VisitDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight

    '                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight

    '                    '.DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    '.DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    'yPos += 2 * lineHeight

    '                    If (BillCustomerName.Length > 14) Then
    '                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                        .DrawString(BillCustomerName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += lineHeight
    '                        .DrawString(BillCustomerName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += 2 * lineHeight
    '                    Else
    '                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                        .DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                        yPos += 2 * lineHeight
    '                    End If

    '                End If

    '                Dim _StringFormat As New StringFormat()

    '                ' Draw the rest of the text left justified,
    '                ' wrap at words, and don't draw partial lines.

    '                With _StringFormat
    '                    .Alignment = StringAlignment.Near
    '                    .FormatFlags = StringFormatFlags.LineLimit
    '                    .Trimming = StringTrimming.Word
    '                End With

    '                Dim charactersFitted As Integer
    '                Dim linesFilled As Integer

    '                If PharmacyThermalPrescriptionParagraphs Is Nothing Then Return

    '                Do While PharmacyThermalPrescriptionParagraphs.Count > 0

    '                    ' Print the next paragraph.
    '                    Dim oPrintParagraps As PrintParagraps = DirectCast(PharmacyThermalPrescriptionParagraphs(1), PrintParagraps)
    '                    PharmacyThermalPrescriptionParagraphs.Remove(1)

    '                    ' Get the area available for this paragraph.
    '                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

    '                    ' If the printing area rectangle's height < 1, make it 1.
    '                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

    '                    ' See how big the text will be and how many characters will fit.
    '                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
    '                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

    '                    ' See if any characters will fit.
    '                    If charactersFitted > 0 Then
    '                        ' Draw the text.
    '                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
    '                        ' Increase the location where we can start, add a little interparagraph spacing.
    '                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

    '                    End If

    '                    ' See if some of the paragraph didn't fit on the page.
    '                    If charactersFitted < oPrintParagraps.Text.Length Then
    '                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
    '                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
    '                        PharmacyThermalPrescriptionParagraphs.Add(oPrintParagraps, Before:=1)
    '                        Exit Do
    '                    End If
    '                Loop

    '                ' If we have more paragraphs, we have more pages.
    '                e.HasMorePages = (PharmacyThermalPrescriptionParagraphs.Count > 0)

    '            End With

    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '    End Sub

    '    Private Sub SetPharmacyThermalPrescriptionPrintData()

    '        Dim padItemNo As Integer = 4
    '        Dim padItemName As Integer = 16
    '        Dim padQuantity As Integer = 8
    '        Dim padIAmount As Integer = 10


    '        Dim footerFont As New Font(printFontName, 9)

    '        pageNo = 0
    '        PharmacyThermalPrescriptionParagraphs = New Collection()

    '        Try


    '            Dim count As Integer
    '            Dim tableData As New System.Text.StringBuilder(String.Empty)
    '            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

    '                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

    '                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

    '                    count += 1

    '                    Dim itemNo As String = (count).ToString()
    '                    Dim DrugName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
    '                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
    '                    Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)
    '                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)


    '                    Dim fullDosage As String
    '                    If String.IsNullOrEmpty(notes) Then
    '                        If duration.Trim().Equals("0") Then
    '                            fullDosage = dosage
    '                        ElseIf duration.Trim().Equals("1") Then
    '                            fullDosage = dosage + " for " + duration + " day"
    '                        Else : fullDosage = dosage + " for " + duration + " days"
    '                        End If
    '                    Else
    '                        If duration.Trim().Equals("0") Then
    '                            fullDosage = dosage + " (" + notes + ")"
    '                        ElseIf duration.Trim().Equals("1") Then
    '                            fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
    '                        Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
    '                        End If
    '                    End If


    '                    tableData.Append(itemNo.PadRight(padItemNo))
    '                    tableData.Append(DrugName.PadRight(padItemName))
    '                    tableData.Append(ControlChars.NewLine)

    '                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
    '                    If wrappedfullDosage.Count > 1 Then
    '                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
    '                            tableData.Append(GetSpaces(padItemNo))
    '                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
    '                            tableData.Append(ControlChars.NewLine)

    '                        Next
    '                    Else
    '                        tableData.Append(GetSpaces(padItemNo))
    '                        tableData.Append(FixDataLength(fullDosage, padFullDosage))
    '                        tableData.Append(ControlChars.NewLine)
    '                    End If
    '                    tableData.Append(ControlChars.NewLine)


    '                End If
    '            Next

    '            PharmacyThermalPrescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

    '            Dim footerData As New System.Text.StringBuilder(String.Empty)
    '             footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now))
    '            footerData.Append("at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
    '             PharmacyThermalPrescriptionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '    End Sub

    '#End Region

#Region "PHARMACY THERMAL Prescription PRINTOUT"


    Private Sub PrintPharmacyThermalPrescription()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Prescription!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Prescription !")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPharmacyThermalPrescriptionPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docPharmacyThermalPrescription
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPharmacyThermalPrescription.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPharmacyThermalPrescription_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPharmacyThermalPrescription.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)
            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper()
            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
           
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                   
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)

                        .DrawString("Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight



                    If (fullName.Length > 14) Then
                        .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    Else
                        .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If


                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight


                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If PharmacyThermalPrescriptionParagraphs Is Nothing Then Return

                Do While PharmacyThermalPrescriptionParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(PharmacyThermalPrescriptionParagraphs(1), PrintParagraps)
                    PharmacyThermalPrescriptionParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        PharmacyThermalPrescriptionParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (PharmacyThermalPrescriptionParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPharmacyThermalPrescriptionPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        PharmacyThermalPrescriptionParagraphs = New Collection()

        Try


            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim DrugName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                    Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)


                    Dim fullDosage As String
                    If String.IsNullOrEmpty(notes) Then
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " for " + duration + " day"
                        Else : fullDosage = dosage + " for " + duration + " days"
                        End If
                    Else
                        If duration.Trim().Equals("0") Then
                            fullDosage = dosage + " (" + notes + ")"
                        ElseIf duration.Trim().Equals("1") Then
                            fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
                        Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
                        End If
                    End If


                    tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(DrugName.PadRight(padItemName))


                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
                    If wrappedfullDosage.Count > 1 Then
                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
                            tableData.Append(GetSpaces(padItemNo))
                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                            tableData.Append(ControlChars.NewLine)

                        Next
                    Else
                        tableData.Append(GetSpaces(padItemNo))
                        tableData.Append(FixDataLength(fullDosage, padFullDosage))
                        'tableData.Append(ControlChars.NewLine)
                    End If
                    ' tableData.Append(ControlChars.NewLine)


                End If
            Next

            PharmacyThermalPrescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append("Printed from " + AppData.AppTitle)
            PharmacyThermalPrescriptionParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region


#Region "DRUG LABEL THERMAL PRINTOUT"

    Private Sub PrintDrugLabel()

        Dim Message As String
        Try
            If Me.chkPrintDrugLabel.Checked = True Then

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then

                        'For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
                        Message = "You are about to print Drug Label for " + CStr(Me.dgvPrescription.Item(Me.colDrugName.Name, row.Index).Value) +
            ControlChars.NewLine + "Are you sure you want to continue?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                            Me.PrintDosage(row.Index)

                        End If

                    End If
                Next
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub PrintDosage(ByVal rowNo As Integer)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Pharmacy request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Pharmacy request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDosagePrintData(rowNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docDrugLabel
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDrugLabel.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub docDrugLabel_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDrugLabel.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 10, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 6)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            'Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Pharmacy Prescription".ToUpper()
            Dim title As String = AppData.ProductOwner.ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then
                    If (title.Length > 25) Then
                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Drug Label For".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 1 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Drug Label For".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 1 * lineHeight
                    End If

                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos, yPos)
                    yPos += lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If DrugLabelParagraphs Is Nothing Then Return

                Do While DrugLabelParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(DrugLabelParagraphs(1), PrintParagraps)
                    DrugLabelParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        DrugLabelParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (DrugLabelParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDosagePrintData(ByVal rowNo As Integer)

        Dim footerFont As New Font(printFontName, 8)

        pageNo = 0
        DrugLabelParagraphs = New Collection()

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim DrugName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
            Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
            Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)
            Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)


            Dim fullDosage As String
            If String.IsNullOrEmpty(notes) Then
                If duration.Trim().Equals("0") Then
                    fullDosage = dosage
                ElseIf duration.Trim().Equals("1") Then
                    fullDosage = dosage + " for " + duration + " day"
                Else : fullDosage = dosage + " for " + duration + " days"
                End If
            Else
                If duration.Trim().Equals("0") Then
                    fullDosage = dosage + " (" + notes + ")"
                ElseIf duration.Trim().Equals("1") Then
                    fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
                Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
                End If
            End If

            tableData.Append(ControlChars.NewLine)
            tableData.Append(DrugName.PadRight(padItemName))
            tableData.Append(ControlChars.NewLine)

            Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
            If wrappedfullDosage.Count > 1 Then
                For pos As Integer = 0 To wrappedfullDosage.Count - 1
                    tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                    tableData.Append(ControlChars.NewLine)

                Next
            Else
                tableData.Append(FixDataLength(fullDosage, padFullDosage))
                tableData.Append(ControlChars.NewLine)
            End If
            tableData.Append(ControlChars.NewLine)


            DrugLabelParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now))
            footerData.Append(" at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            DrugLabelParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    


#End Region

#Region "Print Barcode Prescription"

    Private Sub PrintDrugBarcodes()

        Dim Message As String
        Try
            If Me.chkPrintDrugBarcode.Checked = True Then

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Message = "You are about to print Drug Bar Code for " + CStr(Me.dgvPrescription.Item(Me.colDrugName.Name, row.Index).Value) +
                        ControlChars.NewLine + "Are you sure you want to continue?"
                        toPrintRow = row.Index
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                            Me.PrintBarcodes()
                        End If

                    End If
                Next
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub docBarcodes_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBarcodes.PrintPage
        Try
            SetPrintBarCode(e)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PrintBarcodes()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Pharmacy request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Pharmacy request!")


            dlgPrint.Document = docBarcodes
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBarcodes.Print()


        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetPrintBarCode(ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim footerFont As New Font(printFontName, 8)

        pageNo = 0
        DrugLabelBarCode = New Collection()

        Try

            Dim rect As New Rectangle(0, 10, 200, 85)
            Dim sf As New StringFormat
            sf.LineAlignment = StringAlignment.Center
            Dim printFont10_Normal As New Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point)
            rect = New Rectangle(0, 10, 200, 15)
            e.Graphics.DrawRectangle(Pens.White, rect)

            Dim h, w As Integer

            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(toPrintRow).Cells
            Dim DrugName As String = "(DRUG) - " + " " + cells.Item(Me.colDrugName.Name).Value.ToString()
            w = imgIDAutomation.Width
            h = imgIDAutomation.Height
            rect = New Rectangle(0, 0, w, h)
            e.Graphics.InterpolationMode = Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            e.Graphics.DrawImage(imgIDAutomation.Image, rect)
            rect = New Rectangle(5, 0, w, 105)
            e.Graphics.DrawString(stbVisitNo.Text.ToString(), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 130)
            e.Graphics.DrawString(stbFullName.Text.ToString(), printFont10_Normal, Brushes.Black, rect, sf)
            rect = New Rectangle(5, 0, w, 170)
            e.Graphics.DrawString(DrugName.ToString, printFont10_Normal, Brushes.Black, rect, sf)
            e.Graphics.DrawRectangle(Pens.White, rect)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region


#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Prescription Extras "

    Private Sub cmsPrescription_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsPrescription.Opening

        If Me.dgvPrescription.ColumnCount < 1 OrElse Me.dgvPrescription.RowCount < 1 Then
            Me.cmsPrescriptionCopy.Enabled = False
            Me.cmsPrescriptionSelectAll.Enabled = False
            Me.cmsPrescriptionInventory.Enabled = False
            Me.cmsPrescriptionEditPrescription.Enabled = False
            Me.cmsPrescriptionRefresh.Enabled = False
        Else
            Me.cmsPrescriptionCopy.Enabled = True
            Me.cmsPrescriptionSelectAll.Enabled = True
            Me.cmsPrescriptionInventory.Enabled = True
            Me.cmsPrescriptionEditPrescription.Enabled = True
            Me.cmsPrescriptionRefresh.Enabled = True
            Security.Apply(Me.cmsPrescription, AccessRights.Write)
        End If

    End Sub

    Private Sub cmsPrescriptionCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPrescriptionCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvPrescription.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPrescription))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPrescriptionSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPrescriptionSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPrescription.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPrescriptionInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPrescriptionInventory.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim rowIndex As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            Dim drugNo As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowIndex).Cells, Me.colDrugNo)
            Dim fInventory As New frmInventory(oItemCategoryID.Drug, drugNo)
            fInventory.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadDrugsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPrescriptionEditPrescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsPrescriptionEditPrescription.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))

            Dim fDoctorPrescription As New frmDoctorPrescription(visitNo)
            fDoctorPrescription.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsPrescriptionRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmsPrescriptionRefresh.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Me.LoadDrugsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnPendingIventoryAcknowledgements_Click(sender As Object, e As EventArgs) Handles btnPendingIventoryAcknowledgements.Click
        Try
            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboLocationID)
            Dim fInventoryAcknowledges As New frmInventoryAcknowledges()
            fInventoryAcknowledges.ShowDialog(Me)
            Me.GetAllPendingOrderDetails(LocationID)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnAddExtraCharge_Click(sender As System.Object, e As System.EventArgs) Handles btnAddExtraCharge.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fExtraCharge As New frmExtraCharge(visitNo)
            fExtraCharge.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function GetNextInvoiceNo() As String

        Dim yearL2 As String = Today.Year.ToString().Substring(2)
        Dim invoiceNo As String = String.Empty
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oInvoices As New SyncSoft.SQLDb.Invoices()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Invoices", "InvoiceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            invoiceNo = yearL2 + oInvoices.GetNextInvoiceID.ToString().PadLeft(paddingLEN, paddingCHAR)



        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
        Return invoiceNo
    End Function

    Private Function GetInvoiceDetails(visitNo As String, invoiceNo As String) As List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                Dim drugNo As String = StringEnteredIn(cells, Me.colDrugNo, "drug no!")
                Dim drugName As String = StringEnteredIn(cells, Me.colDrugName, "drug name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim balance As Integer = IntegerEnteredIn(cells, Me.colBalance, "balance!")

                Using oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()

                    If oVariousOptions.GenerateInventoryInvoiceOnDispensingOnly() Then
                        With oInvoiceDetails
                            .InvoiceNo = invoiceNo
                            .VisitNo = visitNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Quantity = IntegerEnteredIn(cells, Me.colQuantity)

                            .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")

                            .Discount = 0
                            .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")


                        End With


                        lInvoiceDetails.Add(oInvoiceDetails)

                    End If
                End Using
            End If
        Next

        Return lInvoiceDetails
    End Function


    Private Sub btnOPDConsumables_Click(sender As System.Object, e As System.EventArgs) Handles btnOPDConsumables.Click
        Me.ShowConsumableSentAlerts()
        frmIssueConsumables.ShowDialog()
    End Sub
End Class