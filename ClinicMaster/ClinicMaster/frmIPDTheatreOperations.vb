
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
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmIPDTheatreOperations

#Region " Fields "

    Private currentAllSaved As Boolean = True
    Private currentRoundNo As String = String.Empty
    Private theatreReportSaved As Boolean = False
    Private iPDAlerts As DataTable
    Private iPDAlertsStartDateTime As Date = Now

    Private procedures As DataTable
    Private diseases As DataTable
    Private theatreServices As DataTable
    Private consumableItems As DataTable
    Private _ConsumableItemValue As String = String.Empty

    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private attendingStaffNo As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty

    Private WithEvents docTheatreReport As New PrintDocument()

    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private theatreReportParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private hasPackage As Boolean = False
    Private patientpackageNo As String = String.Empty

#End Region

#Region " Validations "

    Private Sub dtpOperationDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpOperationDateTime.Validating

        Dim errorMSG As String = "Operation date can't be before round date!"

        Try

            Dim roundDate As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            Dim operationDate As Date = DateMayBeEnteredIn(Me.dtpOperationDateTime)

            If operationDate = AppData.NullDateValue Then Return

            If operationDate < roundDate Then
                ErrProvider.SetError(Me.dtpOperationDateTime, errorMSG)
                Me.dtpOperationDateTime.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpOperationDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmIPDTheatreOperations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.LoadConsumableItems()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboAnaesthesiaTypeID, LookupObjects.AnaesthesiaType, False)
            LoadLookupDataCombo(Me.cboOperationClassID, LookupObjects.OperationClass, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLeadSurgeon()
            Me.LoadLeadAnaesthetist()
            Me.LoadLeadNurse()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDiseases()
            Me.LoadProcedures()
            Me.LoadTheatreServices()
            Me.LoadDrugs()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()
            Me.ShowSentTheatreIPDAlerts()
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrIPDAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmIPDTheatreOperations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmIPDTheatreOperations_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try

            If Not Me.AllSaved() Then
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then e.Cancel = True
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbRoundNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRoundNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentRoundNo = StringMayBeEnteredIn(Me.stbRoundNo)
                ProcessTabKey(True)
            Else : currentRoundNo = String.Empty
            End If

        Catch ex As Exception
            currentRoundNo = String.Empty
        End Try

    End Sub

    Private Sub stbRoundNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbRoundNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub stbRoundNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRoundNo.TextChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
            Me.stbRoundNo.Text = currentRoundNo
            Return
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbRoundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRoundNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.stbRoundNo.Text = currentRoundNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Me.LoadTheatreOperationsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadPendingProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingProcedures.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.Procedure)
            fPendingIPDItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Me.LoadTheatreOperationsData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim roundNo As String = oIPDDoctor.GetRoundNo(admissionNo, Nothing)
            Me.stbRoundNo.Text = FormatText(roundNo, "IPDDoctor", "RoundNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadTheatreOperationsData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        End Try

    End Sub

    Private Sub btnFindRoundNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindRoundNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindRoundNo As New frmFindAutoNo(Me.stbRoundNo, AutoNumber.RoundNo)
        fFindRoundNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        Me.LoadTheatreOperationsData(roundNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub LoadLeadSurgeon()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadSurgeon, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLeadAnaesthetist()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Anaesthetist).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadAnaesthetist, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLeadNurse()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Nurse).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadNurse, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            If Not InitOptions.LoadDiseasesAtStart Then
                diseases = oDiseases.GetDiseases().Tables("Diseases")
                oSetupData.Diseases = diseases
            Else : diseases = oSetupData.Diseases
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDiseaseCode.Sorted = False
            LoadComboData(Me.colDiseaseCode, diseases, "DiseaseCode", "DiseaseName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProcedures()

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Procedures
            If Not InitOptions.LoadProceduresAtStart Then
                procedures = oProcedures.GetProcedures().Tables("Procedures")
                oSetupData.Procedures = procedures
            Else : procedures = oSetupData.Procedures
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugs()

        Dim drugs As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colDrug, drugs, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbVisitDate.Clear()
        Me.stbVisitNo.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbPatientNo.Clear()
        Me.stbAdmissionStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        billModesID = String.Empty
        associatedBillNo = String.Empty
        attendingStaffNo = String.Empty
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        patientpackageNo = String.Empty
        hasPackage = False
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgIPDDiagnosis)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgPrescriptions)

    End Sub

    Private Sub ResetControls()
        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlRoundNo)
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgIPDDiagnosis)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgPrescriptions)
    End Sub

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems
            consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colConsumableName, consumableItems, "ConsumableFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadTheatreOperationsData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                Me.LoadIPDDiagnosis(roundNo)

                Me.LoadProceduresToOffer(roundNo)

                If Not Me.LoadPossibleAttachedServices(roundNo) Then
                    Me.LoadTheatreToOffer(roundNo)
                End If
                If Not Me.LoadPossibleAttachedPrescribedDrugs(roundNo) Then
                    Me.LoadPrescriptions(roundNo)
                End If
                If Not Me.LoadPossibleAttachedConsumables(roundNo) Then
                    Me.LoadIPDConsumables(roundNo)
                End If
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

        Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.ClearControls()

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
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbAttendingDoctor.Text = StringMayBeEnteredIn(row, "AttendingDoctor")
            Me.stbRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "RoundDateTime"))
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            attendingStaffNo = StringMayBeEnteredIn(row, "StaffNo")
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateTimeEnteredIn(row, "RoundDateTime")
            Me.dtpOperationDateTime.Value = roundDateTime
            Me.dtpOperationDateTime.Checked = GetShortDate(roundDateTime) >= GetShortDate(Now.AddHours(-12))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProceduresToOffer(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvProcedures.Rows.Clear()

            If String.IsNullOrEmpty(roundNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proceduresToOffer As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Procedure, oItemStatusID.Pending).Tables("IPDItems")
            If proceduresToOffer Is Nothing OrElse proceduresToOffer.Rows.Count < 1 Then Throw New ArgumentException("This visit has no pending procedure(s)!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To proceduresToOffer.Rows.Count - 1

                Dim row As DataRow = proceduresToOffer.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvProcedures

                    .Rows.Add()
                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureQuantity.Name, pos).Value = quantity
                    .Item(Me.colProcedureUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colProcedureAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colProcedureItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colProcedurePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colProceduresSaved.Name, pos).Value = True

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function LoadTheatreToOffer(ByVal roundNo As String) As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oItems As New SyncSoft.SQLDb.IPDItems

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvTheatre.Rows.Clear()

            If String.IsNullOrEmpty(roundNo) Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreToOffer As DataTable = oItems.GetIPDItems(roundNo, oItemCategoryID.Theatre, oItemStatusID.Pending).Tables("IPDItems")
            If theatreToOffer Is Nothing OrElse theatreToOffer.Rows.Count < 1 Then Throw New ArgumentException("This visit has no pending theatre service(s)!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatreToOffer.Rows.Count - 1

                Dim row As DataRow = theatreToOffer.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvTheatre

                    .Rows.Add()
                    .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = quantity
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colTheatrePayStatusID.Name, pos).Value = StringEnteredIn(row, "PayStatusID")
                    .Item(Me.colTheatreSaved.Name, pos).Value = True

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
            Return True

        Catch ex As Exception
            Return False
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function LoadPossibleAttachedConsumables(ByVal roundNo As String) As Boolean

        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()


        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items attached to the consumables
            Dim consumableItems As DataTable = oPossibleAttachedItems.GetIPDAttachedPossibleCosumablesOnLoad(roundNo).Tables("PossibleAttachedItems")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To consumableItems.Rows.Count - 1

                Dim row As DataRow = consumableItems.Rows(pos)

                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()
                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim consumableNo As String = (StringEnteredIn(row, "ItemCode"))
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)
                    Dim amount As Decimal = quantity * unitPrice

                    .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumableItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablePayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablePayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ConsumableFullName")
                    .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colConsumablesSaved.Name, pos).Value = False
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            Return False
            Throw ex

        End Try

    End Function

    Private Function LoadPossibleAttachedServices(ByVal roundNo As String) As Boolean
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load thearte services attached to the procedures
            Dim theatreSevices As DataTable = oPossibleAttachedItems.GetAttachedIPDPossibleTheatreServicesOnLoad(roundNo).Tables("PossibleAttachedItems")

            If theatreSevices Is Nothing OrElse theatreSevices.Rows.Count < 1 Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatreSevices.Rows.Count - 1

                Dim row As DataRow = theatreSevices.Rows(pos)

                With Me.dgvTheatre

                    .Rows.Add()
                    Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                    Dim selectedItem As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim theatreServiceNo As String = StringEnteredIn(row, "ItemCode")
                    Dim unitPrice As Decimal = GetCustomFee(theatreServiceNo, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)
                    Dim amount As Decimal = quantity * unitPrice
                    .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = quantity
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                        .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colTheatrePayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colTheatrePayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If

                    .Item(Me.colTheatreSaved.Name, pos).Value = False

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            Return False
            Throw ex

        End Try

    End Function

    Private Function LoadPossibleAttachedPrescribedDrugs(ByVal roundNo As String) As Boolean
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try
            Me.dgvPrescription.Rows.Clear()

            ' Load thearte services attached to the procedures
            Dim prescribedDrugs As DataTable = oPossibleAttachedItems.GetIPDAttachedPossiblePrescriptionsOnLoad(roundNo).Tables("PossibleAttachedItems")
            'Dim selectedRow As Integer

            If prescribedDrugs Is Nothing OrElse prescribedDrugs.Rows.Count < 1 Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To prescribedDrugs.Rows.Count - 1

                Dim row As DataRow = prescribedDrugs.Rows(pos)

                With Me.dgvPrescription

                    .Rows.Add()

                    Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

                    Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
                    Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                    Dim amount As Decimal = quantity * unitPrice
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "DrugFullName")
                    .Item(Me.colDosage.Name, pos).Value = StringEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = StringEnteredIn(row, "Duration")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDrugQuantity.Name, pos).Value = quantity
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                        .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If

                    .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPrescriptions()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            Return False
            Throw ex

        End Try

    End Function

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oIPDTheatreOperations As New SyncSoft.SQLDb.IPDTheatreOperations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oIPDTheatreOperations.RoundNo = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            DisplayMessage(oIPDTheatreOperations.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ResetControls()
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oIPDTheatreOperations As New SyncSoft.SQLDb.IPDTheatreOperations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!")))
            Dim dataSource As DataTable = oIPDTheatreOperations.GetIPDTheatreOperations(roundNo).Tables("IPDTheatreOperations")
            Me.DisplayData(dataSource)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadIPDDiagnosis(roundNo)
            Me.LoadProcedures(roundNo)
            Me.LoadTheatre(roundNo)
            Me.LoadPrescriptions(roundNo)
            Me.LoadIPDConsumables(roundNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundDateTime As Date = DateMayBeEnteredIn(Me.stbRoundDateTime)
            If roundDateTime = AppData.NullDateValue Then Return
            Me.DeleteIPDAlerts(roundNo, roundDateTime)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Select Case Me.tbcIPDTheatreOperations.SelectedTab.Name

                        Case Me.tpgGeneral.Name
                            Me.SaveTheatreOperations()

                        Case Me.tpgConsumables.Name
                            Me.VerifyConsumableEntries()
                            Me.SaveConsumables()

                        Case Me.tpgIPDDiagnosis.Name
                            Me.VerifyIPDDiagnosisEntries()
                            Me.SaveIPDDiagnosis()

                        Case Me.tpgPrescriptions.Name
                            Me.VerifyPrescriptionsEntries()
                            Me.SavePrescriptions()

                        Case Me.tpgProcedures.Name
                            Me.VerifyProceduresEntries()
                            Me.SaveProcedures()

                        Case Me.tpgTheatre.Name
                            Me.VerifyTheatreEntries()
                            Me.SaveTheatre()


                    End Select


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Me.ResetControls()
                    ' Me.tbcTheatreOperations.SelectTab(Me.tpgGeneral)
                    Me.ShowSentIPDAlerts()
                    Me.ShowSentTheatreIPDAlerts()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Select Case Me.tbcIPDTheatreOperations.SelectedTab.Name
                        Case Me.tpgGeneral.Name
                            Me.UpdateTheatreOperations()

                        Case Me.tpgConsumables.Name
                            Me.VerifyConsumableEntries()
                            Me.SaveConsumables()

                        Case Me.tpgIPDDiagnosis.Name
                            Me.VerifyIPDDiagnosisEntries()
                            Me.SaveIPDDiagnosis()

                        Case Me.tpgPrescriptions.Name
                            Me.VerifyPrescriptionsEntries()
                            Me.SavePrescriptions()


                        Case Me.tpgProcedures.Name
                            Me.VerifyProceduresEntries()
                            Me.SaveProcedures()

                        Case Me.tpgTheatre.Name
                            Me.VerifyTheatreEntries()
                            Me.SaveTheatre()


                    End Select

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub openConsumables()

        Dim oVariousOptions As New VariousOptions()
        Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Visit's No!"))

        If oVariousOptions.OpenIPDTheatreIssueConsumablesAfterPrescription Then

            Dim hasPendingItems As Boolean = False
            Dim Message As String = "Would you like to open issue IPD consumables now?"

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value) = True Then
                    Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableItemStatus)
                    If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                        hasPendingItems = True
                        Exit For
                    End If
                End If
                hasPendingItems = False
            Next

            If hasPendingItems AndAlso WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then
                Dim fIssueIPDConsumables As New frmIssueIPDConsumables(roundNo)
                fIssueIPDConsumables.ShowDialog()
                ' Me.LoadIPDConsumables(roundNo)
            End If

        End If
    End Sub

    Private Sub tbcIPDTheatreOperations_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcIPDTheatreOperations.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcIPDTheatreOperations.SelectedTab.Name

                Case Me.tpgGeneral.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgGeneral.Text
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgIPDDiagnosis.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgIPDDiagnosis.Text
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgProcedures.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgProcedures.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTheatre.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForTheatre()

                Case Me.tpgPrescriptions.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForPrescriptions()

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " IPDAlerts "

    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Procedure).Tables("IPDAlerts")
            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Doctor Procedure(s): " + iPDAlertsNo.ToString()
            iPDAlertsStartDateTime = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return iPDAlertsNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowSentTheatreIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Theatre).Tables("IPDAlerts")
            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblTheatreIPDAlerts.Text = "Theatre Service(s): " + iPDAlertsNo.ToString()
            iPDAlertsStartDateTime = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return iPDAlertsNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentIPDAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Procedure, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        Me.LoadTheatreOperationsData(roundNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewTheatreList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTheatreList.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentTheatreIPDAlerts()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Theatre, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
        Me.LoadTheatreOperationsData(roundNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DeleteIPDAlerts(ByVal roundNo As String, ByVal roundDateTime As Date)

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If iPDAlerts Is Nothing OrElse iPDAlerts.Rows.Count < 1 Then Return

            Dim miniIPDAlerts As EnumerableRowCollection(Of DataRow) = iPDAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniIPDAlerts
                                      Where data.Field(Of String)("RoundNo").ToUpper().Equals(roundNo.ToUpper()) And
                                      GetShortDate(data.Field(Of Date)("RoundDateTime")).Equals(GetShortDate(roundDateTime))
                                      Select data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oIPDAlerts.AlertID = alertID
            oIPDAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()
            Me.ShowSentTheatreIPDAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                If Me.ShowSentTheatreIPDAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region


    Private Function VerifyIPDDiagnosisEntries() As Boolean

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgIPDDiagnosis)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvIPDDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvIPDDiagnosis.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDiseaseCode)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgIPDDiagnosis)
            VerifyIPDDiagnosisEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveIPDDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lIPDDiagnosis As New List(Of DBConnect)
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvIPDDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvIPDDiagnosis.Rows(rowNo).Cells

                Try

                    Using oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()
                        With oIPDDiagnosis
                            .RoundNo = roundNo
                            .DiseaseCode = StringEnteredIn(cells, Me.colDiseaseCode)
                            .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lIPDDiagnosis.Add(oIPDDiagnosis)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDDiagnosis, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvIPDDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcIPDTheatreOperations.SelectTab(Me.tpgIPDDiagnosis)
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.dgvIPDDiagnosis.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyProceduresEntries() As Boolean

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgProcedures)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvProcedures.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for procedure!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "procedure!")
                IntegerEnteredIn(row.Cells, Me.colProcedureQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "unit price!")
                DecimalEnteredIn(row.Cells, Me.colProcedureAmount, False, "amount!")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "Procedure(s) will automatically be marked as done. You won’t be able to remove or make changes to any." +
                                    ControlChars.NewLine + "Are you sure you want to save?"
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgProcedures)
            VerifyProceduresEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveProcedures()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim operationDate As Date = DateEnteredIn(Me.dtpOperationDateTime, "Operation Date!")
            Dim staffNo As String = SubstringEnteredIn(Me.cboLeadSurgeon, "Lead Surgeon (Staff)!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            Dim lExtraBills As New List(Of DBConnect)
            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim billHeaderTransactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

                With oExtraBills

                    .VisitNo = visitNo
                    .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                    .ExtraBillDate = operationDate
                    .StaffNo = staffNo
                    .LoginID = CurrentUser.LoginID

                End With

                lExtraBills.Add(oExtraBills)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(extraBillNo) Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oExtraBillsEXT
                        .ExtraBillNo = oExtraBills.ExtraBillNo
                        .RoundNo = roundNo
                    End With

                    lExtraBillsEXT.Add(oExtraBillsEXT)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBillsEXT, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    extraBillNo = oExtraBills.ExtraBillNo
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(billHeaderTransactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colProcedureAmount, False, "amount!")
                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100

                Try

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim procedureName As String = (From data In _Procedures
                                                   Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper())
                                                   Select data.Field(Of String)("ProcedureName")).First()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then
                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()

                            With oIPDItems

                                .RoundNo = roundNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .LastUpdate = operationDate
                                .PayStatusID = String.Empty
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = oItemStatusID.Done

                            End With

                            lIPDItems.Add(oIPDItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                            With oIPDItems
                                .RoundNo = roundNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                                .LastUpdate = operationDate
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .ItemStatusID = oItemStatusID.Done
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                    .PayStatusID = oPayStatusID.NA
                                Else
                                    .PayStatusID = oPayStatusID.NotPaid
                                End If

                                .LoginID = CurrentUser.LoginID
                            End With

                            lIPDItems.Add(oIPDItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = "Procedure service: " + procedureName + ", done to Patient No: " + patientNo + " and Round No: " + roundNo
                            .LastUpdate = operationDate
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProcedureItemStatus.Name, rowNo).Value = GetLookupDataDes(oItemStatusID.Done)
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcIPDTheatreOperations.SelectTab(Me.tpgProcedures)
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvProcedures.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgProcedures)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyTheatreEntries() As Boolean

        Dim message As String

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgTheatre)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTheatre.RowCount <= 1 Then
                message = "You have not registered theatre service(s)" + ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "theatre service!")
                IntegerEnteredIn(row.Cells, Me.colTheatreQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "unit price!")
                DecimalEnteredIn(row.Cells, Me.colTheatreAmount, False, "amount!")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTheatre.RowCount > 1 Then
                message = "Theatre service(s) will automatically be marked as offered. You won’t be able to remove or make changes to any." +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgTheatre)
            VerifyTheatreEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveTheatreOperations()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.theatreReportSaved = False
            Dim oIPDTheatreOperations As New SyncSoft.SQLDb.IPDTheatreOperations()
            Dim lIPDTheatreOperations As New List(Of DBConnect)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgGeneral)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oIPDTheatreOperations

                .RoundNo = RevertText(StringEnteredIn(Me.stbRoundNo, "Visit's No!"))
                .OperationDateTime = DateTimeEnteredIn(Me.dtpOperationDateTime, "Operation Date Time!")
                .LeadSurgeon = SubstringEnteredIn(Me.cboLeadSurgeon, "Lead Surgeon (Staff)!")
                .OtherSurgeon = StringMayBeEnteredIn(Me.stbOtherSurgeon)
                .LeadAnaesthetist = SubstringEnteredIn(Me.cboLeadAnaesthetist, "Lead Anaesthetist (Staff)!")
                .OtherAnaesthetist = StringMayBeEnteredIn(Me.stbOtherAnaesthetist)
                .LeadNurse = SubstringEnteredIn(Me.cboLeadNurse, "Lead Nurse (Staff)!")
                .OtherNurse = StringMayBeEnteredIn(Me.stbOtherNurse)
                .AnaesthesiaTypeID = StringValueEnteredIn(Me.cboAnaesthesiaTypeID, "Anaesthesia Type!")
                .OperationClassID = StringValueEnteredIn(Me.cboOperationClassID, "Operation Class!")
                .PreoperativeDiagnosis = StringMayBeEnteredIn(Me.stbPreoperativeDiagnosis)
                .PlannedProcedures = StringMayBeEnteredIn(Me.stbPlannedProcedures)
                .PostoperativeInstructions = StringMayBeEnteredIn(Me.stbPostoperativeInstructions)
                .Report = StringEnteredIn(Me.stbReport, "Report!")
                .LoginID = CurrentUser.LoginID

           ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me)
            ValidateEntriesIn(Me, ErrProvider)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre Findings Successfully Saved!")

            End With
            Me.theatreReportSaved = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub UpdateTheatreOperations()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.theatreReportSaved = False
            Dim oIPDTheatreOperations As New SyncSoft.SQLDb.IPDTheatreOperations()
            Dim lIPDTheatreOperations As New List(Of DBConnect)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgGeneral)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oIPDTheatreOperations

                .RoundNo = RevertText(StringEnteredIn(Me.stbRoundNo, "Visit's No!"))
                .OperationDateTime = DateTimeEnteredIn(Me.dtpOperationDateTime, "Operation Date Time!")
                .LeadSurgeon = SubstringEnteredIn(Me.cboLeadSurgeon, "Lead Surgeon (Staff)!")
                .OtherSurgeon = StringMayBeEnteredIn(Me.stbOtherSurgeon)
                .LeadAnaesthetist = SubstringEnteredIn(Me.cboLeadAnaesthetist, "Lead Anaesthetist (Staff)!")
                .OtherAnaesthetist = StringMayBeEnteredIn(Me.stbOtherAnaesthetist)
                .LeadNurse = SubstringEnteredIn(Me.cboLeadNurse, "Lead Nurse (Staff)!")
                .OtherNurse = StringMayBeEnteredIn(Me.stbOtherNurse)
                .AnaesthesiaTypeID = StringValueEnteredIn(Me.cboAnaesthesiaTypeID, "Anaesthesia Type!")
                .OperationClassID = StringValueEnteredIn(Me.cboOperationClassID, "Operation Class!")
                .PreoperativeDiagnosis = StringMayBeEnteredIn(Me.stbPreoperativeDiagnosis)
                .PlannedProcedures = StringMayBeEnteredIn(Me.stbPlannedProcedures)
                .PostoperativeInstructions = StringMayBeEnteredIn(Me.stbPostoperativeInstructions)
                .Report = StringEnteredIn(Me.stbReport, "Report!")
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Update()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre Findings Successfully Updated!")
            End With
            Me.theatreReportSaved = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveTheatre()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim operationDate As Date = DateEnteredIn(Me.dtpOperationDateTime, "Operation Date!")
            Dim staffNo As String = SubstringEnteredIn(Me.cboLeadSurgeon, "Lead Surgeon (Staff)!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            Dim lExtraBills As New List(Of DBConnect)
            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim billHeaderTransactions As New List(Of TransactionList(Of DBConnect))

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = oExtraBillsEXT.GetExtraBillsEXTExtraBillNo(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

                With oExtraBills

                    .VisitNo = visitNo
                    .ExtraBillNo = GetNextExtraBillNo(visitNo, patientNo)
                    .ExtraBillDate = operationDate
                    .StaffNo = staffNo
                    .LoginID = CurrentUser.LoginID

                End With

                lExtraBills.Add(oExtraBills)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(extraBillNo) Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With oExtraBillsEXT
                        .ExtraBillNo = oExtraBills.ExtraBillNo
                        .RoundNo = roundNo
                    End With

                    lExtraBillsEXT.Add(oExtraBillsEXT)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    billHeaderTransactions.Add(New TransactionList(Of DBConnect)(lExtraBillsEXT, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    extraBillNo = oExtraBills.ExtraBillNo
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(billHeaderTransactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If
            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colTheatreCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                Dim payStatus As String = StringEnteredIn(cells, Me.colTheatrePayStatusID)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colTheatreAmount, False, "amount!")
                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100

                Try

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = (From data In _TheatreServices
                                                 Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper())
                                                 Select data.Field(Of String)("TheatreName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()

                            With oIPDItems

                                .RoundNo = roundNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .LastUpdate = operationDate
                                .PayStatusID = String.Empty
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = oItemStatusID.Offered

                            End With

                            lIPDItems.Add(oIPDItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                            With oIPDItems
                                .RoundNo = roundNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                                .LastUpdate = operationDate
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .ItemStatusID = oItemStatusID.Offered
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                    .PayStatusID = oPayStatusID.NA
                                Else
                                    .PayStatusID = payStatus
                                End If
                                .LoginID = CurrentUser.LoginID
                            End With

                            lIPDItems.Add(oIPDItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Theatre
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = "Theatre service: " + theatreName + ", offered to Patient No: " + patientNo + " and Round No: " + roundNo
                            .LastUpdate = operationDate
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = payStatus
                            End If
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = payStatus
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, rowNo).Value = GetLookupDataDes(oItemStatusID.Offered)
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcIPDTheatreOperations.SelectTab(Me.tpgTheatre)
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvTheatre.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgTheatre)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyPrescriptionsEntries() As Boolean

        Dim message As String

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgPrescriptions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value).Equals(False) Then

                    Dim oVariousOptions As New VariousOptions()
                    Dim drugNo As String = SubstringRight(StringEnteredIn(row.Cells, Me.colDrug, "drug!"))
                    Dim drugName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colDrug))

                    StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                    IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colDrugQuantity, "quantity!")
                    DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "unit price!")
                    StringMayBeEnteredIn(row.Cells, Me.colDrugFormula)

                    Dim availableStock As Integer = GetAvailableStock(drugNo)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colOrderLevel)
                    Dim halted As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHalted)
                    Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHasAlternateDrugs)
                    Dim expiryDate As Date = DateMayBeEnteredIn(row.Cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                    'If halted Then
                    '    If hasAlternateDrugs Then
                    '        message = "Drug: " + drugName + " is currently on halt and has registered alternatives. " + 
                    '                        "The system does not allow prescription of a drug on halt. " + 
                    '                        ControlChars.NewLine + "Would you like to look at its alternatives? "
                    '        If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(oItems.ItemCode)
                    '    Else
                    '        message = "Drug: " + drugName + " is currently on halt and has no registered alternatives. " + 
                    '                    "The system does not allow prescription of a drug on halt!"
                    '        DisplayMessage(message)
                    '    End If
                    'End If

                    If availableStock < quantity Then
                        If Not oVariousOptions.AllowPrescriptionToNegative() Then
                            If hasAlternateDrugs Then
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                  (quantity - availableStock).ToString() + " and has registered alternatives. " +
                                  "The system does not allow a prescription of a drug that is out of stock. " +
                                  "Please notify Pharmacy to re-stock appropriately. " +
                                   ControlChars.NewLine + "Would you like to look at its alternatives? "
                                If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                            Else
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                    (quantity - availableStock).ToString() + " and has no registered alternatives. " +
                                    "The system does not allow a prescription of a drug that is out of stock. " +
                                    "Please notify Pharmacy to re-stock appropriately!"
                                Throw New ArgumentException(message)
                            End If
                            Throw New ArgumentException("Action Cancelled!")
                        Else
                            message = "Insufficient stock to dispense for " + drugName +
                                      " with a deficit of " + (quantity - availableStock).ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then
                                If hasAlternateDrugs Then
                                    message = "Would you like to look at " + drugName + " alternatives? "
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                                End If
                                Throw New ArgumentException("Action Cancelled!")
                            End If
                        End If

                    ElseIf orderLevel >= availableStock - quantity Then
                        message = "Stock level for " + drugName + " is running low. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredDrugs() Then
                            message = "Expiry date for " + drugName + " had reached. " +
                                "The system does not allow to prescribe a drug that is expired. Please notify Pharmacy to re-stock appropriately! "
                            DisplayMessage(message)
                            Continue For
                        Else
                            message = "Expiry date for " + drugName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Drug: " + drugName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return True

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SavePrescriptions()

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim operationDate As Date = DateEnteredIn(Me.dtpOperationDateTime, "Operation Date!")

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lIPDItems As New List(Of DBConnect)
                Dim lIPDItemsEXT As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim paystatus As String = StringEnteredIn(cells, Me.colDrugPayStatusID)
                Try
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                            .LastUpdate = operationDate
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemStatusID = oItemStatusID.Pending
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, SubstringRight(StringEnteredIn(cells, Me.colDrug)), oItemCategoryID.Drug).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = paystatus
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItems.Add(oIPDItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    Using oIPDItemsEXT As New SyncSoft.SQLDb.IPDItemsEXT()
                        With oIPDItemsEXT
                            .RoundNo = roundNo
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Dosage = StringEnteredIn(cells, Me.colDosage)
                            .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItemsEXT.Add(oIPDItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItemsEXT, Action.Save))

                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .RoundNo = roundNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Prescription(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.OpenIPDDispenseAfterPrescription Then

                Dim hasPendingItems As Boolean = False
                message = "Would you like to open IPD Dispense now?"

                For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value) = True Then
                        Dim itemStatus As String = StringMayBeEnteredIn(row.Cells, Me.colDrugItemStatus)
                        If itemStatus.ToUpper().Equals(GetLookupDataDes(oItemStatusID.Pending).ToUpper()) Then
                            hasPendingItems = True
                            Exit For
                        End If
                    End If
                    hasPendingItems = False
                Next

                If hasPendingItems AndAlso WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIPDPharmacy As New frmIPDPharmacy(roundNo)
                    fIPDPharmacy.ShowDialog()
                    Me.LoadPrescriptions(roundNo)
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvPrescription.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyConsumableEntries() As Boolean

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable!")
                IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "unit price!")
                DecimalEnteredIn(row.Cells, Me.colConsumableAmount, False, "amount!")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.RowCount > 1 Then
                Dim message As String = "Consumables(s) will automatically be added to the Patient's bill." +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            Return True

        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables)
            VerifyConsumableEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveConsumables()
        Dim message As String

        Dim oVariousOptions As New VariousOptions()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Dim roundDate As Date = DateEnteredIn(Me.stbRoundDateTime, "Round Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()


            '  If Me.dgvConsumables.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for consumable item!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Dim consumableNo As String = SubstringRight(StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Number!"))
                Dim consumableName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Name!"))
                IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me, ErrProvider)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lIPDItems As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                Dim consumableName As String = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False)
                Dim paystatus As String = StringEnteredIn(cells, Me.colConsumablePayStatusID)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    If quantity > 0 AndAlso unitsInStock < quantity Then
                        If Not oVariousOptions.AllowPrescriptionToNegative() Then

                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                               ControlChars.NewLine + "The system does not allow to give a consumable that is out of stock. " +
                               "Please re-stock appropriately! "

                            Throw New ArgumentException(message)
                        Else
                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

                        End If

                    ElseIf orderLevel >= unitsInStock - quantity Then

                        message = "Stock level for " + consumableName + " is running low. Please re-stock appropriately!"
                        DisplayMessage(message)

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredConsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " + ControlChars.NewLine +
                                "The system does not allow to give a consumable that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + consumableName + " had reached. " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + consumableName + " is not set. The system can not verify when this consumable will expire!"
                        DisplayMessage(message)

                    End If

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()

                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = consumableNo
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = roundDate
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemStatusID = oItemStatusID.Pending
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = paystatus
                            End If
                            .LoginID = CurrentUser.LoginID

                        End With

                        lIPDItems.Add(oIPDItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                        Try

                            If GetShortDate(DateMayBeEnteredIn(Me.stbRoundDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Consumable
                                        .RoundNo = roundNo
                                        .StaffNo = attendingStaffNo
                                        .Notes = (rowNo + 1).ToString() + " Consumable(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables)
                            ErrorMessage(ex)
                        End Try

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next


        Catch ex As Exception
            Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables.Name)
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub LoadAttachedConsumables(selectedRow As Integer, procedureCode As String)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim consumableItems As DataTable = oItems.GetAttachedPossibleCosumables(procedureCode).Tables("PossibleAttachedItems")
        If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim count As Integer = Me.dgvConsumables.Rows.Count - 1

        If selectedRow = dgvProcedures.Rows.Count - 2 Then

            For pos As Integer = 0 To consumableItems.Rows.Count - 1
                Dim row As DataRow = consumableItems.Rows(pos)
                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim consumableNo As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim amount As Decimal = quantity * unitPrice

                    .Item(Me.colConsumableName.Name, count).Value = StringEnteredIn(row, "ConsumableFullName")
                    .Item(Me.colConsumableQuantity.Name, count).Value = quantity
                    .Item(Me.colConsumableNotes.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumablesSaved.Name, pos).Value = False
                    .Item(Me.colConsumableItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablePayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablePayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If

                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), count)
                    Me.dgvConsumables.EndEdit()
                    count += 1

                End With

            Next

        End If

    End Sub

    Private Sub LoadAttachedTheatreServices(selectedRow As Integer, procedureCode As String)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim theatreServices As DataTable = oItems.GetAttachedPossibleTheatreServices(procedureCode).Tables("PossibleAttachedItems")
        If theatreServices Is Nothing OrElse theatreServices.Rows.Count < 1 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim count As Integer = Me.dgvTheatre.Rows.Count - 1

        If selectedRow = dgvProcedures.Rows.Count - 2 Then

            For pos As Integer = 0 To theatreServices.Rows.Count - 1
                Dim row As DataRow = theatreServices.Rows(pos)
                With Me.dgvTheatre

                    .Rows.Add()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim theatreServiceNo As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim unitPrice As Decimal = GetCustomFee(theatreServiceNo, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim amount As Decimal = quantity * unitPrice
                    .Item(Me.colTheatreCode.Name, count).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDTheatreCode.Name, count).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, count).Value = quantity
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, theatreServiceNo, oItemCategoryID.Theatre).Equals(True) Then
                        .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colTheatrePayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colTheatrePayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If
                    .Item(Me.colTheatreSaved.Name, pos).Value = False
                    count += 1

                End With

            Next

        End If

    End Sub

    Private Sub LoadAttachedPrescriptions(selectedRow As Integer, procedureCode As String)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim attachedPrescriptions As DataTable = oItems.GetAttachedPossiblePrescription(procedureCode).Tables("PossibleAttachedItems")
        If attachedPrescriptions Is Nothing OrElse attachedPrescriptions.Rows.Count < 1 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim count As Integer = Me.dgvPrescription.Rows.Count - 1

        If selectedRow = dgvProcedures.Rows.Count - 2 Then

            For pos As Integer = 0 To attachedPrescriptions.Rows.Count - 1
                Dim row As DataRow = attachedPrescriptions.Rows(pos)
                With Me.dgvPrescription

                    ' Ensure that you add a new row
                    .Rows.Add()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim drugNo As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                    Dim amount As Decimal = quantity * unitPrice


                    .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugFullName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDrugQuantity.Name, count).Value = quantity
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                        .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    Else
                        .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    End If
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                    count += 1

                End With

            Next

        End If

    End Sub


    Private Function AllSaved() As Boolean

        Try
            Dim message As String = "Please ensure that all entries are saved on "
            Dim roundNo As String = StringMayBeEnteredIn(Me.stbRoundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(roundNo) Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                Dim operationDate As Date = DateMayBeEnteredIn(Me.dtpOperationDateTime)
                Dim leadSurgeon As String = StringMayBeEnteredIn(Me.cboLeadSurgeon)
                Dim leadAnaesthetist As String = StringMayBeEnteredIn(Me.cboLeadAnaesthetist)
                Dim leadNurse As String = StringMayBeEnteredIn(Me.cboLeadNurse)
                Dim anaesthesiaTypeID As String = StringValueMayBeEnteredIn(Me.cboAnaesthesiaTypeID, "Anaesthesia Type!")
                Dim operationClassID As String = StringValueMayBeEnteredIn(Me.cboOperationClassID, "Operation Class!")
                Dim report As String = StringMayBeEnteredIn(Me.stbReport)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If theatreReportSaved = False Then
                    DisplayMessage(message + "Theatre Operations!")
                    Me.ebnSaveUpdate.Focus()
                    Me.BringToFront()
                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                    Return False
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update AndAlso Not Me.ebnSaveUpdate.Enabled Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each page As TabPage In Me.tbcIPDTheatreOperations.TabPages

                Select Case page.Name

                    Case Me.tpgIPDDiagnosis.Name

                        For Each row As DataGridViewRow In Me.dgvIPDDiagnosis.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDiagnosisSaved) Then
                                DisplayMessage(message + Me.tpgIPDDiagnosis.Text)
                                Me.tbcIPDTheatreOperations.SelectTab(Me.tpgIPDDiagnosis)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgProcedures.Name
                        For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colProceduresSaved) Then
                                DisplayMessage(message + Me.tpgProcedures.Text)
                                Me.tbcIPDTheatreOperations.SelectTab(Me.tpgProcedures)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgTheatre.Name
                        For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colTheatreSaved) Then
                                DisplayMessage(message + Me.tpgTheatre.Text)
                                Me.tbcIPDTheatreOperations.SelectTab(Me.tpgTheatre)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgPrescriptions.Name
                        For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colPrescriptionSaved) Then
                                DisplayMessage(message + Me.tpgPrescriptions.Text)
                                Me.tbcIPDTheatreOperations.SelectTab(Me.tpgPrescriptions)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                    Case Me.tpgConsumables.Name
                        For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colConsumablesSaved) Then
                                DisplayMessage(message + Me.tpgConsumables.Text)
                                Me.tbcIPDTheatreOperations.SelectTab(Me.tpgConsumables)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                End Select
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

#Region " IPDDiagnosis - Grid "

    Private Sub dgvIPDDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvIPDDiagnosis.CellBeginEdit

        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvIPDDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvIPDDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvIPDDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    End Sub

    Private Sub dgvIPDDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvIPDDiagnosis.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvIPDDiagnosis.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDiseaseCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvIPDDiagnosis.Rows.Count > 1 Then Me.SetDiagnosisEntries(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvIPDDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

            If CBool(Me.dgvIPDDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In diagnosis
                                                  Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                                  Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvIPDDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvIPDDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvIPDDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvIPDDiagnosis.Rows(rowNo).Cells, Me.colDiseaseCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                                        Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.ToUpper())
                                                        Select data.Field(Of String)("DiseaseName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvIPDDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvIPDDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseCode = '" + selectedItem + "'")
                Me.dgvIPDDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCategories")
                Me.dgvIPDDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvIPDDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvIPDDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvIPDDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''           
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Visit's No!"))
            Dim diagnosis As String = CStr(Me.dgvIPDDiagnosis.Item(Me.colDiseaseCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDDiagnosis
                .RoundNo = roundNo
                .DiseaseCode = diagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvIPDDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvIPDDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadIPDDiagnosis(ByVal roundNo As String)

        Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()

        Try

            Me.dgvIPDDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim diagnosis As DataTable = oIPDDiagnosis.GetIPDDiagnosis(RevertText(roundNo)).Tables("IPDDiagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To diagnosis.Rows.Count - 1

                Dim row As DataRow = diagnosis.Rows(pos)

                With Me.dgvIPDDiagnosis
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
                    .Item(Me.colICDDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try

            If Me.colConsumableName.Items.Count < 1 Then Return
            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Consumable Item Name (" + _ConsumableItemValue + ") can't be edited!")
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable Item Name (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DetailConsumableItem(selectedRow)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvConsumables.UserDeletedRow
        Me.CalculateBillForConsumables()
    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailConsumableItem(selectedRow As Integer)

        Dim selectedItem As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumableNo As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvConsumables
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colConsumableUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colConsumablePayStatusID.Name, selectedRow).Value = oPayStatusID.NA
                Else
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                    .Item(Me.colConsumablePayStatusID.Name, selectedRow).Value = oPayStatusID.NotPaid
                End If

                .Item(Me.colConsumableHalted.Name, selectedRow).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateConsumablesAmount(selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitPrice)

        Me.dgvConsumables.Item(Me.colConsumableAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForConsumables()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function LoadIPDConsumables(ByVal roundNo As String) As Boolean

        Dim oItems As New SyncSoft.SQLDb.IPDItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableItems As DataTable = oItems.GetIPDItems(roundNo, oItemCategoryID.Consumable).Tables("IPDItems")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To consumableItems.Rows.Count - 1

                Dim row As DataRow = consumableItems.Rows(pos)

                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", True)
                    Dim amount As Decimal = quantity * unitPrice

                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                    .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumablesSaved.Name, pos).Value = True
                    .Item(Me.colConsumableItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colConsumablePayStatusID.Name, pos).Value = StringEnteredIn(row, "PayStatusID")
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            Return False
            Throw ex

        End Try

    End Function


#End Region

#Region " Procedures - Grid "

    Private Sub dgvProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvProcedures.Rows.Count > 1 Then Me.SetProceduresEntries(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colProcedureQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateProcedureAmount(selectedRow)
                Me.CalculateBillForProcedures()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colProcedureUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateProcedureAmount(selectedRow)
                Me.CalculateBillForProcedures()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetProceduresEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim procedureDisplay As String = (From data In _Procedures
                                                  Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper())
                                                  Select data.Field(Of String)("ProcedureName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Procedures
                                                        Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper())
                                                        Select data.Field(Of String)("ProcedureName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailProcedures(selectedRow)
            Me.CalculateProcedureAmount(selectedRow)
            Me.CalculateBillForProcedures()
            Me.LoadAttachedTheatreServices(selectedRow, selectedItem)
            Me.LoadAttachedPrescriptions(selectedRow, selectedItem)
            Me.LoadAttachedConsumables(selectedRow, selectedItem)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvProcedures_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserAddedRow
        Me.dgvProcedures.Item(Me.colProcedureQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserDeletedRow
        Me.CalculateBillForProcedures()
    End Sub

    Private Sub dgvProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailProcedures(ByVal selectedRow As Integer)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            If Me.dgvProcedures.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)

            With Me.dgvProcedures
                .Item(Me.colICDProcedureCode.Name, selectedRow).Value = selectedItem
                .Item(Me.colProcedureQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colProcedureUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colProcedureItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Procedure).Equals(True) Then
                    .Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForProcedures()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colProcedureAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateProcedureAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureUnitPrice)

        Me.dgvProcedures.Item(Me.colProcedureAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadProcedures(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim procedure As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Procedure).Tables("IPDItems")

            If procedure Is Nothing OrElse procedure.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To procedure.Rows.Count - 1

                Dim row As DataRow = procedure.Rows(pos)

                With Me.dgvProcedures
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colProcedureUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colProcedureAmount.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "Amount", True))
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colProcedureItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colProcedurePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colProceduresSaved.Name, pos).Value = True
                End With
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Theatre - Grid "

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreCode.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            If Me.colTheatreCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTheatreCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                Dim TheatreDisplay As String = (From data In _TheatreServices
                                                Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreNameValue.ToUpper())
                                                Select data.Field(Of String)("TheatreName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre (" + TheatreDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colTheatreCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _TheatreServices
                                                        Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
                                                        Select data.Field(Of String)("TheatreName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Theatre (" + enteredDisplay + ") already selected!")
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailTheatre(selectedRow)
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Dim itemCode As String = CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserDeletedRow
        Me.CalculateBillForTheatre()
    End Sub

    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailTheatre(ByVal selectedRow As Integer)
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim selectedItem As String = String.Empty
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            If Me.dgvTheatre.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

            With Me.dgvTheatre
                .Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                .Item(Me.colTheatreQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colTheatreItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                    .Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colTheatrePayStatusID.Name, selectedRow).Value = oPayStatusID.NA
                Else
                    .Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                    .Item(Me.colTheatrePayStatusID.Name, selectedRow).Value = oPayStatusID.NotPaid
                End If
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForTheatre()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colTheatreAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadTheatre(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Theatre).Tables("IPDItems")
            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, theatre)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try

            If Me.colDrug.Items.Count < 1 Then Return
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDrug.Index) Then
                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDosage.Index) Then
                Me.CalculateDrugQuantity(selectedRow, True)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDuration.Index) Then
                Me.CalculateDrugQuantity(selectedRow, False)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                'Me.CalculateDrugQuantity(selectedRow, False)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug (" + _PrescriptionDrugValue + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrug)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Drug (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailPrescribedDrug(selectedRow)
            Me.CalculateDrugQuantity(selectedRow, False)
            Me.CalculateDrugAmount(selectedRow)
            Me.CalculateBillForPrescriptions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oIPDItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvPrescription.UserDeletedRow
        Me.CalculateBillForPrescriptions()
    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer)

        Dim message As String
        Dim drugSelected As String = String.Empty
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then
                drugSelected = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)
            End If

            Dim drugNo As String = SubstringRight(drugSelected)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim availableStock As Integer = GetAvailableStock(drugNo)
            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")

            With Me.dgvPrescription
                .Item(Me.colAvailableStock.Name, selectedRow).Value = availableStock
                .Item(Me.colOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colPrescriptionGroup.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colDrugItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colDrugPayStatusID.Name, selectedRow).Value = oPayStatusID.NA
                Else
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                    .Item(Me.colDrugPayStatusID.Name, selectedRow).Value = oPayStatusID.NotPaid
                End If

                .Item(Me.colHalted.Name, selectedRow).Value = halted
                .Item(Me.colHasAlternateDrugs.Name, selectedRow).Value = hasAlternateDrugs
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If halted AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is on halt and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            ElseIf availableStock <= 0 AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is out of stock and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForPrescriptions()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            If IsNumeric(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)

        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateDrugQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oDosageCalculationID As New LookupDataID.DosageCalculationID()

        Try

            Dim quantity As Single = 0
            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug))
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDosage)
            Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)

            Dim varyPrescribedQty As Boolean = BooleanEnteredIn(row, "VaryPrescribedQty")
            Dim defaultPrescribedQty As Integer = IntegerEnteredIn(row, "DefaultPrescribedQty")
            Dim dosageSeparator As Char = CChar(StringEnteredIn(row, "DosageSeparator").ToUpper())
            Dim dosageCalculationID As String = StringEnteredIn(row, "DosageCalculationID")
            'Dim dosageFormat As String = StringMayBeEnteredIn(row, "DosageFormat")

            If String.IsNullOrEmpty(dosage) Then Return

            If Not IsCharacterInString(dosage.Trim().ToUpper(), dosageSeparator) Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(";".ToUpper()))
                            dosageSeparator = CChar(";".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(":".ToUpper()))
                            dosageSeparator = CChar(":".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("+".ToUpper()))
                            dosageSeparator = CChar("+".ToUpper())
                    End Select
                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("X".ToUpper()))
                            dosageSeparator = CChar("X".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("*".ToUpper()))
                            dosageSeparator = CChar("*".ToUpper())
                    End Select
                End If
            End If

            Dim fullDosage() As String = dosage.Trim().ToUpper().Split(dosageSeparator)
            If fullDosage.Length < 2 Then Throw New ArgumentException("Dosage format incorrect!")

            If Not varyPrescribedQty Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    For Each dose As String In fullDosage
                        Dim dailyDosage As Single
                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                            quantity += dailyDosage
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric separated with '" + dosageSeparator + "' character")
                        End If
                    Next

                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then

                    If fullDosage.Length = 2 Then

                        Dim dailyDosage As Single
                        Dim dailyPeriod As Integer

                        Dim dose As String = fullDosage(fullDosage.GetLowerBound(0))
                        Dim period As String = fullDosage(fullDosage.GetUpperBound(0))

                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric")
                        End If

                        If IsNumeric(period.Trim()) AndAlso Integer.TryParse(period.Trim(), dailyPeriod) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + period + "', enter only as numeric with no decimal places")
                        End If

                        quantity = dailyDosage * dailyPeriod * duration

                    Else : Throw New ArgumentException("Dosage format incorrect, enter only as numeric separated with '" + dosageSeparator + "' character e.g. 2" + dosageSeparator + "1")
                    End If

                Else : quantity = defaultPrescribedQty
                End If
            Else : quantity = defaultPrescribedQty
            End If

            If calculateDuration AndAlso dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = fullDosage.Length
            End If

            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = CInt(quantity)

        Catch ex As Exception
            ErrorMessage(ex)
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
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colPrescriptionGroup.Name, pos).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
                .Item(Me.colHasAlternateDrugs.Name, pos).Value = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPrescriptions(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Drug).Tables("IPDItems")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colDrugPayStatusID.Name, pos).Value = StringEnteredIn(row, "PayStatusID")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPrescriptions()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Theatre Report - Printing "

    Private Sub btnPrintPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetTheatreReportPrintData()

            With dlgPrintPreview
                .Document = docTheatreReport
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintTheatreReport()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintTheatreReport()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetTheatreReportPrintData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docTheatreReport
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docTheatreReport.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docTheatreReport_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docTheatreReport.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Theatre Report".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim attendingDoctor As String = StringMayBeEnteredIn(Me.stbAttendingDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Attending Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(attendingDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If theatreReportParagraphs Is Nothing Then Return

                Do While theatreReportParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(theatreReportParagraphs(1), PrintParagraps)
                    theatreReportParagraphs.Remove(1)

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
                        theatreReportParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (theatreReportParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetTheatreReportPrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        theatreReportParagraphs = New Collection()

        Try

            '''''''''''''''OPERATION DETAILS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim operationDetailsTitle As New System.Text.StringBuilder(String.Empty)
            operationDetailsTitle.Append(ControlChars.NewLine)
            operationDetailsTitle.Append("OPERATION DETAILS: ".ToUpper())
            operationDetailsTitle.Append(ControlChars.NewLine)
            operationDetailsTitle.Append(ControlChars.NewLine)
            theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, operationDetailsTitle.ToString()))
            theatreReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OperationDetailsData()))

            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append(ControlChars.NewLine)

            Dim tableDiagnosis As New System.Text.StringBuilder(String.Empty)
            tableDiagnosis.Append("No: ".PadRight(padLineNo))
            tableDiagnosis.Append("Diagnosis: ".PadRight(padService))
            tableDiagnosis.Append("Notes: ".PadRight(padNotes))
            tableDiagnosis.Append(ControlChars.NewLine)
            tableDiagnosis.Append(ControlChars.NewLine)

            theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))
            If Me.dgvIPDDiagnosis.RowCount > 1 Then
                theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDiagnosis.ToString()))
            End If
            theatreReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData()))

            ''''''''''''''''Procedures'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proceduresTitle As New System.Text.StringBuilder(String.Empty)
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append("Procedures: ".ToUpper())
            proceduresTitle.Append(ControlChars.NewLine)
            proceduresTitle.Append(ControlChars.NewLine)

            Dim tableProcedures As New System.Text.StringBuilder(String.Empty)
            tableProcedures.Append("No: ".PadRight(padLineNo))
            tableProcedures.Append("Procedure Name: ".PadRight(padService))
            tableProcedures.Append("Notes: ".PadRight(padNotes))
            tableProcedures.Append(ControlChars.NewLine)
            tableProcedures.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.ProceduresData()) Then
                theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, proceduresTitle.ToString()))
                If Me.dgvProcedures.RowCount > 1 Then
                    theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableProcedures.ToString()))
                End If
                theatreReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ProceduresData()))
            End If

            ''''''''''''''''Theatre'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreTitle As New System.Text.StringBuilder(String.Empty)
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append("Theatre: ".ToUpper())
            theatreTitle.Append(ControlChars.NewLine)
            theatreTitle.Append(ControlChars.NewLine)

            Dim tableTheatre As New System.Text.StringBuilder(String.Empty)
            tableTheatre.Append("No: ".PadRight(padLineNo))
            tableTheatre.Append("Theatre Name: ".PadRight(padService))
            tableTheatre.Append("Notes: ".PadRight(padNotes))
            tableTheatre.Append(ControlChars.NewLine)
            tableTheatre.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.TheatreData()) Then
                theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, theatreTitle.ToString()))
                If Me.dgvTheatre.RowCount > 1 Then
                    theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tableTheatre.ToString()))
                End If
                theatreReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TheatreData()))
            End If

            ''''''''''''''''Prescription'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("Prescription: ".ToUpper())
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append(ControlChars.NewLine)

            Dim tablePrescription As New System.Text.StringBuilder(String.Empty)
            tablePrescription.Append("No: ".PadRight(padLineNo))
            tablePrescription.Append("Drug Name: ".PadRight(padService))
            tablePrescription.Append("Dosage: ".PadRight(padNotes))
            tablePrescription.Append(ControlChars.NewLine)
            tablePrescription.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.PrescriptionData()) Then
                theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionTitle.ToString()))
                If Me.dgvPrescription.RowCount > 1 Then
                    theatreReportParagraphs.Add(New PrintParagraps(bodyBoldFont, tablePrescription.ToString()))
                End If
                theatreReportParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionData()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)
            doctorSignData.Append(ControlChars.NewLine)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Doctor's Sign:   " + GetCharacters("."c, 20))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 20))
            doctorSignData.Append(ControlChars.NewLine)
            theatreReportParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            ''''''''''''''''FOOTER DATA'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + FixDataLength(CurrentUser.FullName, footerLEN) + " on " + FormatDate(Now) +
                              " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            theatreReportParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Public Function OperationDetailsData() As String

        Try

            Dim textData As New System.Text.StringBuilder(String.Empty)

            Dim operationDateTime As String = FormatDateTime(DateTimeMayBeEnteredIn(Me.dtpOperationDateTime))

            Dim surgeon As String
            Dim leadSurgeon As String = SubstringLeft(StringMayBeEnteredIn(Me.cboLeadSurgeon))
            Dim otherSurgeon As String = StringMayBeEnteredIn(Me.stbOtherSurgeon)

            If Not String.IsNullOrEmpty(otherSurgeon) Then
                surgeon = leadSurgeon + ", " + otherSurgeon
            Else : surgeon = leadSurgeon
            End If

            Dim anaesthetist As String
            Dim leadAnaesthetist As String = SubstringLeft(StringMayBeEnteredIn(Me.cboLeadAnaesthetist))
            Dim otherAnaesthetist As String = StringMayBeEnteredIn(Me.stbOtherAnaesthetist)

            If Not String.IsNullOrEmpty(otherAnaesthetist) Then
                anaesthetist = leadAnaesthetist + ", " + otherAnaesthetist
            Else : anaesthetist = leadAnaesthetist
            End If

            Dim nurse As String
            Dim leadNurse As String = SubstringLeft(StringMayBeEnteredIn(Me.cboLeadNurse))
            Dim otherNurse As String = StringMayBeEnteredIn(Me.stbOtherNurse)

            If Not String.IsNullOrEmpty(otherNurse) Then
                nurse = leadNurse + ", " + otherNurse
            Else : nurse = leadNurse
            End If

            Dim anaesthesiaType As String = StringMayBeEnteredIn(Me.cboAnaesthesiaTypeID)
            Dim operationClass As String = StringMayBeEnteredIn(Me.cboOperationClassID)
            Dim preoperativeDiagnosis As String = StringMayBeEnteredIn(Me.stbPreoperativeDiagnosis)
            Dim plannedProcedures As String = StringMayBeEnteredIn(Me.stbPlannedProcedures)
            Dim postoperativeInstructions As String = StringMayBeEnteredIn(Me.stbPostoperativeInstructions)
            Dim report As String = StringMayBeEnteredIn(Me.stbReport)

            If Not String.IsNullOrEmpty(operationDateTime) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Operation Date and Time: " + operationDateTime)
                Else : textData.Append("Operation Date and Time: " + operationDateTime)
                End If
            End If

            If Not String.IsNullOrEmpty(surgeon) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Surgeon(s): " + surgeon)
                Else : textData.Append("Surgeon(s): " + surgeon)
                End If
            End If

            If Not String.IsNullOrEmpty(anaesthetist) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Anaesthetist(s): " + anaesthetist)
                Else : textData.Append("Anaesthetist(s): " + anaesthetist)
                End If
            End If

            If Not String.IsNullOrEmpty(nurse) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Nurse(s): " + nurse)
                Else : textData.Append("Nurse(s): " + nurse)
                End If
            End If

            If Not String.IsNullOrEmpty(anaesthesiaType) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Anaesthesia Type: " + anaesthesiaType)
                Else : textData.Append("Anaesthesia Type: " + anaesthesiaType)
                End If
            End If

            If Not String.IsNullOrEmpty(operationClass) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Operation Class: " + operationClass)
                Else : textData.Append("Operation Class: " + operationClass)
                End If
            End If

            If Not String.IsNullOrEmpty(preoperativeDiagnosis) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Preoperative Diagnosis: " + ControlChars.NewLine + preoperativeDiagnosis)
                Else : textData.Append("Preoperative Diagnosis: " + ControlChars.NewLine + preoperativeDiagnosis)
                End If
            End If


            If Not String.IsNullOrEmpty(plannedProcedures) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Planned Procedure(s): " + ControlChars.NewLine + plannedProcedures)
                Else : textData.Append("Planned Procedure(s): " + ControlChars.NewLine + plannedProcedures)
                End If
            End If


            If Not String.IsNullOrEmpty(postoperativeInstructions) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Postoperative Instruction(s): " + ControlChars.NewLine + postoperativeInstructions)
                Else : textData.Append("Postoperative Instruction(s): " + ControlChars.NewLine + postoperativeInstructions)
                End If
            End If

            If Not String.IsNullOrEmpty(report) Then
                If textData.Length > 1 Then
                    textData.Append(ControlChars.NewLine)
                    textData.Append(ControlChars.NewLine)
                    textData.Append("Report: " + ControlChars.NewLine + report)
                Else : textData.Append("Report: " + ControlChars.NewLine + report)
                End If
            End If

            If textData.Length > 1 Then textData.Append(ControlChars.NewLine)

            Return textData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DiagnosisData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvIPDDiagnosis.RowCount - 1

                If CBool(Me.dgvIPDDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvIPDDiagnosis.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim diseaseCode As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)
                    Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                    Dim diagnosisDisplay As String = (From data In diagnosis
                                                      Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(diseaseCode.ToUpper())
                                                      Select data.Field(Of String)("DiseaseName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedDiagnosisDisplay As List(Of String) = WrapText(diagnosisDisplay, padService)
                    If wrappedDiagnosisDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedDiagnosisDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedDiagnosisDisplay(pos).Trim(), padService))
                            If pos = wrappedDiagnosisDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(diagnosisDisplay, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ProceduresData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

                If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim procedureCode As String = StringMayBeEnteredIn(cells, Me.colProcedureCode)
                    Dim miniProcedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim procedureName As String = (From data In miniProcedures
                                                   Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(procedureCode.ToUpper())
                                                   Select data.Field(Of String)("ProcedureName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedProceduresDisplay As List(Of String) = WrapText(procedureName, padService)
                    If wrappedProceduresDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedProceduresDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedProceduresDisplay(pos).Trim(), padService))
                            If pos = wrappedProceduresDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(procedureName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TheatreData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

                If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colTheatreCode)
                    Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = (From data In miniTheatre
                                                 Where data.Field(Of String)("TheatreCode").ToUpper().Equals(theatreCode.ToUpper())
                                                 Select data.Field(Of String)("TheatreName")).First()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)

                    tableData.Append(lineNo.PadRight(padLineNo))

                    Dim wrappedTheatreDisplay As List(Of String) = WrapText(theatreName, padService)
                    If wrappedTheatreDisplay.Count > 1 Then
                        For pos As Integer = 0 To wrappedTheatreDisplay.Count - 1
                            tableData.Append(FixDataLength(wrappedTheatreDisplay(pos).Trim(), padService))
                            If pos = wrappedTheatreDisplay.Count - 1 Then

                                Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                                If wrappedNotes.Count > 1 Then
                                    For count As Integer = 0 To wrappedNotes.Count - 1
                                        tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                        tableData.Append(ControlChars.NewLine)
                                        tableData.Append(GetSpaces(padLineNo + padService))
                                    Next
                                Else : tableData.Append(FixDataLength(notes, padNotes))
                                End If

                            End If
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo))
                        Next
                    Else
                        tableData.Append(FixDataLength(theatreName, padService))
                        Dim wrappedNotes As List(Of String) = WrapText(notes, padNotes)
                        If wrappedNotes.Count > 1 Then
                            For count As Integer = 0 To wrappedNotes.Count - 1
                                tableData.Append(FixDataLength(wrappedNotes(count).Trim(), padNotes))
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padLineNo + padService))
                            Next
                        Else : tableData.Append(FixDataLength(notes, padNotes))
                        End If

                    End If

                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()
                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colDrug))
                    Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugFormula)
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

                    tableData.Append(lineNo.PadRight(padLineNo))
                    tableData.Append(itemName.PadRight(padService))

                    Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padNotes)
                    If wrappedfullDosage.Count > 1 Then
                        For pos As Integer = 0 To wrappedfullDosage.Count - 1
                            tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padNotes))
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padLineNo + padService))
                        Next
                    Else : tableData.Append(FixDataLength(fullDosage, padNotes))
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

#Region " Popup Menu "

    Private Sub cmsTheatreOperations_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsTheatreOperations.Opening

        Select Case Me.tbcIPDTheatreOperations.SelectedTab.Name

            Case Me.tpgIPDDiagnosis.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgProcedures.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgTheatre.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgPrescriptions.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Else
                Me.cmsTheatreOperationsQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsTheatreOperationsQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsTheatreOperationsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcIPDTheatreOperations.SelectedTab.Name

                Case Me.tpgIPDDiagnosis.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvIPDDiagnosis, Me.colDiseaseCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvIPDDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgProcedures.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Procedures", Me.dgvProcedures, Me.colProcedureCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvProcedures.NewRowIndex
                    If rowIndex > 0 Then Me.SetProceduresEntries(rowIndex - 1)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgTheatre.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colTheatreCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvTheatre.NewRowIndex
                    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgPrescriptions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrug)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvPrescription.NewRowIndex
                    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.btnLoadPendingProcedures.Enabled = False

        Me.ResetControls()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.btnLoadPendingProcedures.Enabled = True

        Me.ResetControls()

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

            Security.Apply(Me.btnAddExtraCharge, AccessRights.Write)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub



#End Region

    Private Sub btnAddExtraCharge_Click(sender As System.Object, e As System.EventArgs) Handles btnAddExtraCharge.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fExtraCharge As New frmIPDExtraCharge(visitNo)

            fExtraCharge.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub
End Class