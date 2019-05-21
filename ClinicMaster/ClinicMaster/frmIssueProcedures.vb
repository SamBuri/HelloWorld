
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmIssueProcedures

#Region " Fields "

    Private accessCashServices As Boolean = False
    Private alerts As DataTable
    Private alertsStartDateTime As Date = Now
    Private billModesID As String = String.Empty
    Private defaultVisitNo As String = String.Empty

#End Region

#Region " Validations & Checks "

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

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try
            Dim message As String

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvProcedures.RowCount >= 1 Then
                If Me.dgvProcedures.RowCount = 1 Then
                    message = "Please ensure that current procedure is saved!"
                Else : message = "Please ensure that current procedure are saved!"
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

    Private Sub frmIssueProcedures_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Dim message As String
        If Me.dgvProcedures.RowCount = 1 Then
            message = "Current procedure is not saved. " + ControlChars.NewLine + "Just close anyway?"
        Else : message = "Current procedure are not saved. " + ControlChars.NewLine + "Just close anyway?"
        End If
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If

    End Sub

#End Region

    Private Sub frmIssueProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpIssueDate.MaxDate = Today

            Me.ShowSentAlerts()
            Me.LoadProceduresToOffer()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If InitOptions.AlertCheckPeriod > 0 Then Me.tmrAlerts.Interval = 1000 * 60 * InitOptions.AlertCheckPeriod

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then

                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                'Me.ShowDispensingData()
                Me.ProcessTabKey(True)
                Me.EnableDefaultCTRLS(False)

            Else : Me.stbVisitNo.ReadOnly = False
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub EnableDefaultCTRLS(ByVal state As Boolean)

        Me.btnFindVisitNo.Enabled = state
        Me.btnLoadPendingProcedures.Enabled = state
        Me.pnlAlerts.Enabled = state

    End Sub

    Private Sub frmIssueProcedures_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ShowSentAlerts()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLoadPendingProcedures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPendingProcedures.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmPendingItems(Me.stbVisitNo, AlertItemCategory.Procedure)
            fPendingItems.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Focus()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbVisitNo.Focus()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave
        Me.ShowPatientDetails()
        Me.LoadProceduresToOffer()
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.ClearControls()
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
        Me.stbPrimaryDoctor.Clear()
        billModesID = String.Empty
        Me.stbBillMode.Clear()
        Me.stbVisitCategory.Clear()
        accessCashServices = False
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.grpIPDProcedures)
    End Sub

    Private Sub ShowPatientDetails()

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")
            Me.stbPrimaryDoctor.Text = StringMayBeEnteredIn(row, "PrimaryDoctor")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.dtpIssueDate.Value = visitDate
            Me.dtpIssueDate.Checked = GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProceduresToOffer()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim proceduresToOffer As DataTable

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

            Me.dgvProcedures.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oVariousOptions As New VariousOptions()
            If oVariousOptions.AllowAccessCashServices OrElse accessCashServices Then
                proceduresToOffer = oItems.GetItems(visitNo, oItemCategoryID.Procedure, oItemStatusID.Pending).Tables("Items")
            Else : proceduresToOffer = oItems.GetItems(visitNo, oItemCategoryID.Procedure, oItemStatusID.Pending, oPayStatusID.PaidFor).Tables("Items")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If proceduresToOffer Is Nothing OrElse proceduresToOffer.Rows.Count < 1 Then

                Dim message As String
                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
                If String.IsNullOrEmpty(billMode) Then Return

                If billMode.ToUpper().Equals(cashAccountNo.ToUpper()) Then
                    message = "This visit has no pending procedures or is waiting for payment first!"
                Else : message = "This visit has no pending procedures!"
                End If

                DisplayMessage(message)
                Return

            End If

            For pos As Integer = 0 To proceduresToOffer.Rows.Count - 1

                Dim row As DataRow = proceduresToOffer.Rows(pos)

                Dim quantity As Integer = IntegerMayBeEnteredIn(row, "Quantity")
                Dim unitPrice As Decimal = DecimalMayBeEnteredIn(row, "UnitPrice")
                Dim amount As Decimal = quantity * unitPrice

                With Me.dgvProcedures

                    .Rows.Add()

                    .Item(Me.colInclude.Name, pos).Value = False
                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colProcedureName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colQuantity.Name, pos).Value = quantity
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")

                End With

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalBill()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            If visitDate = AppData.NullDateValue Then Return
            Me.DeleteAlerts(visitNo, visitDate)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
            alerts = oAlerts.GetAlerts(oAlertTypeID.Procedure).Tables("Alerts")

            Dim alertsNo As Integer = alerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblAlerts.Text = "Doctor Procedure(s): " + alertsNo.ToString()

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

    Private Sub btnViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewList.Click

        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.ShowSentAlerts()

        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        'Dim fAlerts As New frmAlerts(oAlertTypeID.Procedure, Me.stbVisitNo)
        'fAlerts.ShowDialog(Me)
        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.stbVisitNo.Focus()
        ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.RecordSaved(False) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oAlertTypeID As New LookupDataID.AlertTypeID()
            Dim fAlerts As New frmAlerts(oAlertTypeID.Procedure, Me.stbVisitNo)
            fAlerts.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If Not String.IsNullOrEmpty(visitNo) Then : Me.LoadProcedureData(visitNo)
            Else : Me.stbVisitNo.Focus()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DeleteAlerts(ByVal visitNo As String, ByVal visitDate As Date)

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()

        Try
            Me.Cursor = Cursors.WaitCursor

            If alerts Is Nothing OrElse alerts.Rows.Count < 1 Then Return

            Dim miniAlerts As EnumerableRowCollection(Of DataRow) = alerts.AsEnumerable()

            Dim alertID As Integer = (From data In miniAlerts Where
                                      data.Field(Of String)("VisitNo").ToUpper().Equals(visitNo.ToUpper()) And
                                      GetShortDate(data.Field(Of Date)("VisitDate")).Equals(GetShortDate(visitDate)) Select
                                      data.Field(Of Integer)("AlertID")).First()

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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()

        Dim lItems As New List(Of DBConnect)
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvProcedures.RowCount < 1 Then
                Throw New ArgumentException("Must register at least one entry for procedures " + ControlChars.NewLine +
                                            "If this is a cash patient, ensure that payment is done first!")
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvProcedures.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must include at least one entry for procedure(s)!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
                        .VisitDate = DateEnteredIn(Me.dtpIssueDate, "Issue Date!")
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                Dim procedureCode As String = StringEnteredIn(cells, Me.colProcedureCode, "procedure code!")
                Dim procedureName As String = StringEnteredIn(cells, Me.colProcedureName, "procedure name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unit price!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvProcedures.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = procedureCode
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .LastUpdate = DateEnteredIn(Me.dtpIssueDate, "Issue Date!")
                            .PayStatusID = String.Empty
                            .LoginID = CurrentUser.LoginID
                            .ItemStatusID = oItemStatusID.Done

                        End With

                        lItems.Add(oItems)

                    End Using

                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Procedure)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Procedure)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me, ErrProvider)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
            transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))

            DoTransactions(transactions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim allSelected As Boolean = True

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvProcedures.Item(Me.colInclude.Name, row.Index).Value) = False Then
                    allSelected = False
                    Me.LoadProceduresToOffer()
                    Exit For
                End If
                allSelected = True
            Next

            If allSelected Then
                Me.dgvProcedures.Rows.Clear()
                ResetControlsIn(Me)
                Me.ClearControls()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowSentAlerts()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub CalculateTotalBill()

        Dim totalBill As Decimal

        Me.stbBillForProcedures.Clear()

        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1

            If CBool(Me.dgvProcedures.Item(Me.colInclude.Name, rowNo).Value) = True Then
                If IsNumeric(Me.dgvProcedures.Item(Me.colAmount.Name, rowNo).Value) Then
                    totalBill += CDec(Me.dgvProcedures.Item(Me.colAmount.Name, rowNo).Value)
                Else : totalBill += 0
                End If
            End If
        Next

        Me.stbBillForProcedures.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

#Region "LOAD OPTIONS"
    Private Sub LoadProcedureData(ByVal visitNo As String)

        Try

            '''''''''''''''''''''''''''''''''
            Me.ClearControls()

            '''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails()
            Me.LoadProceduresToOffer()
            '''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub
#End Region
    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit
        Me.CalculateTotalBill()
    End Sub

End Class