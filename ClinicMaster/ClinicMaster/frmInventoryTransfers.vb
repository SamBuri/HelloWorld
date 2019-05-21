
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

Imports System.Collections.Generic
Imports System.Drawing.Printing

Public Class frmInventoryTransfers
    Private oVariousOptions As New VariousOptions()
#Region " Fields "

    Private defaultOrderNo As String = String.Empty

    Private currentAllSaved As Boolean = True
    Private currentTransferNo As String = String.Empty

    Private _DrugNo As String = String.Empty
    Private _ConsumableNo As String = String.Empty

    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oStockTypeID As New LookupDataID.StockTypeID()

    Private WithEvents docInventoryTransfers As New PrintDocument()

    ' The paragraphs.
    Private transferParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 25
    Private padQuantity As Integer = 12
    Private padBatchNo As Integer = 14
    Private padExpiryDate As Integer = 12

    Private itemCount As Integer = 0

    Private oPack As New LookupDataID.PackID
    Private oOrderType As New LookupDataID.InventoryOrderTypeID

#End Region

#Region " Validations "

    Private Sub dtpTransferDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpTransferDate.Validating

        Dim errorMSG As String = "Transfer date can't be before Order date!"

        Try

            Dim transferDate As Date = DateMayBeEnteredIn(Me.dtpTransferDate)
            Dim orderDate As Date = DateMayBeEnteredIn(Me.stbOrderDate)

            If transferDate = AppData.NullDateValue Then Return

            If transferDate < orderDate Then
                ErrProvider.SetError(Me.dtpTransferDate, errorMSG)
                Me.dtpTransferDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpTransferDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmInventoryTransfers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpTransferDate.MaxDate = Today
            Me.dtpTransferDate.Checked = True

            LoadLookupDataCombo(Me.cboFromLocationID, LookupObjects.Location, False)
            'LoadLookupDataCombo(Me.cboToLocationID, LookupObjects.Location, False)
            LoadLookupDataCombo(Me.cboOrderType, LookupObjects.InventoryOrderType, False)
            LoadLookupDataCombo(Me.cboTransferReasonID, LookupObjects.TransferReasonID, False)

            LoadInventoryLocations()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultOrderNo) Then
                Me.stbOrderNo.Text = defaultOrderNo
                Me.stbOrderNo.Enabled = False
                Me.ShowInventoryOrders(defaultOrderNo)
            Else : Me.ClearControls()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadLookupDataCombo(colDrugPack, LookupObjects.Packs, False)
            LoadLookupDataCombo(colConsumablePack, LookupObjects.Packs, False)
            LoadLookupDataCombo(colOtherItemsPack, LookupObjects.Packs, False)
            HideInventoryPacks()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub HideInventoryPacks()
        Dim packControl As DataGridViewColumn() = {colDrugPack, colDrugPackSize, colDrugTotalUnits, colConsumableTotalUnits,
                                            colConsumablePackSize, colConsumablePack, colOtherItemsPack, colOtherItemsPackSize, colOtherItemsTotalUnits}
        HideGridComponets(packControl, oVariousOptions.UseOfInventoryPackSizes)

    End Sub



    Private Sub frmInventoryTransfers_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        Try

            If Not Me.AllSaved() Then 
                If WarningMessage("Just close anyway?") = Windows.Forms.DialogResult.No Then e.Cancel = True
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub frmInventoryTransfers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        If Me.AllSaved() Then Me.Close()
    End Sub

    Private Sub stbTransferNo_Enter(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentTransferNo = StringMayBeEnteredIn(Me.stbTransferNo)
                ProcessTabKey(True)
            Else : currentTransferNo = String.Empty
            End If

        Catch ex As Exception
            currentTransferNo = String.Empty
        End Try

    End Sub

    Private Sub stbTransferNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.TextChanged

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentTransferNo) Then
            Me.stbTransferNo.Text = currentTransferNo
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.CallOnKeyEdit()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbTransferNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbTransferNo.Leave

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentTransferNo) Then
            Me.stbTransferNo.Text = currentTransferNo
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInventoryTransfers As New frmPeriodicInventoryTransfers(Me.stbTransferNo)
            fPeriodicInventoryTransfers.ShowDialog(Me)
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

            Dim fromLocation As String = StringMayBeEnteredIn(Me.cboFromLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(fromLocation) Then
                Me.cboFromLocationID.Enabled = False
            Else : Me.cboFromLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboFromLocationID.Enabled = True
        End Try

    End Sub

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboFromLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboFromLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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

    Private Function GetConsumableItems() As DataTable

        Dim consumableItems As DataTable
        Dim oSetupData As New SetupData()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return consumableItems
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Function GetOtherItems() As DataTable

        Dim otherItems As DataTable
        Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

        Try

            otherItems = oOtherItems.GetOtherItems().Tables("OtherItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return otherItems
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub cboFromLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFromLocationID.SelectedIndexChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        'Me.DetailDrug()
        '  Me.DetailConsumableItem()
    End Sub

    Private Sub cboToLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboToLocationID.SelectedIndexChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        ' Me.DetailDrug()
        ' Me.DetailConsumableItem()
    End Sub

    Private Sub stbOrderNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub stbOrderNo_Leave(sender As System.Object, e As System.EventArgs) Handles stbOrderNo.Leave

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderNo As String = RevertText(StringMayBeEnteredIn(Me.stbOrderNo))
            If String.IsNullOrEmpty(orderNo) Then Return
            Me.ShowInventoryOrders(orderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetNextTransferNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("InventoryTransfers", "TransferNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))
            Dim transferNo As String = yearL2 + oInventoryTransfers.GetNextTransferID.ToString().PadLeft(paddingLEN, paddingCHAR)

            Me.stbTransferNo.Text = FormatText(transferNo, "InventoryTransfers", "TransferNo")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbOrderDate.Clear()
        Me.cboFromLocationID.SelectedIndex = -1
        Me.cboFromLocationID.SelectedIndex = -1
        Me.cboToLocationID.SelectedIndex = -1
        Me.cboToLocationID.SelectedIndex = -1

        Me.dgvDrugs.Rows.Clear()
        Me.dgvConsumables.Rows.Clear()
        Me.dgvOtherItems.Rows.Clear()
        Me.EnableOrderCTLS(True)
        Me.SetDefaultLocation()

    End Sub

    Private Sub EnableOrderCTLS(ByVal state As Boolean)

        Me.cboFromLocationID.Enabled = state
        Me.cboToLocationID.Enabled = state

        Me.dgvDrugs.AllowUserToDeleteRows = state
        Me.dgvConsumables.AllowUserToDeleteRows = state
        Me.dgvOtherItems.AllowUserToDeleteRows = state
        'Me.colDrugSelect.Visible = state
        'Me.colConsumableSelect.Visible = state

        Me.colDrugNo.ReadOnly = Not state
        Me.colConsumableNo.ReadOnly = Not state
        Me.colOtherItemsItemCode.ReadOnly = Not state
        Me.cmsInventoryTransfersQuickSearch.Enabled = state

    End Sub

    Private Sub ResetTabControls()

        ResetControlsIn(Me.tpgDrugs)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgOtherItems)
    End Sub

    Private Sub ShowInventoryOrders(ByVal orderNo As String)

        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(orderNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oInventoryOrders.IsOrderTransferred(orderNo) Then Throw New ArgumentException("Order No: " + orderNo + ", is already transferred!")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim inventoryOrders As DataTable = oInventoryOrders.GetInventoryOrders(orderNo).Tables("InventoryOrders")
            Dim row As DataRow = inventoryOrders.Rows(0)

            Dim orderDate As Date = DateEnteredIn(row, "OrderDate")
            Me.stbOrderDate.Text = FormatDate(orderDate)

            Dim orderType As String = StringEnteredIn(row, "OrderTypeID")
            Me.cboOrderType.SelectedValue = orderType

            Me.cboTransferReasonID.SelectedValue = StringEnteredIn(row, "TransferReasonID")

            Me.cboFromLocationID.SelectedValue = StringEnteredIn(row, "ToLocationID")
            Me.cboToLocationID.SelectedValue = StringEnteredIn(row, "FromLocationID")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpTransferDate.Value = orderDate
            Me.dtpTransferDate.Checked = GetShortDate(orderDate) >= GetShortDate(Today)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugOrderDetails(orderNo)
            Me.LoadConsumableOrderDetails(orderNo)
            Me.LoadOtherItemsOrderDetails(orderNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.EnableOrderCTLS(False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadDrugOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()

        Try

            Me.dgvDrugs.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.Drug).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID, "From Location!")
            Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "To Location!")
            Dim orderTypeID As String = StringValueMayBeEnteredIn(cboOrderType, "Order Type ID!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)
                Dim DrugNo As String = StringEnteredIn(dataRow, "ItemCode")
                Dim packID As String = StringEnteredIn(dataRow, "PackID")

                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Drug, DrugNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                Dim row As DataRow = inventoryLocation.Rows(0)

                Dim fromLocationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")



                Dim tolocationBalance As Integer = 0

                If orderTypeID.Equals(oOrderType.Internal()) Then
                    tolocationBalance = GetInventoryBalance(toLocationID, oItemCategoryID.Drug, DrugNo)
                End If

                Dim batchNo As String = StringMayBeEnteredIn(row, "BatchNo")
                Dim expiryDate As Date = DateMayBeEnteredIn(row, "ExpiryDate")
                With Me.dgvDrugs
                    .Rows.Add()
                    .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(dataRow, "ItemCode")
                    .Item(Me.colDrugName.Name, pos).Value = StringEnteredIn(dataRow, "ItemName")
                    .Item(Me.colDrugFromLocationBalance.Name, pos).Value = fromLocationBalance
                    .Item(Me.colDrugToLocationBalance.Name, pos).Value = tolocationBalance
                    .Item(Me.colDrugQuantity.Name, pos).Value = StringEnteredIn(dataRow, "Quantity")
                    .Item(Me.colDrugPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")
                    .Item(Me.colDrugPackSize.Name, pos).Value = StringEnteredIn(dataRow, "PackSize")
                    .Item(Me.colDrugTotalUnits.Name, pos).Value = StringEnteredIn(dataRow, "TotalUnits")
                    .Item(Me.colDrugUnitCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "UnitCost", False))
                    .Item(Me.colDrugTotalCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "TotalCost", False))
                    .Item(Me.colDrugBatchNo.Name, pos).Value = batchNo
                    .Item(Me.colDrugExpiryDate.Name, pos).Value = expiryDate
                    .Item(Me.colDrugStockStatus.Name, pos).Value = GetLookupDataDes(oStockTypeID.Issued)

                End With



            Next


            '''''''''''''''''''''''''''
            CalculateTotalDrugCost()
        Catch ex As Exception
                ErrorMessage(ex)
            End Try

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



    End Sub

    Private Sub LoadConsumableOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID, "From Location!")
        Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "To Location!")
        Dim orderTypeID As String = StringValueMayBeEnteredIn(Me.cboOrderType, "Order Type!")

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.Consumable).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)
                Dim consumableNo As String = StringEnteredIn(dataRow, "ItemCode")

                Dim InventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Consumable, consumableNo).Tables("InventoryLocation")
                If InventoryLocation Is Nothing OrElse InventoryLocation.Rows.Count < 1 Then Return
                Dim row As DataRow = InventoryLocation.Rows(0)

                Dim fromLocationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                Dim tolocationBalance As Integer = 0

                If (orderTypeID.Equals(oOrderType.Internal())) Then
                    tolocationBalance = GetInventoryBalance(toLocationID, oItemCategoryID.Consumable, consumableNo)
                End If
                Dim batchNo As String = StringMayBeEnteredIn(row, "BatchNo")
                Dim expiryDate As Date = DateMayBeEnteredIn(row, "ExpiryDate")
                With Me.dgvConsumables

                    .Rows.Add()
                    .Item(Me.colConsumableNo.Name, pos).Value = StringEnteredIn(dataRow, "ItemCode")
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(dataRow, "ItemName")
                    .Item(Me.colConsumableFromLocationBalance.Name, pos).Value = fromLocationBalance
                    .Item(Me.colConsumableToLocationBalance.Name, pos).Value = tolocationBalance
                    .Item(Me.colConsumableQuantity.Name, pos).Value = StringEnteredIn(dataRow, "Quantity")
                    .Item(Me.colConsumablePack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")
                    .Item(Me.colConsumablePackSize.Name, pos).Value = StringEnteredIn(dataRow, "PackSize")
                    .Item(Me.colConsumableTotalUnits.Name, pos).Value = StringEnteredIn(dataRow, "TotalUnits")
                    .Item(Me.colConsumableUnitCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "UnitCost", False))
                    .Item(Me.colConsumableTotalCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "TotalCost", False))
                    .Item(Me.colConsumableBatchNo.Name, pos).Value = batchNo
                    .Item(Me.colConsumableExpiryDate.Name, pos).Value = expiryDate
                    .Item(Me.colConsumableStockStatus.Name, pos).Value = GetLookupDataDes(oStockTypeID.Issued)

                End With



            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CalculateTotalConsumableCost()
        Catch ex As Exception
            Throw ex
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadOtherItemsOrderDetails(ByVal orderNo As String)

        Dim oInventoryOrderDetails As New SyncSoft.SQLDb.InventoryOrderDetails()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID, "From Location!")
        Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "To Location!")
        Dim orderTypeID As String = StringValueMayBeEnteredIn(Me.cboOrderType, "Order Type!")

        Try

            Me.dgvOtherItems.Rows.Clear()

            ' Load InventoryOrderDetails

            Dim orderDetails As DataTable = oInventoryOrderDetails.GetInventoryOrderDetails(orderNo, oItemCategoryID.NonMedical).Tables("InventoryOrderDetails")
            If orderDetails Is Nothing OrElse orderDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To orderDetails.Rows.Count - 1

                Dim dataRow As DataRow = orderDetails.Rows(pos)
                Dim OtherItemsNo As String = StringEnteredIn(dataRow, "ItemCode")

                Dim InventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.NonMedical, OtherItemsNo).Tables("InventoryLocation")
                If InventoryLocation Is Nothing OrElse InventoryLocation.Rows.Count < 1 Then Return
                Dim row As DataRow = InventoryLocation.Rows(0)

                Dim fromLocationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")

                Dim tolocationBalance As Integer = 0

                If (orderTypeID.Equals(oOrderType.Internal())) Then
                    tolocationBalance = GetInventoryBalance(toLocationID, oItemCategoryID.NonMedical, OtherItemsNo)
                End If
                Dim batchNo As String = StringMayBeEnteredIn(row, "BatchNo")
                Dim expiryDate As Date = DateMayBeEnteredIn(row, "ExpiryDate")
                With Me.dgvOtherItems

                    .Rows.Add()
                    .Item(Me.colOtherItemsItemCode.Name, pos).Value = StringEnteredIn(dataRow, "ItemCode")
                    .Item(Me.colOtherItemsItemName.Name, pos).Value = StringEnteredIn(dataRow, "ItemName")
                    .Item(Me.colOtherItemsFromLocationBalance.Name, pos).Value = fromLocationBalance
                    .Item(Me.colOtherItemsToLocationBalance.Name, pos).Value = tolocationBalance
                    .Item(Me.colOtherItemsQuantity.Name, pos).Value = StringEnteredIn(dataRow, "Quantity")
                    .Item(Me.colOtherItemsPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")
                    .Item(Me.colOtherItemsPackSize.Name, pos).Value = StringEnteredIn(dataRow, "PackSize")
                    .Item(Me.colOtherItemsTotalUnits.Name, pos).Value = StringEnteredIn(dataRow, "TotalUnits")
                    .Item(Me.colOtherItemsUnitCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "UnitCost", False))
                    .Item(Me.colOtherItemsTotalCost.Name, pos).Value = FormatNumber(DecimalEnteredIn(dataRow, "TotalCost", False))
                    .Item(Me.colOtherItemsBatchNo.Name, pos).Value = batchNo
                    .Item(Me.colOtherItemsExpiryDate.Name, pos).Value = expiryDate
                    .Item(Me.colOtherItemsStockStatus.Name, pos).Value = GetLookupDataDes(oStockTypeID.Issued)

                End With



            Next


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CalculateTotalOtherItemsCost()
        Catch ex As Exception
            Throw ex
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInventoryTransfers.TransferNo = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            DisplayMessage(oInventoryTransfers.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.ResetTabControls()
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInventoryOrders As New SyncSoft.SQLDb.InventoryOrders()
        Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            Dim dataSource As DataTable = oInventoryTransfers.GetInventoryTransfers(transferNo).Tables("InventoryTransfers")

            Me.DisplayData(dataSource)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadDrugTransferDetails(transferNo)
            Me.LoadConsumableTransferDetails(transferNo)
            Me.LoadOtherItemsTransferDetails(transferNo)
            Me.btnPrint.Enabled = True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderNo As String = RevertText(StringMayBeEnteredIn(Me.stbOrderNo))
            If String.IsNullOrEmpty(orderNo) Then Return

            Dim inventoryOrders As DataTable = oInventoryOrders.GetInventoryOrders(orderNo).Tables("InventoryOrders")
            Dim row As DataRow = inventoryOrders.Rows(0)

            Me.stbOrderDate.Text = FormatDate(DateMayBeEnteredIn(row, "OrderDate"))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try

            Dim message As String = "Please ensure that all items are saved on "
            Dim transferNo As String = StringMayBeEnteredIn(Me.stbTransferNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(transferNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For Each page As TabPage In Me.tbcInventoryTransfers.TabPages

                Select Case page.Name

                    Case Me.tpgDrugs.Name
                        For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                            If row.IsNewRow Then Exit For
                            If Not BooleanMayBeEnteredIn(row.Cells, Me.colDrugsSaved) Then
                                DisplayMessage(message + Me.tpgDrugs.Text)
                                Me.tbcInventoryTransfers.SelectTab(Me.tpgDrugs)
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
                                Me.tbcInventoryTransfers.SelectTab(Me.tpgConsumables)
                                Me.BringToFront()
                                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                                Return False
                            End If
                        Next

                End Select
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

#Region " Save Methods "

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oInventoryTransfers As New SyncSoft.SQLDb.InventoryTransfers()
            Dim lInventoryTransfers As New List(Of DBConnect)

            With oInventoryTransfers

                .TransferNo = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
                .TransferDate = DateEnteredIn(Me.dtpTransferDate, "Transfer Date!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")
                If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                   Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(fromLocationID).ToUpper()) Then

                    message = "Selected from location " + Me.cboFromLocationID.Text + " is not the same as " + InitOptions.Location +
                        " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboFromLocationID.Focus() : Return

                End If

                Dim toLocationID As String = StringValueEnteredIn(Me.cboToLocationID, "To Location!")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .FromLocationID = fromLocationID
                .ToLocationID = toLocationID
                .OrderNo = RevertText(StringMayBeEnteredIn(Me.stbOrderNo))
                .StockCost = DecimalEnteredIn(stbTotalcost, False, "Total Cost!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If fromLocationID.ToUpper().Equals(toLocationID.ToUpper()) Then
                    message = "Selected 'From Location' " + Me.cboFromLocationID.Text + " can not be the same as 'To Location'! "
                    Me.cboToLocationID.Focus()
                    Throw New ArgumentException(message)
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lInventoryTransfers.Add(oInventoryTransfers)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugs.RowCount < 1 AndAlso Me.dgvConsumables.RowCount < 1 Then
                message = "Must register at least one item for drugs or consumables!"
                Throw New ArgumentException(message)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyDrugsEntries()
            Me.VerifyConsumablesEntries()
            Me.VerifyOtherItemsEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryTransfers, Action.Save))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SaveDrugs()
                    Me.SaveConsumables()
                    Me.SaveOtherItems()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.chkPrintOnSaving.Checked Then
                        message = "You have not checked Print Transfer On Saving. " + ControlChars.NewLine + "Would you want Transfer printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintInventoryTransfers()
                    Else : Me.PrintInventoryTransfers()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    Me.ResetTabControls()
                    Me.SetNextTransferNo()
                    Me.ClearControls()

                    Me.dtpTransferDate.Value = Today
                    Me.dtpTransferDate.Checked = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryTransfers, Action.Update, "InventoryTransfers"))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SaveDrugs()
                    Me.SaveConsumables()
                    Me.SaveOtherItems()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("record(s) updated successfully!")
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ex.Message.Contains("The Transfer No:") OrElse ex.Message.EndsWith("already exists") Then
                message = "The Transfer No: " + Me.stbTransferNo.Text + ", you are trying to enter already exists" +
                    ControlChars.NewLine + "If you are using the system generated number, probably another user has already taken it." +
                    ControlChars.NewLine + "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextTransferNo()
            Else : ErrorMessage(ex)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function SaveDrugs() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryTransferDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo, "Drug No!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity, "Quantity!")
                    Dim packID As String = StringEnteredIn(cells, Me.colDrugPack, "Pack!")
                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.colDrugPackSize, "Pack Size!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitCost, False, "UnitCost!")
                    If String.IsNullOrEmpty(packID) Then
                        packID = oPack.NA
                    End If
                    Dim batchNo As String = StringEnteredIn(cells, Me.colDrugBatchNo, "Batch No!")
                    Dim expiryDate As Date = DateEnteredIn(cells, Me.colDrugExpiryDate, "Expiry Date!")


                    Using oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
                        With oInventoryTransferDetails
                            .TransferNo = transferNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .PackID = packID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .BatchNo = batchNo
                            .ExpiryDate = expiryDate
                            .StockStatusID = oStockTypeID.Issued
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryTransferDetails.Add(oInventoryTransferDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryTransferDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDrugs.Item(Me.colDrugsSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryTransfers.SelectTab(Me.tpgDrugs.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgDrugs.Name)
            SaveDrugs = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyDrugsEntries() As Boolean

        Try

            Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.colDrugNo, "Drug No!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.colDrugName, "Drug Name!")
                Dim totalUnits As Integer = IntegerEnteredIn(row.Cells, Me.colDrugTotalUnits, "Total Units!")
                StringEnteredIn(row.Cells, Me.colDrugBatchNo, "Batch No!")
                DateEnteredIn(row.Cells, Me.colDrugExpiryDate, "Expiry Date!")

                If totalUnits < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, oItemCategoryID.Drug, itemCode)
                If locationBalance < totalUnits Then
                    Dim message As String = "You do not have sufficient balance to transfer for " + itemName + ". " + ControlChars.NewLine +
                        "Selected from location has " + locationBalance.ToString() + ", and you what to transfer " + totalUnits.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgDrugs.Name)
            VerifyDrugsEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveConsumables() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryTransferDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colConsumableNo, "Consumable No!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "Quantity!")
                    Dim batchNo As String = StringEnteredIn(cells, Me.colConsumableBatchNo, "Batch No!")
                    Dim expiryDate As Date = DateEnteredIn(cells, Me.colConsumableExpiryDate, "Expiry Date!")
                    Dim packID As String = StringEnteredIn(cells, Me.colConsumablePack, "Pack!")
                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.colConsumablePackSize, "Pack Size!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitCost, False, "UnitCost!")

                    If String.IsNullOrEmpty(packID) Then
                        packID = oPack.NA
                    End If

                    Using oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
                        With oInventoryTransferDetails
                            .TransferNo = transferNo
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = itemCode
                            .PackID = packID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .Quantity = quantity
                            .BatchNo = batchNo
                            .ExpiryDate = expiryDate
                            .StockStatusID = oStockTypeID.Issued
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryTransferDetails.Add(oInventoryTransferDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryTransferDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryTransfers.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgConsumables.Name)
            SaveConsumables = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyConsumablesEntries() As Boolean

        Try

            Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.colConsumableNo, "Consumable No!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable Name!")
                Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colConsumableBatchNo, "Batch No!")
                DateEnteredIn(row.Cells, Me.colConsumableExpiryDate, "Expiry Date!")

                If quantity < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, oItemCategoryID.Consumable, itemCode)
                If locationBalance < quantity Then
                    Dim message As String = "You do not have sufficient balance to transfer for " + itemName + ". " + ControlChars.NewLine +
                        "Selected from location has " + locationBalance.ToString() + ", and you what to transfer " + quantity.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgConsumables.Name)
            VerifyConsumablesEntries = False
            Throw ex

        End Try

    End Function



    Private Function SaveOtherItems() As Boolean

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

                Try

                    Dim transactions As New List(Of TransactionList(Of DBConnect))
                    Dim lInventoryTransferDetails As New List(Of DBConnect)

                    Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells

                    Dim itemCode As String = StringEnteredIn(cells, Me.colOtherItemsItemCode, "OtherItems No!")
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colOtherItemsQuantity, "Quantity!")
                    Dim batchNo As String = StringEnteredIn(cells, Me.colOtherItemsBatchNo, "Batch No!")
                    Dim expiryDate As Date = DateEnteredIn(cells, Me.colOtherItemsExpiryDate, "Expiry Date!")
                    Dim packID As String = StringEnteredIn(cells, Me.colOtherItemsPack, "Pack!")
                    Dim packSize As Integer = IntegerEnteredIn(cells, Me.colOtherItemsPackSize, "Pack Size!")
                    Dim unitCost As Decimal = DecimalEnteredIn(cells, Me.colOtherItemsUnitCost, False, "UnitCost!")

                    If String.IsNullOrEmpty(packID) Then
                        packID = oPack.NA
                    End If

                    Using oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
                        With oInventoryTransferDetails
                            .TransferNo = transferNo
                            .ItemCategoryID = oItemCategoryID.NonMedical
                            .ItemCode = itemCode
                            .PackID = packID
                            .PackSize = packSize
                            .UnitCost = unitCost
                            .Quantity = quantity
                            .BatchNo = batchNo
                            .ExpiryDate = expiryDate
                            .StockStatusID = oStockTypeID.Issued
                            .LoginID = CurrentUser.LoginID
                        End With
                        lInventoryTransferDetails.Add(oInventoryTransferDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInventoryTransferDetails, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcInventoryTransfers.SelectTab(Me.tpgOtherItems.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgOtherItems.Name)
            SaveOtherItems = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyOtherItemsEntries() As Boolean

        Try

            Dim fromLocationID As String = StringValueEnteredIn(Me.cboFromLocationID, "From location!")

            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For

                Dim itemCode As String = StringEnteredIn(row.Cells, Me.colOtherItemsItemCode, "OtherItems No!")
                Dim itemName As String = StringEnteredIn(row.Cells, Me.colOtherItemsItemName, "OtherItems Name!")
                Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colOtherItemsQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colOtherItemsBatchNo, "Batch No!")
                DateEnteredIn(row.Cells, Me.colOtherItemsExpiryDate, "Expiry Date!")

                If quantity < 0 Then Throw New ArgumentException("Quantity must be higher than zero!")

                Dim locationBalance As Integer = GetInventoryBalance(fromLocationID, oItemCategoryID.NonMedical, itemCode)
                If locationBalance < quantity Then
                    Dim message As String = "You do not have sufficient balance to transfer for " + itemName + ". " + ControlChars.NewLine +
                        "Selected from location has " + locationBalance.ToString() + ", and you what to transfer " + quantity.ToString() + "!"
                    Throw New ArgumentException(message)
                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcInventoryTransfers.SelectTab(Me.tpgOtherItems.Name)
            VerifyOtherItemsEntries = False
            Throw ex

        End Try

    End Function


#End Region

#Region " Drugs - Grid "


    Private Sub dgvDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugNo.Index OrElse Me.dgvDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDrugs.CurrentCell.RowIndex
        _DrugNo = StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

    End Sub

    Private Sub dgvDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDrugs.CellEndEdit

        Try

            Me.CalculateTotalDrugCost()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub dgvDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDrugs.Item(Me.colDrugsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            Dim itemCode As String = Me.dgvDrugs.Item(Me.colDrugNo.Name, toDeleteRowNo).Value.ToString()

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
            With oInventoryTransferDetails
                .TransferNo = transferNo
                .ItemCategoryID = oItemCategoryID.Drug
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryTransferDetails.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub ClearDrugGridColumns(ByVal selectedRow As Integer)

        If selectedRow >= 0 Then

            With Me.dgvDrugs
                .Item(Me.colDrugFromLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colDrugToLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colDrugBatchNo.Name, selectedRow).Value = String.Empty
                .Item(Me.colDrugExpiryDate.Name, selectedRow).Value = String.Empty
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Else

            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                With Me.dgvDrugs
                    .Item(Me.colDrugFromLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colDrugToLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colDrugBatchNo.Name, row.Index).Value = String.Empty
                    .Item(Me.colDrugExpiryDate.Name, row.Index).Value = String.Empty
                End With

            Next

        End If

    End Sub

    Private Sub ClearDrugGridColumns()
        Me.ClearDrugGridColumns(-1)
    End Sub

    Private Sub LoadDrugTransferDetails(ByVal transferNo As String)

        Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()

        Try

            Me.dgvDrugs.Rows.Clear()

            ' Load InventoryTransferDetails

            Dim transferDetails As DataTable = oInventoryTransferDetails.GetInventoryTransferDetails(transferNo, oItemCategoryID.Drug).Tables("InventoryTransferDetails")
            If transferDetails Is Nothing OrElse transferDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDrugs, transferDetails)

            For pos As Integer = 0 To transferDetails.Rows.Count - 1

                Dim dataRow As DataRow = transferDetails.Rows(pos)

                With Me.dgvDrugs

                    .Item(Me.colDrugPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            CalculateTotalDrugCost()
            For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDrugs.Item(Me.colDrugsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "


    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableNo.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableNo)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
            ' If e.ColumnIndex.Equals(Me.colConsumableNo.Index) Then If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            Dim itemCode As String = Me.dgvConsumables.Item(Me.colConsumableNo.Name, toDeleteRowNo).Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oInventoryTransferDetails
                .TransferNo = transferNo
                .ItemCategoryID = oItemCategoryID.Consumable
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryTransferDetails.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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


    Private Sub ClearConsumableGridColumns(ByVal selectedRow As Integer)

        If selectedRow >= 0 Then

            With Me.dgvConsumables
                .Item(Me.colConsumableFromLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colConsumableToLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colConsumableBatchNo.Name, selectedRow).Value = String.Empty
                .Item(Me.colConsumableExpiryDate.Name, selectedRow).Value = String.Empty
            End With

        Else

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                With Me.dgvConsumables
                    .Item(Me.colConsumableFromLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colConsumableToLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colConsumableBatchNo.Name, row.Index).Value = String.Empty
                    .Item(Me.colConsumableExpiryDate.Name, row.Index).Value = String.Empty
                End With

            Next

        End If

    End Sub

    Private Sub ClearConsumableGridColumns()
        Me.ClearConsumableGridColumns(-1)
    End Sub

    Private Sub LoadConsumableTransferDetails(ByVal transferNo As String)

        Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load InventoryTransferDetails

            Dim transferDetails As DataTable = oInventoryTransferDetails.GetInventoryTransferDetails(transferNo, oItemCategoryID.Consumable).Tables("InventoryTransferDetails")
            If transferDetails Is Nothing OrElse transferDetails.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadGridData(Me.dgvConsumables, transferDetails)
            For pos As Integer = 0 To transferDetails.Rows.Count - 1

                Dim dataRow As DataRow = transferDetails.Rows(pos)

                With Me.dgvConsumables

                    .Item(Me.colConsumablePack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            CalculateTotalConsumableCost()
            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " OtherItems - Grid "


    Private Sub dgvOtherItems_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOtherItems.CellBeginEdit

        If e.ColumnIndex <> Me.colOtherItemsItemCode.Index OrElse Me.dgvOtherItems.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex
        _ConsumableNo = StringMayBeEnteredIn(Me.dgvOtherItems.Rows(selectedRow).Cells, Me.colOtherItemsItemCode)

    End Sub

    Private Sub dgvOtherItems_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOtherItems.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvOtherItems.CurrentCell.RowIndex
            ' If e.ColumnIndex.Equals(Me.colConsumableNo.Index) Then If Me.dgvOtherItems.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub dgvOtherItems_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOtherItems.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim transferNo As String = RevertText(StringEnteredIn(Me.stbTransferNo, "Transfer No!"))
            Dim itemCode As String = Me.dgvOtherItems.Item(Me.colOtherItemsItemCode.Name, toDeleteRowNo).Value.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oInventoryTransferDetails
                .TransferNo = transferNo
                .ItemCategoryID = oItemCategoryID.NonMedical
                .ItemCode = itemCode
            End With

            DisplayMessage(oInventoryTransferDetails.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOtherItems_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOtherItems.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub


    Private Sub ClearOtherItemsGridColumns(ByVal selectedRow As Integer)

        If selectedRow >= 0 Then

            With Me.dgvOtherItems
                .Item(Me.colOtherItemsFromLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colOtherItemsToLocationBalance.Name, selectedRow).Value = String.Empty
                .Item(Me.colOtherItemsBatchNo.Name, selectedRow).Value = String.Empty
                .Item(Me.colOtherItemsExpiryDate.Name, selectedRow).Value = String.Empty
            End With

        Else

            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For

                With Me.dgvOtherItems
                    .Item(Me.colOtherItemsFromLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colOtherItemsToLocationBalance.Name, row.Index).Value = String.Empty
                    .Item(Me.colOtherItemsBatchNo.Name, row.Index).Value = String.Empty
                    .Item(Me.colOtherItemsExpiryDate.Name, row.Index).Value = String.Empty
                End With

            Next

        End If

    End Sub

    Private Sub ClearOtherItemsGridColumns()
        Me.ClearOtherItemsGridColumns(-1)
    End Sub

    Private Sub LoadOtherItemsTransferDetails(ByVal transferNo As String)

        Dim oInventoryTransferDetails As New SyncSoft.SQLDb.InventoryTransferDetails()

        Try

            Me.dgvOtherItems.Rows.Clear()

            ' Load InventoryTransferDetails

            Dim transferDetails As DataTable = oInventoryTransferDetails.GetInventoryTransferDetails(transferNo, oItemCategoryID.NonMedical).Tables("InventoryTransferDetails")
            If transferDetails Is Nothing OrElse transferDetails.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            LoadGridData(Me.dgvOtherItems, transferDetails)
            For pos As Integer = 0 To transferDetails.Rows.Count - 1

                Dim dataRow As DataRow = transferDetails.Rows(pos)

                With Me.dgvOtherItems

                    .Item(Me.colOtherItemsPack.Name, pos).Value = StringEnteredIn(dataRow, "PackID")

                End With


            Next

            CalculateTotalOtherItemsCost()
            For Each row As DataGridViewRow In Me.dgvOtherItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOtherItems.Item(Me.colOtherItemsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " InventoryTransfers Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintInventoryTransfers()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintInventoryTransfers()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDrugs.RowCount < 1 OrElse Me.dgvConsumables.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry on Transfer details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInventoryTransfersPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docInventoryTransfers
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInventoryTransfers.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docInventoryTransfers_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInventoryTransfers.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Internal Inventory Transfer".ToUpper()

            Dim transferNo As String = StringMayBeEnteredIn(Me.stbTransferNo)
            Dim transferDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpTransferDate))
            Dim orderNo As String = StringMayBeEnteredIn(Me.stbOrderNo)
            Dim orderDate As Date = DateMayBeEnteredIn(Me.stbOrderDate)
            Dim orderDateText As String = FormatDate(orderDate)
            Dim orderType As String = StringMayBeEnteredIn(Me.cboOrderType)
            Dim fromLocation As String = StringMayBeEnteredIn(Me.cboFromLocationID)
            Dim toLocation As String = StringMayBeEnteredIn(Me.cboToLocationID)
            Dim stockCost As String = StringMayBeEnteredIn(Me.stbTotalcost)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 18 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Transfer No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(transferNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Transfer Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(transferDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If Not orderDate = AppData.NullDateValue Then
                        .DrawString("Order No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(orderNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        .DrawString("Order Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                        .DrawString(orderDateText, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                        yPos += lineHeight

                    End If


                    .DrawString("From Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("To Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(toLocation, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Stock Cost: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(stockCost, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
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

                If transferParagraphs Is Nothing Then Return

                Do While transferParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(transferParagraphs(1), PrintParagraps)
                    transferParagraphs.Remove(1)

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
                        transferParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (transferParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInventoryTransfersPrintData()

        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        transferParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Total Units: ".PadLeft(padQuantity))
            tableHeader.Append(GetSpaces(1) + "Batch No: ".PadRight(padBatchNo))
            tableHeader.Append("Expiry Date: ".PadRight(padExpiryDate))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DrugsData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transferParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OtherItemsData().ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Transfered By:      " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:         " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Received By:        " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:         " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            transferParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function DrugsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvDrugs.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDrugs.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = cells.Item(Me.colDrugName.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.colDrugTotalUnits.Name).Value.ToString()
                Dim batchNo As String = StringMayBeEnteredIn(cells, Me.colDrugBatchNo)
                Dim expiryDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colDrugExpiryDate))

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 25 Then
                    tableData.Append(itemName.Substring(0, 25).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(GetSpaces(1) + batchNo.PadRight(padBatchNo))
                tableData.Append(expiryDate.PadRight(padExpiryDate))

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ConsumablesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = SubstringLeft(cells.Item(Me.colConsumableName.Name).Value.ToString())
                Dim quantity As String = cells.Item(Me.colConsumableTotalUnits.Name).Value.ToString()
                Dim batchNo As String = StringMayBeEnteredIn(cells, Me.colConsumableBatchNo)
                Dim expiryDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colConsumableExpiryDate))

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 25 Then
                    tableData.Append(itemName.Substring(0, 25).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(GetSpaces(1) + batchNo.PadRight(padBatchNo))
                tableData.Append(expiryDate.PadRight(padExpiryDate))

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Function OtherItemsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvOtherItems.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOtherItems.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = cells.Item(Me.colOtherItemsItemName.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.colOtherItemsTotalUnits.Name).Value.ToString()
                Dim batchNo As String = StringMayBeEnteredIn(cells, Me.colOtherItemsBatchNo)
                Dim expiryDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colOtherItemsExpiryDate))

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 25 Then
                    tableData.Append(itemName.Substring(0, 25).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(GetSpaces(1) + batchNo.PadRight(padBatchNo))
                tableData.Append(expiryDate.PadRight(padExpiryDate))

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region

#Region " Popup Menu "

    Private Sub cmsInventoryTransfers_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInventoryTransfers.Opening

        Select Case Me.tbcInventoryTransfers.SelectedTab.Name

            Case Me.tpgDrugs.Name
                Me.cmsInventoryTransfersQuickSearch.Visible = True

            Case Me.tpgConsumables.Name
                Me.cmsInventoryTransfersQuickSearch.Visible = True

            Case Else : Me.cmsInventoryTransfersQuickSearch.Visible = False

        End Select

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.stbTransferNo.ReadOnly = False
        Me.btnLoad.Enabled = True
        Me.pnlPrintOnSaving.Visible = False
        Me.btnPrint.Visible = True

        ResetControlsIn(Me)
        Me.ResetTabControls()
        Me.cboFromLocationID.Enabled = False
        Me.stbOrderNo.Enabled = False
        Me.fbnLoadOrders.Enabled = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbTransferNo.ReadOnly = InitOptions.TransferNoLocked
        Me.btnLoad.Enabled = False
        Me.pnlPrintOnSaving.Visible = True
        Me.btnPrint.Visible = False

        ResetControlsIn(Me)
        Me.ResetTabControls()
        Me.cboFromLocationID.Enabled = True
        Me.stbOrderNo.Enabled = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.SetNextTransferNo()
        Me.SetDefaultLocation()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dtpTransferDate.Value = Today
        Me.dtpTransferDate.Checked = True
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.fbnLoadOrders.Enabled = True

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
            Me.btnPrint.Enabled = False
        End If
    End Sub

    Private Sub fbnLoadOrders_Click(sender As Object, e As EventArgs) Handles fbnLoadOrders.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicInventoryOrders As New frmPeriodicInventoryOrders(Me.stbOrderNo)
            fPeriodicInventoryOrders.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim orderNo As String = RevertText(StringMayBeEnteredIn(Me.stbOrderNo))
            If String.IsNullOrEmpty(orderNo) Then Return
            Me.ShowInventoryOrders(orderNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub CalculateTotalDrugCost()


        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvDrugs, Me.colDrugTotalCost)

        Me.stbDrugCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        CalculateTotalCost()
    End Sub


    Private Sub CalculateTotalConsumableCost()

        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvConsumables, Me.colConsumableTotalCost)
        Me.stbConsumableCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateTotalCost()

    End Sub

    Private Sub CalculateTotalOtherItemsCost()

        Dim totalBill As Decimal = CalculateGridAmount(Me.dgvOtherItems, Me.colOtherItemsTotalCost)
        Me.stbOtherItems.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.CalculateTotalCost()

    End Sub

    Private Sub CalculateTotalCost()
        Dim drugCost As Decimal = DecimalMayBeEnteredIn(stbDrugCost)
        Dim consumableCost As Decimal = DecimalMayBeEnteredIn(stbConsumableCost)
        stbTotalcost.Text = FormatNumber((drugCost + consumableCost), AppData.DecimalPlaces)
    End Sub

#End Region


    Private Sub DetailDrug(ByVal selectedRow As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim fromLocationID As String = StringValueMayBeEnteredIn(Me.cboFromLocationID, "From Location!")
            Dim toLocationID As String = StringValueMayBeEnteredIn(Me.cboToLocationID, "To Location!")

            If selectedRow >= 0 Then

                Try

                    Dim drugNo As String = String.Empty
                    If Me.dgvDrugs.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvDrugs.Rows(selectedRow).Cells, Me.colDrugNo))
                    If String.IsNullOrEmpty(drugNo) Then Return



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
                    Dim drugRow As DataRow = drugs.Rows(0)

                    Dim hidden As Boolean = BooleanMayBeEnteredIn(drugRow, "Hidden")
                    Dim drugName As String = StringEnteredIn(drugRow, "DrugName", "Drug Name!")

                    If hidden Then Throw New ArgumentException("The Drug No: " + drugNo + ", is not enabled for selection. Contact administrator!")

                    With Me.dgvDrugs
                        .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                        .Item(Me.colDrugName.Name, selectedRow).Value = drugName
                        .Item(Me.colDrugStockStatus.Name, selectedRow).Value = GetLookupDataDes(oStockTypeID.Issued)
                    End With



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(fromLocationID) Then Return
                    Me.ClearDrugGridColumns(selectedRow)



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return
                    Dim row As DataRow = inventoryLocation.Rows(0)

                    Dim fromLocationBalance As Integer = IntegerMayBeEnteredIn(row, "UnitsAtHand")
                    Dim tolocationBalance As Integer = GetInventoryBalance(toLocationID, oItemCategoryID.Drug, drugNo)
                    Dim batchNo As String = StringMayBeEnteredIn(row, "BatchNo")
                    Dim expiryDate As Date = DateMayBeEnteredIn(row, "ExpiryDate")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''
                    With Me.dgvDrugs
                        .Item(Me.colDrugFromLocationBalance.Name, selectedRow).Value = fromLocationBalance
                        .Item(Me.colDrugToLocationBalance.Name, selectedRow).Value = tolocationBalance
                        .Item(Me.colDrugBatchNo.Name, selectedRow).Value = batchNo
                        If expiryDate = AppData.NullDateValue Then
                            .Item(Me.colDrugExpiryDate.Name, selectedRow).Value = String.Empty
                        Else : .Item(Me.colDrugExpiryDate.Name, selectedRow).Value = FormatDate(expiryDate)
                        End If
                    End With



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.dgvDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
                    Throw ex
                End Try

            Else

                If String.IsNullOrEmpty(fromLocationID) Then Return
                Me.ClearDrugGridColumns(selectedRow)

                For Each row As DataGridViewRow In Me.dgvDrugs.Rows
                    If row.IsNewRow Then Exit For

                    Dim drugNo As String = StringMayBeEnteredIn(row.Cells, Me.colDrugNo)
                    If String.IsNullOrEmpty(drugNo) Then Continue For



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''
                    Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(fromLocationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                    If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                    Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                    Dim fromLocationBalance As Integer = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")
                    Dim tolocationBalance As Integer = GetInventoryBalance(toLocationID, oItemCategoryID.Drug, drugNo)
                    Dim batchNo As String = StringMayBeEnteredIn(inventoryRow, "BatchNo")
                    Dim expiryDate As Date = DateMayBeEnteredIn(inventoryRow, "ExpiryDate")



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    With Me.dgvDrugs
                        .Item(Me.colDrugFromLocationBalance.Name, row.Index).Value = fromLocationBalance
                        .Item(Me.colDrugToLocationBalance.Name, row.Index).Value = tolocationBalance
                        .Item(Me.colDrugBatchNo.Name, row.Index).Value = batchNo
                        If expiryDate = AppData.NullDateValue Then
                            .Item(Me.colDrugExpiryDate.Name, row.Index).Value = String.Empty
                        Else : .Item(Me.colDrugExpiryDate.Name, row.Index).Value = FormatDate(expiryDate)
                        End If
                        .Item(Me.colDrugStockStatus.Name, row.Index).Value = GetLookupDataDes(oStockTypeID.Issued)
                    End With

                Next

            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub cboOrderType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrderType.SelectedIndexChanged

        Dim objectID As Integer
        Dim orderType As String = StringValueMayBeEnteredIn(Me.cboOrderType)

        If String.IsNullOrEmpty(orderType) Then Return
        If orderType.ToUpper.Equals(oOrderType.Internal.ToUpper) Then
            objectID = LookupObjects.Location
        Else
            objectID = LookupObjects.ExternalLocation
        End If

        LoadLookupDataCombo(Me.cboToLocationID, objectID, False)

    End Sub

    Private Sub lblOrderType_Click(sender As Object, e As EventArgs) Handles lblOrderType.Click

    End Sub

    Private Sub stbConsumableCost_TextChanged(sender As Object, e As EventArgs) Handles stbConsumableCost.TextChanged

    End Sub

    Private Sub stbTotalcost_TextChanged(sender As Object, e As EventArgs) Handles stbTotalcost.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub stbDrugCost_TextChanged(sender As Object, e As EventArgs) Handles stbDrugCost.TextChanged

    End Sub

    Private Sub tbcInventoryTransfers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcInventoryTransfers.SelectedIndexChanged

    End Sub


    Private Sub LoadInventoryLocations()

        cboToLocationID.DataSource = Nothing

        Dim oInventoryLocation As New InventoryLocation()
        Dim allInventoryLocation As DataTable = oInventoryLocation.GetAllInventionLocations().Tables("AllLocations")

        If allInventoryLocation.Rows.Count() < 1 Then Return
        Me.cboToLocationID.DataSource = allInventoryLocation
        cboToLocationID.DisplayMember = "DataDes"
        cboToLocationID.ValueMember = "DataID"
        Me.cboFromLocationID.SelectedIndex = -1

    End Sub
End Class