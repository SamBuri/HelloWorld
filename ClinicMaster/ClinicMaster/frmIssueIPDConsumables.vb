
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

Public Class frmIssueIPDConsumables

#Region " Fields "

    Private defaultRoundNo As String = String.Empty
    Private tipCoPayValueWords As New ToolTip()
    Private currentAllSaved As Boolean = True
    Private currentRoundNo As String = String.Empty

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

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oVariousOptions As New VariousOptions()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

    Private ConsumableLabelBarCode As Collection
    Private WithEvents docConsumableLabel As New PrintDocument()
    Private WithEvents docBarcodes As New PrintDocument()
    Private toPrintRow As Integer = -1
    Private printFontName As String = "Courier New"
    Private pageNo As Integer

#End Region

#Region " Validations "

#End Region

    Private Sub frmIssueIPDConsumables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.ShowSentIPDAlerts()
            Me.ShowToOrderConsumables()
            Me.ShowToExpireConsumables()
            Me.SetDefaultLocation()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnSave, AccessRights.Write)

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

    Private Sub EnableDefaultCTRLS(ByVal state As Boolean)

        Me.btnFindAdmissionNo.Enabled = state
        Me.btnFindRoundNo.Enabled = state
        Me.btnLoadToPharmacyIPDDoctor.Enabled = state
        Me.pnlAlerts.Enabled = state

    End Sub

    Private Sub frmIssueIPDConsumables_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowSentIPDAlerts()
    End Sub

    Private Sub frmIssueIPDConsumables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvConsumables.RowCount = 1 Then
            message = "Current Consumables is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current Consumabless are not saved. " + ControlChars.NewLine + "Just close anyway?"
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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingIPDItems As New frmPendingIPDItems(Me.stbRoundNo, AlertItemCategory.Consumable)
            fPendingIPDItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) AndAlso Not String.IsNullOrEmpty(currentRoundNo) Then
                Me.stbRoundNo.Text = currentRoundNo
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

            Me.DetailConsumableLocationBalance()

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
        accessCashServices = False
        provisionalIPDDiagnosis = String.Empty
        billModesID = String.Empty
        doctorStaffNo = String.Empty
        Me.stbVisitCategory.Clear()
        Me.stbAttendingDoctor.Clear()
        Me.stbAdmissionDateTime.Clear()
        Me.stbRoundDateTime.Clear()
        ' Me.stbAdmissionNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgConsumables)
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
            Me.LoadConsumablesData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateRounds)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadConsumablesData(ByVal roundNo As String)

        Try

            Me.ShowPatientDetails(roundNo)
            Me.LoadConsumablesToIssue(roundNo)
            Me.GenerateBarcode()
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal roundNo As String)

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

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadConsumablesToIssue(ByVal roundNo As String)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvConsumables.Rows.Clear()
            If String.IsNullOrEmpty(roundNo) Then Return

            Dim consumablesToIssue As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Consumable, oItemStatusID.Pending).Tables("IPDItems")

            If consumablesToIssue Is Nothing OrElse consumablesToIssue.Rows.Count < 1 Then

                Dim message As String
                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)

                If String.IsNullOrEmpty(billMode) Then Return

                If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                    message = "This visit has no pending Consumables or is waiting for payment first!"
                Else : message = "This visit has no pending Consumables!"
                End If

                DisplayMessage(message)
                Return

            End If

            For pos As Integer = 0 To consumablesToIssue.Rows.Count - 1

                Dim row As DataRow = consumablesToIssue.Rows(pos)

                Dim consumableNo As String = StringEnteredIn(row, "ItemCode")
                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvConsumables

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colConsumableNo.Name, pos).Value = consumableNo
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "PayStatus")
                    Me.ShowConsumableDetails(consumableNo, pos)

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesTotalBill()
            Me.DetailConsumableLocationBalance()

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

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumables As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumables Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumables.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region " IPDAlerts "

    Private Function ShowSentIPDAlerts() As Integer

        Dim oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            iPDAlerts = oIPDAlerts.GetIPDAlerts(oAlertTypeID.Consumable).Tables("IPDAlerts")

            Dim iPDAlertsNo As Integer = iPDAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblIPDAlerts.Text = "Sent Consumables: " + iPDAlertsNo.ToString()
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

    Private Function ShowToOrderConsumables() As Integer

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oConsumableItems.CountToOrderConsumableItems()
            Me.lblToOrderConsumables.Text = "To Order Consumables: " + records.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowToExpireConsumables() As Integer

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim records As Integer = oConsumableItems.CountToExpireConsumableItems(oVariousOptions.ExpiryWarningDays)
            Me.lblToExpireConsumables.Text = "To Expire/Expired Consumables: " + records.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Dim fIPDAlerts As New frmIPDAlerts(oAlertTypeID.Consumable, Me.stbRoundNo)
        fIPDAlerts.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowDispensingData()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewToOrderConsumablesList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToOrderConsumablesList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim fToOrderConsumables As New frmToOrderItems(ItemsTo.Order, oItemCategoryID.Consumable, False)
        fToOrderConsumables.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowToOrderConsumables()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnViewToExpireConsumablesList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToExpireConsumablesList.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim fToOrderConsumables As New frmToOrderItems(ItemsTo.Expire, oItemCategoryID.Consumable, False)
        fToOrderConsumables.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowToExpireConsumables()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

                Case Me.tpgConsumables.Name

                    Me.btnSave.Visible = True
                    Me.pnlNavigateRounds.Visible = True

                Case Else

                    Me.btnSave.Visible = True
                    Me.pnlNavigateRounds.Visible = True

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
            If Me.dgvConsumables.RowCount >= 1 Then
                If Me.dgvConsumables.RowCount = 1 Then
                    message = "Please ensure that current Consumables is saved!"
                Else : message = "Please ensure that current Consumabless are saved!"
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
        Dim OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()
        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAdmissionStatusID As New LookupDataID.AdmissionStatusID()

        Dim lIPDItems As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim message As String
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Dim roundDate As Date = DateEnteredIn(Me.stbRoundDateTime, "Round Date Time!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.RowCount < 1 Then Throw New ArgumentException("Must register at least one entry for Consumables " +
                                                ControlChars.NewLine + "If this is a cash patient, ensure that payment is done first!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for Consumables!")

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
            '    For Each row As DataGridViewRow In Me.dgvConsumables.Rows
            '        If row.IsNewRow Then Exit For
            '        If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
            '            Dim payStatus As String = StringEnteredIn(row.Cells, Me.colPayStatus, "pay status!")
            '            If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) Then
            '                cashNotPaid = True
            '                Exit For
            '            End If
            '        End If
            '        cashNotPaid = False
            '    Next

            '    If cashNotPaid Then Throw New ArgumentException("The system does not allow dispensing of not paid for Consumable(s) for a discharged cash visit!")

            'End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
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
            Using oExtraBills As New SyncSoft.SQLDb.ExtraBills()

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

            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me, ErrProvider)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
            If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
               Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                message = "Selected location " + location + " is not the same as " + InitOptions.Location +
                         " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    Dim consumableNo As String = StringEnteredIn(cells, Me.colConsumableNo, "Consumable Number!")
                    Dim consumableName As String = StringEnteredIn(cells, Me.colConsumableName, "Consumable name!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, True, "amount!")

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If quantity > 0 AndAlso unitsInStock < quantity Then
                        If Not oVariousOptions.AllowDispensingToNegative() Then

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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Consumable, consumableNo)
                    If quantity > 0 AndAlso locationBalance < quantity Then
                        If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                            message = "The system does not allow issuing of Consumable: " + consumableName + ", with unit(s) not present at " + location + "!"
                            Throw New ArgumentException(message)
                        Else
                            message = "You are about to issue Consumable: " + consumableName + ", with unit(s) not present at " + location + ". " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowDispensingExpiredConsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " +
                                "The system does not allow to dispence a Consumable that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + consumableName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + consumableName + " is not set. The system can not verify when this Consumable will expire!"
                        DisplayMessage(message)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems

                            .RoundNo = roundNo
                            .ItemCode = consumableNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .LastUpdate = roundDate
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Offered

                        End With
                        lIPDItems.Add(oIPDItems)
                    End Using

                    Using oInventory As New SyncSoft.SQLDb.Inventory()
                        With oInventory
                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = consumableNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = quantity
                            .Details = "Consumable(s) Issued to Round No: " + roundNo
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

                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)
                    Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice, True)

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = consumableNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = roundDate
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
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
                                .ItemCode = consumableNo
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
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

            

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

            DoTransactions(transactions)
            If Me.chkPrintDrugBarcode.Checked Then Me.PrintConsumableBarcodes()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadConsumablesToIssue(roundNo)
                    Exit For
                End If
                allSelected = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If allSelected Then
                Me.dgvConsumables.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlNavigateRounds)
                Me.ClearControls()
                Me.SetDefaultLocation()
                'Me.LoadToPharmacyVisits()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentIPDAlerts()
            Me.ShowToOrderConsumables()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

#Region " Consumables - Grid "

    Private Sub CalculateConsumablesAmount(selectedRow As Integer)

        Dim quantity As Integer = IntegerMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colUnitPrice)

        Me.dgvConsumables.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateConsumablesTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForConsumables.Clear()

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                totalBill += amount
            End If
        Next

        Me.stbBillForConsumables.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        If e.ColumnIndex.Equals(Me.colInclude.Index) OrElse e.ColumnIndex.Equals(Me.colQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colUnitPrice.Index) Then
            Me.CalculateConsumablesAmount(Me.dgvConsumables.CurrentCell.RowIndex)
            Me.CalculateConsumablesTotalBill()
        End If

    End Sub

    Private Sub DetailConsumableLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim ConsumableNo As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableNo)
                If String.IsNullOrEmpty(ConsumableNo) Then Continue For

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = String.Empty
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Consumable, ConsumableNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

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
        Me.EnableNavigateRoundsCTLS(Me.chkNavigateRounds.Checked)
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
            Me.LoadConsumablesData(roundNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Consumables Extras "

    Private Sub cmsConsumables_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsConsumables.Opening

        If Me.dgvConsumables.ColumnCount < 1 OrElse Me.dgvConsumables.RowCount < 1 Then
            Me.cmsConsumablesCopy.Enabled = False
            Me.cmsConsumablesSelectAll.Enabled = False
            Me.cmsConsumablesInventory.Enabled = False
            Me.cmsConsumablesEditConsumables.Enabled = False
            Me.cmsConsumablesRefresh.Enabled = False
        Else
            Me.cmsConsumablesCopy.Enabled = True
            Me.cmsConsumablesSelectAll.Enabled = True
            Me.cmsConsumablesInventory.Enabled = True
            Me.cmsConsumablesEditConsumables.Enabled = True
            Me.cmsConsumablesRefresh.Enabled = True
            Security.Apply(Me.cmsConsumables, AccessRights.Write)
        End If

    End Sub

    Private Sub cmsConsumablesCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsConsumablesCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvConsumables.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvConsumables))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsConsumablesSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsConsumablesSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvConsumables.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsConsumablesInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsConsumablesInventory.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim rowIndex As Integer = Me.dgvConsumables.CurrentCell.RowIndex
            Dim ConsumableNo As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowIndex).Cells, Me.colConsumableNo)
            Dim fInventory As New frmInventory(oItemCategoryID.Consumable, ConsumableNo)
            fInventory.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            If String.IsNullOrEmpty(roundNo) Then Return
            Me.LoadConsumablesData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsConsumablesEditConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsConsumablesEditConsumables.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))

            Dim fIPDConsumables As New frmIPDConsumables(roundNo)
            fIPDConsumables.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadConsumablesData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsConsumablesRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmsConsumablesRefresh.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round's No!"))
            Me.LoadConsumablesData(roundNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Function GetInvoiceDetails(invoiceNo As String, extraBillNo As String) As List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)
        Dim itemCategoryID As String = oItemCategoryID.Consumable()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()
        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

            If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colConsumableNo, "drug no!")
                Dim drugName As String = StringEnteredIn(cells, Me.colConsumableName, "Consumable name!")
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

#Region "Print Barcode Prescription"

    Private Sub PrintConsumableBarcodes()

        Dim Message As String
        Try
            If Me.chkPrintDrugBarcode.Checked = True Then

                For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Message = "You are about to print Consumable Bar Code for " + CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, row.Index).Value) +
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
            If Me.dgvConsumables.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Pharmacy request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
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
        ConsumableLabelBarCode = New Collection()

        Try

            Dim rect As New Rectangle(0, 10, 200, 85)
            Dim sf As New StringFormat
            sf.LineAlignment = StringAlignment.Center
            Dim printFont10_Normal As New Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point)
            rect = New Rectangle(0, 10, 200, 15)
            e.Graphics.DrawRectangle(Pens.White, rect)

            Dim h, w As Integer

            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(toPrintRow).Cells
            Dim ConsumableName As String = "(CONS) - " + " " + cells.Item(Me.colConsumableName.Name).Value.ToString()
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
            e.Graphics.DrawString(ConsumableName.ToString, printFont10_Normal, Brushes.Black, rect, sf)
            e.Graphics.DrawRectangle(Pens.White, rect)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region

End Class