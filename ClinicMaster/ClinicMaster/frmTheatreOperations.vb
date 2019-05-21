
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

Public Class frmTheatreOperations

#Region " Fields "

    Private currentAllSaved As Boolean = False
    Private currentVisitNo As String = String.Empty
    Private theatreReportSaved As Boolean = False
    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now
    Private theatreServicesAlerts As DataTable

    Private consumableItems As DataTable

    Private procedures As DataTable
    Private diseases As DataTable
    Private theatreServices As DataTable
    Private oVariousOptions As New VariousOptions()
    Private copayTypeID As String
    Private genderID As String
    Private accessCashServices As Boolean = False
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()
    Private OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
    Private hasPackage As Boolean = False
    Private hasPaidPackage As Boolean = False
    Private IsPackage As Boolean = False
    Private patientpackageNo As String = String.Empty
    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private _TheatreCode As String = String.Empty
    Private _DiagnosisCode As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty
    Private _DrugNo As String = String.Empty
    Private extraChargeItems As DataTable
    Private _ExtraItemValue As String = String.Empty

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

#End Region

#Region " Validations "

    Private Sub dtpOperationDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpOperationDateTime.Validating

        Dim errorMSG As String = "Operation date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim operationDate As Date = DateMayBeEnteredIn(Me.dtpOperationDateTime)

            If operationDate = AppData.NullDateValue Then Return

            If operationDate < visitDate Then
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

    Private Sub frmTheatreOperations_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboAnaesthesiaTypeID, LookupObjects.AnaesthesiaType, False)
            LoadLookupDataCombo(Me.cboOperationClassID, LookupObjects.OperationClass, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLeadSurgeon()
            Me.LoadLeadAnaesthetist()
            Me.LoadLeadNurse()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadProcedures()
            Me.LoadTheatreServices()

            Me.LoadConsumableItems()
            Me.LoadExtraChargeItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()
            Me.ShowSentTheatreAlerts()
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmTheatreOperations_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmTheatreOperations_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

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

    Private Sub stbVisitNo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
            Return
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.ClearControls()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
                Me.stbVisitNo.Text = currentVisitNo
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadTheatreOperationsData(visitNo)
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Procedure)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadTheatreOperationsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadTheatreOperationsData(visitNo)
        Me.LoadTheatreServices(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub LoadLeadSurgeon()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadSurgeon, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboLeadAnaesthetist, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Function LoadDiseases() As DataTable

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


            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return diseases
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems
            consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colConsumableName, consumableItems, "ConsumableFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbBillCustomerName.Clear()
        billModesID = String.Empty
        associatedBillNo = String.Empty
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbVisitCategory.Clear()
        accessCashServices = False
        Me.btnAddConsumables.Enabled = False
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgDiagnosis)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgConsumables)
        hasPackage = False
        hasPaidPackage = False

    End Sub

    Private Sub ResetControls()

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlVisitNo)
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgDiagnosis)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgOtherItems)
    End Sub

    Private Sub LoadTheatreOperationsData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Me.LoadDiagnosis(visitNo)
                Me.LoadTheatreOperations(visitNo)
                Me.LoadProceduresToOffer(visitNo)
                Me.LoadTheatreToOffer(visitNo)
                Me.LoadPossibleAttachedTheatreServices(visitNo)
                Me.LoadPossibleAttachedConsumables(visitNo)
                Me.LoadPossibleAttachedPrescribedDrugs(visitNo)


            End If


        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
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
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            hasPaidPackage = BooleanMayBeEnteredIn(row, "HasPaidPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnAddConsumables.Enabled = True
            Security.Apply(Me.btnAddConsumables, AccessRights.Write)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.dtpOperationDateTime.Value = visitDate
            Me.dtpOperationDateTime.Checked = GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProceduresToOffer(ByVal visitNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oItems As New SyncSoft.SQLDb.Items()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvProcedures.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proceduresToOffer As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Procedure, oItemStatusID.Pending).Tables("Items")
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
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Function LoadTheatreToOffer(ByVal visitNo As String) As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oItems As New SyncSoft.SQLDb.Items()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvTheatre.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreToOffer As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre, oItemStatusID.Pending).Tables("Items")
            If theatreToOffer Is Nothing OrElse theatreToOffer.Rows.Count < 1 Then Throw New ArgumentException("This visit has no pending theatre service(s)!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatreToOffer.Rows.Count - 1

                Dim row As DataRow = theatreToOffer.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvTheatre

                    .Rows.Add()
                    .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "ItemName")
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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return True
            Me.DeleteTheatreServicesAlerts(visitNo, visitDate)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return False
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function LoadPossibleAttachedConsumables(ByVal visitNo As String) As Boolean

        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()



        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items attached to the procedures

            Dim consumableItems As DataTable = oPossibleAttachedItems.GetAttachedPossibleCosumablesOnLoad(visitNo).Tables("PossibleAttachedItems")
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
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colConsumablePayStatusID.Name, pos).Value = oPayStatusID.NA
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

    Private Function LoadPossibleAttachedTheatreServices(ByVal visitNo As String) As Boolean

        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load theatre services attached to the procedures
            Dim theatreSevices As DataTable = oPossibleAttachedItems.GetAttachedPossibleTheatreServicesOnLoad(visitNo).Tables("PossibleAttachedItems")

            If theatreSevices Is Nothing OrElse theatreSevices.Rows.Count < 1 Then Return False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatreSevices.Rows.Count - 1

                Dim row As DataRow = theatreSevices.Rows(pos)

                With Me.dgvTheatre

                    .Rows.Add()
                    Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                    Dim selectedItem As String = StringEnteredIn(row, "TheatreCode")

                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim itemcode As String = StringEnteredIn(row, "TheatreCode")
                    Dim unitPrice As Decimal = GetCustomFee(itemcode, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)
                    Dim amount As Decimal = quantity * unitPrice
                    .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "TheatreName")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "TheatreCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = quantity
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colTheatrePayStatusID.Name, pos).Value = oPayStatusID.NA
                    .Item(Me.colTheatreSaved.Name, pos).Value = False

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
        Catch ex As Exception
            Return False
            Throw ex

        End Try

    End Function

    Private Function LoadPossibleAttachedPrescribedDrugs(ByVal visitNo As String) As Boolean

        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try
            Me.dgvPrescription.Rows.Clear()

            ' Load thearte services attached to the procedures
            Dim prescribedDrugs As DataTable = oPossibleAttachedItems.GetAttachedPossiblePrescriptionsOnLoad(visitNo).Tables("PossibleAttachedItems")
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
                    .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "DrugName")
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = StringMayBeEnteredIn(row, "Duration")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDrugQuantity.Name, pos).Value = quantity
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    .Item(Me.ColPrescribedby.Name, pos).Value = CurrentUser.FullName
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

        Dim oTheatreOperations As New SyncSoft.SQLDb.TheatreOperations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oTheatreOperations.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oTheatreOperations.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ResetControls()
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oTheatreOperations As New SyncSoft.SQLDb.TheatreOperations()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!")))
            Dim dataSource As DataTable = oTheatreOperations.GetTheatreOperations(visitNo).Tables("TheatreOperations")
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDiagnosis(visitNo)
            Me.LoadProcedures(visitNo)
            Me.LoadTheatreServices(visitNo)
            Me.LoadPrescriptions(visitNo)
            Me.LoadConsumables(visitNo)
            Me.LoadExtraCharge(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Try
            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim oVariousOptions As New VariousOptions()
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)
            Dim notPaidPayStatus As String = GetLookupDataDes(oPayStatusID.NotPaid)

            If Not oVariousOptions.AllowAccessOPDTheatre AndAlso Not oVariousOptions.AllowAccessCashServices AndAlso
                Not accessCashServices AndAlso billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                    If row.IsNewRow Then Exit For
                    Dim payStatus As String = StringEnteredIn(row.Cells, Me.colProcedurePayStatus, "pay status!")
                    If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) Then
                        Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
                        cashNotPaid = True
                        Exit For
                    End If
                    cashNotPaid = False
                Next

                If cashNotPaid Then Throw New ArgumentException("The system does not allow processing of not paid for procedure(s) for a cash visit!")

            End If

           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If billMode.ToUpper().Equals(insuranceBillMode.ToUpper()) Then IsInsuranceFingerprintVerified(patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Select Case Me.tbcTheatreOperations.SelectedTab.Name

                        Case Me.tpgGeneral.Name
                            Me.SaveTheatreOperations()

                        Case Me.tpgConsumables.Name
                            Me.VerifyConsumableEntries()
                            Me.SaveAttachedConsumables()

                        Case Me.tpgDiagnosis.Name
                            Me.VerifyDiagnosisEntries()
                            Me.SaveDiagnosis()

                        Case Me.tpgPrescriptions.Name
                            Me.VerifyPrescriptionsEntries()
                            Me.SavePrescriptions()

                        Case Me.tpgOtherItems.Name
                            Me.SaveExtraChargeItems()

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
                    Me.ShowSentAlerts()
                    Me.ShowSentTheatreAlerts()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Select Case Me.tbcTheatreOperations.SelectedTab.Name
                        Case Me.tpgGeneral.Name
                            Me.updateTheatreOperations()

                        Case Me.tpgConsumables.Name
                            Me.VerifyConsumableEntries()
                            Me.SaveAttachedConsumables()

                        Case Me.tpgDiagnosis.Name
                            Me.VerifyDiagnosisEntries()
                            Me.SaveDiagnosis()

                        Case Me.tpgPrescriptions.Name
                            Me.VerifyPrescriptionsEntries()
                            Me.SavePrescriptions()

                        Case Me.tpgOtherItems.Name
                            Me.SaveExtraChargeItems()

                        Case Me.tpgProcedures.Name
                            Me.VerifyProceduresEntries()
                            Me.SaveProcedures()

                        Case Me.tpgTheatre.Name
                            Me.VerifyTheatreEntries()
                            Me.SaveTheatre()


                    End Select

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("Record(s) successfully updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SaveTheatreOperations()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.theatreReportSaved = False
        Dim oTheatreOperations As New SyncSoft.SQLDb.TheatreOperations()
        Dim lTheatreOperations As New List(Of DBConnect)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oTheatreOperations


                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
                .OperationDateTime = DateTimeEnteredIn(Me.dtpOperationDateTime, "Operation Date Time!")
                If Me.cboLeadSurgeon.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboLeadSurgeon.Text) Then
                    .LeadSurgeon = SubstringEnteredIn(Me.cboLeadSurgeon, "Lead Surgeon (Staff)!")
                Else : .LeadSurgeon = String.Empty
                End If
                .OtherSurgeon = StringMayBeEnteredIn(Me.stbOtherSurgeon)
                If Me.cboLeadAnaesthetist.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboLeadAnaesthetist.Text) Then
                    .LeadAnaesthetist = SubstringEnteredIn(Me.cboLeadAnaesthetist, "Lead Anaesthetist (Staff)!")
                Else : .LeadAnaesthetist = String.Empty
                End If
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

                .Save()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                DisplayMessage("Theatre Findings Successfully Saved!")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
               
            End With
            Me.theatreReportSaved = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub updateTheatreOperations()


        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.theatreReportSaved = False
            Dim oTheatreOperations As New SyncSoft.SQLDb.TheatreOperations()
            Dim lTheatreOperations As New List(Of DBConnect)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgGeneral)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oTheatreOperations

                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
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

    Private Sub tbcTheatreOperations_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcTheatreOperations.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcTheatreOperations.SelectedTab.Name

                Case Me.tpgGeneral.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgGeneral.Text
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgDiagnosis.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDiagnosis.Text
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
                Case Me.tpgConsumables.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgConsumables.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForConsumables()
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

#Region " Alerts "

    Private Function ShowSentAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.Procedure).Tables("Alerts")
            Dim alertsNo As Integer = alerts.Rows.Count

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Procedure(s): " + alertsNo.ToString()
            alertsStartDateTime = Now
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowSentTheatreAlerts() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            alerts = oAlerts.GetAlerts(oAlertTypeID.Theatre).Tables("Alerts")
            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblTheatreAlerts.Text = "Theatre Service(s): " + alertsNo.ToString()
            alertsStartDateTime = Now
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.Procedure, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadTheatreOperationsData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewTheatreList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewTheatreList.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentTheatreAlerts()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmAlerts(oAlertTypeID.Theatre, Me.stbVisitNo)
        fAlerts.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadTheatreOperationsData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
   
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

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
            Me.ShowSentTheatreAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DeleteTheatreServicesAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If theatreServicesAlerts Is Nothing OrElse theatreServicesAlerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = theatreServicesAlerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                      GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                      data.Field(Of Integer)("AlertID")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oAlerts.AlertID = alertID
            oAlerts.Delete()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentTheatreAlerts()
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
                If Me.ShowSentTheatreAlerts() > 0 Then If InitOptions.AlertSoundOn Then Beep()
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub btnAddConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit Number!"))
            Dim fConsumables As New frmConsumables(visitNo)
            fConsumables.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyDiagnosisEntries() As Boolean

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgDiagnosis)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvDiagnosis.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDiseaseCode)
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgDiagnosis)
            VerifyDiagnosisEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lDiagnosis As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                Try

                    Using oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
                        With oDiagnosis
                            .VisitNo = visitNo
                            .DiseaseCode = StringEnteredIn(cells, Me.colICDDiagnosisCode)
                            .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lDiagnosis.Add(oDiagnosis)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDiagnosis, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim oBillModesID As New LookupDataID.BillModesID()
                    Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                        Dim oEntryModeID As New LookupDataID.EntryModeID()

                        Dim lClaims As New List(Of DBConnect)

                        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                        Dim lClaimsEXT As New List(Of DBConnect)
                        Dim lClaimDiagnosis As New List(Of DBConnect)

                        Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
                        Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)
                        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

                        Using oClaims As New SyncSoft.SQLDb.Claims()

                            With oClaims

                                .MedicalCardNo = billNo
                                .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                .PatientNo = patientNo
                                .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .VisitTime = GetTime(Now)
                                .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboLeadSurgeon))
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

                        Using oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

                            With oClaimDiagnosis
                                .ClaimNo = claimNo
                                .DiseaseCode = StringEnteredIn(cells, Me.colICDDiagnosisCode, "Disease Code!")
                            End With

                            lClaimDiagnosis.Add(oClaimDiagnosis)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lClaimDiagnosis, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End Using

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgDiagnosis)
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Me.dgvDiagnosis.Rows.Clear()
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
            Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
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
            If Me.dgvProcedures.RowCount > 1 Then
                Dim message As String = "Procedure(s) will automatically be marked as done. You won’t be able to remove or make changes to any." +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            Return True

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
            VerifyProceduresEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveProcedures()

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oSmartCardMembers As New SmartCardMembers()
        Dim lSmartCardItems As New List(Of SmartCardItems)
        Dim miniTransactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim operationDate As Date = DateEnteredIn(Me.dtpOperationDateTime, "Operation Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim oSmartCardItems As SmartCardItems
            Dim smardCardNo As String = String.Empty
            Dim medicalCardNo As String = RevertText(RevertText(StringMayBeEnteredIn(Me.stbMemberCardNo), "/"c))
            Dim coverAmount As Decimal
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForItem, True, "Bill for Items!")
            Dim totalCashAmount As Decimal = 0
            Dim Message As String = String.Empty
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)
                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not medicalCardNo.ToUpper().Equals(smardCardNo.ToUpper()) Then
                    Message = "The medical card number  (" + StringMayBeEnteredIn(Me.stbMemberCardNo) + ") for this member is not the same " +
                              "as that forwarded from smart card (" + oSmartCardMembers.MedicalCardNumber + ") " +
                              ", the system does not allow to process numbers that don’t match"
                    Throw New ArgumentException(Message)
                End If

                If billFee > coverAmount Then Throw New ArgumentException("The benefit for this patient is not sufficient to cover the bill!")
                oSmartCardMembers.InvoiceNo = visitNo

            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = operationDate
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
                        miniTransactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        miniTransactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(miniTransactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)

                Dim lClaimDetails As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colProcedureQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colProcedureAmount, False, "amount!")
                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim procedureName As String = (From data In _Procedures
                                                   Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper())
                                                   Select data.Field(Of String)("ProcedureName")).First()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value) = True Then
                        Using oItems As New SyncSoft.SQLDb.Items()

                            With oItems

                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .LastUpdate = operationDate
                                .PayStatusID = String.Empty
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = oItemStatusID.Done

                            End With

                            lItems.Add(oItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                                .LastUpdate = operationDate
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .ItemStatusID = oItemStatusID.Done
                                .PayStatusID = oPayStatusID.NotPaid
                                .LoginID = CurrentUser.LoginID
                            End With

                            lItems.Add(oItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = visitNo
                                    .ItemCode = itemCode
                                    .ItemCategoryID = oItemCategoryID.Procedure
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Procedure)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Procedure)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = procedureName
                                .BenefitCode = oBenefitCodes.Procedure
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = "Procedure: " + procedureName + ", done to Visit No: " + visitNo
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance

                            End With

                            lClaimDetails.Add(oClaimDetails)

                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProcedureItemStatus.Name, rowNo).Value = GetLookupDataDes(oItemStatusID.Done)
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardItems = New SmartCardItems()

                        With oSmartCardItems

                            .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                            .TransactionTime = GetTime(Now)
                            .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                            .DiagnosisCode = (0).ToString()
                            .DiagnosisDescription = "Unknown Disease"
                            .EncounterType = GetEncounterType(oItemCategoryID.Procedure)
                            .CodeType = "Mcode"
                            .Code = itemCode
                            .CodeDescription = procedureName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If


                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvProcedures.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            oSmartCardMembers.InvoiceNo = visitNo
            oSmartCardMembers.TotalBill = billFee
            oSmartCardMembers.TotalServices = lSmartCardItems.Count()
            oSmartCardMembers.CopayType = copayTypeID
            oSmartCardMembers.CopayAmount = totalCashAmount
            oSmartCardMembers.Gender = genderID
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then
                Dim oVisitTypeID As New LookupDataID.VisitTypeID()
                If Not UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, visitNo, oVisitTypeID.OutPatient) Then
                    Throw New ArgumentException("Error processing smart card information. Please edit the transactions and try again")
                    Return
                End If

            End If

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Function VerifyTheatreEntries() As Boolean

        Dim message As String

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgTheatre)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvTheatre.RowCount <= 1 Then
                message = "You have not registered theatre service(s)" + ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreService, "theatre service!")
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
            Me.tbcTheatreOperations.SelectTab(Me.tpgTheatre)
            VerifyTheatreEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveTheatre()
        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oSmartCardMembers As New SmartCardMembers()
        Dim lSmartCardItems As New List(Of SmartCardItems)

        Dim miniTransactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim operationDate As Date = DateEnteredIn(Me.dtpOperationDateTime, "Operation Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oSmartCardItems As SmartCardItems
            Dim smardCardNo As String = String.Empty
            Dim medicalCardNo As String = RevertText(RevertText(StringMayBeEnteredIn(Me.stbMemberCardNo), "/"c))
            Dim coverAmount As Decimal
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForItem, True, "Bill for Items!")
            Dim totalCashAmount As Decimal = 0
            Dim Message As String = String.Empty
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)
                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not medicalCardNo.ToUpper().Equals(smardCardNo.ToUpper()) Then
                    Message = "The medical card number  (" + StringMayBeEnteredIn(Me.stbMemberCardNo) + ") for this member is not the same " +
                              "as that forwarded from smart card (" + oSmartCardMembers.MedicalCardNumber + ") " +
                              ", the system does not allow to process numbers that don’t match"
                    Throw New ArgumentException(Message)
                End If

                If billFee > coverAmount Then Throw New ArgumentException("The benefit for this patient is not sufficient to cover the bill!")
                oSmartCardMembers.InvoiceNo = visitNo

            End If


            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = operationDate
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
                        miniTransactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        miniTransactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(miniTransactions)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)

                Dim lClaimDetails As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colICDTheatreCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colTheatreAmount, False, "amount!")
                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim payStatus As String = StringEnteredIn(cells, Me.colTheatrePayStatusID)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = (From data In _TheatreServices
                                                 Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper())
                                                 Select data.Field(Of String)("TheatreName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value) = True Then

                        Using oItems As New SyncSoft.SQLDb.Items()

                            With oItems

                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .LastUpdate = operationDate
                                .PayStatusID = String.Empty
                                .LoginID = CurrentUser.LoginID
                                .ItemStatusID = oItemStatusID.Offered

                            End With

                            lItems.Add(oItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                                .LastUpdate = operationDate
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .ItemStatusID = oItemStatusID.Offered
                                .PayStatusID = payStatus
                                .LoginID = CurrentUser.LoginID
                            End With

                            lItems.Add(oItems)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                            Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                                With oItemsCASH
                                    .VisitNo = visitNo
                                    .ItemCode = itemCode
                                    .ItemCategoryID = oItemCategoryID.Theatre
                                    .CashAmount = cashAmount
                                    .CashPayStatusID = payStatus
                                End With
                                lItemsCASH.Add(oItemsCASH)
                            End Using
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End If
                    End If
                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardItems = New SmartCardItems()

                        With oSmartCardItems

                            .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                            .TransactionTime = GetTime(Now)
                            .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                            .DiagnosisCode = (0).ToString()
                            .DiagnosisDescription = "Unknown Disease"
                            .EncounterType = GetEncounterType(oItemCategoryID.Theatre)
                            .CodeType = "Mcode"
                            .Code = itemCode
                            .CodeDescription = theatreName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Theatre)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Theatre)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = theatreName
                                .BenefitCode = oBenefitCodes.Theatre
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = "Theatre service: " + theatreName + ", offered to Visit No: " + visitNo
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance

                            End With

                            lClaimDetails.Add(oClaimDetails)

                        End Using
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, rowNo).Value = GetLookupDataDes(oItemStatusID.Offered)
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgTheatre)
                    ErrorMessage(ex)

                End Try

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvTheatre.Rows.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgTheatre)
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyPrescriptionsEntries() As Boolean

        Dim message As String

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgPrescriptions)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value).Equals(False) Then

                    Dim oVariousOptions As New VariousOptions()

                    Dim drugNo As String = RevertText(StringEnteredIn(row.Cells, Me.colDrugNo, "drug!"))
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

                    If halted Then

                        If hasAlternateDrugs Then
                            message = "Drug: " + drugName + " is currently on halt and has registered alternatives. " +
                                            "The system does not allow prescription of a drug on halt. " +
                                            ControlChars.NewLine + "Would you like to look at its alternatives? "
                            If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                        Else
                            message = "Drug: " + drugName + " is currently on halt and has no registered alternatives. " +
                                        "The system does not allow prescription of a drug on halt!"
                            Throw New ArgumentException(message)
                        End If

                        Throw New ArgumentException("Action Cancelled!")

                    ElseIf availableStock < quantity Then
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
                            Throw New ArgumentException(message)
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

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return True

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SavePrescriptions()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
       
        Dim oVariousOptions As New VariousOptions()
        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim lItemsEXT As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = RevertText(StringEnteredIn(cells, Me.colDrugNo))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100
                Dim payStatus As String = StringEnteredIn(cells, Me.colDrugPayStatusID)

                Try
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then
                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                                .LastUpdate = visitDate
                                .ItemCategoryID = oItemCategoryID.Drug
                                .ItemStatusID = oItemStatusID.Pending
                                .PayStatusID = payStatus
                                .LoginID = CurrentUser.LoginID

                            End With

                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lItems.Add(oItems)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Using oItemsEXT As New SyncSoft.SQLDb.ItemsEXT()
                        With oItemsEXT
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Dosage = StringEnteredIn(cells, Me.colDosage)
                            .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lItemsEXT.Add(oItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsEXT, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then

                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Drug
                                .CashAmount = cashAmount
                                .CashPayStatusID = payStatus
                            End With
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lItemsCASH.Add(oItemsCASH)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)


                    If oVariousOptions.AllowDrugsServiceFee AndAlso Me.dgvPrescription.RowCount > 0 Then
                        Dim oServicesf As New SyncSoft.SQLDb.Services()
                        Dim services As DataTable = oServicesf.GetServices(oServiceCodes.ServiceFee).Tables("Services")
                        Dim servicesRow As DataRow = services.Rows(0)
                        Dim unitPricesf As Decimal = DecimalMayBeEnteredIn(servicesRow, "StandardFee")
                        Dim serviceName As String = StringMayBeEnteredIn(servicesRow, "ServiceName")

                        Using oItems As New SyncSoft.SQLDb.Items()
                            With oItems
                                .VisitNo = visitNo
                                .ItemCode = oServiceCodes.ServiceFee
                                .Quantity = 1
                                .UnitPrice = unitPricesf
                                .ItemDetails = serviceName
                                .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .ItemCategoryID = oItemCategoryID.Service
                                .ItemStatusID = oItemStatusID.Pending
                                .PayStatusID = payStatus
                                .LoginID = CurrentUser.LoginID
                                .Save()

                            End With
                        End Using
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .VisitNo = visitNo
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgPrescriptions.Name)
                    ErrorMessage(ex)

                End Try
            Next

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgPrescriptions.Name)
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Function VerifyConsumableEntries() As Boolean

        Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables)
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
            Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables)
            VerifyConsumableEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SaveAttachedConsumables()
        Dim message As String

        Dim oVariousOptions As New VariousOptions()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvConsumables.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for consumable item!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Dim consumableNo As String = SubstringRight(StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Number!"))
                Dim consumableName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Name!"))
                IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                Dim consumableName As String = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False)
                Dim payStatus As String = StringEnteredIn(cells, Me.colConsumablePayStatusID)
                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = consumableNo
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = payStatus
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = consumableNo
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .CashAmount = cashAmount
                                .CashPayStatusID = payStatus
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
                    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.stbVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Consumable
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Consumable(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Catch ex As Exception

                            ErrorMessage(ex)
                        End Try

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next


        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables.Name)
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Function AllSaved() As Boolean

        Try
            Dim message As String = "Please ensure that all entries are saved on "
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.Enabled = True Then

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

                For Each page As TabPage In Me.tbcTheatreOperations.TabPages

                    Select Case page.Name

                        Case Me.tpgDiagnosis.Name

                            For Each row As DataGridViewRow In Me.dgvDiagnosis.Rows
                                If row.IsNewRow Then Exit For
                                If Not BooleanMayBeEnteredIn(row.Cells, Me.colDiagnosisSaved) Then
                                    DisplayMessage(message + Me.tpgDiagnosis.Text)
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgDiagnosis)
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
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgProcedures)
                                    Me.BringToFront()
                                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                    Return False
                                End If
                            Next

                        Case Me.tpgOtherItems.Name
                            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                                If row.IsNewRow Then Exit For
                                If Not BooleanMayBeEnteredIn(row.Cells, Me.colExtraChargeSaved) Then
                                    DisplayMessage(message + Me.tpgOtherItems.Text)
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgOtherItems)
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
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgTheatre)
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
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgPrescriptions)
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
                                    Me.tbcTheatreOperations.SelectTab(Me.tpgConsumables)
                                    Me.BringToFront()
                                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                    Return False
                                End If

                            Next

                    End Select
                Next
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub LoadTheatreOperations(ByVal visitNo As String)

        Dim oTheatreOperations As New SyncSoft.SQLDb.TheatreOperations()

        Try

            ResetControlsIn(Me.tpgGeneral)

            theatreReportSaved = False

            Dim theatreOperations As DataTable = oTheatreOperations.GetTheatreOperations(RevertText(visitNo)).Tables("TheatreOperations")

            If theatreOperations Is Nothing Then Return

            For Each row As DataRow In theatreOperations.Rows

                Me.stbPreoperativeDiagnosis.Text = StringMayBeEnteredIn(row, "PreoperativeDiagnosis")
                Me.stbPlannedProcedures.Text = StringMayBeEnteredIn(row, "PlannedProcedures")
                Me.stbPostoperativeInstructions.Text = StringMayBeEnteredIn(row, "PostoperativeInstructions")
                Me.stbReport.Text = StringMayBeEnteredIn(row, "Report")

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " Diagnosis - Grid "

    Private Sub dgvDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDiagnosis.CellBeginEdit

        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    End Sub

    Private Sub dgvDiagnosis_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colICDDiagnosisCode)
            Dim rowIndex As Integer

            If Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvDiagnosis.Rows(e.RowIndex).IsNewRow Then

                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvDiagnosis.NewRowIndex
                If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)


            ElseIf Me.ColDiagnosisSelect.Index.Equals(e.ColumnIndex) Then
                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvDiagnosis.NewRowIndex
                If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub dgvDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colICDDiagnosisCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvDiagnosis.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
                    Me.SetDiagnosisEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim odiagnosis As New SyncSoft.SQLDb.Diseases()


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colICDDiagnosisCode)



            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As DataTable = odiagnosis.GetDiseases(selectedItem).Tables("Diseases")
                If Diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
                Dim row As DataRow = Diagnosis.Rows(0)
                Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + enteredDisplay + ") can't be edited!")
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2


                If Not rowNo.Equals(selectedRow) Then

                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colICDDiagnosisCode)

                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As DataTable = odiagnosis.GetDiseases(enteredItem).Tables("Diseases")

                        If diagnosis Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
                        Dim row As DataRow = diagnosis.Rows(0)

                        Dim enteredDisplay As String = StringMayBeEnteredIn(row, "DiseaseName")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailSelectedDiagnosis(selectedRow, (SubstringRight(selectedItem)))

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseCode = '" + selectedItem + "'")
                Me.dgvDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCategories")
                Me.dgvDiagnosis.Item(Me.ColDiagnosedBy.Name, selectedRow).Value = CurrentUser.FullName
                Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailSelectedDiagnosis(ByVal selectedRow As Integer, selectedItem As String)
        Try

            Dim odiagnosis As New SyncSoft.SQLDb.Diseases()

            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim diagnosis As DataTable = odiagnosis.GetDiseases(selectedItem).Tables("Diseases")

            If diagnosis Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = diagnosis.Rows(0)
            With Me.dgvDiagnosis

                .Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCode")
                .Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                .Item(Me.colDiseaseCode.Name, selectedRow).Value = StringMayBeEnteredIn(row, "DiseaseName")
                .Item(Me.ColDiagnosedBy.Name, selectedRow).Value = CurrentUser.FullName
            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, selectedRow).Value = Me._DiagnosisCode.ToUpper()
            Throw ex

        End Try

    End Sub


    Private Sub dgvDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''           
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colICDDiagnosisCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDiagnosis
                .VisitNo = visitNo
                .DiseaseCode = diagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadDiagnosis(ByVal visitNo As String)

        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim diagnosis As DataTable = oDiagnosis.GetDiagnosis(RevertText(visitNo)).Tables("Diagnosis")
            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To diagnosis.Rows.Count - 1

                Dim row As DataRow = diagnosis.Rows(pos)

                With Me.dgvDiagnosis
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseName")
                    .Item(Me.colICDDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.ColDiagnosedBy.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



    

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
                If Me.dgvProcedures.Rows.Count > 1 Then Me.SetProceduresEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colProcedureQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateProcedureAmount(selectedRow)
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
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oItems.Delete())

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
                .Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
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

    Private Sub LoadProcedures(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim procedure As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Procedure).Tables("Items")

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
    Private Sub ShowTheatreServiceDetails(ByVal theatreCode As String, ByVal pos As Integer)

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try

            Dim theatreServices As DataTable = oTheatreServices.GetTheatreServices(theatreCode).Tables("TheatreServices")

            If theatreServices Is Nothing OrElse theatreCode Is Nothing Then Return
            Dim row As DataRow = theatreServices.Rows(0)
            Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

            With Me.dgvTheatre
                .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "TheatreName")
                .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                .Item(Me.colTheatrePayStatusID.Name, pos).Value = StringEnteredIn(row, "PayStatusID")
                .Item(Me.colTheatreSaved.Name, pos).Value = True

            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadTheatreServices(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre).Tables("Items")

            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatre.Rows.Count - 1

                Dim row As DataRow = theatre.Rows(pos)

                With Me.dgvTheatre
                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colTheatreService.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colTheatrePayStatusID.Name, pos).Value = StringEnteredIn(row, "PayStatusID")
                    .Item(Me.colTheatreSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvTheatre_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellClick
        Try
            Me.Cursor = Cursors.WaitCursor

          
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
            'fQuickSearch.ShowDialog(Me)
            Dim rowIndex As Integer

            If Me.colTheatreOperationsSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvTheatre.Rows(e.RowIndex).IsNewRow Then

                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvTheatre.NewRowIndex
                If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)

            ElseIf Me.colTheatreOperationsSelect.Index.Equals(e.ColumnIndex) Then
                fQuickSearch.ShowDialog(Me)
                rowIndex = Me.dgvTheatre.NewRowIndex
                If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
            End If

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("TheatreServices", "Theatre Code", "Theatre", Me.LoadTheatreServices(), "TheatreServicesFullName",
            '                                                         "TheatreCode", "TheatreServicesFullName", Me.dgvTheatre, Me.colICDTheatreCode, e.RowIndex)

            'Me._TheatreCode = StringMayBeEnteredIn(Me.dgvTheatre.Rows(e.RowIndex).Cells, Me.colICDTheatreCode)

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'If Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvTheatre.Rows(e.RowIndex).IsNewRow Then

            '    Me.dgvTheatre.Rows.Add()

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetTheatreEntries(e.RowIndex)

            'ElseIf Me.ColTheatreSelect.Index.Equals(e.ColumnIndex) Then

            '    fSelectItem.ShowDialog(Me)
            '    Me.SetTheatreEntries(e.RowIndex)




            'If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreService.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreService)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
            If Me.dgvTheatre.Rows.Count > 1 Then

                Me.SetTheatreEntries(selectedRow)

            End If

            If e.ColumnIndex.Equals(Me.colICDTheatreCode.Index) Then
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)


            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)
       
        Try
            Dim otheatre As New SyncSoft.SQLDb.TheatreServices()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colICDTheatreCode)



            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim theatre As DataTable = otheatre.GetTheatreServices(selectedItem).Tables("TheatreServices")
                If theatre Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
                Dim row As DataRow = theatre.Rows(0)
                Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre Service (" + enteredDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2


                If Not rowNo.Equals(selectedRow) Then

                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colICDTheatreCode)

                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim theatre As DataTable = otheatre.GetTheatreServices(enteredItem).Tables("TheatreServices")

                        If theatre Is Nothing OrElse String.IsNullOrEmpty(enteredItem) Then Return
                        Dim row As DataRow = theatre.Rows(0)

                        Dim enteredDisplay As String = StringMayBeEnteredIn(row, "TheatreName")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                        DisplayMessage("Theatre service (" + enteredDisplay + ") already entered!")
                        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreCode
                        Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            'Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colICDTheatreCode)

            'If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    Dim theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
            '    Dim theatreDisplay As String = (From data In theatre
            '                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreCode.ToUpper())
            '                                    Select data.Field(Of String)("TheatreName")).First()
            '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '    DisplayMessage("Theatre (" + theatreDisplay + ") can't be edited!")
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreCode
            '    Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '    Return
            'End If


            'For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2


            '    If Not rowNo.Equals(selectedRow) Then
            '        Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colICDTheatreCode)
            '        If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '            Dim _Theatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
            '            Dim enteredDisplay As String = (From data In _Theatre
            '                                            Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
            '                                            Select data.Field(Of String)("TheatreName")).First()
            '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '            DisplayMessage("Theatre (" + enteredDisplay + ") already entered!")
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = _TheatreNameValue
            '            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Selected = True
            '            Return
            '        End If
            '    End If
            'Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If theatreServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

            For Each row As DataRow In theatreServices.Select("TheatreCode = '" + selectedItem + "'")
                Me.dgvTheatre.Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, selectedRow).Value = 1
                Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                    Me.dgvTheatre.Item(Me.colTheatrePayStatusID.Name, selectedRow).Value = (oPayStatusID.NA)
                Else
                    Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                    Me.dgvTheatre.Item(Me.colTheatrePayStatusID.Name, selectedRow).Value = (oPayStatusID.NotPaid)
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailTheatreService(selectedRow, RevertText(SubstringRight(selectedItem)))
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailTheatreService(ByVal selectedRow As Integer, selectedItem As String)
        Try
            Dim theatreServiceSelected As String = String.Empty
            Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()


            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim theatreService As DataTable = oTheatreServices.GetTheatreServices(selectedItem).Tables("TheatreServices")

            If theatreService Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = theatreService.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim theatreName As String = StringEnteredIn(row, "TheatreName", "Theatre Service Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvTheatre

                .Item(Me.colICDTheatreCode.Name, selectedRow).Value = StringEnteredIn(row, "TheatreCode")
                .Item(Me.colTheatreService.Name, selectedRow).Value = StringEnteredIn(row, "TheatreName")
                .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = Me._TheatreCode.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvTheatre_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserAddedRow
        Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

         Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvTheatre.Item(Me.colTheatreService.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oItems.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForTheatre()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1

            If IsNumeric(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvTheatre.Item(Me.colTheatreAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Function LoadTheatreServices() As DataTable

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()
        Dim oSetupData As New SetupData()
        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices
            If Not InitOptions.LoadTheatreServicesAtStart Then
                theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
                oSetupData.TheatreServices = theatreServices
            Else : theatreServices = oSetupData.TheatreServices
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return theatreServices
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

#End Region

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit
        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

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
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))


            Dim availableStock As Integer = GetAvailableStock(selectedItem)

            If availableStock.Equals(0) Then
                Me.dgvPrescription.Rows(selectedRow).DefaultCellStyle.BackColor = Color.MistyRose
            End If

            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Rows.RemoveAt(selectedRow)
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailPrescribedDrug(selectedRow, RevertText(SubstringRight(selectedItem)))
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
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvPrescription.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer, selectedItem As String)
        Try
            Dim message As String
            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()


            If String.IsNullOrEmpty(selectedItem) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim drugs As DataTable = oDrugs.GetDrugs(selectedItem).Tables("Drugs")

            If drugs Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim row As DataRow = drugs.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim availableStock As Integer = GetAvailableStock(selectedItem)
            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = selectedItem.ToUpper()
                .Item(Me.colAvailableStock.Name, selectedRow).Value = availableStock
                .Item(Me.colDrug.Name, selectedRow).Value = drugName
                .Item(Me.colOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colPrescriptionGroup.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colDrugItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                .Item(Me.ColPrescribedby.Name, selectedRow).Value = CurrentUser.FullName

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Drug).Equals(True) Then
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
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(selectedItem)

            ElseIf availableStock <= 0 AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is out of stock and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(selectedItem)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
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
            Dim drugNo As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo)
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

    Private Sub LoadPrescriptions(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug).Tables("Items")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName")
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
                    .Item(Me.ColPrescribedby.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
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



    Private Function GetDrugs() As DataTable

        Dim drugs As DataTable
        Dim oSetupData As New SetupData()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            ' Load from drugs

            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return drugs
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub dgvPrescription_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvPrescription, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvPrescription.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colDrugSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPrescription.Rows(e.RowIndex).IsNewRow Then

                Me.dgvPrescription.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.colDrugSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


#End Region

#Region " ExtraCharge - Grid "

    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colItemName, extraChargeItems, "ExtraItemFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExtraCharge_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExtraCharge.CellBeginEdit

        If e.ColumnIndex <> Me.colItemName.Index OrElse Me.dgvExtraCharge.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
        _ExtraItemValue = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colItemName)

    End Sub

    Private Sub dgvExtraCharge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraCharge.CellEndEdit

        Try

            If Me.colItemName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colItemName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvExtraCharge.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colItemName)

                    If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, selectedRow).Value).Equals(True) Then

                        DisplayMessage("Extra Item Name (" + _ExtraItemValue + ") can't be edited!")
                        Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Value = _ExtraItemValue
                        Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Selected = True

                        Return

                    End If

                    For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(rowNo).Cells, Me.colItemName)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Extra Item Name (" + enteredItem + ") already selected!")
                                Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Value = _ExtraItemValue
                                Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If

                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
                    Dim extraItemCode As String = SubstringRight(selectedItem)

                    If extraChargeItems Is Nothing OrElse String.IsNullOrEmpty(extraItemCode) Then Return
                    Dim unitPrice As Decimal = GetCustomFee(extraItemCode, oItemCategoryID.Extras, billNo, billModesID, associatedBillNo)

                    For Each row As DataRow In extraChargeItems.Select("ExtraItemCode = '" + extraItemCode + "'")
                        Dim quantity As Integer = 1
                        Me.dgvExtraCharge.Item(Me.colExtraChargeQuantity.Name, selectedRow).Value = quantity
                        Me.dgvExtraCharge.Item(Me.colExtraChargeUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CalculateExtraChargeAmount()
                    Me.CalculateBillForExtraCharge()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                End If

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateExtraChargeAmount()
                Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateExtraChargeAmount()
                Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExtraCharge.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvExtraCharge.Item(Me.colItemName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvExtraCharge.UserDeletedRow
        Me.CalculateBillForExtraCharge()
    End Sub

    Private Sub dgvExtraCharge_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExtraCharge.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateExtraChargeAmount()

        Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeUnitPrice)

        Me.dgvExtraCharge.Item(Me.colExtraChargeAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForExtraCharge()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colExtraChargeAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadExtraCharge(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvExtraCharge.Rows.Clear()

            ' Load items not yet paid for

            Dim chargeItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Extras).Tables("Items")
            If chargeItems Is Nothing OrElse chargeItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To chargeItems.Rows.Count - 1

                Dim row As DataRow = chargeItems.Rows(pos)
                With Me.dgvExtraCharge

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colItemName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colExtraChargeQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.ColNotesOtherItems.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colExtraChargeUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colExtraChargeAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colExtraChargeSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForExtraCharge()
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
            Dim primaryDoctor As String = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 21 * widthTopFirst
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
                    .DrawString("Primary Doctor: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
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
            If Me.dgvDiagnosis.RowCount > 1 Then
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

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 1

                If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                    line += 1

                    Dim lineNo As String = (line).ToString()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim diseaseCode As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)
                    Dim diagnosisDisplay As String = StringMayBeEnteredIn(cells, Me.colDiseaseCode)
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
                    Dim theatreCode As String = StringMayBeEnteredIn(cells, Me.colICDTheatreCode)
                    Dim miniTheatre As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                    Dim theatreName As String = StringMayBeEnteredIn(cells, Me.colTheatreService)
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
                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colDrug)
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
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)
            ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colConsumablePayStatusID.Name, selectedRow).Value = oPayStatusID.NotPaid
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
            '  Me.dgvConsumables.EndEdit()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function LoadConsumables(ByVal visitNo As String) As Boolean

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable).Tables("Items")
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

    Private Sub SaveExtraChargeItems()

        Dim message As String
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            If Me.dgvExtraCharge.RowCount <= 1 Then Throw New ArgumentException("Must register At least one entry for extra charge item!")

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                Dim itemCode As String = SubstringRight(StringEnteredIn(row.Cells, Me.colItemName, "Item Code!"))
                Dim itemName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colItemName, "Item Name!"))
                IntegerEnteredIn(row.Cells, Me.colExtraChargeQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = StringMayBeEnteredIn(Me.stbPrimaryDoctor)
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID

                    End With

                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colItemName))
                Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colItemName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colExtraChargeQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeAmount, False)

                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringEnteredIn(cells, Me.ColNotesOtherItems, "Notes")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                            .ItemCategoryID = oItemCategoryID.Extras
                            .ItemStatusID = oItemStatusID.Offered
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Extras
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

                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Extras)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Extras)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = itemName
                                .BenefitCode = oBenefitCodes.Extras
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance

                            End With

                            lClaimDetails.Add(oClaimDetails)

                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value).Equals(False) Then
                        message = itemName + " item will automatically be marked as offered. You won’t be able to remove it." +
                                                ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Continue For

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcTheatreOperations.SelectTab(Me.tpgOtherItems.Name)
                    Throw ex


                End Try

            Next

        Catch ex As Exception
            Me.tbcTheatreOperations.SelectTab(Me.tpgOtherItems.Name)
            Throw ex
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    

#Region " Popup Menu "

    Private Sub cmsTheatreOperations_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsTheatreOperations.Opening

        Select Case Me.tbcTheatreOperations.SelectedTab.Name

            Case Me.tpgDiagnosis.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgProcedures.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgTheatre.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgPrescriptions.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Me.tpgConsumables.Name
                Me.cmsTheatreOperationsQuickSearch.Visible = True

            Case Else
                Me.cmsTheatreOperationsQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsTheatreOperationsQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsTheatreOperationsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcTheatreOperations.SelectedTab.Name

                Case Me.tpgDiagnosis.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colICDDiagnosisCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDiagnosis.NewRowIndex
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
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colICDTheatreCode)
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

                Case Me.tpgConsumables.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvConsumables.NewRowIndex
                    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadAttachedConsumables(selectedRow As Integer, procedureCode As String)

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
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colConsumablePayStatusID.Name, selectedRow).Value = oPayStatusID.NA
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), count)
                    Me.dgvConsumables.EndEdit()
                    count += 1

                End With

            Next

        End If

    End Sub

    Private Sub LoadAttachedTheatreServices(selectedRow As Integer, procedureCode As String)

        Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim theatreServices As DataTable = oItems.GetAttachedPossibleTheatreServices(procedureCode).Tables("PossibleAttachedItems")
        If theatreServices Is Nothing OrElse theatreServices.Rows.Count < 1 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim count As Integer = Me.dgvTheatre.Rows.Count - 1

        If selectedRow = dgvTheatre.Rows.Count - 2 Then

            For pos As Integer = 0 To theatreServices.Rows.Count - 1
                Dim row As DataRow = theatreServices.Rows(pos)
                With Me.dgvTheatre

                    .Rows.Add()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim theatreServiceNo As String = StringEnteredIn(row, "ItemCode")
                    Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                    Dim itemcode As String = StringEnteredIn(row, "ItemCode")
                    Dim unitPrice As Decimal = GetCustomFee(itemcode, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim amount As Decimal = quantity * unitPrice
                    .Item(Me.colTheatreService.Name, count).Value = StringEnteredIn(row, "TheatreName")
                    .Item(Me.colICDTheatreCode.Name, count).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreQuantity.Name, count).Value = quantity
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreNotes.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colTheatrePayStatusID.Name, pos).Value = (oPayStatusID.NA)
                    .Item(Me.colTheatreSaved.Name, pos).Value = False
                    count += 1

                End With

            Next

        End If

    End Sub

    Private Sub LoadAttachedPrescriptions(selectedRow As Integer, procedureCode As String)

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
                    Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
                    Dim amount As Decimal = quantity * unitPrice


                    .Item(Me.colDrug.Name, count).Value = StringEnteredIn(row, "DrugFullName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDrugQuantity.Name, count).Value = quantity
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = unitPrice
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, count).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                    .Item(Me.colDrugPayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                    .Item(Me.colDrugPayStatusID.Name, pos).Value = oPayStatusID.NA
                    .Item(Me.ColPrescribedby.Name, selectedRow).Value = CurrentUser.FullName
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = False
                    count += 1

                End With

            Next

        End If

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

    Private Sub dgvProcedures_TextChanged(sender As Object, e As EventArgs) Handles dgvProcedures.TextChanged
        'Me.LoadPossibleConsumables()
    End Sub



    Private Sub pnlVisitNo_Paint(sender As Object, e As PaintEventArgs) Handles pnlVisitNo.Paint

    End Sub

#End Region

    Private Sub cboOperationClassID_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboOperationClassID.SelectedValueChanged
        Try

            Dim oOperationClassID As New LookupDataID.OperationClassID

            If Me.cboOperationClassID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboOperationClassID.SelectedValue.ToString()) Then Return

            Dim _operationClass As String = Me.cboOperationClassID.SelectedValue.ToString()

            If _operationClass.Equals(oOperationClassID.Minor.ToUpper()) Then
                Me.cboLeadSurgeon.Enabled = False
                Me.stbOtherSurgeon.Enabled = False
                Me.cboLeadAnaesthetist.Enabled = False
                Me.stbOtherAnaesthetist.Enabled = False

            Else
                Me.cboLeadSurgeon.Enabled = True
                Me.stbOtherSurgeon.Enabled = True
                Me.cboLeadAnaesthetist.Enabled = True
                Me.stbOtherAnaesthetist.Enabled = True
            End If
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    

End Class