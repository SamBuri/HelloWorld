
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Collections.Generic

Public Class frmConsumables

#Region " Fields "

    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private defaultVisitNo As String = String.Empty
    Private consumableItems As DataTable
    Private _ConsumableItemValue As String = String.Empty
    Private hasPackage As Boolean = False
    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private tipCoPayValueWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()

    Private hasPaidPackage As Boolean = False
    Private IsPackage As Boolean = False

    Private patientpackageNo As String = String.Empty
    Private packageNopatient As String = String.Empty
    Private OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT()

#End Region

    Private Sub frmConsumables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)
            Me.LoadConsumableItems()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.btnFindVisitNo.Enabled = False
                Me.btnLoadPeriodicVisits.Enabled = False
                Me.LoadConsumablesData(defaultVisitNo)
                Me.ProcessTabKey(True)
            Else
                Me.stbVisitNo.ReadOnly = False
                Me.btnFindVisitNo.Enabled = True
                Me.btnLoadPeriodicVisits.Enabled = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.LoadConsumablesData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadConsumablesData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

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
        hasPackage = False
        Me.stbBillCustomerName.Clear()
        billModesID = String.Empty
        associatedBillNo = String.Empty
        Me.nbxOutstandingBalance.Value = String.Empty
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.stbCashAccountBalance.Clear()
        Me.tipCashAccountBalanceWords.RemoveAll()
        Me.stbBillMode.Clear()
        Me.stbPackage.Clear()
        Me.stbPackageNo.Clear()
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.spbPhoto.Image = Nothing
        Me.dgvConsumables.Rows.Clear()
        patientpackageNo = String.Empty
        packageNopatient = String.Empty
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
            Me.LoadConsumablesData(visitNo)
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

    Private Sub LoadConsumablesData(ByVal visitNo As String)

        Try
            Dim packageNo As String = RevertText(Me.stbPackageNo.Text)
            '''''''''''''''''''''''''''''''''
            Me.ClearControls()

            '''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadConsumables(visitNo)
           
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
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
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
            Me.stbPackageNo.Text = StringMayBeEnteredIn(row, "PackageNo")
            Me.stbPackage.Text = StringMayBeEnteredIn(row, "PackageName")
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            hasPaidPackage = BooleanMayBeEnteredIn(row, "HasPaidPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            packageNopatient = patientNo
        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim message As String

        Dim oVariousOptions As New VariousOptions()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

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

                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

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
                            If (Me.stbPackage.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.stbPackage.Text)) AndAlso hasPackage.Equals(True) AndAlso hasPackage.Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
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

                        Catch ex As Exception
                            Exit Try
                        End Try

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oVariousOptions.OpenIssueConsumablesAfterPrescription Then

                Dim hasPendingItems As Boolean = False
                message = "Would you like to open issue consumables now?"

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

                If hasPendingItems AndAlso WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    Dim fIssueConsumables As New frmIssueConsumables(visitNo)
                    fIssueConsumables.ShowDialog()
                    Me.LoadConsumables(visitNo)
                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

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
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateConsumablesAmount(selectedRow)
                Me.CalculateBillForConsumables()
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

    Private Sub LoadPackageAttachedConsumables(PackageNo As String)

        Dim oItems As New SyncSoft.SQLDb.PackagesEXT()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()


        Dim attachedConsumables As DataTable = oItems.GetAllowedPackageConsumables(PackageNo).Tables("PackagesEXT")
        If attachedConsumables.Rows.Count > 0 Then

            Dim Message As String = "Hello there, the Patient " + stbFullName.Text +
                                      ", Is on the " + stbPackage.Text +
                                      " Package, would you like me to list the allowed Consumables on this package for you? "

            If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then

                If attachedConsumables Is Nothing OrElse attachedConsumables.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim count As Integer = Me.dgvConsumables.Rows.Count - 1


                For pos As Integer = 0 To attachedConsumables.Rows.Count - 1
                    Dim row As DataRow = attachedConsumables.Rows(pos)
                    With Me.dgvConsumables

                        ' Ensure that you add a new row
                        .Rows.Add()

                        Dim testCode As String = StringEnteredIn(row, "ItemCode")
                        Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
                        Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", False)
                        Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "TestFullName")
                        .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                        .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)
                        .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                        .Item(Me.colConsumableItemStatus.Name, pos).Value = GetLookupDataDes(oItemStatusID.Pending)
                        .Item(Me.colConsumablePayStatus.Name, pos).Value = GetLookupDataDes(oPayStatusID.NA)
                        .Item(Me.colConsumablesSaved.Name, pos).Value = False
                        .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                        .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                        .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                        .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                        .Item(Me.colConsumableHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
                        count += 1

                    End With

                Next

                Me.CalculateBillForConsumables()
            End If
        End If
    End Sub

    Private Sub DetailConsumableItem(selectedRow As Integer)

        Dim selectedItem As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim unitPrice As Decimal
            Dim consumableNo As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            Dim quantity As Integer = 1

            If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                unitPrice = OpackagesEXT.GetPackageItemUnitPrice(patientpackageNo, consumableNo, oItemCategoryID.Consumable)
            Else
                unitPrice = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)
            End If

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

                If OpackagesEXT.hasPackage(packageNopatient, patientpackageNo).Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, consumableNo, oItemCategoryID.Consumable).Equals(True) Then
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
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

    Private Sub LoadConsumables(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable).Tables("Items")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return

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
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvConsumables_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellClick
        Dim packageNo As String = RevertText(Me.stbPackageNo.Text)
        If (packageNo IsNot Nothing OrElse Not String.IsNullOrEmpty(packageNo)) AndAlso Me.dgvConsumables.RowCount < 2 Then
            LoadPackageAttachedConsumables(packageNo)

        End If
    End Sub

#End Region

#Region " Popup Menu "

    Private Sub cmsConsumablesQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsConsumablesQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableName)
            fQuickSearch.ShowDialog(Me)

            Dim rowIndex As Integer = Me.dgvConsumables.NewRowIndex
            If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

End Class