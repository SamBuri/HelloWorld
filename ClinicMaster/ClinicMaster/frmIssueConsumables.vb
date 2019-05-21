
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports GenCode128

Public Class frmIssueConsumables

#Region " Fields "

    Private defaultVisitNo As String = String.Empty
    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty

    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now

    Private billModesID As String = String.Empty
    Private accessCashServices As Boolean = False

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private tipCoPayValueWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()

    Private oPayTypeID As New LookupDataID.PayTypeID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private oVariousOptions As New VariousOptions()
    Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private smartLocationID As Integer
    Private genderID As String
    Private coPayTypeID As String

    Private ConsumableLabelBarCode As Collection
    Private WithEvents docConsumableLabel As New PrintDocument()
    Private WithEvents docBarcodes As New PrintDocument()
    Private toPrintRow As Integer = -1
    Private printFontName As String = "Courier New"
    Private pageNo As Integer
#End Region

    Private Sub frmIssueConsumables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)

            Me.ShowSentAlerts()
            Me.ShowToOrderConsumables()
            Me.ShowToExpireConsumables()
            Me.SetDefaultLocation()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnSave, AccessRights.Write)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then

                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.ShowDispensingData()
                Me.ProcessTabKey(True)
                Me.EnableDefaultCTRLS(False)

            Else : Me.stbVisitNo.ReadOnly = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub EnableDefaultCTRLS(ByVal state As Boolean)

        Me.btnFindVisitNo.Enabled = state
        Me.btnLoadToIssueConsumables.Enabled = state
        Me.pnlAlerts.Enabled = state
        Me.btnFindByFingerprint.Enabled = state

    End Sub

    Private Sub frmIssueConsumables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvConsumables.RowCount = 1 Then
            message = "Current consumable is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current consumables are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

    Private Sub frmIssueConsumables_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.ShowSentAlerts()
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
            fFindVisitNo.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadToIssueConsumables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadToIssueConsumables.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Consumable)
            fPendingItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowDispensingData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, True)
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

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbPrimaryDoctor.Clear()
        Me.stbAge.Clear()
        Me.stbTotalVisits.Clear()
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        billModesID = String.Empty
        accessCashServices = False
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.stbCashAccountBalance.Clear()
        Me.tipCashAccountBalanceWords.RemoveAll()
        Me.stbBillMode.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.spbPhoto.Image = Nothing
        Me.dgvConsumables.Rows.Clear()
        ResetControlsIn(Me.pnlBill)

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
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default

        End Try

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

    Private Sub ShowDispensingData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.pnlNavigateVisits)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadConsumablesData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateVisits)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadConsumablesData(ByVal visitNo As String)

        Try

            '''''''''''''''''''''''''''''''''
            Me.ClearControls()

            '''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadToIssueConsumables(visitNo)
            Me.GenerateBarcode()
            '''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.tipOutstandingBalanceWords.RemoveAll()
            Me.tipCashAccountBalanceWords.RemoveAll()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.genderID = StringEnteredIn(row, "GenderID")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.chkSmartCardApplicable.Checked = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.coPayTypeID = StringMayBeEnteredIn(row, "CoPayTypeID")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.nbxOutstandingBalance.Value = FormatNumber(DecimalMayBeEnteredIn(row, "OutstandingBalance"), AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(DecimalMayBeEnteredIn(row, "OutstandingBalance")))
            Me.stbCashAccountBalance.Text = FormatNumber(DecimalMayBeEnteredIn(row, "CashAccountBalance"), AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.stbCashAccountBalance, NumberToWords(DecimalMayBeEnteredIn(row, "CashAccountBalance")))
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.RowCount >= 1 Then
                If Me.dgvConsumables.RowCount = 1 Then
                    message = "Please ensure that current consumable is saved!"
                Else : message = "Please ensure that current consumables are saved!"
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

                Me.LoadConsumablesData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadConsumablesData(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim message As String
        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lItems As New List(Of DBConnect)
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim lInvoices As New List(Of DBConnect)
        Dim lInvoiceDetails As New List(Of DBConnect)

        Dim oSmartCardMembers As New SmartCardMembers()
        Dim lSmartCardItems As New List(Of SmartCardItems)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim visitDate As Date = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))

            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.RowCount < 1 Then Throw New ArgumentException("Must register at least one entry for consumables " +
                                                ControlChars.NewLine + "If this is a cash patient, ensure that payment is done first!")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for consumables!")

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
                For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringEnteredIn(row.Cells, Me.colConsumablePayStatus, "pay status!")
                        Dim amount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colConsumableAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso amount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow dispensing of not paid for consumable(s) for a cash visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.AllowAccessCoPayServices AndAlso Not coPayType.ToUpper().Equals(_NACoPayType.ToUpper()) AndAlso
             Not billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then

                Dim cashNotPaid As Boolean = False
                For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                    If row.IsNewRow Then Exit For
                    If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                        Dim payStatus As String = StringMayBeEnteredIn(row.Cells, Me.colCashPayStatus)
                        Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row.Cells, Me.colCashAmount, True)
                        If payStatus.ToUpper().Equals(notPaidPayStatus.ToUpper()) AndAlso cashAmount > 0 Then
                            cashNotPaid = True
                            Exit For
                        End If
                    End If
                    cashNotPaid = False
                Next

                message = "The system does not allow dispensing of consumable(s) whose co-pay percent or value is not paid for a co-pay visit!"
                If cashNotPaid Then Throw New ArgumentException(message)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "quantity!")
                    If quantity < 0 Then Throw New ArgumentException("Negative quantity not allowed!")
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
                        .VisitDate = visitDate
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
            Dim billFee As Decimal = DecimalEnteredIn(Me.stbBillForItem, True, "Bill for Consumables!")
            Dim copayAmount As Decimal = 0
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                oSmartCardMembers = ProcessSmartCardData(patientNo)
                smardCardNo = RevertText(RevertText(oSmartCardMembers.MedicalCardNumber, "/"c))
                coverAmount = oSmartCardMembers.CoverAmount
                copayAmount = DecimalEnteredIn(nbxCoPayValue, False, "Copay Value")
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    Dim consumableNo As String = StringEnteredIn(cells, Me.colConsumableNo, "consumable no!")
                    Dim consumableName As String = StringEnteredIn(cells, Me.colConsumableName, "consumable name!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False, "unit price!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False, "amount!")

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colConsumableOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.consumable, consumableNo)
                    If quantity > 0 AndAlso locationBalance < quantity Then
                        If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                            message = "The system does not allow issuing of consumable: " + consumableName + ", with unit(s) not present at " + location + "!"
                            Throw New ArgumentException(message)
                        Else
                            message = "You are about to issue consumable: " + consumableName + ", with unit(s) not present at " + location + ". " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowDispensingExpiredconsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " +
                                "The system does not allow to dispence a consumable that is expired. Please re-stock appropriately! "
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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = consumableNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .LastUpdate = visitDate
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Offered

                        End With

                        lItems.Add(oItems)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then

                        oSmartCardItems = New SmartCardItems()

                        With oSmartCardItems

                            .TransactionDate = FormatDate(Today, "yyyy-MM-dd")
                            .TransactionTime = GetTime(Now)
                            .ServiceProviderNr = oVariousOptions.SmartCardServiceProviderNo
                            .DiagnosisCode = (0).ToString()
                            .DiagnosisDescription = "Unknown Disease"
                            .EncounterType = "Medication"
                            .CodeType = "Mcode"
                            .Code = (2).ToString()
                            .CodeDescription = consumableName
                            .Quantity = quantity.ToString()
                            .Amount = (amount).ToString()

                        End With

                        lSmartCardItems.Add(oSmartCardItems)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim notes As String = cells.Item(Me.colConsumableNotes.Name).Value.ToString()

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.consumable)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.consumable)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                            With oClaimDetails

                                .ClaimNo = claimNo
                                .ItemName = consumableName
                                .BenefitCode = oBenefitCodes.Consumable
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

                    End If

                    Using oInventory As New SyncSoft.SQLDb.Inventory()
                        With oInventory
                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = consumableNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = quantity
                            .Details = "Consumable(s) Issued to Visit No: " + visitNo
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = String.Empty
                            .ExpiryDate = AppData.NullDateValue
                        End With

                        lInventory.Add(oInventory)

                    End Using
                End If
            Next

            oSmartCardMembers.InvoiceNo = visitNo
            oSmartCardMembers.TotalBill = billFee
            oSmartCardMembers.TotalServices = lSmartCardItems.Count()
            oSmartCardMembers.CopayType = copayTypeID
            oSmartCardMembers.CopayAmount = copayAmount
            oSmartCardMembers.Gender = genderID

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkSmartCardApplicable.Checked AndAlso oVariousOptions.ForceSmartCardProcessing Then
                Dim oVisitTypeID As New LookupDataID.VisitTypeID()
                If Not UpdateSmartExchangeFiles(oSmartCardMembers, lSmartCardItems, visitNo, oVisitTypeID.OutPatient) Then
                    Throw New ArgumentException("Error processing smart card information. Please edit the transactions and try again")
                    Return
                End If
                
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

            DoTransactions(transactions)

            If Me.chkPrintDrugBarcode.Checked Then Me.PrintConsumableBarcodes()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadToIssueConsumables(visitNo)
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                Me.dgvConsumables.Rows.Clear()
                ResetControlsIn(Me)
                ResetControlsIn(Me.pnlNavigateVisits)
                Me.ClearControls()
                Me.SetDefaultLocation()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()
            Me.ShowToOrderConsumables()
            Me.ShowToExpireConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

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
            alerts = oAlerts.GetAlerts(oAlertTypeID.Consumable).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Sent Consumables: " + alertsNo.ToString()

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

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oAlertTypeID As New LookupDataID.AlertTypeID()
            Dim fAlerts As New frmAlerts(oAlertTypeID.Consumable, Me.stbVisitNo)
            fAlerts.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If Not String.IsNullOrEmpty(visitNo) Then : Me.LoadConsumablesData(visitNo)
            Else : Me.stbVisitNo.Focus()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

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
            End If

        Catch eX As Exception
            Return

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        If e.ColumnIndex.Equals(Me.colInclude.Index) OrElse e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) OrElse
            e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
            Me.CalculateConsumablesAmount(Me.dgvConsumables.CurrentCell.RowIndex)
            Me.CalculateBillForConsumables()
        End If

    End Sub

    Private Sub CalculateConsumablesAmount(selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitPrice)

        Me.dgvConsumables.Item(Me.colConsumableAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForConsumables()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
                totalBill += amount
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub DetailConsumableLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim consumableNo As String = StringMayBeEnteredIn(row.Cells, Me.colConsumableNo)
                If String.IsNullOrEmpty(consumableNo) Then Continue For

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = String.Empty
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Consumable, consumableNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadToIssueConsumables(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvConsumables.Rows.Clear()
            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim toIssueConsumables As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable, oItemStatusID.Pending).Tables("Items")
            If toIssueConsumables Is Nothing OrElse toIssueConsumables.Rows.Count < 1 Then Throw New ArgumentException("This visit has no pending consumable!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To toIssueConsumables.Rows.Count - 1

                Dim row As DataRow = toIssueConsumables.Rows(pos)

                Dim consumableNo As String = RevertText(StringEnteredIn(row, "ItemCode"))
                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice
                Dim cashAmount As Decimal = DecimalMayBeEnteredIn(row, "CashAmount")

                With Me.dgvConsumables

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = True
                    .Item(Me.colConsumableNo.Name, pos).Value = consumableNo
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                    .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "PayStatus")
                    Me.ShowConsumableDetails(consumableNo, pos)
                    .Item(Me.colCashAmount.Name, pos).Value = FormatNumber(cashAmount, AppData.DecimalPlaces)
                    .Item(Me.colCashPayStatus.Name, pos).Value = StringMayBeEnteredIn(row, "CashPayStatus")

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            Me.DetailConsumableLocationBalance()
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
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadConsumablesData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Consumables Extras "

    Private Sub cmsConsumables_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsConsumables.Opening

        If Me.dgvConsumables.ColumnCount < 1 OrElse Me.dgvConsumables.RowCount <= 1 Then
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim index As Integer = Me.dgvConsumables.CurrentCell.RowIndex
            Dim consumableNo As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(index).Cells, Me.colConsumableNo)
            Dim fInventory As New frmInventory(oItemCategoryID.Consumable, consumableNo)
            fInventory.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadConsumablesData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim fConsumables As New frmConsumables(visitNo)
            fConsumables.ShowDialog()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadConsumablesData(visitNo)
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
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Me.LoadConsumablesData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region
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
        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

            If CBool(Me.dgvConsumables.Item(Me.colInclude.Name, rowNo).Value) = True Then

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = StringEnteredIn(cells, Me.colConsumableNo, "consumable no!")
                Dim consumableName As String = StringEnteredIn(cells, Me.colConsumableName, "consumable name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False, "unit price!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False, "amount!")

                Using oInvoiceDetails As New SyncSoft.SQLDb.InvoiceDetails()

                    If oVariousOptions.GenerateInventoryInvoiceOnDispensingOnly() Then
                        With oInvoiceDetails
                            .InvoiceNo = invoiceNo
                            .VisitNo = visitNo
                            .ItemCode = consumableNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .Quantity = quantity

                            .UnitPrice = unitPrice

                            .Discount = 0
                            .Amount = amount


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
            If Not String.IsNullOrEmpty(stbVisitNo.Text) Then

                Dim barcodeImage As Image = Code128Rendering.MakeBarcodeImage(RevertText(stbVisitNo.Text.ToString()), Integer.Parse(imageweight.ToString()), True)
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
            e.Graphics.DrawString(RevertText(stbVisitNo.Text.ToString()), printFont10_Normal, Brushes.Black, rect, sf)
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