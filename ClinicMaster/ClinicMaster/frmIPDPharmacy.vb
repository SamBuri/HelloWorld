
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports GenCode128

Public Class frmIPDPharmacy

#Region " Fields "
    Private pharmacyPrinterPaperSize As String = String.Empty

    Private defaultRoundNo As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()
    Private currentAllSaved As Boolean = True
    Private currentRoundNo As String = String.Empty
    Private DrugLabelBarCode As Collection
    Private WithEvents docDrugLabel As New PrintDocument()
    Private WithEvents docBarcodes As New PrintDocument()

    Private accessCashServices As Boolean = False
    Private provisionalIPDDiagnosis As String = String.Empty

    Private Const EditText As String = "&Edit"
    Private Const UpdateText As String = "&Update"

    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private billModesID As String = String.Empty
    Private doctorStaffNo As String = String.Empty
    Private patientpackageNo As String = String.Empty
    Private hasPackage As Boolean = False
    Private WithEvents docPrescription As New PrintDocument()
    Private WithEvents docPharmacyThermalReceipt As New PrintDocument()

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 40
    Private padFullDosage As Integer = 20

    ' The paragraphs.

    Private PharmacyThermalReceiptParagraphs As Collection
    Private prescriptionParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oVariousOptions As New VariousOptions()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private toPrintRow As Integer = -1
#End Region

#Region " Validations "

    Private Sub dtpIssueDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpIssueDate.Validating

        Dim errorMSG As String = "Issue date can't be before round date!"

        Try

            Dim roundDate As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            Dim issueDate As Date = DateMayBeEnteredIn(Me.dtpIssueDate)

            If issueDate = AppData.NullDateValue Then Return

            If issueDate < roundDate Then
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

    Private Sub frmIPDPharmacy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.dtpIssueDate.MaxDate = Today

            Me.ShowSentIPDAlerts()
            Me.ShowToOrderDrugs()
            Me.ShowToExpireDrugs()
            Me.LoadStaff()
            Me.SetDefaultLocation()
            Me.SetDefaultPrinter()
            Me.ShowSentConsumableIPDAlerts()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnSave, AccessRights.Write)
            Security.Apply(Me.btnEdit, AccessRights.Update)
            Me.btnPrint.Enabled = oVariousOptions.AllowPrintingBeforeDispensing

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrIPDAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultRoundNo) Then
                Me.stbRoundNo.Text = FormatText(defaultRoundNo, "IPDDoctor", "RoundNo")
                Me.stbRoundNo.ReadOnly = True
                Me.ShowDispensingData()
                Me.ProcessTabKey(True)
                Me.EnableDefaultCTRLS(False)
            Else : Me.stbRoundNo.ReadOnly = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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

    Private Sub EnableDefaultCTRLS(ByVal state As Boolean)

        Me.btnFindAdmissionNo.Enabled = state
        Me.btnFindRoundNo.Enabled = state
        Me.btnLoadToPharmacyIPDDoctor.Enabled = state
        Me.pnlAlerts.Enabled = state

    End Sub

    Private Sub frmIPDPharmacy_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowSentIPDAlerts()
        Me.ShowSentConsumableIPDAlerts()
    End Sub

    Private Sub frmIPDPharmacy_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvPrescription.RowCount = 1 Then
            message = "Current prescription is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current prescriptions are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub stbRoundNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnAddConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim fIPDConsumables As New frmIPDConsumables(roundNo)
            fIPDConsumables.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadConsumables(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.btnEdit.Text = UpdateText Then

                Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))

                If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must Register At least one entry for prescription!")

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows

                    If row.IsNewRow Then Exit For

                    StringEnteredIn(row.Cells, Me.colDrugNo, "drug!")
                    StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                    IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    DecimalEnteredIn(row.Cells, Me.colUnitPrice, False, "unit price!")
                    StringMayBeEnteredIn(row.Cells, Me.colFormula)
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")

                Next

                For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    Try
                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                            With oIPDItems
                                .RoundNo = roundNo
                                .ItemCode = StringEnteredIn(cells, Me.colDrugNo)
                                .Quantity = IntegerEnteredIn(cells, Me.colQuantity)
                                .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False)
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colFormula)
                                .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .ItemCategoryID = oItemCategoryID.Drug
                                .ItemStatusID = oItemStatusID.Pending
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, StringEnteredIn(cells, Me.colDrugNo), oItemCategoryID.Drug).Equals(True) Then
                                    .PayStatusID = oPayStatusID.NA
                                Else
                                    .PayStatusID = oPayStatusID.NotPaid
                                End If
                                .LoginID = CurrentUser.LoginID

                                '''''''''''''''''''''''''''''''''''''''''''
                                .Save()
                                '''''''''''''''''''''''''''''''''''''''''''

                            End With
                        End Using

                    Catch ex As Exception
                        ErrorMessage(ex)

                    End Try

                Next

                '''''''''''''''''''''''''''''''''''''''''''
                Me.LoadDrugsToIssue(roundNo)
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

        If state Then
            cellStyleQuantity.BackColor = System.Drawing.SystemColors.Window
            cellStyleUnitPrice.BackColor = System.Drawing.SystemColors.Window
            Me.btnEdit.Text = UpdateText
        Else
            cellStyleQuantity.BackColor = System.Drawing.SystemColors.Info
            cellStyleUnitPrice.BackColor = System.Drawing.SystemColors.Info
            Me.btnEdit.Text = EditText
        End If

        Me.colQuantity.ReadOnly = Not state
        'Me.colUnitPrice.ReadOnly = Not state
        Me.btnSave.Enabled = Not state
        Me.btnPrint.Visible = Not state
        Me.colQuantity.DefaultCellStyle = cellStyleQuantity
        'Me.colUnitPrice.DefaultCellStyle = cellStyleUnitPrice

    End Sub

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowDispensingData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadToPharmacyIPDDoctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToPharmacyIPDDoctor.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.Drug)
            fPendingIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbRoundNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Enter

        Try
            currentAllSaved = Me.RecordSaved(False)
            If Not currentAllSaved Then
                currentRoundNo = StringMayBeEnteredIn(Me.stbRoundNo)
                ProcessTabKey(True)
            Else : currentRoundNo = String.Empty
            End If

        Catch ex As Exception
            currentRoundNo = String.Empty
        End Try

    End Sub

    Private Sub stbRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.stbRoundNo.Text = currentRoundNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbRoundNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRoundNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.stbRoundNo.Text = currentRoundNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub cboLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLocationID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.DetailDrugLocationBalance()


            Dim LocationID As String = StringValueMayBeEnteredIn(Me.cboLocationID)
               Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If (Not (LocationID = "")) Then
                Me.GetAllPendingOrderDetails(LocationID)
            End If
           
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbVisitNo.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.cboPharmacist.SelectedIndex = -1
        Me.cboPharmacist.SelectedIndex = -1
        accessCashServices = False
        provisionalIPDDiagnosis = String.Empty
        billModesID = String.Empty
        doctorStaffNo = String.Empty
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        ' Me.stbAdmissionNo.Clear()
        Me.stbRefillDuration.Clear()
        Me.lblRefillDuration.Visible = False
        Me.stbRefillDuration.Visible = False
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.btnAddConsumables.Enabled = False
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgPrescription)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgDiagnosis)
        Me.EnableEditColumns(False)
        patientpackageNo = String.Empty
        hasPackage = False
    End Sub

    Private Sub ShowDispensingData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.pnlNavigateRounds)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadDrugsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugsData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            Me.LoadDrugsToIssue(roundNo)
            Me.LoadDiagnosis(roundNo)
            Me.LoadConsumables(roundNo)
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()
            If String.IsNullOrEmpty(roundNo) Then Return

            Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctor(roundNo).Tables("IPDDoctor")
            Dim row As DataRow = iPDDoctor.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")
            Dim billNo As String = StringEnteredIn(row, "BillNo")
            Dim admissionNo As String = StringEnteredIn(row, "AdmissionNo")

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbAdmissionNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbAdmissionStatus.Text = StringEnteredIn(row, "AdmissionStatus")
            Me.stbBillNo.Text = FormatText(billNo, "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            doctorStaffNo = StringMayBeEnteredIn(row, "StaffNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            provisionalIPDDiagnosis = StringMayBeEnteredIn(row, "ProvisionalIPDDiagnosis")
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "RoundDateTime"))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPharmacist.Text = oStaff.GetCurrentStaffFullName
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnAddConsumables.Enabled = True
            Security.Apply(Me.btnAddConsumables, AccessRights.Write)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDate As Date = DateEnteredIn(row, "RoundDateTime")
            Me.dtpIssueDate.Value = roundDate
            Me.dtpIssueDate.Checked = GetShortDate(roundDate) >= GetShortDate(Today.AddHours(-12))

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

    Private Sub LoadDrugsToIssue(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvPrescription.Rows.Clear()
            If String.IsNullOrEmpty(roundNo) Then Return

            Dim drugsToIssue As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Drug, oItemStatusID.Pending).Tables("IPDItems")

            If drugsToIssue Is Nothing OrElse drugsToIssue.Rows.Count < 1 Then

                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
                Dim message As String = "This visit has no pending prescription!"

                If String.IsNullOrEmpty(billMode) Then Return
                DisplayMessage(message)
                Return

            End If

            For pos As Integer = 0 To drugsToIssue.Rows.Count - 1

                Dim row As DataRow = drugsToIssue.Rows(pos)

                Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvPrescription

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colDrugNo.Name, pos).Value = drugNo
                    .Item(Me.colDrugName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "PayStatus")
                    Me.ShowDrugDetails(drugNo, pos)

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculatePrescriptionTotalBill()
            Me.DetailDrugLocationBalance()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadConsumables(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumables As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Consumable).Tables("IPDItems")
            If consumables Is Nothing OrElse consumables.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, consumables)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesTotalBill()
            Me.CalculateGrandTotalAmount()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadDiagnosis(ByVal roundNo As String)

        Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosis As DataTable = oIPDDiagnosis.GetIPDDiagnosis(roundNo).Tables("IPDDiagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDiagnosis, diagnosis)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

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

#Region " IPDAlerts "

    Private Function ShowSentConsumableIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Consumable).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlertsConsumables.Text = "Sent IPD Consumables: " + iPDAlertsNo.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Prescription).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Doctor Prescription: " + iPDAlertsNo.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iPDAlertsStartDateTime = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return iPDAlertsNo

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToOrderDrugs()
            Me.lblToOrderDrugs.Text = "To Order Drugs: " + records.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oDrugs.CountToExpireDrugs(oVariousOptions.ExpiryWarningDays)
            Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: " + records.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Prescription, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowDispensingData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewToOrderDrugsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToOrderDrugsList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim fToOrderDrugs As New frmToOrderItems(ItemsTo.Order, oItemCategoryID.Drug, False)
        fToOrderDrugs.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowToOrderDrugs()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewToExpireDrugsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToExpireDrugsList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim fToOrderDrugs As New frmToOrderItems(ItemsTo.Expire, oItemCategoryID.Drug, False)
        fToOrderDrugs.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowToExpireDrugs()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If iPDAlerts Is Nothing OrElse iPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = iPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts _
                                        Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) _
                                        And GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime)) _
                                        Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tmrIPDAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrIPDAlerts.Tick

        Try

            Dim period As Long = DateDiff(DateInterval.Minute, iPDAlertsStartDateTime, Now)
            If period >= InitOptions.AlertCheckPeriod Then
                If Me.ShowSentIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
                If Me.ShowSentConsumableIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()

            End If

        Catch eX As Exception
            Return

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
                    Me.btnEdit.Visible = True
                    Me.pnlNavigateRounds.Visible = True
                    Me.btnPrint.Visible = True

                Case Me.tpgConsumables.Name

                    Me.pnlPrintPrescription.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnAddConsumables.Visible = True
                    Me.btnEdit.Visible = False
                    Me.pnlNavigateRounds.Visible = False
                    Me.btnPrint.Visible = False

                Case Me.tpgDiagnosis.Name

                    Me.pnlPrintPrescription.Visible = False
                    Me.btnSave.Visible = False
                    Me.btnAddConsumables.Visible = False
                    Me.btnEdit.Visible = False
                    Me.pnlNavigateRounds.Visible = False
                    Me.btnPrint.Visible = False

                Case Else

                    Me.pnlPrintPrescription.Visible = True
                    Me.btnSave.Visible = True
                    Me.btnAddConsumables.Visible = True
                    Me.btnEdit.Visible = True
                    Me.pnlNavigateRounds.Visible = True
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()
         Dim oVariousOptions As New VariousOptions()

        Dim lIPDItems As New List(Of DBConnect)
        Dim lIPDItemsEXT As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim message As String
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Dim issueDate As Date = DateEnteredIn(Me.dtpIssueDate, "Issue Date!")
            Dim pharmacist As String = SubstringEnteredIn(Me.cboPharmacist, "Pharmacist (Staff)!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must register at least one entry for drugs " +
                                                ControlChars.NewLine + "If this is a cash patient, ensure that payment is done first!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
            'Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            'Dim admissionStatus As String = StringMayBeEnteredIn(Me.stbAdmissionStatus)
            'Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            'Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)
            'Dim dischargedAdmissionStatus As String = GetLookupDataDes(oAdmissionStatusID.Discharged)

            'If Not oVariousOptions.AllowAccessCashServices AndAlso Not accessCashServices AndAlso
            '    billMode.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
            '    admissionStatus.ToUpper().Equals(dischargedAdmissionStatus.ToUpper()) Then

            '    Dim cashNotPaid As Boolean = False
            '    For Each row As DataGridViewRow In Me.dgvPrescription.Rows
            '        If row.IsNewRow Then Exit For
            '        If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
            '            Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
            '            If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) Then
            '                cashNotPaid = True
            '                Exit For
            '            End If
            '        End If
            '        cashNotPaid = False
            '    Next

            '    If cashNotPaid Then Throw New ArgumentException("The system does not allow dispensing of not paid for drug(s) for a discharged cash visit!")

            'End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim lExtraBills As New List(Of DBConnect)
            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            Dim billHeaderTransactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



            With oExtraBills

                .VisitNo = visitNo
                .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                .ExtraBillDate = DateEnteredIn(Me.stbRoundDateTime, "Extra Bill Date!")
                .StaffNo = doctorStaffNo
                .LoginID = CurrentUser.LoginID

            End With

            lExtraBills.Add(oExtraBills)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(extraBillNo) Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                With oExtraBillsEXT
                    .ExtraBillNo = oExtraBills.ExtraBillNo
                    .RoundNo = roundNo
                End With

                lExtraBillsEXT.Add(oExtraBillsEXT)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBillsEXT, Action.Save))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                extraBillNo = oExtraBills.ExtraBillNo
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DoTransactions(billHeaderTransactions)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

           


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    Dim drugNo As String = StringEnteredIn(cells, Me.colDrugNo, "drug!")
                    Dim drugName As String = StringEnteredIn(cells, Me.colDrugName, "drug name!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                    Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasAlternateDrugs)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowDispensingExpiredDrugs() Then
                            message = "Expiry date for " + drugName + " had reached. " +
                                "The system does not allow to dispence a drug that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + drugName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .LastUpdate = issueDate
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Offered

                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using

                    Using oIPDItemsEXT As New SyncSoft.SQLDb.IPDItemsEXT()
                        With oIPDItemsEXT

                            .RoundNo = roundNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Pharmacist = pharmacist
                            .LocationID = locationID
                            .LoginID = CurrentUser.LoginID

                        End With
                        lIPDItemsEXT.Add(oIPDItemsEXT)
                    End Using

                    Using oInventory As New SyncSoft.SQLDb.Inventory()
                        With oInventory
                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = drugNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = quantity
                            .Details = "Drug(s) Issued to Round No: " + roundNo
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = String.Empty
                            .ExpiryDate = AppData.NullDateValue
                        End With
                        lInventory.Add(oInventory)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)

                    Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice, True)
                    Dim dosage As String = cells.Item(Me.colDosage.Name).Value.ToString()
                    Dim duration As String = cells.Item(Me.colDuration.Name).Value.ToString()

                    Dim fullDosage As String
                    If duration.Trim().Equals("1") Then
                        fullDosage = dosage + " for " + duration + " day, drug issued to Patient No: " + patientNo + " and Round No: " + roundNo
                    Else : fullDosage = dosage + " for " + duration + " days, drugs issued to Patient No: " + patientNo + " and Round No: " + roundNo
                    End If

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = drugNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = fullDosage
                            .LastUpdate = issueDate
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
                    Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = drugNo
                                .ItemCategoryID = oItemCategoryID.Drug
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If
                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItemsEXT, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

            DoTransactions(transactions)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If GetLookupDataDes(oVisitCategoryID.Refill).Equals(Me.stbVisitCategory.Text.Trim()) Then Me.SaveNextAppointment()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkPrintDrugBarcode.Checked Then Me.PrintDrugBarcodes()
            If Me.chkPrintPrescriptionOnSaving.Checked Then Me.PrintPrescription()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadDrugsToIssue(roundNo)
                    Exit For
                End If
                allSelected = True
            Next


            If dgvConsumables.RowCount > 0 Then
                message = "This Patient has Pending Consumables Would you like to issue them  now?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIssueConsumables As New frmIssueIPDConsumables(roundNo)
                    fIssueConsumables.ShowDialog()
                End If
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If allSelected Then
                Me.dgvPrescription.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlNavigateRounds)
                Me.ClearControls()
                Me.SetDefaultLocation()
                'Me.LoadToPharmacyVisits()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.chkPrintPrescriptionOnSaving.Checked = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()
            Me.ShowToOrderDrugs()
            Me.ShowSentConsumableIPDAlerts()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " Prescription - Grid "

    Private Sub CalculatePrescriptionAmount()

        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colUnitPrice)

        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculatePrescriptionTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForPrescription.Clear()

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

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        If e.ColumnIndex.Equals(Me.colInclude.Index) OrElse e.ColumnIndex.Equals(Me.colQuantity.Index) _
                               OrElse e.ColumnIndex.Equals(Me.colUnitPrice.Index) Then
            Me.CalculatePrescriptionAmount()
            Me.CalculatePrescriptionTotalBill()
        End If

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

        Dim refillDuration As Integer = 0
        Dim oNextAppointment As New NextAppointment()
        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
        Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()

        Try

            Dim appointmentMSG As String = "It’s recommended that you schedule an appointment for the next refill date." +
                ControlChars.NewLine + "Would you like to schedule next refill appointment now?"

            Dim issueDate As Date = Me.dtpIssueDate.Value
            Dim visitNo As String = RevertText(Me.stbVisitNo.Text.Trim())
            If IsNumeric(Me.stbRefillDuration.Text.Trim()) Then refillDuration = CInt(Me.stbRefillDuration.Text.Trim())
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

            Me.PrintPrescription()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintPrescription()
        'xaxa()
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

            'xaxaxa()
            Select Case pharmacyPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetPrescriptionPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docPrescription
                    'dlgPrint.AllowPrintToFile = True
                    'dlgPrint.AllowSelection = True
                    'dlgPrint.AllowSomePages = True
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docPrescription.Print()

                Case String.Empty

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetPrescriptionPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docPrescription
                    'dlgPrint.AllowPrintToFile = True
                    'dlgPrint.AllowSelection = True
                    'dlgPrint.AllowSomePages = True
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docPrescription.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintPharmacyThermalReceipt()

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

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Prescription".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim attendingDoctor As String = StringMayBeEnteredIn(Me.stbAttendingDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 6 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst
                Dim widthTopFourth As Single = 20 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
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
                    .DrawString(attendingDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
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

            ElseIf String.IsNullOrEmpty(provisionalIPDDiagnosis) Then
                Dim diagnosisEmptyData As New System.Text.StringBuilder(String.Empty)
                diagnosisEmptyData.Append(ControlChars.NewLine)
                diagnosisEmptyData.Append(GetSpaces(10))
                diagnosisEmptyData.Append(GetCharacters("."c, 62))
                diagnosisEmptyData.Append(ControlChars.NewLine)
                prescriptionParagraphs.Add(New PrintParagraps(footerFont, diagnosisEmptyData.ToString()))
            Else : prescriptionParagraphs.Add(New PrintParagraps(bodyNormalFont, provisionalIPDDiagnosis))
            End If

            ''''''''''''''''PRESCRIPTION'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("PRESCRIPTION: ".ToUpper())
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
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

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrugName)
                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)
                    Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)

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
                    tableData.Append(itemName.PadRight(padItemName))
                    tableData.Append(GetSpaces(2))

                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
                    If wrappedfullDosage.Count > 1 Then
                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo + padItemName + 2))
                        Next
                    Else
                        tableData.Append(FixDataLength(fullDosage, padFullDosage))
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "PHARMACY THERMAL RECEIPT PRINTOUT"

    'Private Sub PrintPharmacyThermalReceipt()

    '    Dim dlgPrint As New PrintDialog()

    '    Try

    '        Me.Cursor = Cursors.WaitCursor

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for lab request!")

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Dim nonSelected As Boolean = False

    '        For Each row As DataGridViewRow In Me.dgvPrescription.Rows
    '            If row.IsNewRow Then Exit For
    '            If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, row.Index).Value) = True Then
    '                nonSelected = False
    '                Exit For
    '            End If
    '            nonSelected = True
    '        Next

    '        If nonSelected Then Throw New ArgumentException("Must include at least one entry for lab request!")

    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Me.SetPharmacyThermalReceiptPrintData()
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        dlgPrint.Document = docPharmacyThermalReceipt
    '        'dlgPrint.AllowPrintToFile = True
    '        'dlgPrint.AllowSelection = True
    '        'dlgPrint.AllowSomePages = True
    '        dlgPrint.Document.PrinterSettings.Collate = True
    '        If dlgPrint.ShowDialog = DialogResult.OK Then docPharmacyThermalReceipt.Print()

    '    Catch ex As Exception
    '        Throw ex

    '    End Try

    'End Sub

    'Private Sub docPharmacyThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPharmacyThermalReceipt.PrintPage

    '    Try

    '        Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

    '        Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
    '        Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

    '        Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

    '        'Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "IPD Pharmacy Prescription".ToUpper()
    '        Dim title As String = AppData.ProductOwner.ToUpper()

    '        Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
    '        Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
    '        Dim RoundNo As String = StringMayBeEnteredIn(Me.stbRoundNo)
    '        Dim RoundDateTime As String = StringMayBeEnteredIn(Me.stbRoundDateTime)
    '        Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
    '        Dim BillCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)


    '        ' Increment the page number.
    '        pageNo += 1

    '        With e.Graphics

    '            Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
    '            Dim widthTopSecond As Single = 9 * widthTopFirst
    '            Dim widthTopThird As Single = 11 * widthTopFirst

    '            If pageNo < 2 Then

    '                '.DrawString(title, titleFont, Brushes.Black, xPos, yPos)
    '                'yPos += 3 * lineHeight
    '                If (title.Length > 25) Then
    '                    .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
    '                    yPos += lineHeight
    '                    .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
    '                    yPos += lineHeight
    '                    .DrawString("IPD Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
    '                    yPos += 3 * lineHeight
    '                Else
    '                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
    '                    yPos += lineHeight
    '                    .DrawString("Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
    '                    yPos += 3 * lineHeight
    '                End If

    '                '.DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                '.DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                'yPos += lineHeight
    '                If (fullName.Length > 14) Then
    '                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight
    '                    .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight
    '                Else
    '                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight
    '                End If

    '                .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                yPos += lineHeight

    '                .DrawString("Round No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                .DrawString(RoundNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                yPos += lineHeight

    '                .DrawString("RoundDateTime: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                .DrawString(RoundDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                yPos += lineHeight

    '                .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                yPos += lineHeight

    '                '.DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                '.DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                'yPos += 2 * lineHeight
    '                If (BillCustomerName.Length > 14) Then
    '                    .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(BillCustomerName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += lineHeight
    '                    .DrawString(BillCustomerName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += 2 * lineHeight
    '                Else
    '                    .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
    '                    .DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
    '                    yPos += 2 * lineHeight
    '                End If

    '            End If

    '            Dim _StringFormat As New StringFormat()

    '            ' Draw the rest of the text left justified,
    '            ' wrap at words, and don't draw partial lines.

    '            With _StringFormat
    '                .Alignment = StringAlignment.Near
    '                .FormatFlags = StringFormatFlags.LineLimit
    '                .Trimming = StringTrimming.Word
    '            End With

    '            Dim charactersFitted As Integer
    '            Dim linesFilled As Integer

    '            If PharmacyThermalReceiptParagraphs Is Nothing Then Return

    '            Do While PharmacyThermalReceiptParagraphs.Count > 0

    '                ' Print the next paragraph.
    '                Dim oPrintParagraps As PrintParagraps = DirectCast(PharmacyThermalReceiptParagraphs(1), PrintParagraps)
    '                PharmacyThermalReceiptParagraphs.Remove(1)

    '                ' Get the area available for this paragraph.
    '                Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

    '                ' If the printing area rectangle's height < 1, make it 1.
    '                If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

    '                ' See how big the text will be and how many characters will fit.
    '                Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
    '                    New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

    '                ' See if any characters will fit.
    '                If charactersFitted > 0 Then
    '                    ' Draw the text.
    '                    .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
    '                    ' Increase the location where we can start, add a little interparagraph spacing.
    '                    yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

    '                End If

    '                ' See if some of the paragraph didn't fit on the page.
    '                If charactersFitted < oPrintParagraps.Text.Length Then
    '                    ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
    '                    oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
    '                    PharmacyThermalReceiptParagraphs.Add(oPrintParagraps, Before:=1)
    '                    Exit Do
    '                End If
    '            Loop

    '            ' If we have more paragraphs, we have more pages.
    '            e.HasMorePages = (PharmacyThermalReceiptParagraphs.Count > 0)

    '        End With

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub

    'Private Sub SetPharmacyThermalReceiptPrintData()

    '    Dim padItemNo As Integer = 4
    '    Dim padItemName As Integer = 16
    '    Dim padQuantity As Integer = 8
    '    Dim padIAmount As Integer = 10


    '    Dim footerFont As New Font(printFontName, 9)

    '    pageNo = 0
    '    PharmacyThermalReceiptParagraphs = New Collection()

    '    Try

    '        Dim tableHeader As New System.Text.StringBuilder(String.Empty)
    '        tableHeader.Append("No: ".PadRight(padItemNo))
    '        tableHeader.Append("Item: ".PadRight(padItemName))
    '        'tableHeader.Append(ControlChars.NewLine)
    '        tableHeader.Append("Qty: ".PadRight(padQuantity))
    '        'tableHeader.Append(ControlChars.NewLine)
    '        tableHeader.Append("Amt: ".PadRight(padIAmount))
    '        tableHeader.Append(ControlChars.NewLine)
    '        tableHeader.Append(ControlChars.NewLine)
    '        'PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

    '        Dim count As Integer
    '        Dim tableData As New System.Text.StringBuilder(String.Empty)
    '        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

    '            If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

    '                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

    '                count += 1

    '                Dim itemNo As String = (count).ToString()
    '                Dim DrugName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
    '                'Dim itemQuantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
    '                'Dim itemAmount As String = cells.Item(Me.colAmount.Name).Value.ToString()
    '                Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
    '                Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)
    '                Dim notes As String = StringMayBeEnteredIn(cells, Me.colFormula)


    '                Dim fullDosage As String
    '                If String.IsNullOrEmpty(notes) Then
    '                    If duration.Trim().Equals("0") Then
    '                        fullDosage = dosage
    '                    ElseIf duration.Trim().Equals("1") Then
    '                        fullDosage = dosage + " for " + duration + " day"
    '                    Else : fullDosage = dosage + " for " + duration + " days"
    '                    End If
    '                Else
    '                    If duration.Trim().Equals("0") Then
    '                        fullDosage = dosage + " (" + notes + ")"
    '                    ElseIf duration.Trim().Equals("1") Then
    '                        fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
    '                    Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
    '                    End If
    '                End If


    '                tableData.Append(itemNo.PadRight(padItemNo))
    '                tableData.Append(DrugName.PadRight(padItemName))
    '                tableData.Append(ControlChars.NewLine)
    '                'tableData.Append("Quantity: ".PadRight(padQuantity))
    '                'tableData.Append(itemQuantity.PadRight(padItemNo))
    '                'tableData.Append(ControlChars.NewLine)
    '                'tableData.Append("Amount: ".PadRight(padIAmount))
    '                'tableData.Append(itemAmount.PadRight(padItemName))
    '                Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
    '                If wrappedfullDosage.Count > 1 Then
    '                    For pos As Integer = 0 To wrappedfullDosage.Count - 1
    '                        tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
    '                        tableData.Append(ControlChars.NewLine)
    '                        tableData.Append(GetSpaces(padItemNo + padItemName + 2))
    '                    Next
    '                Else
    '                    tableData.Append(GetSpaces(padItemNo))
    '                    tableData.Append(FixDataLength(fullDosage, padFullDosage))
    '                End If
    '                tableData.Append(ControlChars.NewLine)


    '            End If
    '        Next

    '        PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

    '        Dim footerData As New System.Text.StringBuilder(String.Empty)
    '        footerData.Append(ControlChars.NewLine)
    '        'footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
    '        '                    " from " + AppData.AppTitle)
    '        footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now))
    '        footerData.Append(ControlChars.NewLine)
    '        footerData.Append("at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
    '        footerData.Append(ControlChars.NewLine)
    '        PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Sub
    Private Sub PrintPharmacyThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for lab request!")

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

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetPharmacyThermalReceiptPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docPharmacyThermalReceipt
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docPharmacyThermalReceipt.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docPharmacyThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docPharmacyThermalReceipt.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            'Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "IPD Pharmacy Prescription".ToUpper()
            Dim title As String = AppData.ProductOwner.ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim RoundNo As String = StringMayBeEnteredIn(Me.stbRoundNo)
            Dim RoundDateTime As String = StringMayBeEnteredIn(Me.stbRoundDateTime)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim BillCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)


            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                    '.DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    'yPos += 3 * lineHeight
                    If (title.Length > 25) Then
                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("IPD Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Pharmacy Prescription".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    End If

                    '.DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    '.DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    'yPos += lineHeight
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

                    .DrawString("Round No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(RoundNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("RoundDateTime: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(RoundDateTime, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    '.DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    '.DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    'yPos += 2 * lineHeight
                    If (BillCustomerName.Length > 14) Then
                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(BillCustomerName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight
                    Else
                        .DrawString("Bill Customer: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(BillCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += 2 * lineHeight
                    End If

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

                If PharmacyThermalReceiptParagraphs Is Nothing Then Return

                Do While PharmacyThermalReceiptParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(PharmacyThermalReceiptParagraphs(1), PrintParagraps)
                    PharmacyThermalReceiptParagraphs.Remove(1)

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
                        PharmacyThermalReceiptParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (PharmacyThermalReceiptParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetPharmacyThermalReceiptPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        PharmacyThermalReceiptParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item: ".PadRight(padItemName))
            'tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("Qty: ".PadRight(padQuantity))
            'tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append("Amt: ".PadRight(padIAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            'PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim DrugName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
                    'Dim itemQuantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                    'Dim itemAmount As String = cells.Item(Me.colAmount.Name).Value.ToString()
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
                    tableData.Append(ControlChars.NewLine)
                    'tableData.Append("Quantity: ".PadRight(padQuantity))
                    'tableData.Append(itemQuantity.PadRight(padItemNo))
                    'tableData.Append(ControlChars.NewLine)
                    'tableData.Append("Amount: ".PadRight(padIAmount))
                    'tableData.Append(itemAmount.PadRight(padItemName))
                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padFullDosage)
                    If wrappedfullDosage.Count > 1 Then
                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padFullDosage))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo + padItemName + 2))
                        Next
                    Else
                        tableData.Append(GetSpaces(padItemNo))
                        tableData.Append(FixDataLength(fullDosage, padFullDosage))
                    End If
                    tableData.Append(ControlChars.NewLine)


                End If
            Next

            PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            'footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
            '                    " from " + AppData.AppTitle)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now))
            footerData.Append(ControlChars.NewLine)
            footerData.Append("at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            PharmacyThermalReceiptParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region

#Region " Rounds Navigate "

    Private Sub EnableNavigateRoundsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
                Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
                Dim iPDDoctor As DataTable = oIPDDoctor.GetIPDDoctorByAdmissionNoNavigate(admissionNo).Tables("IPDDoctor")

                For pos As Integer = 0 To iPDDoctor.Rows.Count - 1
                    If roundNo.ToUpper().Equals(iPDDoctor.Rows(pos).Item("RoundNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navRounds.DataSource = iPDDoctor
                Me.navRounds.Navigate(startPosition)

            Else : Me.navRounds.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateRounds.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateRounds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateRounds.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navRounds.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(currentValue.ToString())
            If String.IsNullOrEmpty(roundNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadDrugsData(roundNo)
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
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))

            Dim fIPDDoctorPrescription As New frmIPDDoctorPrescription(roundNo)
            fIPDDoctorPrescription.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugsData(roundNo)
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
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Me.LoadDrugsData(roundNo)
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


    Private Function GetInvoiceDetails(invoiceNo As String, extraBillNo As String) As List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)
        Dim itemCategoryID As String = oItemCategoryID.Drug()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            If CBool(Me.dgvPrescription.Item(Me.colInclude.Name, rowNo).Value) = True Then

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo, "drug no!")
                Dim drugName As String = StringEnteredIn(cells, Me.colDrugName, "drug name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")


                Using oInvoiceDetails As New SyncSoft.SQLDb.InvoiceExtraBillItems()

                    If oVariousOptions.GenerateInventoryInvoiceOnDispensingOnly() Then
                        With oInvoiceDetails
                            .InvoiceNo = invoiceNo
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .Quantity = quantity

                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, True, "unit price!")
                            Else : .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                            End If
                            .Discount = 0
                            If itemCategoryID.ToUpper().Equals(oItemCategoryID.Extras.ToUpper()) AndAlso
                                  (itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())) Then
                                .Amount = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")
                            Else : .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")
                            End If


                        End With


                        lInvoiceDetails.Add(oInvoiceDetails)

                    End If
                End Using
            End If
        Next

        Return lInvoiceDetails
    End Function

    Private Sub btnIPDConsumables_Click(sender As System.Object, e As System.EventArgs) Handles btnIPDConsumables.Click
        Me.ShowSentConsumableIPDAlerts()
        frmIssueIPDConsumables.ShowDialog()
    End Sub

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

    Private Sub GenerateBarcode()
        Try
            Dim imageweight As Integer = 2
            'Barcode using the GenCode128
            If Not String.IsNullOrEmpty(stbRoundNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(RevertText(stbRoundNo.Text.ToString()), Integer.Parse(imageweight.ToString()), True)
                imgIDAutomation.Image = barcodeImage

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
            e.Graphics.DrawString(RevertText(stbRoundNo.Text.ToString()), printFont10_Normal, Brushes.Black, rect, sf)
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

End Class