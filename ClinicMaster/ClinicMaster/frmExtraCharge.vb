
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
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmExtraCharge

#Region " Fields "
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private defaultVisitNo As String = String.Empty
    Private extraChargeItems As DataTable
    Private _ExtraItemValue As String = String.Empty

    Private tipCoPayValueWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()
#End Region

    Private Sub frmExtraCharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)

            Me.LoadExtraChargeItems()
            Me.LockItemsUnitPrices()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.btnLoadPeriodicVisits.Enabled = False
                Me.LoadExtraChargeData(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else
                Me.stbVisitNo.ReadOnly = False
                Me.btnLoadPeriodicVisits.Enabled = True
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadExtraChargeData(visitNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadExtraChargeData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

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
        associatedBillNo = String.Empty
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
        Me.dgvExtraCharge.Rows.Clear()
        ResetControlsIn(Me.pnlBill)

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadExtraChargeData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraChargeData(ByVal visitNo As String)

        Try

            Me.ShowPatientDetails(visitNo)
            Me.LoadExtraCharge(visitNo)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
  
        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()

            Me.tipOutstandingBalanceWords.RemoveAll()
            Me.tipCashAccountBalanceWords.RemoveAll()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
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
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

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
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

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
                    ErrorMessage(ex)

                End Try

            Next

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " ExtraCharge - Grid "

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
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
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

    Private Sub LockItemsUnitPrices()
        Dim oVariousOptions As New VariousOptions()
        Dim unitPrice As DataGridViewColumn() = {colExtraChargeUnitPrice}
        DisableGridComponets(unitPrice, oVariousOptions.LockItemsUnitPrices)

    End Sub

End Class