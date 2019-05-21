
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

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmInventory

#Region " Fields "

    Private defaultItemCategoryID As String = String.Empty
    Private defaultItemCode As String = String.Empty
    Private drugs As DataTable
    Private consumableItems As DataTable
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()

    Private inventoryStockTypeSaved As Boolean = False

    Private WithEvents docInventory As New PrintDocument()

    ' The paragraphs.
    Private inventoryParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oVariousOptions As New VariousOptions()

        Try

            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDefaultLocation()
            Me.EnabledPrintCTRLS(False)
            Me.nbxPhysicalStock.Enabled = oVariousOptions.EnableInventoryPhysicalStockEntry
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                Me.Text = "Drug Inventory"
                Me.lblItemCode.Text = "Drug Number"
                Me.lblItemName.Text = "Drug Name"

                Me.btnEditItem.Tag = "Drugs"
                Me.btnEditItem.Text = "E&dit Drug"

                Me.LoadDrugs()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                Me.Text = "Consumable Inventory"
                Me.lblItemCode.Text = "Consumable Number"
                Me.lblItemName.Text = "Consumable Name"

                Me.btnEditItem.Tag = "ConsumableItems"
                Me.btnEditItem.Text = "E&dit Consumable "

                Me.LoadConsumableItems()



            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper()) Then

                Me.Text = "Non Medical Items Inventory"
                Me.lblItemCode.Text = "Item Code"
                Me.lblItemName.Text = "Item Name"

                Me.btnEditItem.Tag = "OtherItems"
                Me.btnEditItem.Text = "E&dit Items "

                Me.LoadOtherItems()

            End If
            Me.dtpExpiryDate.MinDate = Today
            Me.dtpTransactionDate.MaxDate = Today
            Me.dtpTransactionDate.Checked = True
            LoadLookupDataCombo(Me.cboStockTypeID, LookupObjects.StockType, True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultItemCode) Then
                Me.ShowItemDetails(defaultItemCode)
                Me.pnlAlertItems.Visible = False
            Else
                Me.ShowToOrderItems()
                Me.ShowToExpireItems()
                Me.pnlAlertItems.Visible = True
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnSave, AccessRights.Write)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub LoadDrugs()

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs

            With oDrugs
                .DrugNo = String.Empty
                .DrugName = String.Empty
            End With

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, drugs, "DrugFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, consumableItems, "ConsumableFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadOtherItems()

        Dim otherItems As DataTable
        Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

        Try

            otherItems = oOtherItems.GetOtherItems().Tables("OtherItems")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboItemCode, otherItems, "ItemFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboItemCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboItemCode.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub cboItemCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemCode.Leave

        Try

            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Me.ShowItemDetails(itemCode)
            Me.ShowInventoryLocationBalance()
            Me.ShowAdjustedStock()

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub ShowItemDetails(ByVal itemCode As String)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oOtherItems As New SyncSoft.SQLDb.OtherItems()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim row As DataRow
            Dim itemName As String

            Me.EnabledPrintCTRLS(False)
            Me.cboItemCode.Text = itemCode.ToUpper()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                row = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                itemName = StringMayBeEnteredIn(row, "DrugName")

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                row = oConsumableItems.GetConsumableItems(itemCode).Tables("ConsumableItems").Rows(0)
                itemName = StringMayBeEnteredIn(row, "ConsumableName")

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.NonMedical.ToUpper()) Then

                row = oOtherItems.GetOtherItems(itemCode).Tables("OtherItems").Rows(0)
                itemName = StringMayBeEnteredIn(row, "ItemName")

            Else
                row = oDrugs.GetDrugs(itemCode).Tables("Drugs").Rows(0)
                itemName = StringMayBeEnteredIn(row, "DrugName")

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(itemName) Then Me.cboItemCode.Text = itemCode
            Me.stbItemName.Text = itemName
            Me.stbUnitMeasure.Text = StringMayBeEnteredIn(row, "UnitMeasure")
            Me.nbxOrderLevel.Value = StringMayBeEnteredIn(row, "OrderLevel")
            Me.chkHalted.Checked = BooleanMayBeEnteredIn(row, "Halted")
            Me.chkHidden.Checked = BooleanMayBeEnteredIn(row, "Hidden")
            Me.nbxUnitCost.Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitCost"), AppData.DecimalPlaces)
            Me.nbxUnitPrice.Value = FormatNumber(DecimalMayBeEnteredIn(row, "UnitPrice"), AppData.DecimalPlaces)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateInventoryNewBalance()
            Me.ShowInventoryLocationBalance()
            Me.EnabledPrintCTRLS(True)
            Security.Apply(Me.btnEditItem, AccessRights.Update)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboItemCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemCode.SelectedIndexChanged
        Me.CalculateInventoryNewBalance()
    End Sub

    Private Sub ClearControls()

        Me.stbItemName.Clear()
        Me.stbUnitMeasure.Clear()
        Me.nbxOrderLevel.Value = String.Empty
        Me.chkHalted.Checked = False
        Me.chkHidden.Checked = False
        Me.nbxUnitCost.Value = String.Empty
        Me.nbxUnitPrice.Value = String.Empty
        Me.btnEditItem.Enabled = False
        Me.EnabledPrintCTRLS(False)

    End Sub

    Private Sub ResetCountedStockCTRLS()

        Dim oStockTypeID As New LookupDataID.StockTypeID()

        Me.cboStockTypeID.SelectedValue = oStockTypeID.Received
        Me.nbxQuantity.Clear()
        Me.cboStockTypeID.Enabled = True
        Me.nbxQuantity.Enabled = True
        Me.stbDetails.Clear()

    End Sub

    Private Sub cboLocationID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocationID.SelectedIndexChanged
        Me.ShowInventoryLocationBalance()
        Me.ShowAdjustedStock()
    End Sub

    Private Sub cboItemCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItemCode.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub nbxQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nbxQuantity.TextChanged
        Me.CalculateInventoryNewBalance()
    End Sub

    Private Sub cboStockTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStockTypeID.SelectedIndexChanged

        Me.CalculateInventoryNewBalance()
        Me.SetBatchDetails()

    End Sub

    Private Sub nbxCountedStock_TextChanged(sender As System.Object, e As System.EventArgs) Handles nbxPhysicalStock.TextChanged
        Me.ShowAdjustedStock()
    End Sub

    Private Sub ShowAdjustedStock()

        Dim locationBalance As Integer
        Dim oStockTypeID As New LookupDataID.StockTypeID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ResetCountedStockCTRLS()

            If String.IsNullOrEmpty(Me.cboItemCode.Text) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode))
            Dim countedStock As Integer = IntegerMayBeEnteredIn(Me.nbxPhysicalStock, -1)

            If String.IsNullOrEmpty(itemCode) Then Return
            If countedStock < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(locationID) Then
                locationBalance = GetInventoryBalance(defaultItemCategoryID, itemCode)
            Else : locationBalance = GetInventoryBalance(locationID, defaultItemCategoryID, itemCode)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim quantity As Integer = countedStock - locationBalance

            If quantity > 0 Then
                Me.cboStockTypeID.SelectedValue = oStockTypeID.Received
                Me.nbxQuantity.Value = quantity.ToString()

                Me.cboStockTypeID.Enabled = False
                Me.nbxQuantity.Enabled = False
                Me.stbDetails.Text = "To tally system and physical stock at " + Me.cboLocationID.Text + ", " +
                                        quantity.ToString() + " unit(s) were received "

            ElseIf quantity < 0 Then
                quantity = Math.Abs(quantity)
                Me.cboStockTypeID.SelectedValue = oStockTypeID.Issued
                Me.nbxQuantity.Value = quantity.ToString()

                Me.cboStockTypeID.Enabled = False
                Me.nbxQuantity.Enabled = False
                Me.stbDetails.Text = "To tally system and physical stock at " + Me.cboLocationID.Text + ", " +
                                        quantity.ToString() + " unit(s) were issued "

            Else : Me.ResetCountedStockCTRLS()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function CalculateInventoryNewBalance() As Integer

        Dim balance As Integer
        Dim oStockTypeID As New LookupDataID.StockTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.nbxBalance.Clear()

            If String.IsNullOrEmpty(Me.cboItemCode.Text) Then Return 0

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode))
            Dim stockTypeID As String = StringValueMayBeEnteredIn(Me.cboStockTypeID)
            Dim quantity As Integer = IntegerMayBeEnteredIn(Me.nbxQuantity)

            If String.IsNullOrEmpty(itemCode) Then Return 0
            If String.IsNullOrEmpty(stockTypeID) Then Return 0

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If stockTypeID.Equals(oStockTypeID.Received) Then
                balance = GetInventoryBalance(defaultItemCategoryID, itemCode) + quantity

            ElseIf stockTypeID.Equals(oStockTypeID.Issued) Then
                balance = GetInventoryBalance(defaultItemCategoryID, itemCode) - quantity

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.nbxBalance.Value = balance.ToString()
            Me.nbxLocationBalance.Value = Me.GetLocationBalance(itemCode).ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return balance
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub SetBatchDetails()

        Dim oStockTypeID As New LookupDataID.StockTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim stockTypeID As String = StringValueMayBeEnteredIn(Me.cboStockTypeID)
            If String.IsNullOrEmpty(stockTypeID) Then Return

            ResetControlsIn(Me.pnlBatch)

            If stockTypeID.Equals(oStockTypeID.Received) Then
                Me.pnlBatch.Enabled = True

            ElseIf stockTypeID.Equals(oStockTypeID.Issued) Then
                Me.pnlBatch.Enabled = False

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowInventoryLocationBalance()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.nbxLocationBalance.Clear()
            Me.dgvInventoryLocation.Rows.Clear()

            If String.IsNullOrEmpty(Me.cboItemCode.Text) Then Return
            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode))

            If String.IsNullOrEmpty(itemCode) Then Return

            Me.nbxLocationBalance.Value = Me.GetLocationBalance(itemCode).ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInventoryLocation(defaultItemCategoryID, itemCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetLocationBalance(ByVal itemCode As String) As Integer

        Dim locationBalance As Integer
        Dim oStockTypeID As New LookupDataID.StockTypeID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            Dim stockTypeID As String = StringValueMayBeEnteredIn(Me.cboStockTypeID)
            Dim quantity As Integer = IntegerMayBeEnteredIn(Me.nbxQuantity)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(locationID) Then
                locationBalance = GetInventoryBalance(defaultItemCategoryID, itemCode)
            Else : locationBalance = GetInventoryBalance(locationID, defaultItemCategoryID, itemCode)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If stockTypeID.Equals(oStockTypeID.Received) Then
                locationBalance = locationBalance + quantity
            ElseIf stockTypeID.Equals(oStockTypeID.Issued) Then
                locationBalance = locationBalance - quantity
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return locationBalance
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Sub LoadInventoryLocation(ByVal itemCategoryID As String, ByVal itemCode As String)

        Try
            Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

            Me.Cursor = Cursors.WaitCursor

            Me.dgvInventoryLocation.Rows.Clear()

            If String.IsNullOrEmpty(itemCategoryID) OrElse String.IsNullOrEmpty(itemCode) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(itemCategoryID, itemCode).Tables("InventoryLocation")
            If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInventoryLocation, inventoryLocation)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub EnabledPrintCTRLS(state As Boolean)

        Try

            Me.chkPrintInventoryOnSaving.Checked = state
            Me.chkPrintInventoryOnSaving.Enabled = state
            Me.btnPrint.Enabled = state

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#Region " Alerts "

    Private Function ShowToOrderItems() As Integer

        Dim records As Integer
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                records = oDrugs.CountToOrderDrugs()
                Me.lblToOrderItems.Text = "To Order Drugs: " + records.ToString()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                records = oConsumableItems.CountToOrderConsumableItems()
                Me.lblToOrderItems.Text = "To Order Consumables: " + records.ToString()

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowToExpireItems() As Integer

        Dim records As Integer
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oVariousOptions As New VariousOptions()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                records = oDrugs.CountToExpireDrugs(oVariousOptions.ExpiryWarningDays)
                Me.lblToExpireItems.Text = "To Expire/Expired Drugs: " + records.ToString()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                records = oConsumableItems.CountToExpireConsumableItems(oVariousOptions.ExpiryWarningDays)
                Me.lblToExpireItems.Text = "To Expire/Expired Consumables: " + records.ToString()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return records
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub btnViewToOrderItemsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToOrderItemsList.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fToOrderItems As New frmToOrderItems(ItemsTo.Order, defaultItemCategoryID, Me.cboItemCode, False)
            fToOrderItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Me.ShowItemDetails(itemCode)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnViewToExpireItemsList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewToExpireItemsList.Click

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fToExpireItems As New frmToOrderItems(ItemsTo.Expire, defaultItemCategoryID, Me.cboItemCode, False)
            fToExpireItems.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboItemCode)).ToUpper()
            Me.ShowItemDetails(itemCode)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim records As Integer
        Dim message As String

        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemName As String = StringMayBeEnteredIn(Me.stbItemName)
            Dim barcode As String = StringMayBeEnteredIn(Me.stbBarCode)
            If String.IsNullOrEmpty(itemName) Then itemName = "This item"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkHalted.Checked Then
                message = itemName + " is halted and won’t be prescribed. " + ControlChars.NewLine +
                          "It’s recommended that you edit it and uncheck Halted. " + ControlChars.NewLine +
                          "Would you like to edit now? "

                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    If Me.btnEditItem.Enabled Then : Me.btnEditItem.PerformClick()
                    Else : DisplayMessage("You are not authorized to edit " + itemName + "!")
                    End If
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkHidden.Checked Then
                message = itemName + " is hidden and not visible at service point. " + ControlChars.NewLine +
                          "It’s recommended that you edit it and uncheck Hidden. " + ControlChars.NewLine +
                          "Would you like to edit now? "

                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then
                    If Me.btnEditItem.Enabled Then : Me.btnEditItem.PerformClick()
                    Else : DisplayMessage("You are not authorized to edit " + itemName + "!")
                    End If
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
            If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
               Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                message = "Selected location " + Me.cboLocationID.Text + " is not the same as " + InitOptions.Location +
                    " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oInventory As New SyncSoft.SQLDb.Inventory()

                With oInventory

                    .LocationID = locationID
                    .ItemCategoryID = defaultItemCategoryID
                    .ItemCode = StringEnteredIn(Me.cboItemCode, Me.lblItemCode.Text + "!")
                    .TranDate = DateEnteredIn(Me.dtpTransactionDate, "Transaction Date!")
                    .StockTypeID = StringValueEnteredIn(Me.cboStockTypeID)
                    Dim quantity As Integer = Me.nbxQuantity.GetInteger()
                    If quantity > 0 Then : .Quantity = quantity
                    Else : Throw New ArgumentException("Quantity must be higher than zero!")
                    End If
                    .Details = StringEnteredIn(Me.stbDetails, "Details")
                    .EntryModeID = oEntryModeID.Manual
                    .LoginID = CurrentUser.LoginID

                    If .StockTypeID.Equals(oStockTypeID.Received) Then
                        .BatchNo = StringEnteredIn(Me.stbBatchNo, "Batch No!")
                        .ExpiryDate = DateEnteredIn(Me.dtpExpiryDate, "Expiry Date!")

                    ElseIf .StockTypeID.Equals(oStockTypeID.Issued) Then
                        .BatchNo = StringMayBeEnteredIn(Me.stbBatchNo)
                        .ExpiryDate = DateMayBeEnteredIn(Me.dtpExpiryDate)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Not oVariousOptions.AllowInventoryManualIssuing() Then
                            message = "The system does not allow direct issuing of item(s)!"
                            Throw New ArgumentException(message)
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If Me.CalculateInventoryNewBalance() < 0 Then

                            If Not oVariousOptions.AllowManualIssuingToNegative() Then
                                message = "The system does not allow issuing of item(s) to negative stock balance!"
                                Throw New ArgumentException(message)
                            Else
                                message = "You are about to issue item(s) that will lead to negative stock balance. " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                            End If

                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim locationBalance As Integer = GetInventoryBalance(.LocationID, .ItemCategoryID, .ItemCode)
                        If locationBalance < quantity Then
                            If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                                message = "The system does not allow issuing of item: " + itemName + ", with unit(s) not present at selected location!"
                                Throw New ArgumentException(message)
                            Else
                                message = "You are about to issue item: " + itemName + ", with unit(s) not present at selected location. " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                            End If
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ValidateEntriesIn(Me)

                    .Save()

                    If Not String.IsNullOrEmpty(barcode) Then
                        transactions.Add(New TransactionList(Of DBConnect)(BarCodeDetailsList, Action.Save))
                        records = DoTransactions(transactions)
                    End If

                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not Me.chkPrintInventoryOnSaving.Checked Then

                    message = "You have not checked Print On Saving. " + ControlChars.NewLine + "Would you want inventory change printed?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintInventory(True)

                Else : Me.PrintInventory(True)

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)

            Me.SetDefaultLocation()
            Me.cboStockTypeID.SelectedValue = oStockTypeID.Received

            Me.dtpTransactionDate.Value = Today
            Me.dtpTransactionDate.Checked = True
            Me.EnabledPrintCTRLS(False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.pnlAlertItems.Visible = True Then
                Me.ShowToOrderItems()
                Me.ShowToExpireItems()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function BarCodeDetailsList() As List(Of DBConnect)

        Dim lBarCodeDetails As New List(Of DBConnect)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails

                Dim itemCode As String = StringEnteredIn(Me.cboItemCode, Me.lblItemCode.Text + "!")
                Dim barCode As String = StringMayBeEnteredIn(Me.stbBarCode)

                With oBarCodeDetails
                    .ItemCode = itemCode
                    .ItemCategoryID = defaultItemCategoryID
                    .BarCode = barCode
                    .LoginID = CurrentUser.LoginID
                End With

                lBarCodeDetails.Add(oBarCodeDetails)

            End Using

            Return lBarCodeDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Private Sub btnEditItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditItem.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim itemCode As String = StringEnteredIn(Me.cboItemCode, Me.lblItemCode.Text + "!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Drug.ToUpper()) Then

                Dim fDrugs As New frmDrugs(itemCode, True)
                fDrugs.Edit()
                fDrugs.ShowDialog()

            ElseIf defaultItemCategoryID.ToUpper().Equals(oItemCategoryID.Consumable.ToUpper()) Then

                Dim fConsumableItems As New frmConsumableItems(itemCode, True)
                fConsumableItems.Edit()
                fConsumableItems.ShowDialog()

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowItemDetails(itemCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Inventory Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintInventory(False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintInventory(ByVal inventorySaved As Boolean)

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.inventoryStockTypeSaved = inventorySaved
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docInventory
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docInventory.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub docInventory_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docInventory.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            If Me.inventoryStockTypeSaved Then
                title = AppData.ProductOwner.ToUpper() + " Inventory Change".ToUpper()
            Else : title = AppData.ProductOwner.ToUpper() + " Inventory Change (Provisional)".ToUpper()
            End If

            With e.Graphics

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 10 * widthTopFirst

                Dim oStockTypeID As New LookupDataID.StockTypeID()

                Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
                Dim itemName As String = StringMayBeEnteredIn(Me.stbItemName)
                Dim transactionDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpTransactionDate))
                Dim stockType As String = StringMayBeEnteredIn(Me.cboStockTypeID)
                Dim quantity As String = IntegerMayBeEnteredIn(Me.nbxQuantity).ToString()
                Dim locationBalance As String = IntegerMayBeEnteredIn(Me.nbxLocationBalance).ToString()
                Dim balance As String = IntegerMayBeEnteredIn(Me.nbxBalance).ToString()

                Dim details As String = StringMayBeEnteredIn(Me.stbDetails)
                Dim textLEN As Integer = 75
                Dim wordLines As Integer

                .DrawString("Location: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(location, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString(Me.lblItemName.Text + ": ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(itemName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Transaction Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(transactionDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Stock Type: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(stockType, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Quantity: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(quantity, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Location Balance: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(locationBalance, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("All Balance: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(balance, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(details) Then
                    details = "Details: " + details.Trim()
                    Dim detailsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedNotesData As List(Of String) = WrapText(details, textLEN)
                    If wrappedNotesData.Count > 1 Then
                        For pos As Integer = 0 To wrappedNotesData.Count - 1
                            detailsData.Append(wrappedNotesData(pos).Trim())
                            detailsData.Append(ControlChars.NewLine)
                        Next
                    Else : detailsData.Append(details)
                    End If

                    .DrawString(detailsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = detailsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventorySignData As New System.Text.StringBuilder(String.Empty)

                If stockType.ToUpper().Equals(GetLookupDataDes(oStockTypeID.Issued).ToUpper()) Then
                    inventorySignData.Append("Issued By:        " + GetCharacters("."c, 20))
                ElseIf stockType.ToUpper().Equals(GetLookupDataDes(oStockTypeID.Received).ToUpper()) Then
                    inventorySignData.Append("Received By:      " + GetCharacters("."c, 20))
                Else : inventorySignData.Append("Processed By:     " + GetCharacters("."c, 20))
                End If

                inventorySignData.Append(GetSpaces(4))
                inventorySignData.Append("Date:  " + GetCharacters("."c, 20))
                .DrawString(inventorySignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += 2 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim checkedSignData As New System.Text.StringBuilder(String.Empty)

                checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                checkedSignData.Append(GetSpaces(4))
                checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                .DrawString(checkedSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += 2 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                    Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim footerData As New System.Text.StringBuilder(String.Empty)

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

End Class