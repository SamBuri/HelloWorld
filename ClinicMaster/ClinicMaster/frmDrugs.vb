
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmDrugs

#Region " Fields "

    Private defaultDrugNo As String = String.Empty
    Private noCallOnKeyEdit As Boolean = False

    Private drugs As DataTable
    Private billCustomers As DataTable
    Private insurances As DataTable
    Private consumableItems As DataTable
    Private _consumableValue As String = String.Empty
    Private _AlternateDrugNameValue As String = String.Empty
    Private _AccountNoValue As String = String.Empty
    Private _insuranceNoValue As String = String.Empty
    Private _LocationIDValue As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID

#End Region

    Private Sub frmDrugs_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
        If Not oVariousOptions.EnableIntegrationN001 Then
            Me.pnlAlertItems.Visible = False
        Else
            Me.pnlAlertItems.Visible = True
            Me.unSavedDrugs()
        End If
    End Sub

    Private Sub frmDrugs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugCategories()
            Me.LoadConsumableItems()
            LoadLookupDataCombo(Me.cboGroupsID, LookupObjects.Groups, False)
            LoadLookupDataCombo(Me.fcbUnitMeasurID, LookupObjects.UnitMeasure, False)
            LoadLookupDataCombo(Me.colBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colInsuranceCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colLocation, LookupObjects.Location, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugs()
            Me.SetDefaultLocation()
            Me.LoadBillCustomers()
            Me.LoadInsurances()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not oVariousOptions.EnableIntegrationN001 Then
                Me.pnlAlertItems.Visible = False
            Else
                Me.pnlAlertItems.Visible = True
                Me.unSavedDrugs()
            End If

            If Not String.IsNullOrEmpty(defaultDrugNo) Then
                Me.cboDrugNo.Text = defaultDrugNo.ToUpper()
                Me.cboDrugNo.Enabled = False
                Me.ProcessTabKey(True)
                Me.Search(defaultDrugNo)
            Else : Me.cboDrugNo.Enabled = True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.SetNextDrugNo()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub unSavedDrugs()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.countUnSavedDrugs(oItemCategoryID.Drug)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub SetNextDrugNo()

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not oVariousOptions.EnableIntegrationN001 Then

                Dim oVariousOptions As New VariousOptions()
                Dim oDrugs As New SyncSoft.SQLDb.Drugs
                Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

                Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Drugs", "DrugNo").Tables("AutoNumbers")
                Dim row As DataRow = autoNumbers.Rows(0)

                Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
                Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

                Dim drugNoPrefix As String = oVariousOptions.DrugNoPrefix
                Dim nextDrugNo As String = CStr(oDrugs.GetNextDrugID).PadLeft(paddingLEN, paddingCHAR)
                Me.cboDrugNo.Text = FormatText((drugNoPrefix + nextDrugNo).Trim(), "Drugs", "DrugNo")
            Else
                Me.cboDrugNo.Text = Nothing
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmDrugs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cboDrugNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDrugNo.TextChanged
        If Not noCallOnKeyEdit Then Me.CallOnKeyEdit()
    End Sub

    Private Sub cboDrugNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDrugNo.Leave

        Try

            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboDrugNo)).ToUpper()
            Me.cboDrugNo.Text = drugNo.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In drugs.Select("DrugNo = '" + drugNo + "'")
                Me.stbDrugName.Text = StringMayBeEnteredIn(row, "DrugName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub nbxUnitsReceived_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxUnitsReceived.TextChanged

        Try

            Dim quantity As Integer = IntegerMayBeEnteredIn(Me.nbxUnitsReceived)
            Me.ResetInventoryDetails(quantity > 0)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub LoadDrugs()

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colAlternateDrugName.Sorted = False
            LoadComboData(Me.colAlternateDrugName, drugs, "DrugNo", "DrugName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugs(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboDrugNo, drugs, "DrugFullName")
            Else : Me.cboDrugNo.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadBillCustomers()

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Bill Customers
            If Not InitOptions.LoadBillCustomersAtStart Then
                billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                oSetupData.BillCustomers = billCustomers
            Else : billCustomers = oSetupData.BillCustomers
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colBillCustomerName.Sorted = False
            LoadComboData(Me.colBillCustomerName, billCustomers, "AccountNo", "BillCustomerName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsurances()

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Insurances

            insurances = oInsurances.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colInsuranceName.Sorted = False
            LoadComboData(Me.colInsuranceName, insurances, "InsuranceNo", "InsuranceName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugCategories()

        Dim oDrugCategories As New SyncSoft.SQLDb.DrugCategories()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Staff
            Dim drugCategories As DataTable = oDrugCategories.GetDrugCategories().Tables("DrugCategories")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fcbCategoryNo.Sorted = False
            LoadComboData(Me.fcbCategoryNo, drugCategories, "CategoryNo", "CategoryName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub ResetInventoryDetails(ByVal state As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            ResetControlsIn(Me.pnlInventory)
            Me.SetDefaultLocation()
            Me.pnlInventory.Enabled = state

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function countUnSavedDrugs(ItemCategoryID As String) As Integer

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oVariousOptions As New VariousOptions()
        Dim records As Integer = 0

        Try
            If oVariousOptions.EnableIntegrationN001 Then
                Me.Cursor = Cursors.WaitCursor

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                records = oDrugs.GetToCountToUnsavedINTDrugBillables()

                Me.lblToCompleteItems.Text = "Pending Drugs: " + records.ToString()

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            Return records
        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oDrugs.DrugNo = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))
            DisplayMessage(oDrugs.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgAlternateDrugs)
            ResetControlsIn(Me.tpgBillCustomFee)
            ResetControlsIn(Me.tpgInsuranceCustomFee)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Dim drugNo As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No"))
            Me.Search(drugNo)
            Me.LoadAttachedConsumableItems(drugNo)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Public Sub Search(ByVal drugNo As String)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim dataSource As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            Me.DisplayData(dataSource)

            Me.LoadAlternateDrugs(drugNo)
            Me.LoadBillCustomFee(drugNo)
            Me.LoadInsuranceCustomFee(drugNo)
            Me.LoadItemLocationOrderLevels(drugNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim records As Integer
        Dim itemCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))).ToUpper()
        Dim itemCategoryID As String = oItemCategoryID.Drug
        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()

            Dim oLookupData As New LookupData()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oStockTypeID As New LookupDataID.StockTypeID()
            Dim oEntryModeID As New LookupDataID.EntryModeID()

            Dim lDrugs As New List(Of DBConnect)
            Dim lInventory As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            Dim drugNo As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!")).ToUpper()
            Dim drugName As String = StringEnteredIn(Me.stbDrugName, "Drug Name!")

            With oDrugs

                .DrugNo = drugNo
                .DrugName = drugName
                .AlternateName = StringMayBeEnteredIn(Me.stbAlternateName)
                .CategoryNo = StringValueEnteredIn(Me.fcbCategoryNo, "Drug Category!")
                .GroupsID = StringValueEnteredIn(Me.cboGroupsID, "Drug Group!")
                .UnitMeasureID = StringValueEnteredIn(Me.fcbUnitMeasurID, "Unit Measure!")
                .OrderLevel = Me.nbxOrderLevel.GetInteger()
                .KeepingUnit = Me.nbxKeepingUnit.GetInteger()
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .VATPercentage = DecimalMayBeEnteredIn(nbxVATPercentage)
                .UnitPrice = Me.nbxUnitPrice.GetDecimal(False)
                .LastUpdate = Now()
                .Halted = Me.chkHalted.Checked
                .Hidden = Me.chkHidden.Checked

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lDrugs.Add(oDrugs)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oDrugs.UnitCost >= oDrugs.UnitPrice Then

                If oDrugs.UnitCost = oDrugs.UnitPrice Then
                    message = "Unit Cost equals Unit Price. "
                Else : message = "Unit Cost is more than Unit Price. "
                End If
                message += ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.nbxUnitCost.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oDrugs.Halted.Equals(True) Then
                If Me.dgvAlternateDrugs.RowCount > 1 Then
                    message = "You have chosen to halt this drug and won’t be prescribed. " +
                              ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHalted.Focus() : Return
                Else
                    Me.tbcBillExcludedItems.SelectTab(Me.tpgAlternateDrugs.Name)
                    Throw New ArgumentException("Must Register At least one alternate drug for a halted drug!")
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oDrugs.Hidden.Equals(True) Then
                message = "You have chosen to hide this drug and won’t be presented for selection. " +
                          ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Drug, drugNo)

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Dim quantity As Integer = Me.nbxUnitsReceived.GetInteger()
                    Dim locationID As String
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If quantity > 0 Then
                        locationID = StringValueEnteredIn(Me.cboLocationID, "Location!")
                    Else : locationID = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
                    End If

                    If quantity > 0 AndAlso Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                       Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                        message = "Selected location " + Me.cboLocationID.Text + " is not the same as " + InitOptions.Location +
                            " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oInventory As New SyncSoft.SQLDb.Inventory()

                        With oInventory

                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = drugNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Received
                            .Quantity = quantity
                            .Details = "New Drug (" + drugName + ") Received"
                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID

                            If quantity > 0 Then
                                .BatchNo = StringEnteredIn(Me.stbBatchNo, "Batch No!")
                                .ExpiryDate = DateEnteredIn(Me.dtpExpiryDate, "Expiry Date!")
                            Else
                                .BatchNo = StringMayBeEnteredIn(Me.stbBatchNo)
                                .ExpiryDate = DateMayBeEnteredIn(Me.dtpExpiryDate)
                            End If

                        End With

                        lInventory.Add(oInventory)
                        ValidateEntriesIn(Me)
                    End Using

                   

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDrugs, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(AlternateDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ItemLocationOrderLevelsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))
                    If quantity > 0 Then transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))

                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ResetControlsIn(Me)
                    Me.SetNextDrugNo()
                    Me.unSavedDrugs()
                    ResetControlsIn(Me.tpgAlternateDrugs)
                    ResetControlsIn(Me.tpgBillCustomFee)
                    ResetControlsIn(Me.tpgInsuranceCustomFee)
                    ResetControlsIn(Me.tpgPossibleConsumables)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    
                    transactions.Add(New TransactionList(Of DBConnect)(lDrugs, Action.Update, "Drugs"))
                    transactions.Add(New TransactionList(Of DBConnect)(AlternateDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ItemLocationOrderLevelsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))
                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvAlternateDrugs.RowCount - 2
                Me.dgvAlternateDrugs.Item(Me.colAlternateDrugsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvItemLocationOrderLevels.RowCount - 2
                Me.dgvItemLocationOrderLevels.Item(Me.colItemLocationOrderLevelsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function AlternateDrugsList() As List(Of DBConnect)

        Dim lAlternateDrugs As New List(Of DBConnect)

        Try

            Dim drugNo As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))

            For rowNo As Integer = 0 To Me.dgvAlternateDrugs.RowCount - 2

                Using oAlternateDrugs As New SyncSoft.SQLDb.AlternateDrugs()

                    Dim cells As DataGridViewCellCollection = Me.dgvAlternateDrugs.Rows(rowNo).Cells

                    With oAlternateDrugs

                        .DrugNo = drugNo
                        .AlternateDrugNo = StringEnteredIn(cells, Me.colAlternateDrugName, "Alternate Drug Name!")

                    End With

                    lAlternateDrugs.Add(oAlternateDrugs)

                End Using

            Next

            Return lAlternateDrugs

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgAlternateDrugs.Name)
            Throw ex

        End Try

    End Function

    Private Function BillCustomFeeList() As List(Of DBConnect)

        Dim lBillCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2

                Using oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillCustomFee.Rows(rowNo).Cells

                    With oBillCustomFee

                        .AccountNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Account Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Drug
                        .CustomFee = DecimalEnteredIn(cells, Me.colBillCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colBillCurrenciesID, "Currency!")

                    End With

                    lBillCustomFee.Add(oBillCustomFee)

                End Using

            Next

            Return lBillCustomFee

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgBillCustomFee.Name)
            Throw ex

        End Try

    End Function

    Private Function InsuranceCustomFeeList() As List(Of DBConnect)

        Dim lInsuranceCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2

                Using oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceCustomFee.Rows(rowNo).Cells

                    With oInsuranceCustomFee

                        .InsuranceNo = StringEnteredIn(cells, Me.colInsuranceName, "Insurance Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Drug
                        .CustomFee = DecimalEnteredIn(cells, Me.colInsuranceCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colInsuranceCurrenciesID, "Currency!")

                    End With

                    lInsuranceCustomFee.Add(oInsuranceCustomFee)

                End Using

            Next

            Return lInsuranceCustomFee

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgInsuranceCustomFee.Name)
            Throw ex

        End Try

    End Function

    Private Function ItemLocationOrderLevelsList() As List(Of DBConnect)

        Dim lItemLocationOrderLevels As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))

            For rowNo As Integer = 0 To Me.dgvItemLocationOrderLevels.RowCount - 2

                Using oItemLocationOrderLevels As New SyncSoft.SQLDb.ItemLocationOrderLevels()

                    Dim cells As DataGridViewCellCollection = Me.dgvItemLocationOrderLevels.Rows(rowNo).Cells

                    With oItemLocationOrderLevels

                        .LocationID = StringEnteredIn(cells, Me.colLocation, "Location!")
                        .ItemCategoryID = oItemCategoryID.Drug
                        .ItemCode = itemCode
                        .LocationOrderLevel = IntegerEnteredIn(cells, Me.colLocationOrderLevel, "Order Level")
                        .LoginID = CurrentUser.LoginID
                    End With

                    lItemLocationOrderLevels.Add(oItemLocationOrderLevels)

                End Using

            Next

            Return lItemLocationOrderLevels

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgItemLocationOrderLevel.Name)
            Throw ex

        End Try

    End Function

    Private Function PossibleCosumables() As List(Of DBConnect)

        Dim iPossibleAttachedItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = RevertText(StringMayBeEnteredIn(cboDrugNo))
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                        .ItemCategoryID = oItemCategoryID.Consumable
                        .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                        .UnitCost = DecimalEnteredIn(cells, Me.ColUnitCost, False)
                        .UnitPrice = DecimalEnteredIn(cells, Me.ColUnitPrice, False)
                        .Notes = StringEnteredIn(cells, Me.colConsumableNotes, "Consumable Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleAttachedItems.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleAttachedItems

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgPossibleConsumables.Name)

            Throw ex

        End Try

    End Function

#Region " AlternateDrugs - Grid "

    Private Sub dgvAlternateDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAlternateDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colAlternateDrugName.Index OrElse Me.dgvAlternateDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvAlternateDrugs.CurrentCell.RowIndex
        _AlternateDrugNameValue = StringMayBeEnteredIn(Me.dgvAlternateDrugs.Rows(selectedRow).Cells, Me.colAlternateDrugName)

    End Sub

    Private Sub dgvAlternateDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAlternateDrugs.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colAlternateDrugName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvAlternateDrugs.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvAlternateDrugs.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvAlternateDrugs.Rows(selectedRow).Cells, Me.colAlternateDrugName)

                    If CBool(Me.dgvAlternateDrugs.Item(Me.colAlternateDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                        Dim drugDisplay As String = (From data In _Drugs _
                                            Where data.Field(Of String)("DrugNo").ToUpper().Equals(_AlternateDrugNameValue.ToUpper()) _
                                            Select data.Field(Of String)("DrugName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Alternate Drug Name (" + drugDisplay + ") can't be edited!")
                        Me.dgvAlternateDrugs.Item(Me.colAlternateDrugName.Name, selectedRow).Value = _AlternateDrugNameValue
                        Me.dgvAlternateDrugs.Item(Me.colAlternateDrugName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvAlternateDrugs.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvAlternateDrugs.Rows(rowNo).Cells, Me.colAlternateDrugName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Drugs _
                                                    Where data.Field(Of String)("DrugNo").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("DrugName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Alternate Drug Name (" + enteredDisplay + ") already entered!")
                                Me.dgvAlternateDrugs.Item(Me.colAlternateDrugName.Name, selectedRow).Value = _AlternateDrugNameValue
                                Me.dgvAlternateDrugs.Item(Me.colAlternateDrugName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.DetailAlternateDrugs()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailAlternateDrugs()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvAlternateDrugs.Rows.Count > 1 Then
                selectedRow = Me.dgvAlternateDrugs.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvAlternateDrugs.Rows(selectedRow).Cells, Me.colAlternateDrugName)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvAlternateDrugs.Item(Me.colAlternateDrugNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvAlternateDrugs.Item(Me.colAlternateDrugNo.Name, selectedRow).Value = String.Empty
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvAlternateDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvAlternateDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oAlternateDrugs As New SyncSoft.SQLDb.AlternateDrugs()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvAlternateDrugs.Item(Me.colAlternateDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim drugNo As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))
            Dim alternateDrugNo As String = CStr(Me.dgvAlternateDrugs.Item(Me.colAlternateDrugName.Name, toDeleteRowNo).Value)

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
            With oAlternateDrugs
                .DrugNo = drugNo
                .AlternateDrugNo = alternateDrugNo
            End With

            DisplayMessage(oAlternateDrugs.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvAlternateDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAlternateDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadAlternateDrugs(ByVal drugNo As String)

        Dim oAlternateDrugs As New SyncSoft.SQLDb.AlternateDrugs()

        Try

            Me.dgvAlternateDrugs.Rows.Clear()

            ' Load alternate drugs

            Dim alternateDrugs As DataTable = oAlternateDrugs.GetAlternateDrugs(drugNo).Tables("AlternateDrugs")
            If alternateDrugs Is Nothing OrElse alternateDrugs.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAlternateDrugs, alternateDrugs)

            For Each row As DataGridViewRow In Me.dgvAlternateDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvAlternateDrugs.Item(Me.colAlternateDrugsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " BillCustomFee - Grid "

    Private Sub dgvBillCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillCustomFee.CellBeginEdit

        If e.ColumnIndex <> Me.colBillCustomerName.Index OrElse Me.dgvBillCustomFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillCustomFee.CurrentCell.RowIndex
        _AccountNoValue = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)

    End Sub

    Private Sub dgvBillCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillCustomFee.CellEndEdit

        Try

            If Me.colBillCustomerName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colBillCustomerName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillCustomFee.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)

                    If CBool(Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                        Dim billCustomerName As String = (From data In _BillCustomers
                                            Where data.Field(Of String)("AccountNo").ToUpper().Equals(_AccountNoValue.ToUpper())
                                            Select data.Field(Of String)("BillCustomerName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("To-Bill Account (" + billCustomerName + ") can't be edited!")
                        Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                        Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(rowNo).Cells, Me.colBillCustomerName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                                Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailBillCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailBillCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvBillCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvBillCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = String.Empty
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))
            Dim accountNo As String = CStr(Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oBillCustomFee
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oBillCustomFee.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillCustomFee_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillCustomFee.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillCustomFee(ByVal itemCode As String)

        Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, oItemCategoryID.Drug).Tables("BillCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillCustomFee, billCustomFee)

            For Each row As DataGridViewRow In Me.dgvBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " InsuranceCustomFee - Grid "

    Private Sub dgvInsuranceCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceCustomFee.CellBeginEdit

        If (e.ColumnIndex <> Me.colInsuranceName.Index OrElse Me.dgvInsuranceCustomFee.Rows.Count <= 1) Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
        _insuranceNoValue = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)

    End Sub

    Private Sub dgvInsuranceCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceCustomFee.CellEndEdit

        Try

            If Me.colInsuranceName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colInsuranceName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
                    Dim selectedInsuranceNo As String = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)

                    If CBool(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Insurances As EnumerableRowCollection(Of DataRow) = insurances.AsEnumerable()
                        Dim insuranceName As String = (From data In _Insurances
                                            Where data.Field(Of String)("InsuranceNo").ToUpper().Equals(_insuranceNoValue.ToUpper())
                                            Select data.Field(Of String)("InsuranceName")).First()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Insurance (" + insuranceName + ")  can't be edited!")
                        Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Value = _insuranceNoValue
                        Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredInsuranceNo As String = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(rowNo).Cells, Me.colInsuranceName)
                            If enteredInsuranceNo.Trim().ToUpper().Equals(selectedInsuranceNo.Trim().ToUpper()) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Insurances As EnumerableRowCollection(Of DataRow) = insurances.AsEnumerable()
                                Dim insuranceName As String = (From data In _Insurances
                                                    Where data.Field(Of String)("InsuranceNo").ToUpper().Equals(enteredInsuranceNo.ToUpper())
                                                    Select data.Field(Of String)("InsuranceName")).First()

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Insurance (" + insuranceName + ") already entered!")
                                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Value = _insuranceNoValue
                                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.DetailInsuranceCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailInsuranceCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInsuranceCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvInsuranceCustomFee.Item(Me.colInsuranceNo.Name, selectedRow).Value = String.Empty
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvInsuranceCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))
            Dim insuranceNo As String = CStr(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInsuranceCustomFee
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oInsuranceCustomFee.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceCustomFee_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceCustomFee.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceCustomFee(ByVal itemCode As String)

        Dim oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, oItemCategoryID.Drug).Tables("InsuranceCustomFee")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCustomFee, insuranceCustomFee)

            For Each row As DataGridViewRow In Me.dgvInsuranceCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " PossibleCosumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If (e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1) Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _consumableValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvConsumables.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

                    If CBool(Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, selectedRow).Value).Equals(True) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Consumables As EnumerableRowCollection(Of DataRow) = consumableItems.AsEnumerable()
                        Dim consumableName As String = (From data In _Consumables
                                                        Where data.Field(Of String)("ConsumableNo").ToUpper().Equals(_consumableValue.ToUpper())
                                                        Select data.Field(Of String)("ConsumableFullName")).First()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Consumable (" + consumableName + ")  can't be edited!")
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _consumableValue
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = (StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableName))
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Consumables As EnumerableRowCollection(Of DataRow) = consumableItems.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Consumables
                                                                Where data.Field(Of String)("ConsumableFullName").ToUpper().Equals(enteredItem.ToUpper())
                                                                Select data.Field(Of String)("ConsumableFullName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Consumable Item (" + enteredDisplay + ") already entered!")
                                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _consumableValue
                                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.DetailCosumableItems()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailCosumableItems()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then
                selectedRow = Me.dgvConsumables.CurrentCell.RowIndex
                selectedItem = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName))
            End If



        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oConsumables As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = (RevertText(StringMayBeEnteredIn(cboDrugNo)))
            Dim consumableNo As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oConsumables
                .AttachedItemCode = itemCode
                .ItemCode = consumableNo
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oConsumables.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub


    Private Sub LoadAttachedConsumableItems(ByVal drugNo As String)
        Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvConsumables.Rows.Clear()
            Dim theatrePossibleCosumables As DataTable = oConsumableItem.GetPossibleAttachedconsumables(drugNo).Tables("PossibleAttachedItems")
            If theatrePossibleCosumables Is Nothing OrElse theatrePossibleCosumables.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, theatrePossibleCosumables)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

#End Region

#Region " ItemLocationOrderLevels - Grid "

    Private Sub dgvItemLocationOrderLevels_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvItemLocationOrderLevels.CellBeginEdit

        If (e.ColumnIndex <> Me.colLocation.Index OrElse Me.dgvItemLocationOrderLevels.Rows.Count <= 1) Then Return
        Dim selectedRow As Integer = Me.dgvItemLocationOrderLevels.CurrentCell.RowIndex
        _LocationIDValue = StringMayBeEnteredIn(Me.dgvItemLocationOrderLevels.Rows(selectedRow).Cells, Me.colLocation)

    End Sub

    Private Sub dgvItemLocationOrderLevels_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvItemLocationOrderLevels.CellEndEdit

        Try

            If Me.colLocation.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colLocation.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvItemLocationOrderLevels.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvItemLocationOrderLevels.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvItemLocationOrderLevels.Rows(selectedRow).Cells, Me.colLocation)

                    If CBool(Me.dgvItemLocationOrderLevels.Item(Me.colItemLocationOrderLevelsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Location (" + GetLookupDataDes(_LocationIDValue) + ") can't be edited!")
                        Me.dgvItemLocationOrderLevels.Item(Me.colLocation.Name, selectedRow).Value = _LocationIDValue
                        Me.dgvItemLocationOrderLevels.Item(Me.colLocation.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvItemLocationOrderLevels.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvItemLocationOrderLevels.Rows(rowNo).Cells, Me.colLocation)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                DisplayMessage("Location (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvItemLocationOrderLevels.Item(Me.colLocation.Name, selectedRow).Value = _LocationIDValue
                                Me.dgvItemLocationOrderLevels.Item(Me.colLocation.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvItemLocationOrderLevels_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvItemLocationOrderLevels.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemLocationOrderLevels As New SyncSoft.SQLDb.ItemLocationOrderLevels()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvItemLocationOrderLevels.Item(Me.colItemLocationOrderLevelsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboDrugNo, "Drug No!"))
            Dim locationID As String = CStr(Me.dgvItemLocationOrderLevels.Item(Me.colLocation.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItemLocationOrderLevels
                .LocationID = LocationID
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oItemLocationOrderLevels.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvItemLocationOrderLevels_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvItemLocationOrderLevels.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadItemLocationOrderLevels(ByVal itemCode As String)

        Dim oItemLocationOrderLevels As New SyncSoft.SQLDb.ItemLocationOrderLevels()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim ItemLocationOrderLevels As DataTable = oItemLocationOrderLevels.GetItemLocationOrderLevels(oItemCategoryID.Drug, itemCode).Tables("ItemLocationOrderLevels")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvItemLocationOrderLevels, ItemLocationOrderLevels)

            For Each row As DataGridViewRow In Me.dgvItemLocationOrderLevels.Rows
                If row.IsNewRow Then Exit For
                Me.dgvItemLocationOrderLevels.Item(Me.colItemLocationOrderLevelsSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Me.btnSearch.Visible = True
        Me.pnlAlertItems.Visible = False
        Me.cboDrugNo.Enabled = True
        Me.cboDrugNo.MaxLength = 64
        Me.LoadDrugs(True)

        Me.nbxUnitsReceived.Enabled = False
        Me.chkHalted.Enabled = True
        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgAlternateDrugs)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        Me.ResetInventoryDetails(False)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboDrugNo.Enabled = Not InitOptions.DrugNoLocked
        Me.cboDrugNo.MaxLength = 20
        Me.LoadDrugs(False)

        Me.nbxUnitsReceived.Enabled = True
        Me.chkHalted.Enabled = False
        Me.chkHidden.Enabled = False

        ResetControlsIn(Me)
        Me.SetNextDrugNo()
        ResetControlsIn(Me.tpgAlternateDrugs)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        Me.ResetInventoryDetails(False)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.stbDrugName, AccessRights.Update)
            Security.Apply(Me.nbxUnitPrice, AccessRights.Update)
            Security.Apply(Me.nbxUnitCost, AccessRights.Update)
            Security.Apply(Me.nbxVATPercentage, AccessRights.Update)

            Security.Apply(Me.dgvBillCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvInsuranceCustomFee, AccessRights.Write)

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

#End Region

  
    Private Sub btnViewReceivedDrugs_Click(sender As System.Object, e As System.EventArgs) Handles btnViewReceivedDrugs.Click
        Try

            Me.Cursor = Cursors.WaitCursor


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPendingItems As New frmImportInventoryEXT(Me.cboDrugNo)
            fPendingItems.ShowDialog(Me)
            Dim drugNo As String = RevertText(StringMayBeEnteredIn(Me.cboDrugNo))
            If String.IsNullOrEmpty(drugNo) Then Return
            Me.ShowReceivedDeugDetails(drugNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowReceivedDeugDetails(ByVal itemCode As String)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID

        Try

            Dim _INTBillables As DataTable = oDrugs.GetReceiveINTBillableItems(itemCode, oItemCategoryID.Drug).Tables("INTBillables")
            Dim row As DataRow = _INTBillables.Rows(0)



            Me.stbDrugName.Text = StringEnteredIn(row, "ItemName")
            Me.nbxUnitCost.Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitCost"), AppData.DecimalPlaces)
            Me.nbxUnitPrice.Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)
            Me.nbxUnitsReceived.Value = "0"
            Me.nbxVATPercentage.Value = "0"
            Me.nbxKeepingUnit.Value = "0"
            Me.nbxOrderLevel.Value = "0"
        Catch eX As Exception

        End Try

    End Sub

End Class